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

  public Text txtMessage;

  public void Construct(string message, Color color, int timer)
  {
    _message = message;
    _timer = timer;
    txtMessage.text = message;
    txtMessage.color = color;
  }
}
