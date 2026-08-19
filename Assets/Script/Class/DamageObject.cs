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

  // フェードで alpha を変えるため、元の色を保持する。シーンへ書き出す必要はないので SerializeField は付けない。
  protected Color _baseColor = Color.white;

  // 出現時の拡大率。ここから1.0へ縮めてポップさせる。
  private const float POP_START_SCALE = 1.6f;

  public void Construct(string message, int chain_num, Color color, int timer)
  {
    _message = message;
    _chainNumber = chain_num;
    _timer = timer;
    _maxTime = timer;
    _firstLook = false;
    _baseColor = color;
    txtMessage.text = String.Empty; // message;
    txtMessage.color = color;
    txtMessage.rectTransform.localScale = new Vector3(POP_START_SCALE, POP_START_SCALE, 1.0f);
  }

  /// <summary>
  /// 経過に応じて見た目を更新する。出現直後は大きさが縮むポップ、消える手前で不透明度が落ちる。
  /// ポップとフェードの長さは MaxTime 比で決めるため、短い演出でも比率が保たれる。
  /// </summary>
  public void ApplyPopAndFade()
  {
    if (txtMessage == null) { return; }
    if (_maxTime <= 0) { return; }

    int popFrame = Mathf.Max(2, _maxTime / 8);
    int fadeFrame = Mathf.Max(3, _maxTime / 4);
    int elapsed = _maxTime - _timer;

    float scale = 1.0f;
    if (elapsed < popFrame)
    {
      scale = Mathf.Lerp(POP_START_SCALE, 1.0f, (float)elapsed / (float)popFrame);
    }
    txtMessage.rectTransform.localScale = new Vector3(scale, scale, 1.0f);

    float alpha = 1.0f;
    if (_timer < fadeFrame)
    {
      alpha = (float)_timer / (float)fadeFrame;
    }
    txtMessage.color = new Color(_baseColor.r, _baseColor.g, _baseColor.b, alpha);
  }
}
