using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeActionCommand : MonoBehaviour
{
  public Image BackColor;
  public string CommandName;
  public string OwnerName;
  public Button ActionButton;

  public void ApplyImageIcon(string command_name)
  {
    // todo
    if (command_name == Fix.SMALL_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_1); }
    else if (command_name == Fix.NORMAL_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_2); }
    else if (command_name == Fix.LARGE_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_3); }
    else if (command_name == Fix.HUGE_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_4); }
    else if (command_name == Fix.HQ_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_5); }
    else if (command_name == Fix.THQ_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_6); }
    else if (command_name == Fix.PERFECT_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_7); }
    else if (command_name == Fix.SMALL_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_1); }
    else if (command_name == Fix.NORMAL_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_2); }
    else if (command_name == Fix.LARGE_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_3); }
    else if (command_name == Fix.HUGE_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_4); }
    else if (command_name == Fix.HQ_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_5); }
    else if (command_name == Fix.THQ_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_6); }
    else if (command_name == Fix.PERFECT_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_7); }
    else if (command_name == Fix.PURE_CLEAN_WATER)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("PureCleanWater");
    }
    else if (command_name == Fix.ARCHETYPE_EIN_1)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("SYUTYU-DANZETSU");
    }
    else if (command_name == Fix.STRAIGHT_SMASH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STRAIGHT_SMASH);
    }
    else if (command_name == Fix.TRUE_SIGHT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.TRUE_SIGHT);
    }
    else if (command_name == Fix.SHIELD_BASH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SHIELD_BASH);
    }
    else if (command_name == Fix.ICE_NEEDLE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ICE_NEEDLE);
    }
    else if (command_name == Fix.SHADOW_BLAST_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SHADOW_BLAST);
    }
    else if (command_name == Fix.DISPEL_MAGIC_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DISPEL_MAGIC);
    }
    else if (command_name == Fix.FRESH_HEAL_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FRESH_HEAL);
    }
    else if (command_name == Fix.HUNTER_SHOT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.HUNTER_SHOT);
    }
    else if (command_name == Fix.AURA_OF_POWER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AURA_OF_POWER);
    }
    else if (command_name == Fix.LEG_STRIKE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.LEG_STRIKE);
    }
    else if (command_name == Fix.FIRE_BALL_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FIRE_BALL);
    }
    else if (command_name == Fix.HEART_OF_LIFE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.HEART_OF_LIFE);
    }
    else if (command_name == Fix.ENERGY_BOLT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ENERGY_BOLT);
    }
    else if (command_name == Fix.ROCK_SLAM_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ROCK_SLAM);
    }
    else if (command_name == Fix.ORACLE_COMMAND_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ORACLE_COMMAND);
    }
    else if (command_name == Fix.VENOM_SLASH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.VENOM_SLASH);
    }
    else if (command_name == Fix.AIR_CUTTER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AIR_CUTTER);
    }
    else if (command_name == Fix.DARK_AURA_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DARK_AURA);
    }
    else if (command_name == Fix.SWORD_TRAINING)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("Training_Sword");
    }
    else if (command_name == Fix.LANCE_TRAINING)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("Training_Lance");
    }
    else if (command_name == Fix.AXE_TRAINING)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("Training_Axe");
    }
    else if (command_name == Fix.CLAW_TRAINING)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("Training_Claw");
    }
    else if (command_name == Fix.ROD_TRAINING)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("Training_Rod");
    }
    else if (command_name == Fix.BOOK_TRAINING)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("Training_Book");
    }
    else if (command_name == Fix.ORB_TRAINING)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("Training_Orb");
    }
    else if (command_name == Fix.BOW_TRAINING)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("Training_Bow");
    }
    else if (command_name == Fix.SHIELD_TRAINING)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("Training_Shield");
    }
    else
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(command_name);
    }
  }
}
