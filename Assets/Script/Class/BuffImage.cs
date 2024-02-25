using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

  [SerializeField] protected double _effectValue2 = 0;
  public double EffectValue2
  {
    set { _effectValue2 = value; }
    get { return _effectValue2; }
  }

  [SerializeField] protected double _effectValue3 = 0;
  public double EffectValue3
  {
    set { _effectValue3 = value; }
    get { return _effectValue3; }
  }

  [SerializeField] protected int _cumulative = 0;
  public int Cumulative
  {
    set
    {
      if (value >= _cumulativeMax) { value = _cumulativeMax; }
      if (value <= 0) { value = 0; }
      _cumulative = value;
    }
    get { return _cumulative; }
  }

  [SerializeField] protected int _cumulativeMax = 1; // 累積は最低1必要のため、初期値1とする。
  public int CumulativeMax
  {
    set
    {
      if (value <= 1) { value = 1; }
      _cumulativeMax = value;
    }
    get { return _cumulativeMax; }
  }

  [SerializeField] protected int _remainCounter = 0;
  public int RemainCounter
  {
    set { _remainCounter = value; }
    get { return _remainCounter; }
  }

  public void UpdateBuff(string buff_name, int remain, int cumulative, int cumulative_max, double effect_value, double effect_value2, double effect_value3)
  {
    this._buffName = buff_name;
    this._remainCounter = remain;
    this._effectValue = effect_value;
    this._effectValue2 = effect_value2;
    this._effectValue3 = effect_value3;
    this._cumulative = cumulative;
    this._cumulativeMax = cumulative_max;
    this.sprite = Resources.Load<Sprite>(buff_name);
    Invalidate();
  }

  public void CumulativeUp(int remain, int cumulative_up)
  {
    this._remainCounter = remain;
    this.Cumulative = this._cumulative + cumulative_up;
    Invalidate();
  }

  public void CumulativeDown(int cumulative_down)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + cumulative_down);
    this.Cumulative = this._cumulative - cumulative_down;
    if (this.Cumulative <= 0)
    {
      Debug.Log(MethodBase.GetCurrentMethod() + " Cumulative is less than zero, then remove it");
      RemoveBuff();
    }
    else
    {
      Debug.Log(MethodBase.GetCurrentMethod() + " Cumulative is remaining: " + this.Cumulative);
    }
    Invalidate();
  }

  public void RemoveBuff()
  {
    this._buffName = String.Empty;
    this._remainCounter = 0;
    this._effectValue = 0;
    this._effectValue2 = 0;
    this._effectValue3 = 0;
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
      if (CumulativeMax > 1) // 累積最大数が１より大きいなら累積カウントの対象であるため表示する。
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
