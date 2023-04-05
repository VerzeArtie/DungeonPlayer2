using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class NodeMiniChara : MonoBehaviour
{
  public GameObject groupParent;
  public Text txtName;
  public Text txtLife;
  public Image imgLifeGauge;
  public Image imgBackLifeColor;

  public Text txtManaPoint;
  public Image imgManaPointGauge;
  public Image imgBackManaPointColor;

  public Text txtSkillPoint;
  public Image imgSkillPointGauge;
  public Image imgBackSkillPointColor;

  public void Refresh(Character character)
  {
    this.gameObject.SetActive(true);

    if (character == null) { return; }

    if (txtName != null)
    {
      txtName.text = character.FullName;
    }

    if (txtLife != null)
    {
      txtLife.text = character.CurrentLife.ToString() + " / " + character.MaxLife.ToString();
    }

    if (imgLifeGauge != null)
    {
      float dx = (float)character.CurrentLife / (float)character.MaxLife;
      imgLifeGauge.rectTransform.localScale = new Vector3(dx, 1.0f);
    }

    if (imgBackLifeColor != null)
    {
      imgBackLifeColor.color = new Color(character.BattleBackColor.r, character.BattleBackColor.g, character.BattleBackColor.b, 0.7f);
    }

    if (txtManaPoint != null)
    {
      txtManaPoint.text = character.CurrentManaPoint.ToString() + " / " + character.MaxManaPoint.ToString();
    }

    if (imgManaPointGauge != null)
    {
      float dx = (float)character.CurrentManaPoint / (float)character.MaxManaPoint;
      imgManaPointGauge.rectTransform.localScale = new Vector3(dx, 1.0f);
    }

    if (imgBackManaPointColor != null)
    {
      imgBackManaPointColor.color = new Color(character.BattleBackColor.r, character.BattleBackColor.g, character.BattleBackColor.b, 0.7f);
    }

    if (txtSkillPoint != null)
    {
      txtSkillPoint.text = character.CurrentSkillPoint.ToString() + " / " + character.MaxSkillPoint.ToString();
    }

    if (imgSkillPointGauge != null)
    {
      float dx = (float)character.CurrentSkillPoint / (float)character.MaxSkillPoint;
      imgSkillPointGauge.rectTransform.localScale = new Vector3(dx, 1.0f);
    }

    if (imgBackSkillPointColor != null)
    {
      imgBackSkillPointColor.color = new Color(character.BattleBackColor.r, character.BattleBackColor.g, character.BattleBackColor.b, 0.7f);
    }

  }
}
