//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public partial class Item
//{

//  public Item(string item_name)
//  {
//    this._itemName = item_name;
//    this._stackValue = 1; // 必ず１つ存在する。

//    switch (item_name)
//    {
//      case Fix.FINE_SWORD:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Onehand_Sword;
//        this._gripType = GripTypes.OneHand;
//        this._description = "標準的な剣。";
//        this._physicalAttack = 6;
//        this._gold = 501;
//        break;

//      case Fix.FINE_ROD:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Onehand_Rod;
//        this._gripType = GripTypes.OneHand;
//        this._description = "標準的な杖。";
//        this._magicAttack = 6;
//        this._gold = 502;
//        break;

//      case Fix.FINE_LANCE:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Onehand_Lance;
//        this._gripType = GripTypes.OneHand;
//        this._description = "標準的な槍。";
//        this._physicalAttack = 6;
//        this._gold = 503;
//        break;

//      case Fix.FINE_AXE:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Onehand_Axe;
//        this._gripType = GripTypes.TwoHand;
//        this._description = "標準的な斧。";
//        this._physicalAttack = 10;
//        this._gold = 504;
//        break;

//      case Fix.FINE_ORB:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Onehand_Orb;
//        this._gripType = GripTypes.OneHand;
//        this._description = "標準的なオーブ。";
//        this._magicAttack = 6;
//        this._gold = 505;
//        break;

//      case Fix.FINE_CLAW:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Onehand_Claw;
//        this._gripType = GripTypes.OneHand;
//        this._description = "標準的な爪。";
//        this._physicalAttack = 6;
//        this._gold = 506;
//        break;

//      case Fix.FINE_BOOK:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Onehand_Book;
//        this._gripType = GripTypes.OneHand;
//        this._description = "標準的な本。";
//        this._magicAttack = 6;
//        this._gold = 507;
//        break;

//      case Fix.FINE_BOW:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Twohand_Bow;
//        this._gripType = GripTypes.TwoHand;
//        this._description = "標準的な弓。";
//        this._physicalAttack = 10;
//        this._gold = 1201;
//        break;

//      case Fix.BASTARD_SWORD:
//        this._rarity = Rarity.Uncommon;
//        this._itemType = ItemTypes.Twohand_Sword;
//        this._gripType = GripTypes.TwoHand;
//        this._description = "重たいが、使い慣れれば大きく振り回せる大剣。";
//        this._physicalAttack = 15;
//        this._gold = 1202;
//        break;

//      case Fix.FINE_SHIELD:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Shield;
//        this._description = "標準的な盾。";
//        this._physicalDefense = 3;
//        this._gold = 750;
//        break;

//      case Fix.FINE_ARMOR:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Heavy_Armor;
//        this._description = "標準的な鎧。";
//        this._physicalDefense = 4;
//        this._gold = 401;
//        break;

//      case Fix.FINE_CROSS:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Middle_Armor;
//        this._description = "標準的な舞踏着。";
//        this._physicalDefense = 2;
//        this._magicDefense = 2;
//        this._gold = 402;
//        break;

//      case Fix.FINE_ROBE:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Light_Armor;
//        this._description = "標準的なローブ。";
//        this._magicDefense = 4;
//        this._gold = 403;
//        break;

//      case Fix.RED_PENDANT:
//        this._rarity = Rarity.Uncommon;
//        this._itemType = ItemTypes.Accessory;
//        this._description = "赤色のペンダント。僅かな【力】を感じ取る事が出来る。";
//        this._strength = 3;
//        this._gold = 801;
//        break;

//      case Fix.BLUE_PENDANT:
//        this._rarity = Rarity.Uncommon;
//        this._itemType = ItemTypes.Accessory;
//        this._description = "青色のペンダント。僅かな【技】を感じ取る事が出来る。";
//        this._agility = 3;
//        this._gold = 802;
//        break;

//      case Fix.PURPLE_PENDANT:
//        this._rarity = Rarity.Uncommon;
//        this._itemType = ItemTypes.Accessory;
//        this._description = "紫色のペンダント。僅かな【知】を感じ取る事が出来る。";
//        this._intelligence = 3;
//        this._gold = 803;
//        break;

//      case Fix.GREEN_PENDANT:
//        this._rarity = Rarity.Uncommon;
//        this._itemType = ItemTypes.Accessory;
//        this._description = "緑色のペンダント。僅かな【体】を感じ取る事が出来る。";
//        this._stamina = 3;
//        this._gold = 804;
//        break;

//      case Fix.YELLOW_PENDANT:
//        this._rarity = Rarity.Uncommon;
//        this._itemType = ItemTypes.Accessory;
//        this._description = "黄色のペンダント。僅かな【心】を感じ取る事が出来る。";
//        this._mind = 3;
//        this._gold = 805;
//        break;

//      case Fix.GEAR_GENSEI:
//        this._rarity = Rarity.Epic;
//        this._itemType = ItemTypes.Artifact;
//        this._description = "ファージル宮殿に保管されている【百八の宝珠】シリーズの一つ【厳正】。持っている者に厳格なる心を与える。";
//        this._potential = 1;
//        this._gold = 10000;
//        break;

//      case Fix.AERO_BLADE:
//        this._rarity = Rarity.Rare;
//        this._itemType = ItemTypes.Onehand_Sword;
//        this._gripType = GripTypes.OneHand;
//        this._description = "疾駆の振りで、一癖ある切り方が可能なブレード。【特殊能力：有】";
//        this._physicalAttack = 15;
//        this._gold = 4600;
//        break;

//      case Fix.MASTER_SWORD:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Onehand_Sword;
//        this._gripType = GripTypes.OneHand;
//        this._description = "マスターレベルの剣。";
//        this._physicalAttack = 22;
//        this._gold = 70000;
//        break;

//      case Fix.MASTER_SHIELD:
//        this._rarity = Rarity.Common;
//        this._itemType = ItemTypes.Shield;
//        this._description = "マスターレベルの盾。";
//        this._physicalDefense = 10;
//        this._gold = 70000;
//        break;

//      case Fix.EDIL_BLACK_BLADE:
//        this._rarity = Rarity.Epic;
//        this._itemType = ItemTypes.Onehand_Sword;
//        this._gripType = GripTypes.OneHand;
//        this._description = "古代賢者【エディル】が使用していた伝説の剣。";
//        this._physicalAttack = 56;
//        this._magicAttack = 37;
//        this._strength = 10;
//        this._agility = 7;
//        this._intelligence = 8;
//        this._stamina = 5;
//        this._mind = 2;
//        this._gold = 300000;
//        break;

//      case Fix.SMALL_RED_POTION:
//        this._itemType = ItemTypes.Potion;
//        this._description = "標準的な赤いポーション。";
//        this._lifeGain = 60;
//        this._gold = 300;
//        break;
//    }
//  }
//}
