# ---------------------------------------------------------------
# L10n 登録漏れ検査
#
#   L10n.Get() は未登録キーに対して空文字を返すため、Register の書き忘れは
#   例外ではなく「画面から文字が消える」形で現れる。コミット前に本スクリプトを
#   実行し、参照されているキーが全て登録済みであることを確認する。
#
#   使い方:  powershell -ExecutionPolicy Bypass -File Tools\check-l10n.ps1
#   終了コード: 0 = 問題なし / 1 = 登録漏れあり
# ---------------------------------------------------------------

$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$script = Join-Path $root 'Assets\Script'
$locFile = Join-Path $script 'View\HomeTown.Localization.cs'
$fixFile = Join-Path $script 'Class\Fix.cs'

# --- Fix.cs に定義されている L10N_ 定数 ---
$defined = @{}
foreach ($line in [System.IO.File]::ReadAllLines($fixFile)) {
  $m = [regex]::Match($line, 'public\s+const\s+string\s+(L10N_\w+)\s*=\s*"([^"]*)"')
  if ($m.Success) { $defined[$m.Groups[1].Value] = $m.Groups[2].Value }
}

# --- HomeTown.Localization.cs で Register 済みの定数 ---
$locText = [System.IO.File]::ReadAllText($locFile)
$registered = @{}
foreach ($m in [regex]::Matches($locText, 'Register\(\s*Fix\.(L10N_\w+)\s*,')) {
  $registered[$m.Groups[1].Value] = $true
}

# --- コード全体で L10n.Get / Get_EN に渡されている定数 ---
$used = @{}
foreach ($f in Get-ChildItem $script -Recurse -Filter *.cs -File) {
  $n = 0
  foreach ($line in [System.IO.File]::ReadAllLines($f.FullName)) {
    $n++
    if ($line.TrimStart().StartsWith('//')) { continue }
    foreach ($m in [regex]::Matches($line, 'L10n\.Get(?:_EN)?\(\s*Fix\.(L10N_\w+)')) {
      $k = $m.Groups[1].Value
      if (-not $used.ContainsKey($k)) { $used[$k] = @() }
      $used[$k] += ("{0}:{1}" -f $f.Name, $n)
    }
  }
}

$fail = 0

Write-Host ''
Write-Host '=== [1] 参照されているが未登録のキー (実行時に空文字となる) ===' -ForegroundColor Cyan
$missing = $used.Keys | Where-Object { -not $registered.ContainsKey($_) } | Sort-Object
if ($missing) {
  foreach ($k in $missing) { Write-Host ("  NG  {0}   <- {1}" -f $k, ($used[$k] -join ', ')) -ForegroundColor Red }
  Write-Host ("  計 {0} 件" -f @($missing).Count) -ForegroundColor Red
  $fail = 1
} else {
  Write-Host '  なし' -ForegroundColor Green
}

Write-Host ''
Write-Host '=== [2] Fix.cs に定義があるが未登録のキー (未着手 / 要確認) ===' -ForegroundColor Cyan
$undef = $defined.Keys | Where-Object { -not $registered.ContainsKey($_) } | Sort-Object
if ($undef) {
  foreach ($k in $undef) { Write-Host ("  --  {0}" -f $k) -ForegroundColor Yellow }
  Write-Host ("  計 {0} 件" -f @($undef).Count) -ForegroundColor Yellow
} else {
  Write-Host '  なし' -ForegroundColor Green
}

Write-Host ''
Write-Host '=== [3] Fix.cs に定義が無いのに Register されているキー ===' -ForegroundColor Cyan
$ghost = $registered.Keys | Where-Object { -not $defined.ContainsKey($_) } | Sort-Object
if ($ghost) {
  foreach ($k in $ghost) { Write-Host ("  NG  {0}" -f $k) -ForegroundColor Red }
  $fail = 1
} else {
  Write-Host '  なし' -ForegroundColor Green
}

