using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

  public static double CriticalFactor(Character player)
  {
    return 2.00f;
  }

  public static double DefenseFactor(Character player)
  {
    double result = 0.50f;
    if (player.DefenseSkill <= 0) { return result; }

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

    return 2.00f + (player.FireBall - 1) * 0.05f;
  }

  public static double IceNeedle(Character player)
  {
    if (player.IceNeedle <= 1) { return 1.80f; }

    return 1.80f + (player.IceNeedle - 1) * 0.05f;
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
    return 3.00f;
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

    return 2.00f + (player.StraightSmash - 1) * 0.05f;
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
    return 0.80f;
  }

  public static double LegStrike(Character player)
  {
    if (player.LegStrike <= 1) { return 1.80f; }
    return 1.80f + (player.LegStrike - 1) * 0.05f;
  }
  public static int LegStrike_Turn(Character player)
  {
    return 9;
  }
  public static double LegStrike_Value(Character player)
  {
    return 1.20f;
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
    return 1.10f;
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

  public static int OracleCommand(Character player)
  {
    return 100;
  }

  public static double MultipleShot(Character player)
  {
    return 1.20f;
  }

  public static double FlameBlade(Character player)
  {
    return PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * 1.00f;
  }

  public static int FlameBlade_Turn(Character player)
  {
    return 5;
  }

  public static double BloodSign(Character player)
  {
    return PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * 1.00f;
  }

  public static int BloodSign_Turn(Character player)
  {
    return 5;
  }

  public static int DivineCircle(Character player)
  {
    return 150;
  }

  public static int DivineCircle_Turn(Character player)
  {
    return 9;
  }

  public static double FortuneSpirit(Character player)
  {
    return 100.0f;
  }

  public static int FortuneSpirit_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double StanceOfTheBlade(Character player)
  {
    return 0.10f;
  }

  public static int StanceOfTheBlade_Turn(Character player)
  {
    return 10;
  }

  public static double SpeedStep(Character player)
  {
    return 1.10f;
  }
  public static int SpeedStep_Turn(Character player)
  {
    return 5;
  }

  public static double StanceOfTheGuard(Character player)
  {
    return 0.01f;
  }

  public static int StanceOfTheGuard_Turn(Character player)
  {
    return 5;
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

  public static double BlueBullet(Character player)
  {
    return 0.70f;
  }

  public static double HolyBreath(Character player)
  {
    return 3.00f;
  }

  public static double BlackContract(Character plyaer)
  {
    return 0.10f;
  }

  public static int BlackContract_Turn(Character player)
  {
    return 3;
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
    return 0.05f;
  }

  public static int ConcussiveHit_Turn(Character player)
  {
    return 9;
  }

  public static double EyeOfTheIsshin(Character player)
  {
    return 0.20f;
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
    return 0.80f;
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
    return Fix.INFINITY;
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
    return 2.40;
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
    return 1.10f;
  }

  public static int VoiceOfVigor_Turn(Character player)
  {
    return 2;
  }

  public static double ShiningHeal(Character player)
  {
    return 4.00f;
  }

  public static int GaleWind_Turn(Character player)
  {
    return 3;
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
    return 1.20F;
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
    return 1.20f;
  }
  public static double VolcanicBlaze_Effect2(Character player)
  {
    return 1.80f;
  }

  public static double IronBuster(Character player)
  {
    return 2.50f;
  }
  public static double IronBuster_2(Character player)
  {
    return 1.50f;
  }

  public static double AngelicEcho(Character player)
  {
    return 1.50f;
  }
  public static int AngelicEcho_Turn(Character player)
  {
    return 9;
  }
  public static double AngelicEcho_Effect(Character player)
  {
    return 1.50f;
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
    return 4.44f;
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
    return 0.70f;
  }

  public static int CircleOfTheVigor_Turn(Character player)
  {
    return 5;
  }
  public static double CircleOfTheVigor_Effect(Character player)
  {
    return 1.10f;
  }
  public static double CircleOfTheVigor_Effect2(Character player)
  {
    return 1.05f;
  }

  public static int WillAwakening_Turn(Character player)
  {
    return 3;
  }

  public static int PhantomOboro_Turn(Character player)
  {
    return 2;
  }
}
