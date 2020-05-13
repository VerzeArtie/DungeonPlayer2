using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class FieldObject : MonoBehaviour
{
  public enum Content
  {
    None = 0,
    Treasure,
    Rock,
    Character,
    Fountain,
    MessageBoard,
    Door_Copper,
    Door_Silver,
    Door_Gold,
    Boss,
  }

  public Content content = Content.None;

  public string ObjectId = String.Empty;
}
