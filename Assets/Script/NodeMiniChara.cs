using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class NodeMiniChara : MonoBehaviour
{
  public Text txtName;
  public Text txtLife;
  public Image imgLifeGauge;

  public void Refresh(Character character)
  {
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

    GetComponent<Image>().color = new Color(character.BattleBackColor.r, character.BattleBackColor.g, character.BattleBackColor.b, 0.7f);
    this.gameObject.SetActive(true);
  }
}
