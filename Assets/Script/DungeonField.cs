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
using TMPro;

public class DungeonField : MotherBase
{
  public enum Direction
  {
    None,
    Top,
    Left,
    Right,
    Bottom,
    Rise,
    Fall,
  }

  // developer-mode
  public Text txtCurrentDevelopView;
  public GameObject GroupDevelop;
  public TileInformation SelectField;
  public Text txtSelectName;
  public Text txtSelectObjectName;
  public Text txtEditMode;
  public Text txtEditArea;
  public Text txtCurrentCursor;
  public Text txtCurrentCursor2;
  public Text txtEditId;
  public GameObject ContentFieldObj;
  public NodeEditFieldObj NodeFieldObjView;
  public Text txtDebugMainMessage;

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
  public TileInformation prefab_Artharium_Gate;
  public TileInformation prefab_Artharium_Hole;
  public TileInformation prefab_Ohran_Normal;
  public TileInformation prefab_Ohran_Wall;
  public TileInformation prefab_Ohran_FloatTile;
  public TileInformation prefab_Ohran_WarpHole;
  public TileInformation prefab_Dhal_Normal;
  public TileInformation prefab_Dhal_Wall;
  public TileInformation prefab_MysticForest_Normal;
  public TileInformation prefab_MysticForest_Wall;
  public TileInformation prefab_Upstair;
  public TileInformation prefab_Downstair;
  public TileInformation prefab_Unknown;
  public TileInformation prefab_Unknown_Goratrum;
  public TileInformation prefab_Unknown_MysticForest;
  public TextMeshPro prefab_AreaText;
  public GameObject prefab_Player;
  public FieldObject prefab_Treasure;
  public FieldObject prefab_TreasureOpen;
  public FieldObject prefab_Rock;
  public FieldObject prefab_Player2;
  public FieldObject prefab_Fountain;
  public FieldObject prefab_MessageBoard;
  public FieldObject prefab_DoorCopper;
  public FieldObject prefab_Crystal;
  public FieldObject prefab_ObsidianStone;
  public FieldObject prefab_FloatingTile;
  public FieldObject prefab_WarpHole;
  public FieldObject prefab_DhalGate;
  public FieldObject prefab_LeverLeft;
  public FieldObject prefab_LevelRight;
  public FieldObject prefab_DhalGateTile;
  public FieldObject prefab_DhalGateWall;
  public FieldObject prefab_DhalGateDoor;
  public FieldObject prefab_DhalGateDoorOpen;
  public FieldObject prefab_Brushwood;

  // BackpackView
  public NodeBackpackView ParentBackpackView;

  // Decision
  public GameObject GroupDecision;
  public Text txtDecisionTitle;
  public Text txtDecisionMessage;
  public Text txtDecisionA;
  public Text txtDecisionB;
  public Text txtDecisionC;

  // MapSelect
  public GameObject GroupMapSelect;
  public List<Text> txtMapSelect;
  public GameObject background3;
  public GameObject LayoutBottom;

  // Tactics
  public List<Button> StayList;
  public List<Text> StayListName;
  public List<Text> StayListLife;
  public List<Image> StayListLifeGauge;
  public List<Text> StayListSP;
  public List<Image> StayListSPGauge;
  public List<GameObject> StayListCheckMark;
  public GameObject objCancelActionCommand;
  public Text txtCurrentName;
  public List<GameObject> objActionCommand;
  public Text txtBattleSettingCharacterName;

  // Group
  public GameObject GroupPartyMenu;
  public GroupCharacterStatus groupPartyStatus;
  public GameObject groupPartyCommand;
  public GameObject groupPartyItem;
  public GameObject groupPartyBattleSetting;
  public GameObject FilterForAll;
  public GameObject FilterForActionCommand;
  public GameObject FilterForAvailableList;
  public NodeActionCommand ActionCommandMain;
  public List<NodeActionCommand> ListActionCommandSet;
  public List<NodeActionCommand> ListAvailableCommand;
  public List<Text> ListAvailableCommandText;
  public GameObject groupCommandCategory;
  public Button btnCommandCategoryAction;
  public Button btnCommandCetegoryItem;
  public Button btnCommandCetegoryArchetype;

  public NodeActionCommand CurrentSelectCommand;

  // public GameObject groupPartyExit;
  public GroupCharacterStatus groupCharacterStatus;
  public SaveLoad groupSaveLoad;

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

  // Blackout
  public GameObject BlackoutPanel;

  // Gold
  public Text txtGold;

  // Inner Value
  private GameObject Player;
  private List<TileInformation> TileList = new List<TileInformation>();
  private List<TextMeshPro> TileAreaList = new List<TextMeshPro>();
  private List<FieldObject> FieldObjList = new List<FieldObject>();
  private List<TileInformation> UnknownTileList = new List<TileInformation>();
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
  private bool EditAreaMode = false;
  private bool IgnoreObjMode = false;

  List<string> PrefabList = new List<string>();
  List<string> ObjectList = new List<string>();

  private int BattleEncount = 10;
  private int CumulativeBattleCounter = 0;

  private string CurrentMapSelectName = String.Empty;
  private bool ReloadMap = false;

  private bool GameOver = false;

  private bool NextTapOk = false; // 画面再描画が必要案ものについて、一旦メソッドを抜け次のフレーム更新(Update)で即時TapOKを自動処理する。
  private float NextTapOkSleep = 0.0f;
  private float NextTapOkCounter = 0.0f;
  private FieldObject CurrentEventObject = null;

  private string currentDecision = String.Empty;

  private float FieldDamage = 1.0f;

  private Character CurrentPlayer = null;

  private bool FirstAction = false;
  private bool AlreadyDetectEncount = false;
  private bool AlreadyDetectEncounted = false;
  private int MarginTimeForCallBattle = 30;
  bool ignoreCreateShadow = false;

  private bool arrowDown = false; // add unity
  private bool arrowUp = false; // add unity
  private bool arrowLeft = false; // add unity
  private bool arrowRight = false; // add unity
  private bool keyDown = false;
  private bool keyUp = false;
  private bool keyLeft = false;
  private bool keyRight = false;
  private int MOVE_INTERVAL = 50;
  private int interval = 0;
  private bool detectKeyUp = false; // ２階、技の部屋Ｃでキーを離した事を示すフラグ
  private int MovementInterval = 0; // ダンジョンマップ全体を見ている時のインターバル

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

    One.TF.Event_Message100001 = true;

    if (Application.platform == RuntimePlatform.Android ||
    Application.platform == RuntimePlatform.IPhonePlayer)
    {
      MOVE_INTERVAL = 10;
      //this.groupArrow.SetActive(true);
    }
    else
    {
      MOVE_INTERVAL = 20;
      //this.groupArrow.SetActive(true);
    }
    this.interval = MOVE_INTERVAL;
    this.MovementInterval = MOVE_INTERVAL;


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
    PrefabList.Add("Artharium_Gate");
    PrefabList.Add("Artharium_Hole");
    PrefabList.Add("Ohran_Normal");
    PrefabList.Add("Ohran_Wall");
    PrefabList.Add("Ohran_FloatTile");
    PrefabList.Add("Ohran_WarpHole");
    PrefabList.Add("Dhal_Normal");
    PrefabList.Add("Dhal_Wall");
    PrefabList.Add("MysticForest_Normal");
    PrefabList.Add("MysticForest_Wall");
    PrefabList.Add("Upstair");
    PrefabList.Add("Downstair");

    // オブジェクトリストの設定
    ObjectList.Add("Treasure");
    ObjectList.Add("Rock");
    ObjectList.Add("Fountain");
    ObjectList.Add("MessageBoard");
    ObjectList.Add("Door_Copper");
    ObjectList.Add("Crystal");
    ObjectList.Add("ObsidianStone");
    ObjectList.Add("FloatingTile");
    ObjectList.Add("WarpHole");
    ObjectList.Add("DhalGate_Tile");
    ObjectList.Add("DhalGate_Wall");
    ObjectList.Add("DhalGate_Door");
    ObjectList.Add("DhalGate_Door_Open");
    ObjectList.Add("Brushwood");

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

    // プレイヤーを設置
    this.Player = Instantiate(prefab_Player, new Vector3(0, 0, 0), Quaternion.identity) as GameObject; // インスタント生成で位置情報は無意味とする。

    // プレイヤー位置を設定
    JumpToLocation(new Vector3(One.TF.Field_X, One.TF.Field_Y, One.TF.Field_Z));

    // バックパック情報を画面へ反映
    ParentBackpackView.ConstructBackpackView();

    // タイルおよびフィールドオブジェクトの設置
    LoadTileMapping(One.TF.CurrentDungeonField);

    // Unknownタイルの設置
    SetupUnknownTile(One.TF.CurrentDungeonField);

    // イベント進行に応じたオブジェクトの設置
    LoadObjectFromEvent();

    // debug
    NodeEditFieldObj objView = Instantiate(NodeFieldObjView) as NodeEditFieldObj;
    objView.transform.SetParent(ContentFieldObj.transform);
    objView.txtType.text = "Player";
    objView.txtLocation.text = this.Player.transform.position.ToString();
    objView.txtObjectId.text = "";
    objView.x = this.Player.transform.position.x;
    objView.y = this.Player.transform.position.y;
    objView.z = this.Player.transform.position.z;
    objView.gameObject.SetActive(true);
    RectTransform rect = objView.GetComponent<RectTransform>();
    int NODE_HEIGHT = 90;
    rect.anchoredPosition = new Vector2(0, 0);
    //rect.sizeDelta = new Vector2(0, 0);
    Debug.Log("debug this.FieldObjList.Count: " + this.FieldObjList.Count.ToString());
    rect.localPosition = new Vector3(0, -5 - this.FieldObjList.Count * NODE_HEIGHT, 0);
    const int HEIGHT = 110;
    ContentFieldObj.GetComponent<RectTransform>().sizeDelta = new Vector2(ContentFieldObj.GetComponent<RectTransform>().sizeDelta.x, ContentFieldObj.GetComponent<RectTransform>().sizeDelta.y + HEIGHT);
    // debug

    RefreshAllView();

