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
  public Text txtSoulPoint = null;
  public Image objBackSoulPointGauge = null;
  public Image objCurrentSoulPointGauge = null;
  public Image objCurrentSoulPointBorder = null;
  public BuffField objBuffPanel = null;
  public NodeActionCommand objImmediateCommand = null;
  public GameObject GroupActionCommand = null;
  public List<NodeActionCommand> objActionCommandList = new List<NodeActionCommand>();

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
    get { return _isDefense; }
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
  [SerializeField] protected int _baseSoulPoint = 0;
  public int BaseSoulPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _baseSoulPoint = value;
    }
    get { return _baseSoulPoint; }
  }

  public int MaxSoulPoint
  {
    get
    {
      return _baseSoulPoint + TotalMind * 2;
    }
  }

  [SerializeField] protected int _currentSoulPoint = 0;
  public int CurrentSoulPoint
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      if (value >= MaxSoulPoint)
      {
        value = MaxSoulPoint;
      }
      _currentSoulPoint = value;
    }
    get { return _currentSoulPoint; }
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

  [SerializeField] protected bool _AvailableSwordman = false;
  public bool AvailableSwordman
  {
    set { _AvailableSwordman = value; }
    get { return _AvailableSwordman; }
  }

  [SerializeField] protected bool _AvailableArmorer = false;
  public bool AvailableArmorer
  {
    set { _AvailableArmorer = value; }
    get { return _AvailableArmorer; }
  }

  [SerializeField] protected bool _AvailableArcher = false;
  public bool AvailableArcher
  {
    set { _AvailableArcher = value; }
    get { return _AvailableArcher; }
  }

  [SerializeField] protected bool _AvailableRogue = false;
  public bool AvailableRogue
  {
    set { _AvailableRogue = value; }
    get { return _AvailableRogue; }
  }

  [SerializeField] protected bool _AvailableMartialArts = false;
  public bool AvailableMartialArts
  {
    set { _AvailableMartialArts = value; }
    get { return _AvailableMartialArts; }
  }

  [SerializeField] protected bool _AvailableWonderHermit = false;
  public bool AvailableWonderHermit
  {
    set { _AvailableWonderHermit = value; }
    get { return _AvailableWonderHermit; }
  }

  [SerializeField] protected bool _AvailableEnhanceForm = false;
  public bool AvailableEnhanceForm
  {
    set { _AvailableEnhanceForm = value; }
    get { return _AvailableEnhanceForm; }
  }

  [SerializeField] protected bool _AvailableMysticForm = false;
  public bool AvailableMysticForm
  {
    set { _AvailableMysticForm = value; }
    get { return _AvailableMysticForm; }
  }

  [SerializeField] protected bool _AvailableBrave = false;
  public bool AvailableBrave
  {
    set { _AvailableBrave = value; }
    get { return _AvailableBrave; }
  }

  [SerializeField] protected bool _AvailableMindfulness = false;
  public bool AvailableMindfulness
  {
    set { _AvailableMindfulness = value; }
    get { return _AvailableMindfulness; }
  }

  [SerializeField] protected bool _AvailableTruth = false;
  public bool AvailableTruth
  {
    set { _AvailableTruth = value; }
    get { return _AvailableTruth; }
  }

  [SerializeField] protected bool _AvailableVengeance = false;
  public bool AvailableVengeance
  {
    set { _AvailableVengeance = value; }
    get { return _AvailableVengeance; }
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
  [SerializeField] protected int _LaylineSchema = 0;
  public int LaylineSchema { set { if (value >= 0) { _LaylineSchema = value; } } get { return _LaylineSchema; } }
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
  [SerializeField] protected int _CursedEvangel = 0;
  public int CursedEvangel { set { if (value >= 0) { _CursedEvangel = value; } } get { return _CursedEvangel; } }
  [SerializeField] protected int _GaleWind = 0;
  public int GaleWind { set { if (value >= 0) { _GaleWind = value; } } get { return _GaleWind; } }
  [SerializeField] protected int _SandBurst = 0;
  public int SandBurst { set { if (value >= 0) { _SandBurst = value; } } get { return _SandBurst; } }
  [SerializeField] protected int _IronBaster = 0;
  public int IronBaster { set { if (value >= 0) { _IronBaster = value; } } get { return _IronBaster; } }
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
  [SerializeField] protected int _CircleOfTheVigor = 0;
  public int CircleOfTheVigor { set { if (value >= 0) { _CircleOfTheVigor = value; } } get { return _CircleOfTheVigor; } }
  [SerializeField] protected int _DetachmentFault = 0;
  public int DetachmentFault { set { if (value >= 0) { _DetachmentFault = value; } } get { return _DetachmentFault; } }
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
  [SerializeField] protected int _PrecisionRange = 0;
  public int PrecisionRange { set { if (value >= 0) { _PrecisionRange = value; } } get { return _PrecisionRange; } }
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
  [SerializeField] protected int _OneImmunity = 0;
  public int OneImmunity { set { if (value >= 0) { _OneImmunity = value; } } get { return _OneImmunity; } }
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
    return false;
  }


  public int GetPotentialEnergy()
  {
    return 100; // todo 係数化して変化があると良い。
  }
  public void MaxGain()
  {
    _currentLife = MaxLife;
    _currentSoulPoint = MaxSoulPoint;
    //_currentActionPoint = MaxActionPoint;
    //_currentEnergyPoint = MaxEnergyPoint;
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

  public void UpdateSoulPoint()
  {
    float dx = (float)this._currentSoulPoint / (float)this.MaxSoulPoint;
    if (this.objCurrentSoulPointGauge != null)
    {
      this.objCurrentSoulPointGauge.rectTransform.localScale = new Vector2(dx, 1.0f);
    }
    if (this.txtSoulPoint != null)
    {
      this.txtSoulPoint.text = this.CurrentSoulPoint.ToString() + " / " + this.MaxSoulPoint.ToString();
    }
    if (this.objCurrentSoulPointBorder != null)
    {
      if (dx >= 1.0f)
      {
        this.objCurrentSoulPointBorder.gameObject.SetActive(false);
      }
      else
      {
        this.objCurrentSoulPointBorder.gameObject.SetActive(true);
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
    int result = 100;
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
  /// </summary>
  /// <param name="equip_type"></param>
  /// <param name="item"></param>
  /// <returns>  true: 装備可能</returns>
  ///           false: 装備不可
  public bool Equipable(Fix.EquipType equip_type, Item item)
  {
    // todo Fighter, Magician, Seekerまで記述。それぞれMasterとHighについては追記が必要。
    if (equip_type == Fix.EquipType.MainWeapon)
    {
      Debug.Log("Equipable start : MainWeapon");
      if ((this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Sword && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Lance && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Axe && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Claw && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Bow && item.GripType == Item.GripTypes.TwoHand) ||
          (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Sword && item.GripType == Item.GripTypes.TwoHand) ||
          (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Lance && item.GripType == Item.GripTypes.TwoHand) ||
          (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Axe && item.GripType == Item.GripTypes.TwoHand))
      {
        return true;
      }
      if ((this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Onehand_Rod && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Onehand_Book && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Onehand_Orb && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Twohand_Rod && item.GripType == Item.GripTypes.TwoHand))
      {
        return true;
      }
      if ((this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Sword && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Lance && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Axe && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Claw && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Bow && item.GripType == Item.GripTypes.TwoHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Sword && item.GripType == Item.GripTypes.TwoHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Lance && item.GripType == Item.GripTypes.TwoHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Axe && item.GripType == Item.GripTypes.TwoHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Rod && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Book && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Orb && item.GripType == Item.GripTypes.OneHand) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Twohand_Rod && item.GripType == Item.GripTypes.TwoHand))
      {
        return true;
      }

      return false;
    }

    if (equip_type == Fix.EquipType.SubWeapon)
    {
      if ((this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Shield) ||
          (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Shield))
      {
        return true;
      }

      return false;
    }

    if (equip_type == Fix.EquipType.Armor)
    {
      if ((this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Heavy_Armor) ||
          (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Middle_Armor) ||
          (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Light_Armor) ||
          (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Light_Armor) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Middle_Armor) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Light_Armor))
      {
        return true;
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

  public void GainSoulPoint()
  {
    this.CurrentSoulPoint += 1;
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

  public BuffImage IsStun
  {
    get { return SearchBuff(Fix.EFFECT_STUN); }
  }

  public BuffImage IsBind
  {
    get { return SearchBuff(Fix.EFFECT_BIND); }
  }

  public BuffImage IsSilent
  {
    get { return SearchBuff(Fix.EFFECT_SILENT); }
  }

  public BuffImage IsSleep
  {
    get { return SearchBuff(Fix.EFFECT_SLEEP); }
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

  public BuffImage IsShadowBlast
  {
    get { return SearchBuff(Fix.SHADOW_BLAST); }
  }

  public BuffImage IsHunterShot
  {
    get { return SearchBuff(Fix.HUNTER_SHOT); }
  }

  public BuffImage IsHeartOfLife
  {
    get { return SearchBuff(Fix.HEART_OF_LIFE); }
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

  public BuffImage IsEyeOfTheIsshin
  {
    get { return SearchBuff(Fix.EYE_OF_THE_ISSHIN); }
  }

  public BuffImage IsStormArmor
  {
    get { return SearchBuff(Fix.STORM_ARMOR); }
  }

  public BuffImage IsVoiceOfVigor
  {
    get { return SearchBuff(Fix.VOICE_OF_VIGOR); }
  }

  public BuffImage IsUpFire
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_FIRE); }
  }

  public BuffImage IsUpIce
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_ICE); }
  }

  public BuffImage IsUpLight
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_LIGHT); }
  }

  public BuffImage IsUpShadow
  {
    get { return SearchBuff(Fix.EFFECT_POWERUP_SHADOW); }
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

  public void RemoveStun()
  {
    BuffImage buffImage = SearchBuff(Fix.EFFECT_STUN);
    if (buffImage != null)
    {
      buffImage.RemoveBuff();
    }
  }

  /// <summary>
  /// ディスペル・マジックやピュア・ピュリファイケーション経由でBUFFを除去します。
  /// </summary>
  public void RemoveBuff(int num, ActionCommand.BuffType buff_type)
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
      if (ActionCommand.GetBuffType(buffList[ii].BuffName) == ActionCommand.BuffType.Positive)
      {
        result++;
      }
    }
    return result;
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
    if (this.AirCutter > 0) { list.Add(Fix.AIR_CUTTER); }
    if (this.RockSlam > 0) { list.Add(Fix.ROCK_SLAM); }
    if (this.StraightSmash > 0) { list.Add(Fix.STRAIGHT_SMASH); }
    if (this.HunterShot > 0) { list.Add(Fix.HUNTER_SHOT); }
    if (this.LegStrike > 0) { list.Add(Fix.LEG_STRIKE); }
    if (this.VenomSlash > 0) { list.Add(Fix.VENOM_SLASH); }
    if (this.EnergyBolt > 0) { list.Add(Fix.ENERGY_BOLT); }
    if (this.ShieldBash > 0 ) { list.Add(Fix.SHIELD_BASH); }
    if (this.AuraBurn > 0) { list.Add(Fix.AURA_BURN); }
    if (this.DispelMagic > 0) { list.Add(Fix.DISPEL_MAGIC); }
    if (this.HeartOfLife > 0) { list.Add(Fix.HEART_OF_LIFE); }
    if (this.DarkAura > 0) { list.Add(Fix.DARK_AURA); }
    if (this.TrueSight > 0) { list.Add(Fix.TRUE_SIGHT); }
    if (this.OracleCommand > 0) { list.Add(Fix.ORACLE_COMMAND); }

    if (this.FlameBlade > 0) { list.Add(Fix.FLAME_BLADE); }
    if (this.PurePurification > 0) { list.Add(Fix.PURE_PURIFICATION); }
    if (this.DivineCircle > 0) { list.Add(Fix.DIVINE_CIRCLE); }
    if (this.BloodSign > 0) { list.Add(Fix.BLOOD_SIGN); }
    if (this.StormArmor > 0) { list.Add(Fix.STORM_ARMOR); }
    if (this.SoldWall > 0) { list.Add(Fix.SOLID_WALL); }
    if (this.StanceOfTheBlade > 0) { list.Add(Fix.STANCE_OF_THE_BLADE); }
    if (this.MultipleShot > 0) { list.Add(Fix.MULTIPLE_SHOT); }
    if (this.SpeedStep > 0) { list.Add(Fix.SPEED_STEP); }
    if (this.InvisibleBind > 0) { list.Add(Fix.INVISIBLE_BIND); }
    if (this.IdeologyOfSophistication > 0) { list.Add(Fix.IDEOLOGY_OF_SOPHISTICATION); }
    if (this.StanceOfTheGuard > 0){ list. Add(Fix.STANCE_OF_THE_GUARD); }
    if (this.SkyShield > 0) { list.Add(Fix.SKY_SHIELD); }
    if (this.FlashCounter > 0) { list.Add(Fix.FLASH_COUNTER); }
    if (this.FortuneSpirit > 0) { list.Add(Fix.FORTUNE_SPIRIT); }
    if (this.StanceOfTheShade > 0) { list.Add(Fix.STANCE_OF_THE_SHADE); }
    if (this.LaylineSchema > 0) { list.Add(Fix.LAYLINE_SCHEMA); }
    if (this.SpiritualRest > 0) { list.Add(Fix.SPIRITUAL_REST); }

    return list;
  }

  public List<string> GetAvailableListItem()
  {
    List<string> list = new List<string>();
    if (One.TF.FindBackPackItem(Fix.SMALL_RED_POTION)) { list.Add(Fix.SMALL_RED_POTION); }
    if (One.TF.FindBackPackItem(Fix.NORMAL_RED_POTION)) { list.Add(Fix.NORMAL_RED_POTION); }
    if (One.TF.FindBackPackItem(Fix.LARGE_RED_POTION)) { list.Add(Fix.LARGE_RED_POTION); }
    if (One.TF.FindBackPackItem(Fix.HUGE_RED_POTION)) { list.Add(Fix.HUGE_RED_POTION); }
    if (One.TF.FindBackPackItem(Fix.HQ_RED_POTION)) { list.Add(Fix.HQ_RED_POTION); }
    if (One.TF.FindBackPackItem(Fix.THQ_RED_POTION)) { list.Add(Fix.THQ_RED_POTION); }
    if (One.TF.FindBackPackItem(Fix.PERFECT_RED_POTION)) { list.Add(Fix.PERFECT_RED_POTION); }
    if (One.TF.FindBackPackItem(Fix.SMALL_BLUE_POTION)) { list.Add(Fix.SMALL_BLUE_POTION); }
    if (One.TF.FindBackPackItem(Fix.NORMAL_BLUE_POTION)) { list.Add(Fix.NORMAL_BLUE_POTION); }
    if (One.TF.FindBackPackItem(Fix.LARGE_BLUE_POTION)) { list.Add(Fix.LARGE_BLUE_POTION); }
    if (One.TF.FindBackPackItem(Fix.HUGE_BLUE_POTION)) { list.Add(Fix.HUGE_BLUE_POTION); }
    if (One.TF.FindBackPackItem(Fix.HQ_BLUE_POTION)) { list.Add(Fix.HQ_BLUE_POTION); }
    if (One.TF.FindBackPackItem(Fix.THQ_BLUE_POTION)) { list.Add(Fix.THQ_BLUE_POTION); }
    if (One.TF.FindBackPackItem(Fix.PERFECT_BLUE_POTION)) { list.Add(Fix.PERFECT_BLUE_POTION); }
    if (One.TF.FindBackPackItem(Fix.PURE_CLEAN_WATER)) { list.Add(Fix.PURE_CLEAN_WATER); }
    return list;
  }

  public List<string> GetAvailableListArchetype()
  {
    // todo ストーリー進行 or レベルアップなどでリスト追加
    List<string> list = new List<string>();
    if (this.FullName == Fix.NAME_EIN_WOLENCE && One.TF.AvailableArchetype_EinWolence)
    {
      list.Add(Fix.ARCHETYPE_EIN_1);
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA && One.TF.AvailableArchetype_LanaAmiria)
    {
      list.Add(Fix.ARCHETYPE_LANA_1);
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA && One.TF.AvailableArchetype_EoneFulnea)
    {
      list.Add(Fix.ARCHETYPE_EONE_1);
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI && One.TF.AvailableArchetype_BillyRaki)
    {
      list.Add(Fix.ARCHETYPE_BILLY_1);
    }
    if (this.FullName == Fix.NAME_ADEL_BRIGANDY && One.TF.AvailableArchetype_AdelBrigandy)
    {
      list.Add(Fix.ARCHETYPE_ADEL_1);
    }
    if (this.FullName == Fix.NAME_SELMOI_RO && One.TF.AvailableArchetype_SelmoiRo)
    {
      list.Add(Fix.ARCHETYPE_RO_1);
    }
    return list;
  }

  public List<string> GetEssenceTreeTitleList()
  {
    List<string> list = new List<string>();
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      list.Add(Fix.STRAIGHT_SMASH_JP + "強化 Ｉ");
      list.Add(Fix.TRUE_SIGHT_JP + "強化 Ｉ");
      list.Add(Fix.SHIELD_BASH_JP + "強化 Ｉ");
      list.Add("防御の構え Ｉ");
    }
    else if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      list.Add(Fix.ICE_NEEDLE_JP + "強化 Ｉ");
      list.Add(Fix.SHADOW_BLAST_JP + "強化 Ｉ");
      list.Add(Fix.DISPEL_MAGIC_JP + "強化 Ｉ");
      list.Add("魔法詠唱の構え Ｉ");
    }
    else if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      list.Add(Fix.FRESH_HEAL_JP + "強化 Ｉ");
      list.Add(Fix.HUNTER_SHOT_JP + "強化 Ｉ");
      list.Add(Fix.AURA_OF_POWER_JP + "強化 Ｉ");
      list.Add("見切りのセンス Ｉ");
    }
    else if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      list.Add(Fix.LEG_STRIKE_JP + "強化 Ｉ");
      list.Add(Fix.FIRE_BALL_JP + "強化 Ｉ");
      list.Add(Fix.HEART_OF_LIFE_JP + "強化 I");
      list.Add("ラッシュの心構え Ｉ");
    }
    else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
    {
    }
    else if (this.FullName == Fix.NAME_SELMOI_RO)
    {
    }
    return list;
  }

  public List<string> GetEssenceTreeDescList()
  {
    List<string> list = new List<string>();
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      list.Add(Fix.STRAIGHT_SMASH_JP + "の威力が５％上昇する。");
      list.Add(Fix.TRUE_SIGHT_JP + "の効果時間が１ターン長くなる。");
      list.Add(Fix.SHIELD_BASH_JP + "によるスタン効果時間が１ターン長くなる。");
      list.Add("防御姿勢時のダメージ軽減率が２％上昇する。");
    }
    else if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      list.Add(Fix.ICE_NEEDLE_JP + "の威力が５％上昇する。");
      list.Add(Fix.SHADOW_BLAST_JP + "による【陰影】効果からの魔法防御を減らす威力が５％上昇する。");
      list.Add(Fix.DISPEL_MAGIC_JP + "による【有益】に属するBUFFを除去する数が１つ増える。");
      list.Add("インスタントの行動が魔法の場合、インスタントゲージが５％残った状態で行動する。");
    }
    else if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      list.Add(Fix.FRESH_HEAL_JP + "の威力が５％上昇する。");
      list.Add(Fix.HUNTER_SHOT_JP + "による【標的】効果からの命中率が１０％上昇する。");
      list.Add(Fix.AURA_OF_POWER_JP + "による【パワー】効果からの物理攻撃を増強する威力が５％上昇する。");
      list.Add("相手から自分に対しての命中率を１０％減らす。");
    }
    else if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      list.Add(Fix.LEG_STRIKE_JP + "の威力が５％上昇する。"); // todo 未検証
      list.Add(Fix.FIRE_BALL_JP + "の威力が５％上昇する。"); // todo 未検証
      list.Add(Fix.HEART_OF_LIFE_JP + "による【生命】効果からのライフ回復量が１０％上昇する。"); // todo 未検証
      list.Add("１回の行動で連続してダメージを伴う攻撃を実行した場合、２回目またはそれ以降の威力が１０％上昇する。"); // todo 未実装
    }
    else if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
    {
    }
    else if (this.FullName == Fix.NAME_SELMOI_RO)
    {
    }
    return list;
  }

  public List<string> GetEssenceTreeIconList()
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
        this.BaseSoulPoint = 10;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Armorer;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Truth;
        this.BattleBackColor = Fix.COLOR_FIRST_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIRST_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_SWORD);
        this.MainArmor = new Item(Fix.BEGINNER_ARMOR);
        this.AvailableSwordman = true;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.StraightSmash = 1;
        this.CurrentImmediateCommand = Fix.SMALL_RED_POTION;
        this.ActionCommandMain = Fix.NORMAL_ATTACK;
        this.ActionCommand1 = Fix.STRAIGHT_SMASH;
        break;

      case Fix.NAME_LANA_AMIRIA:
        this.Level = 1; // 17 + 0
        this.Strength = 3;
        this.Agility = 5;
        this.Intelligence = 4;
        this.Stamina = 2;
        this.Mind = 3;
        this.BaseLife = 25;
        this.BaseSoulPoint = 15;
        this.Job = Fix.JobClass.Magician;
        this.FirstCommandAttribute = Fix.CommandAttribute.Ice;
        this.SecondCommandAttribute = Fix.CommandAttribute.DarkMagic;
        this.ThirdCommandAttribute = Fix.CommandAttribute.MysticForm;
        this.BattleBackColor = Fix.COLOR_SECOND_CHARA;
        this.BattleForeColor = Fix.COLORFORE_SECOND_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_ORB);
        this.MainArmor = new Item(Fix.BEGINNER_ROBE);
        this.AvailableIce = true;
        this.GlobalAction1 = Fix.MAGIC_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.IceNeedle = 1;
        this.CurrentImmediateCommand = Fix.SMALL_RED_POTION;
        this.ActionCommandMain = Fix.MAGIC_ATTACK;
        this.ActionCommand1 = Fix.ICE_NEEDLE;
        break;

      case Fix.NAME_EONE_FULNEA:
        this.Level = 4; // 17 + 9
        this.Strength = 7;
        this.Agility = 8;
        this.Intelligence = 11;
        this.Stamina = 5;
        this.Mind = 4;
        this.BaseLife = 20 + 15; // level4スタートのため、LV2～LV4分を足し算。
        this.BaseSoulPoint = 20 + 9; // level4スタートのため、LV2～LV4分を足し算。
        this.Job = Fix.JobClass.Magician;
        this.FirstCommandAttribute = Fix.CommandAttribute.HolyLight;
        this.SecondCommandAttribute = Fix.CommandAttribute.Archer;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Mindfulness;
        this.BattleBackColor = Fix.COLOR_THIRD_CHARA;
        this.BattleForeColor = Fix.COLORFORE_THIRD_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_ORB);
        this.MainArmor = new Item(Fix.BEGINNER_ROBE);
        this.AvailableHolyLight = true;
        this.FreshHeal = 1;
        this.AvailableArcher = true;
        this.HunterShot = 1;
        this.AvailableEnhanceForm = true;
        this.AuraOfPower = 1;
        this.GlobalAction1 = Fix.MAGIC_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.FRESH_HEAL;
        this.GlobalAction4 = Fix.MAGIC_ATTACK;
        this.ActionCommandMain = Fix.MAGIC_ATTACK;
        this.ActionCommand1 = Fix.FRESH_HEAL;
        this.ActionCommand2 = Fix.HUNTER_SHOT;
        this.ActionCommand3 = Fix.AURA_OF_POWER;
        break;

      case Fix.NAME_BILLY_RAKI:
        this.Level = 10; // 17 + 28
        this.Strength = 17;
        this.Agility = 8;
        this.Intelligence = 5;
        this.Stamina = 10;
        this.Mind = 5;
        this.BaseLife = 30 + 93; // level10スタートのため、LV2～LV10分を足し算。
        this.BaseSoulPoint = 10 + 20; // level10スタートのため、LV2～LV10分を足し算。
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.MartialArts;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Brave;
        this.BattleBackColor = Fix.COLOR_FOURTH_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FOURTH_CHARA;
        this.MainWeapon = new Item(Fix.SMART_CLAW);
        this.MainArmor = new Item(Fix.SMART_CROSS);
        this.AvailableMartialArts = true;
        this.LegStrike = 1;
        this.SpeedStep = 1;
        this.AvailableFire = true;
        this.FireBall = 1;
        this.FlameBlade = 1;
        this.AvailableBrave = true;
        this.HeartOfLife = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.LEG_STRIKE;
        this.GlobalAction4 = Fix.DEFENSE;
        this.ActionCommandMain = Fix.NORMAL_ATTACK;
        this.ActionCommand1 = Fix.LEG_STRIKE;
        this.ActionCommand2 = Fix.FIRE_BALL;
        this.ActionCommand3 = Fix.HEART_OF_LIFE;
        this.ActionCommand4 = Fix.SPEED_STEP;
        break;

      case Fix.NAME_ADEL_BRIGANDY:
        this.Level = 1;
        this.Strength = 6;
        this.Agility = 5;
        this.Intelligence = 7;
        this.Stamina = 6;
        this.Mind = 3;
        this.BaseLife = 40;
        this.BaseSoulPoint = 12;
        this.Job = Fix.JobClass.Seeker;
        this.FirstCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Warrior;
        this.BattleBackColor = Fix.COLOR_FIFTH_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIFTH_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_SWORD);
        this.MainArmor = new Item(Fix.BEGINNER_ARMOR);
        this.AvailableEnhanceForm = true;
        this.AuraOfPower = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.NORMAL_ATTACK;
        this.GlobalAction4 = Fix.MAGIC_ATTACK;
        break;

      case Fix.NAME_CALMANS_OHN:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_MAGI_ZELKIS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_SELMOI_RO:
        this.Level = 1;
        this.Strength = 3;
        this.Agility = 20;
        this.Intelligence = 9;
        this.Stamina = 4;
        this.Mind = 8;
        this.BaseLife = 20;
        this.BaseSoulPoint = 20;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Rogue;
        this.SecondCommandAttribute = Fix.CommandAttribute.Warrior;
        this.ThirdCommandAttribute = Fix.CommandAttribute.MysticForm;
        this.BattleBackColor = Fix.COLOR_FIFTH_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIFTH_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_SWORD);
        this.MainArmor = new Item(Fix.BEGINNER_ARMOR);
        this.AvailableMysticForm = true;
        this.DispelMagic = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.DISPEL_MAGIC;
        this.GlobalAction4 = Fix.DEFENSE;
        break;

      case Fix.NAME_KARTIN_MAI:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_JEDA_ARUS:
        this.Level = 1;
        this.Strength = 7;
        this.Agility = 6;
        this.Intelligence = 7;
        this.Stamina = 4;
        this.Mind = 3;
        this.BaseLife = 30;
        this.BaseSoulPoint = 25;
        this.Job = Fix.JobClass.Seeker;
        this.FirstCommandAttribute = Fix.CommandAttribute.DarkMagic;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_LENE_COLTOS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_PERMA_WARAMY:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_KILT_JORJU:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
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
        this.BaseSoulPoint = 16;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Archer;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_SHUVALTZ_FLORE:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_RVEL_ZELKIS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_VAN_HEHGUSTEL:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_OHRYU_GENMA:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_LADA_MYSTORUS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_SIN_OSCURETE:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_DELVA_TRECKINO:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_ILZINA_MELDIETE:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;
    }

    MaxGain();
  }

  public int LevelupBaseLife()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (Level == 2) { return 7; }
      if (Level == 3) { return 7; }
      if (Level == 4) { return 7; }
      if (Level == 5) { return 10; }
      if (Level == 6) { return 10; }
      if (Level == 7) { return 10; }
      if (Level == 8) { return 14; }
      if (Level == 9) { return 14; }
      if (Level == 10) { return 14; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (Level == 2) { return 6; }
      if (Level == 3) { return 6; }
      if (Level == 4) { return 6; }
      if (Level == 5) { return 9; }
      if (Level == 6) { return 9; }
      if (Level == 7) { return 9; }
      if (Level == 8) { return 12; }
      if (Level == 9) { return 12; }
      if (Level == 10) { return 12; }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (Level == 2) { return 5; }
      if (Level == 3) { return 5; }
      if (Level == 4) { return 5; }
      if (Level == 5) { return 7; }
      if (Level == 6) { return 7; }
      if (Level == 7) { return 7; }
      if (Level == 8) { return 10; }
      if (Level == 9) { return 10; }
      if (Level == 10) { return 10; }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (Level == 2) { return 7; }
      if (Level == 3) { return 7; }
      if (Level == 4) { return 7; }
      if (Level == 5) { return 10; }
      if (Level == 6) { return 10; }
      if (Level == 7) { return 10; }
      if (Level == 8) { return 14; }
      if (Level == 9) { return 14; }
      if (Level == 10) { return 14; }
    }
    return 5;
  }

  public int LevelupBaseSoulPoint()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (Level == 2) { return 2; }
      if (Level == 3) { return 2; }
      if (Level == 4) { return 2; }
      if (Level == 5) { return 2; }
      if (Level == 6) { return 2; }
      if (Level == 7) { return 2; }
      if (Level == 8) { return 2; }
      if (Level == 9) { return 3; }
      if (Level == 10) { return 3; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (Level == 2) { return 3; }
      if (Level == 3) { return 3; }
      if (Level == 4) { return 3; }
      if (Level == 5) { return 3; }
      if (Level == 6) { return 3; }
      if (Level == 7) { return 3; }
      if (Level == 8) { return 3; }
      if (Level == 9) { return 4; }
      if (Level == 10) { return 4; }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (Level == 2) { return 3; }
      if (Level == 3) { return 3; }
      if (Level == 4) { return 3; }
      if (Level == 5) { return 3; }
      if (Level == 6) { return 4; }
      if (Level == 7) { return 4; }
      if (Level == 8) { return 4; }
      if (Level == 9) { return 4; }
      if (Level == 10) { return 5; }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (Level == 2) { return 2; }
      if (Level == 3) { return 2; }
      if (Level == 4) { return 2; }
      if (Level == 5) { return 2; }
      if (Level == 6) { return 2; }
      if (Level == 7) { return 2; }
      if (Level == 8) { return 2; }
      if (Level == 9) { return 3; }
      if (Level == 10) { return 3; }
    }
    return 2;
  }

  public int LevelupRemainPoint()
  {
    if (Level <= 5) { return 3; }
    if (Level <= 10) { return 4; }
    if (Level <= 15) { return 5; }
    if (Level <= 20) { return 6; }

    return 7;
  }

  public int LevelupSoulEssence()
  {
    return 1;
  }

  public string LevelupActionCommand()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      // if (Level == 1) { return Fix.STRAIGHT_SMASH; }
      if (Level == 2) { return Fix.SHIELD_BASH; }
      if (Level == 4) { return Fix.TRUE_SIGHT; }
      if (Level == 7) { return Fix.STANCE_OF_THE_BLADE; }
      if (Level == 10) { return Fix.STANCE_OF_THE_GUARD; }
      if (Level == 15) { return Fix.LAYLINE_SCHEMA; }
      if (Level == 20) { return Fix.DOUBLE_SLASH; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      // if (Level == 1) { return Fix.ICE_NEEDLE; }
      if (Level == 2) { return Fix.SHADOW_BLAST; }
      if (Level == 4) { return Fix.DISPEL_MAGIC; }
      if (Level == 7) { return Fix.PURE_PURIFICATION; }
      if (Level == 10) { return Fix.BLOOD_SIGN; }
      if (Level == 15) { return Fix.FLASH_COUNTER; }
      if (Level == 20) { return Fix.BLUE_BULLET; }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      // if (Level == 1) { return Fix.FRESH_HEAL; }
      if (Level == 2) { return Fix.HUNTER_SHOT; }
      if (Level == 4) { return Fix.AURA_OF_POWER; }
      if (Level == 7) { return Fix.DIVINE_CIRCLE; }
      if (Level == 10) { return Fix.MULTIPLE_SHOT; }
      if (Level == 15) { return Fix.SKY_SHIELD; }
      if (Level == 20) { return Fix.HOLY_BREATH; }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      // if (Level == 1) { return Fix.LEG_STRIKE; }
      if (Level == 2) { return Fix.FIRE_BALL; }
      if (Level == 4) { return Fix.HEART_OF_LIFE; }
      if (Level == 7) { return Fix.SPEED_STEP; }
      if (Level == 10) { return Fix.FLAME_BLADE; }
      if (Level == 15) { return Fix.FORTUNE_SPIRIT; }
      if (Level == 20) { return Fix.BONE_CRUSH; }
    }
    if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
    {
      // if (Level == 1) { return Fix.ENERGY_BOLT; }
      if (Level == 2) { return Fix.ROCK_SLAM; }
      if (Level == 4) { return Fix.ORACLE_COMMAND; }
      if (Level == 7) { return Fix.IDEOLOGY_OF_SOPHISTICATION; }
      if (Level == 10) { return Fix.SOLID_WALL; }
      if (Level == 15) { return Fix.SPIRITUAL_REST; }
      if (Level == 20) { return Fix.SIGIL_OF_THE_PENDING; }
    }
    if (this.FullName == Fix.NAME_SELMOI_RO)
    {
      // if (Level == 1) { return Fix.VENOM_SLASH; }
      if (Level == 2) { return Fix.AIR_CUTTER; }
      if (Level == 4) { return Fix.DARK_AURA; }
      if (Level == 7) { return Fix.INVISIBLE_BIND; }
      if (Level == 10) { return Fix.STORM_ARMOR; }
      if (Level == 15) { return Fix.STANCE_OF_THE_SHADE; }
      if (Level == 20) { return Fix.IRREGULAR_STEP; }
    }
    return String.Empty;
  }

  public bool CheckLevelupGain(int exp_plus)
  {
    if (this.Exp + exp_plus >= this.GetNextExp())
    {
      return true;
    }

    return false;
  }

  public void UpdateLevelup()
  {
    this.Level += 1;

    this.BaseLife += this.LevelupBaseLife();
    this.BaseSoulPoint += this.LevelupBaseSoulPoint();
    this.RemainPoint += this.LevelupRemainPoint();
    this.SoulFragment += this.LevelupSoulEssence();

    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (this.Level == 2)
      {
        this.AvailableArmorer = true;
        this.ShieldBash++;
        ApplyNewCommand(Fix.SHIELD_BASH);
      }
      if (this.Level == 4)
      {
        this.AvailableTruth = true;
        this.TrueSight++;
        ApplyNewCommand(Fix.TRUE_SIGHT);
      }
      if (this.Level == 7)
      {
        this.StanceOfTheBlade++;
        ApplyNewCommand(Fix.STANCE_OF_THE_BLADE);
      }
      if (this.Level == 10)
      {
        this.StanceOfTheGuard++;
        ApplyNewCommand(Fix.STANCE_OF_THE_GUARD);
      }
      if (this.Level == 15)
      {
        this.LaylineSchema++;
        ApplyNewCommand(Fix.LAYLINE_SCHEMA);
      }
      if (this.Level == 20)
      {
        this.DoubleSlash++;
        ApplyNewCommand(Fix.DOUBLE_SLASH);
      }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (this.Level == 2)
      {
        this.AvailableDarkMagic = true;
        this.ShadowBlast++;
        ApplyNewCommand(Fix.SHADOW_BLAST);
      }
      if (this.Level == 4)
      {
        this.AvailableMysticForm = true;
        this.DispelMagic++;
        ApplyNewCommand(Fix.DISPEL_MAGIC);
      }
      if (this.Level == 7)
      {
        this.PurePurification++;
        ApplyNewCommand(Fix.PURE_PURIFICATION);
      }
      if (this.Level == 10)
      {
        this.BloodSign++;
        ApplyNewCommand(Fix.BLOOD_SIGN);
      }
      if (this.Level == 15)
      {
        this.FlashCounter++;
        ApplyNewCommand(Fix.FLASH_COUNTER);
      }
      if (this.Level == 20)
      {
        this.BlueBullet++;
        ApplyNewCommand(Fix.BLUE_BULLET);
      }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (this.Level == 2)
      {
        this.AvailableArcher = true;
        this.HunterShot++;
        ApplyNewCommand(Fix.HUNTER_SHOT);
      }
      if (this.Level == 4)
      {
        this.AvailableEnhanceForm = true;
        this.AuraOfPower++;
        ApplyNewCommand(Fix.AURA_OF_POWER);
      }
      if (this.Level == 7)
      {
        this.DivineCircle++;
        ApplyNewCommand(Fix.DIVINE_CIRCLE);
      }
      if (this.Level == 10)
      {
        this.MultipleShot++;
        ApplyNewCommand(Fix.MULTIPLE_SHOT);
      }
      if (this.Level == 15)
      {
        this.SkyShield++;
        ApplyNewCommand(Fix.SKY_SHIELD);
      }
      if (this.Level == 20)
      {
        this.HolyBreath++;
        ApplyNewCommand(Fix.HOLY_BREATH);
      }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (this.Level == 2)
      {
        this.AvailableFire = true;
        this.FireBall++;
        ApplyNewCommand(Fix.FIRE_BALL);
      }
      if (this.Level == 4)
      {
        this.AvailableBrave = true;
        this.HeartOfLife++;
        ApplyNewCommand(Fix.HEART_OF_LIFE);
      }
      if (this.Level == 7)
      {
        this.SpeedStep++;
        ApplyNewCommand(Fix.SPEED_STEP);
      }
      if (this.Level == 10)
      {
        this.FlameBlade++;
        ApplyNewCommand(Fix.FLAME_BLADE);
      }
      if (this.Level == 15)
      {
        this.FortuneSpirit++;
        ApplyNewCommand(Fix.FORTUNE_SPIRIT);
      }
      if (this.Level == 20)
      {
        this.BoneCrush++;
        ApplyNewCommand(Fix.BONE_CRUSH);
      }
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
      #region "サルン洞窟前草原区域"
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
        SetupParameter(125, 55, 160, 560, 12, 0, 2500, 4000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SPAAAARK);
        list.Add(Fix.COMMAND_SUPER_RANDOM_CANNON);
        list.Add(Fix.COMMAND_ELECTRO_RAILGUN);
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
        this.CannotCritical = true;
        break;

      case Fix.WOOD_ELF:
      case Fix.WOOD_ELF_JP:
        SetupParameter(95, 55, 102, 108, 10, 4, 476, 288);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_WILD_STORM);
        this.CannotCritical = true;
        break;

      case Fix.STINKED_SPORE:
      case Fix.STINKED_SPORE_JP:
        SetupParameter(65, 47, 98, 120, 10, 3, 491, 296);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_YOUKAIEKI);
        this.CannotCritical = true;
        this.TargetSelectType = Fix.TargetSelectType.Behind;
        break;

      case Fix.POISON_FLOG:
      case Fix.POISON_FLOG_JP:
        SetupParameter(101, 53, 71, 112, 10, 9, 512, 302);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_POISON_TONGUE);
        this.CannotCritical = true;
        break;

      case Fix.GIANT_SNAKE:
      case Fix.GIANT_SNAKE_JP:
        SetupParameter(109, 52, 68, 117, 10, 1, 527, 313);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CONSTRICT);
        this.CannotCritical = true;
        break;
      #endregion


      case Fix.RUDE_WATCHDOG:
      case Fix.RUDE_WATCHDOG_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MYSTIC_DRYAD:
      case Fix.MYSTIC_DRYAD_JP:
        SetupParameter(35, 10, 60, 20, 5, 0, 80, 50);
        list.Add(Fix.COMMAND_POISON_RINPUN);
        list.Add(Fix.COMMAND_YOUEN_FIRE);
        list.Add(Fix.COMMAND_BLAZE_DANCE);
        this.CannotCritical = false;
        break;

      case Fix.SHOTGUN_HYUUI:
      case Fix.SHOTGUN_HYUUI_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.SPEEDY_FALCON:
      case Fix.SPEEDY_FALCON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.INNOCENT_FAIRY:
      case Fix.INNOCENT_FAIRY_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.CALM_STAG:
      case Fix.CALM_STAG_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SAVAGE_BEAR:
      case Fix.SAVAGE_BEAR_JP:
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

      case Fix.EXCITED_ELEPHANT:
      case Fix.EXCITED_ELEPHANT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLANSIS_KNIGHT:
      case Fix.FLANSIS_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.GATHERING_LAPTOR:
      case Fix.GATHERING_LAPTOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SYLPH_DANCER:
      case Fix.SYLPH_DANCER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THORN_WARRIOR:
      case Fix.THORN_WARRIOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TOWERING_ENT:
      case Fix.TOWERING_ENT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DISTURB_RHINO:
      case Fix.DISTURB_RHINO_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MIST_PYTHON:
      case Fix.MIST_PYTHON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MUDDLED_PLANT:
      case Fix.MUDDLED_PLANT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.POISON_MARY:
      case Fix.POISON_MARY_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLANSIS_OF_THE_FOREST_QUEEN:
      case Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.DAGGER_FISH:
      case Fix.DAGGER_FISH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLOATING_MANTA:
      case Fix.FLOATING_MANTA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SKYBLUE_BIRD:
      case Fix.SKYBLUE_BIRD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RAINBOW_CLIONE:
      case Fix.RAINBOW_CLIONE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ROLLING_MAGURO:
      case Fix.ROLLING_MAGURO_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LIMBER_SEAEAGLE:
      case Fix.LIMBER_SEAEAGLE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLUFFY_CORAL:
      case Fix.FLUFFY_CORAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BLACK_OCTOPUS:
      case Fix.BLACK_OCTOPUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STEAL_SQUID:
      case Fix.STEAL_SQUID_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_HAND_OF_KRAKEN:
      case Fix.THE_HAND_OF_KRAKEN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.PROUD_VIKING:
      case Fix.PROUD_VIKING_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GAN_GAME:
      case Fix.GAN_GAME_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.JUMPING_KAMASU:
      case Fix.JUMPING_KAMASU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WRECHED_ANEMONE:
      case Fix.WRECHED_ANEMONE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DEEPSEA_HAND:
      case Fix.DEEPSEA_HAND_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ASSULT_SERPENT:
      case Fix.ASSULT_SERPENT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ESCORT_HERMIT_CLUB:
      case Fix.ESCORT_HERMIT_CLUB_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GLUTTONY_COELACANTH:
      case Fix.GLUTTONY_COELACANTH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GIANT_SEA_SPIDER:
      case Fix.GIANT_SEA_SPIDER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SHELL_THE_SWORD_KNIGHT:
      case Fix.SHELL_THE_SWORD_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.MOGUL_MANTA:
      case Fix.MOGUL_MANTA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WEEPING_MIST:
      case Fix.WEEPING_MIST_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.AMBUSH_ANGLERFISH:
      case Fix.AMBUSH_ANGLERFISH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EMERALD_LOBSTER:
      case Fix.EMERALD_LOBSTER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BIGMOUSE_JOE:
      case Fix.BIGMOUSE_JOE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RAMPAGE_BIGSHARK:
      case Fix.RAMPAGE_BIGSHARK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STICKY_STARFISH:
      case Fix.STICKY_STARFISH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SEA_ELEMENTAL:
      case Fix.SEA_ELEMENTAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EDGED_HIGH_SHARK:
      case Fix.EDGED_HIGH_SHARK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GUARDIAN_ROYAL_NAGA:
      case Fix.GUARDIAN_ROYAL_NAGA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.THOUGHTFUL_NAUTILUS:
      case Fix.THOUGHTFUL_NAUTILUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FEROCIOUS_WHALE:
      case Fix.FEROCIOUS_WHALE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GHOST_SHIP:
      case Fix.GHOST_SHIP_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RECKLESS_WALRUS:
      case Fix.RECKLESS_WALRUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BEAUTY_SEA_LILY:
      case Fix.BEAUTY_SEA_LILY_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DEFENSIVE_DATSU:
      case Fix.DEFENSIVE_DATSU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SEA_STAR_KNIGHT:
      case Fix.SEA_STAR_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SEA_SONG_MARMAID:
      case Fix.SEA_SONG_MARMAID_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BRILLIANT_SEA_PRINCE:
      case Fix.BRILLIANT_SEA_PRINCE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.VELGAS_THE_KING_OF_SEA_STAR:
      case Fix.VELGAS_THE_KING_OF_SEA_STAR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.STONE_STATUE_SEIHITSU:
      case Fix.STONE_STATUE_SEIHITSU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;


      case Fix.DISTORTED_SENSOR:
      case Fix.DISTORTED_SENSOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_GALVADAZER:
      case Fix.THE_GALVADAZER_JP:
        SetupParameter(150, 120, 60, 420, 100, 10, 7500, 2000);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.SWIFT_EAGLE:
      case Fix.SWIFT_EAGLE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EASTERN_GOLEM:
      case Fix.EASTERN_GOLEM_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WESTERN_GOLEM:
      case Fix.WESTERN_GOLEM_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WIND_ELEMENTAL:
      case Fix.WIND_ELEMENTAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SKY_KNIGHT:
      case Fix.SKY_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_PURPLE_HIKARIGOKE:
      case Fix.THE_PURPLE_HIKARIGOKE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MYSTICAL_UNICORN:
      case Fix.MYSTICAL_UNICORN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TRIAL_HERMIT:
      case Fix.TRIAL_HERMIT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STORM_BIRDMAN:
      case Fix.STORM_BIRDMAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_BLUE_LAVA_EYE:
      case Fix.THE_BLUE_LAVA_EYE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.FLYING_CURTAIN:
      case Fix.FLYING_CURTAIN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LUMINOUS_HAWK:
      case Fix.LUMINOUS_HAWK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.AETHER_GUST:
      case Fix.AETHER_GUST_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WHIRLWIND_KITSUNE:
      case Fix.WHIRLWIND_KITSUNE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THUNDER_LION:
      case Fix.THUNDER_LION_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SAINT_PEGASUS:
      case Fix.SAINT_PEGASUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DREAM_WALKER:
      case Fix.DREAM_WALKER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.IVORY_STATUE:
      case Fix.IVORY_STATUE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STUBBORN_SAGE:
      case Fix.STUBBORN_SAGE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LIGHT_THUNDER_LANCEBOLTS:
      case Fix.LIGHT_THUNDER_LANCEBOLTS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.BOMB_BALLON:
      case Fix.BOMB_BALLON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.OBSERVANT_HERALD:
      case Fix.OBSERVANT_HERALD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TOWER_SCOUT:
      case Fix.TOWER_SCOUT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MIST_SALVAGER:
      case Fix.MIST_SALVAGER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WINGSPAN_RANGER:
      case Fix.WINGSPAN_RANGER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.HARDENED_GRIFFIN:
      case Fix.HARDENED_GRIFFIN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MAJESTIC_CLOUD:
      case Fix.MAJESTIC_CLOUD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.PRISMA_SPHERE:
      case Fix.PRISMA_SPHERE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.VEIL_FORTUNE_WIZARD:
      case Fix.VEIL_FORTUNE_WIZARD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_YODIRIAN:
      case Fix.THE_YODIRIAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 10, 7500, 2000);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.IMPERIAL_KNIGHT:
      case Fix.IMPERIAL_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.VENERABLE_WIZARD:
      case Fix.VENERABLE_WIZARD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.HOLLOW_SPECTOR:
      case Fix.HOLLOW_SPECTOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
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

      case Fix.MOVING_CANNON:
      case Fix.MOVING_CANNON_JP:
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

      case Fix.MASCLEWARRIOR_HARDIL:
      case Fix.MASCLEWARRIOR_HARDIL_JP:
        SetupParameter(1, 1, 1, 1, 1, 10, 7500, 2000);
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

      case Fix.RAGE_TIGER:
      case Fix.RAGE_TIGER_JP:
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

      case Fix.WISDOM_CENTAURUS:
      case Fix.WISDOM_CENTAURUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.UNKNOWN_FLOATING_BALL:
      case Fix.UNKNOWN_FLOATING_BALL_JP:
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

      case Fix.HUGE_MAGICIAN_ZAGAN:
      case Fix.HUGE_MAGICIAN_ZAGAN_JP:
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

    }

    // debug
    //this.Strength = 1;
    //this.Intelligence = 1;
    // debug 

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
    this._exp = exp;
    this._gold = gold;
  }

  // 敵の行動コマンドを決定する。
  // コマンド名のみではなくターゲット選定なども含める。
  public void ChooseCommand(List<Character> ally_group, List<Character> opponent_group)
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

      case Fix.MAGICAL_HAIL_GUN:
        this.AI_Phase++;
        if (this.AI_Phase >= 4) { this.AI_Phase = 0; }

        if (this.AI_Phase == 0)
        {
          current.Add(Fix.MAGIC_ATTACK);
        }
        else if (this.AI_Phase == 1)
        {
          current.Add(Fix.COMMAND_SUPER_RANDOM_CANNON);
        }
        else if (this.AI_Phase == 2)
        {
          current.Add(Fix.COMMAND_SPAAAARK);
        }
        else if (this.AI_Phase == 3)
        {
          current.Add(Fix.COMMAND_ELECTRO_RAILGUN);
        }

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
        List<string> currentList = GetActionCommandList();
        currentList.Add(this.ActionCommandMain);
        result = RandomChoice(currentList);
        break;
    }

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

    this.Decision = true;
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

}
