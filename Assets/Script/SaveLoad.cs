using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Xml;
using System.Reflection;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class SaveLoad : MotherBase
{
  public GameObject Background;
  public GameObject back_SystemMessage;
  public Text systemMessage;
  public Text titleLabel;
  public Button[] back_button;
  public Text[] buttonText;
  public Button[] buttonPage;
  public Text lblClose;
  public Text yesnoSystemMessage = null;
  public GameObject groupYesnoSystemMessage = null;

  private string gameDayString = "\r\n経過日数：";
  private string gameDayString2 = @"日 ";
  private string archiveAreaString = @"到達階層：";
  private string archiveAreaString2 = @"階";
  private string archiveAreaString3 = @"制覇";

  private string MESSAGE_1 = @"DungeonPlayerクリアデータです。本編ではロードできません。";
  private string MESSAGE_2 = @"保存が完了しました。";
  private string MESSAGE_OVERWRITE = @"既にデータが存在します。上書きしてセーブしますか？";
  private string MESSAGE_NOWLOADING = @"しばらくお待ちください...";

  private bool nowAutoKill = false;
  private int autoKillTimer = 0;
  private bool nowAutoKillEnd = false;

  private Text currentSaveText = null;
  private string currentTargetFileName = string.Empty;

  private int pageNumber = 1;
  private string[] filenameList = null;
  private DateTime newDateTime = new DateTime(1, 1, 1, 0, 0, 0);
  private DateTime newDateTimeAuto = new DateTime(1, 1, 1, 0, 0, 0);

  public Image pbSandglass;
  private Sprite imageSandglass;
  private CurrentPhase currentPhase = CurrentPhase.None;
  private Text txtSender;
  private bool forceSave = false;

  private enum CurrentPhase
  {
    None,
    Save,
    Load,
    Complete,
  }

  // Use this for initialization
  public void Start()
  {
    SceneLoading();
  }

  // Update is called once per frame
  public void Update()
  {
    if (this.currentPhase == CurrentPhase.None)
    {
      // no action
    }
    else if (this.currentPhase == CurrentPhase.Save || this.currentPhase == CurrentPhase.Load)
    {
      ExecSaveLoad();
    }
    else
    {
      if (One.SaveMode)
      {
        this.systemMessage.text = MESSAGE_2;
      }
      else
      {
        this.systemMessage.text = "ゲームデータの読み込みが完了しました。";
      }
      this.pbSandglass.gameObject.SetActive(false);
    }

    if (this.nowAutoKill && this.nowAutoKillEnd == false)
    {
      this.autoKillTimer++;
      if (this.autoKillTimer >= 200)
      {
        this.nowAutoKillEnd = true;
        tapExit();
      }
    }
  }

  public void SceneLoading()
  {
    Debug.Log("saveload start");

    if (One.SaveMode)
    {
      titleLabel.text = "SAVE";
      this.Background.GetComponent<Image>().color = UnityColor.Salmon;
    }
    else
    {
      this.Background.GetComponent<Image>().color = UnityColor.Aqua;
      titleLabel.text = "LOAD";
    }

    newDateTime = new DateTime(1, 1, 1, 0, 0, 0);
    newDateTimeAuto = new DateTime(1, 1, 1, 0, 0, 0);

    One.MakeDirectory();

    this.filenameList = System.IO.Directory.GetFiles(One.PathForSaveFile(), "*.xml");

    // 一番新しいファイルのナンバーを記憶する。
    int newNumber = 0;
    for (int ii = 0; ii < filenameList.Length; ii++)
    {
      string targetString = System.IO.Path.GetFileName(filenameList[ii]);
      Debug.Log("targetString: " + targetString);
      if (targetString.Contains("TeamFoundationSave.xml")) { continue; } // todo ちょっとタイム
      if (targetString.Contains("TruthWorldEnvironment.xml")) { continue; } // todo ちょっとタイム
      if (Convert.ToInt32(targetString.Substring(0, 3)) >= Fix.WORLD_SAVE_NUM) { continue; } // オートセーブは検査対象外

      string DateTimeString = targetString.Substring(4, 4) + "/" + targetString.Substring(8, 2) + "/" + targetString.Substring(10, 2) + " " + targetString.Substring(12, 2) + ":" + targetString.Substring(14, 2) + ":" + targetString.Substring(16, 2);
      DateTime targetDateTime = DateTime.Parse(DateTimeString);

      // 手動セーブと自動セーブの二つを記憶する。
      int currentNumber = Convert.ToInt32(targetString.Substring(0, 3));
      if (targetDateTime > newDateTime && currentNumber <= 200)
      {
        newDateTime = targetDateTime;
        newNumber = currentNumber;
      }
      if (targetDateTime > newDateTimeAuto && currentNumber > 200)
      {
        newDateTimeAuto = targetDateTime;
        //newNumber = currentNumber; // 自動セーブはページ自動移動の範囲に含めない。
      }
    }

    PageMove((newNumber - 1) / buttonText.Length + 1);

    if (One.SaveMode)
    {
      buttonPage[20].enabled = false;
      buttonPage[20].gameObject.SetActive(false);
    }

    int BASE_SIZE_X = 152;
    int BASE_SIZE_Y = 211;
    this.imageSandglass = Sprite.Create(Resources.Load<Texture2D>("SandGlassIcon"), new Rect(0, 0, BASE_SIZE_X, BASE_SIZE_Y), new Vector2(0, 0));
    this.pbSandglass.sprite = this.imageSandglass;

  }

  private void PageMove(int pageNum)
  {
    this.pageNumber = pageNum;
    for (int ii = 0; ii < buttonText.Length; ii++)
    {
      buttonText[ii].text = "";
      back_button[ii].GetComponent<Image>().sprite = null;
    }
    for (int ii = 0; ii < buttonPage.Length; ii++)
    {
      buttonPage[ii].GetComponent<Image>().sprite = null;
    }
    Debug.Log("buttonpage: " + this.pageNumber);
    buttonPage[this.pageNumber - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>("SaveLoadNewPageNum");


    for (int ii = 0; ii < filenameList.Length; ii++)
    {
      string filename = filenameList[ii];
      //Debug.Log("filename: " + filename);
      Text targetButton = null;
      string targetString = System.IO.Path.GetFileName(filename);
      for (int jj = 0; jj < buttonText.Length; jj++)
      {
        if (targetString.Contains(((jj + 1) + ((this.pageNumber - 1) * buttonText.Length)).ToString("D3") + "_"))
        {
          targetButton = buttonText[jj];
          targetButton.text = targetString.Substring(4, 4) + "/" + targetString.Substring(8, 2) + "/" + targetString.Substring(10, 2) + " " + targetString.Substring(12, 2) + ":" + targetString.Substring(14, 2) + ":" + targetString.Substring(16, 2) + this.gameDayString + targetString.Substring(18, 3) + this.gameDayString2 + archiveAreaString;

          string DateTimeString = targetString.Substring(4, 4) + "/" + targetString.Substring(8, 2) + "/" + targetString.Substring(10, 2) + " " + targetString.Substring(12, 2) + ":" + targetString.Substring(14, 2) + ":" + targetString.Substring(16, 2);
          DateTime targetDateTime = DateTime.Parse(DateTimeString);
          if (targetDateTime.Equals(this.newDateTime))
          {
            back_button[jj].GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.SAVELOAD_NEW);
          }
          if (targetDateTime.Equals(this.newDateTimeAuto))
          {
            back_button[jj].GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.SAVELOAD_NEW_AUTO);
          }


          if (targetString.Substring(21, 1) == "6")
          {
            targetButton.text += this.archiveAreaString3;
          }
          else
          {
            targetButton.text += targetString.Substring(21, 1) + this.archiveAreaString2;
          }

          //if (One.WE2.RealWorld && !One.WE2.SeekerEnd && One.WE2.SelectFalseStatue)
          //{
          //  targetButton.text = "";
          //}
        }
      }
    }
  }

  public void TapSelectNumber(Text txtNumber)
  {
    Debug.Log("txtNumber: " + txtNumber.text.ToString());
    //One.SQL.UpdateOwner(Fix.LOG_SAVELOAD_PAGE, txtNumber.text, String.Empty);
    One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);

    if (txtNumber.text == "A")
    {
      PageMove(Fix.AUTOSAVE_PAGE_NUM);
    }
    else
    {
      PageMove(Convert.ToInt32(txtNumber.text));
    }
  }

  public void tapButton(Text sender)
  {
    Debug.Log(sender.text);
    //One.SQL.UpdateOwner(Fix.LOG_SAVELOAD_NUMBER, sender.text, String.Empty);
    One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);

    this.txtSender = sender;
    this.systemMessage.text = MESSAGE_NOWLOADING;
    this.pbSandglass.sprite = this.imageSandglass;

    if (One.SaveMode)
    {
      string targetFileName = String.Empty;
      for (int ii = 0; ii < buttonText.Length; ii++)
      {
        if (this.txtSender.Equals(buttonText[ii]))
        {
          targetFileName = ((ii + 1) + ((this.pageNumber - 1) * buttonText.Length)).ToString("D3") + "_";
          break;
        }
      }
      bool result = TryExecSave(this.txtSender, targetFileName);
      if (result == false)
      {
        return;
      }
    }
    else
    {
      if ((this.txtSender).text == String.Empty) { return; }
    }

    this.back_SystemMessage.SetActive(true);
    StartCoroutine(WaitOnly());
  }

  private IEnumerator WaitOnly()
  {
    yield return new WaitForEndOfFrame();

    if (One.SaveMode)
    {
      this.currentPhase = CurrentPhase.Save;
    }
    else
    {
      this.currentPhase = CurrentPhase.Load;
    }

    yield return null;
  }

  private void ExecSaveLoad()
  {
    Debug.Log("ExecSaveLoad(S)");
    //
    // セーブ
    //
    if (One.SaveMode)
    {
      string targetFileName = String.Empty;
      for (int ii = 0; ii < buttonText.Length; ii++)
      {
        if (this.txtSender.Equals(buttonText[ii]))
        {
          targetFileName = ((ii + 1) + ((this.pageNumber - 1) * buttonText.Length)).ToString("D3") + "_";
          break;
        }
      }

      this.Filter.SetActive(true);
      ExecSave(this.txtSender, targetFileName, this.forceSave);
      this.forceSave = false;
    }
    //
    // ロード
    //
    else
    {
      if ((this.txtSender).text == String.Empty) { return; }

      string targetFileName = String.Empty;
      for (int ii = 0; ii < buttonText.Length; ii++)
      {
        if (this.txtSender.Equals(buttonText[ii]))
        {
          targetFileName = (ii + 1 + ((this.pageNumber - 1) * buttonText.Length)).ToString("D3") + "_";
          break;
        }
      }
      ExecLoad(this.txtSender, targetFileName, false); // 後編移動
    }
    this.currentPhase = CurrentPhase.Complete;
  }

  public void TapButtonYes()
  {
    groupYesnoSystemMessage.SetActive(false);
    HideAllChild();
    this.systemMessage.text = MESSAGE_NOWLOADING;
    this.pbSandglass.sprite = this.imageSandglass;
    this.back_SystemMessage.SetActive(true);
    this.Filter.SetActive(true);

    this.forceSave = true;
    StartCoroutine(WaitOnly());
  }

  public void TapButtonNo()
  {
    HideAllChild();
    this.currentSaveText = null;
    this.currentTargetFileName = string.Empty;
  }

  public void ExitYes()
  {
    //base.ExitYes();
    //if (this.yesnoSystemMessage.text == this.MESSAGE_OVERWRITE)
    //{
    //    HideAllChild();
    //    this.systemMessage.text = MESSAGE_NOWLOADING;
    //    this.pbSandglass.sprite = this.imageSandglass;
    //    this.back_SystemMessage.SetActive(true);

    //    this.forceSave = true;
    //    StartCoroutine(WaitOnly());
    //}
  }

  public void ExitNo()
  {
    //base.ExitNo();
    //if (this.yesnoSystemMessage.text == this.MESSAGE_OVERWRITE)
    //{
    //    HideAllChild();
    //    this.currentSaveText = null;
    //    this.currentTargetFileName = string.Empty;
    //}
  }

  public void RealWorldSave()
  {
    //ExecSave(null, Fix.WorldSaveNum, true);
  }

  private bool TryExecSave(Text sender, string targetFileName)
  {
    foreach (string overwriteData in System.IO.Directory.GetFiles(One.PathForSaveFile(), "*.xml"))
    {
      if (overwriteData.Contains(targetFileName))
      {
        this.currentSaveText = sender;
        this.currentTargetFileName = targetFileName;
        this.yesnoSystemMessage.text = this.MESSAGE_OVERWRITE;
        this.groupYesnoSystemMessage.SetActive(true);
        this.Filter.SetActive(true);
        return false;
      }
    }
    return true;
  }

  private void ExecSave(Text sender, string targetFileName, bool forceSave)
  {
    DateTime now = DateTime.Now;

    foreach (string overwriteData in System.IO.Directory.GetFiles(One.PathForSaveFile(), "*.xml"))
    {
      if (overwriteData.Contains(targetFileName))
      {
        if (forceSave == false) // if 後編追加
        {
          this.currentSaveText = sender;
          this.currentTargetFileName = targetFileName;
          this.yesnoSystemMessage.text = this.MESSAGE_OVERWRITE;
          this.groupYesnoSystemMessage.SetActive(true);
          this.Filter.SetActive(true);
          return;
        }
        else
        {
          System.IO.File.Delete(overwriteData); // 後編追加
        }
      }
    }

    targetFileName += now.Year.ToString("D4") + now.Month.ToString("D2") + now.Day.ToString("D2") + now.Hour.ToString("D2") + now.Minute.ToString("D2") + now.Second.ToString("D2") + One.TF.GameDay.ToString("D3");
    targetFileName += Convert.ToString(1);
    targetFileName += ".xml";

    XmlTextWriter xmlWriter = new XmlTextWriter(One.pathForDocumentsFile(targetFileName), Encoding.UTF8);
    try
    {
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteWhitespace("\r\n");

      xmlWriter.WriteStartElement("Body");
      xmlWriter.WriteElementString("DateTime", DateTime.Now.ToString());
      xmlWriter.WriteElementString("Version", Fix.VERSION.ToString());
      xmlWriter.WriteWhitespace("\r\n");

      // ワールド環境
      xmlWriter.WriteStartElement("TeamFoundation");
      xmlWriter.WriteWhitespace("\r\n");
      if (One.TF != null)
      {
        Type typeWE2 = One.TF.GetType();
        foreach (PropertyInfo pi in typeWE2.GetProperties())
        {
          if (pi.PropertyType == typeof(System.Int32))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(One.TF, null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.String))
          {
            xmlWriter.WriteElementString(pi.Name, (string)(pi.GetValue(One.TF, null)));
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Double))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Double)(pi.GetValue(One.TF, null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Single))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Single)(pi.GetValue(One.TF, null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Boolean))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Boolean)pi.GetValue(One.TF, null)).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
        }
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // バックパック
      xmlWriter.WriteStartElement("Backpack");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
      {
        xmlWriter.WriteElementString("Item_" + ii.ToString("D8"), One.TF.BackpackList[ii].ItemName);
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_Stack", One.TF.BackpackList[ii].StackValue.ToString());
        xmlWriter.WriteWhitespace("\r\n");
        if (One.TF.BackpackList[ii].CanbeSocket1 && One.TF.BackpackList[ii].SocketedItem1 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket1", One.TF.BackpackList[ii].SocketedItem1.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.BackpackList[ii].CanbeSocket2 && One.TF.BackpackList[ii].SocketedItem2 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket2", One.TF.BackpackList[ii].SocketedItem2.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.BackpackList[ii].CanbeSocket3 && One.TF.BackpackList[ii].SocketedItem3 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket3", One.TF.BackpackList[ii].SocketedItem3.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.BackpackList[ii].CanbeSocket4 && One.TF.BackpackList[ii].SocketedItem4 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket4", One.TF.BackpackList[ii].SocketedItem4.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.BackpackList[ii].CanbeSocket5 && One.TF.BackpackList[ii].SocketedItem5 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket5", One.TF.BackpackList[ii].SocketedItem5.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");


      // プレイヤー情報
      for (int ii = 0; ii < One.PlayerList.Count; ii++)
      {
        Type type = One.PlayerList[ii].GetType();
        xmlWriter.WriteStartElement("Character_" + ii.ToString());
        xmlWriter.WriteWhitespace("\r\n");
        foreach (PropertyInfo pi in type.GetProperties())
        {
          if (pi.PropertyType == typeof(System.Int32))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.String))
          {
            xmlWriter.WriteElementString(pi.Name, (string)(pi.GetValue(One.PlayerList[ii], null)));
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Double))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Double)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Single))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Single)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Boolean))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Boolean)pi.GetValue(One.PlayerList[ii], null)).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(Fix.JobClass))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(Fix.CommandAttribute))
          {
            xmlWriter.WriteElementString(pi.Name, ((Fix.CommandAttribute)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
        }
        xmlWriter.WriteElementString("MainWeapon", (One.PlayerList[ii].MainWeapon?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("SubWeapon", (One.PlayerList[ii].SubWeapon?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("MainArmor", (One.PlayerList[ii].MainArmor?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Accessory1", (One.PlayerList[ii].Accessory1?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Accessory2", (One.PlayerList[ii].Accessory2?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Artifact", (One.PlayerList[ii].Artifact?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteEndElement();
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteWhitespace("\r\n");
      }


      // ダンジョンKnownTileInfo
      xmlWriter.WriteStartElement("CaveOfSarun");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_CaveOfSarun.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileInfo_CaveOfSarun_" + ii.ToString("D8"), One.TF.KnownTileList_CaveOfSarun[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Goratrum )
      xmlWriter.WriteStartElement("Goratrum");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Goratrum.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileInfo_Goratrum_" + ii.ToString("D8"), One.TF.KnownTileList_Goratrum[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");
      // ダンジョンKnownTileInfo ( Goratrum_2 )
      xmlWriter.WriteStartElement("Goratrum_2");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Goratrum_2.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileInfo_Goratrum_2_" + ii.ToString("D8"), One.TF.KnownTileList_Goratrum_2[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // TeamFoundation終了
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");

      xmlWriter.WriteEndDocument();
    }
    finally
    {
      xmlWriter.Close();

      if ((Text)sender != null) // if 後編追加
      {
        ((Text)sender).text = DateTime.Now.ToString() + "\r\n経過日数：" + One.TF.GameDay.ToString("D3") + "日 ";
        // todo
        ((Text)sender).text += archiveAreaString + "1" + archiveAreaString2;

        if (!((Text)sender).Equals(buttonText[0])) back_button[0].GetComponent<Image>().sprite = null;
        if (!((Text)sender).Equals(buttonText[1])) back_button[1].GetComponent<Image>().sprite = null;
        if (!((Text)sender).Equals(buttonText[2])) back_button[2].GetComponent<Image>().sprite = null;
        if (!((Text)sender).Equals(buttonText[3])) back_button[3].GetComponent<Image>().sprite = null;
        if (!((Text)sender).Equals(buttonText[4])) back_button[4].GetComponent<Image>().sprite = null;
        if (!((Text)sender).Equals(buttonText[5])) back_button[5].GetComponent<Image>().sprite = null;
        if (!((Text)sender).Equals(buttonText[6])) back_button[6].GetComponent<Image>().sprite = null;
        if (!((Text)sender).Equals(buttonText[7])) back_button[7].GetComponent<Image>().sprite = null;
        if (!((Text)sender).Equals(buttonText[8])) back_button[8].GetComponent<Image>().sprite = null;
        if (!((Text)sender).Equals(buttonText[9])) back_button[9].GetComponent<Image>().sprite = null;
        for (int ii = 0; ii < buttonText.Length; ii++)
        {
          if (sender.Equals(buttonText[ii]))
          {
            back_button[ii].GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.SAVELOAD_NEW);
          }
        }
      }
    }

    // セーブデータをサーバーへ転送する。
    //try
    //{
    //  Debug.Log("Call UpdateSaveData");
    //  using (FileStream fs = new FileStream(One.pathForDocumentsFile(targetFileName), FileMode.Open))
    //  {
    //    using (BinaryReader br = new BinaryReader(fs))
    //    {
    //      byte[] save_current = br.ReadBytes((int)fs.Length);
    //      using (FileStream fs2 = new FileStream(One.PathForRootFile(Fix.WE2_FILE), FileMode.Open))
    //      {
    //        using (BinaryReader br2 = new BinaryReader(fs2))
    //        {
    //          byte[] save_we2 = br2.ReadBytes((int)fs2.Length);
    //          One.SQL.UpdaeSaveData(save_current, save_we2, sender.text, this.pageNumber.ToString());
    //        }
    //      }
    //    }
    //  }

    //  Debug.Log("Call UpdateSaveData ok");
    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("ExecSave error: " + ex.ToString());
    //}

  }

  private void ExecLoad(Text sender, string targetFileName, bool forceLoad)
  {
    if (this.nowAutoKill) { return; }
    Debug.Log("ExecLoad 0 " + DateTime.Now);

    One.ReInitializeGroundOne(true);

    XmlDocument xml = new XmlDocument();
    DateTime now = DateTime.Now;
    string yearData = String.Empty;
    string monthData = String.Empty;
    string dayData = String.Empty;
    string hourData = String.Empty;
    string minuteData = String.Empty;
    string secondData = String.Empty;
    string gamedayData = String.Empty;
    string completeareaData = String.Empty;

    Debug.Log("ExecLoad 1 " + DateTime.Now);
    if (((Text)sender) != null)
    {
      yearData = ((Text)sender).text.Substring(0, 4);
      monthData = ((Text)sender).text.Substring(5, 2);
      dayData = ((Text)sender).text.Substring(8, 2);
      hourData = ((Text)sender).text.Substring(11, 2);
      minuteData = ((Text)sender).text.Substring(14, 2);
      secondData = ((Text)sender).text.Substring(17, 2);
      gamedayData = ((Text)sender).text.Substring(this.gameDayString.Length + 19, 3);
      completeareaData = ((Text)sender).text.Substring(this.gameDayString.Length + this.gameDayString2.Length + this.archiveAreaString.Length + 22, 1);

      if (completeareaData == "制")
      {
        this.systemMessage.text = MESSAGE_1;
        this.back_SystemMessage.SetActive(true);
        this.Filter.SetActive(true);
        return;
      }
      targetFileName += yearData + monthData + dayData + hourData + minuteData + secondData + gamedayData + completeareaData + ".xml";
    }
    else
    {
      foreach (string currentFile in System.IO.Directory.GetFiles(One.PathForSaveFile(), "*.xml"))
      {
        if (currentFile.Contains(Fix.WorldSaveNum))
        {
          targetFileName = System.IO.Path.GetFileName(currentFile);
          break;
        }
      }
    }

    xml.Load(One.pathForDocumentsFile(targetFileName));
    One.CurrentLoadFileName = targetFileName;
    Debug.Log("ExecLoad 2 " + DateTime.Now);

    // TeamFoundation
    List<string> listTFName = new List<string>();
    List<string> listTFValue = new List<string>();
    XmlNodeList parent = xml.GetElementsByTagName("TeamFoundation");
    for (int ii = 0; ii < parent.Count; ii++)
    {
      Debug.Log("node: " + parent[ii].Name.ToString());
      XmlNodeList current = parent[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        Debug.Log("TF child: " + current[jj].Name + " value: " + current[jj].InnerText.ToString());
        listTFName.Add(current[jj].Name);
        listTFValue.Add(current[jj].InnerText);
      }
    }

    Type typeTF = One.TF.GetType();
    Debug.Log("ExecLoad 6 " + DateTime.Now);


    PropertyInfo[] tempTF = typeTF.GetProperties();
    Debug.Log(tempTF.Length.ToString());
    for (int ii = 0; ii < tempTF.Length; ii++)
    {
      Debug.Log("TF: " + tempTF[ii].Name);
      PropertyInfo pi = tempTF[ii];
      // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
      if (pi.PropertyType == typeof(System.Int32))
      {
        try
        {
          for (int jj = 0; jj < listTFName.Count; jj++)
          {
            if (listTFName[jj] == pi.Name)
            {
              pi.SetValue(One.TF, Convert.ToInt32(listTFValue[jj]), null);
              break;
            }
          }
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Single))
      {
        try
        {
          for (int jj = 0; jj < listTFName.Count; jj++)
          {
            if (listTFName[jj] == pi.Name)
            {
              pi.SetValue(One.TF, Convert.ToSingle(listTFValue[jj]), null);
              break;
            }
          }
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.String))
      {
        try
        {
          for (int jj = 0; jj < listTFName.Count; jj++)
          {
            if (listTFName[jj] == pi.Name)
            {
              pi.SetValue(One.TF, listTFValue[jj], null);
              break;
            }
          }
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Boolean))
      {
        try
        {
          for (int jj = 0; jj < listTFName.Count; jj++)
          {
            if (listTFName[jj] == pi.Name)
            {
              pi.SetValue(One.TF, Convert.ToBoolean(listTFValue[jj]), null);
              break;
            }
          }
        }
        catch { }
      }
    }

    // Backpack
    List<string> listItemValue = new List<string>();
    List<string> listItemStack = new List<string>();
    List<string> listItemJewelSocket1 = new List<string>();
    List<string> listItemJewelSocket2 = new List<string>();
    List<string> listItemJewelSocket3 = new List<string>();
    List<string> listItemJewelSocket4 = new List<string>();
    List<string> listItemJewelSocket5 = new List<string>();
    XmlNodeList parentBackpack = xml.GetElementsByTagName("Backpack");
    for (int ii = 0; ii < parentBackpack.Count; ii++)
    {
      XmlNodeList current = parentBackpack[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].Name.Contains("Stack") == false && current[jj].Name.Contains("JewelSocket") == false)
        {
          listItemValue.Add(current[jj].InnerText);
          XmlNodeList temp2 = xml.GetElementsByTagName(current[jj].Name + "_Stack");
          listItemStack.Add(temp2[0]?.InnerText ?? String.Empty);

          XmlNodeList temp3_1 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket1");
          listItemJewelSocket1.Add(temp3_1[0]?.InnerText ?? string.Empty);

          XmlNodeList temp3_2 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket2");
          listItemJewelSocket2.Add(temp3_2[0]?.InnerText ?? string.Empty);

          XmlNodeList temp3_3 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket3");
          listItemJewelSocket3.Add(temp3_3[0]?.InnerText ?? string.Empty);

          XmlNodeList temp3_4 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket4");
          listItemJewelSocket4.Add(temp3_4[0]?.InnerText ?? string.Empty);

          XmlNodeList temp3_5 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket5");
          listItemJewelSocket5.Add(temp3_5[0]?.InnerText ?? string.Empty);
        }
      }
    }

    for (int ii = 0; ii < listItemValue.Count; ii++)
    {
      Debug.Log("listItemStack: " + listItemStack[ii]);
      for (int jj = 0; jj < Convert.ToInt32(listItemStack[ii]); jj++)
      {
        Item current = new Item(listItemValue[ii]);
        if (listItemJewelSocket1[ii] != string.Empty)
        {
          current.AddJewelSocket1(listItemJewelSocket1[ii]);
        }
        if (listItemJewelSocket2[ii] != string.Empty)
        {
          current.AddJewelSocket2(listItemJewelSocket2[ii]);
        }
        if (listItemJewelSocket3[ii] != string.Empty)
        {
          current.AddJewelSocket3(listItemJewelSocket3[ii]);
        }
        if (listItemJewelSocket4[ii] != string.Empty)
        {
          current.AddJewelSocket4(listItemJewelSocket4[ii]);
        }
        if (listItemJewelSocket5[ii] != string.Empty)
        {
          current.AddJewelSocket5(listItemJewelSocket5[ii]);
        }
        One.TF.AddBackPack(current);
      }
    }

    // Character
    for (int ii = 0; ii < Fix.INFINITY; ii++)
    {
      List<string> listName = new List<string>();
      List<string> listValue = new List<string>();
      XmlNodeList character = xml.GetElementsByTagName("Character_" + ii.ToString());
      if (character == null)
      {
        Debug.Log("character list is null, then no action");
        break;
      }
      if (character.Count <= 0)
      {
        Debug.Log("character list count is 0, then no action");
        break;
      }
      Debug.Log("character Detection ok");

      XmlNodeList current = character[0].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        Debug.Log("character child: " + current[jj].Name + " value: " + current[jj].InnerText.ToString());
        listName.Add(current[jj].Name);
        listValue.Add(current[jj].InnerText);
      }

      GameObject objDummy = new GameObject();
      Character dummy = objDummy.AddComponent<Character>();
      Type typeCharacter = dummy.GetType();
      PropertyInfo[] tempCharacter = typeCharacter.GetProperties();
      for (int jj = 0; jj < tempCharacter.Length; jj++)
      {
        Debug.Log("character: " + tempCharacter[jj].Name);
        PropertyInfo pi = tempCharacter[jj];
        // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
        if (pi.PropertyType == typeof(System.Int32))
        {
          try
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                pi.SetValue(One.Characters[ii], Convert.ToInt32(listValue[kk]), null);
                break;
              }
            }
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.String))
        {
          try
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                pi.SetValue(One.Characters[ii], listValue[kk], null);
                break;
              }
            }
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Boolean))
        {
          try
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                pi.SetValue(One.Characters[ii], Convert.ToBoolean(listValue[kk]), null);
                break;
              }
            }
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(Item))
        {

          Debug.Log("Detect Item: " + pi.Name);
          if (pi.Name == "MainWeapon")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].MainWeapon = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "SubWeapon")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].SubWeapon = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "MainArmor")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].MainArmor = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "Accessory1")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].Accessory1 = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "Accessory2")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].Accessory2 = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "Artifact")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].Artifact = new Item(listValue[kk]);
                break;
              }
            }
          }
        }
        else if (pi.PropertyType == typeof(Fix.JobClass))
        {
          for (int kk = 0; kk < listName.Count; kk++)
          {
            if (listName[kk] == "Job")
            {
              One.Characters[ii].Job = (Fix.JobClass)Enum.Parse(typeof(Fix.JobClass), listValue[kk]);
              break;
            }
          }
        }
      }
    }

    Debug.Log(DateTime.Now.ToString());
    Debug.Log("ExecLoad 8-1 " + DateTime.Now + DateTime.Now.Millisecond);

    Debug.Log("ExecLoad 9-1");
    // KnownTileInfo
    XmlNodeList parentCaveOfSarun = xml.GetElementsByTagName("CaveOfSarun");
    for (int ii = 0; ii < parentCaveOfSarun.Count; ii++)
    {
      XmlNodeList current = parentCaveOfSarun[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        //Debug.Log("ExecLoad current " + jj.ToString() + " " + current[jj].InnerText);
        if (current[jj].InnerText.Contains("True"))
        {
          Debug.Log("ExecLoad KnownTileList_CaveOfSarun KnownNumber: " + jj.ToString());
          One.TF.KnownTileList_CaveOfSarun[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_CaveOfSarun[jj] = false;
        }
      }
    }
    XmlNodeList parentGoratrum = xml.GetElementsByTagName("Goratrum");
    for (int ii = 0; ii < parentGoratrum.Count; ii++)
    {
      XmlNodeList current = parentGoratrum[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          Debug.Log("ExecLoad KnownTileList_Goratrum KnownNumber: " + jj.ToString());
          One.TF.KnownTileList_Goratrum[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_Goratrum[jj] = false;
        }
      }
    }
    XmlNodeList parentGoratrum_2 = xml.GetElementsByTagName("Goratrum_2");
    for (int ii = 0; ii < parentGoratrum_2.Count; ii++)
    {
      XmlNodeList current = parentGoratrum_2[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_Goratrum_2[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_Goratrum_2[jj] = false;
        }
      }
    }

    Debug.Log("ExecLoad 9-2");

    if (forceLoad == false)
    {
      this.systemMessage.text = "ゲームデータの読み込みが完了しました。";
      this.back_SystemMessage.SetActive(true);
      this.autoKillTimer = 0;
      this.nowAutoKill = true;
      this.Filter.SetActive(true);
    }
    Debug.Log("ExecLoad end");
  }
  // move-out(e) 後編追加

  public void HideAllChild()
  {
    this.groupYesnoSystemMessage.SetActive(false);
    this.back_SystemMessage.SetActive(false);
    this.Filter.SetActive(false);
    this.currentPhase = CurrentPhase.None;
    this.systemMessage.text = "";

    if (this.nowAutoKill && this.nowAutoKillEnd == false)
    {
      this.autoKillTimer = (200 - 1);
    }
  }

  public void tapExit()
  {
    One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
    if (this.systemMessage.text == this.MESSAGE_1 || this.systemMessage.text == this.MESSAGE_2)
    {
      HideAllChild();
    }
    else if (this.nowAutoKill)
    {
      if (One.AfterBacktoTitle)
      {
        SceneDimension.JumpToTitle();
      }
      else if (One.Parent.Count > 0)
      {
        One.Parent[One.Parent.Count - 1].NextScene();
      }
    }
    else if (One.AfterBacktoTitle)
    {
      SceneDimension.JumpToTitle();
    }
    else
    {
      SceneDimension.Back(this);
    }
  }

  public void TapClose()
  {
    One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
    this.gameObject.SetActive(false);
  }
}
