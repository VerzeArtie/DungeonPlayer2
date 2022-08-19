using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using TMPro;
using UnityEngine;

public partial class BattleEnemy : MotherBase
{
  public enum CriticalType
  {
    None,
    Random,
    Absolute,
  }

  private double DamageFromCommand(Character player, string command_name)
  {
    double result = 0;
    if (command_name == Fix.NORMAL_ATTACK)
    {
      result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.NormalAttack(player);
    }
    else if (command_name == Fix.MAGIC_ATTACK)
    {
      result = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.MagicAttack(player);
    }
    else if (command_name == Fix.FIRE_BALL)
    {
      result = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.FireBall(player);
    }
    else if (command_name == Fix.ICE_NEEDLE)
    {
      result = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.IceNeedle(player);
    }
    else if (command_name == Fix.SHADOW_BLAST)
    {
      result = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.ShadowBlast(player);
    }
    else if (command_name == Fix.STRAIGHT_SMASH)
    {
      result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.StraightSmash(player);
    }
    else if (command_name == Fix.LEG_STRIKE)
    {
      result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.LegStrike(player);
    }
    else if (command_name == Fix.SHIELD_BASH)
    {
      result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.ShieldBash(player);
    }
    else if (command_name == Fix.HUNTER_SHOT)
    {
      result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.HunterShot(player);
    }
    else if (command_name == Fix.VENOM_SLASH)
    {
      result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.VenomSlash(player);
    }
    else if (command_name == Fix.MULTIPLE_SHOT)
    {
      result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.MultipleShot(player);
    }
    //else if (command_name == Fix.CIRCLE_SLASH)
    //{
    //  result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.CircleSlash(player);
    //}
    else if (command_name == Fix.DOUBLE_SLASH)
    {
      result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.NormalAttack(player);
    }

    return result;
  }

  /// <summary>
  /// 基本ロジックを内包した物理攻撃実行コマンド
  /// </summary>
  private bool ExecNormalAttack(Character player, Character target, double magnify, CriticalType critical, int animation_speed = MAX_ANIMATION_TIME)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    // ターゲットが既に死んでいる場合
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // 回避判定 (ターゲットへの命中率、ターゲットからの回避率、他効果などでaccuracyを決定)
    // 0.0fなら必ず回避される。 100.0fなら必ず当たる。
    double accuracy = PrimaryLogic.BattleAccuracy(player);
    Debug.Log("PrimaryLogic.BattleAccuracy: " + accuracy.ToString("F2"));

    if (target.EvadingSkill > 0)
    {
      accuracy = accuracy * SecondaryLogic.EvadingSkill(target);
    }
    if (accuracy <= 0) accuracy = 0;

    int accuracyValue = AP.Math.RandomInteger(100);
    Debug.Log("Accuracy Value: " + accuracyValue.ToString() + " " + accuracy.ToString("F2"));
    if (accuracyValue > (int)accuracy)
    {
      Debug.Log("Accuracy miss, then no ExecNormalAttack.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // 攻撃コマンドのダメージを算出
    bool resultCritical = false;
    double damageValue = PhysicalDamageLogic(player, target, magnify, Fix.DamageSource.Physical, critical, ref resultCritical);

    // ディバイン・フィールドによる効果
    BuffField panelField = GetPanelFieldFromPlayer(target);
    if (panelField != null)
    {
      BuffImage buffImage = PreCheckFieldEffect(panelField.gameObject, Fix.DIVINE_CIRCLE);
      if (buffImage != null)
      {
        Debug.Log("DivineShiled: " + player.FullName + " -> " + damageValue.ToString("F2") + " " + buffImage.EffectValue.ToString("F2"));
        buffImage.EffectValue -= damageValue;
        StartAnimationGroupPanel(buffImage.gameObject, Fix.BATTLE_DIVINE + "\r\n " + (int)(buffImage.EffectValue), Fix.COLOR_NORMAL);
        if (buffImage.EffectValue <= 0)
        {
          buffImage.RemoveBuff();
        }
        return false; // ディバイン・フィールドで吸収された場合はヒットしたことにならない。
      }
    }

    // ダメージ適用
    ApplyDamage(player, target, damageValue, resultCritical, animation_speed);

    // 追加効果
    if (player.IsFlameBlade && player.Dead == false)
    {
      bool resultCritical2 = false;
      double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.MagicAttack(player), Fix.DamageSource.Fire, critical, ref resultCritical2);
      ApplyDamage(player, target, addDamageValue, resultCritical2, animation_speed);
    }
    BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
    if (stanceOfTheBlade != null)
    {
      stanceOfTheBlade.Cumulative++;
    }
    BuffImage stanceOfTheGuard = target.IsStanceOfTheGuard;
    if (target.IsStanceOfTheGuard && target.IsDefense && target.Dead == false)
    {
      stanceOfTheGuard.Cumulative++;
    }
    if (player.MainWeapon != null && (player.MainWeapon.ItemName == Fix.SWORD_OF_LIFE))
    {
      double effectValue = player.MainWeapon.ItemValue1 + AP.Math.RandomInteger(player.MainWeapon.ItemValue2 - player.MainWeapon.ItemValue1);
      AbstractHealCommand(player, player, effectValue);
    }
    return true;
  }

