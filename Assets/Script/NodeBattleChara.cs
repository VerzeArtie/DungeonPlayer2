﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class NodeBattleChara : MonoBehaviour
{
  public Text txtPlayerName;
  public Text txtPlayerLife;
  public Image objBackLifeGauge;
  public Image objCurrentLifeGauge;
  public Image objCurrentLifeBorder;
  public Image objBackInstantGauge;
  public Image objCurrentInstantGauge;
  public Button objMainButton;
  public Text txtActionCommand;
  public GameObject groupActionPoint;
  public GameObject groupBuff;
  public Text txtTargetName;
  public Image imgTargetLifeGauge;
  public Image objBackSoulPointGauge;
  public Image objCurrentSoulPointGauge;
  public Image objCurrentSoulPointBorder;
  public Text txtSoulPoint;
}
