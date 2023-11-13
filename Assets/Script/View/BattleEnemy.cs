using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices.WindowsRuntime;

public partial class BattleEnemy : MotherBase
{
  #region "Core"
  // prefab
  public BuffImage prefab_Buff = null;
  public StackObject prefab_Stack = null;
  public DamageObject prefab_Damage = null;
  public NodeBattleChara node_BattleChara = null;
  public NodeBattleChara node_BattleChara_Enemy = null;
  public NodeBattleChara node_BattleChara_EnemyBoss = null;
  public GameObject prefab_Message = null;
  public NodeActionCommand prefab_MainAction = null;
  public NodeActionCommand prefab_InstantAction = null;
  public NodeActionCommand prefab_GlobalAction = null;
  public NodeActionCommand prefab_ImmediateAction = null;
  public NodeCharaExp node_CharaExp = null;

  // Level-UP Character
  public GameObject GroupLvupCharacter;
  public Text txtLvupTitle;
  public Text txtLvupMaxLife;
  public Text txtLvupMaxManaPoint;
  public Text txtLvupMaxSkillPoint;
  public Text txtLvupRemainPoint;
  public Text txtLvupSoulEssence;
  public Text txtLvupSpecial;
  protected List<bool> DetectLvup = new List<bool>();
  protected List<string> DetectLvupTitle = new List<string>();
  protected List<string> DetectLvupMaxLife = new List<string>();
  protected List<string> DetectLvupMaxManaPoint = new List<string>();
  protected List<string> DetectLvupMaxSkillPoint = new List<string>();
  protected List<string> DetectLvupRemainPoint = new List<string>();
  protected List<string> DetectLvupSoulEssence = new List<string>();
  protected List<string> DetectLvupSpecial = new List<string>();

  // GUI-BattleView
  public GameObject GroupGlobalAction;
  public GameObject GroupBattleGauge;
  public GameObject GroupParentPlayer;
  public GameObject GroupParentEnemy;
  public GameObject panelGameEnd;
  public Text txtGameEndMessage;
  public GameObject panelGameEndExpList;
  public GameObject panelGameOver;
  public Text txtGameoverMessage;
  public Image imgItemDrop;
  public Text txtItemDrop;

  // GUI-SandGlass
  public Image pbSandglass;
  public Text lblBattleTurn;
  public Text lblTimerCount;
  public Text lblTimerSpeed;

  // GUI-Field
  public BuffField PanelPlayerField;
  public BuffField PanelEnemyField;

  // GUI-Player
  public List<GameObject> PlayerArrowList;
  public List<GameObject> EnemyArrowList;
  public List<Image> imgPlayerInstantGauge_AC;
  //public List<Image> imgEnemyInstantGauge_AC; // 敵用のアクションコマンドボタンは画面上に出てこない。
  public List<Image> imgPlayerPotentialGauge;
  //public List<Image> imgEnemyPotentialGauge; // 敵用のアクションコマンドボタンは画面上に出てこない。
  public Image imgGlobalGauge_AC;

  // GUI Team-Energy
  public GameObject groupPotentialEnergy;
  public Image imgPotentialEnergy;
  public Text txtPotentialEnergy;

  public GameObject GroupMainActionCommand;
  public List<GameObject> GroupMainACList;

  public List<Button> GlobalActionButtonList;
  public List<NodeActionPanel> GroupParentActionPanelList;
  public List<NodeActionPanel> GroupEnemyActionPanel;
  public List<GameObject> GroupActionButton;
  public List<GameObject> GroupPlayerActionPoint;
  public List<Text> PlayerActionPointList;

  // GUI-InstantAction
  public GameObject GroupInstantAction;

  // GUI-Message
  public GameObject GroupLogBox;
  public GameObject GroupMessage;

  public GameObject SelectFilter;
  public GameObject lblInstantAction;
  public GameObject btnCancelSelect;

  public GameObject GroupStackInTheCommand;
  public GameObject GroupAnimation;

  public GameObject GroupArchetectAnimation;
  public GameObject ParentArchetectMessage;
  public Text txtArchetectMessage_Name;
  public Text txtArchetectMessage_Command;

  // debug
  public Text debug1;

  public bool CannotRunAway = false;

  // Inner Value
  private Sprite[] imageSandglass;
  private float speedDown = 1;

  public List<Character> PlayerList;
  public List<Character> EnemyList;
  public List<Character> AllList;
  public List<NodeCharaExp> CharaExpList;

  //protected Character currentPlayer = null;

  protected Fix.BattleStatus TimeStatus = Fix.BattleStatus.Ready;
  protected float BattleTimer = 0;
  protected int BattleTurn = 0;

  protected float GlobalInstantValue = 0;
  protected float GlobalInstantInc = 1;

  protected bool NowAnimationMode = false;
  public List<int> AnimationProgress;
  protected const int MAX_ANIMATION_TIME = 40;

  protected bool NowIrregularStepMode = false;
  protected Character NowIrregularStepPlayer = null;
  protected Character NowIrregularStepTarget = null;
  protected double NowIrregularStepCounter = 0;

  protected bool NowUnintentionalHitMode = false;
  protected Character NowUnintentionalHitPlayer = null;
  protected Character NowUnintentionalHitTarget = null;
  protected double NowUnintentionalHitCounter = 0;

  protected bool NowSelectGlobal = false;
  protected bool NowSelectTarget = false;
  protected bool NowInstantTarget = false;
  public Character NowSelectSrcPlayer = null;
  public Button NowSelectActionSrcButton = null;
  public Button NowSelectActionCommandButton = null;
  public Button NowSelectActionDstButton = null;

  protected bool NowStackInTheCommand = false;

  protected bool NowAnimationArchetect;
  protected int AnimationArchetectProgress;

  protected int GlobalAnimationChain = 0; // アニメーション実行の際、ひとまとめで表示したい箇所についてナンバーを宣言し、同一ナンバーの場合はまとめてアニメーション実行するためのフラグ

  protected int AutoExit = -1;

  private float BATTLE_GAUGE_WITDH = 0;

  protected bool DetectItemDrop = false;

  protected Fix.BattleMode _battleType = Fix.BattleMode.None;
  public Fix.BattleMode BattleType
  {
    set { _battleType = value; }
    get { return _battleType; }
  }

  // Start is called before the first frame update
  public override void Start()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    base.Start();

    BATTLE_GAUGE_WITDH = (GroupBattleGauge.GetComponent<RectTransform>().rect.width - PlayerArrowList[0].GetComponent<RectTransform>().sizeDelta.x);
    Debug.Log("BATTLE_GAUGE_WIDTH: " + BATTLE_GAUGE_WITDH);

    if (debug1 != null)
    {
      debug1.text = Screen.width + " " + Screen.height + " " + Screen.dpi;

    }

    this.CannotRunAway = One.CannotRunAway;
    this.BattleType = One.BattleMode;

    // 砂時計を生成する。
    Texture2D textureSandGlass = Resources.Load<Texture2D>("SandGlassIcon");
    this.imageSandglass = new Sprite[8];
    int BASE_SIZE_X = 152;
    int BASE_SIZE_Y = 211;
    for (int locX = 0; locX < Fix.TIMER_ICON_NUM; locX++)
    {
      this.imageSandglass[locX] = Sprite.Create(textureSandGlass, new Rect(BASE_SIZE_X * locX, 0, BASE_SIZE_X, BASE_SIZE_Y), new Vector2(0, 0));
    }
    this.pbSandglass.sprite = this.imageSandglass[0];
    this.BattleTimer = 0;
    this.BattleTurn = 1; // [debug]

    // グローバルアクションボタンを設定する。
    List<string> str_list0 = new List<string>();
    //str_list0.Add(Fix.GLOBAL_ACTION_1);
    //str_list0.Add(Fix.GLOBAL_ACTION_2);
    //str_list0.Add(Fix.GLOBAL_ACTION_3);
    //str_list0.Add(Fix.GLOBAL_ACTION_4);
    str_list0.Add(Fix.LOG_BUTTON);
    str_list0.Add(Fix.READY_BUTTON);
    str_list0.Add(Fix.RUNAWAY_BUTTON);
    for (int ii = 0; ii < str_list0.Count; ii++)
    {
      string commandName = str_list0[ii];
      NodeActionCommand global = Instantiate(prefab_GlobalAction) as NodeActionCommand;
      global.CommandName = commandName;
      global.name = commandName;
      global.OwnerName = "Owner";
      global.ActionButton.name = commandName;
      global.ApplyImageIcon(commandName);
      //global.ActionButton.image.sprite = Resources.Load<Sprite>(commandName);

      global.transform.SetParent(GroupGlobalAction.transform);
      global.gameObject.SetActive(true);

//      SetupActionCommandButton(GlobalActionButtonList[ii], str_list0[ii]);
    }

