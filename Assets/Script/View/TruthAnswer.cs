using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class TruthAnswer : MotherBase
{
  public List<GameObject> objListMessage;
  public List<Text> txtChant;

  public int CurrentChantNumber = 1; // 初期値１で良い。

  public bool nowAutoKill = false;
  public int nowAutoKillTimer = 0;
  public bool nowAutoKillEnd = false;

  // Start is called before the first frame update
  public override void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (this.nowAutoKill && this.nowAutoKillEnd == false)
    {
      nowAutoKillTimer++;
      if (nowAutoKillTimer >= 150)
      {
        this.nowAutoKillEnd = true;
        SceneDimension.SceneClose(Fix.SCENE_TRUTH_ANSWER);
      }
    }
  }

  public void TapVelgusChantButton(int number)
  {
    Debug.Log(MethodBase.GetCurrentMethod().Name + " " + number.ToString());

    if (CurrentChantNumber == 1) { txtChant[number-1].text = "鳥"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false);  CurrentChantNumber++; }
    else if (CurrentChantNumber == 2) { txtChant[number - 1].text = "天"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 3) { txtChant[number - 1].text = "闇"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 4) { txtChant[number - 1].text = "水"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 5) { txtChant[number - 1].text = "火"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 6) { txtChant[number - 1].text = "嵐"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 7) { txtChant[number - 1].text = "死"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 8) { txtChant[number - 1].text = "生"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 9) { txtChant[number - 1].text = "神"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 10) { txtChant[number - 1].text = "人"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 11) { txtChant[number - 1].text = "理"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 12) { txtChant[number - 1].text = "空"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 13) { txtChant[number - 1].text = "相"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 14) { txtChant[number - 1].text = "永"; txtChant[number - 1].gameObject.SetActive(true); objListMessage[CurrentChantNumber - 1].SetActive(false); CurrentChantNumber++; }
    else if (CurrentChantNumber == 15) { txtChant[number - 1].text = "世"; txtChant[number - 1].gameObject.SetActive(true);/*objListMessage[CurrentChantNumber - 1].SetActive(false);*/ CurrentChantNumber++; }
    else { Debug.Log("Wrong Chant Sequence...please debug it"); }

    if (CurrentChantNumber >= 16)
    {
      List<int> numberList = new List<int>();
      numberList.Add(One.AR.Velgus_Chant_Sequence_1);
      numberList.Add(One.AR.Velgus_Chant_Sequence_2);
      numberList.Add(One.AR.Velgus_Chant_Sequence_3);
      numberList.Add(One.AR.Velgus_Chant_Sequence_4);
      numberList.Add(One.AR.Velgus_Chant_Sequence_5);
      numberList.Add(One.AR.Velgus_Chant_Sequence_6);
      numberList.Add(One.AR.Velgus_Chant_Sequence_7);
      numberList.Add(One.AR.Velgus_Chant_Sequence_8);
      numberList.Add(One.AR.Velgus_Chant_Sequence_9);
      numberList.Add(One.AR.Velgus_Chant_Sequence_10);
      numberList.Add(One.AR.Velgus_Chant_Sequence_11);
      numberList.Add(One.AR.Velgus_Chant_Sequence_12);
      numberList.Add(One.AR.Velgus_Chant_Sequence_13);
      numberList.Add(One.AR.Velgus_Chant_Sequence_14);
      numberList.Add(One.AR.Velgus_Chant_Sequence_15);


      // 最終判定前の補完処理：0 のままの要素に未使用の値をランダムに代入
      List<int> remainingValues = Enumerable.Range(1, 15).Except(numberList.Where(v => v != 0)).ToList();
      System.Random rand = new System.Random();
      Shuffle(remainingValues, rand);

      for (int i = 0, j = 0; i < numberList.Count; i++)
      {
        if (numberList[i] == 0)
        {
          numberList[i] = remainingValues[j++];
        }
      }

      Debug.Log("Velgus_Chant_Sequence before");
      Debug.Log("1: " + One.AR.Velgus_Chant_Sequence_1);
      Debug.Log("2: " + One.AR.Velgus_Chant_Sequence_2);
      Debug.Log("3: " + One.AR.Velgus_Chant_Sequence_3);
      Debug.Log("4: " + One.AR.Velgus_Chant_Sequence_4);
      Debug.Log("5: " + One.AR.Velgus_Chant_Sequence_5);
      Debug.Log("6: " + One.AR.Velgus_Chant_Sequence_6);
      Debug.Log("7: " + One.AR.Velgus_Chant_Sequence_7);
      Debug.Log("8: " + One.AR.Velgus_Chant_Sequence_8);
      Debug.Log("9: " + One.AR.Velgus_Chant_Sequence_9);
      Debug.Log("10: " + One.AR.Velgus_Chant_Sequence_10);
      Debug.Log("11: " + One.AR.Velgus_Chant_Sequence_11);
      Debug.Log("12: " + One.AR.Velgus_Chant_Sequence_12);
      Debug.Log("13: " + One.AR.Velgus_Chant_Sequence_13);
      Debug.Log("14: " + One.AR.Velgus_Chant_Sequence_14);
      Debug.Log("15: " + One.AR.Velgus_Chant_Sequence_15);


      One.AR.Velgus_Chant_Sequence_1 = numberList[0];
      One.AR.Velgus_Chant_Sequence_2 = numberList[1];
      One.AR.Velgus_Chant_Sequence_3 = numberList[2];
      One.AR.Velgus_Chant_Sequence_4 = numberList[3];
      One.AR.Velgus_Chant_Sequence_5 = numberList[4];
      One.AR.Velgus_Chant_Sequence_6 = numberList[5];
      One.AR.Velgus_Chant_Sequence_7 = numberList[6];
      One.AR.Velgus_Chant_Sequence_8 = numberList[7];
      One.AR.Velgus_Chant_Sequence_9 = numberList[8];
      One.AR.Velgus_Chant_Sequence_10 = numberList[9];
      One.AR.Velgus_Chant_Sequence_11 = numberList[10];
      One.AR.Velgus_Chant_Sequence_12 = numberList[11];
      One.AR.Velgus_Chant_Sequence_13 = numberList[12];
      One.AR.Velgus_Chant_Sequence_14 = numberList[13];
      One.AR.Velgus_Chant_Sequence_15 = numberList[14];
      Debug.Log("Velgus_Chant_Sequence result");
      Debug.Log("1: " + One.AR.Velgus_Chant_Sequence_1);
      Debug.Log("2: " + One.AR.Velgus_Chant_Sequence_2);
      Debug.Log("3: " + One.AR.Velgus_Chant_Sequence_3);
      Debug.Log("4: " + One.AR.Velgus_Chant_Sequence_4);
      Debug.Log("5: " + One.AR.Velgus_Chant_Sequence_5);
      Debug.Log("6: " + One.AR.Velgus_Chant_Sequence_6);
      Debug.Log("7: " + One.AR.Velgus_Chant_Sequence_7);
      Debug.Log("8: " + One.AR.Velgus_Chant_Sequence_8);
      Debug.Log("9: " + One.AR.Velgus_Chant_Sequence_9);
      Debug.Log("10: " + One.AR.Velgus_Chant_Sequence_10);
      Debug.Log("11: " + One.AR.Velgus_Chant_Sequence_11);
      Debug.Log("12: " + One.AR.Velgus_Chant_Sequence_12);
      Debug.Log("13: " + One.AR.Velgus_Chant_Sequence_13);
      Debug.Log("14: " + One.AR.Velgus_Chant_Sequence_14);
      Debug.Log("15: " + One.AR.Velgus_Chant_Sequence_15);

      if ( txtChant[One.AR.Velgus_Chant_Sequence_1 - 1].text == "鳥" &&
           txtChant[One.AR.Velgus_Chant_Sequence_2 - 1].text == "天" &&
           txtChant[One.AR.Velgus_Chant_Sequence_3 - 1].text == "闇" &&
           txtChant[One.AR.Velgus_Chant_Sequence_4 - 1].text == "水" &&
           txtChant[One.AR.Velgus_Chant_Sequence_5 - 1].text == "火" &&
           txtChant[One.AR.Velgus_Chant_Sequence_6 - 1].text == "嵐" &&
           txtChant[One.AR.Velgus_Chant_Sequence_7 - 1].text == "死" &&
           txtChant[One.AR.Velgus_Chant_Sequence_8 - 1].text == "生" &&
           txtChant[One.AR.Velgus_Chant_Sequence_9 - 1].text == "神" &&
           txtChant[One.AR.Velgus_Chant_Sequence_10 - 1].text == "人" &&
           txtChant[One.AR.Velgus_Chant_Sequence_11 - 1].text == "理" &&
           txtChant[One.AR.Velgus_Chant_Sequence_12 - 1].text == "空" &&
           txtChant[One.AR.Velgus_Chant_Sequence_13 - 1].text == "相" &&
           txtChant[One.AR.Velgus_Chant_Sequence_14 - 1].text == "永" &&
           txtChant[One.AR.Velgus_Chant_Sequence_15 - 1].text == "世")
      {
        One.TF.Event_Message1000040_VelgusChantSuccess = true;
      }
      else
      {
        One.TF.Event_Message1000040_VelgusChantSuccess = false;
      }
      this.nowAutoKill = true;
    }
  }

  // Fisher-Yates シャッフル
  static void Shuffle<T>(List<T> list, System.Random rand)
  {
    for (int i = list.Count - 1; i > 0; i--)
    {
      int j = rand.Next(i + 1);
      (list[i], list[j]) = (list[j], list[i]);
    }
  }
}
