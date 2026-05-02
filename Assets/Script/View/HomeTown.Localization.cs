using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class L10n
{
  private static Dictionary<string, (string ja, string en)> table = new Dictionary<string, (string ja, string en)>(StringComparer.OrdinalIgnoreCase);

  static L10n()
  {
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
    Register("lblParty", "パーティ", "Party");
    Register("lblBlueSphere", "遠見の青水晶", "Far-Blue-Sphere");
    Register("lblSystem", "システム", "System");
    Register("lblDungeonPlayer", "DungeonPlayer", "DungeonPlayer"); // 日本語／英語で表記を変えない
    Register("lblShop", "ショップ", "Shop");
    Register("lblInn", "宿屋", "Inn");
    Register("lblTalkLana", "幼なじみのラナと会話", "Talk to Lana");
    Register("lblItemBank", "アイテム保管庫", "ItemBank");
    // HomeTown-System
    Register("lblSystemSave", "セーブ", "Save");
    Register("lblSystemLoad", "ロード", "Load");
    Register("lblSystemHelp", "ヘルプ", "Help");
    Register("lblSystemExit", "終了", "Exit");
    Register(Fix.L10N_SAVELOAD_YES, "はい", "Yes");
    Register(Fix.L10N_SAVELOAD_NO, "いいえ", "No");
    // HomeTown-Menu-Custom
    Register("CustomEvent1_ANSHET", "中央噴水広場", "Central Fountain");
    Register("CustomEvent1_FAZIL_CASTLE", "ファージル宮殿", "Fazil Castle");
    Register("CustomEvent1_COTUHSYE", "船着き場", "Dock");
    Register("CustomEvent2_COTUHSYE", "街はずれ", "Outskirts");
    Register("CustomEvent1_ZHALMAN", "長老の家", "Elder's House");
    Register("CustomEvent2_ZHALMAN", "ドルワッツの民芸品店", "Dorwatts Handicraft");
    Register("CustomEvent1_ARCANEDINE", "中央噴水広場", "Central Fountain");
    Register("CustomEvent2_ARCANEDINE", "ワッツの民芸品店", "Watts Handicraft");
    Register("CustomEvent3_ARCANEDINE", "占いの館：アミンダ", "Aminda's Fortune");
    Register("CustomEvent1_PARMETYSIA", "中央神殿", "Central Temple");
    // HomeTown-Inn
    Register(Fix.L10N_HOMETOWN_INN_TITLE, "休息に入りますか？", "Do you want to take a rest?");
    Register(Fix.L10N_HOMETOWN_INN_ACCEPT, "休息する", "Rest");
    Register(Fix.L10N_HOMETOWN_INN_CANCEL, "キャンセル", "Cancel");
    // DungeonField
    Register(Fix.L10N_FASTTRAVEL_MESSAGE_TITLE, "ダンジョンの外へと帰還しますか？", "Do you want to return to the outside of the dungeon?");
    Register(Fix.L10N_FASTTRAVEL_MESSAGE, "ダンジョンから出た場合、その日は再びダンジョン内に入る事は出来なくなります。", "If you leave the dungeon, you will not be able to enter the dungeon again that day.");
    Register(Fix.L10N_FASTTRAVEL_MESSAGE_ACCEPT, "実行", "Accept");
    Register(Fix.L10N_FASTTRAVEL_MESSAGE_CANCEL, "キャンセル", "Cancel");
    Register(Fix.L10N_FASTTRAVEL_MESSAGE_OK, "ＯＫ", "OK");
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
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_BASIC, "基本", "Basic");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_SPELLSKILL, "魔法/スキル", "Spell/Skill");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_USEITEM, "アイテム", "Item");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_ARCHETYPE, "元核", "Archetype");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_VIEWMODE_EDIT, "編集モード", "EditMode");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_VIEWMODE_VIEW, "表示モード", "ViewMode");
    Register(Fix.L10N_PARTYMENU_BATTLETYPE_DESCRIPTION, "説明", "Description");
    Register(Fix.L10N_PARTYMENU_BATTLE_LABEL_MAIN, "メイン", "Main");
    Register(Fix.L10N_PARTYMENU_BATTLE_LABEL_ACTIONCOMMAND, "アクション コマンド", "Action Command");
    Register(Fix.L10N_PARTYMENU_ESSENCETREE_NOACQ, "未修得", "Ready");
    Register(Fix.L10N_PARTYMENU_ESSENCETREE_REQUIRE, "必要", "Require");
    Register(Fix.L10N_PARTYMENU_ESSENCETREE_POWERUP, "強化", "Power-Up");
    Register(Fix.L10N_PARTYMENU_ITEM_BACKPACK, "バックパック", "Backpack");
    Register(Fix.L10N_PARTYMENU_ITEM_PRECIOUS, "貴重品", "Precious");
    Register(Fix.L10N_PARTYMENU_ITEM_USE, "つかう", "Use");
    Register(Fix.L10N_PARTYMENU_ITEM_DETAIL, "詳細", "Detail");
    Register(Fix.L10N_PARTYMENU_ITEM_DELETE, "削除", "Delete");
    // PartyMenu-Decision
    Register(Fix.L10N_PARTYMENU_ITEM_DECISION_ACCEPT, "実行", "Accept");
    Register(Fix.L10N_PARTYMENU_ITEM_DECISION_CANCEL, "キャンセル", "Cancel");
    Register(Fix.L10N_PARTYMENU_ITEM_DECISION_OK, "ＯＫ", "OK");
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
    Register(Fix.L10N_BATTLE_GAMEOVER, "パーティが全滅しました・・・\r\n戦闘を初めからやり直しますか？", "Your party has been defeated...\r\nDo you want to retry the battle from the beginning?");
    Register(Fix.L10N_BATTLE_RETRY, "リトライ", "Retry");
    Register(Fix.L10N_BATTLE_SURRENDER, "終了", "Surrender");
    // Standard-Attribute
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
}