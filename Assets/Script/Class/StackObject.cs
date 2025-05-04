using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class StackObject : MonoBehaviour
{
  [SerializeField] protected int _suddenTimer = 0;
  public int SuddenTimer
  {
    get { return _suddenTimer; }
    set { _suddenTimer = value; }
  }

  [SerializeField] protected int _stackTimer = 0;
  public int StackTimer
  {
    get { return _stackTimer; }
    set { _stackTimer = value; }
  }

  [SerializeField] protected string _stackName = String.Empty;
  public string StackName
  {
    get { return _stackName; }
    set { _stackName = value; }
  }

  [SerializeField] protected Character _player = null;
  public Character Player
  {
    get { return _player; }
    set { _player = value; }
  }

  [SerializeField] protected Character _target = null;
  public Character Target
  {
    get { return _target; }
    set { _target = value; }
  }

  [SerializeField] protected List<Character> _target_list = null;
  public List<Character> TargetList
  {
    get { return _target_list; }
    set { _target_list = value; }
  }

  // 全てのコマンドの要素としてあり得る値を列挙し続ける箇所
  [SerializeField] protected int _sequence_number = 0;
  public int SequenceNumber
  {
    get { return _sequence_number; }
    set { _sequence_number = value; }
  }

  [SerializeField] protected double _magnify = 0.0f;
  public double Magnify
  {
    get { return _magnify; }
    set { _magnify = value; }
  }

  [SerializeField] protected Fix.DamageSource _damageSource = Fix.DamageSource.None;
  public Fix.DamageSource DamageSource
  {
    get { return _damageSource; }
    set { _damageSource = value; }
  }

  [SerializeField] protected Fix.IgnoreType _ignoreType = Fix.IgnoreType.None;
  public Fix.IgnoreType IgnoreType
  {
    get { return _ignoreType; }
    set { _ignoreType = value; }
  }

  [SerializeField] protected Fix.CriticalType _criticalType = Fix.CriticalType.None;
  public Fix.CriticalType CriticalType
  {
    get { return _criticalType; }
    set { _criticalType = value; }
  }

  [SerializeField] protected int _animationSpeed = 40;
  public int AnimationSpeed
  {
    get { return _animationSpeed; }
    set { _animationSpeed = value; }
  }

  [SerializeField] protected string _buff_name = string.Empty;
  public string BuffName
  {
    get { return _buff_name; }
    set { _buff_name = value; }
  }

  [SerializeField] protected string _view_buff_name = string.Empty;
  public string ViewBuffName
  {
    get { return _view_buff_name; }
    set { _view_buff_name = value; }
  }

  [SerializeField] protected int _turn = 0;
  public int Turn
  {
    get { return _turn; }
    set { _turn = value; }
  }

  [SerializeField] protected double _effect1 = 0;
  public double Effect1
  {
    get { return _effect1; }
    set { _effect1 = value; }
  }

  [SerializeField] protected double _effect2 = 0;
  public double Effect2
  {
    get { return _effect2; }
    set { _effect2 = value; }
  }

  [SerializeField] protected double _effect3 = 0;
  public double Effect3
  {
    get { return _effect3; }
    set { _effect3 = value; }
  }

  [SerializeField] protected BuffField _target_field = null;
  public BuffField TargetField
  {
    get { return _target_field; }
    set { _target_field = value; }
  }

  [SerializeField] protected double _heal_value = 0.0f;
  public double HealValue
  {
    get { return _heal_value; }
    set { _heal_value = value; }
  }

  [SerializeField] protected bool _from_potion = false;
  public bool FromPotion
  {
    get { return _from_potion; }
    set { _from_potion = value; }
  }

  [SerializeField] protected double _effect_value = 0.0f;
  public double EffectValue
  {
    get { return _effect_value; }
    set { _effect_value = value; }
  }

  [SerializeField] protected int _num = 0;
  public int Num
  {
    get { return _num; }
    set { _num = value; }
  }

  [SerializeField] protected Fix.BuffType _buff_type = Fix.BuffType.None;
  public Fix.BuffType BuffType
  {
    get { return _buff_type; }
    set { _buff_type = value; }
  }

  [SerializeField] protected double _now_command_counter = 0.0f;
  public double NowCommandCounter
  {
    get { return _now_command_counter; }
    set { _now_command_counter = value; }
  }

  [SerializeField] protected double _decrease = 0.0f;
  public double Decrease
  {
    get { return _decrease; }
    set { _decrease = value; }
  }

  public Image background;
  public Text txtStackName;
  public Text txtStackTarget;
  public Text txtStackTime;
  public NodeActionCommand imgStackIcon;

  public void ConstructStack(Character player, Character target, string stack_name, int stack_timer, int sudden_timer)
  {
    _suddenTimer = sudden_timer;
    _stackName = stack_name;
    _stackTimer = stack_timer;
    _player = player;
    _target = target;
    txtStackName.text = stack_name;
    txtStackTime.text = stack_timer.ToString();
    imgStackIcon.ApplyImageIcon(stack_name);

    if (ActionCommand.IsTarget(stack_name) == ActionCommand.TargetType.Own)
    {
      Debug.Log("ConstructStack 1: " + ActionCommand.IsTarget(stack_name));
      if (player == null)
      {
        txtStackTarget.text = "";
      }
      else
      {
        txtStackTarget.text = player.FullName;
      }
    }
    else
    {
      Debug.Log("ConstructStack 2: " + ActionCommand.IsTarget(stack_name));
      if (player == null)
      {
        txtStackTarget.text = "";
      }
      else
      {
        txtStackTarget.text = player.FullName;
      }

      if (target == null)
      {
        // 何もしない
      }
      else
      {
        txtStackTarget.text += " --> " + target.FullName;
      }

      Debug.Log("ConstructStack 2: txtStackTarget.text: " + txtStackTarget.text);
    }

    if (sudden_timer > 0)
    {
      background.color = Color.black;
      txtStackName.color = Color.white;
      txtStackTarget.color = Color.white;
      txtStackTime.color = Color.white;      
    }
  }
}
