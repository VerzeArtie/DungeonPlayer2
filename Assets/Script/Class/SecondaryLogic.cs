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
    return 1.20;
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
}
