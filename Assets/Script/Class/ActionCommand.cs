using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class ActionCommand
{
  public enum Attribute
  {
    None,
    Basic,
    Skill,
    Magic,
    Archetype,
    UseItem,
    MonsterAction,
    NoAction, // 意図的にアクションではない事を示す。意味を持たないNoneとは異なる。
  }

  public enum CumulativeType
  {
    None,
    Normal,
    Cumulative,
  }

  public enum TargetType
  {
    None,
    Enemy,
    Ally,
    Own,
    EnemyOrAlly,
    EnemyGroup,
    AllyGroup,
    EnemyField,
    AllyField,
    AllMember,  
    AllField,
    ALLFieldMember,
    InstantTarget
  }

  public enum TimingType
  {
    None,
    Normal,
    Instant,
    Sorcery,
    StackCommand,
    Archetype,
  }

  public enum CommandCategory
  {
    None,
    Basic,
    ActionCommand,
    Item,
    Archetype,
  }

  public static List<string> GetCommandList(Fix.CommandAttribute attr)
  {
    List<string> result = new List<string>();
    if (attr == Fix.CommandAttribute.Fire)
    {
      result.Add(Fix.FIRE_BALL);
      result.Add(Fix.FLAME_BLADE);
      result.Add(Fix.METEOR_BULLET);
      result.Add(Fix.VOLCANIC_BLAZE);
      result.Add(Fix.FLAME_STRIKE);
      result.Add(Fix.CIRCLE_OF_THE_IGNITE);
      result.Add(Fix.LAVA_ANNIHILATION);
    }
    else if (attr == Fix.CommandAttribute.Ice)
    {
      result.Add(Fix.ICE_NEEDLE);
      result.Add(Fix.PURE_PURIFICATION);
      result.Add(Fix.BLUE_BULLET);
      result.Add(Fix.FREEZING_CUBE);
      result.Add(Fix.FROST_LANCE);
      result.Add(Fix.WATER_PRESENCE);
      result.Add(Fix.ABSOLUTE_ZERO);
    }
    else if (attr == Fix.CommandAttribute.HolyLight)
    {
      result.Add(Fix.FRESH_HEAL);
      result.Add(Fix.DIVINE_CIRCLE);
      result.Add(Fix.HOLY_BREATH);
      result.Add(Fix.ANGELIC_ECHO);
      result.Add(Fix.SHINING_HEAL);
      result.Add(Fix.VALKYRIE_BLADE);
      result.Add(Fix.RESURRECTION);
    }
    else if (attr == Fix.CommandAttribute.DarkMagic)
    {
      result.Add(Fix.SHADOW_BLAST);
      result.Add(Fix.BLOOD_SIGN);
      result.Add(Fix.BLACK_CONTRACT);
      result.Add(Fix.CURSED_EVANGILE);
      result.Add(Fix.CIRCLE_OF_THE_DESPAIR);
      result.Add(Fix.THE_DARK_INTENSITY);
      result.Add(Fix.DEATH_SCYTHE);
    }
    else if (attr == Fix.CommandAttribute.Force)
    {
      result.Add(Fix.ORACLE_COMMAND);
      result.Add(Fix.FORTUNE_SPIRIT);
      result.Add(Fix.WORD_OF_POWER);
      result.Add(Fix.GALE_WIND);
      result.Add(Fix.SEVENTH_PRINCIPLE);
      result.Add(Fix.FUTURE_VISION);
      result.Add(Fix.GENESIS);
    }
    else if (attr == Fix.CommandAttribute.VoidChant)
    {
      result.Add(Fix.ENERGY_BOLT);
      result.Add(Fix.FLASH_COUNTER);
      result.Add(Fix.SIGIL_OF_THE_PENDING);
      result.Add(Fix.PHANTOM_OBORO);
      result.Add(Fix.COUNTER_DISALLOW);
      result.Add(Fix.DETACHMENT_FAULT);
      result.Add(Fix.TIME_SKIP);
    }
    else if (attr == Fix.CommandAttribute.Warrior)
    {
      result.Add(Fix.STRAIGHT_SMASH);
      result.Add(Fix.STANCE_OF_THE_BLADE);
      result.Add(Fix.DOUBLE_SLASH);
      result.Add(Fix.IRON_BUSTER);
      result.Add(Fix.RAGING_STORM);
      result.Add(Fix.STANCE_OF_THE_IAI);
      result.Add(Fix.KINETIC_SMASH);
    }
    else if (attr == Fix.CommandAttribute.Guardian)
    {
      result.Add(Fix.SHIELD_BASH);
      result.Add(Fix.STANCE_OF_THE_GUARD);
      result.Add(Fix.CONCUSSIVE_HIT);
      result.Add(Fix.DOMINATION_FIELD);
      result.Add(Fix.HARDEST_PARRY);
      result.Add(Fix.ONE_IMMUNITY);
      result.Add(Fix.CATASTROPHE);
    }
    else if (attr == Fix.CommandAttribute.MartialArts)
    {
      result.Add(Fix.LEG_STRIKE);
      result.Add(Fix.SPEED_STEP);
      result.Add(Fix.BONE_CRUSH);
      result.Add(Fix.DEADLY_DRIVE);
      result.Add(Fix.UNINTENTIONAL_HIT);
      result.Add(Fix.STANCE_OF_MUIN);
      result.Add(Fix.CARNAGE_RUSH);
    }
    else if (attr == Fix.CommandAttribute.Archery)
    {
      result.Add(Fix.HUNTER_SHOT);
      result.Add(Fix.MULTIPLE_SHOT);
      result.Add(Fix.EYE_OF_THE_ISSHIN);
      result.Add(Fix.PENETRATION_ARROW);
      result.Add(Fix.PRECISION_STRIKE);
      result.Add(Fix.ETERNAL_CONCENTRATION);
      result.Add(Fix.PIERCING_ARROW);
    }
    else if (attr == Fix.CommandAttribute.Truth)
    {
      result.Add(Fix.TRUE_SIGHT);
      result.Add(Fix.LEYLINE_SCHEMA);
      result.Add(Fix.VOICE_OF_VIGOR);
      result.Add(Fix.WILL_AWAKENING);
      result.Add(Fix.EVERFLOW_MIND);
      result.Add(Fix.SIGIL_OF_THE_FAITH);
      result.Add(Fix.STANCE_OF_THE_KOKOROE);
    }
    else if (attr == Fix.CommandAttribute.Mindfulness)
    {
      result.Add(Fix.DISPEL_MAGIC);
      result.Add(Fix.SPIRITUAL_REST);
      result.Add(Fix.UNSEEN_AID);
      result.Add(Fix.CIRCLE_OF_SERENITY);
      result.Add(Fix.INNER_INSPIRATION);
      result.Add(Fix.ZERO_IMMUNITY);
      result.Add(Fix.TRANSCENDENCE_REACHED);
    }
    else if (attr == Fix.CommandAttribute.HolyLight_DarkMagic)
    {
      result.Add(Fix.PSYCHIC_TRANCE);
      result.Add(Fix.BLIND_JUSTICE);
      result.Add(Fix.DEATH_DENY);
    }
    else if (attr == Fix.CommandAttribute.HolyLight_Fire)
    {
      result.Add(Fix.FLASH_BLAZE);
      result.Add(Fix.LIGHT_DETONATOR);
      result.Add(Fix.ASCENDANT_METEOR);
    }
    else if (attr == Fix.CommandAttribute.HolyLight_Ice)
    {
      result.Add(Fix.SKY_SHIELD);
      result.Add(Fix.SACRED_FIELD);
      result.Add(Fix.SAINT_JUDGEMENT);
    }
    else if (attr == Fix.CommandAttribute.HolyLight_Force)
    {
      result.Add(Fix.HOLY_BREAKER);
      result.Add(Fix.EXALTED_FIELD);
      result.Add(Fix.HYMN_CONTRACT);
    }
    else if (attr == Fix.CommandAttribute.HolyLight_VoidChant)
    {
      result.Add(Fix.VOID_THUNDER);
      result.Add(Fix.ANGEL_INTERVENTION);
      result.Add(Fix.ENDLESS_ANTHEM);
    }
    else if (attr == Fix.CommandAttribute.DarkMagic_Fire)
    {
      result.Add(Fix.BLACK_FIRE);
      result.Add(Fix.BLAZING_FIELD);
      result.Add(Fix.DEMONIC_IGNITE);
    }
    else if (attr == Fix.CommandAttribute.DarkMagic_Ice)
    {
      result.Add(Fix.DEEP_MIRROR);
      result.Add(Fix.STORM_SHARD);
      result.Add(Fix.ABYSS_EYE);
    }
    else if (attr == Fix.CommandAttribute.DarkMagic_Force)
    {
      result.Add(Fix.WORD_OF_MALICE);
      result.Add(Fix.SIN_FORTUNE);
      result.Add(Fix.BLOOD_SHACKLE);
    }
    else if (attr == Fix.CommandAttribute.DarkMagic_VoidChant)
    {
      result.Add(Fix.ACHROMA_BLAST);
      result.Add(Fix.DOOM_BLADE);
      result.Add(Fix.ECLIPSE_END);
    }
    else if (attr == Fix.CommandAttribute.Fire_Ice)
    {
      result.Add(Fix.CHILL_BURN);
      result.Add(Fix.SWORD_OF_FREEZING_FIRE);
      result.Add(Fix.ZETA_EXPLOSION);
    }
    else if (attr == Fix.CommandAttribute.Fire_Force)
    {
      result.Add(Fix.BURST_INFERNO);
      result.Add(Fix.PIERCING_FLAME);
      result.Add(Fix.SIGIL_OF_HOMURA);
    }
    else if (attr == Fix.CommandAttribute.Fire_VoidChant)
    {
      result.Add(Fix.ERRATIC_THUNDERBOLT);
      result.Add(Fix.STEAM_MIRROR);
      result.Add(Fix.RED_DRAGON_WILL);
    }
    else if (attr == Fix.CommandAttribute.Ice_Force)
    {
      result.Add(Fix.WORD_OF_ATTITUDE);
      result.Add(Fix.ICICLE_BARRIER);
      result.Add(Fix.AUSTERITY_MATRIX);
    }
    else if (attr == Fix.CommandAttribute.Ice_VoidChant)
    {
      result.Add(Fix.GLACIAL_CIRCLE);
      result.Add(Fix.VORTEX_SONG);
      result.Add(Fix.BLUE_DRAGON_WILL);
    }
    else if (attr == Fix.CommandAttribute.Force_VoidChant)
    {
      result.Add(Fix.WORD_OF_NINE);
      result.Add(Fix.PARADOX_IMAGE);
      result.Add(Fix.WARP_GATE);
    }
    else if (attr == Fix.CommandAttribute.Warrior_Guardian)
    {
      result.Add(Fix.NEUTRAL_SMASH);
      result.Add(Fix.STANCE_OF_DOUBLE);
    }
    else if (attr == Fix.CommandAttribute.Warrior_MartialArts)
    {
      result.Add(Fix.BLITZ_STRIKE);
      result.Add(Fix.ASSASSINATION_HIT);
    }
    else if (attr == Fix.CommandAttribute.Warrior_Archery)
    {
      result.Add(Fix.PHOENIX_EYE);
      result.Add(Fix.HARDENED_INSIGHT);
    }
    else if (attr == Fix.CommandAttribute.Warrior_Truth)
    {
      result.Add(Fix.CHALLENGING_SHOUT);
      result.Add(Fix.ONSLAUGHT_HIT);
    }
    else if (attr == Fix.CommandAttribute.Warrior_Mindfulness)
    {
      result.Add(Fix.FORMLESS_STYLE);
      result.Add(Fix.HARDEST_PARRY);
    }
    else if (attr == Fix.CommandAttribute.Guardian_MartialArts)
    {
      result.Add(Fix.TACTICAL_VISION);
      result.Add(Fix.SWIFT_RESPONSE);
    }
    else if (attr == Fix.CommandAttribute.Guardian_Archery)
    {
      result.Add(Fix.RIGHTEOUSNESS_ARROW);
      result.Add(Fix.PERFECT_EVASION);
    }
    else if (attr == Fix.CommandAttribute.Guardian_Truth)
    {
      result.Add(Fix.REFLEX_ESSENCE);
      result.Add(Fix.SELF_PERSUASION);
    }
    else if (attr == Fix.CommandAttribute.Guardian_Mindfulness)
    {
      result.Add(Fix.TRUST_SILENCE);
      result.Add(Fix.NOURISH_POWER);
    }
    else if (attr == Fix.CommandAttribute.MartialArts_Archery)
    {
      result.Add(Fix.SUDDEN_STRIKEARROW);
      result.Add(Fix.STANCE_OF_MYSTIC);
    }
    else if (attr == Fix.CommandAttribute.MartialArts_Truth)
    {
      result.Add(Fix.PSYCHIC_WAVE);
      result.Add(Fix.FLARE_OF_FIGHTING);
    }
    else if (attr == Fix.CommandAttribute.MartialArts_Mindfulness)
    {
      result.Add(Fix.INFINITY_IMAGE);
      result.Add(Fix.UNIFIED_CONVICTION);
    }
    else if (attr == Fix.CommandAttribute.Archery_Truth)
    {
      result.Add(Fix.ABSOLUTE_ARROW);
      result.Add(Fix.HEAVENS_WISDOM);
    }
    else if (attr == Fix.CommandAttribute.Archery_Mindfulness)
    {
      result.Add(Fix.SILENT_MEDITATION);
      result.Add(Fix.COLORLESS_FORM);
    }
    else if (attr == Fix.CommandAttribute.Truth_Mindfulness)
    {
      result.Add(Fix.OVERWHELMING_DESTINY);
      result.Add(Fix.WORLD_CHANT);
    }
    else
    {
      result.Add(Fix.AIR_CUTTER);
      result.Add(Fix.STORM_ARMOR);
      result.Add(Fix.SONIC_PULSE);
      result.Add(Fix.ERRATIC_THUNDER);
      result.Add(Fix.CYCLONE_FIELD);
      result.Add(Fix.LIGHTNING_SQUALL);
      result.Add(Fix.ROCK_SLAM);
      result.Add(Fix.SOLID_WALL);
      result.Add(Fix.LAND_SHATTER);
      result.Add(Fix.SAND_BURST);
      result.Add(Fix.PETRIFICATION);
      result.Add(Fix.LIFE_GRACE);
      result.Add(Fix.EARTH_QUAKE);
      result.Add(Fix.VENOM_SLASH);
      result.Add(Fix.INVISIBLE_BIND);
      result.Add(Fix.IRREGULAR_STEP);
      result.Add(Fix.ASSASSINATION_HIT);
      result.Add(Fix.DIRTY_WISDOM);
      result.Add(Fix.AMBIDEXTERITY);
      result.Add(Fix.AURA_OF_POWER);
      result.Add(Fix.SKY_SHIELD);
      result.Add(Fix.AETHER_DRIVE);
      result.Add(Fix.REVOLUTION_AURA);
      result.Add(Fix.BRILLIANT_FORM);
      result.Add(Fix.AUSTERITY_MATRIX);
      result.Add(Fix.MUTE_IMPULSE);
      result.Add(Fix.OATH_OF_AEGIS);
      result.Add(Fix.ESSENCE_OVERFLOW);
      result.Add(Fix.HEART_OF_LIFE);
      result.Add(Fix.AURA_BURN);
      result.Add(Fix.SOUL_SHOUT);
      result.Add(Fix.OVERWHELMING_DESTINY);
      result.Add(Fix.DARKNESS_CIRCLE);
      result.Add(Fix.STANCE_OF_THE_SHADE);
      result.Add(Fix.KILLING_WAVE);
      result.Add(Fix.LEVEL_EATER);
      result.Add(Fix.ABYSS_EYE);
      result.Add(Fix.AVENGER_PROMISE);
      result.Add(Fix.DEMON_CONTRACT);
      result.Add(Fix.IDEOLOGY_OF_SOPHISTICATION);
      result.Add(Fix.SIGIL_OF_THE_HOMURA);
      result.Add(Fix.WORD_OF_PROPHECY);
    }
    return result;
  }

  // todo リリースで削除する。
  //public static List<int> GetCommandPlus(Character player, Fix.CommandAttribute attr)
  //{
  //  List<int> result = new List<int>();
  //  if (attr == Fix.CommandAttribute.Fire)
  //  {
  //    result.Add(player.FireBall);
  //    result.Add(player.FlameBlade);
  //    result.Add(player.MeteorBullet);
  //    result.Add(player.VolcanicBlaze);
  //    result.Add(player.FlameStrike);
  //    result.Add(player.CircleOfTheIgnite);
  //    result.Add(player.LavaAnnihilation);
  //  }
  //  else if (attr == Fix.CommandAttribute.Ice)
  //  {
  //    result.Add(player.IceNeedle);
  //    result.Add(player.PurePurification);
  //    result.Add(player.BlueBullet);
  //    result.Add(player.FreezingCube);
  //    result.Add(player.FrostLance);
  //    result.Add(player.WaterPresence);
  //    result.Add(player.AbsoluteZero);
  //  }
  //  else if (attr == Fix.CommandAttribute.HolyLight)
  //  {
  //    result.Add(player.FreshHeal);
  //    result.Add(player.DivineCircle);
  //    result.Add(player.HolyBreath);
  //    result.Add(player.AngelicEcho);
  //    result.Add(player.ShiningHeal);
  //    result.Add(player.ValkyrieBlade);
  //    result.Add(player.Resurrection);
  //  }
  //  else if (attr == Fix.CommandAttribute.DarkMagic)
  //  {
  //    result.Add(player.ShadowBlast);
  //    result.Add(player.BloodSign);
  //    result.Add(player.BlackContract);
  //    result.Add(player.CursedEvangile);
  //    result.Add(player.CircleOfTheDespair);
  //    result.Add(player.TheDarkIntensity);
  //    result.Add(player.DeathScythe);
  //  }
  //  else if (attr == Fix.CommandAttribute.Force)
  //  {
  //    result.Add(player.OracleCommand);
  //    result.Add(player.FortuneSpirit);
  //    result.Add(player.WordOfPower);
  //    result.Add(player.GaleWind);
  //    result.Add(player.SeventhPrinciple);
  //    result.Add(player.FutureVision);
  //    result.Add(player.Genesis);
  //  }
  //  else if (attr == Fix.CommandAttribute.VoidChant)
  //  {
  //    result.Add(player.EnergyBolt);
  //    result.Add(player.FlashCounter);
  //    result.Add(player.SigilOfThePending);
  //    result.Add(player.PhantomOboro);
  //    result.Add(player.CounterDisallow);
  //    result.Add(player.DetachmentFault);
  //    result.Add(player.TimeSkip);
  //  }
  //  else if (attr == Fix.CommandAttribute.Warrior)
  //  {
  //    result.Add(player.StraightSmash);
  //    result.Add(player.StanceOfTheBlade);
  //    result.Add(player.DoubleSlash);
  //    result.Add(player.IronBuster);
  //    result.Add(player.RagingStorm);
  //    result.Add(player.StanceOfTheIai);
  //    result.Add(player.KineticSmash);
  //  }
  //  else if (attr == Fix.CommandAttribute.Guardian)
  //  {
  //    result.Add(player.ShieldBash);
  //    result.Add(player.StanceOfTheGuard);
  //    result.Add(player.ConcussiveHit);
  //    result.Add(player.DominationField);
  //    result.Add(player.HardestParry);
  //    result.Add(player.OneImmunity);
  //    result.Add(player.Catastrophe);
  //  }
  //  else if (attr == Fix.CommandAttribute.MartialArts)
  //  {
  //    result.Add(player.LegStrike);
  //    result.Add(player.SpeedStep);
  //    result.Add(player.BoneCrush);
  //    result.Add(player.DeadlyDrive);
  //    result.Add(player.UnintentionalHit);
  //    result.Add(player.StanceOfMuin);
  //    result.Add(player.CarnageRush);
  //  }
  //  else if (attr == Fix.CommandAttribute.Archery)
  //  {
  //    result.Add(player.HunterShot);
  //    result.Add(player.MultipleShot);
  //    result.Add(player.EyeOfTheIsshin);
  //    result.Add(player.PenetrationArrow);
  //    result.Add(player.PrecisionStrike);
  //    result.Add(player.EternalConcentration);
  //    result.Add(player.PiercingArrow);
  //  }
  //  else if (attr == Fix.CommandAttribute.Truth)
  //  {
  //    result.Add(player.TrueSight);
  //    result.Add(player.LeylineSchema);
  //    result.Add(player.VoiceOfVigor);
  //    result.Add(player.WillAwakening);
  //    result.Add(player.EverflowMind);
  //    result.Add(player.SigilOfTheFaith);
  //    result.Add(player.StanceOfTheKokoroe);
  //  }
  //  else if (attr == Fix.CommandAttribute.Mindfulness)
  //  {
  //    result.Add(player.DispelMagic);
  //    result.Add(player.SpiritualRest);
  //    result.Add(player.UnseenAid);
  //    result.Add(player.CircleOfSerenity);
  //    result.Add(player.InnerInspiration);
  //    result.Add(player.ZeroImmunity);
  //    result.Add(player.TranscendenceReached);
  //  }
  //  else
  //  {
  //    result.Add(player.AirCutter);
  //    result.Add(player.StormArmor);
  //    result.Add(player.SonicPulse);
  //    result.Add(player.ErraticThunder);
  //    result.Add(player.CycloneField);
  //    result.Add(player.LightningSquall);
  //    result.Add(player.RockSlam);
  //    result.Add(player.SoldWall);
  //    result.Add(player.EarthSurge);
  //    result.Add(player.SandBurst);
  //    result.Add(player.Petrification);
  //    result.Add(player.LifeGrace);
  //    result.Add(player.EarthQuake);
  //    result.Add(player.AuraBurn);
  //    result.Add(player.EagleEye);
  //    result.Add(player.HeartOfLife);
  //    result.Add(player.SoulShout);
  //    result.Add(player.OverwhelmingDestiny);
  //    result.Add(player.ExactTime);
  //    result.Add(player.IdeologyOfSophistication);
  //    result.Add(player.SigilOfTheHomura);
  //    result.Add(player.WordOfProphecy);
  //    result.Add(player.AuraOfPower);
  //    result.Add(player.SkyShield);
  //    result.Add(player.AetherDrive);
  //    result.Add(player.RevolutionAura);
  //    result.Add(player.BrilliantForm);
  //    result.Add(player.AusterityMatrix);
  //    result.Add(player.MuteImpulse);
  //    result.Add(player.OathOfAegis);
  //    result.Add(player.EssenceOverflow);
  //    result.Add(player.DarknessCircle);
  //    result.Add(player.StanceOfTheShade);
  //    result.Add(player.KillingWave);
  //    result.Add(player.LevelEater);
  //    result.Add(player.AbyssEye);
  //    result.Add(player.AvengerPromise);
  //    result.Add(player.DemonContract);
  //  }
  //  return result;
  //}

  public static string GetAttribute_JP(string command_name)
  {
    Attribute current = GetAttribute(command_name);
    if (current == Attribute.Basic)
    {
      return Fix.ATTRIBUTE_BASIC;
    }
    else if (current == Attribute.Magic)
    {
      return Fix.ATTRIBUTE_MAGIC;
    }
    else if (current == Attribute.Skill)
    {
      return Fix.ATTRIBUTE_SKILL;
    }
    else if (current == Attribute.Archetype)
    {
      return Fix.ATTRIBUTE_CORE;
    }
    else if (current == Attribute.None)
    {
      return Fix.ATTRIBUTE_NONE;
    }
    return Fix.ATTRIBUTE_BASIC; // デフォルトは基本行動とする。
  }

  public static string GetAttribute_Unit(string command_name)
  {
    Attribute current = GetAttribute(command_name);
    if (current == Attribute.Basic)
    {
      return "(なし)";
    }
    else if (current == Attribute.Magic)
    {
      return " MP";
    }
    else if (current == Attribute.Skill)
    {
      return " SP";
    }
    else if (current == Attribute.Archetype)
    {
      return "(なし)";
    }
    else if (current == Attribute.None)
    {
      return "(なし)";
    }
    return "(なし)"; // デフォルトは(なし)とする。
  }

  public static Attribute GetAttribute(string command_name)
  {
    #region "基本／一般"
    if (command_name == Fix.NORMAL_ATTACK) { return Attribute.Basic; } // 物理属性の基本攻撃。スキル属性には設定せずbasicとする。（束縛の対象にはならない）
    if (command_name == Fix.MAGIC_ATTACK) { return Attribute.Basic; } // 魔法属性の基本攻撃。魔法属性には設定せずbasicとする。（沈黙の対象にはならない）
    if (command_name == Fix.DEFENSE) { return Attribute.NoAction; }
    if (command_name == Fix.STAY) { return Attribute.NoAction; }
    if (command_name == Fix.USE_RED_POTION_1) { return Attribute.UseItem; }
    if (command_name == Fix.USE_RED_POTION_2) { return Attribute.UseItem; }
    if (command_name == Fix.USE_RED_POTION_3) { return Attribute.UseItem; }
    if (command_name == Fix.USE_RED_POTION_4) { return Attribute.UseItem; }
    if (command_name == Fix.USE_RED_POTION_5) { return Attribute.UseItem; }
    if (command_name == Fix.USE_RED_POTION_6) { return Attribute.UseItem; }
    if (command_name == Fix.USE_RED_POTION_7) { return Attribute.UseItem; }
    if (command_name == Fix.USE_BLUE_POTION_1) { return Attribute.UseItem; }
    if (command_name == Fix.USE_BLUE_POTION_2) { return Attribute.UseItem; }
    if (command_name == Fix.USE_BLUE_POTION_3) { return Attribute.UseItem; }
    if (command_name == Fix.USE_BLUE_POTION_4) { return Attribute.UseItem; }
    if (command_name == Fix.USE_BLUE_POTION_5) { return Attribute.UseItem; }
    if (command_name == Fix.USE_BLUE_POTION_6) { return Attribute.UseItem; }
    if (command_name == Fix.USE_BLUE_POTION_7) { return Attribute.UseItem; }
    #endregion

    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return Attribute.Magic; }
    if (command_name == Fix.ICE_NEEDLE) { return Attribute.Magic; }
    if (command_name == Fix.FRESH_HEAL) { return Attribute.Magic; }
    if (command_name == Fix.SHADOW_BLAST) { return Attribute.Magic; }
    if (command_name == Fix.ORACLE_COMMAND) { return Attribute.Magic; }
    if (command_name == Fix.ENERGY_BOLT) { return Attribute.Magic; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return Attribute.Skill; }
    if (command_name == Fix.SHIELD_BASH) { return Attribute.Skill; }
    if (command_name == Fix.LEG_STRIKE) { return Attribute.Skill; }
    if (command_name == Fix.HUNTER_SHOT) { return Attribute.Skill; }
    if (command_name == Fix.TRUE_SIGHT) { return Attribute.Skill; }
    if (command_name == Fix.DISPEL_MAGIC) { return Attribute.Skill; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return Attribute.Magic; }
    if (command_name == Fix.PURE_PURIFICATION) { return Attribute.Magic; }
    if (command_name == Fix.DIVINE_CIRCLE) { return Attribute.Magic; }
    if (command_name == Fix.BLOOD_SIGN) { return Attribute.Magic; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return Attribute.Magic; }
    if (command_name == Fix.FLASH_COUNTER) { return Attribute.Magic; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return Attribute.Skill; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return Attribute.Skill; }
    if (command_name == Fix.SPEED_STEP) { return Attribute.Skill; }
    if (command_name == Fix.MULTIPLE_SHOT) { return Attribute.Skill; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return Attribute.Skill; }
    if (command_name == Fix.SPIRITUAL_REST) { return Attribute.Skill; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return Attribute.Magic; }
    if (command_name == Fix.BLUE_BULLET) { return Attribute.Magic; }
    if (command_name == Fix.HOLY_BREATH) { return Attribute.Magic; }
    if (command_name == Fix.BLACK_CONTRACT) { return Attribute.Magic; }
    if (command_name == Fix.WORD_OF_POWER) { return Attribute.Magic; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return Attribute.Magic; }
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return Attribute.Skill; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return Attribute.Skill; }
    if (command_name == Fix.BONE_CRUSH) { return Attribute.Skill; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return Attribute.Skill; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return Attribute.Skill; }
    if (command_name == Fix.UNSEEN_AID) { return Attribute.Skill; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return Attribute.Magic; }
    if (command_name == Fix.FREEZING_CUBE) { return Attribute.Magic; }
    if (command_name == Fix.ANGELIC_ECHO) { return Attribute.Magic; }
    if (command_name == Fix.CURSED_EVANGILE) { return Attribute.Magic; }
    if (command_name == Fix.GALE_WIND) { return Attribute.Magic; }
    if (command_name == Fix.PHANTOM_OBORO) { return Attribute.Magic; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return Attribute.Skill; }
    if (command_name == Fix.DOMINATION_FIELD) { return Attribute.Skill; }
    if (command_name == Fix.DEADLY_DRIVE) { return Attribute.Skill; }
    if (command_name == Fix.PENETRATION_ARROW) { return Attribute.Skill; }
    if (command_name == Fix.WILL_AWAKENING) { return Attribute.Skill; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return Attribute.Skill; }
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return Attribute.Magic; }
    if (command_name == Fix.FROST_LANCE) { return Attribute.Magic; }
    if (command_name == Fix.SHINING_HEAL) { return Attribute.Magic; }
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return Attribute.Magic; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return Attribute.Magic; }
    if (command_name == Fix.COUNTER_DISALLOW) { return Attribute.Magic; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return Attribute.Skill; }
    if (command_name == Fix.HARDEST_PARRY) { return Attribute.Skill; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return Attribute.Skill; }
    if (command_name == Fix.PRECISION_STRIKE) { return Attribute.Skill; }
    if (command_name == Fix.EVERFLOW_MIND) { return Attribute.Skill; }
    if (command_name == Fix.INNER_INSPIRATION) { return Attribute.Skill; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return Attribute.Magic; }
    if (command_name == Fix.WATER_PRESENCE) { return Attribute.Magic; }
    if (command_name == Fix.VALKYRIE_BLADE) { return Attribute.Magic; }
    if (command_name == Fix.THE_DARK_INTENSITY) { return Attribute.Magic; }
    if (command_name == Fix.FUTURE_VISION) { return Attribute.Magic; }
    if (command_name == Fix.DETACHMENT_FAULT) { return Attribute.Magic; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return Attribute.Skill; }
    if (command_name == Fix.ONE_IMMUNITY) { return Attribute.Skill; }
    if (command_name == Fix.STANCE_OF_MUIN) { return Attribute.Skill; }
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return Attribute.Skill; }
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return Attribute.Skill; }
    if (command_name == Fix.ZERO_IMMUNITY) { return Attribute.Skill; }
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return Attribute.Magic; }
    if (command_name == Fix.ABSOLUTE_ZERO) { return Attribute.Magic; }
    if (command_name == Fix.RESURRECTION) { return Attribute.Magic; }
    if (command_name == Fix.DEATH_SCYTHE) { return Attribute.Magic; }
    if (command_name == Fix.GENESIS) { return Attribute.Magic; }
    if (command_name == Fix.TIME_SKIP) { return Attribute.Magic; }
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return Attribute.Skill; }
    if (command_name == Fix.CATASTROPHE) { return Attribute.Skill; }
    if (command_name == Fix.CARNAGE_RUSH) { return Attribute.Skill; }
    if (command_name == Fix.PIERCING_ARROW) { return Attribute.Skill; }
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return Attribute.Skill; }
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return Attribute.Skill; }
    #endregion

    #region "複合魔法"
    // 聖＋闇 [完全逆]
    if (command_name == Fix.PSYCHIC_TRANCE) { return Attribute.Magic; }
    if (command_name == Fix.BLIND_JUSTICE) { return Attribute.Magic; }
    if (command_name == Fix.DEATH_DENY) { return Attribute.Magic; }
    // 聖＋炎
    if (command_name == Fix.FLASH_BLAZE) { return Attribute.Magic; }
    if (command_name == Fix.LIGHT_DETONATOR) { return Attribute.Magic; }
    if (command_name == Fix.ASCENDANT_METEOR) { return Attribute.Magic; }
    // 聖＋氷
    if (command_name == Fix.SKY_SHIELD) { return Attribute.Magic; }
    if (command_name == Fix.SACRED_FIELD) { return Attribute.Magic; }
    if (command_name == Fix.SAINT_JUDGEMENT) { return Attribute.Magic; }
    // 聖＋理
    if (command_name == Fix.HOLY_BREAKER) { return Attribute.Magic; }
    if (command_name == Fix.EXALTED_FIELD) { return Attribute.Magic; }
    if (command_name == Fix.HYMN_CONTRACT) { return Attribute.Magic; }
    // 聖＋空唱
    if (command_name == Fix.VOID_THUNDER) { return Attribute.Magic; }
    if (command_name == Fix.ANGEL_INTERVENTION) { return Attribute.Magic; }
    if (command_name == Fix.ENDLESS_ANTHEM) { return Attribute.Magic; }
    // 闇＋炎
    if (command_name == Fix.BLACK_FIRE) { return Attribute.Magic; }
    if (command_name == Fix.BLAZING_FIELD) { return Attribute.Magic; }
    if (command_name == Fix.DEMONIC_IGNITE) { return Attribute.Magic; }
    // 闇＋氷
    if (command_name == Fix.DEEP_MIRROR) { return Attribute.Magic; }
    if (command_name == Fix.STORM_SHARD) { return Attribute.Magic; }
    if (command_name == Fix.ABYSS_EYE) { return Attribute.Magic; }
    // 闇＋理
    if (command_name == Fix.WORD_OF_MALICE) { return Attribute.Magic; }
    if (command_name == Fix.SIN_FORTUNE) { return Attribute.Magic; }
    if (command_name == Fix.BLOOD_SHACKLE) { return Attribute.Magic; }
    // 闇＋空唱
    if (command_name == Fix.ACHROMA_BLAST) { return Attribute.Magic; }
    if (command_name == Fix.DOOM_BLADE) { return Attribute.Magic; }
    if (command_name == Fix.ECLIPSE_END) { return Attribute.Magic; }
    // 炎＋氷 [完全逆]
    if (command_name == Fix.CHILL_BURN) { return Attribute.Magic; }
    if (command_name == Fix.SWORD_OF_FREEZING_FIRE) { return Attribute.Magic; }
    if (command_name == Fix.ZETA_EXPLOSION) { return Attribute.Magic; }
    // 炎＋理
    if (command_name == Fix.BURST_INFERNO) { return Attribute.Magic; }
    if (command_name == Fix.PIERCING_FLAME) { return Attribute.Magic; }
    if (command_name == Fix.SIGIL_OF_HOMURA) { return Attribute.Magic; }
    // 炎＋空唱
    if (command_name == Fix.ERRATIC_THUNDERBOLT) { return Attribute.Magic; }
    if (command_name == Fix.STEAM_MIRROR) { return Attribute.Magic; }
    if (command_name == Fix.RED_DRAGON_WILL) { return Attribute.Magic; }
    // 氷＋理
    if (command_name == Fix.WORD_OF_ATTITUDE) { return Attribute.Magic; }
    if (command_name == Fix.ICICLE_BARRIER) { return Attribute.Magic; }
    if (command_name == Fix.AUSTERITY_MATRIX) { return Attribute.Magic; }
    // 氷＋空唱
    if (command_name == Fix.GLACIAL_CIRCLE) { return Attribute.Magic; }
    if (command_name == Fix.VORTEX_SONG) { return Attribute.Magic; }
    if (command_name == Fix.BLUE_DRAGON_WILL) { return Attribute.Magic; }
    // 理＋空唱 [完全逆]
    if (command_name == Fix.WORD_OF_NINE) { return Attribute.Magic; }
    if (command_name == Fix.PARADOX_IMAGE) { return Attribute.Magic; }
    if (command_name == Fix.WARP_GATE) { return Attribute.Magic; }
    #endregion

    #region "複合スキル"
    // 戦士＋護衛 [完全逆]
    if (command_name == Fix.NEUTRAL_SMASH) { return Attribute.Skill; }
    if (command_name == Fix.STANCE_OF_DOUBLE) { return Attribute.Skill; }
    // 戦士＋格闘
    if (command_name == Fix.BLITZ_STRIKE) { return Attribute.Skill; }
    if (command_name == Fix.ASSASSINATION_HIT) { return Attribute.Skill; }
    // 戦士＋弓術
    if (command_name == Fix.PHOENIX_EYE) { return Attribute.Skill; }
    if (command_name == Fix.HARDENED_INSIGHT) { return Attribute.Skill; }
    // 戦士＋心眼
    if (command_name == Fix.CHALLENGING_SHOUT) { return Attribute.Skill; }
    if (command_name == Fix.ONSLAUGHT_HIT) { return Attribute.Skill; }
    // 戦士＋無心
    if (command_name == Fix.FORMLESS_STYLE) { return Attribute.Skill; }
    if (command_name == Fix.HARDEST_PARRY) { return Attribute.Skill; }
    // 護衛＋格闘
    if (command_name == Fix.TACTICAL_VISION) { return Attribute.Skill; }
    if (command_name == Fix.SWIFT_RESPONSE) { return Attribute.Skill; }
    // 護衛＋弓術
    if (command_name == Fix.RIGHTEOUSNESS_ARROW) { return Attribute.Skill; }
    if (command_name == Fix.PERFECT_EVASION) { return Attribute.Skill; }
    // 護衛＋心眼
    if (command_name == Fix.REFLEX_ESSENCE) { return Attribute.Skill; }
    if (command_name == Fix.SELF_PERSUASION) { return Attribute.Skill; }
    // 護衛＋無心
    if (command_name == Fix.TRUST_SILENCE) { return Attribute.Skill; }
    if (command_name == Fix.NOURISH_POWER) { return Attribute.Skill; }
    // 格闘＋弓術 [完全逆]
    if (command_name == Fix.SUDDEN_STRIKEARROW) { return Attribute.Skill; }
    if (command_name == Fix.STANCE_OF_MYSTIC) { return Attribute.Skill; }
    // 格闘＋心眼
    if (command_name == Fix.PSYCHIC_WAVE) { return Attribute.Skill; }
    if (command_name == Fix.FLARE_OF_FIGHTING) { return Attribute.Skill; }
    // 格闘＋無心
    if (command_name == Fix.INFINITY_IMAGE) { return Attribute.Skill; }
    if (command_name == Fix.UNIFIED_CONVICTION) { return Attribute.Skill; }
    // 弓術＋心眼
    if (command_name == Fix.ABSOLUTE_ARROW) { return Attribute.Skill; }
    if (command_name == Fix.HEAVENS_WISDOM) { return Attribute.Skill; }
    // 弓術＋無心
    if (command_name == Fix.SILENT_MEDITATION) { return Attribute.Skill; }
    if (command_name == Fix.COLORLESS_FORM) { return Attribute.Skill; }
    // 心眼＋無心 [完全逆]
    if (command_name == Fix.OVERWHELMING_DESTINY) { return Attribute.Skill; }
    if (command_name == Fix.WORLD_CHANT) { return Attribute.Skill; }
    #endregion

    #region "Archetype"
    if (command_name == Fix.ARCHETYPE_EIN_1) { return Attribute.Archetype; }
    #endregion

    #region "other"
    if (command_name == Fix.AIR_CUTTER) { return Attribute.Magic; }
    if (command_name == Fix.ROCK_SLAM) { return Attribute.Magic; }
    if (command_name == Fix.VENOM_SLASH) { return Attribute.Skill; }
    if (command_name == Fix.AURA_OF_POWER) { return Attribute.Magic; }
    if (command_name == Fix.HEART_OF_LIFE) { return Attribute.Skill; }
    if (command_name == Fix.DARKNESS_CIRCLE) { return Attribute.Skill; }
    if (command_name == Fix.STORM_ARMOR) { return Attribute.Magic; }
    if (command_name == Fix.SOLID_WALL) { return Attribute.Magic; }
    if (command_name == Fix.INVISIBLE_BIND) { return Attribute.Skill; }
    if (command_name == Fix.IDEOLOGY_OF_SOPHISTICATION) { return Attribute.Skill; }
    if (command_name == Fix.SKY_SHIELD) { return Attribute.Magic; }
    if (command_name == Fix.STANCE_OF_THE_SHADE) { return Attribute.Skill; }
    if (command_name == Fix.SONIC_PULSE) { return Attribute.Magic; }
    if (command_name == Fix.LAND_SHATTER) { return Attribute.Magic; }
    if (command_name == Fix.MUTE_IMPULSE) { return Attribute.Magic; }
    if (command_name == Fix.IRREGULAR_STEP) { return Attribute.Skill; }
    if (command_name == Fix.AETHER_DRIVE) { return Attribute.Skill; }
    if (command_name == Fix.KILLING_WAVE) { return Attribute.Skill; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return Attribute.Skill; }

    if (command_name == Fix.COMMAND_HIKKAKI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_KANAKIRI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WILD_CLAW) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_KAMITSUKI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TREE_SONG) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUN_FIRE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TOSSHIN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FEATHER_WING) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DASH_KERI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUITSUKU_TSUTA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SPIDER_NET) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_POISON_KOKE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CONTINUOUS_ATTACK) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FIRE_EMISSION) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUPER_TOSSHIN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_POISON_RINPUN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_YOUEN_FIRE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLAZE_DANCE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DRILL_CYCLONE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RUMBLE_MACHINEGUN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STRUGGLE_VOICE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GAREKI_TSUBUTE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SHADOW_SPEAR) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MIDARE_GIRI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STINKY_BREATH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MIRROR_SHIELD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HAND_CANNON) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SAIMIN_DANCE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_POISON_NEEDLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CHARGE_LANCE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SPIKE_SHOT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_JUBAKU_ON) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ZINARI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BOUHATSU) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_THUNDER_CLOUD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SURUDOI_HIKKAKI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HAGESHII_KAMITSUKI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BOLT_FRAME) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BOOOOMB) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STONE_RAIN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TARGETTING_SHOT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_POWERED_ATTACK) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUSPICIOUS_VIAL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SPAAAARK) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUPER_RANDOM_CANNON) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ELECTRO_RAILGUN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_LIGHTNING_OUTBURST) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WILD_STORM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_YOUKAIEKI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_POISON_TONGUE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CONSTRICT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TAIATARI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WINDFLARE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_EARTHBOLT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SILENT_SHOT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PHANTOM_SONG) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ENRAGE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SPLASH_HARMONY) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RANBOU_CHARGE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BEAST_STRIKE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_KONSHIN_TOKKAN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HUHAI_SINKOU) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STRONG_SLASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SHADOW_MIST) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ROCK_THROW) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_YOUEN_KISS) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_POISON_SPORE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GROUND_RUMBLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FIRE_BLAST) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RENSOU_TOSSHIN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_VERDANT_VOICE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLACK_SPORE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_KILL_SPINNING_LANCER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WING_BLADE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STONE_BLAW) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HUMIOROSI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SQUALL_LIGHTNING) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SIPPUUKEN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BRIGHTNESS_RINPUN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SHIROGANE_HORN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_VISIBLE_EYE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_INVISIBLE_EYE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WIND_CUTTER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLUE_LAVA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLUE_BUBBLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WHITE_LAVA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WHITE_BUBBLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_REFLECTION_SHADE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ICHIMAI_GUARDWALL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MULTIPLE_FEATHER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BRIGHT_FLASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CYCLONE_SHOT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MORPH_VANISH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ROD_AGARTHA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SWORD_MAHOROBA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FEROCIOUS_THUNDER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RAGING_CLAW) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CLEANSING_LIGHT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FAITH_SIGHT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SAMAYOU_HAND) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SEIIN_FOOTPRINT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_LIGHT_THUNDERBOLT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CYCLONE_ARMOR) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FURY_TRIDENT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HEAVEN_THUNDER_SPEAR) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_OVERRUN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GLARE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ARC_BLASTER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DRAGON_BREATH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RENZOKU_BAKUHATSU) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_AIUCHI_NERAI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HIDDEN_KNIFE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MYSTICAL_FIELD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SEIKUU_GUARDWALL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_THUNDERCLOUD_INVASION) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MIST_BARRIER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUN_SLAYER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TRIPLE_TACTICS) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WIND_ARROW) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TYPHOON) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TAIKI_VANISH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HARD_CHARGE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RAMPAGE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ICE_BURN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FROST_SHARD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DOKAAAAN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RENSYA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ERRATIC_EXPLODE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CYCLONE_FIELD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ICE_RAY) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CLEANSING_LANCE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STATUS_CHANGE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DEATH_DANCE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HEAVEN_VOICE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PLASMA_STORM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_APOCALYPSE_SWORD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WATER_GUN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WATER_DANCE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WATER_SHOT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SKY_FEATHER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RAINBOW_BUBBLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WATER_CIRCLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ROLLING_CHARGE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_JET_RUN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_INVISIBLE_POISON) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BEAUTY_AROMA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_AQUA_BLOSSOM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DEATH_STROKE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DEVIL_EMBLEM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DEVILSPEAR_MISTELTEN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_COLD_WIND) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PARALYZE_TENTACLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SCREAMING_SOUND) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_KUROZUMI_FIELD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HAGAIZIME) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SOLID_SQUARE_WATER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BRIGHT_EYE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_AXE_DRIVER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_EARTH_CLAP) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STONE_KOURA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DAIBOUSOU) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_JUMP_SMASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STRANGE_SPELL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_THROWING_CRASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BAIRIKI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_NAGITAOSHI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WASHIZUKAMI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ZINARASHI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUIKOMI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_EIGHT_ALL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SCARLET_SEED) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_POISON_GERMINATION) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WAVE_SIGN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SILENT_SIGN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HIKKAKI_CLAW) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BATTLE_DANCE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DRAIN_WEB) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SAND_SMOKE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GUT_SLASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GUARDIAN_SONG) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WATER_FLAPPING) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_INVISIBLE_THREAD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_INTENSE_BREATH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BIG_SWIM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ROAR) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BITING) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HOLLOW_MIST) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_POLLUTED_POISON) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BUBBLE_BULLET) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_AMBUSH_ATTACK) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GROUND_THUNDER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CONTINUOUS_CHARGE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STAR_EMBLEM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MUD_PISTOL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RIPPER_CLAW) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HIKICHIGIRI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RUBBER_TONG) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SPANNING_SLASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STARSWORD_KAI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SEASTAR_EYE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WATER_CANNON) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PROTECTION_SEAL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLOODSHOT_EYE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FRENZY_DRIVE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_THOUGHT_EATER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_VACUUM_SHOT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PHANTOM_EATER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GHOST_KILL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ZERO_ATTACK) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_JU_STYLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CLEANSING_SONG) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WASH_AWAY) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CHARGE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SEA_STRIVE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLINK_SHELL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PLATINUM_BLADE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SEASTAR_OATH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_JEWEL_BREAK) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STAR_DUST) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STARSWORD_KIRAMEKI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BARRIER_FIELD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CIRCULAR_SLASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TORPEDO_BUSTER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STAR_FALL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STARSWORD_TSUYA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_INVASION_FIELD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ILLUSION_BOLT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_VORTEX_BLAST) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FIRE_BULLET) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLAZING_STORM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FLARE_BURN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FIRE_WALL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PENETRATION_EYE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FROZEN_BULLET) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FREEZING_STORM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUDDEN_SQUALL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WATER_BUBBLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HALLUCINATE_EYE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BRAVE_ROAR) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SEASLIDE_WATER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GUNGNIR_SLASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ISONIC_WAVE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GUNGNIR_LIGHT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_LIFE_WATER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SALMAN_CHANT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ANDATE_CHANT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ELEMENTAL_SPLASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BYAKURAN_FROZEN_ART) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SEASTAR_ORIGIN_SEAL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SOUMEI_SEISOU_KEN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SEASTARKING_ROAR) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BURST_CLOUD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TIDAL_WAVE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SURGETIC_BIND) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HUGE_SHOCKWAVE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BACKSTAB_ARROW) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_KARAME_BIND) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BEAST_SPIRIT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BEAST_HOUND) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DATOTSU) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ASSASSIN_POISONNEEDLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SAINT_SLASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DEMON_CONTRACT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DARKM_SPELL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HELLFIRE_SPELL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RENZOKU_HOUSYA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STEAM_ARROW) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLACKDRAGON_WHISPER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DEATH_HAITOKU) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUPERIOR_FIELD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SHINDOWKEN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DEATH_STRIKE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SOUL_FROZEN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CURSED_THREAD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HORROR_VISION) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RASEN_KOKUEN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_RANSO_RENGEKI) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DEMON_BOLT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ARCANE_DESTRUCTION) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TOWER_FALL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ROUND_DIVIDE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLACK_FLARE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SATELLITE_SWORD) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SIGIL_OF_SUN_FALLEN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_LIFE_BRILLIANT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ALL_DUST) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_LVEL_SONG) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GIGANT_SLAYER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_JUONSATSU) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ABYSS_LOGIC) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BONE_TORNADO) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_OMINOUS_LAUGH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SKULL_CRASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_WAZAWAI_FLAME) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_THE_END) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HELLFLAME_BULLET) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CHROMATIC_BULLET) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SUPER_MAX_WAVE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_IRREGULAR_REGENERATION) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ETERNAL_CIRCLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DESTRUCTION_CIRCLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PERFECT_STOP) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SPECTOR_VOICE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_NOMERCY_SCREAM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DARK_SIMULACRUM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FABRIOLE_SPEAR) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_REST_IN_DREAM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DANCING_LANCER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CHAOS_DEATHPERADE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MARIA_DANSEL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DESTRUCT_TUNING) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GROUND_CRACK) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLACK_DARK_LANCE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_UNDEAD_WISH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HELL_CIRCLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_INNOCENT_SLASH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HARSH_CUTTER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_JUDGEMENT_LIGHTNING) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BLACKHOLE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ERROR_OCCUR) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FUMBLE_SIGN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_AREA_TWIST) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PARADOXICAL_SLICER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_OAHN_VOICE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MOMENT_MAGIC) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DESPIAR_RAIN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SWORD_OF_WIND) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SKY_CUTTER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SONIC_BLADE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SCREAMING_FROM_VOICE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_DESPAIR_SPEAR) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_KUUKAN_MATEN) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_METEOR_STORM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_CROSS_GATE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PRISMATIC_BULLET) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PHOTON_LASER) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_SEALED_STONE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_OUT_OF_CONTROL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_POWER_EXPLOSION) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PERFECT_HIT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_FUSION_CHARGE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_LEGION_DRIVE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_BERSERKER_RUSH) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_GOLDEN_MATRIX) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_METSU_INCARNATION) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_THOUSAND_SQUALL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_AURORA_BLADE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_MEGIDO_BLAZE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ABYSS_WILL) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ONE_HOMURA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ABYSS_FIRE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ETERNAL_DROPLET) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_AUSTERITY_MATRIX_OMEGA) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_VOID_BEAT) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_PERFECT_PROPHECY) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_HOLY_WISDOM) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ETERNAL_PRESENCE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_ULTIMATE_FLARE) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_TIME_EXPANSION) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STARSWORD_ZETSU) { return Attribute.MonsterAction; }
    if (command_name == Fix.COMMAND_STARSWORD_ZETSU_HOMURA) { return Attribute.MonsterAction; }
    if (command_name == "絶望の魔手") { return Attribute.MonsterAction; }
    #endregion

    return Attribute.None;
  }

  public static TimingType GetTiming(string command_name)
  {
    #region "基本／一般"
    if (command_name == Fix.NORMAL_ATTACK) { return TimingType.Normal; } // 通常攻撃はインスタント行動できない。
    if (command_name == Fix.MAGIC_ATTACK) { return TimingType.Normal; } // 通常攻撃はインスタント行動できない。
    if (command_name == Fix.DEFENSE) { return TimingType.Instant; } // 防御姿勢はインスタント行動できる。
    if (command_name == Fix.STAY) { return TimingType.Instant; } // STAYはインスタント行動できる。
    if (command_name == Fix.USE_RED_POTION_1) { return TimingType.Instant; }
    if (command_name == Fix.USE_RED_POTION_2) { return TimingType.Instant; }
    if (command_name == Fix.USE_RED_POTION_3) { return TimingType.Instant; }
    if (command_name == Fix.USE_RED_POTION_4) { return TimingType.Instant; }
    if (command_name == Fix.USE_RED_POTION_5) { return TimingType.Instant; }
    if (command_name == Fix.USE_RED_POTION_6) { return TimingType.Instant; }
    if (command_name == Fix.USE_RED_POTION_7) { return TimingType.Instant; }
    if (command_name == Fix.USE_BLUE_POTION_1) { return TimingType.Instant; }
    if (command_name == Fix.USE_BLUE_POTION_2) { return TimingType.Instant; }
    if (command_name == Fix.USE_BLUE_POTION_3) { return TimingType.Instant; }
    if (command_name == Fix.USE_BLUE_POTION_4) { return TimingType.Instant; }
    if (command_name == Fix.USE_BLUE_POTION_5) { return TimingType.Instant; }
    if (command_name == Fix.USE_BLUE_POTION_6) { return TimingType.Instant; }
    if (command_name == Fix.USE_BLUE_POTION_7) { return TimingType.Instant; }
    #endregion

    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return TimingType.Instant; }
    if (command_name == Fix.ICE_NEEDLE) { return TimingType.Instant; }
    if (command_name == Fix.FRESH_HEAL) { return TimingType.Instant; }
    if (command_name == Fix.SHADOW_BLAST) { return TimingType.Instant; }
    if (command_name == Fix.ORACLE_COMMAND) { return TimingType.Instant; }
    if (command_name == Fix.ENERGY_BOLT) { return TimingType.Instant; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return TimingType.Instant; }
    if (command_name == Fix.SHIELD_BASH) { return TimingType.Normal; }
    if (command_name == Fix.LEG_STRIKE) { return TimingType.Instant; }
    if (command_name == Fix.HUNTER_SHOT) { return TimingType.Instant; }
    if (command_name == Fix.TRUE_SIGHT) { return TimingType.Instant; }
    if (command_name == Fix.DISPEL_MAGIC) { return TimingType.Instant; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return TimingType.Instant; }
    if (command_name == Fix.PURE_PURIFICATION) { return TimingType.Instant; }
    if (command_name == Fix.DIVINE_CIRCLE) { return TimingType.Normal; }
    if (command_name == Fix.BLOOD_SIGN) { return TimingType.Instant; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return TimingType.Instant; }
    if (command_name == Fix.FLASH_COUNTER) { return TimingType.StackCommand; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return TimingType.Instant; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return TimingType.Normal; }
    if (command_name == Fix.SPEED_STEP) { return TimingType.Instant; }
    if (command_name == Fix.MULTIPLE_SHOT) { return TimingType.Normal; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return TimingType.Normal; }
    if (command_name == Fix.SPIRITUAL_REST) { return TimingType.Instant; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return TimingType.Instant; }
    if (command_name == Fix.BLUE_BULLET) { return TimingType.Instant; }
    if (command_name == Fix.HOLY_BREATH) { return TimingType.Normal; }
    if (command_name == Fix.BLACK_CONTRACT) { return TimingType.Normal; }
    if (command_name == Fix.WORD_OF_POWER) { return TimingType.Instant; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return TimingType.Instant; }
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return TimingType.Instant; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return TimingType.Instant; }
    if (command_name == Fix.BONE_CRUSH) { return TimingType.Instant; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return TimingType.Normal; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return TimingType.Normal; }
    if (command_name == Fix.UNSEEN_AID) { return TimingType.Instant; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return TimingType.Normal; }
    if (command_name == Fix.FREEZING_CUBE) { return TimingType.Normal; }
    if (command_name == Fix.ANGELIC_ECHO) { return TimingType.Normal; }
    if (command_name == Fix.CURSED_EVANGILE) { return TimingType.Instant; }
    if (command_name == Fix.GALE_WIND) { return TimingType.Instant; }
    if (command_name == Fix.PHANTOM_OBORO) { return TimingType.Instant; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return TimingType.Instant; }
    if (command_name == Fix.DOMINATION_FIELD) { return TimingType.Normal; }
    if (command_name == Fix.DEADLY_DRIVE) { return TimingType.Instant; }
    if (command_name == Fix.PENETRATION_ARROW) { return TimingType.Instant; }
    if (command_name == Fix.WILL_AWAKENING) { return TimingType.Instant; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return TimingType.Instant; }
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return TimingType.Normal; }
    if (command_name == Fix.FROST_LANCE) { return TimingType.Normal; }
    if (command_name == Fix.SHINING_HEAL) { return TimingType.Sorcery; }
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return TimingType.Normal; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return TimingType.Normal; }
    if (command_name == Fix.COUNTER_DISALLOW) { return TimingType.StackCommand; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return TimingType.Normal; }
    if (command_name == Fix.HARDEST_PARRY) { return TimingType.StackCommand; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return TimingType.Instant; }
    if (command_name == Fix.PRECISION_STRIKE) { return TimingType.StackCommand; }
    if (command_name == Fix.EVERFLOW_MIND) { return TimingType.Normal; }
    if (command_name == Fix.INNER_INSPIRATION) { return TimingType.Instant; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return TimingType.Normal; }
    if (command_name == Fix.WATER_PRESENCE) { return TimingType.Instant; }
    if (command_name == Fix.VALKYRIE_BLADE) { return TimingType.Normal; }
    if (command_name == Fix.THE_DARK_INTENSITY) { return TimingType.Instant; }
    if (command_name == Fix.FUTURE_VISION) { return TimingType.Instant; }
    if (command_name == Fix.DETACHMENT_FAULT) { return TimingType.Instant; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return TimingType.Normal; }
    if (command_name == Fix.ONE_IMMUNITY) { return TimingType.Instant; }
    if (command_name == Fix.STANCE_OF_MUIN) { return TimingType.Normal; }
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return TimingType.Instant; }
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return TimingType.Instant; }
    if (command_name == Fix.ZERO_IMMUNITY) { return TimingType.Instant; }
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return TimingType.Sorcery; }
    if (command_name == Fix.ABSOLUTE_ZERO) { return TimingType.Sorcery; }
    if (command_name == Fix.RESURRECTION) { return TimingType.Sorcery; }
    if (command_name == Fix.DEATH_SCYTHE) { return TimingType.Sorcery; }
    if (command_name == Fix.GENESIS) { return TimingType.Instant; }
    if (command_name == Fix.TIME_SKIP) { return TimingType.Instant; }
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return TimingType.Sorcery; }
    if (command_name == Fix.CATASTROPHE) { return TimingType.Sorcery; }
    if (command_name == Fix.CARNAGE_RUSH) { return TimingType.Sorcery; }
    if (command_name == Fix.PIERCING_ARROW) { return TimingType.Sorcery; }
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return TimingType.Normal; }
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return TimingType.Instant; }
    #endregion

    #region "複合魔法"
    // 聖＋闇 [完全逆]
    if (command_name == Fix.PSYCHIC_TRANCE) { return TimingType.Instant; }
    if (command_name == Fix.BLIND_JUSTICE) { return TimingType.Instant; }
    if (command_name == Fix.DEATH_DENY) { return TimingType.Instant; }
    // 聖＋炎
    if (command_name == Fix.FLASH_BLAZE) { return TimingType.Instant; }
    if (command_name == Fix.LIGHT_DETONATOR) { return TimingType.Instant; }
    if (command_name == Fix.ASCENDANT_METEOR) { return TimingType.Sorcery; }
    // 聖＋氷
    if (command_name == Fix.SKY_SHIELD) { return TimingType.Sorcery; }
    if (command_name == Fix.SACRED_FIELD) { return TimingType.Sorcery; }
    if (command_name == Fix.SAINT_JUDGEMENT) { return TimingType.Instant; }
    // 聖＋理
    if (command_name == Fix.HOLY_BREAKER) { return TimingType.Sorcery; }
    if (command_name == Fix.EXALTED_FIELD) { return TimingType.Sorcery; }
    if (command_name == Fix.HYMN_CONTRACT) { return TimingType.Sorcery; }
    // 聖＋空唱
    if (command_name == Fix.VOID_THUNDER) { return TimingType.Normal; }
    if (command_name == Fix.ANGEL_INTERVENTION) { return TimingType.Sorcery; }
    if (command_name == Fix.ENDLESS_ANTHEM) { return TimingType.Sorcery; }
    // 闇＋炎
    if (command_name == Fix.BLACK_FIRE) { return TimingType.Instant; }
    if (command_name == Fix.BLAZING_FIELD) { return TimingType.Normal; }
    if (command_name == Fix.DEMONIC_IGNITE) { return TimingType.Instant; }
    // 闇＋氷
    if (command_name == Fix.DEEP_MIRROR) { return TimingType.StackCommand; }
    if (command_name == Fix.STORM_SHARD) { return TimingType.Instant; }
    if (command_name == Fix.ABYSS_EYE) { return TimingType.Normal; }
    // 闇＋理
    if (command_name == Fix.WORD_OF_MALICE) { return TimingType.Instant; }
    if (command_name == Fix.SIN_FORTUNE) { return TimingType.Instant; }
    if (command_name == Fix.BLOOD_SHACKLE) { return TimingType.Normal; }
    // 闇＋空唱
    if (command_name == Fix.ACHROMA_BLAST) { return TimingType.Instant; }
    if (command_name == Fix.DOOM_BLADE) { return TimingType.Normal; }
    if (command_name == Fix.ECLIPSE_END) { return TimingType.Sorcery; }
    // 炎＋氷 [完全逆]
    if (command_name == Fix.CHILL_BURN) { return TimingType.Instant; }
    if (command_name == Fix.SWORD_OF_FREEZING_FIRE) { return TimingType.Normal; }
    if (command_name == Fix.ZETA_EXPLOSION) { return TimingType.Sorcery; }
    // 炎＋理
    if (command_name == Fix.BURST_INFERNO) { return TimingType.Sorcery; }
    if (command_name == Fix.PIERCING_FLAME) { return TimingType.Instant; }
    if (command_name == Fix.SIGIL_OF_HOMURA) { return TimingType.Instant; }
    // 炎＋空唱
    if (command_name == Fix.ERRATIC_THUNDERBOLT) { return TimingType.Instant; }
    if (command_name == Fix.STEAM_MIRROR) { return TimingType.Instant; }
    if (command_name == Fix.RED_DRAGON_WILL) { return TimingType.Instant; }
    // 氷＋理
    if (command_name == Fix.WORD_OF_ATTITUDE) { return TimingType.Instant; }
    if (command_name == Fix.ICICLE_BARRIER) { return TimingType.Instant; }
    if (command_name == Fix.AUSTERITY_MATRIX) { return TimingType.Sorcery; }
    // 氷＋空唱
    if (command_name == Fix.GLACIAL_CIRCLE) { return TimingType.StackCommand; }
    if (command_name == Fix.VORTEX_SONG) { return TimingType.StackCommand; }
    if (command_name == Fix.BLUE_DRAGON_WILL) { return TimingType.Instant; }
    // 理＋空唱 [完全逆]
    if (command_name == Fix.WORD_OF_NINE) { return TimingType.Normal; }
    if (command_name == Fix.PARADOX_IMAGE) { return TimingType.Instant; }
    if (command_name == Fix.WARP_GATE) { return TimingType.Instant; }
    #endregion

    #region "複合スキル"
    // 戦士＋護衛 [完全逆]
    if (command_name == Fix.NEUTRAL_SMASH) { return TimingType.Instant; }
    if (command_name == Fix.STANCE_OF_DOUBLE) { return TimingType.Sorcery; }
    // 戦士＋格闘
    if (command_name == Fix.BLITZ_STRIKE) { return TimingType.StackCommand; }
    if (command_name == Fix.ASSASSINATION_HIT) { return TimingType.Instant; }
    // 戦士＋弓術
    if (command_name == Fix.PHOENIX_EYE) { return TimingType.Normal; }
    if (command_name == Fix.HARDENED_INSIGHT) { return TimingType.Normal; }
    // 戦士＋心眼
    if (command_name == Fix.CHALLENGING_SHOUT) { return TimingType.Instant; }
    if (command_name == Fix.ONSLAUGHT_HIT) { return TimingType.Instant; }
    // 戦士＋無心
    if (command_name == Fix.FORMLESS_STYLE) { return TimingType.StackCommand; }
    if (command_name == Fix.HARDEST_PARRY) { return TimingType.StackCommand; }
    // 護衛＋格闘
    if (command_name == Fix.TACTICAL_VISION) { return TimingType.Sorcery; }
    if (command_name == Fix.SWIFT_RESPONSE) { return TimingType.StackCommand; }
    // 護衛＋弓術
    if (command_name == Fix.RIGHTEOUSNESS_ARROW) { return TimingType.Instant; }
    if (command_name == Fix.PERFECT_EVASION) { return TimingType.StackCommand; }
    // 護衛＋心眼
    if (command_name == Fix.REFLEX_ESSENCE) { return TimingType.Instant; }
    if (command_name == Fix.SELF_PERSUASION) { return TimingType.Instant; }
    // 護衛＋無心
    if (command_name == Fix.TRUST_SILENCE) { return TimingType.Instant; }
    if (command_name == Fix.NOURISH_POWER) { return TimingType.Instant; }
    // 格闘＋弓術 [完全逆]
    if (command_name == Fix.SUDDEN_STRIKEARROW) { return TimingType.Instant; }
    if (command_name == Fix.STANCE_OF_MYSTIC) { return TimingType.Instant; }
    // 格闘＋心眼
    if (command_name == Fix.PSYCHIC_WAVE) { return TimingType.Instant; }
    if (command_name == Fix.FLARE_OF_FIGHTING) { return TimingType.Normal; }
    // 格闘＋無心
    if (command_name == Fix.INFINITY_IMAGE) { return TimingType.Instant; }
    if (command_name == Fix.UNIFIED_CONVICTION) { return TimingType.Sorcery; }
    // 弓術＋心眼
    if (command_name == Fix.ABSOLUTE_ARROW) { return TimingType.Instant; }
    if (command_name == Fix.HEAVENS_WISDOM) { return TimingType.Normal; }
    // 弓術＋無心
    if (command_name == Fix.SILENT_MEDITATION) { return TimingType.Instant; }
    if (command_name == Fix.COLORLESS_FORM) { return TimingType.Normal; }
    // 心眼＋無心 [完全逆]
    if (command_name == Fix.OVERWHELMING_DESTINY) { return TimingType.StackCommand; }
    if (command_name == Fix.WORLD_CHANT) { return TimingType.Sorcery; }
    #endregion

    #region "Archetype"
    if (command_name == Fix.ARCHETYPE_EIN_1) { return TimingType.Archetype; }
    #endregion

    #region "Other"
    if (command_name == Fix.AIR_CUTTER) { return TimingType.Instant; }
    if (command_name == Fix.ROCK_SLAM) { return TimingType.Instant; }
    if (command_name == Fix.VENOM_SLASH) { return TimingType.Instant; }
    if (command_name == Fix.AURA_OF_POWER) { return TimingType.Instant; }
    if (command_name == Fix.HEART_OF_LIFE) { return TimingType.Instant; }
    if (command_name == Fix.DARKNESS_CIRCLE) { return TimingType.Normal; }
    if (command_name == Fix.STORM_ARMOR) { return TimingType.Instant; }
    if (command_name == Fix.SOLID_WALL) { return TimingType.Instant; }
    if (command_name == Fix.INVISIBLE_BIND) { return TimingType.Instant; }
    if (command_name == Fix.IDEOLOGY_OF_SOPHISTICATION) { return TimingType.Normal; }
    if (command_name == Fix.SKY_SHIELD) { return TimingType.Instant; }
    if (command_name == Fix.STANCE_OF_THE_SHADE) { return TimingType.Normal; }
    if (command_name == Fix.SONIC_PULSE) { return TimingType.Instant; }
    if (command_name == Fix.LAND_SHATTER) { return TimingType.Instant; }
    if (command_name == Fix.MUTE_IMPULSE) { return TimingType.Instant; }
    if (command_name == Fix.AETHER_DRIVE) { return TimingType.Normal; }
    if (command_name == Fix.KILLING_WAVE) { return TimingType.Normal; }
    if (command_name == Fix.IRREGULAR_STEP) { return TimingType.Instant; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return TimingType.Instant; }
    #endregion

    return TimingType.None; // 未設定やイレギュラーなものはデフォルトでは使用不可とする。
  }

  public static TargetType IsTarget(string command_name)
  {
    #region "基本／一般"
    if (command_name == Fix.NORMAL_ATTACK) { return TargetType.Enemy; }
    if (command_name == Fix.MAGIC_ATTACK) { return TargetType.Enemy; }
    if (command_name == Fix.DEFENSE) { return TargetType.Own; }
    if (command_name == Fix.STAY) { return TargetType.Own; }
    if (command_name == Fix.USE_RED_POTION_1) { return TargetType.Ally; }
    if (command_name == Fix.USE_RED_POTION_2) { return TargetType.Ally; }
    if (command_name == Fix.USE_RED_POTION_3) { return TargetType.Ally; }
    if (command_name == Fix.USE_RED_POTION_4) { return TargetType.Ally; }
    if (command_name == Fix.USE_RED_POTION_5) { return TargetType.Ally; }
    if (command_name == Fix.USE_RED_POTION_6) { return TargetType.Ally; }
    if (command_name == Fix.USE_RED_POTION_7) { return TargetType.Ally; }
    if (command_name == Fix.USE_BLUE_POTION_1) { return TargetType.Ally; }
    if (command_name == Fix.USE_BLUE_POTION_2) { return TargetType.Ally; }
    if (command_name == Fix.USE_BLUE_POTION_3) { return TargetType.Ally; }
    if (command_name == Fix.USE_BLUE_POTION_4) { return TargetType.Ally; }
    if (command_name == Fix.USE_BLUE_POTION_5) { return TargetType.Ally; }
    if (command_name == Fix.USE_BLUE_POTION_6) { return TargetType.Ally; }
    if (command_name == Fix.USE_BLUE_POTION_7) { return TargetType.Ally; }
    #endregion

    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return TargetType.Enemy; }
    if (command_name == Fix.ICE_NEEDLE) { return TargetType.Enemy; }
    if (command_name == Fix.FRESH_HEAL) { return TargetType.Ally; }
    if (command_name == Fix.SHADOW_BLAST) { return TargetType.Enemy; }
    if (command_name == Fix.ORACLE_COMMAND) { return TargetType.Ally; }
    if (command_name == Fix.ENERGY_BOLT) { return TargetType.Enemy; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return TargetType.Enemy; }
    if (command_name == Fix.SHIELD_BASH) { return TargetType.Enemy; }
    if (command_name == Fix.LEG_STRIKE) { return TargetType.Enemy; }
    if (command_name == Fix.HUNTER_SHOT) { return TargetType.Enemy; }
    if (command_name == Fix.TRUE_SIGHT) { return TargetType.Ally; }
    if (command_name == Fix.DISPEL_MAGIC) { return TargetType.Enemy; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return TargetType.Ally; }
    if (command_name == Fix.PURE_PURIFICATION) { return TargetType.Ally; }
    if (command_name == Fix.DIVINE_CIRCLE) { return TargetType.AllyField; }
    if (command_name == Fix.BLOOD_SIGN) { return TargetType.Enemy; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return TargetType.Ally; }
    if (command_name == Fix.FLASH_COUNTER) { return TargetType.InstantTarget; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return TargetType.Enemy; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return TargetType.Own; }
    if (command_name == Fix.SPEED_STEP) { return TargetType.Enemy; }
    if (command_name == Fix.MULTIPLE_SHOT) { return TargetType.EnemyGroup; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return TargetType.AllyField; }
    if (command_name == Fix.SPIRITUAL_REST) { return TargetType.Ally; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return TargetType.EnemyGroup; }
    if (command_name == Fix.BLUE_BULLET) { return TargetType.Enemy; }
    if (command_name == Fix.HOLY_BREATH) { return TargetType.AllyGroup; }
    if (command_name == Fix.BLACK_CONTRACT) { return TargetType.Own; }
    if (command_name == Fix.WORD_OF_POWER) { return TargetType.Enemy; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return TargetType.EnemyOrAlly; }
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return TargetType.Enemy; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return TargetType.Enemy; }
    if (command_name == Fix.BONE_CRUSH) { return TargetType.Enemy; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return TargetType.Own; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return TargetType.AllyGroup; }
    if (command_name == Fix.UNSEEN_AID) { return TargetType.AllMember; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return TargetType.EnemyGroup; } // + EnemyField
    if (command_name == Fix.FREEZING_CUBE) { return TargetType.Enemy; } // + EnemyField
    if (command_name == Fix.ANGELIC_ECHO) { return TargetType.AllyGroup; } // + AllyField
    if (command_name == Fix.CURSED_EVANGILE) { return TargetType.Enemy; }
    if (command_name == Fix.GALE_WIND) { return TargetType.Own; }
    if (command_name == Fix.PHANTOM_OBORO) { return TargetType.Own; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return TargetType.Enemy; } // + EnemyGroup
    if (command_name == Fix.DOMINATION_FIELD) { return TargetType.AllyField; }
    if (command_name == Fix.DEADLY_DRIVE) { return TargetType.Own; }
    if (command_name == Fix.PENETRATION_ARROW) { return TargetType.Enemy; }
    if (command_name == Fix.WILL_AWAKENING) { return TargetType.Ally; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return TargetType.AllyGroup; } // + AllyField
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return TargetType.Enemy; }
    if (command_name == Fix.FROST_LANCE) { return TargetType.Enemy; }
    if (command_name == Fix.SHINING_HEAL) { return TargetType.Ally; } // + AllyField
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return TargetType.EnemyField; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return TargetType.Ally; }
    if (command_name == Fix.COUNTER_DISALLOW) { return TargetType.InstantTarget; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return TargetType.EnemyGroup; } // + AllyField
    if (command_name == Fix.HARDEST_PARRY) { return TargetType.InstantTarget; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return TargetType.Enemy; }
    if (command_name == Fix.PRECISION_STRIKE) { return TargetType.InstantTarget; }
    if (command_name == Fix.EVERFLOW_MIND) { return TargetType.Ally; }
    if (command_name == Fix.INNER_INSPIRATION) { return TargetType.Ally; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return TargetType.EnemyField; }
    if (command_name == Fix.WATER_PRESENCE) { return TargetType.Ally; }
    if (command_name == Fix.VALKYRIE_BLADE) { return TargetType.Ally; }
    if (command_name == Fix.THE_DARK_INTENSITY) { return TargetType.Ally; }
    if (command_name == Fix.FUTURE_VISION) { return TargetType.Own; } // todo 仮
    if (command_name == Fix.DETACHMENT_FAULT) { return TargetType.EnemyOrAlly; } // todo 仮
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return TargetType.Own; } // todo 仮
    if (command_name == Fix.ONE_IMMUNITY) { return TargetType.Ally; } // todo 仮
    if (command_name == Fix.STANCE_OF_MUIN) { return TargetType.Own; } // todo 仮
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return TargetType.Ally; } // todo 仮
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return TargetType.Ally; } // todo 仮
    if (command_name == Fix.ZERO_IMMUNITY) { return TargetType.Ally; } // todo 仮
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return TargetType.EnemyGroup; } // + EnemyField // todo 仮
    if (command_name == Fix.ABSOLUTE_ZERO) { return TargetType.Enemy; } // todo 仮
    if (command_name == Fix.RESURRECTION) { return TargetType.Ally; }
    if (command_name == Fix.DEATH_SCYTHE) { return TargetType.Enemy; } // todo 仮
    if (command_name == Fix.GENESIS) { return TargetType.Own; }
    if (command_name == Fix.TIME_SKIP) { return TargetType.AllMember; } // todo 仮
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return TargetType.Enemy; } // todo 仮
    if (command_name == Fix.CATASTROPHE) { return TargetType.Enemy; } // todo 仮
    if (command_name == Fix.CARNAGE_RUSH) { return TargetType.Enemy; } // todo 仮
    if (command_name == Fix.PIERCING_ARROW) { return TargetType.Enemy; } // todo 仮
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return TargetType.Own; } // todo 仮
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return TargetType.Ally; } // todo 仮
    #endregion

    #region "複合魔法"
    // 聖＋闇 [完全逆]
    if (command_name == Fix.PSYCHIC_TRANCE) { return TargetType.Ally; }
    if (command_name == Fix.BLIND_JUSTICE) { return TargetType.Ally; }
    if (command_name == Fix.DEATH_DENY) { return TargetType.Ally; }
    // 聖＋炎
    if (command_name == Fix.FLASH_BLAZE) { return TargetType.Enemy; }
    if (command_name == Fix.LIGHT_DETONATOR) { return TargetType.Enemy; }
    if (command_name == Fix.ASCENDANT_METEOR) { return TargetType.EnemyGroup; }
    // 聖＋氷
    if (command_name == Fix.SKY_SHIELD) { return TargetType.Ally; }
    if (command_name == Fix.SACRED_FIELD) { return TargetType.AllyField; }
    if (command_name == Fix.SAINT_JUDGEMENT) { return TargetType.Enemy; }
    // 聖＋理
    if (command_name == Fix.HOLY_BREAKER) { return TargetType.Ally; }
    if (command_name == Fix.EXALTED_FIELD) { return TargetType.AllyField; }
    if (command_name == Fix.HYMN_CONTRACT) { return TargetType.Ally; }
    // 聖＋空唱
    if (command_name == Fix.VOID_THUNDER) { return TargetType.Enemy; }
    if (command_name == Fix.ANGEL_INTERVENTION) { return TargetType.AllyField; }
    if (command_name == Fix.ENDLESS_ANTHEM) { return TargetType.Ally; }
    // 闇＋炎
    if (command_name == Fix.BLACK_FIRE) { return TargetType.Enemy; }
    if (command_name == Fix.BLAZING_FIELD) { return TargetType.EnemyField; }
    if (command_name == Fix.DEMONIC_IGNITE) { return TargetType.Enemy; }
    // 闇＋氷
    if (command_name == Fix.DEEP_MIRROR) { return TargetType.InstantTarget; }
    if (command_name == Fix.STORM_SHARD) { return TargetType.EnemyField; }
    if (command_name == Fix.ABYSS_EYE) { return TargetType.Enemy; }
    // 闇＋理
    if (command_name == Fix.WORD_OF_MALICE) { return TargetType.Enemy; }
    if (command_name == Fix.SIN_FORTUNE) { return TargetType.Own; }
    if (command_name == Fix.BLOOD_SHACKLE) { return TargetType.Enemy; }
    // 闇＋空唱
    if (command_name == Fix.ACHROMA_BLAST) { return TargetType.Enemy; }
    if (command_name == Fix.DOOM_BLADE) { return TargetType.Own; }
    if (command_name == Fix.ECLIPSE_END) { return TargetType.ALLFieldMember; }
    // 炎＋氷 [完全逆]
    if (command_name == Fix.CHILL_BURN) { return TargetType.Enemy; }
    if (command_name == Fix.SWORD_OF_FREEZING_FIRE) { return TargetType.Own; }
    if (command_name == Fix.ZETA_EXPLOSION) { return TargetType.Enemy; }
    // 炎＋理
    if (command_name == Fix.BURST_INFERNO) { return TargetType.EnemyField; }
    if (command_name == Fix.PIERCING_FLAME) { return TargetType.Enemy; }
    if (command_name == Fix.SIGIL_OF_HOMURA) { return TargetType.Enemy; }
    // 炎＋空唱
    if (command_name == Fix.ERRATIC_THUNDERBOLT) { return TargetType.Enemy; }
    if (command_name == Fix.STEAM_MIRROR) { return TargetType.Ally; }
    if (command_name == Fix.RED_DRAGON_WILL) { return TargetType.Ally; }
    // 氷＋理
    if (command_name == Fix.WORD_OF_ATTITUDE) { return TargetType.Ally; }
    if (command_name == Fix.ICICLE_BARRIER) { return TargetType.Ally; }
    if (command_name == Fix.AUSTERITY_MATRIX) { return TargetType.Enemy; }
    // 氷＋空唱
    if (command_name == Fix.GLACIAL_CIRCLE) { return TargetType.InstantTarget; }
    if (command_name == Fix.VORTEX_SONG) { return TargetType.InstantTarget; }
    if (command_name == Fix.BLUE_DRAGON_WILL) { return TargetType.Ally; }
    // 理＋空唱 [完全逆]
    if (command_name == Fix.WORD_OF_NINE) { return TargetType.Ally; }
    if (command_name == Fix.PARADOX_IMAGE) { return TargetType.Own; }
    if (command_name == Fix.WARP_GATE) { return TargetType.Own; }
    #endregion

    #region "複合スキル"
    // 戦士＋護衛 [完全逆]
    if (command_name == Fix.NEUTRAL_SMASH) { return TargetType.Enemy; }
    if (command_name == Fix.STANCE_OF_DOUBLE) { return TargetType.Own; }
    // 戦士＋格闘
    if (command_name == Fix.BLITZ_STRIKE) { return TargetType.InstantTarget; }
    if (command_name == Fix.ASSASSINATION_HIT) { return TargetType.Enemy; }
    // 戦士＋弓術
    if (command_name == Fix.PHOENIX_EYE) { return TargetType.Own; }
    if (command_name == Fix.HARDENED_INSIGHT) { return TargetType.Own; }
    // 戦士＋心眼
    if (command_name == Fix.CHALLENGING_SHOUT) { return TargetType.Own; } // ただし敵全員もある
    if (command_name == Fix.ONSLAUGHT_HIT) { return TargetType.Enemy; }
    // 戦士＋無心
    if (command_name == Fix.FORMLESS_STYLE) { return TargetType.InstantTarget; }
    if (command_name == Fix.HARDEST_PARRY) { return TargetType.InstantTarget; }
    // 護衛＋格闘
    if (command_name == Fix.TACTICAL_VISION) { return TargetType.AllyField; }
    if (command_name == Fix.SWIFT_RESPONSE) { return TargetType.InstantTarget; }
    // 護衛＋弓術
    if (command_name == Fix.RIGHTEOUSNESS_ARROW) { return TargetType.Ally; }
    if (command_name == Fix.PERFECT_EVASION) { return TargetType.InstantTarget; }
    // 護衛＋心眼
    if (command_name == Fix.REFLEX_ESSENCE) { return TargetType.Own; }
    if (command_name == Fix.SELF_PERSUASION) { return TargetType.Ally; }
    // 護衛＋無心
    if (command_name == Fix.TRUST_SILENCE) { return TargetType.Ally; }
    if (command_name == Fix.NOURISH_POWER) { return TargetType.Ally; }
    // 格闘＋弓術 [完全逆]
    if (command_name == Fix.SUDDEN_STRIKEARROW) { return TargetType.Enemy; }
    if (command_name == Fix.STANCE_OF_MYSTIC) { return TargetType.Own; }
    // 格闘＋心眼
    if (command_name == Fix.PSYCHIC_WAVE) { return TargetType.Enemy; }
    if (command_name == Fix.FLARE_OF_FIGHTING) { return TargetType.AllyField; }
    // 格闘＋無心
    if (command_name == Fix.INFINITY_IMAGE) { return TargetType.Own; }
    if (command_name == Fix.UNIFIED_CONVICTION) { return TargetType.Ally; }
    // 弓術＋心眼
    if (command_name == Fix.ABSOLUTE_ARROW) { return TargetType.Enemy; }
    if (command_name == Fix.HEAVENS_WISDOM) { return TargetType.Ally; }
    // 弓術＋無心
    if (command_name == Fix.SILENT_MEDITATION) { return TargetType.Ally; }
    if (command_name == Fix.COLORLESS_FORM) { return TargetType.Own; }
    // 心眼＋無心 [完全逆]
    if (command_name == Fix.OVERWHELMING_DESTINY) { return TargetType.InstantTarget; }
    if (command_name == Fix.WORLD_CHANT) { return TargetType.Own; }
    #endregion

    #region "Archetype"
    if (command_name == Fix.ARCHETYPE_EIN_1) { return TargetType.Own; }
    #endregion

    #region "Other"
    if (command_name == Fix.AIR_CUTTER) { return TargetType.Enemy; }
    if (command_name == Fix.ROCK_SLAM) { return TargetType.Enemy; }
    if (command_name == Fix.VENOM_SLASH) { return TargetType.Enemy; }
    if (command_name == Fix.AURA_OF_POWER) { return TargetType.Ally; }
    if (command_name == Fix.HEART_OF_LIFE) { return TargetType.Ally; }
    if (command_name == Fix.DARKNESS_CIRCLE) { return TargetType.EnemyField; }
    if (command_name == Fix.STORM_ARMOR) { return TargetType.Ally; }
    if (command_name == Fix.SOLID_WALL) { return TargetType.AllyField; }
    if (command_name == Fix.INVISIBLE_BIND) { return TargetType.Enemy; }
    if (command_name == Fix.IDEOLOGY_OF_SOPHISTICATION) { return TargetType.AllyField; }
    if (command_name == Fix.SKY_SHIELD) { return TargetType.Ally; }
    if (command_name == Fix.STANCE_OF_THE_SHADE) { return TargetType.Own; }
    if (command_name == Fix.SONIC_PULSE) { return TargetType.Enemy; }
    if (command_name == Fix.LAND_SHATTER) { return TargetType.Enemy; }
    if (command_name == Fix.MUTE_IMPULSE) { return TargetType.Enemy; }
    if (command_name == Fix.AETHER_DRIVE) { return TargetType.AllyField; }
    if (command_name == Fix.KILLING_WAVE) { return TargetType.EnemyField; }
    if (command_name == Fix.IRREGULAR_STEP) { return TargetType.InstantTarget; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return TargetType.InstantTarget; }
    #endregion

    #region "Monster"
    if (command_name == Fix.COMMAND_HIKKAKI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_GREEN_NENEKI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_KANAKIRI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_WILD_CLAW) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_KAMITSUKI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_TREE_SONG) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SUN_FIRE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_TOSSHIN) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_FEATHER_WING) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_DASH_KERI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SUITSUKU_TSUTA) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SPIDER_NET) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_POISON_KOKE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_CONTINUOUS_ATTACK) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_FIRE_EMISSION) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SUPER_TOSSHIN) { return TargetType.Enemy; }

    if (command_name == Fix.COMMAND_POISON_RINPUN) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_YOUEN_FIRE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_BLAZE_DANCE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_DRILL_CYCLONE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_RUMBLE_MACHINEGUN) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_STRUGGLE_VOICE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_GAREKI_TSUBUTE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SHADOW_SPEAR) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_MIDARE_GIRI) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_MIRROR_SHIELD) { return TargetType.AllyGroup; }
    if (command_name == Fix.COMMAND_HAND_CANNON) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SAIMIN_DANCE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_POISON_NEEDLE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SPIKE_SHOT) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_THUNDER_CLOUD) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_SPAAAARK) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SUPER_RANDOM_CANNON) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_ELECTRO_RAILGUN) { return TargetType.Enemy; }

    if (command_name == Fix.COMMAND_WILD_STORM) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_YOUKAIEKI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_POISON_TONGUE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_CONSTRICT) { return TargetType.Enemy; }

    if (command_name == Fix.COMMAND_STINKY_BREATH) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_CHARGE_LANCE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_JUBAKU_ON) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_ZINARI) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_BOUHATSU) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SURUDOI_HIKKAKI) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_HAGESHII_KAMITSUKI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_BOLT_FRAME) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_BOOOOMB) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_STONE_RAIN) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_TARGETTING_SHOT) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_POWERED_ATTACK) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SUSPICIOUS_VIAL) { return TargetType.EnemyGroup; }

    if (command_name == Fix.COMMAND_LIGHTNING_OUTBURST) { return TargetType.EnemyField; }

    if (command_name == Fix.COMMAND_VERDANT_VOICE) { return TargetType.AllyField; }
    if (command_name == Fix.COMMAND_FIRE_BLAST) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_BLACK_SPORE) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_RENSOU_TOSSHIN) { return TargetType.EnemyGroup; }
    if (command_name == Fix.COMMAND_DEVIL_EMBLEM) { return TargetType.EnemyField; }
    #endregion

    return TargetType.None; // 未設定やイレギュラーなものはデフォルトでは使用不可とする。
  }

  public static int Cost(string command_name)
  {
    #region "基本／一般"
    if (command_name == Fix.NORMAL_ATTACK) { return 0; }
    if (command_name == Fix.MAGIC_ATTACK) { return 0; }
    if (command_name == Fix.DEFENSE) { return 0; }
    if (command_name == Fix.STAY) { return 0; }
    if (command_name == Fix.USE_RED_POTION_1) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_RED_POTION_2) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_RED_POTION_3) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_RED_POTION_4) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_RED_POTION_5) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_RED_POTION_6) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_RED_POTION_7) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_BLUE_POTION_1) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_BLUE_POTION_2) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_BLUE_POTION_3) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_BLUE_POTION_4) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_BLUE_POTION_5) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_BLUE_POTION_6) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    if (command_name == Fix.USE_BLUE_POTION_7) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。
    // アイテム使用は基本０とする。（例外は作るかもしれない）
    if (command_name == Fix.SMALL_RED_POTION) { return 0; }
    if (command_name == Fix.SMALL_BLUE_POTION) { return 0; }
    if (command_name == Fix.SMALL_GREEN_POTION) { return 0; }
    if (command_name == Fix.NORMAL_RED_POTION) { return 0; }
    if (command_name == Fix.NORMAL_BLUE_POTION) { return 0; }
    if (command_name == Fix.NORMAL_GREEN_POTION) { return 0; }
    if (command_name == Fix.LARGE_RED_POTION) { return 0; }
    if (command_name == Fix.LARGE_BLUE_POTION) { return 0; }
    if (command_name == Fix.LARGE_GREEN_POTION) { return 0; }
    if (command_name == Fix.HUGE_RED_POTION) { return 0; }
    if (command_name == Fix.HUGE_BLUE_POTION) { return 0; }
    if (command_name == Fix.HUGE_GREEN_POTION) { return 0; }
    if (command_name == Fix.HQ_RED_POTION) { return 0; }
    if (command_name == Fix.HQ_BLUE_POTION) { return 0; }
    if (command_name == Fix.HQ_GREEN_POTION) { return 0; }
    if (command_name == Fix.THQ_RED_POTION) { return 0; }
    if (command_name == Fix.THQ_BLUE_POTION) { return 0; }
    if (command_name == Fix.THQ_GREEN_POTION) { return 0; }
    if (command_name == Fix.PERFECT_RED_POTION) { return 0; }
    if (command_name == Fix.PERFECT_BLUE_POTION) { return 0; }
    if (command_name == Fix.PERFECT_GREEN_POTION) { return 0; }
    if (command_name == Fix.PURE_CLEAN_WATER) { return 0; }
    if (command_name == Fix.PURE_SINSEISUI) { return 0; }
    #endregion

    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return 4; }
    if (command_name == Fix.ICE_NEEDLE) { return 3; }
    if (command_name == Fix.FRESH_HEAL) { return 4; }
    if (command_name == Fix.SHADOW_BLAST) { return 3; }
    if (command_name == Fix.ORACLE_COMMAND) { return 6; }
    if (command_name == Fix.ENERGY_BOLT) { return 3; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return 12; }
    if (command_name == Fix.SHIELD_BASH) { return 20; }
    if (command_name == Fix.LEG_STRIKE) { return 10; }
    if (command_name == Fix.HUNTER_SHOT) { return 12; }
    if (command_name == Fix.TRUE_SIGHT) { return 20; }
    if (command_name == Fix.DISPEL_MAGIC) { return 25; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return 7; }
    if (command_name == Fix.PURE_PURIFICATION) { return 6; }
    if (command_name == Fix.DIVINE_CIRCLE) { return 8; }
    if (command_name == Fix.BLOOD_SIGN) { return 7; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return 9; }
    if (command_name == Fix.FLASH_COUNTER) { return 7; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return 15; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return 20; }
    if (command_name == Fix.SPEED_STEP) { return 13; }
    if (command_name == Fix.MULTIPLE_SHOT) { return 16; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return 2; }
    if (command_name == Fix.SPIRITUAL_REST) { return 15; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return 14; }
    if (command_name == Fix.BLUE_BULLET) { return 13; }
    if (command_name == Fix.HOLY_BREATH) { return 11; }
    if (command_name == Fix.BLACK_CONTRACT) { return 12; }
    if (command_name == Fix.WORD_OF_POWER) { return 15; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return 20; }
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return 25; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return 15; }
    if (command_name == Fix.BONE_CRUSH) { return 35; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return 20; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return 40; }
    if (command_name == Fix.UNSEEN_AID) { return 30; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return 22; }
    if (command_name == Fix.FREEZING_CUBE) { return 20; }
    if (command_name == Fix.ANGELIC_ECHO) { return 27; }
    if (command_name == Fix.CURSED_EVANGILE) { return 26; }
    if (command_name == Fix.GALE_WIND) { return 33; }
    if (command_name == Fix.PHANTOM_OBORO) { return 36; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return 30; }
    if (command_name == Fix.DOMINATION_FIELD) { return 40; }
    if (command_name == Fix.DEADLY_DRIVE) { return 5; }
    if (command_name == Fix.PENETRATION_ARROW) { return 45; }
    if (command_name == Fix.WILL_AWAKENING) { return 50; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return 50; }
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return 55; }
    if (command_name == Fix.FROST_LANCE) { return 52; }
    if (command_name == Fix.SHINING_HEAL) { return 63; }
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return 59; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return 80; }
    if (command_name == Fix.COUNTER_DISALLOW) { return 70; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return 45; }
    if (command_name == Fix.HARDEST_PARRY) { return 50; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return 25; }
    if (command_name == Fix.PRECISION_STRIKE) { return 50; }
    if (command_name == Fix.EVERFLOW_MIND) { return 20; }
    if (command_name == Fix.INNER_INSPIRATION) { return 0; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return 120; }
    if (command_name == Fix.WATER_PRESENCE) { return 150; }
    if (command_name == Fix.VALKYRIE_BLADE) { return 140; }
    if (command_name == Fix.THE_DARK_INTENSITY) { return 160; }
    if (command_name == Fix.FUTURE_VISION) { return 90; } // todo 仮
    if (command_name == Fix.DETACHMENT_FAULT) { return 90; } // todo 仮
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return 50; } // todo 仮
    if (command_name == Fix.ONE_IMMUNITY) { return 50; } // todo 仮
    if (command_name == Fix.STANCE_OF_MUIN) { return 50; } // todo 仮
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return 50; } // todo 仮
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return 50; } // todo 仮
    if (command_name == Fix.ZERO_IMMUNITY) { return 50; } // todo 仮
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return 120; } // todo 仮
    if (command_name == Fix.ABSOLUTE_ZERO) { return 120; } // todo 仮
    if (command_name == Fix.RESURRECTION) { return 700; }
    if (command_name == Fix.DEATH_SCYTHE) { return 120; } // todo 仮
    if (command_name == Fix.GENESIS) { return 120; } // todo 仮
    if (command_name == Fix.TIME_SKIP) { return 120; } // todo 仮
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return 100; } // todo 仮
    if (command_name == Fix.CATASTROPHE) { return 100; } // todo 仮
    if (command_name == Fix.CARNAGE_RUSH) { return 100; } // todo 仮
    if (command_name == Fix.PIERCING_ARROW) { return 100; } // todo 仮
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return 100; } // todo 仮
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return 100; } // todo 仮
    #endregion

    #region "複合魔法"
    // 聖＋闇 [完全逆]
    if (command_name == Fix.PSYCHIC_TRANCE) { return 1500; }
    if (command_name == Fix.BLIND_JUSTICE) { return 1500; }
    if (command_name == Fix.DEATH_DENY) { return 2500; }
    // 聖＋炎
    if (command_name == Fix.FLASH_BLAZE) { return 600; }
    if (command_name == Fix.LIGHT_DETONATOR) { return 750; }
    if (command_name == Fix.ASCENDANT_METEOR) { return 1500; }
    // 聖＋氷
    if (command_name == Fix.SKY_SHIELD) { return 650; }
    if (command_name == Fix.SACRED_FIELD) { return 800; }
    if (command_name == Fix.SAINT_JUDGEMENT) { return 1200; }
    // 聖＋理
    if (command_name == Fix.HOLY_BREAKER) { return 650; }
    if (command_name == Fix.EXALTED_FIELD) { return 1200; }
    if (command_name == Fix.HYMN_CONTRACT) { return 1600; }
    // 聖＋空唱
    if (command_name == Fix.VOID_THUNDER) { return 550; }
    if (command_name == Fix.ANGEL_INTERVENTION) { return 1400; }
    if (command_name == Fix.ENDLESS_ANTHEM) { return 1800; }
    // 闇＋炎
    if (command_name == Fix.BLACK_FIRE) { return 700; }
    if (command_name == Fix.BLAZING_FIELD) { return 1200; }
    if (command_name == Fix.DEMONIC_IGNITE) { return 1500; }
    // 闇＋氷
    if (command_name == Fix.DEEP_MIRROR) { return 350; }
    if (command_name == Fix.STORM_SHARD) { return 900; }
    if (command_name == Fix.ABYSS_EYE) { return 1200; }
    // 闇＋理
    if (command_name == Fix.WORD_OF_MALICE) { return 700; }
    if (command_name == Fix.SIN_FORTUNE) { return 1300; }
    if (command_name == Fix.BLOOD_SHACKLE) { return 1600; }
    // 闇＋空唱
    if (command_name == Fix.ACHROMA_BLAST) { return 750; }
    if (command_name == Fix.DOOM_BLADE) { return 1400; }
    if (command_name == Fix.ECLIPSE_END) { return 2000; }
    // 炎＋氷 [完全逆]
    if (command_name == Fix.CHILL_BURN) { return 1000; }
    if (command_name == Fix.SWORD_OF_FREEZING_FIRE) { return 1400; }
    if (command_name == Fix.ZETA_EXPLOSION) { return 3000; }
    // 炎＋理
    if (command_name == Fix.BURST_INFERNO) { return 800; }
    if (command_name == Fix.PIERCING_FLAME) { return 1100; }
    if (command_name == Fix.SIGIL_OF_HOMURA) { return 1500; }
    // 炎＋空唱
    if (command_name == Fix.ERRATIC_THUNDERBOLT) { return 600; }
    if (command_name == Fix.STEAM_MIRROR) { return 900; }
    if (command_name == Fix.RED_DRAGON_WILL) { return 1600; }
    // 氷＋理
    if (command_name == Fix.WORD_OF_ATTITUDE) { return 400; }
    if (command_name == Fix.ICICLE_BARRIER) { return 750; }
    if (command_name == Fix.AUSTERITY_MATRIX) { return 1600; }
    // 氷＋空唱
    if (command_name == Fix.GLACIAL_CIRCLE) { return 800; }
    if (command_name == Fix.VORTEX_SONG) { return 1200; }
    if (command_name == Fix.BLUE_DRAGON_WILL) { return 1600; }
    // 理＋空唱 [完全逆]
    if (command_name == Fix.WORD_OF_NINE) { return 1600; }
    if (command_name == Fix.PARADOX_IMAGE) { return 2000; }
    if (command_name == Fix.WARP_GATE) { return 2400; }
    #endregion

    #region "複合スキル"
    // 戦士＋護衛 [完全逆]
    if (command_name == Fix.NEUTRAL_SMASH) { return 0; }
    if (command_name == Fix.STANCE_OF_DOUBLE) { return 100; }
    // 戦士＋格闘
    if (command_name == Fix.BLITZ_STRIKE) { return 20; }
    if (command_name == Fix.ASSASSINATION_HIT) { return 40; }
    // 戦士＋弓術
    if (command_name == Fix.PHOENIX_EYE) { return 30; }
    if (command_name == Fix.HARDENED_INSIGHT) { return 40; }
    // 戦士＋心眼
    if (command_name == Fix.CHALLENGING_SHOUT) { return 25; } // ただし敵全員もある
    if (command_name == Fix.ONSLAUGHT_HIT) { return 30; }
    // 戦士＋無心
    if (command_name == Fix.FORMLESS_STYLE) { return 10; }
    if (command_name == Fix.HARDEST_PARRY) { return 20; }
    // 護衛＋格闘
    if (command_name == Fix.TACTICAL_VISION) { return 15; }
    if (command_name == Fix.SWIFT_RESPONSE) { return 30; }
    // 護衛＋弓術
    if (command_name == Fix.RIGHTEOUSNESS_ARROW) { return 20; }
    if (command_name == Fix.PERFECT_EVASION) { return 30; }
    // 護衛＋心眼
    if (command_name == Fix.REFLEX_ESSENCE) { return 15; }
    if (command_name == Fix.SELF_PERSUASION) { return 50; }
    // 護衛＋無心
    if (command_name == Fix.TRUST_SILENCE) { return 15; }
    if (command_name == Fix.NOURISH_POWER) { return 30; }
    // 格闘＋弓術 [完全逆]
    if (command_name == Fix.SUDDEN_STRIKEARROW) { return 25; }
    if (command_name == Fix.STANCE_OF_MYSTIC) { return 50; }
    // 格闘＋心眼
    if (command_name == Fix.PSYCHIC_WAVE) { return 15; }
    if (command_name == Fix.FLARE_OF_FIGHTING) { return 30; }
    // 格闘＋無心
    if (command_name == Fix.INFINITY_IMAGE) { return 0; }
    if (command_name == Fix.UNIFIED_CONVICTION) { return 50; }
    // 弓術＋心眼
    if (command_name == Fix.ABSOLUTE_ARROW) { return 20; }
    if (command_name == Fix.HEAVENS_WISDOM) { return 50; }
    // 弓術＋無心
    if (command_name == Fix.SILENT_MEDITATION) { return 20; }
    if (command_name == Fix.COLORLESS_FORM) { return 40; }
    // 心眼＋無心 [完全逆]
    if (command_name == Fix.OVERWHELMING_DESTINY) { return 110; }
    if (command_name == Fix.WORLD_CHANT) { return 120; }
    #endregion

    #region "Archetype"
    if (command_name == Fix.ARCHETYPE_EIN_1) { return 0; }
    #endregion

    #region "Other"
    if (command_name == Fix.AIR_CUTTER) { return 3; }
    if (command_name == Fix.ROCK_SLAM) { return 5; }
    if (command_name == Fix.VENOM_SLASH) { return 4; }
    if (command_name == Fix.AURA_OF_POWER) { return 3; }
    if (command_name == Fix.HEART_OF_LIFE) { return 3; }
    if (command_name == Fix.DARKNESS_CIRCLE) { return 5; }
    if (command_name == Fix.STORM_ARMOR) { return 7; }
    if (command_name == Fix.SOLID_WALL) { return 7; }
    if (command_name == Fix.INVISIBLE_BIND) { return 9; }
    if (command_name == Fix.IDEOLOGY_OF_SOPHISTICATION) { return 5; }
    if (command_name == Fix.SKY_SHIELD) { return 7; }
    if (command_name == Fix.STANCE_OF_THE_SHADE) { return 8; }
    if (command_name == Fix.SONIC_PULSE) { return 16; }
    if (command_name == Fix.LAND_SHATTER) { return 15; }
    if (command_name == Fix.MUTE_IMPULSE) { return 15; }
    if (command_name == Fix.AETHER_DRIVE) { return 18; }
    if (command_name == Fix.KILLING_WAVE) { return 19; }
    if (command_name == Fix.IRREGULAR_STEP) { return 12; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return 17; }
    #endregion

    #region "Monster"
    // 以降、モンスターアクションは基本０とする。
    if (command_name == Fix.COMMAND_HIKKAKI) { return 0; }
    if (command_name == Fix.COMMAND_GREEN_NENEKI) { return 0; }
    if (command_name == Fix.COMMAND_KANAKIRI) { return 0; }
    if (command_name == Fix.COMMAND_WILD_CLAW) { return 0; }
    if (command_name == Fix.COMMAND_KAMITSUKI) { return 0; }
    if (command_name == Fix.COMMAND_TREE_SONG) { return 0; }
    if (command_name == Fix.COMMAND_SUN_FIRE) { return 0; }
    if (command_name == Fix.COMMAND_TOSSHIN) { return 0; }
    if (command_name == Fix.COMMAND_FEATHER_WING) { return 0; }
    if (command_name == Fix.COMMAND_DASH_KERI) { return 0; }
    if (command_name == Fix.COMMAND_SUITSUKU_TSUTA) { return 0; }
    if (command_name == Fix.COMMAND_SPIDER_NET) { return 0; }
    if (command_name == Fix.COMMAND_POISON_KOKE) { return 0; }
    if (command_name == Fix.COMMAND_CONTINUOUS_ATTACK) { return 0; }
    if (command_name == Fix.COMMAND_FIRE_EMISSION) { return 0; }
    if (command_name == Fix.COMMAND_SUPER_TOSSHIN) { return 0; }
    if (command_name == Fix.COMMAND_POISON_RINPUN) { return 0; }
    if (command_name == Fix.COMMAND_YOUEN_FIRE) { return 0; }
    if (command_name == Fix.COMMAND_BLAZE_DANCE) { return 0; }
    if (command_name == Fix.COMMAND_DRILL_CYCLONE) { return 0; }
    if (command_name == Fix.COMMAND_RUMBLE_MACHINEGUN) { return 0; }
    if (command_name == Fix.COMMAND_STRUGGLE_VOICE) { return 0; }
    if (command_name == Fix.COMMAND_GAREKI_TSUBUTE) { return 0; }
    if (command_name == Fix.COMMAND_SHADOW_SPEAR) { return 0; }
    if (command_name == Fix.COMMAND_MIDARE_GIRI) { return 0; }
    if (command_name == Fix.COMMAND_MIRROR_SHIELD) { return 0; }
    if (command_name == Fix.COMMAND_HAND_CANNON) { return 0; }
    if (command_name == Fix.COMMAND_SAIMIN_DANCE) { return 0; }
    if (command_name == Fix.COMMAND_POISON_NEEDLE) { return 0; }
    if (command_name == Fix.COMMAND_SPIKE_SHOT) { return 0; }
    if (command_name == Fix.COMMAND_THUNDER_CLOUD) { return 0; }
    if (command_name == Fix.COMMAND_SPAAAARK) { return 0; }
    if (command_name == Fix.COMMAND_SUPER_RANDOM_CANNON) { return 0; }
    if (command_name == Fix.COMMAND_ELECTRO_RAILGUN) { return 0; }

    if (command_name == Fix.COMMAND_WILD_STORM) { return 0; }
    if (command_name == Fix.COMMAND_YOUKAIEKI) { return 0; }
    if (command_name == Fix.COMMAND_POISON_TONGUE) { return 0; }
    if (command_name == Fix.COMMAND_CONSTRICT) { return 0; }

    if (command_name == Fix.COMMAND_STINKY_BREATH) { return 0; }
    if (command_name == Fix.COMMAND_CHARGE_LANCE) { return 0; }
    if (command_name == Fix.COMMAND_JUBAKU_ON) { return 0; }
    if (command_name == Fix.COMMAND_ZINARI) { return 0; }
    if (command_name == Fix.COMMAND_BOUHATSU) { return 0; }
    if (command_name == Fix.COMMAND_SURUDOI_HIKKAKI) { return 0; }
    if (command_name == Fix.COMMAND_HAGESHII_KAMITSUKI) { return 0; }
    if (command_name == Fix.COMMAND_BOLT_FRAME) { return 0; }
    if (command_name == Fix.COMMAND_BOOOOMB) { return 0; }
    if (command_name == Fix.COMMAND_STONE_RAIN) { return 0; }
    if (command_name == Fix.COMMAND_TARGETTING_SHOT) { return 0; }
    if (command_name == Fix.COMMAND_POWERED_ATTACK) { return 0; }
    if (command_name == Fix.COMMAND_SUSPICIOUS_VIAL) { return 0; }

    if (command_name == Fix.COMMAND_LIGHTNING_OUTBURST) { return 0; }
    #endregion

    if (command_name == Fix.COUNTER_ATTACK) { return 3; }

    return Fix.INFINITY; // 未設定やイレギュラーなものはデフォルトでは使用不可とする。
  }

  public static Fix.BuffType GetBuffType(string command_name)
  {
    #region "基本／一般"
    if (command_name == Fix.NORMAL_ATTACK) { return Fix.BuffType.None; }
    if (command_name == Fix.MAGIC_ATTACK) { return Fix.BuffType.None; }
    if (command_name == Fix.DEFENSE) { return Fix.BuffType.None; }
    if (command_name == Fix.STAY) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_RED_POTION_1) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_RED_POTION_2) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_RED_POTION_3) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_RED_POTION_4) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_RED_POTION_5) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_RED_POTION_6) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_RED_POTION_7) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_BLUE_POTION_1) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_BLUE_POTION_2) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_BLUE_POTION_3) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_BLUE_POTION_4) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_BLUE_POTION_5) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_BLUE_POTION_6) { return Fix.BuffType.None; }
    if (command_name == Fix.USE_BLUE_POTION_7) { return Fix.BuffType.None; }
    if (command_name == Fix.SMALL_RED_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.SMALL_BLUE_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.SMALL_GREEN_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.NORMAL_RED_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.NORMAL_BLUE_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.NORMAL_GREEN_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.LARGE_RED_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.LARGE_BLUE_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.LARGE_GREEN_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.HUGE_RED_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.HUGE_BLUE_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.HUGE_GREEN_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.HQ_RED_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.HQ_BLUE_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.HQ_GREEN_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.THQ_RED_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.THQ_BLUE_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.THQ_GREEN_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.PERFECT_RED_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.PERFECT_BLUE_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.PERFECT_GREEN_POTION) { return Fix.BuffType.None; }
    if (command_name == Fix.PURE_CLEAN_WATER) { return Fix.BuffType.None; }
    if (command_name == Fix.PURE_SINSEISUI) { return Fix.BuffType.None; }
    #endregion

    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return Fix.BuffType.None; }
    if (command_name == Fix.ICE_NEEDLE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.FRESH_HEAL) { return Fix.BuffType.None; }
    if (command_name == Fix.SHADOW_BLAST) { return Fix.BuffType.Negative; }
    if (command_name == Fix.ORACLE_COMMAND) { return Fix.BuffType.None; }
    if (command_name == Fix.ENERGY_BOLT) { return Fix.BuffType.None; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return Fix.BuffType.None; }
    if (command_name == Fix.SHIELD_BASH) { return Fix.BuffType.Negative; }
    if (command_name == Fix.LEG_STRIKE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.HUNTER_SHOT) { return Fix.BuffType.Negative; }
    if (command_name == Fix.TRUE_SIGHT) { return Fix.BuffType.Positive; }
    if (command_name == Fix.DISPEL_MAGIC) { return Fix.BuffType.None; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.PURE_PURIFICATION) { return Fix.BuffType.None; }
    if (command_name == Fix.DIVINE_CIRCLE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.BLOOD_SIGN) { return Fix.BuffType.Negative; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return Fix.BuffType.Positive; }
    if (command_name == Fix.FLASH_COUNTER) { return Fix.BuffType.None; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return Fix.BuffType.Positive; }
    if (command_name == Fix.SPEED_STEP) { return Fix.BuffType.Positive; }
    if (command_name == Fix.MULTIPLE_SHOT) { return Fix.BuffType.None; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return Fix.BuffType.Positive; }
    if (command_name == Fix.SPIRITUAL_REST) { return Fix.BuffType.None; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return Fix.BuffType.None; }
    if (command_name == Fix.BLUE_BULLET) { return Fix.BuffType.None; }
    if (command_name == Fix.HOLY_BREATH) { return Fix.BuffType.Positive; }
    if (command_name == Fix.BLACK_CONTRACT) { return Fix.BuffType.Positive; }
    if (command_name == Fix.WORD_OF_POWER) { return Fix.BuffType.None; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return Fix.BuffType.Neutral; } // Neutralは有益／有害のいずれでもないので、打ち消し難い
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return Fix.BuffType.None; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return Fix.BuffType.Negative; }
    if (command_name == Fix.BONE_CRUSH) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return Fix.BuffType.Positive; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return Fix.BuffType.Positive; }
    if (command_name == Fix.UNSEEN_AID) { return Fix.BuffType.None; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.FREEZING_CUBE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.ANGELIC_ECHO) { return Fix.BuffType.Positive; }
    if (command_name == Fix.CURSED_EVANGILE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.GALE_WIND) { return Fix.BuffType.Positive; }
    if (command_name == Fix.PHANTOM_OBORO) { return Fix.BuffType.Positive; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return Fix.BuffType.None; }
    if (command_name == Fix.DOMINATION_FIELD) { return Fix.BuffType.Positive; }
    if (command_name == Fix.DEADLY_DRIVE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.PENETRATION_ARROW) { return Fix.BuffType.Negative; }
    if (command_name == Fix.WILL_AWAKENING) { return Fix.BuffType.Positive; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return Fix.BuffType.Positive; }
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.FROST_LANCE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.SHINING_HEAL) { return Fix.BuffType.Positive; }
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return Fix.BuffType.Negative; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return Fix.BuffType.Neutral; } // Neutralは有益／有害のいずれでもないので、打ち消し難い
    if (command_name == Fix.COUNTER_DISALLOW) { return Fix.BuffType.Negative; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return Fix.BuffType.Positive; }
    if (command_name == Fix.HARDEST_PARRY) { return Fix.BuffType.None; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return Fix.BuffType.Negative; }
    if (command_name == Fix.PRECISION_STRIKE) { return Fix.BuffType.None; }
    if (command_name == Fix.EVERFLOW_MIND) { return Fix.BuffType.Positive; }
    if (command_name == Fix.INNER_INSPIRATION) { return Fix.BuffType.None; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return Fix.BuffType.Negative; } // todo 仮
    if (command_name == Fix.WATER_PRESENCE) { return Fix.BuffType.Positive; } // todo 仮
    if (command_name == Fix.VALKYRIE_BLADE) { return Fix.BuffType.Positive; } // todo 仮
    if (command_name == Fix.THE_DARK_INTENSITY) { return Fix.BuffType.Positive; }
    if (command_name == Fix.FUTURE_VISION) { return Fix.BuffType.Positive; } // todo 仮
    if (command_name == Fix.DETACHMENT_FAULT) { return Fix.BuffType.Neutral; } // todo 仮  // Neutralは有益／有害のいずれでもないので、打ち消し難い
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return Fix.BuffType.Positive; } // todo 仮
    if (command_name == Fix.ONE_IMMUNITY) { return Fix.BuffType.Positive; } // todo 仮
    if (command_name == Fix.STANCE_OF_MUIN) { return Fix.BuffType.Positive; } // todo 仮
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return Fix.BuffType.Positive; } // todo 仮
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return Fix.BuffType.Positive; } // todo 仮
    if (command_name == Fix.ZERO_IMMUNITY) { return Fix.BuffType.Positive; } // todo 仮
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return Fix.BuffType.Negative; } // todo 仮
    if (command_name == Fix.ABSOLUTE_ZERO) { return Fix.BuffType.Negative; } // todo 仮
    if (command_name == Fix.RESURRECTION) { return Fix.BuffType.None; } // todo 仮
    if (command_name == Fix.DEATH_SCYTHE) { return Fix.BuffType.Negative; } // todo 仮
    if (command_name == Fix.GENESIS) { return Fix.BuffType.None; } // todo 仮
    if (command_name == Fix.TIME_SKIP) { return Fix.BuffType.None; } // todo 仮
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return Fix.BuffType.None; } // todo 仮
    if (command_name == Fix.CATASTROPHE) { return Fix.BuffType.None; } // todo 仮
    if (command_name == Fix.CARNAGE_RUSH) { return Fix.BuffType.None; } // todo 仮
    if (command_name == Fix.PIERCING_ARROW) { return Fix.BuffType.None; } // todo 仮
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return Fix.BuffType.Positive; } // todo 仮
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return Fix.BuffType.Positive; } // todo 仮
    #endregion

    #region "複合魔法"
    // 聖＋闇 [完全逆]
    if (command_name == Fix.PSYCHIC_TRANCE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.BLIND_JUSTICE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.DEATH_DENY) { return Fix.BuffType.Negative; }
    // 聖＋炎
    if (command_name == Fix.FLASH_BLAZE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.LIGHT_DETONATOR) { return Fix.BuffType.Negative; }
    if (command_name == Fix.ASCENDANT_METEOR) { return Fix.BuffType.None; }
    // 聖＋氷
    if (command_name == Fix.SKY_SHIELD) { return Fix.BuffType.Positive; }
    if (command_name == Fix.SACRED_FIELD) { return Fix.BuffType.Positive; }
    if (command_name == Fix.SAINT_JUDGEMENT) { return Fix.BuffType.Negative; }
    // 聖＋理
    if (command_name == Fix.HOLY_BREAKER) { return Fix.BuffType.Positive; }
    if (command_name == Fix.EXALTED_FIELD) { return Fix.BuffType.Positive; }
    if (command_name == Fix.HYMN_CONTRACT) { return Fix.BuffType.Positive; }
    // 聖＋空唱
    if (command_name == Fix.VOID_THUNDER) { return Fix.BuffType.Negative; }
    if (command_name == Fix.ANGEL_INTERVENTION) { return Fix.BuffType.Neutral; }
    if (command_name == Fix.ENDLESS_ANTHEM) { return Fix.BuffType.Positive; }
    // 闇＋炎
    if (command_name == Fix.BLACK_FIRE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.BLAZING_FIELD) { return Fix.BuffType.Negative; }
    if (command_name == Fix.DEMONIC_IGNITE) { return Fix.BuffType.Negative; }
    // 闇＋氷
    if (command_name == Fix.DEEP_MIRROR) { return Fix.BuffType.None; }
    if (command_name == Fix.STORM_SHARD) { return Fix.BuffType.Negative; }
    if (command_name == Fix.ABYSS_EYE) { return Fix.BuffType.None; }
    // 闇＋理
    if (command_name == Fix.WORD_OF_MALICE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.SIN_FORTUNE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.BLOOD_SHACKLE) { return Fix.BuffType.Negative; }
    // 闇＋空唱
    if (command_name == Fix.ACHROMA_BLAST) { return Fix.BuffType.Negative; }
    if (command_name == Fix.DOOM_BLADE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.ECLIPSE_END) { return Fix.BuffType.Neutral; }
    // 炎＋氷 [完全逆]
    if (command_name == Fix.CHILL_BURN) { return Fix.BuffType.Negative; }
    if (command_name == Fix.SWORD_OF_FREEZING_FIRE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.ZETA_EXPLOSION) { return Fix.BuffType.None; }
    // 炎＋理
    if (command_name == Fix.BURST_INFERNO) { return Fix.BuffType.Negative; }
    if (command_name == Fix.PIERCING_FLAME) { return Fix.BuffType.None; }
    if (command_name == Fix.SIGIL_OF_HOMURA) { return Fix.BuffType.Negative; }
    // 炎＋空唱
    if (command_name == Fix.ERRATIC_THUNDERBOLT) { return Fix.BuffType.Negative; }
    if (command_name == Fix.STEAM_MIRROR) { return Fix.BuffType.Positive; }
    if (command_name == Fix.RED_DRAGON_WILL) { return Fix.BuffType.Positive; }
    // 氷＋理
    if (command_name == Fix.WORD_OF_ATTITUDE) { return Fix.BuffType.None; }
    if (command_name == Fix.ICICLE_BARRIER) { return Fix.BuffType.Positive; }
    if (command_name == Fix.AUSTERITY_MATRIX) { return Fix.BuffType.Negative; }
    // 氷＋空唱
    if (command_name == Fix.GLACIAL_CIRCLE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.VORTEX_SONG) { return Fix.BuffType.None; }
    if (command_name == Fix.BLUE_DRAGON_WILL) { return Fix.BuffType.Positive; }
    // 理＋空唱 [完全逆]
    if (command_name == Fix.WORD_OF_NINE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.PARADOX_IMAGE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.WARP_GATE) { return Fix.BuffType.None; }
    #endregion

    #region "複合スキル"
    // 戦士＋護衛 [完全逆]
    if (command_name == Fix.NEUTRAL_SMASH) { return Fix.BuffType.None; }
    if (command_name == Fix.STANCE_OF_DOUBLE) { return Fix.BuffType.Positive; }
    // 戦士＋格闘
    if (command_name == Fix.BLITZ_STRIKE) { return Fix.BuffType.Positive ; }
    if (command_name == Fix.ASSASSINATION_HIT) { return Fix.BuffType.None; }
    // 戦士＋弓術
    if (command_name == Fix.PHOENIX_EYE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.HARDENED_INSIGHT) { return Fix.BuffType.Positive; }
    // 戦士＋心眼
    if (command_name == Fix.CHALLENGING_SHOUT) { return Fix.BuffType.Positive; } // ただし敵全員はNegative
    if (command_name == Fix.ONSLAUGHT_HIT) { return Fix.BuffType.Negative; }
    // 戦士＋無心
    if (command_name == Fix.FORMLESS_STYLE) { return Fix.BuffType.None; }
    if (command_name == Fix.HARDEST_PARRY) { return Fix.BuffType.None; }
    // 護衛＋格闘
    if (command_name == Fix.TACTICAL_VISION) { return Fix.BuffType.Positive; }
    if (command_name == Fix.SWIFT_RESPONSE) { return Fix.BuffType.None; }
    // 護衛＋弓術
    if (command_name == Fix.RIGHTEOUSNESS_ARROW) { return Fix.BuffType.Positive; }
    if (command_name == Fix.PERFECT_EVASION) { return Fix.BuffType.None; }
    // 護衛＋心眼
    if (command_name == Fix.REFLEX_ESSENCE) { return Fix.BuffType.None; }
    if (command_name == Fix.SELF_PERSUASION) { return Fix.BuffType.Positive; }
    // 護衛＋無心
    if (command_name == Fix.TRUST_SILENCE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.NOURISH_POWER) { return Fix.BuffType.Positive; }
    // 格闘＋弓術 [完全逆]
    if (command_name == Fix.SUDDEN_STRIKEARROW) { return Fix.BuffType.None; }
    if (command_name == Fix.STANCE_OF_MYSTIC) { return Fix.BuffType.Positive; }
    // 格闘＋心眼
    if (command_name == Fix.PSYCHIC_WAVE) { return Fix.BuffType.None; }
    if (command_name == Fix.FLARE_OF_FIGHTING) { return Fix.BuffType.Positive; }
    // 格闘＋無心
    if (command_name == Fix.INFINITY_IMAGE) { return Fix.BuffType.None; }
    if (command_name == Fix.UNIFIED_CONVICTION) { return Fix.BuffType.Positive; }
    // 弓術＋心眼
    if (command_name == Fix.ABSOLUTE_ARROW) { return Fix.BuffType.None; }
    if (command_name == Fix.HEAVENS_WISDOM) { return Fix.BuffType.Positive; }
    // 弓術＋無心
    if (command_name == Fix.SILENT_MEDITATION) { return Fix.BuffType.Positive; }
    if (command_name == Fix.COLORLESS_FORM) { return Fix.BuffType.Neutral; }
    // 心眼＋無心 [完全逆]
    if (command_name == Fix.OVERWHELMING_DESTINY) { return Fix.BuffType.None; }
    if (command_name == Fix.WORLD_CHANT) { return Fix.BuffType.Positive; }
    #endregion

    #region "Archetype"
    if (command_name == Fix.ARCHETYPE_EIN_1) { return Fix.BuffType.Neutral; } // Neutralは有益／有害のいずれでもないので、打ち消し難い
    #endregion

    #region "Other"
    if (command_name == Fix.AIR_CUTTER) { return Fix.BuffType.Positive; }
    if (command_name == Fix.ROCK_SLAM) { return Fix.BuffType.Negative; }
    if (command_name == Fix.VENOM_SLASH) { return Fix.BuffType.Negative; }
    if (command_name == Fix.AURA_OF_POWER) { return Fix.BuffType.Positive; }
    if (command_name == Fix.HEART_OF_LIFE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.DARKNESS_CIRCLE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.STORM_ARMOR) { return Fix.BuffType.Positive; }
    if (command_name == Fix.SOLID_WALL) { return Fix.BuffType.Positive; }
    if (command_name == Fix.INVISIBLE_BIND) { return Fix.BuffType.Negative; }
    if (command_name == Fix.IDEOLOGY_OF_SOPHISTICATION) { return Fix.BuffType.Neutral; } // Neutralは有益／有害のいずれでもないので、打ち消し難い
    if (command_name == Fix.SKY_SHIELD) { return Fix.BuffType.Positive; }
    if (command_name == Fix.STANCE_OF_THE_SHADE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.SONIC_PULSE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.LAND_SHATTER) { return Fix.BuffType.Negative; }
    if (command_name == Fix.MUTE_IMPULSE) { return Fix.BuffType.None; }
    if (command_name == Fix.AETHER_DRIVE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.KILLING_WAVE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.IRREGULAR_STEP) { return Fix.BuffType.None; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return Fix.BuffType.None; }
    #endregion

    #region "Monster"
    // 以降、モンスターアクションは基本０とする。
    if (command_name == Fix.COMMAND_HIKKAKI) { return 0; }
    if (command_name == Fix.COMMAND_GREEN_NENEKI) { return 0; }
    if (command_name == Fix.COMMAND_KANAKIRI) { return 0; }
    if (command_name == Fix.COMMAND_WILD_CLAW) { return 0; }
    if (command_name == Fix.COMMAND_KAMITSUKI) { return 0; }
    if (command_name == Fix.COMMAND_TREE_SONG) { return 0; }
    if (command_name == Fix.COMMAND_SUN_FIRE) { return 0; }
    if (command_name == Fix.COMMAND_TOSSHIN) { return 0; }
    if (command_name == Fix.COMMAND_FEATHER_WING) { return 0; }
    if (command_name == Fix.COMMAND_DASH_KERI) { return 0; }
    if (command_name == Fix.COMMAND_SUITSUKU_TSUTA) { return 0; }
    if (command_name == Fix.COMMAND_SPIDER_NET) { return 0; }
    if (command_name == Fix.COMMAND_POISON_KOKE) { return 0; }
    if (command_name == Fix.COMMAND_CONTINUOUS_ATTACK) { return 0; }
    if (command_name == Fix.COMMAND_FIRE_EMISSION) { return 0; }
    if (command_name == Fix.COMMAND_SUPER_TOSSHIN) { return 0; }
    if (command_name == Fix.COMMAND_POISON_RINPUN) { return 0; }
    if (command_name == Fix.COMMAND_YOUEN_FIRE) { return 0; }
    if (command_name == Fix.COMMAND_BLAZE_DANCE) { return 0; }
    if (command_name == Fix.COMMAND_DRILL_CYCLONE) { return 0; }
    if (command_name == Fix.COMMAND_RUMBLE_MACHINEGUN) { return 0; }
    if (command_name == Fix.COMMAND_STRUGGLE_VOICE) { return 0; }
    if (command_name == Fix.COMMAND_GAREKI_TSUBUTE) { return 0; }
    if (command_name == Fix.COMMAND_SHADOW_SPEAR) { return 0; }
    if (command_name == Fix.COMMAND_MIDARE_GIRI) { return 0; }
    if (command_name == Fix.COMMAND_MIRROR_SHIELD) { return 0; }
    if (command_name == Fix.COMMAND_HAND_CANNON) { return 0; }
    if (command_name == Fix.COMMAND_SAIMIN_DANCE) { return 0; }
    if (command_name == Fix.COMMAND_POISON_NEEDLE) { return 0; }
    if (command_name == Fix.COMMAND_SPIKE_SHOT) { return 0; }
    if (command_name == Fix.COMMAND_THUNDER_CLOUD) { return 0; }
    if (command_name == Fix.COMMAND_SPAAAARK) { return 0; }
    if (command_name == Fix.COMMAND_SUPER_RANDOM_CANNON) { return 0; }
    if (command_name == Fix.COMMAND_ELECTRO_RAILGUN) { return 0; }

    if (command_name == Fix.COMMAND_WILD_STORM) { return 0; }
    if (command_name == Fix.COMMAND_YOUKAIEKI) { return 0; }
    if (command_name == Fix.COMMAND_POISON_TONGUE) { return 0; }
    if (command_name == Fix.COMMAND_CONSTRICT) { return 0; }

    if (command_name == Fix.COMMAND_STINKY_BREATH) { return 0; }
    if (command_name == Fix.COMMAND_CHARGE_LANCE) { return 0; }
    if (command_name == Fix.COMMAND_JUBAKU_ON) { return 0; }
    if (command_name == Fix.COMMAND_ZINARI) { return 0; }
    if (command_name == Fix.COMMAND_BOUHATSU) { return 0; }
    if (command_name == Fix.COMMAND_SURUDOI_HIKKAKI) { return 0; }
    if (command_name == Fix.COMMAND_HAGESHII_KAMITSUKI) { return 0; }
    if (command_name == Fix.COMMAND_BOLT_FRAME) { return 0; }
    if (command_name == Fix.COMMAND_BOOOOMB) { return 0; }
    if (command_name == Fix.COMMAND_STONE_RAIN) { return 0; }
    if (command_name == Fix.COMMAND_TARGETTING_SHOT) { return 0; }
    if (command_name == Fix.COMMAND_POWERED_ATTACK) { return 0; }
    if (command_name == Fix.COMMAND_SUSPICIOUS_VIAL) { return 0; }

    if (command_name == Fix.COMMAND_LIGHTNING_OUTBURST) { return 0; }
    #endregion

    #region "一般系統"
    if (command_name == Fix.EFFECT_POISON) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_SILENT) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_BIND) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_SLEEP) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_STUN) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_PARALYZE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_FREEZE) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_FEAR) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_TEMPTATION) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_SLOW) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_DIZZY) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_SLIP) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_CANNOT_RESURRECT) { return Fix.BuffType.Negative; }

    if (command_name == Fix.EFFECT_SHADOW_BLAST) { return Fix.BuffType.Negative; }
    if (command_name == Fix.EFFECT_FORTUNE) { return Fix.BuffType.Positive; }
    if (command_name == Fix.EFFECT_HEART_OF_LIFE) { return Fix.BuffType.Positive; }

    // モンスターコマンド
    if (command_name == Fix.EFFECT_POWERUP_FIRE) { return Fix.BuffType.Positive; }
    #endregion

    return Fix.BuffType.None;
  }

  public static int CumulativeMax(string command_name)
  {
    if (command_name == Fix.BUFF_PD_DOWN) { return 5; }
    else if (command_name == Fix.CONCUSSIVE_HIT) { return 5; }
    else if (command_name == Fix.BUFF_LIGHTNING_OUTBURST) { return 5; }
    else if (command_name == Fix.COMMAND_LIGHT_THUNDERBOLT) { return 7; }
    else if (command_name == Fix.FORTUNE_SPIRIT) { return 9; }
    else if (command_name == Fix.THE_DARK_INTENSITY) { return 9; }

    return 1; // 通常は累積なし
  }

  public static CumulativeType GetCumulativeType(string command_name)
  {
    if (command_name == Fix.FORTUNE_SPIRIT)
    {
      return CumulativeType.Cumulative;
    }
    return CumulativeType.Normal;
  }

  public static bool IsDamage(string command_name)
  {
    #region "基本／一般"
    if (command_name == Fix.NORMAL_ATTACK) { return true; }
    if (command_name == Fix.MAGIC_ATTACK) { return true; }
    if (command_name == Fix.DEFENSE) { return false; }
    if (command_name == Fix.STAY) { return false; }
    if (command_name == Fix.USE_RED_POTION_1) { return false; }
    if (command_name == Fix.USE_RED_POTION_2) { return false; }
    if (command_name == Fix.USE_RED_POTION_3) { return false; }
    if (command_name == Fix.USE_RED_POTION_4) { return false; }
    if (command_name == Fix.USE_RED_POTION_5) { return false; }
    if (command_name == Fix.USE_RED_POTION_6) { return false; }
    if (command_name == Fix.USE_RED_POTION_7) { return false; }
    if (command_name == Fix.USE_BLUE_POTION_1) { return false; }
    if (command_name == Fix.USE_BLUE_POTION_2) { return false; }
    if (command_name == Fix.USE_BLUE_POTION_3) { return false; }
    if (command_name == Fix.USE_BLUE_POTION_4) { return false; }
    if (command_name == Fix.USE_BLUE_POTION_5) { return false; }
    if (command_name == Fix.USE_BLUE_POTION_6) { return false; }
    if (command_name == Fix.USE_BLUE_POTION_7) { return false; }
    if (command_name == Fix.SMALL_RED_POTION) { return false; }
    if (command_name == Fix.SMALL_BLUE_POTION) { return false; }
    if (command_name == Fix.SMALL_GREEN_POTION) { return false; }
    if (command_name == Fix.NORMAL_RED_POTION) { return false; }
    if (command_name == Fix.NORMAL_BLUE_POTION) { return false; }
    if (command_name == Fix.NORMAL_GREEN_POTION) { return false; }
    if (command_name == Fix.LARGE_RED_POTION) { return false; }
    if (command_name == Fix.LARGE_BLUE_POTION) { return false; }
    if (command_name == Fix.LARGE_GREEN_POTION) { return false; }
    if (command_name == Fix.HUGE_RED_POTION) { return false; }
    if (command_name == Fix.HUGE_BLUE_POTION) { return false; }
    if (command_name == Fix.HUGE_GREEN_POTION) { return false; }
    if (command_name == Fix.HQ_RED_POTION) { return false; }
    if (command_name == Fix.HQ_BLUE_POTION) { return false; }
    if (command_name == Fix.HQ_GREEN_POTION) { return false; }
    if (command_name == Fix.THQ_RED_POTION) { return false; }
    if (command_name == Fix.THQ_BLUE_POTION) { return false; }
    if (command_name == Fix.THQ_GREEN_POTION) { return false; }
    if (command_name == Fix.PERFECT_RED_POTION) { return false; }
    if (command_name == Fix.PERFECT_BLUE_POTION) { return false; }
    if (command_name == Fix.PERFECT_GREEN_POTION) { return false; }
    if (command_name == Fix.PURE_CLEAN_WATER) { return false; }
    if (command_name == Fix.PURE_SINSEISUI) { return false; }
    #endregion

    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return true; }
    if (command_name == Fix.ICE_NEEDLE) { return true; }
    if (command_name == Fix.FRESH_HEAL) { return false; }
    if (command_name == Fix.SHADOW_BLAST) { return true; }
    if (command_name == Fix.ORACLE_COMMAND) { return false; }
    if (command_name == Fix.ENERGY_BOLT) { return true; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return true; }
    if (command_name == Fix.SHIELD_BASH) { return true; }
    if (command_name == Fix.LEG_STRIKE) { return true; }
    if (command_name == Fix.HUNTER_SHOT) { return true; }
    if (command_name == Fix.TRUE_SIGHT) { return false; }
    if (command_name == Fix.DISPEL_MAGIC) { return false; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return false; }
    if (command_name == Fix.PURE_PURIFICATION) { return false; }
    if (command_name == Fix.DIVINE_CIRCLE) { return false; }
    if (command_name == Fix.BLOOD_SIGN) { return false; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return false; }
    if (command_name == Fix.FLASH_COUNTER) { return false; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return true; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return false; }
    if (command_name == Fix.SPEED_STEP) { return true; }
    if (command_name == Fix.MULTIPLE_SHOT) { return true; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return false; }
    if (command_name == Fix.SPIRITUAL_REST) { return false; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return true; }
    if (command_name == Fix.BLUE_BULLET) { return true; }
    if (command_name == Fix.HOLY_BREATH) { return false; }
    if (command_name == Fix.BLACK_CONTRACT) { return false; }
    if (command_name == Fix.WORD_OF_POWER) { return true; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return false; }
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return true; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return true; }
    if (command_name == Fix.BONE_CRUSH) { return true; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return false; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return false; }
    if (command_name == Fix.UNSEEN_AID) { return false; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return true; }
    if (command_name == Fix.FREEZING_CUBE) { return true; }
    if (command_name == Fix.ANGELIC_ECHO) { return false; }
    if (command_name == Fix.CURSED_EVANGILE) { return false; }
    if (command_name == Fix.GALE_WIND) { return false; }
    if (command_name == Fix.PHANTOM_OBORO) { return false; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return true; }
    if (command_name == Fix.DOMINATION_FIELD) { return false; }
    if (command_name == Fix.DEADLY_DRIVE) { return false; }
    if (command_name == Fix.PENETRATION_ARROW) { return true; }
    if (command_name == Fix.WILL_AWAKENING) { return false; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return false; }
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return true; }
    if (command_name == Fix.FROST_LANCE) { return true; }
    if (command_name == Fix.SHINING_HEAL) { return false; }
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return false; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return false; }
    if (command_name == Fix.COUNTER_DISALLOW) { return false; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return true; }
    if (command_name == Fix.HARDEST_PARRY) { return false; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return true; }
    if (command_name == Fix.PRECISION_STRIKE) { return true; }
    if (command_name == Fix.EVERFLOW_MIND) { return false; }
    if (command_name == Fix.INNER_INSPIRATION) { return false; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return false; } // todo 仮
    if (command_name == Fix.WATER_PRESENCE) { return false; } // todo 仮
    if (command_name == Fix.VALKYRIE_BLADE) { return false; } // todo 仮
    if (command_name == Fix.THE_DARK_INTENSITY) { return false; } // todo 仮
    if (command_name == Fix.FUTURE_VISION) { return false; } // todo 仮
    if (command_name == Fix.DETACHMENT_FAULT) { return false; } // todo 仮  // Neutralは有益／有害のいずれでもないので、打ち消し難い
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return false; } // todo 仮
    if (command_name == Fix.ONE_IMMUNITY) { return false; } // todo 仮
    if (command_name == Fix.STANCE_OF_MUIN) { return false; } // todo 仮
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return false; } // todo 仮
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return false; } // todo 仮
    if (command_name == Fix.ZERO_IMMUNITY) { return false; } // todo 仮
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return true; } // todo 仮
    if (command_name == Fix.ABSOLUTE_ZERO) { return false; } // todo 仮
    if (command_name == Fix.RESURRECTION) { return false; } // todo 仮
    if (command_name == Fix.DEATH_SCYTHE) { return true; } // todo 仮
    if (command_name == Fix.GENESIS) { return false; } // todo 仮
    if (command_name == Fix.TIME_SKIP) { return false; } // todo 仮
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return true; } // todo 仮
    if (command_name == Fix.CATASTROPHE) { return true; } // todo 仮
    if (command_name == Fix.CARNAGE_RUSH) { return true; } // todo 仮
    if (command_name == Fix.PIERCING_ARROW) { return true; } // todo 仮
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return false; } // todo 仮
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return false; } // todo 仮
    #endregion

    #region "複合魔法"
    // 聖＋闇 [完全逆]
    if (command_name == Fix.PSYCHIC_TRANCE) { return false; }
    if (command_name == Fix.BLIND_JUSTICE) { return false; }
    if (command_name == Fix.DEATH_DENY) { return false; }
    // 聖＋炎
    if (command_name == Fix.FLASH_BLAZE) { return true; }
    if (command_name == Fix.LIGHT_DETONATOR) { return true; }
    if (command_name == Fix.ASCENDANT_METEOR) { return true; }
    // 聖＋氷
    if (command_name == Fix.SKY_SHIELD) { return false; }
    if (command_name == Fix.SACRED_FIELD) { return false; }
    if (command_name == Fix.SAINT_JUDGEMENT) { return true; }
    // 聖＋理
    if (command_name == Fix.HOLY_BREAKER) { return false; }
    if (command_name == Fix.EXALTED_FIELD) { return false; }
    if (command_name == Fix.HYMN_CONTRACT) { return false; }
    // 聖＋空唱
    if (command_name == Fix.VOID_THUNDER) { return true; }
    if (command_name == Fix.ANGEL_INTERVENTION) { return false; }
    if (command_name == Fix.ENDLESS_ANTHEM) { return false; }
    // 闇＋炎
    if (command_name == Fix.BLACK_FIRE) { return true; }
    if (command_name == Fix.BLAZING_FIELD) { return false; }
    if (command_name == Fix.DEMONIC_IGNITE) { return true; }
    // 闇＋氷
    if (command_name == Fix.DEEP_MIRROR) { return false; }
    if (command_name == Fix.STORM_SHARD) { return false; }
    if (command_name == Fix.ABYSS_EYE) { return true; }
    // 闇＋理
    if (command_name == Fix.WORD_OF_MALICE) { return true; }
    if (command_name == Fix.SIN_FORTUNE) { return false; }
    if (command_name == Fix.BLOOD_SHACKLE) { return false; }
    // 闇＋空唱
    if (command_name == Fix.ACHROMA_BLAST) { return true; }
    if (command_name == Fix.DOOM_BLADE) { return false; }
    if (command_name == Fix.ECLIPSE_END) { return false; }
    // 炎＋氷 [完全逆]
    if (command_name == Fix.CHILL_BURN) { return true; }
    if (command_name == Fix.SWORD_OF_FREEZING_FIRE) { return false; }
    if (command_name == Fix.ZETA_EXPLOSION) { return true; }
    // 炎＋理
    if (command_name == Fix.BURST_INFERNO) { return false; }
    if (command_name == Fix.PIERCING_FLAME) { return true; }
    if (command_name == Fix.SIGIL_OF_HOMURA) { return false; }
    // 炎＋空唱
    if (command_name == Fix.ERRATIC_THUNDERBOLT) { return true; }
    if (command_name == Fix.STEAM_MIRROR) { return false; }
    if (command_name == Fix.RED_DRAGON_WILL) { return false; }
    // 氷＋理
    if (command_name == Fix.WORD_OF_ATTITUDE) { return false; }
    if (command_name == Fix.ICICLE_BARRIER) { return false; }
    if (command_name == Fix.AUSTERITY_MATRIX) { return false; }
    // 氷＋空唱
    if (command_name == Fix.GLACIAL_CIRCLE) { return false; }
    if (command_name == Fix.VORTEX_SONG) { return false; }
    if (command_name == Fix.BLUE_DRAGON_WILL) { return false; }
    // 理＋空唱 [完全逆]
    if (command_name == Fix.WORD_OF_NINE) { return false; }
    if (command_name == Fix.PARADOX_IMAGE) { return false; }
    if (command_name == Fix.WARP_GATE) { return false; }
    #endregion

    #region "複合スキル"
    // 戦士＋護衛 [完全逆]
    if (command_name == Fix.NEUTRAL_SMASH) { return true; }
    if (command_name == Fix.STANCE_OF_DOUBLE) { return false; }
    // 戦士＋格闘
    if (command_name == Fix.BLITZ_STRIKE) { return false; } // カウンター後にダメージを与えるが、原点はカウンターであるため、falseでよい。
    if (command_name == Fix.ASSASSINATION_HIT) { return true; }
    // 戦士＋弓術
    if (command_name == Fix.PHOENIX_EYE) { return false; }
    if (command_name == Fix.HARDENED_INSIGHT) { return false; }
    // 戦士＋心眼
    if (command_name == Fix.CHALLENGING_SHOUT) { return false; }
    if (command_name == Fix.ONSLAUGHT_HIT) { return true; }
    // 戦士＋無心
    if (command_name == Fix.FORMLESS_STYLE) { return false; }
    if (command_name == Fix.HARDEST_PARRY) { return false; }
    // 護衛＋格闘
    if (command_name == Fix.TACTICAL_VISION) { return false; }
    if (command_name == Fix.SWIFT_RESPONSE) { return false; }
    // 護衛＋弓術
    if (command_name == Fix.RIGHTEOUSNESS_ARROW) { return false; }
    if (command_name == Fix.PERFECT_EVASION) { return false; }
    // 護衛＋心眼
    if (command_name == Fix.REFLEX_ESSENCE) { return false; }
    if (command_name == Fix.SELF_PERSUASION) { return false; }
    // 護衛＋無心
    if (command_name == Fix.TRUST_SILENCE) { return false; }
    if (command_name == Fix.NOURISH_POWER) { return false;}
    // 格闘＋弓術 [完全逆]
    if (command_name == Fix.SUDDEN_STRIKEARROW) { return true; }
    if (command_name == Fix.STANCE_OF_MYSTIC) { return false; }
    // 格闘＋心眼
    if (command_name == Fix.PSYCHIC_WAVE) { return true; }
    if (command_name == Fix.FLARE_OF_FIGHTING) { return false; }
    // 格闘＋無心
    if (command_name == Fix.INFINITY_IMAGE) { return false; }
    if (command_name == Fix.UNIFIED_CONVICTION) { return false; }
    // 弓術＋心眼
    if (command_name == Fix.ABSOLUTE_ARROW) { return true; }
    if (command_name == Fix.HEAVENS_WISDOM) { return false; }
    // 弓術＋無心
    if (command_name == Fix.SILENT_MEDITATION) { return false; }
    if (command_name == Fix.COLORLESS_FORM) { return false; }
    // 心眼＋無心 [完全逆]
    if (command_name == Fix.OVERWHELMING_DESTINY) { return false; }
    if (command_name == Fix.WORLD_CHANT) { return false; }
    #endregion

    #region "Archetype"
    if (command_name == Fix.ARCHETYPE_EIN_1) { return false; }
    #endregion

    #region "Other"
    if (command_name == Fix.AIR_CUTTER) { return true; }
    if (command_name == Fix.ROCK_SLAM) { return true; }
    if (command_name == Fix.VENOM_SLASH) { return true; }
    if (command_name == Fix.AURA_OF_POWER) { return false; }
    if (command_name == Fix.HEART_OF_LIFE) { return false; }
    if (command_name == Fix.DARKNESS_CIRCLE) { return false; }
    if (command_name == Fix.STORM_ARMOR) { return false; }
    if (command_name == Fix.SOLID_WALL) { return false; }
    if (command_name == Fix.INVISIBLE_BIND) { return true; }
    if (command_name == Fix.IDEOLOGY_OF_SOPHISTICATION) { return false; }
    if (command_name == Fix.SKY_SHIELD) { return false; }
    if (command_name == Fix.STANCE_OF_THE_SHADE) { return false; }
    if (command_name == Fix.SONIC_PULSE) { return true; }
    if (command_name == Fix.LAND_SHATTER) { return true; }
    if (command_name == Fix.MUTE_IMPULSE) { return true; }
    if (command_name == Fix.AETHER_DRIVE) { return false; }
    if (command_name == Fix.KILLING_WAVE) { return false; }
    if (command_name == Fix.IRREGULAR_STEP) { return false; }
    if (command_name == Fix.COMMAND_SEA_STRIVE) { return true; }
    if (command_name == Fix.COMMAND_PLATINUM_BLADE) { return true; }
    if (command_name == Fix.COMMAND_CHARGE) { return true; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return false; }
    #endregion

    #region "一般系統"
    if (command_name == Fix.EFFECT_POISON) { return true; }
    if (command_name == Fix.EFFECT_SLIP) { return true; }
    if (command_name == Fix.EFFECT_STUN) { return false; }
    if (command_name == Fix.EFFECT_SHADOW_BLAST) { return true; }
    if (command_name == Fix.EFFECT_FORTUNE) { return false; }
    if (command_name == Fix.EFFECT_HEART_OF_LIFE) { return false; }
    #endregion

    return false;
  }

  public static string To_JP(string command_name)
  {
    // todo 基本／一般／アイテム系は色々足りていない可能性がある。
    #region "基本／一般"
    if (command_name == Fix.NORMAL_ATTACK) { return Fix.NORMAL_ATTACK_JP ; }
    if (command_name == Fix.MAGIC_ATTACK) { return Fix.MAGIC_ATTACK_JP; }
    if (command_name == Fix.DEFENSE) { return Fix.DEFENSE_JP; }
    if (command_name == Fix.STAY) { return Fix.STAY_JP; }
    #endregion

    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return Fix.FIRE_BALL_JP; }
    if (command_name == Fix.ICE_NEEDLE) { return Fix.ICE_NEEDLE_JP; }
    if (command_name == Fix.FRESH_HEAL) { return Fix.FRESH_HEAL_JP; }
    if (command_name == Fix.SHADOW_BLAST) { return Fix.SHADOW_BLAST_JP; }
    if (command_name == Fix.ORACLE_COMMAND) { return Fix.ORACLE_COMMAND_JP; }
    if (command_name == Fix.ENERGY_BOLT) { return Fix.ENERGY_BOLT_JP; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return Fix.STRAIGHT_SMASH_JP; }
    if (command_name == Fix.SHIELD_BASH) { return Fix.SHIELD_BASH_JP; }
    if (command_name == Fix.LEG_STRIKE) { return Fix.LEG_STRIKE_JP; }
    if (command_name == Fix.HUNTER_SHOT) { return Fix.HUNTER_SHOT_JP; }
    if (command_name == Fix.TRUE_SIGHT) { return Fix.TRUE_SIGHT_JP; }
    if (command_name == Fix.DISPEL_MAGIC) { return Fix.DISPEL_MAGIC_JP; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return Fix.FLAME_BLADE_JP; }
    if (command_name == Fix.PURE_PURIFICATION) { return Fix.PURE_PURIFICATION_JP; }
    if (command_name == Fix.DIVINE_CIRCLE) { return Fix.DIVINE_CIRCLE_JP; }
    if (command_name == Fix.BLOOD_SIGN) { return Fix.BLOOD_SIGN_JP; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return Fix.FORTUNE_SPIRIT_JP; }
    if (command_name == Fix.FLASH_COUNTER) { return Fix.FLASH_COUNTER_JP; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return Fix.STANCE_OF_THE_BLADE_JP; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return Fix.STANCE_OF_THE_GUARD_JP; }
    if (command_name == Fix.SPEED_STEP) { return Fix.SPEED_STEP_JP; }
    if (command_name == Fix.MULTIPLE_SHOT) { return Fix.MULTIPLE_SHOT_JP; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return Fix.LEYLINE_SCHEMA_JP; }
    if (command_name == Fix.SPIRITUAL_REST) { return Fix.SPIRITUAL_REST_JP; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return Fix.METEOR_BULLET_JP; }
    if (command_name == Fix.BLUE_BULLET) { return Fix.BLUE_BULLET_JP; }
    if (command_name == Fix.HOLY_BREATH) { return Fix.HOLY_BREATH_JP; }
    if (command_name == Fix.BLACK_CONTRACT) { return Fix.BLACK_CONTRACT_JP; }
    if (command_name == Fix.WORD_OF_POWER) { return Fix.WORD_OF_POWER_JP; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return Fix.SIGIL_OF_THE_PENDING_JP; }
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return Fix.DOUBLE_SLASH_JP; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return Fix.CONCUSSIVE_HIT_JP; }
    if (command_name == Fix.BONE_CRUSH) { return Fix.BONE_CRUSH_JP; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return Fix.EYE_OF_THE_ISSHIN_JP; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return Fix.VOICE_OF_VIGOR_JP; }
    if (command_name == Fix.UNSEEN_AID) { return Fix.UNSEEN_AID_JP; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return Fix.VOLCANIC_BLAZE_JP; }
    if (command_name == Fix.FREEZING_CUBE) { return Fix.FREEZING_CUBE_JP; }
    if (command_name == Fix.ANGELIC_ECHO) { return Fix.ANGELIC_ECHO_JP; }
    if (command_name == Fix.CURSED_EVANGILE) { return Fix.CURSED_EVANGILE_JP; }
    if (command_name == Fix.GALE_WIND) { return Fix.GALE_WIND_JP; }
    if (command_name == Fix.PHANTOM_OBORO) { return Fix.PHANTOM_OBORO_JP; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return Fix.IRON_BUSTER_JP; }
    if (command_name == Fix.DOMINATION_FIELD) { return Fix.DOMINATION_FIELD_JP; }
    if (command_name == Fix.DEADLY_DRIVE) { return Fix.DEADLY_DRIVE_JP; }
    if (command_name == Fix.PENETRATION_ARROW) { return Fix.PENETRATION_ARROW_JP; }
    if (command_name == Fix.WILL_AWAKENING) { return Fix.WILL_AWAKENING_JP; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return Fix.CIRCLE_OF_SERENITY_JP; }
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return Fix.FLAME_STRIKE_JP; }
    if (command_name == Fix.FROST_LANCE) { return Fix.FROST_LANCE_JP; }
    if (command_name == Fix.SHINING_HEAL) { return Fix.SHINING_HEAL_JP; }
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return Fix.CIRCLE_OF_THE_DESPAIR_JP; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return Fix.SEVENTH_PRINCIPLE_JP; }
    if (command_name == Fix.COUNTER_DISALLOW) { return Fix.COUNTER_DISALLOW_JP; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return Fix.RAGING_STORM_JP; }
    if (command_name == Fix.HARDEST_PARRY) { return Fix.HARDEST_PARRY_JP; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return Fix.UNINTENTIONAL_HIT_JP; }
    if (command_name == Fix.PRECISION_STRIKE) { return Fix.PRECISION_STRIKE_JP; }
    if (command_name == Fix.EVERFLOW_MIND) { return Fix.EVERFLOW_MIND_JP; }
    if (command_name == Fix.INNER_INSPIRATION) { return Fix.INNER_INSPIRATION_JP; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return Fix.CIRCLE_OF_THE_IGNITE_JP; }
    if (command_name == Fix.WATER_PRESENCE) { return Fix.WATER_PRESENCE_JP; }
    if (command_name == Fix.VALKYRIE_BLADE) { return Fix.VALKYRIE_BLADE_JP; }
    if (command_name == Fix.THE_DARK_INTENSITY) { return Fix.THE_DARK_INTENSITY_JP; }
    if (command_name == Fix.FUTURE_VISION) { return Fix.FUTURE_VISION_JP; }
    if (command_name == Fix.DETACHMENT_FAULT) { return Fix.DETACHMENT_FAULT_JP; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return Fix.STANCE_OF_THE_IAI_JP; }
    if (command_name == Fix.ONE_IMMUNITY) { return Fix.ONE_IMMUNITY_JP; }
    if (command_name == Fix.STANCE_OF_MUIN) { return Fix.STANCE_OF_MUIN_JP; }
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return Fix.ETERNAL_CONCENTRATION_JP; }
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return Fix.SIGIL_OF_THE_FAITH_JP; }
    if (command_name == Fix.ZERO_IMMUNITY) { return Fix.ZERO_IMMUNITY_JP; }
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return Fix.LAVA_ANNIHILATION_JP; }
    if (command_name == Fix.ABSOLUTE_ZERO) { return Fix.ABSOLUTE_ZERO_JP; }
    if (command_name == Fix.RESURRECTION) { return Fix.RESURRECTION_JP; }
    if (command_name == Fix.DEATH_SCYTHE) { return Fix.DEATH_SCYTHE_JP; }
    if (command_name == Fix.GENESIS) { return Fix.GENESIS_JP; }
    if (command_name == Fix.TIME_SKIP) { return Fix.TIME_SKIP_JP; }
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return Fix.KINETIC_SMASH_JP; }
    if (command_name == Fix.CATASTROPHE) { return Fix.CATASTROPHE_JP; }
    if (command_name == Fix.CARNAGE_RUSH) { return Fix.CARNAGE_RUSH_JP; }
    if (command_name == Fix.PIERCING_ARROW) { return Fix.PIERCING_ARROW_JP; }
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return Fix.STANCE_OF_THE_KOKOROE_JP; }
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return Fix.TRANSCENDENCE_REACHED_JP; }
    #endregion

    #region "複合魔法"
    // 聖＋闇 [完全逆]
    if (command_name == Fix.PSYCHIC_TRANCE) { return Fix.PSYCHIC_TRANCE_JP; }
    if (command_name == Fix.BLIND_JUSTICE) { return Fix.BLIND_JUSTICE_JP; }
    if (command_name == Fix.DEATH_DENY) { return Fix.DEATH_DENY_JP; }
    // 聖＋炎
    if (command_name == Fix.FLASH_BLAZE) { return Fix.FLASH_BLAZE_JP; }
    if (command_name == Fix.LIGHT_DETONATOR) { return Fix.LIGHT_DETONATOR_JP; }
    if (command_name == Fix.ASCENDANT_METEOR) { return Fix.ASCENDANT_METEOR_JP; }
    // 聖＋氷
    if (command_name == Fix.SKY_SHIELD) { return Fix.SKY_SHIELD_JP; }
    if (command_name == Fix.SACRED_FIELD) { return Fix.SACRED_FIELD_JP; }
    if (command_name == Fix.SAINT_JUDGEMENT) { return Fix.SAINT_JUDGEMENT_JP; }
    // 聖＋理
    if (command_name == Fix.HOLY_BREAKER) { return Fix.HOLY_BREAKER_JP; }
    if (command_name == Fix.EXALTED_FIELD) { return Fix.EXALTED_FIELD_JP; }
    if (command_name == Fix.HYMN_CONTRACT) { return Fix.HYMN_CONTRACT_JP; }
    // 聖＋空唱
    if (command_name == Fix.VOID_THUNDER) { return Fix.VOID_THUNDER_JP; }
    if (command_name == Fix.ANGEL_INTERVENTION) { return Fix.ANGEL_INTERVENTION_JP; }
    if (command_name == Fix.ENDLESS_ANTHEM) { return Fix.ENDLESS_ANTHEM_JP; }
    // 闇＋炎
    if (command_name == Fix.BLACK_FIRE) { return Fix.BLACK_FIRE_JP; }
    if (command_name == Fix.BLAZING_FIELD) { return Fix.BLAZING_FIELD_JP; }
    if (command_name == Fix.DEMONIC_IGNITE) { return Fix.DEMONIC_IGNITE_JP; }
    // 闇＋氷
    if (command_name == Fix.DEEP_MIRROR) { return Fix.DEEP_MIRROR_JP; }
    if (command_name == Fix.STORM_SHARD) { return Fix.STORM_SHARD_JP; }
    if (command_name == Fix.ABYSS_EYE) { return Fix.ABYSS_EYE_JP; }
    // 闇＋理
    if (command_name == Fix.WORD_OF_MALICE) { return Fix.WORD_OF_MALICE_JP; }
    if (command_name == Fix.SIN_FORTUNE) { return Fix.SIN_FORTUNE_JP; }
    if (command_name == Fix.BLOOD_SHACKLE) { return Fix.BLOOD_SHACKLE_JP; }
    // 闇＋空唱
    if (command_name == Fix.ACHROMA_BLAST) { return Fix.ACHROMA_BLAST_JP; }
    if (command_name == Fix.DOOM_BLADE) { return Fix.DOOM_BLADE_JP; }
    if (command_name == Fix.ECLIPSE_END) { return Fix.ECLIPSE_END_JP; }
    // 炎＋氷 [完全逆]
    if (command_name == Fix.CHILL_BURN) { return Fix.CHILL_BURN_JP; }
    if (command_name == Fix.SWORD_OF_FREEZING_FIRE) { return Fix.SWORD_OF_FREEZING_FIRE_JP; }
    if (command_name == Fix.ZETA_EXPLOSION) { return Fix.ZETA_EXPLOSION_JP; }
    // 炎＋理
    if (command_name == Fix.BURST_INFERNO) { return Fix.BURST_INFERNO_JP; }
    if (command_name == Fix.PIERCING_FLAME) { return Fix.PIERCING_FLAME_JP; }
    if (command_name == Fix.SIGIL_OF_HOMURA) { return Fix.SIGIL_OF_HOMURA_JP; }
    // 炎＋空唱
    if (command_name == Fix.ERRATIC_THUNDERBOLT) { return Fix.ERRATIC_THUNDERBOLT_JP; }
    if (command_name == Fix.STEAM_MIRROR) { return Fix.STEAM_MIRROR_JP; }
    if (command_name == Fix.RED_DRAGON_WILL) { return Fix.RED_DRAGON_WILL_JP; }
    // 氷＋理
    if (command_name == Fix.WORD_OF_ATTITUDE) { return Fix.WORD_OF_ATTITUDE_JP; }
    if (command_name == Fix.ICICLE_BARRIER) { return Fix.ICICLE_BARRIER_JP; }
    if (command_name == Fix.AUSTERITY_MATRIX) { return Fix.AUSTERITY_MATRIX_JP; }
    // 氷＋空唱
    if (command_name == Fix.GLACIAL_CIRCLE) { return Fix.GLACIAL_CIRCLE_JP; }
    if (command_name == Fix.VORTEX_SONG) { return Fix.VORTEX_SONG_JP; }
    if (command_name == Fix.BLUE_DRAGON_WILL) { return Fix.BLUE_DRAGON_WILL_JP; }
    // 理＋空唱 [完全逆]
    if (command_name == Fix.WORD_OF_NINE) { return Fix.WORD_OF_NINE_JP; }
    if (command_name == Fix.PARADOX_IMAGE) { return Fix.PARADOX_IMAGE_JP; }
    if (command_name == Fix.WARP_GATE) { return Fix.WARP_GATE_JP; }
    #endregion

    #region "複合スキル"
    // 戦士＋護衛 [完全逆]
    if (command_name == Fix.NEUTRAL_SMASH) { return Fix.NEUTRAL_SMASH_JP; }
    if (command_name == Fix.STANCE_OF_DOUBLE) { return Fix.STANCE_OF_DOUBLE_JP; }
    // 戦士＋格闘
    if (command_name == Fix.BLITZ_STRIKE) { return Fix.BLITZ_STRIKE_JP; }
    if (command_name == Fix.ASSASSINATION_HIT) { return Fix.ASSASSINATION_HIT_JP; }
    // 戦士＋弓術
    if (command_name == Fix.PHOENIX_EYE) { return Fix.PHOENIX_EYE_JP; }
    if (command_name == Fix.HARDENED_INSIGHT) { return Fix.HARDENED_INSIGHT_JP; }
    // 戦士＋心眼
    if (command_name == Fix.CHALLENGING_SHOUT) { return Fix.CHALLENGING_SHOUT_JP; }
    if (command_name == Fix.ONSLAUGHT_HIT) { return Fix.ONSLAUGHT_HIT_JP; }
    // 戦士＋無心
    if (command_name == Fix.FORMLESS_STYLE) { return Fix.FORMLESS_STYLE_JP; }
    if (command_name == Fix.HARDEST_PARRY) { return Fix.HARDEST_PARRY_JP; }
    // 護衛＋格闘
    if (command_name == Fix.TACTICAL_VISION) { return Fix.TACTICAL_VISION_JP; }
    if (command_name == Fix.SWIFT_RESPONSE) { return Fix.SWIFT_RESPONSE_JP; }
    // 護衛＋弓術
    if (command_name == Fix.RIGHTEOUSNESS_ARROW) { return Fix.RIGHTEOUSNESS_ARROW_JP; }
    if (command_name == Fix.PERFECT_EVASION) { return Fix.PERFECT_EVASION_JP; }
    // 護衛＋心眼
    if (command_name == Fix.REFLEX_ESSENCE) { return Fix.REFLEX_ESSENCE_JP; }
    if (command_name == Fix.SELF_PERSUASION) { return Fix.SELF_PERSUASION_JP; }
    // 護衛＋無心
    if (command_name == Fix.TRUST_SILENCE) { return Fix.TRUST_SILENCE_JP; }
    if (command_name == Fix.NOURISH_POWER) { return Fix.NOURISH_POWER_JP; }
    // 格闘＋弓術 [完全逆]
    if (command_name == Fix.SUDDEN_STRIKEARROW) { return Fix.SUDDEN_STRIKEARROW_JP; }
    if (command_name == Fix.STANCE_OF_MYSTIC) { return Fix.STANCE_OF_MYSTIC_JP; }
    // 格闘＋心眼
    if (command_name == Fix.PSYCHIC_WAVE) { return Fix.PSYCHIC_WAVE_JP; }
    if (command_name == Fix.FLARE_OF_FIGHTING) { return Fix.FLARE_OF_FIGHTING_JP; }
    // 格闘＋無心
    if (command_name == Fix.INFINITY_IMAGE) { return Fix.INFINITY_IMAGE_JP; }
    if (command_name == Fix.UNIFIED_CONVICTION) { return Fix.UNIFIED_CONVICTION_JP; }
    // 弓術＋心眼
    if (command_name == Fix.ABSOLUTE_ARROW) { return Fix.ABSOLUTE_ARROW_JP; }
    if (command_name == Fix.HEAVENS_WISDOM) { return Fix.HEAVENS_WISDOM_JP; }
    // 弓術＋無心
    if (command_name == Fix.SILENT_MEDITATION) { return Fix.SILENT_MEDITATION_JP; }
    if (command_name == Fix.COLORLESS_FORM) { return Fix.COLORLESS_FORM_JP; }
    // 心眼＋無心 [完全逆]
    if (command_name == Fix.OVERWHELMING_DESTINY) { return Fix.OVERWHELMING_DESTINY_JP; }
    if (command_name == Fix.WORLD_CHANT) { return Fix.WORLD_CHANT; }
    #endregion

    #region "Archetype"
    if (command_name == Fix.ARCHETYPE_EIN_1) { return Fix.ARCHETYPE_EIN_1; }
    #endregion

    #region "Other"
    if (command_name == Fix.AIR_CUTTER) { return Fix.AIR_CUTTER_JP; }
    if (command_name == Fix.ROCK_SLAM) { return Fix.ROCK_SLAM_JP; }
    if (command_name == Fix.VENOM_SLASH) { return Fix.VENOM_SLASH_JP; }
    if (command_name == Fix.AURA_OF_POWER) { return Fix.AURA_OF_POWER_JP; }
    if (command_name == Fix.HEART_OF_LIFE) { return Fix.HEART_OF_LIFE_JP; }
    if (command_name == Fix.DARKNESS_CIRCLE) { return Fix.DARKNESS_CIRCLE_JP; }
    if (command_name == Fix.STORM_ARMOR) { return Fix.STORM_ARMOR_JP; }
    if (command_name == Fix.SOLID_WALL) { return Fix.SOLID_WALL_JP; }
    if (command_name == Fix.INVISIBLE_BIND) { return Fix.INVISIBLE_BIND_JP; }
    if (command_name == Fix.IDEOLOGY_OF_SOPHISTICATION) { return Fix.IDEOLOGY_OF_SOPHISTICATION_JP; }
    if (command_name == Fix.SKY_SHIELD) { return Fix.SKY_SHIELD_JP; }
    if (command_name == Fix.STANCE_OF_THE_SHADE) { return Fix.STANCE_OF_THE_SHADE_JP; }
    if (command_name == Fix.SONIC_PULSE) { return Fix.SONIC_PULSE_JP; }
    if (command_name == Fix.LAND_SHATTER) { return Fix.LAND_SHATTER_JP; }
    if (command_name == Fix.MUTE_IMPULSE) { return Fix.MUTE_IMPULSE_JP; }
    if (command_name == Fix.AETHER_DRIVE) { return Fix.AETHER_DRIVE_JP; }
    if (command_name == Fix.KILLING_WAVE) { return Fix.KILLING_WAVE_JP; }
    if (command_name == Fix.IRREGULAR_STEP) { return Fix.IRREGULAR_STEP_JP; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return Fix.ZERO_IMMUNITY_JP; }
    #endregion

    // todo 一般系統は色々足りていない可能性がある。
    #region "一般系統"
    //if (command_name == Fix.EFFECT_POISON) { return true; }
    //if (command_name == Fix.EFFECT_SLIP) { return true; }
    //if (command_name == Fix.EFFECT_STUN) { return false; }
    //if (command_name == Fix.EFFECT_SHADOW_BLAST) { return true; }
    //if (command_name == Fix.EFFECT_FORTUNE) { return false; }
    //if (command_name == Fix.EFFECT_HEART_OF_LIFE) { return false; }
    #endregion

    return command_name;
  }

  public static string GetDescription(string command_name)
  {
    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return "敵一体を対象とする。対象に【炎】ダメージを与える。"; }
    if (command_name == Fix.ICE_NEEDLE) { return "敵一体を対象とする。対象に【氷】ダメージを与えた後、【鈍化】のBUFFを付与する。\r\n【鈍化】が続く間、戦闘速度が減少する。"; }
    if (command_name == Fix.FRESH_HEAL) { return "味方一体を対象とする。対象のライフを回復する。"; }
    if (command_name == Fix.SHADOW_BLAST) { return "敵一体を対象とする。対象に【闇】ダメージを与えた後、【陰影】のBUFFを付与する。\r\n【陰影】が続く間、魔法防御が減少する。"; }
    if (command_name == Fix.ORACLE_COMMAND) { return "味方一体を対象とする。対象のインスタントゲージを20%進行させる。"; }
    if (command_name == Fix.ENERGY_BOLT) { return "敵一体を対象とする。対象に無属性のダメージを与える。\r\nこのダメージは魔法属性として扱われる。\r\nダメージ量は【知】を根源として算出される。"; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return "敵一体を対象とする。対象に【物理】ダメージを与える。"; }
    if (command_name == Fix.SHIELD_BASH) { return "敵一体を対象とする。対象を【物理】ダメージを与えた後、【スタン】のBUFFを付与する。\r\n【スタン】が続く間、戦闘ゲージ進行が停止する。"; }
    if (command_name == Fix.LEG_STRIKE) { return "敵一体を対象とする。対象に【物理】ダメージを与えた後、【萎縮】のBUFFを付与する。\r\n【萎縮】が続く間、対象の戦闘反応値が減少する。"; }
    if (command_name == Fix.HUNTER_SHOT) { return "敵一体を対象とする。対象に【物理】ダメージを与えた後、対象へ【標的】のBUFFを付与する。\r\n【標的】が続く間、対象はクリティカルを受ける確率が上昇する。"; }
    if (command_name == Fix.TRUE_SIGHT) { return "味方一体を対象とする。対象に【深層】のBUFFを付与する。\r\n【深層】が続く間、【沈黙】【鈍化】【暗闇】のBUFFがあったとしてもそれがあたかも無いかに様に行動する。"; }
    if (command_name == Fix.DISPEL_MAGIC) { return "敵一体を対象とする。対象にかかっている【有益】に属するBUFFを除去する。"; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return "味方一体を対象とする。対象に【炎剣】のBUFFを付与する。【炎剣】が続く間、物理攻撃を行う度に、【炎】ダメージが追加発生する。"; }
    if (command_name == Fix.PURE_PURIFICATION) { return "味方一体を対象とする。対象のライフを回復する。対象にかかっている【有害】に属するBUFFを除去する。"; }
    if (command_name == Fix.DIVINE_CIRCLE) { return "味方フィールドに、【加護】のフィールドを形成する。味方に与えられる魔法属性のダメージは【加護】のポイントに吸収される。【加護】のポイントが0以下になった場合、【加護】フィールドは消滅する。"; }
    if (command_name == Fix.BLOOD_SIGN) { return "敵一体を対象とする。対象に【失血】のBUFFを付与する。【失血】が続く間、対象はメインコマンドを行う度に、出血ダメージを食らう。"; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return "味方一体を対象とする。対象に【幸運】のBUFFを付与する。【幸運】が続く間、次の攻撃がヒットした場合、100 % クリティカルヒットとなる。ダメージを伴う1回のアクションコマンドが完了した後、このBUFFは除去される。"; }
    if (command_name == Fix.FLASH_COUNTER) { return "インスタント限定。インスタント行動が行われた際、その行動属性が【魔法】であり、BUFF付与を行うものである場合、そのインスタント行動を打ち消す。"; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return "敵一体を対象とする。対象に【物理】ダメージを与える。\r\n自分自身に【剣の構え】のBUFFを付与する。この効果が続く間、物理攻撃がヒットする度に、物理攻撃力が上昇する。このスタックは5回まで累積する。"; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return "自分自身に【盾の構え】のBUFFを付与する。この効果が続く間、防御姿勢で敵からの攻撃を受ける度に、物理防御力が上昇する。このスタックは5回まで累積する。"; }
    if (command_name == Fix.SPEED_STEP) { return "敵一体を対象とする。対象に【物理】ダメージを与えた後、自分自身に【俊足の構え】のBUFFを付与する。この効果が続く間、メイン行動が完了する度に、戦闘反応が上昇する。このスタックは５回まで累積する。"; }
    if (command_name == Fix.MULTIPLE_SHOT) { return "敵全員に【物理】ダメージを与える。"; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return "味方フィールドに【直光】のフィールドを形成する。【直光】が続く間、ターン経過毎のスキルポイント回復量が＋２される。"; }
    if (command_name == Fix.SPIRITUAL_REST) { return "味方一体を対象とする。対象が【スタン】にかかっている場合、それを除去する。加えて、対象に【鮮明】のBUFFを付与する。【鮮明】が続く間、対象は【スタン】に対する耐性を得る。"; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return "敵グループを対象とする。いずれかの敵に対して、ランダムに３回の【炎】ダメージを与える。"; }
    if (command_name == Fix.BLUE_BULLET) { return "敵一体を対象とする。対象に３回の【氷】ダメージを与える。"; }
    if (command_name == Fix.HOLY_BREATH) { return "味方全員のライフを回復する。"; }
    if (command_name == Fix.BLACK_CONTRACT) { return "自分自身を対象とし、【黒契約】のBUFFを付与する。【黒契約】が続く間、ターン経過毎に最大ライフの１０％の分だけライフを失う。アクションコマンドで消費するコストが０になる。"; }
    if (command_name == Fix.WORD_OF_POWER) { return "敵一体を対象とする。対象に【理】ダメージを与える。ダメージ量は【力】を根源として算出されるが、魔法属性として扱われる。\r\n対象が【防御】を行っていても、あたかも【防御】していないかのようにダメージを与える。\r\nこの魔法はカウンターされない。"; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return "敵一体、または味方一体を対象とする。対象に【留保】のBUFFを付与する。【留保】のBUFFが続く間、対象のターン経過毎に影響が発生する効果を無効扱いとする。"; }
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return "敵一体を対象とする。対象に２回【物理】ダメージを与える。"; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return "敵一体を対象とする。対象に物理ダメージを与え、【破損】のBUFFを付与する。【破損】が続く間、対象の物理防御が減少する。この効果は５回まで累積可能である。"; }
    if (command_name == Fix.BONE_CRUSH) { return "敵一体を対象とする。対象に【物理】ダメージを与える。対象に【損傷】のBUFFを付与する。【損傷】が続く間、対象の物理攻撃力が２０％低下する。"; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return "自分自身に【一心】のBUFFを付与する。【一心】が続く間、対象の物理防御を２０％無視して、ダメージを当てられるようになる。"; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return "味方全員に【活力】のBUFFを付与する。【活力】が続く間、最大ライフが10%上昇する。また、その分だけライフを回復する。"; }
    if (command_name == Fix.UNSEEN_AID) { return "敵味方全員を対象とする。対象にかかっている【有害】【有益】いずれのBUFFもすべて除去する。"; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return "敵全体に対して【炎】ダメージを与える。加えて、敵フィールドに、【業炎】のフィールドを形成する。\r\n【業炎】が続く間、敵全体に対して毎ターン【炎】ダメージを与える。加えて炎属性の魔法ダメージを食らう場合、２０％増加された形でダメージを食らう。"; }
    if (command_name == Fix.FREEZING_CUBE) { return "敵一体に対して【氷】ダメージを与える。加えて、敵フィールドに、【結晶】のフィールドを形成する。\r\n【結晶】が続く間、敵全体に対して毎ターン【氷】ダメージを与える。加えて氷属性の魔法ダメージを食らう場合、２０％増加された形でダメージを食らう。"; }
    if (command_name == Fix.ANGELIC_ECHO) { return "味方全員のライフを回復し、味方フィールドに【賛美】のフィールドを形成する。【賛美】が続く間、味方全体はターン経過毎にライフを回復し、負のBUFFを除去する。【賛美】は味方全体のうちいずれかに負のBUFFが残っている場合はBUFFカウントが減少せず継続される。いずれにも負のBUFFが残ってない場合はBUFFカウントが減少する。"; }
    if (command_name == Fix.CURSED_EVANGILE) { return "敵一体に対して【闇】ダメージを与える。加えて、【呪い】を付与する。【呪い】が続く間、ターンが経過するごとに【束縛】【出血】【沈黙】のいずれかが付与される。【束縛】【出血】【沈黙】が全て付与されている場合は、対象者に【闇】ダメージを与える。"; }
    if (command_name == Fix.GALE_WIND) { return "自分自身を対象とする。対象に【分身】のBUFFを付与する。\r\n【分身】の効果が続く間、コマンドを発動する際、連続で２回同じ行動を行う。"; }
    if (command_name == Fix.PHANTOM_OBORO) { return "自分自身に【朧】のBUFFを付与する。【朧】のBUFFがある間に、インスタントアクションからダメージを有する攻撃を受けた場合、そのダメージは０と見なされる。これはダメージ軽減の適用外である。"; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return "敵一体を対象とする。対象に【物理】ダメージを与える。加えて、周囲敵全体（対象となった敵以外）に対して【物理】ダメージを与える。このコマンドはカウンターされない。"; }
    if (command_name == Fix.DOMINATION_FIELD) { return "味方フィールドに【鉄壁】のBUFFを形成する。【鉄壁】が続く間、物理防御力および魔法防御力が１０％上昇する。また、各味方が【防御】姿勢を行っている場合のダメージ軽減率が20%上昇する。"; }
    if (command_name == Fix.DEADLY_DRIVE) { return "自分自身に【決死】のBUFFを付与する。【決死】が続く間、致死ダメージ（ライフが0になる攻撃ダメージ）を受けた場合、ライフ１で生き残る。この効果はライフ１以下の時は適用されない。また、ライフが最大ライフの30％以下であれば、物理攻撃が5%上昇、20%以下であれば10%上昇、10以下であれば15%上昇する。"; }
    if (command_name == Fix.PENETRATION_ARROW) { return "敵一体を対象とする。対象に【物理】ダメージを与える。対象が【防御】を行っていても、あたかも【防御】していないかのようにダメージを与える。このダメージは相手の物理防御力に影響しない。加えて対象に【傷跡】のBUFFを付与する。【傷跡】が続く間、対象の物理防御力が減少する。また、対象が行動する度に【出血】ダメージを与える。"; }
    if (command_name == Fix.WILL_AWAKENING) { return "このコマンドはカウンターされない。\r\n味方一体を対象とする。対象に【覚醒】のBUFFを付与する。【覚醒】が続く間、NormalタイミングのコマンドをInstantタイミングで使用可能となる。また、発動コマンドがカウンターされなくなる。"; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return "このコマンドは【束縛】【スタン】状態であっても発動する。味方全体に対して【沈黙】【束縛】【睡眠】【スタン】【麻痺】【恐怖】【誘惑】【鈍化】【眩暈】のBUFFを解除し、味方フィールドに【静穏】のフィールドを形成する。【静穏】が続く間、【沈黙】【束縛】【睡眠】【スタン】【麻痺】【恐怖】【誘惑】【鈍化】【眩暈】のBUFFは付与されない。"; }
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return "敵一体に対して【炎】ダメージを与える。加えて、【炎痕】のBUFFを付与する。【炎痕】が続く間、対象に【炎】属性のダメージが与えられる場合、対象が【防御】の姿勢を取っていても、それを無視して【炎】ダメージが適用される。"; }
    if (command_name == Fix.FROST_LANCE) { return "敵一体に対して【氷】ダメージを与える。加えて、【凍傷】のBUFFを付与する。【凍傷】が続く間、対象がインスタントで行動を行った場合、その行動が失敗する。"; }
    if (command_name == Fix.SHINING_HEAL) { return "味方一体を対象とする。対象のライフを全回復する。また、味方フィールドに【祝福】のBUFFを付与する。【祝福】の効果が続く間、【猛毒】【出血】の影響を受けない。"; }
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return "敵フィールドに【荒廃】のフィールドを形成する。【荒廃】の効果が続く間、物理防御力、魔法防御力、戦闘反応値がそれぞれ２０％減少する。"; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return "味方一体を対象とする。対象に【第七原理】のBUFFを付与する。【第七原理】が続く間、物理属性値の源を【知】、魔法属性値の源を【力】に転換する。"; }
    if (command_name == Fix.COUNTER_DISALLOW) { return "インスタント限定。インスタント行動が行われた際、その行動属性が【魔法】か【スキル】である場合、そのインスタント行動を打ち消す。その後、対象に【喪失】のBUFFを付与する。【喪失】が続く間、対象はインスタント行動を開始する事ができない。また開始した場合、その行動をカウンターする。"; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return "敵全体に対して【物理】ダメージを2回連続で与える。加えて【臨戦】のフィールドを形成する。その後味方フィールドに【臨戦】のBUFFが続く間、味方から敵に与える物理および魔法ダメージが１０％上昇する。"; }
    if (command_name == Fix.HARDEST_PARRY) { return "インスタント限定。インスタント行動が行われた際、その行動属性が【スキル】であり、BUFF付与を行うものである場合、そのインスタント行動を打ち消す。この行動は即座に発揮され、打ち消されない。"; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return "敵一体に対して【物理】ダメージを与える。対象に【麻痺】のBUFFを付与する。また、自分の行動ゲージを20%進め、敵一体の行動ゲージを20%戻す。（行動ゲージが100%に達した場合は、行動ゲージは100%とする。行動ゲージが0%を下回る場合は行動ゲージは0%とする。）"; }
    if (command_name == Fix.PRECISION_STRIKE) { return "インスタント限定。敵一体に対して【物理】ダメージを与える。本ダメージは必ずクリティカルヒットが適用される。"; }
    if (command_name == Fix.EVERFLOW_MIND) { return "味方一体に対して【常在】のBUFFを付与する。【常在】が続く間、インスタント行動を行った後、インスタントゲージが全て消費されず、20%残った状態となる"; }
    if (command_name == Fix.INNER_INSPIRATION) { return "味方一体を対象とする。SPを10%回復する。"; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return ""; } // todo 仮
    if (command_name == Fix.WATER_PRESENCE) { return ""; } // todo 仮
    if (command_name == Fix.VALKYRIE_BLADE) { return ""; } // todo 仮
    if (command_name == Fix.THE_DARK_INTENSITY) { return ""; } // todo 仮
    if (command_name == Fix.FUTURE_VISION) { return ""; } // todo 仮
    if (command_name == Fix.DETACHMENT_FAULT) { return ""; } // todo 仮
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return ""; } // todo 仮
    if (command_name == Fix.ONE_IMMUNITY) { return ""; } // todo 仮
    if (command_name == Fix.STANCE_OF_MUIN) { return ""; } // todo 仮
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return ""; } // todo 仮
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return ""; } // todo 仮
    if (command_name == Fix.ZERO_IMMUNITY) { return ""; } // todo 仮
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return ""; } // todo 仮
    if (command_name == Fix.ABSOLUTE_ZERO) { return ""; } // todo 仮
    if (command_name == Fix.RESURRECTION) { return ""; } // todo 仮
    if (command_name == Fix.DEATH_SCYTHE) { return ""; } // todo 仮
    if (command_name == Fix.GENESIS) { return ""; } // todo 仮
    if (command_name == Fix.TIME_SKIP) { return ""; } // todo 仮
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return ""; } // todo 仮
    if (command_name == Fix.CATASTROPHE) { return ""; } // todo 仮
    if (command_name == Fix.CARNAGE_RUSH) { return ""; } // todo 仮
    if (command_name == Fix.PIERCING_ARROW) { return ""; } // todo 仮
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return ""; } // todo 仮
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return ""; } // todo 仮
    #endregion

    #region "複合魔法"
    // 聖＋闇 [完全逆]
    if (command_name == Fix.PSYCHIC_TRANCE) { return ""; } // todo 仮
    if (command_name == Fix.BLIND_JUSTICE) { return ""; } // todo 仮
    if (command_name == Fix.DEATH_DENY) { return ""; } // todo 仮
    // 聖＋炎
    if (command_name == Fix.FLASH_BLAZE) { return ""; } // todo 仮
    if (command_name == Fix.LIGHT_DETONATOR) { return ""; } // todo 仮
    if (command_name == Fix.ASCENDANT_METEOR) { return ""; } // todo 仮
    // 聖＋氷
    if (command_name == Fix.SKY_SHIELD) { return ""; } // todo 仮
    if (command_name == Fix.SACRED_FIELD) { return ""; } // todo 仮
    if (command_name == Fix.SAINT_JUDGEMENT) { return ""; } // todo 仮
    // 聖＋理
    if (command_name == Fix.HOLY_BREAKER) { return ""; } // todo 仮
    if (command_name == Fix.EXALTED_FIELD) { return ""; } // todo 仮
    if (command_name == Fix.HYMN_CONTRACT) { return ""; } // todo 仮
    // 聖＋空唱
    if (command_name == Fix.VOID_THUNDER) { return ""; } // todo 仮
    if (command_name == Fix.ANGEL_INTERVENTION) { return ""; } // todo 仮
    if (command_name == Fix.ENDLESS_ANTHEM) { return ""; } // todo 仮
    // 闇＋炎
    if (command_name == Fix.BLACK_FIRE) { return ""; } // todo 仮
    if (command_name == Fix.BLAZING_FIELD) { return ""; } // todo 仮
    if (command_name == Fix.DEMONIC_IGNITE) { return ""; } // todo 仮
    // 闇＋氷
    if (command_name == Fix.DEEP_MIRROR) { return ""; } // todo 仮
    if (command_name == Fix.STORM_SHARD) { return ""; } // todo 仮
    if (command_name == Fix.ABYSS_EYE) { return ""; } // todo 仮
    // 闇＋理
    if (command_name == Fix.WORD_OF_MALICE) { return ""; } // todo 仮
    if (command_name == Fix.SIN_FORTUNE) { return ""; } // todo 仮
    if (command_name == Fix.BLOOD_SHACKLE) { return ""; } // todo 仮
    // 闇＋空唱
    if (command_name == Fix.ACHROMA_BLAST) { return ""; } // todo 仮
    if (command_name == Fix.DOOM_BLADE) { return ""; } // todo 仮
    if (command_name == Fix.ECLIPSE_END) { return ""; } // todo 仮
    // 炎＋氷 [完全逆]
    if (command_name == Fix.CHILL_BURN) { return ""; } // todo 仮
    if (command_name == Fix.SWORD_OF_FREEZING_FIRE) { return ""; } // todo 仮
    if (command_name == Fix.ZETA_EXPLOSION) { return ""; } // todo 仮
    // 炎＋理
    if (command_name == Fix.BURST_INFERNO) { return ""; } // todo 仮
    if (command_name == Fix.PIERCING_FLAME) { return ""; } // todo 仮
    if (command_name == Fix.SIGIL_OF_HOMURA) { return ""; } // todo 仮
    // 炎＋空唱
    if (command_name == Fix.ERRATIC_THUNDERBOLT) { return ""; } // todo 仮
    if (command_name == Fix.STEAM_MIRROR) { return ""; } // todo 仮
    if (command_name == Fix.RED_DRAGON_WILL) { return ""; } // todo 仮
    // 氷＋理
    if (command_name == Fix.WORD_OF_ATTITUDE) { return ""; } // todo 仮
    if (command_name == Fix.ICICLE_BARRIER) { return ""; } // todo 仮
    if (command_name == Fix.AUSTERITY_MATRIX) { return ""; } // todo 仮
    // 氷＋空唱
    if (command_name == Fix.GLACIAL_CIRCLE) { return ""; } // todo 仮
    if (command_name == Fix.VORTEX_SONG) { return ""; } // todo 仮
    if (command_name == Fix.BLUE_DRAGON_WILL) { return ""; } // todo 仮
    // 理＋空唱 [完全逆]
    if (command_name == Fix.WORD_OF_NINE) { return ""; } // todo 仮
    if (command_name == Fix.PARADOX_IMAGE) { return ""; } // todo 仮
    if (command_name == Fix.WARP_GATE) { return ""; } // todo 仮
    #endregion

    #region "複合スキル"
    // 戦士＋護衛 [完全逆]
    if (command_name == Fix.NEUTRAL_SMASH) { return ""; } // todo 仮
    if (command_name == Fix.STANCE_OF_DOUBLE) { return ""; } // todo 仮
    // 戦士＋格闘
    if (command_name == Fix.BLITZ_STRIKE) { return ""; } // todo 仮
    if (command_name == Fix.ASSASSINATION_HIT) { return ""; } // todo 仮
    // 戦士＋弓術
    if (command_name == Fix.PHOENIX_EYE) { return ""; } // todo 仮
    if (command_name == Fix.HARDENED_INSIGHT) { return ""; } // todo 仮
    // 戦士＋心眼
    if (command_name == Fix.CHALLENGING_SHOUT) { return ""; } // todo 仮
    if (command_name == Fix.ONSLAUGHT_HIT) { return ""; } // todo 仮
    // 戦士＋無心
    if (command_name == Fix.FORMLESS_STYLE) { return ""; } // todo 仮
    if (command_name == Fix.HARDEST_PARRY) { return ""; } // todo 仮
    // 護衛＋格闘
    if (command_name == Fix.TACTICAL_VISION) { return ""; } // todo 仮
    if (command_name == Fix.SWIFT_RESPONSE) { return ""; } // todo 仮
    // 護衛＋弓術
    if (command_name == Fix.RIGHTEOUSNESS_ARROW) { return ""; } // todo 仮
    if (command_name == Fix.PERFECT_EVASION) { return ""; } // todo 仮
    // 護衛＋心眼
    if (command_name == Fix.REFLEX_ESSENCE) { return ""; } // todo 仮
    if (command_name == Fix.SELF_PERSUASION) { return ""; } // todo 仮
    // 護衛＋無心
    if (command_name == Fix.TRUST_SILENCE) { return ""; } // todo 仮
    if (command_name == Fix.NOURISH_POWER) { return ""; } // todo 仮
    // 格闘＋弓術 [完全逆]
    if (command_name == Fix.SUDDEN_STRIKEARROW) { return ""; } // todo 仮
    if (command_name == Fix.STANCE_OF_MYSTIC) { return ""; } // todo 仮
    // 格闘＋心眼
    if (command_name == Fix.PSYCHIC_WAVE) { return ""; } // todo 仮
    if (command_name == Fix.FLARE_OF_FIGHTING) { return ""; } // todo 仮
    // 格闘＋無心
    if (command_name == Fix.INFINITY_IMAGE) { return ""; } // todo 仮
    if (command_name == Fix.UNIFIED_CONVICTION) { return ""; } // todo 仮
    // 弓術＋心眼
    if (command_name == Fix.ABSOLUTE_ARROW) { return ""; } // todo 仮
    if (command_name == Fix.HEAVENS_WISDOM) { return ""; } // todo 仮
    // 弓術＋無心
    if (command_name == Fix.SILENT_MEDITATION) { return ""; } // todo 仮
    if (command_name == Fix.COLORLESS_FORM) { return ""; } // todo 仮
    // 心眼＋無心 [完全逆]
    if (command_name == Fix.OVERWHELMING_DESTINY) { return ""; } // todo 仮
    if (command_name == Fix.WORLD_CHANT) { return ""; } // todo 仮
    #endregion

    #region "Archetype"
    if (command_name == Fix.ARCHETYPE_EIN_1) { return "自分自身【集中と断絶】のBUFFを付与する。本BUFFが付与された状態で、次にダメージを伴う行動を行った場合、そのダメージ量をX倍したうえで、クリティカルとしてダメージを与える。その時の行動はカウンターされない。その時のダメージは軽減対象とならない。Xは【潜在能力】パラメタに依存する。行動完了後、本BUFFは消滅する。"; }
    if (command_name == Fix.ARCHETYPE_LANA_1) { return "自分自身に【完全なる詠唱】のBUFFを付与する。本BUFFが付与された状態で、次にBUFF付与を伴う魔法属性のコマンドを行った場合、そのBUFF付与がターン経過の制限がある場合、その値をX倍持続可能とする。そのBUFF付与が威力を示す値が含まれている場合、その値をX倍増幅した状態でBUFFが付与される。その時の魔法はカウンターされない。Xは【潜在能力】パラメタに依存する。行動完了後、本BUFFは消滅する。"; }
    if (command_name == Fix.ARCHETYPE_BILLY_1) { return "自分自身に【勝利を我が手に！】のBUFFを累積Ｘの状態で付与する。致死ダメージ（ライフが0になる攻撃ダメージ）を受けた場合、累積Ｘを１つ消費してライフ１で生き残る。この効果はライフ１以下の時は適用されない。魔法を実行する時、マナ消費コストが残りマナより大きい場合、累積Ｘを１つ消費して実行する。この効果は残りマナが１以下の時は適用されない。スキルを実行する時、スキル消費コストが残りスキルより大きい場合、累積Ｘを１つ消費して実行する。この効果は残りスキルが１以下の時は適用されない。Xは【潜在能力】パラメタに依存する。"; }
    if (command_name == Fix.ARCHETYPE_ADEL_1) { return "自分自身に【悠久なる記憶】のBUFFを累積Xの状態で付与する。ターン終了時、累積Xを１つ消費して以下のいずれかのBUFFを付与する。【トゥルー・サイト】【スピリチュアル・レスト】【ブラック・コントラクト】【ゲイル・ウィンド】【エバーフロー・マインド】上記全てが既に付与されている場合、以下のいずれかが発動する。※ターゲットは味方一体の場合は自分自身、敵一体の場合は先頭が対象となる。【オラクル・コマンド】【フォーチュン・スピリット】【ワード・オブ・パワー】【ファントム・朧】【フレイム・ストライク】Xは【潜在能力】パラメタに依存する。"; }
    #endregion

    #region "Other"
    if (command_name == Fix.AIR_CUTTER) { return "敵一体を対象とする。対象に【風】ダメージを与えた後、自分自身に【俊敏】のBUFFを付与する。\r\n【俊敏】が続く間、戦闘反応値が上昇する。"; }
    if (command_name == Fix.ROCK_SLAM) { return "敵一体を対象とする。対象に【土】ダメージを与えた後、【破損】のBUFFを付与する。【破損】が続く間、物理防御が減少する。"; }
    if (command_name == Fix.VENOM_SLASH) { return "敵一体を対象とする。対象に【物理】ダメージを与えた後、【毒】のBUFFを付与する。\r\n【毒】が続く間、ターン経過毎に毒ダメージを与える。"; }
    if (command_name == Fix.AURA_OF_POWER) { return "味方一体を対象とする。対象に【パワー】を付与する。\r\n【パワー】が続く間、物理攻撃が上昇する。"; }
    if (command_name == Fix.HEART_OF_LIFE) { return "味方全員に【生命】のBUFFを付与する。\r\n【生命】が続く間、ターン経過毎にライフを回復する。"; }
    if (command_name == Fix.DARKNESS_CIRCLE) { return "敵フィールドに、【黒炎】のフィールドを形成する。\r\n【黒炎】が続く間、敵の魔法攻撃力が減少する。"; }
    if (command_name == Fix.STORM_ARMOR) { return "味方一体を対象とする。対象に【ストーム】のBUFFを付与する。【ストーム】が続く間、戦闘速度が上昇する。加えて、魔法攻撃を行う度に、【電撃】ダメージが追加発生する。"; }
    if (command_name == Fix.SOLID_WALL) { return "味方フィールドに、【防壁】のフィールドを形成する。味方に与えられる物理属性のダメージは【防壁】のポイントに吸収される。【防壁】のポイントが0以下になった場合、【防壁】フィールドは消滅する。"; }
    if (command_name == Fix.INVISIBLE_BIND) { return "敵一体を対象とする。対象に物理ダメージを与えた後、【麻痺】のBUFFを付与する。【麻痺】が続く間、スキル系のアクションコマンドが使用不可となる。"; }
    if (command_name == Fix.IDEOLOGY_OF_SOPHISTICATION) { return "味方フィールドに【洗練】のフィールドを形成する。【洗練】が続く間、味方からのコマンド実行時、ダメージもしくはライフ回復を伴う場合、その威力を10%増強する。"; }
    if (command_name == Fix.SKY_SHIELD) { return "味方一体を対象とする。対象に【魔法障壁】のBUFFを付与する。【魔法障壁】が続く間、魔法防御が上昇する。"; }
    if (command_name == Fix.STANCE_OF_THE_SHADE) { return "自分自身に【幻闇】のBUFFを付与する。この効果が続く間、敵からダメージ発生を伴う攻撃を食らった場合、あたかも食らわなかったかの様に振る舞った後、このBUFFは除去される。"; }
    if (command_name == Fix.SONIC_PULSE) { return Fix.SONIC_PULSE_JP; }
    if (command_name == Fix.LAND_SHATTER) { return Fix.LAND_SHATTER_JP; }
    if (command_name == Fix.MUTE_IMPULSE) { return Fix.MUTE_IMPULSE_JP; }
    if (command_name == Fix.AETHER_DRIVE) { return Fix.AETHER_DRIVE_JP; }
    if (command_name == Fix.KILLING_WAVE) { return Fix.KILLING_WAVE_JP; }
    if (command_name == Fix.IRREGULAR_STEP) { return Fix.IRREGULAR_STEP_JP; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return Fix.ZERO_IMMUNITY_JP; }

    if (command_name == Fix.DARK_AURA) { return "味方一体を対象とする。対象に【黒炎】のBUFFを付与する。\r\nターン経過毎にこのBUFFは累積カウント＋１される。累積カウントが３を超えた場合、消失する。\r\n【黒炎】が続く間、対象の魔法攻撃が上昇する。上昇は累積カウントの分だけ上昇する。"; }
    #endregion

    if (command_name == Fix.ERRATIC_THUNDER) { return ""; }
    if (command_name == Fix.PETRIFICATION) { return ""; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return ""; }
    if (command_name == Fix.SIGIL_OF_THE_HOMURA) { return ""; }
    if (command_name == Fix.REVOLUTION_AURA) { return ""; }
    if (command_name == Fix.OATH_OF_AEGIS) { return ""; }
    if (command_name == Fix.ABYSS_EYE) { return ""; }
    if (command_name == Fix.MIND_FORCE) { return ""; }

    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return ""; }
    if (command_name == Fix.WATER_PRESENCE) { return ""; }
    if (command_name == Fix.VALKYRIE_BLADE) { return ""; }
    if (command_name == Fix.THE_DARK_INTENSITY) { return ""; }
    if (command_name == Fix.CYCLONE_FIELD) { return ""; }
    if (command_name == Fix.LIFE_GRACE) { return ""; }
    if (command_name == Fix.STANCE_OF_THE_IAI) { return ""; }
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return ""; }
    if (command_name == Fix.STANCE_OF_MUIN) { return ""; }
    if (command_name == Fix.DIRTY_WISDOM) { return ""; }
    if (command_name == Fix.WORD_OF_PROPHECY) { return ""; }
    if (command_name == Fix.WILD_SWING) { return ""; }
    if (command_name == Fix.BRILLIANT_FORM) { return ""; }
    if (command_name == Fix.FUTURE_VISION) { return ""; }
    if (command_name == Fix.SOUL_SHOUT) { return ""; }
    if (command_name == Fix.AVENGER_PROMISE) { return ""; }
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return ""; }
    if (command_name == Fix.ZERO_IMMUNITY) { return ""; }

    if (command_name == Fix.LAVA_ANNIHILATION) { return ""; }
    if (command_name == Fix.ABSOLUTE_ZERO) { return ""; }
    if (command_name == Fix.RESURRECTION) { return ""; }
    if (command_name == Fix.DEATH_SCYTHE) { return ""; }
    if (command_name == Fix.LIGHTNING_SQUALL) { return ""; }
    if (command_name == Fix.EARTH_QUAKE) { return ""; }
    if (command_name == Fix.KINETIC_SMASH) { return ""; }
    if (command_name == Fix.PIERCING_ARROW) { return ""; }
    if (command_name == Fix.CARNAGE_RUSH) { return ""; }
    if (command_name == Fix.AMBIDEXTERITY) { return ""; }
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return ""; }
    if (command_name == Fix.ONE_IMMUNITY) { return ""; }
    if (command_name == Fix.AUSTERITY_MATRIX) { return ""; }
    if (command_name == Fix.ESSENCE_OVERFLOW) { return ""; }
    if (command_name == Fix.OVERWHELMING_DESTINY) { return ""; }
    if (command_name == Fix.DEMON_CONTRACT) { return ""; }
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return ""; }
    if (command_name == Fix.TIME_SKIP) { return ""; }

    return String.Empty;
  }

  public static string GetDescEffect(string command_name, int factor1, int factor2, int factor3)
  {
    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return "【炎】ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.ICE_NEEDLE) { return "【氷】ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.FRESH_HEAL) { return "ライフの回復量 ＋" + factor1; }
    if (command_name == Fix.SHADOW_BLAST) { return "【陰影】による魔法防御ＤＯＷＮ影響 ＋" + factor1; }
    if (command_name == Fix.ORACLE_COMMAND) { return "インスタントゲージの進行率 ＋" + factor1; }
    if (command_name == Fix.ENERGY_BOLT) { return "ＭＰ消費 －" + factor1 ; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return "物理ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.SHIELD_BASH) { return "【スタン】の継続ターン数 ＋" + factor1; }
    if (command_name == Fix.LEG_STRIKE) { return "【躍動】による戦闘速度ＵＰ影響 ＋" + factor1; }
    if (command_name == Fix.HUNTER_SHOT) { return "【標的】によるクリティカル発生率 ＋" + factor1; }
    if (command_name == Fix.TRUE_SIGHT) { return "【深層】による潜在能力ＵＰ影響 ＋" + factor1; }
    if (command_name == Fix.DISPEL_MAGIC) { return "ＳＰ消費 －" + factor1; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return "【炎剣】による追加【炎】ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.PURE_PURIFICATION) { return "ライフの回復量 ＋" + factor1 + "　一度に除去する数 ＋" + factor2; }
    if (command_name == Fix.DIVINE_CIRCLE) { return "【加護】による軽減量 ＋" + factor1; }
    if (command_name == Fix.BLOOD_SIGN) { return "【失血】によるダメージ量 ＋" + factor1; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return "【幸運】の継続ターン数 ＋" + factor1; }
    if (command_name == Fix.FLASH_COUNTER) { return "ＭＰ消費 －" + factor1; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return "物理ダメ―ジの威力 ＋" + factor1 + "　【剣の構え】による物理攻撃ＵＰ影響 ＋" + factor2; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return "【盾の構え】による物理防御ＵＰ影響 ＋" + factor1; }
    if (command_name == Fix.SPEED_STEP) { return "【俊足の構え】による戦闘反応ＵＰ影響 ＋" + factor1; }
    if (command_name == Fix.MULTIPLE_SHOT) { return "物理ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return "【直光】によるＳＰの回復量 ＋" + factor1; }
    if (command_name == Fix.SPIRITUAL_REST) { return "ＳＰ消費 －" + factor1; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return "メテオバレットの攻撃回数 ＋" + factor1; }
    if (command_name == Fix.BLUE_BULLET) { return "ブルーバレットの攻撃回数 ＋" + factor1; }
    if (command_name == Fix.HOLY_BREATH) { return "ライフの回復量 ＋" + factor1; }
    if (command_name == Fix.BLACK_CONTRACT) { return "【黒契約】の継続ターン数 ＋" + factor1; }
    if (command_name == Fix.WORD_OF_POWER) { return "物理ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return "【留保】の継続ターン数 ＋" + factor1; }
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return "物理ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return "【破損】による物理防御ＤＯＷＮ影響 ＋" + factor1; }
    if (command_name == Fix.BONE_CRUSH) { return "【損傷】による物理攻撃ＤＯＷＮ影響 ＋" + factor1; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return "【一心】による対象の物理防御を無視する威力 ＋" + factor1; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return "【活力】による最大ライフの上昇量 ＋" + factor1; }
    if (command_name == Fix.UNSEEN_AID) { return "ＳＰ消費 －" + factor1; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return "【業炎】による【炎】ダメージの上昇量 ＋" + factor1; }
    if (command_name == Fix.FREEZING_CUBE) { return "【結晶】による【氷】ダメージの上昇量 ＋" + factor1; }
    if (command_name == Fix.ANGELIC_ECHO) { return "【賛美】によるライフの回復量 ＋" + factor1; }
    if (command_name == Fix.CURSED_EVANGILE) { return "カーズド・エヴァンジールによる【闇】ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.GALE_WIND) { return "【分身】の継続ターン数 ＋" + factor1; }
    if (command_name == Fix.PHANTOM_OBORO) { return "ＭＰ消費 －" + factor1; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return "対象へのダメージの威力 ＋" + factor1 + "　周囲全体へのダメージの威力 ＋" + factor2; }
    if (command_name == Fix.DOMINATION_FIELD) { return "【鉄壁】による物理／魔法防御 ＋" + factor1 + "　防御姿勢によるダメージ軽減 ＋" + factor2; }
    if (command_name == Fix.DEADLY_DRIVE) { return "【決死】による物理攻撃ＵＰ影響 (30%以下)＋" + factor1 + "　(20%以下)＋" + factor2 + "　(10%以下)＋" + factor3; }
    if (command_name == Fix.PENETRATION_ARROW) { return "【傷跡】による物理防御ＤＯＷＮ影響 ＋" + factor1; }
    if (command_name == Fix.WILL_AWAKENING) { return "【覚醒】の継続ターン数 ＋" + factor1; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return "ＳＰ消費 －" + factor1; }
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return "【炎】ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.FROST_LANCE) { return "【氷】ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.SHINING_HEAL) { return "【祝福】の継続ターン数 ＋" + factor1; }
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return "【荒廃】による物理防御／魔法防御／戦闘反応ＤＯＷＮ影響 ＋" + factor1; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return "ＭＰ消費 －" + factor1; }
    if (command_name == Fix.COUNTER_DISALLOW) { return "【喪失】の継続ターン数 ＋" + factor1; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return "【臨戦】による物理攻撃／魔法攻撃 ＋" + factor1; }
    if (command_name == Fix.HARDEST_PARRY) { return "ＳＰ消費 －" + factor1; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return "自分の行動ゲージ進行率 ＋" + factor1 + "　敵の行動ゲージ後退率 ＋" + factor2; }
    if (command_name == Fix.PRECISION_STRIKE) { return "物理ダメージの威力 ＋" + factor1; }
    if (command_name == Fix.EVERFLOW_MIND) { return "【常在】によるインスタントゲージ消費率 －" + factor1; }
    if (command_name == Fix.INNER_INSPIRATION) { return "ＳＰの回復量 ＋" + factor1; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return ""; } // todo 仮
    if (command_name == Fix.WATER_PRESENCE) { return ""; } // todo 仮
    if (command_name == Fix.VALKYRIE_BLADE) { return ""; } // todo 仮
    if (command_name == Fix.THE_DARK_INTENSITY) { return ""; } // todo 仮
    if (command_name == Fix.FUTURE_VISION) { return ""; } // todo 仮
    if (command_name == Fix.DETACHMENT_FAULT) { return ""; } // todo 仮
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return ""; } // todo 仮
    if (command_name == Fix.ONE_IMMUNITY) { return ""; } // todo 仮
    if (command_name == Fix.STANCE_OF_MUIN) { return ""; } // todo 仮
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return ""; } // todo 仮
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return ""; } // todo 仮
    if (command_name == Fix.ZERO_IMMUNITY) { return ""; } // todo 仮
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return ""; } // todo 仮
    if (command_name == Fix.ABSOLUTE_ZERO) { return ""; } // todo 仮
    if (command_name == Fix.RESURRECTION) { return ""; } // todo 仮
    if (command_name == Fix.DEATH_SCYTHE) { return ""; } // todo 仮
    if (command_name == Fix.GENESIS) { return ""; } // todo 仮
    if (command_name == Fix.TIME_SKIP) { return ""; } // todo 仮
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return ""; } // todo 仮
    if (command_name == Fix.CATASTROPHE) { return ""; } // todo 仮
    if (command_name == Fix.CARNAGE_RUSH) { return ""; } // todo 仮
    if (command_name == Fix.PIERCING_ARROW) { return ""; } // todo 仮
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return ""; } // todo 仮
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return ""; } // todo 仮
    #endregion

    #region "複合魔法"
    // 聖＋闇 [完全逆]
    if (command_name == Fix.PSYCHIC_TRANCE) { return ""; } // todo 仮
    if (command_name == Fix.BLIND_JUSTICE) { return ""; } // todo 仮
    if (command_name == Fix.DEATH_DENY) { return ""; } // todo 仮
    // 聖＋炎
    if (command_name == Fix.FLASH_BLAZE) { return ""; } // todo 仮
    if (command_name == Fix.LIGHT_DETONATOR) { return ""; } // todo 仮
    if (command_name == Fix.ASCENDANT_METEOR) { return ""; } // todo 仮
    // 聖＋氷
    if (command_name == Fix.SKY_SHIELD) { return ""; } // todo 仮
    if (command_name == Fix.SACRED_FIELD) { return ""; } // todo 仮
    if (command_name == Fix.SAINT_JUDGEMENT) { return ""; } // todo 仮
    // 聖＋理
    if (command_name == Fix.HOLY_BREAKER) { return ""; } // todo 仮
    if (command_name == Fix.EXALTED_FIELD) { return ""; } // todo 仮
    if (command_name == Fix.HYMN_CONTRACT) { return ""; } // todo 仮
    // 聖＋空唱
    if (command_name == Fix.VOID_THUNDER) { return ""; } // todo 仮
    if (command_name == Fix.ANGEL_INTERVENTION) { return ""; } // todo 仮
    if (command_name == Fix.ENDLESS_ANTHEM) { return ""; } // todo 仮
    // 闇＋炎
    if (command_name == Fix.BLACK_FIRE) { return ""; } // todo 仮
    if (command_name == Fix.BLAZING_FIELD) { return ""; } // todo 仮
    if (command_name == Fix.DEMONIC_IGNITE) { return ""; } // todo 仮
    // 闇＋氷
    if (command_name == Fix.DEEP_MIRROR) { return ""; } // todo 仮
    if (command_name == Fix.STORM_SHARD) { return ""; } // todo 仮
    if (command_name == Fix.ABYSS_EYE) { return ""; } // todo 仮
    // 闇＋理
    if (command_name == Fix.WORD_OF_MALICE) { return ""; } // todo 仮
    if (command_name == Fix.SIN_FORTUNE) { return ""; } // todo 仮
    if (command_name == Fix.BLOOD_SHACKLE) { return ""; } // todo 仮
    // 闇＋空唱
    if (command_name == Fix.ACHROMA_BLAST) { return ""; } // todo 仮
    if (command_name == Fix.DOOM_BLADE) { return ""; } // todo 仮
    if (command_name == Fix.ECLIPSE_END) { return ""; } // todo 仮
    // 炎＋氷 [完全逆]
    if (command_name == Fix.CHILL_BURN) { return ""; } // todo 仮
    if (command_name == Fix.SWORD_OF_FREEZING_FIRE) { return ""; } // todo 仮
    if (command_name == Fix.ZETA_EXPLOSION) { return ""; } // todo 仮
    // 炎＋理
    if (command_name == Fix.BURST_INFERNO) { return ""; } // todo 仮
    if (command_name == Fix.PIERCING_FLAME) { return ""; } // todo 仮
    if (command_name == Fix.SIGIL_OF_HOMURA) { return ""; } // todo 仮
    // 炎＋空唱
    if (command_name == Fix.ERRATIC_THUNDERBOLT) { return ""; } // todo 仮
    if (command_name == Fix.STEAM_MIRROR) { return ""; } // todo 仮
    if (command_name == Fix.RED_DRAGON_WILL) { return ""; } // todo 仮
    // 氷＋理
    if (command_name == Fix.WORD_OF_ATTITUDE) { return ""; } // todo 仮
    if (command_name == Fix.ICICLE_BARRIER) { return ""; } // todo 仮
    if (command_name == Fix.AUSTERITY_MATRIX) { return ""; } // todo 仮
    // 氷＋空唱
    if (command_name == Fix.GLACIAL_CIRCLE) { return ""; } // todo 仮
    if (command_name == Fix.VORTEX_SONG) { return ""; } // todo 仮
    if (command_name == Fix.BLUE_DRAGON_WILL) { return ""; } // todo 仮
    // 理＋空唱 [完全逆]
    if (command_name == Fix.WORD_OF_NINE) { return ""; } // todo 仮
    if (command_name == Fix.PARADOX_IMAGE) { return ""; } // todo 仮
    if (command_name == Fix.WARP_GATE) { return ""; } // todo 仮
    #endregion

    #region "複合スキル"
    // 戦士＋護衛 [完全逆]
    if (command_name == Fix.NEUTRAL_SMASH) { return ""; } // todo 仮
    if (command_name == Fix.STANCE_OF_DOUBLE) { return ""; } // todo 仮
    // 戦士＋格闘
    if (command_name == Fix.BLITZ_STRIKE) { return ""; } // todo 仮
    if (command_name == Fix.ASSASSINATION_HIT) { return ""; } // todo 仮
    // 戦士＋弓術
    if (command_name == Fix.PHOENIX_EYE) { return ""; } // todo 仮
    if (command_name == Fix.HARDENED_INSIGHT) { return ""; } // todo 仮
    // 戦士＋心眼
    if (command_name == Fix.CHALLENGING_SHOUT) { return ""; } // todo 仮
    if (command_name == Fix.ONSLAUGHT_HIT) { return ""; } // todo 仮
    // 戦士＋無心
    if (command_name == Fix.FORMLESS_STYLE) { return ""; } // todo 仮
    if (command_name == Fix.HARDEST_PARRY) { return ""; } // todo 仮
    // 護衛＋格闘
    if (command_name == Fix.TACTICAL_VISION) { return ""; } // todo 仮
    if (command_name == Fix.SWIFT_RESPONSE) { return ""; } // todo 仮
    // 護衛＋弓術
    if (command_name == Fix.RIGHTEOUSNESS_ARROW) { return ""; } // todo 仮
    if (command_name == Fix.PERFECT_EVASION) { return ""; } // todo 仮
    // 護衛＋心眼
    if (command_name == Fix.REFLEX_ESSENCE) { return ""; } // todo 仮
    if (command_name == Fix.SELF_PERSUASION) { return ""; } // todo 仮
    // 護衛＋無心
    if (command_name == Fix.TRUST_SILENCE) { return ""; } // todo 仮
    if (command_name == Fix.NOURISH_POWER) { return ""; } // todo 仮
    // 格闘＋弓術 [完全逆]
    if (command_name == Fix.SUDDEN_STRIKEARROW) { return ""; } // todo 仮
    if (command_name == Fix.STANCE_OF_MYSTIC) { return ""; } // todo 仮
    // 格闘＋心眼
    if (command_name == Fix.PSYCHIC_WAVE) { return ""; } // todo 仮
    if (command_name == Fix.FLARE_OF_FIGHTING) { return ""; } // todo 仮
    // 格闘＋無心
    if (command_name == Fix.INFINITY_IMAGE) { return ""; } // todo 仮
    if (command_name == Fix.UNIFIED_CONVICTION) { return ""; } // todo 仮
    // 弓術＋心眼
    if (command_name == Fix.ABSOLUTE_ARROW) { return ""; } // todo 仮
    if (command_name == Fix.HEAVENS_WISDOM) { return ""; } // todo 仮
    // 弓術＋無心
    if (command_name == Fix.SILENT_MEDITATION) { return ""; } // todo 仮
    if (command_name == Fix.COLORLESS_FORM) { return ""; } // todo 仮
    // 心眼＋無心 [完全逆]
    if (command_name == Fix.OVERWHELMING_DESTINY) { return ""; } // todo 仮
    if (command_name == Fix.WORLD_CHANT) { return ""; } // todo 仮
    #endregion

    return String.Empty;
  }
}
