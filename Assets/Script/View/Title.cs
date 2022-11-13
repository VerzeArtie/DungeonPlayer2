using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MotherBase
{
  public SaveLoad groupSaveLoad;
  public GameObject groupConfig;

  bool firstAction = false;
  // Start is called before the first frame update
  public override void Start()
  {
    base.Start();
  }

  // Update is called once per frame
  void Update()
  {
    if (this.firstAction == false)
    {
      this.firstAction = true;
      // 初期開始時、ファイルが無い場合準備しておく。
      One.MakeDirectory();
    }
  }

  public void TapGameStart()
  {
    Debug.Log("TapGameStart ok");

    if (System.IO.File.Exists(One.PathForRootFile(Fix.AR_FILE)) == false)
    {
      Debug.Log("PathForRootFile(Fix.AR_FILE no exist, then create it.: " + One.PathForRootFile(Fix.AR_FILE));
      One.UpdateAkashicRecord();
    }
    else
    {
      Debug.Log("PathForRootFile(Fix.AR_FILE exist, then no action.: " + One.PathForRootFile(Fix.AR_FILE));
    }

    One.TF.AvailableEinWolence = true;
    One.TF.AvailableLanaAmiria = true;
    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    One.TF.BattlePlayer2 = Fix.NAME_LANA_AMIRIA;
    One.TF.CurrentAreaName = Fix.TOWN_ANSHET;
    One.TF.BeforeAreaName = Fix.TOWN_ANSHET;
    SceneDimension.JumpToHomeTown();
  }

  public void TapGameLoad()
  {
    One.SaveMode = false;
    One.AfterBacktoTitle = false;
    One.SaveAndExit = false;
    One.Parent.Add(this);
    this.groupSaveLoad.SceneLoading();
    this.groupSaveLoad.gameObject.SetActive(true);
    //SceneDimension.CallSaveLoad(this, false, false);
  }

  public void TapConfig()
  {
    groupConfig.SetActive(true);
  }

  public void TapClose()
  {
    groupConfig.SetActive(false);
    groupSaveLoad.gameObject.SetActive(false);
  }
}
