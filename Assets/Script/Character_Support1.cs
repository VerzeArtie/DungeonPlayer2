using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Character : MonoBehaviour
{
  public void Construction(string character_name)
  {
    this.name = character_name;
    this.FullName = character_name;
    this.BattleBackColor = Fix.COLOR_ENEMY_CHARA;
    this.BattleForeColor = Fix.COLORFORE_ENEMY_CHARA;
    
    List<string> list = new List<string>();
    switch (character_name)
    {
      #region "サルン洞窟前草原区域"
      case Fix.TINY_MANTIS:
      case Fix.TINY_MANTIS_JP:
        SetupParameter(15, 2, 1, 2, 3, 4, 16, 12);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HIKKAKI);
        this.CannotCritical = true;
        break;

      case Fix.GREEN_SLIME:
      case Fix.GREEN_SLIME_JP:
        SetupParameter(2, 2, 15, 2, 3, 8, 19, 14);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_GREEN_NENEKI);
        this.CannotCritical = true;
        break;

      case Fix.MANDRAGORA:
      case Fix.MANDRAGORA_JP:
        SetupParameter(2, 4, 18, 3, 3, 5, 21, 17);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_KANAKIRI);
        this.CannotCritical = true;
        break;

      case Fix.YOUNG_WOLF:
      case Fix.YOUNG_WOLF_JP:
        SetupParameter(17, 5, 2, 4, 3, 7, 23, 19);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_WILD_CLAW);
        this.CannotCritical = true;
        break;

      case Fix.WILD_ANT:
      case Fix.WILD_ANT_JP:
        SetupParameter(19, 4, 2, 6, 3, 2, 26, 22);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_KAMITSUKI);
        this.CannotCritical = true;
        break;

      case Fix.OLD_TREEFORK:
      case Fix.OLD_TREEFORK_JP:
        SetupParameter(2, 4, 20, 7, 4, 4, 28, 24);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_TREE_SONG);
        this.CannotCritical = true;
        break;

      case Fix.SUN_FLOWER:
      case Fix.SUN_FLOWER_JP:
        SetupParameter(2, 6, 25, 4, 4, 3, 32, 28);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SUN_FIRE);
        this.CannotCritical = true;
        break;

      case Fix.SOLID_BEETLE:
      case Fix.SOLID_BEETLE_JP:
        SetupParameter(28, 6, 2, 9, 4, 6, 35, 29);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_TOSSHIN);
        this.CannotCritical = true;
        break;

      case Fix.SILENT_LADYBUG:
      case Fix.SILENT_LADYBUG_JP:
        SetupParameter(2, 7, 27, 7, 4, 5, 37, 32);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_FEATHER_WING);
        this.CannotCritical = true;
        break;

      case Fix.NIMBLE_RABBIT:
      case Fix.NIMBLE_RABBIT_JP:
        SetupParameter(26, 9, 20, 8, 4, 1, 39, 34);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_DASH_KERI);
        this.CannotCritical = true;
        break;

      case Fix.ENTANGLED_VINE:
      case Fix.ENTANGLED_VINE_JP:
        SetupParameter(37, 11, 15, 16, 5, 3, 42, 36);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SUITSUKU_TSUTA);
        this.CannotCritical = true;
        break;

      case Fix.CREEPING_SPIDER:
      case Fix.CREEPING_SPIDER_JP:
        SetupParameter(34, 12, 27, 14, 5, 8, 44, 39);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SPIDER_NET);
        this.CannotCritical = true;
        break;

      case Fix.BLOOD_MOSS:
      case Fix.BLOOD_MOSS_JP:
        SetupParameter(12, 10, 39, 12, 5, 5, 48, 42);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_POISON_KOKE);
        this.CannotCritical = true;
        break;

      case Fix.KILLER_BEE:
      case Fix.KILLER_BEE_JP:
        SetupParameter(33, 18, 25, 12, 5, 9, 51, 45);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CONTINUOUS_ATTACK);
        // this.CannotCritical = true; // クリティカルあり
        break;

      case Fix.WONDER_SEED:
      case Fix.WONDER_SEED_JP:
        SetupParameter(26, 12, 37, 15, 5, 2, 54, 47);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_FIRE_EMISSION);
        this.CannotCritical = true;
        break;

      case Fix.DAUNTLESS_HORSE:
      case Fix.DAUNTLESS_HORSE_JP:
        SetupParameter(40, 15, 10, 20, 5, 1, 58, 52);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SUPER_TOSSHIN);
        this.CannotCritical = true;
        break;

      case Fix.SCREAMING_RAFFLESIA:
        SetupParameter(55, 20, 55, 150, 8, 0, 1000, 2000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_YOUEN_FIRE);
        list.Add(Fix.COMMAND_BLAZE_DANCE);
        list.Add(Fix.COMMAND_POISON_RINPUN);
        this.CannotCritical = false;
        break;
      #endregion

      #region "ゴラトラム洞窟"
      case Fix.DEBRIS_SOLDIER:
      case Fix.DEBRIS_SOLDIER_JP:
        SetupParameter(45, 12, 20, 25, 7, 5, 112, 65);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_GAREKI_TSUBUTE);
        this.CannotCritical = true;
        break;

      case Fix.MAGICAL_AUTOMATA:
      case Fix.MAGICAL_AUTOMATA_JP:
        SetupParameter(15, 13, 48, 21, 7, 8, 126, 72);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SHADOW_SPEAR);
        this.CannotCritical = true;
        break;

      case Fix.KILLER_MACHINE:
      case Fix.KILLER_MACHINE_JP:
        SetupParameter(49, 15, 16, 23, 7, 4, 137, 76);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_MIDARE_GIRI);
        this.CannotCritical = true;
        break;

      case Fix.STINKY_BAT:
      case Fix.STINKY_BAT_JP:
        SetupParameter(47, 16, 23, 20, 7, 7, 140, 78);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_STINKY_BREATH);
        this.CannotCritical = true;
        break;

      case Fix.ANTIQUE_MIRROR:
      case Fix.ANTIQUE_MIRROR_JP:
        SetupParameter(22, 14, 52, 24, 7, 6, 145, 81);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_MIRROR_SHIELD);
        this.CannotCritical = true;
        break;

      case Fix.MECH_HAND:
      case Fix.MECH_HAND_JP:
        SetupParameter(54, 17, 29, 38, 7, 6, 145, 86);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HAND_CANNON);
        this.CannotCritical = true;
        break;

      case Fix.ABSENCE_MOAI:
      case Fix.ABSENCE_MOAI_JP:
        SetupParameter(55, 13, 55, 50, 7, 2, 163, 99);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SAIMIN_DANCE);
        list.Add(Fix.COMMAND_TOSSHIN);
        this.CannotCritical = true;
        break;

      case Fix.ACID_SCORPION:
      case Fix.ACID_SCORPION_JP:
        SetupParameter(62, 20, 14, 43, 7, 3, 169, 101);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_POISON_NEEDLE);
        this.CannotCritical = true;
        break;

      case Fix.NEJIMAKI_KNIGHT:
      case Fix.NEJIMAKI_KNIGHT_JP:
        SetupParameter(59, 21, 28, 43, 7, 5, 174, 104);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CHARGE_LANCE);
        this.CannotCritical = true;
        break;

      case Fix.AIMING_SHOOTER:
      case Fix.AIMING_SHOOTER_JP:
        SetupParameter(67, 22, 25, 46, 7, 9, 178, 108);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SPIKE_SHOT);
        //this.CannotCritical = true; // クリティカルあり
        break;

      case Fix.CULT_BLACK_MAGICIAN:
      case Fix.CULT_BLACK_MAGICIAN_JP:
        SetupParameter(33, 20, 62, 45, 7, 3, 181, 111);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_JUBAKU_ON);
        this.CannotCritical = true;
        break;

      case Fix.STONE_GOLEM:
      case Fix.STONE_GOLEM_JP:
        SetupParameter(78, 24, 30, 56, 8, 1, 186, 112);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_ZINARI);
        this.CannotCritical = true;
        break;

      case Fix.JUNK_VULKAN:
      case Fix.JUNK_VULKAN_JP:
        SetupParameter(75, 28, 42, 50, 8, 8, 196, 117);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BOUHATSU);
        this.CannotCritical = true;
        break;

      case Fix.LIGHTNING_CLOUD:
      case Fix.LIGHTNING_CLOUD_JP:
        SetupParameter(30, 25, 75, 52, 8, 5, 201, 123);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_THUNDER_CLOUD);
        this.CannotCritical = true;
        break;

      case Fix.SILENT_GARGOYLE:
      case Fix.SILENT_GARGOYLE_JP:
        SetupParameter(75, 30, 55, 48, 8, 6, 205, 131);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SURUDOI_HIKKAKI);
        this.CannotCritical = true;
        break;

      case Fix.GATE_HOUND:
      case Fix.GATE_HOUND_JP:
        SetupParameter(66, 29, 15, 53, 8, 4, 207, 135);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_HAGESHII_KAMITSUKI);
        this.CannotCritical = true;
        break;

      case Fix.PLAY_FIRE_IMP:
      case Fix.PLAY_FIRE_IMP_JP:
        SetupParameter(32, 27, 72, 49, 8, 7, 208, 137);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_BOLT_FRAME);
        this.CannotCritical = true;
        break;

      case Fix.WALKING_TIME_BOMB:
      case Fix.WALKING_TIME_BOMB_JP:
        SetupParameter(70, 31, 70, 55, 8, 5, 215, 139);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_BOOOOMB);
        this.CannotCritical = true;
        break;

      case Fix.EARTH_ELEMENTAL:
      case Fix.EARTH_ELEMENTAL_JP:
        SetupParameter(55, 32, 82, 60, 8, 3, 217, 144);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_STONE_RAIN);
        this.CannotCritical = true;
        break;

      case Fix.DEATH_DRONE:
      case Fix.DEATH_DRONE_JP:
        SetupParameter(81, 36, 32, 58, 8, 1, 220, 150);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_TARGETTING_SHOT);
        // this.CannotCritical = true; // クリティカルあり
        break;

      case Fix.ASSULT_SCARECROW:
      case Fix.ASSULT_SCARECROW_JP:
        SetupParameter(86, 34, 37, 61, 8, 5, 224, 153);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_POWERED_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MAD_DOCTOR:
      case Fix.MAD_DOCTOR_JP:
        SetupParameter(35, 35, 80, 63, 8, 2, 229, 158);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_SUSPICIOUS_VIAL);
        this.CannotCritical = true;
        break;

      case Fix.MAGICAL_HAIL_GUN:
      case Fix.MAGICAL_HAIL_GUN_JP:
        SetupParameter(125, 55, 160, 360, 12, 0, 2500, 4000);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SPAAAARK);
        list.Add(Fix.COMMAND_SUPER_RANDOM_CANNON);
        list.Add(Fix.COMMAND_ELECTRO_RAILGUN);
        this.CannotCritical = false;
        break;
      #endregion

      #region "神秘の森"
      case Fix.CHARGED_BOAR:
      case Fix.CHARGED_BOAR_JP:
        SetupParameter(106, 50, 30, 115, 10, 8, 460, 280);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_SUPER_TOSSHIN);
        this.CannotCritical = true;
        break;

      case Fix.WOOD_ELF:
      case Fix.WOOD_ELF_JP:
        SetupParameter(95, 55, 102, 108, 10, 4, 476, 288);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_WILD_STORM);
        this.CannotCritical = true;
        break;

      case Fix.STINKED_SPORE:
      case Fix.STINKED_SPORE_JP:
        SetupParameter(65, 47, 98, 120, 10, 3, 491, 296);
        list.Add(Fix.MAGIC_ATTACK);
        list.Add(Fix.COMMAND_YOUKAIEKI);
        this.CannotCritical = true;
        this.TargetSelectType = Fix.TargetSelectType.Behind;
        break;

      case Fix.POISON_FLOG:
      case Fix.POISON_FLOG_JP:
        SetupParameter(101, 53, 71, 112, 10, 9, 512, 302);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_POISON_TONGUE);
        this.CannotCritical = true;
        break;

      case Fix.GIANT_SNAKE:
      case Fix.GIANT_SNAKE_JP:
        SetupParameter(109, 52, 68, 117, 10, 1, 527, 313);
        list.Add(Fix.NORMAL_ATTACK);
        list.Add(Fix.COMMAND_CONSTRICT);
        this.CannotCritical = true;
        break;
      #endregion


      case Fix.RUDE_WATCHDOG:
      case Fix.RUDE_WATCHDOG_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MYSTIC_DRYAD:
      case Fix.MYSTIC_DRYAD_JP:
        SetupParameter(35, 10, 60, 20, 5, 0, 80, 50);
        list.Add(Fix.COMMAND_POISON_RINPUN);
        list.Add(Fix.COMMAND_YOUEN_FIRE);
        list.Add(Fix.COMMAND_BLAZE_DANCE);
        this.CannotCritical = false;
        break;

      case Fix.SHOTGUN_HYUUI:
      case Fix.SHOTGUN_HYUUI_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.SPEEDY_FALCON:
      case Fix.SPEEDY_FALCON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.INNOCENT_FAIRY:
      case Fix.INNOCENT_FAIRY_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.CALM_STAG:
      case Fix.CALM_STAG_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SAVAGE_BEAR:
      case Fix.SAVAGE_BEAR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FOREST_ELEMENTAL:
      case Fix.FOREST_ELEMENTAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EXCITED_ELEPHANT:
      case Fix.EXCITED_ELEPHANT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLANSIS_KNIGHT:
      case Fix.FLANSIS_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.GATHERING_LAPTOR:
      case Fix.GATHERING_LAPTOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SYLPH_DANCER:
      case Fix.SYLPH_DANCER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THORN_WARRIOR:
      case Fix.THORN_WARRIOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TOWERING_ENT:
      case Fix.TOWERING_ENT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DISTURB_RHINO:
      case Fix.DISTURB_RHINO_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MIST_PYTHON:
      case Fix.MIST_PYTHON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MUDDLED_PLANT:
      case Fix.MUDDLED_PLANT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.POISON_MARY:
      case Fix.POISON_MARY_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLANSIS_OF_THE_FOREST_QUEEN:
      case Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.DAGGER_FISH:
      case Fix.DAGGER_FISH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLOATING_MANTA:
      case Fix.FLOATING_MANTA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SKYBLUE_BIRD:
      case Fix.SKYBLUE_BIRD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RAINBOW_CLIONE:
      case Fix.RAINBOW_CLIONE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ROLLING_MAGURO:
      case Fix.ROLLING_MAGURO_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LIMBER_SEAEAGLE:
      case Fix.LIMBER_SEAEAGLE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLUFFY_CORAL:
      case Fix.FLUFFY_CORAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BLACK_OCTOPUS:
      case Fix.BLACK_OCTOPUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STEAL_SQUID:
      case Fix.STEAL_SQUID_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_HAND_OF_KRAKEN:
      case Fix.THE_HAND_OF_KRAKEN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.PROUD_VIKING:
      case Fix.PROUD_VIKING_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GAN_GAME:
      case Fix.GAN_GAME_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.JUMPING_KAMASU:
      case Fix.JUMPING_KAMASU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WRECHED_ANEMONE:
      case Fix.WRECHED_ANEMONE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DEEPSEA_HAND:
      case Fix.DEEPSEA_HAND_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ASSULT_SERPENT:
      case Fix.ASSULT_SERPENT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ESCORT_HERMIT_CLUB:
      case Fix.ESCORT_HERMIT_CLUB_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GLUTTONY_COELACANTH:
      case Fix.GLUTTONY_COELACANTH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GIANT_SEA_SPIDER:
      case Fix.GIANT_SEA_SPIDER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SHELL_THE_SWORD_KNIGHT:
      case Fix.SHELL_THE_SWORD_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.MOGUL_MANTA:
      case Fix.MOGUL_MANTA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WEEPING_MIST:
      case Fix.WEEPING_MIST_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.AMBUSH_ANGLERFISH:
      case Fix.AMBUSH_ANGLERFISH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EMERALD_LOBSTER:
      case Fix.EMERALD_LOBSTER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BIGMOUSE_JOE:
      case Fix.BIGMOUSE_JOE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RAMPAGE_BIGSHARK:
      case Fix.RAMPAGE_BIGSHARK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STICKY_STARFISH:
      case Fix.STICKY_STARFISH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SEA_ELEMENTAL:
      case Fix.SEA_ELEMENTAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EDGED_HIGH_SHARK:
      case Fix.EDGED_HIGH_SHARK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GUARDIAN_ROYAL_NAGA:
      case Fix.GUARDIAN_ROYAL_NAGA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.THOUGHTFUL_NAUTILUS:
      case Fix.THOUGHTFUL_NAUTILUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FEROCIOUS_WHALE:
      case Fix.FEROCIOUS_WHALE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GHOST_SHIP:
      case Fix.GHOST_SHIP_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RECKLESS_WALRUS:
      case Fix.RECKLESS_WALRUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BEAUTY_SEA_LILY:
      case Fix.BEAUTY_SEA_LILY_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DEFENSIVE_DATSU:
      case Fix.DEFENSIVE_DATSU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SEA_STAR_KNIGHT:
      case Fix.SEA_STAR_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SEA_SONG_MARMAID:
      case Fix.SEA_SONG_MARMAID_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BRILLIANT_SEA_PRINCE:
      case Fix.BRILLIANT_SEA_PRINCE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.VELGAS_THE_KING_OF_SEA_STAR:
      case Fix.VELGAS_THE_KING_OF_SEA_STAR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.STONE_STATUE_SEIHITSU:
      case Fix.STONE_STATUE_SEIHITSU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;


      case Fix.DISTORTED_SENSOR:
      case Fix.DISTORTED_SENSOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_GALVADAZER:
      case Fix.THE_GALVADAZER_JP:
        SetupParameter(150, 120, 60, 420, 100, 10, 7500, 2000);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.SWIFT_EAGLE:
      case Fix.SWIFT_EAGLE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EASTERN_GOLEM:
      case Fix.EASTERN_GOLEM_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WESTERN_GOLEM:
      case Fix.WESTERN_GOLEM_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WIND_ELEMENTAL:
      case Fix.WIND_ELEMENTAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SKY_KNIGHT:
      case Fix.SKY_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_PURPLE_HIKARIGOKE:
      case Fix.THE_PURPLE_HIKARIGOKE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MYSTICAL_UNICORN:
      case Fix.MYSTICAL_UNICORN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TRIAL_HERMIT:
      case Fix.TRIAL_HERMIT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STORM_BIRDMAN:
      case Fix.STORM_BIRDMAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_BLUE_LAVA_EYE:
      case Fix.THE_BLUE_LAVA_EYE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.FLYING_CURTAIN:
      case Fix.FLYING_CURTAIN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LUMINOUS_HAWK:
      case Fix.LUMINOUS_HAWK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.AETHER_GUST:
      case Fix.AETHER_GUST_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WHIRLWIND_KITSUNE:
      case Fix.WHIRLWIND_KITSUNE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THUNDER_LION:
      case Fix.THUNDER_LION_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SAINT_PEGASUS:
      case Fix.SAINT_PEGASUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DREAM_WALKER:
      case Fix.DREAM_WALKER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.IVORY_STATUE:
      case Fix.IVORY_STATUE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STUBBORN_SAGE:
      case Fix.STUBBORN_SAGE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LIGHT_THUNDER_LANCEBOLTS:
      case Fix.LIGHT_THUNDER_LANCEBOLTS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.BOMB_BALLON:
      case Fix.BOMB_BALLON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.OBSERVANT_HERALD:
      case Fix.OBSERVANT_HERALD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TOWER_SCOUT:
      case Fix.TOWER_SCOUT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MIST_SALVAGER:
      case Fix.MIST_SALVAGER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WINGSPAN_RANGER:
      case Fix.WINGSPAN_RANGER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.HARDENED_GRIFFIN:
      case Fix.HARDENED_GRIFFIN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MAJESTIC_CLOUD:
      case Fix.MAJESTIC_CLOUD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.PRISMA_SPHERE:
      case Fix.PRISMA_SPHERE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.VEIL_FORTUNE_WIZARD:
      case Fix.VEIL_FORTUNE_WIZARD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_YODIRIAN:
      case Fix.THE_YODIRIAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 10, 7500, 2000);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.IMPERIAL_KNIGHT:
      case Fix.IMPERIAL_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.VENERABLE_WIZARD:
      case Fix.VENERABLE_WIZARD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.HOLLOW_SPECTOR:
      case Fix.HOLLOW_SPECTOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LIGHTNING_SPHERE:
      case Fix.LIGHTNING_SPHERE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DECEIVED_HUNTSMAN:
      case Fix.DECEIVED_HUNTSMAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MOVING_CANNON:
      case Fix.MOVING_CANNON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DHAL_GUARDIAN:
      case Fix.DHAL_GUARDIAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.PUPPET_MASTER:
      case Fix.PUPPET_MASTER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DANCING_BLADE:
      case Fix.DANCING_BLADE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MASCLEWARRIOR_HARDIL:
      case Fix.MASCLEWARRIOR_HARDIL_JP:
        SetupParameter(1, 1, 1, 1, 1, 10, 7500, 2000);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TRAPPED_DISK:
      case Fix.TRAPPED_DISK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WHISTLE_SENSOR:
      case Fix.WHISTLE_SENSOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DREAD_LANCER:
      case Fix.DREAD_LANCER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RAGE_TIGER:
      case Fix.RAGE_TIGER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.PEACEFUL_ANDANTINO:
      case Fix.PEACEFUL_ANDANTINO_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.POISONED_CHALICE:
      case Fix.POISONED_CHALICE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WISDOM_CENTAURUS:
      case Fix.WISDOM_CENTAURUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.UNKNOWN_FLOATING_BALL:
      case Fix.UNKNOWN_FLOATING_BALL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.AURORA_SPIRIT:
      case Fix.AURORA_SPIRIT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.HUGE_MAGICIAN_ZAGAN:
      case Fix.HUGE_MAGICIAN_ZAGAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.HELL_KERBEROS:
      case Fix.HELL_KERBEROS_JP:
        //SetupParameter(85, 50, 15, 300, 10, 10000, 3000, 2000);
        SetupParameter(1, 50, 15, 1, 10, 0, 3000, 1200);
        list.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

    }

    // debug
    //this.Strength = 1;
    //this.Intelligence = 1;
    // debug 

    this.MaxGain();
    this.CurrentActionCommand = list[0];
    this.ActionCommandMain = list[0];
    for (int ii = 0; ii < 10; ii++)
    {
      if (ii < list.Count)
      {
        if (ii == 1) { this.ActionCommand1 = list[ii]; }
        else if (ii == 2) { this.ActionCommand2 = list[ii]; }
        else if (ii == 3) { this.ActionCommand3 = list[ii]; }
        else if (ii == 4) { this.ActionCommand4 = list[ii]; }
        else if (ii == 5) { this.ActionCommand5 = list[ii]; }
        else if (ii == 6) { this.ActionCommand6 = list[ii]; }
        else if (ii == 7) { this.ActionCommand7 = list[ii]; }
        else if (ii == 8) { this.ActionCommand8 = list[ii]; }
        else if (ii == 9) { this.ActionCommand9 = list[ii]; }
      }
      else
      {
        if (ii == 1) { this.ActionCommand1 = Fix.STAY; }
        else if (ii == 2) { this.ActionCommand2 = Fix.STAY; }
        else if (ii == 3) { this.ActionCommand3 = Fix.STAY; }
        else if (ii == 4) { this.ActionCommand4 = Fix.STAY; }
        else if (ii == 5) { this.ActionCommand5 = Fix.STAY; }
        else if (ii == 6) { this.ActionCommand6 = Fix.STAY; }
        else if (ii == 7) { this.ActionCommand7 = Fix.STAY; }
        else if (ii == 8) { this.ActionCommand8 = Fix.STAY; }
        else if (ii == 9) { this.ActionCommand9 = Fix.STAY; }
      }
    }
    this.CurrentImmediateCommand = string.Empty;
  }

}