Write-Host ''
Write-Host '=== [4] 登録済みだがコードから参照されていないキー (死蔵 / 参考) ===' -ForegroundColor Cyan
$unused = $registered.Keys | Where-Object { -not $used.ContainsKey($_) } | Sort-Object
Write-Host ("  {0} 件" -f @($unused).Count)

# ---------------------------------------------------------------
# [5] 用語対応(グロッサリ)の一貫性検査
#
#   日本語説明文の 【用語】 と 英語説明文の [Term] が 1:1 で対応していることを検査する。
#   対応表はコメントではなく実コードから機械的に導出する:
#     (a) Fix.cs の  NAME / NAME_JP  ペア定数   (例 BUFF_SHADE="Shade" / BUFF_SHADE_JP="陰影")
#     (b) LocalizeGeneratedText の replacements 配列のうち 【JP】->[EN] の行
#   新しい用語を説明文に使うには (a) か (b) に登録する必要があり、
#   登録しないまま訳語を書くと本検査で落ちる。訳語の揺れも同時に検出される。
# ---------------------------------------------------------------

Write-Host ''
Write-Host '=== [5] 説明文の用語対応 (【JP】 と [EN] の 1:1 対応) ===' -ForegroundColor Cyan

$glossary = @{}   # 日本語用語 -> 英語用語
$origin   = @{}   # 日本語用語 -> 定義元(表示用)

# (a) Fix.cs の BUFF_/EFFECT_ 系 NAME / NAME_JP ペア
#     CLASS_* 等は属性タグと語が衝突する(【聖】= 属性 vs HolyLight = クラス名)ため対象外。
$allConst = @{}
$constAlias = @{}
foreach ($line in [System.IO.File]::ReadAllLines($fixFile)) {
  $m = [regex]::Match($line, 'public\s+const\s+string\s+(\w+)\s*=\s*"([^"]*)"')
  if ($m.Success) { $allConst[$m.Groups[1].Value] = $m.Groups[2].Value; continue }
  # 別の const を参照する定義 (例: BUFF_CLONE_JP = BUFF_CHAOTIC_SCHEMA;)
  $m = [regex]::Match($line, 'public\s+const\s+string\s+(\w+)\s*=\s*(\w+)\s*;')
  if ($m.Success) { $constAlias[$m.Groups[1].Value] = $m.Groups[2].Value }
}
# 参照の連鎖を解決する
for ($pass = 0; $pass -lt 5; $pass++) {
  foreach ($k in @($constAlias.Keys)) {
    $target = $constAlias[$k]
    if ($allConst.ContainsKey($target)) { $allConst[$k] = $allConst[$target]; $constAlias.Remove($k) }
  }
}
foreach ($k in $constAlias.Keys) {
  Write-Host ("  NG  Fix.{0} = {1} の参照先が解決できない" -f $k, $constAlias[$k]) -ForegroundColor Red
  $fail = 1
}
foreach ($name in $allConst.Keys) {
  if ($name -notlike '*_JP') { continue }
  if (-not ($name -like 'BUFF_*' -or $name -like 'EFFECT_*' -or $name -like 'TERM_*')) { continue }
  $baseName = $name -replace '_JP$', ''
  if (-not $allConst.ContainsKey($baseName)) { continue }
  $ja = $allConst[$name]; $en = $allConst[$baseName]
  if ($ja -notmatch '[぀-ヿ㐀-鿿]') { continue }   # JP側に日本語が無いものは対象外
  if ($en -match '[぀-ヿ㐀-鿿]') { continue }      # EN側に日本語が残るものは対象外
  $glossary[$ja] = $en
  $origin[$ja] = "Fix.$baseName"
}

# (b) 【JP】->[EN] を literal で直書きした置換ルールが残っていないか
#     (TermTags から生成する方式に統一済みのため、残っていれば二重定義)
foreach ($m in [regex]::Matches($locText, 'new string\[\]\s*\{\s*"【([^"】]+)】"\s*,\s*"\[([^"\]]+)\]"\s*\}')) {
  Write-Host ("  NG  置換ルールに 【{0}】->[{1}] が直書きされている (L10n.TermTags に統一すること)" -f $m.Groups[1].Value, $m.Groups[2].Value) -ForegroundColor Red
  $fail = 1
}

