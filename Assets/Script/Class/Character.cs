using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class Character : MonoBehaviour
{
  #region "Core"
  // Battle GUI-View object
  public NodeBattleChara objGroup = null;
  public GameObject objArrow = null;
  public NodeActionCommand objMainButton = null;
  public Text txtName = null;
  public Text txtLife = null;
  public Image objBackLifeGauge = null;
  public Image objCurrentLifeGauge = null;
  public Image objCurrentLifeBorder = null;
  public Text txtActionCommand = null;
  public NodeActionPanel objParentActionPanel = null;
  public GameObject groupActionButton = null;
  public List<Button> objActionButtonList = null;
  public Image objBackInstantGauge = null;
  public Image objCurrentInstantGauge = null;
  public Image objCurrentInstangGauge_AC = null;
  public Text txtTargetName = null;
  public Image imgTargetLifeGauge = null;
  public GameObject groupActionPoint;
  public Image objCurrentActionPointGauge = null;
  public List<Image> imgActionPointList = null;
  public Text txtActionPoint = null;
  public Image imgCurrentEnergyPointGauge = null;

  public Text txtManaPoint = null;
  public Image objBackManaPointGauge = null;
  public Image objCurrentManaPointGauge = null;
  public Image objCurrentManaPointBorder = null;

  public Text txtSkillPoint = null;  
  public Image objBackSkillPointGauge = null;
  public Image objCurrentSkillPointGauge = null;
  public Image objCurrentSkillPointBorder = null;

  public BuffField objBuffPanel = null;
  public NodeActionCommand objImmediateCommand = null;
  public GameObject GroupActionCommand = null;
  public List<NodeActionCommand> objActionCommandList = new List<NodeActionCommand>();
  public List<NodeActionCommand> objMainActionList = new List<NodeActionCommand>();
  public BuffField objFieldPanel = null;
  public GameObject groupManaPoint = null;
  public GameObject groupSkillPoint = null;

  #region "First Value"
  [SerializeField] protected string _fullName = string.Empty;
  public string FullName
  {
    set { _fullName = value; }
    get { return _fullName; }
  }

  [SerializeField] protected int _strengthFood = 0;
  public int StrengthFood
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _strengthFood = value;
    }
    get { return _strengthFood; }
  }

  [SerializeField] protected int _agilityhFood = 0;
  public int AgilityFood
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _agilityhFood = value;
    }
    get { return _agilityhFood; }
  }

  [SerializeField] protected int _intelligenceFood = 0;
  public int IntelligenceFood
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _intelligenceFood = value;
    }
    get { return _intelligenceFood; }
  }

  [SerializeField] protected int _staminaFood = 0;
  public int StaminaFood
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _staminaFood = value;
    }
    get { return _staminaFood; }
  }

  [SerializeField] protected int _mindFood = 0;
  public int MindFood
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _mindFood = value;
    }
    get { return _mindFood; }
  }
  #endregion

  #region "Parameters (Core)"
  [SerializeField] protected int _strength = 0;
  public int Strength
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _strength = value;
    }
    get
    {
      int result = _strength + _plusStrength;
      return result;
    }
  }

  [SerializeField] protected int _agility = 0;
  public int Agility
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _agility = value;
    }
    get
    {
      int result = _agility + _plusAgility;
      return result;
    }
  }

  [SerializeField] protected int _intelligence = 0;
  public int Intelligence
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _intelligence = value;
    }
    get
    {
      int result = _intelligence + _plusIntelligence;
      return result;
    }
  }

  [SerializeField] protected int _stamina = 0;
  public int Stamina
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _stamina = value;
    }
    get
    {
      int result = _stamina + _plusStamina;
      return result;
    }
  }

  [SerializeField] protected int _mind = 0;
  public int Mind
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _mind = value;
    }
    get
    {
      int result = _mind + _plusMind;
      return result;
    }
  }
  #endregion

  #region "Equip"
  [SerializeField] protected Item _mainWeapon = null;
  public Item MainWeapon
  {
    set { _mainWeapon = value; }
    get { return _mainWeapon; }
  }

  [SerializeField] protected Item _subWeapon = null;
  public Item SubWeapon
  {
    set { _subWeapon = value; }
    get { return _subWeapon; }
  }

  [SerializeField] protected Item _mainArmor = null;
  public Item MainArmor
  {
    set { _mainArmor = value; }
    get { return _mainArmor; }
  }

  [SerializeField] protected Item _accessory1 = null;
  public Item Accessory1
  {
    set { _accessory1 = value; }
    get { return _accessory1; }
  }

  [SerializeField] protected Item _accessory2 = null;
  public Item Accessory2
  {
    set { _accessory2 = value; }
    get { return _accessory2; }
  }

  [SerializeField] protected Item _artifact = null;
  public Item Artifact
  {
    set { _artifact = value; }
    get { return _artifact; }
  }
  #endregion

  #region "Parameters (General)"
  [SerializeField] protected int _soulFragment = 0;
  public int SoulFragment
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _soulFragment = value;
    }
    get { return _soulFragment; }
  }

  [SerializeField] protected Fix.JobClass _job = Fix.JobClass.None;
  public Fix.JobClass Job
  {
    set { _job = value; }
    get { return _job; }
  }

  [SerializeField] protected Fix.Ally _ally = Fix.Ally.None;
  public Fix.Ally Ally
  {
    set { _ally = value; }
    get { return _ally; }
  }

  [SerializeField] protected Character _target = null;
  public Character Target
  {
    set { _target = value; }
    get { return _target; }
  }

  [SerializeField] protected Character _target2 = null;
  public Character Target2
  {
    set { _target2 = value; }
    get { return _target2; }
  }

  [SerializeField] protected Color _battleBackColor = new Color(0.0f, 0.0f, 0.0f);
  public Color BattleBackColor
  {
    set { _battleBackColor = value; }
    get { return _battleBackColor; }
  }
  [SerializeField] protected Color _battleForeColor = new Color(0.0f, 0.0f, 0.0f);
  public Color BattleForeColor
  {
    set { _battleForeColor = value; }
    get { return _battleForeColor; }
  }

  [SerializeField] protected float _battleGaugeArrow = 0.0f;
  public float BattleGaugeArrow
  {
    set { _battleGaugeArrow = value; }
    get { return _battleGaugeArrow; }
  }

  [SerializeField] protected Fix.TargetSelectType _targetSelectType = Fix.TargetSelectType.None;
  public Fix.TargetSelectType TargetSelectType
  {
    set { _targetSelectType = value; }
    get { return _targetSelectType; }
  }

  [SerializeField] protected string _currentActionCommand = string.Empty;
  public string CurrentActionCommand
  {
    set
    {
      if (value == Fix.DEFENSE)
      {
        this._isDefense = true;
      }
      else
      {
        this._isDefense = false;
      }
      _currentActionCommand = value;
    }
    get { return _currentActionCommand; }
  }

  [SerializeField] protected string _currentImmediateCommand = string.Empty;
  public string CurrentImmediateCommand
  {
    set
    {
      _currentImmediateCommand = value;
    }
    get { return _currentImmediateCommand; }
  }

  //[SerializeField] protected List<string> _actionCommand = new List<string>();
  //public List<string> ActionCommandList
  //{
  //  set { _actionCommand = value; }
  //  get { return _actionCommand; }
  //}
  protected string _actionCommandMain = string.Empty;
  public string ActionCommandMain
  {
    get { return _actionCommandMain; }
    set { _actionCommandMain = value; }
  }
  protected string _actionCommand1 = string.Empty;
  public string ActionCommand1
  {
    get { return _actionCommand1; }
    set { _actionCommand1 = value; }
  }
  protected string _actionCommand2 = string.Empty;
  public string ActionCommand2
  {
    get { return _actionCommand2; }
    set { _actionCommand2 = value; }
  }
  protected string _actionCommand3 = string.Empty;
  public string ActionCommand3
  {
    get { return _actionCommand3; }
    set { _actionCommand3 = value; }
  }
  protected string _actionCommand4 = string.Empty;
  public string ActionCommand4
  {
    get { return _actionCommand4; }
    set { _actionCommand4 = value; }
  }
  protected string _actionCommand5 = string.Empty;
  public string ActionCommand5
  {
    get { return _actionCommand5; }
    set { _actionCommand5 = value; }
  }
  protected string _actionCommand6 = string.Empty;
  public string ActionCommand6
  {
    get { return _actionCommand6; }
    set { _actionCommand6 = value; }
  }
  protected string _actionCommand7 = string.Empty;
  public string ActionCommand7
  {
    get { return _actionCommand7; }
    set { _actionCommand7 = value; }
  }
  protected string _actionCommand8 = string.Empty;
  public string ActionCommand8
  {
    get { return _actionCommand8; }
    set { _actionCommand8 = value; }
  }
  protected string _actionCommand9 = string.Empty;
  public string ActionCommand9
  {
    get { return _actionCommand9; }
    set { _actionCommand9 = value; }
  }

  [SerializeField] protected string _GlobalAction1 = string.Empty;
  public string GlobalAction1
  {
    get { return _GlobalAction1; }
    set { _GlobalAction1 = value; }
  }
  [SerializeField] protected string _GlobalAction2 = string.Empty;
  public string GlobalAction2
  {
    get { return _GlobalAction2; }
    set { _GlobalAction2 = value; }
  }
  [SerializeField] protected string _GlobalAction3 = string.Empty;
  public string GlobalAction3
  {
    get { return _GlobalAction3; }
    set { _GlobalAction3 = value; }
  }
  [SerializeField] protected string _GlobalAction4 = string.Empty;
  public string GlobalAction4
  {
    get { return _GlobalAction4; }
    set { _GlobalAction4 = value; }
  }

  [SerializeField] protected bool _isDefense = false;
  public bool IsDefense
  {
    get 
    {
      if (this.IsAbsoluteZero)
      {
        return false;
      }

      return _isDefense; 
    }
  }

  [SerializeField] protected bool _isEnemy = false;
  public bool IsEnemy
  {
    set { _isEnemy = value; }
    get { return _isEnemy; }
  }

  [SerializeField] protected int _baseLife = 0;
  public int BaseLife
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _baseLife = value;
    }
    get { return _baseLife; }
  }

  [SerializeField] protected int _baseManaPoint = 0;
  public int BaseManaPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _baseManaPoint = value;
    }
    get { return _baseManaPoint; }
  }

  [SerializeField] protected int _baseSkillPoint = 0;
  public int BaseSkillPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _baseSkillPoint = value;
    }
    get { return _baseSkillPoint; }
  }

  public int MaxManaPoint
  {
    get
    {
      int result = _baseManaPoint + TotalMind * 2;
      if (this.objFieldPanel != null)
      {
        BuffImage[] buffList = this.objFieldPanel.GetComponentsInChildren<BuffImage>();
        for (int ii = 0; ii < buffList.Length; ii++)
        {
          if (buffList[ii].BuffName == Fix.SIGIL_OF_THE_FAITH)
          {
            result = (int)((double)result * buffList[ii].EffectValue);
            break;
          }
        }
      }

      return result;
    }
  }
  public int MaxSkillPoint
  {
    get
    {
      int result = _baseSkillPoint;
      if (objFieldPanel != null)
      {
        BuffImage[] buffList = this.objFieldPanel.GetComponentsInChildren<BuffImage>();
        for (int ii = 0; ii < buffList.Length; ii++)
        {
          if (buffList[ii].BuffName == Fix.SIGIL_OF_THE_FAITH)
          {
            result = (int)((double)result * buffList[ii].EffectValue);
            break;
          }
        }
      }

      return result;
    }
  }

  [SerializeField] protected int _currentManaPoint = 0;
  public int CurrentManaPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      if (value >= MaxManaPoint)
      {
        value = MaxManaPoint;
      }
      _currentManaPoint = value;
    }
    get { return _currentManaPoint; }
  }

  [SerializeField] protected int _currentSkillPoint = 0;
  public int CurrentSkillPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      if (value >= MaxSkillPoint)
      {
        value = MaxSkillPoint;
      }
      _currentSkillPoint = value;
    }
    get { return _currentSkillPoint; }
  }

  [SerializeField] protected int _currentLife = 0;
  public int CurrentLife
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      if (value >= MaxLife)
      {
        value = MaxLife;
      }
      _currentLife = value;
    }
    get { return _currentLife; }
  }

  [SerializeField] protected double _currentInstantPoint = 0.0f;
  public double CurrentInstantPoint
  {
    set
    {
      if (value >= MaxInstantPoint)
      {
        value = MaxInstantPoint;
      }
      _currentInstantPoint = value;
    }
    get { return _currentInstantPoint; }
  }

  [SerializeField] protected double _currentActionPoint = 0.0f;
  public double CurrentActionPoint
  {
    set
    {
      if (value >= MaxActionPoint)
      {
        value = MaxActionPoint;
      }
      _currentActionPoint = value;
    }
    get { return _currentActionPoint; }
  }

  [SerializeField] protected double _currentEnergyPoint = 0.0f;
  public double CurrentEnergyPoint
  {
    set
    {
      if (value >= MaxEnergyPoint)
      {
        value = MaxEnergyPoint;
      }
      _currentEnergyPoint = value;
    }
    get { return _currentEnergyPoint; }
  }

  [SerializeField] protected int _baseInstantPoint = Fix.MAX_INSTANT_POINT;
  public int MaxInstantPoint
  {
    get
    {
      if (_baseInstantPoint < Fix.MAX_INSTANT_POINT)
      {
        _baseInstantPoint = Fix.MAX_INSTANT_POINT;
      }
      return _baseInstantPoint;
    }
  }

  [SerializeField] protected int _baseActionPoint = 1000;
  public int BaseActionPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _baseActionPoint = value;
    }
    get { return _baseActionPoint; }
  }

  //[SerializeField] protected int _maxActionPoint = 0;
  public int MaxActionPoint
  {
    get
    {
      return _baseActionPoint;
    }
  }

  [SerializeField] protected int _baseEnergyPoint = 10000;
  public int BaseEnergyPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _baseEnergyPoint = value;
    }
    get { return _baseEnergyPoint; }
  }

  //[SerializeField] protected int _maxEnergyPoint = 0;
  public int MaxEnergyPoint
  {
    get
    {
      return _baseEnergyPoint;
    }
  }

  [SerializeField] protected bool _dead = false;
  public bool Dead
  {
    set { _dead = value; }
    get { return _dead; }
  }

  [SerializeField] protected int _level = 0;
  public int Level
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _level = value;
    }
    get { return _level; }
  }

  [SerializeField] protected int _exp = 0;
  public int Exp
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }

      // レベルアップに必要な経験値以上は稼ぐ事はできない。
      if (value >= this.GetNextExp())
      {
        value = this.GetNextExp();
      }
      _exp = value;
    }
    get { return _exp; }
  }

  [SerializeField] protected int _remainPoint = 0;
  public int RemainPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _remainPoint = value;
    }
    get { return _remainPoint; }
  }

  [SerializeField] protected int _minusRemainPoint = 0;
  public int MinusRemainPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _minusRemainPoint = value;
    }
    get { return _minusRemainPoint; }
  }

  [SerializeField] protected int _plusStrength = 0;
  public int PlusStrength
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _plusStrength = value;
    }
    get { return _plusStrength; }
  }

  [SerializeField] protected int _plusAgility = 0;
  public int PlusAgility
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _plusAgility = value;
    }
    get { return _plusAgility; }
  }

  [SerializeField] protected int _plusIntelligence = 0;
  public int PlusIntelligence
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _plusIntelligence = value;
    }
    get { return _plusIntelligence; }
  }

  [SerializeField] protected int _plusStamina = 0;
  public int PlusStamina
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _plusStamina = value;
    }
    get { return _plusStamina; }
  }

  [SerializeField] protected int _plusMind = 0;
  public int PlusMind
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _plusMind = value;
    }
    get { return _plusMind; }
  }

  public int TotalStrength
  {
    get
    {
      int result = 0;
      result += this.Strength;
      result += (this.MainWeapon?.Strength ?? 0);
      result += (this.SubWeapon?.Strength ?? 0);
      result += (this.MainArmor?.Strength ?? 0);
      result += (this.Accessory1?.Strength ?? 0);
      result += (this.Accessory2?.Strength ?? 0);
      result += (this.Artifact?.Strength ?? 0);
      result += this._strengthFood;
      return result;
    }
  }

  public int TotalAgility
  {
    get
    {
      int result = 0;
      result += this.Agility;
      result += (this.MainWeapon?.Agility ?? 0);
      result += (this.SubWeapon?.Agility ?? 0);
      result += (this.MainArmor?.Agility ?? 0);
      result += (this.Accessory1?.Agility ?? 0);
      result += (this.Accessory2?.Agility ?? 0);
      result += (this.Artifact?.Agility ?? 0);
      result += this._agilityhFood;
      return result;
    }
  }

  public int TotalIntelligence
  {
    get
    {
      int result = 0;
      result += this.Intelligence;
      result += (this.MainWeapon?.Intelligence ?? 0);
      result += (this.SubWeapon?.Intelligence ?? 0);
      result += (this.MainArmor?.Intelligence ?? 0);
      result += (this.Accessory1?.Intelligence ?? 0);
      result += (this.Accessory2?.Intelligence ?? 0);
      result += (this.Artifact?.Intelligence ?? 0);
      result += this._intelligenceFood;
      return result;
    }
  }

  public int TotalStamina
  {
    get
    {
      int result = 0;
      result += this.Stamina;
      result += (this.MainWeapon?.Stamina ?? 0);
      result += (this.SubWeapon?.Stamina ?? 0);
      result += (this.MainArmor?.Stamina ?? 0);
      result += (this.Accessory1?.Stamina ?? 0);
      result += (this.Accessory2?.Stamina ?? 0);
      result += (this.Artifact?.Stamina ?? 0);
      result += this._staminaFood;
      return result;
    }
  }

  public int TotalMind
  {
    get
    {
      int result = 0;
      result += this.Mind;
      result += (this.MainWeapon?.Mind ?? 0);
      result += (this.SubWeapon?.Mind ?? 0);
      result += (this.MainArmor?.Mind ?? 0);
      result += (this.Accessory1?.Mind ?? 0);
      result += (this.Accessory2?.Mind ?? 0);
      result += (this.Artifact?.Mind ?? 0);
      result += this._mindFood;
      return result;
    }
  }
  #endregion

  #region "戦闘中"
  [SerializeField] protected bool _nowExecSyutyuDanzetsu;
  public bool NowExecSyutyuDanzetsu
  {
    get { return _nowExecSyutyuDanzetsu; }
    set { _nowExecSyutyuDanzetsu = value; }
  }

  [SerializeField] protected int _powerUpFire = 0;
  public int PowerUpFire
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _powerUpFire = value;
    }
    get { return _powerUpFire; }
  }
  [SerializeField] protected int _powerUpIce = 0;
  public int PowerUpIce
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _powerUpIce = value;
    }
    get { return _powerUpIce; }
  }
  [SerializeField] protected int _powerUpLight = 0;
  public int PowerUpLight
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _powerUpLight = value;
    }
    get { return _powerUpLight; }
  }
  [SerializeField] protected int _powerUpShadow = 0;
  public int PowerUpShadow
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _powerUpShadow = value;
    }
    get { return _powerUpShadow; }
  }

  protected string _beforeActionCommand = string.Empty;
  protected Character _beforeTarget = null;
  protected Character _beforeTarget2 = null;
  public string BeforeActionCommand
  {
    get { return _beforeActionCommand; }
    set { _beforeActionCommand = value; }
  }
  public Character BeforeTarget
  {
    get { return _beforeTarget; }
    set { _beforeTarget = value; }
  }
  public Character BeforeTarget2
  {
    get { return _beforeTarget2; }
    set { _beforeTarget2 = value; }
  }

  public void CleanupBattleEnd()
  {
    _beforeActionCommand = String.Empty;
    _beforeTarget = null;
    _beforeTarget2 = null;
  }
  #endregion

  #region "Last Value"
  //[SerializeField] protected int _maxLife = 0;
  public int MaxLife
  {
    get
    {
      int result = _baseLife + TotalStamina * 10;
      if (this.IsVoiceOfVigor)
      {
        result = (int)((double)result * (this.IsVoiceOfVigor.EffectValue));
      }
      if (this.objFieldPanel != null)
      {
        BuffImage[] buffList = this.objFieldPanel.GetComponentsInChildren<BuffImage>();
        for (int ii = 0; ii < buffList.Length; ii++)
        {
          if (buffList[ii].BuffName == Fix.KILLING_WAVE)
          {
            Debug.Log("MaxLife Value down cause KillingWave(before): " + result);
            result = (int)((double)result * buffList[ii].EffectValue);
            Debug.Log("Potential Value down cause KillingWave(after ): " + result);
            break;
          }
        }
      }
      return result;
    }
  }

  #endregion

  #region "ActionCommand"
  [SerializeField] protected Fix.CommandAttribute _FirstCommandAttribute = Fix.CommandAttribute.None;
  public Fix.CommandAttribute FirstCommandAttribute
  {
    set { _FirstCommandAttribute = value; }
    get { return _FirstCommandAttribute; }
  }

  [SerializeField] protected Fix.CommandAttribute _SecondCommandAttribute = Fix.CommandAttribute.None;
  public Fix.CommandAttribute SecondCommandAttribute
  {
    set { _SecondCommandAttribute = value; }
    get { return _SecondCommandAttribute; }
  }

  [SerializeField] protected Fix.CommandAttribute _ThirdCommandAttribute = Fix.CommandAttribute.None;
  public Fix.CommandAttribute ThirdCommandAttribute
  {
    set { _ThirdCommandAttribute = value; }
    get { return _ThirdCommandAttribute; }
  }

  [SerializeField] protected Fix.CommandAttribute _FourthCommandAttribute = Fix.CommandAttribute.None;
  public Fix.CommandAttribute FourthCommandAttribute
  {
    set { _FourthCommandAttribute = value; }
    get { return _FourthCommandAttribute; }
  }

  [SerializeField] protected Fix.CommandAttribute _FifthCommandAttribute = Fix.CommandAttribute.None;
  public Fix.CommandAttribute FifthCommandAttribute
  {
    set { _FifthCommandAttribute = value; }
    get { return _FifthCommandAttribute; }
  }

  [SerializeField] protected Fix.CommandAttribute _SixthCommandAttribute = Fix.CommandAttribute.None;
  public Fix.CommandAttribute SixthCommandAttribute
  {
    set { _SixthCommandAttribute = value; }
    get { return _SixthCommandAttribute; }
  }

  [SerializeField] protected bool _AvailableFire = false;
  public bool AvailableFire
  {
    set { _AvailableFire = value; }
    get { return _AvailableFire; }
  }

  [SerializeField] protected bool _AvailableIce = false;
  public bool AvailableIce
  {
    set { _AvailableIce = value; }
    get { return _AvailableIce; }
  }

  [SerializeField] protected bool _AvailableHolyLight = false;
  public bool AvailableHolyLight
  {
    set { _AvailableHolyLight = value; }
    get { return _AvailableHolyLight; }
  }

  [SerializeField] protected bool _AvailableDarkMagic = false;
  public bool AvailableDarkMagic
  {
    set { _AvailableDarkMagic = value; }
    get { return _AvailableDarkMagic; }
  }

  [SerializeField] protected bool _AvailableForce = false;
  public bool AvailableForce
  {
    set { _AvailableForce = value; }
    get { return _AvailableForce; }
  }

  [SerializeField] protected bool _AvailableVoidChant = false;
  public bool AvailableVoidChant
  {
    set { _AvailableVoidChant = value; }
    get { return _AvailableVoidChant; }
  }

  [SerializeField] protected bool _AvailableWind = false;
  public bool AvailableWind
  {
    set { _AvailableWind = value; }
    get { return _AvailableWind; }
  }

  [SerializeField] protected bool _AvailableEarth = false;
  public bool AvailableEarth
  {
    set { _AvailableEarth = value; }
    get { return _AvailableEarth; }
  }

  [SerializeField] protected bool _AvailableWarrior = false;
  public bool AvailableWarrior
  {
    set { _AvailableWarrior = value; }
    get { return _AvailableWarrior; }
  }

  [SerializeField] protected bool _AvailableGuardian = false;
  public bool AvailableGuardian
  {
    set { _AvailableGuardian = value; }
    get { return _AvailableGuardian; }
  }

  [SerializeField] protected bool _AvailableMartialArts = false;
  public bool AvailableMartialArts
  {
    set { _AvailableMartialArts = value; }
    get { return _AvailableMartialArts; }
  }

  [SerializeField] protected bool _AvailableArchery = false;
  public bool AvailableArchery
  {
    set { _AvailableArchery = value; }
    get { return _AvailableArchery; }
  }

  [SerializeField] protected bool _AvailableTruth = false;
  public bool AvailableTruth
  {
    set { _AvailableTruth = value; }
    get { return _AvailableTruth; }
  }

  [SerializeField] protected bool _AvailableMindfulness = false;
  public bool AvailableMindfulness
  {
    set { _AvailableMindfulness = value; }
    get { return _AvailableMindfulness; }
  }

  // Basic
  [SerializeField] protected int _defenseSkill = 0;
  public int DefenseSkill { set { if (value >= 0) { _defenseSkill = value; } } get { return _defenseSkill; } }
  [SerializeField] protected int _magicSpell = 0;
  public int MagicSpell { set { if (value >= 0) { _magicSpell = value; } } get { return _magicSpell; } }
  [SerializeField] protected int _evadingSkill = 0;
  public int EvadingSkill { set { if (value >= 0) { _evadingSkill = value; } } get { return _evadingSkill; } }
  [SerializeField] protected int _rushSkill = 0;
  public int RushSkill { set { if (value >= 0) { _rushSkill = value; } } get { return _rushSkill; } }

  // Delve I
  [SerializeField] protected int _FireBall = 0;
  public int FireBall { set { if (value >= 0) { _FireBall = value; } } get { return _FireBall; } }
  [SerializeField] protected int _IceNeedle = 0;
  public int IceNeedle { set { if (value >= 0) { _IceNeedle = value; } } get { return _IceNeedle; } }
  [SerializeField] protected int _FreshHeal = 0;
  public int FreshHeal { set { if (value >= 0) { _FreshHeal = value; } } get { return _FreshHeal; } }
  [SerializeField] protected int _ShadowBlast = 0;
  public int ShadowBlast { set { if (value >= 0) { _ShadowBlast = value; } } get { return _ShadowBlast; } }
  [SerializeField] protected int _AirCutter = 0;
  public int AirCutter { set { if (value >= 0) { _AirCutter = value; } } get { return _AirCutter; } }
  [SerializeField] protected int _RockSlam = 0;
  public int RockSlam { set { if (value >= 0) { _RockSlam = value; } } get { return _RockSlam; } }
  [SerializeField] protected int _StraightSmash = 0;
  public int StraightSmash { set { if (value >= 0) { _StraightSmash = value; } } get { return _StraightSmash; } }
  [SerializeField] protected int _HunterShot = 0;
  public int HunterShot { set { if (value >= 0) { _HunterShot = value; } } get { return _HunterShot; } }
  [SerializeField] protected int _LegStrike = 0;
  public int LegStrike { set { if (value >= 0) { _LegStrike = value; } } get { return _LegStrike; } }
  [SerializeField] protected int _VenomSlash = 0;
  public int VenomSlash { set { if (value >= 0) { _VenomSlash = value; } } get { return _VenomSlash; } }
  [SerializeField] protected int _EnergyBolt = 0;
  public int EnergyBolt { set { if (value >= 0) { _EnergyBolt = value; } } get { return _EnergyBolt; } }
  [SerializeField] protected int _ShieldBash = 0;
  public int ShieldBash { set { if (value >= 0) { _ShieldBash = value; } } get { return _ShieldBash; } }
  [SerializeField] protected int _AuraOfPower = 0;
  public int AuraOfPower { set { if (value >= 0) { _AuraOfPower = value; } } get { return _AuraOfPower; } }
  [SerializeField] protected int _DispelMagic = 0;
  public int DispelMagic { set { if (value >= 0) { _DispelMagic = value; } } get { return _DispelMagic; } }
  [SerializeField] protected int _TrueSight = 0;
  public int HeartOfLife { set { if (value >= 0) { _HeartOfLife = value; } } get { return _HeartOfLife; } }
  [SerializeField] protected int _DarknessCircle = 0;
  public int DarknessCircle { set { if (value >= 0) { _DarknessCircle = value; } } get { return _DarknessCircle; } }
  [SerializeField] protected int _DarkAura = 0;
  public int DarkAura { set { if (value >= 0) { _DarkAura = value; } } get { return _DarkAura; } }
  [SerializeField] protected int _OracleCommand = 0;
  public int TrueSight { set { if (value >= 0) { _TrueSight = value; } } get { return _TrueSight; } }
  [SerializeField] protected int _HeartOfLife = 0;
  public int OracleCommand { set { if (value >= 0) { _OracleCommand = value; } } get { return _OracleCommand; } }

  // Delve II
  [SerializeField] protected int _FlameBlade = 0;
  public int FlameBlade { set { if (value >= 0) { _FlameBlade = value; } } get { return _FlameBlade; } }
  [SerializeField] protected int _PurePurification = 0;
  public int PurePurification { set { if (value >= 0) { _PurePurification = value; } } get { return _PurePurification; } }
  [SerializeField] protected int _DivineCircle = 0;
  public int DivineCircle { set { if (value >= 0) { _DivineCircle = value; } } get { return _DivineCircle; } }
  [SerializeField] protected int _BloodSign = 0;
  public int BloodSign { set { if (value >= 0) { _BloodSign = value; } } get { return _BloodSign; } }
  [SerializeField] protected int _StormArmor = 0;
  public int StormArmor { set { if (value >= 0) { _StormArmor = value; } } get { return _StormArmor; } }
  [SerializeField] protected int _SoldWall = 0;
  public int SoldWall { set { if (value >= 0) { _SoldWall = value; } } get { return _SoldWall; } }
  [SerializeField] protected int _StanceOfTheBlade = 0;
  public int StanceOfTheBlade { set { if (value >= 0) { _StanceOfTheBlade = value; } } get { return _StanceOfTheBlade; } }
  [SerializeField] protected int _MultipleShot = 0;
  public int MultipleShot { set { if (value >= 0) { _MultipleShot = value; } } get { return _MultipleShot; } }
  [SerializeField] protected int _SpeedStep = 0;
  public int SpeedStep { set { if (value >= 0) { _SpeedStep = value; } } get { return _SpeedStep; } }
  [SerializeField] protected int _InvisibleBind = 0;
  public int InvisibleBind { set { if (value >= 0) { _InvisibleBind = value; } } get { return _InvisibleBind; } }
  [SerializeField] protected int _IdeologyOfSophistication = 0;
  public int IdeologyOfSophistication { set { if (value >= 0) { _IdeologyOfSophistication = value; } } get { return _IdeologyOfSophistication; } }
  [SerializeField] protected int _StanceOfTheGuard = 0;
  public int StanceOfTheGuard { set { if (value >= 0) { _StanceOfTheGuard = value; } } get { return _StanceOfTheGuard; } }
  [SerializeField] protected int _SkyShield = 0;
  public int SkyShield { set { if (value >= 0) { _SkyShield = value; } } get { return _SkyShield; } }
  [SerializeField] protected int _FlashCounter = 0;
  public int FlashCounter { set { if (value >= 0) { _FlashCounter = value; } } get { return _FlashCounter; } }
  [SerializeField] protected int _FortuneSpirit = 0;
  public int FortuneSpirit { set { if (value >= 0) { _FortuneSpirit = value; } } get { return _FortuneSpirit; } }
  [SerializeField] protected int _StanceOfTheShade = 0;
  public int StanceOfTheShade { set { if (value >= 0) { _StanceOfTheShade = value; } } get { return _StanceOfTheShade; } }
  [SerializeField] protected int _LeylineSchema = 0;
  public int LeylineSchema { set { if (value >= 0) { _LeylineSchema = value; } } get { return _LeylineSchema; } }
  [SerializeField] protected int _SpiritualRest = 0;
  public int SpiritualRest { set { if (value >= 0) { _SpiritualRest = value; } } get { return _SpiritualRest; } }

  // Delve III
  [SerializeField] protected int _MeteorBullet = 0;
  public int MeteorBullet { set { if (value >= 0) { _MeteorBullet = value; } } get { return _MeteorBullet; } }
  [SerializeField] protected int _BlueBullet = 0;
  public int BlueBullet { set { if (value >= 0) { _BlueBullet = value; } } get { return _BlueBullet; } }
  [SerializeField] protected int _HolyBreath = 0;
  public int HolyBreath { set { if (value >= 0) { _HolyBreath = value; } } get { return _HolyBreath; } }
  [SerializeField] protected int _BlackContract = 0;
  public int BlackContract { set { if (value >= 0) { _BlackContract = value; } } get { return _BlackContract; } }
  [SerializeField] protected int _SonicPulse = 0;
  public int SonicPulse { set { if (value >= 0) { _SonicPulse = value; } } get { return _SonicPulse; } }
  [SerializeField] protected int _EarthSurge = 0;
  public int EarthSurge { set { if (value >= 0) { _EarthSurge = value; } } get { return _EarthSurge; } }
  [SerializeField] protected int _DoubleSlash = 0;
  public int DoubleSlash { set { if (value >= 0) { _DoubleSlash = value; } } get { return _DoubleSlash; } }
  [SerializeField] protected int _EyeOfTheIsshin = 0;
  public int EyeOfTheIsshin { set { if (value >= 0) { _EyeOfTheIsshin = value; } } get { return _EyeOfTheIsshin; } }
  [SerializeField] protected int _BoneCrush = 0;
  public int BoneCrush { set { if (value >= 0) { _BoneCrush = value; } } get { return _BoneCrush; } }
  [SerializeField] protected int _IrregularStep = 0;
  public int IrregularStep { set { if (value >= 0) { _IrregularStep = value; } } get { return _IrregularStep; } }
  [SerializeField] protected int _SigilOfThePending = 0;
  public int SigilOfThePending { set { if (value >= 0) { _SigilOfThePending = value; } } get { return _SigilOfThePending; } }
  [SerializeField] protected int _ConcussiveHit = 0;
  public int ConcussiveHit { set { if (value >= 0) { _ConcussiveHit = value; } } get { return _ConcussiveHit; } }
  [SerializeField] protected int _AetherDrive = 0;
  public int AetherDrive { set { if (value >= 0) { _AetherDrive = value; } } get { return _AetherDrive; } }
  [SerializeField] protected int _MuteImpulse = 0;
  public int MuteImpulse { set { if (value >= 0) { _MuteImpulse = value; } } get { return _MuteImpulse; } }
  [SerializeField] protected int _VoiceOfVigor = 0;
  public int VoiceOfVigor { set { if (value >= 0) { _VoiceOfVigor = value; } } get { return _VoiceOfVigor; } }
  [SerializeField] protected int _KillingWave = 0;
  public int KillingWave { set { if (value >= 0) { _KillingWave = value; } } get { return _KillingWave; } }
  [SerializeField] protected int _WordOfPower = 0;
  public int WordOfPower { set { if (value >= 0) { _WordOfPower = value; } } get { return _WordOfPower; } }
  [SerializeField] protected int _UnseenAid = 0;
  public int UnseenAid { set { if (value >= 0) { _UnseenAid = value; } } get { return _UnseenAid; } }

  // Delve IV
  [SerializeField] protected int _VolcanicBlaze = 0;
  public int VolcanicBlaze { set { if (value >= 0) { _VolcanicBlaze = value; } } get { return _VolcanicBlaze; } }
  [SerializeField] protected int _FreezingCube = 0;
  public int FreezingCube { set { if (value >= 0) { _FreezingCube = value; } } get { return _FreezingCube; } }
  [SerializeField] protected int _AngelicEcho = 0;
  public int AngelicEcho { set { if (value >= 0) { _AngelicEcho = value; } } get { return _AngelicEcho; } }
  [SerializeField] protected int _CursedEvangile = 0;
  public int CursedEvangile { set { if (value >= 0) { _CursedEvangile = value; } } get { return _CursedEvangile; } }
  [SerializeField] protected int _GaleWind = 0;
  public int GaleWind { set { if (value >= 0) { _GaleWind = value; } } get { return _GaleWind; } }
  [SerializeField] protected int _SandBurst = 0;
  public int SandBurst { set { if (value >= 0) { _SandBurst = value; } } get { return _SandBurst; } }
  [SerializeField] protected int _IronBuster = 0;
  public int IronBuster { set { if (value >= 0) { _IronBuster = value; } } get { return _IronBuster; } }
  [SerializeField] protected int _PenetrationArrow = 0;
  public int PenetrationArrow { set { if (value >= 0) { _PenetrationArrow = value; } } get { return _PenetrationArrow; } }
  [SerializeField] protected int _DeadlyDrive = 0;
  public int DeadlyDrive { set { if (value >= 0) { _DeadlyDrive = value; } } get { return _DeadlyDrive; } }
  [SerializeField] protected int _AssassinationHit = 0;
  public int AssassinationHit { set { if (value >= 0) { _AssassinationHit = value; } } get { return _AssassinationHit; } }
  [SerializeField] protected int _PhantomOboro = 0;
  public int PhantomOboro { set { if (value >= 0) { _PhantomOboro = value; } } get { return _PhantomOboro; } }
  [SerializeField] protected int _DominationField = 0;
  public int DominationField { set { if (value >= 0) { _DominationField = value; } } get { return _DominationField; } }
  [SerializeField] protected int _CircleOfSerenity = 0;
  public int CircleOfSerenity { set { if (value >= 0) { _CircleOfSerenity = value; } } get { return _CircleOfSerenity; } }
  [SerializeField] protected int _AuraBurn = 0;
  public int AuraBurn { set { if (value >= 0) { _AuraBurn = value; } } get { return _AuraBurn; } }
  [SerializeField] protected int _LevelEater = 0;
  public int LevelEater { set { if (value >= 0) { _LevelEater = value; } } get { return _LevelEater; } }
  [SerializeField] protected int _WillAwakening = 0;
  public int WillAwakening { set { if (value >= 0) { _WillAwakening = value; } } get { return _WillAwakening; } }
  [SerializeField] protected int _ExactTime = 0;
  public int ExactTime { set { if (value >= 0) { _ExactTime = value; } } get { return _ExactTime; } }

  // Delve V
  [SerializeField] protected int _FlameStrike = 0;
  public int FlameStrike { set { if (value >= 0) { _FlameStrike = value; } } get { return _FlameStrike; } }
  [SerializeField] protected int _FrostLance = 0;
  public int FrostLance { set { if (value >= 0) { _FrostLance = value; } } get { return _FrostLance; } }
  [SerializeField] protected int _ShiningHeal = 0;
  public int ShiningHeal { set { if (value >= 0) { _ShiningHeal = value; } } get { return _ShiningHeal; } }
  [SerializeField] protected int _CircleOfTheDespair = 0;
  public int CircleOfTheDespair { set { if (value >= 0) { _CircleOfTheDespair = value; } } get { return _CircleOfTheDespair; } }
  [SerializeField] protected int _ErraticThunder = 0;
  public int ErraticThunder { set { if (value >= 0) { _ErraticThunder = value; } } get { return _ErraticThunder; } }
  [SerializeField] protected int _Petrification = 0;
  public int Petrification { set { if (value >= 0) { _Petrification = value; } } get { return _Petrification; } }
  [SerializeField] protected int _RagingStorm = 0;
  public int RagingStorm { set { if (value >= 0) { _RagingStorm = value; } } get { return _RagingStorm; } }
  [SerializeField] protected int _PrecisionStrike = 0;
  public int PrecisionStrike { set { if (value >= 0) { _PrecisionStrike = value; } } get { return _PrecisionStrike; } }
  [SerializeField] protected int _UnintentionalHit = 0;
  public int UnintentionalHit { set { if (value >= 0) { _UnintentionalHit = value; } } get { return _UnintentionalHit; } }
  [SerializeField] protected int _CounterDisallow = 0;
  public int CounterDisallow { set { if (value >= 0) { _CounterDisallow = value; } } get { return _CounterDisallow; } }
  [SerializeField] protected int _SigilOfTheHomura = 0;
  public int SigilOfTheHomura { set { if (value >= 0) { _SigilOfTheHomura = value; } } get { return _SigilOfTheHomura; } }
  [SerializeField] protected int _HardestParry = 0;
  public int HardestParry { set { if (value >= 0) { _HardestParry = value; } } get { return _HardestParry; } }
  [SerializeField] protected int _RevolutionAura = 0;
  public int RevolutionAura { set { if (value >= 0) { _RevolutionAura = value; } } get { return _RevolutionAura; } }
  [SerializeField] protected int _OathOfAegis = 0;
  public int OathOfAegis { set { if (value >= 0) { _OathOfAegis = value; } } get { return _OathOfAegis; } }
  [SerializeField] protected int _EverflowMind = 0;
  public int EverflowMind { set { if (value >= 0) { _EverflowMind = value; } } get { return _EverflowMind; } }
  [SerializeField] protected int _AbyssEye = 0;
  public int AbyssEye { set { if (value >= 0) { _AbyssEye = value; } } get { return _AbyssEye; } }
  [SerializeField] protected int _EagleEye = 0;
  public int EagleEye { set { if (value >= 0) { _EagleEye = value; } } get { return _EagleEye; } }
  [SerializeField] protected int _InnerInspiration = 0;
  public int InnerInspiration { set { if (value >= 0) { _InnerInspiration = value; } } get { return _InnerInspiration; } }
  [SerializeField] protected int _SeventhPrinciple = 0;
  public int SeventhPrinciple { set { if (value >= 0) { _SeventhPrinciple = value; } } get { return _SeventhPrinciple; } }

  // Delve VI
  [SerializeField] protected int _CircleOfTheIgnite = 0;
  public int CircleOfTheIgnite { set { if (value >= 0) { _CircleOfTheIgnite = value; } } get { return _CircleOfTheIgnite; } }
  [SerializeField] protected int _WaterPresence = 0;
  public int WaterPresence { set { if (value >= 0) { _WaterPresence = value; } } get { return _WaterPresence; } }
  [SerializeField] protected int _ValkyrieBlade = 0;
  public int ValkyrieBlade { set { if (value >= 0) { _ValkyrieBlade = value; } } get { return _ValkyrieBlade; } }
  [SerializeField] protected int _TheDarkIntensity = 0;
  public int TheDarkIntensity { set { if (value >= 0) { _TheDarkIntensity = value; } } get { return _TheDarkIntensity; } }
  [SerializeField] protected int _CycloneField = 0;
  public int CycloneField { set { if (value >= 0) { _CycloneField = value; } } get { return _CycloneField; } }
  [SerializeField] protected int _LifeGrace = 0;
  public int LifeGrace { set { if (value >= 0) { _LifeGrace = value; } } get { return _LifeGrace; } }
  [SerializeField] protected int _StanceOfTheIai = 0;
  public int StanceOfTheIai { set { if (value >= 0) { _StanceOfTheIai = value; } } get { return _StanceOfTheIai; } }
  [SerializeField] protected int _EternalConcentration = 0;
  public int EternalConcentration { set { if (value >= 0) { _EternalConcentration = value; } } get { return _EternalConcentration; } }
  [SerializeField] protected int _StanceOfMuin = 0;
  public int StanceOfMuin { set { if (value >= 0) { _StanceOfMuin = value; } } get { return _StanceOfMuin; } }
  [SerializeField] protected int _DirtyWisdom = 0;
  public int DirtyWisdom { set { if (value >= 0) { _DirtyWisdom = value; } } get { return _DirtyWisdom; } }
  [SerializeField] protected int _WordOfProphecy = 0;
  public int WordOfProphecy { set { if (value >= 0) { _WordOfProphecy = value; } } get { return _WordOfProphecy; } }
  [SerializeField] protected int _WildSwing = 0;
  public int WildSwing { set { if (value >= 0) { _WildSwing = value; } } get { return _WildSwing; } }
  [SerializeField] protected int _BrilliantForm = 0;
  public int BrilliantForm { set { if (value >= 0) { _BrilliantForm = value; } } get { return _BrilliantForm; } }
  [SerializeField] protected int _FutureVision = 0;
  public int FutureVision { set { if (value >= 0) { _FutureVision = value; } } get { return _FutureVision; } }
  [SerializeField] protected int _SoulShout = 0;
  public int SoulShout { set { if (value >= 0) { _SoulShout = value; } } get { return _SoulShout; } }
  [SerializeField] protected int _AvengerPromise = 0;
  public int AvengerPromise { set { if (value >= 0) { _AvengerPromise = value; } } get { return _AvengerPromise; } }
  [SerializeField] protected int _SigilOfTheFaith = 0;
  public int SigilOfTheFaith { set { if (value >= 0) { _SigilOfTheFaith = value; } } get { return _SigilOfTheFaith; } }
  [SerializeField] protected int _ZeroImmunity = 0;
  public int ZeroImmunity { set { if (value >= 0) { _ZeroImmunity = value; } } get { return _ZeroImmunity; } }
  [SerializeField] protected int _DetachmentFault = 0;
  public int DetachmentFault { set { if (value >= 0) { _DetachmentFault = value; } } get { return _DetachmentFault; } }
  [SerializeField] protected int _OneImmunity = 0;
  public int OneImmunity { set { if (value >= 0) { _OneImmunity = value; } } get { return _OneImmunity; } }

  // Delve VII
  [SerializeField] protected int _LavaAnnihilation = 0;
  public int LavaAnnihilation { set { if (value >= 0) { _LavaAnnihilation = value; } } get { return _LavaAnnihilation; } }
  [SerializeField] protected int _AbsoluteZero = 0;
  public int AbsoluteZero { set { if (value >= 0) { _AbsoluteZero = value; } } get { return _AbsoluteZero; } }
  [SerializeField] protected int _Resurrection = 0;
  public int Resurrection { set { if (value >= 0) { _Resurrection = value; } } get { return _Resurrection; } }
  [SerializeField] protected int _DeathScythe = 0;
  public int DeathScythe { set { if (value >= 0) { _DeathScythe = value; } } get { return _DeathScythe; } }
  [SerializeField] protected int _LightningSquall = 0;
  public int LightningSquall { set { if (value >= 0) { _LightningSquall = value; } } get { return _LightningSquall; } }
  [SerializeField] protected int _EarthQuake = 0;
  public int EarthQuake { set { if (value >= 0) { _EarthQuake = value; } } get { return _EarthQuake; } }
  [SerializeField] protected int _KineticSmash = 0;
  public int KineticSmash { set { if (value >= 0) { _KineticSmash = value; } } get { return _KineticSmash; } }
  [SerializeField] protected int _PiercingArrow = 0;
  public int PiercingArrow { set { if (value >= 0) { _PiercingArrow = value; } } get { return _PiercingArrow; } }
  [SerializeField] protected int _CarnageRush = 0;
  public int CarnageRush { set { if (value >= 0) { _CarnageRush = value; } } get { return _CarnageRush; } }
  [SerializeField] protected int _Ambidexterity = 0;
  public int Ambidexterity { set { if (value >= 0) { _Ambidexterity = value; } } get { return _Ambidexterity; } }
  [SerializeField] protected int _TranscendenceReached = 0;
  public int TranscendenceReached { set { if (value >= 0) { _TranscendenceReached = value; } } get { return _TranscendenceReached; } }
  [SerializeField] protected int _AusterityMatrix = 0;
  public int AusterityMatrix { set { if (value >= 0) { _AusterityMatrix = value; } } get { return _AusterityMatrix; } }
  [SerializeField] protected int _EssenceOverflow = 0;
  public int EssenceOverflow { set { if (value >= 0) { _EssenceOverflow = value; } } get { return _EssenceOverflow; } }
  [SerializeField] protected int _OverwhelmingDestiny = 0;
  public int OverwhelmingDestiny { set { if (value >= 0) { _OverwhelmingDestiny = value; } } get { return _OverwhelmingDestiny; } }
  [SerializeField] protected int _DemonContract = 0;
  public int DemonContract { set { if (value >= 0) { _DemonContract = value; } } get { return _DemonContract; } }
  [SerializeField] protected int _StanceOfTheKokoroe = 0;
  public int StanceOfTheKokoroe { set { if (value >= 0) { _StanceOfTheKokoroe = value; } } get { return _StanceOfTheKokoroe; } }
  [SerializeField] protected int _TimeSkip = 0;
  public int TimeSkip { set { if (value >= 0) { _TimeSkip = value; } } get { return _TimeSkip; } }

  [SerializeField] protected int _CounterAttack = 0;
  public int CounterAttack { set { if (value >= 0) { _CounterAttack = value; } } get { return _CounterAttack; } }

  [SerializeField] protected int _Catastrophe = 0;
  public int Catastrophe { set { if (value >= 0) { _Catastrophe = value; } } get { return _Catastrophe; } }
  [SerializeField] protected int _Genesis = 0;
  public int Genesis { set { if (value >= 0) { _Genesis = value; } } get { return _Genesis; } }

  [SerializeField] protected int _SanctionField = 0;
  public int SanctionField
  {
    set
    {
      if (value >= 0)
      {
        _SanctionField = value;
      }
    }
    get { return _SanctionField; }
  }
  [SerializeField] protected int _ValkyrieBreak = 0;
  public int ValkyrieBreak
  {
    set
    {
      if (value >= 0)
      {
        _ValkyrieBreak = value;
      }
    }
    get { return _ValkyrieBreak; }
  }

  [SerializeField] protected int _WhisperVoice = 0;
  public int WhisperVoice
  {
    set
    {
      if (value >= 0)
      {
        _WhisperVoice = value;
      }
    }
    get { return _WhisperVoice; }
  }
  [SerializeField] protected int _WarSwing = 0;
  public int WarSwing
  {
    set
    {
      if (value >= 0)
      {
        _WarSwing = value;
      }
    }
    get { return _WarSwing; }
  }
  [SerializeField] protected int _ReachableTarget = 0;
  public int ReachableTarget
  {
    set
    {
      if (value >= 0)
      {
        _ReachableTarget = value;
      }
    }
    get { return _ReachableTarget; }
  }
  [SerializeField] protected int _HawkEye = 0;
  public int HawkEye
  {
    set
    {
      if (value >= 0)
      {
        _HawkEye = value;
      }
    }
    get { return _HawkEye; }
  }
  [SerializeField] protected int _DissensionRhythm = 0;
  public int DissensionRhythm
  {
    set
    {
      if (value >= 0)
      {
        _DissensionRhythm = value;
      }
    }
    get { return _DissensionRhythm; }
  }
  [SerializeField] protected int _RuneStrike = 0;
  public int RuneStrike
  {
    set
    {
      if (value >= 0)
      {
        _RuneStrike = value;
      }
    }
    get { return _RuneStrike; }
  }
  #endregion

  #region "Method"
  public BuffImage SearchFieldBuff(string field_buff_name)
  {
    if (this.objFieldPanel == null) { return null; }

    BuffImage[] buffList = this.objFieldPanel.GetComponentsInChildren<BuffImage>();
    for (int ii = 0; ii < buffList.Length; ii++)
    {
      if (buffList[ii].BuffName == field_buff_name)
      {
        //Debug.Log("Detect field_buff_name: " + field_buff_name);
        return buffList[ii];
      }
    }

    return null;
  }

  // もう少し抽象化した書き方がありそうが、芋プログラミングで良しとする。
  public bool GetResistPoisonLogic()
  {
    if ((this.IsResistPoison) ||
     (this.MainWeapon != null && this.MainWeapon.ResistPoison) ||
     (this.SubWeapon != null && this.SubWeapon.ResistPoison) ||
     (this.MainArmor != null && this.MainArmor.ResistPoison) ||
     (this.Accessory1 != null && this.Accessory1.ResistPoison) ||
     (this.Accessory2 != null && this.Accessory2.ResistPoison) ||
     (this.Artifact != null && this.Artifact.ResistPoison))
    {
      return true;
    }
    // 猛毒はサークル・オブ・セレニティで防げない
    //if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    //{
    //  return true;
    //}

    return false;
  }

  public bool GetResistSilenceLogic()
  {
    if ((this.IsResistSilence) ||
     (this.MainWeapon != null && this.MainWeapon.ResistSilence) ||
     (this.SubWeapon != null && this.SubWeapon.ResistSilence) ||
     (this.MainArmor != null && this.MainArmor.ResistSilence) ||
     (this.Accessory1 != null && this.Accessory1.ResistSilence) ||
     (this.Accessory2 != null && this.Accessory2.ResistSilence) ||
     (this.Artifact != null && this.Artifact.ResistSilence))
    {
      return true;
    }
    if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    {
      return true;
    }

    return false;
  }

  public bool GetResistBindLogic()
  {
    if ((this.IsResistBind) ||
     (this.MainWeapon != null && this.MainWeapon.ResistBind) ||
     (this.SubWeapon != null && this.SubWeapon.ResistBind) ||
     (this.MainArmor != null && this.MainArmor.ResistBind) ||
     (this.Accessory1 != null && this.Accessory1.ResistBind) ||
     (this.Accessory2 != null && this.Accessory2.ResistBind) ||
     (this.Artifact != null && this.Artifact.ResistBind))
    {
      return true;
    }
    if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    {
      return true;
    }

    return false;
  }

  public bool GetResistSleepLogic()
  {
    if ((this.IsResistSleep) ||
     (this.MainWeapon != null && this.MainWeapon.ResistSleep) ||
     (this.SubWeapon != null && this.SubWeapon.ResistSleep) ||
     (this.MainArmor != null && this.MainArmor.ResistSleep) ||
     (this.Accessory1 != null && this.Accessory1.ResistSleep) ||
     (this.Accessory2 != null && this.Accessory2.ResistSleep) ||
     (this.Artifact != null && this.Artifact.ResistSleep))
    {
      return true;
    }
    if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    {
      return true;
    }

    return false;
  }

  public bool GetResistStunLogic()
  {
    if ((this.IsResistStun) ||
     (this.MainWeapon != null && this.MainWeapon.ResistStun) ||
     (this.SubWeapon != null && this.SubWeapon.ResistStun) ||
     (this.MainArmor != null && this.MainArmor.ResistStun) ||
     (this.Accessory1 != null && this.Accessory1.ResistStun) ||
     (this.Accessory2 != null && this.Accessory2.ResistStun) ||
     (this.Artifact != null && this.Artifact.ResistStun))
    {
      return true;
    }
    if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    {
      return true;
    }

    return false;
  }

  public bool GetResistParalyzeLogic()
  {
    if ((this.IsResistParalyze) ||
     (this.MainWeapon != null && this.MainWeapon.ResistParalyze) ||
     (this.SubWeapon != null && this.SubWeapon.ResistParalyze) ||
     (this.MainArmor != null && this.MainArmor.ResistParalyze) ||
     (this.Accessory1 != null && this.Accessory1.ResistParalyze) ||
     (this.Accessory2 != null && this.Accessory2.ResistParalyze) ||
     (this.Artifact != null && this.Artifact.ResistParalyze))
    {
      return true;
    }
    if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    {
      return true;
    }

    return false;
  }

  public bool GetResistFreezeLogic()
  {
    if ((this.IsResistFreeze) ||
     (this.MainWeapon != null && this.MainWeapon.ResistFreeze) ||
     (this.SubWeapon != null && this.SubWeapon.ResistFreeze) ||
     (this.MainArmor != null && this.MainArmor.ResistFreeze) ||
     (this.Accessory1 != null && this.Accessory1.ResistFreeze) ||
     (this.Accessory2 != null && this.Accessory2.ResistFreeze) ||
     (this.Artifact != null && this.Artifact.ResistFreeze))
    {
      return true;
    }
    // 凍結はサークル・オブ・セレニティで防げない
    //if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    //{
    //  return true;
    //}

    return false;
  }

  public bool GetResistFearLogic()
  {
    if ((this.IsResistFear) ||
     (this.MainWeapon != null && this.MainWeapon.ResistFear) ||
     (this.SubWeapon != null && this.SubWeapon.ResistFear) ||
     (this.MainArmor != null && this.MainArmor.ResistFear) ||
     (this.Accessory1 != null && this.Accessory1.ResistFear) ||
     (this.Accessory2 != null && this.Accessory2.ResistFear) ||
     (this.Artifact != null && this.Artifact.ResistFear))
    {
      return true;
    }
    if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    {
      return true;
    }

    return false;
  }

  public bool GetResistTemptationLogic()
  {
    if ((this.IsResistTemptation) ||
     (this.MainWeapon != null && this.MainWeapon.ResistTemptation) ||
     (this.SubWeapon != null && this.SubWeapon.ResistTemptation) ||
     (this.MainArmor != null && this.MainArmor.ResistTemptation) ||
     (this.Accessory1 != null && this.Accessory1.ResistTemptation) ||
     (this.Accessory2 != null && this.Accessory2.ResistTemptation) ||
     (this.Artifact != null && this.Artifact.ResistTemptation))
    {
      return true;
    }
    if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    {
      return true;
    }

    return false;
  }

  public bool GetResistSlowLogic()
  {
    if ((this.IsResistSlow) ||
     (this.MainWeapon != null && this.MainWeapon.ResistSlow) ||
     (this.SubWeapon != null && this.SubWeapon.ResistSlow) ||
     (this.MainArmor != null && this.MainArmor.ResistSlow) ||
     (this.Accessory1 != null && this.Accessory1.ResistSlow) ||
     (this.Accessory2 != null && this.Accessory2.ResistSlow) ||
     (this.Artifact != null && this.Artifact.ResistSlow))
    {
      return true;
    }
    if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    {
      return true;
    }

    return false;
  }

  public bool GetResistDizzyLogic()
  {
    if ((this.IsResistDizzy) ||
     (this.MainWeapon != null && this.MainWeapon.ResistDizzy) ||
     (this.SubWeapon != null && this.SubWeapon.ResistDizzy) ||
     (this.MainArmor != null && this.MainArmor.ResistDizzy) ||
     (this.Accessory1 != null && this.Accessory1.ResistDizzy) ||
     (this.Accessory2 != null && this.Accessory2.ResistDizzy) ||
     (this.Artifact != null && this.Artifact.ResistDizzy))
    {
      return true;
    }
    if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    {
      return true;
    }

    return false;
  }

  public bool GetResistSlipLogic()
  {
    if ((this.IsResistSlip) ||
     (this.MainWeapon != null && this.MainWeapon.ResistSlip) ||
     (this.SubWeapon != null && this.SubWeapon.ResistSlip) ||
     (this.MainArmor != null && this.MainArmor.ResistSlip) ||
     (this.Accessory1 != null && this.Accessory1.ResistSlip) ||
     (this.Accessory2 != null && this.Accessory2.ResistSlip) ||
     (this.Artifact != null && this.Artifact.ResistSlip))
    {
      return true;
    }
    // 出血はサークル・オブ・セレニティで防げない
    //if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    //{
    //  return true;
    //}

    return false;
  }

  public bool GetResistCannotResurrectLogic()
  {
    if ((this.IsResistCannotResurrect) ||
     (this.MainWeapon != null && this.MainWeapon.ResistCannotResurrect) ||
     (this.SubWeapon != null && this.SubWeapon.ResistCannotResurrect) ||
     (this.MainArmor != null && this.MainArmor.ResistCannotResurrect) ||
     (this.Accessory1 != null && this.Accessory1.ResistCannotResurrect) ||
     (this.Accessory2 != null && this.Accessory2.ResistCannotResurrect) ||
     (this.Artifact != null && this.Artifact.ResistCannotResurrect))
    {
      return true;
    }
    // 復活不可はサークル・オブ・セレニティで防げない
    //if (SearchFieldBuff(Fix.CIRCLE_OF_SERENITY) != null)
    //{
    //  return true;
    //}

    return false;
  }


  public int GetPotentialEnergy()
  {
    return 100; // todo 係数化して変化があると良い。
  }
  public void MaxGain()
  {
    _currentLife = MaxLife;
    _currentManaPoint = MaxManaPoint;
    _currentSkillPoint = MaxSkillPoint;
    //_currentActionPoint = MaxActionPoint;
    //_currentEnergyPoint = MaxEnergyPoint;
  }

  public void DecisionDefense()
  {
    Debug.Log("DecisionDefense");
    CurrentActionCommand = Fix.DEFENSE;
    if (txtActionCommand != null)
    {
      txtActionCommand.text = Fix.DEFENSE;
    }
    if (objMainButton != null)
    {
      Debug.Log("DecisionDefense: objMainButton detect");
      objMainButton.ApplyImageIcon(Fix.DEFENSE);
    }
    Debug.Log("DecisionDefense(E)");
  }

  public void DeadPlayer()
  {
    this._dead = true;
    this._currentLife = 0;
    this._currentInstantPoint = 0;
    UpdateInstantPointGauge();

    if (this.objMainButton != null)
    {
      // 【要検討】リザレクション対象にするため、生死に関わらず、対象とする事を許可
      //this.MainObjectButton.Enabled = false; // delete
      this.objMainButton.GetComponent<Image>().color = Color.grey;
    }

    if (this.txtName != null) this.txtName.color = Color.red;
    if (this.txtLife != null) this.txtLife.color = Color.red;
  }

  public void ResurrectPlayer(int life)
  {
    if (this.IsCannotResurrect == false)
    {
      this.CurrentLife = life;
      this.Dead = false;
      if (this.objMainButton != null)
      {
        this.objMainButton.gameObject.SetActive(true);
        this.objMainButton.GetComponent<Image>().color = Color.white;// this.MainColor;
      }
      if (this.txtName != null) { this.txtName.color = Color.black; }
      if (this.txtLife != null) { this.txtLife.color = Color.black; this.txtLife.text = CurrentLife.ToString(); }
    }
  }

  public void MaxLifeCheck()
  {
    if (this.CurrentLife >= this.MaxLife)
    {
      this.CurrentLife = this.MaxLife;
    }
  }

  public void UpdateLife()
  {
    float dx = (float)this.CurrentLife / (float)this.MaxLife;

    if (this.txtLife != null)
    {
      this.txtLife.text = this.CurrentLife.ToString();
    }
    if (this.objCurrentLifeGauge != null)
    {
      this.objCurrentLifeGauge.rectTransform.localScale = new Vector3(dx, 1.0f);
    }
    if (this.objCurrentLifeBorder != null)
    {
      if (this.CurrentLife < this.MaxLife)
      {
        this.objCurrentLifeBorder.gameObject.SetActive(true);
      }
      else
      {
        this.objCurrentLifeBorder.gameObject.SetActive(false);
      }
    }
  }

  public void UpdatePlayerInstantPoint()
  {
    UpdateInstantPointGauge();
  }
  public void UpdateInstantPointGauge()
  {
    float dx = (float)this.CurrentInstantPoint / (float)this.MaxInstantPoint;
    if (this.objCurrentInstantGauge != null)
    {
      this.objCurrentInstantGauge.rectTransform.localScale = new Vector2(dx, 1.0f);
    }
    //if (this.objCurrentInstangGauge_AC != null)
    //{
    //  this.objCurrentInstangGauge_AC.rectTransform.localScale = new Vector2(dx, 1.0f);
    //}
  }

  public void UpdateBattleGaugeArrow(float gui_view_factor)
  {
    if (this.objArrow != null)
    {
      RectTransform rect = this.objArrow.GetComponent<RectTransform>();
      rect.position = new Vector3(this.BattleGaugeArrow * gui_view_factor, rect.position.y, rect.position.z);
    }
  }

  public void UpdateActionPoint()
  {
    if (this.CurrentActionPoint < this.MaxActionPoint)
    {
      this.CurrentActionPoint += 0; // 基本は自然回復しない
    }
    UpdateActionPointGauge();
  }
  public void UpdateActionPointGauge()
  {
    float dx = (float)this.CurrentActionPoint / (float)this.MaxActionPoint;
    if (this.objCurrentActionPointGauge != null)
    {
      this.objCurrentActionPointGauge.rectTransform.localScale = new Vector2(dx, 1.0f);
    }
    if (this.txtActionPoint != null)
    {
      this.txtActionPoint.text = this.CurrentActionPoint.ToString() + " / " + this.MaxActionPoint.ToString();
    }
    if (this.imgActionPointList != null)
    {
      for (int ii = 0; ii < this.imgActionPointList.Count; ii++)
      {
        UpdateActionPointIcon(this.imgActionPointList[ii], this.CurrentActionPoint, Fix.AP_BASE * (ii + 1));
      }
    }
  }

  public void UpdateEnergyPoint()
  {
    float dx = (float)this._currentEnergyPoint / (float)this.MaxEnergyPoint;
    if (this.imgCurrentEnergyPointGauge != null)
    {
      if (dx < 0.10f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_0"); }
      if (0.10f <= dx && dx < 0.20f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_10"); }
      if (0.20f <= dx && dx < 0.30f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_20"); }
      if (0.30f <= dx && dx < 0.40f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_30"); }
      if (0.40f <= dx && dx < 0.50f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_40"); }
      if (0.50f <= dx && dx < 0.60f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_50"); }
      if (0.60f <= dx && dx < 0.70f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_60"); }
      if (0.70f <= dx && dx < 0.80f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_70"); }
      if (0.80f <= dx && dx < 0.90f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_80"); }
      if (0.90f <= dx && dx < 1.00f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_90"); }
      if (dx >= 1.00f) { this.imgCurrentEnergyPointGauge.sprite = Resources.Load<Sprite>("Energy_100"); }
    }
  }

  public void UpdateManaPoint()
  {
    float dx = (float)this._currentManaPoint / (float)this.MaxManaPoint;
    if (this.objCurrentManaPointGauge != null)
    {
      this.objCurrentManaPointGauge.rectTransform.localScale = new Vector2(dx, 1.0f);
    }
    if (this.txtManaPoint != null)
    {
      this.txtManaPoint.text = this.CurrentManaPoint.ToString() + " / " + this.MaxManaPoint.ToString();
    }
    if (this.objCurrentManaPointBorder != null)
    {
      if (dx >= 1.0f)
      {
        this.objCurrentManaPointBorder.gameObject.SetActive(false);
      }
      else
      {
        this.objCurrentManaPointBorder.gameObject.SetActive(true);
      }
    }
  }

  public void UpdateSkillPoint()
  {
    float dx = (float)this._currentSkillPoint / (float)this.MaxSkillPoint;
    if (this.objCurrentSkillPointGauge != null)
    {
      this.objCurrentSkillPointGauge.rectTransform.localScale = new Vector2(dx, 1.0f);
    }
    if (this.txtSkillPoint != null)
    {
      this.txtSkillPoint.text = this.CurrentSkillPoint.ToString() + " / " + this.MaxSkillPoint.ToString();
    }
    if (this.objCurrentSkillPointBorder != null)
    {
      if (dx >= 1.0f)
      {
        this.objCurrentSkillPointBorder.gameObject.SetActive(false);
      }
      else
      {
        this.objCurrentSkillPointBorder.gameObject.SetActive(true);
      }
    }
  }

  private void UpdateActionPointIcon(Image img, double current_ap, int require_ap)
  {
    if (current_ap >= require_ap)
    {
      img.sprite = Resources.Load<Sprite>("ActionPoint");
    }
    else
    {
      img.sprite = Resources.Load<Sprite>("ActionPoint_use");
    }
  }

  public int GetNextExp()
  {
    int result = 50;
    //if (this.Level == 1) { return result; }

    for (int ii = 1 ; ii < 100; ii++)
    {
      if (this.Level >= ii) { result += (ii - 1) * 100; }
      else { break; }
    }
    return result;
  }

  //public int GetRemainPoint()
  //{
  //  int result = 0;
  //  if (this.Level == 1) { result = 3; }
  //  else if (this.Level == 2) { result = 4; }
  //  else if (this.Level == 3) { result = 5; }
  //  else if (this.Level == 4) { result = 6; }
  //  else if (this.Level == 5) { result = 7; }
  //  else if (this.Level == 6) { result = 8; }
  //  else if (this.Level == 7) { result = 10; }
  //  else if (this.Level == 8) { result = 12; }
  //  else if (this.Level == 9) { result = 14; }
  //  else { result = 0; }
  //  return result;
  //}

  public void AddStrength()
  {
    if (this._remainPoint <= 0) { return; }
    this._plusStrength += 1;
    this._remainPoint -= 1;
  }
  public void AddAgility()
  {
    if (this._remainPoint <= 0) { return; }
    this._plusAgility += 1;
    this._remainPoint -= 1;
  }
  public void AddIntelligence()
  {
    if (this._remainPoint <= 0) { return; }
    this._plusIntelligence += 1;
    this._remainPoint -= 1;
  }
  public void AddStamina()
  {
    if (this._remainPoint <= 0) { return; }
    this._plusStamina += 1;
    this._remainPoint -= 1;
  }
  public void AddMind()
  {
    if (this._remainPoint <= 0) { return; }
    this._plusMind += 1;
    this._remainPoint -= 1;
  }

  public void GetReadyLevelUp()
  {
    ResetLevelUp();
  }

  public void ResetLevelUp()
  {
    this._remainPoint += this._plusStrength;
    this._remainPoint += this._plusAgility;
    this._remainPoint += this._plusIntelligence;
    this._remainPoint += this._plusStamina;
    this._remainPoint += this._plusMind;

    this._plusStrength = 0;
    this._plusAgility = 0;
    this._plusIntelligence = 0;
    this._plusStamina = 0;
    this._plusMind = 0;
  }
  public void AcceptLevelup()
  {
    if (this.Exp >= this.GetNextExp())
    {
      this.Exp = 0;
      this._level += 1;
    }
    this._strength += this._plusStrength;
    this._agility += this._plusAgility;
    this._intelligence += this._plusIntelligence;
    this._stamina += this._plusStamina;
    this._mind += this._plusMind;

    //this._remainPoint = 0;
    this._plusStrength = 0;
    this._plusAgility = 0;
    this._plusIntelligence = 0;
    this._plusStamina = 0;
    this._plusMind = 0;
    //this._exp = 0;
  }

  public void GainExp(int gain_exp)
  {
    if (this.GetNextExp() - this._exp > 0)
    {
      this._exp += gain_exp;
      //if (this._exp >= this.GetNextExp())
      //{
      //  this._exp = this.GetNextExp();
      //}
    }
  }

  /// <summary>
  /// 装備可能なアイテムかどうかを装備箇所毎に判定する。
  /// キャラクター毎に設定する。
  /// </summary>
  /// <param name="equip_type"></param>
  /// <param name="item"></param>
  /// <returns>  true: 装備可能</returns>
  ///           false: 装備不可
  public bool Equipable(Fix.EquipType equip_type, Item item)
  {
    if (equip_type == Fix.EquipType.MainWeapon)
    {
      Debug.Log("Equipable start : MainWeapon");
      //if ((this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Sword && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Lance && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Axe && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Claw && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Bow && item.GripType == Item.GripTypes.TwoHand) ||
      //    (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Sword && item.GripType == Item.GripTypes.TwoHand) ||
      //    (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Lance && item.GripType == Item.GripTypes.TwoHand) ||
      //    (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Axe && item.GripType == Item.GripTypes.TwoHand))
      //{
      //  return true;
      //}
      //if ((this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Onehand_Rod && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Onehand_Book && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Onehand_Orb && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Twohand_Rod && item.GripType == Item.GripTypes.TwoHand))
      //{
      //  return true;
      //}
      //if ((this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Sword && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Lance && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Axe && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Claw && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Bow && item.GripType == Item.GripTypes.TwoHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Sword && item.GripType == Item.GripTypes.TwoHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Lance && item.GripType == Item.GripTypes.TwoHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Axe && item.GripType == Item.GripTypes.TwoHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Rod && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Book && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Orb && item.GripType == Item.GripTypes.OneHand) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Rod && item.GripType == Item.GripTypes.TwoHand))
      //{
      //  return true;
      //}

      if (this.FullName == Fix.NAME_EIN_WOLENCE)
      {
        if (item.ItemType == Item.ItemTypes.Onehand_Sword ||
            item.ItemType == Item.ItemTypes.Onehand_Lance ||
            item.ItemType == Item.ItemTypes.Onehand_Axe ||
            item.ItemType == Item.ItemTypes.Twohand_Sword ||
            item.ItemType == Item.ItemTypes.Twohand_Lance ||
            item.ItemType == Item.ItemTypes.Twohand_Axe)
        {
          return true;
        }
      }
      else if (this.FullName == Fix.NAME_LANA_AMIRIA)
      {
        if (item.ItemType == Item.ItemTypes.Onehand_Claw ||
            item.ItemType == Item.ItemTypes.Onehand_Rod ||
            item.ItemType == Item.ItemTypes.Onehand_Book ||
            item.ItemType == Item.ItemTypes.Onehand_Orb ||
            item.ItemType == Item.ItemTypes.Twohand_Rod)
        {
          return true;
        }
      }
      else if (this.FullName == Fix.NAME_EONE_FULNEA)
      {
        if (item.ItemType == Item.ItemTypes.Onehand_Rod ||
            item.ItemType == Item.ItemTypes.Onehand_Book ||
            item.ItemType == Item.ItemTypes.Onehand_Orb ||
            item.ItemType == Item.ItemTypes.Twohand_Bow)
        {
          return true;
        }
      }
      else if (this.FullName == Fix.NAME_BILLY_RAKI)
      {
        if (item.ItemType == Item.ItemTypes.Onehand_Sword ||
            item.ItemType == Item.ItemTypes.Onehand_Lance ||
            item.ItemType == Item.ItemTypes.Onehand_Axe ||
            item.ItemType == Item.ItemTypes.Onehand_Claw ||
            item.ItemType == Item.ItemTypes.Twohand_Sword ||
            item.ItemType == Item.ItemTypes.Twohand_Lance ||
            item.ItemType == Item.ItemTypes.Twohand_Axe)
        {
          return true;
        }
      }
      else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
      {
        if (item.ItemType == Item.ItemTypes.Onehand_Sword ||
         item.ItemType == Item.ItemTypes.Onehand_Lance ||
         item.ItemType == Item.ItemTypes.Onehand_Axe ||
         item.ItemType == Item.ItemTypes.Onehand_Claw ||
         item.ItemType == Item.ItemTypes.Onehand_Rod ||
         item.ItemType == Item.ItemTypes.Onehand_Book ||
         item.ItemType == Item.ItemTypes.Onehand_Orb)
        {
          return true;
        }
      }

      return false;
    }

    if (equip_type == Fix.EquipType.SubWeapon)
    {
      //if ((this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Shield) ||
      //    (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Shield))
      //{
      //  return true;
      //}

      // 両手持ちを装備している場合、サブウェポンは装備できない。
      if (this.MainWeapon != null && this.MainWeapon.GripType == Item.GripTypes.TwoHand)
      {
        return false;
      }

      if (item.ItemType == Item.ItemTypes.Shield)
      {
        return true;
      }
      return false;
    }

    if (equip_type == Fix.EquipType.Armor)
    {
      //if ((this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Heavy_Armor) ||
      //    (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Middle_Armor) ||
      //    (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Light_Armor) ||
      //    (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Light_Armor) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Middle_Armor) ||
      //    (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Light_Armor))
      //{
      //  return true;
      //}

      if (this.FullName == Fix.NAME_EIN_WOLENCE)
      {
        if (item.ItemType == Item.ItemTypes.Heavy_Armor ||
            item.ItemType == Item.ItemTypes.Middle_Armor)
        {
          return true;
        }
      }
      else if (this.FullName == Fix.NAME_LANA_AMIRIA)
      {
        if (item.ItemType == Item.ItemTypes.Middle_Armor ||
            item.ItemType == Item.ItemTypes.Light_Armor)
        {
          return true;
        }

      }
      else if (this.FullName == Fix.NAME_EONE_FULNEA)
      {
        if (item.ItemType == Item.ItemTypes.Middle_Armor ||
            item.ItemType == Item.ItemTypes.Light_Armor)
        {
          return true;
        }

      }
      else if (this.FullName == Fix.NAME_BILLY_RAKI)
      {
        if (item.ItemType == Item.ItemTypes.Heavy_Armor ||
            item.ItemType == Item.ItemTypes.Middle_Armor)
        {
          return true;
        }

      }
      else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
      {
        if (item.ItemType == Item.ItemTypes.Heavy_Armor ||
            item.ItemType == Item.ItemTypes.Middle_Armor ||
            item.ItemType == Item.ItemTypes.Light_Armor)
        {
          return true;
        }

      }
      return false;
    }

    if (equip_type == Fix.EquipType.Accessory1 ||
        equip_type == Fix.EquipType.Accessory2)
    {
      if (item.ItemType == Item.ItemTypes.Accessory)
      {
        return true;
      }
      return false;
    }

    if (equip_type == Fix.EquipType.Artifact)
    {
      if (item.ItemType == Item.ItemTypes.Accessory ||
          item.ItemType == Item.ItemTypes.Artifact)
      {
        return true;
      }
      return false;
    }

    return false;
  }

  public void BuffCountdown()
  {
    if (this.objBuffPanel == null) { return; }

    // unity潜在バグの可能性。null合体演算子、厳密にはnull判定かどうかを行おうとした時、
    // missing exceptionが発生するので、null合体演算子はここでは使わない。
    //BuffImage[] buffList = this.objBuffPanel?.GetComponentsInChildren<BuffImage>() ?? null;
    BuffImage[] buffList = this.objBuffPanel.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    for (int ii = 0; ii < buffList.Length; ii++)
    {
      buffList[ii].BuffCountDown();
    }
  }

  public void GainManaPoint()
  {
    this.CurrentManaPoint += 1;
  }

  public void GainSkillPoint()
  {
    this.CurrentSkillPoint += 1;

    BuffImage leylineSchema = this.SearchFieldBuff(Fix.LEYLINE_SCHEMA);
    if (leylineSchema != null)
    {
      this.CurrentSkillPoint += (int)(leylineSchema.EffectValue);
    }
  }

  public BuffImage IsResistPoison
  {
    get { return SearchBuff(Fix.BUFF_RESIST_POISON); }
  }

  public BuffImage IsResistSilence
  {
    get { return SearchBuff(Fix.BUFF_RESIST_SILENCE); }
  }

  public BuffImage IsResistBind
  {
    get { return SearchBuff(Fix.BUFF_RESIST_BIND); }
  }

  public BuffImage IsResistSleep
  {
    get { return SearchBuff(Fix.BUFF_RESIST_SLEEP); }
  }

  public BuffImage IsResistStun
  {
    get { return SearchBuff(Fix.BUFF_RESIST_STUN); }
  }

  public BuffImage IsResistParalyze
  {
    get { return SearchBuff(Fix.BUFF_RESIST_PARALYZE); }
  }

  public BuffImage IsResistFreeze
  {
    get { return SearchBuff(Fix.BUFF_RESIST_FREEZE); }
  }

  public BuffImage IsResistFear
  {
    get { return SearchBuff(Fix.BUFF_RESIST_FEAR); }
  }

  public BuffImage IsResistTemptation
  {
    get { return SearchBuff(Fix.BUFF_RESIST_TEMPTATION); }
  }

  public BuffImage IsResistSlow
  {
    get { return SearchBuff(Fix.BUFF_RESIST_SLOW); }
  }

  public BuffImage IsResistDizzy
  {
    get { return SearchBuff(Fix.BUFF_RESIST_DIZZY); }
  }

  public BuffImage IsResistSlip
  {
    get { return SearchBuff(Fix.BUFF_RESIST_SLIP); }
  }

  public BuffImage IsResistCannotResurrect
  {
    get { return SearchBuff(Fix.BUFF_RESIST_CANNOT_RESURRECT); }
  }


  public BuffImage IsPoison
  {
    get { return SearchBuff(Fix.EFFECT_POISON); }
  }

  public BuffImage IsSilent
  {
    get { return SearchBuff(Fix.EFFECT_SILENT); }
  }

  public BuffImage IsBind
  {
    get { return SearchBuff(Fix.EFFECT_BIND); }
  }

  public BuffImage IsSleep
  {
    get { return SearchBuff(Fix.EFFECT_SLEEP); }
  }

  public BuffImage IsStun
  {
    get { return SearchBuff(Fix.EFFECT_STUN); }
  }

  public BuffImage IsParalyze
  {
    get { return SearchBuff(Fix.EFFECT_PARALYZE); }
  }

  public BuffImage IsFreeze
  {
    get { return SearchBuff(Fix.EFFECT_FREEZE); }
  }

  public BuffImage IsFear
  {
    get { return SearchBuff(Fix.EFFECT_FEAR); }
  }

  public BuffImage IsTemptation
  {
    get { return SearchBuff(Fix.EFFECT_TEMPTATION); }
  }

  public BuffImage IsSlow
  {
    get { return SearchBuff(Fix.EFFECT_SLOW); }
  }

  public BuffImage IsDizzy
  {
    get { return SearchBuff(Fix.EFFECT_DIZZY); }
  }

  public BuffImage IsSlip
  {
    get {return SearchBuff(Fix.EFFECT_SLIP); }
  }

  public BuffImage IsCannotResurrect
  {
    get { return SearchBuff(Fix.EFFECT_CANNOT_RESURRECT); }
  }

  public BuffImage IsSkyShield
  {
    get { return SearchBuff(Fix.SKY_SHIELD); }
  }

  public BuffImage IsAuraOfPower
  {
    get { return SearchBuff(Fix.AURA_OF_POWER); }
  }

  public BuffImage IsIceNeedle
  {
    get { return SearchBuff(Fix.ICE_NEEDLE); }
  }

  public BuffImage IsAirCutter
  {
    get { return SearchBuff(Fix.AIR_CUTTER); }
  }

  public BuffImage IsRockSlum
  {
    get { return SearchBuff(Fix.ROCK_SLAM); }
  }

  public BuffImage IsShadowBlast
  {
    get { return SearchBuff(Fix.SHADOW_BLAST); }
  }

  public BuffImage IsHunterShot
  {
    get { return SearchBuff(Fix.HUNTER_SHOT); }
  }

  public BuffImage IsLegStrike
  {
    get { return SearchBuff(Fix.LEG_STRIKE); }
  }

  public BuffImage IsHeartOfLife
  {
    get { return SearchBuff(Fix.HEART_OF_LIFE); }
  }

  public BuffImage IsTrueSight
  {
    get { return SearchBuff(Fix.TRUE_SIGHT); }
  }

  public BuffImage IsFlameBlade
  {
    get { return SearchBuff(Fix.FLAME_BLADE); }
  }

  public BuffImage IsSpeedStep
  {
    get {return SearchBuff(Fix.SPEED_STEP); }
  }

  public BuffImage IsBloodSign
  {
    get { return SearchBuff(Fix.BLOOD_SIGN); }
  }

  public BuffImage IsDivineCircle
  {
    get { return SearchBuff(Fix.DIVINE_CIRCLE); }
  }

  public BuffImage IsFortuneSpirit
  {
    get { return SearchBuff(Fix.FORTUNE_SPIRIT); }
  }

  public BuffImage IsStanceOfTheBlade
  {
    get { return SearchBuff(Fix.STANCE_OF_THE_BLADE); }
  }

  public BuffImage IsStanceOfTheGuard
  {
    get { return SearchBuff(Fix.STANCE_OF_THE_GUARD); }
  }

  public BuffImage IsBlackContract
  {
    get { return SearchBuff(Fix.BLACK_CONTRACT); }
  }

  public BuffImage IsSonicPulse
  {
    get { return SearchBuff(Fix.SONIC_PULSE, Fix.SONIC_PULSE_JP); }
  }

  public BuffImage IsLandShatter
  {
    get { return SearchBuff(Fix.LAND_SHATTER, Fix.LAND_SHATTER_JP); }
  }

  public BuffImage IsEyeOfTheIsshin
  {
    get { return SearchBuff(Fix.EYE_OF_THE_ISSHIN); }
  }

  public BuffImage IsConcussiveHit
  {
    get { return SearchBuff(Fix.CONCUSSIVE_HIT); }
  }

  public BuffImage IsBoneCrush
  {
    get { return SearchBuff(Fix.BONE_CRUSH, Fix.BONE_CRUSH_JP); }
  }

  public BuffImage IsSigilOfThePending
  {
    get { return SearchBuff(Fix.SIGIL_OF_THE_PENDING, Fix.SIGIL_OF_THE_PENDING_JP); }
  }

  public BuffImage IsStormArmor
  {
    get { return SearchBuff(Fix.STORM_ARMOR); }
  }

  public BuffImage IsVoiceOfVigor
  {
    get { return SearchBuff(Fix.VOICE_OF_VIGOR); }
  }

  public BuffImage IsGaleWind
  {
    get { return SearchBuff(Fix.GALE_WIND); }
  }

  public BuffImage IsCursedEvangile
  {
    get { return SearchBuff(Fix.CURSED_EVANGILE); }
  }

  public BuffImage IsPenetrationArrow
  {
    get { return SearchBuff(Fix.PENETRATION_ARROW); }
  }

  public BuffImage IsWillAwakening
  {
    get { return SearchBuff(Fix.WILL_AWAKENING); }
  }

  public BuffImage IsPhantomOboro
  {
    get { return SearchBuff(Fix.PHANTOM_OBORO); }
  }

  public BuffImage IsDeadlyDrive
  {
    get { return SearchBuff(Fix.DEADLY_DRIVE); }
  }

  public BuffImage IsFlameStrike
  {
    get { return SearchBuff(Fix.FLAME_STRIKE); }
  }

  public BuffImage IsFrostLance
  {
    get { return SearchBuff(Fix.FROST_LANCE); }
  }

  public BuffImage IsCounterDisallow
  {
    get { return SearchBuff(Fix.COUNTER_DISALLOW); }
  }

  public BuffImage IsEverflowMind
  {
    get { return SearchBuff(Fix.EVERFLOW_MIND); }
  }

  public BuffImage IsSeventhPrinciple
  {
    get { return SearchBuff(Fix.SEVENTH_PRINCIPLE); }
  }

  public BuffImage IsWaterPresence
  {
    get { return SearchBuff(Fix.WATER_PRESENCE); }
  }

  public BuffImage IsValkyrieBlade
  {
    get { return SearchBuff(Fix.VALKYRIE_BLADE); }
  }

  public BuffImage IsValkyrieScar
  {
    get { return SearchBuff(Fix.BUFF_VALKYRIE_SCAR); }
  }

  public BuffImage IsTheDarkIntensity
  {
    get { return SearchBuff(Fix.THE_DARK_INTENSITY); }
  }

  public BuffImage IsFutureVision
  {
    get { return SearchBuff(Fix.FUTURE_VISION); }
  }

  public BuffImage IsStanceOfTheIai
  {
    get { return SearchBuff(Fix.STANCE_OF_THE_IAI); }
  }

  public BuffImage IsOneImmunity
  {
    get { return SearchBuff(Fix.ONE_IMMUNITY); }
  }

  public BuffImage IsStanceOfMuin
  {
    get { return SearchBuff(Fix.STANCE_OF_MUIN); }
  }

  public BuffImage IsEternalConcentration
  {
    get { return SearchBuff(Fix.ETERNAL_CONCENTRATION); }
  }

  public BuffImage IsFocusEye
  {
    get { return SearchBuff(Fix.BUFF_FOCUS_EYE); }
  }

  public BuffImage IsAbsoluteZero
  {
    get { return SearchBuff(Fix.ABSOLUTE_ZERO); }
  }

  // 魔法：基本耐性
  public BuffImage IsUpFire
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_FIRE); }
  }
  public BuffImage IsDownFire
  {
    get { return SearchBuff(Fix.EFFECT_POWERDOWN_FIRE); }
  }

  public BuffImage IsUpIce
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_ICE); }
  }
  public BuffImage IsDownIce
  {
    get { return SearchBuff(Fix.EFFECT_POWERDOWN_ICE); }
  }

  public BuffImage IsUpLight
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_LIGHT); }
  }
  public BuffImage IsDownLight
  {
    get { return SearchBuff(Fix.EFFECT_POWERDOWN_LIGHT); }
  }

  public BuffImage IsUpShadow
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_SHADOW); }
  }
  public BuffImage IsDownShadow
  {
    get { return SearchBuff(Fix.EFFECT_POWERDOWN_SHADOW); }
  }

  public BuffImage IsUpWind
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_WIND); }
  }
  public BuffImage IsDownWind
  {
    get { return SearchBuff(Fix.EFFECT_POWERDOWN_WIND); }
  }

  public BuffImage IsUpEarth
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_EARTH); }
  }
  public BuffImage IsDownEarth
  {
    get { return SearchBuff(Fix.EFFECT_POWERDOWN_EARTH); }
  }

  public BuffImage IsPhysicalAttackUp
  {
    get { return SearchBuff(Fix.BUFF_PA_UP); }
  }
  public BuffImage IsPhysicalAttackDown
  {
    get { return SearchBuff(Fix.BUFF_PA_DOWN); }
  }

  public BuffImage IsPhysicalDefenseUp
  {
    get { return SearchBuff(Fix.BUFF_PD_UP); }
  }
  public BuffImage IsPhysicalDefenseDown
  {
    get { return SearchBuff(Fix.BUFF_PD_DOWN); }
  }

  public BuffImage IsMagicAttackUp
  {
    get { return SearchBuff(Fix.BUFF_MA_UP); }
  }
  public BuffImage IsMagicAttackDown
  {
    get { return SearchBuff(Fix.BUFF_MA_DOWN); }
  }

  public BuffImage IsMagicDefenseUp
  {
    get { return SearchBuff(Fix.BUFF_MD_UP); }
  }
  public BuffImage IsMagicDefenseDown
  {
    get { return SearchBuff(Fix.BUFF_MD_DOWN); }
  }

  public BuffImage IsBattleSpeedUp
  {
    get { return SearchBuff(Fix.BUFF_BS_UP); }
  }
  public BuffImage IsBattleSpeedDown
  {
    get { return SearchBuff(Fix.BUFF_BS_DOWN); }
  }

  public BuffImage IsBattleReponseUp
  {
    get { return SearchBuff(Fix.BUFF_BR_UP); }
  }
  public BuffImage IsBattleResponseDown
  {
    get { return SearchBuff(Fix.BUFF_BR_DOWN); }
  }

  public BuffImage IsPotentialUp
  {
    get { return SearchBuff(Fix.BUFF_PO_UP); }
  }
  public BuffImage IsPotentialDown
  {
    get { return SearchBuff(Fix.BUFF_PO_DOWN); }
  }

  public BuffImage IsSyutyuDanzetsu
  {
    get { return SearchBuff(Fix.BUFF_SYUTYU_DANZETSU); }
  }

  // モンスター特有
  public BuffImage IsBlackSpore
  {
    get { return SearchBuff(Fix.BUFF_BLACK_SPORE); }
  }
  
  public BuffImage IsReflectionShade
  {
    get { return SearchBuff(Fix.COMMAND_REFLECTION_SHADE); }
  }

  public BuffImage IsIchimaiGuardwall
  {
    get { return SearchBuff(Fix.COMMAND_ICHIMAI_GUARDWALL); }
  }

  public BuffImage IsFaithSight
  {
    get { return SearchBuff(Fix.COMMAND_FAITH_SIGHT); }
  }

  public BuffImage IsLightThunderbolt
  {
    get { return SearchBuff(Fix.COMMAND_LIGHT_THUNDERBOLT); }
  }

  public void RemoveTargetBuff(string buff_name)
  {
    BuffImage buffImage = SearchBuff(buff_name);
    if (buffImage != null)
    {
      buffImage.RemoveBuff();
    }
  }

  /// <summary>
  /// ディスペル・マジックやピュア・ピュリファイケーション経由でBUFFを除去します。
  /// </summary>
  public void RemoveBuff(int num, Fix.BuffType buff_type)
  {
    if (this.objBuffPanel == null) { return; }

    // unity潜在バグの可能性。null合体演算子、厳密にはnull判定かどうかを行おうとした時、
    // missing exceptionが発生するので、null合体演算子はここでは使わない。
    //BuffImage[] buffList = this.objBuffPanel?.GetComponentsInChildren<BuffImage>() ?? null;
    BuffImage[] buffList = this.objBuffPanel.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    int detect = 0;
    for (int ii = 0; ii < buffList.Length; ii++)
    {
      // 有益なBUFFが見つかった場合、それを除去する。
      if (ActionCommand.GetBuffType(buffList[ii].BuffName) == buff_type)
      {
        buffList[ii].RemoveBuff();
        detect++;
      }

      // 指定された数だけ除去したら抜ける。
      if (detect >= num)
      {
        break;
      }
    }
  }

  public int GetPositiveBuff()
  {
    BuffImage[] buffList = this.objBuffPanel.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return 0; }

    int result = 0;
    for (int ii = 0; ii < buffList.Length; ii++)
    {
      if (ActionCommand.GetBuffType(buffList[ii].BuffName) == Fix.BuffType.Positive)
      {
        result++;
      }
    }
    return result;
  }

  public BuffImage[] GetNegativeBuffList()
  {
    BuffImage[] buffList = this.objBuffPanel.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return null; }

    int result = 0;
    for (int ii = 0; ii < buffList.Length; ii++)
    {
      if (ActionCommand.GetBuffType(buffList[ii].BuffName) == Fix.BuffType.Negative)
      {
        result++;
      }
    }
    return buffList;
  }

  /// <summary>
  /// 指定されたBUFFが存在するかどうかを確認します。
  /// </summary>
  private BuffImage SearchBuff(string buff_name)
  {
    if (this.objBuffPanel == null) { return null; }

    // unity潜在バグの可能性。null合体演算子、厳密にはnull判定かどうかを行おうとした時、
    // missing exceptionが発生するので、null合体演算子はここでは使わない。
    //BuffImage[] buffList = this.objBuffPanel?.GetComponentsInChildren<BuffImage>() ?? null;
    BuffImage[] buffList = this.objBuffPanel.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return null; }

    for (int ii = 0; ii < buffList.Length; ii++)
    {
      if (buffList[ii].BuffName == buff_name)
      {
        return buffList[ii];
      }
    }
    return null;
  }
  private BuffImage SearchBuff(string buff_name, string buff_name_jp)
  {
    if (this.objBuffPanel == null) { return null; }

    // unity潜在バグの可能性。null合体演算子、厳密にはnull判定かどうかを行おうとした時、
    // missing exceptionが発生するので、null合体演算子はここでは使わない。
    //BuffImage[] buffList = this.objBuffPanel?.GetComponentsInChildren<BuffImage>() ?? null;
    BuffImage[] buffList = this.objBuffPanel.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return null; }

    for (int ii = 0; ii < buffList.Length; ii++)
    {
      if (buffList[ii].BuffName == buff_name || buffList[ii].BuffName == buff_name_jp)
      {
        return buffList[ii];
      }
    }
    return null;
  }

  public bool IsAvailableCA(Fix.CommandAttribute CA)
  {
    if (_FirstCommandAttribute == CA ||
        _SecondCommandAttribute == CA ||
        _ThirdCommandAttribute == CA)
    {
      return true;
    }
    return false;
  }

  public List<string> GetActionCommandList()
  {
    // ここでは変換則は一切入れない。
    List<string> list = new List<string>();
    list.Add(this.ActionCommand1);
    list.Add(this.ActionCommand2);
    list.Add(this.ActionCommand3);
    list.Add(this.ActionCommand4);
    list.Add(this.ActionCommand5);
    list.Add(this.ActionCommand6);
    list.Add(this.ActionCommand7);
    list.Add(this.ActionCommand8);
    list.Add(this.ActionCommand9);
    return list;
  }

  public List<string> GetAvailableBasicAction()
  {
    List<string> list = new List<string>();
    list.Add(Fix.NORMAL_ATTACK);
    list.Add(Fix.MAGIC_ATTACK);
    list.Add(Fix.DEFENSE);
    return list;
  }

  public List<string> GetAvailableList()
  {
    // todo
    List<string> list = new List<string>();
    if (this.FireBall > 0) { list.Add(Fix.FIRE_BALL); }
    if (this.IceNeedle > 0) { list.Add(Fix.ICE_NEEDLE); }
    if (this.FreshHeal > 0) { list.Add(Fix.FRESH_HEAL); }
    if (this.ShadowBlast > 0) { list.Add(Fix.SHADOW_BLAST); }
    if (this.OracleCommand > 0) { list.Add(Fix.ORACLE_COMMAND); }
    if (this.EnergyBolt > 0) { list.Add(Fix.ENERGY_BOLT); }
    if (this.StraightSmash > 0) { list.Add(Fix.STRAIGHT_SMASH); }
    if (this.ShieldBash > 0) { list.Add(Fix.SHIELD_BASH); }
    if (this.LegStrike > 0) { list.Add(Fix.LEG_STRIKE); }
    if (this.HunterShot > 0) { list.Add(Fix.HUNTER_SHOT); }
    if (this.TrueSight > 0) { list.Add(Fix.TRUE_SIGHT); }
    if (this.DispelMagic > 0) { list.Add(Fix.DISPEL_MAGIC); }

    if (this.FlameBlade > 0) { list.Add(Fix.FLAME_BLADE); }
    if (this.PurePurification > 0) { list.Add(Fix.PURE_PURIFICATION); }
    if (this.DivineCircle > 0) { list.Add(Fix.DIVINE_CIRCLE); }
    if (this.BloodSign > 0) { list.Add(Fix.BLOOD_SIGN); }
    if (this.FortuneSpirit > 0) { list.Add(Fix.FORTUNE_SPIRIT); }
    if (this.FlashCounter > 0) { list.Add(Fix.FLASH_COUNTER); }
    if (this.StanceOfTheBlade > 0) { list.Add(Fix.STANCE_OF_THE_BLADE); }
    if (this.StanceOfTheGuard > 0) { list.Add(Fix.STANCE_OF_THE_GUARD); }
    if (this.SpeedStep > 0) { list.Add(Fix.SPEED_STEP); }
    if (this.MultipleShot > 0) { list.Add(Fix.MULTIPLE_SHOT); }
    if (this.LeylineSchema > 0) { list.Add(Fix.LEYLINE_SCHEMA); }
    if (this.SpiritualRest > 0) { list.Add(Fix.SPIRITUAL_REST); }

    if (this.MeteorBullet > 0) { list.Add(Fix.METEOR_BULLET); }
    if (this.BlueBullet > 0) { list.Add(Fix.BLUE_BULLET); }
    if (this.HolyBreath > 0) { list.Add(Fix.HOLY_BREATH); }
    if (this.BlackContract > 0) { list.Add(Fix.BLACK_CONTRACT); }
    if (this.WordOfPower > 0) { list.Add(Fix.WORD_OF_POWER); }
    if (this.SigilOfThePending > 0) { list.Add(Fix.SIGIL_OF_THE_PENDING); }
    if (this.DoubleSlash > 0) { list.Add(Fix.DOUBLE_SLASH); }
    if (this.ConcussiveHit > 0) { list.Add(Fix.CONCUSSIVE_HIT); }
    if (this.BoneCrush > 0) { list.Add(Fix.BONE_CRUSH); }
    if (this.EyeOfTheIsshin > 0) { list.Add(Fix.EYE_OF_THE_ISSHIN); }
    if (this.VoiceOfVigor > 0) { list.Add(Fix.VOICE_OF_VIGOR); }
    if (this.UnseenAid > 0) { list.Add(Fix.UNSEEN_AID); }

    if (this.VolcanicBlaze > 0) { list.Add(Fix.VOLCANIC_BLAZE); }
    if (this.FreezingCube > 0) { list.Add(Fix.FREEZING_CUBE); }
    if (this.AngelicEcho > 0) { list.Add(Fix.ANGELIC_ECHO); }
    if (this.CursedEvangile > 0) { list.Add(Fix.CURSED_EVANGILE); }
    if (this.GaleWind > 0) { list.Add(Fix.GALE_WIND); }
    if (this.PhantomOboro > 0) { list.Add(Fix.PHANTOM_OBORO); }
    if (this.IronBuster > 0) { list.Add(Fix.IRON_BUSTER); }
    if (this.DominationField > 0) { list.Add(Fix.DOMINATION_FIELD); }
    if (this.DeadlyDrive > 0) { list.Add(Fix.DEADLY_DRIVE); }
    if (this.PenetrationArrow > 0) { list.Add(Fix.PENETRATION_ARROW); }
    if (this.WillAwakening > 0) { list.Add(Fix.WILL_AWAKENING); }
    if (this.CircleOfSerenity > 0) { list.Add(Fix.CIRCLE_OF_SERENITY); }

    if (this.FlameStrike > 0) { list.Add(Fix.FLAME_STRIKE); }
    if (this.FrostLance > 0) { list.Add(Fix.FROST_LANCE); }
    if (this.ShiningHeal > 0) { list.Add(Fix.SHINING_HEAL); }
    if (this.CircleOfTheDespair > 0) { list.Add(Fix.CIRCLE_OF_THE_DESPAIR); }
    if (this.SeventhPrinciple > 0) { list.Add(Fix.SEVENTH_PRINCIPLE); }
    if (this.CounterDisallow > 0) { list.Add(Fix.COUNTER_DISALLOW); }
    if (this.RagingStorm > 0) { list.Add(Fix.RAGING_STORM); }
    if (this.PrecisionStrike > 0) { list.Add(Fix.PRECISION_STRIKE); }
    if (this.UnintentionalHit > 0) { list.Add(Fix.UNINTENTIONAL_HIT); }
    if (this.HardestParry > 0) { list.Add(Fix.HARDEST_PARRY); }
    if (this.EverflowMind > 0) { list.Add(Fix.EVERFLOW_MIND); }
    if (this.InnerInspiration > 0) { list.Add(Fix.INNER_INSPIRATION); }

    if (this.CircleOfTheIgnite > 0) { list.Add(Fix.CIRCLE_OF_THE_IGNITE); }
    if (this.WaterPresence > 0) { list.Add(Fix.WATER_PRESENCE); }
    if (this.ValkyrieBlade > 0) { list.Add(Fix.VALKYRIE_BLADE); }
    if (this.TheDarkIntensity > 0) { list.Add(Fix.THE_DARK_INTENSITY); }
    if (this.FutureVision > 0) { list.Add(Fix.FUTURE_VISION); }
    if (this.DetachmentFault > 0) { list.Add(Fix.DETACHMENT_FAULT); }
    if (this.StanceOfTheIai > 0) { list.Add(Fix.STANCE_OF_THE_IAI); }
    if (this.OneImmunity > 0) { list.Add(Fix.ONE_IMMUNITY); }
    if (this.StanceOfMuin > 0) { list.Add(Fix.STANCE_OF_MUIN); }
    if (this.EternalConcentration > 0) { list.Add(Fix.ETERNAL_CONCENTRATION); }
    if (this.SigilOfTheFaith > 0) { list.Add(Fix.SIGIL_OF_THE_FAITH); }
    if (this.ZeroImmunity > 0) { list.Add(Fix.ZERO_IMMUNITY); }

    if (this.LavaAnnihilation > 0) { list.Add(Fix.LAVA_ANNIHILATION); }
    if (this.AbsoluteZero > 0) { list.Add(Fix.ABSOLUTE_ZERO); }
    if (this.Resurrection > 0) { list.Add(Fix.RESURRECTION); }
    if (this.DeathScythe > 0) { list.Add(Fix.DEATH_SCYTHE); }
    if (this.Genesis > 0) { list.Add(Fix.GENESIS); }
    if (this.TimeSkip > 0) { list.Add(Fix.TIME_SKIP); }
    if (this.KineticSmash > 0) { list.Add(Fix.KINETIC_SMASH); }
    if (this.Catastrophe > 0) { list.Add(Fix.CATASTROPHE); }
    if (this.CarnageRush > 0) { list.Add(Fix.CARNAGE_RUSH); }
    if (this.PiercingArrow > 0) { list.Add(Fix.PIERCING_ARROW); }
    if (this.StanceOfTheKokoroe > 0) { list.Add(Fix.STANCE_OF_THE_KOKOROE); }
    if (this.TranscendenceReached > 0) { list.Add(Fix.TRANSCENDENCE_REACHED); }

    // other
    if (this.AirCutter > 0) { list.Add(Fix.AIR_CUTTER); }
    if (this.RockSlam > 0) { list.Add(Fix.ROCK_SLAM); }
    if (this.VenomSlash > 0) { list.Add(Fix.VENOM_SLASH); }
    if (this.AuraBurn > 0) { list.Add(Fix.AURA_BURN); }
    if (this.HeartOfLife > 0) { list.Add(Fix.HEART_OF_LIFE); }
    if (this.DarkAura > 0) { list.Add(Fix.DARK_AURA); }
    if (this.CounterAttack > 0) { list.Add(Fix.COUNTER_ATTACK); }
    if (this.StormArmor > 0) { list.Add(Fix.STORM_ARMOR); }
    if (this.SoldWall > 0) { list.Add(Fix.SOLID_WALL); }
    if (this.InvisibleBind > 0) { list.Add(Fix.INVISIBLE_BIND); }
    if (this.IdeologyOfSophistication > 0) { list.Add(Fix.IDEOLOGY_OF_SOPHISTICATION); }
    if (this.SkyShield > 0) { list.Add(Fix.SKY_SHIELD); }
    if (this.StanceOfTheShade > 0) { list.Add(Fix.STANCE_OF_THE_SHADE); }

    return list;
  }

  public void LevelUpEssenceTree(int number, ref string new_command)
  {
    if (number == 1)
    {
      if (this.FullName == Fix.NAME_EIN_WOLENCE)
      {
        this.AvailableWarrior = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.StraightSmash <= 0) { this.StraightSmash = 1; new_command = Fix.STRAIGHT_SMASH_JP; }
        }
        if (this.Level >= 4)
        {
          if (this.StanceOfTheBlade <= 0) { this.StanceOfTheBlade = 1; new_command = Fix.STANCE_OF_THE_BLADE_JP; }
        }
        if (this.Level >= 8)
        {
          if (this.DoubleSlash <= 0) { this.DoubleSlash = 1; new_command = Fix.DOUBLE_SLASH_JP; }
        }
        if (this.Level >= 22)
        {
          if (this.IronBuster <= 0) { this.IronBuster = 1; new_command = Fix.IRON_BUSTER_JP; }
        }
        if (this.Level >= 32)
        {
          if (this.RagingStorm <= 0) { this.RagingStorm = 1; new_command = Fix.RAGING_STORM_JP; }
        }
        if (this.Level >= 42)
        {
          if (this.StanceOfTheIai <= 0) { this.StanceOfTheIai = 1; new_command = Fix.STANCE_OF_THE_IAI_JP; }
        }
        if (this.Level >= 52)
        {
          if (this.KineticSmash <= 0) { this.KineticSmash = 1; new_command = Fix.KINETIC_SMASH_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_LANA_AMIRIA)
      {
        this.AvailableIce = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.IceNeedle <= 0) { this.IceNeedle = 1; new_command = Fix.ICE_NEEDLE_JP; }
        }
        if (this.Level >= 4)
        {
          if (this.PurePurification <= 0) { this.PurePurification = 1; new_command = Fix.PURE_PURIFICATION_JP; }
        }
        if (this.Level >= 8)
        {
          if (this.BlueBullet <= 0) { this.BlueBullet = 1; new_command = Fix.BLUE_BULLET_JP; }
        }
        if (this.Level >= 22)
        {
          if (this.FreezingCube <= 0) { this.FreezingCube = 1; new_command = Fix.FREEZING_CUBE_JP; }
        }
        if (this.Level >= 32)
        {
          if (this.FrostLance <= 0) { this.FrostLance = 1; new_command = Fix.FROST_LANCE_JP; }
        }
        if (this.Level >= 42)
        {
          if (this.WaterPresence <= 0) { this.WaterPresence = 1; new_command = Fix.WATER_PRESENCE_JP; }
        }
        if (this.Level >= 52)
        {
          if (this.AbsoluteZero <= 0) { this.AbsoluteZero = 1; new_command = Fix.ABSOLUTE_ZERO_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_EONE_FULNEA)
      {
        this.AvailableArchery = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.HunterShot <= 0) { this.HunterShot = 1; new_command = Fix.HUNTER_SHOT_JP; }
        }
        if (this.Level >= 4)
        {
          if (this.MultipleShot <= 0) { this.MultipleShot = 1; new_command = Fix.MULTIPLE_SHOT_JP; }
        }
        if (this.Level >= 8)
        {
          if (this.EyeOfTheIsshin <= 0) { this.EyeOfTheIsshin = 1; new_command = Fix.EYE_OF_THE_ISSHIN_JP; }
        }
        if (this.Level >= 22)
        {
          if (this.PenetrationArrow <= 0) { this.PenetrationArrow = 1; new_command = Fix.PENETRATION_ARROW_JP; }
        }
        if (this.Level >= 32)
        {
          if (this.PrecisionStrike <= 0) { this.PrecisionStrike = 1; new_command = Fix.PRECISION_STRIKE_JP; }
        }
        if (this.Level >= 42)
        {
          if (this.EternalConcentration <= 0) { this.EternalConcentration = 1; new_command = Fix.ETERNAL_CONCENTRATION_JP; }
        }
        if (this.Level >= 52)
        {
          if (this.PiercingArrow <= 0) { this.PiercingArrow = 1; new_command = Fix.PIERCING_ARROW_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_BILLY_RAKI)
      {
        this.AvailableMartialArts = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.LegStrike <= 0) { this.LegStrike = 1; new_command = Fix.LEG_STRIKE_JP; }
        }
        if (this.Level >= 4)
        {
          if (this.SpeedStep <= 0) { this.SpeedStep = 1; new_command = Fix.SPEED_STEP_JP; }
        }
        if (this.Level >= 8)
        {
          if (this.BoneCrush <= 0) { this.BoneCrush = 1; new_command = Fix.BONE_CRUSH_JP; }
        }
        if (this.Level >= 22)
        {
          if (this.DeadlyDrive <= 0) { this.DeadlyDrive = 1; new_command = Fix.DEADLY_DRIVE_JP; }
        }
        if (this.Level >= 32)
        {
          if (this.UnintentionalHit <= 0) { this.UnintentionalHit = 1; new_command = Fix.UNINTENTIONAL_HIT_JP; }
        }
        if (this.Level >= 42)
        {
          if (this.StanceOfMuin <= 0) { this.StanceOfMuin = 1; new_command = Fix.STANCE_OF_MUIN_JP; }
        }
        if (this.Level >= 52)
        {
          if (this.CarnageRush <= 0) { this.CarnageRush = 1; new_command = Fix.CARNAGE_RUSH_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
      {
        this.AvailableVoidChant = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.EnergyBolt <= 0) { this.EnergyBolt = 1; new_command = Fix.ENERGY_BOLT_JP; }
        }
        if (this.Level >= 4)
        {
          if (this.FlashCounter <= 0) { this.FlashCounter = 1; new_command = Fix.FLASH_COUNTER_JP; }
        }
        if (this.Level >= 8)
        {
          if (this.SigilOfThePending <= 0) { this.SigilOfThePending = 1; new_command = Fix.SIGIL_OF_THE_PENDING_JP; }
        }
        if (this.Level >= 22)
        {
          if (this.PhantomOboro <= 0) { this.PhantomOboro = 1; new_command = Fix.PHANTOM_OBORO_JP; }
        }
        if (this.Level >= 32)
        {
          if (this.CounterDisallow <= 0) { this.CounterDisallow = 1; new_command = Fix.COUNTER_DISALLOW_JP; }
        }
        if (this.Level >= 42)
        {
          if (this.DetachmentFault <= 0) { this.DetachmentFault = 1; new_command = Fix.DETACHMENT_FAULT_JP; }
        }
        if (this.Level >= 52)
        {
          if (this.TimeSkip <= 0) { this.TimeSkip = 1; new_command = Fix.TIME_SKIP_JP; }
        }
      }
    }
    else if (number == 2)
    {
      if (this.FullName == Fix.NAME_EIN_WOLENCE)
      {
        this.AvailableFire = true;
        if (this.Level >= 2) // 第２属性は初期から有効のため、適切なレベル設定を設けておく。
        {
          if (this.FireBall <= 0) { this.FireBall = 1; new_command = Fix.FIRE_BALL_JP; }
        }
        if (this.Level >= 6)
        {
          if (this.FlameBlade <= 0) { this.FlameBlade = 1; new_command = Fix.FLAME_BLADE_JP; }
        }
        if (this.Level >= 10)
        {
          if (this.MeteorBullet <= 0) { this.MeteorBullet = 1; new_command = Fix.METEOR_BULLET_JP; }
        }
        if (this.Level >= 25)
        {
          if (this.VolcanicBlaze <= 0) { this.VolcanicBlaze = 1; new_command = Fix.VOLCANIC_BLAZE_JP; }
        }
        if (this.Level >= 35)
        {
          if (this.FlameStrike <= 0) { this.FlameStrike = 1; new_command = Fix.FLAME_STRIKE_JP; }
        }
        if (this.Level >= 45)
        {
          if (this.CircleOfTheIgnite <= 0) { this.CircleOfTheIgnite = 1; new_command = Fix.CIRCLE_OF_THE_IGNITE_JP; }
        }
        if (this.Level >= 55)
        {
          if (this.LavaAnnihilation <= 0) { this.LavaAnnihilation = 1; new_command = Fix.LAVA_ANNIHILATION_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_LANA_AMIRIA)
      {
        this.AvailableMartialArts = true;
        if (this.Level >= 2) // 第２属性は初期から有効のため、適切なレベル設定を設けておく。
        {
          if (this.LegStrike <= 0) { this.LegStrike = 1; new_command = Fix.LEG_STRIKE_JP; }
        }
        if (this.Level >= 6)
        {
          if (this.SpeedStep <= 0) { this.SpeedStep = 1; new_command = Fix.SPEED_STEP_JP; }
        }
        if (this.Level >= 10)
        {
          if (this.BoneCrush <= 0) { this.BoneCrush = 1; new_command = Fix.BONE_CRUSH_JP; }
        }
        if (this.Level >= 25)
        {
          if (this.DeadlyDrive <= 0) { this.DeadlyDrive = 1; new_command = Fix.DEADLY_DRIVE_JP; }
        }
        if (this.Level >= 35)
        {
          if (this.UnintentionalHit <= 0) { this.UnintentionalHit = 1; new_command = Fix.UNINTENTIONAL_HIT_JP; }
        }
        if (this.Level >= 45)
        {
          if (this.StanceOfMuin <= 0) { this.StanceOfMuin = 1; new_command = Fix.STANCE_OF_MUIN_JP; }
        }
        if (this.Level >= 55)
        {
          if (this.CarnageRush <= 0) { this.CarnageRush = 1; new_command = Fix.CARNAGE_RUSH_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_EONE_FULNEA)
      {
        this.AvailableHolyLight = true;
        if (this.Level >= 2) // 第２属性は初期から有効のため、適切なレベル設定を設けておく。
        {
          if (this.FreshHeal <= 0) { this.FreshHeal = 1; new_command = Fix.FRESH_HEAL_JP; }
        }
        if (this.Level >= 6)
        {
          if (this.DivineCircle <= 0) { this.DivineCircle = 1; new_command = Fix.DIVINE_CIRCLE_JP; }
        }
        if (this.Level >= 10)
        {
          if (this.HolyBreath <= 0) { this.HolyBreath = 1; new_command = Fix.HOLY_BREATH_JP; }
        }
        if (this.Level >= 25)
        {
          if (this.AngelicEcho <= 0) { this.AngelicEcho = 1; new_command = Fix.ANGELIC_ECHO_JP; }
        }
        if (this.Level >= 35)
        {
          if (this.ShiningHeal <= 0) { this.ShiningHeal = 1; new_command = Fix.SHINING_HEAL_JP; }
        }
        if (this.Level >= 45)
        {
          if (this.ValkyrieBlade <= 0) { this.ValkyrieBlade = 1; new_command = Fix.VALKYRIE_BLADE_JP; }
        }
        if (this.Level >= 55)
        {
          if (this.Resurrection <= 0) { this.Resurrection = 1; new_command = Fix.RESURRECTION_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_BILLY_RAKI)
      {
        this.AvailableFire = true;
        if (this.Level >= 2) // 第２属性は初期から有効のため、適切なレベル設定を設けておく。
        {
          if (this.FireBall <= 0) { this.FireBall = 1; new_command = Fix.FIRE_BALL_JP; }
        }
        if (this.Level >= 6)
        {
          if (this.FlameBlade <= 0) { this.FlameBlade = 1; new_command = Fix.FLAME_BLADE_JP; }
        }
        if (this.Level >= 10)
        {
          if (this.MeteorBullet <= 0) { this.MeteorBullet = 1; new_command = Fix.METEOR_BULLET_JP; }
        }
        if (this.Level >= 25)
        {
          if (this.VolcanicBlaze <= 0) { this.VolcanicBlaze = 1; new_command = Fix.VOLCANIC_BLAZE_JP; }
        }
        if (this.Level >= 35)
        {
          if (this.FlameStrike <= 0) { this.FlameStrike = 1; new_command = Fix.FLAME_STRIKE_JP; }
        }
        if (this.Level >= 45)
        {
          if (this.CircleOfTheIgnite <= 0) { this.CircleOfTheIgnite = 1; new_command = Fix.CIRCLE_OF_THE_IGNITE_JP; }
        }
        if (this.Level >= 55)
        {
          if (this.LavaAnnihilation <= 0) { this.LavaAnnihilation = 1; new_command = Fix.LAVA_ANNIHILATION_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
      {
        this.AvailableTruth = true;
        if (this.Level >= 2) // 第２属性は初期から有効のため、適切なレベル設定を設けておく。
        {
          if (this.TrueSight <= 0) { this.TrueSight = 1; new_command = Fix.TRUE_SIGHT_JP; }
        }
        if (this.Level >= 6)
        {
          if (this.LeylineSchema <= 0) { this.LeylineSchema = 1; new_command = Fix.LEYLINE_SCHEMA_JP; }
        }
        if (this.Level >= 10)
        {
          if (this.VoiceOfVigor <= 0) { this.VoiceOfVigor = 1; new_command = Fix.VOICE_OF_VIGOR_JP; }
        }
        if (this.Level >= 25)
        {
          if (this.WillAwakening <= 0) { this.WillAwakening = 1; new_command = Fix.WILL_AWAKENING_JP; }
        }
        if (this.Level >= 35)
        {
          if (this.EverflowMind <= 0) { this.EverflowMind = 1; new_command = Fix.EVERFLOW_MIND_JP; }
        }
        if (this.Level >= 45)
        {
          if (this.SigilOfTheFaith <= 0) { this.SigilOfTheFaith = 1; new_command = Fix.SIGIL_OF_THE_FAITH_JP; }
        }
        if (this.Level >= 55)
        {
          if (this.StanceOfTheKokoroe <= 0) { this.StanceOfTheKokoroe = 1; new_command = Fix.STANCE_OF_THE_KOKOROE_JP; }
        }
      }
    }
    else if (number == 3)
    {
      if (this.FullName == Fix.NAME_EIN_WOLENCE)
      {
        this.AvailableGuardian = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.ShieldBash <= 0) { this.ShieldBash = 1; new_command = Fix.SHIELD_BASH_JP; }
        }
        if (this.Level >= 15)
        {
          if (this.StanceOfTheGuard <= 0) { this.StanceOfTheGuard = 1; new_command = Fix.STANCE_OF_THE_GUARD_JP; }
        }
        if (this.Level >= 18)
        {
          if (this.ConcussiveHit <= 0) { this.ConcussiveHit = 1; new_command = Fix.CONCUSSIVE_HIT_JP; }
        }
        if (this.Level >= 28)
        {
          if (this.DominationField <= 0) { this.DominationField = 1; new_command = Fix.DOMINATION_FIELD_JP; }
        }
        if (this.Level >= 38)
        {
          if (this.HardestParry <= 0) { this.HardestParry = 1; new_command = Fix.HARDEST_PARRY_JP; }
        }
        if (this.Level >= 48)
        {
          if (this.OneImmunity <= 0) { this.OneImmunity = 1; new_command = Fix.ONE_IMMUNITY_JP; }
        }
        if (this.Level >= 58)
        {
          if (this.Catastrophe <= 0) { this.Catastrophe = 1; new_command = Fix.CATASTROPHE_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_LANA_AMIRIA)
      {
        this.AvailableDarkMagic = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.ShadowBlast <= 0) { this.ShadowBlast = 1; new_command = Fix.SHADOW_BLAST_JP; }
        }
        if (this.Level >= 15)
        {
          if (this.BloodSign <= 0) { this.BloodSign = 1; new_command = Fix.BLOOD_SIGN_JP; }
        }
        if (this.Level >= 18)
        {
          if (this.BlackContract <= 0) { this.BlackContract = 1; new_command = Fix.BLACK_CONTRACT_JP; }
        }
        if (this.Level >= 28)
        {
          if (this.CursedEvangile <= 0) { this.CursedEvangile = 1; new_command = Fix.CURSED_EVANGILE_JP; }
        }
        if (this.Level >= 38)
        {
          if (this.CircleOfTheDespair <= 0) { this.CircleOfTheDespair = 1; new_command = Fix.CIRCLE_OF_THE_DESPAIR_JP; }
        }
        if (this.Level >= 48)
        {
          if (this.TheDarkIntensity <= 0) { this.TheDarkIntensity = 1; new_command = Fix.THE_DARK_INTENSITY_JP; }
        }
        if (this.Level >= 58)
        {
          if (this.DeathScythe <= 0) { this.DeathScythe = 1; new_command = Fix.DEATH_SCYTHE_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_EONE_FULNEA)
      {
        this.AvailableMindfulness = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.DispelMagic <= 0) { this.DispelMagic = 1; new_command = Fix.DISPEL_MAGIC_JP; }
        }
        if (this.Level >= 15)
        {
          if (this.SpiritualRest <= 0) { this.SpiritualRest = 1; new_command = Fix.SPIRITUAL_REST_JP; }
        }
        if (this.Level >= 18)
        {
          if (this.UnseenAid <= 0) { this.UnseenAid = 1; new_command = Fix.UNSEEN_AID_JP; }
        }
        if (this.Level >= 28)
        {
          if (this.CircleOfSerenity <= 0) { this.CircleOfSerenity = 1; new_command = Fix.CIRCLE_OF_SERENITY_JP; }
        }
        if (this.Level >= 38)
        {
          if (this.InnerInspiration <= 0) { this.InnerInspiration = 1; new_command = Fix.INNER_INSPIRATION_JP; }
        }
        if (this.Level >= 48)
        {
          if (this.ZeroImmunity <= 0) { this.ZeroImmunity = 1; new_command = Fix.ZERO_IMMUNITY_JP; }
        }
        if (this.Level >= 58)
        {
          if (this.TranscendenceReached <= 0) { this.TranscendenceReached = 1; new_command = Fix.TRANSCENDENCE_REACHED_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_BILLY_RAKI)
      {
        this.AvailableTruth = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.TrueSight <= 0) { this.TrueSight = 1; new_command = Fix.TRUE_SIGHT_JP; }
        }
        if (this.Level >= 15)
        {
          if (this.LeylineSchema <= 0) { this.LeylineSchema = 1; new_command = Fix.LEYLINE_SCHEMA; }
        }
        if (this.Level >= 18)
        {
          if (this.VoiceOfVigor <= 0) { this.VoiceOfVigor = 1; new_command = Fix.VOICE_OF_VIGOR_JP; }
        }
        if (this.Level >= 28)
        {
          if (this.WillAwakening <= 0) { this.WillAwakening = 1; new_command = Fix.WILL_AWAKENING_JP; }
        }
        if (this.Level >= 38)
        {
          if (this.EverflowMind <= 0) { this.EverflowMind = 1; new_command = Fix.EVERFLOW_MIND_JP; }
        }
        if (this.Level >= 48)
        {
          if (this.SigilOfTheFaith <= 0) { this.SigilOfTheFaith = 1; new_command = Fix.SIGIL_OF_THE_FAITH_JP; }
        }
        if (this.Level >= 58)
        {
          if (this.StanceOfTheKokoroe <= 0) { this.StanceOfTheKokoroe = 1; new_command = Fix.STANCE_OF_THE_KOKOROE_JP; }
        }
      }
      else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
      {
        this.AvailableForce = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.OracleCommand <= 0) { this.OracleCommand = 1; new_command = Fix.ORACLE_COMMAND_JP; }
        }
        if (this.Level >= 15)
        {
          if (this.FortuneSpirit <= 0) { this.FortuneSpirit = 1; new_command = Fix.FORTUNE_SPIRIT_JP; }
        }
        if (this.Level >= 18)
        {
          if (this.WordOfPower <= 0) { this.WordOfPower = 1; new_command = Fix.WORD_OF_POWER_JP; }
        }
        if (this.Level >= 28)
        {
          if (this.GaleWind <= 0) { this.GaleWind = 1; new_command = Fix.GALE_WIND_JP; }
        }
        if (this.Level >= 38)
        {
          if (this.SeventhPrinciple <= 0) { this.SeventhPrinciple = 1; new_command = Fix.SEVENTH_PRINCIPLE_JP; }
        }
        if (this.Level >= 48)
        {
          if (this.FutureVision <= 0) { this.FutureVision = 1; new_command = Fix.FUTURE_VISION_JP; }
        }
        if (this.Level >= 58)
        {
          if (this.Genesis <= 0) { this.Genesis = 1; new_command = Fix.GENESIS_JP; }
        }
      }
    }
    else if (number == 4)
    {
      if (this.FullName == Fix.NAME_EIN_WOLENCE)
      {
        this.AvailableHolyLight = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.FreshHeal <= 0) { this.FreshHeal = 1; new_command = Fix.FRESH_HEAL_JP; }
        }
        // 属性４は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_LANA_AMIRIA)
      {
        this.AvailableMindfulness = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.DispelMagic <= 0) { this.DispelMagic = 1; new_command = Fix.DISPEL_MAGIC_JP; }
        }
        // 属性４は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_EONE_FULNEA)
      {
        this.AvailableVoidChant = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.EnergyBolt <= 0) { this.EnergyBolt = 1; new_command = Fix.ENERGY_BOLT_JP; }
        }
        // 属性４は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_BILLY_RAKI)
      {
        this.AvailableWarrior = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.StraightSmash <= 0) { this.StraightSmash = 1; new_command = Fix.STRAIGHT_SMASH_JP; }
        }
        // 属性４は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
      {
        this.AvailableHolyLight = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.FreshHeal <= 0) { this.FreshHeal = 1; new_command = Fix.FRESH_HEAL_JP; }
        }
        // 属性４は１つ目以外は手動習得のため、これ以降追加無し
      }
    }
    else if (number == 5)
    {
      if (this.FullName == Fix.NAME_EIN_WOLENCE)
      {
        this.AvailableForce = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.OracleCommand <= 0) { this.OracleCommand = 1; new_command = Fix.ORACLE_COMMAND_JP; }
        }
        // 属性５は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_LANA_AMIRIA)
      {
        this.AvailableVoidChant = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.EnergyBolt <= 0) { this.EnergyBolt = 1; new_command = Fix.ENERGY_BOLT_JP; }
        }
        // 属性５は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_EONE_FULNEA)
      {
        this.AvailableIce = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.IceNeedle <= 0) { this.IceNeedle = 1; new_command = Fix.ICE_NEEDLE_JP; }
        }
        // 属性５は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_BILLY_RAKI)
      {
        this.AvailableDarkMagic = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.ShadowBlast <= 0) { this.ShadowBlast = 1; new_command = Fix.SHADOW_BLAST_JP; }
        }
        // 属性５は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
      {
        this.AvailableArchery = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.HunterShot <= 0) { this.HunterShot = 1; new_command = Fix.HUNTER_SHOT_JP; }
        }
        // 属性５は１つ目以外は手動習得のため、これ以降追加無し
      }
    }
    else if (number == 6)
    {
      if (this.FullName == Fix.NAME_EIN_WOLENCE)
      {
        this.AvailableTruth = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.TrueSight <= 0) { this.TrueSight = 1; new_command = Fix.TRUE_SIGHT_JP; }
        }
        // 属性６は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_LANA_AMIRIA)
      {
        this.AvailableFire = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.FireBall <= 0) { this.FireBall = 1; new_command = Fix.FIRE_BALL_JP; }
        }
        // 属性６は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_EONE_FULNEA)
      {
        this.AvailableDarkMagic = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.ShadowBlast <= 0) { this.ShadowBlast = 1; new_command = Fix.SHADOW_BLAST_JP; }
        }
        // 属性６は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_BILLY_RAKI)
      {
        this.AvailableMindfulness = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.DispelMagic <= 0) { this.DispelMagic = 1; new_command = Fix.DISPEL_MAGIC_JP; }
        }
        // 属性６は１つ目以外は手動習得のため、これ以降追加無し
      }
      else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
      {
        this.AvailableIce = true;
        if (this.Level >= 1) // 一つ目は無条件
        {
          if (this.IceNeedle <= 0) { this.IceNeedle = 1; new_command = Fix.ICE_NEEDLE_JP; }
        }
        // 属性６は１つ目以外は手動習得のため、これ以降追加無し
      }
    }
    else if (number == 7)
    {
      //  if (this.Level == 999)
      //  {
      //    // this.Archetype_Ein1++; // todo そのパラメタはないが、パラメタを用意するのか決めないといけない。
      //    ApplyNewCommand(Fix.ARCHETYPE_EIN_1);
      //    new_command = Fix.ARCHETYPE_EIN_1;
      //  }

      //  if (this.Level == 999)
      //  {
      //    // this.Archetype_Lana1++; // todo そのパラメタはないが、パラメタを用意するのか決めないといけない。
      //    ApplyNewCommand(Fix.ARCHETYPE_LANA_1);
      //    new_command = Fix.ARCHETYPE_LANA_1;
      //  }

      //  if (this.Level == 999)
      //  {
      //    // this.Archetype_Eone1++; // todo そのパラメタはないが、パラメタを用意するのか決めないといけない。
      //    ApplyNewCommand(Fix.ARCHETYPE_EONE_1);
      //    new_command = Fix.ARCHETYPE_EONE_1;
      //  }

      //  if (this.Level == 999)
      //  {
      //    // this.Archetype_BILLY1++; // todo そのパラメタはないが、パラメタを用意するのか決めないといけない。
      //    ApplyNewCommand(Fix.ARCHETYPE_BILLY_1);
      //    new_command = Fix.ARCHETYPE_BILLY_1;
      //  }

      //  if (this.Level == 999)
      //  {
      //    // this.Archetype_ADEL1++; // todo そのパラメタはないが、パラメタを用意するのか決めないといけない。
      //    ApplyNewCommand(Fix.ARCHETYPE_ADEL_1);
      //    new_command = Fix.ARCHETYPE_ADEL_1;
      //  }
    }
  }

  public List<string> GetEssenceTreeTitleList(int attr, int type)
  {
    List<string> list = new List<string>();
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (attr == 0)
      {
        if (type == 0)
        {
          list.Add(Fix.STRAIGHT_SMASH_JP + "強化");
          list.Add(Fix.STANCE_OF_THE_BLADE_JP + "強化");
          list.Add(Fix.DOUBLE_SLASH_JP + "強化");
          list.Add(Fix.IRON_BUSTER_JP + "強化");
          list.Add(Fix.RAGING_STORM_JP + "強化");
          list.Add(Fix.STANCE_OF_THE_IAI_JP + "強化");
          list.Add(Fix.KINETIC_SMASH_JP + "強化");
        }
        else if (type == 1)
        {
          list.Add(Fix.TRUE_SIGHT_JP + "強化");
          list.Add(Fix.LEYLINE_SCHEMA_JP + "強化");
          list.Add(Fix.WORD_OF_POWER_JP + "強化");
          list.Add(Fix.WILL_AWAKENING_JP + "強化");
          list.Add(Fix.MIND_FORCE_JP + "強化");
          list.Add(Fix.SIGIL_OF_THE_FAITH_JP + "強化");
          list.Add(Fix.STANCE_OF_THE_KOKOROE_JP + "強化");
        }
        else if (type == 2)
        {
          list.Add(Fix.SHIELD_BASH_JP + "強化");
          list.Add(Fix.STANCE_OF_THE_GUARD_JP + "強化");
          list.Add(Fix.CONCUSSIVE_HIT_JP + "強化");
          list.Add(Fix.DOMINATION_FIELD_JP + "強化");
          list.Add(Fix.HARDEST_PARRY_JP + "強化");
          list.Add(Fix.WILD_SWING_JP + "強化");
          list.Add(Fix.ONE_IMMUNITY_JP + "強化");
        }
      }
      else if (attr == 1)
      {
        if (type == 0)
        {
          list.Add(Fix.SWORD_TRAINING);
        }
        else if (type == 1)
        {
          list.Add(Fix.LANCE_TRAINING);
        }
        else if (type == 2)
        {
          list.Add(Fix.SHIELD_TRAINING);
        }
      }
      else if (attr == 2)
      {
        if (type == 0)
        {
          list.Add(Fix.STYLE_GLADIATOR);
        }
        else if (type == 1)
        {
          list.Add(Fix.STYLE_DEFENDER);
        }
        else if (type == 2)
        {
          list.Add(Fix.STYLE_BRAVE_SEEKER);
        }
      }
      else if (attr == 3)
      {
        if (type == 0)
        {
          list.Add(Fix.GIFT_OF_TWIN);
        }
        else if (type == 1)
        {
          list.Add(Fix.WAY_OF_POTENTIAL);
        }
        else if (type == 2)
        {
          list.Add(Fix.TIME_EXPANSION);
        }
      }
    }
    else if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (attr == 0)
      {
        if (type == 0)
        {
          list.Add(Fix.ICE_NEEDLE_JP + "強化");
          list.Add(Fix.PURE_PURIFICATION_JP + "強化");
          list.Add(Fix.BLUE_BULLET_JP + "強化");
          list.Add(Fix.FREEZING_CUBE_JP + "強化");
          list.Add(Fix.FROST_LANCE_JP + "強化");
          list.Add(Fix.WATER_PRESENCE_JP + "強化");
          list.Add(Fix.ABSOLUTE_ZERO_JP + "強化");
        }
        else if (type == 1)
        {
          list.Add(Fix.SHADOW_BLAST_JP + "強化");
          list.Add(Fix.BLOOD_SIGN_JP + "強化");
          list.Add(Fix.BLACK_CONTRACT_JP + "強化");
          list.Add(Fix.CURSED_EVANGILE_JP + "強化");
          list.Add(Fix.CIRCLE_OF_THE_DESPAIR_JP + "強化");
          list.Add(Fix.THE_DARK_INTENSITY_JP + "強化");
          list.Add(Fix.DEATH_SCYTHE_JP + "強化");
        }
        else if (type == 2)
        {
          list.Add(Fix.DISPEL_MAGIC_JP + "強化");
          list.Add(Fix.FLASH_COUNTER_JP + "強化");
          list.Add(Fix.MUTE_IMPULSE_JP + "強化");
          list.Add(Fix.DETACHMENT_FAULT_JP + "強化");
          list.Add(Fix.OATH_OF_AEGIS_JP + "強化");
          list.Add(Fix.FUTURE_VISION_JP + "強化");
          list.Add(Fix.ESSENCE_OVERFLOW_JP + "強化");
        }
      }
      else if (attr == 1)
      {
        if (type == 0)
        {
          list.Add(Fix.ROD_TRAINING);
        }
        else if (type == 1)
        {
          list.Add(Fix.BOOK_TRAINING);
        }
        else if (type == 2)
        {
          list.Add(Fix.CLAW_TRAINING);
        }
      }
      else if (attr == 2)
      {
        if (type == 0)
        {
          list.Add(Fix.STYLE_SWORD_DANCER);
        }
        else if (type == 1)
        {
          list.Add(Fix.STYLE_ELEMENTAL_WIZARD);
        }
        else if (type == 2)
        {
          list.Add(Fix.STYLE_MYSTIC_ENHANCER);
        }
      }
      else if (attr == 3)
      {
        if (type == 0)
        {
          list.Add(Fix.BREATHING_DANCE);
        }
        else if (type == 1)
        {
          list.Add(Fix.MAGIC_SPELL_STANCE);
        }
        else if (type == 2)
        {
          list.Add(""); // todo
        }
      }
    }
    else if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (attr == 0)
      {
        if (type == 0)
        {
          list.Add(Fix.FRESH_HEAL_JP + "強化");
          list.Add(Fix.DIVINE_CIRCLE_JP + "強化");
          list.Add(Fix.HOLY_BREATH_JP + "強化");
          list.Add(Fix.ANGELIC_ECHO_JP + "強化");
          list.Add(Fix.SHINING_HEAL_JP + "強化");
          list.Add(Fix.VALKYRIE_BLADE_JP + "強化");
          list.Add(Fix.RESURRECTION_JP + "強化");
        }
        else if (type == 1)
        {
          list.Add(Fix.HUNTER_SHOT_JP + "強化");
          list.Add(Fix.MULTIPLE_SHOT_JP + "強化");
          list.Add(Fix.EYE_OF_THE_ISSHIN_JP + "強化");
          list.Add(Fix.PENETRATION_ARROW_JP + "強化");
          list.Add(Fix.PRECISION_STRIKE_JP + "強化");
          list.Add(Fix.ETERNAL_CONCENTRATION_JP + "強化");
          list.Add(Fix.PIERCING_ARROW_JP + "強化");
        }
        else if (type == 2)
        {
          list.Add(Fix.AURA_OF_POWER_JP + "強化");
          list.Add(Fix.SKY_SHIELD_JP + "強化");
          list.Add(Fix.AETHER_DRIVE_JP + "強化");
          list.Add(Fix.CIRCLE_OF_SERENITY_JP + "強化");
          list.Add(Fix.REVOLUTION_AURA_JP + "強化");
          list.Add(Fix.BRILLIANT_FORM_JP + "強化");
          list.Add(Fix.AUSTERITY_MATRIX_JP + "強化");
        }
      }
      else if (attr == 1)
      {
        if (type == 0)
        {
          list.Add(Fix.BOW_TRAINING);
        }
        else if (type == 1)
        {
          list.Add(Fix.ORB_TRAINING);
        }
        else if (type == 2)
        {
          list.Add(Fix.BOOK_TRAINING);
        }
      }
      else if (attr == 2)
      {
        if (type == 0)
        {
          list.Add(Fix.STYLE_AERIAL_HUNTER);
        }
        else if (type == 1)
        {
          list.Add(Fix.STYLE_HIGH_PRIEST);
        }
        else if (type == 2)
        {
          list.Add(Fix.STYLE_ROYAL_KNIGHT);
        }
      }
      else if (attr == 3)
      {
        if (type == 0)
        {
          list.Add(Fix.MIKIRI_SENSE);
        }
        else if (type == 1)
        {
          list.Add(""); // todo
        }
        else if (type == 2)
        {
          list.Add(""); // todo
        }
      }
    }
    else if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (attr == 0)
      {
        if (type == 0)
        {
          list.Add(Fix.LEG_STRIKE_JP + "強化");
          list.Add(Fix.SPEED_STEP_JP + "強化");
          list.Add(Fix.BONE_CRUSH_JP + "強化");
          list.Add(Fix.DEADLY_DRIVE_JP + "強化");
          list.Add(Fix.UNINTENTIONAL_HIT_JP + "強化");
          list.Add(Fix.STANCE_OF_MUIN_JP + "強化");
          list.Add(Fix.CARNAGE_RUSH_JP + "強化");
        }
        else if (type == 1)
        {
          list.Add(Fix.FIRE_BALL_JP + "強化");
          list.Add(Fix.FLAME_BLADE_JP + "強化");
          list.Add(Fix.METEOR_BULLET_JP + "強化");
          list.Add(Fix.VOLCANIC_BLAZE_JP + "強化");
          list.Add(Fix.FLAME_STRIKE_JP + "強化");
          list.Add(Fix.CIRCLE_OF_THE_IGNITE_JP + "強化");
          list.Add(Fix.LAVA_ANNIHILATION_JP + "強化");
        }
        else if (type == 2)
        {
          list.Add(Fix.HEART_OF_LIFE_JP + "強化");
          list.Add(Fix.FORTUNE_SPIRIT_JP + "強化");
          list.Add(Fix.VOICE_OF_VIGOR_JP + "強化");
          list.Add(Fix.AURA_BURN_JP + "強化");
          list.Add(Fix.EVERFLOW_MIND_JP + "強化");
          list.Add(Fix.SOUL_SHOUT_JP + "強化");
          list.Add(Fix.OVERWHELMING_DESTINY_JP + "強化");
        }
      }
      else if (attr == 1)
      {
        if (type == 0)
        {
          list.Add(Fix.CLAW_TRAINING);
        }
        else if (type == 1)
        {
          list.Add(Fix.AXE_TRAINING);
        }
        else if (type == 2)
        {
          list.Add(Fix.SWORD_TRAINING);
        }
      }
      else if (attr == 2)
      {
        if (type == 0)
        {
          list.Add(Fix.STYLE_VOICE_CALLER);
        }
        else if (type == 1)
        {
          list.Add(Fix.STYLE_WAR_MASTER);
        }
        else if (type == 2)
        {
          list.Add(Fix.STYLE_DRAGON_SLAYER);
        }
      }
      else if (attr == 3)
      {
        if (type == 0)
        {
          list.Add(Fix.WAY_OF_SWORD);
        }
        else if (type == 1)
        {
          list.Add(Fix.NEED_MORE_POWER);
        }
        else if (type == 2)
        {
          list.Add(Fix.RUSH_STANCE);
        }
      }
    }
    else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
    {
      if (attr == 0)
      {
        if (type == 0)
        {
          list.Add(Fix.ENERGY_BOLT_JP + "強化");
          list.Add(Fix.IDEOLOGY_OF_SOPHISTICATION_JP + "強化");
          list.Add(Fix.SIGIL_OF_THE_PENDING_JP + "強化");
          list.Add(Fix.PHANTOM_OBORO_JP + "強化");
          list.Add(Fix.SIGIL_OF_THE_HOMURA_JP + "強化");
          list.Add(Fix.WORD_OF_PROPHECY_JP + "強化");
          list.Add(Fix.TRANSCENDENCE_REACHED_JP + "強化");
        }
        else if (type == 1)
        {
          list.Add(Fix.ROCK_SLAM_JP + "強化");
          list.Add(Fix.SOLID_WALL_JP + "強化");
          list.Add(Fix.LAND_SHATTER_JP + "強化");
          list.Add(Fix.SAND_BURST_JP + "強化");
          list.Add(Fix.PETRIFICATION_JP + "強化");
          list.Add(Fix.LIFE_GRACE_JP + "強化");
          list.Add(Fix.EARTH_QUAKE_JP + "強化");
        }
        else if (type == 2)
        {
          list.Add(Fix.ORACLE_COMMAND_JP + "強化");
          list.Add(Fix.SPIRITUAL_REST_JP + "強化");
          list.Add(Fix.UNSEEN_AID_JP + "強化");
          list.Add(Fix.EXACT_TIME_JP + "強化");
          list.Add(Fix.INNER_INSPIRATION_JP + "強化");
          list.Add(Fix.ZERO_IMMUNITY_JP + "強化");
          list.Add(Fix.TIME_SKIP_JP + "強化");
        }
      }
      else if (attr == 1)
      {
        if (type == 0)
        {
          list.Add(Fix.ROD_TRAINING);
        }
        else if (type == 1)
        {
          list.Add(Fix.AXE_TRAINING);
        }
        else if (type == 2)
        {
          list.Add(Fix.SHIELD_TRAINING);
        }
      }
      else if (attr == 2)
      {
        if (type == 0)
        {
          list.Add(Fix.STYLE_BARD_RANGER);
        }
        else if (type == 1)
        {
          list.Add(Fix.STYLE_BATTLE_SAGE);
        }
        else if (type == 2)
        {
          list.Add(Fix.STYLE_ORACLE_COMMANDER);
        }
      }
      else if (attr == 3)
      {
        if (type == 0)
        {
          list.Add(Fix.MASTER_TEACHING);
        }
        else if (type == 1)
        {
          list.Add(""); // todo
        }
        else if (type == 2)
        {
          list.Add(""); // todo
        }
      }
    }
    else if (this.FullName == Fix.NAME_SELMOI_RO)
    {
      if (attr == 0)
      {
        if (type == 0)
        {
          list.Add(Fix.VENOM_SLASH_JP + "強化");
          list.Add(Fix.INVISIBLE_BIND_JP + "強化");
          list.Add(Fix.IRREGULAR_STEP_JP + "強化");
          list.Add(Fix.ASSASSINATION_HIT_JP + "強化");
          list.Add(Fix.COUNTER_DISALLOW_JP + "強化");
          list.Add(Fix.DIRTY_WISDOM_JP + "強化");
          list.Add(Fix.AMBIDEXTERITY_JP + "強化");
        }
        else if (type == 1)
        {
          list.Add(Fix.AIR_CUTTER_JP + "強化");
          list.Add(Fix.STORM_ARMOR_JP + "強化");
          list.Add(Fix.SONIC_PULSE_JP + "強化");
          list.Add(Fix.GALE_WIND_JP + "強化");
          list.Add(Fix.ERRATIC_THUNDER_JP + "強化");
          list.Add(Fix.CYCLONE_FIELD_JP + "強化");
          list.Add(Fix.LIGHTNING_SQUALL_JP + "強化");
        }
        else if (type == 2)
        {
          list.Add(Fix.DARK_AURA_JP + "強化");
          list.Add(Fix.STANCE_OF_THE_SHADE_JP + "強化");
          list.Add(Fix.KILLING_WAVE_JP + "強化");
          list.Add(Fix.LEVEL_EATER_JP + "強化");
          list.Add(Fix.ABYSS_EYE_JP + "強化");
          list.Add(Fix.AVENGER_PROMISE_JP + "強化");
          list.Add(Fix.DEMON_CONTRACT_JP + "強化");
        }
      }
      else if (attr == 1)
      {
        if (type == 0)
        {
          list.Add(Fix.BOW_TRAINING);
        }
        else if (type == 1)
        {
          list.Add(Fix.ORB_TRAINING);
        }
        else if (type == 2)
        {
          list.Add(Fix.LANCE_TRAINING);
        }
      }
      else if (attr == 2)
      {
        if (type == 0)
        {
          list.Add(Fix.STYLE_MAGE_BREAKER);
        }
        else if (type == 1)
        {
          list.Add(Fix.STYLE_SHADOW_ROGUE);
        }
        else if (type == 2)
        {
          list.Add(Fix.STYLE_DEMON_LOAD);
        }
      }
      else if (attr == 3)
      {
        if (type == 0)
        {
          list.Add(Fix.TWIN_OFFENSIVE_STANCE);
        }
        else if (type == 1)
        {
          list.Add(""); // todo
        }
        else if (type == 2)
        {
          list.Add(""); // todo
        }
      }
    }
    return list;
  }

  public string GetEssenceTreeDescList(string essence_name)
  {
    if (essence_name == Fix.STRAIGHT_SMASH_JP + "強化") { return Fix.STRAIGHT_SMASH_JP + "の威力が５％上昇する。"; }
    else if (essence_name == Fix.TRUE_SIGHT_JP + "強化") { return Fix.TRUE_SIGHT_JP + "の効果時間が１ターン長くなる。"; }
    else if (essence_name == Fix.SHIELD_BASH_JP + "強化") { return Fix.SHIELD_BASH_JP + "によるスタン効果時間が１ターン長くなる。"; }
    else if (essence_name == Fix.ICE_NEEDLE_JP + "強化") { return Fix.ICE_NEEDLE_JP + "の威力が５％上昇する。"; }
    else if (essence_name == Fix.SHADOW_BLAST_JP + "強化") { return Fix.SHADOW_BLAST_JP + "による【陰影】効果からの魔法防御を減少させる効果が５％上昇する。"; }
    else if (essence_name == Fix.DISPEL_MAGIC_JP + "強化") { return Fix.DISPEL_MAGIC_JP + "による【有益】に属するBUFFを除去する数が１つ増える。"; }
    else if (essence_name == Fix.FRESH_HEAL_JP + "強化") { return Fix.FRESH_HEAL_JP + "の威力が５％上昇する。"; }
    else if (essence_name == Fix.HUNTER_SHOT_JP + "強化") { return Fix.HUNTER_SHOT_JP + "による【標的】効果からの命中率が１０％上昇する。"; }
    else if (essence_name == Fix.AURA_OF_POWER_JP + "強化") { return Fix.AURA_OF_POWER_JP + "による【パワー】効果からの物理攻撃を増強する威力が５％上昇する。"; }
    else if (essence_name == Fix.LEG_STRIKE_JP + "強化") { return Fix.LEG_STRIKE_JP + "の威力が５％上昇する。"; }
    else if (essence_name == Fix.FIRE_BALL_JP + "強化") { return Fix.FIRE_BALL_JP + "の威力が５％上昇する。"; }
    else if (essence_name == Fix.HEART_OF_LIFE_JP + "強化") { return Fix.HEART_OF_LIFE_JP + "による【生命】効果からのライフ回復量が１０％上昇する。"; }
    else if (essence_name == Fix.ENERGY_BOLT_JP + "強化") { return "エナジー・ボルトの威力が５％上昇する。"; }
    else if (essence_name == Fix.ROCK_SLAM_JP + "強化") { return "ロック・スラムの威力が５％上昇する。"; }
    else if (essence_name == Fix.ORACLE_COMMAND_JP + "強化") { return "オラクル・コマンドによるインスタント・ゲージ進行が10%増加する。"; }
    else if (essence_name == Fix.VENOM_SLASH_JP + "強化") { return "ヴェノム・スラッシュの威力が５％上昇する。"; }
    else if (essence_name == Fix.AIR_CUTTER_JP + "強化") { return "エア・カッターの威力が５％上昇する。"; }
    else if (essence_name == Fix.DARK_AURA_JP + "強化") { return "ダーク・オーラによる【黒炎】の累積カウントに対する最大上限が＋１される。"; }

    else if (essence_name == Fix.SWORD_TRAINING) { return "剣を装備しているとき、物理攻撃力が３％上昇する。"; }
    else if (essence_name == Fix.LANCE_TRAINING) { return "槍を装備しているとき、物理攻撃力が３％上昇する。"; }
    else if (essence_name == Fix.AXE_TRAINING) { return "斧を装備しているとき、物理攻撃力が３％上昇する。"; }
    else if (essence_name == Fix.CLAW_TRAINING) { return "爪を装備をしている時、物理攻撃力が3％上昇する。"; }
    else if (essence_name == Fix.ROD_TRAINING) { return "杖を装備をしている時、魔法攻撃力が3％上昇する。"; }
    else if (essence_name == Fix.BOOK_TRAINING) { return "本を装備をしている時、魔法攻撃力が3％上昇する。"; }
    else if (essence_name == Fix.ORB_TRAINING) { return "水晶を装備をしている時、魔法攻撃力が3％上昇する。"; }
    else if (essence_name == Fix.BOW_TRAINING) { return "弓を装備をしている時、物理攻撃力が3％上昇する。"; }
    else if (essence_name == Fix.SHIELD_TRAINING) { return "防御姿勢時のダメージ軽減率が２％上昇する。"; }

    else if (essence_name == Fix.STYLE_GLADIATOR_JP) { return "両手を使う武器の命中率が100%となる。"; }
    else if (essence_name == Fix.STYLE_DEFENDER_JP) { return "「防衛」のコマンドを使用可能となる。また物理防御力が１％上昇する。"; }
    else if (essence_name == Fix.STYLE_BRAVE_SEEKER_JP) { return "味方フィールドに「勇敢」のBUFFを形成する事が可能になる。"; }
    else if (essence_name == Fix.STYLE_SWORD_DANCER_JP) { return "「二刀流」が使用可能となる。武器の命中率が上昇する。"; }
    else if (essence_name == Fix.STYLE_ELEMENTAL_WIZARD_JP) { return "両手杖装備時、魔法攻撃力が３％上昇する。また、炎、氷、風、土の魔法耐性が１０％上昇する。"; }
    else if (essence_name == Fix.STYLE_MYSTIC_ENHANCER_JP) { return "ターン制BUFFのターン永続数が＋１ターンされる。また、威力を示す要素が含まれるBUFFを付与する時、威力の値が５％上昇する。"; }
    else if (essence_name == Fix.STYLE_AERIAL_HUNTER_JP) { return "弓装備時、命中率が100%になり、「ためる」コマンドを使用可能となる。"; }
    else if (essence_name == Fix.STYLE_HIGH_PRIEST_JP) { return "回復魔法の威力が5%上昇する。"; }
    else if (essence_name == Fix.STYLE_ROYAL_KNIGHT_JP) { return "【力】パラメタから物理防御への変換比率、【知】パラメタからの魔法防御への変換比率が0.2から0.3に上昇する。"; }
    else if (essence_name == Fix.STYLE_VOICE_CALLER_JP) { return "「シャウト」コマンドが使用可能となる。"; }
    else if (essence_name == Fix.STYLE_WAR_MASTER_JP) { return "「二刀流」が使用可能となる。武器による攻撃力が上昇する。"; }
    else if (essence_name == Fix.STYLE_DRAGON_SLAYER_JP) { return ""; }
    else if (essence_name == Fix.STYLE_BARD_RANGER_JP) { return "味方のフィールドBUFFから影響を受ける効果が増強される。"; }
    else if (essence_name == Fix.STYLE_BATTLE_SAGE_JP) { return ""; }
    else if (essence_name == Fix.STYLE_ORACLE_COMMANDER_JP) { return ""; }
    else if (essence_name == Fix.STYLE_MAGE_BREAKER_JP) { return ""; }
    else if (essence_name == Fix.STYLE_SHADOW_ROGUE_JP) { return ""; }
    else if (essence_name == Fix.STYLE_DEMON_LOAD_JP) { return ""; }

    else if (essence_name == Fix.MAGIC_SPELL_STANCE) { return "インスタントの行動が魔法の場合、インスタントゲージが５％残った状態で行動する。"; }
    else if (essence_name == Fix.MIKIRI_SENSE) { return "相手から自分に対しての命中率を１０％減らす。"; }
    else if (essence_name == Fix.RUSH_STANCE) { return "１回の行動で連続してダメージを伴う攻撃を実行した場合、２回目またはそれ以降の威力が１０％上昇する。"; }
    else if (essence_name == Fix.TWIN_OFFENSIVE_STANCE) { return "二刀流の装備形態の場合、物理ダメージがそれぞれ２％上昇する。"; }

    return String.Empty;
  }

  public List<string> GetEssenceTreeIconList(int level)
  {
    List<string> list = new List<string>();
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      list.Add(Fix.STRAIGHT_SMASH);
      list.Add(Fix.TRUE_SIGHT);
      list.Add(Fix.SHIELD_BASH);
      list.Add(Fix.DEFENSE);
    }
    else if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      list.Add(Fix.ICE_NEEDLE);
      list.Add(Fix.SHADOW_BLAST);
      list.Add(Fix.DISPEL_MAGIC);
      list.Add(Fix.MAGIC_ATTACK);
    }
    else if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      list.Add(Fix.FRESH_HEAL);
      list.Add(Fix.HUNTER_SHOT);
      list.Add(Fix.AURA_OF_POWER);
      list.Add("RunAwayButton"); // todo アイコンは改めて対応。
    }
    else if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      list.Add(Fix.LEG_STRIKE);
      list.Add(Fix.FIRE_BALL);
      list.Add(Fix.HEART_OF_LIFE);
      list.Add(Fix.STAY);
    }
    return list;
  }

  public void UpgradeEssenceTree(string essence_name)
  {
    if (essence_name == Fix.STRAIGHT_SMASH_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.StraightSmash++;
    }
    else if (essence_name == Fix.SHIELD_BASH_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.ShieldBash++;
    }
    else if (essence_name == Fix.TRUE_SIGHT_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.TrueSight++;
    }
    else if (essence_name == "防御の構え Ｉ")
    {
      this.SoulFragment--;
      this.DefenseSkill++;
    }
    if (essence_name == Fix.ICE_NEEDLE_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.IceNeedle++;
    }
    else if (essence_name == Fix.SHADOW_BLAST_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.ShadowBlast++;
    }
    else if (essence_name == Fix.DISPEL_MAGIC_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.DispelMagic++;
    }
    else if (essence_name == "魔法詠唱の構え Ｉ")
    {
      this.SoulFragment--;
      this.MagicSpell++;
    }
    else if (essence_name == Fix.FRESH_HEAL_JP + "強化 I")
    {
      this.SoulFragment--;
      this.FreshHeal++;
    }
    else if (essence_name == Fix.HUNTER_SHOT_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.HunterShot++;
    }
    else if (essence_name == Fix.AURA_OF_POWER_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.AuraOfPower++;
    }
    else if (essence_name == "見切りのセンス Ｉ")
    {
      this.SoulFragment--;
      this.EvadingSkill++;
    }
    else if (essence_name == Fix.FIRE_BALL_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.FireBall++;
    }
    else if (essence_name == Fix.LEG_STRIKE_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.LegStrike++;
    }
    else if (essence_name == Fix.HEART_OF_LIFE_JP + "強化 Ｉ")
    {
      this.SoulFragment--;
      this.HeartOfLife++;
    }
    else if (essence_name == "ラッシュの心構え Ｉ")
    {
      this.SoulFragment--;
      this.RushSkill++;
    }
    else if (essence_name == Fix.FIRE_BALL || essence_name == Fix.FIRE_BALL_JP)
    {
      this.SoulFragment--;
      this.FireBall++;
    }
    else if (essence_name == Fix.FLAME_BLADE || essence_name == Fix.FLAME_BLADE_JP)
    {
      this.SoulFragment--;
      this.FlameBlade++;
    }
    else if (essence_name == Fix.METEOR_BULLET || essence_name == Fix.METEOR_BULLET_JP)
    {
      this.SoulFragment--;
      this.MeteorBullet++;
    }
    else if (essence_name == Fix.VOLCANIC_BLAZE || essence_name == Fix.VOLCANIC_BLAZE_JP)
    {
      this.SoulFragment--;
      this.VolcanicBlaze++;
    }
    else if (essence_name == Fix.FLAME_STRIKE || essence_name == Fix.FLAME_STRIKE_JP)
    {
      this.SoulFragment--;
      this.FlameStrike++;
    }
    else if (essence_name == Fix.CIRCLE_OF_THE_IGNITE || essence_name == Fix.CIRCLE_OF_THE_IGNITE_JP)
    {
      this.SoulFragment--;
      this.CircleOfTheIgnite++;
    }
    else if (essence_name == Fix.LAVA_ANNIHILATION || essence_name == Fix.LAVA_ANNIHILATION_JP)
    {
      this.SoulFragment--;
      this.LavaAnnihilation++;
    }
    else if (essence_name == Fix.ICE_NEEDLE || essence_name == Fix.ICE_NEEDLE_JP)
    {
      this.SoulFragment--;
      this.IceNeedle++;
    }
    else if (essence_name == Fix.PURE_PURIFICATION || essence_name == Fix.PURE_PURIFICATION_JP)
    {
      this.SoulFragment--;
      this.PurePurification++;
    }
    else if (essence_name == Fix.BLUE_BULLET || essence_name == Fix.BLUE_BULLET_JP)
    {
      this.SoulFragment--;
      this.BlueBullet++;
    }
    else if (essence_name == Fix.FREEZING_CUBE || essence_name == Fix.FREEZING_CUBE_JP)
    {
      this.SoulFragment--;
      this.FreezingCube++;
    }
    else if (essence_name == Fix.FROST_LANCE || essence_name == Fix.FROST_LANCE_JP)
    {
      this.SoulFragment--;
      this.FrostLance++;
    }
    else if (essence_name == Fix.WATER_PRESENCE || essence_name == Fix.WATER_PRESENCE_JP)
    {
      this.SoulFragment--;
      this.WaterPresence++;
    }
    else if (essence_name == Fix.ABSOLUTE_ZERO || essence_name == Fix.ABSOLUTE_ZERO_JP)
    {
      this.SoulFragment--;
      this.AbsoluteZero++;
    }
    else if (essence_name == Fix.FRESH_HEAL || essence_name == Fix.FRESH_HEAL_JP)
    {
      this.SoulFragment--;
      this.FreshHeal++;
    }
    else if (essence_name == Fix.DIVINE_CIRCLE || essence_name == Fix.DIVINE_CIRCLE_JP)
    {
      this.SoulFragment--;
      this.DivineCircle++;
    }
    else if (essence_name == Fix.HOLY_BREATH || essence_name == Fix.HOLY_BREATH_JP)
    {
      this.SoulFragment--;
      this.HolyBreath++;
    }
    else if (essence_name == Fix.ANGELIC_ECHO || essence_name == Fix.ANGELIC_ECHO_JP)
    {
      this.SoulFragment--;
      this.AngelicEcho++;
    }
    else if (essence_name == Fix.SHINING_HEAL || essence_name == Fix.SHINING_HEAL_JP)
    {
      this.SoulFragment--;
      this.ShiningHeal++;
    }
    else if (essence_name == Fix.VALKYRIE_BLADE || essence_name == Fix.VALKYRIE_BLADE_JP)
    {
      this.SoulFragment--;
      this.ValkyrieBlade++;
    }
    else if (essence_name == Fix.RESURRECTION || essence_name == Fix.RESURRECTION_JP)
    {
      this.SoulFragment--;
      this.Resurrection++;
    }
    else if (essence_name == Fix.SHADOW_BLAST || essence_name == Fix.SHADOW_BLAST_JP)
    {
      this.SoulFragment--;
      this.ShadowBlast++;
    }
    else if (essence_name == Fix.BLOOD_SIGN || essence_name == Fix.BLOOD_SIGN_JP)
    {
      this.SoulFragment--;
      this.BloodSign++;
    }
    else if (essence_name == Fix.BLACK_CONTRACT || essence_name == Fix.BLACK_CONTRACT_JP)
    {
      this.SoulFragment--;
      this.BlackContract++;
    }
    else if (essence_name == Fix.CURSED_EVANGILE || essence_name == Fix.CURSED_EVANGILE_JP)
    {
      this.SoulFragment--;
      this.CursedEvangile++;
    }
    else if (essence_name == Fix.CIRCLE_OF_THE_DESPAIR || essence_name == Fix.CIRCLE_OF_THE_DESPAIR_JP)
    {
      this.SoulFragment--;
      this.CircleOfTheDespair++;
    }
    else if (essence_name == Fix.THE_DARK_INTENSITY || essence_name == Fix.THE_DARK_INTENSITY_JP)
    {
      this.SoulFragment--;
      this.TheDarkIntensity++;
    }
    else if (essence_name == Fix.DEATH_SCYTHE || essence_name == Fix.DEATH_SCYTHE_JP)
    {
      this.SoulFragment--;
      this.DeathScythe++;
    }
    else if (essence_name == Fix.ORACLE_COMMAND || essence_name == Fix.ORACLE_COMMAND_JP)
    {
      this.SoulFragment--;
      this.OracleCommand++;
    }
    else if (essence_name == Fix.FORTUNE_SPIRIT || essence_name == Fix.FORTUNE_SPIRIT_JP)
    {
      this.SoulFragment--;
      this.FortuneSpirit++;
    }
    else if (essence_name == Fix.WORD_OF_POWER || essence_name == Fix.WORD_OF_POWER_JP)
    {
      this.SoulFragment--;
      this.WordOfPower++;
    }
    else if (essence_name == Fix.GALE_WIND || essence_name == Fix.GALE_WIND_JP)
    {
      this.SoulFragment--;
      this.GaleWind++;
    }
    else if (essence_name == Fix.SEVENTH_PRINCIPLE || essence_name == Fix.SEVENTH_PRINCIPLE_JP)
    {
      this.SoulFragment--;
      this.SeventhPrinciple++;
    }
    else if (essence_name == Fix.FUTURE_VISION || essence_name == Fix.FUTURE_VISION_JP)
    {
      this.SoulFragment--;
      this.FutureVision++;
    }
    else if (essence_name == Fix.GENESIS || essence_name == Fix.GENESIS_JP)
    {
      this.SoulFragment--;
      this.Genesis++;
    }
    else if (essence_name == Fix.ENERGY_BOLT || essence_name == Fix.ENERGY_BOLT_JP)
    {
      this.SoulFragment--;
      this.EnergyBolt++;
    }
    else if (essence_name == Fix.FLASH_COUNTER || essence_name == Fix.FLASH_COUNTER_JP)
    {
      this.SoulFragment--;
      this.FlashCounter++;
    }
    else if (essence_name == Fix.SIGIL_OF_THE_PENDING || essence_name == Fix.SIGIL_OF_THE_PENDING_JP)
    {
      this.SoulFragment--;
      this.SigilOfThePending++;
    }
    else if (essence_name == Fix.PHANTOM_OBORO || essence_name == Fix.PHANTOM_OBORO_JP)
    {
      this.SoulFragment--;
      this.PhantomOboro++;
    }
    else if (essence_name == Fix.COUNTER_DISALLOW || essence_name == Fix.COUNTER_DISALLOW_JP)
    {
      this.SoulFragment--;
      this.CounterDisallow++;
    }
    else if (essence_name == Fix.DETACHMENT_FAULT || essence_name == Fix.DETACHMENT_FAULT_JP)
    {
      this.SoulFragment--;
      this.DetachmentFault++;
    }
    else if (essence_name == Fix.TIME_SKIP || essence_name == Fix.TIME_SKIP_JP)
    {
      this.SoulFragment--;
      this.TimeSkip++;
    }
    else if (essence_name == Fix.STRAIGHT_SMASH || essence_name == Fix.STRAIGHT_SMASH_JP)
    {
      this.SoulFragment--;
      this.StraightSmash++;
    }
    else if (essence_name == Fix.STANCE_OF_THE_BLADE || essence_name == Fix.STANCE_OF_THE_BLADE_JP)
    {
      this.SoulFragment--;
      this.StanceOfTheBlade++;
    }
    else if (essence_name == Fix.DOUBLE_SLASH || essence_name == Fix.DOUBLE_SLASH_JP)
    {
      this.SoulFragment--;
      this.DoubleSlash++;
    }
    else if (essence_name == Fix.IRON_BUSTER || essence_name == Fix.IRON_BUSTER_JP)
    {
      this.SoulFragment--;
      this.IronBuster++;
    }
    else if (essence_name == Fix.RAGING_STORM || essence_name == Fix.RAGING_STORM_JP)
    {
      this.SoulFragment--;
      this.RagingStorm++;
    }
    else if (essence_name == Fix.STANCE_OF_THE_IAI || essence_name == Fix.STANCE_OF_THE_IAI_JP)
    {
      this.SoulFragment--;
      this.StanceOfTheIai++;
    }
    else if (essence_name == Fix.KINETIC_SMASH || essence_name == Fix.KINETIC_SMASH_JP)
    {
      this.SoulFragment--;
      this.KineticSmash++;
    }
    else if (essence_name == Fix.SHIELD_BASH || essence_name == Fix.SHIELD_BASH_JP)
    {
      this.SoulFragment--;
      this.ShieldBash++;
    }
    else if (essence_name == Fix.STANCE_OF_THE_GUARD || essence_name == Fix.STANCE_OF_THE_GUARD_JP)
    {
      this.SoulFragment--;
      this.StanceOfTheGuard++;
    }
    else if (essence_name == Fix.CONCUSSIVE_HIT || essence_name == Fix.CONCUSSIVE_HIT_JP)
    {
      this.SoulFragment--;
      this.ConcussiveHit++;
    }
    else if (essence_name == Fix.DOMINATION_FIELD || essence_name == Fix.DOMINATION_FIELD_JP)
    {
      this.SoulFragment--;
      this.DominationField++;
    }
    else if (essence_name == Fix.HARDEST_PARRY || essence_name == Fix.HARDEST_PARRY_JP)
    {
      this.SoulFragment--;
      this.HardestParry++;
    }
    else if (essence_name == Fix.ONE_IMMUNITY || essence_name == Fix.ONE_IMMUNITY_JP)
    {
      this.SoulFragment--;
      this.OneImmunity++;
    }
    else if (essence_name == Fix.CATASTROPHE || essence_name == Fix.CATASTROPHE_JP)
    {
      this.SoulFragment--;
      this.Catastrophe++;
    }
    else if (essence_name == Fix.LEG_STRIKE || essence_name == Fix.LEG_STRIKE_JP)
    {
      this.SoulFragment--;
      this.LegStrike++;
    }
    else if (essence_name == Fix.SPEED_STEP || essence_name == Fix.SPEED_STEP_JP)
    {
      this.SoulFragment--;
      this.SpeedStep++;
    }
    else if (essence_name == Fix.BONE_CRUSH || essence_name == Fix.BONE_CRUSH_JP)
    {
      this.SoulFragment--;
      this.BoneCrush++;
    }
    else if (essence_name == Fix.DEADLY_DRIVE || essence_name == Fix.DEADLY_DRIVE_JP)
    {
      this.SoulFragment--;
      this.DeadlyDrive++;
    }
    else if (essence_name == Fix.UNINTENTIONAL_HIT || essence_name == Fix.UNINTENTIONAL_HIT_JP)
    {
      this.SoulFragment--;
      this.UnintentionalHit++;
    }
    else if (essence_name == Fix.STANCE_OF_MUIN || essence_name == Fix.STANCE_OF_MUIN_JP)
    {
      this.SoulFragment--;
      this.StanceOfMuin++;
    }
    else if (essence_name == Fix.CARNAGE_RUSH || essence_name == Fix.CARNAGE_RUSH_JP)
    {
      this.SoulFragment--;
      this.CarnageRush++;
    }
    else if (essence_name == Fix.HUNTER_SHOT || essence_name == Fix.HUNTER_SHOT_JP)
    {
      this.SoulFragment--;
      this.HunterShot++;
    }
    else if (essence_name == Fix.MULTIPLE_SHOT || essence_name == Fix.MULTIPLE_SHOT_JP)
    {
      this.SoulFragment--;
      this.MultipleShot++;
    }
    else if (essence_name == Fix.EYE_OF_THE_ISSHIN || essence_name == Fix.EYE_OF_THE_ISSHIN_JP)
    {
      this.SoulFragment--;
      this.EyeOfTheIsshin++;
    }
    else if (essence_name == Fix.PENETRATION_ARROW || essence_name == Fix.PENETRATION_ARROW_JP)
    {
      this.SoulFragment--;
      this.PenetrationArrow++;
    }
    else if (essence_name == Fix.PRECISION_STRIKE || essence_name == Fix.PRECISION_STRIKE_JP)
    {
      this.SoulFragment--;
      this.PrecisionStrike++;
    }
    else if (essence_name == Fix.ETERNAL_CONCENTRATION || essence_name == Fix.ETERNAL_CONCENTRATION_JP)
    {
      this.SoulFragment--;
      this.EternalConcentration++;
    }
    else if (essence_name == Fix.PENETRATION_ARROW || essence_name == Fix.PENETRATION_ARROW_JP)
    {
      this.SoulFragment--;
      this.PenetrationArrow++;
    }
    else if (essence_name == Fix.TRUE_SIGHT || essence_name == Fix.TRUE_SIGHT_JP)
    {
      this.SoulFragment--;
      this.TrueSight++;
    }
    else if (essence_name == Fix.LEYLINE_SCHEMA || essence_name == Fix.LEYLINE_SCHEMA_JP)
    {
      this.SoulFragment--;
      this.LeylineSchema++;
    }
    else if (essence_name == Fix.VOICE_OF_VIGOR || essence_name == Fix.VOICE_OF_VIGOR_JP)
    {
      this.SoulFragment--;
      this.VoiceOfVigor++;
    }
    else if (essence_name == Fix.WILL_AWAKENING || essence_name == Fix.WILL_AWAKENING_JP)
    {
      this.SoulFragment--;
      this.WillAwakening++;
    }
    else if (essence_name == Fix.EVERFLOW_MIND || essence_name == Fix.EVERFLOW_MIND_JP)
    {
      this.SoulFragment--;
      this.EverflowMind++;
    }
    else if (essence_name == Fix.SIGIL_OF_THE_FAITH || essence_name == Fix.SIGIL_OF_THE_FAITH_JP)
    {
      this.SoulFragment--;
      this.SigilOfTheFaith++;
    }
    else if (essence_name == Fix.STANCE_OF_THE_KOKOROE || essence_name == Fix.STANCE_OF_THE_KOKOROE_JP)
    {
      this.SoulFragment--;
      this.StanceOfTheKokoroe++;
    }
    else if (essence_name == Fix.DISPEL_MAGIC || essence_name == Fix.DISPEL_MAGIC_JP)
    {
      this.SoulFragment--;
      this.DispelMagic++;
    }
    else if (essence_name == Fix.SPIRITUAL_REST || essence_name == Fix.SPIRITUAL_REST_JP)
    {
      this.SoulFragment--;
      this.SpiritualRest++;
    }
    else if (essence_name == Fix.UNSEEN_AID || essence_name == Fix.UNSEEN_AID_JP)
    {
      this.SoulFragment--;
      this.UnseenAid++;
    }
    else if (essence_name == Fix.CIRCLE_OF_SERENITY || essence_name == Fix.CIRCLE_OF_SERENITY_JP)
    {
      this.SoulFragment--;
      this.CircleOfSerenity++;
    }
    else if (essence_name == Fix.INNER_INSPIRATION || essence_name == Fix.INNER_INSPIRATION_JP)
    {
      this.SoulFragment--;
      this.InnerInspiration++;
    }
    else if (essence_name == Fix.ZERO_IMMUNITY || essence_name == Fix.ZERO_IMMUNITY_JP)
    {
      this.SoulFragment--;
      this.ZeroImmunity++;
    }
    else if (essence_name == Fix.TRANSCENDENCE_REACHED || essence_name == Fix.TRANSCENDENCE_REACHED_JP)
    {
      this.SoulFragment--;
      this.TranscendenceReached++;
    }
  }

  public void UpdateActionCommandList(List<NodeActionCommand> action_command_list)
  {
    if (action_command_list.Count >= 1) { ActionCommand1 = action_command_list[0].CommandName; }
    if (action_command_list.Count >= 2) { ActionCommand2 = action_command_list[1].CommandName; }
    if (action_command_list.Count >= 3) { ActionCommand3 = action_command_list[2].CommandName; }
    if (action_command_list.Count >= 4) { ActionCommand4 = action_command_list[3].CommandName; }
    if (action_command_list.Count >= 5) { ActionCommand5 = action_command_list[4].CommandName; }
    if (action_command_list.Count >= 6) { ActionCommand6 = action_command_list[5].CommandName; }
    if (action_command_list.Count >= 7) { ActionCommand7 = action_command_list[6].CommandName; }
    if (action_command_list.Count >= 8) { ActionCommand8 = action_command_list[7].CommandName; }
    if (action_command_list.Count >= 9) { ActionCommand9 = action_command_list[8].CommandName; }

  }
  #endregion
  #endregion

  #region "Character Data"
  public void CharacterCreation(string character_name)
  {
    this.FullName = character_name;
    List<string> actionList = new List<string>();
    this.ActionCommandMain = Fix.STAY;
    this.ActionCommand1 = Fix.STAY;
    this.ActionCommand2 = Fix.STAY;
    this.ActionCommand3 = Fix.STAY;
    this.ActionCommand4 = Fix.STAY;
    this.ActionCommand5 = Fix.STAY;
    this.ActionCommand6 = Fix.STAY;
    this.ActionCommand7 = Fix.STAY;
    this.ActionCommand8 = Fix.STAY;
    this.ActionCommand9 = Fix.STAY;
    this.CurrentActionCommand = String.Empty;

    this.BattleBackColor = Fix.COLOR_FIRST_CHARA;
    this.BattleForeColor = Fix.COLORFORE_FIRST_CHARA;
    //this.ActionCommandList[0] = Fix.NORMAL_ATTACK;
    //this.ActionCommandList[1] = Fix.MAGIC_ATTACK;
    //this.ActionCommandList[2] = Fix.DEFENSE;

    switch (character_name)
    {
      case Fix.NAME_EIN_WOLENCE:
        this.Level = 1; // 17 + 0
        this.Strength = 5;
        this.Agility = 3;
        this.Intelligence = 2;
        this.Stamina = 4;
        this.Mind = 3;
        this.BaseLife = 30;
        this.BaseManaPoint = 10;
        this.BaseSkillPoint = 100;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Guardian;
        this.FourthCommandAttribute = Fix.CommandAttribute.HolyLight;
        this.FifthCommandAttribute = Fix.CommandAttribute.Force;
        this.SixthCommandAttribute = Fix.CommandAttribute.Truth;
        this.BattleBackColor = Fix.COLOR_FIRST_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIRST_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_SWORD);
        this.MainArmor = new Item(Fix.BEGINNER_ARMOR);
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.CurrentImmediateCommand = Fix.SMALL_RED_POTION;
        this.ActionCommandMain = Fix.NORMAL_ATTACK;
        this.ActionCommand1 = Fix.STRAIGHT_SMASH;
        this.AvailableWarrior = true;
        this.StraightSmash = 1;
        break;

      case Fix.NAME_LANA_AMIRIA:
        this.Level = 1; // 17 + 0
        this.Strength = 3;
        this.Agility = 5;
        this.Intelligence = 4;
        this.Stamina = 2;
        this.Mind = 3;
        this.BaseLife = 25;
        this.BaseManaPoint = 15;
        this.BaseSkillPoint = 100;
        this.Job = Fix.JobClass.Magician;
        this.FirstCommandAttribute = Fix.CommandAttribute.Ice;
        this.SecondCommandAttribute = Fix.CommandAttribute.MartialArts;
        this.ThirdCommandAttribute = Fix.CommandAttribute.DarkMagic;
        this.FourthCommandAttribute = Fix.CommandAttribute.Mindfulness;
        this.FifthCommandAttribute = Fix.CommandAttribute.VoidChant;
        this.SixthCommandAttribute = Fix.CommandAttribute.Fire;
        this.BattleBackColor = Fix.COLOR_SECOND_CHARA;
        this.BattleForeColor = Fix.COLORFORE_SECOND_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_ORB);
        this.MainArmor = new Item(Fix.BEGINNER_ROBE);
        this.GlobalAction1 = Fix.MAGIC_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.CurrentImmediateCommand = Fix.SMALL_RED_POTION;
        this.ActionCommandMain = Fix.MAGIC_ATTACK;
        this.ActionCommand1 = Fix.ICE_NEEDLE;
        this.AvailableIce = true;
        this.IceNeedle = 1;
        break;

      case Fix.NAME_EONE_FULNEA:
        this.Level = 6; // 17 + (12 + 4)
        this.Strength = 7;
        this.Agility = 8;
        this.Intelligence = 9;
        this.Stamina = 5;
        this.Mind = 4;
        this.BaseLife = 20 + 30; // level6スタートのため、LV2～LV6分を足し算。
        this.BaseManaPoint = 20 + 46; // level6スタートのため、LV2～LV6分を足し算。
        this.BaseSkillPoint = 100;
        this.Job = Fix.JobClass.Magician;
        this.FirstCommandAttribute = Fix.CommandAttribute.Archery;
        this.SecondCommandAttribute = Fix.CommandAttribute.HolyLight;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Mindfulness;
        this.FourthCommandAttribute = Fix.CommandAttribute.VoidChant;
        this.FifthCommandAttribute = Fix.CommandAttribute.Ice;
        this.SixthCommandAttribute = Fix.CommandAttribute.DarkMagic;
        this.BattleBackColor = Fix.COLOR_THIRD_CHARA;
        this.BattleForeColor = Fix.COLORFORE_THIRD_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_ORB);
        this.MainArmor = new Item(Fix.BEGINNER_ROBE);
        this.GlobalAction1 = Fix.MAGIC_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.FRESH_HEAL;
        this.GlobalAction4 = Fix.MAGIC_ATTACK;
        this.ActionCommandMain = Fix.MAGIC_ATTACK;
        this.ActionCommand1 = Fix.HUNTER_SHOT;
        this.ActionCommand2 = Fix.FRESH_HEAL;
        this.ActionCommand3 = Fix.MULTIPLE_SHOT;
        this.ActionCommand4 = Fix.DIVINE_CIRCLE;
        this.AvailableArchery = true;
        this.AvailableHolyLight = true;
        this.HunterShot = 1;
        this.MultipleShot = 1;
        this.FreshHeal = 1;
        this.DivineCircle = 1;
        break;

      case Fix.NAME_BILLY_RAKI:
        this.Level = 14; // 17 + (3*4 + 4*5 + 5*4)
        this.Strength = 22;
        this.Agility = 12;
        this.Intelligence = 4;
        this.Stamina = 17;
        this.Mind = 14;
        this.BaseLife = 50 + 246; // level14スタートのため、LV2～LV14分を足し算。
        this.BaseManaPoint = 5 + 52; // level14スタートのため、LV2～LV14分を足し算。
        this.BaseSkillPoint = 100;
        this.SoulFragment = 4;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.MartialArts;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Truth;
        this.FourthCommandAttribute = Fix.CommandAttribute.Warrior;
        this.FifthCommandAttribute = Fix.CommandAttribute.DarkMagic;
        this.SixthCommandAttribute = Fix.CommandAttribute.Mindfulness;
        this.BattleBackColor = Fix.COLOR_FOURTH_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FOURTH_CHARA;
        this.MainWeapon = new Item(Fix.SMART_CLAW);
        this.MainArmor = new Item(Fix.SMART_CROSS);
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.LEG_STRIKE;
        this.GlobalAction4 = Fix.DEFENSE;
        this.ActionCommandMain = Fix.NORMAL_ATTACK;
        this.ActionCommand1 = Fix.LEG_STRIKE;
        this.ActionCommand2 = Fix.SPEED_STEP;
        this.ActionCommand3 = Fix.BONE_CRUSH;
        this.ActionCommand4 = Fix.FIRE_BALL;
        this.ActionCommand5 = Fix.FLAME_BLADE;
        this.ActionCommand6 = Fix.METEOR_BULLET;
        this.ActionCommand7 = Fix.TRUE_SIGHT;
        this.AvailableMartialArts = true;
        this.AvailableFire = true;
        this.AvailableTruth = true;
        this.LegStrike = 1;
        this.SpeedStep = 1;
        this.BoneCrush = 1;
        this.FireBall = 1;
        this.FlameBlade = 1;
        this.MeteorBullet = 1;
        this.TrueSight = 1;
        break;

      case Fix.NAME_ADEL_BRIGANDY:
        this.Level = 20; // 17 + 3*4 + 4*5 + 5*5 + 6*5 = 104
        this.Strength = 8; // 0.08%
        this.Agility = 20; // 0.19%
        this.Intelligence = 30; // 0.29%
        this.Stamina = 13; // 0.12%
        this.Mind = 33; // 0.32%
        this.BaseLife = 15 + 388; // LV20スタートのため
        this.BaseManaPoint = 25 + 220; // LV20スタートのため
        this.BaseSkillPoint = 100;
        this.Job = Fix.JobClass.Seeker;
        this.FirstCommandAttribute = Fix.CommandAttribute.VoidChant;
        this.SecondCommandAttribute = Fix.CommandAttribute.Truth;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Force;
        this.FourthCommandAttribute = Fix.CommandAttribute.HolyLight;
        this.FifthCommandAttribute = Fix.CommandAttribute.Archery;
        this.SixthCommandAttribute = Fix.CommandAttribute.Ice;
        this.BattleBackColor = Fix.COLOR_FIFTH_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIFTH_CHARA;
        this.MainWeapon = new Item(Fix.SUPERIOR_BOOK);
        this.SubWeapon = new Item(Fix.SUPERIOR_ORB);
        this.MainArmor = new Item(Fix.SUPERIOR_CROSS);
        this.Accessory1 = new Item(Fix.SPIRIT_CHALICE_OF_HEART);
        this.Accessory2 = new Item(Fix.MIRAGE_PLASMA_EARRING);
        this.Artifact = new Item(Fix.YELLOW_KOKUIN);
        this.ActionCommandMain = Fix.MAGIC_ATTACK;
        this.ActionCommand1 = Fix.ENERGY_BOLT;
        this.ActionCommand2 = Fix.FLASH_COUNTER;
        this.ActionCommand3 = Fix.SIGIL_OF_THE_PENDING;
        this.ActionCommand4 = Fix.TRUE_SIGHT;
        this.ActionCommand5 = Fix.LEYLINE_SCHEMA;
        this.ActionCommand6 = Fix.SIGIL_OF_THE_PENDING;
        this.ActionCommand7 = Fix.ORACLE_COMMAND;
        this.ActionCommand8 = Fix.FORTUNE_SPIRIT;
        this.ActionCommand9 = Fix.WORD_OF_POWER;
        this.RemainPoint = 5;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.NORMAL_ATTACK;
        this.GlobalAction4 = Fix.MAGIC_ATTACK;
        this.AvailableVoidChant = true;
        this.AvailableTruth = true;
        this.AvailableForce = true;
        this.EnergyBolt = 1;
        this.FlashCounter = 1;
        this.SigilOfThePending = 1;
        this.TrueSight = 1;
        this.LeylineSchema = 1;
        this.VoiceOfVigor = 1;
        this.OracleCommand = 1;
        this.FortuneSpirit = 1;
        this.WordOfPower = 1;
        break;

      case Fix.NAME_CALMANS_OHN:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_MAGI_ZELKIS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_SELMOI_RO:
        this.Level = 1;
        this.Strength = 3;
        this.Agility = 20;
        this.Intelligence = 9;
        this.Stamina = 4;
        this.Mind = 8;
        this.BaseLife = 20;
        this.BaseManaPoint = 20;
        this.BaseSkillPoint = 100;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_KARTIN_MAI:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_JEDA_ARUS:
        this.Level = 1;
        this.Strength = 7;
        this.Agility = 6;
        this.Intelligence = 7;
        this.Stamina = 4;
        this.Mind = 3;
        this.BaseLife = 30;
        this.BaseManaPoint = 25;
        this.BaseSkillPoint = 100;
        this.Job = Fix.JobClass.Seeker;
        this.ShadowBlast = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.SHADOW_BLAST;
        this.GlobalAction4 = Fix.DEFENSE;
        break;

      case Fix.NAME_SINIKIA_VEILHANZ:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_LENE_COLTOS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_PERMA_WARAMY:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_KILT_JORJU:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_ANNA_HAMILTON:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Strength = 4;
        this.Agility = 10;
        this.Intelligence = 5;
        this.Stamina = 5;
        this.Mind = 3;
        this.BaseLife = 40;
        this.BaseManaPoint = 16;
        this.BaseSkillPoint = 100;
        this.Job = Fix.JobClass.Fighter;
        this.HunterShot = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.HUNTER_SHOT;
        this.GlobalAction4 = Fix.DEFENSE;
        break;

      case Fix.NAME_SUN_YU:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_SHUVALTZ_FLORE:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_RVEL_ZELKIS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_VAN_HEHGUSTEL:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_OHRYU_GENMA:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_LADA_MYSTORUS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_SIN_OSCURETE:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_DELVA_TRECKINO:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;

      case Fix.NAME_ILZINA_MELDIETE:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        break;
    }

    MaxGain();
  }

  public int LevelupBaseLife()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (Level == 2) { return 6; }
      if (Level == 3) { return 7; }
      if (Level == 4) { return 8; }
      if (Level == 5) { return 9; }
      if (Level == 6) { return 10; }
      if (Level == 7) { return 12; }
      if (Level == 8) { return 14; }
      if (Level == 9) { return 16; }
      if (Level == 10) { return 18; }
      if (Level == 11) { return 20; }
      if (Level == 12) { return 24; }
      if (Level == 13) { return 28; }
      if (Level == 14) { return 32; }
      if (Level == 15) { return 36; }
      if (Level == 16) { return 40; }
      if (Level == 17) { return 46; }
      if (Level == 18) { return 52; }
      if (Level == 19) { return 58; }
      if (Level == 20) { return 64; }
      if (Level == 21) { return 70; }
      if (Level == 22) { return 79; }
      if (Level == 23) { return 88; }
      if (Level == 24) { return 97; }
      if (Level == 25) { return 106; }
      if (Level == 26) { return 115; }
      if (Level == 27) { return 127; }
      if (Level == 28) { return 139; }
      if (Level == 29) { return 151; }
      if (Level == 30) { return 163; }
      if (Level == 31) { return 175; }
      if (Level == 32) { return 192; }
      if (Level == 33) { return 209; }
      if (Level == 34) { return 226; }
      if (Level == 35) { return 243; }
      if (Level == 36) { return 260; }
      if (Level == 37) { return 282; }
      if (Level == 38) { return 304; }
      if (Level == 39) { return 326; }
      if (Level == 40) { return 348; }
      if (Level == 41) { return 370; }
      if (Level == 42) { return 400; }
      if (Level == 43) { return 430; }
      if (Level == 44) { return 460; }
      if (Level == 45) { return 490; }
      if (Level == 46) { return 520; }
      if (Level == 47) { return 558; }
      if (Level == 48) { return 596; }
      if (Level == 49) { return 634; }
      if (Level == 50) { return 672; }
      if (Level == 51) { return 710; }
      if (Level == 52) { return 761; }
      if (Level == 53) { return 812; }
      if (Level == 54) { return 863; }
      if (Level == 55) { return 914; }
      if (Level == 56) { return 965; }
      if (Level == 57) { return 1029; }
      if (Level == 58) { return 1093; }
      if (Level == 59) { return 1157; }
      if (Level == 60) { return 1221; }
      if (Level == 61) { return 1285; }
      if (Level == 62) { return 1370; }
      if (Level == 63) { return 1455; }
      if (Level == 64) { return 1540; }
      if (Level == 65) { return 1625; }
      if (Level == 66) { return 1710; }
      if (Level == 67) { return 1816; }
      if (Level == 68) { return 1922; }
      if (Level == 69) { return 2028; }
      if (Level == 70) { return 2134; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (Level == 2) { return 5; }
      if (Level == 3) { return 6; }
      if (Level == 4) { return 7; }
      if (Level == 5) { return 8; }
      if (Level == 6) { return 9; }
      if (Level == 7) { return 11; }
      if (Level == 8) { return 13; }
      if (Level == 9) { return 15; }
      if (Level == 10) { return 17; }
      if (Level == 11) { return 19; }
      if (Level == 12) { return 22; }
      if (Level == 13) { return 25; }
      if (Level == 14) { return 28; }
      if (Level == 15) { return 31; }
      if (Level == 16) { return 34; }
      if (Level == 17) { return 39; }
      if (Level == 18) { return 44; }
      if (Level == 19) { return 49; }
      if (Level == 20) { return 54; }
      if (Level == 21) { return 59; }
      if (Level == 22) { return 66; }
      if (Level == 23) { return 73; }
      if (Level == 24) { return 80; }
      if (Level == 25) { return 87; }
      if (Level == 26) { return 94; }
      if (Level == 27) { return 103; }
      if (Level == 28) { return 112; }
      if (Level == 29) { return 121; }
      if (Level == 30) { return 130; }
      if (Level == 31) { return 139; }
      if (Level == 32) { return 151; }
      if (Level == 33) { return 163; }
      if (Level == 34) { return 175; }
      if (Level == 35) { return 187; }
      if (Level == 36) { return 199; }
      if (Level == 37) { return 214; }
      if (Level == 38) { return 229; }
      if (Level == 39) { return 244; }
      if (Level == 40) { return 259; }
      if (Level == 41) { return 274; }
      if (Level == 42) { return 292; }
      if (Level == 43) { return 310; }
      if (Level == 44) { return 328; }
      if (Level == 45) { return 346; }
      if (Level == 46) { return 364; }
      if (Level == 47) { return 386; }
      if (Level == 48) { return 408; }
      if (Level == 49) { return 430; }
      if (Level == 50) { return 452; }
      if (Level == 51) { return 474; }
      if (Level == 52) { return 500; }
      if (Level == 53) { return 526; }
      if (Level == 54) { return 552; }
      if (Level == 55) { return 578; }
      if (Level == 56) { return 604; }
      if (Level == 57) { return 634; }
      if (Level == 58) { return 664; }
      if (Level == 59) { return 694; }
      if (Level == 60) { return 724; }
      if (Level == 61) { return 754; }
      if (Level == 62) { return 789; }
      if (Level == 63) { return 824; }
      if (Level == 64) { return 859; }
      if (Level == 65) { return 894; }
      if (Level == 66) { return 929; }
      if (Level == 67) { return 969; }
      if (Level == 68) { return 1009; }
      if (Level == 69) { return 1049; }
      if (Level == 70) { return 1089; }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (Level == 2) { return 4; }
      if (Level == 3) { return 5; }
      if (Level == 4) { return 6; }
      if (Level == 5) { return 7; }
      if (Level == 6) { return 8; }
      if (Level == 7) { return 10; }
      if (Level == 8) { return 12; }
      if (Level == 9) { return 14; }
      if (Level == 10) { return 16; }
      if (Level == 11) { return 18; }
      if (Level == 12) { return 21; }
      if (Level == 13) { return 24; }
      if (Level == 14) { return 27; }
      if (Level == 15) { return 30; }
      if (Level == 16) { return 33; }
      if (Level == 17) { return 37; }
      if (Level == 18) { return 41; }
      if (Level == 19) { return 45; }
      if (Level == 20) { return 49; }
      if (Level == 21) { return 53; }
      if (Level == 22) { return 59; }
      if (Level == 23) { return 65; }
      if (Level == 24) { return 71; }
      if (Level == 25) { return 77; }
      if (Level == 26) { return 83; }
      if (Level == 27) { return 91; }
      if (Level == 28) { return 99; }
      if (Level == 29) { return 107; }
      if (Level == 30) { return 115; }
      if (Level == 31) { return 123; }
      if (Level == 32) { return 133; }
      if (Level == 33) { return 143; }
      if (Level == 34) { return 153; }
      if (Level == 35) { return 163; }
      if (Level == 36) { return 173; }
      if (Level == 37) { return 186; }
      if (Level == 38) { return 199; }
      if (Level == 39) { return 212; }
      if (Level == 40) { return 225; }
      if (Level == 41) { return 238; }
      if (Level == 42) { return 254; }
      if (Level == 43) { return 270; }
      if (Level == 44) { return 286; }
      if (Level == 45) { return 302; }
      if (Level == 46) { return 318; }
      if (Level == 47) { return 337; }
      if (Level == 48) { return 356; }
      if (Level == 49) { return 375; }
      if (Level == 50) { return 394; }
      if (Level == 51) { return 413; }
      if (Level == 52) { return 435; }
      if (Level == 53) { return 457; }
      if (Level == 54) { return 479; }
      if (Level == 55) { return 501; }
      if (Level == 56) { return 523; }
      if (Level == 57) { return 549; }
      if (Level == 58) { return 575; }
      if (Level == 59) { return 601; }
      if (Level == 60) { return 627; }
      if (Level == 61) { return 653; }
      if (Level == 62) { return 683; }
      if (Level == 63) { return 713; }
      if (Level == 64) { return 743; }
      if (Level == 65) { return 773; }
      if (Level == 66) { return 803; }
      if (Level == 67) { return 837; }
      if (Level == 68) { return 871; }
      if (Level == 69) { return 905; }
      if (Level == 70) { return 939; }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (Level == 2) { return 10; }
      if (Level == 3) { return 11; }
      if (Level == 4) { return 12; }
      if (Level == 5) { return 13; }
      if (Level == 6) { return 14; }
      if (Level == 7) { return 16; }
      if (Level == 8) { return 18; }
      if (Level == 9) { return 20; }
      if (Level == 10) { return 22; }
      if (Level == 11) { return 24; }
      if (Level == 12) { return 28; }
      if (Level == 13) { return 32; }
      if (Level == 14) { return 36; }
      if (Level == 15) { return 40; }
      if (Level == 16) { return 44; }
      if (Level == 17) { return 50; }
      if (Level == 18) { return 56; }
      if (Level == 19) { return 62; }
      if (Level == 20) { return 68; }
      if (Level == 21) { return 74; }
      if (Level == 22) { return 83; }
      if (Level == 23) { return 92; }
      if (Level == 24) { return 101; }
      if (Level == 25) { return 110; }
      if (Level == 26) { return 119; }
      if (Level == 27) { return 131; }
      if (Level == 28) { return 143; }
      if (Level == 29) { return 155; }
      if (Level == 30) { return 167; }
      if (Level == 31) { return 179; }
      if (Level == 32) { return 195; }
      if (Level == 33) { return 211; }
      if (Level == 34) { return 227; }
      if (Level == 35) { return 243; }
      if (Level == 36) { return 259; }
      if (Level == 37) { return 279; }
      if (Level == 38) { return 299; }
      if (Level == 39) { return 319; }
      if (Level == 40) { return 339; }
      if (Level == 41) { return 359; }
      if (Level == 42) { return 384; }
      if (Level == 43) { return 409; }
      if (Level == 44) { return 434; }
      if (Level == 45) { return 459; }
      if (Level == 46) { return 484; }
      if (Level == 47) { return 514; }
      if (Level == 48) { return 544; }
      if (Level == 49) { return 574; }
      if (Level == 50) { return 604; }
      if (Level == 51) { return 634; }
      if (Level == 52) { return 670; }
      if (Level == 53) { return 706; }
      if (Level == 54) { return 742; }
      if (Level == 55) { return 778; }
      if (Level == 56) { return 814; }
      if (Level == 57) { return 856; }
      if (Level == 58) { return 898; }
      if (Level == 59) { return 940; }
      if (Level == 60) { return 982; }
      if (Level == 61) { return 1024; }
      if (Level == 62) { return 1073; }
      if (Level == 63) { return 1122; }
      if (Level == 64) { return 1171; }
      if (Level == 65) { return 1220; }
      if (Level == 66) { return 1269; }
      if (Level == 67) { return 1325; }
      if (Level == 68) { return 1381; }
      if (Level == 69) { return 1437; }
      if (Level == 70) { return 1493; }
    }
    if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
    {
      if (Level == 2) { return 3; }
      if (Level == 3) { return 4; }
      if (Level == 4) { return 5; }
      if (Level == 5) { return 6; }
      if (Level == 6) { return 7; }
      if (Level == 7) { return 9; }
      if (Level == 8) { return 11; }
      if (Level == 9) { return 13; }
      if (Level == 10) { return 15; }
      if (Level == 11) { return 17; }
      if (Level == 12) { return 20; }
      if (Level == 13) { return 23; }
      if (Level == 14) { return 26; }
      if (Level == 15) { return 29; }
      if (Level == 16) { return 32; }
      if (Level == 17) { return 36; }
      if (Level == 18) { return 40; }
      if (Level == 19) { return 44; }
      if (Level == 20) { return 48; }
      if (Level == 21) { return 52; }
      if (Level == 22) { return 57; }
      if (Level == 23) { return 62; }
      if (Level == 24) { return 67; }
      if (Level == 25) { return 72; }
      if (Level == 26) { return 77; }
      if (Level == 27) { return 84; }
      if (Level == 28) { return 91; }
      if (Level == 29) { return 98; }
      if (Level == 30) { return 105; }
      if (Level == 31) { return 112; }
      if (Level == 32) { return 121; }
      if (Level == 33) { return 130; }
      if (Level == 34) { return 139; }
      if (Level == 35) { return 148; }
      if (Level == 36) { return 157; }
      if (Level == 37) { return 168; }
      if (Level == 38) { return 179; }
      if (Level == 39) { return 190; }
      if (Level == 40) { return 201; }
      if (Level == 41) { return 212; }
      if (Level == 42) { return 225; }
      if (Level == 43) { return 238; }
      if (Level == 44) { return 251; }
      if (Level == 45) { return 264; }
      if (Level == 46) { return 277; }
      if (Level == 47) { return 293; }
      if (Level == 48) { return 309; }
      if (Level == 49) { return 325; }
      if (Level == 50) { return 341; }
      if (Level == 51) { return 357; }
      if (Level == 52) { return 376; }
      if (Level == 53) { return 395; }
      if (Level == 54) { return 414; }
      if (Level == 55) { return 433; }
      if (Level == 56) { return 452; }
      if (Level == 57) { return 474; }
      if (Level == 58) { return 496; }
      if (Level == 59) { return 518; }
      if (Level == 60) { return 540; }
      if (Level == 61) { return 562; }
      if (Level == 62) { return 587; }
      if (Level == 63) { return 612; }
      if (Level == 64) { return 637; }
      if (Level == 65) { return 662; }
      if (Level == 66) { return 687; }
      if (Level == 67) { return 716; }
      if (Level == 68) { return 745; }
      if (Level == 69) { return 774; }
      if (Level == 70) { return 803; }
    }
    return 5; // 意味はないが5としておく。
  }

  public int LevelupBaseManaPoint()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (Level == 2) { return 5; }
      if (Level == 3) { return 5; }
      if (Level == 4) { return 5; }
      if (Level == 5) { return 5; }
      if (Level == 6) { return 6; }
      if (Level == 7) { return 6; }
      if (Level == 8) { return 6; }
      if (Level == 9) { return 6; }
      if (Level == 10) { return 6; }
      if (Level == 11) { return 7; }
      if (Level == 12) { return 7; }
      if (Level == 13) { return 7; }
      if (Level == 14) { return 7; }
      if (Level == 15) { return 7; }
      if (Level == 16) { return 9; }
      if (Level == 17) { return 9; }
      if (Level == 18) { return 9; }
      if (Level == 19) { return 9; }
      if (Level == 20) { return 9; }
      if (Level == 21) { return 11; }
      if (Level == 22) { return 11; }
      if (Level == 23) { return 11; }
      if (Level == 24) { return 11; }
      if (Level == 25) { return 11; }
      if (Level == 26) { return 14; }
      if (Level == 27) { return 14; }
      if (Level == 28) { return 14; }
      if (Level == 29) { return 14; }
      if (Level == 30) { return 14; }
      if (Level == 31) { return 17; }
      if (Level == 32) { return 17; }
      if (Level == 33) { return 17; }
      if (Level == 34) { return 17; }
      if (Level == 35) { return 17; }
      if (Level == 36) { return 22; }
      if (Level == 37) { return 22; }
      if (Level == 38) { return 22; }
      if (Level == 39) { return 22; }
      if (Level == 40) { return 22; }
      if (Level == 41) { return 27; }
      if (Level == 42) { return 27; }
      if (Level == 43) { return 27; }
      if (Level == 44) { return 27; }
      if (Level == 45) { return 27; }
      if (Level == 46) { return 35; }
      if (Level == 47) { return 35; }
      if (Level == 48) { return 35; }
      if (Level == 49) { return 35; }
      if (Level == 50) { return 35; }
      if (Level == 51) { return 43; }
      if (Level == 52) { return 43; }
      if (Level == 53) { return 43; }
      if (Level == 54) { return 43; }
      if (Level == 55) { return 43; }
      if (Level == 56) { return 56; }
      if (Level == 57) { return 56; }
      if (Level == 58) { return 56; }
      if (Level == 59) { return 56; }
      if (Level == 60) { return 56; }
      if (Level == 61) { return 69; }
      if (Level == 62) { return 69; }
      if (Level == 63) { return 69; }
      if (Level == 64) { return 69; }
      if (Level == 65) { return 69; }
      if (Level == 66) { return 90; }
      if (Level == 67) { return 90; }
      if (Level == 68) { return 90; }
      if (Level == 69) { return 90; }
      if (Level == 70) { return 90; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (Level == 2) { return 7; }
      if (Level == 3) { return 7; }
      if (Level == 4) { return 7; }
      if (Level == 5) { return 7; }
      if (Level == 6) { return 8; }
      if (Level == 7) { return 8; }
      if (Level == 8) { return 8; }
      if (Level == 9) { return 8; }
      if (Level == 10) { return 8; }
      if (Level == 11) { return 10; }
      if (Level == 12) { return 10; }
      if (Level == 13) { return 10; }
      if (Level == 14) { return 10; }
      if (Level == 15) { return 10; }
      if (Level == 16) { return 13; }
      if (Level == 17) { return 13; }
      if (Level == 18) { return 13; }
      if (Level == 19) { return 13; }
      if (Level == 20) { return 13; }
      if (Level == 21) { return 17; }
      if (Level == 22) { return 17; }
      if (Level == 23) { return 17; }
      if (Level == 24) { return 17; }
      if (Level == 25) { return 17; }
      if (Level == 26) { return 22; }
      if (Level == 27) { return 22; }
      if (Level == 28) { return 22; }
      if (Level == 29) { return 22; }
      if (Level == 30) { return 22; }
      if (Level == 31) { return 28; }
      if (Level == 32) { return 28; }
      if (Level == 33) { return 28; }
      if (Level == 34) { return 28; }
      if (Level == 35) { return 28; }
      if (Level == 36) { return 35; }
      if (Level == 37) { return 35; }
      if (Level == 38) { return 35; }
      if (Level == 39) { return 35; }
      if (Level == 40) { return 35; }
      if (Level == 41) { return 43; }
      if (Level == 42) { return 43; }
      if (Level == 43) { return 43; }
      if (Level == 44) { return 43; }
      if (Level == 45) { return 43; }
      if (Level == 46) { return 52; }
      if (Level == 47) { return 52; }
      if (Level == 48) { return 52; }
      if (Level == 49) { return 52; }
      if (Level == 50) { return 52; }
      if (Level == 51) { return 62; }
      if (Level == 52) { return 62; }
      if (Level == 53) { return 62; }
      if (Level == 54) { return 62; }
      if (Level == 55) { return 62; }
      if (Level == 56) { return 73; }
      if (Level == 57) { return 73; }
      if (Level == 58) { return 73; }
      if (Level == 59) { return 73; }
      if (Level == 60) { return 73; }
      if (Level == 61) { return 85; }
      if (Level == 62) { return 85; }
      if (Level == 63) { return 85; }
      if (Level == 64) { return 85; }
      if (Level == 65) { return 85; }
      if (Level == 66) { return 98; }
      if (Level == 67) { return 98; }
      if (Level == 68) { return 98; }
      if (Level == 69) { return 98; }
      if (Level == 70) { return 98; }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (Level == 2) { return 9; }
      if (Level == 3) { return 9; }
      if (Level == 4) { return 9; }
      if (Level == 5) { return 9; }
      if (Level == 6) { return 10; }
      if (Level == 7) { return 10; }
      if (Level == 8) { return 10; }
      if (Level == 9) { return 10; }
      if (Level == 10) { return 10; }
      if (Level == 11) { return 12; }
      if (Level == 12) { return 12; }
      if (Level == 13) { return 12; }
      if (Level == 14) { return 12; }
      if (Level == 15) { return 12; }
      if (Level == 16) { return 16; }
      if (Level == 17) { return 16; }
      if (Level == 18) { return 16; }
      if (Level == 19) { return 16; }
      if (Level == 20) { return 16; }
      if (Level == 21) { return 22; }
      if (Level == 22) { return 22; }
      if (Level == 23) { return 22; }
      if (Level == 24) { return 22; }
      if (Level == 25) { return 22; }
      if (Level == 26) { return 30; }
      if (Level == 27) { return 30; }
      if (Level == 28) { return 30; }
      if (Level == 29) { return 30; }
      if (Level == 30) { return 30; }
      if (Level == 31) { return 40; }
      if (Level == 32) { return 40; }
      if (Level == 33) { return 40; }
      if (Level == 34) { return 40; }
      if (Level == 35) { return 40; }
      if (Level == 36) { return 52; }
      if (Level == 37) { return 52; }
      if (Level == 38) { return 52; }
      if (Level == 39) { return 52; }
      if (Level == 40) { return 52; }
      if (Level == 41) { return 66; }
      if (Level == 42) { return 66; }
      if (Level == 43) { return 66; }
      if (Level == 44) { return 66; }
      if (Level == 45) { return 66; }
      if (Level == 46) { return 82; }
      if (Level == 47) { return 82; }
      if (Level == 48) { return 82; }
      if (Level == 49) { return 82; }
      if (Level == 50) { return 82; }
      if (Level == 51) { return 100; }
      if (Level == 52) { return 100; }
      if (Level == 53) { return 100; }
      if (Level == 54) { return 100; }
      if (Level == 55) { return 100; }
      if (Level == 56) { return 120; }
      if (Level == 57) { return 120; }
      if (Level == 58) { return 120; }
      if (Level == 59) { return 120; }
      if (Level == 60) { return 120; }
      if (Level == 61) { return 142; }
      if (Level == 62) { return 142; }
      if (Level == 63) { return 142; }
      if (Level == 64) { return 142; }
      if (Level == 65) { return 142; }
      if (Level == 66) { return 166; }
      if (Level == 67) { return 166; }
      if (Level == 68) { return 166; }
      if (Level == 69) { return 166; }
      if (Level == 70) { return 166; }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (Level == 2) { return 3; }
      if (Level == 3) { return 3; }
      if (Level == 4) { return 3; }
      if (Level == 5) { return 3; }
      if (Level == 6) { return 4; }
      if (Level == 7) { return 4; }
      if (Level == 8) { return 4; }
      if (Level == 9) { return 4; }
      if (Level == 10) { return 4; }
      if (Level == 11) { return 5; }
      if (Level == 12) { return 5; }
      if (Level == 13) { return 5; }
      if (Level == 14) { return 5; }
      if (Level == 15) { return 5; }
      if (Level == 16) { return 7; }
      if (Level == 17) { return 7; }
      if (Level == 18) { return 7; }
      if (Level == 19) { return 7; }
      if (Level == 20) { return 7; }
      if (Level == 21) { return 9; }
      if (Level == 22) { return 9; }
      if (Level == 23) { return 9; }
      if (Level == 24) { return 9; }
      if (Level == 25) { return 9; }
      if (Level == 26) { return 12; }
      if (Level == 27) { return 12; }
      if (Level == 28) { return 12; }
      if (Level == 29) { return 12; }
      if (Level == 30) { return 12; }
      if (Level == 31) { return 15; }
      if (Level == 32) { return 15; }
      if (Level == 33) { return 15; }
      if (Level == 34) { return 15; }
      if (Level == 35) { return 15; }
      if (Level == 36) { return 19; }
      if (Level == 37) { return 19; }
      if (Level == 38) { return 19; }
      if (Level == 39) { return 19; }
      if (Level == 40) { return 19; }
      if (Level == 41) { return 23; }
      if (Level == 42) { return 23; }
      if (Level == 43) { return 23; }
      if (Level == 44) { return 23; }
      if (Level == 45) { return 23; }
      if (Level == 46) { return 28; }
      if (Level == 47) { return 28; }
      if (Level == 48) { return 28; }
      if (Level == 49) { return 28; }
      if (Level == 50) { return 28; }
      if (Level == 51) { return 33; }
      if (Level == 52) { return 33; }
      if (Level == 53) { return 33; }
      if (Level == 54) { return 33; }
      if (Level == 55) { return 33; }
      if (Level == 56) { return 39; }
      if (Level == 57) { return 39; }
      if (Level == 58) { return 39; }
      if (Level == 59) { return 39; }
      if (Level == 60) { return 39; }
      if (Level == 61) { return 45; }
      if (Level == 62) { return 45; }
      if (Level == 63) { return 45; }
      if (Level == 64) { return 45; }
      if (Level == 65) { return 45; }
      if (Level == 66) { return 52; }
      if (Level == 67) { return 52; }
      if (Level == 68) { return 52; }
      if (Level == 69) { return 52; }
      if (Level == 70) { return 52; }
    }
    if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
    {
      if (Level == 2) { return 10; }
      if (Level == 3) { return 10; }
      if (Level == 4) { return 10; }
      if (Level == 5) { return 10; }
      if (Level == 6) { return 11; }
      if (Level == 7) { return 11; }
      if (Level == 8) { return 11; }
      if (Level == 9) { return 11; }
      if (Level == 10) { return 11; }
      if (Level == 11) { return 12; }
      if (Level == 12) { return 12; }
      if (Level == 13) { return 12; }
      if (Level == 14) { return 12; }
      if (Level == 15) { return 12; }
      if (Level == 16) { return 13; }
      if (Level == 17) { return 13; }
      if (Level == 18) { return 13; }
      if (Level == 19) { return 13; }
      if (Level == 20) { return 13; }
      if (Level == 21) { return 15; }
      if (Level == 22) { return 15; }
      if (Level == 23) { return 15; }
      if (Level == 24) { return 15; }
      if (Level == 25) { return 15; }
      if (Level == 26) { return 18; }
      if (Level == 27) { return 18; }
      if (Level == 28) { return 18; }
      if (Level == 29) { return 18; }
      if (Level == 30) { return 18; }
      if (Level == 31) { return 23; }
      if (Level == 32) { return 23; }
      if (Level == 33) { return 23; }
      if (Level == 34) { return 23; }
      if (Level == 35) { return 23; }
      if (Level == 36) { return 31; }
      if (Level == 37) { return 31; }
      if (Level == 38) { return 31; }
      if (Level == 39) { return 31; }
      if (Level == 40) { return 31; }
      if (Level == 41) { return 44; }
      if (Level == 42) { return 44; }
      if (Level == 43) { return 44; }
      if (Level == 44) { return 44; }
      if (Level == 45) { return 44; }
      if (Level == 46) { return 65; }
      if (Level == 47) { return 65; }
      if (Level == 48) { return 65; }
      if (Level == 49) { return 65; }
      if (Level == 50) { return 65; }
      if (Level == 51) { return 99; }
      if (Level == 52) { return 99; }
      if (Level == 53) { return 99; }
      if (Level == 54) { return 99; }
      if (Level == 55) { return 99; }
      if (Level == 56) { return 154; }
      if (Level == 57) { return 154; }
      if (Level == 58) { return 154; }
      if (Level == 59) { return 154; }
      if (Level == 60) { return 154; }
      if (Level == 61) { return 243; }
      if (Level == 62) { return 243; }
      if (Level == 63) { return 243; }
      if (Level == 64) { return 243; }
      if (Level == 65) { return 243; }
      if (Level == 66) { return 387; }
      if (Level == 67) { return 387; }
      if (Level == 68) { return 387; }
      if (Level == 69) { return 387; }
      if (Level == 70) { return 387; }
    }
    return 2; // 意味はないが2としておく。
  }

  public int LevelupBaseSkillPoint()
  {
    return 0; // ベーススキルポイントは原則、追加されない。
  }

  public int LevelupRemainPoint()
  {
    if (Level <= 5) { return 3; }
    if (Level <= 10) { return 4; }
    if (Level <= 15) { return 5; }
    if (Level <= 20) { return 6; }
    if (Level <= 25) { return 7; }
    if (Level <= 30) { return 8; }
    if (Level <= 35) { return 9; }
    if (Level <= 40) { return 10; }
    if (Level <= 45) { return 11; }
    if (Level <= 50) { return 12; }
    if (Level <= 55) { return 13; }
    if (Level <= 60) { return 14; }
    if (Level <= 65) { return 15; }
    if (Level <= 70) { return 16; }
    else
    {
      return 3;
    }
  }

  public int LevelupSoulEssence()
  {
    if (this.Level >= 11) // 色々考えられるが、単純にLV11から
    {
      return 1;
    }
    return 0;
  }

  public bool CheckLevelupGain(int exp_plus)
  {
    if (this.Exp + exp_plus >= this.GetNextExp())
    {
      return true;
    }

    return false;
  }

  public void UpdateLevelup(ref string new_command, bool first, bool second, bool third, bool fourth)
  {
    this.Level += 1;

    this.BaseLife += this.LevelupBaseLife();
    this.BaseManaPoint += this.LevelupBaseManaPoint();
    this.BaseSkillPoint += this.LevelupBaseSkillPoint();
    this.RemainPoint += this.LevelupRemainPoint();
    this.SoulFragment += this.LevelupSoulEssence();

    // エッセンスツリー更新
    new_command = String.Empty;
    if (true) { LevelUpEssenceTree(1, ref new_command); } // 無条件
    if (true) { LevelUpEssenceTree(2, ref new_command); } // 無条件
    if (first) { LevelUpEssenceTree(3, ref new_command); }
    if (second) { LevelUpEssenceTree(4, ref new_command); }
    if (third) { LevelUpEssenceTree(5, ref new_command); }
    if (fourth) { LevelUpEssenceTree(6, ref new_command); }

    // アクションコマンドのスロット空きがあれば、新しく習得したアクションコマンドを設定する。
    if (new_command != String.Empty)
    {
      ApplyNewCommand(new_command);
    }
  }

  private void ApplyNewCommand(string command_name)
  {
    for (int ii = 0; ii < Fix.MAX_INSTANT_NUM; ii++)
    {
      bool result = CheckToApply(ii, command_name);
      if (result) { break; }
    }
  }


  public bool CheckToApply(int ii, string command_name)
  {
    if (ii == 0 && this.ActionCommand1 == string.Empty || this.ActionCommand1 == Fix.STAY)
    {
      this.ActionCommand1 = command_name; return true;
    }
    if (ii == 1 && this.ActionCommand2 == string.Empty || this.ActionCommand2 == Fix.STAY)
    {
      this.ActionCommand2 = command_name; return true;
    }
    if (ii == 2 && this.ActionCommand3 == string.Empty || this.ActionCommand3 == Fix.STAY)
    {
      this.ActionCommand3 = command_name; return true;
    }
    if (ii == 3 && this.ActionCommand4 == string.Empty || this.ActionCommand4 == Fix.STAY)
    {
      this.ActionCommand4 = command_name; return true;
    }
    if (ii == 4 && this.ActionCommand5 == string.Empty || this.ActionCommand5 == Fix.STAY)
    {
      this.ActionCommand5 = command_name; return true;
    }
    if (ii == 5 && this.ActionCommand6 == string.Empty || this.ActionCommand6 == Fix.STAY)
    {
      this.ActionCommand6 = command_name; return true;
    }
    if (ii == 6 && this.ActionCommand7 == string.Empty || this.ActionCommand7 == Fix.STAY)
    {
      this.ActionCommand7 = command_name; return true;
    }
    if (ii == 7 && this.ActionCommand8 == string.Empty || this.ActionCommand8 == Fix.STAY)
    {
      this.ActionCommand8 = command_name; return true;
    }
    if (ii == 8 && this.ActionCommand9 == string.Empty || this.ActionCommand9 == Fix.STAY)
    {
      this.ActionCommand9 = command_name; return true;
    }

    return false;
  }

  public string CharacterMessage(int num)
  {
    string result = string.Empty;
    switch (num)
    {
      case 1000:
        if (this.FullName == Fix.NAME_EIN_WOLENCE) { result = "アイン：敵と遭遇だ！"; }
        else if (this.FullName == Fix.NAME_LANA_AMIRIA) { result = "ラナ：：敵が来たわね、行くわよ。"; }
        else if (this.FullName == Fix.NAME_EONE_FULNEA) { result = "エオネ：・・・敵です。準備を。"; }
        else if (this.FullName == Fix.NAME_BILLY_RAKI) { result = "ビリー：敵襲だ！"; }
        break;

      case 1001:
        if (this.FullName == Fix.NAME_EIN_WOLENCE) { result = "アイン：いや、これは敵向けのコマンドだ。味方には向けられないな。"; }
        else if (this.FullName == Fix.NAME_LANA_AMIRIA) { result = "ラナ：：これは敵専用コマンドでしょ。味方に向けられるわけないじゃない。"; }
        else if (this.FullName == Fix.NAME_EONE_FULNEA) { result = "エオネ：このコマンドは敵向けです。味方には向けられません。"; }
        else if (this.FullName == Fix.NAME_BILLY_RAKI) { result = "ビリー：やっべ、間違えて味方に向けそうだったぜ。"; }
        break;
      case 1002:
        if (this.FullName == Fix.NAME_EIN_WOLENCE) { result = "アイン：いや、これは味方向けのコマンドだ。敵には向けられないな。"; }
        else if (this.FullName == Fix.NAME_LANA_AMIRIA) { result = "ラナ：：これは味方専用コマンドでしょ。敵に向けられるわけないじゃない。"; }
        else if (this.FullName == Fix.NAME_EONE_FULNEA) { result = "エオネ：いえ、このコマンドは味方向けです。敵には向けられません。"; }
        else if (this.FullName == Fix.NAME_BILLY_RAKI) { result = "ビリー：やっべ、間違えて敵に向けそうだったぜ。"; }
        break;
      case 1003:
        if (this.FullName == Fix.NAME_EIN_WOLENCE) { result = "アイン：しまった。インスタントが足りねえ。"; }
        else if (this.FullName == Fix.NAME_LANA_AMIRIA) { result = "ラナ：：インスタントが足りないわよ。"; }
        else if (this.FullName == Fix.NAME_EONE_FULNEA) { result = "エオネ：インスタントが足りませんね。"; }
        else if (this.FullName == Fix.NAME_BILLY_RAKI) { result = "ビリー：インスタント足りねー！"; }
        break;
    }

    return result;
  }
  #endregion

  #region "Monster Data"
  public string[] DropItem { get; set; }

  public static int MAX_DROPITEM_SIZE = 10;

  public bool AddDropItem(string dropitem)
  {
    for (int ii = 0; ii < MAX_DROPITEM_SIZE; ii++)
    {
      if (this.DropItem[ii] == string.Empty)
      {
        this.DropItem[ii] = dropitem;
        return true;
      }
    }
    return false;
  }

  public void Construction(string character_name)
  {
    this.name = character_name;
    this.FullName = character_name;
    this.BattleBackColor = Fix.COLOR_ENEMY_CHARA;
    this.BattleForeColor = Fix.COLORFORE_ENEMY_CHARA;

    this.DropItem = new String[MAX_DROPITEM_SIZE];
    for (int ii = 0; ii < MAX_DROPITEM_SIZE; ii++)
    {
      this.DropItem[ii] = String.Empty;
    }

    List<string> list = new List<string>();
    switch (character_name)
    {
      #region "エスミリア草原区域"
      case Fix.TINY_MANTIS:
      case Fix.TINY_MANTIS_JP:
        SetupParameter(15, 2, 1, 2, 3, 4, 16, 12);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HIKKAKI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area11;
        this.CannotCritical = true;
        break;

      case Fix.GREEN_SLIME:
      case Fix.GREEN_SLIME_JP:
        SetupParameter(2, 2, 15, 2, 3, 8, 19, 14);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_GREEN_NENEKI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area11;
        this.CannotCritical = true;
        break;

      case Fix.MANDRAGORA:
      case Fix.MANDRAGORA_JP:
        SetupParameter(2, 4, 18, 3, 3, 5, 21, 17);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_KANAKIRI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area11;
        this.CannotCritical = true;
        break;

      case Fix.YOUNG_WOLF:
      case Fix.YOUNG_WOLF_JP:
        SetupParameter(17, 5, 2, 4, 3, 7, 23, 19);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_WILD_CLAW);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area11;
        this.CannotCritical = true;
        break;

      case Fix.WILD_ANT:
      case Fix.WILD_ANT_JP:
        SetupParameter(19, 4, 2, 6, 3, 2, 26, 22);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_KAMITSUKI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area12;
        this.CannotCritical = true;
        break;

      case Fix.OLD_TREEFORK:
      case Fix.OLD_TREEFORK_JP:
        SetupParameter(2, 4, 20, 7, 4, 4, 28, 24);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_TREE_SONG);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area12;
        this.CannotCritical = true;
        break;

      case Fix.SUN_FLOWER:
      case Fix.SUN_FLOWER_JP:
        SetupParameter(2, 6, 25, 4, 4, 3, 32, 28);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SUN_FIRE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area12;
        this.CannotCritical = true;
        break;

      case Fix.SOLID_BEETLE:
      case Fix.SOLID_BEETLE_JP:
        SetupParameter(28, 6, 2, 9, 4, 6, 35, 29);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_TOSSHIN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area12;
        this.CannotCritical = true;
        break;

      case Fix.SILENT_LADYBUG:
      case Fix.SILENT_LADYBUG_JP:
        SetupParameter(2, 7, 27, 7, 4, 5, 37, 32);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_FEATHER_WING);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area12;
        this.CannotCritical = true;
        break;

      case Fix.NIMBLE_RABBIT:
      case Fix.NIMBLE_RABBIT_JP:
        SetupParameter(26, 9, 20, 8, 4, 1, 39, 34);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_DASH_KERI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area12;
        this.CannotCritical = true;
        break;

      case Fix.ENTANGLED_VINE:
      case Fix.ENTANGLED_VINE_JP:
        SetupParameter(37, 11, 15, 16, 5, 3, 42, 36);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SUITSUKU_TSUTA);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area13;
        this.CannotCritical = true;
        break;

      case Fix.CREEPING_SPIDER:
      case Fix.CREEPING_SPIDER_JP:
        SetupParameter(34, 12, 27, 14, 5, 8, 44, 39);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SPIDER_NET);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area13;
        this.CannotCritical = true;
        break;

      case Fix.BLOOD_MOSS:
      case Fix.BLOOD_MOSS_JP:
        SetupParameter(12, 10, 39, 12, 5, 5, 48, 42);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_POISON_KOKE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area13;
        this.CannotCritical = true;
        break;

      case Fix.KILLER_BEE:
      case Fix.KILLER_BEE_JP:
        SetupParameter(33, 18, 25, 12, 5, 9, 51, 45);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CONTINUOUS_ATTACK);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area13;
        // this.CannotCritical = true; // クリティカルあり
        break;

      case Fix.WONDER_SEED:
      case Fix.WONDER_SEED_JP:
        SetupParameter(26, 12, 37, 15, 5, 2, 54, 47);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_FIRE_EMISSION);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area13;
        this.CannotCritical = true;
        break;

      case Fix.DAUNTLESS_HORSE:
      case Fix.DAUNTLESS_HORSE_JP:
        SetupParameter(40, 15, 10, 20, 5, 1, 58, 52);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SUPER_TOSSHIN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area13;
        this.CannotCritical = true;
        break;

      case Fix.SCREAMING_RAFFLESIA:
        SetupParameter(55, 20, 55, 150, 8, 0, 1000, 2000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_YOUEN_FIRE);
        list.Add(Fix.COMMAND_BLAZE_DANCE);
        list.Add(Fix.COMMAND_POISON_RINPUN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss1;
        this.CannotCritical = false;
        break;
      #endregion

      #region "ゴラトラム洞窟"
      case Fix.DEBRIS_SOLDIER:
      case Fix.DEBRIS_SOLDIER_JP:
        SetupParameter(45, 12, 20, 25, 7, 5, 112, 65);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_GAREKI_TSUBUTE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area21;
        this.CannotCritical = true;
        break;

      case Fix.MAGICAL_AUTOMATA:
      case Fix.MAGICAL_AUTOMATA_JP:
        SetupParameter(15, 13, 48, 21, 7, 8, 126, 72);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SHADOW_SPEAR);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area21;
        this.CannotCritical = true;
        break;

      case Fix.KILLER_MACHINE:
      case Fix.KILLER_MACHINE_JP:
        SetupParameter(49, 15, 16, 23, 7, 4, 137, 76);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_MIDARE_GIRI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area21;
        this.CannotCritical = true;
        break;

      case Fix.STINKY_BAT:
      case Fix.STINKY_BAT_JP:
        SetupParameter(47, 16, 23, 20, 7, 7, 140, 78);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_STINKY_BREATH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area21;
        this.CannotCritical = true;
        break;

      case Fix.ANTIQUE_MIRROR:
      case Fix.ANTIQUE_MIRROR_JP:
        SetupParameter(22, 14, 52, 24, 7, 6, 145, 81);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_MIRROR_SHIELD);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area21;
        this.CannotCritical = true;
        break;

      case Fix.MECH_HAND:
      case Fix.MECH_HAND_JP:
        SetupParameter(54, 17, 29, 38, 7, 6, 145, 86);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HAND_CANNON);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area22;
        this.CannotCritical = true;
        break;

      case Fix.ABSENCE_MOAI:
      case Fix.ABSENCE_MOAI_JP:
        SetupParameter(55, 13, 55, 50, 7, 2, 163, 99);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SAIMIN_DANCE);
        list.Add(Fix.COMMAND_TOSSHIN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area22;
        this.CannotCritical = true;
        break;

      case Fix.ACID_SCORPION:
      case Fix.ACID_SCORPION_JP:
        SetupParameter(62, 20, 14, 43, 7, 3, 169, 101);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_POISON_NEEDLE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area22;
        this.CannotCritical = true;
        break;

      case Fix.NEJIMAKI_KNIGHT:
      case Fix.NEJIMAKI_KNIGHT_JP:
        SetupParameter(59, 21, 28, 43, 7, 5, 174, 104);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CHARGE_LANCE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area22;
        this.CannotCritical = true;
        break;

      case Fix.AIMING_SHOOTER:
      case Fix.AIMING_SHOOTER_JP:
        SetupParameter(67, 22, 25, 46, 7, 9, 178, 108);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SPIKE_SHOT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area22;
        this.TargetSelectType = Fix.TargetSelectType.Behind;
        //this.CannotCritical = true; // クリティカルあり
        break;

      case Fix.CULT_BLACK_MAGICIAN:
      case Fix.CULT_BLACK_MAGICIAN_JP:
        SetupParameter(33, 20, 62, 45, 7, 3, 181, 111);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_JUBAKU_ON);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area22;
        this.CannotCritical = true;
        break;

      case Fix.STONE_GOLEM:
      case Fix.STONE_GOLEM_JP:
        SetupParameter(78, 24, 30, 56, 8, 1, 186, 112);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_ZINARI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area23;
        this.CannotCritical = true;
        break;

      case Fix.JUNK_VULKAN:
      case Fix.JUNK_VULKAN_JP:
        SetupParameter(75, 28, 42, 50, 8, 8, 196, 117);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BOUHATSU);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area23;
        this.CannotCritical = true;
        break;

      case Fix.LIGHTNING_CLOUD:
      case Fix.LIGHTNING_CLOUD_JP:
        SetupParameter(30, 25, 75, 52, 8, 5, 201, 123);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_THUNDER_CLOUD);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area23;
        this.CannotCritical = true;
        break;

      case Fix.SILENT_GARGOYLE:
      case Fix.SILENT_GARGOYLE_JP:
        SetupParameter(75, 30, 55, 48, 8, 6, 205, 131);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SURUDOI_HIKKAKI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area23;
        this.CannotCritical = true;
        break;

      case Fix.GATE_HOUND:
      case Fix.GATE_HOUND_JP:
        SetupParameter(66, 29, 15, 53, 8, 4, 207, 135);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HAGESHII_KAMITSUKI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area23;
        this.CannotCritical = true;
        break;

      case Fix.PLAY_FIRE_IMP:
      case Fix.PLAY_FIRE_IMP_JP:
        SetupParameter(32, 27, 72, 49, 8, 7, 208, 137);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_BOLT_FRAME);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area23;
        this.CannotCritical = true;
        break;

      case Fix.WALKING_TIME_BOMB:
      case Fix.WALKING_TIME_BOMB_JP:
        SetupParameter(70, 31, 70, 55, 8, 5, 215, 139);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BOOOOMB);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area24;
        this.CannotCritical = true;
        break;

      case Fix.EARTH_ELEMENTAL:
      case Fix.EARTH_ELEMENTAL_JP:
        SetupParameter(55, 32, 82, 60, 8, 3, 217, 144);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_STONE_RAIN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area24;
        this.CannotCritical = true;
        break;

      case Fix.DEATH_DRONE:
      case Fix.DEATH_DRONE_JP:
        SetupParameter(81, 36, 32, 58, 8, 1, 220, 150);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_TARGETTING_SHOT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area24;
        // this.CannotCritical = true; // クリティカルあり
        break;

      case Fix.ASSULT_SCARECROW:
      case Fix.ASSULT_SCARECROW_JP:
        SetupParameter(86, 34, 37, 61, 8, 5, 224, 153);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_POWERED_ATTACK);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area24;
        this.CannotCritical = true;
        break;

      case Fix.MAD_DOCTOR:
      case Fix.MAD_DOCTOR_JP:
        SetupParameter(35, 35, 80, 63, 8, 2, 229, 158);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SUSPICIOUS_VIAL);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area24;
        this.CannotCritical = true;
        break;

      case Fix.MAGICAL_HAIL_GUN:
      case Fix.MAGICAL_HAIL_GUN_JP:
        SetupParameter(90, 55, 90, 760, 15, 0, 7000, 5000);
        this._baseInstantPoint = 3500;
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SPAAAARK);
        list.Add(Fix.COMMAND_SUPER_RANDOM_CANNON);
        list.Add(Fix.COMMAND_ELECTRO_RAILGUN);
        list.Add(Fix.COMMAND_BEHIND_BOMB);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss2;
        this.CannotCritical = false;
        break;
      #endregion

      #region "神秘の森"
      case Fix.CHARGED_BOAR:
      case Fix.CHARGED_BOAR_JP:
        SetupParameter(106, 50, 30, 115, 10, 8, 460, 280);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SUPER_TOSSHIN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area31;
        this.CannotCritical = true;
        break;

      case Fix.WOOD_ELF:
      case Fix.WOOD_ELF_JP:
        SetupParameter(95, 55, 102, 108, 10, 4, 476, 288);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_WILD_STORM);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area31;
        this.CannotCritical = true;
        break;

      case Fix.STINKED_SPORE:
      case Fix.STINKED_SPORE_JP:
        SetupParameter(65, 47, 98, 120, 10, 3, 491, 296);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_YOUKAIEKI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area31;
        this.CannotCritical = true;
        this.TargetSelectType = Fix.TargetSelectType.Behind;
        break;

      case Fix.POISON_FLOG:
      case Fix.POISON_FLOG_JP:
        SetupParameter(101, 53, 71, 112, 10, 9, 512, 302);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_POISON_TONGUE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area31;
        this.CannotCritical = true;
        break;

      case Fix.GIANT_SNAKE:
      case Fix.GIANT_SNAKE_JP:
        SetupParameter(109, 52, 68, 117, 10, 1, 527, 313);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CONSTRICT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area31;
        this.CannotCritical = true;
        break;

      case Fix.SAVAGE_BEAR:
      case Fix.SAVAGE_BEAR_JP:
        SetupParameter(140, 65, 77, 193, 14, 6, 685, 412);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_TAIATARI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area32;
        this.CannotCritical = true;
        break;

      case Fix.INNOCENT_FAIRY:
      case Fix.INNOCENT_FAIRY_JP:
        SetupParameter(79, 70, 145, 160, 14, 7, 702, 427);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_WINDFLARE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area32;
        this.CannotCritical = true;
        break;

      case Fix.SPEEDY_FALCON:
      case Fix.SPEEDY_FALCON_JP:
        SetupParameter(132, 76, 105, 182, 14, 9, 716, 438);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CONTINUOUS_ATTACK);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area32;
        // this.CannotCritical = true; // クリティカルあり
        break;

      case Fix.MYSTIC_DRYAD:
      case Fix.MYSTIC_DRYAD_JP:
        SetupParameter(90, 72, 151, 190, 14, 4, 727, 450);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_EARTHBOLT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area32;
        this.CannotCritical = true;
        break;

      case Fix.WOLF_HUNTER:
      case Fix.WOLF_HUNTER_JP:
        SetupParameter(143, 78, 110, 206, 14, 1, 740, 466);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SILENT_SHOT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area32;
        this.CannotCritical = true;
        break;

      case Fix.FOREST_PHANTOM:
      case Fix.FOREST_PHANTOM_JP:
        SetupParameter(120, 80, 155, 211, 14, 6, 772, 481);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_PHANTOM_SONG);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area32;
        this.CannotCritical = true;
        break;

      case Fix.EXCITED_ELEPHANT:
      case Fix.EXCITED_ELEPHANT_JP:
        SetupParameter(165, 86, 122, 277, 17, 8, 788, 516);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_ENRAGE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area33;
        this.CannotCritical = true;
        break;

      case Fix.SYLPH_DANCER:
      case Fix.SYLPH_DANCER_JP:
        SetupParameter(126, 90, 169, 262, 17, 2, 792, 530);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SPLASH_HARMONY);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area33;
        this.CannotCritical = true;
        break;

      case Fix.GATHERING_LAPTOR:
      case Fix.GATHERING_LAPTOR_JP:
        SetupParameter(172, 88, 134, 278, 17, 5, 804, 543);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_RANBOU_CHARGE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area33;
        this.CannotCritical = true;
        break;

      case Fix.RAGE_TIGER:
      case Fix.RAGE_TIGER_JP:
        SetupParameter(181, 92, 140, 269, 17, 7, 821, 561);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BEAST_STRIKE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area33;
        // this.CannotCritical = true; // クリティカルあり
        break;

      case Fix.THORN_WARRIOR:
      case Fix.THORN_WARRIOR_JP:
        SetupParameter(177, 87, 141, 269, 17, 2, 839, 575);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_KONSHIN_TOKKAN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area33;
        this.CannotCritical = true;
        break;

      case Fix.MUDDLED_PLANT:
      case Fix.MUDDLED_PLANT_JP:
        SetupParameter(155, 84, 177, 285, 17, 4, 853, 589);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_HUHAI_SINKOU);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area33;
        this.CannotCritical = true;
        break;

      case Fix.FLANSIS_KNIGHT:
      case Fix.FLANSIS_KNIGHT_JP:
        SetupParameter(196, 101, 142, 316, 20, 7, 910, 650);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_STRONG_SLASH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area34;
        this.CannotCritical = false;
        break;

      case Fix.MIST_PYTHON:
      case Fix.MIST_PYTHON_JP:
        SetupParameter(149, 106, 188, 305, 20, 1, 923, 667);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SHADOW_MIST);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area34;
        this.CannotCritical = true;
        break;

      case Fix.TOWERING_ENT:
      case Fix.TOWERING_ENT_JP:
        SetupParameter(186, 99, 147, 327, 20, 3, 940, 681);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_ROCK_THROW);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area34;
        this.CannotCritical = true;
        break;

      case Fix.POISON_MARY:
      case Fix.POISON_MARY_JP:
        SetupParameter(153, 104, 196, 312, 20, 6, 955, 699);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_YOUEN_KISS);
        list.Add(Fix.COMMAND_POISON_SPORE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area34;
        this.CannotCritical = true;
        break;

      case Fix.DISTURB_RHINO:
      case Fix.DISTURB_RHINO_JP:
        SetupParameter(206, 97, 133, 336, 20, 8, 988, 704);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_GROUND_RUMBLE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area34;
        this.CannotCritical = true;
        break;

      case Fix.FLANSIS_OF_THE_FOREST_QUEEN:
      case Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP:
        SetupParameter(450, 150, 500, 1600, 25, 0, 15000, 25000);
        this._baseInstantPoint = 5000;
        list.Add(Fix.COMMAND_FIRE_BLAST);
        list.Add(Fix.COMMAND_RENSOU_TOSSHIN);
        list.Add(Fix.COMMAND_VERDANT_VOICE);
        list.Add(Fix.COMMAND_BLACK_SPORE);
        // list.Add("キル・スピニングランサー"); // エリミネイトスキルなので設定しなくてよい。
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss3;
        this.CannotCritical = false;
        break;

      #endregion

      #region "オーランの塔"
      case Fix.WISDOM_CENTAURUS:
      case Fix.WISDOM_CENTAURUS_JP:
        SetupParameter(286, 135, 228, 542, 25, 2, 1957, 1423);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.WORD_OF_POWER);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area41;
        this.CannotCritical = true;
        break;

      case Fix.SWIFT_EAGLE:
      case Fix.SWIFT_EAGLE_JP:
        SetupParameter(250, 149, 207, 498, 25, 7, 2021, 1566);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_WING_BLADE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area41;
        this.CannotCritical = true;
        break;

      case Fix.EASTERN_GOLEM:
      case Fix.EASTERN_GOLEM_JP:
        SetupParameter(320, 120, 170, 580, 25, 5, 2208, 1629);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_STONE_BLAW);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area41;
        this.CannotCritical = true;
        break;

      case Fix.WESTERN_GOLEM:
      case Fix.WESTERN_GOLEM_JP:
        SetupParameter(320, 120, 170, 580, 25, 5, 2208, 1629);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HUMIOROSI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area41;
        this.CannotCritical = true;
        break;

      case Fix.WIND_ELEMENTAL:
      case Fix.WIND_ELEMENTAL_JP:
        SetupParameter(262, 143, 289, 564, 25, 3, 2384, 1742);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SQUALL_LIGHTNING);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area41;
        this.CannotCritical = true;
        break;

      case Fix.SKY_KNIGHT:
      case Fix.SKY_KNIGHT_JP:
        SetupParameter(388, 162, 245, 623, 30, 8, 2531, 1836);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SIPPUUKEN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area42;
        this.CannotCritical = true;
        break;

      case Fix.THE_PURPLE_HIKARIGOKE:
      case Fix.THE_PURPLE_HIKARIGOKE_JP:
        SetupParameter(299, 151, 382, 607, 30, 9, 2665, 1947);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_BRIGHTNESS_RINPUN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area42;
        this.CannotCritical = true;
        break;

      case Fix.MYSTICAL_UNICORN:
      case Fix.MYSTICAL_UNICORN_JP:
        SetupParameter(369, 170, 310, 631, 30, 4, 2853, 2051);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SHIROGANE_HORN);
        list.Add(Fix.COMMAND_TOSSHIN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area42;
        this.CannotCritical = true;
        break;

      case Fix.TRIAL_HERMIT:
      case Fix.TRIAL_HERMIT_JP:
        SetupParameter(324, 167, 398, 611, 30, 5, 3013, 2116);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_VISIBLE_EYE);
        list.Add(Fix.COMMAND_INVISIBLE_EYE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area42;
        this.CannotCritical = true;
        break;

      case Fix.STORM_BIRDMAN:
      case Fix.STORM_BIRDMAN_JP:
        SetupParameter(353, 189, 322, 623, 30, 1, 3164, 2231);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CONTINUOUS_ATTACK);
        list.Add(Fix.COMMAND_WIND_CUTTER);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area42;
        this.CannotCritical = false;
        break;

      case Fix.THE_BLUE_LAVA_EYE:
      case Fix.THE_BLUE_LAVA_EYE_JP:
        SetupParameter(318, 174, 407, 643, 30, 2, 3308, 2412);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_BLUE_LAVA);
        list.Add(Fix.COMMAND_BLUE_BUBBLE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area42;
        this.CannotCritical = false;
        break;

      case Fix.THE_WHITE_LAVA_EYE:
      case Fix.THE_WHITE_LAVA_EYE_JP:
        SetupParameter(318, 174, 407, 643, 30, 2, 3308, 2412);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_WHITE_LAVA);
        list.Add(Fix.COMMAND_WHITE_BUBBLE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area42;
        this.CannotCritical = false;
        break;

      case Fix.FLYING_CURTAIN:
      case Fix.FLYING_CURTAIN_JP:
        SetupParameter(333, 202, 451, 688, 35, 4, 3519, 2677);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_REFLECTION_SHADE);
        list.Add(Fix.COMMAND_ICHIMAI_GUARDWALL);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area43;
        this.CannotCritical = true;
        break;

      case Fix.LUMINOUS_HAWK:
      case Fix.LUMINOUS_HAWK_JP:
        SetupParameter(427, 228, 329, 705, 35, 8, 3665, 2879);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_MULTIPLE_FEATHER);
        list.Add(Fix.COMMAND_BRIGHT_FLASH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area43;
        this.CannotCritical = true;
        break;

      case Fix.AETHER_GUST:
      case Fix.AETHER_GUST_JP:
        SetupParameter(341, 219, 443, 711, 35, 7, 3784, 2992);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_CYCLONE_SHOT);
        list.Add(Fix.COMMAND_MORPH_VANISH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area43;
        this.CannotCritical = true;
        break;

      case Fix.WHIRLWIND_KITSUNE:
      case Fix.WHIRLWIND_KITSUNE_JP:
        SetupParameter(448, 224, 448, 733, 35, 9, 3911, 3046);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_ROD_AGARTHA);
        list.Add(Fix.COMMAND_SWORD_MAHOROBA);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area43;
        this.CannotCritical = false;
        break;

      case Fix.THUNDER_LION:
      case Fix.THUNDER_LION_JP:
        SetupParameter(457, 239, 432, 746, 35, 5, 4026, 3113);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_FEROCIOUS_THUNDER);
        list.Add(Fix.COMMAND_RAGING_CLAW);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area43;
        this.CannotCritical = true;
        break;

      case Fix.SAINT_PEGASUS:
      case Fix.SAINT_PEGASUS_JP:
        SetupParameter(387, 231, 451, 757, 35, 2, 4129, 3297);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_CLEANSING_LIGHT);
        list.Add(Fix.COMMAND_FAITH_SIGHT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area43;
        this.CannotCritical = true;
        break;

      case Fix.DREAM_WALKER:
      case Fix.DREAM_WALKER_JP:
        SetupParameter(456, 235, 395, 763, 35, 3, 4297, 3418);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SAMAYOU_HAND);
        list.Add(Fix.COMMAND_SEIIN_FOOTPRINT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area43;
        this.CannotCritical = true;
        break;

      case Fix.LIGHT_THUNDER_LANCEBOLTS:
      case Fix.LIGHT_THUNDER_LANCEBOLTS_JP:
      case Fix.LIGHT_THUNDER_LANCEBOLTS_JP_VIEW:
        SetupParameter(980, 280, 980, 4500, 50, 0, 25000, 30000);
        this._baseInstantPoint = 3000;
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_LIGHT_THUNDERBOLT);
        list.Add(Fix.COMMAND_CYCLONE_ARMOR);
        list.Add(Fix.COMMAND_FURY_TRIDENT);
        list.Add(Fix.COMMAND_HEAVEN_THUNDER_SPEAR);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss4;
        this.CannotCritical = false;
        break;

      case Fix.IVORY_STATUE:
      case Fix.IVORY_STATUE_JP:
        SetupParameter(546, 265, 411, 820, 40, 9, 4438, 3610);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_OVERRUN);
        list.Add(Fix.COMMAND_GLARE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area44;
        this.CannotCritical = true;
        break;

      case Fix.STUBBORN_SAGE:
      case Fix.STUBBORN_SAGE_JP:
        SetupParameter(433, 275, 557, 832, 40, 9, 4438, 3610);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_ARC_BLASTER);
        list.Add(Fix.COMMAND_DRAGON_BREATH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area44;
        this.CannotCritical = false;
        break;

      case Fix.BOMB_BALLON:
      case Fix.BOMB_BALLON_JP:
        SetupParameter(539, 281, 427, 816, 40, 3, 4818, 3889);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_RENZOKU_BAKUHATSU);
        list.Add(Fix.COMMAND_AIUCHI_NERAI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area44;
        this.CannotCritical = false;
        break;

      case Fix.OBSERVANT_HERALD:
      case Fix.OBSERVANT_HERALD_JP:
        SetupParameter(528, 298, 432, 824, 40, 6, 5066, 4022);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HIDDEN_KNIFE);
        list.Add(Fix.COMMAND_MYSTICAL_FIELD);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area44;
        this.CannotCritical = true;
        break;

      case Fix.TOWER_SCOUT:
      case Fix.TOWER_SCOUT_JP:
        SetupParameter(441, 286, 557, 836, 40, 2, 5284, 4146);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SEIKUU_GUARDWALL);
        list.Add(Fix.COMMAND_THUNDERCLOUD_INVASION);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area44;
        this.CannotCritical = true;
        break;

      case Fix.MIST_SALVAGER:
      case Fix.MIST_SALVAGER_JP:
        SetupParameter(453, 293, 564, 846, 40, 2, 5497, 4215);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_MIST_BARRIER);
        list.Add(Fix.COMMAND_SUN_SLAYER);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area44;
        this.CannotCritical = true;
        break;

      case Fix.WINGSPAN_RANGER:
      case Fix.WINGSPAN_RANGER_JP:
        SetupParameter(630, 329, 489, 927, 45, 4, 6218, 4467);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_TRIPLE_TACTICS);
        list.Add(Fix.COMMAND_WIND_ARROW);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area45;
        this.CannotCritical = false;
        break;

      case Fix.MAJESTIC_CLOUD:
      case Fix.MAJESTIC_CLOUD_JP:
        SetupParameter(497, 307, 641, 945, 45, 2, 6561, 4580);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_TYPHOON);
        list.Add(Fix.COMMAND_TAIKI_VANISH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area45;
        this.CannotCritical = true;
        break;

      case Fix.HARDENED_GRIFFIN:
      case Fix.HARDENED_GRIFFIN_JP:
        SetupParameter(646, 312, 470, 966, 45, 7, 6813, 4711);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HARD_CHARGE);
        list.Add(Fix.COMMAND_RAMPAGE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area45;
        this.CannotCritical = true;
        break;

      case Fix.PRISMA_SPHERE:
      case Fix.PRISMA_SPHERE_JP:
        SetupParameter(481, 317, 655, 973, 45, 5, 7019, 4853);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_ICE_BURN);
        list.Add(Fix.COMMAND_FROST_SHARD);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area45;
        this.CannotCritical = true;
        break;

      case Fix.MOVING_CANNON:
      case Fix.MOVING_CANNON_JP:
        SetupParameter(658, 319, 488, 981, 45, 6, 7267, 4979);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_DOKAAAAN);
        list.Add(Fix.COMMAND_RENSYA);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area45;
        this.CannotCritical = true;
        break;

      case Fix.VEIL_FORTUNE_WIZARD:
      case Fix.VEIL_FORTUNE_WIZARD_JP:
        SetupParameter(493, 315, 672, 998, 45, 9, 7493, 5111);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_ERRATIC_EXPLODE);
        list.Add(Fix.COMMAND_CYCLONE_FIELD);
        list.Add(Fix.COMMAND_ICE_RAY);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area45;
        this.CannotCritical = false;
        break;

      case Fix.THE_YODIRIAN:
      case Fix.THE_YODIRIAN_JP:
        SetupParameter(1200, 450, 1500, 12000, 60, 0, 40000, 50000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_CLEANSING_LANCE);
        list.Add(Fix.COMMAND_STATUS_CHANGE);
        list.Add(Fix.COMMAND_DEATH_DANCE);
        list.Add(Fix.COMMAND_HEAVEN_VOICE);
        list.Add(Fix.COMMAND_PLASMA_STORM);
        list.Add(Fix.COMMAND_APOCALYPSE_SWORD);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss42;
        this.CannotCritical = false;
        break;


      #endregion

      #region "ヴェルガスの海底神殿"
      case Fix.DAGGER_FISH:
      case Fix.DAGGER_FISH_JP:
        SetupParameter(820, 380, 600, 1600, 70, 7, 9800, 6600);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_WATER_GUN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area51;
        this.CannotCritical = false;
        break;

      case Fix.FLOATING_MANTA:
      case Fix.FLOATING_MANTA_JP:
        SetupParameter(610, 390, 820, 1680, 70, 2, 10200, 7100);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_WATER_DANCE);
        list.Add(Fix.COMMAND_WATER_SHOT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area51;
        this.CannotCritical = false;
        break;

      case Fix.SKYBLUE_BIRD:
      case Fix.SKYBLUE_BIRD_JP:
        SetupParameter(710, 450, 730, 1550, 70, 6, 10600, 7600);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CONTINUOUS_ATTACK);
        list.Add(Fix.COMMAND_SKY_FEATHER);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area51;
        this.CannotCritical = false;
        break;

      case Fix.RAINBOW_CLIONE:
      case Fix.RAINBOW_CLIONE_JP:
        SetupParameter(630, 410, 840, 1740, 70, 9, 11000, 8200);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_RAINBOW_BUBBLE);
        list.Add(Fix.COMMAND_WATER_CIRCLE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area51;
        this.CannotCritical = false;
        break;

      case Fix.ROLLING_MAGURO:
      case Fix.ROLLING_MAGURO_JP:
        SetupParameter(850, 400, 550, 1960, 70, 5, 11500, 8800);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_ROLLING_CHARGE);
        list.Add(Fix.COMMAND_JET_RUN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area51;
        this.CannotCritical = false;
        break;

      case Fix.BEAUTY_SEA_LILY:
      case Fix.BEAUTY_SEA_LILY_JP:
        SetupParameter(600, 430, 860, 1800, 70, 8, 12100, 9500);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_INVISIBLE_POISON);
        list.Add(Fix.COMMAND_BEAUTY_AROMA);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area51;
        this.CannotCritical = false;
        break;

      case Fix.DEVIL_STAR_DEATH_FLODIETE:
      case Fix.DEVIL_STAR_DEATH_FLODIETE_JP:
      case Fix.DEVIL_STAR_DEATH_FLODIETE_JP_VIEW:
        SetupParameter(1500, 650, 2000, 30000, 85, 0, 60000, 70000);
        this._baseInstantPoint = 4000;
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.BLUE_BULLET);
        list.Add(Fix.COMMAND_AQUA_BLOSSOM);
        list.Add(Fix.COMMAND_DEATH_STROKE);
        list.Add(Fix.COMMAND_DEVIL_EMBLEM);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss5;
        this.CannotCritical = true;
        break;

      case Fix.LIMBER_SEAEAGLE:
      case Fix.LIMBER_SEAEAGLE_JP:
        SetupParameter(920, 490, 900, 1900, 80, 8, 13000, 10500);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_COLD_WIND);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area52;
        this.CannotCritical = false;
        break;

      case Fix.FLUFFY_CORAL:
      case Fix.FLUFFY_CORAL_JP:
        SetupParameter(720, 450, 960, 2000, 80, 6, 13600, 11000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_PARALYZE_TENTACLE);
        list.Add(Fix.COMMAND_SCREAMING_SOUND);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area52;
        this.CannotCritical = false;
        break;

      case Fix.BLACK_OCTOPUS:
      case Fix.BLACK_OCTOPUS_JP:
        SetupParameter(970, 480, 730, 2120, 80, 4, 14200, 11500);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_KUROZUMI_FIELD);
        list.Add(Fix.COMMAND_HAGAIZIME);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area52;
        this.CannotCritical = false;
        break;

      case Fix.STEAL_SQUID:
      case Fix.STEAL_SQUID_JP:
        SetupParameter(760, 500, 990, 2360, 80, 1, 14800, 12000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SOLID_SQUARE_WATER);
        list.Add(Fix.COMMAND_BRIGHT_EYE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area52;
        this.CannotCritical = false;
        break;

      case Fix.PROUD_VIKING:
      case Fix.PROUD_VIKING_JP:
        SetupParameter(980, 470, 750, 2420, 80, 4, 15500, 12600);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add("アクス・ドライバー");
        list.Add("アース・クラップ");
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area52;
        this.CannotCritical = false;
        break;

      case Fix.GAN_GAME:
      case Fix.GAN_GAME_JP:
        SetupParameter(1000, 460, 710, 2480, 80, 3, 16200, 13200);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_STONE_KOURA);
        list.Add(Fix.COMMAND_DAIBOUSOU);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area52;
        this.CannotCritical = false;
        break;

      case Fix.JUMPING_KAMASU:
      case Fix.JUMPING_KAMASU_JP:
        SetupParameter(740, 510, 950, 2370, 80, 8, 16900, 13800);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_JUMP_SMASH);
        list.Add(Fix.COMMAND_STRANGE_SPELL);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area52;
        this.CannotCritical = false;
        break;

      case Fix.RECKLESS_WALRUS:
      case Fix.RECKLESS_WALRUS_JP:
        SetupParameter(990, 520, 730, 2530, 80, 5, 17600, 14400);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_THROWING_CRASH);
        list.Add(Fix.COMMAND_BAIRIKI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area52;
        this.CannotCritical = true;
        break;

      case Fix.THE_BIGHAND_OF_KRAKEN:
      case Fix.THE_BIGHAND_OF_KRAKEN_JP:
      case Fix.THE_BIGHAND_OF_KRAKEN_JP_VIEW:
        SetupParameter(2300, 700, 1700, 45000, 95, 0, 70000, 85000);
        this._baseInstantPoint = 4000;
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_NAGITAOSHI);
        list.Add(Fix.COMMAND_WASHIZUKAMI);
        list.Add(Fix.COMMAND_ZINARASHI);
        list.Add(Fix.COMMAND_SUIKOMI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss52;
        this.CannotCritical = true;
        break;

      case Fix.WRECHED_ANEMONE:
      case Fix.WRECHED_ANEMONE_JP:
        SetupParameter(850, 550, 1050, 3200, 90, 7, 18500, 15600);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SCARLET_SEED);
        list.Add(Fix.COMMAND_POISON_GERMINATION);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area53;
        this.CannotCritical = false;
        break;

      case Fix.DEEPSEA_HAND:
      case Fix.DEEPSEA_HAND_JP:
        SetupParameter(1070, 570, 860, 3340, 90, 4, 19200, 16200);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_WAVE_SIGN);
        list.Add(Fix.COMMAND_SILENT_SIGN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area53;
        this.CannotCritical = false;
        break;

      case Fix.ASSULT_SERPENT:
      case Fix.ASSULT_SERPENT_JP:
        SetupParameter(1080, 600, 870, 3480, 90, 5, 19900, 16800);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HIKKAKI_CLAW);
        list.Add(Fix.COMMAND_BATTLE_DANCE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area53;
        this.CannotCritical = false;
        break;

      case Fix.GIANT_SEA_SPIDER:
      case Fix.GIANT_SEA_SPIDER_JP:
        SetupParameter(880, 580, 1050, 3570, 90, 2, 20600, 17600);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_DRAIN_WEB);
        list.Add(Fix.COMMAND_SAND_SMOKE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area53;
        this.CannotCritical = false;
        break;

      case Fix.ESCORT_HERMIT_CLUB:
      case Fix.ESCORT_HERMIT_CLUB_JP:
        SetupParameter(1000, 610, 1000, 3660, 90, 8, 21400, 18300);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_GUT_SLASH);
        list.Add(Fix.COMMAND_GUARDIAN_SONG);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area53;
        this.CannotCritical = false;
        break;

      case Fix.MOGUL_MANTA:
      case Fix.MOGUL_MANTA_JP:
        SetupParameter(890, 590, 1080, 3790, 90, 7, 22200, 19000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_WATER_FLAPPING);
        list.Add(Fix.COMMAND_INVISIBLE_THREAD);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area53;
        this.CannotCritical = false;
        break;

      case Fix.GLUTTONY_COELACANTH:
      case Fix.GLUTTONY_COELACANTH_JP:
        SetupParameter(1130, 560, 910, 3980, 90, 6, 23000, 19700);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_INTENSE_BREATH);
        list.Add(Fix.COMMAND_BIG_SWIM);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area53;
        this.CannotCritical = false;
        break;

      case Fix.FEROCIOUS_WHALE:
      case Fix.FEROCIOUS_WHALE_JP:
        SetupParameter(1160, 600, 1160, 4100, 90, 9, 23800, 20400);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_ROAR);
        list.Add(Fix.COMMAND_BITING);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area53;
        this.CannotCritical = false;
        break;

      case Fix.GUARDIAN_ROYAL_NAGA:
      case Fix.GUARDIAN_ROYAL_NAGA_JP:
      case Fix.GUARDIAN_ROYAL_NAGA_JP_VIEW:
        SetupParameter(1900, 850, 2600, 60000, 105, 0, 80000, 100000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SAINT_DROP);
        list.Add(Fix.COMMAND_AMPLIFY_SEAL);
        list.Add(Fix.COMMAND_PHANTOM_SEAL);
        list.Add(Fix.COMMAND_TEN_BULLET);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss53;
        this.CannotCritical = true;
        break;

      case Fix.WEEPING_MIST:
      case Fix.WEEPING_MIST_JP:
        SetupParameter(1020, 710, 1270, 5500, 100, 5, 25000, 21000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_HOLLOW_MIST);
        list.Add(Fix.COMMAND_POLLUTED_POISON);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area54;
        this.CannotCritical = false;
        break;

      case Fix.AMBUSH_ANGLERFISH:
      case Fix.AMBUSH_ANGLERFISH_JP:
        SetupParameter(1260, 720, 1030, 5600, 100, 7, 25900, 21800);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BUBBLE_BULLET);
        list.Add(Fix.COMMAND_AMBUSH_ATTACK);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area54;
        this.CannotCritical = false;
        break;

      case Fix.EMERALD_LOBSTER:
      case Fix.EMERALD_LOBSTER_JP:
        SetupParameter(1280, 740, 1040, 5700, 100, 3, 26800, 22600);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_GROUND_THUNDER);
        list.Add(Fix.COMMAND_CONTINUOUS_CHARGE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area54;
        this.CannotCritical = false;
        break;

      case Fix.STICKY_STARFISH:
      case Fix.STICKY_STARFISH_JP:
        SetupParameter(1050, 730, 1290, 5550, 100, 9, 27700, 23400);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_STAR_EMBLEM);
        list.Add(Fix.COMMAND_MUD_PISTOL);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area54;
        this.CannotCritical = false;
        break;

      case Fix.RAMPAGE_BIGSHARK:
      case Fix.RAMPAGE_BIGSHARK_JP:
        SetupParameter(1300, 750, 1060, 6000, 100, 4, 28600, 24200);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_RIPPER_CLAW);
        list.Add(Fix.COMMAND_HIKICHIGIRI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area54;
        this.CannotCritical = true;
        break;

      case Fix.BIGMOUSE_JOE:
      case Fix.BIGMOUSE_JOE_JP:
        SetupParameter(1200, 770, 1200, 5850, 100, 1, 29500, 25000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_RUBBER_TONG);
        list.Add(Fix.COMMAND_SPANNING_SLASH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area54;
        this.CannotCritical = false;
        break;

      case Fix.SEA_STAR_KNIGHT:
      case Fix.SEA_STAR_KNIGHT_JP:
        SetupParameter(1250, 760, 1150, 5800, 100, 2, 30400, 25800);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_STARSWORD_KAI);
        list.Add(Fix.COMMAND_SEASTAR_EYE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area54;
        this.CannotCritical = false;
        break;

      case Fix.SEA_ELEMENTAL:
      case Fix.SEA_ELEMENTAL_JP:
        SetupParameter(1200, 800, 1420, 6500, 110, 8, 31400, 26700);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_WATER_CANNON);
        list.Add(Fix.COMMAND_PROTECTION_SEAL);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area55;
        this.CannotCritical = false;
        break;

      case Fix.EDGED_HIGH_SHARK:
      case Fix.EDGED_HIGH_SHARK_JP:
        SetupParameter(1450, 810, 1220, 6650, 110, 3, 32400, 27600);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BLOODSHOT_EYE);
        list.Add(Fix.COMMAND_FRENZY_DRIVE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area55;
        this.CannotCritical = true;
        break;

      case Fix.THOUGHTFUL_NAUTILUS:
      case Fix.THOUGHTFUL_NAUTILUS_JP:
        SetupParameter(1230, 820, 1460, 6800, 110, 2, 33400, 28500);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_THOUGHT_EATER);
        list.Add(Fix.COMMAND_VACUUM_SHOT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area55;
        this.CannotCritical = false;
        break;

      case Fix.GHOST_SHIP:
      case Fix.GHOST_SHIP_JP:
        SetupParameter(1350, 830, 1350, 6880, 110, 6, 34400, 29400);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_PHANTOM_EATER);
        list.Add(Fix.COMMAND_GHOST_KILL);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area55;
        this.CannotCritical = false;
        break;

      case Fix.DEFENSIVE_DATSU:
      case Fix.DEFENSIVE_DATSU_JP:
        SetupParameter(1520, 850, 1260, 7000, 110, 8, 35400, 30300);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_ZERO_ATTACK);
        list.Add(Fix.COMMAND_JU_STYLE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area55;
        this.CannotCritical = false;
        break;

      case Fix.SEA_SONG_MARMAID:
      case Fix.SEA_SONG_MARMAID_JP:
        SetupParameter(1280, 840, 1500, 6970, 110, 1, 36400, 31200);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_CLEANSING_SONG);
        list.Add(Fix.COMMAND_WASH_AWAY);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area55;
        this.CannotCritical = true;
        break;

      case Fix.BRILLIANT_SEA_PRINCE_1:
      case Fix.BRILLIANT_SEA_PRINCE_1_JP:
      case Fix.BRILLIANT_SEA_PRINCE_1_JP_VIEW:
        SetupParameter(2900, 880, 2000, 45000, 120, 0, 85000, 100000);
        this._baseInstantPoint = 4000;
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BRAVE_ROAR);
        list.Add(Fix.COMMAND_SEASLIDE_WATER);
        list.Add(Fix.COMMAND_GUNGNIR_SLASH);
        list.Add(Fix.COMMAND_ISONIC_WAVE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_1;
        this.CannotCritical = false;
        break;

      case Fix.SHELL_THE_SWORD_KNIGHT:
      case Fix.SHELL_THE_SWORD_KNIGHT_JP:
      case Fix.SHELL_THE_SWORD_KNIGHT_JP_VIEW:
        SetupParameter(3200, 900, 2100, 8000, 120, 0, 90000, 110000);
        this._baseInstantPoint = 4000;
        list.Add(Fix.COMMAND_CHARGE);
        list.Add(Fix.COMMAND_SEA_STRIVE);
        list.Add(Fix.COMMAND_BLINK_SHELL);
        list.Add(Fix.COMMAND_PLATINUM_BLADE);
        list.Add(Fix.COMMAND_SEASTAR_OATH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_2;
        this.CannotCritical = false;
        break;

      case Fix.SEA_STAR_KNIGHT_AEGIRU:
      case Fix.SEA_STAR_KNIGHT_AEGIRU_JP:
        SetupParameter(3600, 950, 2400, 106000, 120, 0, 100000, 120000);
        this._baseInstantPoint = 4000;
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_STAR_DUST);
        list.Add(Fix.COMMAND_STARSWORD_KIRAMEKI);
        list.Add(Fix.COMMAND_BARRIER_FIELD);
        list.Add(Fix.COMMAND_CIRCULAR_SLASH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_3_1;
        this.CannotCritical = false;
        break;

      case Fix.SEA_STAR_KNIGHT_AMARA:
      case Fix.SEA_STAR_KNIGHT_AMARA_JP:
        SetupParameter(2400, 960, 3600, 106000, 120, 0, 0, 0);
        this._baseInstantPoint = 3650;
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_STAR_FALL);
        list.Add(Fix.COMMAND_STARSWORD_TSUYA);
        list.Add(Fix.COMMAND_INVASION_FIELD);
        list.Add(Fix.COMMAND_ILLUSION_BOLT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_3_2;
        this.CannotCritical = false;
        break;

      case Fix.ORIGIN_STAR_CORAL_QUEEN_1:
      case Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP:
      case Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP_VIEW:
        SetupParameter(2600, 980, 3800, 88000, 130, 0, 105000, 130000);
        this._baseInstantPoint = 4000;
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_LIFE_WATER);
        list.Add(Fix.COMMAND_SALMAN_CHANT);
        list.Add(Fix.COMMAND_ANDATE_CHANT);
        list.Add(Fix.COMMAND_ELEMENTAL_SPLASH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_4;
        this.CannotCritical = false;
        break;

      case Fix.JELLY_EYE_BRIGHT_RED:
      case Fix.JELLY_EYE_BRIGHT_RED_JP:
        SetupParameter(2800, 1000, 4000, 132000, 130, 0, 110000, 140000);
        this._baseInstantPoint = 3600;
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_FIRE_BULLET);
        list.Add(Fix.COMMAND_BLAZING_STORM);
        list.Add(Fix.COMMAND_FLARE_BURN);
        list.Add(Fix.COMMAND_FIRE_WALL);
        list.Add(Fix.COMMAND_PENETRATION_EYE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_5_1;
        this.CannotCritical = false;
        break;

      case Fix.JELLY_EYE_DEEP_BLUE:
      case Fix.JELLY_EYE_DEEP_BLUE_JP:
        SetupParameter(2800, 1010, 4000, 132000, 130, 0, 0, 0);
        this._baseInstantPoint = 3300;
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_FROZEN_BULLET);
        list.Add(Fix.COMMAND_FREEZING_STORM);
        list.Add(Fix.COMMAND_SUDDEN_SQUALL);
        list.Add(Fix.COMMAND_WATER_BUBBLE);
        list.Add(Fix.COMMAND_HALLUCINATE_EYE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_5_2;
        this.CannotCritical = false;
        break;

      case Fix.GROUND_VORTEX_LEVIATHAN:
      case Fix.GROUND_VORTEX_LEVIATHAN_JP:
      case Fix.GROUND_VORTEX_LEVIATHAN_JP_VIEW:
        SetupParameter(4300, 1050, 4300, 160000, 140, 0, 120000, 160000);
        this._baseInstantPoint = 5000;
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SEASTARKING_ROAR);
        list.Add(Fix.COMMAND_BURST_CLOUD);
        list.Add(Fix.COMMAND_TIDAL_WAVE);
        list.Add(Fix.COMMAND_SURGETIC_BIND);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_6;
        this.CannotCritical = false;
        break;

      case Fix.BRILLIANT_SEA_PRINCE:
      case Fix.BRILLIANT_SEA_PRINCE_JP:
        SetupParameter(4600, 1200, 3300, 200000, 150, 0, 130000, 200000);
        this._baseInstantPoint = 4200;
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BRAVE_ROAR);
        list.Add(Fix.COMMAND_SEASLIDE_WATER);
        list.Add(Fix.COMMAND_GUNGNIR_SLASH);
        list.Add(Fix.COMMAND_GUNGNIR_LIGHT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_7_1;
        this.CannotCritical = false;
        break;

      case Fix.ORIGIN_STAR_CORAL_QUEEN:
      case Fix.ORIGIN_STAR_CORAL_QUEEN_JP:
      case Fix.ORIGIN_STAR_CORAL_QUEEN_JP_VIEW:
        SetupParameter(3300, 1150, 4600, 220000, 150, 0, 0, 0);
        this._baseInstantPoint = 3800;
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_LIFE_WATER);
        list.Add(Fix.COMMAND_SALMAN_CHANT);
        list.Add(Fix.COMMAND_ANDATE_CHANT);
        list.Add(Fix.COMMAND_ELEMENTAL_SPLASH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_7_2;
        this.CannotCritical = false;
        break;

      case Fix.VELGAS_THE_KING_OF_SEA_STAR:
      case Fix.VELGAS_THE_KING_OF_SEA_STAR_JP:
      case Fix.VELGAS_THE_KING_OF_SEA_STAR_JP_VIEW:
        SetupParameter(5000, 1100, 5000, 250000, 150, 0, 0, 0);
        this._baseInstantPoint = 5000;
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SEASTAR_ORIGIN_SEAL);
        list.Add(Fix.HOLY_BREATH);
        list.Add(Fix.FREEZING_CUBE);
        list.Add(Fix.FORTUNE_SPIRIT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss54_7_3;
        this.CannotCritical = false;
        break;

      #endregion

      #region "エデルガイゼン城"
      case Fix.PHANTOM_HUNTER:
      case Fix.PHANTOM_HUNTER_JP:
        SetupParameter(1800, 1090, 1500, 16000, 200, 0, 40000, 33000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BACKSTAB_ARROW);
        list.Add(Fix.COMMAND_KARAME_BIND);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area61;
        this.CannotCritical = true;
        break;

      case Fix.BEAST_MASTER:
      case Fix.BEAST_MASTER_JP:
        SetupParameter(1550, 1070, 1900, 19000, 200, 0, 41000, 33900);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_BEAST_SPIRIT);
        list.Add(Fix.COMMAND_BEAST_HOUND);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area61;
        this.CannotCritical = false;
        break;

      case Fix.ELDER_ASSASSIN:
      case Fix.ELDER_ASSASSIN_JP:
        SetupParameter(1850, 1150, 1550, 17000, 200, 0, 42000, 34800);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_DATOTSU);
        list.Add(Fix.COMMAND_ASSASSIN_POISONNEEDLE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area61;
        this.CannotCritical = true;
        break;

      case Fix.FALLEN_SEEKER:
      case Fix.FALLEN_SEEKER_JP:
        SetupParameter(1900, 1100, 1660, 18000, 200, 0, 43000, 35700);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SAINT_SLASH);
        list.Add(Fix.COMMAND_DEMON_CONTRACT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area61;
        this.CannotCritical = false;
        break;

      case Fix.MEPHISTO_RIGHTARM:
      case Fix.MEPHISTO_RIGHTARM_JP:
        SetupParameter(1700, 1120, 1950, 21000, 200, 0, 44000, 36600);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_DARKM_SPELL);
        list.Add(Fix.COMMAND_HELLFIRE_SPELL);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area61;
        this.CannotCritical = false;
        break;

      case Fix.POWERED_STEAM_BOW:
      case Fix.POWERED_STEAM_BOW_JP:
        SetupParameter(2000, 1050, 1700, 20000, 200, 0, 45000, 37500);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_RENZOKU_HOUSYA);
        list.Add(Fix.COMMAND_STEAM_ARROW);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area61;
        this.CannotCritical = true;
        break;

      case Fix.DARK_MESSENGER:
      case Fix.DARK_MESSENGER_JP:
        SetupParameter(1800, 1200, 2200, 24000, 225, 0, 47000, 39000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_BLACKDRAGON_WHISPER);
        list.Add(Fix.COMMAND_DEATH_HAITOKU);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area62;
        this.CannotCritical = false;
        break;

      case Fix.MASTER_LORD:
      case Fix.MASTER_LORD_JP:
        SetupParameter(2280, 1340, 1830, 25000, 225, 0, 48200, 40000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SUPERIOR_FIELD);
        list.Add(Fix.COMMAND_SHINDOWKEN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area62;
        this.CannotCritical = false;
        break;

      case Fix.EXECUTIONER:
      case Fix.EXECUTIONER_JP:
        SetupParameter(2360, 1300, 1810, 26000, 225, 0, 49400, 41000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_DEATH_STRIKE);
        list.Add(Fix.COMMAND_SOUL_FROZEN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area62;
        this.CannotCritical = false;
        break;

      case Fix.MARIONETTE_NEMESIS:
      case Fix.MARIONETTE_NEMESIS_JP:
        SetupParameter(1840, 1360, 2400, 27000, 225, 0, 50600, 42000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_CURSED_THREAD);
        list.Add(Fix.COMMAND_HORROR_VISION);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area62;
        this.CannotCritical = true;
        break;

      case Fix.BLACKFIRE_MASTER_BLADE:
      case Fix.BLACKFIRE_MASTER_BLADE_JP:
        SetupParameter(2420, 1420, 1870, 29000, 225, 0, 51800, 43000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_RASEN_KOKUEN);
        list.Add(Fix.COMMAND_RANSO_RENGEKI);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area62;
        this.CannotCritical = true;
        break;

      case Fix.SIN_THE_DARKELF:
      case Fix.SIN_THE_DARKELF_JP:
        SetupParameter(1860, 1380, 2460, 28000, 225, 0, 53000, 44000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_DEMON_BOLT);
        list.Add(Fix.COMMAND_ARCANE_DESTRUCTION);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area62;
        this.CannotCritical = false;
        break;

      case Fix.IMPERIAL_KNIGHT:
      case Fix.IMPERIAL_KNIGHT_JP:
        SetupParameter(2450, 1390, 1880, 30000, 225, 0, 54200, 45000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_TOWER_FALL);
        list.Add(Fix.COMMAND_ROUND_DIVIDE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area62;
        this.CannotCritical = false;
        break;

      case Fix.SUN_STRIDER:
      case Fix.SUN_STRIDER_JP:
        SetupParameter(2550, 1480, 1900, 32000, 250, 0, 56000, 47000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BLACK_FLARE);
        list.Add(Fix.COMMAND_SATELLITE_SWORD);
        list.Add(Fix.COMMAND_SIGIL_OF_SUN_FALLEN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area63;
        this.CannotCritical = false;
        break;

      case Fix.BALANCE_IDLE:
      case Fix.BALANCE_IDLE_JP:
        SetupParameter(2580, 1500, 2580, 38000, 250, 0, 57400, 48100);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_LIFE_BRILLIANT);
        list.Add(Fix.COMMAND_ALL_DUST);
        list.Add(Fix.COMMAND_LVEL_SONG);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area63;
        this.CannotCritical = false;
        break;

      case Fix.ARCHDEMON:
      case Fix.ARCHDEMON_JP:
        SetupParameter(2620, 1460, 1920, 34000, 250, 0, 58600, 49200);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_GIGANT_SLAYER);
        list.Add(Fix.COMMAND_JUONSATSU);
        list.Add(Fix.COMMAND_ABYSS_LOGIC);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area63;
        this.CannotCritical = true;
        break;

      case Fix.UNDEAD_WYVERN:
      case Fix.UNDEAD_WYVERN_JP:
        SetupParameter(1940, 1520, 2660, 36000, 250, 0, 59800, 50300);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_BONE_TORNADO);
        list.Add(Fix.COMMAND_OMINOUS_LAUGH);
        list.Add(Fix.COMMAND_SKULL_CRASH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area63;
        this.CannotCritical = false;
        break;

      case Fix.GO_FLAME_SLASHER:
      case Fix.GO_FLAME_SLASHER_JP:
        SetupParameter(2640, 1550, 1950, 44000, 250, 0, 61000, 51400);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_WAZAWAI_FLAME);
        list.Add(Fix.COMMAND_THE_END);
        list.Add(Fix.COMMAND_HELLFLAME_BULLET);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area63;
        this.CannotCritical = true;
        break;

      case Fix.DEVIL_CHILDREN:
      case Fix.DEVIL_CHILDREN_JP:
        SetupParameter(1980, 1540, 2680, 40000, 250, 0, 62200, 52500);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_CHROMATIC_BULLET);
        list.Add(Fix.COMMAND_SUPER_MAX_WAVE);
        list.Add(Fix.COMMAND_IRREGULAR_REGENERATION);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area63;
        this.CannotCritical = false;
        break;

      case Fix.ANCIENT_DISK:
      case Fix.ANCIENT_DISK_JP:
        SetupParameter(1990, 1530, 2700, 42000, 250, 0, 63400, 53600);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_ETERNAL_CIRCLE);
        list.Add(Fix.COMMAND_DESTRUCTION_CIRCLE);
        list.Add(Fix.COMMAND_PERFECT_STOP);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area63;
        this.CannotCritical = false;
        break;

      case Fix.HOWLING_HORROR:
      case Fix.HOWLING_HORROR_JP:
        SetupParameter(2100, 1620, 2850, 45000, 275, 0, 65000, 55000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SPECTOR_VOICE);
        list.Add(Fix.COMMAND_NOMERCY_SCREAM);
        list.Add(Fix.COMMAND_DARK_SIMULACRUM);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area64;
        this.CannotCritical = false;
        break;

      case Fix.PAIN_ANGEL:
      case Fix.PAIN_ANGEL_JP:
        SetupParameter(2900, 1660, 2120, 47000, 275, 0, 66300, 56200);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_FABRIOLE_SPEAR);
        list.Add(Fix.COMMAND_REST_IN_DREAM);
        list.Add(Fix.COMMAND_DANCING_LANCER);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area64;
        this.CannotCritical = false;
        break;

      case Fix.CHAOS_WARDEN:
      case Fix.CHAOS_WARDEN_JP:
        SetupParameter(2140, 1700, 2950, 49000, 275, 0, 67600, 57400);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_CHAOS_DEATHPERADE);
        list.Add(Fix.COMMAND_MARIA_DANSEL);
        list.Add(Fix.COMMAND_DESTRUCT_TUNING);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area64;
        this.CannotCritical = false;
        break;

      case Fix.HELL_DREAD_KNIGHT:
      case Fix.HELL_DREAD_KNIGHT_JP:
        SetupParameter(2980, 1740, 2170, 53000, 275, 0, 68900, 58600);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_GROUND_CRACK);
        list.Add(Fix.COMMAND_BLACK_DARK_LANCE);
        list.Add(Fix.COMMAND_UNDEAD_WISH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area64;
        this.CannotCritical = true;
        break;

      case Fix.DOOM_BRINGER:
      case Fix.DOOM_BRINGER_JP:
        SetupParameter(3050, 1720, 2200, 57000, 275, 0, 70200, 59800);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HELL_CIRCLE);
        list.Add(Fix.COMMAND_INNOCENT_SLASH);
        list.Add(Fix.COMMAND_HARSH_CUTTER);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area64;
        this.CannotCritical = false;
        break;

      case Fix.BLACK_LIGHTNING_SPHERE:
      case Fix.BLACK_LIGHTNING_SPHERE_JP:
        SetupParameter(2240, 1760, 3030, 51000, 275, 0, 71500, 61000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_JUDGEMENT_LIGHTNING);
        list.Add(Fix.COMMAND_BLACKHOLE);
        list.Add(Fix.COMMAND_ERROR_OCCUR);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area64;
        this.CannotCritical = true;
        break;

      case Fix.DISTORTED_SENSOR:
      case Fix.DISTORTED_SENSOR_JP:
        SetupParameter(3000, 1800, 3000, 55000, 275, 0, 72800, 62200);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_FUMBLE_SIGN);
        list.Add(Fix.COMMAND_AREA_TWIST);
        list.Add(Fix.COMMAND_PARADOXICAL_SLICER);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area64;
        this.CannotCritical = true;
        break;

      case Fix.ELDER_BAPHOMET:
      case Fix.ELDER_BAPHOMET_JP:
        SetupParameter(2280, 1900, 3180, 60000, 300, 0, 74000, 64000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_OAHN_VOICE);
        list.Add(Fix.COMMAND_MOMENT_MAGIC);
        list.Add(Fix.COMMAND_DESPIAR_RAIN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area65;
        this.CannotCritical = true;
        break;

      case Fix.WIND_BREAKER:
      case Fix.WIND_BREAKER_JP:
        SetupParameter(3300, 2020, 2300, 70000, 300, 0, 75500, 65400);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SWORD_OF_WIND);
        list.Add(Fix.COMMAND_SKY_CUTTER);
        list.Add(Fix.COMMAND_SONIC_BLADE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area65;
        this.CannotCritical = true;
        break;

      case Fix.HOLLOW_SPECTOR:
      case Fix.HOLLOW_SPECTOR_JP:
        SetupParameter(2320, 1950, 3260, 66000, 300, 0, 77000, 66800);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SCREAMING_FROM_VOICE);
        list.Add(Fix.COMMAND_DESPAIR_SPEAR);
        list.Add(Fix.COMMAND_KUUKAN_MATEN);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area65;
        this.CannotCritical = true;
        break;

      case Fix.VENERABLE_WIZARD:
      case Fix.VENERABLE_WIZARD_JP:
        SetupParameter(2340, 1980, 3330, 63000, 300, 0, 78500, 68200);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_METEOR_STORM);
        list.Add(Fix.COMMAND_CROSS_GATE);
        list.Add(Fix.COMMAND_PRISMATIC_BULLET);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area65;
        this.CannotCritical = true;
        break;

      case Fix.UNKNOWN_FLOATING_BALL:
      case Fix.UNKNOWN_FLOATING_BALL_JP:
        SetupParameter(3220, 1920, 2360, 68000, 300, 0, 80000, 68600);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_PHOTON_LASER);
        list.Add(Fix.COMMAND_SEALED_STONE);
        list.Add(Fix.COMMAND_OUT_OF_CONTROL);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Area65;
        this.CannotCritical = true;
        break;

      case Fix.MASCLEWARRIOR_HARDIL:
      case Fix.MASCLEWARRIOR_HARDIL_JP:
      case Fix.MASCLEWARRIOR_HARDIL_JP_VIEW:
        SetupParameter(6000, 2500, 4000, 300000, 350, 0, 150000, 250000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_POWER_EXPLOSION);
        list.Add(Fix.COMMAND_PERFECT_HIT);
        list.Add(Fix.COMMAND_FUSION_CHARGE);
        list.Add(Fix.COMMAND_LEGION_DRIVE);
        list.Add(Fix.COMMAND_BERSERKER_RUSH);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss6;
        this.CannotCritical = true;
        break;

      case Fix.HUGE_MAGICIAN_ZAGAN:
      case Fix.HUGE_MAGICIAN_ZAGAN_JP:
      case Fix.HUGE_MAGICIAN_ZAGAN_JP_VIEW:
        SetupParameter(4000, 2600, 6000, 320000, 360, 0, 160000, 300000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_GOLDEN_MATRIX);
        list.Add(Fix.COMMAND_METSU_INCARNATION);
        list.Add(Fix.COMMAND_THOUSAND_SQUALL);
        list.Add(Fix.COMMAND_AURORA_BLADE);
        list.Add(Fix.COMMAND_MEGIDO_BLAZE);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss62;
        this.CannotCritical = true;
        break;

      case Fix.LEGIN_ARZE_1:
      case Fix.LEGIN_ARZE_1_JP:
      case Fix.LEGIN_ARZE_1_JP_VIEW:
        SetupParameter(4500, 3000, 6500, 400000, 370, 0, 0, 0);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_ABYSS_WILL);
        list.Add(Fix.COMMAND_ONE_HOMURA);
        list.Add(Fix.COMMAND_ABYSS_FIRE);
        list.Add(Fix.COMMAND_ETERNAL_DROPLET);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss63_1;
        this.CannotCritical = true;
        break;

      case Fix.LEGIN_ARZE_2:
      case Fix.LEGIN_ARZE_2_JP:
      case Fix.LEGIN_ARZE_2_JP_VIEW:
        SetupParameter(4500, 3100, 6600, 450000, 380, 0, 0, 0);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_ABYSS_WILL);
        list.Add(Fix.COMMAND_ONE_HOMURA);
        list.Add(Fix.COMMAND_ABYSS_FIRE);
        list.Add(Fix.COMMAND_ETERNAL_DROPLET);
        list.Add(Fix.COMMAND_AUSTERITY_MATRIX_OMEGA);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss63_2;
        this.CannotCritical = true;
        break;

      case Fix.LEGIN_ARZE_3:
      case Fix.LEGIN_ARZE_3_JP:
      case Fix.LEGIN_ARZE_3_JP_VIEW:
        SetupParameter(4500, 3200, 6700, 500000, 390, 0, 200000, 350000);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_ABYSS_WILL);
        list.Add(Fix.COMMAND_ONE_HOMURA);
        list.Add(Fix.COMMAND_ABYSS_FIRE);
        list.Add(Fix.COMMAND_ETERNAL_DROPLET);
        list.Add(Fix.COMMAND_AUSTERITY_MATRIX_OMEGA);
        list.Add(Fix.COMMAND_VOID_BEAT);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss63_3;
        this.CannotCritical = true;
        break;

      case Fix.EMPEROR_LEGAL_ORPHSTEIN:
      case Fix.EMPEROR_LEGAL_ORPHSTEIN_JP:
      case Fix.EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW:
        SetupParameter(7500, 3500, 7500, 1000000, 500, 0, 0, 0);
        list.Add(Fix.COMMAND_CONTINUOUS_ATTACK);
        list.Add(Fix.COMMAND_PERFECT_PROPHECY);
        list.Add(Fix.COMMAND_HOLY_WISDOM);
        list.Add(Fix.COMMAND_ETERNAL_PRESENCE);
        list.Add(Fix.COMMAND_ULTIMATE_FLARE);
        list.Add(Fix.COMMAND_TIME_EXPANSION);
        list.Add(Fix.COMMAND_STARSWORD_ZETSU);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss64;
        this.CannotCritical = true;
        break;

      case Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN:
      case Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP:
      case Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW:
        SetupParameter(8000, 3800, 8000, 1500000, 600, 0, 0, 0);
        list.Add(Fix.COMMAND_CONTINUOUS_ATTACK);
        list.Add(Fix.COMMAND_PERFECT_PROPHECY);
        list.Add(Fix.COMMAND_HOLY_WISDOM);
        list.Add(Fix.COMMAND_ETERNAL_PRESENCE);
        list.Add(Fix.COMMAND_ULTIMATE_FLARE);
        list.Add(Fix.COMMAND_TIME_EXPANSION);
        list.Add(Fix.COMMAND_STARSWORD_ZETSU_HOMURA);
        this.Rare = Fix.RareString.Black;
        this.Area = Fix.MonsterArea.Boss64_2;
        this.CannotCritical = true;
        break;

      #endregion

      case Fix.DUMMY_SUBURI:
        SetupParameter(1000, 100, 1000, 99999, 10, 100, 0, 0);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DUEL_JEDA_ARUS:
        this.Level = 16;
        SetupParameter(48, 20, 30, 35, 12, 0, 0, 0);//(48, 20, 7, 35, 8, 0, 0, 0);
        list.Add(Fix.MAGIC_ATTACK);
        this.CannotCritical = false;
        this.MainWeapon = new Item(Fix.AERO_BLADE);
        this.SubWeapon = new Item(Fix.AERO_BLADE);
        this.MainArmor = new Item(Fix.CLASSICAL_ARMOR); //SUN_BRAVE_ARMOR);
        this.Accessory1 = new Item(Fix.BLUE_WIZARD_HAT); // SINTYUU_RING_KUROHEBI);
        this.Accessory2 = new Item(Fix.WARRIOR_BRACER); // SINTYUU_RING_AKAHYOU);
        this.Artifact = new Item(Fix.YELLOW_PENDANT);
        // todo Item保持リストが必要。回復ポーションなど
        break;

      case Fix.RUDE_WATCHDOG:
      case Fix.RUDE_WATCHDOG_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SHOTGUN_HYUUI:
      case Fix.SHOTGUN_HYUUI_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.CALM_STAG:
      case Fix.CALM_STAG_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FOREST_ELEMENTAL:
      case Fix.FOREST_ELEMENTAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STONE_STATUE_SEIHITSU:
      case Fix.STONE_STATUE_SEIHITSU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.THE_GALVADAZER:
      case Fix.THE_GALVADAZER_JP:
      case Fix.THE_GALVADAZER_JP_VIEW:
        SetupParameter(150, 120, 60, 420, 100, 10, 7500, 2000);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        this.Area = Fix.MonsterArea.Boss1;
        break;

      case Fix.LIGHTNING_SPHERE:
      case Fix.LIGHTNING_SPHERE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DECEIVED_HUNTSMAN:
      case Fix.DECEIVED_HUNTSMAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DHAL_GUARDIAN:
      case Fix.DHAL_GUARDIAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.PUPPET_MASTER:
      case Fix.PUPPET_MASTER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DANCING_BLADE:
      case Fix.DANCING_BLADE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TRAPPED_DISK:
      case Fix.TRAPPED_DISK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WHISTLE_SENSOR:
      case Fix.WHISTLE_SENSOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DREAD_LANCER:
      case Fix.DREAD_LANCER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.PEACEFUL_ANDANTINO:
      case Fix.PEACEFUL_ANDANTINO_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.POISONED_CHALICE:
      case Fix.POISONED_CHALICE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.AURORA_SPIRIT:
      case Fix.AURORA_SPIRIT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.HELL_KERBEROS:
      case Fix.HELL_KERBEROS_JP:
        //SetupParameter(85, 50, 15, 300, 10, 10000, 3000, 2000);
        SetupParameter(1, 50, 15, 1, 10, 0, 3000, 1200);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      default:
        SetupParameter(10, 10, 10, 10, 10, 0, 0, 0);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;
    }

    if (One.Difficulty == -1)
    {
      this.Strength = 1;
      this.Agility = 1;
      this.Intelligence = 1;
      this.Stamina = 1;
      this.Mind = 1;
      this.BaseLife = 1;
    }

    this.MaxGain();
    this.CurrentActionCommand = list[0];
    this.ActionCommandMain = list[0];
    for (int ii = 0; ii < 10; ii++)
    {
      if (ii < list.Count)
      {
        if (ii == 1) { this.ActionCommand1 = list[ii]; }
        else if (ii == 2) { this.ActionCommand2 = list[ii]; }
        else if (ii == 3) { this.ActionCommand3 = list[ii]; }
        else if (ii == 4) { this.ActionCommand4 = list[ii]; }
        else if (ii == 5) { this.ActionCommand5 = list[ii]; }
        else if (ii == 6) { this.ActionCommand6 = list[ii]; }
        else if (ii == 7) { this.ActionCommand7 = list[ii]; }
        else if (ii == 8) { this.ActionCommand8 = list[ii]; }
        else if (ii == 9) { this.ActionCommand9 = list[ii]; }
      }
      else
      {
        if (ii == 1) { this.ActionCommand1 = Fix.STAY; }
        else if (ii == 2) { this.ActionCommand2 = Fix.STAY; }
        else if (ii == 3) { this.ActionCommand3 = Fix.STAY; }
        else if (ii == 4) { this.ActionCommand4 = Fix.STAY; }
        else if (ii == 5) { this.ActionCommand5 = Fix.STAY; }
        else if (ii == 6) { this.ActionCommand6 = Fix.STAY; }
        else if (ii == 7) { this.ActionCommand7 = Fix.STAY; }
        else if (ii == 8) { this.ActionCommand8 = Fix.STAY; }
        else if (ii == 9) { this.ActionCommand9 = Fix.STAY; }
      }
    }
    this.CurrentImmediateCommand = string.Empty;
    this.Target2 = this;
  }
  #endregion

  #region "Enemy-AI"
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

  protected Fix.RareString _rare = Fix.RareString.Black;
  public Fix.RareString Rare
  {
    set { _rare = value; }
    get { return _rare; }
  }

  protected Fix.MonsterArea _area = Fix.MonsterArea.None;
  public Fix.MonsterArea Area
  {
    set { _area = value; }
    get { return _area; }
  }

  private void SetupParameter(int strength, int agility, int intelligence, int stamina, int mind, int base_life, int exp, int gold)
  {
    this._strength = strength;
    this._agility = agility;
    this._intelligence = intelligence;
    this._stamina = stamina;
    this._mind = mind;
    this._baseLife = base_life;
    this._baseSkillPoint = Fix.BASIC_SKILLPOINT;
    this._exp = exp;
    this._gold = gold;
  }

  // 敵の行動コマンドを決定する。
  // コマンド名のみではなくターゲット選定なども含める。
  public void ChooseCommand(List<Character> ally_group, List<Character> opponent_group, bool skip_decision)
  {
    string result = string.Empty;
    List<string> current = new List<string>();

    // コマンド名によってターゲット選定を設定する。
    // ランダムで対象を指定
    if (result == Fix.COMMAND_HAND_CANNON || result == Fix.COMMAND_SAIMIN_DANCE || result == Fix.COMMAND_POISON_NEEDLE || result == Fix.COMMAND_SPIKE_SHOT || result == Fix.COMMAND_TARGETTING_SHOT || result == Fix.COMMAND_POISON_TONGUE)
    {
      int rand = AP.Math.RandomInteger(opponent_group.Count);
      this.Target = opponent_group[rand];
    }
    // それ以外はグループの先頭を指定
    else
    {
      if (this.TargetSelectType == Fix.TargetSelectType.Behind)
      {
        for (int ii = opponent_group.Count - 1; ii >= 0; ii--)
        {
          if (opponent_group[ii].Dead == false)
          {
            this.Target = opponent_group[ii];
            break;
          }
        }
      }
      else
      {
        for (int ii = 0; ii < opponent_group.Count; ii++)
        {
          if (opponent_group[ii].Dead == false)
          {
            this.Target = opponent_group[ii];
            break;
          }
        }
      }
    }

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

      case Fix.MAGICAL_HAIL_GUN:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 8) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_ELECTRO_RAILGUN);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_LIGHTNING_OUTBURST);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        else if (this.AI_Phase == 4)
        {
          current.Add(Fix.COMMAND_SPAAAARK);
        }
        else if (this.AI_Phase == 5)
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        else if (this.AI_Phase == 6)
        {
          current.Add(Fix.COMMAND_BEHIND_BOMB);
          for (int ii = opponent_group.Count - 1; ii >= 0; ii--)
          {
            if (opponent_group[ii].Dead == false)
            {
              this.Target = opponent_group[ii];
              break;
            }
          }
        }
        else if (this.AI_Phase == 7)
        {
          current.Add(Fix.MAGIC_ATTACK);
        }

        result = RandomChoice(current);
        break;

      case Fix.THE_GALVADAZER:
      case Fix.THE_GALVADAZER_JP:
      case Fix.THE_GALVADAZER_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
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

      case Fix.FLANSIS_OF_THE_FOREST_QUEEN:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 4) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_FIRE_BLAST);
        }
        else if (this.AI_Phase == 1)
        {
          if (this.SearchFieldBuff(Fix.BUFF_VERDANT_VOICE))
          {
            current.Add(Fix.MAGIC_ATTACK);
          }
          else
          {
            current.Add(Fix.COMMAND_VERDANT_VOICE);
          }
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_RENSOU_TOSSHIN);
        }
        else
        {
          bool detect = false;
          for (int ii = 0; ii < opponent_group.Count; ii++)
          {
            if (opponent_group[ii].SearchBuff(Fix.BUFF_BLACK_SPORE) == false)
            {
              current.Add(Fix.COMMAND_BLACK_SPORE);
              detect = true;
              break;
            }
          }
          if (detect == false)
          {
            current.Add(Fix.NORMAL_ATTACK);
          }
        }
        result = RandomChoice(current);
        break;

      case Fix.LIGHT_THUNDER_LANCEBOLTS:
      case Fix.LIGHT_THUNDER_LANCEBOLTS_JP:
      case Fix.LIGHT_THUNDER_LANCEBOLTS_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 4) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_FURY_TRIDENT);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_LIGHT_THUNDERBOLT);
        }
        else if (this.AI_Phase == 2)
        {
          if (this.IsBattleSpeedUp == false ||
              this.IsPhysicalAttackUp == false ||
              this.IsMagicDefenseUp == false)
          {
            current.Add(Fix.COMMAND_CYCLONE_ARMOR);
          }
        }
        else
        {
          if (AP.Math.RandomInteger(2) == 0)
          {
            current.Add(Fix.MAGIC_ATTACK);
          }
          else
          {
            current.Add(Fix.NORMAL_ATTACK);
          }
        }
        result = RandomChoice(current);
        break;

      case Fix.THE_YODIRIAN:
      case Fix.THE_YODIRIAN_JP:
      case Fix.THE_YODIRIAN_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_CLEANSING_LANCE);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_STATUS_CHANGE);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_DEATH_DANCE);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_HEAVEN_VOICE);
        }
        else if (this.AI_Phase == 4)
        {
          current.Add(Fix.COMMAND_PLASMA_STORM);
        }
        else
        {
          if (AP.Math.RandomInteger(2) == 0)
          {
            current.Add(Fix.MAGIC_ATTACK);
          }
          else
          {
            current.Add(Fix.NORMAL_ATTACK);
          }
        }
        result = RandomChoice(current);
        break;

      case Fix.DEVIL_STAR_DEATH_FLODIETE:
      case Fix.DEVIL_STAR_DEATH_FLODIETE_JP:
      case Fix.DEVIL_STAR_DEATH_FLODIETE_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 4) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.BLUE_BULLET);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_AQUA_BLOSSOM);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_DEATH_STROKE);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_DEVIL_EMBLEM);
        }
        else
        {
          if (AP.Math.RandomInteger(2) == 0)
          {
            current.Add(Fix.MAGIC_ATTACK);
          }
          else
          {
            current.Add(Fix.NORMAL_ATTACK);
          }
        }
        result = RandomChoice(current);
        break;

      case Fix.THE_BIGHAND_OF_KRAKEN:
      case Fix.THE_BIGHAND_OF_KRAKEN_JP:
      case Fix.THE_BIGHAND_OF_KRAKEN_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 4) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_NAGITAOSHI);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_WASHIZUKAMI);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_ZINARASHI);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_SUIKOMI);
        }
        else
        {
          if (AP.Math.RandomInteger(2) == 0)
          {
            current.Add(Fix.MAGIC_ATTACK);
          }
          else
          {
            current.Add(Fix.NORMAL_ATTACK);
          }
        }
        result = RandomChoice(current);
        break;

      case Fix.BRILLIANT_SEA_PRINCE_1:
      case Fix.BRILLIANT_SEA_PRINCE_1_JP:
      case Fix.BRILLIANT_SEA_PRINCE_1_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_ISONIC_WAVE);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_SEASLIDE_WATER);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_GUNGNIR_SLASH);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_BRAVE_ROAR);
        }
        else
        {
          current.Add(Fix.NORMAL_ATTACK);
        }
        result = RandomChoice(current);
        break;

      // BRILLIANT_SEA_PRINCE_1と同一だが、違うキャラクターとして設定しているため、
      // 別のコードとして記載しておく。
      case Fix.BRILLIANT_SEA_PRINCE:
      case Fix.BRILLIANT_SEA_PRINCE_JP:
      case Fix.BRILLIANT_SEA_PRINCE_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_ISONIC_WAVE);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_SEASLIDE_WATER);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_GUNGNIR_SLASH);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_BRAVE_ROAR);
        }
        else
        {
          current.Add(Fix.NORMAL_ATTACK);
        }
        result = RandomChoice(current);
        break;

      case Fix.ORIGIN_STAR_CORAL_QUEEN_1:
      case Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP:
      case Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_LIFE_WATER);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_SALMAN_CHANT);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_ANDATE_CHANT);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_ELEMENTAL_SPLASH);
        }
        else
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        result = RandomChoice(current);
        break;

      // ORIGIN_STAR_CORAL_QUEEN_1と同一だが、違うキャラクターとして設定しているため、
      // 別のコードとして記載しておく。
      case Fix.ORIGIN_STAR_CORAL_QUEEN:
      case Fix.ORIGIN_STAR_CORAL_QUEEN_JP:
      case Fix.ORIGIN_STAR_CORAL_QUEEN_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_LIFE_WATER);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_SALMAN_CHANT);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_ANDATE_CHANT);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_ELEMENTAL_SPLASH);
        }
        else
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        result = RandomChoice(current);
        break;

      case Fix.SHELL_THE_SWORD_KNIGHT:
      case Fix.SHELL_THE_SWORD_KNIGHT_JP:
      case Fix.SHELL_THE_SWORD_KNIGHT_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_PLATINUM_BLADE);
        }
        else if (this.AI_Phase == 1)
        {
          if (this.IsFortuneSpirit == false)
          {
            current.Add(Fix.COMMAND_BLINK_SHELL);
          }
          else
          {
            current.Add(Fix.NORMAL_ATTACK);
          }
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_SEA_STRIVE);
        }
        else if (this.AI_Phase == 3)
        {
          if (this.IsPhysicalAttackUp == false)
          {
            current.Add(Fix.COMMAND_SEASTAR_OATH);
          }
          else
          {
            current.Add(Fix.NORMAL_ATTACK);
          }
        }
        else if (this.AI_Phase == 4)
        {
          current.Add(Fix.COMMAND_CHARGE);
        }
        else
        {
          current.Add(Fix.NORMAL_ATTACK);
        }
        result = RandomChoice(current);
        break;

      case Fix.SEA_STAR_KNIGHT_AEGIRU:
      case Fix.SEA_STAR_KNIGHT_AEGIRU_JP:
      case Fix.SEA_STAR_KNIGHT_AEGIRU_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 4) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_STAR_DUST);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_STARSWORD_KIRAMEKI);
        }
        else if (this.AI_Phase == 2)
        {
          if (this.IsPhysicalDefenseUp == false)
          {
            current.Add(Fix.COMMAND_BARRIER_FIELD);
          }
          else
          {
            current.Add(Fix.NORMAL_ATTACK);
          }
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_CIRCULAR_SLASH);
        }
        else
        {
          current.Add(Fix.NORMAL_ATTACK);
        }
        result = RandomChoice(current);
        break;

      case Fix.SEA_STAR_KNIGHT_AMARA:
      case Fix.SEA_STAR_KNIGHT_AMARA_JP:
      case Fix.SEA_STAR_KNIGHT_AMARA_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 4) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          if (this.IsPhysicalDefenseUp == false)
          {
            current.Add(Fix.COMMAND_INVASION_FIELD);
          }
          else
          {
            current.Add(Fix.NORMAL_ATTACK);
          }
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_ILLUSION_BOLT);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_STAR_FALL);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_STARSWORD_TSUYA);
        }
        else
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        result = RandomChoice(current);
        break;

      case Fix.JELLY_EYE_BRIGHT_RED:
      case Fix.JELLY_EYE_BRIGHT_RED_JP:
      case Fix.JELLY_EYE_BRIGHT_RED_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_FIRE_BULLET);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_FLARE_BURN);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_BLAZING_STORM);
        }
        else
        {
          current.Add(Fix.COMMAND_FIRE_WALL);
        }
        result = RandomChoice(current);
        break;

      case Fix.JELLY_EYE_DEEP_BLUE:
      case Fix.JELLY_EYE_DEEP_BLUE_JP:
      case Fix.JELLY_EYE_DEEP_BLUE_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_SUDDEN_SQUALL);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_FREEZING_STORM);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_WATER_BUBBLE);
        }
        else
        {
          current.Add(Fix.COMMAND_FROZEN_BULLET);
        }
        result = RandomChoice(current);
        break;

      case Fix.GROUND_VORTEX_LEVIATHAN:
      case Fix.GROUND_VORTEX_LEVIATHAN_JP:
      case Fix.GROUND_VORTEX_LEVIATHAN_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.COMMAND_SEASTARKING_ROAR);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_TIDAL_WAVE);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_SURGETIC_BIND);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_BURST_CLOUD);
        }
        else
        {
          current.Add(Fix.NORMAL_ATTACK);
        }
        result = RandomChoice(current);
        break;

      case Fix.VELGAS_THE_KING_OF_SEA_STAR:
      case Fix.VELGAS_THE_KING_OF_SEA_STAR_JP:
      case Fix.VELGAS_THE_KING_OF_SEA_STAR_JP_VIEW:
        if (skip_decision == false) { this.AI_Phase++; }
        if (this.AI_Phase >= 5) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.FORTUNE_SPIRIT);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.FREEZING_CUBE);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_SEASTAR_ORIGIN_SEAL);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.HOLY_BREATH);
        }
        else
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        result = RandomChoice(current);
        break;

      case Fix.DUEL_JEDA_ARUS:
        switch (AP.Math.RandomInteger(2))
        {
          case 0:
            if (this.SearchFieldBuff(Fix.DIVINE_CIRCLE) == null)
            {
              result = Fix.DIVINE_CIRCLE;
            }
            else if (this.CurrentSkillPoint >= SecondaryLogic.CostControl(Fix.DOUBLE_SLASH, ActionCommand.Cost(Fix.DOUBLE_SLASH), this))
            {
              result = Fix.DOUBLE_SLASH;
            }
            else
            {
              result = Fix.NORMAL_ATTACK;
            }
            break;

          case 1:
            if (this.SearchBuff(Fix.STANCE_OF_THE_BLADE) == null)
            {
              result = Fix.STANCE_OF_THE_BLADE;
            }
            else if (this.CurrentSkillPoint >= SecondaryLogic.CostControl(Fix.DOUBLE_SLASH, ActionCommand.Cost(Fix.DOUBLE_SLASH), this))
            {
              result = Fix.DOUBLE_SLASH;
            }
            else
            {
              result = Fix.NORMAL_ATTACK;
            }
            break;
        }
        break;

      case Fix.DUMMY_SUBURI:
        if (AP.Math.RandomInteger(2) == 0)
        {
          if (this.IsStanceOfTheIai == false)
          {
            result = Fix.DEATH_SCYTHE;
          }
          else
          {
            result = Fix.COMMAND_POISON_NEEDLE;
          }
        }
        else
        {
          result = Fix.NORMAL_ATTACK;
        }
        break;

      default:
        // 雑魚はランダムでひとまずよい。
        List<string> currentList = GetActionCommandList();
        currentList.Add(this.ActionCommandMain);
        result = RandomChoice(currentList);
        break;
    }

    // コマンド名によって後方優先を設定する。
    if (result == Fix.COMMAND_AIUCHI_NERAI ||
        result == Fix.COMMAND_HIDDEN_KNIFE ||
        result == Fix.COMMAND_RENSYA ||
        result == Fix.COMMAND_INVISIBLE_POISON ||
        result == Fix.COMMAND_THROWING_CRASH ||
        result == Fix.COMMAND_INVISIBLE_THREAD ||
        result == Fix.COMMAND_AMBUSH_ATTACK ||
        result == Fix.COMMAND_BACKSTAB_ARROW ||
        result == Fix.COMMAND_ASSASSIN_POISONNEEDLE)
    {
      Debug.Log("result is COMMAND_HIDDEN_KNIFE, then behind");
      for (int ii = opponent_group.Count - 1; ii >= 0; ii--)
      {
        if (opponent_group[ii].Dead == false)
        {
          this.Target = opponent_group[ii];
          break;
        }
      }
    }

    if (skip_decision == false)
    {
      this.Decision = true;
    }
    this.CurrentActionCommand = result;
    if (this.txtActionCommand != null)
    {
      this.txtActionCommand.text = result;
    }
  }

  private string RandomChoice(List<string> command_list)
  {
    string result = string.Empty;
    command_list.RemoveAll(s => s.Contains(Fix.STAY));
    int random = AP.Math.RandomInteger(command_list.Count);
    return command_list[random];
  }
  #endregion

  public string ConvertToJP(string src)
  {
    if (src == Fix.TINY_MANTIS) { return Fix.TINY_MANTIS_JP; }
    if (src == Fix.GREEN_SLIME) { return Fix.GREEN_SLIME_JP; }
    if (src == Fix.MANDRAGORA) { return Fix.MANDRAGORA_JP; }
    if (src == Fix.YOUNG_WOLF) { return Fix.YOUNG_WOLF_JP; }
    if (src == Fix.WILD_ANT) { return Fix.WILD_ANT_JP; }
    if (src == Fix.OLD_TREEFORK) { return Fix.OLD_TREEFORK_JP; }
    if (src == Fix.SUN_FLOWER) { return Fix.SUN_FLOWER_JP; }
    if (src == Fix.SOLID_BEETLE) { return Fix.SOLID_BEETLE_JP; }
    if (src == Fix.SILENT_LADYBUG) { return Fix.SILENT_LADYBUG_JP; }
    if (src == Fix.NIMBLE_RABBIT) { return Fix.NIMBLE_RABBIT_JP; }
    if (src == Fix.ENTANGLED_VINE) { return Fix.ENTANGLED_VINE_JP; }
    if (src == Fix.CREEPING_SPIDER) { return Fix.CREEPING_SPIDER_JP; }
    if (src == Fix.BLOOD_MOSS) { return Fix.BLOOD_MOSS_JP; }
    if (src == Fix.KILLER_BEE) { return Fix.KILLER_BEE_JP; }
    if (src == Fix.WONDER_SEED) { return Fix.WONDER_SEED_JP; }
    if (src == Fix.DAUNTLESS_HORSE) { return Fix.DAUNTLESS_HORSE_JP; }
    if (src == Fix.SCREAMING_RAFFLESIA) { return Fix.SCREAMING_RAFFLESIA_JP; }

    if (src == Fix.DEBRIS_SOLDIER) { return Fix.DEBRIS_SOLDIER_JP; }
    if (src == Fix.MAGICAL_AUTOMATA) { return Fix.MAGICAL_AUTOMATA_JP; }
    if (src == Fix.KILLER_MACHINE) { return Fix.KILLER_MACHINE_JP; }
    if (src == Fix.STINKY_BAT) { return Fix.STINKY_BAT_JP; }
    if (src == Fix.ANTIQUE_MIRROR) { return Fix.ANTIQUE_MIRROR_JP; }
    if (src == Fix.MECH_HAND) { return Fix.MECH_HAND_JP; }
    if (src == Fix.ABSENCE_MOAI) { return Fix.ABSENCE_MOAI_JP; }
    if (src == Fix.ACID_SCORPION) { return Fix.ACID_SCORPION_JP; }
    if (src == Fix.NEJIMAKI_KNIGHT) { return Fix.NEJIMAKI_KNIGHT_JP; }
    if (src == Fix.AIMING_SHOOTER) { return Fix.AIMING_SHOOTER_JP; }
    if (src == Fix.CULT_BLACK_MAGICIAN_JP) { return Fix.CULT_BLACK_MAGICIAN_JP; }
    if (src == Fix.STONE_GOLEM) { return Fix.STONE_GOLEM_JP; }
    if (src == Fix.JUNK_VULKAN) { return Fix.JUNK_VULKAN_JP; }
    if (src == Fix.LIGHTNING_CLOUD) { return Fix.LIGHTNING_CLOUD_JP; }
    if (src == Fix.SILENT_GARGOYLE) { return Fix.SILENT_GARGOYLE_JP; }
    if (src == Fix.GATE_HOUND) { return Fix.GATE_HOUND_JP; }
    if (src == Fix.PLAY_FIRE_IMP_JP) { return Fix.PLAY_FIRE_IMP_JP; }
    if (src == Fix.WALKING_TIME_BOMB) { return Fix.WALKING_TIME_BOMB_JP; }
    if (src == Fix.EARTH_ELEMENTAL) { return Fix.EARTH_ELEMENTAL_JP; }
    if (src == Fix.DEATH_DRONE) { return Fix.DEATH_DRONE_JP; }
    if (src == Fix.ASSULT_SCARECROW) { return Fix.ASSULT_SCARECROW_JP; }
    if (src == Fix.MAD_DOCTOR) { return Fix.MAD_DOCTOR_JP; }
    if (src == Fix.MAGICAL_HAIL_GUN) { return Fix.MAGICAL_HAIL_GUN_JP; }
    if (src == Fix.THE_GALVADAZER) { return Fix.THE_GALVADAZER_JP; }

    if (src == Fix.CHARGED_BOAR) { return Fix.CHARGED_BOAR_JP; }
    if (src == Fix.WOOD_ELF) { return Fix.WOOD_ELF_JP; }
    if (src == Fix.STINKED_SPORE) { return Fix.STINKED_SPORE_JP; }
    if (src == Fix.POISON_FLOG) { return Fix.POISON_FLOG_JP; }
    if (src == Fix.GIANT_SNAKE) { return Fix.GIANT_SNAKE_JP; }
    if (src == Fix.SAVAGE_BEAR) { return Fix.SAVAGE_BEAR_JP; }
    if (src == Fix.INNOCENT_FAIRY) { return Fix.INNOCENT_FAIRY_JP; }
    if (src == Fix.MYSTIC_DRYAD) { return Fix.MYSTIC_DRYAD_JP; }
    if (src == Fix.SPEEDY_FALCON) { return Fix.SPEEDY_FALCON_JP; }
    if (src == Fix.WOLF_HUNTER) { return Fix.WOLF_HUNTER_JP; }
    if (src == Fix.FOREST_PHANTOM) { return Fix.FOREST_PHANTOM_JP; }
    if (src == Fix.EXCITED_ELEPHANT) {  return Fix.EXCITED_ELEPHANT_JP; }
    if (src == Fix.SYLPH_DANCER) { return Fix.SYLPH_DANCER_JP; }
    if (src == Fix.GATHERING_LAPTOR) { return Fix.GATHERING_LAPTOR_JP; }
    if (src == Fix.FOREST_ELEMENTAL) { return Fix.FOREST_ELEMENTAL_JP; }
    if (src == Fix.THORN_WARRIOR) { return Fix.THORN_WARRIOR_JP; }
    if (src == Fix.MUDDLED_PLANT) { return Fix.MUDDLED_PLANT_JP; }
    if (src == Fix.FLANSIS_KNIGHT) { return Fix.FLANSIS_KNIGHT_JP; }
    if (src == Fix.MIST_PYTHON) { return Fix.MIST_PYTHON_JP; }
    if (src == Fix.TOWER_SCOUT) { return Fix.TOWER_SCOUT_JP; }
    if (src == Fix.DISTURB_RHINO) { return Fix.DISTURB_RHINO_JP; }
    if (src == Fix.POISON_MARY) { return Fix.POISON_MARY_JP; }
    if (src == Fix.FLANSIS_OF_THE_FOREST_QUEEN) { return Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP; }

    // 未設定
    if (src == Fix.RUDE_WATCHDOG) { return Fix.RUDE_WATCHDOG_JP; }
    if (src == Fix.STONE_STATUE_SEIHITSU) { return Fix.STONE_STATUE_SEIHITSU_JP; }
    if (src == Fix.DISTORTED_SENSOR) { return Fix.DISTORTED_SENSOR_JP; }
    if (src == Fix.SHOTGUN_HYUUI) { return Fix.SHOTGUN_HYUUI_JP; }

    return src; // なにも該当しないなら、そのまま。
  }
}
