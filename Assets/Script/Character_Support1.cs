using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class Character : MonoBehaviour
{
  public bool Decision = false; // アクションコマンドを決定したかどうかを示すフラグ
  public bool CannotCritical = false; // 雑魚キャラレベルはクリティカルなし

  protected int _gold = 0;
  public int Gold
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _gold = value;
    }
    get
    {
      return _gold;
    }
  }

  public void Construction(string character_name)
  {
    this.name = character_name;
    this.FullName = character_name;
    this.BattleBackColor = Fix.COLOR_ENEMY_CHARA;
    this.BattleForeColor = Fix.COLORFORE_ENEMY_CHARA;

    switch (character_name)
    {
      case Fix.TINY_MANTIS:
      case Fix.TINY_MANTIS_JP:
        SetupParameter(10, 2, 1, 2, 3, 4, 16, 12);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_HIKKAKI);
        this.CannotCritical = true;
        break;

      case Fix.GREEN_SLIME:
      case Fix.GREEN_SLIME_JP:
        SetupParameter(2, 2, 12, 2, 3, 8, 19, 14);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_GREEN_NENEKI);
        this.CannotCritical = true;
        this.Gold = 18;
        break;

      case Fix.MANDRAGORA:
      case Fix.MANDRAGORA_JP:
        SetupParameter(2, 4, 16, 3, 3, 5, 21, 17);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_KANAKIRI);
        this.CannotCritical = true;
        break;

      case Fix.YOUNG_WOLF:
      case Fix.YOUNG_WOLF_JP:
        SetupParameter(19, 5, 2, 4, 3, 7, 23, 19);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_WILD_CLAW);
        this.CannotCritical = true;
        break;

      case Fix.WILD_ANT:
      case Fix.WILD_ANT_JP:
        SetupParameter(22, 4, 2, 6, 3, 2, 26, 22);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_KAMITSUKI);
        this.CannotCritical = true;
        break;

      case Fix.OLD_TREEFORK:
      case Fix.OLD_TREEFORK_JP:
        SetupParameter(2, 4, 30, 7, 4, 4, 28, 24);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_TREE_SONG);
        this.CannotCritical = true;
        break;

      case Fix.SUN_FLOWER:
      case Fix.SUN_FLOWER_JP:
        SetupParameter(2, 6, 35, 4, 4, 3, 32, 28);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_SUN_FIRE);
        this.CannotCritical = true;
        break;

      case Fix.SOLID_BEETLE:
      case Fix.SOLID_BEETLE_JP:
        SetupParameter(44, 6, 2, 9, 4, 6, 35, 29);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_TOSSHIN);
        this.CannotCritical = true;
        break;

      case Fix.SILENT_LADYBUG:
      case Fix.SILENT_LADYBUG_JP:
        SetupParameter(2, 7, 49, 7, 4, 8, 37, 32);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_FEATHER_WING);
        this.CannotCritical = true;
        break;

      case Fix.MYSTIC_DRYAD:
      case Fix.MYSTIC_DRYAD_JP:
        SetupParameter(55, 10, 60, 20, 5, 0, 80, 50);
        this.ActionCommandList.Add(Fix.COMMAND_POISON_RINPUN);
        this.ActionCommandList.Add(Fix.COMMAND_YOUEN_FIRE);
        this.ActionCommandList.Add(Fix.COMMAND_BLAZE_DANCE);
        this.CannotCritical = false;
        break;

      case Fix.DEBRIS_SOLDIER:
      case Fix.DEBRIS_SOLDIER_JP:
        SetupParameter(62, 43, 15, 120, 10, 0, 120, 80);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

    }

    this.MaxGain();
    this.CurrentActionCommand = this.ActionCommandList[0];
  }

  private void SetupParameter(int strength, int agility, int intelligence, int stamina, int mind, int base_life, int exp, int gold)
  {
    this._strength = strength;
    this._agility = agility;
    this._intelligence = intelligence;
    this._stamina = stamina;
    this._mind = mind;
    this._baseLife = base_life;
    this._exp = exp;
    this._gold = gold;
  }

  public string ChooseCommand()
  {
    string result = string.Empty;
    if (this.FullName == Fix.MYSTIC_DRYAD)
    {
      List<string> current = new List<string>();
      if (this.Target != null && this.Target.IsPoison == null)
      {
        current.Add(Fix.COMMAND_POISON_RINPUN);
      }

      if (this.IsUpFire == null)
      {
        current.Add(Fix.COMMAND_BLAZE_DANCE);
      }

      current.Add(Fix.COMMAND_YOUEN_FIRE);
      result = LogicMRandom(current);
    }
    else
    {
      // 雑魚はランダムでひとまずよい。
      result = LogicMRandom(this.ActionCommandList);
    }

    return result;
  }

  private string LogicMRandom(List<string> command_list)
  {
    string result = string.Empty;
    int random = AP.Math.RandomInteger(command_list.Count);
    return command_list[random];
  }
}