# (c) TermTags 配列 — Fix 定数ペアを参照していることを確認する
$tagBlock = [regex]::Match($locText, 'TermTags\s*=\s*new\s*\(string ja, string en\)\[\]\s*\{(?<body>[^}]*)\}')
if (-not $tagBlock.Success) {
  Write-Host '  NG  L10n.TermTags が見つからない' -ForegroundColor Red
  $fail = 1
} else {
  foreach ($m in [regex]::Matches($tagBlock.Groups['body'].Value, '\(\s*Fix\.(\w+)\s*,\s*Fix\.(\w+)\s*\)')) {
    $cJa = $m.Groups[1].Value; $cEn = $m.Groups[2].Value
    if (($cJa -replace '_JP$','') -cne $cEn -or $cJa -notlike '*_JP') {
      Write-Host ("  NG  TermTags: 用語ペアが不整合 (Fix.{0}, Fix.{1})" -f $cJa, $cEn) -ForegroundColor Red
      $fail = 1; continue
    }
    if (-not $allConst.ContainsKey($cJa) -or -not $allConst.ContainsKey($cEn)) {
      Write-Host ("  NG  TermTags: Fix.{0} / Fix.{1} が見つからない" -f $cJa, $cEn) -ForegroundColor Red
      $fail = 1; continue
    }
    $glossary[$allConst[$cJa]] = $allConst[$cEn]
    $origin[$allConst[$cJa]] = "Fix.$cEn"
  }
}

# Register 済みキーの (ja, en) — Term(Fix.L10N_*) の解決に使う
$regValue = @{}
$simpleRe = [regex]'Register\(\s*Fix\.(L10N_\w+)\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"\s*\)'
foreach ($m in $simpleRe.Matches($locText)) {
  $regValue[$m.Groups[1].Value] = @{ ja = $m.Groups[2].Value; en = $m.Groups[3].Value }
}

# (c2) Register に用語ペアとして渡されている定数を用語表へ取り込む
#      接頭辞(BUFF_/EFFECT_/TERM_)に当てはまらない定数でも、用語引数として
#      使われている以上は用語である (例: Fix.DEFENSE / DEFENSE_JP)。
foreach ($m in [regex]::Matches($locText, '\(\s*Fix\.(\w+_JP)\s*,\s*Fix\.(\w+)\s*\)')) {
  $cJa = $m.Groups[1].Value; $cEn = $m.Groups[2].Value
  if (($cJa -replace '_JP$','') -cne $cEn) { continue }
  if (-not $allConst.ContainsKey($cJa) -or -not $allConst.ContainsKey($cEn)) { continue }
  $glossary[$allConst[$cJa]] = $allConst[$cEn]
  if (-not $origin.ContainsKey($allConst[$cJa])) { $origin[$allConst[$cJa]] = "Fix.$cEn" }
}

# (c3) Term(Fix.L10N_*) で用語として渡されている登録も用語表へ取り込む
#      (例: 【潜在能力】は Fix の定数ペアではなく L10N_POTENTIAL の登録が定義元)
$regJaEnPre = @{}
foreach ($m in [regex]::Matches($locText, 'Register\(\s*Fix\.(L10N_\w+)\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"\s*\)')) {
  $regJaEnPre[$m.Groups[1].Value] = @{ ja = $m.Groups[2].Value; en = $m.Groups[3].Value }
}
foreach ($m in [regex]::Matches($locText, 'Term\(\s*Fix\.(L10N_\w+)\s*\)')) {
  $rk = $m.Groups[1].Value
  if (-not $regJaEnPre.ContainsKey($rk)) { continue }
  $rja = $regJaEnPre[$rk].ja; $ren = $regJaEnPre[$rk].en
  if ($rja -notmatch '[぀-ヿ㐀-鿿]') { continue }
  if ($ren -match '[぀-ヿ㐀-鿿]') { continue }
  $glossary[$rja] = $ren
  if (-not $origin.ContainsKey($rja)) { $origin[$rja] = "Fix.$rk" }
}

