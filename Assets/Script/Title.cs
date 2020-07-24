using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MotherBase
{
  public SaveLoad groupSaveLoad;

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

    //if (System.IO.File.Exists(One.pathForDocumentsFile(Fix.TF_SAVE)) == false)
    //{
    //    Debug.Log("File exist: " + One.pathForDocumentsFile(Fix.TF_SAVE));
    //    One.AutoSaveTruthWorldEnvironment();
    //}
    //else
    //{
    //    // セーブデータをロード
    //    Debug.Log("found it, then load");
    //    Debug.Log("One.TF.Event_Message100010: " + One.TF.Event_Message100010.ToString());
    //    One.ExecLoad("TeamFoundationSave.xml");
    //    Debug.Log("One.TF.Event_Message100010: " + One.TF.Event_Message100010.ToString());
    //}

    One.TF.CurrentAreaName = Fix.TOWN_ANSHET;
    SceneManager.LoadSceneAsync("HomeTown");
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
}
