using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class NodeBattleChara : MonoBehaviour
{
  public GameObject ParentPanel;
  public Text txtPlayerName;
  public Text txtPlayerLife;
  public Image objBackLifeGauge;
  public Image objCurrentLifeGauge;
  public Image objCurrentLifeBorder;
  public Image objBackInstantGauge;
  public Image objCurrentInstantGauge;
  public NodeActionCommand objMainButton;
  public Text txtActionCommand;
  public GameObject groupActionPoint;
  public BuffField groupBuff;
  public Text txtTargetName;
  public Image imgTargetLifeGauge;
  public Image objBackManaPointGauge;
  public Image objCurrentManaPointGauge;
  public Image objCurrentManaPointBorder;
  public Text txtManaPoint;
  public Image objBackSkillPointGauge;
  public Image objCurrentSkillPointGauge;
  public Image objCurrentSkillPointBorder;
  public Text txtSkillPoint;
  public NodeActionCommand objImmediateCommand;
  public GameObject GroupActionCommand;
  public List<NodeActionCommand> ActionCommandList;
  public GameObject GroupManaPoint;
  public GameObject GroupSkillPoint;
  public BuffField GroupTimeSequenceField;
}
