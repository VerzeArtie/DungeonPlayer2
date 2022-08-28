﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class HomeTown : MotherBase
{
  private List<Item> GetShopItem(string area_name)
  {
    List<Item> shopList = new List<Item>();
    if (area_name == Fix.TOWN_ANSHET)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));
      shopList.Add(new Item(Fix.FINE_CLAW));
      shopList.Add(new Item(Fix.FINE_LANCE));
      shopList.Add(new Item(Fix.FINE_AXE));
      shopList.Add(new Item(Fix.FINE_BOW));
      shopList.Add(new Item(Fix.FINE_ORB));
      shopList.Add(new Item(Fix.FINE_BOOK));
      shopList.Add(new Item(Fix.FINE_ROD));
      shopList.Add(new Item(Fix.FINE_SHIELD));
      shopList.Add(new Item(Fix.FINE_ARMOR));
      shopList.Add(new Item(Fix.FINE_CROSS));
      shopList.Add(new Item(Fix.FINE_ROBE));
      shopList.Add(new Item(Fix.BLUE_WIZARD_HAT));
      shopList.Add(new Item(Fix.SWORD_OF_LIFE));
      shopList.Add(new Item(Fix.SMALL_RED_POTION));
      shopList.Add(new Item(Fix.SMALL_BLUE_POTION));
    }
    if (area_name == Fix.TOWN_FAZIL_CASTLE)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));
      shopList.Add(new Item(Fix.FINE_CLAW));
      shopList.Add(new Item(Fix.FINE_LANCE));
      shopList.Add(new Item(Fix.FINE_AXE));
      shopList.Add(new Item(Fix.FINE_BOW));
      shopList.Add(new Item(Fix.FINE_ORB));
      shopList.Add(new Item(Fix.FINE_BOOK));
      shopList.Add(new Item(Fix.FINE_ROD));
      shopList.Add(new Item(Fix.FINE_SHIELD));
      shopList.Add(new Item(Fix.FINE_ARMOR));
      shopList.Add(new Item(Fix.FINE_CROSS));
      shopList.Add(new Item(Fix.FINE_ROBE));
      shopList.Add(new Item(Fix.RED_PENDANT));
      shopList.Add(new Item(Fix.BLUE_PENDANT));
      shopList.Add(new Item(Fix.PURPLE_PENDANT));
      shopList.Add(new Item(Fix.GREEN_PENDANT));
      shopList.Add(new Item(Fix.YELLOW_PENDANT));
      shopList.Add(new Item(Fix.SWORD_OF_LIFE));
      shopList.Add(new Item(Fix.BLUE_WIZARD_HAT));
      shopList.Add(new Item(Fix.FLAME_HAND_KEEPER));
      shopList.Add(new Item(Fix.RED_PILLER_ORB));
      shopList.Add(new Item(Fix.MUIN_BOOK));
      shopList.Add(new Item(Fix.NORMAL_RED_POTION));
      shopList.Add(new Item(Fix.NORMAL_BLUE_POTION));

      //// todo
      //if (false)
      //{
      //  shopList.Add(new Item(Fix.FINE_LANCE));
      //  shopList.Add(new Item(Fix.FINE_AXE));
      //  shopList.Add(new Item(Fix.FINE_BOW));
      //  shopList.Add(new Item(Fix.FINE_ROD));
      //  shopList.Add(new Item(Fix.FINE_BOOK));
      //  //shopList.Add(new Item(Fix.BASTARD_SWORD));
      //  shopList.Add(new Item(Fix.AERO_BLADE));
      //  shopList.Add(new Item(Fix.GEAR_GENSEI));
      //  shopList.Add(new Item(Fix.MASTER_SWORD));
      //  shopList.Add(new Item(Fix.MASTER_SHIELD));
      //  shopList.Add(new Item(Fix.EDIL_BLACK_BLADE));
      //  shopList.Add(new Item(Fix.WHITE_PARGE_LANCE));
      //  shopList.Add(new Item(Fix.ICE_SPIRIT_LANCE));
      //}
    }
    else if (area_name == Fix.TOWN_COTUHSYE)
    {
      shopList.Add(new Item(Fix.SMART_SWORD));
      shopList.Add(new Item(Fix.SMART_CLAW));
      shopList.Add(new Item(Fix.SMART_LANCE));
      shopList.Add(new Item(Fix.SMART_AXE));
      shopList.Add(new Item(Fix.SMART_BOW));
      shopList.Add(new Item(Fix.SMART_ORB));
      shopList.Add(new Item(Fix.SMART_BOOK));
      shopList.Add(new Item(Fix.SMART_ROD));
      shopList.Add(new Item(Fix.SMART_SHIELD));
      shopList.Add(new Item(Fix.SMART_ARMOR));
      shopList.Add(new Item(Fix.SMART_CROSS));
      shopList.Add(new Item(Fix.RED_AMULET));
      shopList.Add(new Item(Fix.BLUE_AMULET));
      shopList.Add(new Item(Fix.PURPLE_AMULET));
      shopList.Add(new Item(Fix.GREEN_AMULET));
      shopList.Add(new Item(Fix.YELLOW_AMULET));
      shopList.Add(new Item(Fix.LARGE_RED_POTION));
      shopList.Add(new Item(Fix.LARGE_BLUE_POTION));
    }
    else if (area_name == Fix.TOWN_QVELTA_TOWN)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));
      shopList.Add(new Item(Fix.FINE_CLAW));
    }
    else if (area_name == Fix.TOWN_ARCANEDINE)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));

    }
    else if (area_name == Fix.TOWN_DALE)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));

    }
    else if (area_name == Fix.TOWN_ZELMAN)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));

    }
    return shopList;
  }

  public List<string> GetFoodMenu(string area_name)
  {
    List<string> foodList = new List<string>();
    if (area_name == Fix.TOWN_ANSHET)
    {
      foodList.Add(Fix.FOOD_BALANCE_SET);
      foodList.Add(Fix.FOOD_LARGE_GOHAN_SET);
      foodList.Add(Fix.FOOD_TSIKARA_UDON);
      foodList.Add(Fix.FOOD_ZUNOU_FLY_SET);
      foodList.Add(Fix.FOOD_SPEED_SOBA);
    }
    else if (area_name == Fix.TOWN_FAZIL_CASTLE)
    {
      foodList.Add(Fix.FOOD_KATUCARRY);
      foodList.Add(Fix.FOOD_OLIVE_AND_ONION);
      foodList.Add(Fix.FOOD_INAGO_AND_TAMAGO);
      foodList.Add(Fix.FOOD_USAGI);
      foodList.Add(Fix.FOOD_SANMA);
    }
    else if (area_name == Fix.TOWN_COTUHSYE)
    {
      foodList.Add(Fix.FOOD_FISH_GURATAN);
      foodList.Add(Fix.FOOD_SEA_TENPURA);
      foodList.Add(Fix.FOOD_TRUTH_YAMINABE_1);
      foodList.Add(Fix.FOOD_OSAKANA_ZINGISKAN);
      foodList.Add(Fix.FOOD_RED_HOT_SPAGHETTI);
    }
    return foodList;
  }
}
