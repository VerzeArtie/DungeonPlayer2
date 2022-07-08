using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class Character : MonoBehaviour
{
  public void CharacterCreation(string character_name)
  {
    this.FullName = character_name;
    List<string> actionList = new List<string>();
    this.ActionCommandMain = Fix.STAY;
    this.ActionCommand1 = Fix.STAY;
    this.ActionCommand2 = Fix.STAY;
    this.ActionCommand3 = Fix.STAY;
    this.ActionCommand4 = Fix.STAY;
    this.ActionCommand5 = Fix.STAY;
    this.ActionCommand6 = Fix.STAY;
    this.ActionCommand7 = Fix.STAY;
    this.ActionCommand8 = Fix.STAY;
    this.ActionCommand9 = Fix.STAY;
    this.CurrentActionCommand = String.Empty;

    this.BattleBackColor = Fix.COLOR_FIRST_CHARA;
    this.BattleForeColor = Fix.COLORFORE_FIRST_CHARA;
    //this.ActionCommandList[0] = Fix.NORMAL_ATTACK;
    //this.ActionCommandList[1] = Fix.MAGIC_ATTACK;
    //this.ActionCommandList[2] = Fix.DEFENSE;

    switch (character_name)
    {
      case Fix.NAME_EIN_WOLENCE:
        this.Level = 1;
        this.Strength = 5;
        this.Agility = 3;
        this.Intelligence = 2;
        this.Stamina = 4;
        this.Mind = 3;
        this.BaseLife = 30;
        this.BaseSoulPoint = 10;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Armorer;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Truth;
        this.BattleBackColor = Fix.COLOR_FIRST_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIRST_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_SWORD);
        this.MainArmor = new Item(Fix.BEGINNER_ARMOR);
        this.AvailableSwordman = true;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.StraightSmash = 1;
        this.CurrentImmediateCommand = Fix.SMALL_RED_POTION;
        this.ActionCommandMain = Fix.NORMAL_ATTACK;
        this.ActionCommand1 = Fix.STRAIGHT_SMASH;
        break;

      case Fix.NAME_LANA_AMIRIA:
        this.Level = 1;
        this.Strength = 3;
        this.Agility = 5;
        this.Intelligence = 4;
        this.Stamina = 2;
        this.Mind = 3;
        this.BaseLife = 25;
        this.BaseSoulPoint = 15;
        this.Job = Fix.JobClass.Magician;
        this.FirstCommandAttribute = Fix.CommandAttribute.Ice;
        this.SecondCommandAttribute = Fix.CommandAttribute.DarkMagic;
        this.ThirdCommandAttribute = Fix.CommandAttribute.MysticForm;
        this.BattleBackColor = Fix.COLOR_SECOND_CHARA;
        this.BattleForeColor = Fix.COLORFORE_SECOND_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_ORB);
        this.MainArmor = new Item(Fix.BEGINNER_ROBE);
        this.AvailableIce = true;
        this.GlobalAction1 = Fix.MAGIC_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.IceNeedle = 1;
        this.CurrentImmediateCommand = Fix.SMALL_RED_POTION;
        this.ActionCommandMain = Fix.MAGIC_ATTACK;
        this.ActionCommand1 = Fix.ICE_NEEDLE;
        break;

      case Fix.NAME_EONE_FULNEA:
        this.Level = 4;
        this.Strength = 7;
        this.Agility = 8;
        this.Intelligence = 11;
        this.Stamina = 5;
        this.Mind = 4;
        this.BaseLife = 35;
        this.BaseSoulPoint = 29;
        this.Job = Fix.JobClass.Magician;
        this.FirstCommandAttribute = Fix.CommandAttribute.HolyLight;
        this.SecondCommandAttribute = Fix.CommandAttribute.Archer;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Mindfulness;
        this.BattleBackColor = Fix.COLOR_THIRD_CHARA;
        this.BattleForeColor = Fix.COLORFORE_THIRD_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_ORB);
        this.MainArmor = new Item(Fix.BEGINNER_ROBE);
        this.AvailableHolyLight = true;
        this.FreshHeal = 1;
        this.AvailableArcher = true;
        this.HunterShot = 1;
        this.AvailableEnhanceForm = true;
        this.AuraOfPower = 1;
        this.GlobalAction1 = Fix.MAGIC_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.FRESH_HEAL;
        this.GlobalAction4 = Fix.MAGIC_ATTACK;
        this.ActionCommandMain = Fix.MAGIC_ATTACK;
        this.ActionCommand1 = Fix.FRESH_HEAL;
        this.ActionCommand2 = Fix.HUNTER_SHOT;
        this.ActionCommand3 = Fix.AURA_OF_POWER;
        break;

      case Fix.NAME_BILLY_RAKI:
        this.Level = 10; // 17 + 28
        this.Strength = 17;
        this.Agility = 8;
        this.Intelligence = 5;
        this.Stamina = 10;
        this.Mind = 5;
        this.BaseLife = 30;
        this.BaseSoulPoint = 10;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.MartialArts;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Brave;
        this.BattleBackColor = Fix.COLOR_FOURTH_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FOURTH_CHARA;
        this.MainWeapon = new Item(Fix.SMART_CLAW);
        this.MainArmor = new Item(Fix.SMART_CROSS);
        this.AvailableMartialArts = true;
        this.LegStrike = 1;
        this.SpeedStep = 1;
        this.AvailableFire = true;
        this.FireBall = 1;
        this.AvailableBrave = true;
        this.HeartOfLife = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.LEG_STRIKE;
        this.GlobalAction4 = Fix.DEFENSE;
        this.ActionCommandMain = Fix.NORMAL_ATTACK;
        this.ActionCommand1 = Fix.LEG_STRIKE;
        this.ActionCommand2 = Fix.FIRE_BALL;
        this.ActionCommand3 = Fix.HEART_OF_LIFE;
        this.ActionCommand4 = Fix.SPEED_STEP;
        break;

      case Fix.NAME_ADEL_BRIGANDY:
        this.Level = 1;
        this.Strength = 6;
        this.Agility = 5;
        this.Intelligence = 7;
        this.Stamina = 6;
        this.Mind = 3;
        this.BaseLife = 40;
        this.BaseSoulPoint = 12;
        this.Job = Fix.JobClass.Seeker;
        this.FirstCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Warrior;
        this.BattleBackColor = Fix.COLOR_FIFTH_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIFTH_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_SWORD);
        this.MainArmor = new Item(Fix.BEGINNER_ARMOR);
        this.AvailableEnhanceForm = true;
        this.AuraOfPower = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.NORMAL_ATTACK;
        this.GlobalAction4 = Fix.MAGIC_ATTACK;
        break;

      case Fix.NAME_CALMANS_OHN:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_MAGI_ZELKIS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_SELMOI_RO:
        this.Level = 1;
        this.Strength = 3;
        this.Agility = 20;
        this.Intelligence = 9;
        this.Stamina = 4;
        this.Mind = 8;
        this.BaseLife = 20;
        this.BaseSoulPoint = 20;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Rogue;
        this.SecondCommandAttribute = Fix.CommandAttribute.Warrior;
        this.ThirdCommandAttribute = Fix.CommandAttribute.MysticForm;
        this.BattleBackColor = Fix.COLOR_FIFTH_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIFTH_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_SWORD);
        this.MainArmor = new Item(Fix.BEGINNER_ARMOR);
        this.AvailableMysticForm = true;
        this.DispelMagic = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.DISPEL_MAGIC;
        this.GlobalAction4 = Fix.DEFENSE;
        break;

      case Fix.NAME_KARTIN_MAI:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_JEDA_ARUS:
        this.Level = 1;
        this.Strength = 7;
        this.Agility = 6;
        this.Intelligence = 7;
        this.Stamina = 4;
        this.Mind = 3;
        this.BaseLife = 30;
        this.BaseSoulPoint = 25;
        this.Job = Fix.JobClass.Seeker;
        this.FirstCommandAttribute = Fix.CommandAttribute.DarkMagic;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        this.ShadowBlast = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.SHADOW_BLAST;
        this.GlobalAction4 = Fix.DEFENSE;
        break;

      case Fix.NAME_SINIKIA_VEILHANZ:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_LENE_COLTOS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_PERMA_WARAMY:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_KILT_JORJU:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_ANNA_HAMILTON:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Strength = 4;
        this.Agility = 10;
        this.Intelligence = 5;
        this.Stamina = 5;
        this.Mind = 3;
        this.BaseLife = 40;
        this.BaseSoulPoint = 16;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Archer;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        this.HunterShot = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.HUNTER_SHOT;
        this.GlobalAction4 = Fix.DEFENSE;
        break;

      case Fix.NAME_SUN_YU:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_SHUVALTZ_FLORE:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_RVEL_ZELKIS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_VAN_HEHGUSTEL:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_OHRYU_GENMA:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_LADA_MYSTORUS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_SIN_OSCURETE:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_DELVA_TRECKINO:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_ILZINA_MELDIETE:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;
    }

    MaxGain();
  }

  public int LevelupBaseLife()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (Level == 2) { return 7; }
      if (Level == 3) { return 7; }
      if (Level == 4) { return 7; }
      if (Level == 5) { return 10; }
      if (Level == 6) { return 10; }
      if (Level == 7) { return 10; }
      if (Level == 8) { return 14; }
      if (Level == 9) { return 14; }
      if (Level == 10) { return 14; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (Level == 2) { return 6; }
      if (Level == 3) { return 6; }
      if (Level == 4) { return 6; }
      if (Level == 5) { return 9; }
      if (Level == 6) { return 9; }
      if (Level == 7) { return 9; }
      if (Level == 8) { return 12; }
      if (Level == 9) { return 12; }
      if (Level == 10) { return 12; }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (Level == 2) { return 5; }
      if (Level == 3) { return 5; }
      if (Level == 4) { return 5; }
      if (Level == 5) { return 7; }
      if (Level == 6) { return 7; }
      if (Level == 7) { return 7; }
      if (Level == 8) { return 10; }
      if (Level == 9) { return 10; }
      if (Level == 10) { return 10; }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (Level == 2) { return 7; }
      if (Level == 3) { return 7; }
      if (Level == 4) { return 7; }
      if (Level == 5) { return 10; }
      if (Level == 6) { return 10; }
      if (Level == 7) { return 10; }
      if (Level == 8) { return 14; }
      if (Level == 9) { return 14; }
      if (Level == 10) { return 14; }
    }
    return 5;
  }

  public int LevelupBaseSoulPoint()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (Level == 2) { return 2; }
      if (Level == 3) { return 2; }
      if (Level == 4) { return 2; }
      if (Level == 5) { return 2; }
      if (Level == 6) { return 2; }
      if (Level == 7) { return 2; }
      if (Level == 8) { return 2; }
      if (Level == 9) { return 3; }
      if (Level == 10) { return 3; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (Level == 2) { return 3; }
      if (Level == 3) { return 3; }
      if (Level == 4) { return 3; }
      if (Level == 5) { return 3; }
      if (Level == 6) { return 3; }
      if (Level == 7) { return 3; }
      if (Level == 8) { return 3; }
      if (Level == 9) { return 4; }
      if (Level == 10) { return 4; }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (Level == 2) { return 3; }
      if (Level == 3) { return 3; }
      if (Level == 4) { return 3; }
      if (Level == 5) { return 3; }
      if (Level == 6) { return 4; }
      if (Level == 7) { return 4; }
      if (Level == 8) { return 4; }
      if (Level == 9) { return 4; }
      if (Level == 10) { return 5; }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (Level == 2) { return 2; }
      if (Level == 3) { return 2; }
      if (Level == 4) { return 2; }
      if (Level == 5) { return 2; }
      if (Level == 6) { return 2; }
      if (Level == 7) { return 2; }
      if (Level == 8) { return 2; }
      if (Level == 9) { return 3; }
      if (Level == 10) { return 3; }
    }
    return 2;
  }

  public int LevelupRemainPoint()
  {
    if (Level <= 5) { return 3; }
    if (Level <= 10) { return 4; }
    if (Level <= 15) { return 5; }
    if (Level <= 20) { return 6; }

    return 7;
  }

  public int LevelupSoulEssence()
  {
    return 1;
  }

  public string LevelupActionCommand()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      // if (Level == 1) { return Fix.STRAIGHT_SMASH; }
      if (Level == 2) { return Fix.SHIELD_BASH; }
      if (Level == 4) { return Fix.TRUE_SIGHT; }
      if (Level == 7) { return Fix.STANCE_OF_THE_BLADE; }
      if (Level == 10) { return Fix.STANCE_OF_THE_GUARD; }
      if (Level == 15) { return Fix.LAYLINE_SCHEMA; }
      if (Level == 20) { return Fix.DOUBLE_SLASH; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      // if (Level == 1) { return Fix.ICE_NEEDLE; }
      if (Level == 2) { return Fix.SHADOW_BLAST; }
      if (Level == 4) { return Fix.DISPEL_MAGIC; }
      if (Level == 7) { return Fix.PURE_PURIFICATION; }
      if (Level == 10) { return Fix.BLOOD_SIGN; }
      if (Level == 15) { return Fix.FLASH_COUNTER; }
      if (Level == 20) { return Fix.BLUE_BULLET; }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      // if (Level == 1) { return Fix.FRESH_HEAL; }
      if (Level == 2) { return Fix.HUNTER_SHOT; }
      if (Level == 4) { return Fix.AURA_OF_POWER; }
      if (Level == 7) { return Fix.DIVINE_CIRCLE; }
      if (Level == 10) { return Fix.MULTIPLE_SHOT; }
      if (Level == 15) { return Fix.SKY_SHIELD; }
      if (Level == 20) { return Fix.HOLY_BREATH; }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      // if (Level == 1) { return Fix.LEG_STRIKE; }
      if (Level == 2) { return Fix.FIRE_BALL; }
      if (Level == 4) { return Fix.HEART_OF_LIFE; }
      if (Level == 7) { return Fix.SPEED_STEP; }
      if (Level == 10) { return Fix.FLAME_BLADE; }
      if (Level == 15) { return Fix.FORTUNE_SPIRIT; }
      if (Level == 20) { return Fix.BONE_CRUSH; }
    }
    if (this.FullName == Fix.NAME_ADEL_BRIGANDY)
    {
      // if (Level == 1) { return Fix.ENERGY_BOLT; }
      if (Level == 2) { return Fix.ROCK_SLAM; }
      if (Level == 4) { return Fix.ORACLE_COMMAND; }
      if (Level == 7) { return Fix.IDEOLOGY_OF_SOPHISTICATION; }
      if (Level == 10) { return Fix.SOLID_WALL; }
      if (Level == 15) { return Fix.SPIRITUAL_REST; }
      if (Level == 20) { return Fix.SIGIL_OF_THE_PENDING; }
    }
    if (this.FullName == Fix.NAME_SELMOI_RO)
    {
      // if (Level == 1) { return Fix.VENOM_SLASH; }
      if (Level == 2) { return Fix.AIR_CUTTER; }
      if (Level == 4) { return Fix.DARK_AURA; }
      if (Level == 7) { return Fix.INVISIBLE_BIND; }
      if (Level == 10) { return Fix.STORM_ARMOR; }
      if (Level == 15) { return Fix.STANCE_OF_THE_SHADE; }
      if (Level == 20) { return Fix.IRREGULAR_STEP; }
    }
    return String.Empty;
  }

  public bool CheckLevelupGain(int exp_plus)
  {
    if (this.Exp + exp_plus >= this.GetNextExp())
    {
      return true;
    }

    return false;
  }

  public void UpdateLevelup()
  {
    this.Level += 1;

    this.BaseLife += this.LevelupBaseLife();
    this.BaseSoulPoint += this.LevelupBaseSoulPoint();
    this.RemainPoint += this.LevelupRemainPoint();
    this.SoulFragment += this.LevelupSoulEssence();

    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (this.Level == 2)
      {
        this.AvailableArmorer = true;
        this.ShieldBash++;
        ApplyNewCommand(Fix.SHIELD_BASH);
      }
      if (this.Level == 4)
      {
        this.AvailableTruth = true;
        this.TrueSight++;
        ApplyNewCommand(Fix.TRUE_SIGHT);
      }
      if (this.Level == 7)
      {
        this.StanceOfTheBlade++;
        ApplyNewCommand(Fix.STANCE_OF_THE_BLADE);
      }
      if (this.Level == 10)
      {
        this.StanceOfTheGuard++;
        ApplyNewCommand(Fix.STANCE_OF_THE_GUARD);
      }
      if (this.Level == 15)
      {
        this.LaylineSchema++;
        ApplyNewCommand(Fix.LAYLINE_SCHEMA);
      }
      if (this.Level == 20)
      {
        this.DoubleSlash++;
        ApplyNewCommand(Fix.DOUBLE_SLASH);
      }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (this.Level == 2)
      {
        this.AvailableDarkMagic = true;
        this.ShadowBlast++;
        ApplyNewCommand(Fix.SHADOW_BLAST);
      }
      if (this.Level == 4)
      {
        this.AvailableMysticForm = true;
        this.DispelMagic++;
        ApplyNewCommand(Fix.DISPEL_MAGIC);
      }
      if (this.Level == 7)
      {
        this.PurePurification++;
        ApplyNewCommand(Fix.PURE_PURIFICATION);
      }
      if (this.Level == 10)
      {
        this.BloodSign++;
        ApplyNewCommand(Fix.BLOOD_SIGN);
      }
      if (this.Level == 15)
      {
        this.FlashCounter++;
        ApplyNewCommand(Fix.FLASH_COUNTER);
      }
      if (this.Level == 20)
      {
        this.BlueBullet++;
        ApplyNewCommand(Fix.BLUE_BULLET);
      }
    }
    if (this.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (this.Level == 2)
      {
        this.AvailableArcher = true;
        this.HunterShot++;
        ApplyNewCommand(Fix.HUNTER_SHOT);
      }
      if (this.Level == 4)
      {
        this.AvailableEnhanceForm = true;
        this.AuraOfPower++;
        ApplyNewCommand(Fix.AURA_OF_POWER);
      }
      if (this.Level == 7)
      {
        this.DivineCircle++;
        ApplyNewCommand(Fix.DIVINE_CIRCLE);
      }
      if (this.Level == 10)
      {
        this.MultipleShot++;
        ApplyNewCommand(Fix.MULTIPLE_SHOT);
      }
      if (this.Level == 15)
      {
        this.SkyShield++;
        ApplyNewCommand(Fix.SKY_SHIELD);
      }
      if (this.Level == 20)
      {
        this.HolyBreath++;
        ApplyNewCommand(Fix.HOLY_BREATH);
      }
    }
    if (this.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (this.Level == 2)
      {
        this.AvailableFire = true;
        this.FireBall++;
        ApplyNewCommand(Fix.FIRE_BALL);
      }
      if (this.Level == 4)
      {
        this.AvailableBrave = true;
        this.HeartOfLife++;
        ApplyNewCommand(Fix.HEART_OF_LIFE);
      }
      if (this.Level == 7)
      {
        this.SpeedStep++;
        ApplyNewCommand(Fix.SPEED_STEP);
      }
      if (this.Level == 10)
      {
        this.FlameBlade++;
        ApplyNewCommand(Fix.FLAME_BLADE);
      }
      if (this.Level == 15)
      {
        this.FortuneSpirit++;
        ApplyNewCommand(Fix.FORTUNE_SPIRIT);
      }
      if (this.Level == 20)
      {
        this.BoneCrush++;
        ApplyNewCommand(Fix.BONE_CRUSH);
      }
    }
  }

  private void ApplyNewCommand(string command_name)
  {
    for (int ii = 0; ii < Fix.MAX_INSTANT_NUM; ii++)
    {
      bool result = CheckToApply(ii, command_name);
      if (result) { break; }
    }
  }


  public bool CheckToApply(int ii, string command_name)
  {
    if (ii == 0 && this.ActionCommand1 == string.Empty || this.ActionCommand1 == Fix.STAY)
    {
      this.ActionCommand1 = command_name;  return true;
    }
    if (ii == 1 && this.ActionCommand2 == string.Empty || this.ActionCommand2 == Fix.STAY)
    {
      this.ActionCommand2 = command_name; return true;
    }
    if (ii == 2 && this.ActionCommand3 == string.Empty || this.ActionCommand3 == Fix.STAY)
    {
      this.ActionCommand3 = command_name; return true;
    }
    if (ii == 3 && this.ActionCommand4 == string.Empty || this.ActionCommand4 == Fix.STAY)
    {
      this.ActionCommand4 = command_name; return true;
    }
    if (ii == 4 && this.ActionCommand5 == string.Empty || this.ActionCommand5 == Fix.STAY)
    {
      this.ActionCommand5 = command_name; return true;
    }
    if (ii == 5 && this.ActionCommand6 == string.Empty || this.ActionCommand6 == Fix.STAY)
    {
      this.ActionCommand6 = command_name; return true;
    }
    if (ii == 6 && this.ActionCommand7 == string.Empty || this.ActionCommand7 == Fix.STAY)
    {
      this.ActionCommand7 = command_name; return true;
    }
    if (ii == 7 && this.ActionCommand8 == string.Empty || this.ActionCommand8 == Fix.STAY)
    {
      this.ActionCommand8 = command_name; return true;
    }
    if (ii == 8 && this.ActionCommand9 == string.Empty || this.ActionCommand9 == Fix.STAY)
    {
      this.ActionCommand9 = command_name; return true;
    }

    return false;
  }

  public string CharacterMessage(int num)
  {
    string result = string.Empty;
    switch (num)
    {
      case 1000:
        if (this.FullName == Fix.NAME_EIN_WOLENCE) { result = "アイン：敵と遭遇だ！"; }
        else if (this.FullName == Fix.NAME_LANA_AMIRIA) { result = "ラナ：：敵が来たわね、行くわよ。"; }
        else if (this.FullName == Fix.NAME_EONE_FULNEA) { result = "エオネ：・・・敵です。準備を。"; }
        else if (this.FullName == Fix.NAME_BILLY_RAKI) { result = "ビリー：敵襲だ！"; }
        break;

      case 1001:
        if (this.FullName == Fix.NAME_EIN_WOLENCE) { result = "アイン：いや、これは敵向けのコマンドだ。味方には向けられないな。"; }
        else if (this.FullName == Fix.NAME_LANA_AMIRIA) { result = "ラナ：：これは敵専用コマンドでしょ。味方に向けられるわけないじゃない。"; }
        else if (this.FullName == Fix.NAME_EONE_FULNEA) { result = "エオネ：このコマンドは敵向けです。味方には向けられません。"; }
        else if (this.FullName == Fix.NAME_BILLY_RAKI) { result = "ビリー：やっべ、間違えて味方に向けそうだったぜ。"; }
        break;
      case 1002:
        if (this.FullName == Fix.NAME_EIN_WOLENCE) { result = "アイン：いや、これは味方向けのコマンドだ。敵には向けられないな。"; }
        else if (this.FullName == Fix.NAME_LANA_AMIRIA) { result = "ラナ：：これは味方専用コマンドでしょ。敵に向けられるわけないじゃない。"; }
        else if (this.FullName == Fix.NAME_EONE_FULNEA) { result = "エオネ：いえ、このコマンドは味方向けです。敵には向けられません。"; }
        else if (this.FullName == Fix.NAME_BILLY_RAKI) { result = "ビリー：やっべ、間違えて敵に向けそうだったぜ。"; }
        break;
      case 1003:
        if (this.FullName == Fix.NAME_EIN_WOLENCE) { result = "アイン：しまった。インスタントが足りねえ。"; }
        else if (this.FullName == Fix.NAME_LANA_AMIRIA) { result = "ラナ：：インスタントが足りないわよ。"; }
        else if (this.FullName == Fix.NAME_EONE_FULNEA) { result = "エオネ：インスタントが足りませんね。"; }
        else if (this.FullName == Fix.NAME_BILLY_RAKI) { result = "ビリー：インスタント足りねー！"; }
        break;
    }

    return result;
  }
}