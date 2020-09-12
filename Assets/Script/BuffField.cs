using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffField : MonoBehaviour
{
  public void AddBuff(BuffImage prefab, string buff_name, int remain_counter, double effect_value, double effect_value2)
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
        if (buff_name == Fix.BUFF_PD_DOWN)
        {
          buffList[ii].CumulativeUp(remain_counter, 1);
        }
        else
        {
          buffList[ii].UpdateBuff(buff_name, remain_counter, effect_value, effect_value2);
        }
        break;
      }
    }
    if (detect) { return; }

    // 該当BUFFが無い場合は、BUFFオブジェクトを追加する。
    BuffImage buff = Instantiate(prefab) as BuffImage;
    buff.UpdateBuff(buff_name, remain_counter, effect_value, effect_value2);
    buff.gameObject.SetActive(true);
    buff.transform.SetParent(this.gameObject.transform);
    RectTransform rect = buff.GetComponent<RectTransform>();

    rect.transform.localPosition = new Vector3(0, 0);
    rect.anchoredPosition = new Vector2(0, 0);
    rect.anchorMin = new Vector2(0, 0);
    rect.anchorMax = new Vector2(1, 1);
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
