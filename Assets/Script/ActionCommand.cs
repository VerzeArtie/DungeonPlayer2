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
      result.Add(Fix.FIRE_BOLT);
      result.Add(Fix.FLAME_BLADE);
      result.Add(Fix.METEOR_BULLET);
      result.Add(Fix.FLAME_STRIKE);
      result.Add(Fix.LAVA_ANNIHILATION);
    }
    else if (attr == Fix.CommandAttribute.Ice)
    {
      result.Add(Fix.ICE_NEEDLE);
      result.Add(Fix.PURE_PURIFICATION);
      result.Add(Fix.BLUE_BULLET);
      result.Add(Fix.FREEZING_CUBE);
      result.Add(Fix.FROST_LANCE);
    }
    else if (attr == Fix.CommandAttribute.HolyLight)
    {
      result.Add(Fix.FRESH_HEAL);
      result.Add(Fix.DIVINE_CIRCLE);
      result.Add(Fix.HOLY_BREATH);
      result.Add(Fix.SANCTION_FIELD);
      result.Add(Fix.VALKYRIE_BREAK);
    }
    else if (attr == Fix.CommandAttribute.DarkMagic)
    {
      result.Add(Fix.SHADOW_BLAST);
      result.Add(Fix.BLOOD_SIGN);
      result.Add(Fix.DEATH_SCYTHE);
      result.Add(Fix.WHISPER_VOICE);
      result.Add(Fix.ABYSS_EYE);
    }
    else if (attr == Fix.CommandAttribute.Swordman)
    {
      result.Add(Fix.STRAIGHT_SMASH);
      result.Add(Fix.STANCE_OF_THE_BLADE);
      result.Add(Fix.DOUBLE_SLASH);
      result.Add(Fix.WAR_SWING);
      result.Add(Fix.KINETIC_SMASH);
    }
    else if (attr == Fix.CommandAttribute.Armorer)
    {
      result.Add(Fix.SHIELD_BASH);
      result.Add(Fix.STANCE_OF_THE_GUARD);
      result.Add(Fix.CONCUSSIVE_HIT);
      result.Add(Fix.DOMINATION_FIELD);
      result.Add(Fix.OATH_OF_AEGIS);
    }
    else if (attr == Fix.CommandAttribute.Archer)
    {
      result.Add(Fix.HUNTER_SHOT);
      result.Add(Fix.MULTIPLE_SHOT);
      result.Add(Fix.REACHABLE_TARGET);
      result.Add(Fix.HAWK_EYE);
      result.Add(Fix.PIERCING_ARROW);
    }
    else if (attr == Fix.CommandAttribute.Rogue)
    {
      result.Add(Fix.VENOM_SLASH);
      result.Add(Fix.INVISIBLE_BIND);
      result.Add(Fix.IRREGULAR_STEP);
      result.Add(Fix.DISSENSION_RHYTHM);
      result.Add(Fix.ASSASSINATION_HIT);
    }
    else if (attr == Fix.CommandAttribute.EnhanceForm)
    {
      result.Add(Fix.AURA_OF_POWER);
      result.Add(Fix.SKY_SHIELD);
      result.Add(Fix.STORM_ARMOR);
      result.Add(Fix.AETHER_DRIVE);
      result.Add(Fix.RUNE_STRIKE);
    }
    else if (attr == Fix.CommandAttribute.MysticForm)
    {
      result.Add(Fix.DISPEL_MAGIC);
      result.Add(Fix.FLASH_COUNTER);
      result.Add(Fix.MUTE_IMPULSE);
      result.Add(Fix.DETACHMENT_FAULT);
      result.Add(Fix.PHANTOM_OBORO);
    }
    else if (attr == Fix.CommandAttribute.Brave)
    {
      result.Add(Fix.HEART_OF_LIFE);
      result.Add(Fix.FORTUNE_SPIRIT);
      result.Add(Fix.VOICE_OF_VIGOR);
      result.Add(Fix.SIGIL_OF_THE_FAITH);
      result.Add(Fix.RAGING_STORM);
    }
    else if (attr == Fix.CommandAttribute.Mindfulness)
    {
      result.Add(Fix.ORACLE_COMMAND);
      result.Add(Fix.SPIRITUAL_REST);
      result.Add(Fix.ZERO_IMMUNITY);
      result.Add(Fix.ESSENCE_OVERFLOW);
      result.Add(Fix.INNER_INSPIRATION);
    }
    return result;
  }
  public static List<int> GetCommandPlus(Character player, Fix.CommandAttribute attr)
  {
    List<int> result = new List<int>();
    if (attr == Fix.CommandAttribute.Fire)
    {
      result.Add(player.FireBolt);
      result.Add(player.FlameBlade);
      result.Add(player.MeteorBullet);
      result.Add(player.FlameStrike);
      result.Add(player.LavaAnnihilation);
    }
    else if (attr == Fix.CommandAttribute.Ice)
    {
      result.Add(player.IceNeedle);
      result.Add(player.PurePurification);
      result.Add(player.BlueBullet);
      result.Add(player.FreezingCube);
      result.Add(player.FrostLance);
    }
    else if (attr == Fix.CommandAttribute.HolyLight)
    {
      result.Add(player.FreshHeal);
      result.Add(player.DivineCircle);
      result.Add(player.HolyBreath);
      result.Add(player.SanctionField);
      result.Add(player.ValkyrieBreak);
    }
    else if (attr == Fix.CommandAttribute.DarkMagic)
    {
      result.Add(player.ShadowBlast);
      result.Add(player.BloodSign);
      result.Add(player.DeathScythe);
      result.Add(player.WhisperVoice);
      result.Add(player.AbyssEye);
    }
    else if (attr == Fix.CommandAttribute.Swordman)
    {
      result.Add(player.StraightSmash);
      result.Add(player.StanceOfTheBlade);
      result.Add(player.DoubleSlash);
      result.Add(player.WarSwing);
      result.Add(player.KineticSmash);
    }
    else if (attr == Fix.CommandAttribute.Armorer)
    {
      result.Add(player.ShieldBash);
      result.Add(player.StanceOfTheGuard);
      result.Add(player.ConcussiveHit);
      result.Add(player.DominationField);
      result.Add(player.OathOfAegis);
    }
    else if (attr == Fix.CommandAttribute.Archer)
    {
      result.Add(player.HunterShot);
      result.Add(player.MultipleShot);
      result.Add(player.ReachableTarget);
      result.Add(player.HawkEye);
      result.Add(player.PiercingArrow);
    }
    else if (attr == Fix.CommandAttribute.Rogue)
    {
      result.Add(player.VenomSlash);
      result.Add(player.InvisibleBind);
      result.Add(player.IrregularStep);
      result.Add(player.DissensionRhythm);
      result.Add(player.AssassinationHit);
    }
    else if (attr == Fix.CommandAttribute.EnhanceForm)
    {
      result.Add(player.AuraOfPower);
      result.Add(player.SkyShield);
      result.Add(player.StormArmor);
      result.Add(player.AetherDrive);
      result.Add(player.RuneStrike);
    }
    else if (attr == Fix.CommandAttribute.MysticForm)
    {
      result.Add(player.DispelMagic);
      result.Add(player.FlashCounter);
      result.Add(player.MuteImpulse);
      result.Add(player.DetachmentFault);
      result.Add(player.PhantomOboro);
    }
    else if (attr == Fix.CommandAttribute.Brave)
    {
      result.Add(player.HeartOfLife);
      result.Add(player.FortuneSpirit);
      result.Add(player.VoiceOfVigor);
      result.Add(player.SigilOfTheFaith);
      result.Add(player.RagingStorm);
    }
    else if (attr == Fix.CommandAttribute.Mindfulness)
    {
      result.Add(player.OracleCommand);
      result.Add(player.SpiritualRest);
      result.Add(player.ZeroImmunity);
      result.Add(player.EssenceOverflow);
      result.Add(player.InnerInspiration);
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
    else if (attr == Fix.CommandAttribute.Swordman)
    {
      return new Color(0, 210.0f / 255.0f, 40.0f / 255.0f);
    }
    else if (attr == Fix.CommandAttribute.Armorer)
    {
      return new Color(1.0f, 194.0f / 255.0f, 0);
    }
    else if (attr == Fix.CommandAttribute.Archer)
    {
      return new Color(114.0f / 255.0f, 0, 217.0f / 255.0f);
    }
    else if (attr == Fix.CommandAttribute.Rogue)
    {
      return new Color(45.0f / 255.0f, 58.0f / 255.0f, 24.0f / 255.0f);
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

    if (command_name == Fix.FIRE_BOLT) { return Attribute.Magic; }
    if (command_name == Fix.ICE_NEEDLE) { return Attribute.Magic; }
    if (command_name == Fix.FRESH_HEAL) { return Attribute.Magic; }
    if (command_name == Fix.SHADOW_BLAST) { return Attribute.Magic; }
    if (command_name == Fix.AURA_OF_POWER) { return Attribute.Magic; }
    if (command_name == Fix.DISPEL_MAGIC) { return Attribute.Magic; }
    if (command_name == Fix.STRAIGHT_SMASH) { return Attribute.Skill; }
    if (command_name == Fix.SHIELD_BASH) { return Attribute.Skill; }
    if (command_name == Fix.HUNTER_SHOT) { return Attribute.Skill; }
    if (command_name == Fix.VENOM_SLASH) { return Attribute.Skill; }
    if (command_name == Fix.HEART_OF_LIFE) { return Attribute.Skill; }
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

    if (command_name == Fix.ZERO_IMMUNITY) { return Attribute.Skill; }
    if (command_name == Fix.CIRCLE_SLASH) { return Attribute.Skill; }
    if (command_name == Fix.DOUBLE_SLASH) { return Attribute.Skill; }

    return Attribute.None;
  }

  public static TimingType GetTiming(string command_name)
  {
    if (command_name == Fix.NORMAL_ATTACK) { return TimingType.Normal; }
    if (command_name == Fix.MAGIC_ATTACK) { return TimingType.Normal; }
    if (command_name == Fix.DEFENSE) { return TimingType.Normal; }
    if (command_name == Fix.STAY) { return TimingType.Normal; }
    if (command_name == Fix.USE_RED_POTION) { return TimingType.Instant; }

    if (command_name == Fix.FIRE_BOLT) { return TimingType.Instant; }
    if (command_name == Fix.ICE_NEEDLE) { return TimingType.Instant; }
    if (command_name == Fix.FRESH_HEAL) { return TimingType.Instant; }
    if (command_name == Fix.SHADOW_BLAST) { return TimingType.Instant; }
    if (command_name == Fix.AURA_OF_POWER) { return TimingType.Instant; }
    if (command_name == Fix.DISPEL_MAGIC) { return TimingType.Instant; }
    if (command_name == Fix.STRAIGHT_SMASH) { return TimingType.Instant; }
    if (command_name == Fix.SHIELD_BASH) { return TimingType.Instant; }
    if (command_name == Fix.HUNTER_SHOT) { return TimingType.Instant; }
    if (command_name == Fix.VENOM_SLASH) { return TimingType.Instant; }
    if (command_name == Fix.HEART_OF_LIFE) { return TimingType.Instant; }
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

    if (command_name == Fix.ZERO_IMMUNITY) { return TimingType.Instant; }
    if (command_name == Fix.CIRCLE_SLASH) { return TimingType.Instant; }
    if (command_name == Fix.DOUBLE_SLASH) { return TimingType.Instant; }

    return TimingType.None; // 未設定やイレギュラーなものはデフォルトでは使用不可とする。
  }

  public static TargetType IsTarget(string command_name)
  {
    if (command_name == Fix.NORMAL_ATTACK) { return TargetType.Enemy; }
    if (command_name == Fix.MAGIC_ATTACK) { return TargetType.Enemy; }
    if (command_name == Fix.DEFENSE) { return TargetType.Own; }
    if (command_name == Fix.STAY) { return TargetType.Own; }
    if (command_name == Fix.USE_RED_POTION) { return TargetType.Ally; }

    if (command_name == Fix.FIRE_BOLT) { return TargetType.Enemy; }
    if (command_name == Fix.ICE_NEEDLE) { return TargetType.Enemy; }
    if (command_name == Fix.FRESH_HEAL) { return TargetType.Ally; }
    if (command_name == Fix.SHADOW_BLAST) { return TargetType.Enemy; }
    if (command_name == Fix.AURA_OF_POWER) { return TargetType.Ally; }
    if (command_name == Fix.DISPEL_MAGIC) { return TargetType.Enemy; }
    if (command_name == Fix.STRAIGHT_SMASH) { return TargetType.Enemy; }
    if (command_name == Fix.SHIELD_BASH) { return TargetType.Enemy; }
    if (command_name == Fix.HUNTER_SHOT) { return TargetType.Enemy; }
    if (command_name == Fix.VENOM_SLASH) { return TargetType.Enemy; }
    if (command_name == Fix.HEART_OF_LIFE) { return TargetType.Ally; }
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

    if (command_name == Fix.ZERO_IMMUNITY) { return TargetType.None; }
    if (command_name == Fix.CIRCLE_SLASH) { return TargetType.None; }
    if (command_name == Fix.DOUBLE_SLASH) { return TargetType.None; }

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

    if (command_name == Fix.FIRE_BOLT) { return 4; }
    if (command_name == Fix.ICE_NEEDLE) { return 3; }
    if (command_name == Fix.FRESH_HEAL) { return 3; }
    if (command_name == Fix.SHADOW_BLAST) { return 3; }
    if (command_name == Fix.AURA_OF_POWER) { return 2; }
    if (command_name == Fix.DISPEL_MAGIC) { return 4; }
    if (command_name == Fix.STRAIGHT_SMASH) { return 5; }
    if (command_name == Fix.SHIELD_BASH) { return 3; }
    if (command_name == Fix.HUNTER_SHOT) { return 4; }
    if (command_name == Fix.VENOM_SLASH) { return 3; }
    if (command_name == Fix.HEART_OF_LIFE) { return 3; }
    if (command_name == Fix.ORACLE_COMMAND) { return 2; } // todo
    if (command_name == Fix.FLAME_BLADE) { return 7; }
    if (command_name == Fix.PURE_PURIFICATION) { return 10; }
    if (command_name == Fix.DIVINE_CIRCLE) { return 9; }
    if (command_name == Fix.BLOOD_SIGN) { return 10; }
    if (command_name == Fix.SKY_SHIELD) { return 11; }
    if (command_name == Fix.FLASH_COUNTER) { return 8; }
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return 5; }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return 5; }
    if (command_name == Fix.MULTIPLE_SHOT) { return 12; }
    if (command_name == Fix.INVISIBLE_BIND) { return 9; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return 15; }
    if (command_name == Fix.SPIRITUAL_REST) { return 15; }

    if (command_name == Fix.METEOR_BULLET) { return 1; }
    if (command_name == Fix.BLUE_BULLET) { return 1; }

    if (command_name == Fix.ZERO_IMMUNITY) { return 20; }
    if (command_name == Fix.CIRCLE_SLASH) { return 18; }
    if (command_name == Fix.DOUBLE_SLASH) { return 16; }

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
    if (command_name == Fix.FIRE_BOLT) { return BuffType.None; }
    if (command_name == Fix.ICE_NEEDLE) { return BuffType.Negative; }
    if (command_name == Fix.FRESH_HEAL) { return BuffType.None; }
    if (command_name == Fix.SHADOW_BLAST) { return BuffType.Negative; }
    if (command_name == Fix.AURA_OF_POWER) { return BuffType.Positive; }
    if (command_name == Fix.DISPEL_MAGIC) { return BuffType.None; }
    if (command_name == Fix.STRAIGHT_SMASH) { return BuffType.None; }
    if (command_name == Fix.SHIELD_BASH) { return BuffType.Negative; }
    if (command_name == Fix.HUNTER_SHOT) { return BuffType.Negative; }
    if (command_name == Fix.VENOM_SLASH) { return BuffType.Negative; }
    if (command_name == Fix.HEART_OF_LIFE) { return BuffType.Positive; }
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

    // 一般系統
    if (command_name == Fix.EFFECT_POISON) { return BuffType.Negative; }
    if (command_name == Fix.EFFECT_SLIP) { return BuffType.Negative; }
    if (command_name == Fix.EFFECT_STUN) { return BuffType.Negative; }
    if (command_name == Fix.EFFECT_SHADOW_BLAST) { return BuffType.Negative; }
    if (command_name == Fix.EFFECT_FORTUNE) { return BuffType.Positive; }
    if (command_name == Fix.EFFECT_HEART_OF_LIFE) { return BuffType.Positive; }

    if (command_name == Fix.ZERO_IMMUNITY) { return BuffType.Positive; }
    if (command_name == Fix.CIRCLE_SLASH) { return BuffType.None; }
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
    if (command_name == Fix.FIRE_BOLT) { return true; }
    if (command_name == Fix.ICE_NEEDLE) { return true; }
    if (command_name == Fix.FRESH_HEAL) { return false; }
    if (command_name == Fix.SHADOW_BLAST) { return true; }
    if (command_name == Fix.AURA_OF_POWER) { return false; }
    if (command_name == Fix.DISPEL_MAGIC) { return false; }
    if (command_name == Fix.STRAIGHT_SMASH) { return true; }
    if (command_name == Fix.SHIELD_BASH) { return true; }
    if (command_name == Fix.HUNTER_SHOT) { return true; }
    if (command_name == Fix.VENOM_SLASH) { return true; }
    if (command_name == Fix.HEART_OF_LIFE) { return false; }
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

    // 一般系統
    if (command_name == Fix.EFFECT_POISON) { return true; }
    if (command_name == Fix.EFFECT_SLIP) { return true; }
    if (command_name == Fix.EFFECT_STUN) { return false; }
    if (command_name == Fix.EFFECT_SHADOW_BLAST) { return true; }
    if (command_name == Fix.EFFECT_FORTUNE) { return false; }
    if (command_name == Fix.EFFECT_HEART_OF_LIFE) { return false; }


    if (command_name == Fix.ZERO_IMMUNITY) { return false; }
    if (command_name == Fix.CIRCLE_SLASH) { return true; }
    if (command_name == Fix.DOUBLE_SLASH) { return true; }

    return false;
  }
}
