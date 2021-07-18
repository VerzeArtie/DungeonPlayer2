using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class Character : MonoBehaviour
{
  // Battle GUI-View object
  public NodeBattleChara objGroup = null;
  public GameObject objArrow = null;
  public Button objMainButton = null;
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

  [SerializeField] protected string _fullName = string.Empty;
  public string FullName
  {
    set { _fullName = value; }
    get { return _fullName; }
  }


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

  [SerializeField] protected List<string> _actionCommand = new List<string>();
  public List<string> ActionCommandList
  {
    set { _actionCommand = value; }
    get { return _actionCommand; }
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
      return _baseSoulPoint + TotalMind * 3;
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
  public int TrueSight { set { if (value >= 0) { _TrueSight = value; } } get { return _TrueSight; } }
  [SerializeField] protected int _HeartOfLife = 0;
  public int HeartOfLife { set { if (value >= 0) { _HeartOfLife = value; } } get { return _HeartOfLife; } }
  [SerializeField] protected int _DarkAura = 0;
  public int DarkAura { set { if (value >= 0) { _DarkAura = value; } } get { return _DarkAura; } }
  [SerializeField] protected int _OracleCommand = 0;
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
  [SerializeField] protected int _LaylineSchema = 0;
  public int LaylineSchema { set { if (value >= 0) { _LaylineSchema = value; } } get { return _LaylineSchema; } }
  [SerializeField] protected int _FortuneSpirit = 0;
  public int FortuneSpirit { set { if (value >= 0) { _FortuneSpirit = value; } } get { return _FortuneSpirit; } }
  [SerializeField] protected int _StanceOfTheShade = 0;
  public int StanceOfTheShade { set { if (value >= 0) { _StanceOfTheShade = value; } } get { return _StanceOfTheShade; } }
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
  [SerializeField] protected int _WordOfPower = 0;
  public int WordOfPower { set { if (value >= 0) { _WordOfPower = value; } } get { return _WordOfPower; } }
  [SerializeField] protected int _VoiceOfVigor = 0;
  public int VoiceOfVigor { set { if (value >= 0) { _VoiceOfVigor = value; } } get { return _VoiceOfVigor; } }
  [SerializeField] protected int _KillingWave = 0;
  public int KillingWave { set { if (value >= 0) { _KillingWave = value; } } get { return _KillingWave; } }
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
  [SerializeField] protected int _WillAwakening = 0;
  public int WillAwakening { set { if (value >= 0) { _WillAwakening = value; } } get { return _WillAwakening; } }
  [SerializeField] protected int _AuraBurn = 0;
  public int AuraBurn { set { if (value >= 0) { _AuraBurn = value; } } get { return _AuraBurn; } }
  [SerializeField] protected int _LevelEater = 0;
  public int LevelEater { set { if (value >= 0) { _LevelEater = value; } } get { return _LevelEater; } }
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
  [SerializeField] protected int _EagleEye = 0;
  public int EagleEye { set { if (value >= 0) { _EagleEye = value; } } get { return _EagleEye; } }
  [SerializeField] protected int _EverflowMind = 0;
  public int EverflowMind { set { if (value >= 0) { _EverflowMind = value; } } get { return _EverflowMind; } }
  [SerializeField] protected int _AbyssEye = 0;
  public int AbyssEye { set { if (value >= 0) { _AbyssEye = value; } } get { return _AbyssEye; } }
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
  [SerializeField] protected int _SigilOfTheFaith = 0;
  public int SigilOfTheFaith { set { if (value >= 0) { _SigilOfTheFaith = value; } } get { return _SigilOfTheFaith; } }
  [SerializeField] protected int _SoulShout = 0;
  public int SoulShout { set { if (value >= 0) { _SoulShout = value; } } get { return _SoulShout; } }
  [SerializeField] protected int _AvengerPromise = 0;
  public int AvengerPromise { set { if (value >= 0) { _AvengerPromise = value; } } get { return _AvengerPromise; } }
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
  [SerializeField] protected int _StanceOfTheKokoroe = 0;
  public int StanceOfTheKokoroe { set { if (value >= 0) { _StanceOfTheKokoroe = value; } } get { return _StanceOfTheKokoroe; } }
  [SerializeField] protected int _OverwhelmingDestiny = 0;
  public int OverwhelmingDestiny { set { if (value >= 0) { _OverwhelmingDestiny = value; } } get { return _OverwhelmingDestiny; } }
  [SerializeField] protected int _DemonContract = 0;
  public int DemonContract { set { if (value >= 0) { _DemonContract = value; } } get { return _DemonContract; } }
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
  [SerializeField] protected int _EyeOfTheTruth = 0;
  public int EyeOfTheTruth
  {
    set
    {
      if (value >= 0)
      {
        _EyeOfTheTruth = value;
      }
    }
    get { return _EyeOfTheTruth; }
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
    int result = 0;
    if (this.Level == 1) { result = 250; }
    else if (this.Level == 2) { result = 600; }
    else if (this.Level == 3) { result = 1000; }
    else if (this.Level == 4) { result = 1500; }
    else if (this.Level == 5) { result = 2000; }
    else if (this.Level == 6) { result = 2600; }
    else if (this.Level == 7) { result = 3200; }
    else if (this.Level == 8) { result = 4000; }
    else if (this.Level == 9) { result = 5000; }
    else { result = 9999999; }
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
    this._exp = 0;
  }

  public void GainExp(int gain_exp)
  {
    if (this.GetNextExp() - this._exp > 0)
    {
      this._exp += gain_exp;

      if (this._exp >= this.GetNextExp())
      {
        int gainRemainPoint = 0;
        if (this.Level == 1) { gainRemainPoint = 3; }
        else if (this.Level == 2) { gainRemainPoint = 4; }
        else if (this.Level == 3) { gainRemainPoint = 5; }
        else if (this.Level == 4) { gainRemainPoint = 6; }
        else if (this.Level == 5) { gainRemainPoint = 7; }
        else if (this.Level == 6) { gainRemainPoint = 8; }
        else if (this.Level == 7) { gainRemainPoint = 10; }
        else if (this.Level == 8) { gainRemainPoint = 12; }
        else if (this.Level == 9) { gainRemainPoint = 14; }
        else if (this.Level == 10) { gainRemainPoint = 16; }
        else if (this.Level == 11) { gainRemainPoint = 18; }
        else if (this.Level == 12) { gainRemainPoint = 20; }
        else { gainRemainPoint = 20; }

        this._remainPoint += gainRemainPoint;
      }
    }
  }

  public bool Equipable(Fix.EquipType equip_type, Item item)
  {
    if (equip_type == Fix.EquipType.MainWeapon)
    {
      // サブウェポンを装備している場合、メインは片手持ちしか装備できない。
      if (this.SubWeapon != null)
      {
        if ((this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Sword && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Lance && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Axe && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Claw && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Onehand_Rod && item.GripType == Item.GripTypes.OneHand))
        {
          return true;
        }
        if ((this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Onehand_Rod && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Onehand_Book && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Onehand_Orb && item.GripType == Item.GripTypes.OneHand))
        {
          return true;
        }
        if ((this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Sword && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Lance && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Axe && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Claw && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Rod && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Book && item.GripType == Item.GripTypes.OneHand) ||
            (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Onehand_Orb && item.GripType == Item.GripTypes.OneHand))
        {
          return true;
        }
        return false;
      }

      // サブウェポンを装備していない場合、両手持ちは装備できる。
      if (this.SubWeapon == null)
      {
        if ((this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Sword) ||
           (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Lance) ||
           (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Axe) ||
           (this.Job == Fix.JobClass.Fighter && item.ItemType == Item.ItemTypes.Twohand_Bow))
        {
          return true;
        }
        if ((this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Twohand_Rod))
        {
          return true;
        }
        // Seekerは両手持ちを装備できない。
        // if ((this.Job == Fix.JobClass.Seeker && ...)

        return false;
      }

      return false;
    }

    if (equip_type == Fix.EquipType.SubWeapon)
    {
      // 両手持ちをメインに装備している場合、サブウェポンは装備できない。
      if (this.MainWeapon != null && this.MainWeapon.GripType == Item.GripTypes.TwoHand)
      {
        return false;
      }

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
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Middle_Armor) ||
          (this.Job == Fix.JobClass.Seeker && item.ItemType == Item.ItemTypes.Light_Armor) ||
          (this.Job == Fix.JobClass.Magician && item.ItemType == Item.ItemTypes.Light_Armor))
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

  public BuffImage IsResistStun
  {
    get { return SearchBuff(Fix.BUFF_RESIST_STUN); }
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

  public BuffImage IsDizzy
  {
    get { return SearchBuff(Fix.EFFECT_DIZZY); }
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

  public BuffImage IsEyeOfTheTruth
  {
    get { return SearchBuff(Fix.EYE_OF_THE_TRUTH); }
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

  public BuffImage IsPhysicalDefenseDown
  {
    get { return SearchBuff(Fix.BUFF_PD_DOWN); }
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
  #endregion
}
