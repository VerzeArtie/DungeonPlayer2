using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;
using System.Xml;
using System.Text;
using System;
using System.Reflection;
using System.Xml.XPath;

public class DungeonField : MotherBase
{
  public enum Direction
  {
    None,
    Top,
    Left,
    Right,
    Bottom,
    Upper,
    Under,
  }

  // developer-mode
  public TileInformation SelectField;
  public Text txtSelectName;
  public Text txtEditMode;
  public Text txtCurrentCursor;
  public Text txtCurrentCursor2;

  // prefab
  public TileInformation prefab_FieldNormal;
  public TileInformation prefab_FieldSea;
  public TileInformation prefab_FieldBridge1;
  public TileInformation prefab_FieldBridge2;
  public TileInformation prefab_FieldWall;
  public TileInformation prefab_Town1;
  public TileInformation prefab_Fountain1;
  public TileInformation prefab_Castle1;
  public TileInformation prefab_Dungeon1;
  public TileInformation prefab_Snow;
  public TileInformation prefab_SnowWall;
  public TileInformation prefab_Waste;
  public TileInformation prefab_WasteWall;
  public TileInformation prefab_Artharium_Normal;
  public TileInformation prefab_Artharium_Debris;
  public TileInformation prefab_Artharium_Poison;
  public TileInformation prefab_Artharium_Bridge1;
  public TileInformation prefab_Artharium_Bridge2;
  public TileInformation prefab_Artharium_Wall;
  public TileInformation prefab_Upstair;
  public GameObject prefab_Player;
  public FieldObject prefab_Treasure;

  public GameObject GroupDecision;
  public Text txtDecisionTitle;
  public Text txtDecisionMessage;

  // MapSelect
  public GameObject GroupMapSelect;
  public List<Text> txtMapSelect;
  public GameObject background3;
  public GameObject LayoutBottom;

  // Group
  public GroupCharacterStatus groupCharacterStatus;

  // GUI
  public Camera MainCamera;
  public Light PlayerLight;

  // System
  public GameObject GroupSystem;

  //public List<GameObject> GroupPlayerPanelList;
  //public List<Text> PlayerNameList;
  //public List<Text> PlayerLifeTextList;
  //public List<Image> PlayerLifeGaugeList;
  public GameObject GroupCharacterList;
  public NodeMiniChara nodeCharaPanel;

  // Quest Message
  public GameObject GroupQuestMessage;
  public Text txtQuestMessage;
  public GameObject panelSystemMessage;
  public Text txtSystemMessage;
  public GameObject objBlackOut;

  // GameOver
  public GameObject panelGameOver;
  public Text txtGameOver;

  // Quest ( same HomeTown )
  public GameObject GroupDungeonPlayer;
  public GameObject contentDungeonPlayer;
  public NodeButton nodeButton;
  public Image imgEventIcon;
  public Text txtEventTitle;
  public Text txtEventDescription;

  // Inner Value
  private GameObject Player;
  private List<TileInformation> TileList = new List<TileInformation>();
  private List<FieldObject> FieldObjList = new List<FieldObject>();
  private List<Character> PlayerList = new List<Character>();
  private List<NodeMiniChara> MiniCharaList = new List<NodeMiniChara>();

  private string HomeTownCall = string.Empty;
  private bool HomeTownComplete = false;
  private string DungeonCall = string.Empty;
  private string DungeonMap = string.Empty;
  private bool DungeonCallComplete = false;

  protected List<string> QuestMessageList = new List<string>();
  protected List<MessagePack.ActionEvent> QuestEventList = new List<MessagePack.ActionEvent>();

  private bool EditMode = false;

  List<string> PrefabList = new List<string>();

  private int BattleEncount = 10;
  private int CumulativeBattleCounter = 0;

  private string CurrentMapSelectName = String.Empty;

  private bool GameOver = false;

  // Start is called before the first frame update
  public override void Start()
  {
    base.Start();

    // debug
    //One.MC.CurrentLife = 1;
    //One.SC.CurrentLife = 12;
    //One.TC.CurrentLife = 52;
    //One.FC.CurrentLife = 19;
    ////One.TF.Field_X = 17;
    ////One.TF.Field_Y = 1;
    ////One.TF.Field_Z = 4;
    //One.TF.Field_X = 2;
    //One.TF.Field_Y = 1;
    //One.TF.Field_Z = 2;
    // debug

    One.TF.SaveByDungeon = true;

    // プレハブの設定
    PrefabList.Add("Plain");
    PrefabList.Add("Sea");
    PrefabList.Add("Bridge1");
    PrefabList.Add("Bridge2");
    PrefabList.Add("Wall_1");
    PrefabList.Add("Town_1");
    PrefabList.Add("Fountain_1");
    PrefabList.Add("Castle_1");
    PrefabList.Add("Dungeon_1");
    PrefabList.Add("Snow");
    PrefabList.Add("SnowWall");
    PrefabList.Add("Waste");
    PrefabList.Add("WasteWall");
    PrefabList.Add("Artharium_Normal");
    PrefabList.Add("Artharium_Wall");
    PrefabList.Add("Artharium_Poison");
    PrefabList.Add("Artharium_Debris");
    PrefabList.Add("Artharium_Bridge1");
    PrefabList.Add("Artharium_Bridge2");
    PrefabList.Add("Upstair");

    // マップセレクトを設定
    for (int ii = 0; ii < txtMapSelect.Count; ii++)
    {
      txtMapSelect[ii].text = "???";
    }
    background3.SetActive(false);
    LayoutBottom.SetActive(false);

    int counter = 0;
    if (One.TF.AvailableAnshet) { txtMapSelect[counter].text = Fix.TOWN_ANSHET; }
    counter++;
    if (One.TF.AvailableGoratrum) { txtMapSelect[counter].text = Fix.DUNGEON_GORATRUM_CAVE; }
    counter++;
    if (One.TF.AvailableQvelta) { txtMapSelect[counter].text = Fix.TOWN_QVELTA_TOWN; }
    counter++;
    if (One.TF.AvailableArtharium) { txtMapSelect[counter].text = Fix.DUNGEON_ARTHARIUM_FACTORY; }
    counter++;
    if (One.TF.AvailableCotuhsye) { txtMapSelect[counter].text = Fix.TOWN_COTUHSYE; }
    counter++;
    if (One.TF.AvailableZhalman) { txtMapSelect[counter].text = Fix.TOWN_ZHALMAN; }
    counter++;
    if (One.TF.AvailableOhran) { txtMapSelect[counter].text = Fix.TOWER_OHRAN; }
    counter++;
    if (One.TF.AvailableVelgus) { txtMapSelect[counter].text = Fix.DUNGEON_VELGUS_SEA_TEMPLE; }
    counter++;
    if (One.TF.AvailableArcaneDine) { txtMapSelect[counter].text = Fix.TOWN_ARCANEDINE; }
    counter++;
    if (One.TF.AvailableParmetysia) { txtMapSelect[counter].text = Fix.TOWN_PARMETYSIA; }
    counter++;
    if (One.TF.AvailableSaritan) { txtMapSelect[counter].text = Fix.DUNGEON_RUINS_OF_SARITAN; }
    counter++;
    if (One.TF.AvailableDhal) { txtMapSelect[counter].text = Fix.DUNGEON_GATE_OF_DHAL; }
    counter++;
    if (One.TF.AvailableDale) { txtMapSelect[counter].text = Fix.TOWN_DALE; }
    counter++;
    if (One.TF.AvailableDiskel) { txtMapSelect[counter].text = Fix.DUNGEON_DISKEL_BATTLE_FIELD; }
    counter++;
    if (One.TF.AvailableGanro) { txtMapSelect[counter].text = Fix.DUNGEON_GANRO_FORTRESS; }
    counter++;
    if (One.TF.AvailableEdelgarzen) { txtMapSelect[counter].text = Fix.TOWN_EDELGARZEN_CASTLE; }
    counter++;
    if (One.TF.AvailableLoslon) { txtMapSelect[counter].text = Fix.DUNGEON_LOSLON_CAVE; }
    counter++;
    if (One.TF.AvailableZelman) { txtMapSelect[counter].text = Fix.TOWN_ZELMAN; }
    counter++;
    if (One.TF.AvailableLataHouse) { txtMapSelect[counter].text = Fix.TOWN_LATA_HOSE; }
    counter++;
    if (One.TF.AvailableSithGraveyard) { txtMapSelect[counter].text = Fix.DUNGEON_SITH_GRAVEYARD; }
    counter++;
    if (One.TF.AvailableFran) { txtMapSelect[counter].text = Fix.TOWER_FRAN; }
    counter++;
    if (One.TF.AvailableSnowtreeLata) { txtMapSelect[counter].text = Fix.DUNGEON_SNOWTREE_LATA; }
    counter++;
    if (One.TF.AvailableWosm) { txtMapSelect[counter].text = Fix.TOWN_WOSM; }
    counter++;
    if (One.TF.AvailableFazilCastle) { txtMapSelect[counter].text = Fix.TOWN_FAZIL_CASTLE; }
    counter++;

    if (One.TF.AvailableHeavenGenesisGate)
    {
      txtMapSelect[counter].text = Fix.FIELD_HEAVENS_GENESIS_GATE;
      background3.SetActive(true);
      LayoutBottom.SetActive(true);
    }
    counter++;

    // プレイヤーリスト
    List<Character> list = One.AvailableCharacters();
    for (int ii = 0; ii < list.Count; ii++)
    {
      NodeMiniChara current = Instantiate(nodeCharaPanel) as NodeMiniChara;
      current.Refresh(list[ii]);
      current.transform.SetParent(GroupCharacterList.transform);
      MiniCharaList.Add(current);

      PlayerList.Add(list[ii]);
    }

    // プレイヤーを設置
    this.Player = Instantiate(prefab_Player, new Vector3(0, 0, 0), Quaternion.identity) as GameObject; // インスタント生成で位置情報は無意味とする。

    // タイルを設置
    LoadTileMapping(One.TF.CurrentDungeonField);

    // プレイヤー位置を設定
    JumpToLocation(new Vector3(One.TF.Field_X, One.TF.Field_Y, One.TF.Field_Z));

    // トレジャーなどのフィールドオブジェクトを設置
    //FieldObject obj = Instantiate(prefab_Treasure, new Vector3(3, 1, 3), Quaternion.identity) as FieldObject;
    // FieldObjList.Add(obj);

    // キャラクター情報を画面へ反映
    UpdateCharacterStatus();
  }

