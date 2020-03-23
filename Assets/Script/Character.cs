using System.Collections;
using System.Collections.Generic;
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
  public Text txtActionCommand = null;
  public NodeActionPanel objParentActionPanel = null;
  public GameObject groupActionButton = null;
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
  public GameObject objBuffPanel = null;

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

  [SerializeField] protected string _currentActionCommand = string.Empty;
  public string CurrentActionCommand
  {
    set
    {
      if (value == Fix.Defense)
      {
        Debug.Log("_currentActionCommand isDefense true");
        this._isDefense = true;
      }
      else
      {
        Debug.Log("_currentActionCommand isDefense false");
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

  //[SerializeField] protected int _maxLife = 0;
  public int MaxLife
  {
    get
    {
      return _baseLife + TotalStamina * 10;
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

  [SerializeField] protected int _FireBolt = 0;
  public int FireBolt
  {
    set
    {
      if (value >= 0)
      {
        _FireBolt = value;
      }
    }
    get { return _FireBolt; }
  }
  [SerializeField] protected int _FlameBlade = 0;
  public int FlameBlade
  {
    set
    {
      if (value >= 0)
      {
        _FlameBlade = value;
      }
    }
    get { return _FlameBlade; }
  }
  [SerializeField] protected int _MeteorBullet = 0;
  public int MeteorBullet
  {
    set
    {
      if (value >= 0)
      {
        _MeteorBullet = value;
      }
    }
    get { return _MeteorBullet; }
  }
  [SerializeField] protected int _FlameStrike = 0;
  public int FlameStrike
  {
    set
    {
      if (value >= 0)
      {
        _FlameStrike = value;
      }
    }
    get { return _FlameStrike; }
  }
  [SerializeField] protected int _LavaAnnihilation = 0;
  public int LavaAnnihilation
  {
    set
    {
      if (value >= 0)
      {
        _LavaAnnihilation = value;
      }
    }
    get { return _LavaAnnihilation; }
  }
  [SerializeField] protected int _IceNeedle = 0;
  public int IceNeedle
  {
    set
    {
      if (value >= 0)
      {
        _IceNeedle = value;
      }
    }
    get { return _IceNeedle; }
  }
  [SerializeField] protected int _PurePurification = 0;
  public int PurePurification
  {
    set
    {
      if (value >= 0)
      {
        _PurePurification = value;
      }
    }
    get { return _PurePurification; }
  }
  [SerializeField] protected int _BlueBullet = 0;
  public int BlueBullet
  {
    set
    {
      if (value >= 0)
      {
        _BlueBullet = value;
      }
    }
    get { return _BlueBullet; }
  }
  [SerializeField] protected int _FreezingCube = 0;
  public int FreezingCube
  {
    set
    {
      if (value >= 0)
      {
        _FreezingCube = value;
      }
    }
    get { return _FreezingCube; }
  }
  [SerializeField] protected int _FrostLance = 0;
  public int FrostLance
  {
    set
    {
      if (value >= 0)
      {
        _FrostLance = value;
      }
    }
    get { return _FrostLance; }
  }
  [SerializeField] protected int _FreshHeal = 0;
  public int FreshHeal
  {
    set
    {
      if (value >= 0)
      {
        _FreshHeal = value;
      }
    }
    get { return _FreshHeal; }
  }
  [SerializeField] protected int _DivineCircle = 0;
  public int DivineCircle
  {
    set
    {
      if (value >= 0)
      {
        _DivineCircle = value;
      }
    }
    get { return _DivineCircle; }
  }
  [SerializeField] protected int _HolyBreath = 0;
  public int HolyBreath
  {
    set
    {
      if (value >= 0)
      {
        _HolyBreath = value;
      }
    }
    get { return _HolyBreath; }
  }
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
  [SerializeField] protected int _ShadowBlast = 0;
  public int ShadowBlast
  {
    set
    {
      if (value >= 0)
      {
        _ShadowBlast = value;
      }
    }
    get { return _ShadowBlast; }
  }
  [SerializeField] protected int _BloodSign = 0;
  public int BloodSign
  {
    set
    {
      if (value >= 0)
      {
        _BloodSign = value;
      }
    }
    get { return _BloodSign; }
  }
  [SerializeField] protected int _DeathScythe = 0;
  public int DeathScythe
  {
    set
    {
      if (value >= 0)
      {
        _DeathScythe = value;
      }
    }
    get { return _DeathScythe; }
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
  [SerializeField] protected int _AbyssEye = 0;
  public int AbyssEye
  {
    set
    {
      if (value >= 0)
      {
        _AbyssEye = value;
      }
    }
    get { return _AbyssEye; }
  }
  [SerializeField] protected int _StraightSmash = 0;
  public int StraightSmash
  {
    set
    {
      if (value >= 0)
      {
        _StraightSmash = value;
      }
    }
    get { return _StraightSmash; }
  }
  [SerializeField] protected int _StanceOfTheBlade = 0;
  public int StanceOfTheBlade
  {
    set
    {
      if (value >= 0)
      {
        _StanceOfTheBlade = value;
      }
    }
    get { return _StanceOfTheBlade; }
  }
  [SerializeField] protected int _DoubleSlash = 0;
  public int DoubleSlash
  {
    set
    {
      if (value >= 0)
      {
        _DoubleSlash = value;
      }
    }
    get { return _DoubleSlash; }
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
  [SerializeField] protected int _KineticSmash = 0;
  public int KineticSmash
  {
    set
    {
      if (value >= 0)
      {
        _KineticSmash = value;
      }
    }
    get { return _KineticSmash; }
  }
  [SerializeField] protected int _ShieldBash = 0;
  public int ShieldBash
  {
    set
    {
      if (value >= 0)
      {
        _ShieldBash = value;
      }
    }
    get { return _ShieldBash; }
  }
  [SerializeField] protected int _StanceOfTheGuard = 0;
  public int StanceOfTheGuard
  {
    set
    {
      if (value >= 0)
      {
        _StanceOfTheGuard = value;
      }
    }
    get { return _StanceOfTheGuard; }
  }
  [SerializeField] protected int _ConcussiveHit = 0;
  public int ConcussiveHit
  {
    set
    {
      if (value >= 0)
      {
        _ConcussiveHit = value;
      }
    }
    get { return _ConcussiveHit; }
  }
  [SerializeField] protected int _DominationField = 0;
  public int DominationField
  {
    set
    {
      if (value >= 0)
      {
        _DominationField = value;
      }
    }
    get { return _DominationField; }
  }
  [SerializeField] protected int _OathOfAegis = 0;
  public int OathOfAegis
  {
    set
    {
      if (value >= 0)
      {
        _OathOfAegis = value;
      }
    }
    get { return _OathOfAegis; }
  }
  [SerializeField] protected int _HunterShot = 0;
  public int HunterShot
  {
    set
    {
      if (value >= 0)
      {
        _HunterShot = value;
      }
    }
    get { return _HunterShot; }
  }
  [SerializeField] protected int _MultipleShot = 0;
  public int MultipleShot
  {
    set
    {
      if (value >= 0)
      {
        _MultipleShot = value;
      }
    }
    get { return _MultipleShot; }
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
  [SerializeField] protected int _PiercingArrow = 0;
  public int PiercingArrow
  {
    set
    {
      if (value >= 0)
      {
        _PiercingArrow = value;
      }
    }
    get { return _PiercingArrow; }
  }
  [SerializeField] protected int _VenomSlash = 0;
  public int VenomSlash
  {
    set
    {
      if (value >= 0)
      {
        _VenomSlash = value;
      }
    }
    get { return _VenomSlash; }
  }
  [SerializeField] protected int _InvisibleBind = 0;
  public int InvisibleBind
  {
    set
    {
      if (value >= 0)
      {
        _InvisibleBind = value;
      }
    }
    get { return _InvisibleBind; }
  }
  [SerializeField] protected int _IrregularStep = 0;
  public int IrregularStep
  {
    set
    {
      if (value >= 0)
      {
        _IrregularStep = value;
      }
    }
    get { return _IrregularStep; }
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
  [SerializeField] protected int _AssassinationHit = 0;
  public int AssassinationHit
  {
    set
    {
      if (value >= 0)
      {
        _AssassinationHit = value;
      }
    }
    get { return _AssassinationHit; }
  }
  [SerializeField] protected int _AuraOfPower = 0;
  public int AuraOfPower
  {
    set
    {
      if (value >= 0)
      {
        _AuraOfPower = value;
      }
    }
    get { return _AuraOfPower; }
  }
  [SerializeField] protected int _SkyShield = 0;
  public int SkyShield
  {
    set
    {
      if (value >= 0)
      {
        _SkyShield = value;
      }
    }
    get { return _SkyShield; }
  }
  [SerializeField] protected int _StormArmor = 0;
  public int StormArmor
  {
    set
    {
      if (value >= 0)
      {
        _StormArmor = value;
      }
    }
    get { return _StormArmor; }
  }
  [SerializeField] protected int _AetherDrive = 0;
  public int AetherDrive
  {
    set
    {
      if (value >= 0)
      {
        _AetherDrive = value;
      }
    }
    get { return _AetherDrive; }
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
  [SerializeField] protected int _DispelMagic = 0;
  public int DispelMagic
  {
    set
    {
      if (value >= 0)
      {
        _DispelMagic = value;
      }
    }
    get { return _DispelMagic; }
  }
  [SerializeField] protected int _FlashCounter = 0;
  public int FlashCounter
  {
    set
    {
      if (value >= 0)
      {
        _FlashCounter = value;
      }
    }
    get { return _FlashCounter; }
  }
  [SerializeField] protected int _MuteImpulse = 0;
  public int MuteImpulse
  {
    set
    {
      if (value >= 0)
      {
        _MuteImpulse = value;
      }
    }
    get { return _MuteImpulse; }
  }
  [SerializeField] protected int _DetachmentFault = 0;
  public int DetachmentFault
  {
    set
    {
      if (value >= 0)
      {
        _DetachmentFault = value;
      }
    }
    get { return _DetachmentFault; }
  }
  [SerializeField] protected int _PhantomOboro = 0;
  public int PhantomOboro
  {
    set
    {
      if (value >= 0)
      {
        _PhantomOboro = value;
      }
    }
    get { return _PhantomOboro; }
  }
  [SerializeField] protected int _HeartOfLife = 0;
  public int HeartOfLife
  {
    set
    {
      if (value >= 0)
      {
        _HeartOfLife = value;
      }
    }
    get { return _HeartOfLife; }
  }
  [SerializeField] protected int _FortuneSpirit = 0;
  public int FortuneSpirit
  {
    set
    {
      if (value >= 0)
      {
        _FortuneSpirit = value;
      }
    }
    get { return _FortuneSpirit; }
  }
  [SerializeField] protected int _VoiceOfVigor = 0;
  public int VoiceOfVigor
  {
    set
    {
      if (value >= 0)
      {
        _VoiceOfVigor = value;
      }
    }
    get { return _VoiceOfVigor; }
  }
  [SerializeField] protected int _SigilOfTheFaith = 0;
  public int SigilOfTheFaith
  {
    set
    {
      if (value >= 0)
      {
        _SigilOfTheFaith = value;
      }
    }
    get { return _SigilOfTheFaith; }
  }
  [SerializeField] protected int _RagingStorm = 0;
  public int RagingStorm
  {
    set
    {
      if (value >= 0)
      {
        _RagingStorm = value;
      }
    }
    get { return _RagingStorm; }
  }
  [SerializeField] protected int _OracleCommand = 0;
  public int OracleCommand
  {
    set
    {
      if (value >= 0)
      {
        _OracleCommand = value;
      }
    }
    get { return _OracleCommand; }
  }
  [SerializeField] protected int _SpiritualRest = 0;
  public int SpiritualRest
  {
    set
    {
      if (value >= 0)
      {
        _SpiritualRest = value;
      }
    }
    get { return _SpiritualRest; }
  }
  [SerializeField] protected int _ZeroImmunity = 0;
  public int ZeroImmunity
  {
    set
    {
      if (value >= 0)
      {
        _ZeroImmunity = value;
      }
    }
    get { return _ZeroImmunity; }
  }
  [SerializeField] protected int _EssenceOverflow = 0;
  public int EssenceOverflow
  {
    set
    {
      if (value >= 0)
      {
        _EssenceOverflow = value;
      }
    }
    get { return _EssenceOverflow; }
  }
  [SerializeField] protected int _InnerInspiration = 0;
  public int InnerInspiration
  {
    set
    {
      if (value >= 0)
      {
        _InnerInspiration = value;
      }
    }
    get { return _InnerInspiration; }
  }
  #endregion

  #region "Method"
  public void MaxGain()
  {
    _currentLife = MaxLife;

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
    if (this.objCurrentInstangGauge_AC != null)
    {
      this.objCurrentInstangGauge_AC.rectTransform.localScale = new Vector2(dx, 1.0f);
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

  public int GetRemainPoint()
  {
    int result = 0;
    if (this.Level == 1) { result = 3; }
    else if (this.Level == 2) { result = 4; }
    else if (this.Level == 3) { result = 5; }
    else if (this.Level == 4) { result = 6; }
    else if (this.Level == 5) { result = 7; }
    else if (this.Level == 6) { result = 8; }
    else if (this.Level == 7) { result = 10; }
    else if (this.Level == 8) { result = 12; }
    else if (this.Level == 9) { result = 14; }
    else { result = 0; }
    return result;
  }

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
    this._remainPoint = GetRemainPoint();
    this._plusStrength = 0;
    this._plusAgility = 0;
    this._plusIntelligence = 0;
    this._plusStamina = 0;
    this._plusMind = 0;
  }
  public void AcceptLevelup()
  {
    this._level += 1;
    this._strength += this._plusStrength;
    this._agility += this._plusAgility;
    this._intelligence += this._plusIntelligence;
    this._stamina += this._plusStamina;
    this._mind += this._plusMind;

    this._remainPoint = 0;
    this._plusStrength = 0;
    this._plusAgility = 0;
    this._plusIntelligence = 0;
    this._plusStamina = 0;
    this._plusMind = 0;
    this._exp = 0;
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

    if (equip_type == Fix.EquipType.Accessory1)
    {
      if (item.ItemType == Item.ItemTypes.Accessory)
      {
        return true;
      }
      return false;
    }

    if (equip_type == Fix.EquipType.Accessory2)
    {
      if (item.ItemType == Item.ItemTypes.Accessory)
      {
        return true;
      }
      return false;
    }

    if (equip_type == Fix.EquipType.Artifact)
    {
      if (item.ItemType == Item.ItemTypes.Artifact)
      {
        return true;
      }
      return false;
    }
    return false;
  }

  public void AddBuff(string buff_name, double effect_value, int remain_counter)
  {
    bool detect = false;

    if (this.objBuffPanel == null) { return; }

    // unity潜在バグの可能性。null合体演算子、厳密にはnull判定かどうかを行おうとした時、
    // missing exceptionが発生するので、null合体演算子はここでは使わない。
    //BuffImage[] buffList = this.objBuffPanel?.GetComponentsInChildren<BuffImage>() ?? null;
    BuffImage[] buffList = this.objBuffPanel.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    for (int ii = 0; ii < buffList.Length; ii++)
    {
      if (buffList[ii].BuffName == buff_name)
      {
        buffList[ii].UpdateBuff(buff_name, remain_counter, effect_value);
        detect = true;
        break;
      }
    }
    if (detect) { return; }

    for (int ii = 0; ii < buffList.Length; ii++)
    {
      if (buffList[ii].BuffName == string.Empty)
      {
        buffList[ii].UpdateBuff(buff_name, remain_counter, effect_value);
        detect = true;
        break;
      }
    }
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
