using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public partial class Item
{
  #region "enum"
  public enum Important
  {
    None,
    Normal,
    Precious,
  }

  public enum ItemTypes
  {
    None,
    Onehand_Sword,
    Onehand_Lance,
    Onehand_Axe,
    Onehand_Claw,
    //Onehand_Bow, 弓は片手持ちは無い。
    Onehand_Rod,
    Onehand_Book,
    Onehand_Orb,
    Twohand_Sword,
    Twohand_Lance,
    Twohand_Axe,
    //Twohand_Claw, 爪は両手持ちは無い。
    Twohand_Bow,
    Twohand_Rod,
    //Twohand_Book, 本は両手持ちは無い。
    //Twohand_Orb, 宝玉は両手持ちは無い。
    Shield,
    Heavy_Armor,
    Middle_Armor,
    Light_Armor,
    Accessory,
    Artifact,
    Potion,
    EventItem,
    SellOnly,
  }
  public enum GripTypes
  {
    None,
    OneHand,
    TwoHand,
  }

  public enum Rarity
  {
    None,
    Poor,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
  }
  #endregion

  #region "Property"
  public Text txtItemName = null;
  public Image imgItem = null;

  protected string _itemName = string.Empty;
  public string ItemName
  {
    set { _itemName = value; }
    get { return _itemName; }
  }

  protected int _stackValue = 0;
  public int StackValue
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _stackValue = value;
    }
    get { return _stackValue; }
  }

  protected Important _importantType = Important.None;
  public Important ImportantType
  {
    set { _importantType = value; }
    get { return _importantType; }
  }

  protected ItemTypes _itemType = ItemTypes.None;
  public ItemTypes ItemType
  {
    set { _itemType = value; }
    get { return _itemType; }
  }

  protected GripTypes _gripType = GripTypes.None;
  public GripTypes GripType
  {
    set { _gripType = value; }
    get { return _gripType; }
  }

  //protected WeaponTypes _weaponType = WeaponTypes.None;
  //public WeaponTypes WeaponType
  //{
  //    set { _weaponType = value; }
  //    get { return _weaponType; }
  //}
  //protected ArmorTypes _armorType = ArmorTypes.None;
  //public ArmorTypes ArmorType
  //{
  //    set { _armorType = value; }
  //    get { return _armorType; }
  //}

  protected Rarity _rarity = Rarity.None;
  public Rarity Rare
  {
    set { _rarity = value; }
    get { return _rarity; }
  }

  protected string _description = string.Empty;
  public string Description
  {
    set { _description = value; }
    get { return _description; }
  }

  protected int _gold = 0;
  public int Gold
  {
    set { _gold = value; }
    get { return _gold; }
  }

  protected int _strength = 0;
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
    get { return _strength; }
  }

  protected int _agility = 0;
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
    get { return _agility; }
  }

  protected int _intelligence = 0;
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
    get { return _intelligence; }
  }

  protected int _stamina = 0;
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
    get { return _stamina; }
  }

  protected int _mind = 0;
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
    get { return _mind; }
  }

  protected int _hitRating = 0;
  public int HitRating
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      if (value >= 100)
      {
        value = 100;
      }
      _hitRating = value;
    }
    get { return _hitRating; }
  }

  protected int _physicalAttack = 0;
  public int PhysicalAttack
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _physicalAttack = value;
    }
    get { return _physicalAttack; }
  }
  protected int _physicalAttackMax = 0;
  public int PhysicalAttackMax
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _physicalAttackMax = value;
    }
    get { return _physicalAttackMax; }
  }

  protected int _magicAttack = 0;
  public int MagicAttack
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _magicAttack = value;
    }
    get { return _magicAttack; }
  }

  protected int _magicAttackMax = 0;
  public int MagicAttackMax
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _magicAttackMax = value;
    }
    get { return _magicAttackMax; }
  }

  protected int _physicalDefense = 0;
  public int PhysicalDefense
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _physicalDefense = value;
    }
    get { return _physicalDefense; }
  }

  protected int _magicDefense = 0;
  public int MagicDefense
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _magicDefense = value;
    }
    get { return _magicDefense; }
  }

  protected int _battleAccuracy = 0;
  public int BattleAccuracy
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _battleAccuracy = value;
    }
    get { return _battleAccuracy; }
  }

  protected int _battleSpeed = 0;
  public int BattleSpeed
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _battleSpeed = value;
    }
    get { return _battleSpeed; }
  }

  protected int _battleResponse = 0;
  public int BattleResponse
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _battleResponse = value;
    }
    get { return _battleResponse; }
  }

  protected int _potential = 0;
  public int Potential
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _potential = value;
    }
    get { return _potential; }
  }

  protected int _itemValue1 = 0;
  public int ItemValue1
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _itemValue1 = value;
    }
    get { return _itemValue1; }
  }

  protected int _itemValue2 = 0;
  public int ItemValue2
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _itemValue2 = value;
    }
    get { return _itemValue2; }
  }

  protected int _limitValue = 1;
  public int LimitValue
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _limitValue = value;
    }
    get { return _limitValue; }
  }

  //protected int _lifeGain = 0;
  //public int LifeGain
  //{
  //  set
  //  {
  //    if (value <= 0)
  //    {
  //      value = 0;
  //    }
  //    _lifeGain = value;
  //  }
  //  get { return _lifeGain; }
  //}

  protected bool _canbeSocket1 = false;
  protected bool _canbeSocket2 = false;
  protected bool _canbeSocket3 = false;
  protected bool _canbeSocket4 = false;
  protected bool _canbeSocket5 = false;
  public bool CanbeSocket1 { get { return _canbeSocket1; } set { _canbeSocket1 = value; } }
  public bool CanbeSocket2 { get { return _canbeSocket2; } set { _canbeSocket2 = value; } }
  public bool CanbeSocket3 { get { return _canbeSocket3; } set { _canbeSocket3 = value; } }
  public bool CanbeSocket4 { get { return _canbeSocket4; } set { _canbeSocket4 = value; } }
  public bool CanbeSocket5 { get { return _canbeSocket5; } set { _canbeSocket5 = value; } }

  protected Item _socketedItem1 = null;
  protected Item _socketedItem2 = null;
  protected Item _socketedItem3 = null;
  protected Item _socketedItem4 = null;
  protected Item _socketedItem5 = null;

  public Item SocketedItem1 { get { return _socketedItem1; } set { _socketedItem1 = value; } }
  public Item SocketedItem2 { get { return _socketedItem2; } set { _socketedItem2 = value; } }
  public Item SocketedItem3 { get { return _socketedItem3; } set { _socketedItem3 = value; } }
  public Item SocketedItem4 { get { return _socketedItem4; } set { _socketedItem4 = value; } }
  public Item SocketedItem5 { get { return _socketedItem5; } set { _socketedItem5 = value; } }

  public double _resistFire = 0.0f;
  public double ResistFire
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistFire = value;
    }
    get { return _resistFire; }
  }

  public double _resistIce = 0.0f;
  public double ResistIce
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistIce = value;
    }
    get { return _resistIce; }
  }

  public double _resistLight = 0.0f;
  public double ResistLight
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistLight = value;
    }
    get { return _resistLight; }
  }

  public double _resistShadow = 0.0f;
  public double ResistShadow
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistShadow = value;
    }
    get { return _resistShadow; }
  }

  public double _resistWind = 0.0f;
  public double ResistWind
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistWind = value;
    }
    get { return _resistWind; }
  }

  public double _resistEarth = 0.0f;
  public double ResistEarth
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistEarth = value;
    }
    get { return _resistEarth; }
  }

  // 猛毒への耐性
  protected bool _resistPoison = false;
  public bool ResistPoison
  {
    set { _resistPoison = value; }
    get { return _resistPoison; }
  }

  // 沈黙への耐性
  protected bool _resistSilence = false;
  public bool ResistSilence
  {
    set { _resistSilence = value; }
    get { return _resistSilence; }
  }

  // 束縛への耐性
  protected bool _resistBind = false;
  public bool ResistBind
  {
    set { _resistBind = value; }
    get { return _resistBind; }
  }

  // 睡眠への耐性
  protected bool _resistSleep = false;
  public bool ResistSleep
  {
    set { _resistSleep = value; }
    get { return _resistSleep; }
  }

  // スタンへの耐性
  protected bool _resistStun = false;
  public bool ResistStun
  {
    set { _resistStun = value; }
    get { return _resistStun; }
  }

  // 麻痺への耐性
  protected bool _resistParalyze = false;
  public bool ResistParalyze
  {
    set { _resistParalyze = value; }
    get { return _resistParalyze; }
  }

  // 凍結への耐性
  protected bool _resistFreeze = false;
  public bool ResistFreeze
  {
    set { _resistFreeze = value; }
    get { return _resistFreeze; }
  }

  // 恐怖への耐性
  protected bool _resistFear = false;
  public bool ResistFear
  {
    set { _resistFear = value; }
    get { return _resistFear; }
  }

  // 誘惑への耐性
  protected bool _resistTemptation = false;
  public bool ResistTemptation
  {
    set { _resistTemptation = value; }
    get { return _resistTemptation; }
  }

  // 鈍化への耐性
  protected bool _resistSlow = false;
  public bool ResistSlow
  {
    set { _resistSlow = value; }
    get { return _resistSlow; }
  }

  // 眩暈への耐性
  protected bool _resistDizzy = false;
  public bool ResistDizzy
  {
    set { _resistDizzy = value; }
    get { return _resistDizzy; }
  }

  // 出血への耐性
  protected bool _resistSlip = false;
  public bool ResistSlip
  {
    set { _resistSlip = value; }
    get { return _resistSlip; }
  }

  // 復活不可への耐性
  protected bool _resistCannotResurrect = false;
  public bool ResistCannotResurrect
  {
    set { _resistCannotResurrect = value; }
    get { return _resistCannotResurrect; }
  }

  protected double _amplifyFire = 1.00f;
  public double AmplifyFire
  {
    set { _amplifyFire = value; }
    get { return _amplifyFire; }
  }

  protected double _amplifyIce = 1.00f;
  public double AmplifyIce
  {
    set { _amplifyIce = value; }
    get { return _amplifyIce; }
  }

  protected double _amplifyLight = 1.00f;
  public double AmplifyLight
  {
    set { _amplifyLight = value; }
    get { return _amplifyLight; }
  }

  protected double _amplifyShadow = 1.00f;
  public double AmplifyShadow
  {
    set { _amplifyShadow = value; }
    get { return _amplifyShadow; }
  }

  protected double _amplifyWind = 1.00f;
  public double AmplifyWind
  {
    set { _amplifyWind = value; }
    get { return _amplifyWind; }
  }

  protected double _amplifyEarth = 1.00f;
  public double AmplifyEarth
  {
    set { _amplifyEarth = value; }
    get { return _amplifyEarth; }
  }

  protected double _amplifyPhysicalAttack = 1.00f;
  public double AmplifyPhysicalAttack
  {
    set { _amplifyPhysicalAttack = value; }
    get { return _amplifyPhysicalAttack; }
  }

  protected double _amplifyPhysicalDefense = 1.00f;
  public double AmplifyPhysicalDefense
  {
    set { _amplifyPhysicalDefense = value; }
    get { return _amplifyPhysicalDefense; }
  }

  protected double _amplifyMagicAttack = 1.00f;
  public double AmplifyMagicAttack
  {
    set { _amplifyMagicAttack = value; }
    get { return _amplifyMagicAttack; }
  }

  protected double _amplifyMagicDefense = 1.00f;
  public double AmplifyMagicDefense
  {
    set { _amplifyMagicDefense = value; }
    get { return _amplifyMagicDefense; }
  }

  protected double _amplifyBattleAccuracy = 1.00f;
  public double AmplifyBattleAccuracy
  {
    set { _amplifyBattleAccuracy = value; }
    get { return _amplifyBattleAccuracy; }
  }

  protected double _amplifyBattleSpeed = 1.00f;
  public double AmplifyBattleSpeed
  {
    set { _amplifyBattleSpeed = value; }
    get { return _amplifyBattleSpeed; }
  }

  protected double _amplifyBattleResponse = 1.00f;
  public double AmplifyBattleResponse
  {
    set { _amplifyBattleResponse = value; }
    get { return _amplifyBattleResponse; }
  }

  protected double _amplifyPotential = 1.00f;
  public double AmplifyPotential
  {
    set { _amplifyPotential = value; }
    get { return _amplifyPotential; }
  }

  public void SetupItemView(Text txtName, Image img)
  {
    if (txtName != null)
    {
      txtName.text = _itemName;
    }
  }

  public Color GetRareColor
  {
    get
    {

      if (this._rarity == Item.Rarity.Poor)
      {
        return Color.gray;
      }
      else if (this._rarity == Item.Rarity.Common)
      {
        return Color.white;
      }
      else if (this._rarity == Item.Rarity.Uncommon)
      {
        return Color.green;
      }
      else if (this._rarity == Item.Rarity.Rare)
      {
        return Color.blue;
      }
      else if (this._rarity == Item.Rarity.Epic)
      {
        return new Color(155.0f / 255.0f, 0, 255.0f / 255.0f);
      }
      else if (this._rarity == Item.Rarity.Legendary)
      {
        return new Color(255.0f / 255.0f, 130.0f / 255.0f, 0);
      }
      else
      {
        // 指定以外の場合、Normalと同じ扱いで良い。
        return Color.gray;
      }
    }
  }
  public Color GetRareTextColor
  {
    get
    {

      if (this._rarity == Item.Rarity.Poor)
      {
        return Color.black;
      }
      else if (this._rarity == Item.Rarity.Common)
      {
        return Color.black;
      }
      else if (this._rarity == Item.Rarity.Uncommon)
      {
        return Color.black;
      }
      else if (this._rarity == Item.Rarity.Rare)
      {
        return Color.white;
      }
      else if (this._rarity == Item.Rarity.Epic)
      {
        return Color.white;
      }
      else if (this._rarity == Item.Rarity.Legendary)
      {
        return Color.white;
      }
      else
      {
        // 指定以外の場合、Normalと同じ扱いで良い。
        return new Color(155.0f / 255.0f, 0, 255.0f / 255.0f);
      }
    }
  }
  public string ItemType_JP
  {
    get
    {
      if (this._itemType == ItemTypes.None) { return "売却専用品"; }
      if (this._itemType == ItemTypes.Onehand_Sword) { return "剣"; }
      if (this._itemType == ItemTypes.Onehand_Lance) { return "槍"; }
      if (this._itemType == ItemTypes.Onehand_Axe) { return "斧"; }
      if (this._itemType == ItemTypes.Onehand_Claw) { return "爪"; }
      if (this._itemType == ItemTypes.Onehand_Orb) { return "宝玉"; }
      if (this._itemType == ItemTypes.Onehand_Book) { return "本"; }
      if (this._itemType == ItemTypes.Onehand_Rod) { return "杖"; }
      if (this._itemType == ItemTypes.Twohand_Sword) { return "両手剣"; }
      if (this._itemType == ItemTypes.Twohand_Lance) { return "両手槍"; }
      if (this._itemType == ItemTypes.Twohand_Axe) { return "両手斧"; }
      if (this._itemType == ItemTypes.Twohand_Bow) { return "弓"; }
      if (this._itemType == ItemTypes.Twohand_Rod) { return "大杖"; }
      if (this._itemType == ItemTypes.Shield) { return "盾"; }
      if (this._itemType == ItemTypes.Heavy_Armor) { return "重装"; }
      if (this._itemType == ItemTypes.Middle_Armor) { return "中装"; }
      if (this._itemType == ItemTypes.Light_Armor) { return "軽装"; }
      if (this._itemType == ItemTypes.Accessory) { return "アクセサリ"; }
      if (this._itemType == ItemTypes.Artifact) { return "アーティファクト"; }
      if (this._itemType == ItemTypes.Potion) { return "ポーション"; }
      if (this._itemType == ItemTypes.EventItem) { return "貴重品"; }

      return "売却専用品";
    }      
  }
  #endregion

  #region "Method"
  public void AddJewelSocket1(string item_name)
  {
    this.SocketedItem1 = new Item(item_name);
  }
  public void AddJewelSocket2(string item_name)
  {
    this.SocketedItem2 = new Item(item_name);
  }
  public void AddJewelSocket3(string item_name)
  {
    this.SocketedItem3 = new Item(item_name);
  }
  public void AddJewelSocket4(string item_name)
  {
    this.SocketedItem4 = new Item(item_name);
  }
  public void AddJewelSocket5(string item_name)
  {
    this.SocketedItem5 = new Item(item_name);
  }

  public void SetupLimitValue()
  {
    if (this.ItemType == ItemTypes.Accessory ||
        this.ItemType == ItemTypes.Artifact ||
        this.ItemType == ItemTypes.EventItem ||
        this.ItemType == ItemTypes.Heavy_Armor ||
        this.ItemType == ItemTypes.Light_Armor ||
        this.ItemType == ItemTypes.Middle_Armor ||
        this.ItemType == ItemTypes.Onehand_Axe ||
        this.ItemType == ItemTypes.Onehand_Book ||
        this.ItemType == ItemTypes.Onehand_Claw ||
        this.ItemType == ItemTypes.Onehand_Lance ||
        this.ItemType == ItemTypes.Onehand_Orb ||
        this.ItemType == ItemTypes.Onehand_Rod ||
        this.ItemType == ItemTypes.Onehand_Sword ||
        this.ItemType == ItemTypes.Shield ||
        this.ItemType == ItemTypes.Twohand_Axe ||
        this.ItemType == ItemTypes.Twohand_Bow ||
        this.ItemType == ItemTypes.Twohand_Lance ||
        this.ItemType == ItemTypes.Twohand_Rod ||
        this.ItemType == ItemTypes.Twohand_Sword)
    {
      this._limitValue = 1;
    }
    else if (this.ItemType == ItemTypes.Potion)
    {
      this.LimitValue = Fix.MAX_ITEM_STACK_SIZE; // オブジェクトがスタックできる最大数
    }
    else
    {
      this.LimitValue = Fix.MAX_ITEM_STACK_SIZE; // オブジェクトがスタックできる最大数
    }
  }
  #endregion

  #region "Contents"
  public Item(string item_name)
  {
    this._itemName = item_name;
    this._stackValue = 1; // 必ず１つ存在する。
    this._gripType = GripTypes.None;
    this._importantType = Important.None;

    switch (item_name)
    {
      #region "サルン洞窟前の草原区域"
      case Fix.PRACTICE_CLAW:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 1;
        this._physicalAttackMax = 3;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 180;
        this._importantType = Important.None;
        this._description = "練習用の爪。実践ではあまり用いられず、訓練の時に使用する。物理攻撃力１～３";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_CLAW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 3;
        this._physicalAttackMax = 5;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "標準的な爪。一般的な冒険者にとっては安心して使える。物理攻撃力３～５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SURVIVAL_CLAW:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 4;
        this._physicalAttackMax = 7;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 860;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.RISING_FORCE_CLAW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 9;
        this._physicalAttackMax = 15;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2000;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした後、自分自身の物理攻撃を＋３する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.LIGHTNING_CLAW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 13;
        this._physicalAttackMax = 16;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2200;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で雷による追加ダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PRACTICE_SWORD:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 2;
        this._physicalAttackMax = 4;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 200;
        this._importantType = Important.None;
        this._description = "練習用の剣。実践ではあまり用いられず、訓練の時に使用する。物理攻撃力２～４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 4;
        this._physicalAttackMax = 7;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 650;
        this._importantType = Important.None;
        this._description = "標準的な剣。一般的な冒険者にとっては安心して使える。物理攻撃力４～７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.BRONZE_SWORD:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 6;
        this._physicalAttackMax = 10;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 900;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SWORD_OF_LIFE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 14;
        this._physicalAttackMax = 19;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2100;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットする毎に、自分自身のライフを回復する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.ItemValue1 = 12;
        this.ItemValue2 = 30;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.AERO_BLADE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 16;
        this._physicalAttackMax = 21;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2300;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で風による追加ダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.MERGIZD_SOL_BLADE:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 45;
        this._physicalAttackMax = 67;
        this._magicAttack = 22;
        this._magicAttackMax = 34;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 10;
        this._agility = 0;
        this._intelligence = 8;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PRACTICE_LANCE:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 3;
        this._physicalAttackMax = 6;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 220;
        this._importantType = Important.None;
        this._description = "練習用の槍。実践ではあまり用いられず、訓練の時に使用する。物理攻撃力３～６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 5;
        this._physicalAttackMax = 9;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 720;
        this._importantType = Important.None;
        this._description = "標準的な槍。一般的な冒険者にとっては安心して使える。物理攻撃力５～９";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SHARP_LANCE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 8;
        this._physicalAttackMax = 14;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1100;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.WHITE_PARGE_LANCE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 16;
        this._physicalAttackMax = 23;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2200;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身の負のBUFFを一つ解除する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ICE_SPIRIT_LANCE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 19;
        this._physicalAttackMax = 26;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2400;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で氷による追加ダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_BOW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 7;
        this._physicalAttackMax = 12;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 800;
        this._importantType = Important.None;
        this._description = "標準的な弓。一般的な冒険者にとっては安心して使える。物理攻撃力７～１２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ICICLE_LONGBOW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 18;
        this._physicalAttackMax = 27;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2500;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で対象に【鈍化】のBUFFを付与する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.MUMYOU_BOW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 20;
        this._physicalAttackMax = 29;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2800;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、物理攻撃に関するコマンドの命中率が100%になるBUFFを付与する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PRACTICE_AXE:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 4;
        this._physicalAttackMax = 8;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 240;
        this._importantType = Important.None;
        this._description = "練習用の斧。実践ではあまり用いられず、訓練の時に使用する。物理攻撃力４～８";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 8;
        this._physicalAttackMax = 13;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "標準的な斧。一般的な冒険者にとっては安心して使える。物理攻撃力８～１３";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.VIKING_AXE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 11;
        this._physicalAttackMax = 18;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.EARTH_POWER_AXE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 26;
        this._physicalAttackMax = 31;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 3000;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で土による追加ダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.WARWOLF_AXE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 29;
        this._physicalAttackMax = 34;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 3300;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした後、対象の物理防御を－２する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PRACTICE_ORB:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 1;
        this._magicAttackMax = 3;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 180;
        this._importantType = Important.None;
        this._description = "練習用の水晶。実践ではあまり用いられず、訓練の時に使用する。魔法攻撃力１～３";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_ORB:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 3;
        this._magicAttackMax = 5;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "標準的な水晶。一般的な冒険者にとっては安心して使える。魔法攻撃力３～５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ENERGY_ORB:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 4;
        this._magicAttackMax = 7;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 860;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.LIVING_GROWTH_ORB:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 9;
        this._magicAttackMax = 15;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2000;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身のライフを回復する。魔法攻撃力９～１５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.RED_PILLER_ORB:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 13;
        this._magicAttackMax = 16;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2200;
        this._importantType = Important.None;
        this._description = "魔法攻撃がヒットした時、20%の確率で炎による追加ダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PRACTICE_ROD:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 2;
        this._magicAttackMax = 4;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 200;
        this._importantType = Important.None;
        this._description = "練習用の杖。実践ではあまり用いられず、訓練の時に使用する。魔法攻撃力２～４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_ROD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 4;
        this._magicAttackMax = 7;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 650;
        this._importantType = Important.None;
        this._description = "標準的な杖。一般的な冒険者にとっては安心して使える。魔法攻撃力４～７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.WOOD_ROD:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 6;
        this._magicAttackMax = 10;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 900;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.TOUGH_TREE_ROD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 12;
        this._magicAttackMax = 21;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2100;
        this._importantType = Important.None;
        this._description = "魔法攻撃がヒットした時、20%の確率で対象に【暗闇】のBUFFを付与する。魔法攻撃力１２～２１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.BLACK_SORCERER_ROD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 16;
        this._magicAttackMax = 21;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2300;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身に【闇】属性からの魔法ダメージを増強するBUFFを付与する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PRACTICE_BOOK:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 3;
        this._magicAttackMax = 6;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 220;
        this._importantType = Important.None;
        this._description = "練習用の本。実践ではあまり用いられず、訓練の時に使用する。魔法攻撃力３～６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_BOOK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 6;
        this._magicAttackMax = 10;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 720;
        this._importantType = Important.None;
        this._description = "標準的な本。一般的な冒険者にとっては安心して使える。魔法攻撃力６～１０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.KINDNESS_BOOK:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 8;
        this._magicAttackMax = 14;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1100;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SAINT_FAITHFUL_BOOK:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 18;
        this._magicAttackMax = 30;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2200;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身に【聖】属性からの魔法ダメージを増強するBUFFを付与する。魔法攻撃力１８～３０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.MUIN_BOOK:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 19;
        this._magicAttackMax = 26;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2400;
        this._importantType = Important.None;
        this._description = "魔法攻撃がヒットした後、自分自身の物理攻撃を＋５する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PRACTICE_SHIELD:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 1;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 200;
        this._importantType = Important.None;
        this._description = "練習用の盾。実践ではあまり用いられず、訓練の時に使用する。物理防御力１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_SHIELD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 3;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 450;
        this._importantType = Important.None;
        this._description = "標準的な盾。一般的な冒険者にとっては安心して使える。物理防御力３";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.KITE_SHIELD:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 5;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1020;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SUPERIOR_FLAME_SHIELD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 8;
        this._magicDefense = 4;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2500;
        this._importantType = Important.None;
        this._description = "魔法攻撃を防御姿勢で受けた時、その魔法属性が「炎」の場合はダメージを半分に軽減する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.BEGINNER_ARMOR:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 3;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 250;
        this._importantType = Important.None;
        this._description = "練習用の鎧。実践ではあまり用いられず、訓練の時に使用する。物理防御力３";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_ARMOR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 6;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 500;
        this._importantType = Important.None;
        this._description = "標準的な鎧。一般的な冒険者にとっては安心して使える。物理防御力６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.HEAVY_ARMOR:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 10;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 900;
        this._importantType = Important.None;
        this._description = "重量感を意識して作られた鎧。か弱い攻撃であれば食らっても支障はない。物理防御力１０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.BEGINNER_CROSS:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 2;
        this._magicDefense = 1;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 200;
        this._importantType = Important.None;
        this._description = "練習用の舞踏衣。実践ではあまり用いられず、訓練の時に使用する。物理防御力２、魔法防御力１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_CROSS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 4;
        this._magicDefense = 2;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 400;
        this._importantType = Important.None;
        this._description = "標準的な舞踏衣。一般的な冒険者にとっては安心して使える。物理防御力４、魔法防御力２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.LEATHER_CROSS:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 6;
        this._magicDefense = 3;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 600;
        this._importantType = Important.None;
        this._description = "しっかりとしたレザーを使って作成された舞踏衣。物理防御力６、魔法防御力３";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.BEGINNER_ROBE:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 1;
        this._magicDefense = 2;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 350;
        this._importantType = Important.None;
        this._description = "練習用のローブ。実践ではあまり用いられず、訓練の時に使用する。物理防御力１、魔法防御力２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINE_ROBE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 2;
        this._magicDefense = 4;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 700;
        this._importantType = Important.None;
        this._description = "標準的なローブ。一般的な冒険者にとっては安心して使える。物理防御力２、魔法防御力４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COTTON_ROBE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 3;
        this._magicDefense = 6;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "木綿の素材を編み合わせて作られたローブ。か弱い魔法攻撃であれば食らっても支障はない。物理防御力３、魔法防御力６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.HINJAKU_RING:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 240;
        this._importantType = Important.None;
        this._description = "ほんのりパワーを感じ取れる腕輪。力＋１";
        this._strength = 1;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.USUYOGORETA_FEATHER:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 240;
        this._importantType = Important.None;
        this._description = "みすぼらしい付け羽。少しだけ軽さを感じ取れる。技＋１";
        this._strength = 0;
        this._agility = 1;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.NON_BRIGHT_ORB:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 240;
        this._importantType = Important.None;
        this._description = "知性が枯渇してしまった丸い水晶玉。知＋１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 1;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.KUKEI_BANGLE:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 240;
        this._importantType = Important.None;
        this._description = "丸みを帯びていないため、装着しにくいバングル。体＋１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 1;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SUTERARESHI_EMBLEM:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 240;
        this._importantType = Important.None;
        this._description = "惨敗した者が捨てていった名もなき紋章。心＋１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 1;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ADJUSTABLE_BELT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "付け心地の良いベルト。力＋２、技＋１";
        this._strength = 2;
        this._agility = 1;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.BIRD_STATUE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "鳥の形をした彫像。技＋２、心＋１";
        this._strength = 0;
        this._agility = 2;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 1;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SHAPED_FINGERRING:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "壊れていいたが整形され、再び使えるようになった指輪。技＋１、知＋２";
        this._strength = 0;
        this._agility = 1;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.REFRESHED_MANTLE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "手入れが施されたマント。僅かな何かを感じられる。知＋１、心＋２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 1;
        this._stamina = 0;
        this._mind = 2;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COOL_CROWN:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "付けているつ少しカッコよさが上がる王冠、ほんのりパワーを感じられる。力＋１、技＋１、知＋１";
        this._strength = 1;
        this._agility = 1;
        this._intelligence = 1;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FLAT_SHOES:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "軽快なシューズ。これを履いた瞬間から、身体全体が軽くなった様な感覚を得ることができる。技＋２、体＋１";
        this._strength = 0;
        this._agility = 2;
        this._intelligence = 0;
        this._stamina = 1;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COMPACT_EARRING:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "控え目なサイズのイヤリング。身に着けているとほのかに安定感が生まれてくる。知＋２、心＋１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 1;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.POWER_BANDANA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "力が湧いてくるバンダナ。しっかりとした結び目がやる気を引き立たせてくれる。力＋２、心＋１";
        this._strength = 2;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 1;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.CHERRY_CHOKER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "紺碧色の可愛らしいチョーカー。装着している者の精神を向上させてくれる。力＋１、知＋２";
        this._strength = 1;
        this._agility = 0;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FIT_BANGLE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "弾力があり、フィットしやすいバングル。力＋１、体＋２";
        this._strength = 1;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 2;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PRISM_EMBLEM:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "特徴は無いが、ほど良い形をしたエムブレム。力＋１、技＋１、知＋１、体＋１、心＋１";
        this._strength = 1;
        this._agility = 1;
        this._intelligence = 1;
        this._stamina = 1;
        this._mind = 1;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.POOR_BLACK_MATERIAL:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 200;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルのため、使い道はない。";
        break;

      case Fix.POOR_BLACK_MATERIAL2:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 800;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルに対して改良が施されているが、使い道はない。";
        break;

      case Fix.POOR_BLACK_MATERIAL3:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1400;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルが時間経過で灰と化しており、使い道はない。";
        break;

      case Fix.POOR_BLACK_MATERIAL4:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2500;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルを幾つか圧縮させてみたが、使い道はない。";
        break;

      case Fix.POOR_BLACK_MATERIAL5:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 4000;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルが塵となったものを集約してみたが、使い道はない。";
        break;

      case Fix.POOR_BLACK_MATERIAL6:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7500;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルに対して素材性質の変化を試みたが、使い道はない。";
        break;
        
      case Fix.POOR_BLACK_MATERIAL7:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 10000;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルが消滅する寸前に形成維持させたものだが、使い道はない。";
        break;

      case Fix.POOR_BLACK_MATERIAL8:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 16000;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルから元素還元を行ってみたが、使い道はない。";
        break;

      case Fix.POOR_BLACK_MATERIAL9:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 30000;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルを使用済みマテリアルとして再構築したが、使い道はない。";
        break;

      case Fix.RED_PENDANT:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "赤色のペンダント。僅かな【力】を感じ取る事が出来る。力＋５";
        this._strength = 5;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.BLUE_PENDANT:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "青色のペンダント。僅かな【技】を感じ取る事が出来る。技＋５";
        this._strength = 0;
        this._agility = 5;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PURPLE_PENDANT:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "紫色のペンダント。僅かな【知】を感じ取る事が出来る。知＋５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 5;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.GREEN_PENDANT:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "緑色のペンダント。僅かな【体】を感じ取る事が出来る。体＋５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 5;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.YELLOW_PENDANT:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "黄色のペンダント。僅かな【心】を感じ取る事が出来る。心＋５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 5;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.WARRIOR_BRACER:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1600;
        this._importantType = Important.None;
        this._description = "戦士系が好んで装備する籠手。力がみなぎってくるのを感じる。力＋３、心＋１\r\nスタン耐性";
        this._strength = 3;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 1;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        this.ResistStun = true;
        break;

      case Fix.STARDUST_CHARM:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1600;
        this._importantType = Important.None;
        this._description = "魔法使い系が好んで使うストラップ型の魔除け。精神が統一されていくのを感じる。知＋３、心＋１\r\n猛毒耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 3;
        this._stamina = 0;
        this._mind = 1;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        this.ResistPoison = true;
        break;

      case Fix.BOLT_STONE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1600;
        this._importantType = Important.None;
        this._description = "求道者系が好んで使う電流タイプの魔道石。持っていると、ほとばしる感覚が宿る。力＋２、知＋２\r\n眩暈耐性";
        this._strength = 2;
        this._agility = 0;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        this.ResistDizzy = true;
        break;

      case Fix.BLUE_WIZARD_HAT:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2500;
        this._importantType = Important.None;
        this._description = "高貴なる青の帽子は魔法使いの力の源でもある。【氷】属性からの魔法ダメージを軽減し、かつ、【氷】属性による魔法ダメージを増強する。";
        this._strength = 0;
        this._agility = 2;
        this._intelligence = 5;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FLAME_HAND_KEEPER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2500;
        this._importantType = Important.None;
        this._description = "装着者の周囲に炎のオーラが出現する。【炎】属性からの魔法ダメージを軽減し、かつ、【炎】属性による魔法ダメージを増強する。";
        this._strength = 5;
        this._agility = 2;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;
      #endregion
      #region "ゴラトラム洞窟"
      case Fix.CLASSICAL_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 25;
        this._physicalAttackMax = 35;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "伝統的な剣。威力、使いやすさと共に申し分はない。物理攻撃力２５～３５";
        break;

      case Fix.SMASH_BLADE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 30;
        this._physicalAttackMax = 42;
        this._gold = 5000;
        this._importantType = Important.None;
        this._description = "グリップが良く、切れ味も良い。安定以上の使い心地があり、振るのが楽しくなる。物理攻撃力３０～４２、力＋２、心＋２";
        this._strength = 2;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 2;
        break;

      case Fix.BLUE_LIGHTNING_SWORD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 45;
        this._physicalAttackMax = 62;
        this._gold = 9000;
        this._importantType = Important.None;
        this._description = "青い閃光が剣の中に埋め込まれている。剣を振るうたびに、青光の残影がのこるため、青い稲妻が走ったように見える。物理攻撃力４５～６２、力＋３、心＋３\r\n　【特殊能力】物理攻撃が対象にヒットする度に、【電撃】ダメージが追加で発生する。";
        this._strength = 3;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 3;
        break;

      case Fix.CLASSICAL_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 30;
        this._physicalAttackMax = 42;
        this._gold = 4200;
        this._importantType = Important.None;
        this._description = "伝統的な槍。威力、使いやすさと共に申し分はない。物理攻撃力３０～４２";
        break;

      case Fix.STYLISH_LANCE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 36;
        this._physicalAttackMax = 50;
        this._gold = 5200;
        this._importantType = Important.None;
        this._description = "軽さと威力を両立している槍。構えた時の見栄えも良く愛好者は多い。物理攻撃力３６～５０、力＋２、技＋２";
        this._strength = 2;
        this._agility = 2;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.ASH_EXCLUDE_LANCE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._physicalAttack = 52;
        this._physicalAttackMax = 75;
        this._gold = 9200;
        this._importantType = Important.None;
        this._description = "粉塵を薙ぎ払う事を連想させる槍。比較的大きめで、槍の形も特殊な形状をしており、見ている者を恐れさせる。物理攻撃力５２～７５、力＋３、技＋３\r\n　【特殊能力】物理攻撃が対象にヒットした場合、【出血】のBUFFを付与する。";
        this._strength = 3;
        this._agility = 3;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.CLASSICAL_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 35;
        this._physicalAttackMax = 50;
        this._gold = 4400;
        this._importantType = Important.None;
        this._description = "伝統的な斧。威力、使いやすさと共に申し分はない。物理攻撃力３５～５０";
        break;

      case Fix.LAND_AXE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 42;
        this._physicalAttackMax = 60;
        this._gold = 5400;
        this._importantType = Important.None;
        this._description = "ズッシリとした重みとフルスイングした時の爽快さが戦闘意欲を引き立たせる。物理攻撃力４２～６０、力＋２、体＋２";
        this._strength = 2;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 2;
        this._mind = 0;
        break;

      case Fix.BONE_CRUSH_AXE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 60;
        this._physicalAttackMax = 97;
        this._gold = 9400;
        this._importantType = Important.None;
        this._description = "骨を粉砕するぐらいの威力で猛威を振るう斧。全体的に大きめだが片手で振り回せ、かつ、打撃力も高い。物理攻撃力６０～９７、力＋３、体＋３\r\n　【特殊能力】物理攻撃が対象にヒットした場合、対象の物理防御力を５％減少させる。";
        this._strength = 3;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
        break;

      case Fix.CLASSICAL_CLAW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 23;
        this._physicalAttackMax = 28;
        this._gold = 3800;
        this._importantType = Important.None;
        this._description = "伝統的な爪。威力、使いやすさと共に申し分はない。物理攻撃力２３～２８";
        break;

      case Fix.SAVAGE_CLAW:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 28;
        this._physicalAttackMax = 34;
        this._gold = 4800;
        this._importantType = Important.None;
        this._description = "爪の先端を意図的に荒れた状態にして仕上げられた作品。攻撃スタイルは野蛮な方が威力は上がる。物理攻撃力２８～３４、技＋２、心＋２";
        this._strength = 0;
        this._agility = 2;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 2;
        break;

      case Fix.COLD_SPLASH_CLAW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 42;
        this._physicalAttackMax = 55;
        this._gold = 8900;
        this._importantType = Important.None;
        this._description = "武具全体が凍結した状態で固形化されており、非常に鋭い切れ味の爪に仕上がっている。物理攻撃力４２～５５、技＋３、心＋３\r\n　【特殊能力】物理攻撃が対象にヒットする度に、【氷】ダメージが追加で発生する。";
        this._strength = 0;
        this._agility = 3;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 3;
        break;

      case Fix.CLASSICAL_ROD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._magicAttack = 25;
        this._magicAttackMax = 35;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "伝統的な杖。威力、使いやすさと共に申し分はない。魔法攻撃力２５～３５";
        break;

      case Fix.WINGED_ROD:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._magicAttack = 30;
        this._magicAttackMax = 42;
        this._gold = 5000;
        this._importantType = Important.None;
        this._description = "持ち手の所に小さな羽が装飾されている杖。手元へ魔力が集約されるのを感じ取れる。魔法攻撃力３０～４２、知＋２、心＋２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 2;
        break;

      case Fix.SEKISOUJU_ROD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._magicAttack = 45;
        this._magicAttackMax = 63;
        this._gold = 8400;
        this._importantType = Important.None;
        this._description = "炎の力を増幅させるため、炎を２つの球体に分離した形で杖の取っ手に宿した大杖。魔法攻撃力４５～６３、知＋３、心＋３\r\n　【特殊能力】魔法攻撃が対象にヒットする度に、対象に【炎】ダメージが追加で発生する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 3;
        this._stamina = 0;
        this._mind = 3;
        break;

      case Fix.CLASSICAL_BOOK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._magicAttack = 30;
        this._magicAttackMax = 42;
        this._gold = 4200;
        this._importantType = Important.None;
        this._description = "伝統的な本。威力、使いやすさと共に申し分はない。魔法攻撃力３０～４２";
        break;

      case Fix.EXPERT_BOOK:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._magicAttack = 36;
        this._magicAttackMax = 50;
        this._gold = 5200;
        this._importantType = Important.None;
        this._description = "一人前になった冒険者が良く持ち歩く本。本書の読み解きを経て詠唱すれば自ずと威力は上がる。魔法攻撃力３６～５０、知＋２、体＋２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 2;
        this._stamina = 2;
        this._mind = 0;
        break;

      case Fix.GORGON_EYES_BOOK:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 93;
        this._magicAttack = 54;
        this._magicAttackMax = 76;
        this._gold = 8600;
        this._importantType = Important.None;
        this._description = "ゴルゴンの目玉が描かれている魔道の書物。持っているだけでも禍々しさがあるが、魔法を放つ時その目が光りだす。魔法攻撃力５４～７６、知＋３、体＋３\r\n　【特殊能力】魔法攻撃が対象にヒットした場合、【猛毒】のBUFFを付与する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 3;
        this._stamina = 3;
        this._mind = 0;
        break;

      case Fix.CLASSICAL_ORB:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._magicAttack = 23;
        this._magicAttackMax = 28;
        this._gold = 3800;
        this._importantType = Important.None;
        this._description = "伝統的な水晶。威力、使いやすさと共に申し分はない。魔法攻撃力２３～２８";
        break;

      case Fix.FLOATING_ORB:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._magicAttack = 28;
        this._magicAttackMax = 34;
        this._gold = 4800;
        this._importantType = Important.None;
        this._description = "一人前が扱う水晶は基本的な魔力が備えられており、常に浮いた状態となる。魔法攻撃力２８～３４、技＋２、知＋２";
        this._strength = 0;
        this._agility = 2;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.STAR_FUSION_ORB:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._magicAttack = 41;
        this._magicAttackMax = 50;
        this._gold = 8500;
        this._importantType = Important.None;
        this._description = "星型と丸形を融合させた形状のオーブ。白く輝いており、見ているものを惑わせる。魔法攻撃力４１～５０、技＋３、知＋３　【特殊能力】魔法攻撃が対象にヒットした場合、【聖】ダメージが追加で発生する。";
        this._strength = 0;
        this._agility = 3;
        this._intelligence = 3;
        this._stamina = 0;
        this._mind = 0;
        break;


      case Fix.CLASSICAL_LARGE_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Sword;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 87;
        this._physicalAttack = 25;
        this._physicalAttackMax = 63;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6200;
        this._importantType = Important.None;
        this._description = "伝統的な両手剣。威力、使いやすさと共に申し分はない。物理攻撃力２５～６３";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.CLASSICAL_LARGE_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Lance;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 85;
        this._physicalAttack = 30;
        this._physicalAttackMax = 76;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "伝統的な両手槍。威力、使いやすさと共に申し分はない。物理攻撃力３０～７６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.CLASSICAL_LARGE_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Axe;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 83;
        this._physicalAttack = 35;
        this._physicalAttackMax = 90;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6800;
        this._importantType = Important.None;
        this._description = "伝統的な両手斧。威力、使いやすさと共に申し分はない。物理攻撃力３５～９０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.CLASSICAL_BOW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 46;
        this._physicalAttackMax = 72;
        this._gold = 7200;
        this._importantType = Important.None;
        this._description = "伝統的な弓。威力、使いやすさと共に申し分はない。物理攻撃力４６～７２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.ELVISH_BOW:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 55;
        this._physicalAttackMax = 74;
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "過去の時代に繁栄していたエルフ族が作った弓。射やすく作られており飛距離がある。物理攻撃力５５～７４、力＋２、知＋２";
        this._strength = 2;
        this._agility = 0;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MADAN_SHOOTING_STAR:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 68;
        this._physicalAttackMax = 108;
        this._gold = 8500;
        this._importantType = Important.None;
        this._description = "禍々しい魔力がこめられた魔道弾丸が矢として放たれる。通常の物理攻撃とは異なる何かを受けた者は食らう。物理攻撃力６８～１０８、力＋３、知＋３\r\n　【特殊能力】物理攻撃が対象にヒットする度に、【闇】ダメージが追加で発生する。";
        this._strength = 3;
        this._agility = 0;
        this._intelligence = 3;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.CLASSICAL_LARGE_STAFF:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 41;
        this._magicAttackMax = 65;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 7000;
        this._importantType = Important.None;
        this._description = "伝統的な大杖。威力、使いやすさと共に申し分はない。魔法攻撃力４１～６５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.CLASSICAL_SHIELD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._physicalDefense = 10;
        this._gold = 3200;
        this._importantType = Important.None;
        this._description = "伝統的な盾。持ちやすさと防御のしやすさ、共に申し分はない。物理防御力１０";
        break;

      case Fix.IRON_SHIELD:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._physicalDefense = 17;
        this._gold = 3900;
        this._importantType = Important.None;
        this._description = "ゴツくて重たい鉄製の盾。使いにくさはあるが、ガッチリ防衛するのには適している。物理防御力１７、体＋２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 2;
        this._mind = 0;
        break;

      case Fix.SILVER_EARTH_SHIELD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._physicalDefense = 26;
        this._magicDefense = 15;
        this._gold = 3900;
        this._importantType = Important.None;
        this._description = "土属性のエッセンスをシルバー素材に埋め込んで作成された盾。物理防御はもちろんの事、魔法耐性も幾ばくか付与されている。物理防御力２６、魔法防御力１５、体＋３、土耐性＋１５０、沈黙耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
        this._resistEarth = 150;
        this._resistSilence = true;
        break;

      case Fix.CLASSICAL_ARMOR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 16;
        this._gold = 3600;
        this._importantType = Important.None;
        this._description = "伝統的な鎧。重量感、防御力共に申し分はない。物理防御力１６";
        break;

      case Fix.IRON_ARMOR:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 27;
        this._gold = 3600;
        this._importantType = Important.None;
        this._description = "暑苦しいが硬さを保証してくれる鉄製の鎧。物理防御力２７、体＋２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 2;
        this._mind = 0;
        break;

      case Fix.ROIZ_IMPERIAL_ARMOR:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 41;
        this._gold = 7000;
        this._importantType = Important.None;
        this._description = "ロイズ社が皇族向けに制作した鎧。護衛を示す印が刻まれており装着者は様々な恩恵を受けられる。物理防御力４１、体＋４、土耐性１５０、風耐性１５０、スタン耐性、沈黙耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 4;
        this._mind = 0;
        this._resistEarth = 150;
        this._resistWind = 150;
        this._resistStun = true;
        this._resistSilence = true;
        break;

      case Fix.CLASSICAL_CROSS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 10;
        this._magicDefense = 6;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 3400;
        this._importantType = Important.None;
        this._description = "伝統的な舞踏衣。軽さと防御力共に申し分はない。物理防御力１０、魔法防御力６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.CROSSCHAIN_MAIL:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 17;
        this._magicDefense = 10;
        this._gold = 4300;
        this._importantType = Important.None;
        this._description = "通常の舞踏衣を意識したものではなく、素早さを求めつつある程度の防御力も兼ね備えている。物理防御力１７、魔法防御力１０、体＋１、心＋１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 1;
        this._mind = 1;
        break;

      case Fix.SWIFT_THUNDER_CROSS:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 26;
        this._magicDefense = 15;
        this._gold = 6800;
        this._importantType = Important.None;
        this._description = "重さを全く感じさせない稲妻紋様が入った舞踏衣。攻守を兼ね備えた防護服として仕上がっている。物理防御力２６、魔法防御力１５、体＋２、心＋２、炎耐性＋１５０、氷耐性＋１５０、猛毒耐性、鈍化耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 2;
        this._mind = 2;
        this._resistFire = 150;
        this._resistIce = 150;
        this._resistPoison = true;
        this._resistSlow = true;
        break;

      case Fix.CLASSICAL_ROBE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 4;
        this._magicDefense = 12;
        this._gold = 4200;
        this._importantType = Important.None;
        this._description = "伝統的なローブ。薄さと魔法防御共に申し分はない。物理防御力４、魔法防御力１２";
        break;

      case Fix.CHIFFON_ROBE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 7;
        this._magicDefense = 20;
        this._gold = 4700;
        this._importantType = Important.None;
        this._description = "シフォン製で製作された高級感が漂うローブ。見た目とは裏腹に戦闘特化型の形態となっており動きやすい。物理防御力７、魔法防御力２０、心＋２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 2;
        break;

      case Fix.CROWD_DIRGE_ROBE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 10;
        this._magicDefense = 31;
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "ローブにしては重量感を伴うが、通常の魔法耐性以外にも聖・闇に対する特化能力がこめられている。物理防御力１０、魔法防御力３１、心＋４、聖耐性＋１５０、闇耐性＋１５０、束縛耐性、恐怖耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 4;
        this._resistLight = 150;
        this._resistShadow = 150;
        this._resistBind = true;
        this._resistFear = true;
        break;

      case Fix.HUANTEI_RING:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "パワーを感じる事はあるが、安定しない感触がある指輪。力＋２、知＋２、心＋２";
        this._strength = 2;
        this._agility = 0;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 2;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.DEPRESS_FEATHER:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "軽快な感触は得られず、不運な感情がつきまとう羽飾り。技＋２、知＋２、心＋２";
        this._strength = 0;
        this._agility = 2;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 2;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.STIFF_BELT:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "しっかりした形で頑丈なのだが、窮屈すぎるベルト。力＋２、体＋２、心＋２";
        this._strength = 2;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 2;
        this._mind = 2;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.LOST_NAME_EMBLEM:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "由緒正しき家系を示す紋様に見えるが、原型を留めておらず、活力は感じられない。知＋２、体＋２、心＋２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 2;
        this._stamina = 2;
        this._mind = 2;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.DAMAGED_STATUE:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "何か象徴的なものを司る彫像だったようだが、破損がひどく容が見えない。力＋２、技＋２、心＋２";
        this._strength = 2;
        this._agility = 2;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 2;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.USED_HQ_BOOTS:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "元々は高品質素材で作られたブーツの様だが、かなり使用されたもので履き心地が良くない。技＋２、体＋２、心＋２";
        this._strength = 0;
        this._agility = 2;
        this._intelligence = 0;
        this._stamina = 2;
        this._mind = 2;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

        // todo 炎耐性以外は記述不要なパラメタ。全switch-caseで不要パラメタを明記するのは不要である。
      case Fix.MAGICLIGHT_FIRE:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gold = 1200;
        this._description = "炎の残影を宿しているマジックライト。僅かに炎のイメージが入り込んでくる。体＋３、炎耐性５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
        this._resistFire = 50; // todo パーセンテージで 0.00 ~ 1.00のパラメタだが、減値 50を埋め込む値ではない。
        break;

      case Fix.MAGICLIGHT_ICE:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gold = 1200;
        this._description = "氷の残影を宿しているマジックライト。僅かに氷のイメージが入り込んでくる。体＋３、氷耐性５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
        this._resistIce = 50; // todo パーセンテージで 0.00 ~ 1.00のパラメタだが、減値 50を埋め込む値ではない。
        break;

      case Fix.MAGICLIGHT_SHADOW:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gold = 1200;
        this._description = "闇の残影を宿しているマジックライト。僅かに闇のイメージが入り込んでくる。体＋３、闇耐性５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
        this._resistShadow = 50; // todo パーセンテージで 0.00 ~ 1.00のパラメタだが、減値 50を埋め込む値ではない。
        break;

      case Fix.MAGICLIGHT_LIGHT:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gold = 1200;
        this._description = "聖の残影を宿しているマジックライト。僅かに聖のイメージが入り込んでくる。体＋３、聖耐性５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
        this._resistLight = 50; // todo パーセンテージで 0.00 ~ 1.00のパラメタだが、減値 50を埋め込む値ではない。
        break;

      case Fix.MAGICLIGHT_WIND:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gold = 1200;
        this._description = "風の残影を宿しているマジックライト。僅かに風のイメージが入り込んでくる。体＋３、風耐性５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
        this._resistWind = 50; // todo パーセンテージで 0.00 ~ 1.00のパラメタだが、減値 50を埋め込む値ではない。
        break;

      case Fix.MAGICLIGHT_EARTH:
        this._rarity = Rarity.Poor;
        this._itemType = ItemTypes.Accessory;
        this._gold = 1200;
        this._description = "土の残影を宿しているマジックライト。僅かに土のイメージが入り込んでくる。体＋３、土耐性５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
        this._resistEarth = 50; // todo パーセンテージで 0.00 ~ 1.00のパラメタだが、減値 50を埋め込む値ではない。
        break;

      case Fix.COPPERRING_TIGER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "虎の刻印が施された銅の腕輪。力＋５、技＋５";
        this._strength = 5;
        this._agility = 5;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.COPPERRING_DORPHINE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "イルカの刻印が施された銅の腕輪。力＋５、知＋５";
        this._strength = 5;
        this._agility = 0;
        this._intelligence = 5;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.COPPERRING_HORSE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "馬の刻印が施された銅の腕輪。力＋５、体＋５";
        this._strength = 5;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 5;
        this._mind = 0;
        break;

      case Fix.COPPERRING_BEAR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "熊の刻印が施された銅の腕輪。力＋５、心＋５";
        this._strength = 5;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 5;
        break;

      case Fix.COPPERRING_HAYABUSA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "隼の刻印が施された銅の腕輪。技＋５、知＋５";
        this._strength = 0;
        this._agility = 5;
        this._intelligence = 5;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.COPPERRING_OCTOPUS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "タコの刻印が施された銅の腕輪。技＋５、体＋５";
        this._strength = 0;
        this._agility = 5;
        this._intelligence = 0;
        this._stamina = 5;
        this._mind = 0;
        break;

      case Fix.COPPERRING_RABBIT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "兎の刻印が施された銅の腕輪。技＋５、心＋５";
        this._strength = 0;
        this._agility = 5;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 5;
        break;

      case Fix.COPPERRING_SPIDER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "蜘蛛の刻印が施された銅の腕輪。知＋５、体＋５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 5;
        this._stamina = 5;
        this._mind = 0;
        break;

      case Fix.COPPERRING_DEER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "鹿の刻印が施された銅の腕輪。知＋５、心＋５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 5;
        this._stamina = 0;
        this._mind = 5;
        break;

      case Fix.COPPERRING_ELEPHANT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gold = 2000;
        this._description = "象の刻印が施された銅の腕輪。体＋５、心＋５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 5;
        this._mind = 5;
        break;

      case Fix.RED_AMULET:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3500;
        this._description = "純赤色を司るアミュレット。確かな力のエッセンスを感じ取れる。力＋１５";
        this._strength = 15;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BLUE_AMULET:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3500;
        this._description = "純青色を司るアミュレット。確かな技のエッセンスを感じ取れる。技＋１５";
        this._strength = 0;
        this._agility = 15;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PURPLE_AMULET:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3500;
        this._description = "純紫色を司るアミュレット。確かな知のエッセンスを感じ取れる。知＋１５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 15;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.GREEN_AMULET:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3500;
        this._description = "純緑色を司るアミュレット。確かな体のエッセンスを感じ取れる。体＋１５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 15;
        this._mind = 0;
        break;

      case Fix.YELLOW_AMULET:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3500;
        this._description = "純黄色を司るアミュレット。確かな心のエッセンスを感じ取れる。心＋１５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 15;
        break;

      case Fix.STEEL_ANKLET:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3800;
        this._description = "鋼鉄製のアンクレット。安定感を生む脚力を引き出してくれる。力＋７、体＋５、麻痺耐性";
        this._strength = 7;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 5;
        this._mind = 0;
        this._resistParalyze = true;
        break;

      case Fix.CLEAN_HEARBAND:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3800;
        this._description = "清潔感のある髪飾り。安らぎと闘争心を同時にもたらしてくれる。技＋５、知＋７、睡眠耐性";
        this._strength = 0;
        this._agility = 5;
        this._intelligence = 7;
        this._stamina = 0;
        this._mind = 0;
        this._resistSleep = true;
        break;

      case Fix.TRUTH_GLASSES:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3800;
        this._description = "真実が見えると噂されているメガネ。しかし装着自体に意味はなく、パワーアップを感じるかどうかは本人の心得次第である。技＋５、心＋７、誘惑耐性";
        this._strength = 0;
        this._agility = 5;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 7;
        this._resistTemptation = true;
        break;

      case Fix.FIVECOLOR_COMPASS:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 4000;
        this._description = "カラフルな色で構成されたコンパス。暗い中でもこれがあれば安心できる上、色彩が活力を与えてくれる。力＋４、技＋４、知＋４、体＋４、心＋４";
        this._strength = 4;
        this._agility = 4;
        this._intelligence = 4;
        this._stamina = 4;
        this._mind = 4;
        break;

      case Fix.ZEPHYR_FEATHER_BLUE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 7200;
        this._description = "ゼフィールの羽は装着者に研ぎ澄まされた高速の感覚を与えてくる。また、ワンテンポ上位の戦闘感覚が身体に流れ込んでくる。技＋２２、知＋８、鈍化耐性、スタン耐性、氷属性の攻撃ダメージ＋５％";
        this._strength = 0;
        this._agility = 22;
        this._intelligence = 8;
        this._stamina = 0;
        this._mind = 0;
        this._resistSlow = true;
        this._resistStun = true;
        this._amplifyIce = 1.05f;
        break;

      case Fix.CRIMSON_GAUNTLET:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 7500;
        this._description = "深紅に染まった重厚なガントレットは装着者に武器を振るう時の手元のグリップ力を増強してくれる。また、ワンテンポ上位の攻撃する意志を伝導させてくる。力＋２２、技＋８、沈黙耐性、束縛耐性、炎属性の攻撃ダメージ＋５％";
        this._strength =22;
        this._agility = 8;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this._resistSilence = true;
        this._resistBind = true;
        this._amplifyFire = 1.05f;
        break;

      case Fix.BURIED_DANZAIANGEL_STATUE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 8000;
        this._description = "闇を司る断罪天使を形容させた偶像。これを持っているだけで、闇からの恩恵を受けている感覚が発生する。知＋２２、体＋８、恐怖耐性、誘惑耐性、闇属性の攻撃ダメージ＋５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 22;
        this._stamina = 8;
        this._mind = 0;
        this._resistFear = true;
        this._resistTemptation = true;
        this._amplifyShadow = 1.05f;
        break;

      case Fix.LIGHT_HAKURUANGEL_STATUE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 8000;
        this._description = "聖を司る琥珀天使を形容させた偶像。偶像から放たれる聖なるオーラは保持者に対して勇気を護衛の意志を与える。体＋２２、心＋８、猛毒耐性、スタン耐性、聖属性の攻撃ダメージ＋５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 22;
        this._stamina = 0;
        this._mind = 8;
        this._resistPoison = true;
        this._resistStun = true;
        this._amplifyLight = 1.05f;
        break;

      case Fix.JADE_NOBLE_CIRCLET:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 8500;
        this._description = "とある王国が栄えた時代、このサークレットを装着していた者が安定した支配で世界を治めていたと言われている。力＋１０、技＋１０、知＋１０、宝玉ソケット１、風耐性１００、風属性の攻撃ダメージ＋５％";
        this._strength = 10;
        this._agility = 10;
        this._intelligence = 10;
        this._stamina = 0;
        this._mind = 0;
        this._resistWind = 100;
        this._amplifyWind = 1.05f;
        this.CanbeSocket1 = true;
        break;

      case Fix.ADILORB_OF_THE_GARVANDI:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._magicAttack = 56;
        this._magicAttackMax = 83;
        this._gold = 30000;
        this._description = "古代賢者エーディルが少年時代に身に着けていた水晶型のアクセサリ。装着者には無限にも等しき魔力が流れ込むと言われている。魔法攻撃力５６～８３、技＋２３、知＋４５、体＋３１、沈黙耐性、スタン耐性、恐怖耐性、炎耐性５００、氷属性の攻撃ダメージ＋７％、戦速率＋３％、宝玉ソケット＋１";
        this._strength = 0;
        this._agility = 23;
        this._intelligence = 45;
        this._stamina = 31;
        this._mind = 0;
        this._resistSilence = true;
        this._resistStun = true;
        this._resistFear = true;
        this._resistFire = 500;
        this._amplifyIce = 1.07f;
        this._amplifyBattleSpeed = 1.03f;
        this.CanbeSocket1 = true;
        break;

      #endregion
      #region "神秘の森"
      case Fix.SMART_CLAW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 45;
        this._physicalAttackMax = 50;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた爪。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力４５～５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.DANCING_CLAW:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 52;
        this._physicalAttackMax = 57;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5250;
        this._importantType = Important.None;
        this._description = "舞踏術を好む者から定評がある爪。使い勝手が良く、手に馴染みやすい。物理攻撃力５２～５７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.WRATH_SABEL_CLAW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 81;
        this._physicalAttackMax = 99;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0; // todo
        this._importantType = Important.None;
        this._description = "重量をほぼ感じさせないため、装着者は自由に荒れ狂う拳を振る舞う事ができる爪。物理攻撃力８１～９９、技＋１０、心＋１０　【特殊能力】物理攻撃が対象にヒットする度に、20%の確率で対象に【スリップ】のBUFFを付与する。";
        this._strength = 0;
        this._agility = 10;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 10;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 48;
        this._physicalAttackMax = 64;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた剣。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力４８～６４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.CUTTING_BLADE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 58;
        this._physicalAttackMax = 77;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5750;
        this._importantType = Important.None;
        this._description = "切れ味が良く、振るう者にとって負担の少ない剣。軽さのわりに威力は大きい。物理攻撃力５８～７７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ENSHOUTOU:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 77;
        this._physicalAttackMax = 102;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0; // todo
        this._importantType = Important.None;
        this._description = "炎の残痕が宿り続けている刀。刀は振るわれる度に、炎の飛礫が周囲へと飛翔する。物理攻撃力７７～１０２、力＋１０、心＋１０　【特殊能力】物理攻撃が対象にヒットする度に、【炎】ダメージが追加で発生する。";
        this._strength = 10;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 10;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 56;
        this._physicalAttackMax = 76;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた槍。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力５６～７６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SWIFT_SPEAR:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 67;
        this._physicalAttackMax = 91;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6250;
        this._importantType = Important.None;
        this._description = "突きに行く構えから実際に繰り出されるまでの速度が非常に早く感じられる槍。物理攻撃力６７～９１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.GALLANT_FEATHER_LANCE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 90;
        this._physicalAttackMax = 122;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0; // todo
        this._importantType = Important.None;
        this._description = "ガーラント王国に代々伝わる羽根つきの槍。高貴なる感覚と気品が宿っており、所持するものに勇気を与えてくれる。物理攻撃力９０～１２２、力＋１０、技＋１０　【特殊能力】物理攻撃がヒットする度に、【風】ダメージが追加で発生する。";
        this._strength = 10;
        this._agility = 10;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_BOW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 83;
        this._physicalAttackMax = 127;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた弓。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力８３～１２７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.LONG_BOW:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 65;
        this._physicalAttackMax = 73;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6750;
        this._importantType = Important.None;
        this._description = "手を添える箇所が遠めに設定されており、使うためには少々の訓練が必要。物理攻撃力６５～７３";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 64;
        this._physicalAttackMax = 88;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 7000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた斧。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力６４～８８";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.POWERED_AXE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 77;
        this._physicalAttackMax = 106;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 7250;
        this._importantType = Important.None;
        this._description = "力強く振り回した時、それに呼応する形で威力の出る斧。つかうためには少々の訓練が必要。物理攻撃力７７～１０６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.THUNDER_BREAK_AXE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 102;
        this._physicalAttackMax = 141;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0; // todo
        this._importantType = Important.None;
        this._description = "持ち手には電光が宿っており、豪快なスイングで振るう事で、雷鳴が轟く斧。物理攻撃力１０２～１４１、力＋１０、体＋１０　【特殊能力】物理攻撃がヒットする度に、20%の確率で対象に【麻痺】のBUFFを付与する。";
        this._strength = 10;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 10;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_ORB:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 45;
        this._magicAttackMax = 55;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた水晶。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力４５～５５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FOCUS_ORB:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 54;
        this._magicAttackMax = 66;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5250;
        this._importantType = Important.None;
        this._description = "一点集中する事のために作られた水晶。安定感ある威力のため、一定の層から人気がある。魔法攻撃力５４～６６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.INTRINSIC_FROZEN_ORB:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 81;
        this._magicAttackMax = 99;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0; // todo
        this._importantType = Important.None;
        this._description = "その水晶の素材は天然の凍水石から生成されており、氷表面がとだえる事は決してない。魔法攻撃力８１～９９、技＋１０、知＋１０　【特殊能力】魔法攻撃がヒットする度に、20%の確率で対象に【凍結】のBUFFを付与する。";
        this._strength = 0;
        this._agility = 10;
        this._intelligence = 10;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_ROD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 48;
        this._magicAttackMax = 64;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた杖。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力４８～６４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.AUTUMN_ROD:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 58;
        this._magicAttackMax = 77;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5750;
        this._importantType = Important.None;
        this._description = "見た目とは裏腹に振りかざすと一般的な杖よりも威力を弾き出す。魔法攻撃力５８～７７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.DORN_NAMELESS_ROD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 77;
        this._magicAttackMax = 102;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0; // todo
        this._importantType = Important.None;
        this._description = "遥か西に存在する大地の王国ドルンで重宝された杖。威力と効果が非常に良いのだが名称があまり伝承されていない。魔法攻撃力７７～１０２、知＋１０、心＋１０　【特殊能力】魔法攻撃がヒットする時、クリティカル発生率が10%上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 10;
        this._stamina = 0;
        this._mind = 10;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_BOOK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 56;
        this._magicAttackMax = 76;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた本。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力５６～７６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.BULKY_BOOK:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 67;
        this._magicAttackMax = 91;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6250;
        this._importantType = Important.None;
        this._description = "通常のサイズよりも大き目に誤って作成された本。扱いは難しい感じがするが、威力に申し分はない。魔法攻撃力６７～９１";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FINESSE_IMPERIAL_BOOK:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 90;
        this._magicAttackMax = 122;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0; // todo
        this._importantType = Important.None;
        this._description = "玉座には常にその一冊が置かれており、その威力が減る事はない。魔法攻撃力９０～１２２、知＋１０、体＋１０　【特殊能力】味方を対象にする魔法を唱える度に、自分自身のライフが回復する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 10;
        this._stamina = 10;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_SHIELD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 25;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 3200;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの盾。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力２５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.WIDE_BUCKLER:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 38;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 3800;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_ARMOR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 45;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 3600;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの鎧。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力４５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.GOTHIC_PLATE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 68;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 3800;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_CROSS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 28;
        this._magicDefense = 17;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの舞踏衣。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力２８、魔法防御力１７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FITNESS_CROSS:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 42;
        this._magicDefense = 25;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0; // todo
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの舞踏衣。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力４２、魔法防御力２５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMART_ROBE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 11;
        this._magicDefense = 34;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4400;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りのローブ。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力１１、魔法防御力３４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SILK_ROBE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 17;
        this._magicDefense = 51;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4600;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.WATERY_RING:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 5;
        this._stamina = 3;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SUPERIOR_FEATHER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 5;
        this._intelligence = 3;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.HEAVYWEIGHT_SHOULDER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 5;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.TIGHT_BOOTS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 3;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 5;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.GORGEOUS_MANTLE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 3;
        this._agility = 0;
        this._intelligence = 5;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SWEET_BANGLE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 3;
        this._agility = 5;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.NAMELESS_HAT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 3;
        this._stamina = 0;
        this._mind = 5;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.WARM_LEGGUARD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 5;
        this._mind = 3;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      #endregion
      #region "ポーション"
      case Fix.SMALL_RED_POTION:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 60;
        this._itemValue2 = 80;
        this._gold = 150;
        this._importantType = Important.None;
        this._description = "小さい赤ポーション。初心者の間は重宝する必需品。ライフ回復量60～80";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.NORMAL_RED_POTION:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 300;
        this._itemValue2 = 450;
        this._gold = 400;
        this._importantType = Important.None;
        this._description = "普通の赤ポーション。一般的な戦闘において重宝する必需品。ライフ回復量300～450";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.LARGE_RED_POTION:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 700;
        this._itemValue2 = 960;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "大きな赤ポーション。ある程度戦闘経験を積んだ者にとっては重宝する必需品。ライフ回復700～960";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.HUGE_RED_POTION:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 1500;
        this._itemValue2 = 2300;
        this._gold = 3200;
        this._importantType = Important.None;
        this._description = "巨大な赤ポーション。歴戦の強者達が好んで携帯する必需品。ライフ回復1500～2300";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.HQ_RED_POTION:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 3600;
        this._itemValue2 = 4500;
        this._gold = 5400;
        this._importantType = Important.None;
        this._description = "高品質の赤ポーション。上級戦では常識で使用される必需品。ライフ回復3600～4500";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.THQ_RED_POTION:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 8000;
        this._itemValue2 = 12000;
        this._gold = 8500;
        this._importantType = Important.None;
        this._description = "最高品質の赤ポーション。上位ランクを超えし者が手にする必需品。ライフ回復8000～12000";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PERFECT_RED_POTION:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 25000;
        this._itemValue2 = 30000;
        this._gold = 15000;
        this._importantType = Important.None;
        this._description = "完全な赤ポーション。入手できた者はこの世に僅かしか存在しない。ライフ回復25000～30000";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.SMALL_BLUE_POTION:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 30;
        this._itemValue2 = 40;
        this._gold = 150;
        this._importantType = Important.None;
        this._description = "小さい青ポーション。初心者の間は重宝する必需品。ソウルポイント回復量30～40";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.NORMAL_BLUE_POTION:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 160;
        this._itemValue2 = 240;
        this._gold = 400;
        this._importantType = Important.None;
        this._description = "普通の青ポーション。一般的な戦闘において重宝する必需品。ソウルポイント回復量160～240";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.LARGE_BLUE_POTION:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 320;
        this._itemValue2 = 400;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "大きな青ポーション。ある程度戦闘経験を積んだ者にとっては重宝する必需品。ソウルポイント回復320～400";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.HUGE_BLUE_POTION:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 600;
        this._itemValue2 = 1000;
        this._gold = 3200;
        this._importantType = Important.None;
        this._description = "巨大な青ポーション。歴戦の強者達が好んで携帯する必需品。ソウルポイント回復600～1000";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.HQ_BLUE_POTION:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 1500;
        this._itemValue2 = 2000;
        this._gold = 5400;
        this._importantType = Important.None;
        this._description = "高品質の青ポーション。上級戦では常識で使用される必需品。ソウルポイント回復1500～2000";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.THQ_BLUE_POTION:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 3500;
        this._itemValue2 = 5000;
        this._gold = 8500;
        this._importantType = Important.None;
        this._description = "最高品質の青ポーション。上位ランクを超えし者が手にする必需品。ソウルポイント回復3500～5000";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PERFECT_BLUE_POTION:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 10000;
        this._itemValue2 = 12000;
        this._gold = 15000;
        this._importantType = Important.None;
        this._description = "完全な青ポーション。入手出来た者はこの世に僅かしか存在しない。ソウルポイント回復10000～12000";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;
      #endregion
      #region "other"
      case Fix.ZETANIUM_STONE:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "アーサリウム工場跡地で採取した鉱石。薄汚れた色をしているが、中身の強度は失われておらず、再利用することが出来そうだ。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FIELD_RESEARCH_LICENSE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "各地への遠征を可能とする公式の許可証。この許可証を持っていれば、各区域に対して自由に行き来する事ができる様になる。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ITEM_MATOCK:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "アーサリウム工場内で発見したマトック。だいぶ色が剥げているがまだまだ強度はあり、十分に使える。岩壁の近くで使えば、岩を崩す事ができるようになる。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ITEM_TOOMI_AOSUISYOU:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "水晶の奥を深くのぞき込む事で、対象の地点へワープする事が出来る。ダンジョン内であれば、ダンジョン入口へ移動する事が出来、フィールド上では一度訪れた事のある地点へワープする事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ITEM_WALKING_ROPE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "ゴラトラム洞窟内で発見した綱渡り専用のロープ。大きな穴が開いており、少々飛んだだけでは渡れそうもない箇所でも、本アイテムをうまく駆使すれば、向こう側に渡る事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ITEM_COPPER_KEY:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "ゴラトラム洞窟で入手した銅製の鍵。鍵がかかっている銅製の扉に対して使用する事で、扉は開くだろう。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.PURE_CLEAN_WATER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Potion;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "純正透明色の液体で生成された回復ポーション。飲んだ者のライフを100%回復する。ただし1度使うと空となるが、次の日になれば自然発生によりポーションはまた使える様になる。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.RESIST_POISON_SUIT:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "フィールドに流れ出している毒から身を守る事が出来る防護服。薄い透明の素材で出来ており、見た目はほぼ変わらず、動きに支障をきたす事もない。これを着ている事により、毒のフィールドから受けるダメージを軽減する事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ARTHARIUM_KEY:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "アーサリウム工場跡地の内部で見つけた扉の鍵。本エリア内に設置されている扉に鍵がかかっている場合、この鍵を使用する事で扉を開ける事が出来るようになる。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.UNKNOWN_OBJECT:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "工場跡地の奥地にて入手した奇妙な物体。アインが触れた瞬間に見たこともない形状の空間を形成した。今は元の形状に戻っており、触れても何も起こらない。物体は常に少しだけ宙に浮いている状態で、何かに使える様な代物ではなさそうだ。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.MARBLE_STAR:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "アーケンダイン街にある占いの館で入手した物。空に浮かび上がっている赤い星について尋ねた時に入手したもの。使い道については一切知らされておらず用途は不明である。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ZHALMAN_NECKLACE:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.EventItem;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "ツァルマンの里にいる長老より受け渡された首飾り。この首飾りは「神秘の森」へ入るための許可証の役割を果たしている。これがあれば「神秘の森」へは自由に行き来する事が出来るようになる。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ZEMULGEARS:
        this._rarity = Rarity.Legendary;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 100;
        this._physicalAttack = 10000;
        this._physicalAttackMax = 15000;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "その輝きが放たれる事は無い。選ばれし者のみが心に宿らせる剣。物理攻撃力10000～15000。ジュエルソケット５。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = true;
        this.CanbeSocket2 = true;
        this.CanbeSocket3 = true;
        this.CanbeSocket4 = true;
        this.CanbeSocket5 = true;
        break;

      case Fix.ARTIFACT_GENSEI:
        this._rarity = Rarity.Legendary;
        this._itemType = ItemTypes.Artifact;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "十七宝珠の一つ「厳正の宝珠」。王が見定めるは大いなる天空と静粛なる視点。ソケットに埋め込む事により、さらにその輝きは増す。力+5、心＋10、「宝玉ソケット埋め込み時：力+10、心＋5」";
        this._strength = 5;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 10;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ARTIFACT_ZIHI:
        this._rarity = Rarity.Legendary;
        this._itemType = ItemTypes.Artifact;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "慈悲の宝珠。ソケットに埋め込む事により、さらにその輝きは増す。体+1000、「宝玉ソケット埋め込み時：体+500、心+500」";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 1000;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ARTIFACT_MUSOU:
        this._rarity = Rarity.Legendary;
        this._itemType = ItemTypes.Artifact;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "無双の宝珠。ソケットに埋め込む事により、さらにその輝きは増す。技＋1000、「宝玉ソケット埋め込み時：技+500、知+500」";
        this._strength = 0;
        this._agility = 1000;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ARTIFACT_ZETSUKEN:
        this._rarity = Rarity.Legendary;
        this._itemType = ItemTypes.Artifact;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "絶剣の宝珠。ソケットに埋め込む事により、さらにその輝きは増す。力＋1000、「宝玉ソケット埋め込み時：力＋500、技+500」";
        this._strength = 1000;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.ARTIFACT_JOURYOKU:
        this._rarity = Rarity.Legendary;
        this._itemType = ItemTypes.Artifact;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "常緑の宝珠。ソケットに埋め込む事により、さらにその輝きは増す。知＋1000、「宝玉ソケット埋め込み時：知＋500、体+500」";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 1000;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.FIRE_ANGEL_TALISMAN:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 5;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Normal;
        this._description = "炎授天使からの加護が得られる護符。魔法防御力が全体的に上がる事に加え、炎に特化した耐性が付く。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 3;
        this._stamina = 0;
        this._mind = 3;
        this._resistFire = 0.30f;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;
        #endregion

    }

    SetupLimitValue();
  }
  #endregion
}