  /// <summary>
  /// 基本ロジックを内包した魔法攻撃実行コマンド
  /// </summary>
  private bool ExecMagicAttack(Character player, Character target, double magnify, Fix.DamageSource attr, CriticalType critical, int animation_speed = MAX_ANIMATION_TIME)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    // ターゲットが既に死んでいる場合
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL, animation_speed);
      this.NowAnimationMode = true;
      return false;
    }

    // 回避判定 (ターゲットへの命中率、ターゲットからの回避率、他効果などでaccuracyを決定)
    // 0.0fなら必ず回避される。 100.0fなら必ず当たる。
    double accuracy = PrimaryLogic.BattleAccuracy(player);
    Debug.Log("PrimaryLogic.BattleAccuracy: " + accuracy.ToString("F2"));
    if (target.EvadingSkill > 0)
    {
      accuracy = accuracy * SecondaryLogic.EvadingSkill(target);
    }
    if (accuracy <= 0) accuracy = 0;

    int accuracyValue = AP.Math.RandomInteger(100);
    Debug.Log("Accuracy Value: " + accuracyValue.ToString() + " " + accuracy.ToString("F2"));
    if (accuracyValue > (int)accuracy)
    {
      Debug.Log("Accuracy miss, then no ExecMagicAttack.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // 攻撃コマンドのダメージを算出
    bool resultCritical = false;
    double damageValue = MagicDamageLogic(player, target, magnify, attr, critical, ref resultCritical);

    // ディバイン・フィールドによる効果
    BuffField panelField = GetPanelFieldFromPlayer(target);
    if (panelField != null)
    {
      BuffImage buffImage = PreCheckFieldEffect(panelField.gameObject, Fix.DIVINE_CIRCLE);
      if (buffImage != null)
      {
        Debug.Log("DivineShiled: " + player.FullName + " -> " + damageValue.ToString("F2") + " " + buffImage.EffectValue.ToString("F2"));
        buffImage.EffectValue -= damageValue;
        StartAnimationGroupPanel(buffImage.gameObject, Fix.BATTLE_DIVINE + "\r\n " + (int)(buffImage.EffectValue), Fix.COLOR_NORMAL);
        if (buffImage.EffectValue <= 0)
        {
          buffImage.RemoveBuff();
        }
        return false; // ディバイン・フィールドで吸収された場合はヒットしたことにならない。
      }
    }

    // ダメージ適用
    ApplyDamage(player, target, damageValue, resultCritical, animation_speed);

    // 追加効果
    if (player.IsStormArmor && player.Dead == false)
    {
      bool resultCritical2 = false;
      double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.StormArmor_Damage(player), Fix.DamageSource.Wind, critical, ref resultCritical2);
      ApplyDamage(player, target, addDamageValue, resultCritical2, animation_speed);
    }
    BuffImage stanceOfTheGuard = target.IsStanceOfTheGuard;
    if (target.IsStanceOfTheGuard && target.IsDefense && target.Dead == false)
    {
      stanceOfTheGuard.Cumulative++;
    }

    return true;
  }

  private void ExecFireBall(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    ExecMagicAttack(player, target, SecondaryLogic.FireBall(player), Fix.DamageSource.Fire, critical);
  }

  private void ExecIceNeedle(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.IceNeedle(player), Fix.DamageSource.Ice, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.ICE_NEEDLE, SecondaryLogic.IceNeedle_Turn(player), SecondaryLogic.IceNeedle_Value(player), 0);
      StartAnimation(target.objGroup.gameObject, Fix.ICE_NEEDLE, Fix.COLOR_NORMAL);
    }
  }

  private void ExecFreshHeal(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.FreshHeal(player);
    AbstractHealCommand(player, target, healValue);
  }

  private void ExecShadowBlast(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.ShadowBlast(player), Fix.DamageSource.DarkMagic, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.SHADOW_BLAST, SecondaryLogic.ShadowBlast_Turn(player), SecondaryLogic.ShadowBlast_Value(player), 0);
      StartAnimation(target.objGroup.gameObject, Fix.SHADOW_BLAST, Fix.COLOR_NORMAL);
    }
  }

  private void ExecAirCutter(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.AirCutter(player), Fix.DamageSource.Wind, critical);
    if (success)
    {
      player.objBuffPanel.AddBuff(prefab_Buff, Fix.AIR_CUTTER, SecondaryLogic.AirCutter_Turn(player), SecondaryLogic.AirCutter_Value(player), 0);
      StartAnimation(player.objGroup.gameObject, Fix.AIR_CUTTER, Fix.COLOR_NORMAL); //todo buff 戦闘速度2%上昇、最大3回累積をつけてね
    }
  }

  private void ExecRockSlum(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.RockSlum(player), Fix.DamageSource.Earth, critical);
    if (success)
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_GAUGE_BACK, Fix.COLOR_NORMAL); // todo 対象の行動ゲージを5%後方へ戻す。をつけてね
    }
  }

  private void ExecStraightSmash(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    ExecNormalAttack(player, target, SecondaryLogic.StraightSmash(player), critical);
  }

  private void ExecHunterShot(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.HunterShot(player), critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.HUNTER_SHOT, SecondaryLogic.HunterShot_Turn(player), SecondaryLogic.HunterShot_Value(player), 0);
      StartAnimation(target.objGroup.gameObject, Fix.HUNTER_SHOT, Fix.COLOR_NORMAL);
    }
  }

  private void ExecLegStrike(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    // ２回攻撃
    for (int ii = 0; ii < 2; ii++)
    {
      ExecNormalAttack(player, target, SecondaryLogic.LegStrike(player), critical);
    }
  }

  private void ExecVenomSlash(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.VenomSlash(player), critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_POISON, SecondaryLogic.VenomSlash_Turn(player), SecondaryLogic.VenomSlash_2(player), 0);
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_POISON, Fix.COLOR_NORMAL);
    }
  }

  private void ExecEnergyBolt(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    ExecNormalAttack(player, target, SecondaryLogic.EnergyBolt(player), critical); // todo このダメージ量は【知】をベースとして算出される。
  }

  private void ExecShieldBash(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.ShieldBash(player), critical);
    if (success)
    {
      if (target.IsResistStun)
      {
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_STUN, Fix.COLOR_NORMAL);
        return;
      }

      target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_STUN, SecondaryLogic.ShieldBash_Turn(player), 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_STUN, Fix.COLOR_NORMAL);
    }
  }

  private void ExecAuraOfPower(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.AURA_OF_POWER, SecondaryLogic.AuraOfPower_Turn(player), SecondaryLogic.AuraOfPower_Value(player), 0);
    StartAnimation(target.objGroup.gameObject, Fix.AURA_OF_POWER, Fix.COLOR_NORMAL);
  }

  private void ExecDispelMagic(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.RemoveBuff(SecondaryLogic.DispelMagic_Value(player), ActionCommand.BuffType.Positive);
    StartAnimation(target.objGroup.gameObject, Fix.DISPEL_MAGIC, Fix.COLOR_NORMAL);
  }

  private void ExecTrueSight(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.TRUE_SIGHT, SecondaryLogic.TrueSight_Turn(player), 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.TRUE_SIGHT, Fix.COLOR_NORMAL);
    // todo
    // 味方一体を対象とする。対象に【深層】のBUFFを付与する。
    //【深層】が続く間、【沈黙】【鈍化】【暗闇】【毒】のBUFFがあったとしてもそれがあたかも無いかに様に行動する。
  }

  private void ExecHeartOfLife(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.HEART_OF_LIFE, SecondaryLogic.HeartOfLife_Turn(player), PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random), 0);
    StartAnimation(target.objGroup.gameObject, Fix.HEART_OF_LIFE, Fix.COLOR_NORMAL);
  }

  private void ExecDarkAura(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    // todo
    // 味方一体を対象とする。対象に【黒炎】のBUFFを付与する。
    // ターン経過毎にこのBUFFは累積カウント＋１される。累積カウントが３を超えた場合、消失する。
    //【黒炎】が続く間、対象の魔法攻撃が上昇する。上昇は累積カウントの分だけ上昇する。
  }

  private void ExecOracleCommand(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    int effectValue = SecondaryLogic.OracleCommand(player);
    target.CurrentActionPoint += effectValue;
    StartAnimation(target.objGroup.gameObject, "AP +" + effectValue.ToString(), Fix.COLOR_NORMAL);
  }

  // Delve II
  private void ExecFlameBlade(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.FLAME_BLADE, SecondaryLogic.FlameBlade_Turn(player), SecondaryLogic.FlameBlade(player), 0);
    StartAnimation(target.objBuffPanel.gameObject, Fix.FLAME_BLADE, Fix.COLOR_NORMAL);
  }

  private void ExecPurePurification(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.RemoveBuff(1, ActionCommand.BuffType.Negative);
    StartAnimation(target.objGroup.gameObject, Fix.PURE_PURIFICATION, Fix.COLOR_NORMAL);
  }

  private void ExecDivineCircle(Character player, Character target, BuffField target_field_obj)
  {
    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }

    target_field_obj.AddBuff(prefab_Buff, Fix.DIVINE_CIRCLE, SecondaryLogic.DivineCircle_Turn(player), SecondaryLogic.DivineCircle(player), 0);
    StartAnimation(target_field_obj.gameObject, Fix.DIVINE_CIRCLE, Fix.COLOR_NORMAL);
  }

  private void ExecBloodSign(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BLOOD_SIGN, SecondaryLogic.BloodSign_Turn(player), SecondaryLogic.BloodSign(player), 0);
    StartAnimation(target.objGroup.gameObject, Fix.BLOOD_SIGN, Fix.COLOR_NORMAL);
  }

  private void ExecSkyShield(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.SKY_SHIELD, SecondaryLogic.SkyShield_Turn(player), SecondaryLogic.SkyShield_Value(player), 0);
    StartAnimation(target.objGroup.gameObject, Fix.SKY_SHIELD, Fix.COLOR_NORMAL);
  }

  private void ExecFlashCounter(Character player, StackObject[] stack_list)
  {
    if (stack_list.Length >= 2)
    {
      // FLASH_COUNTERがスタック先頭なので、一つ前を削除する。
      int num = stack_list.Length - 2;

      if (ActionCommand.GetAttribute(stack_list[num].StackName) == ActionCommand.Attribute.Skill)
      {
        StartAnimation(stack_list[num].gameObject, "Counter!", Fix.COLOR_NORMAL);
        Destroy(stack_list[num].gameObject);
        stack_list[num] = null;
      }
      else
      {
        StartAnimation(stack_list[num].gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      }
    }
  }

  private void ExecStanceOfTheBlade(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.STANCE_OF_THE_BLADE, SecondaryLogic.StanceOfTheBlade_Turn(player), SecondaryLogic.StanceOfTheBlade(player), 0);
    StartAnimation(player.objGroup.gameObject, Fix.STANCE_OF_THE_BLADE, Fix.COLOR_NORMAL);
  }

  private void ExecSpeedStep(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.SPEED_STEP, SecondaryLogic.SpeedStep_Turn(player), SecondaryLogic.SpeedStep(player), 0);
    StartAnimation(target.objGroup.gameObject, Fix.SPEED_STEP, Fix.COLOR_NORMAL);
  }

  private void ExecStanceOfTheGuard(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.STANCE_OF_THE_GUARD, SecondaryLogic.StanceOfTheGuard_Turn(player), SecondaryLogic.StanceOfTheGuard(player), 0);
    StartAnimation(target.objGroup.gameObject, Fix.STANCE_OF_THE_GUARD, Fix.COLOR_NORMAL);
  }

  private void ExecMultipleShot(Character player, List<Character> target_list, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      ExecNormalAttack(player, target_list[ii], SecondaryLogic.MultipleShot(player), critical);
    }
  }

  private void ExecInvisibleBind(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.InvisibleBind(player), critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_BIND, SecondaryLogic.InvibisleBind_Turn(player), 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BIND, Fix.COLOR_NORMAL);
    }
  }

  private void ExecFortuneSpirit(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.FORTUNE_SPIRIT, SecondaryLogic.FortuneSpirit_Turn(player), SecondaryLogic.FortuneSpirit(player), 0);
    StartAnimation(target.objGroup.gameObject, Fix.FORTUNE_SPIRIT, Fix.COLOR_NORMAL);
  }

  private void ExecSpiritualRest(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.IsStun)
    {
      target.RemoveStun();
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_REMOVE_STUN, Fix.COLOR_NORMAL);
    }
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_RESIST_STUN, SecondaryLogic.SpiritualRest_Turn(player), 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.BUFF_RESIST_STUN, Fix.COLOR_NORMAL);
  }

  private void ExecZeroImmunity(Character player, Character target)
  {
    // todo
  }

  private void ExecCircleSlash(Character player, List<Character> target_list, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      ExecNormalAttack(player, target_list[ii], SecondaryLogic.NormalAttack(player), critical);
    }
  }

  private void ExecDoubleSlash(Character player, Character target, CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < 2; ii++)
    {
      ExecNormalAttack(player, target, SecondaryLogic.NormalAttack(player), critical);
    }
  }

  private void ExecMeteorBullet(Character player, List<Character> target_list, CriticalType critical)
  {
    for (int ii = 0; ii < 3; ii++)
    {
      int rand = AP.Math.RandomInteger(target_list.Count);
      ExecMagicAttack(player, target_list[rand], SecondaryLogic.MeteorBullet(player), Fix.DamageSource.Fire, critical);
    }
  }

  private void ExecBlueBullet(Character player, Character target, CriticalType critical)
  {
    for (int ii = 0; ii < 3; ii++)
    {
      ExecMagicAttack(player, target, SecondaryLogic.BlueBullet(player), Fix.DamageSource.Ice, critical);
    }
  }

  public void ExecHolyBreath(Character player, List<Character> target_list)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.HolyBreath(player);
      AbstractHealCommand(player, target_list[ii], healValue);
    }
  }

  public void ExecBlackContract(Character player)
  {
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.BLACK_CONTRACT, SecondaryLogic.BlackContract_Turn(player), SecondaryLogic.BlackContract(player), 0);
    StartAnimation(player.objGroup.gameObject, Fix.BLACK_CONTRACT, Fix.COLOR_NORMAL);
  }

  public void ExecConcussiveHit(Character player, Character target, CriticalType critical)
  {
    bool success = ExecNormalAttack(player, target, SecondaryLogic.ConcussiveHit(player), critical);
    if (success)
    {
      ExecBuffPhysicalDefenseDown(player, target, SecondaryLogic.ConcussiveHit_Turn(player), SecondaryLogic.ConcussiveHit(player));
    }
  }

  public void ExecEyeOfTheIsshin(Character player, Character target)
  {
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.EYE_OF_THE_ISSHIN, SecondaryLogic.EyeOfTheIsshin_Turn(player), SecondaryLogic.EyeOfTheIsshin(player), 0);
    StartAnimation(target.objGroup.gameObject, Fix.EYE_OF_THE_ISSHIN, Fix.COLOR_NORMAL);
  }

  public void ExecIrregularStep(Character player, Character target)
  {
    this.NowIrregularStepPlayer = player;
    this.NowIrregularStepTarget = target;
    this.NowIrregularStepCounter = SecondaryLogic.IrregularStep_GaugeStep(player) * BATTLE_GAUGE_WITDH;
    this.NowIrregularStepMode = true;
  }
  private void ExecPlayIrregularStep()
  {
    if (this.NowIrregularStepCounter > 0)
    {
      float factor = (float)PrimaryLogic.BattleSpeed(this.NowIrregularStepPlayer) * 2.00f;
      UpdatePlayerArrow(this.NowIrregularStepPlayer, factor);
      this.NowIrregularStepCounter = this.NowIrregularStepCounter - factor * BATTLE_GAUGE_WITDH / 100.0f;
    }

    if (this.NowIrregularStepCounter <= 0.0f)
    {
      ExecNormalAttack(this.NowIrregularStepPlayer, this.NowIrregularStepTarget, SecondaryLogic.IrregularStep_Damage(this.NowIrregularStepPlayer), CriticalType.Random);
      this.NowIrregularStepPlayer = null;
      this.NowIrregularStepTarget = null;
      this.NowIrregularStepCounter = 0;
      this.NowIrregularStepMode = false;
    }
  }

  public void ExecStormArmor(Character player, Character target)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.STORM_ARMOR, SecondaryLogic.StormArmor_Turn(player), SecondaryLogic.StormArmor_SpeedUp(player), SecondaryLogic.StormArmor_Damage(player));
    StartAnimation(target.objGroup.gameObject, Fix.STORM_ARMOR, Fix.COLOR_NORMAL);
  }

  public void ExecMuteImpulse(Character player, Character target, CriticalType critical)
  {
    int positiveCount = target.GetPositiveBuff() + 1;
    ExecMagicAttack(player, target, SecondaryLogic.MuteImpulse(player) * positiveCount, Fix.DamageSource.Colorless, critical);
  }

  public void ExecVoiceOfVigor(Character player, List<Character> target_list)
  {
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      target_list[ii].objBuffPanel.AddBuff(prefab_Buff, Fix.VOICE_OF_VIGOR, SecondaryLogic.VoiceOfVigor_Turn(player), SecondaryLogic.VoiceOfVigor(player), 0);
      StartAnimation(target_list[ii].objGroup.gameObject, Fix.VOICE_OF_VIGOR, Fix.COLOR_NORMAL);

      ExecLifeGain(target_list[ii], (target_list[ii].MaxLife / 10.0f));
    }
  }

  public void ExecUnseenAid(Character player, List<Character> target_list)
  {
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      target_list[ii].objBuffPanel.RemoveAll();
      StartAnimation(target_list[ii].objGroup.gameObject, Fix.BUFF_REMOVE_ALL, Fix.COLOR_NORMAL);
    }
  }

  private bool ExecUseRedPotion(Character target, string command_name)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    string itemName = string.Empty;

    if (command_name == Fix.USE_RED_POTION_1 || command_name == Fix.SMALL_RED_POTION) { itemName = Fix.SMALL_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_2 || command_name == Fix.NORMAL_RED_POTION) { itemName = Fix.NORMAL_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_3 || command_name == Fix.LARGE_RED_POTION) { itemName = Fix.LARGE_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_4 || command_name == Fix.HUGE_RED_POTION) { itemName = Fix.HUGE_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_5 || command_name == Fix.HQ_RED_POTION) { itemName = Fix.HQ_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_6 || command_name == Fix.THQ_RED_POTION) { itemName = Fix.THQ_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_7 || command_name == Fix.PERFECT_RED_POTION) { itemName = Fix.PERFECT_RED_POTION; }

    if (itemName == string.Empty)
    {
      Debug.Log("Red Potion name is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    if (One.TF.FindBackPackItem(itemName) == false)
    {
      Debug.Log("Red Potion is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    Item current = new Item(itemName);
    One.TF.DeleteBackpack(current, 1);
    double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
    AbstractHealCommand(null, target, effectValue);
    return true;
  }

  private bool ExecUseBluePotion(Character target, string command_name)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    string itemName = string.Empty;

    if (command_name == Fix.USE_BLUE_POTION_1 || command_name == Fix.SMALL_BLUE_POTION) { itemName = Fix.SMALL_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_2 || command_name == Fix.NORMAL_BLUE_POTION) { itemName = Fix.NORMAL_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_3 || command_name == Fix.LARGE_BLUE_POTION) { itemName = Fix.LARGE_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_4 || command_name == Fix.HUGE_BLUE_POTION) { itemName = Fix.HUGE_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_5 || command_name == Fix.HQ_BLUE_POTION) { itemName = Fix.HQ_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_6 || command_name == Fix.THQ_BLUE_POTION) { itemName = Fix.THQ_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_7 || command_name == Fix.PERFECT_BLUE_POTION) { itemName = Fix.PERFECT_BLUE_POTION; }

    if (itemName == string.Empty)
    {
      Debug.Log("Blue Potion name is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    if (One.TF.FindBackPackItem(itemName) == false)
    {
      Debug.Log("Blue Potion is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    Item current = new Item(itemName);
    One.TF.DeleteBackpack(current, 1);
    double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
    AbstractGainSoulPoint(null, target, effectValue);
    return true;
  }

  private bool ExecPureCleanWater(Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    if (One.TF.FindBackPackItem(Fix.PURE_CLEAN_WATER) == false)
    {
      Debug.Log("PURE_CLEAN_WATER is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }
    if (One.TF.AlreadyPureCleanWater)
    {
      Debug.Log("PURE_CLEAN_WATER is already used...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_ALREADY_USED, Fix.COLOR_NORMAL);
      return false;
    }

    One.TF.AlreadyPureCleanWater = true;
    double effectValue = target.MaxLife;
    AbstractHealCommand(null, target, effectValue);
    return true;
  }

  private void ExecLifeGain(Character target, double effectValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    AbstractHealCommand(null, target, effectValue);
  }

  private void ExecPoisonDamage(Character target, double effectValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target == null) { Debug.Log("target is null. then no effect."); return; }
    if (target.Dead) { Debug.Log("target is dead. then no effect."); return; }

    if (effectValue <= 0) { effectValue = 0; }
    int result = (int)effectValue;
    Debug.Log(target.FullName + " " + result.ToString() + " damage");
    target.CurrentLife -= result;
    target.txtLife.text = target.CurrentLife.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL);
  }

  private void ExecLightningDamage(Character target, double effect_value)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target == null) { Debug.Log("target is null. then no effect."); return; }
    if (target.Dead) { Debug.Log("target is dead. then no effect."); return; }

    if (effect_value <= 0) { effect_value = 0; }
    int result = (int)effect_value;
    Debug.Log(target.FullName + " " + result.ToString() + " damage");
    target.CurrentLife -= result;
    target.txtLife.text = target.CurrentLife.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL);
  }

  private void ExecSlipDamage(Character target, double effectValue)
  {
    // 毒と出血は効果は同じだが、毒はアップキープ、出血は行動時なので、効果は同じで良い。
    Debug.Log(MethodBase.GetCurrentMethod());

    if (target == null) { Debug.Log("target is null. then no effect."); return; }
    if (target.Dead) { Debug.Log("target is dead. then no effect."); return; }

    if (effectValue <= 0) { effectValue = 0; }
    int result = (int)effectValue;
    Debug.Log(target.FullName + " " + result.ToString() + " damage");
    target.CurrentLife -= result;
    target.txtLife.text = target.CurrentLife.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL);
  }

  private void ExecBuffPoison(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_POISON, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_POISON, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSlow(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_SLOW, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_SLOW, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSleep(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_SLEEP, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_SLEEP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffStun(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_STUN, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_STUN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffDizzy(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_DIZZY, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DIZZY, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBind(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_BIND, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BIND, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSilent(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_SILENT, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_SILENT, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSlip(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_SLIP, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_SLIP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffPhysicalAttackUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PA_UP, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PA_UP, Fix.COLOR_NORMAL);
  }
  private void ExecBuffPhysicalAttackDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PA_DOWN, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PA_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffPhysicalDefenseUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PD_UP, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PD_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffPhysicalDefenseDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PD_DOWN, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PD_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffMagicAttackUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_MA_UP, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_MA_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffMagicAttackDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_MA_DOWN, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_MA_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffMagicDefenceUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_MD_UP, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_MD_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffMagicDefenceDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_MD_DOWN, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_MD_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattleSpeedUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_BS_UP, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BS_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattleSpeedDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_BS_DOWN, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BS_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattleResponseUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_BR_UP, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BR_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattleResponseDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_BR_DOWN, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BR_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattlePotentialUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PO_UP, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PO_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattlePotentialDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PO_DOWN, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PO_DOWN, Fix.COLOR_NORMAL);
  }

  private void BuffUpFire(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_POWERUP_FIRE, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_POWERUP_FIRE, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSyutyuDanzetsu(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_SYUTYU_DANZETSU, turn, effect_value, 0);
    StartAnimation(target.objGroup.gameObject, Fix.BUFF_SYUTYU_DANZETSU, Fix.COLOR_NORMAL);
  }

  #region "元核"
  private void ExecEinShutyuDanzetsu(Character player, Character target)
  {
    ExecBuffSyutyuDanzetsu(player, target, Fix.INFINITY, PrimaryLogic.Potential(player));
  }

  private void ExecLanaPerfectSpell(Character player, Character target)
  {
    // todo
  }

  private void ExecEoneMuinSong(Character player, Character target)
  {
    // todo
  }

  private void ExecBillyVictoryStyle(Character player, Character target)
  {
    // todo
  }

  private void ExecAdelEndlessMemory(Character player, Character target)
  {
    // todo
  }

  private void ExecRoStanceOfMuni(Character player, Character target)
  {
    // todo
  }
  #endregion

  #region "General"
  private double PhysicalDamageLogic(Character player, Character target, double magnify, Fix.DamageSource attr, CriticalType critical, ref bool result_critical)
  {
    // 攻撃コマンドのダメージを算出
    double damageValue = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * magnify;
    double debug1 = damageValue;
    Debug.Log("PrimaryLogic.PhysicalAttack: " + debug1.ToString());

    // Buff効果による増強（物理属性専用UPは現時点では存在しない）

    // クリティカル判定
    result_critical = false;
    if (player.CannotCritical == false &&
        ((critical == CriticalType.Random && AP.Math.RandomInteger(100) <= 5))
       )
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      debug1 = damageValue;
      result_critical = true;
      Debug.Log("PhysicalDamageLogic detect Critical! (Random) " + damageValue.ToString());
    }
    if (critical == CriticalType.Absolute)
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      debug1 = damageValue;
      result_critical = true;
      Debug.Log("PhysicalDamageLogic detect Critical! (Absolute) " + damageValue.ToString());
    }


    // ターゲットの物理防御を差し引く
    double defenseValue = PrimaryLogic.PhysicalDefense(target);
    double debug2 = defenseValue;
    Debug.Log("PrimaryLogic.PhysicalDefense: " + debug2.ToString());

    if (player.IsEyeOfTheIsshin)
    {
      double reduce = 1.00f - player.IsEyeOfTheIsshin.EffectValue;
      if (reduce <= 0.0f) { reduce = 0.0f; }
      Debug.Log("player.IsEyeOfTheIsshin.EffectValue: " + reduce.ToString("F2"));
      defenseValue = defenseValue * reduce;
      debug2 = defenseValue;
      Debug.Log("PrimaryLogic.PhysicalDefense(EoT): " + debug2.ToString());
    }
    damageValue -= defenseValue;
    double debug3 = damageValue;
    Debug.Log("Physical-DamageValue: " + debug1.ToString("F2") + " - " + debug2.ToString("F2") + " = " + debug3.ToString("F2"));

    // ターゲットが防御姿勢であれば、ダメージを軽減する
    if (target.IsDefense)
    {
      damageValue = damageValue * SecondaryLogic.DefenseFactor(target);
      Debug.Log("Target is Defense mode: " + damageValue.ToString("F2"));
    }

    // ダメージ量が負の値になる場合は０とみなす。
    if (damageValue <= 0) { damageValue = 0; }

    return damageValue;
  }

  private double MagicDamageLogic(Character player, Character target, double magnify, Fix.DamageSource attr, CriticalType critical, ref bool result_critical)
  {
    // 魔法コマンドのダメージを算出
    double damageValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * magnify;
    double debug0 = damageValue;
    Debug.Log("PrimaryLogic.MagicDamage: " + debug0.ToString());

    // Buff効果による増強
    if (attr == Fix.DamageSource.Fire && player.IsUpFire)
    {
      Debug.Log("damageValue UpFire: " + player.IsUpFire.EffectValue.ToString());
      damageValue = damageValue * player.IsUpFire.EffectValue;
    }
    if (attr == Fix.DamageSource.Ice && player.IsUpIce)
    {
      Debug.Log("damageValue IsUpIce: " + player.IsUpIce.EffectValue.ToString());
      damageValue = damageValue * player.IsUpIce.EffectValue;
    }
    if (attr == Fix.DamageSource.HolyLight && player.IsUpLight)
    {
      Debug.Log("damageValue IsUpLight: " + player.IsUpLight.EffectValue.ToString());
      damageValue = damageValue * player.IsUpLight.EffectValue;
    }
    if (attr == Fix.DamageSource.DarkMagic && player.IsUpShadow)
    {
      Debug.Log("damageValue IsUpShadow: " + player.IsUpShadow.EffectValue.ToString());
      damageValue = damageValue * player.IsUpShadow.EffectValue;
    }

    // ストーム・アーマーによる効果
    if (player.IsStormArmor)
    {
      damageValue = damageValue * player.IsStormArmor.EffectValue2;
      Debug.Log("damageValue IsStormArmor(after): " + damageValue.ToString());
    }

    // クリティカル判定
    result_critical = false;
    if (player.CannotCritical == false &&
        ((critical == CriticalType.Random && AP.Math.RandomInteger(100) <= 5))
       )
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      result_critical = true;
      Debug.Log("MagicDamageLogic detect Critical! (Random) " + damageValue.ToString());
    }
    if (critical == CriticalType.Absolute)
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      result_critical = true;
      Debug.Log("MagicDamageLogic detect Critical! (Absolute) " + damageValue.ToString());
    }

    // 属性耐性の分だけ、減衰させる。
    if (attr == Fix.DamageSource.Fire && target.MainWeapon != null && target.MainWeapon.ResistFire > 0) { damageValue *= (1.00f - target.MainWeapon.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.SubWeapon != null && target.SubWeapon.ResistFire > 0) { damageValue *= (1.00f - target.SubWeapon.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.MainArmor != null && target.MainArmor.ResistFire > 0) { damageValue *= (1.00f - target.MainArmor.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.Accessory1 != null && target.Accessory1.ResistFire > 0) { damageValue *= (1.00f - target.Accessory1.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.Accessory2 != null && target.Accessory2.ResistFire > 0) { damageValue *= (1.00f - target.Accessory2.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.Artifact != null && target.Artifact.ResistFire > 0) { damageValue *= (1.00f - target.Artifact.ResistFire); }

    if (attr == Fix.DamageSource.Ice && target.MainWeapon != null && target.MainWeapon.ResistIce > 0) { damageValue *= (1.00f - target.MainWeapon.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.SubWeapon != null && target.SubWeapon.ResistIce > 0) { damageValue *= (1.00f - target.SubWeapon.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.MainArmor != null && target.MainArmor.ResistIce > 0) { damageValue *= (1.00f - target.MainArmor.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.Accessory1 != null && target.Accessory1.ResistIce > 0) { damageValue *= (1.00f - target.Accessory1.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.Accessory2 != null && target.Accessory2.ResistIce > 0) { damageValue *= (1.00f - target.Accessory2.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.Artifact != null && target.Artifact.ResistIce > 0) { damageValue *= (1.00f - target.Artifact.ResistIce); }

    if (attr == Fix.DamageSource.HolyLight && target.MainWeapon != null && target.MainWeapon.ResistLight > 0) { damageValue *= (1.00f - target.MainWeapon.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.SubWeapon != null && target.SubWeapon.ResistLight > 0) { damageValue *= (1.00f - target.SubWeapon.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.MainArmor != null && target.MainArmor.ResistLight > 0) { damageValue *= (1.00f - target.MainArmor.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.Accessory1 != null && target.Accessory1.ResistLight > 0) { damageValue *= (1.00f - target.Accessory1.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.Accessory2 != null && target.Accessory2.ResistLight > 0) { damageValue *= (1.00f - target.Accessory2.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.Artifact != null && target.Artifact.ResistLight > 0) { damageValue *= (1.00f - target.Artifact.ResistLight); }

    if (attr == Fix.DamageSource.DarkMagic && target.MainWeapon != null && target.MainWeapon.ResistShadow > 0) { damageValue *= (1.00f - target.MainWeapon.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.SubWeapon != null && target.SubWeapon.ResistShadow > 0) { damageValue *= (1.00f - target.SubWeapon.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.MainArmor != null && target.MainArmor.ResistShadow > 0) { damageValue *= (1.00f - target.MainArmor.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.Accessory1 != null && target.Accessory1.ResistShadow > 0) { damageValue *= (1.00f - target.Accessory1.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.Accessory2 != null && target.Accessory2.ResistShadow > 0) { damageValue *= (1.00f - target.Accessory2.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.Artifact != null && target.Artifact.ResistShadow > 0) { damageValue *= (1.00f - target.Artifact.ResistShadow); }

    if (attr == Fix.DamageSource.Wind && target.MainWeapon != null && target.MainWeapon.ResistWind > 0) { damageValue *= (1.00f - target.MainWeapon.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.SubWeapon != null && target.SubWeapon.ResistWind > 0) { damageValue *= (1.00f - target.SubWeapon.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.MainArmor != null && target.MainArmor.ResistWind > 0) { damageValue *= (1.00f - target.MainArmor.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.Accessory1 != null && target.Accessory1.ResistWind > 0) { damageValue *= (1.00f - target.Accessory1.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.Accessory2 != null && target.Accessory2.ResistWind > 0) { damageValue *= (1.00f - target.Accessory2.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.Artifact != null && target.Artifact.ResistWind > 0) { damageValue *= (1.00f - target.Artifact.ResistWind); }

    if (attr == Fix.DamageSource.Earth && target.MainWeapon != null && target.MainWeapon.ResistEarth > 0) { damageValue *= (1.00f - target.MainWeapon.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.SubWeapon != null && target.SubWeapon.ResistEarth > 0) { damageValue *= (1.00f - target.SubWeapon.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.MainArmor != null && target.MainArmor.ResistEarth > 0) { damageValue *= (1.00f - target.MainArmor.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.Accessory1 != null && target.Accessory1.ResistEarth > 0) { damageValue *= (1.00f - target.Accessory1.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.Accessory2 != null && target.Accessory2.ResistEarth > 0) { damageValue *= (1.00f - target.Accessory2.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.Artifact != null && target.Artifact.ResistEarth > 0) { damageValue *= (1.00f - target.Artifact.ResistEarth); }

    double debug1 = damageValue;

    // ターゲットの魔法防御を差し引く
    double defenseValue = PrimaryLogic.MagicDefense(target);
    double debug2 = defenseValue;
    damageValue -= defenseValue;
    double debug3 = damageValue;

    Debug.Log("Magic-DamageValue: " + debug0.ToString("F2") + " -> " + debug1.ToString("F2") + " - " + debug2.ToString("F2") + " = " + debug3.ToString("F2"));

    // ターゲットが防御姿勢であれば、ダメージを軽減する
    if (target.IsDefense)
    {
      damageValue = damageValue * SecondaryLogic.DefenseFactor(target);
      Debug.Log("Target is Defense mode: " + damageValue.ToString());
    }

    // ダメージ量が負の値になる場合は０とみなす。
    if (damageValue <= 0) { damageValue = 0; }

    return damageValue;
  }

  private void ApplyDamage(Character player, Character target, double damageValue, bool critical, int animation_speed)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    if (damageValue <= 0) { damageValue = 0; }

    int result = (int)damageValue;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " damage");
    target.CurrentLife -= result;
    target.txtLife.text = target.CurrentLife.ToString();
    if (critical)
    {
      StartAnimation(target.objGroup.gameObject, result.ToString() + "\r\n Critial", Fix.COLOR_NORMAL, animation_speed);
    }
    else
    {
      StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL, animation_speed);
    }
  }

  private bool AbstractHealCommand(Character player, Character target, double healValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // ヒールなので、防御姿勢で軽減はしない。
    // if (target.IsDefense) { healValue = healValue / 3.0f; }

    // ヒール量が負の値になる場合は０とみなす。
    if (healValue <= 0) { healValue = 0; }

    int result = (int)healValue;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " life heal");
    target.CurrentLife += result;
    target.txtLife.text = target.CurrentLife.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_HEAL);

    return true;
  }

  private bool AbstractGainSoulPoint(Character player, Character target, double gainValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // ゲイン量が負の値になる場合は０とみなす。
    if (gainValue <= 0) { gainValue = 0; }

    int result = (int)gainValue;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " sp gain");
    target.CurrentSoulPoint += result;
    target.txtSoulPoint.text = target.CurrentSoulPoint.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_GAIN_SP);

    return true;
  }
  #endregion
}

