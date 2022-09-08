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
    if (command_name == Fix.SMALL_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_1); }
    else if (command_name == Fix.NORMAL_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_2); }
    else if (command_name == Fix.LARGE_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_3); }
    else if (command_name == Fix.HUGE_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_4); }
    else if (command_name == Fix.HQ_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_5); }
    else if (command_name == Fix.THQ_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_6); }
    else if (command_name == Fix.PERFECT_RED_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_RED_POTION_7); }
    else if (command_name == Fix.SMALL_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_1); }
    else if (command_name == Fix.NORMAL_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_2); }
    else if (command_name == Fix.LARGE_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_3); }
    else if (command_name == Fix.HUGE_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_4); }
    else if (command_name == Fix.HQ_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_5); }
    else if (command_name == Fix.THQ_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_6); }
    else if (command_name == Fix.PERFECT_BLUE_POTION) { ActionButton.image.sprite = Resources.Load<Sprite>(Fix.USE_BLUE_POTION_7); }
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
