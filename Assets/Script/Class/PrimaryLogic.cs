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

  public enum SpellSkillType
  {
    None,
    Strength,
    Intelligence,
    Both,
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
        Debug.Log("CoreDamage totalmind " + player.TotalMind);
        Debug.Log("CoreDamage mu        " + mu);
        Debug.Log("CoreDamage min " + min + " max " + max);

        // sigma
        sigma = (max - min + 1) / 10.0f;
        Debug.Log("CoreDamage sigma 1   " + sigma);
        if (sigma <= 1.0f) { sigma = 1.0f; }
        Debug.Log("CoreDamage sigma 2   " + sigma);

        // 『標準正規累積分布に対する逆関数』により算出される
        result = (Statistics.Distributions.NormInv(AP.Math.RandomReal(), mu, sigma));
        Debug.Log("CoreDamage result    " + result);

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
  public static double PhysicalAttack(Character player, ValueType value_type, SpellSkillType spell_skill_type)
  {
    double min = 1;
    double max = 1;
    if (player.IsSeventhPrinciple)
    {
      if (spell_skill_type == SpellSkillType.Strength)
      {
        min += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else if (spell_skill_type == SpellSkillType.Intelligence)
      {
        min += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else if (spell_skill_type == SpellSkillType.Both)
      {
        min += (player.TotalStrength + player.TotalIntelligence) * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += (player.TotalStrength + player.TotalIntelligence) * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else
      {
        min += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
    }
    else
    {
      if (spell_skill_type == SpellSkillType.Strength)
      {
        min += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else if (spell_skill_type == SpellSkillType.Intelligence)
      {
        min += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else if (spell_skill_type == SpellSkillType.Both)
      {
        min += (player.TotalStrength + player.TotalIntelligence) * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += (player.TotalStrength + player.TotalIntelligence) * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else
      {
        min += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
    }

    min += (player.MainWeapon?.PhysicalAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.SubWeapon?.PhysicalAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.MainArmor?.PhysicalAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.Accessory1?.PhysicalAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.Accessory2?.PhysicalAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.Artifact?.PhysicalAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);

    max += (player.MainWeapon?.PhysicalAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.SubWeapon?.PhysicalAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.MainArmor?.PhysicalAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.Accessory1?.PhysicalAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.Accessory2?.PhysicalAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.Artifact?.PhysicalAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);

    double result = 0.0f;
    int debug = 1;
    int debug_min = 999999999;
    int debug_max = 0;
    double debug_avg = 0;
    for (int ii = 0; ii < debug; ii++)
    {
      result = CoreDamage(player, value_type, min, max);
      Debug.Log("CoreDamage min " + min + " max " + max + " result " + result);
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
      double debug_result = result;
      result = result * (1.00f + (player.IsStanceOfTheBlade.EffectValue * stanceOfTheBlade.Cumulative));
      Debug.Log("stanceOfTheBlade detect: " + debug_result.ToString() + " -> " + result);
    }

    BuffImage darkIntensity = player.IsTheDarkIntensity;
    if (darkIntensity)
    {
      double debug_result = result;
      result = result * (darkIntensity.EffectValue + ((double)(darkIntensity.Cumulative - 1) * darkIntensity.EffectValue2));
      Debug.Log("darkIntensity detect: " + debug_result.ToString() + " -> " + result);
    }

    BuffImage deadlyDrive = player.IsDeadlyDrive;
    if (deadlyDrive)
    {
      double diffLife = (double)(player.CurrentLife) / (double)(player.MaxLife);
      if (diffLife <= 0.10f)
      {
        double result_before = result;
        Debug.Log("DeadlyDrive under 10%: " + diffLife.ToString());
        result = result * player.IsDeadlyDrive.EffectValue3;
        Debug.Log("DeadlyDrive under 10% : " + player.IsDeadlyDrive.EffectValue3.ToString("F2") + " " + result_before.ToString("F2") + " -> " + result);
      }
      else if (diffLife <= 0.20f)
      {
        double result_before = result;
        Debug.Log("DeadlyDrive under 20%: " + diffLife.ToString() + " " + result);
        result = result * player.IsDeadlyDrive.EffectValue2;
        Debug.Log("DeadlyDrive under 20% : " + player.IsDeadlyDrive.EffectValue2.ToString("F2") + " " + result_before.ToString("F2") + " -> " + result);
      }
      else if (diffLife <= 0.30f)
      {
        double result_before = result;
        Debug.Log("DeadlyDrive under 30%: " + diffLife.ToString() + " " + result);
        result = result * player.IsDeadlyDrive.EffectValue;
        Debug.Log("DeadlyDrive under 30% : " + player.IsDeadlyDrive.EffectValue.ToString("F2") + " " + result_before.ToString("F2") + " -> " + result);
      }
    }

    BuffImage ragingStorm = player.SearchFieldBuff(Fix.RAGING_STORM);
    if (ragingStorm != null)
    {
      result = result * ragingStorm.EffectValue;
    }

    if (player.IsPhysicalAttackUp)
    {
      Debug.Log("Buff player.IsPhysicalAttackUp (factor) " + player + " " + player.IsPhysicalAttackUp.EffectValue + " " + player.IsPhysicalAttackUp.Cumulative);
      double effect = 1.00 + (player.IsPhysicalAttackUp.EffectValue * player.IsPhysicalAttackUp.Cumulative);
      Debug.Log("Buff player.IsPhysicalAttackUp (before) " + player + " " + result + " : " + effect);
      result = result * effect;
      Debug.Log("Buff player.IsPhysicalAttackUp (after ) " + player + " " + result + " : " + effect);
    }
    if (player.IsPhysicalAttackDown)
    {
      if (player.IsAbsolutePerfection ||
          player.IsGodWill)
      {
        // skip
      }
      else
      {
        double decrease = (1.00f - player.IsPhysicalAttackDown.EffectValue * player.IsPhysicalAttackDown.Cumulative);
        if (decrease <= 0.0f) { decrease = 0.0f; }
        result *= decrease;
        Debug.Log("IsPhysicalAttackDown phase: " + result);
      }
    }
    BuffImage boneCrush = player.IsBoneCrush;
    if (boneCrush)
    {
      double result_before = result;
      result = result * boneCrush.EffectValue;
      Debug.Log("Detect boneCrush: " + result_before + " -> " + result);
    }

    if (player.MainWeapon != null && player.MainWeapon.AmplifyPhysicalAttack > 1.00f) { result = result * player.MainWeapon.AmplifyPhysicalAttack; }
    if (player.SubWeapon != null && player.SubWeapon.AmplifyPhysicalAttack > 1.00f) { result = result * player.SubWeapon.AmplifyPhysicalAttack; }
    if (player.MainArmor != null && player.MainArmor.AmplifyPhysicalAttack > 1.00f) { result = result * player.MainArmor.AmplifyPhysicalAttack; }
    if (player.Accessory1 != null && player.Accessory1.AmplifyPhysicalAttack > 1.00f) { result = result * player.Accessory1.AmplifyPhysicalAttack; }
    if (player.Accessory2 != null && player.Accessory2.AmplifyPhysicalAttack > 1.00f) { result = result * player.Accessory2.AmplifyPhysicalAttack; }
    if (player.Artifact != null && player.Artifact.AmplifyPhysicalAttack > 1.00f) { result = result * player.Artifact.AmplifyPhysicalAttack; }

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

    //if (player.IsHunterShot)
    //{
    //  result *= player.IsHunterShot.EffectValue;
    //}

    BuffImage dominationField = player.SearchFieldBuff(Fix.DOMINATION_FIELD);
    if (dominationField != null)
    {
      result *= dominationField.EffectValue;
    }

    BuffImage concussiveHit = player.IsConcussiveHit;
    if (concussiveHit != null)
    {
      double result_before = result;
      result = result * (1.00f - concussiveHit.EffectValue * concussiveHit.Cumulative);
      if (result <= 0) { result = 0.0f; }
      Debug.Log("Detect concussiveHit: " + concussiveHit.Cumulative + " " + result_before + " -> " + result);
    }

    BuffImage circleOfDespair = player.SearchFieldBuff(Fix.CIRCLE_OF_THE_DESPAIR);
    if (circleOfDespair != null)
    {
      result *= circleOfDespair.EffectValue;
    }

    if (player.IsRockSlum)
    {
      result *= player.IsRockSlum.EffectValue;
    }
    if (player.IsPenetrationArrow)
    {
      Debug.Log("PhysicalDefense( Penetration-Arrow ): " + player.IsPenetrationArrow.EffectValue2.ToString("F2"));
      double result_before = result;
      result *= player.IsPenetrationArrow.EffectValue2;
      Debug.Log("PenetrationArrow detect: " + player.IsPenetrationArrow.EffectValue2.ToString("F2") + " " + result_before.ToString("F2") + " -> " + result.ToString("F2"));
    }

    BuffImage stanceOfTheGuard = player.IsStanceOfTheGuard;
    if (stanceOfTheGuard)
    {
      double debug_result = result;
      result = result * (1.00f + player.IsStanceOfTheGuard.EffectValue * stanceOfTheGuard.Cumulative);
      Debug.Log("stanceOfTheGuard detect: " + debug_result.ToString() + " -> " + result);
    }

    BuffImage darkIntensity = player.IsTheDarkIntensity;
    if (darkIntensity)
    {
      double debug_result = result;
      result = result * (darkIntensity.EffectValue + ((double)(darkIntensity.Cumulative - 1) * darkIntensity.EffectValue2));
      Debug.Log("darkIntensity detect: " + debug_result.ToString() + " -> " + result);
    }

    if (player.IsPhysicalDefenseUp)
    {
      Debug.Log("Buff player.IsPhysicalDefenseUp (factor) " + player + " " + player.IsPhysicalDefenseUp.EffectValue + " " + player.IsPhysicalDefenseUp.Cumulative);
      double effect = 1.00 + (player.IsPhysicalDefenseUp.EffectValue * player.IsPhysicalDefenseUp.Cumulative);
      Debug.Log("Buff player.IsPhysicalDefenseUp (before) " + player + " " + result + " : " + effect);
      result = result * effect;
      Debug.Log("Buff player.IsPhysicalDefenseUp (after ) " + player + " " + result + " : " + effect);
    }
    if (player.IsPhysicalDefenseDown)
    {
      if (player.IsAbsolutePerfection ||
          player.IsGodWill)
      {
        // skip
      }
      else
      {
        double decrease = (1.00f - player.IsPhysicalDefenseDown.EffectValue * player.IsPhysicalDefenseDown.Cumulative);
        if (decrease <= 0.0f) { decrease = 0.0f; }
        result *= decrease;
        Debug.Log("IsPhysicalDefenseDown phase: " + result);
      }
    }

    if (player.MainWeapon != null && player.MainWeapon.AmplifyPhysicalDefense > 1.00f) { result = result * player.MainWeapon.AmplifyPhysicalDefense; }
    if (player.SubWeapon != null && player.SubWeapon.AmplifyPhysicalDefense > 1.00f) { result = result * player.SubWeapon.AmplifyPhysicalDefense; }
    if (player.MainArmor != null && player.MainArmor.AmplifyPhysicalDefense > 1.00f) { result = result * player.MainArmor.AmplifyPhysicalDefense; }
    if (player.Accessory1 != null && player.Accessory1.AmplifyPhysicalDefense > 1.00f) { result = result * player.Accessory1.AmplifyPhysicalDefense; }
    if (player.Accessory2 != null && player.Accessory2.AmplifyPhysicalDefense > 1.00f) { result = result * player.Accessory2.AmplifyPhysicalDefense; }
    if (player.Artifact != null && player.Artifact.AmplifyPhysicalDefense > 1.00f) { result = result * player.Artifact.AmplifyPhysicalDefense; }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  /// <summary>
  /// 魔法攻撃の算出
  /// </summary>
  public static double MagicAttack(Character player, ValueType value_type, SpellSkillType spell_skill_type)
  {
    double min = 1;
    double max = 1;
    if (player.IsSeventhPrinciple)
    {
      if (spell_skill_type == SpellSkillType.Intelligence)
      {
        min += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else if (spell_skill_type == SpellSkillType.Strength)
      {
        min += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else
      {
        min += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
    }
    else
    {
      if (spell_skill_type == SpellSkillType.Intelligence)
      {
        min += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else if (spell_skill_type == SpellSkillType.Strength)
      {
        min += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalStrength * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
      else
      {
        min += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
        max += player.TotalIntelligence * Potential(player) * SecondaryLogic.CoreAttackRate(player);
      }
    }

    min += (player.MainWeapon?.MagicAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.SubWeapon?.MagicAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.MainArmor?.MagicAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.Accessory1?.MagicAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.Accessory2?.MagicAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);
    min += (player.Artifact?.MagicAttack * SecondaryLogic.CoreAttackRate(player) ?? 0);

    max += (player.MainWeapon?.MagicAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.SubWeapon?.MagicAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.MainArmor?.MagicAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.Accessory1?.MagicAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.Accessory2?.MagicAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);
    max += (player.Artifact?.MagicAttackMax * SecondaryLogic.CoreAttackRate(player) ?? 0);

    double result = CoreDamage(player, value_type, min, max);

    if (player.objFieldPanel != null)
    {
      BuffImage[] buffList = player.objFieldPanel.GetComponentsInChildren<BuffImage>();
      for (int ii = 0; ii < buffList.Length; ii++)
      {
        if (buffList[ii].BuffName == Fix.DARKNESS_CIRCLE)
        {
          Debug.Log("Potential Value up cause DarknessCircle(before): " + result);
          result = result * buffList[ii].EffectValue;
          Debug.Log("Potential Value up cause DarknessCircle(after ): " + result);
        }
      }
    }

    if (player.objFieldPanel != null)
    {
      BuffImage[] buffList = player.objFieldPanel.GetComponentsInChildren<BuffImage>();
      for (int ii = 0; ii < buffList.Length; ii++)
      {
        if (buffList[ii].BuffName == Fix.AETHER_DRIVE)
        {
          Debug.Log("Potential Value up cause AetherDrive(before): " + result);
          result = result * buffList[ii].EffectValue;
          Debug.Log("Potential Value up cause AetherDrive(after ): " + result);
          break;
        }
      }
    }

    BuffImage ragingStorm = player.SearchFieldBuff(Fix.RAGING_STORM);
    if (ragingStorm != null)
    {
      result = result * ragingStorm.EffectValue;
    }

    if (player.IsMagicAttackUp)
    {
      Debug.Log("Buff player.IsMagicAttackUp (factor) " + player + " " + player.IsMagicAttackUp.EffectValue + " " + player.IsMagicAttackUp.Cumulative);
      double effect = 1.00 + (player.IsMagicAttackUp.EffectValue * player.IsMagicAttackUp.Cumulative);
      Debug.Log("Buff player.IsMagicAttackUp (before) " + player + " " + result + " : " + effect);
      result = result * effect;
      Debug.Log("Buff player.IsMagicAttackUp (after ) " + player + " " + result + " : " + effect);
    }
    if (player.IsMagicAttackDown)
    {
      if (player.IsAbsolutePerfection ||
          player.IsGodWill)
      {
        // skip
      }
      else
      {
        double decrease = (1.00f - player.IsMagicAttackDown.EffectValue * player.IsMagicAttackDown.Cumulative);
        if (decrease <= 0.0f) { decrease = 0.0f; }
        result *= decrease;
        Debug.Log("IsMagicAttackDown phase: " + result);
      }
    }

    if (player.MainWeapon != null && player.MainWeapon.AmplifyMagicAttack > 1.00f) { result = result * player.MainWeapon.AmplifyMagicAttack; }
    if (player.SubWeapon != null && player.SubWeapon.AmplifyMagicAttack > 1.00f) { result = result * player.SubWeapon.AmplifyMagicAttack; }
    if (player.MainArmor != null && player.MainArmor.AmplifyMagicAttack > 1.00f) { result = result * player.MainArmor.AmplifyMagicAttack; }
    if (player.Accessory1 != null && player.Accessory1.AmplifyMagicAttack > 1.00f) { result = result * player.Accessory1.AmplifyMagicAttack; }
    if (player.Accessory2 != null && player.Accessory2.AmplifyMagicAttack > 1.00f) { result = result * player.Accessory2.AmplifyMagicAttack; }
    if (player.Artifact != null && player.Artifact.AmplifyMagicAttack > 1.00f) { result = result * player.Artifact.AmplifyMagicAttack; }

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

    BuffImage dominationField = player.SearchFieldBuff(Fix.DOMINATION_FIELD);
    if (dominationField != null)
    {
      result *= dominationField.EffectValue;
    }
    BuffImage circleOfDespair = player.SearchFieldBuff(Fix.CIRCLE_OF_THE_DESPAIR);
    if (circleOfDespair != null)
    {
      result *= circleOfDespair.EffectValue;
    }

    if (player.IsShadowBlast)
    {
      //Debug.Log("MagicDefense (before): " + result.ToString("F2"));
      result *= player.IsShadowBlast.EffectValue;
      //Debug.Log("MagicDefense (after): effect -> " + player.IsShadowBlast.EffectValue.ToString("F2") + " " + result.ToString("F2"));
    }

    if (player.IsMagicDefenseUp)
    {
      Debug.Log("Buff player.IsMagicDefenseUp (factor) " + player + " " + player.IsMagicDefenseUp.EffectValue + " " + player.IsMagicDefenseUp.Cumulative);
      double effect = 1.00 + (player.IsMagicDefenseUp.EffectValue * player.IsMagicDefenseUp.Cumulative);
      Debug.Log("Buff player.IsMagicDefenseUp (before) " + player + " " + result + " : " + effect);
      result = result * effect;
      Debug.Log("Buff player.IsMagicDefenseUp (after ) " + player + " " + result + " : " + effect);
    }
    if (player.IsMagicDefenseDown)
    {
      if (player.IsAbsolutePerfection ||
          player.IsGodWill)
      {
        // skip
      }
      else
      {
        double decrease = (1.00f - player.IsMagicDefenseDown.EffectValue * player.IsMagicDefenseDown.Cumulative);
        if (decrease <= 0.0f) { decrease = 0.0f; }
        result *= decrease;
        Debug.Log("IsMagicDefenseDown phase: " + result);
      }
    }

    if (player.MainWeapon != null && player.MainWeapon.AmplifyMagicDefense > 1.00f) { result = result * player.MainWeapon.AmplifyMagicDefense; }
    if (player.SubWeapon != null && player.SubWeapon.AmplifyMagicDefense > 1.00f) { result = result * player.SubWeapon.AmplifyMagicDefense; }
    if (player.MainArmor != null && player.MainArmor.AmplifyMagicDefense > 1.00f) { result = result * player.MainArmor.AmplifyMagicDefense; }
    if (player.Accessory1 != null && player.Accessory1.AmplifyMagicDefense > 1.00f) { result = result * player.Accessory1.AmplifyMagicDefense; }
    if (player.Accessory2 != null && player.Accessory2.AmplifyMagicDefense > 1.00f) { result = result * player.Accessory2.AmplifyMagicDefense; }
    if (player.Artifact != null && player.Artifact.AmplifyMagicDefense > 1.00f) { result = result * player.Artifact.AmplifyMagicDefense; }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }

  /// <summary>
  /// 戦闘命中率の算出
  /// </summary>
  public static double BattleAccuracy(Character player)
  {
    double result = 1.00 + Math.Log(Convert.ToInt32(player.TotalAgility), Math.Exp(1)) * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 30.0f;

    result += (player.MainWeapon?.BattleAccuracy ?? 90.0f);

    if (player.IsDizzy)
    {
      if (player.IsAbsolutePerfection ||
          player.IsGodWill)
      {
        // skip
      }
      else
      {
        result = result * player.IsDizzy.EffectValue;
      }
    }

    if (player.MainWeapon != null && player.MainWeapon.AmplifyBattleAccuracy > 1.00f) { result = result * player.MainWeapon.AmplifyBattleAccuracy; }
    if (player.SubWeapon != null && player.SubWeapon.AmplifyBattleAccuracy > 1.00f) { result = result * player.SubWeapon.AmplifyBattleAccuracy; }
    if (player.MainArmor != null && player.MainArmor.AmplifyBattleAccuracy > 1.00f) { result = result * player.MainArmor.AmplifyBattleAccuracy; }
    if (player.Accessory1 != null && player.Accessory1.AmplifyBattleAccuracy > 1.00f) { result = result * player.Accessory1.AmplifyBattleAccuracy; }
    if (player.Accessory2 != null && player.Accessory2.AmplifyBattleAccuracy > 1.00f) { result = result * player.Accessory2.AmplifyBattleAccuracy; }
    if (player.Artifact != null && player.Artifact.AmplifyBattleAccuracy > 1.00f) { result = result * player.Artifact.AmplifyBattleAccuracy; }

    if (result <= 0.0f) { result = 0.0f; }
    if (result >= 100.0f) { result = 100.0f; }
    return result;
  }

  /// <summary>
  /// 戦闘速度の算出
  /// </summary>
  public static double BattleSpeed(Character player)
  {
    double factor = 0.01f; // 速度は0.00以下にならないようにする。
    if (player.TotalAgility <= 100)
    {
      factor = 1.00f + 1.00f / 100.00f * player.TotalAgility;
    }
    else if (player.TotalAgility <= 1000)
    {
      factor = 2.00f + 1.00f / 1000.00f * player.TotalAgility;
    }
    else if (player.TotalAgility <= 9999)
    {
      factor = 3.00f + 1.00f / 10000.00f * player.TotalAgility;
    }
    else
    {
      factor = 4.00f + 1.00f / 100000.00f * player.TotalAgility;
    }
    double core = Math.Exp((double)player.TotalMind / Fix.PARAMETER_MAX);

    double result = factor * core;
    Debug.Log(player.FullName + " factor: " + factor.ToString());
    Debug.Log(player.FullName + " core: " + factor.ToString());
    Debug.Log(player.FullName +  " battlespeed: " + result.ToString());

    result += (player.MainWeapon?.BattleSpeed ?? 0);
    result += (player.SubWeapon?.BattleSpeed ?? 0);
    result += (player.MainArmor?.BattleSpeed ?? 0);
    result += (player.Accessory1?.BattleSpeed ?? 0);
    result += (player.Accessory2?.BattleSpeed ?? 0);
    result += (player.Artifact?.BattleSpeed ?? 0);

    if (player.IsLegStrike)
    {
      result *= player.IsLegStrike.EffectValue;
    }
    if (player.IsIceNeedle)
    {
      result *= player.IsIceNeedle.EffectValue;
    }
    if (player.IsStormArmor)
    {
      result *= player.IsStormArmor.EffectValue;
    }
    if (player.IsSlow)
    {
      if (player.IsAbsolutePerfection)
      {
        // skip
      }
      else
      {
        result *= player.IsSlow.EffectValue;
      }
    }

    if (player.IsBattleSpeedUp)
    {
      Debug.Log("Buff player.IsBattleSpeedUp (factor) " + player + " " + player.IsBattleSpeedUp.EffectValue + " " + player.IsBattleSpeedUp.Cumulative);
      double effect = 1.00 + (player.IsBattleSpeedUp.EffectValue * player.IsBattleSpeedUp.Cumulative);
      Debug.Log("Buff player.IsBattleSpeedUp (before) " + player + " " + result + " : " + effect);
      result = result * effect;
      Debug.Log("Buff player.IsBattleSpeedUp (after ) " + player + " " + result + " : " + effect);
    }
    if (player.IsBattleSpeedDown)
    {
      if (player.IsAbsolutePerfection ||
          player.IsGodWill)
      {
        // skip
      }
      else
      {
        double decrease = (1.00f - player.IsBattleSpeedDown.EffectValue * player.IsBattleSpeedDown.Cumulative);
        if (decrease <= 0.0f) { decrease = 0.0f; }
        result *= decrease;
        Debug.Log("IsBattleSpeedDown phase: " + result);
      }
    }

    BuffImage buffImage = player.IsLightThunderbolt;
    if (buffImage)
    {
      result = result * (1.00f - buffImage.EffectValue * buffImage.Cumulative);
    }

    if (player.MainWeapon != null && player.MainWeapon.AmplifyBattleSpeed > 1.00f) { result = result * player.MainWeapon.AmplifyBattleSpeed; }
    if (player.SubWeapon != null && player.SubWeapon.AmplifyBattleSpeed > 1.00f) { result = result * player.SubWeapon.AmplifyBattleSpeed; }
    if (player.MainArmor != null && player.MainArmor.AmplifyBattleSpeed > 1.00f) { result = result * player.MainArmor.AmplifyBattleSpeed; }
    if (player.Accessory1 != null && player.Accessory1.AmplifyBattleSpeed > 1.00f) { result = result * player.Accessory1.AmplifyBattleSpeed; }
    if (player.Accessory2 != null && player.Accessory2.AmplifyBattleSpeed > 1.00f) { result = result * player.Accessory2.AmplifyBattleSpeed; }
    if (player.Artifact != null && player.Artifact.AmplifyBattleSpeed > 1.00f) { result = result * player.Artifact.AmplifyBattleSpeed; }

    if (result <= 0.0f) { result = 0.0f; }
    // Debug.Log(player.FullName + " battlespeed2: " + result.ToString());
    return result;
  }

  /// <summary>
  /// 戦闘反応の算出
  /// </summary>
  public static double BattleResponse(Character player)
  {
    // double result = 1.00f + Math.Log(Convert.ToInt32(player.TotalAgility), Math.Exp(1)) * Math.Log(Convert.ToInt32(player.TotalMind), Math.Exp(1)) / 4.0f;
    double factor = Math.Log((double)(player.TotalAgility) * (double)(player.TotalMind), Math.Exp(1)) / Math.Log(Fix.PARAMETER_MAX * Fix.PARAMETER_MAX, Math.Exp(1));
    // Debug.Log(player.FullName + " factor: " + factor.ToString());
    double result = 1.00f + factor * 4.00f; // 1.00fがベース値。最大Agility9999、Mind9999の場合 +4.00fで、総合計は5.00fまで。

    result += (player.MainWeapon?.BattleResponse ?? 0);
    result += (player.SubWeapon?.BattleResponse ?? 0);
    result += (player.MainArmor?.BattleResponse ?? 0);
    result += (player.Accessory1?.BattleResponse ?? 0);
    result += (player.Accessory2?.BattleResponse ?? 0);
    result += (player.Artifact?.BattleResponse ?? 0);

    if (player.IsAirCutter)
    {
      result = result * player.IsAirCutter.EffectValue;
    }
    if (player.IsSpeedStep)
    {
      result = result * (1.00f + player.IsSpeedStep.EffectValue * player.IsSpeedStep.Cumulative);
    }
    BuffImage stanceOftheIai = player.IsStanceOfTheIai;
    if (stanceOftheIai)
    {
      result = result * stanceOftheIai.EffectValue2;
    }

    if (player.IsBattleReponseUp)
    {
      Debug.Log("Buff player.IsBattleReponseUp (factor) " + player + " " + player.IsBattleReponseUp.EffectValue + " " + player.IsBattleReponseUp.Cumulative);
      double effect = 1.00 + (player.IsBattleReponseUp.EffectValue * player.IsBattleReponseUp.Cumulative);
      Debug.Log("Buff player.IsBattleReponseUp (before) " + player + " " + result + " : " + effect);
      result = result * effect;
      Debug.Log("Buff player.IsBattleReponseUp (after ) " + player + " " + result + " : " + effect);
    }
    if (player.IsBattleResponseDown)
    {
      if (player.IsAbsolutePerfection ||
          player.IsGodWill)
      {
        // skip
      }
      else
      {
        double decrease = (1.00f - player.IsBattleResponseDown.EffectValue * player.IsBattleResponseDown.Cumulative);
        if (decrease <= 0.0f) { decrease = 0.0f; }
        result *= decrease;
        Debug.Log("IsBattleResponseDown phase: " + result);
      }
    }
    BuffImage circleOfDespair = player.SearchFieldBuff(Fix.CIRCLE_OF_THE_DESPAIR);
    if (circleOfDespair != null)
    {
      result *= circleOfDespair.EffectValue;
    }

    BuffImage buffImage = player.IsLightThunderbolt;
    if (buffImage)
    {
      result = result * (1.00f - buffImage.EffectValue2 * buffImage.Cumulative);
    }

    if (player.MainWeapon != null && player.MainWeapon.AmplifyBattleResponse > 1.00f) { result = result * player.MainWeapon.AmplifyBattleResponse; }
    if (player.SubWeapon != null && player.SubWeapon.AmplifyBattleResponse > 1.00f) { result = result * player.SubWeapon.AmplifyBattleResponse; }
    if (player.MainArmor != null && player.MainArmor.AmplifyBattleResponse > 1.00f) { result = result * player.MainArmor.AmplifyBattleResponse; }
    if (player.Accessory1 != null && player.Accessory1.AmplifyBattleResponse > 1.00f) { result = result * player.Accessory1.AmplifyBattleResponse; }
    if (player.Accessory2 != null && player.Accessory2.AmplifyBattleResponse > 1.00f) { result = result * player.Accessory2.AmplifyBattleResponse; }
    if (player.Artifact != null && player.Artifact.AmplifyBattleResponse > 1.00f) { result = result * player.Artifact.AmplifyBattleResponse; }

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

    if (player.objFieldPanel != null)
    {
      BuffImage[] buffList = player.objFieldPanel.GetComponentsInChildren<BuffImage>();
      for (int ii = 0; ii < buffList.Length; ii++)
      {
        if (buffList[ii].BuffName == Fix.AETHER_DRIVE)
        {
          Debug.Log("Potential Value up cause AetherDrive(before): " + result);
          result = result * buffList[ii].EffectValue;
          Debug.Log("Potential Value up cause AetherDrive(after ): " + result);
          break;
        }
      }
    }

    if (player.IsTrueSight)
    {
      result *= player.IsTrueSight.EffectValue;
    }

    BuffImage sphereOfGlory = player.IsSphereOfGlory;
    if (sphereOfGlory)
    {
      result = result * (1.00f + sphereOfGlory.EffectValue * sphereOfGlory.Cumulative);
    }

    if (player.IsPotentialUp)
    {
      Debug.Log("Buff player.IsPotentialUp (factor) " + player + " " + player.IsPotentialUp.EffectValue + " " + player.IsPotentialUp.Cumulative);
      double effect = 1.00 + (player.IsPotentialUp.EffectValue * player.IsPotentialUp.Cumulative);
      Debug.Log("Buff player.IsPotentialUp (before) " + player + " " + result + " : " + effect);
      result = result * effect;
      Debug.Log("Buff player.IsPotentialUp (after ) " + player + " " + result + " : " + effect);
    }
    if (player.IsPotentialDown)
    {
      if (player.IsAbsolutePerfection ||
          player.IsGodWill)
      {
        // skip
      }
      else
      {
        double decrease = (1.00f - player.IsPotentialDown.EffectValue * player.IsPotentialDown.Cumulative);
        if (decrease <= 0.0f) { decrease = 0.0f; }
        result *= decrease;
        Debug.Log("IsPotentialDown phase: " + result);
      }
    }

    if (player.MainWeapon != null && player.MainWeapon.AmplifyPotential > 1.00f) { result = result * player.MainWeapon.AmplifyPotential; }
    if (player.SubWeapon != null && player.SubWeapon.AmplifyPotential > 1.00f) { result = result * player.SubWeapon.AmplifyPotential; }
    if (player.MainArmor != null && player.MainArmor.AmplifyPotential > 1.00f) { result = result * player.MainArmor.AmplifyPotential; }
    if (player.Accessory1 != null && player.Accessory1.AmplifyPotential > 1.00f) { result = result * player.Accessory1.AmplifyPotential; }
    if (player.Accessory2 != null && player.Accessory2.AmplifyPotential > 1.00f) { result = result * player.Accessory2.AmplifyPotential; }
    if (player.Artifact != null && player.Artifact.AmplifyPotential > 1.00f) { result = result * player.Artifact.AmplifyPotential; }

    if (result <= 0.0f) { result = 0.0f; }
    return result;
  }
}
