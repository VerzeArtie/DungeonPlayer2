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
    Register("lblSaveLoad", "ロード", "LOAD");
    Register("txtClose", "閉じる", "Close");
    Register("GameDay", "日目", "Day");
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
      string baseText = (One.CONF.GameLanguage == 1) ? v.ja : v.en;
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