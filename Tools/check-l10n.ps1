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
  $m = [regex]::Match($line, 'public\s+const\s+string\s+(L10N_\w+)\s*=\s*@?"([^"]*)"')
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
Write-Host '=== [3b] 英訳が空文字の登録 (許可リスト外は登録漏れの疑い) ===' -ForegroundColor Cyan
# L10n.Get は未登録キーでも空文字を返すため、意図的な空文字と登録漏れが実行時に区別できない。
# 英語に対応語を持たない助数詞などは、ここに明示して初めて許可する。
$allowEmptyEn = @(
  'L10N_EF_TIMES_SUFFIX'   # 「回」。英語には助数詞が無いため訳を置かない (Attack Count 3)
)
$emptyNG = 0
foreach ($m in [regex]::Matches($locText, 'Register\(\s*Fix\.(L10N_\w+)\s*,\s*"((?:[^"\\]|\\.)+)"\s*,\s*""\s*\)')) {
  $k = $m.Groups[1].Value
  if ($allowEmptyEn -contains $k) {
    Write-Host ("  --  {0} (許可: ja='{1}')" -f $k, $m.Groups[2].Value) -ForegroundColor Yellow
    continue
  }
  Write-Host ("  NG  {0}: 英訳が空文字 (ja='{1}') — 意図的なら check-l10n.ps1 の allowEmptyEn に追加すること" -f $k, $m.Groups[2].Value) -ForegroundColor Red
  $emptyNG++
}
if ($emptyNG -gt 0) { $fail = 1 }
if ($emptyNG -eq 0 -and @($allowEmptyEn).Count -eq 0) { Write-Host '  なし' -ForegroundColor Green }

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
  $m = [regex]::Match($line, 'public\s+const\s+string\s+(\w+)\s*=\s*@?"([^"]*)"')
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

  # 用語ではない 【】 の中身。書式プレースホルダと、見出しとして使われる語を除外する。
  $notTerm = @('特殊効果')
  $jaTerms = @([regex]::Matches($ja, '【([^】]+)】') | ForEach-Object { $_.Groups[1].Value } |
                Where-Object { $_ -notmatch '[{}]' -and $notTerm -notcontains $_ } | Sort-Object -Unique)
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

# ---------------------------------------------------------------
# [6] 英訳が未了の登録 (英語側に日本語が残っているもの)
#
#   訳語が未確定な語は、日英とも日本語原文で登録して「対応漏れではなく訳出保留」
#   であることを示す運用にしている。ここに並ぶ件数が英訳の残作業量になる。
# ---------------------------------------------------------------
Write-Host ''
Write-Host '=== [6] 英語側に日本語が残る登録 ===' -ForegroundColor Cyan
# 「訳出保留」(いずれ英訳する)と「変換しない」(日本語のまま出すのが仕様)を区別する。
# 後者は行末に「// 変換しない。」と書くことで宣言し、訳出保留の残数から除外する。
$pendingRe = [regex]'Register\(\s*Fix\.(L10N_\w+)\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"\s*,\s*(?:\r?\n\s*)?"((?:[^"\\]|\\.)*)"\s*\)\s*;?\s*(//.*)?'
$pending = @()
$intentional = @()
foreach ($m in $pendingRe.Matches($locText)) {
  $pja = $m.Groups[2].Value; $pen = $m.Groups[3].Value
  if ($pen -notmatch '[぀-ヿ㐀-鿿]') { continue }
  $row = [pscustomobject]@{ Key = $m.Groups[1].Value; Ja = $pja; Same = ($pja -ceq $pen) }
  if ($m.Groups[4].Value -match '変換しない') { $intentional += $row; continue }
  $pending += $row
}
if ($intentional.Count -gt 0) {
  Write-Host ("  -- 変換しない (仕様): {0} 件" -f $intentional.Count) -ForegroundColor DarkGray
}
if ($pending.Count -eq 0) {
  Write-Host '  なし' -ForegroundColor Green
} else {
  $byPrefix = $pending | Group-Object { ($_.Key -split '_')[0..2] -join '_' } | Sort-Object Count -Descending
  foreach ($g in $byPrefix) {
    Write-Host ("  {0,-28} {1,3} 件" -f $g.Name, $g.Count) -ForegroundColor Yellow
  }
  $mismatch = @($pending | Where-Object { -not $_.Same })
  if ($mismatch.Count -gt 0) {
    foreach ($x in $mismatch) {
      Write-Host ("  NG  {0}: 英語側に日本語が混在 (ja と一致しない)" -f $x.Key) -ForegroundColor Red
    }
    $fail = 1
  }
  Write-Host ("  ---- 訳出保留 計 {0} 件" -f $pending.Count) -ForegroundColor Yellow
}

