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
    else if (command_name == Fix.STANCE_OF_THE_BLADE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STANCE_OF_THE_BLADE);
    }
    else if (command_name == Fix.DOUBLE_SLASH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DOUBLE_SLASH);
    }
    else if (command_name == Fix.IRON_BASTER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.IRON_BASTER);
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
    else if (command_name == Fix.LAYLINE_SCHEMA_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.LAYLINE_SCHEMA);
    }
    else if (command_name == Fix.WORD_OF_POWER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.WORD_OF_POWER);
    }
    else if (command_name == Fix.WILL_AWAKENING_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.WILL_AWAKENING);
    }
    else if (command_name == Fix.MIND_FORCE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.MIND_FORCE);
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
    else if (command_name == Fix.WILD_SWING_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.WILD_SWING);
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
    else if (command_name == Fix.CURSED_EVANGEL_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CURSED_EVANGEL);
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
    else if (command_name == Fix.MUTE_IMPULSE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.MUTE_IMPULSE);
    }
    else if (command_name == Fix.DETACHMENT_FAULT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DETACHMENT_FAULT);
    }
    else if (command_name == Fix.OATH_OF_AEGIS_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.OATH_OF_AEGIS);
    }
    else if (command_name == Fix.FUTURE_VISION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FUTURE_VISION);
    }
    else if (command_name == Fix.ESSENCE_OVERFLOW_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ESSENCE_OVERFLOW);
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
    else if (command_name == Fix.AURA_OF_POWER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AURA_OF_POWER);
    }
    else if (command_name == Fix.SKY_SHIELD_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SKY_SHIELD);
    }
    else if (command_name == Fix.AETHER_DRIVE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AETHER_DRIVE);
    }
    else if (command_name == Fix.CIRCLE_OF_THE_VIGOR_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CIRCLE_OF_THE_VIGOR);
    }
    else if (command_name == Fix.REVOLUTION_AURA_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.REVOLUTION_AURA);
    }
    else if (command_name == Fix.BRILLIANT_FORM_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.BRILLIANT_FORM);
    }
    else if (command_name == Fix.AUSTERITY_MATRIX_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AUSTERITY_MATRIX);
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

    else if (command_name == Fix.HEART_OF_LIFE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.HEART_OF_LIFE);
    }
    else if (command_name == Fix.FORTUNE_SPIRIT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.FORTUNE_SPIRIT);
    }
    else if (command_name == Fix.VOICE_OF_VIGOR_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.VOICE_OF_VIGOR);
    }
    else if (command_name == Fix.AURA_BURN_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AURA_BURN);
    }
    else if (command_name == Fix.EVERFLOW_MIND_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.EVERFLOW_MIND);
    }
    else if (command_name == Fix.SOUL_SHOUT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SOUL_SHOUT);
    }
    else if (command_name == Fix.OVERWHELMING_DESTINY_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.OVERWHELMING_DESTINY);
    }
    else if (command_name == Fix.ENERGY_BOLT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ENERGY_BOLT);
    }
    else if (command_name == Fix.IDEOLOGY_OF_SOPHISTICATION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.IDEOLOGY_OF_SOPHISTICATION);
    }
    else if (command_name == Fix.SIGIL_OF_THE_PENDING_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SIGIL_OF_THE_PENDING);
    }
    else if (command_name == Fix.PHANTOM_OBORO_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.PHANTOM_OBORO);
    }
    else if (command_name == Fix.SIGIL_OF_THE_HOMURA_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SIGIL_OF_THE_HOMURA);
    }
    else if (command_name == Fix.WORD_OF_PROPHECY_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.WORD_OF_PROPHECY);
    }
    else if (command_name == Fix.TRANSCENDENCE_REACHED_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.TRANSCENDENCE_REACHED);
    }
    else if (command_name == Fix.ROCK_SLAM_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ROCK_SLAM);
    }
    else if (command_name == Fix.SOLID_WALL_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SOLID_WALL);
    }
    else if (command_name == Fix.LAND_SHATTER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.LAND_SHATTER);
    }
    else if (command_name == Fix.SAND_BURST_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SAND_BURST);
    }
    else if (command_name == Fix.PETRIFICATION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.PETRIFICATION);
    }
    else if (command_name == Fix.LIFE_GRACE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.LIFE_GRACE);
    }
    else if (command_name == Fix.EARTH_QUAKE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.EARTH_QUAKE);
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
    else if (command_name == Fix.EXACT_TIME_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.EXACT_TIME);
    }
    else if (command_name == Fix.INNER_INSPIRATION_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.INNER_INSPIRATION);
    }
    else if (command_name == Fix.ZERO_IMMUNITY_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ZERO_IMMUNITY);
    }
    else if (command_name == Fix.TIME_SKIP_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.TIME_SKIP);
    }
    else if (command_name == Fix.VENOM_SLASH_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.VENOM_SLASH);
    }
    else if (command_name == Fix.INVISIBLE_BIND_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.INVISIBLE_BIND);
    }
    else if (command_name == Fix.IRREGULAR_STEP_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.IRREGULAR_STEP);
    }
    else if (command_name == Fix.ASSASSINATION_HIT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ASSASSINATION_HIT);
    }
    else if (command_name == Fix.COUNTER_DISALLOW_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.COUNTER_DISALLOW);
    }
    else if (command_name == Fix.DIRTY_WISDOM_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DIRTY_WISDOM);
    }
    else if (command_name == Fix.AMBIDEXTERITY_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AMBIDEXTERITY);
    }
    else if (command_name == Fix.AIR_CUTTER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AIR_CUTTER);
    }
    else if (command_name == Fix.STORM_ARMOR_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STORM_ARMOR);
    }
    else if (command_name == Fix.SONIC_PULSE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.SONIC_PULSE);
    }
    else if (command_name == Fix.GALE_WIND_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.GALE_WIND);
    }
    else if (command_name == Fix.ERRATIC_THUNDER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ERRATIC_THUNDER);
    }
    else if (command_name == Fix.CYCLONE_FIELD_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.CYCLONE_FIELD);
    }
    else if (command_name == Fix.LIGHTNING_SQUALL_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.LIGHTNING_SQUALL);
    }
    else if (command_name == Fix.DARK_AURA_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DARK_AURA);
    }
    else if (command_name == Fix.STANCE_OF_THE_SHADE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STANCE_OF_THE_SHADE);
    }
    else if (command_name == Fix.KILLING_WAVE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.KILLING_WAVE);
    }
    else if (command_name == Fix.LEVEL_EATER_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.LEVEL_EATER);
    }
    else if (command_name == Fix.ABYSS_EYE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.ABYSS_EYE);
    }
    else if (command_name == Fix.AVENGER_PROMISE_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.AVENGER_PROMISE);
    }
    else if (command_name == Fix.DEMON_CONTRACT_JP + "強化")
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(Fix.DEMON_CONTRACT);
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

      if (ActionButton.image.sprite == null)
      {
        ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STAY_2);
      }
    }
  }
}
