﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
        else if (command_name == Fix.FIRE_BOLT)
        {
            result = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.FireBolt(player);
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
        else if (command_name == Fix.CIRCLE_SLASH)
        {
            result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.CircleSlash(player);
        }
        else if (command_name == Fix.DOUBLE_SLASH)
        {
            result = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.NormalAttack(player);
        }

        return result;
    }

    private void ExecNormalAttack(Character player, Character target, double magnify, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        bool success = false;
        double damageValue = PhysicalDamageLogic(player, target, magnify, critical);
        success = AbstractDamageCommand(player, target, damageValue);

        // アクションコマンド実行後、行動が成立した場合、追加効果を行う。
        if (success)
        {
            if (player.IsFlameBlade && player.Dead == false)
            {
                double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.MagicAttack(player), Fix.CommandAttribute.Fire, critical);
                AbstractDamageCommand(player, target, addDamageValue);
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
        }
    }

    private void ExecMagicAttack(Character player, Character target, double magnify, Fix.CommandAttribute attr, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        double damageValue = MagicDamageLogic(player, target, magnify, attr, critical);
        AbstractDamageCommand(player, target, damageValue);
    }

    private void ExecFireBolt(Character player, Character target, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        double damageValue = MagicDamageLogic(player, target, SecondaryLogic.FireBolt(player), Fix.CommandAttribute.Fire, critical);
        AbstractDamageCommand(player, target, damageValue);
    }

    private void ExecIceNeedle(Character player, Character target, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        double damageValue = MagicDamageLogic(player, target, SecondaryLogic.IceNeedle(player), Fix.CommandAttribute.Ice, critical);
        AbstractDamageCommand(player, target, damageValue);

        target.AddBuff(Fix.ICE_NEEDLE, SecondaryLogic.IceNeedle_Value(player), SecondaryLogic.IceNeedle_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.ICE_NEEDLE, Fix.COLOR_NORMAL);
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
        double damageValue = MagicDamageLogic(player, target, SecondaryLogic.ShadowBlast(player), Fix.CommandAttribute.DarkMagic, critical);
        AbstractDamageCommand(player, target, damageValue);

        target.AddBuff(Fix.SHADOW_BLAST, SecondaryLogic.ShadowBlast_Value(player), SecondaryLogic.ShadowBlast_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.SHADOW_BLAST, Fix.COLOR_NORMAL);
    }

    private void ExecAuraOfPower(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.AddBuff(Fix.AURA_OF_POWER, SecondaryLogic.AuraOfPower_Value(player), SecondaryLogic.AuraOfPower_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.AURA_OF_POWER, Fix.COLOR_NORMAL);
    }
    
    private void ExecDispelMagic(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.RemoveBuff(1, ActionCommand.BuffType.Positive);
        StartAnimation(target.objGroup.gameObject, Fix.DISPEL_MAGIC, Fix.COLOR_NORMAL);
    }

    private void ExecStraightSmash(Character player, Character target, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        bool success = false;
        double damageValue = PhysicalDamageLogic(player, target, SecondaryLogic.StraightSmash(player), critical);
        success = AbstractDamageCommand(player, target, damageValue);

        // アクションコマンド実行後、行動が成立した場合、追加効果を行う。
        if (success)
        {
            if (player.IsFlameBlade && player.Dead == false)
            {
                double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.MagicAttack(player), Fix.CommandAttribute.Fire, critical);
                AbstractDamageCommand(player, target, addDamageValue);
            }
            BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
            if (stanceOfTheBlade)
            {
                stanceOfTheBlade.Cumulative++;
            }
            BuffImage stanceOfTheGuard = target.IsStanceOfTheGuard;
            if (target.IsStanceOfTheGuard && target.IsDefense && target.Dead == false)
            {
                stanceOfTheGuard.Cumulative++;
            }
        }
    }

    private void ExecShieldBash(Character player, Character target, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        bool success = false;
        double damageValue = PhysicalDamageLogic(player, target, SecondaryLogic.ShieldBash(player), critical);
        success = AbstractDamageCommand(player, target, damageValue);

        // アクションコマンド実行後、行動が成立した場合、追加効果を行う。
        if (success)
        {
            if (target.IsResistStun)
            {
                StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_STUN, Fix.COLOR_NORMAL);
            }
            else
            {
                target.AddBuff(Fix.EFFECT_STUN, 0, SecondaryLogic.ShieldBash_Turn(player));
                StartAnimation(target.objGroup.gameObject, Fix.EFFECT_STUN, Fix.COLOR_NORMAL);
            }

            if (player.IsFlameBlade && player.Dead == false)
            {
                double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.MagicAttack(player), Fix.CommandAttribute.Fire, critical);
                AbstractDamageCommand(player, target, addDamageValue);
            }
            BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
            if (stanceOfTheBlade)
            {
                stanceOfTheBlade.Cumulative++;
            }
            BuffImage stanceOfTheGuard = target.IsStanceOfTheGuard;
            if (target.IsStanceOfTheGuard && target.IsDefense && target.Dead == false)
            {
                stanceOfTheGuard.Cumulative++;
            }
        }
    }

    private void ExecHunterShot(Character player, Character target, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        bool success = false;
        double damageValue = PhysicalDamageLogic(player, target, SecondaryLogic.HunterShot(player), critical);
        success = AbstractDamageCommand(player, target, damageValue);

        if (success)
        {
            target.AddBuff(Fix.HUNTER_SHOT, SecondaryLogic.HunterShot_Value(player), SecondaryLogic.HunterShot_Turn(player));
            StartAnimation(target.objGroup.gameObject, Fix.HUNTER_SHOT, Fix.COLOR_NORMAL);

            if (player.IsFlameBlade && player.Dead == false)
            {
                double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.MagicAttack(player), Fix.CommandAttribute.Fire, critical);
                AbstractDamageCommand(player, target, addDamageValue);
            }
            BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
            if (stanceOfTheBlade)
            {
                stanceOfTheBlade.Cumulative++;
            }
            BuffImage stanceOfTheGuard = target.IsStanceOfTheGuard;
            if (target.IsStanceOfTheGuard && target.IsDefense && target.Dead == false)
            {
                stanceOfTheGuard.Cumulative++;
            }
        }
    }

    private void ExecVenomSlash(Character player, Character target, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        bool success = false;
        double damageValue = PhysicalDamageLogic(player, target, SecondaryLogic.VenomSlash(player), critical);
        success = AbstractDamageCommand(player, target, damageValue);

        if (success)
        {
            target.AddBuff(Fix.EFFECT_POISON, SecondaryLogic.VenomSlash_2(player), SecondaryLogic.VenomSlash_Turn(player));
            StartAnimation(target.objGroup.gameObject, Fix.EFFECT_POISON, Fix.COLOR_NORMAL);

            if (player.IsFlameBlade && player.Dead == false)
            {
                double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.MagicAttack(player), Fix.CommandAttribute.Fire, critical);
                AbstractDamageCommand(player, target, addDamageValue);
            }
            BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
            if (stanceOfTheBlade)
            {
                stanceOfTheBlade.Cumulative++;
            }
            BuffImage stanceOfTheGuard = target.IsStanceOfTheGuard;
            if (target.IsStanceOfTheGuard && target.IsDefense && target.Dead == false)
            {
                stanceOfTheGuard.Cumulative++;
            }
        }
    }

    private void ExecHeartOfLife(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.AddBuff(Fix.HEART_OF_LIFE, PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random), SecondaryLogic.HeartOfLife_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.HEART_OF_LIFE, Fix.COLOR_NORMAL);
    }

    private void ExecOracleCommand(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        int effectValue = SecondaryLogic.OracleCommand(player);
        target.CurrentActionPoint += effectValue;
        StartAnimation(target.objGroup.gameObject, "AP +" + effectValue.ToString(), Fix.COLOR_NORMAL);
    }

    private void ExecFlameBlade(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.AddBuff(Fix.FLAME_BLADE, SecondaryLogic.FlameBlade(player), SecondaryLogic.FlameBlade_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.FLAME_BLADE, Fix.COLOR_NORMAL);
    }

    private void ExecPurePurification(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.RemoveBuff(1, ActionCommand.BuffType.Negative);
        StartAnimation(target.objGroup.gameObject, Fix.PURE_PURIFICATION, Fix.COLOR_NORMAL);
    }

    private void ExecDivineCircle(Character player, List<Character> target_list)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        for (int ii = 0; ii < target_list.Count; ii++)
        {
            target_list[ii].AddBuff(Fix.DIVINE_CIRCLE, SecondaryLogic.DivineCircle(player), SecondaryLogic.DivineCircle_Turn(player));
            StartAnimation(target_list[ii].objGroup.gameObject, Fix.DIVINE_CIRCLE, Fix.COLOR_NORMAL);
        }
    }

    private void ExecBloodSign(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.AddBuff(Fix.BLOOD_SIGN, SecondaryLogic.BloodSign(player), SecondaryLogic.BloodSign_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.BLOOD_SIGN, Fix.COLOR_NORMAL);
    }

    private void ExecSkyShield(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.AddBuff(Fix.SKY_SHIELD, SecondaryLogic.SkyShield_Value(player), SecondaryLogic.SkyShield_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.SKY_SHIELD, Fix.COLOR_NORMAL);
    }

    private void ExecFlashCounter(Character player, StackObject[] stackList)
    {
        if (stackList.Length >= 2)
        {
            // FLASH_COUNTERがスタック先頭なので、一つ前を削除する。
            int num = stackList.Length - 2;

            if (ActionCommand.GetAttribute(stackList[num].StackName) == ActionCommand.Attribute.Skill)
            {
                StartAnimation(stackList[num].gameObject, "Counter!", Fix.COLOR_NORMAL);
                Destroy(stackList[num].gameObject);
                stackList[num] = null;
            }
            else
            {
                StartAnimation(stackList[num].gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
            }
        }
    }

    private void ExecStanceOfTheBlade(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.AddBuff(Fix.STANCE_OF_THE_BLADE, SecondaryLogic.StanceOfTheBlade(player), SecondaryLogic.StanceOfTheBlade_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.STANCE_OF_THE_BLADE, Fix.COLOR_NORMAL);
    }

    private void ExecStanceOfTheGuard(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.AddBuff(Fix.STANCE_OF_THE_GUARD, SecondaryLogic.StanceOfTheGuard(player), SecondaryLogic.StanceOfTheGuard_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.STANCE_OF_THE_GUARD, Fix.COLOR_NORMAL);
    }

    private void ExecMultipleShot(Character player, List<Character> target_list, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        bool success = false;
        for (int ii = 0; ii < target_list.Count; ii++)
        {
            double damageValue = PhysicalDamageLogic(player, target_list[ii], SecondaryLogic.MultipleShot(player), critical);
            bool current = AbstractDamageCommand(player, target_list[ii], damageValue);
            if (current)
            {
                if (current) { success = current; } // 一つでも成功していれば、成功と判定する。

                if (player.IsFlameBlade && player.Dead == false)
                {
                    double addDamageValue = MagicDamageLogic(player, target_list[ii], SecondaryLogic.MagicAttack(player), Fix.CommandAttribute.Fire, critical);
                    AbstractDamageCommand(player, target_list[ii], addDamageValue);
                }
                BuffImage stanceOfTheGuard = target_list[ii].IsStanceOfTheGuard;
                if (target_list[ii].IsStanceOfTheGuard && target_list[ii].IsDefense && target_list[ii].Dead == false)
                {
                    stanceOfTheGuard.Cumulative++;
                }
            }
        }

        if (success)
        {
            BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
            if (stanceOfTheBlade)
            {
                stanceOfTheBlade.Cumulative++;
            }
        }
    }

    private void ExecInvisibleBind(Character player, Character target, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        bool success = false;
        double damageValue = PhysicalDamageLogic(player, target, SecondaryLogic.InvisibleBind(player), critical);
        success = AbstractDamageCommand(player, target, damageValue);
        if (success)
        {
            target.AddBuff(Fix.EFFECT_BIND, 0, SecondaryLogic.InvibisleBind_Turn(player));
            StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BIND, Fix.COLOR_NORMAL);
        }
    }

    private void ExecFortuneSpirit(Character player, Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        target.AddBuff(Fix.FORTUNE_SPIRIT, SecondaryLogic.FortuneSpirit(player), SecondaryLogic.FortuneSpirit_Turn(player));
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
        target.AddBuff(Fix.BUFF_RESIST_STUN, 0, SecondaryLogic.SpiritualRest_Turn(player));
        StartAnimation(target.objGroup.gameObject, Fix.BUFF_RESIST_STUN, Fix.COLOR_NORMAL);
    }


    private void ExecZeroImmunity(Character player, Character target)
    {
        // todo
    }

    private void ExecCircleSlash(Character player, List<Character> target_list, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        bool success = false;
        for (int ii = 0; ii < target_list.Count; ii++)
        {
            double damageValue = PhysicalDamageLogic(player, target_list[ii], SecondaryLogic.NormalAttack(player), critical);
            bool current = AbstractDamageCommand(player, target_list[ii], damageValue);
            if (current)
            {
                if (current) { success = current; } // 一つでも成功していれば、成功と判定する。

                if (player.IsFlameBlade && player.Dead == false)
                {
                    double addDamageValue = MagicDamageLogic(player, target_list[ii], SecondaryLogic.MagicAttack(player), Fix.CommandAttribute.Fire, critical);
                    AbstractDamageCommand(player, target_list[ii], addDamageValue);
                }
                BuffImage stanceOfTheGuard = target_list[ii].IsStanceOfTheGuard;
                if (target_list[ii].IsStanceOfTheGuard && target_list[ii].IsDefense && target_list[ii].Dead == false)
                {
                    stanceOfTheGuard.Cumulative++;
                }
            }
        }

        if (success)
        {
            BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
            if (stanceOfTheBlade)
            {
                stanceOfTheBlade.Cumulative++;
            }
        }
    }

    private void ExecDoubleSlash(Character player, Character target, CriticalType critical)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        for (int ii = 0; ii < 2; ii++)
        {
            double damageValue = PhysicalDamageLogic(player, target, SecondaryLogic.NormalAttack(player), critical);
            bool success = AbstractDamageCommand(player, target, damageValue);
            if (success)
            {
                if (player.IsFlameBlade && player.Dead == false)
                {
                    double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.MagicAttack(player), Fix.CommandAttribute.Fire, critical);
                    AbstractDamageCommand(player, target, addDamageValue);
                }
                BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
                if (stanceOfTheBlade)
                {
                    stanceOfTheBlade.Cumulative++;
                }
            }
        }
    }

    private void ExecUseRedPotion(Character target)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        double effectValue = 60;
        AbstractHealCommand(null, target, effectValue);
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

    private void ExecSlipDamage(Character target, double effectValue)
    {
        // todo Poisonと同じのままでは毒と出血を用意した意味がない。何か別の効果を考えるべきである。
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
        target.AddBuff(Fix.EFFECT_POISON, effect_value, turn);
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_POISON, Fix.COLOR_NORMAL);
    }

    private void ExecBuffSleep(Character player, Character target, int turn, double effect_value)
    {
        target.AddBuff(Fix.EFFECT_SLEEP, effect_value, turn);
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_SLEEP, Fix.COLOR_NORMAL);
    }

    private void ExecBuffStun(Character player, Character target, int turn, double effect_value)
    {
        target.AddBuff(Fix.EFFECT_STUN, effect_value, turn);
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_STUN, Fix.COLOR_NORMAL);
    }

    private void ExecBuffDizzy(Character player, Character target, int turn, double effect_value)
    {
        target.AddBuff(Fix.EFFECT_DIZZY, effect_value, turn);
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DIZZY, Fix.COLOR_NORMAL);
    }
    
    private void BuffUpFire(Character player, Character target, int turn, double effect_value)
    {
        target.AddBuff(Fix.EFFECT_POWERUP_FIRE, effect_value, turn);
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_POWERUP_FIRE, Fix.COLOR_NORMAL);
    }

    #region "General"
    private double PhysicalDamageLogic(Character player, Character target, double magnify, CriticalType critical)
    {
        double damageValue = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * magnify;
        Debug.Log("damage-1: " + (PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random) * magnify).ToString());
        if (player.CannotCritical == false &&
            ((critical == CriticalType.Random && AP.Math.RandomInteger(100) <= 5) || (critical == CriticalType.Absolute))
           )
        {
            if (critical == CriticalType.Absolute) { Debug.Log("PhysicalDamageLogic detect Critical! (Absolute)"); }
            if (critical == CriticalType.Random) { Debug.Log("PhysicalDamageLogic detect Critical! (Random)"); }
            damageValue *= SecondaryLogic.CriticalFactor(player);
        }
        else
        {
            Debug.Log("PhysicalDamageLogic detect Normal...");
        }

        damageValue -= PrimaryLogic.PhysicalDefense(target);
        Debug.Log("damage-2: " + (PrimaryLogic.PhysicalDefense(target)).ToString());

        if (target.IsDefense) { damageValue = damageValue * SecondaryLogic.DefenseFactor(target); }
        if (damageValue <= 0) { damageValue = 0; }

        return damageValue;
    }

    private double MagicDamageLogic(Character player, Character target, double magnify, Fix.CommandAttribute attr, CriticalType critical)
    {
        double damageValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * magnify;
        if (attr == Fix.CommandAttribute.Fire && player.IsUpFire)
        {
            Debug.Log("damageValue UpFire: " + player.IsUpFire.EffectValue.ToString());
            damageValue = damageValue * player.IsUpFire.EffectValue;
        }
        if (attr == Fix.CommandAttribute.Ice && player.IsUpIce)
        {
            damageValue = damageValue * player.IsUpIce.EffectValue;
        }
        if (attr == Fix.CommandAttribute.HolyLight && player.IsUpLight)
        {
            damageValue = damageValue * player.IsUpLight.EffectValue;
        }
        if (attr == Fix.CommandAttribute.DarkMagic && player.IsUpShadow)
        {
            damageValue = damageValue * player.IsUpShadow.EffectValue;
        }

        if (player.CannotCritical == false &&
            ((critical == CriticalType.Random && AP.Math.RandomInteger(100) <= 5) || (critical == CriticalType.Absolute))
           )
        {
            if (critical == CriticalType.Absolute) { Debug.Log("MagicDamageLogic detect Critical! (Absolute)"); }
            if (critical == CriticalType.Random) { Debug.Log("MagicDamageLogic detect Critical! (Random)"); }
            damageValue *= SecondaryLogic.CriticalFactor(player);
        }
        else
        {
            Debug.Log("MagicDamageLogic detect Normal...");
        }

        damageValue -= PrimaryLogic.MagicDefense(target);

        if (damageValue <= 0) { damageValue = 0; }
        if (target.IsDefense) { damageValue = damageValue * SecondaryLogic.DefenseFactor(target); }

        return damageValue;
    }

    private bool AbstractDamageCommand(Character player, Character target, double damageValue)
    {
        Debug.Log(MethodBase.GetCurrentMethod());
        if (target.Dead)
        {
            StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
            this.NowAnimationMode = true;
            return false;
        }
        if (player.IsDizzy)
        {
            if (AP.Math.RandomInteger(100) > (int)player.IsDizzy.EffectValue)
            {
                StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
                this.NowAnimationMode = true;
                return false;
            }
        }

        if (damageValue <= 0) { damageValue = 0; }

        int result = (int)damageValue;
        Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " damage");
        target.CurrentLife -= result;
        target.txtLife.text = target.CurrentLife.ToString();
        StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL);

        return true;
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

        if (healValue <= 0) { healValue = 0; }
        // if (target.IsDefense) { damageValue = damageValue / 3.0f; } // 回復なので、防御軽減は対象外。

        int result = (int)healValue;
        Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " heal");
        target.CurrentLife += result;
        target.txtLife.text = target.CurrentLife.ToString();
        StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_HEAL);

        return true;
    }
    #endregion
}