# ---------------------------------------------------------------
# [7] 日本語定数が L10n を経由せず画面に出ている箇所
#
#   .text 代入などの表示シンクへ Fix.<日本語を持つ定数> が直接渡されると、
#   英語モードでも日本語が表示される。リテラルではなく定数経由のため、
#   「日本語リテラルを探す」方式では検出できない。宿屋の料理名はこれで見落とした。
# ---------------------------------------------------------------
Write-Host ''
Write-Host '=== [7] 日本語定数が L10n を経由せず表示されている箇所 ===' -ForegroundColor Cyan
$jpConst = @{}
foreach ($k in $allConst.Keys) {
  if ($allConst[$k] -match '[぀-ヿ㐀-鿿]') { $jpConst[$k] = $allConst[$k] }
}
$sinkRe = '\.text\s*=|SetupItemDetail\(|SetMessage\(|ShowMessage\(|\.Description\s*='
$leak = @()
foreach ($f in Get-ChildItem $script -Recurse -Filter *.cs -File) {
  if ($f.Name -in @('Fix.cs', 'HomeTown.Localization.cs', 'MessagePack.cs')) { continue }
  $n = 0
  foreach ($line in [System.IO.File]::ReadAllLines($f.FullName)) {
    $n++
    $t = $line.Trim()
    if ($t.StartsWith('//')) { continue }
    if ($t -notmatch $sinkRe) { continue }
    if ($t -match 'L10n\.') { continue }
    foreach ($m in [regex]::Matches($line, 'Fix\.(\w+)')) {
      if ($jpConst.ContainsKey($m.Groups[1].Value)) {
        $leak += [pscustomobject]@{ File = $f.Name; Line = $n; Const = $m.Groups[1].Value }
      }
    }
  }
}
if ($leak.Count -eq 0) {
  Write-Host '  なし' -ForegroundColor Green
} else {
  foreach ($g in ($leak | Group-Object { ($_.Const -split '_')[0..1] -join '_' } | Sort-Object Count -Descending)) {
    Write-Host ("  --  {0,-26} {1,4} 件" -f $g.Name, $g.Count) -ForegroundColor Yellow
  }
  Write-Host ("  ---- 計 {0} 件 / 固有定数 {1} 種" -f $leak.Count, @($leak.Const | Sort-Object -Unique).Count) -ForegroundColor Yellow
}

# === [8] Term(Fix.X) の参照が X の登録より前に無いか ===
# Register は呼び出し時点で $N を確定させるため、参照先が未登録だと Term が (key, key) を返し、
# キー文字列 (lblAreaNameFazilCastle 等) がそのまま英文に残る。実行時 LogError は出るが
# 画面を見ないと気付けないため、静的に検出する。
Write-Host ''
Write-Host '=== [8] Term 参照が登録より前にある箇所 ==='
$locLines = [System.IO.File]::ReadAllLines($locFile)
$regFirst = @{}
for ($i = 0; $i -lt $locLines.Count; $i++) {
  $mm = [regex]::Match($locLines[$i], '^\s*Register\(Fix\.(\w+)\s*,')
  if ($mm.Success -and -not $regFirst.ContainsKey($mm.Groups[1].Value)) { $regFirst[$mm.Groups[1].Value] = $i + 1 }
}
$termBad = @()
$curReg = ''
$curRegLine = 0
for ($i = 0; $i -lt $locLines.Count; $i++) {
  $mm = [regex]::Match($locLines[$i], '^\s*Register\(Fix\.(\w+)\s*,')
  if ($mm.Success) { $curReg = $mm.Groups[1].Value; $curRegLine = $i + 1 }
  foreach ($tm in [regex]::Matches($locLines[$i], 'Term\(Fix\.(\w+)\)')) {
    $tk = $tm.Groups[1].Value
    if (-not $regFirst.ContainsKey($tk)) {
      $termBad += ('  L{0}  {1} が Term({2}) を参照: {2} の登録が存在しない' -f ($i + 1), $curReg, $tk)
    }
    elseif ($regFirst[$tk] -ge $curRegLine) {
      $termBad += ('  L{0}  {1} (L{2}) が Term({3}) を参照 -> {3} の登録は L{4} で後方' -f ($i + 1), $curReg, $curRegLine, $tk, $regFirst[$tk])
    }
  }
}
if ($termBad.Count -eq 0) {
  Write-Host '  なし' -ForegroundColor Green
} else {
  foreach ($b in $termBad) { Write-Host $b -ForegroundColor Red }
  Write-Host ('  ---- 計 {0} 件  参照先の Register より後ろへ移動すること' -f $termBad.Count) -ForegroundColor Red
  $fail = 1
}

