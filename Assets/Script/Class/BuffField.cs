using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffField : MonoBehaviour
{
  public void AddBuff(BuffImage prefab, string buff_name, int remain_counter, double effect_value, double effect_value2, double effect_value3)
  {
    Debug.Log("AddBuff(S)");
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
        Debug.Log("AddBuff target: " + buff_name + buffList[ii].EffectValue + " " + buffList[ii].EffectValue2 + " " + buffList[ii].EffectValue3);
        detect = true;
        if (ActionCommand.CumulativeMax(buff_name) > 1) // 1つより大きければ累積
        {
          Debug.Log("AddBuff CumulativeMax(buff_name) greater: " + ActionCommand.CumulativeMax(buff_name));
          int up = 1;
          if (ActionCommand.GetCumulativeType(buff_name) == ActionCommand.CumulativeType.Cumulative) { up = (int)effect_value; }
          Debug.Log("AddBuff CumulativeUp: " + remain_counter + " " + up);
          buffList[ii].CumulativeUp(remain_counter, up);
        }
        else
        {
          Debug.Log("AddBuff CumulativeMax(buff_name) less than: " + ActionCommand.CumulativeMax(buff_name));
          buffList[ii].UpdateBuff(buff_name, remain_counter, 1, ActionCommand.CumulativeMax(buff_name), effect_value, effect_value2, effect_value3);// 累積は標準１がデフォルトで与えられる。
        }
        break;
      }
    }
    if (detect) { return; }

    Debug.Log("AddBuff not detect already buff, then add it: " + buff_name);

    // 該当BUFFが無い場合は、BUFFオブジェクトを追加する。
    BuffImage buff = Instantiate(prefab) as BuffImage;
    int cumulative = 1;// 累積は標準１がデフォルトで与えられる。
    if (ActionCommand.GetCumulativeType(buff_name) == ActionCommand.CumulativeType.Cumulative)
    {
      Debug.Log("AddBuff target is cumulative");
      cumulative = (int)effect_value;
    }
    else
    {
      Debug.Log("AddBuff target is normal ( not cumulative )");
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
    Debug.Log("AddBuff(E)");
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

  public void ResetAllBuff()
  {
    BuffImage[] buffList = this.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    for (int ii = buffList.Length - 1; ii >= 0; ii--)
    {
      if (buffList[ii].BuffName == Fix.LIFE_POINT)
      {
        continue;
      }
      buffList[ii].RemoveBuff();
    }
  }

  public void RemoveAll(Character target)
  {
    Debug.Log("RemoveAll(S)");
    BuffImage[] buffList = this.GetComponentsInChildren<BuffImage>();
    if (buffList == null) { return; }

    // 既に該当BUFFがあるかどうかを確認。
    for (int ii = buffList.Length - 1; ii >= 0; ii--)
    {
      Debug.Log(target.FullName + " bufflist[ii].buffname : " + buffList[ii].BuffName + " " + ActionCommand.GetBuffType(buffList[ii].BuffName));

      if (target.SearchFieldBuff(Fix.DETACHMENT_FAULT))
      {
        Debug.Log("DETACHMENT_FAULT ignore it");
        continue; // アニメーションでないため分かり難いが、まずこれで良しとする。
      }

      BuffImage transcendenceReached = target.IsTranscendenceReached;
      if (transcendenceReached && ActionCommand.GetBuffType(buffList[ii].BuffName) == Fix.BuffType.Positive)
      {
        Debug.Log("IsTranscendenceReached ignore it");
        continue; // アニメーションでないため分かり難いが、まずこれで良しとする。
      }

      BuffImage innocentCircle = target.IsInnocentCircle;
      if (innocentCircle && ActionCommand.GetBuffType(buffList[ii].BuffName) == Fix.BuffType.Positive)
      {
        Debug.Log("IsInnocentCircle ignore it");
        continue; // アニメーションでないため分かり難いが、まずこれで良しとする。
      }

      if (buffList[ii].BuffName == Fix.LIFE_POINT)
      {
        continue;
      }

      Debug.Log("remove it");
      buffList[ii].RemoveBuff();
    }
  }
}
