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
  }

  public enum BuffType
  {
    None,
    Positive,
    Negative,
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
    AllMember,
    InstantTarget
  }

  public enum TimingType
  {
    None,
    Normal,
    Instant,
    Sorcery
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
      result.Add(Fix.CURSED_EVANGEL);
      result.Add(Fix.CIRCLE_OF_THE_DESPAIR);
      result.Add(Fix.THE_DARK_INTENSITY);
      result.Add(Fix.DEATH_SCYTHE);
    }
    else if (attr == Fix.CommandAttribute.Wind)
    {
      result.Add(Fix.AIR_CUTTER);
      result.Add(Fix.STORM_ARMOR);
      result.Add(Fix.SONIC_PULSE);
      result.Add(Fix.GALE_WIND);
      result.Add(Fix.ERRATIC_THUNDER);
      result.Add(Fix.CYCLONE_FIELD);
      result.Add(Fix.LIGHTNING_SQUALL);
    }
    else if (attr == Fix.CommandAttribute.Earth)
    {
      result.Add(Fix.ROCK_SLAM);
      result.Add(Fix.SOLID_WALL);
      result.Add(Fix.EARTH_SURGE);
      result.Add(Fix.SAND_BURST);
      result.Add(Fix.PETRIFICATION);
      result.Add(Fix.LIFE_GRACE);
      result.Add(Fix.EARTH_QUAKE);
    }
    else if (attr == Fix.CommandAttribute.Warrior)
    {
      result.Add(Fix.STRAIGHT_SMASH);
      result.Add(Fix.STANCE_OF_THE_BLADE);
      result.Add(Fix.DOUBLE_SLASH);
      result.Add(Fix.IRON_BASTER);
      result.Add(Fix.RAGING_STORM);
      result.Add(Fix.STANCE_OF_THE_IAI);
      result.Add(Fix.KINETIC_SMASH);
    }
    else if (attr == Fix.CommandAttribute.Archer)
    {
      result.Add(Fix.HUNTER_SHOT);
      result.Add(Fix.MULTIPLE_SHOT);
      result.Add(Fix.EYE_OF_THE_TRUTH);
      result.Add(Fix.PENETRATION_ARROW);
      result.Add(Fix.PRECISION_RANGE);
      result.Add(Fix.ETERNAL_CONCENTRATION);
      result.Add(Fix.PIERCING_ARROW);
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
    else if (attr == Fix.CommandAttribute.Rogue)
    {
      result.Add(Fix.VENOM_SLASH);
      result.Add(Fix.INVISIBLE_BIND);
      result.Add(Fix.IRREGULAR_STEP);
      result.Add(Fix.ASSASSINATION_HIT);
      result.Add(Fix.COUNTER_DISALLOW);
      result.Add(Fix.DIRTY_WISDOM);
      result.Add(Fix.AMBIDEXTERITY);
    }
    else if (attr == Fix.CommandAttribute.WonderHermit)
    {
      result.Add(Fix.ENERGY_BOLT);
      result.Add(Fix.IDEOLOGY_OF_SOPHISTICATION);
      result.Add(Fix.SIGIL_OF_THE_PENDING);
      result.Add(Fix.PHANTOM_OBORO);
      result.Add(Fix.SIGIL_OF_THE_HOMURA);
      result.Add(Fix.WORD_OF_PROPHECY);
      result.Add(Fix.TRANSCENDENCE_REACHED);
    }
    else if (attr == Fix.CommandAttribute.Armorer)
    {
      result.Add(Fix.SHIELD_BASH);
      result.Add(Fix.STANCE_OF_THE_GUARD);
      result.Add(Fix.CONCUSSIVE_HIT);
      result.Add(Fix.DOMINATION_FIELD);
      result.Add(Fix.HARDEST_PARRY);
      result.Add(Fix.WILD_SWING);
      result.Add(Fix.ONE_IMMUNITY);
    }
    else if (attr == Fix.CommandAttribute.EnhanceForm)
    {
      result.Add(Fix.AURA_OF_POWER);
      result.Add(Fix.SKY_SHIELD);
      result.Add(Fix.AETHER_DRIVE);
      result.Add(Fix.CIRCLE_OF_THE_VIGOR);
      result.Add(Fix.REVOLUTION_AURA);
      result.Add(Fix.BRILLIANT_FORM);
      result.Add(Fix.AUSTERITY_MATRIX);
    }
    else if (attr == Fix.CommandAttribute.MysticForm)
    {
      result.Add(Fix.DISPEL_MAGIC);
      result.Add(Fix.FLASH_COUNTER);
      result.Add(Fix.MUTE_IMPULSE);
      result.Add(Fix.DETACHMENT_FAULT);
      result.Add(Fix.OATH_OF_AEGIS);
      result.Add(Fix.FUTURE_VISION);
      result.Add(Fix.ESSENCE_OVERFLOW);
    }
    else if (attr == Fix.CommandAttribute.Truth)
    {
      result.Add(Fix.TRUE_SIGHT);
      result.Add(Fix.LAYLINE_SCHEMA);
      result.Add(Fix.WORD_OF_POWER);
      result.Add(Fix.WILL_AWAKENING);
      result.Add(Fix.EAGLE_EYE);
      result.Add(Fix.SIGIL_OF_THE_FAITH);
      result.Add(Fix.STANCE_OF_THE_KOKOROE);
    }
    else if (attr == Fix.CommandAttribute.Brave)
    {
      result.Add(Fix.HEART_OF_LIFE);
      result.Add(Fix.FORTUNE_SPIRIT);
      result.Add(Fix.VOICE_OF_VIGOR);
      result.Add(Fix.AURA_BURN);
      result.Add(Fix.EVERFLOW_MIND);
      result.Add(Fix.SOUL_SHOUT);
      result.Add(Fix.OVERWHELMING_DESTINY);
    }
    else if (attr == Fix.CommandAttribute.Vengeance)
    {
      result.Add(Fix.DARK_AURA);
      result.Add(Fix.STANCE_OF_THE_SHADE);
      result.Add(Fix.KILLING_WAVE);
      result.Add(Fix.LEVEL_EATER);
      result.Add(Fix.ABYSS_EYE);
      result.Add(Fix.AVENGER_PROMISE);
      result.Add(Fix.DEMON_CONTRACT);
    }
    else if (attr == Fix.CommandAttribute.Mindfulness)
    {
      result.Add(Fix.ORACLE_COMMAND);
      result.Add(Fix.SPIRITUAL_REST);
      result.Add(Fix.UNSEEN_AID);
      result.Add(Fix.EXACT_TIME);
      result.Add(Fix.INNER_INSPIRATION);
      result.Add(Fix.ZERO_IMMUNITY);
      result.Add(Fix.TIME_SKIP);
    }
    return result;
  }
  public static List<int> GetCommandPlus(Character player, Fix.CommandAttribute attr)
  {
    List<int> result = new List<int>();
    if (attr == Fix.CommandAttribute.Fire)
    {
      result.Add(player.FireBall);
      result.Add(player.FlameBlade);
      result.Add(player.MeteorBullet);
      result.Add(player.VolcanicBlaze);
      result.Add(player.FlameStrike);
      result.Add(player.CircleOfTheIgnite);
      result.Add(player.LavaAnnihilation);
    }
    else if (attr == Fix.CommandAttribute.Ice)
    {
      result.Add(player.IceNeedle);
      result.Add(player.PurePurification);
      result.Add(player.BlueBullet);
      result.Add(player.FreezingCube);
      result.Add(player.FrostLance);
      result.Add(player.WaterPresence);
      result.Add(player.AbsoluteZero);
    }
    else if (attr == Fix.CommandAttribute.HolyLight)
    {
      result.Add(player.FreshHeal);
      result.Add(player.DivineCircle);
      result.Add(player.HolyBreath);
      result.Add(player.AngelicEcho);
      result.Add(player.ShiningHeal);
      result.Add(player.ValkyrieBlade);
      result.Add(player.Resurrection);
    }
    else if (attr == Fix.CommandAttribute.DarkMagic)
    {
      result.Add(player.ShadowBlast);
      result.Add(player.BloodSign);
      result.Add(player.BlackContract);
      result.Add(player.CursedEvangel);
      result.Add(player.CircleOfTheDespair);
      result.Add(player.TheDarkIntensity);
      result.Add(player.DeathScythe);
    }
    else if (attr == Fix.CommandAttribute.Wind)
    {
      result.Add(player.AirCutter);
      result.Add(player.StormArmor);
      result.Add(player.SonicPulse);
      result.Add(player.GaleWind);
      result.Add(player.ErraticThunder);
      result.Add(player.CycloneField);
      result.Add(player.LightningSquall);
    }
    else if (attr == Fix.CommandAttribute.Earth)
    {
      result.Add(player.RockSlam);
      result.Add(player.SoldWall);
      result.Add(player.EarthSurge);
      result.Add(player.SandBurst);
      result.Add(player.Petrification);
      result.Add(player.LifeGrace);
      result.Add(player.EarthQuake);
    }
    else if (attr == Fix.CommandAttribute.Warrior)
    {
      result.Add(player.StraightSmash);
      result.Add(player.StanceOfTheBlade);
      result.Add(player.DoubleSlash);
      result.Add(player.IronBaster);
      result.Add(player.RagingStorm);
      result.Add(player.StanceOfTheIai);
      result.Add(player.KineticSmash);
    }
    else if (attr == Fix.CommandAttribute.Archer)
    {
      result.Add(player.HunterShot);
      result.Add(player.MultipleShot);
      result.Add(player.EyeOfTheIsshin);
      result.Add(player.PenetrationArrow);
      result.Add(player.PrecisionRange);
      result.Add(player.EternalConcentration);
      result.Add(player.PiercingArrow);
    }
    else if (attr == Fix.CommandAttribute.MartialArts)
    {
      result.Add(player.LegStrike);
      result.Add(player.SpeedStep);
      result.Add(player.BoneCrush);
      result.Add(player.DeadlyDrive);
      result.Add(player.UnintentionalHit);
      result.Add(player.StanceOfMuin);
      result.Add(player.CarnageRush);
    }
    else if (attr == Fix.CommandAttribute.Rogue)
    {
      result.Add(player.VenomSlash);
      result.Add(player.InvisibleBind);
      result.Add(player.IrregularStep);
      result.Add(player.AssassinationHit);
      result.Add(player.CounterDisallow);
      result.Add(player.DirtyWisdom);
      result.Add(player.Ambidexterity);
    }
    else if (attr == Fix.CommandAttribute.WonderHermit)
    {
      result.Add(player.EnergyBolt);
      result.Add(player.IdeologyOfSophistication);
      result.Add(player.SigilOfThePending);
      result.Add(player.PhantomOboro);
      result.Add(player.SigilOfTheHomura);
      result.Add(player.WordOfProphecy);
      result.Add(player.TranscendenceReached);
    }
    else if (attr == Fix.CommandAttribute.Armorer)
    {
      result.Add(player.ShieldBash);
      result.Add(player.StanceOfTheGuard);
      result.Add(player.ConcussiveHit);
      result.Add(player.DominationField);
      result.Add(player.HardestParry);
      result.Add(player.WildSwing);
      result.Add(player.OneImmunity);
    }
    else if (attr == Fix.CommandAttribute.EnhanceForm)
    {
      result.Add(player.AuraOfPower);
      result.Add(player.SkyShield);
      result.Add(player.AetherDrive);
      result.Add(player.CircleOfTheVigor);
      result.Add(player.RevolutionAura);
      result.Add(player.BrilliantForm);
      result.Add(player.AusterityMatrix);
    }
    else if (attr == Fix.CommandAttribute.MysticForm)
    {
      result.Add(player.DispelMagic);
      result.Add(player.FlashCounter);
      result.Add(player.MuteImpulse);
      result.Add(player.DetachmentFault);
      result.Add(player.OathOfAegis);
      result.Add(player.FutureVision);
      result.Add(player.EssenceOverflow);
    }
    else if (attr == Fix.CommandAttribute.Brave)
    {
      result.Add(player.HeartOfLife);
      result.Add(player.FortuneSpirit);
      result.Add(player.VoiceOfVigor);
      result.Add(player.AuraBurn);
      result.Add(player.EverflowMind);
      result.Add(player.SoulShout);
      result.Add(player.OverwhelmingDestiny);
    }
    else if (attr == Fix.CommandAttribute.Vengeance)
    {
      result.Add(player.DarkAura);
      result.Add(player.StanceOfTheShade);
      result.Add(player.KillingWave);
      result.Add(player.LevelEater);
      result.Add(player.AbyssEye);
      result.Add(player.AvengerPromise);
      result.Add(player.DemonContract);
    }
    else if (attr == Fix.CommandAttribute.Truth)
    {
      result.Add(player.TrueSight);
      result.Add(player.LaylineSchema);
      result.Add(player.WordOfPower);
      result.Add(player.WillAwakening);
      result.Add(player.EagleEye);
      result.Add(player.SigilOfTheFaith);
      result.Add(player.StanceOfTheKokoroe);
    }
    else if (attr == Fix.CommandAttribute.Mindfulness)
    {
      result.Add(player.OracleCommand);
      result.Add(player.SpiritualRest);
      result.Add(player.UnseenAid);
      result.Add(player.ExactTime);
      result.Add(player.InnerInspiration);
      result.Add(player.ZeroImmunity);
      result.Add(player.TimeSkip);
    }
    return result;
  }
  public static Color GetCommandColor(Fix.CommandAttribute attr)
  {
    if (attr == Fix.CommandAttribute.Fire)
    {
      return new Color(1.0f, 0, 0);
    }
    else if (attr == Fix.CommandAttribute.Ice)
    {
      return new Color(0, 0, 1.0f);
    }
    else if (attr == Fix.CommandAttribute.HolyLight)
    {
      return new Color(1.0f, 1.0f, 0);
    }
    else if (attr == Fix.CommandAttribute.DarkMagic)
    {
      return new Color(0, 0, 0);
    }
    else if (attr == Fix.CommandAttribute.Wind)
    {
      return new Color(0, 1.0f, 0);
    }
    else if (attr == Fix.CommandAttribute.Earth)
    {
      return new Color(200.0f / 255.0f, 150.0f / 255.0f, 40.0f / 255.0f);
    }
    else if (attr == Fix.CommandAttribute.Warrior)
    {
      return new Color(0.9f, 0.1f, 0.1f);
    }
    else if (attr == Fix.CommandAttribute.Archer)
    {
      return new Color(114.0f / 255.0f, 0, 217.0f / 255.0f);
    }
    else if (attr == Fix.CommandAttribute.MartialArts)
    {
      return new Color(0.9f, 0.9f, 0.1f);
    }
    else if (attr == Fix.CommandAttribute.Rogue)
    {
      return new Color(45.0f / 255.0f, 58.0f / 255.0f, 24.0f / 255.0f);
    }
    else if (attr == Fix.CommandAttribute.WonderHermit)
    {
      return new Color(0.1f, 0.9f, 0.1f);
    }
    else if (attr == Fix.CommandAttribute.Armorer)
    {
      return new Color(1.0f, 194.0f / 255.0f, 0);
    }
    else if (attr == Fix.CommandAttribute.EnhanceForm)
    {
      return new Color(167.0f / 255.0f, 1.0f, 245.0f / 255.0f);
    }
    else if (attr == Fix.CommandAttribute.MysticForm)
    {
      return new Color(207.0f / 255.0f, 207.0f / 255.0f, 207.0f / 255.0f);
    }
    else if (attr == Fix.CommandAttribute.Brave)
    {
      return new Color(123.0f / 255.0f, 0, 54.0f / 255.0f);
    }
    else if (attr == Fix.CommandAttribute.Vengeance)
    {
      return new Color(0, 0, 0);
    }
    else if (attr == Fix.CommandAttribute.Truth)
    {
      return new Color(0.15f, 0.8f, 0.15f);
    }
    else if (attr == Fix.CommandAttribute.Mindfulness)
    {
      return new Color(239.0f / 255.0f, 201.0f / 255.0f, 1.0f);
    }
    return new Color(1.0f, 1.0f, 1.0f);
  }

  public static Attribute GetAttribute(string command_name)
  {
    if (command_name == Fix.NORMAL_ATTACK) { return Attribute.Skill; } // 物理としての基本攻撃である。
    if (command_name == Fix.MAGIC_ATTACK) { return Attribute.Magic; } // 魔法としての基本攻撃である。
    if (command_name == Fix.DEFENSE) { return Attribute.Basic; }
    if (command_name == Fix.STAY) { return Attribute.Basic; }
    if (command_name == Fix.USE_RED_POTION) { return Attribute.Basic; }

    if (command_name == Fix.FIRE_BALL) { return Attribute.Magic; }
    if (command_name == Fix.ICE_NEEDLE) { return Attribute.Magic; }
    if (command_name == Fix.FRESH_HEAL) { return Attribute.Magic; }
    if (command_name == Fix.SHADOW_BLAST) { return Attribute.Magic; }
    if (command_name == Fix.AIR_CUTTER) { return Attribute.Magic; }
    if (command_name == Fix.ROCK_SLAM) { return Attribute.Magic; }
    if (command_name == Fix.STRAIGHT_SMASH) { return Attribute.Skill; }
    if (command_name == Fix.HUNTER_SHOT) { return Attribute.Skill; }
    if (command_name == Fix.LEG_STRIKE) { return Attribute.Skill; }
    if (command_name == Fix.VENOM_SLASH) { return Attribute.Skill; }
    if (command_name == Fix.ENERGY_BOLT) { return Attribute.Magic; }
    if (command_name == Fix.SHIELD_BASH) { return Attribute.Skill; }
    if (command_name == Fix.AURA_OF_POWER) { return Attribute.Magic; }
    if (command_name == Fix.DISPEL_MAGIC) { return Attribute.Magic; }
    if (command_name == Fix.HEART_OF_LIFE) { return Attribute.Skill; }
    if (command_name == Fix.DARK_AURA) { return Attribute.Skill; }
    if (command_name == Fix.TRUE_SIGHT) { return Attribute.Magic; }
    if (command_name == Fix.ORACLE_COMMAND) { return Attribute.Skill; }

    if (command_name == Fix.FLAME_BLADE) { return Attribute.Magic; }
    if (command_name == Fix.PURE_PURIFICATION) { return Attribute.Magic; }
    if (command_name == Fix.DIVINE_CIRCLE) { return Attribute.Magic; }
    if (command_name == Fix.BLOOD_SIGN) { return Attribute.Magic; }
    if (command_name == Fix.SKY_SHIELD) { return Attribute.Magic; }
    if (command_name == Fix.FLASH_COUNTER) { return Attribute.Magic; }
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return Attribute.Skill; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return Attribute.Skill; }
    if (command_name == Fix.MULTIPLE_SHOT) { return Attribute.Skill; }
    if (command_name == Fix.INVISIBLE_BIND) { return Attribute.Skill; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return Attribute.Skill; }
    if (command_name == Fix.SPIRITUAL_REST) { return Attribute.Skill; }

    if (command_name == Fix.METEOR_BULLET) { return Attribute.Magic; }
    if (command_name == Fix.BLUE_BULLET) { return Attribute.Magic; }
    if (command_name == Fix.HOLY_BREATH) { return Attribute.Magic; }
    if (command_name == Fix.BLACK_CONTRACT) { return Attribute.Magic; }
    if (command_name == Fix.STORM_ARMOR) { return Attribute.Magic; }
    if (command_name == Fix.MUTE_IMPULSE) { return Attribute.Magic; }
    if (command_name == Fix.DOUBLE_SLASH) { return Attribute.Skill; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return Attribute.Skill; }
    if (command_name == Fix.EYE_OF_THE_TRUTH) { return Attribute.Skill; }
    if (command_name == Fix.IRREGULAR_STEP) { return Attribute.Skill; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return Attribute.Skill; }
    if (command_name == Fix.UNSEEN_AID) { return Attribute.Skill; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return Attribute.Skill; }

    return Attribute.None;
  }

  public static TimingType GetTiming(string command_name)
  {
    if (command_name == Fix.NORMAL_ATTACK) { return TimingType.Normal; }
    if (command_name == Fix.MAGIC_ATTACK) { return TimingType.Normal; }
    if (command_name == Fix.DEFENSE) { return TimingType.Normal; }
    if (command_name == Fix.STAY) { return TimingType.Normal; }
    if (command_name == Fix.USE_RED_POTION) { return TimingType.Instant; }

    if (command_name == Fix.FIRE_BALL) { return TimingType.Instant; }
    if (command_name == Fix.ICE_NEEDLE) { return TimingType.Instant; }
    if (command_name == Fix.FRESH_HEAL) { return TimingType.Instant; }
    if (command_name == Fix.SHADOW_BLAST) { return TimingType.Instant; }
    if (command_name == Fix.AIR_CUTTER) { return TimingType.Instant; }
    if (command_name == Fix.ROCK_SLAM) { return TimingType.Instant; }
    if (command_name == Fix.STRAIGHT_SMASH) { return TimingType.Instant; }
    if (command_name == Fix.HUNTER_SHOT) { return TimingType.Instant; }
    if (command_name == Fix.LEG_STRIKE) { return TimingType.Instant; }
    if (command_name == Fix.VENOM_SLASH) { return TimingType.Instant; }
    if (command_name == Fix.ENERGY_BOLT) { return TimingType.Instant; }
    if (command_name == Fix.SHIELD_BASH) { return TimingType.Normal; }
    if (command_name == Fix.AURA_OF_POWER) { return TimingType.Instant; }
    if (command_name == Fix.DISPEL_MAGIC) { return TimingType.Instant; }
    if (command_name == Fix.HEART_OF_LIFE) { return TimingType.Instant; }
    if (command_name == Fix.DARK_AURA) { return TimingType.Normal; }
    if (command_name == Fix.TRUE_SIGHT) { return TimingType.Instant; }
    if (command_name == Fix.ORACLE_COMMAND) { return TimingType.Instant; }

    if (command_name == Fix.FLAME_BLADE) { return TimingType.Instant; }
    if (command_name == Fix.PURE_PURIFICATION) { return TimingType.Instant; }
    if (command_name == Fix.DIVINE_CIRCLE) { return TimingType.Normal; }
    if (command_name == Fix.BLOOD_SIGN) { return TimingType.Instant; }
    if (command_name == Fix.SKY_SHIELD) { return TimingType.Instant; }
    if (command_name == Fix.FLASH_COUNTER) { return TimingType.Instant; }
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return TimingType.Normal; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return TimingType.Normal; }
    if (command_name == Fix.MULTIPLE_SHOT) { return TimingType.Instant; }
    if (command_name == Fix.INVISIBLE_BIND) { return TimingType.Instant; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return TimingType.Instant; }
    if (command_name == Fix.SPIRITUAL_REST) { return TimingType.Instant; }

    if (command_name == Fix.METEOR_BULLET) { return TimingType.Instant; }
    if (command_name == Fix.BLUE_BULLET) { return TimingType.Instant; }
    if (command_name == Fix.HOLY_BREATH) { return TimingType.Instant; }
    if (command_name == Fix.BLACK_CONTRACT) { return TimingType.Normal; }
    if (command_name == Fix.STORM_ARMOR) { return TimingType.Instant; }
    if (command_name == Fix.MUTE_IMPULSE) { return TimingType.Instant; }
    if (command_name == Fix.DOUBLE_SLASH) { return TimingType.Instant; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return TimingType.Instant; }
    if (command_name == Fix.EYE_OF_THE_TRUTH) { return TimingType.Instant; }
    if (command_name == Fix.IRREGULAR_STEP) { return TimingType.Instant; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return TimingType.Normal; }
    if (command_name == Fix.UNSEEN_AID) { return TimingType.Instant; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return TimingType.Instant; }

    return TimingType.None; // 未設定やイレギュラーなものはデフォルトでは使用不可とする。
  }

  public static TargetType IsTarget(string command_name)
  {
    if (command_name == Fix.NORMAL_ATTACK) { return TargetType.Enemy; }
    if (command_name == Fix.MAGIC_ATTACK) { return TargetType.Enemy; }
    if (command_name == Fix.DEFENSE) { return TargetType.Own; }
    if (command_name == Fix.STAY) { return TargetType.Own; }
    if (command_name == Fix.USE_RED_POTION) { return TargetType.Ally; }

    if (command_name == Fix.FIRE_BALL) { return TargetType.Enemy; }
    if (command_name == Fix.ICE_NEEDLE) { return TargetType.Enemy; }
    if (command_name == Fix.FRESH_HEAL) { return TargetType.Ally; }
    if (command_name == Fix.SHADOW_BLAST) { return TargetType.Enemy; }
    if (command_name == Fix.AIR_CUTTER) { return TargetType.Enemy; }
    if (command_name == Fix.ROCK_SLAM) { return TargetType.Enemy; }
    if (command_name == Fix.STRAIGHT_SMASH) { return TargetType.Enemy; }
    if (command_name == Fix.HUNTER_SHOT) { return TargetType.Enemy; }
    if (command_name == Fix.LEG_STRIKE) { return TargetType.Enemy; }
    if (command_name == Fix.VENOM_SLASH) { return TargetType.Enemy; }
    if (command_name == Fix.ENERGY_BOLT) { return TargetType.Enemy; }
    if (command_name == Fix.SHIELD_BASH) { return TargetType.Enemy; }
    if (command_name == Fix.AURA_OF_POWER) { return TargetType.Ally; }
    if (command_name == Fix.DISPEL_MAGIC) { return TargetType.EnemyOrAlly; }
    if (command_name == Fix.HEART_OF_LIFE) { return TargetType.Ally; }
    if (command_name == Fix.DARK_AURA) { return TargetType.Ally; }
    if (command_name == Fix.TRUE_SIGHT) { return TargetType.Ally; }
    if (command_name == Fix.ORACLE_COMMAND) { return TargetType.Ally; }


    if (command_name == Fix.FLAME_BLADE) { return TargetType.Ally; }
    if (command_name == Fix.PURE_PURIFICATION) { return TargetType.Ally; }
    if (command_name == Fix.DIVINE_CIRCLE) { return TargetType.AllyGroup; }
    if (command_name == Fix.BLOOD_SIGN) { return TargetType.Enemy; }
    if (command_name == Fix.SKY_SHIELD) { return TargetType.Ally; }
    if (command_name == Fix.FLASH_COUNTER) { return TargetType.InstantTarget; }
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return TargetType.Own; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return TargetType.Own; }
    if (command_name == Fix.MULTIPLE_SHOT) { return TargetType.EnemyGroup; }
    if (command_name == Fix.INVISIBLE_BIND) { return TargetType.Enemy; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return TargetType.Ally; }
    if (command_name == Fix.SPIRITUAL_REST) { return TargetType.Ally; }

    if (command_name == Fix.METEOR_BULLET) { return TargetType.EnemyGroup; }
    if (command_name == Fix.BLUE_BULLET) { return TargetType.Enemy; }
    if (command_name == Fix.HOLY_BREATH) { return TargetType.Ally; }
    if (command_name == Fix.BLACK_CONTRACT) { return TargetType.Own; }
    if (command_name == Fix.STORM_ARMOR) { return TargetType.Ally; }
    if (command_name == Fix.MUTE_IMPULSE) { return TargetType.Enemy; }
    if (command_name == Fix.DOUBLE_SLASH) { return TargetType.Enemy; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return TargetType.Enemy; }
    if (command_name == Fix.EYE_OF_THE_TRUTH) { return TargetType.Own; }
    if (command_name == Fix.IRREGULAR_STEP) { return TargetType.InstantTarget; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return TargetType.AllyGroup; }
    if (command_name == Fix.UNSEEN_AID) { return TargetType.AllMember; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return TargetType.InstantTarget; }

    // 以降、モンスターアクション
    if (command_name == Fix.COMMAND_HIKKAKI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_GREEN_NENEKI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_KANAKIRI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_WILD_CLAW) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_KAMITSUKI) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_TREE_SONG) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_SUN_FIRE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_TOSSHIN) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_FEATHER_WING) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_POISON_RINPUN) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_YOUEN_FIRE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_BLAZE_DANCE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_DRILL_CYCLONE) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_RUMBLE_MACHINEGUN) { return TargetType.Enemy; }
    if (command_name == Fix.COMMAND_STRUGGLE_VOICE) { return TargetType.Enemy; }

    return TargetType.None; // 未設定やイレギュラーなものはデフォルトでは使用不可とする。
  }

  public static int CostSP(string command_name)
  {
    if (command_name == Fix.NORMAL_ATTACK) { return 0; }
    if (command_name == Fix.MAGIC_ATTACK) { return 0; }
    if (command_name == Fix.DEFENSE) { return 0; }
    if (command_name == Fix.STAY) { return 0; }
    if (command_name == Fix.USE_RED_POTION) { return 0; } // アクションコマンドだが、アイテム使用にコストの概念はない。

    if (command_name == Fix.FIRE_BALL) { return 4; }
    if (command_name == Fix.ICE_NEEDLE) { return 3; }
    if (command_name == Fix.FRESH_HEAL) { return 4; }
    if (command_name == Fix.SHADOW_BLAST) { return 3; }
    if (command_name == Fix.AIR_CUTTER) { return 3; }
    if (command_name == Fix.ROCK_SLAM) { return 5; }
    if (command_name == Fix.STRAIGHT_SMASH) { return 5; }
    if (command_name == Fix.HUNTER_SHOT) { return 4; }
    if (command_name == Fix.LEG_STRIKE) { return 4; }
    if (command_name == Fix.VENOM_SLASH) { return 4; }
    if (command_name == Fix.ENERGY_BOLT) { return 3; }
    if (command_name == Fix.SHIELD_BASH) { return 4; }
    if (command_name == Fix.AURA_OF_POWER) { return 3; }
    if (command_name == Fix.DISPEL_MAGIC) { return 3; }
    if (command_name == Fix.HEART_OF_LIFE) { return 3; }
    if (command_name == Fix.DARK_AURA) { return 3; }
    if (command_name == Fix.TRUE_SIGHT) { return 6; }
    if (command_name == Fix.ORACLE_COMMAND) { return 6; }

    if (command_name == Fix.FLAME_BLADE) { return 7; }
    if (command_name == Fix.PURE_PURIFICATION) { return 6; }
    if (command_name == Fix.DIVINE_CIRCLE) { return 8; }
    if (command_name == Fix.BLOOD_SIGN) { return 7; }
    if (command_name == Fix.SKY_SHIELD) { return 6; }
    if (command_name == Fix.FLASH_COUNTER) { return 7; }
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return 7; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return 7; }
    if (command_name == Fix.MULTIPLE_SHOT) { return 8; }
    if (command_name == Fix.INVISIBLE_BIND) { return 9; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return 11; }
    if (command_name == Fix.SPIRITUAL_REST) { return 11; }

    if (command_name == Fix.METEOR_BULLET) { return 14; }
    if (command_name == Fix.BLUE_BULLET) { return 13; }
    if (command_name == Fix.HOLY_BREATH) { return 11; }
    if (command_name == Fix.BLACK_CONTRACT) { return 12; }
    if (command_name == Fix.STORM_ARMOR) { return 16; }
    if (command_name == Fix.MUTE_IMPULSE) { return 15; }
    if (command_name == Fix.DOUBLE_SLASH) { return 14; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return 12; }
    if (command_name == Fix.EYE_OF_THE_TRUTH) { return 13; }
    if (command_name == Fix.IRREGULAR_STEP) { return 12; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return 15; }
    if (command_name == Fix.UNSEEN_AID) { return 16; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return 17; }

    if (command_name == Fix.SHINING_HEAL) { return 7; }

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
    if (command_name == Fix.COMMAND_POISON_RINPUN) { return 0; }
    if (command_name == Fix.COMMAND_YOUEN_FIRE) { return 0; }
    if (command_name == Fix.COMMAND_BLAZE_DANCE) { return 0; }
    if (command_name == Fix.COMMAND_DRILL_CYCLONE) { return 0; }
    if (command_name == Fix.COMMAND_RUMBLE_MACHINEGUN) { return 0; }
    if (command_name == Fix.COMMAND_STRUGGLE_VOICE) { return 0; }

    return Fix.INFINITY; // 未設定やイレギュラーなものはデフォルトでは使用不可とする。
  }

  public static BuffType GetBuffType(string command_name)
  {
    if (command_name == Fix.NORMAL_ATTACK) { return BuffType.None; }
    if (command_name == Fix.MAGIC_ATTACK) { return BuffType.None; }
    if (command_name == Fix.DEFENSE) { return BuffType.None; }
    if (command_name == Fix.STAY) { return BuffType.None; }
    if (command_name == Fix.USE_RED_POTION) { return BuffType.None; }

    // コマンド別
    if (command_name == Fix.FIRE_BALL) { return BuffType.None; }
    if (command_name == Fix.ICE_NEEDLE) { return BuffType.Negative; }
    if (command_name == Fix.FRESH_HEAL) { return BuffType.None; }
    if (command_name == Fix.SHADOW_BLAST) { return BuffType.Negative; }
    if (command_name == Fix.AIR_CUTTER) { return BuffType.Positive; }
    if (command_name == Fix.ROCK_SLAM) { return BuffType.None; }
    if (command_name == Fix.STRAIGHT_SMASH) { return BuffType.None; }
    if (command_name == Fix.HUNTER_SHOT) { return BuffType.Positive; }
    if (command_name == Fix.LEG_STRIKE) { return BuffType.Negative; }
    if (command_name == Fix.VENOM_SLASH) { return BuffType.Negative; }
    if (command_name == Fix.ENERGY_BOLT) { return BuffType.None; }
    if (command_name == Fix.SHIELD_BASH) { return BuffType.Negative; }
    if (command_name == Fix.AURA_OF_POWER) { return BuffType.Positive; }
    if (command_name == Fix.DISPEL_MAGIC) { return BuffType.None; }
    if (command_name == Fix.HEART_OF_LIFE) { return BuffType.Positive; }
    if (command_name == Fix.DARK_AURA) { return BuffType.Positive; }
    if (command_name == Fix.TRUE_SIGHT) { return BuffType.Positive; }
    if (command_name == Fix.ORACLE_COMMAND) { return BuffType.None; }


    if (command_name == Fix.FLAME_BLADE) { return BuffType.Positive; }
    if (command_name == Fix.PURE_PURIFICATION) { return BuffType.None; }
    if (command_name == Fix.DIVINE_CIRCLE) { return BuffType.Positive; }
    if (command_name == Fix.BLOOD_SIGN) { return BuffType.Negative; }
    if (command_name == Fix.SKY_SHIELD) { return BuffType.Positive; }
    if (command_name == Fix.FLASH_COUNTER) { return BuffType.None; }
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return BuffType.Positive; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return BuffType.Positive; }
    if (command_name == Fix.MULTIPLE_SHOT) { return BuffType.None; }
    if (command_name == Fix.INVISIBLE_BIND) { return BuffType.Negative; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return BuffType.Positive; }
    if (command_name == Fix.SPIRITUAL_REST) { return BuffType.None; }

    if (command_name == Fix.METEOR_BULLET) { return BuffType.None; }
    if (command_name == Fix.BLUE_BULLET) { return BuffType.None; }
    if (command_name == Fix.HOLY_BREATH) { return BuffType.Positive; }
    if (command_name == Fix.BLACK_CONTRACT) { return BuffType.Positive; }
    if (command_name == Fix.STORM_ARMOR) { return BuffType.Positive; }
    if (command_name == Fix.MUTE_IMPULSE) { return BuffType.None; }
    if (command_name == Fix.DOUBLE_SLASH) { return BuffType.None; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return BuffType.Negative; }
    if (command_name == Fix.EYE_OF_THE_TRUTH) { return BuffType.Positive; }
    if (command_name == Fix.IRREGULAR_STEP) { return BuffType.None; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return BuffType.Positive; }
    if (command_name == Fix.UNSEEN_AID) { return BuffType.None; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return BuffType.None; }

    // 一般系統
    if (command_name == Fix.EFFECT_POISON) { return BuffType.Negative; }
    if (command_name == Fix.EFFECT_SLIP) { return BuffType.Negative; }
    if (command_name == Fix.EFFECT_STUN) { return BuffType.Negative; }
    if (command_name == Fix.EFFECT_SHADOW_BLAST) { return BuffType.Negative; }
    if (command_name == Fix.EFFECT_FORTUNE) { return BuffType.Positive; }
    if (command_name == Fix.EFFECT_HEART_OF_LIFE) { return BuffType.Positive; }

    if (command_name == Fix.ZERO_IMMUNITY) { return BuffType.Positive; }
    if (command_name == Fix.DOUBLE_SLASH) { return BuffType.None; }

    return BuffType.None;
  }

  public static bool IsDamage(string command_name)
  {
    if (command_name == Fix.NORMAL_ATTACK) { return true; }
    if (command_name == Fix.MAGIC_ATTACK) { return true; }
    if (command_name == Fix.DEFENSE) { return false; }
    if (command_name == Fix.STAY) { return false; }
    if (command_name == Fix.USE_RED_POTION) { return false; }

    // コマンド別
    if (command_name == Fix.FIRE_BALL) { return true; }
    if (command_name == Fix.ICE_NEEDLE) { return true; }
    if (command_name == Fix.FRESH_HEAL) { return false; }
    if (command_name == Fix.SHADOW_BLAST) { return true; }
    if (command_name == Fix.AIR_CUTTER) { return true; }
    if (command_name == Fix.ROCK_SLAM) { return true; }
    if (command_name == Fix.STRAIGHT_SMASH) { return true; }
    if (command_name == Fix.HUNTER_SHOT) { return true; }
    if (command_name == Fix.LEG_STRIKE) { return true; }
    if (command_name == Fix.VENOM_SLASH) { return true; }
    if (command_name == Fix.ENERGY_BOLT) { return true; }
    if (command_name == Fix.SHIELD_BASH) { return true; }
    if (command_name == Fix.AURA_OF_POWER) { return false; }
    if (command_name == Fix.DISPEL_MAGIC) { return false; }
    if (command_name == Fix.HEART_OF_LIFE) { return false; }
    if (command_name == Fix.DARK_AURA) { return false; }
    if (command_name == Fix.TRUE_SIGHT) { return false; }
    if (command_name == Fix.ORACLE_COMMAND) { return false; }

    if (command_name == Fix.FLAME_BLADE) { return false; }
    if (command_name == Fix.PURE_PURIFICATION) { return false; }
    if (command_name == Fix.DIVINE_CIRCLE) { return false; }
    if (command_name == Fix.BLOOD_SIGN) { return false; }
    if (command_name == Fix.SKY_SHIELD) { return false; }
    if (command_name == Fix.FLASH_COUNTER) { return false; }
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return false; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return false; }
    if (command_name == Fix.MULTIPLE_SHOT) { return true; }
    if (command_name == Fix.INVISIBLE_BIND) { return false; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return false; }
    if (command_name == Fix.SPIRITUAL_REST) { return false; }

    if (command_name == Fix.METEOR_BULLET) { return true; }
    if (command_name == Fix.BLUE_BULLET) { return true; }
    if (command_name == Fix.HOLY_BREATH) { return false; }
    if (command_name == Fix.BLACK_CONTRACT) { return false; }
    if (command_name == Fix.STORM_ARMOR) { return false; }
    if (command_name == Fix.MUTE_IMPULSE) { return true; }
    if (command_name == Fix.DOUBLE_SLASH) { return true; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return true; }
    if (command_name == Fix.EYE_OF_THE_TRUTH) { return false; }
    if (command_name == Fix.IRREGULAR_STEP) { return false; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return false; }
    if (command_name == Fix.UNSEEN_AID) { return false; }
    //if (command_name == Fix.ZERO_IMMUNITY) { return false; }

    // 一般系統
    if (command_name == Fix.EFFECT_POISON) { return true; }
    if (command_name == Fix.EFFECT_SLIP) { return true; }
    if (command_name == Fix.EFFECT_STUN) { return false; }
    if (command_name == Fix.EFFECT_SHADOW_BLAST) { return true; }
    if (command_name == Fix.EFFECT_FORTUNE) { return false; }
    if (command_name == Fix.EFFECT_HEART_OF_LIFE) { return false; }

    return false;
  }
}
