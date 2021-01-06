using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public partial class Item
{
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
    Normal,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
  }

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

  protected int _limitValue = Fix.MAX_ITEM_STACK_SIZE; // オブジェクトがスタックできる最大数
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

      if (this._rarity == Item.Rarity.Normal)
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

      if (this._rarity == Item.Rarity.Normal)
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

}
