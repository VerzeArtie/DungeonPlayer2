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

  // 全てのコマンドの要素としてあり得る値を列挙し続ける箇所
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
