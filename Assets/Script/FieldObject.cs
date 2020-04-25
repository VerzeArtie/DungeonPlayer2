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
    Boss,
  }

  public string ObjectName { get; set; }
  public Content content = Content.None;
}
