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
    }

    MaxGain();
  }
}