# (d) 置換ルールと Register 登録の二重定義チェック
#     同じ日本語に対して置換ルールと Register が別々の英訳を持っていないか
$regJaEn = @{}
foreach ($m in [regex]::Matches($locText, 'Register\(\s*Fix\.(L10N_\w+)\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"\s*\)')) {
  $regJaEn[$m.Groups[2].Value] = @{ key = $m.Groups[1].Value; en = $m.Groups[3].Value }
}
foreach ($m in [regex]::Matches($locText, 'new string\[\]\s*\{\s*"((?:[^"\\]|\\.)*)"\s*,\s*"((?:[^"\\]|\\.)*)"\s*\}')) {
  $rja = $m.Groups[1].Value; $ren = $m.Groups[2].Value
  if ($regJaEn.ContainsKey($rja) -and $regJaEn[$rja].en -cne $ren) {
    Write-Host ("  NG  '{0}' の英訳が不一致: 置換ルール='{1}' / Fix.{2}='{3}'" -f $rja, $ren, $regJaEn[$rja].key, $regJaEn[$rja].en) -ForegroundColor Red
    $fail = 1
  }
}

$termNG = 0
$argRe  =[regex]'(?:\(\s*Fix\.\w+\s*,\s*Fix\.\w+\s*\)|Term\(\s*Fix\.\w+\s*\))'
$pairRe = [regex]('Register\(\s*Fix\.(L10N_\w+)\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"((?:\s*,\s*(?:\r?\n\s*)?' + $argRe.ToString() + ')*)\s*\)')
foreach ($m in $pairRe.Matches($locText)) {
  $key = $m.Groups[1].Value; $ja = $m.Groups[2].Value; $en = $m.Groups[3].Value

  # --- 用語引数の検査と $N の解決 ---
  #     (Fix.XXX_JP, Fix.XXX) = Fix の定数ペア / Term(Fix.L10N_XXX) = 登録済みキーの再利用
  $pairs = @($argRe.Matches($m.Groups[4].Value))
  # $1 が $11 の一部に誤ヒットしないよう、添字の大きい方から置換する
  # (Register 側の実装と同じ順序であること)。
  for ($pi = $pairs.Count - 1; $pi -ge 0; $pi--) {
    $arg = $pairs[$pi].Value
    $tm = [regex]::Match($arg, 'Term\(\s*Fix\.(\w+)\s*\)')
    if ($tm.Success) {
      $refKey = $tm.Groups[1].Value
      if (-not $regValue.ContainsKey($refKey)) {
        Write-Host ("  NG  {0}: Term(Fix.{1}) の参照先が未登録、または自身より後に登録されている" -f $key, $refKey) -ForegroundColor Red
        $termNG++; continue
      }
      $ja = $ja.Replace(('$' + $pi), $regValue[$refKey].ja)
      $en = $en.Replace(('$' + $pi), $regValue[$refKey].en)
      continue
    }
    $cm = [regex]::Match($arg, '\(\s*Fix\.(\w+)\s*,\s*Fix\.(\w+)\s*\)')
    $cJa = $cm.Groups[1].Value; $cEn = $cm.Groups[2].Value
    if (($cJa -replace '_JP$','') -cne $cEn -or $cJa -notlike '*_JP') {
      Write-Host ("  NG  {0}: 用語ペアが不整合 (Fix.{1}, Fix.{2}) — 同一基底名の XXX_JP / XXX を渡すこと" -f $key, $cJa, $cEn) -ForegroundColor Red
      $termNG++; continue
    }
    if (-not $allConst.ContainsKey($cJa) -or -not $allConst.ContainsKey($cEn)) {
      Write-Host ("  NG  {0}: Fix.{1} / Fix.{2} が Fix.cs に見つからない" -f $key, $cJa, $cEn) -ForegroundColor Red
      $termNG++; continue
    }
    $ja = $ja.Replace(('$' + $pi), $allConst[$cJa])
    $en = $en.Replace(('$' + $pi), $allConst[$cEn])
  }
  $leftJa = @([regex]::Matches($ja, '\$\d+') | ForEach-Object { $_.Value } | Sort-Object -Unique)
  $leftEn = @([regex]::Matches($en, '\$\d+') | ForEach-Object { $_.Value } | Sort-Object -Unique)
  if ($leftJa.Count -gt 0 -or $leftEn.Count -gt 0) {
    Write-Host ("  NG  {0}: 未解決のトークンが残っている ja={1} en={2} (用語ペアの個数不足)" -f $key, ($leftJa -join ','), ($leftEn -join ',')) -ForegroundColor Red
    $termNG++
  }

  # --- 数字表記の検査 ---
  #     説明文の散文は半角数字に統一する。英文の全角数字は常に誤り。
  if ($key -like 'L10N_DESC_*') {
    $jaFull = @([regex]::Matches($ja, '[０-９]')).Count
    $jaHalf = @([regex]::Matches($ja, '[0-9]')).Count
    if ($jaFull -gt 0 -and $jaHalf -gt 0) {
      Write-Host ("  [警告] {0}: 日本語文で全角数字と半角数字が混在 (全角{1}/半角{2}) — 半角に統一すること" -f $key, $jaFull, $jaHalf) -ForegroundColor Yellow
    } elseif ($jaFull -gt 0) {
      Write-Host ("  [警告] {0}: 日本語文が全角数字 ({1}文字) — 散文は半角に統一すること" -f $key, $jaFull) -ForegroundColor Yellow
    }
  }
  if (@([regex]::Matches($en, '[０-９]')).Count -gt 0) {
    Write-Host ("  NG  {0}: 英文に全角数字が含まれている" -f $key) -ForegroundColor Red
    $termNG++
  }

  # --- 不採用と決めた訳語が復活していないか ---
  #     決定の経緯は HomeTown.Localization.cs の「訳語の決定事項」を参照。
  foreach ($banned in @(
      @('in a row',       'consecutively を使うこと (row は隊列と紛らわしい)'),
      @('combatant',      'All Allies and Enemies を使うこと (軍事的レジスター)'),
      @('non-elemental',  'Colorless を使うこと (本作の属性体系と合わない)'),
      @('execut',         'perform / take / repeat を使うこと (execute は処刑・即死技を連想させる)'))) {
    if ($en -match ('(?i)' + [regex]::Escape($banned[0]))) {
      Write-Host ("  NG  {0}: 不採用の訳語 '{1}' — {2}" -f $key, $banned[0], $banned[1]) -ForegroundColor Red
      $termNG++
    }
  }

  # --- 表記スタイルの検査 (説明文のみ) ---
  if ($key -like 'L10N_DESC_*') {
    # 属性ダメージは 【物理】ダメージ のように括弧付きで書く。
    # 「物理」の一部である「理」を誤検出しないよう、
    # 括弧内を伏せ字にし、長い属性名から順に伏せてから 1 文字の属性を探す。
    $scan = [regex]::Replace($ja, '【[^】]*】', '~')
    foreach ($a in @('物理', '魔法')) {
      if ($scan -match ($a + 'ダメージ')) {
        Write-Host ("  [警告] {0}: 【{1}】ダメージ と書くこと (括弧なしの「{1}ダメージ」)" -f $key, $a) -ForegroundColor Yellow
      }
      $scan = $scan.Replace($a, '~~')
    }
    foreach ($a in @('炎', '氷', '聖', '闇', '理')) {
      if ($scan -match ($a + 'ダメージ')) {
        Write-Host ("  [警告] {0}: 【{1}】ダメージ と書くこと (括弧なしの「{1}ダメージ」)" -f $key, $a) -ForegroundColor Yellow
      }
    }
    # ダメージ付与とBUFF付与は文を分ける。連用中止だと BUFF の付与先が省略され、
    # 「敵にダメージ / 自分にBUFF」型の説明文と書式が揃わなくなる。
    if ($ja -match 'ダメージを与え、') {
      Write-Host ("  [警告] {0}: 「ダメージを与える。」で文を分けること (連用中止「与え、」)" -f $key) -ForegroundColor Yellow
    }
  }

  # 【 {0} 】 のような書式プレースホルダは用語ではないため除外する。
  $jaTerms = @([regex]::Matches($ja, '【([^】]+)】') | ForEach-Object { $_.Groups[1].Value } |
                Where-Object { $_ -notmatch '[{}]' } | Sort-Object -Unique)
  # 英文側の用語表記は [Term] が正。既存テキストに 【Term】 形式が残っているため両方を拾い、
  # 【Term】 を使っている場合は表記ゆれとして警告する。
  $enTerms = @([regex]::Matches($en, '\[([^\]]+)\]') | ForEach-Object { $_.Groups[1].Value } |
                Where-Object { $_ -notmatch '[{}]' } | Sort-Object -Unique)
  $enBracketJa = @([regex]::Matches($en, '【([^】]+)】') | ForEach-Object { $_.Groups[1].Value } |
                Where-Object { $_ -notmatch '[{}]' } | Sort-Object -Unique)
  foreach ($t in $enBracketJa) {
    if ($t -notmatch '[぀-ヿ㐀-鿿]') {
      Write-Host ("  [警告] {0}: 英文が 【{1}】 表記 ([{1}] が正)" -f $key, $t) -ForegroundColor Yellow
    }
  }
  $enTerms = @($enTerms + $enBracketJa | Sort-Object -Unique)
  if ($jaTerms.Count -eq 0 -and $enTerms.Count -eq 0) { continue }

  foreach ($t in $jaTerms) {
    if (-not $glossary.ContainsKey($t)) {
      Write-Host ("  NG  {0}: 用語 【{1}】 が未定義 (Fix.cs に XXX / XXX_JP ペアを追加すること)" -f $key, $t) -ForegroundColor Red
      $termNG++; continue
    }
    if ($enTerms -notcontains $glossary[$t]) {
      Write-Host ("  NG  {0}: 【{1}】 に対応する [{2}] が英文に無い ({3})" -f $key, $t, $glossary[$t], $origin[$t]) -ForegroundColor Red
      $termNG++
    }
  }
  foreach ($t in $enTerms) {
    $back = $glossary.Keys | Where-Object { $glossary[$_] -ceq $t }
    if (-not $back) {
      Write-Host ("  NG  {0}: 英文の [{1}] が用語表に無い (訳語の揺れの可能性)" -f $key, $t) -ForegroundColor Red
      $termNG++; continue
    }
    if (-not ($back | Where-Object { $jaTerms -contains $_ })) {
      Write-Host ("  NG  {0}: 英文の [{1}] に対応する 【{2}】 が日本語文に無い" -f $key, $t, ($back -join '/')) -ForegroundColor Red
      $termNG++
    }
  }
}
if ($termNG -eq 0) { Write-Host ('  なし (用語表 {0} 語)' -f $glossary.Count) -ForegroundColor Green } else { Write-Host ("  計 {0} 件" -f $termNG) -ForegroundColor Red; $fail = 1 }

Write-Host ''
Write-Host ('--- 定義 {0} / 登録 {1} / 参照 {2} / 用語 {3} ---' -f $defined.Count, $registered.Count, $used.Count, $glossary.Count)
if ($fail -eq 0) { Write-Host '検査OK' -ForegroundColor Green } else { Write-Host '検査NG' -ForegroundColor Red }
exit $fail
