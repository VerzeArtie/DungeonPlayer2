using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
  protected int _enableBGM = 100;
  protected int _enableSound = 100;
  protected int _difficulty = 3;
  protected bool _supportLog = true;
  protected string _account = string.Empty;

  public int EnableBGM { get { return _enableBGM; } set { _enableBGM = value; } }
  public int EnableSoundEffect { get { return _enableSound; } set { _enableSound = value; } }
  public int Difficulty { get { return _difficulty; } set { _difficulty = value; } }
  public bool SupportLog { get { return _supportLog; } set { _supportLog = value; } }
  public string Account { get { return _account; } set { _account = value; } }
}
