using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class PrimaryLogic
{
  public enum ValueType
  {
    None,
    Min,
    Max,
    Random,
  }

  /// <summary>
  /// コア・ダメージの算出
  /// </summary>
  private static double CoreDamage(Character player, ValueType type, double min, double max)
  {
    double result = 0.0;
    switch (type)
    {
      case ValueType.Random:
        double sigma = 0.0f;
        double mu = 0.0f;

        // mu
        mu = min + player.TotalMind;

        // sigma
        sigma = (max - min + 1) / 10.0f;
        if (sigma <= 1.0f) { sigma = 1.0f; }

        // 『標準正規累積分布に対する逆関数』により算出される
        result = (Statistics.Distributions.NormInv(AP.Math.RandomReal(), mu, sigma));

        // 下回る場合はmin,上回る場合はmax
        if (result <= min) result = min;
        if (result >= max) result = max;
        break;

      case ValueType.Min:
        result = min;
        break;

      case ValueType.Max:
        result = max;
        break;
    }
    return result;
  }

  /// <summary>
  /// 物理攻撃の算出
  /// </summary>
  public static double PhysicalAttack(Character player, ValueType value_type)
  {
    double min = 1 + player.TotalStrength * Potential(player) * 1.00f;
    double max = 1 + player.TotalStrength * Potential(player) * 1.00f;

    min += (player.MainWeapon?.PhysicalAttack ?? 0);
    min += (player.SubWeapon?.PhysicalAttack ?? 0);
    min += (player.MainArmor?.PhysicalAttack ?? 0);
    min += (player.Accessory1?.PhysicalAttack ?? 0);
    min += (player.Accessory2?.PhysicalAttack ?? 0);
    min += (player.Artifact?.PhysicalAttack ?? 0);

    max += (player.MainWeapon?.PhysicalAttackMax ?? 0);
    max += (player.SubWeapon?.PhysicalAttackMax ?? 0);
    max += (player.MainArmor?.PhysicalAttackMax ?? 0);
    max += (player.Accessory1?.PhysicalAttackMax ?? 0);
    max += (player.Accessory2?.PhysicalAttackMax ?? 0);
    max += (player.Artifact?.PhysicalAttackMax ?? 0);

    double result = 0.0f;
    int debug = 999;
    int debug_min = 999999999;
    int debug_max = 0;
    double debug_avg = 0;
    for (int ii = 0; ii < debug; ii++)
    {
      result = CoreDamage(player, value_type, min, max);
      //Debug.Log("CoreDamage: " + Convert.ToInt32(result).ToString());
      if (debug_min >= result) { debug_min = Convert.ToInt32(result); }
      if (debug_max <= result) { debug_max = Convert.ToInt32(result); }
      debug_avg += result;
    }
    debug_avg /= debug;
    //Debug.Log("AVG: " + Convert.ToInt32(debug_avg).ToString());
    //Debug.Log("MIN: " + Convert.ToInt32(debug_min).ToString());
    //Debug.Log("MAX: " + Convert.ToInt32(debug_max).ToString());

    //    double result = CoreDamage(player, value_type, min, max);

    if (player.IsSyutyuDanzetsu)
    {
      Debug.Log("IsSyutyuDanzetsu detect: " + (1.00f + player.IsSyutyuDanzetsu.EffectValue));
      result *= (1.00f + player.IsSyutyuDanzetsu.EffectValue);
    }

    if (player.IsAuraOfPower)
    {
      result *= player.IsAuraOfPower.EffectValue;
    }

    BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
    if (stanceOfTheBlade)
    {
      result = result * (1.00f + (player.IsStanceOfTheBlade.EffectValue * stanceOfTheBlade.Cumulative));
    }

    if (player.IsPhysicalAttackUp)
    {
      result = result * player.IsPhysicalAttackUp.EffectValue;
    }
    if (player.IsPhysicalAttackDown)
    {
      result = result * player.IsPhysicalAttackDown.EffectValue;
    }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  /// <summary>
  /// 物理防御の算出
  /// </summary>
  public static double PhysicalDefense(Character player)
  {
    double result = 1 + player.TotalStrength * Potential(player) * 0.20f;
    result += (player.MainWeapon?.PhysicalDefense ?? 0);
    result += (player.SubWeapon?.PhysicalDefense ?? 0);
    result += (player.MainArmor?.PhysicalDefense ?? 0);
    result += (player.Accessory1?.PhysicalDefense ?? 0);
    result += (player.Accessory2?.PhysicalDefense ?? 0);
    result += (player.Artifact?.PhysicalDefense ?? 0);

    if (player.IsHunterShot)
    {
      result *= player.IsHunterShot.EffectValue;
    }
    if (player.IsPhysicalDefenseDown)
    {
      double decrease = (1.00f - player.IsPhysicalDefenseDown.EffectValue * player.IsPhysicalDefenseDown.Cumulative);
      if (decrease <= 0.0f) { decrease = 0.0f; }
      result *= decrease;
      Debug.Log("IsPhysicalDefenseDown phase: " + result);
    }

    BuffImage stanceOfTheShield = player.IsStanceOfTheGuard;
    if (stanceOfTheShield)
    {
      result = result * (1.00f + player.IsStanceOfTheGuard.EffectValue * stanceOfTheShield.Cumulative);
    }

    if (player.IsPhysicalDefenseUp)
    {
      result = result * player.IsPhysicalDefenseUp.EffectValue;
    }
    if (player.IsPhysicalDefenseDown)
    {
      result = result * player.IsPhysicalDefenseDown.EffectValue;
    }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  /// <summary>
  /// 魔法攻撃の算出
  /// </summary>
  public static double MagicAttack(Character player, ValueType value_type)
  {
    double min = 1 + player.TotalIntelligence * Potential(player) * 1.00f;
    double max = 1 + player.TotalIntelligence * Potential(player) * 1.00f;

    min += (player.MainWeapon?.MagicAttack ?? 0);
    min += (player.SubWeapon?.MagicAttack ?? 0);
    min += (player.MainArmor?.MagicAttack ?? 0);
    min += (player.Accessory1?.MagicAttack ?? 0);
    min += (player.Accessory2?.MagicAttack ?? 0);
    min += (player.Artifact?.MagicAttack ?? 0);

    max += (player.MainWeapon?.MagicAttackMax ?? 0);
    max += (player.SubWeapon?.MagicAttackMax ?? 0);
    max += (player.MainArmor?.MagicAttackMax ?? 0);
    max += (player.Accessory1?.MagicAttackMax ?? 0);
    max += (player.Accessory2?.MagicAttackMax ?? 0);
    max += (player.Artifact?.MagicAttackMax ?? 0);

    double result = CoreDamage(player, value_type, min, max);

    if (player.IsMagicAttackUp)
    {
      result = result * player.IsMagicAttackUp.EffectValue;
    }
    if (player.IsMagicAttackDown)
    {
      result = result * player.IsMagicAttackDown.EffectValue;
    }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  /// <summary>
  /// 魔法防御の算出
  /// </summary>
  public static double MagicDefense(Character player)
  {
    double result = 1 + player.TotalIntelligence * Potential(player) * 0.20f;
    result += (player.MainWeapon?.MagicDefense ?? 0);
    result += (player.SubWeapon?.MagicDefense ?? 0);
    result += (player.MainArmor?.MagicDefense ?? 0);
    result += (player.Accessory1?.MagicDefense ?? 0);
    result += (player.Accessory2?.MagicDefense ?? 0);
    result += (player.Artifact?.MagicDefense ?? 0);

    if (player.IsSkyShield)
    {
      result *= player.IsSkyShield.EffectValue;
    }
    if (player.IsShadowBlast)
    {
      //Debug.Log("MagicDefense (before): " + result.ToString("F2"));
      result *= player.IsShadowBlast.EffectValue;
      //Debug.Log("MagicDefense (after): effect -> " + player.IsShadowBlast.EffectValue.ToString("F2") + " " + result.ToString("F2"));
    }

    if (player.IsMagicDefenseUp)
    {
      result = result * player.IsMagicDefenseUp.EffectValue;
    }
    if (player.IsMagicDefenseDown)
    {
      result = result * player.IsMagicDefenseDown.EffectValue;
    }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  /// <summary>
  /// 戦闘命中率の算出
  /// </summary>
  public static double BattleAccuracy(Character player)
  {
    double result = 1.00 + Math.Log(Convert.ToInt32(player.TotalAgility), Math.Exp(1)) * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 30.0f;

    result += (player.MainWeapon?.BattleAccuracy ?? 95.0f);

    if (result <= 0.0f) { result = 0.0f; }
    if (result >= 100.0f) { result = 100.0f; }
    return result;

  }

  /// <summary>
  /// 戦闘速度の算出
  /// </summary>
  public static double BattleSpeed(Character player)
  {
    double result = 0.30f + Math.Log(Convert.ToInt32(player.TotalAgility), Math.Exp(1)) * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 30.0f;
    //Debug.Log(player.FullName +  " battlespeed: " + result.ToString());
    result += (player.MainWeapon?.BattleSpeed ?? 0);
    result += (player.SubWeapon?.BattleSpeed ?? 0);
    result += (player.MainArmor?.BattleSpeed ?? 0);
    result += (player.Accessory1?.BattleSpeed ?? 0);
    result += (player.Accessory2?.BattleSpeed ?? 0);
    result += (player.Artifact?.BattleSpeed ?? 0);

    if (player.IsIceNeedle)
    {
      result *= player.IsIceNeedle.EffectValue;
    }
    if (player.IsStormArmor)
    {
      result *= player.IsStormArmor.EffectValue;
    }
    if (player.IsSpeedStep)
    {
      result *= player.IsSpeedStep.EffectValue;
    }
    if (player.IsSlow)
    {
      result *= player.IsSlow.EffectValue;
    }

    if (player.IsBattleSpeedUp)
    {
      result = result * player.IsBattleSpeedUp.EffectValue;
    }
    if (player.IsBattleSpeedDown)
    {
      result = result * player.IsBattleSpeedDown.EffectValue;
    }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  /// <summary>
  /// 戦闘反応の算出
  /// </summary>
  public static double BattleResponse(Character player)
  {
    double result = 1.00f + Math.Log(Convert.ToInt32(player.TotalAgility), Math.Exp(1)) * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 4.0f;
    result += (player.MainWeapon?.BattleResponse ?? 0);
    result += (player.SubWeapon?.BattleResponse ?? 0);
    result += (player.MainArmor?.BattleResponse ?? 0);
    result += (player.Accessory1?.BattleResponse ?? 0);
    result += (player.Accessory2?.BattleResponse ?? 0);
    result += (player.Artifact?.BattleResponse ?? 0);

    if (player.IsBattleReponseUp)
    {
      result = result * player.IsBattleReponseUp.EffectValue;
    }
    if (player.IsBattleResponseDown)
    {
      result = result * player.IsBattleResponseDown.EffectValue;
    }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  /// <summary>
  /// 潜在能力の算出
  /// </summary>
  public static double Potential(Character player)
  {
    double result = 1 + player.TotalMind * 0.01f;
    result += (player.MainWeapon?.Potential ?? 0);
    result += (player.SubWeapon?.Potential ?? 0);
    result += (player.MainArmor?.Potential ?? 0);
    result += (player.Accessory1?.Potential ?? 0);
    result += (player.Accessory2?.Potential ?? 0);
    result += (player.Artifact?.Potential ?? 0);

    if (player.IsPotentialUp)
    {
      result = result * player.IsPotentialUp.EffectValue;
    }
    if (player.IsPotentialDown)
    {
      result = result * player.IsPotentialDown.EffectValue;
    }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }
}
