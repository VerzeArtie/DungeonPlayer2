using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public static partial class L10n
{
  private static Dictionary<string, (string ja, string en)> table = new Dictionary<string, (string ja, string en)>(StringComparer.OrdinalIgnoreCase);

  /// <summary>
  /// 説明文中の 【タグ】 の日英対応。Fix の定数ペアを参照しているため、
  /// 定数のリネームや削除はコンパイルエラーになる。
  /// Register の用語ペア引数 Term(...) がここを唯一の定義とし、
  /// Tools\check-l10n.ps1 の検査[5]が説明文中の 【JP】/[EN] の 1:1 対応をここに照らして検証する。
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
    // 略号は L10N_CORE_* と揃える。宿屋の枠は狭く1文字前提の配置だったため、
    // HomeTown.unity 側でラベルの RectTransform を上半分(AnchorMax.y=0.45)に制限し、
    // 3文字略号が中央の数値と重ならないようにしている。
    Register(Fix.L10N_HOMETOWN_INN_STRENGTH, "力", "STR");
    Register(Fix.L10N_HOMETOWN_INN_AGILITY, "技", "AGI");
    Register(Fix.L10N_HOMETOWN_INN_INTELLIGENCE, "知", "INT");
    Register(Fix.L10N_HOMETOWN_INN_STAMINA, "体", "STA");
    Register(Fix.L10N_HOMETOWN_INN_MIND, "心", "MND");
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
    Register(Fix.L10N_QUESTSTART_TITLE, "クエスト【 {0} 】が開始されました！", "Quest 【 {0} 】 started!");
    Register(Fix.L10N_QUESTUPDATE_TITLE, "クエスト【 {0} 】が更新されました！", "Quest 【 {0} 】 updated!");
    // クエスト名。日本語は Fix.QUEST_TITLE_* を唯一の定義とし、ここでは英訳のみを与える。
    Register(Fix.L10N_QUEST_TITLE_1, Fix.QUEST_TITLE_1, "Obtain the Expedition Permit");
    Register(Fix.L10N_QUEST_TITLE_2, Fix.QUEST_TITLE_2, "A Request from King Aermi");
    Register(Fix.L10N_QUEST_TITLE_3, Fix.QUEST_TITLE_3, "Speak with Vasta the Blacksmith");
    Register(Fix.L10N_QUEST_TITLE_4, Fix.QUEST_TITLE_4, "Gather Zetanium Ore");
    Register(Fix.L10N_QUEST_TITLE_5, Fix.QUEST_TITLE_5, "Find the Mattock");
    Register(Fix.L10N_QUEST_TITLE_6, Fix.QUEST_TITLE_6, "Find the Door Key");
    Register(Fix.L10N_QUEST_TITLE_7, Fix.QUEST_TITLE_7, "Defeat the Beast");
    Register(Fix.L10N_QUEST_TITLE_8, Fix.QUEST_TITLE_8, "Guard Against the Poison");
    Register(Fix.L10N_QUEST_TITLE_9, Fix.QUEST_TITLE_9, "An Ominous Presence Within");
    Register(Fix.L10N_QUEST_TITLE_10, Fix.QUEST_TITLE_10, "Investigating the Strange Object");
    Register(Fix.L10N_QUEST_TITLE_11, Fix.QUEST_TITLE_11, "A Request from King Aermi II");
    Register(Fix.L10N_QUEST_TITLE_20, Fix.QUEST_TITLE_20, "A Presence at the Tower Summit");
    Register(Fix.L10N_QUEST_TITLE_21, Fix.QUEST_TITLE_21, "A Request from King Aermi III");
    Register(Fix.L10N_QUEST_TITLE_31, Fix.QUEST_TITLE_31, "A Request from Pontiff Zveldose");
    Register(Fix.L10N_QUEST_TITLE_41, Fix.QUEST_TITLE_41, "A Request from Pontiff Zveldose II");
    Register(Fix.L10N_QUEST_TITLE_23, Fix.QUEST_TITLE_23, "The Red Star Is the Marble Star");
    Register(Fix.L10N_QUESTCOMPLETE_GOLDGAIN, "{0} ゴールドを獲得しました！", "Gain {0} Gold!");
    Register(Fix.L10N_QUESTCOMPLETE_EXPGAIN, "{0} 経験値を獲得しました！", "Gain {0} EXP!");
    Register(Fix.L10N_QUESTCOMPLETE_ITEMGAIN, "【 {0} 】を獲得しました！", "Gain 【 {0} 】!");
    Register(Fix.L10N_QUESTCOMPLETE_PARTY_EONE, "エオネ・フルネアが仲間になりました！", "Eone Fulnea has joined your party!");
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

    // ここから下は Term(Fix.L10N_AREANAME_*) を参照するため、地名の登録より後に置くこと。
    // Register は呼び出し時点でトークンを確定させるため、参照先が未登録だとキー文字列がそのまま残る。
    Register(Fix.L10N_QUEST_TITLE_22, Fix.QUEST_TITLE_22, "Hidden Away: [$0]", Term(Fix.L10N_AREANAME_MYSTIC_FOREST));

    // エリア情報。日本語は Fix.AREA_INFO_* を唯一の定義とし、ここでは英訳のみを与える。
    // 地名は L10N_AREANAME_* を参照し、表記を一箇所で管理する。
    Register(Fix.L10N_AREA_INFO_ANSHET, Fix.AREA_INFO_ANSHET,
      "The town of Anshet prospers quietly downriver, to the south of $0. Few traveling merchants pass through, but the town as a whole is stable, and its people lead peaceful lives.",
      Term(Fix.L10N_AREANAME_FAZIL_CASTLE));
    Register(Fix.L10N_AREA_INFO_ESMILIA_GRASSFIELD, Fix.AREA_INFO_ESMILIA_GRASSFIELD,
      "A game trail running through $0. It is the route by which travelers pass between $1 and the town of Anshet. Monsters appear here, but none of [High] threat, and those who keep to the path seldom meet with danger.",
      Term(Fix.L10N_AREANAME_ESMILIA_GRASSFIELD), Term(Fix.L10N_AREANAME_FAZIL_CASTLE));
    Register(Fix.L10N_AREA_INFO_FAZIL_CASTLE, Fix.AREA_INFO_FAZIL_CASTLE,
      "$0, the seat of King Aermi Jorzt, who governs the whole of the Fazil region. Numerous warp gates stand behind $0, and through them King Aermi Jorzt, Queen Fara Flore, Sinikia Kahlhanz the head of the Academy of Sorcery, Ol Landis the Tyrant of Justice, and Verze Artie the Unseen keep daily watch over the state of every area. That crime is rare throughout Fazil, and that its people live in peace, is owed to their protection and nothing else.",
      Term(Fix.L10N_AREANAME_FAZIL_CASTLE));
    Register(Fix.L10N_AREA_INFO_GORATRUM_CAVE, Fix.AREA_INFO_GORATRUM_CAVE,
      "These enchanting limestone caverns once drew travelers as a sightseeing destination. Little of the limestone formation remains today, and monsters now emerge from the depths of the earth, so ordinary people no longer visit. Anyone who ventures in to explore had best not neglect thorough preparation.");
    Register(Fix.L10N_AREA_INFO_COTUHSYE, Fix.AREA_INFO_COTUHSYE,
      "People of every trade come and go through this port town. King Aermi designated the area as a place of exchange and imposed no restriction on entry, so commerce flourishes here. At present, however, sailings are restricted, and no ship departs from here for the Kingdom of Vinsgarde.");
    Register(Fix.L10N_AREA_INFO_MYSTIC_FOREST, Fix.AREA_INFO_MYSTIC_FOREST,
      "The [$0], which lures those who enter into a deep and abyssal mist. Visibility is poor, and monsters attack again and again, so there is no end to those who lose all sense of direction and vanish for good. Thorough preparation will be needed to press on.",
      Term(Fix.L10N_AREANAME_MYSTIC_FOREST));
    Register(Fix.L10N_AREA_INFO_OHRAN_TOWER, Fix.AREA_INFO_OHRAN_TOWER,
      "From the summit of the tower one can survey the entire continent. When the [$0] was built remains unknown, but it has stood at least since before the Kingdom of Fazil rose to prosperity. No one visits it as a sightseer now; it has become a place overrun with monsters, and is designated as a proving ground where those with combat experience test their skill. To reach the tower top, one must take it on with a certain level of ability and sound judgment.",
      Term(Fix.L10N_AREANAME_OHRAN_TOWER));
    Register(Fix.L10N_AREA_INFO_PARMETYSIA, Fix.AREA_INFO_PARMETYSIA,
      "$0, which oversees the Moonforder region. That region is a snowfield, and it is said that no one travels there from the Fazil area without special cause. The whole of the area is also kept under regular watch by members of the Moonforder cult, and wandering about carelessly is not permitted.",
      Term(Fix.L10N_AREANAME_PARMETYSIA));
    Register(Fix.L10N_AREA_INFO_VELGUS_SEA_TEMPLE, Fix.AREA_INFO_VELGUS_SEA_TEMPLE,
      "The undersea temple of Velgus, which has stood since the distant past. Its name was taken from Verselius Garland Altorius, the figure who discovered the temple in the cult of that era. Every life born into this world is promised the equal favor of the divine, and that favor is shown in the form of the Name of Heaven. Countless patterns are carved into the undersea temple, and what those patterns mean has yet to be deciphered, even with the power of the Moonforder cult. For all that it is said to bestow the Name of Heaven, the undersea temple is in truth a den of monsters. Considerable ability will be required to challenge it.");
    Register(Fix.L10N_AREA_INFO_EDELGARZEN, Fix.AREA_INFO_EDELGARZEN,
      "$0, standing serene and lofty in the Kingdom of Vinsgarde. The castle was built atop the Kilcood mountain range to guard against invasion from other nations and to strengthen watch over other regions. Being impregnable, it has never been assailed, and it radiates an overwhelming presence. Thorough preparation and the strength to act are not enough when setting out for the castle. A certain capacity, and a true temperament, will be required.",
      Term(Fix.L10N_AREANAME_EDELGARZEN_CASTLE));

    // アクションコマンド 対象／タイミング
    // 日本語は Fix.TARGET_TYPE_* / TIMING_TYPE_* と同一。あちらは内部判定用の値であり、
    // 表示はここの対訳を使う。
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

    // コマンド解放／エッセンス獲得の確認ダイアログ
    // {0} にはコマンド名・カテゴリ名が入る。
    Register(Fix.L10N_UNLOCK_FAIL_TITLE, "{0} を解放する事ができません。", "{0} cannot be unlocked.");
    Register(Fix.L10N_UNLOCK_FAIL_SOULFRAGMENT, "ソウル・フラグメントが不足しています。ソウル・フラグメントを入手してください。", "You do not have enough Soul Fragments. Obtain more Soul Fragments.");
    Register(Fix.L10N_UNLOCK_CONFIRM_TITLE, "{0} を解放しますか？", "Unlock {0}?");
    Register(Fix.L10N_UNLOCK_CONFIRM_MESSAGE, "ソウル・フラグメントを１ポイント消費します。この操作は元に戻せません。", "This consumes 1 Soul Fragment. This action cannot be undone.");
    Register(Fix.L10N_UNLOCK_BLOCK_TITLE, "{0} を解放する条件を満たしていません。", "{0} does not meet the requirements to be unlocked.");
    Register(Fix.L10N_UNLOCK_BLOCK_MESSAGE, "このコマンドを解放するためには、{0}を解放する必要があります", "To unlock this command, you must first unlock {0}.");
    Register(Fix.L10N_REINFORCE_FAIL_TITLE, "{0} を強化する事ができません。", "{0} cannot be reinforced.");
    Register(Fix.L10N_REINFORCE_CONFIRM_TITLE, "{0} を強化しますか？", "Reinforce {0}?");
    Register(Fix.L10N_ESSENCE_FAIL_TITLE, "{0} を獲得する事ができません。", "{0} cannot be obtained.");
    Register(Fix.L10N_ESSENCE_FAIL_MESSAGE, "エッセンス・ポイントが不足しています。エッセンス・ポイントを入手してください。", "You do not have enough Essence Points. Obtain more Essence Points.");
    Register(Fix.L10N_ESSENCE_CONFIRM_TITLE, "{0}を獲得しますか？", "Obtain {0}?");
    Register(Fix.L10N_ESSENCE_CONFIRM_MESSAGE, "エッセンス・ポイントを１ポイント消費して獲得します。この操作は元に戻せません。", "This consumes 1 Essence Point. This action cannot be undone.");
    Register(Fix.L10N_MYSTICFOREST_WARNING, "【$0】はダンジョンエリアとなります。全滅した場合はゴールドが失われます。", "[$0] is a dungeon area. If your party is wiped out, you will lose gold.",
      Term(Fix.L10N_AREANAME_MYSTIC_FOREST));

    // 宿屋の料理名
    // 日本語は Fix.FOOD_* を唯一の定義とし、ここでは英訳のみを与える。
    // 分岐判定は Fix.FOOD_* のキーで行うため(HomeTown.GetFoodKey)、英訳は動作に影響しない。
    Register(Fix.L10N_FOOD_BALANCE_SET, Fix.FOOD_BALANCE_SET, "Balanced Set Meal");
    Register(Fix.L10N_FOOD_LARGE_GOHAN_SET, Fix.FOOD_LARGE_GOHAN_SET, "Heaping Rice Set");
    Register(Fix.L10N_FOOD_TSIKARA_UDON, Fix.FOOD_TSIKARA_UDON, "Hearty Chikara Udon");
    Register(Fix.L10N_FOOD_ZUNOU_FLY_SET, Fix.FOOD_ZUNOU_FLY_SET, "Brain-Boost Fry Set Meal");
    Register(Fix.L10N_FOOD_SPEED_SOBA, Fix.FOOD_SPEED_SOBA, "Endless Egg Soba");
    Register(Fix.L10N_FOOD_KATUCARRY, Fix.FOOD_KATUCARRY, "Fiery Katsu Curry Set Meal");
    Register(Fix.L10N_FOOD_OLIVE_AND_ONION, Fix.FOOD_OLIVE_AND_ONION, "Olive Bread and Onion Soup");
    Register(Fix.L10N_FOOD_INAGO_AND_TAMAGO, Fix.FOOD_INAGO_AND_TAMAGO, "Candied Locust and Egg Set Meal");
    Register(Fix.L10N_FOOD_USAGI, Fix.FOOD_USAGI, "Rabbit Stew");
    Register(Fix.L10N_FOOD_SANMA, Fix.FOOD_SANMA, "Saury Set Meal (with Simmered Side)");
    Register(Fix.L10N_FOOD_FISH_GURATAN, Fix.FOOD_FISH_GURATAN, "Fish Gratin");
    Register(Fix.L10N_FOOD_SEA_TENPURA, Fix.FOOD_SEA_TENPURA, "Crispy Seafood Tempura");
    Register(Fix.L10N_FOOD_TRUTH_YAMINABE_1, Fix.FOOD_TRUTH_YAMINABE_1, "Hotpot of Truth (Part 1)");
    Register(Fix.L10N_FOOD_OSAKANA_ZINGISKAN, Fix.FOOD_OSAKANA_ZINGISKAN, "Fish Jingisukan");
    Register(Fix.L10N_FOOD_RED_HOT_SPAGHETTI, Fix.FOOD_RED_HOT_SPAGHETTI, "Red Hot Spaghetti");
    Register(Fix.L10N_FOOD_TOBIUSAGI_ROAST, Fix.FOOD_TOBIUSAGI_ROAST, "Roast Jackrabbit Set Meal");
    Register(Fix.L10N_FOOD_WATARI_KAMONABE, Fix.FOOD_WATARI_KAMONABE, "Migratory Duck Hotpot");
    Register(Fix.L10N_FOOD_SYOI_KINOKO_SUGATAYAKI, Fix.FOOD_SYOI_KINOKO_SUGATAYAKI, "Whole-Grilled Packmushroom");
    Register(Fix.L10N_FOOD_NEGIYAKI_DON, Fix.FOOD_NEGIYAKI_DON, "Grilled Scallion Don");
    Register(Fix.L10N_FOOD_NANAIRO_BUNA_NITSUKE, Fix.FOOD_NANAIRO_BUNA_NITSUKE, "Simmered Rainbow Beech Fish");
    Register(Fix.L10N_FOOD_HINYARI_YASAI, Fix.FOOD_HINYARI_YASAI, "Chilled Crispy Vegetable Set Meal");
    Register(Fix.L10N_FOOD_AZARASI_SHIOYAKI, Fix.FOOD_AZARASI_SHIOYAKI, "Salt-Grilled White Seal");
    Register(Fix.L10N_FOOD_WINTER_BEEF_CURRY, Fix.FOOD_WINTER_BEEF_CURRY, "Winter Beef Curry");
    Register(Fix.L10N_FOOD_GATTURI_GOZEN, Fix.FOOD_GATTURI_GOZEN, "Hearty Bone-Deep Feast");
    Register(Fix.L10N_FOOD_KOGOERU_DESSERT, Fix.FOOD_KOGOERU_DESSERT, "Bone-Chilling Blue Dessert");
    Register(Fix.L10N_FOOD_BLACK_BUTTER_SPAGHETTI, Fix.FOOD_BLACK_BUTTER_SPAGHETTI, "Black Butter Spaghetti");
    Register(Fix.L10N_FOOD_KOROKORO_PIENUS_HAMBURG, Fix.FOOD_KOROKORO_PIENUS_HAMBURG, "Peanut-Studded Hamburg Steak");
    Register(Fix.L10N_FOOD_PIRIKARA_HATIMITSU_STEAK, Fix.FOOD_PIRIKARA_HATIMITSU_STEAK, "Spicy Honey Steak Set Meal");
    Register(Fix.L10N_FOOD_HUNWARI_ORANGE_TOAST, Fix.FOOD_HUNWARI_ORANGE_TOAST, "Fluffy Orange Toast");
    Register(Fix.L10N_FOOD_TRUTH_YAMINABE_2, Fix.FOOD_TRUTH_YAMINABE_2, "Hotpot of Truth (Part 2)");

    // 宿屋の料理説明
    // 日本語は Fix.DESC_*_MINI を唯一の定義とし、ここでは英訳のみを与える。
    Register(Fix.L10N_DESC_FOOD_01, Fix.DESC_01_MINI, "A set meal designed with your health in mind. Its calorie balance is well considered, and the flavor keeps locals coming back.");
    Register(Fix.L10N_DESC_FOOD_02, Fix.DESC_02_MINI, "The perfect rice set for filling up. On top of the heaping mound of rice, it comes loaded with side dishes that build plenty of stamina, making it a favorite among certain customers.");
    Register(Fix.L10N_DESC_FOOD_03, Fix.DESC_03_MINI, "If you want to build strength, start with this udon set. There is no particular reason for it, but people swear they feel highly motivated the day after eating it.");
    Register(Fix.L10N_DESC_FOOD_04, Fix.DESC_04_MINI, "Rabbit meat wrapped in sun leaves and slowly deep-fried. The flavor is rich and distinctive. Rumor has it that eating this fires up your brain and raises your intelligence.");
    Register(Fix.L10N_DESC_FOOD_05, Fix.DESC_05_MINI, "Egg soba that keeps getting refilled no matter how much you eat. The combination is superb and never gets old. Unless you call a stop partway, you will keep eating forever, so knowing when to quit is everything.");
    Register(Fix.L10N_DESC_FOOD_11, Fix.DESC_11_MINI, "S-so spicy!! But so good!!\r\n　Hanna apparently adjusts the heat for every customer.");
    Register(Fix.L10N_DESC_FOOD_12, Fix.DESC_12_MINI, "Onion soup with a faint aroma of olive, prepared with a light touch. It proved so popular that it became one of the standard menu items.");
    Register(Fix.L10N_DESC_FOOD_13, Fix.DESC_13_MINI, "The taste itself is exquisite and the texture is excellent. The only problem is how it looks...");
    Register(Fix.L10N_DESC_FOOD_14, Fix.DESC_14_MINI, "The gaminess unique to rabbit has been removed while the savory richness of the meat remains. It is quite chewy, but the more you chew, the more flavor comes out.");
    Register(Fix.L10N_DESC_FOOD_15, Fix.DESC_15_MINI, "It brings out the natural flavor of the fish, and pairs remarkably well with the simmered side.");
    Register(Fix.L10N_DESC_FOOD_21, Fix.DESC_21_MINI, "A gratin scattered with finely sliced fresh seafood.");
    Register(Fix.L10N_DESC_FOOD_22, Fix.DESC_22_MINI, "The gaminess unique to seafood has been completely removed, finished as a high-quality tempura. Size, tenderness, and heartiness are all beyond reproach, and you can eat your fill.");
    Register(Fix.L10N_DESC_FOOD_23, Fix.DESC_23_MINI, "Truth lurks within the darkness. The taste, at least, is said to be guaranteed...");
    Register(Fix.L10N_DESC_FOOD_24, Fix.DESC_24_MINI, "A jingisukan so chewy you would never guess it was fish. It leaves a pleasant aftertaste and a flavor you will want again and again.");
    Register(Fix.L10N_DESC_FOOD_25, Fix.DESC_25_MINI, "Bright red spaghetti, yet apparently not spicy at all.\r\n　They make full use of the ingredients' natural colors, with no coloring added.");
    Register(Fix.L10N_DESC_FOOD_31, Fix.DESC_31_MINI, "Rabbit thigh slowly grilled over a low flame and finished with a sauce passed down in secret at $0. The fluffy texture makes it addictively delicious.",
      Term(Fix.L10N_AREANAME_ZHALMAN));
    Register(Fix.L10N_DESC_FOOD_32, Fix.DESC_32_MINI, "Migratory ducks are a common catch in the hunts held near the village. The duck's lower legs are cut away and simmered in a pot with a wide variety of vegetables. The finished pot gives off a pleasant, savory aroma that whets the appetite.");
    Register(Fix.L10N_DESC_FOOD_33, Fix.DESC_33_MINI, "A rare dish of a whole packmushroom grilled in a stone oven. The texture is surprisingly crunchy, and one bite makes it hard to stop.");
    Register(Fix.L10N_DESC_FOOD_34, Fix.DESC_34_MINI, "A mountain of scallions grilled boldly on a searing iron plate. Piled onto a huge rice bowl, and order up!");
    Register(Fix.L10N_DESC_FOOD_35, Fix.DESC_35_MINI, "Very little of the rainbow beech fish is actually edible, even after cooking. Simmered over several days, its savory depth is drawn out to its finest.");
    Register(Fix.L10N_DESC_FOOD_51, Fix.DESC_51_MINI, "Vegetable tempura fried crisp in tempura batter.\r\nThe aroma and crunch are so pronounced you forget you are eating vegetables.");
    Register(Fix.L10N_DESC_FOOD_52, Fix.DESC_52_MINI, "The ultimate dish: tough, unpleasantly chewy seal meat thoroughly tenderized, then frozen, grilled, and dusted with salt.");
    Register(Fix.L10N_DESC_FOOD_53, Fix.DESC_53_MINI, "Curry rice made with beef firmed up by the sharp temperature swings of winter. Not a trace of gaminess.");
    Register(Fix.L10N_DESC_FOOD_54, Fix.DESC_54_MINI, "Meat, fish, beans, miso soup, rice, and green tea. A well-balanced set meal with everything you need.\r\nAunt Hanna's pride and joy.");
    Register(Fix.L10N_DESC_FOOD_55, Fix.DESC_55_MINI, "Such blueness... just looking at it could freeze you.\r\n　The sensation that fills your mouth when you eat it is that of a first-class dessert.");
    Register(Fix.L10N_DESC_FOOD_61, Fix.DESC_61_MINI, "Pitch-black spaghetti.\r\nIt looks rather ominous... but gives off a spiced aroma.");
    Register(Fix.L10N_DESC_FOOD_62, Fix.DESC_62_MINI, "Finely chopped peanuts are mixed into the hamburg steak.\r\nThe fluffy, juicy meat and the crunchy peanuts together whet the appetite.");
    Register(Fix.L10N_DESC_FOOD_63, Fix.DESC_63_MINI, "A fillet steak topped with bright red chili peppers.\r\nHidden beneath is a subtle touch of honey, so heat and sweetness ring out together for whoever eats it.");
    Register(Fix.L10N_DESC_FOOD_64, Fix.DESC_64_MINI, "When it comes to the most popular toast set, this orange toast is it.\r\nThe enormous slice, generously spread with orange jam and topped with white cream, is a favorite regardless of who you ask.");
    Register(Fix.L10N_DESC_FOOD_65, Fix.DESC_65_MINI, "A pot of darkness with no smell of food at all.\r\n　Aunt Hanna says the good stuff is definitely in there. You have no choice but to believe her and eat.");

    // クエスト説明文
    // 日本語は Fix.QUEST_DESC_* を唯一の定義とし、ここでは英訳のみを与える。
    // 地名は L10N_AREANAME_* を参照し、表記を一箇所で管理する。
    Register(Fix.L10N_QUEST_DESC_1, Fix.QUEST_DESC_1,
      "Head for $0 and obtain an expedition permit. To reach $0 you must pass through $1. Set out once you have made your preparations.",
      Term(Fix.L10N_AREANAME_FAZIL_CASTLE), Term(Fix.L10N_AREANAME_ESMILIA_GRASSFIELD));
    Register(Fix.L10N_QUEST_DESC_2, Fix.QUEST_DESC_2,
      "Upon receiving the domestic and foreign expedition permit, King Aermi asked you to travel to $0 in the Fazil region and investigate. $0 lies along the coast east of the Fazil region, but you must pass through $1 on the way. Break through $1 and reach $0.",
      Term(Fix.L10N_AREANAME_COTUHSYE), Term(Fix.L10N_AREANAME_GORATRUM_CAVE));
    Register(Fix.L10N_QUEST_DESC_2_2, Fix.QUEST_DESC_2_2,
      "Arriving at $0, Ein and the others joined up with the mercenary Billy Laki and resolved to head for the $1. No detailed information about the $1 has surfaced yet, but Ein sensed they would find it by continuing this journey.",
      Term(Fix.L10N_AREANAME_COTUHSYE), Term(Fix.L10N_AREANAME_MYSTIC_FOREST));
    Register(Fix.L10N_QUEST_DESC_2_3, Fix.QUEST_DESC_2_3,
      "Ein and the others reached $0 and were speaking with the village elder, only to be abruptly turned away partway through. Immediately after, a messenger relayed orders to return to $1 once. Having lost their destination, Ein followed the messenger for now, returning to $1 to report the whole affair to the king.",
      Term(Fix.L10N_AREANAME_ZHALMAN), Term(Fix.L10N_AREANAME_FAZIL_CASTLE));
    Register(Fix.L10N_QUEST_DESC_3, Fix.QUEST_DESC_3,
      "Go and meet the blacksmith Vasta. Vasta lives in Qvelta Town, straight east of $0.",
      Term(Fix.L10N_AREANAME_FAZIL_CASTLE));
    Register(Fix.L10N_QUEST_DESC_4, Fix.QUEST_DESC_4,
      "You have been asked to gather 5 pieces of zetanium ore. The ore appears to be somewhere in the Artharium Factory Ruins. Gather it, if only to uncover the identity of the mysterious item.");
    Register(Fix.L10N_QUEST_DESC_5, Fix.QUEST_DESC_5,
      "Eone Fulnea told you that a mattock lies somewhere in the Artharium Factory Ruins. Search every corner of the ruins and find it. With the mattock you should be able to break through the rock wall.");
    Register(Fix.L10N_QUEST_DESC_6, Fix.QUEST_DESC_6,
      "While advancing through the passages of the Artharium Factory Ruins, you found a large door. It is locked, and opening it will be difficult without a key. The key must be somewhere within the ruins. Go look for it.");
    Register(Fix.L10N_QUEST_DESC_7, Fix.QUEST_DESC_7,
      "A sign at the entrance to the narrow passage read: \"Ferocious creatures have appeared deep in this area. This passage is to be sealed at once.\"\r\n\r\nUnusually powerful monsters may be lying in wait. Explore this area with caution.");
    Register(Fix.L10N_QUEST_DESC_8, Fix.QUEST_DESC_8,
      "While exploring the Artharium Factory Ruins, you discovered an area filled with poison. You cannot venture further into this area without a countermeasure. Go find an item that protects against poison. It should be somewhere in the section where you found the mattock.");
    Register(Fix.L10N_QUEST_DESC_9, Fix.QUEST_DESC_9,
      "After unlocking the door in the central passage, the whole party sensed an extraordinary atmosphere. Something is clearly waiting ahead. Ein and the others are steeling themselves to press deeper. It would be wise to prepare thoroughly before facing it.");
    Register(Fix.L10N_QUEST_DESC_10, Fix.QUEST_DESC_10,
      "After defeating the boss of the Artharium Factory Ruins, you obtained a strange object in its depths. What this item signifies is entirely unknown, and it cannot be analyzed here. Deciding to settle on a plan for investigating it, Ein chose to return to Qvelta Town for now. Return to Qvelta Town and speak with your party members.");
    Register(Fix.L10N_QUEST_DESC_11, Fix.QUEST_DESC_11,
      "Having returned from $0 to $1, Ein and the others received their next order: travel to the $2 and survey the continent. The $2 appears to lie northeast of $1. Head northeast and make for the $2.",
      Term(Fix.L10N_AREANAME_ZHALMAN), Term(Fix.L10N_AREANAME_FAZIL_CASTLE), Term(Fix.L10N_AREANAME_OHRAN_TOWER));
    Register(Fix.L10N_QUEST_DESC_11_2, Fix.QUEST_DESC_11_2,
      "Reaching the top floor of the $0, you surveyed the continent from the observation deck and gathered a variety of information about its situation. To convey this to the king, Ein returns to $1 and confers with King Aermi in the audience chamber.",
      Term(Fix.L10N_AREANAME_OHRAN_TOWER), Term(Fix.L10N_AREANAME_FAZIL_CASTLE));
    Register(Fix.L10N_QUEST_DESC_20, Fix.QUEST_DESC_20,
      "On the stairs leading to the top floor of the $0, the whole party felt an alien wind flowing in. There is no doubt that something waits ahead. It would be wise to prepare thoroughly before facing it.",
      Term(Fix.L10N_AREANAME_OHRAN_TOWER));
    Register(Fix.L10N_QUEST_DESC_21, Fix.QUEST_DESC_21,
      "You reported to the king what was seen from the $0. King Aermi gave the next order: make for $1 in the Moonforder region. Having made their preparations, Ein and the others head for $1.",
      Term(Fix.L10N_AREANAME_OHRAN_TOWER), Term(Fix.L10N_AREANAME_PARMETYSIA));
    Register(Fix.L10N_QUEST_DESC_21_2, Fix.QUEST_DESC_21_2,
      "Having arrived at Arcanedine Town, Ein and the others decided to begin asking around at once. Make a full round of Arcanedine Town and talk with its people.");
    Register(Fix.L10N_QUEST_DESC_31, Fix.QUEST_DESC_31,
      "The pontiff of $0 asked you to travel to the $1 and obtain the Name of Heaven. Steeling himself, Ein sets out for the $1. By receiving the Name of Heaven there, Ein may come to understand the unease he has felt all this time. Believing so, he presses on.",
      Term(Fix.L10N_AREANAME_PARMETYSIA), Term(Fix.L10N_AREANAME_VELGUS_SEA_TEMPLE));
    Register(Fix.L10N_QUEST_DESC_41, Fix.QUEST_DESC_41,
      "Having received the Name of Heaven, Ein was granted an audience with Pontiff Zveldose and asked to head for $0 in the Kingdom of Vinsgarde. Through his encounters with the Obsidian Stone, Ein is close to reaching a single conclusion. Resolved to accept everything that awaits him at $0, Ein sets out.",
      Term(Fix.L10N_AREANAME_EDELGARZEN_CASTLE));
    Register(Fix.L10N_QUEST_DESC_22, Fix.QUEST_DESC_22,
      "From townspeople crossing the central fountain plaza of Arcanedine Town, you learned that a trade route once existed between Arcanedine Town and $0. The route was apparently the very road Ein and the others had travelled. In those days, rumor held that an inviolable domain, the $1, lay deep beyond $0. Whether the $1 still exists is uncertain, but visiting $0 once more may reveal the answer. Go to $0 and speak with the elder again.",
      Term(Fix.L10N_AREANAME_ZHALMAN), Term(Fix.L10N_AREANAME_MYSTIC_FOREST));
    Register(Fix.L10N_QUEST_DESC_22_2, Fix.QUEST_DESC_22_2,
      "When you asked the elder in $0 about the $1, it turned out to be managed as a sacred place, and Ein and the others were not permitted to enter. However, the elder assigned an errand to a man named Adel Brigandi, and granted permission on the condition that they accompany him. Explore the $1 together with Adel Brigandi. Surely something will be found.",
      Term(Fix.L10N_AREANAME_ZHALMAN), Term(Fix.L10N_AREANAME_MYSTIC_FOREST));
    Register(Fix.L10N_QUEST_DESC_23, Fix.QUEST_DESC_23,
      "When Ein asked about the red star at the Fortune House: Aminda in Arcanedine Town, the fortune teller offered him a Marble Star. What this item is used for is uncertain, but Ein was advised to visit the Ruins of Saritan regarding it. Search for the Ruins of Saritan and gather information about this item.");

    // ダンジョン内の選択肢
    // 心の解(ヴェルガス海底神殿)の設問文。選択肢は物語のキーワードのため原文のまま残す。
    Register(Fix.L10N_CHOICE_REVEAL_PROMPT, "どのような内容を示すか選択してください。", "Choose what to reveal.");
    // 心の解の選択肢18項目 ---------------------------------------------
    // 訳出が未確定のため、英語側も日本語原文のまま登録している。
    // 「日英対応が必要だが英訳が未了」であることを明示するのが目的であり、
    // 対応漏れではない。訳語が決まり次第、第3引数のみ差し替えること。
    // 検査 [6] が英語側に日本語が残る登録として一覧表示する。
    Register(Fix.L10N_CHOICE_JUDGE_1_A, "破壊の心を示す", "破壊の心を示す");
    Register(Fix.L10N_CHOICE_JUDGE_1_B, "慈愛の心を示す", "慈愛の心を示す");
    Register(Fix.L10N_CHOICE_JUDGE_1_C, "何も心を示さない", "何も心を示さない");
    Register(Fix.L10N_CHOICE_JUDGE_2_A, "過去の自分自身をイメージする", "過去の自分自身をイメージする");
    Register(Fix.L10N_CHOICE_JUDGE_2_B, "未来の自分自身をイメージする", "未来の自分自身をイメージする");
    Register(Fix.L10N_CHOICE_JUDGE_2_C, "現在の自分自身をイメージする", "現在の自分自身をイメージする");
    Register(Fix.L10N_CHOICE_JUDGE_3_A, "神々からの意志", "神々からの意志");
    Register(Fix.L10N_CHOICE_JUDGE_3_B, "人々による意志", "人々による意志");
    Register(Fix.L10N_CHOICE_JUDGE_3_C, "意志からの脱却", "意志からの脱却");
    Register(Fix.L10N_CHOICE_JUDGE_4_A, "生命そのもの", "生命そのもの");
    Register(Fix.L10N_CHOICE_JUDGE_4_B, "波動そのもの", "波動そのもの");
    Register(Fix.L10N_CHOICE_JUDGE_4_C, "存在しえない", "存在しえない");
    Register(Fix.L10N_CHOICE_JUDGE_5_A, "同一であり相反である", "同一であり相反である");
    Register(Fix.L10N_CHOICE_JUDGE_5_B, "対称的であり排他的である", "対称的であり排他的である");
    Register(Fix.L10N_CHOICE_JUDGE_5_C, "絶対的な円環", "絶対的な円環");
    Register(Fix.L10N_CHOICE_JUDGE_6_A, "古来より定められし絶対根源法則", "古来より定められし絶対根源法則");
    Register(Fix.L10N_CHOICE_JUDGE_6_B, "時空変化し続ける万物の色空", "時空変化し続ける万物の色空");
    Register(Fix.L10N_CHOICE_JUDGE_6_C, "全ての因果関係を示す無限連鎖", "全ての因果関係を示す無限連鎖");
    // -----------------------------------------------------------------
    // 崖・扉・仲間加入
    Register(Fix.L10N_CHOICE_CLIFF_DOWN_MSG, "崖を降りるかどうかを決めてください。", "Decide whether to climb down the cliff.");
    Register(Fix.L10N_CHOICE_CLIFF_DOWN_A, "崖を降りる", "Climb down");
    Register(Fix.L10N_CHOICE_TURN_BACK, "引き返す", "Turn back");
    Register(Fix.L10N_CHOICE_CLIFF_RETURN_MSG, "崖を降りて元の通路へ戻るかどうかを決めてください。", "Decide whether to climb down the cliff and return to the original passage.");
    Register(Fix.L10N_CHOICE_CLIFF_RETURN_A, "崖を降りて元の通路へ戻る。", "Climb down and return");
    Register(Fix.L10N_CHOICE_CLIFF_RETURN_B, "引き返して他の場所を探す", "Turn back and search elsewhere");
    Register(Fix.L10N_CHOICE_BREAK_DOOR_MSG, "扉を蹴破って進むかどうかを決めてください。", "Decide whether to break down the door and proceed.");
    Register(Fix.L10N_CHOICE_BREAK_DOOR_A, "扉を蹴破る", "Break down the door");
    Register(Fix.L10N_CHOICE_RECRUIT_TITLE, "セルモイ・ロウに50000G支払い、仲間に引き入れますか？", "Pay 50,000G to recruit Selmoi Rou?");
    Register(Fix.L10N_CHOICE_RECRUIT_MSG, "50000G支払う事で、セルモイ・ロウを仲間にする事が出来ます。50000G持っていない場合は仲間にする事は出来ません。", "Paying 50,000G lets you recruit Selmoi Rou. You cannot recruit him without 50,000G.");
    Register(Fix.L10N_CHOICE_RECRUIT_YES, "仲間にする", "Recruit");
    Register(Fix.L10N_CHOICE_RECRUIT_NO, "仲間にしない", "Do not recruit");
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

    // アイテム名は件数が多いため別ファイル (HomeTown.Localization.ItemName.cs) に分けている。
    RegisterItemNames();
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

  /// <summary>
  /// クエストID (Fix.QUEST_ID_*) から表示用のクエスト名を得る。
  /// 進行フラグの判定は呼び出し側でIDに対して行うこと。本メソッドの戻り値を条件に使ってはならない。
  /// </summary>
  public static string GetQuestTitle(string quest_id)
  {
    // クエスト一覧の空枠 (SeekerMode) では空文字が渡る。
    if (String.IsNullOrEmpty(quest_id)) { return String.Empty; }
    if (quest_id == Fix.QUEST_ID_1) { return Get(Fix.L10N_QUEST_TITLE_1); }
    if (quest_id == Fix.QUEST_ID_2) { return Get(Fix.L10N_QUEST_TITLE_2); }
    if (quest_id == Fix.QUEST_ID_3) { return Get(Fix.L10N_QUEST_TITLE_3); }
    if (quest_id == Fix.QUEST_ID_4) { return Get(Fix.L10N_QUEST_TITLE_4); }
    if (quest_id == Fix.QUEST_ID_5) { return Get(Fix.L10N_QUEST_TITLE_5); }
    if (quest_id == Fix.QUEST_ID_6) { return Get(Fix.L10N_QUEST_TITLE_6); }
    if (quest_id == Fix.QUEST_ID_7) { return Get(Fix.L10N_QUEST_TITLE_7); }
    if (quest_id == Fix.QUEST_ID_8) { return Get(Fix.L10N_QUEST_TITLE_8); }
    if (quest_id == Fix.QUEST_ID_9) { return Get(Fix.L10N_QUEST_TITLE_9); }
    if (quest_id == Fix.QUEST_ID_10) { return Get(Fix.L10N_QUEST_TITLE_10); }
    if (quest_id == Fix.QUEST_ID_11) { return Get(Fix.L10N_QUEST_TITLE_11); }
    if (quest_id == Fix.QUEST_ID_20) { return Get(Fix.L10N_QUEST_TITLE_20); }
    if (quest_id == Fix.QUEST_ID_21) { return Get(Fix.L10N_QUEST_TITLE_21); }
    if (quest_id == Fix.QUEST_ID_31) { return Get(Fix.L10N_QUEST_TITLE_31); }
    if (quest_id == Fix.QUEST_ID_41) { return Get(Fix.L10N_QUEST_TITLE_41); }
    if (quest_id == Fix.QUEST_ID_22) { return Get(Fix.L10N_QUEST_TITLE_22); }
    if (quest_id == Fix.QUEST_ID_23) { return Get(Fix.L10N_QUEST_TITLE_23); }
    Debug.LogError("L10n.GetQuestTitle: 未知のクエストIDを参照しました quest_id=" + quest_id);
    return quest_id;
  }

  public static string GetDisplayName(string key)
  {
    if (string.IsNullOrEmpty(key)) { return string.Empty; }

    if (table.ContainsKey(key))
    {
      return Get(key);
    }

    // 未登録なら日本語のまま返す。
    // 以前はここで Fix の定数名から機械生成した英語を返していたが (ABSENCE_MOAI_JP -> "Absence Moai Jp")、
    // 品質が保証できず定数名の接尾辞まで露出するため廃止した。訳が要るものは RegisterItemName で登録する。
    return key;
  }

  public static string GetItemName(string key)
  {
    return GetDisplayName(key);
  }



}
