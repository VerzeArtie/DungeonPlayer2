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
    actionList.Add(Fix.STAY);
    actionList.Add(Fix.STAY);
    actionList.Add(Fix.STAY);
    actionList.Add(Fix.STAY);
    actionList.Add(Fix.STAY);
    actionList.Add(Fix.STAY);
    actionList.Add(Fix.STAY);
    actionList.Add(Fix.STAY);
    actionList.Add(Fix.STAY);
    actionList.Add(Fix.STAY);
    this.ActionCommandList = actionList;
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
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
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
        this.ActionCommandList[0] = Fix.STRAIGHT_SMASH;
        break;

      case Fix.NAME_LANA_AMIRIA:
        this.Level = 1;
        this.Strength = 4;
        this.Agility = 5;
        this.Intelligence = 3;
        this.Stamina = 2;
        this.Mind = 3;
        this.BaseLife = 25;
        this.BaseSoulPoint = 15;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.MartialArts;
        this.SecondCommandAttribute = Fix.CommandAttribute.Ice;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Mindfulness;
        this.BattleBackColor = Fix.COLOR_SECOND_CHARA;
        this.BattleForeColor = Fix.COLORFORE_SECOND_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_CLAW);
        this.MainArmor = new Item(Fix.BEGINNER_CROSS);
        this.AvailableIce = true;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.LegStrike = 1;
        this.CurrentImmediateCommand = Fix.SMALL_RED_POTION;
        this.ActionCommandList[0] = Fix.LEG_STRIKE;
        break;

      case Fix.NAME_EONE_FULNEA:
        this.Level = 1;
        this.Strength = 4;
        this.Agility = 6;
        this.Intelligence = 9;
        this.Stamina = 4;
        this.Mind = 3;
        this.BaseLife = 20;
        this.BaseSoulPoint = 20;
        this.Job = Fix.JobClass.Magician;
        this.FirstCommandAttribute = Fix.CommandAttribute.HolyLight;
        this.SecondCommandAttribute = Fix.CommandAttribute.Ice;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Mindfulness;
        this.BattleBackColor = Fix.COLOR_THIRD_CHARA;
        this.BattleForeColor = Fix.COLORFORE_THIRD_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_ORB);
        this.MainArmor = new Item(Fix.BEGINNER_ROBE);
        this.AvailableHolyLight = true;
        this.FreshHeal = 1;
        this.GlobalAction1 = Fix.MAGIC_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.FRESH_HEAL;
        this.GlobalAction4 = Fix.MAGIC_ATTACK;
        this.ActionCommandList[0] = Fix.FRESH_HEAL;
        break;

      case Fix.NAME_BILLY_RAKI:
        this.Level = 1;
        this.Strength = 10;
        this.Agility = 5;
        this.Intelligence = 2;
        this.Stamina = 7;
        this.Mind = 3;
        this.BaseLife = 30;
        this.BaseSoulPoint = 10;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Warrior;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        this.BattleBackColor = Fix.COLOR_FOURTH_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FOURTH_CHARA;
        this.MainWeapon = new Item(Fix.PRACTICE_SWORD);
        this.MainArmor = new Item(Fix.BEGINNER_ARMOR);
        this.AvailableSwordman = true;
        this.StraightSmash = 1;
        this.GlobalAction1 = Fix.NORMAL_ATTACK;
        this.GlobalAction2 = Fix.DEFENSE;
        this.GlobalAction3 = Fix.STRAIGHT_SMASH;
        this.GlobalAction4 = Fix.DEFENSE;
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
      if (Level == 2) { return 5; }
      if (Level == 3) { return 5; }
      if (Level == 4) { return 5; }
      if (Level == 5) { return 5; }
      if (Level == 6) { return 6; }
      if (Level == 7) { return 6; }
      if (Level == 8) { return 6; }
      if (Level == 9) { return 7; }
      if (Level == 10) { return 7; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (Level == 2) { return 4; }
      if (Level == 3) { return 4; }
      if (Level == 4) { return 4; }
      if (Level == 5) { return 4; }
      if (Level == 6) { return 4; }
      if (Level == 7) { return 5; }
      if (Level == 8) { return 5; }
      if (Level == 9) { return 5; }
      if (Level == 10) { return 5; }
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
    return 2;
  }

  public int LevelupRemainPoint()
  {
    return 3;
  }

  public int LevelupSoulEssence()
  {
    return 1;
  }

  public string LevelupActionCommand()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (Level == 2) { return Fix.FIRE_BALL; }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (Level == 2) { return Fix.ICE_NEEDLE; }
    }
    return String.Empty;
  }

  public void AcceptLevelUp()
  {
    if (this.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (this.Level == 2)
      {
        this.BaseLife += this.LevelupBaseLife();
        this.BaseSoulPoint += this.LevelupBaseSoulPoint();
        this.RemainPoint += this.LevelupRemainPoint();
        this.SoulFragment += this.LevelupSoulEssence();
        this.AvailableFire = true;
        this.FireBall++;
        for (int ii = 0; ii < this.ActionCommandList.Count; ii++)
        {
          if (this.ActionCommandList[ii] == Fix.STAY || this.ActionCommandList[ii] == String.Empty)
          {
            this.ActionCommandList[ii] = Fix.FIRE_BALL;
            break;
          }
        }
      }
    }
    if (this.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (this.Level == 2)
      {
        this.BaseLife += this.LevelupBaseLife();
        this.BaseSoulPoint += this.LevelupBaseSoulPoint();
        this.RemainPoint += this.LevelupRemainPoint();
        this.SoulFragment += this.LevelupSoulEssence();
        this.AvailableIce = true;
        this.IceNeedle++;
        for (int ii = 0; ii < this.ActionCommandList.Count; ii++)
        {
          if (this.ActionCommandList[ii] == Fix.STAY || this.ActionCommandList[ii] == String.Empty)
          {
            this.ActionCommandList[ii] = Fix.ICE_NEEDLE;
            break;
          }
        }
      }
    }
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