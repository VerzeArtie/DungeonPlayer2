using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MotherBase
{
  // Ending
  public Canvas parent;
  public GameObject panelEnding;

  bool nowAnimationEnding = false;
  bool nowAnimationEnding_First = false;
  bool nowAnimationEnding_Third = false;

  private bool FirstAction = false;

  public override void Start()
  {
  }

  void Update()
  {
    if (this.FirstAction == false)
    {
      this.FirstAction = true;

      One.PlayDungeonMusic(Fix.BGM15, Fix.BGM15LoopBegin);

      StartEnding(One.EndingNumber);
      return;
    }

    // エンディングロール
    #region "エンディング"
    if (this.nowAnimationEnding)
    {
      if (this.panelEnding.GetComponent<Image>().color.a < 1.0f)
      {
        Color current = this.panelEnding.GetComponent<Image>().color;
        this.panelEnding.GetComponent<Image>().color = new Color(current.r, current.g, current.g, current.a + 0.125f);
        System.Threading.Thread.Sleep(1000);
        return;
      }

      if (!this.nowAnimationEnding_First)
      {
        this.nowAnimationEnding_First = true;
        //One.PlayDungeonMusic(Fix.BGM15, Fix.BGM15LoopBegin);

        for (int ii = this.endingMessage.Count - 1; ii >= 0; ii--)
        {
          this.endingMessage[ii].transform.localPosition = new Vector3(-Screen.width / 4, -ii * 40 - Screen.height / 2 - 50, 0);
          this.endingMessage[ii].gameObject.SetActive(true);
        }
        for (int ii = this.endingMessage2.Count - 1; ii >= 0; ii--)
        {
          this.endingMessage2[ii].transform.localPosition = new Vector3(Screen.width / 4, -ii * 140 - Screen.height / 2 - 50, 0);
          this.endingMessage2[ii].gameObject.SetActive(true);
        }
        for (int ii = this.endingMessage3.Count - 1; ii >= 0; ii--)
        {
          this.endingMessage3[ii].color = new Color(0, 0, 0, 0);
          this.endingMessage3[ii].transform.localPosition = new Vector3(-Screen.width / 4, 0, 0);
          this.endingMessage3[ii].gameObject.SetActive(true);
          Debug.Log("Ending-3 endingMessage3[ii].transform.localPosition " + endingMessage3[ii].transform.localPosition.x);
          Debug.Log("Ending-3 endingMessage3[ii].transform.position      " + endingMessage3[ii].transform.position.x);
        }
        return;
      }

      float move = 0.1f;
      float lastPosition = this.endingMessage[this.endingMessage.Count - 1].transform.position.y;
      if (lastPosition < -Screen.height / 4)
      {
        move = 0.30f; // 0.15f;
      }
      else if (-Screen.height / 4 <= lastPosition && lastPosition < 0)
      {
        move = 0.6f; // 0.3f;
      }
      else if (0 <= lastPosition && lastPosition <= Screen.height / 4)
      {
        move = 1.0f; // 0.5f;
      }
      else if (Screen.height / 4 <= lastPosition && lastPosition < Screen.height + 100)
      {
        move = 2.0f; // 1.0f;
      }
      else
      {
        move = 0;
      }
      if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
      {
        move = move * 2.5f;
      }

      for (int ii = 0; ii < this.endingMessage.Count; ii++)
      {
        this.endingMessage[ii].transform.position = new Vector3(this.endingMessage[ii].transform.position.x, this.endingMessage[ii].transform.position.y + move, this.endingMessage[ii].transform.position.z);
      }
      for (int ii = 0; ii < this.endingMessage2.Count; ii++)
      {
        this.endingMessage2[ii].transform.position = new Vector3(this.endingMessage2[ii].transform.position.x, this.endingMessage2[ii].transform.position.y + move, this.endingMessage2[ii].transform.position.z);
      }

      //      Debug.Log("Ending move: " + move.ToString());
      if (move == 0)
      {
        Debug.Log("Ending-3 start");
        float moveX = 0.1f;
        float alpha = this.endingMessage3[0].color.a;
        Debug.Log("Ending-3 endingMessage3[0].transform.position.x " + endingMessage3[0].transform.position.x);
        //if (this.endingMessage3[0].transform.position.x < 400)
        //{
        //   float lastPositionX = this.endingMessage3[this.endingMessage3.Count - 1].transform.position.x;

        if (this.nowAnimationEnding_Third == false)
        {
          float phase_1 = 0.70f; float phase_1_speed = 0.005f;
          float phase_2 = 1.00f; float phase_2_speed = 0.001f;

          Debug.Log("Ending-3 this.endingMessage3[0].color.a " + this.endingMessage3[0].color.a);
          if (this.endingMessage3[0].color.a < phase_1)
          {
            moveX = 0.3f;
            float current = this.endingMessage3[0].color.a + phase_1_speed;
            if (current >= phase_1) { current = phase_1; }
            this.endingMessage3[0].color = new Color(0, 0, 0, current);
          }
          else if (this.endingMessage3[0].color.a < phase_2)
          {
            moveX = 0.05f;
            float current = this.endingMessage3[0].color.a + phase_2_speed;
            if (current >= phase_2)
            {
              current = phase_2;
              this.nowAnimationEnding_Third = true;
            }
            this.endingMessage3[0].color = new Color(0, 0, 0, current);
          }
        }
        //}
        else
        {
          if (alpha > 0.5f)
          {
            moveX = 0.3f;
          }
          else if (alpha > 0.25f)
          {
            moveX = 0.5f;
          }
          else
          {
            moveX = 1.0f;
          }
          this.endingMessage3[0].color = new Color(0, 0, 0, this.endingMessage3[0].color.a - 0.0025f);

          Debug.Log("Ending-3 alpha " + alpha.ToString());
          if (alpha <= 0.0f)
          {
            // One.SQL.UpdateArchivement(Fix.ARCHIVEMENT_ENDING);
            this.nowAnimationEnding = true;
            //GroundOne.WE2.SeekerEnd = true;
            //GroundOne.WE.TruthCompleteArea5 = true;
            //GroundOne.WE.TruthCompleteArea5Day = GroundOne.WE.GameDay;
            //Method.AutoSaveRealWorld();
            //Method.AutoSaveTruthWorldEnvironment();
            //Method.ExecSave(null, Database.WorldSaveNum, true);
            One.AR.LeaveSeekerMode = true;
            One.TF.CompleteArea5 = true;
            One.TF.CompleteArea5Day = One.TF.GameDay;
            One.UpdateAkashicRecord();
            One.RealWorldSave();

            Debug.Log("Ending-3 end");
            SceneDimension.JumpToTitle();
          }
        }
        this.endingMessage3[0].transform.position = new Vector3(this.endingMessage3[0].transform.position.x + moveX, this.endingMessage3[0].transform.position.y, this.endingMessage3[0].transform.position.z);

      }

      return;
    }
    #endregion
  }


  private void StartEnding(int ending_type)
  {
    //GroundOne.WE2.SeekerEndingRoll = true;

    List<string> QuestMessageList = new List<string>();
    List<MessagePack.ActionEvent> QuestEventList = new List<MessagePack.ActionEvent>();
    QuestMessageList.Clear();
    QuestEventList.Clear();

    if (ending_type == 1)
    {
      MessagePack.MessageEnding(ref QuestMessageList, ref QuestEventList);
    }
    else if (ending_type == 2)
    {
      MessagePack.MessageEnding2(ref QuestMessageList, ref QuestEventList);
    }
    else
    {
      MessagePack.MessageEnding(ref QuestMessageList, ref QuestEventList);
    }
    for (int ii = 0; ii < QuestMessageList.Count; ii++)
    {
      ConstructEndingMessage(this.endingMessage, new Vector2(Screen.width / 2, 60), TextAnchor.MiddleLeft, QuestMessageList[ii]);
    }

    QuestMessageList.Clear();
    QuestEventList.Clear();
    if (ending_type == 1)
    {
      MessagePack.MessageEnding_2(ref QuestMessageList, ref QuestEventList);
    }
    else if (ending_type == 2)
    {
      MessagePack.MessageEnding2_2(ref QuestMessageList, ref QuestEventList);
    }
    else
    {
      MessagePack.MessageEnding_2(ref QuestMessageList, ref QuestEventList);
    }
    for (int ii = 0; ii < QuestMessageList.Count; ii++)
    {
      ConstructEndingMessage(this.endingMessage2, new Vector2(Screen.width / 2, 60), TextAnchor.MiddleCenter, QuestMessageList[ii]);
    }

    QuestMessageList.Clear();
    QuestEventList.Clear();
    if (ending_type == 1)
    {
      MessagePack.MessageEnding_3(ref QuestMessageList, ref QuestEventList);
    }
    else if (ending_type == 2)
    {
      MessagePack.MessageEnding2_3(ref QuestMessageList, ref QuestEventList);
    }
    else
    {
      MessagePack.MessageEnding_3(ref QuestMessageList, ref QuestEventList);
    }
    for (int ii = 0; ii < QuestMessageList.Count; ii++)
    {
      ConstructEndingMessage(this.endingMessage3, new Vector2(Screen.width / 2, 60), TextAnchor.MiddleLeft, QuestMessageList[ii]);
    }

    QuestMessageList.Clear();
    QuestEventList.Clear();

    this.panelEnding.SetActive(true);
    this.nowAnimationEnding = true;
  }

  List<Text> endingMessage = new List<Text>();
  List<Text> endingMessage2 = new List<Text>();
  List<Text> endingMessage3 = new List<Text>();
  private void ConstructEndingMessage(List<Text> messageList, Vector2 sizeDelta, TextAnchor txtAnchor, string text)
  {
    GameObject obj = new GameObject();
    Text element = obj.AddComponent<Text>();
    element.fontStyle = FontStyle.Normal;
    Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

    element.font = ArialFont;
    element.transform.SetParent(parent.transform);
    element.rectTransform.localScale = new Vector3(1, 1, 1);
    element.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
    element.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
    element.rectTransform.sizeDelta = sizeDelta;
    element.color = Color.black;
    element.gameObject.SetActive(false);
    element.text = text;
    element.alignment = txtAnchor;
    element.transform.SetParent(panelEnding.transform);
    messageList.Add(element);
  }
}
