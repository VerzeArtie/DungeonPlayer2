using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class Item
{
  public Item(string item_name)
  {
    this._itemName = item_name;
    this._stackValue = 1; // 必ず１つ存在する。
    switch (item_name)
    {
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
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "";
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
        this._physicalAttack = 5;
        this._physicalAttackMax = 7;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 860;
        this._importantType = Important.None;
        this._description = "";
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
        this._physicalAttack = 11;
        this._physicalAttackMax = 14;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
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
        this._gold = 2200;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で雷による追加ダメージを与える。";
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
        this._physicalAttackMax = 100;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 650;
        this._importantType = Important.None;
        this._description = "";
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
        this._gold = 900;
        this._importantType = Important.None;
        this._description = "";
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
        this._gold = 2100;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身のライフを回復する。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 2300;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で風による追加ダメージを与える。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 0;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 10;
        this._agility = 0;
        this._intelligence = 8;
        this._stamina = 0;
        this._mind = 0;
        break;

      case Fix.FINE_LANCE:
        this._rarity = Rarity.Common;
        this._itemType = ItemTypes.Onehand_Lance;
        this._gripType = GripTypes.OneHand;
        this._battleAccuracy = 92;
        this._physicalAttack = 5;
        this._physicalAttackMax = 9;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 720;
        this._importantType = Important.None;
        this._description = "";
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
        this._battleAccuracy = 92;
        this._physicalAttack = 8;
        this._physicalAttackMax = 12;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 1100;
        this._importantType = Important.None;
        this._description = "";
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
        this._battleAccuracy = 92;
        this._physicalAttack = 16;
        this._physicalAttackMax = 23;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
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
        this._battleAccuracy = 92;
        this._physicalAttack = 19;
        this._physicalAttackMax = 26;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 2400;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で氷による追加ダメージを与える。";
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
        this._battleAccuracy = 88;
        this._physicalAttack = 7;
        this._physicalAttackMax = 13;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 800;
        this._importantType = Important.None;
        this._description = "";
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
        this._battleAccuracy = 88;
        this._physicalAttack = 11;
        this._physicalAttackMax = 17;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 1150;
        this._importantType = Important.None;
        this._description = "";
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
        this._battleAccuracy = 88;
        this._physicalAttack = 18;
        this._physicalAttackMax = 27;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 2500;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした時、20%の確率で土による追加ダメージを与える。";
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
        this._battleAccuracy = 88;
        this._physicalAttack = 20;
        this._physicalAttackMax = 29;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 2800;
        this._importantType = Important.None;
        this._description = "物理攻撃がヒットした後、対象の物理防御を－２する。";
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
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "";
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
        this._magicAttack = 5;
        this._magicAttackMax = 7;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 860;
        this._importantType = Important.None;
        this._description = "";
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
        this._magicAttack = 11;
        this._magicAttackMax = 14;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 2000;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身のライフを回復する。";
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
        this._gold = 2200;
        this._importantType = Important.None;
        this._description = "魔法攻撃がヒットした時、20%の確率で炎による追加ダメージを与える。";
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
        this._gold = 650;
        this._importantType = Important.None;
        this._description = "";
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
        this._gold = 900;
        this._importantType = Important.None;
        this._description = "";
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
        this._magicAttack = 14;
        this._magicAttackMax = 19;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 2100;
        this._importantType = Important.None;
        this._description = "魔法攻撃がヒットした時、20%の確率で対象に【暗闇】のBUFFを付与する。";
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
        this._gold = 2300;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身に【闇】属性からの魔法ダメージを増強するBUFFを付与する。";
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
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 5;
        this._magicAttackMax = 9;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 720;
        this._importantType = Important.None;
        this._description = "";
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
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 8;
        this._magicAttackMax = 12;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 1100;
        this._importantType = Important.None;
        this._description = "";
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
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 16;
        this._magicAttackMax = 23;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 2200;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、自分自身に【聖】属性からの魔法ダメージを増強するBUFFを付与する。";
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
        this._battleAccuracy = 92;
        this._physicalAttack = 0;
        this._physicalAttackMax = 0;
        this._magicAttack = 19;
        this._magicAttackMax = 26;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 2400;
        this._importantType = Important.None;
        this._description = "魔法攻撃がヒットした後、自分自身の物理攻撃を＋５する。";
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
        this._battleAccuracy = 85;
        this._physicalAttack = 10;
        this._physicalAttackMax = 15;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "";
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
        this._battleAccuracy = 85;
        this._physicalAttack = 14;
        this._physicalAttackMax = 19;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 1500;
        this._importantType = Important.None;
        this._description = "";
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
        this._battleAccuracy = 85;
        this._physicalAttack = 26;
        this._physicalAttackMax = 31;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 3000;
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
        this._battleAccuracy = 85;
        this._physicalAttack = 29;
        this._physicalAttackMax = 34;
        this._magicAttack = 0;
        this._magicAttackMax = 0;
        this._physicalDefense = 0;
        this._magicDefense = 0;
        this._gold = 3300;
        this._importantType = Important.None;
        this._description = "アクションコマンドで使用した場合、物理攻撃に関するコマンドの命中率が100%になるBUFFを付与する。";
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
        this._gold = 450;
        this._importantType = Important.None;
        this._description = "";
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
        this._gold = 1020;
        this._importantType = Important.None;
        this._description = "";
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
        this._gold = 2500;
        this._importantType = Important.None;
        this._description = "魔法攻撃を防御姿勢で受けた時、その魔法属性が「炎」の場合はダメージを半分に軽減する。";
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
        this._gold = 500;
        this._importantType = Important.None;
        this._description = "";
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
        this._magicDefense = 0;
        this._gold = 400;
        this._importantType = Important.None;
        this._description = "";
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
        this._physicalDefense = 1;
        this._magicDefense = 3;
        this._gold = 700;
        this._importantType = Important.None;
        this._description = "";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
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
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "軽快なシューズ。これを履いた瞬間から、身体全体が軽くなった様な感覚を得ることができる。";
        this._strength = 0;
        this._agility = 2;
        this._intelligence = 1;
        this._stamina = 0;
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
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "控え目なサイズのイヤリング。身に着けているとほのかに安定感が生まれてくる。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 1;
        this._stamina = 0;
        this._mind = 2;
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
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "力が湧いてくるバンダナ。しっかりとした結び目がやる気を引き立たせてくれる。";
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
        this._gold = 550;
        this._importantType = Important.None;
        this._description = "紺碧色の可愛らしいチョーカー。装着している者の精神を向上させてくれる。";
        this._strength = 1;
        this._agility = 0;
        this._intelligence = 2;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "赤色のペンダント。僅かな【力】を感じ取る事が出来る。";
        this._strength = 4;
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
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "青色のペンダント。僅かな【技】を感じ取る事が出来る。";
        this._strength = 0;
        this._agility = 4;
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
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "紫色のペンダント。僅かな【知】を感じ取る事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 4;
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
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "緑色のペンダント。僅かな【体】を感じ取る事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 4;
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
        this._gold = 1200;
        this._importantType = Important.None;
        this._description = "黄色のペンダント。僅かな【心】を感じ取る事が出来る。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 4;
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
        this._gold = 2500;
        this._importantType = Important.None;
        this._description = "装着者の周囲に炎のオーラが出現する。【炎】属性からの魔法ダメージを軽減し、かつ、【炎】属性による魔法ダメージを増強する。";
        this._strength = 5;
        this._agility = 2;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
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
        this._gold = 0;
        this._importantType = Important.Precious;
        this._description = "アーサリウム工場跡地で採取した鉱石。薄汚れた色をしているが、中身の強度は失われておらず、再利用することが出来そうだ。";
        this._strength = 0;
        this._agility = 0;
        this._intelligence = 0;
        this._stamina = 0;
        this._mind = 0;
        break;

    }
  }
}
