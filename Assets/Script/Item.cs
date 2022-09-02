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
    switch (item_name)
    {
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
        this._physicalAttack = 5;
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
        this._physicalAttack = 11;
        this._physicalAttackMax = 14;
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
        this._physicalAttack = 2;
        this._physicalAttackMax = 6;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 220;
        this._importantType = Important.None;
        this._description = "練習用の槍。実践ではあまり用いられず、訓練の時に使用する。物理攻撃力２～６";
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
        this._physicalAttackMax = 12;
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

      case Fix.ELVISH_BOW:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 11;
        this._physicalAttackMax = 17;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1150;
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
        this._physicalAttack = 6;
        this._physicalAttackMax = 11;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 240;
        this._importantType = Important.None;
        this._description = "練習用の斧。実践ではあまり用いられず、訓練の時に使用する。物理攻撃力６～１１";
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
        this._physicalAttack = 10;
        this._physicalAttackMax = 15;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "標準的な斧。一般的な冒険者にとっては安心して使える。物理攻撃力１０～１５";
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
        this._physicalAttack = 14;
        this._physicalAttackMax = 19;
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
        this._magicAttack = 5;
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
        this._magicAttack = 11;
        this._magicAttackMax = 14;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2000;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身のライフを回復する。";
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
        this._magicAttack = 14;
        this._magicAttackMax = 19;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2100;
        this._importantType = Important.None;
        this._description = "魔法攻撃がヒットした時、20%の確率で対象に【暗闇】のBUFFを付与する。";
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
        this._magicAttack = 2;
        this._magicAttackMax = 6;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 220;
        this._importantType = Important.None;
        this._description = "練習用の本。実践ではあまり用いられず、訓練の時に使用する。魔法攻撃力２～６";
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
        this._magicAttack = 5;
        this._magicAttackMax = 9;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 720;
        this._importantType = Important.None;
        this._description = "標準的な本。一般的な冒険者にとっては安心して使える。魔法攻撃力５～９";
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
        this._magicAttackMax = 12;
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
        this._magicAttack = 16;
        this._magicAttackMax = 23;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 2200;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身に【聖】属性からの魔法ダメージを増強するBUFFを付与する。";
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
        this._rarity = Rarity.Common;
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

      case Fix.BEGINNER_CROSS:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 2;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 200;
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
        this._description = "標準的な舞踏衣。一般的な冒険者にとっては安心して使える。物理防御力４";
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
        this._rarity = Rarity.Common;
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
        this._gold = 200;
        this._importantType = Important.None;
        this._description = "【売却専用品】\r\n　純黒色の立方体。使用済みマテリアルのため、使い道はない。";
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

      case Fix.SMART_SWORD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Sword;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 48;
        this._physicalAttackMax = 54;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた剣。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力４８～５４";
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
        this._physicalAttack = 56;
        this._physicalAttackMax = 62;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5750;
        this._importantType = Important.None;
        this._description = "切れ味が良く、振るう者にとって負担の少ない剣。軽さのわりに威力は大きい。物理攻撃力５６～６２";
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

      case Fix.SMART_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 51;
        this._physicalAttackMax = 58;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた槍。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力５１～５８";
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
        this._physicalAttack = 60;
        this._physicalAttackMax = 67;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6250;
        this._importantType = Important.None;
        this._description = "突きに行く構えから実際に繰り出されるまでの速度が非常に早く感じられる槍。物理攻撃力６０～６７";
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

      case Fix.SMART_BOW:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Twohand_Bow;
        this._gripType = GripTypes.TwoHand;
        this._battleAccuracy = 88;
        this._physicalAttack = 55;
        this._physicalAttackMax = 63;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた弓。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力５５～６３";
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
        this._battleAccuracy = 85;
        this._physicalAttack = 60;
        this._physicalAttackMax = 70;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 7000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた斧。戦闘に少々馴染んできた者が好んでこれを使用する。物理攻撃力６０～７０";
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
        this._battleAccuracy = 85;
        this._physicalAttack = 72;
        this._physicalAttackMax = 82;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 7250;
        this._importantType = Important.None;
        this._description = "力強く振り回した時、それに呼応する形で威力の出る斧。つかうためには少々の訓練が必要。物理攻撃力７２～８２";
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

      case Fix.SMART_ORB:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Orb;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 98;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 45;
        this._magicAttackMax = 50;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた水晶。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力４５～５０";
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
        this._magicAttack = 52;
        this._magicAttackMax = 57;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5250;
        this._importantType = Important.None;
        this._description = "一点集中する事を鍛えるために作られた水晶。";
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

      case Fix.SMART_ROD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Rod;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 95;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 48;
        this._magicAttackMax = 54;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5500;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた杖。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力４８～５４";
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
        this._magicAttack = 56;
        this._magicAttackMax = 62;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 5750;
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

      case Fix.SMART_BOOK:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Book;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 51;
        this._magicAttackMax = 58;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6000;
        this._importantType = Important.None;
        this._description = "標準よりも研ぎ澄まされた本。戦闘に少々馴染んできた者が好んでこれを使用する。魔法攻撃力５１～５８";
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
        this._magicAttack = 60;
        this._magicAttackMax = 67;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 6250;
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

      case Fix.SMART_SHIELD:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Shield;
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
        this._gold = 3200;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの盾。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力９";
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
        this._physicalDefense = 14;
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
        this._physicalDefense = 15;
        this._magicDefense = 0;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 3600;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの鎧。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力１５";
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
        this._physicalDefense = 20;
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
        this._physicalDefense = 10;
        this._magicDefense = 5;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4000;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りの舞踏衣。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力１０";
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

      case Fix.LETHER_CROSS:
        this._rarity = Rarity.Uncommon;
        this._itemType = ItemTypes.Middle_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 13;
        this._magicDefense = 7;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4200;
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

      case Fix.SMART_ROBE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Light_Armor;
        this._gripType = GripTypes.None;
        this._battleAccuracy = 0;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 5;
        this._magicDefense = 10;
        this._itemValue1 = 0;
        this._itemValue2 = 0;
        this._gold = 4400;
        this._importantType = Important.None;
        this._description = "標準よりもしっかりした造りのローブ。戦闘に少々馴染んできた者が好んでこれを使用する。物理防御力５、魔法防御力１０";
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
        this._physicalDefense = 7;
        this._magicDefense = 13;
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

      case Fix.RED_AMULET:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 10;
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

      case Fix.BLUE_AMULET:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
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

      case Fix.PURPLE_AMULET:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 10;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.GREEN_AMULET:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
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

      case Fix.YELLOW_AMULET:
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
        this._gold = 7500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
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

      case Fix.COPPERRING_TIGER:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 7;
        this._agility = 7;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COPPERRING_DORPHINE:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 7;
        this._agility = 0;
        this._intelligence = 7;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COPPERRING_HORSE:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 7;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 7;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COPPERRING_BEAR:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 7;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 7;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COPPERRING_HAYABUSA:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 7;
        this._intelligence = 7;
        this._stamina = 0;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COPPERRING_OCTOPUS:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 7;
        this._intelligence = 0;
        this._stamina = 7;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COPPERRING_RABBIT:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 7;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 7;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COPPERRING_SPIDER:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 7;
        this._stamina = 7;
        this._mind = 0;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COPPERRING_DEER:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 7;
        this._stamina = 0;
        this._mind = 7;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

      case Fix.COPPERRING_ELEPHANT:
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
        this._gold = 6500;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 7;
        this._mind = 7;
        this.CanbeSocket1 = false;
        this.CanbeSocket2 = false;
        this.CanbeSocket3 = false;
        this.CanbeSocket4 = false;
        this.CanbeSocket5 = false;
        break;

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

    }

    SetupLimitValue();
  }
  #endregion
}
