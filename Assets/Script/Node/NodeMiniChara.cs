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
  public Text txtSP;
  public Image imgSPGauge;
  public Image imgBackColor;

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

    if (txtSP != null)
    {
      txtSP.text = character.CurrentSoulPoint.ToString() + " / " + character.MaxSoulPoint.ToString();
    }

    if (imgSPGauge != null)
    {
      float dx = (float)character.CurrentSoulPoint / (float)character.MaxSoulPoint;
      imgSPGauge.rectTransform.localScale = new Vector3(dx, 1.0f);
    }

    if (imgBackColor != null)
    {
      imgBackColor.color = new Color(character.BattleBackColor.r, character.BattleBackColor.g, character.BattleBackColor.b, 0.7f);
    }
  }
}
