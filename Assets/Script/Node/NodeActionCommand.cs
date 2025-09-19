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
    else if (command_name == Fix.SMALL_GREEN_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_GREEN_POTION_1); }
    else if (command_name == Fix.NORMAL_GREEN_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_GREEN_POTION_2); }
    else if (command_name == Fix.LARGE_GREEN_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_GREEN_POTION_3); }
    else if (command_name == Fix.HUGE_GREEN_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_GREEN_POTION_4); }
    else if (command_name == Fix.HQ_GREEN_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_GREEN_POTION_5); }
    else if (command_name == Fix.THQ_GREEN_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_GREEN_POTION_6); }
    else if (command_name == Fix.PERFECT_GREEN_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_GREEN_POTION_7); }
    else if (command_name == Fix.PURE_CLEAN_WATER)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("PureCleanWater");
    }
    else if (command_name == Fix.PURE_SINSEISUI)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("PureSinseisui");
    }
    else if (command_name == Fix.PURE_VITALIRY_WATER)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("PureVitalityWater");
    }
    else if (command_name == Fix.POTION_RESIST_FIRE ||
             command_name == Fix.CURE_SEAL ||
             command_name == Fix.POTION_MAGIC_SEAL ||
             command_name == Fix.POTION_RESIST_PLUS ||
             command_name == Fix.TOTAL_HIYAKU_KASSEI ||
             command_name == Fix.TOTAL_HIYAKU_JOUSEI ||
             command_name == Fix.PATERMA_DISMAGIC_DRINK ||
             command_name == Fix.SOUKAI_DRINK_SS ||
             command_name == Fix.TUUKAI_DRINK_DD ||
             command_name == Fix.GOD_YORISHIRO_SOSEI ||
             command_name == Fix.OLDTREE_GUARDIAN_MARK ||
             command_name == Fix.TRADITIONAL_POTION_DATTOU ||
             command_name == Fix.TRADITIONAL_POTION_HEIGAN ||
             command_name == Fix.LEKS_MYSTICAL_POTION)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("CureSeal");
    }
    else if (command_name == Fix.ARCHETYPE_EIN_1)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("SYUTYU-DANZETSU");
    }
    else if (command_name == Fix.STRAIGHT_SMASH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STRAIGHT_SMASH);
    }
    else if (command_name == Fix.STANCE_OF_THE_BLADE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STANCE_OF_THE_BLADE);
    }
    else if (command_name == Fix.DOUBLE_SLASH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DOUBLE_SLASH);
    }
    else if (command_name == Fix.IRON_BUSTER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.IRON_BUSTER);
    }
    else if (command_name == Fix.RAGING_STORM_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.RAGING_STORM);
    }
    else if (command_name == Fix.STANCE_OF_THE_IAI_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STANCE_OF_THE_IAI);
    }
    else if (command_name == Fix.KINETIC_SMASH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.KINETIC_SMASH);
    }
    else if (command_name == Fix.TRUE_SIGHT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.TRUE_SIGHT);
    }
    else if (command_name == Fix.LEYLINE_SCHEMA_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.LEYLINE_SCHEMA);
    }
    else if (command_name == Fix.WORD_OF_POWER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.WORD_OF_POWER);
    }
    else if (command_name == Fix.WILL_AWAKENING_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.WILL_AWAKENING);
    }
    else if (command_name == Fix.SIGIL_OF_THE_FAITH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SIGIL_OF_THE_FAITH);
    }
    else if (command_name == Fix.STANCE_OF_THE_KOKOROE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STANCE_OF_THE_KOKOROE);
    }
    else if (command_name == Fix.SHIELD_BASH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SHIELD_BASH);
    }
    else if (command_name == Fix.STANCE_OF_THE_GUARD_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STANCE_OF_THE_GUARD);
    }
    else if (command_name == Fix.CONCUSSIVE_HIT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CONCUSSIVE_HIT);
    }
    else if (command_name == Fix.DOMINATION_FIELD_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DOMINATION_FIELD);
    }
    else if (command_name == Fix.HARDEST_PARRY_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.HARDEST_PARRY);
    }
    else if (command_name == Fix.ONE_IMMUNITY_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ONE_IMMUNITY);
    }
    else if (command_name == Fix.ICE_NEEDLE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ICE_NEEDLE);
    }
    else if (command_name == Fix.PURE_PURIFICATION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.PURE_PURIFICATION);
    }
    else if (command_name == Fix.BLUE_BULLET_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.BLUE_BULLET);
    }
    else if (command_name == Fix.FREEZING_CUBE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FREEZING_CUBE);
    }
    else if (command_name == Fix.FROST_LANCE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FROST_LANCE);
    }
    else if (command_name == Fix.WATER_PRESENCE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.WATER_PRESENCE);
    }
    else if (command_name == Fix.ABSOLUTE_ZERO_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ABSOLUTE_ZERO);
    }
    else if (command_name == Fix.SHADOW_BLAST_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SHADOW_BLAST);
    }
    else if (command_name == Fix.BLOOD_SIGN_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.BLOOD_SIGN);
    }
    else if (command_name == Fix.BLACK_CONTRACT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.BLACK_CONTRACT);
    }
    else if (command_name == Fix.CURSED_EVANGILE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CURSED_EVANGILE);
    }
    else if (command_name == Fix.CIRCLE_OF_THE_DESPAIR_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CIRCLE_OF_THE_DESPAIR);
    }
    else if (command_name == Fix.THE_DARK_INTENSITY_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.THE_DARK_INTENSITY);
    }
    else if (command_name == Fix.DEATH_SCYTHE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DEATH_SCYTHE);
    }
    else if (command_name == Fix.DISPEL_MAGIC_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DISPEL_MAGIC);
    }
    else if (command_name == Fix.FLASH_COUNTER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FLASH_COUNTER);
    }
    else if (command_name == Fix.DETACHMENT_FAULT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DETACHMENT_FAULT);
    }
    else if (command_name == Fix.FUTURE_VISION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FUTURE_VISION);
    }
    else if (command_name == Fix.FRESH_HEAL_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FRESH_HEAL);
    }
    else if (command_name == Fix.DIVINE_CIRCLE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DIVINE_CIRCLE);
    }
    else if (command_name == Fix.HOLY_BREATH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.HOLY_BREATH);
    }
    else if (command_name == Fix.ANGELIC_ECHO_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ANGELIC_ECHO);
    }
    else if (command_name == Fix.SHINING_HEAL_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SHINING_HEAL);
    }
    else if (command_name == Fix.VALKYRIE_BLADE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.VALKYRIE_BLADE);
    }
    else if (command_name == Fix.RESURRECTION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.RESURRECTION);
    }
    else if (command_name == Fix.HUNTER_SHOT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.HUNTER_SHOT);
    }
    else if (command_name == Fix.MULTIPLE_SHOT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.MULTIPLE_SHOT);
    }
    else if (command_name == Fix.EYE_OF_THE_ISSHIN_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.EYE_OF_THE_ISSHIN);
    }
    else if (command_name == Fix.PENETRATION_ARROW_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.PENETRATION_ARROW);
    }
    else if (command_name == Fix.PRECISION_STRIKE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.PRECISION_STRIKE);
    }
    else if (command_name == Fix.ETERNAL_CONCENTRATION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ETERNAL_CONCENTRATION);
    }
    else if (command_name == Fix.PIERCING_ARROW_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.PIERCING_ARROW);
    }
    else if (command_name == Fix.CIRCLE_OF_SERENITY_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CIRCLE_OF_SERENITY);
    }
    else if (command_name == Fix.LEG_STRIKE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.LEG_STRIKE);
    }
    else if (command_name == Fix.SPEED_STEP_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SPEED_STEP);
    }
    else if (command_name == Fix.BONE_CRUSH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.BONE_CRUSH);
    }
    else if (command_name == Fix.DEADLY_DRIVE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DEADLY_DRIVE);
    }
    else if (command_name == Fix.UNINTENTIONAL_HIT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.UNINTENTIONAL_HIT);
    }
    else if (command_name == Fix.STANCE_OF_MUIN_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STANCE_OF_MUIN);
    }
    else if (command_name == Fix.CARNAGE_RUSH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CARNAGE_RUSH);
    }
    else if (command_name == Fix.FIRE_BALL_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FIRE_BALL);
    }
    else if (command_name == Fix.FLAME_BLADE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FLAME_BLADE);
    }
    else if (command_name == Fix.METEOR_BULLET_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.METEOR_BULLET);
    }
    else if (command_name == Fix.VOLCANIC_BLAZE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.VOLCANIC_BLAZE);
    }
    else if (command_name == Fix.FLAME_STRIKE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FLAME_STRIKE);
    }
    else if (command_name == Fix.CIRCLE_OF_THE_IGNITE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CIRCLE_OF_THE_IGNITE);
    }
    else if (command_name == Fix.LAVA_ANNIHILATION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.LAVA_ANNIHILATION);
    }
    else if (command_name == Fix.FORTUNE_SPIRIT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FORTUNE_SPIRIT);
    }
    else if (command_name == Fix.VOICE_OF_VIGOR_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.VOICE_OF_VIGOR);
    }
    else if (command_name == Fix.EVERFLOW_MIND_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.EVERFLOW_MIND);
    }
    else if (command_name == Fix.ENERGY_BOLT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ENERGY_BOLT);
    }
    else if (command_name == Fix.SIGIL_OF_THE_PENDING_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SIGIL_OF_THE_PENDING);
    }
    else if (command_name == Fix.PHANTOM_OBORO_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.PHANTOM_OBORO);
    }
    else if (command_name == Fix.TRANSCENDENCE_REACHED_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.TRANSCENDENCE_REACHED);
    }
    else if (command_name == Fix.ORACLE_COMMAND_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ORACLE_COMMAND);
    }
    else if (command_name == Fix.SPIRITUAL_REST_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SPIRITUAL_REST);
    }
    else if (command_name == Fix.UNSEEN_AID_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.UNSEEN_AID);
    }
    else if (command_name == Fix.INNER_INSPIRATION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.INNER_INSPIRATION);
    }
    else if (command_name == Fix.ZERO_IMMUNITY_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ZERO_IMMUNITY);
    }
    else if (command_name == Fix.TIME_STOP_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.TIME_STOP);
    }
    else if (command_name == Fix.COUNTER_DISALLOW_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.COUNTER_DISALLOW);
    }
    else if (command_name == Fix.GALE_WIND_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.GALE_WIND);
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
    else if (command_name == Fix.COMMAND_RENGEKI)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.RENGEKI);
    }
    else if (command_name == Fix.COMMAND_PERFECT_PROPHECY)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.PERFECT_PROPHECY);
    }
    else if (command_name == Fix.COMMAND_HOLY_WISDOM)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.HOLY_WISDOM);
    }
    else if (command_name == Fix.COMMAND_ETERNAL_PRESENCE)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ETERNAL_PRESENCE);
    }
    else if (command_name == Fix.COMMAND_ULTIMATE_FLARE)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ULTIMATE_FLARE);
    }
    else if (command_name == Fix.COMMAND_BUTOH_ISSEN)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.BUTOH_ISSEN);
    }
    else if (command_name == Fix.COMMAND_GOD_SENSE)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.GOD_SENSE);
    }
    else if (command_name == Fix.COMMAND_TIME_JUMP)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.TIME_JUMP);
    }
    else if (command_name == Fix.COMMAND_STARSWORD_ZETSUKEN)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STARSWORD_ZETSUKEN);
    }
    else if (command_name == Fix.COMMAND_STARSWORD_REIKUU)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STARSWORD_REIKUU);
    }
    else if (command_name == Fix.COMMAND_STARSWORD_SEIEI)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STARSWORD_SEIEI);
    }
    else if (command_name == Fix.COMMAND_STARSWORD_RYOKUEI)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STARSWORD_RYOKUEI);
    }
    else if (command_name == Fix.COMMAND_STARSWORD_FINALITY)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STARSWORD_FINALITY);
    }
    else if (command_name == Fix.COMMAND_SHADOW_BRINGER)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SHADOW_BRINGER);
    }
    else if (command_name == Fix.COMMAND_SPHERE_OF_GLORY)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SPHERE_OF_GLORY);
    }
    else if (command_name == Fix.COMMAND_AURORA_PUNISHMENT)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AURORA_PUNISHMENT);
    }
    else if (command_name == Fix.COMMAND_INNOCENT_CIRCLE)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.INNOCENT_CIRCLE);
    }
    else if (command_name == Fix.COMMAND_ATOMIC_THE_INFINITY_NOVA)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ATOMIC_THE_INFINITY_NOVA);
    }
    else if (command_name == Fix.COMMAND_ABSOLUTE_PERFECTION)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ABSOLUTE_PERFECTION);
    }
    else if (command_name == Fix.COMMAND_ASTRAL_GATE)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ASTRAL_GATE);
    }
    else if (command_name == Fix.COMMAND_DOUBLE_STANCE)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DOUBLE_STANCE);
    }
    else if (command_name == Fix.COMMAND_DESTRUCTION_OF_TRUTH ||
             command_name == Fix.EFFECT_STACK_END)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DESTRUCTION_OF_TRUTH);
    }
    else if (command_name == Fix.COMMAND_CHAOTIC_SCHEMA)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CHAOTIC_SCHEMA);
    }
    else if (command_name == Fix.COMMAND_OATH_OF_SEFINE)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.OATH_OF_SEFINE);
    }
    else if (command_name == Fix.COMMAND_SPACETIME_INFLUENCE)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SPACETIME_INFLUENCE);
    }
    else
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(command_name);

      if (ActionButton.image.sprite == null)
      {
        ActionButton.image.sprite = Resources.Load<Sprite>(Fix.NORMAL_ATTACK);
        //ActionButton.image.sprite = null; // Resources.Load<Sprite>(Fix.STAY_2);
      }
    }
  }
}
