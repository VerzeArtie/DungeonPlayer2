using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MotherBase : MonoBehaviour
{
  public GameObject Filter;

  public virtual void Start()
  {
    One.InitializeGroundOne(false);
    Application.targetFrameRate = 60;
  }

  public virtual void RefreshAllView()
  {
    // 何もなし
  }

  public virtual void SceneBack()
  {
    if (this.Filter != null)
    {
      this.Filter.SetActive(false);
    }
  }

  public void NextScene()
  {
    Resources.UnloadUnusedAssets();
    //Application.UnloadLevel(Fix.Title);
    //Application.UnloadLevel(Fix.SaveLoad);
    if (One.TF.SaveByDungeon)
    {
      One.TF.BeforeAreaName = One.TF.CurrentAreaName;
      SceneDimension.JumpToDungeonField(One.TF.CurrentDungeonField);
    }
    else
    {
      One.TF.BeforeAreaName = One.TF.CurrentAreaName;
      SceneDimension.JumpToHomeTown();
    }
  }
}