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
  public TileInformation SelectField;
  public Text txtSelectName;
  public Text txtSelectObjectName;
  public Text txtEditMode;
  public Text txtCurrentCursor;
  public Text txtCurrentCursor2;
  public Text txtEditId;
  public GameObject ContentFieldObj;
  public NodeEditFieldObj NodeFieldObjView;

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
  public TileInformation prefab_Upstair;
  public GameObject prefab_Player;
  public FieldObject prefab_Treasure;
  public FieldObject prefab_TreasureOpen;
  public FieldObject prefab_Rock;
  public FieldObject prefab_Player2;


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
  List<string> ObjectList = new List<string>();

  private int BattleEncount = 10;
  private int CumulativeBattleCounter = 0;

  private string CurrentMapSelectName = String.Empty;

  private bool GameOver = false;

  private bool NextTapOk = false; // 画面再描画が必要案ものについて、一旦メソッドを抜け次のフレーム更新(Update)で即時TapOKを自動処理する。
  private float NextTapOkSleep = 0.0f;
  private float NextTapOkCounter = 0.0f;

  private string currentDecision = String.Empty;

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
    PrefabList.Add("Artharium_Gate");
    PrefabList.Add("Upstair");

    // オブジェクトリストの設定
    ObjectList.Add("Treasure");
    ObjectList.Add("Rock");

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

    // プレイヤー位置を設定
    JumpToLocation(new Vector3(One.TF.Field_X, One.TF.Field_Y, One.TF.Field_Z));

    // タイルおよびフィールドオブジェクトの設置
    LoadTileMapping(One.TF.CurrentDungeonField);

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

    // フィールドオブジェクトの状態更新
    UpdateFieldObject(One.TF.CurrentDungeonField);

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
        // todo 第三引数のIDをどう入力させるか。
        AddTile(txtSelectName.text, SelectField.transform.position, String.Empty);
        Debug.Log("time-5: " + DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString());
        return;
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
          if (FieldObjList[ii].content == FieldObject.Content.Treasure)
          {
            counter++;
          }
        }
        counter++; // 追加するのでもう１カウント
        String objectId = counter.ToString();
        AddFieldObj(txtSelectObjectName.text, SelectField.transform.position, objectId);
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
      // まず移動する。
      JumpToLocation(new Vector3(tile.transform.position.x,
                                 tile.transform.position.y + 1.0f,
                                 tile.transform.position.z));

      One.PlaySoundEffect(Fix.SOUND_FOOT_STEP);

      // 移動直後、フィールドオブジェクトの検出および対応。
      FieldObject fieldObj = SearchObject(this.Player.transform.position);

      if (fieldObj != null && fieldObj.content == FieldObject.Content.Treasure)
      {
        Vector3 location = fieldObj.transform.position;
        if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
        {
          Debug.Log("Detect fieldObj: " + location);
          // 宝箱１
          if (One.TF.Treasure_Artharium_00001 == false && location.x == Fix.ARTHARIUM_Treasure_2_X && location.y == Fix.ARTHARIUM_Treasure_2_Y && location.z == Fix.ARTHARIUM_Treasure_2_Z)
          {
            int num = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);
            ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, Fix.FINE_SWORD); TapOK();
            return;
          }
          // 宝箱２
          if (One.TF.Treasure_Artharium_00002 == false && location.x == Fix.ARTHARIUM_Treasure_8_X && location.y == Fix.ARTHARIUM_Treasure_8_Y && location.z == Fix.ARTHARIUM_Treasure_8_Z)
          {
            int num = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);
            ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, Fix.FINE_LANCE); TapOK();
            return;
          }
          // 宝箱３
          if (One.TF.Treasure_Artharium_00003 == false && location.x == Fix.ARTHARIUM_Treasure_9_X && location.y == Fix.ARTHARIUM_Treasure_9_Y && location.z == Fix.ARTHARIUM_Treasure_9_Z)
          {
            int num = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);
            ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, Fix.FINE_ARMOR); TapOK();
            return;
          }
          // 宝箱４
          if (One.TF.Treasure_Artharium_00004 == false && location.x == Fix.ARTHARIUM_Treasure_10_X && location.y == Fix.ARTHARIUM_Treasure_10_Y && location.z == Fix.ARTHARIUM_Treasure_10_Z)
          {
            int num = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);
            ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, Fix.FINE_CLAW); TapOK();
            return;
          }
          // 宝箱５
          if (One.TF.Treasure_Artharium_00005 == false && location.x == Fix.ARTHARIUM_Treasure_11_X && location.y == Fix.ARTHARIUM_Treasure_11_Y && location.z == Fix.ARTHARIUM_Treasure_11_Z)
          {
            int num = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);
            ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, Fix.BLUE_PENDANT); TapOK();
            return;
          }
          // 宝箱６
          if (One.TF.Treasure_Artharium_00006 == false && location.x == Fix.ARTHARIUM_Treasure_12_X && location.y == Fix.ARTHARIUM_Treasure_12_Y && location.z == Fix.ARTHARIUM_Treasure_12_Z)
          {
            int num = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);
            ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, Fix.YELLOW_PENDANT); TapOK();
            return;
          }
          // 宝箱７
          if (One.TF.Treasure_Artharium_00007 == false && location.x == Fix.ARTHARIUM_Treasure_13_X && location.y == Fix.ARTHARIUM_Treasure_13_Y && location.z == Fix.ARTHARIUM_Treasure_13_Z)
          {
            int num = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);
            ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, Fix.GREEN_PENDANT); TapOK();
            return;
          }
          // 宝箱８
          if (One.TF.Treasure_Artharium_00008 == false && location.x == Fix.ARTHARIUM_Treasure_14_X && location.y == Fix.ARTHARIUM_Treasure_14_Y && location.z == Fix.ARTHARIUM_Treasure_14_Z)
          {
            int num = FindFieldObjectIndex(FieldObjList, fieldObj.transform.position);
            ExchangeFieldObject(FieldObjList, prefab_TreasureOpen, num);
            MessagePack.MessageX00003(ref QuestMessageList, ref QuestEventList, Fix.PURPLE_PENDANT); TapOK();
            return;
          }
        }
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
      DetectEncount();
    }
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
      this.currentDecision = Fix.DECISION_BACKTO_HOMETOWN;
      txtDecisionTitle.text = "ホームタウンへ帰還しますか？";
      int cost = One.TF.Gold / 4;
      txtDecisionMessage.text = "ダンジョン内から直接帰還した場合、" + cost.ToString() + " ゴールド消費する事となります。";
      txtDecisionA.text = "Accept";
      txtDecisionB.text = "Cancel";
      txtDecisionC.text = "";
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
    if (this.currentDecision == Fix.DECISION_BACKTO_HOMETOWN)
    {
      One.TF.Gold -= One.TF.Gold / 4;
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
  }

  public void TapDecisionCancel()
  {
    if (this.currentDecision == Fix.DECISION_BACKTO_HOMETOWN)
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
    One.TF.LocationPlayer2 = false;
    SceneDimension.JumpToHomeTown();
  }

  public void TapJumpView(NodeEditFieldObj node_edit_obj)
  {
    MainCamera.transform.position = new Vector3(node_edit_obj.x - 0.0f,
                                       node_edit_obj.y + 7.0f,
                                       node_edit_obj.z - 5.0f);

    SelectField.transform.position = new Vector3(node_edit_obj.x,
                                             node_edit_obj.y,
                                             node_edit_obj.z);

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

        Debug.Log(currentEvent.ToString() + " " + currentMessage);

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
          this.NextTapOkSleep = Convert.ToSingle(currentMessage);
          this.NextTapOk = true;
          return; // 画面即時反映
        }
        else if (currentEvent == MessagePack.ActionEvent.GetItem)
        {
          One.TF.AddBackPack(new Item(currentMessage));
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.GetTreasure)
        {
          this.txtSystemMessage.text = "【 " + currentMessage + " 】を手に入れました！";
          this.panelSystemMessage.SetActive(true);

          if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
          {
            // 宝箱１
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_2_X, Fix.ARTHARIUM_Treasure_2_Y, Fix.ARTHARIUM_Treasure_2_Z))
            {
              One.TF.AddBackPack(new Item(currentMessage));
              One.TF.Treasure_Artharium_00001 = true;
              return; // 通常
            }
            // 宝箱２
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_8_X, Fix.ARTHARIUM_Treasure_8_Y, Fix.ARTHARIUM_Treasure_8_Z))
            {
              One.TF.AddBackPack(new Item(currentMessage));
              One.TF.Treasure_Artharium_00002 = true;
              return; // 通常
            }
            // 宝箱３
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_9_X, Fix.ARTHARIUM_Treasure_9_Y, Fix.ARTHARIUM_Treasure_9_Z))
            {
              One.TF.AddBackPack(new Item(currentMessage));
              One.TF.Treasure_Artharium_00003 = true;
              return; // 通常
            }
            // 宝箱４
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_10_X, Fix.ARTHARIUM_Treasure_10_Y, Fix.ARTHARIUM_Treasure_10_Z))
            {
              One.TF.AddBackPack(new Item(currentMessage));
              One.TF.Treasure_Artharium_00004 = true;
              return; // 通常
            }
            // 宝箱５
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_11_X, Fix.ARTHARIUM_Treasure_11_Y, Fix.ARTHARIUM_Treasure_11_Z))
            {
              One.TF.AddBackPack(new Item(currentMessage));
              One.TF.Treasure_Artharium_00005 = true;
              return; // 通常
            }
            // 宝箱６
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_12_X, Fix.ARTHARIUM_Treasure_12_Y, Fix.ARTHARIUM_Treasure_12_Z))
            {
              One.TF.AddBackPack(new Item(currentMessage));
              One.TF.Treasure_Artharium_00006 = true;
              return; // 通常
            }
            // 宝箱７
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_13_X, Fix.ARTHARIUM_Treasure_13_Y, Fix.ARTHARIUM_Treasure_13_Z))
            {
              One.TF.AddBackPack(new Item(currentMessage));
              One.TF.Treasure_Artharium_00007 = true;
              return; // 通常
            }
            // 宝箱８
            if (this.Player.transform.position == new Vector3(Fix.ARTHARIUM_Treasure_14_X, Fix.ARTHARIUM_Treasure_14_Y, Fix.ARTHARIUM_Treasure_14_Z))
            {
              One.TF.AddBackPack(new Item(currentMessage));
              One.TF.Treasure_Artharium_00008 = true;
              return; // 通常
            }

          }
        }
        else if (currentEvent == MessagePack.ActionEvent.RemoveFieldObject)
        {
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
        }
        else if (currentEvent == MessagePack.ActionEvent.InstantiateObject)
        {
          Debug.Log("Detect InstantiateObject");
          // todo 他の生成シーンもケースごとに対応する。
          One.TF.LocationPlayer2 = true;
          LoadObjectFromEvent();
          continue; // 継続
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
    if (One.TF.CurrentDungeonField == Fix.MAPFILE_BASE_FIELD)
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
    }

    if (tile != null && tile.field == TileInformation.Field.Upstair)
    {
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_ARTHARIUM)
      {
        this.DungeonMap = Fix.MAPFILE_BASE_FIELD;
        this.DungeonCall = Fix.MAPFILE_BASE_FIELD;
        One.TF.Field_X = 25;
        One.TF.Field_Y = 3;
        One.TF.Field_Z = 32;
        return true;
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
      else if (tile.transform.position.x == -4 && tile.transform.position.y == 9 && tile.transform.position.z == 34)
      {
        this.HomeTownCall = Fix.TOWER_OHRAN;
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
      if (tile.transform.position.x == -27 && tile.transform.position.y == 0 && tile.transform.position.z == -7)
      {
        this.DungeonMap = Fix.MAPFILE_GORATRUM;
        this.DungeonCall = Fix.DUNGEON_GORATRUM_CAVE;
        return true;
      }
      else if (tile.transform.position.x == -69 && tile.transform.position.y == 0 && tile.transform.position.z == 33)
      {
        this.DungeonCall = Fix.DUNGEON_VELGUS_SEA_TEMPLE;
        return true;
      }
      else if (tile.transform.position.x == -109 && tile.transform.position.y == 0.5 && tile.transform.position.z == 34)
      {
        this.DungeonCall = Fix.DUNGEON_RUINS_OF_SARITAN;
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
  private void AddTile(string tile_name, Vector3 position, string id)
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
    else if (tile_name == "Artharium_Gate")
    {
      current = Instantiate(prefab_Artharium_Gate, position, Quaternion.identity) as TileInformation;
    }
    else if (tile_name == "Upstair")
    {
      current = Instantiate(prefab_Upstair, position, Quaternion.identity) as TileInformation;
    }

    if (current != null)
    {
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      //current.gameObject.SetActive(false);
      TileList.Add(current);
    }
  }

  private void AddFieldObj(string obj_name, Vector3 position, string id)
  {
    FieldObject current = null;

    if (obj_name == "Treasure")
    {
      current = Instantiate(prefab_Treasure, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Treasure;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = prefab_Treasure.transform.rotation;
    }
    else if (obj_name == "Rock")
    {
      current = Instantiate(prefab_Rock, position, Quaternion.identity) as FieldObject;
      current.content = FieldObject.Content.Rock;
      current.ObjectId = id;
      current.transform.SetParent(this.transform);
      current.transform.rotation = prefab_Rock.transform.rotation;
    }

    if (current != null)
    {
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
        xmlWriter.WriteAttributeString("O", TileList[ii].ObjectId);
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
        xmlWriter.WriteAttributeString("O", FieldObjList[ii].ObjectId);
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

    using (XmlReader reader = XmlReader.Create(Application.dataPath + Fix.BaseMapFolder + map_data, settings))
    {
      int counter = 0;
      List<Vector3> list = new List<Vector3>();
      List<string> strList = new List<string>();
      List<string> strIdList = new List<string>();

      List<Vector3> objList = new List<Vector3>();
      List<string> strObjList = new List<string>();
      List<string> strObjIdList = new List<string>();

      for (; reader.Read();)
      {
        if (reader.Name.Contains("Tile_"))
        {
          string tile = reader.GetAttribute("T");
          string id = reader.GetAttribute("O");
          float x = Convert.ToSingle(reader.GetAttribute("X"));
          float y = Convert.ToSingle(reader.GetAttribute("Y"));
          float z = Convert.ToSingle(reader.GetAttribute("Z"));
          //Debug.Log(reader.GetAttribute("T") + " " + reader.GetAttribute("X") + " " + reader.GetAttribute("Y") + " " + reader.GetAttribute("Z"));
          list.Add(new Vector3(x, y, z));
          strList.Add(tile);
          strIdList.Add(id);
        }
        if (reader.Name.Contains("Field_"))
        {
          string obj = reader.GetAttribute("C");
          string id = reader.GetAttribute("O");
          float x = Convert.ToSingle(reader.GetAttribute("X"));
          float y = Convert.ToSingle(reader.GetAttribute("Y"));
          float z = Convert.ToSingle(reader.GetAttribute("Z"));
          objList.Add(new Vector3(x, y, z));
          strObjList.Add(obj);
          strObjIdList.Add(id);
        }
        counter++;
      }
      Debug.Log("counter : " + counter.ToString());

      for (int ii = 0; ii < list.Count; ii++)
      {
        AddTile(strList[ii], list[ii], strIdList[ii]);
      }

      for (int ii = 0; ii < objList.Count; ii++)
      {
        AddFieldObj(strObjList[ii], objList[ii], strObjIdList[ii]);

        // debug
        NodeEditFieldObj objView = Instantiate(NodeFieldObjView) as NodeEditFieldObj;
        objView.transform.SetParent(ContentFieldObj.transform);
        objView.txtType.text = strObjList[ii];
        objView.txtLocation.text = objList[ii].ToString();
        Debug.Log("currentObjView ID: " + strObjIdList[ii]);
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
        Debug.Log("debug count: " + ii.ToString());
        // debug
      }
    }

    Debug.Log("LoadTileMapping-2 " + DateTime.Now.ToString());
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
