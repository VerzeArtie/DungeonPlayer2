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
    public Image background;

  public void Construct(GameObject content, string item_name, int num)
  {
    this.transform.SetParent(content.transform);

    this.name = item_name;
    this.txtName.text = item_name;
    Item current = new Item(item_name);
    this.background.color = current.GetRareColor;

    this.imgIcon.sprite = Resources.Load<Sprite>("Icon_" + current?.ItemType.ToString() ?? "");


    Text[] txtList = this.GetComponentsInChildren<Text>();
    for (int ii = 0; ii < txtList.Length; ii++)
    {
      if (txtList[ii].name == "txtEquipItem")
      {
        txtList[ii].text = item_name;
      }
    }
    this.gameObject.SetActive(true);

    const int HEIGHT = 80;
    RectTransform rect = this.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    rect.sizeDelta = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, -num * HEIGHT, 0);

    content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x, content.GetComponent<RectTransform>().sizeDelta.y + HEIGHT);
  }
}