# === [9] 二値照合 (JP値 と EN値 の両方を受理する箇所) の整合性 ===
#   `name == Fix.X || name == Fix.X_EN` の形で「日本語表記と英語表記のどちらでも通す」
#   書き方がコードベース全体にある (例 One.CurrentAreaAnshet)。
#   この方式は、実際に画面へ出る英語 (L10n の登録値) が Fix の EN 定数と一致していて初めて成立する。
#   一致が崩れると判定だけが静かに偽になる。実例: TOWN_ANSHET_EN='Ansthet Town' に対し
#   L10n='Anshet Town' だったため CurrentAreaAnshet() が英語名を受理できていなかった。
#
#   命名規約 (X/X_EN, X_JP/X) からの機械的な対では 【闇】=属性タグ と 闇=DarkMagic のような
#   語の衝突で誤検出が出るため、コード上で実際に二値照合している対だけを対象にする。
Write-Host ''
Write-Host '=== [9] 二値照合 (JP/EN 両方を受理する箇所) と L10n 登録の整合性 ===' -ForegroundColor Cyan

$dualSites = @{}
foreach ($f in Get-ChildItem $script -Recurse -Filter *.cs -File) {
  $n = 0
  foreach ($line in [System.IO.File]::ReadAllLines($f.FullName)) {
    $n++
    $t = $line.Trim()
    if ($t.StartsWith('//')) { continue }
    foreach ($m in [regex]::Matches($t, '(\w[\w\.\[\]]*)\s*==\s*Fix\.(\w+)\s*\|\|\s*\1\s*==\s*Fix\.(\w+)')) {
      $ca = $m.Groups[2].Value; $cb = $m.Groups[3].Value
      if (-not ($allConst.ContainsKey($ca) -and $allConst.ContainsKey($cb))) { continue }
      $va = $allConst[$ca]; $vb = $allConst[$cb]
      $kJa = $null; $kEn = $null
      if ($va -match '[぀-ヿ㐀-鿿]' -and $vb -notmatch '[぀-ヿ㐀-鿿]') { $kJa = $ca; $kEn = $cb }
      elseif ($vb -match '[぀-ヿ㐀-鿿]' -and $va -notmatch '[぀-ヿ㐀-鿿]') { $kJa = $cb; $kEn = $ca }
      if ($null -eq $kJa) { continue }
      $pk = $kJa + '|' + $kEn
      if (-not $dualSites.ContainsKey($pk)) { $dualSites[$pk] = @() }
      $dualSites[$pk] += ($f.Name + ':L' + $n)
    }
  }
}
# L10n 登録を 日本語値 -> 英語値 で引けるようにする
$regByJa = @{}
foreach ($m in [regex]::Matches($locText, 'Register\(Fix\.(\w+),\s*"([^"]*)",\s*"([^"]*)"\)')) {
  $ja = $m.Groups[2].Value
  if (-not $regByJa.ContainsKey($ja)) { $regByJa[$ja] = @{ en = $m.Groups[3].Value; key = $m.Groups[1].Value } }
}
$dualNG = 0; $dualChecked = 0; $dualNoReg = 0
foreach ($pk in ($dualSites.Keys | Sort-Object)) {
  $p = $pk -split '\|'
  $jaV = $allConst[$p[0]]; $enV = $allConst[$p[1]]
  if (-not $regByJa.ContainsKey($jaV)) { $dualNoReg++; continue }   # 表示経路が L10n に無いので対象外
  $dualChecked++
  if ($regByJa[$jaV].en -ne $enV) {
    Write-Host ("  NG  Fix.{0}='{1}' を受理する箇所で Fix.{2}='{3}' だが、表示は L10n({4})='{5}'" -f `
      $p[0], $jaV, $p[1], $enV, $regByJa[$jaV].key, $regByJa[$jaV].en) -ForegroundColor Red
    Write-Host ("      使用: {0}" -f (($dualSites[$pk] | Select-Object -First 3) -join ', ')) -ForegroundColor Red
    $dualNG++
  }
}
if ($dualNG -eq 0) {
  Write-Host ("  なし (二値照合 {0} 対 / うち L10n 登録あり {1} 対を照合)" -f $dualSites.Count, $dualChecked) -ForegroundColor Green
} else {
  Write-Host ("  ---- 計 {0} 件  Fix の EN 定数と L10n の英訳を一致させること" -f $dualNG) -ForegroundColor Red
  $fail = 1
}

# === [10] 同じ Fix 定数に割り当てるアイコンが場所によって食い違っていないか ===
#   アイコン解決は NodeActionCommand.ApplyImageIcon が正典だが、
#   SecondaryLogic.ApplyImageIcon にもポーション類の同じ分岐が二重に書かれている。
#   現状は値が一致しているものの、片方だけ直せば静かにズレる (Anshet と同じ構図)。
#   コードを一本化する代わりに、ズレたことを検出する。
Write-Host ''
Write-Host '=== [10] 同一定数に対するアイコン割り当ての一貫性 ==='

$iconMap = @{}
foreach ($f in Get-ChildItem $script -Recurse -Filter *.cs -File) {
  $lines = [System.IO.File]::ReadAllLines($f.FullName)
  for ($i = 0; $i -lt $lines.Count; $i++) {
    $t = $lines[$i].Trim()
    if ($t.StartsWith('//')) { continue }
    $cmp = [regex]::Matches($t, '==\s*Fix\.(\w+)')
    if ($cmp.Count -eq 0) { continue }
    $consts = New-Object System.Collections.Generic.List[string]
    foreach ($c in $cmp) { $consts.Add($c.Groups[1].Value) }
    $icon = $null
    $at = -1
    for ($j = $i; $j -lt [Math]::Min($i + 6, $lines.Count); $j++) {
      $u = $lines[$j].Trim()
      if ($u.StartsWith('//')) { continue }
      if ($j -gt $i) {
        # 条件が || で次行へ続く場合は定数を足す。次の分岐に入ったら打ち切る。
        if ($u -match '^\|\|' -or $u -match '^\s*\w[\w\.\[\]]*\s*==\s*Fix\.') {
          foreach ($c in [regex]::Matches($u, '==\s*Fix\.(\w+)')) { $consts.Add($c.Groups[1].Value) }
        }
        elseif ($u -match '^else\b' -or $u -match '^if\s*\(') { break }
      }
      $m = [regex]::Match($u, 'Resources\.Load<Sprite>\(\s*(?:Fix\.(\w+)|"([^"]+)")\s*\)')
      if ($m.Success) {
        $icon = $(if ($m.Groups[1].Success) { 'Fix.' + $m.Groups[1].Value } else { '"' + $m.Groups[2].Value + '"' })
        $at = $j + 1
        break
      }
    }
    if ($null -eq $icon) { continue }
    foreach ($k in ($consts | Sort-Object -Unique)) {
      if (-not $iconMap.ContainsKey($k)) { $iconMap[$k] = @{} }
      if (-not $iconMap[$k].ContainsKey($icon)) { $iconMap[$k][$icon] = New-Object System.Collections.Generic.List[string] }
      $iconMap[$k][$icon].Add($f.Name + ':L' + $at)
    }
  }
}
$iconNG = 0
foreach ($k in ($iconMap.Keys | Sort-Object)) {
  if ($iconMap[$k].Count -le 1) { continue }
  Write-Host ("  NG  Fix.{0} に割り当てるアイコンが場所によって異なる" -f $k) -ForegroundColor Red
  foreach ($icon in ($iconMap[$k].Keys | Sort-Object)) {
    Write-Host ("        {0}  <- {1}" -f $icon, (($iconMap[$k][$icon] | Select-Object -First 3) -join ', ')) -ForegroundColor Red
  }
  $iconNG++
}
if ($iconNG -eq 0) {
  Write-Host ("  なし (アイコンを割り当てている定数 {0} 件を照合)" -f $iconMap.Count) -ForegroundColor Green
} else {
  Write-Host ("  ---- 計 {0} 件  同じ定数には同じアイコンを割り当てること" -f $iconNG) -ForegroundColor Red
  $fail = 1
}

# === [11] アイテム名 (RegisterItemName) の健全性 ===
#   アイテム名は日本語名そのものをキーとして L10n の同一テーブルへ入るため、
#   検査[1]〜[3] の「Fix.L10N_* をキーとする登録」とは形が違い、そちらでは見られない。
#   旧 itemNameTable を廃止して Register へ統合した際に、ここを検査対象として引き取った。
Write-Host ''
Write-Host '=== [11] アイテム名の登録 (RegisterItemName) ==='

$itemFile = Join-Path $script 'View\HomeTown.Localization.ItemName.cs'
if (-not (Test-Path $itemFile)) {
  Write-Host ('  NG  {0} が見つからない' -f $itemFile) -ForegroundColor Red
  $fail = 1
} else {
  $itemLines = [System.IO.File]::ReadAllLines($itemFile)
  $itemByConst = @{}
  $itemByJa = @{}
  $itemNG = 0
  for ($i = 0; $i -lt $itemLines.Count; $i++) {
    $m = [regex]::Match($itemLines[$i], '^\s*RegisterItemName\(Fix\.(\w+),\s*"([^"]*)"\);')
    if (-not $m.Success) { continue }
    $ck = $m.Groups[1].Value
    $cen = $m.Groups[2].Value
    $ln = $i + 1

    if (-not $allConst.ContainsKey($ck)) {
      Write-Host ("  NG  L{0}  Fix.{1} が Fix.cs に存在しない" -f $ln, $ck) -ForegroundColor Red
      $itemNG++
      continue
    }
    $cja = $allConst[$ck]

    if ($itemByConst.ContainsKey($ck)) {
      Write-Host ("  NG  L{0}  Fix.{1} が重複登録されている (既に L{2})" -f $ln, $ck, $itemByConst[$ck]) -ForegroundColor Red
      $itemNG++
    } else { $itemByConst[$ck] = $ln }

    if ([string]::IsNullOrWhiteSpace($cen)) {
      Write-Host ("  NG  L{0}  Fix.{1} の英訳が空" -f $ln, $ck) -ForegroundColor Red
      $itemNG++
    }
    if ($cen -match '[぀-ヿ㐀-鿿]') {
      Write-Host ("  NG  L{0}  Fix.{1} の英訳に日本語が残っている `"{2}`"" -f $ln, $ck, $cen) -ForegroundColor Red
      $itemNG++
    }
    # 日本語名がキーになるため、同じ日本語に異なる英訳を書くと後勝ちで静かに上書きされる
    if ($itemByJa.ContainsKey($cja)) {
      if ($itemByJa[$cja].en -ne $cen) {
        Write-Host ("  NG  L{0}  日本語 `"{1}`" に異なる英訳: `"{2}`" (L{3}) と `"{4}`"" -f `
          $ln, $cja, $itemByJa[$cja].en, $itemByJa[$cja].ln, $cen) -ForegroundColor Red
        $itemNG++
      }
    } else { $itemByJa[$cja] = @{ en = $cen; ln = $ln } }
  }

  # 実アイテム (Item.cs の case) のうち、名前が日本語で未登録のもの
  $itemCase = @{}
  foreach ($m in [regex]::Matches([System.IO.File]::ReadAllText((Join-Path $script 'Class\Item.cs')), 'case Fix\.(\w+)\s*:')) {
    $itemCase[$m.Groups[1].Value] = 1
  }
  $needTrans = @($itemCase.Keys | Where-Object { $allConst.ContainsKey($_) -and $allConst[$_] -match '[぀-ヿ㐀-鿿]' })
  $missTrans = @($needTrans | Where-Object { -not $itemByConst.ContainsKey($_) })
  foreach ($k in ($missTrans | Sort-Object)) {
    Write-Host ("  --  Fix.{0} `"{1}`" は英訳が無く、英語モードでも日本語のまま表示される" -f $k, $allConst[$k]) -ForegroundColor Yellow
  }

  if ($itemNG -eq 0) {
    Write-Host ("  なし (登録 {0} 件 / 実アイテム {1} 件中 {2} 件を網羅)" -f `
      $itemByConst.Count, $needTrans.Count, ($needTrans.Count - $missTrans.Count)) -ForegroundColor Green
  } else {
    Write-Host ("  ---- 計 {0} 件" -f $itemNG) -ForegroundColor Red
    $fail = 1
  }
}

Write-Host ''
Write-Host ('--- 定義 {0} / 登録 {1} / 参照 {2} / 用語 {3} ---' -f $defined.Count, $registered.Count, $used.Count, $glossary.Count)
if ($fail -eq 0) { Write-Host '検査OK' -ForegroundColor Green } else { Write-Host '検査NG' -ForegroundColor Red }
exit $fail
