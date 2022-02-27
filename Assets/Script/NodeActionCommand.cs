using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeActionCommand : MonoBehaviour
{
  public Image BackColor;
  public string CommandName;
  public string OwnerName;
  public Button ActionButton;

  public void ApplyImageIcon(string command_name)
  {
    if (command_name == Fix.SMALL_RED_POTION)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("RedPotion");
    }
    else if (command_name == Fix.SMALL_BLUE_POTION)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("BluePotion");
    }
    else
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(command_name);
    }
  }
}
