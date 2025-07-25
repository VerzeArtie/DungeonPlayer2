﻿using System;
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
    Jewel,
    Potion,
    EventItem,
    SellOnly,
    Material_Equip,
    Material_Potion,
    Material_Food,
    Use_Item,
    Use_BlueOrb,
    Useless,
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

  // [comment] アイテム消耗品より、RARE_EPICだった場合はスタック１とすること。
  //           装備品はRARE_EPICと同等で気にしなくて良い。
  public const int USING_ITEM_STACK_SIZE = 5;
  public const int RARE_EPIC_ITEM_STACK_SIZE = 1;
  public const int EQUIP_ITEM_STACK_SIZE = 1;
  public const int MATERIAL_ITEM_STACK_SIZE = 10;
  public const int OTHER_ITEM_STACK_SIZE = 10;

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

  public double _resistFirePercent = 0.0f;
  public double ResistFirePercent
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistFirePercent = value;
    }
    get { return _resistFirePercent; }
  }

  public double _resistFireValue = 0.0f;
  public double ResistFireValue
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistFireValue = value;
    }
    get { return _resistFireValue; }
  }

  public double _resistIcePercent = 0.0f;
  public double ResistIcePercent
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistIcePercent = value;
    }
    get { return _resistIcePercent; }
  }

  public double _resistIceValue = 0.0f;
  public double ResistIceValue
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistIceValue = value;
    }
    get { return _resistIceValue; }
  }

  public double _resistLightPercent = 0.0f;
  public double ResistLightPercent
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistLightPercent = value;
    }
    get { return _resistLightPercent; }
  }

  public double _resistLightValue = 0.0f;
  public double ResistLightValue
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistLightValue = value;
    }
    get { return _resistLightValue; }
  }

  public double _resistShadowPercent = 0.0f;
  public double ResistShadowPercent
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistShadowPercent = value;
    }
    get { return _resistShadowPercent; }
  }

  public double _resistShadowValue = 0.0f;
  public double ResistShadowValue
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistShadowValue = value;
    }
    get { return _resistShadowValue; }
  }

  public double _resistWindPercent = 0.0f;
  public double ResistWindPercent
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistWindPercent = value;
    }
    get { return _resistWindPercent; }
  }

  public double _resistWindValue = 0.0f;
  public double ResistWindValue
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistWindValue = value;
    }
    get { return _resistWindValue; }
  }

  public double _resistEarthPercent = 0.0f;
  public double ResistEarthPercent
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistEarthPercent = value;
    }
    get { return _resistEarthPercent; }
  }

  public double _resistEarthValue = 0.0f;
  public double ResistEarthValue
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _resistEarthValue = value;
    }
    get { return _resistEarthValue; }
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

  // 蘇生不可への耐性
  protected bool _resistCannotResurrect = false;
  public bool ResistCannotResurrect
  {
    set { _resistCannotResurrect = value; }
    get { return _resistCannotResurrect; }
  }

  // ライフ回復不可への耐性
  protected bool _resistNoGainLife = false;
  public bool ResistNoGainLife
  {
    set { _resistNoGainLife = value; }
    get { return _resistNoGainLife; }
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
      #region "エスミリア草原区域"
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
        this._description = "サバイバル用の爪。戦闘用を意識されており形状が少し尖っている。物理攻撃力４～７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._description = "青銅の素材で製作された剣。標準的な剣よりも少しだけ重量感がある。物理攻撃力６～１０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._description = "生命を吸い取る魔剣。物理攻撃力１４～１９。【特殊効果】物理攻撃がヒットする毎に、自分自身のライフを回復する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.ItemValue1 = 12;
        this.ItemValue2 = 30;
        break;

      case Fix.AERO_BLADE:
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
        this._description = "疾風をまとった軽めの剣。切れ味は鋭い。物理攻撃力１４～１９【特殊効果】物理攻撃がヒットした時、20%の確率で追加で物理ダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.NAME_SIN_OSCURETE:
        this._rarity = Rarity.Epic;
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
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者オスキュレーテが幼少時代に付けていたリング。力＋６、技＋４、知＋１０、体＋３、心＋５、猛毒耐性、スタン耐性、眩暈耐性";
        this._strength = 6;
        this._agility = 4;
        this._intelligence = 10;
        this._stamina = 3;
        this._mind = 5;
        this._resistPoison = true;
        this._resistStun = true;
        this._resistDizzy = true;
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
        this._description = "古代賢者メルギズドが幼少時代に付けていたブレード。力＋１０、知＋８、心＋５、物理攻撃４５～６７、魔法攻撃２２～３４";
        this._strength = 10;
        this._agility = 0;
        this._intelligence = 8;
        this._stamina = 0;
        this._mind = 5;
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
        this._description = "細身の槍。持ち方は少々特殊であるが、一般品より威力は高い。物理攻撃力８～１４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._description = "海賊の斧。使いづらい側面はあるが一般的な斧より少々ダメージは出る。物理攻撃力１１～１８";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.EARTH_POWER_AXE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 24;
        this._physicalAttackMax = 39;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 3000;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で追加で物理ダメージを与える。物理攻撃力２４～３９";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._description = "エネルギーが充填されている水晶。これをもって詠唱すると魔力放出力が上がる。魔法攻撃力４～７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._description = "木製の杖。一般品よりも先端の形状が自然な形で出来ており、魔力が宿っている。魔法攻撃力６～１０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._description = "所持者に安心感を与える本。詠唱する時の持ちやすさが重視されている。魔法攻撃力８～１４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._description = "上部が丸みを帯びている盾。重さが軽量化されているが防御力は一般品よりも高い。物理防御力５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._description = "青い閃光が剣の中に埋め込まれている。剣を振るうたびに、青光の残影がのこるため、青い稲妻が走ったように見える。物理攻撃力４５～６２、力＋３、心＋３\r\n　【特殊効果】物理攻撃が対象にヒットする度に、【氷】ダメージが追加で発生する。";
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
        this._description = "粉塵を薙ぎ払う事を連想させる槍。比較的大きめで、槍の形も特殊な形状をしており、見ている者を恐れさせる。物理攻撃力５２～７５、力＋３、技＋３\r\n　【特殊効果】物理攻撃が対象にヒットした場合、【出血】のBUFFを付与する。";
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
        this._description = "骨を粉砕するぐらいの威力で猛威を振るう斧。全体的に大きめだが片手で振り回せ、かつ、打撃力も高い。物理攻撃力６０～９７、力＋３、体＋３\r\n　【特殊効果】物理攻撃が対象にヒットした場合、対象の物理防御力を１０％減少させる。";
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
        this._description = "武具全体が凍結した状態で固形化されており、非常に鋭い切れ味の爪に仕上がっている。物理攻撃力４２～５５、技＋３、心＋３\r\n　【特殊効果】物理攻撃が対象にヒットする度に、【氷】ダメージが追加で発生する。";
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
        this._description = "炎の力を増幅させるため、炎を２つの球体に分離した形で杖の取っ手に宿した大杖。魔法攻撃力４５～６３、知＋３、心＋３\r\n　【特殊効果】魔法攻撃が対象にヒットする度に、対象に【炎】ダメージが追加で発生する。";
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
        this._description = "ゴルゴンの目玉が描かれている魔道の書物。持っているだけでも禍々しさがあるが、魔法を放つ時その目が光りだす。魔法攻撃力５４～７６、知＋３、体＋３\r\n　【特殊効果】魔法攻撃が対象にヒットした場合、【猛毒】のBUFFを付与する。";
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
        this._description = "星型と丸形を融合させた形状のオーブ。白く輝いており、見ているものを惑わせる。魔法攻撃力４１～５０、技＋３、知＋３　【特殊効果】魔法攻撃が対象にヒットした場合、【聖】ダメージが追加で発生する。";
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
        break;

      case Fix.MAXCARN_X_BUSTER:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Twohand_Axe;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 83;
        this._physicalAttack = 90;
        this._physicalAttackMax = 250;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者マクスカーンが幼少時代に付けていた両手剣。力＋２５、技＋１５、心＋３０、物理攻撃９０～２５０";
        this._strength = 25;
        this._agility = 15;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 30;
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
        this._description = "禍々しい魔力がこめられた魔道弾丸が矢として放たれる。通常の物理攻撃とは異なる何かを受けた者は食らう。物理攻撃力６８～１０８、力＋３、知＋３\r\n　【特殊効果】物理攻撃が対象にヒットする度に、【闇】ダメージが追加で発生する。";
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
        this._description = "大地のエッセンスをシルバー素材に埋め込んで作成された盾。物理防御はもちろんの事、魔法耐性も幾ばくか付与されている。物理防御力２６、魔法防御力１５、体＋３、沈黙耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 3;
        this._mind = 0;
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
        this._description = "ロイズ社が皇族向けに制作した鎧。護衛を示す印が刻まれており装着者は様々な恩恵を受けられる。物理防御力４１、体＋４、聖耐性１５０、闇耐性１５０、スタン耐性、沈黙耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 4;
        this._mind = 0;
        this._resistLightValue = 150;
        this._resistShadowValue = 150;
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
        this._resistFireValue = 150;
        this._resistIceValue = 150;
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
        this._resistLightValue = 150;
        this._resistShadowValue = 150;
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
        this._resistFireValue = 50;
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
        this._resistIceValue = 50;
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
        this._resistShadowValue = 50;
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
        this._resistLightValue = 50;
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
        this._description = "とある王国が栄えた時代、このサークレットを装着していた者が安定した支配で世界を治めていたと言われている。力＋１０、技＋１０、知＋１０、出血耐性、闇耐性１００、聖属性の攻撃ダメージ＋１０％";
        this._strength = 10;
        this._agility = 10;
        this._intelligence = 10;
        this._stamina = 0;
        this._mind = 0;
        this._resistShadowValue = 100;
        this._amplifyLight = 1.10f;
        this._resistSlip = true;
        break;

      case Fix.ADILORB_OF_THE_GARVANDI:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._gold = 0;
        this._description = "古代賢者エーディルが少年時代に身に着けていた水晶型のアクセサリ。装着者には無限にも等しき魔力が流れ込むと言われている。技＋２５、知＋４５、体＋３０、沈黙耐性、スタン耐性、恐怖耐性、炎耐性２０％、氷増幅２０％、戦速率＋３％";
        this._strength = 0;
        this._agility = 25;
        this._intelligence = 45;
        this._stamina = 30;
        this._mind = 0;
        this._resistSilence = true;
        this._resistStun = true;
        this._resistFear = true;
        this._resistFirePercent = 0.20f;
        this._amplifyIce = 1.20f;
        this._amplifyBattleSpeed = 1.03f;
        break;

      #endregion
      #region "神秘の森"
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
        this._gold = 9000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた剣。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力４８～６４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 11000;
        this._importantType = Important.None;
        this._description = "切れ味が良く、振るう者にとって負担の少ない剣。軽さのわりに威力は大きい。物理攻撃力５８～７７、力＋６、心＋６";
        this._strength = 6;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 6;
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
        this._gold = 18000;
        this._importantType = Important.None;
        this._description = "炎の残痕が宿り続けている刀。刀は振るわれる度に、炎の飛礫が周囲へと飛翔する。物理攻撃力７７～１０２、力＋１０、心＋１０　【特殊効果】物理攻撃が対象にヒットする度に、【炎】ダメージが追加で発生する。";
        this._strength = 10;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 10;
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた槍。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力５６～７６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 12000;
        this._importantType = Important.None;
        this._description = "突きに行く構えから実際に繰り出されるまでの速度が非常に早く感じられる槍。物理攻撃力６７～９１、力＋６、技＋６";
        this._strength = 6;
        this._agility = 6;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 20000;
        this._importantType = Important.None;
        this._description = "ガーラント王国に代々伝わる羽根つきの槍。高貴なる感覚と気品が宿っており、所持するものに勇気を与えてくれる。物理攻撃力９０～１２２、力＋１０、技＋１０　【特殊効果】物理攻撃がヒットする度に、戦闘速度が２％上昇する。";
        this._strength = 10;
        this._agility = 10;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.VIRGIRANTE_HELLGATE_LANCE:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 280;
        this._physicalAttackMax = 400;
        this._magicAttack = 160;
        this._magicAttackMax = 250;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "失われた王国ヴィルジランテが栄華を誇った時代に作られた伝説の槍。槍の切っ先には黒い空間が宿っている。その形状は神々しくもあり、禍々しくもある。槍の効果は凄まじく、対象者はたちまち絶命の危機に瀕するだろう。物理攻撃力２８０～４００、魔法攻撃力１６０～２５０、力＋３５、技＋４５、知＋３０　【特殊効果】自分から物理攻撃を伴う行動を行った場合、クリティカルの発生率が５％上昇する。物理攻撃がクリティカルでヒットした場合、クリティカルダメージ量が５％上昇する。";
        this._strength = 35;
        this._agility = 45;
        this._intelligence = 30;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 11000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた斧。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力６４～８８";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 13000;
        this._importantType = Important.None;
        this._description = "力強く振り回した時、それに呼応する形で威力の出る斧。つかうためには少々の訓練が必要。物理攻撃力７７～１０６、力＋６、体＋６";
        this._strength = 6;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 6;
        this._mind = 0;
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
        this._gold = 24000;
        this._importantType = Important.None;
        this._description = "持ち手には電光が宿っており、豪快なスイングで振るう事で、雷鳴が轟く斧。物理攻撃力１０２～１４１、力＋１０、体＋１０　【特殊効果】物理攻撃がヒットする度に、30%の確率で対象に【麻痺】のBUFFを付与する。";
        this._strength = 10;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 10;
        this._mind = 0;
        break;

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
        this._gold = 8500;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた爪。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力４５～５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "舞踏術を好む者から定評がある爪。使い勝手が良く、手に馴染みやすい。物理攻撃力５４～６６、技＋６、心＋６";
        this._strength = 0;
        this._agility = 6;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 6;
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
        this._gold = 16000;
        this._importantType = Important.None;
        this._description = "重量をほぼ感じさせないため、装着者は自由に荒れ狂う拳を振る舞う事ができる爪。物理攻撃力８１～９９、技＋１０、心＋１０　【特殊効果】物理攻撃が対象にヒットする度に、30%の確率で対象に【スリップ】のBUFFを付与する。";
        this._strength = 0;
        this._agility = 10;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 10;
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
        this._gold = 9000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた杖。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力４８～６４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 11000;
        this._importantType = Important.None;
        this._description = "見た目とは裏腹に振りかざすと一般的な杖よりも威力を弾き出す。魔法攻撃力５８～７７、知＋６、心＋６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 6;
        this._stamina = 0;
        this._mind = 6;
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
        this._gold = 18000;
        this._importantType = Important.None;
        this._description = "遥か西に存在する大地の王国ドルンで重宝された杖。威力と効果が非常に良いのだが名称があまり伝承されていない。魔法攻撃力７７～１０２、知＋１０、心＋１０　【特殊効果】魔法攻撃がヒットする時、クリティカル発生率が10%上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 10;
        this._stamina = 0;
        this._mind = 10;
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた本。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力５６～７６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 12000;
        this._importantType = Important.None;
        this._description = "通常のサイズよりも大き目に誤って作成された本。扱いは難しい感じがするが、威力に申し分はない。魔法攻撃力６７～９１、知＋６、体＋６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 6;
        this._stamina = 6;
        this._mind = 0;
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
        this._gold = 20000;
        this._importantType = Important.None;
        this._description = "玉座には常にその一冊が置かれており、その威力が減る事はない。魔法攻撃力９０～１２２、知＋１０、体＋１０　【特殊効果】ライフ回復を伴う魔法を使用した時、ライフ回復量が５%上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 10;
        this._stamina = 10;
        this._mind = 0;
        break;

      case Fix.MULLERHAIZEN_AGARTA_BOOK:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 120;
        this._physicalAttackMax = 160;
        this._magicAttack = 330;
        this._magicAttackMax = 410;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "異国の大地で繁栄の一途を辿ったミュラーヘイゼンでは毎年最強の魔法武具大会が開催される。中でも本作品は突出しており、魔法を志す者にとって本作品を手にする事は最高の栄誉とされた。その威力は群を抜いており、保持者に確実な力を与えるだろう。物理攻撃力１２０～１６０、魔法攻撃力３３０～４１０、知＋６０、心＋６０　【特殊効果】自分から魔法攻撃を伴う行動を行った場合、クリティカルの発生率が５％上昇する。魔法攻撃がクリティカルでヒットした場合、クリティカルダメージ量が５％上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 60;
        this._stamina = 0;
        this._mind = 60;
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
        this._gold = 8500;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた水晶。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力４５～５５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "一点集中する事のために作られた水晶。安定感ある威力のため、一定の層から人気がある。魔法攻撃力５４～６６、技＋６、知＋６";
        this._strength = 0;
        this._agility = 6;
        this._intelligence = 6;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 16000;
        this._importantType = Important.None;
        this._description = "その水晶の素材は天然の凍水石から生成されており、氷表面がとだえる事は決してない。魔法攻撃力８１～９９、技＋１０、知＋１０　【特殊効果】魔法攻撃がヒットする度に、20%の確率で対象に【凍結】のBUFFを付与する。";
        this._strength = 0;
        this._agility = 10;
        this._intelligence = 10;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SMART_LARGE_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Sword;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 87;
        this._physicalAttack = 48;
        this._physicalAttackMax = 115;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 14000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた両手剣。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力４８～１１５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.FORCEFUL_BASTARD_SWORD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Sword;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 87;
        this._physicalAttack = 77;
        this._physicalAttackMax = 184;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 26000;
        this._importantType = Important.None;
        this._description = "洗練された鋭気を持って作製された巨大な剣。持ち手を選ぶが、誤りなく振るう事で真の効果を発揮する。物理攻撃力７７～１８４、力＋１５、心＋１５";
        this._strength = 15;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 15;
        break;

      case Fix.SMART_LARGE_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Lance;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 85;
        this._physicalAttack = 56;
        this._physicalAttackMax = 137;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 16000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた両手槍。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力５６～１３７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SHARPNEL_ARC_LANCER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Lance;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 85;
        this._physicalAttack = 90;
        this._physicalAttackMax = 219;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 29000;
        this._importantType = Important.None;
        this._description = "鋭い切っ先と、螺旋状に巻きついている物体がその強さを物語る。物理攻撃力９０～２１９、力＋１５、技＋１５";
        this._strength = 15;
        this._agility = 15;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SMART_LARGE_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Axe;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 83;
        this._physicalAttack = 64;
        this._physicalAttackMax = 158;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 18000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた両手斧。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力６４～１５８";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.OGRE_KILL_BUSTER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Axe;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 83;
        this._physicalAttack = 102;
        this._physicalAttackMax = 253;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "各地を支配しているオーガ軍勢を一刀両断できる豪快な両手斧。その強さはオーガ達をひるませる。物理攻撃力１０２～２５３、力＋１５、体＋１５";
        this._strength = 15;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 15;
        this._mind = 0;
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
        this._gold = 21000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた弓。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力８３～１２７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 23000;
        this._importantType = Important.None;
        this._description = "手を添える箇所が遠めに設定されており、使うためには少々の訓練が必要。物理攻撃力６５～７３";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.EXPLODING_ASH_BOW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 133;
        this._physicalAttackMax = 203;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 38000;
        this._importantType = Important.None;
        this._description = "弓を射たその瞬間、手元が爆発の炎に包まれた状態で矢が放たれる。対象者はその威力を身を持って知る事となる。物理攻撃力１３３～２０３、力＋１５、知＋１５";
        this._strength = 15;
        this._agility = 0;
        this._intelligence = 15;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SMART_LARGE_STAFF:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 75;
        this._magicAttackMax = 114;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 20000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた両手杖。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力７５～１１４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.EARTH_POWERED_STAFF:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 120;
        this._magicAttackMax = 182;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 36000;
        this._importantType = Important.None;
        this._description = "地母神による教えが授けられし巨大な杖。両手で持つのがやっとであり、威力を出すためのモーションにはそれなりの技量が必要。魔法攻撃力１２０～１８２、知＋１５、心＋１５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 15;
        this._stamina = 0;
        this._mind = 15;
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの盾。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力２５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 9000;
        this._importantType = Important.None;
        this._description = "攻撃的視点をある程度犠牲にして、防衛に特化した盾。物理防御力３８、体＋６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 6;
        this._mind = 0;
        break;

      case Fix.BLACK_REFLECTOR_SHIELD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 53;
        this._magicDefense = 37;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 15000;
        this._importantType = Important.None;
        this._description = "黒い装飾で容取られたシールド。その光沢は一定の魔法反射率を帯びており、魔法攻撃を主とする対象者からは恐れられている。物理防御５３、魔法防御３７、体＋１０　【特殊効果】魔法攻撃を受ける度に、３０％の確率で攻撃を行った対象者に魔法ダメージ1/2の分だけ反射してダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 10;
        this._mind = 0;
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
        this._gold = 8500;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの鎧。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力４５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 10500;
        this._importantType = Important.None;
        this._description = "遥か古代の様式をモチーフにした鎧。気品と頑丈さを兼ね備えている。物理防御力６８、体＋６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 6;
        this._mind = 0;
        break;

      case Fix.ARANDEL_FORCE_ARMOR:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 95;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 17000;
        this._importantType = Important.None;
        this._description = "古代賢者エーディルの一番弟子アランデルが愛用していた鎧。好戦的な行動を振る舞うものに確かな防御力を授ける。物理防御力９５、体＋１０、炎耐性３００、氷耐性３００、凍結耐性、沈黙耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 10;
        this._mind = 0;
        this._resistFireValue = 300;
        this._resistIceValue = 300;
        this._resistFreeze = true;
        this._resistSilence = true;
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
        this._gold = 8000;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの舞踏衣。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力２８、魔法防御力１７";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "身体に密着しやすい素材で作られており、俊敏な動きをするのに適している。物理防御力４２、魔法防御力２５、体＋４、心＋２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 4;
        this._mind = 2;
        break;

      case Fix.WONDERING_BLESSED_CROSS:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 59;
        this._magicDefense = 35;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 17000;
        this._importantType = Important.None;
        this._description = "未開の大地より加護を授けられた舞踏衣。製作者は不明だが大自然の恩恵がこの防具には宿っている。物理防御力５９、魔法防御力３５、体＋６、心＋４、闇耐性＋３００、氷耐性＋３００、スリップ耐性、スタン耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 6;
        this._mind = 4;
        this._resistShadowValue = 300;
        this._resistIcePercent = 300;
        this._resistSlip = true;
        this._resistStun = true;
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
        this._gold = 9200;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りのローブ。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力１１、魔法防御力３４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 11600;
        this._importantType = Important.None;
        this._description = "シルク製の素材で作製されたローブ。着こなしが良く愛用者は多い。物理防御力１７、魔法防御力５１、心＋６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 6;
        break;

      case Fix.SERANA_BRILLIANT_ROBE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 24;
        this._magicDefense = 71;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 19000;
        this._importantType = Important.None;
        this._description = "悠久都市セラーナにて限定的に販売された衣。輝かしい光を放つ衣からは威厳を感じ取れる。物理防御力２４、魔法防御力７１、心＋１０、聖耐性＋３００、氷耐性＋３００、沈黙耐性、眩暈耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 10;
        this._resistLightValue = 300;
        this._resistIceValue = 300;
        this._resistSilence = true;
        this._resistDizzy = true;
        break;

      case Fix.JUNK_TARISMAN_POISON:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、猛毒耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistPoison = true;
        break;

      case Fix.JUNK_TARISMAN_SILENCE:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、沈黙耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistSilence = true;
        break;

      case Fix.JUNK_TARISMAN_BIND:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、束縛耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistBind = true;
        break;

      case Fix.JUNK_TARISMAN_SLEEP:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、睡眠耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistSleep = true;
        break;

      case Fix.JUNK_TARISMAN_STUN:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、スタン耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistStun = true;
        break;

      case Fix.JUNK_TARISMAN_PARALYZE:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、麻痺耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistParalyze = true;
        break;

      case Fix.JUNK_TARISMAN_FROZEN:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、凍結耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistFreeze = true;
        break;

      case Fix.JUNK_TARISMAN_FEAR:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、恐怖耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistFear = true;
        break;

      case Fix.JUNK_TARISMAN_TEMPTATION:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、誘惑耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistTemptation = true;
        break;

      case Fix.JUNK_TARISMAN_SLOW:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、鈍化耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistSlow = true;
        break;

      case Fix.JUNK_TARISMAN_DIZZY:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、眩暈耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistDizzy = true;
        break;

      case Fix.JUNK_TARISMAN_SLIP:
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
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "今にも壊れそうなタリスマンだが、最低限の効果は期待できる。体＋２０、出血耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        this.ResistSlip = true;
        break;

      case Fix.SIHAIRYU_SIKOTU:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "常に在り続けるが、姿のない竜の意志が流れ込んでくる。指の骨は形を呈しているだけであり真実ではないが、直接的なパワーを感じ取れる。物攻率＋５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyPhysicalAttack = 1.05f; // todo 要検証
        break;

      case Fix.OLDGLORY_TREE_KAREHA:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "既に枯れてしまっているにも関わらず、古代栄樹の底知れぬ魔力を宿す。保持するだけで直接脳内へ魔力の根源が伝わってくる。魔攻率＋５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyMagicAttack = 1.05f; // todo 要検証
        break;

      case Fix.GALEWIND_KONSEKI:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "正しき秩序と整合性はこのゲイル・ウィンドから生じる事象。その痕跡だけではあるが、直接原理の意志が流れ込んでくる。戦速率＋５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyBattleSpeed = 1.05f; // todo 要検証
        break;

      case Fix.SIN_CRYSTAL_KAKERA:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "過去から現在、そして未来永劫決して輝きを失わないクリスタル。その欠片のみではあるが、所持者に直接的な反射能力を向上させる力が宿っている。戦応率＋５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyBattleResponse = 1.05f; // todo 要検証
        break;

      case Fix.EVERMIND_ZANSHI:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "現世には決して存在しない存在、エバー・マインド。その存在の残思は潜在意識へと直接コンタクトしてくる。既に朽ちてはいるが、そでもなお一定の効果は発揮される。潜力率＋５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyPotential = 1.05f; // todo 要検証
        break;

      case Fix.BRONZE_RING_KIBA:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。牙の刻印がしてある。力＋２４、技＋１６";
        this._strength = 24;
        this._agility = 16;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BRONZE_RING_SASU:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。刺の刻印がしてある。力＋１６、知＋２４";
        this._strength = 16;
        this._agility = 0;
        this._intelligence = 24;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BRONZE_RING_KU:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。駆の刻印がしてある。力＋２４、体＋１６";
        this._strength = 24;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 16;
        this._mind = 0;
        break;

      case Fix.BRONZE_RING_NAGURI:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。殴の刻印がしてある。力＋２４、心＋１６";
        this._strength = 24;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 16;
        break;

      case Fix.BRONZE_RING_TOBI:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。飛の刻印がしてある。技＋２４、知＋１６";
        this._strength = 0;
        this._agility = 24;
        this._intelligence = 16;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BRONZE_RING_KARAMU:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。絡の刻印がしてある。技＋１６、体＋２４";
        this._strength = 0;
        this._agility = 16;
        this._intelligence = 0;
        this._stamina = 24;
        this._mind = 0;
        break;

      case Fix.BRONZE_RING_HANERU:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。跳の刻印がしてある。技＋２４、心＋１６";
        this._strength = 0;
        this._agility = 24;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 16;
        break;

      case Fix.BRONZE_RING_TORU:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。補の刻印がしてある。知＋１６、体＋２４";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 16;
        this._stamina = 24;
        this._mind = 0;
        break;

      case Fix.BRONZE_RING_MIRU:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。視の刻印がしてある。知＋２４、心＋１６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 24;
        this._stamina = 0;
        this._mind = 16;
        break;

      case Fix.BRONZE_RING_KATAI:
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
        this._gold = 10000;
        this._importantType = Important.None;
        this._description = "青銅素材で作られた腕輪。堅の刻印がしてある。体＋２４、心＋１６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 24;
        this._mind = 16;
        break;

      case Fix.RED_KOKUIN:
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
        this._gold = 15000;
        this._importantType = Important.None;
        this._description = "赤を宿らせている刻印、それは【力】を示す。力＋５０";
        this._strength = 50;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BLUE_KOKUIN:
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
        this._gold = 15000;
        this._importantType = Important.None;
        this._description = "青を宿らせている刻印、それは【技】を示す。技＋５０";
        this._strength = 0;
        this._agility = 50;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PURPLE_KOKUIN:
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
        this._gold = 15000;
        this._importantType = Important.None;
        this._description = "紫を宿らせている刻印、それは【知】を示す。知＋５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 50;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.GREEN_KOKUIN:
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
        this._gold = 15000;
        this._importantType = Important.None;
        this._description = "緑を宿らせている刻印、それは【体】を示す。体＋５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 50;
        this._mind = 0;
        break;

      case Fix.YELLOW_KOKUIN:
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
        this._gold = 15000;
        this._importantType = Important.None;
        this._description = "黄を宿らせている刻印、それは【心】を示す。心＋５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 40;
        this._stamina = 20;
        this._mind = 15;
        this.AmplifyLight = 1.05f; // 要検証
        this.ResistSleep = true;
        break;

      case Fix.SUNLEAF_SEAL:
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
        this._gold = 16000;
        this._importantType = Important.None;
        this._description = "太陽をシンボルとして光を放ち続ける葉。葉に込められた魔力は聖なる輝きを周囲へ放つ。知＋４０、体＋２０、心＋１５、睡眠耐性、聖増幅＋５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 50;
        break;

      case Fix.SPIRIT_TUNOBUE:
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
        this._gold = 16000;
        this._importantType = Important.None;
        this._description = "森に住む精霊達が稀に落としていく角笛。その笛から発せられる音波は常人には聞こえないが、稀に聞き取れる者がおり、その者には躍動感がみなぎると言われている。技＋４０、知＋２０、心＋１５、束縛耐性、闇増幅＋５％";
        this._strength = 0;
        this._agility = 40;
        this._intelligence = 20;
        this._stamina = 0;
        this._mind = 15;
        this.AmplifyShadow = 1.05f; // 要検証
        this.ResistBind = true;
        break;

      case Fix.DEPLETH_SEED_PIERCE:
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
        this._gold = 16000;
        this._importantType = Important.None;
        this._description = "種として枯渇しきった素材を元に作製された黒いピアス。失われた魔力の代償として、それと同等の力を手にする。力＋４０、技＋２０、心＋１５、恐怖耐性、炎増幅＋５％";
        this._strength = 40;
        this._agility = 20;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 15;
        this.AmplifyFire = 1.05f; // 要検証
        this.ResistFear = true;
        break;

      case Fix.SPARKLINE_EMBLEM:
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
        this._gold = 16000;
        this._importantType = Important.None;
        this._description = "一点から周囲全体へと電撃がほとばしる紋章。瞬間的な強さを誇る者はこの原理を基点としている。技＋４０、心＋２５、凍結耐性、氷増幅＋５％";
        this._strength = 0;
        this._agility = 40;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 25;
        this.AmplifyIce = 1.05f; // 要検証
        this.ResistFreeze = true;
        break;

      case Fix.CHAINSHIFT_BOOTS:
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
        this._gold = 16000;
        this._importantType = Important.None;
        this._description = "身動きの取りやすい攻撃フォームから防衛姿勢に転じる時、このブーツが半自動的にその効果を発揮してくれる。力＋２５、体＋４０、スタン耐性、麻痺耐性";
        this._strength = 25;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 40;
        this._mind = 0;
        this.ResistStun = true;
        this.ResistParalyze = true;
        break;

      case Fix.ASHED_COMPASS:
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
        this._gold = 17000;
        this._importantType = Important.None;
        this._description = "コンパスとしての指し示す機能は既に失われている。ただし、所持者の想い次第で導きを再び指し示してくれる。力＋１０、技＋１０、知＋１０、体＋１０、心＋３０、炎耐性５％、氷耐性５％、聖耐性５％、闇耐性５％";
        this._strength = 10;
        this._agility = 10;
        this._intelligence = 10;
        this._stamina = 10;
        this._mind = 30;
        this.ResistFirePercent = 0.05f;
        this.ResistIcePercent = 0.05f;
        this.ResistLightPercent = 0.05f;
        this.ResistShadowPercent = 0.05f;
        break;

      case Fix.SQUARE_SINNEN:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Jewel;
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
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "正方形の形状をした宝石。煌びやかではないが宝石の中央に「信念」の文字が刻まれ、もの静かに発光している。ジュエルソケットに装着する事で効果を得られる。心＋２０、物攻率１０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        this.AmplifyPhysicalAttack = 1.10f; // 要検証
        break;

      case Fix.SQUARE_BLESTAR:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Jewel;
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
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "正方形の形状をした宝石。煌びやかではないが宝石の中央に「熟慮」の文字が刻まれ、もの静かに発光している。ジュエルソケットに装着する事で効果を得られる。心＋２０、物防率１０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        this.AmplifyPhysicalDefense = 1.10f; // 要検証
        break;

      case Fix.SQUARE_CHISEI:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Jewel;
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
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "正方形の形状をした宝石。煌びやかではないが宝石の中央に「知性」の文字が刻まれ、もの静かに発光している。ジュエルソケットに装着する事で効果を得られる。心＋２０、魔攻率１０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        this.AmplifyMagicAttack = 1.10f; // 要検証
        break;

      case Fix.SQUARE_SENREN:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Jewel;
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
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "正方形の形状をした宝石。煌びやかではないが宝石の中央に「洗練」の文字が刻まれ、もの静かに発光している。ジュエルソケットに装着する事で効果を得られる。心＋２０、魔防率１０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        this.AmplifyMagicDefense = 1.10f; // 要検証
        break;

      case Fix.SQUARE_SAIKI:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Jewel;
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
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "正方形の形状をした宝石。煌びやかではないが宝石の中央に「才気」の文字が刻まれ、もの静かに発光している。ジュエルソケットに装着する事で効果を得られる。心＋２０、戦速率１０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        this.AmplifyBattleSpeed = 1.10f; // 要検証
        break;

      case Fix.SQUARE_TANREN:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Jewel;
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
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "正方形の形状をした宝石。煌びやかではないが宝石の中央に「鍛錬」の文字が刻まれ、もの静かに発光している。ジュエルソケットに装着する事で効果を得られる。心＋２０、戦応率１０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        this.AmplifyBattleResponse = 1.10f; // 要検証
        break;

      case Fix.SQUARE_KOKOH:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Jewel;
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
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "正方形の形状をした宝石。煌びやかではないが宝石の中央に「孤高」の文字が刻まれ、もの静かに発光している。ジュエルソケットに装着する事で効果を得られる。心＋２０、潜力率１０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        this.AmplifyPotential = 1.10f; // 要検証
        break;

      case Fix.ENSEMBLE_FEATHER_HUT:
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
        this._gold = 25000;
        this._importantType = Important.None;
        this._description = "スペルの詠唱が組み合わさる時、普段の威力とは異なった相乗効果が発揮される。この羽根つきの帽子はその心が宿っており、魔法詠唱する者にとって優雅な旋律を提供してくれる。技＋３２、知＋５６、沈黙耐性、猛毒耐性、闇耐性１５％、炎増幅１５％、魔攻率５％";
        this._strength = 0;
        this._agility = 32;
        this._intelligence = 56;
        this._stamina = 0;
        this._mind = 0;
        this.ResistSilence = true;
        this.ResistPoison = true;
        this.ResistShadowPercent = 0.15f;
        this.AmplifyFire = 1.15f; // todo 要検証
        this.AmplifyMagicAttack = 1.05f; // todo 要検証
        break;

      case Fix.MIRAGE_PLASMA_EARRING:
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
        this._gold = 26000;
        this._importantType = Important.None;
        this._description = "常に放電し続けるが、可視化されていないイアリング。存在自体はしてお発光された箇所から次々と活力が湧いてくる。技＋４６、体＋３０、心＋１２、束縛耐性、恐怖耐性、氷耐性１５％、聖増幅１５％、戦速率５％";
        this._strength = 0;
        this._agility = 46;
        this._intelligence = 0;
        this._stamina = 30;
        this._mind = 12;
        this.ResistBind = true;
        this.ResistFear = true;
        this.ResistIcePercent = 0.15f;
        this.AmplifyLight = 1.15f; // todo 要検証
        this.AmplifyBattleSpeed = 1.05f; // todo 要検証
        break;

      case Fix.PHOTON_ZEAL_CROWN:
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
        this._gold = 27000;
        this._importantType = Important.None;
        this._description = "粒子が幾つもの型を形成し、たまたま王冠の輪郭として形状化した物。非常に神々しいオーラを放っているが装着した者にはそれなりの精神力が要求される。選ばれた者であれば多大な恩恵を得られる。力＋２０、技＋２０、知＋２０、体＋２０、心＋２０、炎耐性１５％、氷耐性１５％、光耐性１５％、闇耐性１５％";
        this._strength = 20;
        this._agility = 20;
        this._intelligence = 20;
        this._stamina = 20;
        this._mind = 20;
        this.ResistFirePercent = 0.15f;
        this.ResistIcePercent = 0.15f;
        this.ResistLightPercent = 0.15f;
        this.ResistShadowPercent = 0.15f;
        break;

      case Fix.DEMONS_STAR_BRACELET:
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
        this._gold = 28000;
        this._importantType = Important.None;
        this._description = "悪魔の刻印が施された星型（逆）のブレスレット。装着する時、対象者の心が試されるが恐れと嘆きを振り払う事で確約された力を手にする事が出来る。力＋５０、体＋３０、心＋１０、炎増幅１５％、闇増幅１５％、魔防率５％";
        this._strength = 50;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 30;
        this._mind = 10;
        this.AmplifyFire = 1.15f; // todo 要検証
        this.AmplifyShadow = 1.15f; // todo 要検証
        this.AmplifyMagicDefense = 1.05f; // todo 要検証
        break;

      case Fix.MIST_WAVE_GAUNTLET:
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
        this._gold = 29000;
        this._importantType = Important.None;
        this._description = "美しい霧を常に纏うガントレット。表面はさざ波の形状をしており、装着者に勇敢な心と流水の精神が刻み込まれる。知＋４６、体＋３０、心＋１０、氷増幅１５％、聖耐性１５％、戦応率５％";
        this._strength = 0;
        this._agility = 46;
        this._intelligence = 0;
        this._stamina = 30;
        this._mind = 10;
        this.AmplifyIce = 1.15f; // todo 要検証
        this.ResistLightPercent = 0.15f;
        this.AmplifyBattleResponse = 1.05f; // todo 要検証
        break;

      case Fix.MEIUN_PRISM_BOX:
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
        this._gold = 30000;
        this._importantType = Important.None;
        this._description = "己の命運を掛けて開かれる箱。開くたびに様々な効果が発揮される。力＋３０、技＋３０、知＋３０、【特殊効果】ターン経過毎に、ライフ／マナ／スキルポイントのいずれかが５%回復する。";
        this._strength = 30;
        this._agility = 30;
        this._intelligence = 30;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SPIRIT_CHALICE_OF_HEART:
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
        this._gold = 31000;
        this._importantType = Important.None;
        this._description = "この聖杯の中には眼には見えないが人の心が埋め込まれていると謳われる。装着者には得たいの知れない源泉のパワーが溢れてくる。心＋３０、物攻率５％、魔攻率５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 70;
        this.AmplifyPhysicalAttack = 1.05f; // todo 要検証
        this.AmplifyMagicAttack = 1.05f; // todo 要検証
        break;
      #endregion
      #region "オーランの塔"
      case Fix.SUPERIOR_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 100;
        this._physicalAttackMax = 125;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 30000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された剣。更なる強さを求める一部の者がこれを使用する。物理攻撃力１００～１２５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.FULLMETAL_ASTRAL_BLADE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 180;
        this._physicalAttackMax = 230;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 55000;
        this._importantType = Important.None;
        this._description = "完全な鋼鉄製のブレード。神々の姿をモチーフにした紋章が刻まれており、剣を振るった時に剣の重さを感じる事が無く、非常に強力な威力を発揮する。物理攻撃力１８０～２３０、力＋３２、心＋２０【特殊効果】物理攻撃が対象にヒットする度に、１０％の確率でインスタントゲージが１０％進行する。";
        this._strength = 32;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        break;

      case Fix.SUPERIOR_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 110;
        this._physicalAttackMax = 140;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された槍。更なる強さを求める一部の者がこれを使用する。物理攻撃力１１０～１４０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.STORM_FURY_LANCER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 200;
        this._physicalAttackMax = 270;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 58000;
        this._importantType = Important.None;
        this._description = "戦の神が与えたのは嵐の力。嵐の紋様が槍全体に刻み込まれており、槍を振るう度に、轟音の風が吹き荒れる。物理攻撃力２００～２７０、力＋３０、技＋４０【特殊効果】物理攻撃が対象にヒットする度に、自分自身の物理攻撃／戦闘速度／戦闘反応のいずれかが５％上昇する。";
        this._strength = 30;
        this._agility = 40;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SUPERIOR_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 120;
        this._physicalAttackMax = 160;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 34000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された斧。更なる強さを求める一部の者がこれを使用する。物理攻撃力１２０～１６０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.WARLOAD_BASTARD_AXE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 230;
        this._physicalAttackMax = 300;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 61000;
        this._importantType = Important.None;
        this._description = "闘うことが使命である戦士にとって、この斧は期待以上の効果を出してくれる。振るえば一網打尽、叩きつければ豪快な一撃が出るため、戦闘の最中においてボルテージが上昇する。物理攻撃力２３０～３００、力＋４５、体＋２０【特殊効果】物理攻撃が対象にヒットする度に、対象の物理防御／魔法防御／戦闘速度のいずれかが１０％減少する。";
        this._strength = 45;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 0;
        break;

      case Fix.SUPERIOR_CLAW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 95;
        this._physicalAttackMax = 105;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 28000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された爪。更なる強さを求める一部の者がこれを使用する。物理攻撃力９５～１０５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.EARTH_SHARD_CLAW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 160;
        this._physicalAttackMax = 180;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 52000;
        this._importantType = Important.None;
        this._description = "大地の恩恵から採取された鋼の欠片を爪の形状に仕立て上げた逸品。切れ味の鋭さというよりは、一撃の重みを重点として作製されている。破壊力は申し分なく、使い勝手はこの上なく良い。物理攻撃力１６０～１８０、技＋３２，心＋２０【特殊効果】物理攻撃が対象にヒットする度に、20%の確率で自分自身のスキルポイントが３％回復する。";
        this._strength = 0;
        this._agility = 32;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        break;

      case Fix.JUZA_ARESTINE_SLICER:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 340;
        this._physicalAttackMax = 450;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者ジュザは逸脱した戦闘能力を更に進化させ、スピード／威力／インパクトを全て兼ね備える技の極みを常に求めていた。その到達地点としての一つの解は「爪装備」であると彼は断言している。物理攻撃力３４０～４５０、力７５、技１２０、心５５、炎増幅２０％、氷増幅２０％、猛毒耐性、スタン耐性、凍結耐性、鈍化耐性、出血耐性";
        this._strength = 75;
        this._agility = 120;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 55;
        this._amplifyFire = 1.20f;
        this._amplifyIce = 1.20f;
        this._resistPoison = true;
        this._resistStun = true;
        this._resistFreeze = true;
        this._resistSlow = true;
        this._resistSlip = true;
        break;

      case Fix.SUPERIOR_ROD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 100;
        this._magicAttackMax = 125;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 30000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された杖。更なる強さを求める一部の者がこれを使用する。魔法攻撃力１００～１２５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.ENGAGED_FUTURE_ROD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 180;
        this._magicAttackMax = 230;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 55000;
        this._importantType = Important.None;
        this._description = "戦況を先読みする者にとって愛用され続けている杖。光輝く先端に視点を集中する事で、普段発揮できない魔法能力を引き出す事が出来る。魔法攻撃力１８０～２３０、知＋３２、心＋２０【特殊効果】ライフ回復を伴う魔法を使用した時、ライフ回復量が10%上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 32;
        this._stamina = 0;
        this._mind = 20;
        break;

      case Fix.SUPERIOR_BOOK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 110;
        this._magicAttackMax = 140;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 32000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された本。更なる強さを求める一部の者がこれを使用する。魔法攻撃力１１０～１４０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.ANCIENT_FAITHFUL_BOOK:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 200;
        this._magicAttackMax = 270;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 58000;
        this._importantType = Important.None;
        this._description = "古代から伝わる由緒ある伝承を収めた本。ページ毎には様々な効果が記述されており、詠唱するのとほぼ同時に該当ページが自然と開く仕組みになっている。魔法効果は絶大であり、他の追従を許さない。魔法攻撃力２００～２７０、知＋４０、体＋２０【特殊効果】ターン経過毎に、インスタントゲージが１０％進行する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 40;
        this._stamina = 20;
        this._mind = 0;
        break;

      case Fix.SUPERIOR_ORB:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 95;
        this._magicAttackMax = 105;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 28000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された水晶。更なる強さを求める一部の者がこれを使用する。魔法攻撃力９５～１０５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BLUE_SKY_ORB:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 160;
        this._magicAttackMax = 180;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 52000;
        this._importantType = Important.None;
        this._description = "澄みわたる大空をモチーフにした水晶。見た目の良さとは裏腹に魔力が蓄積される仕組みを有している。通常は安定した攻撃力だが、使い方によっては絶大な効果を発揮できる。魔法攻撃力１６０～１８０、技＋３０、知＋３０【特殊効果】魔法攻撃がヒットする度に、自分自身の魔法攻撃／魔法防御／戦闘反応のいずれかが５％上昇する。";
        this._strength = 0;
        this._agility = 30;
        this._intelligence = 30;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SUPERIOR_LARGE_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Sword;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 87;
        this._physicalAttack = 100;
        this._physicalAttackMax = 200;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された両手剣。更なる強さを求める一部の者がこれを使用する。物理攻撃力１００～２００";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PRISMATIC_SOUL_BREAKER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Sword;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 87;
        this._physicalAttack = 190;
        this._physicalAttackMax = 380;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 70000;
        this._importantType = Important.None;
        this._description = "カラフルな装飾が施された魔剣。魂を食らう様な形状をしており、一太刀振るう度に生命を吸収するかのような波動が相手に伝わる。物理攻撃力１９０～３８０、力＋３５、心＋２５、間属性上昇１０％";
        this._strength = 35;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 25;
        this.AmplifyShadow = 1.10f; // todo 要検証
        break;

      case Fix.SUPERIOR_LARGE_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Lance;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 85;
        this._physicalAttack = 110;
        this._physicalAttackMax = 240;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 43000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された両手槍。更なる強さを求める一部の者がこれを使用する。物理攻撃力１１０～２４０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BLOOD_STUBBORN_SPEAR:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Lance;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 85;
        this._physicalAttack = 260;
        this._physicalAttackMax = 400;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 75000;
        this._importantType = Important.None;
        this._description = "ゴツめの鋼鉄を素材の元としており、血のりで装飾された狂気の槍。柄の形状は禍々しくあるが、その破壊力は群を抜いている。通常の一撃でも対象者にとっては脅威となるだろう。物理攻撃力２６０～４００、力＋３５、技＋４５";
        this._strength = 35;
        this._agility = 45;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SUPERIOR_LARGE_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Axe;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 83;
        this._physicalAttack = 120;
        this._physicalAttackMax = 280;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 46000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された両手斧。更なる強さを求める一部の者がこれを使用する。物理攻撃力１２０～２８０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.ELEMENTAL_DISRUPT_AXE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Axe;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 83;
        this._physicalAttack = 300;
        this._physicalAttackMax = 450;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 80000;
        this._importantType = Important.None;
        this._description = "数多く魔法属性を兼ね備えた破壊の斧。この武具を振るった時、様々な色を成して振るわれるが、元々の装飾もカラフルであり、エレメンタルの総称が付けられたと言われている。見た目とは裏腹に威力は絶大である。物理攻撃力３００～４５０、力＋４５、体＋３５";
        this._strength = 45;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 35;
        this._mind = 0;
        break;

      case Fix.SUPERIOR_BOW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 180;
        this._physicalAttackMax = 220;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 50000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された弓。更なる強さを求める一部の者がこれを使用する。物理攻撃力１８０～２２０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.LINGERING_FROST_SHOOTER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 340;
        this._physicalAttackMax = 380;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 90000;
        this._importantType = Important.None;
        this._description = "非常に巨大な形状をしたロングボウ。弦の所々には微細な雪の結晶が常に発生しており、放った矢にはその結晶が付いた状態で放たれる。雪の結晶が矢の起動を追尾する様に見えるため、矢が放たれる度に美しい弧が描かれる。物理攻撃力３４０～３８０、力＋４０、知＋４０、氷攻撃力１０％、氷耐性１０％";
        this._strength = 40;
        this._agility = 0;
        this._intelligence = 40;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyIce = 1.10f; // todo 要検証
        this.ResistIcePercent = 0.10f;
        break;

      case Fix.SUPERIOR_LARGE_STAFF:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 170;
        this._magicAttackMax = 210;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 48000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された両手杖。更なる強さを求める一部の者がこれを使用する。魔法攻撃力１７０～２１０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.INFERNAL_IMMORTAL_STAFF:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 320;
        this._magicAttackMax = 360;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 85000;
        this._importantType = Important.None;
        this._description = "悪を滅するために業火の炎で鍛えられた大型の杖。形状は非常にごつごつしており、杖の先端は常に炎が宿っている。炎同士の対決を意識する者は、炎の激突に打ち克つためにこの杖を保持する。魔法攻撃力３２０～３６０、知＋３２、心＋２０、炎攻撃力１０％、炎耐性１０％";
        this._strength = 0;
        this._agility = 32;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 20;
        this.AmplifyFire = 1.10f; // todo 要検証
        this.ResistFirePercent = 0.10f;
        break;

      case Fix.GATUH_HAWL_OF_GREAT:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 270;
        this._physicalAttackMax = 430;
        this._magicAttack = 520;
        this._magicAttackMax = 680;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "とある伝承の中でのみ描かれる伝説の言霊使いガトゥは、生命体を媒介として直接声を届ける術を会得していたとされている。古代賢者の1人でもあり、世界の監視者でもあった彼は悠久の時の中で、この生命力あふれる巨大な樫の杖を常時装備していたと記されている。物理攻撃力２７０～４３０、魔法攻撃力５２０～６８０、知＋９５、体＋１０５、心＋５０、闇耐性２０％、聖増幅２０％、沈黙耐性、束縛耐性、睡眠耐性、麻痺耐性、眩暈耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 95;
        this._stamina = 105;
        this._mind = 50;
        this._resistShadowPercent = 0.20f;
        this._amplifyLight = 1.20f;
        this._resistSilence = true;
        this._resistBind = true;
        this._resistSleep = true;
        this._resistParalyze = true;
        this._resistDizzy = true;
        break;

      case Fix.SUPERIOR_SHIELD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 40;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 24000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された盾。更なる強さを求める一部の者がこれを使用する。物理防御力４０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.GRACEFUL_KINGS_BUCKLER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 76;
        this._magicDefense = 55;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 45000;
        this._importantType = Important.None;
        this._description = "奇麗で洗練された形状で仕上げられた王の盾。保持者には王としての意志が呼び起こされる。防御への立ち回り、攻撃への転化、場の構築などあらゆる局面でその盾は効果を発揮する。物理防御７６、魔法防御５５、体＋２５、闇耐性１０％　【特殊効果】防御姿勢時における軽減率が1０％上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 25;
        this._mind = 0;
        this.ResistShadowPercent = 0.10f;
        break;

      case Fix.SUPERIOR_ARMOR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 60;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 28000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された鎧。更なる強さを求める一部の者がこれを使用する。物理防御力６０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.HARDED_INTENSITY_PLATE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 115;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 55000;
        this._importantType = Important.None;
        this._description = "鋼鉄の中でも特に密度の高い素材で作られた鎧。分厚さと頑丈さを兼ね備えており、硬い防御力を誇る。装飾もごつごつした印象であり、対象者からはデカい壁の様に見えると言われている。物理防御力１１５、体＋３０、炎耐性１０％、聖耐性１０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 30;
        this._mind = 0;
        this.ResistFirePercent = 0.10f;
        this.ResistLightPercent = 0.10f;
        break;

      case Fix.SUPERIOR_CROSS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 40;
        this._magicDefense = 20;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 26000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練された舞踏衣。更なる強さを求める一部の者がこれを使用する。物理防御力４０、魔法防御力２０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SOLDIER_HATRED_CROSS:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 68;
        this._magicDefense = 42;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 50000;
        this._importantType = Important.None;
        this._description = "闘いに身を投じる強者達が好んで使用する舞踏衣。俊敏さと防御力を兼ね備えており、活力次第では重たい鎧でガッチリ防御するよりもこちらの方がダメージ軽減が図れるだろう。物理防御力６８、魔法防御力４２、体＋１６、心＋１０、氷耐性１０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 16;
        this._mind = 10;
        this.ResistIcePercent = 0.10f;
        break;

      case Fix.SUPERIOR_ROBE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 15;
        this._magicDefense = 45;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 31000;
        this._importantType = Important.None;
        this._description = "品質が高く、洗練されたローブ。更なる強さを求める一部の者がこれを使用する。物理防御力１５、魔法防御力４５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.WONDERERS_INVISIBLE_ROBE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 42;
        this._magicDefense = 68;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 60000;
        this._importantType = Important.None;
        this._description = "その見た目からは単なる旅人の様にしか見えないため、防御を捨てた様相に見える。しかしローブには目に見えない魔法反射素材が使用されており、通常の一般的な魔法攻撃ではほとんどがダメージ軽減されてしまう特性を持っている。物理防御力４２、魔法防御力６８、心＋２５、闇耐性１０％、睡眠耐性、猛毒耐性、沈黙耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 25;
        this.ResistShadowPercent = 0.10f;
        this.ResistSleep = true;
        this.ResistPoison = true;
        this.ResistSilence = true;
        break;

      case Fix.ZELMAN_THE_ONSLAUGHT_BASTER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Axe;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 0;
        this._physicalAttack = 350;
        this._physicalAttackMax = 550;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 83000;
        this._importantType = Important.None;
        this._description = "ゼールマンの里から伝承された両手斧。重量が非常にあり、一般的な鍛え方をしている人では両手でもまともに持ち上げられない。攻撃が当たれば破壊力は絶大である。物理攻撃力３５０～５５０、力＋５０、体＋４０";
        this._strength = 50;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 40;
        this._mind = 0;
        break;

      case Fix.LIFEGRACE_FORTUNE_STAFF:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 200;
        this._magicAttackMax = 250;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 56000;
        this._importantType = Important.None;
        this._description = "ツァルマンの里で毎年行われる奉納祭にて、よく利用される杖。杖全体から淡い緑色の光が放たれており、保持者にマナの源泉を感じ取らせてくれる。魔法攻撃力２００～２５０、知＋３５、心＋２２";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 35;
        this._stamina = 0;
        this._mind = 22;
        break;

      case Fix.WHITEVEIL_QUEENS_ROBE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 50;
        this._magicDefense = 90;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 62000;
        this._importantType = Important.None;
        this._description = "白のヴェールが特徴的なシルク製のローブ。ツァルマンの里で婚儀が行われる時によく用いられる。物理防御力５０、魔法防御力９０、知＋３０、闇耐性＋１０％、聖耐性＋１０、スタン耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 30;
        this._stamina = 0;
        this._mind = 0;
        this._resistShadowPercent = 0.10f;
        this._resistLightPercent = 0.10f;
        this._resistStun = true;
        this._resistFear = true;
        break;

      case Fix.KODAIEIJU_GREEN_LEAF:
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
        this._gold = 160000;
        this._importantType = Important.None;
        this._description = "古代栄樹の葉は決して枯れる事はなく、今でも装備品として重宝されている。希少価値としても高いのでお値段はわりと高めとなっている。技＋４０、知＋４０、体＋４０、心＋４０、猛毒耐性、出血耐性";
        this._strength = 0;
        this._agility = 40;
        this._intelligence = 40;
        this._stamina = 40;
        this._mind = 40;
        this._resistPoison = true;
        this._resistSlip = true;
        break;

      case Fix.STEEL_RING_POWER:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『パワー』の印字が刻まれている。力＋４５、技＋３０";
        this._strength = 45;
        this._agility = 30;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.STEEL_RING_SENSE:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『センス』の印字が刻まれている。力＋３０、知＋４５";
        this._strength = 30;
        this._agility = 0;
        this._intelligence = 45;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.STEEL_RING_TOUGH:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『タフ』の印字が刻まれている。力＋４５、体＋３０";
        this._strength = 45;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 30;
        this._mind = 0;
        break;

      case Fix.STEEL_RING_ROCK:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『ロック』の印字が刻まれている。力＋４５、心＋３０";
        this._strength = 45;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 30;
        break;

      case Fix.STEEL_RING_FAST:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『ファスト』の印字が刻まれている。技＋４５、知＋３０";
        this._strength = 0;
        this._agility = 45;
        this._intelligence = 30;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.STEEL_RING_SHARP:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『シャープ』の印字が刻まれている。技＋３０、体＋４５";
        this._strength = 0;
        this._agility = 30;
        this._intelligence = 0;
        this._stamina = 45;
        this._mind = 0;
        break;

      case Fix.STEEL_RING_HIGH:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『ハイ』の印字が刻まれている。技＋４５、心＋３０";
        this._strength = 0;
        this._agility = 45;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 30;
        break;

      case Fix.STEEL_RING_DEEP:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『ディープ』の印字が刻まれている。知＋４５、体＋３０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 45;
        this._stamina = 30;
        this._mind = 0;
        break;

      case Fix.STEEL_RING_BOUND:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『バウンド』の印字が刻まれている。知＋４５、心＋３０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 45;
        this._stamina = 0;
        this._mind = 30;
        break;

      case Fix.STEEL_RING_EMOTE:
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
        this._gold = 40000;
        this._importantType = Important.None;
        this._description = "鋼の素材で作られた腕輪。『エモート』の印字が刻まれている。体＋４５、心＋３０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 45;
        this._mind = 30;
        break;

      case Fix.RED_MASEKI:
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
        this._gold = 60000;
        this._importantType = Important.None;
        this._description = "凛と光る赤い魔石からは自然に湧き出るような【力】を感じる。力＋１０５";
        this._strength = 105;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BLUE_MASEKI:
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
        this._gold = 60000;
        this._importantType = Important.None;
        this._description = "凛と光る青い魔石からは自然に湧き出るような【技】を感じる。技＋１０５";
        this._strength = 0;
        this._agility = 105;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PURPLE_MASEKI:
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
        this._gold = 60000;
        this._importantType = Important.None;
        this._description = "凛と光る紫の魔石からは自然に湧き出るような【知】を感じる。知＋１０５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 105;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.GREEN_MASEKI:
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
        this._gold = 60000;
        this._importantType = Important.None;
        this._description = "凛と光る緑の魔石からは自然に湧き出るような【体】を感じる。体＋１０５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 105;
        this._mind = 0;
        break;

      case Fix.YELLOW_MASEKI:
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
        this._gold = 60000;
        this._importantType = Important.None;
        this._description = "凛と光る黄の魔石からは自然に湧き出るような【心】を感じる。心＋１０５";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 105;
        break;

      case Fix.POWER_STEEL_RING_SOLID:
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
        this._gold = 110000;
        this._importantType = Important.None;
        this._description = "強芯鋼素材の腕輪、【ソリッド】の印字が施されてれる。腕輪からは物質化に関する波動意志が微弱ながら放たれており、装着者に確かな力を与える。力＋７０、技＋５０、心＋４０、物防率１０％、スタン耐性";
        this._strength = 70;
        this._agility = 60;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 40;
        this.AmplifyPhysicalDefense = 1.10f;
        this.ResistStun = true;
        break;

      case Fix.POWER_STEEL_RING_VAPOUR:
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
        this._gold = 110000;
        this._importantType = Important.None;
        this._description = "強芯鋼素材の腕輪、【ヴェイパー】の印字が施されている。腕輪からは蒸気化に関する波動意志が微弱ながら放たれており、装着者に確かな力を与える。技＋７０、知＋５０、体＋４０、戦速率１０％、沈黙耐性";
        this._strength = 0;
        this._agility = 70;
        this._intelligence = 50;
        this._stamina = 40;
        this._mind = 0;
        this.AmplifyBattleSpeed = 1.10f;
        this.ResistSilence = true;
        break;

      case Fix.POWER_STEEL_RING_STRAIN:
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
        this._gold = 110000;
        this._importantType = Important.None;
        this._description = "強芯鋼素材の腕輪、【ストレイン】の印字が施されている。腕輪からは重圧化に関する波動意志が微弱ながら放たれており、装着者に確かな力を与える。知＋４０、体＋７０、心＋５０、魔防率１０％、凍結耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 40;
        this._stamina = 70;
        this._mind = 50;
        this.AmplifyMagicDefense = 1.10f;
        this.ResistFreeze = true;
        break;

      case Fix.POWER_STEEL_RING_TOLERANCE:
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
        this._gold = 110000;
        this._importantType = Important.None;
        this._description = "強芯鋼素材の腕輪、【トレランス】の印字が施されている。腕輪からは許容化に関する波動意志が微弱ながら放たれており、装着者に確かな力を与える。力＋５０、知＋７０、心＋４０、戦応率１０％、麻痺耐性";
        this._strength = 50;
        this._agility = 0;
        this._intelligence = 70;
        this._stamina = 0;
        this._mind = 40;
        this.AmplifyBattleResponse = 1.10f;
        this.ResistParalyze = true;
        break;

      case Fix.POWER_STEEL_RING_ASCEND:
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
        this._gold = 110000;
        this._importantType = Important.None;
        this._description = "強芯鋼素材の腕輪、【アセンド】の印字が施されている。腕輪からは上昇化に関する波動意志が微弱ながら放たれており、装着者に確かな力を与える。力＋５０、技＋４０、体＋７０、物攻率１０％、束縛耐性";
        this._strength = 50;
        this._agility = 40;
        this._intelligence = 0;
        this._stamina = 70;
        this._mind = 0;
        this.AmplifyPhysicalAttack = 1.10f;
        this.ResistBind = true;
        break;

      case Fix.POWER_STEEL_RING_INTERCEPT:
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
        this._gold = 110000;
        this._importantType = Important.None;
        this._description = "強芯鋼素材の腕輪、【インターセプト】の印字が施されている。腕輪からは遮断化に関する波動意志が微弱ながら放たれており、装着者に確かな力を与える。力＋5０、技＋7０、知＋4０、魔攻率１０％、鈍化耐性";
        this._strength = 50;
        this._agility = 70;
        this._intelligence = 40;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyMagicAttack = 1.10f;
        this.ResistSlow = true;
        break;

      case Fix.STARAIR_FLOATING_STONE:
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
        this._gold = 120000;
        this._importantType = Important.None;
        this._description = "星空の紋様が描かれている石。中には並外れた魔力が込められており、それ自体が浮遊する様にできている。これを手にしている者は石から強烈な魔力が身体に流れ込んでくるのを感じ取る事が出来る。技＋１３５、氷増幅２０％、睡眠耐性、スタン耐性";
        this._strength = 0;
        this._agility = 135;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyIce = 1.20f;
        this.ResistSleep = true;
        this.ResistStun = true;
        break;

      case Fix.LIGHTBRIGHT_FLOATING_STONE:
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
        this._gold = 120000;
        this._importantType = Important.None;
        this._description = "聖と光の刻印がクロスした形状で出来上がった石。多大な魔力が込められており、それ自体で自律的に宙に浮く。これを保持する者は永続的な恩恵と断続的な魔力が身体に流れ込んでくるのを感じ取る事が出来る。知＋１３５、聖増幅２０％、束縛耐性、スタン耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 135;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyLight = 1.20f;
        this.ResistBind = true;
        this.ResistStun = true;
        break;

      case Fix.LUMINOUS_REFLECT_MIRROR:
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
        this._gold = 120000;
        this._importantType = Important.None;
        this._description = "輝きを周辺に放ち続けるミラー。その特性は気体中の抵抗物質を溶かし、物質が接触した際、新たな光源として反射する特性を有する非常に稀な物質から構成されている。使い処は様々であり、愛用者は多い。体＋１３５【特殊効果】物理攻撃を受ける度に、３０％の確率で攻撃を行った対象者に物理ダメージ1/10の分だけ反射してダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 135;
        this._mind = 0;
        break;

      case Fix.BLACK_SPIRAL_NEEDLE:
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
        this._gold = 120000;
        this._importantType = Important.None;
        this._description = "禍々しい螺旋状の取っ手が付けられている漆黒の針。その針は自らの手のひらへ刺す事を糧として、圧倒的な力を授かる事が出来る。力＋１３５、恐怖耐性、闇増幅１０％、闇耐性１０％【特殊効果】ターン経過毎に、自分にかかっている負のBUFFが１つ解除される。この効果で１つ負のBUFFが除去される毎に、自分自身の物理攻撃力／物理防御力が１０％上昇する。";
        this._strength = 135;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyShadow = 1.10f;
        this.ResistShadowPercent = 0.10f;
        this.ResistFear = true;
        break;

      case Fix.EMBLEM_OF_VALKYRIE:
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
        this._gold = 130000;
        this._importantType = Important.None;
        this._description = "死を迎え入れるヴァルキリーの紋章。装備者にヴァルキリーの信念が宿る。力＋３８、技＋１１４、体＋２０、心＋３０、聖増幅１０％、聖耐性１０％、炎増幅１０％、炎耐性１０%、沈黙耐性、麻痺耐性、誘惑耐性";
        this._strength = 38;
        this._agility = 114;
        this._intelligence = 0;
        this._stamina = 20;
        this._mind = 30;
        this.AmplifyLight = 1.10f;
        this.AmplifyFire = 1.10f;
        this.ResistLightPercent = 0.10f;
        this.ResistFirePercent = 0.10f;
        this.ResistSilence = true;
        this.ResistParalyze = true;
        this.ResistTemptation = true;
        break;

      case Fix.EMBLEM_OF_NECROMANCY:
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
        this._gold = 130000;
        this._importantType = Important.None;
        this._description = "死を呼び寄せるネクロマンシーの紋章。装備者にネクロマンシーの信念が宿る。技＋２８、知＋１２２、体＋３０、心＋２０、闇増幅１０％、闇耐性１０％、氷増幅１０％、氷耐性１０％、凍結耐性、恐怖耐性、出血耐性";
        this._strength = 0;
        this._agility = 28;
        this._intelligence = 122;
        this._stamina = 30;
        this._mind = 20;
        this.AmplifyShadow = 1.10f;
        this.AmplifyIce = 1.10f;
        this.ResistShadowPercent = 0.10f;
        this.ResistIcePercent = 0.10f;
        this.ResistFreeze = true;
        this.ResistFear = true;
        this.ResistSlip = true;
        break;

      #endregion
      #region "ヴェルガス海底神殿"
      case Fix.MASTER_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 360;
        this._physicalAttackMax = 420;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 120000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた剣はマスターの称号が与えられる。物理攻撃力３６０～４２０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SOLEMN_EMPERORS_SWORD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 640;
        this._physicalAttackMax = 800;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 250000;
        this._importantType = Important.None;
        this._description = "厳粛なる皇帝が出陣する際、常用していた魔剣。静かな立ち振る舞いからは異様なオーラが放たれるため、対峙した者はその圧力に屈するだろう。物理攻撃力６４０～８４０【特殊効果】戦闘開始時、自分自身に【スタンス・オブ・ブレイド】のBUFFが付与される。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 400;
        this._physicalAttackMax = 480;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 140000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた槍はマスターの称号が与えられる。物理攻撃力４００～４８０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MYSTIC_BLUE_JAVELIN:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 700;
        this._physicalAttackMax = 900;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 270000;
        this._importantType = Important.None;
        this._description = "普通の槍とは異なり、柄の部分がかなり短めの設計で製作されている。柄の部分には蒼いドラゴンの装飾が施されており、また少しだけ婉曲している事から、対峙者に蒼き竜が食らいつく形で猛威を振るう。物理攻撃力７００～９００【特殊効果】戦闘開始時、【スピード・ステップ】のBUFFが付与される。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 440;
        this._physicalAttackMax = 540;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 160000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた斧はマスターの称号が与えられる。物理攻撃力４４０～５４０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.STRONG_FIRE_HELL_BASTARDAXE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 90;
        this._physicalAttack = 760;
        this._physicalAttackMax = 1020;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 330000;
        this._importantType = Important.None;
        this._description = "熱く、強靭であり、豪快な紋様が描かれれている斧。その振る舞いは常に炎が周囲を纏うかの様に行われる。斧自体が圧力を放っており、その斧を持った物が戦闘モーションに入るだけで周囲敵を威圧する。物理攻撃力７６０～１０２０【特殊効果】戦闘開始時、味方フィールドに【ドミネーション・フィールド】のBUFFが付与される。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_CLAW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 350;
        this._physicalAttackMax = 390;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 110000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた爪はマスターの称号が与えられる。物理攻撃力３５０～３９０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.AURA_BURN_CLAW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 620;
        this._physicalAttackMax = 720;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 230000;
        this._importantType = Important.None;
        this._description = "先端部分に聖なるオーラを纏う魔力が施されている爪。そのため、装着した者が戦闘態勢に入ったとき、拳全体が光を纏っている様に見える。見た目の派手さだけではなく、実際に攻撃が繰り出される威力は想像を凌ぐ。物理攻撃力６２０～７２０【特殊効果】戦闘開始時、味方フィールドに【レイライン・スキーマ】のBUFFが付与される。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_ROD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 360;
        this._magicAttackMax = 420;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 120000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた杖はマスターの称号が与えられる。魔法攻撃力３６０～４２０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MIND_STONEFEAR_ROD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 640;
        this._magicAttackMax = 800;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 250000;
        this._importantType = Important.None;
        this._description = "心に宿る恐怖心を無色の石に封じ、それが杖の先端にはめ込んである。杖を保持した者はある一定の恐怖心が伝搬してくるがそれに打ち克つ心を持てばその分魔法力に変換できる。魔法攻撃力６４０～８００【特殊効果】ターン経過毎に、自分にかかっている負のBUFFが１つ解除される。この効果で１つ負のBUFFが除去される毎に、自分自身の魔法攻撃力／魔法防御力が１０％上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_BOOK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 400;
        this._magicAttackMax = 480;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 140000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた本はマスターの称号が与えられる。魔法攻撃力４００～４８０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.DARKSUN_TRAGEDIC_BOOK:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 700;
        this._magicAttackMax = 900;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 270000;
        this._importantType = Important.None;
        this._description = "太陽が穢された刻、この世の終焉を謡う本。その本から発せられる詠唱は非常に独特であり、聴く全ての者が負の影響を受ける。魔法攻撃力７００～９００【特殊効果】魔法攻撃がヒットする度に、２０％の確率で沈黙／束縛／睡眠／鈍化／眩暈のいずれかのBUFFが付与される。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_ORB:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 350;
        this._magicAttackMax = 390;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 110000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた水晶はマスターの称号が与えられる。魔法攻撃力３５０～３９０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.CHROMATIC_FORGE_ORB:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 620;
        this._magicAttackMax = 720;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 230000;
        this._importantType = Important.None;
        this._description = "圧縮化されたガラス素材を更に色相変化させ、高純度の別の結晶へと変化を遂げた素材を用いた水晶。魔導士がこれを振る舞う時は、相当高い熱量を発生させて魔法を繰り出す。魔法攻撃力６２０～７２０【特殊効果】魔法攻撃がクリティカルでヒットした場合、クリティカルダメージ量が１０％上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_LARGE_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Sword;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 87;
        this._physicalAttack = 360;
        this._physicalAttackMax = 780;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 180000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた両手剣はマスターの称号が与えられる。物理攻撃力３６０～７８０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.GOLDWILL_DESCENT_SOWRD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Sword;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 87;
        this._physicalAttack = 680;
        this._physicalAttackMax = 1360;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 370000;
        this._importantType = Important.None;
        this._description = "振りかざすその大剣は、黄金の意志を持つ者が振るう事で圧倒的な破壊力を表現する。対象者への敬意を込めて振るわれる様は、王としての存在感をそこに出現させる。物理攻撃力７００～１３６０【特殊効果】物理攻撃がクリティカルでヒットした場合、クリティカルダメージ量が１０％上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_LARGE_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Lance;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 85;
        this._physicalAttack = 400;
        this._physicalAttackMax = 840;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 200000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた両手槍はマスターの称号が与えられる。物理攻撃力４００～８４０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.FLASH_VANISH_SPEAR:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Lance;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 85;
        this._physicalAttack = 760;
        this._physicalAttackMax = 1580;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 410000;
        this._importantType = Important.None;
        this._description = "烈火の如く放たれるその槍は、瞬間的な伸びがある。対象者からは一瞬で間合いを断ち切られ、懐に突如槍が出現しその直後槍が消失したかのように引き戻されるため、この名称が付けられたと言われている。物理攻撃力７６０～１５８０【特殊効果】自分から物理攻撃を伴う行動を行った場合、クリティカルの発生率が１０％上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_LARGE_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Axe;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 83;
        this._physicalAttack = 440;
        this._physicalAttackMax = 1020;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 220000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた両手斧はマスターの称号が与えられる。物理攻撃力４４０～１０２０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.VOLCANIC_BATTLE_BASTER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Axe;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 83;
        this._physicalAttack = 820;
        this._physicalAttackMax = 1880;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 450000;
        this._importantType = Important.None;
        this._description = "最高火力をぶっ放す剛なる斧。振り回せば周囲の敵はすべて一網打尽にする事が出来るだろう。後はその辺りに適当にブチ当てれば威力は確認する必要はない。存分に振り回し、ぞんぶんにぶちかますと良いだろう。物理攻撃力８２０～１８８０【特殊効果】物理攻撃がヒットする度に、２０％の確率でスタン／麻痺／恐怖／鈍化のいずれかのBUFFが付与される。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_BOW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 760;
        this._physicalAttackMax = 940;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 250000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた弓はマスターの称号が与えられる。物理攻撃力７６０～９４０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.WHITE_FIRE_CROSSBOW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 1160;
        this._physicalAttackMax = 1420;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 520000;
        this._importantType = Important.None;
        this._description = "純度の高い魔力を弓矢に同化させる事に成功した弓。実際には炎ではないのだが、魔力の揺らめきが矢に付与されているため、矢が飛んだ時に白い炎の軌跡が見える事からこの名称で親しまれている。矢には当然だが圧倒的な威力が込められている。物理攻撃力１１６０～１４２０【特殊効果】戦闘開始時、【フレイム・ブレイド】と【一心の眼】のBUFFが付与される。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_LARGE_STAFF:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 720;
        this._magicAttackMax = 900;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 240000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた両手杖はマスターの称号が与えられる。魔法攻撃力７２０～９００";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.ELDERSTAFF_OF_LIFEBLOOM:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 1080;
        this._magicAttackMax = 1340;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 510000;
        this._importantType = Important.None;
        this._description = "生命を司る大樹から選りすぐりの枝を切り取り、大杖の形状に仕立て上げた一品。際立った特徴はないが、手に持つだけで自然の生命力を感じる事が出来る。そこから放たれる魔力は計り知れない。魔法攻撃力１０８０～１３４０【特殊効果】戦闘開始時、味方フィールドに【エンジェリック・エコー】のBUFFが付与される。ライフ回復を伴う魔法を使用した時、ライフ回復量が２０%上昇する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.MASTER_SHIELD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 120;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 110000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた盾はマスターの称号が与えられる。物理防御力１２０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.DIMENSION_ZERO_SHIELD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 230;
        this._magicDefense = 78;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 230000;
        this._importantType = Important.None;
        this._description = "極限まで薄さを追求した盾。その薄さからは想定できない程の強靭な防御力を誇る。物理防御力２３０、魔法防御力７８、体＋５０、聖耐性１５％、闇耐性１５％、炎耐性１５％、氷耐性１５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 50;
        this._mind = 0;
        this.ResistFirePercent = 0.15f;
        this.ResistIcePercent = 0.15f;
        this.ResistLightPercent = 0.15f;
        this.ResistShadowPercent = 0.15f;
        break;

      case Fix.MASTER_ARMOR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 180;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 180000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた鎧はマスターの称号が与えられる。物理防御力１８０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.HIGHWARRIOR_DRAGONMAIL:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 340;
        this._magicDefense = 100;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 370000;
        this._importantType = Important.None;
        this._description = "希少価値の高いドラゴンの鱗を素材にして製作された鎧。頑丈さはもちろんだが、魔法耐性の効果もあるため、前衛で闘う戦士にとっては無くてはならない装備品である。物理防御力３４０、魔法防御力１００、体＋９０、氷耐性２５％、光耐性２５％【特殊効果】魔法ダメージを受ける時、３０％の確率で受けるダメージ量を半分にする。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 90;
        this._mind = 0;
        this.ResistIcePercent = 0.25f;
        this.ResistLightPercent = 0.25f;
        break;

      case Fix.MASTER_CROSS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 114;
        this._magicDefense = 66;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 160000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられた舞踏衣はマスターの称号が与えられる。物理防御力１１４、魔法防御力６６";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SWIFTCROSS_OF_REDTHUNDER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 280;
        this._magicDefense = 150;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 340000;
        this._importantType = Important.None;
        this._description = "深紅の雷をデザインとして施された舞踏衣。非常に動きやすく、熟練者であれば技を繰り出す速度は神域に達する事が出来るだろう。防御力も物理・魔法ともに非常に高く、前衛・後衛いずれでも活躍する事が出来る。物理防御力２８０、魔法防御力１５０、体＋７０、心＋２０、炎耐性２５％、闇耐性２５％【特殊効果】物理攻撃／魔法攻撃のいずれかを受ける度に、３０％の確率で攻撃を行った対象者に物理／魔法ダメージ1/2の分だけ反射してダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 70;
        this._mind = 20;
        this.ResistFirePercent = 0.25f;
        this.ResistShadowPercent = 0.25f;
        break;

      case Fix.MASTER_ROBE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 15;
        this._magicDefense = 45;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 210000;
        this._importantType = Important.None;
        this._description = "高品質の素材と熟練の技で鍛えられたローブはマスターの称号が与えられる。物理防御力４２、魔法防御力１３８";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BLADESHADOW_CROWDED_DRESS:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 80;
        this._magicDefense = 380;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 450000;
        this._importantType = Important.None;
        this._description = "一見すると颯爽とした普通のドレスに見えるが、キメ細かい装飾が施されておりその様は白い光を纏う中に一筋の黒い闇の紋様が埋め込まれているのが理解できる。物理防御力８０、魔法防御力３８０、心＋５０、光耐性２５％、闇耐性２５％【特殊効果】物理ダメージを受ける時、３０％の確率で受けるダメージ量を半分にし、加えて、攻撃を行った対象者に受けたダメージ量の分だけ反射して無属性の魔法ダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 50;
        this.ResistLightPercent = 0.25f;
        this.ResistShadowPercent = 0.25f;
        break;

      case Fix.SHEZL_MYSTIC_FORTUNE:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 300;
        this._magicDefense = 650;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者シェズルが幼少時代に付けていた神秘的な奇麗さを放つ衣。シェズルは魔法に関しては一線を画しており、その能力／才覚／カリスマ性には誰もが惹かれたと言われている。物理防御３００、魔法防御６５０、知＋３００、心＋１００、魔攻率１０％、魔防率１０％、闇増幅３０％、氷耐性３０％、沈黙耐性、スタン耐性、麻痺耐性、凍結耐性、恐怖耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 300;
        this._stamina = 0;
        this._mind = 100;
        this._amplifyMagicAttack = 1.10f;
        this._amplifyMagicDefense = 1.10f;
        this._amplifyShadow = 1.30f;
        this._resistIcePercent = 1.30f;
        this._resistSilence = true;
        this._resistStun = true;
        this._resistParalyze = true;
        this._resistFreeze = true;
        this._resistFear = true;
        break;

      case Fix.BLACKROGUE_BLACKROGUE_AMBIDEXTARITY_DAGGER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 0;
        this._physicalAttack = 1050;
        this._physicalAttackMax = 1240;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 850000;
        this._importantType = Important.None;
        this._description = "両利き用に製作された黒纏いのダガー。恐ろしいほどの切れ味と軽量さから、暗躍するローグ達は必ずと言って良いほど、これを駆使する。物理攻撃力 １０５０～１２４０、技＋５０、知＋５０";
        this._strength = 0;
        this._agility = 20;
        this._intelligence = 20;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.HOLY_BLESSING_SHIELD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 400;
        this._magicDefense = 360;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 700000;
        this._importantType = Important.None;
        this._description = "パルメティシア神殿の祈りが込められている聖なる盾。神々しさを常に放っており、所持者には聖なる加護が付与される。物理防御力４００、魔法防御力３６０、体＋１００、聖耐性３０％、闇耐性３０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 100;
        this._mind = 0;
        this.ResistLightPercent = 0.30f;
        this.ResistShadowPercent = 0.30f;
        break;

      case Fix.LATA_GUARDIAN_RING:
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
        this._gold = 1000000;
        this._importantType = Important.None;
        this._description = "雪原の大樹【ラタ】の紋様が施されたリング。装備した者に不思議な青白の発行が与えられ、加護が約束される。体＋４００、心＋２００、猛毒耐性、スタン耐性、出血耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 400;
        this._mind = 200;
        this._resistPoison = true;
        this._resistStun = true;
        this._resistSlip = true;
        break;

      case Fix.BLUEEYE_TEMPLE_PENDANT:
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
        this._gold = 1100000;
        this._importantType = Important.None;
        this._description = "【青眼】の紋様が記されている神殿騎士のペンダント。【青眼】の紋様からは蒼のイメージが流れ込んでくる。技＋１５０、知＋５５０、凍結耐性、沈黙耐性、氷耐性３０％、氷増幅２０％";
        this._strength = 0;
        this._agility = 150;
        this._intelligence = 550;
        this._stamina = 0;
        this._mind = 0;
        this._resistFreeze = true;
        this._resistSilence = true;
        this._resistIcePercent = 0.30f;
        this._amplifyIce = 1.20f;
        break;

      case Fix.REDEYE_TEMPLE_PENDANT:
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
        this._gold = 1100000;
        this._importantType = Important.None;
        this._description = "【赤眼】の紋様が記されている神殿騎士のペンダント。【赤眼】の紋様からは朱のイメージが流れ込んでくる。力＋５５０、技＋１５０、束縛耐性、麻痺耐性、炎耐性３０％、炎増幅２０％";
        this._strength = 550;
        this._agility = 150;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this._resistBind = true;
        this._resistParalyze = true;
        this._resistFirePercent = 0.30f;
        this._amplifyFire = 1.20f;
        break;

      case Fix.SILVER_RING_GOUKA:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『業火』のオーラが漂っている。力＋１５０、技＋１２０";
        this._strength = 150;
        this._agility = 120;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SILVER_RING_TSUNAMI:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『津波』のオーラが漂っている。力＋１２０、知＋１５０";
        this._strength = 120;
        this._agility = 0;
        this._intelligence = 150;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SILVER_RING_AKISAME:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『秋雨』のオーラが漂っている。力＋１５０、体＋１２０";
        this._strength = 150;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 120;
        this._mind = 0;
        break;

      case Fix.SILVER_RING_NEPPA:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『熱波』のオーラが漂っている。力＋１５０、心＋１２０";
        this._strength = 150;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 120;
        break;

      case Fix.SILVER_RING_RAIMEI:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『雷鳴』のオーラが漂っている。技＋１５０、知＋１２０";
        this._strength = 0;
        this._agility = 150;
        this._intelligence = 120;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SILVER_RING_FUBUKI:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『吹雪』のオーラが漂っている。技＋１２０、体＋１５０";
        this._strength = 0;
        this._agility = 120;
        this._intelligence = 150;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SILVER_RING_GENJITSU:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『幻日』のオーラが漂っている。技＋１５０、心＋１２０";
        this._strength = 0;
        this._agility = 150;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 120;
        break;

      case Fix.SILVER_RING_TATSUMAKI:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『竜巻』のオーラが漂っている。知＋１２０、体＋１５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 120;
        this._stamina = 150;
        this._mind = 0;
        break;

      case Fix.SILVER_RING_SYUNIJI:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『主虹』のオーラが漂っている。知＋１５０、心＋１２０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 150;
        this._stamina = 0;
        this._mind = 120;
        break;

      case Fix.SILVER_RING_KAGEROU:
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
        this._gold = 150000;
        this._importantType = Important.None;
        this._description = "銀の素材で作られた腕輪。『陽炎』のオーラが漂っている。体＋１５０、心＋１２０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 150;
        this._mind = 120;
        break;

      case Fix.REDLIGHT_BRIGHTSTONE:
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
        this._gold = 200000;
        this._importantType = Important.None;
        this._description = "淡く照らす赤の輝石が身体の周りで浮遊する。力＋３６０";
        this._strength = 360;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BLUELIGHT_BRIGHTSTONE:
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
        this._gold = 200000;
        this._importantType = Important.None;
        this._description = "淡く照らす青の輝石が身体の周りで浮遊する。技＋３６０";
        this._strength = 0;
        this._agility = 360;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PURPLELIGHT_BRIGHTSTONE:
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
        this._gold = 200000;
        this._importantType = Important.None;
        this._description = "淡く照らす紫の輝石が身体の周りで浮遊する。知＋３６０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 360;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.GREENLIGHT_BRIGHTSTONE:
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
        this._gold = 200000;
        this._importantType = Important.None;
        this._description = "淡く照らす緑の輝石が身体の周りで浮遊する。体＋３６０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 360;
        this._mind = 0;
        break;

      case Fix.YELLOWLIGHT_BRIGHTSTONE:
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
        this._gold = 200000;
        this._importantType = Important.None;
        this._description = "淡く照らす黄の輝石が身体の周りで浮遊する。心＋３６０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 360;
        break;

      case Fix.SEAL_OF_REDEYE:
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
        this._gold = 360000;
        this._importantType = Important.None;
        this._description = "深紅の目玉を封じている御札。目玉には強力過ぎる炎が宿っているがそれを制御するために御札で威力を封じられている。保持者には業火のイメージがみなぎってくる。知＋３２０、体＋１８０、炎増幅３０％、炎耐性３０％、恐怖耐性、スタン耐性、麻痺耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 320;
        this._stamina = 180;
        this._mind = 0;
        this.AmplifyFire = 1.30f;
        this.ResistFirePercent = 0.30f;
        this.ResistFear = true;
        this.ResistStun = true;
        this.ResistParalyze = true;
        break;

      case Fix.SEAL_OF_BLUEEYE:
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
        this._gold = 360000;
        this._importantType = Important.None;
        this._description = "深蒼の目玉を封じている御札。目玉には強力過ぎる氷が宿っているがそれを制御するために御札で威力を封じられている。保持者には凍氷のイメージがみなぎってくる。知＋３２０、体＋１８０、氷増幅３０％、氷耐性３０％、凍結耐性、スタン耐性、麻痺耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 320;
        this._stamina = 180;
        this._mind = 0;
        this.AmplifyIce = 1.30f;
        this.ResistIcePercent = 0.30f;
        this.ResistFreeze = true;
        this.ResistStun = true;
        this.ResistParalyze = true;
        break;

      case Fix.WINGED_LIGHTNING_BOOTS:
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
        this._gold = 380000;
        this._importantType = Important.None;
        this._description = "電撃の羽が付与されているブーツ。その印は俊足を象徴しており、装着したものは瞬間力のある切り返し行動をものともせず実行できるようになる。技＋３００、知＋２００、炎増幅３０％、氷耐性３０％、麻痺耐性、スタン耐性、束縛耐性、戦応率１５％";
        this._strength = 0;
        this._agility = 300;
        this._intelligence = 200;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyFire = 1.30f;
        this.ResistIcePercent = 0.30f;
        this.ResistBind = true;
        this.ResistParalyze = true;
        this.ResistStun = true;
        this.AmplifyBattleResponse = 1.15f;
        break;

      case Fix.SPELLCASTERS_LENS:
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
        this._gold = 380000;
        this._importantType = Important.None;
        this._description = "無色透明で特徴が一切ないレンズ。知識を追求する者にとって派手な装飾やエッセンスは不要である。精神を集中するためだけに特化した装備品としてこのレンズが常用されている。レンズ装着者には非常に強烈な魔力が流れ込むが、その変化は外見からは全く分からない。知＋３５０、心＋１５０、氷増幅３０％、闇増幅３０％、沈黙耐性、猛毒耐性、誘惑耐性、魔攻率１５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 350;
        this._stamina = 0;
        this._mind = 150;
        this.AmplifyIce = 1.30f;
        this.AmplifyShadow = 1.30f;
        this.ResistPoison = true;
        this.ResistSilence = true;
        this.ResistTemptation = true;
        this.AmplifyMagicAttack = 1.15f;
        break;

      case Fix.PEACEFUL_REBIRTH_CANDLE:
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
        this._gold = 380000;
        this._importantType = Important.None;
        this._description = "安らぎと再生の印字が刻まれたキャンドル。素材はロウでは出来ておらず耐久性に優れた素材が用いられている。炎の灯は装着者に永続的な生命力を与えてくれる。体＋３５０、心＋１５０、聖増幅３０％、闇耐性３０％、鈍化耐性、恐怖耐性、眩暈耐性、魔防率１５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 350;
        this._mind = 150;
        this.AmplifyLight = 1.30f;
        this.ResistShadowPercent = 0.30f;
        this.ResistSlow = true;
        this.ResistFear = true;
        this.ResistDizzy = true;
        this.AmplifyMagicDefense = 1.15f;
        break;

      case Fix.DESPAIR_BLACKANGEL_RING:
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
        this._gold = 380000;
        this._importantType = Important.None;
        this._description = "絶対的な死を司る漆黒の天使を描いた指輪。姿を見た者は恐怖と絶望に打ちひしがれると言われている。暗黒の魔力が込められており、装着した者は相応の心を持ってして制御しなければならない。力＋３５０、知＋１５０、闇増幅３０％、炎耐性３０％、猛毒耐性、凍結耐性、出血耐性、物攻率１５％";
        this._strength = 350;
        this._agility = 0;
        this._intelligence = 150;
        this._stamina = 0;
        this._mind = 0;
        this.AmplifyShadow = 1.30f;
        this.ResistFirePercent = 0.30f;
        this.ResistPoison = true;
        this.ResistFreeze = true;
        this.ResistSlip = true;
        this.AmplifyPhysicalAttack = 1.15f;
        break;

      case Fix.PHANTASMAL_INSIGHT_RUNE:
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
        this._gold = 380000;
        this._importantType = Important.None;
        this._description = "内なる力を秘めたルーン。意志決定とは正反対の特徴を有しており、潜在的な波動を発する時にファンタズマル・インサイト・ルーンはそれに呼応する。そのポテンシャルを測る事は難しい。体＋１００、心＋４００、炎増幅３０％、氷耐性３０％、睡眠耐性、スタン耐性、麻痺耐性、潜力率１５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 100;
        this._mind = 400;
        this.AmplifyFire = 1.30f;
        this.ResistIcePercent = 0.30f;
        this.ResistSleep = true;
        this.ResistStun = true;
        this.ResistParalyze = true;
        this.AmplifyPotential = 1.15f;
        break;

      case Fix.SILVER_ETERNAL_SEED:
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
        this._gold = 380000;
        this._importantType = Important.None;
        this._description = "永遠に輝く銀色の種。具体的な効果を望んで保持する者ではないが、手にしたものには神々からの恩恵が授与されると言われているがどのような恩恵なのかは判明していない。力＋１００、技＋１００、知＋１００、心＋２００、聖増幅２０％、闇増幅２０％、炎耐性２０％、氷耐性２０％、束縛耐性、恐怖耐性、出血耐性、物防率１５％";
        this._strength = 100;
        this._agility = 100;
        this._intelligence = 100;
        this._stamina = 0;
        this._mind = 200;
        this.AmplifyLight = 1.20f;
        this.AmplifyShadow = 1.20f;
        this.ResistFirePercent = 0.20f;
        this.ResistIcePercent = 0.20f;
        this.ResistBind = true;
        this.ResistFear = true;
        this.ResistSlip = true;
        this.AmplifyPhysicalDefense = 1.15f;
        break;

      case Fix.FIRELIEGE_AETHER_TALISMAN:
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
        this._gold = 380000;
        this._importantType = Important.None;
        this._description = "煉獄を制御する炎授天使が炎柱を一つの護符に収められている。この護符の中では渦巻く業火の炎が激しく燃え盛り続けている。力１００、技３００、心＋１００、炎耐性３０％、闇耐性３０％、沈黙耐性、束縛耐性、スタン耐性、戦速率１５％";
        this._strength = 100;
        this._agility = 300;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 100;
        this.ResistFirePercent = 0.30f;
        this.ResistShadowPercent = 0.30f;
        this.ResistSilence = true;
        this.ResistBind = true;
        this.ResistStun = true;
        this.AmplifyBattleSpeed = 1.15f;
        break;

      case Fix.RAINBOW_MOON_COMPASS:
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
        this._gold = 420000;
        this._importantType = Important.None;
        this._description = "レインボーカラーで装飾された月のコンパス。コンパスが指し示す方向は常に不定であり、対象が何であるかも判明はしていない。通常時はカラフルな色をしているが保持者の意志決定により、色が一定に定まり、コンパスの差し示す方向も固定になる時がある。力＋１００、技＋１００、知＋１００、体＋１００、心＋１００、炎増幅１０％、氷増幅１０％、聖増幅１０％、闇増幅１０％、炎耐性１０％、氷耐性１０％、聖耐性１０％、闇耐性１０％【特殊効果】メイン行動を行った時、防御、待機以外であれば稀に物攻率、物防率、魔攻率、魔防率、戦速率、戦応率、潜力率のいずれかが２０％上昇するBUFFが付与される。このBUFFは１種類しか付与されず、３ターン継続する。";
        this._strength = 100;
        this._agility = 100;
        this._intelligence = 1;
        this._stamina = 100;
        this._mind = 100;
        this.AmplifyFire = 1.10f;
        this.AmplifyIce = 1.10f;
        this.AmplifyLight = 1.10f;
        this.AmplifyShadow = 1.10f;
        this.ResistFirePercent = 0.10f;
        this.ResistIcePercent = 0.10f;
        this.ResistLightPercent = 0.10f;
        this.ResistShadowPercent = 0.10f;
        break;

      case Fix.ANGEL_CONTRACT_SHEET:
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
        this._gold = 450000;
        this._importantType = Important.None;
        this._description = "天使との契約を果たす事で絶対的な恩恵を授かる事が出来る。その影響により保持者にはほんの少し光のオーラが宿り、一定レベルの魔物が発する様々な効果を対象者は受け付けなくなる。知＋１５０、体＋２００、心＋１５０、猛毒耐性、沈黙耐性、束縛耐性、睡眠耐性、スタン耐性、麻痺耐性、凍結耐性、恐怖耐性、誘惑耐性、鈍化耐性、眩暈耐性、出血耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 150;
        this._stamina = 200;
        this._mind = 150;
        this.ResistPoison = true;
        this.ResistSilence = true;
        this.ResistBind = true;
        this.ResistSleep = true;
        this.ResistStun = true;
        this.ResistParalyze = true;
        this.ResistFreeze = true;
        this.ResistFear = true;
        this.ResistTemptation = true;
        this.ResistSlow = true;
        this.ResistDizzy = true;
        this.ResistSlip = true;
        break;

      case Fix.FLOW_FUNNEL_OF_THE_ZVELDOZE:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者ツヴェルドーゼの傍をよく見るととある物体が空中に浮いている。そこから多彩なアクションが発生しているのだ。この浮遊体は波動意志を送り込む事によって動作する。つまり装備した本人の強い意思決定次第である。力＋１５０、技＋１５０、知＋１５０、心＋６００、物防率２０％、魔防率２０％、戦応率１０％、聖増幅３５％、炎耐性３５％、氷耐性３５％、闇耐性３５％、沈黙耐性、束縛耐性、スタン耐性、麻痺耐性、凍結耐性、恐怖耐性";
        this._strength = 150;
        this._agility = 150;
        this._intelligence = 150;
        this._stamina = 0;
        this._mind = 600;
        this._amplifyPhysicalDefense = 1.20f;
        this._amplifyMagicDefense = 1.20f;
        this._amplifyBattleResponse = 1.10f;
        this._amplifyLight = 1.35f;
        this._resistFirePercent = 0.35f;
        this._resistIcePercent = 0.35f;
        this._resistShadowPercent = 0.35f;
        this._resistSilence = true;
        this._resistBind = true;
        this._resistStun = true;
        this._resistParalyze = true;
        this._resistFreeze = true;
        this._resistFear = true;
        break;

      case Fix.ADILRING_OF_BLUE_BURN:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者エーディルの念が永遠に込められた魔石を刻印した指輪。常に蒼白き炎を放っているのが特徴的で、それだけで相対した者はそれが何であるかは瞬時に判別できる。蒼白き炎は戦闘中、常にその咆哮を戦場に放つだろう。力＋４５０、知＋４５０、心＋１５０、物攻率２０％、魔攻率２０％、潜在率１０％、炎増幅３５％、氷増幅３５％、炎耐性３５％、氷耐性３５％、猛毒耐性、睡眠耐性、鈍化耐性、眩暈耐性、出血耐性";
        this._strength = 450;
        this._agility = 0;
        this._intelligence = 450;
        this._stamina = 0;
        this._mind = 150;
        this._amplifyPhysicalAttack = 1.20f;
        this._amplifyMagicAttack = 1.20f;
        this._amplifyPotential = 1.10f;
        this._amplifyFire = 1.35f;
        this._amplifyIce = 1.35f;
        this._resistFirePercent = 0.35f;
        this._resistIcePercent = 0.35f;
        this._resistPoison = true;
        this._resistSleep = true;
        this._resistSlow = true;
        this._resistDizzy = true;
        this._resistSlip = true;
        break;
      #endregion
      #region "エデルガイゼン城"
      case Fix.EXTREME_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._physicalAttack = 750;
        this._physicalAttackMax = 1000;
        this._gold = 1000000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された剣はエクストリームの称号にふさわしい。物理攻撃力７５０～１０００";
        break;

      case Fix.EXTREME_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._physicalAttack = 900;
        this._physicalAttackMax = 1200;
        this._gold = 1200000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された槍はエクストリームの称号にふさわしい。物理攻撃力９００～１２００";
        break;

      case Fix.EXTREME_AXE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._physicalAttack = 1050;
        this._physicalAttackMax = 1400;
        this._gold = 1400000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された斧はエクストリームの称号にふさわしい。物理攻撃力１０５０～１４００";
        break;

      case Fix.EXTREME_CLAW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._physicalAttack = 700;
        this._physicalAttackMax = 900;
        this._gold = 980000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された爪はエクストリームの称号にふさわしい。物理攻撃力７００～９００";
        break;

      case Fix.EXTREME_ROD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._magicAttack = 750;
        this._magicAttackMax = 1000;
        this._gold = 1000000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された杖はエクストリームの称号にふさわしい。魔法攻撃力７５０～１０００";
        break;

      case Fix.EXTREME_BOOK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._magicAttack = 900;
        this._magicAttackMax = 1200;
        this._gold = 1200000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された本はエクストリームの称号にふさわしい。魔法攻撃力９００～１２００";
        break;

      case Fix.EXTREME_ORB:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._magicAttack = 700;
        this._magicAttackMax = 900;
        this._gold = 980000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された水晶はエクストリームの称号にふさわしい。魔法攻撃力７００～９００";
        break;

      case Fix.EXTREME_BOW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._physicalAttack = 1700;
        this._physicalAttackMax = 2000;
        this._gold = 2100000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された弓はエクストリームの称号にふさわしい。物理攻撃力１７００～２０００";
        break;

      case Fix.EXTREME_LARGE_STAFF:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._magicAttack = 1650;
        this._magicAttackMax = 1950;
        this._gold = 2050000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された両手杖はエクストリームの称号にふさわしい。魔法攻撃力１６５０～１９５０";
        break;

      case Fix.EXTREME_SHIELD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._physicalDefense = 450;
        this._gold = 960000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された盾はエクストリームの称号にふさわしい。物理防御力４５０";
        break;

      case Fix.EXTREME_ARMOR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 700;
        this._gold = 1600000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された鎧はエクストリームの称号にふさわしい。物理防御力７００";
        break;

      case Fix.EXTREME_CROSS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 500;
        this._magicDefense = 200;
        this._gold = 1400000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作された舞踏衣はエクストリームの称号にふさわしい。物理防御力５００、魔法防御力２００";
        break;

      case Fix.EXTREME_ROBE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 150;
        this._magicDefense = 550;
        this._gold = 1800000;
        this._importantType = Important.None;
        this._description = "世界に7つしかない高級素材で製作されたローブはエクストリームの称号にふさわしい。物理防御力１５０、魔法防御力５５０";
        break;

      case Fix.ETHEREAL_EDGE_BLADE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._physicalAttack = 1400;
        this._physicalAttackMax = 1800;
        this._gold = 2100000;
        this._importantType = Important.None;
        this._description = "この世の物とは思えないほどの優美な輝きを放っている剣。切っ先は目に見えない粒度で研磨されており、被対象者は攻撃を食らった場合、致命傷は間逃れない。物理攻撃力１４００～１８００";
        break;

      case Fix.MERGIZD_DAV_AGITATED_BLADE:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._physicalAttack = 2400;
        this._physicalAttackMax = 3500;
        this._magicAttack = 1600;
        this._magicAttackMax = 2300;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者メルギズドは、自我と武具において相性の観点が必要不可欠である事を見出していた。そのため、長く愛用していた剣を完全に捨て、この剣を作成するに至った。その威力は限界値を突破する事に成功している。物理攻撃力２４００～３５００、魔法攻撃力１６００～２３００、力＋５００、知＋２００、心＋１００、戦速率２５、戦応率２５％、潜在率２０％、炎増幅４０％、氷増幅４０％";
        this._strength = 500;
        this._agility = 200;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 100;
        this._amplifyBattleSpeed = 1.25f;
        this._amplifyBattleResponse = 1.25f;
        this._amplifyPotential = 1.20f;
        this._amplifyFire = 1.40f;
        this._amplifyIce = 1.40f;
        break;

      case Fix.EVIL_ELIMINATION_LANCE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._physicalAttack = 1600;
        this._physicalAttackMax = 2100;
        this._gold = 2100000;
        this._importantType = Important.None;
        this._description = "諸悪の根源を抹消するために作成された槍。槍全体からは禍々しいオーラが放たれているが使用者には一切影響はなく、通常の武具として振る舞える。物理攻撃力１６００～２１００";
        break;

      case Fix.PRISON_DESTRUCTION_AXE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Axe;
        this._gripType = GripTypes.OneHand;
        this._physicalAttack = 2000;
        this._physicalAttackMax = 2600;
        this._gold = 2100000;
        this._importantType = Important.None;
        this._description = "どれだけ強固な監獄を気付いても、この斧が存在する限り、監獄が絶対に破られないという事はありえない。想像を絶する破壊力はあらゆるものを打破する。物理攻撃力２０００～２６００";
        break;

      case Fix.SHINGETSUEN_CLAW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Claw;
        this._gripType = GripTypes.OneHand;
        this._physicalAttack = 1300;
        this._physicalAttackMax = 1600;
        this._gold = 2000000;
        this._importantType = Important.None;
        this._description = "月が描く曲線美を模倣しようとして作られた爪。全体的に曲がっており、攻撃ヒット時見た目以上のダメージを与える事に成功する。物理攻撃力１３００～１６００";
        break;

      case Fix.GARGAN_BLAZE_ROD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._magicAttack = 1400;
        this._magicAttackMax = 1800;
        this._gold = 2100000;
        this._importantType = Important.None;
        this._description = "ガルガンの山に住まう伝説の竜は、世界が危機に瀕した時、業火で不浄なる大地を浄化すると言われている。その時の業火を杖に魔力として込められている。魔法攻撃力１４００～１８００";
        break;

      case Fix.JUNKEI_SHIKI_BOOK:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._magicAttack = 1600;
        this._magicAttackMax = 2100;
        this._gold = 2100000;
        this._importantType = Important.None;
        this._description = "風景を示すイラストが描かれているが、実質的な魔力が込められている。その該当ページを開いて詠唱する事で、本来の威力以上の効果を発揮する事ができる。魔法攻撃力１６００～２１００";
        break;

      case Fix.SHEZL_THE_VENTIEL_DARKMIRAGE_BOOK:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._magicAttack = 2700;
        this._magicAttackMax = 3900;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者シェズルは元々戦闘は好まず、純粋に知識のみを欲していた。知識を獲得するための道具として本は重要であるが、実戦的である必要性も常に感じ取っていた。とある事象を境にし、完全なる戦闘術を獲得する。この本はその軌跡の原点を示すものである。魔法攻撃力２７００～３９００、技＋２００，知＋５００、心＋１００、魔防率３０％、戦応率２０％、潜在率２０％、氷増幅４０％、闇増幅４０％";
        this._strength = 0;
        this._agility = 200;
        this._intelligence = 500;
        this._stamina = 0;
        this._mind = 100;
        this._amplifyMagicDefense = 1.30f;
        this._amplifyBattleResponse = 1.20f;
        this._amplifyPotential = 1.20f;
        this._amplifyIce = 1.40f;
        this._amplifyShadow = 1.40f;
        break;

      case Fix.ALL_ELEMENTAL_ORB:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._magicAttack = 1300;
        this._magicAttackMax = 1600;
        this._gold = 2000000;
        this._importantType = Important.None;
        this._description = "全属性の魔力が込められた水晶。虹色に輝く時もあれば、特定の属性色になる時もある。魔法攻撃力１３００～１６００";
        break;

      case Fix.SYOKO_PALESTRIDE_BOW:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._physicalAttack = 3100;
        this._physicalAttackMax = 3700;
        this._gold = 3000000;
        this._importantType = Important.None;
        this._description = "質素な見た目と特徴の無い弓だが、一点、極小の光が矢の突出箇所に凝縮されている。ダメージを食らった時の威力はあらゆる想定を遥かに超えてくる。物理攻撃力３１００～３７００";
        break;

      case Fix.LABYRINTH_MAGE_BLUESTAFF:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Twohand_Rod;
        this._gripType = GripTypes.TwoHand;
        this._magicAttack = 3000;
        this._magicAttackMax = 3600;
        this._gold = 3100000;
        this._importantType = Important.None;
        this._description = "迷宮を作り続ける魔導士は、年を取る事すら忘れ、ひたすらに深い階層を描き続ける。深淵に辿り着くころは、この蒼き大杖が唯一の道標となっている事だろう。魔法攻撃力３０００～３６００";
        break;

      case Fix.MAJESTIC_FORCE_SHIELD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Shield;
        this._gripType = GripTypes.None;
        this._physicalDefense = 800;
        this._magicDefense = 350;
        this._gold = 2000000;
        this._importantType = Important.None;
        this._description = "雄大な力を兼ね備える大きな盾。装備した時、ズッシリとした重たい感触を味わう事になるが、その装甲の固さはその辺の一級品を軽く超える固さを誇る。物理防御力８００、魔法防御力３５０、体＋１２０、聖耐性２０％、闇耐性２０％、炎耐性２０％、氷耐性２０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 120;
        this._mind = 0;
        this._resistLightPercent = 0.20f;
        this._resistShadowPercent = 0.20f;
        this._resistFirePercent = 0.20f;
        this._resistIcePercent = 0.20f;
        break;

      case Fix.EZEKRIEL_IMPRINT_SIGIL_ARMOR:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Heavy_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 3000;
        this._magicDefense = 1800;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者エゼクリエルlは、魔導士としての究極形は重装形態による物理属性への耐性を付け、かつ、魔道攻撃を行う際、完全に物理属性に転換した上で攻撃を繰り広げる事だという地点に到達した。この鎧には様々な刻印が施されており、完全無欠さを放つオーラに覆われている。物理防御３０００、魔法防御１８００、体＋５００、心＋１０００、魔攻率３０％、物防率３０％、聖耐性３５％、闇耐性３５％、炎耐性３５％、氷耐性３５％、猛毒耐性、沈黙耐性、束縛耐性、睡眠耐性、スタン耐性、麻痺耐性、凍結耐性、恐怖耐性、誘惑耐性、鈍化耐性、眩暈耐性、出血耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 500;
        this._mind = 1000;
        this._amplifyMagicAttack = 1.30f;
        this._amplifyPhysicalDefense = 1.30f;
        this._resistLightPercent = 0.35f;
        this._resistShadowPercent = 0.35f;
        this._resistFirePercent = 0.35f;
        this._resistIcePercent = 0.35f;
        this._resistPoison = true;
        this._resistSilence = true;
        this._resistBind = true;
        this._resistSleep = true;
        this._resistStun = true;
        this._resistParalyze = true;
        this._resistFreeze = true;
        this._resistFear = true;
        this._resistSlow = true;
        this._resistDizzy = true;
        this._resistSlip = true;
        break;

      case Fix.SHISO_GENSUI_KING_CROSS:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 1100;
        this._magicDefense = 750;
        this._gold = 3000000;
        this._importantType = Important.None;
        this._description = "始祖の時代に作成された舞踏衣。トラディッショナルな形状であり、無骨な感じが出ている。それに反して、圧倒的な防御力を誇る。物理防御力１１００、魔法防御力７５０、体＋２００、心＋１００、氷耐性２５％、聖耐性２５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 200;
        this._mind = 100;
        this._resistIcePercent = 0.25f;
        this._resistLightPercent = 0.25f;
        break;

      case Fix.ROBE_OF_COLORSTREAMING:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._physicalDefense = 400;
        this._magicDefense = 1300;
        this._gold = 3200000;
        this._importantType = Important.None;
        this._description = "純白をベースとし、何色もの種類の曲線が描かれているローブ。見た目は派手というより優美な印象であり、振る舞う者は他者を魅了する。物理防御力４００、魔法防御力１３００、知＋２００、心＋１００、闇耐性２５％、炎耐性２５％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 200;
        this._stamina = 0;
        this._mind = 100;
        this._resistShadowPercent = 0.25f;
        this._resistFirePercent = 0.25f;
        break;

      case Fix.PLATINUM_RING_1:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【白虎】の刻印が刻まれている。力＋３５０、技＋２５０";
        this._strength = 350;
        this._agility = 250;
        this._intelligence = 0;
        this._stamina = 0;  
        this._mind = 0;
        break;

      case Fix.PLATINUM_RING_2:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【ヴァルキリー】の刻印が刻まれている。力＋２５０、知＋３５０";
        this._strength = 250;
        this._agility = 0;
        this._intelligence = 350;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PLATINUM_RING_3:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【ナイトメア】の刻印が刻まれている。力＋３５０、体＋２５０";
        this._strength = 350;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 250;
        this._mind = 0;
        break;

      case Fix.PLATINUM_RING_4:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【ナラシンハ】の刻印が刻まれている。力＋３５０、心＋２５０";
        this._strength = 350;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 350;
        break;

      case Fix.PLATINUM_RING_5:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【朱雀】の刻印が刻まれている。技＋３５０、知＋２５０";
        this._strength = 0;
        this._agility = 350;
        this._intelligence = 250;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PLATINUM_RING_6:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【ウロボロス】の刻印が刻まれている。技＋２５０、体＋３５０";
        this._strength = 0;
        this._agility = 250;
        this._intelligence = 0;
        this._stamina = 350;
        this._mind = 0;
        break;

      case Fix.PLATINUM_RING_7:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【ナインテイル】の刻印が刻まれている。技＋３５０、心＋２５０";
        this._strength = 0;
        this._agility = 350;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 250;
        break;

      case Fix.PLATINUM_RING_8:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【ベヒモス】の刻印が刻まれている。知＋２５０、体＋３５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 250;
        this._stamina = 350;
        this._mind = 0;
        break;

      case Fix.PLATINUM_RING_9:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【青龍】の刻印が刻まれている。知＋３５０、心＋２５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 350;
        this._stamina = 0;
        this._mind = 250;
        break;

      case Fix.PLATINUM_RING_10:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 1500000;
        this._importantType = Important.None;
        this._description = "白金の素材で形成された腕輪。【玄武】の刻印が刻まれている。体＋３５０、心＋２５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 350;
        this._mind = 250;
        break;

      case Fix.RED_CRYSTAL:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 2000000;
        this._importantType = Important.None;
        this._description = "永久の時代よりその輝きは失われていない、真紅のクリスタル。力＋７５０";
        this._strength = 750;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BLUE_CRYSTAL:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 2000000;
        this._importantType = Important.None;
        this._description = "永久の時代よりその輝きは失われていない、瑠璃のクリスタル。技＋７５０";
        this._strength = 0;
        this._agility = 750;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PURPLE_CRYSTAL:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 2000000;
        this._importantType = Important.None;
        this._description = "永久の時代よりその輝きは失われていない、紫苑のクリスタル。知＋７５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 750;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.GREEN_CRYSTAL:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 2000000;
        this._importantType = Important.None;
        this._description = "永久の時代よりその輝きは失われていない、翡翠のクリスタル。体＋７５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 750;
        this._mind = 0;
        break;

      case Fix.YELLOW_CRYSTAL:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 2000000;
        this._importantType = Important.None;
        this._description = "永久の時代よりその輝きは失われていない、琥珀のクリスタル。心＋７５０";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 750;
        break;

      case Fix.BLACK_DRAGON_FEATHER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3000000;
        this._importantType = Important.None;
        this._description = "エデルガイゼン城の上空を稀に旋回する黒翼龍が落とした羽。絶大な魔力が込められている。技＋２５０、知＋２５０、体＋５００、闇増幅３０％、魔攻率２０％、束縛耐性、恐怖耐性、眩暈耐性";
        this._strength = 0;
        this._agility = 250;
        this._intelligence = 250;
        this._stamina = 500;
        this._mind = 0;
        this._amplifyShadow = 1.30f;
        this._amplifyMagicAttack = 1.20f;
        this._resistBind = true;
        this._resistFear = true;
        break;

      case Fix.RAGING_RESONANCE_RING:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3000000;
        this._importantType = Important.None;
        this._description = "荒れ狂う炎を形容化させた形状のリング。見た目は炎が付与されていないが、装着者の内在的精神とリンクし、炎に関するイメージの増幅が流れ込む。力＋６００、技＋２００、知＋２００、炎増幅３０％、魔防率２０％、睡眠耐性、スタン耐性、凍結耐性";
        this._strength = 600;
        this._agility = 200;
        this._intelligence = 200;
        this._stamina = 0;
        this._mind = 0;
        this._amplifyFire = 1.30f;
        this._amplifyMagicDefense = 1.20f;
        this._resistSleep = true;
        this._resistStun = true;
        this._resistFreeze = true;
        break;

      case Fix.LAGINA_DISTORTED_BRACER:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3100000;
        this._importantType = Important.None;
        this._description = "名君主ラギナが常につけていてたブレイサー。異形な形状をしており、装着するには一定以上の技量と感覚が必要だが、性能を引き出せられれば圧倒的な威力を発揮する事が出来る。技＋６００、体＋３００、心＋１００、氷増幅３０％、物攻率２０％、沈黙耐性、スタン耐性、麻痺耐性";
        this._strength = 0;
        this._agility = 600;
        this._intelligence = 0;
        this._stamina = 300;
        this._mind = 100;
        this._amplifyIce = 1.30f;
        this._amplifyPhysicalAttack = 1.20f;
        this._resistSilence = true;
        this._resistStun = true;
        this._resistParalyze = true;
        break;

      case Fix.RIGID_WAVE_METALGUNTLET:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3100000;
        this._importantType = Important.None;
        this._description = "波動意志を動力源として駆動するメタル製ガントレット。波動意志は訓練も重要だが元来保有している資質も重要になってくる。上手く融合すればそのポテンシャルの高さは計り知れない。力＋４００、知＋４００、心＋２００、聖増幅３０％、戦速率２０％、猛毒耐性、鈍化耐性、眩暈耐性";
        this._strength = 400;
        this._agility = 0;
        this._intelligence = 400;
        this._stamina = 0;
        this._mind = 200;
        this._amplifyLight = 1.30f;
        this._amplifyBattleSpeed = 1.20f;
        this._resistPoison = true;
        this._resistSlow = true;
        this._resistDizzy = true;
        break;

      case Fix.ISOCHRON_FATED_LENS:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3200000;
        this._importantType = Important.None;
        this._description = "このレンズを装着した者は、あらゆる物質の元素記号が脳内に流れ込んでくる。物質の解明を行う知識と共に、論理性が飛躍的に向上する。知＋６５０、心＋３５０、炎耐性３０％、氷耐性３０％、聖耐性３０％、闇耐性３０％、戦応率２０％、束縛耐性、麻痺耐性、凍結耐性";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 650;
        this._stamina = 0;
        this._mind = 350;
        this._resistFirePercent = 0.30f;
        this._resistIcePercent = 0.30f;
        this._resistLightPercent = 0.30f;
        this._resistShadowPercent = 0.30f;
        this._amplifyBattleResponse = 1.20f;
        this._resistBind = true;
        this._resistParalyze = true;
        this._resistFreeze = true;
        break;

      case Fix.DARKNESS_COIN:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3200000;
        this._importantType = Important.None;
        this._description = "闇なる存在と無法の契約を交わした証として獲得できるコイン。コインの保持者は獲得した事による苦痛と共に力を増していく。力＋２００、知＋２００、体＋６００、闇増幅３０％、闇耐性３０％、物防率２０％、恐怖耐性、眩暈耐性、出血耐性";
        this._strength = 200;
        this._agility = 0;
        this._intelligence = 200;
        this._stamina = 600;
        this._mind = 0;
        this._amplifyShadow = 1.30f;
        this._resistShadowPercent = 0.30f;
        this._amplifyPhysicalDefense = 1.20f;
        this._resistFear = true;
        this._resistDizzy = true;
        this._resistSlip = true;
        break;

      case Fix.HEART_SEEKERS_STONE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3300000;
        this._importantType = Important.None;
        this._description = "魂の求道者が保有し続けた石。石の素材そのものには効果が無いが、保有しているものには様々な求道者としてのイメージが流れ込んでくる。技＋３５０、心＋６５０、物攻率２５％、魔攻率２５％";
        this._strength = 0;
        this._agility = 350;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 650;
        this._amplifyPhysicalAttack = 1.25f;
        this._amplifyMagicAttack = 1.25f;
        break;

      case Fix.SUN_BREAKERS_STONE:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3300000;
        this._importantType = Important.None;
        this._description = "太陽を滅する心を持ちし者が永遠に追及し続ける事を決意した証として、この石にその魂が込められている。石の素材そのものには効果が無いが、保有しているものにはそのイメージが流れ込んでくる。力＋３５０、心＋６５０、潜在率＋３０％";
        this._strength = 350;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 650;
        this._amplifyPotential = 1.30f;
        break;

      case Fix.DANZAI_ANGEL_TALISMAN:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 3500000;
        this._importantType = Important.None;
        this._description = "全てを許さない断罪の天使は、罪の重さに関係せず、必ずそれを執行する。かの天使は、ほんの些細な事象も見逃さない。力＋１５０、技＋１５０、知＋１５０、体＋５５０、猛毒耐性、沈黙耐性、束縛耐性、睡眠耐性、スタン耐性、麻痺耐性、凍結耐性、恐怖耐性、鈍化耐性、眩暈耐性、出血耐性";
        this._strength = 150;
        this._agility = 150;
        this._intelligence = 150;
        this._stamina = 550;
        this._mind = 0;
        this._resistPoison = true;
        this._resistSilence = true;
        this._resistBind = true;
        this._resistSleep = true;
        this._resistStun = true;
        this._resistParalyze = true;
        this._resistFreeze = true;
        this._resistFear = true;
        this._resistSlow = true;
        this._resistDizzy = true;
        this._resistSlip = true;
        break;

      case Fix.XEXXER_WORLD_MASTERY_GLOBE:
        this._rarity = Rarity.Epic;
        this._itemType = ItemTypes.Accessory;
        this._gripType = GripTypes.None;
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "古代賢者マクスカーンの強さの源泉はパワーで押す事ではなく強靭なる耐性を有していた事にある。彼がこの装備品を一心に付けている間は、身体全体の体幹が揺らぐ事は決してなく、あらゆる状況において咄嗟の判断が行える事を可能にする。力＋１０００、技＋４００、心＋８００、物攻率３０％、物防率３０％、潜在率２０％、炎耐性４０％、氷耐性４０％、聖耐性４０％、闇体制４０％、猛毒耐性、沈黙耐性、束縛耐性、睡眠耐性、スタン耐性、麻痺耐性、凍結耐性、恐怖耐性、鈍化耐性、眩暈耐性、出血耐性";
        this._strength = 1000;
        this._agility = 400;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 800;
        this._amplifyPhysicalAttack = 1.30f;
        this._amplifyPhysicalDefense = 1.30f;
        this._amplifyPotential = 1.20f;
        this._resistFirePercent = 0.40f;
        this._resistIcePercent = 0.40f;
        this._resistLightPercent = 0.40f;
        this._resistShadowPercent = 0.40f;
        this._resistPoison = true;
        this._resistSilence = true;
        this._resistBind = true;
        this._resistSleep = true;
        this._resistStun = true;
        this._resistParalyze = true;
        this._resistFreeze = true;
        this._resistFear = true;
        this._resistSlow = true;
        this._resistDizzy = true;
        this._resistSlip = true;
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
        break;


      case Fix.SMALL_GREEN_POTION:
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
        this._itemValue1 = 10;
        this._itemValue2 = 20;
        this._gold = 150;
        this._importantType = Important.None;
        this._description = "小さい緑ポーション。初心者の間は重宝する必需品。スキルポイント回復量10～20";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.NORMAL_GREEN_POTION:
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
        this._itemValue1 = 20;
        this._itemValue2 = 30;
        this._gold = 400;
        this._importantType = Important.None;
        this._description = "普通の緑ポーション。一般的な戦闘において重宝する必需品。スキルポイント回復量20～30";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.LARGE_GREEN_POTION:
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
        this._itemValue1 = 30;
        this._itemValue2 = 40;
        this._gold = 1000;
        this._importantType = Important.None;
        this._description = "大きな緑ポーション。ある程度戦闘経験を積んだ者にとっては重宝する必需品。スキルポイント回復30～40";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.HUGE_GREEN_POTION:
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
        this._itemValue1 = 40;
        this._itemValue2 = 50;
        this._gold = 3200;
        this._importantType = Important.None;
        this._description = "巨大な緑ポーション。歴戦の強者達が好んで携帯する必需品。スキルポイント回復40～50";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.HQ_GREEN_POTION:
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
        this._itemValue1 = 50;
        this._itemValue2 = 60;
        this._gold = 5400;
        this._importantType = Important.None;
        this._description = "高品質の緑ポーション。上級戦では常識で使用される必需品。スキルポイント回復50～60";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.THQ_GREEN_POTION:
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
        this._itemValue1 = 60;
        this._itemValue2 = 70;
        this._gold = 8500;
        this._importantType = Important.None;
        this._description = "最高品質の緑ポーション。上位ランクを超えし者が手にする必需品。スキルポイント回復60～70";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PERFECT_GREEN_POTION:
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
        this._itemValue1 = 70;
        this._itemValue2 = 80;
        this._gold = 15000;
        this._importantType = Important.None;
        this._description = "完全な緑ポーション。入手できた者はこの世に僅かしか存在しない。スキルポイント回復70～80";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;
      #endregion
      #region "成長リキッド"
      case Fix.GROWTH_LIQUID_STRENGTH:
        this._description = "能力の一部を成長促進させる薬。力パラメタが１～３ＵＰする。";
        this._itemValue1 = 1;
        this._itemValue2 = 3;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID_AGILITY:
        this._description = "能力の一部を成長促進させる薬。技パラメタが１～３ＵＰする。";
        this._itemValue1 = 1;
        this._itemValue2 = 3;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID_INTELLIGENCE:
        this._description = "能力の一部を成長促進させる薬。知パラメタが１～３ＵＰする。";
        this._itemValue1 = 1;
        this._itemValue2 = 3;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID_STAMINA:
        this._description = "能力の一部を成長促進させる薬。体パラメタが１～３ＵＰする。";
        this._itemValue1 = 1;
        this._itemValue2 = 3;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID_MIND:
        this._description = "能力の一部を成長促進させる薬。心パラメタが１～３ＵＰする。";
        this._itemValue1 = 1;
        this._itemValue2 = 3;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;

      case Fix.GROWTH_LIQUID2_STRENGTH:
        this._description = "能力の一部を成長促進させる薬。力パラメタが５～１０ＵＰする。";
        this._itemValue1 = 5;
        this._itemValue2 = 10;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID2_AGILITY:
        this._description = "能力の一部を成長促進させる薬。技パラメタが５～１０ＵＰする。";
        this._itemValue1 = 5;
        this._itemValue2 = 10;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID2_INTELLIGENCE:
        this._description = "能力の一部を成長促進させる薬。知パラメタが５～１０ＵＰする。";
        this._itemValue1 = 5;
        this._itemValue2 = 10;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID2_STAMINA:
        this._description = "能力の一部を成長促進させる薬。体パラメタが５～１０ＵＰする。";
        this._itemValue1 = 5;
        this._itemValue2 = 10;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID2_MIND:
        this._description = "能力の一部を成長促進させる薬。心パラメタが５～１０ＵＰする。";
        this._itemValue1 = 5;
        this._itemValue2 = 10;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;

      case Fix.GROWTH_LIQUID3_STRENGTH:
        this._description = "能力の一部を成長促進させる薬。力パラメタが２０～３０ＵＰする。";
        this._itemValue1 = 20;
        this._itemValue2 = 30;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID3_AGILITY:
        this._description = "能力の一部を成長促進させる薬。技パラメタが２０～３０ＵＰする。";
        this._itemValue1 = 20;
        this._itemValue2 = 30;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID3_INTELLIGENCE:
        this._description = "能力の一部を成長促進させる薬。知パラメタが２０～３０ＵＰする。";
        this._itemValue1 = 20;
        this._itemValue2 = 30;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID3_STAMINA:
        this._description = "能力の一部を成長促進させる薬。体パラメタが２０～３０ＵＰする。";
        this._itemValue1 = 20;
        this._itemValue2 = 30;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID3_MIND:
        this._description = "能力の一部を成長促進させる薬。心パラメタが２０～３０ＵＰする。";
        this._itemValue1 = 20;
        this._itemValue2 = 30;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;

      case Fix.GROWTH_LIQUID4_STRENGTH:
        this._description = "能力の一部を成長促進させる薬。力パラメタが４５～６０ＵＰする。";
        this._itemValue1 = 45;
        this._itemValue2 = 60;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID4_AGILITY:
        this._description = "能力の一部を成長促進させる薬。技パラメタが４５～６０ＵＰする。";
        this._itemValue1 = 45;
        this._itemValue2 = 60;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID4_INTELLIGENCE:
        this._description = "能力の一部を成長促進させる薬。知パラメタが４５～６０ＵＰする。";
        this._itemValue1 = 45;
        this._itemValue2 = 60;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID4_STAMINA:
        this._description = "能力の一部を成長促進させる薬。体パラメタが４５～６０ＵＰする。";
        this._itemValue1 = 45;
        this._itemValue2 = 60;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID4_MIND:
        this._description = "能力の一部を成長促進させる薬。心パラメタが４５～６０ＵＰする。";
        this._itemValue1 = 45;
        this._itemValue2 = 60;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;

      case Fix.GROWTH_LIQUID5_STRENGTH:
        this._description = "能力の一部を成長促進させる薬。力パラメタが８０～１００ＵＰする。";
        this._itemValue1 = 80;
        this._itemValue2 = 100;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID5_AGILITY:
        this._description = "能力の一部を成長促進させる薬。技パラメタが８０～１００ＵＰする。";
        this._itemValue1 = 80;
        this._itemValue2 = 100;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID5_INTELLIGENCE:
        this._description = "能力の一部を成長促進させる薬。知パラメタが８０～１００ＵＰする。";
        this._itemValue1 = 80;
        this._itemValue2 = 100;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID5_STAMINA:
        this._description = "能力の一部を成長促進させる薬。体パラメタが８０～１００ＵＰする。";
        this._itemValue1 = 80;
        this._itemValue2 = 100;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID5_MIND:
        this._description = "能力の一部を成長促進させる薬。心パラメタが８０～１００ＵＰする。";
        this._itemValue1 = 80;
        this._itemValue2 = 100;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;

      case Fix.GROWTH_LIQUID6_STRENGTH:
        this._description = "能力の一部を成長促進させる薬。力パラメタが１３０～１６０ＵＰする。";
        this._itemValue1 = 130;
        this._itemValue2 = 160;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID6_AGILITY:
        this._description = "能力の一部を成長促進させる薬。技パラメタが１３０～１６０ＵＰする。";
        this._itemValue1 = 130;
        this._itemValue2 = 160;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID6_INTELLIGENCE:
        this._description = "能力の一部を成長促進させる薬。知パラメタが１３０～１６０ＵＰする。";
        this._itemValue1 = 130;
        this._itemValue2 = 160;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID6_STAMINA:
        this._description = "能力の一部を成長促進させる薬。体パラメタが１３０～１６０ＵＰする。";
        this._itemValue1 = 130;
        this._itemValue2 = 160;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID6_MIND:
        this._description = "能力の一部を成長促進させる薬。心パラメタが１３０～１６０ＵＰする。";
        this._itemValue1 = 130;
        this._itemValue2 = 160;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;


      case Fix.GROWTH_LIQUID7_STRENGTH:
        this._description = "能力の一部を成長促進させる薬。力パラメタが２００～２４０ＵＰする。";
        this._itemValue1 = 200;
        this._itemValue2 = 240;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID7_AGILITY:
        this._description = "能力の一部を成長促進させる薬。技パラメタが２００～２４０ＵＰする。";
        this._itemValue1 = 200;
        this._itemValue2 = 240;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID7_INTELLIGENCE:
        this._description = "能力の一部を成長促進させる薬。知パラメタが２００～２４０ＵＰする。";
        this._itemValue1 = 200;
        this._itemValue2 = 240;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID7_STAMINA:
        this._description = "能力の一部を成長促進させる薬。体パラメタが２００～２４０ＵＰする。";
        this._itemValue1 = 200;
        this._itemValue2 = 240;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      case Fix.GROWTH_LIQUID7_MIND:
        this._description = "能力の一部を成長促進させる薬。心パラメタが２００～２４０ＵＰする。";
        this._itemValue1 = 200;
        this._itemValue2 = 240;
        this._gold = 0;
        AdditionalDescription(Item.ItemTypes.Potion);
        this._rarity = Rarity.Rare;
        this._limitValue = RARE_EPIC_ITEM_STACK_SIZE;
        break;
      #endregion
      #region "ドロップアイテム"
      case Fix.COMMON_MANTIS_TAIEKI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 48;
        this._description = "マンティスの体液は皮膚に塗ると薬用として効果があると言われている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_GREEN_SIKISO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 52;
        this._description = "樹木の表面にほんのり残っていた緑色素。持っていると、少しだけ暖かみを感じる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_MANDORAGORA_ROOT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 56;
        this._description = "マンドラゴラ死に際の根には、魔力が宿る言われている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_WOLF_FUR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 60;
        this._description = "衣類のカテゴリで最もよく使われる素材の一つ。ゴワつき感があるがしっかりとした毛皮である。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_ANT_ESSENCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 74;
        this._description = "アリの死骸から採取されたエッセンス。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_KATAME_TREE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 79;
        this._description = "よく見慣れた形状である杖型の原木。先端の形状は職人の手に形となり、その後魔力が宿される。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SUN_LEAF:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 84;
        this._description = "太陽の恩恵を受けずに人工的な光で育った葉。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_WARM_NO_KOUKAKU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 89;
        this._description = "死骸となったワームの甲殻の欠片。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_YELLOW_TAIEKI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 94;
        this._description = "取得してから短い期間は黄色い体液として所持するが、時間経過に伴い、不思議な色の固形物に変化する。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_RABBIT_MEAT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 99;
        this._description = "雑食で育ったウサギの肉。煮てから焼いて食べると美味しい。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_TOGETOGE_GRASS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 116;
        this._description = "生物として存在している間は柔らかい組織で出来ているが、死後はトゲトゲの形状に変化する。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_ASH_EGG:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 122;
        this._description = "灰色ではあるが、れっきとした卵。不気味だが美味と言われている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_RED_HOUSI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 128;
        this._description = "胞子攻撃の際に噴出された胞子。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_DOKUSO_NEEDLE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 134;
        this._description = "猛毒注意。手で触れる時は最大限の注意を払わないと、毒素が身体に回ってしまう。運搬の際は専用の袋に入れて運んだ方が良い。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_PLANTNOID_SEED:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 140;
        this._description = "体当たり時に紛れ落ちていたプラントノイド種。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_HORSE_HIZUME:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 146;
        this._description = "デカい蹄。素材自体に特徴はないが、採取できる量が少ないため、それなりに価値ある素材として知られている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_MACHINE_PARTS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 232;
        this._description = "ジャンク品として扱われる機械の部品。希少価値を見出す商人もいるが、そうだとしても一般的な価格で取引される。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_COLORFUL_BALL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 240;
        this._description = "カラフルな装飾が施されている魔道の弾。一見すると威力がある様に見えるが、それほど高級な素材で創られているものではない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SHARP_HAHEN:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 248;
        this._description = "砕け散った破片はまとまりが無く、あらゆる形状に分離している。下手に触れるとケガするが、慎重に運搬すれば取引対象物として扱う事ができる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_BAT_FEATHER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 256;
        this._description = "素材としては良いのだが、何かとキツい匂いが伴う。レザー系のアイテムを作る際によく使われるため、価値はある。少々我慢して運ぶしかない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_GLASS_SHARD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 264;
        this._description = "透明なガラスの破片。ドロップしていても気付かずに拾われないケースもある。モンスター撃破の後、しっかりと確認する必要がある。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_MECHANICAL_SHAFT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 289;
        this._description = "組み立て構造物を創造する際、ほぼ使われる部品。単価は普通であり、需要と供給のバランスも一般的である。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_AMBER_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 299;
        this._description = "使いどころの分からない素材だが、腕のある職人の手に渡れば、高品質の武具が製作されると言われている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_NEBARIKE_EKITAI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 309;
        this._description = "手で取ろうとすると、手にくっついてしまうため、ある程度袋を用意し、それに直接入れる必要がある。少々気持ち悪いアイテムだが、取引素材として持っていく価値はある。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_USUGATA_ENBAN:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 319;
        this._description = "この形状をした素材は数少なく、奇麗な形状であればあるほど価値は上がる。モンスターからのドロップであるため、奇麗な形状で残る確率は皆無でほとんどは職人が形状を奇麗に仕立て上げて再び販売されるようになる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_HASSYADAI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 329;
        this._description = "何でもかんでも飛ばしてみたい！という願望を叶えてくれる道具。武器以外の使い方が色々とあるため、人気商品として売られやすい。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_KYOUTEN_X:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 339;
        this._description = "これを手にしたものは・・・【幸福Ｘ倍】という名の呪いが掛けられると言われている。真相は定かではないが、興味を持って購入してくれる人もいる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_SOLIDSTONE_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 369;
        this._description = "見た目は何の特徴もないため、ブラックマテリアルと混同してしまいがちだが、成分を解析すると硬質化素材のエッセンスが含まれている事がわかる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_JUNK_PARTS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 381;
        this._description = "粗悪品、劣悪品、使えないパーツ。ただし、形を成していないだけであり、創造すればいいだけの事。部品自体は流通の対象となる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_ELECT_BOLT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 393;
        this._description = "最初からボルトの形状をしているため、天然物と信じてもらうには難しい。電磁波も帯びているため、加工次第で様々なアイテムを生成できる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_GARGOYLE_EYE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 405;
        this._description = "装飾品の一つとして重宝される素材。これ自体は不気味であるが、偉大なる杖などにはめ込む方式でよく使われる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_WATCHDOG_TONGUE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 417;
        this._description = "番犬の舌はあらゆるものを嚙みちぎってきた証として、無数の切り傷が入っている。焼いて食べると意外に美味しいと好評。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_BUYOBUYO_MOEKASU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 429;
        this._description = "元の素材が何であるか分からないほど消失している燃えカス。燃えカス自体に価値は無いが、残留している炎のエッセンスが重宝する。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_BAKUHA_CHAKKAZAI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 464;
        this._description = "あらゆるものを爆破させるためには、まずこれが必要だ。形を問わず、ケースを問わず、タイミングを問わず、爆弾とはそういうものだ。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SEKKAIKOU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 478;
        this._description = "鉱山からよく採取される素材アイテムだが、純度が高く、本素材を基にして作成された武具は長持ちする。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_CHROTIUM_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 492;
        this._description = "それは人工的に造られた素材であるはずだったが、遥か古代から存在していた事が後に判明する。本素材はエッセンス変換の元になる貴重な素材である。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SANKAKU_STEEL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 506;
        this._description = "この最初から奇麗に形成されている鋼鉄素材はあまりなく、すぐさま市販品として流通できるレベルである。手っ取り早く売ると良いだろう。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_PURPLE_BOTTOLE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 520;
        this._description = "特に何らかの成分を蓄えているわけではないが、不思議と人気のある素材アイテム。見た目の色合いと形状が流行りの元となっている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_BOAR_MOMONIKU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 654;
        this._description = "柔らかく、歯ごたえもあり、ボリュームもある。食材として一番人気で売れる素材である。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_MIST_LEAF:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 672;
        this._description = "季節に応じてその形状は様々である。同じ素材ではあるが、形状が都度異なるため、それによって値段も変動する。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_NORMAL_SPORE_ESSENCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 690;
        this._description = "ちょっとこのままでは誰も買ってくれない・・・ただ、その道の業者が奇麗に加工してくれる事で一般的な素材として使えるようになる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_FROG_FRONTLEG:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 708;
        this._description = "この形状だとどう見ても例の足に見えるため、食用とは言えそのままでは誰も欲しがらない。調理の過程を経て、始めて食事をとる事が出来る。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SNAKE_EMPTYSHELL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 726;
        this._description = "バックパックは人気商品の一つであり、様々な模様の物がある。なかでも蛇の抜け殻を素材として造られたバックパックはかなりの人気商品であり、入荷してもすぐに売り切れる" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_BEAR_LARGE_CLAW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 774;
        this._description = "研ぎ澄まされたその大爪は、加工する以前から強度および威力は高い。熟練の職人が手を加える事で強力な武具に仕上げられる事だろう。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_FAIRY_POWDER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 796;
        this._description = "このパウダーは視覚的な要素が強く、興味を持って魅入った者は購入するという衝動に駆られる。使い道としての価値は低いので、何らかのセット商品で売られる事が多い。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_BEAUTY_WHITEFEATHER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 818;
        this._description = "テクノロジの頂点を捉えていた古代文明では大自然の生物は存在していない。そのため、大自然そのものであるこの白羽は、奇跡の象徴として扱われた。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_DRYAD_RINPUN:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 840;
        this._description = "ドライアドが死に際に散布した鱗粉。ほのかに良い香りがする。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_HUNTER_TOOL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 862;
        this._description = "このままでも十分使える用具ではあるのだが、取り出し口が小さく一般の人達にとっては扱うのが難しいため、少し調整して一般品として出荷される品物。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_BLACK_MIST_ESSENCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 884;
        this._description = "通路の隙間にドロップしていると、影と同化していて見え難い。魔法学でよく使用されるアイテムなので、念のため見つけたら拾って置いて損はしない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_ELEPHANT_LEGS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 941;
        this._description = "本素材はアイテム生成にも食用としても使えるため、かなり広範囲の商人がすぐに買い占める傾向がある。多少重たいが頑張って持ち帰ろう。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_ELEMENTAL_KONA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 967;
        this._description = "妖精と森と言えば、このアイテムで決まり。魔法や、武器エンチャント、合成素材、なんにでも使えるが、よく考えてから使用する事。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_LAPTOR_FUR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 993;
        this._description = "職人の腕の見せ所。基本的に取り扱える代物ではなく、加工にも非常に時間はかかるし、価値あるアイテムの創生も稀にしか出来ない。だが、挑戦し続けるのが人の営みである。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SHARPNESS_TIGER_TOOTH:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1019;
        this._description = "剣歯虎の牙からは強靭性エキスが摘出可能である。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_THORN_ELEMENT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1045;
        this._description = "非常に不格好ではあるが、威力や潜在価値は申し分ない。一部の商人達は購入を控えるものの、密に売値が上がる事を期待してストックしている噂がある。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_DORO_YOUKAIEKI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1071;
        this._description = "これを手で持ち運ぶ事は不可能なため、強固なバックパックが必要となる。それでもバックパックを損傷したくない冒険者たちは専用のミニボックスを用意している事が多い。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_YOUKAI_MIKI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1137;
        this._description = "戦闘慣れしていない一般人から見ると単なる幹。熟練者が見れば間違いなく妖気を感じる代物であり、魔力を秘めている事は明白である。一部の商人が好んで買い取る。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_DANPEN_OF_GOFU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1167;
        this._description = "所定の場所に収められていたはずの蛇が、護符の効果が切らす目的で噛みつく場合がある。この護符はその断片であるが、まだ護法の力は僅かに宿っている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_GOTUGOTU_BIGTREE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1197;
        this._description = "バカでかい木で、素材としては普通。ただ、こうした原木はあらゆる商品を造る時に使われるため、使用用途は多く人気のある素材である。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_MARY_KISS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1227;
        this._description = "マリーのキッスは恐れられる場合がほとんどだが、独自の趣向を持っている一部の人には好まれるアイテムである。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_REHINO_HOHONIKU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1257;
        this._description = "そのままの食材として一般的であるが、調理の仕方によって肉の臭みを完全に削ぎ落し、フルーツ感覚の食感を味わえる。調理人の腕によって味は左右されるだろう。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_MAGIC_HORN:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1587;
        this._description = "そのホーンからは確かな魔力が感じ取れる。しかしホーンそのものに道具としての使い道はないため、インテリアとして使われる事が多い。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_THREE_FEATHER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1623;
        this._description = "1つ羽は不幸、２つ羽は契り、３つ羽は盛栄。この羽を手にした者にはささやかな幸福が訪れるだろう。縁起物として隣人に贈る時によく使われる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_YELLOW_DOROTSUCHI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1659;
        this._description = "色合いが鮮やかな方がより売買の対象になりやすい。使い道は色々とあるが、主に繊維系で良く用いられる素材である。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_RED_DOROTSUCHI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1695;
        this._description = "色合いが鮮やかな方がより売買の対象になりやすい。使い道は色々とあるが、主に武具系で良く用いられる素材である。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_WINDMAN_SEAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1731;
        this._description = "砂漠の民、深海の民、森の民。その中でも風の民は中々姿を現す事はない。ただし精霊達が契約下でこの印を保持している場合があり、貴重な素材として知られている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_AIRORIGIN_KIHO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1817;
        this._description = "下手に手で持ち運ぼうとすると、すぐ消失してしまうアイテム。直接触れるのではなく、ある程度の魔力で少し形状化させて持ち運ぶと良いだろう。売る時もその状態のままで販売される。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_HENSYOKU_KOKE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1859;
        this._description = "コケは注意深く観察しないと、毒成分を含んでいるのか、活性成分を含んでいるのか分からない。直観は危険であり、分析能力を用いてから取得するようにした方が良い。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_KIRAMEKU_GOLDHORN:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1901;
        this._description = "豪華で煌びやかな角。武具にするのは勿体ないとされており、そのままの形で部屋に飾られる事が多い。ただ、中には違法なオークションに出品する事を目的とする輩もおり扱いには注意した方が良い。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_MYSTERY_SCROLL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1943;
        this._description = "開くまで-中身は-見えない。開くと-効果を-発動する。効果は-発動後-判明する。使い道が難しいので戦闘で使うのではなく面白い商品として一般に売られる事が多い。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_BIRD_OUGI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 1985;
        this._description = "偶然にも扇子の形状をした状態で固定化された。アイテムとしては使いにくく、インテリアにもあまり向いてなく活用できる場面は少ない。一部のマニアが好んで購入する。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_BLUECOLOR_EYE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2027;
        this._description = "おぞましい・・・恐ろしい・・・絶対に手にしたくはないが、闇鍋料理を作る時に使われるようだ。もちろん完成した料理には出てこない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_WHITECOLOR_EYE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2069;
        this._description = "きれいであり・・・惹かれる・・・だが、ただの目玉であるため、あまり価値はない。魅入られた者は即購入していくが、どういった使い道なのかはあまり知られてない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_CURTAIN_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2171;
        this._description = "素材そのものがモンスターから入手できるのは稀である。ただし、かなり汚れており、多少洗い流しただけでは売り物にはならない。一旦、清潔な状態にしてから流通品として出回る。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_MEGANE_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2219;
        this._description = "このアイテムはあらゆる眼鏡のタイプに用いられる素材だが、中でも博識メガネと呼ばれる商品を生成するために、この素材を最低でも１００個集める必要があると言われている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_ARTHARIUM_JEWEL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2267;
        this._description = "この宝石自体に利用価値はないが、貨幣と同等に扱われるアイテムとしてよく取引されている。エリアによっては通常の貨幣よりも価値があると言われているが、定かではない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_KITSUNE_TAIL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2315;
        this._description = "このアイテムを道具として使う事はなく、部屋の一区画に供えるのが通常の使い方である。意味はないが、心、いわゆる精神的な静穏が宿るとされる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_LION_FUR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2363;
        this._description = "色、ツヤ、丈夫さ共に万能の素材。非常に売れる素材であるため、これだけを入手するための専属のハンターがするほどである。所持していると狙われる場合もあるので、気を付けよう。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_WHITE_HIDUME:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2411;
        this._description = "カッコ良いアイテムではあるが、重たいし使い道もなく、武具向けの加工にも向いていない。魔法学でも一定の効果は望めるが、期待はできない。ただ、何らかの使い方があるのではないかと追い求める者がいる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_TOUMEI_KESSYO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2459;
        this._description = "輪郭だけは見えるが、無色透明のせいで景色に溶け込んでおり、視認は難しい。純度の高いエッセンスを内包しており、魔法学で重宝される素材として知られている。" +Fix.DESCRIPTION_SELL_ONLY;
        break;
  
      case Fix.COMMON_PARTIMIUM_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2577;
        this._description = "一般的な硬質化とは異なる結合配列で構成されるエッセンス素材。量子空間の知見である程度の解析は出来ているが、本質的には理解に至っておらず研究対象となっている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_HUGE_BOOK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2631;
        this._description = "バカデカい箱。持ち運ぶのも苦労するが、売り買いでも苦労する。ちなみに、中身を空けてガッカリする事もある・・・。ただ、本当に豪華賞品が入っている場合もある。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_GUNPOWDER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2685;
        this._description = "危険物、取り扱い注意。普通に持ち運ぶ際は問題ないが、意図せずして発火要因が周囲にある場合、暴発被害を被る場合があるため、結局気を付けるしかない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SILENT_WHISTLE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2739;
        this._description = "戦闘経験慣れしている者は、音を聴く必要はなく、直観でこの笛から発せられた何かを感じ取る事が出来る。ただし一般生活ではその必要はなく普通に使われる。もちろん音を出す事は可能。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_STEEL_BATON:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2793;
        this._description = "重く頑丈で固いバトン。どう使うのかは分からず、武器としての価値も低いが、不思議と人気商品であり買っていく人は多い。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_PURE_SILVER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2847;
        this._description = "重鎧作成過程で溶接した部分の強度はどうしても下がってしまう。これに対し、熟練の技量が必要であるが、この素材を駆使して溶接する事で強度を維持する事が出来るだろう。" + Fix.DESCRIPTION_SELL_ONLY;
        break;

      case Fix.COMMON_SPEEDARROW_TOOL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 2981;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_OVAL_GEAR:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 3041;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_APLITOS_BONE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 3101;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_MUKAKOU_SEKIEI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 3161;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_HOUDAN_SHARD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 3221;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_DEATH_CLOVER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 3281;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.COMMON_DAGGERFISH_UROKO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 5841;
        this._description = "牙魚の鱗は、薄いが歯ごたえのある硬さがウリの一つ。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_MANTA_HARA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 5911;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_BLUE_MAGATAMA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 5981;
        this._description = "その青さは、目立たないが、高貴な雰囲気を出している。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_KURIONE_ZOUMOTU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6051;
        this._description = "臓物の中でも特に鮮度の高い部分を切り出してある。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_RENEW_AKAMI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6121;
        this._description = "活きの良いマグロの赤身。アンシェットの町では売れ筋No.1。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_ROSE_SEKKAI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6191;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.COMMON_WASI_BLUE_FEATHER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6361;
        this._description = "異常成長した海鷲の青い羽。幸運を呼ぶと言われている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_HANTOUMEI_ROCK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6441;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_EIGHTEIGHT_KUROSUMI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6521;
        this._description = "純黒色の墨。少し粘りっけがある。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_BLACK_GESO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6601;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_BIGAXE_TOP:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6681;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_GANGAME_EGG:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6761;
        this._description = "異常な大きさの卵。生のままでは食べられない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_JUMP_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6841;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_KYOZIN_MUNENIKU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 6921;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.COMMON_NANAIRO_SYOKUSYU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7116;
        this._description = "カラフルな触手のため、数多くの魚がこの罠に引っかかると言われている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SEA_MO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7206;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_SERPENT_UROKO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7296;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_AYASHII_NENNEKI_ITO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7386;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_GOTUGOTU_KARA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7476;
        this._description = "ちょっとやそっとのパンチ・キックでは壊れない殻。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SOFT_BIG_HIRE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7566;
        this._description = "極薄のヒレ。コリコリした感触で、歯ごたえ十分。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_BIG_STONE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7656;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_TAIRYO_FISH:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7746;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.COMMON_UNKNOWN_BOX:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 7966;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_PUREWHITE_KIMO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 8066;
        this._description = "白色の肝には、身体の健康を促進させる効果があると言われている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SHRIMP_DOTAI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 8166;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_KOUSITUKA_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 8266;
        this._description = "ブラック・スターフィッシュは死亡後、硬質化し物質成分が変化する。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_AOSAME_UROKO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 8366;
        this._description = "普通に触ると柔らかいが、対衝撃性に優れている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_JOE_TONGUE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 8466;
        this._description = "長い。硬い。ゴツい。料理の腕が問われる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_EMBLEM_KNIGHT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 8566;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.COMMON_SEA_WATER:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 8811;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_BLACKSAME_TOOTH:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 8921;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_MYSTERIOUS_KARA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 9031;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_CURSED_ITO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 9141;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_CHINMI_FISH:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 9251;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_SEA_MUSICBOX:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 9361;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.COMMON_HUNTER_SEVEN_TOOL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 19471;
        this._description = "ハンター達が長年利用してきたアイテム類は、戦況を有利な状況へと導いてくれる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_BEAST_KEGAWA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 19682;
        this._description = "ビーストマスターが所有していた毛皮。弾力と剛質性を兼ね備えている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_BLOOD_DAGGER_KAKERA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 19893;
        this._description = "ダガーに付着している血液は、どの獣の血か既にわからない。血液成分をキッチリ鑑定すれば、何かに使えそうだ。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_SABI_BUGU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 20104;
        this._description = "堕ちたる求道者は、武具のメンテナンスを全く行ってない。鍛冶屋がメンテナンスすれば元の状態に戻せそうだ。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_MEPHISTO_BLACKLIGHT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 20315;
        this._description = "メフィストの右腕についていた黒い瘴気が怪しく光っている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_STEAM_POMP:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 20526;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.COMMON_SEEKER_HEAD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 20907;
        this._description = "求道者の末期姿。闇の眷属は求道者の潜在能力を吸い取り、それを糧として力を得ていた。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_ESSENCE_OF_DARK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 21220;
        this._description = "闇のマテリアル合成素材。武具職人の力量が問われる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_EXECUTIONER_ROBE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 21533;
        this._description = "執行人のローブには呪いの念がこめられており、通常の人間には扱えない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_NEMESIS_ESSENCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 21846;
        this._description = "倒れていたネメシスからエッセンスが抽出されたもの。溶かす事で何かの成分が摘出できそうだ。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_MASTERBLADE_FIRE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 22159;
        this._description = "マスターブレイドに宿らせる火。禍々しさは消えうせている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_GREAT_JEWELCROWN:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 22472;
        this._description = "派手な装飾により煌びやかに光っている。宝石素材のみ使い道あり。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_GOUKIN_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 22785;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.RARE_ESSENCE_OF_SHINE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 23288;
        this._description = "聖のマテリアル合成素材。ポーション合成スキルの力量が問われる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_KUMITATE_TENBIN_DOU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 23704;
        this._description = "魔法生命の天秤より得られた素材。このままでは使えないが・・・" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_DEMON_HORN:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 24120;
        this._description = "悪魔の角には咎を収める能力が込められている。その能力は角の繊維の奥深くに隠されている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_WYVERN_BONE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 24536;
        this._description = "ワイバーンの骨からは体力維持に欠かせないエキスが大量に抽出できる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_ESSENCE_OF_FLAME:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 24952;
        this._description = "火のマテリアル合成素材。武具職人の力量が問われる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_BLACK_SEAL_IMPRESSION:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 25368;
        this._description = "黒色とは分からないほど、禍々しいまでにドス黒い印鑑。黒い液体はエキスとして使えそうだ。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_HIGH_ESTORMIUM_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 25784;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.COMMON_ONRYOU_HAKO:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 26410;
        this._description = "何が飛び出てくるか分からない・・・箱からは強烈な恐怖が伝わってくるため、肝のすわった鍛冶職人にしか開くことは出来ない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_ANGEL_SILK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 26930;
        this._description = "純白かつ透明なシルク素材。触っている感触が分からないほど軽い。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_CHAOS_SIZUKU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 27450;
        this._description = "どれほどの人格者であったとしても、これに触れた途端、カオス属性に落とし込むエキスが内部に凝固化して入っている。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_DREAD_EXTRACT:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 27970;
        this._description = "恐怖のエッセンスが凝縮されているエキス。耐性力を高める効果が期待できる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.RARE_DOOMBRINGER_KAKERA:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 28490;
        this._description = "闇を滅するドゥームブリンガーの欠片。不思議と血液は付着してない。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_KOKU_THUNDER_SIRUSI:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 29010;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_TENNEN_JISYAKU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 29530;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;

      case Fix.COMMON_VOID_BOU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 30280;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_ESSENCE_OF_WIND:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 30905;
        this._description = "風のマテリアル合成素材。武具職人の力量が問われる。" + Fix.DESCRIPTION_SELL_ONLY;
        break;
      case Fix.COMMON_INNOCENCE_ESSENCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 31530;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_JUNKAN_MAHU_GU:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 32155;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
        break;
      case Fix.COMMON_UNRESOLVED_MATERIAL:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.SellOnly;
        this._gold = 32780;
        this._description = "市場で流通し、売買が可能なアイテム。売却専用品。";
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
        break;

      case Fix.KODAIEIJU_EDA:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.EventItem;
        this._importantType = Important.Precious;
        this._description = "神秘の森で入手した古代栄樹の枝。何の変哲も無い枝だが、不思議と生命力が感じられる。深い茂みがあり通過出来ない箇所で振りかざしてみよう。";
        break;

      case Fix.KIGAN_OFUDA:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.EventItem;
        this._importantType = Important.Precious;
        this._description = "神秘の森においては、侵入者の行く手を阻む突風が吹き荒れる箇所が存在する。この御札を保持している事で、突風は自然と収まるだろう。";
        break;

      case Fix.STAR_DUST_KEY:
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
        this._description = "オーランの塔で入手した星屑の鍵。星屑の紋様が描かれている扉に対して使用する事で、扉は開くだろう。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SHADOW_MOON_KEY:
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
        this._description = "オーランの塔で入手した月影の鍵。月影の紋様が描かれている扉に対して使用する事で、扉は開くだろう。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.SUN_BURST_KEY:
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
        this._description = "オーランの塔で入手した日輪の鍵。日輪の紋様が描かれている扉に対して使用する事で、扉は開くだろう。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.ORIGIN_ROAD_KEY:
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
        this._description = "オーランの塔で入手した原初の鍵。原初の紋様が描かれている扉に対して使用する事で、扉は開くだろう。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        break;

      case Fix.PURE_SINSEISUI:
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
        this._description = "純濃度が高い青い液体で生成された回復ポーション。飲んだ者のマナを100%回復する。ただし1度使うと空となるが、次の日になれば自然発生によりポーションはまた使える様になる。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.PURE_VITALIRY_WATER:
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
        this._description = "純濃度が高い緑色の液体で生成された回復ポーション。飲んだ者のスキルポイントを100%回復する。ただし1度使うと空となるが、次の日になれば自然発生によりポーションはまた使える様になる。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        break;

      case Fix.VELGUS_KEY1:
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
        this._description = "ヴェルガス海底神殿で入手した扉の鍵【１】。第一階層に設置されている特定の扉に対して使用する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.VELGUS_KEY2:
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
        this._description = "ヴェルガス海底神殿で入手した扉の鍵【２】。第一階層に設置されている特定の扉に対して使用する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.VELGUS_KEY3:
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
        this._description = "ヴェルガス海底神殿で入手した扉の鍵【３】。第一階層に設置されている特定の扉に対して使用する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.VELGUS2_KEY1:
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
        this._description = "ヴェルガス海底神殿で入手した鍵。【静穏】の文字が刻印されている。第二階層に設置されている特定の扉に対して使用する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.VELGUS2_KEY2:
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
        this._description = "ヴェルガス海底神殿で入手した鍵。【疾走】の文字が刻印されている。第二階層に設置されている特定の扉に対して使用する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.VELGUS2_KEY3:
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
        this._description = "ヴェルガス海底神殿で入手した鍵。【順応】の文字が刻印されている。第二階層に設置されている特定の扉に対して使用する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.EDELGARZEN_KEY:
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
        this._description = "エデルガイゼン城で入手した鍵。この鍵を使う事で正面ゲートの扉を開く事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.EDELGARZEN_KEY1:
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
        this._description = "エデルガイゼン城で入手した鍵。【不屈】の刻印が刻まれている。一階：中枢区画への扉を開く事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.EDELGARZEN_KEY2:
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
        this._description = "エデルガイゼン城で入手した鍵。【意志】の刻印が刻まれている。二階：中枢区画への扉を開く事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.EDELGARZEN_KEY3:
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
        this._description = "エデルガイゼン城で入手した鍵。【無為】の刻印が刻まれている。三階：中枢区画への扉を開く事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.EDELGARZEN_KEY4:
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
        this._description = "エデルガイゼン城で入手した鍵。【全知】の刻印が刻まれている。四階：王の間への扉を開く事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        break;

      case Fix.MARBLE_STAR:
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
        this._description = "オーランの塔で入手した不思議な赤い球状の素材。素材アイテムとして売買できそうではあるが、どのような用途で用いられるかは不明である。";
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
        break;

      case Fix.PRECIOUS_SWORD:
        this._rarity = Rarity.Rare;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 0;
        this._physicalAttack = 1;
        this._physicalAttackMax = 3;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "その剣には飾り付けが幾つか施されているが、実質的な武器としての効果は見受けられない。武具としての特徴的な本質は分かり難くなっており、一般的な強さを示す武器とは性質が異なる。何らかのレプリカにも見えるが、元となる素材も判明していない。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.BLUESKY_STAR_FEATHER:
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
        this._description = "真夜中の空に一つ浮かび上がるは蒼き羽を象徴する星。ツァルマンの里と対となるゼールマンの里から受け継がれた貴重な蒼い羽。手に乗せた際、僅かに空中に浮き、手のひらの上を少し漂う感じで不規則に動くため、この羽には過去に絶滅した蒼き不死鳥がまだ生命を宿しているのではないかと言われている。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.REDCOMET_STAR_CHARM:
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
        this._description = "真昼の空に一つ浮かび上がるは朱き彗星。ツァルマンの里意外ではこれを吉兆の星とは呼ばず、運命を司る星と詠んでいる。不吉を呼び寄せているのか、幸福が訪れているのかは人としての感性に依存しておりいずれも適切ではない。古来より伝わるオラクルの預言は常に確定的であり、かつ、未知である。";
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
        this._description = "その輝きが放たれる事は無い。選ばれし者のみが心に宿らせる剣。物理攻撃力10000～15000。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.LEGENDARY_FELTUS:
        this._rarity = Rarity.Legendary;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 100;
        this._physicalAttack = 1;
        this._physicalAttackMax = 8974;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "剣の中枢部に微細な円環状の無空間を形成している剣。理そのものを示すその剣は時間律、因果律、そして生命の根源を断ち切る性質を有する。物理攻撃１～８９７４\r\n" +
                            "【特殊効果】\r\n" +
                            "任意の行動を行うたび、防御、待機以外であれば、自分自身に【神の意志】が付与され累積カウンターが１つ乗る。累積カウンターの分だけ、【心】パラメタが１００上昇する。累積カウンターは最大99個まで乗る。\r\n" +
                            "【神の意志】が続く間、自分自身の対象の物理攻撃／物理防御／魔法攻撃／魔法防御／戦闘速度／戦闘反応／潜在能力が減少するBUFFがかけられていたとしても、減少効果は適用されなくなる。\r\n" +
                            "対象に物理攻撃もしくは魔法攻撃がヒットした時、対象に【神の契約】が付与された上で、【蘇生不可】および【ライフ回復不可】の効果を与える。本効果は対象が【蘇生不可】および【ライフ回復不可】に対する耐性を保持していたとしても適用される。\r\n" +
                            "【神の契約】が続く間、対象は【蘇生不可】【ライフ回復不可】を除去する事が出来ない。";
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
        this._description = "十七宝珠の一つ「厳正の宝珠」。王が見定めるは大いなる天空と静粛なる視点。アーティファクト枠に埋め込む事で、輝きは増す。力＋１０、心＋１０、【特殊効果】ターン経過毎に、スキルポイントが回復する。";
        this._strength = 5;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 10;
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
        this._description = "十七宝珠の一つ「慈悲の宝珠」。王が民に与えしは神々より降り注ぐ慈悲の視点。アーティファクト枠に埋め込む事で、輝きは増す。体＋５０、心＋５０、【特殊効果】ターン経過毎に、スキルポイントが回復する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 50;
        this._mind = 50;
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
        this._description = "十七宝珠の一つ「無双の宝珠」。王が民を守りし時、無双の構えにて闇を断ち斬らん。アーティファクト枠に埋め込む事で、輝きは増す。力＋１２０、技＋１２０、心＋１２０、物防率１０％【特殊効果】スキル行動を行った際、稀にそのスキル行動がもう一度発動する。";
        this._strength = 120;
        this._agility = 120;
        this._intelligence = 120;
        this._stamina = 0;
        this._mind = 120;
        this._amplifyPhysicalDefense = 1.10f;
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
        this._description = "炎授天使からの加護が得られる護符。炎に特化した耐性が付く。知＋３、心＋３、炎耐性＋２０％";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 3;
        this._stamina = 0;
        this._mind = 3;
        this._resistFirePercent = 0.20f;
        break;
        #endregion

    }

    SetupLimitValue();
  }


  protected void AdditionalDescription(Item.ItemTypes s_type)
  {
    this._itemType = s_type;
    if (s_type == Item.ItemTypes.Material_Equip)
    {
      this._description = this._description.Insert(0, Fix.DESCRIPTION_EQUIP_MATERIAL);
    }
    else if (s_type == Item.ItemTypes.Material_Food)
    {
      this._description = this._description.Insert(0, Fix.DESCRIPTION_FOOD_MATERIAL);
    }
    else if (s_type == Item.ItemTypes.Material_Potion)
    {
      this._description = this._description.Insert(0, Fix.DESCRIPTION_POTION_MATERIAL);
    }
    else if (s_type == Item.ItemTypes.Useless || s_type == Item.ItemTypes.None)
    {
      this._description = this._description.Insert(0, Fix.DESCRIPTION_SELL_ONLY);
    }
  }
  #endregion
}
