using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Xml;
using System.Reflection;
using System.Text;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
  private string saveDungeonAreaString = @"到達地点：";

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
      //Debug.Log("targetString: " + targetString);
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

          // todo セーブファイル名が、画面上のテキストに連動してしまっている。
          // セーブデータが示す表示文字はセーブファイルの中に埋め込んである
          // ダンジョン名、ホームタウン名を取り出すしかない。
          // 処理が重たくなる点は改善はしたい所ではあるが、現状このままとする。
          // targetButton.text = targetString.Substring(4, 4) + "/" + targetString.Substring(8, 2) + "/" + targetString.Substring(10, 2) + " " + targetString.Substring(12, 2) + ":" + targetString.Substring(14, 2) + ":" + targetString.Substring(16, 2) + this.gameDayString + targetString.Substring(18, 3) + this.gameDayString2 + archiveAreaString;
          targetButton.text = targetString.Substring(4, 4) + "/" + targetString.Substring(8, 2) + "/" + targetString.Substring(10, 2) + " " + targetString.Substring(12, 2) + ":" + targetString.Substring(14, 2) + ":" + targetString.Substring(16, 2) + this.gameDayString + targetString.Substring(18, 3) + this.gameDayString2;
          
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


          //if (targetString.Substring(21, 1) == "6")
          //{
          //  targetButton.text += this.archiveAreaString3;
          //}
          //else
          //{
          //  targetButton.text += targetString.Substring(21, 1) + this.archiveAreaString2;
          //}

          string displayDungeonName = string.Empty;
          string displayAreaName = string.Empty;
          bool displaySaveByDungeon = false;
          ReadDisplaySaveString(targetString, ref displayDungeonName, ref displayAreaName, ref displaySaveByDungeon);
          if (displaySaveByDungeon)
          {
            if (displayDungeonName != string.Empty)
            {
              targetButton.text += displayDungeonName;
            }
            else
            {
              targetButton.text += displayAreaName;
            }
          }
          else
          {
            if (displayAreaName != string.Empty)
            {
              targetButton.text += displayAreaName;
            }
            else
            {
              targetButton.text += displayDungeonName;
            }
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
    // Debug.Log(sender.text);
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

      if (this.nowAutoKill) { return; }

      DateTime now = DateTime.Now;
      string yearData = String.Empty;
      string monthData = String.Empty;
      string dayData = String.Empty;
      string hourData = String.Empty;
      string minuteData = String.Empty;
      string secondData = String.Empty;
      string gamedayData = String.Empty;
      //string completeareaData = String.Empty;
      if (((Text)this.txtSender) != null)
      {
        Debug.Log("ExecLoad 1-2 " + targetFileName);
        yearData = ((Text)this.txtSender).text.Substring(0, 4);
        monthData = ((Text)this.txtSender).text.Substring(5, 2);
        dayData = ((Text)this.txtSender).text.Substring(8, 2);
        hourData = ((Text)this.txtSender).text.Substring(11, 2);
        minuteData = ((Text)this.txtSender).text.Substring(14, 2);
        secondData = ((Text)this.txtSender).text.Substring(17, 2);
        gamedayData = ((Text)this.txtSender).text.Substring(this.gameDayString.Length + 19, 3);
        //completeareaData = ((Text)this.txtSender).text.Substring(this.gameDayString.Length + this.gameDayString2.Length + this.archiveAreaString.Length + 22, 1);

        //if (completeareaData == "制")
        //{
        //  this.systemMessage.text = MESSAGE_1;
        //  this.back_SystemMessage.SetActive(true);
        //  this.Filter.SetActive(true);
        //  return;
        //}
        targetFileName += yearData + monthData + dayData + hourData + minuteData + secondData + gamedayData + /* completeareaData + */ "1.xml";
        Debug.Log("ExecLoad 1-3 " + targetFileName);
      }
      Debug.Log("ExecLoad 1-6 " + targetFileName);

      One.ExecLoad(targetFileName, false);

      this.systemMessage.text = Fix.LOAD_DATA_COMPLETE;
      this.back_SystemMessage.SetActive(true);
      this.autoKillTimer = 0;
      this.nowAutoKill = true;
      this.Filter.SetActive(true);
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

      // アイテムバンク
      xmlWriter.WriteStartElement("ItemBank");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.ItemBankList.Count; ii++)
      {
        // 本来[ Item_ ]という名称がバックパックと重複していても制御できるはずだが、[ ItemBank_ ]とする。
        // 芋プログラミングで良しとする。
        xmlWriter.WriteElementString("ItemBank_" + ii.ToString("D8"), One.TF.ItemBankList[ii].ItemName);
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("ItemBank_" + ii.ToString("D8") + "_Stack", One.TF.ItemBankList[ii].StackValue.ToString());
        xmlWriter.WriteWhitespace("\r\n");
        if (One.TF.ItemBankList[ii].CanbeSocket1 && One.TF.ItemBankList[ii].SocketedItem1 != null)
        {
          xmlWriter.WriteElementString("ItemBank_" + ii.ToString("D8") + "_JewelSocket1", One.TF.ItemBankList[ii].SocketedItem1.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.ItemBankList[ii].CanbeSocket2 && One.TF.ItemBankList[ii].SocketedItem2 != null)
        {
          xmlWriter.WriteElementString("ItemBank_" + ii.ToString("D8") + "_JewelSocket2", One.TF.ItemBankList[ii].SocketedItem2.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.ItemBankList[ii].CanbeSocket3 && One.TF.ItemBankList[ii].SocketedItem3 != null)
        {
          xmlWriter.WriteElementString("ItemBank_" + ii.ToString("D8") + "_JewelSocket3", One.TF.ItemBankList[ii].SocketedItem3.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.ItemBankList[ii].CanbeSocket4 && One.TF.ItemBankList[ii].SocketedItem4 != null)
        {
          xmlWriter.WriteElementString("ItemBank_" + ii.ToString("D8") + "_JewelSocket4", One.TF.ItemBankList[ii].SocketedItem4.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.ItemBankList[ii].CanbeSocket5 && One.TF.ItemBankList[ii].SocketedItem5 != null)
        {
          xmlWriter.WriteElementString("ItemBank_" + ii.ToString("D8") + "_JewelSocket5", One.TF.ItemBankList[ii].SocketedItem5.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // 貴重品
      xmlWriter.WriteStartElement("PreciousItem");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.PreciousItemList.Count; ii++)
      {
        // 本来[ Item_ ]という名称がバックパックと重複していても制御できるはずだが、[ PreciousItem_ ]とする。
        // 芋プログラミングで良しとする。
        xmlWriter.WriteElementString("PreciousItem_" + ii.ToString("D8"), One.TF.PreciousItemList[ii].ItemName);
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("PreciousItem_" + ii.ToString("D8") + "_Stack", One.TF.PreciousItemList[ii].StackValue.ToString());
        xmlWriter.WriteWhitespace("\r\n");
        if (One.TF.PreciousItemList[ii].CanbeSocket1 && One.TF.PreciousItemList[ii].SocketedItem1 != null)
        {
          xmlWriter.WriteElementString("PreciousItem_" + ii.ToString("D8") + "_JewelSocket1", One.TF.PreciousItemList[ii].SocketedItem1.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.PreciousItemList[ii].CanbeSocket2 && One.TF.PreciousItemList[ii].SocketedItem2 != null)
        {
          xmlWriter.WriteElementString("PreciousItem_" + ii.ToString("D8") + "_JewelSocket2", One.TF.PreciousItemList[ii].SocketedItem2.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.PreciousItemList[ii].CanbeSocket3 && One.TF.PreciousItemList[ii].SocketedItem3 != null)
        {
          xmlWriter.WriteElementString("PreciousItem_" + ii.ToString("D8") + "_JewelSocket3", One.TF.PreciousItemList[ii].SocketedItem3.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.PreciousItemList[ii].CanbeSocket4 && One.TF.PreciousItemList[ii].SocketedItem4 != null)
        {
          xmlWriter.WriteElementString("PreciousItem_" + ii.ToString("D8") + "_JewelSocket4", One.TF.PreciousItemList[ii].SocketedItem4.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.PreciousItemList[ii].CanbeSocket5 && One.TF.PreciousItemList[ii].SocketedItem5 != null)
        {
          xmlWriter.WriteElementString("PreciousItem_" + ii.ToString("D8") + "_JewelSocket5", One.TF.PreciousItemList[ii].SocketedItem5.ItemName);
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
      xmlWriter.WriteStartElement("EsmiliaGrassField");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_EsmiliaGrassField.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileInfo_EsmiliaGrassField_" + ii.ToString("D8"), One.TF.KnownTileList_EsmiliaGrassField[ii].ToString());
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

      // ダンジョンKnownTileInfo ( MysticForest )
      xmlWriter.WriteStartElement("MysticForest");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_MysticForest.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileInfo_MysticForest_" + ii.ToString("D8"), One.TF.KnownTileList_MysticForest[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( VelgusSeaTemple )
      xmlWriter.WriteStartElement("VelgusSeaTemple");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_VelgusSeaTemple.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_VelgusSeaTemple" + ii.ToString("D8"), One.TF.KnownTileList_VelgusSeaTemple[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( VelgusSeaTemple_2 )
      xmlWriter.WriteStartElement("VelgusSeaTemple_2");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_VelgusSeaTemple_2.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_VelgusSeaTemple_2" + ii.ToString("D8"), One.TF.KnownTileList_VelgusSeaTemple_2[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( VelgusSeaTemple_3 )
      xmlWriter.WriteStartElement("VelgusSeaTemple_3");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_VelgusSeaTemple_3.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_VelgusSeaTemple_3" + ii.ToString("D8"), One.TF.KnownTileList_VelgusSeaTemple_3[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( VelgusSeaTemple_4 )
      xmlWriter.WriteStartElement("VelgusSeaTemple_4");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_VelgusSeaTemple_4.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_VelgusSeaTemple_4" + ii.ToString("D8"), One.TF.KnownTileList_VelgusSeaTemple_4[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Edelgarzen_1 )
      xmlWriter.WriteStartElement("Edelgarzen_1");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Edelgarzen_1.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_Edelgarzen_1" + ii.ToString("D8"), One.TF.KnownTileList_Edelgarzen_1[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Edelgarzen_2 )
      xmlWriter.WriteStartElement("Edelgarzen_2");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Edelgarzen_2.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_Edelgarzen_2" + ii.ToString("D8"), One.TF.KnownTileList_Edelgarzen_2[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Edelgarzen_3 )
      xmlWriter.WriteStartElement("Edelgarzen_3");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Edelgarzen_3.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_Edelgarzen_3" + ii.ToString("D8"), One.TF.KnownTileList_Edelgarzen_3[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Edelgarzen_4 )
      xmlWriter.WriteStartElement("Edelgarzen_4");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Edelgarzen_4.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_Edelgarzen_4" + ii.ToString("D8"), One.TF.KnownTileList_Edelgarzen_4[ii].ToString());
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
        if (One.TF.SaveByDungeon)
        {
          ((Text)sender).text += ConvertMapFileToDungeonName(One.TF.CurrentDungeonField);
        }
        else
        {
          ((Text)sender).text += saveDungeonAreaString + One.TF.CurrentAreaName;
        }

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

  private void ReadDisplaySaveString(string targetFileName, ref string currentDungeonName, ref string currentAreaName, ref bool saveByDungeon)
  {
    XmlDocument xml = new XmlDocument();
    xml.Load(One.pathForDocumentsFile(targetFileName));

    List<string> listDSDName = new List<string>();
    List<string> listDSDValue = new List<string>();
    XmlNodeList parent = xml.GetElementsByTagName("TeamFoundation");
    for (int ii = 0; ii < parent.Count; ii++)
    {
      //Debug.Log("node: " + parent[ii].Name.ToString());
      XmlNodeList current = parent[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        //Debug.Log("DSD child: " + current[jj].Name + " value: " + current[jj].InnerText.ToString());
        listDSDName.Add(current[jj].Name);
        listDSDValue.Add(current[jj].InnerText);
      }
    }

    Type typeDSD = One.TF.GetType();
    PropertyInfo[] tempDSD = typeDSD.GetProperties();
    // Debug.Log(tempDSD.Length.ToString());
    for (int ii = 0; ii < tempDSD.Length; ii++)
    {
      //Debug.Log("DSD: " + tempDSD[ii].Name);
      PropertyInfo pi = tempDSD[ii];
      // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
      if (pi.PropertyType == typeof(System.String))
      {
        try
        {
          for (int jj = 0; jj < listDSDName.Count; jj++)
          {
            if (listDSDName[jj] == pi.Name)
            {
              if (listDSDName[jj] == "CurrentDungeonField")
              {
                if (listDSDName[jj] != string.Empty)
                {
                  currentDungeonName = saveDungeonAreaString + ConvertMapFileToDungeonName(listDSDValue[jj]);
                }
                else
                {
                  currentDungeonName = string.Empty;
                }
              }
              else if (listDSDName[jj] == "CurrentAreaName")
              {
                if (listDSDName[jj] != string.Empty)
                {
                  currentAreaName = saveDungeonAreaString + listDSDValue[jj];
                }
                else
                {
                  currentAreaName = string.Empty;
                }
              }
            }
          }
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Boolean))
      {
        try
        {
          for (int jj = 0; jj < listDSDName.Count; jj++)
          {
            if (listDSDName[jj] == pi.Name)
            {
              if (listDSDName[jj] == "SaveByDungeon")
              {
                saveByDungeon = Convert.ToBoolean(listDSDValue[jj]);
              }
            }
          }
        }
        catch { }
      }
    }
  }

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
        One.ReInitializeGroundOne(false);
        One.StopDungeonMusic();
        SceneDimension.JumpToTitle();
      }
      else
      {
        Resources.UnloadUnusedAssets();
        if (One.TF.SaveByDungeon)
        {
          One.TF.BeforeAreaName = One.TF.CurrentAreaName;
          One.StopDungeonMusic();
          SceneDimension.JumpToDungeonField();
        }
        else
        {
          One.TF.BeforeAreaName = One.TF.CurrentAreaName;
          One.StopDungeonMusic();
          SceneDimension.JumpToHomeTown();
        }
      }
    }
    else if (One.AfterBacktoTitle)
    {
      One.ReInitializeGroundOne(false);
      One.StopDungeonMusic();
      SceneDimension.JumpToTitle();
    }
    else
    {
      // TapCloseと同等に扱う。
      One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
      this.gameObject.SetActive(false);
    }
  }

  public void TapClose()
  {
    One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
    this.gameObject.SetActive(false);
  }

  private string ConvertMapFileToDungeonName(string map_file)
  {
    if (map_file == Fix.MAPFILE_ESMILIA_GRASSFIELD) { return Fix.DUNGEON_ESMILIA_GRASSFIELD; }
    else if (map_file == Fix.MAPFILE_GORATRUM) { return Fix.DUNGEON_GORATRUM_CAVE + "(１層)"; }
    else if (map_file == Fix.MAPFILE_GORATRUM_2) { return Fix.DUNGEON_GORATRUM_CAVE + "(２層)"; }
    else if (map_file == Fix.MAPFILE_MYSTIC_FOREST) { return Fix.DUNGEON_MYSTIC_FOREST; }
    else if (map_file == Fix.MAPFILE_OHRAN_TOWER) { return Fix.DUNGEON_OHRAN_TOWER; }
    else if (map_file == Fix.MAPFILE_VELGUS) { return Fix.DUNGEON_VELGUS_SEA_TEMPLE; }
    else if (map_file == Fix.MAPFILE_VELGUS_2) { return Fix.DUNGEON_VELGUS_SEA_TEMPLE_2; }
    else if (map_file == Fix.MAPFILE_VELGUS_3) { return Fix.DUNGEON_VELGUS_SEA_TEMPLE_3; }
    else if (map_file == Fix.MAPFILE_VELGUS_4) { return Fix.DUNGEON_VELGUS_SEA_TEMPLE_4; }
    else if (map_file == Fix.MAPFILE_GATE_OF_DHAL) { return Fix.DUNGEON_GATE_OF_DHAL; }
    else if (map_file == Fix.MAPFILE_DISKEL) { return Fix.DUNGEON_DISKEL_BATTLE_FIELD; }
    else if (map_file == Fix.MAPFILE_EDELGARZEN) { return Fix.DUNGEON_EDELGARZEN_CASTLE; }
    else if (map_file == Fix.MAPFILE_EDELGARZEN_2) { return Fix.DUNGEON_EDELGARZEN_CASTLE_2; }
    else if (map_file == Fix.MAPFILE_EDELGARZEN_3) { return Fix.DUNGEON_EDELGARZEN_CASTLE_3; }
    else if (map_file == Fix.MAPFILE_EDELGARZEN_4) { return Fix.DUNGEON_EDELGARZEN_CASTLE_4; }
    else if (map_file == Fix.MAPFILE_SNOWTREE_LATA) { return Fix.DUNGEON_SNOWTREE_LATA; }
    else if (map_file == Fix.MAPFILE_GENESISGATE) { return Fix.DUNGEON_HEAVENS_GENESIS_GATE; }

    return map_file;
  }
}
