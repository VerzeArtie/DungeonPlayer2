﻿using System.Collections;
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
  // Blackout
  public GameObject objBlackOut;
  // Whiteout
  public GameObject objWhiteOut;

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
  public TileInformation prefab_Velgus_Normal;
  public TileInformation prefab_Velgus_Wall;
  public TileInformation prefab_Velgus_Sea;
  public TileInformation prefab_Velgus_Number1;
  public TileInformation prefab_Velgus_Number2;
  public TileInformation prefab_Velgus_Number3;
  public TileInformation prefab_Velgus_Number4;
  public TileInformation prefab_Velgus_Number5;
  public TileInformation prefab_Velgus_Number6;
  public TileInformation prefab_Velgus_Number7;
  public TileInformation prefab_Velgus_CircleRed;
  public TileInformation prefab_Velgus_CircleBlue;
  public TileInformation prefab_Velgus_CircleGreen;
  public TileInformation prefab_Velgus_CircleYellow;
  public TileInformation prefab_Upstair;
  public TileInformation prefab_Downstair;
  public TileInformation prefab_Unknown;
  public TileInformation prefab_Unknown_Goratrum;
  public TileInformation prefab_Unknown_MysticForest;
  public TileInformation prefab_Unknown_Velgus;
  public TileInformation prefab_Unknown_Velgus_2;
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
  public FieldObject prefab_MysticForest_EventWall;
  public FieldObject prefab_OhranTower_Door_ShadowMoon;
  public FieldObject prefab_OhranTower_Door_SunBurst;
  public FieldObject prefab_OhranTower_Door_StarDust;
  public FieldObject prefab_OhranTower_Door_OriginRoad;
  public FieldObject prefab_Velgus_WallDoor;
  public FieldObject prefab_Velgus_SecretWall;
  public FieldObject prefab_Velgus_FakeSea;
  public FieldObject prefab_Velgus_BallRed;
  public FieldObject prefab_Velgus_BallBlue;
  public FieldObject prefab_Velgus_BallGreen;
  public FieldObject prefab_Velgus_BallYellow;
  public FieldObject prefab_Velgus_CircleRedObj;
  public FieldObject prefab_Velgus_CircleBlueObj;
  public FieldObject prefab_Velgus_CircleGreenObj;
  public FieldObject prefab_Velgus_CircleYellowObj;
  public FieldObject prefab_Velgus_SlidingTile;
  public FieldObject prefab_Velgus_FixedTile;
  public FieldObject prefab_Velgus_MovingTile1;
  public FieldObject prefab_Velgus_MovingTile2;
  public FieldObject prefab_Velgus_MovingTile3;
  public FieldObject prefab_Velgus_MovingTile4;
  public FieldObject prefab_Velgus_MovingTile5;
  public FieldObject prefab_Velgus_MovingTile2_1;
  public FieldObject prefab_Velgus_MovingTile2_2;
  public FieldObject prefab_Velgus_MovingTile2_3;
  public FieldObject prefab_Velgus_MovingTile2_4;
  public FieldObject prefab_Velgus_MovingTile2_5;
  public FieldObject prefab_Velgus_MovingTile2_6;
  public FieldObject prefab_Velgus_MovingTile2_7;
  public FieldObject prefab_Velgus_MovingTile2_8;
  public FieldObject prefab_Velgus_MovingTile3_1;
  public FieldObject prefab_Velgus_MovingTile3_2;
  public FieldObject prefab_Velgus_MovingTile3_3;
  public FieldObject prefab_Velgus_MovingTile3_4;
  public FieldObject prefab_Velgus_MovingTile3_5;
  public FieldObject prefab_Velgus_MovingTile3_6;
  public FieldObject prefab_Velgus_MovingTile3_7;

  // Decision
  public GameObject GroupDecision;
  public Text txtDecisionTitle;
  public Text txtDecisionMessage;
  public Text txtDecisionA;
  public Text txtDecisionB;
  public Text txtDecisionC;

  // Choice
  public GameObject GroupChoice;
  public Text txtChoiceTitle;
  public Text txtChoiceMessage;
  public Text txtChoiceA;
  public Text txtChoiceB;
  public Text txtChoiceC;

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

  private bool ReloadMap = false;

  private bool GameOver = false;

  private bool NextTapOk = false; // 画面再描画が必要案ものについて、一旦メソッドを抜け次のフレーム更新(Update)で即時TapOKを自動処理する。
  private float NextTapOkSleep = 0.0f;
  private float NextTapOkCounter = 0.0f;
  private FieldObject CurrentEventObject = null;
  private FieldObject CurrentEventObject2 = null;

  private string currentDecision = String.Empty;
  private string currentChoice = String.Empty;

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
  private int MovementInterval = 0; // ダンジョンマップ全体を見ている時のインターバル
  private bool detectFastKeyUpTop = false; // ヴェルガスの海底神殿、疾走の間４、短時間移動を検知したフラグ
  private int FastKeyUpTimerTop = 0; // ヴェルガスの海底神殿、疾走の間４、短時間移動を検知するためのタイマー
  private bool detectFastKeyUpLeft = false; // ヴェルガスの海底神殿、疾走の間４、短時間移動を検知したフラグ
  private int FastKeyUpTimerLeft = 0; // ヴェルガスの海底神殿、疾走の間４、短時間移動を検知するためのタイマー
  private bool detectFastKeyUpRight = false; // ヴェルガスの海底神殿、疾走の間４、短時間移動を検知したフラグ
  private int FastKeyUpTimerRight = 0; // ヴェルガスの海底神殿、疾走の間４、短時間移動を検知するためのタイマー
  private bool detectFastKeyUpBottom = false; // ヴェルガスの海底神殿、疾走の間４、短時間移動を検知したフラグ
  private int FastKeyUpTimerBottom = 0; // ヴェルガスの海底神殿、疾走の間４、短時間移動を検知するためのタイマー

  private int Velgus_SpeedRun1_Timer = 0;
  private int Velgus_SpeedRun2_Timer = 0;
  private FieldObject objVelgusSlidingTile = null;
  private Vector3 objVelgusSlidingTileLocation = Vector3.zero;
  private int VelgusSlidingTilePhase = 0;

  private int Velgus_SpeedRun3_Timer = 0;

  private int Velgus_SpeedRun4_Timer = 0;

  private int Velgus_SpeedRun5_Timer = 0;

  private int Velgus_Circulate1_Timer = 0;
  private FieldObject objVelgusMovingTile1 = null;
  private FieldObject objVelgusMovingTile2 = null;
  private FieldObject objVelgusMovingTile3 = null;
  private FieldObject objVelgusMovingTile4 = null;
  private FieldObject objVelgusMovingTile5 = null;

  private int Velgus_Circulate2_Timer = 0;
  private FieldObject objVelgusMovingTile2_1 = null;
  private FieldObject objVelgusMovingTile2_2 = null;
  private FieldObject objVelgusMovingTile2_3 = null;
  private FieldObject objVelgusMovingTile2_4 = null;
  private FieldObject objVelgusMovingTile2_5 = null;
  private FieldObject objVelgusMovingTile2_6 = null;
  private FieldObject objVelgusMovingTile2_7 = null;
  private FieldObject objVelgusMovingTile2_8 = null;

  private int Velgus_Circulate3_Timer = 0;
  private FieldObject objVelgusMovingTile3_1 = null;
  private FieldObject objVelgusMovingTile3_2 = null;
  private FieldObject objVelgusMovingTile3_3 = null;
  private FieldObject objVelgusMovingTile3_4 = null;
  private FieldObject objVelgusMovingTile3_5 = null;
  private FieldObject objVelgusMovingTile3_6 = null;
  private FieldObject objVelgusMovingTile3_7 = null;
  private bool switchVelgusMovingTile3_1 = false;
  private int Velgus_Circulate3_Timer3_1 = 0;
  private bool switchVelgusMovingTile3_2 = false;
  private int Velgus_Circulate3_Timer3_2 = 0;
  private bool switchVelgusMovingTile3_3 = false;
  private int Velgus_Circulate3_Timer3_3 = 0;
  private bool switchVelgusMovingTile3_4 = false;
  private int Velgus_Circulate3_Timer3_4 = 0;

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
    PrefabList.Add("Velgus_Normal");
    PrefabList.Add("Velgus_Wall");
    PrefabList.Add("Velgus_Sea");
    PrefabList.Add("Velgus_Number1");
    PrefabList.Add("Velgus_Number2");
    PrefabList.Add("Velgus_Number3");
    PrefabList.Add("Velgus_Number4");
    PrefabList.Add("Velgus_Number5");
    PrefabList.Add("Velgus_Number6");
    PrefabList.Add("Velgus_Number7");
    PrefabList.Add("Velgus_CircleRed");
    PrefabList.Add("Velgus_CircleBlue");
    PrefabList.Add("Velgus_CircleGreen");
    PrefabList.Add("Velgus_CircleYellow");
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
    ObjectList.Add("MysticForest_EventWall");
    ObjectList.Add("OhranTower_Door_ShadowMoon");
    ObjectList.Add("OhranTower_Door_SunBurst");
    ObjectList.Add("OhranTower_Door_StarDust");
    ObjectList.Add("OhranTower_Door_OriginRoad");
    ObjectList.Add("Velgus_WallDoor");
    ObjectList.Add("Velgus_SecretWall");
    ObjectList.Add("Velgus_FakeSea");
    ObjectList.Add("Velgus_BallRed");
    ObjectList.Add("Velgus_BallBlue");
    ObjectList.Add("Velgus_BallGreen");
    ObjectList.Add("Velgus_BallYellow");
    ObjectList.Add("Velgus_CircleRed");
    ObjectList.Add("Velgus_CircleBlue");
    ObjectList.Add("Velgus_CircleGreen");
    ObjectList.Add("Velgus_CircleYellow");
    ObjectList.Add("Velgus_SlidingTile");
    ObjectList.Add("Velgus_FixedTile");
    ObjectList.Add("Velgus_MovingTile1");
    ObjectList.Add("Velgus_MovingTile2");
    ObjectList.Add("Velgus_MovingTile3");
    ObjectList.Add("Velgus_MovingTile4");
    ObjectList.Add("Velgus_MovingTile5");
    ObjectList.Add("Velgus_MovingTile2_1");
    ObjectList.Add("Velgus_MovingTile2_2");
    ObjectList.Add("Velgus_MovingTile2_3");
    ObjectList.Add("Velgus_MovingTile2_4");
    ObjectList.Add("Velgus_MovingTile2_5");
    ObjectList.Add("Velgus_MovingTile2_6");
    ObjectList.Add("Velgus_MovingTile2_7");
    ObjectList.Add("Velgus_MovingTile2_8");
    ObjectList.Add("Velgus_MovingTile3_1");
    ObjectList.Add("Velgus_MovingTile3_2");
    ObjectList.Add("Velgus_MovingTile3_3");
    ObjectList.Add("Velgus_MovingTile3_4");
    ObjectList.Add("Velgus_MovingTile3_5");
    ObjectList.Add("Velgus_MovingTile3_6");
    ObjectList.Add("Velgus_MovingTile3_7");

    // プレイヤーを設置
    this.Player = Instantiate(prefab_Player, new Vector3(0, 0, 0), Quaternion.identity) as GameObject; // インスタント生成で位置情報は無意味とする。

    // プレイヤー位置を設定
    JumpToLocation(new Vector3(One.TF.Field_X, One.TF.Field_Y, One.TF.Field_Z));

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
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
      {
        if (One.TF.Event_Message000010 == false)
        {
          One.TF.Event_Message000010 = true;
          MessagePack.Message000010(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }

        if (One.TF.DefeatScreamingRafflesia && One.TF.Event_Message000111 == false)
        {
          MessagePack.Message000111(ref QuestMessageList, ref QuestEventList); TapOK();
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

      if (One.TF.CurrentDungeonField == Fix.MAPFILE_GORATRUM_2)
      {
        if (One.TF.DefeatMagicalHailGun && One.TF.Event_Message600200 == false)
        {
          MessagePack.Message600330(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
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
      }

      if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
      {
        if (One.TF.DefeatLightThunderLancebolts && One.TF.Event_Message800051 == false)
        {
          MessagePack.Message800052(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }

        if (One.TF.DefeatYodirian && One.TF.Event_Message800100 == false)
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

        if (One.TF.DefeatFlansisQueenOfVerdant && One.TF.Event_Message900110 == false)
        {
          MessagePack.Message900750(ref QuestMessageList, ref QuestEventList); TapOK();
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

      if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
      {
        if (One.TF.Event_Message1000000 == false)
        {
          MessagePack.Message1000000(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (One.TF.DefeatOriginStarCoralQueen && One.TF.Event_Message1000183 == false)
        {
          MessagePack.Message1000183(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (One.TF.DefeatEoneFulnea && One.TF.Event_Message1010010 == false)
        {
          MessagePack.Message1010010(ref QuestMessageList, ref QuestEventList); TapOK();
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
          One.StopDungeonMusic();
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
          Debug.Log("FieldObjList ID: " + FieldObjList[ii].ObjectId + " objectname: " + txtSelectObjectName.text);
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
//    txtCurrentCursor2.text = this.Player.transform.position.ToString();

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
      One.StopDungeonMusic();
      SceneDimension.JumpToHomeTown();
      return;
    }
    if (this.DungeonCall != string.Empty && this.DungeonMap != string.Empty && this.DungeonCallComplete == false)
    {
      this.DungeonCallComplete = true;
      // todo
      Debug.Log("DungeonCallComplete: " + this.DungeonCall + " " + this.DungeonMap);
      // One.TF.BeforeAreaName = One.TF.CurrentAreaName; // 更新しない
      // One.StopDungeonMusic(); // 同じダンジョン内の階層移動なので、音楽は停止しない
      One.TF.CurrentDungeonField = this.DungeonMap;
      SceneDimension.JumpToDungeonField();
      return;
    }

    // ヴェルガスの海底神殿、疾走の間、初級のタイマーカウント
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && One.TF.Event_SpeedRun1_Complete == false)
    {
      if (this.Velgus_SpeedRun1_Timer > 0)
      {
        Debug.Log("Velgus_SpeedRun1_Timer: " + this.Velgus_SpeedRun1_Timer.ToString());
        this.Velgus_SpeedRun1_Timer--;
        if (this.Velgus_SpeedRun1_Timer == 0)
        {
          MessagePack.SpeedRun1_Failed(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
      }
    }
    // ヴェルガスの海底神殿、疾走の間、流水のタイマーカウント
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && One.TF.Event_SpeedRun2_Complete == false)
    {
      if (this.VelgusSlidingTilePhase >= 7)
      {
        // 何もしない
      }
      else
      {
        if (this.Velgus_SpeedRun2_Timer > 0)
        {
          Debug.Log("Velgus_SpeedRun2_Timer: " + this.Velgus_SpeedRun2_Timer.ToString());

          if (this.objVelgusSlidingTile == null)
          {
            for (int ii = 0; ii < FieldObjList.Count; ii++)
            {
              if (FieldObjList[ii].content == FieldObject.Content.Velgus_SlidingTile) // スライディングタイルは１つだけなのでこれでも問題ない。複数出現する場合は要検討。
              {
                this.objVelgusSlidingTile = FieldObjList[ii];
                this.objVelgusSlidingTileLocation = FieldObjList[ii].transform.localPosition;
                break;
              }
            }
          }

          int border1 = 200;
          int border2 = 100;
          int border3 = 0;

          if (this.VelgusSlidingTilePhase == 0) { border1 = 250; border2 = 200; border3 = 150; }
          if (this.VelgusSlidingTilePhase == 1) { border1 = 270; border2 = 240; border3 = 210; }
          if (this.VelgusSlidingTilePhase == 2) { border1 = 280; border2 = 260; border3 = 240; }
          if (this.VelgusSlidingTilePhase == 3) { border1 = 285; border2 = 270; border3 = 255; }
          if (this.VelgusSlidingTilePhase == 4) { border1 = 290; border2 = 280; border3 = 270; }
          if (this.VelgusSlidingTilePhase == 5) { border1 = 293; border2 = 286; border3 = 279; }
          if (this.VelgusSlidingTilePhase == 6) { border1 = 295; border2 = 290; border3 = 285; }

          this.Velgus_SpeedRun2_Timer--;
          if (this.Velgus_SpeedRun2_Timer == border1)
          {
            this.objVelgusSlidingTile.transform.localPosition = new Vector3(this.objVelgusSlidingTile.transform.localPosition.x, this.objVelgusSlidingTile.transform.localPosition.y, this.objVelgusSlidingTile.transform.localPosition.z - 1.00f);
          }
          else if (this.Velgus_SpeedRun2_Timer == border2)
          {
            this.objVelgusSlidingTile.transform.localPosition = new Vector3(this.objVelgusSlidingTile.transform.localPosition.x, this.objVelgusSlidingTile.transform.localPosition.y, this.objVelgusSlidingTile.transform.localPosition.z - 1.00f);
          }
          else if (this.Velgus_SpeedRun2_Timer == border3)
          {
            this.Velgus_SpeedRun2_Timer = 300;
            this.objVelgusSlidingTile.transform.localPosition = new Vector3(this.objVelgusSlidingTileLocation.x + this.VelgusSlidingTilePhase, this.objVelgusSlidingTileLocation.y, this.objVelgusSlidingTileLocation.z);
            return;
          }
        }
      }
    }
    // ヴェルガスの海底神殿、疾走の間２、対流のタイマーカウント
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && One.TF.Event_SpeedRun3_Complete == false)
    {
      if (this.Velgus_SpeedRun3_Timer > 0)
      {
        Debug.Log("Velgus_SpeedRun3_Timer: " + this.Velgus_SpeedRun3_Timer.ToString());
        this.Velgus_SpeedRun3_Timer--;
        if (this.Velgus_SpeedRun3_Timer == 0)
        {
          //MessagePack.SpeedRun1_Failed(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
      }
    }

    // ヴェルガスの海底神殿、疾走の間３、早流のタイマーカウント
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && One.TF.Event_SpeedRun4_Complete == false)
    {
      if (this.Velgus_SpeedRun4_Timer > 0)
      {
        Debug.Log("Velgus_SpeedRun4_Timer: " + this.Velgus_SpeedRun4_Timer.ToString());
        this.Velgus_SpeedRun4_Timer--;
        if (this.Velgus_SpeedRun4_Timer == 0)
        {
          MessagePack.SpeedRun4_Failed(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
      }
    }

    // ヴェルガスの海底神殿、疾走の間４、光速のタイマーカウント
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && One.TF.Event_SpeedRun5_Complete == false)
    {
      if (this.Velgus_SpeedRun5_Timer > 0)
      {
        this.FastKeyUpTimerTop++;
        this.FastKeyUpTimerLeft++;
        this.FastKeyUpTimerRight++;
        this.FastKeyUpTimerBottom++;

        Debug.Log("Velgus_SpeedRun5_Timer: " + this.Velgus_SpeedRun5_Timer.ToString());
        this.Velgus_SpeedRun5_Timer--;
        if (this.Velgus_SpeedRun5_Timer == 0)
        {
          MessagePack.SpeedRun5_Failed(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
      }
    }

    // ヴェルガスの海底神殿、海渡の間１、タイマーカウント１
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && One.TF.Event_Message1000217 && One.TF.EventSeaCirculate1_Complete == false)
    {
      Velgus_Circulate1_Timer++;
      if (this.objVelgusMovingTile1 == null)
      {
        for (int ii = 0; ii < FieldObjList.Count; ii++)
        {
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile1) // 複数出現する場合は要検討。
          {
            this.objVelgusMovingTile1 = FieldObjList[ii];
            //break;
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile2 && this.objVelgusMovingTile2 == null)
          {
            this.objVelgusMovingTile2 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile3 && this.objVelgusMovingTile3 == null)
          {
            this.objVelgusMovingTile3 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile4 && this.objVelgusMovingTile4 == null)
          {
            this.objVelgusMovingTile4 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile5 && this.objVelgusMovingTile5 == null)
          {
            this.objVelgusMovingTile5 = FieldObjList[ii];
          }
        }
      }

      if (0 < Velgus_Circulate1_Timer && Velgus_Circulate1_Timer <= 100)
      {
        objVelgusMovingTile1.transform.localPosition = new Vector3(objVelgusMovingTile1.transform.localPosition.x, objVelgusMovingTile1.transform.localPosition.y, objVelgusMovingTile1.transform.localPosition.z - 0.01f);

        objVelgusMovingTile2.transform.localPosition = new Vector3(objVelgusMovingTile2.transform.localPosition.x + 0.01f, objVelgusMovingTile2.transform.localPosition.y, objVelgusMovingTile2.transform.localPosition.z);

        objVelgusMovingTile3.transform.localPosition = new Vector3(objVelgusMovingTile3.transform.localPosition.x, objVelgusMovingTile3.transform.localPosition.y, objVelgusMovingTile3.transform.localPosition.z + 0.01f);

        objVelgusMovingTile4.transform.localPosition = new Vector3(objVelgusMovingTile4.transform.localPosition.x, objVelgusMovingTile4.transform.localPosition.y, objVelgusMovingTile4.transform.localPosition.z - 0.01f);

        objVelgusMovingTile5.transform.localPosition = new Vector3(objVelgusMovingTile5.transform.localPosition.x, objVelgusMovingTile5.transform.localPosition.y, objVelgusMovingTile5.transform.localPosition.z + 0.01f);
      }
      else if (100 < Velgus_Circulate1_Timer && Velgus_Circulate1_Timer <= 200)
      {
        objVelgusMovingTile1.transform.localPosition = new Vector3(objVelgusMovingTile1.transform.localPosition.x + 0.01f, objVelgusMovingTile1.transform.localPosition.y, objVelgusMovingTile1.transform.localPosition.z);

        objVelgusMovingTile2.transform.localPosition = new Vector3(objVelgusMovingTile2.transform.localPosition.x, objVelgusMovingTile2.transform.localPosition.y, objVelgusMovingTile2.transform.localPosition.z + 0.01f);

        objVelgusMovingTile3.transform.localPosition = new Vector3(objVelgusMovingTile3.transform.localPosition.x - 0.01f, objVelgusMovingTile3.transform.localPosition.y, objVelgusMovingTile3.transform.localPosition.z);

        objVelgusMovingTile4.transform.localPosition = new Vector3(objVelgusMovingTile4.transform.localPosition.x - 0.01f, objVelgusMovingTile4.transform.localPosition.y, objVelgusMovingTile4.transform.localPosition.z);

        objVelgusMovingTile5.transform.localPosition = new Vector3(objVelgusMovingTile5.transform.localPosition.x + 0.01f, objVelgusMovingTile5.transform.localPosition.y, objVelgusMovingTile5.transform.localPosition.z);
      }
      else if (200 < Velgus_Circulate1_Timer && Velgus_Circulate1_Timer <= 300)
      {
        objVelgusMovingTile1.transform.localPosition = new Vector3(objVelgusMovingTile1.transform.localPosition.x, objVelgusMovingTile1.transform.localPosition.y, objVelgusMovingTile1.transform.localPosition.z + 0.01f);

        objVelgusMovingTile2.transform.localPosition = new Vector3(objVelgusMovingTile2.transform.localPosition.x - 0.01f, objVelgusMovingTile2.transform.localPosition.y, objVelgusMovingTile2.transform.localPosition.z);

        objVelgusMovingTile3.transform.localPosition = new Vector3(objVelgusMovingTile3.transform.localPosition.x, objVelgusMovingTile3.transform.localPosition.y, objVelgusMovingTile3.transform.localPosition.z - 0.01f);

        objVelgusMovingTile4.transform.localPosition = new Vector3(objVelgusMovingTile4.transform.localPosition.x, objVelgusMovingTile4.transform.localPosition.y, objVelgusMovingTile4.transform.localPosition.z + 0.01f);

        objVelgusMovingTile5.transform.localPosition = new Vector3(objVelgusMovingTile5.transform.localPosition.x, objVelgusMovingTile5.transform.localPosition.y, objVelgusMovingTile5.transform.localPosition.z - 0.01f);
      }
      else if (300 < Velgus_Circulate1_Timer && Velgus_Circulate1_Timer <= 400)
      {
        objVelgusMovingTile1.transform.localPosition = new Vector3(objVelgusMovingTile1.transform.localPosition.x - 0.01f, objVelgusMovingTile1.transform.localPosition.y, objVelgusMovingTile1.transform.localPosition.z);

        objVelgusMovingTile2.transform.localPosition = new Vector3(objVelgusMovingTile2.transform.localPosition.x, objVelgusMovingTile2.transform.localPosition.y, objVelgusMovingTile2.transform.localPosition.z - 0.01f);

        objVelgusMovingTile3.transform.localPosition = new Vector3(objVelgusMovingTile3.transform.localPosition.x + 0.01f, objVelgusMovingTile3.transform.localPosition.y, objVelgusMovingTile3.transform.localPosition.z);

        objVelgusMovingTile4.transform.localPosition = new Vector3(objVelgusMovingTile4.transform.localPosition.x + 0.01f, objVelgusMovingTile4.transform.localPosition.y, objVelgusMovingTile4.transform.localPosition.z);

        objVelgusMovingTile5.transform.localPosition = new Vector3(objVelgusMovingTile5.transform.localPosition.x - 0.01f, objVelgusMovingTile5.transform.localPosition.y, objVelgusMovingTile5.transform.localPosition.z);
      }

      if (Velgus_Circulate1_Timer >= 400) { Velgus_Circulate1_Timer = 0; }

      // Debug.Log("X: " + this.Player.transform.position.x + " " + objVelgusMovingTile.transform.position.x);
      // Debug.Log("Z: " + this.Player.transform.position.z + " " + objVelgusMovingTile.transform.position.z);
      if (objVelgusMovingTile1.transform.position.x - 0.1f < this.Player.transform.position.x && this.Player.transform.position.x < objVelgusMovingTile1.transform.position.x + 0.1f &&
          objVelgusMovingTile1.transform.position.z - 0.1f < this.Player.transform.position.z && this.Player.transform.position.z < objVelgusMovingTile1.transform.position.z + 0.1f)
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile1.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile1.transform.position.z);
        RefleshMainCamera();
      }
      if (objVelgusMovingTile2.transform.position.x - 0.1f < this.Player.transform.position.x && this.Player.transform.position.x < objVelgusMovingTile2.transform.position.x + 0.1f &&
          objVelgusMovingTile2.transform.position.z - 0.1f < this.Player.transform.position.z && this.Player.transform.position.z < objVelgusMovingTile2.transform.position.z + 0.1f)
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile2.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile2.transform.position.z);
        RefleshMainCamera();
      }
      if (objVelgusMovingTile3.transform.position.x - 0.1f < this.Player.transform.position.x && this.Player.transform.position.x < objVelgusMovingTile3.transform.position.x + 0.1f &&
          objVelgusMovingTile3.transform.position.z - 0.1f < this.Player.transform.position.z && this.Player.transform.position.z < objVelgusMovingTile3.transform.position.z + 0.1f)
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile3.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile3.transform.position.z);
        RefleshMainCamera();
      }
      if (objVelgusMovingTile4.transform.position.x - 0.1f < this.Player.transform.position.x && this.Player.transform.position.x < objVelgusMovingTile4.transform.position.x + 0.1f &&
          objVelgusMovingTile4.transform.position.z - 0.1f < this.Player.transform.position.z && this.Player.transform.position.z < objVelgusMovingTile4.transform.position.z + 0.1f)
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile4.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile4.transform.position.z);
        RefleshMainCamera();
      }
      if (objVelgusMovingTile5.transform.position.x - 0.1f < this.Player.transform.position.x && this.Player.transform.position.x < objVelgusMovingTile5.transform.position.x + 0.1f &&
          objVelgusMovingTile5.transform.position.z - 0.1f < this.Player.transform.position.z && this.Player.transform.position.z < objVelgusMovingTile5.transform.position.z + 0.1f)
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile5.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile5.transform.position.z);
        RefleshMainCamera();
      }
    }

    // ヴェルガスの海底神殿、海渡の間２、タイマーカウント２
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && One.TF.Event_Message1000219 && One.TF.EventSeaCirculate2_Complete == false)
    {
      Velgus_Circulate2_Timer++;
      if (this.objVelgusMovingTile2_1 == null)
      {
        for (int ii = 0; ii < FieldObjList.Count; ii++)
        {
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile2_1)
          {
            this.objVelgusMovingTile2_1 = FieldObjList[ii];
            //break;
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile2_2 && this.objVelgusMovingTile2_2 == null)
          {
            this.objVelgusMovingTile2_2 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile2_3 && this.objVelgusMovingTile2_3 == null)
          {
            this.objVelgusMovingTile2_3 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile2_4 && this.objVelgusMovingTile2_4 == null)
          {
            this.objVelgusMovingTile2_4 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile2_5 && this.objVelgusMovingTile2_5 == null)
          {
            this.objVelgusMovingTile2_5 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile2_6 && this.objVelgusMovingTile2_6 == null)
          {
            this.objVelgusMovingTile2_6 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile2_7 && this.objVelgusMovingTile2_7 == null)
          {
            this.objVelgusMovingTile2_7 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile2_8 && this.objVelgusMovingTile2_8 == null)
          {
            this.objVelgusMovingTile2_8 = FieldObjList[ii];
          }
        }
      }

      if (0 < Velgus_Circulate2_Timer && Velgus_Circulate2_Timer <= 50)
      {
        objVelgusMovingTile2_1.transform.localPosition = new Vector3(objVelgusMovingTile2_1.transform.localPosition.x, objVelgusMovingTile2_1.transform.localPosition.y, objVelgusMovingTile2_1.transform.localPosition.z + 0.02f);
        objVelgusMovingTile2_2.transform.localPosition = new Vector3(objVelgusMovingTile2_2.transform.localPosition.x - 0.02f, objVelgusMovingTile2_2.transform.localPosition.y, objVelgusMovingTile2_2.transform.localPosition.z);
        objVelgusMovingTile2_3.transform.localPosition = new Vector3(objVelgusMovingTile2_3.transform.localPosition.x - 0.02f, objVelgusMovingTile2_3.transform.localPosition.y, objVelgusMovingTile2_3.transform.localPosition.z);
        objVelgusMovingTile2_4.transform.localPosition = new Vector3(objVelgusMovingTile2_4.transform.localPosition.x - 0.04f, objVelgusMovingTile2_4.transform.localPosition.y, objVelgusMovingTile2_4.transform.localPosition.z);
        objVelgusMovingTile2_5.transform.localPosition = new Vector3(objVelgusMovingTile2_5.transform.localPosition.x + 0.02f, objVelgusMovingTile2_5.transform.localPosition.y, objVelgusMovingTile2_5.transform.localPosition.z);
        objVelgusMovingTile2_6.transform.localPosition = new Vector3(objVelgusMovingTile2_6.transform.localPosition.x + 0.02f, objVelgusMovingTile2_6.transform.localPosition.y, objVelgusMovingTile2_6.transform.localPosition.z);
        objVelgusMovingTile2_7.transform.localPosition = new Vector3(objVelgusMovingTile2_7.transform.localPosition.x + 0.02f, objVelgusMovingTile2_7.transform.localPosition.y, objVelgusMovingTile2_7.transform.localPosition.z);
        //
      }
      else if (50 < Velgus_Circulate2_Timer && Velgus_Circulate2_Timer <= 100)
      {
        //
        objVelgusMovingTile2_2.transform.localPosition = new Vector3(objVelgusMovingTile2_2.transform.localPosition.x + 0.02f, objVelgusMovingTile2_2.transform.localPosition.y, objVelgusMovingTile2_2.transform.localPosition.z);
        objVelgusMovingTile2_3.transform.localPosition = new Vector3(objVelgusMovingTile2_3.transform.localPosition.x - 0.02f, objVelgusMovingTile2_3.transform.localPosition.y, objVelgusMovingTile2_3.transform.localPosition.z);
        objVelgusMovingTile2_4.transform.localPosition = new Vector3(objVelgusMovingTile2_4.transform.localPosition.x + 0.02f, objVelgusMovingTile2_4.transform.localPosition.y, objVelgusMovingTile2_4.transform.localPosition.z);
        //
        objVelgusMovingTile2_6.transform.localPosition = new Vector3(objVelgusMovingTile2_6.transform.localPosition.x - 0.02f, objVelgusMovingTile2_6.transform.localPosition.y, objVelgusMovingTile2_6.transform.localPosition.z);
        objVelgusMovingTile2_7.transform.localPosition = new Vector3(objVelgusMovingTile2_7.transform.localPosition.x - 0.04f, objVelgusMovingTile2_7.transform.localPosition.y, objVelgusMovingTile2_7.transform.localPosition.z);
        objVelgusMovingTile2_8.transform.localPosition = new Vector3(objVelgusMovingTile2_8.transform.localPosition.x - 0.02f, objVelgusMovingTile2_8.transform.localPosition.y, objVelgusMovingTile2_8.transform.localPosition.z);
      }
      else if (100 < Velgus_Circulate2_Timer && Velgus_Circulate2_Timer <= 150)
      {
        objVelgusMovingTile2_1.transform.localPosition = new Vector3(objVelgusMovingTile2_1.transform.localPosition.x, objVelgusMovingTile2_1.transform.localPosition.y, objVelgusMovingTile2_1.transform.localPosition.z - 0.02f);
        objVelgusMovingTile2_2.transform.localPosition = new Vector3(objVelgusMovingTile2_2.transform.localPosition.x - 0.02f, objVelgusMovingTile2_2.transform.localPosition.y, objVelgusMovingTile2_2.transform.localPosition.z);
        objVelgusMovingTile2_3.transform.localPosition = new Vector3(objVelgusMovingTile2_3.transform.localPosition.x + 0.02f, objVelgusMovingTile2_3.transform.localPosition.y, objVelgusMovingTile2_3.transform.localPosition.z);
        objVelgusMovingTile2_4.transform.localPosition = new Vector3(objVelgusMovingTile2_4.transform.localPosition.x + 0.04f, objVelgusMovingTile2_4.transform.localPosition.y, objVelgusMovingTile2_4.transform.localPosition.z);
        objVelgusMovingTile2_5.transform.localPosition = new Vector3(objVelgusMovingTile2_5.transform.localPosition.x - 0.04f, objVelgusMovingTile2_5.transform.localPosition.y, objVelgusMovingTile2_5.transform.localPosition.z);
        objVelgusMovingTile2_6.transform.localPosition = new Vector3(objVelgusMovingTile2_6.transform.localPosition.x + 0.02f, objVelgusMovingTile2_6.transform.localPosition.y, objVelgusMovingTile2_6.transform.localPosition.z);
        //
        objVelgusMovingTile2_8.transform.localPosition = new Vector3(objVelgusMovingTile2_8.transform.localPosition.x + 0.04f, objVelgusMovingTile2_8.transform.localPosition.y, objVelgusMovingTile2_8.transform.localPosition.z);
      }
      else if (150 < Velgus_Circulate2_Timer && Velgus_Circulate2_Timer <= 200)
      {
        //
        objVelgusMovingTile2_2.transform.localPosition = new Vector3(objVelgusMovingTile2_2.transform.localPosition.x + 0.02f, objVelgusMovingTile2_2.transform.localPosition.y, objVelgusMovingTile2_2.transform.localPosition.z);
        objVelgusMovingTile2_3.transform.localPosition = new Vector3(objVelgusMovingTile2_3.transform.localPosition.x + 0.02f, objVelgusMovingTile2_3.transform.localPosition.y, objVelgusMovingTile2_3.transform.localPosition.z);
        objVelgusMovingTile2_4.transform.localPosition = new Vector3(objVelgusMovingTile2_4.transform.localPosition.x - 0.02f, objVelgusMovingTile2_4.transform.localPosition.y, objVelgusMovingTile2_4.transform.localPosition.z);
        objVelgusMovingTile2_5.transform.localPosition = new Vector3(objVelgusMovingTile2_5.transform.localPosition.x + 0.02f, objVelgusMovingTile2_5.transform.localPosition.y, objVelgusMovingTile2_5.transform.localPosition.z);
        objVelgusMovingTile2_6.transform.localPosition = new Vector3(objVelgusMovingTile2_6.transform.localPosition.x - 0.02f, objVelgusMovingTile2_6.transform.localPosition.y, objVelgusMovingTile2_6.transform.localPosition.z);
        objVelgusMovingTile2_7.transform.localPosition = new Vector3(objVelgusMovingTile2_7.transform.localPosition.x + 0.02f, objVelgusMovingTile2_7.transform.localPosition.y, objVelgusMovingTile2_7.transform.localPosition.z);
        objVelgusMovingTile2_8.transform.localPosition = new Vector3(objVelgusMovingTile2_8.transform.localPosition.x - 0.02f, objVelgusMovingTile2_8.transform.localPosition.y, objVelgusMovingTile2_8.transform.localPosition.z);
      }

      if (Velgus_Circulate2_Timer >= 200) { Velgus_Circulate2_Timer = 0; }

      if (DetectVelgusMovingTile(objVelgusMovingTile2_1.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile2_1.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile2_1.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile2_2.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile2_2.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile2_2.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile2_3.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile2_3.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile2_3.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile2_4.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile2_4.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile2_4.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile2_5.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile2_5.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile2_5.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile2_6.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile2_6.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile2_6.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile2_7.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile2_7.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile2_7.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile2_8.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile2_8.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile2_8.transform.position.z);
        RefleshMainCamera();
      }
    }

    // ヴェルガスの海底神殿、海渡の間３、タイマーカウント３
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && One.TF.Event_Message1000221 && One.TF.EventSeaCirculate3_Complete == false)
    {
      //Debug.Log("Velgus_Circulate3_Timer : " + Velgus_Circulate3_Timer.ToString());
      Velgus_Circulate3_Timer++;
      if (this.switchVelgusMovingTile3_1) { Velgus_Circulate3_Timer3_1++; }
      if (this.switchVelgusMovingTile3_2) { Velgus_Circulate3_Timer3_2++; }
      if (this.switchVelgusMovingTile3_3) { Velgus_Circulate3_Timer3_3++; }
      if (this.switchVelgusMovingTile3_4) { Velgus_Circulate3_Timer3_4++; }
      if (this.objVelgusMovingTile3_1 == null)
      {
        for (int ii = 0; ii < FieldObjList.Count; ii++)
        {
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile3_1)
          {
            Debug.Log("Velgus_MovingTile3_1 DETECT");
            this.objVelgusMovingTile3_1 = FieldObjList[ii];
            //break;
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile3_2 && this.objVelgusMovingTile3_2 == null)
          {
            Debug.Log("Velgus_MovingTile3_2 DETECT");
            this.objVelgusMovingTile3_2 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile3_3 && this.objVelgusMovingTile3_3 == null)
          {
            this.objVelgusMovingTile3_3 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile3_4 && this.objVelgusMovingTile3_4 == null)
          {
            this.objVelgusMovingTile3_4 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile3_5 && this.objVelgusMovingTile3_5 == null)
          {
            this.objVelgusMovingTile3_5 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile3_6 && this.objVelgusMovingTile3_6 == null)
          {
            this.objVelgusMovingTile3_6 = FieldObjList[ii];
          }
          if (FieldObjList[ii].content == FieldObject.Content.Velgus_MovingTile3_7 && this.objVelgusMovingTile3_7 == null)
          {
            this.objVelgusMovingTile3_7 = FieldObjList[ii];
          }
        }
      }

      if (0 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 20)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z - 0.05f);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x - 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (20 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 40)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x + 0.05f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z + 0.05f);
      }
      else if (40 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 60)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x + 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (60 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 80)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x - 0.05f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z - 0.05f);
      }
      else if (80 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 100)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z + 0.05f);
        //
        //
      }
      else if (100 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 120)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x - 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z - 0.05f);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x - 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (120 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 140)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x - 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x + 0.05f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z + 0.05f);
      }
      else if (140 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 160)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x - 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x + 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (160 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 180)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x - 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x - 0.05f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z - 0.05f);
      }
      else if (180 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 200)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z + 0.05f);
        //
        //
      }
      else if (200 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 220)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x - 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z - 0.05f);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x - 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (220 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 240)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x + 0.05f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z + 0.05f);
      }
      else if (240 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 260)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x - 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x + 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (260 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 280)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z - 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x - 0.05f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z - 0.05f);
      }
      else if (280 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 300)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z - 0.05f);
        //
        //
      }
      else if (300 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 320)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z - 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z - 0.05f);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x - 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (320 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 340)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z - 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x + 0.05f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z + 0.05f);
      }
      else if (340 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 360)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z - 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x + 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (360 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 380)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z - 0.05f);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x - 0.05f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z - 0.025f);
      }
      else if (380 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 400)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z - 0.05f);
        //
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z - 0.025f);
      }
      else if (400 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 420)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x + 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z - 0.05f);
        //
      }
      else if (420 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 440)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x + 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x + 0.05f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x - 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (440 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 460)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x + 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z + 0.05f);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z + 0.05f);
      }
      else if (460 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 480)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x + 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x - 0.025f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x + 0.05f, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z);
      }
      else if (480 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 500)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x + 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        objVelgusMovingTile3_2.transform.localPosition = new Vector3(objVelgusMovingTile3_2.transform.localPosition.x - 0.025f, objVelgusMovingTile3_2.transform.localPosition.y, objVelgusMovingTile3_2.transform.localPosition.z);
        objVelgusMovingTile3_3.transform.localPosition = new Vector3(objVelgusMovingTile3_3.transform.localPosition.x, objVelgusMovingTile3_3.transform.localPosition.y, objVelgusMovingTile3_3.transform.localPosition.z - 0.05f);
      }
      else if (500 < Velgus_Circulate3_Timer && Velgus_Circulate3_Timer <= 520)
      {
        objVelgusMovingTile3_1.transform.localPosition = new Vector3(objVelgusMovingTile3_1.transform.localPosition.x + 0.05f, objVelgusMovingTile3_1.transform.localPosition.y, objVelgusMovingTile3_1.transform.localPosition.z);
        //
        //
      }
      if (Velgus_Circulate3_Timer >= 520) { Velgus_Circulate3_Timer = 0; }

      // スイッチ１によるタイル７移動
      if (this.switchVelgusMovingTile3_1)
      {
        if (0 < Velgus_Circulate3_Timer3_1 && Velgus_Circulate3_Timer3_1 <= 80)
        {
          objVelgusMovingTile3_7.transform.localPosition = new Vector3(objVelgusMovingTile3_7.transform.localPosition.x + 0.05f, objVelgusMovingTile3_7.transform.localPosition.y, objVelgusMovingTile3_7.transform.localPosition.z);
        }
        else if (80 < Velgus_Circulate3_Timer3_1 && Velgus_Circulate3_Timer3_1 <= 160)
        {
          objVelgusMovingTile3_7.transform.localPosition = new Vector3(objVelgusMovingTile3_7.transform.localPosition.x - 0.05f, objVelgusMovingTile3_7.transform.localPosition.y, objVelgusMovingTile3_7.transform.localPosition.z);
        }
        if (Velgus_Circulate3_Timer3_1 >= 160) { Velgus_Circulate3_Timer3_1 = 0; }
      }

      // スイッチ２によるタイル６移動
      if (this.switchVelgusMovingTile3_2)
      {
        if (0 < Velgus_Circulate3_Timer3_2 && Velgus_Circulate3_Timer3_2 <= 60)
        {
          objVelgusMovingTile3_6.transform.localPosition = new Vector3(objVelgusMovingTile3_6.transform.localPosition.x + 0.05f, objVelgusMovingTile3_6.transform.localPosition.y, objVelgusMovingTile3_6.transform.localPosition.z);
        }
        else if (60 < Velgus_Circulate3_Timer3_2 && Velgus_Circulate3_Timer3_2 <= 120)
        {
          objVelgusMovingTile3_6.transform.localPosition = new Vector3(objVelgusMovingTile3_6.transform.localPosition.x - 0.05f, objVelgusMovingTile3_6.transform.localPosition.y, objVelgusMovingTile3_6.transform.localPosition.z);
        }
        if (Velgus_Circulate3_Timer3_2 >= 120) { Velgus_Circulate3_Timer3_2 = 0; }
      }

      // スイッチ３によるタイル５移動
      if (this.switchVelgusMovingTile3_3)
      {
        if (0 < Velgus_Circulate3_Timer3_3 && Velgus_Circulate3_Timer3_3 <= 40)
        {
          objVelgusMovingTile3_5.transform.localPosition = new Vector3(objVelgusMovingTile3_5.transform.localPosition.x + 0.05f, objVelgusMovingTile3_5.transform.localPosition.y, objVelgusMovingTile3_5.transform.localPosition.z);
        }
        else if (40 < Velgus_Circulate3_Timer3_3 && Velgus_Circulate3_Timer3_3 <= 80)
        {
          objVelgusMovingTile3_5.transform.localPosition = new Vector3(objVelgusMovingTile3_5.transform.localPosition.x - 0.05f, objVelgusMovingTile3_5.transform.localPosition.y, objVelgusMovingTile3_5.transform.localPosition.z);
        }
        if (Velgus_Circulate3_Timer3_3 >= 80) { Velgus_Circulate3_Timer3_3 = 0; }
      }

      // スイッチ４によるタイル４移動
      if (this.switchVelgusMovingTile3_4)
      {
        if (0 < Velgus_Circulate3_Timer3_4 && Velgus_Circulate3_Timer3_4 <= 40)
        {
          objVelgusMovingTile3_4.transform.localPosition = new Vector3(objVelgusMovingTile3_4.transform.localPosition.x + 0.05f, objVelgusMovingTile3_4.transform.localPosition.y, objVelgusMovingTile3_4.transform.localPosition.z);
        }
        else if (40 < Velgus_Circulate3_Timer3_4 && Velgus_Circulate3_Timer3_4 <= 80)
        {
          objVelgusMovingTile3_4.transform.localPosition = new Vector3(objVelgusMovingTile3_4.transform.localPosition.x - 0.05f, objVelgusMovingTile3_4.transform.localPosition.y, objVelgusMovingTile3_4.transform.localPosition.z);
        }
        if (Velgus_Circulate3_Timer3_4 >= 80) { Velgus_Circulate3_Timer3_4 = 0; }
      }

      if (DetectVelgusMovingTile(objVelgusMovingTile3_1.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile3_1.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile3_1.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile3_2.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile3_2.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile3_2.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile3_3.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile3_3.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile3_3.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile3_4.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile3_4.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile3_4.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile3_5.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile3_5.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile3_5.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile3_6.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile3_6.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile3_6.transform.position.z);
        RefleshMainCamera();
      }
      if (DetectVelgusMovingTile(objVelgusMovingTile3_7.gameObject, this.Player))
      {
        this.Player.transform.position = new Vector3(objVelgusMovingTile3_7.transform.position.x, this.Player.transform.position.y, objVelgusMovingTile3_7.transform.position.z);
        RefleshMainCamera();
      }
    }
    bool detectKey = false;
    TileInformation tile = null;
    Fix.Direction direction = Fix.Direction.None;
    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      direction = Fix.Direction.Right;
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      direction = Fix.Direction.Left;
    }
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      direction = Fix.Direction.Top;
    }
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      direction = Fix.Direction.Bottom;
    }
    
    if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.UpArrow) || this.arrowUp)
    {
      this.keyUp = true;
      this.keyDown = false;
      if (0 < this.FastKeyUpTimerTop && this.FastKeyUpTimerTop < 5)
      {
        this.detectFastKeyUpTop = true;
      }
      movementTimer_Tick();
    }
    if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.DownArrow) || this.arrowDown)
    {
      this.keyDown = true;
      this.keyUp = false;
      if (0 < this.FastKeyUpTimerBottom && this.FastKeyUpTimerBottom < 5)
      {
        this.detectFastKeyUpBottom = true;
      }
      movementTimer_Tick();
    }
    if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.LeftArrow) || this.arrowLeft)
    {
      this.keyLeft = true;
      this.keyRight = false;
      if (0 < this.FastKeyUpTimerLeft && this.FastKeyUpTimerLeft < 5)
      {
        this.detectFastKeyUpLeft = true;
      }
      movementTimer_Tick();
    }
    if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.RightArrow) || this.arrowRight)
    {
      this.keyRight = true;
      this.keyLeft = false;
      if (0 < this.FastKeyUpTimerRight && this.FastKeyUpTimerRight < 5)
      {
        this.detectFastKeyUpRight = true;
      }
      movementTimer_Tick();
    }
    if (Input.GetKeyUp(KeyCode.UpArrow))
    {
      this.keyUp = false;
      this.interval = MOVE_INTERVAL;
      this.FastKeyUpTimerTop = 0;
      this.detectFastKeyUpTop = false;
    }
    if (Input.GetKeyUp(KeyCode.DownArrow))
    {
      this.keyDown = false;
      this.interval = MOVE_INTERVAL;
      this.FastKeyUpTimerBottom = 0;
      this.detectFastKeyUpBottom = false;
    }
    if (Input.GetKeyUp(KeyCode.LeftArrow))
    {
      this.keyLeft = false;
      this.interval = MOVE_INTERVAL;
      this.FastKeyUpTimerLeft = 0;
      this.detectFastKeyUpLeft = false;
    }
    if (Input.GetKeyUp(KeyCode.RightArrow))
    {
      this.keyRight = false;
      this.interval = MOVE_INTERVAL;
      this.FastKeyUpTimerRight = 0;
      this.detectFastKeyUpRight = false;
    }
    //if (Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.UpArrow) ||
    //    Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.DownArrow) ||
    //    Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.LeftArrow) ||
    //    Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp(KeyCode.RightArrow))
    //{
    //  detectKeyUp = true;
    //  Debug.Log("CancelKeyDownMovement call 1");
    //  CancelKeyDownMovement();
    //}
    if (One.TF.Event_SpeedRun3_Complete == false && this.Velgus_SpeedRun3_Timer > 0)
    {
      if (this.keyUp == false && this.keyDown == false && this.keyLeft == false && this.keyRight == false)
      {
        Velgus_SpeedRun3_Timer = 0;
        MessagePack.SpeedRun3_Failed(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    
    
    // [comment] イベント実行はUpdatePlayersKeyEventsで実施する。

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
    //this.CurrentPlayer = PlayerList[0];

    SceneManager.sceneUnloaded += PartyMenuUnloaded;
    SceneManager.sceneLoaded += PartyMenuLoadded;
    SceneDimension.SceneAdd(Fix.SCENE_PARTY_MENU);
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
      GroupSystem.SetActive(false);
    }
  }

  private void PartyMenuLoadded(Scene next, LoadSceneMode mode)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    SceneManager.sceneLoaded -= PartyMenuLoadded;
  }

  private void PartyMenuUnloaded(Scene scene)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    SceneManager.sceneUnloaded -= PartyMenuUnloaded;

    RefreshAllView();
  }

  public void TapFastTravel()
  {
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_BASE_FIELD)
    {
      this.currentDecision = Fix.DECISION_TRANSFER_TOWN;
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

  public void TapChoiceAccept(int number)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + number.ToString());
    GroupChoice.SetActive(false);
    if (this.currentChoice == Fix.CHOICE_VELGUS_JUDGE_1)
    {
      if (number == 1)
      {
        MessagePack.Message1009011(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else if (number == 2)
      {
        MessagePack.Message1009020(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else if (number == 3)
      {
        MessagePack.Message1009011(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    else if (this.currentChoice == Fix.CHOICE_VELGUS_JUDGE_2)
    {
      if (number == 1)
      {
        MessagePack.Message1009030(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else if (number == 2)
      {
        MessagePack.Message1009011(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else if (number == 3)
      {
        MessagePack.Message1009011(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      } 
    }
    else if (this.currentChoice == Fix.CHOICE_VELGUS_JUDGE_3)
    {
      if (number == 1)
      {
        MessagePack.Message1009011(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else if (number == 2)
      {
        MessagePack.Message1009011(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else if (number == 3)
      {
        MessagePack.Message1009040(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
  }

  public void TapChoiceCancel()
  {
    this.currentChoice = String.Empty;
    GroupChoice.SetActive(false);
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
    One.StopDungeonMusic();
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
    Debug.Log("CancelKeyDownMovement call 2");
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

    if (One.TF.Event_SpeedRun3_Complete == false && this.Velgus_SpeedRun3_Timer > 0)
    {
      Velgus_SpeedRun3_Timer = 0;
      MessagePack.SpeedRun3_Failed(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
  }

  private void movementTimer_Tick()
  {
    if (this.interval < this.MovementInterval) { this.interval++; return; }
    else 
    {
      this.interval = 0;
      if (this.detectFastKeyUpTop || this.detectFastKeyUpLeft || this.detectFastKeyUpRight || this.detectFastKeyUpBottom)
      {
        this.interval = this.MovementInterval;
      }
    }

    TileInformation tile = null;
    if (this.keyUp)
    {
      UpdatePlayersKeyEvents(Fix.Direction.Top, tile);
    }
    else if (this.keyRight)
    {
      UpdatePlayersKeyEvents(Fix.Direction.Right, tile);
    }
    else if (this.keyDown)
    {
      UpdatePlayersKeyEvents(Fix.Direction.Bottom, tile);
    }
    else if (this.keyLeft)
    {
      UpdatePlayersKeyEvents(Fix.Direction.Left, tile);
    }
  }

  private void UpdatePlayersKeyEvents(Fix.Direction direction, TileInformation tile)
  {
    Debug.Log("UpdatePlayersKeyEvents(S)");

    // 移動直前、フィールドオブジェクトの検出および対応。
    // 移動直前、ブロックチェック前に移動先の位置のみをまず選定
    Vector3 nextLocation = new Vector3(-99999, -99999, -99999); // 初期(0,0,0)はあり得るので、あり得ない位置をまず設定
    if (direction == Fix.Direction.Right)
    {
      nextLocation = new Vector3(this.Player.transform.position.x + 1.0f, this.Player.transform.position.y - 1.0f, this.Player.transform.position.z);
      Debug.Log("nextLocation: " + nextLocation.ToString());
    }
    if (direction == Fix.Direction.Left)
    {
      nextLocation = new Vector3(this.Player.transform.position.x - 1.0f, this.Player.transform.position.y - 1.0f, this.Player.transform.position.z);
      Debug.Log("nextLocation: " + nextLocation.ToString());
    }
    if (direction == Fix.Direction.Top)
    {
      nextLocation = new Vector3(this.Player.transform.position.x, this.Player.transform.position.y - 1.0f, this.Player.transform.position.z + 1.0f);
      Debug.Log("nextLocation: " + nextLocation.ToString());
    }
    if (direction == Fix.Direction.Bottom)
    {
      nextLocation = new Vector3(this.Player.transform.position.x, this.Player.transform.position.y - 1.0f, this.Player.transform.position.z - 1.0f);
      Debug.Log("nextLocation: " + nextLocation.ToString());
    }
    FieldObject fieldObjBefore = SearchObject(nextLocation);

    if (fieldObjBefore == null)
    {
      // 移動直前、ブロックチェック前に移動先の位置のみをまず選定(0.5f段差は判定に含める)
      fieldObjBefore = SearchObject(new Vector3(nextLocation.x, nextLocation.y + 0.5f, nextLocation.z));
      if (fieldObjBefore == null)
      {
        // 移動直前、ブロックチェック前に移動先の位置のみをまず選定(1.0f段差は判定に含める)
        fieldObjBefore = SearchObject(new Vector3(nextLocation.x, nextLocation.y + 1.0f, nextLocation.z));
      }
    }

    if (fieldObjBefore != null)
    {
      Debug.Log("fieldObjBefore: " + fieldObjBefore.content.ToString() + " " + fieldObjBefore.transform.position.x + " " + fieldObjBefore.transform.position.y + " " + fieldObjBefore.transform.position.z);
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
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
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
        if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_MessageBoard_3_X, Fix.MYSTICFOREST_MessageBoard_3_Y, Fix.MYSTICFOREST_MessageBoard_3_Z))
        {
          MessagePack.Message900270(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_MessageBoard_4_X, Fix.MYSTICFOREST_MessageBoard_4_Y, Fix.MYSTICFOREST_MessageBoard_4_Z))
        {
          MessagePack.Message900450(ref QuestMessageList, ref QuestEventList); TapOK();
        }
      }
      else if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
      {
        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_MessageBoard_1_X, Fix.VELGUS_MessageBoard_1_Y, Fix.VELGUS_MessageBoard_1_Z))
        {
          MessagePack.Message1000010(ref QuestMessageList, ref QuestEventList); TapOK();
        }

        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_MessageBoard_2_X, Fix.VELGUS_MessageBoard_2_Y, Fix.VELGUS_MessageBoard_2_Z))
        {
          MessagePack.Message1000020(ref QuestMessageList, ref QuestEventList); TapOK();
        }

        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_MessageBoard_3_X, Fix.VELGUS_MessageBoard_3_Y, Fix.VELGUS_MessageBoard_3_Z))
        {
          MessagePack.Message1000040(ref QuestMessageList, ref QuestEventList); TapOK();
        }

        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_MessageBoard_4_X, Fix.VELGUS_MessageBoard_4_Y, Fix.VELGUS_MessageBoard_4_Z))
        {
          MessagePack.Message1000100(ref QuestMessageList, ref QuestEventList); TapOK();
        }

        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_MessageBoard_5_X, Fix.VELGUS_MessageBoard_5_Y, Fix.VELGUS_MessageBoard_5_Z))
        {
          MessagePack.Message1000160(ref QuestMessageList, ref QuestEventList); TapOK();
        }
      }
      else if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
      {
        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_2_MessageBoard_1_X, Fix.VELGUS_2_MessageBoard_1_Y, Fix.VELGUS_2_MessageBoard_1_Z))
        {
          MessagePack.Message1000200(ref QuestMessageList, ref QuestEventList); TapOK();
        }

        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_2_MessageBoard_2_X, Fix.VELGUS_2_MessageBoard_2_Y, Fix.VELGUS_2_MessageBoard_2_Z))
        {
          MessagePack.Message1000209(ref QuestMessageList, ref QuestEventList); TapOK();
        }

        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_2_MessageBoard_3_X, Fix.VELGUS_2_MessageBoard_3_Y, Fix.VELGUS_2_MessageBoard_3_Z))
        {
          MessagePack.Message1000211(ref QuestMessageList, ref QuestEventList); TapOK();
        }

        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_2_MessageBoard_4_X, Fix.VELGUS_2_MessageBoard_4_Y, Fix.VELGUS_2_MessageBoard_4_Z))
        {
          MessagePack.Message1000213(ref QuestMessageList, ref QuestEventList); TapOK();
        }

        if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_2_MessageBoard_5_X, Fix.VELGUS_2_MessageBoard_5_Y, Fix.VELGUS_2_MessageBoard_5_Z))
        {
          MessagePack.Message1000217(ref QuestMessageList, ref QuestEventList); TapOK();
        }
      }
      return;
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.OhranTower_Door_ShadowMoon)
    {
      if (One.TF.FindBackPackItem(Fix.SHADOW_MOON_KEY))
      {
        MessagePack.Message800041(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      else
      {
        Debug.Log("fieldObjBefore is OhranTower_Door_ShadowMoon, then no move");
        MessagePack.Message800040(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      return;
    }
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.OhranTower_Door_SunBurst)
    {
      if (One.TF.FindBackPackItem(Fix.SUN_BURST_KEY))
      {
        MessagePack.Message800043(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      else
      {
        Debug.Log("fieldObjBefore is OhranTower_Door_ShadowMoon, then no move");
        MessagePack.Message800042(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      return;
    }
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.OhranTower_Door_StarDust)
    {
      Debug.Log("fieldObjBefore is OhranTower_Door_StarDust, then no move");
      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      return;
    }
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.OhranTower_Door_OriginRoad)
    {
      if (One.TF.FindBackPackItem(Fix.ORIGIN_ROAD_KEY))
      {
        MessagePack.Message800141(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      else
      {
        Debug.Log("fieldObjBefore is OhranTower_Door_OriginRoad, then no move");
        MessagePack.Message800140(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      return;
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Velgus_SecretWall)
    {
      CurrentEventObject = fieldObjBefore;
      // 第一階層
      if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_SECRETWALL_5_X, Fix.VELGUS_SECRETWALL_5_Y, Fix.VELGUS_SECRETWALL_5_Z))
      {
        if (direction == Fix.Direction.Top)
        {
          MessagePack.Message1000015(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        else
        {
          One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
        }
        return;
      }
      if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_SECRETWALL_63_X, Fix.VELGUS_SECRETWALL_63_Y, Fix.VELGUS_SECRETWALL_63_Z))
      {
        if (direction == Fix.Direction.Right && One.TF.Event_Message1000040_VelgusChantSuccess)
        {
          MessagePack.Message1000068(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        else
        {
          // 条件を満たしていない場合は開かないが、WallHitの音は出さない。
          //One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
        }
        return;
      }

      // 第二階層
      if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_SECRETWALL_245_X, Fix.VELGUS_SECRETWALL_245_Y, Fix.VELGUS_SECRETWALL_245_Z))
      {
        if (direction == Fix.Direction.Right && One.TF.Event_Message1000215 == false)
        {
          MessagePack.Message1000215(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        return;
      }

      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      return;
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Velgus_FakeSea)
    {
      //Debug.Log("fieldObjBefore Velgus_FakeSea: " + fieldObjBefore.transform.localPosition.ToString());
      //Debug.Log("X: " + fieldObjBefore.transform.localPosition.x + " " + objVelgusMovingTile2.transform.localPosition.x);
      //Debug.Log("Z: " + fieldObjBefore.transform.localPosition.z + " " + objVelgusMovingTile2.transform.localPosition.z);

      if (objVelgusMovingTile1 != null &&
          fieldObjBefore.transform.localPosition.x - 0.1f < objVelgusMovingTile1.transform.localPosition.x &&
          objVelgusMovingTile1.transform.localPosition.x < fieldObjBefore.transform.localPosition.x + 0.1f &&
          fieldObjBefore.transform.localPosition.z - 0.1f < objVelgusMovingTile1.transform.localPosition.z &&
          objVelgusMovingTile1.transform.localPosition.z < fieldObjBefore.transform.localPosition.z + 0.1f)
      {
        // 何もせず通過
        Debug.Log("DETECT objVelgusMovingTile1 within Velgus_FakeSea");
        Debug.Log("X: " + fieldObjBefore.transform.localPosition.x + " " + objVelgusMovingTile1.transform.localPosition.x);
        Debug.Log("Z: " + fieldObjBefore.transform.localPosition.z + " " + objVelgusMovingTile1.transform.localPosition.z);
      }
      else if (objVelgusMovingTile2 != null &&
          fieldObjBefore.transform.localPosition.x - 0.1f < objVelgusMovingTile2.transform.localPosition.x &&
          objVelgusMovingTile2.transform.localPosition.x < fieldObjBefore.transform.localPosition.x + 0.1f &&
          fieldObjBefore.transform.localPosition.z - 0.1f < objVelgusMovingTile2.transform.localPosition.z &&
          objVelgusMovingTile2.transform.localPosition.z < fieldObjBefore.transform.localPosition.z + 0.1f)
      {
        // 何もせず通過
        Debug.Log("DETECT objVelgusMovingTile2 within Velgus_FakeSea");
        Debug.Log("X: " + fieldObjBefore.transform.localPosition.x + " " + objVelgusMovingTile2.transform.localPosition.x);
        Debug.Log("Z: " + fieldObjBefore.transform.localPosition.z + " " + objVelgusMovingTile2.transform.localPosition.z);
      }
      else if (objVelgusMovingTile3 != null &&
          fieldObjBefore.transform.localPosition.x - 0.1f < objVelgusMovingTile3.transform.localPosition.x &&
          objVelgusMovingTile3.transform.localPosition.x < fieldObjBefore.transform.localPosition.x + 0.1f &&
          fieldObjBefore.transform.localPosition.z - 0.1f < objVelgusMovingTile3.transform.localPosition.z &&
          objVelgusMovingTile3.transform.localPosition.z < fieldObjBefore.transform.localPosition.z + 0.1f)
      {
        // 何もせず通過
        Debug.Log("DETECT objVelgusMovingTile3 within Velgus_FakeSea");
        Debug.Log("X: " + fieldObjBefore.transform.localPosition.x + " " + objVelgusMovingTile3.transform.localPosition.x);
        Debug.Log("Z: " + fieldObjBefore.transform.localPosition.z + " " + objVelgusMovingTile3.transform.localPosition.z);
      }
      else if (objVelgusMovingTile4 != null &&
          fieldObjBefore.transform.localPosition.x - 0.1f < objVelgusMovingTile4.transform.localPosition.x &&
          objVelgusMovingTile4.transform.localPosition.x < fieldObjBefore.transform.localPosition.x + 0.1f &&
          fieldObjBefore.transform.localPosition.z - 0.1f < objVelgusMovingTile4.transform.localPosition.z &&
          objVelgusMovingTile4.transform.localPosition.z < fieldObjBefore.transform.localPosition.z + 0.1f)
      {
        // 何もせず通過
        Debug.Log("DETECT objVelgusMovingTile4 within Velgus_FakeSea");
        Debug.Log("X: " + fieldObjBefore.transform.localPosition.x + " " + objVelgusMovingTile4.transform.localPosition.x);
        Debug.Log("Z: " + fieldObjBefore.transform.localPosition.z + " " + objVelgusMovingTile4.transform.localPosition.z);
      }
      else if (objVelgusMovingTile5 != null &&
          fieldObjBefore.transform.localPosition.x - 0.1f < objVelgusMovingTile5.transform.localPosition.x &&
          objVelgusMovingTile5.transform.localPosition.x < fieldObjBefore.transform.localPosition.x + 0.1f &&
          fieldObjBefore.transform.localPosition.z - 0.1f < objVelgusMovingTile5.transform.localPosition.z &&
          objVelgusMovingTile5.transform.localPosition.z < fieldObjBefore.transform.localPosition.z + 0.1f)
      {
        // 何もせず通過
        Debug.Log("DETECT objVelgusMovingTile5 within Velgus_FakeSea");
        Debug.Log("X: " + fieldObjBefore.transform.localPosition.x + " " + objVelgusMovingTile5.transform.localPosition.x);
        Debug.Log("Z: " + fieldObjBefore.transform.localPosition.z + " " + objVelgusMovingTile5.transform.localPosition.z);
      }
      else if (objVelgusMovingTile2_1 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile2_1.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile2_2 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile2_2.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile2_3 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile2_3.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile2_4 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile2_4.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile2_5 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile2_5.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile2_6 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile2_6.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile2_7 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile2_7.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile2_8 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile2_8.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile3_1 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile3_1.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile3_2 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile3_2.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile3_3 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile3_3.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile3_4 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile3_4.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile3_5 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile3_5.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile3_6 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile3_6.gameObject)) { } // 何もせず通過
      else if (objVelgusMovingTile3_7 != null && DetectVelgusMovingTile(fieldObjBefore.gameObject, objVelgusMovingTile3_7.gameObject)) { } // 何もせず通過
      else
      {
        One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
        return;
      }
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Rock)
    {
      Debug.Log("Content.Rock detect: " + fieldObjBefore.ObjectId + " " + fieldObjBefore.transform.position.x + " " + fieldObjBefore.transform.position.y + " " + fieldObjBefore.transform.position.z);
      if (One.TF.FindBackPackItem(Fix.ITEM_MATOCK))
      {
        if (LocationFieldDetect(fieldObjBefore, Fix.ESMILIA_Rock_5_X, Fix.ESMILIA_Rock_5_Y, Fix.ESMILIA_Rock_5_Z))
        {
          MessagePack.Message000140(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.ESMILIA_Rock_6_X, Fix.ESMILIA_Rock_6_Y, Fix.ESMILIA_Rock_6_Z))
        {
          MessagePack.Message000150(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.ESMILIA_Rock_7_X, Fix.ESMILIA_Rock_7_Y, Fix.ESMILIA_Rock_7_Z))
        {
          MessagePack.Message000160(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.ESMILIA_Rock_4_X, Fix.ESMILIA_Rock_4_Y, Fix.ESMILIA_Rock_4_Z))
        {
          MessagePack.Message000170(ref QuestMessageList, ref QuestEventList); TapOK();
          return;
        }
        if (LocationFieldDetect(fieldObjBefore, Fix.ESMILIA_Rock_8_X, Fix.ESMILIA_Rock_8_Y, Fix.ESMILIA_Rock_8_Z))
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

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Brushwood)
    {
      if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_1_X, Fix.MYSTICFOREST_BRUSHWOOD_1_Y, Fix.MYSTICFOREST_BRUSHWOOD_1_Z))
      {
        MessagePack.Message900140(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_2_X, Fix.MYSTICFOREST_BRUSHWOOD_2_Y, Fix.MYSTICFOREST_BRUSHWOOD_2_Z))
      {
        MessagePack.Message900210(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_3_X, Fix.MYSTICFOREST_BRUSHWOOD_3_Y, Fix.MYSTICFOREST_BRUSHWOOD_3_Z))
      {
        MessagePack.Message900250(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_4_X, Fix.MYSTICFOREST_BRUSHWOOD_4_Y, Fix.MYSTICFOREST_BRUSHWOOD_4_Z))
      {
        MessagePack.Message900150(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_5_X, Fix.MYSTICFOREST_BRUSHWOOD_5_Y, Fix.MYSTICFOREST_BRUSHWOOD_5_Z))
      {
        MessagePack.Message900260(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_6_X, Fix.MYSTICFOREST_BRUSHWOOD_6_Y, Fix.MYSTICFOREST_BRUSHWOOD_6_Z))
      {
        MessagePack.Message900600(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      //if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_7_X, Fix.MYSTICFOREST_BRUSHWOOD_7_Y, Fix.MYSTICFOREST_BRUSHWOOD_7_Z))
      //{
      //  MessagePack.Message900620(ref QuestMessageList, ref QuestEventList); TapOK();
      //}
      //if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_8_X, Fix.MYSTICFOREST_BRUSHWOOD_8_Y, Fix.MYSTICFOREST_BRUSHWOOD_8_Z))
      //{
      //  MessagePack.Message900630(ref QuestMessageList, ref QuestEventList); TapOK();
      //}
      //if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_9_X, Fix.MYSTICFOREST_BRUSHWOOD_9_Y, Fix.MYSTICFOREST_BRUSHWOOD_9_Z))
      //{
      //  MessagePack.Message900640(ref QuestMessageList, ref QuestEventList); TapOK();
      //}
      //if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_10_X, Fix.MYSTICFOREST_BRUSHWOOD_10_Y, Fix.MYSTICFOREST_BRUSHWOOD_10_Z))
      //{
      //  MessagePack.Message900650(ref QuestMessageList, ref QuestEventList); TapOK();
      //}
      if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_11_X, Fix.MYSTICFOREST_BRUSHWOOD_11_Y, Fix.MYSTICFOREST_BRUSHWOOD_11_Z))
      {
        MessagePack.Message900380(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_BRUSHWOOD_12_X, Fix.MYSTICFOREST_BRUSHWOOD_12_Y, Fix.MYSTICFOREST_BRUSHWOOD_12_Z))
      {
        MessagePack.Message900700(ref QuestMessageList, ref QuestEventList); TapOK();
      }
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

      if (LocationFieldDetect(fieldObjBefore, Fix.MYSTICFOREST_ObsidianPortal_1_X, Fix.MYSTICFOREST_ObsidianPortal_1_Y, Fix.MYSTICFOREST_ObsidianPortal_1_Z))
      {
        MessagePack.Message900720(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_ObsidianStone_2_X, Fix.OHRANTOWER_ObsidianStone_2_Y, Fix.OHRANTOWER_ObsidianStone_2_Z))
      {
        MessagePack.Message801000(ref QuestMessageList, ref QuestEventList); TapOK();
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
    // オブジェクト（イベント壁）の判定
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.MysticForest_EventWall)
    {
      Debug.Log("fieldObjBefore is MysticForest_EventWall, then no move");
      if (One.TF.AvailableAdelBrigandy)
      {
        // 隠し通路（１）
        if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_56_X, Fix.MYSTICFOREST_Event_56_Y, Fix.MYSTICFOREST_Event_56_Z))
        {
          if (One.TF.Event_Message900120 == false)
          {
            MessagePack.Message900800(ref QuestMessageList, ref QuestEventList); TapOK();
          }
          else
          {
            MessagePack.Message900820(ref QuestMessageList, ref QuestEventList); TapOK();
          }
        }
        // 隠し通路（１）反対側
        else if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_57_X, Fix.MYSTICFOREST_Event_57_Y, Fix.MYSTICFOREST_Event_57_Z))
        {
          MessagePack.Message900810(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        // 隠し通路（２）
        else if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_58_X, Fix.MYSTICFOREST_Event_58_Y, Fix.MYSTICFOREST_Event_58_Z))
        {
          MessagePack.Message900830(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        // 隠し通路（２）反対側
        else if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_59_X, Fix.MYSTICFOREST_Event_59_Y, Fix.MYSTICFOREST_Event_59_Z))
        {
          MessagePack.Message900840(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        // 隠し通路（３）
        else if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_60_X, Fix.MYSTICFOREST_Event_60_Y, Fix.MYSTICFOREST_Event_60_Z))
        {
          MessagePack.Message900850(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        // 隠し通路（３）反対側
        else if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_61_X, Fix.MYSTICFOREST_Event_61_Y, Fix.MYSTICFOREST_Event_61_Z))
        {
          MessagePack.Message900860(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        // 隠し通路（４）
        else if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_62_X, Fix.MYSTICFOREST_Event_62_Y, Fix.MYSTICFOREST_Event_62_Z))
        {
          MessagePack.Message900870(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        // 隠し通路（４）反対側
        else if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_63_X, Fix.MYSTICFOREST_Event_63_Y, Fix.MYSTICFOREST_Event_63_Z))
        {
          MessagePack.Message900880(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        // 隠し通路（５）
        else if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_64_X, Fix.MYSTICFOREST_Event_64_Y, Fix.MYSTICFOREST_Event_64_Z))
        {
          MessagePack.Message900890(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        // 隠し通路（５）反対側
        else if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Event_65_X, Fix.MYSTICFOREST_Event_65_Y, Fix.MYSTICFOREST_Event_65_Z))
        {
          MessagePack.Message900900(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        else
        {
          Debug.Log("not detect... " + this.Player.transform.position.ToString());
        }
        return;
      }
      else
      {
        One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      }
      return;
    }
    // オブジェクト（ヴェルガスの海底神殿：壁ドア）の判定
    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.Velgus_WallDoor)
    {
      if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_DOOR_201_X, Fix.VELGUS_DOOR_201_Y, Fix.VELGUS_DOOR_201_Z))
      {
        if (One.TF.Event_Message1000137 == false)
        {
          if (One.TF.FindBackPackItem(Fix.VELGUS_KEY2))
          {
            MessagePack.Message1000176(ref QuestMessageList, ref QuestEventList); TapOK();
          }
          else
          {
            MessagePack.Message1000177(ref QuestMessageList, ref QuestEventList); TapOK();
          }
        }
      }
      else if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_DOOR_202_X, Fix.VELGUS_DOOR_202_Y, Fix.VELGUS_DOOR_202_Z))
      {
        if (One.TF.Event_Message1000139 == false)
        {
          if (One.TF.FindBackPackItem(Fix.VELGUS_KEY1))
          {
            MessagePack.Message1000178(ref QuestMessageList, ref QuestEventList); TapOK();
          }
          else
          {
            MessagePack.Message1000179(ref QuestMessageList, ref QuestEventList); TapOK();
          }
        }
      }
      else if (LocationFieldDetect(fieldObjBefore, Fix.VELGUS_DOOR_203_X, Fix.VELGUS_DOOR_203_Y, Fix.VELGUS_DOOR_203_Z))
      {
        if (One.TF.Event_Message1000141 == false)
        {
          if (One.TF.FindBackPackItem(Fix.VELGUS_KEY3))
          {
            MessagePack.Message1000180(ref QuestMessageList, ref QuestEventList); TapOK();
          }
          else
          {
            MessagePack.Message1000181(ref QuestMessageList, ref QuestEventList); TapOK();
          }
        }
      }

      Debug.Log("fieldObjBefore is Velgus_WallDoor, then no move");
      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      return;
    }

    if (fieldObjBefore != null && fieldObjBefore.content == FieldObject.Content.FloatingTile)
    {
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
      {
        Debug.Log("CurrentDungeonField is MAPFILE_OHRAN_TOWER");
        CurrentEventObject = fieldObjBefore;

        int num = 1;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_1_X, Fix.OHRANTOWER_FLOATINGTILE_1_Y, Fix.OHRANTOWER_FLOATINGTILE_1_Z))
        {
          One.TF.FieldObject_OhranTower_00001 = true;
          if (One.TF.Event_Message800020 == false)
          {
            MessagePack.Message800020(ref QuestMessageList, ref QuestEventList);
          }
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_2_X, Fix.OHRANTOWER_FLOATINGTILE_2_Y, Fix.OHRANTOWER_FLOATINGTILE_2_Z))
        {
          One.TF.FieldObject_OhranTower_00001 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_3_X, Fix.OHRANTOWER_FLOATINGTILE_3_Y, Fix.OHRANTOWER_FLOATINGTILE_3_Z))
        {
          One.TF.FieldObject_OhranTower_00002 = true;
          if (One.TF.Event_Message800020 == false)
          {
            MessagePack.Message800020(ref QuestMessageList, ref QuestEventList);
          }
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 16); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_4_X, Fix.OHRANTOWER_FLOATINGTILE_4_Y, Fix.OHRANTOWER_FLOATINGTILE_4_Z))
        {
          One.TF.FieldObject_OhranTower_00002 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 16); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_5_X, Fix.OHRANTOWER_FLOATINGTILE_5_Y, Fix.OHRANTOWER_FLOATINGTILE_5_Z))
        {
          One.TF.FieldObject_OhranTower_00003 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_6_X, Fix.OHRANTOWER_FLOATINGTILE_6_Y, Fix.OHRANTOWER_FLOATINGTILE_6_Z))
        {
          One.TF.FieldObject_OhranTower_00003 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_7_X, Fix.OHRANTOWER_FLOATINGTILE_7_Y, Fix.OHRANTOWER_FLOATINGTILE_7_Z))
        {
          One.TF.FieldObject_OhranTower_00004 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_8_X, Fix.OHRANTOWER_FLOATINGTILE_8_Y, Fix.OHRANTOWER_FLOATINGTILE_8_Z))
        {
          One.TF.FieldObject_OhranTower_00004 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_9_X, Fix.OHRANTOWER_FLOATINGTILE_9_Y, Fix.OHRANTOWER_FLOATINGTILE_9_Z))
        {
          One.TF.FieldObject_OhranTower_00005 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_10_X, Fix.OHRANTOWER_FLOATINGTILE_10_Y, Fix.OHRANTOWER_FLOATINGTILE_10_Z))
        {
          One.TF.FieldObject_OhranTower_00005 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_11_X, Fix.OHRANTOWER_FLOATINGTILE_11_Y, Fix.OHRANTOWER_FLOATINGTILE_11_Z))
        {
          One.TF.FieldObject_OhranTower_00006 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_12_X, Fix.OHRANTOWER_FLOATINGTILE_12_Y, Fix.OHRANTOWER_FLOATINGTILE_12_Z))
        {
          One.TF.FieldObject_OhranTower_00006 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_13_X, Fix.OHRANTOWER_FLOATINGTILE_13_Y, Fix.OHRANTOWER_FLOATINGTILE_13_Z))
        {
          One.TF.FieldObject_OhranTower_00007 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_14_X, Fix.OHRANTOWER_FLOATINGTILE_14_Y, Fix.OHRANTOWER_FLOATINGTILE_14_Z))
        {
          One.TF.FieldObject_OhranTower_00007 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_15_X, Fix.OHRANTOWER_FLOATINGTILE_15_Y, Fix.OHRANTOWER_FLOATINGTILE_15_Z))
        {
          One.TF.FieldObject_OhranTower_00008 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_16_X, Fix.OHRANTOWER_FLOATINGTILE_16_Y, Fix.OHRANTOWER_FLOATINGTILE_16_Z))
        {
          One.TF.FieldObject_OhranTower_00008 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_17_X, Fix.OHRANTOWER_FLOATINGTILE_17_Y, Fix.OHRANTOWER_FLOATINGTILE_17_Z))
        {
          One.TF.FieldObject_OhranTower_00009 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_18_X, Fix.OHRANTOWER_FLOATINGTILE_18_Y, Fix.OHRANTOWER_FLOATINGTILE_18_Z))
        {
          One.TF.FieldObject_OhranTower_00009 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_19_X, Fix.OHRANTOWER_FLOATINGTILE_19_Y, Fix.OHRANTOWER_FLOATINGTILE_19_Z))
        {
          One.TF.FieldObject_OhranTower_00010 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_20_X, Fix.OHRANTOWER_FLOATINGTILE_20_Y, Fix.OHRANTOWER_FLOATINGTILE_20_Z))
        {
          One.TF.FieldObject_OhranTower_00010 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_21_X, Fix.OHRANTOWER_FLOATINGTILE_21_Y, Fix.OHRANTOWER_FLOATINGTILE_21_Z))
        {
          One.TF.FieldObject_OhranTower_00011 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_22_X, Fix.OHRANTOWER_FLOATINGTILE_22_Y, Fix.OHRANTOWER_FLOATINGTILE_22_Z))
        {
          One.TF.FieldObject_OhranTower_00011 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_23_X, Fix.OHRANTOWER_FLOATINGTILE_23_Y, Fix.OHRANTOWER_FLOATINGTILE_23_Z))
        {
          One.TF.FieldObject_OhranTower_00012 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_24_X, Fix.OHRANTOWER_FLOATINGTILE_24_Y, Fix.OHRANTOWER_FLOATINGTILE_24_Z))
        {
          One.TF.FieldObject_OhranTower_00012 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_25_X, Fix.OHRANTOWER_FLOATINGTILE_25_Y, Fix.OHRANTOWER_FLOATINGTILE_25_Z))
        {
          One.TF.FieldObject_OhranTower_00013 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_26_X, Fix.OHRANTOWER_FLOATINGTILE_26_Y, Fix.OHRANTOWER_FLOATINGTILE_26_Z))
        {
          One.TF.FieldObject_OhranTower_00013 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_27_X, Fix.OHRANTOWER_FLOATINGTILE_27_Y, Fix.OHRANTOWER_FLOATINGTILE_27_Z))
        {
          One.TF.FieldObject_OhranTower_00014 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_28_X, Fix.OHRANTOWER_FLOATINGTILE_28_Y, Fix.OHRANTOWER_FLOATINGTILE_28_Z))
        {
          One.TF.FieldObject_OhranTower_00014 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_29_X, Fix.OHRANTOWER_FLOATINGTILE_29_Y, Fix.OHRANTOWER_FLOATINGTILE_29_Z))
        {
          One.TF.FieldObject_OhranTower_00015 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_30_X, Fix.OHRANTOWER_FLOATINGTILE_30_Y, Fix.OHRANTOWER_FLOATINGTILE_30_Z))
        {
          One.TF.FieldObject_OhranTower_00015 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_31_X, Fix.OHRANTOWER_FLOATINGTILE_31_Y, Fix.OHRANTOWER_FLOATINGTILE_31_Z))
        {
          One.TF.FieldObject_OhranTower_00016 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_32_X, Fix.OHRANTOWER_FLOATINGTILE_32_Y, Fix.OHRANTOWER_FLOATINGTILE_32_Z))
        {
          One.TF.FieldObject_OhranTower_00016 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_33_X, Fix.OHRANTOWER_FLOATINGTILE_33_Y, Fix.OHRANTOWER_FLOATINGTILE_33_Z))
        {
          One.TF.FieldObject_OhranTower_00017 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_34_X, Fix.OHRANTOWER_FLOATINGTILE_34_Y, Fix.OHRANTOWER_FLOATINGTILE_34_Z))
        {
          One.TF.FieldObject_OhranTower_00017 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_35_X, Fix.OHRANTOWER_FLOATINGTILE_35_Y, Fix.OHRANTOWER_FLOATINGTILE_35_Z))
        {
          One.TF.FieldObject_OhranTower_00018 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_36_X, Fix.OHRANTOWER_FLOATINGTILE_36_Y, Fix.OHRANTOWER_FLOATINGTILE_36_Z))
        {
          One.TF.FieldObject_OhranTower_00018 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_37_X, Fix.OHRANTOWER_FLOATINGTILE_37_Y, Fix.OHRANTOWER_FLOATINGTILE_37_Z))
        {
          One.TF.FieldObject_OhranTower_00019 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_38_X, Fix.OHRANTOWER_FLOATINGTILE_38_Y, Fix.OHRANTOWER_FLOATINGTILE_38_Z))
        {
          One.TF.FieldObject_OhranTower_00019 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_39_X, Fix.OHRANTOWER_FLOATINGTILE_39_Y, Fix.OHRANTOWER_FLOATINGTILE_39_Z))
        {
          One.TF.FieldObject_OhranTower_00020 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_40_X, Fix.OHRANTOWER_FLOATINGTILE_40_Y, Fix.OHRANTOWER_FLOATINGTILE_40_Z))
        {
          One.TF.FieldObject_OhranTower_00020 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_41_X, Fix.OHRANTOWER_FLOATINGTILE_41_Y, Fix.OHRANTOWER_FLOATINGTILE_41_Z))
        {
          One.TF.FieldObject_OhranTower_00021 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_42_X, Fix.OHRANTOWER_FLOATINGTILE_42_Y, Fix.OHRANTOWER_FLOATINGTILE_42_Z))
        {
          One.TF.FieldObject_OhranTower_00021 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_43_X, Fix.OHRANTOWER_FLOATINGTILE_43_Y, Fix.OHRANTOWER_FLOATINGTILE_43_Z))
        {
          One.TF.FieldObject_OhranTower_00022 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_44_X, Fix.OHRANTOWER_FLOATINGTILE_44_Y, Fix.OHRANTOWER_FLOATINGTILE_44_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00022 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00023 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 11); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_45_X, Fix.OHRANTOWER_FLOATINGTILE_45_Y, Fix.OHRANTOWER_FLOATINGTILE_45_Z))
        {
          One.TF.FieldObject_OhranTower_00023 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 11); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_46_X, Fix.OHRANTOWER_FLOATINGTILE_46_Y, Fix.OHRANTOWER_FLOATINGTILE_46_Z))
        {
          One.TF.FieldObject_OhranTower_00024 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_47_X, Fix.OHRANTOWER_FLOATINGTILE_47_Y, Fix.OHRANTOWER_FLOATINGTILE_47_Z))
        {
          One.TF.FieldObject_OhranTower_00024 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_48_X, Fix.OHRANTOWER_FLOATINGTILE_48_Y, Fix.OHRANTOWER_FLOATINGTILE_48_Z))
        {
          One.TF.FieldObject_OhranTower_00025 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 10); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_49_X, Fix.OHRANTOWER_FLOATINGTILE_49_Y, Fix.OHRANTOWER_FLOATINGTILE_49_Z))
        {
          One.TF.FieldObject_OhranTower_00025 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 10); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_50_X, Fix.OHRANTOWER_FLOATINGTILE_50_Y, Fix.OHRANTOWER_FLOATINGTILE_50_Z))
        {
          One.TF.FieldObject_OhranTower_00026 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 16); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_51_X, Fix.OHRANTOWER_FLOATINGTILE_51_Y, Fix.OHRANTOWER_FLOATINGTILE_51_Z))
        {
          One.TF.FieldObject_OhranTower_00026 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 16); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_52_X, Fix.OHRANTOWER_FLOATINGTILE_52_Y, Fix.OHRANTOWER_FLOATINGTILE_52_Z))
        {
          One.TF.FieldObject_OhranTower_00027 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_53_X, Fix.OHRANTOWER_FLOATINGTILE_53_Y, Fix.OHRANTOWER_FLOATINGTILE_53_Z))
        {
          One.TF.FieldObject_OhranTower_00027 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_54_X, Fix.OHRANTOWER_FLOATINGTILE_54_Y, Fix.OHRANTOWER_FLOATINGTILE_54_Z))
        {
          One.TF.FieldObject_OhranTower_00028 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 16); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_55_X, Fix.OHRANTOWER_FLOATINGTILE_55_Y, Fix.OHRANTOWER_FLOATINGTILE_55_Z))
        {
          One.TF.FieldObject_OhranTower_00028 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 16); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_56_X, Fix.OHRANTOWER_FLOATINGTILE_56_Y, Fix.OHRANTOWER_FLOATINGTILE_56_Z))
        {
          One.TF.FieldObject_OhranTower_00029 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 16); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_57_X, Fix.OHRANTOWER_FLOATINGTILE_57_Y, Fix.OHRANTOWER_FLOATINGTILE_57_Z))
        {
          One.TF.FieldObject_OhranTower_00029 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 16); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_58_X, Fix.OHRANTOWER_FLOATINGTILE_58_Y, Fix.OHRANTOWER_FLOATINGTILE_58_Z))
        {
          One.TF.FieldObject_OhranTower_00030 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_59_X, Fix.OHRANTOWER_FLOATINGTILE_59_Y, Fix.OHRANTOWER_FLOATINGTILE_59_Z))
        {
          One.TF.FieldObject_OhranTower_00030 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_60_X, Fix.OHRANTOWER_FLOATINGTILE_60_Y, Fix.OHRANTOWER_FLOATINGTILE_60_Z))
        {
          One.TF.FieldObject_OhranTower_00031 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_61_X, Fix.OHRANTOWER_FLOATINGTILE_61_Y, Fix.OHRANTOWER_FLOATINGTILE_61_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00031 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00032 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_62_X, Fix.OHRANTOWER_FLOATINGTILE_62_Y, Fix.OHRANTOWER_FLOATINGTILE_62_Z))
        {
          One.TF.FieldObject_OhranTower_00032 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_63_X, Fix.OHRANTOWER_FLOATINGTILE_63_Y, Fix.OHRANTOWER_FLOATINGTILE_63_Z))
        {
          One.TF.FieldObject_OhranTower_00033 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_64_X, Fix.OHRANTOWER_FLOATINGTILE_64_Y, Fix.OHRANTOWER_FLOATINGTILE_64_Z))
        {
          One.TF.FieldObject_OhranTower_00033 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_65_X, Fix.OHRANTOWER_FLOATINGTILE_65_Y, Fix.OHRANTOWER_FLOATINGTILE_65_Z))
        {
          One.TF.FieldObject_OhranTower_00034 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_66_X, Fix.OHRANTOWER_FLOATINGTILE_66_Y, Fix.OHRANTOWER_FLOATINGTILE_66_Z))
        {
          One.TF.FieldObject_OhranTower_00034 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_67_X, Fix.OHRANTOWER_FLOATINGTILE_67_Y, Fix.OHRANTOWER_FLOATINGTILE_67_Z))
        {
          One.TF.FieldObject_OhranTower_00035 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_68_X, Fix.OHRANTOWER_FLOATINGTILE_68_Y, Fix.OHRANTOWER_FLOATINGTILE_68_Z))
        {
          One.TF.FieldObject_OhranTower_00035 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_69_X, Fix.OHRANTOWER_FLOATINGTILE_69_Y, Fix.OHRANTOWER_FLOATINGTILE_69_Z))
        {
          One.TF.FieldObject_OhranTower_00036 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_70_X, Fix.OHRANTOWER_FLOATINGTILE_70_Y, Fix.OHRANTOWER_FLOATINGTILE_70_Z))
        {
          One.TF.FieldObject_OhranTower_00036 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_71_X, Fix.OHRANTOWER_FLOATINGTILE_71_Y, Fix.OHRANTOWER_FLOATINGTILE_71_Z))
        {
          One.TF.FieldObject_OhranTower_00037 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_72_X, Fix.OHRANTOWER_FLOATINGTILE_72_Y, Fix.OHRANTOWER_FLOATINGTILE_72_Z))
        {
          One.TF.FieldObject_OhranTower_00037 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_73_X, Fix.OHRANTOWER_FLOATINGTILE_73_Y, Fix.OHRANTOWER_FLOATINGTILE_73_Z))
        {
          One.TF.FieldObject_OhranTower_00038 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_74_X, Fix.OHRANTOWER_FLOATINGTILE_74_Y, Fix.OHRANTOWER_FLOATINGTILE_74_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00038 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00039 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_75_X, Fix.OHRANTOWER_FLOATINGTILE_75_Y, Fix.OHRANTOWER_FLOATINGTILE_75_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00039 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00040 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_76_X, Fix.OHRANTOWER_FLOATINGTILE_76_Y, Fix.OHRANTOWER_FLOATINGTILE_76_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00040 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00041 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_77_X, Fix.OHRANTOWER_FLOATINGTILE_77_Y, Fix.OHRANTOWER_FLOATINGTILE_77_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00041 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00042 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_78_X, Fix.OHRANTOWER_FLOATINGTILE_78_Y, Fix.OHRANTOWER_FLOATINGTILE_78_Z))
        {
          One.TF.FieldObject_OhranTower_00042 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_79_X, Fix.OHRANTOWER_FLOATINGTILE_79_Y, Fix.OHRANTOWER_FLOATINGTILE_79_Z))
        {
          One.TF.FieldObject_OhranTower_00043 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 18); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_80_X, Fix.OHRANTOWER_FLOATINGTILE_80_Y, Fix.OHRANTOWER_FLOATINGTILE_80_Z))
        {
          One.TF.FieldObject_OhranTower_00043 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 18); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_81_X, Fix.OHRANTOWER_FLOATINGTILE_81_Y, Fix.OHRANTOWER_FLOATINGTILE_81_Z))
        {
          One.TF.FieldObject_OhranTower_00044 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_82_X, Fix.OHRANTOWER_FLOATINGTILE_82_Y, Fix.OHRANTOWER_FLOATINGTILE_82_Z))
        {
          One.TF.FieldObject_OhranTower_00044 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_83_X, Fix.OHRANTOWER_FLOATINGTILE_83_Y, Fix.OHRANTOWER_FLOATINGTILE_83_Z))
        {
          One.TF.FieldObject_OhranTower_00045 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_84_X, Fix.OHRANTOWER_FLOATINGTILE_84_Y, Fix.OHRANTOWER_FLOATINGTILE_84_Z))
        {
          One.TF.FieldObject_OhranTower_00045 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_85_X, Fix.OHRANTOWER_FLOATINGTILE_85_Y, Fix.OHRANTOWER_FLOATINGTILE_85_Z))
        {
          One.TF.FieldObject_OhranTower_00046 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_86_X, Fix.OHRANTOWER_FLOATINGTILE_86_Y, Fix.OHRANTOWER_FLOATINGTILE_86_Z))
        {
          One.TF.FieldObject_OhranTower_00046 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_87_X, Fix.OHRANTOWER_FLOATINGTILE_87_Y, Fix.OHRANTOWER_FLOATINGTILE_87_Z))
        {
          One.TF.FieldObject_OhranTower_00047 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 19); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_88_X, Fix.OHRANTOWER_FLOATINGTILE_88_Y, Fix.OHRANTOWER_FLOATINGTILE_88_Z))
        {
          One.TF.FieldObject_OhranTower_00047 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 19); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_89_X, Fix.OHRANTOWER_FLOATINGTILE_89_Y, Fix.OHRANTOWER_FLOATINGTILE_89_Z))
        {
          One.TF.FieldObject_OhranTower_00048 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_90_X, Fix.OHRANTOWER_FLOATINGTILE_90_Y, Fix.OHRANTOWER_FLOATINGTILE_90_Z))
        {
          One.TF.FieldObject_OhranTower_00048 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_91_X, Fix.OHRANTOWER_FLOATINGTILE_91_Y, Fix.OHRANTOWER_FLOATINGTILE_91_Z))
        {
          One.TF.FieldObject_OhranTower_00049 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_92_X, Fix.OHRANTOWER_FLOATINGTILE_92_Y, Fix.OHRANTOWER_FLOATINGTILE_92_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00049 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00050 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_93_X, Fix.OHRANTOWER_FLOATINGTILE_93_Y, Fix.OHRANTOWER_FLOATINGTILE_93_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00050 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00051 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_94_X, Fix.OHRANTOWER_FLOATINGTILE_94_Y, Fix.OHRANTOWER_FLOATINGTILE_94_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00051 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00052 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_95_X, Fix.OHRANTOWER_FLOATINGTILE_95_Y, Fix.OHRANTOWER_FLOATINGTILE_95_Z))
        {
          One.TF.FieldObject_OhranTower_00052 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_96_X, Fix.OHRANTOWER_FLOATINGTILE_96_Y, Fix.OHRANTOWER_FLOATINGTILE_96_Z))
        {
          One.TF.FieldObject_OhranTower_00053 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_97_X, Fix.OHRANTOWER_FLOATINGTILE_97_Y, Fix.OHRANTOWER_FLOATINGTILE_97_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00053 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00054 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_98_X, Fix.OHRANTOWER_FLOATINGTILE_98_Y, Fix.OHRANTOWER_FLOATINGTILE_98_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00054 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00055 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_99_X, Fix.OHRANTOWER_FLOATINGTILE_99_Y, Fix.OHRANTOWER_FLOATINGTILE_99_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00055 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00056 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_100_X, Fix.OHRANTOWER_FLOATINGTILE_100_Y, Fix.OHRANTOWER_FLOATINGTILE_100_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00056 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00057 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_101_X, Fix.OHRANTOWER_FLOATINGTILE_101_Y, Fix.OHRANTOWER_FLOATINGTILE_101_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00057 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00058 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_102_X, Fix.OHRANTOWER_FLOATINGTILE_102_Y, Fix.OHRANTOWER_FLOATINGTILE_102_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00058 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00059 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_103_X, Fix.OHRANTOWER_FLOATINGTILE_103_Y, Fix.OHRANTOWER_FLOATINGTILE_103_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00059 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00060 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_104_X, Fix.OHRANTOWER_FLOATINGTILE_104_Y, Fix.OHRANTOWER_FLOATINGTILE_104_Z))
        {
          One.TF.FieldObject_OhranTower_00060 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_105_X, Fix.OHRANTOWER_FLOATINGTILE_105_Y, Fix.OHRANTOWER_FLOATINGTILE_105_Z))
        {
          One.TF.FieldObject_OhranTower_00061 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_106_X, Fix.OHRANTOWER_FLOATINGTILE_106_Y, Fix.OHRANTOWER_FLOATINGTILE_106_Z))
        {
          One.TF.FieldObject_OhranTower_00061 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z))
        {
          One.TF.FieldObject_OhranTower_00062 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_108_X, Fix.OHRANTOWER_FLOATINGTILE_108_Y, Fix.OHRANTOWER_FLOATINGTILE_108_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00062 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00063 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 18); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_109_X, Fix.OHRANTOWER_FLOATINGTILE_109_Y, Fix.OHRANTOWER_FLOATINGTILE_109_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00063 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 18); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00064 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_110_X, Fix.OHRANTOWER_FLOATINGTILE_110_Y, Fix.OHRANTOWER_FLOATINGTILE_110_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00064 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00065 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 1); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_111_X, Fix.OHRANTOWER_FLOATINGTILE_111_Y, Fix.OHRANTOWER_FLOATINGTILE_111_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00065 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 1); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00066 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_112_X, Fix.OHRANTOWER_FLOATINGTILE_112_Y, Fix.OHRANTOWER_FLOATINGTILE_112_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00066 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00067 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 1); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_113_X, Fix.OHRANTOWER_FLOATINGTILE_113_Y, Fix.OHRANTOWER_FLOATINGTILE_113_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00067 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 1); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00068 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_114_X, Fix.OHRANTOWER_FLOATINGTILE_114_Y, Fix.OHRANTOWER_FLOATINGTILE_114_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00068 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00069 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_115_X, Fix.OHRANTOWER_FLOATINGTILE_115_Y, Fix.OHRANTOWER_FLOATINGTILE_115_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00069 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00070 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 13); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_116_X, Fix.OHRANTOWER_FLOATINGTILE_116_Y, Fix.OHRANTOWER_FLOATINGTILE_116_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00070 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 13); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00071 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 17); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_117_X, Fix.OHRANTOWER_FLOATINGTILE_117_Y, Fix.OHRANTOWER_FLOATINGTILE_117_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00071 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 17); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00072 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_118_X, Fix.OHRANTOWER_FLOATINGTILE_118_Y, Fix.OHRANTOWER_FLOATINGTILE_118_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00072 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00073 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 26); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_119_X, Fix.OHRANTOWER_FLOATINGTILE_119_Y, Fix.OHRANTOWER_FLOATINGTILE_119_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00073 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 26); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00074 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 26); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_120_X, Fix.OHRANTOWER_FLOATINGTILE_120_Y, Fix.OHRANTOWER_FLOATINGTILE_120_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00074 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 26); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00075 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 26); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_121_X, Fix.OHRANTOWER_FLOATINGTILE_121_Y, Fix.OHRANTOWER_FLOATINGTILE_121_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00075 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 26); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00076 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_122_X, Fix.OHRANTOWER_FLOATINGTILE_122_Y, Fix.OHRANTOWER_FLOATINGTILE_122_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00076 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00077 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_123_X, Fix.OHRANTOWER_FLOATINGTILE_123_Y, Fix.OHRANTOWER_FLOATINGTILE_123_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00077 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00078 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_124_X, Fix.OHRANTOWER_FLOATINGTILE_124_Y, Fix.OHRANTOWER_FLOATINGTILE_124_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00078 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00079 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_125_X, Fix.OHRANTOWER_FLOATINGTILE_125_Y, Fix.OHRANTOWER_FLOATINGTILE_125_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00079 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00080 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_126_X, Fix.OHRANTOWER_FLOATINGTILE_126_Y, Fix.OHRANTOWER_FLOATINGTILE_126_Z))
        {
          One.TF.FieldObject_OhranTower_00080 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_127_X, Fix.OHRANTOWER_FLOATINGTILE_127_Y, Fix.OHRANTOWER_FLOATINGTILE_127_Z))
        {
          One.TF.FieldObject_OhranTower_00081 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_128_X, Fix.OHRANTOWER_FLOATINGTILE_128_Y, Fix.OHRANTOWER_FLOATINGTILE_128_Z))
        {
          One.TF.FieldObject_OhranTower_00081 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_129_X, Fix.OHRANTOWER_FLOATINGTILE_129_Y, Fix.OHRANTOWER_FLOATINGTILE_129_Z))
        {
          One.TF.FieldObject_OhranTower_00082 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_130_X, Fix.OHRANTOWER_FLOATINGTILE_130_Y, Fix.OHRANTOWER_FLOATINGTILE_130_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00082 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00083 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_131_X, Fix.OHRANTOWER_FLOATINGTILE_131_Y, Fix.OHRANTOWER_FLOATINGTILE_131_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00083 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00084 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_132_X, Fix.OHRANTOWER_FLOATINGTILE_132_Y, Fix.OHRANTOWER_FLOATINGTILE_132_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00084 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00085 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_133_X, Fix.OHRANTOWER_FLOATINGTILE_133_Y, Fix.OHRANTOWER_FLOATINGTILE_133_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00085 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00086 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_134_X, Fix.OHRANTOWER_FLOATINGTILE_134_Y, Fix.OHRANTOWER_FLOATINGTILE_134_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00086 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00087 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_135_X, Fix.OHRANTOWER_FLOATINGTILE_135_Y, Fix.OHRANTOWER_FLOATINGTILE_135_Z))
        {
          One.TF.FieldObject_OhranTower_00087 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_136_X, Fix.OHRANTOWER_FLOATINGTILE_136_Y, Fix.OHRANTOWER_FLOATINGTILE_136_Z))
        {
          One.TF.FieldObject_OhranTower_00088 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_137_X, Fix.OHRANTOWER_FLOATINGTILE_137_Y, Fix.OHRANTOWER_FLOATINGTILE_137_Z))
        {
          One.TF.FieldObject_OhranTower_00088 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_138_X, Fix.OHRANTOWER_FLOATINGTILE_138_Y, Fix.OHRANTOWER_FLOATINGTILE_138_Z))
        {
          One.TF.FieldObject_OhranTower_00089 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_139_X, Fix.OHRANTOWER_FLOATINGTILE_139_Y, Fix.OHRANTOWER_FLOATINGTILE_139_Z))
        {
          One.TF.FieldObject_OhranTower_00089 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_140_X, Fix.OHRANTOWER_FLOATINGTILE_140_Y, Fix.OHRANTOWER_FLOATINGTILE_140_Z))
        {
          One.TF.FieldObject_OhranTower_00090 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_141_X, Fix.OHRANTOWER_FLOATINGTILE_141_Y, Fix.OHRANTOWER_FLOATINGTILE_141_Z))
        {
          One.TF.FieldObject_OhranTower_00090 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_142_X, Fix.OHRANTOWER_FLOATINGTILE_142_Y, Fix.OHRANTOWER_FLOATINGTILE_142_Z))
        {
          One.TF.FieldObject_OhranTower_00091 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_143_X, Fix.OHRANTOWER_FLOATINGTILE_143_Y, Fix.OHRANTOWER_FLOATINGTILE_143_Z))
        {
          One.TF.FieldObject_OhranTower_00091 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z))
        {
          One.TF.FieldObject_OhranTower_00092 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_145_X, Fix.OHRANTOWER_FLOATINGTILE_145_Y, Fix.OHRANTOWER_FLOATINGTILE_145_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00092 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00093 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_146_X, Fix.OHRANTOWER_FLOATINGTILE_146_Y, Fix.OHRANTOWER_FLOATINGTILE_146_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00093 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00094 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 26); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_147_X, Fix.OHRANTOWER_FLOATINGTILE_147_Y, Fix.OHRANTOWER_FLOATINGTILE_147_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00094 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 26); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00095 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_148_X, Fix.OHRANTOWER_FLOATINGTILE_148_Y, Fix.OHRANTOWER_FLOATINGTILE_148_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00095 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00096 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_149_X, Fix.OHRANTOWER_FLOATINGTILE_149_Y, Fix.OHRANTOWER_FLOATINGTILE_149_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00096 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00097 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_150_X, Fix.OHRANTOWER_FLOATINGTILE_150_Y, Fix.OHRANTOWER_FLOATINGTILE_150_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00097 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00098 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_151_X, Fix.OHRANTOWER_FLOATINGTILE_151_Y, Fix.OHRANTOWER_FLOATINGTILE_151_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00098 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            if (One.TF.FieldObject_OhranTower_00091 == false)
            {
              MessagePack.MoveFloatingTileFail(ref QuestMessageList, ref QuestEventList, direction, 2); TapOK();
            }
            else
            {
              One.TF.FieldObject_OhranTower_00099 = true;
              MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
            }
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_152_X, Fix.OHRANTOWER_FLOATINGTILE_152_Y, Fix.OHRANTOWER_FLOATINGTILE_152_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            if (One.TF.FieldObject_OhranTower_00091 == false)
            {
              MessagePack.MoveFloatingTileFail(ref QuestMessageList, ref QuestEventList, direction, 2); TapOK();
            }
            else
            {
              One.TF.FieldObject_OhranTower_00099 = false;
              MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
            }
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00100 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_153_X, Fix.OHRANTOWER_FLOATINGTILE_153_Y, Fix.OHRANTOWER_FLOATINGTILE_153_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00100 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00101 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_154_X, Fix.OHRANTOWER_FLOATINGTILE_154_Y, Fix.OHRANTOWER_FLOATINGTILE_154_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00101 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00102 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
          }
          return;
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_155_X, Fix.OHRANTOWER_FLOATINGTILE_155_Y, Fix.OHRANTOWER_FLOATINGTILE_155_Z))
        {
          One.TF.FieldObject_OhranTower_00102 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_156_X, Fix.OHRANTOWER_FLOATINGTILE_156_Y, Fix.OHRANTOWER_FLOATINGTILE_156_Z))
        {
          One.TF.FieldObject_OhranTower_00103 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_157_X, Fix.OHRANTOWER_FLOATINGTILE_157_Y, Fix.OHRANTOWER_FLOATINGTILE_157_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00103 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00104 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_158_X, Fix.OHRANTOWER_FLOATINGTILE_158_Y, Fix.OHRANTOWER_FLOATINGTILE_158_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00104 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00105 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_159_X, Fix.OHRANTOWER_FLOATINGTILE_159_Y, Fix.OHRANTOWER_FLOATINGTILE_159_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00105 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00106 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_160_X, Fix.OHRANTOWER_FLOATINGTILE_160_Y, Fix.OHRANTOWER_FLOATINGTILE_160_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00106 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00107 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 14); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_161_X, Fix.OHRANTOWER_FLOATINGTILE_161_Y, Fix.OHRANTOWER_FLOATINGTILE_161_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00107 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 14); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00108 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_162_X, Fix.OHRANTOWER_FLOATINGTILE_162_Y, Fix.OHRANTOWER_FLOATINGTILE_162_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00108 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00109 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_163_X, Fix.OHRANTOWER_FLOATINGTILE_163_Y, Fix.OHRANTOWER_FLOATINGTILE_163_Z))
        {
          One.TF.FieldObject_OhranTower_00109 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_164_X, Fix.OHRANTOWER_FLOATINGTILE_164_Y, Fix.OHRANTOWER_FLOATINGTILE_164_Z))
        {
          One.TF.FieldObject_OhranTower_00110 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_165_X, Fix.OHRANTOWER_FLOATINGTILE_165_Y, Fix.OHRANTOWER_FLOATINGTILE_165_Z))
        {
          One.TF.FieldObject_OhranTower_00110 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_166_X, Fix.OHRANTOWER_FLOATINGTILE_166_Y, Fix.OHRANTOWER_FLOATINGTILE_166_Z))
        {
          One.TF.FieldObject_OhranTower_00111 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_167_X, Fix.OHRANTOWER_FLOATINGTILE_167_Y, Fix.OHRANTOWER_FLOATINGTILE_167_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00111 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00112 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 20); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_168_X, Fix.OHRANTOWER_FLOATINGTILE_168_Y, Fix.OHRANTOWER_FLOATINGTILE_168_Z))
        {
          if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00112 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 20); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00113 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_169_X, Fix.OHRANTOWER_FLOATINGTILE_169_Y, Fix.OHRANTOWER_FLOATINGTILE_169_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00113 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00114 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_170_X, Fix.OHRANTOWER_FLOATINGTILE_170_Y, Fix.OHRANTOWER_FLOATINGTILE_170_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00114 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            One.TF.FieldObject_OhranTower_00115 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_171_X, Fix.OHRANTOWER_FLOATINGTILE_171_Y, Fix.OHRANTOWER_FLOATINGTILE_171_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00115 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 3); TapOK();
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00116 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_172_X, Fix.OHRANTOWER_FLOATINGTILE_172_Y, Fix.OHRANTOWER_FLOATINGTILE_172_Z))
        {
          One.TF.FieldObject_OhranTower_00116 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 2); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_173_X, Fix.OHRANTOWER_FLOATINGTILE_173_Y, Fix.OHRANTOWER_FLOATINGTILE_173_Z))
        {
          One.TF.FieldObject_OhranTower_00117 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_174_X, Fix.OHRANTOWER_FLOATINGTILE_174_Y, Fix.OHRANTOWER_FLOATINGTILE_174_Z))
        {
          One.TF.FieldObject_OhranTower_00117 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_175_X, Fix.OHRANTOWER_FLOATINGTILE_175_Y, Fix.OHRANTOWER_FLOATINGTILE_175_Z))
        {
          One.TF.FieldObject_OhranTower_00118 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_176_X, Fix.OHRANTOWER_FLOATINGTILE_176_Y, Fix.OHRANTOWER_FLOATINGTILE_176_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00118 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 5); TapOK();
          }
          else if (direction == Fix.Direction.Left)
          {
            if (One.TF.FieldObject_OhranTower_00117 == false)
            {
              MessagePack.MoveFloatingTileFail(ref QuestMessageList, ref QuestEventList, direction, 1); TapOK();
            }
            else
            {
              One.TF.FieldObject_OhranTower_00119 = true;
              MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 18); TapOK();
            }
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_177_X, Fix.OHRANTOWER_FLOATINGTILE_177_Y, Fix.OHRANTOWER_FLOATINGTILE_177_Z))
        {
          if (One.TF.FieldObject_OhranTower_00117 == false)
          {
            MessagePack.MoveFloatingTileFail(ref QuestMessageList, ref QuestEventList, direction, 1); TapOK();
          }
          else
          {
            One.TF.FieldObject_OhranTower_00119 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 18); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_178_X, Fix.OHRANTOWER_FLOATINGTILE_178_Y, Fix.OHRANTOWER_FLOATINGTILE_178_Z))
        {
          One.TF.FieldObject_OhranTower_00120 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_179_X, Fix.OHRANTOWER_FLOATINGTILE_179_Y, Fix.OHRANTOWER_FLOATINGTILE_179_Z))
        {
          One.TF.FieldObject_OhranTower_00120 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_180_X, Fix.OHRANTOWER_FLOATINGTILE_180_Y, Fix.OHRANTOWER_FLOATINGTILE_180_Z))
        {
          One.TF.FieldObject_OhranTower_00121 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_181_X, Fix.OHRANTOWER_FLOATINGTILE_181_Y, Fix.OHRANTOWER_FLOATINGTILE_181_Z))
        {
          if (direction == Fix.Direction.Right)
          {
            One.TF.FieldObject_OhranTower_00121 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Bottom)
          {
            One.TF.FieldObject_OhranTower_00122 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_182_X, Fix.OHRANTOWER_FLOATINGTILE_182_Y, Fix.OHRANTOWER_FLOATINGTILE_182_Z))
        {
          if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00122 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 4); TapOK();
          }
          else if (direction == Fix.Direction.Right)
          {
            if (One.TF.FieldObject_OhranTower_00093 == false)
            {
              MessagePack.MoveFloatingTileFail(ref QuestMessageList, ref QuestEventList, direction, 3); TapOK();
            }
            else
            {
              One.TF.FieldObject_OhranTower_00123 = true;
              MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 11); TapOK();
            }
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_183_X, Fix.OHRANTOWER_FLOATINGTILE_183_Y, Fix.OHRANTOWER_FLOATINGTILE_183_Z))
        {
          if (direction == Fix.Direction.Left)
          {
            if (One.TF.FieldObject_OhranTower_00093 == false)
            {
              MessagePack.MoveFloatingTileFail(ref QuestMessageList, ref QuestEventList, direction, 3); TapOK();
            }
            else
            {
              One.TF.FieldObject_OhranTower_00123 = false;
              MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 11); TapOK();
            }
          }
          else if (direction == Fix.Direction.Top)
          {
            One.TF.FieldObject_OhranTower_00124 = true;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_184_X, Fix.OHRANTOWER_FLOATINGTILE_184_Y, Fix.OHRANTOWER_FLOATINGTILE_184_Z))
        {
          One.TF.FieldObject_OhranTower_00124 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 9); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_185_X, Fix.OHRANTOWER_FLOATINGTILE_185_Y, Fix.OHRANTOWER_FLOATINGTILE_185_Z))
        {
          One.TF.FieldObject_OhranTower_00125 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_186_X, Fix.OHRANTOWER_FLOATINGTILE_186_Y, Fix.OHRANTOWER_FLOATINGTILE_186_Z))
        {
          One.TF.FieldObject_OhranTower_00125 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 7); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_187_X, Fix.OHRANTOWER_FLOATINGTILE_187_Y, Fix.OHRANTOWER_FLOATINGTILE_187_Z))
        {
          One.TF.FieldObject_OhranTower_00126 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_188_X, Fix.OHRANTOWER_FLOATINGTILE_188_Y, Fix.OHRANTOWER_FLOATINGTILE_188_Z))
        {
          One.TF.FieldObject_OhranTower_00126 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 8); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_189_X, Fix.OHRANTOWER_FLOATINGTILE_189_Y, Fix.OHRANTOWER_FLOATINGTILE_189_Z))
        {
          CurrentEventObject2 = SearchObject(new Vector3(Fix.OHRANTOWER_FLOATINGTILE_195_X, Fix.OHRANTOWER_FLOATINGTILE_195_Y, Fix.OHRANTOWER_FLOATINGTILE_195_Z));
          One.TF.FieldObject_OhranTower_00127 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 56); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_190_X, Fix.OHRANTOWER_FLOATINGTILE_190_Y, Fix.OHRANTOWER_FLOATINGTILE_190_Z))
        {
          CurrentEventObject2 = SearchObject(new Vector3(Fix.OHRANTOWER_FLOATINGTILE_196_X, Fix.OHRANTOWER_FLOATINGTILE_196_Y, Fix.OHRANTOWER_FLOATINGTILE_196_Z));
          if (One.TF.FieldObject_OhranTower_00127)
          {
            One.TF.FieldObject_OhranTower_00127 = false;
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 56); TapOK();
          }
          else
          {
            One.TF.FieldObject_OhranTower_00127 = true;
            num--; // todo 汚いコード。必ず直す事。
            MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 56); TapOK();
            if (One.TF.Event_Message800260 == false)
            {
              MessagePack.Message800180(ref QuestMessageList, ref QuestEventList); TapOK();
              return;
            }
            num++;
          }
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_191_X, Fix.OHRANTOWER_FLOATINGTILE_191_Y, Fix.OHRANTOWER_FLOATINGTILE_191_Z))
        {
          One.TF.FieldObject_OhranTower_00128 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 15); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_192_X, Fix.OHRANTOWER_FLOATINGTILE_192_Y, Fix.OHRANTOWER_FLOATINGTILE_192_Z))
        {
          One.TF.FieldObject_OhranTower_00128 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 15); TapOK();
        }
        num++;

        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_193_X, Fix.OHRANTOWER_FLOATINGTILE_193_Y, Fix.OHRANTOWER_FLOATINGTILE_193_Z))
        {
          One.TF.FieldObject_OhranTower_00129 = true;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
        }
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_194_X, Fix.OHRANTOWER_FLOATINGTILE_194_Y, Fix.OHRANTOWER_FLOATINGTILE_194_Z))
        {
          One.TF.FieldObject_OhranTower_00129 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 6); TapOK();
        }
        num++;
        // 190に統合されているため、ココはコメントアウト
        //if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_196_X, Fix.OHRANTOWER_FLOATINGTILE_196_Y, Fix.OHRANTOWER_FLOATINGTILE_196_Z))
        //{
        //}
        num++;
        if (LocationFieldDetect(fieldObjBefore, Fix.OHRANTOWER_FLOATINGTILE_196_X, Fix.OHRANTOWER_FLOATINGTILE_196_Y, Fix.OHRANTOWER_FLOATINGTILE_196_Z))
        {
          CurrentEventObject2 = SearchObject(new Vector3(Fix.OHRANTOWER_FLOATINGTILE_190_X, Fix.OHRANTOWER_FLOATINGTILE_190_Y, Fix.OHRANTOWER_FLOATINGTILE_190_Z));
          One.TF.FieldObject_OhranTower_00127 = false;
          MessagePack.MoveFloatingTile(ref QuestMessageList, ref QuestEventList, direction, num, 56); TapOK();
        }
        num++;
      }
    }

    // オーランの塔、フローティングタイルがない場合でも、指定箇所については、フローティングタイルを引き戻せる事とする。
    if (direction == Fix.Direction.Top && nextLocation.x == Fix.OHRANTOWER_FLOATINGTILE_54_X && nextLocation.y == Fix.OHRANTOWER_FLOATINGTILE_54_Y && nextLocation.z == Fix.OHRANTOWER_FLOATINGTILE_54_Z)
    {
      CurrentEventObject = SearchObject(new Vector3(Fix.OHRANTOWER_FLOATINGTILE_55_X, Fix.OHRANTOWER_FLOATINGTILE_55_Y, Fix.OHRANTOWER_FLOATINGTILE_55_Z));
      if (CurrentEventObject != null)
      {
        One.TF.FieldObject_OhranTower_00028 = false;
        MessagePack.CallbackFloatingtile(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }

    tile = SearchNextTile(this.Player.transform.position, direction);
    TileInformation beforeTile = tile;

    if (beforeTile != null)
    {
      Debug.Log("beforeTile: " + beforeTile.transform.position.ToString());
    }

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

    // 移動不可のチェック
    if (BlockCheck(Player, tile) == false)
    {
      One.PlaySoundEffect(Fix.SOUND_WALL_HIT);
      return;
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

      #region "エスミリア草原区域"
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
      {
        string treasureName = String.Empty;

        Debug.Log("Detect fieldObj: " + location);

        if (One.TF.Treasure_EsmiliaGrassField_00001 == false && location.x == Fix.ESMILIA_Treasure_1_X && location.y == Fix.ESMILIA_Treasure_1_Y && location.z == Fix.ESMILIA_Treasure_1_Z)
        {
          treasureName = Fix.FINE_SWORD;
        }
        if (One.TF.Treasure_EsmiliaGrassField_00002 == false && location.x == Fix.ESMILIA_Treasure_2_X && location.y == Fix.ESMILIA_Treasure_2_Y && location.z == Fix.ESMILIA_Treasure_2_Z)
        {
          treasureName = Fix.GREEN_PENDANT;
        }
        if (One.TF.Treasure_EsmiliaGrassField_00003 == false && location.x == Fix.ESMILIA_Treasure_3_X && location.y == Fix.ESMILIA_Treasure_3_Y && location.z == Fix.ESMILIA_Treasure_3_Z)
        {
          treasureName = Fix.FINE_ORB;
        }
        if (One.TF.Treasure_EsmiliaGrassField_00004 == false && location.x == Fix.ESMILIA_Treasure_4_X && location.y == Fix.ESMILIA_Treasure_4_Y && location.z == Fix.ESMILIA_Treasure_4_Z)
        {
          treasureName = Fix.FLAT_SHOES;
        }
        if (One.TF.Treasure_EsmiliaGrassField_00005 == false && location.x == Fix.ESMILIA_Treasure_5_X && location.y == Fix.ESMILIA_Treasure_5_Y && location.z == Fix.ESMILIA_Treasure_5_Z)
        {
          treasureName = Fix.COMPACT_EARRING;
        }
        if (One.TF.Treasure_EsmiliaGrassField_00006 == false && location.x == Fix.ESMILIA_Treasure_6_X && location.y == Fix.ESMILIA_Treasure_6_Y && location.z == Fix.ESMILIA_Treasure_6_Z)
        {
          treasureName = Fix.CHERRY_CHOKER;
        }
        if (One.TF.Treasure_EsmiliaGrassField_00007 == false && location.x == Fix.ESMILIA_Treasure_7_X && location.y == Fix.ESMILIA_Treasure_7_Y && location.z == Fix.ESMILIA_Treasure_7_Z)
        {
          treasureName = Fix.ITEM_MATOCK;
        }
        if (One.TF.Treasure_EsmiliaGrassField_00008 == false && location.x == Fix.ESMILIA_Treasure_8_X && location.y == Fix.ESMILIA_Treasure_8_Y && location.z == Fix.ESMILIA_Treasure_8_Z)
        {
          treasureName = Fix.FINE_SHIELD;
        }
        if (One.TF.Treasure_EsmiliaGrassField_00009 == false && location.x == Fix.ESMILIA_Treasure_9_X && location.y == Fix.ESMILIA_Treasure_9_Y && location.z == Fix.ESMILIA_Treasure_9_Z)
        {
          treasureName = Fix.FINE_ARMOR;
        }
        if (One.TF.Treasure_EsmiliaGrassField_00010 == false && location.x == Fix.ESMILIA_Treasure_10_X && location.y == Fix.ESMILIA_Treasure_10_Y && location.z == Fix.ESMILIA_Treasure_10_Z)
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
          treasureName = Fix.COLD_SPLASH_CLAW;
        }
        if (One.TF.Treasure_Goratrum2_00004 == false && location.x == Fix.GORATRUM_2_Treasure_4_X && location.y == Fix.GORATRUM_2_Treasure_4_Y && location.z == Fix.GORATRUM_2_Treasure_4_Z)
        {
          treasureName = Fix.BLUE_LIGHTNING_SWORD;
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
      #region "神秘の森"
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
      {
        string treasureName = String.Empty;

        Debug.Log("Detect fieldObj: " + location);

        if (One.TF.Treasure_MysticForest_00001 == false && location.x == Fix.MYSTICFOREST_Treasure_1_X && location.y == Fix.MYSTICFOREST_Treasure_1_Y && location.z == Fix.MYSTICFOREST_Treasure_1_Z)
        {
          treasureName = Fix.SMART_SWORD;
        }
        if (One.TF.Treasure_MysticForest_00002 == false && location.x == Fix.MYSTICFOREST_Treasure_2_X && location.y == Fix.MYSTICFOREST_Treasure_2_Y && location.z == Fix.MYSTICFOREST_Treasure_2_Z)
        {
          treasureName = Fix.BULKY_BOOK;
        }
        if (One.TF.Treasure_MysticForest_00003 == false && location.x == Fix.MYSTICFOREST_Treasure_3_X && location.y == Fix.MYSTICFOREST_Treasure_3_Y && location.z == Fix.MYSTICFOREST_Treasure_3_Z)
        {
          treasureName = Fix.WIDE_BUCKLER;
        }
        if (One.TF.Treasure_MysticForest_00004 == false && location.x == Fix.MYSTICFOREST_Treasure_4_X && location.y == Fix.MYSTICFOREST_Treasure_4_Y && location.z == Fix.MYSTICFOREST_Treasure_4_Z)
        {
          treasureName = Fix.KODAIEIJU_EDA;
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
          MessagePack.Message900435(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
        }
        if (One.TF.Treasure_MysticForest_00005 == false && location.x == Fix.MYSTICFOREST_Treasure_5_X && location.y == Fix.MYSTICFOREST_Treasure_5_Y && location.z == Fix.MYSTICFOREST_Treasure_5_Z)
        {
          treasureName = Fix.PURE_SINSEISUI;
        }
        if (One.TF.Treasure_MysticForest_00006 == false && location.x == Fix.MYSTICFOREST_Treasure_6_X && location.y == Fix.MYSTICFOREST_Treasure_6_Y && location.z == Fix.MYSTICFOREST_Treasure_6_Z)
        {
          treasureName = Fix.BRONZE_RING_TOBI;
        }
        if (One.TF.Treasure_MysticForest_00007 == false && location.x == Fix.MYSTICFOREST_Treasure_7_X && location.y == Fix.MYSTICFOREST_Treasure_7_Y && location.z == Fix.MYSTICFOREST_Treasure_7_Z)
        {
          treasureName = Fix.SUNLEAF_SEAL;
        }
        if (One.TF.Treasure_MysticForest_00008 == false && location.x == Fix.MYSTICFOREST_Treasure_8_X && location.y == Fix.MYSTICFOREST_Treasure_8_Y && location.z == Fix.MYSTICFOREST_Treasure_8_Z)
        {
          treasureName = Fix.SPARKLINE_EMBLEM;
        }
        if (One.TF.Treasure_MysticForest_00009 == false && location.x == Fix.MYSTICFOREST_Treasure_9_X && location.y == Fix.MYSTICFOREST_Treasure_9_Y && location.z == Fix.MYSTICFOREST_Treasure_9_Z)
        {
          treasureName = Fix.SMART_SHIELD;
        }
        if (One.TF.Treasure_MysticForest_00010 == false && location.x == Fix.MYSTICFOREST_Treasure_10_X && location.y == Fix.MYSTICFOREST_Treasure_10_Y && location.z == Fix.MYSTICFOREST_Treasure_10_Z)
        {
          treasureName = Fix.ENSHOUTOU;
        }
        if (One.TF.Treasure_MysticForest_00011 == false && location.x == Fix.MYSTICFOREST_Treasure_11_X && location.y == Fix.MYSTICFOREST_Treasure_11_Y && location.z == Fix.MYSTICFOREST_Treasure_11_Z)
        {
          treasureName = Fix.PHOTON_ZEAL_CROWN;
        }
        if (One.TF.Treasure_MysticForest_00012 == false && location.x == Fix.MYSTICFOREST_Treasure_12_X && location.y == Fix.MYSTICFOREST_Treasure_12_Y && location.z == Fix.MYSTICFOREST_Treasure_12_Z)
        {
          treasureName = Fix.SILK_ROBE;
        }
        if (One.TF.Treasure_MysticForest_00013 == false && location.x == Fix.MYSTICFOREST_Treasure_13_X && location.y == Fix.MYSTICFOREST_Treasure_13_Y && location.z == Fix.MYSTICFOREST_Treasure_13_Z)
        {
          treasureName = Fix.KIGAN_OFUDA;
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
          MessagePack.Message900440(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
        }
        if (One.TF.Treasure_MysticForest_00014 == false && location.x == Fix.MYSTICFOREST_Treasure_14_X && location.y == Fix.MYSTICFOREST_Treasure_14_Y && location.z == Fix.MYSTICFOREST_Treasure_14_Z)
        {
          treasureName = Fix.INTRINSIC_FROZEN_ORB;
        }
        if (One.TF.Treasure_MysticForest_00015 == false && location.x == Fix.MYSTICFOREST_Treasure_15_X && location.y == Fix.MYSTICFOREST_Treasure_15_Y && location.z == Fix.MYSTICFOREST_Treasure_15_Z)
        {
          treasureName = Fix.SQUARE_CHISEI;
        }
        if (One.TF.Treasure_MysticForest_00016 == false && location.x == Fix.MYSTICFOREST_Treasure_16_X && location.y == Fix.MYSTICFOREST_Treasure_16_Y && location.z == Fix.MYSTICFOREST_Treasure_16_Z)
        {
          treasureName = Fix.SQUARE_TANREN;
        }
        if (One.TF.Treasure_MysticForest_00017 == false && location.x == Fix.MYSTICFOREST_Treasure_17_X && location.y == Fix.MYSTICFOREST_Treasure_17_Y && location.z == Fix.MYSTICFOREST_Treasure_17_Z)
        {
          treasureName = Fix.MEIUN_PRISM_BOX;
        }
        if (One.TF.Treasure_MysticForest_00018 == false && location.x == Fix.MYSTICFOREST_Treasure_18_X && location.y == Fix.MYSTICFOREST_Treasure_18_Y && location.z == Fix.MYSTICFOREST_Treasure_18_Z)
        {
          treasureName = Fix.DEPLETH_SEED_PIERCE;
        }
        if (One.TF.Treasure_MysticForest_00019 == false && location.x == Fix.MYSTICFOREST_Treasure_19_X && location.y == Fix.MYSTICFOREST_Treasure_19_Y && location.z == Fix.MYSTICFOREST_Treasure_19_Z)
        {
          treasureName = Fix.GOTHIC_PLATE;
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
          treasureName = Fix.SUPERIOR_SWORD;
        }
        // 宝箱２
        if (One.TF.Treasure_OhranTower_00002 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_2_X, Fix.OHRANTOWER_Treasure_2_Y, Fix.OHRANTOWER_Treasure_2_Z))
        {
          treasureName = Fix.SUPERIOR_SWORD;
        }
        // 宝箱３
        if (One.TF.Treasure_OhranTower_00003 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_3_X, Fix.OHRANTOWER_Treasure_3_Y, Fix.OHRANTOWER_Treasure_3_Z))
        {
          treasureName = Fix.SUPERIOR_SHIELD;
        }
        // 宝箱４
        if (One.TF.Treasure_OhranTower_00004 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_4_X, Fix.OHRANTOWER_Treasure_4_Y, Fix.OHRANTOWER_Treasure_4_Z))
        {
          treasureName = Fix.SUPERIOR_ROBE;
        }
        // 宝箱５
        if (One.TF.Treasure_OhranTower_00005 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_5_X, Fix.OHRANTOWER_Treasure_5_Y, Fix.OHRANTOWER_Treasure_5_Z))
        {
          treasureName = Fix.SUPERIOR_ORB;
        }
        // 宝箱６
        if (One.TF.Treasure_OhranTower_00006 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_6_X, Fix.OHRANTOWER_Treasure_6_Y, Fix.OHRANTOWER_Treasure_6_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_STAFF;
        }
        // 宝箱７
        if (One.TF.Treasure_OhranTower_00007 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_7_X, Fix.OHRANTOWER_Treasure_7_Y, Fix.OHRANTOWER_Treasure_7_Z))
        {
          treasureName = Fix.SUPERIOR_LANCE;
        }
        // 宝箱８
        if (One.TF.Treasure_OhranTower_00008 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_8_X, Fix.OHRANTOWER_Treasure_8_Y, Fix.OHRANTOWER_Treasure_8_Z))
        {
          treasureName = Fix.SUPERIOR_CLAW;
        }
        // 宝箱９
        if (One.TF.Treasure_OhranTower_00009 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_9_X, Fix.OHRANTOWER_Treasure_9_Y, Fix.OHRANTOWER_Treasure_9_Z))
        {
          treasureName = Fix.SUPERIOR_SWORD;
        }
        // 宝箱１０
        if (One.TF.Treasure_OhranTower_00010 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_10_X, Fix.OHRANTOWER_Treasure_10_Y, Fix.OHRANTOWER_Treasure_10_Z))
        {
          treasureName = Fix.SUPERIOR_LANCE;
        }
        // 宝箱１１
        if (One.TF.Treasure_OhranTower_00011 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_11_X, Fix.OHRANTOWER_Treasure_11_Y, Fix.OHRANTOWER_Treasure_11_Z))
        {
          treasureName = Fix.SUPERIOR_AXE;
        }
        // 宝箱１２
        if (One.TF.Treasure_OhranTower_00012 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_12_X, Fix.OHRANTOWER_Treasure_12_Y, Fix.OHRANTOWER_Treasure_12_Z))
        {
          treasureName = Fix.SUPERIOR_ARMOR;
        }
        // 宝箱１３
        if (One.TF.Treasure_OhranTower_00013 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_13_X, Fix.OHRANTOWER_Treasure_13_Y, Fix.OHRANTOWER_Treasure_13_Z))
        {
          treasureName = Fix.SUPERIOR_CROSS;
        }
        // 宝箱１４
        if (One.TF.Treasure_OhranTower_00014 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_14_X, Fix.OHRANTOWER_Treasure_14_Y, Fix.OHRANTOWER_Treasure_14_Z))
        {
          treasureName = Fix.SUPERIOR_ROBE;
        }
        // 宝箱１５
        if (One.TF.Treasure_OhranTower_00015 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_15_X, Fix.OHRANTOWER_Treasure_15_Y, Fix.OHRANTOWER_Treasure_15_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_SWORD;
        }
        // 宝箱１６
        if (One.TF.Treasure_OhranTower_00016 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_16_X, Fix.OHRANTOWER_Treasure_16_Y, Fix.OHRANTOWER_Treasure_16_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_LANCE;
        }
        // 宝箱１７
        if (One.TF.Treasure_OhranTower_00017 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_17_X, Fix.OHRANTOWER_Treasure_17_Y, Fix.OHRANTOWER_Treasure_17_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_AXE;
        }
        // 宝箱１８
        if (One.TF.Treasure_OhranTower_00018 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_18_X, Fix.OHRANTOWER_Treasure_18_Y, Fix.OHRANTOWER_Treasure_18_Z))
        {
          treasureName = Fix.SUPERIOR_BOW;
        }
        // 宝箱１９
        if (One.TF.Treasure_OhranTower_00019 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_19_X, Fix.OHRANTOWER_Treasure_19_Y, Fix.OHRANTOWER_Treasure_19_Z))
        {
          treasureName = Fix.SUPERIOR_BOOK;
        }
        // 宝箱２０
        if (One.TF.Treasure_OhranTower_00020 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_20_X, Fix.OHRANTOWER_Treasure_20_Y, Fix.OHRANTOWER_Treasure_20_Z))
        {
          treasureName = Fix.SUPERIOR_ROD;
        }
        // 宝箱２１
        if (One.TF.Treasure_OhranTower_00021 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_21_X, Fix.OHRANTOWER_Treasure_21_Y, Fix.OHRANTOWER_Treasure_21_Z))
        {
          treasureName = Fix.SUPERIOR_ORB;
        }
        // 宝箱２２
        if (One.TF.Treasure_OhranTower_00022 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_22_X, Fix.OHRANTOWER_Treasure_22_Y, Fix.OHRANTOWER_Treasure_22_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_STAFF;
        }
        // 宝箱２３
        if (One.TF.Treasure_OhranTower_00023 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_23_X, Fix.OHRANTOWER_Treasure_23_Y, Fix.OHRANTOWER_Treasure_23_Z))
        {
          treasureName = Fix.SUPERIOR_SHIELD;
        }
        // 宝箱２４
        if (One.TF.Treasure_OhranTower_00024 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_24_X, Fix.OHRANTOWER_Treasure_24_Y, Fix.OHRANTOWER_Treasure_24_Z))
        {
          treasureName = Fix.SUPERIOR_SWORD;
        }
        // 宝箱２５
        if (One.TF.Treasure_OhranTower_00025 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_25_X, Fix.OHRANTOWER_Treasure_25_Y, Fix.OHRANTOWER_Treasure_25_Z))
        {
          treasureName = Fix.SUPERIOR_BOOK;
        }
        // 宝箱２６
        if (One.TF.Treasure_OhranTower_00026 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_26_X, Fix.OHRANTOWER_Treasure_26_Y, Fix.OHRANTOWER_Treasure_26_Z))
        {
          treasureName = Fix.SUPERIOR_ORB;
        }
        // 宝箱２７
        if (One.TF.Treasure_OhranTower_00027 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_27_X, Fix.OHRANTOWER_Treasure_27_Y, Fix.OHRANTOWER_Treasure_27_Z))
        {
          treasureName = Fix.SUPERIOR_ROD;
        }
        // 宝箱２８
        if (One.TF.Treasure_OhranTower_00028 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_28_X, Fix.OHRANTOWER_Treasure_28_Y, Fix.OHRANTOWER_Treasure_28_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_AXE;
        }
        // 宝箱２９
        if (One.TF.Treasure_OhranTower_00029 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_29_X, Fix.OHRANTOWER_Treasure_29_Y, Fix.OHRANTOWER_Treasure_29_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_LANCE;
        }
        // 宝箱３０
        if (One.TF.Treasure_OhranTower_00030 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_30_X, Fix.OHRANTOWER_Treasure_30_Y, Fix.OHRANTOWER_Treasure_30_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_STAFF;
        }
        // 宝箱３１
        if (One.TF.Treasure_OhranTower_00031 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_31_X, Fix.OHRANTOWER_Treasure_31_Y, Fix.OHRANTOWER_Treasure_31_Z))
        {
          treasureName = Fix.SUPERIOR_ARMOR;
        }
        // 宝箱３２
        if (One.TF.Treasure_OhranTower_00032 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_32_X, Fix.OHRANTOWER_Treasure_32_Y, Fix.OHRANTOWER_Treasure_32_Z))
        {
          treasureName = Fix.SUPERIOR_ROBE;
        }
        // 宝箱３３
        if (One.TF.Treasure_OhranTower_00033 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_33_X, Fix.OHRANTOWER_Treasure_33_Y, Fix.OHRANTOWER_Treasure_33_Z))
        {
          treasureName = Fix.SUPERIOR_CROSS;
        }
        // 宝箱３４
        if (One.TF.Treasure_OhranTower_00034 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_34_X, Fix.OHRANTOWER_Treasure_34_Y, Fix.OHRANTOWER_Treasure_34_Z))
        {
          treasureName = Fix.SUPERIOR_BOW;
        }
        // 宝箱３５
        if (One.TF.Treasure_OhranTower_00035 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_35_X, Fix.OHRANTOWER_Treasure_35_Y, Fix.OHRANTOWER_Treasure_35_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_LANCE;
        }
        // 宝箱３６
        if (One.TF.Treasure_OhranTower_00036 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_36_X, Fix.OHRANTOWER_Treasure_36_Y, Fix.OHRANTOWER_Treasure_36_Z))
        {
          treasureName = Fix.SUPERIOR_LARGE_AXE;
        }
        // 宝箱３７
        if (One.TF.Treasure_OhranTower_00037 == false && LocationFieldDetect(fieldObj, Fix.OHRANTOWER_Treasure_37_X, Fix.OHRANTOWER_Treasure_37_Y, Fix.OHRANTOWER_Treasure_37_Z))
        {
          treasureName = Fix.STAR_DUST_KEY;
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
          MessagePack.Message800053(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
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
      #region "ヴェルガスの海底神殿"
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
      {
        string treasureName = String.Empty;
        if (One.TF.Treasure_Velgus_00001 == false && location.x == Fix.VELGUS_TREASURE_1_X && location.y == Fix.VELGUS_TREASURE_1_Y && location.z == Fix.VELGUS_TREASURE_1_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
        }
        if (One.TF.Treasure_Velgus_00002 == false && location.x == Fix.VELGUS_TREASURE_2_X && location.y == Fix.VELGUS_TREASURE_2_Y && location.z == Fix.VELGUS_TREASURE_2_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
          MessagePack.Message1000028(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
        }
        if (One.TF.Treasure_Velgus_00003 == false && location.x == Fix.VELGUS_TREASURE_3_X && location.y == Fix.VELGUS_TREASURE_3_Y && location.z == Fix.VELGUS_TREASURE_3_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
        }
        if (One.TF.Treasure_Velgus_00004 == false && location.x == Fix.VELGUS_TREASURE_4_X && location.y == Fix.VELGUS_TREASURE_4_Y && location.z == Fix.VELGUS_TREASURE_4_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
        }
        if (One.TF.Treasure_Velgus_00005 == false && location.x == Fix.VELGUS_TREASURE_5_X && location.y == Fix.VELGUS_TREASURE_5_Y && location.z == Fix.VELGUS_TREASURE_5_Z)
        {
          treasureName = Fix.VELGUS_KEY1;
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
          MessagePack.Message1000061(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
        }
        if (One.TF.Treasure_Velgus_00006 == false && location.x == Fix.VELGUS_TREASURE_6_X && location.y == Fix.VELGUS_TREASURE_6_Y && location.z == Fix.VELGUS_TREASURE_6_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
        }
        if (One.TF.Treasure_Velgus_00007 == false && location.x == Fix.VELGUS_TREASURE_7_X && location.y == Fix.VELGUS_TREASURE_7_Y && location.z == Fix.VELGUS_TREASURE_7_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
        }
        if (One.TF.Treasure_Velgus_00008 == false && location.x == Fix.VELGUS_TREASURE_8_X && location.y == Fix.VELGUS_TREASURE_8_Y && location.z == Fix.VELGUS_TREASURE_8_Z)
        {
          treasureName = Fix.VELGUS_KEY2;
          MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
          MessagePack.Message1000153(ref QuestMessageList, ref QuestEventList);
          TapOK();
          return;
        }
        if (One.TF.Treasure_Velgus_00009 == false && location.x == Fix.VELGUS_TREASURE_9_X && location.y == Fix.VELGUS_TREASURE_9_Y && location.z == Fix.VELGUS_TREASURE_9_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
          if (One.TF.Event_Message1000132 == false)
          {
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
            MessagePack.Message1000171(ref QuestMessageList, ref QuestEventList);
            TapOK();
            return;
          }
        }
        if (One.TF.Treasure_Velgus_00010 == false && location.x == Fix.VELGUS_TREASURE_10_X && location.y == Fix.VELGUS_TREASURE_10_Y && location.z == Fix.VELGUS_TREASURE_10_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
          if (One.TF.Event_Message1000134 == false)
          {
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
            MessagePack.Message1000173(ref QuestMessageList, ref QuestEventList);
            TapOK();
            return;
          }
        }
        if (One.TF.Treasure_Velgus_00011 == false && location.x == Fix.VELGUS_TREASURE_11_X && location.y == Fix.VELGUS_TREASURE_11_Y && location.z == Fix.VELGUS_TREASURE_11_Z)
        {
          treasureName = Fix.VELGUS_KEY3;
          if (One.TF.Event_Message1000136 == false)
          {
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, treasureName);
            MessagePack.Message1000175(ref QuestMessageList, ref QuestEventList);
            TapOK();
            return;
          }
        }
        if (One.TF.Treasure_Velgus_00012 == false && location.x == Fix.VELGUS_TREASURE_12_X && location.y == Fix.VELGUS_TREASURE_12_Y && location.z == Fix.VELGUS_TREASURE_12_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
        }
        if (One.TF.Treasure_Velgus_00013 == false && location.x == Fix.VELGUS_TREASURE_13_X && location.y == Fix.VELGUS_TREASURE_13_Y && location.z == Fix.VELGUS_TREASURE_13_Z)
        {
          treasureName = Fix.EXCELLENT_SWORD;
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
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
      {
        string treasureName = String.Empty;
        if (One.TF.Treasure_Velgus2_00001 == false && location.x == Fix.VELGUS_2_TREASURE_1_X && location.y == Fix.VELGUS_2_TREASURE_1_Y && location.z == Fix.VELGUS_2_TREASURE_1_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00002 == false && location.x == Fix.VELGUS_2_TREASURE_2_X && location.y == Fix.VELGUS_2_TREASURE_2_Y && location.z == Fix.VELGUS_2_TREASURE_2_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00003 == false && location.x == Fix.VELGUS_2_TREASURE_3_X && location.y == Fix.VELGUS_2_TREASURE_3_Y && location.z == Fix.VELGUS_2_TREASURE_3_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00004 == false && location.x == Fix.VELGUS_2_TREASURE_4_X && location.y == Fix.VELGUS_2_TREASURE_4_Y && location.z == Fix.VELGUS_2_TREASURE_4_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00005 == false && location.x == Fix.VELGUS_2_TREASURE_5_X && location.y == Fix.VELGUS_2_TREASURE_5_Y && location.z == Fix.VELGUS_2_TREASURE_5_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00006 == false && location.x == Fix.VELGUS_2_TREASURE_6_X && location.y == Fix.VELGUS_2_TREASURE_6_Y && location.z == Fix.VELGUS_2_TREASURE_6_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00007 == false && location.x == Fix.VELGUS_2_TREASURE_7_X && location.y == Fix.VELGUS_2_TREASURE_7_Y && location.z == Fix.VELGUS_2_TREASURE_7_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00008 == false && location.x == Fix.VELGUS_2_TREASURE_8_X && location.y == Fix.VELGUS_2_TREASURE_8_Y && location.z == Fix.VELGUS_2_TREASURE_8_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00009 == false && location.x == Fix.VELGUS_2_TREASURE_9_X && location.y == Fix.VELGUS_2_TREASURE_9_Y && location.z == Fix.VELGUS_2_TREASURE_9_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00010 == false && location.x == Fix.VELGUS_2_TREASURE_10_X && location.y == Fix.VELGUS_2_TREASURE_10_Y && location.z == Fix.VELGUS_2_TREASURE_10_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00011 == false && location.x == Fix.VELGUS_2_TREASURE_11_X && location.y == Fix.VELGUS_2_TREASURE_11_Y && location.z == Fix.VELGUS_2_TREASURE_11_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00012 == false && location.x == Fix.VELGUS_2_TREASURE_12_X && location.y == Fix.VELGUS_2_TREASURE_12_Y && location.z == Fix.VELGUS_2_TREASURE_12_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00013 == false && location.x == Fix.VELGUS_2_TREASURE_13_X && location.y == Fix.VELGUS_2_TREASURE_13_Y && location.z == Fix.VELGUS_2_TREASURE_13_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00014 == false && location.x == Fix.VELGUS_2_TREASURE_14_X && location.y == Fix.VELGUS_2_TREASURE_14_Y && location.z == Fix.VELGUS_2_TREASURE_14_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00015 == false && location.x == Fix.VELGUS_2_TREASURE_15_X && location.y == Fix.VELGUS_2_TREASURE_15_Y && location.z == Fix.VELGUS_2_TREASURE_15_Z)
        {
          treasureName = Fix.MASTER_SWORD;
        }
        if (One.TF.Treasure_Velgus2_00016 == false && location.x == Fix.VELGUS_2_TREASURE_16_X && location.y == Fix.VELGUS_2_TREASURE_16_Y && location.z == Fix.VELGUS_2_TREASURE_16_Z)
        {
          treasureName = Fix.MASTER_SWORD;
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

        Debug.Log("TapOK: " + currentEvent.ToString() + " " + currentMessage);

        // ブラックアウトやホワイトアウトしている画面から元に戻す。
        if (currentEvent == MessagePack.ActionEvent.ReturnToNormal)
        {
          this.objBlackOut.SetActive(false);
          this.objWhiteOut.SetActive(false);
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.TurnToBlack)
        {
          this.objBlackOut.SetActive(true);
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.TurnToWhite)
        {
          this.objWhiteOut.SetActive(true);
          continue; // 継続
        }
        // ゲームオーバー、タイトルへ
        else if (currentEvent == MessagePack.ActionEvent.DungeonBadEnd)
        {
          One.ReInitializeGroundOne(false);
          One.StopDungeonMusic();
          SceneDimension.JumpToTitle();
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
        // 画面の情報をクリアする。
        else if (currentEvent == MessagePack.ActionEvent.MessageClear)
        {
          this.txtSystemMessage.text = string.Empty;
          this.txtQuestMessage.text = string.Empty;
          continue; // 継続
        }
        // 画面にシステムメッセージを表示する。
        else if (currentEvent == MessagePack.ActionEvent.MessageDisplay)
        {
          this.txtSystemMessage.text = currentMessage;
          this.panelSystemMessage.SetActive(true);
          return;
        }
        // システムメッセージを非表示する。
        else if (currentEvent == MessagePack.ActionEvent.HideMessageDisplay)
        {
          this.panelSystemMessage.SetActive(false);
          this.txtSystemMessage.text = string.Empty;
          continue; // 継続
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
        else if (currentEvent == MessagePack.ActionEvent.SceneAdd)
        {
          this.GroupQuestMessage.SetActive(false);
          this.panelSystemMessage.SetActive(false);
          this.txtSystemMessage.text = string.Empty;
          this.QuestMessageList.Clear();
          this.QuestMessageList.Clear();

          SceneManager.sceneUnloaded += UnloadedSceneAdd;
          SceneDimension.SceneAdd(currentMessage);
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
          else if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
          {
            if (currentMessage == Fix.VELGUS_DOWNSTAIR_205_O)
            {
              One.GoratrumHoleFalling2 = true;
              One.TF.Field_X = Fix.VELGUS_LOCATION_206_X;
              One.TF.Field_Y = Fix.VELGUS_LOCATION_206_Y + 1.0f;
              One.TF.Field_Z = Fix.VELGUS_LOCATION_206_Z;
              continue; // 継続
            }
          }
        }
        // 未到達タイルを更新する。
        else if (currentEvent == MessagePack.ActionEvent.UpdateUnknownTile)
        {
          // ダンジョン毎に特定領域を可視化
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD && currentMessage == "1")
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
              One.TF.KnownTileList_EsmiliaGrassField[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD && currentMessage == "2")
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
              One.TF.KnownTileList_EsmiliaGrassField[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD && currentMessage == "3")
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
              One.TF.KnownTileList_EsmiliaGrassField[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD && currentMessage == "10")
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
              One.TF.KnownTileList_EsmiliaGrassField[numbers[jj]] = true;
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

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST && currentMessage == "1")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 5; jj++)
            {
              for (int kk = 0; kk < 5; kk++)
              {
                numbers.Add(24 * 50 + 44 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_MysticForest[numbers[jj]] = true;
            }
          }

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS && currentMessage == "1")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 9; jj++)
            {
              for (int kk = 0; kk < 9; kk++)
              {
                numbers.Add(5 * 50 + 10 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple[numbers[jj]] = true;
            }
          }

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS && currentMessage == "2")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 11; jj++)
            {
              for (int kk = 0; kk < 11; kk++)
              {
                numbers.Add(4 * 50 + 20 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS && currentMessage == "3")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 9; jj++)
            {
              for (int kk = 0; kk < 11; kk++)
              {
                numbers.Add(18 * 50 + 22 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS && currentMessage == "4")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 7; jj++)
            {
              for (int kk = 0; kk < 13; kk++)
              {
                numbers.Add(18 * 50 + 34 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple[numbers[jj]] = true;
            }

            numbers.Clear();
            for (int jj = 0; jj < 4; jj++)
            {
              for (int kk = 0; kk < 7; kk++)
              {
                numbers.Add(25 * 50 + 34 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS && currentMessage == "5")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 5; jj++)
            {
              for (int kk = 0; kk < 8; kk++)
              {
                numbers.Add(24 * 50 + 41 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS && currentMessage == "6")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 14; jj++)
            {
              for (int kk = 0; kk < 14; kk++)
              {
                numbers.Add(15 * 50 + 5 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS && currentMessage == "7")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 6; jj++)
            {
              for (int kk = 0; kk < 7; kk++)
              {
                numbers.Add(7 * 50 + 1 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && currentMessage == "1")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 5; jj++)
            {
              for (int kk = 0; kk < 4; kk++)
              {
                numbers.Add(21 * 50 + 32 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple_2[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && currentMessage == "2")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 5; jj++)
            {
              for (int kk = 0; kk < 4; kk++)
              {
                numbers.Add(17 * 50 + 35 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple_2[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && currentMessage == "3")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 5; jj++)
            {
              for (int kk = 0; kk < 5; kk++)
              {
                numbers.Add(13 * 50 + 35 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple_2[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && currentMessage == "4")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 3; jj++)
            {
              for (int kk = 0; kk < 7; kk++)
              {
                numbers.Add(14 * 50 + 39 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple_2[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && currentMessage == "5")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 8; jj++)
            {
              for (int kk = 0; kk < 6; kk++)
              {
                numbers.Add(7 * 50 + 12 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple_2[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && currentMessage == "6")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 13; jj++)
            {
              for (int kk = 0; kk < 5; kk++)
              {
                numbers.Add(2 * 50 + 8 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple_2[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && currentMessage == "7")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 12; jj++)
            {
              for (int kk = 0; kk < 7; kk++)
              {
                numbers.Add(6 * 50 + 1 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple_2[numbers[jj]] = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2 && currentMessage == "8")
          {
            List<int> numbers = new List<int>();
            for (int jj = 0; jj < 4; jj++)
            {
              for (int kk = 0; kk < 5; kk++)
              {
                numbers.Add(2 * 50 + 4 + jj * 50 + kk);
              }
            }
            for (int jj = 0; jj < numbers.Count; jj++)
            {
              UnknownTileList[numbers[jj]].gameObject.SetActive(false);
              One.TF.KnownTileList_VelgusSeaTemple_2[numbers[jj]] = true;
            }
          }
        }
        // マップ上を自動移動（左）
        else if (currentEvent == MessagePack.ActionEvent.MoveLeft)
        {
          TileInformation tile = SearchNextTile(this.Player.transform.position, Fix.Direction.Left);
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
          TileInformation tile = SearchNextTile(this.Player.transform.position, Fix.Direction.Right);
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
          TileInformation tile = SearchNextTile(this.Player.transform.position, Fix.Direction.Top);
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
          TileInformation tile = SearchNextTile(this.Player.transform.position, Fix.Direction.Bottom);
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
          else
          {
            Debug.Log("CurrentEventObject is null...");
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
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveObjRise2)
        {
          // オーランの塔、2つ目の浮遊石を動かすために用意したもの。
          if (this.CurrentEventObject2 != null)
          {
            this.CurrentEventObject2.transform.position = new Vector3(this.CurrentEventObject2.transform.position.x,
                                                                     this.CurrentEventObject2.transform.position.y + 1.0f,
                                                                     this.CurrentEventObject2.transform.position.z);
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
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveObjFall2)
        {
          // オーランの塔、2つ目の浮遊石を動かすために用意したもの。
          if (this.CurrentEventObject2 != null)
          {
            this.CurrentEventObject2.transform.position = new Vector3(this.CurrentEventObject2.transform.position.x,
                                                                     this.CurrentEventObject2.transform.position.y - 1.0f,
                                                                     this.CurrentEventObject2.transform.position.z);
          }
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.ForceMoveObjRiseWithoutPlayer)
        {
          if (this.CurrentEventObject != null)
          {
            this.CurrentEventObject.transform.position = new Vector3(this.CurrentEventObject.transform.position.x,
                                                                     this.CurrentEventObject.transform.position.y + 1.0f,
                                                                     this.CurrentEventObject.transform.position.z);

            this.NextTapOkSleep = Convert.ToSingle(currentMessage);
            this.NextTapOk = true;
          }
          return; // 画面即時反映
        }
        else if (currentEvent == MessagePack.ActionEvent.MoveTopContinuous)
        {
          if (CurrentEventObject != null)
          {
            FieldObjectMoveLogic(CurrentEventObject, Fix.Direction.Top);
          }
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.MoveBottomContinuous)
        {
          if (CurrentEventObject != null)
          {
            FieldObjectMoveLogic(CurrentEventObject, Fix.Direction.Bottom);
          }
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.MoveLeftContinuous)
        {
          if (CurrentEventObject != null)
          {
            FieldObjectMoveLogic(CurrentEventObject, Fix.Direction.Left);
          }
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.MoveRightContinuous)
        {
          if (CurrentEventObject != null)
          {
            FieldObjectMoveLogic(CurrentEventObject, Fix.Direction.Right);
          }
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusBallReset)
        {
          if (One.TF.Event_Message1000130_Success == false)
          {
            FieldObject obj = SearchObject(FieldObject.Content.Velgus_BallRed);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLRED_170_X, Fix.VELGUS_BALLRED_170_Y, Fix.VELGUS_BALLRED_170_Z);
            }
            obj = SearchObject(FieldObject.Content.Velgus_BallBlue);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLBLUE_171_X, Fix.VELGUS_BALLBLUE_171_Y, Fix.VELGUS_BALLBLUE_171_Z);
            }
            obj = SearchObject(FieldObject.Content.Velgus_BallGreen);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLGREEN_172_X, Fix.VELGUS_BALLGREEN_172_Y, Fix.VELGUS_BALLGREEN_172_Z);
            }
            obj = SearchObject(FieldObject.Content.Velgus_BallYellow);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLYELLOW_173_X, Fix.VELGUS_BALLYELLOW_173_Y, Fix.VELGUS_BALLYELLOW_173_Z);
            }
          }
          else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
          {
            // 前回のゴール位置がリセット地点である。
            FieldObject obj = SearchObject(FieldObject.Content.Velgus_BallRed);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLREDGOAL_174_X, Fix.VELGUS_BALLREDGOAL_174_Y, Fix.VELGUS_BALLREDGOAL_174_Z);
            }
            obj = SearchObject(FieldObject.Content.Velgus_BallBlue);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLBLUEGOAL_175_X, Fix.VELGUS_BALLBLUEGOAL_175_Y, Fix.VELGUS_BALLBLUEGOAL_175_Z);
            }
            obj = SearchObject(FieldObject.Content.Velgus_BallGreen);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLGREENGOAL_176_X, Fix.VELGUS_BALLGREENGOAL_176_Y, Fix.VELGUS_BALLGREENGOAL_176_Z);
            }
            obj = SearchObject(FieldObject.Content.Velgus_BallYellow);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLYELLOWGOAL_177_X, Fix.VELGUS_BALLYELLOWGOAL_177_Y, Fix.VELGUS_BALLYELLOWGOAL_177_Z);
            }
          }
          else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
          {
            // 前回のゴール位置がリセット地点である。
            FieldObject obj = SearchObject(FieldObject.Content.Velgus_BallRed);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLREDGOAL2_187_X, Fix.VELGUS_BALLREDGOAL2_187_Y, Fix.VELGUS_BALLREDGOAL2_187_Z);
            }
            obj = SearchObject(FieldObject.Content.Velgus_BallBlue);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLBLUEGOAL2_188_X, Fix.VELGUS_BALLBLUEGOAL2_188_Y, Fix.VELGUS_BALLBLUEGOAL2_188_Z);
            }
            obj = SearchObject(FieldObject.Content.Velgus_BallGreen);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLGREENGOAL2_189_X, Fix.VELGUS_BALLGREENGOAL2_189_Y, Fix.VELGUS_BALLGREENGOAL2_189_Z);
            }
            obj = SearchObject(FieldObject.Content.Velgus_BallYellow);
            if (obj != null)
            {
              obj.transform.position = new Vector3(Fix.VELGUS_BALLYELLOWGOAL2_190_X, Fix.VELGUS_BALLYELLOWGOAL2_190_Y, Fix.VELGUS_BALLYELLOWGOAL2_190_Z);
            }
          }
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusBallCheckComplete)
        {
          FieldObject objBallRed = SearchObject(FieldObject.Content.Velgus_BallRed);
          FieldObject objBallBlue = SearchObject(FieldObject.Content.Velgus_BallBlue);
          FieldObject objBallGreen = SearchObject(FieldObject.Content.Velgus_BallGreen);
          FieldObject objBallYellow = SearchObject(FieldObject.Content.Velgus_BallYellow);
          if (objBallRed == null || objBallBlue == null || objBallGreen == null || objBallYellow == null)
          {
            Debug.Log("VelgusBallCheckComplete objBall null...");
            continue;
          }

          if (One.TF.Event_Message1000130_Success == false)
          {
            if (MatchFieldObjLocation(objBallRed, Fix.VELGUS_BALLREDGOAL_174_X, Fix.VELGUS_BALLREDGOAL_174_Y, Fix.VELGUS_BALLREDGOAL_174_Z) &&
                MatchFieldObjLocation(objBallBlue, Fix.VELGUS_BALLBLUEGOAL_175_X, Fix.VELGUS_BALLBLUEGOAL_175_Y, Fix.VELGUS_BALLBLUEGOAL_175_Z) &&
                MatchFieldObjLocation(objBallGreen, Fix.VELGUS_BALLGREENGOAL_176_X, Fix.VELGUS_BALLGREENGOAL_176_Y, Fix.VELGUS_BALLGREENGOAL_176_Z) &&
                MatchFieldObjLocation(objBallYellow, Fix.VELGUS_BALLYELLOWGOAL_177_X, Fix.VELGUS_BALLYELLOWGOAL_177_Y, Fix.VELGUS_BALLYELLOWGOAL_177_Z))
            {
              Debug.Log("VelgusBallCheckComplete 1 Match ALL !!");
              MessagePack.Message1000170(ref QuestMessageList, ref QuestEventList);
              continue;
            }
            else
            {
              Debug.Log("VelgusBallCheckComplete 2 not match...");
            }
            Debug.Log("VelgusBallCheckComplete 1 last continue...");
            continue;
          }
          else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
          {
            if (MatchFieldObjLocation(objBallRed, Fix.VELGUS_BALLREDGOAL2_187_X, Fix.VELGUS_BALLREDGOAL2_187_Y, Fix.VELGUS_BALLREDGOAL2_187_Z) &&
                MatchFieldObjLocation(objBallBlue, Fix.VELGUS_BALLBLUEGOAL2_188_X, Fix.VELGUS_BALLBLUEGOAL2_188_Y, Fix.VELGUS_BALLBLUEGOAL2_188_Z) &&
                MatchFieldObjLocation(objBallGreen, Fix.VELGUS_BALLGREENGOAL2_189_X, Fix.VELGUS_BALLGREENGOAL2_189_Y, Fix.VELGUS_BALLGREENGOAL2_189_Z) &&
                MatchFieldObjLocation(objBallYellow, Fix.VELGUS_BALLYELLOWGOAL2_190_X, Fix.VELGUS_BALLYELLOWGOAL2_190_Y, Fix.VELGUS_BALLYELLOWGOAL2_190_Z))
            {
              Debug.Log("VelgusBallCheckComplete 2 Match ALL !!");
              MessagePack.Message1000172(ref QuestMessageList, ref QuestEventList);
              continue;
            }
            else
            {
              Debug.Log("VelgusBallCheckComplete 2 not match...");
            }
            Debug.Log("VelgusBallCheckComplete 2 last continue...");
            continue;
          }
          else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
          {
            if (MatchFieldObjLocation(objBallRed, Fix.VELGUS_BALLREDGOAL3_196_X, Fix.VELGUS_BALLREDGOAL3_196_Y, Fix.VELGUS_BALLREDGOAL3_196_Z) &&
                MatchFieldObjLocation(objBallBlue, Fix.VELGUS_BALLBLUEGOAL3_197_X, Fix.VELGUS_BALLBLUEGOAL3_197_Y, Fix.VELGUS_BALLBLUEGOAL3_197_Z) &&
                MatchFieldObjLocation(objBallGreen, Fix.VELGUS_BALLGREENGOAL3_198_X, Fix.VELGUS_BALLGREENGOAL3_198_Y, Fix.VELGUS_BALLGREENGOAL3_198_Z) &&
                MatchFieldObjLocation(objBallYellow, Fix.VELGUS_BALLYELLOWGOAL3_199_X, Fix.VELGUS_BALLYELLOWGOAL3_199_Y, Fix.VELGUS_BALLYELLOWGOAL3_199_Z))
            {
              Debug.Log("VelgusBallCheckComplete 3 Match ALL !!");
              MessagePack.Message1000174(ref QuestMessageList, ref QuestEventList);
              continue;
            }
            else
            {
              Debug.Log("VelgusBallCheckComplete 3 not match...");
            }
            Debug.Log("VelgusBallCheckComplete 3 last continue...");
            continue;
          }

          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusCircleChange)
        {
          if (One.TF.Event_Message1000130_Success && One.TF.Event_Message1000130_Success_2 == false)
          {
            MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_RED_179_X, Fix.VELGUS_CIRCLE_RED_179_Y, Fix.VELGUS_CIRCLE_RED_179_Z), new Vector3(Fix.VELGUS_CIRCLE_RED_183_X, Fix.VELGUS_CIRCLE_RED_183_Y, Fix.VELGUS_CIRCLE_RED_183_Z));
            MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_BLUE_180_X, Fix.VELGUS_CIRCLE_BLUE_180_Y, Fix.VELGUS_CIRCLE_BLUE_180_Z), new Vector3(Fix.VELGUS_CIRCLE_BLUE_184_X, Fix.VELGUS_CIRCLE_BLUE_184_Y, Fix.VELGUS_CIRCLE_BLUE_184_Z));
            MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_GREEN_181_X, Fix.VELGUS_CIRCLE_GREEN_181_Y, Fix.VELGUS_CIRCLE_GREEN_181_Z), new Vector3(Fix.VELGUS_CIRCLE_GREEN_185_X, Fix.VELGUS_CIRCLE_GREEN_185_Y, Fix.VELGUS_CIRCLE_GREEN_185_Z));
            MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_YELLOW_182_X, Fix.VELGUS_CIRCLE_YELLOW_182_Y, Fix.VELGUS_CIRCLE_YELLOW_182_Z), new Vector3(Fix.VELGUS_CIRCLE_YELLOW_186_X, Fix.VELGUS_CIRCLE_YELLOW_186_Y, Fix.VELGUS_CIRCLE_YELLOW_186_Z));
          }
          else if (One.TF.Event_Message1000130_Success && One.TF.Event_Message1000130_Success_2 && One.TF.Event_Message1000130_Success_3 == false)
          {
            MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_RED_183_X, Fix.VELGUS_CIRCLE_RED_183_Y, Fix.VELGUS_CIRCLE_RED_183_Z), new Vector3(Fix.VELGUS_CIRCLE_RED_192_X, Fix.VELGUS_CIRCLE_RED_192_Y, Fix.VELGUS_CIRCLE_RED_192_Z));
            MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_BLUE_184_X, Fix.VELGUS_CIRCLE_BLUE_184_Y, Fix.VELGUS_CIRCLE_BLUE_184_Z), new Vector3(Fix.VELGUS_CIRCLE_BLUE_193_X, Fix.VELGUS_CIRCLE_BLUE_193_Y, Fix.VELGUS_CIRCLE_BLUE_193_Z));
            MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_GREEN_185_X, Fix.VELGUS_CIRCLE_GREEN_185_Y, Fix.VELGUS_CIRCLE_GREEN_185_Z), new Vector3(Fix.VELGUS_CIRCLE_GREEN_194_X, Fix.VELGUS_CIRCLE_GREEN_194_Y, Fix.VELGUS_CIRCLE_GREEN_194_Z));
            MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_YELLOW_186_X, Fix.VELGUS_CIRCLE_YELLOW_186_Y, Fix.VELGUS_CIRCLE_YELLOW_186_Z), new Vector3(Fix.VELGUS_CIRCLE_YELLOW_195_X, Fix.VELGUS_CIRCLE_YELLOW_195_Y, Fix.VELGUS_CIRCLE_YELLOW_195_Z));
          }
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusSpeedRunStart_1)
        {
          One.TF.Event_SpeedRun1_Progress = 0;
          this.Velgus_SpeedRun1_Timer = 300;
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusSpeedRunStart_2)
        {
          this.Velgus_SpeedRun2_Timer = 300;
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusSpeedRunStart_2_Next)
        {
          if (this.objVelgusSlidingTile != null)
          {
            Debug.Log("objVelgusSlidingTile x : " + this.Player.transform.position.x.ToString() + " " + this.objVelgusSlidingTile.transform.position.x.ToString());
            Debug.Log("objVelgusSlidingTile z : " + this.Player.transform.position.z.ToString() + " " + this.objVelgusSlidingTile.transform.position.z.ToString());

            if ((this.Player.transform.position.x == this.objVelgusSlidingTile.transform.position.x) && (this.Player.transform.position.z == this.objVelgusSlidingTile.transform.position.z))
            {
              this.VelgusSlidingTilePhase++;
              this.Velgus_SpeedRun2_Timer = 300;
              this.objVelgusSlidingTile.transform.localPosition = new Vector3(this.objVelgusSlidingTileLocation.x + this.VelgusSlidingTilePhase, this.objVelgusSlidingTileLocation.y, this.objVelgusSlidingTileLocation.z);
              // if (this.VelgusSlidingTilePhase == 0) { RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_229_X, Fix.VELGUS_FIXEDTILE_229_Y, Fix.VELGUS_FIXEDTILE_229_Z)); } // 最初のタイルは操作不要。
              if (this.VelgusSlidingTilePhase == 1) { RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_230_X, Fix.VELGUS_FIXEDTILE_230_Y, Fix.VELGUS_FIXEDTILE_230_Z)); }
              if (this.VelgusSlidingTilePhase == 2) { RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_231_X, Fix.VELGUS_FIXEDTILE_231_Y, Fix.VELGUS_FIXEDTILE_231_Z)); }
              if (this.VelgusSlidingTilePhase == 3) { RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_232_X, Fix.VELGUS_FIXEDTILE_232_Y, Fix.VELGUS_FIXEDTILE_232_Z)); }
              if (this.VelgusSlidingTilePhase == 4) { RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_233_X, Fix.VELGUS_FIXEDTILE_233_Y, Fix.VELGUS_FIXEDTILE_233_Z)); }
              if (this.VelgusSlidingTilePhase == 5) { RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_234_X, Fix.VELGUS_FIXEDTILE_234_Y, Fix.VELGUS_FIXEDTILE_234_Z)); }
              if (this.VelgusSlidingTilePhase == 6) { RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_235_X, Fix.VELGUS_FIXEDTILE_235_Y, Fix.VELGUS_FIXEDTILE_235_Z)); }
              if (this.VelgusSlidingTilePhase == 7)
              {
                RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_236_X, Fix.VELGUS_FIXEDTILE_236_Y, Fix.VELGUS_FIXEDTILE_236_Z));
                this.objVelgusSlidingTile.gameObject.SetActive(false);
              }
            }
            else
            {
              MessagePack.SpeedRun2_Failed(ref QuestMessageList, ref QuestEventList); TapOK();
            }
          }
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusSpeedRunStart_2_Reset)
        {
          // もう少しクラス構造を見直した方が良いが、コレで良しとする。
          //HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_229_X, Fix.VELGUS_FIXEDTILE_229_Y, Fix.VELGUS_FIXEDTILE_229_Z)); // 最初のタイルは隠さなくて良い。
          HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_230_X, Fix.VELGUS_FIXEDTILE_230_Y, Fix.VELGUS_FIXEDTILE_230_Z));
          HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_231_X, Fix.VELGUS_FIXEDTILE_231_Y, Fix.VELGUS_FIXEDTILE_231_Z));
          HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_232_X, Fix.VELGUS_FIXEDTILE_232_Y, Fix.VELGUS_FIXEDTILE_232_Z));
          HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_233_X, Fix.VELGUS_FIXEDTILE_233_Y, Fix.VELGUS_FIXEDTILE_233_Z));
          HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_234_X, Fix.VELGUS_FIXEDTILE_234_Y, Fix.VELGUS_FIXEDTILE_234_Z));
          HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_235_X, Fix.VELGUS_FIXEDTILE_235_Y, Fix.VELGUS_FIXEDTILE_235_Z));
          HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_236_X, Fix.VELGUS_FIXEDTILE_236_Y, Fix.VELGUS_FIXEDTILE_236_Z));
          HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_237_X, Fix.VELGUS_FIXEDTILE_237_Y, Fix.VELGUS_FIXEDTILE_237_Z));

          this.objVelgusSlidingTile.transform.localPosition = new Vector3(this.objVelgusSlidingTileLocation.x, this.objVelgusSlidingTileLocation.y, this.objVelgusSlidingTileLocation.z);
          this.Velgus_SpeedRun2_Timer = 0;
          this.VelgusSlidingTilePhase = 0;
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusSpeedRunStart_3)
        {
          this.Velgus_SpeedRun3_Timer = 999999; // 時間制限は要らないかもしれない。
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusSpeedRunStart_4)
        {
          this.Velgus_SpeedRun4_Timer = 500;
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusSpeedRunStart_5)
        {
          this.Velgus_SpeedRun5_Timer = 200;
        }
        else if (currentEvent == MessagePack.ActionEvent.VelgusCirculate3_Switch)
        {
          if (currentMessage == "1")
          {
            this.switchVelgusMovingTile3_1 = !this.switchVelgusMovingTile3_1;
          }
          else if (currentMessage == "2")
          {
            this.switchVelgusMovingTile3_2 = !this.switchVelgusMovingTile3_2;
          }
          else if (currentMessage == "3")
          {
            this.switchVelgusMovingTile3_3 = !this.switchVelgusMovingTile3_3;
          }
          else if (currentMessage == "4")
          {
            this.switchVelgusMovingTile3_4 = !this.switchVelgusMovingTile3_4;
          }
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

          #region "エスミリア草原区域"
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
          {
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_1_X, Fix.ESMILIA_Treasure_1_Y, Fix.ESMILIA_Treasure_1_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00001 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_2_X, Fix.ESMILIA_Treasure_2_Y, Fix.ESMILIA_Treasure_2_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00002 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_3_X, Fix.ESMILIA_Treasure_3_Y, Fix.ESMILIA_Treasure_3_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00003 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_4_X, Fix.ESMILIA_Treasure_4_Y, Fix.ESMILIA_Treasure_4_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00004 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_5_X, Fix.ESMILIA_Treasure_5_Y, Fix.ESMILIA_Treasure_5_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00005 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_6_X, Fix.ESMILIA_Treasure_6_Y, Fix.ESMILIA_Treasure_6_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00006 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_7_X, Fix.ESMILIA_Treasure_7_Y, Fix.ESMILIA_Treasure_7_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00007 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_8_X, Fix.ESMILIA_Treasure_8_Y, Fix.ESMILIA_Treasure_8_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00008 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_9_X, Fix.ESMILIA_Treasure_9_Y, Fix.ESMILIA_Treasure_9_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00009 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.ESMILIA_Treasure_10_X, Fix.ESMILIA_Treasure_10_Y, Fix.ESMILIA_Treasure_10_Z))
            {
              One.TF.Treasure_EsmiliaGrassField_00010 = true;
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
          #region "神秘の森"
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
          {
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_1_X, Fix.MYSTICFOREST_Treasure_1_Y, Fix.MYSTICFOREST_Treasure_1_Z))
            {
              One.TF.Treasure_MysticForest_00001 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_2_X, Fix.MYSTICFOREST_Treasure_2_Y, Fix.MYSTICFOREST_Treasure_2_Z))
            {
              One.TF.Treasure_MysticForest_00002 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_3_X, Fix.MYSTICFOREST_Treasure_3_Y, Fix.MYSTICFOREST_Treasure_3_Z))
            {
              One.TF.Treasure_MysticForest_00003 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_4_X, Fix.MYSTICFOREST_Treasure_4_Y, Fix.MYSTICFOREST_Treasure_4_Z))
            {
              One.TF.Treasure_MysticForest_00004 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_5_X, Fix.MYSTICFOREST_Treasure_5_Y, Fix.MYSTICFOREST_Treasure_5_Z))
            {
              One.TF.Treasure_MysticForest_00005 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_6_X, Fix.MYSTICFOREST_Treasure_6_Y, Fix.MYSTICFOREST_Treasure_6_Z))
            {
              One.TF.Treasure_MysticForest_00006 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_7_X, Fix.MYSTICFOREST_Treasure_7_Y, Fix.MYSTICFOREST_Treasure_7_Z))
            {
              One.TF.Treasure_MysticForest_00007 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_8_X, Fix.MYSTICFOREST_Treasure_8_Y, Fix.MYSTICFOREST_Treasure_8_Z))
            {
              One.TF.Treasure_MysticForest_00008 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_9_X, Fix.MYSTICFOREST_Treasure_9_Y, Fix.MYSTICFOREST_Treasure_9_Z))
            {
              One.TF.Treasure_MysticForest_00009 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_10_X, Fix.MYSTICFOREST_Treasure_10_Y, Fix.MYSTICFOREST_Treasure_10_Z))
            {
              One.TF.Treasure_MysticForest_00010 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_11_X, Fix.MYSTICFOREST_Treasure_11_Y, Fix.MYSTICFOREST_Treasure_11_Z))
            {
              One.TF.Treasure_MysticForest_00011 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_12_X, Fix.MYSTICFOREST_Treasure_12_Y, Fix.MYSTICFOREST_Treasure_12_Z))
            {
              One.TF.Treasure_MysticForest_00012 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_13_X, Fix.MYSTICFOREST_Treasure_13_Y, Fix.MYSTICFOREST_Treasure_13_Z))
            {
              One.TF.Treasure_MysticForest_00013 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_14_X, Fix.MYSTICFOREST_Treasure_14_Y, Fix.MYSTICFOREST_Treasure_14_Z))
            {
              One.TF.Treasure_MysticForest_00014 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_15_X, Fix.MYSTICFOREST_Treasure_15_Y, Fix.MYSTICFOREST_Treasure_15_Z))
            {
              One.TF.Treasure_MysticForest_00015 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_16_X, Fix.MYSTICFOREST_Treasure_16_Y, Fix.MYSTICFOREST_Treasure_16_Z))
            {
              One.TF.Treasure_MysticForest_00016 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_17_X, Fix.MYSTICFOREST_Treasure_17_Y, Fix.MYSTICFOREST_Treasure_17_Z))
            {
              One.TF.Treasure_MysticForest_00017 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_18_X, Fix.MYSTICFOREST_Treasure_18_Y, Fix.MYSTICFOREST_Treasure_18_Z))
            {
              One.TF.Treasure_MysticForest_00018 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.MYSTICFOREST_Treasure_19_X, Fix.MYSTICFOREST_Treasure_19_Y, Fix.MYSTICFOREST_Treasure_19_Z))
            {
              One.TF.Treasure_MysticForest_00019 = true;
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
            // 宝箱２４
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_24_X, Fix.OHRANTOWER_Treasure_24_Y, Fix.OHRANTOWER_Treasure_24_Z))
            {
              One.TF.Treasure_OhranTower_00024 = true;
            }
            // 宝箱２５
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_25_X, Fix.OHRANTOWER_Treasure_25_Y, Fix.OHRANTOWER_Treasure_25_Z))
            {
              One.TF.Treasure_OhranTower_00025 = true;
            }
            // 宝箱２６
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_26_X, Fix.OHRANTOWER_Treasure_26_Y, Fix.OHRANTOWER_Treasure_26_Z))
            {
              One.TF.Treasure_OhranTower_00026 = true;
            }
            // 宝箱２７
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_27_X, Fix.OHRANTOWER_Treasure_27_Y, Fix.OHRANTOWER_Treasure_27_Z))
            {
              One.TF.Treasure_OhranTower_00027 = true;
            }
            // 宝箱２８
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_28_X, Fix.OHRANTOWER_Treasure_28_Y, Fix.OHRANTOWER_Treasure_28_Z))
            {
              One.TF.Treasure_OhranTower_00028 = true;
            }
            // 宝箱２９
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_29_X, Fix.OHRANTOWER_Treasure_29_Y, Fix.OHRANTOWER_Treasure_29_Z))
            {
              One.TF.Treasure_OhranTower_00029 = true;
            }
            // 宝箱３０
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_30_X, Fix.OHRANTOWER_Treasure_30_Y, Fix.OHRANTOWER_Treasure_30_Z))
            {
              One.TF.Treasure_OhranTower_00030 = true;
            }
            // 宝箱３１
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_31_X, Fix.OHRANTOWER_Treasure_31_Y, Fix.OHRANTOWER_Treasure_31_Z))
            {
              One.TF.Treasure_OhranTower_00031 = true;
            }
            // 宝箱３２
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_32_X, Fix.OHRANTOWER_Treasure_32_Y, Fix.OHRANTOWER_Treasure_32_Z))
            {
              One.TF.Treasure_OhranTower_00032 = true;
            }
            // 宝箱３３
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_33_X, Fix.OHRANTOWER_Treasure_33_Y, Fix.OHRANTOWER_Treasure_33_Z))
            {
              One.TF.Treasure_OhranTower_00033 = true;
            }
            // 宝箱３４
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_34_X, Fix.OHRANTOWER_Treasure_34_Y, Fix.OHRANTOWER_Treasure_34_Z))
            {
              One.TF.Treasure_OhranTower_00034 = true;
            }
            // 宝箱３５
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_35_X, Fix.OHRANTOWER_Treasure_35_Y, Fix.OHRANTOWER_Treasure_35_Z))
            {
              One.TF.Treasure_OhranTower_00035 = true;
            }
            // 宝箱３６
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_36_X, Fix.OHRANTOWER_Treasure_36_Y, Fix.OHRANTOWER_Treasure_36_Z))
            {
              One.TF.Treasure_OhranTower_00036 = true;
            }
            // 宝箱３７
            if (this.Player.transform.position == new Vector3(Fix.OHRANTOWER_Treasure_37_X, Fix.OHRANTOWER_Treasure_37_Y, Fix.OHRANTOWER_Treasure_37_Z))
            {
              One.TF.Treasure_OhranTower_00037 = true;
            }
          }
          #endregion
          #region "ヴェルガスの海底神殿"
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
          {
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_1_X, Fix.VELGUS_TREASURE_1_Y, Fix.VELGUS_TREASURE_1_Z))
            {
              One.TF.Treasure_Velgus_00001 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_2_X, Fix.VELGUS_TREASURE_2_Y, Fix.VELGUS_TREASURE_2_Z))
            {
              One.TF.Treasure_Velgus_00002 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_3_X, Fix.VELGUS_TREASURE_3_Y, Fix.VELGUS_TREASURE_3_Z))
            {
              One.TF.Treasure_Velgus_00003 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_4_X, Fix.VELGUS_TREASURE_4_Y, Fix.VELGUS_TREASURE_4_Z))
            {
              One.TF.Treasure_Velgus_00004 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_5_X, Fix.VELGUS_TREASURE_5_Y, Fix.VELGUS_TREASURE_5_Z))
            {
              One.TF.Treasure_Velgus_00005 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_6_X, Fix.VELGUS_TREASURE_6_Y, Fix.VELGUS_TREASURE_6_Z))
            {
              One.TF.Treasure_Velgus_00006 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_7_X, Fix.VELGUS_TREASURE_7_Y, Fix.VELGUS_TREASURE_7_Z))
            {
              One.TF.Treasure_Velgus_00007 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_8_X, Fix.VELGUS_TREASURE_8_Y, Fix.VELGUS_TREASURE_8_Z))
            {
              One.TF.Treasure_Velgus_00008 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_9_X, Fix.VELGUS_TREASURE_9_Y, Fix.VELGUS_TREASURE_9_Z))
            {
              One.TF.Treasure_Velgus_00009 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_10_X, Fix.VELGUS_TREASURE_10_Y, Fix.VELGUS_TREASURE_10_Z))
            {
              One.TF.Treasure_Velgus_00010 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_11_X, Fix.VELGUS_TREASURE_11_Y, Fix.VELGUS_TREASURE_11_Z))
            {
              One.TF.Treasure_Velgus_00011 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_12_X, Fix.VELGUS_TREASURE_12_Y, Fix.VELGUS_TREASURE_12_Z))
            {
              One.TF.Treasure_Velgus_00012 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_TREASURE_13_X, Fix.VELGUS_TREASURE_13_Y, Fix.VELGUS_TREASURE_13_Z))
            {
              One.TF.Treasure_Velgus_00013 = true;
            }
          }
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
          {
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_1_X, Fix.VELGUS_2_TREASURE_1_Y, Fix.VELGUS_2_TREASURE_1_Z))
            {
              One.TF.Treasure_Velgus2_00001 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_2_X, Fix.VELGUS_2_TREASURE_2_Y, Fix.VELGUS_2_TREASURE_2_Z))
            {
              One.TF.Treasure_Velgus2_00002 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_3_X, Fix.VELGUS_2_TREASURE_3_Y, Fix.VELGUS_2_TREASURE_3_Z))
            {
              One.TF.Treasure_Velgus2_00003 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_4_X, Fix.VELGUS_2_TREASURE_4_Y, Fix.VELGUS_2_TREASURE_4_Z))
            {
              One.TF.Treasure_Velgus2_00004 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_5_X, Fix.VELGUS_2_TREASURE_5_Y, Fix.VELGUS_2_TREASURE_5_Z))
            {
              One.TF.Treasure_Velgus2_00005 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_6_X, Fix.VELGUS_2_TREASURE_6_Y, Fix.VELGUS_2_TREASURE_6_Z))
            {
              One.TF.Treasure_Velgus2_00006 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_7_X, Fix.VELGUS_2_TREASURE_7_Y, Fix.VELGUS_2_TREASURE_7_Z))
            {
              One.TF.Treasure_Velgus2_00007 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_8_X, Fix.VELGUS_2_TREASURE_8_Y, Fix.VELGUS_2_TREASURE_8_Z))
            {
              One.TF.Treasure_Velgus2_00008 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_9_X, Fix.VELGUS_2_TREASURE_9_Y, Fix.VELGUS_2_TREASURE_9_Z))
            {
              One.TF.Treasure_Velgus2_00009 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_10_X, Fix.VELGUS_2_TREASURE_10_Y, Fix.VELGUS_2_TREASURE_10_Z))
            {
              One.TF.Treasure_Velgus2_00010 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_11_X, Fix.VELGUS_2_TREASURE_11_Y, Fix.VELGUS_2_TREASURE_11_Z))
            {
              One.TF.Treasure_Velgus2_00011 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_12_X, Fix.VELGUS_2_TREASURE_12_Y, Fix.VELGUS_2_TREASURE_12_Z))
            {
              One.TF.Treasure_Velgus2_00012 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_13_X, Fix.VELGUS_2_TREASURE_13_Y, Fix.VELGUS_2_TREASURE_13_Z))
            {
              One.TF.Treasure_Velgus2_00013 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_14_X, Fix.VELGUS_2_TREASURE_14_Y, Fix.VELGUS_2_TREASURE_14_Z))
            {
              One.TF.Treasure_Velgus2_00014 = true;
            }
            if (this.Player.transform.position == new Vector3(Fix.VELGUS_2_TREASURE_15_X, Fix.VELGUS_2_TREASURE_15_Y, Fix.VELGUS_2_TREASURE_15_Z))
            {
              One.TF.Treasure_Velgus2_00015 = true;
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
          if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
          {
            // 岩壁１
            if (currentMessage == "1")
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_1_X, Fix.ESMILIA_Rock_1_Y, Fix.ESMILIA_Rock_1_Z));
              RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_2_X, Fix.ESMILIA_Rock_2_Y, Fix.ESMILIA_Rock_2_Z));
            }
            if (currentMessage == "2")
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_3_X, Fix.ESMILIA_Rock_3_Y, Fix.ESMILIA_Rock_3_Z));
              RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_4_X, Fix.ESMILIA_Rock_4_Y, Fix.ESMILIA_Rock_4_Z));
            }
            if (currentMessage == Fix.ESMILIA_Rock_5_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_5_X, Fix.ESMILIA_Rock_5_Y, Fix.ESMILIA_Rock_5_Z));
            }
            if (currentMessage == Fix.ESMILIA_Rock_6_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_6_X, Fix.ESMILIA_Rock_6_Y, Fix.ESMILIA_Rock_6_Z));
            }
            if (currentMessage == Fix.ESMILIA_Rock_7_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_7_X, Fix.ESMILIA_Rock_7_Y, Fix.ESMILIA_Rock_7_Z));
            }
            if (currentMessage == Fix.ESMILIA_Rock_4_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_4_X, Fix.ESMILIA_Rock_4_Y, Fix.ESMILIA_Rock_4_Z));
            }
            if (currentMessage == Fix.ESMILIA_Rock_8_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_8_X, Fix.ESMILIA_Rock_8_Y, Fix.ESMILIA_Rock_8_Z));
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

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
          {
            if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_1_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_1_X, Fix.MYSTICFOREST_BRUSHWOOD_1_Y, Fix.MYSTICFOREST_BRUSHWOOD_1_Z));
            }
            if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_2_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_2_X, Fix.MYSTICFOREST_BRUSHWOOD_2_Y, Fix.MYSTICFOREST_BRUSHWOOD_2_Z));
            }
            if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_3_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_3_X, Fix.MYSTICFOREST_BRUSHWOOD_3_Y, Fix.MYSTICFOREST_BRUSHWOOD_3_Z));
            }
            if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_4_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_4_X, Fix.MYSTICFOREST_BRUSHWOOD_4_Y, Fix.MYSTICFOREST_BRUSHWOOD_4_Z));
            }
            if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_5_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_5_X, Fix.MYSTICFOREST_BRUSHWOOD_5_Y, Fix.MYSTICFOREST_BRUSHWOOD_5_Z));
            }
            if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_6_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_6_X, Fix.MYSTICFOREST_BRUSHWOOD_6_Y, Fix.MYSTICFOREST_BRUSHWOOD_6_Z));
            }
            //if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_7_O)
            //{
            //  RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_7_X, Fix.MYSTICFOREST_BRUSHWOOD_7_Y, Fix.MYSTICFOREST_BRUSHWOOD_7_Z));
            //}
            //if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_8_O)
            //{
            //  RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_8_X, Fix.MYSTICFOREST_BRUSHWOOD_8_Y, Fix.MYSTICFOREST_BRUSHWOOD_8_Z));
            //}
            //if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_9_O)
            //{
            //  RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_9_X, Fix.MYSTICFOREST_BRUSHWOOD_9_Y, Fix.MYSTICFOREST_BRUSHWOOD_9_Z));
            //}
            //if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_10_O)
            //{
            //  RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_10_X, Fix.MYSTICFOREST_BRUSHWOOD_10_Y, Fix.MYSTICFOREST_BRUSHWOOD_10_Z));
            //}
            if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_11_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_11_X, Fix.MYSTICFOREST_BRUSHWOOD_11_Y, Fix.MYSTICFOREST_BRUSHWOOD_11_Z));
            }
            if (currentMessage == Fix.MYSTICFOREST_BRUSHWOOD_12_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_12_X, Fix.MYSTICFOREST_BRUSHWOOD_12_Y, Fix.MYSTICFOREST_BRUSHWOOD_12_Z));
            }

            if (currentMessage == Fix.MYSTICFOREST_ObsidianPortal_1_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_ObsidianPortal_1_X, Fix.MYSTICFOREST_ObsidianPortal_1_Y, Fix.MYSTICFOREST_ObsidianPortal_1_Z));
            }
          }

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
          {
            if (currentMessage == Fix.OHRANTOWER_KEYDOOR_1_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_KEYDOOR_1_X, Fix.OHRANTOWER_KEYDOOR_1_Y, Fix.OHRANTOWER_KEYDOOR_1_Z));
            }
            if (currentMessage == Fix.OHRANTOWER_KEYDOOR_2_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_KEYDOOR_2_X, Fix.OHRANTOWER_KEYDOOR_2_Y, Fix.OHRANTOWER_KEYDOOR_2_Z));
            }
            if (currentMessage == Fix.OHRANTOWER_KEYDOOR_3_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_KEYDOOR_3_X, Fix.OHRANTOWER_KEYDOOR_3_Y, Fix.OHRANTOWER_KEYDOOR_3_Z));
            }
            if (currentMessage == Fix.OHRANTOWER_KEYDOOR_4_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_KEYDOOR_4_X, Fix.OHRANTOWER_KEYDOOR_4_Y, Fix.OHRANTOWER_KEYDOOR_4_Z));
            }
            if (currentMessage == Fix.OHRANTOWER_ObsidianStone_2_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_ObsidianStone_2_X, Fix.OHRANTOWER_ObsidianStone_2_Y, Fix.OHRANTOWER_ObsidianStone_2_Z));
            }
          }

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
          {
            if (currentMessage == Fix.VELGUS_DOOR_6_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_6_X, Fix.VELGUS_DOOR_6_Y, Fix.VELGUS_DOOR_6_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_7_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_7_X, Fix.VELGUS_DOOR_7_Y, Fix.VELGUS_DOOR_7_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_8_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_8_X, Fix.VELGUS_DOOR_8_Y, Fix.VELGUS_DOOR_8_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_15_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_15_X, Fix.VELGUS_DOOR_15_Y, Fix.VELGUS_DOOR_15_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_16_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_16_X, Fix.VELGUS_SECRETWALL_16_Y, Fix.VELGUS_SECRETWALL_16_Z));
            }

            if (currentMessage == Fix.VELGUS_FAKESEA_18_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_18_X, Fix.VELGUS_FAKESEA_18_Y, Fix.VELGUS_FAKESEA_18_Z));
            }
            if (currentMessage == Fix.VELGUS_FAKESEA_19_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_19_X, Fix.VELGUS_FAKESEA_19_Y, Fix.VELGUS_FAKESEA_19_Z));
            }
            if (currentMessage == Fix.VELGUS_FAKESEA_20_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_20_X, Fix.VELGUS_FAKESEA_20_Y, Fix.VELGUS_FAKESEA_20_Z));
            }
            if (currentMessage == Fix.VELGUS_FAKESEA_21_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_21_X, Fix.VELGUS_FAKESEA_21_Y, Fix.VELGUS_FAKESEA_21_Z));
            }
            if (currentMessage == Fix.VELGUS_FAKESEA_22_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_22_X, Fix.VELGUS_FAKESEA_22_Y, Fix.VELGUS_FAKESEA_22_Z));
            }
            if (currentMessage == Fix.VELGUS_FAKESEA_23_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_23_X, Fix.VELGUS_FAKESEA_23_Y, Fix.VELGUS_FAKESEA_23_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_25_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_25_X, Fix.VELGUS_SECRETWALL_25_Y, Fix.VELGUS_SECRETWALL_25_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_26_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_26_X, Fix.VELGUS_DOOR_26_Y, Fix.VELGUS_DOOR_26_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_27_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_27_X, Fix.VELGUS_DOOR_27_Y, Fix.VELGUS_DOOR_27_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_28_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_28_X, Fix.VELGUS_DOOR_28_Y, Fix.VELGUS_DOOR_28_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_49_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_49_X, Fix.VELGUS_SECRETWALL_49_Y, Fix.VELGUS_SECRETWALL_49_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_50_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_50_X, Fix.VELGUS_SECRETWALL_50_Y, Fix.VELGUS_SECRETWALL_50_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_51_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_51_X, Fix.VELGUS_SECRETWALL_51_Y, Fix.VELGUS_SECRETWALL_51_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_52_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_52_X, Fix.VELGUS_SECRETWALL_52_Y, Fix.VELGUS_SECRETWALL_52_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_53_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_53_X, Fix.VELGUS_SECRETWALL_53_Y, Fix.VELGUS_SECRETWALL_53_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_54_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_54_X, Fix.VELGUS_SECRETWALL_54_Y, Fix.VELGUS_SECRETWALL_54_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_55_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_55_X, Fix.VELGUS_SECRETWALL_55_Y, Fix.VELGUS_SECRETWALL_55_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_56_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_56_X, Fix.VELGUS_SECRETWALL_56_Y, Fix.VELGUS_SECRETWALL_56_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_58_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_58_X, Fix.VELGUS_SECRETWALL_58_Y, Fix.VELGUS_SECRETWALL_58_Z));
            }
            if (currentMessage == Fix.VELGUS_MessageBoard_3_O) // ただし宣言値は単なる"3"であり他と重複する可能性がある。
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_MessageBoard_3_X, Fix.VELGUS_MessageBoard_3_Y, Fix.VELGUS_MessageBoard_3_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_60_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_60_X, Fix.VELGUS_SECRETWALL_60_Y, Fix.VELGUS_SECRETWALL_60_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_63_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_63_X, Fix.VELGUS_SECRETWALL_63_Y, Fix.VELGUS_SECRETWALL_63_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_86_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_86_X, Fix.VELGUS_DOOR_86_Y, Fix.VELGUS_DOOR_86_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_111_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_111_X, Fix.VELGUS_DOOR_111_Y, Fix.VELGUS_DOOR_111_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_120_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_120_X, Fix.VELGUS_SECRETWALL_120_Y, Fix.VELGUS_SECRETWALL_120_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_178_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_178_X, Fix.VELGUS_DOOR_178_Y, Fix.VELGUS_DOOR_178_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_191_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_191_X, Fix.VELGUS_DOOR_191_Y, Fix.VELGUS_DOOR_191_Z));
            }
            if (currentMessage == Fix.VELGUS_SECRETWALL_200_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_200_X, Fix.VELGUS_SECRETWALL_200_Y, Fix.VELGUS_SECRETWALL_200_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_201_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_201_X, Fix.VELGUS_DOOR_201_Y, Fix.VELGUS_DOOR_201_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_202_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_202_X, Fix.VELGUS_DOOR_202_Y, Fix.VELGUS_DOOR_202_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_203_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_203_X, Fix.VELGUS_DOOR_203_Y, Fix.VELGUS_DOOR_203_Z));
            }
          }

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
          {
            if (currentMessage == Fix.VELGUS_DOOR_216_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_216_X, Fix.VELGUS_DOOR_216_Y, Fix.VELGUS_DOOR_216_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_217_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_217_X, Fix.VELGUS_DOOR_217_Y, Fix.VELGUS_DOOR_217_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_218_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_218_X, Fix.VELGUS_DOOR_218_Y, Fix.VELGUS_DOOR_218_Z));
            }

            if (currentMessage == Fix.VELGUS_DOOR_219_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_219_X, Fix.VELGUS_DOOR_219_Y, Fix.VELGUS_DOOR_219_Z));
            }

            if (currentMessage == Fix.VELGUS_DOOR_239_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_239_X, Fix.VELGUS_DOOR_239_Y, Fix.VELGUS_DOOR_239_Z));
            }

            if (currentMessage == Fix.VELGUS_DOOR_242_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_242_X, Fix.VELGUS_DOOR_242_Y, Fix.VELGUS_DOOR_242_Z));
            }

            if (currentMessage == Fix.VELGUS_SECRETWALL_245_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_245_X, Fix.VELGUS_SECRETWALL_245_Y, Fix.VELGUS_SECRETWALL_245_Z));
            }

            if (currentMessage == Fix.VELGUS_DOOR_248_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_248_X, Fix.VELGUS_DOOR_248_Y, Fix.VELGUS_DOOR_248_Z));
            }
            if (currentMessage == Fix.VELGUS_DOOR_249_O)
            {
              RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_249_X, Fix.VELGUS_DOOR_249_Y, Fix.VELGUS_DOOR_249_Z));
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
        else if (currentEvent == MessagePack.ActionEvent.RevealFieldObject)
        {
          if (currentMessage == Fix.VELGUS_SECRETWALL_130_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_130_X, Fix.VELGUS_SECRETWALL_130_Y, Fix.VELGUS_SECRETWALL_130_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_131_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_131_X, Fix.VELGUS_SECRETWALL_131_Y, Fix.VELGUS_SECRETWALL_131_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_132_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_132_X, Fix.VELGUS_SECRETWALL_132_Y, Fix.VELGUS_SECRETWALL_132_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_133_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_133_X, Fix.VELGUS_SECRETWALL_133_Y, Fix.VELGUS_SECRETWALL_133_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_134_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_134_X, Fix.VELGUS_SECRETWALL_134_Y, Fix.VELGUS_SECRETWALL_134_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_135_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_135_X, Fix.VELGUS_SECRETWALL_135_Y, Fix.VELGUS_SECRETWALL_135_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_136_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_136_X, Fix.VELGUS_SECRETWALL_136_Y, Fix.VELGUS_SECRETWALL_136_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_137_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_137_X, Fix.VELGUS_SECRETWALL_137_Y, Fix.VELGUS_SECRETWALL_137_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_138_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_138_X, Fix.VELGUS_SECRETWALL_138_Y, Fix.VELGUS_SECRETWALL_138_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_139_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_139_X, Fix.VELGUS_SECRETWALL_139_Y, Fix.VELGUS_SECRETWALL_139_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_140_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_140_X, Fix.VELGUS_SECRETWALL_140_Y, Fix.VELGUS_SECRETWALL_140_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_141_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_141_X, Fix.VELGUS_SECRETWALL_141_Y, Fix.VELGUS_SECRETWALL_141_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_142_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_142_X, Fix.VELGUS_SECRETWALL_142_Y, Fix.VELGUS_SECRETWALL_142_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_143_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_143_X, Fix.VELGUS_SECRETWALL_143_Y, Fix.VELGUS_SECRETWALL_143_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_144_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_144_X, Fix.VELGUS_SECRETWALL_144_Y, Fix.VELGUS_SECRETWALL_144_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_145_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_145_X, Fix.VELGUS_SECRETWALL_145_Y, Fix.VELGUS_SECRETWALL_145_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_146_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_146_X, Fix.VELGUS_SECRETWALL_146_Y, Fix.VELGUS_SECRETWALL_146_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_147_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_147_X, Fix.VELGUS_SECRETWALL_147_Y, Fix.VELGUS_SECRETWALL_147_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_148_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_148_X, Fix.VELGUS_SECRETWALL_148_Y, Fix.VELGUS_SECRETWALL_148_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_149_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_149_X, Fix.VELGUS_SECRETWALL_149_Y, Fix.VELGUS_SECRETWALL_149_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_150_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_150_X, Fix.VELGUS_SECRETWALL_150_Y, Fix.VELGUS_SECRETWALL_150_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_151_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_151_X, Fix.VELGUS_SECRETWALL_151_Y, Fix.VELGUS_SECRETWALL_151_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_152_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_152_X, Fix.VELGUS_SECRETWALL_152_Y, Fix.VELGUS_SECRETWALL_152_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_153_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_153_X, Fix.VELGUS_SECRETWALL_153_Y, Fix.VELGUS_SECRETWALL_153_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_154_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_154_X, Fix.VELGUS_SECRETWALL_154_Y, Fix.VELGUS_SECRETWALL_154_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_155_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_155_X, Fix.VELGUS_SECRETWALL_155_Y, Fix.VELGUS_SECRETWALL_155_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_156_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_156_X, Fix.VELGUS_SECRETWALL_156_Y, Fix.VELGUS_SECRETWALL_156_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_157_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_157_X, Fix.VELGUS_SECRETWALL_157_Y, Fix.VELGUS_SECRETWALL_157_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_158_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_158_X, Fix.VELGUS_SECRETWALL_158_Y, Fix.VELGUS_SECRETWALL_158_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_159_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_159_X, Fix.VELGUS_SECRETWALL_159_Y, Fix.VELGUS_SECRETWALL_159_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_160_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_160_X, Fix.VELGUS_SECRETWALL_160_Y, Fix.VELGUS_SECRETWALL_160_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_161_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_161_X, Fix.VELGUS_SECRETWALL_161_Y, Fix.VELGUS_SECRETWALL_161_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_162_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_162_X, Fix.VELGUS_SECRETWALL_162_Y, Fix.VELGUS_SECRETWALL_162_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_163_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_163_X, Fix.VELGUS_SECRETWALL_163_Y, Fix.VELGUS_SECRETWALL_163_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_164_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_164_X, Fix.VELGUS_SECRETWALL_164_Y, Fix.VELGUS_SECRETWALL_164_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_165_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_165_X, Fix.VELGUS_SECRETWALL_165_Y, Fix.VELGUS_SECRETWALL_165_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_166_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_166_X, Fix.VELGUS_SECRETWALL_166_Y, Fix.VELGUS_SECRETWALL_166_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_167_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_167_X, Fix.VELGUS_SECRETWALL_167_Y, Fix.VELGUS_SECRETWALL_167_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_168_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_168_X, Fix.VELGUS_SECRETWALL_168_Y, Fix.VELGUS_SECRETWALL_168_Z));
          }
          if (currentMessage == Fix.VELGUS_SECRETWALL_169_O)
          {
            RevealFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_169_X, Fix.VELGUS_SECRETWALL_169_Y, Fix.VELGUS_SECRETWALL_169_Z));
          }
          continue;
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
          if (currentMessage == Fix.CHOICE_VELGUS_JUDGE_1)
          {
            this.currentChoice = currentMessage;
            txtChoiceTitle.text = currentMessage;
            txtChoiceMessage.text = "石像に対してどのような行動をするか選択してください。";
            txtChoiceMessage.text = "";
            txtChoiceA.text = "赤ポーションを皿の上に置く";
            txtChoiceB.text = "青ポーションを皿の上の置く";
            txtChoiceC.text = "何もしない";
            GroupChoice.SetActive(true);
            return;
          }
          if (currentMessage == Fix.CHOICE_VELGUS_JUDGE_2)
          {
            this.currentChoice = currentMessage;
            txtChoiceTitle.text = currentMessage;
            txtChoiceMessage.text = "石像に対してどのような行動をするか選択してください。";
            txtChoiceMessage.text = "";
            txtChoiceA.text = "水晶を皿の上に置く";
            txtChoiceB.text = "本を皿の上の置く";
            txtChoiceC.text = "何もしない";
            GroupChoice.SetActive(true);
            return;
          }
          if (currentMessage == Fix.CHOICE_VELGUS_JUDGE_3)
          {
            this.currentChoice = currentMessage;
            txtChoiceTitle.text = currentMessage;
            txtChoiceMessage.text = "石像に対してどのような行動をするか選択してください。";
            txtChoiceMessage.text = "";
            txtChoiceA.text = "剣を皿の上に置く";
            txtChoiceB.text = "盾を皿の上の置く";
            txtChoiceC.text = "何もしない";
            GroupChoice.SetActive(true);
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
        else if (currentEvent == MessagePack.ActionEvent.EncountDuel)
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
          //if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
          {
            string[] locations = currentMessage.Split(':');
            int jump_X = Convert.ToInt32(locations[0]);
            int jump_Y = Convert.ToInt32(locations[1]);
            int jump_Z = Convert.ToInt32(locations[2]);
            JumpToLocation(new Vector3(jump_X, jump_Y, jump_Z));
            UpdateUnknownTile(Player.transform.position);
          }
        }
        else if (currentEvent == MessagePack.ActionEvent.GotoHomeTownForce)
        {
          this.HomeTownCall = currentMessage;
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

  private void UnloadedSceneAdd(Scene arg0)
  {
    SceneManager.sceneUnloaded -= UnloadedSceneAdd;

    if (One.TF.Event_Message1000077 && One.TF.Event_Message1000078 == false)
    {
      MessagePack.Message1000067(ref QuestMessageList, ref QuestEventList); TapOK();
    }
  }

  private void PrepareCallTruthBattleEnemy()
  {
    this.AlreadyDetectEncount = true;
    One.BattleEnd = Fix.GameEndType.None;
    One.FromHometown = false;
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

      if (One.EnemyList[0].Area == Fix.MonsterArea.Boss1 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss2 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss21 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss22 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss23 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss24 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss25 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss3 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss4 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss42 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss5 ||
          One.EnemyList[0].Area == Fix.MonsterArea.LastBoss ||
          One.EnemyList[0].Area == Fix.MonsterArea.TruthBoss1 ||
          One.EnemyList[0].Area == Fix.MonsterArea.TruthBoss2 ||
          One.EnemyList[0].Area == Fix.MonsterArea.TruthBoss3 ||
          One.EnemyList[0].Area == Fix.MonsterArea.TruthBoss4 ||
          One.EnemyList[0].Area == Fix.MonsterArea.TruthBoss5
          )
      {
        One.BattleMode = Fix.BattleMode.Boss;
      }
      else if (One.EnemyList[0].FullName == Fix.NAME_EONE_FULNEA ||
               One.EnemyList[0].FullName == Fix.NAME_SELMOI_RO)
      {
        One.BattleMode = Fix.BattleMode.Duel;
      }
      else
      {
        One.BattleMode = Fix.BattleMode.Normal;
      }
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
    #region "エスミリア草原区域"
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
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
      //if (LocationDetect(tile, 15, 0, 1) && One.TF.AvailableImmediateAction == false)
      //{
      //  MessagePack.Message000190(ref QuestMessageList, ref QuestEventList); TapOK();
      //  return true;
      //}
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

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_2_X, Fix.MYSTICFOREST_Event_2_Y, Fix.MYSTICFOREST_Event_2_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_2_2_X, Fix.MYSTICFOREST_Event_2_2_Y, Fix.MYSTICFOREST_Event_2_2_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_2_3_X, Fix.MYSTICFOREST_Event_2_3_Y, Fix.MYSTICFOREST_Event_2_3_Z))
      {
        MessagePack.Message900030(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_3_X, Fix.MYSTICFOREST_Event_3_Y, Fix.MYSTICFOREST_Event_3_Z))
      {
        MessagePack.Message900040(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_4_X, Fix.MYSTICFOREST_Event_4_Y, Fix.MYSTICFOREST_Event_4_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_4_2_X, Fix.MYSTICFOREST_Event_4_2_Y, Fix.MYSTICFOREST_Event_4_2_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_4_3_X, Fix.MYSTICFOREST_Event_4_3_Y, Fix.MYSTICFOREST_Event_4_3_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_4_4_X, Fix.MYSTICFOREST_Event_4_4_Y, Fix.MYSTICFOREST_Event_4_4_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_4_5_X, Fix.MYSTICFOREST_Event_4_5_Y, Fix.MYSTICFOREST_Event_4_5_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_4_6_X, Fix.MYSTICFOREST_Event_4_6_Y, Fix.MYSTICFOREST_Event_4_6_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_4_7_X, Fix.MYSTICFOREST_Event_4_7_Y, Fix.MYSTICFOREST_Event_4_7_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_4_8_X, Fix.MYSTICFOREST_Event_4_8_Y, Fix.MYSTICFOREST_Event_4_8_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_4_9_X, Fix.MYSTICFOREST_Event_4_9_Y, Fix.MYSTICFOREST_Event_4_9_Z))
      {
        MessagePack.Message900070(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_5_X, Fix.MYSTICFOREST_Event_5_Y, Fix.MYSTICFOREST_Event_5_Z))
      {
        MessagePack.Message900080(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_6_X, Fix.MYSTICFOREST_Event_6_Y, Fix.MYSTICFOREST_Event_6_Z))
      {
        MessagePack.Message900090(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_7_X, Fix.MYSTICFOREST_Event_7_Y, Fix.MYSTICFOREST_Event_7_Z))
      {
        MessagePack.Message900100(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_8_X, Fix.MYSTICFOREST_Event_8_Y, Fix.MYSTICFOREST_Event_8_Z))
      {
        MessagePack.Message900110(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_9_X, Fix.MYSTICFOREST_Event_9_Y, Fix.MYSTICFOREST_Event_9_Z))
      {
        MessagePack.Message900120(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_10_X, Fix.MYSTICFOREST_Event_10_Y, Fix.MYSTICFOREST_Event_10_Z))
      {
        MessagePack.Message900130(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_11_X, Fix.MYSTICFOREST_Event_11_Y, Fix.MYSTICFOREST_Event_11_Z))
      {
        MessagePack.Message900160(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_12_X, Fix.MYSTICFOREST_Event_12_Y, Fix.MYSTICFOREST_Event_12_Z))
      {
        MessagePack.Message900170(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_13_X, Fix.MYSTICFOREST_Event_13_Y, Fix.MYSTICFOREST_Event_13_Z))
      {
        MessagePack.Message900180(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_14_X, Fix.MYSTICFOREST_Event_14_Y, Fix.MYSTICFOREST_Event_14_Z))
      {
        MessagePack.Message900190(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_15_X, Fix.MYSTICFOREST_Event_15_Y, Fix.MYSTICFOREST_Event_15_Z))
      {
        MessagePack.Message900200(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_16_X, Fix.MYSTICFOREST_Event_16_Y, Fix.MYSTICFOREST_Event_16_Z))
      {
        MessagePack.Message900220(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_17_X, Fix.MYSTICFOREST_Event_17_Y, Fix.MYSTICFOREST_Event_17_Z))
      {
        MessagePack.Message900230(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_18_X, Fix.MYSTICFOREST_Event_18_Y, Fix.MYSTICFOREST_Event_18_Z))
      {
        MessagePack.Message900240(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_19_X, Fix.MYSTICFOREST_Event_19_Y, Fix.MYSTICFOREST_Event_19_Z))
      {
        MessagePack.Message900280(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_20_X, Fix.MYSTICFOREST_Event_20_Y, Fix.MYSTICFOREST_Event_20_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_20_2_X, Fix.MYSTICFOREST_Event_20_2_Y, Fix.MYSTICFOREST_Event_20_2_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_20_3_X, Fix.MYSTICFOREST_Event_20_3_Y, Fix.MYSTICFOREST_Event_20_3_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_20_4_X, Fix.MYSTICFOREST_Event_20_4_Y, Fix.MYSTICFOREST_Event_20_4_Z) ||
          LocationDetect(tile, Fix.MYSTICFOREST_Event_20_5_X, Fix.MYSTICFOREST_Event_20_5_Y, Fix.MYSTICFOREST_Event_20_5_Z))
      {
        MessagePack.Message900290(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_21_X, Fix.MYSTICFOREST_Event_21_Y, Fix.MYSTICFOREST_Event_21_Z))
      {
        MessagePack.Message900300(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_22_X, Fix.MYSTICFOREST_Event_22_Y, Fix.MYSTICFOREST_Event_22_Z))
      {
        MessagePack.Message900310(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_23_X, Fix.MYSTICFOREST_Event_23_Y, Fix.MYSTICFOREST_Event_23_Z))
      {
        MessagePack.Message900320(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_24_X, Fix.MYSTICFOREST_Event_24_Y, Fix.MYSTICFOREST_Event_24_Z))
      {
        MessagePack.Message900330(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_25_X, Fix.MYSTICFOREST_Event_25_Y, Fix.MYSTICFOREST_Event_25_Z))
      {
        MessagePack.Message900340(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_26_X, Fix.MYSTICFOREST_Event_26_Y, Fix.MYSTICFOREST_Event_26_Z))
      {
        MessagePack.Message900350(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_27_X, Fix.MYSTICFOREST_Event_27_Y, Fix.MYSTICFOREST_Event_27_Z))
      {
        MessagePack.Message900360(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_28_X, Fix.MYSTICFOREST_Event_28_Y, Fix.MYSTICFOREST_Event_28_Z))
      {
        MessagePack.Message900370(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_29_X, Fix.MYSTICFOREST_Event_29_Y, Fix.MYSTICFOREST_Event_29_Z))
      {
        MessagePack.Message900390(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_30_X, Fix.MYSTICFOREST_Event_30_Y, Fix.MYSTICFOREST_Event_30_Z))
      {
        MessagePack.Message900400(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_31_X, Fix.MYSTICFOREST_Event_31_Y, Fix.MYSTICFOREST_Event_31_Z))
      {
        MessagePack.Message900410(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_32_X, Fix.MYSTICFOREST_Event_32_Y, Fix.MYSTICFOREST_Event_32_Z))
      {
        MessagePack.Message900420(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_33_X, Fix.MYSTICFOREST_Event_33_Y, Fix.MYSTICFOREST_Event_33_Z))
      {
        MessagePack.Message900430(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_34_X, Fix.MYSTICFOREST_Event_34_Y, Fix.MYSTICFOREST_Event_34_Z))
      {
        MessagePack.Message900460(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_35_X, Fix.MYSTICFOREST_Event_35_Y, Fix.MYSTICFOREST_Event_35_Z))
      {
        MessagePack.Message900470(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_36_X, Fix.MYSTICFOREST_Event_36_Y, Fix.MYSTICFOREST_Event_36_Z))
      {
        MessagePack.Message900480(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_37_X, Fix.MYSTICFOREST_Event_37_Y, Fix.MYSTICFOREST_Event_37_Z))
      {
        MessagePack.Message900490(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_STEPBACK_1_X, Fix.MYSTICFOREST_STEPBACK_1_Y, Fix.MYSTICFOREST_STEPBACK_1_Z))
      {
        MessagePack.Message900500(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_38_X, Fix.MYSTICFOREST_Event_38_Y, Fix.MYSTICFOREST_Event_38_Z))
      {
        MessagePack.Message900510(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_39_X, Fix.MYSTICFOREST_Event_39_Y, Fix.MYSTICFOREST_Event_39_Z))
      {
        MessagePack.Message900520(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_40_X, Fix.MYSTICFOREST_Event_40_Y, Fix.MYSTICFOREST_Event_40_Z))
      {
        MessagePack.Message900530(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_41_X, Fix.MYSTICFOREST_Event_41_Y, Fix.MYSTICFOREST_Event_41_Z))
      {
        MessagePack.Message900540(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_42_X, Fix.MYSTICFOREST_Event_42_Y, Fix.MYSTICFOREST_Event_42_Z))
      {
        MessagePack.Message900550(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_43_X, Fix.MYSTICFOREST_Event_43_Y, Fix.MYSTICFOREST_Event_43_Z))
      {
        MessagePack.Message900560(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_44_X, Fix.MYSTICFOREST_Event_44_Y, Fix.MYSTICFOREST_Event_44_Z))
      {
        MessagePack.Message900570(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_45_X, Fix.MYSTICFOREST_Event_45_Y, Fix.MYSTICFOREST_Event_45_Z))
      {
        MessagePack.Message900580(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_46_X, Fix.MYSTICFOREST_Event_46_Y, Fix.MYSTICFOREST_Event_46_Z))
      {
        MessagePack.Message900590(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_47_X, Fix.MYSTICFOREST_Event_47_Y, Fix.MYSTICFOREST_Event_47_Z))
      {
        MessagePack.Message900610(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_48_X, Fix.MYSTICFOREST_Event_48_Y, Fix.MYSTICFOREST_Event_48_Z))
      {
        MessagePack.Message900660(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_49_X, Fix.MYSTICFOREST_Event_49_Y, Fix.MYSTICFOREST_Event_49_Z))
      {
        MessagePack.Message900670(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_50_X, Fix.MYSTICFOREST_Event_50_Y, Fix.MYSTICFOREST_Event_50_Z))
      {
        MessagePack.Message900680(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_51_X, Fix.MYSTICFOREST_Event_51_Y, Fix.MYSTICFOREST_Event_51_Z))
      {
        MessagePack.Message900690(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_52_X, Fix.MYSTICFOREST_Event_52_Y, Fix.MYSTICFOREST_Event_52_Z))
      {
        MessagePack.Message900710(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_53_X, Fix.MYSTICFOREST_Event_53_Y, Fix.MYSTICFOREST_Event_53_Z) && One.TF.DefeatFlansisQueenOfVerdant == false)
      {
        MessagePack.Message900730(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Boss_1_X, Fix.MYSTICFOREST_Boss_1_Y, Fix.MYSTICFOREST_Boss_1_Z) && One.TF.DefeatFlansisQueenOfVerdant == false)
      {
        MessagePack.Message900740(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_54_X, Fix.MYSTICFOREST_Event_54_Y, Fix.MYSTICFOREST_Event_54_Z))
      {
        MessagePack.Message900436(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.MYSTICFOREST_Event_55_X, Fix.MYSTICFOREST_Event_55_Y, Fix.MYSTICFOREST_Event_55_Z))
      {
        MessagePack.Message900760(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
    }
    #endregion
    #region "オーランの塔"
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
    {
      if (LocationDetect(tile, Fix.OHRANTOWER_EVENT_1_X, Fix.OHRANTOWER_EVENT_1_Y, Fix.OHRANTOWER_EVENT_1_Z))
      {
        MessagePack.Message800010(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.OHRANTOWER_EVENT_2_X, Fix.OHRANTOWER_EVENT_2_Y, Fix.OHRANTOWER_EVENT_2_Z))
      {
        MessagePack.Message800050(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationDetect(tile, Fix.OHRANTOWER_EVENT_3_X, Fix.OHRANTOWER_EVENT_3_Y, Fix.OHRANTOWER_EVENT_3_Z))
      {
        MessagePack.Message800051(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationDetect(tile, Fix.OHRANTOWER_EVENT_4_X, Fix.OHRANTOWER_EVENT_4_Y, Fix.OHRANTOWER_EVENT_4_Z))
      {
        MessagePack.Message800060(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationDetect(tile, Fix.OHRANTOWER_EVENT_5_X, Fix.OHRANTOWER_EVENT_5_Y, Fix.OHRANTOWER_EVENT_5_Z))
      {
        MessagePack.Message800070(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      if (LocationDetect(tile, Fix.OHRANTOWER_EVENT_6_X, Fix.OHRANTOWER_EVENT_6_Y, Fix.OHRANTOWER_EVENT_6_Z))
      {
        MessagePack.Message800080(ref QuestMessageList, ref QuestEventList); TapOK();
      }
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
      if (LocationDetect(tile, Fix.EVENT_OHRANTOWER_11_X, Fix.EVENT_OHRANTOWER_11_Y, Fix.EVENT_OHRANTOWER_11_Z) && One.TF.DefeatYodirian == false)
      {
        MessagePack.Message800105(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.EVENT_OHRANTOWER_12_X, Fix.EVENT_OHRANTOWER_12_Y, Fix.EVENT_OHRANTOWER_12_Z))
      {
        MessagePack.Message800120(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.EVENT_OHRANTOWER_13_X, Fix.EVENT_OHRANTOWER_13_Y, Fix.EVENT_OHRANTOWER_13_Z))
      {
        MessagePack.Message800130(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.OHRANTOWER_EVENT_14_X, Fix.OHRANTOWER_EVENT_14_Y, Fix.OHRANTOWER_EVENT_14_Z))
      {
        MessagePack.Message800160(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.OHRANTOWER_EVENT_15_X, Fix.OHRANTOWER_EVENT_15_Y, Fix.OHRANTOWER_EVENT_15_Z))
      {
        MessagePack.Message800170(ref QuestMessageList, ref QuestEventList); TapOK();
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
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
    {
      // エントランス１
      if (One.TF.Event_Message1000010_Complete == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_1_X, Fix.VELGUS_TRIGGERTILE_1_Y, Fix.VELGUS_TRIGGERTILE_1_Z))
        {
          MessagePack.Message1000011(ref QuestMessageList, ref QuestEventList);
          if (One.TF.Event_Message1000011 == false && One.TF.Event_Message1000012 == false && One.TF.Event_Message1000013 == false && One.TF.Event_Message1000014 == false)
          {
            One.TF.Event_Message1000011 = true;
          }
          else
          {
            One.TF.Event_Message1000010_Fail = true;
          }
          TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_2_X, Fix.VELGUS_TRIGGERTILE_2_Y, Fix.VELGUS_TRIGGERTILE_2_Z))
        {
          MessagePack.Message1000012(ref QuestMessageList, ref QuestEventList);
          if (One.TF.Event_Message1000011 == true && One.TF.Event_Message1000012 == false && One.TF.Event_Message1000013 == false && One.TF.Event_Message1000014 == false)
          {
            One.TF.Event_Message1000012 = true;
          }
          else
          {
            One.TF.Event_Message1000010_Fail = true;
          }
          TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_3_X, Fix.VELGUS_TRIGGERTILE_3_Y, Fix.VELGUS_TRIGGERTILE_3_Z))
        {
          MessagePack.Message1000013(ref QuestMessageList, ref QuestEventList);
          if (One.TF.Event_Message1000011 == true && One.TF.Event_Message1000012 == true && One.TF.Event_Message1000013 == false && One.TF.Event_Message1000014 == false)
          {
            One.TF.Event_Message1000013 = true;
          }
          else
          {
            One.TF.Event_Message1000010_Fail = true;
          }
          TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_4_X, Fix.VELGUS_TRIGGERTILE_4_Y, Fix.VELGUS_TRIGGERTILE_4_Z))
        {
          MessagePack.Message1000014(ref QuestMessageList, ref QuestEventList);
          if (One.TF.Event_Message1000011 == true && One.TF.Event_Message1000012 == true && One.TF.Event_Message1000013 == true && One.TF.Event_Message1000014 == false && One.TF.Event_Message1000010_Fail == false)
          {
            One.TF.Event_Message1000014 = true;
            MessagePack.Message1000016(ref QuestMessageList, ref QuestEventList);
          }
          else
          {
            One.TF.Event_Message1000010_Fail = true;
            MessagePack.Message1000017(ref QuestMessageList, ref QuestEventList);
          }
          TapOK();
          return true;
        }
      }

      // 中央の間
      if (One.TF.Event_Message1000020_Complete == false || One.TF.Event_Message1000020_2_Complete == false)
      {
        if (One.TF.Event_Message1000020_Complete == false && One.TF.Event_Message1000020 == false)
        {
          if (LocationDetect(tile, Fix.VELGUS_TILEEVENT_9_X, Fix.VELGUS_TILEEVENT_9_Y, Fix.VELGUS_TILEEVENT_9_Z))
          {
            MessagePack.Message1000025(ref QuestMessageList, ref QuestEventList, MessagePack.ActionEvent.ForceMoveBottom);
            TapOK();
            return true;
          }
          if (LocationDetect(tile, Fix.VELGUS_TILEEVENT_10_X, Fix.VELGUS_TILEEVENT_10_Y, Fix.VELGUS_TILEEVENT_10_Z))
          {
            MessagePack.Message1000025(ref QuestMessageList, ref QuestEventList, MessagePack.ActionEvent.ForceMoveTop);
            TapOK();
            return true;
          }
        }

        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_11_X, Fix.VELGUS_TRIGGERTILE_11_Y, Fix.VELGUS_TRIGGERTILE_11_Z))
        {
          MessagePack.Message1000021(ref QuestMessageList, ref QuestEventList);
          // 表
          if (One.TF.Event_Message1000021 == false && One.TF.Event_Message1000022 == false && One.TF.Event_Message1000023 == false && One.TF.Event_Message1000024 == false)
          {
            One.TF.Event_Message1000021 = true;
          }
          else
          {
            One.TF.Event_Message1000020_Fail = true;
          }
          // 裏
          if (One.TF.Event_Message1000021_2 == true && One.TF.Event_Message1000022_2 == true && One.TF.Event_Message1000023_2 == false && One.TF.Event_Message1000024_2 == false)
          {
            One.TF.Event_Message1000023_2 = true;
          }
          else
          {
            One.TF.Event_Message1000020_2_Fail = true;
          }

          TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_12_X, Fix.VELGUS_TRIGGERTILE_12_Y, Fix.VELGUS_TRIGGERTILE_12_Z))
        {
          MessagePack.Message1000022(ref QuestMessageList, ref QuestEventList);
          // 表
          if (One.TF.Event_Message1000021 == true && One.TF.Event_Message1000022 == false && One.TF.Event_Message1000023 == false && One.TF.Event_Message1000024 == false)
          {
            One.TF.Event_Message1000022 = true;
          }
          else
          {
            One.TF.Event_Message1000020_Fail = true;
          }
          // 裏
          if (One.TF.Event_Message1000021_2 == false && One.TF.Event_Message1000022_2 == false && One.TF.Event_Message1000023_2 == false && One.TF.Event_Message1000024_2 == false)
          {
            One.TF.Event_Message1000021_2 = true;
          }
          else
          {
            One.TF.Event_Message1000020_2_Fail = true;
          }

          TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_13_X, Fix.VELGUS_TRIGGERTILE_13_Y, Fix.VELGUS_TRIGGERTILE_13_Z))
        {
          MessagePack.Message1000023(ref QuestMessageList, ref QuestEventList);
          // 表
          if (One.TF.Event_Message1000021 == true && One.TF.Event_Message1000022 == true && One.TF.Event_Message1000023 == false && One.TF.Event_Message1000024 == false)
          {
            One.TF.Event_Message1000023 = true;
          }
          else
          {
            One.TF.Event_Message1000020_Fail = true;
          }
          // 裏
          Debug.Log("13 21_2:" + One.TF.Event_Message1000021_2.ToString() + " 22_2:" + One.TF.Event_Message1000022_2.ToString() + " 23_2:" + One.TF.Event_Message1000023_2.ToString() + " 24_2:" + One.TF.Event_Message1000024_2.ToString() + " 20_2_fail:" + One.TF.Event_Message1000020_2_Fail.ToString());
          if (One.TF.Event_Message1000021_2 == true && One.TF.Event_Message1000022_2 == true && One.TF.Event_Message1000023_2 == true && One.TF.Event_Message1000024_2 == false && One.TF.Event_Message1000020_2_Fail == false)
          {
            One.TF.Event_Message1000024_2 = true;
            MessagePack.Message1000029(ref QuestMessageList, ref QuestEventList);
          }
          else
          {
            One.TF.Event_Message1000020_2_Fail = true;
            MessagePack.Message1000030(ref QuestMessageList, ref QuestEventList);
          }

          TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_14_X, Fix.VELGUS_TRIGGERTILE_14_Y, Fix.VELGUS_TRIGGERTILE_14_Z))
        {
          MessagePack.Message1000024(ref QuestMessageList, ref QuestEventList);
          // 裏ルート失敗なら表ルートでメッセージ表示とする。
          if (One.TF.Event_Message1000020_2_Fail)
          {
            // 表
            if (One.TF.Event_Message1000021 == true && One.TF.Event_Message1000022 == true && One.TF.Event_Message1000023 == true && One.TF.Event_Message1000024 == false && One.TF.Event_Message1000020_Fail == false)
            {
              One.TF.Event_Message1000024 = true;
              MessagePack.Message1000026(ref QuestMessageList, ref QuestEventList);
            }
            else
            {
              One.TF.Event_Message1000020_Fail = true;
              MessagePack.Message1000027(ref QuestMessageList, ref QuestEventList);
            }
          }
          else
          {
            Debug.Log("14 21_2:" + One.TF.Event_Message1000021_2.ToString() + " 22_2:" + One.TF.Event_Message1000022_2.ToString() + " 23_2:" + One.TF.Event_Message1000023_2.ToString() + " 24_2:" + One.TF.Event_Message1000024_2.ToString() + " 20_2_fail:" + One.TF.Event_Message1000020_2_Fail.ToString());
            // 裏
            if (One.TF.Event_Message1000021_2 == true && One.TF.Event_Message1000022_2 == false && One.TF.Event_Message1000023_2 == false && One.TF.Event_Message1000024_2 == false)
            {
              One.TF.Event_Message1000022_2 = true;
            }
            else
            {
              One.TF.Event_Message1000020_2_Fail = true;
            }
          }
          TapOK();
          return true;
        }
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_17_X, Fix.VELGUS_TRIGGERTILE_17_Y, Fix.VELGUS_TRIGGERTILE_17_Z))
      {
        if (One.TF.Event_Message1000020_3_Complete == false)
        {
          MessagePack.Message1000031(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_24_X, Fix.VELGUS_TRIGGERTILE_24_Y, Fix.VELGUS_TRIGGERTILE_24_Z))
      {
        if (One.TF.Event_Message1000040_Complete == false)
        {
          MessagePack.Message1000041(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (One.TF.Event_Message1000040_Complete_1 == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_46_X, Fix.VELGUS_TRIGGERTILE_46_Y, Fix.VELGUS_TRIGGERTILE_46_Z))
        {
          MessagePack.Message1000042(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_47_X, Fix.VELGUS_TRIGGERTILE_47_Y, Fix.VELGUS_TRIGGERTILE_47_Z))
        {
          MessagePack.Message1000043(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_48_X, Fix.VELGUS_TRIGGERTILE_48_Y, Fix.VELGUS_TRIGGERTILE_48_Z))
        {
          MessagePack.Message1000044(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_31_X, Fix.VELGUS_TRIGGERTILE_31_Y, Fix.VELGUS_TRIGGERTILE_31_Z))
      {
        MessagePack.Message1000045(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_32_X, Fix.VELGUS_TRIGGERTILE_32_Y, Fix.VELGUS_TRIGGERTILE_32_Z))
      {
        MessagePack.Message1000046(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_33_X, Fix.VELGUS_TRIGGERTILE_33_Y, Fix.VELGUS_TRIGGERTILE_33_Z))
      {
        MessagePack.Message1000047(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_34_X, Fix.VELGUS_TRIGGERTILE_34_Y, Fix.VELGUS_TRIGGERTILE_34_Z))
      {
        MessagePack.Message1000048(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_35_X, Fix.VELGUS_TRIGGERTILE_35_Y, Fix.VELGUS_TRIGGERTILE_35_Z))
      {
        MessagePack.Message1000049(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_36_X, Fix.VELGUS_TRIGGERTILE_36_Y, Fix.VELGUS_TRIGGERTILE_36_Z))
      {
        MessagePack.Message1000050(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_37_X, Fix.VELGUS_TRIGGERTILE_37_Y, Fix.VELGUS_TRIGGERTILE_37_Z))
      {
        MessagePack.Message1000051(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_38_X, Fix.VELGUS_TRIGGERTILE_38_Y, Fix.VELGUS_TRIGGERTILE_38_Z))
      {
        MessagePack.Message1000052(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_39_X, Fix.VELGUS_TRIGGERTILE_39_Y, Fix.VELGUS_TRIGGERTILE_39_Z))
      {
        MessagePack.Message1000053(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_40_X, Fix.VELGUS_TRIGGERTILE_40_Y, Fix.VELGUS_TRIGGERTILE_40_Z))
      {
        MessagePack.Message1000054(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_41_X, Fix.VELGUS_TRIGGERTILE_41_Y, Fix.VELGUS_TRIGGERTILE_41_Z))
      {
        MessagePack.Message1000055(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_42_X, Fix.VELGUS_TRIGGERTILE_42_Y, Fix.VELGUS_TRIGGERTILE_42_Z))
      {
        MessagePack.Message1000056(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_43_X, Fix.VELGUS_TRIGGERTILE_43_Y, Fix.VELGUS_TRIGGERTILE_43_Z))
      {
        MessagePack.Message1000057(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_44_X, Fix.VELGUS_TRIGGERTILE_44_Y, Fix.VELGUS_TRIGGERTILE_44_Z))
      {
        MessagePack.Message1000058(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_57_X, Fix.VELGUS_TRIGGERTILE_57_Y, Fix.VELGUS_TRIGGERTILE_57_Z))
      {
        MessagePack.Message1000062(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_30_X, Fix.VELGUS_TRIGGERTILE_30_Y, Fix.VELGUS_TRIGGERTILE_30_Z))
      {
        MessagePack.Message1000059(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_59_X, Fix.VELGUS_TRIGGERTILE_59_Y, Fix.VELGUS_TRIGGERTILE_59_Z))
      {
        MessagePack.Message1000064(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_61_X, Fix.VELGUS_TRIGGERTILE_61_Y, Fix.VELGUS_TRIGGERTILE_61_Z))
      {
        MessagePack.Message1000065(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_CHANTFIELD_62_X + 1.0f, Fix.VELGUS_CHANTFIELD_62_Y, Fix.VELGUS_CHANTFIELD_62_Z)) // イベントは神々の詩詠唱の一歩手前で X + 1とする。
      {
        MessagePack.Message1000066(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_TRIGGERTILE_45_X, Fix.VELGUS_TRIGGERTILE_45_Y, Fix.VELGUS_TRIGGERTILE_45_Z))
      {
        MessagePack.Message1000060(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_66_X, Fix.VELGUS_EVENTTILE_66_Y, Fix.VELGUS_EVENTTILE_66_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000101(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_67_X, Fix.VELGUS_NUMBERTILE_67_Y, Fix.VELGUS_NUMBERTILE_67_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000102(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_68_X, Fix.VELGUS_NUMBERTILE_68_Y, Fix.VELGUS_NUMBERTILE_68_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000103(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_69_X, Fix.VELGUS_NUMBERTILE_69_Y, Fix.VELGUS_NUMBERTILE_69_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000104(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_70_X, Fix.VELGUS_NUMBERTILE_70_Y, Fix.VELGUS_NUMBERTILE_70_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000105(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_71_X, Fix.VELGUS_NUMBERTILE_71_Y, Fix.VELGUS_NUMBERTILE_71_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000106(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_72_X, Fix.VELGUS_NUMBERTILE_72_Y, Fix.VELGUS_NUMBERTILE_72_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000107(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_73_X, Fix.VELGUS_NUMBERTILE_73_Y, Fix.VELGUS_NUMBERTILE_73_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000108(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_74_X, Fix.VELGUS_NUMBERTILE_74_Y, Fix.VELGUS_NUMBERTILE_74_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000109(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_75_X, Fix.VELGUS_NUMBERTILE_75_Y, Fix.VELGUS_NUMBERTILE_75_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000110(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_76_X, Fix.VELGUS_NUMBERTILE_76_Y, Fix.VELGUS_NUMBERTILE_76_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000111(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_77_X, Fix.VELGUS_NUMBERTILE_77_Y, Fix.VELGUS_NUMBERTILE_77_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000112(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_78_X, Fix.VELGUS_NUMBERTILE_78_Y, Fix.VELGUS_NUMBERTILE_78_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000113(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_79_X, Fix.VELGUS_NUMBERTILE_79_Y, Fix.VELGUS_NUMBERTILE_79_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000114(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_80_X, Fix.VELGUS_NUMBERTILE_80_Y, Fix.VELGUS_NUMBERTILE_80_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000115(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_81_X, Fix.VELGUS_NUMBERTILE_81_Y, Fix.VELGUS_NUMBERTILE_81_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000116(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_82_X, Fix.VELGUS_NUMBERTILE_82_Y, Fix.VELGUS_NUMBERTILE_82_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000117(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_83_X, Fix.VELGUS_NUMBERTILE_83_Y, Fix.VELGUS_NUMBERTILE_83_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000118(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_84_X, Fix.VELGUS_NUMBERTILE_84_Y, Fix.VELGUS_NUMBERTILE_84_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000119(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_85_X, Fix.VELGUS_NUMBERTILE_85_Y, Fix.VELGUS_NUMBERTILE_85_Z))
      {
        if (One.TF.Event_Message1000100_Success == false)
        {
          MessagePack.Message1000120(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_87_X, Fix.VELGUS_EVENTTILE_87_Y, Fix.VELGUS_EVENTTILE_87_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000121(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_88_X, Fix.VELGUS_NUMBERTILE_88_Y, Fix.VELGUS_NUMBERTILE_88_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000122(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_89_X, Fix.VELGUS_NUMBERTILE_89_Y, Fix.VELGUS_NUMBERTILE_89_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000123(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_90_X, Fix.VELGUS_NUMBERTILE_90_Y, Fix.VELGUS_NUMBERTILE_90_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000124(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_91_X, Fix.VELGUS_NUMBERTILE_91_Y, Fix.VELGUS_NUMBERTILE_91_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000125(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_92_X, Fix.VELGUS_NUMBERTILE_92_Y, Fix.VELGUS_NUMBERTILE_92_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000126(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_93_X, Fix.VELGUS_NUMBERTILE_93_Y, Fix.VELGUS_NUMBERTILE_93_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000127(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_94_X, Fix.VELGUS_NUMBERTILE_94_Y, Fix.VELGUS_NUMBERTILE_94_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000128(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_95_X, Fix.VELGUS_NUMBERTILE_95_Y, Fix.VELGUS_NUMBERTILE_95_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000129(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_96_X, Fix.VELGUS_NUMBERTILE_96_Y, Fix.VELGUS_NUMBERTILE_96_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000130(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_97_X, Fix.VELGUS_NUMBERTILE_97_Y, Fix.VELGUS_NUMBERTILE_97_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000131(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_98_X, Fix.VELGUS_NUMBERTILE_98_Y, Fix.VELGUS_NUMBERTILE_98_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000132(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_99_X, Fix.VELGUS_NUMBERTILE_99_Y, Fix.VELGUS_NUMBERTILE_99_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000133(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_100_X, Fix.VELGUS_NUMBERTILE_100_Y, Fix.VELGUS_NUMBERTILE_100_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000134(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_101_X, Fix.VELGUS_NUMBERTILE_101_Y, Fix.VELGUS_NUMBERTILE_101_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000135(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_102_X, Fix.VELGUS_NUMBERTILE_102_Y, Fix.VELGUS_NUMBERTILE_102_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000136(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_103_X, Fix.VELGUS_NUMBERTILE_103_Y, Fix.VELGUS_NUMBERTILE_103_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000137(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_104_X, Fix.VELGUS_NUMBERTILE_104_Y, Fix.VELGUS_NUMBERTILE_104_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000138(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_105_X, Fix.VELGUS_NUMBERTILE_105_Y, Fix.VELGUS_NUMBERTILE_105_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000139(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_106_X, Fix.VELGUS_NUMBERTILE_106_Y, Fix.VELGUS_NUMBERTILE_106_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000140(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_107_X, Fix.VELGUS_NUMBERTILE_107_Y, Fix.VELGUS_NUMBERTILE_107_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000141(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_108_X, Fix.VELGUS_NUMBERTILE_108_Y, Fix.VELGUS_NUMBERTILE_108_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000142(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_109_X, Fix.VELGUS_NUMBERTILE_109_Y, Fix.VELGUS_NUMBERTILE_109_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000143(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_110_X, Fix.VELGUS_NUMBERTILE_110_Y, Fix.VELGUS_NUMBERTILE_110_Z))
      {
        if (One.TF.Event_Message1000110_Success == false)
        {
          MessagePack.Message1000144(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_112_X, Fix.VELGUS_EVENTTILE_112_Y, Fix.VELGUS_EVENTTILE_112_Z))
      {
        if (One.TF.Event_Message1000120_Success == false)
        {
          MessagePack.Message1000145(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_113_X, Fix.VELGUS_NUMBERTILE_113_Y, Fix.VELGUS_NUMBERTILE_113_Z))
      {
        if (One.TF.Event_Message1000120_Success == false)
        {
          MessagePack.Message1000146(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_114_X, Fix.VELGUS_NUMBERTILE_114_Y, Fix.VELGUS_NUMBERTILE_114_Z))
      {
        if (One.TF.Event_Message1000120_Success == false)
        {
          MessagePack.Message1000147(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_115_X, Fix.VELGUS_NUMBERTILE_115_Y, Fix.VELGUS_NUMBERTILE_115_Z))
      {
        if (One.TF.Event_Message1000120_Success == false)
        {
          MessagePack.Message1000148(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_116_X, Fix.VELGUS_NUMBERTILE_116_Y, Fix.VELGUS_NUMBERTILE_116_Z))
      {
        if (One.TF.Event_Message1000120_Success == false)
        {
          MessagePack.Message1000149(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_117_X, Fix.VELGUS_NUMBERTILE_117_Y, Fix.VELGUS_NUMBERTILE_117_Z))
      {
        if (One.TF.Event_Message1000120_Success == false)
        {
          MessagePack.Message1000150(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_118_X, Fix.VELGUS_NUMBERTILE_118_Y, Fix.VELGUS_NUMBERTILE_118_Z))
      {
        if (One.TF.Event_Message1000120_Success == false)
        {
          MessagePack.Message1000151(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_NUMBERTILE_119_X, Fix.VELGUS_NUMBERTILE_119_Y, Fix.VELGUS_NUMBERTILE_119_Z))
      {
        if (One.TF.Event_Message1000120_Success == false)
        {
          MessagePack.Message1000152(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_121_X, Fix.VELGUS_EVENTTILE_121_Y, Fix.VELGUS_EVENTTILE_121_Z))
      {
        MessagePack.Message1000161(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_122_X, Fix.VELGUS_EVENTTILE_122_Y, Fix.VELGUS_EVENTTILE_122_Z))
      {
        if (One.TF.Event_Message1000130_Success == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallRed);
        }
        else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallBlue);
        }
        else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallRed);
        }
        else
        {
          return true;
        }

        if (CurrentEventObject == null)
        {
          Debug.Log("Cannot find SearchObject Velgus_BallRed( MoveBottomContinuous )...should debug it.");
          return true;
        }
        MessagePack.Message1000162(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_123_X, Fix.VELGUS_EVENTTILE_123_Y, Fix.VELGUS_EVENTTILE_123_Z))
      {
        if (One.TF.Event_Message1000130_Success == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallRed);
        }
        else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallBlue);
        }
        else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallGreen);
        }
        else
        {
          return true;
        }

        if (CurrentEventObject == null)
        {
          Debug.Log("Cannot find SearchObject Velgus_BallRed( MoveLeftContinuous )...should debug it.");
          return true;
        }
        MessagePack.Message1000163(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_124_X, Fix.VELGUS_EVENTTILE_124_Y, Fix.VELGUS_EVENTTILE_124_Z))
      {
        if (One.TF.Event_Message1000130_Success == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallGreen);
        }
        else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallYellow);
        }
        else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallGreen);
        }
        else
        {
          return true;
        }

        if (CurrentEventObject == null)
        {
          Debug.Log("Cannot find SearchObject Velgus_BallGreen( MoveLeftContinuous )...should debug it.");
          return true;
        }
        MessagePack.Message1000164(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_125_X, Fix.VELGUS_EVENTTILE_125_Y, Fix.VELGUS_EVENTTILE_125_Z))
      {
        if (One.TF.Event_Message1000130_Success == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallGreen);
        }
        else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallYellow);
        }
        else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallBlue);
        }
        else
        {
          return true;
        }

        if (CurrentEventObject == null)
        {
          Debug.Log("Cannot find SearchObject Velgus_BallGreen( MoveTopContinuous )...should debug it.");
          return true;
        }
        MessagePack.Message1000165(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_126_X, Fix.VELGUS_EVENTTILE_126_Y, Fix.VELGUS_EVENTTILE_126_Z))
      {
        if (One.TF.Event_Message1000130_Success == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallBlue);
        }
        else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallRed);
        }
        else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallBlue);
        }
        else
        {
          return true;
        }

        if (CurrentEventObject == null)
        {
          Debug.Log("Cannot find SearchObject Velgus_BallBlue( MoveTopContinuous )...should debug it.");
          return true;
        }
        MessagePack.Message1000166(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_127_X, Fix.VELGUS_EVENTTILE_127_Y, Fix.VELGUS_EVENTTILE_127_Z))
      {
        if (One.TF.Event_Message1000130_Success == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallBlue);
        }
        else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallRed);
        }
        else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallYellow);
        }
        else
        {
          return true;
        }

        if (CurrentEventObject == null)
        {
          Debug.Log("Cannot find SearchObject Velgus_BallBlue( MoveRightContinuous )...should debug it.");
          return true;
        }
        MessagePack.Message1000167(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_128_X, Fix.VELGUS_EVENTTILE_128_Y, Fix.VELGUS_EVENTTILE_128_Z))
      {
        if (One.TF.Event_Message1000130_Success == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallYellow);
        }
        else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallGreen);
        }
        else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallYellow);
        }
        else
        {
          return true;
        }

        if (CurrentEventObject == null)
        {
          Debug.Log("Cannot find SearchObject Velgus_BallYellow( MoveRightContinuous )...should debug it.");
          return true;
        }
        MessagePack.Message1000168(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }
      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_129_X, Fix.VELGUS_EVENTTILE_129_Y, Fix.VELGUS_EVENTTILE_129_Z))
      {
        if (One.TF.Event_Message1000130_Success == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallYellow);
        }
        else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000130_Success_2 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallGreen);
        }
        else if (One.TF.Event_Message1000135 && One.TF.Event_Message1000130_Success_3 == false)
        {
          CurrentEventObject = SearchObject(FieldObject.Content.Velgus_BallRed);
        }
        else
        {
          return true;
        }

        if (CurrentEventObject == null)
        {
          Debug.Log("Cannot find SearchObject Velgus_BallYellow( MoveBottomContinuous )...should debug it.");
          return true;
        }
        MessagePack.Message1000169(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (LocationDetect(tile, Fix.VELGUS_BOSS_204_X, Fix.VELGUS_BOSS_204_Y, Fix.VELGUS_BOSS_204_Z) && One.TF.DefeatOriginStarCoralQueen == false)
      {
        MessagePack.Message1000182(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

    }
    else if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
    {
      if (One.TF.Event_SpeedRun1_Complete == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_208_X, Fix.VELGUS_EVENTTILE_208_Y, Fix.VELGUS_EVENTTILE_208_Z))
        {
          Debug.Log("Velgus_SpeedRun1_Timer: " + this.Velgus_SpeedRun1_Timer.ToString());
          MessagePack.Message1000201(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_209_X, Fix.VELGUS_EVENTTILE_209_Y, Fix.VELGUS_EVENTTILE_209_Z))
        {
          Debug.Log("Velgus_SpeedRun1_Timer: " + this.Velgus_SpeedRun1_Timer.ToString());
          MessagePack.Message1000202(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_210_X, Fix.VELGUS_EVENTTILE_210_Y, Fix.VELGUS_EVENTTILE_210_Z))
        {
          Debug.Log("Velgus_SpeedRun1_Timer: " + this.Velgus_SpeedRun1_Timer.ToString());
          MessagePack.Message1000203(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_211_X, Fix.VELGUS_EVENTTILE_211_Y, Fix.VELGUS_EVENTTILE_211_Z))
        {
          Debug.Log("Velgus_SpeedRun1_Timer: " + this.Velgus_SpeedRun1_Timer.ToString());
          MessagePack.Message1000204(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_212_X, Fix.VELGUS_EVENTTILE_212_Y, Fix.VELGUS_EVENTTILE_212_Z))
        {
          Debug.Log("Velgus_SpeedRun1_Timer: " + this.Velgus_SpeedRun1_Timer.ToString());
          MessagePack.Message1000205(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_213_X, Fix.VELGUS_EVENTTILE_213_Y, Fix.VELGUS_EVENTTILE_213_Z))
        {
          Debug.Log("Velgus_SpeedRun1_Timer: " + this.Velgus_SpeedRun1_Timer.ToString());
          MessagePack.Message1000206(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_214_X, Fix.VELGUS_EVENTTILE_214_Y, Fix.VELGUS_EVENTTILE_214_Z))
        {
          Debug.Log("Velgus_SpeedRun1_Timer: " + this.Velgus_SpeedRun1_Timer.ToString());
          MessagePack.Message1000207(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_215_X, Fix.VELGUS_EVENTTILE_215_Y, Fix.VELGUS_EVENTTILE_215_Z))
        {
          Debug.Log("Velgus_SpeedRun1_Timer: " + this.Velgus_SpeedRun1_Timer.ToString());
          MessagePack.Message1000208(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (One.TF.Event_SpeedRun2_Complete == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_220_X, Fix.VELGUS_EVENTTILE_220_Y, Fix.VELGUS_EVENTTILE_220_Z))
        {
          MessagePack.StartSlideTile(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_221_X, Fix.VELGUS_EVENTTILE_221_Y, Fix.VELGUS_EVENTTILE_221_Z))
        {
          MessagePack.CheckSlideTile(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_222_X, Fix.VELGUS_EVENTTILE_222_Y, Fix.VELGUS_EVENTTILE_222_Z))
        {
          MessagePack.CheckSlideTile(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_223_X, Fix.VELGUS_EVENTTILE_223_Y, Fix.VELGUS_EVENTTILE_223_Z))
        {
          MessagePack.CheckSlideTile(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_224_X, Fix.VELGUS_EVENTTILE_224_Y, Fix.VELGUS_EVENTTILE_224_Z))
        {
          MessagePack.CheckSlideTile(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_225_X, Fix.VELGUS_EVENTTILE_225_Y, Fix.VELGUS_EVENTTILE_225_Z))
        {
          MessagePack.CheckSlideTile(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_226_X, Fix.VELGUS_EVENTTILE_226_Y, Fix.VELGUS_EVENTTILE_226_Z))
        {
          MessagePack.CheckSlideTile(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_227_X, Fix.VELGUS_EVENTTILE_227_Y, Fix.VELGUS_EVENTTILE_227_Z))
        {
          MessagePack.CheckSlideTile(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_228_X, Fix.VELGUS_EVENTTILE_228_Y, Fix.VELGUS_EVENTTILE_228_Z))
        {
          MessagePack.Message1000210(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (One.TF.Event_SpeedRun3_Complete == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_240_X, Fix.VELGUS_EVENTTILE_240_Y, Fix.VELGUS_EVENTTILE_240_Z))
        {
          MessagePack.StartSpeedRun3(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_241_X, Fix.VELGUS_EVENTTILE_241_Y, Fix.VELGUS_EVENTTILE_241_Z))
        {
          MessagePack.Message1000212(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (One.TF.Event_SpeedRun4_Complete == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_243_X, Fix.VELGUS_EVENTTILE_243_Y, Fix.VELGUS_EVENTTILE_243_Z))
        {
          MessagePack.StartSpeedRun4(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_244_X, Fix.VELGUS_EVENTTILE_244_Y, Fix.VELGUS_EVENTTILE_244_Z))
        {
          MessagePack.Message1000214(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (One.TF.Event_SpeedRun5_Complete == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_246_X, Fix.VELGUS_EVENTTILE_246_Y, Fix.VELGUS_EVENTTILE_246_Z))
        {
          MessagePack.StartSpeedRun5(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_247_X, Fix.VELGUS_EVENTTILE_247_Y, Fix.VELGUS_EVENTTILE_247_Z))
        {
          // クラス化していないが、良しとする。
          this.detectFastKeyUpTop = false;
          this.detectFastKeyUpBottom = false;
          this.detectFastKeyUpLeft = false;
          this.detectFastKeyUpRight = false;
          this.FastKeyUpTimerTop = 0;
          this.FastKeyUpTimerBottom = 0;
          this.FastKeyUpTimerLeft = 0;
          this.FastKeyUpTimerRight = 0;
          MessagePack.Message1000216(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (One.TF.EventSeaCirculate1_Complete == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_250_X, Fix.VELGUS_EVENTTILE_250_Y, Fix.VELGUS_EVENTTILE_250_Z))
        {
          MessagePack.Message1000218(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }

      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_251_X, Fix.VELGUS_EVENTTILE_251_Y, Fix.VELGUS_EVENTTILE_251_Z))
      {
        MessagePack.Message1000219(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (One.TF.EventSeaCirculate2_Complete == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_252_X, Fix.VELGUS_EVENTTILE_252_Y, Fix.VELGUS_EVENTTILE_252_Z))
        {
          MessagePack.Message1000220(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
      }
      
      if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_253_X, Fix.VELGUS_EVENTTILE_253_Y, Fix.VELGUS_EVENTTILE_253_Z))
      {
        MessagePack.Message1000221(ref QuestMessageList, ref QuestEventList); TapOK();
        return true;
      }

      if (One.TF.EventSeaCirculate3_Complete == false)
      {
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_254_X, Fix.VELGUS_EVENTTILE_254_Y, Fix.VELGUS_EVENTTILE_254_Z))
        {
          MessagePack.Message1000222(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_255_X, Fix.VELGUS_EVENTTILE_255_Y, Fix.VELGUS_EVENTTILE_255_Z))
        {
          MessagePack.Message1000223(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_256_X, Fix.VELGUS_EVENTTILE_256_Y, Fix.VELGUS_EVENTTILE_256_Z))
        {
          MessagePack.Message1000224(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_257_X, Fix.VELGUS_EVENTTILE_257_Y, Fix.VELGUS_EVENTTILE_257_Z))
        {
          MessagePack.Message1000225(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
        if (LocationDetect(tile, Fix.VELGUS_EVENTTILE_258_X, Fix.VELGUS_EVENTTILE_258_Y, Fix.VELGUS_EVENTTILE_258_Z))
        {
          MessagePack.Message1000226(ref QuestMessageList, ref QuestEventList); TapOK();
          return true;
        }
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
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
      {
        if (LocationDetect(tile, 29.0f, 0, 9.0f))
        {
          this.HomeTownCall = Fix.TOWN_ANSHET;
          return true;
        }
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
        if (LocationDetect(tile, Fix.MYSTICFOREST_UPSTAIR_1_X, Fix.MYSTICFOREST_UPSTAIR_1_Y, Fix.MYSTICFOREST_UPSTAIR_1_Z))
        {
          this.HomeTownCall = Fix.TOWN_COTUHSYE;
          return true;
        }
        if (LocationDetect(tile, Fix.MYSTICFOREST_UPSTAIR_2_X, Fix.MYSTICFOREST_UPSTAIR_2_Y, Fix.MYSTICFOREST_UPSTAIR_2_Z))
        {
          this.HomeTownCall = Fix.TOWN_ZHALMAN;
          return true;
        }
      }
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
      {
        if (LocationDetect(tile, Fix.VELGUS_UPSTAIR_1_X, Fix.VELGUS_UPSTAIR_1_Y, Fix.VELGUS_UPSTAIR_1_Z))
        {
          this.HomeTownCall = Fix.TOWN_PARMETYSIA;
          return true;
        }
      }
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
      {
        if (LocationDetect(tile, Fix.VELGUS_UPSTAIR_2_X, Fix.VELGUS_UPSTAIR_2_Y, Fix.VELGUS_UPSTAIR_2_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_VELGUS, 1.0f, 1.0f, -18.0f);
          return true;
        }
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

      if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
      {
        if (LocationDetect(tile, Fix.OHRANTOWER_DOWNSTAIR_1_X, Fix.OHRANTOWER_DOWNSTAIR_1_Y, Fix.OHRANTOWER_DOWNSTAIR_1_Z))
        {
          this.HomeTownCall = Fix.TOWN_FAZIL_CASTLE;
          return true;
        }
      }

      if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
      {
        if (LocationDetect(tile, Fix.VELGUS_DOWNSTAIR_205_X, Fix.VELGUS_DOWNSTAIR_205_Y, Fix.VELGUS_DOWNSTAIR_205_Z))
        {
          DungeonCallSetup(Fix.MAPFILE_VELGUS_2, Fix.VELGUS_LOCATION_206_X, Fix.VELGUS_LOCATION_206_Y + 1.0f, Fix.VELGUS_LOCATION_206_Z);
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
        this.HomeTownCall = Fix.TOWN_LATA_HOUSE;
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
        Debug.Log("Detect EsmiliaGrassField");
        this.DungeonMap = Fix.MAPFILE_ESMILIA_GRASSFIELD;
        this.DungeonCall = Fix.DUNGEON_ESMILIA_GRASSFIELD;
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

    const int NoEncountNumber = 6;
    CumulativeBattleCounter++;

    // 最初の歩きはじめはエンカウント対象外
    if (CumulativeBattleCounter <= NoEncountNumber)
    {
      return;
    }
    // エンカウントしない場合は対象外
    else if (this.BattleEncount <= -1)
    {
      return;
    }

    // エリア毎にランダムで敵軍隊を生成する。
    #region "エスミリア草原区域"
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
    {
      int random = 100 + NoEncountNumber - CumulativeBattleCounter;
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
      int random = 100 + NoEncountNumber - CumulativeBattleCounter;
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
      int random = 100 + NoEncountNumber - CumulativeBattleCounter;
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
        else if (area_info == TileInformation.Area.AREA_2)
        {
          Debug.Log("area_info is AREA_2");
          int rand_data = AP.Math.RandomInteger(10);
          Debug.Log("rand_data is " + random);
          switch (rand_data)
          {
            case 0:
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.SAVAGE_BEAR);
              One.BattleEnemyList.Add(Fix.SAVAGE_BEAR);
              One.BattleEnemyList.Add(Fix.INNOCENT_FAIRY);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.SAVAGE_BEAR);
              One.BattleEnemyList.Add(Fix.SPEEDY_FALCON);
              One.BattleEnemyList.Add(Fix.INNOCENT_FAIRY);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.WOLF_HUNTER);
              One.BattleEnemyList.Add(Fix.INNOCENT_FAIRY);
              One.BattleEnemyList.Add(Fix.SPEEDY_FALCON);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.WOLF_HUNTER);
              One.BattleEnemyList.Add(Fix.FOREST_PHANTOM);
              One.BattleEnemyList.Add(Fix.FOREST_PHANTOM);
              break;
            case 4:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.FOREST_PHANTOM);
              One.BattleEnemyList.Add(Fix.INNOCENT_FAIRY);
              One.BattleEnemyList.Add(Fix.INNOCENT_FAIRY);
              break;
            case 5:
              Debug.Log("rand_data 5");
              One.BattleEnemyList.Add(Fix.FOREST_PHANTOM);
              One.BattleEnemyList.Add(Fix.SAVAGE_BEAR);
              One.BattleEnemyList.Add(Fix.WOLF_HUNTER);
              break;
            case 6:
              Debug.Log("rand_data 6");
              One.BattleEnemyList.Add(Fix.FOREST_PHANTOM);
              One.BattleEnemyList.Add(Fix.WOLF_HUNTER);
              One.BattleEnemyList.Add(Fix.WOLF_HUNTER);
              break;
            case 7:
              Debug.Log("rand_data 7");
              One.BattleEnemyList.Add(Fix.FOREST_PHANTOM);
              One.BattleEnemyList.Add(Fix.SAVAGE_BEAR);
              One.BattleEnemyList.Add(Fix.SPEEDY_FALCON);
              break;
            case 8:
              Debug.Log("rand_data 8");
              One.BattleEnemyList.Add(Fix.INNOCENT_FAIRY);
              One.BattleEnemyList.Add(Fix.SPEEDY_FALCON);
              One.BattleEnemyList.Add(Fix.SPEEDY_FALCON);
              break;
            case 9:
              Debug.Log("rand_data 9");
              One.BattleEnemyList.Add(Fix.WOLF_HUNTER);
              One.BattleEnemyList.Add(Fix.FOREST_PHANTOM);
              One.BattleEnemyList.Add(Fix.INNOCENT_FAIRY);
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
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.EXCITED_ELEPHANT);
              One.BattleEnemyList.Add(Fix.RAGE_TIGER);
              One.BattleEnemyList.Add(Fix.SYLPH_DANCER);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.GATHERING_LAPTOR);
              One.BattleEnemyList.Add(Fix.EXCITED_ELEPHANT);
              One.BattleEnemyList.Add(Fix.SYLPH_DANCER);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.GATHERING_LAPTOR);
              One.BattleEnemyList.Add(Fix.SYLPH_DANCER);
              One.BattleEnemyList.Add(Fix.SYLPH_DANCER);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.GATHERING_LAPTOR);
              One.BattleEnemyList.Add(Fix.SYLPH_DANCER);
              One.BattleEnemyList.Add(Fix.MUDDLED_PLANT);
              break;
            case 4:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.THORN_WARRIOR);
              One.BattleEnemyList.Add(Fix.RAGE_TIGER);
              One.BattleEnemyList.Add(Fix.MUDDLED_PLANT);
              break;
            case 5:
              Debug.Log("rand_data 5");
              One.BattleEnemyList.Add(Fix.THORN_WARRIOR);
              One.BattleEnemyList.Add(Fix.MUDDLED_PLANT);
              One.BattleEnemyList.Add(Fix.SYLPH_DANCER);
              break;
            case 6:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.THORN_WARRIOR);
              One.BattleEnemyList.Add(Fix.MUDDLED_PLANT);
              One.BattleEnemyList.Add(Fix.RAGE_TIGER);
              break;
            case 7:
              Debug.Log("rand_data 7");
              One.BattleEnemyList.Add(Fix.GATHERING_LAPTOR);
              One.BattleEnemyList.Add(Fix.GATHERING_LAPTOR);
              One.BattleEnemyList.Add(Fix.SYLPH_DANCER);
              break;
            case 8:
              Debug.Log("rand_data 8");
              One.BattleEnemyList.Add(Fix.EXCITED_ELEPHANT);
              One.BattleEnemyList.Add(Fix.SYLPH_DANCER);
              One.BattleEnemyList.Add(Fix.RAGE_TIGER);
              break;
            case 9:
              Debug.Log("rand_data 9");
              One.BattleEnemyList.Add(Fix.EXCITED_ELEPHANT);
              One.BattleEnemyList.Add(Fix.SYLPH_DANCER);
              One.BattleEnemyList.Add(Fix.THORN_WARRIOR);
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
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.FLANSIS_KNIGHT);
              One.BattleEnemyList.Add(Fix.MIST_PYTHON);
              One.BattleEnemyList.Add(Fix.MIST_PYTHON);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.FLANSIS_KNIGHT);
              One.BattleEnemyList.Add(Fix.MIST_PYTHON);
              One.BattleEnemyList.Add(Fix.POISON_MARY);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.TOWERING_ENT);
              One.BattleEnemyList.Add(Fix.POISON_MARY);
              One.BattleEnemyList.Add(Fix.POISON_MARY);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.TOWERING_ENT);
              One.BattleEnemyList.Add(Fix.FLANSIS_KNIGHT);
              One.BattleEnemyList.Add(Fix.MIST_PYTHON);
              break;
            case 4:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.DISTURB_RHINO);
              One.BattleEnemyList.Add(Fix.MIST_PYTHON);
              One.BattleEnemyList.Add(Fix.POISON_MARY);
              break;
            case 5:
              Debug.Log("rand_data 5");
              One.BattleEnemyList.Add(Fix.DISTURB_RHINO);
              One.BattleEnemyList.Add(Fix.FLANSIS_KNIGHT);
              One.BattleEnemyList.Add(Fix.POISON_MARY);
              break;
            case 6:
              Debug.Log("rand_data 6");
              One.BattleEnemyList.Add(Fix.TOWERING_ENT);
              One.BattleEnemyList.Add(Fix.MIST_PYTHON);
              One.BattleEnemyList.Add(Fix.MIST_PYTHON);
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
    #region "オーランの塔"
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_OHRAN_TOWER)
    {
      int random = 200 + NoEncountNumber - CumulativeBattleCounter; // オーランの塔は広いので値は低め
      if (random <= 0) { random = 0; }
      if (AP.Math.RandomInteger(random) <= 10)
      {
        Debug.Log("area_info is " + area_info);
        if (area_info == TileInformation.Area.AREA_1 || area_info == TileInformation.Area.None)
        {
          Debug.Log("area_info is AREA_1");
          int rand_data = AP.Math.RandomInteger(6);
          Debug.Log("rand_data is " + random);
          switch (rand_data)
          {
            case 0:
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.EASTERN_GOLEM);
              One.BattleEnemyList.Add(Fix.SWIFT_EAGLE);
              One.BattleEnemyList.Add(Fix.WISDOM_CENTAURUS);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.WESTERN_GOLEM);
              One.BattleEnemyList.Add(Fix.EASTERN_GOLEM);
              One.BattleEnemyList.Add(Fix.WIND_ELEMENTAL);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.WESTERN_GOLEM);
              One.BattleEnemyList.Add(Fix.SWIFT_EAGLE);
              One.BattleEnemyList.Add(Fix.SWIFT_EAGLE);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.EASTERN_GOLEM);
              One.BattleEnemyList.Add(Fix.WISDOM_CENTAURUS);
              One.BattleEnemyList.Add(Fix.WIND_ELEMENTAL);
              break;
            case 4:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.WIND_ELEMENTAL);
              One.BattleEnemyList.Add(Fix.WISDOM_CENTAURUS);
              One.BattleEnemyList.Add(Fix.SWIFT_EAGLE);
              break;
            case 5:
              Debug.Log("rand_data 5");
              One.BattleEnemyList.Add(Fix.EASTERN_GOLEM);
              One.BattleEnemyList.Add(Fix.SWIFT_EAGLE);
              One.BattleEnemyList.Add(Fix.WIND_ELEMENTAL);
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
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.THE_WHITE_LAVA_EYE);
              One.BattleEnemyList.Add(Fix.STORM_BIRDMAN);
              One.BattleEnemyList.Add(Fix.STORM_BIRDMAN);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.TRIAL_HERMIT);
              One.BattleEnemyList.Add(Fix.STORM_BIRDMAN);
              One.BattleEnemyList.Add(Fix.THE_BLUE_LAVA_EYE);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.THE_WHITE_LAVA_EYE);
              One.BattleEnemyList.Add(Fix.STORM_BIRDMAN);
              One.BattleEnemyList.Add(Fix.THE_BLUE_LAVA_EYE);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.STORM_BIRDMAN);
              One.BattleEnemyList.Add(Fix.MYSTICAL_UNICORN);
              One.BattleEnemyList.Add(Fix.THE_WHITE_LAVA_EYE);
              break;
            case 4:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.SKY_KNIGHT);
              One.BattleEnemyList.Add(Fix.TRIAL_HERMIT);
              One.BattleEnemyList.Add(Fix.THE_PURPLE_HIKARIGOKE);
              break;
            case 5:
              Debug.Log("rand_data 5");
              One.BattleEnemyList.Add(Fix.SKY_KNIGHT);
              One.BattleEnemyList.Add(Fix.SKY_KNIGHT);
              One.BattleEnemyList.Add(Fix.MYSTICAL_UNICORN);
              break;
            case 6:
              Debug.Log("rand_data 6");
              One.BattleEnemyList.Add(Fix.STORM_BIRDMAN);
              One.BattleEnemyList.Add(Fix.STORM_BIRDMAN);
              One.BattleEnemyList.Add(Fix.STORM_BIRDMAN);
              break;
            case 7:
              Debug.Log("rand_data 7");
              One.BattleEnemyList.Add(Fix.MYSTICAL_UNICORN);
              One.BattleEnemyList.Add(Fix.THE_WHITE_LAVA_EYE);
              One.BattleEnemyList.Add(Fix.THE_BLUE_LAVA_EYE);
              break;
            case 8:
              Debug.Log("rand_data 8");
              One.BattleEnemyList.Add(Fix.STORM_BIRDMAN);
              One.BattleEnemyList.Add(Fix.SKY_KNIGHT);
              One.BattleEnemyList.Add(Fix.TRIAL_HERMIT);
              break;
            case 9:
              Debug.Log("rand_data 9");
              One.BattleEnemyList.Add(Fix.MYSTICAL_UNICORN);
              One.BattleEnemyList.Add(Fix.TRIAL_HERMIT);
              One.BattleEnemyList.Add(Fix.TRIAL_HERMIT);
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
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.WHIRLWIND_KITSUNE);
              One.BattleEnemyList.Add(Fix.FLYING_CURTAIN);
              One.BattleEnemyList.Add(Fix.SAINT_PEGASUS);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.WHIRLWIND_KITSUNE);
              One.BattleEnemyList.Add(Fix.AETHER_GUST);
              One.BattleEnemyList.Add(Fix.FLYING_CURTAIN);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.DREAM_WALKER);
              One.BattleEnemyList.Add(Fix.THUNDER_LION);
              One.BattleEnemyList.Add(Fix.DREAM_WALKER);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.THUNDER_LION);
              One.BattleEnemyList.Add(Fix.SAINT_PEGASUS);
              One.BattleEnemyList.Add(Fix.DREAM_WALKER);
              break;
            case 4:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.SAINT_PEGASUS);
              One.BattleEnemyList.Add(Fix.DREAM_WALKER);
              One.BattleEnemyList.Add(Fix.AETHER_GUST);
              break;
            case 5:
              Debug.Log("rand_data 5");
              One.BattleEnemyList.Add(Fix.DREAM_WALKER);
              One.BattleEnemyList.Add(Fix.THUNDER_LION);
              One.BattleEnemyList.Add(Fix.FLYING_CURTAIN);
              break;
            case 6:
              Debug.Log("rand_data 6");
              One.BattleEnemyList.Add(Fix.SAINT_PEGASUS);
              One.BattleEnemyList.Add(Fix.DREAM_WALKER);
              One.BattleEnemyList.Add(Fix.AETHER_GUST);
              break;
            case 7:
              Debug.Log("rand_data 7");
              One.BattleEnemyList.Add(Fix.THUNDER_LION);
              One.BattleEnemyList.Add(Fix.WHIRLWIND_KITSUNE);
              One.BattleEnemyList.Add(Fix.AETHER_GUST);
              break;
            case 8:
              Debug.Log("rand_data 8");
              One.BattleEnemyList.Add(Fix.THUNDER_LION);
              One.BattleEnemyList.Add(Fix.WHIRLWIND_KITSUNE);
              One.BattleEnemyList.Add(Fix.DREAM_WALKER);
              break;
            case 9:
              Debug.Log("rand_data 9");
              One.BattleEnemyList.Add(Fix.FLYING_CURTAIN);
              One.BattleEnemyList.Add(Fix.FLYING_CURTAIN);
              One.BattleEnemyList.Add(Fix.FLYING_CURTAIN);
              break;
            default:
              Debug.Log("rand_data default...");
              break;
          }
        }
        else if (area_info == TileInformation.Area.AREA_4)
        {
          Debug.Log("area_info is AREA_4");
          int rand_data = AP.Math.RandomInteger(10);
          Debug.Log("rand_data is " + random);
          switch (rand_data)
          {
            case 0:
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.IVORY_STATUE);
              One.BattleEnemyList.Add(Fix.BOMB_BALLON);
              One.BattleEnemyList.Add(Fix.TOWER_SCOUT);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.IVORY_STATUE);
              One.BattleEnemyList.Add(Fix.STUBBORN_SAGE);
              One.BattleEnemyList.Add(Fix.BOMB_BALLON);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.OBSERVANT_HERALD);
              One.BattleEnemyList.Add(Fix.TOWER_SCOUT);
              One.BattleEnemyList.Add(Fix.MIST_SALVAGER);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.IVORY_STATUE);
              One.BattleEnemyList.Add(Fix.BOMB_BALLON);
              One.BattleEnemyList.Add(Fix.BOMB_BALLON);
              break;
            case 4:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.OBSERVANT_HERALD);
              One.BattleEnemyList.Add(Fix.MIST_SALVAGER);
              One.BattleEnemyList.Add(Fix.MIST_SALVAGER);
              break;
            case 5:
              Debug.Log("rand_data 5");
              One.BattleEnemyList.Add(Fix.TOWER_SCOUT);
              One.BattleEnemyList.Add(Fix.MIST_SALVAGER);
              One.BattleEnemyList.Add(Fix.STUBBORN_SAGE);
              break;
            case 6:
              Debug.Log("rand_data 6");
              One.BattleEnemyList.Add(Fix.IVORY_STATUE);
              One.BattleEnemyList.Add(Fix.IVORY_STATUE);
              One.BattleEnemyList.Add(Fix.BOMB_BALLON);
              break;
            case 7:
              Debug.Log("rand_data 7");
              One.BattleEnemyList.Add(Fix.STUBBORN_SAGE);
              One.BattleEnemyList.Add(Fix.MIST_SALVAGER);
              One.BattleEnemyList.Add(Fix.OBSERVANT_HERALD);
              break;
            case 8:
              Debug.Log("rand_data 8");
              One.BattleEnemyList.Add(Fix.STUBBORN_SAGE);
              One.BattleEnemyList.Add(Fix.STUBBORN_SAGE);
              One.BattleEnemyList.Add(Fix.TOWER_SCOUT);
              break;
            case 9:
              Debug.Log("rand_data 9");
              One.BattleEnemyList.Add(Fix.STUBBORN_SAGE);
              One.BattleEnemyList.Add(Fix.OBSERVANT_HERALD);
              One.BattleEnemyList.Add(Fix.BOMB_BALLON);
              break;
            default:
              Debug.Log("rand_data default...");
              break;
          }
        }
        else if (area_info == TileInformation.Area.AREA_5)
        {
          Debug.Log("area_info is AREA_4");
          int rand_data = AP.Math.RandomInteger(10);
          Debug.Log("rand_data is " + random);
          switch (rand_data)
          {
            case 0:
              Debug.Log("rand_data 0");
              One.BattleEnemyList.Add(Fix.WINGSPAN_RANGER);
              One.BattleEnemyList.Add(Fix.MAJESTIC_CLOUD);
              One.BattleEnemyList.Add(Fix.HARDENED_GRIFFIN);
              break;
            case 1:
              Debug.Log("rand_data 1");
              One.BattleEnemyList.Add(Fix.PRISMA_SPHERE);
              One.BattleEnemyList.Add(Fix.MOVING_CANNON);
              One.BattleEnemyList.Add(Fix.MOVING_CANNON);
              break;
            case 2:
              Debug.Log("rand_data 2");
              One.BattleEnemyList.Add(Fix.WINGSPAN_RANGER);
              One.BattleEnemyList.Add(Fix.WINGSPAN_RANGER);
              One.BattleEnemyList.Add(Fix.VEIL_FORTUNE_WIZARD);
              break;
            case 3:
              Debug.Log("rand_data 3");
              One.BattleEnemyList.Add(Fix.HARDENED_GRIFFIN);
              One.BattleEnemyList.Add(Fix.MAJESTIC_CLOUD);
              One.BattleEnemyList.Add(Fix.MOVING_CANNON);
              break;
            case 4:
              Debug.Log("rand_data 4");
              One.BattleEnemyList.Add(Fix.HARDENED_GRIFFIN);
              One.BattleEnemyList.Add(Fix.HARDENED_GRIFFIN);
              One.BattleEnemyList.Add(Fix.MOVING_CANNON);
              break;
            case 5:
              Debug.Log("rand_data 5");
              One.BattleEnemyList.Add(Fix.PRISMA_SPHERE);
              One.BattleEnemyList.Add(Fix.PRISMA_SPHERE);
              One.BattleEnemyList.Add(Fix.MAJESTIC_CLOUD);
              break;
            case 6:
              Debug.Log("rand_data 6");
              One.BattleEnemyList.Add(Fix.PRISMA_SPHERE);
              One.BattleEnemyList.Add(Fix.HARDENED_GRIFFIN);
              One.BattleEnemyList.Add(Fix.VEIL_FORTUNE_WIZARD);
              break;
            case 7:
              Debug.Log("rand_data 7");
              One.BattleEnemyList.Add(Fix.VEIL_FORTUNE_WIZARD);
              One.BattleEnemyList.Add(Fix.MOVING_CANNON);
              One.BattleEnemyList.Add(Fix.MAJESTIC_CLOUD);
              break;
            case 8:
              Debug.Log("rand_data 8");
              One.BattleEnemyList.Add(Fix.WINGSPAN_RANGER);
              One.BattleEnemyList.Add(Fix.VEIL_FORTUNE_WIZARD);
              One.BattleEnemyList.Add(Fix.MOVING_CANNON);
              break;
            case 9:
              Debug.Log("rand_data 9");
              One.BattleEnemyList.Add(Fix.HARDENED_GRIFFIN);
              One.BattleEnemyList.Add(Fix.PRISMA_SPHERE);
              One.BattleEnemyList.Add(Fix.VEIL_FORTUNE_WIZARD);
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

  private FieldObject SearchObject(FieldObject.Content obj_content)
  {
    FieldObject obj = null;
    for (int ii = 0; ii < FieldObjList.Count; ii++)
    {
      Debug.Log("SearchObject: " + FieldObjList[ii].ObjectId + " " + FieldObjList[ii].content.ToString());
      // ヴェルガスの海底神殿で、赤、青、緑、黄のボールを探索するために記載しているが
      // 複数ボールがある場合は上手く機能しない。しかしボールは１つずつしかないため、これで良しとする。
      if (FieldObjList[ii].content == FieldObject.Content.Velgus_BallRed &&
          obj_content == FieldObject.Content.Velgus_BallRed)
      {
        obj = FieldObjList[ii];
        break;
      }
      else if (FieldObjList[ii].content == FieldObject.Content.Velgus_BallBlue &&
               obj_content == FieldObject.Content.Velgus_BallBlue)
      {
        obj = FieldObjList[ii];
        break;
      }
      else if (FieldObjList[ii].content == FieldObject.Content.Velgus_BallGreen &&
               obj_content == FieldObject.Content.Velgus_BallGreen)
      {
        obj = FieldObjList[ii];
        break;
      }
      else if (FieldObjList[ii].content == FieldObject.Content.Velgus_BallYellow &&
               obj_content == FieldObject.Content.Velgus_BallYellow)
      {
        obj = FieldObjList[ii];
        break;
      }
    }
    return obj;
  }

  private TileInformation SearchNextTile(Vector3 player, Fix.Direction direction)
  {
    TileInformation next = null;
    if (direction == Fix.Direction.Right)
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
    if (direction == Fix.Direction.Left)
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
    if (direction == Fix.Direction.Top)
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
    if (direction == Fix.Direction.Bottom)
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

      // ここをコメントアウトしておかないとエディタモードで適切にオブジェクト削除できなくなる。
      // 本番ではヴェルガスの海底神殿の移動タイルで使われるロジック。
      float dx = x % 1;
      if (0 < dx && dx <= 0.30f) { x = (float)Math.Round(x); }
      if (0.70f < dx && dx <= 1.00f) { x = (float)Math.Round(x); }

      float dz = z % 1;        
      if (-0.30f < dz && dz <= -0.00f) { z = (float)Math.Round(z);}
      if (-1.00f < dz && dz <= -0.70f) { z = (float)Math.Round(z); }

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

      // ここをコメントアウトしておかないとエディタモードで適切にオブジェクト削除できなくなる。
      // 本番ではヴェルガスの海底神殿の移動タイルで使われるロジック。
      float dx = x % 1;
      if (0 < dx && dx <= 0.30f) { x = (float)Math.Round(x); }
      if (0.70f < dx && dx <= 1.00f) { x = (float)Math.Round(x); }

      float dz = z % 1;
      if (-0.30f < dz && dz <= -0.00f) { z = (float)Math.Round(z); }
      if (-1.00f < dz && dz <= -0.70f) { z = (float)Math.Round(z); }

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

    RefleshMainCamera();

    One.TF.Field_X = this.Player.transform.position.x;
    One.TF.Field_Y = this.Player.transform.position.y;
    One.TF.Field_Z = this.Player.transform.position.z;
  }

  private void RefleshMainCamera()
  {
    MainCamera.transform.position = new Vector3(Player.transform.position.x - 0.0f,
                                           Player.transform.position.y + 7.0f,
                                           Player.transform.position.z - 1.0f);
    PlayerLight.transform.position = Player.transform.position;
  }

  private void UpdateUnknownTile(Vector3 position)
  {
    TileInformation currentRight = SearchNextTile(position, Fix.Direction.Right);
    TileInformation currentLeft = SearchNextTile(position, Fix.Direction.Left);
    TileInformation currentTop = SearchNextTile(position, Fix.Direction.Top);
    TileInformation currentBottom = SearchNextTile(position, Fix.Direction.Bottom);

    for (int ii = 0; ii < UnknownTileList.Count; ii++)
    {
      // 自プレイヤー位置の１スクエアは無条件で可視化する。
      if (position.x - 1.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < position.x + 1.01f
       && position.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < position.z + 1.01f)
      {
        UnknownTileList[ii].gameObject.SetActive(false);
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
        {
          One.TF.KnownTileList_EsmiliaGrassField[ii] = true;
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
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
        {
          One.TF.KnownTileList_VelgusSeaTemple[ii] = true;
        }
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
        {
          One.TF.KnownTileList_VelgusSeaTemple_2[ii] = true;
        }
      }

      //１歩移動先が移動可能な場合その先の縦横クロス１マス分だけ可視化する。
      // ただし扉などで塞がれている場合は可視化しない。
      // 右
      if (currentRight != null && currentRight.MoveCost != 999)
      {
        Vector3 vector = new Vector3(currentRight.transform.position.x, currentRight.transform.position.y + 0.5f, currentRight.transform.position.z);
        FieldObject field_obj = SearchObject(vector);
        if (field_obj == null)
        {
          // 1.0f段差は判定に含める
          Vector3 vector2 = new Vector3(currentRight.transform.position.x, currentRight.transform.position.y + 1.0f, currentRight.transform.position.z);
          field_obj = SearchObject(vector2);
        }

        if (field_obj != null && field_obj.content == FieldObject.Content.Rock ||
            field_obj != null && field_obj.content == FieldObject.Content.Door_Copper ||
            field_obj != null && field_obj.content == FieldObject.Content.Brushwood ||
            field_obj != null && field_obj.content == FieldObject.Content.MysticForest_EventWall ||
            field_obj != null && field_obj.content == FieldObject.Content.Velgus_WallDoor ||
            field_obj != null && field_obj.content == FieldObject.Content.Velgus_SecretWall)
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
            {
              One.TF.KnownTileList_EsmiliaGrassField[ii] = true;
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
            {
              One.TF.KnownTileList_VelgusSeaTemple[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
            {
              One.TF.KnownTileList_VelgusSeaTemple_2[ii] = true;
            }
          }

          if (rightPos.x - 0.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < rightPos.x + 0.01f
           && rightPos.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < rightPos.z + 1.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
            {
              One.TF.KnownTileList_EsmiliaGrassField[ii] = true;
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
            {
              One.TF.KnownTileList_VelgusSeaTemple[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
            {
              One.TF.KnownTileList_VelgusSeaTemple_2[ii] = true;
            }
          }
        }
      }

      // 左
      if (currentLeft != null && currentLeft.MoveCost != 999)
      {
        Vector3 vector = new Vector3(currentLeft.transform.position.x, currentLeft.transform.position.y + 0.5f, currentLeft.transform.position.z);
        FieldObject field_obj = SearchObject(vector);
        if (field_obj == null)
        {
          // 1.0f段差は判定に含める
          Vector3 vector2 = new Vector3(currentLeft.transform.position.x, currentLeft.transform.position.y + 1.0f, currentLeft.transform.position.z);
          field_obj = SearchObject(vector2);
        }
        if (field_obj != null && field_obj.content == FieldObject.Content.Rock ||
            field_obj != null && field_obj.content == FieldObject.Content.Door_Copper ||
            field_obj != null && field_obj.content == FieldObject.Content.Brushwood ||
            field_obj != null && field_obj.content == FieldObject.Content.MysticForest_EventWall ||
            field_obj != null && field_obj.content == FieldObject.Content.Velgus_WallDoor ||
            field_obj != null && field_obj.content == FieldObject.Content.Velgus_SecretWall)
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
            {
              One.TF.KnownTileList_EsmiliaGrassField[ii] = true;
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
            {
              One.TF.KnownTileList_VelgusSeaTemple[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
            {
              One.TF.KnownTileList_VelgusSeaTemple_2[ii] = true;
            }
          }

          if (leftPos.x - 0.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < leftPos.x + 0.01f
           && leftPos.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < leftPos.z + 1.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
            {
              One.TF.KnownTileList_EsmiliaGrassField[ii] = true;
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
            {
              One.TF.KnownTileList_VelgusSeaTemple[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
            {
              One.TF.KnownTileList_VelgusSeaTemple_2[ii] = true;
            }
          }
        }
      }

      // 上
      if (currentTop != null && currentTop.MoveCost != 999)
      {
        Vector3 vector = new Vector3(currentTop.transform.position.x, currentTop.transform.position.y + 0.5f, currentTop.transform.position.z);
        FieldObject field_obj = SearchObject(vector);
        if (field_obj == null)
        {
          // 1.0f段差は判定に含める
          Vector3 vector2 = new Vector3(currentTop.transform.position.x, currentTop.transform.position.y + 1.0f, currentTop.transform.position.z);
          field_obj = SearchObject(vector2);
        }
        if (field_obj != null && field_obj.content == FieldObject.Content.Rock ||
            field_obj != null && field_obj.content == FieldObject.Content.Door_Copper ||
            field_obj != null && field_obj.content == FieldObject.Content.Brushwood ||
            field_obj != null && field_obj.content == FieldObject.Content.MysticForest_EventWall ||
            field_obj != null && field_obj.content == FieldObject.Content.Velgus_WallDoor ||
            field_obj != null && field_obj.content == FieldObject.Content.Velgus_SecretWall)
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
            {
              One.TF.KnownTileList_EsmiliaGrassField[ii] = true;
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
            {
              One.TF.KnownTileList_VelgusSeaTemple[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
            {
              One.TF.KnownTileList_VelgusSeaTemple_2[ii] = true;
            }
          }

          if (topPos.x - 0.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < topPos.x + 0.01f
           && topPos.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < topPos.z + 1.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
            {
              One.TF.KnownTileList_EsmiliaGrassField[ii] = true;
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
            {
              One.TF.KnownTileList_VelgusSeaTemple[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
            {
              One.TF.KnownTileList_VelgusSeaTemple_2[ii] = true;
            }
          }
        }
      }

      // 下
      if (currentBottom != null && currentBottom.MoveCost != 999)
      {
        Vector3 vector = new Vector3(currentBottom.transform.position.x, currentBottom.transform.position.y + 0.5f, currentBottom.transform.position.z);
        FieldObject field_obj = SearchObject(vector);
        if (field_obj == null)
        {
          // 1.0f段差は判定に含める
          Vector3 vector2 = new Vector3(currentBottom.transform.position.x, currentBottom.transform.position.y + 1.0f, currentBottom.transform.position.z);
          field_obj = SearchObject(vector2);
        }
        if (field_obj != null && field_obj.content == FieldObject.Content.Rock ||
            field_obj != null && field_obj.content == FieldObject.Content.Door_Copper ||
            field_obj != null && field_obj.content == FieldObject.Content.Brushwood ||
            field_obj != null && field_obj.content == FieldObject.Content.MysticForest_EventWall ||
            field_obj != null && field_obj.content == FieldObject.Content.Velgus_WallDoor ||
            field_obj != null && field_obj.content == FieldObject.Content.Velgus_SecretWall)
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
            {
              One.TF.KnownTileList_EsmiliaGrassField[ii] = true;
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
            {
              One.TF.KnownTileList_VelgusSeaTemple[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
            {
              One.TF.KnownTileList_VelgusSeaTemple_2[ii] = true;
            }
          }

          if (bottomPos.x - 0.01f < UnknownTileList[ii].transform.position.x && UnknownTileList[ii].transform.position.x < bottomPos.x + 0.01f
           && bottomPos.z - 1.01f < UnknownTileList[ii].transform.position.z && UnknownTileList[ii].transform.position.z < bottomPos.z + 1.01f)
          {
            UnknownTileList[ii].gameObject.SetActive(false);
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
            {
              One.TF.KnownTileList_EsmiliaGrassField[ii] = true;
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
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
            {
              One.TF.KnownTileList_VelgusSeaTemple[ii] = true;
            }
            if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
            {
              One.TF.KnownTileList_VelgusSeaTemple_2[ii] = true;
            }
          }
        }
      }
    }

    // ダンジョン毎に到達ポイントで特定領域を可視化
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
    {
      if (position.x == 4.0f && position.y == 1.0f && position.z == 5.0f)
      {
        List<int> numbers = new List<int>() { 172, 173, 174, 175, 176, 212, 213, 214, 215, 216, 252, 253, 254, 255, 256, 292, 293, 294, 295, 296, 332, 333, 334, 335, 336 };
        for (int ii = 0; ii < numbers.Count; ii++)
        {
          UnknownTileList[numbers[ii]].gameObject.SetActive(false);
          One.TF.KnownTileList_EsmiliaGrassField[numbers[ii]] = true;
        }
      }
      if (position.x == 10.0f && position.y == 1 && position.z == -3)
      {
        List<int> numbers = new List<int>() { 619, 620, 621, 622, 623, 624, 659, 660, 661, 662, 663, 664, 699, 700, 701, 702, 703, 704, 739, 740, 741, 742, 743, 744, 779, 780, 781, 782, 783, 784 };
        for (int ii = 0; ii < numbers.Count; ii++)
        {
          UnknownTileList[numbers[ii]].gameObject.SetActive(false);
          One.TF.KnownTileList_EsmiliaGrassField[numbers[ii]] = true;
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
    else if (tile_name == "Velgus_Normal")
    {
      current = Instantiate(prefab_Velgus_Normal, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_Wall")
    {
      current = Instantiate(prefab_Velgus_Wall, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_Sea")
    {
      current = Instantiate(prefab_Velgus_Sea, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_Number1")
    {
      current = Instantiate(prefab_Velgus_Number1, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_Number2")
    {
      current = Instantiate(prefab_Velgus_Number2, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_Number3")
    {
      current = Instantiate(prefab_Velgus_Number3, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_Number4")
    {
      current = Instantiate(prefab_Velgus_Number4, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_Number5")
    {
      current = Instantiate(prefab_Velgus_Number5, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_Number6")
    {
      current = Instantiate(prefab_Velgus_Number6, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_Number7")
    {
      current = Instantiate(prefab_Velgus_Number7, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_CircleRed")
    {
      current = Instantiate(prefab_Velgus_CircleRed, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_CircleBlue")
    {
      current = Instantiate(prefab_Velgus_CircleBlue, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_CircleGreen")
    {
      current = Instantiate(prefab_Velgus_CircleGreen, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Velgus_CircleYellow")
    {
      current = Instantiate(prefab_Velgus_CircleYellow, position, Quaternion.identity) as TileInformation;
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
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_ESMILIA_GRASSFIELD)
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
      else if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS)
      {
        current = Instantiate(prefab_Unknown_Velgus, position, Quaternion.identity) as TileInformation;
      }
      else if (One.TF.CurrentDungeonField == Fix.MAPFILE_VELGUS_2)
      {
        current = Instantiate(prefab_Unknown_Velgus_2, position, Quaternion.identity) as TileInformation;
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
    else if (obj_name == "MysticForest_EventWall")
    {
      current = Instantiate(prefab_MysticForest_EventWall, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.MysticForest_EventWall;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "OhranTower_Door_ShadowMoon")
    {
      current = Instantiate(prefab_OhranTower_Door_ShadowMoon, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.OhranTower_Door_ShadowMoon;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "OhranTower_Door_SunBurst")
    {
      current = Instantiate(prefab_OhranTower_Door_SunBurst, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.OhranTower_Door_SunBurst;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "OhranTower_Door_StarDust")
    {
      current = Instantiate(prefab_OhranTower_Door_StarDust, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.OhranTower_Door_StarDust;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "OhranTower_Door_OriginRoad")
    {
      current = Instantiate(prefab_OhranTower_Door_OriginRoad, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.OhranTower_Door_OriginRoad;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_WallDoor")
    {
      current = Instantiate(prefab_Velgus_WallDoor, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_WallDoor;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_SecretWall")
    {
      current = Instantiate(prefab_Velgus_SecretWall, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_SecretWall;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_FakeSea")
    {
      current = Instantiate(prefab_Velgus_FakeSea, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_FakeSea;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_BallRed")
    {
      current = Instantiate(prefab_Velgus_BallRed, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_BallRed;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_BallBlue")
    {
      current = Instantiate(prefab_Velgus_BallBlue, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_BallBlue;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_BallGreen")
    {
      current = Instantiate(prefab_Velgus_BallGreen, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_BallGreen;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_BallYellow")
    {
      current = Instantiate(prefab_Velgus_BallYellow, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_BallYellow;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_CircleRed")
    {
      current = Instantiate(prefab_Velgus_CircleRedObj, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_CircleRed;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_CircleBlue")
    {
      current = Instantiate(prefab_Velgus_CircleBlueObj, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_CircleBlue;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_CircleGreen")
    {
      current = Instantiate(prefab_Velgus_CircleGreenObj, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_CircleGreen;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_CircleYellow")
    {
      current = Instantiate(prefab_Velgus_CircleYellowObj, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_CircleYellow;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_SlidingTile")
    {
      current = Instantiate(prefab_Velgus_SlidingTile, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_SlidingTile;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_FixedTile")
    {
      current = Instantiate(prefab_Velgus_FixedTile, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_FixedTile;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile1")
    {
      current = Instantiate(prefab_Velgus_MovingTile1, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile1;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile2")
    {
      current = Instantiate(prefab_Velgus_MovingTile2, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile2;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile3")
    {
      current = Instantiate(prefab_Velgus_MovingTile3, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile3;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile4")
    {
      current = Instantiate(prefab_Velgus_MovingTile4, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile4;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile5")
    {
      current = Instantiate(prefab_Velgus_MovingTile5, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile5;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile2_1")
    {
      current = Instantiate(prefab_Velgus_MovingTile2_1, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile2_1;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile2_2")
    {
      current = Instantiate(prefab_Velgus_MovingTile2_2, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile2_2;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile2_3")
    {
      current = Instantiate(prefab_Velgus_MovingTile2_3, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile2_3;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile2_4")
    {
      current = Instantiate(prefab_Velgus_MovingTile2_4, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile2_4;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile2_5")
    {
      current = Instantiate(prefab_Velgus_MovingTile2_5, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile2_5;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile2_6")
    {
      current = Instantiate(prefab_Velgus_MovingTile2_6, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile2_6;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile2_7")
    {
      current = Instantiate(prefab_Velgus_MovingTile2_7, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile2_7;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile2_8")
    {
      current = Instantiate(prefab_Velgus_MovingTile2_8, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile2_8;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile3_1")
    {
      current = Instantiate(prefab_Velgus_MovingTile3_1, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile3_1;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile3_2")
    {
      current = Instantiate(prefab_Velgus_MovingTile3_2, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile3_2;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile3_3")
    {
      current = Instantiate(prefab_Velgus_MovingTile3_3, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile3_3;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile3_4")
    {
      current = Instantiate(prefab_Velgus_MovingTile3_4, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile3_4;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile3_5")
    {
      current = Instantiate(prefab_Velgus_MovingTile3_5, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile3_5;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile3_6")
    {
      current = Instantiate(prefab_Velgus_MovingTile3_6, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile3_6;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = q * current.transform.rotation;
    }
    else if (obj_name == "Velgus_MovingTile3_7")
    {
      current = Instantiate(prefab_Velgus_MovingTile3_7, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Velgus_MovingTile3_7;
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
    if (map_data == Fix.MAPFILE_ESMILIA_GRASSFIELD)
    {
      for (int ii = 0; ii < Fix.MAPSIZE_Z_ESMILIA_GRASSFIELD; ii++)
      {
        for (int jj = 0; jj < Fix.MAPSIZE_X_ESMILIA_GRASSFIELD; jj++)
        {
          Vector3 position = new Vector3(jj - 10, 1.0f, 12 - ii);
          AddUnknown("Unknown", position, "X" + ii + "_Z" + jj);
          UnknownTileList[UnknownTileList.Count - 1].gameObject.SetActive(true);
        }
      }
      for (int ii = 0; ii < Fix.MAPSIZE_X_ESMILIA_GRASSFIELD * Fix.MAPSIZE_Z_ESMILIA_GRASSFIELD; ii++)
      {
        if (One.TF.KnownTileList_EsmiliaGrassField[ii])
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

    if (map_data == Fix.MAPFILE_VELGUS)
    {
      for (int ii = 0; ii < Fix.MAPSIZE_Z_VELGUS_SEATEMPLE; ii++)
      {
        for (int jj = 0; jj < Fix.MAPSIZE_X_VELGUS_SEATEMPLE; jj++)
        {
          Vector3 position = new Vector3(jj, 1.0f, -ii);
          AddUnknown("Unknown", position, "X" + ii + "_Z" + jj);
          UnknownTileList[UnknownTileList.Count - 1].gameObject.SetActive(true);
        }
      }
      Debug.Log("KnownTileList_VelgusSeaTemple count: " + One.TF.KnownTileList_VelgusSeaTemple.Count);
      for (int ii = 0; ii < Fix.MAPSIZE_X_VELGUS_SEATEMPLE * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE; ii++)
      {
        if (One.TF.KnownTileList_VelgusSeaTemple[ii])
        {
          UnknownTileList[ii].gameObject.SetActive(false);
        }
      }
    }

    if (map_data == Fix.MAPFILE_VELGUS_2)
    {
      for (int ii = 0; ii < Fix.MAPSIZE_Z_VELGUS_SEATEMPLE_2; ii++)
      {
        for (int jj = 0; jj < Fix.MAPSIZE_X_VELGUS_SEATEMPLE_2; jj++)
        {
          Vector3 position = new Vector3(jj, 1.0f, -ii);
          AddUnknown("Unknown", position, "X" + ii + "_Z" + jj);
          UnknownTileList[UnknownTileList.Count - 1].gameObject.SetActive(true);
        }
      }
      for (int ii = 0; ii < Fix.MAPSIZE_X_VELGUS_SEATEMPLE_2 * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE_2; ii++)
      {
        if (One.TF.KnownTileList_VelgusSeaTemple_2[ii])
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
    #region "エスミリア草原区域"
    if (map_data == Fix.MAPFILE_ESMILIA_GRASSFIELD)
    {
      Debug.Log("update " + map_data + " field");
      if (One.TF.Treasure_EsmiliaGrassField_00001)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_1_X, Fix.ESMILIA_Treasure_1_Y, Fix.ESMILIA_Treasure_1_Z)));
      }
      if (One.TF.Treasure_EsmiliaGrassField_00002)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_2_X, Fix.ESMILIA_Treasure_2_Y, Fix.ESMILIA_Treasure_2_Z)));
      }
      if (One.TF.Treasure_EsmiliaGrassField_00003)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_3_X, Fix.ESMILIA_Treasure_3_Y, Fix.ESMILIA_Treasure_3_Z)));
      }
      if (One.TF.Treasure_EsmiliaGrassField_00004)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_4_X, Fix.ESMILIA_Treasure_4_Y, Fix.ESMILIA_Treasure_4_Z)));
      }
      if (One.TF.Treasure_EsmiliaGrassField_00005)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_5_X, Fix.ESMILIA_Treasure_5_Y, Fix.ESMILIA_Treasure_5_Z)));
      }
      if (One.TF.Treasure_EsmiliaGrassField_00006)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_6_X, Fix.ESMILIA_Treasure_6_Y, Fix.ESMILIA_Treasure_6_Z)));
      }
      if (One.TF.Treasure_EsmiliaGrassField_00007)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_7_X, Fix.ESMILIA_Treasure_7_Y, Fix.ESMILIA_Treasure_7_Z)));
      }
      if (One.TF.Treasure_EsmiliaGrassField_00008)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_8_X, Fix.ESMILIA_Treasure_8_Y, Fix.ESMILIA_Treasure_8_Z)));
      }
      if (One.TF.Treasure_EsmiliaGrassField_00009)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_9_X, Fix.ESMILIA_Treasure_9_Y, Fix.ESMILIA_Treasure_9_Z)));
      }
      if (One.TF.Treasure_EsmiliaGrassField_00010)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.ESMILIA_Treasure_10_X, Fix.ESMILIA_Treasure_10_Y, Fix.ESMILIA_Treasure_10_Z)));
      }

      // 岩壁１
      if (One.TF.FieldObject_EsmiliaGrassField_00001)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_1_X, Fix.ESMILIA_Rock_1_Y, Fix.ESMILIA_Rock_1_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_2_X, Fix.ESMILIA_Rock_2_Y, Fix.ESMILIA_Rock_2_Z));
      }
      // 岩壁６
      if (One.TF.FieldObject_EsmiliaGrassField_00002)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_6_X, Fix.ESMILIA_Rock_6_Y, Fix.ESMILIA_Rock_6_Z));
      }
      // 岩壁５
      if (One.TF.FieldObject_EsmiliaGrassField_00003)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_5_X, Fix.ESMILIA_Rock_5_Y, Fix.ESMILIA_Rock_5_Z));
      }
      // 岩壁７
      if (One.TF.FieldObject_EsmiliaGrassField_00007)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_7_X, Fix.ESMILIA_Rock_7_Y, Fix.ESMILIA_Rock_7_Z));
      }
      // 岩壁４
      if (One.TF.FieldObject_EsmiliaGrassField_00008)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_4_X, Fix.ESMILIA_Rock_4_Y, Fix.ESMILIA_Rock_4_Z));
      }
      // 岩壁８
      if (One.TF.FieldObject_EsmiliaGrassField_00009)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.ESMILIA_Rock_8_X, Fix.ESMILIA_Rock_8_Y, Fix.ESMILIA_Rock_8_Z));
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
    #region "神秘の森"
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_MYSTIC_FOREST)
    {
      if (One.TF.Treasure_MysticForest_00001)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_1_X, Fix.MYSTICFOREST_Treasure_1_Y, Fix.MYSTICFOREST_Treasure_1_Z)));
      }
      if (One.TF.Treasure_MysticForest_00002)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_2_X, Fix.MYSTICFOREST_Treasure_2_Y, Fix.MYSTICFOREST_Treasure_2_Z)));
      }
      if (One.TF.Treasure_MysticForest_00003)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_3_X, Fix.MYSTICFOREST_Treasure_3_Y, Fix.MYSTICFOREST_Treasure_3_Z)));
      }
      if (One.TF.Treasure_MysticForest_00004)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_4_X, Fix.MYSTICFOREST_Treasure_4_Y, Fix.MYSTICFOREST_Treasure_4_Z)));
      }
      if (One.TF.Treasure_MysticForest_00005)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_5_X, Fix.MYSTICFOREST_Treasure_5_Y, Fix.MYSTICFOREST_Treasure_5_Z)));
      }
      if (One.TF.Treasure_MysticForest_00006)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_6_X, Fix.MYSTICFOREST_Treasure_6_Y, Fix.MYSTICFOREST_Treasure_6_Z)));
      }
      if (One.TF.Treasure_MysticForest_00007)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_7_X, Fix.MYSTICFOREST_Treasure_7_Y, Fix.MYSTICFOREST_Treasure_7_Z)));
      }
      if (One.TF.Treasure_MysticForest_00008)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_8_X, Fix.MYSTICFOREST_Treasure_8_Y, Fix.MYSTICFOREST_Treasure_8_Z)));
      }
      if (One.TF.Treasure_MysticForest_00009)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_9_X, Fix.MYSTICFOREST_Treasure_9_Y, Fix.MYSTICFOREST_Treasure_9_Z)));
      }
      if (One.TF.Treasure_MysticForest_00010)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_10_X, Fix.MYSTICFOREST_Treasure_10_Y, Fix.MYSTICFOREST_Treasure_10_Z)));
      }
      if (One.TF.Treasure_MysticForest_00011)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_11_X, Fix.MYSTICFOREST_Treasure_11_Y, Fix.MYSTICFOREST_Treasure_11_Z)));
      }
      if (One.TF.Treasure_MysticForest_00012)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_12_X, Fix.MYSTICFOREST_Treasure_12_Y, Fix.MYSTICFOREST_Treasure_12_Z)));
      }
      if (One.TF.Treasure_MysticForest_00013)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_13_X, Fix.MYSTICFOREST_Treasure_13_Y, Fix.MYSTICFOREST_Treasure_13_Z)));
      }
      if (One.TF.Treasure_MysticForest_00014)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_14_X, Fix.MYSTICFOREST_Treasure_14_Y, Fix.MYSTICFOREST_Treasure_14_Z)));
      }
      if (One.TF.Treasure_MysticForest_00015)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_15_X, Fix.MYSTICFOREST_Treasure_15_Y, Fix.MYSTICFOREST_Treasure_15_Z)));
      }
      if (One.TF.Treasure_MysticForest_00016)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_16_X, Fix.MYSTICFOREST_Treasure_16_Y, Fix.MYSTICFOREST_Treasure_16_Z)));
      }
      if (One.TF.Treasure_MysticForest_00017)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_17_X, Fix.MYSTICFOREST_Treasure_17_Y, Fix.MYSTICFOREST_Treasure_17_Z)));
      }
      if (One.TF.Treasure_MysticForest_00018)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_18_X, Fix.MYSTICFOREST_Treasure_18_Y, Fix.MYSTICFOREST_Treasure_18_Z)));
      }
      if (One.TF.Treasure_MysticForest_00019)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.MYSTICFOREST_Treasure_19_X, Fix.MYSTICFOREST_Treasure_19_Y, Fix.MYSTICFOREST_Treasure_19_Z)));
      }

      // 茂み１
      if (One.TF.FieldObject_MysticForest_00001)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_1_X, Fix.MYSTICFOREST_BRUSHWOOD_1_Y, Fix.MYSTICFOREST_BRUSHWOOD_1_Z));
      }
      // 茂み２
      if (One.TF.FieldObject_MysticForest_00002)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_2_X, Fix.MYSTICFOREST_BRUSHWOOD_2_Y, Fix.MYSTICFOREST_BRUSHWOOD_2_Z));
      }
      // 茂み３
      if (One.TF.FieldObject_MysticForest_00003)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_3_X, Fix.MYSTICFOREST_BRUSHWOOD_3_Y, Fix.MYSTICFOREST_BRUSHWOOD_3_Z));
      }
      // 茂み４
      if (One.TF.FieldObject_MysticForest_00004)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_4_X, Fix.MYSTICFOREST_BRUSHWOOD_4_Y, Fix.MYSTICFOREST_BRUSHWOOD_4_Z));
      }
      // 茂み５
      if (One.TF.FieldObject_MysticForest_00005)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_5_X, Fix.MYSTICFOREST_BRUSHWOOD_5_Y, Fix.MYSTICFOREST_BRUSHWOOD_5_Z));
      }
      // 茂み６
      if (One.TF.FieldObject_MysticForest_00006)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_6_X, Fix.MYSTICFOREST_BRUSHWOOD_6_Y, Fix.MYSTICFOREST_BRUSHWOOD_6_Z));
      }
      //// 茂み７
      //if (One.TF.FieldObject_MysticForest_00007)
      //{
      //  RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_7_X, Fix.MYSTICFOREST_BRUSHWOOD_7_Y, Fix.MYSTICFOREST_BRUSHWOOD_7_Z));
      //}
      //// 茂み８
      //if (One.TF.FieldObject_MysticForest_00008)
      //{
      //  RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_8_X, Fix.MYSTICFOREST_BRUSHWOOD_8_Y, Fix.MYSTICFOREST_BRUSHWOOD_8_Z));
      //}
      //// 茂み９
      //if (One.TF.FieldObject_MysticForest_00009)
      //{
      //  RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_9_X, Fix.MYSTICFOREST_BRUSHWOOD_9_Y, Fix.MYSTICFOREST_BRUSHWOOD_9_Z));
      //}
      //// 茂み１０
      //if (One.TF.FieldObject_MysticForest_00010)
      //{
      //  RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_10_X, Fix.MYSTICFOREST_BRUSHWOOD_10_Y, Fix.MYSTICFOREST_BRUSHWOOD_10_Z));
      //}
      // 茂み１１
      if (One.TF.FieldObject_MysticForest_00011)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_11_X, Fix.MYSTICFOREST_BRUSHWOOD_11_Y, Fix.MYSTICFOREST_BRUSHWOOD_11_Z));
      }
      // 茂み１２
      if (One.TF.FieldObject_MysticForest_00012)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_BRUSHWOOD_12_X, Fix.MYSTICFOREST_BRUSHWOOD_12_Y, Fix.MYSTICFOREST_BRUSHWOOD_12_Z));
      }

      if (One.TF.Event_Message900090)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.MYSTICFOREST_ObsidianPortal_1_X, Fix.MYSTICFOREST_ObsidianPortal_1_Y, Fix.MYSTICFOREST_ObsidianPortal_1_Z));
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
      if (One.TF.Event_Message800210)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_KEYDOOR_4_X, Fix.OHRANTOWER_KEYDOOR_4_Y, Fix.OHRANTOWER_KEYDOOR_4_Z));
      }
      if (One.TF.Event_Message800190)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_KEYDOOR_3_X, Fix.OHRANTOWER_KEYDOOR_3_Y, Fix.OHRANTOWER_KEYDOOR_3_Z));
      }
      if (One.TF.Event_Message800046)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_KEYDOOR_1_X, Fix.OHRANTOWER_KEYDOOR_1_Y, Fix.OHRANTOWER_KEYDOOR_1_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_KEYDOOR_2_X, Fix.OHRANTOWER_KEYDOOR_2_Y, Fix.OHRANTOWER_KEYDOOR_2_Z));
      }

      if (One.TF.FieldObject_OhranTower_00001)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_1_X, Fix.OHRANTOWER_FLOATINGTILE_1_Y, Fix.OHRANTOWER_FLOATINGTILE_1_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_2_X, Fix.OHRANTOWER_FLOATINGTILE_2_Y, Fix.OHRANTOWER_FLOATINGTILE_2_Z));
      }
      if (One.TF.FieldObject_OhranTower_00002)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_3_X, Fix.OHRANTOWER_FLOATINGTILE_3_Y, Fix.OHRANTOWER_FLOATINGTILE_3_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_4_X, Fix.OHRANTOWER_FLOATINGTILE_4_Y, Fix.OHRANTOWER_FLOATINGTILE_4_Z));
      }
      if (One.TF.FieldObject_OhranTower_00003)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_5_X, Fix.OHRANTOWER_FLOATINGTILE_5_Y, Fix.OHRANTOWER_FLOATINGTILE_5_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_6_X, Fix.OHRANTOWER_FLOATINGTILE_6_Y, Fix.OHRANTOWER_FLOATINGTILE_6_Z));
      }
      if (One.TF.FieldObject_OhranTower_00004)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_7_X, Fix.OHRANTOWER_FLOATINGTILE_7_Y, Fix.OHRANTOWER_FLOATINGTILE_7_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_8_X, Fix.OHRANTOWER_FLOATINGTILE_8_Y, Fix.OHRANTOWER_FLOATINGTILE_8_Z));
      }
      if (One.TF.FieldObject_OhranTower_00005)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_9_X, Fix.OHRANTOWER_FLOATINGTILE_9_Y, Fix.OHRANTOWER_FLOATINGTILE_9_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_10_X, Fix.OHRANTOWER_FLOATINGTILE_10_Y, Fix.OHRANTOWER_FLOATINGTILE_10_Z));
      }
      if (One.TF.FieldObject_OhranTower_00006)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_11_X, Fix.OHRANTOWER_FLOATINGTILE_11_Y, Fix.OHRANTOWER_FLOATINGTILE_11_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_12_X, Fix.OHRANTOWER_FLOATINGTILE_12_Y, Fix.OHRANTOWER_FLOATINGTILE_12_Z));
      }
      if (One.TF.FieldObject_OhranTower_00007)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_13_X, Fix.OHRANTOWER_FLOATINGTILE_13_Y, Fix.OHRANTOWER_FLOATINGTILE_13_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_14_X, Fix.OHRANTOWER_FLOATINGTILE_14_Y, Fix.OHRANTOWER_FLOATINGTILE_14_Z));
      }
      if (One.TF.FieldObject_OhranTower_00008)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_15_X, Fix.OHRANTOWER_FLOATINGTILE_15_Y, Fix.OHRANTOWER_FLOATINGTILE_15_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_16_X, Fix.OHRANTOWER_FLOATINGTILE_16_Y, Fix.OHRANTOWER_FLOATINGTILE_16_Z));
      }
      if (One.TF.FieldObject_OhranTower_00009)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_17_X, Fix.OHRANTOWER_FLOATINGTILE_17_Y, Fix.OHRANTOWER_FLOATINGTILE_17_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_18_X, Fix.OHRANTOWER_FLOATINGTILE_18_Y, Fix.OHRANTOWER_FLOATINGTILE_18_Z));
      }
      if (One.TF.FieldObject_OhranTower_00010)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_19_X, Fix.OHRANTOWER_FLOATINGTILE_19_Y, Fix.OHRANTOWER_FLOATINGTILE_19_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_20_X, Fix.OHRANTOWER_FLOATINGTILE_20_Y, Fix.OHRANTOWER_FLOATINGTILE_20_Z));
      }
      if (One.TF.FieldObject_OhranTower_00011)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_21_X, Fix.OHRANTOWER_FLOATINGTILE_21_Y, Fix.OHRANTOWER_FLOATINGTILE_21_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_22_X, Fix.OHRANTOWER_FLOATINGTILE_22_Y, Fix.OHRANTOWER_FLOATINGTILE_22_Z));
      }
      if (One.TF.FieldObject_OhranTower_00012)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_23_X, Fix.OHRANTOWER_FLOATINGTILE_23_Y, Fix.OHRANTOWER_FLOATINGTILE_23_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_24_X, Fix.OHRANTOWER_FLOATINGTILE_24_Y, Fix.OHRANTOWER_FLOATINGTILE_24_Z));
      }
      if (One.TF.FieldObject_OhranTower_00013)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_25_X, Fix.OHRANTOWER_FLOATINGTILE_25_Y, Fix.OHRANTOWER_FLOATINGTILE_25_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_26_X, Fix.OHRANTOWER_FLOATINGTILE_26_Y, Fix.OHRANTOWER_FLOATINGTILE_26_Z));
      }
      if (One.TF.FieldObject_OhranTower_00014)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_27_X, Fix.OHRANTOWER_FLOATINGTILE_27_Y, Fix.OHRANTOWER_FLOATINGTILE_27_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_28_X, Fix.OHRANTOWER_FLOATINGTILE_28_Y, Fix.OHRANTOWER_FLOATINGTILE_28_Z));
      }
      if (One.TF.FieldObject_OhranTower_00015)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_29_X, Fix.OHRANTOWER_FLOATINGTILE_29_Y, Fix.OHRANTOWER_FLOATINGTILE_29_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_30_X, Fix.OHRANTOWER_FLOATINGTILE_30_Y, Fix.OHRANTOWER_FLOATINGTILE_30_Z));
      }
      if (One.TF.FieldObject_OhranTower_00016)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_31_X, Fix.OHRANTOWER_FLOATINGTILE_31_Y, Fix.OHRANTOWER_FLOATINGTILE_31_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_32_X, Fix.OHRANTOWER_FLOATINGTILE_32_Y, Fix.OHRANTOWER_FLOATINGTILE_32_Z));
      }
      if (One.TF.FieldObject_OhranTower_00017)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_33_X, Fix.OHRANTOWER_FLOATINGTILE_33_Y, Fix.OHRANTOWER_FLOATINGTILE_33_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_34_X, Fix.OHRANTOWER_FLOATINGTILE_34_Y, Fix.OHRANTOWER_FLOATINGTILE_34_Z));
      }
      if (One.TF.FieldObject_OhranTower_00018)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_35_X, Fix.OHRANTOWER_FLOATINGTILE_35_Y, Fix.OHRANTOWER_FLOATINGTILE_35_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_36_X, Fix.OHRANTOWER_FLOATINGTILE_36_Y, Fix.OHRANTOWER_FLOATINGTILE_36_Z));
      }
      if (One.TF.FieldObject_OhranTower_00019)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_37_X, Fix.OHRANTOWER_FLOATINGTILE_37_Y, Fix.OHRANTOWER_FLOATINGTILE_37_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_38_X, Fix.OHRANTOWER_FLOATINGTILE_38_Y, Fix.OHRANTOWER_FLOATINGTILE_38_Z));
      }
      if (One.TF.FieldObject_OhranTower_00020)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_39_X, Fix.OHRANTOWER_FLOATINGTILE_39_Y, Fix.OHRANTOWER_FLOATINGTILE_39_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_40_X, Fix.OHRANTOWER_FLOATINGTILE_40_Y, Fix.OHRANTOWER_FLOATINGTILE_40_Z));
      }
      if (One.TF.FieldObject_OhranTower_00021)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_41_X, Fix.OHRANTOWER_FLOATINGTILE_41_Y, Fix.OHRANTOWER_FLOATINGTILE_41_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_42_X, Fix.OHRANTOWER_FLOATINGTILE_42_Y, Fix.OHRANTOWER_FLOATINGTILE_42_Z));
      }
      if (One.TF.FieldObject_OhranTower_00022 && One.TF.FieldObject_OhranTower_00023 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_43_X, Fix.OHRANTOWER_FLOATINGTILE_43_Y, Fix.OHRANTOWER_FLOATINGTILE_43_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_44_X, Fix.OHRANTOWER_FLOATINGTILE_44_Y, Fix.OHRANTOWER_FLOATINGTILE_44_Z));
      }
      if (One.TF.FieldObject_OhranTower_00023)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_43_X, Fix.OHRANTOWER_FLOATINGTILE_43_Y, Fix.OHRANTOWER_FLOATINGTILE_43_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_45_X, Fix.OHRANTOWER_FLOATINGTILE_45_Y, Fix.OHRANTOWER_FLOATINGTILE_45_Z));
      }
      if (One.TF.FieldObject_OhranTower_00024)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_46_X, Fix.OHRANTOWER_FLOATINGTILE_46_Y, Fix.OHRANTOWER_FLOATINGTILE_46_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_47_X, Fix.OHRANTOWER_FLOATINGTILE_47_Y, Fix.OHRANTOWER_FLOATINGTILE_47_Z));
      }
      if (One.TF.FieldObject_OhranTower_00025)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_48_X, Fix.OHRANTOWER_FLOATINGTILE_48_Y, Fix.OHRANTOWER_FLOATINGTILE_48_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_49_X, Fix.OHRANTOWER_FLOATINGTILE_49_Y, Fix.OHRANTOWER_FLOATINGTILE_49_Z));
      }
      if (One.TF.FieldObject_OhranTower_00026)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_50_X, Fix.OHRANTOWER_FLOATINGTILE_50_Y, Fix.OHRANTOWER_FLOATINGTILE_50_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_51_X, Fix.OHRANTOWER_FLOATINGTILE_51_Y, Fix.OHRANTOWER_FLOATINGTILE_51_Z));
      }
      if (One.TF.FieldObject_OhranTower_00027)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_52_X, Fix.OHRANTOWER_FLOATINGTILE_52_Y, Fix.OHRANTOWER_FLOATINGTILE_52_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_53_X, Fix.OHRANTOWER_FLOATINGTILE_53_Y, Fix.OHRANTOWER_FLOATINGTILE_53_Z));
      }
      if (One.TF.FieldObject_OhranTower_00028)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_54_X, Fix.OHRANTOWER_FLOATINGTILE_54_Y, Fix.OHRANTOWER_FLOATINGTILE_54_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_55_X, Fix.OHRANTOWER_FLOATINGTILE_55_Y, Fix.OHRANTOWER_FLOATINGTILE_55_Z));
      }
      if (One.TF.FieldObject_OhranTower_00029)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_56_X, Fix.OHRANTOWER_FLOATINGTILE_56_Y, Fix.OHRANTOWER_FLOATINGTILE_56_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_57_X, Fix.OHRANTOWER_FLOATINGTILE_57_Y, Fix.OHRANTOWER_FLOATINGTILE_57_Z));
      }
      if (One.TF.FieldObject_OhranTower_00030)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_58_X, Fix.OHRANTOWER_FLOATINGTILE_58_Y, Fix.OHRANTOWER_FLOATINGTILE_58_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_59_X, Fix.OHRANTOWER_FLOATINGTILE_59_Y, Fix.OHRANTOWER_FLOATINGTILE_59_Z));
      }
      if (One.TF.FieldObject_OhranTower_00031 && One.TF.FieldObject_OhranTower_00032 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_60_X, Fix.OHRANTOWER_FLOATINGTILE_60_Y, Fix.OHRANTOWER_FLOATINGTILE_60_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_61_X, Fix.OHRANTOWER_FLOATINGTILE_61_Y, Fix.OHRANTOWER_FLOATINGTILE_61_Z));
      }
      if (One.TF.FieldObject_OhranTower_00032)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_60_X, Fix.OHRANTOWER_FLOATINGTILE_60_Y, Fix.OHRANTOWER_FLOATINGTILE_60_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_62_X, Fix.OHRANTOWER_FLOATINGTILE_62_Y, Fix.OHRANTOWER_FLOATINGTILE_62_Z));
      }
      if (One.TF.FieldObject_OhranTower_00033)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_63_X, Fix.OHRANTOWER_FLOATINGTILE_63_Y, Fix.OHRANTOWER_FLOATINGTILE_63_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_64_X, Fix.OHRANTOWER_FLOATINGTILE_64_Y, Fix.OHRANTOWER_FLOATINGTILE_64_Z));
      }
      if (One.TF.FieldObject_OhranTower_00034)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_65_X, Fix.OHRANTOWER_FLOATINGTILE_65_Y, Fix.OHRANTOWER_FLOATINGTILE_65_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_66_X, Fix.OHRANTOWER_FLOATINGTILE_66_Y, Fix.OHRANTOWER_FLOATINGTILE_66_Z));
      }
      if (One.TF.FieldObject_OhranTower_00035)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_67_X, Fix.OHRANTOWER_FLOATINGTILE_67_Y, Fix.OHRANTOWER_FLOATINGTILE_67_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_68_X, Fix.OHRANTOWER_FLOATINGTILE_68_Y, Fix.OHRANTOWER_FLOATINGTILE_68_Z));
      }
      if (One.TF.FieldObject_OhranTower_00036)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_69_X, Fix.OHRANTOWER_FLOATINGTILE_69_Y, Fix.OHRANTOWER_FLOATINGTILE_69_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_70_X, Fix.OHRANTOWER_FLOATINGTILE_70_Y, Fix.OHRANTOWER_FLOATINGTILE_70_Z));
      }
      if (One.TF.FieldObject_OhranTower_00037)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_71_X, Fix.OHRANTOWER_FLOATINGTILE_71_Y, Fix.OHRANTOWER_FLOATINGTILE_71_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_72_X, Fix.OHRANTOWER_FLOATINGTILE_72_Y, Fix.OHRANTOWER_FLOATINGTILE_72_Z));
      }
      if (One.TF.FieldObject_OhranTower_00038 && One.TF.FieldObject_OhranTower_00039 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_73_X, Fix.OHRANTOWER_FLOATINGTILE_73_Y, Fix.OHRANTOWER_FLOATINGTILE_73_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_74_X, Fix.OHRANTOWER_FLOATINGTILE_74_Y, Fix.OHRANTOWER_FLOATINGTILE_74_Z));
      }
      if (One.TF.FieldObject_OhranTower_00039 && One.TF.FieldObject_OhranTower_00040 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_73_X, Fix.OHRANTOWER_FLOATINGTILE_73_Y, Fix.OHRANTOWER_FLOATINGTILE_73_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_75_X, Fix.OHRANTOWER_FLOATINGTILE_75_Y, Fix.OHRANTOWER_FLOATINGTILE_75_Z));
      }
      if (One.TF.FieldObject_OhranTower_00040 && One.TF.FieldObject_OhranTower_00041 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_73_X, Fix.OHRANTOWER_FLOATINGTILE_73_Y, Fix.OHRANTOWER_FLOATINGTILE_73_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_76_X, Fix.OHRANTOWER_FLOATINGTILE_76_Y, Fix.OHRANTOWER_FLOATINGTILE_76_Z));
      }
      if (One.TF.FieldObject_OhranTower_00041 && One.TF.FieldObject_OhranTower_00042 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_73_X, Fix.OHRANTOWER_FLOATINGTILE_73_Y, Fix.OHRANTOWER_FLOATINGTILE_73_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_77_X, Fix.OHRANTOWER_FLOATINGTILE_77_Y, Fix.OHRANTOWER_FLOATINGTILE_77_Z));
      }
      if (One.TF.FieldObject_OhranTower_00042)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_73_X, Fix.OHRANTOWER_FLOATINGTILE_73_Y, Fix.OHRANTOWER_FLOATINGTILE_73_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_78_X, Fix.OHRANTOWER_FLOATINGTILE_78_Y, Fix.OHRANTOWER_FLOATINGTILE_78_Z));
      }
      if (One.TF.FieldObject_OhranTower_00043)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_79_X, Fix.OHRANTOWER_FLOATINGTILE_79_Y, Fix.OHRANTOWER_FLOATINGTILE_79_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_80_X, Fix.OHRANTOWER_FLOATINGTILE_80_Y, Fix.OHRANTOWER_FLOATINGTILE_80_Z));
      }
      if (One.TF.FieldObject_OhranTower_00044)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_81_X, Fix.OHRANTOWER_FLOATINGTILE_81_Y, Fix.OHRANTOWER_FLOATINGTILE_81_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_82_X, Fix.OHRANTOWER_FLOATINGTILE_82_Y, Fix.OHRANTOWER_FLOATINGTILE_82_Z));
      }
      if (One.TF.FieldObject_OhranTower_00045)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_83_X, Fix.OHRANTOWER_FLOATINGTILE_83_Y, Fix.OHRANTOWER_FLOATINGTILE_83_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_84_X, Fix.OHRANTOWER_FLOATINGTILE_84_Y, Fix.OHRANTOWER_FLOATINGTILE_84_Z));
      }
      if (One.TF.FieldObject_OhranTower_00046)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_85_X, Fix.OHRANTOWER_FLOATINGTILE_85_Y, Fix.OHRANTOWER_FLOATINGTILE_85_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_86_X, Fix.OHRANTOWER_FLOATINGTILE_86_Y, Fix.OHRANTOWER_FLOATINGTILE_86_Z));
      }
      if (One.TF.FieldObject_OhranTower_00047)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_87_X, Fix.OHRANTOWER_FLOATINGTILE_87_Y, Fix.OHRANTOWER_FLOATINGTILE_87_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_88_X, Fix.OHRANTOWER_FLOATINGTILE_88_Y, Fix.OHRANTOWER_FLOATINGTILE_88_Z));
      }
      if (One.TF.FieldObject_OhranTower_00048)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_89_X, Fix.OHRANTOWER_FLOATINGTILE_89_Y, Fix.OHRANTOWER_FLOATINGTILE_89_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_90_X, Fix.OHRANTOWER_FLOATINGTILE_90_Y, Fix.OHRANTOWER_FLOATINGTILE_90_Z));
      }
      if (One.TF.FieldObject_OhranTower_00049 && One.TF.FieldObject_OhranTower_00050 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_91_X, Fix.OHRANTOWER_FLOATINGTILE_91_Y, Fix.OHRANTOWER_FLOATINGTILE_91_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_92_X, Fix.OHRANTOWER_FLOATINGTILE_92_Y, Fix.OHRANTOWER_FLOATINGTILE_92_Z));
      }
      if (One.TF.FieldObject_OhranTower_00050 && One.TF.FieldObject_OhranTower_00051 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_91_X, Fix.OHRANTOWER_FLOATINGTILE_91_Y, Fix.OHRANTOWER_FLOATINGTILE_91_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_93_X, Fix.OHRANTOWER_FLOATINGTILE_93_Y, Fix.OHRANTOWER_FLOATINGTILE_93_Z));
      }
      if (One.TF.FieldObject_OhranTower_00051 && One.TF.FieldObject_OhranTower_00052 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_91_X, Fix.OHRANTOWER_FLOATINGTILE_91_Y, Fix.OHRANTOWER_FLOATINGTILE_91_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_94_X, Fix.OHRANTOWER_FLOATINGTILE_94_Y, Fix.OHRANTOWER_FLOATINGTILE_94_Z));
      }
      if (One.TF.FieldObject_OhranTower_00052)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_91_X, Fix.OHRANTOWER_FLOATINGTILE_91_Y, Fix.OHRANTOWER_FLOATINGTILE_91_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_95_X, Fix.OHRANTOWER_FLOATINGTILE_95_Y, Fix.OHRANTOWER_FLOATINGTILE_95_Z));
      }
      if (One.TF.FieldObject_OhranTower_00053 && One.TF.FieldObject_OhranTower_00054 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_96_X, Fix.OHRANTOWER_FLOATINGTILE_96_Y, Fix.OHRANTOWER_FLOATINGTILE_96_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_97_X, Fix.OHRANTOWER_FLOATINGTILE_97_Y, Fix.OHRANTOWER_FLOATINGTILE_97_Z));
      }
      if (One.TF.FieldObject_OhranTower_00054 && One.TF.FieldObject_OhranTower_00055 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_96_X, Fix.OHRANTOWER_FLOATINGTILE_96_Y, Fix.OHRANTOWER_FLOATINGTILE_96_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_98_X, Fix.OHRANTOWER_FLOATINGTILE_98_Y, Fix.OHRANTOWER_FLOATINGTILE_98_Z));
      }
      if (One.TF.FieldObject_OhranTower_00055 && One.TF.FieldObject_OhranTower_00056 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_96_X, Fix.OHRANTOWER_FLOATINGTILE_96_Y, Fix.OHRANTOWER_FLOATINGTILE_96_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_99_X, Fix.OHRANTOWER_FLOATINGTILE_99_Y, Fix.OHRANTOWER_FLOATINGTILE_99_Z));
      }
      if (One.TF.FieldObject_OhranTower_00056 && One.TF.FieldObject_OhranTower_00057 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_96_X, Fix.OHRANTOWER_FLOATINGTILE_96_Y, Fix.OHRANTOWER_FLOATINGTILE_96_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_100_X, Fix.OHRANTOWER_FLOATINGTILE_100_Y, Fix.OHRANTOWER_FLOATINGTILE_100_Z));
      }
      if (One.TF.FieldObject_OhranTower_00057 && One.TF.FieldObject_OhranTower_00058 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_96_X, Fix.OHRANTOWER_FLOATINGTILE_96_Y, Fix.OHRANTOWER_FLOATINGTILE_96_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_101_X, Fix.OHRANTOWER_FLOATINGTILE_101_Y, Fix.OHRANTOWER_FLOATINGTILE_101_Z));
      }
      if (One.TF.FieldObject_OhranTower_00058 && One.TF.FieldObject_OhranTower_00059 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_96_X, Fix.OHRANTOWER_FLOATINGTILE_96_Y, Fix.OHRANTOWER_FLOATINGTILE_96_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_102_X, Fix.OHRANTOWER_FLOATINGTILE_102_Y, Fix.OHRANTOWER_FLOATINGTILE_102_Z));
      }
      if (One.TF.FieldObject_OhranTower_00059 && One.TF.FieldObject_OhranTower_00060 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_96_X, Fix.OHRANTOWER_FLOATINGTILE_96_Y, Fix.OHRANTOWER_FLOATINGTILE_96_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_103_X, Fix.OHRANTOWER_FLOATINGTILE_103_Y, Fix.OHRANTOWER_FLOATINGTILE_103_Z));
      }
      if (One.TF.FieldObject_OhranTower_00060)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_96_X, Fix.OHRANTOWER_FLOATINGTILE_96_Y, Fix.OHRANTOWER_FLOATINGTILE_96_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_104_X, Fix.OHRANTOWER_FLOATINGTILE_104_Y, Fix.OHRANTOWER_FLOATINGTILE_104_Z));
      }
      if (One.TF.FieldObject_OhranTower_00061)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_105_X, Fix.OHRANTOWER_FLOATINGTILE_105_Y, Fix.OHRANTOWER_FLOATINGTILE_105_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_106_X, Fix.OHRANTOWER_FLOATINGTILE_106_Y, Fix.OHRANTOWER_FLOATINGTILE_106_Z));
      }
      if (One.TF.FieldObject_OhranTower_00062 && One.TF.FieldObject_OhranTower_00063 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_108_X, Fix.OHRANTOWER_FLOATINGTILE_108_Y, Fix.OHRANTOWER_FLOATINGTILE_108_Z));
      }
      if (One.TF.FieldObject_OhranTower_00063 && One.TF.FieldObject_OhranTower_00064 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_109_X, Fix.OHRANTOWER_FLOATINGTILE_109_Y, Fix.OHRANTOWER_FLOATINGTILE_109_Z));
      }
      if (One.TF.FieldObject_OhranTower_00064 && One.TF.FieldObject_OhranTower_00065 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_110_X, Fix.OHRANTOWER_FLOATINGTILE_110_Y, Fix.OHRANTOWER_FLOATINGTILE_110_Z));
      }
      if (One.TF.FieldObject_OhranTower_00065 && One.TF.FieldObject_OhranTower_00066 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_111_X, Fix.OHRANTOWER_FLOATINGTILE_111_Y, Fix.OHRANTOWER_FLOATINGTILE_111_Z));
      }
      if (One.TF.FieldObject_OhranTower_00066 && One.TF.FieldObject_OhranTower_00067 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_112_X, Fix.OHRANTOWER_FLOATINGTILE_112_Y, Fix.OHRANTOWER_FLOATINGTILE_112_Z));
      }
      if (One.TF.FieldObject_OhranTower_00067 && One.TF.FieldObject_OhranTower_00068 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_113_X, Fix.OHRANTOWER_FLOATINGTILE_113_Y, Fix.OHRANTOWER_FLOATINGTILE_113_Z));
      }
      if (One.TF.FieldObject_OhranTower_00068 && One.TF.FieldObject_OhranTower_00069 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_114_X, Fix.OHRANTOWER_FLOATINGTILE_114_Y, Fix.OHRANTOWER_FLOATINGTILE_114_Z));
      }
      if (One.TF.FieldObject_OhranTower_00069 && One.TF.FieldObject_OhranTower_00070 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_115_X, Fix.OHRANTOWER_FLOATINGTILE_115_Y, Fix.OHRANTOWER_FLOATINGTILE_115_Z));
      }
      if (One.TF.FieldObject_OhranTower_00070 && One.TF.FieldObject_OhranTower_00071 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_116_X, Fix.OHRANTOWER_FLOATINGTILE_116_Y, Fix.OHRANTOWER_FLOATINGTILE_116_Z));
      }
      if (One.TF.FieldObject_OhranTower_00071 && One.TF.FieldObject_OhranTower_00072 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_117_X, Fix.OHRANTOWER_FLOATINGTILE_117_Y, Fix.OHRANTOWER_FLOATINGTILE_117_Z));
      }
      if (One.TF.FieldObject_OhranTower_00072 && One.TF.FieldObject_OhranTower_00073 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_118_X, Fix.OHRANTOWER_FLOATINGTILE_118_Y, Fix.OHRANTOWER_FLOATINGTILE_118_Z));
      }
      if (One.TF.FieldObject_OhranTower_00073 && One.TF.FieldObject_OhranTower_00074 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_119_X, Fix.OHRANTOWER_FLOATINGTILE_119_Y, Fix.OHRANTOWER_FLOATINGTILE_119_Z));
      }
      if (One.TF.FieldObject_OhranTower_00074 && One.TF.FieldObject_OhranTower_00075 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_120_X, Fix.OHRANTOWER_FLOATINGTILE_120_Y, Fix.OHRANTOWER_FLOATINGTILE_120_Z));
      }
      if (One.TF.FieldObject_OhranTower_00075 && One.TF.FieldObject_OhranTower_00076 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_121_X, Fix.OHRANTOWER_FLOATINGTILE_121_Y, Fix.OHRANTOWER_FLOATINGTILE_121_Z));
      }
      if (One.TF.FieldObject_OhranTower_00076 && One.TF.FieldObject_OhranTower_00077 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_122_X, Fix.OHRANTOWER_FLOATINGTILE_122_Y, Fix.OHRANTOWER_FLOATINGTILE_122_Z));
      }
      if (One.TF.FieldObject_OhranTower_00077 && One.TF.FieldObject_OhranTower_00078 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_123_X, Fix.OHRANTOWER_FLOATINGTILE_123_Y, Fix.OHRANTOWER_FLOATINGTILE_123_Z));
      }
      if (One.TF.FieldObject_OhranTower_00078 && One.TF.FieldObject_OhranTower_00079 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_124_X, Fix.OHRANTOWER_FLOATINGTILE_124_Y, Fix.OHRANTOWER_FLOATINGTILE_124_Z));
      }
      if (One.TF.FieldObject_OhranTower_00079 && One.TF.FieldObject_OhranTower_00080 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_125_X, Fix.OHRANTOWER_FLOATINGTILE_125_Y, Fix.OHRANTOWER_FLOATINGTILE_125_Z));
      }
      if (One.TF.FieldObject_OhranTower_00080)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_107_X, Fix.OHRANTOWER_FLOATINGTILE_107_Y, Fix.OHRANTOWER_FLOATINGTILE_107_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_126_X, Fix.OHRANTOWER_FLOATINGTILE_126_Y, Fix.OHRANTOWER_FLOATINGTILE_126_Z));
      }
      if (One.TF.FieldObject_OhranTower_00081)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_127_X, Fix.OHRANTOWER_FLOATINGTILE_127_Y, Fix.OHRANTOWER_FLOATINGTILE_127_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_128_X, Fix.OHRANTOWER_FLOATINGTILE_128_Y, Fix.OHRANTOWER_FLOATINGTILE_128_Z));
      }
      if (One.TF.FieldObject_OhranTower_00082 && One.TF.FieldObject_OhranTower_00083 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_129_X, Fix.OHRANTOWER_FLOATINGTILE_129_Y, Fix.OHRANTOWER_FLOATINGTILE_129_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_130_X, Fix.OHRANTOWER_FLOATINGTILE_130_Y, Fix.OHRANTOWER_FLOATINGTILE_130_Z));
      }
      if (One.TF.FieldObject_OhranTower_00083 && One.TF.FieldObject_OhranTower_00084 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_129_X, Fix.OHRANTOWER_FLOATINGTILE_129_Y, Fix.OHRANTOWER_FLOATINGTILE_129_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_131_X, Fix.OHRANTOWER_FLOATINGTILE_131_Y, Fix.OHRANTOWER_FLOATINGTILE_131_Z));
      }
      if (One.TF.FieldObject_OhranTower_00084 && One.TF.FieldObject_OhranTower_00085 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_129_X, Fix.OHRANTOWER_FLOATINGTILE_129_Y, Fix.OHRANTOWER_FLOATINGTILE_129_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_132_X, Fix.OHRANTOWER_FLOATINGTILE_132_Y, Fix.OHRANTOWER_FLOATINGTILE_132_Z));
      }
      if (One.TF.FieldObject_OhranTower_00085 && One.TF.FieldObject_OhranTower_00086 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_129_X, Fix.OHRANTOWER_FLOATINGTILE_129_Y, Fix.OHRANTOWER_FLOATINGTILE_129_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_133_X, Fix.OHRANTOWER_FLOATINGTILE_133_Y, Fix.OHRANTOWER_FLOATINGTILE_133_Z));
      }
      if (One.TF.FieldObject_OhranTower_00086 && One.TF.FieldObject_OhranTower_00087 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_129_X, Fix.OHRANTOWER_FLOATINGTILE_129_Y, Fix.OHRANTOWER_FLOATINGTILE_129_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_134_X, Fix.OHRANTOWER_FLOATINGTILE_134_Y, Fix.OHRANTOWER_FLOATINGTILE_134_Z));
      }
      if (One.TF.FieldObject_OhranTower_00087)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_129_X, Fix.OHRANTOWER_FLOATINGTILE_129_Y, Fix.OHRANTOWER_FLOATINGTILE_129_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_135_X, Fix.OHRANTOWER_FLOATINGTILE_135_Y, Fix.OHRANTOWER_FLOATINGTILE_135_Z));
      }
      if (One.TF.FieldObject_OhranTower_00088)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_136_X, Fix.OHRANTOWER_FLOATINGTILE_136_Y, Fix.OHRANTOWER_FLOATINGTILE_136_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_137_X, Fix.OHRANTOWER_FLOATINGTILE_137_Y, Fix.OHRANTOWER_FLOATINGTILE_137_Z));
      }
      if (One.TF.FieldObject_OhranTower_00089)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_138_X, Fix.OHRANTOWER_FLOATINGTILE_138_Y, Fix.OHRANTOWER_FLOATINGTILE_138_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_139_X, Fix.OHRANTOWER_FLOATINGTILE_139_Y, Fix.OHRANTOWER_FLOATINGTILE_139_Z));
      }
      if (One.TF.FieldObject_OhranTower_00090)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_140_X, Fix.OHRANTOWER_FLOATINGTILE_140_Y, Fix.OHRANTOWER_FLOATINGTILE_140_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_141_X, Fix.OHRANTOWER_FLOATINGTILE_141_Y, Fix.OHRANTOWER_FLOATINGTILE_141_Z));
      }
      if (One.TF.FieldObject_OhranTower_00091)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_142_X, Fix.OHRANTOWER_FLOATINGTILE_142_Y, Fix.OHRANTOWER_FLOATINGTILE_142_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_143_X, Fix.OHRANTOWER_FLOATINGTILE_143_Y, Fix.OHRANTOWER_FLOATINGTILE_143_Z));
      }
      if (One.TF.FieldObject_OhranTower_00092 && One.TF.FieldObject_OhranTower_00093 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_145_X, Fix.OHRANTOWER_FLOATINGTILE_145_Y, Fix.OHRANTOWER_FLOATINGTILE_145_Z));
      }
      if (One.TF.FieldObject_OhranTower_00093 && One.TF.FieldObject_OhranTower_00094 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_146_X, Fix.OHRANTOWER_FLOATINGTILE_146_Y, Fix.OHRANTOWER_FLOATINGTILE_146_Z));
      }
      if (One.TF.FieldObject_OhranTower_00094 && One.TF.FieldObject_OhranTower_00095 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_147_X, Fix.OHRANTOWER_FLOATINGTILE_147_Y, Fix.OHRANTOWER_FLOATINGTILE_147_Z));
      }
      if (One.TF.FieldObject_OhranTower_00095 && One.TF.FieldObject_OhranTower_00096 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_148_X, Fix.OHRANTOWER_FLOATINGTILE_148_Y, Fix.OHRANTOWER_FLOATINGTILE_148_Z));
      }
      if (One.TF.FieldObject_OhranTower_00096 && One.TF.FieldObject_OhranTower_00097 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_149_X, Fix.OHRANTOWER_FLOATINGTILE_149_Y, Fix.OHRANTOWER_FLOATINGTILE_149_Z));
      }
      if (One.TF.FieldObject_OhranTower_00097 && One.TF.FieldObject_OhranTower_00098 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_150_X, Fix.OHRANTOWER_FLOATINGTILE_150_Y, Fix.OHRANTOWER_FLOATINGTILE_150_Z));
      }
      if (One.TF.FieldObject_OhranTower_00098 && One.TF.FieldObject_OhranTower_00099 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_151_X, Fix.OHRANTOWER_FLOATINGTILE_151_Y, Fix.OHRANTOWER_FLOATINGTILE_151_Z));
      }
      if (One.TF.FieldObject_OhranTower_00099 && One.TF.FieldObject_OhranTower_00100 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_152_X, Fix.OHRANTOWER_FLOATINGTILE_152_Y, Fix.OHRANTOWER_FLOATINGTILE_152_Z));
      }
      if (One.TF.FieldObject_OhranTower_00100 && One.TF.FieldObject_OhranTower_00101 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_153_X, Fix.OHRANTOWER_FLOATINGTILE_153_Y, Fix.OHRANTOWER_FLOATINGTILE_153_Z));
      }
      if (One.TF.FieldObject_OhranTower_00101 && One.TF.FieldObject_OhranTower_00102 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_154_X, Fix.OHRANTOWER_FLOATINGTILE_154_Y, Fix.OHRANTOWER_FLOATINGTILE_154_Z));
      }
      if (One.TF.FieldObject_OhranTower_00102)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_144_X, Fix.OHRANTOWER_FLOATINGTILE_144_Y, Fix.OHRANTOWER_FLOATINGTILE_144_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_155_X, Fix.OHRANTOWER_FLOATINGTILE_155_Y, Fix.OHRANTOWER_FLOATINGTILE_155_Z));
      }
      if (One.TF.FieldObject_OhranTower_00103 && One.TF.FieldObject_OhranTower_00104 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_156_X, Fix.OHRANTOWER_FLOATINGTILE_156_Y, Fix.OHRANTOWER_FLOATINGTILE_156_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_157_X, Fix.OHRANTOWER_FLOATINGTILE_157_Y, Fix.OHRANTOWER_FLOATINGTILE_157_Z));
      }
      if (One.TF.FieldObject_OhranTower_00104 && One.TF.FieldObject_OhranTower_00105 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_156_X, Fix.OHRANTOWER_FLOATINGTILE_156_Y, Fix.OHRANTOWER_FLOATINGTILE_156_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_158_X, Fix.OHRANTOWER_FLOATINGTILE_158_Y, Fix.OHRANTOWER_FLOATINGTILE_158_Z));
      }
      if (One.TF.FieldObject_OhranTower_00105 && One.TF.FieldObject_OhranTower_00106 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_156_X, Fix.OHRANTOWER_FLOATINGTILE_156_Y, Fix.OHRANTOWER_FLOATINGTILE_156_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_159_X, Fix.OHRANTOWER_FLOATINGTILE_159_Y, Fix.OHRANTOWER_FLOATINGTILE_159_Z));
      }
      if (One.TF.FieldObject_OhranTower_00106 && One.TF.FieldObject_OhranTower_00107 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_156_X, Fix.OHRANTOWER_FLOATINGTILE_156_Y, Fix.OHRANTOWER_FLOATINGTILE_156_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_160_X, Fix.OHRANTOWER_FLOATINGTILE_160_Y, Fix.OHRANTOWER_FLOATINGTILE_160_Z));
      }
      if (One.TF.FieldObject_OhranTower_00107 && One.TF.FieldObject_OhranTower_00108 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_156_X, Fix.OHRANTOWER_FLOATINGTILE_156_Y, Fix.OHRANTOWER_FLOATINGTILE_156_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_161_X, Fix.OHRANTOWER_FLOATINGTILE_161_Y, Fix.OHRANTOWER_FLOATINGTILE_161_Z));
      }
      if (One.TF.FieldObject_OhranTower_00108 && One.TF.FieldObject_OhranTower_00109 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_156_X, Fix.OHRANTOWER_FLOATINGTILE_156_Y, Fix.OHRANTOWER_FLOATINGTILE_156_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_162_X, Fix.OHRANTOWER_FLOATINGTILE_162_Y, Fix.OHRANTOWER_FLOATINGTILE_162_Z));
      }
      if (One.TF.FieldObject_OhranTower_00109)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_156_X, Fix.OHRANTOWER_FLOATINGTILE_156_Y, Fix.OHRANTOWER_FLOATINGTILE_156_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_163_X, Fix.OHRANTOWER_FLOATINGTILE_163_Y, Fix.OHRANTOWER_FLOATINGTILE_163_Z));
      }
      if (One.TF.FieldObject_OhranTower_00110)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_164_X, Fix.OHRANTOWER_FLOATINGTILE_164_Y, Fix.OHRANTOWER_FLOATINGTILE_164_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_165_X, Fix.OHRANTOWER_FLOATINGTILE_165_Y, Fix.OHRANTOWER_FLOATINGTILE_165_Z));
      }
      if (One.TF.FieldObject_OhranTower_00111 && One.TF.FieldObject_OhranTower_00112 == false) 
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_166_X, Fix.OHRANTOWER_FLOATINGTILE_166_Y, Fix.OHRANTOWER_FLOATINGTILE_166_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_167_X, Fix.OHRANTOWER_FLOATINGTILE_167_Y, Fix.OHRANTOWER_FLOATINGTILE_167_Z));
      }
      if (One.TF.FieldObject_OhranTower_00112 && One.TF.FieldObject_OhranTower_00113 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_166_X, Fix.OHRANTOWER_FLOATINGTILE_166_Y, Fix.OHRANTOWER_FLOATINGTILE_166_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_168_X, Fix.OHRANTOWER_FLOATINGTILE_168_Y, Fix.OHRANTOWER_FLOATINGTILE_168_Z));
      }
      if (One.TF.FieldObject_OhranTower_00113 && One.TF.FieldObject_OhranTower_00114 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_166_X, Fix.OHRANTOWER_FLOATINGTILE_166_Y, Fix.OHRANTOWER_FLOATINGTILE_166_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_169_X, Fix.OHRANTOWER_FLOATINGTILE_169_Y, Fix.OHRANTOWER_FLOATINGTILE_169_Z));
      }
      if (One.TF.FieldObject_OhranTower_00114 && One.TF.FieldObject_OhranTower_00115 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_166_X, Fix.OHRANTOWER_FLOATINGTILE_166_Y, Fix.OHRANTOWER_FLOATINGTILE_166_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_170_X, Fix.OHRANTOWER_FLOATINGTILE_170_Y, Fix.OHRANTOWER_FLOATINGTILE_170_Z));
      }
      if (One.TF.FieldObject_OhranTower_00115 && One.TF.FieldObject_OhranTower_00116 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_166_X, Fix.OHRANTOWER_FLOATINGTILE_166_Y, Fix.OHRANTOWER_FLOATINGTILE_166_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_171_X, Fix.OHRANTOWER_FLOATINGTILE_171_Y, Fix.OHRANTOWER_FLOATINGTILE_171_Z));
      }
      if (One.TF.FieldObject_OhranTower_00116)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_166_X, Fix.OHRANTOWER_FLOATINGTILE_166_Y, Fix.OHRANTOWER_FLOATINGTILE_166_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_172_X, Fix.OHRANTOWER_FLOATINGTILE_172_Y, Fix.OHRANTOWER_FLOATINGTILE_172_Z));
      }
      if (One.TF.FieldObject_OhranTower_00117)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_173_X, Fix.OHRANTOWER_FLOATINGTILE_173_Y, Fix.OHRANTOWER_FLOATINGTILE_173_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_174_X, Fix.OHRANTOWER_FLOATINGTILE_174_Y, Fix.OHRANTOWER_FLOATINGTILE_174_Z));
      }
      if (One.TF.FieldObject_OhranTower_00118 && One.TF.FieldObject_OhranTower_00119 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_175_X, Fix.OHRANTOWER_FLOATINGTILE_175_Y, Fix.OHRANTOWER_FLOATINGTILE_175_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_176_X, Fix.OHRANTOWER_FLOATINGTILE_176_Y, Fix.OHRANTOWER_FLOATINGTILE_176_Z));
      }
      if (One.TF.FieldObject_OhranTower_00119)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_175_X, Fix.OHRANTOWER_FLOATINGTILE_175_Y, Fix.OHRANTOWER_FLOATINGTILE_175_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_177_X, Fix.OHRANTOWER_FLOATINGTILE_177_Y, Fix.OHRANTOWER_FLOATINGTILE_177_Z));
      }
      if (One.TF.FieldObject_OhranTower_00120)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_178_X, Fix.OHRANTOWER_FLOATINGTILE_178_Y, Fix.OHRANTOWER_FLOATINGTILE_178_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_179_X, Fix.OHRANTOWER_FLOATINGTILE_179_Y, Fix.OHRANTOWER_FLOATINGTILE_179_Z));
      }
      if (One.TF.FieldObject_OhranTower_00121 && One.TF.FieldObject_OhranTower_00122 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_180_X, Fix.OHRANTOWER_FLOATINGTILE_180_Y, Fix.OHRANTOWER_FLOATINGTILE_180_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_181_X, Fix.OHRANTOWER_FLOATINGTILE_181_Y, Fix.OHRANTOWER_FLOATINGTILE_181_Z));
      }
      if (One.TF.FieldObject_OhranTower_00122 && One.TF.FieldObject_OhranTower_00123 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_180_X, Fix.OHRANTOWER_FLOATINGTILE_180_Y, Fix.OHRANTOWER_FLOATINGTILE_180_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_182_X, Fix.OHRANTOWER_FLOATINGTILE_182_Y, Fix.OHRANTOWER_FLOATINGTILE_182_Z));
      }
      if (One.TF.FieldObject_OhranTower_00123 && One.TF.FieldObject_OhranTower_00124 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_180_X, Fix.OHRANTOWER_FLOATINGTILE_180_Y, Fix.OHRANTOWER_FLOATINGTILE_180_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_183_X, Fix.OHRANTOWER_FLOATINGTILE_183_Y, Fix.OHRANTOWER_FLOATINGTILE_183_Z));
      }
      if (One.TF.FieldObject_OhranTower_00124)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_180_X, Fix.OHRANTOWER_FLOATINGTILE_180_Y, Fix.OHRANTOWER_FLOATINGTILE_180_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_184_X, Fix.OHRANTOWER_FLOATINGTILE_184_Y, Fix.OHRANTOWER_FLOATINGTILE_184_Z));
      }
      if (One.TF.FieldObject_OhranTower_00125)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_185_X, Fix.OHRANTOWER_FLOATINGTILE_185_Y, Fix.OHRANTOWER_FLOATINGTILE_185_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_186_X, Fix.OHRANTOWER_FLOATINGTILE_186_Y, Fix.OHRANTOWER_FLOATINGTILE_186_Z));
      }
      if (One.TF.FieldObject_OhranTower_00126)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_187_X, Fix.OHRANTOWER_FLOATINGTILE_187_Y, Fix.OHRANTOWER_FLOATINGTILE_187_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_188_X, Fix.OHRANTOWER_FLOATINGTILE_188_Y, Fix.OHRANTOWER_FLOATINGTILE_188_Z));
      }
      if (One.TF.FieldObject_OhranTower_00127)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_189_X, Fix.OHRANTOWER_FLOATINGTILE_189_Y, Fix.OHRANTOWER_FLOATINGTILE_189_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_190_X, Fix.OHRANTOWER_FLOATINGTILE_190_Y, Fix.OHRANTOWER_FLOATINGTILE_190_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_195_X, Fix.OHRANTOWER_FLOATINGTILE_195_Y, Fix.OHRANTOWER_FLOATINGTILE_195_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_196_X, Fix.OHRANTOWER_FLOATINGTILE_196_Y, Fix.OHRANTOWER_FLOATINGTILE_196_Z));
      }
      if (One.TF.FieldObject_OhranTower_00128)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_191_X, Fix.OHRANTOWER_FLOATINGTILE_191_Y, Fix.OHRANTOWER_FLOATINGTILE_191_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_192_X, Fix.OHRANTOWER_FLOATINGTILE_192_Y, Fix.OHRANTOWER_FLOATINGTILE_192_Z));
      }
      if (One.TF.FieldObject_OhranTower_00129)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.OHRANTOWER_FLOATINGTILE_193_X, Fix.OHRANTOWER_FLOATINGTILE_193_Y, Fix.OHRANTOWER_FLOATINGTILE_193_Z), new Vector3(Fix.OHRANTOWER_FLOATINGTILE_194_X, Fix.OHRANTOWER_FLOATINGTILE_194_Y, Fix.OHRANTOWER_FLOATINGTILE_194_Z));
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
      // 宝箱２４
      if (One.TF.Treasure_OhranTower_00024)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_24_X, Fix.OHRANTOWER_Treasure_24_Y, Fix.OHRANTOWER_Treasure_24_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２５
      if (One.TF.Treasure_OhranTower_00025)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_25_X, Fix.OHRANTOWER_Treasure_25_Y, Fix.OHRANTOWER_Treasure_25_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２６
      if (One.TF.Treasure_OhranTower_00026)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_26_X, Fix.OHRANTOWER_Treasure_26_Y, Fix.OHRANTOWER_Treasure_26_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２７
      if (One.TF.Treasure_OhranTower_00027)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_27_X, Fix.OHRANTOWER_Treasure_27_Y, Fix.OHRANTOWER_Treasure_27_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２８
      if (One.TF.Treasure_OhranTower_00028)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_28_X, Fix.OHRANTOWER_Treasure_28_Y, Fix.OHRANTOWER_Treasure_28_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱２９
      if (One.TF.Treasure_OhranTower_00029)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_29_X, Fix.OHRANTOWER_Treasure_29_Y, Fix.OHRANTOWER_Treasure_29_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３０
      if (One.TF.Treasure_OhranTower_00030)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_30_X, Fix.OHRANTOWER_Treasure_30_Y, Fix.OHRANTOWER_Treasure_30_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３１
      if (One.TF.Treasure_OhranTower_00031)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_31_X, Fix.OHRANTOWER_Treasure_31_Y, Fix.OHRANTOWER_Treasure_31_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３２
      if (One.TF.Treasure_OhranTower_00032)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_32_X, Fix.OHRANTOWER_Treasure_32_Y, Fix.OHRANTOWER_Treasure_32_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３３
      if (One.TF.Treasure_OhranTower_00033)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_33_X, Fix.OHRANTOWER_Treasure_33_Y, Fix.OHRANTOWER_Treasure_33_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３４
      if (One.TF.Treasure_OhranTower_00034)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_34_X, Fix.OHRANTOWER_Treasure_34_Y, Fix.OHRANTOWER_Treasure_34_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３５
      if (One.TF.Treasure_OhranTower_00035)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_35_X, Fix.OHRANTOWER_Treasure_35_Y, Fix.OHRANTOWER_Treasure_35_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３６
      if (One.TF.Treasure_OhranTower_00036)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_36_X, Fix.OHRANTOWER_Treasure_36_Y, Fix.OHRANTOWER_Treasure_36_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
      // 宝箱３７
      if (One.TF.Treasure_OhranTower_00037)
      {
        int num = FindFieldObjectIndex(FieldObjList, new Vector3(Fix.OHRANTOWER_Treasure_37_X, Fix.OHRANTOWER_Treasure_37_Y, Fix.OHRANTOWER_Treasure_37_Z));
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
      }
    }
    #endregion
    #region "ヴェルガスの海底神殿"
    if (map_data == Fix.MAPFILE_VELGUS)
    {
      if (One.TF.Treasure_Velgus_00001)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_1_X, Fix.VELGUS_TREASURE_1_Y, Fix.VELGUS_TREASURE_1_Z)));
      }
      if (One.TF.Treasure_Velgus_00002)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_2_X, Fix.VELGUS_TREASURE_2_Y, Fix.VELGUS_TREASURE_2_Z)));
      }
      if (One.TF.Treasure_Velgus_00003)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_3_X, Fix.VELGUS_TREASURE_3_Y, Fix.VELGUS_TREASURE_3_Z)));
      }
      if (One.TF.Treasure_Velgus_00004)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_4_X, Fix.VELGUS_TREASURE_4_Y, Fix.VELGUS_TREASURE_4_Z)));
      }
      if (One.TF.Treasure_Velgus_00005)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_5_X, Fix.VELGUS_TREASURE_5_Y, Fix.VELGUS_TREASURE_5_Z)));
      }
      if (One.TF.Treasure_Velgus_00006)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_6_X, Fix.VELGUS_TREASURE_6_Y, Fix.VELGUS_TREASURE_6_Z)));
      }
      if (One.TF.Treasure_Velgus_00007)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_7_X, Fix.VELGUS_TREASURE_7_Y, Fix.VELGUS_TREASURE_7_Z)));
      }
      if (One.TF.Treasure_Velgus_00008)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_8_X, Fix.VELGUS_TREASURE_8_Y, Fix.VELGUS_TREASURE_8_Z)));
      }
      if (One.TF.Treasure_Velgus_00009)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_9_X, Fix.VELGUS_TREASURE_9_Y, Fix.VELGUS_TREASURE_9_Z)));
      }
      if (One.TF.Treasure_Velgus_00010)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_10_X, Fix.VELGUS_TREASURE_10_Y, Fix.VELGUS_TREASURE_10_Z)));
      }
      if (One.TF.Treasure_Velgus_00011)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_11_X, Fix.VELGUS_TREASURE_11_Y, Fix.VELGUS_TREASURE_11_Z)));
      }
      if (One.TF.Treasure_Velgus_00012)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_12_X, Fix.VELGUS_TREASURE_12_Y, Fix.VELGUS_TREASURE_12_Z)));
      }
      if (One.TF.Treasure_Velgus_00013)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_TREASURE_13_X, Fix.VELGUS_TREASURE_13_Y, Fix.VELGUS_TREASURE_13_Z)));
      }

      // エントランス１の柱
      if (One.TF.Event_Message1000010_MoveWall)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_5_X, Fix.VELGUS_SECRETWALL_5_Y, Fix.VELGUS_SECRETWALL_5_Z), new Vector3(Fix.VELGUS_SECRETWALL_5_2_X, Fix.VELGUS_SECRETWALL_5_2_Y, Fix.VELGUS_SECRETWALL_5_2_Z));
      }

      // 壁ドア
      if (One.TF.Event_Message1000010_Complete)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_6_X, Fix.VELGUS_DOOR_6_Y, Fix.VELGUS_DOOR_6_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_7_X, Fix.VELGUS_DOOR_7_Y, Fix.VELGUS_DOOR_7_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_8_X, Fix.VELGUS_DOOR_8_Y, Fix.VELGUS_DOOR_8_Z));
      }
      if (One.TF.Event_Message1000020_Complete)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_15_X, Fix.VELGUS_DOOR_15_Y, Fix.VELGUS_DOOR_15_Z));
      }
      if (One.TF.Event_Message1000020_2_Complete)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_16_X, Fix.VELGUS_SECRETWALL_16_Y, Fix.VELGUS_SECRETWALL_16_Z));
      }
      if (One.TF.Event_Message1000020_3_Complete)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_18_X, Fix.VELGUS_FAKESEA_18_Y, Fix.VELGUS_FAKESEA_18_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_19_X, Fix.VELGUS_FAKESEA_19_Y, Fix.VELGUS_FAKESEA_19_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_20_X, Fix.VELGUS_FAKESEA_20_Y, Fix.VELGUS_FAKESEA_20_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_21_X, Fix.VELGUS_FAKESEA_21_Y, Fix.VELGUS_FAKESEA_21_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_22_X, Fix.VELGUS_FAKESEA_22_Y, Fix.VELGUS_FAKESEA_22_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FAKESEA_23_X, Fix.VELGUS_FAKESEA_23_Y, Fix.VELGUS_FAKESEA_23_Z));
      }
      if (One.TF.Event_Message1000041)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_25_X, Fix.VELGUS_SECRETWALL_25_Y, Fix.VELGUS_SECRETWALL_25_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_26_X, Fix.VELGUS_DOOR_26_Y, Fix.VELGUS_DOOR_26_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_27_X, Fix.VELGUS_DOOR_27_Y, Fix.VELGUS_DOOR_27_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_28_X, Fix.VELGUS_DOOR_28_Y, Fix.VELGUS_DOOR_28_Z));
      }

      if (One.TF.Event_Message1000040_Complete_1)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_49_X, Fix.VELGUS_SECRETWALL_49_Y, Fix.VELGUS_SECRETWALL_49_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_50_X, Fix.VELGUS_SECRETWALL_50_Y, Fix.VELGUS_SECRETWALL_50_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_51_X, Fix.VELGUS_SECRETWALL_51_Y, Fix.VELGUS_SECRETWALL_51_Z));
      }

      if (One.TF.Event_Message1000040_Complete_2)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_52_X, Fix.VELGUS_SECRETWALL_52_Y, Fix.VELGUS_SECRETWALL_52_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_53_X, Fix.VELGUS_SECRETWALL_53_Y, Fix.VELGUS_SECRETWALL_53_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_54_X, Fix.VELGUS_SECRETWALL_54_Y, Fix.VELGUS_SECRETWALL_54_Z));
      }

      if (One.TF.Event_Message1000040_Complete_3)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_55_X, Fix.VELGUS_SECRETWALL_55_Y, Fix.VELGUS_SECRETWALL_55_Z));
      }

      if (One.TF.Event_Message1000040_Complete_4)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_56_X, Fix.VELGUS_SECRETWALL_56_Y, Fix.VELGUS_SECRETWALL_56_Z));
      }

      if (One.TF.Event_Message1000040_Complete_5)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_58_X, Fix.VELGUS_SECRETWALL_58_Y, Fix.VELGUS_SECRETWALL_58_Z));
      }

      if (One.TF.Event_Message1000040_Complete_6)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_MessageBoard_3_X, Fix.VELGUS_MessageBoard_3_Y, Fix.VELGUS_MessageBoard_3_Z));
      }

      if (One.TF.Event_Message1000040_Complete_7)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_60_X, Fix.VELGUS_SECRETWALL_60_Y, Fix.VELGUS_SECRETWALL_60_Z));
      }

      if (One.TF.Event_Message1000040_Complete_8)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_63_X, Fix.VELGUS_SECRETWALL_63_Y, Fix.VELGUS_SECRETWALL_63_Z));
      }

      if (One.TF.Event_Message1000100_Success)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_86_X, Fix.VELGUS_DOOR_86_Y, Fix.VELGUS_DOOR_86_Z));
      }

      if (One.TF.Event_Message1000110_Success)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_111_X, Fix.VELGUS_DOOR_111_Y, Fix.VELGUS_DOOR_111_Z));
      }

      if (One.TF.Event_Message1000120_Success)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_120_X, Fix.VELGUS_SECRETWALL_120_Y, Fix.VELGUS_SECRETWALL_120_Z));
      }

      if (One.TF.Event_Message1000131 == false)
      {
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_130_X, Fix.VELGUS_SECRETWALL_130_Y, Fix.VELGUS_SECRETWALL_130_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_131_X, Fix.VELGUS_SECRETWALL_131_Y, Fix.VELGUS_SECRETWALL_131_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_132_X, Fix.VELGUS_SECRETWALL_132_Y, Fix.VELGUS_SECRETWALL_132_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_133_X, Fix.VELGUS_SECRETWALL_133_Y, Fix.VELGUS_SECRETWALL_133_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_134_X, Fix.VELGUS_SECRETWALL_134_Y, Fix.VELGUS_SECRETWALL_134_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_135_X, Fix.VELGUS_SECRETWALL_135_Y, Fix.VELGUS_SECRETWALL_135_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_136_X, Fix.VELGUS_SECRETWALL_136_Y, Fix.VELGUS_SECRETWALL_136_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_137_X, Fix.VELGUS_SECRETWALL_137_Y, Fix.VELGUS_SECRETWALL_137_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_138_X, Fix.VELGUS_SECRETWALL_138_Y, Fix.VELGUS_SECRETWALL_138_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_139_X, Fix.VELGUS_SECRETWALL_139_Y, Fix.VELGUS_SECRETWALL_139_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_140_X, Fix.VELGUS_SECRETWALL_140_Y, Fix.VELGUS_SECRETWALL_140_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_141_X, Fix.VELGUS_SECRETWALL_141_Y, Fix.VELGUS_SECRETWALL_141_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_142_X, Fix.VELGUS_SECRETWALL_142_Y, Fix.VELGUS_SECRETWALL_142_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_143_X, Fix.VELGUS_SECRETWALL_143_Y, Fix.VELGUS_SECRETWALL_143_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_144_X, Fix.VELGUS_SECRETWALL_144_Y, Fix.VELGUS_SECRETWALL_144_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_145_X, Fix.VELGUS_SECRETWALL_145_Y, Fix.VELGUS_SECRETWALL_145_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_146_X, Fix.VELGUS_SECRETWALL_146_Y, Fix.VELGUS_SECRETWALL_146_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_147_X, Fix.VELGUS_SECRETWALL_147_Y, Fix.VELGUS_SECRETWALL_147_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_148_X, Fix.VELGUS_SECRETWALL_148_Y, Fix.VELGUS_SECRETWALL_148_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_149_X, Fix.VELGUS_SECRETWALL_149_Y, Fix.VELGUS_SECRETWALL_149_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_150_X, Fix.VELGUS_SECRETWALL_150_Y, Fix.VELGUS_SECRETWALL_150_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_151_X, Fix.VELGUS_SECRETWALL_151_Y, Fix.VELGUS_SECRETWALL_151_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_152_X, Fix.VELGUS_SECRETWALL_152_Y, Fix.VELGUS_SECRETWALL_152_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_153_X, Fix.VELGUS_SECRETWALL_153_Y, Fix.VELGUS_SECRETWALL_153_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_154_X, Fix.VELGUS_SECRETWALL_154_Y, Fix.VELGUS_SECRETWALL_154_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_155_X, Fix.VELGUS_SECRETWALL_155_Y, Fix.VELGUS_SECRETWALL_155_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_156_X, Fix.VELGUS_SECRETWALL_156_Y, Fix.VELGUS_SECRETWALL_156_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_157_X, Fix.VELGUS_SECRETWALL_157_Y, Fix.VELGUS_SECRETWALL_157_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_158_X, Fix.VELGUS_SECRETWALL_158_Y, Fix.VELGUS_SECRETWALL_158_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_159_X, Fix.VELGUS_SECRETWALL_159_Y, Fix.VELGUS_SECRETWALL_159_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_160_X, Fix.VELGUS_SECRETWALL_160_Y, Fix.VELGUS_SECRETWALL_160_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_161_X, Fix.VELGUS_SECRETWALL_161_Y, Fix.VELGUS_SECRETWALL_161_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_162_X, Fix.VELGUS_SECRETWALL_162_Y, Fix.VELGUS_SECRETWALL_162_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_163_X, Fix.VELGUS_SECRETWALL_163_Y, Fix.VELGUS_SECRETWALL_163_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_164_X, Fix.VELGUS_SECRETWALL_164_Y, Fix.VELGUS_SECRETWALL_164_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_165_X, Fix.VELGUS_SECRETWALL_165_Y, Fix.VELGUS_SECRETWALL_165_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_166_X, Fix.VELGUS_SECRETWALL_166_Y, Fix.VELGUS_SECRETWALL_166_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_167_X, Fix.VELGUS_SECRETWALL_167_Y, Fix.VELGUS_SECRETWALL_167_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_168_X, Fix.VELGUS_SECRETWALL_168_Y, Fix.VELGUS_SECRETWALL_168_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_169_X, Fix.VELGUS_SECRETWALL_169_Y, Fix.VELGUS_SECRETWALL_169_Z));
      }

      if (One.TF.Event_Message1000130_Success)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_178_X, Fix.VELGUS_DOOR_178_Y, Fix.VELGUS_DOOR_178_Z));
      }
      if (One.TF.Event_Message1000130_Success_2)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_191_X, Fix.VELGUS_DOOR_191_Y, Fix.VELGUS_DOOR_191_Z));
      }
      if (One.TF.Event_Message1000130_Success_3)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_200_X, Fix.VELGUS_SECRETWALL_200_Y, Fix.VELGUS_SECRETWALL_200_Z));
      }

      // ヴェルガスの海底神殿：４つの球体は条件に応じて表示位置が変わる
      if (One.TF.Event_Message1000130_Success && One.TF.Event_Message1000130_Success_2 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLRED_170_X, Fix.VELGUS_BALLRED_170_Y, Fix.VELGUS_BALLRED_170_Z), new Vector3(Fix.VELGUS_BALLREDGOAL_174_X, Fix.VELGUS_BALLREDGOAL_174_Y, Fix.VELGUS_BALLREDGOAL_174_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLBLUE_171_X, Fix.VELGUS_BALLBLUE_171_Y, Fix.VELGUS_BALLBLUE_171_Z), new Vector3(Fix.VELGUS_BALLBLUEGOAL_175_X, Fix.VELGUS_BALLBLUEGOAL_175_Y, Fix.VELGUS_BALLBLUEGOAL_175_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLGREEN_172_X, Fix.VELGUS_BALLGREEN_172_Y, Fix.VELGUS_BALLGREEN_172_Z), new Vector3(Fix.VELGUS_BALLGREENGOAL_176_X, Fix.VELGUS_BALLGREENGOAL_176_Y, Fix.VELGUS_BALLGREENGOAL_176_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLYELLOW_173_X, Fix.VELGUS_BALLYELLOW_173_Y, Fix.VELGUS_BALLYELLOW_173_Z), new Vector3(Fix.VELGUS_BALLYELLOWGOAL_177_X, Fix.VELGUS_BALLYELLOWGOAL_177_Y, Fix.VELGUS_BALLYELLOWGOAL_177_Z));
      }
      else if (One.TF.Event_Message1000130_Success && One.TF.Event_Message1000130_Success_2 && One.TF.Event_Message1000130_Success_3 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLRED_170_X, Fix.VELGUS_BALLRED_170_Y, Fix.VELGUS_BALLRED_170_Z), new Vector3(Fix.VELGUS_BALLREDGOAL2_187_X, Fix.VELGUS_BALLREDGOAL2_187_Y, Fix.VELGUS_BALLREDGOAL2_187_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLBLUE_171_X, Fix.VELGUS_BALLBLUE_171_Y, Fix.VELGUS_BALLBLUE_171_Z), new Vector3(Fix.VELGUS_BALLBLUEGOAL2_188_X, Fix.VELGUS_BALLBLUEGOAL2_188_Y, Fix.VELGUS_BALLBLUEGOAL2_188_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLGREEN_172_X, Fix.VELGUS_BALLGREEN_172_Y, Fix.VELGUS_BALLGREEN_172_Z), new Vector3(Fix.VELGUS_BALLGREENGOAL2_189_X, Fix.VELGUS_BALLGREENGOAL2_189_Y, Fix.VELGUS_BALLGREENGOAL2_189_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLYELLOW_173_X, Fix.VELGUS_BALLYELLOW_173_Y, Fix.VELGUS_BALLYELLOW_173_Z), new Vector3(Fix.VELGUS_BALLYELLOWGOAL2_190_X, Fix.VELGUS_BALLYELLOWGOAL2_190_Y, Fix.VELGUS_BALLYELLOWGOAL2_190_Z));
      }
      else if (One.TF.Event_Message1000130_Success && One.TF.Event_Message1000130_Success_2 && One.TF.Event_Message1000130_Success_3)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLRED_170_X, Fix.VELGUS_BALLRED_170_Y, Fix.VELGUS_BALLRED_170_Z), new Vector3(Fix.VELGUS_BALLREDGOAL3_196_X, Fix.VELGUS_BALLREDGOAL3_196_Y, Fix.VELGUS_BALLREDGOAL3_196_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLBLUE_171_X, Fix.VELGUS_BALLBLUE_171_Y, Fix.VELGUS_BALLBLUE_171_Z), new Vector3(Fix.VELGUS_BALLBLUEGOAL3_197_X, Fix.VELGUS_BALLBLUEGOAL3_197_Y, Fix.VELGUS_BALLBLUEGOAL3_197_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLGREEN_172_X, Fix.VELGUS_BALLGREEN_172_Y, Fix.VELGUS_BALLGREEN_172_Z), new Vector3(Fix.VELGUS_BALLGREENGOAL3_198_X, Fix.VELGUS_BALLGREENGOAL3_198_Y, Fix.VELGUS_BALLGREENGOAL3_198_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_BALLYELLOW_173_X, Fix.VELGUS_BALLYELLOW_173_Y, Fix.VELGUS_BALLYELLOW_173_Z), new Vector3(Fix.VELGUS_BALLYELLOWGOAL3_199_X, Fix.VELGUS_BALLYELLOWGOAL3_199_Y, Fix.VELGUS_BALLYELLOWGOAL3_199_Z));
      }

      // ヴェルガスの海底神殿：４つのサークルは条件に応じて表示位置が変わる
      if (One.TF.Event_Message1000130_Success == false)
      {
        // 動かさない
      }
      else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000135 == false)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_RED_179_X, Fix.VELGUS_CIRCLE_RED_179_Y, Fix.VELGUS_CIRCLE_RED_179_Z), new Vector3(Fix.VELGUS_CIRCLE_RED_183_X, Fix.VELGUS_CIRCLE_RED_183_Y, Fix.VELGUS_CIRCLE_RED_183_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_BLUE_180_X, Fix.VELGUS_CIRCLE_BLUE_180_Y, Fix.VELGUS_CIRCLE_BLUE_180_Z), new Vector3(Fix.VELGUS_CIRCLE_BLUE_184_X, Fix.VELGUS_CIRCLE_BLUE_184_Y, Fix.VELGUS_CIRCLE_BLUE_184_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_GREEN_181_X, Fix.VELGUS_CIRCLE_GREEN_181_Y, Fix.VELGUS_CIRCLE_GREEN_181_Z), new Vector3(Fix.VELGUS_CIRCLE_GREEN_185_X, Fix.VELGUS_CIRCLE_GREEN_185_Y, Fix.VELGUS_CIRCLE_GREEN_185_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_YELLOW_182_X, Fix.VELGUS_CIRCLE_YELLOW_182_Y, Fix.VELGUS_CIRCLE_YELLOW_182_Z), new Vector3(Fix.VELGUS_CIRCLE_YELLOW_186_X, Fix.VELGUS_CIRCLE_YELLOW_186_Y, Fix.VELGUS_CIRCLE_YELLOW_186_Z));
      }
      else if (One.TF.Event_Message1000133 && One.TF.Event_Message1000135)
      {
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_RED_179_X, Fix.VELGUS_CIRCLE_RED_179_Y, Fix.VELGUS_CIRCLE_RED_179_Z), new Vector3(Fix.VELGUS_CIRCLE_RED_192_X, Fix.VELGUS_CIRCLE_RED_192_Y, Fix.VELGUS_CIRCLE_RED_192_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_BLUE_180_X, Fix.VELGUS_CIRCLE_BLUE_180_Y, Fix.VELGUS_CIRCLE_BLUE_180_Z), new Vector3(Fix.VELGUS_CIRCLE_BLUE_193_X, Fix.VELGUS_CIRCLE_BLUE_193_Y, Fix.VELGUS_CIRCLE_BLUE_193_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_GREEN_181_X, Fix.VELGUS_CIRCLE_GREEN_181_Y, Fix.VELGUS_CIRCLE_GREEN_181_Z), new Vector3(Fix.VELGUS_CIRCLE_GREEN_194_X, Fix.VELGUS_CIRCLE_GREEN_194_Y, Fix.VELGUS_CIRCLE_GREEN_194_Z));
        MoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_CIRCLE_YELLOW_182_X, Fix.VELGUS_CIRCLE_YELLOW_182_Y, Fix.VELGUS_CIRCLE_YELLOW_182_Z), new Vector3(Fix.VELGUS_CIRCLE_YELLOW_195_X, Fix.VELGUS_CIRCLE_YELLOW_195_Y, Fix.VELGUS_CIRCLE_YELLOW_195_Z));
      }

      if (One.TF.Event_Message1000137)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_201_X, Fix.VELGUS_DOOR_201_Y, Fix.VELGUS_DOOR_201_Z));
      }
      if (One.TF.Event_Message1000139)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_202_X, Fix.VELGUS_DOOR_202_Y, Fix.VELGUS_DOOR_202_Z));
      }
      if (One.TF.Event_Message1000141)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_203_X, Fix.VELGUS_DOOR_203_Y, Fix.VELGUS_DOOR_203_Z));
      }

    }
    if (map_data == Fix.MAPFILE_VELGUS_2)
    {
      if (One.TF.Treasure_Velgus2_00001)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_1_X, Fix.VELGUS_2_TREASURE_1_Y, Fix.VELGUS_2_TREASURE_1_Z)));
      }
      if (One.TF.Treasure_Velgus2_00002)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_2_X, Fix.VELGUS_2_TREASURE_2_Y, Fix.VELGUS_2_TREASURE_2_Z)));
      }
      if (One.TF.Treasure_Velgus2_00003)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_3_X, Fix.VELGUS_2_TREASURE_3_Y, Fix.VELGUS_2_TREASURE_3_Z)));
      }
      if (One.TF.Treasure_Velgus2_00004)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_4_X, Fix.VELGUS_2_TREASURE_4_Y, Fix.VELGUS_2_TREASURE_4_Z)));
      }
      if (One.TF.Treasure_Velgus2_00005)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_5_X, Fix.VELGUS_2_TREASURE_5_Y, Fix.VELGUS_2_TREASURE_5_Z)));
      }
      if (One.TF.Treasure_Velgus2_00006)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_6_X, Fix.VELGUS_2_TREASURE_6_Y, Fix.VELGUS_2_TREASURE_6_Z)));
      }
      if (One.TF.Treasure_Velgus2_00007)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_7_X, Fix.VELGUS_2_TREASURE_7_Y, Fix.VELGUS_2_TREASURE_7_Z)));
      }
      if (One.TF.Treasure_Velgus2_00008)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_8_X, Fix.VELGUS_2_TREASURE_8_Y, Fix.VELGUS_2_TREASURE_8_Z)));
      }
      if (One.TF.Treasure_Velgus2_00009)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_9_X, Fix.VELGUS_2_TREASURE_9_Y, Fix.VELGUS_2_TREASURE_9_Z)));
      }
      if (One.TF.Treasure_Velgus2_00010)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_10_X, Fix.VELGUS_2_TREASURE_10_Y, Fix.VELGUS_2_TREASURE_10_Z)));
      }
      if (One.TF.Treasure_Velgus2_00011)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_11_X, Fix.VELGUS_2_TREASURE_11_Y, Fix.VELGUS_2_TREASURE_11_Z)));
      }
      if (One.TF.Treasure_Velgus2_00012)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_12_X, Fix.VELGUS_2_TREASURE_12_Y, Fix.VELGUS_2_TREASURE_12_Z)));
      }
      if (One.TF.Treasure_Velgus2_00013)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_13_X, Fix.VELGUS_2_TREASURE_13_Y, Fix.VELGUS_2_TREASURE_13_Z)));
      }
      if (One.TF.Treasure_Velgus2_00014)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_14_X, Fix.VELGUS_2_TREASURE_14_Y, Fix.VELGUS_2_TREASURE_14_Z)));
      }
      if (One.TF.Treasure_Velgus2_00015)
      {
        ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, FindFieldObjectIndex(FieldObjList, new Vector3(Fix.VELGUS_2_TREASURE_15_X, Fix.VELGUS_2_TREASURE_15_Y, Fix.VELGUS_2_TREASURE_15_Z)));
      }

      if (One.TF.Event_SpeedRun1_Complete)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_216_X, Fix.VELGUS_DOOR_216_Y, Fix.VELGUS_DOOR_216_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_217_X, Fix.VELGUS_DOOR_217_Y, Fix.VELGUS_DOOR_217_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_218_X, Fix.VELGUS_DOOR_218_Y, Fix.VELGUS_DOOR_218_Z));
      }

      if (One.TF.Event_Message1000209)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_219_X, Fix.VELGUS_DOOR_219_Y, Fix.VELGUS_DOOR_219_Z));
      }

      if (One.TF.Event_SpeedRun2_Complete == false)
      {
        //HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_229_X, Fix.VELGUS_FIXEDTILE_229_Y, Fix.VELGUS_FIXEDTILE_229_Z)); // 最初のタイルは隠さなくて良い。
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_230_X, Fix.VELGUS_FIXEDTILE_230_Y, Fix.VELGUS_FIXEDTILE_230_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_231_X, Fix.VELGUS_FIXEDTILE_231_Y, Fix.VELGUS_FIXEDTILE_231_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_232_X, Fix.VELGUS_FIXEDTILE_232_Y, Fix.VELGUS_FIXEDTILE_232_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_233_X, Fix.VELGUS_FIXEDTILE_233_Y, Fix.VELGUS_FIXEDTILE_233_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_234_X, Fix.VELGUS_FIXEDTILE_234_Y, Fix.VELGUS_FIXEDTILE_234_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_235_X, Fix.VELGUS_FIXEDTILE_235_Y, Fix.VELGUS_FIXEDTILE_235_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_236_X, Fix.VELGUS_FIXEDTILE_236_Y, Fix.VELGUS_FIXEDTILE_236_Z));
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_FIXEDTILE_237_X, Fix.VELGUS_FIXEDTILE_237_Y, Fix.VELGUS_FIXEDTILE_237_Z));
      }
      else
      {
        HideFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SLIDINGTILE_238_X, Fix.VELGUS_SLIDINGTILE_238_Y, Fix.VELGUS_SLIDINGTILE_238_Z));
      }

      if (One.TF.Event_Message1000211)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_239_X, Fix.VELGUS_DOOR_239_Y, Fix.VELGUS_DOOR_239_Z));
      }

      if (One.TF.Event_Message1000213)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_242_X, Fix.VELGUS_DOOR_242_Y, Fix.VELGUS_DOOR_242_Z));
      }

      if (One.TF.Event_Message1000215)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_SECRETWALL_245_X, Fix.VELGUS_SECRETWALL_245_Y, Fix.VELGUS_SECRETWALL_245_Z));
      }

      if (One.TF.Event_SpeedRun5_Complete)
      {
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_248_X, Fix.VELGUS_DOOR_248_Y, Fix.VELGUS_DOOR_248_Z));
        RemoveFieldObject(FieldObjList, new Vector3(Fix.VELGUS_DOOR_249_X, Fix.VELGUS_DOOR_249_Y, Fix.VELGUS_DOOR_249_Z));
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

  private void HideFieldObject(List<FieldObject> list, Vector3 position)
  {
    for (int ii = 0; ii < FieldObjList.Count; ii++)
    {
      if (FieldObjList[ii].transform.position == position)
      {
        FieldObject current = FieldObjList[ii];
        Debug.Log("HideFieldObject[ii] " + ii.ToString());
        current.gameObject.SetActive(false);
        return;
      }
    }

    Debug.Log("HideFieldObject not found...");
  }

  private void RevealFieldObject(List<FieldObject> list, Vector3 position)
  {
    for (int ii = 0; ii < FieldObjList.Count; ii++)
    {
      if (FieldObjList[ii].transform.position == position)
      {
        FieldObject current = FieldObjList[ii];
        Debug.Log("RevealFieldObject[ii] " + ii.ToString());
        current.gameObject.SetActive(true);
        return;
      }
    }

    Debug.Log("RevealFieldObject not found...");
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
      if (One.TF.BattlePlayer1 == list[ii].FullName)
      {
        NodeMiniChara current = Instantiate(nodeCharaPanel) as NodeMiniChara;
        current.Refresh(list[ii]);
        current.transform.SetParent(GroupCharacterList.transform);
        MiniCharaList.Add(current);
        PlayerList.Add(list[ii]);
        break; 
      }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer2 == list[ii].FullName)
      {
        NodeMiniChara current = Instantiate(nodeCharaPanel) as NodeMiniChara;
        current.Refresh(list[ii]);
        current.transform.SetParent(GroupCharacterList.transform);
        MiniCharaList.Add(current);
        PlayerList.Add(list[ii]); 
        break; 
      }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer3 == list[ii].FullName)
      {
        NodeMiniChara current = Instantiate(nodeCharaPanel) as NodeMiniChara;
        current.Refresh(list[ii]);
        current.transform.SetParent(GroupCharacterList.transform);
        MiniCharaList.Add(current);
        PlayerList.Add(list[ii]); 
        break; 
      }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer4 == list[ii].FullName)
      {
        NodeMiniChara current = Instantiate(nodeCharaPanel) as NodeMiniChara;
        current.Refresh(list[ii]);
        current.transform.SetParent(GroupCharacterList.transform);
        MiniCharaList.Add(current);
        PlayerList.Add(list[ii]); 
        break;
      }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer5 == list[ii].FullName)
      {
        NodeMiniChara current = Instantiate(nodeCharaPanel) as NodeMiniChara;
        current.Refresh(list[ii]);
        current.transform.SetParent(GroupCharacterList.transform);
        MiniCharaList.Add(current);
        PlayerList.Add(list[ii]);
        break;
      }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer6 == list[ii].FullName)
      {
        NodeMiniChara current = Instantiate(nodeCharaPanel) as NodeMiniChara;
        current.Refresh(list[ii]);
        current.transform.SetParent(GroupCharacterList.transform);
        MiniCharaList.Add(current);
        PlayerList.Add(list[ii]);
        break;
      }
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

  private void FieldObjectMoveLogic(FieldObject field_obj, Fix.Direction direction)
  {
    if (field_obj != null)
    {
      for (int jj = 0; jj < Fix.INFINITY; jj++)
      {
        TileInformation tile = SearchNextTile(field_obj.transform.position, direction);
        if (tile == null)
        {
          break;
        }

        Vector3 nextLocation = new Vector3(-99999, -99999, -99999); // 初期(0,0,0)はあり得るので、あり得ない位置をまず設定
        Vector3 nextLocation2 = new Vector3(-99999, -99999, -99999); // 初期(0,0,0)はあり得るので、あり得ない位置をまず設定
        if (direction == Fix.Direction.Right)
        {
          nextLocation = new Vector3(field_obj.transform.position.x + 1.0f, field_obj.transform.position.y, field_obj.transform.position.z);
          nextLocation2 = new Vector3(field_obj.transform.position.x + 1.0f, field_obj.transform.position.y - 0.5f, field_obj.transform.position.z);
          Debug.Log("nextLocation: " + nextLocation.ToString());
        }
        if (direction == Fix.Direction.Left)
        {
          nextLocation = new Vector3(field_obj.transform.position.x - 1.0f, field_obj.transform.position.y, field_obj.transform.position.z);
          nextLocation2 = new Vector3(field_obj.transform.position.x - 1.0f, field_obj.transform.position.y - 0.5f, field_obj.transform.position.z);
          Debug.Log("nextLocation: " + nextLocation.ToString());
        }
        if (direction == Fix.Direction.Top)
        {
          nextLocation = new Vector3(field_obj.transform.position.x, field_obj.transform.position.y, field_obj.transform.position.z + 1.0f);
          nextLocation2 = new Vector3(field_obj.transform.position.x, field_obj.transform.position.y - 0.5f, field_obj.transform.position.z + 1.0f);
          Debug.Log("nextLocation: " + nextLocation.ToString());
        }
        if (direction == Fix.Direction.Bottom)
        {
          nextLocation = new Vector3(field_obj.transform.position.x, field_obj.transform.position.y, field_obj.transform.position.z - 1.0f);
          nextLocation2 = new Vector3(field_obj.transform.position.x, field_obj.transform.position.y - 0.5f, field_obj.transform.position.z - 1.0f);
          Debug.Log("nextLocation: " + nextLocation.ToString());
        }
        FieldObject fieldObjBefore = SearchObject(nextLocation);
        if (fieldObjBefore != null)
        {
          break;
        }
        fieldObjBefore = SearchObject(nextLocation2);
        if (fieldObjBefore != null)
        {
          break;
        }

        if (tile != null)
        {
          Debug.Log("nextLocation: " + nextLocation.ToString());

          if (BlockCheck(field_obj.gameObject, tile) == false)
          {
            break;
          }
        }

        // todo 単なる描画のためにスリープメソッドを探求する必要があるか。あれば要対応
        //this.NextTapOkSleep = Convert.ToSingle(currentMessage);
        //this.NextTapOk = true;

        if (direction == Fix.Direction.Right)
        {
          field_obj.transform.position = new Vector3(field_obj.transform.position.x + 1.0f,
                                                     field_obj.transform.position.y,
                                                     field_obj.transform.position.z);
        }
        else if (direction == Fix.Direction.Left)
        {
          field_obj.transform.position = new Vector3(field_obj.transform.position.x -1.0f,
                                                     field_obj.transform.position.y,
                                                     field_obj.transform.position.z);
        }
        else if (direction == Fix.Direction.Top)
        {
          field_obj.transform.position = new Vector3(field_obj.transform.position.x,
                                                     field_obj.transform.position.y,
                                                     field_obj.transform.position.z + 1.0f);
        }
        else if (direction == Fix.Direction.Bottom)
        {
          field_obj.transform.position = new Vector3(field_obj.transform.position.x,
                                                     field_obj.transform.position.y,
                                                     field_obj.transform.position.z - 1.0f);
        }
      }
    }
  }

  private bool MatchFieldObjLocation(FieldObject field_obj, float x, float y, float z)
  {
    if ((x - 0.001f <= field_obj.transform.position.x && field_obj.transform.position.x <= x + 0.001f) &&
        (y - 0.001f <= field_obj.transform.position.y && field_obj.transform.position.y <= y + 0.001f) &&
        (z - 0.001f <= field_obj.transform.position.z && field_obj.transform.position.z <= z + 0.001f))
    {
      return true;
    }

    return false;
  }

  private bool DetectVelgusMovingTile(GameObject src, GameObject dst)
  {
    if (src == null) { return false; }
    if (dst == null) { return false; }

    if (src.transform.position.x - 0.2f < dst.transform.position.x &&
         dst.transform.position.x < src.transform.position.x + 0.2f &&
         src.transform.position.z - 0.2f < dst.transform.position.z &&
         dst.transform.position.z < src.transform.position.z + 0.2f)
    {
      // 何もせず通過
      return true;
    }
    return false;
  }
}
