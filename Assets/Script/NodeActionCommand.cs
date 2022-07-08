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
    // todo
    if (command_name == Fix.SMALL_RED_POTION ||
        command_name == Fix.NORMAL_RED_POTION)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("RedPotion");
    }
    else if (command_name == Fix.SMALL_BLUE_POTION ||
             command_name == Fix.NORMAL_BLUE_POTION)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("BluePotion");
    }
    else if (command_name == Fix.PURE_CLEAN_WATER)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("PureCleanWater");
    }
    else if (command_name == Fix.ARCHETYPE_EIN_1)
    {
      ActionButton.image.sprite = Resources.Load<Sprite>("SYUTYU-DANZETSU");
    }
    else
    {
      ActionButton.image.sprite = Resources.Load<Sprite>(command_name);
    }
  }
}
