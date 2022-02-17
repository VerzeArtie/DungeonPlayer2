using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
  public bool Decision = false; // アクションコマンドを決定したかどうかを示すフラグ
  public bool CannotCritical = false; // 雑魚キャラレベルはクリティカルなし
  public int AI_Phase = 0;

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
    List<string> current = new List<string>();
    switch (this.FullName)
    {
      case Fix.SCREAMING_RAFFLESIA:
        int random = AP.Math.RandomInteger(4);
        if (random == 0)
        {
          current.Add(Fix.COMMAND_YOUEN_FIRE);
        }
        else if (random == 1)
        {
          current.Add(Fix.COMMAND_POISON_RINPUN);
        }
        else if (random == 2)
        {
          current.Add(Fix.COMMAND_BLAZE_DANCE);
        }
        else
        {
          current.Add(Fix.NORMAL_ATTACK);
        }
        result = RandomChoice(current);
        break;

      case Fix.MYSTIC_DRYAD:
        if (this.Target != null && this.Target.IsPoison == null)
        {
          current.Add(Fix.COMMAND_POISON_RINPUN);
        }

        if (this.IsUpFire == null)
        {
          current.Add(Fix.COMMAND_BLAZE_DANCE);
        }

        current.Add(Fix.COMMAND_YOUEN_FIRE);
        result = RandomChoice(current);
        break;

      case Fix.THE_GALVADAZER:
        this.AI_Phase++;
        if (this.AI_Phase >= 3) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.NORMAL_ATTACK);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_RUMBLE_MACHINEGUN);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_STRUGGLE_VOICE);
        }
        result = RandomChoice(current);
        break;

      default:
        // 雑魚はランダムでひとまずよい。
        result = RandomChoice(GetActionCommandList());
        break;
    }

    return result;
  }

  private string RandomChoice(List<string> command_list)
  {
    string result = string.Empty;
    command_list.RemoveAll(s => s.Contains(Fix.STAY));
    int random = AP.Math.RandomInteger(command_list.Count);
    return command_list[random];
  }
}
