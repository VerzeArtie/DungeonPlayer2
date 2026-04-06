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