    // キャラクターを生成する。
    List<Character> playerList = new List<Character>();
    for (int ii = 0; ii < Fix.MAX_TEAM_MEMBER; ii++)
    {
      string target = String.Empty;
      if (ii == 0) { target = One.TF.BattlePlayer1; Debug.Log("target1 is " + target); }
      if (ii == 1) { target = One.TF.BattlePlayer2; Debug.Log("target2 is " + target); }
      if (ii == 2) { target = One.TF.BattlePlayer3; Debug.Log("target3 is " + target); }
      //if (ii == 3) { target = One.TF.BattlePlayer4; Debug.Log("target4 is " + target); }

      int counter = 0;
      if (One.TF.AvailableEinWolence && target == Fix.NAME_EIN_WOLENCE) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableLanaAmiria && target == Fix.NAME_LANA_AMIRIA) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableEoneFulnea && target == Fix.NAME_EONE_FULNEA) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableMagiZelkis && target == Fix.NAME_MAGI_ZELKIS) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableSelmoiRo && target == Fix.NAME_SELMOI_RO) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableKartinMai && target == Fix.NAME_KARTIN_MAI) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableJedaArus && target == Fix.NAME_JEDA_ARUS) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableSinikiaVeilhanz && target == Fix.NAME_SINIKIA_VEILHANZ) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableAdelBrigandy && target == Fix.NAME_ADEL_BRIGANDY) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableLeneColtos && target == Fix.NAME_LENE_COLTOS) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailablePermaWaramy && target == Fix.NAME_PERMA_WARAMY) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableKiltJorju && target == Fix.NAME_KILT_JORJU) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableBillyRaki && target == Fix.NAME_BILLY_RAKI) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableAnnaHamilton && target == Fix.NAME_ANNA_HAMILTON) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableCalmansOhn && target == Fix.NAME_CALMANS_OHN) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableSunYu && target == Fix.NAME_SUN_YU) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableShuvaltzFlore && target == Fix.NAME_SHUVALTZ_FLORE) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableRvelZelkis && target == Fix.NAME_RVEL_ZELKIS) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableVanHehgustel && target == Fix.NAME_VAN_HEHGUSTEL) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableOhryuGenma && target == Fix.NAME_OHRYU_GENMA) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableLadaMystorus && target == Fix.NAME_LADA_MYSTORUS) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableSinOscurete && target == Fix.NAME_SIN_OSCURETE) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
      if (One.TF.AvailableDelvaTreckino && target == Fix.NAME_DELVA_TRECKINO) { playerList.Add(One.SelectCharacter(target)); }
      counter++;
    }

    // 味方グループの作成
    float allyBaseStart = AP.Math.RandomInteger(30) + 30.0f;
    for (int ii = 0; ii < playerList.Count; ii++)
    {
      Debug.Log("playerList: " + ii.ToString() + " " + playerList[ii].FullName);
      if (BattleType == Fix.BattleMode.Duel && ii >= 1)
      {
        // Duelの場合１人しか参加させない。
        continue;
      }
      NodeBattleChara node = Instantiate(node_BattleChara) as NodeBattleChara;
      node.gameObject.SetActive(true);
      node.ParentPanel.SetActive(true);
      node.transform.SetParent(GroupParentPlayer.transform);
      RectTransform rt = node.GetComponent<RectTransform>();
      rt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
      rt.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
      rt.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
      rt.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

      //playerList[ii].MaxGain(); //プレイヤー側は全快設定は不要。
      playerList[ii].IsEnemy = false;
      AddPlayerFromOne(playerList[ii], node, PlayerArrowList[ii], GroupParentActionPanelList[ii], GroupActionButton[ii], imgPlayerInstantGauge_AC[ii], imgPlayerPotentialGauge[ii], this.PanelPlayerField);

      NodeCharaExp node_charaExp = Instantiate(node_CharaExp) as NodeCharaExp;
      node_charaExp.txtPlayerName.text = playerList[ii].FullName;
      if (playerList[ii].Exp < playerList[ii].GetNextExp())
      {
        node_charaExp.txtPlayerExp.text = playerList[ii].Exp + " / " + playerList[ii].GetNextExp();
      }
      else
      {
        node_charaExp.txtPlayerExp.text = "Max";
      }
      float dx = (float)playerList[ii].Exp / (float)playerList[ii].GetNextExp();
      node_charaExp.objCurrentExpGauge.rectTransform.localScale = new Vector3(dx, 1.0f);

      if (playerList[ii].Exp < playerList[ii].GetNextExp())
      {
        node_charaExp.objCurrentExpBorder.gameObject.SetActive(true);
      }
      else
      {
        node_charaExp.objCurrentExpBorder.gameObject.SetActive(false);
      }
      node_charaExp.BeforeExpThreshold = playerList[ii].GetNextExp();
      node_charaExp.BeforeExp = playerList[ii].Exp;
      node_charaExp.gameObject.SetActive(true);
      node_charaExp.transform.SetParent(panelGameEndExpList.transform);
      CharaExpList.Add(node_charaExp);

      // キャラクターグループのリストに追加
      playerList[ii].Ally = Fix.Ally.Ally;
      PlayerList.Add(playerList[ii]);
      AllList.Add(playerList[ii]);

      // インスタント・アクションの作成
      List<string> actionCommandList = PlayerList[ii].GetActionCommandList();
      for (int jj = 0; jj < actionCommandList.Count; jj++)
      {
        string commandName = actionCommandList[jj];
        ActionCommand.TimingType timing = ActionCommand.GetTiming(commandName);
        if (timing == ActionCommand.TimingType.Instant)
        {
          NodeActionCommand instant = Instantiate(prefab_InstantAction) as NodeActionCommand;
          instant.BackColor.color = playerList[ii].BattleForeColor;
          instant.CommandName = commandName;
          instant.name = commandName;
          instant.OwnerName = playerList[ii].FullName;
          instant.ActionButton.name = commandName;
          instant.ApplyImageIcon(commandName);
          //instant.ActionButton.image.sprite = Resources.Load<Sprite>(commandName);

          instant.transform.SetParent(GroupInstantAction.transform);
          instant.gameObject.SetActive(true);
        }
      }

      // 戦闘ゲージを設定
      if (this.BattleType == Fix.BattleMode.Duel)
      {
        playerList[ii].BattleGaugeArrow = 0;
      }
      else
      {
        playerList[ii].BattleGaugeArrow = (float)(AP.Math.RandomInteger(8) + (allyBaseStart - (10.0f * ii)));
      }
      playerList[ii].UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / 100.0f);
    }

    // 最大人数に満たない場合、GUIレイアウト向けに空のパネルを挿入する。
    if (playerList.Count < Fix.MAX_TEAM_MEMBER)
    {
      for (int ii = playerList.Count; ii < Fix.MAX_TEAM_MEMBER; ii++)
      {
        NodeBattleChara node = Instantiate(node_BattleChara) as NodeBattleChara;
        node.gameObject.SetActive(true);
        node.transform.SetParent(GroupParentPlayer.transform);
        node.ParentPanel.SetActive(false);
        RectTransform rt = node.GetComponent<RectTransform>();
        rt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
        rt.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        rt.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        rt.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

      }
    }

    // 敵グループの作成
    float enemyBaseStart = AP.Math.RandomInteger(0) + (One.EnemyList.Count - 1) * 10.0f;
    if (enemyBaseStart <= 0.0f) { enemyBaseStart = 0.0f; }

    if (BattleType == Fix.BattleMode.Normal || BattleType == Fix.BattleMode.Duel)
    {
      for (int ii = 0; ii < One.EnemyList.Count; ii++)
      {
        NodeBattleChara node = Instantiate(node_BattleChara_Enemy) as NodeBattleChara;
        node.gameObject.SetActive(true);
        node.ParentPanel.SetActive(true);
        node.transform.SetParent(GroupParentEnemy.transform);
        //GameObject objEC = new GameObject("objEC");
        //Character character = objEC.AddComponent<Character>();
        //character.BattleBackColor = Fix.COLOR_ENEMY_CHARA;
        //character.BattleForeColor = Fix.COLORFORE_ENEMY_CHARA;
        //character.Construction(One.EnemyList[ii]);
        One.EnemyList[ii].IsEnemy = true;
        if (One.EnemyList[ii] == null) { Debug.Log("null enemylist"); }
        if (EnemyArrowList[ii] == null) { Debug.Log("enemyarrowlist null"); }
        AddPlayerFromOne(One.EnemyList[ii], node, EnemyArrowList[ii], null, null, null, null, this.PanelEnemyField);

        // 戦闘ゲージを設定
        if (this.BattleType == Fix.BattleMode.Duel)
        {
          One.EnemyList[ii].BattleGaugeArrow = 0;
        }
        else
        {
          One.EnemyList[ii].BattleGaugeArrow = (float)(AP.Math.RandomInteger(8) + (enemyBaseStart - (10.0f * ii)));
        }
        One.EnemyList[ii].UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / 100.0f);

        // キャラクターグループのリストに追加
        One.EnemyList[ii].Ally = Fix.Ally.Enemy;
        EnemyList.Add(One.EnemyList[ii]);
        AllList.Add(One.EnemyList[ii]);
      }


      // 最大人数に満たない場合、GUIレイアウト向けに空のパネルを挿入する。
      if (EnemyList.Count < Fix.MAX_ENEMY_MEMBER)
      {
        for (int ii = EnemyList.Count; ii < Fix.MAX_ENEMY_MEMBER; ii++)
        {
          NodeBattleChara node = Instantiate(node_BattleChara_Enemy) as NodeBattleChara;
          node.gameObject.SetActive(true);
          node.ParentPanel.SetActive(false);
          node.transform.SetParent(GroupParentEnemy.transform);
          RectTransform rt = node.GetComponent<RectTransform>();
          rt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
          rt.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
          rt.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
          rt.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
        }
      }
    }
    else if (BattleType == Fix.BattleMode.Boss)
    {
      NodeBattleChara node = Instantiate(node_BattleChara_EnemyBoss) as NodeBattleChara;
      node.gameObject.SetActive(true);
      node.ParentPanel.SetActive(true);
      node.transform.SetParent(GroupParentEnemy.transform);
      One.EnemyList[0].IsEnemy = true;
      if (One.EnemyList[0] == null) { Debug.Log("null enemylist"); }
      if (EnemyArrowList[0] == null) { Debug.Log("enemyarrowlist null"); }
      AddPlayerFromOne(One.EnemyList[0], node, EnemyArrowList[0], null, null, null, null, this.PanelEnemyField);

      // 戦闘ゲージを設定
      One.EnemyList[0].BattleGaugeArrow = (float)(AP.Math.RandomInteger(8) + (enemyBaseStart - (10.0f * 0)));
      One.EnemyList[0].UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / 100.0f);

      // キャラクターグループのリストに追加
      One.EnemyList[0].Ally = Fix.Ally.Enemy;
      EnemyList.Add(One.EnemyList[0]);
      AllList.Add(One.EnemyList[0]);
    }

    // 敵コマンドの最初の設定を行う。
    for (int ii = 0; ii < EnemyList.Count; ii++)
    {
      EnemyList[ii].ChooseCommand(GetAllyGroup(EnemyList[ii]), GetOpponentGroup(EnemyList[ii]), true);
    }

    // ファースト・コマンドからメインコマンドおよびターゲットを設定する。
    for (int ii = 0; ii < PlayerList.Count; ii++)
    {
      SetupFirstCommand(PlayerList[ii], PlayerList[ii].ActionCommandMain);
    }
    for (int ii = 0; ii < EnemyList.Count; ii++)
    {
      SetupFirstCommand(EnemyList[ii], EnemyList[ii].ActionCommandMain);
    }

    //this.currentPlayer = PlayerList[0];

    LogicInvalidate();
  }

  private void AddPlayerFromOne(Character character, NodeBattleChara node, GameObject arrow, NodeActionPanel group_parent_actionpanel, GameObject groupActionButton, Image instant_gauge_ac, Image potential_energy, BuffField field_panel)
  {
    character.objGroup = node;
    character.objArrow = arrow;
    character.objArrow.SetActive(true);
    character.txtName = node.txtPlayerName;
    character.txtLife = node.txtPlayerLife;
    character.objBackLifeGauge = node.objBackLifeGauge;
    character.objCurrentLifeGauge = node.objCurrentLifeGauge;
    character.objCurrentLifeBorder = node.objCurrentLifeBorder;
    character.objBackInstantGauge = node.objBackInstantGauge;
    character.objCurrentInstantGauge = node.objCurrentInstantGauge;
    character.txtManaPoint = node.txtManaPoint;
    character.objBackManaPointGauge = node.objBackManaPointGauge;
    character.objCurrentManaPointGauge = node.objCurrentManaPointGauge;
    character.objCurrentManaPointBorder = node.objCurrentManaPointBorder;
    character.txtSkillPoint = node.txtSkillPoint;
    character.objBackSkillPointGauge = node.objBackSkillPointGauge;
    character.objCurrentSkillPointGauge = node.objCurrentSkillPointGauge;
    character.objCurrentSkillPointBorder = node.objCurrentSkillPointBorder;
    character.objMainButton = node.objMainButton;
    character.txtActionCommand = node.txtActionCommand;
    character.groupActionPoint = node.groupActionPoint;
    character.objBuffPanel = node.groupBuff;
    character.txtTargetName = node.txtTargetName;
    character.imgTargetLifeGauge = node.imgTargetLifeGauge;
    character.objFieldPanel = field_panel;
    character.groupManaPoint = node.GroupManaPoint;
    character.groupSkillPoint = node.GroupSkillPoint;

    if (node.objImmediateCommand != null)
    {
      string command_name = character.CurrentImmediateCommand;
      character.objImmediateCommand = node.objImmediateCommand;
      character.objImmediateCommand.BackColor.color = new Color(0, 0, 0, 0);
      character.objImmediateCommand.CommandName = command_name;
      character.objImmediateCommand.name = command_name;
      character.objImmediateCommand.OwnerName = character.FullName;
      character.objImmediateCommand.ActionButton.name = command_name;
      character.objImmediateCommand.ApplyImageIcon(command_name);

      if (character.IsEnemy)
      {
        character.objImmediateCommand.gameObject.SetActive(false);
      }
    }

    if (character.IsEnemy && this.BattleType == Fix.BattleMode.Duel)
    {
      character.groupManaPoint.SetActive(true);
      character.groupSkillPoint.SetActive(true);
    }

    if (node.GroupActionCommand != null)
    {
      character.GroupActionCommand = node.GroupActionCommand;
      Debug.Log("character.ActionCommandList count: " + character.FullName + " " + character.GetActionCommandList().Count);

      character.objMainButton = node.objMainButton;
      character.objMainButton.CommandName = character.ActionCommandMain;
      character.objMainButton.name = character.ActionCommandMain;
      character.objMainButton.OwnerName = character.FullName;
      character.objMainButton.ApplyImageIcon(character.ActionCommandMain);
      //character.objMainButton.ActionButton.image.sprite = Resources.Load<Sprite>(character.ActionCommandMain);

      character.objActionCommandList.Clear();
      List<String> actionList = character.GetActionCommandList();
      for (int ii = 0; ii < node.ActionCommandList.Count; ii++)
      {
        Debug.Log("actioncommandlist: " + ii.ToString() + actionList[ii]);
        if (ii >= actionList.Count)
        {
          continue;
        }
        character.objActionCommandList.Add(node.ActionCommandList[ii]);
        character.objActionCommandList[ii].CommandName = actionList[ii];
        character.objActionCommandList[ii].name = actionList[ii];
        character.objActionCommandList[ii].OwnerName = character.FullName;
        character.objActionCommandList[ii].ApplyImageIcon(actionList[ii]);
        //character.objActionCommandList[ii].ActionButton.image.sprite = Resources.Load<Sprite>(actionList[ii]);
      }
      if (character.IsEnemy)
      {
        character.GroupActionCommand.SetActive(false);
      }
    }

    character.objParentActionPanel = group_parent_actionpanel;
    character.groupActionButton = groupActionButton;
    character.imgCurrentEnergyPointGauge = potential_energy;

    // GUI画面向けオブジェクトの登録
    if (character.txtName != null)
    {
      character.txtName.text = character.ConvertToJP(character.FullName);
    }
    if (character.txtLife != null)
    {
      character.txtLife.text = character.CurrentLife.ToString();
    }
    if (instant_gauge_ac != null)
    {
      character.objCurrentInstangGauge_AC = instant_gauge_ac;
    }
    if (character.objParentActionPanel != null)
    {
      if (character.objParentActionPanel.txtCurrentPlayerName != null)
      {
        character.objParentActionPanel.txtCurrentPlayerName.text = character.FullName;
      }
      if (character.objParentActionPanel.imgBackGauge != null)
      {
        character.objParentActionPanel.imgBackGauge.color = character.BattleBackColor;
      }
    }
    if (character.objCurrentInstantGauge != null)
    {
      character.objCurrentInstantGauge.color = character.BattleForeColor;
      if (character.IsEnemy && this.BattleType == Fix.BattleMode.Normal)
      {
        character.objCurrentInstantGauge.gameObject.SetActive(false);
      }
      else
      {
        character.objCurrentInstantGauge.gameObject.SetActive(true);
      }
    }
    if (character.objBackInstantGauge)
    {
      character.objBackInstantGauge.color = character.BattleBackColor;
    }
    if (character.txtManaPoint != null)
    {
      character.txtManaPoint.text = character.CurrentManaPoint.ToString();
    }
    if (character.txtSkillPoint != null)
    {
      character.txtSkillPoint.text = character.CurrentSkillPoint.ToString();
    }
    if (character.IsEnemy == false && character.objArrow)
    {
      character.objArrow.GetComponent<Image>().color = character.BattleForeColor;
    }

    // メインコマンドボタンの割当を設定する。
    if (groupActionButton != null)
    {
      //character.ActionCommandList.Clear();
      //AddActionButton(character, groupActionButton, Fix.NORMAL_ATTACK);
      //AddActionButton(character, groupActionButton, Fix.MAGIC_ATTACK);
      //AddActionButton(character, groupActionButton, Fix.DEFENSE);

      //// todo
      //// Delve I
      //if (character.FireBall > 0) { AddActionButton(character, groupActionButton, Fix.FIRE_BALL); }
      //if (character.IceNeedle > 0) { AddActionButton(character, groupActionButton, Fix.ICE_NEEDLE); }
      //if (character.FreshHeal > 0) { AddActionButton(character, groupActionButton, Fix.FRESH_HEAL); }
      //if (character.ShadowBlast > 0) { AddActionButton(character, groupActionButton, Fix.SHADOW_BLAST); }
      //if (character.AirCutter > 0) { AddActionButton(character, groupActionButton, Fix.AIR_CUTTER); }
      //if (character.RockSlam > 0) { AddActionButton(character, groupActionButton, Fix.ROCK_SLAM); }
      //if (character.StraightSmash > 0) { AddActionButton(character, groupActionButton, Fix.STRAIGHT_SMASH); }
      //if (character.HunterShot > 0) { AddActionButton(character, groupActionButton, Fix.HUNTER_SHOT); }
      //if (character.LegStrike > 0) { AddActionButton(character, groupActionButton, Fix.LEG_STRIKE); }
      //if (character.VenomSlash > 0) { AddActionButton(character, groupActionButton, Fix.VENOM_SLASH); }
      //if (character.EnergyBolt > 0) { AddActionButton(character, groupActionButton, Fix.ENERGY_BOLT); }
      //if (character.ShieldBash > 0) { AddActionButton(character, groupActionButton, Fix.SHIELD_BASH); }
      //if (character.AuraOfPower > 0) { AddActionButton(character, groupActionButton, Fix.AURA_OF_POWER); }
      //if (character.DispelMagic > 0) { AddActionButton(character, groupActionButton, Fix.DISPEL_MAGIC); }
      //if (character.TrueSight > 0) { AddActionButton(character, groupActionButton, Fix.TRUE_SIGHT); }
      //if (character.HeartOfLife > 0) { AddActionButton(character, groupActionButton, Fix.HEART_OF_LIFE); }
      //if (character.DarkAura > 0) { AddActionButton(character, groupActionButton, Fix.DARK_AURA); }
      //if (character.OracleCommand > 0) { AddActionButton(character, groupActionButton, Fix.ORACLE_COMMAND); }
      //if (character.FlameBlade > 0) { AddActionButton(character, groupActionButton, Fix.FLAME_BLADE); }
      //if (character.PurePurification > 0) { AddActionButton(character, groupActionButton, Fix.PURE_PURIFICATION); }
      //if (character.DivineCircle> 0) { AddActionButton(character, groupActionButton, Fix.DIVINE_CIRCLE); }
      //if (character.BloodSign> 0) { AddActionButton(character, groupActionButton, Fix.BLOOD_SIGN); }
      //if (character.StanceOfTheBlade > 0) { AddActionButton(character, groupActionButton, Fix.STANCE_OF_THE_BLADE); }
      //if (character.StanceOfTheGuard > 0) { AddActionButton(character, groupActionButton, Fix.STANCE_OF_THE_GUARD); }
      //if (character.MultipleShot > 0) { AddActionButton(character, groupActionButton, Fix.MULTIPLE_SHOT); }
      //if (character.InvisibleBind > 0) { AddActionButton(character, groupActionButton, Fix.INVISIBLE_BIND); }
      //if (character.SkyShield > 0) { AddActionButton(character, groupActionButton, Fix.SKY_SHIELD); }
      //if (character.FlashCounter > 0) { AddActionButton(character, groupActionButton, Fix.FLASH_COUNTER); }
      //if (character.FortuneSpirit > 0) { AddActionButton(character, groupActionButton, Fix.FORTUNE_SPIRIT); }
      //if (character.SpiritualRest > 0) { AddActionButton(character, groupActionButton, Fix.SPIRITUAL_REST); }
      //if (character.MeteorBullet > 0) { AddActionButton(character, groupActionButton, Fix.METEOR_BULLET); }
      //if (character.BlueBullet > 0) { AddActionButton(character, groupActionButton, Fix.BLUE_BULLET); }
      //if (character.HolyBreath > 0) { AddActionButton(character, groupActionButton, Fix.HOLY_BREATH); }
      //if (character.BlackContract > 0) { AddActionButton(character, groupActionButton, Fix.BLACK_CONTRACT); }
      //if (character.DoubleSlash > 0) { AddActionButton(character, groupActionButton, Fix.DOUBLE_SLASH); }
      //if (character.ConcussiveHit > 0) { AddActionButton(character, groupActionButton, Fix.CONCUSSIVE_HIT); }
      //if (character.IrregularStep > 0) { AddActionButton(character, groupActionButton, Fix.IRREGULAR_STEP); }
      //if (character.StormArmor > 0) { AddActionButton(character, groupActionButton, Fix.STORM_ARMOR); }
      //if (character.MuteImpulse > 0) { AddActionButton(character, groupActionButton, Fix.MUTE_IMPULSE); }
      //if (character.VoiceOfVigor > 0) { AddActionButton(character, groupActionButton, Fix.VOICE_OF_VIGOR); }
      //if (character.UnseenAid > 0) { AddActionButton(character, groupActionButton, Fix.UNSEEN_AID); }

      // キャラクター達が保持している情報に基づいてアクションコマンドを登録。
      List<string> mainActionList = new List<string>();
      List<string> basicActionList = character.GetAvailableBasicAction();
      for (int ii = 0; ii < basicActionList.Count; ii++)
      {
        mainActionList.Add(basicActionList[ii]);
      }
      List<string> list = character.GetAvailableList();
      for (int ii = 0; ii < list.Count; ii++)
      {
        mainActionList.Add(list[ii]);
      }

      for (int ii = 0; ii < mainActionList.Count; ii++)
      {
        string commandName = mainActionList[ii];
        NodeActionCommand mainAction = Instantiate(prefab_MainAction) as NodeActionCommand;
        mainAction.BackColor.color = character.BattleForeColor;
        mainAction.CommandName = commandName;
        mainAction.name = commandName;
        mainAction.OwnerName = character.FullName;
        mainAction.ActionButton.name = commandName;
        mainAction.ApplyImageIcon(commandName);
        //mainAction.ActionButton.image.sprite = Resources.Load<Sprite>(commandName);

        mainAction.transform.SetParent(groupActionButton.transform);
        mainAction.gameObject.SetActive(true);
        character.objMainActionList.Add(mainAction);
      }
    }

    // アクションポイントのビュー割当を設定する。
    if (character.groupActionPoint != null)
    {
      character.imgActionPointList = new List<Image>();
      Image[] imageList = character.groupActionPoint.GetComponentsInChildren<Image>();
      for (int jj = 0; jj < imageList.Length; jj++)
      {
        character.imgActionPointList.Add(imageList[jj]);
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
    // todo 試験的に常に再描画を行うようにする。処理落ちの場合はコメントアウトする。
    LogicInvalidate();

    // 元核発動中。この間、時間を進めない。通常アニメーションよりも優先的に処理する。
    if (NowAnimationArchetect)
    {
      AnimationArchetectProgress--;
      Vector3 move = this.ParentArchetectMessage.transform.localPosition;
      if (AnimationArchetectProgress >= 87)
      {
        move.x = move.x + 100;
      }
      else if (AnimationArchetectProgress >= 20)
      {
        move.x = move.x + 2;
      }
      else
      {
        move.x = move.x + 100;
      }
      this.ParentArchetectMessage.transform.localPosition = new Vector3(move.x, move.y, move.z);
      if (AnimationArchetectProgress <= 0)
      {
        NowAnimationArchetect = false;
        this.GroupArchetectAnimation.SetActive(false);
        this.ParentArchetectMessage.transform.localPosition = new Vector3(-500.0f, 0, 0);
      }
      return;
    }

    // イレギュラー・ステップを実行する。この間、時間を進めずイレギュラー・ステップのゲージ進行を行う。
    if (NowIrregularStepMode)
    {
      ExecPlayIrregularStep();
      return;
    }
    if (NowUnintentionalHitMode)
    {
      ExecPlayUnintentionalHit();
      return;
    }

    // アニメーションを実行する。通常は、時間を進める事とする。
    if (NowAnimationMode)
    {
      ExecAnimation();
      return;
      // 敵側が全滅した場合、ゲームエンドとし、最後のダメージ表示は見せる。
      if (CheckGroupAlive(EnemyList) == false)
      {
        return;
      }
      // プレイヤー側が全滅した場合、ゲームエンドとし、最後のダメージ表示は見せる。
      if (CheckGroupAlive(PlayerList) == false)
      {
        return;
      }
    }

    // スタックインザコマンドを実行中。この間、時間を進めない。
    if (NowStackInTheCommand)
    {
      ExecStackInTheCommand();
      return;
    }

    // 集中と断絶のBUFFをリムーブ。この間、時間を進めない。
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (AllList[ii].NowExecSyutyuDanzetsu)
      {
        AllList[ii].NowExecSyutyuDanzetsu = false;
        BuffImage syutyuDanzetsu = AllList[ii].IsSyutyuDanzetsu;
        if (syutyuDanzetsu != null)
        {
          syutyuDanzetsu.RemoveBuff();
        }
        return;
      }
    }

    // ターゲット選択中は、時間を進めない。ただし、Duelではリアルタイムのため時間は止まらない。
    if ((NowSelectTarget || NowInstantTarget) && this.BattleType != Fix.BattleMode.Duel)
    {
      return;
    }
    // タイムステータスの状況に応じて、時間を進めない。
    if (TimeStatus == Fix.BattleStatus.Ready || TimeStatus == Fix.BattleStatus.Stop)
    {
      return;
    }

    // バトルが完了している場合、時間を進めない。
    if (One.BattleEnd != Fix.GameEndType.None)
    {
      if (One.BattleEnd == Fix.GameEndType.Success)
      {
        if (AutoExit > 0)
        {
          AutoExit--;
          if (AutoExit == Fix.BATTLEEND_AUTOEXIT - 1)
          {
            for (int ii = 0; ii < CharaExpList.Count; ii++)
            {
              for (int jj = 0; jj < PlayerList.Count; jj++)
              {
                if (PlayerList[jj].FullName == CharaExpList[ii].txtPlayerName.text)
                {
                  CharaExpList[ii].AfterExp = PlayerList[jj].Exp;
                  if (PlayerList[jj].Exp >= PlayerList[jj].GetNextExp())
                  {
                    CharaExpList[ii].AfterExp = PlayerList[jj].GetNextExp();
                  }
                  Debug.Log("after exp detect: " + CharaExpList[ii].AfterExp);
                }
              }
            }
          }

          int start_time = Fix.BATTLEEND_AUTOEXIT - 50;
          int end_time = Fix.BATTLEEND_AUTOEXIT - 100;
          if (end_time <= AutoExit && AutoExit < start_time)
          {
            for (int ii = 0; ii < CharaExpList.Count; ii++)
            {
              for (int jj = 0; jj < PlayerList.Count; jj++)
              {
                if (PlayerList[jj].FullName == CharaExpList[ii].txtPlayerName.text)
                {
                  // レベルアップの場合MAXで止めるアニメーションにする。
                  if (CharaExpList[ii].AfterExp <= CharaExpList[ii].BeforeExp)
                  {
                    //Debug.Log("CharaExpList detect Levelup");
                    float div_value = (float)((float)CharaExpList[ii].BeforeExpThreshold - (float)CharaExpList[ii].BeforeExp + CharaExpList[ii].AfterExp) * (float)(1.00f / (start_time - end_time)) * (start_time - AutoExit);
                    float current = (CharaExpList[ii].BeforeExp + div_value);
                    float dx = current / (float)(CharaExpList[ii].BeforeExpThreshold); // (float)PlayerList[jj].GetNextExp();
                    if (dx < 1.0f)
                    {
                      CharaExpList[ii].objCurrentExpGauge.rectTransform.localScale = new Vector3(dx, 1.0f);
                      CharaExpList[ii].objCurrentExpBorder.gameObject.SetActive(true);
                      CharaExpList[ii].txtPlayerExp.text = (int)current + " / " + CharaExpList[ii].BeforeExpThreshold;
                    }
                    else
                    {
                      CharaExpList[ii].objCurrentExpGauge.rectTransform.localScale = new Vector3(1.0f, 1.0f);
                      CharaExpList[ii].objCurrentExpBorder.gameObject.SetActive(false);
                      CharaExpList[ii].txtPlayerExp.text = "Max";
                    }
                  }
                  // それ以外は通常のアニメーション
                  else
                  {
                    //Debug.Log("CharaExpList normal");
                    float div_value = (float)((float)CharaExpList[ii].AfterExp - (float)CharaExpList[ii].BeforeExp) * (float)(1.00f / (start_time - end_time)) * (start_time - AutoExit);
                    float current = (CharaExpList[ii].BeforeExp + div_value);
                    float dx = current / (float)PlayerList[jj].GetNextExp();
                    CharaExpList[ii].objCurrentExpGauge.rectTransform.localScale = new Vector3(dx, 1.0f);
                    if (dx < 1.0f)
                    {
                      CharaExpList[ii].objCurrentExpBorder.gameObject.SetActive(true);
                      CharaExpList[ii].txtPlayerExp.text = (int)current + " / " + PlayerList[jj].GetNextExp();
                    }
                    else
                    {
                      CharaExpList[ii].objCurrentExpBorder.gameObject.SetActive(false);
                      CharaExpList[ii].txtPlayerExp.text = "Max";
                    }
                  }
                }
              }
            }
          }

          if (AutoExit == 0)
          {
            AutoExit--;
            TapEndScene();
          }
        }
      }
      return;
    }

    LogicInvalidate();

    // メイン戦闘タイマーカウント更新
    this.BattleTimer += 100 * SpeedFactor();
    if (BattleTurn != 0)
    {
      float currentTime = ((float)Fix.BASE_TIMER_BAR_LENGTH - (float)this.BattleTimer) / ((float)Fix.BASE_TIMER_BAR_LENGTH);
      lblTimerCount.text = currentTime.ToString("0.00");
    }
    UpdateTimerSpeed();
    for (int ii = 0; ii < Fix.TIMER_ICON_NUM; ii++)
    {
      if (Fix.BASE_TIMER_DIV * 100 * ii <= this.BattleTimer && this.BattleTimer < Fix.BASE_TIMER_DIV * 100 * (ii + 1))
      {
        pbSandglass.sprite = this.imageSandglass[ii];
        break;
      }
    }

    // ターンエンドとアップキープ
    if (BattleTimer >= Fix.BASE_TIMER_BAR_LENGTH)
    {
      UpdateTurnEnd();

      UpkeepStep();
    }

    LogicInvalidate();

    // 敵側が全滅した場合、ゲームエンドとする。
    if (CheckGroupAlive(EnemyList) == false)
    {
      One.BattleEnd = Fix.GameEndType.Success;
      if (panelGameEnd.activeInHierarchy == false)
      {
        int gainExp = 0;
        int gainGold = 0;
        for (int ii = 0; ii < One.EnemyList.Count; ii++)
        {
          gainExp += One.EnemyList[ii].Exp;
          gainGold += One.EnemyList[ii].Gold;
        }

        for (int ii = 0; ii < PlayerList.Count; ii++)
        {
          if (PlayerList[ii].Exp < PlayerList[ii].GetNextExp())
          {
            PlayerList[ii].GainExp(gainExp);

            if (PlayerList[ii].Exp >= PlayerList[ii].GetNextExp())
            {
              string newCommand = string.Empty;
              PlayerList[ii].Exp = PlayerList[ii].Exp - PlayerList[ii].GetNextExp();
              PlayerList[ii].UpdateLevelup(ref newCommand);

              DetectLvup.Add(true);
              DetectLvupTitle.Add( PlayerList[ii].FullName + "が Lv " + PlayerList[ii].Level.ToString() + " にレベルアップしました！");
              DetectLvupMaxLife.Add("最大ライフが " + PlayerList[ii].LevelupBaseLife() + " 上昇した！");
              DetectLvupMaxManaPoint.Add("最大マナが " + PlayerList[ii].LevelupBaseManaPoint() + " 上昇した！");
              DetectLvupMaxSkillPoint.Add(""); // 最大スキルポイントが " + PlayerList[ii].LevelupBaseSkillPoint() + " 上昇した！"); // スキルポイントは原則上昇しない。
              DetectLvupRemainPoint.Add("コア・パラメタポイントを " + PlayerList[ii].LevelupRemainPoint() +" 獲得！");
              DetectLvupSoulEssence.Add("ソウル・エッセンスポイントを " + PlayerList[ii].LevelupSoulEssence() + " 獲得！");
              if (newCommand != String.Empty)
              {
                DetectLvupSpecial.Add("【 " + ActionCommand.To_JP(newCommand) + " 】を習得した！");
              }
              else
              {
                DetectLvupSpecial.Add("");
              }
            }
          }
        }
        One.TF.Gold += gainGold;

        txtGameEndMessage.text = "敵を倒した。\r\n" + gainExp + "経験値を獲得。\r\n" + gainGold + "ゴールドを獲得";
        panelGameEnd.SetActive(true);

        // アイテムドロップ
        string targetItemName = One.GetNewItem(Fix.DropItemCategory.Battle, PlayerList[0], EnemyList[0], 1);
        if (targetItemName != String.Empty)
        {
          this.DetectItemDrop = true;
          Item current = new Item(targetItemName);
          this.txtItemDrop.text = "【 " + targetItemName + " 】を入手した！";
          this.imgItemDrop.sprite = Resources.Load<Sprite>("Icon_" + current?.ItemType.ToString() ?? "");

          One.TF.AddBackPack(current);
          // todo DungeonPlayer2ではバックパックに上限値が無いようだが、上限を設けるなら不要アイテムに対するアクションが必要です。
          //this.GettingNewItem = new ItemBackPack(targetItemName);
          //if (this.GettingNewItem.Rare == ItemBackPack.RareLevel.Epic)
          //{
          //  GroundOne.PlaySoundEffect(Database.SOUND_GET_EPIC_ITEM);
          //}
          //else if (this.GettingNewItem.Rare == ItemBackPack.RareLevel.Rare)
          //{
          //  GroundOne.PlaySoundEffect(Database.SOUND_GET_RARE_ITEM);
          //}
          //MessageDisplayWithIcon(new ItemBackPack(targetItemName));
          //this.Filter.SetActive(true);
          //treasurePanel.SetActive(true);

          //if (GetNewItem(this.GettingNewItem))
          //{
          //  // バックパックが空いてて入手可能な場合、ここでは何もしない。
          //  return; // scenebackさせない
          //}
          //else
          //{
          //  // バックパックがいっぱいの場合ステータス画面で不要アイテムを捨てさせます。
          //  SceneDimension.CallTruthStatusPlayer(this, true, targetItemName, string.Empty);
          //  return; // scenebackさせない

          //}
        }
        else
        {
          this.txtItemDrop.text = "";
          this.imgItemDrop.sprite = null;
        }

        // todo ここでイベントフラグを制御してよいか、再考の余地はある。
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.SCREAMING_RAFFLESIA)
        {
          One.TF.DefeatScreamingRafflesia = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.MAGICAL_HAIL_GUN)
        {
          One.TF.DefeatMagicalHailGun = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.HELL_KERBEROS)
        {
          One.TF.DefeatHellKerberos = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.THE_GALVADAZER)
        {
          One.TF.DefeatGalvadazer = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.THE_YODIRIAN)
        {
          One.TF.DefeatYodirian = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.FLANSIS_OF_THE_FOREST_QUEEN)
        {
          One.TF.DefeatFlansisQueenOfVerdant = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.ENEMY_ORIGIN_STAR_CORAL_QUEEN_JP)
        {
          One.TF.DefeatOriginStarCoralQueen = true;
        }
      }
      AutoExit = Fix.BATTLEEND_AUTOEXIT;
      return;
    }
    // プレイヤー側が全滅した場合、ゲームエンドとする。
    if (CheckGroupAlive(PlayerList) == false)
    {
      One.BattleEnd = Fix.GameEndType.Fail;
      if (panelGameOver.activeInHierarchy == false)
      {
        panelGameOver.SetActive(true);
      }
      return;
    }

    LogicInvalidate();

    // プレイヤーゲージを進行する。
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (AllList[ii].Dead == false && AllList[ii].IsSleep == false && AllList[ii].IsStun == false)
      {
        UpdatePlayerArrow(AllList[ii], 0);
      }
    }

    // プレイヤーのインスタントゲージを進行する。
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (AllList[ii].Dead == false && AllList[ii].IsSleep == false && AllList[ii].IsStun == false)
      {
        if (AllList[ii].CurrentInstantPoint < AllList[ii].MaxInstantPoint)
        {
          double increment = PrimaryLogic.BattleResponse(AllList[ii]);
          increment = increment * SpeedFactor();
          AllList[ii].CurrentInstantPoint += increment;
          if (AllList[ii].CurrentInstantPoint >= AllList[ii].MaxInstantPoint)
          {
            AllList[ii].CurrentInstantPoint = AllList[ii].MaxInstantPoint;
          }
        }
      }
    }

    // グローバルのインスタント値を更新する。
    float incrementGlobal = GlobalInstantInc * SpeedFactor();
    this.GlobalInstantValue += incrementGlobal;
    if (this.GlobalInstantValue >= Fix.GLOBAL_INSTANT_MAX)
    {
      this.GlobalInstantValue = Fix.GLOBAL_INSTANT_MAX;
    }
    UpdateGlobalGauge();

    // 敵プレイヤー側のターゲット変更を行う。
    // 即時対応は反応が早すぎるため、遅い反応タイミングでのみ変更可能とする。
    for (int ii = 0; ii < EnemyList.Count; ii++)
    {
      RectTransform rectX = EnemyList[ii].objArrow.GetComponent<RectTransform>();
      if (rectX.position.x <= BATTLE_GAUGE_WITDH / 3.0f)
      {
        if (EnemyList[ii].Target != null && EnemyList[ii].Target.Dead && EnemyList[ii].Target.IsEnemy == false)
        {
          Character current = SearchOpponentForEnemy(EnemyList[ii], PlayerList);
          if (current != null)
          {
            EnemyList[ii].Target = current;
          }
        }
      }
    }

    // 敵の行動コマンドを決定する。
    for (int ii = 0; ii < EnemyList.Count; ii++)
    {
      RectTransform rectX = EnemyList[ii].objArrow.GetComponent<RectTransform>();
      if (rectX.position.x >= BATTLE_GAUGE_WITDH / 3.0f && EnemyList[ii].Decision == false)
      {
        EnemyList[ii].ChooseCommand(GetAllyGroup(EnemyList[ii]), GetOpponentGroup(EnemyList[ii]), false);
      }
    }

    // 敵プレイヤー側がインスタントが溜まった場合、スタックインザコマンドを発動する。
    // ボス戦、Duel戦が対象
    for (int ii = 0; ii < EnemyList.Count; ii++)
    {
      if (EnemyList[ii].CurrentInstantPoint >= EnemyList[ii].MaxInstantPoint)
      {
        if (EnemyList[ii].FullName == Fix.MAGICAL_HAIL_GUN)
        {
          EnemyList[ii].CurrentInstantPoint = 0;
          EnemyList[ii].UpdateInstantPointGauge();
          CreateStackObject(EnemyList[ii], EnemyList[ii], Fix.COMMAND_SUPER_RANDOM_CANNON, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
          return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
        }

        if (EnemyList[ii].FullName == Fix.THE_GALVADAZER || EnemyList[ii].FullName == Fix.THE_GALVADAZER_JP || EnemyList[ii].FullName == Fix.THE_GALVADAZER_JP_VIEW)
        {
          EnemyList[ii].CurrentInstantPoint = 0;
          EnemyList[ii].UpdateInstantPointGauge();
          CreateStackObject(EnemyList[ii], EnemyList[ii].Target, Fix.COMMAND_DRILL_CYCLONE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
          return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
        }

        if (EnemyList[ii].FullName == Fix.DUMMY_SUBURI)
        {
          if (EnemyList[ii].CurrentInstantPoint >= EnemyList[ii].MaxInstantPoint)
          {
            EnemyList[ii].CurrentInstantPoint = 0;
            EnemyList[ii].UpdateInstantPointGauge();

            CreateStackObject(EnemyList[ii], PlayerList[0], Fix.STRAIGHT_SMASH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }
        }
        if (EnemyList[ii].FullName == Fix.DUEL_JEDA_ARUS)
        {
          if (EnemyList[ii].CurrentInstantPoint >= EnemyList[ii].MaxInstantPoint)
          {
            if (EnemyList[ii].CurrentSkillPoint >= ActionCommand.Cost(Fix.DOUBLE_SLASH, EnemyList[ii]))
            {
              EnemyList[ii].CurrentInstantPoint = 0;
              EnemyList[ii].UpdateInstantPointGauge();

              CreateStackObject(EnemyList[ii], PlayerList[0], Fix.DOUBLE_SLASH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
            }
          }
        }
      }
    }
    LogicInvalidate();

    // プレイヤ－ゲージがたまった場合、アクションコマンドを実行する。
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (AllList[ii].Dead == false)
      {
        RectTransform rectX = AllList[ii].objArrow.GetComponent<RectTransform>();
        if (rectX.position.x >= BATTLE_GAUGE_WITDH)
        {
          ExecPlayerCommand(AllList[ii], AllList[ii].Target, string.Empty);
          UpdatePlayerArrowZero(AllList[ii], AllList[ii].objArrow);
          BuffImage speedStep = AllList[ii].IsSpeedStep;
          if (speedStep != null)
          {
            Debug.Log("Target is speedStep, then Cumulative++");
            int beforeCumulative = speedStep.Cumulative;
            speedStep.Cumulative++;
            if (beforeCumulative != speedStep.Cumulative)
            {
              StartAnimation(AllList[ii].objGroup.gameObject, Fix.BATTLE_SPEED_UP, Fix.COLOR_NORMAL);
            }
          }

          AllList[ii].Decision = false;
          break;
        }
      }
    }

    LogicInvalidate();
  }

  private void CreateStackObject(Character player, Character target, string command_name, int stack_timer, int sudden_timer)
  {
    StackObject stack = Instantiate(this.prefab_Stack, GroupStackInTheCommand.transform.localPosition, Quaternion.identity) as StackObject;
    stack.transform.SetParent(GroupStackInTheCommand.transform);
    stack.name = "StackPanel";
    RectTransform rect = stack.GetComponent<RectTransform>();
    rect.sizeDelta = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, 0);
    rect.anchoredPosition = new Vector2(0, 0);
    rect.anchorMin = new Vector2(0, 0);
    rect.anchorMax = new Vector2(1, 1);
    stack.ConstructStack(player, target, command_name, stack_timer, sudden_timer);
    stack.gameObject.SetActive(true);

    this.NowStackInTheCommand = true;
    GroupStackInTheCommand.SetActive(true);
  }

  private void LogicInvalidate()
  {
    UpdateTimerSpeed();

    // ポテンシャル・ポイントの更新
    if (One.TF.AvailablePotentialGauge)
    {
      if (groupPotentialEnergy.activeInHierarchy == false)
      {
        groupPotentialEnergy.SetActive(true);
      }
      if (this.imgPotentialEnergy != null)
      {
        float dx = (float)One.TF.PotentialEnergy / (float)One.TF.MaxPotentialEnergy;
        if (dx < 0.10f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_0"); }
        if (0.10f <= dx && dx < 0.20f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_10"); }
        if (0.20f <= dx && dx < 0.30f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_20"); }
        if (0.30f <= dx && dx < 0.40f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_30"); }
        if (0.40f <= dx && dx < 0.50f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_40"); }
        if (0.50f <= dx && dx < 0.60f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_50"); }
        if (0.60f <= dx && dx < 0.70f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_60"); }
        if (0.70f <= dx && dx < 0.80f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_70"); }
        if (0.80f <= dx && dx < 0.90f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_80"); }
        if (0.90f <= dx && dx < 1.00f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_90"); }
        if (dx >= 1.00f) { this.imgPotentialEnergy.sprite = Resources.Load<Sprite>("Energy_100"); }
      }
      if (this.txtPotentialEnergy)
      {
        float dx = (float)One.TF.PotentialEnergy / (float)One.TF.MaxPotentialEnergy;
        int dx_percent = (int)(dx * 100.0f);
        this.txtPotentialEnergy.text = dx_percent.ToString() + " %";
      }
    }
    else
    {
      groupPotentialEnergy.SetActive(false);
    }

    // プレイヤー関連
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      // プレイヤーのリソースゲージ値を更新する。
      AllList[ii].MaxLifeCheck();
      AllList[ii].UpdateLife();
      AllList[ii].UpdatePlayerInstantPoint();
      AllList[ii].UpdateActionPoint();
      AllList[ii].UpdateEnergyPoint();
      AllList[ii].UpdateManaPoint();
      AllList[ii].UpdateSkillPoint();
      // プレイヤーのステータス表示を更新する。
      if (AllList[ii].Target != null)
      {
        if (AllList[ii].txtTargetName != null)
        {
          AllList[ii].txtTargetName.text = AllList[ii].Target.FullName;
        }
        float dx = (float)AllList[ii].Target.CurrentLife / (float)AllList[ii].Target.MaxLife;
        if (AllList[ii].imgTargetLifeGauge != null)
        {
          AllList[ii].imgTargetLifeGauge.rectTransform.localScale = new Vector2(dx, 1.0f);
        }
      }
    }

    // キャラクターの死亡判定をチェックする。
    for (int ii = 0; ii < this.PlayerList.Count; ii++)
    {
      if (this.PlayerList[ii].CurrentLife <= 0)
      {
        this.PlayerList[ii].DeadPlayer();
      }
    }
    bool detectEnemyDead = false;
    for (int ii = 0; ii < this.EnemyList.Count; ii++)
    {
      if (this.EnemyList[ii].CurrentLife <= 0)
      {
        if (this.EnemyList[ii].Dead == false)
        {
          detectEnemyDead = true;
        }
        this.EnemyList[ii].DeadPlayer();
      }
    }

    if (detectEnemyDead)
    {
      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        for (int jj = 0; jj < this.EnemyList.Count; jj++)
        {
          if (this.EnemyList[jj].Dead == false)
          {
            PlayerList[ii].Target = this.EnemyList[jj];
            break;
          }
        }
      }
    }
  }

  private Character SearchOpponentForEnemy(Character player, List<Character> player_list)
  {
    if (player.TargetSelectType == Fix.TargetSelectType.Behind)
    {
      Debug.Log("Detect behind targetting");
      for (int ii = player_list.Count - 1; ii >= 0; ii--)
      {
        if (player_list[ii].Dead == false)
        {
          return player_list[ii];
        }
      }
    }
    else
    {
      Debug.Log("Detect normal targetting");
      for (int ii = 0; ii < player_list.Count; ii++)
      {
        if (player_list[ii].Dead == false)
        {
          return player_list[ii];
        }
      }
    }
    return null;
  }

  private void CharacterLinkToGUI()
  {

  }

  /// <summary>
  /// アクションボタンのオブジェクト情報を設定します。
  /// </summary>
  private void SetupActionCommandButton(NodeActionCommand button, string command_name)
  {
    Image[] imageList = button.GetComponentsInChildren<Image>();
    for (int ii = 0; ii < imageList.Length; ii++)
    {
      imageList[ii].sprite = Resources.Load<Sprite>(command_name);
      imageList[ii].name = command_name;
    }
  }

  /// <summary>
  /// パーティグループが生存しているかどうかをチェックします。
  /// </summary>
  /// <returns>true:生存 false:全滅</returns>
  private bool CheckGroupAlive(List<Character> group_list)
  {
    for (int ii = 0; ii < group_list.Count; ii++)
    {
      if (group_list[ii].CurrentLife > 0)
      {
        return true;
      }
    }
    return false;
  }

  private void ExecPlayerCommand(Character player, Character target, string command_name)
  {
    ExecPlayerCommand_Origin(player, target, command_name);

    // GaleWindなら２回行動。GaleWind自体は２度掛けしない。
    if (player.IsGaleWind && command_name != Fix.GALE_WIND)
    {
      ExecPlayerCommand_Origin(player, target, command_name);
    }
  }

  /// <summary>
  /// プレイヤーコマンドを実行します。
  /// </summary>
  private void ExecPlayerCommand_Origin(Character player, Character target, string command_name)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + player?.FullName);

    if (player == null)
    {
      Debug.Log("Player is null, then no action.");
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      return;
    }
    if (ActionCommand.GetTiming(player.CurrentActionCommand) == ActionCommand.TimingType.Sorcery)
    {
      if (player.CurrentInstantPoint < player.MaxInstantPoint)
      {
        Debug.Log("Timing Sorcery and not enough CurrentInstantPoint, then no action.");
        StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
        return;
      }
      else
      {
        // ソーサリータイミング実行によるインスタント消費はプレイヤー意志によるものであるため、EverflowMindなどの効果の対象とする。
        BuffImage everflowMind = player.IsEverflowMind;
        if (everflowMind != null)
        {
          player.CurrentInstantPoint = everflowMind.EffectValue * player.MaxInstantPoint;
        }
        else
        {
          player.CurrentInstantPoint = SecondaryLogic.MagicSpellFactor(player) * player.MaxInstantPoint;
        }
        player.UpdateActionPointGauge();
      }
    }

    if (ActionCommand.IsTarget(command_name) == ActionCommand.TargetType.Enemy &&　target == null)
    {
      Debug.Log("Target is null, then no action.");
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      return;
    }
    if (target != null && target.Dead && command_name != Fix.RESURRECTION)
    {
      Debug.Log("Target is dead, then no action.");
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      return;
    }

    // コマンド名指定が無い場合は、プレイヤーが現在選択しているアクションコマンドを実行する。
    if (command_name == string.Empty)
    {
      command_name = player.CurrentActionCommand;
    }

    if (command_name == string.Empty)
    {
      Debug.Log("command_name is empty, then no action.");
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      return;
    }

    if (player.IsBind && ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Skill)
    {
      // サークル・オブ・セレニティは対象外。
      if (command_name == Fix.CIRCLE_OF_SERENITY)
      {
        // skip
      }
      else
      {
        StartAnimation(player.objGroup.gameObject, Fix.BATTLE_BIND, Fix.COLOR_NORMAL);
        return;
      }
    }

    if (player.IsSilent && ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Magic)
    {
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_SILENT, Fix.COLOR_NORMAL);
      return;
    }

    // アクションポイントが不足している場合、行動ミスとする。
    //if (player.CurrentActionPoint < ActionCommand.GetCost(command_name))
    //{
    //  StartAnimation(player.objGroup.gameObject, Fix.BATTLE_AP_LESS, Fix.COLOR_NORMAL);
    //  return;
    //}
    //else
    //{
    //  player.CurrentActionPoint -= ActionCommand.GetCost(command_name);
    //}

    // ブラック・コントラクトがかかっていれば、SPは消費しない。
    // todo ブラック・コントラクトは魔法ポイントを消費しない。スキルポイントも消費しないかどうかを決めるべきである。
    if (player.IsBlackContract)
    {
      Debug.Log("IsBlackContract was detected, then no spend Mana/Skill point.");
      // 何もしない
    }
    else
    {
      if (ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Magic)
      {
        if (player.CurrentManaPoint < ActionCommand.Cost(command_name, player))
        {
          Debug.Log("NO Mana-Point: [" + command_name + "] " + player.CurrentManaPoint + " < " + ActionCommand.Cost(command_name, player));
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MANAPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        player.CurrentManaPoint -= ActionCommand.Cost(command_name, player);
      }
      else if (ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Skill)
      {
        if (player.CurrentSkillPoint < ActionCommand.Cost(command_name, player))
        {
          Debug.Log("NO Skill-Point: [" + command_name + "] " + player.CurrentSkillPoint + " < " + ActionCommand.Cost(command_name, player));
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_SKILLPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        player.CurrentSkillPoint -= ActionCommand.Cost(command_name, player);
      }
    }

    if (player.Ally == Fix.Ally.Ally)
    {
      if (command_name == Fix.STAY || command_name == Fix.DEFENSE)
      {
        // 待機と防御はポテンシャル・ゲージへ加算しない。通常攻撃は加算するので、カテゴリタイプ通常ではなく個別で記載。
      }
      else
      {
        One.TF.PotentialEnergy += player.GetPotentialEnergy();
      }
    }

    // ブラッド・サインによる効果
    if (player.IsBloodSign && player.SearchFieldBuff(Fix.SHINING_HEAL) == null)
    {
      ExecSlipDamage(player, player.IsBloodSign.EffectValue);
    }
    // スリップによる効果
    if (player.IsSlip && (command_name != Fix.STAY && command_name != Fix.DEFENSE) && player.SearchFieldBuff(Fix.SHINING_HEAL) == null)
    {
      ExecSlipDamage(player, player.IsSlip.EffectValue);
    }
    if (player.IsPenetrationArrow && (command_name != Fix.STAY && command_name != Fix.DEFENSE) && player.SearchFieldBuff(Fix.SHINING_HEAL) == null)
    {
      ExecSlipDamage(player, player.IsPenetrationArrow.EffectValue);
    }

    Fix.CriticalType critical = Fix.CriticalType.Random;
    BuffImage fortune = player.IsFortuneSpirit;
    if (ActionCommand.IsDamage(command_name) && fortune != null)
    {
      Debug.Log("Detect FortuneSpirit, then Absolute Critical.");
      critical = Fix.CriticalType.Absolute;
      fortune.CumulativeDown(1);
    }
    BuffImage syutyuDanzetsu = player.IsSyutyuDanzetsu;
    if (ActionCommand.IsDamage(command_name) && syutyuDanzetsu)
    {
      Debug.Log("Detect IsSyutyuDanzetsu, then Absolute Critical.");
      critical = Fix.CriticalType.Absolute;
      player.NowExecSyutyuDanzetsu = true;
    }

    this.GlobalAnimationChain++; // コマンド実行をグローバルアニメーションチェインの対象とするが、これが最適かどうかは分からない。
    #region "コマンド実行"
    List<Character> target_list = null;
    int rand = 0;
    bool success = false;
    Debug.Log("Player: " + player.FullName + " Command: " + command_name);
    switch (command_name)
    {
      #region "一般"
      case Fix.NORMAL_ATTACK:
        ExecNormalAttack(player, target, SecondaryLogic.NormalAttack(player), Fix.DamageSource.Physical, false, critical);
        break;

      case Fix.MAGIC_ATTACK:
        ExecMagicAttack(player, target, SecondaryLogic.MagicAttack(player), Fix.DamageSource.Colorless, false, critical);
        break;

      case Fix.DEFENSE:
        player.DecisionDefense();
        break;

      case Fix.STAY:
        // 何もしない
        break;
      #endregion

      #region "アクションコマンド"
      #region "Delve I"
      case Fix.FIRE_BALL:
        ExecFireBall(player, target, critical);
        break;

      case Fix.ICE_NEEDLE:
        ExecIceNeedle(player, target, critical);
        break;

      case Fix.FRESH_HEAL:
        ExecFreshHeal(player, target);
        break;

      case Fix.SHADOW_BLAST:
        ExecShadowBlast(player, target, critical);
        break;

      case Fix.AIR_CUTTER:
        ExecAirCutter(player, target, critical);
        break;

      case Fix.ROCK_SLAM:
        ExecRockSlum(player, target, critical);
        break;

      case Fix.STRAIGHT_SMASH:
        ExecStraightSmash(player, target, critical);
        break;

      case Fix.HUNTER_SHOT:
        ExecHunterShot(player, target, critical);
        break;

      case Fix.LEG_STRIKE:
        ExecLegStrike(player, target, critical);
        break;

      case Fix.VENOM_SLASH:
        ExecVenomSlash(player, target, critical);
        break;

      case Fix.ENERGY_BOLT:
        ExecEnergyBolt(player, target, critical);
        break;

      case Fix.SHIELD_BASH:
        ExecShieldBash(player, target, critical);
        break;

      case Fix.AURA_OF_POWER:
        ExecAuraOfPower(player, target);
        break;

      case Fix.DISPEL_MAGIC:
        ExecDispelMagic(player, target);
        break;

      case Fix.TRUE_SIGHT:
        ExecTrueSight(player, target);
        break;

      case Fix.HEART_OF_LIFE:
        ExecHeartOfLife(player, target);
        break;

      case Fix.DARKNESS_CIRCLE:
        ExecDarknessCircle(player, target, target.objFieldPanel);
        break;

      case Fix.ORACLE_COMMAND:
        ExecOracleCommand(player, target);
        break;
      #endregion

      #region "Delve II"
      case Fix.FLAME_BLADE:
        Debug.Log(Fix.FLAME_BLADE);
        ExecFlameBlade(player, target);
        break;

      case Fix.PURE_PURIFICATION:
        ExecPurePurification(player, target);
        break;

      case Fix.BLOOD_SIGN:
        ExecBloodSign(player, target);
        break;

      case Fix.DIVINE_CIRCLE:
        ExecDivineCircle(player, target, player.objFieldPanel);
        break;

      case Fix.SKY_SHIELD:
        ExecSkyShield(player, target);
        break;

      case Fix.COUNTER_ATTACK:
        ExecCounterAttack(player, GroupStackInTheCommand.GetComponentsInChildren<StackObject>());
        break;

      case Fix.FLASH_COUNTER:
        ExecFlashCounter(player, GroupStackInTheCommand.GetComponentsInChildren<StackObject>());
        break;

      case Fix.STANCE_OF_THE_BLADE:
        ExecStanceOfTheBlade(player);
        break;

      case Fix.SPEED_STEP:
        ExecSpeedStep(player);
        break;

      case Fix.STANCE_OF_THE_GUARD:
        ExecStanceOfTheGuard(player);
        break;

      case Fix.MULTIPLE_SHOT:
        target_list = GetOpponentGroup(player);
        ExecMultipleShot(player, target_list, critical);
        break;

      case Fix.LEYLINE_SCHEMA:
        ExecLeylineSchema(player, player.objFieldPanel);
        break;

      case Fix.INVISIBLE_BIND:
        ExecInvisibleBind(player, target, critical);
        break;

      case Fix.FORTUNE_SPIRIT:
        ExecFortuneSpirit(player, target);
        break;

      case Fix.SPIRITUAL_REST:
        ExecSpiritualRest(player, target);
        break;
      #endregion

      #region "Delve III"
      case Fix.METEOR_BULLET:
        target_list = GetOpponentGroup(player);
        ExecMeteorBullet(player, target_list, critical);
        break;

      case Fix.BLUE_BULLET:
        ExecBlueBullet(player, target, critical);
        break;

      case Fix.HOLY_BREATH:
        target_list = GetAllyGroup(player);
        ExecHolyBreath(player, target_list);
        break;

      case Fix.BLACK_CONTRACT:
        ExecBlackContract(player);
        break;

      case Fix.WORD_OF_POWER:
        ExecWordOfPower(player, target, critical);
        break;

      case Fix.SIGIL_OF_THE_PENDING:
        ExecSigilOfThePending(player, target);
        break;

      case Fix.DOUBLE_SLASH:
        ExecDoubleSlash(player, target, critical);
        break;

      case Fix.CONCUSSIVE_HIT:
        ExecConcussiveHit(player, target, critical);
        break;

      case Fix.BONE_CRUSH:
        ExecBoneCrush(player, target, critical);
        break;

      case Fix.EYE_OF_THE_ISSHIN:
        ExecEyeOfTheIsshin(player, target);
        break;

      case Fix.VOICE_OF_VIGOR:
        target_list = GetAllyGroup(player);
        ExecVoiceOfVigor(player, target_list);
        break;

      case Fix.UNSEEN_AID:
        target_list = GetAllMember();
        ExecUnseenAid(player, target_list);
        break;
      #endregion

      #region "Delve IV"
      case Fix.GALE_WIND:
        ExecGaleWind(player);
        break;

      case Fix.VOLCANIC_BLAZE:
        target_list = GetOpponentGroup(player);
        ExecVolcanicBlaze(player, target_list, target.objFieldPanel, critical);
        break;

      case Fix.FREEZING_CUBE:
        ExecFreezingCube(player, target, target.objFieldPanel, critical);
        break;

      case Fix.IRON_BUSTER:
        target_list = GetOpponentGroup(player);
        ExecIronBuster(player, target, target_list, critical);
        break;

      case Fix.ANGELIC_ECHO:
        target_list = GetAllyGroup(player);
        ExecAngelicEcho(player, target_list, player.objFieldPanel);
        break;

      case Fix.CURSED_EVANGILE:
        ExecCursedEvangile(player, target, critical);
        break;

      case Fix.PENETRATION_ARROW:
        ExecPenetrationArrow(player, target, critical);
        break;

      case Fix.CIRCLE_OF_SERENITY:
        target_list = GetAllyGroup(player);
        ExecCircleOfTheSerenity(player, target_list, player.objFieldPanel); 
        break;

      case Fix.WILL_AWAKENING:
        ExecWillAwakening(player, target);
        break;

      case Fix.PHANTOM_OBORO:
        ExecPhantomOboro(player);
        break;

      case Fix.DEADLY_DRIVE:
        ExecDeadlyDrive(player);
        break;

      case Fix.DOMINATION_FIELD:
        ExecDominationField(player, player.objFieldPanel);
        break;
      #endregion

      #region "Delve  V"
      case Fix.FLAME_STRIKE:
        ExecFlameStrike(player, target, critical);
        break;

      case Fix.FROST_LANCE:
        ExecFrostLance(player, target, critical);
        break;

      case Fix.SHINING_HEAL:
        ExecShiningHeal(player, target, critical, target.objFieldPanel);
        break;

      case Fix.CIRCLE_OF_THE_DESPAIR:
        ExecCircleOfTheDespair(player, target.objFieldPanel);
        break;

      case Fix.COUNTER_DISALLOW:
        ExecCounterDisallow(player, GroupStackInTheCommand.GetComponentsInChildren<StackObject>());
        break;

      case Fix.RAGING_STORM:
        target_list = GetOpponentGroup(player);
        ExecRagingStorm(player, target_list, player.objFieldPanel, critical);
        break;

      case Fix.PRECISION_STRIKE:
        ExecPrecisionStrike(player, target);
        break;

      case Fix.UNINTENTIONAL_HIT:
        ExecUnintentionalHit(player, target, critical);
        break;

      case Fix.HARDEST_PARRY:
        ExecHardestParry(player, GroupStackInTheCommand.GetComponentsInChildren<StackObject>());
        break;

      case Fix.EVERFLOW_MIND:
        ExecEverflowMind(player, target);
        break;

      case Fix.INNER_INSPIRATION:
        ExecInnerInspiration(player, target);
        break;

      case Fix.SEVENTH_PRINCIPLE:
        ExecSeventhPrinciple(player, target);
        break;

      #endregion

      #region "Other"
      case Fix.ZERO_IMMUNITY:
        ExecZeroImmunity(player, target);
        break;

      case Fix.IRREGULAR_STEP:
        ExecIrregularStep(player, target);
        break;

      case Fix.AETHER_DRIVE:
      case Fix.AETHER_DRIVE_JP:
        ExecAetherDrive(player, target, player.objFieldPanel);
        break;

      case Fix.KILLING_WAVE:
      case Fix.KILLING_WAVE_JP:
        ExecKillingWave(player, target_list, target.objFieldPanel);
        break;

      case Fix.STORM_ARMOR:
        ExecStormArmor(player, target);
        break;

      case Fix.MUTE_IMPULSE:
        ExecMuteImpulse(player, target, critical);
        break;
      #endregion
      #endregion

      case Fix.DARK_AURA:
        ExecDarkAura(player, target);
        break;

      case Fix.SONIC_PULSE:
      case Fix.SONIC_PULSE_JP:
        ExecSonicPulse(player, target, critical);
        break;

      case Fix.LAND_SHATTER:
      case Fix.LAND_SHATTER_JP:
        ExecLandShatter(player, target, critical);
        break;

      #region "元核"
      case Fix.ARCHETYPE_EIN_1:
        this.AnimationArchetectProgress = 100;
        this.NowAnimationArchetect = true;
        this.GroupArchetectAnimation.SetActive(true);
        ExecEinShutyuDanzetsu(player, target);
        break;

      case Fix.ARCHETYPE_LANA_1:
        ExecLanaPerfectSpell(player, target);
        break;

      case Fix.ARCHETYPE_EONE_1:
        ExecEoneMuinSong(player, target);
        break;

      case Fix.ARCHETYPE_BILLY_1:
        ExecBillyVictoryStyle(player, target);
        break;

      case Fix.ARCHETYPE_ADEL_1:
        ExecAdelEndlessMemory(player, target);
        break;

      case Fix.ARCHETYPE_RO_1:
        ExecRoStanceOfMuni(player, target);
        break;

      #endregion

      #region "アイテム使用"
      case Fix.SMALL_RED_POTION:
      case Fix.NORMAL_RED_POTION:
      case Fix.LARGE_RED_POTION:
      case Fix.HUGE_RED_POTION:
      case Fix.HQ_RED_POTION:
      case Fix.THQ_RED_POTION:
      case Fix.PERFECT_RED_POTION:
        ExecUseRedPotion(player, command_name);
        break;

      case Fix.SMALL_BLUE_POTION:
      case Fix.NORMAL_BLUE_POTION:
      case Fix.LARGE_BLUE_POTION:
      case Fix.HUGE_BLUE_POTION:
      case Fix.HQ_BLUE_POTION:
      case Fix.THQ_BLUE_POTION:
      case Fix.PERFECT_BLUE_POTION:
        ExecUseBluePotion(player, command_name);
        break;

      case Fix.SMALL_GREEN_POTION:
      case Fix.NORMAL_GREEN_POTION:
      case Fix.LARGE_GREEN_POTION:
      case Fix.HUGE_GREEN_POTION:
      case Fix.HQ_GREEN_POTION:
      case Fix.THQ_GREEN_POTION:
      case Fix.PERFECT_GREEN_POTION:
        ExecUseGreenPotion(player, command_name);
        break;

      case Fix.PURE_CLEAN_WATER:
        ExecPureCleanWater(player);
        break;
      case Fix.PURE_SINSEISUI:
        ExecSinseisui(player);
        break;
      #endregion

      #region "モンスターアクション"
      // 以下、モンスターアクションはmagic numberでよい
      case Fix.COMMAND_HIKKAKI:
        ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_GREEN_NENEKI:
        ExecBuffPoison(player, target, 2, 7);
        break;

      case Fix.COMMAND_KANAKIRI:
        ExecBuffDizzy(player, target, 2, 0.30f);
        break;

      case Fix.COMMAND_WILD_CLAW:
        ExecNormalAttack(player, target, 1.35f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_KAMITSUKI:
        ExecNormalAttack(player, target, 1.40f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_TREE_SONG:
        success = ExecMagicAttack(player, target, 0.8f, Fix.DamageSource.Colorless, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSleep(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_SUN_FIRE:
        ExecMagicAttack(player, target, 1.35f, Fix.DamageSource.Fire, false, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_TOSSHIN:
        success = ExecNormalAttack(player, target, 1.10f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_FEATHER_WING:
        success = ExecMagicAttack(player, target, 0.5f, Fix.DamageSource.Colorless, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSleep(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_DASH_KERI:
        success = ExecNormalAttack(player, target, 1.1f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffDizzy(player, target, 1, 0.30f);
        }
        break;

      case Fix.COMMAND_SUITSUKU_TSUTA:
        success = ExecNormalAttack(player, target, 0.5f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSlow(player, target, 2, 0.5f);
        }
        break;

      case Fix.COMMAND_SPIDER_NET:
        success = ExecNormalAttack(player, target, 0.5f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffBind(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_POISON_KOKE:
        ExecBuffPoison(player, target, 3, 18);
        break;

      case Fix.COMMAND_CONTINUOUS_ATTACK:
        for (int jj = 0; jj < 2; jj++)
        {
          // ランダムで対象を選んで当てる
          List<Character> list = GetOpponentGroup(player);
          ExecNormalAttack(player, list[AP.Math.RandomInteger(list.Count)], 0.85f, Fix.DamageSource.Physical, false, critical);
        }
        break;

      case Fix.COMMAND_FIRE_EMISSION:
        ExecMagicAttack(player, target, 1.2f, Fix.DamageSource.Fire, false, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_SUPER_TOSSHIN:
        success = ExecNormalAttack(player, target, 1.5f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_POISON_RINPUN:
        ExecBuffPoison(player, target, 3, 33);
        break;

      case Fix.COMMAND_YOUEN_FIRE:
        for (int jj = 0; jj < 5; jj++)
        {
          // ランダムで対象を選んで当てる
          // ダメージアニメーション速度を上げる。
          List<Character> list = GetOpponentGroup(player);
          ExecMagicAttack(player, list[AP.Math.RandomInteger(list.Count)], 0.5, Fix.DamageSource.Fire, false, Fix.CriticalType.None, 25);
        }
        break;

      case Fix.COMMAND_BLAZE_DANCE:
        BuffUpFire(player, player, 5, 1.20f);
        break;

      case Fix.COMMAND_DRILL_CYCLONE:
        success = ExecNormalAttack(player, target, 1.50f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_RUMBLE_MACHINEGUN:
        for (int jj = 0; jj < 5; jj++)
        {
          rand = AP.Math.RandomInteger(PlayerList.Count);
          ExecNormalAttack(player, PlayerList[rand], 1.0f, Fix.DamageSource.Physical, false, Fix.CriticalType.Random);
        }
        break;

      case Fix.COMMAND_STRUGGLE_VOICE:
        for (int jj = 0; jj < PlayerList.Count; jj++)
        {
          rand = AP.Math.RandomInteger(3);
          if (rand == 0)
          {
            ExecBuffDizzy(player, PlayerList[jj], 2, 0.30f);
          }
          else if (rand == 1)
          {
            ExecBuffSilent(player, PlayerList[jj], 2, 0);
          }
          else if (rand == 2)
          {
            ExecBuffBind(player, PlayerList[jj], 2, 0);
          }
        }
        break;

      case Fix.COMMAND_GAREKI_TSUBUTE:
        success = ExecNormalAttack(player, target, 0.80f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_SHADOW_SPEAR:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.DarkMagic, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSilent(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_MIDARE_GIRI:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecNormalAttack(player, target_list[jj], 0.9f, Fix.DamageSource.Physical, false, critical);
        }
        break;

      case Fix.COMMAND_STINKY_BREATH:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          rand = AP.Math.RandomInteger(100);
          if (rand >= 50)
          {
            ExecBuffBind(player, target_list[jj], 2, 0);
          }
          else
          {
            StartAnimation(target_list[jj].objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
          }
        }
        break;

      case Fix.COMMAND_MIRROR_SHIELD:
        target_list = GetAllyGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecBuffMagicDefenceUp(player, target_list[jj], 5, 1.25f);
        }
        break;

      case Fix.COMMAND_HAND_CANNON:
        success = ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffDizzy(player, target, 2, 0.30f);
        }
        break;

      case Fix.COMMAND_SAIMIN_DANCE:
        ExecBuffSleep(player, target, 2, 0);
        break;

      case Fix.COMMAND_POISON_NEEDLE:
        success = ExecNormalAttack(player, target, 1.10f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffPoison(player, target, 3, 33);
        }
        break;

      case Fix.COMMAND_CHARGE_LANCE:
        ExecNormalAttack(player, target, 1.0f, Fix.DamageSource.Physical, false, Fix.CriticalType.Absolute);
        break;

      case Fix.COMMAND_SPIKE_SHOT:
        success = ExecNormalAttack(player, target, 1.4f, Fix.DamageSource.Physical, false, critical);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_JUBAKU_ON:
        success = ExecMagicAttack(player, target, 0.9f, Fix.DamageSource.DarkMagic, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffPhysicalDefenseDown(player, target, 5, 0.75f);
        }
        break;

      case Fix.COMMAND_ZINARI:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecNormalAttack(player, target_list[jj], 0.7f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_BOUHATSU:
        ExecNormalAttack(player, player, 2.0f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        ExecNormalAttack(player, target, 2.0f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_THUNDER_CLOUD:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 0.8f, Fix.DamageSource.Wind, false, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_SURUDOI_HIKKAKI:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          success = ExecNormalAttack(player, target_list[jj], 0.8f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
          if (success)
          {
            rand = AP.Math.RandomInteger(100);
            if (rand >= 60)
            {
              ExecBuffSilent(player, target_list[jj], 2, 0);
            }
          }
        }
        break;

      case Fix.COMMAND_HAGESHII_KAMITSUKI:
        success = ExecNormalAttack(player, target, 0.8f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSlip(player, target, 3, 25);
        }
        break;

      case Fix.COMMAND_BOLT_FRAME:
        success = ExecMagicAttack(player, target, 1.2f, Fix.DamageSource.Fire, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffPhysicalAttackDown(player, target, 3, 0.75f);
        }
        break;

      case Fix.COMMAND_BOOOOMB:
        if (player.CurrentLife <= 1)
        {
          // モンスター行動なので、ファントム・朧による効果はやらなくて良い。
          ApplyDamage(player, player, player.CurrentLife, false, MAX_ANIMATION_TIME);
        }
        else
        {
          // モンスター行動なので、ファントム・朧による効果はやらなくて良い。
          ApplyDamage(player, player, player.CurrentLife - 1, false, MAX_ANIMATION_TIME);
        }
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 2.0f, Fix.DamageSource.Fire, false, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_STONE_RAIN:
        for (int jj = 0; jj < 3; jj++)
        {
          rand = AP.Math.RandomInteger(PlayerList.Count);
          ExecMagicAttack(player, PlayerList[rand], 0.9f, Fix.DamageSource.Earth, false, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_TARGETTING_SHOT:
        success = ExecNormalAttack(player, target, 1.0f, Fix.DamageSource.Physical, false, critical);
        if (success)
        {
          ExecBuffMagicDefenceDown(player, target, 3, 0.75f);
        }
        break;

      case Fix.COMMAND_POWERED_ATTACK:
        rand = AP.Math.RandomInteger(5);
        if (rand == 0)
        {
          StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
        }
        else
        {
          ExecNormalAttack(player, target, 0.5f + (0.5f * rand), Fix.DamageSource.Physical, false, critical);
        }
        break;

      case Fix.COMMAND_SUSPICIOUS_VIAL:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          rand = AP.Math.RandomInteger(5);
          if (rand == 0)
          {
            ExecBuffDizzy(player, target_list[jj], 2, 0.30f);
          }
          else if (rand == 1)
          {
            ExecBuffSilent(player, target_list[jj], 2, 0);
          }
          else if (rand == 2)
          {
            ExecBuffSlow(player, target_list[jj], 2, 0.5f);
          }
          else if (rand == 3)
          {
            ExecBuffStun(player, target_list[jj], 1, 0);
          }
          else
          {
            ExecBuffSleep(player, target_list[jj], 1, 0);
          }
        }
        break;

      case Fix.COMMAND_SPAAAARK:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.Fire, false, critical);
        }
        // 相手に魔法攻撃が当たったかどうかに関係なく、自分自身へのBUFFは適用される。
        ExecBuffMagicAttackUp(player, player, Fix.INFINITY, 1.10f);
        break;

      case Fix.COMMAND_SUPER_RANDOM_CANNON:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < 4; jj++)
        {
          double additional = AP.Math.RandomReal() / 2.0f;
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.8f + additional, Fix.DamageSource.Physical, false, critical);
        }
        break;

      case Fix.COMMAND_ELECTRO_RAILGUN:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Fire, false, Fix.CriticalType.None);
        if (success)
        {
          rand = AP.Math.RandomInteger(100);
          if (rand <= 25)
          {
            ExecBuffBind(player, target, 2, 0);
          }
          else if (rand <= 50)
          {
            ExecBuffStun(player, target, 1, 0);
          }
          else if (rand <= 75)
          {
            ExecBuffSilent(player, target, 2, 0);
          }
        }
        break;

      case Fix.COMMAND_LIGHTNING_OUTBURST:
        //PanelEnemyField.AddBuff(prefab_Buff, Fix.BUFF_LIGHTNING_OUTBURST, Fix.INFINITY, 10, 0, 0);
        //StartAnimation(PanelEnemyField.gameObject, Fix.COMMAND_LIGHTNING_OUTBURST, Fix.COLOR_NORMAL);
        PanelPlayerField.AddBuff(prefab_Buff, Fix.BUFF_LIGHTNING_OUTBURST, Fix.INFINITY, 10, 0, 0);
        StartAnimation(PanelPlayerField.gameObject, Fix.COMMAND_LIGHTNING_OUTBURST, Fix.COLOR_NORMAL);
        break;

      case Fix.COMMAND_WILD_STORM:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.Wind, false, critical);
        }
        break;

      case Fix.COMMAND_YOUKAIEKI:
        success = ExecMagicAttack(player, target, 0.60f, Fix.DamageSource.Earth, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffBattleSpeedDown(player, target, 2, 0.7f);
          ExecBuffBattleResponseDown(player, target, 2, 0.7f);
        }
        break;

      case Fix.COMMAND_POISON_TONGUE:
        ExecNormalAttack(player, target, 0.80f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        ExecBuffPoison(player, target, 3, 70);
        break;

      case Fix.COMMAND_CONSTRICT:
        success = ExecNormalAttack(player, target, 0.7f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          rand = AP.Math.RandomInteger(100);
          if (rand <= 20)
          {
            ExecBuffStun(player, target, 1, 0);
            ExecBuffBind(player, target, 2, 0);
            ExecBuffSlow(player, target, 3, 0.5f);
          }
          else if (rand <= 50)
          {
            ExecBuffBind(player, target, 1, 0);
            ExecBuffSlow(player, target, 2, 0.5f);
          }
          else if (rand <= 100)
          {
            ExecBuffSlow(player, target, 1, 0.5f);
          }
        }
        break;

      case Fix.COMMAND_TAIATARI:
        success = ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_WINDFLARE:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Wind, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSlow(player, target, 2, 0.5f);
        }
        break;

      case Fix.COMMAND_EARTHBOLT:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Earth, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffBind(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_SILENT_SHOT:
        success = ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffFear(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_PHANTOM_SONG:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.Fire, false, critical);
          ExecBuffSilent(player, target_list[jj], 1, 0);
        }
        break;

      case Fix.COMMAND_ENRAGE:
        ExecBuffPhysicalAttackUp(player, player, 3, 1.30f);
        break;

      case Fix.COMMAND_SPLASH_HARMONY:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Wind, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffParalyze(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_RANBOU_CHARGE:
        success = ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffPhysicalDefenseDown(player, target, 5, 0.70f);
        }
        break;

      case Fix.COMMAND_BEAST_STRIKE:
        success = ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSlip(player, target, 3, 50);
        }
        break;

      case Fix.COMMAND_KONSHIN_TOKKAN:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.None, false, critical);
        }
        break;

      case Fix.COMMAND_HUHAI_SINKOU:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.None, false, Fix.CriticalType.None);
        if (success)
        {
          if (target.IsPoison == null)
          {
            ExecBuffPoison(player, target, 3, 50);
          }
          else if (target.IsSlip == null)
          {
            ExecBuffSlip(player, target, 3, 50);
          }
          else if (target.IsFear == null)
          {
            ExecBuffFear(player, target, 1, 0);
          }
        }
        break;

      case Fix.COMMAND_STRONG_SLASH:
        success = ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecNormalAttack(player, target, 0.30f, Fix.DamageSource.Fire, false, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_SHADOW_MIST:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          bool hit = ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.None, false, critical);
          if (hit)
          {
            ExecBuffDizzy(player, target_list[jj], 2, 0.30f);
            ExecBuffSlow(player, target_list[jj], 1, 0.50f);
          }
        }
        break;

      case Fix.COMMAND_ROCK_THROW:
        success = ExecNormalAttack(player, target, 1.40f, Fix.DamageSource.Physical, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_YOUEN_KISS:
        ExecBuffTemptation(player, target, 2, 0);
        break;

      case Fix.COMMAND_POISON_SPORE:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.None, false, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffPoison(player, target, 3, 100);
        }
        break;

      case Fix.COMMAND_GROUND_RUMBLE:
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecNormalAttack(player, target, 0.70f, Fix.DamageSource.Fire, false, Fix.CriticalType.None);
          int random = AP.Math.RandomInteger(3);
          if (random == 0)
          {
            ExecBuffStun(player, target_list[jj], 2, 0);
          }
          else if (rand == 1)
          {
            ExecBuffBind(player, target_list[jj], 2, 0);
          }
          else
          {
            ExecBuffSilent(player, target_list[jj], 2, 0);
          }
        }
        break;

      case Fix.COMMAND_FIRE_BLAST:
        target_list = GetOpponentGroup(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          bool hit = ExecMagicAttack(player, target_list[ii], SecondaryLogic.VolcanicBlaze(player), Fix.DamageSource.Fire, false, critical);
          if (hit)
          {
            ExecBuffPhysicalDefenseDown(player, target_list[ii], 5, 0.70f);
          }
        }
        target_list[0].objFieldPanel.AddBuff(prefab_Buff, Fix.VOLCANIC_BLAZE, SecondaryLogic.VolcanicBlaze_Turn(player), SecondaryLogic.VolcanicBlaze_Effect(player), PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.VolcanicBlaze_Effect2(player), 0);
        StartAnimation(target_list[0].objFieldPanel.gameObject, Fix.VOLCANIC_BLAZE, Fix.COLOR_NORMAL);
        break;

      case Fix.COMMAND_RENSOU_TOSSHIN:
        for (int jj = 0; jj < 3; jj++)
        {
          // ランダムで対象を選んで当てる
          List<Character> list = GetOpponentGroup(player);
          ExecNormalAttack(player, list[AP.Math.RandomInteger(list.Count)], 0.90f, Fix.DamageSource.Physical, false, critical);
        }
        break;

      case Fix.COMMAND_VERDANT_VOICE:
        ExecLifeGain(player, player.MaxLife / 20);
        player.objFieldPanel.AddBuff(prefab_Buff, Fix.BUFF_VERDANT_VOICE, Fix.INFINITY, 0, 0, 0);
        break;

      case Fix.COMMAND_BLACK_SPORE:
        target_list = GetOpponentGroup(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          // ExecMagicAttack(player, target_list[ii], SecondaryLogic.VolcanicBlaze(player), Fix.DamageSource.Fire, false, critical);
          target_list[ii].objBuffPanel.AddBuff(prefab_Buff, "BlackSpore", Fix.INFINITY, 0, 0, 0);
        }
        break;

      case Fix.COMMAND_KILL_SPINNING_LANCER:
        ExecNormalAttack(player, target, 5.00f, Fix.DamageSource.Physical, false, critical);
        break;

      case "絶望の魔手":
        ExecBuffSlow(player, target, 10, 0.5f);
        ExecBuffPoison(player, target, 10, 11);
        ExecBuffSlip(player, target, 10, 12);
        ExecBuffFreeze(player, target, 10, 0);
        ExecBuffSilent(player, target, 10, 0);
        ExecBuffBind(player, target, 10, 0);
        break;

      #endregion

      default:
        Debug.Log("Nothing Command: " + command_name);
        StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
        break;
    }
    #endregion
    this.GlobalAnimationChain--; // コマンド実行をグローバルアニメーションチェインの対象とするが、これが最適かどうかは分からない。
  }

  private List<Character> GetAllMember()
  {
    return AllList;
  }

  private List<Character> GetAllyGroup(Character player)
  {
    if (player.Ally == Fix.Ally.Ally)
    {
      return PlayerList;
    }
    //else if (player.Ally == Fix.Ally.Enemy)
    else
    {
      return EnemyList;
    }
  }

  private List<Character> GetOpponentGroup(Character player)
  {
    if (player.Ally == Fix.Ally.Ally)
    {
      return EnemyList;
    }
    //else if (player.Ally == Fix.Ally.Enemy)
    else
    {
      return PlayerList;
    }

  }

  private BuffImage PreCheckFieldEffect(GameObject field_panel, string field_name)
  {
    BuffImage[] buffList = field_panel.GetComponentsInChildren<BuffImage>();
    for (int ii = 0; ii < buffList.Length; ii++)
    {
      if (buffList[ii].BuffName == field_name)
      {
        return buffList[ii];
      }
    }
    return null;
  }

  /// <summary>
  /// アニメーションオブジェクトを生成します。
  /// </summary>
  private void StartAnimation(GameObject targetObj, string message, Color color, int animation_speed = MAX_ANIMATION_TIME)
  {
    DamageObject damageObj = Instantiate(this.prefab_Damage, new Vector3(0, 0, 0), Quaternion.identity) as DamageObject;
    // 対象オブジェクトにリンクさせて位置を設定する。
    damageObj.transform.SetParent(targetObj.transform);
    damageObj.name = "DamageObject";
    RectTransform rect = damageObj.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    rect.anchorMin = new Vector2(0, 1);
    rect.anchorMax = new Vector2(0, 1);
    rect.pivot = new Vector2(0, 1);
    rect.anchoredPosition = new Vector2(0, -AP.Math.RandomInteger(5) * 20.0f);

    // アニメーショングループに再設定してアニメーション表示する。
    if (this.GlobalAnimationChain > 0)
    {
      damageObj.Construct(message, this.GlobalAnimationChain, color, animation_speed);
    }
    else
    {
      damageObj.Construct(message, 0, color, animation_speed);
    }
    damageObj.transform.SetParent(GroupAnimation.transform);
    damageObj.gameObject.SetActive(true);
    this.NowAnimationMode = true;
  }
  private void StartAnimationGroupPanel(GameObject targetObj, string message, Color color, int animation_speed = MAX_ANIMATION_TIME)
  {
    DamageObject damageObj = Instantiate(this.prefab_Damage, new Vector3(0, 0, 0), Quaternion.identity) as DamageObject;
    // 対象オブジェクトにリンクさせて位置を設定する。
    damageObj.transform.SetParent(targetObj.transform);
    damageObj.name = "DamageObject";
    RectTransform rect = damageObj.GetComponent<RectTransform>();
    rect.sizeDelta = new Vector2(150, 100);
    rect.anchoredPosition = new Vector2(0, 0);
    rect.anchorMin = new Vector2(0, 1);
    rect.anchorMax = new Vector2(0, 1);
    rect.pivot = new Vector2(0, 1);
    rect.anchoredPosition = new Vector2(0, 0);

    // アニメーショングループに再設定してアニメーション表示する。
    if (this.GlobalAnimationChain > 0)
    {
      damageObj.Construct(message, this.GlobalAnimationChain, color, animation_speed);
    }
    else
    {
      damageObj.Construct(message, 0, color, animation_speed);
    }
    damageObj.transform.SetParent(GroupAnimation.transform);
    damageObj.gameObject.SetActive(true);
    this.NowAnimationMode = true;
  }

  /// <summary>
  /// アニメーションを実行します。
  /// </summary>
  private void ExecAnimation()
  {
    bool detect = false;
    int chainNumber = 0;
    DamageObject[] damageObj = GroupAnimation.GetComponentsInChildren<DamageObject>();
    for (int ii = 0; ii < damageObj.Length; ii++)
    {
      if (damageObj[ii].Timer > 0)
      {
        // 最初に検知したチェインナンバーと同じものはアニメーション実行する。
        if ((chainNumber) > 0 && (damageObj[ii].ChainNumber != chainNumber))
        {
          continue;
        }

        damageObj[ii].FirstLook = true;
        damageObj[ii].Timer--;
        RectTransform rect = damageObj[ii].txtMessage.GetComponent<RectTransform>();
        float moveX = 0.0f;
        if (damageObj[ii].Timer <= MAX_ANIMATION_TIME - 15) { moveX = 0.0f; }
        else if (damageObj[ii].Timer <= MAX_ANIMATION_TIME - 10) { moveX = 1.0f; }
        else if (damageObj[ii].Timer <= MAX_ANIMATION_TIME - 5) { moveX = 2.0f; }
        else { moveX = 7.0f; }

        rect.position = new Vector3(rect.position.x + moveX, rect.position.y, rect.position.z);

        detect = true;
        chainNumber = damageObj[ii].ChainNumber;

        if (damageObj[ii].Timer <= 0)
        {
          //EndAnimation(damageObj[ii].txtMessage);
          RectTransform rect2 = damageObj[ii].txtMessage.GetComponent<RectTransform>();
          rect2.position = new Vector3(0, rect.position.y, rect.position.z);
          damageObj[ii].txtMessage.gameObject.SetActive(false);
          Destroy(damageObj[ii].gameObject);
          damageObj[ii] = null;
        }

        if (chainNumber <= 0)
        {
          break;
        }
      }
    }

    // 一つもアニメーションが存在しない場合は、終了します。
    if (detect == false)
    {
      this.NowAnimationMode = false;
    }
  }

  private void ExecStackInTheCommand()
  {
    // スタックが無くなれば、終了とする。
    StackObject[] stackList = GroupStackInTheCommand.GetComponentsInChildren<StackObject>();
    if (stackList.Length <= 0)
    {
      this.NowStackInTheCommand = false;
      GroupStackInTheCommand.SetActive(false);
      return;
    }

    if (stackList[stackList.Length - 1].StackTimer <= 0)
    {
      if (stackList[stackList.Length - 1].SuddenTimer > 0)
      {
        stackList[stackList.Length - 1].SuddenTimer--;
        stackList[stackList.Length - 1].txtStackTime.text = "";
        return;
      }
      Debug.Log("curren is existed->Destroy it: " + stackList.Length.ToString());
      Destroy(stackList[stackList.Length - 1].gameObject);
      stackList[stackList.Length - 1] = null;
      return;
    }

    // スタックがあれば、最後に積まれたスタックを優先処理する。
    int num = stackList.Length - 1;
    stackList[num].StackTimer--;
    stackList[num].txtStackTime.text = stackList[num].StackTimer.ToString();

    // フロスト・ランス効果がある場合、インスタントはカウンターされる。
    // todo ただし、例外で無効化してくる効果も考えられるため、後にロジック改版。
    BuffImage frostLance = stackList[num].Player?.IsFrostLance ?? null;
    BuffImage counterDisallow = stackList[num].Player?.IsCounterDisallow ?? null;
    if (frostLance != null || counterDisallow != null)
    {
      Debug.Log("ExecStackInTheCommand frostLance phase length: " + stackList.Length + " " + stackList[stackList.Length - 1].StackName);
      string currentStackName = stackList[stackList.Length - 1].StackName;
      Character player = stackList[stackList.Length - 1].Player;
      Character target = stackList[stackList.Length - 1].Target;
      // 現在のスタックを破棄する。
      Destroy(stackList[stackList.Length - 1].gameObject);
      stackList[stackList.Length - 1] = null;
      // 失敗したことを示すスタックを表示する。
      if (frostLance != null)
      {
        CreateStackObject(player, target, currentStackName + " 失敗！（要因：フロスト・ランス）", 0, Fix.STACKCOMMAND_SUDDEN_TIMER);
      }
      else if (counterDisallow != null)
      {
        CreateStackObject(player, target, currentStackName + " 失敗！（要因：カウンター・ディスアロウ）", 0, Fix.STACKCOMMAND_SUDDEN_TIMER);
      }
      else
      {
        CreateStackObject(player, target, currentStackName + " 失敗！（要因：不明）", 0, Fix.STACKCOMMAND_SUDDEN_TIMER);
      }
      return;
    }
    if (stackList[num].StackTimer <= 0)
    {
      ExecPlayerCommand(stackList[num].Player, stackList[num].Target, stackList[num].StackName);
    }
  }

  /// <summary>
  /// プレイヤーの行動ゲージを更新します。
  /// </summary>
  private void UpdatePlayerArrow(Character player, float move_skip)
  {
    //RectTransform rect = player.objArrow.GetComponent<RectTransform>();
    //float speedValue = (float)PrimaryLogic.BattleSpeed(player);
    ////Debug.Log("speedValue: " + speedValue);
    //// 画面の枠の大きさに応じて、スピード倍率を調整する。(ベース100)
    //// プレイヤーアローの大きさの分を画面枠から差し引いて調整する。
    //float factor = BATTLE_GAUGE_WITDH / 100.0f;
    ////Debug.Log("factor: " + factor);
    //speedValue = speedValue * factor * SpeedFactor();
    ////Debug.Log("speedValue2: " + speedValue);

    //if (move_skip > 0)
    //{
    //  rect.position = new Vector3(rect.position.x + move_skip, rect.position.y, rect.position.z);
    //}
    //else
    //{
    //  rect.position = new Vector3(rect.position.x + speedValue, rect.position.y, rect.position.z);
    //}

    //if (rect.position.x >= BATTLE_GAUGE_WITDH)
    //{
    //  rect.position = new Vector3(BATTLE_GAUGE_WITDH, rect.position.y, rect.position.z);
    //}

    if (move_skip > 0 || move_skip < 0)
    {
      player.BattleGaugeArrow += move_skip;
      if (player.BattleGaugeArrow >= 100.0f) { player.BattleGaugeArrow = 100.0f; }
      if (player.BattleGaugeArrow <= 0.0f) { player.BattleGaugeArrow = 0.0f; }
      player.UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / 100.0f);
    }
    else
    {
      player.BattleGaugeArrow += (float)PrimaryLogic.BattleSpeed(player);
      if (player.BattleGaugeArrow >= 100.0f) { player.BattleGaugeArrow = 100.0f; }
      if (player.BattleGaugeArrow <= 0.0f) { player.BattleGaugeArrow = 0.0f; }
      player.UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / 100.0f);
    }
  }

  /// <summary>
  /// プレイヤーの行動ゲージを０に設定します。
  /// </summary>
  /// <param name="player"></param>
  /// <param name="arrow"></param>
  private void UpdatePlayerArrowZero(Character player, GameObject arrow)
  {
    player.BattleGaugeArrow = 0;
    player.UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH);
    //RectTransform rect = arrow.GetComponent<RectTransform>();
    //rect.position = new Vector3(0, rect.position.y, rect.position.z);
  }

  #region "GUI Event"
  /// <summary>
  /// メインボタン押下時の処理
  /// </summary>
  public void TapCharacterMainButton(Button sender)
  {
    Debug.Log("TapPlayerMainButton: " + sender.name);

    // 最初はターゲット元の指定に応じる
    if (this.NowSelectTarget == false)
    {
      // 最初は敵をターゲットにできない。
      for (int ii = 0; ii < EnemyList.Count; ii++)
      {
        if (sender.Equals(EnemyList[ii].objMainButton.ActionButton))
        {
          Debug.Log("First target is enemy, then no action.");
          return;
        }
      }

      // 最初は味方をターゲットにする。
      //bool detectChange = false;
      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        Debug.Log("TapPlayerMainButton: Player is " + PlayerList[ii].FullName + " " + PlayerList[ii].objMainButton.name);
        if (sender.Equals(PlayerList[ii].objMainButton.ActionButton))
        {
          Debug.Log("TapPlayerMainButton: Detect src target: " + PlayerList[ii].FullName);
          //if (this.currentPlayer.Equals(PlayerList[ii]) == false)
          //{
          //  detectChange = true;
          //}
          //
          //this.currentPlayer = PlayerList[ii];
          ////this.txtCurrentPlayerName.text = PlayerList[ii].FullName;
          ////this.imgCurrentPlayerActionButton.color = PlayerList[ii].BattleColor;

          for (int jj = 0; jj < PlayerList[ii].objMainActionList.Count; jj++)
          {
            if (PlayerList[ii].objMainActionList[jj].CommandName == Fix.DEFENSE || PlayerList[ii].objMainActionList[jj].CommandName == Fix.DEFENSE_JP)
            {
              if (PlayerList[ii].IsLandShatter)
              {
                Debug.Log("PlayerList[ii].IsLandShatter phase, CommandName is Defense_Disable");
                PlayerList[ii].objMainActionList[jj].ApplyImageIcon(Fix.DEFENSE_DISABLE);
              }
              else
              {
                Debug.Log("PlayerList[ii].IsLandShatter phase, CommandName is Defense");
                PlayerList[ii].objMainActionList[jj].ApplyImageIcon(PlayerList[ii].objMainActionList[jj].CommandName);
              }
            }
          }
          PlayerList[ii].objParentActionPanel.imgBackGauge.color = PlayerList[ii].BattleBackColor;
          PlayerList[ii].objParentActionPanel.imgCurrentPlayerActionButton.color = PlayerList[ii].BattleForeColor;
          PlayerList[ii].objParentActionPanel.gameObject.SetActive(true);
          this.NowSelectSrcPlayer = PlayerList[ii];
          break;
        }
      }

      // 味方選択が変わった場合は、ターゲット選択モードに入らず終了する。
      //if (detectChange)
      //{
      //  Debug.Log("DetectChange has hitted, then no select target.");
      //  return;
      //}

      this.NowSelectTarget = true;
      this.NowSelectActionSrcButton = sender;

      SelectFilter.SetActive(true);
      //btnCancelSelect.SetActive(true);
      lblInstantAction.SetActive(false);
      GroupMainActionCommand.SetActive(true);
    }
    // それ以外はターゲット選定中
    else
    {
      this.NowSelectActionDstButton = sender;

      // グローバルアクションボタン指定時
      if (this.NowSelectGlobal)
      {
        if (this.NowSelectActionSrcButton.name == Fix.NORMAL_ATTACK)
        {
          for (int ii = 0; ii < PlayerList.Count; ii++)
          {
            for (int jj = 0; jj < EnemyList.Count; jj++)
            {
              if (this.NowSelectActionDstButton.Equals(EnemyList[jj].objMainButton.ActionButton))
              {
                // アクションコマンドを更新
                PlayerList[ii].CurrentActionCommand = this.NowSelectActionSrcButton.name;
                PlayerList[ii].txtActionCommand.text = this.NowSelectActionSrcButton.name;
                CopyActionButton(this.NowSelectActionSrcButton, PlayerList[ii].objMainButton.ActionButton);

                // ターゲット敵を更新
                PlayerList[ii].Target = EnemyList[jj];
              }
            }
          }
        }
        else if (this.NowSelectActionSrcButton.name == Fix.USE_RED_POTION_1 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_RED_POTION_2 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_RED_POTION_3 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_RED_POTION_4 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_RED_POTION_5 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_RED_POTION_6 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_RED_POTION_7)
        {
          for (int ii = 0; ii < PlayerList.Count; ii++)
          {
            if (this.NowSelectActionDstButton.Equals(PlayerList[ii].objMainButton.ActionButton))
            {
              ExecUseRedPotion(PlayerList[ii], this.NowSelectActionSrcButton.name);
            }
          }
        }
        else if (this.NowSelectActionSrcButton.name == Fix.USE_BLUE_POTION_1 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_BLUE_POTION_2 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_BLUE_POTION_3 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_BLUE_POTION_4 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_BLUE_POTION_5 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_BLUE_POTION_6 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_BLUE_POTION_7)
        {
          for (int ii = 0; ii < PlayerList.Count; ii++)
          {
            if (this.NowSelectActionDstButton.Equals(PlayerList[ii].objMainButton.ActionButton))
            {
              ExecUseBluePotion(PlayerList[ii], this.NowSelectActionSrcButton.name);
            }
          }
        }

        // グローバルインスタントゲージを０にする。
        this.GlobalInstantValue = 0;
        UpdateGlobalGauge();

        // 決定後、通常の戦闘モードに戻す。
        ClearSelectFilterGroup();
      }
      // 通常のアクションボタン指定時
      else
      {
        // アクションコマンド指定が無い場合は、キャンセル扱いとする。
        // note: ターゲット変更時、変更対象が敵味方によってターゲット指定できないものがあるが、
        // それに準じたブロック仕様を行うと、プレイヤーはなぜターゲット指定できないのかが理解できないケースがあり
        // ＧＵＩ不備と考えられるケースがある。また単にキャンセル扱いしたい場合は同じキャラクターを
        // ２回タップするため、それが自然な操作であると考えられる。
        if (this.NowSelectActionCommandButton == null)
        {
          ClearSelectFilterGroup();
        }
        // アクションコマンド指定がある場合
        else
        {
          if (NowSelectActionSrcButton != null) { Debug.Log(NowSelectActionSrcButton.name); }
          if (NowSelectActionCommandButton != null) { Debug.Log(NowSelectActionCommandButton.name); }
          if (NowSelectActionDstButton != null) { Debug.Log(NowSelectActionDstButton.name); }

          // 通常選択時
          if (this.NowInstantTarget == false)
          {
            // 新しいメインコマンドを反映する。
            for (int ii = 0; ii < PlayerList.Count; ii++)
            {
              if (NowSelectActionSrcButton.Equals(PlayerList[ii].objMainButton.ActionButton))
              {
                // ターゲットを反映する。
                for (int jj = 0; jj < AllList.Count; jj++)
                {
                  if (NowSelectActionDstButton.Equals(AllList[jj].objMainButton.ActionButton))
                  {
                    // ターゲット指定とアクションコマンドのターゲット範囲が違う場合はブロックする。
                    if (AllList[jj].IsEnemy == false && ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.Enemy)
                    {
                      Debug.Log("Target Error. IsEnemy False : AC is Enemy");
                      UpdateMessage(NowSelectSrcPlayer.CharacterMessage(1001));
                      return;
                    }
                    if (AllList[jj].IsEnemy && ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.Ally)
                    {
                      Debug.Log("Target Error. IsEnemy True : AC is Enemy");
                      UpdateMessage(NowSelectSrcPlayer.CharacterMessage(1002));
                      return;
                    }
                    PlayerList[ii].Target = AllList[jj];
                    Debug.Log("command: " + NowSelectActionSrcButton.name + " Enemy: " + AllList[jj].FullName);
                    break;
                  }
                }
                ApplyMainActionCommand(PlayerList[ii], NowSelectActionCommandButton, NowSelectActionSrcButton, NowSelectActionCommandButton.name);
                LogicInvalidate();
                break;
              }
            }
          }
          // インスタント行動時
          else
          {
            // コマンドを実行する。
            for (int ii = 0; ii < AllList.Count; ii++)
            {
              if (NowSelectActionDstButton.Equals(AllList[ii].objMainButton.ActionButton))
              {
                // ターゲット指定とアクションコマンドのターゲット範囲が違う場合はブロックする。
                if (AllList[ii].IsEnemy == false && ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.Enemy)
                {
                  Debug.Log("Target Error. IsEnemy False : AC is Enemy");
                  UpdateMessage(NowSelectSrcPlayer.CharacterMessage(1001));
                  return;
                }
                if (AllList[ii].IsEnemy && ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.Ally)
                {
                  Debug.Log("Target Error. IsEnemy True : AC is Enemy");
                  UpdateMessage(NowSelectSrcPlayer.CharacterMessage(1002));
                  return;
                }

                Debug.Log("instant target is " + AllList[ii].FullName);
                ExecPlayerCommand(this.NowSelectSrcPlayer, AllList[ii], NowSelectActionCommandButton.name);
                break;
              }
            }

            if (ActionCommand.GetAttribute(NowSelectActionCommandButton.name) == ActionCommand.Attribute.Archetype)
            {
              // ポテンシャル・ゲージを消費。
              One.TF.PotentialEnergy = 0;
            }
            else
            {
              // インスタント・ゲージを消費。
              BuffImage everflowMind = this.NowSelectSrcPlayer.IsEverflowMind;
              if (everflowMind != null)
              {
                this.NowSelectSrcPlayer.CurrentInstantPoint = everflowMind.EffectValue * this.NowSelectSrcPlayer.MaxInstantPoint;
              }
              else
              {
                this.NowSelectSrcPlayer.CurrentInstantPoint = SecondaryLogic.MagicSpellFactor(this.NowSelectSrcPlayer) * this.NowSelectSrcPlayer.MaxInstantPoint;
              }
              this.NowSelectSrcPlayer.UpdateInstantPointGauge();
            }
          }
          // 決定後、通常の戦闘モードに戻す。
          ClearSelectFilterGroup();
        }
      }
    }
  }

  /// <summary>
  /// 行動元プレイヤー選択後、表示されるメインアクションを選択する。
  /// </summary>
  public void TapMainAction(NodeActionCommand sender)
  {
    // 対象元を検索する。
    for (int ii = 0; ii < PlayerList.Count; ii++)
    {
      if (sender.OwnerName == PlayerList[ii].FullName)
      {
        this.NowSelectSrcPlayer = PlayerList[ii];
        break;
      }
    }

    // 対象元が存在しない場合、行動できない。
    if (this.NowSelectSrcPlayer == null)
    {
      Debug.Log("selectedPlayer is null, then no action.");
      return;
    }

    // LandShatter効果が続いている間は、防御を選択できない。
    if (sender.CommandName == Fix.DEFENSE || sender.CommandName == Fix.DEFENSE_JP)
    {
      for (int ii = 0; ii < this.NowSelectSrcPlayer.objMainActionList.Count; ii++)
      {
        if (this.NowSelectSrcPlayer.objMainActionList[ii].CommandName == sender.CommandName &&
            this.NowSelectSrcPlayer.IsLandShatter)
        {
          return;
        }
      }
    }

    // 自分自身の場合はその場で選択決定。（防御など）
    ActionCommand.TargetType targetType = ActionCommand.IsTarget(sender.CommandName);
    Debug.Log("current mainaction " + sender.CommandName + " targetType: " + targetType.ToString());
    if (targetType == ActionCommand.TargetType.Own ||
        targetType == ActionCommand.TargetType.AllMember)
    {
      ApplyMainActionCommand(this.NowSelectSrcPlayer, sender.ActionButton, this.NowSelectSrcPlayer.objMainButton.ActionButton, sender.CommandName);
      //CopyActionButton(sender.ActionButton, this.NowSelectSrcPlayer.objMainButton);
      //this.NowSelectSrcPlayer.CurrentActionCommand = sender.CommandName;
      //this.NowSelectSrcPlayer.txtActionCommand.text = sender.CommandName;
      // 決定後、通常の戦闘モードに戻す。
      ClearSelectFilterGroup();
      return;
    }
    // 味方全体の場合はその場で選択決定。（DivineCircleなど）
    if (targetType == ActionCommand.TargetType.AllyGroup || targetType == ActionCommand.TargetType.AllyField)
    {
      ApplyMainActionCommand(this.NowSelectSrcPlayer, sender.ActionButton, this.NowSelectActionSrcButton, sender.name);
      ClearSelectFilterGroup();
      return;
    }
    // 敵全体の場合はその場で選択決定。（）
    if (targetType == ActionCommand.TargetType.EnemyGroup || targetType == ActionCommand.TargetType.EnemyField)
    {
      ApplyMainActionCommand(this.NowSelectSrcPlayer, sender.ActionButton, this.NowSelectActionSrcButton, sender.name);
      ClearSelectFilterGroup();
      return;
    }

    // ターゲット選択状態へ遷移
    this.NowSelectTarget = true;
    SelectFilter.SetActive(true);
    GroupMainActionCommand.SetActive(false);
    this.NowSelectActionCommandButton = sender.ActionButton;
  }

  /// <summary>
  /// アクションコマンド押下時の処理
  /// </summary>
  public void TapInstantAction(NodeActionCommand sender)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " +sender.CommandName);

    // 対象元を検索する。
    for (int ii = 0; ii < PlayerList.Count; ii++)
    {
      if (sender.OwnerName == PlayerList[ii].FullName)
      {
        this.NowSelectSrcPlayer = PlayerList[ii];
        break;
      }
    }

    // 対象元が存在しない場合、行動できない。
    if (this.NowSelectSrcPlayer == null)
    {
      Debug.Log("selectedPlayer is null, then no action.");
      return;
    }

    // インスタント値が不足している場合、行動できない。
    if ((this.NowSelectSrcPlayer.CurrentInstantPoint < this.NowSelectSrcPlayer.MaxInstantPoint) &&
        (ActionCommand.GetTiming(sender.CommandName) != ActionCommand.TimingType.Archetype)) // todo Archetypeではない場合、すべて使用不可能かどうかは決まっていない。
    {
      if (sender.CommandName == Fix.DEFENSE && this.NowSelectSrcPlayer.IsDefense == false)
      {
        // 防御姿勢は可能とする。
      }
      else
      {
        UpdateMessage(this.NowSelectSrcPlayer.CharacterMessage(1003));
        Debug.Log("Still not enough instant point. then no action.");
        return;
      }
    }

    if ((ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.Archetype) &&
        (One.TF.PotentialEnergy < One.TF.MaxPotentialEnergy))
    {
      //UpdateMessage(this.NowSelectSrcPlayer.CharacterMessage(1003));
      Debug.Log("Still not enough PotentialEnergy point. then no action.");
      return;
    }

    if (this.NowStackInTheCommand == false)
    {
      if (this.NowSelectSrcPlayer.IsSleep || this.NowSelectSrcPlayer.IsStun)
      {
        Debug.Log("CurrentPlayer is now sleeping or stunning, then no action.");
        return;
      }

      if (ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.StackCommand)
      {
        Debug.Log("Command Timing is StackCommand, then no action.");
        return;
      }

      if (ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.Normal)
      {
        if (this.NowSelectSrcPlayer.IsWillAwakening)
        {
          Debug.Log("IsWillAwakening detect, possible action.");
          // 通過
        }
        else
        {
          Debug.Log("Command Timing is Normal, then no action.");
          return;
        }
      }
      if (ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.Sorcery)
      {
        Debug.Log("Command Timing is Sorcery, then no action.");
        return;
      }

      if (this.NowSelectTarget == false)
      {
        Debug.Log("TapPlayerActionButton: " + this.NowSelectSrcPlayer.FullName + " " + this.NowSelectSrcPlayer.CurrentInstantPoint.ToString() + " " + this.NowSelectSrcPlayer.MaxInstantPoint.ToString());
      }

      if (this.BattleType == Fix.BattleMode.Duel)
      {
        if (sender.CommandName == Fix.DEFENSE) // 防御姿勢はインスタント消費ではなく可能とする。
        {
          this.NowSelectSrcPlayer.DecisionDefense();
          this.NowSelectSrcPlayer = null;
        }
        else if (ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.StackCommand &&
                 GroupStackInTheCommand.GetComponentsInChildren<StackObject>().Length <= 0)
        {
          Debug.Log("Command Timing is StackCommand and stack-length less than 0, then no action.");
        }
        else if (this.NowSelectSrcPlayer.CurrentInstantPoint >= this.NowSelectSrcPlayer.MaxInstantPoint)
        {
          BuffImage everflowMind = this.NowSelectSrcPlayer.IsEverflowMind;
          if (everflowMind != null)
          {
            this.NowSelectSrcPlayer.CurrentInstantPoint = everflowMind.EffectValue * this.NowSelectSrcPlayer.MaxInstantPoint;
          }
          else
          {
            this.NowSelectSrcPlayer.CurrentInstantPoint = SecondaryLogic.MagicSpellFactor(this.NowSelectSrcPlayer) * this.NowSelectSrcPlayer.MaxInstantPoint;
          }
          this.NowSelectSrcPlayer.UpdateInstantPointGauge();
          if (sender.CommandName == Fix.HARDEST_PARRY)
          {
            CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.CommandName, 1, Fix.STACKCOMMAND_SUDDEN_TIMER);
          }
          else
          {
            CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.name, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
          }
        }
      }
      else
      {
        this.NowSelectTarget = true;
        SelectFilter.SetActive(true);
        this.NowInstantTarget = true;
        lblInstantAction.SetActive(true);

        this.NowSelectActionCommandButton = sender.ActionButton;
      }
    }
    else
    {
      if (ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.Normal)
      {
        if (this.NowSelectSrcPlayer.IsWillAwakening)
        {
          Debug.Log("IsWillAwakening detect, possible action.");
          // 通過
        }
        else
        {
          Debug.Log("ActionCommand.TimingType.Normal, then no action.");
          return;
        }
      }
      if (ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.Sorcery)
      {
        Debug.Log("Command Timing is Sorcery, then no action.");
        return;
      }


      if (sender.CommandName == Fix.DEFENSE) // 防御姿勢はインスタント消費ではなく可能とする。
      {
        CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.name, 1, Fix.STACKCOMMAND_SUDDEN_TIMER);
      }
      else if (this.NowSelectSrcPlayer.CurrentInstantPoint >= this.NowSelectSrcPlayer.MaxInstantPoint)
      {
        BuffImage everflowMind = this.NowSelectSrcPlayer.IsEverflowMind;
        if (everflowMind != null)
        {
          this.NowSelectSrcPlayer.CurrentInstantPoint = everflowMind.EffectValue * this.NowSelectSrcPlayer.MaxInstantPoint;
        }
        else
        {
          this.NowSelectSrcPlayer.CurrentInstantPoint = SecondaryLogic.MagicSpellFactor(this.NowSelectSrcPlayer) * this.NowSelectSrcPlayer.MaxInstantPoint;
        }
        this.NowSelectSrcPlayer.UpdateInstantPointGauge();

        if (sender.CommandName == Fix.HARDEST_PARRY)
        {
          CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.CommandName, 1, Fix.STACKCOMMAND_SUDDEN_TIMER);
        }
        else
        {
          CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.name, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
        }
      }
    }
  }

  public void TapImmediateAction(NodeActionCommand sender)
  {
    Debug.Log("TapImmediateAction(S)");
    Debug.Log("target Action is " + sender.CommandName);
    Debug.Log("target Owner is " + sender.OwnerName);
    for (int ii = 0; ii < this.PlayerList.Count; ii++)
    {
      if (this.PlayerList[ii].FullName == sender.OwnerName)
      {
        // インスタント値が不足している場合、行動できない。
        if (PlayerList[ii].CurrentInstantPoint < PlayerList[ii].MaxInstantPoint)
        {
          UpdateMessage(this.NowSelectSrcPlayer.CharacterMessage(1003));
          Debug.Log("Still now instant point. then no action.");
          return;
        }

        // ImmediateActionはポーションやシールなどの消耗品限定であり、アクションコマンドは入らない。実行後は必ず０とする。
        this.PlayerList[ii].CurrentInstantPoint = 0;
        this.PlayerList[ii].UpdateInstantPointGauge();

        if (sender.CommandName == Fix.SMALL_RED_POTION ||
            sender.CommandName == Fix.NORMAL_RED_POTION ||
            sender.CommandName == Fix.LARGE_RED_POTION ||
            sender.CommandName == Fix.HUGE_RED_POTION ||
            sender.CommandName == Fix.HQ_RED_POTION ||
            sender.CommandName == Fix.THQ_RED_POTION ||
            sender.CommandName == Fix.PERFECT_RED_POTION)
        {
          bool result = ExecUseRedPotion(this.PlayerList[ii], sender.CommandName);
          if (result == false)
          {
            StartAnimation(this.PlayerList[ii].objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
          }
        }
        else if (sender.CommandName == Fix.SMALL_BLUE_POTION ||
                 sender.CommandName == Fix.NORMAL_BLUE_POTION ||
                 sender.CommandName == Fix.LARGE_BLUE_POTION ||
                 sender.CommandName == Fix.HUGE_BLUE_POTION ||
                 sender.CommandName == Fix.HQ_BLUE_POTION ||
                 sender.CommandName == Fix.THQ_BLUE_POTION ||
                 sender.CommandName == Fix.PERFECT_BLUE_POTION)
        {
          bool result = ExecUseBluePotion(this.PlayerList[ii], sender.CommandName);
          if (result == false)
          {
            StartAnimation(this.PlayerList[ii].objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
          }
        }
        else if (sender.CommandName == Fix.SMALL_GREEN_POTION ||
                 sender.CommandName == Fix.NORMAL_GREEN_POTION ||
                 sender.CommandName == Fix.LARGE_GREEN_POTION ||
                 sender.CommandName == Fix.HUGE_GREEN_POTION ||
                 sender.CommandName == Fix.HQ_GREEN_POTION ||
                 sender.CommandName == Fix.THQ_GREEN_POTION ||
                 sender.CommandName == Fix.PERFECT_GREEN_POTION)
        {
          bool result = ExecUseGreenPotion(this.PlayerList[ii], sender.CommandName);
          if (result == false)
          {
            StartAnimation(this.PlayerList[ii].objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
          }
        }
        break;
      }
    }
  }

  /// <summary>
  /// グローバルアクションボタン押下時の処理
  /// </summary>
  public void TapGlobalAction(NodeActionCommand sender)
  {

    switch (sender.name)
    {
      case Fix.DEFENSE:
        Debug.Log("Global Defense");
        for (int ii = 0; ii < PlayerList.Count; ii++)
        {
          PlayerList[ii].DecisionDefense();
        }
        break;

      case Fix.GLOBAL_ACTION_1:
        Debug.Log(Fix.GLOBAL_ACTION_1);
        for (int ii = 0; ii < PlayerList.Count; ii++)
        {
          SetupFirstCommand(PlayerList[ii], PlayerList[ii].GlobalAction1);
        }
        break;

      case Fix.GLOBAL_ACTION_2:
        Debug.Log(Fix.GLOBAL_ACTION_2);
        for (int ii = 0; ii < PlayerList.Count; ii++)
        {
          SetupFirstCommand(PlayerList[ii], PlayerList[ii].GlobalAction2);
        }
        break;

      case Fix.GLOBAL_ACTION_3:
        Debug.Log(Fix.GLOBAL_ACTION_3);
        for (int ii = 0; ii < PlayerList.Count; ii++)
        {
          SetupFirstCommand(PlayerList[ii], PlayerList[ii].GlobalAction3);
        }
        break;

      case Fix.GLOBAL_ACTION_4:
        Debug.Log(Fix.GLOBAL_ACTION_4);
        for (int ii = 0; ii < PlayerList.Count; ii++)
        {
          SetupFirstCommand(PlayerList[ii], PlayerList[ii].GlobalAction4);
        }
        break;

      case Fix.USE_RED_POTION_1:
      case Fix.USE_RED_POTION_2:
      case Fix.USE_RED_POTION_3:
      case Fix.USE_RED_POTION_4:
      case Fix.USE_RED_POTION_5:
      case Fix.USE_RED_POTION_6:
      case Fix.USE_RED_POTION_7:
        Debug.Log("Global USE_RED_POTION");
        if (this.GlobalInstantValue < Fix.GLOBAL_INSTANT_MAX)
        {
          Debug.Log("Still not enough global gauge, then no action.");
          return;
        }
        Debug.Log("UsePotionRed");
        if (this.NowSelectActionSrcButton == null)
        {
          this.NowSelectActionSrcButton = sender.ActionButton;
          SelectFilter.SetActive(true);
          //btnCancelSelect.SetActive(true);
          this.NowSelectTarget = true;
          this.NowSelectGlobal = true;
        }
        break;

      case Fix.USE_BLUE_POTION_1:
      case Fix.USE_BLUE_POTION_2:
      case Fix.USE_BLUE_POTION_3:
      case Fix.USE_BLUE_POTION_4:
      case Fix.USE_BLUE_POTION_5:
      case Fix.USE_BLUE_POTION_6:
      case Fix.USE_BLUE_POTION_7:
        Debug.Log("Global USE_BLUE_POTION");
        if (this.GlobalInstantValue < Fix.GLOBAL_INSTANT_MAX)
        {
          Debug.Log("Still not enough global gauge, then no action.");
          return;
        }
        Debug.Log("UsePotionBLUE");
        if (this.NowSelectActionSrcButton == null)
        {
          this.NowSelectActionSrcButton = sender.ActionButton;
          SelectFilter.SetActive(true);
          //btnCancelSelect.SetActive(true);
          this.NowSelectTarget = true;
          this.NowSelectGlobal = true;
        }
        break;

      case Fix.READY_BUTTON:
        Debug.Log("Global READY_BUTTON");
        this.TimeStatus = Fix.BattleStatus.Go;
        sender.ActionButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.GO_BUTTON);
        sender.ActionButton.name = Fix.GO_BUTTON;
        sender.name = Fix.GO_BUTTON;
        break;

      case Fix.GO_BUTTON:
        Debug.Log("Global GO_BUTTON");
        this.TimeStatus = Fix.BattleStatus.Stop;
        sender.ActionButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.STOP_BUTTON);
        sender.ActionButton.name = Fix.STOP_BUTTON;
        sender.name = Fix.STOP_BUTTON;
        break;

      case Fix.STOP_BUTTON:
        Debug.Log("Global STOP_BUTTON");
        this.TimeStatus = Fix.BattleStatus.Go;
        sender.ActionButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.GO_BUTTON);
        sender.ActionButton.name = Fix.GO_BUTTON;
        sender.name = Fix.GO_BUTTON;
        break;

      case Fix.RUNAWAY_BUTTON:
        Debug.Log("RUNAWAY_BUTTON");
        if (this.CannotRunAway)
        {
          Debug.Log("CannotRunAway is true, then prohibit RunAway.");
          return;
        }

        One.BattleEnd = Fix.GameEndType.RunAway;
        if (panelGameEnd.activeInHierarchy == false)
        {
          txtGameEndMessage.text = PlayerList[0].FullName + "達は逃げ出した・・・";
          panelGameEndExpList.SetActive(false);
          panelGameEnd.SetActive(true);
        }
        break;

      case Fix.LOG_BUTTON:
        GroupLogBox.SetActive(!GroupLogBox.activeInHierarchy);
        break;

      default:
        Debug.Log("Unknown Command, then no action.");
        break;
    }
  }

  public void TapPotentialAction(Button sender)
  {
    Debug.Log("TapPotentialAction(S)");

    // todo プレイヤー毎に潜在奥義を出させるか、何か固定か？
    Debug.Log("TapPotentialAction(S)");
  }

  /// <summary>
  /// アクション行動選択中の状態を解除します。
  /// </summary>
  public void TapCancelSelect()
  {
    ClearSelectFilterGroup();
  }

  public void HideLvUpCharacterView()
  {
    TapEndScene();
  }

  public void TapEndScene()
  {
    Debug.Log(MethodBase.GetCurrentMethod()+"(S)");
    this.AutoExit = -1;

    // シーンエンド前のレベルアップ報告フェーズ
    if (DetectLvup.Count > 0)
    {
      DetectLvup.RemoveAt(0);
      if (DetectLvupTitle.Count > 0)
      {
        txtLvupTitle.text = DetectLvupTitle[0];
        DetectLvupTitle.RemoveAt(0);
      }
      if (DetectLvupMaxLife.Count > 0)
      {
        txtLvupMaxLife.text = DetectLvupMaxLife[0];
        DetectLvupMaxLife.RemoveAt(0);
      }
      if (DetectLvupMaxManaPoint.Count > 0)
      {
        txtLvupMaxManaPoint.text = DetectLvupMaxManaPoint[0];
        DetectLvupMaxManaPoint.RemoveAt(0);
      }
      if (DetectLvupMaxSkillPoint.Count > 0)
      {
        txtLvupMaxSkillPoint.text = DetectLvupMaxSkillPoint[0];
        DetectLvupMaxSkillPoint.RemoveAt(0);
      }
      if (DetectLvupRemainPoint.Count > 0)
      {
        txtLvupRemainPoint.text = DetectLvupRemainPoint[0];
        DetectLvupRemainPoint.RemoveAt(0);
      }
      if (DetectLvupSoulEssence.Count > 0)
      {
        txtLvupSoulEssence.text = DetectLvupSoulEssence[0];
        DetectLvupSoulEssence.RemoveAt(0);
      }
      if (DetectLvupSpecial.Count > 0)
      {
        txtLvupSpecial.text = DetectLvupSpecial[0];
        DetectLvupSpecial.RemoveAt(0);
      }
      GroupLvupCharacter.SetActive(true);
      return;
    }

    // シーンエンド
    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      Destroy(One.EnemyList[ii].gameObject);
    }
    SceneManager.LoadSceneAsync("DungeonField");
  }

  public void TapSpeedUp()
  {
    speedDown--;
    if (speedDown <= 1) { speedDown = 1; }
    LogicInvalidate();
  }

  public void TapSpeedDown()
  {
    if (speedDown < 10)
    {
      speedDown++;
    }
    LogicInvalidate();
  }

  public void TapRetryBattle()
  {
    One.BattleEnd = Fix.GameEndType.Retry;
    TapEndScene();
  }

  public void TapSurrenderBattle()
  {
    SceneDimension.JumpToTitle();
  }
  #endregion

  #region "Private Method"
  /// <summary>
  /// アクションボタンのアイコンをコピーします。
  /// </summary>
  private void CopyActionButton(Button src, Button dst)
  {
    if (src == null) { return; }
    if (dst == null) { return; }

    Image current = dst.GetComponent<Image>();
    Sprite _sprite = Resources.Load<Sprite>(src.name);
    if (_sprite != null)
    {
      current.sprite = _sprite;
      current.name = src.name;
    }
    else
    {
      current.sprite = Resources.Load<Sprite>(Fix.STAY);
      current.name = Fix.STAY;
    }
  }

  /// <summary>
  /// メインアクションコマンドを適用します。
  /// </summary>
  private void ApplyMainActionCommand(Character player, Button src, Button dst, string command_name)
  {
    CopyActionButton(src, dst);
    player.CurrentActionCommand = command_name;
    player.txtActionCommand.text = command_name;
  }

  /// <summary>
  /// アクション選択中の状態を解除します。
  /// </summary>
  private void ClearSelectFilterGroup()
  {
    SelectFilter.SetActive(false);
    lblInstantAction.SetActive(false);
    //btnCancelSelect.SetActive(false);

    this.NowSelectSrcPlayer = null;
    this.NowSelectActionSrcButton = null;
    this.NowSelectActionCommandButton = null;
    this.NowSelectActionDstButton = null;
    this.NowSelectGlobal = false;
    this.NowSelectTarget = false;
    this.NowInstantTarget = false;

    GroupMainActionCommand.SetActive(false);
    for (int ii = 0; ii < GroupMainACList.Count; ii++)
    {
      GroupMainACList[ii].SetActive(false);
    }
  }


  /// <summary>
  /// ターンエンド処理を行います。
  /// </summary>
  private void UpdateTurnEnd()
  {
    this.BattleTurn++;
    this.lblBattleTurn.text = "Turn " + BattleTurn.ToString();
    this.BattleTimer = 0;
  }

  /// <summary>
  /// アップキープ処理を行います。
  /// </summary>
  private void UpkeepStep()
  {
    BuffImage[] buffPlayerFieldList = PanelPlayerField.GetComponentsInChildren<BuffImage>();
    for (int ii = 0; ii < buffPlayerFieldList.Length; ii++)
    {
      // ライトニング・アウトバーストによる効果
      if (buffPlayerFieldList[ii] != null && buffPlayerFieldList[ii].BuffName == Fix.BUFF_LIGHTNING_OUTBURST)
      {
        for (int jj = 0; jj < PlayerList.Count; jj++)
        {
          if (PlayerList[jj].IsSigilOfThePending == null)
          {
            ExecElementalDamage(PlayerList[jj], Fix.DamageSource.Wind, buffPlayerFieldList[ii].EffectValue * buffPlayerFieldList[ii].Cumulative);
          }
        }
      }
      if (buffPlayerFieldList[ii] != null && buffPlayerFieldList[ii].BuffName == Fix.FREEZING_CUBE)
      {
        for (int jj = 0; jj < PlayerList.Count; jj++)
        {
          if (PlayerList[jj].IsSigilOfThePending == null)
          {
            ExecElementalDamage(PlayerList[jj], Fix.DamageSource.Ice, buffPlayerFieldList[ii].EffectValue2);
          }
        }
      }
      if (buffPlayerFieldList[ii] != null && buffPlayerFieldList[ii].BuffName == Fix.VOLCANIC_BLAZE)
      {
        for (int jj = 0; jj < PlayerList.Count; jj++)
        {
          if (PlayerList[jj].IsSigilOfThePending == null)
          {
            ExecElementalDamage(PlayerList[jj], Fix.DamageSource.Fire, buffPlayerFieldList[ii].EffectValue2);
          }
        }
      }
    }
    BuffImage[] buffEnemyFieldList = PanelEnemyField.GetComponentsInChildren<BuffImage>();
    for (int ii = 0; ii < buffEnemyFieldList.Length; ii++)
    {
      // ライトニング・アウトバーストによる効果
      if (buffEnemyFieldList[ii] != null && buffEnemyFieldList[ii].BuffName == Fix.BUFF_LIGHTNING_OUTBURST)
      {
        for (int jj = 0; jj < EnemyList.Count; jj++)
        {
          if (EnemyList[jj].IsSigilOfThePending == null)
          {
            ExecElementalDamage(EnemyList[jj], Fix.DamageSource.Wind, buffEnemyFieldList[ii].EffectValue * buffEnemyFieldList[ii].Cumulative);
          }
        }
      }
      if (buffEnemyFieldList[ii] != null && buffEnemyFieldList[ii].BuffName == Fix.FREEZING_CUBE)
      {
        for (int jj = 0; jj < EnemyList.Count; jj++)
        {
          if (EnemyList[jj].IsSigilOfThePending == null)
          {
            ExecElementalDamage(EnemyList[jj], Fix.DamageSource.Ice, buffEnemyFieldList[ii].EffectValue2);
          }
        }
      }
      if (buffEnemyFieldList[ii] != null && buffEnemyFieldList[ii].BuffName == Fix.VOLCANIC_BLAZE)
      {
        for (int jj = 0; jj < EnemyList.Count; jj++)
        {
          if (EnemyList[jj].IsSigilOfThePending == null)
          {
            ExecElementalDamage(EnemyList[jj], Fix.DamageSource.Fire, buffEnemyFieldList[ii].EffectValue2);
          }
        }
      }
      if (buffEnemyFieldList[ii] != null && buffEnemyFieldList[ii].BuffName == Fix.BUFF_VERDANT_VOICE)
      {
        for (int jj = 0; jj < EnemyList.Count; jj++)
        {
          if (EnemyList[jj].IsSigilOfThePending == null)
          {
            ExecLifeGain(EnemyList[jj], EnemyList[jj].MaxLife / 40);
          }
        }
      }
    }

    // 各BUFFによる効果
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      AllList[ii].CurrentActionPoint += Fix.AP_BASE;
      //AllList[ii].GainManaPoint(); // Manaはターン経過で増加しない
      AllList[ii].GainSkillPoint(); // Skillはターン経過で増加する
      AllList[ii].UpdateActionPoint();

      BuffImage sigilOfThePending = AllList[ii].IsSigilOfThePending;

      // シギル・オブ・ザ・ペンディングがある場合、効果を発揮しない。
      if (sigilOfThePending != null) 
      {
        Debug.Log("Upkeep phase, but sigilOfThePending is enabled, then no effect");
        AllList[ii].BuffCountdown(); // ペンディング効果がある状態だが、カウントダウンが進む方がゲーム性は高いため、進む事とする。
        continue; 
      }

      if (AllList[ii].IsHeartOfLife)
      {
        ExecLifeGain(AllList[ii], AllList[ii].IsHeartOfLife.EffectValue);
      }

      if (AllList[ii].IsPoison)
      {
        if (AllList[ii].SearchFieldBuff(Fix.SHINING_HEAL) != null)
        {
          // 何もしない
        }
        else
        {
          ExecPoisonDamage(AllList[ii], AllList[ii].IsPoison.EffectValue);
        }
      }

      // ブラッド・サインの効果はアップキープではない。
      //if (AllList[ii].IsBloodSign)
      //{
      //  ExecSlipDamage(AllList[ii], AllList[ii].IsBloodSign.EffectValue);
      //}

      if (AllList[ii].IsBlackContract && AllList[ii].SearchFieldBuff(Fix.SHINING_HEAL) == null)
      {
        ExecSlipDamage(AllList[ii], AllList[ii].IsBlackContract.EffectValue * AllList[ii].MaxLife);
      }

      if (AllList[ii].IsCursedEvangile)
      {
        Debug.Log("CursedEvangile Detect");
        List<string> total = new List<string>();
        if (AllList[ii].IsSilent == null) { total.Add(Fix.EFFECT_SILENT); }
        if (AllList[ii].IsBind == null) { total.Add(Fix.EFFECT_BIND); }
        if (AllList[ii].IsSlip == null) { total.Add(Fix.EFFECT_SLIP); }

        if (total.Count > 0)
        {
          int random = AP.Math.RandomInteger(total.Count);
          if (total[random] == Fix.EFFECT_SILENT)
          {
            Debug.Log("CursedEvangile EFFECT_SILENT");
            ExecBuffSilent(AllList[ii], AllList[ii], (int)(AllList[ii].IsCursedEvangile.EffectValue2), 0);
          }
          else if (total[random] == Fix.EFFECT_BIND)
          {
            Debug.Log("CursedEvangile EFFECT_BIND");
            ExecBuffBind(AllList[ii], AllList[ii], (int)(AllList[ii].IsCursedEvangile.EffectValue2), 0);
          }
          else // if (total[random] == Fix.EFFECT_SLIP)
          {
            Debug.Log("CursedEvangile EFFECT_SLIP");
            ExecBuffSlip(AllList[ii], AllList[ii], (int)(AllList[ii].IsCursedEvangile.EffectValue2), AllList[ii].IsCursedEvangile.EffectValue3);
          }
        }
        else
        {
          Debug.Log("CursedEvangile Detect: " + AllList[ii].IsCursedEvangile.EffectValue.ToString("F2"));
          ExecElementalDamage(AllList[ii], Fix.DamageSource.DarkMagic, AllList[ii].IsCursedEvangile.EffectValue);
        }
      }

      if (AllList[ii].IsBlackSpore)
      {
        int random = AP.Math.RandomInteger(5);
        switch (random)
        {
          case 0:
            ExecBuffSilent(AllList[ii], AllList[ii], 3, 0);
            break;
          case 1:
            ExecBuffBind(AllList[ii], AllList[ii], 3, 0);
            break;
          case 2:
            ExecBuffFear(AllList[ii], AllList[ii], 2, 0);
            break;
          case 3:
            ExecBuffPoison(AllList[ii], AllList[ii], 5, 120);
            break;
          case 4:
            ExecBuffTemptation(AllList[ii], AllList[ii], 2, 0);
            break;
        }
      }

      if (AllList[ii].Artifact.ItemName == Fix.ARTIFACT_GENSEI)
      {
        AllList[ii].CurrentManaPoint += 10;
        AllList[ii].UpdateManaPoint();
      }
      if (AllList[ii].Artifact.ItemName == Fix.ARTIFACT_ZIHI)
      {
        AllList[ii].CurrentSkillPoint += 3;
        AllList[ii].UpdateSkillPoint();
      }

      AllList[ii].BuffCountdown();
    }

    bool detectAngelicEchoEffectAlly = false;
    bool detectAngelicEchoEffectEnemy = false;

    for (int ii = 0; ii < buffPlayerFieldList.Length; ii++)
    {
      // エンジェリック・エコーによる効果
      if (buffPlayerFieldList[ii] != null && buffPlayerFieldList[ii].BuffName == Fix.ANGELIC_ECHO)
      {
        for (int jj = 0; jj < PlayerList.Count; jj++)
        {
          if (PlayerList[jj].IsSigilOfThePending == null)
          {
            AbstractHealCommand(PlayerList[jj], PlayerList[jj], buffPlayerFieldList[ii].EffectValue);
            BuffImage[] buffList = PlayerList[jj].GetNegativeBuffList();
            if (buffList != null && buffList.Length > 0) 
            {
              PlayerList[jj].RemoveBuff(1, ActionCommand.BuffType.Negative);
              detectAngelicEchoEffectAlly = true;
            }
          }
        }
      }
    }
    for (int ii = 0; ii < buffEnemyFieldList.Length; ii++)
    {
      // エンジェリック・エコーによる効果
      if (buffEnemyFieldList[ii] != null && buffEnemyFieldList[ii].BuffName == Fix.ANGELIC_ECHO)
      {
        for (int jj = 0; jj < EnemyList.Count; jj++)
        {
          if (EnemyList[jj].IsSigilOfThePending == null)
          {
            AbstractHealCommand(EnemyList[jj], EnemyList[jj], buffEnemyFieldList[ii].EffectValue);
            BuffImage[] buffList = EnemyList[jj].GetNegativeBuffList();
            if (buffList != null && buffList.Length > 0)
            {
              EnemyList[jj].RemoveBuff(1, ActionCommand.BuffType.Negative);
              detectAngelicEchoEffectEnemy = true;
            }
          }
        }
      }
    }

    if (detectAngelicEchoEffectAlly == false)
    {
      for (int ii = 0; ii < buffPlayerFieldList.Length; ii++)
      {
        buffPlayerFieldList[ii].BuffCountDown();
      }
    }
    if (detectAngelicEchoEffectEnemy == false)
    {
      for (int ii = 0; ii < buffEnemyFieldList.Length; ii++)
      {
        buffEnemyFieldList[ii].BuffCountDown();
      }
    }
  }

  /// <summary>
  /// グローバルゲージを更新します。
  /// </summary>
  private void UpdateGlobalGauge()
  {
    float dx = (float)this.GlobalInstantValue / (float)Fix.GLOBAL_INSTANT_MAX;
    if (this.imgGlobalGauge_AC != null)
    {
      this.imgGlobalGauge_AC.rectTransform.localScale = new Vector2(dx, 1.0f);
    }
  }

  private void UpdateTimerSpeed()
  {
    lblTimerSpeed.text = "x" + SpeedFactor().ToString("0.00");
  }

  private float SpeedFactor()
  {
    float result = (11.0f - speedDown) / 10.0f;
    return result;
  }

  private void UpdateMessage(string message)
  {
    GameObject node = Instantiate(prefab_Message) as GameObject;
    Text[] txtList = node.GetComponentsInChildren<Text>();
    txtList[0].text = message;
    node.SetActive(true);
    node.transform.SetParent(GroupMessage.transform);
    node.transform.SetAsFirstSibling();

    RectTransform rect = GroupMessage.GetComponent<RectTransform>();
    RectTransform rectMessage = node.GetComponent<RectTransform>();
    rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y + rectMessage.sizeDelta.y);
  }

  //private void AddActionButton(Character character, GameObject group_action_button, string command_name)
  //{
  //  character.ActionCommandList.Add(command_name);

  //  // インスタント限定でなければ、メインアクションに登録する。
  //  if (ActionCommand.IsTarget(command_name) != ActionCommand.TargetType.InstantTarget)
  //  {
  //    NodeActionCommand instant = Instantiate(prefab_MainAction) as NodeActionCommand;
  //    instant.BackColor.color = character.BattleForeColor;
  //    instant.CommandName = command_name;
  //    instant.name = command_name;
  //    instant.OwnerName = character.FullName;
  //    instant.ActionButton.name = command_name;
  //    instant.ActionButton.image.sprite = Resources.Load<Sprite>(command_name);

  //    instant.transform.SetParent(group_action_button.transform);
  //    instant.gameObject.SetActive(true);
  //  }

  //  Debug.Log("character AC add: " + character.ActionCommandList.Count);
  //}

  private void SetupFirstCommand(Character player, string command_name)
  {
    Debug.Log("SetupFirstCommand: " + player.FullName + " "  + command_name);
    player.CurrentActionCommand = command_name;
    if (player.objMainButton == null) { Debug.Log("ObjMainButton is null..."); }

    SetupActionCommandButton(player.objMainButton, command_name);
    Debug.Log("SetupFirstCommand: 2");
    player.txtActionCommand.text = command_name;
    Debug.Log("SetupFirstCommand: 3");
    ActionCommand.TargetType currentTargetType = ActionCommand.IsTarget(command_name);
    Debug.Log("SetupFirstCommand: 4");
    List<Character> opponentList = GetOpponentGroup(player);
    if (currentTargetType == ActionCommand.TargetType.Enemy || currentTargetType == ActionCommand.TargetType.EnemyGroup || currentTargetType == ActionCommand.TargetType.EnemyField)
    {
      Debug.Log("SetupFirstCommand: 5");
      if (player.TargetSelectType == Fix.TargetSelectType.Behind)
      {
        player.Target = GetOpponentGroup(player)[opponentList.Count - 1];
      }
      else
      {
        player.Target = GetOpponentGroup(player)[0];
      }
      Debug.Log("SetupFirstCommand: 5-2");
    }
    else if (currentTargetType == ActionCommand.TargetType.Ally || currentTargetType == ActionCommand.TargetType.AllyGroup || currentTargetType == ActionCommand.TargetType.AllyField)
    {
      Debug.Log("SetupFirstCommand: 6");
      player.Target = GetAllyGroup(player)[0];
      Debug.Log("SetupFirstCommand: 6-2");
    }
    else if (currentTargetType == ActionCommand.TargetType.EnemyOrAlly || currentTargetType == ActionCommand.TargetType.AllMember)
    {
      Debug.Log("SetupFirstCommand: 7");
      if (player.TargetSelectType == Fix.TargetSelectType.Behind)
      {
        player.Target = GetOpponentGroup(player)[opponentList.Count - 1];
      }
      else
      {
        player.Target = GetOpponentGroup(player)[0];
      }
      Debug.Log("SetupFirstCommand: 7-2");
    }
    else if (currentTargetType == ActionCommand.TargetType.Own)
    {
      Debug.Log("SetupFirstCommand: 8");
      player.Target = player;
      Debug.Log("SetupFirstCommand: 8-2");
    }
    else
    {
      Debug.Log("SetupFirstCommand: 9");
      // Targetは基本NULLは入れない。何も考えない場合は相手側をターゲットとする。
      if (player.TargetSelectType == Fix.TargetSelectType.Behind)
      {
        player.Target = GetOpponentGroup(player)[opponentList.Count - 1];
      }
      else
      {
        player.Target = GetOpponentGroup(player)[0];
      }
      Debug.Log("SetupFirstCommand: 9-2");
    }
    Debug.Log("SetupFirstCommand: 10");
  }
  #endregion
  #endregion

  #region "Exec Action Command"
  /// <summary>
  /// 基本ロジックを内包した物理攻撃実行コマンド
  /// </summary>
  private bool ExecNormalAttack(Character player, Character target, double magnify, Fix.DamageSource attr, bool ignore_target_defense, Fix.CriticalType critical, int animation_speed = MAX_ANIMATION_TIME)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    // ターゲットが既に死んでいる場合
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // 回避判定 (ターゲットへの命中率、ターゲットからの回避率、他効果などでaccuracyを決定)
    // 0.0fなら必ず回避される。 100.0fなら必ず当たる。
    double accuracy = 100.0f; //  PrimaryLogic.BattleAccuracy(player); // 命中率は原則100%とする。シリーズ１と同様。
    Debug.Log("PrimaryLogic.BattleAccuracy: " + accuracy.ToString("F2"));

    if (target.EvadingSkill > 0)
    {
      accuracy = accuracy * SecondaryLogic.EvadingSkill(target);
    }
    if (accuracy <= 0) accuracy = 0;

    int accuracyValue = AP.Math.RandomInteger(100);
    Debug.Log("Accuracy Value: " + accuracyValue.ToString() + " " + accuracy.ToString("F2"));
    if (accuracyValue > (int)accuracy)
    {
      Debug.Log("Accuracy miss, then no ExecNormalAttack.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    if (player.IsSonicPulse)
    {
      Debug.Log("Detect SonicPulse phase");
      double rand = AP.Math.RandomReal();
      Debug.Log("result: " + rand.ToString() + " " + player.IsSonicPulse.EffectValue.ToString());
      if (rand <= player.IsSonicPulse.EffectValue)
      {
        Debug.Log("SonicPulse effect, then no ExecNormalAttack.");
        // SonicPulseは妨害の位置づけでありEverflowMindなどの効果を受け付けない。実行後は必ず０とする。
        player.CurrentInstantPoint = 0;
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
        this.NowAnimationMode = true;
        return false;
      }
    }

    // 攻撃コマンドのダメージを算出
    bool resultCritical = false;
    double damageValue = PhysicalDamageLogic(player, target, magnify, attr, ignore_target_defense, critical, ref resultCritical);

    // ディバイン・フィールドによる効果
    BuffField panelField = target.objFieldPanel; // GetPanelFieldFromPlayer(target);
    if (panelField != null)
    {
      BuffImage buffImage = PreCheckFieldEffect(panelField.gameObject, Fix.DIVINE_CIRCLE);
      if (buffImage != null)
      {
        Debug.Log("DivineShiled: " + player.FullName + " -> " + damageValue.ToString("F2") + " " + buffImage.EffectValue.ToString("F2"));
        buffImage.EffectValue -= damageValue;
        StartAnimationGroupPanel(buffImage.gameObject, Fix.BATTLE_DIVINE + "\r\n " + (int)(buffImage.EffectValue), Fix.COLOR_NORMAL);
        if (buffImage.EffectValue <= 0)
        {
          buffImage.RemoveBuff();
        }
        return false; // ディバイン・フィールドで吸収された場合はヒットしたことにならない。
      }
    }
    // ファントム・朧による効果
    if (target.IsPhantomOboro != null && this.NowStackInTheCommand)
    {
      damageValue = 0;
    }
    // ダメージ適用
    ApplyDamage(player, target, damageValue, resultCritical, animation_speed);

    // 追加効果
    if (player.IsFlameBlade && player.Dead == false)
    {
      bool resultCritical2 = false;
      double addDamageValue = player.IsFlameBlade.EffectValue; // MagicDamageLogic(player, target, SecondaryLogic.MagicAttack(player), Fix.DamageSource.Fire, false, critical, ref resultCritical2);
      // ファントム・朧による効果
      if (target.IsPhantomOboro != null && this.NowStackInTheCommand)
      {
        addDamageValue = 0;
      }
      ApplyDamage(player, target, addDamageValue, resultCritical2, animation_speed);
    }
    BuffImage stanceOfTheBlade = player.IsStanceOfTheBlade;
    if (stanceOfTheBlade != null)
    {
      Debug.Log("Target is stanceOfTheBlade, then Cumulative++");
      int beforeCumulative = stanceOfTheBlade.Cumulative;
      stanceOfTheBlade.Cumulative++;
      if (beforeCumulative != stanceOfTheBlade.Cumulative)
      {
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_ATTACK_UP, Fix.COLOR_NORMAL);
      }
    }
    BuffImage stanceOfTheGuard = target.IsStanceOfTheGuard;
    if (stanceOfTheGuard != null && target.IsDefense && target.Dead == false)
    {
      Debug.Log("Target is IsStanceOfTheGuard, then Cumulative++");
      int beforeCumulative = stanceOfTheGuard.Cumulative;
      stanceOfTheGuard.Cumulative++;
      if (beforeCumulative != stanceOfTheGuard.Cumulative)
      {
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_DEFENSE_UP, Fix.COLOR_NORMAL);
      }
    }

    if (player.MainWeapon != null && (player.MainWeapon.ItemName == Fix.SWORD_OF_LIFE))
    {
      double effectValue = player.MainWeapon.ItemValue1 + AP.Math.RandomInteger(player.MainWeapon.ItemValue2 - player.MainWeapon.ItemValue1);
      AbstractHealCommand(player, player, effectValue);
    }
    return true;
  }

  /// <summary>
  /// 基本ロジックを内包した魔法攻撃実行コマンド
  /// </summary>
  private bool ExecMagicAttack(Character player, Character target, double magnify, Fix.DamageSource attr, bool ignore_target_defense, Fix.CriticalType critical, int animation_speed = MAX_ANIMATION_TIME)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    // ターゲットが既に死んでいる場合
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // 回避判定 (ターゲットへの命中率、ターゲットからの回避率、他効果などでaccuracyを決定)
    // 0.0fなら必ず回避される。 100.0fなら必ず当たる。
    double accuracy = 100.0f; // PrimaryLogic.BattleAccuracy(player); // 命中率は原則100%とする。シリーズ１と同様。
    Debug.Log("PrimaryLogic.BattleAccuracy: " + accuracy.ToString("F2"));
    if (target.EvadingSkill > 0)
    {
      accuracy = accuracy * SecondaryLogic.EvadingSkill(target);
    }
    if (accuracy <= 0) accuracy = 0;

    int accuracyValue = AP.Math.RandomInteger(100);
    Debug.Log("Accuracy Value: " + accuracyValue.ToString() + " " + accuracy.ToString("F2"));
    if (accuracyValue > (int)accuracy)
    {
      Debug.Log("Accuracy miss, then no ExecMagicAttack.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // 攻撃コマンドのダメージを算出
    bool resultCritical = false;
    double damageValue = MagicDamageLogic(player, target, magnify, attr, ignore_target_defense, critical, ref resultCritical);

    // ディバイン・フィールドによる効果
    BuffField panelField = target.objFieldPanel; // GetPanelFieldFromPlayer(target);
    if (panelField != null)
    {
      BuffImage buffImage = PreCheckFieldEffect(panelField.gameObject, Fix.DIVINE_CIRCLE);
      if (buffImage != null)
      {
        Debug.Log("DivineShiled: " + player.FullName + " -> " + damageValue.ToString("F2") + " " + buffImage.EffectValue.ToString("F2"));
        buffImage.EffectValue -= damageValue;
        StartAnimationGroupPanel(buffImage.gameObject, Fix.BATTLE_DIVINE + "\r\n " + (int)(buffImage.EffectValue), Fix.COLOR_NORMAL);
        if (buffImage.EffectValue <= 0)
        {
          buffImage.RemoveBuff();
        }
        return false; // ディバイン・フィールドで吸収された場合はヒットしたことにならない。
      }
    }

    // ファントム・朧による効果
    if (target.IsPhantomOboro != null && this.NowStackInTheCommand)
    {
      damageValue = 0;
    }

    // ダメージ適用
    ApplyDamage(player, target, damageValue, resultCritical, animation_speed);

    // 追加効果
    if (player.IsStormArmor && player.Dead == false)
    {
      bool resultCritical2 = false;
      double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.StormArmor_Damage(player), Fix.DamageSource.Wind, false, critical, ref resultCritical2);
      if (target.IsPhantomOboro != null && this.NowStackInTheCommand)
      {
        addDamageValue = 0;
      }
      ApplyDamage(player, target, addDamageValue, resultCritical2, animation_speed);
    }
    BuffImage stanceOfTheGuard = target.IsStanceOfTheGuard;
    if (target.IsStanceOfTheGuard && target.IsDefense && target.Dead == false)
    {
      Debug.Log("Target is IsStanceOfTheGuard, then Cumulative++");
      int beforeCumulative = stanceOfTheGuard.Cumulative;
      stanceOfTheGuard.Cumulative++;
      if (beforeCumulative != stanceOfTheGuard.Cumulative)
      {
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_DEFENSE_UP, Fix.COLOR_NORMAL);
      }
    }

    return true;
  }

  private void ExecFireBall(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    ExecMagicAttack(player, target, SecondaryLogic.FireBall(player), Fix.DamageSource.Fire, false, critical);
  }

  private void ExecIceNeedle(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.IceNeedle(player), Fix.DamageSource.Ice, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.ICE_NEEDLE, SecondaryLogic.IceNeedle_Turn(player), SecondaryLogic.IceNeedle_Value(player), 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.ICE_NEEDLE, Fix.COLOR_NORMAL);
    }
  }

  private void ExecFreshHeal(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.FreshHeal(player);
    AbstractHealCommand(player, target, healValue);
  }

  private void ExecShadowBlast(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.ShadowBlast(player), Fix.DamageSource.DarkMagic, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.SHADOW_BLAST, SecondaryLogic.ShadowBlast_Turn(player), SecondaryLogic.ShadowBlast_Value(player), 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.SHADOW_BLAST, Fix.COLOR_NORMAL);
    }
  }

  private void ExecAirCutter(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.AirCutter(player), Fix.DamageSource.Wind, false, critical);
    if (success)
    {
      player.objBuffPanel.AddBuff(prefab_Buff, Fix.AIR_CUTTER, SecondaryLogic.AirCutter_Turn(player), SecondaryLogic.AirCutter_Value(player), 0, 0);
      StartAnimation(player.objGroup.gameObject, Fix.AIR_CUTTER, Fix.COLOR_NORMAL);
    }
  }

  private void ExecRockSlum(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.RockSlum(player), Fix.DamageSource.Earth, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.ROCK_SLAM, SecondaryLogic.RockSlum_Turn(player), SecondaryLogic.RockSlum_Value(player), 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.ROCK_SLAM, Fix.COLOR_NORMAL);
    }
  }

  private void ExecStraightSmash(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    ExecNormalAttack(player, target, SecondaryLogic.StraightSmash(player), Fix.DamageSource.Physical, false, critical);
  }

  private void ExecHunterShot(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.HunterShot(player), Fix.DamageSource.Physical, false, critical);
    if (success)
    {
      player.objBuffPanel.AddBuff(prefab_Buff, Fix.HUNTER_SHOT, SecondaryLogic.HunterShot_Turn(player), SecondaryLogic.HunterShot_Value(player), 0, 0);
      StartAnimation(player.objGroup.gameObject, Fix.HUNTER_SHOT, Fix.COLOR_NORMAL);
    }
  }

  private void ExecLegStrike(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.LegStrike(player), Fix.DamageSource.Physical, false, critical);
    if (success)
    {
      player.objBuffPanel.AddBuff(prefab_Buff, Fix.LEG_STRIKE, SecondaryLogic.LegStrike_Turn(player), SecondaryLogic.LegStrike_Value(player), 0, 0);
      StartAnimation(player.objGroup.gameObject, Fix.LEG_STRIKE, Fix.COLOR_NORMAL);
    }
  }

  private void ExecVenomSlash(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.VenomSlash(player), Fix.DamageSource.Physical, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_POISON, SecondaryLogic.VenomSlash_Turn(player), SecondaryLogic.VenomSlash_2(player), 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_POISON, Fix.COLOR_NORMAL);
    }
  }

  private void ExecEnergyBolt(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    ExecNormalAttack(player, target, SecondaryLogic.EnergyBolt(player), Fix.DamageSource.Colorless, false, critical);
  }

  private void ExecShieldBash(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.ShieldBash(player), Fix.DamageSource.Physical, false, critical);
    if (success)
    {
      if (target.GetResistStunLogic())
      {
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_STUN, Fix.COLOR_NORMAL);
        return;
      }

      target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_STUN, SecondaryLogic.ShieldBash_Turn(player), 0, 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_STUN, Fix.COLOR_NORMAL);
    }
  }

  private void ExecAuraOfPower(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.AURA_OF_POWER, SecondaryLogic.AuraOfPower_Turn(player), SecondaryLogic.AuraOfPower_Value(player), 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.AURA_OF_POWER, Fix.COLOR_NORMAL);
  }

  private void ExecDispelMagic(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.RemoveBuff(SecondaryLogic.DispelMagic_Value(player), ActionCommand.BuffType.Positive);
    StartAnimation(target.objGroup.gameObject, Fix.DISPEL_MAGIC, Fix.COLOR_NORMAL);
  }

  private void ExecTrueSight(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.TRUE_SIGHT, SecondaryLogic.TrueSight_Turn(player), SecondaryLogic.TrueSight_Value(player), 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.TRUE_SIGHT, Fix.COLOR_NORMAL);
  }

  private void ExecHeartOfLife(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.HEART_OF_LIFE, SecondaryLogic.HeartOfLife_Turn(player), PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence), 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.HEART_OF_LIFE, Fix.COLOR_NORMAL);
  }

  private void ExecDarknessCircle(Character player, Character target, BuffField target_field_obj)
  {
    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }

    target_field_obj.AddBuff(prefab_Buff, Fix.DARKNESS_CIRCLE, SecondaryLogic.DarknessCircle_Turn(player), SecondaryLogic.DarknessCircle_Value(player), 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.DARKNESS_CIRCLE, Fix.COLOR_NORMAL);
  }

  private void ExecDarkAura(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    // todo
    // 味方一体を対象とする。対象に【黒炎】のBUFFを付与する。
    // ターン経過毎にこのBUFFは累積カウント＋１される。累積カウントが３を超えた場合、消失する。
    //【黒炎】が続く間、対象の魔法攻撃が上昇する。上昇は累積カウントの分だけ上昇する。
  }

  private void ExecOracleCommand(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    double effectValue = SecondaryLogic.OracleCommand(player);
    target.CurrentInstantPoint += (int)((double)Fix.MAX_INSTANT_POINT * effectValue);
    int strValue = (int)((effectValue * 100));
    StartAnimation(target.objGroup.gameObject, "Instant Point +" + strValue.ToString() + "%", Fix.COLOR_NORMAL);
  }

  // Delve II
  private void ExecFlameBlade(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.FLAME_BLADE, SecondaryLogic.FlameBlade_Turn(player), SecondaryLogic.FlameBlade(player), 0, 0);
    StartAnimation(target.objBuffPanel.gameObject, Fix.FLAME_BLADE, Fix.COLOR_NORMAL);
  }

  private void ExecPurePurification(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.RemoveBuff(SecondaryLogic.PurePurification_Effect1(player), ActionCommand.BuffType.Negative);
    StartAnimation(target.objGroup.gameObject, Fix.PURE_PURIFICATION, Fix.COLOR_NORMAL);
  }

  private void ExecDivineCircle(Character player, Character target, BuffField target_field_obj)
  {
    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }

    target_field_obj.AddBuff(prefab_Buff, Fix.DIVINE_CIRCLE, SecondaryLogic.DivineCircle_Turn(player), SecondaryLogic.DivineCircle_Effect1(player), 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.DIVINE_CIRCLE, Fix.COLOR_NORMAL);
  }

  private void ExecBloodSign(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BLOOD_SIGN, SecondaryLogic.BloodSign_Turn(player), SecondaryLogic.BloodSign(player), 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.BLOOD_SIGN, Fix.COLOR_NORMAL);
  }

  private void ExecSkyShield(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.SKY_SHIELD, SecondaryLogic.SkyShield_Turn(player), SecondaryLogic.SkyShield_Value(player), 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.SKY_SHIELD, Fix.COLOR_NORMAL);
  }

  private void ExecCounterAttack(Character player, StackObject[] stack_list)
  {
    if (stack_list.Length >= 2)
    {
      int num = stack_list.Length - 2;

      if (ActionCommand.GetAttribute(stack_list[num].StackName) == ActionCommand.Attribute.Skill)
      {
        // カウンターできない。
        if (stack_list[num].StackName == Fix.WORD_OF_POWER ||
            stack_list[num].StackName == Fix.IRON_BUSTER ||
            stack_list[num].StackName == Fix.PRECISION_STRIKE ||
            stack_list[num].Player.IsWillAwakening != null)
        {
          StartAnimation(stack_list[num].gameObject, "Cannot be countered!", Fix.COLOR_NORMAL);
        }
        else
        {
          StartAnimation(stack_list[num].gameObject, "Counter!", Fix.COLOR_NORMAL);
          Destroy(stack_list[num].gameObject);
          stack_list[num] = null;
        }
      }
      else
      {
        StartAnimation(stack_list[num].gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      }
    }
  }

  private void ExecFlashCounter(Character player, StackObject[] stack_list)
  {
    if (stack_list.Length >= 2)
    {
      // FLASH_COUNTERがスタック先頭なので、一つ前を削除する。
      int num = stack_list.Length - 2;

      if (ActionCommand.GetAttribute(stack_list[num].StackName) == ActionCommand.Attribute.Magic &&
          (ActionCommand.GetBuffType(stack_list[num].StackName) == ActionCommand.BuffType.Negative || ActionCommand.GetBuffType(stack_list[num].StackName) == ActionCommand.BuffType.Positive))
      {
        StartAnimation(stack_list[num].gameObject, "Counter!", Fix.COLOR_NORMAL);
        Destroy(stack_list[num].gameObject);
        stack_list[num] = null;
      }
      else
      {
        StartAnimation(stack_list[num].gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      }
    }
  }

  private void ExecCounterDisallow(Character player, StackObject[] stack_list)
  {
    if (stack_list.Length >= 2)
    {
      int num = stack_list.Length - 2;

      if (ActionCommand.GetAttribute(stack_list[num].StackName) == ActionCommand.Attribute.Skill ||
          (ActionCommand.GetAttribute(stack_list[num].StackName) == ActionCommand.Attribute.Magic))
      {
        // todo CounterAttackやFlashCounterとロジックを統合する必要がある。
        // カウンターできない。
        if (stack_list[num].StackName == Fix.WORD_OF_POWER ||
            stack_list[num].StackName == Fix.IRON_BUSTER ||
            stack_list[num].StackName == Fix.PRECISION_STRIKE ||
            stack_list[num].Player.IsWillAwakening != null)
        {
          StartAnimation(stack_list[num].gameObject, "Cannot be countered!", Fix.COLOR_NORMAL);
        }
        else
        {
          Character target = stack_list[num].Player;
          StartAnimation(stack_list[num].gameObject, "Counter!", Fix.COLOR_NORMAL);
          Destroy(stack_list[num].gameObject);
          stack_list[num] = null;

          target.objBuffPanel.AddBuff(prefab_Buff, Fix.COUNTER_DISALLOW, SecondaryLogic.CounterDisallow_Turn(player), 0, 0, 0);
          StartAnimation(target.objGroup.gameObject, Fix.COUNTER_DISALLOW, Fix.COLOR_NORMAL);
        }
      }
      else
      {
        StartAnimation(stack_list[num].gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      }
    }
  }

  private void ExecHardestParry(Character player, StackObject[] stack_list)
  {
    if (stack_list.Length >= 2)
    {
      int num = stack_list.Length - 2;

      if (ActionCommand.GetAttribute(stack_list[num].StackName) == ActionCommand.Attribute.Skill)
      {
        // todo CounterAttackやFlashCounter, CounterDisallowとロジックを統合する必要がある。
        // カウンターできない。
        if (stack_list[num].StackName == Fix.WORD_OF_POWER ||
            stack_list[num].StackName == Fix.IRON_BUSTER ||
            stack_list[num].StackName == Fix.PRECISION_STRIKE ||
            stack_list[num].Player.IsWillAwakening != null)
        {
          StartAnimation(stack_list[num].gameObject, "Cannot be countered!", Fix.COLOR_NORMAL);
        }
        else
        {
          Character target = stack_list[num].Player;
          StartAnimation(stack_list[num].gameObject, "Counter!", Fix.COLOR_NORMAL);
          Destroy(stack_list[num].gameObject);
          stack_list[num] = null;
        }
      }
      else
      {
        StartAnimation(stack_list[num].gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      }
    }
  }

  private void ExecEverflowMind(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EVERFLOW_MIND, SecondaryLogic.EverflowMind_Turn(player), SecondaryLogic.EverflowMind_Effect1(player), 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EVERFLOW_MIND, Fix.COLOR_NORMAL);
  }

  private void ExecInnerInspiration(Character player, Character target)
  {
    double effectValue = SecondaryLogic.InnerInspiration_Effect1(player) * target.MaxSkillPoint;
    AbstractGainSkillPoint(player, target, effectValue);
  }

  private void ExecSeventhPrinciple(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.SEVENTH_PRINCIPLE, SecondaryLogic.SeventhPrinciple_Turn(player), 0, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.SEVENTH_PRINCIPLE, Fix.COLOR_NORMAL);
  }

  private void ExecStanceOfTheBlade(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.STANCE_OF_THE_BLADE, SecondaryLogic.StanceOfTheBlade_Turn(player), SecondaryLogic.StanceOfTheBlade(player), 0, 0);
    StartAnimation(player.objGroup.gameObject, Fix.STANCE_OF_THE_BLADE, Fix.COLOR_NORMAL);
  }

  private void ExecSpeedStep(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.SPEED_STEP, SecondaryLogic.SpeedStep_Turn(player), SecondaryLogic.SpeedStep(player), 0, 0);
    StartAnimation(player.objGroup.gameObject, Fix.SPEED_STEP, Fix.COLOR_NORMAL);
  }

  private void ExecStanceOfTheGuard(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.STANCE_OF_THE_GUARD, SecondaryLogic.StanceOfTheGuard_Turn(player), SecondaryLogic.StanceOfTheGuard(player), 0, 0);
    StartAnimation(player.objGroup.gameObject, Fix.STANCE_OF_THE_GUARD, Fix.COLOR_NORMAL);
  }

  private void ExecMultipleShot(Character player, List<Character> target_list, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      ExecNormalAttack(player, target_list[ii], SecondaryLogic.MultipleShot(player), Fix.DamageSource.Physical, false, critical);
    }
  }

  private void ExecLeylineSchema(Character player, BuffField target_field_obj)
  {
    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }

    target_field_obj.AddBuff(prefab_Buff, Fix.LEYLINE_SCHEMA, SecondaryLogic.LeylineSchema_Turn(player), SecondaryLogic.LeylineSchema_Effect1(player), 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.LEYLINE_SCHEMA, Fix.COLOR_NORMAL);
  }

  private void ExecInvisibleBind(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.InvisibleBind(player), Fix.DamageSource.Physical, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_BIND, SecondaryLogic.InvibisleBind_Turn(player), 0, 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BIND, Fix.COLOR_NORMAL);
    }
  }

  private void ExecFortuneSpirit(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.FORTUNE_SPIRIT, SecondaryLogic.FortuneSpirit_Turn(player), SecondaryLogic.FortuneSpirit_Effect1(player), 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.FORTUNE_SPIRIT, Fix.COLOR_NORMAL);
  }

  private void ExecSpiritualRest(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.IsStun)
    {
      target.RemoveTargetBuff(Fix.EFFECT_STUN);
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_REMOVE_STUN, Fix.COLOR_NORMAL);
    }
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_RESIST_STUN, SecondaryLogic.SpiritualRest_Turn(player), 0, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.BUFF_RESIST_STUN, Fix.COLOR_NORMAL);
  }

  private void ExecZeroImmunity(Character player, Character target)
  {
    // todo
  }

  private void ExecCircleSlash(Character player, List<Character> target_list, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      ExecNormalAttack(player, target_list[ii], SecondaryLogic.NormalAttack(player), Fix.DamageSource.Physical, false, critical);
    }
  }

  private void ExecDoubleSlash(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < 2; ii++)
    {
      ExecNormalAttack(player, target, SecondaryLogic.DoubleSlash(player), Fix.DamageSource.Physical, false, critical);
    }
  }

  private void ExecMeteorBullet(Character player, List<Character> target_list, Fix.CriticalType critical)
  {
    for (int ii = 0; ii < SecondaryLogic.MeteorBullet_Effect1(player); ii++)
    {
      int rand = AP.Math.RandomInteger(target_list.Count);
      ExecMagicAttack(player, target_list[rand], SecondaryLogic.MeteorBullet(player), Fix.DamageSource.Fire, false, critical);
    }
  }

  private void ExecBlueBullet(Character player, Character target, Fix.CriticalType critical)
  {
    for (int ii = 0; ii < SecondaryLogic.BlueBullet_Effect1(player); ii++)
    {
      ExecMagicAttack(player, target, SecondaryLogic.BlueBullet(player), Fix.DamageSource.Ice, false, critical);
    }
  }

  public void ExecHolyBreath(Character player, List<Character> target_list)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.HolyBreath(player);
      AbstractHealCommand(player, target_list[ii], healValue);
    }
  }

  public void ExecBlackContract(Character player)
  {
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.BLACK_CONTRACT, SecondaryLogic.BlackContract_Turn(player), SecondaryLogic.BlackContract(player), 0, 0);
    StartAnimation(player.objGroup.gameObject, Fix.BLACK_CONTRACT, Fix.COLOR_NORMAL);
  }

  private void ExecSonicPulse(Character player, Character target, Fix.CriticalType critical)
  {
    bool success = ExecMagicAttack(player, target, SecondaryLogic.SonicPulse(player), Fix.DamageSource.Wind, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.SONIC_PULSE, SecondaryLogic.SonicPulse_Turn(player), SecondaryLogic.SonicPulse_Value(player), 0, 0);
    }
  }

  private void ExecLandShatter(Character player, Character target, Fix.CriticalType critical)
  {
    bool success = ExecMagicAttack(player, target, SecondaryLogic.LandShatter(player), Fix.DamageSource.Earth, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.LAND_SHATTER, SecondaryLogic.LandShatter_Turn(player), 0, 0, 0);
      if (target.CurrentActionCommand == Fix.DEFENSE || target.CurrentActionCommand == Fix.DEFENSE_JP)
      {
        target.CurrentActionCommand = Fix.STAY;
        target.txtActionCommand.text = Fix.STAY;
        SetupActionCommandButton(target.objMainButton, Fix.STAY);
      }
    }
  }

  public void ExecConcussiveHit(Character player, Character target, Fix.CriticalType critical)
  {
    bool success = ExecNormalAttack(player, target, SecondaryLogic.ConcussiveHit(player), Fix.DamageSource.Physical, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.CONCUSSIVE_HIT, SecondaryLogic.ConcussiveHit_Turn(player), SecondaryLogic.ConcussiveHit(player), 0, 0);
    }
  }

  public void ExecAetherDrive(Character player, Character target, BuffField target_field_obj)
  {
    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }

    target_field_obj.AddBuff(prefab_Buff, Fix.AETHER_DRIVE, SecondaryLogic.AetherDrive_Turn(player), SecondaryLogic.AetherDrive_Effect(player), 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.AETHER_DRIVE, Fix.COLOR_NORMAL);
  }

  public void ExecKillingWave(Character player, List<Character> target_list, BuffField target_field_obj)
  {
    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }

    target_field_obj.AddBuff(prefab_Buff, Fix.KILLING_WAVE, SecondaryLogic.KillingWave_Turn(player), SecondaryLogic.KillingWave_Effect(player), 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.KILLING_WAVE, Fix.COLOR_NORMAL);
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      if (target_list[ii].CurrentLife > target_list[ii].MaxLife)
      {
        target_list[ii].CurrentLife = target_list[ii].MaxLife;
      }
    }
  }

  public void ExecWordOfPower(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    ExecMagicAttack(player, target, SecondaryLogic.WordOfPower(player), Fix.DamageSource.Physical, true, critical);
  }

  public void ExecEyeOfTheIsshin(Character player, Character target)
  {
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.EYE_OF_THE_ISSHIN, SecondaryLogic.EyeOfTheIsshin_Turn(player), SecondaryLogic.EyeOfTheIsshin_Effect1(player), 0, 0);
    StartAnimation(player.objGroup.gameObject, Fix.EYE_OF_THE_ISSHIN, Fix.COLOR_NORMAL);
  }

  public void ExecBoneCrush(Character player, Character target, Fix.CriticalType critical)
  {
    bool success = ExecNormalAttack(player, target, SecondaryLogic.NormalAttack(player), Fix.DamageSource.Physical, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.BONE_CRUSH, SecondaryLogic.BoneCrush_Turn(player), SecondaryLogic.BoneCrush_Value(player), 0, 0);
    }
  }

  public void ExecIrregularStep(Character player, Character target)
  {
    this.NowIrregularStepPlayer = player;
    this.NowIrregularStepTarget = target;
    this.NowIrregularStepCounter = SecondaryLogic.IrregularStep_GaugeStep(player) * BATTLE_GAUGE_WITDH;
    this.NowIrregularStepMode = true;
  }
  private void ExecPlayIrregularStep()
  {
    if (this.NowIrregularStepCounter > 0)
    {
      float factor = (float)PrimaryLogic.BattleSpeed(this.NowIrregularStepPlayer) * 2.00f;
      UpdatePlayerArrow(this.NowIrregularStepPlayer, factor);
      this.NowIrregularStepCounter = this.NowIrregularStepCounter - factor * BATTLE_GAUGE_WITDH / 100.0f;
    }

    if (this.NowIrregularStepCounter <= 0.0f)
    {
      ExecNormalAttack(this.NowIrregularStepPlayer, this.NowIrregularStepTarget, SecondaryLogic.IrregularStep_Damage(this.NowIrregularStepPlayer), Fix.DamageSource.Physical, false, Fix.CriticalType.Random);
      this.NowIrregularStepPlayer = null;
      this.NowIrregularStepTarget = null;
      this.NowIrregularStepCounter = 0;
      this.NowIrregularStepMode = false;
    }
  }

  private void ExecPlayUnintentionalHit()
  {
    if (this.NowUnintentionalHitCounter > 0)
    {
      // プレイヤーのゲージを進める
      float factor = (float)PrimaryLogic.BattleSpeed(this.NowUnintentionalHitPlayer) * 2.00f;
      UpdatePlayerArrow(this.NowUnintentionalHitPlayer, factor);

      // ターゲットのゲージを遅らせる
      float factor2 = (float)PrimaryLogic.BattleSpeed(this.NowUnintentionalHitTarget) * 2.00f;
      UpdatePlayerArrow(this.NowUnintentionalHitTarget, factor2 * -1);

      this.NowUnintentionalHitCounter = this.NowUnintentionalHitCounter - factor * BATTLE_GAUGE_WITDH / 100.0f;
    }

    if (this.NowUnintentionalHitCounter <= 0.0f)
    {
      this.NowUnintentionalHitPlayer = null;
      this.NowUnintentionalHitTarget = null;
      this.NowUnintentionalHitCounter = 0;
      this.NowUnintentionalHitMode = false;
    }
  }

  public void ExecSigilOfThePending(Character player, Character target)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.SIGIL_OF_THE_PENDING, SecondaryLogic.SigilOfThePending_Turn(player), 0, 0, 0);
  }

  public void ExecStormArmor(Character player, Character target)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.STORM_ARMOR, SecondaryLogic.StormArmor_Turn(player), SecondaryLogic.StormArmor_SpeedUp(player), SecondaryLogic.StormArmor_Damage(player), 0);
    StartAnimation(target.objGroup.gameObject, Fix.STORM_ARMOR, Fix.COLOR_NORMAL);
  }

  public void ExecMuteImpulse(Character player, Character target, Fix.CriticalType critical)
  {
    int positiveCount = target.GetPositiveBuff() + 1;
    ExecMagicAttack(player, target, SecondaryLogic.MuteImpulse(player) * positiveCount, Fix.DamageSource.Colorless, false, critical);
  }

  public void ExecVoiceOfVigor(Character player, List<Character> target_list)
  {
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      target_list[ii].objBuffPanel.AddBuff(prefab_Buff, Fix.VOICE_OF_VIGOR, SecondaryLogic.VoiceOfVigor_Turn(player), SecondaryLogic.VoiceOfVigor(player), 0, 0);
      StartAnimation(target_list[ii].objGroup.gameObject, Fix.VOICE_OF_VIGOR, Fix.COLOR_NORMAL);

      ExecLifeGain(target_list[ii], (target_list[ii].MaxLife / 10.0f));
    }
  }

  public void ExecUnseenAid(Character player, List<Character> target_list)
  {
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      target_list[ii].objBuffPanel.RemoveAll();
      StartAnimation(target_list[ii].objGroup.gameObject, Fix.BUFF_REMOVE_ALL, Fix.COLOR_NORMAL);
    }
  }

  public void ExecGaleWind(Character player)
  {
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.GALE_WIND, SecondaryLogic.GaleWind_Turn(player), 0, 0, 0);
    StartAnimation(player.objGroup.gameObject, Fix.GALE_WIND, Fix.COLOR_NORMAL);
  }

  public void ExecFreezingCube(Character player, Character target, BuffField target_field_obj, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }
    bool success = ExecMagicAttack(player, target, SecondaryLogic.FreezingCube(player), Fix.DamageSource.Ice, false, critical);
    if (success)
    {
      target_field_obj.AddBuff(prefab_Buff, Fix.FREEZING_CUBE, SecondaryLogic.FreezingCube_Turn(player), SecondaryLogic.FreezingCube_Effect(player), PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.FreezingCube_Effect2(player), 0);
      StartAnimation(target_field_obj.gameObject, Fix.FREEZING_CUBE, Fix.COLOR_NORMAL);
    }
  }

  private void ExecVolcanicBlaze(Character player, List<Character> target_list, BuffField target_field_obj, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      ExecMagicAttack(player, target_list[ii], SecondaryLogic.VolcanicBlaze(player), Fix.DamageSource.Fire, false, critical);
    }
    target_field_obj.AddBuff(prefab_Buff, Fix.VOLCANIC_BLAZE, SecondaryLogic.VolcanicBlaze_Turn(player), SecondaryLogic.VolcanicBlaze_Effect(player), PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.VolcanicBlaze_Effect2(player), 0);
    StartAnimation(target_field_obj.gameObject, Fix.VOLCANIC_BLAZE, Fix.COLOR_NORMAL);
  }

  private void ExecIronBuster(Character player, Character target, List<Character> target_list, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    ExecNormalAttack(player, target, SecondaryLogic.IronBuster(player), Fix.DamageSource.Physical, false, critical);
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      if (target_list[ii].Equals(target)) { continue; } // 同じターゲットはスキップ対象
      ExecNormalAttack(player, target_list[ii], SecondaryLogic.IronBuster_2(player), Fix.DamageSource.Physical, false, critical);
    }
  }

  private void ExecAngelicEcho(Character player, List<Character> target_list, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.AngelicEcho(player);
      AbstractHealCommand(player, target_list[ii], healValue);
    }

    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }
    target_field_obj.AddBuff(prefab_Buff, Fix.ANGELIC_ECHO, SecondaryLogic.AngelicEcho_Turn(player), PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.AngelicEcho_Effect(player), 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.ANGELIC_ECHO, Fix.COLOR_NORMAL);
  }

  private void ExecCursedEvangile(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    bool success = ExecMagicAttack(player, target, SecondaryLogic.CursedEvangile(player), Fix.DamageSource.DarkMagic, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.CURSED_EVANGILE, SecondaryLogic.CursedEvangile_Turn(player), PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.CursedEvangile_Effect(player), SecondaryLogic.CursedEvangile_SlepTurn(player), PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.CursedEvangile_SlipFactor(player));
      StartAnimation(target.objGroup.gameObject, Fix.CURSED_EVANGILE, Fix.COLOR_NORMAL);
    }
  }

  private void ExecPenetrationArrow(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.PenetrationArrow(player), Fix.DamageSource.Physical, true, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.PENETRATION_ARROW, SecondaryLogic.PenetrationArrow_Turn(player), PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Strength) * SecondaryLogic.PenetrationArrow_Effect(player), SecondaryLogic.PenetrationArrow_Effect2(player), 0);
      StartAnimation(target.objGroup.gameObject, Fix.PENETRATION_ARROW, Fix.COLOR_NORMAL); // todo AddBuffでStartAnimationしていないケースがある。
    }
  }

  private void ExecCircleOfTheSerenity(Character player, List<Character> target_list, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      // target_list[ii].RemoveTargetBuff(Fix.EFFECT_POISON); // 猛毒は解除できない
      target_list[ii].RemoveTargetBuff(Fix.EFFECT_SILENT);
      target_list[ii].RemoveTargetBuff(Fix.EFFECT_BIND);
      target_list[ii].RemoveTargetBuff(Fix.EFFECT_SLEEP);
      target_list[ii].RemoveTargetBuff(Fix.EFFECT_STUN);
      target_list[ii].RemoveTargetBuff(Fix.EFFECT_PARALYZE);
      // target_list[ii].RemoveTargetBuff(Fix.EFFECT_FREEZE); // 凍結は解除できない
      target_list[ii].RemoveTargetBuff(Fix.EFFECT_FEAR);
      target_list[ii].RemoveTargetBuff(Fix.EFFECT_TEMPTATION);
      target_list[ii].RemoveTargetBuff(Fix.EFFECT_SLOW);
      target_list[ii].RemoveTargetBuff(Fix.EFFECT_DIZZY);
      // target_list[ii].RemoveTargetBuff(Fix.EFFECT_SLIP); // 出血は解除できない
      // target_list[ii].RemoveTargetBuff(Fix.EFFECT_CANNOT_RESURRECT); // 復活不可は解除できない
    }
    target_field_obj.AddBuff(prefab_Buff, Fix.CIRCLE_OF_SERENITY, SecondaryLogic.CircleOfTheSerenity_Turn(player), 0, 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.CIRCLE_OF_SERENITY, Fix.COLOR_NORMAL);
  }

  private void ExecRagingStorm(Character player, List<Character> target_list, BuffField target_field_obj, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int jj = 0; jj < 2; jj++)
    {
      for (int ii = 0; ii < target_list.Count; ii++)
      {
        ExecNormalAttack(player, target_list[ii], SecondaryLogic.RagingStorm(player), Fix.DamageSource.Physical, false, critical);
      }
    }
    target_field_obj.AddBuff(prefab_Buff, Fix.RAGING_STORM, SecondaryLogic.RagingStorm_Turn(player), SecondaryLogic.RagingStorm_Effect1(player), 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.RAGING_STORM, Fix.COLOR_NORMAL);
  }

  private void ExecPrecisionStrike(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    ExecNormalAttack(player, target, SecondaryLogic.PrecisionStrike(player), Fix.DamageSource.Physical, false, Fix.CriticalType.Absolute);
  }

  private void ExecUnintentionalHit(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.UnintentionalHit(player), Fix.DamageSource.Physical, false, critical);
    if (success)
    {
      ExecBuffParalyze(player, target, SecondaryLogic.UnintentionalHit_Turn(player), 0);

      this.NowUnintentionalHitPlayer = player;
      this.NowUnintentionalHitTarget = target;
      this.NowUnintentionalHitCounter = SecondaryLogic.UnintentionalHit_GaugeStep(player) * BATTLE_GAUGE_WITDH;
      this.NowUnintentionalHitMode = true;
    }
  }

  private void ExecWillAwakening(Character player, Character target)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.WILL_AWAKENING, SecondaryLogic.WillAwakening_Turn(player), 0, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.WILL_AWAKENING, Fix.COLOR_NORMAL); // todo AddBuffでStartAnimationしていないケースがある。
  }

  private void ExecPhantomOboro(Character player)
  {
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.PHANTOM_OBORO, SecondaryLogic.PhantomOboro_Turn(player), 0, 0, 0);
    StartAnimation(player.objGroup.gameObject, Fix.PHANTOM_OBORO, Fix.COLOR_NORMAL); // todo AddBuffでStartAnimationしていないケースがある。
  }

  private void ExecDeadlyDrive(Character player)
  {
    player.objBuffPanel.AddBuff(prefab_Buff, Fix.DEADLY_DRIVE, SecondaryLogic.DeadlyDrive_Turn(player), SecondaryLogic.DeadlyDrive_Effect1(player), SecondaryLogic.DeadlyDrive_Effect2(player), SecondaryLogic.DeadlyDrive_Effect3(player));
    StartAnimation(player.objGroup.gameObject, Fix.DEADLY_DRIVE, Fix.COLOR_NORMAL); // todo AddBuffでStartAnimationしていないケースがある。
  }

  private void ExecDominationField(Character player, BuffField target_field_obj)
  {
    target_field_obj.AddBuff(prefab_Buff, Fix.DOMINATION_FIELD, SecondaryLogic.DominationField_Turn(player), SecondaryLogic.DominationField_Effect1(player), SecondaryLogic.DominationField_Effect2(player), 0);
    StartAnimation(target_field_obj.gameObject, Fix.DOMINATION_FIELD, Fix.COLOR_NORMAL);
  }

  private void ExecFlameStrike(Character player, Character target, Fix.CriticalType critical)
  {
    bool success = ExecMagicAttack(player, target, SecondaryLogic.FlameStrike(player), Fix.DamageSource.Fire, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.FLAME_STRIKE, SecondaryLogic.FlameStrike_Turn(player), 0, 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.FLAME_STRIKE, Fix.COLOR_NORMAL);
    }
  }

  private void ExecFrostLance(Character player, Character target, Fix.CriticalType critical)
  {
    bool success = ExecMagicAttack(player, target, SecondaryLogic.FrostLance(player), Fix.DamageSource.Ice, false, critical);
    if (success)
    {
      target.objBuffPanel.AddBuff(prefab_Buff, Fix.FROST_LANCE, SecondaryLogic.FrostLance_Turn(player), 0, 0, 0);
      StartAnimation(target.objGroup.gameObject, Fix.FROST_LANCE, Fix.COLOR_NORMAL);
    }
  }

  private void ExecShiningHeal(Character player, Character target, Fix.CriticalType critical, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    double healValue = target.MaxLife;
    AbstractHealCommand(player, target, healValue);
    target_field_obj.AddBuff(prefab_Buff, Fix.SHINING_HEAL, SecondaryLogic.ShiningHeal_Turn(player), PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.ShiningHeal_Effect1(player), 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.SHINING_HEAL, Fix.COLOR_NORMAL);
  }

  private void ExecCircleOfTheDespair(Character player, BuffField target_field_obj)
  {
    target_field_obj.AddBuff(prefab_Buff, Fix.CIRCLE_OF_THE_DESPAIR, SecondaryLogic.CircleOfDespair_Turn(player), SecondaryLogic.CircleOfDespair_Effect1(player), 0, 0);
    StartAnimation(target_field_obj.gameObject, Fix.CIRCLE_OF_THE_DESPAIR, Fix.COLOR_NORMAL);
  }

  private bool ExecUseRedPotion(Character target, string command_name)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    string itemName = string.Empty;

    if (command_name == Fix.USE_RED_POTION_1 || command_name == Fix.SMALL_RED_POTION) { itemName = Fix.SMALL_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_2 || command_name == Fix.NORMAL_RED_POTION) { itemName = Fix.NORMAL_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_3 || command_name == Fix.LARGE_RED_POTION) { itemName = Fix.LARGE_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_4 || command_name == Fix.HUGE_RED_POTION) { itemName = Fix.HUGE_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_5 || command_name == Fix.HQ_RED_POTION) { itemName = Fix.HQ_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_6 || command_name == Fix.THQ_RED_POTION) { itemName = Fix.THQ_RED_POTION; }
    if (command_name == Fix.USE_RED_POTION_7 || command_name == Fix.PERFECT_RED_POTION) { itemName = Fix.PERFECT_RED_POTION; }

    if (itemName == string.Empty)
    {
      Debug.Log("Red Potion name is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    if (One.TF.FindBackPackItem(itemName) == false)
    {
      Debug.Log("Red Potion is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    Item current = new Item(itemName);
    One.TF.DeleteBackpack(current, 1);
    double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
    AbstractHealCommand(null, target, effectValue);
    return true;
  }

  private bool ExecUseBluePotion(Character target, string command_name)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    string itemName = string.Empty;

    if (command_name == Fix.USE_BLUE_POTION_1 || command_name == Fix.SMALL_BLUE_POTION) { itemName = Fix.SMALL_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_2 || command_name == Fix.NORMAL_BLUE_POTION) { itemName = Fix.NORMAL_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_3 || command_name == Fix.LARGE_BLUE_POTION) { itemName = Fix.LARGE_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_4 || command_name == Fix.HUGE_BLUE_POTION) { itemName = Fix.HUGE_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_5 || command_name == Fix.HQ_BLUE_POTION) { itemName = Fix.HQ_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_6 || command_name == Fix.THQ_BLUE_POTION) { itemName = Fix.THQ_BLUE_POTION; }
    if (command_name == Fix.USE_BLUE_POTION_7 || command_name == Fix.PERFECT_BLUE_POTION) { itemName = Fix.PERFECT_BLUE_POTION; }

    if (itemName == string.Empty)
    {
      Debug.Log("Blue Potion name is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    if (One.TF.FindBackPackItem(itemName) == false)
    {
      Debug.Log("Blue Potion is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    Item current = new Item(itemName);
    One.TF.DeleteBackpack(current, 1);
    double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
    AbstractGainManaPoint(null, target, effectValue);
    return true;
  }

  private bool ExecUseGreenPotion(Character target, string command_name)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    string itemName = string.Empty;

    if (command_name == Fix.USE_GREEN_POTION_1 || command_name == Fix.SMALL_GREEN_POTION) { itemName = Fix.SMALL_GREEN_POTION; }
    if (command_name == Fix.USE_GREEN_POTION_2 || command_name == Fix.NORMAL_GREEN_POTION) { itemName = Fix.NORMAL_GREEN_POTION; }
    if (command_name == Fix.USE_GREEN_POTION_3 || command_name == Fix.LARGE_GREEN_POTION) { itemName = Fix.LARGE_GREEN_POTION; }
    if (command_name == Fix.USE_GREEN_POTION_4 || command_name == Fix.HUGE_GREEN_POTION) { itemName = Fix.HUGE_GREEN_POTION; }
    if (command_name == Fix.USE_GREEN_POTION_5 || command_name == Fix.HQ_GREEN_POTION) { itemName = Fix.HQ_GREEN_POTION; }
    if (command_name == Fix.USE_GREEN_POTION_6 || command_name == Fix.THQ_GREEN_POTION) { itemName = Fix.THQ_GREEN_POTION; }
    if (command_name == Fix.USE_GREEN_POTION_7 || command_name == Fix.PERFECT_GREEN_POTION) { itemName = Fix.PERFECT_GREEN_POTION; }

    if (itemName == string.Empty)
    {
      Debug.Log("Green Potion name is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    if (One.TF.FindBackPackItem(itemName) == false)
    {
      Debug.Log("Green Potion is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }

    Item current = new Item(itemName);
    One.TF.DeleteBackpack(current, 1);
    double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
    AbstractGainSkillPoint(null, target, effectValue);
    return true;
  }

  private bool ExecPureCleanWater(Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    if (One.TF.FindBackPackItem(Fix.PURE_CLEAN_WATER) == false)
    {
      Debug.Log("PURE_CLEAN_WATER is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }
    if (One.TF.AlreadyPureCleanWater)
    {
      Debug.Log("PURE_CLEAN_WATER is already used...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_ALREADY_USED, Fix.COLOR_NORMAL);
      return false;
    }

    One.TF.AlreadyPureCleanWater = true;
    double effectValue = target.MaxLife;
    AbstractHealCommand(null, target, effectValue);
    return true;
  }

  private bool ExecSinseisui(Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    if (One.TF.FindBackPackItem(Fix.PURE_SINSEISUI) == false)
    {
      Debug.Log("SINSEISUI is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }
    if (One.TF.AlreadySinseisui)
    {
      Debug.Log("SINSEISUI is already used...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_ALREADY_USED, Fix.COLOR_NORMAL);
      return false;
    }

    One.TF.AlreadySinseisui = true;
    double effectValue = target.MaxManaPoint;
    AbstractGainManaPoint(null, target, effectValue);
    return true;
  }

  private void ExecLifeGain(Character target, double effectValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    AbstractHealCommand(null, target, effectValue);
  }

  private void ExecPoisonDamage(Character target, double effectValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target == null) { Debug.Log("target is null. then no effect."); return; }
    if (target.Dead) { Debug.Log("target is dead. then no effect."); return; }

    if (effectValue <= 0) { effectValue = 0; }
    int result = (int)effectValue;
    Debug.Log(target.FullName + " " + result.ToString() + " damage");
    target.CurrentLife -= result;
    target.txtLife.text = target.CurrentLife.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL);
  }

  private void ExecElementalDamage(Character target, Fix.DamageSource damage_source, double effect_value)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target == null) { Debug.Log("target is null. then no effect."); return; }
    if (target.Dead) { Debug.Log("target is dead. then no effect."); return; }

    if (effect_value <= 0) { effect_value = 0; }
    int result = (int)effect_value;
    Debug.Log(target.FullName + " " + result.ToString() + " damage");
    target.CurrentLife -= result;
    target.txtLife.text = target.CurrentLife.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL);
  }

  private void ExecSlipDamage(Character target, double effectValue)
  {
    // 毒と出血は効果は同じだが、毒はアップキープ、出血は行動時なので、効果は同じで良い。
    Debug.Log(MethodBase.GetCurrentMethod());

    if (target == null) { Debug.Log("target is null. then no effect."); return; }
    if (target.Dead) { Debug.Log("target is dead. then no effect."); return; }

    if (effectValue <= 0) { effectValue = 0; }
    int result = (int)effectValue;
    Debug.Log(target.FullName + " " + result.ToString() + " damage");
    target.CurrentLife -= result;
    target.txtLife.text = target.CurrentLife.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL);
  }

  private void ExecBuffPoison(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistPoisonLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_POISON, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_POISON, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_POISON, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSilent(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistSilenceLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_SILENCE, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_SILENT, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_SILENT, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBind(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistBindLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_BIND, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_BIND, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BIND, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSleep(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistSleepLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_SLEEP, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_SLEEP, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_SLEEP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffStun(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistStunLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_STUN, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_STUN, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_STUN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffParalyze(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistParalyzeLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_PARALYZE, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_PARALYZE, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PARALYZE, Fix.COLOR_NORMAL);
  }

  private void ExecBuffFreeze(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistFreezeLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_FREEZE, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_FREEZE, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_FREEZE, Fix.COLOR_NORMAL);
  }

  private void ExecBuffFear(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistFearLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_FEAR, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_FEAR, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_FEAR, Fix.COLOR_NORMAL);
  }

  private void ExecBuffTemptation(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistTemptationLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_TEMPTATION, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_TEMPTATION, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_TEMPTATION, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSlow(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistSlowLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_SLOW, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_SLOW, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_SLOW, Fix.COLOR_NORMAL);
  }

  private void ExecBuffDizzy(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistDizzyLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_DIZZY, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_DIZZY, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DIZZY, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSlip(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistSlipLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_SLIP, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_SLIP, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_SLIP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffCannotResurrect(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistCannotResurrectLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_CANNOT_RESURRECT, Fix.COLOR_NORMAL);
      return;
    }

    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_CANNOT_RESURRECT, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_CANNOT_RESURRECT, Fix.COLOR_NORMAL);
  }

  private void ExecBuffPhysicalAttackUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PA_UP, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PA_UP, Fix.COLOR_NORMAL);
  }
  private void ExecBuffPhysicalAttackDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PA_DOWN, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PA_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffPhysicalDefenseUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PD_UP, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PD_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffPhysicalDefenseDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PD_DOWN, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PD_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffMagicAttackUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_MA_UP, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_MA_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffMagicAttackDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_MA_DOWN, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_MA_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffMagicDefenceUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_MD_UP, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_MD_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffMagicDefenceDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_MD_DOWN, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_MD_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattleSpeedUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_BS_UP, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BS_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattleSpeedDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_BS_DOWN, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BS_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattleResponseUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_BR_UP, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BR_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattleResponseDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_BR_DOWN, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_BR_DOWN, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattlePotentialUp(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PO_UP, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PO_UP, Fix.COLOR_NORMAL);
  }

  private void ExecBuffBattlePotentialDown(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_PO_DOWN, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_PO_DOWN, Fix.COLOR_NORMAL);
  }

  private void BuffUpFire(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.EFFECT_POWERUP_FIRE, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_POWERUP_FIRE, Fix.COLOR_NORMAL);
  }

  private void ExecBuffSyutyuDanzetsu(Character player, Character target, int turn, double effect_value)
  {
    target.objBuffPanel.AddBuff(prefab_Buff, Fix.BUFF_SYUTYU_DANZETSU, turn, effect_value, 0, 0);
    StartAnimation(target.objGroup.gameObject, Fix.BUFF_SYUTYU_DANZETSU, Fix.COLOR_NORMAL);
  }

  #region "元核"
  private void ExecEinShutyuDanzetsu(Character player, Character target)
  {
    ExecBuffSyutyuDanzetsu(player, target, Fix.INFINITY, PrimaryLogic.Potential(player));
  }

  private void ExecLanaPerfectSpell(Character player, Character target)
  {
    // todo
  }

  private void ExecEoneMuinSong(Character player, Character target)
  {
    // todo
  }

  private void ExecBillyVictoryStyle(Character player, Character target)
  {
    // todo
  }

  private void ExecAdelEndlessMemory(Character player, Character target)
  {
    // todo
  }

  private void ExecRoStanceOfMuni(Character player, Character target)
  {
    // todo
  }
  #endregion

  #region "General"
  private double PhysicalDamageLogic(Character player, Character target, double magnify, Fix.DamageSource attr, bool ignore_target_defense, Fix.CriticalType critical, ref bool result_critical)
  {
    // 攻撃コマンドのダメージを算出
    double damageValue = 0.0f;
    if (attr == Fix.DamageSource.Colorless)
    {
      damageValue = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * magnify;
    }
    else
    {
      damageValue = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Strength) * magnify;
    }

    double debug1 = damageValue;
    Debug.Log("PrimaryLogic.PhysicalAttack: " + debug1.ToString());

    // Buff効果による増強（物理属性専用UPは現時点では存在しない）

    // クリティカル判定
    result_critical = false;
    int rand = AP.Math.RandomInteger(100);
    int current = SecondaryLogic.CriticalRate(player);
    Debug.Log("PhysicalDamageLogic CriticalRate ( " + rand.ToString() + " / " + current + " ) ");
    if (player.CannotCritical == false &&
        ((critical == Fix.CriticalType.Random && rand <= current))
       )
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      debug1 = damageValue;
      result_critical = true;
      Debug.Log("PhysicalDamageLogic detect Critical! (Random) ( " + rand.ToString() + " / " + current + " ) " + damageValue.ToString());
    }
    if (critical == Fix.CriticalType.Absolute)
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      debug1 = damageValue;
      result_critical = true;
      Debug.Log("PhysicalDamageLogic detect Critical! (Absolute) " + damageValue.ToString());
    }


    // ターゲットの物理防御を差し引く
    double defenseValue = PrimaryLogic.PhysicalDefense(target);
    double debug2 = defenseValue;
    Debug.Log("PrimaryLogic.PhysicalDefense: " + debug2.ToString());

    if (player.IsEyeOfTheIsshin)
    {
      double reduce = 1.00f - player.IsEyeOfTheIsshin.EffectValue;
      if (reduce <= 0.0f) { reduce = 0.0f; }
      Debug.Log("player.IsEyeOfTheIsshin.EffectValue: " + reduce.ToString("F2"));
      defenseValue = defenseValue * reduce;
      debug2 = defenseValue;
      Debug.Log("PrimaryLogic.PhysicalDefense(EoT): " + debug2.ToString());
    }
    damageValue -= defenseValue;
    double debug3 = damageValue;
    Debug.Log("Physical-DamageValue: " + debug1.ToString("F2") + " - " + debug2.ToString("F2") + " = " + debug3.ToString("F2"));

    // ターゲットが防御姿勢であれば、ダメージを軽減する
    if (target.IsDefense)
    {
      damageValue = damageValue * SecondaryLogic.DefenseFactor(target);
      Debug.Log("Target is Defense mode: " + damageValue.ToString("F2"));
    }

    // ダメージ量が負の値になる場合は０とみなす。
    if (damageValue <= 0) { damageValue = 0; }

    return damageValue;
  }

  private double MagicDamageLogic(Character player, Character target, double magnify, Fix.DamageSource attr, bool ignore_target_defense, Fix.CriticalType critical, ref bool result_critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " player: " + player.FullName + " target: " + target.FullName + " magnify: " + magnify + " attr: " + attr + " critical: " + critical);
    // 魔法コマンドのダメージを算出
    double damageValue = 0.0f;
    if (attr == Fix.DamageSource.Physical)
    {
      damageValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Strength) * magnify;
    }
    else
    {
      damageValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * magnify;
    }

    double debug0 = damageValue;
    Debug.Log("PrimaryLogic.MagicDamage: " + debug0.ToString());

    // Buff効果による増強
    if (attr == Fix.DamageSource.Fire)
    {
      if (player.IsUpFire)
      {
        Debug.Log("damageValue UpFire: " + player.IsUpFire.EffectValue.ToString());
        damageValue = damageValue * player.IsUpFire.EffectValue;
      }
      if (player.MainWeapon != null && player.MainWeapon.AmplifyFire > 1.00f) { damageValue = damageValue * player.MainWeapon.AmplifyFire; }
      if (player.SubWeapon != null && player.SubWeapon.AmplifyFire > 1.00f) { damageValue = damageValue * player.SubWeapon.AmplifyFire; }
      if (player.MainArmor != null && player.MainArmor.AmplifyFire > 1.00f) { damageValue = damageValue * player.MainArmor.AmplifyFire; }
      if (player.Accessory1 != null && player.Accessory1.AmplifyFire > 1.00f) { damageValue = damageValue * player.Accessory1.AmplifyFire; }
      if (player.Accessory2 != null && player.Accessory2.AmplifyFire > 1.00f) { damageValue = damageValue * player.Accessory2.AmplifyFire; }
      if (player.Artifact != null && player.Artifact.AmplifyFire > 1.00f) { damageValue = damageValue * player.Artifact.AmplifyFire; }
    }
    if (attr == Fix.DamageSource.Ice)
    {
      if (player.IsUpIce)
      {
        Debug.Log("damageValue IsUpIce: " + player.IsUpIce.EffectValue.ToString());
        damageValue = damageValue * player.IsUpIce.EffectValue;
      }
      if (player.MainWeapon != null && player.MainWeapon.AmplifyIce > 1.00f) { damageValue = damageValue * player.MainWeapon.AmplifyIce; }
      if (player.SubWeapon != null && player.SubWeapon.AmplifyIce > 1.00f) { damageValue = damageValue * player.SubWeapon.AmplifyIce; }
      if (player.MainArmor != null && player.MainArmor.AmplifyIce > 1.00f) { damageValue = damageValue * player.MainArmor.AmplifyIce; }
      if (player.Accessory1 != null && player.Accessory1.AmplifyIce > 1.00f) { damageValue = damageValue * player.Accessory1.AmplifyIce; }
      if (player.Accessory2 != null && player.Accessory2.AmplifyIce > 1.00f) { damageValue = damageValue * player.Accessory2.AmplifyIce; }
      if (player.Artifact != null && player.Artifact.AmplifyIce > 1.00f) { damageValue = damageValue * player.Artifact.AmplifyIce; }
    }
    if (attr == Fix.DamageSource.HolyLight)
    {
      if (player.IsUpLight)
      {
        Debug.Log("damageValue IsUpLight: " + player.IsUpLight.EffectValue.ToString());
        damageValue = damageValue * player.IsUpLight.EffectValue;
      }
      if (player.MainWeapon != null && player.MainWeapon.AmplifyLight > 1.00f) { damageValue = damageValue * player.MainWeapon.AmplifyLight; }
      if (player.SubWeapon != null && player.SubWeapon.AmplifyLight > 1.00f) { damageValue = damageValue * player.SubWeapon.AmplifyLight; }
      if (player.MainArmor != null && player.MainArmor.AmplifyLight > 1.00f) { damageValue = damageValue * player.MainArmor.AmplifyLight; }
      if (player.Accessory1 != null && player.Accessory1.AmplifyLight > 1.00f) { damageValue = damageValue * player.Accessory1.AmplifyLight; }
      if (player.Accessory2 != null && player.Accessory2.AmplifyLight > 1.00f) { damageValue = damageValue * player.Accessory2.AmplifyLight; }
      if (player.Artifact != null && player.Artifact.AmplifyLight > 1.00f) { damageValue = damageValue * player.Artifact.AmplifyLight; }
    }
    if (attr == Fix.DamageSource.DarkMagic)
    {
      if (player.IsUpShadow)
      {
        Debug.Log("damageValue IsUpShadow: " + player.IsUpShadow.EffectValue.ToString());
        damageValue = damageValue * player.IsUpShadow.EffectValue;
      }
      if (player.MainWeapon != null && player.MainWeapon.AmplifyShadow > 1.00f) { damageValue = damageValue * player.MainWeapon.AmplifyShadow; }
      if (player.SubWeapon != null && player.SubWeapon.AmplifyShadow > 1.00f) { damageValue = damageValue * player.SubWeapon.AmplifyShadow; }
      if (player.MainArmor != null && player.MainArmor.AmplifyShadow > 1.00f) { damageValue = damageValue * player.MainArmor.AmplifyShadow; }
      if (player.Accessory1 != null && player.Accessory1.AmplifyShadow > 1.00f) { damageValue = damageValue * player.Accessory1.AmplifyShadow; }
      if (player.Accessory2 != null && player.Accessory2.AmplifyShadow > 1.00f) { damageValue = damageValue * player.Accessory2.AmplifyShadow; }
      if (player.Artifact != null && player.Artifact.AmplifyShadow > 1.00f) { damageValue = damageValue * player.Artifact.AmplifyShadow; }
    }
    if (attr == Fix.DamageSource.Wind)
    {
      if (player.IsUpWind)
      {
        Debug.Log("damageValue IsUpWind: " + player.IsUpWind.EffectValue.ToString());
        damageValue = damageValue * player.IsUpWind.EffectValue;
      }
      if (player.MainWeapon != null && player.MainWeapon.AmplifyWind > 1.00f) { damageValue = damageValue * player.MainWeapon.AmplifyWind; }
      if (player.SubWeapon != null && player.SubWeapon.AmplifyWind > 1.00f) { damageValue = damageValue * player.SubWeapon.AmplifyWind; }
      if (player.MainArmor != null && player.MainArmor.AmplifyWind > 1.00f) { damageValue = damageValue * player.MainArmor.AmplifyWind; }
      if (player.Accessory1 != null && player.Accessory1.AmplifyWind > 1.00f) { damageValue = damageValue * player.Accessory1.AmplifyWind; }
      if (player.Accessory2 != null && player.Accessory2.AmplifyWind > 1.00f) { damageValue = damageValue * player.Accessory2.AmplifyWind; }
      if (player.Artifact != null && player.Artifact.AmplifyWind > 1.00f) { damageValue = damageValue * player.Artifact.AmplifyWind; }
    }
    if (attr == Fix.DamageSource.Earth)
    {
      if (player.IsUpEarth)
      {
        Debug.Log("damageValue IsUpEarth: " + player.IsUpEarth.EffectValue.ToString());
        damageValue = damageValue * player.IsUpEarth.EffectValue;
      }
      if (player.MainWeapon != null && player.MainWeapon.AmplifyEarth > 1.00f) { damageValue = damageValue * player.MainWeapon.AmplifyEarth; }
      if (player.SubWeapon != null && player.SubWeapon.AmplifyEarth > 1.00f) { damageValue = damageValue * player.SubWeapon.AmplifyEarth; }
      if (player.MainArmor != null && player.MainArmor.AmplifyEarth > 1.00f) { damageValue = damageValue * player.MainArmor.AmplifyEarth; }
      if (player.Accessory1 != null && player.Accessory1.AmplifyEarth > 1.00f) { damageValue = damageValue * player.Accessory1.AmplifyEarth; }
      if (player.Accessory2 != null && player.Accessory2.AmplifyEarth > 1.00f) { damageValue = damageValue * player.Accessory2.AmplifyEarth; }
      if (player.Artifact != null && player.Artifact.AmplifyEarth > 1.00f) { damageValue = damageValue * player.Artifact.AmplifyEarth; }
    }

    if (target.objFieldPanel != null)
    {
      BuffImage[] buffList = target.objFieldPanel.GetComponentsInChildren<BuffImage>();
      for (int ii = 0; ii < buffList.Length; ii++)
      {
        // フリージング・キューブによる効果
        if (buffList[ii].BuffName == Fix.FREEZING_CUBE && attr == Fix.DamageSource.Ice)
        {
          double before_result = damageValue;
          damageValue = damageValue * buffList[ii].EffectValue;
          Debug.Log("MagicDamage ( FreezingCube ) : " + buffList[ii].EffectValue.ToString("F2") + " " + before_result.ToString("F2") + " -> " + damageValue.ToString("F2"));
        }

        // ヴォルカニック・ウェイヴによる効果
        if (buffList[ii].BuffName == Fix.VOLCANIC_BLAZE && attr == Fix.DamageSource.Fire)
        {
          double before_result = damageValue;
          damageValue = damageValue * buffList[ii].EffectValue;
          Debug.Log("MagicDamage ( VolcanicWave ) : " + buffList[ii].EffectValue.ToString("F2") + " " + before_result.ToString("F2") + " -> " + damageValue.ToString("F2"));
        }
      }
    }

    // ストーム・アーマーによる効果
    if (player.IsStormArmor)
    {
      damageValue = damageValue * player.IsStormArmor.EffectValue2;
      Debug.Log("damageValue IsStormArmor(after): " + damageValue.ToString());
    }

    // クリティカル判定
    result_critical = false;
    int rand = AP.Math.RandomInteger(100);
    int current = SecondaryLogic.CriticalRate(player);
    Debug.Log("MagicDamageLogic CriticalRate ( " + rand.ToString() + " / " + current + " ) ");
    if (player.CannotCritical == false &&
        ((critical == Fix.CriticalType.Random && rand <= current))
       )
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      result_critical = true;
      Debug.Log("MagicDamageLogic detect Critical! (Random) ( " + rand.ToString() + " / " + current + " ) " + damageValue.ToString());
      UpdateMessage("クリティカル発生！");
    }
    if (critical == Fix.CriticalType.Absolute)
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      result_critical = true;
      Debug.Log("MagicDamageLogic detect Critical! (Absolute) " + damageValue.ToString());
      UpdateMessage("クリティカル発生！");
    }

    // 属性耐性の分だけ、減衰させる。
    if (attr == Fix.DamageSource.Fire && target.MainWeapon != null && target.MainWeapon.ResistFire > 0) { damageValue *= (1.00f - target.MainWeapon.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.SubWeapon != null && target.SubWeapon.ResistFire > 0) { damageValue *= (1.00f - target.SubWeapon.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.MainArmor != null && target.MainArmor.ResistFire > 0) { damageValue *= (1.00f - target.MainArmor.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.Accessory1 != null && target.Accessory1.ResistFire > 0) { damageValue *= (1.00f - target.Accessory1.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.Accessory2 != null && target.Accessory2.ResistFire > 0) { damageValue *= (1.00f - target.Accessory2.ResistFire); }
    if (attr == Fix.DamageSource.Fire && target.Artifact != null && target.Artifact.ResistFire > 0) { damageValue *= (1.00f - target.Artifact.ResistFire); }

    if (attr == Fix.DamageSource.Ice && target.MainWeapon != null && target.MainWeapon.ResistIce > 0) { damageValue *= (1.00f - target.MainWeapon.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.SubWeapon != null && target.SubWeapon.ResistIce > 0) { damageValue *= (1.00f - target.SubWeapon.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.MainArmor != null && target.MainArmor.ResistIce > 0) { damageValue *= (1.00f - target.MainArmor.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.Accessory1 != null && target.Accessory1.ResistIce > 0) { damageValue *= (1.00f - target.Accessory1.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.Accessory2 != null && target.Accessory2.ResistIce > 0) { damageValue *= (1.00f - target.Accessory2.ResistIce); }
    if (attr == Fix.DamageSource.Ice && target.Artifact != null && target.Artifact.ResistIce > 0) { damageValue *= (1.00f - target.Artifact.ResistIce); }

    if (attr == Fix.DamageSource.HolyLight && target.MainWeapon != null && target.MainWeapon.ResistLight > 0) { damageValue *= (1.00f - target.MainWeapon.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.SubWeapon != null && target.SubWeapon.ResistLight > 0) { damageValue *= (1.00f - target.SubWeapon.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.MainArmor != null && target.MainArmor.ResistLight > 0) { damageValue *= (1.00f - target.MainArmor.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.Accessory1 != null && target.Accessory1.ResistLight > 0) { damageValue *= (1.00f - target.Accessory1.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.Accessory2 != null && target.Accessory2.ResistLight > 0) { damageValue *= (1.00f - target.Accessory2.ResistLight); }
    if (attr == Fix.DamageSource.HolyLight && target.Artifact != null && target.Artifact.ResistLight > 0) { damageValue *= (1.00f - target.Artifact.ResistLight); }

    if (attr == Fix.DamageSource.DarkMagic && target.MainWeapon != null && target.MainWeapon.ResistShadow > 0) { damageValue *= (1.00f - target.MainWeapon.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.SubWeapon != null && target.SubWeapon.ResistShadow > 0) { damageValue *= (1.00f - target.SubWeapon.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.MainArmor != null && target.MainArmor.ResistShadow > 0) { damageValue *= (1.00f - target.MainArmor.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.Accessory1 != null && target.Accessory1.ResistShadow > 0) { damageValue *= (1.00f - target.Accessory1.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.Accessory2 != null && target.Accessory2.ResistShadow > 0) { damageValue *= (1.00f - target.Accessory2.ResistShadow); }
    if (attr == Fix.DamageSource.DarkMagic && target.Artifact != null && target.Artifact.ResistShadow > 0) { damageValue *= (1.00f - target.Artifact.ResistShadow); }

    if (attr == Fix.DamageSource.Wind && target.MainWeapon != null && target.MainWeapon.ResistWind > 0) { damageValue *= (1.00f - target.MainWeapon.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.SubWeapon != null && target.SubWeapon.ResistWind > 0) { damageValue *= (1.00f - target.SubWeapon.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.MainArmor != null && target.MainArmor.ResistWind > 0) { damageValue *= (1.00f - target.MainArmor.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.Accessory1 != null && target.Accessory1.ResistWind > 0) { damageValue *= (1.00f - target.Accessory1.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.Accessory2 != null && target.Accessory2.ResistWind > 0) { damageValue *= (1.00f - target.Accessory2.ResistWind); }
    if (attr == Fix.DamageSource.Wind && target.Artifact != null && target.Artifact.ResistWind > 0) { damageValue *= (1.00f - target.Artifact.ResistWind); }

    if (attr == Fix.DamageSource.Earth && target.MainWeapon != null && target.MainWeapon.ResistEarth > 0) { damageValue *= (1.00f - target.MainWeapon.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.SubWeapon != null && target.SubWeapon.ResistEarth > 0) { damageValue *= (1.00f - target.SubWeapon.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.MainArmor != null && target.MainArmor.ResistEarth > 0) { damageValue *= (1.00f - target.MainArmor.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.Accessory1 != null && target.Accessory1.ResistEarth > 0) { damageValue *= (1.00f - target.Accessory1.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.Accessory2 != null && target.Accessory2.ResistEarth > 0) { damageValue *= (1.00f - target.Accessory2.ResistEarth); }
    if (attr == Fix.DamageSource.Earth && target.Artifact != null && target.Artifact.ResistEarth > 0) { damageValue *= (1.00f - target.Artifact.ResistEarth); }

    double debug1 = damageValue;

    // ターゲットの魔法防御を差し引く。
    double defenseValue = PrimaryLogic.MagicDefense(target);
    double debug2 = defenseValue;
    damageValue -= defenseValue;
    double debug3 = damageValue;

    Debug.Log("Magic-DamageValue: " + debug0.ToString("F2") + " -> " + debug1.ToString("F2") + " - " + debug2.ToString("F2") + " = " + debug3.ToString("F2"));

    // 防御判定
    if (target.IsDefense)
    {
      // ターゲットが防御姿勢であれば、ダメージを軽減する。ただし防御無効の場合は差し引かない。
      if (ignore_target_defense)
      {
        Debug.Log("Target is Defense, but ignore_target_defense is true, then cannot Defense");
      }
      // フレイム・ストライク効果があり、【炎】属性の場合は防御できない。
      else if (attr == Fix.DamageSource.Fire && target.IsFlameStrike != null)
      {
        Debug.Log("Target is Defense, but Fire Damage cannot be Defensed, cause FlameStrike !!");
      }
      else
      {
        damageValue = damageValue * SecondaryLogic.DefenseFactor(target);
        Debug.Log("Target is Defense mode: " + damageValue.ToString());
      }
    }

    // ダメージ量が負の値になる場合は０とみなす。
    if (damageValue <= 0) { damageValue = 0; }

    return damageValue;
  }

  private void ApplyDamage(Character player, Character target, double damageValue, bool critical, int animation_speed)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    int beforeTargetLife = target.CurrentLife;

    if (damageValue <= 0) { damageValue = 0; }

    int result = (int)damageValue;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " damage");
    UpdateMessage((player?.FullName ?? string.Empty) + " から " + target.FullName + " へ " + result.ToString() + " のダメージ");
    target.CurrentLife -= result;
    target.txtLife.text = target.CurrentLife.ToString();
    if (critical)
    {
      StartAnimation(target.objGroup.gameObject, result.ToString() + "\r\n Critial", Fix.COLOR_NORMAL, animation_speed);
    }
    else
    {
      StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL, animation_speed);
    }

    if (target.IsDeadlyDrive != null && target.CurrentLife <= 0 && beforeTargetLife > 1)
    {
      target.CurrentLife = 1;
      StartAnimation(target.objGroup.gameObject, "決死　ライフ１", Fix.COLOR_NORMAL, animation_speed);
    }
  }

  private bool AbstractHealCommand(Character player, Character target, double healValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // ヒールなので、防御姿勢で軽減はしない。
    // if (target.IsDefense) { healValue = healValue / 3.0f; }

    // ヒール量が負の値になる場合は０とみなす。
    if (healValue <= 0) { healValue = 0; }

    int result = (int)healValue;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " life heal");
    UpdateMessage((player?.FullName ?? string.Empty) + " から " + target.FullName + " へ " + result.ToString() + " ライフ回復");
    target.CurrentLife += result;
    target.txtLife.text = target.CurrentLife.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_HEAL);

    return true;
  }

  private bool AbstractGainManaPoint(Character player, Character target, double gainValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // ゲイン量が負の値になる場合は０とみなす。
    if (gainValue <= 0) { gainValue = 0; }

    int result = (int)gainValue;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " Mana gain");
    UpdateMessage((player?.FullName ?? string.Empty) + " から " + target.FullName + " へ " + result.ToString() + " ManaPoint回復");
    target.CurrentManaPoint += result;
    target.txtManaPoint.text = target.CurrentManaPoint.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_GAIN_MP);

    return true;
  }

  private bool AbstractGainSkillPoint(Character player, Character target, double gainValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // ゲイン量が負の値になる場合は０とみなす。
    if (gainValue <= 0) { gainValue = 0; }

    int result = (int)gainValue;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " skill-point gain");
    UpdateMessage((player?.FullName ?? string.Empty) + " から " + target.FullName + " へ " + result.ToString() + " SkillPoint回復");
    target.CurrentSkillPoint += result;
    target.txtSkillPoint.text = target.CurrentSkillPoint.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_GAIN_SP);

    return true;
  }
  #endregion
  #endregion
}