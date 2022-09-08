using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class NodeBackpackItem : MonoBehaviour
{
  public Image imgIcon;
  public Text txtName;
  public Text txtItemNum;
  public Image background;
  public Image imgSelect;
  public int BackpackNumber;

  public void Construct(GameObject content, string item_name, int item_num, int num, int counter)
  {
    this.transform.SetParent(content.transform);
    this.BackpackNumber = num;

    Item current = new Item(item_name);

    this.name = item_name;
    if (this.txtName != null)
    {
      this.txtName.text = item_name;
      this.txtName.color = current.GetRareTextColor;
    }
    if (this.txtItemNum != null)
    {
      this.txtItemNum.text = "x " + item_num.ToString();
      this.txtItemNum.color = current.GetRareTextColor;
    }
    this.background.color = current.GetRareColor;

    if (this.imgIcon != null)
    {
      this.imgIcon.sprite = Resources.Load<Sprite>("Icon_" + current?.ItemType.ToString() ?? "");
    }

    Text[] txtList = this.GetComponentsInChildren<Text>();
    for (int ii = 0; ii < txtList.Length; ii++)
    {
      if (txtList[ii].name == "txtEquipItem")
      {
        txtList[ii].text = item_name;
      }
    }
    this.gameObject.SetActive(true);

    const int HEIGHT = 76;
    RectTransform rect = this.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    rect.sizeDelta = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, -counter * HEIGHT, 0);

    content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x, content.GetComponent<RectTransform>().sizeDelta.y + HEIGHT);
  }
}
