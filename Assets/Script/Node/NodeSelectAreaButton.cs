using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeSelectAreaButton : MonoBehaviour
{
  public Text txtName;
  public Image imgFilter;
  public Image imgIcon;

  public void ApplyImageIcon(string icon_name)
  {
    if (imgIcon != null)
    {
      imgIcon.sprite = Resources.Load<Sprite>(icon_name);
    }
  }
}
