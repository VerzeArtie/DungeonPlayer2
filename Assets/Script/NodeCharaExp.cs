using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeCharaExp : MonoBehaviour
{
  public Text txtPlayerName;
  public Text txtPlayerExp;
  public Image objBackExpGauge;
  public Image objCurrentExpGauge;
  public Image objCurrentExpBorder;

  public int BeforeExpThreshold;
  public int BeforeExp;
  public int AfterExp;
}
