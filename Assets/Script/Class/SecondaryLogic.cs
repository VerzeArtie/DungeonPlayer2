using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class SecondaryLogic
{
  public static double NormalAttack(Character player)
  {
    return 1.00f;
  }

  public static double MagicAttack(Character player)
  {
    return 1.00f;
  }

  public static int CriticalRate(Character player, Character target)
  {
    int result = 5;
    BuffImage hunterShot = target.IsHunterShot;
    if (hunterShot != null)
    {
      result += (int)(hunterShot.EffectValue);
    }
    return result;
  }

  public static double CriticalFactor(Character player)
  {
    return 2.00f;
  }

  public static double DefenseFactor(Character player)
  {
    double result = 0.50f;
    // if (player.DefenseSkill <= 0) { return result; }

    BuffImage dominationField = player.SearchFieldBuff(Fix.DOMINATION_FIELD);
    if (dominationField)
    {
      Debug.Log("DefenseFactor by dominationField(before): " + result.ToString());
      result -= dominationField.EffectValue2;
      Debug.Log("DefenseFactor by dominationField(after ): " + result.ToString());
    }
    else
    {
      Debug.Log("DefenseFactor by dominationField, no effect...");
    }

    result -= player.DefenseSkill * 0.02f; // 軽減率なので、この値は減少させる。
    if (result <= 0.00f) { result = 0.01f; } // 完全に0にはせず、最小値を設ける。
    return result;
  }

  public static double MagicSpellFactor(Character player)
  {
    if (player.MagicSpell <= 0) { return 0.00f; }
    return 0.00f + (player.MagicSpell * 0.05f);
  }

  public static double EvadingSkill(Character player)
  {
    double result = 1.00f; // 1.00fは回避率に対する乗算であるため、1.00fは回避率へ影響しない値となる。
    if (player.EvadingSkill <= 0) { return result; }

    result = result - (player.EvadingSkill * 0.10f);
    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  public static double FireBall(Character player)
  {
    if (player.FireBall <= 1) { return 2.00f; }
    return 2.00f + (player.FireBall - 1) * 0.10f;
  }

  public static double IceNeedle(Character player)
  {
    if (player.IceNeedle <= 1) { return 1.80f; }
    return 1.80f + (player.IceNeedle - 1) * 0.09f;
  }
  public static int IceNeedle_Turn(Character player)
  {
    return 2;
  }
  public static double IceNeedle_Value(Character player)
  {
    return 0.80f;
  }

  public static double FreshHeal(Character player)
  {
    if (player.FreshHeal <= 1) { return 3.00f; }
    return 3.00f + (player.FreshHeal - 1) * 0.20f;
  }

  public static double ShadowBlast(Character player)
  {
    return 1.50f;
  }
  public static int ShadowBlast_Turn(Character player)
  {
    return 9;
  }
  public static double ShadowBlast_Value(Character player)
  {
    if (player.ShadowBlast <= 1) { return 0.80f; }

    return 0.80f - (player.ShadowBlast - 1) * 0.05f;
  }

  public static double AirCutter(Character player)
  {
    return 1.60f;
  }
  public static int AirCutter_Turn(Character player)
  {
    return 9;
  }
  public static double AirCutter_Value(Character player)
  {
    return 1.20f;
  }

  public static double RockSlum(Character player)
  {
    return 1.70f;
  }
  public static int RockSlum_Turn(Character player)
  {
    return 5;
  }
  public static double RockSlum_Value(Character player)
  {
    return 0.80f;
  }

  public static double StraightSmash(Character player)
  {
    if (player.StraightSmash <= 1) { return 2.00f; }

    return 2.00f + (player.StraightSmash - 1) * 0.10f;
  }

  public static double HunterShot(Character player)
  {
    return 1.50f;
  }
  public static int HunterShot_Turn(Character player)
  {
    return 9;
  }
  public static double HunterShot_Value(Character player)
  {
    return 10.0f + (player.HunterShot - 1) * 2.0f;
  }

  public static double LegStrike(Character player)
  {
    return 1.80f;
  }
  public static int LegStrike_Turn(Character player)
  {
    return 9;
  }
  public static double LegStrike_Value(Character player)
  {
    if (player.LegStrike <= 1) { return 1.20f; }
    return 1.20f + (player.LegStrike - 1) * 0.05f;
  }

  public static double VenomSlash(Character player)
  {
    return 1.50f;
  }
  public static double VenomSlash_2(Character player)
  {
    return PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Strength) * 0.50f;
  }
  public static int VenomSlash_Turn(Character player)
  {
    return 3;
  }

  public static double EnergyBolt(Character player)
  {
    return 1.40;
  }

  public static double ShieldBash(Character player)
  {
    return 1.00f;
  }
  public static int ShieldBash_Turn(Character player)
  {
    if (player.ShieldBash <= 1) { return 1; }
    return 1 + (player.ShieldBash - 1); // todo ただし、強すぎると思われる。
  }

  public static int AuraOfPower_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double AuraOfPower_Value(Character player)
  {
    return 1.20f;
  }

  public static int TrueSight_Turn(Character player)
  {
    return Fix.INFINITY;
  }
  public static double TrueSight_Value(Character player)
  {
    if (player.TrueSight <= 1) { return 1.10f; }
    return 1.10f + (player.TrueSight - 1) * 0.05f;
  }

  public static int DispelMagic_Value(Character player)
  {
    if (player.DispelMagic <= 1) { return 1; }
    return 1 + (player.DispelMagic - 1);
  }

  public static int SkyShield_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double SkyShield_Value(Character player)
  {
    return 1.20f;
  }

  public static double HeartOfLife(Character player)
  {
    if (player.HeartOfLife <= 1)
    {
      return PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence);
    }

    return PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * (1.00f + (player.HeartOfLife - 1) * 0.10f);
  }

  public static int HeartOfLife_Turn(Character player)
  {
    return 3;
  }

  public static int DarknessCircle_Turn(Character player)
  {
    return 5;
  }

  public static double DarknessCircle_Value(Character player)
  {
    return 0.80f;
  }

  public static double OracleCommand(Character player)
  {
    return 0.50f + (player.OracleCommand - 1) * 0.10f;
  }

  public static double MultipleShot(Character player)
  {
    if (player.MultipleShot <= 1) { return 1.20f; }
    return 1.20f + (player.MultipleShot - 1) * 0.10f;
  }

  public static int LeylineSchema_Turn(Character player)
  {
    return Fix.INFINITY;
  }
  public static double LeylineSchema_Effect1(Character player)
  {
    if (player.LeylineSchema <= 1) { return 2.00f; }
    return 2.00f + (player.LeylineSchema - 1) * 2.00f;
  }

  public static double FlameBlade(Character player)
  {
    double factor = 0.00f;
    if (player.FlameBlade <= 1) 
    {
      factor = 1.00f; 
    }
    else
    {
      factor = 1.00f + (player.FlameBlade - 1) * 0.20f;
    }

    return 20.0f + PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * factor;
  }

  public static int FlameBlade_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double PurePurificationHealValuel(Character player)
  {
    if (player.PurePurification <= 1) { return 0.70f; }
    return 0.70f + (player.PurePurification - 1) * 0.10f;
  }

  public static int PurePurification_Effect1(Character player)
  {
    if (player.PurePurification <= 1) { return 1; }
    return 1 + (player.PurePurification - 1);
  }

  public static double BloodSign(Character player)
  {
    double result = 0.0f;
    if (player.BloodSign <= 1)
    {
      result = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * 1.00f;
    }
    else
    {
      result = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * (1.00f + (player.BloodSign - 1) * 0.20f);
    }

    return result;
  }

  public static int BloodSign_Turn(Character player)
  {
    return 5;
  }

  public static double DivineCircle_Effect1(Character player)
  {
    double result = 0.0f;
    if (player.DivineCircle <= 1)
    {
      result = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * 1.50f;
    }
    else
    {
      result = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * (1.50f + (player.DivineCircle - 1) * 0.30f);
    }
    return result;
  }

  public static int DivineCircle_Turn(Character player)
  {
    return 9;
  }

  public static int FortuneSpirit_Turn(Character player)
  {
    return Fix.INFINITY;
  }
  public static int FortuneSpirit_Effect1(Character player)
  {
    if (player.FortuneSpirit <= 1) { return 1; }
    return 1 + (player.FortuneSpirit - 1);
  }
  public static double StanceOfTheBladeDamage(Character player)
  {
    if (player.StanceOfTheBlade <= 1) { return 1.50f; }
    return 1.50f + (player.StanceOfTheBlade - 1) * 0.05f;
  }

  public static double StanceOfTheBlade(Character player)
  {
    if (player.StanceOfTheBlade <= 1) { return 0.10f; }
    return 0.10f + (player.StanceOfTheBlade - 1) * 0.30f;
  }

  public static int StanceOfTheBlade_Turn(Character player)
  {
    return 10;
  }

  public static double SpeedStepDamage(Character player)
  {
    return 1.40f;
  }

  public static double SpeedStep(Character player)
  {
    if (player.SpeedStep <= 1) { return 0.05f; }
    return 0.05f + (player.SpeedStep - 1) * 0.03f;
  }
  public static int SpeedStep_Turn(Character player)
  {
    return 10;
  }

  public static double StanceOfTheGuard(Character player)
  {
    if (player.StanceOfTheGuard <= 1) { return 0.02f; }
    return 0.02f + (player.StanceOfTheGuard - 1) * 0.02f;
  }

  public static int StanceOfTheGuard_Turn(Character player)
  {
    return 10;
  }

  public static double InvisibleBind(Character player)
  {
    return 1.00f;
  }

  public static int InvibisleBind_Turn(Character player)
  {
    return 2;
  }

  public static int SpiritualRest_Turn(Character player)
  {
    return 9;
  }

  // todo draft
  public static double CircleSlash(Character player)
  {
    return 1.20f;
  }

  public static double MeteorBullet(Character player)
  {
    return 0.80f;
  }
  public static int MeteorBullet_Effect1(Character player)
  {
    if (player.MeteorBullet <= 1) { return 3; }
    return 3 + (player.MeteorBullet - 1);
  }

  public static double BlueBullet(Character player)
  {
    return 0.70f;
  }
  public static int BlueBullet_Effect1(Character player)
  {
    if (player.BlueBullet <= 1) { return 3; }
    return 3 + (player.BlueBullet - 1);
  }

  public static double HolyBreath(Character player)
  {
    if (player.HolyBreath <= 1) { return 3.00f; }
    return 3.00f + (player.HolyBreath - 1) * 0.30f;
  }

  public static double BlackContract(Character plyaer)
  {
    return 0.10f;
  }

  public static int BlackContract_Turn(Character player)
  {
    if (player.BlackContract <= 1) { return 3; }
    return 3 + (player.BlackContract - 1);
  }

  public static double SonicPulse(Character player)
  {
    return 2.00f;
  }

  public static int SonicPulse_Turn(Character player)
  {
    return 3;
  }

  public static double SonicPulse_Value(Character player)
  {
    return 0.70f;
  }

  public static double LandShatter(Character player)
  {
    return 2.20f;
  }

  public static int LandShatter_Turn(Character player)
  {
    return 2;
  }

  public static double ConcussiveHit(Character player)
  {
    if (player.ConcussiveHit <= 1) { return 0.05f; }
    return 0.05f + (player.ConcussiveHit - 1) * 0.01f;
  }

  public static int ConcussiveHit_Turn(Character player)
  {
    return 9;
  }

  public static double EyeOfTheIsshin_Effect1(Character player)
  {
    if (player.EyeOfTheIsshin <= 1) { return 0.20f; }
    return 0.20f + (player.EyeOfTheIsshin - 1) * 0.02f;
  }

  public static int EyeOfTheIsshin_Turn(Character player)
  {
    return 9;
  }

  public static double BoneCrush(Character player)
  {
    return 2.20;
  }

  public static int BoneCrush_Turn(Character player)
  {
    return 9;
  }

  public static double BoneCrush_Value(Character player)
  {
    double result = 0.0f;
    if (player.BoneCrush <= 1) { return 0.80f; }
    result = 0.80f - (player.BoneCrush - 1) * 0.03f;
    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  public static double IrregularStep_Damage(Character player)
  {
    return 2.00f;
  }

  public static float IrregularStep_GaugeStep(Character player)
  {
    return 0.30f;
  }

  public static int SigilOfThePending_Turn(Character player)
  {
    if (player.SigilOfThePending <= 1) { return 3; }
    return 3 + (player.SigilOfThePending - 1) * 2;
  }

  public static int AetherDrive_Turn(Character player)
  {
    return 9;
  }

  public static double AetherDrive_Effect(Character player)
  {
    return 1.10f;
  }

  public static int KillingWave_Turn(Character player)
  {
    return 9;
  }

  public static double KillingWave_Effect(Character player)
  {
    return 0.95f;
  }

  public static double WordOfPower(Character player)
  {
    if (player.WordOfPower <= 1) { return 2.40f; }
    return 2.40f + (player.WordOfPower - 1) * 0.20f;
  }

  public static double DoubleSlash(Character player)
  {
    if (player.DoubleSlash <= 1) { return 1.20f; }
    return 1.20f + (player.DoubleSlash - 1) * 0.10f;
  }

  public static double StormArmor_SpeedUp(Character player)
  {
    return 1.10f;
  }

  public static double StormArmor_Damage(Character player)
  {
    return 1.20f;
  }

  public static int StormArmor_Turn(Character player)
  {
    return 3;
  }

  public static double MuteImpulse(Character player)
  {
    return 1.00f;
  }

  public static double VoiceOfVigor(Character player)
  {
    if (player.VoiceOfVigor <= 1) { return 1.10f; }
    return 1.10f + (player.VoiceOfVigor - 1) * 0.03f;
  }

  public static int VoiceOfVigor_Turn(Character player)
  {
    return 9;
  }

  public static double ShiningHeal(Character player)
  {
    return 4.00f;
  }

  public static int GaleWind_Turn(Character player)
  {
    if (player.GaleWind <= 1) { return 3; }
    return 3 + (player.GaleWind - 1);
  }

  public static double FreezingCube(Character player)
  {
    return 1.60f;
  }

  public static int FreezingCube_Turn(Character player)
  {
    return 9;
  }

  public static double FreezingCube_Effect(Character player)
  {
    if (player.FreezingCube <= 1) { return 1.20f; }
    return 1.20F + (player.FreezingCube - 1) * 0.25f;
  }

  public static double FreezingCube_Effect2(Character player)
  {
    return 1.60f;
  }

  public static double VolcanicBlaze(Character player)
  {
    return 1.80f;
  }

  public static int VolcanicBlaze_Turn(Character player)
  {
    return 9;
  }

  public static double VolcanicBlaze_Effect(Character player)
  {
    if (player.VolcanicBlaze <= 1) { return 1.20f; }
    return 1.20f + (player.VolcanicBlaze - 1) * 0.30f;
  }
  public static double VolcanicBlaze_Effect2(Character player)
  {
    return 1.80f;
  }

  public static double IronBuster(Character player)
  {
    if (player.IronBuster <= 1) { return 2.50f; }
    return 2.50f + (player.IronBuster - 1) * 0.30f;
  }
  public static double IronBuster_2(Character player)
  {
    if (player.IronBuster <= 1) { return 1.50f; }
    return 1.50f + (player.IronBuster - 1) * 0.20f;
  }

  public static double AngelicEcho(Character player)
  {
    if (player.AngelicEcho <= 1) { return 1.50f; }
    return 1.50f + (player.AngelicEcho - 1) * 0.10f;
  }
  public static int AngelicEcho_Turn(Character player)
  {
    return 9;
  }
  public static double AngelicEcho_Effect(Character player)
  {
    if (player.AngelicEcho <= 1) { return 1.50f; }
    return 1.50f + (player.AngelicEcho - 1) * 0.10f;
  }

  public static double CursedEvangile(Character player)
  {
    return 1.20f;
  }

  public static int CursedEvangile_Turn(Character player)
  {
    return 9;
  }

  public static double CursedEvangile_Effect(Character player)
  {
    if (player.CursedEvangile <= 1) { return 4.44f; }
    return 4.44f + (player.CursedEvangile - 1) * 0.74f; // 3段階UPで666を狙った値
  }

  public static int CursedEvangile_SlepTurn(Character player)
  {
    return 9;
  }

  public static double CursedEvangile_SlipFactor(Character player)
  {
    return 1.50f;
  }

  public static double PenetrationArrow(Character player)
  {
    return 2.20f;
  }

  public static int PenetrationArrow_Turn(Character player)
  {
    return 5;
  }

  public static double PenetrationArrow_Effect(Character player)
  {
    return 1.5f;
  }

  public static double PenetrationArrow_Effect2(Character player)
  {
    if (player.PenetrationArrow <= 1) { return 0.70f; }
    return 0.70f - (player.PenetrationArrow - 1) * 0.04f;
  }

  public static int CircleOfTheSerenity_Turn(Character player)
  {
    return 5;
  }

  public static int WillAwakening_Turn(Character player)
  {
    if (player.WillAwakening <= 1) { return 3; }
    return 3 + (player.WillAwakening - 1);
  }

  public static int PhantomOboro_Turn(Character player)
  {
    return 2;
  }

  public static int DeadlyDrive_Turn(Character player)
  {
    return 3;
  }
  public static double DeadlyDrive_Effect1(Character player)
  {
    if (player.DeadlyDrive <= 1) { return 1.05f; }
    return 1.05f + (player.DeadlyDrive - 1) * 0.01f;
  }
  public static double DeadlyDrive_Effect2(Character player)
  {
    if (player.DeadlyDrive <= 1) { return 1.10f; }
    return 1.10f + (player.DeadlyDrive - 1) * 0.02f;
  }
  public static double DeadlyDrive_Effect3(Character player)
  {
    if (player.DeadlyDrive <= 1) { return 1.15f; }
    return 1.15f + (player.DeadlyDrive - 1) * 0.03f;
  }

  public static int DominationField_Turn(Character player)
  {
    return 9;
  }
  public static double DominationField_Effect1(Character player)
  {
    if (player.DominationField <= 1) { return 1.10f; }
    return 1.10f + (player.DominationField - 1) * 0.03f;
  }
  public static double DominationField_Effect2(Character player)
  {
    if (player.DominationField <= 1) { return 0.10f; }
    return 0.10f + (player.DominationField - 1) * 0.02f;
  }

  public static double FlameStrike(Character player)
  {
    if (player.FlameStrike <= 1) { return 3.50f; }
    return 3.50f + (player.FlameStrike - 1) * 0.50f;
  }

  public static int FlameStrike_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double FrostLance(Character player)
  {
    if (player.FrostLance <= 1) { return 3.20f; }
    return 3.20f + (player.FrostLance - 1) * 0.40f;
  }
  public static int FrostLance_Turn(Character player)
  {
    return 3;
  }

  public static int ShiningHeal_Turn(Character player)
  {
    if (player.ShiningHeal <= 1) { return 3; }
    return 3 + (player.ShiningHeal - 1);
  }

  public static double ShiningHeal_Effect1(Character player)
  {
    return 2.00f;
  }

  public static int CircleOfDespair_Turn(Character player)
  {
    return 5;
  }
  public static double CircleOfDespair_Effect1(Character player)
  {
    if (player.CircleOfTheDespair <= 1) { return 0.80f; }
    return 0.80f - (player.CircleOfTheDespair - 1) * 0.03f;
  }

  // MindForce still is not implemented.

  public static int CounterDisallow_Turn(Character player)
  {
    if (player.CounterDisallow <= 1) { return 2; }
    return 2 + (player.CounterDisallow - 1);
  }

  public static double RagingStorm(Character player)
  {
    return 3.00f;
  }

  public static int RagingStorm_Turn(Character player)
  {
    return 3;
  }

  public static double RagingStorm_Effect1(Character player)
  {
    if (player.RagingStorm <= 1) { return 1.10f; }
    return 1.10f + (player.RagingStorm - 1) * 0.10f;
  }

  public static double PrecisionStrike(Character player)
  {
    if (player.PrecisionStrike <= 1) { return 2.50f; }
    return 2.50f + (player.PrecisionStrike - 1) * 0.50f;
  }

  public static double UnintentionalHit(Character player)
  {
    return 2.00f;
  }
  public static int UnintentionalHit_Turn(Character player)
  {
    return 2;
  }
  public static float UnintentionalHit_GaugeStep(Character player)
  {
    return 0.20f;
  }

  public static int EverflowMind_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double EverflowMind_Effect1(Character player)
  {
    if (player.EverflowMind <= 1) { return 0.20f; }
    return 0.20f + (player.EverflowMind - 1) * 0.02f;
  }

  public static double InnerInspiration_Effect1(Character player)
  {
    if (player.InnerInspiration <= 1) { return 0.10f; }
    return 0.10f + (player.InnerInspiration - 1) * 0.10f;
  }

  public static int SeventhPrinciple_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static int CircleOfTheIgnite_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double CircleOfTheIgnite_Effect(Character player)
  {
    if (player.CircleOfTheIgnite <= 1) { return 1.00f; }
    return 1.00f + (player.CircleOfTheIgnite - 1) * 0.10f;
  }

  public static int WaterPresence_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double WaterPresence_Effect(Character player)
  {
    // 半分で固定
    return 0.50f;
  }

  public static double WaterPresence_Effect2(Character player)
  {
    // 半分で固定
    return 0.50f;
  }

  public static int ValkyrieBlade_Turn(Character player)
  {
    return 9;
  }

  public static double ValkyrieBlade_Effect(Character player)
  {
    if (player.ValkyrieBlade <= 1) { return 2.50f; }
    return 2.50f + (player.ValkyrieBlade - 1) * 0.10f;
  }

  public static int ValkyrieScar_Turn(Character player)
  {
    return 5;
  }

  public static int TheDarkIntensity_Turn(Character player)
  {
    if (player.TheDarkIntensity <= 1) { return 5; }
    return 5 + (player.TheDarkIntensity - 1);
  }

  public static double TheDarkIntensity_Effect(Character player)
  {
    return 1.30f;
  }

  public static double TheDarkIntensity_Effect2(Character player)
  {
    return 0.20f;
  }

  public static int FutureVision_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static int DetachmentFault_Turn(Character player)
  {
    if (player.DetachmentFault <= 1) { return 2; }
    return 2 + (player.DetachmentFault - 1);
  }

  public static int StanceoftheIai_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double StanceoftheIai_Effect(Character player)
  {
    if (player.StanceOfTheIai <= 1) { return 2.00f; }
    return 2.00f + (player.StanceOfTheIai - 1) * 0.20f;
  }

  public static double StanceoftheIai_Effect2(Character player)
  {
    return 1.20f;
  }

  public static int OneImmunity_Turn(Character player)
  {
    return 3;
  }

  public static int StanceofMuin_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static int StanceofMuin_Effect(Character player)
  {
    return 5;
  }

  public static int EternalConcentration_Turn(Character player)
  {
    return 9;
  }

  public static double EternalConcentration_Effect(Character player)
  {
    if (player.EternalConcentration <= 1) { return 1.20f; }
    return 1.20f + (player.EternalConcentration - 1) * 0.20f;
  }

  public static int FocusEye_Turn(Character player)
  {
    return 3;
  }

  public static double FocusEye_Effect()
  {
    return 0.20f;
  }

  public static int SigilOfTheFaith_Turn(Character player)
  {
    return 9;
  }

  public static double SigilOfTheFaith_Effect(Character player)
  {
    if (player.SigilOfTheFaith <= 1) { return 1.20f; }
    return 1.20f + (player.SigilOfTheFaith - 1) * 0.10f;
  }

  public static double LavaAnnihilation(Character player)
  {
    if (player.LavaAnnihilation <= 1) { return 5.00f; }
    return 5.00f + (player.LavaAnnihilation - 1) * 1.00f;
  }

  public static int AbsoluteZero_Turn(Character player)
  {
    if (player.AbsoluteZero <= 1) { return 2; }
    return 2 + (player.AbsoluteZero - 1);
  }

  public static int DeathScythe_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double DeathScythe_Effect(Character player)
  {
    return 0.01f;
  }

  public static double KineticSmash_Effect(Character player)
  {
    if (player.KineticSmash <= 1) { return 5.00f; }
    return 5.00f + (player.KineticSmash - 1) * 1.00f;
  }

  public static double Catastrophe(Character player)
  {
    if (player.Catastrophe <= 1) { return 3.50f; }
    return 3.50f + (player.Catastrophe - 1) * 0.50f;
  }

  public static double CarnageRush(Character player)
  {
    return 1.00f;
  }

  public static int CarnageRush_Count(Character player)
  {
    if (player.CarnageRush <= 1) { return 5; }
    return 5 + (player.CarnageRush - 1);
  }

  public static double PiercingArrow(Character player)
  {
    return 4.00f;
  }

  public static int PiercingArrow_Turn(Character player)
  {
    if (player.PiercingArrow <= 1) { return 2; }
    return 2 + (player.PiercingArrow - 1);
  }

  public static int StanceoftheKokoroe_Turn(Character player)
  {
    return 9;
  }

  public static int TimeStop_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double TimeStop_Effect(Character player)
  {
    if (player.TimeStop <= 1) { return 300; }
    return 300 + (player.TimeStop - 1) * 200;
  }

  public static int CostControl(string command_name, int current_cost, Character player)
  {
    int result = current_cost; // デフォルト値は無変換とする。

    if (player == null) { return result; } // 対象を取っていない場合は無変換とする。

    if (command_name == Fix.ENERGY_BOLT)
    {
      if (player != null && player.EnergyBolt > 1)
      {
        result -= (player.EnergyBolt - 1) * 1;
      }
    }

    if (command_name == Fix.DISPEL_MAGIC)
    {
      if (player != null && player.DispelMagic > 1)
      {
        result -= (player.DispelMagic - 1) * 5;
      }
    }

    if (command_name == Fix.ZERO_IMMUNITY)
    {
      if (player != null && player.ZeroImmunity > 1)
      {
        result -= (player.ZeroImmunity - 1) * 5;
      }
    }

    if (command_name == Fix.FLASH_COUNTER)
    {
      if (player != null && player.FlashCounter > 1)
      {
        result -= (player.FlashCounter - 1) * 2;
      }
    }

    if (command_name == Fix.SPIRITUAL_REST)
    {
      if (player != null && player.SpiritualRest > 1)
      {
        result -= (player.SpiritualRest - 1) * 3;
      }
    }

    if (command_name == Fix.UNSEEN_AID)
    {
      if (player != null && player.UnseenAid > 1)
      {
        result -= (player.UnseenAid - 1) * 5;
      }
    }

    if (command_name == Fix.PHANTOM_OBORO)
    {
      if (player != null && player.PhantomOboro > 0)
      {
        result -= (player.PhantomOboro - 1) * 10;
      }
    }

    if (command_name == Fix.CIRCLE_OF_SERENITY)
    {
      if (player != null && player.CircleOfSerenity > 0)
      {
        result -= (player.CircleOfSerenity - 1) * 10;
      }
    }

    if (command_name == Fix.SEVENTH_PRINCIPLE)
    {
      if (player != null && player.SeventhPrinciple > 0)
      {
        result -= (player.SeventhPrinciple - 1) * 10;
      }
    }

    if (command_name == Fix.HARDEST_PARRY)
    {
      if (player != null && player.HardestParry > 0)
      {
        result -= (player.HardestParry - 1) * 5;
      }
    }

    if (result <= 0) { result = 0; }
    return result;
  }

  public static int FactorControl(string command_name, Character player)
  {
    #region "Delve I"
    // 魔法
    if (command_name == Fix.FIRE_BALL) { return (player.FireBall) * 10; }
    if (command_name == Fix.ICE_NEEDLE) { return (player.IceNeedle) * 9; }
    if (command_name == Fix.FRESH_HEAL) { return (player.FreshHeal) * 20; }
    if (command_name == Fix.SHADOW_BLAST) { return (player.ShadowBlast) * 5; }
    if (command_name == Fix.ORACLE_COMMAND) { return (player.OracleCommand) * 10; }
    if (command_name == Fix.ENERGY_BOLT) { return (player.EnergyBolt) * 1; }
    // スキル
    if (command_name == Fix.STRAIGHT_SMASH) { return (player.StraightSmash) * 10; }
    if (command_name == Fix.SHIELD_BASH) { return (player.ShieldBash) * 1; }
    if (command_name == Fix.LEG_STRIKE) { return (player.LegStrike) * 5; }
    if (command_name == Fix.HUNTER_SHOT) { return (player.HunterShot) * 2; }
    if (command_name == Fix.TRUE_SIGHT) { return (player.TrueSight) * 5; }
    if (command_name == Fix.DISPEL_MAGIC) { return (player.DispelMagic) * 5; }
    #endregion

    #region "Delve II"
    // 魔法
    if (command_name == Fix.FLAME_BLADE) { return (player.FlameBlade) * 20; }
    if (command_name == Fix.PURE_PURIFICATION) { return (player.PurePurification) * 10; }
    if (command_name == Fix.DIVINE_CIRCLE) { return (player.DivineCircle) * 30; }
    if (command_name == Fix.BLOOD_SIGN) { return (player.BloodSign) * 20; }
    if (command_name == Fix.FORTUNE_SPIRIT) { return (player.FortuneSpirit) * 1; }
    if (command_name == Fix.FLASH_COUNTER) { return (player.FlashCounter) * 2; }
    // スキル
    if (command_name == Fix.STANCE_OF_THE_BLADE) { return ((player.StanceOfTheBlade) * 5); }
    if (command_name == Fix.STANCE_OF_THE_GUARD) { return (player.StanceOfTheGuard) * 2; }
    if (command_name == Fix.SPEED_STEP) { return (player.SpeedStep) * 3; }
    if (command_name == Fix.MULTIPLE_SHOT) { return (player.MultipleShot) * 10; }
    if (command_name == Fix.LEYLINE_SCHEMA) { return (player.LeylineSchema) * 2; }
    if (command_name == Fix.SPIRITUAL_REST) { return (player.SpiritualRest) * 3; }
    #endregion

    #region "Delve III"
    // 魔法
    if (command_name == Fix.METEOR_BULLET) { return (player.MeteorBullet) * 1; }
    if (command_name == Fix.BLUE_BULLET) { return (player.BlueBullet) * 1; }
    if (command_name == Fix.HOLY_BREATH) { return (player.FreshHeal) * 30; }
    if (command_name == Fix.BLACK_CONTRACT) { return (player.BlackContract) * 1; }
    if (command_name == Fix.WORD_OF_POWER) { return (player.WordOfPower) * 20; }
    if (command_name == Fix.SIGIL_OF_THE_PENDING) { return (player.SigilOfThePending) * 2; }
    // スキル
    if (command_name == Fix.DOUBLE_SLASH) { return (player.DoubleSlash) * 10; }
    if (command_name == Fix.CONCUSSIVE_HIT) { return (player.ConcussiveHit) * 1; }
    if (command_name == Fix.BONE_CRUSH) { return (player.ConcussiveHit) * 3; }
    if (command_name == Fix.EYE_OF_THE_ISSHIN) { return (player.EyeOfTheIsshin) * 2; }
    if (command_name == Fix.VOICE_OF_VIGOR) { return (player.VoiceOfVigor) * 3; }
    if (command_name == Fix.UNSEEN_AID) { return (player.SpiritualRest) * 5; }
    #endregion

    #region "Delve IV"
    // 魔法
    if (command_name == Fix.VOLCANIC_BLAZE) { return (player.VolcanicBlaze) * 30; }
    if (command_name == Fix.FREEZING_CUBE) { return (player.FreezingCube) * 25; }
    if (command_name == Fix.ANGELIC_ECHO) { return (player.AngelicEcho) * 10; }
    if (command_name == Fix.CURSED_EVANGILE) { return (player.CursedEvangile) * 74; }
    if (command_name == Fix.GALE_WIND) { return (player.GaleWind) * 1; }
    if (command_name == Fix.PHANTOM_OBORO) { return (player.PhantomOboro) * 10; }
    // スキル
    if (command_name == Fix.IRON_BUSTER) { return (player.IronBuster) * 30; }
    if (command_name == Fix.DOMINATION_FIELD) { return (player.DominationField) * 3; }
    if (command_name == Fix.DEADLY_DRIVE) { return (player.DeadlyDrive) * 1; }
    if (command_name == Fix.PENETRATION_ARROW) { return (player.PenetrationArrow) * 4; }
    if (command_name == Fix.WILL_AWAKENING) { return (player.WillAwakening) * 1; }
    if (command_name == Fix.CIRCLE_OF_SERENITY) { return (player.CircleOfSerenity) * 10; }
    #endregion

    #region "Delve V"
    // 魔法
    if (command_name == Fix.FLAME_STRIKE) { return (player.FlameStrike) * 50; }
    if (command_name == Fix.FROST_LANCE) { return (player.FrostLance) * 40; }
    if (command_name == Fix.SHINING_HEAL) { return (player.ShiningHeal) * 1; }
    if (command_name == Fix.CIRCLE_OF_THE_DESPAIR) { return (player.CircleOfTheDespair) * 3; }
    if (command_name == Fix.SEVENTH_PRINCIPLE) { return (player.SeventhPrinciple) * 10; }
    if (command_name == Fix.COUNTER_DISALLOW) { return (player.CounterDisallow) * 1; }
    // スキル
    if (command_name == Fix.RAGING_STORM) { return (player.RagingStorm) * 10; }
    if (command_name == Fix.HARDEST_PARRY) { return (player.HardestParry) * 5; }
    if (command_name == Fix.UNINTENTIONAL_HIT) { return (player.UnintentionalHit) * 3; }
    if (command_name == Fix.PRECISION_STRIKE) { return (player.PrecisionStrike) * 50; }
    if (command_name == Fix.EVERFLOW_MIND) { return (player.EverflowMind) * 2; }
    if (command_name == Fix.INNER_INSPIRATION) { return (player.InnerInspiration) * 10; }
    #endregion

    #region "Delve VI"
    // 魔法
    if (command_name == Fix.CIRCLE_OF_THE_IGNITE) { return 0; } // todo 仮
    if (command_name == Fix.WATER_PRESENCE) { return 0; } // todo 仮
    if (command_name == Fix.VALKYRIE_BLADE) { return 0; } // todo 仮
    if (command_name == Fix.THE_DARK_INTENSITY) { return 0; } // todo 仮
    if (command_name == Fix.FUTURE_VISION) { return 0; } // todo 仮
    if (command_name == Fix.DETACHMENT_FAULT) { return 0; } // todo 仮
    // スキル
    if (command_name == Fix.STANCE_OF_THE_IAI) { return 0; } // todo 仮
    if (command_name == Fix.ONE_IMMUNITY) { return 0; } // todo 仮
    if (command_name == Fix.STANCE_OF_MUIN) { return 0; } // todo 仮
    if (command_name == Fix.ETERNAL_CONCENTRATION) { return 0; } // todo 仮
    if (command_name == Fix.SIGIL_OF_THE_FAITH) { return 0; } // todo 仮
    if (command_name == Fix.ZERO_IMMUNITY) { return 0; } // todo 仮
    #endregion

    #region "Delve VII"
    // 魔法
    if (command_name == Fix.LAVA_ANNIHILATION) { return 0; } // todo 仮
    if (command_name == Fix.ABSOLUTE_ZERO) { return 0; } // todo 仮
    if (command_name == Fix.RESURRECTION) { return 0; } // todo 仮
    if (command_name == Fix.DEATH_SCYTHE) { return 0; } // todo 仮
    if (command_name == Fix.GENESIS) { return 0; } // todo 仮
    if (command_name == Fix.TIME_STOP) { return 0; } // todo 仮
    // スキル
    if (command_name == Fix.KINETIC_SMASH) { return 0; } // todo 仮
    if (command_name == Fix.CATASTROPHE) { return 0; } // todo 仮
    if (command_name == Fix.CARNAGE_RUSH) { return 0; } // todo 仮
    if (command_name == Fix.PIERCING_ARROW) { return 0; } // todo 仮
    if (command_name == Fix.STANCE_OF_THE_KOKOROE) { return 0; } // todo 仮
    if (command_name == Fix.TRANSCENDENCE_REACHED) { return 0; } // todo 仮
    #endregion
    return 0; // Factor要素が無い場合は0を返す。
  }

  public static int FactorControl2(string command_name, Character player)
  {
    if (command_name == Fix.PURE_PURIFICATION) { return (player.PurePurification) * 1; }

    if (command_name == Fix.STANCE_OF_THE_BLADE) { return (player.StanceOfTheBlade) * 3; }

    if (command_name == Fix.IRON_BUSTER) { return (player.IronBuster) * 20; }

    if (command_name == Fix.DOMINATION_FIELD) { return (player.DominationField) * 2; }

    if (command_name == Fix.DEADLY_DRIVE) { return (player.DeadlyDrive) * 2; }

    if (command_name == Fix.UNINTENTIONAL_HIT) { return (player.UnintentionalHit) * 3; }

    return 0; // Factor要素が無い場合は0を返す。
  }


  public static int FactorControl3(string command_name, Character player)
  {
    if (command_name == Fix.PURE_PURIFICATION) { return (player.PurePurification) * 1; }

    if (command_name == Fix.STANCE_OF_THE_BLADE) { return (player.StanceOfTheBlade) * 3; }

    if (command_name == Fix.IRON_BUSTER) { return (player.IronBuster) * 20; }

    if (command_name == Fix.DOMINATION_FIELD) { return (player.DominationField) * 2; }

    if (command_name == Fix.DEADLY_DRIVE) { return (player.DeadlyDrive) * 3; }

    if (command_name == Fix.UNINTENTIONAL_HIT) { return (player.UnintentionalHit) * 3; }

    return 0; // Factor要素が無い場合は0を返す。
  }
}