    if (One.BattleEnd == Fix.GameEndType.Retry)
    {
      One.BattleEnd = Fix.GameEndType.None;
      One.CopyShadowToMain();
      this.ignoreCreateShadow = true;
      PrepareCallTruthBattleEnemy();
      //this.nowEncountEnemy = true;
    }
    else
    {
      this.ignoreCreateShadow = false;
      One.BattleEnemyList.Clear();

      for (int ii = 0; ii < One.ShadowPlayerList.Count; ii++)
      {
        if (One.ShadowPlayerList[ii] == null)
        {
          Debug.Log("ShadPlayerList " + ii.ToString() + " is null...");
        }
        else
        {
          Destroy(One.ShadowPlayerList[ii].gameObject);
        }
      }
      One.ShadowPlayerList.Clear();

      Destroy(One.ShadowTF);
      One.ShadowTF = null;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (this.FirstAction == false)
    {
      this.FirstAction = true;

      // 画面表示時のイベント進行
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
      {
        if (One.TF.Event_Message000010 == false)
        {
          One.TF.Event_Message000010 = true;
          MessagePack.Message000010(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }

      }

      if (One.GoratrumHoleFalling)
      {
        One.GoratrumHoleFalling = false;
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
        {
          if (One.TF.Event_Message600050)
          {
            MessagePack.Message600060(ref QuestMessageList, ref QuestEventList); TapOK();
            return;
          }
        }
      }
      if (One.GoratrumHoleFalling2)
      {
        One.GoratrumHoleFalling2 = false;
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
        {
          if (One.TF.Event_Message600130)
          {
            MessagePack.Message600240(ref QuestMessageList, ref QuestEventList); TapOK();
            return;
          }
        }
      }
      if (One.GoratrumHoleFalling3)
      {
        One.GoratrumHoleFalling3 = false;
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
        {
          if (One.TF.Event_Message600160)
          {
            MessagePack.Message600290(ref QuestMessageList, ref QuestEventList); TapOK();
            return;
          }
        }
      }

      if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
      {
        if (One.TF.DefeatHellKerberos && One.TF.QuestMain_Complete_00007 == false)
        {
          MessagePack.Message300123(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }

        if (One.TF.DefeatGalvadazer && One.TF.QuestMain_Complete_00009 == false)
        {
          MessagePack.Message300200(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }

        if (One.TF.DefeatYodirian && One.TF.QuestMain_Complete_00020 == false)
        {
          MessagePack.Message800110(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
      }

      if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
      {
        if (One.TF.Event_EntryMysticForest == false)
        {
          One.TF.Event_EntryMysticForest = true;
          return;
        }
      }

      if (One.TF.CurrentDungeonField == Fix.MAPFILE_SARITAN)
      {
        if (One.TF.Event_Message1200010 == false)
        {
          MessagePack.Message1200010(ref QuestMessageList, ref QuestEventList); TapOK();
        }
      }

      return;
    }

    if (this.AlreadyDetectEncount)
    {
      MarginTimeForCallBattle--;
      if (MarginTimeForCallBattle <= 0)
      {
        if (AlreadyDetectEncounted == false)
        {
          AlreadyDetectEncounted = true;
          SceneDimension.CallBattleEnemy();
        }
      }
      return;
    }

    // Editモード（開発者専用）
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Debug.Log("Input getkeydown is escape");
      txtCurrentDevelopView.text = "Develop Enable";
      GroupDevelop.SetActive(true);
    }

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

        // タイル配置モード
        if (this.EditAreaMode == false)
        {
          if (objTile != null)
          {
            TileList.Remove(objTile);
            //Debug.Log("objTile Remove");
            Destroy(objTile.gameObject);
            return;
          }

          Debug.Log("time-4: " + DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString());
          // todo 第三引数のIDをどう入力させるか。
          AddTile(txtSelectName.text, SelectField.transform.position, String.Empty, "None");
          Debug.Log("time-5: " + DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString());
          return;
        }
        // タイルエリア設定モード
        else
        {
          if (objTile != null)
          {
            for (int ii = 0; ii < TileList.Count; ii++)
            {
              if (TileList[ii].Equals(objTile))
              {
                TileList[ii].AreaInfo = (TileInformation.Area)Enum.Parse(typeof(TileInformation.Area), txtEditArea.text);
                TileAreaList[ii].text = ((int)(TileList[ii].AreaInfo)).ToString();
                break;
              }
            }
            return;
          }
          return;
        }
      }

      if (Input.GetMouseButtonDown(1))
      {
        Debug.Log("GetMouseButton 1");
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        List<RaycastResult> raycast = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycast);

        for (int ii = 0; ii < raycast.Count; ii++)
        {
          // ボタン押下時はヒット判定対象外とする。
          if (raycast[ii].ToString().Contains("btn")) { return; }
        }

        FieldObject currentObj = GetObjectInfo(SelectField.transform.position.x,
                                             SelectField.transform.position.y,
                                             SelectField.transform.position.z);
        if (currentObj != null)
        {
          FieldObjList.Remove(currentObj);
          Destroy(currentObj.gameObject);
          return;
        }

        int counter = 0;
        for (int ii = 0; ii < FieldObjList.Count; ii++)
        {
          Debug.Log("FieldObjList ID: " + FieldObjList[ii].ObjectId);
          FieldObject.Content currentContent = (FieldObject.Content)(Enum.Parse(typeof(FieldObject.Content), txtSelectObjectName.text));
          if (FieldObjList[ii].content == currentContent)
          {
            counter++;
          }
        }
        counter++; // 追加するのでもう１カウント
        String objectId = counter.ToString();
        AddFieldObj(txtSelectObjectName.text, SelectField.transform.position, objectId, new Quaternion(0, 0, 0, 0));
        return;
      }

      if (Input.GetMouseButtonDown(2))
      {
        Debug.Log("GetMouseButtonDown(2)");
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        List<RaycastResult> raycast = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycast);
        for (int ii = 0; ii < raycast.Count; ii++)
        {
          // ボタン押下時はヒット判定対象外とする。
          if (raycast[ii].ToString().Contains("btn")) { return; }
        }

        FieldObject currentObj = GetObjectInfo(SelectField.transform.position.x,
                                           SelectField.transform.position.y,
                                           SelectField.transform.position.z);
        if (currentObj != null)
        {
          Debug.Log("currentObj is hit");
          txtEditId.text = currentObj.ObjectId;
          Quaternion q = Quaternion.Euler(0, 90.0f, 0);
          currentObj.transform.rotation = q * currentObj.transform.rotation;
          return;
        }
        else
        {
          Debug.Log("currentObj is null...");
        }
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

    // 次のTapOKを即時反映する。
    if (this.NextTapOk)
    {
      this.NextTapOkCounter += Time.deltaTime;

      if (this.NextTapOkCounter > this.NextTapOkSleep)
      {
        this.NextTapOkSleep = 0.0f;
        this.NextTapOkCounter = 0.0f;
        this.NextTapOk = false;
        TapOK();
      }
      return;
    }
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
      One.TF.BeforeAreaName = One.TF.CurrentAreaName;
      One.TF.CurrentAreaName = this.HomeTownCall;
      SceneDimension.JumpToHomeTown();
      return;
    }
    if (this.DungeonCall != string.Empty && this.DungeonMap != string.Empty && this.DungeonCallComplete == false)
    {
      this.DungeonCallComplete = true;
      // todo
      Debug.Log("DungeonCallComplete: " + this.DungeonCall + " " + this.DungeonMap);
      // One.TF.BeforeAreaName = One.TF.CurrentAreaName; // 更新しない
      SceneDimension.JumpToDungeonField(this.DungeonMap);
      return;
    }

    bool detectKey = false;
    TileInformation tile = null;
    Direction direction = Direction.None;
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      direction = Direction.Right;
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      direction = Direction.Left;
    }
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      direction = Direction.Top;
    }
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      direction = Direction.Bottom;
    }
    
    if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.UpArrow) || this.arrowUp)
    {
      this.keyUp = true;
      this.keyDown = false;
      movementTimer_Tick();
    }
    else if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.DownArrow) || this.arrowDown)
    {
      this.keyDown = true;
      this.keyUp = false;
      movementTimer_Tick();
    }
    if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.LeftArrow) || this.arrowLeft)
    {
      this.keyLeft = true;
      this.keyRight = false;
      movementTimer_Tick();
    }
    if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.RightArrow) || this.arrowRight)
    {
      this.keyRight = true;
      this.keyLeft = false;
      movementTimer_Tick();
    }
    if (Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.UpArrow) ||
        Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.DownArrow) ||
        Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.LeftArrow) ||
        Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp(KeyCode.RightArrow))
    {
      detectKeyUp = true;
      CancelKeyDownMovement();
    }


    #region "移動直前、ブロックチェック前にオーランの塔で出現する空中板のの検出および対応。"
    Vector3 nextLocation = new Vector3(-99999, -99999, -99999); // 初期(0,0,0)はあり得るので、あり得ない位置をまず設定
    if (direction == Direction.Right)
    {
      nextLocation = new Vector3(this.Player.transform.position.x + 1.0f, this.Player.transform.position.y - 1.0f, this.Player.transform.position.z);
      Debug.Log("nextLocation: " + nextLocation.ToString());
    }
    if (direction == Direction.Left)
    {
      nextLocation = new Vector3(this.Player.transform.position.x - 1.0f, this.Player.transform.position.y - 1.0f, this.Player.transform.position.z);
      Debug.Log("nextLocation: " + nextLocation.ToString());
    }
    if (direction == Direction.Top)
    {
      nextLocation = new Vector3(this.Player.transform.position.x, this.Player.transform.position.y - 1.0f, this.Player.transform.position.z + 1.0f);
      Debug.Log("nextLocation: " + nextLocation.ToString());
    }
    if (direction == Direction.Bottom)
    {
      nextLocation = new Vector3(this.Player.transform.position.x, this.Player.transform.position.y - 1.0f, this.Player.transform.position.z - 1.0f);
      Debug.Log("nextLocation: " + nextLocation.ToString());
    }

    FieldObject beforeFloatingTile = SearchObject(nextLocation);
    if (beforeFloatingTile != null && beforeFloatingTile.content == FieldObject.Content.FloatingTile ||
        beforeFloatingTile != null && beforeFloatingTile.content == FieldObject.Content.WarpHole)
    {
      CurrentEventObject = beforeFloatingTile;
      int num = 1;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_1_X, Fix.OHRANTOWER_FloatingTile_1_Y, Fix.OHRANTOWER_FloatingTile_1_Z))
      {
        One.TF.FieldObject_OhranTower_00001 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_1_X, Fix.OHRANTOWER_FloatingTile_1_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_1_Z))
      {
        One.TF.FieldObject_OhranTower_00001 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_2_X, Fix.OHRANTOWER_FloatingTile_2_Y, Fix.OHRANTOWER_FloatingTile_2_Z))
      {
        One.TF.FieldObject_OhranTower_00002 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_2_X, Fix.OHRANTOWER_FloatingTile_2_Y + 12.0f, Fix.OHRANTOWER_FloatingTile_2_Z))
      {
        One.TF.FieldObject_OhranTower_00002 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_5_X, Fix.OHRANTOWER_FloatingTile_5_Y, Fix.OHRANTOWER_FloatingTile_5_Z))
      {
        One.TF.FieldObject_OhranTower_00003 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_5_X, Fix.OHRANTOWER_FloatingTile_5_Y, Fix.OHRANTOWER_FloatingTile_5_Z + 10.0f))
      {
        One.TF.FieldObject_OhranTower_00003 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_8_X, Fix.OHRANTOWER_FloatingTile_8_Y, Fix.OHRANTOWER_FloatingTile_8_Z))
      {
        One.TF.FieldObject_OhranTower_00004 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_8_X - 11.0f, Fix.OHRANTOWER_FloatingTile_8_Y, Fix.OHRANTOWER_FloatingTile_8_Z))
      {
        One.TF.FieldObject_OhranTower_00004 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_9_X, Fix.OHRANTOWER_FloatingTile_9_Y, Fix.OHRANTOWER_FloatingTile_9_Z))
      {
        One.TF.FieldObject_OhranTower_00005 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_9_X, Fix.OHRANTOWER_FloatingTile_9_Y, Fix.OHRANTOWER_FloatingTile_9_Z - 11.0f))
      {
        One.TF.FieldObject_OhranTower_00005 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_4_X, Fix.OHRANTOWER_FloatingTile_4_Y, Fix.OHRANTOWER_FloatingTile_4_Z))
      {
        One.TF.FieldObject_OhranTower_00006 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_4_X, Fix.OHRANTOWER_FloatingTile_4_Y, Fix.OHRANTOWER_FloatingTile_4_Z + 13.0f))
      {
        One.TF.FieldObject_OhranTower_00006 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_6_X, Fix.OHRANTOWER_FloatingTile_6_Y, Fix.OHRANTOWER_FloatingTile_6_Z))
      {
        One.TF.FieldObject_OhranTower_00007 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_6_X + 7.0f, Fix.OHRANTOWER_FloatingTile_6_Y, Fix.OHRANTOWER_FloatingTile_6_Z))
      {
        One.TF.FieldObject_OhranTower_00007 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;


      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_7_X, Fix.OHRANTOWER_FloatingTile_7_Y, Fix.OHRANTOWER_FloatingTile_7_Z))
      {
        One.TF.FieldObject_OhranTower_00008 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_7_X, Fix.OHRANTOWER_FloatingTile_7_Y, Fix.OHRANTOWER_FloatingTile_7_Z - 11.0f))
      {
        One.TF.FieldObject_OhranTower_00008 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_10_X, Fix.OHRANTOWER_FloatingTile_10_Y, Fix.OHRANTOWER_FloatingTile_10_Z))
      {
        One.TF.FieldObject_OhranTower_00009 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_10_X - 3.0f, Fix.OHRANTOWER_FloatingTile_10_Y, Fix.OHRANTOWER_FloatingTile_10_Z))
      {
        One.TF.FieldObject_OhranTower_00009 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_11_X, Fix.OHRANTOWER_FloatingTile_11_Y, Fix.OHRANTOWER_FloatingTile_11_Z))
      {
        One.TF.FieldObject_OhranTower_00010 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_11_X - 45.0f, Fix.OHRANTOWER_FloatingTile_11_Y, Fix.OHRANTOWER_FloatingTile_11_Z))
      {
        One.TF.FieldObject_OhranTower_00010 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_3_X, Fix.OHRANTOWER_FloatingTile_3_Y, Fix.OHRANTOWER_FloatingTile_3_Z))
      {
        One.TF.FieldObject_OhranTower_00011 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_3_X, Fix.OHRANTOWER_FloatingTile_3_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_3_Z))
      {
        One.TF.FieldObject_OhranTower_00011 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_12_X, Fix.OHRANTOWER_FloatingTile_12_Y, Fix.OHRANTOWER_FloatingTile_12_Z))
      {
        One.TF.FieldObject_OhranTower_00012 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_12_X, Fix.OHRANTOWER_FloatingTile_12_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_12_Z))
      {
        One.TF.FieldObject_OhranTower_00012 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_13_X, Fix.OHRANTOWER_FloatingTile_13_Y, Fix.OHRANTOWER_FloatingTile_13_Z))
      {
        One.TF.FieldObject_OhranTower_00013 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_13_X, Fix.OHRANTOWER_FloatingTile_13_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_13_Z))
      {
        One.TF.FieldObject_OhranTower_00013 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_14_X, Fix.OHRANTOWER_FloatingTile_14_Y, Fix.OHRANTOWER_FloatingTile_14_Z))
      {
        One.TF.FieldObject_OhranTower_00014 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_14_X + 7.0f, Fix.OHRANTOWER_FloatingTile_14_Y, Fix.OHRANTOWER_FloatingTile_14_Z))
      {
        One.TF.FieldObject_OhranTower_00014 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_15_X, Fix.OHRANTOWER_FloatingTile_15_Y, Fix.OHRANTOWER_FloatingTile_15_Z))
      {
        One.TF.FieldObject_OhranTower_00015 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_15_X, Fix.OHRANTOWER_FloatingTile_15_Y, Fix.OHRANTOWER_FloatingTile_15_Z - 7.0f))
      {
        One.TF.FieldObject_OhranTower_00015 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_16_X, Fix.OHRANTOWER_FloatingTile_16_Y, Fix.OHRANTOWER_FloatingTile_16_Z))
      {
        One.TF.FieldObject_OhranTower_00016 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_16_X, Fix.OHRANTOWER_FloatingTile_16_Y, Fix.OHRANTOWER_FloatingTile_16_Z - 7.0f))
      {
        One.TF.FieldObject_OhranTower_00016 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_17_X, Fix.OHRANTOWER_FloatingTile_17_Y, Fix.OHRANTOWER_FloatingTile_17_Z))
      {
        One.TF.FieldObject_OhranTower_00017 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_17_X - 7.0f, Fix.OHRANTOWER_FloatingTile_17_Y, Fix.OHRANTOWER_FloatingTile_17_Z))
      {
        One.TF.FieldObject_OhranTower_00017 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_18_X, Fix.OHRANTOWER_FloatingTile_18_Y, Fix.OHRANTOWER_FloatingTile_18_Z))
      {
        One.TF.FieldObject_OhranTower_00018 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_18_X - 7.0f, Fix.OHRANTOWER_FloatingTile_18_Y, Fix.OHRANTOWER_FloatingTile_18_Z))
      {
        One.TF.FieldObject_OhranTower_00018 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_19_X, Fix.OHRANTOWER_FloatingTile_19_Y, Fix.OHRANTOWER_FloatingTile_19_Z))
      {
        One.TF.FieldObject_OhranTower_00019 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_19_X, Fix.OHRANTOWER_FloatingTile_19_Y, Fix.OHRANTOWER_FloatingTile_19_Z + 5.0f))
      {
        One.TF.FieldObject_OhranTower_00019 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_20_X, Fix.OHRANTOWER_FloatingTile_20_Y, Fix.OHRANTOWER_FloatingTile_20_Z))
      {
        One.TF.FieldObject_OhranTower_00020 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_20_X + 2.0f, Fix.OHRANTOWER_FloatingTile_20_Y, Fix.OHRANTOWER_FloatingTile_20_Z))
      {
        One.TF.FieldObject_OhranTower_00020 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_21_X, Fix.OHRANTOWER_FloatingTile_21_Y, Fix.OHRANTOWER_FloatingTile_21_Z))
      {
        One.TF.FieldObject_OhranTower_00021 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_21_X + 5.0f, Fix.OHRANTOWER_FloatingTile_21_Y, Fix.OHRANTOWER_FloatingTile_21_Z))
      {
        One.TF.FieldObject_OhranTower_00021 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_22_X, Fix.OHRANTOWER_FloatingTile_22_Y, Fix.OHRANTOWER_FloatingTile_22_Z))
      {
        One.TF.FieldObject_OhranTower_00022 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_22_X, Fix.OHRANTOWER_FloatingTile_22_Y, Fix.OHRANTOWER_FloatingTile_22_Z + 16.0f))
      {
        One.TF.FieldObject_OhranTower_00022 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_23_X, Fix.OHRANTOWER_FloatingTile_23_Y, Fix.OHRANTOWER_FloatingTile_23_Z))
      {
        One.TF.FieldObject_OhranTower_00023 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_23_X - 6.0f, Fix.OHRANTOWER_FloatingTile_23_Y, Fix.OHRANTOWER_FloatingTile_23_Z))
      {
        One.TF.FieldObject_OhranTower_00023 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_24_X, Fix.OHRANTOWER_FloatingTile_24_Y, Fix.OHRANTOWER_FloatingTile_24_Z))
      {
        One.TF.FieldObject_OhranTower_00024 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_24_X, Fix.OHRANTOWER_FloatingTile_24_Y, Fix.OHRANTOWER_FloatingTile_24_Z - 2.0f))
      {
        One.TF.FieldObject_OhranTower_00024 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_25_X, Fix.OHRANTOWER_FloatingTile_25_Y, Fix.OHRANTOWER_FloatingTile_25_Z))
      {
        One.TF.FieldObject_OhranTower_00025 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_25_X - 4.0f, Fix.OHRANTOWER_FloatingTile_25_Y, Fix.OHRANTOWER_FloatingTile_25_Z))
      {
        One.TF.FieldObject_OhranTower_00025 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_26_X, Fix.OHRANTOWER_FloatingTile_26_Y, Fix.OHRANTOWER_FloatingTile_26_Z))
      {
        One.TF.FieldObject_OhranTower_00026 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_26_X, Fix.OHRANTOWER_FloatingTile_26_Y, Fix.OHRANTOWER_FloatingTile_26_Z - 4.0f))
      {
        One.TF.FieldObject_OhranTower_00026 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_27_X, Fix.OHRANTOWER_FloatingTile_27_Y, Fix.OHRANTOWER_FloatingTile_27_Z))
      {
        One.TF.FieldObject_OhranTower_00027 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_27_X + 4.0f, Fix.OHRANTOWER_FloatingTile_27_Y, Fix.OHRANTOWER_FloatingTile_27_Z))
      {
        One.TF.FieldObject_OhranTower_00027 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_28_X, Fix.OHRANTOWER_FloatingTile_28_Y, Fix.OHRANTOWER_FloatingTile_28_Z))
      {
        One.TF.FieldObject_OhranTower_00028 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_28_X + 2.0f, Fix.OHRANTOWER_FloatingTile_28_Y, Fix.OHRANTOWER_FloatingTile_28_Z))
      {
        One.TF.FieldObject_OhranTower_00028 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_29_X, Fix.OHRANTOWER_FloatingTile_29_Y, Fix.OHRANTOWER_FloatingTile_29_Z))
      {
        One.TF.FieldObject_OhranTower_00029 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_29_X, Fix.OHRANTOWER_FloatingTile_29_Y - 8.0f, Fix.OHRANTOWER_FloatingTile_29_Z))
      {
        One.TF.FieldObject_OhranTower_00029 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_30_X, Fix.OHRANTOWER_FloatingTile_30_Y, Fix.OHRANTOWER_FloatingTile_30_Z))
      {
        One.TF.FieldObject_OhranTower_00030 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_30_X, Fix.OHRANTOWER_FloatingTile_30_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_30_Z))
      {
        One.TF.FieldObject_OhranTower_00030 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_31_X, Fix.OHRANTOWER_FloatingTile_31_Y, Fix.OHRANTOWER_FloatingTile_31_Z))
      {
        One.TF.FieldObject_OhranTower_00031 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_31_X, Fix.OHRANTOWER_FloatingTile_31_Y - 63.0f, Fix.OHRANTOWER_FloatingTile_31_Z))
      {
        One.TF.FieldObject_OhranTower_00031 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_32_X, Fix.OHRANTOWER_FloatingTile_32_Y, Fix.OHRANTOWER_FloatingTile_32_Z))
      {
        One.TF.FieldObject_OhranTower_00032 = true;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_FloatingTile_32_X, Fix.OHRANTOWER_FloatingTile_32_Y, Fix.OHRANTOWER_FloatingTile_32_Z - 18.0f))
      {
        One.TF.FieldObject_OhranTower_00032 = false;
        MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num); TapOK();
        return;
      }
      num++;

      int num2 = 1;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_1_X, Fix.OHRANTOWER_WarpHole_1_Y, Fix.OHRANTOWER_WarpHole_1_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_2_X, Fix.OHRANTOWER_WarpHole_2_Y, Fix.OHRANTOWER_WarpHole_2_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_3_X, Fix.OHRANTOWER_WarpHole_3_Y, Fix.OHRANTOWER_WarpHole_3_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_4_X, Fix.OHRANTOWER_WarpHole_4_Y, Fix.OHRANTOWER_WarpHole_4_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_5_X, Fix.OHRANTOWER_WarpHole_5_Y, Fix.OHRANTOWER_WarpHole_5_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_6_X, Fix.OHRANTOWER_WarpHole_6_Y, Fix.OHRANTOWER_WarpHole_6_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_7_X, Fix.OHRANTOWER_WarpHole_7_Y, Fix.OHRANTOWER_WarpHole_7_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_8_X, Fix.OHRANTOWER_WarpHole_8_Y, Fix.OHRANTOWER_WarpHole_8_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      // 1
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_9_X, Fix.OHRANTOWER_WarpHole_9_Y, Fix.OHRANTOWER_WarpHole_9_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_10_X, Fix.OHRANTOWER_WarpHole_10_Y, Fix.OHRANTOWER_WarpHole_10_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_11_X, Fix.OHRANTOWER_WarpHole_11_Y, Fix.OHRANTOWER_WarpHole_11_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_12_X, Fix.OHRANTOWER_WarpHole_12_Y, Fix.OHRANTOWER_WarpHole_12_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_13_X, Fix.OHRANTOWER_WarpHole_13_Y, Fix.OHRANTOWER_WarpHole_13_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_14_X, Fix.OHRANTOWER_WarpHole_14_Y, Fix.OHRANTOWER_WarpHole_14_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_15_X, Fix.OHRANTOWER_WarpHole_15_Y, Fix.OHRANTOWER_WarpHole_15_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_16_X, Fix.OHRANTOWER_WarpHole_16_Y, Fix.OHRANTOWER_WarpHole_16_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_17_X, Fix.OHRANTOWER_WarpHole_17_Y, Fix.OHRANTOWER_WarpHole_17_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_18_X, Fix.OHRANTOWER_WarpHole_18_Y, Fix.OHRANTOWER_WarpHole_18_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_19_X, Fix.OHRANTOWER_WarpHole_19_Y, Fix.OHRANTOWER_WarpHole_19_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_20_X, Fix.OHRANTOWER_WarpHole_20_Y, Fix.OHRANTOWER_WarpHole_20_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_21_X, Fix.OHRANTOWER_WarpHole_21_Y, Fix.OHRANTOWER_WarpHole_21_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_22_X, Fix.OHRANTOWER_WarpHole_22_Y, Fix.OHRANTOWER_WarpHole_22_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_23_X, Fix.OHRANTOWER_WarpHole_23_Y, Fix.OHRANTOWER_WarpHole_23_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_24_X, Fix.OHRANTOWER_WarpHole_24_Y, Fix.OHRANTOWER_WarpHole_24_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_25_X, Fix.OHRANTOWER_WarpHole_25_Y, Fix.OHRANTOWER_WarpHole_25_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
      if (LocationFieldDetect(beforeFloatingTile, Fix.OHRANTOWER_WarpHole_26_X, Fix.OHRANTOWER_WarpHole_26_Y, Fix.OHRANTOWER_WarpHole_26_Z))
      {
        MessagePack.MoveWarpHoleTile(ref QuestMessageList, ref QuestEventList, direction, num2); TapOK();
        return;
      }
      num2++;
    }
    #endregion

    // [comment] イベント実行はUpdatePlayersKeyEventsで実施する。

    //#region "ブロックチェック"
    //if (Input.GetKeyDown(KeyCode.RightArrow))
    //{
    //  tile = SearchNextTile(this.Player.transform.position, Direction.Right);
    //  if (BlockCheck(Player, tile) == false)
    //  {
    //    One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
    //    return;
    //  }

    //  detectKey = true;
    //}
    //if (Input.GetKeyDown(KeyCode.LeftArrow))
    //{
    //  tile = SearchNextTile(this.Player.transform.position, Direction.Left);
    //  if (BlockCheck(Player, tile) == false)
    //  {
    //    One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
    //    return;
    //  }

    //  detectKey = true;
    //}
    //if (Input.GetKeyDown(KeyCode.UpArrow))
    //{
    //  tile = SearchNextTile(this.Player.transform.position, Direction.Top);
    //  if (BlockCheck(Player, tile) == false)
    //  {
    //    One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
    //    return;
    //  }

    //  detectKey = true;
    //}
    //if (Input.GetKeyDown(KeyCode.DownArrow))
    //{
    //  tile = SearchNextTile(this.Player.transform.position, Direction.Bottom);
    //  if (BlockCheck(Player, tile) == false)
    //  {
    //    One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
    //    return;
    //  }

    //  detectKey = true;
    //}
    //#endregion

    #region "カメラ移動"
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
    #endregion
  }

  public void TapQuestButton(Text txt)
  {
    // same DungeonField, HomeTown
    if (txt == null) { Debug.Log("TapQuestButton txt is null..."); return; }

    ViewQuestEvent(txt.text);
  }

  public void TapMapReload(Text txtMap)
  {
    ClearAllMapTile();
    One.TF.CurrentDungeonField = "MapData_" + txtMap.text + ".txt";
    UpdateDebugMessage("MapData_" + txtMap.text + ".txt");
    // タイルを設置
    LoadTileMapping(One.TF.CurrentDungeonField);

    if (this.ReloadMap)
    {
      // イベント進行に応じたオブジェクトの設置
      LoadObjectFromEvent();

      RefreshAllView();
    }
  }

  public void TapSelectReload(Text txtReloadMap)
  {
    this.ReloadMap = !this.ReloadMap;
    if (this.ReloadMap)
    {
      txtReloadMap.text = "ReloadMap";
    }
    else
    {
      txtReloadMap.text = "NoReload";
    }
  }

  public void TapPartyMenu()
  {
    GroupPartyMenu.gameObject.SetActive(true);
    this.CurrentPlayer = PlayerList[0];
    //TapStayListCharacter(StayListName[0]);
    //CallGroupPartyStatus(this.CurrentPlayer);
    //TapStatus();
  }

  public void TapStatus()
  {
    SetupStayList();
    CallGroupPartyStatus(this.CurrentPlayer);

    groupPartyStatus.gameObject.SetActive(true);
    groupPartyCommand.SetActive(false);
    groupPartyItem.SetActive(false);
    groupPartyBattleSetting.SetActive(false);
  }
  public void TapCommand()
  {
    SetupStayList();
    groupPartyStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(true);
    groupPartyItem.SetActive(false);
    groupPartyBattleSetting.SetActive(false);
  }

  public void TapItem()
  {
    SetupStayList();
    groupPartyStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(false);
    groupPartyItem.SetActive(true);
    groupPartyBattleSetting.SetActive(false);
  }

  public void TapBattleSetting()
  {
    SetupStayList();
    groupPartyStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(false);
    groupPartyItem.SetActive(false);
    groupPartyBattleSetting.SetActive(true);
  }

  public void TapExit()
  {
    GroupPartyMenu.gameObject.SetActive(false);
  }

  public void TapCommandTypeBasic()
  {
    SetupActionCommand(this.CurrentPlayer, ActionCommand.CommandCategory.Basic);
  }

  public void TapCommandTypeAction()
  {
    SetupActionCommand(this.CurrentPlayer, ActionCommand.CommandCategory.ActionCommand);
  }

  public void TapCommandTypeItem()
  {
    SetupActionCommand(this.CurrentPlayer, ActionCommand.CommandCategory.Item);
  }

  public void TapCommandTypeArchetype()
  {
    SetupActionCommand(this.CurrentPlayer, ActionCommand.CommandCategory.Archetype);
  }

  public void TapMenu()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    // Tacticsのリスト
    SetupStayList();

    //int num = 0;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer1, num); num++;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer2, num); num++;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer3, num); num++;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer4, num); num++;


    //UpdateStayListCheckMark();

  }

  public void TapStatusCharacter()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
  }

  public void TapActionCommand(Text txt_src)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + txt_src.text);

    if (txt_src.text == Fix.FRESH_HEAL)
    {
      objCancelActionCommand.SetActive(true);
    }
    else if (txt_src.text == Fix.SHINING_HEAL)
    {
      Character player = One.SelectCharacter(txtCurrentName.text);
      if (player.CurrentSoulPoint < ActionCommand.CostSP(Fix.SHINING_HEAL))
      {
        return;
      }
      player.CurrentSoulPoint -= ActionCommand.CostSP(Fix.SHINING_HEAL);

      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.ShiningHeal(player);
        Character target = PlayerList[ii];
        if (target.Dead)
        {
          return;
        }

        if (healValue <= 0) { healValue = 0; }
        PlayerList[ii].CurrentLife += (int)healValue;
      }
      groupPartyStatus.UpdateCharacterDetailView(groupPartyStatus.CurrentPlayer);
    }
    SetupStayList();
  }

  public void TapCancelActionCommand()
  {
    objCancelActionCommand.SetActive(false);
  }

  public void TapAvailableListButton(NodeActionCommand action_command)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (FilterForAll.activeInHierarchy == false)
    {
      this.CurrentSelectCommand = action_command;
      FilterForAll.SetActive(true);
      FilterForActionCommand.SetActive(false);
      FilterForAvailableList.SetActive(true);
      return;
    }

    TapCancelActionCommandSet();
  }

  public void TapActionCommandSetList(NodeActionCommand action_command)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    if (FilterForAll.activeInHierarchy == false)
    {
      FilterForAll.SetActive(true);
      FilterForActionCommand.SetActive(true);
      FilterForAvailableList.SetActive(false);
      return;
    }

    action_command.CommandName = this.CurrentSelectCommand.CommandName;
    action_command.ApplyImageIcon(this.CurrentSelectCommand.CommandName);
    //action_command.ActionButton.image.sprite = Resources.Load<Sprite>(this.CurrentSelectCommand.CommandName);
    TapCancelActionCommandSet();

    if (ActionCommandMain.Equals(action_command))
    {
      CurrentPlayer.ActionCommandMain = action_command.CommandName;
    }
    else
    {
      CurrentPlayer.UpdateActionCommandList(ListActionCommandSet);
    }
  }

  public void TapCancelActionCommandSet()
  {
    FilterForAll.SetActive(false);
    FilterForActionCommand.SetActive(false);
    FilterForAvailableList.SetActive(false);
    this.CurrentSelectCommand = null;
  }

  public void TapStayListCharacter(Text txt_name)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    // コマンド実行
    if (objCancelActionCommand.activeInHierarchy)
    {
      Character player = One.SelectCharacter(txtCurrentName.text);
      Character target = One.SelectCharacter(txt_name.text);

      double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random) * SecondaryLogic.FreshHeal(player);
      Debug.Log(MethodBase.GetCurrentMethod());
      if (target.Dead)
      {
        return;
      }
      if (player.CurrentSoulPoint < ActionCommand.CostSP(Fix.FRESH_HEAL))
      {
        return;
      }
      player.CurrentSoulPoint -= ActionCommand.CostSP(Fix.FRESH_HEAL);

      if (healValue <= 0) { healValue = 0; }
      int result = (int)healValue;
      Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " heal");
      target.CurrentLife += result;

      objCancelActionCommand.SetActive(false);
      ParentBackpackView.objBlockFilter.SetActive(false);
      SetupStayList();
      RefreshAllView();
      return;
    }

    // アイテム実行
    if (ParentBackpackView.objBlockFilter.activeInHierarchy)
    {
      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        if (txt_name.text == PlayerList[ii].FullName)
        {
          if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.SMALL_RED_POTION ||
              ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.NORMAL_RED_POTION ||
              ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.LARGE_RED_POTION ||
              ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.HUGE_RED_POTION ||
              ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.HQ_RED_POTION ||
              ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.THQ_RED_POTION ||
              ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.PERFECT_RED_POTION)
          {
            Item current = new Item(ParentBackpackView.CurrentSelectBackpack.ItemName);
            One.TF.DeleteBackpack(current, 1);
            double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
            PlayerList[ii].CurrentLife += (int)effectValue;
          }
          else if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.SMALL_BLUE_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.NORMAL_BLUE_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.LARGE_BLUE_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.HUGE_BLUE_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.HQ_BLUE_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.THQ_BLUE_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.PERFECT_BLUE_POTION)
          {
            Item current = new Item(ParentBackpackView.CurrentSelectBackpack.ItemName);
            One.TF.DeleteBackpack(current, 1);
            double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
            PlayerList[ii].CurrentSoulPoint += (int)effectValue;
          }
          objCancelActionCommand.SetActive(false);
          ParentBackpackView.objBlockFilter.SetActive(false);
          SetupStayList();
          RefreshAllView();
          break;
        }
      }
      return;
    }

    // 通常選択
    for (int ii = 0; ii < PlayerList.Count; ii++)
    {
      if (txt_name.text == PlayerList[ii].FullName)
      {
        this.CurrentPlayer = PlayerList[ii];
        CallGroupPartyStatus(PlayerList[ii]);
        break;
      }
    }

    txtCurrentName.text = txt_name.text;
    txtBattleSettingCharacterName.text = txt_name.text;
    Character player2 = One.SelectCharacter(txt_name.text);
    if (player2 != null)
    {
      if (player2.FreshHeal > 0) { objActionCommand[0].SetActive(true); }
      else { objActionCommand[0].SetActive(false); }

      if (player2.ShiningHeal > 0) { objActionCommand[1].SetActive(true); }
      else { objActionCommand[1].SetActive(false); }

      if (player2.LifeGrace > 0) { objActionCommand[2].SetActive(true); }
      else { objActionCommand[2].SetActive(false); }
    }

    // コマンド設定画面への反映
    Character player3 = One.SelectCharacter(txt_name.text);
    SetupActionCommand(player3, ActionCommand.CommandCategory.ActionCommand); // [基本行動]が一番左で最初だが、デフォルトはアクションコマンドを表示
  }

  private void CallGroupPartyStatus(Character player)
  {
    //groupPartyStatus.parentMotherBase = this;
    //groupPartyStatus.ReleaseIt();
    //groupPartyStatus.CurrentPlayer = player;
    //groupPartyStatus.UpdateCharacterDetailView(player);

    SceneManager.sceneLoaded += CharacterStatusLoadded;
    SceneDimension.SceneAdd("CharacterStatus");

  }

  private void CharacterStatusLoadded(Scene next, LoadSceneMode mode)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    SceneManager.sceneLoaded -= CharacterStatusLoadded;

    var charaStatus = GameObject.Find("groupCharacterStatus").GetComponent<GroupCharacterStatus>();

    charaStatus.parentMotherBase = this;
    charaStatus.ReleaseIt();
    charaStatus.CurrentPlayer = this.CurrentPlayer;
    charaStatus.UpdateCharacterDetailView(this.CurrentPlayer);
  }

  private void SetupStayList()
  {
    for (int ii = 0; ii < StayListName.Count; ii++)
    {
      if (StayList[ii] != null) { StayList[ii].gameObject.SetActive(false); }
      if (StayListName[ii] != null) { StayListName[ii].text = string.Empty; }
      if (StayListLife[ii] != null) { StayListLife[ii].text = string.Empty; }
      if (StayListSP[ii] != null) { StayListSP[ii].text = string.Empty; }
    }
    Debug.Log("PlayerList count: " + PlayerList.Count.ToString());

    for (int ii = 0; ii < PlayerList.Count; ii++)
    {
      Debug.Log("PlayerList name: " + PlayerList[ii].FullName);
      StayListName[ii].text = PlayerList[ii].FullName;
      StayListLife[ii].text = PlayerList[ii].CurrentLife.ToString() + " / " + PlayerList[ii].MaxLife.ToString();
      if (StayListLifeGauge[ii] != null)
      {
        float dx = (float)PlayerList[ii].CurrentLife / (float)PlayerList[ii].MaxLife;
        StayListLifeGauge[ii].rectTransform.localScale = new Vector2(dx, 1.0f);
      }
      if (StayListSP[ii] != null) { StayListSP[ii].text = PlayerList[ii].CurrentSoulPoint.ToString() + " / " + PlayerList[ii].MaxSoulPoint.ToString(); }
      if (StayListSPGauge[ii] != null)
      {
        float dx = (float)PlayerList[ii].CurrentSoulPoint / (float)PlayerList[ii].MaxSoulPoint;
        StayListSPGauge[ii].rectTransform.localScale = new Vector2(dx, 1.0f);
      }
      StayList[ii].gameObject.SetActive(true);
      //if (One.PlayerList[ii].FullName == One.TF.BattlePlayer1)
      //{
      //  StayListName[counter].text = One.PlayerList[ii].FullName;
      //  StayListLife[counter].text = One.PlayerList[ii].CurrentLife.ToString();
      //  counter++;
      //}
      //if (One.PlayerList[ii].FullName == One.TF.BattlePlayer2)
      //{
      //  StayListName[counter].text = One.PlayerList[ii].FullName;
      //  StayListLife[counter].text = One.PlayerList[ii].CurrentLife.ToString();
      //  counter++;
      //}
      //if (One.PlayerList[ii].FullName == One.TF.BattlePlayer3)
      //{
      //  StayListName[counter].text = One.PlayerList[ii].FullName;
      //  StayListLife[counter].text = One.PlayerList[ii].CurrentLife.ToString();
      //  counter++;
      //}
      //if (One.PlayerList[ii].FullName == One.TF.BattlePlayer4)
      //{
      //  StayListName[counter].text = One.PlayerList[ii].FullName;
      //  StayListLife[counter].text = One.PlayerList[ii].CurrentLife.ToString();
      //  counter++;
      //}
    }
  }

  private void SetupActionCommand(Character player, ActionCommand.CommandCategory category_type)
  {
    Debug.Log("ListActionCommandSet.Count: " + ListActionCommandSet.Count);

    // キャラクターのメインコマンド、アクションコマンドの設定
    ActionCommandMain.BackColor.color = player.BattleForeColor;
    ActionCommandMain.OwnerName = player.FullName;
    ActionCommandMain.CommandName = player.ActionCommandMain;
    ActionCommandMain.name = player.ActionCommandMain;
    ActionCommandMain.ActionButton.name = player.ActionCommandMain;
    ActionCommandMain.ApplyImageIcon(player.ActionCommandMain);
    //ActionCommandMain.ActionButton.image.sprite = Resources.Load<Sprite>(player.ActionCommandMain);

    List<String> actionList = player.GetActionCommandList();
    for (int ii = 0; ii < ListActionCommandSet.Count; ii++)
    {
      ListActionCommandSet[ii].BackColor.color = player.BattleForeColor;
      ListActionCommandSet[ii].OwnerName = player.FullName;
      if (actionList[ii] == Fix.STAY)
      {
        ListActionCommandSet[ii].CommandName = Fix.STAY;
        ListActionCommandSet[ii].name = Fix.STAY;
        ListActionCommandSet[ii].ActionButton.name = Fix.STAY;
        ListActionCommandSet[ii].ApplyImageIcon(Fix.STAY);
        //ListActionCommandSet[ii].ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STAY);
        continue;
      }

      ListActionCommandSet[ii].CommandName = actionList[ii];
      ListActionCommandSet[ii].name = actionList[ii];
      ListActionCommandSet[ii].ActionButton.name = actionList[ii];
      ListActionCommandSet[ii].ApplyImageIcon(actionList[ii]);
      //ListActionCommandSet[ii].ActionButton.image.sprite = Resources.Load<Sprite>(actionList[ii]);
    }

    // アクション可能なコマンド一覧の設定
    for (int ii = 0; ii < ListAvailableCommand.Count; ii++)
    {
      ListAvailableCommand[ii].CommandName = String.Empty;
      ListAvailableCommand[ii].name = String.Empty;
      ListAvailableCommand[ii].ActionButton.image.sprite = null;
      ListAvailableCommandText[ii].text = String.Empty;
    }

    // todo (カテゴリが増えた場合、追加実装が必要）
    groupCommandCategory.SetActive(One.TF.AvailableImmediateAction);
    btnCommandCategoryAction.gameObject.SetActive(One.TF.AvailableImmediateAction);
    btnCommandCetegoryItem.gameObject.SetActive(One.TF.AvailableImmediateAction);
    btnCommandCetegoryArchetype.gameObject.SetActive(One.TF.AvailablePotentialGauge);

    List<string> currentList = null;
    if (category_type == ActionCommand.CommandCategory.Basic)
    {
      currentList = player.GetAvailableBasicAction();
    }
    else if (category_type == ActionCommand.CommandCategory.ActionCommand)
    {
      currentList = player.GetAvailableList();
    }
    else if (category_type == ActionCommand.CommandCategory.Item)
    {
      currentList = player.GetAvailableListItem();
    }
    else if (category_type == ActionCommand.CommandCategory.Archetype)
    {
      currentList = player.GetAvailableListArchetype();
    }
    else
    {
      currentList = player.GetAvailableBasicAction(); // 万が一見つからない場合はBasicで表示
    }

    for (int ii = 0; ii < ListAvailableCommand.Count; ii++)
    {
      Debug.Log("GetAvailableList: " + ListAvailableCommand[ii].CommandName);
      if (ii >= currentList.Count)
      {
        ListAvailableCommand[ii].CommandName = String.Empty;
        ListAvailableCommand[ii].name = String.Empty;
        ListAvailableCommand[ii].ActionButton.image.sprite = null;
        ListAvailableCommandText[ii].text = String.Empty;
        continue;
      }
      ListAvailableCommand[ii].CommandName = currentList[ii];
      ListAvailableCommand[ii].name = currentList[ii];
      ListAvailableCommand[ii].ApplyImageIcon(currentList[ii]);
      //ListAvailableCommand[ii].ActionButton.image.sprite = Resources.Load<Sprite>(currentList[ii]);
      ListAvailableCommandText[ii].text = currentList[ii];
    }
  }

  private void UpdateStayListCheckMark()
  {
    //for (int ii = 0; ii < PartyListName.Count; ii++)
    //{
    //  if (PartyListName[ii].text != "(Empty" && PartyListName[ii].text != String.Empty)
    //  {
    //    if (ii == 0) { One.TF.BattlePlayer1 = PartyListName[ii].text; }
    //    if (ii == 1) { One.TF.BattlePlayer2 = PartyListName[ii].text; }
    //    if (ii == 2) { One.TF.BattlePlayer3 = PartyListName[ii].text; }
    //    if (ii == 3) { One.TF.BattlePlayer4 = PartyListName[ii].text; }
    //  }
    //  else
    //  {
    //    if (ii == 0) { One.TF.BattlePlayer1 = string.Empty; }
    //    if (ii == 1) { One.TF.BattlePlayer2 = string.Empty; }
    //    if (ii == 2) { One.TF.BattlePlayer3 = string.Empty; }
    //    if (ii == 3) { One.TF.BattlePlayer4 = string.Empty; }
    //  }
    //}

    for (int ii = 0; ii < StayListName.Count; ii++)
    {
      Debug.Log("StayListName: " + StayListName[ii].text);
      if (StayListName[ii].text != string.Empty &&
          (StayListName[ii].text == One.TF.BattlePlayer1 ||
           StayListName[ii].text == One.TF.BattlePlayer2 ||
           StayListName[ii].text == One.TF.BattlePlayer3 ||
           StayListName[ii].text == One.TF.BattlePlayer4))
      {
        StayListCheckMark[ii].SetActive(true);
      }
      else
      {
        StayListCheckMark[ii].SetActive(false);
      }
    }
  }

  private void UpdateTacticsPartyMember(string full_name, int num)
  {
    if (full_name != string.Empty)
    {
      for (int ii = 0; ii < One.PlayerList.Count; ii++)
      {
        if (One.PlayerList[ii].FullName == full_name)
        {
          //PartyListClass[num].sprite = Resources.Load<Sprite>("Unit_" + current?.Job.ToString() ?? "");
          //PartyListName[num].text = current.FullName;
          //PartyListLevel[num].text = current.Level.ToString();
          //PartyListLife[num].text = current.CurrentLife.ToString() + " / " + current.MaxLife.ToString();
          //PartyListSTR[num].text = current.TotalStrength.ToString();
          //PartyListAGL[num].text = current.TotalAgility.ToString();
          //PartyListINT[num].text = current.TotalIntelligence.ToString();
          //PartyListSTM[num].text = current.TotalStamina.ToString();
          //PartyListMND[num].text = current.TotalMind.ToString();

          //foreach (Transform n in GroupPartyList[num].transform)
          //{
          //  GameObject.Destroy(n.gameObject);
          //}
          //for (int jj = 0; jj < current.ActionCommandList.Count; jj++)
          //{
          //  NodeActionCommand instant = Instantiate(prefab_ActionCommand) as NodeActionCommand;
          //  instant.BackColor.color = current.BattleForeColor;
          //  instant.CommandName = current.ActionCommandList[jj];
          //  instant.name = current.ActionCommandList[jj];
          //  instant.OwnerName = current.FullName;
          //  instant.ActionButton.name = current.ActionCommandList[jj];
          //  instant.ActionButton.image.sprite = Resources.Load<Sprite>(current.ActionCommandList[jj]);

          //  //Debug.Log("TapPartyPickChoose: " + TacticsPickupCharacter.ActionCommandList[jj]);
          //  instant.transform.SetParent(GroupPartyList[num].transform);
          //  instant.gameObject.SetActive(true);
          //}
          break;
        }
      }
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

  public void TapBackpack()
  {
    if (ParentBackpackView.gameObject.activeInHierarchy)
    {
      ParentBackpackView.gameObject.SetActive(false);
      return;
    }

    ParentBackpackView.ConstructBackpackView();
    ParentBackpackView.gameObject.SetActive(true);
  }

  public void TapFastTravel()
  {
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_BASE_FIELD)
    {
      this.currentDecision = Fix.DECISION_TRANSFER_TOWN;
      GroupMapSelect.SetActive(true);
    }
    else
    {
      this.currentDecision = Fix.DECISION_ESCAPE_FROM_DUNGEON;
      txtDecisionTitle.text = "ダンジョンの外へと帰還しますか？";
      txtDecisionMessage.text = "ダンジョンから出た場合、その日は再びダンジョン内に入る事は出来なくなります。";
      txtDecisionA.text = "Accept";
      txtDecisionB.text = "Cancel";
      txtDecisionC.text = "";
      GroupDecision.SetActive(true);
    }
  }

  public void TapDecisionAccept()
  {
    if (this.currentDecision == Fix.DECISION_ESCAPE_FROM_DUNGEON)
    {
      this.HomeTownCall = One.TF.BeforeAreaName;
      return;
    }
    if (this.currentDecision == Fix.DECISION_TRANSFER_TOWN)
    {
      One.TF.CurrentAreaName = this.CurrentMapSelectName;
      SceneManager.LoadSceneAsync("HomeTown");
      return;
    }
    if (this.currentDecision == Fix.DECISION_ARTHARIUM_CLIFF)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message300071(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (this.currentDecision == Fix.DECISION_ARTHARIUM_CLIFF_END)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message300081(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (this.currentDecision == Fix.DECISION_ARTHARIUM_CRASH_DOOR)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message300111(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (this.currentDecision == Fix.DECISION_ARTHARIUM_CRASH_DOOR2)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message300121(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (this.currentDecision == Fix.DECISION_PARTY_JOIN_SELMOI_RO)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message1200011(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
  }

  public void TapDecisionCancel()
  {
    if (this.currentDecision == Fix.DECISION_ESCAPE_FROM_DUNGEON)
    {
      GroupDecision.SetActive(false);
      return;
    }
    if (this.currentDecision == Fix.DECISION_TRANSFER_TOWN)
    {
      this.CurrentMapSelectName = String.Empty;
      GroupDecision.SetActive(false);
      return;
    }
    if (this.currentDecision == Fix.DECISION_ARTHARIUM_CLIFF)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message300072(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (this.currentDecision == Fix.DECISION_ARTHARIUM_CLIFF_END)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message300082(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (this.currentDecision == Fix.DECISION_ARTHARIUM_CRASH_DOOR)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message300112(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (this.currentDecision == Fix.DECISION_ARTHARIUM_CRASH_DOOR2)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message300122(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (this.currentDecision == Fix.DECISION_PARTY_JOIN_SELMOI_RO)
    {
      GroupDecision.SetActive(false);
      MessagePack.Message1200012(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
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
    txtDecisionTitle.text = map_text.text + "へと移動しますか？";
    txtDecisionMessage.text = "";
    GroupDecision.SetActive(true);
  }

  public void TapPlayerStatus(Text player_text)
  {
    //if (One.PlayerList == null) { Debug.Log("PlayerList is null..."); return; }

    //// 既にプレイヤーステータスが開かれており、同一の名前だった場合は、その画面を閉じる。
    //if (groupCharacterStatus.gameObject.activeInHierarchy && groupCharacterStatus.CurrentPlayer?.FullName == player_text.text)
    //{
    //  groupCharacterStatus.gameObject.SetActive(false);
    //  return;
    //}

    //for (int ii = 0; ii < One.PlayerList.Count; ii++)
    //{
    //  if (One.PlayerList[ii] == null) { Debug.Log("PlayerList[" + ii.ToString() + "] is null..."); return; }

    //  if (One.PlayerList[ii].FullName == player_text.text)
    //  {
    //    One.PlayerList[ii].GetReadyLevelUp();
    //    groupCharacterStatus.parentMotherBase = this;
    //    groupCharacterStatus.ReleaseIt();
    //    groupCharacterStatus.CurrentPlayer = One.PlayerList[ii];
    //    groupCharacterStatus.UpdateCharacterDetailView(One.PlayerList[ii]);
    //    break;
    //  }
    //}

    //groupCharacterStatus.gameObject.SetActive(true);
  }

  public void TapCharacterDetailBack()
  {
    //groupCharacterStatus.gameObject.SetActive(false);
  }

  public void TapBattleConfig()
  {
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

  public void TapNoFieldDamage(Text txt)
  {
    if (txt.text == "Field Damage")
    {
      this.FieldDamage = 0.0f;
      txt.text = "No Damage";
    }
    else
    {
      this.FieldDamage = 1.0f;
      txt.text = "Field Damage";
    }
  }

  public void TapHideUnknown(Text txt)
  {
    if (txt.text == "Hide Disable")
    {
      for (int ii = 0; ii < UnknownTileList.Count; ii++)
      {
        UnknownTileList[ii].gameObject.SetActive(false);
      }
    }
  }

  public void TapIgnoreObjectMove(Text txt)
  {
    if (txt.text == "IgnoreObj Disable")
    {
      txt.text = "IgnoreObj Enable";
      IgnoreObjMode = true;
    }
    else
    {
      txt.text = "IgnoreObj Disable";
      IgnoreObjMode = false;
    }
  }

  public void TapDevelopView(Text txt)
  {
    if (txt.text == "Develop Enable")
    {
      txt.text = "Develop Disable";
      GroupDevelop.SetActive(false);
    }
    else
    {
      txt.text = "Develop Enable";
      GroupDevelop.SetActive(true);
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

  public void TapSelectObjectName()
  {
    Debug.Log("TapSelectObjectName(S)");
    for (int ii = 0; ii < ObjectList.Count; ii++)
    {
      if (txtSelectObjectName.text == ObjectList[ii])
      {
        if (ii >= ObjectList.Count - 1)
        {
          txtSelectObjectName.text = ObjectList[0];
        }
        else
        {
          txtSelectObjectName.text = ObjectList[ii + 1];
        }
        return;
      }
    }
  }
  public void TapSelectObjectNameBack()
  {
    Debug.Log("TapSelectObjectNameBack(S)");
    for (int ii = ObjectList.Count - 1; ii >= 0; ii--)
    {
      if (txtSelectObjectName.text == ObjectList[ii])
      {
        if (ii <= 0)
        {
          txtSelectObjectName.text = ObjectList[ObjectList.Count - 1];
        }
        else
        {
          txtSelectObjectName.text = ObjectList[ii - 1];
        }
        return;
      }
    }
  }

  public void TapHideView(int hide_floor)
  {
    Debug.Log("TapHideView");

    for (int ii = 0; ii < TileList.Count; ii++)
    {
      if (TileList[ii].transform.position.y >= hide_floor)
      {
        TileList[ii].gameObject.SetActive(false);
      }
      else
      {
        TileList[ii].gameObject.SetActive(true);
      }
    }
  }

  public void TapHideViewRev(int hide_floor)
  {
    for (int ii = TileList.Count - 1; ii >= 0; ii--)
    {
      if (TileList[ii].transform.position.y <= hide_floor)
      {
        TileList[ii].gameObject.SetActive(false);
      }
      else
      {
        TileList[ii].gameObject.SetActive(true);
      }
    }
  }

  public void TapHideAreaNumber()
  {
    for (int ii = 0; ii < TileAreaList.Count; ii++)
    {
      TileAreaList[ii].gameObject.SetActive(!TileAreaList[ii].gameObject.activeInHierarchy);
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

  public void TapEditArea()
  {
    if (txtEditArea.text == "AreaEdit-OFF")
    {
      txtEditArea.text = "None";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "None")
    {
      txtEditArea.text = "AREA_1";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_1")
    {
      txtEditArea.text = "AREA_2";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_2")
    {
      txtEditArea.text = "AREA_3";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_3")
    {
      txtEditArea.text = "AREA_4";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_4")
    {
      txtEditArea.text = "AREA_5";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_5")
    {
      txtEditArea.text = "AREA_6";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_6")
    {
      txtEditArea.text = "AREA_7";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_7")
    {
      txtEditArea.text = "AREA_8";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_8")
    {
      txtEditArea.text = "AREA_9";
      this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_9")
    {
        txtEditArea.text = "AREA_10";
        this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_10")
    {
        txtEditArea.text = "AREA_11";
        this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_11")
    {
        txtEditArea.text = "AREA_12";
        this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_12")
    {
        txtEditArea.text = "AREA_13";
        this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_13")
    {
        txtEditArea.text = "AREA_14";
        this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_14")
    {
        txtEditArea.text = "AREA_15";
        this.EditAreaMode = true;
    }
    else if (txtEditArea.text == "AREA_15")
    {
        txtEditArea.text = "AREA_16";
        this.EditAreaMode = true;
    }
    else
    {
      txtEditArea.text = "AreaEdit-OFF";
      this.EditAreaMode = false;
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
    One.SaveMode = true;
    One.AfterBacktoTitle = false;
    One.SaveAndExit = false;
    this.groupSaveLoad.SceneLoading();
    this.groupSaveLoad.gameObject.SetActive(true);
    //    SceneDimension.CallSaveLoad(this, true, false);
  }

  public void TapLoad()
  {
    One.SaveMode = false;
    One.AfterBacktoTitle = false;
    One.SaveAndExit = false;
    One.Parent.Add(this);
    this.groupSaveLoad.SceneLoading();
    this.groupSaveLoad.gameObject.SetActive(true);
    //    SceneDimension.CallSaveLoad(this, false, false);
  }

  public void TapHelp()
  {
    Debug.Log(MethodBase.GetCurrentMethod() + "(S)");
    SceneDimension.SceneAdd(Fix.SCENE_HELP_BOOK);
  }

  public void TapBacktoTown()
  {
    Debug.Log("TapBacktoTown(S)");
    this.HomeTownComplete = true;
    One.TF.LocationPlayer2 = false;
    One.TF.BeforeAreaName = One.TF.CurrentAreaName;
    SceneDimension.JumpToHomeTown();
  }

  public void TapJumpView(NodeEditFieldObj node_edit_obj)
  {
    MainCamera.transform.position = new Vector3(node_edit_obj.x - 0.0f,
                                       node_edit_obj.y + 7.0f,
                                       node_edit_obj.z - 1.0f);

    SelectField.transform.position = new Vector3(node_edit_obj.x,
                                             node_edit_obj.y,
                                             node_edit_obj.z);

  }

  public void PointerDownArrowTop()
  {
    UpdateDebugMessage(MethodBase.GetCurrentMethod().ToString());
    this.arrowUp = true;
    this.arrowDown = false;
  }
  public void PointerDownArrowBottom()
  {
    UpdateDebugMessage(MethodBase.GetCurrentMethod().ToString());
    this.arrowUp = false;
    this.arrowDown = true;
  }
  public void PointerDownArrowLeft()
  {
    UpdateDebugMessage(MethodBase.GetCurrentMethod().ToString());
    this.arrowLeft = true;
    this.arrowRight = false;
  }
  public void PointerDownArrowRight()
  {
    UpdateDebugMessage(MethodBase.GetCurrentMethod().ToString());
    this.arrowLeft = false;
    this.arrowRight = true;
  }
  public void PointerUpArrow()
  {
    UpdateDebugMessage(MethodBase.GetCurrentMethod().ToString());
    detectKeyUp = true;
    CancelKeyDownMovement();
  }

  public void CancelKeyDownMovement()
  {
    this.arrowUp = false;
    this.arrowDown = false;
    this.arrowLeft = false;
    this.arrowRight = false;
    this.keyUp = false;
    this.keyDown = false;
    this.keyLeft = false;
    this.keyRight = false;
    this.interval = MOVE_INTERVAL;
  }

  private void movementTimer_Tick()
  {
    if (this.interval < this.MovementInterval) { this.interval++; return; }
    else { this.interval = 0; }

    TileInformation tile = null;
    if (this.keyUp)
    {
      tile = SearchNextTile(this.Player.transform.position, Direction.Top);
      if (BlockCheck(Player, tile) == false)
      {
        One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
        return;
      }
      UpdatePlayersKeyEvents(Direction.Top, tile);
    }
    else if (this.keyRight)
    {
      tile = SearchNextTile(this.Player.transform.position, Direction.Right);
      if (BlockCheck(Player, tile) == false)
      {
        One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
        return;
      }
      UpdatePlayersKeyEvents(Direction.Right, tile);
    }
    else if (this.keyDown)
    {
      tile = SearchNextTile(this.Player.transform.position, Direction.Bottom);
      if (BlockCheck(Player, tile) == false)
      {
        One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
        return;
      }
      UpdatePlayersKeyEvents(Direction.Bottom, tile);
    }
    else if (this.keyLeft)
    {
      tile = SearchNextTile(this.Player.transform.position, Direction.Left);
      if (BlockCheck(Player, tile) == false)
      {
        One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
        return;
      }
      UpdatePlayersKeyEvents(Direction.Left, tile);
    }
  }

  private void UpdatePlayersKeyEvents(Direction direction, TileInformation tile)
  {
    Debug.Log("UpdatePlayersKeyEvents(S)");

    // 移動直前、フィールドオブジェクトの検出および対応。
    FieldObject fieldObjBefore = SearchObject(new Vector3(tile.transform.position.x,
                                                          tile.transform.position.y + 1.0f,
                                                          tile.transform.position.z));
    if (fieldObjBefore == null)
    {
      fieldObjBefore = SearchObject(new Vector3(tile.transform.position.x,
                                                          tile.transform.position.y + 0.5f,
                                                          tile.transform.position.z));
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Fountain)
    {
      MessagePack.MessageX00004(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    // todo 位置によってイベントが違う。位置による制御違いを実装する必要がある。
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.MessageBoard)
    {
      Debug.Log("MessageBoard detect: " + fieldObjBefore.ObjectId);
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
      {
        Debug.Log("fieldObjBefore: " + fieldObjBefore.transform.position.x + " " + fieldObjBefore.transform.position.y + " " + fieldObjBefore.transform.position.z);
        if (LocationFieldDetect(fieldObjBefore, 0, 1, 0))
        {
          //MessagePack.Message000020(ref QuestMessageList, ref QuestEventList); TapOK();
          MessagePack.Message000120(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        else if (LocationFieldDetect(fieldObjBefore, 12, 1, -4))
        {
          MessagePack.Message000030(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        else if (LocationFieldDetect(fieldObjBefore, -9, 1, 11))
        {
          MessagePack.Message000040(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        else if (LocationFieldDetect(fieldObjBefore, -5, 1, -3))
        {
          MessagePack.Message000050(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        else if (LocationFieldDetect(fieldObjBefore, 7, 1, -3))
        {
          MessagePack.Message000060(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, 25, 1, 9))
        {
          MessagePack.Message000070(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, 5, 1, 4))
        {
          MessagePack.Message000090(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, 3, 1, 7))
        {
          MessagePack.Message000095(ref QuestMessageList, ref QuestEventList); TapOK();
        }
      }
      else if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
      {
        if (LocationFieldDetect(fieldObjBefore, Fix.GORATRUM_MessageBoard_1_X, Fix.GORATRUM_MessageBoard_1_Y, Fix.GORATRUM_MessageBoard_1_Z))
        {
          MessagePack.Message600015(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.GORATRUM_MessageBoard_2_X, Fix.GORATRUM_MessageBoard_2_Y, Fix.GORATRUM_MessageBoard_2_Z))
        {
          MessagePack.Message600170(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.GORATRUM_MessageBoard_3_X, Fix.GORATRUM_MessageBoard_3_Y, Fix.GORATRUM_MessageBoard_3_Z))
        {
          MessagePack.Message600180(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.GORATRUM_MessageBoard_4_X, Fix.GORATRUM_MessageBoard_4_Y, Fix.GORATRUM_MessageBoard_4_Z))
        {
          MessagePack.Message600220(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.GORATRUM_MessageBoard_5_X, Fix.GORATRUM_MessageBoard_5_Y, Fix.GORATRUM_MessageBoard_5_Z))
        {
          MessagePack.Message600170(ref QuestMessageList, ref QuestEventList); TapOK();
        }
      }
      else if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
      {
        if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_MessageBoard_1_X, Fix.MYSTICFOREST_MessageBoard_1_Y, Fix.MYSTICFOREST_MessageBoard_1_Z))
        {
          MessagePack.Message900010(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_MessageBoard_2_X, Fix.MYSTICFOREST_MessageBoard_2_Y, Fix.MYSTICFOREST_MessageBoard_2_Z))
        {
          MessagePack.Message900050(ref QuestMessageList, ref QuestEventList); TapOK();
        }
      }
      return;
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Rock)
    {
      Debug.Log("Content.Rock detect: " + fieldObjBefore.ObjectId + " " + fieldObjBefore.transform.position.x + " " + fieldObjBefore.transform.position.y + " " + fieldObjBefore.transform.position.z);
      if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK))
      {
        if (LocationFieldDetect(fieldObjBefore, Fix.CAVEOFSARUN_Rock_5_X, Fix.CAVEOFSARUN_Rock_5_Y, Fix.CAVEOFSARUN_Rock_5_Z))
        {
          MessagePack.Message000140(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.CAVEOFSARUN_Rock_6_X, Fix.CAVEOFSARUN_Rock_6_Y, Fix.CAVEOFSARUN_Rock_6_Z))
        {
          MessagePack.Message000150(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.CAVEOFSARUN_Rock_7_X, Fix.CAVEOFSARUN_Rock_7_Y, Fix.CAVEOFSARUN_Rock_7_Z))
        {
          MessagePack.Message000160(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.CAVEOFSARUN_Rock_4_X, Fix.CAVEOFSARUN_Rock_4_Y, Fix.CAVEOFSARUN_Rock_4_Z))
        {
          MessagePack.Message000170(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.CAVEOFSARUN_Rock_8_X, Fix.CAVEOFSARUN_Rock_8_Y, Fix.CAVEOFSARUN_Rock_8_Z))
        {
          MessagePack.Message000180(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
      }
    }

    // todo 位置によってイベントが違う。位置による制御違いを実装する必要がある。
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Door_Copper)
    {
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
      {
        if (LocationFieldDetect(fieldObjBefore, Fix.GORATRUM_CopperDoor_1_X, Fix.GORATRUM_CopperDoor_1_Y, Fix.GORATRUM_CopperDoor_1_Z))
        {
          MessagePack.Message600020(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.GORATRUM_CopperDoor_2_X, Fix.GORATRUM_CopperDoor_2_Y, Fix.GORATRUM_CopperDoor_2_Z))
        {
          if (this.Player.transform.position == new Vector3(Fix.GORATRUM_CopperDoor_2_X - 1.0f, Fix.GORATRUM_CopperDoor_2_Y, Fix.GORATRUM_CopperDoor_2_Z))
          {
            MessagePack.Message600340(ref QuestMessageList, ref QuestEventList); TapOK();
          }
          else
          {
            MessagePack.Message600030(ref QuestMessageList, ref QuestEventList); TapOK();
          }
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.GORATRUM_CopperDoor_3_X, Fix.GORATRUM_CopperDoor_3_Y, Fix.GORATRUM_CopperDoor_3_Z))
        {
          if (this.Player.transform.position == new Vector3(Fix.GORATRUM_CopperDoor_3_X, Fix.GORATRUM_CopperDoor_3_Y, Fix.GORATRUM_CopperDoor_3_Z - 1.0f))
          {
            MessagePack.Message600270(ref QuestMessageList, ref QuestEventList); TapOK();
          }
          else
          {
            MessagePack.Message600190(ref QuestMessageList, ref QuestEventList); TapOK();
          }
        }
      }

      if (LocationFieldDetect(fieldObjBefore, Fix.MAPEVENT_ARTHARIUM_4_0_X, Fix.MAPEVENT_ARTHARIUM_4_0_Y, Fix.MAPEVENT_ARTHARIUM_4_0_Z))
      {
        MessagePack.Message300110(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      else if (LocationFieldDetect(fieldObjBefore, Fix.MAPEVENT_ARTHARIUM_5_X, Fix.MAPEVENT_ARTHARIUM_5_Y, Fix.MAPEVENT_ARTHARIUM_5_Z))
      {
        MessagePack.Message300120(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      else if (LocationFieldDetect(fieldObjBefore, Fix.ARTHARIUM_Door_Copper_3_X, Fix.ARTHARIUM_Door_Copper_3_Y, Fix.ARTHARIUM_Door_Copper_3_Z))
      {
        MessagePack.Message300170(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      return;
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.DhalGate_Door)
    {
      if (LocationFieldDetect(fieldObjBefore, Fix.EVENT_GATEDHAL_1_X, Fix.EVENT_GATEDHAL_1_Y, Fix.EVENT_GATEDHAL_1_Z))
      {
        MessagePack.Message1400010(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      if (LocationFieldDetect(fieldObjBefore, Fix.EVENT_GATEDHAL_2_X, Fix.EVENT_GATEDHAL_2_Y, Fix.EVENT_GATEDHAL_2_Z))
      {
        MessagePack.Message1400020(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      if (LocationFieldDetect(fieldObjBefore, Fix.EVENT_GATEDHAL_3_X, Fix.EVENT_GATEDHAL_3_Y, Fix.EVENT_GATEDHAL_3_Z))
      {
        MessagePack.Message1400030(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Crystal)
    {
      if (LocationFieldDetect(fieldObjBefore, Fix.ARTHARIUM_Crystal_1_X, Fix.ARTHARIUM_Crystal_1_Y, Fix.ARTHARIUM_Crystal_1_Z))
      {
        MessagePack.Message300130(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Crystal)
    {
      if (LocationFieldDetect(fieldObjBefore, Fix.ARTHARIUM_Crystal_2_X, Fix.ARTHARIUM_Crystal_2_Y, Fix.ARTHARIUM_Crystal_2_Z))
      {
        MessagePack.Message300160(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.ObsidianStone)
    {
      if (LocationFieldDetect(fieldObjBefore, Fix.ARTHARIUM_ObsidianStone_1_X, Fix.ARTHARIUM_ObsidianStone_1_Y, Fix.ARTHARIUM_ObsidianStone_1_Z))
      {
        MessagePack.Message300210(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    // オブジェクト（岩）の判定
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Rock)
    {
      Debug.Log("fieldObjBefore is rock, then no move");
      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      return;
    }
    // オブジェクト（茂み）の判定
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Brushwood)
    {
      Debug.Log("fieldObjBefore is Brushwood, then no move");
      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      return;
    }

    TileInformation beforeTile = tile;
    Debug.Log("beforeTile: " + beforeTile.transform.position.ToString());
    if (beforeTile != null && beforeTile.field == TileInformation.Field.Goratrum_Hole)
    {
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
      {
        if (One.TF.FindBackPackItem(Fix.ITEM_WALKING_ROPE))
        {
          if (LocationDetect(tile, Fix.GORATRUM_Hole_1_X, Fix.GORATRUM_Hole_1_Y, Fix.GORATRUM_Hole_1_Z))
          {
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_1_X, Fix.GORATRUM_Hole_1_Y + 1.5f, Fix.GORATRUM_Hole_1_Z + 1.0f))
            {
              MessagePack.Message600070(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_1_X, Fix.GORATRUM_Hole_1_Y + 1.5f, Fix.GORATRUM_Hole_1_Z - 1.0f))
            {
              MessagePack.Message600080(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            return;
          }

          if (LocationDetect(tile, Fix.GORATRUM_Hole_2_X, Fix.GORATRUM_Hole_2_Y, Fix.GORATRUM_Hole_2_Z))
          {
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_2_X, Fix.GORATRUM_Hole_2_Y + 1.5f, Fix.GORATRUM_Hole_2_Z + 1.0f))
            {
              MessagePack.Message600090(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_2_X, Fix.GORATRUM_Hole_2_Y + 1.5f, Fix.GORATRUM_Hole_2_Z - 1.0f))
            {
              MessagePack.Message600100(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            return;
          }

          if (LocationDetect(tile, Fix.GORATRUM_Hole_3_X, Fix.GORATRUM_Hole_3_Y, Fix.GORATRUM_Hole_3_Z))
          {
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_3_X, Fix.GORATRUM_Hole_3_Y + 1.5f, Fix.GORATRUM_Hole_3_Z + 1.0f))
            {
              MessagePack.Message600110(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_3_X, Fix.GORATRUM_Hole_3_Y + 1.5f, Fix.GORATRUM_Hole_3_Z - 1.0f))
            {
              MessagePack.Message600120(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            return;
          }

          if (LocationDetect(tile, Fix.GORATRUM_Hole_4_X, Fix.GORATRUM_Hole_4_Y, Fix.GORATRUM_Hole_4_Z))
          {
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_4_X, Fix.GORATRUM_Hole_4_Y + 1.5f, Fix.GORATRUM_Hole_4_Z + 1.0f))
            {
              MessagePack.Message600130(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_4_X, Fix.GORATRUM_Hole_4_Y + 1.5f, Fix.GORATRUM_Hole_4_Z - 1.0f))
            {
              MessagePack.Message600140(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            return;
          }

          if (LocationDetect(tile, Fix.GORATRUM_Hole_5_X, Fix.GORATRUM_Hole_5_Y, Fix.GORATRUM_Hole_5_Z))
          {
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_5_X - 1.0f, Fix.GORATRUM_Hole_5_Y + 1.5f, Fix.GORATRUM_Hole_5_Z))
            {
              MessagePack.Message600150(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_5_X + 1.0f, Fix.GORATRUM_Hole_5_Y + 1.5f, Fix.GORATRUM_Hole_5_Z))
            {
              MessagePack.Message600160(ref QuestMessageList, ref QuestEventList); TapOK();
            }
            return;
          }
        }
        else
        {
          // ロープを持たない場合、そのまま穴へ落ちる。

          // 下記、ロープで渡れないため、記述不要
          //if (LocationDetect(tile, Fix.GORATRUM_Event_9_X, Fix.GORATRUM_Event_9_Y, Fix.GORATRUM_Event_9_Z)) { return; }
          //if (LocationDetect(tile, Fix.GORATRUM_Event_10_X, Fix.GORATRUM_Event_10_Y, Fix.GORATRUM_Event_10_Z)) { return; }
          //if (LocationDetect(tile, Fix.GORATRUM_Event_11_X, Fix.GORATRUM_Event_11_Y, Fix.GORATRUM_Event_11_Z)) { return; }
          //if (LocationDetect(tile, Fix.GORATRUM_Event_12_X, Fix.GORATRUM_Event_12_Y, Fix.GORATRUM_Event_12_Z)) { return; }
          //if (LocationDetect(tile, Fix.GORATRUM_Event_13_X, Fix.GORATRUM_Event_13_Y, Fix.GORATRUM_Event_13_Z)) { return; }
          //if (LocationDetect(tile, Fix.GORATRUM_Event_14_X, Fix.GORATRUM_Event_14_Y, Fix.GORATRUM_Event_14_Z)) { return; }
        }

        if (LocationDetect(tile, Fix.GORATRUM_Hole_12_X, Fix.GORATRUM_Hole_12_Y, Fix.GORATRUM_Hole_12_Z))
        {
          if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_12_X, Fix.GORATRUM_Hole_12_Y + 1.5f, Fix.GORATRUM_Hole_12_Z - 1.0f))
          {
            MessagePack.Message600230(ref QuestMessageList, ref QuestEventList, 0); TapOK();
          }
          else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_12_X - 1.0f, Fix.GORATRUM_Hole_12_Y + 1.5f, Fix.GORATRUM_Hole_12_Z))
          {
            MessagePack.Message600230(ref QuestMessageList, ref QuestEventList, 1); TapOK();
          }
          else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_12_X + 1.0f, Fix.GORATRUM_Hole_12_Y + 1.5f, Fix.GORATRUM_Hole_12_Z))
          {
            MessagePack.Message600230(ref QuestMessageList, ref QuestEventList, 2); TapOK();
          }
          else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_12_X, Fix.GORATRUM_Hole_12_Y + 1.5f, Fix.GORATRUM_Hole_12_Z + 1.0f))
          {
            MessagePack.Message600230(ref QuestMessageList, ref QuestEventList, 3); TapOK();
          }
          return;
        }

        if (LocationDetect(tile, Fix.GORATRUM_Hole_13_X, Fix.GORATRUM_Hole_13_Y, Fix.GORATRUM_Hole_13_Z))
        {
          if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_13_X, Fix.GORATRUM_Hole_13_Y + 1.5f, Fix.GORATRUM_Hole_13_Z - 1.0f))
          {
            MessagePack.Message600250(ref QuestMessageList, ref QuestEventList, 0, "13"); TapOK();
          }
          else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_13_X - 1.0f, Fix.GORATRUM_Hole_13_Y + 1.5f, Fix.GORATRUM_Hole_13_Z))
          {
            MessagePack.Message600250(ref QuestMessageList, ref QuestEventList, 1, "13"); TapOK();
          }
          else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_13_X + 1.0f, Fix.GORATRUM_Hole_13_Y + 1.5f, Fix.GORATRUM_Hole_13_Z))
          {
            MessagePack.Message600250(ref QuestMessageList, ref QuestEventList, 2, "13"); TapOK();
          }
          else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_13_X, Fix.GORATRUM_Hole_13_Y + 1.5f, Fix.GORATRUM_Hole_13_Z + 1.0f))
          {
            MessagePack.Message600250(ref QuestMessageList, ref QuestEventList, 3, "13"); TapOK();
          }
          return;
        }

        if (LocationDetect(tile, Fix.GORATRUM_Hole_14_X, Fix.GORATRUM_Hole_14_Y, Fix.GORATRUM_Hole_14_Z))
        {
          MessagePack.Message600260(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }

        if (LocationDetect(tile, Fix.GORATRUM_Hole_15_X, Fix.GORATRUM_Hole_15_Y, Fix.GORATRUM_Hole_15_Z))
        {
          if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_15_X, Fix.GORATRUM_Hole_15_Y + 1.5f, Fix.GORATRUM_Hole_15_Z - 1.0f))
          {
            MessagePack.Message600280(ref QuestMessageList, ref QuestEventList, 0); TapOK();
          }
          else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_15_X - 1.0f, Fix.GORATRUM_Hole_15_Y + 1.5f, Fix.GORATRUM_Hole_15_Z))
          {
            MessagePack.Message600280(ref QuestMessageList, ref QuestEventList, 1); TapOK();
          }
          else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_15_X + 1.0f, Fix.GORATRUM_Hole_15_Y + 1.5f, Fix.GORATRUM_Hole_15_Z))
          {
            MessagePack.Message600280(ref QuestMessageList, ref QuestEventList, 2); TapOK();
          }
          else if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Hole_15_X, Fix.GORATRUM_Hole_15_Y + 1.5f, Fix.GORATRUM_Hole_15_Z + 1.0f))
          {
            MessagePack.Message600280(ref QuestMessageList, ref QuestEventList, 3); TapOK();
          }
          return;
        }

        if (LocationDetect(tile, Fix.GORATRUM_Hole_29_X, Fix.GORATRUM_Hole_29_Y, Fix.GORATRUM_Hole_29_Z))
        {
          MessagePack.Message600250(ref QuestMessageList, ref QuestEventList, 1, Fix.GORATRUM_Hole_29_O); TapOK();
          return;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Hole_30_X, Fix.GORATRUM_Hole_30_Y, Fix.GORATRUM_Hole_30_Z))
        {
          MessagePack.Message600250(ref QuestMessageList, ref QuestEventList, 1, Fix.GORATRUM_Hole_30_O); TapOK();
          return;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Hole_31_X, Fix.GORATRUM_Hole_31_Y, Fix.GORATRUM_Hole_31_Z))
        {
          MessagePack.Message600250(ref QuestMessageList, ref QuestEventList, 2, Fix.GORATRUM_Hole_31_O); TapOK();
          return;
        }

      }
    }

    // 移動する。
    JumpToLocation(new Vector3(tile.transform.position.x,
                               tile.transform.position.y + 1.0f,
                               tile.transform.position.z));

    // UnknownTileを更新する。
    UpdateUnknownTile(Player.transform.position);

    One.PlaySoundEffect(Fix.SOUND_FOOT_STEP);

    // 移動直後、フィールドオブジェクトの検出および対応。
    FieldObject fieldObj = SearchObject(this.Player.transform.position);

    if (fieldObj != null && fieldObj.content == FieldObject.Content.Treasure)
    {
      Vector3 location = fieldObj.transform.position;
      int number = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);

      #region "サルンの洞窟前"
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
      {
        string treasureName = String.Empty;

        Debug.Log("Detect fieldObj: " + location);

        if (One.TF.Treasure_CaveOfSarun_00001 == false && location.x == Fix.CAVEOFSARUN_Treasure_1_X && location.y == Fix.CAVEOFSARUN_Treasure_1_Y && location.z == Fix.CAVEOFSARUN_Treasure_1_Z)
        {
          treasureName = Fix.FINE_SWORD;
        }
        if (One.TF.Treasure_CaveOfSarun_00002 == false && location.x == Fix.CAVEOFSARUN_Treasure_2_X && location.y == Fix.CAVEOFSARUN_Treasure_2_Y && location.z == Fix.CAVEOFSARUN_Treasure_2_Z)
        {
          treasureName = Fix.GREEN_PENDANT;
        }
        if (One.TF.Treasure_CaveOfSarun_00003 == false && location.x == Fix.CAVEOFSARUN_Treasure_3_X && location.y == Fix.CAVEOFSARUN_Treasure_3_Y && location.z == Fix.CAVEOFSARUN_Treasure_3_Z)
        {
          treasureName = Fix.FINE_ORB;
        }
        if (One.TF.Treasure_CaveOfSarun_00004 == false && location.x == Fix.CAVEOFSARUN_Treasure_4_X && location.y == Fix.CAVEOFSARUN_Treasure_4_Y && location.z == Fix.CAVEOFSARUN_Treasure_4_Z)
        {
          treasureName = Fix.FLAT_SHOES;
        }
        if (One.TF.Treasure_CaveOfSarun_00005 == false && location.x == Fix.CAVEOFSARUN_Treasure_5_X && location.y == Fix.CAVEOFSARUN_Treasure_5_Y && location.z == Fix.CAVEOFSARUN_Treasure_5_Z)
        {
          treasureName = Fix.COMPACT_EARRING;
        }
        if (One.TF.Treasure_CaveOfSarun_00006 == false && location.x == Fix.CAVEOFSARUN_Treasure_6_X && location.y == Fix.CAVEOFSARUN_Treasure_6_Y && location.z == Fix.CAVEOFSARUN_Treasure_6_Z)
        {
          treasureName = Fix.CHERRY_CHOKER;
        }
        if (One.TF.Treasure_CaveOfSarun_00007 == false && location.x == Fix.CAVEOFSARUN_Treasure_7_X && location.y == Fix.CAVEOFSARUN_Treasure_7_Y && location.z == Fix.CAVEOFSARUN_Treasure_7_Z)
        {
          treasureName = Fix.ITEM_MATOCK;
        }
        if (One.TF.Treasure_CaveOfSarun_00008 == false && location.x == Fix.CAVEOFSARUN_Treasure_8_X && location.y == Fix.CAVEOFSARUN_Treasure_8_Y && location.z == Fix.CAVEOFSARUN_Treasure_8_Z)
        {
          treasureName = Fix.FINE_SHIELD;
        }
        if (One.TF.Treasure_CaveOfSarun_00009 == false && location.x == Fix.CAVEOFSARUN_Treasure_9_X && location.y == Fix.CAVEOFSARUN_Treasure_9_Y && location.z == Fix.CAVEOFSARUN_Treasure_9_Z)
        {
          treasureName = Fix.FINE_ARMOR;
        }
        if (One.TF.Treasure_CaveOfSarun_00010 == false && location.x == Fix.CAVEOFSARUN_Treasure_10_X && location.y == Fix.CAVEOFSARUN_Treasure_10_Y && location.z == Fix.CAVEOFSARUN_Treasure_10_Z)
        {
          treasureName = Fix.FIRE_ANGEL_TALISMAN;
        }

        if (treasureName == String.Empty)
        {
          // 何もしない
        }
        else
        {
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName); TapOK();
        }
      }
      #endregion
      #region "ゴラトラム洞窟"
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
      {
        string treasureName = String.Empty;
        if (One.TF.Treasure_Goratrum_00001 == false && location.x == Fix.GORATRUM_Treasure_1_X && location.y == Fix.GORATRUM_Treasure_1_Y && location.z == Fix.GORATRUM_Treasure_1_Z)
        {
          treasureName = Fix.ITEM_WALKING_ROPE;
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
          MessagePack.Message600040(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
        }

        if (One.TF.Treasure_Goratrum_00002 == false && location.x == Fix.GORATRUM_Treasure_2_X && location.y == Fix.GORATRUM_Treasure_2_Y && location.z == Fix.GORATRUM_Treasure_2_Z)
        {
          treasureName = Fix.NORMAL_RED_POTION;
        }
        if (One.TF.Treasure_Goratrum_00003 == false && location.x == Fix.GORATRUM_Treasure_3_X && location.y == Fix.GORATRUM_Treasure_3_Y && location.z == Fix.GORATRUM_Treasure_3_Z)
        {
          treasureName = Fix.ELVISH_BOW;
        }
        if (One.TF.Treasure_Goratrum_00004 == false && location.x == Fix.GORATRUM_Treasure_4_X && location.y == Fix.GORATRUM_Treasure_4_Y && location.z == Fix.GORATRUM_Treasure_4_Z)
        {
          treasureName = Fix.ITEM_COPPER_KEY;
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
          MessagePack.Message600200(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
        }
        if (One.TF.Treasure_Goratrum_00005 == false && location.x == Fix.GORATRUM_Treasure_5_X && location.y == Fix.GORATRUM_Treasure_5_Y && location.z == Fix.GORATRUM_Treasure_5_Z)
        {
          treasureName = Fix.RED_PENDANT;
        }
        if (One.TF.Treasure_Goratrum_00006 == false && location.x == Fix.GORATRUM_Treasure_6_X && location.y == Fix.GORATRUM_Treasure_6_Y && location.z == Fix.GORATRUM_Treasure_6_Z)
        {
          treasureName = Fix.KITE_SHIELD;
        }
        if (One.TF.Treasure_Goratrum_00007 == false && location.x == Fix.GORATRUM_Treasure_7_X && location.y == Fix.GORATRUM_Treasure_7_Y && location.z == Fix.GORATRUM_Treasure_7_Z)
        {
          treasureName = Fix.KINDNESS_BOOK;
        }
        if (One.TF.Treasure_Goratrum_00008 == false && location.x == Fix.GORATRUM_Treasure_8_X && location.y == Fix.GORATRUM_Treasure_8_Y && location.z == Fix.GORATRUM_Treasure_8_Z)
        {
          treasureName = Fix.GREEN_PENDANT;
        }
        if (One.TF.Treasure_Goratrum_00009 == false && location.x == Fix.GORATRUM_Treasure_9_X && location.y == Fix.GORATRUM_Treasure_9_Y && location.z == Fix.GORATRUM_Treasure_9_Z)
        {
          treasureName = Fix.PURPLE_PENDANT;
        }
        if (One.TF.Treasure_Goratrum_00010 == false && location.x == Fix.GORATRUM_Treasure_10_X && location.y == Fix.GORATRUM_Treasure_10_Y && location.z == Fix.GORATRUM_Treasure_10_Z)
        {
          treasureName = Fix.YELLOW_PENDANT;
        }
        if (One.TF.Treasure_Goratrum_00011 == false && location.x == Fix.GORATRUM_Treasure_11_X && location.y == Fix.GORATRUM_Treasure_11_Y && location.z == Fix.GORATRUM_Treasure_11_Z)
        {
          treasureName = Fix.PURE_CLEAN_WATER;
        }

        if (treasureName == String.Empty)
        {
          // 何もしない
        }
        else
        {
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName); TapOK();
        }
      }
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
      {
        string treasureName = String.Empty;
        if (One.TF.Treasure_Goratrum2_00001 == false && location.x == Fix.GORATRUM_2_Treasure_1_X && location.y == Fix.GORATRUM_2_Treasure_1_Y && location.z == Fix.GORATRUM_2_Treasure_1_Z)
        {
          treasureName = Fix.ENERGY_ORB;
        }
        if (One.TF.Treasure_Goratrum2_00002 == false && location.x == Fix.GORATRUM_2_Treasure_2_X && location.y == Fix.GORATRUM_2_Treasure_2_Y && location.z == Fix.GORATRUM_2_Treasure_2_Z)
        {
          treasureName = Fix.NORMAL_BLUE_POTION;
        }
        if (One.TF.Treasure_Goratrum2_00003 == false && location.x == Fix.GORATRUM_2_Treasure_3_X && location.y == Fix.GORATRUM_2_Treasure_3_Y && location.z == Fix.GORATRUM_2_Treasure_3_Z)
        {
          treasureName = Fix.LIGHTNING_CLAW;
        }
        if (One.TF.Treasure_Goratrum2_00004 == false && location.x == Fix.GORATRUM_2_Treasure_4_X && location.y == Fix.GORATRUM_2_Treasure_4_Y && location.z == Fix.GORATRUM_2_Treasure_4_Z)
        {
          treasureName = Fix.ICE_SPIRIT_LANCE;
        }

        if (treasureName == String.Empty)
        {
          // 何もしない
        }
        else
        {
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName); TapOK();
        }
      }
      #endregion
      #region "アーサリウム工場跡地"
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
      {
        string treasureName = String.Empty;

        Debug.Log("Detect fieldObj: " + location);
        // 宝箱１
        if (One.TF.Treasure_Artharium_00001 == false && location.x == Fix.ARTHARIUM_Treasure_2_X && location.y == Fix.ARTHARIUM_Treasure_2_Y && location.z == Fix.ARTHARIUM_Treasure_2_Z)
        {
          treasureName = Fix.FINE_SWORD;
        }
        // 宝箱２
        if (One.TF.Treasure_Artharium_00002 == false && location.x == Fix.ARTHARIUM_Treasure_8_X && location.y == Fix.ARTHARIUM_Treasure_8_Y && location.z == Fix.ARTHARIUM_Treasure_8_Z)
        {
          treasureName = Fix.FINE_LANCE;
        }
        // 宝箱３
        if (One.TF.Treasure_Artharium_00003 == false && location.x == Fix.ARTHARIUM_Treasure_9_X && location.y == Fix.ARTHARIUM_Treasure_9_Y && location.z == Fix.ARTHARIUM_Treasure_9_Z)
        {
          treasureName = Fix.FINE_ARMOR;
        }
        // 宝箱４
        if (One.TF.Treasure_Artharium_00004 == false && location.x == Fix.ARTHARIUM_Treasure_10_X && location.y == Fix.ARTHARIUM_Treasure_10_Y && location.z == Fix.ARTHARIUM_Treasure_10_Z)
        {
          treasureName = Fix.FINE_CLAW;
        }
        // 宝箱５
        if (One.TF.Treasure_Artharium_00005 == false && location.x == Fix.ARTHARIUM_Treasure_11_X && location.y == Fix.ARTHARIUM_Treasure_11_Y && location.z == Fix.ARTHARIUM_Treasure_11_Z)
        {
          treasureName = Fix.BLUE_PENDANT;
        }
        // 宝箱６
        if (One.TF.Treasure_Artharium_00006 == false && location.x == Fix.ARTHARIUM_Treasure_12_X && location.y == Fix.ARTHARIUM_Treasure_12_Y && location.z == Fix.ARTHARIUM_Treasure_12_Z)
        {
          treasureName = Fix.YELLOW_PENDANT;
        }
        // 宝箱７
        if (One.TF.Treasure_Artharium_00007 == false && location.x == Fix.ARTHARIUM_Treasure_13_X && location.y == Fix.ARTHARIUM_Treasure_13_Y && location.z == Fix.ARTHARIUM_Treasure_13_Z)
        {
          treasureName = Fix.GREEN_PENDANT;
        }
        // 宝箱８
        if (One.TF.Treasure_Artharium_00008 == false && location.x == Fix.ARTHARIUM_Treasure_14_X && location.y == Fix.ARTHARIUM_Treasure_14_Y && location.z == Fix.ARTHARIUM_Treasure_14_Z)
        {
          treasureName = Fix.PURPLE_PENDANT;
        }
        // 宝箱９
        if (One.TF.Treasure_Artharium_00009 == false && location.x == Fix.ARTHARIUM_Treasure_3_X && location.y == Fix.ARTHARIUM_Treasure_3_Y && location.z == Fix.ARTHARIUM_Treasure_3_Z)
        {
          treasureName = Fix.FINE_BOW;
        }
        // 宝箱１０
        if (One.TF.Treasure_Artharium_00010 == false && location.x == Fix.ARTHARIUM_Treasure_15_X && location.y == Fix.ARTHARIUM_Treasure_15_Y && location.z == Fix.ARTHARIUM_Treasure_15_Z)
        {
          treasureName = Fix.SURVIVAL_CLAW;
        }
        // 宝箱１１
        if (One.TF.Treasure_Artharium_00011 == false && location.x == Fix.ARTHARIUM_Treasure_16_X && location.y == Fix.ARTHARIUM_Treasure_16_Y && location.z == Fix.ARTHARIUM_Treasure_16_Z)
        {
          treasureName = Fix.BRONZE_SWORD;
        }
        // 宝箱１２
        if (One.TF.Treasure_Artharium_00012 == false && location.x == Fix.ARTHARIUM_Treasure_17_X && location.y == Fix.ARTHARIUM_Treasure_17_Y && location.z == Fix.ARTHARIUM_Treasure_17_Z)
        {
          treasureName = Fix.SHARP_LANCE;
        }
        // 宝箱１３
        if (One.TF.Treasure_Artharium_00013 == false && location.x == Fix.ARTHARIUM_Treasure_18_X && location.y == Fix.ARTHARIUM_Treasure_18_Y && location.z == Fix.ARTHARIUM_Treasure_18_Z)
        {
          treasureName = Fix.VIKING_AXE;
        }
        // 宝箱１４
        if (One.TF.Treasure_Artharium_00014 == false && location.x == Fix.ARTHARIUM_Treasure_19_X && location.y == Fix.ARTHARIUM_Treasure_19_Y && location.z == Fix.ARTHARIUM_Treasure_19_Z)
        {
          treasureName = Fix.ENERGY_ORB;
        }
        // 宝箱１５
        if (One.TF.Treasure_Artharium_00015 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_20_X, Fix.ARTHARIUM_Treasure_20_Y, Fix.ARTHARIUM_Treasure_20_Z))
        {
          treasureName = Fix.WOOD_ROD;
        }
        // 宝箱１６
        if (One.TF.Treasure_Artharium_00016 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_21_X, Fix.ARTHARIUM_Treasure_21_Y, Fix.ARTHARIUM_Treasure_21_Z))
        {
          treasureName = Fix.KINDNESS_BOOK;
        }
        // 宝箱１７
        if (One.TF.Treasure_Artharium_00017 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_22_X, Fix.ARTHARIUM_Treasure_22_Y, Fix.ARTHARIUM_Treasure_22_Z))
        {
          treasureName = Fix.ELVISH_BOW;
        }
        // 宝箱１８
        if (One.TF.Treasure_Artharium_00018 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_23_X, Fix.ARTHARIUM_Treasure_23_Y, Fix.ARTHARIUM_Treasure_23_Z))
        {
          treasureName = Fix.KITE_SHIELD;
        }
        // 宝箱１９
        if (One.TF.Treasure_Artharium_00019 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_24_X, Fix.ARTHARIUM_Treasure_24_Y, Fix.ARTHARIUM_Treasure_24_Z))
        {
          treasureName = Fix.COMPACT_EARRING;
        }
        // 宝箱２０
        if (One.TF.Treasure_Artharium_00020 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_25_X, Fix.ARTHARIUM_Treasure_25_Y, Fix.ARTHARIUM_Treasure_25_Z))
        {
          treasureName = Fix.BLUE_WIZARD_HAT;
        }
        // 宝箱２１
        if (One.TF.Treasure_Artharium_00021 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_26_X, Fix.ARTHARIUM_Treasure_26_Y, Fix.ARTHARIUM_Treasure_26_Z))
        {
          treasureName = Fix.CHERRY_CHOKER;
        }
        // 宝箱２２
        if (One.TF.Treasure_Artharium_00022 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_27_X, Fix.ARTHARIUM_Treasure_27_Y, Fix.ARTHARIUM_Treasure_27_Z))
        {
          treasureName = Fix.ARTHARIUM_KEY;
        }
        // 宝箱２３
        if (One.TF.Treasure_Artharium_00023 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_6_X, Fix.ARTHARIUM_Treasure_6_Y, Fix.ARTHARIUM_Treasure_6_Z))
        {
          treasureName = Fix.PURPLE_PENDANT;
        }
        // 宝箱２４
        if (One.TF.Treasure_Artharium_00024 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_5_X, Fix.ARTHARIUM_Treasure_5_Y, Fix.ARTHARIUM_Treasure_5_Z))
        {
          treasureName = Fix.YELLOW_PENDANT;
        }
        // 宝箱２５
        if (One.TF.Treasure_Artharium_00025 == false && LocationFieldDetect(fieldObj, Fix.ARTHARIUM_Treasure_7_X, Fix.ARTHARIUM_Treasure_7_Y, Fix.ARTHARIUM_Treasure_7_Z))
        {
          treasureName = Fix.FLAME_HAND_KEEPER;
        }

        if (treasureName == String.Empty)
        {
          // 何もしない
        }
        else
        {
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName); TapOK();
        }
        return;
      }
      #endregion
      #region "オーランの塔"
      // オーランの塔
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
      {
        string treasureName = String.Empty;
        // 宝箱１
        if (One.TF.Treasure_OhranTower_00001 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_1_X, Fix.OHRANTOWER_Treasure_1_Y, Fix.OHRANTOWER_Treasure_1_Z))
        {
          treasureName = Fix.RED_PENDANT;
        }
        // 宝箱２
        if (One.TF.Treasure_OhranTower_00002 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_2_X, Fix.OHRANTOWER_Treasure_2_Y, Fix.OHRANTOWER_Treasure_2_Z))
        {
          treasureName = Fix.BLUE_PENDANT;
        }
        // 宝箱３
        if (One.TF.Treasure_OhranTower_00003 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_3_X, Fix.OHRANTOWER_Treasure_3_Y, Fix.OHRANTOWER_Treasure_3_Z))
        {
          treasureName = Fix.YELLOW_PENDANT;
        }
        // 宝箱４
        if (One.TF.Treasure_OhranTower_00004 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_4_X, Fix.OHRANTOWER_Treasure_4_Y, Fix.OHRANTOWER_Treasure_4_Z))
        {
          treasureName = Fix.GREEN_PENDANT;
        }
        // 宝箱５
        if (One.TF.Treasure_OhranTower_00005 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_5_X, Fix.OHRANTOWER_Treasure_5_Y, Fix.OHRANTOWER_Treasure_5_Z))
        {
          treasureName = Fix.SWORD_OF_LIFE;
        }
        // 宝箱６
        if (One.TF.Treasure_OhranTower_00006 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_6_X, Fix.OHRANTOWER_Treasure_6_Y, Fix.OHRANTOWER_Treasure_6_Z))
        {
          treasureName = Fix.EARTH_POWER_AXE;
        }
        // 宝箱７
        if (One.TF.Treasure_OhranTower_00007 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_7_X, Fix.OHRANTOWER_Treasure_7_Y, Fix.OHRANTOWER_Treasure_7_Z))
        {
          treasureName = Fix.FROST_LANCE;
        }
        // 宝箱８
        if (One.TF.Treasure_OhranTower_00008 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_8_X, Fix.OHRANTOWER_Treasure_8_Y, Fix.OHRANTOWER_Treasure_8_Z))
        {
          treasureName = Fix.TOUGH_TREE_ROD;
        }
        // 宝箱９
        if (One.TF.Treasure_OhranTower_00009 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_9_X, Fix.OHRANTOWER_Treasure_9_Y, Fix.OHRANTOWER_Treasure_9_Z))
        {
          treasureName = Fix.LIVING_GROWTH_ORB;
        }
        // 宝箱１０
        if (One.TF.Treasure_OhranTower_00010 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_10_X, Fix.OHRANTOWER_Treasure_10_Y, Fix.OHRANTOWER_Treasure_10_Z))
        {
          treasureName = Fix.MUIN_BOOK;
        }
        // 宝箱１１
        if (One.TF.Treasure_OhranTower_00011 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_11_X, Fix.OHRANTOWER_Treasure_11_Y, Fix.OHRANTOWER_Treasure_11_Z))
        {
          treasureName = Fix.ICICLE_LONGBOW;
        }
        // 宝箱１２
        if (One.TF.Treasure_OhranTower_00012 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_12_X, Fix.OHRANTOWER_Treasure_12_Y, Fix.OHRANTOWER_Treasure_12_Z))
        {
          treasureName = Fix.KITE_SHIELD;
        }
        // 宝箱１３
        if (One.TF.Treasure_OhranTower_00013 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_13_X, Fix.OHRANTOWER_Treasure_13_Y, Fix.OHRANTOWER_Treasure_13_Z))
        {
          treasureName = Fix.FINE_ARMOR;
        }
        // 宝箱１４
        if (One.TF.Treasure_OhranTower_00014 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_14_X, Fix.OHRANTOWER_Treasure_14_Y, Fix.OHRANTOWER_Treasure_14_Z))
        {
          treasureName = Fix.FINE_CROSS;
        }
        // 宝箱１５
        if (One.TF.Treasure_OhranTower_00015 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_15_X, Fix.OHRANTOWER_Treasure_15_Y, Fix.OHRANTOWER_Treasure_15_Z))
        {
          treasureName = Fix.FINE_ROBE;
        }
        // 宝箱１６
        if (One.TF.Treasure_OhranTower_00016 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_16_X, Fix.OHRANTOWER_Treasure_16_Y, Fix.OHRANTOWER_Treasure_16_Z))
        {
          treasureName = Fix.FLAT_SHOES;
        }
        // 宝箱１７
        if (One.TF.Treasure_OhranTower_00017 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_17_X, Fix.OHRANTOWER_Treasure_17_Y, Fix.OHRANTOWER_Treasure_17_Z))
        {
          treasureName = Fix.COMPACT_EARRING;
        }
        // 宝箱１８
        if (One.TF.Treasure_OhranTower_00018 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_18_X, Fix.OHRANTOWER_Treasure_18_Y, Fix.OHRANTOWER_Treasure_18_Z))
        {
          treasureName = Fix.POWER_BANDANA;
        }
        // 宝箱１９
        if (One.TF.Treasure_OhranTower_00019 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_19_X, Fix.OHRANTOWER_Treasure_19_Y, Fix.OHRANTOWER_Treasure_19_Z))
        {
          treasureName = Fix.CHERRY_CHOKER;
        }
        // 宝箱２０
        if (One.TF.Treasure_OhranTower_00020 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_20_X, Fix.OHRANTOWER_Treasure_20_Y, Fix.OHRANTOWER_Treasure_20_Z))
        {
          treasureName = Fix.BLUE_WIZARD_HAT;
        }
        // 宝箱２１
        if (One.TF.Treasure_OhranTower_00021 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_21_X, Fix.OHRANTOWER_Treasure_21_Y, Fix.OHRANTOWER_Treasure_21_Z))
        {
          treasureName = Fix.FLAME_HAND_KEEPER;
        }
        // 宝箱２２
        if (One.TF.Treasure_OhranTower_00022 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_22_X, Fix.OHRANTOWER_Treasure_22_Y, Fix.OHRANTOWER_Treasure_22_Z))
        {
          treasureName = Fix.MUMYOU_BOW;
        }
        // 宝箱２３
        if (One.TF.Treasure_OhranTower_00023 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_23_X, Fix.OHRANTOWER_Treasure_23_Y, Fix.OHRANTOWER_Treasure_23_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }

        if (treasureName == String.Empty)
        {
          // 何もしない
        }
        else
        {
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName); TapOK();
        }
        return;
      }
      #endregion
      #region "ダルの門"
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GATE_OF_DHAL)
      {
        string treasureName = String.Empty;
        if (One.TF.Treasure_GateDhal_00001 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_1_X, Fix.GATEOFDHAL_Treasure_1_Y, Fix.GATEOFDHAL_Treasure_1_Z))
        {
          treasureName = Fix.RED_PENDANT;
        }
        if (One.TF.Treasure_GateDhal_00002 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_2_X, Fix.GATEOFDHAL_Treasure_2_Y, Fix.GATEOFDHAL_Treasure_2_Z))
        {
          treasureName = Fix.BLUE_PENDANT;
        }
        if (One.TF.Treasure_GateDhal_00003 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_3_X, Fix.GATEOFDHAL_Treasure_3_Y, Fix.GATEOFDHAL_Treasure_3_Z))
        {
          treasureName = Fix.YELLOW_PENDANT;
        }
        if (One.TF.Treasure_GateDhal_00004 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_4_X, Fix.GATEOFDHAL_Treasure_4_Y, Fix.GATEOFDHAL_Treasure_4_Z))
        {
          treasureName = Fix.GREEN_PENDANT;
        }
        if (One.TF.Treasure_GateDhal_00005 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_5_X, Fix.GATEOFDHAL_Treasure_5_Y, Fix.GATEOFDHAL_Treasure_5_Z))
        {
          treasureName = Fix.SWORD_OF_LIFE;
        }
        if (One.TF.Treasure_GateDhal_00006 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_6_X, Fix.GATEOFDHAL_Treasure_6_Y, Fix.GATEOFDHAL_Treasure_6_Z))
        {
          treasureName = Fix.EARTH_POWER_AXE;
        }
        if (One.TF.Treasure_GateDhal_00007 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_7_X, Fix.GATEOFDHAL_Treasure_7_Y, Fix.GATEOFDHAL_Treasure_7_Z))
        {
          treasureName = Fix.FROST_LANCE;
        }
        if (One.TF.Treasure_GateDhal_00008 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_8_X, Fix.GATEOFDHAL_Treasure_8_Y, Fix.GATEOFDHAL_Treasure_8_Z))
        {
          treasureName = Fix.TOUGH_TREE_ROD;
        }
        if (One.TF.Treasure_GateDhal_00009 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_9_X, Fix.GATEOFDHAL_Treasure_9_Y, Fix.GATEOFDHAL_Treasure_9_Z))
        {
          treasureName = Fix.LIVING_GROWTH_ORB;
        }
        if (One.TF.Treasure_GateDhal_00010 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_10_X, Fix.GATEOFDHAL_Treasure_10_Y, Fix.GATEOFDHAL_Treasure_10_Z))
        {
          treasureName = Fix.MUIN_BOOK;
        }
        if (One.TF.Treasure_GateDhal_00011 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_11_X, Fix.GATEOFDHAL_Treasure_11_Y, Fix.GATEOFDHAL_Treasure_11_Z))
        {
          treasureName = Fix.ICICLE_LONGBOW;
        }
        if (One.TF.Treasure_GateDhal_00012 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_12_X, Fix.GATEOFDHAL_Treasure_12_Y, Fix.GATEOFDHAL_Treasure_12_Z))
        {
          treasureName = Fix.KITE_SHIELD;
        }
        if (One.TF.Treasure_GateDhal_00013 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_13_X, Fix.GATEOFDHAL_Treasure_13_Y, Fix.GATEOFDHAL_Treasure_13_Z))
        {
          treasureName = Fix.FINE_ARMOR;
        }
        if (One.TF.Treasure_GateDhal_00014 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_14_X, Fix.GATEOFDHAL_Treasure_14_Y, Fix.GATEOFDHAL_Treasure_14_Z))
        {
          treasureName = Fix.FINE_CROSS;
        }
        if (One.TF.Treasure_GateDhal_00015 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_15_X, Fix.GATEOFDHAL_Treasure_15_Y, Fix.GATEOFDHAL_Treasure_15_Z))
        {
          treasureName = Fix.FINE_ROBE;
        }
        if (One.TF.Treasure_GateDhal_00016 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_16_X, Fix.GATEOFDHAL_Treasure_16_Y, Fix.GATEOFDHAL_Treasure_16_Z))
        {
          treasureName = Fix.FLAT_SHOES;
        }
        if (One.TF.Treasure_GateDhal_00017 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_17_X, Fix.GATEOFDHAL_Treasure_17_Y, Fix.GATEOFDHAL_Treasure_17_Z))
        {
          treasureName = Fix.COMPACT_EARRING;
        }
        if (One.TF.Treasure_GateDhal_00018 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_18_X, Fix.GATEOFDHAL_Treasure_18_Y, Fix.GATEOFDHAL_Treasure_18_Z))
        {
          treasureName = Fix.POWER_BANDANA;
        }
        if (One.TF.Treasure_GateDhal_00019 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_19_X, Fix.GATEOFDHAL_Treasure_19_Y, Fix.GATEOFDHAL_Treasure_19_Z))
        {
          treasureName = Fix.CHERRY_CHOKER;
        }
        if (One.TF.Treasure_GateDhal_00020 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_20_X, Fix.GATEOFDHAL_Treasure_20_Y, Fix.GATEOFDHAL_Treasure_20_Z))
        {
          treasureName = Fix.BLUE_WIZARD_HAT;
        }
        if (One.TF.Treasure_GateDhal_00021 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_21_X, Fix.GATEOFDHAL_Treasure_21_Y, Fix.GATEOFDHAL_Treasure_21_Z))
        {
          treasureName = Fix.FLAME_HAND_KEEPER;
        }
        if (One.TF.Treasure_GateDhal_00022 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_22_X, Fix.GATEOFDHAL_Treasure_22_Y, Fix.GATEOFDHAL_Treasure_22_Z))
        {
          treasureName = Fix.MUMYOU_BOW;
        }
        if (One.TF.Treasure_GateDhal_00023 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_23_X, Fix.GATEOFDHAL_Treasure_23_Y, Fix.GATEOFDHAL_Treasure_23_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00024 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_24_X, Fix.GATEOFDHAL_Treasure_24_Y, Fix.GATEOFDHAL_Treasure_24_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00024 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_24_X, Fix.GATEOFDHAL_Treasure_24_Y, Fix.GATEOFDHAL_Treasure_24_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00025 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_25_X, Fix.GATEOFDHAL_Treasure_25_Y, Fix.GATEOFDHAL_Treasure_25_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00026 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_26_X, Fix.GATEOFDHAL_Treasure_26_Y, Fix.GATEOFDHAL_Treasure_26_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00027 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_27_X, Fix.GATEOFDHAL_Treasure_27_Y, Fix.GATEOFDHAL_Treasure_27_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00028 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_28_X, Fix.GATEOFDHAL_Treasure_28_Y, Fix.GATEOFDHAL_Treasure_28_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00029 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_29_X, Fix.GATEOFDHAL_Treasure_29_Y, Fix.GATEOFDHAL_Treasure_29_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00030 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_30_X, Fix.GATEOFDHAL_Treasure_30_Y, Fix.GATEOFDHAL_Treasure_30_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00031 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_31_X, Fix.GATEOFDHAL_Treasure_31_Y, Fix.GATEOFDHAL_Treasure_31_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00032 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_32_X, Fix.GATEOFDHAL_Treasure_32_Y, Fix.GATEOFDHAL_Treasure_32_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00033 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_33_X, Fix.GATEOFDHAL_Treasure_33_Y, Fix.GATEOFDHAL_Treasure_33_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00034 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_34_X, Fix.GATEOFDHAL_Treasure_34_Y, Fix.GATEOFDHAL_Treasure_34_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00035 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_35_X, Fix.GATEOFDHAL_Treasure_35_Y, Fix.GATEOFDHAL_Treasure_35_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00036 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_36_X, Fix.GATEOFDHAL_Treasure_36_Y, Fix.GATEOFDHAL_Treasure_36_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00037 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_37_X, Fix.GATEOFDHAL_Treasure_37_Y, Fix.GATEOFDHAL_Treasure_37_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00038 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_38_X, Fix.GATEOFDHAL_Treasure_38_Y, Fix.GATEOFDHAL_Treasure_38_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00039 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_39_X, Fix.GATEOFDHAL_Treasure_39_Y, Fix.GATEOFDHAL_Treasure_39_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00040 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_40_X, Fix.GATEOFDHAL_Treasure_40_Y, Fix.GATEOFDHAL_Treasure_40_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00041 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_41_X, Fix.GATEOFDHAL_Treasure_41_Y, Fix.GATEOFDHAL_Treasure_41_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00042 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_42_X, Fix.GATEOFDHAL_Treasure_42_Y, Fix.GATEOFDHAL_Treasure_42_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00043 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_43_X, Fix.GATEOFDHAL_Treasure_43_Y, Fix.GATEOFDHAL_Treasure_43_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00044 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_44_X, Fix.GATEOFDHAL_Treasure_44_Y, Fix.GATEOFDHAL_Treasure_44_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00045 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_45_X, Fix.GATEOFDHAL_Treasure_45_Y, Fix.GATEOFDHAL_Treasure_45_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00046 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_46_X, Fix.GATEOFDHAL_Treasure_46_Y, Fix.GATEOFDHAL_Treasure_46_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00047 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_47_X, Fix.GATEOFDHAL_Treasure_47_Y, Fix.GATEOFDHAL_Treasure_47_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00048 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_48_X, Fix.GATEOFDHAL_Treasure_48_Y, Fix.GATEOFDHAL_Treasure_48_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00049 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_49_X, Fix.GATEOFDHAL_Treasure_49_Y, Fix.GATEOFDHAL_Treasure_49_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00050 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_50_X, Fix.GATEOFDHAL_Treasure_50_Y, Fix.GATEOFDHAL_Treasure_50_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }
        if (One.TF.Treasure_GateDhal_00051 == false && LocationFieldDetect(fieldObj, Fix.GATEOFDHAL_Treasure_51_X, Fix.GATEOFDHAL_Treasure_51_Y, Fix.GATEOFDHAL_Treasure_51_Z))
        {
          treasureName = Fix.SMALL_RED_POTION;
        }

        if (treasureName == String.Empty)
        {
          // 何もしない
        }
        else
        {
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName); TapOK();
        }
        return;
      }
      #endregion
    }

    // 各種イベント発生チェック。イベント発生時は下記の敵遭遇エンカウントには到達させない。
    bool detectEvent = DetectEvent(tile);
    if (detectEvent) { return; }

    // フィールドダメージ
    DetectDamage(tile);
    bool result = JudgePartyDead();
    if (result)
    {
      this.GameOver = true;
      txtGameOver.text = "ダンジョン攻略に失敗しました・・・最後に出たホームタウンへ帰還します。";
      panelGameOver.SetActive(true);
      return;
    }

    // 敵遭遇エンカウント
    DetectEncount(tile.AreaInfo);

    //mainMessage.text = "";
    //// 通常動作モード
    //if (!this.DungeonViewMode)
    //{
    //  int moveX = 0;
    //  int moveY = 0;

    //  //    // [警告]：開発途中で戦闘終了後、イベント発生後などでキーダウンで効かない場合があった。押下しっぱなしだと進められるように仕様変更となるので、別の不具合が出た場合はまた再検討してください。
    //  //    // [警告]：後編でキーダウン動作仕様を変更した。戦闘エンカウントやメッセージ表示、ホームタウン戻り、壁当たりなど随所にCancelKeyDownMovementを導入して検討中。
    //  //    //keyDown = true;
    //  if (CheckWall(direction))
    //  {
    //    keyDown = false;
    //    keyUp = false;
    //    keyLeft = false;
    //    keyRight = false;
    //    //System.Threading.Thread.Sleep(100);
    //    //debug.text += "check wall end.";
    //    return;
    //  }

    //  if (CheckBlueWall(direction))
    //  {
    //    System.Threading.Thread.Sleep(100);
    //    return;
    //  }

    //  if (direction == 0) moveY = Database.DUNGEON_MOVE_LEN; // change unity
    //  else if (direction == 1) moveX = -Database.DUNGEON_MOVE_LEN;
    //  else if (direction == 2) moveX = Database.DUNGEON_MOVE_LEN;
    //  else if (direction == 3) moveY = -Database.DUNGEON_MOVE_LEN; // change unity

    //  JumpToLocation((int)this.Player.transform.position.x + moveX, (int)this.Player.transform.position.y + moveY, false);

    //  // EPICアイテムEPIC_ORB_GROW_GREENの効果
    //  for (int ii = 0; ii < 3; ii++)
    //  {
    //    MainCharacter player = null;
    //    Image targetLabel = null;
    //    Text targetText = null;
    //    if (ii == 0) { player = GroundOne.MC; targetLabel = currentSkillPoint1; targetText = currentSkillValue1; }
    //    else if (ii == 1) { player = GroundOne.SC; targetLabel = currentSkillPoint2; targetText = currentSkillValue2; }
    //    else if (ii == 2) { player = GroundOne.TC; targetLabel = currentSkillPoint3; targetText = currentSkillValue3; }
    //    if (player != null &&
    //        player.Accessory != null &&
    //        player.Accessory.Name == Database.EPIC_ORB_GROW_GREEN)
    //    {
    //      player.CurrentSkillPoint++;
    //      UpdateSkill(player, targetLabel, targetText);
    //    }
    //    if (player != null &&
    //        player.Accessory2 != null &&
    //        player.Accessory2.Name == Database.EPIC_ORB_GROW_GREEN)
    //    {
    //      player.CurrentSkillPoint++;
    //      UpdateSkill(player, targetLabel, targetText);
    //    }
    //  }

    //  // 移動時のタイル更新
    //  bool lowSpeed = UpdateUnknownTile();

    //  // イベント発生
    //  SearchSomeEvents();

    //  if (lowSpeed)
    //  {
    //    this.MovementInterval = MOVE_INTERVAL;
    //  }
    //  else
    //  {
    //    this.MovementInterval = MOVE_INTERVAL / 2;
    //  }
    //  Method.GetTileNumber(Player.transform.position);
    //}
    //// View動作モード
    //else
    //{
    //  int moveX = 0;
    //  int moveY = 0;

    //  if (direction == 0) moveY = Database.DUNGEON_MOVE_LEN;
    //  else if (direction == 1) moveX = -Database.DUNGEON_MOVE_LEN;
    //  else if (direction == 2) moveX = Database.DUNGEON_MOVE_LEN;
    //  else if (direction == 3) moveY = -Database.DUNGEON_MOVE_LEN;

    //  // 上端ダンジョン外を見せないようにする
    //  // 左端ダンジョン外を見せないようにする
    //  // 右端ダンジョン外を見せないようにする
    //  // 下端ダンジョン外を見せないようにする
    //  if ((direction == 0 && this.viewPoint.y >= Database.CAMERA_BORDER_Y_TOP + Database.CAMERA_WORLD_POINT_Y) ||
    //      (direction == 1 && this.viewPoint.x <= Database.CAMERA_BORDER_X_LEFT + Database.CAMERA_WORLD_POINT_X) ||
    //      (direction == 2 && this.viewPoint.x >= Database.CAMERA_BORDER_X_RIGHT + Database.CAMERA_WORLD_POINT_X) ||
    //      (direction == 3 && this.viewPoint.y <= Database.CAMERA_BORDER_Y_BOTTOM + Database.CAMERA_WORLD_POINT_Y)
    //      )
    //  {
    //    return;
    //  }

    //  UpdateViewPoint(GroundOne.WE.dungeonViewPointX + moveX, GroundOne.WE.dungeonViewPointY + moveY);
    //}
  }
  public void TapOK()
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    if (MarginTimeForCallBattle >= 1) { MarginTimeForCallBattle = 1; }

    for (int ii = 0; ii < Fix.INFINITY; ii++)
    {
      // メッセージが在る場合は、メッセージを進行する。
      if (QuestMessageList.Count > 0)
      {
        MessagePack.ActionEvent currentEvent = QuestEventList[0];
        string currentMessage = QuestMessageList[0];
        RemoveOneSentence();
        GroupQuestMessage.SetActive(true);

        Debug.Log(currentEvent.ToString() + " " + currentMessage);

        // ブラックアウトしている画面から元に戻す。
        if (currentEvent == MessagePack.ActionEvent.ReturnToNormal)
        {
          this.objBlackOut.SetActive(false);
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.TurnToBlack)
        {
          this.objBlackOut.SetActive(true);
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.Fountain)
        {
          EventFountain();
          continue; // 継続
        }
        // 画面を再描画する。
        else if (currentEvent == MessagePack.ActionEvent.RefreshAllView)
        {
          RefreshAllView();
        }
        // 画面にシステムメッセージを表示する。
        else if (currentEvent == MessagePack.ActionEvent.MessageDisplay)
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
          if (currentMessage.Contains(Fix.QUEST_TITLE_1)) { One.TF.QuestMain_00001 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_2)) { One.TF.QuestMain_00002 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_3)) { One.TF.QuestMain_00003 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_4)) { One.TF.QuestMain_00004 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_5)) { One.TF.QuestMain_00005 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_6)) { One.TF.QuestMain_00006 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_7)) { One.TF.QuestMain_00007 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_8)) { One.TF.QuestMain_00008 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_9)) { One.TF.QuestMain_00009 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_10)) { One.TF.QuestMain_00010 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_11)) { One.TF.QuestMain_00011 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_20)) { One.TF.QuestMain_00020 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_21)) { One.TF.QuestMain_00021 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_22)) { One.TF.QuestMain_00022 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_23)) { One.TF.QuestMain_00023 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_24)) { One.TF.QuestMain_00024 = true; }
          RefreshQuestList();
          return;
        }
        // 画面にクエスト更新メッセージを表示する。
        else if (currentEvent == MessagePack.ActionEvent.QuestUpdate)
        {
          this.txtSystemMessage.text = currentMessage;
          this.panelSystemMessage.SetActive(true);

          RefreshQuestList();
          return;
        }
        // 画面にクエスト完了メッセージを表示する。
        else if (currentEvent == MessagePack.ActionEvent.QuestComplete)
        {
          this.txtSystemMessage.text = currentMessage;
          this.panelSystemMessage.SetActive(true);

          // todo
          if (currentMessage.Contains(Fix.QUEST_TITLE_1)) { One.TF.QuestMain_Complete_00001 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_2)) { One.TF.QuestMain_Complete_00002 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_3)) { One.TF.QuestMain_Complete_00003 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_4)) { One.TF.QuestMain_Complete_00004 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_5)) { One.TF.QuestMain_Complete_00005 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_6)) { One.TF.QuestMain_Complete_00006 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_7)) { One.TF.QuestMain_Complete_00007 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_8)) { One.TF.QuestMain_Complete_00008 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_9)) { One.TF.QuestMain_Complete_00009 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_10)) { One.TF.QuestMain_Complete_00010 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_11)) { One.TF.QuestMain_Complete_00011 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_20)) { One.TF.QuestMain_Complete_00020 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_21)) { One.TF.QuestMain_Complete_00021 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_22)) { One.TF.QuestMain_Complete_00022 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_23)) { One.TF.QuestMain_Complete_00023 = true; }
          if (currentMessage.Contains(Fix.QUEST_TITLE_24)) { One.TF.QuestMain_Complete_00024 = true; }
          RefreshQuestList();
          return;
        }
        // 下階層に降りる
        else if (currentEvent == MessagePack.ActionEvent.DungeonGotoDownstair)
        {
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
          {
            this.DungeonMap = Fix.MAPFILE_GORATRUM_2;
            this.DungeonCall = Fix.DUNGEON_GORATRUM_CAVE;
            if (currentMessage == "1")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_1_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_1_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_1_Z;
              continue; // 継続
            }
            if (currentMessage == "2")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_2_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_2_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_2_Z;
              continue; // 継続
            }
            if (currentMessage == "3")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_3_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_3_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_3_Z;
              continue; // 継続
            }
            if (currentMessage == "4")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_4_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_4_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_4_Z;
              continue; // 継続
            }
            if (currentMessage == "5")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_5_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_5_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_5_Z;
              continue; // 継続
            }
            if (currentMessage == "6")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_6_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_6_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_6_Z;
              continue; // 継続
            }
            if (currentMessage == "7")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_7_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_7_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_7_Z;
              continue; // 継続
            }
            if (currentMessage == "8")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_8_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_8_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_8_Z;
              continue; // 継続
            }
            if (currentMessage == "9")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_9_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_9_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_9_Z;
              continue; // 継続
            }
            if (currentMessage == "10")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_10_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_10_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_10_Z;
              continue; // 継続
            }
            if (currentMessage == "11")
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_11_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_11_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_11_Z;
              continue; // 継続
            }
            if (currentMessage == "12")
            {
              One.GoratrumHoleFalling2 = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_12_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_12_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_12_Z;
              continue; // 継続
            }
            if (currentMessage == "13")
            {
              One.GoratrumHoleFalling2 = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_13_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_13_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_13_Z;
              continue; // 継続
            }
            if (currentMessage == "14")
            {
              One.GoratrumHoleFalling2 = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_14_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_14_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_14_Z;
              continue; // 継続
            }
            if (currentMessage == "15")
            {
              One.GoratrumHoleFalling3 = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_15_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_15_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_15_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_16_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_16_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_16_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_16_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_17_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_17_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_17_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_17_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_18_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_18_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_18_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_18_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_19_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_19_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_19_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_19_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_20_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_20_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_20_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_20_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_21_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_21_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_21_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_21_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_22_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_22_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_22_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_22_Z;
              continue; // 継続
            }

            if (currentMessage == Fix.GORATRUM_Hole_23_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_23_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_23_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_23_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_24_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_24_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_24_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_24_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_25_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_25_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_25_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_25_Z;
              continue; // 継続
            }

            if (currentMessage == Fix.GORATRUM_Hole_26_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_26_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_26_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_26_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_27_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_27_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_27_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_27_Z;
              continue; // 継続
            }
            if (currentMessage == Fix.GORATRUM_Hole_28_O)
            {
              One.GoratrumHoleFalling = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_28_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_28_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_28_Z;
              continue; // 継続
            }

            if (currentMessage == Fix.GORATRUM_Hole_29_O)
            {
              One.GoratrumHoleFalling2 = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_29_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_29_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_29_Z;
              continue; // 継続
            }

            if (currentMessage == Fix.GORATRUM_Hole_30_O)
            {
              One.GoratrumHoleFalling2 = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_30_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_30_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_30_Z;
              continue; // 継続
            }

            if (currentMessage == Fix.GORATRUM_Hole_31_O)
            {
              One.GoratrumHoleFalling2 = true;
              One.TF.Field_X = Fix.GORATRUM_Hole_31_X;
              One.TF.Field_Y = Fix.GORATRUM_Hole_31_Y + 1.5f; // 1;
              One.TF.Field_Z = Fix.GORATRUM_Hole_31_Z;
              continue; // 継続
            }
          }
        }
        // 未到達タイルを更新する。
        else if (currentEvent == MessagePack.ActionEvent.UpdateUnknownTile)
        {
          // ダンジョン毎に特定領域を可視化
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN && currentMessage == "1")
          {
            //List<int> numbers = new List<int>() { 408, 409, 410, 411, 412, 448, 449, 450, 451, 452, 488, 489, 490, 491, 492, 528, 529, 530, 531, 532, 568, 569, 570, 571, 572 };
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 3; jj++)
            {
              for (int kk = 0; kk < 3; kk++)
              {
                numbers.Add(117 + jj * 40 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_CaveOfSarun[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN && currentMessage == "2")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 7; jj++)
            {
              for (int kk = 0; kk < 6; kk++)
              {
                numbers.Add(32 + jj * 40 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_CaveOfSarun[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN && currentMessage == "3")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 7; jj++)
            {
              for (int kk = 0; kk < 5; kk++)
              {
                numbers.Add(132 + jj * 40 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_CaveOfSarun[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN && currentMessage == "10")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 5; jj++)
            {
              for (int kk = 0; kk < 5; kk++)
              {
                numbers.Add(562 + jj * 40 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_CaveOfSarun[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM && currentMessage == Fix.GORATRUM_Event_1_O)
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 4; jj++)
            {
              for (int kk = 0; kk < 3; kk++)
              {
                numbers.Add(3 * 40 + 7 + jj * 40 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_Goratrum[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM && currentMessage == "2")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 4; jj++)
            {
              for (int kk = 0; kk < 5; kk++)
              {
                numbers.Add(13 * 40 + 5 + jj * 40 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_Goratrum[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2 && currentMessage == Fix.GORATRUM_2_Event_1_O)
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 8; jj++)
            {
              for (int kk = 0; kk < 7; kk++)
              {
                numbers.Add(0 * 40 + 17 + jj * 40 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_Goratrum_2[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2 && currentMessage == Fix.GORATRUM_2_Event_2_O)
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 7; jj++)
            {
              for (int kk = 0; kk < 6; kk++)
              {
                numbers.Add(5 * 40 + 2 + jj * 40 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_Goratrum_2[numbers[jj]] = true;
            }
          }
        }
        // マップ上を自動移動（左）
        else if (currentEvent == MessagePack.ActionEvent.MoveLeft)
        {
          TileInformation tile = SearchNextTile(this.Player.transform.position, Direction.Left);
          JumpToLocation(new Vector3(tile.transform.position.x,
                                     tile.transform.position.y + 1.0f,
                                     tile.transform.position.z));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        // マップ上を自動移動（右）
        else if (currentEvent == MessagePack.ActionEvent.MoveRight)
        {
          TileInformation tile = SearchNextTile(this.Player.transform.position, Direction.Right);
          JumpToLocation(new Vector3(tile.transform.position.x,
                                     tile.transform.position.y + 1.0f,
                                     tile.transform.position.z));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        // マップ上を自動移動（上）
        else if (currentEvent == MessagePack.ActionEvent.MoveTop)
        {
          TileInformation tile = SearchNextTile(this.Player.transform.position, Direction.Top);
          JumpToLocation(new Vector3(tile.transform.position.x,
                                     tile.transform.position.y + 1.0f,
                                     tile.transform.position.z));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        // マップ上を自動移動（下）
        else if (currentEvent == MessagePack.ActionEvent.MoveBottom)
        {
          TileInformation tile = SearchNextTile(this.Player.transform.position, Direction.Bottom);
          JumpToLocation(new Vector3(tile.transform.position.x,
                                     tile.transform.position.y + 1.0f,
                                     tile.transform.position.z));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        // マップ上を自動移動（強制移動：右）
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveRight)
        {
          JumpToLocation(new Vector3(this.Player.transform.position.x + 1.0f,
                                     this.Player.transform.position.y,
                                     this.Player.transform.position.z));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        // マップ上を自動移動（強制移動：左）
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveLeft)
        {
          JumpToLocation(new Vector3(this.Player.transform.position.x - 1.0f,
                                     this.Player.transform.position.y,
                                     this.Player.transform.position.z));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        // マップ上を自動移動（強制移動：上）
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveTop)
        {
          JumpToLocation(new Vector3(this.Player.transform.position.x,
                                     this.Player.transform.position.y,
                                     this.Player.transform.position.z + 1.0f));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        // マップ上を自動移動（強制移動：下）
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveBottom)
        {
          JumpToLocation(new Vector3(this.Player.transform.position.x,
                                     this.Player.transform.position.y,
                                     this.Player.transform.position.z - 1.0f));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        // マップ上を自動移動（強制移動：上昇）
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveRise)
        {
          JumpToLocation(new Vector3(this.Player.transform.position.x,
                                     this.Player.transform.position.y + 1.0f,
                                     this.Player.transform.position.z));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        // マップ上を自動移動（強制移動：下降）
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveFall)
        {
          JumpToLocation(new Vector3(this.Player.transform.position.x,
                                     this.Player.transform.position.y - 1.0f,
                                     this.Player.transform.position.z));
          UpdateUnknownTile(Player.transform.position);
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveObjTop)
        {
          if (this.CurrentEventObject != null)
          {
            this.CurrentEventObject.transform.position = new Vector3(this.CurrentEventObject.transform.position.x,
                                                                     this.CurrentEventObject.transform.position.y,
                                                                     this.CurrentEventObject.transform.position.z + 1.0f);
          }
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveObjBottom)
        {
          if (this.CurrentEventObject != null)
          {
            this.CurrentEventObject.transform.position = new Vector3(this.CurrentEventObject.transform.position.x,
                                                                     this.CurrentEventObject.transform.position.y,
                                                                     this.CurrentEventObject.transform.position.z - 1.0f);
          }
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveObjLeft)
        {
          if (this.CurrentEventObject != null)
          {
            this.CurrentEventObject.transform.position = new Vector3(this.CurrentEventObject.transform.position.x - 1.0f,
                                                                     this.CurrentEventObject.transform.position.y,
                                                                     this.CurrentEventObject.transform.position.z);
          }
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveObjRight)
        {
          if (this.CurrentEventObject != null)
          {
            this.CurrentEventObject.transform.position = new Vector3(this.CurrentEventObject.transform.position.x + 1.0f,
                                                                     this.CurrentEventObject.transform.position.y,
                                                                     this.CurrentEventObject.transform.position.z);
          }
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveObjRise)
        {
          if (this.CurrentEventObject != null)
          {
            this.CurrentEventObject.transform.position = new Vector3(this.CurrentEventObject.transform.position.x,
                                                                     this.CurrentEventObject.transform.position.y + 1.0f,
                                                                     this.CurrentEventObject.transform.position.z);
          }
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveObjFall)
        {
          if (this.CurrentEventObject != null)
          {
            this.CurrentEventObject.transform.position = new Vector3(this.CurrentEventObject.transform.position.x,
                                                                     this.CurrentEventObject.transform.position.y - 1.0f,
                                                                     this.CurrentEventObject.transform.position.z);
          }
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.HidePlayer)
        {
          this.Player.SetActive(false);
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.VisiblePlayer)
        {
          this.Player.SetActive(true);
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.GetItem)
        {
          One.TF.AddBackPack(new Item(currentMessage));
          ParentBackpackView.ConstructBackpackView();
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.Fountain)
        {
          EventFountain();
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.GetTreasure)
        {
          Debug.Log("GetTreasure 1");
          FieldObject fieldObj = SearchObject(this.Player.transform.position);
          Vector3 location = fieldObj.transform.position;
          int number = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);
          ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, number);
          Debug.Log("GetTreasure 2");

          this.txtSystemMessage.text = "【 " + currentMessage + " 】を手に入れました！";
          this.panelSystemMessage.SetActive(true);
          Debug.Log("GetTreasure 3");

          One.TF.AddBackPack(new Item(currentMessage));
          ParentBackpackView.ConstructBackpackView();

          #region "サルンの洞窟前"
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
          {
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_1_X, Fix.CAVEOFSARUN_Treasure_1_Y, Fix.CAVEOFSARUN_Treasure_1_Z))
            {
              One.TF.Treasure_CaveOfSarun_00001 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_2_X, Fix.CAVEOFSARUN_Treasure_2_Y, Fix.CAVEOFSARUN_Treasure_2_Z))
            {
              One.TF.Treasure_CaveOfSarun_00002 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_3_X, Fix.CAVEOFSARUN_Treasure_3_Y, Fix.CAVEOFSARUN_Treasure_3_Z))
            {
              One.TF.Treasure_CaveOfSarun_00003 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_4_X, Fix.CAVEOFSARUN_Treasure_4_Y, Fix.CAVEOFSARUN_Treasure_4_Z))
            {
              One.TF.Treasure_CaveOfSarun_00004 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_5_X, Fix.CAVEOFSARUN_Treasure_5_Y, Fix.CAVEOFSARUN_Treasure_5_Z))
            {
              One.TF.Treasure_CaveOfSarun_00005 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_6_X, Fix.CAVEOFSARUN_Treasure_6_Y, Fix.CAVEOFSARUN_Treasure_6_Z))
            {
              One.TF.Treasure_CaveOfSarun_00006 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_7_X, Fix.CAVEOFSARUN_Treasure_7_Y, Fix.CAVEOFSARUN_Treasure_7_Z))
            {
              One.TF.Treasure_CaveOfSarun_00007 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_8_X, Fix.CAVEOFSARUN_Treasure_8_Y, Fix.CAVEOFSARUN_Treasure_8_Z))
            {
              One.TF.Treasure_CaveOfSarun_00008 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_9_X, Fix.CAVEOFSARUN_Treasure_9_Y, Fix.CAVEOFSARUN_Treasure_9_Z))
            {
              One.TF.Treasure_CaveOfSarun_00009 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.CAVEOFSARUN_Treasure_10_X, Fix.CAVEOFSARUN_Treasure_10_Y, Fix.CAVEOFSARUN_Treasure_10_Z))
            {
              One.TF.Treasure_CaveOfSarun_00010 = true;
            }
          }
          #endregion
          #region "ゴラトラム洞窟"
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
          {
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_1_X, Fix.GORATRUM_Treasure_1_Y, Fix.GORATRUM_Treasure_1_Z))
            {
              One.TF.Treasure_Goratrum_00001 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_2_X, Fix.GORATRUM_Treasure_2_Y, Fix.GORATRUM_Treasure_2_Z))
            {
              One.TF.Treasure_Goratrum_00002 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_3_X, Fix.GORATRUM_Treasure_3_Y, Fix.GORATRUM_Treasure_3_Z))
            {
              One.TF.Treasure_Goratrum_00003 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_4_X, Fix.GORATRUM_Treasure_4_Y, Fix.GORATRUM_Treasure_4_Z))
            {
              One.TF.Treasure_Goratrum_00004 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_5_X, Fix.GORATRUM_Treasure_5_Y, Fix.GORATRUM_Treasure_5_Z))
            {
              One.TF.Treasure_Goratrum_00005 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_6_X, Fix.GORATRUM_Treasure_6_Y, Fix.GORATRUM_Treasure_6_Z))
            {
              One.TF.Treasure_Goratrum_00006 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_7_X, Fix.GORATRUM_Treasure_7_Y, Fix.GORATRUM_Treasure_7_Z))
            {
              One.TF.Treasure_Goratrum_00007 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_8_X, Fix.GORATRUM_Treasure_8_Y, Fix.GORATRUM_Treasure_8_Z))
            {
              One.TF.Treasure_Goratrum_00008 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_9_X, Fix.GORATRUM_Treasure_9_Y, Fix.GORATRUM_Treasure_9_Z))
            {
              One.TF.Treasure_Goratrum_00009 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_10_X, Fix.GORATRUM_Treasure_10_Y, Fix.GORATRUM_Treasure_10_Z))
            {
              One.TF.Treasure_Goratrum_00010 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_Treasure_11_X, Fix.GORATRUM_Treasure_11_Y, Fix.GORATRUM_Treasure_11_Z))
            {
              One.TF.Treasure_Goratrum_00011 = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
          {
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_2_Treasure_1_X, Fix.GORATRUM_2_Treasure_1_Y, Fix.GORATRUM_2_Treasure_1_Z))
            {
              One.TF.Treasure_Goratrum2_00001 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_2_Treasure_2_X, Fix.GORATRUM_2_Treasure_2_Y, Fix.GORATRUM_2_Treasure_2_Z))
            {
              One.TF.Treasure_Goratrum2_00002 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_2_Treasure_3_X, Fix.GORATRUM_2_Treasure_3_Y, Fix.GORATRUM_2_Treasure_3_Z))
            {
              One.TF.Treasure_Goratrum2_00003 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GORATRUM_2_Treasure_4_X, Fix.GORATRUM_2_Treasure_4_Y, Fix.GORATRUM_2_Treasure_4_Z))
            {
              One.TF.Treasure_Goratrum2_00004 = true;
            }
          }
          #endregion
          #region "アーサリウム工場跡地"
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
          {
            // 宝箱１
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_2_X, Fix.ARTHARIUM_Treasure_2_Y, Fix.ARTHARIUM_Treasure_2_Z))
            {
              One.TF.Treasure_Artharium_00001 = true;
            }
            // 宝箱２
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_8_X, Fix.ARTHARIUM_Treasure_8_Y, Fix.ARTHARIUM_Treasure_8_Z))
            {
              One.TF.Treasure_Artharium_00002 = true;
            }
            // 宝箱３
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_9_X, Fix.ARTHARIUM_Treasure_9_Y, Fix.ARTHARIUM_Treasure_9_Z))
            {
              One.TF.Treasure_Artharium_00003 = true;
            }
            // 宝箱４
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_10_X, Fix.ARTHARIUM_Treasure_10_Y, Fix.ARTHARIUM_Treasure_10_Z))
            {
              One.TF.Treasure_Artharium_00004 = true;
            }
            // 宝箱５
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_11_X, Fix.ARTHARIUM_Treasure_11_Y, Fix.ARTHARIUM_Treasure_11_Z))
            {
              One.TF.Treasure_Artharium_00005 = true;
            }
            // 宝箱６
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_12_X, Fix.ARTHARIUM_Treasure_12_Y, Fix.ARTHARIUM_Treasure_12_Z))
            {
              One.TF.Treasure_Artharium_00006 = true;
            }
            // 宝箱７
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_13_X, Fix.ARTHARIUM_Treasure_13_Y, Fix.ARTHARIUM_Treasure_13_Z))
            {
              One.TF.Treasure_Artharium_00007 = true;
            }
            // 宝箱８
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_14_X, Fix.ARTHARIUM_Treasure_14_Y, Fix.ARTHARIUM_Treasure_14_Z))
            {
              One.TF.Treasure_Artharium_00008 = true;
            }
            // 宝箱９
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_3_X, Fix.ARTHARIUM_Treasure_3_Y, Fix.ARTHARIUM_Treasure_3_Z))
            {
              One.TF.Treasure_Artharium_00009 = true;
            }
            // 宝箱１０
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_15_X, Fix.ARTHARIUM_Treasure_15_Y, Fix.ARTHARIUM_Treasure_15_Z))
            {
              One.TF.Treasure_Artharium_00010 = true;
            }
            // 宝箱１１
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_16_X, Fix.ARTHARIUM_Treasure_16_Y, Fix.ARTHARIUM_Treasure_16_Z))
            {
              One.TF.Treasure_Artharium_00011 = true;
            }
            // 宝箱１２
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_17_X, Fix.ARTHARIUM_Treasure_17_Y, Fix.ARTHARIUM_Treasure_17_Z))
            {
              One.TF.Treasure_Artharium_00012 = true;
            }
            // 宝箱１３
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_18_X, Fix.ARTHARIUM_Treasure_18_Y, Fix.ARTHARIUM_Treasure_18_Z))
            {
              One.TF.Treasure_Artharium_00013 = true;
            }
            // 宝箱１４
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_19_X, Fix.ARTHARIUM_Treasure_19_Y, Fix.ARTHARIUM_Treasure_19_Z))
            {
              One.TF.Treasure_Artharium_00014 = true;
            }
            // 宝箱１５
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_20_X, Fix.ARTHARIUM_Treasure_20_Y, Fix.ARTHARIUM_Treasure_20_Z))
            {
              One.TF.Treasure_Artharium_00015 = true;
            }
            // 宝箱１６
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_21_X, Fix.ARTHARIUM_Treasure_21_Y, Fix.ARTHARIUM_Treasure_21_Z))
            {
              One.TF.Treasure_Artharium_00016 = true;
            }
            // 宝箱１７
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_22_X, Fix.ARTHARIUM_Treasure_22_Y, Fix.ARTHARIUM_Treasure_22_Z))
            {
              One.TF.Treasure_Artharium_00017 = true;
            }
            // 宝箱１８
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_23_X, Fix.ARTHARIUM_Treasure_23_Y, Fix.ARTHARIUM_Treasure_23_Z))
            {
              One.TF.Treasure_Artharium_00018 = true;
            }
            // 宝箱１９
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_24_X, Fix.ARTHARIUM_Treasure_24_Y, Fix.ARTHARIUM_Treasure_24_Z))
            {
              One.TF.Treasure_Artharium_00019 = true;
            }
            // 宝箱２０
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_25_X, Fix.ARTHARIUM_Treasure_25_Y, Fix.ARTHARIUM_Treasure_25_Z))
            {
              One.TF.Treasure_Artharium_00020 = true;
            }
            // 宝箱２１
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_26_X, Fix.ARTHARIUM_Treasure_26_Y, Fix.ARTHARIUM_Treasure_26_Z))
            {
              One.TF.Treasure_Artharium_00021 = true;
            }
            // 宝箱２２
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_27_X, Fix.ARTHARIUM_Treasure_27_Y, Fix.ARTHARIUM_Treasure_27_Z))
            {
              One.TF.Treasure_Artharium_00022 = true;
            }
            // 宝箱２３
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_6_X, Fix.ARTHARIUM_Treasure_6_Y, Fix.ARTHARIUM_Treasure_6_Z))
            {
              One.TF.Treasure_Artharium_00023 = true;
            }
            // 宝箱２４
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_5_X, Fix.ARTHARIUM_Treasure_5_Y, Fix.ARTHARIUM_Treasure_5_Z))
            {
              One.TF.Treasure_Artharium_00024 = true;
            }
            // 宝箱２５
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_7_X, Fix.ARTHARIUM_Treasure_7_Y, Fix.ARTHARIUM_Treasure_7_Z))
            {
              One.TF.Treasure_Artharium_00025 = true;
            }
          }
          #endregion
          #region "オーランの塔"
          else if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
          {
            // 宝箱１
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_1_X, Fix.OHRANTOWER_Treasure_1_Y, Fix.OHRANTOWER_Treasure_1_Z))
            {
              One.TF.Treasure_OhranTower_00001 = true;
            }
            // 宝箱２
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_2_X, Fix.OHRANTOWER_Treasure_2_Y, Fix.OHRANTOWER_Treasure_2_Z))
            {
              One.TF.Treasure_OhranTower_00002 = true;
            }
            // 宝箱３
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_3_X, Fix.OHRANTOWER_Treasure_3_Y, Fix.OHRANTOWER_Treasure_3_Z))
            {
              One.TF.Treasure_OhranTower_00003 = true;
            }
            // 宝箱４
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_4_X, Fix.OHRANTOWER_Treasure_4_Y, Fix.OHRANTOWER_Treasure_4_Z))
            {
              One.TF.Treasure_OhranTower_00004 = true;
            }
            // 宝箱５
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_5_X, Fix.OHRANTOWER_Treasure_5_Y, Fix.OHRANTOWER_Treasure_5_Z))
            {
              One.TF.Treasure_OhranTower_00005 = true;
            }
            // 宝箱６
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_6_X, Fix.OHRANTOWER_Treasure_6_Y, Fix.OHRANTOWER_Treasure_6_Z))
            {
              One.TF.Treasure_OhranTower_00006 = true;
            }
            // 宝箱７
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_7_X, Fix.OHRANTOWER_Treasure_7_Y, Fix.OHRANTOWER_Treasure_7_Z))
            {
              One.TF.Treasure_OhranTower_00007 = true;
            }
            // 宝箱８
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_8_X, Fix.OHRANTOWER_Treasure_8_Y, Fix.OHRANTOWER_Treasure_8_Z))
            {
              One.TF.Treasure_OhranTower_00008 = true;
            }
            // 宝箱９
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_9_X, Fix.OHRANTOWER_Treasure_9_Y, Fix.OHRANTOWER_Treasure_9_Z))
            {
              One.TF.Treasure_OhranTower_00009 = true;
            }
            // 宝箱１０
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_10_X, Fix.OHRANTOWER_Treasure_10_Y, Fix.OHRANTOWER_Treasure_10_Z))
            {
              One.TF.Treasure_OhranTower_00010 = true;
            }
            // 宝箱１１
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_11_X, Fix.OHRANTOWER_Treasure_11_Y, Fix.OHRANTOWER_Treasure_11_Z))
            {
              One.TF.Treasure_OhranTower_00011 = true;
            }
            // 宝箱１２
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_12_X, Fix.OHRANTOWER_Treasure_12_Y, Fix.OHRANTOWER_Treasure_12_Z))
            {
              One.TF.Treasure_OhranTower_00012 = true;
            }
            // 宝箱１３
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_13_X, Fix.OHRANTOWER_Treasure_13_Y, Fix.OHRANTOWER_Treasure_13_Z))
            {
              One.TF.Treasure_OhranTower_00013 = true;
            }
            // 宝箱１４
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_14_X, Fix.OHRANTOWER_Treasure_14_Y, Fix.OHRANTOWER_Treasure_14_Z))
            {
              One.TF.Treasure_OhranTower_00014 = true;
            }
            // 宝箱１５
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_15_X, Fix.OHRANTOWER_Treasure_15_Y, Fix.OHRANTOWER_Treasure_15_Z))
            {
              One.TF.Treasure_OhranTower_00015 = true;
            }
            // 宝箱１６
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_16_X, Fix.OHRANTOWER_Treasure_16_Y, Fix.OHRANTOWER_Treasure_16_Z))
            {
              One.TF.Treasure_OhranTower_00016 = true;
            }
            // 宝箱１７
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_17_X, Fix.OHRANTOWER_Treasure_17_Y, Fix.OHRANTOWER_Treasure_17_Z))
            {
              One.TF.Treasure_OhranTower_00017 = true;
            }
            // 宝箱１８
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_18_X, Fix.OHRANTOWER_Treasure_18_Y, Fix.OHRANTOWER_Treasure_18_Z))
            {
              One.TF.Treasure_OhranTower_00018 = true;
            }
            // 宝箱１９
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_19_X, Fix.OHRANTOWER_Treasure_19_Y, Fix.OHRANTOWER_Treasure_19_Z))
            {
              One.TF.Treasure_OhranTower_00019 = true;
            }
            // 宝箱２０
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_20_X, Fix.OHRANTOWER_Treasure_20_Y, Fix.OHRANTOWER_Treasure_20_Z))
            {
              One.TF.Treasure_OhranTower_00020 = true;
            }
            // 宝箱２１
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_21_X, Fix.OHRANTOWER_Treasure_21_Y, Fix.OHRANTOWER_Treasure_21_Z))
            {
              One.TF.Treasure_OhranTower_00021 = true;
            }
            // 宝箱２２
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_22_X, Fix.OHRANTOWER_Treasure_22_Y, Fix.OHRANTOWER_Treasure_22_Z))
            {
              One.TF.Treasure_OhranTower_00022 = true;
            }
            // 宝箱２３
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_23_X, Fix.OHRANTOWER_Treasure_23_Y, Fix.OHRANTOWER_Treasure_23_Z))
            {
              One.TF.Treasure_OhranTower_00023 = true;
            }
          }
          #endregion
          #region "ダルの門"
          else if (One.TF.CurrentDungeonField == Fix.MAPFILE_GATE_OF_DHAL)
          {
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_1_X, Fix.GATEOFDHAL_Treasure_1_Y, Fix.GATEOFDHAL_Treasure_1_Z))
            {
              One.TF.Treasure_GateDhal_00001 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_2_X, Fix.GATEOFDHAL_Treasure_2_Y, Fix.GATEOFDHAL_Treasure_2_Z))
            {
              One.TF.Treasure_GateDhal_00002 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_3_X, Fix.GATEOFDHAL_Treasure_3_Y, Fix.GATEOFDHAL_Treasure_3_Z))
            {
              One.TF.Treasure_GateDhal_00003 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_4_X, Fix.GATEOFDHAL_Treasure_4_Y, Fix.GATEOFDHAL_Treasure_4_Z))
            {
              One.TF.Treasure_GateDhal_00004 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_5_X, Fix.GATEOFDHAL_Treasure_5_Y, Fix.GATEOFDHAL_Treasure_5_Z))
            {
              One.TF.Treasure_GateDhal_00005 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_6_X, Fix.GATEOFDHAL_Treasure_6_Y, Fix.GATEOFDHAL_Treasure_6_Z))
            {
              One.TF.Treasure_GateDhal_00006 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_7_X, Fix.GATEOFDHAL_Treasure_7_Y, Fix.GATEOFDHAL_Treasure_7_Z))
            {
              One.TF.Treasure_GateDhal_00007 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_8_X, Fix.GATEOFDHAL_Treasure_8_Y, Fix.GATEOFDHAL_Treasure_8_Z))
            {
              One.TF.Treasure_GateDhal_00008 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_9_X, Fix.GATEOFDHAL_Treasure_9_Y, Fix.GATEOFDHAL_Treasure_9_Z))
            {
              One.TF.Treasure_GateDhal_00009 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_10_X, Fix.GATEOFDHAL_Treasure_10_Y, Fix.GATEOFDHAL_Treasure_10_Z))
            {
              One.TF.Treasure_GateDhal_00010 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_11_X, Fix.GATEOFDHAL_Treasure_11_Y, Fix.GATEOFDHAL_Treasure_11_Z))
            {
              One.TF.Treasure_GateDhal_00011 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_12_X, Fix.GATEOFDHAL_Treasure_12_Y, Fix.GATEOFDHAL_Treasure_12_Z))
            {
              One.TF.Treasure_GateDhal_00012 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_13_X, Fix.GATEOFDHAL_Treasure_13_Y, Fix.GATEOFDHAL_Treasure_13_Z))
            {
              One.TF.Treasure_GateDhal_00013 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_14_X, Fix.GATEOFDHAL_Treasure_14_Y, Fix.GATEOFDHAL_Treasure_14_Z))
            {
              One.TF.Treasure_GateDhal_00014 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_15_X, Fix.GATEOFDHAL_Treasure_15_Y, Fix.GATEOFDHAL_Treasure_15_Z))
            {
              One.TF.Treasure_GateDhal_00015 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_16_X, Fix.GATEOFDHAL_Treasure_16_Y, Fix.GATEOFDHAL_Treasure_16_Z))
            {
              One.TF.Treasure_GateDhal_00016 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_17_X, Fix.GATEOFDHAL_Treasure_17_Y, Fix.GATEOFDHAL_Treasure_17_Z))
            {
              One.TF.Treasure_GateDhal_00017 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_18_X, Fix.GATEOFDHAL_Treasure_18_Y, Fix.GATEOFDHAL_Treasure_18_Z))
            {
              One.TF.Treasure_GateDhal_00018 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_19_X, Fix.GATEOFDHAL_Treasure_19_Y, Fix.GATEOFDHAL_Treasure_19_Z))
            {
              One.TF.Treasure_GateDhal_00019 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_20_X, Fix.GATEOFDHAL_Treasure_20_Y, Fix.GATEOFDHAL_Treasure_20_Z))
            {
              One.TF.Treasure_GateDhal_00020 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_21_X, Fix.GATEOFDHAL_Treasure_21_Y, Fix.GATEOFDHAL_Treasure_21_Z))
            {
              One.TF.Treasure_GateDhal_00021 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_22_X, Fix.GATEOFDHAL_Treasure_22_Y, Fix.GATEOFDHAL_Treasure_22_Z))
            {
              One.TF.Treasure_GateDhal_00022 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_23_X, Fix.GATEOFDHAL_Treasure_23_Y, Fix.GATEOFDHAL_Treasure_23_Z))
            {
              One.TF.Treasure_GateDhal_00023 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_24_X, Fix.GATEOFDHAL_Treasure_24_Y, Fix.GATEOFDHAL_Treasure_24_Z))
            {
              One.TF.Treasure_GateDhal_00024 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_25_X, Fix.GATEOFDHAL_Treasure_25_Y, Fix.GATEOFDHAL_Treasure_25_Z))
            {
              One.TF.Treasure_GateDhal_00025 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_26_X, Fix.GATEOFDHAL_Treasure_26_Y, Fix.GATEOFDHAL_Treasure_26_Z))
            {
              One.TF.Treasure_GateDhal_00026 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_27_X, Fix.GATEOFDHAL_Treasure_27_Y, Fix.GATEOFDHAL_Treasure_27_Z))
            {
              One.TF.Treasure_GateDhal_00027 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_28_X, Fix.GATEOFDHAL_Treasure_28_Y, Fix.GATEOFDHAL_Treasure_28_Z))
            {
              One.TF.Treasure_GateDhal_00028 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_29_X, Fix.GATEOFDHAL_Treasure_29_Y, Fix.GATEOFDHAL_Treasure_29_Z))
            {
              One.TF.Treasure_GateDhal_00029 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_30_X, Fix.GATEOFDHAL_Treasure_30_Y, Fix.GATEOFDHAL_Treasure_30_Z))
            {
              One.TF.Treasure_GateDhal_00030 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_31_X, Fix.GATEOFDHAL_Treasure_31_Y, Fix.GATEOFDHAL_Treasure_31_Z))
            {
              One.TF.Treasure_GateDhal_00031 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_32_X, Fix.GATEOFDHAL_Treasure_32_Y, Fix.GATEOFDHAL_Treasure_32_Z))
            {
              One.TF.Treasure_GateDhal_00032 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_33_X, Fix.GATEOFDHAL_Treasure_33_Y, Fix.GATEOFDHAL_Treasure_33_Z))
            {
              One.TF.Treasure_GateDhal_00033 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_34_X, Fix.GATEOFDHAL_Treasure_34_Y, Fix.GATEOFDHAL_Treasure_34_Z))
            {
              One.TF.Treasure_GateDhal_00034 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_35_X, Fix.GATEOFDHAL_Treasure_35_Y, Fix.GATEOFDHAL_Treasure_35_Z))
            {
              One.TF.Treasure_GateDhal_00035 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_36_X, Fix.GATEOFDHAL_Treasure_36_Y, Fix.GATEOFDHAL_Treasure_36_Z))
            {
              One.TF.Treasure_GateDhal_00036 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_37_X, Fix.GATEOFDHAL_Treasure_37_Y, Fix.GATEOFDHAL_Treasure_37_Z))
            {
              One.TF.Treasure_GateDhal_00037 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_38_X, Fix.GATEOFDHAL_Treasure_38_Y, Fix.GATEOFDHAL_Treasure_38_Z))
            {
              One.TF.Treasure_GateDhal_00038 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_39_X, Fix.GATEOFDHAL_Treasure_39_Y, Fix.GATEOFDHAL_Treasure_39_Z))
            {
              One.TF.Treasure_GateDhal_00039 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_40_X, Fix.GATEOFDHAL_Treasure_40_Y, Fix.GATEOFDHAL_Treasure_40_Z))
            {
              One.TF.Treasure_GateDhal_00040 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_41_X, Fix.GATEOFDHAL_Treasure_41_Y, Fix.GATEOFDHAL_Treasure_41_Z))
            {
              One.TF.Treasure_GateDhal_00041 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_42_X, Fix.GATEOFDHAL_Treasure_42_Y, Fix.GATEOFDHAL_Treasure_42_Z))
            {
              One.TF.Treasure_GateDhal_00042 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_43_X, Fix.GATEOFDHAL_Treasure_43_Y, Fix.GATEOFDHAL_Treasure_43_Z))
            {
              One.TF.Treasure_GateDhal_00043 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_44_X, Fix.GATEOFDHAL_Treasure_44_Y, Fix.GATEOFDHAL_Treasure_44_Z))
            {
              One.TF.Treasure_GateDhal_00044 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_45_X, Fix.GATEOFDHAL_Treasure_45_Y, Fix.GATEOFDHAL_Treasure_45_Z))
            {
              One.TF.Treasure_GateDhal_00045 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_46_X, Fix.GATEOFDHAL_Treasure_46_Y, Fix.GATEOFDHAL_Treasure_46_Z))
            {
              One.TF.Treasure_GateDhal_00046 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_47_X, Fix.GATEOFDHAL_Treasure_47_Y, Fix.GATEOFDHAL_Treasure_47_Z))
            {
              One.TF.Treasure_GateDhal_00047 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_48_X, Fix.GATEOFDHAL_Treasure_48_Y, Fix.GATEOFDHAL_Treasure_48_Z))
            {
              One.TF.Treasure_GateDhal_00048 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_49_X, Fix.GATEOFDHAL_Treasure_49_Y, Fix.GATEOFDHAL_Treasure_49_Z))
            {
              One.TF.Treasure_GateDhal_00049 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_50_X, Fix.GATEOFDHAL_Treasure_50_Y, Fix.GATEOFDHAL_Treasure_50_Z))
            {
              One.TF.Treasure_GateDhal_00050 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.GATEOFDHAL_Treasure_51_X, Fix.GATEOFDHAL_Treasure_51_Y, Fix.GATEOFDHAL_Treasure_51_Z))
            {
              One.TF.Treasure_GateDhal_00051 = true;
            }
          }
          #endregion

          return; // 通常
        }
        else if (currentEvent == MessagePack.ActionEvent.RemoveFieldObject)
        {
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
          {
            // 岩壁１
            if (currentMessage == "1")
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_1_X, Fix.CAVEOFSARUN_Rock_1_Y, Fix.CAVEOFSARUN_Rock_1_Z));
              RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_2_X, Fix.CAVEOFSARUN_Rock_2_Y, Fix.CAVEOFSARUN_Rock_2_Z));
            }
            if (currentMessage == "2")
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_3_X, Fix.CAVEOFSARUN_Rock_3_Y, Fix.CAVEOFSARUN_Rock_3_Z));
              RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_4_X, Fix.CAVEOFSARUN_Rock_4_Y, Fix.CAVEOFSARUN_Rock_4_Z));
            }
            if (currentMessage == Fix.CAVEOFSARUN_Rock_5_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_5_X, Fix.CAVEOFSARUN_Rock_5_Y, Fix.CAVEOFSARUN_Rock_5_Z));
            }
            if (currentMessage == Fix.CAVEOFSARUN_Rock_6_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_6_X, Fix.CAVEOFSARUN_Rock_6_Y, Fix.CAVEOFSARUN_Rock_6_Z));
            }
            if (currentMessage == Fix.CAVEOFSARUN_Rock_7_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_7_X, Fix.CAVEOFSARUN_Rock_7_Y, Fix.CAVEOFSARUN_Rock_7_Z));
            }
            if (currentMessage == Fix.CAVEOFSARUN_Rock_4_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_4_X, Fix.CAVEOFSARUN_Rock_4_Y, Fix.CAVEOFSARUN_Rock_4_Z));
            }
            if (currentMessage == Fix.CAVEOFSARUN_Rock_8_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_8_X, Fix.CAVEOFSARUN_Rock_8_Y, Fix.CAVEOFSARUN_Rock_8_Z));
            }
          }

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
          {
            if (currentMessage == Fix.GORATRUM_CopperDoor_1_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.GORATRUM_CopperDoor_1_X, Fix.GORATRUM_CopperDoor_1_Y, Fix.GORATRUM_CopperDoor_1_Z));
            }
            if (currentMessage == Fix.GORATRUM_CopperDoor_2_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.GORATRUM_CopperDoor_2_X, Fix.GORATRUM_CopperDoor_2_Y, Fix.GORATRUM_CopperDoor_2_Z));
            }
            if (currentMessage == Fix.GORATRUM_CopperDoor_3_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.GORATRUM_CopperDoor_3_X, Fix.GORATRUM_CopperDoor_3_Y, Fix.GORATRUM_CopperDoor_3_Z));
            }
          }

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
          {
            if (currentMessage == Fix.GORATRUM_2_ObsidianPortal_1_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.GORATRUM_2_ObsidianPortal_1_X, Fix.GORATRUM_2_ObsidianPortal_1_Y, Fix.GORATRUM_2_ObsidianPortal_1_Z));
            }
          }

          // 岩壁１
          if (currentMessage == Fix.ARTHARIUM_Rock_1_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_1_X, Fix.ARTHARIUM_Rock_1_Y, Fix.ARTHARIUM_Rock_1_Z));
          }
          // 岩壁２
          if (currentMessage == Fix.ARTHARIUM_Rock_2_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_2_X, Fix.ARTHARIUM_Rock_2_Y, Fix.ARTHARIUM_Rock_2_Z));
          }
          // 岩壁３
          if (currentMessage == Fix.ARTHARIUM_Rock_3_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_3_X, Fix.ARTHARIUM_Rock_3_Y, Fix.ARTHARIUM_Rock_3_Z));
          }
          // 岩壁４
          if (currentMessage == Fix.ARTHARIUM_Rock_4_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_4_X, Fix.ARTHARIUM_Rock_4_Y, Fix.ARTHARIUM_Rock_4_Z));
          }
          // 岩壁５
          if (currentMessage == Fix.ARTHARIUM_Rock_5_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_5_X, Fix.ARTHARIUM_Rock_5_Y, Fix.ARTHARIUM_Rock_5_Z));
          }
          // プレイヤー２（ラナ待機オブジェクト）
          if (currentMessage == Fix.MAPEVENT_ARTHARIUM_3_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.MAPEVENT_ARTHARIUM_1_X, Fix.MAPEVENT_ARTHARIUM_1_Y + 1.0f, Fix.MAPEVENT_ARTHARIUM_1_Z));
          }
          // 扉１（右下、強敵モンスター入口）
          if (currentMessage == Fix.MAPEVENT_ARTHARIUM_4_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_1_X, Fix.ARTHARIUM_Door_Copper_1_Y, Fix.ARTHARIUM_Door_Copper_1_Z));
          }
          // 扉２（右下、強敵モンスター出現）
          if (currentMessage == Fix.MAPEVENT_ARTHARIUM_5_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_2_X, Fix.ARTHARIUM_Door_Copper_2_Y, Fix.ARTHARIUM_Door_Copper_2_Z));
          }
          // 扉３（左下出口近辺の宝箱）
          if (currentMessage == Fix.MAPEVENT_ARTHARIUM_8_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_3_X, Fix.ARTHARIUM_Door_Copper_3_Y, Fix.ARTHARIUM_Door_Copper_3_Z));
          }
          // 岩壁６
          if (currentMessage == Fix.ARTHARIUM_Rock_6_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_6_X, Fix.ARTHARIUM_Rock_6_Y, Fix.ARTHARIUM_Rock_6_Z));
          }
          // 扉４と５（中央通路のメインゲート）
          if (currentMessage == Fix.MAPEVENT_ARTHARIUM_9_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_4_X, Fix.ARTHARIUM_Door_Copper_4_Y, Fix.ARTHARIUM_Door_Copper_4_Z));
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_5_X, Fix.ARTHARIUM_Door_Copper_5_Y, Fix.ARTHARIUM_Door_Copper_5_Z));
          }
          // 奇妙な物体の入手
          if (currentMessage == Fix.MAPEVENT_ARTHARIUM_11_O)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_ObsidianStone_1_X, Fix.ARTHARIUM_ObsidianStone_1_Y, Fix.ARTHARIUM_ObsidianStone_1_Z));
          }

          // ダルの門、右エリア入口
          if (currentMessage == Fix.EVENT_GATEDHAL_1)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.EVENT_GATEDHAL_1_X, Fix.EVENT_GATEDHAL_1_Y, Fix.EVENT_GATEDHAL_1_Z));
          }
          // ダルの門、左エリア入口
          if (currentMessage == Fix.EVENT_GATEDHAL_2)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.EVENT_GATEDHAL_2_X, Fix.EVENT_GATEDHAL_2_Y, Fix.EVENT_GATEDHAL_2_Z));
          }
          // ダルの門、正面通路
          if (currentMessage == Fix.EVENT_GATEDHAL_3)
          {
            RemoveFieldObject(FieldObjList, new Vector3(Fix.EVENT_GATEDHAL_3_X, Fix.EVENT_GATEDHAL_3_Y, Fix.EVENT_GATEDHAL_3_Z));
          }
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.CallDecision)
        {
          if (currentMessage == Fix.DECISION_ARTHARIUM_CLIFF)
          {
            this.currentDecision = currentMessage;
            txtDecisionTitle.text = "DECISION TIME";
            txtDecisionMessage.text = "崖を降りるかどうかを決めてください。";
            txtDecisionA.text = "崖を降りる";
            txtDecisionB.text = "引き返す";
            txtDecisionC.text = "";
            GroupDecision.SetActive(true);
            return;
          }
          if (currentMessage == Fix.DECISION_ARTHARIUM_CLIFF_END)
          {
            this.currentDecision = currentMessage;
            txtDecisionTitle.text = "DECISION TIME";
            txtDecisionMessage.text = "崖を降りて元の通路へ戻るかどうかを決めてください。";
            txtDecisionA.text = "崖を降りて元の通路へ戻る。";
            txtDecisionB.text = "引き返して他の場所を探す";
            txtDecisionC.text = "";
            GroupDecision.SetActive(true);
            return;
          }
          if (currentMessage == Fix.DECISION_ARTHARIUM_CRASH_DOOR)
          {
            this.currentDecision = currentMessage;
            txtDecisionTitle.text = "DECISION TIME";
            txtDecisionMessage.text = "扉を蹴破って進むかどうかを決めてください。";
            txtDecisionA.text = "扉を蹴破る";
            txtDecisionB.text = "引き返す";
            txtDecisionC.text = "";
            GroupDecision.SetActive(true);
            return;
          }
          if (currentMessage == Fix.DECISION_ARTHARIUM_CRASH_DOOR2)
          {
            this.currentDecision = currentMessage;
            txtDecisionTitle.text = "DECISION TIME";
            txtDecisionMessage.text = "扉を蹴破って進むかどうかを決めてください。";
            txtDecisionA.text = "扉を蹴破る";
            txtDecisionB.text = "引き返す";
            txtDecisionC.text = "";
            GroupDecision.SetActive(true);
            return;
          }
          if (currentMessage == Fix.DECISION_PARTY_JOIN_SELMOI_RO)
          {
            this.currentDecision = currentMessage;
            txtDecisionTitle.text = "セルモイ・ロウに50000G支払い、仲間に引き入れますか？";
            txtDecisionMessage.text = "50000G支払う事で、セルモイ・ロウを仲間にする事が出来ます。50000G持っていない場合は仲間にする事は出来ません。";
            txtDecisionA.text = "仲間にする";
            txtDecisionB.text = "仲間にしない";
            GroupDecision.SetActive(true);
            return;
          }
        }
        else if (currentEvent == MessagePack.ActionEvent.EncountBoss)
        {
          One.CannotRunAway = true;
          One.BattleEnemyList.Clear();
          One.BattleEnemyList.Add(currentMessage);
          PrepareCallTruthBattleEnemy();
        }
        else if (currentEvent == MessagePack.ActionEvent.InstantiateObject)
        {
          Debug.Log("Detect InstantiateObject");
          // todo 他の生成シーンもケースごとに対応する。
          One.TF.LocationPlayer2 = true;
          LoadObjectFromEvent();
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.GainSoulFragment)
        {
          for (int jj = 0; jj < this.PlayerList.Count; jj++)
          {
            this.PlayerList[jj].SoulFragment += Convert.ToInt32(currentMessage);
          }
        }
        else if (currentEvent == MessagePack.ActionEvent.JumpToLocation)
        {
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
          {
            string[] locations = currentMessage.Split(':');
            int jump_X = Convert.ToInt32(locations[0]);
            int jump_Y = Convert.ToInt32(locations[1]);
            int jump_Z = Convert.ToInt32(locations[2]);
            JumpToLocation(new Vector3(jump_X, jump_Y, jump_Z));
            UpdateUnknownTile(Player.transform.position);
          }
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
      this.panelSystemMessage.SetActive(false);
      this.txtSystemMessage.text = string.Empty;
      this.QuestMessageList.Clear();
      Debug.Log(MethodBase.GetCurrentMethod() + " Message Clear");
    }
  }

  private void PrepareCallTruthBattleEnemy()
  {
    this.AlreadyDetectEncount = true;
    One.BattleEnd = Fix.GameEndType.None;
    if (this.ignoreCreateShadow == false)
    {
      One.CreateShadowData();
      for (int ii = 0; ii < One.EnemyList.Count; ii++)
      {
        UnityEngine.Object.DontDestroyOnLoad(One.ShadowPlayerList[ii]);
      }
    }

    One.EnemyList.Clear();
    for (int ii = 0; ii < One.BattleEnemyList.Count; ii++)
    {
      GameObject objEC = new GameObject("objEC_" + ii.ToString());
      Character character = objEC.AddComponent<Character>();
      character.Construction(One.BattleEnemyList[ii]);
      One.EnemyList.Add(character);
    }

    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    }
    //    SceneDimension.CallBattleEnemy();


    this.txtQuestMessage.text = PlayerList[0].CharacterMessage(1000);
    this.GroupQuestMessage.SetActive(true);
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

  private bool DetectEvent(TileInformation tile)
  {
    Debug.Log("DetectEvent: " + tile.transform.position.x + " " + tile.transform.position.y + " " + tile.transform.position.z);
    // 回復の泉
    if (tile != null && tile.field == TileInformation.Field.Fountain_1)
    {
      MessagePack.Message101000(ref QuestMessageList, ref QuestEventList); TapOK();
      GroupQuestMessage.SetActive(true);
      return true;
    }

    // todo town , castle, field, dungeonの属性分けが誤っている。
    // field
    #region "CaveOfSarun"
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
    {
      // todo 資格があれば入れる事とする。
      if (LocationDetect(tile, 0, 0, 2))
      {
        MessagePack.Message000130(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, -6, 0, 0) && One.TF.Event_Message000100 == false)
      {
        One.TF.Event_Message000100 = true;
        MessagePack.Message000100(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, -6, 0, -2) && One.TF.DefeatScreamingRafflesia == false)
      {
        MessagePack.Message000110(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, 5, 0, 6) && One.TF.Event_Message000080 == false)
      {
        One.TF.Event_Message000080 = true;
        MessagePack.Message000080(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, 15, 0, 1) && One.TF.AvailableImmediateAction == false)
      {
        MessagePack.Message000190(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
    }
    #endregion
    #region "ゴラトラム洞窟"
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
    {
      if (LocationDetect(tile, Fix.GORATRUM_Event_1_X, Fix.GORATRUM_Event_1_Y, Fix.GORATRUM_Event_1_Z))
      {
        MessagePack.Message600010(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_1_X, Fix.GORATRUM_Hole_1_Y, Fix.GORATRUM_Hole_1_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "1"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_2_X, Fix.GORATRUM_Hole_2_Y, Fix.GORATRUM_Hole_2_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "2"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_3_X, Fix.GORATRUM_Hole_3_Y, Fix.GORATRUM_Hole_3_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "3"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_4_X, Fix.GORATRUM_Hole_4_Y, Fix.GORATRUM_Hole_4_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "4"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_5_X, Fix.GORATRUM_Hole_5_Y, Fix.GORATRUM_Hole_5_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "5"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_6_X, Fix.GORATRUM_Hole_6_Y, Fix.GORATRUM_Hole_6_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "6"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_7_X, Fix.GORATRUM_Hole_7_Y, Fix.GORATRUM_Hole_7_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "7"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_8_X, Fix.GORATRUM_Hole_8_Y, Fix.GORATRUM_Hole_8_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "8"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_9_X, Fix.GORATRUM_Hole_9_Y, Fix.GORATRUM_Hole_9_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "9"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_10_X, Fix.GORATRUM_Hole_10_Y, Fix.GORATRUM_Hole_10_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "10"); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_11_X, Fix.GORATRUM_Hole_11_Y, Fix.GORATRUM_Hole_11_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, "11"); TapOK();
        return true;
      }

      // 左下聖堂前のタイル3つでイベント発生とする。
      if (LocationDetect(tile, Fix.GORATRUM_Event_2_X, Fix.GORATRUM_Event_2_Y, Fix.GORATRUM_Event_2_Z))
      {
        MessagePack.Message600210(ref QuestMessageList, ref QuestEventList, 0); TapOK();
      }
      if (LocationDetect(tile, Fix.GORATRUM_Event_3_X, Fix.GORATRUM_Event_3_Y, Fix.GORATRUM_Event_3_Z))
      {
        MessagePack.Message600210(ref QuestMessageList, ref QuestEventList, 1); TapOK();
      }
      if (LocationDetect(tile, Fix.GORATRUM_Event_4_X, Fix.GORATRUM_Event_4_Y, Fix.GORATRUM_Event_4_Z))
      {
        MessagePack.Message600210(ref QuestMessageList, ref QuestEventList, 2); TapOK();
      }

      if (LocationDetect(tile, Fix.GORATRUM_Hole_16_X, Fix.GORATRUM_Hole_16_Y, Fix.GORATRUM_Hole_16_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_16_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_17_X, Fix.GORATRUM_Hole_17_Y, Fix.GORATRUM_Hole_17_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_17_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_18_X, Fix.GORATRUM_Hole_18_Y, Fix.GORATRUM_Hole_18_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_18_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_19_X, Fix.GORATRUM_Hole_19_Y, Fix.GORATRUM_Hole_19_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_19_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_20_X, Fix.GORATRUM_Hole_20_Y, Fix.GORATRUM_Hole_20_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_20_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_21_X, Fix.GORATRUM_Hole_21_Y, Fix.GORATRUM_Hole_21_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_21_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_22_X, Fix.GORATRUM_Hole_22_Y, Fix.GORATRUM_Hole_22_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_22_O); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.GORATRUM_Hole_23_X, Fix.GORATRUM_Hole_23_Y, Fix.GORATRUM_Hole_23_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_23_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_24_X, Fix.GORATRUM_Hole_24_Y, Fix.GORATRUM_Hole_24_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_24_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_25_X, Fix.GORATRUM_Hole_25_Y, Fix.GORATRUM_Hole_25_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_25_O); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.GORATRUM_Hole_26_X, Fix.GORATRUM_Hole_26_Y, Fix.GORATRUM_Hole_26_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_26_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_27_X, Fix.GORATRUM_Hole_27_Y, Fix.GORATRUM_Hole_27_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_27_O); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_Hole_28_X, Fix.GORATRUM_Hole_28_Y, Fix.GORATRUM_Hole_28_Z))
      {
        MessagePack.Message600050(ref QuestMessageList, ref QuestEventList, Fix.GORATRUM_Hole_28_O); TapOK();
        return true;
      }
    }
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
    {
      if (LocationDetect(tile, Fix.GORATRUM_2_Event_1_X, Fix.GORATRUM_2_Event_1_Y, Fix.GORATRUM_2_Event_1_Z))
      {
        MessagePack.Message600300(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_2_Event_2_X, Fix.GORATRUM_2_Event_2_Y, Fix.GORATRUM_2_Event_2_Z))
      {
        MessagePack.Message600310(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.GORATRUM_2_Event_3_X, Fix.GORATRUM_2_Event_3_Y, Fix.GORATRUM_2_Event_3_Z) && One.TF.DefeatMagicalHailGun == false)
      {
        MessagePack.Message600320(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
    }
    #endregion
    #region "神秘の森"
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
    {
      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_1_X, Fix.MYSTICFOREST_Event_1_Y, Fix.MYSTICFOREST_Event_1_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_1_2_X, Fix.MYSTICFOREST_Event_1_2_Y, Fix.MYSTICFOREST_Event_1_2_Z))
      {
        MessagePack.Message900020(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_2_X, Fix.MYSTICFOREST_Event_2_Y, Fix.MYSTICFOREST_Event_2_Z))
      {
        MessagePack.Message900030(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_3_X, Fix.MYSTICFOREST_Event_3_Y, Fix.MYSTICFOREST_Event_3_Z))
      {
        MessagePack.Message900040(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
    }
    #endregion
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_BASE_FIELD)
    {
      if (LocationDetect(tile, -47, 3.5f, 17))
      {
        Debug.Log("Detect Message101001");
        MessagePack.Message101001(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, -49, 3.5f, 19))
      {
        Debug.Log("Detect Message101002");
        MessagePack.Message101002(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, -51, 3.5f, 17))
      {
        Debug.Log("Detect Message101003");
        MessagePack.Message101003(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, 26, 0, 4))
      {
        Debug.Log("Detect Message101004");
        MessagePack.Message101004(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_12_X, Fix.MAPEVENT_ARTHARIUM_12_Y, Fix.MAPEVENT_ARTHARIUM_12_Z) &&
         One.TF.Event_Message400040 == false)
      {
        Debug.Log("Detect Message101005");
        MessagePack.Message101005(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.EVENT_BASEFIELD_10_X, Fix.EVENT_BASEFIELD_10_Y, Fix.EVENT_BASEFIELD_10_Z) &&
        One.TF.EventField_10 == false)
      {
        MessagePack.Field_000010(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      // パルメテイシア神殿
      if (LocationDetect(tile, -100, 2, 80))
      {
        MessagePack.Field_000020(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
    }
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
    {
      // 岩壁１、マトックが必要（中央通路の左）
      if (LocationDetect(tile, -4, 0, 19))
      {
        MessagePack.Message300030(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // 岩壁２、マトックが必要（センター区画入り口前の右）
      else if (LocationDetect(tile, 10, 0, 9))
      {
        MessagePack.Message300031(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // 岩壁３、マトックが必要（センター区画入り口前の右）
      else if (LocationDetect(tile, 21, -1.5f, 19))
      {
        MessagePack.Message300032(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // 岩壁４、マトックが必要（センター区画、右通路）
      else if (LocationDetect(tile, 25, -1.5f, 30))
      {
        MessagePack.Message300033(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // 岩壁５、マトックが必要（センター区画、左通路）
      else if (LocationDetect(tile, 14, -1.5f, 30))
      {
        MessagePack.Message300034(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // 扉の鍵が必要（中央通路、センター区画の間の小部屋の右）
      else if (LocationDetect(tile, -1, 0, 32) || LocationDetect(tile, 0, 0, 32))
      {
        MessagePack.Message300040(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // センター区画に到着イベント
      else if (LocationDetect(tile, 20, -1.5f, 25) || LocationDetect(tile, 19, -1.5f, 25))
      {
        MessagePack.Message300050(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // マトック入手
      else if (LocationDetect(tile, 23, -1.5f, 36))
      {
        MessagePack.Message300060(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // センター区画左側通路先、崖落ち
      else if (LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_1_X, Fix.MAPEVENT_ARTHARIUM_1_Y, Fix.MAPEVENT_ARTHARIUM_1_Z))
      {
        MessagePack.Message300070(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      // todo 他のイベントを埋める必要がある。

      // 崖落ちマップから通常通路へと帰還
      else if (LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_2_X, Fix.MAPEVENT_ARTHARIUM_2_Y, Fix.MAPEVENT_ARTHARIUM_2_Z))
      {
        MessagePack.Message300080(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // 通常通路に戻り、ラナと合流
      else if (LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_3_X, Fix.MAPEVENT_ARTHARIUM_3_Y, Fix.MAPEVENT_ARTHARIUM_3_Z))
      {
        MessagePack.Message300090(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // 全域毒エリア、入口にて防護服が必要
      else if (LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_6_X, Fix.MAPEVENT_ARTHARIUM_6_Y, Fix.MAPEVENT_ARTHARIUM_6_Z) ||
               LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_6_2_X, Fix.MAPEVENT_ARTHARIUM_6_2_Y, Fix.MAPEVENT_ARTHARIUM_6_2_Z))
      {
        MessagePack.Message300140(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // センター区画、防護服の入手
      else if (LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_7_X, Fix.MAPEVENT_ARTHARIUM_7_Y, Fix.MAPEVENT_ARTHARIUM_7_Z))
      {
        MessagePack.Message300150(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // 岩壁６ // todo 岩壁は動いた先が岩壁の場合にイベント発生するほうが望ましい。下記のコードはY-1,Z-1が入っていて制御できていない。
      else if (LocationDetect(tile, Fix.ARTHARIUM_Rock_6_X, Fix.ARTHARIUM_Rock_6_Y - 1.0f, Fix.ARTHARIUM_Rock_6_Z - 1.0f))
      {
        MessagePack.Message300180(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      // ボス戦
      else if (LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_10_1_X, Fix.MAPEVENT_ARTHARIUM_10_1_Y, Fix.MAPEVENT_ARTHARIUM_10_1_Z) ||
               LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_10_2_X, Fix.MAPEVENT_ARTHARIUM_10_2_Y, Fix.MAPEVENT_ARTHARIUM_10_2_Z) ||
               LocationDetect(tile, Fix.MAPEVENT_ARTHARIUM_10_3_X, Fix.MAPEVENT_ARTHARIUM_10_3_Y, Fix.MAPEVENT_ARTHARIUM_10_3_Z)
               )
      {
        MessagePack.Message300190(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
    }
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
    {
      if (LocationDetect(tile, Fix.EVENT_OHRANTOWER_9_X, Fix.EVENT_OHRANTOWER_9_Y, Fix.EVENT_OHRANTOWER_9_Z))
      {
        MessagePack.Message800090(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.EVENT_OHRANTOWER_10_X, Fix.EVENT_OHRANTOWER_10_Y, Fix.EVENT_OHRANTOWER_10_Z))
      {
        MessagePack.Message800100(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.EVENT_OHRANTOWER_11_X, Fix.EVENT_OHRANTOWER_11_Y, Fix.EVENT_OHRANTOWER_11_Z))
      {
        MessagePack.Message800120(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
    }
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_SARITAN)
    {
      if (LocationDetect(tile, 1, 0, 0) && One.TF.AvailableSelmoiRo == false)
      {
        MessagePack.Message1200013(ref QuestMessageList, ref QuestEventList); TapOK();
        GroupQuestMessage.SetActive(true);
        return true;
      }
    }

    if (tile != null && tile.field == TileInformation.Field.Upstair)
    {
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
      {
        if (LocationDetect(tile, -10.0f, 0, -4.0f))
        {
          this.HomeTownCall = Fix.TOWN_FAZIL_CASTLE;
          return true;
          //DungeonCallSetup(Fix.MAPFILE_BASE_FIELD, -43, 2, -2);
        }
      }
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
      {
        if (LocationDetect(tile, Fix.GORATRUM_Upstair_1_X, Fix.GORATRUM_Upstair_1_Y, Fix.GORATRUM_Upstair_1_Z))
        {
          this.HomeTownCall = Fix.TOWN_FAZIL_CASTLE;
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Upstair_2_X, Fix.GORATRUM_Upstair_2_Y, Fix.GORATRUM_Upstair_2_Z))
        {
          this.HomeTownCall = Fix.TOWN_COTUHSYE;
          return true;
        }
      }
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
      {
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_1_X, Fix.GORATRUM_2_Upstair_1_Y, Fix.GORATRUM_2_Upstair_1_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_1_X, Fix.GORATRUM_2_Upstair_1_Y + 1.0f, Fix.GORATRUM_2_Upstair_1_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_2_X, Fix.GORATRUM_2_Upstair_2_Y, Fix.GORATRUM_2_Upstair_2_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_2_X, Fix.GORATRUM_2_Upstair_2_Y + 1.0f, Fix.GORATRUM_2_Upstair_2_Z);
          return true;
        }

        // todo (場所チェンジ)
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_3_X, Fix.GORATRUM_2_Upstair_3_Y, Fix.GORATRUM_2_Upstair_3_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_3_X, Fix.GORATRUM_2_Upstair_3_Y + 1.0f, Fix.GORATRUM_2_Upstair_3_Z);
          return true;
        }
        // todo

        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_4_X, Fix.GORATRUM_2_Upstair_4_Y, Fix.GORATRUM_2_Upstair_4_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_4_X, Fix.GORATRUM_2_Upstair_4_Y + 1.0f, Fix.GORATRUM_2_Upstair_4_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_5_X, Fix.GORATRUM_2_Upstair_5_Y, Fix.GORATRUM_2_Upstair_5_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_5_X, Fix.GORATRUM_2_Upstair_5_Y + 1.0f, Fix.GORATRUM_2_Upstair_5_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_6_X, Fix.GORATRUM_2_Upstair_6_Y, Fix.GORATRUM_2_Upstair_6_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_6_X, Fix.GORATRUM_2_Upstair_6_Y + 1.0f, Fix.GORATRUM_2_Upstair_6_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_7_X, Fix.GORATRUM_2_Upstair_7_Y, Fix.GORATRUM_2_Upstair_7_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_7_X, Fix.GORATRUM_2_Upstair_7_Y + 1.0f, Fix.GORATRUM_2_Upstair_7_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_8_X, Fix.GORATRUM_2_Upstair_8_Y, Fix.GORATRUM_2_Upstair_8_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_8_X, Fix.GORATRUM_2_Upstair_8_Y + 1.0f, Fix.GORATRUM_2_Upstair_8_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_9_X, Fix.GORATRUM_2_Upstair_9_Y, Fix.GORATRUM_2_Upstair_9_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_9_X, Fix.GORATRUM_2_Upstair_9_Y + 1.0f, Fix.GORATRUM_2_Upstair_9_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_10_X, Fix.GORATRUM_2_Upstair_10_Y, Fix.GORATRUM_2_Upstair_10_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_10_X, Fix.GORATRUM_2_Upstair_10_Y + 1.0f, Fix.GORATRUM_2_Upstair_10_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_11_X, Fix.GORATRUM_2_Upstair_11_Y, Fix.GORATRUM_2_Upstair_11_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_11_X, Fix.GORATRUM_2_Upstair_11_Y + 1.0f, Fix.GORATRUM_2_Upstair_11_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_2_Upstair_12_X, Fix.GORATRUM_2_Upstair_12_Y, Fix.GORATRUM_2_Upstair_12_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM, Fix.GORATRUM_2_Upstair_12_X, Fix.GORATRUM_2_Upstair_12_Y + 1.0f, Fix.GORATRUM_2_Upstair_12_Z);
          return true;
        }
      }

      if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
      {
        DungeonCallSetup(Fix.MAPFILE_BASE_FIELD, 25, 3, 32);
        return true;
      }
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
      {
        DungeonCallSetup(Fix.MAPFILE_BASE_FIELD, -4, 10, 33);
        return true;
      }
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GATE_OF_DHAL)
      {
        // 入口
        if (LocationDetect(tile, 0, 0, -3))
        {
          DungeonCallSetup(Fix.MAPFILE_BASE_FIELD, -67, 1.5f, 74);
          return true;
        }
        // 出口
        if (LocationDetect(tile, 0, 0, 37))
        {
          DungeonCallSetup(Fix.MAPFILE_BASE_FIELD, -65, 1.5f, 74);
          return true;
        }
      }
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
      {
        this.HomeTownCall = Fix.TOWN_COTUHSYE;
        return true;
      }
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_SARITAN)
      {
        DungeonCallSetup(Fix.MAPFILE_BASE_FIELD, -109, 1.5f, 33);
        return true;
      }
    }
    if (tile != null && tile.field == TileInformation.Field.Downstair)
    {
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
      {
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_1_X, Fix.GORATRUM_Downstair_1_Y, Fix.GORATRUM_Downstair_1_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_1_X, Fix.GORATRUM_Downstair_1_Y + 1.0f, Fix.GORATRUM_Downstair_1_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_2_X, Fix.GORATRUM_Downstair_2_Y, Fix.GORATRUM_Downstair_2_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_2_X, Fix.GORATRUM_Downstair_2_Y + 1.0f, Fix.GORATRUM_Downstair_2_Z);
          return true;
        }

        // todo (場所チェンジ)
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_3_X, Fix.GORATRUM_Downstair_3_Y, Fix.GORATRUM_Downstair_3_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_3_X, Fix.GORATRUM_Downstair_3_Y + 1.0f, Fix.GORATRUM_Downstair_3_Z);
          return true;
        }
        // todo

        if (LocationDetect(tile, Fix.GORATRUM_Downstair_4_X, Fix.GORATRUM_Downstair_4_Y, Fix.GORATRUM_Downstair_4_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_4_X, Fix.GORATRUM_Downstair_4_Y + 1.0f, Fix.GORATRUM_Downstair_4_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_5_X, Fix.GORATRUM_Downstair_5_Y, Fix.GORATRUM_Downstair_5_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_5_X, Fix.GORATRUM_Downstair_5_Y + 1.0f, Fix.GORATRUM_Downstair_5_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_6_X, Fix.GORATRUM_Downstair_6_Y, Fix.GORATRUM_Downstair_6_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_6_X, Fix.GORATRUM_Downstair_6_Y + 1.0f, Fix.GORATRUM_Downstair_6_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_7_X, Fix.GORATRUM_Downstair_7_Y, Fix.GORATRUM_Downstair_7_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_7_X, Fix.GORATRUM_Downstair_7_Y + 1.0f, Fix.GORATRUM_Downstair_7_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_8_X, Fix.GORATRUM_Downstair_8_Y, Fix.GORATRUM_Downstair_8_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_8_X,  Fix.GORATRUM_Downstair_8_Y + 1.0f, Fix.GORATRUM_Downstair_8_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_9_X, Fix.GORATRUM_Downstair_9_Y, Fix.GORATRUM_Downstair_9_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_9_X, Fix.GORATRUM_Downstair_9_Y + 1.0f, Fix.GORATRUM_Downstair_9_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_10_X, Fix.GORATRUM_Downstair_10_Y, Fix.GORATRUM_Downstair_10_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_10_X, Fix.GORATRUM_Downstair_10_Y + 1.0f, Fix.GORATRUM_Downstair_10_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_11_X, Fix.GORATRUM_Downstair_11_Y, Fix.GORATRUM_Downstair_11_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_11_X, Fix.GORATRUM_Downstair_11_Y + 1.0f, Fix.GORATRUM_Downstair_11_Z);
          return true;
        }
        if (LocationDetect(tile, Fix.GORATRUM_Downstair_12_X, Fix.GORATRUM_Downstair_12_Y, Fix.GORATRUM_Downstair_12_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_GORATRUM_2, Fix.GORATRUM_Downstair_12_X, Fix.GORATRUM_Downstair_12_Y + 1.0f, Fix.GORATRUM_Downstair_12_Z);
          return true;
        }
      }
    }

    // Town , Castle
    if ((tile != null && tile.field == TileInformation.Field.Town_1) ||
        (tile != null && tile.field == TileInformation.Field.Castle_1))
    {
      if (tile.transform.position.x == -44 && tile.transform.position.y == 1 && tile.transform.position.z == 4)
      {
        this.HomeTownCall = Fix.TOWN_ANSHET;
        return true;
      }
      else if (tile.transform.position.x == -49 && tile.transform.position.y == 4 && tile.transform.position.z == 17)
      {
        this.HomeTownCall = Fix.TOWN_FAZIL_CASTLE;
        return true;
      }
      else if (tile.transform.position.x == 24 && tile.transform.position.y == 0 && tile.transform.position.z == 4)
      {
        this.HomeTownCall = Fix.TOWN_QVELTA_TOWN;
        return true;
      }
      else if (tile.transform.position.x == 65 && tile.transform.position.y == 0 && tile.transform.position.z == -6)
      {
        this.HomeTownCall = Fix.TOWN_COTUHSYE;
        return true;
      }
      else if (tile.transform.position.x == 52 && tile.transform.position.y == 6.5 && tile.transform.position.z == 43)
      {
        this.HomeTownCall = Fix.TOWN_ZHALMAN;
        return true;
      }
      else if (tile.transform.position.x == -99 && tile.transform.position.y == 0 && tile.transform.position.z == 2)
      {
        this.HomeTownCall = Fix.TOWN_WOSM;
        return true;
      }
      else if (tile.transform.position.x == -85 && tile.transform.position.y == 0.5 && tile.transform.position.z == 49)
      {
        this.HomeTownCall = Fix.TOWN_ARCANEDINE;
        return true;
      }
      else if (tile.transform.position.x == -32 && tile.transform.position.y == 0.5 && tile.transform.position.z == 67)
      {
        this.HomeTownCall = Fix.TOWN_DALE;
        return true;
      }
      else if (tile.transform.position.x == 59 && tile.transform.position.y == 0.5 && tile.transform.position.z == 92)
      {
        this.HomeTownCall = Fix.TOWN_LATA_HOSE;
        return true;
      }
      else if (tile.transform.position.x == 52 && tile.transform.position.y == 6.5 && tile.transform.position.z == 49)
      {
        this.HomeTownCall = Fix.TOWN_ZELMAN;
        return true;
      }
      else if (tile.transform.position.x == 24 && tile.transform.position.y == 13 && tile.transform.position.z == 53)
      {
        this.HomeTownCall = Fix.TOWER_FRAN;
        return true;
      }
      else if (tile.transform.position.x == -100 && tile.transform.position.y == 2 && tile.transform.position.z == 77)
      {
        this.HomeTownCall = Fix.TOWN_PARMETYSIA;
        return true;
      }
      else if (tile.transform.position.x == 19 && tile.transform.position.y == 8 && tile.transform.position.z == 77)
      {
        this.HomeTownCall = Fix.TOWN_EDELGARZEN_CASTLE;
        return true;
      }
      else
      {
        // 何も設定しない
        Debug.Log("Not detect tile event(town): " + tile.transform.position.ToString());
      }
    }
    // Dungeon
    if (tile != null && tile.field == TileInformation.Field.Dungeon_1)
    {
      Debug.Log("Detect Dungeon_1: " + tile.transform.position.x + " " + tile.transform.position.y + " " + tile.transform.position.z);
      if (One.TF.EscapeFromDungeon)
      {
        MessagePack.MessageX00005(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (tile.transform.position.x == -44 && tile.transform.position.y == 1 && tile.transform.position.z == -2)
      {
        Debug.Log("Detect CaveOfSarun");
        this.DungeonMap = Fix.MAPFILE_CAVEOFSARUN;
        this.DungeonCall = Fix.DUNGEON_CAVEOFSARUN;
        One.TF.Field_X = 27;
        One.TF.Field_Y = 1;
        One.TF.Field_Z = 9;
        return true;
      }
      if (tile.transform.position.x == 25 && tile.transform.position.y == 2 && tile.transform.position.z == 33)
      {
        Debug.Log("Detect Artharium");
        this.DungeonMap = Fix.MAPFILE_ARTHARIUM;
        this.DungeonCall = Fix.DUNGEON_ARTHARIUM_FACTORY;
        One.TF.Field_X = 1;
        One.TF.Field_Y = 1;
        One.TF.Field_Z = 1;
        return true;
      }
      if (tile.transform.position.x == -4 && tile.transform.position.y == 9 && tile.transform.position.z == 34)
      {
        Debug.Log("Detect OhranTower");
        this.DungeonMap = Fix.MAPFILE_OHRAN_TOWER;
        this.DungeonCall = Fix.DUNGEON_OHRAN_TOWER;
        One.TF.Field_X = 0;
        One.TF.Field_Y = 1;
        One.TF.Field_Z = 0;
        return true;
      }
      if (tile.transform.position.x == -27 && tile.transform.position.y == 0 && tile.transform.position.z == -7)
      {
        this.DungeonMap = Fix.MAPFILE_GORATRUM;
        this.DungeonCall = Fix.DUNGEON_GORATRUM_CAVE;
        return true;
      }
      if (tile.transform.position.x == -66 && tile.transform.position.y == 0.5f && tile.transform.position.z == 74)
      {
        Debug.Log("Detect Gate of Dhal");
        this.DungeonMap = Fix.MAPFILE_GATE_OF_DHAL;
        this.DungeonCall = Fix.DUNGEON_GATE_OF_DHAL;
        One.TF.Field_X = 0;
        One.TF.Field_Y = 1;
        One.TF.Field_Z = -1;
        return true;
      }
      else if (tile.transform.position.x == -69 && tile.transform.position.y == 0 && tile.transform.position.z == 33)
      {
        this.DungeonCall = Fix.DUNGEON_VELGUS_SEA_TEMPLE;
        return true;
      }
      else if (tile.transform.position.x == -109 && tile.transform.position.y == 0.5 && tile.transform.position.z == 34)
      {
        Debug.Log("Detect Saritan");
        this.DungeonMap = Fix.MAPFILE_SARITAN;
        this.DungeonCall = Fix.DUNGEON_RUINS_OF_SARITAN;
        One.TF.Field_X = 0;
        One.TF.Field_Y = 1;
        One.TF.Field_Z = -1;
        return true;
      }
      else if (tile.transform.position.x == -112 && tile.transform.position.y == 7 && tile.transform.position.z == 95)
      {
        this.DungeonCall = Fix.DUNGEON_SNOWTREE_LATA;
        return true;
      }
      else if (tile.transform.position.x == -24 && tile.transform.position.y == -3.5 && tile.transform.position.z == 36)
      {
        this.DungeonCall = Fix.DUNGEON_DISKEL_BATTLE_FIELD;
        return true;
      }
      else if (tile.transform.position.x == 50 && tile.transform.position.y == 0.5 && tile.transform.position.z == 72)
      {
        this.DungeonCall = Fix.DUNGEON_SITH_GRAVEYARD;
        return true;
      }
      else if (tile.transform.position.x == -2 && tile.transform.position.y == 5 && tile.transform.position.z == 70)
      {
        this.DungeonCall = Fix.DUNGEON_GANRO_FORTRESS;
        return true;
      }
      else if (tile.transform.position.x == 17 && tile.transform.position.y == 0 && tile.transform.position.z == 93)
      {
        this.DungeonCall = Fix.DUNGEON_LOSLON_CAVE;
        return true;
      }
      else if (tile.transform.position.x == 25 && tile.transform.position.y == 2 && tile.transform.position.z == 33)
      {
        this.DungeonCall = Fix.DUNGEON_ARTHARIUM_FACTORY;
        return true;
      }
      else if (tile.transform.position.x == 2 && tile.transform.position.y == 30 && tile.transform.position.z == 48)
      {
        this.DungeonCall = Fix.DUNGEON_HEAVENS_GENESIS_GATE;
        return true;
      }
      else
      {
        // 何も設定しない
        Debug.Log("Not detect tile event(dungeon): " + tile.transform.position.ToString());
      }
    }
    return false;
  }

  private void DungeonCallSetup(string target_dungeon, float x, float y, float z)
  {
    this.DungeonMap = target_dungeon;
    this.DungeonCall = target_dungeon;
    One.TF.Field_X = x;
    One.TF.Field_Y = y;
    One.TF.Field_Z = z;
  }

  private bool LocationFieldDetect(FieldObject field_obj, float x, float y, float z)
  {
    if (field_obj.transform.position.x == x && field_obj.transform.position.y == y && field_obj.transform.position.z == z)
    {
      return true;
    }
    return false;
  }

  private bool LocationDetect(TileInformation tile, float x, float y, float z)
  {
    if (tile == null) { return false; }

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
        float damage = 10.0f * this.FieldDamage;
        if (One.TF.FindBackPackItem(Fix.RESIST_POISON_SUIT))
        {
          damage = damage / 10.0f;
        }
        PlayerList[ii].CurrentLife -= (int)(damage);
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

  private void DetectEncount(TileInformation.Area area_info)
  {
    Debug.Log("DetectEncount(S)");
    if (this.AlreadyDetectEncount)
    {
      Debug.Log("AlreadyDetectEncount is true, then not call DetectEncount");
      return;
    }

    CumulativeBattleCounter++;

    // 最初の歩きはじめはエンカウント対象外
    if (CumulativeBattleCounter <= 3)
    {
      return;
    }
    // エンカウントしない場合は対象外
    else if (this.BattleEncount <= -1)
    {
      return;
    }

    // エリア毎にランダムで敵軍隊を生成する。
    #region "サルン洞窟前"
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
    {
      int random = 100 - CumulativeBattleCounter;
      if (random <= 0) { random = 0; }
      if (AP.Math.RandomInteger(random) <= 10)
      {
        Debug.Log("area_info is " + area_info);
        if (area_info == TileInformation.Area.None) { return; }

        if (area_info == TileInformation.Area.AREA_1)
        {
          Debug.Log("area_info is AREA_1");
          if (PlayerList[0].Level < 2)
          {
            switch (AP.Math.RandomInteger(2))
            {
              case 0:
                One.BattleEnemyList.Add(Fix.TINY_MANTIS);
                break;
              case 1:
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                break;
              default:
                Debug.Log("rand_data default...AREA_1(1)");
                One.BattleEnemyList.Add(Fix.TINY_MANTIS);
                break;
            }
          }
          else
          {
            Debug.Log("PlayerList level is greater than 2");
            switch (AP.Math.RandomInteger(4))
            {
              case 0:
                Debug.Log("rand_data 0");
                One.BattleEnemyList.Add(Fix.TINY_MANTIS);
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                break;
              case 1:
                Debug.Log("rand_data 1");
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                One.BattleEnemyList.Add(Fix.TINY_MANTIS);
                break;
              case 2:
                Debug.Log("rand_data 2");
                One.BattleEnemyList.Add(Fix.YOUNG_WOLF);
                break;
              case 3:
                Debug.Log("rand_data 3");
                One.BattleEnemyList.Add(Fix.MANDRAGORA);
                break;
              default:
                Debug.Log("rand_data default...AREA_1(2)");
                One.BattleEnemyList.Add(Fix.TINY_MANTIS);
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                break;
            }
          }
        }
        else if (area_info == TileInformation.Area.AREA_2)
        {
          switch (AP.Math.RandomInteger(9))
          {
            case 0:
              One.BattleEnemyList.Add(Fix.WILD_ANT);
              One.BattleEnemyList.Add(Fix.SUN_FLOWER);
              break;
            case 1:
              One.BattleEnemyList.Add(Fix.WILD_ANT);
              One.BattleEnemyList.Add(Fix.SILENT_LADYBUG);
              break;
            case 2:
              One.BattleEnemyList.Add(Fix.WILD_ANT);
              One.BattleEnemyList.Add(Fix.NIMBLE_RABBIT);
              break;
            case 3:
              One.BattleEnemyList.Add(Fix.SOLID_BEETLE);
              One.BattleEnemyList.Add(Fix.SUN_FLOWER);
              break;
            case 4:
              One.BattleEnemyList.Add(Fix.SOLID_BEETLE);
              One.BattleEnemyList.Add(Fix.SILENT_LADYBUG);
              break;
            case 5:
              One.BattleEnemyList.Add(Fix.SOLID_BEETLE);
              One.BattleEnemyList.Add(Fix.NIMBLE_RABBIT);
              break;
            case 6:
              One.BattleEnemyList.Add(Fix.OLD_TREEFORK);
              One.BattleEnemyList.Add(Fix.SUN_FLOWER);
              break;
            case 7:
              One.BattleEnemyList.Add(Fix.OLD_TREEFORK);
              One.BattleEnemyList.Add(Fix.SILENT_LADYBUG);
              break;
            case 8:
              One.BattleEnemyList.Add(Fix.OLD_TREEFORK);
              One.BattleEnemyList.Add(Fix.NIMBLE_RABBIT);
              break;
            default:
              Debug.Log("rand_data default...AREA_2");
              One.BattleEnemyList.Add(Fix.WILD_ANT);
              One.BattleEnemyList.Add(Fix.SUN_FLOWER);
              break;
          }
        }
        else if (area_info == TileInformation.Area.AREA_3)
        {
          switch (AP.Math.RandomInteger(9))
          {
            case 0:
              One.BattleEnemyList.Add(Fix.ENTANGLED_VINE);
              One.BattleEnemyList.Add(Fix.CREEPING_SPIDER);
              break;
            case 1:
              One.BattleEnemyList.Add(Fix.ENTANGLED_VINE);
              One.BattleEnemyList.Add(Fix.BLOOD_MOSS);
              break;
            case 2:
              One.BattleEnemyList.Add(Fix.ENTANGLED_VINE);
              One.BattleEnemyList.Add(Fix.KILLER_BEE);
              break;
            case 3:
              One.BattleEnemyList.Add(Fix.DAUNTLESS_HORSE);
              One.BattleEnemyList.Add(Fix.CREEPING_SPIDER);
              break;
            case 4:
              One.BattleEnemyList.Add(Fix.DAUNTLESS_HORSE);
              One.BattleEnemyList.Add(Fix.BLOOD_MOSS);
              break;
            case 5:
              One.BattleEnemyList.Add(Fix.DAUNTLESS_HORSE);
              One.BattleEnemyList.Add(Fix.KILLER_BEE);
              break;
            case 6:
              One.BattleEnemyList.Add(Fix.WONDER_SEED);
              One.BattleEnemyList.Add(Fix.CREEPING_SPIDER);
              break;
            case 7:
              One.BattleEnemyList.Add(Fix.WONDER_SEED);
              One.BattleEnemyList.Add(Fix.BLOOD_MOSS);
              break;
            case 8:
              One.BattleEnemyList.Add(Fix.WONDER_SEED);
              One.BattleEnemyList.Add(Fix.KILLER_BEE);
              break;
            default:
              Debug.Log("rand_data default...AREA_3");
              One.BattleEnemyList.Add(Fix.ENTANGLED_VINE);
              One.BattleEnemyList.Add(Fix.CREEPING_SPIDER);
              break;
          }
        }
        //One.BattleEnemyList.Clear();
        //One.BattleEnemyList.Add(Fix.MAGICAL_HAIL_GUN);
        One.CannotRunAway = false;
        if (One.BattleEnemyList.Count <= 0) { Debug.Log("EnemyList is null..."); }
        else { for (int ii = 0; ii < One.BattleEnemyList.Count; ii++) { Debug.Log("EnemyList " + One.BattleEnemyList[ii]); } }
        PrepareCallTruthBattleEnemy();
      }
      return;
    }
    #endregion
    #region "ゴラトラム洞窟"
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM || One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
    {
      int random = 100 - CumulativeBattleCounter;
      if (random <= 0) { random = 0; }
      if (AP.Math.RandomInteger(random) <= 10)
      {
        Debug.Log("area_info is " + area_info);
        //if (area_info == TileInformation.Area.None) { return; }

        if (area_info == TileInformation.Area.AREA_1 || area_info == TileInformation.Area.None)
        {
          Debug.Log("area_info is AREA_1");
          int rand_data = AP.Math.RandomInteger(4);
          Debug.Log("rand_data is " + random);
          switch (rand_data)
          {
            case 0:
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.DEBRIS_SOLDIER);
              One.BattleEnemyList.Add(Fix.DEBRIS_SOLDIER);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.DEBRIS_SOLDIER);
              One.BattleEnemyList.Add(Fix.MAGICAL_AUTOMATA);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.KILLER_MACHINE);
              One.BattleEnemyList.Add(Fix.DEBRIS_SOLDIER);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.KILLER_MACHINE);
              One.BattleEnemyList.Add(Fix.MAGICAL_AUTOMATA);
              break;
            default:
              Debug.Log("rand_data default...");
              break;
          }
        }
        else if (area_info == TileInformation.Area.AREA_2)
        {
          Debug.Log("area_info is AREA_2");
          int rand_data = AP.Math.RandomInteger(10);
          Debug.Log("rand_data is " + random);
          switch (rand_data)
          {
            case 0:
              One.BattleEnemyList.Add(Fix.MECH_HAND);
              One.BattleEnemyList.Add(Fix.ABSENCE_MOAI);
              One.BattleEnemyList.Add(Fix.ACID_SCORPION);
              break;
            case 1:
              One.BattleEnemyList.Add(Fix.MECH_HAND);
              One.BattleEnemyList.Add(Fix.ABSENCE_MOAI);
              One.BattleEnemyList.Add(Fix.NEJIMAKI_KNIGHT);
              break;
            case 2:
              One.BattleEnemyList.Add(Fix.MECH_HAND);
              One.BattleEnemyList.Add(Fix.ABSENCE_MOAI);
              One.BattleEnemyList.Add(Fix.AIMING_SHOOTER);
              break;
            case 3:
              One.BattleEnemyList.Add(Fix.MECH_HAND);
              One.BattleEnemyList.Add(Fix.ABSENCE_MOAI);
              One.BattleEnemyList.Add(Fix.CULT_BLACK_MAGICIAN);
              break;
            case 4:
              One.BattleEnemyList.Add(Fix.ABSENCE_MOAI);
              One.BattleEnemyList.Add(Fix.AIMING_SHOOTER);
              One.BattleEnemyList.Add(Fix.AIMING_SHOOTER);
              break;
            case 5:
              One.BattleEnemyList.Add(Fix.NEJIMAKI_KNIGHT);
              One.BattleEnemyList.Add(Fix.NEJIMAKI_KNIGHT);
              One.BattleEnemyList.Add(Fix.CULT_BLACK_MAGICIAN);
              break;
            case 6:
              One.BattleEnemyList.Add(Fix.NEJIMAKI_KNIGHT);
              One.BattleEnemyList.Add(Fix.MECH_HAND);
              One.BattleEnemyList.Add(Fix.AIMING_SHOOTER);
              break;
            case 7:
              One.BattleEnemyList.Add(Fix.ABSENCE_MOAI);
              One.BattleEnemyList.Add(Fix.CULT_BLACK_MAGICIAN);
              One.BattleEnemyList.Add(Fix.CULT_BLACK_MAGICIAN);
              break;
            case 8:
              One.BattleEnemyList.Add(Fix.ACID_SCORPION);
              One.BattleEnemyList.Add(Fix.ACID_SCORPION);
              One.BattleEnemyList.Add(Fix.ACID_SCORPION);
              break;
            case 9:
              One.BattleEnemyList.Add(Fix.NEJIMAKI_KNIGHT);
              One.BattleEnemyList.Add(Fix.MECH_HAND);
              One.BattleEnemyList.Add(Fix.ABSENCE_MOAI);
              break;
            default:
              Debug.Log("rand_data default...");
              break;
          }
        }
        else if (area_info == TileInformation.Area.AREA_3)
        {
          Debug.Log("area_info is AREA_3");
          int rand_data = AP.Math.RandomInteger(10);
          Debug.Log("rand_data is " + random);
          switch (rand_data)
          {
            case 0:
              One.BattleEnemyList.Add(Fix.STONE_GOLEM);
              One.BattleEnemyList.Add(Fix.JUNK_VULKAN);
              One.BattleEnemyList.Add(Fix.SILENT_GARGOYLE);
              break;
            case 1:
              One.BattleEnemyList.Add(Fix.STONE_GOLEM);
              One.BattleEnemyList.Add(Fix.JUNK_VULKAN);
              One.BattleEnemyList.Add(Fix.LIGHTNING_CLOUD);
              break;
            case 2:
              One.BattleEnemyList.Add(Fix.LIGHTNING_CLOUD);
              One.BattleEnemyList.Add(Fix.JUNK_VULKAN);
              One.BattleEnemyList.Add(Fix.GATE_HOUND);
              break;
            case 3:
              One.BattleEnemyList.Add(Fix.STONE_GOLEM);
              One.BattleEnemyList.Add(Fix.LIGHTNING_CLOUD);
              One.BattleEnemyList.Add(Fix.PLAY_FIRE_IMP);
              break;
            case 4:
              One.BattleEnemyList.Add(Fix.GATE_HOUND);
              One.BattleEnemyList.Add(Fix.GATE_HOUND);
              One.BattleEnemyList.Add(Fix.SILENT_GARGOYLE);
              break;
            case 5:
              One.BattleEnemyList.Add(Fix.LIGHTNING_CLOUD);
              One.BattleEnemyList.Add(Fix.STONE_GOLEM);
              One.BattleEnemyList.Add(Fix.PLAY_FIRE_IMP);
              break;
            case 6:
              One.BattleEnemyList.Add(Fix.JUNK_VULKAN);
              One.BattleEnemyList.Add(Fix.SILENT_GARGOYLE);
              One.BattleEnemyList.Add(Fix.PLAY_FIRE_IMP);
              break;
            case 7:
              One.BattleEnemyList.Add(Fix.JUNK_VULKAN);
              One.BattleEnemyList.Add(Fix.LIGHTNING_CLOUD);
              One.BattleEnemyList.Add(Fix.PLAY_FIRE_IMP);
              break;
            case 8:
              One.BattleEnemyList.Add(Fix.JUNK_VULKAN);
              One.BattleEnemyList.Add(Fix.JUNK_VULKAN);
              One.BattleEnemyList.Add(Fix.JUNK_VULKAN);
              break;
            case 9:
              One.BattleEnemyList.Add(Fix.GATE_HOUND);
              One.BattleEnemyList.Add(Fix.PLAY_FIRE_IMP);
              One.BattleEnemyList.Add(Fix.PLAY_FIRE_IMP);
              break;
            default:
              Debug.Log("rand_data default...");
              break;
          }
        }
        else if (area_info == TileInformation.Area.AREA_4)
        {
          Debug.Log("area_info is AREA_4");
          int rand_data = AP.Math.RandomInteger(7);
          Debug.Log("rand_data is " + random);
          switch (rand_data)
          {
            case 0:
              One.BattleEnemyList.Add(Fix.EARTH_ELEMENTAL);
              One.BattleEnemyList.Add(Fix.WALKING_TIME_BOMB);
              One.BattleEnemyList.Add(Fix.DEATH_DRONE);
              break;
            case 1:
              One.BattleEnemyList.Add(Fix.ASSULT_SCARECROW);
              One.BattleEnemyList.Add(Fix.MAD_DOCTOR);
              One.BattleEnemyList.Add(Fix.WALKING_TIME_BOMB);
              break;
            case 2:
              One.BattleEnemyList.Add(Fix.EARTH_ELEMENTAL);
              One.BattleEnemyList.Add(Fix.ASSULT_SCARECROW);
              One.BattleEnemyList.Add(Fix.DEATH_DRONE);
              break;
            case 3:
              One.BattleEnemyList.Add(Fix.MAD_DOCTOR);
              One.BattleEnemyList.Add(Fix.DEATH_DRONE);
              One.BattleEnemyList.Add(Fix.DEATH_DRONE);
              break;
            case 4:
              One.BattleEnemyList.Add(Fix.MAD_DOCTOR);
              One.BattleEnemyList.Add(Fix.WALKING_TIME_BOMB);
              One.BattleEnemyList.Add(Fix.WALKING_TIME_BOMB);
              break;
            case 5:
              One.BattleEnemyList.Add(Fix.ASSULT_SCARECROW);
              One.BattleEnemyList.Add(Fix.ASSULT_SCARECROW);
              One.BattleEnemyList.Add(Fix.EARTH_ELEMENTAL);
              break;
            case 6:
              One.BattleEnemyList.Add(Fix.EARTH_ELEMENTAL);
              One.BattleEnemyList.Add(Fix.MAD_DOCTOR);
              One.BattleEnemyList.Add(Fix.ASSULT_SCARECROW);
              break;
            default:
              Debug.Log("rand_data default...");
              break;
          }

        }
        One.CannotRunAway = false;
        if (One.BattleEnemyList.Count <= 0) { Debug.Log("EnemyList is null..."); }
        else { for (int ii = 0; ii < One.BattleEnemyList.Count; ii++) { Debug.Log("EnemyList " + One.BattleEnemyList[ii]); } }
        PrepareCallTruthBattleEnemy();
      }
    }
    #endregion
    #region "神秘の森"
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
    {
      int random = 100 - CumulativeBattleCounter;
      if (random <= 0) { random = 0; }
      if (AP.Math.RandomInteger(random) <= 10)
      {
        Debug.Log("area_info is " + area_info);
        //if (area_info == TileInformation.Area.None) { return; }

        if (area_info == TileInformation.Area.AREA_1 || area_info == TileInformation.Area.None)
        {
          Debug.Log("area_info is AREA_1");
          int rand_data = AP.Math.RandomInteger(5);
          Debug.Log("rand_data is " + random);
          switch (rand_data)
          {
            case 0:
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.CHARGED_BOAR);
              One.BattleEnemyList.Add(Fix.POISON_FLOG);
              One.BattleEnemyList.Add(Fix.POISON_FLOG);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.CHARGED_BOAR);
              One.BattleEnemyList.Add(Fix.WOOD_ELF);
              One.BattleEnemyList.Add(Fix.STINKED_SPORE);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.GIANT_SNAKE);
              One.BattleEnemyList.Add(Fix.WOOD_ELF);
              One.BattleEnemyList.Add(Fix.WOOD_ELF);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.GIANT_SNAKE);
              One.BattleEnemyList.Add(Fix.CHARGED_BOAR);
              One.BattleEnemyList.Add(Fix.STINKED_SPORE);
              break;
            case 4:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.GIANT_SNAKE);
              One.BattleEnemyList.Add(Fix.POISON_FLOG);
              One.BattleEnemyList.Add(Fix.WOOD_ELF);
              break;
            default:
              Debug.Log("rand_data default...");
              break;
          }
        }

        One.CannotRunAway = false;
        if (One.BattleEnemyList.Count <= 0) { Debug.Log("EnemyList is null..."); }
        else { for (int ii = 0; ii < One.BattleEnemyList.Count; ii++) { Debug.Log("EnemyList " + One.BattleEnemyList[ii]); } }
        PrepareCallTruthBattleEnemy();
      }
      return;
    }
    #endregion
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_BASE_FIELD)
    {
      int random = 100 - CumulativeBattleCounter;
      if (random <= 0) { random = 0; }
      if (AP.Math.RandomInteger(random) <= 10)
      {
        Debug.Log("detectenemy: location: " + this.Player.transform.position.x + " " + this.Player.transform.position.z);

        switch (area_info)
        {
          case TileInformation.Area.AREA_1:
            switch (AP.Math.RandomInteger(3))
            {
              case 0:
                One.BattleEnemyList.Add(Fix.TINY_MANTIS);
                break;
              case 1:
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                break;
              case 2:
                One.BattleEnemyList.Add(Fix.YOUNG_WOLF);
                break;
            }
            break;
          case TileInformation.Area.AREA_2:
            switch (AP.Math.RandomInteger(5))
            {
              case 0:
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                One.BattleEnemyList.Add(Fix.MANDRAGORA);
                break;
              case 1:
                One.BattleEnemyList.Add(Fix.WILD_ANT);
                One.BattleEnemyList.Add(Fix.YOUNG_WOLF);
                One.BattleEnemyList.Add(Fix.YOUNG_WOLF);
                break;
              case 2:
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                One.BattleEnemyList.Add(Fix.GREEN_SLIME);
                One.BattleEnemyList.Add(Fix.OLD_TREEFORK);
                break;
              case 3:
                One.BattleEnemyList.Add(Fix.SUN_FLOWER);
                One.BattleEnemyList.Add(Fix.SUN_FLOWER);
                One.BattleEnemyList.Add(Fix.SUN_FLOWER);
                break;
              case 4:
                One.BattleEnemyList.Add(Fix.WILD_ANT);
                One.BattleEnemyList.Add(Fix.WILD_ANT);
                One.BattleEnemyList.Add(Fix.MANDRAGORA);
                One.BattleEnemyList.Add(Fix.MANDRAGORA);
                break;
            }
            break;
        }
        One.CannotRunAway = false;
        PrepareCallTruthBattleEnemy();
      }
      return;
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
      PlayerList[ii].Dead = false;
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
      Debug.Log("Tile is null.");
      return false;
    }
    if (tile != null && tile.MoveCost >= 999)
    {
      Debug.Log("Tile next field: " + tile.field.ToString());
      return false;
    }
    if (tile.transform.position.y - Player.transform.position.y >= 0.0f)
    {
      Debug.Log("Tile next field height is too high: " + (tile.transform.position.y - Player.transform.position.y).ToString());
      return false;
    }
    if (tile.transform.position.y - Player.transform.position.y <= -5.0f)
    {
      Debug.Log("Tile next field height is too low: " + (tile.transform.position.y - Player.transform.position.y).ToString());
      return false;
    }

    // debug（オブジェクト判定しない）
    if (IgnoreObjMode)
    {
      return true;
    }

    return true;
  }

  private FieldObject SearchObject(Vector3 player)
  {
    FieldObject obj = null;
    obj = GetObjectInfo(player.x, player.y, player.z);
    return obj;
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

  private FieldObject GetObjectInfo(float x, float y, float z)
  {
    //Debug.Log("GetObjectInfo: " + x.ToString() + " " + y.ToString() + " " + z.ToString());
    for (int ii = 0; ii < FieldObjList.Count; ii++)
    {
      if (x == FieldObjList[ii].transform.position.x &&
          y == FieldObjList[ii].transform.position.y &&
          z == FieldObjList[ii].transform.position.z)
      {
        return FieldObjList[ii];
      }
    }

    //Debug.Log("Cannot get object...then NULL");
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
                                           Player.transform.position.z - 1.0f);
    PlayerLight.transform.position = Player.transform.position;

    One.TF.Field_X = this.Player.transform.position.x;
    One.TF.Field_Y = this.Player.transform.position.y;
    One.TF.Field_Z = this.Player.transform.position.z;
  }

  private void UpdateUnknownTile(Vector3 position)
  {
    TileInformation currentRight = SearchNextTile(position, Direction.Right);
    TileInformation currentLeft = SearchNextTile(position, Direction.Left);
    TileInformation currentTop = SearchNextTile(position, Direction.Top);
    TileInformation currentBottom = SearchNextTile(position, Direction.Bottom);

    for (int ii = 0; ii < UnknownTileList.Count; ii++)
    {
      // 自プレイヤー位置の１スクエアは無条件で可視化する。
      if (position.x - 1.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < position.x + 1.01f
       && position.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < position.z + 1.01f)
      {
        UnknownTileList[ii].gameObject.SetActive(false);
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
        {
          One.TF.KnownTileList_CaveOfSarun[ii] = true;
        }
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
        {
          One.TF.KnownTileList_Goratrum[ii] = true;
        }
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
        {
          One.TF.KnownTileList_Goratrum_2[ii] = true;
        }
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
        {
          One.TF.KnownTileList_MysticForest[ii] = true;
        }
      }

      //１歩移動先が移動可能な場合その先の縦横クロス１マス分だけ可視化する。
      // ただし扉などで塞がれている場合は可視化しない。
      // 右
      if (currentRight != null && currentRight.MoveCost != 999)
      {
        Vector3 vector = new Vector3(currentRight.transform.position.x, currentRight.transform.position.y + 1.0f, currentRight.transform.position.z);
        FieldObject field_obj = SearchObject(vector);
        if (field_obj != null && field_obj.content == FieldObject.Content.Rock ||
            field_obj != null && field_obj.content == FieldObject.Content.Door_Copper ||
            field_obj != null && field_obj.content == FieldObject.Content.Brushwood)
        {
          // 可視化しない
        }
        else
        {
          Vector3 rightPos = new Vector3(position.x + 1, position.y, position.z);
          if (rightPos.x - 1.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < rightPos.x + 1.01f
           && rightPos.z - 0.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < rightPos.z + 0.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
            {
              One.TF.KnownTileList_CaveOfSarun[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
            {
              One.TF.KnownTileList_Goratrum[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
            {
              One.TF.KnownTileList_Goratrum_2[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
            {
              One.TF.KnownTileList_MysticForest[ii] = true;
            }
          }

          if (rightPos.x - 0.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < rightPos.x + 0.01f
           && rightPos.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < rightPos.z + 1.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
            {
              One.TF.KnownTileList_CaveOfSarun[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
            {
              One.TF.KnownTileList_Goratrum[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
            {
              One.TF.KnownTileList_Goratrum_2[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
            {
              One.TF.KnownTileList_MysticForest[ii] = true;
            }
          }
        }
      }

      // 左
      if (currentLeft != null && currentLeft.MoveCost != 999)
      {
        Vector3 vector = new Vector3(currentLeft.transform.position.x, currentLeft.transform.position.y + 1.0f, currentLeft.transform.position.z);
        FieldObject field_obj = SearchObject(vector);
        if (field_obj != null && field_obj.content == FieldObject.Content.Rock ||
            field_obj != null && field_obj.content == FieldObject.Content.Door_Copper)
        {
          // 可視化しない
        }
        else
        {
          Vector3 leftPos = new Vector3(position.x - 1, position.y, position.z);
          if (leftPos.x - 1.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < leftPos.x + 1.01f
           && leftPos.z - 0.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < leftPos.z + 0.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
            {
              One.TF.KnownTileList_CaveOfSarun[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
            {
              One.TF.KnownTileList_Goratrum[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
            {
              One.TF.KnownTileList_Goratrum_2[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
            {
              One.TF.KnownTileList_MysticForest[ii] = true;
            }
          }

          if (leftPos.x - 0.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < leftPos.x + 0.01f
           && leftPos.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < leftPos.z + 1.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
            {
              One.TF.KnownTileList_CaveOfSarun[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
            {
              One.TF.KnownTileList_Goratrum[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
            {
              One.TF.KnownTileList_Goratrum_2[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
            {
              One.TF.KnownTileList_MysticForest[ii] = true;
            }
          }
        }
      }

      // 上
      if (currentTop != null && currentTop.MoveCost != 999)
      {
        Vector3 vector = new Vector3(currentTop.transform.position.x, currentTop.transform.position.y + 1.0f, currentTop.transform.position.z);
        FieldObject field_obj = SearchObject(vector);
        if (field_obj != null && field_obj.content == FieldObject.Content.Rock ||
            field_obj != null && field_obj.content == FieldObject.Content.Door_Copper)
        {
          // 可視化しない
        }
        else
        {
          Vector3 topPos = new Vector3(position.x, position.y, position.z + 1);
          if (topPos.x - 1.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < topPos.x + 1.01f
           && topPos.z - 0.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < topPos.z + 0.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
            {
              One.TF.KnownTileList_CaveOfSarun[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
            {
              One.TF.KnownTileList_Goratrum[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
            {
              One.TF.KnownTileList_Goratrum_2[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
            {
              One.TF.KnownTileList_MysticForest[ii] = true;
            }
          }

          if (topPos.x - 0.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < topPos.x + 0.01f
           && topPos.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < topPos.z + 1.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
            {
              One.TF.KnownTileList_CaveOfSarun[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
            {
              One.TF.KnownTileList_Goratrum[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
            {
              One.TF.KnownTileList_Goratrum_2[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
            {
              One.TF.KnownTileList_MysticForest[ii] = true;
            }
          }
        }
      }

      // 下
      if (currentBottom != null && currentBottom.MoveCost != 999)
      {
        Vector3 vector = new Vector3(currentBottom.transform.position.x, currentBottom.transform.position.y + 1.0f, currentBottom.transform.position.z);
        FieldObject field_obj = SearchObject(vector);
        if (field_obj != null && field_obj.content == FieldObject.Content.Rock ||
            field_obj != null && field_obj.content == FieldObject.Content.Door_Copper)
        {
          // 可視化しない
        }
        else
        {
          Vector3 bottomPos = new Vector3(position.x, position.y, position.z - 1);
          if (bottomPos.x - 1.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < bottomPos.x + 1.01f
           && bottomPos.z - 0.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < bottomPos.z + 0.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
            {
              One.TF.KnownTileList_CaveOfSarun[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
            {
              One.TF.KnownTileList_Goratrum[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
            {
              One.TF.KnownTileList_Goratrum_2[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
            {
              One.TF.KnownTileList_MysticForest[ii] = true;
            }
          }

          if (bottomPos.x - 0.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < bottomPos.x + 0.01f
           && bottomPos.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < bottomPos.z + 1.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
            {
              One.TF.KnownTileList_CaveOfSarun[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
            {
              One.TF.KnownTileList_Goratrum[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
            {
              One.TF.KnownTileList_Goratrum_2[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
            {
              One.TF.KnownTileList_MysticForest[ii] = true;
            }
          }
        }
      }
    }

    // ダンジョン毎に到達ポイントで特定領域を可視化
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
    {
      if (position.x == 4.0f && position.y == 1.0f && position.z == 5.0f)
      {
        List<int> numbers = new List<int>() { 172, 173, 174, 175, 176, 212, 213, 214, 215, 216, 252, 253, 254, 255, 256, 292, 293, 294, 295, 296, 332, 333, 334, 335, 336 };
        for (int ii = 0; ii < numbers.Count; ii++)
        {
          UnknownTileList[numbers[ii]].gameObject.SetActive(false);
          One.TF.KnownTileList_CaveOfSarun[numbers[ii]] = true;
        }
      }
      if (position.x == 10.0f && position.y == 1 && position.z == -3)
      {
        List<int> numbers = new List<int>() { 619, 620, 621, 622, 623, 624, 659, 660, 661, 662, 663, 664, 699, 700, 701, 702, 703, 704, 739, 740, 741, 742, 743, 744, 779, 780, 781, 782, 783, 784 };
        for (int ii = 0; ii < numbers.Count; ii++)
        {
          UnknownTileList[numbers[ii]].gameObject.SetActive(false);
          One.TF.KnownTileList_CaveOfSarun[numbers[ii]] = true;
        }
      }
    }
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
  private void AddTile(string tile_name, Vector3 position, string id, string area_info)
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
    else if (tile_name == "Artharium_Hole" ||
             tile_name == "Goratrum_Hole")
    {
      current = Instantiate(prefab_Artharium_Hole, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Artharium_Poison")
    {
      current = Instantiate(prefab_Artharium_Poison, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Artharium_Gate")
    {
      current = Instantiate(prefab_Artharium_Gate, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Ohran_Normal")
    {
      current = Instantiate(prefab_Ohran_Normal, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Ohran_Wall")
    {
      current = Instantiate(prefab_Ohran_Wall, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Ohran_FloatTile")
    {
      current = Instantiate(prefab_Ohran_FloatTile, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Ohran_WarpHole")
    {
      current = Instantiate(prefab_Ohran_WarpHole, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Dhal_Normal")
    {
      current = Instantiate(prefab_Dhal_Normal, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Dhal_Wall")
    {
      current = Instantiate(prefab_Dhal_Wall, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "MysticForest_Normal")
    {
      current = Instantiate(prefab_MysticForest_Normal, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "MysticForest_Wall")
    {
      current = Instantiate(prefab_MysticForest_Wall, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Upstair")
    {
      current = Instantiate(prefab_Upstair, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Downstair")
    {
      current = Instantiate(prefab_Downstair, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Unknown")
    {
      current = Instantiate(prefab_Unknown, position, Quaternion.identity) as TileInformation;
    }

    if (current != null)
    {
      current.ObjectId = id;
      //Debug.Log("areainfo: " + area_info);
      if (string.IsNullOrEmpty(area_info) == false)
      {
        current.AreaInfo = (TileInformation.Area)(Enum.Parse(typeof(TileInformation.Area), area_info));
      }
      current.transform.SetParent(this.transform);
      //current.gameObject.SetActive(false);
      TileList.Add(current);

      TextMeshPro instance = Instantiate(prefab_AreaText) as TextMeshPro;
      instance.gameObject.transform.SetParent(TileList[TileList.Count - 1].transform);
      instance.gameObject.transform.localPosition = new Vector3(0, 0.70f, 0);
      instance.text = ((int)(current.AreaInfo)).ToString();
      instance.gameObject.SetActive(false);
      TileAreaList.Add(instance);
    }
  }

  /// <summary>
  /// タイルを追加します。
  /// </summary>
  private void AddUnknown(string tile_name, Vector3 position, string id)
  {
    TileInformation current = null;
    if (tile_name == "Unknown")
    {
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_CAVEOFSARUN)
      {
        current = Instantiate(prefab_Unknown, position, Quaternion.identity) as TileInformation;
      }
      else if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM ||
          One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
      {
        current = Instantiate(prefab_Unknown_Goratrum, position, Quaternion.identity) as TileInformation;
      }
      else if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
      {
        current = Instantiate(prefab_Unknown_MysticForest, position, Quaternion.identity) as TileInformation;
      }
      else
      {
        current = Instantiate(prefab_Unknown, position, Quaternion.identity) as TileInformation;
      }
    }

    if (current != null)
    {
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      UnknownTileList.Add(current);
    }
  }

  private void AddFieldObj(string obj_name, Vector3 position, string id, Quaternion q)
  {
    FieldObject current = null;

    if (obj_name == "Treasure")
    {
      current = Instantiate(prefab_Treasure, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Treasure;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Rock")
    {
      current = Instantiate(prefab_Rock, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Rock;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Fountain")
    {
      current = Instantiate(prefab_Fountain, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Fountain;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "MessageBoard")
    {
      current = Instantiate(prefab_MessageBoard, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.MessageBoard;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Door_Copper")
    {
      current = Instantiate(prefab_DoorCopper, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Door_Copper;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Crystal")
    {
      current = Instantiate(prefab_Crystal, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Crystal;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "ObsidianStone")
    {
      current = Instantiate(prefab_ObsidianStone, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.ObsidianStone;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "FloatingTile")
    {
      current = Instantiate(prefab_FloatingTile, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.FloatingTile;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "WarpHole")
    {
      current = Instantiate(prefab_WarpHole, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.WarpHole;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "DhalGate_Tile")
    {
      current = Instantiate(prefab_DhalGateTile, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.DhalGate_Tile;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "DhalGate_Wall")
    {
      current = Instantiate(prefab_DhalGateWall, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.DhalGate_Wall;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "DhalGate_Door")
    {
      current = Instantiate(prefab_DhalGateDoor, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.DhalGate_Door;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Brushwood")
    {
      current = Instantiate(prefab_Brushwood, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Brushwood;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else
    {
      Debug.Log("AddFieldObj not found... " + obj_name);
    }

    if (current != null)
    {
      current.gameObject.SetActive(true);
      FieldObjList.Add(current);
    }
  }

  /// <summary>
  /// タイルマップデータを保存します。
  /// </summary>
  /// <param name="map_data"></param>
  private void SaveTileMapping(string map_data)
  {
    TextAsset txt = Resources.Load<TextAsset>(map_data.Replace(".txt", ""));

    Debug.Log("map_data path: " + One.pathForRoot() + map_data);
    //XmlTextWriter xmlWriter = new XmlTextWriter(Application.dataPath + Fix.BaseMapFolder + map_data, Encoding.UTF8);
    XmlTextWriter xmlWriter = new XmlTextWriter(One.pathForRoot() + map_data, Encoding.UTF8);
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
        xmlWriter.WriteAttributeString("O", TileList[ii].ObjectId);
        xmlWriter.WriteAttributeString("X", TileList[ii].transform.position.x.ToString());
        xmlWriter.WriteAttributeString("Y", TileList[ii].transform.position.y.ToString());
        xmlWriter.WriteAttributeString("Z", TileList[ii].transform.position.z.ToString());
        xmlWriter.WriteAttributeString("A", TileList[ii].AreaInfo.ToString());
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
        xmlWriter.WriteAttributeString("O", FieldObjList[ii].ObjectId);
        xmlWriter.WriteAttributeString("X", FieldObjList[ii].transform.position.x.ToString());
        xmlWriter.WriteAttributeString("Y", FieldObjList[ii].transform.position.y.ToString());
        xmlWriter.WriteAttributeString("Z", FieldObjList[ii].transform.position.z.ToString());
        xmlWriter.WriteAttributeString("QX", FieldObjList[ii].transform.rotation.x.ToString());
        xmlWriter.WriteAttributeString("QY", FieldObjList[ii].transform.rotation.y.ToString());
        xmlWriter.WriteAttributeString("QZ", FieldObjList[ii].transform.rotation.z.ToString());
        xmlWriter.WriteAttributeString("QW", FieldObjList[ii].transform.rotation.w.ToString());
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

  private void UpdateDebugMessage(string message)
  {
    txtDebugMainMessage.text = txtDebugMainMessage.text.Insert(0, message + "\r\n");
    Debug.Log(message);
  }

  /// <summary>
  /// タイルマップデータを読み込み、画面へ反映します。
  /// </summary>
  private void LoadTileMapping(string map_data)
  {
    Debug.Log("LoadTileMapping-1 " + DateTime.Now.ToString() + " " + map_data);

    try
    {
      for (int ii = 0; ii < TileList.Count; ii++)
      {
        Destroy(TileList[ii].gameObject);
        TileList[ii] = null;
      }
      TileList.Clear();

      for (int ii = 0; ii < FieldObjList.Count; ii++)
      {
        Destroy(FieldObjList[ii].gameObject);
        FieldObjList[ii] = null;
      }
      FieldObjList.Clear();

      XmlDocument xml = new XmlDocument();
      DateTime now = DateTime.Now;
      //xml.Load(map_data);

      XmlReaderSettings settings = new XmlReaderSettings();
      settings.IgnoreWhitespace = true;
      settings.IgnoreComments = true;
     // UpdateDebugMessage(Application.dataPath + Fix.BaseMapFolder + map_data);
//      UpdateDebugMessage("2: " + Resources.Load<TextAsset>(@"Map\" + map_data).text);
      TextAsset txt = Resources.Load<TextAsset>(map_data.Replace(".txt", ""));
      if (txt == null)
      {
        UpdateDebugMessage("cannot find map_data...");
      }
      else
      {
        UpdateDebugMessage("map_data found! " + txt.name);
      }
      UpdateDebugMessage("3: " + txt.name);
      //using (XmlReader reader = XmlReader.Create(Environment.CurrentDirectory + "/" +  Fix.BaseMapFolder + map_data, settings))
      Stream sw = new MemoryStream(txt.bytes);
      using (XmlReader reader = XmlReader.Create(sw, settings))
      {
        int counter = 0;
        List<Vector3> list = new List<Vector3>();
        List<string> strList = new List<string>();
        List<string> strIdList = new List<string>();

        List<Vector3> objList = new List<Vector3>();
        List<string> strObjList = new List<string>();
        List<string> strObjIdList = new List<string>();
        List<string> strObjArea = new List<string>();
        List<Quaternion> ObjQuaternionList = new List<Quaternion>();

        for (; reader.Read();)
        {
          if (reader.Name.Contains("Tile_"))
          {
            string tile = reader.GetAttribute("T");
            string id = reader.GetAttribute("O");
            float x = Convert.ToSingle(reader.GetAttribute("X"));
            float y = Convert.ToSingle(reader.GetAttribute("Y"));
            float z = Convert.ToSingle(reader.GetAttribute("Z"));
            string a = Convert.ToString(reader.GetAttribute("A"));
            //Debug.Log(reader.GetAttribute("T") + " " + reader.GetAttribute("X") + " " + reader.GetAttribute("Y") + " " + reader.GetAttribute("Z"));
            list.Add(new Vector3(x, y, z));
            strList.Add(tile);
            strIdList.Add(id);
            strObjArea.Add(a);
          }
          if (reader.Name.Contains("Field_"))
          {
            string obj = reader.GetAttribute("C");
            string id = reader.GetAttribute("O");
            float x = Convert.ToSingle(reader.GetAttribute("X"));
            float y = Convert.ToSingle(reader.GetAttribute("Y"));
            float z = Convert.ToSingle(reader.GetAttribute("Z"));
            float qx = Convert.ToSingle(reader.GetAttribute("QX"));
            float qy = Convert.ToSingle(reader.GetAttribute("QY"));
            float qz = Convert.ToSingle(reader.GetAttribute("QZ"));
            float qw = Convert.ToSingle(reader.GetAttribute("QW"));
            objList.Add(new Vector3(x, y, z));
            strObjList.Add(obj);
            strObjIdList.Add(id);
            ObjQuaternionList.Add(new Quaternion(qx, qy, qz, qw));
          }
          counter++;
        }
        Debug.Log(MethodBase.GetCurrentMethod() + " counter : " + counter.ToString());

        for (int ii = 0; ii < list.Count; ii++)
        {
          AddTile(strList[ii], list[ii], strIdList[ii], strObjArea[ii]);
        }

        for (int ii = 0; ii < objList.Count; ii++)
        {
          AddFieldObj(strObjList[ii], objList[ii], strObjIdList[ii], ObjQuaternionList[ii]);

          // debug
          NodeEditFieldObj objView = Instantiate(NodeFieldObjView) as NodeEditFieldObj;
          objView.transform.SetParent(ContentFieldObj.transform);
          objView.txtType.text = strObjList[ii];
          objView.txtLocation.text = objList[ii].ToString();
          //Debug.Log("currentObjView ID: " + strObjIdList[ii]);
          objView.txtObjectId.text = strObjIdList[ii];
          objView.x = objList[ii].x;
          objView.y = objList[ii].y;
          objView.z = objList[ii].z;
          objView.gameObject.SetActive(true);
          RectTransform rect = objView.GetComponent<RectTransform>();
          int NODE_HEIGHT = 90;
          rect.anchoredPosition = new Vector2(0, 0);
          //rect.sizeDelta = new Vector2(0, 0);
          rect.localPosition = new Vector3(0, -5 - ii * NODE_HEIGHT, 0);
          const int HEIGHT = 110;
          ContentFieldObj.GetComponent<RectTransform>().sizeDelta = new Vector2(ContentFieldObj.GetComponent<RectTransform>().sizeDelta.x, ContentFieldObj.GetComponent<RectTransform>().sizeDelta.y + HEIGHT);
          //Debug.Log("debug count: " + ii.ToString());
          // debug
        }
      }
    }
    catch (Exception ex)
    {
      UpdateDebugMessage(ex.ToString());
    }
    Debug.Log("LoadTileMapping-2 " + DateTime.Now.ToString());
  }

  /// <summary>
  /// 未到達箇所にUnknownタイルを設置します。
  /// </summary>
  private void SetupUnknownTile(string map_data)
  {
    if (map_data == Fix.MAPFILE_CAVEOFSARUN)
    {
      for (int ii = 0; ii < Fix.MAPSIZE_Z_CAVEOFSARUN; ii++)
      {
        for (int jj = 0; jj < Fix.MAPSIZE_X_CAVEOFSARUN; jj++)
        {
          Vector3 position = new Vector3(jj - 10, 1.0f, 12 - ii);
          AddUnknown("Unknown", position, "X" + ii + "_Z" + jj);
          UnknownTileList[UnknownTileList.Count - 1].gameObject.SetActive(true);
        }
      }
      for (int ii = 0; ii < Fix.MAPSIZE_X_CAVEOFSARUN * Fix.MAPSIZE_Z_CAVEOFSARUN; ii++)
      {
        if (One.TF.KnownTileList_CaveOfSarun[ii])
        {
          UnknownTileList[ii].gameObject.SetActive(false);
        }
      }
    }
    if (map_data == Fix.MAPFILE_GORATRUM)
    {
      for (int ii = 0; ii < Fix.MAPSIZE_Z_GORATRUM; ii++)
      {
        for (int jj = 0; jj < Fix.MAPSIZE_X_GORATRUM; jj++)
        {
          Vector3 position = new Vector3(jj, 1.0f, -ii);
          AddUnknown("Unknown", position, "X" + ii + "_Z" + jj);
          UnknownTileList[UnknownTileList.Count - 1].gameObject.SetActive(true);
        }
      }
      Debug.Log("Goratrum KnownTileList_Goratrum count: " + One.TF.KnownTileList_Goratrum.Count);
      for (int ii = 0; ii < Fix.MAPSIZE_X_GORATRUM * Fix.MAPSIZE_Z_GORATRUM; ii++)
      {
        if (One.TF.KnownTileList_Goratrum[ii])
        {
          UnknownTileList[ii].gameObject.SetActive(false);
        }
      }
    }
    if (map_data == Fix.MAPFILE_GORATRUM_2)
    {
      for (int ii = 0; ii < Fix.MAPSIZE_Z_GORATRUM; ii++)
      {
        for (int jj = 0; jj < Fix.MAPSIZE_X_GORATRUM; jj++)
        {
          Vector3 position = new Vector3(jj, 1.0f, -ii);
          AddUnknown("Unknown", position, "X" + ii + "_Z" + jj);
          UnknownTileList[UnknownTileList.Count - 1].gameObject.SetActive(true);
        }
      }
      Debug.Log("Goratrum KnownTileList_Goratrum_2 count: " + One.TF.KnownTileList_Goratrum_2.Count);
      for (int ii = 0; ii < Fix.MAPSIZE_X_GORATRUM * Fix.MAPSIZE_Z_GORATRUM; ii++)
      {
        if (One.TF.KnownTileList_Goratrum_2[ii])
        {
          UnknownTileList[ii].gameObject.SetActive(false);
        }
      }
    }

    if (map_data == Fix.MAPFILE_MYSTIC_FOREST)
    {
      for (int ii = 0; ii < Fix.MAPSIZE_Z_MYSTICFOREST; ii++)
      {
        for (int jj = 0; jj < Fix.MAPSIZE_X_MYSTICFOREST; jj++)
        {
          Vector3 position = new Vector3(jj, 1.0f, -ii);
          AddUnknown("Unknown", position, "X" + ii + "_Z" + jj);
          UnknownTileList[UnknownTileList.Count - 1].gameObject.SetActive(true);
        }
      }
      Debug.Log("Goratrum KnownTileList_MysticForest count: " + One.TF.KnownTileList_MysticForest.Count);
      for (int ii = 0; ii < Fix.MAPSIZE_X_MYSTICFOREST * Fix.MAPSIZE_Z_MYSTICFOREST; ii++)
      {
        if (One.TF.KnownTileList_MysticForest[ii])
        {
          UnknownTileList[ii].gameObject.SetActive(false);
        }
      }
    }
  }

  private void LoadObjectFromEvent()
  {
    if (One.TF.LocationPlayer2 && One.TF.Event_Message300090 == false)
    {
      Debug.Log("Detect One.TF.LocationPlayer2");

      // イベント発生するタイルの一つ上に設置
      Vector3 position = new Vector3(Fix.MAPEVENT_ARTHARIUM_1_X, Fix.MAPEVENT_ARTHARIUM_1_Y + 1, Fix.MAPEVENT_ARTHARIUM_1_Z);
      FieldObject current = Instantiate(prefab_Player2, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Character;
      current.transform.SetParent(this.transform);
      current.transform.rotation = prefab_Player2.transform.rotation;

      // debug
      NodeEditFieldObj objView = Instantiate(NodeFieldObjView) as NodeEditFieldObj;
      objView.transform.SetParent(ContentFieldObj.transform);
      objView.txtType.text = current.content.ToString();
      objView.txtLocation.text = current.transform.position.ToString();
      objView.txtObjectId.text = current.ObjectId.ToString();
      objView.x = current.transform.position.x;
      objView.y = current.transform.position.y;
      objView.z = current.transform.position.z;
      objView.gameObject.SetActive(true);
      RectTransform rect = objView.GetComponent<RectTransform>();
      int NODE_HEIGHT = 90;
      rect.anchoredPosition = new Vector2(0, 0);
      //rect.sizeDelta = new Vector2(0, 0);
      rect.localPosition = new Vector3(0, -5 - this.FieldObjList.Count * NODE_HEIGHT, 0);
      const int HEIGHT = 110;
      ContentFieldObj.GetComponent<RectTransform>().sizeDelta = new Vector2(ContentFieldObj.GetComponent<RectTransform>().sizeDelta.x, ContentFieldObj.GetComponent<RectTransform>().sizeDelta.y + HEIGHT);
      // debug

      this.FieldObjList.Add(current);
    }
  }

  private void UpdateFieldObject(string map_data)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + "(S)");
    #region "サルン洞窟前"
    if (map_data == Fix.MAPFILE_CAVEOFSARUN)
    {
      Debug.Log("update " + map_data + " field");
      if (One.TF.Treasure_CaveOfSarun_00001)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_1_X, Fix.CAVEOFSARUN_Treasure_1_Y, Fix.CAVEOFSARUN_Treasure_1_Z)));
      }
      if (One.TF.Treasure_CaveOfSarun_00002)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_2_X, Fix.CAVEOFSARUN_Treasure_2_Y, Fix.CAVEOFSARUN_Treasure_2_Z)));
      }
      if (One.TF.Treasure_CaveOfSarun_00003)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_3_X, Fix.CAVEOFSARUN_Treasure_3_Y, Fix.CAVEOFSARUN_Treasure_3_Z)));
      }
      if (One.TF.Treasure_CaveOfSarun_00004)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_4_X, Fix.CAVEOFSARUN_Treasure_4_Y, Fix.CAVEOFSARUN_Treasure_4_Z)));
      }
      if (One.TF.Treasure_CaveOfSarun_00005)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_5_X, Fix.CAVEOFSARUN_Treasure_5_Y, Fix.CAVEOFSARUN_Treasure_5_Z)));
      }
      if (One.TF.Treasure_CaveOfSarun_00006)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_6_X, Fix.CAVEOFSARUN_Treasure_6_Y, Fix.CAVEOFSARUN_Treasure_6_Z)));
      }
      if (One.TF.Treasure_CaveOfSarun_00007)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_7_X, Fix.CAVEOFSARUN_Treasure_7_Y, Fix.CAVEOFSARUN_Treasure_7_Z)));
      }
      if (One.TF.Treasure_CaveOfSarun_00008)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_8_X, Fix.CAVEOFSARUN_Treasure_8_Y, Fix.CAVEOFSARUN_Treasure_8_Z)));
      }
      if (One.TF.Treasure_CaveOfSarun_00009)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_9_X, Fix.CAVEOFSARUN_Treasure_9_Y, Fix.CAVEOFSARUN_Treasure_9_Z)));
      }
      if (One.TF.Treasure_CaveOfSarun_00010)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Treasure_10_X, Fix.CAVEOFSARUN_Treasure_10_Y, Fix.CAVEOFSARUN_Treasure_10_Z)));
      }

      // 岩壁１
      if (One.TF.FieldObject_CaveofSarun_00001)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_1_X, Fix.CAVEOFSARUN_Rock_1_Y, Fix.CAVEOFSARUN_Rock_1_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_2_X, Fix.CAVEOFSARUN_Rock_2_Y, Fix.CAVEOFSARUN_Rock_2_Z));
      }
      // 岩壁６
      if (One.TF.FieldObject_CaveofSarun_00002)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_6_X, Fix.CAVEOFSARUN_Rock_6_Y, Fix.CAVEOFSARUN_Rock_6_Z));
      }
      // 岩壁５
      if (One.TF.FieldObject_CaveofSarun_00003)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_5_X, Fix.CAVEOFSARUN_Rock_5_Y, Fix.CAVEOFSARUN_Rock_5_Z));
      }
      // 岩壁７
      if (One.TF.FieldObject_CaveofSarun_00007)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_7_X, Fix.CAVEOFSARUN_Rock_7_Y, Fix.CAVEOFSARUN_Rock_7_Z));
      }
      // 岩壁４
      if (One.TF.FieldObject_CaveofSarun_00008)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_4_X, Fix.CAVEOFSARUN_Rock_4_Y, Fix.CAVEOFSARUN_Rock_4_Z));
      }
      // 岩壁８
      if (One.TF.FieldObject_CaveofSarun_00009)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.CAVEOFSARUN_Rock_8_X, Fix.CAVEOFSARUN_Rock_8_Y, Fix.CAVEOFSARUN_Rock_8_Z));
      }
    }
    #endregion
    #region "ゴラトラム洞窟"
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM)
    {
      if (One.TF.Treasure_Goratrum_00001)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_1_X, Fix.GORATRUM_Treasure_1_Y, Fix.GORATRUM_Treasure_1_Z)));
      }
      if (One.TF.Treasure_Goratrum_00002)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_2_X, Fix.GORATRUM_Treasure_2_Y, Fix.GORATRUM_Treasure_2_Z)));
      }
      if (One.TF.Treasure_Goratrum_00003)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_3_X, Fix.GORATRUM_Treasure_3_Y, Fix.GORATRUM_Treasure_3_Z)));
      }
      if (One.TF.Treasure_Goratrum_00004)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_4_X, Fix.GORATRUM_Treasure_4_Y, Fix.GORATRUM_Treasure_4_Z)));
      }
      if (One.TF.Treasure_Goratrum_00005)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_5_X, Fix.GORATRUM_Treasure_5_Y, Fix.GORATRUM_Treasure_5_Z)));
      }
      if (One.TF.Treasure_Goratrum_00006)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_6_X, Fix.GORATRUM_Treasure_6_Y, Fix.GORATRUM_Treasure_6_Z)));
      }
      if (One.TF.Treasure_Goratrum_00007)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_7_X, Fix.GORATRUM_Treasure_7_Y, Fix.GORATRUM_Treasure_7_Z)));
      }
      if (One.TF.Treasure_Goratrum_00008)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_8_X, Fix.GORATRUM_Treasure_8_Y, Fix.GORATRUM_Treasure_8_Z)));
      }
      if (One.TF.Treasure_Goratrum_00009)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_9_X, Fix.GORATRUM_Treasure_9_Y, Fix.GORATRUM_Treasure_9_Z)));
      }
      if (One.TF.Treasure_Goratrum_00010)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_10_X, Fix.GORATRUM_Treasure_10_Y, Fix.GORATRUM_Treasure_10_Z)));
      }
      if (One.TF.Treasure_Goratrum_00011)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_Treasure_11_X, Fix.GORATRUM_Treasure_11_Y, Fix.GORATRUM_Treasure_11_Z)));
      }

      if (One.TF.FieldObject_Goratrum_00001)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GORATRUM_CopperDoor_1_X, Fix.GORATRUM_CopperDoor_1_Y, Fix.GORATRUM_CopperDoor_1_Z));
      }

      if (One.TF.FieldObject_Goratrum_00002)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GORATRUM_CopperDoor_3_X, Fix.GORATRUM_CopperDoor_3_Y, Fix.GORATRUM_CopperDoor_3_Z));
      }

      if (One.TF.FieldObject_Goratrum_00003)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GORATRUM_CopperDoor_2_X, Fix.GORATRUM_CopperDoor_2_Y, Fix.GORATRUM_CopperDoor_2_Z));
      }
    }
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
    {
      if (One.TF.Treasure_Goratrum2_00001)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_2_Treasure_1_X, Fix.GORATRUM_2_Treasure_1_Y, Fix.GORATRUM_2_Treasure_1_Z)));
      }
      if (One.TF.Treasure_Goratrum2_00002)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_2_Treasure_2_X, Fix.GORATRUM_2_Treasure_2_Y, Fix.GORATRUM_2_Treasure_2_Z)));
      }
      if (One.TF.Treasure_Goratrum2_00003)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_2_Treasure_3_X, Fix.GORATRUM_2_Treasure_3_Y, Fix.GORATRUM_2_Treasure_3_Z)));
      }
      if (One.TF.Treasure_Goratrum2_00004)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GORATRUM_2_Treasure_4_X, Fix.GORATRUM_2_Treasure_4_Y, Fix.GORATRUM_2_Treasure_4_Z)));
      }

      if (One.TF.Event_Message600180)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GORATRUM_2_ObsidianPortal_1_X, Fix.GORATRUM_2_ObsidianPortal_1_Y, Fix.GORATRUM_2_ObsidianPortal_1_Z));
      }
    }
    #endregion
    #region "アーサリウム工場跡地"
    if (map_data == Fix.MAPFILE_ARTHARIUM)
    {
      Debug.Log("update " + map_data + " field");
      // 宝箱１
      if (One.TF.Treasure_Artharium_00001)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_2_X, Fix.ARTHARIUM_Treasure_2_Y, Fix.ARTHARIUM_Treasure_2_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２
      if (One.TF.Treasure_Artharium_00002)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_8_X, Fix.ARTHARIUM_Treasure_8_Y, Fix.ARTHARIUM_Treasure_8_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３
      if (One.TF.Treasure_Artharium_00003)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_9_X, Fix.ARTHARIUM_Treasure_9_Y, Fix.ARTHARIUM_Treasure_9_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱４
      if (One.TF.Treasure_Artharium_00004)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_10_X, Fix.ARTHARIUM_Treasure_10_Y, Fix.ARTHARIUM_Treasure_10_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱５
      if (One.TF.Treasure_Artharium_00005)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_11_X, Fix.ARTHARIUM_Treasure_11_Y, Fix.ARTHARIUM_Treasure_11_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱６
      if (One.TF.Treasure_Artharium_00006)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_12_X, Fix.ARTHARIUM_Treasure_12_Y, Fix.ARTHARIUM_Treasure_12_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱７
      if (One.TF.Treasure_Artharium_00007)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_13_X, Fix.ARTHARIUM_Treasure_13_Y, Fix.ARTHARIUM_Treasure_13_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱８
      if (One.TF.Treasure_Artharium_00008)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_14_X, Fix.ARTHARIUM_Treasure_14_Y, Fix.ARTHARIUM_Treasure_14_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱９
      if (One.TF.Treasure_Artharium_00009)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_3_X, Fix.ARTHARIUM_Treasure_3_Y, Fix.ARTHARIUM_Treasure_3_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１０
      if (One.TF.Treasure_Artharium_00010)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_15_X, Fix.ARTHARIUM_Treasure_15_Y, Fix.ARTHARIUM_Treasure_15_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１１
      if (One.TF.Treasure_Artharium_00011)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_16_X, Fix.ARTHARIUM_Treasure_16_Y, Fix.ARTHARIUM_Treasure_16_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１２
      if (One.TF.Treasure_Artharium_00012)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_17_X, Fix.ARTHARIUM_Treasure_17_Y, Fix.ARTHARIUM_Treasure_17_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１３
      if (One.TF.Treasure_Artharium_00013)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_18_X, Fix.ARTHARIUM_Treasure_18_Y, Fix.ARTHARIUM_Treasure_18_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１４
      if (One.TF.Treasure_Artharium_00014)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_19_X, Fix.ARTHARIUM_Treasure_19_Y, Fix.ARTHARIUM_Treasure_19_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１５
      if (One.TF.Treasure_Artharium_00015)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_20_X, Fix.ARTHARIUM_Treasure_20_Y, Fix.ARTHARIUM_Treasure_20_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１６
      if (One.TF.Treasure_Artharium_00016)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_21_X, Fix.ARTHARIUM_Treasure_21_Y, Fix.ARTHARIUM_Treasure_21_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１７
      if (One.TF.Treasure_Artharium_00017)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_22_X, Fix.ARTHARIUM_Treasure_22_Y, Fix.ARTHARIUM_Treasure_22_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１８
      if (One.TF.Treasure_Artharium_00018)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_23_X, Fix.ARTHARIUM_Treasure_23_Y, Fix.ARTHARIUM_Treasure_23_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１９
      if (One.TF.Treasure_Artharium_00019)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_24_X, Fix.ARTHARIUM_Treasure_24_Y, Fix.ARTHARIUM_Treasure_24_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２０
      if (One.TF.Treasure_Artharium_00020)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_25_X, Fix.ARTHARIUM_Treasure_25_Y, Fix.ARTHARIUM_Treasure_25_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２１
      if (One.TF.Treasure_Artharium_00021)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_26_X, Fix.ARTHARIUM_Treasure_26_Y, Fix.ARTHARIUM_Treasure_26_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２２
      if (One.TF.Treasure_Artharium_00022)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_27_X, Fix.ARTHARIUM_Treasure_27_Y, Fix.ARTHARIUM_Treasure_27_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２３
      if (One.TF.Treasure_Artharium_00023)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_6_X, Fix.ARTHARIUM_Treasure_6_Y, Fix.ARTHARIUM_Treasure_6_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２４
      if (One.TF.Treasure_Artharium_00024)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_5_X, Fix.ARTHARIUM_Treasure_5_Y, Fix.ARTHARIUM_Treasure_5_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２５
      if (One.TF.Treasure_Artharium_00025)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ARTHARIUM_Treasure_7_X, Fix.ARTHARIUM_Treasure_7_Y, Fix.ARTHARIUM_Treasure_7_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }

      // 岩壁１
      if (One.TF.FieldObject_Artharium_00001)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_1_X, Fix.ARTHARIUM_Rock_1_Y, Fix.ARTHARIUM_Rock_1_Z));
      }
      // 岩壁２
      if (One.TF.FieldObject_Artharium_00002)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_2_X, Fix.ARTHARIUM_Rock_2_Y, Fix.ARTHARIUM_Rock_2_Z));
      }
      // 岩壁３
      if (One.TF.FieldObject_Artharium_00003)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_3_X, Fix.ARTHARIUM_Rock_3_Y, Fix.ARTHARIUM_Rock_3_Z));
      }
      // 岩壁４
      if (One.TF.FieldObject_Artharium_00004)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_4_X, Fix.ARTHARIUM_Rock_4_Y, Fix.ARTHARIUM_Rock_4_Z));
      }
      // 岩壁５
      if (One.TF.FieldObject_Artharium_00005)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_5_X, Fix.ARTHARIUM_Rock_5_Y, Fix.ARTHARIUM_Rock_5_Z));
      }

      // 扉１
      if (One.TF.FieldObject_Artharium_00006)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_1_X, Fix.ARTHARIUM_Door_Copper_1_Y, Fix.ARTHARIUM_Door_Copper_1_Z));
      }
      // 扉２
      if (One.TF.FieldObject_Artharium_00007)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_2_X, Fix.ARTHARIUM_Door_Copper_2_Y, Fix.ARTHARIUM_Door_Copper_2_Z));
      }
      // 扉３
      if (One.TF.FieldObject_Artharium_00008)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_3_X, Fix.ARTHARIUM_Door_Copper_3_Y, Fix.ARTHARIUM_Door_Copper_3_Z));
      }
      // 岩壁６
      if (One.TF.FieldObject_Artharium_00009)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Rock_6_X, Fix.ARTHARIUM_Rock_6_Y, Fix.ARTHARIUM_Rock_6_Z));
      }
      // 扉４と５
      if (One.TF.FieldObject_Artharium_00010)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_4_X, Fix.ARTHARIUM_Door_Copper_4_Y, Fix.ARTHARIUM_Door_Copper_4_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_Door_Copper_5_X, Fix.ARTHARIUM_Door_Copper_5_Y, Fix.ARTHARIUM_Door_Copper_5_Z));
      }
      // 奇妙な物体の入手
      if (One.TF.Obsidian_Artharium_00001)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ARTHARIUM_ObsidianStone_1_X, Fix.ARTHARIUM_ObsidianStone_1_Y, Fix.ARTHARIUM_ObsidianStone_1_Z));
      }
    }
    #endregion
    #region "オーランの塔"
    else if (map_data == Fix.MAPFILE_OHRAN_TOWER)
    {
      if (One.TF.FieldObject_OhranTower_00001)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_1_X, Fix.OHRANTOWER_FloatingTile_1_Y, Fix.OHRANTOWER_FloatingTile_1_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_1_X, Fix.OHRANTOWER_FloatingTile_1_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_1_Z));
      }
      if (One.TF.FieldObject_OhranTower_00002)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_2_X, Fix.OHRANTOWER_FloatingTile_2_Y, Fix.OHRANTOWER_FloatingTile_2_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_2_X, Fix.OHRANTOWER_FloatingTile_2_Y + 12.0f, Fix.OHRANTOWER_FloatingTile_2_Z));
      }
      if (One.TF.FieldObject_OhranTower_00003)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_5_X, Fix.OHRANTOWER_FloatingTile_5_Y, Fix.OHRANTOWER_FloatingTile_5_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_5_X, Fix.OHRANTOWER_FloatingTile_5_Y, Fix.OHRANTOWER_FloatingTile_5_Z + 10.0f));
      }
      if (One.TF.FieldObject_OhranTower_00004)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_8_X, Fix.OHRANTOWER_FloatingTile_8_Y, Fix.OHRANTOWER_FloatingTile_8_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_8_X - 11.0f, Fix.OHRANTOWER_FloatingTile_8_Y, Fix.OHRANTOWER_FloatingTile_8_Z));
      }
      if (One.TF.FieldObject_OhranTower_00005)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_9_X, Fix.OHRANTOWER_FloatingTile_9_Y, Fix.OHRANTOWER_FloatingTile_9_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_9_X, Fix.OHRANTOWER_FloatingTile_9_Y, Fix.OHRANTOWER_FloatingTile_9_Z - 11.0f));
      }
      if (One.TF.FieldObject_OhranTower_00006)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_4_X, Fix.OHRANTOWER_FloatingTile_4_Y, Fix.OHRANTOWER_FloatingTile_4_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_4_X, Fix.OHRANTOWER_FloatingTile_4_Y, Fix.OHRANTOWER_FloatingTile_4_Z + 13.0f));
      }
      if (One.TF.FieldObject_OhranTower_00007)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_6_X, Fix.OHRANTOWER_FloatingTile_6_Y, Fix.OHRANTOWER_FloatingTile_6_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_6_X + 7.0f, Fix.OHRANTOWER_FloatingTile_6_Y, Fix.OHRANTOWER_FloatingTile_6_Z));
      }
      if (One.TF.FieldObject_OhranTower_00008)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_7_X, Fix.OHRANTOWER_FloatingTile_7_Y, Fix.OHRANTOWER_FloatingTile_7_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_7_X, Fix.OHRANTOWER_FloatingTile_7_Y, Fix.OHRANTOWER_FloatingTile_7_Z - 11.0f));
      }
      if (One.TF.FieldObject_OhranTower_00009)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_10_X, Fix.OHRANTOWER_FloatingTile_10_Y, Fix.OHRANTOWER_FloatingTile_10_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_10_X - 3.0f, Fix.OHRANTOWER_FloatingTile_10_Y, Fix.OHRANTOWER_FloatingTile_10_Z));
      }
      if (One.TF.FieldObject_OhranTower_00010)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_11_X, Fix.OHRANTOWER_FloatingTile_11_Y, Fix.OHRANTOWER_FloatingTile_11_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_11_X - 45.0f, Fix.OHRANTOWER_FloatingTile_11_Y, Fix.OHRANTOWER_FloatingTile_11_Z));
      }
      if (One.TF.FieldObject_OhranTower_00011)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_3_X, Fix.OHRANTOWER_FloatingTile_3_Y, Fix.OHRANTOWER_FloatingTile_3_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_3_X, Fix.OHRANTOWER_FloatingTile_3_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_3_Z));
      }
      if (One.TF.FieldObject_OhranTower_00012)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_12_X, Fix.OHRANTOWER_FloatingTile_12_Y, Fix.OHRANTOWER_FloatingTile_12_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_12_X, Fix.OHRANTOWER_FloatingTile_12_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_12_Z));
      }
      if (One.TF.FieldObject_OhranTower_00013)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_13_X, Fix.OHRANTOWER_FloatingTile_13_Y, Fix.OHRANTOWER_FloatingTile_13_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_13_X, Fix.OHRANTOWER_FloatingTile_13_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_13_Z));
      }
      if (One.TF.FieldObject_OhranTower_00014)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_14_X, Fix.OHRANTOWER_FloatingTile_14_Y, Fix.OHRANTOWER_FloatingTile_14_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_14_X + 7.0f, Fix.OHRANTOWER_FloatingTile_14_Y, Fix.OHRANTOWER_FloatingTile_14_Z));
      }
      if (One.TF.FieldObject_OhranTower_00015)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_15_X, Fix.OHRANTOWER_FloatingTile_15_Y, Fix.OHRANTOWER_FloatingTile_15_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_15_X, Fix.OHRANTOWER_FloatingTile_15_Y, Fix.OHRANTOWER_FloatingTile_15_Z - 7.0f));
      }
      if (One.TF.FieldObject_OhranTower_00016)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_16_X, Fix.OHRANTOWER_FloatingTile_16_Y, Fix.OHRANTOWER_FloatingTile_16_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_16_X, Fix.OHRANTOWER_FloatingTile_16_Y, Fix.OHRANTOWER_FloatingTile_16_Z - 7.0f));
      }
      if (One.TF.FieldObject_OhranTower_00017)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_17_X, Fix.OHRANTOWER_FloatingTile_17_Y, Fix.OHRANTOWER_FloatingTile_17_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_17_X - 7.0f, Fix.OHRANTOWER_FloatingTile_17_Y, Fix.OHRANTOWER_FloatingTile_17_Z));
      }
      if (One.TF.FieldObject_OhranTower_00018)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_18_X, Fix.OHRANTOWER_FloatingTile_18_Y, Fix.OHRANTOWER_FloatingTile_18_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_18_X - 7.0f, Fix.OHRANTOWER_FloatingTile_18_Y, Fix.OHRANTOWER_FloatingTile_18_Z));
      }
      if (One.TF.FieldObject_OhranTower_00019)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_19_X, Fix.OHRANTOWER_FloatingTile_19_Y, Fix.OHRANTOWER_FloatingTile_19_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_19_X, Fix.OHRANTOWER_FloatingTile_19_Y, Fix.OHRANTOWER_FloatingTile_19_Z + 5.0f));
      }
      if (One.TF.FieldObject_OhranTower_00020)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_20_X, Fix.OHRANTOWER_FloatingTile_20_Y, Fix.OHRANTOWER_FloatingTile_20_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_20_X + 2.0f, Fix.OHRANTOWER_FloatingTile_20_Y, Fix.OHRANTOWER_FloatingTile_20_Z));
      }
      if (One.TF.FieldObject_OhranTower_00021)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_21_X, Fix.OHRANTOWER_FloatingTile_21_Y, Fix.OHRANTOWER_FloatingTile_21_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_21_X + 5.0f, Fix.OHRANTOWER_FloatingTile_21_Y, Fix.OHRANTOWER_FloatingTile_21_Z));
      }
      if (One.TF.FieldObject_OhranTower_00022)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_22_X, Fix.OHRANTOWER_FloatingTile_22_Y, Fix.OHRANTOWER_FloatingTile_22_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_22_X, Fix.OHRANTOWER_FloatingTile_22_Y, Fix.OHRANTOWER_FloatingTile_22_Z + 16.0f));
      }
      if (One.TF.FieldObject_OhranTower_00023)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_23_X, Fix.OHRANTOWER_FloatingTile_23_Y, Fix.OHRANTOWER_FloatingTile_23_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_23_X - 6.0f, Fix.OHRANTOWER_FloatingTile_23_Y, Fix.OHRANTOWER_FloatingTile_23_Z));
      }
      if (One.TF.FieldObject_OhranTower_00024)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_24_X, Fix.OHRANTOWER_FloatingTile_24_Y, Fix.OHRANTOWER_FloatingTile_24_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_24_X, Fix.OHRANTOWER_FloatingTile_24_Y, Fix.OHRANTOWER_FloatingTile_24_Z - 2.0f));
      }
      if (One.TF.FieldObject_OhranTower_00025)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_25_X, Fix.OHRANTOWER_FloatingTile_25_Y, Fix.OHRANTOWER_FloatingTile_25_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_25_X - 4.0f, Fix.OHRANTOWER_FloatingTile_25_Y, Fix.OHRANTOWER_FloatingTile_25_Z));
      }
      if (One.TF.FieldObject_OhranTower_00026)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_26_X, Fix.OHRANTOWER_FloatingTile_26_Y, Fix.OHRANTOWER_FloatingTile_26_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_26_X, Fix.OHRANTOWER_FloatingTile_26_Y, Fix.OHRANTOWER_FloatingTile_26_Z - 4.0f));
      }
      if (One.TF.FieldObject_OhranTower_00027)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_27_X, Fix.OHRANTOWER_FloatingTile_27_Y, Fix.OHRANTOWER_FloatingTile_27_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_27_X + 4.0f, Fix.OHRANTOWER_FloatingTile_27_Y, Fix.OHRANTOWER_FloatingTile_27_Z));
      }
      if (One.TF.FieldObject_OhranTower_00028)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_28_X, Fix.OHRANTOWER_FloatingTile_28_Y, Fix.OHRANTOWER_FloatingTile_28_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_28_X + 2.0f, Fix.OHRANTOWER_FloatingTile_28_Y, Fix.OHRANTOWER_FloatingTile_28_Z));
      }
      if (One.TF.FieldObject_OhranTower_00029)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_29_X, Fix.OHRANTOWER_FloatingTile_29_Y, Fix.OHRANTOWER_FloatingTile_29_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_29_X, Fix.OHRANTOWER_FloatingTile_29_Y - 8.0f, Fix.OHRANTOWER_FloatingTile_29_Z));
      }
      if (One.TF.FieldObject_OhranTower_00030)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_30_X, Fix.OHRANTOWER_FloatingTile_30_Y, Fix.OHRANTOWER_FloatingTile_30_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_30_X, Fix.OHRANTOWER_FloatingTile_30_Y + 8.0f, Fix.OHRANTOWER_FloatingTile_30_Z));
      }
      if (One.TF.FieldObject_OhranTower_00031)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_31_X, Fix.OHRANTOWER_FloatingTile_31_Y, Fix.OHRANTOWER_FloatingTile_31_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_31_X, Fix.OHRANTOWER_FloatingTile_31_Y - 63.0f, Fix.OHRANTOWER_FloatingTile_31_Z));
      }
      if (One.TF.FieldObject_OhranTower_00032)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FloatingTile_32_X, Fix.OHRANTOWER_FloatingTile_32_Y, Fix.OHRANTOWER_FloatingTile_32_Z), new Vector3(Fix.OHRANTOWER_FloatingTile_32_X, Fix.OHRANTOWER_FloatingTile_32_Y, Fix.OHRANTOWER_FloatingTile_32_Z - 18.0f));
      }

      // 宝箱１
      if (One.TF.Treasure_OhranTower_00001)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_1_X, Fix.OHRANTOWER_Treasure_1_Y, Fix.OHRANTOWER_Treasure_1_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２
      if (One.TF.Treasure_OhranTower_00002)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_2_X, Fix.OHRANTOWER_Treasure_2_Y, Fix.OHRANTOWER_Treasure_2_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３
      if (One.TF.Treasure_OhranTower_00003)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_3_X, Fix.OHRANTOWER_Treasure_3_Y, Fix.OHRANTOWER_Treasure_3_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱４
      if (One.TF.Treasure_OhranTower_00004)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_4_X, Fix.OHRANTOWER_Treasure_4_Y, Fix.OHRANTOWER_Treasure_4_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱５
      if (One.TF.Treasure_OhranTower_00005)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_5_X, Fix.OHRANTOWER_Treasure_5_Y, Fix.OHRANTOWER_Treasure_5_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱６
      if (One.TF.Treasure_OhranTower_00006)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_6_X, Fix.OHRANTOWER_Treasure_6_Y, Fix.OHRANTOWER_Treasure_6_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱７
      if (One.TF.Treasure_OhranTower_00007)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_7_X, Fix.OHRANTOWER_Treasure_7_Y, Fix.OHRANTOWER_Treasure_7_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱８
      if (One.TF.Treasure_OhranTower_00008)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_8_X, Fix.OHRANTOWER_Treasure_8_Y, Fix.OHRANTOWER_Treasure_8_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱９
      if (One.TF.Treasure_OhranTower_00009)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_9_X, Fix.OHRANTOWER_Treasure_9_Y, Fix.OHRANTOWER_Treasure_9_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１０
      if (One.TF.Treasure_OhranTower_00010)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_10_X, Fix.OHRANTOWER_Treasure_10_Y, Fix.OHRANTOWER_Treasure_10_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１１
      if (One.TF.Treasure_OhranTower_00011)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_11_X, Fix.OHRANTOWER_Treasure_11_Y, Fix.OHRANTOWER_Treasure_11_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１２
      if (One.TF.Treasure_OhranTower_00012)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_12_X, Fix.OHRANTOWER_Treasure_12_Y, Fix.OHRANTOWER_Treasure_12_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１３
      if (One.TF.Treasure_OhranTower_00013)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_13_X, Fix.OHRANTOWER_Treasure_13_Y, Fix.OHRANTOWER_Treasure_13_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１４
      if (One.TF.Treasure_OhranTower_00014)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_14_X, Fix.OHRANTOWER_Treasure_14_Y, Fix.OHRANTOWER_Treasure_14_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１５
      if (One.TF.Treasure_OhranTower_00015)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_15_X, Fix.OHRANTOWER_Treasure_15_Y, Fix.OHRANTOWER_Treasure_15_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１６
      if (One.TF.Treasure_OhranTower_00016)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_16_X, Fix.OHRANTOWER_Treasure_16_Y, Fix.OHRANTOWER_Treasure_16_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１７
      if (One.TF.Treasure_OhranTower_00017)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_17_X, Fix.OHRANTOWER_Treasure_17_Y, Fix.OHRANTOWER_Treasure_17_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１８
      if (One.TF.Treasure_OhranTower_00018)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_18_X, Fix.OHRANTOWER_Treasure_18_Y, Fix.OHRANTOWER_Treasure_18_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱１９
      if (One.TF.Treasure_OhranTower_00019)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_19_X, Fix.OHRANTOWER_Treasure_19_Y, Fix.OHRANTOWER_Treasure_19_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２０
      if (One.TF.Treasure_OhranTower_00020)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_20_X, Fix.OHRANTOWER_Treasure_20_Y, Fix.OHRANTOWER_Treasure_20_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２１
      if (One.TF.Treasure_OhranTower_00021)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_21_X, Fix.OHRANTOWER_Treasure_21_Y, Fix.OHRANTOWER_Treasure_21_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２２
      if (One.TF.Treasure_OhranTower_00022)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_22_X, Fix.OHRANTOWER_Treasure_22_Y, Fix.OHRANTOWER_Treasure_22_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２３
      if (One.TF.Treasure_OhranTower_00023)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_23_X, Fix.OHRANTOWER_Treasure_23_Y, Fix.OHRANTOWER_Treasure_23_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
    }
    #endregion
    #region "ダルの門"
    else if (map_data == Fix.MAPFILE_GATE_OF_DHAL)
    {
      // 扉１（右エリア、入口）
      if (One.TF.Fieldobject_GateDhal_00001)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Door_1_X, Fix.GATEOFDHAL_DhalGate_Door_1_Y, Fix.GATEOFDHAL_DhalGate_Door_1_Z));
      }
      // 扉２（左エリア、入口）
      if (One.TF.Fieldobject_GateDhal_00002)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Door_2_X, Fix.GATEOFDHAL_DhalGate_Door_2_Y, Fix.GATEOFDHAL_DhalGate_Door_2_Z));
      }
      // 扉３（正面通路）
      if (One.TF.Fieldobject_GateDhal_00003)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Door_3_X, Fix.GATEOFDHAL_DhalGate_Door_3_Y, Fix.GATEOFDHAL_DhalGate_Door_3_Z));
      }

      // 床タイル浮上（右エリア階層１－１）
      if (One.TF.Fieldobject_GateDhal_00004 == false)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_1_X, Fix.GATEOFDHAL_DhalGate_Tile_1_Y, Fix.GATEOFDHAL_DhalGate_Tile_1_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_2_X, Fix.GATEOFDHAL_DhalGate_Tile_2_Y, Fix.GATEOFDHAL_DhalGate_Tile_2_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_3_X, Fix.GATEOFDHAL_DhalGate_Tile_3_Y, Fix.GATEOFDHAL_DhalGate_Tile_3_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_4_X, Fix.GATEOFDHAL_DhalGate_Tile_4_Y, Fix.GATEOFDHAL_DhalGate_Tile_4_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_5_X, Fix.GATEOFDHAL_DhalGate_Tile_5_Y, Fix.GATEOFDHAL_DhalGate_Tile_5_Z));
      }
      // 床タイル浮上（左エリア階層１－１）
      if (One.TF.Fieldobject_GateDhal_00005 == false)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_6_X, Fix.GATEOFDHAL_DhalGate_Tile_6_Y, Fix.GATEOFDHAL_DhalGate_Tile_6_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_7_X, Fix.GATEOFDHAL_DhalGate_Tile_7_Y, Fix.GATEOFDHAL_DhalGate_Tile_7_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_8_X, Fix.GATEOFDHAL_DhalGate_Tile_8_Y, Fix.GATEOFDHAL_DhalGate_Tile_8_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_9_X, Fix.GATEOFDHAL_DhalGate_Tile_9_Y, Fix.GATEOFDHAL_DhalGate_Tile_9_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_10_X, Fix.GATEOFDHAL_DhalGate_Tile_10_Y, Fix.GATEOFDHAL_DhalGate_Tile_10_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.GATEOFDHAL_DhalGate_Tile_11_X, Fix.GATEOFDHAL_DhalGate_Tile_11_Y, Fix.GATEOFDHAL_DhalGate_Tile_11_Z));
      }

      // 宝箱
      if (One.TF.Treasure_GateDhal_00001)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_1_X, Fix.GATEOFDHAL_Treasure_1_Y, Fix.GATEOFDHAL_Treasure_1_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00002)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_2_X, Fix.GATEOFDHAL_Treasure_2_Y, Fix.GATEOFDHAL_Treasure_2_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00003)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_3_X, Fix.GATEOFDHAL_Treasure_3_Y, Fix.GATEOFDHAL_Treasure_3_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00004)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_4_X, Fix.GATEOFDHAL_Treasure_4_Y, Fix.GATEOFDHAL_Treasure_4_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00005)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_5_X, Fix.GATEOFDHAL_Treasure_5_Y, Fix.GATEOFDHAL_Treasure_5_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00006)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_6_X, Fix.GATEOFDHAL_Treasure_6_Y, Fix.GATEOFDHAL_Treasure_6_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00007)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_7_X, Fix.GATEOFDHAL_Treasure_7_Y, Fix.GATEOFDHAL_Treasure_7_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00008)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_8_X, Fix.GATEOFDHAL_Treasure_8_Y, Fix.GATEOFDHAL_Treasure_8_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00009)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_9_X, Fix.GATEOFDHAL_Treasure_9_Y, Fix.GATEOFDHAL_Treasure_9_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00010)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_10_X, Fix.GATEOFDHAL_Treasure_10_Y, Fix.GATEOFDHAL_Treasure_10_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00011)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_11_X, Fix.GATEOFDHAL_Treasure_11_Y, Fix.GATEOFDHAL_Treasure_11_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00012)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_12_X, Fix.GATEOFDHAL_Treasure_12_Y, Fix.GATEOFDHAL_Treasure_12_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00013)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_13_X, Fix.GATEOFDHAL_Treasure_13_Y, Fix.GATEOFDHAL_Treasure_13_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00014)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_14_X, Fix.GATEOFDHAL_Treasure_14_Y, Fix.GATEOFDHAL_Treasure_14_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00015)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_15_X, Fix.GATEOFDHAL_Treasure_15_Y, Fix.GATEOFDHAL_Treasure_15_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00016)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_16_X, Fix.GATEOFDHAL_Treasure_16_Y, Fix.GATEOFDHAL_Treasure_16_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00017)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_17_X, Fix.GATEOFDHAL_Treasure_17_Y, Fix.GATEOFDHAL_Treasure_17_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00018)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_18_X, Fix.GATEOFDHAL_Treasure_18_Y, Fix.GATEOFDHAL_Treasure_18_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00019)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_19_X, Fix.GATEOFDHAL_Treasure_19_Y, Fix.GATEOFDHAL_Treasure_19_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00020)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_20_X, Fix.GATEOFDHAL_Treasure_20_Y, Fix.GATEOFDHAL_Treasure_20_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00021)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_21_X, Fix.GATEOFDHAL_Treasure_21_Y, Fix.GATEOFDHAL_Treasure_21_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00022)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_22_X, Fix.GATEOFDHAL_Treasure_22_Y, Fix.GATEOFDHAL_Treasure_22_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00023)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_23_X, Fix.GATEOFDHAL_Treasure_23_Y, Fix.GATEOFDHAL_Treasure_23_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00024)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_24_X, Fix.GATEOFDHAL_Treasure_24_Y, Fix.GATEOFDHAL_Treasure_24_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00025)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_25_X, Fix.GATEOFDHAL_Treasure_25_Y, Fix.GATEOFDHAL_Treasure_25_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00026)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_26_X, Fix.GATEOFDHAL_Treasure_26_Y, Fix.GATEOFDHAL_Treasure_26_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00027)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_27_X, Fix.GATEOFDHAL_Treasure_27_Y, Fix.GATEOFDHAL_Treasure_27_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00028)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_28_X, Fix.GATEOFDHAL_Treasure_28_Y, Fix.GATEOFDHAL_Treasure_28_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00029)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_29_X, Fix.GATEOFDHAL_Treasure_29_Y, Fix.GATEOFDHAL_Treasure_29_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00030)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_30_X, Fix.GATEOFDHAL_Treasure_30_Y, Fix.GATEOFDHAL_Treasure_30_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00031)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_31_X, Fix.GATEOFDHAL_Treasure_31_Y, Fix.GATEOFDHAL_Treasure_31_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00032)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_32_X, Fix.GATEOFDHAL_Treasure_32_Y, Fix.GATEOFDHAL_Treasure_32_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00033)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_33_X, Fix.GATEOFDHAL_Treasure_33_Y, Fix.GATEOFDHAL_Treasure_33_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00034)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_34_X, Fix.GATEOFDHAL_Treasure_34_Y, Fix.GATEOFDHAL_Treasure_34_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00035)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_35_X, Fix.GATEOFDHAL_Treasure_35_Y, Fix.GATEOFDHAL_Treasure_35_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00036)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_36_X, Fix.GATEOFDHAL_Treasure_36_Y, Fix.GATEOFDHAL_Treasure_36_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00037)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_37_X, Fix.GATEOFDHAL_Treasure_37_Y, Fix.GATEOFDHAL_Treasure_37_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00038)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_38_X, Fix.GATEOFDHAL_Treasure_38_Y, Fix.GATEOFDHAL_Treasure_38_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00039)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_39_X, Fix.GATEOFDHAL_Treasure_39_Y, Fix.GATEOFDHAL_Treasure_39_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00040)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_40_X, Fix.GATEOFDHAL_Treasure_40_Y, Fix.GATEOFDHAL_Treasure_40_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00041)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_41_X, Fix.GATEOFDHAL_Treasure_41_Y, Fix.GATEOFDHAL_Treasure_41_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00042)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_42_X, Fix.GATEOFDHAL_Treasure_42_Y, Fix.GATEOFDHAL_Treasure_42_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00043)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_43_X, Fix.GATEOFDHAL_Treasure_43_Y, Fix.GATEOFDHAL_Treasure_43_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00044)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_44_X, Fix.GATEOFDHAL_Treasure_44_Y, Fix.GATEOFDHAL_Treasure_44_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00045)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_45_X, Fix.GATEOFDHAL_Treasure_45_Y, Fix.GATEOFDHAL_Treasure_45_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00046)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_46_X, Fix.GATEOFDHAL_Treasure_46_Y, Fix.GATEOFDHAL_Treasure_46_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00047)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_47_X, Fix.GATEOFDHAL_Treasure_47_Y, Fix.GATEOFDHAL_Treasure_47_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00048)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_48_X, Fix.GATEOFDHAL_Treasure_48_Y, Fix.GATEOFDHAL_Treasure_48_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00049)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_49_X, Fix.GATEOFDHAL_Treasure_49_Y, Fix.GATEOFDHAL_Treasure_49_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00050)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_50_X, Fix.GATEOFDHAL_Treasure_50_Y, Fix.GATEOFDHAL_Treasure_50_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      if (One.TF.Treasure_GateDhal_00051)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.GATEOFDHAL_Treasure_51_X, Fix.GATEOFDHAL_Treasure_51_Y, Fix.GATEOFDHAL_Treasure_51_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
    }
    #endregion
  }

  private void MoveFieldObject(List<FieldObject> list, Vector3 src, Vector3 dst)
  {
    for (int ii = 0; ii < FieldObjList.Count; ii++)
    {
      if (FieldObjList[ii].transform.position == src)
      {
        FieldObject current = FieldObjList[ii];
        current.transform.position = dst;
        Debug.Log("detect field ohran current.transform.position " + current.transform.position.ToString());
        return;
      }
    }

  }

  private void RemoveFieldObject(List<FieldObject> list, Vector3 position)
  {
    for (int ii = 0; ii < FieldObjList.Count; ii++)
    {
      if (FieldObjList[ii].transform.position == position)
      {
        FieldObject current = FieldObjList[ii];
        Debug.Log("RemoveFieldObject[ii] " + ii.ToString());
        list.Remove(current);
        Destroy(current.gameObject);
        return;
      }
    }

    Debug.Log("RemoveFieldObject not found...");
  }

  private void ExchangeFieldObject(List<FieldObject> list,  FieldObject new_prefab, int num)
  {
    if (num <= -1) { Debug.Log("ExchangeFieldObject(S) num less than -1, then no action..."); return; }

    //for (int ii = 0; ii < FieldObjList.Count; ii++)
    //{
    //  Debug.Log("obj " + ii.ToString() + " " + FieldObjList[ii].ObjectName + " " + FieldObjList[ii].transform.position.ToString());
    //}

    string objectId = list[num].ObjectId;

    Vector3 current = list[num].transform.position;
    Destroy(list[num].gameObject);
    list.RemoveAt(num);

    FieldObject newCurrent = Instantiate(new_prefab, current, Quaternion.identity) as FieldObject;
    newCurrent.ObjectId = objectId;
    newCurrent.transform.SetParent(this.transform);
    newCurrent.transform.rotation = new_prefab.transform.rotation;
    newCurrent.gameObject.SetActive(true);
    list.Insert(num, newCurrent);

    //for (int ii = 0; ii < FieldObjList.Count; ii++)
    //{
    //  Debug.Log("obj " + ii.ToString() + " " + FieldObjList[ii].ObjectName + " " + FieldObjList[ii].transform.position.ToString());
    //}
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
    Debug.Log(MethodBase.GetCurrentMethod());
    // プレイヤーリストの反映
    foreach (Transform n in GroupCharacterList.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    PlayerList.Clear();
    MiniCharaList.Clear();

    List<Character> list = One.AvailableCharacters;
    for (int ii = 0; ii < list.Count; ii++)
    {
      NodeMiniChara current = Instantiate(nodeCharaPanel) as NodeMiniChara;
      current.Refresh(list[ii]);
      current.transform.SetParent(GroupCharacterList.transform);
      MiniCharaList.Add(current);

      PlayerList.Add(list[ii]);
    }
    // 最大人数に満たない場合、GUIレイアウト向けに空のパネルを挿入する。
    if (list.Count < Fix.MAX_TEAM_MEMBER)
    {
      for (int ii = list.Count; ii < Fix.MAX_TEAM_MEMBER; ii++)
      {
        NodeMiniChara node = Instantiate(nodeCharaPanel) as NodeMiniChara;
        node.Refresh(null);
        node.transform.SetParent(GroupCharacterList.transform);
        node.groupParent.SetActive(false);
      }
    }

    // キャラクター情報を画面へ反映
    UpdateCharacterStatus();

    // パーティステータス画面への反映
    SetupStayList();

    // ゴールドへの反映
    txtGold.text = One.TF.Gold.ToString();

    // コマンド設定画面への反映
    SetupActionCommand(PlayerList[0], ActionCommand.CommandCategory.ActionCommand); // [基本行動]が一番左で最初だが、デフォルトはアクションコマンドを表示

    // バックパック情報を画面へ反映
    ParentBackpackView.ConstructBackpackView();

    // フィールドオブジェクトの状態更新
    UpdateFieldObject(One.TF.CurrentDungeonField);

    // 現在位置周辺の未探索タイル更新
    UpdateUnknownTile(Player.transform.position);
  }

  private void RefreshQuestList()
  {
    // same DungeonField, HomeTown
    foreach (Transform n in contentDungeonPlayer.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    int counter = 0;

    // todo
    if (One.TF.QuestMain_00001) { AddQuestEvent(Fix.QUEST_TITLE_1, One.TF.QuestMain_Complete_00001, counter); counter++; }
    if (One.TF.QuestMain_00002) { AddQuestEvent(Fix.QUEST_TITLE_2, One.TF.QuestMain_Complete_00002, counter); counter++; }
    if (One.TF.QuestMain_00003) { AddQuestEvent(Fix.QUEST_TITLE_3, One.TF.QuestMain_Complete_00003, counter); counter++; }
    if (One.TF.QuestMain_00004) { AddQuestEvent(Fix.QUEST_TITLE_4, One.TF.QuestMain_Complete_00004, counter); counter++; }
    if (One.TF.QuestMain_00005) { AddQuestEvent(Fix.QUEST_TITLE_5, One.TF.QuestMain_Complete_00005, counter); counter++; }
    if (One.TF.QuestMain_00006) { AddQuestEvent(Fix.QUEST_TITLE_6, One.TF.QuestMain_Complete_00006, counter); counter++; }
    if (One.TF.QuestMain_00007) { AddQuestEvent(Fix.QUEST_TITLE_7, One.TF.QuestMain_Complete_00007, counter); counter++; }
    if (One.TF.QuestMain_00008) { AddQuestEvent(Fix.QUEST_TITLE_8, One.TF.QuestMain_Complete_00008, counter); counter++; }
    if (One.TF.QuestMain_00009) { AddQuestEvent(Fix.QUEST_TITLE_9, One.TF.QuestMain_Complete_00009, counter); counter++; }
    if (One.TF.QuestMain_00010) { AddQuestEvent(Fix.QUEST_TITLE_10, One.TF.QuestMain_Complete_00010, counter); counter++; }
    if (One.TF.QuestMain_00011) { AddQuestEvent(Fix.QUEST_TITLE_11, One.TF.QuestMain_Complete_00011, counter); counter++; }
    if (One.TF.QuestMain_00020) { AddQuestEvent(Fix.QUEST_TITLE_20, One.TF.QuestMain_Complete_00020, counter); counter++; }
    if (One.TF.QuestMain_00021) { AddQuestEvent(Fix.QUEST_TITLE_21, One.TF.QuestMain_Complete_00021, counter); counter++; }
    if (One.TF.QuestMain_00022) { AddQuestEvent(Fix.QUEST_TITLE_22, One.TF.QuestMain_Complete_00022, counter); counter++; }
    if (One.TF.QuestMain_00023) { AddQuestEvent(Fix.QUEST_TITLE_23, One.TF.QuestMain_Complete_00023, counter); counter++; }
    if (One.TF.QuestMain_00024) { AddQuestEvent(Fix.QUEST_TITLE_24, One.TF.QuestMain_Complete_00024, counter); counter++; }
  }

  private void AddQuestEvent(string quest_name, bool complete, int counter)
  {
    // same DungeonField, HomeTown
    NodeButton button = Instantiate(nodeButton) as NodeButton;
    button.gameObject.transform.SetParent(contentDungeonPlayer.transform);
    button.txtName.text = quest_name;
    button.gameObject.SetActive(true);
    if (complete)
    {
      button.imgFilter.gameObject.SetActive(true);
    }
    contentDungeonPlayer.GetComponent<RectTransform>().sizeDelta = new Vector2(contentDungeonPlayer.GetComponent<RectTransform>().sizeDelta.x, contentDungeonPlayer.GetComponent<RectTransform>().sizeDelta.y + 100);

    ViewQuestEvent(quest_name);

    RectTransform rect = button.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, -5 - counter * 100, 0);
  }

  private void ViewQuestEvent(string quest_name)
  {
    // same DungeonField, HomeTown
    txtEventTitle.text = quest_name;

    if (quest_name == Fix.QUEST_TITLE_1) { txtEventDescription.text = Fix.QUEST_DESC_1; }
    if (quest_name == Fix.QUEST_TITLE_2) { txtEventDescription.text = Fix.QUEST_DESC_2; }
    if (quest_name == Fix.QUEST_TITLE_3) { txtEventDescription.text = Fix.QUEST_DESC_3; }
    if (quest_name == Fix.QUEST_TITLE_4) { txtEventDescription.text = Fix.QUEST_DESC_4; }
    if (quest_name == Fix.QUEST_TITLE_5) { txtEventDescription.text = Fix.QUEST_DESC_5; }
    if (quest_name == Fix.QUEST_TITLE_6) { txtEventDescription.text = Fix.QUEST_DESC_6; }
    if (quest_name == Fix.QUEST_TITLE_7) { txtEventDescription.text = Fix.QUEST_DESC_7; }
    if (quest_name == Fix.QUEST_TITLE_8) { txtEventDescription.text = Fix.QUEST_DESC_8; }
    if (quest_name == Fix.QUEST_TITLE_9) { txtEventDescription.text = Fix.QUEST_DESC_9; }
    if (quest_name == Fix.QUEST_TITLE_10) { txtEventDescription.text = Fix.QUEST_DESC_10; }
    if (quest_name == Fix.QUEST_TITLE_11) { txtEventDescription.text = Fix.QUEST_DESC_11; }
    if (quest_name == Fix.QUEST_TITLE_20) { txtEventDescription.text = Fix.QUEST_DESC_20; }
    if (quest_name == Fix.QUEST_TITLE_21) { txtEventDescription.text = Fix.QUEST_DESC_21; }
    if (quest_name == Fix.QUEST_TITLE_22) { txtEventDescription.text = Fix.QUEST_DESC_22; }
    if (quest_name == Fix.QUEST_TITLE_23) { txtEventDescription.text = Fix.QUEST_DESC_23; }
    if (quest_name == Fix.QUEST_TITLE_24) { txtEventDescription.text = Fix.QUEST_DESC_24; }

    // クエスト到達状況に応じて、テキスト文章を更新する。
    if (quest_name == Fix.QUEST_TITLE_2 && One.TF.Event_Message400030)
    {
      txtEventDescription.text = Fix.QUEST_DESC_2_2;
    }
    if (quest_name == Fix.QUEST_TITLE_2 && One.TF.Event_Message500020)
    {
      txtEventDescription.text = Fix.QUEST_DESC_2_3;
    }

    if (quest_name == Fix.QUEST_TITLE_11 && One.TF.Event_Message800090)
    {
      txtEventDescription.text = Fix.QUEST_DESC_11_2;
    }
    if (quest_name == Fix.QUEST_DESC_21 && One.TF.Event_Message1100010)
    {
      txtEventDescription.text = Fix.QUEST_DESC_21_2;
    }
    if (quest_name == Fix.QUEST_TITLE_24 && One.TF.Event_Message2200020)
    {
      txtEventDescription.text = Fix.QUEST_DESC_24_2;
    }
  }

  private int FindFieldObjectIndex(List<FieldObject> field_obj_list, Vector3 position)
  {
    for (int ii = 0; ii < FieldObjList.Count; ii++)
    {
      if (position == FieldObjList[ii].transform.position)
      {
        return ii;
      }
    }

    return -1;
  }
}
