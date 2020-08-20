using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DamageObject : MonoBehaviour
{
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

  public Text txtMessage;

  public void Construct(string message, Color color, int timer)
  {
    _message = message;
    _timer = timer;
    _firstLook = false;
    txtMessage.text = String.Empty; // message;
    txtMessage.color = color;
  }
}
