using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class TruthAnswer : MotherBase
{
  public List<Text> txtChant;

  public int CurrentChantNumber = 1; // �����l�P�ŗǂ��B

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

    if (CurrentChantNumber == 1) { txtChant[number-1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 2) { txtChant[number - 1].text = "�V"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 3) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 4) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 5) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 6) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 7) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 8) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 9) { txtChant[number - 1].text = "�_"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 10) { txtChant[number - 1].text = "�l"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 11) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 12) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 13) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 14) { txtChant[number - 1].text = "�i"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else if (CurrentChantNumber == 15) { txtChant[number - 1].text = "��"; txtChant[number - 1].gameObject.SetActive(true); CurrentChantNumber++; }
    else { Debug.Log("Wrong Chant Sequence...please debug it"); }

    if (CurrentChantNumber >= 16)
    {
      if ( txtChant[One.AR.Velgus_Chant_Sequence_1 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_2 - 1].text == "�V" &&
           txtChant[One.AR.Velgus_Chant_Sequence_3 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_4 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_5 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_6 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_7 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_8 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_9 - 1].text == "�_" &&
           txtChant[One.AR.Velgus_Chant_Sequence_10 - 1].text == "�l" &&
           txtChant[One.AR.Velgus_Chant_Sequence_11 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_12 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_13 - 1].text == "��" &&
           txtChant[One.AR.Velgus_Chant_Sequence_14 - 1].text == "�i" &&
           txtChant[One.AR.Velgus_Chant_Sequence_15 - 1].text == "��")
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
}