  // Update is called once per frame
  void Update()
  {
    // Editモード（開発者専用）
    if (EditMode)
    {
      txtCurrentCursor.text = SelectField.transform.position.ToString();

      if (Input.GetMouseButtonDown(0))
      {
        Debug.Log("time-1: " + DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString());
        //Debug.Log("GetMouseButton");
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        List<RaycastResult> raycast = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycast);
        //foreach (RaycastResult ray_data in raycast)

        Debug.Log("time-2: " + DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString());

        for (int ii = 0; ii < raycast.Count; ii++)
        {
          //Debug.Log("current: " + raycast[ii].ToString());

          // ボタン押下時はヒット判定対象外とする。
          if (raycast[ii].ToString().Contains("btn"))
          {
            return;
          }
        }

        Debug.Log("time-3: " + DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString());

        TileInformation objTile = GetTileInfo(SelectField.transform.position.x,
                                              SelectField.transform.position.y,
                                              SelectField.transform.position.z);
        if (objTile != null)
        {
          TileList.Remove(objTile);
          //Debug.Log("objTile Remove");
          Destroy(objTile.gameObject);
          return;
        }

        Debug.Log("time-4: " + DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString());
        AddTile(txtSelectName.text, SelectField.transform.position);
        Debug.Log("time-5: " + DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString());
        return;
      }

      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
        SelectField.transform.position = new Vector3(SelectField.transform.position.x,
                                                     SelectField.transform.position.y + 0.5f,
                                                     SelectField.transform.position.z);
      }
      if (Input.GetKeyDown(KeyCode.X))
      {
        SelectField.transform.position = new Vector3(SelectField.transform.position.x,
                                                     SelectField.transform.position.y - 0.5f,
                                                     SelectField.transform.position.z);
      }
      if (Input.GetKeyDown(KeyCode.A))
      {
        SelectField.transform.position = new Vector3(SelectField.transform.position.x - 1,
                                                     SelectField.transform.position.y,
                                                     SelectField.transform.position.z);
      }
      if (Input.GetKeyDown(KeyCode.D))
      {
        SelectField.transform.position = new Vector3(SelectField.transform.position.x + 1,
                                                     SelectField.transform.position.y,
                                                     SelectField.transform.position.z);
      }
      if (Input.GetKeyDown(KeyCode.S))
      {
        SelectField.transform.position = new Vector3(SelectField.transform.position.x,
                                                     SelectField.transform.position.y,
                                                     SelectField.transform.position.z - 1);
      }
      if (Input.GetKeyDown(KeyCode.W))
      {
        SelectField.transform.position = new Vector3(SelectField.transform.position.x,
                                                     SelectField.transform.position.y,
                                                     SelectField.transform.position.z + 1);
      }
      if (Input.GetKey(KeyCode.LeftArrow))
      {
        MainCamera.transform.position = new Vector3(MainCamera.transform.position.x - 0.1f,
            MainCamera.transform.position.y,
            MainCamera.transform.position.z);
      }
      if (Input.GetKey(KeyCode.RightArrow))
      {
        MainCamera.transform.position = new Vector3(MainCamera.transform.position.x + 0.1f,
            MainCamera.transform.position.y,
            MainCamera.transform.position.z);
      }
      if (Input.GetKey(KeyCode.DownArrow))
      {
        MainCamera.transform.position = new Vector3(MainCamera.transform.position.x,
            MainCamera.transform.position.y,
            MainCamera.transform.position.z - 0.1f);
      }
      if (Input.GetKey(KeyCode.UpArrow))
      {
        MainCamera.transform.position = new Vector3(MainCamera.transform.position.x,
            MainCamera.transform.position.y,
            MainCamera.transform.position.z + 0.1f);
      }
      if (Input.GetKey(KeyCode.I))
      {
        MainCamera.transform.position = new Vector3(MainCamera.transform.position.x,
            MainCamera.transform.position.y + 0.1f,
            MainCamera.transform.position.z);
      }
      if (Input.GetKey(KeyCode.K))
      {
        MainCamera.transform.position = new Vector3(MainCamera.transform.position.x,
            MainCamera.transform.position.y - 0.1f,
            MainCamera.transform.position.z);
      }

