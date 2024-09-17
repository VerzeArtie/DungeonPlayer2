using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffField : MonoBehaviour
{
  public void AddBuff(BuffImage prefab, string buff_name, int remain_counter, double effect_value, double effect_value2, double effect_value3)
  {
    bool detect = false;

    if (prefab == null) { return; }

    // unity潜在バグの可能性。null合体演算子、厳密にはnull判定かどうかを行おうとした時、
    // missing exceptionが発生するので、null合体演算子はここでは使わない。
    //BuffImage[] buffList = this.GetComponentsInChildren<BuffImage>() ?? null;
    BuffImage[] buffList = this.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    // 既に該当BUFFがあるかどうかを確認。
    for (int ii = 0; ii < buffList.Length; ii++)
    {
      if (buffList[ii].BuffName == buff_name)
      {
        detect = true;
        if (ActionCommand.CumulativeMax(buff_name) > 1) // 1つより大きければ累積
        {
          int up = 1;
          if (ActionCommand.GetCumulativeType(buff_name) == ActionCommand.CumulativeType.Cumulative) { up = (int)effect_value; }
          buffList[ii].CumulativeUp(remain_counter, up);
        }
        else
        {
          buffList[ii].UpdateBuff(buff_name, remain_counter, 1, ActionCommand.CumulativeMax(buff_name), effect_value, effect_value2, effect_value3);// 累積は標準１がデフォルトで与えられる。
        }
        break;
      }
    }
    if (detect) { return; }

    // 該当BUFFが無い場合は、BUFFオブジェクトを追加する。
    BuffImage buff = Instantiate(prefab) as BuffImage;
    int cumulative = 1;// 累積は標準１がデフォルトで与えられる。
    if (ActionCommand.GetCumulativeType(buff_name) == ActionCommand.CumulativeType.Cumulative)
    {
      cumulative = (int)effect_value;
    }
    int cumulativeMax = ActionCommand.CumulativeMax(buff_name);
    buff.UpdateBuff(buff_name, remain_counter, cumulative, cumulativeMax, effect_value, effect_value2, effect_value3);
    buff.gameObject.SetActive(true);
    buff.transform.SetParent(this.gameObject.transform);
    //RectTransform rect = buff.GetComponent<RectTransform>();

    //rect.transform.localPosition = new Vector3(0, 0);
    //rect.anchoredPosition = new Vector2(0, 0);
    //rect.anchorMin = new Vector2(0, 0);
    //rect.anchorMax = new Vector2(1, 1);
    Canvas.ForceUpdateCanvases();
  }

  public void RemoveTargetFieldBuff(string field_buff_name)
  {
    BuffImage[] buffList = this.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    for (int ii = buffList.Length - 1; ii >= 0; ii--)
    {
      if (buffList[ii].BuffName == field_buff_name)
      {
        buffList[ii].RemoveBuff();
        return;
      }
    }
  }

  public void RemovePositiveBuffAll()
  {
    Debug.Log("RemovePositiveBuffAll(S)");
    BuffImage[] buffList = this.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    for (int ii = buffList.Length - 1; ii >= 0; ii--)
    {
      if (ActionCommand.GetBuffType(buffList[ii].BuffName) == Fix.BuffType.Positive)
      {
        buffList[ii].RemoveBuff();
      }
    }
  }

  public void RemoveNegativeBuffAll()
  {
    Debug.Log("RemoveNegativeBuffAll(S)");
    BuffImage[] buffList = this.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    for (int ii = buffList.Length - 1; ii >= 0; ii--)
    {
      if (ActionCommand.GetBuffType(buffList[ii].BuffName) == Fix.BuffType.Negative)
      {
        buffList[ii].RemoveBuff();
      }
    }
  }

  public void RemoveAll()
  {
    Debug.Log("RemoveAll(S)");
    BuffImage[] buffList = this.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    // 既に該当BUFFがあるかどうかを確認。
    for (int ii = buffList.Length - 1; ii >= 0; ii--)
    {
      buffList[ii].RemoveBuff();
    }
  }
}
