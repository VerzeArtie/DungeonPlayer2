﻿using System;
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
    actionList.Add(Fix.Stay);
    actionList.Add(Fix.Stay);
    actionList.Add(Fix.Stay);
    actionList.Add(Fix.Stay);
    actionList.Add(Fix.Stay);
    actionList.Add(Fix.Stay);
    actionList.Add(Fix.Stay);
    actionList.Add(Fix.Stay);
    actionList.Add(Fix.Stay);
    actionList.Add(Fix.Stay);
    this.ActionCommandList = actionList;
    this.CurrentActionCommand = String.Empty;

    this.BattleBackColor = Fix.COLOR_FIRST_CHARA;
    this.BattleForeColor = Fix.COLORFORE_FIRST_CHARA;

    switch (character_name)
    {
      case Fix.NAME_EIN_WOLENCE:
        this.Level = 1;
        this.Strength = 9;
        this.Agility = 6;
        this.Intelligence = 3;
        this.Stamina = 7;
        this.Mind = 3;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Brave;
        this.BattleBackColor = Fix.COLOR_FIRST_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIRST_CHARA;
        //this.MainWeapon = new Item(Fix.FINE_SWORD);
        break;

      case Fix.NAME_LANA_AMIRIA:
        this.Level = 1;
        this.Strength = 7;
        this.Agility = 5;
        this.Intelligence = 8;
        this.Stamina = 5;
        this.Mind = 3;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Brave;
        this.BattleBackColor = Fix.COLOR_FIRST_CHARA;
        this.BattleForeColor = Fix.COLORFORE_FIRST_CHARA;
        break;

      case Fix.NAME_EONE_FULNEA:
        this.Level = 1;
        this.Strength = 6;
        this.Agility = 6;
        this.Intelligence = 9;
        this.Stamina = 4;
        this.Mind = 3;
        this.Job = Fix.JobClass.Magician;
        this.FirstCommandAttribute = Fix.CommandAttribute.HolyLight;
        this.SecondCommandAttribute = Fix.CommandAttribute.Ice;
        this.ThirdCommandAttribute = Fix.CommandAttribute.Mindfulness;
        this.BattleBackColor = Fix.COLOR_THIRD_CHARA;
        this.BattleForeColor = Fix.COLORFORE_THIRD_CHARA;
        break;

      case Fix.NAME_MAGI_ZELKIS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_SELMOI_RO:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_KARTIN_MAI:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_JEDA_ARUS:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_SINIKIA_VEILHANZ:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_ADEL_BRIGANDY:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_BILLY_RAKI:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_CALMANS_OHN:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;

      case Fix.NAME_SUN_YU:
        this.Level = 1;
        this.Strength = 1;
        this.Agility = 1;
        this.Intelligence = 1;
        this.Stamina = 1;
        this.Mind = 1;
        this.Job = Fix.JobClass.Fighter;
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
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
        this.FirstCommandAttribute = Fix.CommandAttribute.Swordman;
        this.SecondCommandAttribute = Fix.CommandAttribute.Fire;
        this.ThirdCommandAttribute = Fix.CommandAttribute.EnhanceForm;
        break;
    }

    MaxGain();
  }
}