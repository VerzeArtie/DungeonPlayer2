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

  static L10n()
  {
    // Title
    Register(Fix.L10N_TITLE_GAMESTART, "Game Start", "Game Start"); // Fix
    Register(Fix.L10N_TITLE_LOAD, "Load Game", "Load Game"); // Fix
    Register(Fix.L10N_TITLE_CONFIG, "Config", "Config"); // Fix
    Register(Fix.L10N_TITLE_PRIVACYPOLICY, "Privacy Policy", "Privacy Policy"); // Fix
    Register(Fix.L10N_TITLE_EXIT, "Exit", "Exit"); // Fix
    Register(Fix.L10N_TITLE_OBSIDIAN_PORTAL, "Obsidian Portal", "Obsidian Portal"); // Fix
    Register(Fix.L10N_TITLE_OP_GAMESTART, "Game Start", "Game Start"); // Fix
    Register(Fix.L10N_TITLE_OP_LOAD, "Load Game", "Load Game"); // Fix
    Register(Fix.L10N_TITLE_OP_CONFIG, "Config", "Config"); // Fix
    Register(Fix.L10N_TITLE_OP_PRIVACYPOLICY, "Privacy Policy", "Privacy Policy"); // Fix
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
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_STRENGTH, "{0} の【力】パラメタが {1} 上昇した！", "{0} 's 【Strength】 parameter increased by {1}!");
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_AGILITY, "{0} の【技】パラメタが {1} 上昇した！", "{0} 's 【Agility】 parameter increased by {1}!");
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_INTELLIGENCE, "{0} の【知】パラメタが {1} 上昇した！", "{0} 's 【Intelligence】 parameter increased by {1}!");
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_STAMINA, "{0} の【体】パラメタが {1} 上昇した！", "{0} 's 【Stamina】 parameter increased by {1}!");
    Register(Fix.L10N_PARTYMENU_ITEM_LIQUID_MIND, "{0} の【心】パラメタが {1} 上昇した！", "{0} 's 【Mind】 parameter increased by {1}!");
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
    // Common-CoreParameter
    Register(Fix.L10N_CORE_STRENGTH, "力", "STR");
    Register(Fix.L10N_CORE_AGILITY, "技", "AGL");
    Register(Fix.L10N_CORE_INTELLIGENCE, "知", "INT");
    Register(Fix.L10N_CORE_STAMINA, "体", "STM");
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
  }

  public static void Register(string key, string japanese, string english)
  {
    table[key] = (japanese, english);
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
      new string[] { "敵一体、または味方一体を対象とする。", "Targets one enemy or one ally. " },
      new string[] { "敵味方全員を対象とする。", "Targets all combatants. " },
      new string[] { "敵グループを対象とする。", "Targets an enemy group. " },
      new string[] { "敵一体を対象とする。", "Targets one enemy. " },
      new string[] { "味方一体を対象とする。", "Targets one ally. " },
      new string[] { "自分自身を対象とする。", "Targets self. " },
      new string[] { "自分自身を対象として", "Targets self and " },
      new string[] { "敵全体に対して", "Deals damage to all enemies and " },
      new string[] { "敵全体に", "To all enemies " },
      new string[] { "味方全員に", "To all allies " },
      new string[] { "味方全員の", "All allies' " },
      new string[] { "敵全員に", "To all enemies " },
      new string[] { "敵単体 / 味方単体", "Single Enemy / Single Ally" },
      new string[] { "敵味方全体", "All Combatants" },
      new string[] { "敵フィールド", "Enemy Field" },
      new string[] { "味方フィールド", "Ally Field" },
      new string[] { "敵全体", "All Enemies" },
      new string[] { "味方全体", "All Allies" },
      new string[] { "敵単体", "Single Enemy" },
      new string[] { "味方単体", "Single Ally" },
      new string[] { "インスタント対象", "Instant Target" },
      new string[] { "自分自身", "Self" },
      new string[] { "インスタント", "Instant" },
      new string[] { "ノーマル", "Normal" },
      new string[] { "ソーサリー", "Sorcery" },
      new string[] { "(なし)", "(None)" },
      new string[] { "なし", "None" },
      new string[] { "威力 ", "Power " },
      new string[] { "追加【炎】の威力 ", "Extra [Fire] Power " },
      new string[] { "ライフの回復量 ", "Life Recovery " },
      new string[] { "ライフ回復量 ", "Life Recovery " },
      new string[] { "最大ライフの増加量 ", "Max Life Increase " },
      new string[] { "最大ライフ", "Max Life" },
      new string[] { "回復量 ", "Recovery " },
      new string[] { "増加量 ", "Increase " },
      new string[] { "減少量 ", "Reduction " },
      new string[] { "継続ターン数 ", "Duration " },
      new string[] { "ターン持続数 ", "Duration " },
      new string[] { "攻撃回数 ", "Hits " },
      new string[] { "累積カウンター数 ", "Stack Count " },
      new string[] { "ＭＰ消費 ", "MP Cost " },
      new string[] { "ＭＰ消費　", "MP Cost " },
      new string[] { "ＳＰ消費 ", "SP Cost " },
      new string[] { "ＳＰ回復量 ", "SP Recovery " },
      new string[] { "インスタンスゲージ進行 ", "Instant Gauge " },
      new string[] { "自分の行動ゲージ進行率 ", "Own Action Gauge " },
      new string[] { "敵の行動ゲージ後退率 ", "Enemy Action Gauge Down " },
      new string[] { "物理攻撃／魔法攻撃の増加量 ", "Physical Attack / Magic Attack Increase " },
      new string[] { "物理防御／魔法防御／戦闘反応の減少量 ", "Physical Defense / Magic Defense / Battle Response Reduction " },
      new string[] { "物理／魔法防御の増加量 ", "Physical / Magic Defense Increase " },
      new string[] { "物理防御を無視する量 ", "Physical Defense Ignore " },
      new string[] { "物理防御ＤＯＷＮ影響 ", "Physical Defense Down Effect " },
      new string[] { "物理防御の増加量 ", "Physical Defense Increase " },
      new string[] { "物理防御の減少量 ", "Physical Defense Reduction " },
      new string[] { "物理攻撃の減少量 ", "Physical Attack Reduction " },
      new string[] { "魔法防御の減少量 ", "Magic Defense Reduction " },
      new string[] { "戦闘速度の増加量 ", "Battle Speed Increase " },
      new string[] { "戦闘反応の増加量 ", "Battle Response Increase " },
      new string[] { "潜在能力の増加量 ", "Potential Increase " },
      new string[] { "クリティカル発生率 +", "Critical Rate +" },
      new string[] { "対象へのダメージの威力 ", "Target Damage Power " },
      new string[] { "周囲全体への威力 ", "Surrounding Damage Power " },
      new string[] { "【力】", "[Strength]" },
      new string[] { "【技】", "[Agility]" },
      new string[] { "【知】", "[Intelligence]" },
      new string[] { "【体】", "[Stamina]" },
      new string[] { "【心】", "[Mind]" },
      new string[] { "【炎】", "[Fire]" },
      new string[] { "【氷】", "[Ice]" },
      new string[] { "【聖】", "[Holy]" },
      new string[] { "【闇】", "[Dark]" },
      new string[] { "【理】", "[Force]" },
      new string[] { "【物理】", "[Physical]" },
      new string[] { "【魔法】", "[Magic]" },
      new string[] { "【有益】", "[Beneficial]" },
      new string[] { "【有害】", "[Harmful]" }
    };

    for (int ii = 0; ii < replacements.Length; ii++)
    {
      result = result.Replace(replacements[ii][0], replacements[ii][1]);
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