using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DamageObject : MonoBehaviour
{
  [SerializeField] protected int _maxTime = 0;
  public int MaxTime
  {
    get { return _maxTime; }
    set { _maxTime = value; }
  }

  [SerializeField] protected int _timer = 0;
  public int Timer
  {
    get { return _timer; }
    set { _timer = value; }
  }

  [SerializeField] protected string _message = String.Empty;
  public string Message
  {
    get { return _message; }
    set { _message = value; }
  }

  [SerializeField] protected bool _firstLook = false;
  public bool FirstLook
  {
    get { return _firstLook; }
    set 
    {
      _firstLook = value;
      if (_firstLook)
      {
        txtMessage.text = _message;
      }
    }
  }

  [SerializeField] protected int _chainNumber = 0;
  public int ChainNumber
  {
    get { return _chainNumber; }
    set { _chainNumber = value; }
  }

  public Text txtMessage;

  public void Construct(string message, int chain_num, Color color, int timer)
  {
    _message = message;
    _chainNumber = chain_num;
    _timer = timer;
    _maxTime = timer;
    _firstLook = false;
    txtMessage.text = String.Empty; // message;
    txtMessage.color = color;
  }
}
