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
    return 0.50f;
  }

  public static double FireBolt(Character player)
  {
    return 2.00f;
  }

  public static double IceNeedle(Character player)
  {
    return 1.50f;
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
    return 10;
  }
  public static double ShadowBlast_Value(Character player)
  {
    return 0.80f;
  }

  public static int AuraOfPower_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double AuraOfPower_Value(Character player)
  {
    return 1.20f;
  }

  public static int SkyShield_Turn(Character player)
  {
    return Fix.INFINITY;
  }

  public static double SkyShield_Value(Character player)
  {
    return 1.20f;
  }

  public static double StraightSmash(Character player)
  {
    return 2.00f;
  }

  public static double ShieldBash(Character player)
  {
    return 1.00f;
  }
  public static int ShieldBash_Turn(Character player)
  {
    return 1;
  }

  public static double HunterShot(Character player)
  {
    return 1.50f;
  }
  public static int HunterShot_Turn(Character player)
  {
    return 10;
  }
  public static double HunterShot_Value(Character player)
  {
    return 0.80f;
  }

  public static double VenomSlash(Character player)
  {
    return 1.50f;
  }
  public static double VenomSlash_2(Character player)
  {
    return PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * 0.50f;
  }
  public static int VenomSlash_Turn(Character player)
  {
    return 3;
  }

  public static double HeartOfLife(Character player)
  {
    return PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * 1.00f;
  }

  public static int HeartOfLife_Turn(Character player)
  {
    return 3;
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
    return PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * 1.00f;
  }

  public static int FlameBlade_Turn(Character player)
  {
    return 5;
  }

  public static double BloodSign(Character player)
  {
    return PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * 1.00f;
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
    return 10;
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
    return 0.02f;
  }

  public static int StanceOfTheBlade_Turn(Character player)
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
    return 10;
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

  public static double BlackContract_Turn(Character player)
  {
    return 3;
  }

  public static double ConcussiveHit(Character player)
  {
    return 0.05f;
  }

  public static int ConcussiveHit_Turn(Character player)
  {
    return 10;
  }
}