      if (Input.GetKey(KeyCode.Alpha1))
      {
        Quaternion q = Quaternion.AngleAxis(1, Vector3.up);
        MainCamera.transform.rotation = MainCamera.transform.rotation * q;
      }
      if (Input.GetKey(KeyCode.Alpha3))
      {
        Quaternion q = Quaternion.AngleAxis(1, Vector3.down);
        MainCamera.transform.rotation = MainCamera.transform.rotation * q;
      }
      if (Input.GetKey(KeyCode.Q))
      {
        Quaternion q = Quaternion.AngleAxis(1, Vector3.left);
        MainCamera.transform.rotation = MainCamera.transform.rotation * q;
      }
      if (Input.GetKey(KeyCode.E))
      {
        Quaternion q = Quaternion.AngleAxis(1, Vector3.right);
        MainCamera.transform.rotation = MainCamera.transform.rotation * q;
      }
      if (Input.GetKey(KeyCode.Z))
      {
        Quaternion q = Quaternion.AngleAxis(1, Vector3.forward);
        MainCamera.transform.rotation = MainCamera.transform.rotation * q;
      }
      if (Input.GetKey(KeyCode.C))
      {
        Quaternion q = Quaternion.AngleAxis(1, Vector3.back);
        MainCamera.transform.rotation = MainCamera.transform.rotation * q;
      }
      return;
    }

    // 通常モード
    txtCurrentCursor2.text = this.Player.transform.position.ToString();
    if (this.HomeTownComplete || this.DungeonCallComplete)
    {
      return;
    }
    if (this.GroupQuestMessage.activeInHierarchy)
    {
      return;
    }
    if (this.GameOver)
    {
      return;
    }

    if (this.HomeTownCall != string.Empty && this.HomeTownComplete == false)
    {
      this.HomeTownComplete = true;
      One.TF.CurrentAreaName = this.HomeTownCall;
      SceneDimension.JumpToHomeTown();
      return;
    }
    if (this.DungeonCall != string.Empty && this.DungeonMap != string.Empty && this.DungeonCallComplete == false)
    {
      this.DungeonCallComplete = true;
      // todo
      Debug.Log("DungeonCallComplete: " + this.DungeonCall + " " + this.DungeonMap);
      SceneDimension.JumpToDungeonField(this.DungeonMap);
      return;
    }

    bool detectKey = false;
    TileInformation tile = null;
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      tile = SearchNextTile(this.Player.transform.position, Direction.Right);
      if (BlockCheck(Player, tile) == false)
      {
        return;
      }

      detectKey = true;
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      tile = SearchNextTile(this.Player.transform.position, Direction.Left);
      if (BlockCheck(Player, tile) == false)
      {
        return;
      }

      detectKey = true;
    }
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      tile = SearchNextTile(this.Player.transform.position, Direction.Top);
      if (BlockCheck(Player, tile) == false)
      {
        return;
      }

      detectKey = true;
    }
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      tile = SearchNextTile(this.Player.transform.position, Direction.Bottom);
      if (BlockCheck(Player, tile) == false)
      {
        return;
      }

      detectKey = true;
    }

    if (Input.GetKey(KeyCode.Alpha2))
    {
      MainCamera.transform.position = new Vector3(MainCamera.transform.position.x,
          MainCamera.transform.position.y + 0.1f,
          MainCamera.transform.position.z);
    }
    if (Input.GetKey(KeyCode.X))
    {
      MainCamera.transform.position = new Vector3(MainCamera.transform.position.x,
        MainCamera.transform.position.y - 0.1f,
        MainCamera.transform.position.z);
    }
    if (Input.GetKey(KeyCode.A))
    {
      MainCamera.transform.position = new Vector3(MainCamera.transform.position.x - 0.1f,
          MainCamera.transform.position.y,
          MainCamera.transform.position.z);
    }
    if (Input.GetKey(KeyCode.D))
    {
      MainCamera.transform.position = new Vector3(MainCamera.transform.position.x + 0.1f,
          MainCamera.transform.position.y,
          MainCamera.transform.position.z);
    }
    if (Input.GetKey(KeyCode.S))
    {
      MainCamera.transform.position = new Vector3(MainCamera.transform.position.x,
          MainCamera.transform.position.y,
          MainCamera.transform.position.z - 0.1f);
    }
    if (Input.GetKey(KeyCode.W))
    {
      MainCamera.transform.position = new Vector3(MainCamera.transform.position.x,
          MainCamera.transform.position.y,
          MainCamera.transform.position.z + 0.1f);
    }
    if (Input.GetKey(KeyCode.Alpha1))
    {
      Quaternion q = Quaternion.AngleAxis(1, Vector3.up);
      MainCamera.transform.rotation = MainCamera.transform.rotation * q;
    }
    if (Input.GetKey(KeyCode.Alpha3))
    {
      Quaternion q = Quaternion.AngleAxis(1, Vector3.down);
      MainCamera.transform.rotation = MainCamera.transform.rotation * q;
    }
    if (Input.GetKey(KeyCode.Q))
    {
      Quaternion q = Quaternion.AngleAxis(1, Vector3.left);
      MainCamera.transform.rotation = MainCamera.transform.rotation * q;
    }
    if (Input.GetKey(KeyCode.E))
    {
      Quaternion q = Quaternion.AngleAxis(1, Vector3.right);
      MainCamera.transform.rotation = MainCamera.transform.rotation * q;
    }
    if (Input.GetKey(KeyCode.Z))
    {
      Quaternion q = Quaternion.AngleAxis(1, Vector3.forward);
      MainCamera.transform.rotation = MainCamera.transform.rotation * q;
    }
    if (Input.GetKey(KeyCode.C))
    {
      Quaternion q = Quaternion.AngleAxis(1, Vector3.back);
      MainCamera.transform.rotation = MainCamera.transform.rotation * q;
    }

    if (detectKey)
    {
      JumpToLocation(new Vector3(tile.transform.position.x,
                                 tile.transform.position.y + 1.0f,
                                 tile.transform.position.z));

      One.PlaySoundEffect(Fix.SOUND_FOOT_STEP);

      DetectEvent(tile);

      DetectDamage(tile);

      bool result = JudgePartyDead();
      if (result)
      {
        this.GameOver = true;
        txtGameOver.text = "ダンジョン攻略に失敗しました・・・最後に出たホームタウンへ帰還します。";
        panelGameOver.SetActive(true);
        return;
      }

      DetectEncount();
    }
  }

  public void TapMapReload(Text txtMap)
  {
    ClearAllMapTile();
    One.TF.CurrentDungeonField = "MapData_" + txtMap.text + ".txt";
    // タイルを設置
    LoadTileMapping(One.TF.CurrentDungeonField);
  }

  public void TapFastTravel()
  {
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_BASE_FIELD)
    {
      GroupMapSelect.SetActive(true);
    }
    else
    {
      txtDecisionTitle.text = "ホームタウンへ帰還しますか？";
      int cost = One.TF.Gold / 4;
      txtDecisionMessage.text = "ダンジョン内から直接帰還した場合、" + cost.ToString() + " ゴールド消費する事となります。";
      GroupDecision.SetActive(true);
    }
  }

  public void TapDungeonPlayer()
  {
    if (GroupDungeonPlayer.activeInHierarchy)
    {
      GroupDungeonPlayer.SetActive(false);
    }
    else
    {
      RefreshQuestList();
      GroupDungeonPlayer.SetActive(true);
      groupCharacterStatus.gameObject.SetActive(false);
      GroupSystem.SetActive(false);
      GroupMapSelect.SetActive(false);
    }
  }

  public void TapDecisionAccept()
  {
    One.TF.Gold -= One.TF.Gold / 4;
    One.TF.CurrentAreaName = this.CurrentMapSelectName;
    SceneManager.LoadSceneAsync("HomeTown");
  }

  public void TapDecisionCancel()
  {
    this.CurrentMapSelectName = String.Empty;
    GroupDecision.SetActive(false);
  }

  public void TapMapSelectBack()
  {
    this.CurrentMapSelectName = String.Empty;
    GroupMapSelect.SetActive(false);
  }

  public void TapMapSelectChoose(Text map_text)
  {
    Debug.Log("MapSelectChoose: " + map_text.text);

    if (map_text.text == "???") { return; }

    this.CurrentMapSelectName = map_text.text;
    txtDecisionTitle.text = map_text.text + "へ移動しますか？";
    txtDecisionMessage.text = "";
    GroupDecision.SetActive(true);
  }

  public void TapPlayerStatus(Text player_text)
  {
    if (One.PlayerList == null) { Debug.Log("PlayerList is null..."); return; }

    // 既にプレイヤーステータスが開かれており、同一の名前だった場合は、その画面を閉じる。
    if (groupCharacterStatus.gameObject.activeInHierarchy && groupCharacterStatus.CurrentPlayer?.FullName == player_text.text)
    {
      groupCharacterStatus.gameObject.SetActive(false);
      return;
    }

    for (int ii = 0; ii < One.PlayerList.Count; ii++)
    {
      if (One.PlayerList[ii] == null) { Debug.Log("PlayerList[" + ii.ToString() + "] is null..."); return; }

      if (One.PlayerList[ii].FullName == player_text.text)
      {
        One.PlayerList[ii].GetReadyLevelUp();
        groupCharacterStatus.parentMotherBase = this;
        groupCharacterStatus.ReleaseIt();
        groupCharacterStatus.CurrentPlayer = One.PlayerList[ii];
        groupCharacterStatus.UpdateCharacterDetailView(One.PlayerList[ii]);
        break;
      }
    }

    groupCharacterStatus.gameObject.SetActive(true);
  }

  public void TapCharacterDetailBack()
  {
    //groupCharacterStatus.gameObject.SetActive(false);
  }

  public void TapBattleConfig()
  {
  }

  public void TapOK()
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    for (int ii = 0; ii < Fix.INFINITY; ii++)
    {
      // メッセージが在る場合は、メッセージを進行する。
      if (QuestMessageList.Count > 0)
      {
        MessagePack.ActionEvent currentEvent = QuestEventList[0];
        string currentMessage = QuestMessageList[0];
        RemoveOneSentence();
        GroupQuestMessage.SetActive(true);

        // ブラックアウトしている画面から元に戻す。
        if (currentEvent == MessagePack.ActionEvent.ReturnToNormal)
        {
          this.objBlackOut.SetActive(false);
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.Fountain)
        {
          EventFountain();
          continue; // 継続
        }
        // 画面にシステムメッセージを表示する。
        else if (currentEvent == MessagePack.ActionEvent.HomeTownMessageDisplay)
        {
          this.txtSystemMessage.text = currentMessage;
          this.panelSystemMessage.SetActive(true);
          return;
        }
        // 画面にクエスト開始メッセージを表示する。
        else if (currentEvent == MessagePack.ActionEvent.GetNewQuest)
        {
          this.txtSystemMessage.text = currentMessage;
          this.panelSystemMessage.SetActive(true);

          // todo
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[0])) { One.TF.QuestMain_00001 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[1])) { One.TF.QuestMain_00002 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[2])) { One.TF.QuestMain_00003 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[3])) { One.TF.QuestMain_00004 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[4])) { One.TF.QuestMain_00005 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[5])) { One.TF.QuestMain_00006 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[6])) { One.TF.QuestMain_00007 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[7])) { One.TF.QuestMain_00008 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[8])) { One.TF.QuestMain_00009 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[9])) { One.TF.QuestMain_00010 = true; }
          RefreshQuestList();
          return;
        }
        // 画面にクエスト完了メッセージを表示する。
        else if (currentEvent == MessagePack.ActionEvent.QuestComplete)
        {
          this.txtSystemMessage.text = currentMessage;
          this.panelSystemMessage.SetActive(true);

          // todo
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[0])) { One.TF.QuestMain_Complete_00001 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[1])) { One.TF.QuestMain_Complete_00002 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[2])) { One.TF.QuestMain_Complete_00003 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[3])) { One.TF.QuestMain_Complete_00004 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[4])) { One.TF.QuestMain_Complete_00005 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[5])) { One.TF.QuestMain_Complete_00006 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[6])) { One.TF.QuestMain_Complete_00007 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[7])) { One.TF.QuestMain_Complete_00008 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[8])) { One.TF.QuestMain_Complete_00009 = true; }
          if (currentMessage.Contains(Fix.QUEST_EVENT_TITLE[9])) { One.TF.QuestMain_Complete_00010 = true; }
          RefreshQuestList();
          return;
        }
        // マップ上を自動移動（左）
        else if (currentEvent == MessagePack.ActionEvent.MoveLeft)
        {
          TileInformation tile = SearchNextTile(this.Player.transform.position, Direction.Left);
          JumpToLocation(new Vector3(tile.transform.position.x,
                                     tile.transform.position.y + 1.0f,
                                     tile.transform.position.z));
        }
        // マップ上を自動移動（右）
        else if (currentEvent == MessagePack.ActionEvent.MoveRight)
        {
          TileInformation tile = SearchNextTile(this.Player.transform.position, Direction.Right);
          JumpToLocation(new Vector3(tile.transform.position.x,
                                     tile.transform.position.y + 1.0f,
                                     tile.transform.position.z));
        }
        // マップ上を自動移動（上）
        else if (currentEvent == MessagePack.ActionEvent.MoveTop)
        {
          TileInformation tile = SearchNextTile(this.Player.transform.position, Direction.Top);
          JumpToLocation(new Vector3(tile.transform.position.x,
                                     tile.transform.position.y + 1.0f,
                                     tile.transform.position.z));
        }
        // マップ上を自動移動（下）
        else if (currentEvent == MessagePack.ActionEvent.MoveBottom)
        {
          TileInformation tile = SearchNextTile(this.Player.transform.position, Direction.Bottom);
          JumpToLocation(new Vector3(tile.transform.position.x,
                                     tile.transform.position.y + 1.0f,
                                     tile.transform.position.z));
        }
        // 通常メッセージ表示（システムメッセージが出ている場合は消す）
        else if (currentEvent == MessagePack.ActionEvent.None)
        {
          this.panelSystemMessage.SetActive(false);
          this.txtQuestMessage.text = currentMessage;
          return;
        }
      }
    }

    // メッセージが無くなったら、元の画面に戻す。
    if (this.QuestMessageList.Count <= 0)
    {
      this.GroupQuestMessage.SetActive(false);
      this.QuestMessageList.Clear();
      Debug.Log(MethodBase.GetCurrentMethod() + " Message Clear");
    }
  }

  private void RemoveOneSentence()
  {
    if (this.QuestMessageList.Count > 0)
    {
      this.QuestMessageList.RemoveAt(0);
    }
    if (this.QuestEventList.Count > 0)
    {
      this.QuestEventList.RemoveAt(0);
    }
  }

  public void TapMapData()
  {
    SaveTileMapping(One.TF.CurrentDungeonField);
  }

  public void TapNoBattle(Text txt)
  {
    if (txt.text == "Battle Enable")
    {
      BattleEncount = -1;
      txt.text = "No Battle";
    }
    else
    {
      BattleEncount = 10;
      txt.text = "Battle Enable";
    }
  }

  public void TapSelectNameBack()
  {
    for (int ii = PrefabList.Count - 1; ii >= 0; ii--)
    {
      if (txtSelectName.text == PrefabList[ii])
      {
        if (ii <= 0)
        {
          txtSelectName.text = PrefabList[PrefabList.Count - 1];
        }
        else
        {
          txtSelectName.text = PrefabList[ii - 1];
        }
        return;
      }
    }
  }
  public void TapSelectName()
  {
    for (int ii = 0; ii < PrefabList.Count; ii++)
    {
      if (txtSelectName.text == PrefabList[ii])
      {
        if (ii >= PrefabList.Count - 1)
        {
          txtSelectName.text = PrefabList[0];
        }
        else
        {
          txtSelectName.text = PrefabList[ii + 1];
        }
        return;
      }
    }
  }

  public void TapEditMode()
  {
    this.EditMode = !this.EditMode;
    if (this.EditMode)
    {
      txtEditMode.text = "Edit";
    }
    else
    {
      txtEditMode.text = "Move";
    }
  }

  public void TapSystem()
  {
    GroupSystem.SetActive(true);
  }

  public void TapSystemCancel()
  {
    GroupSystem.SetActive(false);
  }

  public void TapSave()
  {
    SceneDimension.CallSaveLoad(this, true, false);
  }

  public void TapLoad()
  {
    SceneDimension.CallSaveLoad(this, false, false);
  }

  public void TapBacktoTown()
  {
    Debug.Log("TapBacktoTown(S)");
    this.HomeTownComplete = true;
    SceneDimension.JumpToHomeTown();
  }

  private void DetectEvent(TileInformation tile)
  {
    Debug.Log("DetectEvent: " + tile.transform.position.x + " " + tile.transform.position.y + " " + tile.transform.position.z);
    // 回復の泉
    if (tile != null && tile.field == TileInformation.Field.Fountain_1)
    {
      MessagePack.Message101000(ref QuestMessageList, ref QuestEventList);
      TapOK();
      GroupQuestMessage.SetActive(true);
      return;
    }

    // todo town , castle, field, dungeonの属性分けが誤っている。
    // field
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_BASE_FIELD)
    {
      if (LocationDetect(tile, -47, 3.5f, 17))
      {
        Debug.Log("Detect Message101001");
        MessagePack.Message101001(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }
      if (LocationDetect(tile, -49, 3.5f, 19))
      {
        Debug.Log("Detect Message101002");
        MessagePack.Message101002(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }
      if (LocationDetect(tile, -51, 3.5f, 17))
      {
        Debug.Log("Detect Message101003");
        MessagePack.Message101003(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }
      if (LocationDetect(tile, 26, 0, 4))
      {
        Debug.Log("Detect Message101004");
        MessagePack.Message101004(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }
    }
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
    {
      if (LocationDetect(tile, -4, 0, 19))
      {
        if (One.TF.Event_Message300030 == false)
        {
          Debug.Log("Detect Message300030");
          One.TF.Event_Message300030 = true;
          MessagePack.Message300030(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
        }
        else
        {
          MessagePack.Message300031(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
        }
      }
    }

    if (tile != null && tile.field == TileInformation.Field.Upstair)
    {
      if (One.TF.CurrentDungeonField == Fix.DUNGEON_ARTHARIUM_FACTORY)
      {
        this.DungeonMap = Fix.MAPFILE_BASE_FIELD;
        this.DungeonCall = Fix.MAPFILE_BASE_FIELD;
        One.TF.Field_X = 25;
        One.TF.Field_Y = 3;
        One.TF.Field_Z = 32;
      }
    }

    // Town , Castle
    if ((tile != null && tile.field == TileInformation.Field.Town_1) ||
        (tile != null && tile.field == TileInformation.Field.Castle_1))
    {
      if (tile.transform.position.x == -44 && tile.transform.position.y == 1 && tile.transform.position.z == 4)
      {
        this.HomeTownCall = Fix.TOWN_ANSHET;
      }
      else if (tile.transform.position.x == -49 && tile.transform.position.y == 4 && tile.transform.position.z == 17)
      {
        this.HomeTownCall = Fix.TOWN_FAZIL_CASTLE;
      }
      else if (tile.transform.position.x == 24 && tile.transform.position.y == 0 && tile.transform.position.z == 4)
      {
        this.HomeTownCall = Fix.TOWN_QVELTA_TOWN;
      }
      else if (tile.transform.position.x == 65 && tile.transform.position.y == 0 && tile.transform.position.z == -6)
      {
        this.HomeTownCall = Fix.TOWN_COTUHSYE;
      }
      else if (tile.transform.position.x == 52 && tile.transform.position.y == 6.5 && tile.transform.position.z == 43)
      {
        this.HomeTownCall = Fix.TOWN_ZHALMAN;
      }
      else if (tile.transform.position.x == -99 && tile.transform.position.y == 0 && tile.transform.position.z == 2)
      {
        this.HomeTownCall = Fix.TOWN_WOSM;
      }
      else if (tile.transform.position.x == -85 && tile.transform.position.y == 0.5 && tile.transform.position.z == 49)
      {
        this.HomeTownCall = Fix.TOWN_ARCANEDINE;
      }
      else if (tile.transform.position.x == -32 && tile.transform.position.y == 0.5 && tile.transform.position.z == 67)
      {
        this.HomeTownCall = Fix.TOWN_DALE;
      }
      else if (tile.transform.position.x == -4 && tile.transform.position.y == 9 && tile.transform.position.z == 34)
      {
        this.HomeTownCall = Fix.TOWER_OHRAN;
      }
      else if (tile.transform.position.x == 59 && tile.transform.position.y == 0.5 && tile.transform.position.z == 92)
      {
        this.HomeTownCall = Fix.TOWN_LATA_HOSE;
      }
      else if (tile.transform.position.x == 52 && tile.transform.position.y == 6.5 && tile.transform.position.z == 49)
      {
        this.HomeTownCall = Fix.TOWN_ZELMAN;
      }
      else if (tile.transform.position.x == 24 && tile.transform.position.y == 13 && tile.transform.position.z == 53)
      {
        this.HomeTownCall = Fix.TOWER_FRAN;
      }
      else if (tile.transform.position.x == -100 && tile.transform.position.y == 2 && tile.transform.position.z == 77)
      {
        this.HomeTownCall = Fix.TOWN_PARMETYSIA;
      }
      else if (tile.transform.position.x == 19 && tile.transform.position.y == 8 && tile.transform.position.z == 77)
      {
        this.HomeTownCall = Fix.TOWN_EDELGARZEN_CASTLE;
      }
      else
      {
        // 何も設定しない
        Debug.Log("Not detect tile event(town): " + tile.transform.position.ToString());
      }
      return;
    }
    // Dungeon
    if (tile != null && tile.field == TileInformation.Field.Dungeon_1)
    {
      Debug.Log("Detect Dungeon_1: " + tile.transform.position.x + " " + tile.transform.position.y + " " + tile.transform.position.z);
      if (tile.transform.position.x == 25 && tile.transform.position.y == 2 && tile.transform.position.z == 33)
      {
        Debug.Log("Detect Artharium");
        this.DungeonMap = Fix.MAPFILE_ARTHARIUM;
        this.DungeonCall = Fix.DUNGEON_ARTHARIUM_FACTORY;
        One.TF.Field_X = 1;
        One.TF.Field_Y = 1;
        One.TF.Field_Z = 1;
      }
      if (tile.transform.position.x == -27 && tile.transform.position.y == 0 && tile.transform.position.z == -7)
      {
        this.DungeonMap = Fix.MAPFILE_GORATRUM;
        this.DungeonCall = Fix.DUNGEON_GORATRUM_CAVE;
      }
      else if (tile.transform.position.x == -69 && tile.transform.position.y == 0 && tile.transform.position.z == 33)
      {
        this.DungeonCall = Fix.DUNGEON_VELGUS_SEA_TEMPLE;
      }
      else if (tile.transform.position.x == -109 && tile.transform.position.y == 0.5 && tile.transform.position.z == 34)
      {
        this.DungeonCall = Fix.DUNGEON_RUINS_OF_SARITAN;
      }
      else if (tile.transform.position.x == -112 && tile.transform.position.y == 7 && tile.transform.position.z == 95)
      {
        this.DungeonCall = Fix.DUNGEON_SNOWTREE_LATA;
      }
      else if (tile.transform.position.x == -24 && tile.transform.position.y == -3.5 && tile.transform.position.z == 36)
      {
        this.DungeonCall = Fix.DUNGEON_DISKEL_BATTLE_FIELD;
      }
      else if (tile.transform.position.x == 50 && tile.transform.position.y == 0.5 && tile.transform.position.z == 72)
      {
        this.DungeonCall = Fix.DUNGEON_SITH_GRAVEYARD;
      }
      else if (tile.transform.position.x == -2 && tile.transform.position.y == 5 && tile.transform.position.z == 70)
      {
        this.DungeonCall = Fix.DUNGEON_GANRO_FORTRESS;
      }
      else if (tile.transform.position.x == 17 && tile.transform.position.y == 0 && tile.transform.position.z == 93)
      {
        this.DungeonCall = Fix.DUNGEON_LOSLON_CAVE;
      }
      else if (tile.transform.position.x == 25 && tile.transform.position.y == 2 && tile.transform.position.z == 33)
      {
        this.DungeonCall = Fix.DUNGEON_ARTHARIUM_FACTORY;
      }
      else if (tile.transform.position.x == 2 && tile.transform.position.y == 30 && tile.transform.position.z == 48)
      {
        this.DungeonCall = Fix.DUNGEON_HEAVENS_GENESIS_GATE;
      }
      else
      {
        // 何も設定しない
        Debug.Log("Not detect tile event(dungeon): " + tile.transform.position.ToString());
      }

      return;
    }
  }

  private bool LocationDetect(TileInformation tile, float x, float y, float z)
  {
    if (tile.transform.position.x == x && tile.transform.position.y == y && tile.transform.position.z == z)
    {
      return true;
    }
    return false;
  }

  private void DetectDamage(TileInformation tile)
  {
    if (tile.field == TileInformation.Field.Artharium_Poison)
    {
      for (int ii = 0; ii < this.PlayerList.Count; ii++)
      {
        PlayerList[ii].CurrentLife -= 10;
      }
      UpdateCharacterStatus();
    }
  }

  private bool JudgePartyDead()
  {
    for (int ii = 0; ii < PlayerList.Count; ii++)
    {
      if (PlayerList[ii].CurrentLife > 0)
      {
        return false;
      }
    }
    return true;
  }

  private void DetectEncount()
  {
    bool encount = false;
    CumulativeBattleCounter++;

    // 最初の歩きはじめはエンカウント対象外
    if (CumulativeBattleCounter <= 4)
    {
      encount = false;
    }
    // エンカウントしない場合は対象外
    else if (this.BattleEncount <= -1)
    {
      encount = false;
    }
    else
    {
      int random = 100 - CumulativeBattleCounter;
      if (random <= 0) { random = 0; }

      if (AP.Math.RandomInteger(random) <= 5)
      {
        encount = true;
      }
    }

    if (encount)
    {
      // ランダムで敵軍隊を生成する。
      One.EnemyList.Clear();
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_BASE_FIELD)
      {
        for (int ii = 0; ii < 4; ii++)
        {
          int rand = AP.Math.RandomInteger(100);
          if (rand > (100 / (ii + 1)))
          {
            break;
          }
          string enemyName = string.Empty;
          switch (AP.Math.RandomInteger(4))
          {
            case 0:
              enemyName = Fix.TINY_MANTIS;
              break;
            case 1:
              enemyName = Fix.GREEN_SLIME;
              break;
            case 2:
              enemyName = Fix.MANDRAGORA;
              break;
            case 3:
              enemyName = Fix.YOUNG_WOLF;
              break;
          }

          GameObject objEC = new GameObject("objEC_" + ii);
          Character character = objEC.AddComponent<Character>();
          character.Construction(enemyName);
          One.EnemyList.Add(character);
        }
      }
      else if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
      {
        string enemyName = string.Empty;

        enemyName = Fix.DEBRIS_SOLDIER;

        GameObject objEC = new GameObject("objEC_1");
        Character character = objEC.AddComponent<Character>();
        character.Construction(enemyName);
        One.EnemyList.Add(character);
      }

      for (int ii = 0; ii < One.EnemyList.Count; ii++)
      {
        UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
      }
      SceneManager.LoadSceneAsync("BattleEnemy");
    }
  }

  /// <summary>
  /// 回復の泉イベント
  /// </summary>
  private void EventFountain()
  {
    for (int ii = 0; ii < PlayerList.Count; ii++)
    {
      PlayerList[ii].MaxGain();
    }
    UpdateCharacterStatus();
  }

  /// <summary>
  /// 移動先が移動可能かどうかをチェックする。
  /// </summary>
  /// <returns>true:移動可能  false:移動不可能</returns>
  private bool BlockCheck(GameObject player, TileInformation tile)
  {
    if (tile == null)
    {
      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      Debug.Log("Tile is null.");
      return false;
    }
    if (tile != null && tile.MoveCost >= 999)
    {
      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      Debug.Log("Tile next field: " + tile.field.ToString());
      return false;
    }
    if (tile.transform.position.y - Player.transform.position.y >= 0.0f)
    {
      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      Debug.Log("Tile next field height is too high: " + (tile.transform.position.y - Player.transform.position.y).ToString());
      return false;
    }
    if (tile.transform.position.y - Player.transform.position.y <= -5.0f)
    {
      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      Debug.Log("Tile next field height is too low: " + (tile.transform.position.y - Player.transform.position.y).ToString());
      return false;
    }
    return true;
  }

  private TileInformation SearchNextTile(Vector3 player, Direction direction)
  {
    TileInformation next = null;
    if (direction == Direction.Right)
    {
      // タイル一つ上から下に向けて順序よく探索する。(3が3つ上、2が2つ上、1が一つ上、0が平行、-1が一つ下）
      // それ以外のケースも考えられるが、基本をまず記述する。
      for (int ii = 3; ii >= -1; ii--)
      {
        next = GetTileInfo(player.x + 1, player.y - 1.0f + ii * 0.5f, player.z);
        if (next != null)
        {
          if (ii == 3 || ii == 2) { return null; } // 上壁がある場合は通過不可能とする。
          else { return next; }
        }
      }
    }
    if (direction == Direction.Left)
    {
      // タイル一つ上から下に向けて順序よく探索する。
      // それ以外のケースも考えられるが、基本をまず記述する。
      for (int ii = 3; ii >= -1; ii--)
      {
        next = GetTileInfo(player.x - 1, player.y - 1.0f + ii * 0.5f, player.z);
        if (next != null)
        {
          if (ii == 3 || ii == 2) { return null; } // 上壁がある場合は通過不可能とする。
          else { return next; }
        }
      }
    }
    if (direction == Direction.Top)
    {
      // タイル一つ上から下に向けて順序よく探索する。(1が一つ上、0が平行、-1が一つ下）
      // それ以外のケースも考えられるが、基本をまず記述する。
      for (int ii = 3; ii >= -1; ii--)
      {
        next = GetTileInfo(player.x, player.y - 1.0f + ii * 0.5f, player.z + 1);
        if (next != null)
        {
          if (ii == 3 || ii == 2) { return null; } // 上壁がある場合は通過不可能とする。
          else { return next; }
        }
      }
    }
    if (direction == Direction.Bottom)
    {
      // タイル一つ上から下に向けて順序よく探索する。(1が一つ上、0が平行、-1が一つ下）
      // それ以外のケースも考えられるが、基本をまず記述する。
      for (int ii = 3; ii >= -1; ii--)
      {
        next = GetTileInfo(player.x, player.y - 1.0f + ii * 0.5f, player.z - 1);
        if (next != null)
        {
          if (ii == 3 || ii == 2) { return null; } // 上壁がある場合は通過不可能とする。
          else { return next; }
        }
      }
    }
    return null;
  }

  /// <summary>
  /// 対象位置のタイル情報を取得する。
  /// </summary>
  private TileInformation GetTileInfo(float x, float y, float z)
  {
    //Debug.Log("GetTileInfo: " + x.ToString() + " " + y.ToString() + " " + z.ToString());
    for (int ii = 0; ii < TileList.Count; ii++)
    {
      if (x == TileList[ii].transform.position.x &&
          y == TileList[ii].transform.position.y &&
          z == TileList[ii].transform.position.z)
      {
        return TileList[ii];
      }
    }

    //Debug.Log("Cannot get tile...then NULL");
    return null;
  }

  /// <summary>
  /// プレイヤーを指定位置へ移動させます。
  /// </summary>
  private void JumpToLocation(Vector3 position)
  {
    Player.transform.position = new Vector3(position.x, position.y, position.z);

    MainCamera.transform.position = new Vector3(Player.transform.position.x - 0.0f,
                                           Player.transform.position.y + 7.0f,
                                           Player.transform.position.z - 5.0f);
    PlayerLight.transform.position = Player.transform.position;

    One.TF.Field_X = this.Player.transform.position.x;
    One.TF.Field_Y = this.Player.transform.position.y;
    One.TF.Field_Z = this.Player.transform.position.z;
  }

  // キャラクターのステータス表示を更新します。
  private void UpdateCharacterStatus()
  {
    for (int ii = 0; ii < PlayerList.Count; ii++)
    {
      if (MiniCharaList[ii] != null)
      {
        MiniCharaList[ii].Refresh(PlayerList[ii]);
      }
      //if (PlayerLifeTextList[ii] != null)
      //{
      //  PlayerLifeTextList[ii].text = PlayerList[ii].CurrentLife.ToString() + " / " + PlayerList[ii].MaxLife.ToString();
      //}
      //float dx = (float)PlayerList[ii].CurrentLife / (float)PlayerList[ii].MaxLife;
      //if (PlayerLifeGaugeList[ii] != null)
      //{
      //  PlayerLifeGaugeList[ii].rectTransform.localScale = new Vector2(dx, 1.0f);
      //}
      //GroupPlayerPanelList[ii].GetComponent<Image>().color = new Color(PlayerList[ii].BattleBackColor.r, PlayerList[ii].BattleBackColor.g, PlayerList[ii].BattleBackColor.b, 0.7f);
    }

    // 登場しないキャラクターは非表示にする。
    //for (int ii = PlayerList.Count; ii < GroupPlayerPanelList.Count; ii++)
    //{
    //  GroupPlayerPanelList[ii].SetActive(false);
    //}
  }

  /// <summary>
  /// タイルを追加します。
  /// </summary>
  private void AddTile(string tile_name, Vector3 position)
  {
    TileInformation current = null;
    if (tile_name == "Plain")
    {
      current = Instantiate(prefab_FieldNormal, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Sea")
    {
      current = Instantiate(prefab_FieldSea, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Bridge1")
    {
      current = Instantiate(prefab_FieldBridge1, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Bridge2")
    {
      current = Instantiate(prefab_FieldBridge2, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Wall_1")
    {
      current = Instantiate(prefab_FieldWall, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Town_1")
    {
      current = Instantiate(prefab_Town1, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Fountain_1")
    {
      current = Instantiate(prefab_Fountain1, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Castle_1")
    {
      current = Instantiate(prefab_Castle1, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Dungeon_1")
    {
      current = Instantiate(prefab_Dungeon1, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Snow")
    {
      current = Instantiate(prefab_Snow, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "SnowWall")
    {
      current = Instantiate(prefab_SnowWall, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Waste")
    {
      current = Instantiate(prefab_Waste, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "WasteWall")
    {
      current = Instantiate(prefab_WasteWall, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Artharium_Normal")
    {
      current = Instantiate(prefab_Artharium_Normal, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Artharium_Debris")
    {
      current = Instantiate(prefab_Artharium_Debris, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Artharium_Wall")
    {
      current = Instantiate(prefab_Artharium_Wall, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Artharium_Poison")
    {
      current = Instantiate(prefab_Artharium_Poison, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Upstair")
    {
      current = Instantiate(prefab_Upstair, position, Quaternion.identity) as TileInformation;
    }

    if (current != null)
    {
      current.transform.SetParent(this.transform);
      //current.gameObject.SetActive(false);
      TileList.Add(current);
    }
  }

  private void AddFieldObj(string obj_name, Vector3 position)
  {
    FieldObject current = null;
    if (obj_name == "Treasure")
    {
      current = Instantiate(prefab_Treasure, position, Quaternion.identity) as FieldObject;
    }
    if (current != null)
    {
      //current.gameObject.SetActive(false);
      FieldObjList.Add(current);
    }
  }


  /// <summary>
  /// タイルマップデータを保存します。
  /// </summary>
  /// <param name="map_data"></param>
  private void SaveTileMapping(string map_data)
  {
    XmlTextWriter xmlWriter = new XmlTextWriter(Application.dataPath + Fix.BaseMapFolder + map_data, Encoding.UTF8);
    try
    {
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteWhitespace("\r\n");

      xmlWriter.WriteStartElement("Body");
      xmlWriter.WriteElementString("DateTime", DateTime.Now.ToString());
      xmlWriter.WriteElementString("Version", "1.0");
      xmlWriter.WriteWhitespace("\r\n");

      xmlWriter.WriteStartElement("TileInformation");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < TileList.Count; ii++)
      {
        xmlWriter.WriteStartElement("Tile_" + ii.ToString());
        xmlWriter.WriteAttributeString("T", TileList[ii].field.ToString());
        xmlWriter.WriteAttributeString("X", TileList[ii].transform.position.x.ToString());
        xmlWriter.WriteAttributeString("Y", TileList[ii].transform.position.y.ToString());
        xmlWriter.WriteAttributeString("Z", TileList[ii].transform.position.z.ToString());
        xmlWriter.WriteEndElement();
      }
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      xmlWriter.WriteStartElement("FieldObject");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < FieldObjList.Count; ii++)
      {
        xmlWriter.WriteStartElement("Field_" + ii.ToString());
        xmlWriter.WriteAttributeString("C", FieldObjList[ii].content.ToString());
        xmlWriter.WriteAttributeString("X", FieldObjList[ii].transform.position.x.ToString());
        xmlWriter.WriteAttributeString("Y", FieldObjList[ii].transform.position.y.ToString());
        xmlWriter.WriteAttributeString("Z", FieldObjList[ii].transform.position.z.ToString());
        xmlWriter.WriteEndElement();
      }
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");
    }
    catch
    {
    }
    finally
    {
      xmlWriter.Close();
    }
  }

  /// <summary>
  /// タイルマップデータを読み込み、画面へ反映します。
  /// </summary>
  private void LoadTileMapping(string map_data)
  {
    Debug.Log("LoadTileMapping-1 " + DateTime.Now.ToString() + " " + map_data);
    XmlDocument xml = new XmlDocument();
    DateTime now = DateTime.Now;
    //xml.Load(map_data);

    XmlReaderSettings settings = new XmlReaderSettings();
    settings.IgnoreWhitespace = true;
    settings.IgnoreComments = true;

    using (XmlReader reader = XmlReader.Create(Application.dataPath + Fix.BaseMapFolder + map_data, settings))
    {
      int counter = 0;
      List<Vector3> list = new List<Vector3>();
      List<string> strList = new List<string>();
      for (; reader.Read();)
      {
        if (reader.Name.Contains("Tile_"))
        {
          string tile = reader.GetAttribute("T");
          float x = Convert.ToSingle(reader.GetAttribute("X"));
          float y = Convert.ToSingle(reader.GetAttribute("Y"));
          float z = Convert.ToSingle(reader.GetAttribute("Z"));
          //Debug.Log(reader.GetAttribute("T") + " " + reader.GetAttribute("X") + " " + reader.GetAttribute("Y") + " " + reader.GetAttribute("Z"));
          list.Add(new Vector3(x, y, z));
          strList.Add(tile);
        }
        counter++;
        //break;
      }
      Debug.Log("counter : " + counter.ToString());

      for (int ii = 0; ii < list.Count; ii++)
      {
        AddTile(strList[ii], list[ii]);
      }
    }


    //for (int ii = 0; ii < 999999; ii++)
    //{
    //    XmlNodeList innerObjectList = xml.GetElementsByTagName("Field_" + ii.ToString());
    //    if (innerObjectList != null)
    //    {
    //        if (innerObjectList.Count > 0)
    //        {
    //            //Debug.Log("Obj_ " + ii.ToString() + " " + innerObjectList[0].InnerText);
    //            XmlElement element = (XmlElement)innerObjectList.Item(0);
    //            float x = Convert.ToSingle(element.GetAttribute("X"));
    //            float y = Convert.ToSingle(element.GetAttribute("Y"));
    //            float z = Convert.ToSingle(element.GetAttribute("Z"));
    //            string content = element.GetAttribute("C");
    //            AddFieldObj(content, new Vector3(x, y, z));
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }
    //    else
    //    {
    //        break;
    //    }
    //}

    //try
    //{
    //}
    //catch (Exception ex)
    //{
    //    Debug.Log(ex.ToString());
    //}
    Debug.Log("LoadTileMapping-2 " + DateTime.Now.ToString());
  }

  private void ClearAllMapTile()
  {
    for (int ii = 0; ii < TileList.Count; ii++)
    {
      if (TileList[ii] != null)
      {
        Destroy(TileList[ii].gameObject);
        TileList[ii] = null;
      }
    }
    TileList.Clear();
  }

  public override void RefreshAllView()
  {
    UpdateCharacterStatus();
  }
  
  private void RefreshQuestList()
  {
    // todo ダンジョンフィールドでもクエスト状況を確認すること。
    foreach (Transform n in contentDungeonPlayer.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    int counter = 0;

    // todo
    if (One.TF.QuestMain_00001) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[0], One.TF.QuestMain_Complete_00001, counter); counter++; }
    if (One.TF.QuestMain_00002) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[1], One.TF.QuestMain_Complete_00002, counter); counter++; }
    if (One.TF.QuestMain_00003) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[2], One.TF.QuestMain_Complete_00003, counter); counter++; }
    if (One.TF.QuestMain_00004) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[3], One.TF.QuestMain_Complete_00004, counter); counter++; }
    if (One.TF.QuestMain_00005) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[4], One.TF.QuestMain_Complete_00005, counter); counter++; }
    if (One.TF.QuestMain_00006) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[5], One.TF.QuestMain_Complete_00006, counter); counter++; }
    if (One.TF.QuestMain_00007) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[6], One.TF.QuestMain_Complete_00007, counter); counter++; }
    if (One.TF.QuestMain_00008) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[7], One.TF.QuestMain_Complete_00008, counter); counter++; }
    if (One.TF.QuestMain_00009) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[8], One.TF.QuestMain_Complete_00009, counter); counter++; }
    if (One.TF.QuestMain_00010) { AddQuestEvent(Fix.QUEST_EVENT_TITLE[9], One.TF.QuestMain_Complete_00010, counter); counter++; }
  }

  private void AddQuestEvent(string quest_name, bool complete, int counter)
  {
    // todo ダンジョンフィールドでもクエスト状況を確認すること。
    NodeButton button = Instantiate(nodeButton) as NodeButton;
    button.gameObject.transform.SetParent(contentDungeonPlayer.transform);
    button.txtName.text = quest_name;
    button.gameObject.SetActive(true);
    if (complete)
    {
      button.imgFilter.gameObject.SetActive(true);
    }
    contentDungeonPlayer.GetComponent<RectTransform>().sizeDelta = new Vector2(contentDungeonPlayer.GetComponent<RectTransform>().sizeDelta.x, contentDungeonPlayer.GetComponent<RectTransform>().sizeDelta.y + 100);

    txtEventTitle.text = quest_name;
    for (int ii = 0; ii < Fix.QUEST_EVENT_TITLE.Count; ii++)
    {
      if (txtEventTitle.text == Fix.QUEST_EVENT_TITLE[ii])
      {
        txtEventDescription.text = Fix.QUEST_EVENT_MESSAGE[ii];
        break;
      }
    }

    RectTransform rect = button.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, -5 - counter * 100, 0);
  }

  public void TapQuestButton(Text txt)
  {
    txtEventTitle.text = txt.text;
    for (int ii = 0; ii < Fix.QUEST_EVENT_TITLE.Count; ii++)
    {
      if (txtEventTitle.text == Fix.QUEST_EVENT_TITLE[ii])
      {
        txtEventDescription.text = Fix.QUEST_EVENT_MESSAGE[ii];
        break;
      }
    }
  }
}
