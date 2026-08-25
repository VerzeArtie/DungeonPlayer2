using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public static class L10n
{
  private static Dictionary<string, (string ja, string en)> table = new Dictionary<string, (string ja, string en)>(StringComparer.OrdinalIgnoreCase);
  private static Dictionary<string, string> itemNameTable = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
  private static bool itemNameTableReady = false;

  /// <summary>
  /// 説明文中の 【タグ】 の日英対応。Fix の定数ペアを参照しているため、
  /// 定数のリネームや削除はコンパイルエラーになる。
  /// Register の用語ペア引数と LocalizeGeneratedText の置換の双方が、ここを唯一の定義とする。
  /// </summary>
  public static readonly (string ja, string en)[] TermTags = new (string ja, string en)[]
  {
    (Fix.TERM_STRENGTH_JP, Fix.TERM_STRENGTH),
    (Fix.TERM_AGILITY_JP, Fix.TERM_AGILITY),
    (Fix.TERM_INTELLIGENCE_JP, Fix.TERM_INTELLIGENCE),
    (Fix.TERM_STAMINA_JP, Fix.TERM_STAMINA),
    (Fix.TERM_MIND_JP, Fix.TERM_MIND),
    (Fix.TERM_FIRE_JP, Fix.TERM_FIRE),
    (Fix.TERM_ICE_JP, Fix.TERM_ICE),
    (Fix.TERM_HOLY_JP, Fix.TERM_HOLY),
    (Fix.TERM_DARK_JP, Fix.TERM_DARK),
    (Fix.TERM_FORCE_JP, Fix.TERM_FORCE),
    (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
    (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC),
    (Fix.TERM_BENEFICIAL_JP, Fix.TERM_BENEFICIAL),
    (Fix.TERM_HARMFUL_JP, Fix.TERM_HARMFUL),
  };

  static L10n()
  {
    // Title
    Register(Fix.L10N_TITLE_GAMESTART, "Game Start", "Game Start"); // Fix
    Register(Fix.L10N_TITLE_LOAD, "Load Game", "Load Game"); // Fix
    Register(Fix.L10N_TITLE_CONFIG, "Config", "Config"); // Fix
    Register(Fix.L10N_TITLE_PRIVACYPOLICY, "Privacy Policy", "Privacy Policy"); // Fix
    Register(Fix.L10N_TITLE_OFFICIALSITE, "Official Site", "Official Site"); // Fix
    Register(Fix.L10N_TITLE_EXIT, "Exit", "Exit"); // Fix
    Register(Fix.L10N_TITLE_OBSIDIAN_PORTAL, "Obsidian Portal", "Obsidian Portal"); // Fix
    Register(Fix.L10N_TITLE_OP_GAMESTART, "Game Start", "Game Start"); // Fix
    Register(Fix.L10N_TITLE_OP_LOAD, "Load Game", "Load Game"); // Fix
    Register(Fix.L10N_TITLE_OP_CONFIG, "Config", "Config"); // Fix
    Register(Fix.L10N_TITLE_OP_PRIVACYPOLICY, "Privacy Policy", "Privacy Policy"); // Fix
    Register(Fix.L10N_TITLE_OP_OFFICIALSITE, "Official Site", "Official Site"); // Fix
    Register(Fix.L10N_TITLE_OP_EXIT, "Exit", "Exit"); // Fix
    Register(Fix.L10N_TITLE_CANNOT_GAMESTARTLOAD, "アイン・ウォーレンスは並行世界へと突入しており、選択不可。", "Ein-Wolence is in a parallel world and cannot be selected.");
    Register(Fix.L10N_TITLE_ACCOUNT_MESSAGE_LESS2, "2文字以上を入力してください。", "Please enter 2 or more characters.");
    Register(Fix.L10N_TITLE_ACCOUNT_ALREADY_EXIST, "その名前は既に存在します。", "A character with that name already exists.");
    Register(Fix.L10N_TITLE_ACCOUNT_NAME_CHANGED, "アカウント名が変更されました。", "Account name has been changed.");
    // SaveLoad
    Register(Fix.L10N_SAVELOAD_TITLESAVE, "セーブ", "SAVE");
    Register(Fix.L10N_SAVELOAD_TITLELOAD, "ロード", "LOAD");
    Register(Fix.L10N_SAVELOAD_NOWLOADING, "しばらくお待ちください...", "Now Loading...");
    Register(Fix.L10N_SAVELOAD_LOAD_COMPLETED, "ゲームデータの読み込みが完了しました。", "Game data loading is complete.");
    Register(Fix.L10N_SAVELOAD_OVERWRITE, "既にデータが存在します。上書きしてセーブしますか？", "Data already exists. Do you want to overwrite and save?");
    Register(Fix.L10N_SAVELOAD_SAVE_COMPLETED, "ゲームデータの保存が完了しました。", "Game data saving is complete.");
    Register(Fix.L10N_SAVELOAD_CANNOTCLEARDATA, "DungeonPlayerクリアデータです。本編ではロードできません。", "This is DungeonPlayer clear data. It cannot be loaded in the main story.");
    Register(Fix.L10N_TXT_CLOSE, "閉じる", "Close");
    Register(Fix.L10N_GAMEDAY, "日目", "Day");
    // SystemMenu
    Register(Fix.L10N_SYSTEM_EXIT_TITLE, "ゲームを終了しますか？", "Do you want to exit the game?");
    Register(Fix.L10N_SYSTEM_EXIT_DESCRIPTION, "セーブしていない場合、現在データは破棄されます。", "If you haven't saved, your current data will be lost.");
    Register(Fix.L10N_SYSTEM_EXIT_OK, "終了する", "Exit");
    Register(Fix.L10N_SYSTEM_EXIT_CANCEL, "終了しない", "Cancel");
    // HomeTown-Menu
    Register(Fix.L10N_PARTY, "パーティ", "Party");
    Register(Fix.L10N_BLUESPHERE, "遠見の青水晶", "Far-Blue-Sphere");
    Register(Fix.L10N_SYSTEM, "システム", "System");
    Register(Fix.L10N_DUNGEONPLAYER, "DungeonPlayer", "DungeonPlayer"); // 日本語／英語で表記を変えない
    Register(Fix.L10N_SHOP, "ショップ", "Shop");
    Register(Fix.L10N_INN, "宿屋", "Inn");
    Register(Fix.L10N_TALK_LANA, "幼なじみのラナと会話", "Talk to Lana");
    Register(Fix.L10N_ITEMBANK, "アイテム保管庫", "ItemBank");
    // HomeTown-System
    Register(Fix.L10N_SYSTEM_SAVE, "セーブ", "Save");
    Register(Fix.L10N_SYSTEM_LOAD, "ロード", "Load");
    Register(Fix.L10N_SYSTEM_HELP, "ヘルプ", "Help");
    Register(Fix.L10N_SYSTEM_EXIT, "終了", "Exit");
    Register(Fix.L10N_SAVELOAD_YES, "はい", "Yes");
    Register(Fix.L10N_SAVELOAD_NO, "いいえ", "No");
    // HomeTown-Menu-Custom
    Register(Fix.L10N_CUSTOMEVENT1_ANSHET, "中央噴水広場", "Central Fountain");
    Register(Fix.L10N_CUSTOMEVENT1_FAZIL_CASTLE, "ファージル宮殿", "Fazil Castle");
    Register(Fix.L10N_CUSTOMEVENT1_COTUHSYE, "船着き場", "Dock");
    Register(Fix.L10N_CUSTOMEVENT2_COTUHSYE, "街はずれ", "Outskirts");
    Register(Fix.L10N_CUSTOMEVENT1_ZHALMAN, "長老の家", "Elder's House");
    Register(Fix.L10N_CUSTOMEVENT2_ZHALMAN, "ドルワッツの民芸品店", "Dorwatts Handicraft");
    Register(Fix.L10N_CUSTOMEVENT1_ARCANEDINE, "中央噴水広場", "Central Fountain");
    Register(Fix.L10N_CUSTOMEVENT2_ARCANEDINE, "ワッツの民芸品店", "Watts Handicraft");
    Register(Fix.L10N_CUSTOMEVENT3_ARCANEDINE, "占いの館：アミンダ", "Aminda's Fortune");
    Register(Fix.L10N_CUSTOMEVENT1_PARMETYSIA, "中央神殿", "Central Temple");
    // HomeTown-DungeonPlayer
    Register(Fix.L10N_HOMETOWN_DUNGEONPLAYER_GOTO, " 【 {0} 】へ向かう", "Go to 【 {0} 】");
    // HomeTown-Shop
    Register(Fix.L10N_HOMETOWN_SHOPMENU_TITLE_BUY, "ショップ", "Shop");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_TITLE_SELL, "バックパック", "Backpack");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_DECISION_BUY, "購入", "Buy");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_DECISION_SELL, "売却", "Sell");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_TITLE_BUY, "{0}を購入しますか？", "Do you want to buy {0}?");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_DESCRIPTION_BUY, "{0} ゴールドを消費します。この操作は元に戻せません。", "You will consume {0} gold. This operation cannot be undone.");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_TITLE_CANNOTBUY, "{0} を購入する事ができません。", "{0} cannot be bought.");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_DESCRIPTION_CANNOTBUY, "{0} ゴールドが不足しているため、{1} を購入できません。", "You don't have enough {0} gold to buy {1}.");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_ACCEPT_BUY, "購入する", "Buy");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_CANCEL_BUY, "キャンセル", "Cancel");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_OK_BUY, "ＯＫ", "OK");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_TITLE_SELL, "{0} を売却しますか？", "Do you want to sell {0}?");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_DESCRIPTION_SELL, "{0} Goldで売却した後、{1} を手元に戻す事はできません。", "Once you sell it for {0} gold, you cannot get {1} back.");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_TITLE_CANNOTSELL, "{0} は売却する事ができません。", "{0} cannot be sold.");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_DESCRIPTION_CANNOTSELL, "{0} は貴重品のため、売却することができません。", "{0} is a precious item and cannot be sold.");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_ACCEPT_SELL, "売却する", "Sell");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_CANCEL_SELL, "キャンセル", "Cancel");
    Register(Fix.L10N_HOMETOWN_SHOPMENU_MESSAGEBOX_OK_SELL, "ＯＫ", "OK");
    // HomeTown-Inn
    Register(Fix.L10N_HOMETOWN_INN_STRENGTH, "力", "力"); // 変換しない。
    Register(Fix.L10N_HOMETOWN_INN_AGILITY, "技", "技"); // 変換しない。
    Register(Fix.L10N_HOMETOWN_INN_INTELLIGENCE, "知", "知"); // 変換しない。
    Register(Fix.L10N_HOMETOWN_INN_STAMINA, "体", "体"); // 変換しない。
    Register(Fix.L10N_HOMETOWN_INN_MIND, "心", "心"); // 変換しない。
    Register(Fix.L10N_HOMETOWN_INN_NOW_ACCEPT, "決定", "Accept");
    Register(Fix.L10N_HOMETOWN_INN_TITLE, "休息に入りますか？", "Do you want to take a rest?");
    Register(Fix.L10N_HOMETOWN_INN_ACCEPT, "休息する", "Rest");
    Register(Fix.L10N_HOMETOWN_INN_CANCEL, "キャンセル", "Cancel");
    // HomeTown-ItemBank
    Register(Fix.L10N_HOMETOWN_ITEMBANK_TITLE, "アイテム保管庫", "Item Bank");
    Register(Fix.L10N_HOMETOWN_ITEMBANK_WITHDRAW, "取り出す", "Withdraw");
    // HomeTown
    Register(Fix.L10N_HOMETOWN_AVAILABLE, "【 {0} 】が追加されました！", "【 {0} 】 has been added!");
    // HomeTown-Quest
    Register(Fix.L10N_QUESTCOMPLETE_TITLE, "クエスト【 {0} 】を達成しました！", "Quest 【 {0} 】 completed!");
    Register(Fix.L10N_QUESTCOMPLETE_GOLDGAIN, "{0} ゴールドを獲得しました！", "Gain {0} Gold!");
    Register(Fix.L10N_QUESTCOMPLETE_EXPGAIN, "{0} 経験値を獲得しました！", "Gain {0} EXP!");
    Register(Fix.L10N_QUESTCOMPLETE_ITEMGAIN, "【 {0} 】を獲得しました！", "Gain 【 {0} 】!");
    Register(Fix.L10N_QUESTCOMPLETE_PARTY_EONE, "エオネ・フルネアが仲間になりました！", "Eone Furnea has joined your party!");
    Register(Fix.L10N_QUESTCOMPLETE_NEWQUEST, "新しいミッションが追加されました！", "New mission added!");
    Register(Fix.L10N_QUESTCOMPLETE_SOULESSENCEGAIN, "{0} ソウル・エッセンスを獲得しました！", "Gain {0} Soul Essence!");
    // DungeonField
    Register(Fix.L10N_FASTTRAVEL_MESSAGE_TITLE, "ダンジョンの外へと帰還しますか？", "Do you want to return to the outside of the dungeon?");
    Register(Fix.L10N_FASTTRAVEL_MESSAGE, "ダンジョンから出た場合、その日は再びダンジョン内に入る事は出来なくなります。", "If you leave the dungeon, you will not be able to enter the dungeon again that day.");
    Register(Fix.L10N_FASTTRAVEL_MESSAGE_ACCEPT, "実行", "Accept");
    Register(Fix.L10N_FASTTRAVEL_MESSAGE_CANCEL, "キャンセル", "Cancel");
    Register(Fix.L10N_FASTTRAVEL_MESSAGE_OK, "ＯＫ", "OK");
    Register(Fix.L10N_DUNGEON_TREASURE_LIMIT, "バックパックがいっぱいのため、【 {0} 】を入手できませんでした。", "Your backpack is full, so you couldn't acquire 【 {0} 】.");
    Register(Fix.L10N_DUNGEON_TREASURE_GET, "【 {0} 】を入手しました。", "You acquired 【 {0} 】.");
    Register(Fix.L10N_DUNGEON_MISSIONFAIL, "ダンジョン攻略に失敗しました・・・\r\n最後に出たホームタウンへ帰還します。", "You failed to clear the dungeon...\r\nYou will return to the last Home Town.");
    // PartyMenu-Top
    Register(Fix.L10N_PARTYMENU_STATUS, "ステータス", "Status");
    Register(Fix.L10N_PARTYMENU_BATTLESETTING, "バトル設定", "Battle");
    Register(Fix.L10N_PARTYMENU_ESSENCETREE, "エッセンス", "Essence");
    Register(Fix.L10N_PARTYMENU_ACTIONCOMMAND, "コマンド", "Command");
    Register(Fix.L10N_PARTYMENU_ITEM, "アイテム", "Item");
    Register(Fix.L10N_PARTYMENU_SWITCHFORMATION, "隊列変更", "Formation");
    Register(Fix.L10N_PARTYMENU_CLOSEMENU, "閉じる", "Close");
    // PartyMenu-Etc
    Register(Fix.L10N_PARTYMENU_STATUS_DETAIL, "詳細", "Detail");
    Register(Fix.L10N_PARTYMENU_LEVELUP_PARAMETER_ACCEPT, "確定", "Accept");
    Register(Fix.L10N_PARTYMENU_LEVELUP_PARAMETER_RESET, "リセット", "Reset");
    Register(Fix.L10N_PARTYMENU_LEVELUP_COREPOINT, "コアポイント", "CORE Point");
    Register(Fix.L10N_PARTYMENU_EQUIPCHANGE_OK, "装備", "Equip");
    Register(Fix.L10N_PARTYMENU_EQUIPCHANGE_DETACH, "外す", "Detach");
    Register(Fix.L10N_PARTYMENU_EQUIPCHANGE_CANCEL, "キャンセル", "Cancel");
    Register(Fix.L10N_PARTYMENU_NO_EQUIP, "( 装備なし )", "( No Equip )");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_BASIC, "基本", "Basic");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_SPELLSKILL, "魔法/スキル", "Spell/Skill");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_USEITEM, "アイテム", "Item");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_ARCHETYPE, "元核", "Archetype");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_VIEWMODE_EDIT, "編集モード", "EditMode");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_VIEWMODE_VIEW, "表示モード", "ViewMode");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_DESCRIPTION, "説明", "Description");
    Register(Fix.L10N_PARTYMENU_BATTLE_LABEL_MAIN, "メイン", "Main");
    Register(Fix.L10N_PARTYMENU_BATTLE_LABEL_ACTIONCOMMAND, "アクション コマンド", "Action Command");
    Register(Fix.L10N_PARTYMENU_BATTLE_LABEL_TYPE, "タイプ：", "Type:");
    Register(Fix.L10N_PARTYMENU_BATTLE_LABEL_COST, "コスト：", "Cost:");
    Register(Fix.L10N_PARTYMENU_COMMAND_NOT_ENOUGH_MANA, "ＭＰが足りない！", "Not enough mana !");
    Register(Fix.L10N_PARTYMENU_COMMAND_TARGET_DEAD, "対象は既に死んでいる！", "Target is already dead !");
    // Register(Fix.L10N_PARTYMENU_ESSENCETREE_LABEL_EFFECT, "～効果～", "～Effect～");
    Register(Fix.L10N_PARTYMENU_ESSENCETREE_LABEL_POWERUP, "～強化～", "～PowerUp～");
    Register(Fix.L10N_PARTYMENU_ESSENCETREE_LABEL_UNKNOWN, "？？？", "???");
    Register(Fix.L10N_PARTYMENU_ESSENCETREE_NOACQ, "未修得", "Ready");
    Register(Fix.L10N_PARTYMENU_ESSENCETREE_REQUIRE, "必要", "Require");
    Register(Fix.L10N_PARTYMENU_ESSENCETREE_POWERUP, "強化", "Power-Up");
    Register(Fix.L10N_PARTYMENU_ITEM_BACKPACK, "バックパック", "Backpack");
    Register(Fix.L10N_PARTYMENU_ITEM_PRECIOUS, "貴重品", "Precious");
    Register(Fix.L10N_PARTYMENU_ITEM_USE, "つかう", "Use");
    Register(Fix.L10N_PARTYMENU_ITEM_DETAIL, "詳細", "Detail");
    Register(Fix.L10N_PARTYMENU_ITEM_DELETE, "捨てる", "Remove");
    // PartyMenu-Decision
    Register(Fix.L10N_PARTYMENU_ITEM_DECISION_ACCEPT, "実行", "Accept");
    Register(Fix.L10N_PARTYMENU_ITEM_DECISION_CANCEL, "キャンセル", "Cancel");
    Register(Fix.L10N_PARTYMENU_ITEM_DECISION_OK, "ＯＫ", "OK");
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_STRENGTH, "{0} の【力】パラメタが {1} 上昇した！", "{0} 's [STR] parameter increased by {1}!");
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_AGILITY, "{0} の【技】パラメタが {1} 上昇した！", "{0} 's [AGI] parameter increased by {1}!");
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_INTELLIGENCE, "{0} の【知】パラメタが {1} 上昇した！", "{0} 's [INT] parameter increased by {1}!");
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_STAMINA, "{0} の【体】パラメタが {1} 上昇した！", "{0} 's [STA] parameter increased by {1}!");
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_MIND, "{0} の【心】パラメタが {1} 上昇した！", "{0} 's [MND] parameter increased by {1}!");
    // PartyMenu-EssencePowerUp
    Register(Fix.L10N_PARTYMENU_ESSENCE_POWERUP_ACCEPT, "実行", "Accept");
    Register(Fix.L10N_PARTYMENU_ESSENCE_POWERUP_CANCEL, "キャンセル", "Cancel");
    Register(Fix.L10N_PARTYMENU_ESSENCE_POWERUP_OK, "ＯＫ", "OK");
    // PartyMenu-Essence-GetNew
    Register(Fix.L10N_PARTYMENU_ESSENCE_GETNEW_TITLE, "{0} を獲得しますか？", "Do you want to acquire {0}?");
    Register(Fix.L10N_PARTYMENU_ESSENCE_GETNEW_MESSAGE, "エッセンス・ポイントを１ポイント消費して獲得します。この操作は元に戻せません。", "You will consume 1 Essence Point to acquire it. This operation cannot be undone.");
    Register(Fix.L10N_PARTYMENU_ESSENCE_GETLIMIT_TITLE, "{0} はレベル上限に達しています。", "{0} has reached the level cap.");
    Register(Fix.L10N_PARTYMENU_ESSENCE_GETLIMIT_MESSAGE, "本コマンドはレベル上限に達しているため、これ以上強化する事は出来ません。", "This command has reached the level cap and cannot be further enhanced.");
    Register(Fix.L10N_PARTYMENU_ESSENCE_GETCANNOT_TITLE, "エッセンス・ポイントが不足しているため、{0} を獲得できません。", "Need more Essence Points to get {0}.");
    Register(Fix.L10N_PARTYMENU_ESSENCE_GETCANNOT_MESSAGE, "エッセンス・ポイントが不足しています。エッセンス・ポイントを入手してください。", "You don't have enough Essence Points. Please acquire Essence Points.");
    // GroupCharacterStatus
    Register(Fix.L10N_CHARASTATUS_CANNOT_NOSELECT_EQUIP, "装備対象が選択されていません。", "No equipment target selected.");
    Register(Fix.L10N_CHARASTATUS_CANNOT_EXCHANGE_EQUIP, "装備変更できません。バックパックの空きを増やす必要があります。", "Can't change it. Increase backpack space.");
    Register(Fix.L10N_CHARASTATUS_CANNOT_DETACH_EQUIP, "装備を外す事ができません。バックパックの空きを増やす必要があります。", "Can't detach it. Increase backpack space.");
    // NodeBackpackView
    Register(Fix.L10N_NODEBACKPACK_DELETE_TITLE, "{0}を捨てますか？", "Do you want to discard {0}?");
    Register(Fix.L10N_NODEBACKPACK_DELETE_MESSAGE, "バックパックから削除した場合、そのアイテムは二度と戻す事ができません。", "Once you delete an item from the backpack, it cannot be restored.");
    Register(Fix.L10N_NODEBACKPACK_DELETE_CANNOT, "{0}は捨てる事ができません。", "{0} cannot be discarded.");
    // HelpBook
    Register(Fix.L10N_HELPMENU_ACTIONCOMMAND, "アクションコマンド", "Action Command");
    Register(Fix.L10N_HELPMENU_CLOSE_BUTTON, "閉じる", "Close");
    Register(Fix.L10N_HELPMENU_NAME_EN, "名称(EN)", "Name(EN)");
    Register(Fix.L10N_HELPMENU_NAME_JP, "名称(JP)", "Name(JP)");
    Register(Fix.L10N_HELPMENU_COST, "コスト", "Cost");
    Register(Fix.L10N_HELPMENU_TARGET, "対象", "Target");
    Register(Fix.L10N_HELPMENU_TIMING, "タイミング", "Timing");
    // BattleEnemy
    Register(Fix.L10N_BATTLE_REWARD, "敵を倒した。\r\n{0}経験値を獲得。\r\n{1}ゴールドを獲得", "You defeated the enemy.\r\nGain {0} EXP\r\nGain {1} Gold.");
    Register(Fix.L10N_BATTLE_GETITEM, "【 {0} 】を入手した！", "You got 【 {0} 】!");
    Register(Fix.L10N_BATTLE_RUNAWAY, "{0}達は逃げ出した・・・", "{0} ran away...");
    Register(Fix.L10N_BATTLE_GAMEOVER, "パーティが全滅しました・・・\r\n戦闘を初めからやり直しますか？", "Your party has been defeated...\r\nDo you want to retry the battle from the beginning?");
    Register(Fix.L10N_BATTLE_RETRY, "リトライ", "Retry");
    Register(Fix.L10N_BATTLE_SURRENDER, "終了", "Surrender");
    // Standard-Attribute
    Register(Fix.L10N_STANDARD_BASIC, "基本行動", "Basic");
    Register(Fix.L10N_STANDARD_SPELL, "魔法", "Spell");
    Register(Fix.L10N_STANDARD_SKILL, "スキル", "Skill");
    Register(Fix.L10N_STANDARD_CORE, "元核", "Archetype");
    Register(Fix.L10N_STANDARD_MONSTERACTION, "モンスターアクション", "Monster Action");
    Register(Fix.L10N_STANDARD_OTHER, "その他", "Other");
    Register(Fix.L10N_STANDARD_NONE, "なし", "None");
    Register(Fix.L10N_STANDARD_FIRE, "炎", "Fire");
    Register(Fix.L10N_STANDARD_ICE, "氷", "Ice");
    Register(Fix.L10N_STANDARD_LIGHT, "聖", "HolyLight");
    Register(Fix.L10N_STANDARD_SHADOW, "闇", "DarkMagic");
    Register(Fix.L10N_STANDARD_FORCE, "理", "Force");
    Register(Fix.L10N_STANDARD_VOIDCHANT, "空唱", "VoidChant");
    Register(Fix.L10N_STANDARD_WARRIOR, "戦士", "Warrior");
    Register(Fix.L10N_STANDARD_GUARDIAN, "護衛", "Guardian");
    Register(Fix.L10N_STANDARD_MARTIALARTS, "格闘", "MartialArts");
    Register(Fix.L10N_STANDARD_ARCHERY, "弓術", "Archery");
    Register(Fix.L10N_STANDARD_TRUTH, "心眼", "Truth");
    Register(Fix.L10N_STANDARD_MINDFULNESS, "無心", "Mindfulness");
    Register(Fix.L10N_STANDARD_LABEL_LV, "Lv", "Lv");
    Register(Fix.L10N_STANDARD_LABEL_SAVE_DAYS, "経過日数", "Elapsed");
    Register(Fix.L10N_STANDARD_LABEL_SAVE_DAYS2, "日", "Days");
    Register(Fix.L10N_STANDARD_LABEL_SAVE_ARCHIVE_AREA3, "制覇", "Completed");
    Register(Fix.L10N_STANDARD_LABEL_SAVE_DUNGEON_AREA, "到達地点", "Area");
    // Common-BasicParameter
    Register(Fix.L10N_BASIC_LEVEL, "レベル", "Level");
    Register(Fix.L10N_BASIC_EXPERIENCE, "経験値", "Exp");
    Register(Fix.L10N_BASIC_LIFE, "ライフ", "Life");
    Register(Fix.L10N_BASIC_MANA_POINT, "マナ", "MP");
    Register(Fix.L10N_BASIC_SKILL_POINT, "スキル", "SP");
    Register(Fix.L10N_SKILL_POINT, "スキルポイント", "Skill Point");
    Register(Fix.L10N_MAX_LIFE, "最大ライフ", "Max Life");
    Register(Fix.L10N_MAX_MANA, "最大マナ", "Max MP");
    Register(Fix.L10N_MAX_SKILL_POINT, "最大スキルポイント", "Max Skill Point");
    Register(Fix.L10N_INSTANT_GAUGE, "インスタントゲージ", "Instant Gauge");
    Register(Fix.L10N_ACTION_GAUGE, "行動ゲージ", "Action Gauge");
    Register(Fix.L10N_BATTLE_GAUGE, "戦闘ゲージ", "Battle Gauge");
    // Common-CoreParameter
    Register(Fix.L10N_CORE_STRENGTH, "力", "STR");
    Register(Fix.L10N_CORE_AGILITY, "技", "AGI");
    Register(Fix.L10N_CORE_INTELLIGENCE, "知", "INT");
    Register(Fix.L10N_CORE_STAMINA, "体", "STA");
    Register(Fix.L10N_CORE_MIND, "心", "MND");
    // Common-SecondParameter
    Register(Fix.L10N_PHYSICAL_ATTACK, "物理攻撃", "Physical Attack");
    Register(Fix.L10N_PHYSICAL_DEFENSE, "物理防御", "Physical Defense");
    Register(Fix.L10N_MAGIC_ATTACK, "魔法攻撃", "Magic Attack");
    Register(Fix.L10N_MAGIC_DEFENSE, "魔法防御", "Magic Defense");
    Register(Fix.L10N_BATTLE_SPEED, "戦闘速度", "Battle Speed");
    Register(Fix.L10N_BATTLE_RESPONSE, "戦闘反応", "Battle Response");
    Register(Fix.L10N_POTENTIAL, "潜在能力", "Potential");
    // Common-DetailParameter
    Register(Fix.L10N_DETAIL_BATTLE_PERCENT_PA, "物攻率", "PA Amplify");
    Register(Fix.L10N_DETAIL_BATTLE_PERCENT_PD, "物防率", "PD Amplify");
    Register(Fix.L10N_DETAIL_BATTLE_PERCENT_MA, "魔攻率", "MA Amplify");
    Register(Fix.L10N_DETAIL_BATTLE_PERCENT_MD, "魔防率", "MD Amplify");
    Register(Fix.L10N_DETAIL_BATTLE_PERCENT_BS, "戦速率", "BS Amplify");
    Register(Fix.L10N_DETAIL_BATTLE_PERCENT_BR, "戦応率", "BR Amplify");
    Register(Fix.L10N_DETAIL_BATTLE_PERCENT_PO, "潜在率", "PO Amplify");
    Register(Fix.L10N_DETAIL_FIRE_AMPLIFY, "炎増幅", "Fire Amplify");
    Register(Fix.L10N_DETAIL_FIRE_RESIST, "炎耐性", "Fire Resist");
    Register(Fix.L10N_DETAIL_ICE_AMPLIFY, "氷増幅", "Ice Amplify");
    Register(Fix.L10N_DETAIL_ICE_RESIST, "氷耐性", "Ice Resist");
    Register(Fix.L10N_DETAIL_LIGHT_AMPLIFY, "光増幅", "Light Amplify");
    Register(Fix.L10N_DETAIL_LIGHT_RESIST, "光耐性", "Light Resist");
    Register(Fix.L10N_DETAIL_SHADOW_AMPLIFY, "闇増幅", "Shadow Amplify");
    Register(Fix.L10N_DETAIL_SHADOW_RESIST, "闇耐性", "Shadow Resist");
    Register(Fix.L10N_DETAIL_RESIST_POISON, "猛毒耐性", "Poison Resist");
    Register(Fix.L10N_DETAIL_RESIST_SILENCE, "沈黙耐性", "Silence Resist");
    Register(Fix.L10N_DETAIL_RESIST_BIND, "束縛耐性", "Bind Resist");
    Register(Fix.L10N_DETAIL_RESIST_SLEEP, "睡眠耐性", "Sleep Resist");
    Register(Fix.L10N_DETAIL_RESIST_STUN, "スタン耐性", "Stun Resist");
    Register(Fix.L10N_DETAIL_RESIST_PARALYZE, "麻痺耐性", "Paralyze Resist");
    Register(Fix.L10N_DETAIL_RESIST_FROZEN, "凍結耐性", "Frozen Resist");
    Register(Fix.L10N_DETAIL_RESIST_FEAR, "恐怖耐性", "Fear Resist");
    Register(Fix.L10N_DETAIL_RESIST_SLOW, "鈍足耐性", "Slow Resist");
    Register(Fix.L10N_DETAIL_RESIST_DIZZY, "眩暈耐性", "Dizzy Resist");
    Register(Fix.L10N_DETAIL_RESIST_SLIP, "出血耐性", "Slip Resist");
    // Common-Equip
    Register(Fix.L10N_MAIN_WEAPON, "メイン武器", "Main Weapon");
    Register(Fix.L10N_SUB_WEAPON, "サブ武器", "Sub Weapon");
    Register(Fix.L10N_ARMOR, "防具", "Armor");
    Register(Fix.L10N_ACCESSORY1, "アクセサリー1", "Accessory 1");
    Register(Fix.L10N_ACCESSORY2, "アクセサリー2", "Accessory 2");
    Register(Fix.L10N_ARTIFACT, "アーティファクト", "Artifact");
    // Common-AreaName
    Register(Fix.L10N_AREANAME_ANSHET, "アンシェット街", "Anshet Town");
    Register(Fix.L10N_AREANAME_FAZIL_CASTLE, "ファージル宮殿", "Fazil Castle");
    Register(Fix.L10N_AREANAME_COTUHSYE, "港町コチューシェ", "Cotuhsye Town");
    Register(Fix.L10N_AREANAME_ZHALMAN, "ツァルマンの里", "Zhalman Village");
    Register(Fix.L10N_AREANAME_PARMETYSIA, "パルメテイシア神殿", "Parmetysia Temple");
    Register(Fix.L10N_AREANAME_ESMILIA_GRASSFIELD, "エスミリア草原区域", "Esmilia Grassfield");
    Register(Fix.L10N_AREANAME_GORATRUM_CAVE, "ゴラトラム洞窟", "Goratrum Cave");
    Register(Fix.L10N_AREANAME_GORATRUM_CAVE_2, "ゴラトラム洞窟（２層）", "Goratrum Cave (2F)");
    Register(Fix.L10N_AREANAME_MYSTIC_FOREST, "神秘の森", "Mystic Forest");
    Register(Fix.L10N_AREANAME_OHRAN_TOWER, "オーランの塔", "Tower of Ohran");
    Register(Fix.L10N_AREANAME_VELGUS_SEA_TEMPLE, "ヴェルガス海底神殿", "Velgus Sea Temple");
    Register(Fix.L10N_AREANAME_VELGUS_SEA_TEMPLE_2, "ヴェルガス海底神殿 第二階層", "Velgus Sea Temple (2F)");
    Register(Fix.L10N_AREANAME_VELGUS_SEA_TEMPLE_3, "ヴェルガス海底神殿 第三階層", "Velgus Sea Temple (3F)");
    Register(Fix.L10N_AREANAME_VELGUS_SEA_TEMPLE_4, "ヴェルガス海底神殿 最深部", "Velgus Sea Temple (DEEP)");
    Register(Fix.L10N_AREANAME_EDELGARZEN_CASTLE, "エデルガイゼン城", "Edelgarzen Castle");
    Register(Fix.L10N_AREANAME_EDELGARZEN_CASTLE_2, "エデルガイゼン城 第二階層", "Edelgarzen Castle (2F)");
    Register(Fix.L10N_AREANAME_EDELGARZEN_CASTLE_3, "エデルガイゼン城 第三階層", "Edelgarzen Castle (3F)");
    Register(Fix.L10N_AREANAME_EDELGARZEN_CASTLE_4, "エデルガイゼン城 最上階", "Edelgarzen Castle (TOP)");
    Register(Fix.L10N_AREANAME_EDELGARZEN_CENTER, "エデルガイゼン城 正面ゲート", "Edelgarzen Castle (CENTER)");

    // アクションコマンド 対象／タイミング
    // 日本語は Fix.TARGET_TYPE_* / TIMING_TYPE_* と同一。あちらは内部判定用の値であり、
    // 表示はここの対訳を使う(以前は LocalizeGeneratedText の語句置換に頼っていた)。
    Register(Fix.L10N_TARGET_ENEMY, "敵単体", "Single Enemy");
    Register(Fix.L10N_TARGET_ALLY, "味方単体", "Single Ally");
    Register(Fix.L10N_TARGET_ENEMYGROUP, "敵全体", "All Enemies");
    Register(Fix.L10N_TARGET_ALLYGROUP, "味方全体", "All Allies");
    Register(Fix.L10N_TARGET_ENEMYFIELD, "敵フィールド", "Enemy Field");
    Register(Fix.L10N_TARGET_ALLYFIELD, "味方フィールド", "Ally Field");
    Register(Fix.L10N_TARGET_ALLMEMBER, "敵味方全体", "All Allies and Enemies");
    Register(Fix.L10N_TARGET_ENEMYORALLY, "敵単体 / 味方単体", "Single Enemy / Single Ally");
    Register(Fix.L10N_TARGET_INSTANTTARGET, "インスタント対象", "Instant Target");
    Register(Fix.L10N_TARGET_OWN, "自分自身", "Self");
    Register(Fix.L10N_TARGET_NONE, "なし", "None");
    Register(Fix.L10N_TIMING_INSTANT, "インスタント", "Instant");
    Register(Fix.L10N_TIMING_NORMAL, "ノーマル", "Normal");
    Register(Fix.L10N_TIMING_SORCERY, "ソーサリー", "Sorcery");
    Register(Fix.L10N_UNIT_NONE, "(なし)", "(None)");

    // ---------------------------------------------------------------
    // ActionCommand説明文の記述規約
    //
    // 数字の全角／半角:
    //   説明文(GetDescription)の散文では半角数字を使う。英文側が必然的に半角であるため、
    //   同一概念の表記を言語間で揃える。移行前の原文が全角の場合はここで半角に直す。
    //   ただし GetDescReinforce の強化値(「ライフ回復量 ＋１０」など)は
    //   ＋ と数字を全角で揃える書式が確立しているため、そちらは全角のまま維持する。
    //
    // 属性ダメージ:
    //   【物理】ダメージ のように必ず括弧付きで書く。括弧が用語であることの標識になる。
    //
    // 文の区切り:
    //   ダメージ付与とBUFF付与は文を分ける。「ダメージを与え、BUFFを付与する」と繋ぐと
    //   BUFFの付与先が省略され、「敵にダメージ / 自分にBUFF」型の説明文と書式が揃わない。
    //
    // ローマ字表記(英訳しない語):
    //   武術・世界観固有の概念で英語に等価な一語が無いものは、訳さず日本語の読みを使う。
    //     【一心】Isshin  【朧】Oboro  【見切り】Mikiri
    //     (コマンド名では Stance of Muin / Stance of the Iai が同じ扱い)
    //   ただし機械的な基準は設けない。英語で合致する表現があればそちらを優先するため、
    //   ローマ字化するかどうかは語ごとに作者の判断を仰ぐこと。
    //
    // 訳語の決定事項:
    //   「連続」    -> consecutively ("N times consecutively")。
    //                 in a row は口語であり、本作は隊列(Formation)の概念を持つため
    //                 row が「隊列の列」と読まれる余地がある。使用しない。
    //   「敵味方全体」-> All Allies and Enemies。combatant は軍事的レジスターのため使用しない。
    //   「無属性」  -> Colorless (Fix.TERM_COLORLESS)。
    //                 Non-Elemental は聖/闇/理を含む本作の属性体系と合わないため使用しない。
    //   「実行する」-> perform / take / repeat。
    //                 execute は英語圏の戦闘ゲームで「低体力の敵を即死させる技」の定番名であり、
    //                 一般語としても「処刑する」を意味するため使用しない。
    //                 (内部のメソッド名 ExecMagicAttack 等はプレイヤーに見えないため対象外)
    //
    // 以上は Tools\check-l10n.ps1 が検査する。
    // ---------------------------------------------------------------

    // ---------------------------------------------------------------
    // エッセンス係数ラベル (Character.GetEssenceFactor)
    //
    // 「固定句 + 計算値」の固定句部分。末尾の半角スペースは計算値との区切りであり、
    // 削らないこと。ＳＰ/ＭＰ は強化値の書式に合わせ全角を維持する。
    // ---------------------------------------------------------------
    Register(Fix.L10N_EF_POWER, "威力 ", "Power ");
    Register(Fix.L10N_EF_DURATION, "継続ターン数 ", "Duration ");
    Register(Fix.L10N_EF_SP_COST, "ＳＰ消費 ", "SP Cost ");
    Register(Fix.L10N_EF_MP_COST, "ＭＰ消費 ", "MP Cost ");
    Register(Fix.L10N_EF_ATTACK_COUNT, "攻撃回数 ", "Attack Count ");
    // 「回」は助数詞であり英語に対応語が無いため、訳を置かない (攻撃回数 3回 -> Attack Count 3)。
    // 空文字は未登録キーと実行時に区別できないため、check-l10n.ps1 の allowEmptyEn に明示する。
    Register(Fix.L10N_EF_TIMES_SUFFIX, "回", "");
    Register(Fix.L10N_EF_STACK_COUNT, "累積カウンター数 ", "Stack Count ");
    Register(Fix.L10N_EF_LIFE_RECOVERY, "$0の回復量 ", "$0 Recovery ",
      Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_EF_SP_RECOVERY, "ＳＰ回復量 ", "SP Recovery ");
    Register(Fix.L10N_EF_TURN_LOSS, "ターン経過毎に失う量 ", "Loss per Turn ");
    Register(Fix.L10N_EF_MAX_VALUE_UP, "最大値の上昇量 ", "Max Value Increase ");
    Register(Fix.L10N_EF_TIME_STOP_TIMER, "時間停止タイマ ", "Time Stop Timer ");
    Register(Fix.L10N_EF_CRITICAL_RATE, "クリティカル発生率 +", "Critical Rate +");
    Register(Fix.L10N_EF_TWICE, " x2回", " x2");
    Register(Fix.L10N_EF_REMOVE_COUNT, "、1度に除去できる数 ", ", Removed at Once ");
    Register(Fix.L10N_EF_SURROUND_POWER, "、周囲全体への威力 ", ", Surrounding Power ");
    // 能力値の増減
    Register(Fix.L10N_EF_PATK_DOWN, "$0の減少量 ", "$0 Reduction ",
      Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_EF_PDEF_UP, "$0の増加量 ", "$0 Increase ",
      Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_EF_PDEF_DOWN, "$0の減少量 ", "$0 Reduction ",
      Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_EF_MDEF_DOWN, "$0の減少量 ", "$0 Reduction ",
      Term(Fix.L10N_MAGIC_DEFENSE));
    Register(Fix.L10N_EF_BS_UP, "$0の増加量 ", "$0 Increase ",
      Term(Fix.L10N_BATTLE_SPEED));
    Register(Fix.L10N_EF_BR_UP, "$0の増加量 ", "$0 Increase ",
      Term(Fix.L10N_BATTLE_RESPONSE));
    Register(Fix.L10N_EF_PO_UP, "$0の増加量 ", "$0 Increase ",
      Term(Fix.L10N_POTENTIAL));
    Register(Fix.L10N_EF_MAXLIFE_UP, "$0の増加量 ", "$0 Increase ",
      Term(Fix.L10N_MAX_LIFE));
    Register(Fix.L10N_EF_PATK_MATK_UP, "$0／$1の増加量 ", "$0 / $1 Increase ",
      Term(Fix.L10N_PHYSICAL_ATTACK), Term(Fix.L10N_MAGIC_ATTACK));
    Register(Fix.L10N_EF_PDEF_MDEF_BR_DOWN, "$0／$1／$2の減少量 ", "$0 / $1 / $2 Reduction ",
      Term(Fix.L10N_PHYSICAL_DEFENSE), Term(Fix.L10N_MAGIC_DEFENSE), Term(Fix.L10N_BATTLE_RESPONSE));
    Register(Fix.L10N_EF_PDEF_IGNORE, "$0を無視する量 ", "$0 Ignored ",
      Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_EF_PDEF_DOWN_EFFECT, "$0ＤＯＷＮ影響 ", "$0 Down Effect ",
      Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_EF_BLADE_STANCE_RATE, "、$0ヒット毎の上昇率", ", Increase per $0 Hit ",
      Term(Fix.L10N_PHYSICAL_ATTACK));
    // ゲージ
    Register(Fix.L10N_EF_OWN_GAUGE_ADVANCE, "自分の$0進行率 ", "Own $0 Advance ",
      Term(Fix.L10N_ACTION_GAUGE));
    Register(Fix.L10N_EF_ENEMY_GAUGE_DELAY, "、敵の$0後退率 ", ", Enemy $0 Delay ",
      Term(Fix.L10N_ACTION_GAUGE));
    Register(Fix.L10N_EF_INSTANT_GAUGE_ADVANCE, "$0進行 ", "$0 Advance ",
      Term(Fix.L10N_INSTANT_GAUGE));
    // BUFF名を含む句
    Register(Fix.L10N_EF_EXTRA_FIRE_POWER, "追加【$0】の威力 ", "Extra [$0] Power ",
      (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_EF_CRYSTAL_POWER, "【$0】の威力 ", "[$0] Power ",
      (Fix.BUFF_CRYSTAL_JP, Fix.BUFF_CRYSTAL));
    Register(Fix.L10N_EF_HELLFIRE_POWER, "【$0】の威力 ", "[$0] Power ",
      (Fix.BUFF_HELLFIRE_JP, Fix.BUFF_HELLFIRE));
    Register(Fix.L10N_EF_FLAMERING_POWER, "【$0】による【$1】ダメージの威力 ", "[$1] Damage Power from [$0] ",
      (Fix.BUFF_FLAME_RING_JP, Fix.BUFF_FLAME_RING), (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_EF_SLIP_POWER, "【$0】ダメージの威力 ", "[$0] Damage Power ",
      (Fix.EFFECT_SLIP_JP, Fix.EFFECT_SLIP));
    Register(Fix.L10N_EF_CURSE_DARK_POWER, "【$0】による【$1】ダメージの威力 ", "[$1] Damage Power from [$0] ",
      (Fix.BUFF_CURSE_JP, Fix.BUFF_CURSE), (Fix.TERM_DARK_JP, Fix.TERM_DARK));
    Register(Fix.L10N_EF_FOCUS_EYE_POWER, "【$0】による【$1】ダメージの威力 ", "[$1] Damage Power from [$0] ",
      (Fix.BUFF_FOCUS_EYE_JP, Fix.BUFF_FOCUS_EYE), (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL));
    Register(Fix.L10N_EF_IAI_POWER, "【$0】による【$1】ダメージの威力 ", "[$1] Damage Power from [$0] ",
      (Fix.BUFF_STANCE_OF_THE_IAI_JP, Fix.BUFF_STANCE_OF_THE_IAI), (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL));
    Register(Fix.L10N_EF_HOLY_ON_HIT_POWER, "$1ヒット時の【$0】ダメージの威力 ", "[$0] Damage Power on $1 Hit ",
      (Fix.TERM_HOLY_JP, Fix.TERM_HOLY), Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_EF_PRAISE_LIFE_RECOVERY, "【$0】による$1の回復量 ", "$1 Recovery from [$0] ",
      (Fix.BUFF_PRAISE_JP, Fix.BUFF_PRAISE), Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_EF_GRACE_REDUCTION, "【$0】による軽減量 ", "Reduction from [$0] ",
      (Fix.BUFF_GRACE_JP, Fix.BUFF_GRACE));
    Register(Fix.L10N_EF_WATERVEIN_REDUCTION, "【$0】による【$1】ダメージ軽減量 ", "[$1] Damage Reduction from [$0] ",
      (Fix.BUFF_WATER_VEIN_JP, Fix.BUFF_WATER_VEIN), (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC));
    Register(Fix.L10N_EF_MAGIC_COST_REDUCTION, "、魔法消費コスト軽減量 ", ", Spell Cost Reduction ");
    Register(Fix.L10N_EF_DESPERATION_PATK_UP, "【$0】による$1ＵＰ影響 ", "$1 Up Effect from [$0] ",
      (Fix.BUFF_DESPERATION_JP, Fix.BUFF_DESPERATION), Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_EF_IRONWALL_DEF_UP, "【$0】による$1／$2の増加量 ", "$1 / $2 Increase from [$0] ",
      (Fix.BUFF_IRON_WALL_JP, Fix.BUFF_IRON_WALL), Term(Fix.L10N_PHYSICAL_DEFENSE), Term(Fix.L10N_MAGIC_DEFENSE));
    Register(Fix.L10N_EF_GUARD_REDUCTION, "%、【$0】姿勢によるダメージ軽減 ", "%, Damage Reduction in [$0] Stance ",
      (Fix.DEFENSE_JP, Fix.DEFENSE));
    Register(Fix.L10N_EF_PERSISTENCE_KEEP, "【$0】による$1維持率 ", "$1 Retention from [$0] ",
      (Fix.BUFF_PERSISTENCE_JP, Fix.BUFF_PERSISTENCE), Term(Fix.L10N_INSTANT_GAUGE));

    // ---------------------------------------------------------------
    // 強化内容ラベル (ActionCommand.GetDescReinforce)
    // 増減値(＋１０ / －５)はリテラルのまま残し、ラベル部分のみ対訳化する。
    // ---------------------------------------------------------------
    Register(Fix.L10N_RF_FIRE_POWER, "【$0】ダメージの威力 ", "[$0] Damage Power ",
      (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_RF_ICE_POWER, "【$0】ダメージの威力 ", "[$0] Damage Power ",
      (Fix.TERM_ICE_JP, Fix.TERM_ICE));
    Register(Fix.L10N_RF_PHYS_POWER, "【$0】ダメージの威力 ", "[$0] Damage Power ",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL));
    Register(Fix.L10N_RF_TARGET_POWER, "対象へのダメージの威力 ", "Damage Power to Target ");
    Register(Fix.L10N_RF_REMOVE_AT_ONCE, "、一度に除去する数 ", ", Removed at Once ");
    Register(Fix.L10N_RF_INSTANT_GAUGE_RATE, "$0の進行率 ", "$0 Advance Rate ",
      Term(Fix.L10N_INSTANT_GAUGE));
    Register(Fix.L10N_RF_METEOR_HITS, "$0の攻撃回数 ", "$0 Attack Count ",
      (Fix.METEOR_BULLET_JP, Fix.METEOR_BULLET));
    Register(Fix.L10N_RF_BLUE_HITS, "$0の攻撃回数 ", "$0 Attack Count ",
      (Fix.BLUE_BULLET_JP, Fix.BLUE_BULLET));
    // BUFF + 継続ターン数
    Register(Fix.L10N_RF_STUN_DURATION, "【$0】の継続ターン数 ", "[$0] Duration ",
      (Fix.EFFECT_STUN_JP, Fix.EFFECT_STUN));
    Register(Fix.L10N_RF_BLACKCONTRACT_DURATION, "【$0】の継続ターン数 ", "[$0] Duration ",
      (Fix.BUFF_BLACK_CONTRACT_JP, Fix.BUFF_BLACK_CONTRACT));
    Register(Fix.L10N_RF_PENDING_DURATION, "【$0】の継続ターン数 ", "[$0] Duration ",
      (Fix.BUFF_PENDING_JP, Fix.BUFF_PENDING));
    Register(Fix.L10N_RF_CLONE_DURATION, "【$0】の継続ターン数 ", "[$0] Duration ",
      (Fix.BUFF_CLONE_JP, Fix.BUFF_CLONE));
    Register(Fix.L10N_RF_AWAKENING_DURATION, "【$0】の継続ターン数 ", "[$0] Duration ",
      (Fix.BUFF_AWAKENING_JP, Fix.BUFF_AWAKENING));
    Register(Fix.L10N_RF_BLESSING_DURATION, "【$0】の継続ターン数 ", "[$0] Duration ",
      (Fix.BUFF_BLESSING_JP, Fix.BUFF_BLESSING));
    Register(Fix.L10N_RF_LAPSE_DURATION, "【$0】の継続ターン数 ", "[$0] Duration ",
      (Fix.BUFF_LAPSE_JP, Fix.BUFF_LAPSE));
    Register(Fix.L10N_RF_FORTUNE_STACK, "【$0】の累積カウンター数 ", "[$0] Stack Count ",
      (Fix.EFFECT_FORTUNE_JP, Fix.EFFECT_FORTUNE));
    // BUFF + 能力値ＵＰ／ＤＯＷＮ
    Register(Fix.L10N_RF_SURGE_BS_UP, "【$0】による$1ＵＰ影響 ", "$1 Up Effect from [$0] ",
      (Fix.BUFF_SURGE_JP, Fix.BUFF_SURGE), Term(Fix.L10N_BATTLE_SPEED));
    Register(Fix.L10N_RF_INSIGHT_PO_UP, "【$0】による$1ＵＰ影響 ", "$1 Up Effect from [$0] ",
      (Fix.BUFF_INSIGHT_JP, Fix.BUFF_INSIGHT), Term(Fix.L10N_POTENTIAL));
    Register(Fix.L10N_RF_BLADESTANCE_PATK_UP, "【$0】による$1ＵＰ影響 ", "$1 Up Effect from [$0] ",
      (Fix.BUFF_BLADE_STANCE_JP, Fix.BUFF_BLADE_STANCE), Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_RF_GUARDSTANCE_PDEF_UP, "【$0】による$1ＵＰ影響 ", "$1 Up Effect from [$0] ",
      (Fix.BUFF_GUARD_STANCE_JP, Fix.BUFF_GUARD_STANCE), Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_RF_SWIFTSTANCE_BR_UP, "【$0】による$1ＵＰ影響 ", "$1 Up Effect from [$0] ",
      (Fix.BUFF_SWIFT_STANCE_JP, Fix.BUFF_SWIFT_STANCE), Term(Fix.L10N_BATTLE_RESPONSE));
    Register(Fix.L10N_RF_DESPERATION_PATK_UP, "【$0】による$1ＵＰ影響 (30%以下)", "$1 Up Effect from [$0] (at 30% or less)",
      (Fix.BUFF_DESPERATION_JP, Fix.BUFF_DESPERATION), Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_RF_SHADE_MDEF_DOWN, "【$0】による$1ＤＯＷＮ影響 ", "$1 Down Effect from [$0] ",
      (Fix.BUFF_SHADE_JP, Fix.BUFF_SHADE), Term(Fix.L10N_MAGIC_DEFENSE));
    Register(Fix.L10N_RF_BREACH_PDEF_DOWN, "【$0】による$1ＤＯＷＮ影響 ", "$1 Down Effect from [$0] ",
      (Fix.BUFF_BREACH_JP, Fix.BUFF_BREACH), Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_RF_WOUND_PATK_DOWN, "【$0】による$1ＤＯＷＮ影響 ", "$1 Down Effect from [$0] ",
      (Fix.BUFF_WOUND_JP, Fix.BUFF_WOUND), Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_RF_SCAR_PDEF_DOWN, "【$0】による$1ＤＯＷＮ影響 ", "$1 Down Effect from [$0] ",
      (Fix.BUFF_SCAR_JP, Fix.BUFF_SCAR), Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_RF_BLIGHT_DEF_DOWN, "【$0】による$1／$2／$3ＤＯＷＮ影響 ", "$1 / $2 / $3 Down Effect from [$0] ",
      (Fix.BUFF_BLIGHT_JP, Fix.BUFF_BLIGHT), Term(Fix.L10N_PHYSICAL_DEFENSE), Term(Fix.L10N_MAGIC_DEFENSE), Term(Fix.L10N_BATTLE_RESPONSE));
    // BUFF + その他
    Register(Fix.L10N_RF_MARK_CRITICAL, "【$0】によるクリティカル発生率 ", "Critical Rate from [$0] ",
      (Fix.BUFF_MARK_JP, Fix.BUFF_MARK));
    Register(Fix.L10N_RF_BLOODSIGIL_DAMAGE, "【$0】によるダメージ量 ", "Damage from [$0] ",
      (Fix.BUFF_BLOOD_SIGIL_JP, Fix.BUFF_BLOOD_SIGIL));
    Register(Fix.L10N_RF_ISSHIN_PDEF_IGNORE, "【$0】による対象の$1を無視する量 ", "Target's $1 Ignored by [$0] ",
      (Fix.BUFF_ISSHIN_JP, Fix.BUFF_ISSHIN), Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_RF_VIGOR_MAXLIFE_UP, "【$0】による$1の増加量 ", "$1 Increase from [$0] ",
      (Fix.BUFF_VIGOR_JP, Fix.BUFF_VIGOR), Term(Fix.L10N_MAX_LIFE));
    Register(Fix.L10N_RF_LEYLINE_SP_RECOVERY, "【$0】によるＳＰの回復量 ", "SP Recovery from [$0] ",
      (Fix.BUFF_LEYLINE_JP, Fix.BUFF_LEYLINE));
    Register(Fix.L10N_RF_IRONWALL_DEF_UP, "【$0】による$1／$2の増加 ", "$1 / $2 Increase from [$0] ",
      (Fix.BUFF_IRON_WALL_JP, Fix.BUFF_IRON_WALL), Term(Fix.L10N_PHYSICAL_DEFENSE), Term(Fix.L10N_MAGIC_DEFENSE));
    Register(Fix.L10N_RF_BATTLEREADY_ATK_UP, "【$0】による$1／$2 ", "$1 / $2 from [$0] ",
      (Fix.BUFF_BATTLE_READY_JP, Fix.BUFF_BATTLE_READY), Term(Fix.L10N_PHYSICAL_ATTACK), Term(Fix.L10N_MAGIC_ATTACK));
    Register(Fix.L10N_RF_FLAMEBLADE_POWER, "【$0】による追加【$1】ダメージの威力 ", "Extra [$1] Damage Power from [$0] ",
      (Fix.BUFF_FLAME_BLADE_JP, Fix.BUFF_FLAME_BLADE), (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_RF_HELLFIRE_FIRE_POWER, "【$0】による【$1】ダメージの威力 ", "[$1] Damage Power from [$0] ",
      (Fix.BUFF_HELLFIRE_JP, Fix.BUFF_HELLFIRE), (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_RF_CRYSTAL_ICE_UP, "【$0】による【$1】ダメージの上昇量 ", "[$1] Damage Increase from [$0] ",
      (Fix.BUFF_CRYSTAL_JP, Fix.BUFF_CRYSTAL), (Fix.TERM_ICE_JP, Fix.TERM_ICE));
    Register(Fix.L10N_RF_SURROUND_POWER, "　周囲全体へのダメージの威力 ", "  Surrounding Damage Power ");
    Register(Fix.L10N_RF_COND_20, "　(20%以下)", "  (at 20% or less)");
    Register(Fix.L10N_RF_COND_10, "　(10%以下)", "  (at 10% or less)");

    // ---------------------------------------------------------------
    // アイテム説明のステータス表記 (Item.Description)
    // フレーバー部は日本語のまま残るため、境界に改行を入れて切り替わりを示す。
    // ---------------------------------------------------------------
    Register(Fix.L10N_IT_PATK, "$0力", "$0 ", Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_IT_MATK, "$0力", "$0 ", Term(Fix.L10N_MAGIC_ATTACK));
    Register(Fix.L10N_IT_PDEF, "$0力", "$0 ", Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_IT_MDEF, "$0力", "$0 ", Term(Fix.L10N_MAGIC_DEFENSE));
    Register(Fix.L10N_IT_STR, "$0", "$0 ", (Fix.TERM_STRENGTH_JP, Fix.TERM_STRENGTH));
    Register(Fix.L10N_IT_AGI, "$0", "$0 ", (Fix.TERM_AGILITY_JP, Fix.TERM_AGILITY));
    Register(Fix.L10N_IT_INT, "$0", "$0 ", (Fix.TERM_INTELLIGENCE_JP, Fix.TERM_INTELLIGENCE));
    Register(Fix.L10N_IT_STA, "$0", "$0 ", (Fix.TERM_STAMINA_JP, Fix.TERM_STAMINA));
    Register(Fix.L10N_IT_MND, "$0", "$0 ", (Fix.TERM_MIND_JP, Fix.TERM_MIND));
    // 率
    Register(Fix.L10N_IT_RATE_PATK, "物攻率", "Physical Attack Rate ");
    Register(Fix.L10N_IT_RATE_PDEF, "物防率", "Physical Defense Rate ");
    Register(Fix.L10N_IT_RATE_MATK, "魔攻率", "Magic Attack Rate ");
    Register(Fix.L10N_IT_RATE_MDEF, "魔防率", "Magic Defense Rate ");
    Register(Fix.L10N_IT_RATE_SPEED, "戦速率", "Battle Speed Rate ");
    Register(Fix.L10N_IT_RATE_RESPONSE, "戦応率", "Battle Response Rate ");
    Register(Fix.L10N_IT_RATE_POTENTIAL, "潜在率", "Potential Rate ");
    // 耐性
    Register(Fix.L10N_IT_RES_STUN, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_STUN_JP, Fix.EFFECT_STUN));
    Register(Fix.L10N_IT_RES_SILENT, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_SILENT_JP, Fix.EFFECT_SILENT));
    Register(Fix.L10N_IT_RES_PARALYZE, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_PARALYZE_JP, Fix.EFFECT_PARALYZE));
    Register(Fix.L10N_IT_RES_BIND, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_BIND_JP, Fix.EFFECT_BIND));
    Register(Fix.L10N_IT_RES_POISON, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_POISON_JP, Fix.EFFECT_POISON));
    Register(Fix.L10N_IT_RES_FEAR, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_FEAR_JP, Fix.EFFECT_FEAR));
    Register(Fix.L10N_IT_RES_FREEZE, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_FREEZE_JP, Fix.EFFECT_FREEZE));
    Register(Fix.L10N_IT_RES_SLIP, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_SLIP_JP, Fix.EFFECT_SLIP));
    Register(Fix.L10N_IT_RES_DIZZY, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_DIZZY_JP, Fix.EFFECT_DIZZY));
    Register(Fix.L10N_IT_RES_SLEEP, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_SLEEP_JP, Fix.EFFECT_SLEEP));
    Register(Fix.L10N_IT_RES_SLOW, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_SLOW_JP, Fix.EFFECT_SLOW));
    Register(Fix.L10N_IT_RES_TEMPTATION, "【$0】耐性", "[$0] Resist ", (Fix.EFFECT_TEMPTATION_JP, Fix.EFFECT_TEMPTATION));
    Register(Fix.L10N_IT_RES_FIRE, "【$0】耐性", "[$0] Resist ", (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_IT_RES_ICE, "【$0】耐性", "[$0] Resist ", (Fix.TERM_ICE_JP, Fix.TERM_ICE));
    Register(Fix.L10N_IT_RES_HOLY, "【$0】耐性", "[$0] Resist ", (Fix.TERM_HOLY_JP, Fix.TERM_HOLY));
    Register(Fix.L10N_IT_RES_DARK, "【$0】耐性", "[$0] Resist ", (Fix.TERM_DARK_JP, Fix.TERM_DARK));
    // 増幅
    Register(Fix.L10N_IT_AMP_FIRE, "【$0】増幅", "[$0] Amplify ", (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_IT_AMP_ICE, "【$0】増幅", "[$0] Amplify ", (Fix.TERM_ICE_JP, Fix.TERM_ICE));
    Register(Fix.L10N_IT_AMP_HOLY, "【$0】増幅", "[$0] Amplify ", (Fix.TERM_HOLY_JP, Fix.TERM_HOLY));
    Register(Fix.L10N_IT_AMP_DARK, "【$0】増幅", "[$0] Amplify ", (Fix.TERM_DARK_JP, Fix.TERM_DARK));
    // 属性攻撃ダメージ
    Register(Fix.L10N_IT_ATKDMG_FIRE, "【$0】属性の攻撃ダメージ", "[$0] Attack Damage ", (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_IT_ATKDMG_ICE, "【$0】属性の攻撃ダメージ", "[$0] Attack Damage ", (Fix.TERM_ICE_JP, Fix.TERM_ICE));
    Register(Fix.L10N_IT_ATKDMG_HOLY, "【$0】属性の攻撃ダメージ", "[$0] Attack Damage ", (Fix.TERM_HOLY_JP, Fix.TERM_HOLY));
    Register(Fix.L10N_IT_ATKDMG_DARK, "【$0】属性の攻撃ダメージ", "[$0] Attack Damage ", (Fix.TERM_DARK_JP, Fix.TERM_DARK));
    // ポーション等の回復量。「$0を <数値> 回復する。」の形で数値を挟む。
    Register(Fix.L10N_IT_RECOVER_LIFE_PRE, "$0を", "Restores $0 by ", Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_IT_RECOVER_MANA_PRE, "$0を", "Restores $0 by ", Term(Fix.L10N_BASIC_MANA_POINT));
    Register(Fix.L10N_IT_RECOVER_SP_PRE, "$0を", "Restores $0 by ", Term(Fix.L10N_SKILL_POINT));
    Register(Fix.L10N_IT_RECOVER_SUFFIX, "回復する。", ". ");
    Register(Fix.L10N_IT_UP_SUFFIX, "ＵＰ。", " Up. ");
    // 特殊効果の見出し
    // 見出しであり用語タグではないため、英語側は 【】 を用いない。
    Register(Fix.L10N_IT_SPECIAL, "【特殊効果】", "-- Special Effect -- ");
    Register(Fix.L10N_RF_GUARD_REDUCTION, "　【$0】姿勢によるダメージ軽減 ", "  Damage Reduction in [$0] Stance ",
      (Fix.DEFENSE_JP, Fix.DEFENSE));

    // ActionCommand説明文 - Delve I
    //
    // BUFF名の英訳について:
    //   【鈍化】【スタン】【沈黙】は Fix.EFFECT_SLOW / EFFECT_STUN / EFFECT_SILENT に準拠。
    //   【陰影】[Shade] 【躍動】[Surge] 【標的】[Mark] 【深層】[Insight] 【暗闇】[Blind] は
    //   既存の英訳定数が無いため新規に命名した。名称を変更する場合はここを直す。
    //
    // 魔法
    Register(Fix.L10N_DESC_FIRE_BALL,
      "敵一体を対象とする。対象に【$0】ダメージを与える。",
      "Targets one enemy. Deals [$0] damage to the target.",
      (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_DESC_ICE_NEEDLE,
      "敵一体を対象とする。対象に【$1】ダメージを与えた後、【$0】のBUFFを付与する。\r\n【$0】が続く間、$2が減少する。",
      "Targets one enemy. Deals [$1] damage to the target, then applies [$0].\r\nWhile [$0] lasts, the target's $2 is reduced.",
      (Fix.EFFECT_SLOW_JP, Fix.EFFECT_SLOW),
      (Fix.TERM_ICE_JP, Fix.TERM_ICE),
      Term(Fix.L10N_BATTLE_SPEED));
    Register(Fix.L10N_DESC_FRESH_HEAL,
      "味方一体を対象とする。対象の$0を回復する。",
      "Targets one ally. Restores the target's $0.",
      Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_DESC_SHADOW_BLAST,
      "敵一体を対象とする。対象に【$1】ダメージを与えた後、【$0】のBUFFを付与する。\r\n【$0】が続く間、$2が減少する。",
      "Targets one enemy. Deals [$1] damage to the target, then applies [$0].\r\nWhile [$0] lasts, the target's $2 is reduced.",
      (Fix.BUFF_SHADE_JP, Fix.BUFF_SHADE),
      (Fix.TERM_DARK_JP, Fix.TERM_DARK),
      Term(Fix.L10N_MAGIC_DEFENSE));
    Register(Fix.L10N_DESC_ORACLE_COMMAND,
      "味方一体を対象とする。対象の$0を進行させる。",
      "Targets one ally. Advances the target's $0.",
      Term(Fix.L10N_INSTANT_GAUGE));
    Register(Fix.L10N_DESC_ENERGY_BOLT,
      "敵一体を対象とする。対象に$0の【$1】ダメージを与える。",
      "Targets one enemy. Deals $0 [$1] damage to the target.",
      (Fix.TERM_COLORLESS_JP, Fix.TERM_COLORLESS),
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC));
    // スキル
    Register(Fix.L10N_DESC_STRAIGHT_SMASH,
      "敵一体を対象とする。対象に【$0】ダメージを与える。",
      "Targets one enemy. Deals [$0] damage to the target.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL));
    Register(Fix.L10N_DESC_SHIELD_BASH,
      "敵一体を対象とする。対象を【$1】ダメージを与えた後、【$0】のBUFFを付与する。\r\n【$0】が続く間、$2進行が停止する。",
      "Targets one enemy. Deals [$1] damage to the target, then applies [$0].\r\nWhile [$0] lasts, the target's $2 stops advancing.",
      (Fix.EFFECT_STUN_JP, Fix.EFFECT_STUN),
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      Term(Fix.L10N_BATTLE_GAUGE));
    Register(Fix.L10N_DESC_LEG_STRIKE,
      "敵一体を対象とする。対象に【$1】ダメージを与えた後、自分自身に【$0】のBUFFを付与する。\r\n【$0】が続く間、$2が上昇する。",
      "Targets one enemy. Deals [$1] damage to the target, then applies [$0] to self.\r\nWhile [$0] lasts, $2 increases.",
      (Fix.BUFF_SURGE_JP, Fix.BUFF_SURGE),
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      Term(Fix.L10N_BATTLE_SPEED));
    Register(Fix.L10N_DESC_HUNTER_SHOT,
      "敵一体を対象とする。対象に【$1】ダメージを与えた後、対象へ【$0】のBUFFを付与する。\r\n【$0】が続く間、対象はクリティカルを受ける確率が上昇する。",
      "Targets one enemy. Deals [$1] damage to the target, then applies [$0].\r\nWhile [$0] lasts, the target is more likely to take critical hits.",
      (Fix.BUFF_MARK_JP, Fix.BUFF_MARK),
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL));
    Register(Fix.L10N_DESC_TRUE_SIGHT,
      "味方一体を対象とする。対象に【$0】のBUFFを付与する。\r\n【$0】が続く間、【$1】【$2】【$3】のBUFFがあったとしてもそれがあたかも無いかに様に行動する。",
      "Targets one ally. Applies [$0] to the target.\r\nWhile [$0] lasts, the target acts as though [$1], [$2] and [$3] were not present, even while afflicted by them.",
      (Fix.BUFF_INSIGHT_JP, Fix.BUFF_INSIGHT),
      (Fix.EFFECT_SILENT_JP, Fix.EFFECT_SILENT),
      (Fix.EFFECT_SLOW_JP, Fix.EFFECT_SLOW),
      (Fix.EFFECT_BLIND_JP, Fix.EFFECT_BLIND));
    Register(Fix.L10N_DESC_DISPEL_MAGIC,
      "敵一体を対象とする。対象にかかっている【$0】に属するBUFFを除去する。",
      "Targets one enemy. Removes all [$0] buffs from the target.",
      (Fix.TERM_BENEFICIAL_JP, Fix.TERM_BENEFICIAL));

    // ActionCommand説明文 - Delve II
    //
    // BUFF名の英訳について:
    //   【幸運】は Fix.EFFECT_FORTUNE、【出血】は Fix.EFFECT_SLIP、【スタン】は Fix.EFFECT_STUN に準拠。
    //   【炎剣】[Flame Blade] 【加護】[Grace] 【血の刻印】[Blood Sigil] 【剣の構え】[Blade Stance]
    //   【盾の構え】[Guard Stance] 【俊足の構え】[Swift Stance] 【直光】[Leyline] 【鮮明】[Clarity] は
    //   既存の英訳定数が無いため新規に命名した。名称を変更する場合はここを直す。
    //
    // 魔法
    Register(Fix.L10N_DESC_FLAME_BLADE,
      "味方一体を対象とする。対象に【$0】のBUFFを付与する。【$0】が続く間、$1を行う度に、【$2】ダメージが追加発生する。",
      "Targets one ally. Applies [$0] to the target. While [$0] lasts, each $1 deals additional [$2] damage.",
      (Fix.BUFF_FLAME_BLADE_JP, Fix.BUFF_FLAME_BLADE),
      Term(Fix.L10N_PHYSICAL_ATTACK),
      (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_DESC_PURE_PURIFICATION,
      "味方一体を対象とする。対象の$0を回復する。対象にかかっている【$1】に属するBUFFを除去する。",
      "Targets one ally. Restores the target's $0. Removes all [$1] buffs from the target.",
      Term(Fix.L10N_BASIC_LIFE),
      (Fix.TERM_HARMFUL_JP, Fix.TERM_HARMFUL));
    Register(Fix.L10N_DESC_DIVINE_CIRCLE,
      "味方フィールドに、【$0】のフィールドを形成する。味方に与えられる$1属性のダメージは【$0】のポイントに吸収される。【$0】のポイントが0以下になった場合、【$0】フィールドは消滅する。",
      "Forms a [$0] field on the ally field. $1 attribute damage dealt to allies is absorbed by [$0] points. When [$0] points reach 0 or below, the [$0] field disappears.",
      (Fix.BUFF_GRACE_JP, Fix.BUFF_GRACE),
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC));
    Register(Fix.L10N_DESC_BLOOD_SIGN,
      "敵一体を対象とする。対象に【$0】のBUFFを付与する。【$0】が続く間、対象が行動する度に、$1ダメージを食らう。",
      "Targets one enemy. Applies [$0] to the target. While [$0] lasts, the target takes $1 damage each time it acts.",
      (Fix.BUFF_BLOOD_SIGIL_JP, Fix.BUFF_BLOOD_SIGIL),
      (Fix.EFFECT_SLIP_JP, Fix.EFFECT_SLIP));
    Register(Fix.L10N_DESC_FORTUNE_SPIRIT,
      "味方一体を対象とする。対象に【$0】のBUFFを付与する。【$0】が続く間、次の攻撃がヒットした場合、100 % クリティカルヒットとなる。ダメージを伴う1回のアクションコマンドが完了した後、このBUFFは除去される。",
      "Targets one ally. Applies [$0] to the target. While [$0] lasts, the next attack that hits becomes a guaranteed critical hit. This buff is removed after one action command involving damage is completed.",
      (Fix.EFFECT_FORTUNE_JP, Fix.EFFECT_FORTUNE));
    Register(Fix.L10N_DESC_FLASH_COUNTER,
      "インスタント限定。インスタント行動が行われた際、その行動属性が【$0】であり、BUFF付与を行うものである場合、そのインスタント行動を打ち消す。",
      "Instant only. When an instant action is performed, if its attribute is [$0] and it applies a buff, that instant action is negated.",
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC));
    // スキル
    Register(Fix.L10N_DESC_STANCE_OF_THE_BLADE,
      "敵一体を対象とする。対象に【$0】ダメージを与える。自分自身に【$1】のBUFFを付与する。この効果が続く間、$2がヒットする度に、$2が上昇する。このスタックは5回まで累積する。",
      "Targets one enemy. Deals [$0] damage to the target. Applies [$1] to self. While this effect lasts, $2 increases each time a $2 lands. This stack accumulates up to 5 times.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      (Fix.BUFF_BLADE_STANCE_JP, Fix.BUFF_BLADE_STANCE),
      Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_DESC_STANCE_OF_THE_GUARD,
      "自分自身に【$0】のBUFFを付与する。この効果が続く間、防御姿勢で敵からの攻撃を受ける度に、$1が上昇する。このスタックは5回まで累積する。",
      "Applies [$0] to self. While this effect lasts, $1 increases each time you take an enemy attack while in a defensive stance. This stack accumulates up to 5 times.",
      (Fix.BUFF_GUARD_STANCE_JP, Fix.BUFF_GUARD_STANCE),
      Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_DESC_SPEED_STEP,
      "敵一体を対象とする。対象に【$0】ダメージを与えた後、自分自身に【$1】のBUFFを付与する。この効果が続く間、メイン行動が完了する度に、$2が上昇する。このスタックは5回まで累積する。",
      "Targets one enemy. Deals [$0] damage to the target, then applies [$1] to self. While this effect lasts, $2 increases each time a main action is completed. This stack accumulates up to 5 times.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      (Fix.BUFF_SWIFT_STANCE_JP, Fix.BUFF_SWIFT_STANCE),
      Term(Fix.L10N_BATTLE_RESPONSE));
    Register(Fix.L10N_DESC_MULTIPLE_SHOT,
      "敵全員に【$0】ダメージを与える。",
      "Deals [$0] damage to all enemies.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL));
    Register(Fix.L10N_DESC_LEYLINE_SCHEMA,
      "味方フィールドに【$0】のフィールドを形成する。【$0】が続く間、ターン経過毎に$1が回復する。",
      "Forms a [$0] field on the ally field. While [$0] lasts, $1 is restored each turn.",
      (Fix.BUFF_LEYLINE_JP, Fix.BUFF_LEYLINE),
      Term(Fix.L10N_SKILL_POINT));
    Register(Fix.L10N_DESC_SPIRITUAL_REST,
      "味方一体を対象とする。対象が【$0】にかかっている場合、それを除去する。加えて、対象に【$1】のBUFFを付与する。【$1】が続く間、対象は【$0】に対する耐性を得る。",
      "Targets one ally. Removes [$0] from the target if it is afflicted. In addition, applies [$1] to the target. While [$1] lasts, the target gains resistance to [$0].",
      (Fix.EFFECT_STUN_JP, Fix.EFFECT_STUN),
      (Fix.BUFF_CLARITY_JP, Fix.BUFF_CLARITY));

    // ActionCommand説明文 - Delve III
    //
    // BUFF名の英訳について:
    //   【防御】は Fix.DEFENSE(防御コマンド)に準拠。
    //   【黒契約】[Black Contract] 【留保】[Pending] 【破損】[Breach] 【損傷】[Wound]
    //   【活力】[Vigor] は既存の英訳定数が無いため新規に命名した。
    //   【一心】[Isshin] は英訳せずローマ字表記とする(Fix.BUFF_ISSHIN)。
    //
    // 魔法
    Register(Fix.L10N_DESC_METEOR_BULLET,
      "敵グループを対象とする。いずれかの敵に対して、ランダムに3回の【$0】ダメージを与える。",
      "Targets an enemy group. Deals [$0] damage 3 times to randomly chosen enemies.",
      (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_DESC_BLUE_BULLET,
      "敵一体を対象とする。対象に3回の【$0】ダメージを与える。",
      "Targets one enemy. Deals [$0] damage to the target 3 times.",
      (Fix.TERM_ICE_JP, Fix.TERM_ICE));
    Register(Fix.L10N_DESC_HOLY_BREATH,
      "味方全員の$0を回復する。",
      "Restores $0 for all allies.",
      Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_DESC_BLACK_CONTRACT,
      "自分自身を対象とし、【$0】のBUFFを付与する。【$0】が続く間、ターン経過毎に$1の10%の分だけ$2を失う。アクションコマンドで消費するコストが0になる。",
      "Targets self and applies [$0]. While [$0] lasts, you lose $2 equal to 10% of $1 each turn, and action commands cost 0.",
      (Fix.BUFF_BLACK_CONTRACT_JP, Fix.BUFF_BLACK_CONTRACT),
      Term(Fix.L10N_MAX_LIFE),
      Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_DESC_WORD_OF_POWER,
      "敵一体を対象とする。対象に【$0】ダメージを与える。ダメージ量は【$1】を根源として算出されるが、$2属性として扱われる。\r\n対象が【$3】を行っていても、あたかも【$3】していないかのようにダメージを与える。\r\nこの魔法はカウンターされない。",
      "Targets one enemy. Deals [$0] damage to the target. The damage is derived from [$1], but is treated as $2 attribute damage.\r\nDamage is dealt as though the target were not using [$3], even while it is.\r\nThis spell cannot be countered.",
      (Fix.TERM_FORCE_JP, Fix.TERM_FORCE),
      (Fix.TERM_STRENGTH_JP, Fix.TERM_STRENGTH),
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC),
      (Fix.DEFENSE_JP, Fix.DEFENSE));
    Register(Fix.L10N_DESC_SIGIL_OF_THE_PENDING,
      "敵一体、または味方一体を対象とする。対象に【$0】のBUFFを付与する。【$0】のBUFFが続く間、対象のターン経過毎に影響が発生する効果を無効扱いとする。",
      "Targets one enemy or one ally. Applies [$0] to the target. While [$0] lasts, effects that trigger on the target's turn are treated as nullified.",
      (Fix.BUFF_PENDING_JP, Fix.BUFF_PENDING));
    // スキル
    Register(Fix.L10N_DESC_DOUBLE_SLASH,
      "敵一体を対象とする。対象に2回【$0】ダメージを与える。",
      "Targets one enemy. Deals [$0] damage to the target 2 times.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL));
    Register(Fix.L10N_DESC_CONCUSSIVE_HIT,
      "敵一体を対象とする。対象に【$0】ダメージを与える。対象に【$1】のBUFFを付与する。【$1】が続く間、対象の$2が減少する。この効果は5回まで累積可能である。",
      "Targets one enemy. Deals [$0] damage to the target. Applies [$1] to the target. While [$1] lasts, the target's $2 is reduced. This effect can accumulate up to 5 times.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      (Fix.BUFF_BREACH_JP, Fix.BUFF_BREACH),
      Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_DESC_BONE_CRUSH,
      "敵一体を対象とする。対象に【$0】ダメージを与える。対象に【$1】のBUFFを付与する。【$1】が続く間、対象の$2が20%低下する。",
      "Targets one enemy. Deals [$0] damage to the target. Applies [$1] to the target. While [$1] lasts, the target's $2 is reduced by 20%.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      (Fix.BUFF_WOUND_JP, Fix.BUFF_WOUND),
      Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_DESC_EYE_OF_THE_ISSHIN,
      "自分自身に【$0】のBUFFを付与する。【$0】が続く間、対象の$1を20%無視して、ダメージを当てられるようになる。",
      "Applies [$0] to self. While [$0] lasts, damage is dealt while ignoring 20% of the target's $1.",
      (Fix.BUFF_ISSHIN_JP, Fix.BUFF_ISSHIN),
      Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_DESC_VOICE_OF_VIGOR,
      "味方全員に【$0】のBUFFを付与する。【$0】が続く間、$1が上昇する。また、その分だけ$2を回復する。",
      "Applies [$0] to all allies. While [$0] lasts, $1 increases, and $2 is restored by the same amount.",
      (Fix.BUFF_VIGOR_JP, Fix.BUFF_VIGOR),
      Term(Fix.L10N_MAX_LIFE),
      Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_DESC_UNSEEN_AID,
      "敵味方全員を対象とする。対象にかかっている【$0】【$1】いずれのBUFFもすべて除去する。",
      "Targets all allies and enemies. Removes every [$0] and [$1] buff from them.",
      (Fix.TERM_HARMFUL_JP, Fix.TERM_HARMFUL),
      (Fix.TERM_BENEFICIAL_JP, Fix.TERM_BENEFICIAL));

    // ActionCommand説明文 - Delve IV
    //
    // BUFF名の英訳について:
    //   【束縛】【出血】【沈黙】【睡眠】【スタン】【麻痺】【恐怖】【誘惑】【鈍化】【眩暈】は
    //   Fix.EFFECT_* に、【防御】は Fix.DEFENSE に準拠。
    //   【業炎】[Hellfire] 【結晶】[Crystal] 【賛美】[Praise] 【呪い】[Curse] 【分身】[Clone]
    //   【鉄壁】[Iron Wall] 【決死】[Desperation] 【傷跡】[Scar] 【覚醒】[Awakening]
    //   【静穏】[Serenity] は既存の英訳定数が無いため新規に命名した。
    //   【朧】[Oboro] は英訳せずローマ字表記とする(コマンド名 Phantom Oboro に準拠)。
    //
    // 魔法
    Register(Fix.L10N_DESC_VOLCANIC_BLAZE,
      "敵全体に対して【$0】ダメージを与える。加えて、敵フィールドに、【$1】のフィールドを形成する。\r\n【$1】が続く間、敵全体に対して毎ターン【$0】ダメージを与える。加えて【$0】属性の【$2】ダメージを食らう場合、20%増加された形でダメージを食らう。",
      "Deals [$0] damage to all enemies. In addition, forms a [$1] field on the enemy field.\r\nWhile [$1] lasts, all enemies take [$0] damage each turn. In addition, [$0] attribute [$2] damage they take is increased by 20%.",
      (Fix.TERM_FIRE_JP, Fix.TERM_FIRE),
      (Fix.BUFF_HELLFIRE_JP, Fix.BUFF_HELLFIRE),
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC));
    Register(Fix.L10N_DESC_FREEZING_CUBE,
      "敵一体に対して【$0】ダメージを与える。加えて、敵フィールドに、【$1】のフィールドを形成する。\r\n【$1】が続く間、敵全体に対して毎ターン【$0】ダメージを与える。加えて【$0】属性の【$2】ダメージを食らう場合、20%増加された形でダメージを食らう。",
      "Deals [$0] damage to one enemy. In addition, forms a [$1] field on the enemy field.\r\nWhile [$1] lasts, all enemies take [$0] damage each turn. In addition, [$0] attribute [$2] damage they take is increased by 20%.",
      (Fix.TERM_ICE_JP, Fix.TERM_ICE),
      (Fix.BUFF_CRYSTAL_JP, Fix.BUFF_CRYSTAL),
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC));
    Register(Fix.L10N_DESC_ANGELIC_ECHO,
      "味方全員の$1を回復し、味方フィールドに【$0】のフィールドを形成する。【$0】が続く間、味方全体はターン経過毎に$1を回復し、負のBUFFを除去する。【$0】は味方全体のうちいずれかに負のBUFFが残っている場合はBUFFカウントが減少せず継続される。いずれにも負のBUFFが残ってない場合はBUFFカウントが減少する。",
      "Restores $1 for all allies and forms a [$0] field on the ally field. While [$0] lasts, all allies restore $1 each turn and have their negative buffs removed. While any ally still has a negative buff, the [$0] buff count does not decrease and it continues. Once none remain, the buff count decreases.",
      (Fix.BUFF_PRAISE_JP, Fix.BUFF_PRAISE),
      Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_DESC_CURSED_EVANGILE,
      "敵一体に対して【$0】ダメージを与える。加えて、【$1】を付与する。【$1】が続く間、ターンが経過するごとに【$2】【$3】【$4】のいずれかが付与される。【$2】【$3】【$4】が全て付与されている場合は、対象者に【$0】ダメージを与える。",
      "Deals [$0] damage to one enemy. In addition, applies [$1]. While [$1] lasts, one of [$2], [$3] or [$4] is applied each turn. If [$2], [$3] and [$4] are all applied, the target takes [$0] damage.",
      (Fix.TERM_DARK_JP, Fix.TERM_DARK),
      (Fix.BUFF_CURSE_JP, Fix.BUFF_CURSE),
      (Fix.EFFECT_BIND_JP, Fix.EFFECT_BIND),
      (Fix.EFFECT_SLIP_JP, Fix.EFFECT_SLIP),
      (Fix.EFFECT_SILENT_JP, Fix.EFFECT_SILENT));
    Register(Fix.L10N_DESC_GALE_WIND,
      "自分自身を対象とする。対象に【$0】のBUFFを付与する。\r\n【$0】の効果が続く間、コマンドを発動する際、連続で2回同じ行動を行う。",
      "Targets self. Applies [$0] to the target.\r\nWhile [$0] lasts, activating a command performs the same action 2 times consecutively.",
      (Fix.BUFF_CLONE_JP, Fix.BUFF_CLONE));
    Register(Fix.L10N_DESC_PHANTOM_OBORO,
      "自分自身に【$0】のBUFFを付与する。【$0】のBUFFがある間に、$1アクションからダメージを有する攻撃を受けた場合、そのダメージは0と見なされる。これはダメージ軽減の適用外である。",
      "Applies [$0] to self. While [$0] is active, damage taken from an $1 action is treated as 0. This is not subject to damage reduction.",
      (Fix.BUFF_OBORO_JP, Fix.BUFF_OBORO),
      Term(Fix.L10N_TIMING_INSTANT));
    // スキル
    Register(Fix.L10N_DESC_IRON_BUSTER,
      "このコマンドはカウンターされない。敵一体を対象とする。対象に【$0】ダメージを与える。加えて、周囲敵全体（対象となった敵以外）に対して【$0】ダメージを与える。",
      "This command cannot be countered. Targets one enemy. Deals [$0] damage to the target. In addition, deals [$0] damage to all surrounding enemies (other than the target).",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL));
    Register(Fix.L10N_DESC_DOMINATION_FIELD,
      "味方フィールドに【$0】のBUFFを形成する。【$0】が続く間、$1および$2が10%上昇する。また、各味方が【$3】姿勢を行っている場合のダメージ軽減率が20%上昇する。",
      "Forms [$0] on the ally field. While [$0] lasts, $1 and $2 increase by 10%. In addition, damage reduction while an ally is in a [$3] stance increases by 20%.",
      (Fix.BUFF_IRON_WALL_JP, Fix.BUFF_IRON_WALL),
      Term(Fix.L10N_PHYSICAL_DEFENSE),
      Term(Fix.L10N_MAGIC_DEFENSE),
      (Fix.DEFENSE_JP, Fix.DEFENSE));
    Register(Fix.L10N_DESC_DEADLY_DRIVE,
      "自分自身に【$0】のBUFFを付与する。【$0】が続く間、致死ダメージ（$1が0になる攻撃ダメージ）を受けた場合、$1が1で生き残る。この効果は$1が1以下の時は適用されない。また、$1が$2の30%以下であれば、$3が5%上昇、20%以下であれば10%上昇、10%以下であれば15%上昇する。",
      "Applies [$0] to self. While [$0] lasts, when you would take lethal damage (an attack that reduces $1 to 0), you survive with $1 at 1. This effect does not apply while $1 is 1 or less. In addition, while $1 is 30% or less of $2, $3 increases by 5%; at 20% or less, by 10%; at 10% or less, by 15%.",
      (Fix.BUFF_DESPERATION_JP, Fix.BUFF_DESPERATION),
      Term(Fix.L10N_BASIC_LIFE),
      Term(Fix.L10N_MAX_LIFE),
      Term(Fix.L10N_PHYSICAL_ATTACK));
    Register(Fix.L10N_DESC_PENETRATION_ARROW,
      "敵一体を対象とする。対象に【$0】ダメージを与える。対象が【$1】を行っていても、あたかも【$1】していないかのようにダメージを与える。このダメージは相手の$2に影響しない。加えて対象に【$3】のBUFFを付与する。【$3】が続く間、対象の$2が減少する。また、対象が行動する度に【$4】ダメージを与える。",
      "Targets one enemy. Deals [$0] damage to the target. Damage is dealt as though the target were not using [$1], even while it is. This damage is not affected by the target's $2. In addition, applies [$3] to the target. While [$3] lasts, the target's $2 is reduced. It also deals [$4] damage each time the target acts.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      (Fix.DEFENSE_JP, Fix.DEFENSE),
      Term(Fix.L10N_PHYSICAL_DEFENSE),
      (Fix.BUFF_SCAR_JP, Fix.BUFF_SCAR),
      (Fix.EFFECT_SLIP_JP, Fix.EFFECT_SLIP));
    Register(Fix.L10N_DESC_WILL_AWAKENING,
      "このコマンドはカウンターされない。\r\n味方一体を対象とする。対象に【$0】のBUFFを付与する。【$0】が続く間、$1タイミングのコマンドを$2タイミングで使用可能となる。また、発動コマンドがカウンターされなくなる。",
      "This command cannot be countered.\r\nTargets one ally. Applies [$0] to the target. While [$0] lasts, $1 timing commands can be used at $2 timing. In addition, the commands you activate can no longer be countered.",
      (Fix.BUFF_AWAKENING_JP, Fix.BUFF_AWAKENING),
      Term(Fix.L10N_TIMING_NORMAL),
      Term(Fix.L10N_TIMING_INSTANT));
    Register(Fix.L10N_DESC_CIRCLE_OF_SERENITY,
      "このコマンドは【$2】【$4】状態であっても発動する。この行動は即座に発揮され、打ち消されない。\r\n味方全体に対して【$1】【$2】【$3】【$4】【$5】【$6】【$7】【$8】【$9】のBUFFを解除し、味方フィールドに【$0】のフィールドを形成する。【$0】が続く間、【$1】【$2】【$3】【$4】【$5】【$6】【$7】【$8】【$9】のBUFFは付与されない。",
      "This command activates even while affected by [$2] or [$4]. It takes effect immediately and cannot be negated.\r\nRemoves [$1], [$2], [$3], [$4], [$5], [$6], [$7], [$8] and [$9] from all allies, and forms a [$0] field on the ally field. While [$0] lasts, [$1], [$2], [$3], [$4], [$5], [$6], [$7], [$8] and [$9] cannot be applied.",
      (Fix.BUFF_SERENITY_JP, Fix.BUFF_SERENITY),
      (Fix.EFFECT_SILENT_JP, Fix.EFFECT_SILENT),
      (Fix.EFFECT_BIND_JP, Fix.EFFECT_BIND),
      (Fix.EFFECT_SLEEP_JP, Fix.EFFECT_SLEEP),
      (Fix.EFFECT_STUN_JP, Fix.EFFECT_STUN),
      (Fix.EFFECT_PARALYZE_JP, Fix.EFFECT_PARALYZE),
      (Fix.EFFECT_FEAR_JP, Fix.EFFECT_FEAR),
      (Fix.EFFECT_TEMPTATION_JP, Fix.EFFECT_TEMPTATION),
      (Fix.EFFECT_SLOW_JP, Fix.EFFECT_SLOW),
      (Fix.EFFECT_DIZZY_JP, Fix.EFFECT_DIZZY));

    // ActionCommand説明文 - Delve V
    //
    // BUFF名の英訳について:
    //   【猛毒】【出血】【麻痺】は Fix.EFFECT_*、【防御】は Fix.DEFENSE、
    //   【第七原理】は既存の Fix.SEVENTH_PRINCIPLE(コマンド名)に準拠。
    //   【炎痕】[Scorch] 【凍傷】[Frostbite] 【祝福】[Blessing] 【荒廃】[Blight]
    //   【喪失】[Lapse] 【臨戦】[Battle Ready] 【常在】[Persistence] は
    //   既存の英訳定数が無いため新規に命名した。
    //   Lapse は「一時的な制御の途切れ」と「権利・能力の失効」の両義を持つ語であり、
    //   インスタント行動を開始できなくなる本効果と、原語「喪失」の双方に対応する。
    //   【見切り】[Mikiri] は英訳せずローマ字表記とする(Fix.BUFF_MIKIRI)。
    //
    // 魔法
    Register(Fix.L10N_DESC_FLAME_STRIKE,
      "敵一体に対して【$0】ダメージを与える。加えて、【$1】のBUFFを付与する。【$1】が続く間、対象に【$0】属性のダメージが与えられる場合、対象が【$2】の姿勢を取っていても、それを無視して【$0】ダメージが適用される。",
      "Deals [$0] damage to one enemy. In addition, applies [$1]. While [$1] lasts, [$0] attribute damage dealt to the target applies as [$0] damage even while the target is in a [$2] stance.",
      (Fix.TERM_FIRE_JP, Fix.TERM_FIRE),
      (Fix.BUFF_SCORCH_JP, Fix.BUFF_SCORCH),
      (Fix.DEFENSE_JP, Fix.DEFENSE));
    Register(Fix.L10N_DESC_FROST_LANCE,
      "敵一体に対して【$0】ダメージを与える。加えて、【$1】のBUFFを付与する。【$1】が続く間、対象が$2で行動を行った場合、その行動が失敗する。",
      "Deals [$0] damage to one enemy. In addition, applies [$1]. While [$1] lasts, any action the target takes at $2 timing fails.",
      (Fix.TERM_ICE_JP, Fix.TERM_ICE),
      (Fix.BUFF_FROSTBITE_JP, Fix.BUFF_FROSTBITE),
      Term(Fix.L10N_TIMING_INSTANT));
    Register(Fix.L10N_DESC_SHINING_HEAL,
      "味方一体を対象とする。対象の$1を全回復する。また、味方フィールドに【$0】のBUFFを付与する。【$0】の効果が続く間、【$2】【$3】の影響を受けない。",
      "Targets one ally. Fully restores the target's $1. In addition, applies [$0] to the ally field. While [$0] lasts, allies are unaffected by [$2] and [$3].",
      (Fix.BUFF_BLESSING_JP, Fix.BUFF_BLESSING),
      Term(Fix.L10N_BASIC_LIFE),
      (Fix.EFFECT_POISON_JP, Fix.EFFECT_POISON),
      (Fix.EFFECT_SLIP_JP, Fix.EFFECT_SLIP));
    Register(Fix.L10N_DESC_CIRCLE_OF_THE_DESPAIR,
      "敵フィールドに【$0】のフィールドを形成する。【$0】の効果が続く間、$1、$2、$3がそれぞれ20%減少する。",
      "Forms a [$0] field on the enemy field. While [$0] lasts, $1, $2 and $3 each decrease by 20%.",
      (Fix.BUFF_BLIGHT_JP, Fix.BUFF_BLIGHT),
      Term(Fix.L10N_PHYSICAL_DEFENSE),
      Term(Fix.L10N_MAGIC_DEFENSE),
      Term(Fix.L10N_BATTLE_RESPONSE));
    Register(Fix.L10N_DESC_SEVENTH_PRINCIPLE,
      "味方一体を対象とする。対象に【$0】のBUFFを付与する。【$0】が続く間、物理属性値の源を【$1】、魔法属性値の源を【$2】に転換する。",
      "Targets one ally. Applies [$0] to the target. While [$0] lasts, the source of physical attribute values becomes [$1] and the source of magic attribute values becomes [$2].",
      (Fix.SEVENTH_PRINCIPLE_JP, Fix.SEVENTH_PRINCIPLE),
      (Fix.TERM_INTELLIGENCE_JP, Fix.TERM_INTELLIGENCE),
      (Fix.TERM_STRENGTH_JP, Fix.TERM_STRENGTH));
    Register(Fix.L10N_DESC_COUNTER_DISALLOW,
      "$1限定。$1行動が行われた際、その$1行動を打ち消す。その後、対象に【$0】のBUFFを付与する。【$0】が続く間、対象は$1行動を開始する事ができない。また開始した場合、その行動をカウンターする。",
      "$1 only. When an $1 action is performed, that $1 action is negated. Afterwards, applies [$0] to the target. While [$0] lasts, the target cannot begin an $1 action. If it does begin one, that action is countered.",
      (Fix.BUFF_LAPSE_JP, Fix.BUFF_LAPSE),
      Term(Fix.L10N_TIMING_INSTANT));
    // スキル
    Register(Fix.L10N_DESC_RAGING_STORM,
      "敵全体に対して【$1】ダメージを2回連続で与える。加えて【$0】のフィールドを形成する。その後味方フィールドに【$0】のBUFFが続く間、味方から敵に与える【$1】および【$2】ダメージが10%上昇する。",
      "Deals [$1] damage 2 times consecutively to all enemies. In addition, forms a [$0] field. While [$0] then lasts on the ally field, [$1] and [$2] damage dealt by allies to enemies increases by 10%.",
      (Fix.BUFF_BATTLE_READY_JP, Fix.BUFF_BATTLE_READY),
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC));
    Register(Fix.L10N_DESC_HARDEST_PARRY,
      "$1限定。この行動は即座に発揮される。$1行動が行われた際、その行動を打ち消す。加えて、自分自身に【$0】のBUFFを付与する。【$0】が続く間、メイン行動からダメージを有する攻撃を受けた場合、そのダメージは0と見なされる。これはダメージ軽減の適用外である。",
      "$1 only. This action takes effect immediately. When an $1 action is performed, that action is negated. In addition, applies [$0] to self. While [$0] lasts, damage taken from a main action is treated as 0. This is not subject to damage reduction.",
      (Fix.BUFF_MIKIRI_JP, Fix.BUFF_MIKIRI),
      Term(Fix.L10N_TIMING_INSTANT));
    Register(Fix.L10N_DESC_UNINTENTIONAL_HIT,
      "敵一体に対して【$0】ダメージを与える。対象に【$1】のBUFFを付与する。また、自分の$2を20%進め、敵一体の$2を20%戻す。（$2が100%に達した場合は、$2は100%とする。$2が0%を下回る場合は$2は0%とする。）",
      "Deals [$0] damage to one enemy. Applies [$1] to the target. In addition, advances your own $2 by 20% and sets back one enemy's $2 by 20%. (If the $2 reaches 100%, it is capped at 100%. If it would fall below 0%, it is set to 0%.)",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      (Fix.EFFECT_PARALYZE_JP, Fix.EFFECT_PARALYZE),
      Term(Fix.L10N_ACTION_GAUGE));
    Register(Fix.L10N_DESC_PRECISION_STRIKE,
      "このコマンドはカウンターされない。$1限定。敵一体に対して【$0】ダメージを与える。本ダメージは必ずクリティカルヒットが適用される。",
      "This command cannot be countered. $1 only. Deals [$0] damage to one enemy. This damage is always a critical hit.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      Term(Fix.L10N_TIMING_INSTANT));
    Register(Fix.L10N_DESC_EVERFLOW_MIND,
      "味方一体に対して【$0】のBUFFを付与する。【$0】が続く間、$1行動を行った後、$2が全て消費されず、20%残った状態となる。",
      "Applies [$0] to one ally. While [$0] lasts, after taking an $1 action, the $2 is not fully consumed and 20% of it remains.",
      (Fix.BUFF_PERSISTENCE_JP, Fix.BUFF_PERSISTENCE),
      Term(Fix.L10N_TIMING_INSTANT),
      Term(Fix.L10N_INSTANT_GAUGE));
    Register(Fix.L10N_DESC_INNER_INSPIRATION,
      "味方一体を対象とする。対象の$0を回復する。",
      "Targets one ally. Restores the target's $0.",
      Term(Fix.L10N_SKILL_POINT));

    // ActionCommand説明文 - Delve VI
    //
    // BUFF名の英訳について:
    //   【聖痕】[Valkyrie Scar] 【暗黒精神】[Dark Spirit] 【凝視】[Focus Eye] は既存定数に準拠。
    //   【未来視】[Future Vision] 【無下】[Detachment] 【唯一円】[One Immunity]
    //   【超集中】[Hyperfocus] 【信仰】[Faith] 【炎輪】[Flame Ring] 【水脈】[Water Vein]
    //   【聖剣】[Holy Blade] は既存の _JP 側のみ存在していたため英訳を補った。
    //   【居合】[Iai] 【無音】[Muin] は英訳せずローマ字表記とする
    //   (コマンド名 Stance of the Iai / Stance of Muin に準拠)。
    //
    // 魔法
    Register(Fix.L10N_DESC_CIRCLE_OF_THE_IGNITE,
      "敵フィールドに対して【$0】のBUFFを付与する。\r\n【$0】が続く間、対象が通常攻撃を行うか、魔法を唱えるか、スキル行動を行うたびに、【$1】のダメージを与える。",
      "Applies [$0] to the enemy field.\r\nWhile [$0] lasts, each time a target makes a normal attack, casts a spell, or takes a skill action, it takes [$1] damage.",
      (Fix.BUFF_FLAME_RING_JP, Fix.BUFF_FLAME_RING),
      (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_DESC_WATER_PRESENCE,
      "味方一体を対象とする。対象に【$0】のBUFFを与える。\r\n【$0】が続く間、【$1】ダメージを受けた場合、そのダメージ量を軽減する。また、魔法を唱える際の消費コストが軽減される。",
      "Targets one ally. Applies [$0] to the target.\r\nWhile [$0] lasts, [$1] damage taken is reduced. In addition, the cost of casting spells is reduced.",
      (Fix.BUFF_WATER_VEIN_JP, Fix.BUFF_WATER_VEIN),
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC));
    Register(Fix.L10N_DESC_VALKYRIE_BLADE,
      "味方一体を対象とする。対象に【$0】のBUFFを付与する。\r\n【$0】が続く間、$3を行った場合、加えて【$1】の【$2】属性ダメージを与える。本効果によるダメージを受けた対象は【$4】のBUFFが付与される。【$4】が続く間、対象は$5回復を受けた場合、$5を回復することができない。",
      "Targets one ally. Applies [$0] to the target.\r\nWhile [$0] lasts, making a $3 also deals [$1] attribute [$2] damage. A target damaged by this effect is given [$4]. While [$4] lasts, the target cannot restore $5 even when $5 recovery is applied.",
      (Fix.BUFF_HOLY_BLADE_JP, Fix.BUFF_HOLY_BLADE),
      (Fix.TERM_HOLY_JP, Fix.TERM_HOLY),
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC),
      Term(Fix.L10N_PHYSICAL_ATTACK),
      (Fix.BUFF_VALKYRIE_SCAR_JP, Fix.BUFF_VALKYRIE_SCAR),
      Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_DESC_THE_DARK_INTENSITY,
      "味方一体を対象とする。対象の$1を半分に減らし、【$0】のBUFFを付与する。\r\n【$0】が続く間、ダメージを受ける度に累積カウンターが乗る。累積カウンターの分だけ$2、$3が上昇する。累積カウンターは最大9つまで乗る。",
      "Targets one ally. Halves the target's $1 and applies [$0].\r\nWhile [$0] lasts, a stack counter is added each time damage is taken. $2 and $3 increase according to the stack counter. The stack counter accumulates up to 9.",
      (Fix.BUFF_DARK_INTENSITY_JP, Fix.BUFF_DARK_INTENSITY),
      Term(Fix.L10N_BASIC_LIFE),
      Term(Fix.L10N_PHYSICAL_ATTACK),
      Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_DESC_FUTURE_VISION,
      "自分自身を対象として【$0】のBUFFを付与する。\r\n【$0】が続く間、敵陣営のいずれかが$1行動を行った場合、それをカウンターする。その後、本BUFFは消失する。",
      "Targets self and applies [$0].\r\nWhile [$0] lasts, if any enemy takes an $1 action, that action is countered. This buff then disappears.",
      (Fix.BUFF_FUTURE_VISION_JP, Fix.BUFF_FUTURE_VISION),
      Term(Fix.L10N_TIMING_INSTANT));
    Register(Fix.L10N_DESC_DETACHMENT_FAULT,
      "敵フィールドおよび味方フィールドに【$0】のフィールドを形成する。\r\n【$0】が続く間、単体およびフィールドに対してBUFFの追加／除去がされなくなる。ターン経過によるBUFF消滅は行われる。",
      "Forms a [$0] field on both the enemy field and the ally field.\r\nWhile [$0] lasts, buffs can no longer be added to or removed from individuals or fields. Buffs still expire as turns pass.",
      (Fix.BUFF_DETACHMENT_FAULT_JP, Fix.BUFF_DETACHMENT_FAULT));
    // スキル
    Register(Fix.L10N_DESC_STANCE_OF_THE_IAI,
      "自分自身に【$0】のBUFFを付与する。\r\n【$0】が続く間、$1が上昇する。相手から自分に対して【$2】ダメージを有する$3行動を行った場合、それをカウンターする。加えて、相手にクリティカルで【$2】ダメージを与える。その後、【$0】のBUFFは消失する。",
      "Applies [$0] to self.\r\nWhile [$0] lasts, $1 increases. If an opponent takes an $3 action that deals [$2] damage to you, that action is countered. In addition, you deal [$2] damage to that opponent as a critical hit. [$0] then disappears.",
      (Fix.BUFF_STANCE_OF_THE_IAI_JP, Fix.BUFF_STANCE_OF_THE_IAI),
      Term(Fix.L10N_BATTLE_RESPONSE),
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      Term(Fix.L10N_TIMING_INSTANT));
    Register(Fix.L10N_DESC_ONE_IMMUNITY,
      "自分自身を対象とし【$0】のBUFFを付与する。\r\n【$0】が続く間、自分自身へのダメージを全て軽減する。",
      "Targets self and applies [$0].\r\nWhile [$0] lasts, all damage dealt to you is reduced.",
      (Fix.BUFF_ONE_IMMUNITY_JP, Fix.BUFF_ONE_IMMUNITY));
    Register(Fix.L10N_DESC_STANCE_OF_MUIN,
      "自分自身に【$0】のBUFFを付与し、累積カウンターを5つ載せる。\r\n【$0】が続く間、BUFFを付与するアクションコマンドを受けた場合、BUFFが付与されず即座に消失し、累積カウンターが1つ除去される。これは負のBUFFのみ適用される。累積カウンターが無くなれば、このBUFFは除去される。",
      "Applies [$0] to self with 5 stack counters.\r\nWhile [$0] lasts, an action command that would apply a buff to you instead fails and disappears immediately, and 1 stack counter is removed. This applies only to negative buffs. When no stack counters remain, [$0] is removed.",
      (Fix.BUFF_STANCE_OF_MUIN_JP, Fix.BUFF_STANCE_OF_MUIN));
    Register(Fix.L10N_DESC_ETERNAL_CONCENTRATION,
      "自分自身に【$0】のBUFFを付与する。\r\n【$0】が続く間、ターン経過毎に攻撃対象へ【$1】のBUFFを付与し、累積カウンターを1つ載せる。自分自身から攻撃対象者へダメージを与えた場合、【$1】の累積カウンターの分だけ、被ダメージが上昇する。【$1】は負のBUFFとみなされない。累積カウンターは最大9つまで累積する。",
      "Applies [$0] to self.\r\nWhile [$0] lasts, each turn applies [$1] to your attack target and adds 1 stack counter. When you deal damage to that target, the damage it takes increases according to the [$1] stack counter. [$1] is not treated as a negative buff. The stack counter accumulates up to 9.",
      (Fix.BUFF_ETERNAL_CONCENTRATION_JP, Fix.BUFF_ETERNAL_CONCENTRATION),
      (Fix.BUFF_FOCUS_EYE_JP, Fix.BUFF_FOCUS_EYE));
    Register(Fix.L10N_DESC_SIGIL_OF_THE_FAITH,
      "味方フィールドに【$0】のBUFFを付与する。\r\n【$0】が続く間、$1、$2が上昇する。上昇した分だけ、$1、$2が回復する。ターン経過毎に、$3、$4が回復する。",
      "Applies [$0] to the ally field.\r\nWhile [$0] lasts, $1 and $2 increase, and $1 and $2 are restored by the amount they increased. $3 and $4 are also restored each turn.",
      (Fix.BUFF_SIGIL_OF_THE_FAITH_JP, Fix.BUFF_SIGIL_OF_THE_FAITH),
      Term(Fix.L10N_MAX_MANA),
      Term(Fix.L10N_MAX_SKILL_POINT),
      Term(Fix.L10N_BASIC_MANA_POINT),
      Term(Fix.L10N_SKILL_POINT));
    Register(Fix.L10N_DESC_ZERO_IMMUNITY,
      "$0限定。敵一体が発動中のスタック・コマンドをカウンターする。",
      "$0 only. Counters a stack command an enemy is activating.",
      Term(Fix.L10N_TIMING_INSTANT));

    // ActionCommand説明文 - Delve VII
    //
    // BUFF名の英訳について:
    //   【絶対零度】[Absolute Zero] 【死の鎌】[Death Scythe] 【致命傷】[Mortal Wound]
    //   【超越】[Transcendence] は既存の _JP 側のみ存在していたため英訳を補った。
    //   【致命傷】は防御姿勢を封じる効果で、【損傷】[Wound](物理攻撃低下)とは別物。
    //   【心得】[Kokoroe] は英訳せずローマ字表記とする
    //   (コマンド名 Stance of the Kokoroe に準拠)。
    //
    // 魔法
    Register(Fix.L10N_DESC_LAVA_ANNIHILATION,
      "敵全体に対して【$0】ダメージを与える。",
      "Deals [$0] damage to all enemies.",
      (Fix.TERM_FIRE_JP, Fix.TERM_FIRE));
    Register(Fix.L10N_DESC_ABSOLUTE_ZERO,
      "敵一体を対象とする。対象に【$0】のBUFFを付与する。【$0】が続く間、対象は通常攻撃、魔法詠唱、スキル行動が行えず、防御姿勢を取る事が出来なくなる。加えて、$1、$2、$3が回復不可となる。",
      "Targets one enemy. Applies [$0] to the target. While [$0] lasts, the target cannot make normal attacks, cast spells, or take skill actions, and cannot enter a defensive stance. In addition, $1, $2 and $3 cannot be restored.",
      (Fix.BUFF_ABSOLUTE_ZERO_JP, Fix.BUFF_ABSOLUTE_ZERO),
      Term(Fix.L10N_BASIC_LIFE),
      Term(Fix.L10N_BASIC_MANA_POINT),
      Term(Fix.L10N_SKILL_POINT));
    Register(Fix.L10N_DESC_RESURRECTION,
      "味方一体を対象とする。対象を蘇生し、$0を全回復する。",
      "Targets one ally. Revives the target and fully restores $0.",
      Term(Fix.L10N_BASIC_LIFE));
    Register(Fix.L10N_DESC_DEATH_SCYTHE,
      "敵フィールドに【$0】フィールドを形成する。\r\n【$0】が続く間、ターン経過毎に累積カウンターが1つ載る。ターン経過毎に$1のX % 分$2を失い、$3のX % 分$4を失い、$5のX % 分$6を失う。失う量は累積カウンターに依存する。フィールドに含まれるキャラクターがいずれか死亡した場合、本フィールドは消失する。累積カウンターは最大99まで累積する。",
      "Forms a [$0] field on the enemy field.\r\nWhile [$0] lasts, 1 stack counter is added each turn. Each turn, characters lose $2 equal to X % of $1, $4 equal to X % of $3, and $6 equal to X % of $5. The amount lost depends on the stack counter. If any character in the field dies, this field disappears. The stack counter accumulates up to 99.",
      (Fix.BUFF_DEATH_SCYTHE_JP, Fix.BUFF_DEATH_SCYTHE),
      Term(Fix.L10N_MAX_LIFE),
      Term(Fix.L10N_BASIC_LIFE),
      Term(Fix.L10N_MAX_MANA),
      Term(Fix.L10N_BASIC_MANA_POINT),
      Term(Fix.L10N_MAX_SKILL_POINT),
      Term(Fix.L10N_SKILL_POINT));
    Register(Fix.L10N_DESC_GENESIS,
      "この魔法は$0を消費しない。\r\n前回自分が行ったアクションコマンドと同じ内容を実行する。",
      "This spell does not consume $0.\r\nRepeats the same action command you performed last time.",
      Term(Fix.L10N_BASIC_MANA_POINT));
    Register(Fix.L10N_DESC_TIME_STOP,
      "時間を停止する。",
      "Stops time.");
    // スキル
    Register(Fix.L10N_DESC_KINETIC_SMASH,
      "敵一体を対象とする。対象に【$0】ダメージを与える。ダメージのコア・エッセンスは【$1】と【$2】を足し合わせた値を根源として算出される。",
      "Targets one enemy. Deals [$0] damage to the target. The core essence of the damage is derived from the sum of [$1] and [$2].",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      (Fix.TERM_STRENGTH_JP, Fix.TERM_STRENGTH),
      (Fix.TERM_INTELLIGENCE_JP, Fix.TERM_INTELLIGENCE));
    Register(Fix.L10N_DESC_CATASTROPHE,
      "敵一体を対象とする。対象の$1を0とみなした上で、【$0】ダメージを与える。",
      "Targets one enemy. Deals [$0] damage while treating the target's $1 as 0.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL),
      Term(Fix.L10N_PHYSICAL_DEFENSE));
    Register(Fix.L10N_DESC_CARNAGE_RUSH,
      "敵一体を対象とする。対象に【$0】ダメージを5回連続で与える。",
      "Targets one enemy. Deals [$0] damage to the target 5 times consecutively.",
      (Fix.TERM_PHYSICAL_JP, Fix.TERM_PHYSICAL));
    Register(Fix.L10N_DESC_PIERCING_ARROW,
      "敵一体を対象とする。対象が【$1】を行っていても、あたかも【$1】していないかのようにダメージを与える。対象に【$0】のBUFFを付与し、$2を0にする。【$0】が続く間、【$1】姿勢を取る事が出来ない。",
      "Targets one enemy. Damage is dealt as though the target were not using [$1], even while it is. Applies [$0] to the target and sets its $2 to 0. While [$0] lasts, the target cannot take a [$1] stance.",
      (Fix.BUFF_PIERCING_ARROW_JP, Fix.BUFF_PIERCING_ARROW),
      (Fix.DEFENSE_JP, Fix.DEFENSE),
      Term(Fix.L10N_INSTANT_GAUGE));
    Register(Fix.L10N_DESC_STANCE_OF_THE_KOKOROE,
      "自分自身を対象とする。対象に【$0】のBUFFを付与する。\r\n【$0】が続く間、$1または$2タイミングのコマンドを放つ場合、$3タイミングで行動する事が可能になる。",
      "Targets self. Applies [$0] to the target.\r\nWhile [$0] lasts, when releasing a command of $1 or $2 timing, you may act at $3 timing instead.",
      (Fix.BUFF_STANCE_OF_THE_KOKOROE_JP, Fix.BUFF_STANCE_OF_THE_KOKOROE),
      Term(Fix.L10N_TIMING_SORCERY),
      Term(Fix.L10N_TIMING_NORMAL),
      Term(Fix.L10N_TIMING_INSTANT));
    Register(Fix.L10N_DESC_TRANSCENDENCE_REACHED,
      "このコマンドはカウンターされない。味方一体を対象とする。対象の負のBUFFを全て除去し、【$0】のBUFFを付与する。【$0】が続く間、負のBUFFは付与されなくなり、正のBUFFは除去されなくなる。対象のスタック・コマンドに対してカウンターする効果が発動した場合、そのカウンターを無効化する。この効果は即時に適用される。",
      "This command cannot be countered. Targets one ally. Removes all negative buffs from the target and applies [$0]. While [$0] lasts, negative buffs cannot be applied and positive buffs cannot be removed. If an effect that would counter the target's stack command activates, that counter is nullified. This effect applies immediately.",
      (Fix.BUFF_TRANSCENDENCE_JP, Fix.BUFF_TRANSCENDENCE));

    // ActionCommand説明文 - Archetype (元核)
    //
    // BUFF名の英訳について:
    //   【集中と断絶】[Concentration and Severance] 【完全なる詠唱】[Perfect Incantation]
    //   【勝利を我が手に！】[Victory Is Mine!] 【悠久なる記憶】[Eternal Memory] を新規に命名した。
    //   いずれもキャラクター固有の元核コマンド名と同一であり、
    //   日本語表記は ARCHETYPE_*_1(ランタイム識別子)を唯一の定義として共有する。
    //
    //   Xは倍率を示す変数で、日本語・英語とも X のまま据え置く。
    Register(Fix.L10N_DESC_ARCHETYPE_EIN_1,
      "自分自身に【$0】のBUFFを付与する。本BUFFが付与された状態で、次にダメージを伴う行動を行った場合、そのダメージ量をX倍したうえで、クリティカルとしてダメージを与える。その時の行動はカウンターされない。その時のダメージは軽減対象とならない。Xは【$1】パラメタに依存する。行動完了後、本BUFFは消滅する。",
      "Applies [$0] to self. While this buff is applied, the next action that deals damage multiplies its damage by X and deals it as a critical hit. That action cannot be countered, and that damage is not subject to reduction. X depends on the [$1] parameter. This buff disappears once the action completes.",
      (Fix.BUFF_CONCENTRATION_SEVERANCE_JP, Fix.BUFF_CONCENTRATION_SEVERANCE),
      Term(Fix.L10N_POTENTIAL));
    Register(Fix.L10N_DESC_ARCHETYPE_LANA_1,
      "自分自身に【$0】のBUFFを付与する。本BUFFが付与された状態で、次にBUFF付与を伴う【$2】属性のコマンドを行った場合、そのBUFF付与がターン経過の制限がある場合、その値をX倍持続可能とする。そのBUFF付与が威力を示す値が含まれている場合、その値をX倍増幅した状態でBUFFが付与される。その時の魔法はカウンターされない。Xは【$1】パラメタに依存する。行動完了後、本BUFFは消滅する。",
      "Applies [$0] to self. While this buff is applied, when you next use a [$2] attribute command that grants a buff: if that buff has a turn limit, its duration lasts X times longer; if that buff carries a power value, the buff is granted with that value amplified X times. That spell cannot be countered. X depends on the [$1] parameter. This buff disappears once the action completes.",
      (Fix.BUFF_PERFECT_INCANTATION_JP, Fix.BUFF_PERFECT_INCANTATION),
      Term(Fix.L10N_POTENTIAL),
      (Fix.TERM_MAGIC_JP, Fix.TERM_MAGIC));
    Register(Fix.L10N_DESC_ARCHETYPE_BILLY_1,
      "自分自身に【$0】のBUFFを累積Xの状態で付与する。致死ダメージ（$2が0になる攻撃ダメージ）を受けた場合、累積Xを1つ消費して$2が1で生き残る。この効果は$2が1以下の時は適用されない。魔法を実行する時、$3消費コストが残り$3より大きい場合、累積Xを1つ消費して実行する。この効果は残り$3が1以下の時は適用されない。スキルを実行する時、$4消費コストが残り$4より大きい場合、累積Xを1つ消費して実行する。この効果は残り$4が1以下の時は適用されない。Xは【$1】パラメタに依存する。",
      "Applies [$0] to self with X stacks. When you would take lethal damage (an attack that reduces $2 to 0), 1 stack of X is consumed and you survive with $2 at 1. This effect does not apply while $2 is 1 or less. When casting a spell whose $3 cost exceeds your remaining $3, 1 stack of X is consumed and the spell is cast anyway. This effect does not apply while remaining $3 is 1 or less. When using a skill whose $4 cost exceeds your remaining $4, 1 stack of X is consumed and the skill is used anyway. This effect does not apply while remaining $4 is 1 or less. X depends on the [$1] parameter.",
      (Fix.BUFF_VICTORY_IS_MINE_JP, Fix.BUFF_VICTORY_IS_MINE),
      Term(Fix.L10N_POTENTIAL),
      Term(Fix.L10N_BASIC_LIFE),
      Term(Fix.L10N_BASIC_MANA_POINT),
      Term(Fix.L10N_BASIC_SKILL_POINT));
    Register(Fix.L10N_DESC_ARCHETYPE_ADEL_1,
      "自分自身に【$0】のBUFFを累積Xの状態で付与する。ターン終了時、累積Xを1つ消費して以下のいずれかのBUFFを付与する。【$2】【$3】【$4】【$5】【$6】上記全てが既に付与されている場合、以下のいずれかが発動する。※ターゲットは味方一体の場合は自分自身、敵一体の場合は先頭が対象となる。【$7】【$8】【$9】【$10】【$11】Xは【$1】パラメタに依存する。",
      "Applies [$0] to self with X stacks. At the end of each turn, 1 stack of X is consumed to grant one of the following buffs: [$2] [$3] [$4] [$5] [$6] If all of the above are already granted, one of the following activates instead. (Targets: for a single ally, yourself; for a single enemy, the front-most one.) [$7] [$8] [$9] [$10] [$11] X depends on the [$1] parameter.",
      (Fix.BUFF_ETERNAL_MEMORY_JP, Fix.BUFF_ETERNAL_MEMORY),
      Term(Fix.L10N_POTENTIAL),
      (Fix.TRUE_SIGHT_JP, Fix.TRUE_SIGHT),
      (Fix.SPIRITUAL_REST_JP, Fix.SPIRITUAL_REST),
      (Fix.BLACK_CONTRACT_JP, Fix.BLACK_CONTRACT),
      (Fix.GALE_WIND_JP, Fix.GALE_WIND),
      (Fix.EVERFLOW_MIND_JP, Fix.EVERFLOW_MIND),
      (Fix.ORACLE_COMMAND_JP, Fix.ORACLE_COMMAND),
      (Fix.FORTUNE_SPIRIT_JP, Fix.FORTUNE_SPIRIT),
      (Fix.WORD_OF_POWER_JP, Fix.WORD_OF_POWER),
      (Fix.PHANTOM_OBORO_JP, Fix.PHANTOM_OBORO),
      (Fix.FLAME_STRIKE_JP, Fix.FLAME_STRIKE));
  }

  /// <summary>
  /// 日英の対訳を登録する。
  ///
  /// terms を渡した場合、本文中の $0, $1 ... を対応する用語で置換してから登録する。
  /// 日本語文には ja 側、英語文には en 側が入るため、1つの用語ペアを渡すだけで
  /// 両言語の表記が同時に決まる。用語を Fix の定数ペアで渡すことにより、
  /// 定数のリネームや削除がコンパイルエラーとして検出される。
  ///
  ///   Register(Fix.L10N_DESC_LEG_STRIKE,
  ///     "... 【$0】のBUFFを付与する。",
  ///     "... applies [$0].",
  ///     (Fix.BUFF_SURGE_JP, Fix.BUFF_SURGE));
  ///
  /// $N は登録時に解決されるため、実行時引数用の {0} とは衝突しない。
  /// </summary>
  public static void Register(string key, string japanese, string english, params (string ja, string en)[] terms)
  {
    if (terms != null && terms.Length > 0)
    {
      // $1 が $10 の一部に誤ヒットしないよう、添字の大きい方から置換する。
      for (int ii = terms.Length - 1; ii >= 0; ii--)
      {
        string token = "$" + ii.ToString();
        japanese = japanese.Replace(token, terms[ii].ja);
        english = english.Replace(token, terms[ii].en);
      }
    }

    table[key] = (japanese, english);
  }

  /// <summary>
  /// 登録済みキーの日英ペアを、Register の用語ペア引数として取り出す。
  ///
  /// 戦闘能力値(戦闘速度/魔法防御/戦闘反応など)は L10N_BATTLE_SPEED のように
  /// 既に日英が登録済みであるため、Fix に別の定数ペアを起こすと二重定義になる。
  /// 説明文からはこのメソッド経由で既存の登録をそのまま参照する。
  ///
  ///   Register(Fix.L10N_DESC_ICE_NEEDLE, "... $2 が減少する。", "... the target's $2 is reduced.",
  ///     ..., Term(Fix.L10N_BATTLE_SPEED));
  ///
  /// 参照先は自分より前に Register 済みである必要がある。
  /// </summary>
  private static (string ja, string en) Term(string key)
  {
    if (table.TryGetValue(key, out var v)) { return v; }

    // 未登録キーを参照した場合、説明文にキー文字列がそのまま出てしまうため気付けるようにする。
    Debug.LogError("L10n.Term: 未登録のキーを参照しました key=" + key);
    return (key, key);
  }

  public static string Get(string key, params object[] args)
  {
    if (table.TryGetValue(key, out var v))
    {
      string baseText = (One.CONF.GameLanguage == (int)(One.GameLanguage.English)) ? v.en : v.ja;
      if (args != null && args.Length > 0)
      {
        try { return string.Format(baseText, args); }
        catch { return baseText; }
      }
      return baseText;
    }

    return string.Empty;
  }

  public static string Get_EN(string key, params object[] args)
  {
    if (table.TryGetValue(key, out var v))
    {
      string baseText = v.en;
      if (args != null && args.Length > 0)
      {
        try { return string.Format(baseText, args); }
        catch { return baseText; }
      }
      return baseText;
    }

    return string.Empty;
  }

  public static string GetDisplayName(string key)
  {
    if (string.IsNullOrEmpty(key)) { return string.Empty; }

    if (table.ContainsKey(key))
    {
      return Get(key);
    }

    if (One.CONF.GameLanguage != (int)(One.GameLanguage.English))
    {
      return key;
    }

    EnsureItemNameTable();
    if (itemNameTable.TryGetValue(key, out string english))
    {
      return english;
    }

    return key;
  }

  public static string GetItemName(string key)
  {
    return GetDisplayName(key);
  }

  public static string LocalizeGeneratedText(string text)
  {
    if (string.IsNullOrEmpty(text)) { return string.Empty; }
    if (One.CONF == null || One.CONF.GameLanguage != (int)(One.GameLanguage.English)) { return text; }

    string result = text.Replace("　", " ");

    string[][] replacements = new string[][]
    {
      new string[] { "味方フィールド", "Ally Field" },
      new string[] { "自分自身", "Self" },
      new string[] { "インスタント", "Instant" },
      new string[] { "なし", "None" },
      new string[] { "威力 ", "Power " },
      new string[] { "ライフの回復量 ", "Life Recovery " },
      new string[] { "ライフ回復量 ", "Life Recovery " },
      new string[] { "最大ライフの増加量 ", "Max Life Increase " },
      new string[] { "最大ライフ", "Max Life" },
      new string[] { "回復量 ", "Recovery " },
      new string[] { "増加量 ", "Increase " },
      new string[] { "継続ターン数 ", "Duration " },
      new string[] { "攻撃回数 ", "Attack Count " },
      new string[] { "累積カウンター数 ", "Stack Count " },
      new string[] { "ＭＰ消費 ", "MP Cost " },
      new string[] { "ＳＰ消費 ", "SP Cost " },
      new string[] { "自分の行動ゲージ進行率 ", "Own Action Gauge Advance " },
      new string[] { "敵の行動ゲージ後退率 ", "Enemy Action Delay " },
      new string[] { "物理防御を無視する量 ", "Physical Defense Ignored " },
      new string[] { "物理防御ＤＯＷＮ影響 ", "Physical Defense Down Effect " },
      new string[] { "対象へのダメージの威力 ", "Damage Power to Target " },
    };

    for (int ii = 0; ii < replacements.Length; ii++)
    {
      result = result.Replace(replacements[ii][0], replacements[ii][1]);
    }

    // 【タグ】 の置換は TermTags から生成する。定型句の置換より後に行うこと
    // ("追加【炎】の威力 " のように 【】 を内包する定型句を先に処理する必要があるため)。
    for (int ii = 0; ii < TermTags.Length; ii++)
    {
      result = result.Replace("【" + TermTags[ii].ja + "】", "[" + TermTags[ii].en + "]");
    }

    return result;
  }

  private static void EnsureItemNameTable()
  {
    if (itemNameTableReady) { return; }
    itemNameTableReady = true;

    // ---------------------------------------------------------------
    // Explicit JP→EN item name translations
    // Items whose field-name auto-generation produces Japanese-romanization
    // tokens or otherwise misleading English are registered here first.
    // The reflection loop below skips keys that are already present.
    // ---------------------------------------------------------------

    // --- Phase I-1: Esmilia Grassfield (weapons / accessories) ---
    itemNameTable[Fix.MUMYOU_BOW] = "Bow of Obscurity";
    itemNameTable[Fix.RED_PILLER_ORB] = "Flame Pillar Crystal";
    itemNameTable[Fix.MUIN_BOOK] = "Blank Grimoire";
    itemNameTable[Fix.HINJAKU_RING] = "Feeble Bangle";
    itemNameTable[Fix.USUYOGORETA_FEATHER] = "Grimy Feather Ornament";
    itemNameTable[Fix.KUKEI_BANGLE] = "Rectangular Bangle";
    itemNameTable[Fix.SUTERARESHI_EMBLEM] = "Forsaken Emblem";
    itemNameTable[Fix.SHAPED_FINGERRING] = "Well-Shaped Ring";

    // Copper bangles (COPPERRING_*)
    itemNameTable[Fix.COPPERRING_TIGER] = "Copper Bangle 'Tiger'";
    itemNameTable[Fix.COPPERRING_DORPHINE] = "Copper Bangle 'Dolphin'";
    itemNameTable[Fix.COPPERRING_HORSE] = "Copper Bangle 'Horse'";
    itemNameTable[Fix.COPPERRING_BEAR] = "Copper Bangle 'Bear'";
    itemNameTable[Fix.COPPERRING_HAYABUSA] = "Copper Bangle 'Falcon'";
    itemNameTable[Fix.COPPERRING_OCTOPUS] = "Copper Bangle 'Octopus'";
    itemNameTable[Fix.COPPERRING_RABBIT] = "Copper Bangle 'Rabbit'";
    itemNameTable[Fix.COPPERRING_SPIDER] = "Copper Bangle 'Spider'";
    itemNameTable[Fix.COPPERRING_DEER] = "Copper Bangle 'Deer'";
    itemNameTable[Fix.COPPERRING_ELEPHANT] = "Copper Bangle 'Elephant'";

    // --- Phase I-1: Anshet synthesis ---
    itemNameTable[Fix.KOUKAKU_ARMOR] = "Chitin Armor";

    // --- Phase I-2: Goratrum Cave ---
    itemNameTable[Fix.SEKISOUJU_ROD] = "Red Twin-Wielded Rod";
    itemNameTable[Fix.MADAN_SHOOTING_STAR] = "Magic Shot: Shooting Star";
    itemNameTable[Fix.HUANTEI_RING] = "Unstable Ring";
    itemNameTable[Fix.USED_HQ_BOOTS] = "Worn High-Quality Boots";

    // Bronze bangles (BRONZE_RING_*)
    itemNameTable[Fix.BRONZE_RING_KIBA] = "Bronze Bangle 'Fang'";
    itemNameTable[Fix.BRONZE_RING_SASU] = "Bronze Bangle 'Pierce'";
    itemNameTable[Fix.BRONZE_RING_KU] = "Bronze Bangle 'Run'";
    itemNameTable[Fix.BRONZE_RING_NAGURI] = "Bronze Bangle 'Strike'";
    itemNameTable[Fix.BRONZE_RING_TOBI] = "Bronze Bangle 'Fly'";
    itemNameTable[Fix.BRONZE_RING_KARAMU] = "Bronze Bangle 'Entwine'";
    itemNameTable[Fix.BRONZE_RING_HANERU] = "Bronze Bangle 'Leap'";
    itemNameTable[Fix.BRONZE_RING_TORU] = "Bronze Bangle 'Capture'";
    itemNameTable[Fix.BRONZE_RING_MIRU] = "Bronze Bangle 'See'";
    itemNameTable[Fix.BRONZE_RING_KATAI] = "Bronze Bangle 'Sturdy'";

    // Color brands
    itemNameTable[Fix.RED_KOKUIN] = "Red Brand";
    itemNameTable[Fix.BLUE_KOKUIN] = "Blue Brand";
    itemNameTable[Fix.PURPLE_KOKUIN] = "Purple Brand";
    itemNameTable[Fix.GREEN_KOKUIN] = "Green Brand";
    itemNameTable[Fix.YELLOW_KOKUIN] = "Yellow Brand";

    // Misc accessories (Goratrum)
    itemNameTable[Fix.CLEAN_HEARBAND] = "Clean Hair Band";
    itemNameTable[Fix.FIVECOLOR_COMPASS] = "Five-Color Compass";
    itemNameTable[Fix.BURIED_DANZAIANGEL_STATUE] = "Statue of the Buried Judgment Angel";
    itemNameTable[Fix.LIGHT_HAKURUANGEL_STATUE] = "Statue of the Radiant Jade Angel";

    // --- Phase I-2: Fazil synthesis ---
    itemNameTable[Fix.DENDO_DRILL_AXE] = "Electromagnetic Drill Axe";
    itemNameTable[Fix.TETRA_EYE_BIGROD] = "Tetra-Style Stacked-Eye Staff";

    // --- Phase II-1: Mystic Forest ---
    itemNameTable[Fix.ENSHOUTOU] = "Flame-Soaring Blade";

    // Junk talismans
    itemNameTable[Fix.JUNK_TARISMAN_POISON] = "Junk Talisman [Poison]";
    itemNameTable[Fix.JUNK_TARISMAN_SILENCE] = "Junk Talisman [Silence]";
    itemNameTable[Fix.JUNK_TARISMAN_BIND] = "Junk Talisman [Bind]";
    itemNameTable[Fix.JUNK_TARISMAN_SLEEP] = "Junk Talisman [Sleep]";
    itemNameTable[Fix.JUNK_TARISMAN_STUN] = "Junk Talisman [Stun]";
    itemNameTable[Fix.JUNK_TARISMAN_PARALYZE] = "Junk Talisman [Paralyze]";
    itemNameTable[Fix.JUNK_TARISMAN_FROZEN] = "Junk Talisman [Frozen]";
    itemNameTable[Fix.JUNK_TARISMAN_FEAR] = "Junk Talisman [Fear]";
    itemNameTable[Fix.JUNK_TARISMAN_TEMPTATION] = "Junk Talisman [Temptation]";
    itemNameTable[Fix.JUNK_TARISMAN_SLOW] = "Junk Talisman [Slow]";
    itemNameTable[Fix.JUNK_TARISMAN_DIZZY] = "Junk Talisman [Dizzy]";
    itemNameTable[Fix.JUNK_TARISMAN_SLIP] = "Junk Talisman [Bleed]";

    // Misc drop items (Mystic Forest)
    itemNameTable[Fix.SIHAIRYU_SIKOTU] = "Dragon Lord's Finger Bone";
    itemNameTable[Fix.OLDGLORY_TREE_KAREHA] = "Ancient Great Tree Dead Leaf";
    itemNameTable[Fix.GALEWIND_KONSEKI] = "Gale Wind's Trace";
    itemNameTable[Fix.SIN_CRYSTAL_KAKERA] = "Sin Crystal Fragment";
    itemNameTable[Fix.EVERMIND_ZANSHI] = "Ever-Mind Lingering Thought";

    // Misc accessories (Mystic Forest)
    itemNameTable[Fix.SPIRIT_TUNOBUE] = "Spirits' Horn Flute";
    itemNameTable[Fix.ENSEMBLE_FEATHER_HUT] = "Ensemble Feather Hat";
    itemNameTable[Fix.MEIUN_PRISM_BOX] = "Prism Box of Fate";
    itemNameTable[Fix.SQUARE_SINNEN] = "Square [Faith]";
    itemNameTable[Fix.SQUARE_BLESTAR] = "Square [Deliberation]";
    itemNameTable[Fix.SQUARE_CHISEI] = "Square [Wisdom]";
    itemNameTable[Fix.SQUARE_SENREN] = "Square [Refinement]";
    itemNameTable[Fix.SQUARE_SAIKI] = "Square [Brilliance]";
    itemNameTable[Fix.SQUARE_TANREN] = "Square [Tempering]";
    itemNameTable[Fix.SQUARE_KOKOH] = "Square [Solitude]";

    // --- Phase II-2: Tower of Ohran ---
    itemNameTable[Fix.KODAIEIJU_GREEN_LEAF] = "Ancient Great Tree Evergreen Leaf";
    itemNameTable[Fix.TYORENSOU_ZANKYO_LANCE] = "Twin-Butterfly Resonance Lance";

    // Magic stones
    itemNameTable[Fix.RED_MASEKI] = "Red Magic Stone";
    itemNameTable[Fix.BLUE_MASEKI] = "Blue Magic Stone";
    itemNameTable[Fix.PURPLE_MASEKI] = "Purple Magic Stone";
    itemNameTable[Fix.GREEN_MASEKI] = "Green Magic Stone";
    itemNameTable[Fix.YELLOW_MASEKI] = "Yellow Magic Stone";

    // Misc accessories (Tower of Ohran)
    itemNameTable[Fix.STARAIR_FLOATING_STONE] = "Starry Sky Floating Stone";
    itemNameTable[Fix.LIGHTBRIGHT_FLOATING_STONE] = "Holy Light Floating Stone";

    // --- Phase III-1: Velgus Sea Temple ---
    itemNameTable[Fix.STRONG_FIRE_HELL_BASTARDAXE] = "Forged Flame Hell Bastard Axe";
    itemNameTable[Fix.GOLDWILL_DESCENT_SOWRD] = "Gold Will Descent Sword";

    // Silver bangles (SILVER_RING_*)
    itemNameTable[Fix.SILVER_RING_GOUKA] = "Silver Bangle [Hellfire]";
    itemNameTable[Fix.SILVER_RING_TSUNAMI] = "Silver Bangle [Tsunami]";
    itemNameTable[Fix.SILVER_RING_AKISAME] = "Silver Bangle [Autumn Rain]";
    itemNameTable[Fix.SILVER_RING_NEPPA] = "Silver Bangle [Heat Wave]";
    itemNameTable[Fix.SILVER_RING_RAIMEI] = "Silver Bangle [Thunder]";
    itemNameTable[Fix.SILVER_RING_FUBUKI] = "Silver Bangle [Blizzard]";
    itemNameTable[Fix.SILVER_RING_GENJITSU] = "Silver Bangle [Parhelion]";
    itemNameTable[Fix.SILVER_RING_TATSUMAKI] = "Silver Bangle [Tornado]";
    itemNameTable[Fix.SILVER_RING_SYUNIJI] = "Silver Bangle [Primary Rainbow]";
    itemNameTable[Fix.SILVER_RING_KAGEROU] = "Silver Bangle [Heat Shimmer]";

    // Brillistones
    itemNameTable[Fix.REDLIGHT_BRIGHTSTONE] = "Red-Light Brillistone";
    itemNameTable[Fix.BLUELIGHT_BRIGHTSTONE] = "Blue-Light Brillistone";
    itemNameTable[Fix.PURPLELIGHT_BRIGHTSTONE] = "Purple-Light Brillistone";
    itemNameTable[Fix.GREENLIGHT_BRIGHTSTONE] = "Green-Light Brillistone";
    itemNameTable[Fix.YELLOWLIGHT_BRIGHTSTONE] = "Yellow-Light Brillistone";

    // Misc accessories (Velgus)
    itemNameTable[Fix.ANGEL_CONTRACT_SHEET] = "Angel's Contract";

    // --- Palmetysia synthesis ---
    itemNameTable[Fix.HATENA_BIG_BOX] = "Mystery Big Box";

    // --- Phase IV-2: Edelgarzen Castle ---
    itemNameTable[Fix.SHINGETSUEN_CLAW] = "Deep Moon Abyss Claw";
    itemNameTable[Fix.JUNKEI_SHIKI_BOOK] = "Pure Vista Four Seasons Book";
    itemNameTable[Fix.SYOKO_PALESTRIDE_BOW] = "Dawn Pale-Stride Bow";
    itemNameTable[Fix.SHISO_GENSUI_KING_CROSS] = "Founding Marshal's Garb [Royal]";
    itemNameTable[Fix.DANZAI_ANGEL_TALISMAN] = "Judgment Angel's Talisman";

    // Platinum bangles (PLATINUM_RING_*)
    itemNameTable[Fix.PLATINUM_RING_1] = "Platinum Bangle [White Tiger]";
    itemNameTable[Fix.PLATINUM_RING_2] = "Platinum Bangle [Valkyrie]";
    itemNameTable[Fix.PLATINUM_RING_3] = "Platinum Bangle [Nightmare]";
    itemNameTable[Fix.PLATINUM_RING_4] = "Platinum Bangle [Narasimha]";
    itemNameTable[Fix.PLATINUM_RING_5] = "Platinum Bangle [Vermilion Bird]";
    itemNameTable[Fix.PLATINUM_RING_6] = "Platinum Bangle [Ouroboros]";
    itemNameTable[Fix.PLATINUM_RING_7] = "Platinum Bangle [Nine-Tails]";
    itemNameTable[Fix.PLATINUM_RING_8] = "Platinum Bangle [Behemoth]";
    itemNameTable[Fix.PLATINUM_RING_9] = "Platinum Bangle [Azure Dragon]";
    itemNameTable[Fix.PLATINUM_RING_10] = "Platinum Bangle [Black Tortoise]";

    // Misc accessories (Edelgarzen)
    itemNameTable[Fix.DARKNESS_COIN] = "Dark Currency";
    itemNameTable[Fix.BLACK_DRAGON_FEATHER] = "Black Wing Dragon's Feather";

    // --- Quest / key items ---
    itemNameTable[Fix.ITEM_MATOCK] = "Mattock";
    itemNameTable[Fix.ITEM_TOOMI_AOSUISYOU] = "Far-Seeing Blue Crystal";
    itemNameTable[Fix.ITEM_WALKING_ROPE] = "Tightrope";
    itemNameTable[Fix.ITEM_COPPER_KEY] = "Copper Key";
    itemNameTable[Fix.PURE_SINSEISUI] = "Holy Water";
    itemNameTable[Fix.PURE_VITALIRY_WATER] = "Vitality Water";
    itemNameTable[Fix.KODAIEIJU_EDA] = "Ancient Great Tree Branch";
    itemNameTable[Fix.KIGAN_OFUDA] = "Prayer Talisman";
    itemNameTable[Fix.VELGUS_KEY1] = "Velgus Sea Temple Key [1]";
    itemNameTable[Fix.VELGUS_KEY2] = "Velgus Sea Temple Key [2]";
    itemNameTable[Fix.VELGUS_KEY3] = "Velgus Sea Temple Key [3]";
    itemNameTable[Fix.VELGUS2_KEY1] = "Velgus Sea Temple Key [Stillness]";
    itemNameTable[Fix.VELGUS2_KEY2] = "Velgus Sea Temple Key [Sprint]";
    itemNameTable[Fix.VELGUS2_KEY3] = "Velgus Sea Temple Key [Adaptation]";
    itemNameTable[Fix.EDELGARZEN_KEY] = "Edelgarzen Castle: Front Gate Key";
    itemNameTable[Fix.EDELGARZEN_KEY1] = "Edelgarzen Castle Key [Tenacity]";
    itemNameTable[Fix.EDELGARZEN_KEY2] = "Edelgarzen Castle Key [Will]";
    itemNameTable[Fix.EDELGARZEN_KEY3] = "Edelgarzen Castle Key [Non-Action]";
    itemNameTable[Fix.EDELGARZEN_KEY4] = "Edelgarzen Castle Key [Omniscience]";
    itemNameTable[Fix.ZEMULGEARS] = "Supreme Blade: Zemulgears";
    itemNameTable[Fix.ARTIFACT_GENSEI] = "Ancient Orb: Integrity";
    itemNameTable[Fix.ARTIFACT_ZIHI] = "Ancient Orb: Mercy";
    itemNameTable[Fix.ARTIFACT_MUSOU] = "Ancient Orb: Peerless";
    itemNameTable[Fix.LEGENDARY_FELTUS] = "Divine Blade: Feltusch";

    // --- Potions ---
    itemNameTable[Fix.TOTAL_HIYAKU_KASSEI] = "Composite Elixir [Activation]";
    itemNameTable[Fix.TOTAL_HIYAKU_JOUSEI] = "Composite Elixir [Purification]";
    itemNameTable[Fix.SOUKAI_DRINK_SS] = "Refreshing Drink [S&S]";
    itemNameTable[Fix.TUUKAI_DRINK_DD] = "Exhilarating Drink [D&D]";
    itemNameTable[Fix.GOD_YORISHIRO_SOSEI] = "God's Vessel [Resurrection]";
    itemNameTable[Fix.TRADITIONAL_POTION_DATTOU] = "Traditional Elixir [Escape]";
    itemNameTable[Fix.TRADITIONAL_POTION_HEIGAN] = "Traditional Elixir [Closed Eyes]";
    itemNameTable[Fix.TEN_ON_MORI_MEGUMI] = "Heaven's Grace, Forest's Blessing";
    itemNameTable[Fix.KINDAN_TOKKOUYAKU] = "Forbidden Special Medicine";
    itemNameTable[Fix.SOUIN_HIYAKU_DISENCHANT] = "Monastery Elixir [Dispel]";

    // --- Material drop items ---
    itemNameTable[Fix.COMMON_MANTIS_TAIEKI] = "Mantis Fluid";
    itemNameTable[Fix.COMMON_GREEN_SIKISO] = "Green Pigment";
    itemNameTable[Fix.COMMON_KOKYU_LETHER_MATERIAL] = "Kokyuu Leather Material";
    itemNameTable[Fix.COMMON_KATAME_TREE] = "Solid Wood Branch";
    itemNameTable[Fix.COMMON_WARM_NO_KOUKAKU] = "Worm Carapace";
    itemNameTable[Fix.COMMON_YELLOW_TAIEKI] = "Yellow Bodily Fluid";
    itemNameTable[Fix.COMMON_TOGETOGE_GRASS] = "Prickly Grass";
    itemNameTable[Fix.COMMON_RED_HOUSI] = "Red Spore";
    itemNameTable[Fix.COMMON_DOKUSO_NEEDLE] = "Poison-Component Needle";
    itemNameTable[Fix.COMMON_HORSE_HIZUME] = "Horse Hoof";
    itemNameTable[Fix.COMMON_COLORFUL_BALL] = "Chromatic Ball";
    itemNameTable[Fix.COMMON_SHARP_HAHEN] = "Sharp Fragment";
    itemNameTable[Fix.COMMON_NEBARIKE_EKITAI] = "Viscous Liquid";
    itemNameTable[Fix.COMMON_USUGATA_ENBAN] = "Thin Disk";
    itemNameTable[Fix.COMMON_HASSYADAI] = "Launch Platform";
    itemNameTable[Fix.COMMON_KYOUTEN_X] = "Scripture X";
    itemNameTable[Fix.COMMON_BUYOBUYO_MOEKASU] = "Soggy Ash Residue";
    itemNameTable[Fix.COMMON_BAKUHA_CHAKKAZAI] = "Explosive Igniter";
    itemNameTable[Fix.COMMON_SEKKAIKOU] = "Limestone Ore";
    itemNameTable[Fix.COMMON_SANKAKU_STEEL] = "Triangular Steel";
    itemNameTable[Fix.COMMON_PURPLE_BOTTOLE] = "Purple Vial";
    itemNameTable[Fix.COMMON_BOAR_MOMONIKU] = "Boar Thigh Meat";
    itemNameTable[Fix.COMMON_SNAKE_EMPTYSHELL] = "Snake Shed Skin";
    itemNameTable[Fix.COMMON_DRYAD_RINPUN] = "Dryad Scale Powder";
    itemNameTable[Fix.COMMON_ELEMENTAL_KONA] = "Spirit Powder";
    itemNameTable[Fix.COMMON_DORO_YOUKAIEKI] = "Thick Corrosive Liquid";
    itemNameTable[Fix.COMMON_YOUKAI_MIKI] = "Aura-Wreathed Trunk";
    itemNameTable[Fix.COMMON_DANPEN_OF_GOFU] = "Talisman Scrap";
    itemNameTable[Fix.COMMON_GOTUGOTU_BIGTREE] = "Rugged Large Tree";
    itemNameTable[Fix.COMMON_HUGE_HOHONIKU] = "Large Cheek Meat";
    itemNameTable[Fix.COMMON_THREE_FEATHER] = "Three-Blade Feather";
    itemNameTable[Fix.COMMON_YELLOW_DOROTSUCHI] = "Yellow Muddy Soil";
    itemNameTable[Fix.COMMON_RED_DOROTSUCHI] = "Red Muddy Soil";
    itemNameTable[Fix.COMMON_AIRORIGIN_KIHO] = "Void-Origin Air Bubble";
    itemNameTable[Fix.COMMON_HENSYOKU_KOKE] = "Discolored Moss";
    itemNameTable[Fix.COMMON_KIRAMEKU_GOLDHORN] = "Gleaming Golden Horn";
    itemNameTable[Fix.COMMON_BIRD_OUGI] = "Bird Fan";
    itemNameTable[Fix.COMMON_MEGANE_MATERIAL] = "Scholar's Glasses Material";
    itemNameTable[Fix.COMMON_KITSUNE_TAIL] = "Fox Tail";
    itemNameTable[Fix.COMMON_WHITE_HIDUME] = "White Hoof";
    itemNameTable[Fix.COMMON_TOUMEI_KESSYO] = "Colorless Crystal";
    itemNameTable[Fix.COMMON_MUKAKOU_SEKIEI] = "Unprocessed Quartz";
    itemNameTable[Fix.COMMON_HOUDAN_SHARD] = "Cannonball Fragment";
    itemNameTable[Fix.COMMON_DAGGERFISH_UROKO] = "Daggerfish Scale";
    itemNameTable[Fix.COMMON_MANTA_HARA] = "Manta Belly";
    itemNameTable[Fix.COMMON_BLUE_MAGATAMA] = "Blue Magatama";
    itemNameTable[Fix.COMMON_KURIONE_ZOUMOTU] = "Clione Innards";
    itemNameTable[Fix.COMMON_RENEW_AKAMI] = "Fresh Red Meat";
    itemNameTable[Fix.COMMON_ROSE_SEKKAI] = "Rose Limestone";
    itemNameTable[Fix.COMMON_WASI_BLUE_FEATHER] = "Eagle's Blue Feather";
    itemNameTable[Fix.COMMON_HANTOUMEI_ROCK] = "Semi-Transparent Pretty Stone";
    itemNameTable[Fix.COMMON_EIGHTEIGHT_KUROSUMI] = "Eight-Eight's Black Ink";
    itemNameTable[Fix.COMMON_BLACK_GESO] = "Blackened Squid Tentacle";
    itemNameTable[Fix.COMMON_BIGAXE_TOP] = "Tip of Giant Axe";
    itemNameTable[Fix.COMMON_GANGAME_EGG] = "Hardy Tortoise Egg";
    itemNameTable[Fix.COMMON_KYOZIN_MUNENIKU] = "Resilient Breast Meat";
    itemNameTable[Fix.COMMON_NANAIRO_SYOKUSYU] = "Seven-Colored Tentacle";
    itemNameTable[Fix.COMMON_SEA_MO] = "Deep-Sea Seaweed";
    itemNameTable[Fix.COMMON_SERPENT_UROKO] = "Serpent Scale";
    itemNameTable[Fix.COMMON_AYASHII_NENNEKI_ITO] = "Suspicious Viscous Thread";
    itemNameTable[Fix.COMMON_GOTUGOTU_KARA] = "Rugged Shell";
    itemNameTable[Fix.COMMON_SOFT_BIG_HIRE] = "Soft Large Fin";
    itemNameTable[Fix.COMMON_TAIRYO_FISH] = "Large School of Fish";
    itemNameTable[Fix.COMMON_PUREWHITE_KIMO] = "Pure White Liver";
    itemNameTable[Fix.COMMON_SHRIMP_DOTAI] = "Shrimp Body";
    itemNameTable[Fix.COMMON_KOUSITUKA_MATERIAL] = "Hardened Material";
    itemNameTable[Fix.COMMON_AOSAME_UROKO] = "Blue Shark Scale";
    itemNameTable[Fix.COMMON_EMBLEM_KNIGHT] = "Knights' Emblem";
    itemNameTable[Fix.COMMON_BLACKSAME_TOOTH] = "Black Shark Sword-Tooth";
    itemNameTable[Fix.COMMON_MYSTERIOUS_KARA] = "Mysteriously-Shaped Shell";
    itemNameTable[Fix.COMMON_CURSED_ITO] = "Cursed Thread";
    itemNameTable[Fix.COMMON_CHINMI_FISH] = "Exotic Seafood";
    itemNameTable[Fix.COMMON_HUNTER_SEVEN_TOOL] = "Hunter's Seven Tools";
    itemNameTable[Fix.COMMON_BEAST_KEGAWA] = "Wild Beast Hide";
    itemNameTable[Fix.RARE_BLOOD_DAGGER_KAKERA] = "Bloodstained Dagger Fragment";
    itemNameTable[Fix.COMMON_SABI_BUGU] = "Rusted Junk Weapon";
    itemNameTable[Fix.COMMON_STEAM_POMP] = "Steam Pump";
    itemNameTable[Fix.COMMON_GOUKIN_MATERIAL] = "Alloy Material";
    itemNameTable[Fix.COMMON_KUMITATE_TENBIN_DOU] = "Assembly Material: Scale Weight";
    itemNameTable[Fix.COMMON_ONRYOU_HAKO] = "Vengeful Spirit Box";
    itemNameTable[Fix.RARE_CHAOS_SIZUKU] = "Chaos Drop";
    itemNameTable[Fix.RARE_DOOMBRINGER_KAKERA] = "Doombringer Fragment";
    itemNameTable[Fix.COMMON_KOKU_THUNDER_SIRUSI] = "Engraved Thunder Mark";
    itemNameTable[Fix.COMMON_TENNEN_JISYAKU] = "Natural Magnet";
    itemNameTable[Fix.COMMON_VOID_BOU] = "Void Staff";
    itemNameTable[Fix.COMMON_JUNKAN_MAHU_GU] = "Circular Magic Sealing Tool";

    // --- Practice weapons ---
    itemNameTable[Fix.PRACTICE_SWORD] = "Practice Sword";
    itemNameTable[Fix.PRACTICE_LANCE] = "Practice Lance";
    itemNameTable[Fix.PRACTICE_AXE] = "Practice Axe";
    itemNameTable[Fix.PRACTICE_CLAW] = "Practice Claw";
    itemNameTable[Fix.PRACTICE_ROD] = "Practice Rod";
    itemNameTable[Fix.PRACTICE_BOOK] = "Practice Book";
    itemNameTable[Fix.PRACTICE_ORB] = "Practice Orb";
    itemNameTable[Fix.PRACTICE_SHIELD] = "Practice Shield";

    // --- Fine series ---
    itemNameTable[Fix.FINE_SWORD] = "Fine Sword";
    itemNameTable[Fix.FINE_LANCE] = "Fine Lance";
    itemNameTable[Fix.FINE_AXE] = "Fine Axe";
    itemNameTable[Fix.FINE_CLAW] = "Fine Claw";
    itemNameTable[Fix.FINE_ROD] = "Fine Rod";
    itemNameTable[Fix.FINE_BOOK] = "Fine Book";
    itemNameTable[Fix.FINE_ORB] = "Fine Orb";
    itemNameTable[Fix.FINE_LARGE_SWORD] = "Fine Greatsword";
    itemNameTable[Fix.FINE_LARGE_LANCE] = "Fine Grand Lance";
    itemNameTable[Fix.FINE_LARGE_AXE] = "Fine Grand Axe";
    itemNameTable[Fix.FINE_BOW] = "Fine Bow";
    itemNameTable[Fix.FINE_LARGE_STAFF] = "Fine Grand Staff";
    itemNameTable[Fix.FINE_SHIELD] = "Fine Shield";
    itemNameTable[Fix.FINE_ARMOR] = "Fine Armor";
    itemNameTable[Fix.FINE_CROSS] = "Fine Cross";
    itemNameTable[Fix.FINE_ROBE] = "Fine Robe";

    // --- Basic armor types ---
    itemNameTable[Fix.HEAVY_ARMOR] = "Heavy Armor";
    itemNameTable[Fix.LEATHER_CROSS] = "Leather Cross";
    itemNameTable[Fix.COTTON_ROBE] = "Cotton Robe";

    // --- Named early-game weapons and armor ---
    itemNameTable[Fix.SURVIVAL_CLAW] = "Survival Claw";
    itemNameTable[Fix.RISING_FORCE_CLAW] = "Rising Force Claw";
    itemNameTable[Fix.LIGHTNING_CLAW] = "Lightning Claw";
    itemNameTable[Fix.BRONZE_SWORD] = "Bronze Sword";
    itemNameTable[Fix.SWORD_OF_LIFE] = "Sword of Life";
    itemNameTable[Fix.AERO_BLADE] = "Gale Wind Blade";
    itemNameTable[Fix.SHARP_LANCE] = "Sharp Lance";
    itemNameTable[Fix.WHITE_PARGE_LANCE] = "White Purge Lance";
    itemNameTable[Fix.ICE_SPIRIT_LANCE] = "Ice Soul Lance";
    itemNameTable[Fix.ICICLE_LONGBOW] = "Icicle Longbow";
    itemNameTable[Fix.VIKING_AXE] = "Viking Axe";
    itemNameTable[Fix.EARTH_POWER_AXE] = "Earth Power Axe";
    itemNameTable[Fix.WARWOLF_AXE] = "Warwolf Axe";
    itemNameTable[Fix.ENERGY_ORB] = "Energy Orb";
    itemNameTable[Fix.LIVING_GROWTH_ORB] = "Living Growth Orb";
    itemNameTable[Fix.WOOD_ROD] = "Wood Rod";
    itemNameTable[Fix.TOUGH_TREE_ROD] = "Sturdy Oak Rod";
    itemNameTable[Fix.BLACK_SORCERER_ROD] = "Black Sorcerer's Rod";
    itemNameTable[Fix.KINDNESS_BOOK] = "Kindness Book";
    itemNameTable[Fix.SAINT_FAITHFUL_BOOK] = "Saint's Faithful Book";
    itemNameTable[Fix.KITE_SHIELD] = "Kite Shield";
    itemNameTable[Fix.SUPERIOR_FLAME_SHIELD] = "Superior Flame Shield";
    itemNameTable[Fix.BEGINNER_ARMOR] = "Novice's Armor";
    itemNameTable[Fix.BEGINNER_CROSS] = "Novice's Dance Garb";
    itemNameTable[Fix.BEGINNER_ROBE] = "Novice's Robe";

    // --- Early accessories ---
    itemNameTable[Fix.NON_BRIGHT_ORB] = "Dull Round Orb";
    itemNameTable[Fix.ADJUSTABLE_BELT] = "Adjusted Belt";
    itemNameTable[Fix.BIRD_STATUE] = "Bird Statue";
    itemNameTable[Fix.REFRESHED_MANTLE] = "Refreshing Mantle";
    itemNameTable[Fix.COOL_CROWN] = "Distinguished Crown";
    itemNameTable[Fix.FLAT_SHOES] = "Flat Shoes";
    itemNameTable[Fix.AETHER_BALL] = "Aether Ball";
    itemNameTable[Fix.COMPACT_EARRING] = "Compact Earring";
    itemNameTable[Fix.POWER_BANDANA] = "Power Bandana";
    itemNameTable[Fix.CHERRY_CHOKER] = "Cherry Choker";
    itemNameTable[Fix.FIT_BANGLE] = "Fit Bangle";
    itemNameTable[Fix.PRISM_EMBLEM] = "Prism Emblem";
    itemNameTable[Fix.RED_PENDANT] = "Red Pendant";
    itemNameTable[Fix.BLUE_PENDANT] = "Blue Pendant";
    itemNameTable[Fix.PURPLE_PENDANT] = "Purple Pendant";
    itemNameTable[Fix.GREEN_PENDANT] = "Green Pendant";
    itemNameTable[Fix.YELLOW_PENDANT] = "Yellow Pendant";
    itemNameTable[Fix.WARRIOR_BRACER] = "Warrior Bracer";
    itemNameTable[Fix.STARDUST_CHARM] = "Stardust Charm";
    itemNameTable[Fix.BOLT_STONE] = "Lightning Stone";
    itemNameTable[Fix.ANTIDOTE_STONE] = "Antidote Stone";
    itemNameTable[Fix.SPIRIT_BRANCH] = "Spirit Branch";
    itemNameTable[Fix.BLUE_WIZARD_HAT] = "Blue Wizard Hat";
    itemNameTable[Fix.FLAME_HAND_KEEPER] = "Flame Hand Keeper";
    itemNameTable[Fix.WOLF_CROSS] = "Wolf-Crafted Dance Garb";
    itemNameTable[Fix.STRIDE_WAR_SWORD] = "Stride War Sword";

    // --- Classical series ---
    itemNameTable[Fix.CLASSICAL_SWORD] = "Classical Sword";
    itemNameTable[Fix.CLASSICAL_LANCE] = "Classical Lance";
    itemNameTable[Fix.CLASSICAL_AXE] = "Classical Axe";
    itemNameTable[Fix.CLASSICAL_CLAW] = "Classical Claw";
    itemNameTable[Fix.CLASSICAL_ROD] = "Classical Rod";
    itemNameTable[Fix.CLASSICAL_BOOK] = "Classical Book";
    itemNameTable[Fix.CLASSICAL_ORB] = "Classical Orb";
    itemNameTable[Fix.CLASSICAL_LARGE_SWORD] = "Classical Greatsword";
    itemNameTable[Fix.CLASSICAL_LARGE_LANCE] = "Classical Grand Lance";
    itemNameTable[Fix.CLASSICAL_LARGE_AXE] = "Classical Grand Axe";
    itemNameTable[Fix.CLASSICAL_BOW] = "Classical Bow";
    itemNameTable[Fix.CLASSICAL_LARGE_STAFF] = "Classical Grand Staff";
    itemNameTable[Fix.CLASSICAL_SHIELD] = "Classical Shield";
    itemNameTable[Fix.CLASSICAL_ARMOR] = "Classical Armor";
    itemNameTable[Fix.CLASSICAL_CROSS] = "Classical Cross";
    itemNameTable[Fix.CLASSICAL_ROBE] = "Classical Robe";

    // --- Named mid-tier weapons and armor ---
    itemNameTable[Fix.SMASH_BLADE] = "Smash Blade";
    itemNameTable[Fix.STYLISH_LANCE] = "Stylish Lance";
    itemNameTable[Fix.LAND_AXE] = "Land Axe";
    itemNameTable[Fix.SAVAGE_CLAW] = "Savage Claw";
    itemNameTable[Fix.WINGED_ROD] = "Winged Rod";
    itemNameTable[Fix.EXPERT_BOOK] = "Expert Book";
    itemNameTable[Fix.FLOATING_ORB] = "Floating Orb";
    itemNameTable[Fix.ELVISH_BOW] = "Elvish Bow";
    itemNameTable[Fix.IRON_SHIELD] = "Iron Shield";
    itemNameTable[Fix.IRON_ARMOR] = "Iron Armor";
    itemNameTable[Fix.CROSSCHAIN_MAIL] = "Crosschain Mail";
    itemNameTable[Fix.CHIFFON_ROBE] = "Chiffon Robe";

    // --- Named upper-tier weapons and armor ---
    itemNameTable[Fix.BLUE_LIGHTNING_SWORD] = "Blue Lightning Sword";
    itemNameTable[Fix.ASH_EXCLUDE_LANCE] = "Ash Exclude Lance";
    itemNameTable[Fix.BONE_CRUSH_AXE] = "Bone Crush Axe";
    itemNameTable[Fix.COLD_SPLASH_CLAW] = "Cold Splash Claw";
    itemNameTable[Fix.GORGON_EYES_BOOK] = "Gorgon Eyes Book";
    itemNameTable[Fix.STAR_FUSION_ORB] = "Star Fusion Orb";
    itemNameTable[Fix.SILVER_EARTH_SHIELD] = "Silver Earth Shield";
    itemNameTable[Fix.ROIZ_IMPERIAL_ARMOR] = "Roiz Imperial Armor";
    itemNameTable[Fix.SWIFT_THUNDER_CROSS] = "Swift Thunder Cross";
    itemNameTable[Fix.CROWD_DIRGE_ROBE] = "Crowd Dirge Robe";
    itemNameTable[Fix.DEPRESS_FEATHER] = "Depress Feather";
    itemNameTable[Fix.STIFF_BELT] = "Tight Belt";
    itemNameTable[Fix.LOST_NAME_EMBLEM] = "Emblem of the Lost Name";
    itemNameTable[Fix.DAMAGED_STATUE] = "Damaged Statue";
    itemNameTable[Fix.MAGICLIGHT_FIRE] = "Magiclight [Fire]";
    itemNameTable[Fix.MAGICLIGHT_ICE] = "Magiclight [Ice]";
    itemNameTable[Fix.MAGICLIGHT_SHADOW] = "Magiclight [Shadow]";
    itemNameTable[Fix.MAGICLIGHT_LIGHT] = "Magiclight [Light]";
    itemNameTable[Fix.RED_AMULET] = "Red Amulet";
    itemNameTable[Fix.BLUE_AMULET] = "Blue Amulet";
    itemNameTable[Fix.PURPLE_AMULET] = "Purple Amulet";
    itemNameTable[Fix.GREEN_AMULET] = "Green Amulet";
    itemNameTable[Fix.YELLOW_AMULET] = "Yellow Amulet";
    itemNameTable[Fix.STEEL_ANKLET] = "Steel Anklet";
    itemNameTable[Fix.TRUTH_GLASSES] = "Glasses of Truth";
    itemNameTable[Fix.ZEPHYR_FEATHER_BLUE] = "Zephyr Feather [Blue]";
    itemNameTable[Fix.CRIMSON_GAUNTLET] = "Crimson Gauntlet";
    itemNameTable[Fix.JADE_NOBLE_CIRCLET] = "Jade Noble Circlet";
    itemNameTable[Fix.ATTACH_SPIRAL_ORB] = "Wearable Spiral Orb";
    itemNameTable[Fix.THIN_STEEL_BUCKLER] = "Thin Steel Buckler";

    // --- Smart series ---
    itemNameTable[Fix.SMART_SWORD] = "Smart Sword";
    itemNameTable[Fix.SMART_LANCE] = "Smart Lance";
    itemNameTable[Fix.SMART_AXE] = "Smart Axe";
    itemNameTable[Fix.SMART_CLAW] = "Smart Claw";
    itemNameTable[Fix.SMART_ROD] = "Smart Rod";
    itemNameTable[Fix.SMART_BOOK] = "Smart Book";
    itemNameTable[Fix.SMART_ORB] = "Smart Orb";
    itemNameTable[Fix.SMART_LARGE_SWORD] = "Smart Greatsword";
    itemNameTable[Fix.SMART_LARGE_LANCE] = "Smart Grand Lance";
    itemNameTable[Fix.SMART_LARGE_AXE] = "Smart Grand Axe";
    itemNameTable[Fix.SMART_BOW] = "Smart Bow";
    itemNameTable[Fix.SMART_LARGE_STAFF] = "Smart Grand Staff";
    itemNameTable[Fix.SMART_SHIELD] = "Smart Shield";
    itemNameTable[Fix.SMART_ARMOR] = "Smart Armor";
    itemNameTable[Fix.SMART_CROSS] = "Smart Cross";
    itemNameTable[Fix.SMART_ROBE] = "Smart Robe";

    // --- Named weapons and armor (second tier) ---
    itemNameTable[Fix.DANCING_CLAW] = "Dancing Claw";
    itemNameTable[Fix.CUTTING_BLADE] = "Cutting Blade";
    itemNameTable[Fix.SWIFT_SPEAR] = "Swift Spear";
    itemNameTable[Fix.POWERED_AXE] = "Powered Axe";
    itemNameTable[Fix.LONG_BOW] = "Longbow";
    itemNameTable[Fix.AUTUMN_ROD] = "Autumn Rod";
    itemNameTable[Fix.BULKY_BOOK] = "Bulky Book";
    itemNameTable[Fix.FOCUS_ORB] = "Focus Orb";
    itemNameTable[Fix.WIDE_BUCKLER] = "Wide Buckler";
    itemNameTable[Fix.GOTHIC_PLATE] = "Gothic Plate";
    itemNameTable[Fix.FITNESS_CROSS] = "Fitness Cross";
    itemNameTable[Fix.SILK_ROBE] = "Silk Robe";
    itemNameTable[Fix.GALLANT_FEATHER_LANCE] = "Gallant Feather Lance";
    itemNameTable[Fix.THUNDER_BREAK_AXE] = "Thunder Break Axe";
    itemNameTable[Fix.WRATH_SABEL_CLAW] = "Wrath Saber Claw";
    itemNameTable[Fix.DORN_NAMELESS_ROD] = "Dorn Nameless Rod";
    itemNameTable[Fix.FINESSE_IMPERIAL_BOOK] = "Finesse Imperial Book";
    itemNameTable[Fix.INTRINSIC_FROZEN_ORB] = "Intrinsic Frozen Orb";
    itemNameTable[Fix.FORCEFUL_BASTARD_SWORD] = "Forceful Bastard Sword";
    itemNameTable[Fix.SHARPNEL_ARC_LANCER] = "Shrapnel Arc Lancer";
    itemNameTable[Fix.OGRE_KILL_BUSTER] = "Ogre Kill Buster";
    itemNameTable[Fix.EXPLODING_ASH_BOW] = "Exploding Ash Bow";
    itemNameTable[Fix.EARTH_POWERED_STAFF] = "Earth Powered Staff";
    itemNameTable[Fix.BLACK_REFLECTOR_SHIELD] = "Black Reflector Shield";
    itemNameTable[Fix.ARANDEL_FORCE_ARMOR] = "Arandel Force Armor";
    itemNameTable[Fix.WONDERING_BLESSED_CROSS] = "Wandering Blessed Cross";
    itemNameTable[Fix.SERANA_BRILLIANT_ROBE] = "Serana Brilliant Robe";
    itemNameTable[Fix.SUNLEAF_SEAL] = "Sunleaf Seal";
    itemNameTable[Fix.DEPLETH_SEED_PIERCE] = "Depleth Seed Pierce";
    itemNameTable[Fix.SPARKLINE_EMBLEM] = "Sparkline Emblem";
    itemNameTable[Fix.CHAINSHIFT_BOOTS] = "Chainshift Boots";
    itemNameTable[Fix.ASHED_COMPASS] = "Ashed Compass";
    itemNameTable[Fix.MIRAGE_PLASMA_EARRING] = "Mirage Plasma Earring";
    itemNameTable[Fix.PHOTON_ZEAL_CROWN] = "Photon Zeal Crown";
    itemNameTable[Fix.DEMONS_STAR_BRACELET] = "Demon's Star Bracelet";
    itemNameTable[Fix.MIST_WAVE_GAUNTLET] = "Mist Wave Gauntlet";
    itemNameTable[Fix.SPIRIT_CHALICE_OF_HEART] = "Spirit Chalice of Heart";
    itemNameTable[Fix.VIRGIRANTE_HELLGATE_LANCE] = "Virgirante Hellgate Lance";
    itemNameTable[Fix.MULLERHAIZEN_AGARTA_BOOK] = "Mullerhaizen Book of Agarta";
    itemNameTable[Fix.SILENT_OLGA_CLAW] = "Silent Olga Claw";
    itemNameTable[Fix.IRIDESCENT_CLOUD_FEATHER] = "Iridescent Cloud Feather";
    itemNameTable[Fix.BRINSCALE_WAR_CROSS] = "Brinscale War Cross";
    itemNameTable[Fix.GREAT_COMPOSITE_LANCE] = "Great Composite Lance";

    // --- Superior series ---
    itemNameTable[Fix.SUPERIOR_SWORD] = "Superior Sword";
    itemNameTable[Fix.SUPERIOR_LANCE] = "Superior Lance";
    itemNameTable[Fix.SUPERIOR_AXE] = "Superior Axe";
    itemNameTable[Fix.SUPERIOR_CLAW] = "Superior Claw";
    itemNameTable[Fix.SUPERIOR_ROD] = "Superior Rod";
    itemNameTable[Fix.SUPERIOR_BOOK] = "Superior Book";
    itemNameTable[Fix.SUPERIOR_ORB] = "Superior Orb";
    itemNameTable[Fix.SUPERIOR_LARGE_SWORD] = "Superior Greatsword";
    itemNameTable[Fix.SUPERIOR_LARGE_LANCE] = "Superior Grand Lance";
    itemNameTable[Fix.SUPERIOR_LARGE_AXE] = "Superior Grand Axe";
    itemNameTable[Fix.SUPERIOR_BOW] = "Superior Bow";
    itemNameTable[Fix.SUPERIOR_LARGE_STAFF] = "Superior Grand Staff";
    itemNameTable[Fix.SUPERIOR_SHIELD] = "Superior Shield";
    itemNameTable[Fix.SUPERIOR_ARMOR] = "Superior Armor";
    itemNameTable[Fix.SUPERIOR_CROSS] = "Superior Cross";
    itemNameTable[Fix.SUPERIOR_ROBE] = "Superior Robe";

    // --- Named high-tier weapons and armor ---
    itemNameTable[Fix.FULLMETAL_ASTRAL_BLADE] = "Fullmetal Astral Blade";
    itemNameTable[Fix.STORM_FURY_LANCER] = "Storm Fury Lancer";
    itemNameTable[Fix.WARLOAD_BASTARD_AXE] = "Warlord Bastard Axe";
    itemNameTable[Fix.EARTH_SHARD_CLAW] = "Earth Shard Claw";
    itemNameTable[Fix.ENGAGED_FUTURE_ROD] = "Engaged Future Rod";
    itemNameTable[Fix.ANCIENT_FAITHFUL_BOOK] = "Ancient Faithful Book";
    itemNameTable[Fix.BLUE_SKY_ORB] = "Blue Sky Orb";
    itemNameTable[Fix.PRISMATIC_SOUL_BREAKER] = "Prismatic Soul Breaker";
    itemNameTable[Fix.BLOOD_STUBBORN_SPEAR] = "Blood Stubborn Spear";
    itemNameTable[Fix.ELEMENTAL_DISRUPT_AXE] = "Elemental Disrupt Axe";
    itemNameTable[Fix.LINGERING_FROST_SHOOTER] = "Lingering Frost Shooter";
    itemNameTable[Fix.INFERNAL_IMMORTAL_STAFF] = "Infernal Immortal Staff";
    itemNameTable[Fix.GRACEFUL_KINGS_BUCKLER] = "Graceful King's Buckler";
    itemNameTable[Fix.HARDED_INTENSITY_PLATE] = "Hardened Intensity Plate";
    itemNameTable[Fix.SOLDIER_HATRED_CROSS] = "Soldier Vigor Cross";
    itemNameTable[Fix.WONDERERS_INVISIBLE_ROBE] = "Wanderer's Invisible Robe";
    itemNameTable[Fix.ZELMAN_THE_ONSLAUGHT_BASTER] = "Zelman the Onslaught Buster";
    itemNameTable[Fix.LIFEGRACE_FORTUNE_STAFF] = "Lifegrace Fortune Staff";
    itemNameTable[Fix.WHITEVEIL_QUEENS_ROBE] = "Whiteveil Queen's Robe";

    // --- Steel bangles ---
    itemNameTable[Fix.STEEL_RING_POWER] = "Steel Bangle 'Power'";
    itemNameTable[Fix.STEEL_RING_SENSE] = "Steel Bangle 'Sense'";
    itemNameTable[Fix.STEEL_RING_TOUGH] = "Steel Bangle 'Tough'";
    itemNameTable[Fix.STEEL_RING_ROCK] = "Steel Bangle 'Rock'";
    itemNameTable[Fix.STEEL_RING_FAST] = "Steel Bangle 'Fast'";
    itemNameTable[Fix.STEEL_RING_SHARP] = "Steel Bangle 'Sharp'";
    itemNameTable[Fix.STEEL_RING_HIGH] = "Steel Bangle 'High'";
    itemNameTable[Fix.STEEL_RING_DEEP] = "Steel Bangle 'Deep'";
    itemNameTable[Fix.STEEL_RING_BOUND] = "Steel Bangle 'Bound'";
    itemNameTable[Fix.STEEL_RING_EMOTE] = "Steel Bangle 'Emote'";

    // --- Powersteel bangles ---
    itemNameTable[Fix.POWER_STEEL_RING_SOLID] = "Powersteel Bangle 'Solid'";
    itemNameTable[Fix.POWER_STEEL_RING_VAPOUR] = "Powersteel Bangle 'Vapour'";
    itemNameTable[Fix.POWER_STEEL_RING_STRAIN] = "Powersteel Bangle 'Strain'";
    itemNameTable[Fix.POWER_STEEL_RING_TOLERANCE] = "Powersteel Bangle 'Tolerance'";
    itemNameTable[Fix.POWER_STEEL_RING_ASCEND] = "Powersteel Bangle 'Ascend'";
    itemNameTable[Fix.POWER_STEEL_RING_INTERCEPT] = "Powersteel Bangle 'Intercept'";

    // --- Unique accessories ---
    itemNameTable[Fix.LUMINOUS_REFLECT_MIRROR] = "Luminous Reflect Mirror";
    itemNameTable[Fix.BLACK_SPIRAL_NEEDLE] = "Black Spiral Needle";
    itemNameTable[Fix.EMBLEM_OF_VALKYRIE] = "Emblem of Valkyrie";
    itemNameTable[Fix.EMBLEM_OF_NECROMANCY] = "Emblem of Necromancy";
    itemNameTable[Fix.OHRAN_REDIAN_ROD] = "Ohran Redian Rod";
    itemNameTable[Fix.VIGILANT_FENCER_ROBE] = "Vigilant Fencer's Robe";
    itemNameTable[Fix.LION_EYES_BLADE] = "Lion Eyes Blade";

    // --- Master series ---
    itemNameTable[Fix.MASTER_SWORD] = "Master Sword";
    itemNameTable[Fix.MASTER_LANCE] = "Master Lance";
    itemNameTable[Fix.MASTER_AXE] = "Master Axe";
    itemNameTable[Fix.MASTER_CLAW] = "Master Claw";
    itemNameTable[Fix.MASTER_ROD] = "Master Rod";
    itemNameTable[Fix.MASTER_BOOK] = "Master Book";
    itemNameTable[Fix.MASTER_ORB] = "Master Orb";
    itemNameTable[Fix.MASTER_LARGE_SWORD] = "Master Greatsword";
    itemNameTable[Fix.MASTER_LARGE_LANCE] = "Master Grand Lance";
    itemNameTable[Fix.MASTER_LARGE_AXE] = "Master Grand Axe";
    itemNameTable[Fix.MASTER_BOW] = "Master Bow";
    itemNameTable[Fix.MASTER_LARGE_STAFF] = "Master Grand Staff";
    itemNameTable[Fix.MASTER_SHIELD] = "Master Shield";
    itemNameTable[Fix.MASTER_ARMOR] = "Master Armor";
    itemNameTable[Fix.MASTER_CROSS] = "Master Cross";
    itemNameTable[Fix.MASTER_ROBE] = "Master Robe";

    // --- Named elite weapons and armor ---
    itemNameTable[Fix.SOLEMN_EMPERORS_SWORD] = "Solemn Emperor's Sword";
    itemNameTable[Fix.MYSTIC_BLUE_JAVELIN] = "Mystic Blue Javelin";
    itemNameTable[Fix.AURA_BURN_CLAW] = "Aura Burn Claw";
    itemNameTable[Fix.MIND_STONEFEAR_ROD] = "Mind Stonefear Rod";
    itemNameTable[Fix.DARKSUN_TRAGEDIC_BOOK] = "Darksun Tragedic Book";
    itemNameTable[Fix.CHROMATIC_FORGE_ORB] = "Chromatic Forge Orb";
    itemNameTable[Fix.FLASH_VANISH_SPEAR] = "Flash Vanish Spear";
    itemNameTable[Fix.VOLCANIC_BATTLE_BASTER] = "Volcanic Battle Buster";
    itemNameTable[Fix.WHITE_FIRE_CROSSBOW] = "White Fire Crossbow";
    itemNameTable[Fix.ELDERSTAFF_OF_LIFEBLOOM] = "Elderstaff of Lifebloom";
    itemNameTable[Fix.DIMENSION_ZERO_SHIELD] = "Dimension Zero Shield";
    itemNameTable[Fix.HIGHWARRIOR_DRAGONMAIL] = "High Warrior Dragonmail";
    itemNameTable[Fix.SWIFTCROSS_OF_REDTHUNDER] = "Swiftcross of Red Thunder";
    itemNameTable[Fix.BLADESHADOW_CROWDED_DRESS] = "Bladeshadow Crowded Dress";
    itemNameTable[Fix.BLACKROGUE_BLACKROGUE_AMBIDEXTARITY_DAGGER] = "Blackrogue Ambidexterity Dagger";
    itemNameTable[Fix.HOLY_BLESSING_SHIELD] = "Holy Blessing Shield";
    itemNameTable[Fix.LATA_GUARDIAN_RING] = "Guardian Ring [Lata's Guidance]";
    itemNameTable[Fix.BLUEEYE_TEMPLE_PENDANT] = "Temple Knight's Pendant [Blue Eye]";
    itemNameTable[Fix.REDEYE_TEMPLE_PENDANT] = "Temple Knight's Pendant [Red Eye]";
    itemNameTable[Fix.SEAL_OF_REDEYE] = "Seal of Red Eye";
    itemNameTable[Fix.SEAL_OF_BLUEEYE] = "Seal of Blue Eye";
    itemNameTable[Fix.WINGED_LIGHTNING_BOOTS] = "Winged Lightning Boots";
    itemNameTable[Fix.SPELLCASTERS_LENS] = "Spellcaster's Lens";
    itemNameTable[Fix.PEACEFUL_REBIRTH_CANDLE] = "Peaceful Rebirth Candle";
    itemNameTable[Fix.DESPAIR_BLACKANGEL_RING] = "Despair Black Angel Ring";
    itemNameTable[Fix.PHANTASMAL_INSIGHT_RUNE] = "Phantasmal Insight Rune";
    itemNameTable[Fix.SILVER_ETERNAL_SEED] = "Silver Eternal Seed";
    itemNameTable[Fix.FIRELIEGE_AETHER_TALISMAN] = "Fireliege Aether Talisman";
    itemNameTable[Fix.RAINBOW_MOON_COMPASS] = "Rainbow Moon Compass";
    itemNameTable[Fix.HIGH_RANGER_BATTLE_BOW] = "High Ranger Battle Bow";
    itemNameTable[Fix.DARMEKIUS_HARD_PLATE] = "Darmekius Hard Plate";
    itemNameTable[Fix.SEE_SONG_FEBRIOL_BOOK] = "See Song Febriol Book";

    // --- Marvelous series ---
    itemNameTable[Fix.MARVELOUS_SWORD] = "Marvelous Sword";
    itemNameTable[Fix.MARVELOUS_LANCE] = "Marvelous Lance";
    itemNameTable[Fix.MARVELOUS_AXE] = "Marvelous Axe";
    itemNameTable[Fix.MARVELOUS_CLAW] = "Marvelous Claw";
    itemNameTable[Fix.MARVELOUS_ROD] = "Marvelous Rod";
    itemNameTable[Fix.MARVELOUS_BOOK] = "Marvelous Book";
    itemNameTable[Fix.MARVELOUS_ORB] = "Marvelous Orb";
    itemNameTable[Fix.MARVELOUS_LARGE_SWORD] = "Marvelous Greatsword";
    itemNameTable[Fix.MARVELOUS_LARGE_LANCE] = "Marvelous Grand Lance";
    itemNameTable[Fix.MARVELOUS_LARGE_AXE] = "Marvelous Grand Axe";
    itemNameTable[Fix.MARVELOUS_BOW] = "Marvelous Bow";
    itemNameTable[Fix.MARVELOUS_LARGE_STAFF] = "Marvelous Grand Staff";
    itemNameTable[Fix.MARVELOUS_SHIELD] = "Marvelous Shield";
    itemNameTable[Fix.MARVELOUS_ARMOR] = "Marvelous Armor";
    itemNameTable[Fix.MARVELOUS_CROSS] = "Marvelous Cross";
    itemNameTable[Fix.MARVELOUS_ROBE] = "Marvelous Robe";

    // --- Excellent series ---
    itemNameTable[Fix.EXCELLENT_SWORD] = "Excellent Sword";
    itemNameTable[Fix.EXCELLENT_LANCE] = "Excellent Lance";
    itemNameTable[Fix.EXCELLENT_AXE] = "Excellent Axe";
    itemNameTable[Fix.EXCELLENT_CLAW] = "Excellent Claw";
    itemNameTable[Fix.EXCELLENT_ROD] = "Excellent Rod";
    itemNameTable[Fix.EXCELLENT_BOOK] = "Excellent Book";
    itemNameTable[Fix.EXCELLENT_ORB] = "Excellent Orb";
    itemNameTable[Fix.EXCELLENT_LARGE_SWORD] = "Excellent Greatsword";
    itemNameTable[Fix.EXCELLENT_LARGE_LANCE] = "Excellent Grand Lance";
    itemNameTable[Fix.EXCELLENT_LARGE_AXE] = "Excellent Grand Axe";
    itemNameTable[Fix.EXCELLENT_BOW] = "Excellent Bow";
    itemNameTable[Fix.EXCELLENT_LARGE_STAFF] = "Excellent Grand Staff";
    itemNameTable[Fix.EXCELLENT_SHIELD] = "Excellent Shield";
    itemNameTable[Fix.EXCELLENT_ARMOR] = "Excellent Armor";
    itemNameTable[Fix.EXCELLENT_CROSS] = "Excellent Cross";
    itemNameTable[Fix.EXCELLENT_ROBE] = "Excellent Robe";

    // --- Extreme series ---
    itemNameTable[Fix.EXTREME_SWORD] = "Extreme Sword";
    itemNameTable[Fix.EXTREME_LANCE] = "Extreme Lance";
    itemNameTable[Fix.EXTREME_AXE] = "Extreme Axe";
    itemNameTable[Fix.EXTREME_CLAW] = "Extreme Claw";
    itemNameTable[Fix.EXTREME_ROD] = "Extreme Rod";
    itemNameTable[Fix.EXTREME_BOOK] = "Extreme Book";
    itemNameTable[Fix.EXTREME_ORB] = "Extreme Orb";
    itemNameTable[Fix.EXTREME_BOW] = "Extreme Bow";
    itemNameTable[Fix.EXTREME_LARGE_STAFF] = "Extreme Grand Staff";
    itemNameTable[Fix.EXTREME_SHIELD] = "Extreme Shield";
    itemNameTable[Fix.EXTREME_ARMOR] = "Extreme Armor";
    itemNameTable[Fix.EXTREME_CROSS] = "Extreme Cross";
    itemNameTable[Fix.EXTREME_ROBE] = "Extreme Robe";

    // --- Named legendary weapons and armor ---
    itemNameTable[Fix.ETHEREAL_EDGE_BLADE] = "Ethereal Edge Blade";
    itemNameTable[Fix.EVIL_ELIMINATION_LANCE] = "Evil Elimination Lance";
    itemNameTable[Fix.PRISON_DESTRUCTION_AXE] = "Prison Destruction Axe";
    itemNameTable[Fix.GARGAN_BLAZE_ROD] = "Gargan Blaze Rod";
    itemNameTable[Fix.ALL_ELEMENTAL_ORB] = "All Elemental Orb";
    itemNameTable[Fix.LABYRINTH_MAGE_BLUESTAFF] = "Labyrinth Mage's Blue Grand Staff";
    itemNameTable[Fix.MAJESTIC_FORCE_SHIELD] = "Majestic Force Shield";
    itemNameTable[Fix.ROBE_OF_COLORSTREAMING] = "Robe of Colorstreaming";

    // --- Crystals ---
    itemNameTable[Fix.RED_CRYSTAL] = "Crimson Crystal";
    itemNameTable[Fix.BLUE_CRYSTAL] = "Lapis Crystal";
    itemNameTable[Fix.PURPLE_CRYSTAL] = "Violet Crystal";
    itemNameTable[Fix.GREEN_CRYSTAL] = "Jade Crystal";
    itemNameTable[Fix.YELLOW_CRYSTAL] = "Amber Crystal";

    // --- Late-game accessories ---
    itemNameTable[Fix.RAGING_RESONANCE_RING] = "Raging Resonance Ring";
    itemNameTable[Fix.LAGINA_DISTORTED_BRACER] = "Lagina Distorted Bracer";
    itemNameTable[Fix.RIGID_WAVE_METALGUNTLET] = "Rigid Wave Metal Gauntlet";
    itemNameTable[Fix.ISOCHRON_FATED_LENS] = "Isochron Fated Lens";
    itemNameTable[Fix.HEART_SEEKERS_STONE] = "Heart Seeker's Stone";
    itemNameTable[Fix.SUN_BREAKERS_STONE] = "Sun Breaker's Stone";

    // --- Incredible series ---
    itemNameTable[Fix.INCREDIBLE_SWORD] = "Incredible Sword";
    itemNameTable[Fix.INCREDIBLE_LANCE] = "Incredible Lance";
    itemNameTable[Fix.INCREDIBLE_AXE] = "Incredible Axe";
    itemNameTable[Fix.INCREDIBLE_CLAW] = "Incredible Claw";
    itemNameTable[Fix.INCREDIBLE_ROD] = "Incredible Rod";
    itemNameTable[Fix.INCREDIBLE_BOOK] = "Incredible Book";
    itemNameTable[Fix.INCREDIBLE_ORB] = "Incredible Orb";
    itemNameTable[Fix.INCREDIBLE_LARGE_SWORD] = "Incredible Greatsword";
    itemNameTable[Fix.INCREDIBLE_LARGE_LANCE] = "Incredible Grand Lance";
    itemNameTable[Fix.INCREDIBLE_LARGE_AXE] = "Incredible Grand Axe";
    itemNameTable[Fix.INCREDIBLE_BOW] = "Incredible Bow";
    itemNameTable[Fix.INCREDIBLE_LARGE_STAFF] = "Incredible Grand Staff";
    itemNameTable[Fix.INCREDIBLE_SHIELD] = "Incredible Shield";
    itemNameTable[Fix.INCREDIBLE_ARMOR] = "Incredible Armor";
    itemNameTable[Fix.INCREDIBLE_CROSS] = "Incredible Cross";
    itemNameTable[Fix.INCREDIBLE_ROBE] = "Incredible Robe";

    // --- Key / quest items ---
    itemNameTable[Fix.ZETANIUM_STONE] = "Zetanium Ore";
    itemNameTable[Fix.FIELD_RESEARCH_LICENSE] = "Expedition Permit";
    itemNameTable[Fix.PURE_CLEAN_WATER] = "Pure Clear Water";
    itemNameTable[Fix.SHADOW_MOON_KEY] = "Shadow Moon Key";
    itemNameTable[Fix.SUN_BURST_KEY] = "Sun Burst Key";
    itemNameTable[Fix.STAR_DUST_KEY] = "Star Dust Key";
    itemNameTable[Fix.ORIGIN_ROAD_KEY] = "Origin Road Key";
    itemNameTable[Fix.RESIST_POISON_SUIT] = "Poison-Resistant Suit";
    itemNameTable[Fix.ARTHARIUM_KEY] = "Artharium Factory Key";
    itemNameTable[Fix.UNKNOWN_OBJECT] = "Strange Object";
    itemNameTable[Fix.MARBLE_STAR] = "Marble Star";
    itemNameTable[Fix.ZHALMAN_NECKLACE] = "Zhalman Village Necklace";
    itemNameTable[Fix.FIRE_ANGEL_TALISMAN] = "Flame-Blessed Angel's Talisman";
    itemNameTable[Fix.EARRING_OF_LANA] = "Lana's Earring";
    itemNameTable[Fix.PRECIOUS_SWORD] = "Precious Sword ???";
    itemNameTable[Fix.BLUESKY_STAR_FEATHER] = "Blue Starlit Heaven Feather";
    itemNameTable[Fix.REDCOMET_STAR_CHARM] = "Red Comet Star Charm";

    // --- Black Materials ---
    itemNameTable[Fix.POOR_BLACK_MATERIAL] = "Black Material";
    itemNameTable[Fix.POOR_BLACK_MATERIAL2] = "Black Material [Revised]";
    itemNameTable[Fix.POOR_BLACK_MATERIAL3] = "Black Material [Ash]";
    itemNameTable[Fix.POOR_BLACK_MATERIAL4] = "Black Material [Dense]";
    itemNameTable[Fix.POOR_BLACK_MATERIAL5] = "Black Material [Dust]";
    itemNameTable[Fix.POOR_BLACK_MATERIAL6] = "Black Material [Trial]";
    itemNameTable[Fix.POOR_BLACK_MATERIAL7] = "Black Material [Ruin]";
    itemNameTable[Fix.POOR_BLACK_MATERIAL8] = "Black Material [Return]";
    itemNameTable[Fix.POOR_BLACK_MATERIAL9] = "Black Material [Void]";

    // --- Potions ---
    itemNameTable[Fix.SMALL_RED_POTION] = "Small Red Potion";
    itemNameTable[Fix.SMALL_BLUE_POTION] = "Small Blue Potion";
    itemNameTable[Fix.SMALL_GREEN_POTION] = "Small Green Potion";
    itemNameTable[Fix.NORMAL_RED_POTION] = "Red Potion";
    itemNameTable[Fix.NORMAL_BLUE_POTION] = "Blue Potion";
    itemNameTable[Fix.NORMAL_GREEN_POTION] = "Green Potion";
    itemNameTable[Fix.LARGE_RED_POTION] = "Large Red Potion";
    itemNameTable[Fix.LARGE_BLUE_POTION] = "Large Blue Potion";
    itemNameTable[Fix.LARGE_GREEN_POTION] = "Large Green Potion";
    itemNameTable[Fix.HUGE_RED_POTION] = "Huge Red Potion";
    itemNameTable[Fix.HUGE_BLUE_POTION] = "Huge Blue Potion";
    itemNameTable[Fix.HUGE_GREEN_POTION] = "Huge Green Potion";
    itemNameTable[Fix.HQ_RED_POTION] = "High-Quality Red Potion";
    itemNameTable[Fix.HQ_BLUE_POTION] = "High-Quality Blue Potion";
    itemNameTable[Fix.HQ_GREEN_POTION] = "High-Quality Green Potion";
    itemNameTable[Fix.THQ_RED_POTION] = "Supreme Red Potion";
    itemNameTable[Fix.THQ_BLUE_POTION] = "Supreme Blue Potion";
    itemNameTable[Fix.THQ_GREEN_POTION] = "Supreme Green Potion";
    itemNameTable[Fix.PERFECT_RED_POTION] = "Perfect Red Potion";
    itemNameTable[Fix.PERFECT_BLUE_POTION] = "Perfect Blue Potion";
    itemNameTable[Fix.PERFECT_GREEN_POTION] = "Perfect Green Potion";
    itemNameTable[Fix.POTION_RESIST_FIRE] = "Heat Resist Potion";
    itemNameTable[Fix.CURE_SEAL] = "Cure Seal";
    itemNameTable[Fix.POTION_MAGIC_SEAL] = "Magic Seal Potion";
    itemNameTable[Fix.POTION_RESIST_PLUS] = "Resist Potion Plus";
    itemNameTable[Fix.PATERMA_DISMAGIC_DRINK] = "Paterma Anti-Magic Drink";
    itemNameTable[Fix.OLDTREE_GUARDIAN_MARK] = "Ancient Great Tree Guardian Seal";
    itemNameTable[Fix.LEKS_MYSTICAL_POTION] = "Leks Mystical Potion";
    itemNameTable[Fix.SEAL_OF_ARCPOWER] = "Seal of Arc Power";
    itemNameTable[Fix.SEAL_OF_CHOSEN_POWER] = "Seal of Chosen Power";

    // --- Growth Elixirs ---
    itemNameTable[Fix.GROWTH_LIQUID_STRENGTH] = "Growth Elixir [Strength]";
    itemNameTable[Fix.GROWTH_LIQUID_AGILITY] = "Growth Elixir [Agility]";
    itemNameTable[Fix.GROWTH_LIQUID_INTELLIGENCE] = "Growth Elixir [Intelligence]";
    itemNameTable[Fix.GROWTH_LIQUID_STAMINA] = "Growth Elixir [Stamina]";
    itemNameTable[Fix.GROWTH_LIQUID_MIND] = "Growth Elixir [Spirit]";
    itemNameTable[Fix.GROWTH_LIQUID2_STRENGTH] = "Growth Elixir II [Strength]";
    itemNameTable[Fix.GROWTH_LIQUID2_AGILITY] = "Growth Elixir II [Agility]";
    itemNameTable[Fix.GROWTH_LIQUID2_INTELLIGENCE] = "Growth Elixir II [Intelligence]";
    itemNameTable[Fix.GROWTH_LIQUID2_STAMINA] = "Growth Elixir II [Stamina]";
    itemNameTable[Fix.GROWTH_LIQUID2_MIND] = "Growth Elixir II [Spirit]";
    itemNameTable[Fix.GROWTH_LIQUID3_STRENGTH] = "Growth Elixir III [Strength]";
    itemNameTable[Fix.GROWTH_LIQUID3_AGILITY] = "Growth Elixir III [Agility]";
    itemNameTable[Fix.GROWTH_LIQUID3_INTELLIGENCE] = "Growth Elixir III [Intelligence]";
    itemNameTable[Fix.GROWTH_LIQUID3_STAMINA] = "Growth Elixir III [Stamina]";
    itemNameTable[Fix.GROWTH_LIQUID3_MIND] = "Growth Elixir III [Spirit]";
    itemNameTable[Fix.GROWTH_LIQUID4_STRENGTH] = "Growth Elixir IV [Strength]";
    itemNameTable[Fix.GROWTH_LIQUID4_AGILITY] = "Growth Elixir IV [Agility]";
    itemNameTable[Fix.GROWTH_LIQUID4_INTELLIGENCE] = "Growth Elixir IV [Intelligence]";
    itemNameTable[Fix.GROWTH_LIQUID4_STAMINA] = "Growth Elixir IV [Stamina]";
    itemNameTable[Fix.GROWTH_LIQUID4_MIND] = "Growth Elixir IV [Spirit]";
    itemNameTable[Fix.GROWTH_LIQUID5_STRENGTH] = "Growth Elixir V [Strength]";
    itemNameTable[Fix.GROWTH_LIQUID5_AGILITY] = "Growth Elixir V [Agility]";
    itemNameTable[Fix.GROWTH_LIQUID5_INTELLIGENCE] = "Growth Elixir V [Intelligence]";
    itemNameTable[Fix.GROWTH_LIQUID5_STAMINA] = "Growth Elixir V [Stamina]";
    itemNameTable[Fix.GROWTH_LIQUID5_MIND] = "Growth Elixir V [Spirit]";
    itemNameTable[Fix.GROWTH_LIQUID6_STRENGTH] = "Growth Elixir VI [Strength]";
    itemNameTable[Fix.GROWTH_LIQUID6_AGILITY] = "Growth Elixir VI [Agility]";
    itemNameTable[Fix.GROWTH_LIQUID6_INTELLIGENCE] = "Growth Elixir VI [Intelligence]";
    itemNameTable[Fix.GROWTH_LIQUID6_STAMINA] = "Growth Elixir VI [Stamina]";
    itemNameTable[Fix.GROWTH_LIQUID6_MIND] = "Growth Elixir VI [Spirit]";
    itemNameTable[Fix.GROWTH_LIQUID7_STRENGTH] = "Growth Elixir VII [Strength]";
    itemNameTable[Fix.GROWTH_LIQUID7_AGILITY] = "Growth Elixir VII [Agility]";
    itemNameTable[Fix.GROWTH_LIQUID7_INTELLIGENCE] = "Growth Elixir VII [Intelligence]";
    itemNameTable[Fix.GROWTH_LIQUID7_STAMINA] = "Growth Elixir VII [Stamina]";
    itemNameTable[Fix.GROWTH_LIQUID7_MIND] = "Growth Elixir VII [Spirit]";

    // --- Common material drops ---
    itemNameTable[Fix.COMMON_MANDORAGORA_ROOT] = "Mandragora Root";
    itemNameTable[Fix.COMMON_WOLF_FUR] = "Wolf Pelt";
    itemNameTable[Fix.COMMON_ANT_ESSENCE] = "Ant Essence";
    itemNameTable[Fix.COMMON_SUN_LEAF] = "Sun Leaf";
    itemNameTable[Fix.COMMON_RABBIT_MEAT] = "Rabbit Meat";
    itemNameTable[Fix.COMMON_ORANGE_MATERIAL] = "Orange Material";
    itemNameTable[Fix.COMMON_ASH_EGG] = "Pale Gray Egg";
    itemNameTable[Fix.COMMON_PLANTNOID_SEED] = "Plantnoid Seed";
    itemNameTable[Fix.COMMON_MACHINE_PARTS] = "Machine Parts";
    itemNameTable[Fix.COMMON_BAT_FEATHER] = "Bat Wing";
    itemNameTable[Fix.COMMON_GLASS_SHARD] = "Glass Shard";
    itemNameTable[Fix.COMMON_MECHANICAL_SHAFT] = "Mechanical Shaft";
    itemNameTable[Fix.COMMON_AMBER_MATERIAL] = "Amber Material";
    itemNameTable[Fix.COMMON_SOLIDSTONE_MATERIAL] = "Hard Stone Material";
    itemNameTable[Fix.COMMON_JUNK_PARTS] = "Junk Parts";
    itemNameTable[Fix.COMMON_ELECT_BOLT] = "Electromagnetic Bolt";
    itemNameTable[Fix.COMMON_GARGOYLE_EYE] = "Gargoyle Eyeball";
    itemNameTable[Fix.COMMON_WATCHDOG_TONGUE] = "Watchdog Tongue";
    itemNameTable[Fix.COMMON_CHROTIUM_MATERIAL] = "Chrotium Material";
    itemNameTable[Fix.COMMON_MIST_LEAF] = "Mist Grass";
    itemNameTable[Fix.COMMON_NORMAL_SPORE_ESSENCE] = "Unprocessed Spore Extract";
    itemNameTable[Fix.COMMON_FROG_FRONTLEG] = "Frog Foreleg";
    itemNameTable[Fix.COMMON_BEAR_LARGE_CLAW] = "Bear's Great Claw";
    itemNameTable[Fix.COMMON_FAIRY_POWDER] = "Fairy Powder";
    itemNameTable[Fix.COMMON_BEAUTY_WHITEFEATHER] = "Beautiful White Feather";
    itemNameTable[Fix.COMMON_HUNTER_TOOL] = "Hunter's Tool Bag";
    itemNameTable[Fix.COMMON_BLACK_MIST_ESSENCE] = "Black Mist Extract";
    itemNameTable[Fix.COMMON_ELEPHANT_LEGS] = "Elephant's Massive Legs";
    itemNameTable[Fix.COMMON_LAPTOR_FUR] = "Raptor Pelt";
    itemNameTable[Fix.COMMON_SHARPNESS_TIGER_TOOTH] = "Razor-Sharp Tiger Fang";
    itemNameTable[Fix.COMMON_THORN_ELEMENT] = "Thorn Crown Material";
    itemNameTable[Fix.COMMON_MARY_KISS] = "Mary Kiss";
    itemNameTable[Fix.COMMON_MAGIC_HORN] = "Magic Horn";
    itemNameTable[Fix.COMMON_WINDMAN_SEAL] = "Wind Folk's Seal";
    itemNameTable[Fix.COMMON_MYSTERY_SCROLL] = "Mysterious Scroll";
    itemNameTable[Fix.COMMON_BLUECOLOR_EYE] = "Blue Eyeball";
    itemNameTable[Fix.COMMON_WHITECOLOR_EYE] = "White Eyeball";
    itemNameTable[Fix.COMMON_CURTAIN_MATERIAL] = "Curtain Material";
    itemNameTable[Fix.COMMON_ARTHARIUM_JEWEL] = "Artharium Jewel";
    itemNameTable[Fix.COMMON_LION_FUR] = "Lion Pelt";
    itemNameTable[Fix.COMMON_PARTIMIUM_MATERIAL] = "Partimium Material";
    itemNameTable[Fix.COMMON_HUGE_BOOK] = "Thick Tome";
    itemNameTable[Fix.COMMON_GUNPOWDER] = "Gunpowder";
    itemNameTable[Fix.COMMON_SILENT_WHISTLE] = "Silent Whistle";
    itemNameTable[Fix.COMMON_STEEL_BATON] = "Steel Baton";
    itemNameTable[Fix.COMMON_PURE_SILVER] = "Pure Silver";
    itemNameTable[Fix.COMMON_SPEEDARROW_TOOL] = "Swift Arrow Crafting Tool";
    itemNameTable[Fix.COMMON_OVAL_GEAR] = "Oval Gear";
    itemNameTable[Fix.COMMON_APLITOS_BONE] = "Aplitos Cartilage";
    itemNameTable[Fix.COMMON_DEATH_CLOVER] = "Death Clover";
    itemNameTable[Fix.COMMON_JUMP_MATERIAL] = "Jumping Material";
    itemNameTable[Fix.COMMON_BIG_STONE] = "Big Stone";
    itemNameTable[Fix.COMMON_UNKNOWN_BOX] = "Unidentified Box";
    itemNameTable[Fix.RARE_JOE_TONGUE] = "Joe's Tongue";
    itemNameTable[Fix.COMMON_SEA_WATER] = "Pure Seawater";
    itemNameTable[Fix.COMMON_SEA_MUSICBOX] = "Sea Music Box";
    itemNameTable[Fix.RARE_MEPHISTO_BLACKLIGHT] = "Mephisto's Black Flame";
    itemNameTable[Fix.COMMON_SEEKER_HEAD] = "Seeker's Skull";
    itemNameTable[Fix.RARE_ESSENCE_OF_DARK] = "Essence of Dark";
    itemNameTable[Fix.COMMON_EXECUTIONER_ROBE] = "Executioner's Tattered Robe";
    itemNameTable[Fix.COMMON_NEMESIS_ESSENCE] = "Nemesis Essence";
    itemNameTable[Fix.RARE_MASTERBLADE_FIRE] = "Masterblade's Embers";
    itemNameTable[Fix.COMMON_GREAT_JEWELCROWN] = "Grand Jewel Crown";
    itemNameTable[Fix.RARE_ESSENCE_OF_SHINE] = "Essence of Shine";
    itemNameTable[Fix.RARE_DEMON_HORN] = "Demon Horn";
    itemNameTable[Fix.COMMON_WYVERN_BONE] = "Wyvern Bone";
    itemNameTable[Fix.RARE_ESSENCE_OF_FLAME] = "Essence of Flame";
    itemNameTable[Fix.RARE_BLACK_SEAL_IMPRESSION] = "Black Seal Imprint";
    itemNameTable[Fix.COMMON_HIGH_ESTORMIUM_MATERIAL] = "High-Purity Estormium Material";
    itemNameTable[Fix.RARE_ANGEL_SILK] = "Angel's Silk";
    itemNameTable[Fix.RARE_DREAD_EXTRACT] = "Dread Extract";
    itemNameTable[Fix.COMMON_ESSENCE_OF_WIND] = "Essence of Wind";
    itemNameTable[Fix.COMMON_INNOCENCE_ESSENCE] = "Innocence Essence";
    itemNameTable[Fix.COMMON_UNRESOLVED_MATERIAL] = "Unidentified Substance";

    // --- Item category labels ---
    itemNameTable[Fix.DESCRIPTION_SELL_ONLY] = "For Sale Only";
    itemNameTable[Fix.DESCRIPTION_BATTLE_ONLY] = "Battle Use Only";
    itemNameTable[Fix.DESCRIPTION_EQUIP_MATERIAL] = "Weapon Material";
    itemNameTable[Fix.DESCRIPTION_POTION_MATERIAL] = "Potion Material";
    itemNameTable[Fix.DESCRIPTION_FOOD_MATERIAL] = "Food Ingredient";
    itemNameTable[Fix.DESCRIPTION_WEAPON] = "Weapon";
    itemNameTable[Fix.DESCRIPTION_SHIELD] = "Shield";
    itemNameTable[Fix.DESCRIPTION_ARMOR] = "Armor";
    itemNameTable[Fix.DESCRIPTION_ACCESSORY] = "Accessory";
    itemNameTable[Fix.DESCRIPTION_POTION] = "Consumable";
    itemNameTable[Fix.DESCRIPTION_BLUEORB] = "Exclusive Item";

    // --- Special named items (already English values) ---
    itemNameTable[Fix.RING_OF_OSCURETE] = "Ring of the Oscurete";
    itemNameTable[Fix.MERGIZD_SOL_BLADE] = "Mergizd Sol Blade";
    itemNameTable[Fix.ADILORB_OF_THE_GARVANDI] = "AdilOrb of the Garvandi";
    itemNameTable[Fix.MAXCARN_X_BUSTER] = "Maxcarn the X-BUSTER";
    itemNameTable[Fix.GATUH_HAWL_OF_GREAT] = "Gatuh Hawl of Great";
    itemNameTable[Fix.JUZA_ARESTINE_SLICER] = "Arestine-Slicer of Juza";
    itemNameTable[Fix.ADILRING_OF_BLUE_BURN] = "AdilRing of the Blue Burn";
    itemNameTable[Fix.SHEZL_MYSTIC_FORTUNE] = "Shezl the Mystic Fortune";
    itemNameTable[Fix.FLOW_FUNNEL_OF_THE_ZVELDOZE] = "Flow Funnel of the Zveldose";
    itemNameTable[Fix.EZEKRIEL_IMPRINT_SIGIL_ARMOR] = "Ezekriel the Imprinted-Armor of Sigil";
    itemNameTable[Fix.MERGIZD_DAV_AGITATED_BLADE] = "Mergizd DAV-Agitated Blade";
    itemNameTable[Fix.SHEZL_THE_VENTIEL_DARKMIRAGE_BOOK] = "Shezl the Ventiel-DarkMirage Book";
    itemNameTable[Fix.XEXXER_WORLD_MASTERY_GLOBE] = "Xexxer the World-Mastery Globe";

    // ---------------------------------------------------------------

    FieldInfo[] fields = typeof(Fix).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
    for (int ii = 0; ii < fields.Length; ii++)
    {
      FieldInfo field = fields[ii];
      if (field.FieldType != typeof(string)) { continue; }
      if (field.IsLiteral == false || field.IsInitOnly) { continue; }

      string key = field.GetRawConstantValue() as string;
      if (string.IsNullOrEmpty(key)) { continue; }
      if (itemNameTable.ContainsKey(key)) { continue; }

      itemNameTable[key] = HasJapaneseCharacter(key) ? HumanizeItemIdentifier(field.Name) : key;
    }
  }

  private static bool HasJapaneseCharacter(string value)
  {
    if (string.IsNullOrEmpty(value)) { return false; }

    for (int ii = 0; ii < value.Length; ii++)
    {
      char current = value[ii];
      // Hiragana / Katakana / CJK unified ideographs / Halfwidth katakana.
      if ((current >= '\u3040' && current <= '\u30ff') ||
          (current >= '\u3400' && current <= '\u9fff') ||
          (current >= '\uff66' && current <= '\uff9f'))
      {
        return true;
      }
    }
    return false;
  }

  private static string HumanizeItemIdentifier(string identifier)
  {
    if (string.IsNullOrEmpty(identifier)) { return string.Empty; }

    string[] rawTokens = identifier.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
    List<string> tokens = new List<string>();
    for (int ii = 0; ii < rawTokens.Length; ii++)
    {
      string token = rawTokens[ii];
      int splitIndex = token.Length;
      while (splitIndex > 0 && char.IsDigit(token[splitIndex - 1]))
      {
        splitIndex--;
      }

      if (splitIndex > 0)
      {
        tokens.Add(token.Substring(0, splitIndex));
      }
      if (splitIndex < token.Length)
      {
        tokens.Add(token.Substring(splitIndex));
      }
    }

    HashSet<string> lowerWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
      "A", "AN", "AND", "AS", "AT", "BY", "FOR", "FROM", "IN", "OF", "ON", "OR", "THE", "TO", "WITH"
    };

    for (int ii = 0; ii < tokens.Count; ii++)
    {
      string token = tokens[ii];
      if (string.IsNullOrEmpty(token)) { continue; }
      if (char.IsDigit(token[0])) { continue; }
      if (token.Length == 1)
      {
        tokens[ii] = token.ToUpperInvariant();
      }
      else if (ii > 0 && lowerWords.Contains(token))
      {
        tokens[ii] = token.ToLowerInvariant();
      }
      else
      {
        tokens[ii] = char.ToUpperInvariant(token[0]) + token.Substring(1).ToLowerInvariant();
      }
    }

    return string.Join(" ", tokens.ToArray());
  }
}
