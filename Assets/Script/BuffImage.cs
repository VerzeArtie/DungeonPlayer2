using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BuffImage : Image
{
  [SerializeField] public Text txtRemainCounter;
  [SerializeField] public GameObject objRemainCounter;
  public Text txtCumulativeCounter;
  public GameObject objCumulativeCounter;

  [SerializeField] protected string _buffName = String.Empty;
  public string BuffName
  {
    set { _buffName = value; }
    get { return _buffName; }
  }

  [SerializeField] protected double _effectValue = 0;
  public double EffectValue
  {
    set { _effectValue = value; }
    get { return _effectValue; }
  }

  [SerializeField] protected int _cumulative = 0;
  public int Cumulative
  {
    set
    {
      if (value >= 5) { value = 5; }
      _cumulative = value;
    }
    get { return _cumulative; }
  }

  [SerializeField] protected int _remainCounter = 0;
  public int RemainCounter
  {
    set { _remainCounter = value; }
    get { return _remainCounter; }
  }

  public void UpdateBuff(string buff_name, int remain, double effect_value)
  {
    this._buffName = buff_name;
    this._remainCounter = remain;
    this._effectValue = effect_value;
    this._cumulative = 1; // 累積は標準１がデフォルトで与えられる。
    this.sprite = Resources.Load<Sprite>(buff_name);
    Invalidate();
  }

  public void CumulativeUp(int remain, int cumulative_up)
  {
    this._remainCounter = remain;
    this.Cumulative = this._cumulative + cumulative_up;
    Invalidate();
  }

  public void RemoveBuff()
  {
    this._buffName = String.Empty;
    this._remainCounter = 0;
    this._effectValue = 0;
    this._cumulative = 0;
    this.sprite = Resources.Load<Sprite>("Buff_Empty");
    Destroy(this.gameObject);
  }

  public void BuffCountDown()
  {
    if (this._remainCounter > 0)
    {
      this._remainCounter--;
      if (this._remainCounter <= 0)
      {
        RemoveBuff();
      }
      Invalidate();
    }
  }

  private void Invalidate()
  {
    if (this.txtRemainCounter != null)
    {
      if (this._remainCounter >= 10)
      {
        this.txtRemainCounter.text = "-";
      }
      else
      {
        this.txtRemainCounter.text = _remainCounter.ToString();
      }
    }

    if (this.objCumulativeCounter != null)
    {
      if (this.BuffName == Fix.BUFF_PD_DOWN) // todo その書き方はコード体系としてよろしくない。
      {
        this.objCumulativeCounter.SetActive(true);
      }
      else
      {
        this.objCumulativeCounter.SetActive(false);
      }
      if (this.txtCumulativeCounter != null)
      {
        this.txtCumulativeCounter.text = this._cumulative.ToString();
      }
    }
  }
}
