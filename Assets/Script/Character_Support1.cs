using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Character : MonoBehaviour
{
  public bool Decision = false; // アクションコマンドを決定したかどうかを示すフラグ
  public bool CannotCritical = false; // 雑魚キャラレベルはクリティカルなし

  protected int _gold = 0;
  public int Gold
  {
    set
    {
      if (value <= 0)
      {
        value = 0;
      }
      _gold = value;
    }
    get
    {
      return _gold;
    }
  }

  public void Construction(string character_name)
  {
    this.name = character_name;
    this.FullName = character_name;
    this.BattleBackColor = Fix.COLOR_ENEMY_CHARA;
    this.BattleForeColor = Fix.COLORFORE_ENEMY_CHARA;

    switch (character_name)
    {
      case Fix.TINY_MANTIS:
      case Fix.TINY_MANTIS_JP:
        SetupParameter(10, 2, 1, 2, 3, 4, 16, 12);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_HIKKAKI);
        this.CannotCritical = true;
        break;

      case Fix.GREEN_SLIME:
      case Fix.GREEN_SLIME_JP:
        SetupParameter(2, 2, 12, 2, 3, 8, 19, 14);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_GREEN_NENEKI);
        this.CannotCritical = true;
        break;

      case Fix.MANDRAGORA:
      case Fix.MANDRAGORA_JP:
        SetupParameter(2, 4, 16, 3, 3, 5, 21, 17);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_KANAKIRI);
        this.CannotCritical = true;
        break;

      case Fix.YOUNG_WOLF:
      case Fix.YOUNG_WOLF_JP:
        SetupParameter(19, 5, 2, 4, 3, 7, 23, 19);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_WILD_CLAW);
        this.CannotCritical = true;
        break;

      case Fix.WILD_ANT:
      case Fix.WILD_ANT_JP:
        SetupParameter(22, 4, 2, 6, 3, 2, 26, 22);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_KAMITSUKI);
        this.CannotCritical = true;
        break;

      case Fix.OLD_TREEFORK:
      case Fix.OLD_TREEFORK_JP:
        SetupParameter(2, 4, 30, 7, 4, 4, 28, 24);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_TREE_SONG);
        this.CannotCritical = true;
        break;

      case Fix.SUN_FLOWER:
      case Fix.SUN_FLOWER_JP:
        SetupParameter(2, 6, 35, 4, 4, 3, 32, 28);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_SUN_FIRE);
        this.CannotCritical = true;
        break;

      case Fix.SOLID_BEETLE:
      case Fix.SOLID_BEETLE_JP:
        SetupParameter(44, 6, 2, 9, 4, 6, 35, 29);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_TOSSHIN);
        this.CannotCritical = true;
        break;

      case Fix.SILENT_LADYBUG:
      case Fix.SILENT_LADYBUG_JP:
        SetupParameter(2, 7, 49, 7, 4, 8, 37, 32);
        this.ActionCommandList.Add(Fix.MAGIC_ATTACK);
        this.ActionCommandList.Add(Fix.COMMAND_FEATHER_WING);
        this.CannotCritical = true;
        break;

      case Fix.MYSTIC_DRYAD:
      case Fix.MYSTIC_DRYAD_JP:
        SetupParameter(55, 10, 60, 20, 5, 0, 80, 50);
        this.ActionCommandList.Add(Fix.COMMAND_POISON_RINPUN);
        this.ActionCommandList.Add(Fix.COMMAND_YOUEN_FIRE);
        this.ActionCommandList.Add(Fix.COMMAND_BLAZE_DANCE);
        this.CannotCritical = false;
        break;

      case Fix.NIMBLE_RABBIT:
      case Fix.NIMBLE_RABBIT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ENTANGLED_VINE:
      case Fix.ENTANGLED_VINE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.CREEPING_SPIDER:
      case Fix.CREEPING_SPIDER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BLOOD_MOSS:
      case Fix.BLOOD_MOSS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WOOD_ELF:
      case Fix.WOOD_ELF_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RUDE_WATCHDOG:
      case Fix.RUDE_WATCHDOG_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STINKED_SPORE:
      case Fix.STINKED_SPORE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DAUNTLESS_HORSE:
      case Fix.DAUNTLESS_HORSE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WONDER_SEED:
      case Fix.WONDER_SEED_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SHOTGUN_HYUUI:
      case Fix.SHOTGUN_HYUUI_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.CHARGED_BOAR:
      case Fix.CHARGED_BOAR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.POISON_FLOG:
      case Fix.POISON_FLOG_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SPEEDY_FALCON:
      case Fix.SPEEDY_FALCON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.INNOCENT_FAIRY:
      case Fix.INNOCENT_FAIRY_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GIANT_SNAKE:
      case Fix.GIANT_SNAKE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.CALM_STAG:
      case Fix.CALM_STAG_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SAVAGE_BEAR:
      case Fix.SAVAGE_BEAR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FOREST_ELEMENTAL:
      case Fix.FOREST_ELEMENTAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EXCITED_ELEPHANT:
      case Fix.EXCITED_ELEPHANT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLANSIS_KNIGHT:
      case Fix.FLANSIS_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.GATHERING_LAPTOR:
      case Fix.GATHERING_LAPTOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SYLPH_DANCER:
      case Fix.SYLPH_DANCER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THORN_WARRIOR:
      case Fix.THORN_WARRIOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TOWERING_ENT:
      case Fix.TOWERING_ENT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DISTURB_RHINO:
      case Fix.DISTURB_RHINO_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MIST_PYTHON:
      case Fix.MIST_PYTHON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MUDDLED_PLANT:
      case Fix.MUDDLED_PLANT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.KILLER_BEE:
      case Fix.KILLER_BEE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.POISON_MARY:
      case Fix.POISON_MARY_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLANSIS_OF_THE_FOREST_QUEEN:
      case Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.DAGGER_FISH:
      case Fix.DAGGER_FISH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLOATING_MANTA:
      case Fix.FLOATING_MANTA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SKYBLUE_BIRD:
      case Fix.SKYBLUE_BIRD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RAINBOW_CLIONE:
      case Fix.RAINBOW_CLIONE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ROLLING_MAGURO:
      case Fix.ROLLING_MAGURO_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LIMBER_SEAEAGLE:
      case Fix.LIMBER_SEAEAGLE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FLUFFY_CORAL:
      case Fix.FLUFFY_CORAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BLACK_OCTOPUS:
      case Fix.BLACK_OCTOPUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STEAL_SQUID:
      case Fix.STEAL_SQUID_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_HAND_OF_KRAKEN:
      case Fix.THE_HAND_OF_KRAKEN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.PROUD_VIKING:
      case Fix.PROUD_VIKING_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GAN_GAME:
      case Fix.GAN_GAME_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.JUMPING_KAMASU:
      case Fix.JUMPING_KAMASU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WRECHED_ANEMONE:
      case Fix.WRECHED_ANEMONE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DEEPSEA_HAND:
      case Fix.DEEPSEA_HAND_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ASSULT_SERPENT:
      case Fix.ASSULT_SERPENT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ESCORT_HERMIT_CLUB:
      case Fix.ESCORT_HERMIT_CLUB_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GLUTTONY_COELACANTH:
      case Fix.GLUTTONY_COELACANTH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GIANT_SEA_SPIDER:
      case Fix.GIANT_SEA_SPIDER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SHELL_THE_SWORD_KNIGHT:
      case Fix.SHELL_THE_SWORD_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.MOGUL_MANTA:
      case Fix.MOGUL_MANTA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WEEPING_MIST:
      case Fix.WEEPING_MIST_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.AMBUSH_ANGLERFISH:
      case Fix.AMBUSH_ANGLERFISH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EMERALD_LOBSTER:
      case Fix.EMERALD_LOBSTER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BIGMOUSE_JOE:
      case Fix.BIGMOUSE_JOE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RAMPAGE_BIGSHARK:
      case Fix.RAMPAGE_BIGSHARK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STICKY_STARFISH:
      case Fix.STICKY_STARFISH_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SEA_ELEMENTAL:
      case Fix.SEA_ELEMENTAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EDGED_HIGH_SHARK:
      case Fix.EDGED_HIGH_SHARK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GUARDIAN_ROYAL_NAGA:
      case Fix.GUARDIAN_ROYAL_NAGA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.THOUGHTFUL_NAUTILUS:
      case Fix.THOUGHTFUL_NAUTILUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.FEROCIOUS_WHALE:
      case Fix.FEROCIOUS_WHALE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.GHOST_SHIP:
      case Fix.GHOST_SHIP_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.RECKLESS_WALRUS:
      case Fix.RECKLESS_WALRUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BEAUTY_SEA_LILY:
      case Fix.BEAUTY_SEA_LILY_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DEFENSIVE_DATSU:
      case Fix.DEFENSIVE_DATSU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SEA_STAR_KNIGHT:
      case Fix.SEA_STAR_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SEA_SONG_MARMAID:
      case Fix.SEA_SONG_MARMAID_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.BRILLIANT_SEA_PRINCE:
      case Fix.BRILLIANT_SEA_PRINCE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.VELGAS_THE_KING_OF_SEA_STAR:
      case Fix.VELGAS_THE_KING_OF_SEA_STAR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.DEBRIS_SOLDIER:
      case Fix.DEBRIS_SOLDIER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MAGICAL_AUTOMATA:
      case Fix.MAGICAL_AUTOMATA_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.KILLER_MACHINE:
      case Fix.KILLER_MACHINE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ANTIQUE_MIRROR:
      case Fix.ANTIQUE_MIRROR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MECH_HAND:
      case Fix.MECH_HAND_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ABSENCE_MOAI:
      case Fix.ABSENCE_MOAI_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ACID_SCORPION:
      case Fix.ACID_SCORPION_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.AIMING_SHOOTER:
      case Fix.AIMING_SHOOTER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LIGHTNING_CLOUD:
      case Fix.LIGHTNING_CLOUD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STONE_STATUE_SEIHITSU:
      case Fix.STONE_STATUE_SEIHITSU_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.NEJIMAKI_KNIGHT:
      case Fix.NEJIMAKI_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WALKING_TIME_BOMB:
      case Fix.WALKING_TIME_BOMB_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DISTORTED_SENSOR:
      case Fix.DISTORTED_SENSOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.JUNK_VULKAN:
      case Fix.JUNK_VULKAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.ASSULT_SCARECROW:
      case Fix.ASSULT_SCARECROW_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MAD_DOCTOR:
      case Fix.MAD_DOCTOR_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SILENT_GARGOYLE:
      case Fix.SILENT_GARGOYLE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STONE_GOLEM:
      case Fix.STONE_GOLEM_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DEATH_DRONE:
      case Fix.DEATH_DRONE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MAGICAL_HAIL_GUN:
      case Fix.MAGICAL_HAIL_GUN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.THE_GALVADAZER:
      case Fix.THE_GALVADAZER_JP:
        SetupParameter(1, 1, 1, 1, 1, 10, 7500, 2000);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.SWIFT_EAGLE:
      case Fix.SWIFT_EAGLE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.EASTERN_GOLEM:
      case Fix.EASTERN_GOLEM_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WESTERN_GOLEM:
      case Fix.WESTERN_GOLEM_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WIND_ELEMENTAL:
      case Fix.WIND_ELEMENTAL_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SKY_KNIGHT:
      case Fix.SKY_KNIGHT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_PURPLE_HIKARIGOKE:
      case Fix.THE_PURPLE_HIKARIGOKE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MYSTICAL_UNICORN:
      case Fix.MYSTICAL_UNICORN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TRIAL_HERMIT:
      case Fix.TRIAL_HERMIT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STORM_BIRDMAN:
      case Fix.STORM_BIRDMAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_BLUE_LAVA_EYE:
      case Fix.THE_BLUE_LAVA_EYE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.FLYING_CURTAIN:
      case Fix.FLYING_CURTAIN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LUMINOUS_HAWK:
      case Fix.LUMINOUS_HAWK_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.AETHER_GUST:
      case Fix.AETHER_GUST_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WHIRLWIND_KITSUNE:
      case Fix.WHIRLWIND_KITSUNE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THUNDER_LION:
      case Fix.THUNDER_LION_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.SAINT_PEGASUS:
      case Fix.SAINT_PEGASUS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.DREAM_WALKER:
      case Fix.DREAM_WALKER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.IVORY_STATUE:
      case Fix.IVORY_STATUE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.STUBBORN_SAGE:
      case Fix.STUBBORN_SAGE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.LIGHT_THUNDER_LANCEBOLTS:
      case Fix.LIGHT_THUNDER_LANCEBOLTS_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.BOMB_BALLON:
      case Fix.BOMB_BALLON_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.OBSERVANT_HERALD:
      case Fix.OBSERVANT_HERALD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.TOWER_SCOUT:
      case Fix.TOWER_SCOUT_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MIST_SALVAGER:
      case Fix.MIST_SALVAGER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.WINGSPAN_RANGER:
      case Fix.WINGSPAN_RANGER_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.HARDENED_GRIFFIN:
      case Fix.HARDENED_GRIFFIN_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.MAJESTIC_CLOUD:
      case Fix.MAJESTIC_CLOUD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.PRISMA_SPHERE:
      case Fix.PRISMA_SPHERE_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.VEIL_FORTUNE_WIZARD:
      case Fix.VEIL_FORTUNE_WIZARD_JP:
        SetupParameter(1, 1, 1, 1, 1, 1, 1, 1);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = true;
        break;

      case Fix.THE_YODIRIAN:
      case Fix.THE_YODIRIAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 10, 7500, 2000);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.HELL_KERBEROS:
      case Fix.HELL_KERBEROS_JP:
        //SetupParameter(85, 50, 15, 300, 10, 10000, 3000, 2000);
        SetupParameter(1, 50, 15, 1, 10, 0, 3000, 1200);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

      case Fix.THE_YODIRIAN:
      case Fix.THE_YODIRIAN_JP:
        SetupParameter(1, 1, 1, 1, 1, 10, 7500, 2000);
        this.ActionCommandList.Add(Fix.NORMAL_ATTACK);
        this.CannotCritical = false;
        break;

    }

    this.MaxGain();
    this.CurrentActionCommand = this.ActionCommandList[0];
  }

  private void SetupParameter(int strength, int agility, int intelligence, int stamina, int mind, int base_life, int exp, int gold)
  {
    this._strength = strength;
    this._agility = agility;
    this._intelligence = intelligence;
    this._stamina = stamina;
    this._mind = mind;
    this._baseLife = base_life;
    this._exp = exp;
    this._gold = gold;
  }

  public string ChooseCommand()
  {
    string result = string.Empty;
    if (this.FullName == Fix.MYSTIC_DRYAD)
    {
      List<string> current = new List<string>();
      if (this.Target != null && this.Target.IsPoison == null)
      {
        current.Add(Fix.COMMAND_POISON_RINPUN);
      }

      if (this.IsUpFire == null)
      {
        current.Add(Fix.COMMAND_BLAZE_DANCE);
      }

      current.Add(Fix.COMMAND_YOUEN_FIRE);
      result = LogicMRandom(current);
    }
    else
    {
      // 雑魚はランダムでひとまずよい。
      result = LogicMRandom(this.ActionCommandList);
    }

    return result;
  }

  private string LogicMRandom(List<string> command_list)
  {
    string result = string.Empty;
    int random = AP.Math.RandomInteger(command_list.Count);
    return command_list[random];
  }
}
