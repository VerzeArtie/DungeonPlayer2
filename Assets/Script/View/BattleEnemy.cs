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
  public GameObject grpLvupMaxLife;
  public Text txtLvupMaxLife;
  public GameObject objLvupMaxManaPoint;
  public Text txtLvupMaxManaPoint;
  public GameObject objLvupMaxSkillPoint;
  public Text txtLvupMaxSkillPoint;
  public GameObject objLvupRemainPoint;
  public Text txtLvupRemainPoint;
  public GameObject objLvupSoulEssence;
  public Text txtLvupSoulEssence;
  public GameObject grpLvupSpecial;
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
  public GameObject Background;
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
  public List<GameObject> EnemyArrowShadowList;
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
  public GameObject GroupNormalStack;
  public GameObject GroupAnimation;

  public GameObject GroupArchetectAnimation;
  public GameObject ParentArchetectMessage;
  public Text txtArchetectMessage_Name;
  public Text txtArchetectMessage_Command;

  // debug
  public Text debug1;

  public bool CannotRunAway = false;
  public bool LifePointBattle = false;

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

  protected float GlobalInstantValue = 0;
  protected float GlobalInstantInc = 1;

  protected bool NowAnimationMode = false;
  public List<int> AnimationProgress;
  protected const int MAX_ANIMATION_TIME = 40;
  protected const int ANIMATION_TIME_HALF = 20;
  protected const int ANIMATION_TIME_SHORT = 10;

  protected bool NowIrregularStepMode = false;
  protected Character NowIrregularStepPlayer = null;
  protected Character NowIrregularStepTarget = null;
  protected double NowIrregularStepCounter = 0;

  protected bool NowSeaStripeMode = false;
  protected Character NowSeaStripePlayer = null;
  protected Character NowSeaStripeTarget = null;
  protected double NowSeaStripeCounter = 0;

  protected bool NowUnintentionalHitMode = false;
  protected Character NowUnintentionalHitPlayer = null;
  protected Character NowUnintentionalHitTarget = null;
  protected double NowUnintentionalHitCounter = 0;

  protected bool NowGodSenseMode = false;
  protected Character NowGodSensePlayer = null;
  protected double NowGodSenseCounter = 0;

  protected bool NowSelectGlobal = false;
  protected bool NowSelectTarget = false;
  protected bool NowInstantTarget = false;
  public Character NowSelectSrcPlayer = null;
  public Button NowSelectActionSrcButton = null;
  public Button NowSelectActionCommandButton = null;
  public Button NowSelectActionDstButton = null;

  protected bool NowStackInTheCommand = false;
  protected bool NowNormalStack = false;

  protected bool NowAnimationArchetect;
  protected int AnimationArchetectProgress;

  protected int GlobalAnimationChain = 0; // アニメーション実行の際、ひとまとめで表示したい箇所についてナンバーを宣言し、同一ナンバーの場合はまとめてアニメーション実行するためのフラグ

  bool nowAnimationSandGlass = false;
  int nowAnimationSandGlassCounter = 0;
  public Image back_Sandglass;
  public Text SandGlassText;
  public Image SandGlassImage;
  protected int BattleTurnCount = 0;

  protected int AutoExit = -1;

  private float BATTLE_GAUGE_WITDH = 0;

  protected bool DetectItemDrop = false;

  private bool NowTimeStop = false;
  public GameObject back_labelBattleTurn;
  public Text labelBattleTurn;
  public Text TimeSpeedLabel;
  public Text TimeStopText;

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
    this.LifePointBattle = One.LifePointBattle;
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
    this.BattleTurnCount = 1;

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

      if (BattleType == Fix.BattleMode.Duel)
      {
        playerList.Add(One.SelectCharacter(Fix.NAME_EIN_WOLENCE)); // Duelはアイン・ウォーレンス固定
        break;
      }

      if (ii == 0) { target = One.TF.BattlePlayer1; Debug.Log("target1 is " + target); }
      if (ii == 1) { target = One.TF.BattlePlayer2; Debug.Log("target2 is " + target); }
      if (ii == 2) { target = One.TF.BattlePlayer3; Debug.Log("target3 is " + target); }
      //if (ii == 3) { target = One.TF.BattlePlayer4; Debug.Log("target4 is " + target); }

      int counter = 0;
      if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
      {
        if (One.TF.AvailableEinWolence && target == Fix.NAME_EIN_WOLENCE) { playerList.Add(One.SelectCharacter(target)); }
        counter++;
        break;
      }

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

    // Expパネルの作成
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      if (One.TF.BattlePlayer1 != String.Empty) { ConstructNodeCharaExp(One.SelectCharacter(One.TF.BattlePlayer1)); }
    }
    else
    {
      if (One.TF.BattlePlayer1 != String.Empty) { ConstructNodeCharaExp(One.SelectCharacter(One.TF.BattlePlayer1)); }
      if (One.TF.BattlePlayer2 != String.Empty) { ConstructNodeCharaExp(One.SelectCharacter(One.TF.BattlePlayer2)); }
      if (One.TF.BattlePlayer3 != String.Empty) { ConstructNodeCharaExp(One.SelectCharacter(One.TF.BattlePlayer3)); }
      if (One.TF.BattlePlayer4 != String.Empty) { ConstructNodeCharaExp(One.SelectCharacter(One.TF.BattlePlayer4)); }
      if (One.TF.BattlePlayer5 != String.Empty) { ConstructNodeCharaExp(One.SelectCharacter(One.TF.BattlePlayer5)); }
      if (One.TF.BattlePlayer6 != String.Empty) { ConstructNodeCharaExp(One.SelectCharacter(One.TF.BattlePlayer6)); }
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
      AddPlayerFromOne(playerList[ii], node, PlayerArrowList[ii], null, GroupParentActionPanelList[ii], GroupActionButton[ii], imgPlayerInstantGauge_AC[ii], imgPlayerPotentialGauge[ii], this.PanelPlayerField);

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
      playerList[ii].UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX);

      if (this.LifePointBattle)
      {
        AbstractAddBuff(playerList[ii], playerList[ii].objBuffPanel, Fix.LIFE_POINT, Fix.BUFF_LIFE_POINT, Fix.INFINITY, 3, 0, 0);
      }

      // ソレム・エンペラーズ・ソードによる効果
      if (playerList[ii].IsEquip(Fix.SOLEMN_EMPERORS_SWORD))
      {
        Debug.Log("Equip " + Fix.SOLEMN_EMPERORS_SWORD + " Setup StanceOftheBlade " + playerList[ii].FullName);
        AbstractAddBuff(playerList[ii], playerList[ii].objBuffPanel, Fix.STANCE_OF_THE_BLADE, Fix.STANCE_OF_THE_BLADE, SecondaryLogic.StanceOfTheBlade_Turn(playerList[ii]), SecondaryLogic.StanceOfTheBlade(playerList[ii]), 0, 0);
      }

      // ミスティック・ブルー・ジャベリンによる効果
      if (playerList[ii].IsEquip(Fix.MYSTIC_BLUE_JAVELIN))
      {
        Debug.Log("Equip " + Fix.MYSTIC_BLUE_JAVELIN + " Setup SpeedStep " + playerList[ii].FullName);
        AbstractAddBuff(playerList[ii], playerList[ii].objBuffPanel, Fix.SPEED_STEP, Fix.SPEED_STEP, SecondaryLogic.SpeedStep_Turn(playerList[ii]), SecondaryLogic.SpeedStep(playerList[ii]), 0, 0);
      }

      // 剛煉炎ヘル・バスタードアックスによる効果
      if (playerList[ii].IsEquip(Fix.STRONG_FIRE_HELL_BASTARDAXE))
      {
        Debug.Log("Equip " + Fix.STRONG_FIRE_HELL_BASTARDAXE + " Setup DominationField " + playerList[ii].FullName);
        AbstractAddBuff(playerList[ii], playerList[ii].objFieldPanel, Fix.DOMINATION_FIELD, Fix.DOMINATION_FIELD, SecondaryLogic.DominationField_Turn(playerList[ii]), SecondaryLogic.DominationField_Effect1(playerList[ii]), SecondaryLogic.DominationField_Effect2(playerList[ii]), 0);
      }

      // オーラ・バーン・クローによる効果
      if (playerList[ii].IsEquip(Fix.AURA_BURN_CLAW))
      {
        Debug.Log("Equip " + Fix.AURA_BURN_CLAW + " Setup LeylineSchema " + playerList[ii].FullName);
        AbstractAddBuff(playerList[ii], playerList[ii].objFieldPanel, Fix.LEYLINE_SCHEMA, Fix.LEYLINE_SCHEMA, SecondaryLogic.LeylineSchema_Turn(playerList[ii]), SecondaryLogic.LeylineSchema_Effect1(playerList[ii]), 0, 0);
      }

      // ホワイト・ファイア・クロスボウによる効果
      if (playerList[ii].IsEquip(Fix.WHITE_FIRE_CROSSBOW))
      {
        Debug.Log("Equip " + Fix.WHITE_FIRE_CROSSBOW + " Setup FlameBlade and EyeOftheIsshin " + playerList[ii].FullName);
        AbstractAddBuff(playerList[ii], playerList[ii].objBuffPanel, Fix.FLAME_BLADE, Fix.FLAME_BLADE, SecondaryLogic.FlameBlade_Turn(playerList[ii]), SecondaryLogic.FlameBlade(playerList[ii]), SecondaryLogic.FlameBlade_BaseDamage(playerList[ii]), 0);
        AbstractAddBuff(playerList[ii], playerList[ii].objBuffPanel, Fix.EYE_OF_THE_ISSHIN, Fix.EYE_OF_THE_ISSHIN, SecondaryLogic.EyeOfTheIsshin_Turn(playerList[ii]), SecondaryLogic.EyeOfTheIsshin_Effect1(playerList[ii]), 0, 0);
      }

      // エルダースタッフ・オブ・ライフブルームによる効果
      if (playerList[ii].IsEquip(Fix.ELDERSTAFF_OF_LIFEBLOOM))
      {
        Debug.Log("Equip " + Fix.ELDERSTAFF_OF_LIFEBLOOM + " Setup AngelicEcho " + playerList[ii].FullName);
        AbstractAddBuff(playerList[ii], playerList[ii].objFieldPanel, Fix.ANGELIC_ECHO, Fix.ANGELIC_ECHO, SecondaryLogic.AngelicEcho_Turn(playerList[ii]), PrimaryLogic.MagicAttack(playerList[ii], PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.AngelicEcho_Effect(playerList[ii]), 0, 0);
      }

      //if (playerList[ii].FullName == Fix.NAME_EIN_WOLENCE)
      //{
      //  PlayerList[ii].CurrentInstantPoint = Fix.MAX_INSTANT_POINT;
      //  PlayerList[ii].CurrentSkillPoint = 1;
      //  PlayerList[ii].UpdateSkillPoint();
      //  UpdatePlayerInstantGauge(PlayerList[ii]);
      //  ExecBuffStun(playerList[ii], playerList[ii], 99, 0);
      //  ExecBuffSleep(playerList[ii], playerList[ii], 99, 0);
      //  ExecBuffSilent(playerList[ii], playerList[ii], 99, 0);
      //  ExecBuffPoison(playerList[ii], playerList[ii], 99, 100);
      //  ExecBuffSlip(playerList[ii], playerList[ii], 99, 100);
      //  AbstractAddBuff(playerList[ii], playerList[ii].objBuffPanel, Fix.DEADLY_DRIVE, Fix.DEADLY_DRIVE_JP, 99, 0, 0, 0);
      //  ExecBuffPhysicalAttackDown(playerList[ii], playerList[ii], 99, 0.10f);
      //}
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

        // リガール・オルフシュタイン専用
        if (One.EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN || One.EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP || One.EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW ||
            One.EnemyList[ii].FullName == Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN || One.EnemyList[ii].FullName == Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP || One.EnemyList[ii].FullName == Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW)
        {
          Debug.Log("One.EnemyList[ii].FullName is legal-orphstein");
          node.GroupTimeSequenceField.gameObject.SetActive(true);
        }
        else
        {
          Debug.Log("One.EnemyList[ii].FullName not ...");
          node.GroupTimeSequenceField.gameObject.SetActive(false);
        }

        AddPlayerFromOne(One.EnemyList[ii], node, EnemyArrowList[ii], EnemyArrowShadowList[ii], null, null, null, null, this.PanelEnemyField);

        if (One.EnemyList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT || One.EnemyList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.ROYAL_KING_AERMI_JORZT_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.ETERNITY_KING_AERMI_JORZT || One.EnemyList[ii].FullName == Fix.ETERNITY_KING_AERMI_JORZT_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.ETERNITY_KING_AERMI_JORZT_JP_VIEW;
        }

        // 戦闘ゲージを設定
        if (this.BattleType == Fix.BattleMode.Duel)
        {
          One.EnemyList[ii].BattleGaugeArrow = 0;
        }
        else
        {
          One.EnemyList[ii].BattleGaugeArrow = (float)(AP.Math.RandomInteger(8) + (enemyBaseStart - (10.0f * ii)));
        }
        One.EnemyList[ii].UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX);

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
      for (int ii = 0; ii < One.EnemyList.Count; ii++)
      {
        NodeBattleChara node = Instantiate(node_BattleChara_EnemyBoss) as NodeBattleChara;
        node.gameObject.SetActive(true);
        node.ParentPanel.SetActive(true);
        node.transform.SetParent(GroupParentEnemy.transform);
        One.EnemyList[ii].IsEnemy = true;
        if (One.EnemyList[ii] == null) { Debug.Log("null enemylist"); }
        if (EnemyArrowList[ii] == null) { Debug.Log("enemyarrowlist null"); }

        // マナゲージを見せる
        if (One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_1 || One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_1_JP || One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_1_JP_VIEW ||
            One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_2 || One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_2_JP || One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_2_JP_VIEW ||
            One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_3 || One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_3_JP || One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_3_JP_VIEW)
        {
          node.GroupManaPoint.SetActive(true);
        }

        // リガール・オルフシュタイン専用
        if (One.EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN || One.EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP || One.EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW ||
            One.EnemyList[ii].FullName == Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN || One.EnemyList[ii].FullName == Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP || One.EnemyList[ii].FullName == Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW)
        {
          Debug.Log("One.EnemyList[ii].FullName is legal-orphstein");
          node.GroupTimeSequenceField.gameObject.SetActive(true);
        }
        else
        {
          if (node.GroupTimeSequenceField != null)
          {
            node.GroupTimeSequenceField.gameObject.SetActive(false);
          }
          Debug.Log("One.EnemyList[ii].FullName not ...");
        }
        AddPlayerFromOne(One.EnemyList[ii], node, EnemyArrowList[ii], EnemyArrowShadowList[ii], null, null, null, null, this.PanelEnemyField);

        // ボス向けに表示文字を変換
        if (One.EnemyList[ii].FullName == Fix.SCREAMING_RAFFLESIA || One.EnemyList[ii].FullName == Fix.SCREAMING_RAFFLESIA_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.SCREAMING_RAFFLESIA_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.MAGICAL_HAIL_GUN || One.EnemyList[ii].FullName == Fix.MAGICAL_HAIL_GUN_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.MAGICAL_HAIL_GUN_JP_VIEW;
        }
        if (One.EnemyList[ii].FullName == Fix.THE_YODIRIAN || One.EnemyList[ii].FullName == Fix.THE_YODIRIAN_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.THE_YODIRIAN_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.DEVIL_STAR_DEATH_FLODIETE || One.EnemyList[ii].FullName == Fix.DEVIL_STAR_DEATH_FLODIETE_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.DEVIL_STAR_DEATH_FLODIETE_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.THE_BIGHAND_OF_KRAKEN || One.EnemyList[ii].FullName == Fix.THE_BIGHAND_OF_KRAKEN_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.THE_BIGHAND_OF_KRAKEN_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE || One.EnemyList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.BRILLIANT_SEA_PRINCE_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE_1 || One.EnemyList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE_1_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.BRILLIANT_SEA_PRINCE_1_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.SHELL_THE_SWORD_KNIGHT || One.EnemyList[ii].FullName == Fix.SHELL_THE_SWORD_KNIGHT)
        {
          One.EnemyList[ii].txtName.text = Fix.SHELL_THE_SWORD_KNIGHT_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.SEA_STAR_KNIGHT_AEGIR || One.EnemyList[ii].FullName == Fix.SEA_STAR_KNIGHT_AEGIR_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.SEA_STAR_KNIGHT_AEGIR_JP_VIEW;
        }
        else if (One.EnemyList.Count > 1 && (One.EnemyList[1].FullName == Fix.SEA_STAR_KNIGHT_AMARA || One.EnemyList[1].FullName == Fix.SEA_STAR_KNIGHT_AMARA_JP))
        {
          One.EnemyList[ii].txtName.text = Fix.SEA_STAR_KNIGHT_AMARA_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN || One.EnemyList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.ORIGIN_STAR_CORAL_QUEEN_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_1 || One.EnemyList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.JELLY_EYE_BRIGHT_RED || One.EnemyList[ii].FullName == Fix.JELLY_EYE_BRIGHT_RED_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.JELLY_EYE_BRIGHT_RED_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.JELLY_EYE_DEEP_BLUE || One.EnemyList[ii].FullName == Fix.JELLY_EYE_DEEP_BLUE_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.JELLY_EYE_DEEP_BLUE_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.GROUND_VORTEX_LEVIATHAN || One.EnemyList[ii].FullName == Fix.GROUND_VORTEX_LEVIATHAN_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.GROUND_VORTEX_LEVIATHAN_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.VELGAS_THE_KING_OF_SEA_STAR || One.EnemyList[ii].FullName == Fix.VELGAS_THE_KING_OF_SEA_STAR_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.VELGAS_THE_KING_OF_SEA_STAR_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.MASCLEWARRIOR_HARDIL || One.EnemyList[ii].FullName == Fix.MASCLEWARRIOR_HARDIL_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.MASCLEWARRIOR_HARDIL_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.HUGE_MAGICIAN_ZAGAN || One.EnemyList[ii].FullName == Fix.HUGE_MAGICIAN_ZAGAN_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.HUGE_MAGICIAN_ZAGAN_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_1 || One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_1_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.LEGIN_ARZE_1_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_2 || One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_2_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.LEGIN_ARZE_2_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_3 || One.EnemyList[ii].FullName == Fix.LEGIN_ARZE_3_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.LEGIN_ARZE_3_JP_VIEW;
        }
        else if (One.EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN || One.EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP)
        {
          One.EnemyList[ii].txtName.text = Fix.EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW;
        }

        // 戦闘ゲージを設定
        One.EnemyList[ii].BattleGaugeArrow = (float)(AP.Math.RandomInteger(8) + (enemyBaseStart - (10.0f * 0)));
        One.EnemyList[ii].UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX);

        // キャラクターグループのリストに追加
        One.EnemyList[ii].Ally = Fix.Ally.Enemy;
        EnemyList.Add(One.EnemyList[ii]);
        AllList.Add(One.EnemyList[ii]);
      }
    }

    // 敵コマンドの最初の設定を行う。
    for (int ii = 0; ii < EnemyList.Count; ii++)
    {
      EnemyList[ii].ChooseCommand(GetAllyGroup(EnemyList[ii]), GetOpponentGroup(EnemyList[ii]), true);
      Debug.Log("EnemyList[ii].FullName: " + EnemyList[ii].FullName);

      if (this.LifePointBattle)
      {
        AbstractAddBuff(EnemyList[ii], EnemyList[ii].objBuffPanel, Fix.LIFE_POINT, Fix.BUFF_LIFE_POINT, Fix.INFINITY, 3, 0, 0);
      }

      // ソレム・エンペラーズ・ソードによる効果
      if (EnemyList[ii].IsEquip(Fix.SOLEMN_EMPERORS_SWORD))
      {
        Debug.Log("Equip " + Fix.SOLEMN_EMPERORS_SWORD + " Setup StanceOftheBlade " + EnemyList[ii].FullName);
        AbstractAddBuff(EnemyList[ii], EnemyList[ii].objBuffPanel, Fix.STANCE_OF_THE_BLADE, Fix.STANCE_OF_THE_BLADE, SecondaryLogic.StanceOfTheBlade_Turn(EnemyList[ii]), SecondaryLogic.StanceOfTheBlade(EnemyList[ii]), 0, 0);
      }

      // ミスティック・ブルー・ジャベリンによる効果
      if (EnemyList[ii].IsEquip(Fix.MYSTIC_BLUE_JAVELIN))
      {
        Debug.Log("Equip " + Fix.MYSTIC_BLUE_JAVELIN + " Setup SpeedStep " + EnemyList[ii].FullName);
        AbstractAddBuff(EnemyList[ii], EnemyList[ii].objBuffPanel, Fix.SPEED_STEP, Fix.SPEED_STEP, SecondaryLogic.SpeedStep_Turn(EnemyList[ii]), SecondaryLogic.SpeedStep_Turn(EnemyList[ii]), 0, 0);
      }

      // 剛煉炎ヘル・バスタードアックスによる効果
      if (EnemyList[ii].IsEquip(Fix.STRONG_FIRE_HELL_BASTARDAXE))
      {
        Debug.Log("Equip " + Fix.STRONG_FIRE_HELL_BASTARDAXE + " Setup DominationField " + EnemyList[ii].FullName);
        AbstractAddBuff(EnemyList[ii], EnemyList[ii].objFieldPanel, Fix.DOMINATION_FIELD, Fix.DOMINATION_FIELD, SecondaryLogic.DominationField_Turn(EnemyList[ii]), SecondaryLogic.DominationField_Effect1(EnemyList[ii]), SecondaryLogic.DominationField_Effect2(EnemyList[ii]), 0);
      }

      // オーラ・バーン・クローによる効果
      if (EnemyList[ii].IsEquip(Fix.AURA_BURN_CLAW))
      {
        Debug.Log("Equip " + Fix.AURA_BURN_CLAW + " Setup LeylineSchema " + EnemyList[ii].FullName);
        AbstractAddBuff(EnemyList[ii], EnemyList[ii].objFieldPanel, Fix.LEYLINE_SCHEMA, Fix.LEYLINE_SCHEMA, SecondaryLogic.LeylineSchema_Turn(EnemyList[ii]), SecondaryLogic.LeylineSchema_Effect1(EnemyList[ii]), 0, 0);
      }

      //if (EnemyList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT||
      //    EnemyList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT_JP ||
      //    EnemyList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT_JP_VIEW)
      //{
      //  ExecBuffPhysicalAttackDown(EnemyList[ii], EnemyList[ii], 99, 0.10f);
      //  ExecBuffPhysicalDefenseDown(EnemyList[ii], EnemyList[ii], 99, 0.10f);
      //  ExecBuffMagicAttackDown(EnemyList[ii], EnemyList[ii], 99, 0.10f);
      //  ExecBuffMagicDefenseDown(EnemyList[ii], EnemyList[ii], 99, 0.10f);
      //  ExecBuffBattleSpeedDown(EnemyList[ii], EnemyList[ii], 99, 0.10f);
      //  ExecBuffBattleResponseDown(EnemyList[ii], EnemyList[ii], 99, 0.10f);
      //  ExecBuffBattlePotentialDown(EnemyList[ii], EnemyList[ii], 99, 0.10f);
      //}
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

  private void AddPlayerFromOne(Character character, NodeBattleChara node, GameObject arrow, GameObject arrow2, NodeActionPanel group_parent_actionpanel, GameObject groupActionButton, Image instant_gauge_ac, Image potential_energy, BuffField field_panel)
  {
    character.objGroup = node;
    character.objArrow = arrow;
    character.objArrow.SetActive(true);
    character.objArrow2 = arrow2;
    if (character.objArrow2 != null) { character.objArrow2.SetActive(false); }
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
    character.groupTimeSequencePanel = node.GroupTimeSequenceField;

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

    character.Target2 = character;
  }

  // Update is called once per frame
  void Update()
  {
    // todo 試験的に常に再描画を行うようにする。処理落ちの場合はコメントアウトする。
    if (One.BattleEnd == Fix.GameEndType.None && CheckGameEnd())
    {
      Debug.Log("Game End 1");
      return;
    }
    LogicInvalidate();

    #region "進行停止"
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

    // 時間の跳躍
    if (this.nowAnimationSandGlass)
    {
      ExecAnimationSandGlass();
      //Debug.Log("nowAnimationSandGlass is true then return");
      return; // アニメーション表示中は停止させる。
    }

    // アニメーションを実行する。通常は、時間を進める事とする。
    if (NowAnimationMode)
    {
      ExecAnimation();
      return;
    }

    // イレギュラー・ステップを実行する。この間、時間を進めずイレギュラー・ステップのゲージ進行を行う。
    if (NowIrregularStepMode)
    {
      ExecPlayIrregularStep();
      return;
    }
    if (NowSeaStripeMode)
    {
      ExecPlaySeaStripe();
    }
    if (NowUnintentionalHitMode)
    {
      ExecPlayUnintentionalHit();
      return;
    }
    if (NowGodSenseMode)
    {
      ExecPlayGodSense();
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
          // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveBuffを介さない。
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
    #endregion

    #region "タイムストップチェック"
    bool tempTimeStop = false;
    int tempTimeStopCounter = 0;
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if ((AllList[ii].CurrentTimeStopValue > 0))
      {
        AllList[ii].CurrentTimeStopValue--;
        tempTimeStopCounter = AllList[ii].CurrentTimeStopValue;
        if (AllList[ii].CurrentTimeStopValue <= 0)
        {
          AllList[ii].RemoveTargetBuff(Fix.TIME_STOP);
          AllList[ii].RemoveTargetBuff(Fix.SPACETIME_INFLUENCE); // クラス化の考え方として良くないが、一括で解除する事にする。
        }
        else
        {
          //Debug.Log("NowTimeStop start !!!");
          this.NowTimeStop = true;
          tempTimeStop = true;
          break;
        }
      }
    }
    if (tempTimeStop == false)
    {
      this.NowTimeStop = false;
    }
    if ((this.NowTimeStop == true) && (this.Background.GetComponent<Image>().color == Color.white))
    {
      this.Background.GetComponent<Image>().color = Color.black;
      this.TimeStopText.gameObject.SetActive(true);
      this.labelBattleTurn.color = Color.white;
      this.TimeSpeedLabel.color = Color.white;
      this.lblTimerCount.color = Color.white;

      //  if (EnemyList[0].FullName != Fix.EMPEROR_LEGAL_ORPHSTEIN &&
      //      EnemyList[0].FullName != Fix.EMPEROR_LEGAL_ORPHSTEIN_JP &&
      //      EnemyList[0].FullName != Fix.EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW)
      //  {
      //    this.TimeStopText.gameObject.SetActive(true);
      //  }
      //  for (int ii = 0; ii < AllList.Count; ii++)
      //  {
      //    AllList[ii].labelName.color = Color.white;
      //    AllList[ii].ActionLabel.color = Color.white;
      //    AllList[ii].CriticalLabel.color = Color.white;
      //    AllList[ii].DamageLabel.color = Color.white;
      //    GoToTimeStopColor(AllList[ii]);
      //    AllList[ii].BuffPanel.GetComponent<Image>().color = Color.black;
      //  }
      //}
    }
    if (this.NowTimeStop)
    {
      this.TimeStopText.text = tempTimeStopCounter.ToString();
    }
    if ((this.NowTimeStop == false) && (this.Background.GetComponent<Image>().color == Color.black))
    {
      //ExecPhaseElement(MethodType.TimeStopEnd, null);
      TimeStopEnd();
    }
    #endregion

    #region "バトルが完了している場合、時間を進めない。"
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
              CharaExpList[ii].AfterExp = CharaExpList[ii].SourceCharacter.Exp;
              if (CharaExpList[ii].SourceCharacter.Exp >= CharaExpList[ii].SourceCharacter.GetNextExp())
              {
                CharaExpList[ii].AfterExp = CharaExpList[ii].SourceCharacter.GetNextExp();
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
                // 経験値獲得が０の場合、アニメーションしない。
                if (CharaExpList[ii].AfterExp == CharaExpList[ii].BeforeExp)
                {
                  continue;
                }

                // レベルアップの場合MAXで止めるアニメーションにする。
                if (CharaExpList[ii].AfterExp <= CharaExpList[ii].BeforeExp)
                {
                  //Debug.Log("CharaExpList detect Levelup");
                  float div_value = (float)((float)CharaExpList[ii].BeforeExpThreshold - (float)CharaExpList[ii].BeforeExp + CharaExpList[ii].AfterExp) * (float)(1.00f / (start_time - end_time)) * (start_time - AutoExit);
                  float current = (CharaExpList[ii].BeforeExp + div_value);
                  float dx = current / (float)(CharaExpList[ii].BeforeExpThreshold); // (float)CharaExpList[ii].SourceCharacter.GetNextExp();
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
                  float dx = current / (float)CharaExpList[ii].SourceCharacter.GetNextExp();
                  CharaExpList[ii].objCurrentExpGauge.rectTransform.localScale = new Vector3(dx, 1.0f);
                  if (dx < 1.0f)
                  {
                    CharaExpList[ii].objCurrentExpBorder.gameObject.SetActive(true);
                    CharaExpList[ii].txtPlayerExp.text = (int)current + " / " + CharaExpList[ii].SourceCharacter.GetNextExp();
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
    #endregion

    #region "ノーマルスタックを実行中。この間、時間を進めない"
    if (NowNormalStack)
    {
      ExecNormalStack();
      return;
    }
    #endregion

    #region "スタックインザコマンドを実行中。この間、時間を進めない"
    if (NowStackInTheCommand)
    {
      ExecStackInTheCommand();
      return;
    }
    #endregion

    #region "ターン砂時計(タイマーカウント更新)"
    bool detectSpacetimeInfluence = false;
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (AllList[ii].IsSpacetimeInfluence)
      {
        detectSpacetimeInfluence = true;
        break;
      }
    }

    if (detectSpacetimeInfluence == false)
    {
      this.BattleTimer += SpeedFactor();
      if (BattleTurnCount != 0)
      {
        float currentTime = ((float)Fix.BASE_TIMER_BAR_LENGTH - (float)this.BattleTimer) / ((float)Fix.BASE_TIMER_BAR_LENGTH);
        lblTimerCount.text = currentTime.ToString("0.00");
      }
      UpdateTimerSpeed();
      for (int ii = 0; ii < Fix.TIMER_ICON_NUM; ii++)
      {
        if (Fix.BASE_TIMER_DIV * Fix.BATTLE_SPEED_MAX * ii <= this.BattleTimer && this.BattleTimer < Fix.BASE_TIMER_DIV * Fix.BATTLE_SPEED_MAX * (ii + 1))
        {
          pbSandglass.sprite = this.imageSandglass[ii];
          break;
        }
      }
      LogicInvalidate();
    }
    #endregion

    #region "ターンエンドとアップキープ"
    if (BattleTimer >= Fix.BASE_TIMER_BAR_LENGTH)
    {
      UpdateTurnEnd();

      UpkeepStep();
    }
    else
    {
      UpdateAutoRecoverForBoss();
    }
    LogicInvalidate();
    #endregion

    #region "メインフェーズ"
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (this.NowTimeStop && AllList[ii].CurrentTimeStopValue <= 0 && (AllList[ii].FullName != Fix.EMPEROR_LEGAL_ORPHSTEIN &&
                                                                   AllList[ii].FullName != Fix.EMPEROR_LEGAL_ORPHSTEIN_JP &&
                                                                   AllList[ii].FullName != Fix.EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW))
      {
        // 時間は飛ばされる
        continue;
      }

      // プレイヤーゲージを進行する。
      if (AllList[ii].Dead == false)
      {
        if (AllList[ii].IsStun || AllList[ii].IsParalyze)
        {
          if (AllList[ii].IsAbsolutePerfection)
          {
            UpdatePlayerArrow(AllList[ii], 0);
          }
          else
          {
            // skip
          }
        }
        else
        {
          UpdatePlayerArrow(AllList[ii], 0);
        }
      }

      // プレイヤーのインスタントゲージを進行する。
      if (AllList[ii].Dead == false)
      {
        if (AllList[ii].IsStun || AllList[ii].IsFreeze)
        {
          if (AllList[ii].IsAbsolutePerfection)
          {
            UpdatePlayerInstantGauge(AllList[ii]);
          }
          else
          {
            // skip
          }
        }
        else
        {
          UpdatePlayerInstantGauge(AllList[ii]);
        }
      }

      // 敵プレイヤー側のターゲット変更を行う。
      // 即時対応は反応が早すぎるため、遅い反応タイミングでのみ変更可能とする。
      if (AllList[ii].IsEnemy)
      {
        RectTransform rectX = AllList[ii].objArrow.GetComponent<RectTransform>();
        if (rectX.position.x <= BATTLE_GAUGE_WITDH / 3.0f)
        {
          if (AllList[ii].Target != null && AllList[ii].Target.Dead && AllList[ii].Target.IsEnemy == false)
          {
            Character current = SearchOpponentForEnemy(AllList[ii], PlayerList);
            if (current != null)
            {
              AllList[ii].Target = current;
            }
          }
        }

        // 敵の行動コマンドを決定する。
        if (rectX.position.x >= BATTLE_GAUGE_WITDH / 3.0f && AllList[ii].Decision == false)
        {
          AllList[ii].ChooseCommand(GetAllyGroup(AllList[ii]), GetOpponentGroup(AllList[ii]), false);
        }

        // 敵プレイヤー側がインスタントが溜まった場合、スタックインザコマンドを発動する。
        // ボス戦、Duel戦が対象
        if ((this.BattleType == Fix.BattleMode.Boss || this.BattleType == Fix.BattleMode.Duel) &&
            AllList[ii].CurrentInstantPoint >= AllList[ii].MaxInstantPoint)
        {
          if (AllList[ii].FullName == Fix.MAGICAL_HAIL_GUN || AllList[ii].FullName == Fix.MAGICAL_HAIL_GUN_JP || AllList[ii].FullName == Fix.MAGICAL_HAIL_GUN_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_SUPER_RANDOM_CANNON);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii], Fix.COMMAND_SUPER_RANDOM_CANNON, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.THE_GALVADAZER || AllList[ii].FullName == Fix.THE_GALVADAZER_JP || AllList[ii].FullName == Fix.THE_GALVADAZER_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_DRILL_CYCLONE);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_DRILL_CYCLONE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.FLANSIS_OF_THE_FOREST_QUEEN || AllList[ii].FullName == Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP || AllList[ii].FullName == Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_KILL_SPINNING_LANCER);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_KILL_SPINNING_LANCER, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.LIGHT_THUNDER_LANCEBOLTS || AllList[ii].FullName == Fix.LIGHT_THUNDER_LANCEBOLTS_JP || AllList[ii].FullName == Fix.LIGHT_THUNDER_LANCEBOLTS_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_HEAVEN_THUNDER_SPEAR);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_HEAVEN_THUNDER_SPEAR, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.THE_YODIRIAN || AllList[ii].FullName == Fix.THE_YODIRIAN_JP || AllList[ii].FullName == Fix.THE_YODIRIAN_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_APOCALYPSE_SWORD);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_APOCALYPSE_SWORD, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.DEVIL_STAR_DEATH_FLODIETE || AllList[ii].FullName == Fix.DEVIL_STAR_DEATH_FLODIETE_JP || AllList[ii].FullName == Fix.DEVIL_STAR_DEATH_FLODIETE_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_DEVILSPEAR_MISTELTEN);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_DEVILSPEAR_MISTELTEN, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.THE_BIGHAND_OF_KRAKEN || AllList[ii].FullName == Fix.THE_BIGHAND_OF_KRAKEN_JP || AllList[ii].FullName == Fix.THE_BIGHAND_OF_KRAKEN_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_EIGHT_ALL);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_EIGHT_ALL, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE_1 || AllList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE_1_JP || AllList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE_1_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_GUNGNIR_LIGHT);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_GUNGNIR_LIGHT, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          // BRILLIANT_SEA_PRINCE_1と同一だが、違うキャラクターとして設定しているため、
          // 別のコードとして記載しておく。
          if (AllList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE || AllList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE_JP || AllList[ii].FullName == Fix.BRILLIANT_SEA_PRINCE_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_GUNGNIR_LIGHT);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_GUNGNIR_LIGHT, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.SHELL_THE_SWORD_KNIGHT || AllList[ii].FullName == Fix.SHELL_THE_SWORD_KNIGHT_JP || AllList[ii].FullName == Fix.SHELL_THE_SWORD_KNIGHT_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_JEWEL_BREAK);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_JEWEL_BREAK, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.SEA_STAR_KNIGHT_AEGIR || AllList[ii].FullName == Fix.SEA_STAR_KNIGHT_AEGIR_JP || AllList[ii].FullName == Fix.SEA_STAR_KNIGHT_AEGIR_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_TORPEDO_BUSTER);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_TORPEDO_BUSTER, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.SEA_STAR_KNIGHT_AMARA || AllList[ii].FullName == Fix.SEA_STAR_KNIGHT_AMARA_JP || AllList[ii].FullName == Fix.SEA_STAR_KNIGHT_AMARA_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_VORTEX_BLAST);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_VORTEX_BLAST, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_1 || AllList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP || AllList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_BYAKURAN_FROZEN_ART);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_BYAKURAN_FROZEN_ART, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          // ORIGIN_STAR_CORAL_QUEEN_1と同一だが、違うキャラクターとして設定しているため、
          // 別のコードとして記載しておく。
          if (AllList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN || AllList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_JP || AllList[ii].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_BYAKURAN_FROZEN_ART);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_BYAKURAN_FROZEN_ART, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.JELLY_EYE_BRIGHT_RED || AllList[ii].FullName == Fix.JELLY_EYE_BRIGHT_RED_JP || AllList[ii].FullName == Fix.JELLY_EYE_BRIGHT_RED_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_PENETRATION_EYE);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_PENETRATION_EYE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.JELLY_EYE_DEEP_BLUE || AllList[ii].FullName == Fix.JELLY_EYE_DEEP_BLUE_JP || AllList[ii].FullName == Fix.JELLY_EYE_DEEP_BLUE_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_HALLUCINATE_EYE);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_HALLUCINATE_EYE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.GROUND_VORTEX_LEVIATHAN || AllList[ii].FullName == Fix.GROUND_VORTEX_LEVIATHAN_JP || AllList[ii].FullName == Fix.GROUND_VORTEX_LEVIATHAN_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_HUGE_SHOCKWAVE);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_HUGE_SHOCKWAVE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.VELGAS_THE_KING_OF_SEA_STAR || AllList[ii].FullName == Fix.VELGAS_THE_KING_OF_SEA_STAR_JP || AllList[ii].FullName == Fix.VELGAS_THE_KING_OF_SEA_STAR_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_SOUMEI_SEISOU_KEN);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_SOUMEI_SEISOU_KEN, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.MASCLEWARRIOR_HARDIL || AllList[ii].FullName == Fix.MASCLEWARRIOR_HARDIL_JP || AllList[ii].FullName == Fix.MASCLEWARRIOR_HARDIL_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_BERSERKER_RUSH);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_BERSERKER_RUSH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.HUGE_MAGICIAN_ZAGAN || AllList[ii].FullName == Fix.HUGE_MAGICIAN_ZAGAN_JP || AllList[ii].FullName == Fix.HUGE_MAGICIAN_ZAGAN_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_MEGIDO_BLAZE);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_MEGIDO_BLAZE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.LEGIN_ARZE_1 || AllList[ii].FullName == Fix.LEGIN_ARZE_1_JP || AllList[ii].FullName == Fix.LEGIN_ARZE_1_JP_VIEW ||
              AllList[ii].FullName == Fix.LEGIN_ARZE_2 || AllList[ii].FullName == Fix.LEGIN_ARZE_2_JP || AllList[ii].FullName == Fix.LEGIN_ARZE_2_JP_VIEW ||
              AllList[ii].FullName == Fix.LEGIN_ARZE_3 || AllList[ii].FullName == Fix.LEGIN_ARZE_3_JP || AllList[ii].FullName == Fix.LEGIN_ARZE_3_JP_VIEW)
          {
            AllList[ii].UseInstantPoint(false, Fix.COMMAND_VOID_BEAT);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_VOID_BEAT, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN || AllList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP || AllList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW)
          {
            if (AllList[ii].Target.CurrentInstantPoint <= AllList[ii].Target.MaxInstantPoint * 0.70f || // 見合いの時は待つ。
                AllList[ii].IsPerfectProphecy || // 完全予見があれば発動する。
                AllList[ii].IsStarswordReikuu) // スターソード「零空」があれば発動する。
            {
              int rand = AP.Math.RandomInteger(2);
              if (rand == 0)
              {
                AllList[ii].UseInstantPoint(false, Fix.COMMAND_GOUGEKI);
                AllList[ii].UpdateInstantPointGauge();
                CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_GOUGEKI, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              }
              else
              {
                if ((AllList[ii].IsPerfectProphecy == false && AllList[ii].CurrentActionCommand == Fix.COMMAND_PERFECT_PROPHECY) || 
                    (AllList[ii].IsHolyWisdom == false && AllList[ii].CurrentActionCommand == Fix.COMMAND_HOLY_WISDOM) ||
                    (AllList[ii].IsEternalPresence == false && AllList[ii].CurrentActionCommand == Fix.COMMAND_ETERNAL_PRESENCE) ||
                    (AllList[ii].IsStarswordZetsuken == false && AllList[ii].CurrentActionCommand == Fix.COMMAND_STARSWORD_ZETSUKEN) ||
                    (AllList[ii].IsStarswordReikuu == false && AllList[ii].CurrentActionCommand == Fix.COMMAND_STARSWORD_REIKUU) ||
                    (AllList[ii].IsStarswordSeiei == false && AllList[ii].CurrentActionCommand == Fix.COMMAND_STARSWORD_SEIEI) ||
                    (AllList[ii].IsStarswordRyokuei == false && AllList[ii].CurrentActionCommand == Fix.COMMAND_STARSWORD_RYOKUEI) ||
                    (AllList[ii].IsStarswordFinality == false && AllList[ii].CurrentActionCommand == Fix.COMMAND_STARSWORD_FINALITY)
                    )
                {
                  AllList[ii].UseInstantPoint(false, Fix.COMMAND_GOD_SENSE);
                  AllList[ii].UpdateInstantPointGauge();
                  CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_GOD_SENSE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
                }
                else
                {
                  AllList[ii].UseInstantPoint(false, Fix.COMMAND_GOUGEKI);
                  AllList[ii].UpdateInstantPointGauge();
                  CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_GOUGEKI, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
                }
              }
              return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
            }
          }

          if (AllList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT || AllList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT_JP || AllList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT_JP_VIEW)
          {
            // 残りライフに余力があるなら、見合いせずインスタント行動を行う。
            if (AllList[ii].CurrentLife >= AllList[ii].MaxLife / 2.0f)
            {
              if (AllList[ii].CurrentSkillPoint >= ActionCommand.Cost(Fix.DOUBLE_SLASH))
              {
                AllList[ii].UseInstantPoint(false, Fix.DOUBLE_SLASH);
                AllList[ii].UpdateInstantPointGauge();
                CreateStackObject(AllList[ii], AllList[ii].Target, Fix.DOUBLE_SLASH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
                return;
              }
            }
            if (AllList[ii].Target.CurrentInstantPoint >= AllList[ii].Target.MaxInstantPoint * 0.70f)
            {
              // 見合いの時は待つ。
            }
            else if (AllList[ii].IsOneImmunity == false)
            {
              AllList[ii].UseInstantPoint(false, Fix.COMMAND_ABSOLUTE_PERFECTION);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.COMMAND_ABSOLUTE_PERFECTION, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
            }
            else if (AllList[ii].IsTheDarkIntensity == false)
            {
              AllList[ii].UseInstantPoint(false, Fix.THE_DARK_INTENSITY);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.THE_DARK_INTENSITY, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
            }
            else if (AllList[ii].CurrentSkillPoint >= ActionCommand.Cost(Fix.DOUBLE_SLASH))
            {
              AllList[ii].UseInstantPoint(false, Fix.DOUBLE_SLASH);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.DOUBLE_SLASH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return;
            }
            else if (AllList[ii].CurrentLife < AllList[ii].MaxLife)
            {
              AllList[ii].UseInstantPoint(false, Fix.FRESH_HEAL);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.FRESH_HEAL, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return;
            }
          }

          // Duel !
          if (AllList[ii].FullName == Fix.DUEL_DUMMY_SUBURI || AllList[ii].FullName == Fix.DUEL_DUMMY_SUBURI_JP)
          {
            AllList[ii].UseInstantPoint(false, Fix.FIRE_BALL);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.FIRE_BALL, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.DUEL_EGALT_SANDY || AllList[ii].FullName == Fix.DUEL_EGALT_SANDY_JP)
          {
            AllList[ii].UseInstantPoint(false, Fix.SHIELD_BASH);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.SHIELD_BASH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.DUEL_YORZEN_GORMEZ || AllList[ii].FullName == Fix.DUEL_YORZEN_GORMEZ_JP)
          {
            AllList[ii].UseInstantPoint(false, Fix.BLUE_BULLET);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.BLUE_BULLET, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.DUEL_ARDAM_VIO || AllList[ii].FullName == Fix.DUEL_ARDAM_VIO_JP)
          {
            if (AllList[ii].CurrentLife <= AllList[ii].MaxLife / 4)
            {
              AllList[ii].UseInstantPoint(false, Fix.DEADLY_DRIVE);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.DEADLY_DRIVE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            }
            else
            {
              AllList[ii].UseInstantPoint(false, Fix.WORD_OF_POWER);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.WORD_OF_POWER, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            }
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.DUEL_LENE_COLTOS || AllList[ii].FullName == Fix.DUEL_LENE_COLTOS_JP)
          {
            if (AllList[ii].Target.CurrentInstantPoint <= AllList[ii].Target.MaxInstantPoint * 0.70f) // 見合いの時は待つ。
            {
              // skip
            }
            else if (AllList[ii].CurrentSkillPoint >= ActionCommand.Cost(Fix.DOUBLE_SLASH))
            {
              AllList[ii].UseInstantPoint(false, Fix.DOUBLE_SLASH);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.DOUBLE_SLASH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
            }
          }

          if (AllList[ii].FullName == Fix.DUEL_PLAYER_1 || AllList[ii].FullName == Fix.DUEL_PLAYER_1_JP)
          {
            AllList[ii].UseInstantPoint(false, Fix.DOUBLE_SLASH);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.DOUBLE_SLASH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.DUEL_ZATKON_MEMBER_1 || AllList[ii].FullName == Fix.DUEL_ZATKON_MEMBER_1_JP)
          {
            AllList[ii].UseInstantPoint(false, Fix.BONE_CRUSH);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.BONE_CRUSH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.DUEL_ZATKON_MEMBER_2 || AllList[ii].FullName == Fix.DUEL_ZATKON_MEMBER_2_JP)
          {
            AllList[ii].UseInstantPoint(false, Fix.CURSED_EVANGILE);
            AllList[ii].UpdateInstantPointGauge();
            CreateStackObject(AllList[ii], AllList[ii].Target, Fix.CURSED_EVANGILE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
          }

          if (AllList[ii].FullName == Fix.DUEL_SELMOI_RO)
          {
            // 残りライフが少なくなったら、デッドリー・ドライブを行う。
            if (AllList[ii].CurrentLife < AllList[ii].MaxLife / 5.0f && AllList[ii].IsDeadlyDrive == false)
            {
              AllList[ii].UseInstantPoint(false, Fix.DEADLY_DRIVE);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.DEADLY_DRIVE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
            }
            // 残りライフに余力があるなら、見合いせずインスタント行動を行う。
            if (AllList[ii].CurrentLife >= AllList[ii].MaxLife / 2.0f)
            {
              AllList[ii].UseInstantPoint(false, Fix.SPEED_STEP);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.SPEED_STEP, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
            }
            if (AllList[ii].Target.CurrentInstantPoint >= AllList[ii].Target.MaxInstantPoint * 0.70f)
            {
              // 見合いの時は待つ。
            }
            else
            {
              AllList[ii].UseInstantPoint(false, Fix.SPEED_STEP);
              AllList[ii].UpdateInstantPointGauge();
              CreateStackObject(AllList[ii], AllList[ii].Target, Fix.SPEED_STEP, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
            }
          }

          if (AllList[ii].FullName == Fix.DUEL_CALMANS_OHN || AllList[ii].FullName == Fix.DUEL_CALMANS_OHN_JP)
          {
            if (AllList[ii].IsWillAwakening)
            {
              if (AllList[ii].Target.SearchFieldBuff(Fix.CIRCLE_OF_THE_IGNITE) == null && AllList[ii].CurrentManaPoint >= ActionCommand.Cost(Fix.CIRCLE_OF_THE_IGNITE))
              {
                AllList[ii].UseInstantPoint(false, Fix.CIRCLE_OF_THE_IGNITE);
                AllList[ii].UpdateInstantPointGauge();
                CreateStackObject(AllList[ii], AllList[ii].Target, Fix.CIRCLE_OF_THE_IGNITE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
                return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
              }
              else if (AllList[ii].SearchFieldBuff(Fix.SIGIL_OF_THE_FAITH) == null && AllList[ii].CurrentSkillPoint >= ActionCommand.Cost(Fix.SIGIL_OF_THE_FAITH))
              {
                AllList[ii].UseInstantPoint(false, Fix.SIGIL_OF_THE_FAITH);
                AllList[ii].UpdateInstantPointGauge();
                CreateStackObject(AllList[ii], AllList[ii].Target, Fix.SIGIL_OF_THE_FAITH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
                return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
              }
              else if (AllList[ii].CurrentManaPoint >= ActionCommand.Cost(Fix.FLAME_STRIKE))
              {
                AllList[ii].UseInstantPoint(false, Fix.FLAME_STRIKE);
                AllList[ii].UpdateInstantPointGauge();
                CreateStackObject(AllList[ii], AllList[ii].Target, Fix.FLAME_STRIKE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
                return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
              }
            }
          }

          if (AllList[ii].FullName == Fix.DUMMY_SUBURI)
          {
            if (AllList[ii].CurrentInstantPoint >= AllList[ii].MaxInstantPoint)
            {
              string command = Fix.FIRE_BALL;
              AllList[ii].UseInstantPoint(false, command);
              AllList[ii].UpdateInstantPointGauge();

              CreateStackObject(AllList[ii], PlayerList[0], command, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
            }
          }
          if (AllList[ii].FullName == Fix.DUEL_JEDA_ARUS)
          {
            if (AllList[ii].CurrentInstantPoint >= AllList[ii].MaxInstantPoint)
            {
              if (AllList[ii].CurrentSkillPoint >= SecondaryLogic.CostControl(Fix.DOUBLE_SLASH, ActionCommand.Cost(Fix.DOUBLE_SLASH), AllList[ii]))
              {
                AllList[ii].UseInstantPoint(false, Fix.DOUBLE_SLASH);
                AllList[ii].UpdateInstantPointGauge();

                CreateStackObject(AllList[ii], PlayerList[0], Fix.DOUBLE_SLASH, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
                return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
              }
            }
          }
        }
      }
      LogicInvalidate();
      // プレイヤ－ゲージがたまった場合、アクションコマンドを実行する。
      if (AllList[ii].Dead == false)
      {
        RectTransform rectX2 = AllList[ii].objArrow.GetComponent<RectTransform>();
        if (rectX2.position.x >= BATTLE_GAUGE_WITDH)
        {
          if (ActionCommand.IsTarget(AllList[ii].CurrentActionCommand) == ActionCommand.TargetType.Ally)
          {
            ExecPlayerCommand(AllList[ii], AllList[ii].Target2, string.Empty);
          }
          else
          {
            ExecPlayerCommand(AllList[ii], AllList[ii].Target, string.Empty);
          }

          UpdatePlayerArrowZero(AllList[ii]);
          BuffImage speedStep = AllList[ii].IsSpeedStep;
          if (speedStep != null)
          {
            Debug.Log("Target is speedStep, then Cumulative++");
            int beforeCumulative = speedStep.Cumulative;
            speedStep.CumulativeUp(speedStep.RemainCounter, 1);
            if (beforeCumulative != speedStep.Cumulative)
            {
              StartAnimation(AllList[ii].objGroup.gameObject, Fix.BATTLE_SPEED_UP, Fix.COLOR_NORMAL);
            }
          }

          AllList[ii].Decision = false;
          break;
        }

        if (AllList[ii].objArrow2 != null)
        {
          RectTransform rectX2_2 = null;
          rectX2_2 = AllList[ii].objArrow2.GetComponent<RectTransform>();
          if (rectX2_2.position.x >= BATTLE_GAUGE_WITDH)
          {
            if (ActionCommand.IsTarget(AllList[ii].CurrentActionCommand) == ActionCommand.TargetType.Ally)
            {
              ExecPlayerCommand(AllList[ii], AllList[ii].Target2, string.Empty);
            }
            else
            {
              ExecPlayerCommand(AllList[ii], AllList[ii].Target, string.Empty);
            }

            UpdatePlayerArrowZero2(AllList[ii]);
            // 分身の方はSpeedStepカウントの対象外でよい
            AllList[ii].Decision = false;
            break;
          }
        }
      }
    }
    LogicInvalidate();
    #endregion

    #region "全滅判定"
    if (CheckGameEnd())
    {
      Debug.Log("Game End 2");
      return;
    }
    #endregion

    #region "グローバルのインスタント値を更新する。"
    float incrementGlobal = GlobalInstantInc * SpeedFactor();
    this.GlobalInstantValue += incrementGlobal;
    if (this.GlobalInstantValue >= Fix.GLOBAL_INSTANT_MAX)
    {
      this.GlobalInstantValue = Fix.GLOBAL_INSTANT_MAX;
    }
    UpdateGlobalGauge();
    LogicInvalidate();
    #endregion
  }

  private bool CheckGameEnd()
  {
    // プレイヤー側が全滅した場合、ゲームエンドとする。
    if (CheckGroupAlive(PlayerList) == false)
    {
      One.BattleEnd = Fix.GameEndType.Fail;
      for (int ii = 0; ii < AllList.Count; ii++)
      {
        AllList[ii].CleanupBattleEnd();
      }

      if (panelGameOver.activeInHierarchy == false)
      {
        panelGameOver.SetActive(true);
      }
      return true;
    }
    // 敵側が全滅した場合、ゲームエンドとする。
    if (CheckGroupAlive(EnemyList) == false)
    {
      One.BattleEnd = Fix.GameEndType.Success;
      for (int ii = 0; ii < AllList.Count; ii++)
      {
        AllList[ii].CleanupBattleEnd();
      }

      if (panelGameEnd.activeInHierarchy == false)
      {
        int gainExp = 0;
        int gainGold = 0;
        for (int ii = 0; ii < One.EnemyList.Count; ii++)
        {
          gainExp += One.EnemyList[ii].Exp;
          gainGold += One.EnemyList[ii].Gold;
        }

        if (One.TF.BattlePlayer1 != String.Empty) { UpdateExp(One.SelectCharacter(One.TF.BattlePlayer1), gainExp); }
        if (One.TF.BattlePlayer2 != String.Empty) { UpdateExp(One.SelectCharacter(One.TF.BattlePlayer2), gainExp); }
        if (One.TF.BattlePlayer3 != String.Empty) { UpdateExp(One.SelectCharacter(One.TF.BattlePlayer3), gainExp); }
        if (One.TF.BattlePlayer4 != String.Empty) { UpdateExp(One.SelectCharacter(One.TF.BattlePlayer4), gainExp); }
        if (One.TF.BattlePlayer5 != String.Empty) { UpdateExp(One.SelectCharacter(One.TF.BattlePlayer5), gainExp); }
        if (One.TF.BattlePlayer6 != String.Empty) { UpdateExp(One.SelectCharacter(One.TF.BattlePlayer6), gainExp); }

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

          Debug.Log("curren item Rare: " + current.Rare.ToString());
          if (current.Rare == Item.Rarity.Epic)
          {
            Debug.Log("curren item Item.Rarity.Epic");
            One.PlaySoundEffect(Fix.SOUND_GET_EPIC_ITEM);
          }
          else if (current.Rare == Item.Rarity.Rare)
          {
            Debug.Log("curren item Item.Rarity.Rare");
            One.PlaySoundEffect(Fix.SOUND_GET_RARE_ITEM);
          }
          else
          {
            Debug.Log("curren item ELSE...");
          }

          bool success = One.TF.AddBackPack(current);
          if (success == false)
          {
            // アイテム保管庫へ移管する。アイテムを捨てさせるのは止める。
            One.TF.AddItemBank(current);
          }
        }
        else
        {
          this.txtItemDrop.text = "";
          this.imgItemDrop.sprite = null;
        }

        // todo ここでイベントフラグを制御してよいか、再考の余地はある。
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.SCREAMING_RAFFLESIA ||
                                       One.EnemyList[0].FullName == Fix.SCREAMING_RAFFLESIA_JP ||
                                       One.EnemyList[0].FullName == Fix.SCREAMING_RAFFLESIA_JP_VIEW)
        {
          One.TF.DefeatScreamingRafflesia = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.MAGICAL_HAIL_GUN ||
                                       One.EnemyList[0].FullName == Fix.MAGICAL_HAIL_GUN_JP ||
                                       One.EnemyList[0].FullName == Fix.MAGICAL_HAIL_GUN_JP_VIEW)
        {
          One.TF.DefeatMagicalHailGun = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.HELL_KERBEROS ||
                                       One.EnemyList[0].FullName == Fix.HELL_KERBEROS_JP ||
                                       One.EnemyList[0].FullName == Fix.HELL_KERBEROS_JP_VIEW)
        {
          One.TF.DefeatHellKerberos = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_ZATKON_MEMBER_1 ||
                                       One.EnemyList[0].FullName == Fix.DUEL_ZATKON_MEMBER_1_JP)
        {
          One.TF.DefeatZatKon_1 = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_ZATKON_MEMBER_2 ||
                                       One.EnemyList[0].FullName == Fix.DUEL_ZATKON_MEMBER_2_JP)
        {
          One.TF.DefeatZatKon_2 = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.THE_GALVADAZER ||
                                       One.EnemyList[0].FullName == Fix.THE_GALVADAZER_JP ||
                                       One.EnemyList[0].FullName == Fix.THE_GALVADAZER_JP_VIEW)
        {
          One.TF.DefeatGalvadazer = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.THE_YODIRIAN ||
                                       One.EnemyList[0].FullName == Fix.THE_YODIRIAN_JP ||
                                       One.EnemyList[0].FullName == Fix.THE_YODIRIAN_JP_VIEW)
        {
          One.TF.DefeatYodirian = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DEVIL_STAR_DEATH_FLODIETE ||
                                       One.EnemyList[0].FullName == Fix.DEVIL_STAR_DEATH_FLODIETE_JP ||
                                       One.EnemyList[0].FullName == Fix.DEVIL_STAR_DEATH_FLODIETE_JP_VIEW)
        {
          One.TF.DefeatDeathFlodiete = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.THE_BIGHAND_OF_KRAKEN ||
                                       One.EnemyList[0].FullName == Fix.THE_BIGHAND_OF_KRAKEN_JP ||
                                       One.EnemyList[0].FullName == Fix.THE_BIGHAND_OF_KRAKEN_JP_VIEW)
        {
          One.TF.DefeatBighandKraken = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.BRILLIANT_SEA_PRINCE_1 ||
                                       One.EnemyList[0].FullName == Fix.BRILLIANT_SEA_PRINCE_1_JP ||
                                       One.EnemyList[0].FullName == Fix.BRILLIANT_SEA_PRINCE_1_JP_VIEW)
        {
          One.TF.DefeatBrilliantSeaPrince = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.SHELL_THE_SWORD_KNIGHT ||
                                       One.EnemyList[0].FullName == Fix.SHELL_THE_SWORD_KNIGHT_JP ||
                                       One.EnemyList[0].FullName == Fix.SHELL_THE_SWORD_KNIGHT_JP_VIEW)
        {
          One.TF.DefeatShellSwordKnight = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.SEA_STAR_KNIGHT_AEGIR ||
                                       One.EnemyList[0].FullName == Fix.SEA_STAR_KNIGHT_AEGIR_JP ||
                                       One.EnemyList[0].FullName == Fix.SEA_STAR_KNIGHT_AEGIR_JP_VIEW)
        {
          One.TF.DefeatAegirAmara = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_1 ||
                                       One.EnemyList[0].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP ||
                                       One.EnemyList[0].FullName == Fix.ORIGIN_STAR_CORAL_QUEEN_1_JP_VIEW)
        {
          One.TF.DefeatOriginStarCoralQueen = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.FLANSIS_OF_THE_FOREST_QUEEN ||
                                       One.EnemyList[0].FullName == Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP ||
                                       One.EnemyList[0].FullName == Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP_VIEW)
        {
          One.TF.DefeatFlansisQueenOfVerdant = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.LIGHT_THUNDER_LANCEBOLTS ||
                                       One.EnemyList[0].FullName == Fix.LIGHT_THUNDER_LANCEBOLTS_JP ||
                                       One.EnemyList[0].FullName == Fix.LIGHT_THUNDER_LANCEBOLTS_JP_VIEW)
        {
          One.TF.DefeatLightThunderLancebolts = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.JELLY_EYE_BRIGHT_RED ||
                                       One.EnemyList[0].FullName == Fix.JELLY_EYE_BRIGHT_RED_JP ||
                                       One.EnemyList[0].FullName == Fix.JELLY_EYE_BRIGHT_RED_JP_VIEW)
        {
          One.TF.DefeatBlueRedEye = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.GROUND_VORTEX_LEVIATHAN ||
                                       One.EnemyList[0].FullName == Fix.GROUND_VORTEX_LEVIATHAN_JP ||
                                       One.EnemyList[0].FullName == Fix.GROUND_VORTEX_LEVIATHAN_JP_VIEW)
        {
          One.TF.DefeatLeviathan = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.VELGAS_THE_KING_OF_SEA_STAR ||
                                       One.EnemyList[0].FullName == Fix.VELGAS_THE_KING_OF_SEA_STAR_JP ||
                                       One.EnemyList[0].FullName == Fix.VELGAS_THE_KING_OF_SEA_STAR_JP_VIEW)
        {
          One.TF.DefeatKingOfVelgus = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.NAME_EONE_FULNEA)
        {
          One.TF.DefeatEoneFulnea = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.MASCLEWARRIOR_HARDIL ||
                                       One.EnemyList[0].FullName == Fix.MASCLEWARRIOR_HARDIL_JP ||
                                       One.EnemyList[0].FullName == Fix.MASCLEWARRIOR_HARDIL_JP_VIEW)
        {
          One.TF.DefeatMuscleHardil = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.HUGE_MAGICIAN_ZAGAN ||
                                       One.EnemyList[0].FullName == Fix.HUGE_MAGICIAN_ZAGAN_JP ||
                                       One.EnemyList[0].FullName == Fix.HUGE_MAGICIAN_ZAGAN_JP_VIEW)
        {
          One.TF.DefeatHugeZagan = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.LEGIN_ARZE_1 ||
                                       One.EnemyList[0].FullName == Fix.LEGIN_ARZE_1_JP ||
                                       One.EnemyList[0].FullName == Fix.LEGIN_ARZE_1_JP_VIEW)
        {
          One.TF.DefeatLeginArze = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.LEGIN_ARZE_2 ||
                                       One.EnemyList[0].FullName == Fix.LEGIN_ARZE_2_JP ||
                                       One.EnemyList[0].FullName == Fix.LEGIN_ARZE_2_JP_VIEW)
        {
          One.TF.DefeatLeginArze2 = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.LEGIN_ARZE_3 ||
                                       One.EnemyList[0].FullName == Fix.LEGIN_ARZE_3_JP ||
                                       One.EnemyList[0].FullName == Fix.LEGIN_ARZE_3_JP_VIEW)
        {
          One.TF.DefeatLeginArze3 = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN ||
                                       One.EnemyList[0].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP ||
                                       One.EnemyList[0].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW)
        {
          One.TF.DefeatLegalOrphstein = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.ROYAL_KING_AERMI_JORZT ||
                                       One.EnemyList[0].FullName == Fix.ROYAL_KING_AERMI_JORZT_JP ||
                                       One.EnemyList[0].FullName == Fix.ROYAL_KING_AERMI_JORZT_JP_VIEW)
        {
          One.TF.DefeatAermiJorzt = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.ETERNITY_KING_AERMI_JORZT ||
                                       One.EnemyList[0].FullName == Fix.ETERNITY_KING_AERMI_JORZT_JP ||
                                       One.EnemyList[0].FullName == Fix.ETERNITY_KING_AERMI_JORZT_JP_VIEW)
        {
          One.TF.DefeatAermiJorzt2 = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_DUMMY_SUBURI ||
                                       One.EnemyList[0].FullName == Fix.DUEL_DUMMY_SUBURI_JP)
        {
          One.TF.DefeatDummySuburi = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_EGALT_SANDY ||
                                       One.EnemyList[0].FullName == Fix.DUEL_EGALT_SANDY_JP)
        {
          One.TF.DefeatEgaltSandy = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_YORZEN_GORMEZ ||
                                       One.EnemyList[0].FullName == Fix.DUEL_YORZEN_GORMEZ_JP)
        {
          One.TF.DefeatYorzenGormez = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_ARDAM_VIO ||
                                       One.EnemyList[0].FullName == Fix.DUEL_ARDAM_VIO_JP)
        {
          One.TF.DefeatArdamVio = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_LENE_COLTOS ||
                                       One.EnemyList[0].FullName == Fix.DUEL_LENE_COLTOS_JP)
        {
          One.TF.DefeatLeneColtos = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_CALMANS_OHN ||
                                       One.EnemyList[0].FullName == Fix.DUEL_CALMANS_OHN_JP)
        {
          One.TF.DefeatCalmansOhn = true;
        }
        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_SHINIKIA_KAHLHANZ ||
                                       One.EnemyList[0].FullName == Fix.DUEL_SHINIKIA_KAHLHANZ_JP)
        {
          One.TF.DefeatShinikiaKahlhanz = true;
        }

        if (One.EnemyList.Count > 0 && One.EnemyList[0].FullName == Fix.DUEL_SELMOI_RO)
        {
          One.TF.DefeatSelmoiRo = true;
        }
      }
      AutoExit = Fix.BATTLEEND_AUTOEXIT;
      return true;
    }
    LogicInvalidate();
    return false;
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
    if (ActionCommand.IsTarget(command_name) == ActionCommand.TargetType.Ally)
    {
      stack.ConstructStack(player, player.Target2, command_name, stack_timer, sudden_timer);
    }
    else
    {
      stack.ConstructStack(player, target, command_name, stack_timer, sudden_timer);
    }
    stack.gameObject.SetActive(true);

    this.NowStackInTheCommand = true;
    GroupStackInTheCommand.SetActive(true);
  }

  private void CreateNormalStackObject(string command_name, StackObject stack_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + command_name + " ");
    stack_obj.transform.SetParent(GroupNormalStack.transform);
    stack_obj.name = "NormalStackPanel";
    RectTransform rect = stack_obj.GetComponent<RectTransform>();
    rect.sizeDelta = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, 0);
    rect.anchoredPosition = new Vector2(0, 0);
    rect.anchorMin = new Vector2(0, 0);
    rect.anchorMax = new Vector2(1, 1);
    Debug.Log(MethodBase.GetCurrentMethod() + " target -> " + stack_obj.Target.FullName + " ");
    stack_obj.ConstructStack(stack_obj.Player, stack_obj.Target, command_name, 0, 0);
    stack_obj.gameObject.SetActive(true);

    this.NowNormalStack = true;
    //GroupNormalStack.SetActive(true);
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
        // 最終戦闘、ライフカウンター判定
        BuffImage lifePoint = PlayerList[ii].IsLifePoint;
        if (lifePoint)
        {
          lifePoint.CumulativeDown(1);
          UpdateMessage(PlayerList[ii].FullName + "の生命力が１つ削られた！！\r\n");
          if (lifePoint.Cumulative > 0)
          {
            UpdateMessage(PlayerList[ii].GetCharacterSentence(216));
            StartAnimation(PlayerList[ii].objGroup.gameObject, Fix.EFFECT_LIFE_REGAIN, Fix.COLOR_NORMAL);
            PlayerList[ii].objBuffPanel.ResetAllBuff();
            //PlayerList[ii].ChangeLifeCountStatus(PlayerList[ii].CurrentLifeCount);
            PlayerList[ii].CurrentLife = (int)(PlayerList[ii].MaxLife);
            PlayerList[ii].UpdateLife();
          }
          else
          {
            this.PlayerList[ii].DeadPlayer();
          }
          continue;
        }

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

        if ((this.EnemyList[ii].FullName == Fix.LEGIN_ARZE_3 || this.EnemyList[ii].FullName == Fix.LEGIN_ARZE_3_JP || this.EnemyList[ii].FullName == Fix.LEGIN_ARZE_3_JP_VIEW) &&
            (this.EnemyList[ii].IsTheAbyssWall == false) &&
            (this.EnemyList[ii].DetectDeath == false))
        {
          this.EnemyList[ii].DetectDeath = true;
          detectEnemyDead = false;
          UpdateMessage(EnemyList[ii].FullName + "は死の至る刹那、深淵の防壁を作りだした！！\r\n");
          StartAnimation(EnemyList[ii].objGroup.gameObject, "深淵の防壁", Fix.COLOR_NORMAL);
          EnemyList[ii].CurrentLife = 1;
          EnemyList[ii].UpdateLife();
          AbstractAddBuff(EnemyList[ii], EnemyList[ii].objBuffPanel, Fix.THE_ABYSS_WALL, Fix.BUFF_THE_ABYSS_WALL, Fix.INFINITY, 0, 0, 0);
          continue;
        }

        // 最終戦闘、ライフカウンター判定
        BuffImage lifePoint = EnemyList[ii].IsLifePoint;
        if (lifePoint)
        {
          lifePoint.CumulativeDown(1);
          UpdateMessage(EnemyList[ii].FullName + "の生命力が１つ削られた！！\r\n");
          if (lifePoint.Cumulative > 0)
          {
            UpdateMessage(EnemyList[ii].GetCharacterSentence(216));
            StartAnimation(EnemyList[ii].objGroup.gameObject, Fix.EFFECT_LIFE_REGAIN, Fix.COLOR_NORMAL);
            EnemyList[ii].objBuffPanel.ResetAllBuff();
            //EnemyList[ii].ChangeLifeCountStatus(EnemyList[ii].CurrentLifeCount);
            EnemyList[ii].CurrentLife = (int)(PlayerList[ii].MaxLife);
            EnemyList[ii].UpdateLife();
          }
          else
          {
            this.EnemyList[ii].DeadPlayer();
          }
          continue;
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

  // 通常コマンドから呼び出されるメソッド
  private void ExecPlayerCommand(Character player, Character target, string command_name)
  {
    Debug.Log("ExecPlayerCommand(S) " + player.FullName + " " + command_name + " " + player.CurrentActionCommand);
    ExecPlayerCommand_Origin(player, target, command_name, false);
    // 宝珠「無双」による効果
    if (player.IsEquip(Fix.ARTIFACT_MUSOU))
    {
      Debug.Log("Equip " + Fix.ARTIFACT_MUSOU + " " + player.FullName + " " + player.CurrentActionCommand);
     
      if (ActionCommand.GetAttribute(player.CurrentActionCommand) == ActionCommand.Attribute.Skill)
      {
        Debug.Log("Equip " + Fix.ARTIFACT_MUSOU + " call target skill");
        int random = AP.Math.RandomInteger(100);
        Debug.Log("Equip " + Fix.ARTIFACT_MUSOU + " random " + random + " " + SecondaryLogic.ArtifactMusou_Effect(player));
        if (random <= SecondaryLogic.ArtifactMusou_Effect(player))
        {
          Debug.Log("Equip " + Fix.ARTIFACT_MUSOU + " ExecPlayerCommand " + player.CurrentActionCommand);
          ExecPlayerCommand_Origin(player, target, command_name, true);
        }
        else
        {
          Debug.Log("Equip " + Fix.ARTIFACT_MUSOU + " no action");
        }
      }
    }

    // GaleWindなら２回行動。GaleWind自体は２度掛けしない。
    if (command_name == Fix.GALE_WIND || player.CurrentActionCommand == Fix.GALE_WIND)
    {
      // skip
    }
    else if (player.IsGaleWind)
    {
      Debug.Log("ExecPlayerCommand_Origin second phase");
      ExecPlayerCommand_Origin(player, target, command_name, true);
      // こちらはGaleWind効果による２回行動の箇所なので、宝珠「無双」の効果対象にはしない。
    }
  }

  // Genesisから呼び出されるメソッド
  protected void ExecBeforeAttackPhase(Character player, bool skipStanceDouble)
  {
    Debug.Log("ExecBeforeAttackPhase(S) " + player.FullName);
    string shadowActionCommand = player.CurrentActionCommand;
    Character shadowTarget = player.Target;
    Character shadowTarget2 = player.Target2;
    Character shadowBeforeTarget = player.BeforeTarget;
    Character shadowBeforeTarget2 = player.BeforeTarget2;
    string shadowBeforeActionCommand = player.BeforeActionCommand;

    player.Target = player.BeforeTarget;
    player.Target2 = player.BeforeTarget2;
    player.CurrentActionCommand = player.BeforeActionCommand;

    Character target = null;
    if (ActionCommand.IsTarget(player.BeforeActionCommand) == ActionCommand.TargetType.Ally)
    {
      target = player.Target2;
    }
    else if (ActionCommand.IsTarget(player.BeforeActionCommand) == ActionCommand.TargetType.Enemy)
    {
      target = player.Target;
    }
    else // 色々考えられるが、まずTargetにしておく
    {
      target = player.Target;
    }

    Debug.Log("ExecBeforeAttackPhase -> ExecPlayerCommand_Origin");
    ExecPlayerCommand_Origin(player, target, player.CurrentActionCommand, true);

    player.CurrentActionCommand = shadowActionCommand;
    player.Target = shadowTarget;
    player.Target2 = shadowTarget2;
    player.BeforeTarget = shadowBeforeTarget;
    player.BeforeTarget2 = shadowBeforeTarget2;
    player.BeforeActionCommand = shadowBeforeActionCommand;
  }

  /// <summary>
  /// プレイヤーコマンドを実行します。
  /// </summary>
  private void ExecPlayerCommand_Origin(Character player, Character target, string command_name, bool without_cost)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + player?.FullName + " " + command_name);

    if (player == null)
    {
      Debug.Log("Player is null, then no action.");
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      return;
    }

    // コマンド名指定が無い場合は、プレイヤーが現在選択しているアクションコマンドを実行する。
    if (command_name == string.Empty)
    {
      command_name = player.CurrentActionCommand;
    }

    // 行動の成功・失敗を問わず、アクションコマンド自体は記憶する。
    if (command_name == Fix.GENESIS ||
        command_name == Fix.STANCE_OF_DOUBLE)
    {
      // Genesis、StanceOfDouble自体が行動の場合、それは記憶しない。
    }
    else
    {
      player.BeforeActionCommand = command_name;
      player.BeforeTarget = player.Target;
      player.BeforeTarget2 = player.Target2;
    }

    if (command_name == string.Empty)
    {
      Debug.Log("command_name is empty, then no action.");
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      return;
    }

    // Sleepによる効果判定
    if (player.IsSleep)
    {
      if (command_name == Fix.CIRCLE_OF_SERENITY)
      {
        // サークル・オブ・セレニティの場合は対象外
      }
      else
      {
        command_name = Fix.STAY;
        StartAnimation(player.objGroup.gameObject, Fix.BATTLE_SLEEP_MISS, Fix.COLOR_WARNING);
        // return; // 睡眠は行動失敗ではないので、ここは通過させる。
      }
    }

    // ソーサリータイミングのチェック判定
    if (ActionCommand.GetTiming(command_name) == ActionCommand.TimingType.Sorcery &&
        without_cost == false)
    {
      if (player.CurrentInstantPoint < player.MaxInstantPoint)
      {
        Debug.Log("Timing Sorcery and not enough CurrentInstantPoint, then no action.");
        StartAnimation(player.objGroup.gameObject, Fix.BATTLE_SORCERY_FAIL, Fix.COLOR_WARNING);
        return;
      }
      else
      {
        // ソーサリータイミング実行によるインスタント消費はプレイヤー意志によるものであるため、EverflowMindなどの効果の対象とする。
        player.UseInstantPoint(false, command_name);
      }
    }

    // アブソリュート・ゼロによる効果判定
    if (player.IsAbsoluteZero)
    {
      Debug.Log("detect player.IsAbsoluteZero");
      if (ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Skill ||
          ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Magic ||
          command_name == Fix.DEFENSE ||
          command_name == Fix.NORMAL_ATTACK ||
          command_name == Fix.NORMAL_ATTACK_JP ||
          command_name == Fix.MAGIC_ATTACK)
      {
        StartAnimation(player.objGroup.gameObject, Fix.BUFF_CANNOT_MOVE_JP, Fix.COLOR_WARNING);
        return;
      }
      else
      {
        Debug.Log("detect player.IsAbsoluteZero but through... " + command_name);
      }
    }

    // Dizzyによる効果判定
    if (player.IsDizzy)
    {
      if (player.IsAbsolutePerfection)
      {
        // skip
      }
      else if (command_name == Fix.ABSOLUTE_PERFECTION || command_name == Fix.COMMAND_ABSOLUTE_PERFECTION)
      {
        // エルミ・ジョルジュのアブソリュート・パーフェクションは失敗しない
        // skip
      }
      else
      {
        double random_seed = (double)((double)AP.Math.RandomInteger(100)) / 100.0f;
        if (player.IsDizzy.EffectValue > random_seed)
        {
          Debug.Log("Player is Dizzy, then no action.");
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_DIZZY_MISS, Fix.COLOR_NORMAL);
          return;
        }
      }
    }

    // ターゲットの整合性判定
    if (ActionCommand.IsTarget(command_name) == ActionCommand.TargetType.Enemy &&　target == null)
    {
      Debug.Log("Target is null, then no action.");
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      return;
    }
    if (target != null && target.Dead && command_name != Fix.RESURRECTION)
    {
      if (ActionCommand.IsTarget(command_name) == ActionCommand.TargetType.Ally || ActionCommand.IsTarget(command_name) == ActionCommand.TargetType.Enemy)
      {
        Debug.Log("Target is dead, then no action.");
        StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
        return;
      }
      else
      {
        Debug.Log("Target is dead, But ignore it. IsTarget is " + ActionCommand.IsTarget(command_name).ToString());
      }
    }

    // Bindによる効果判定
    if (player.IsBind && ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Skill)
    {
      // サークル・オブ・セレニティなら、チェック対象外。
      if (command_name == Fix.CIRCLE_OF_SERENITY)
      {
        // skip
      }
      // アブソリュート・パーフェクションなら、チェック対象外。
      else if (player.IsAbsolutePerfection)
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
      // アブソリュート・パーフェクションなら、チェック対象外。
      if (player.IsAbsolutePerfection)
      {
        // skip
      }
      else
      {
        StartAnimation(player.objGroup.gameObject, Fix.BATTLE_SILENT, Fix.COLOR_NORMAL);
        return;
      }
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
    // 消費コストスキップの場合
    else if (without_cost)
    {
      Debug.Log("without_cost is true, then no spend Mana/Skill point.");
      // 何もしない
    }
    else
    {
      Debug.Log("cost check.");
      if (ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Magic)
      {
        int manaCost = SecondaryLogic.CostControl(command_name, ActionCommand.Cost(command_name), player);
        if (player.IsWaterPresence)
        {
          manaCost = (int)((double)manaCost * SecondaryLogic.WaterPresence_Effect2(player));
        }

        if (player.CurrentManaPoint < manaCost)
        {
          Debug.Log("NO Mana-Point: [" + command_name + "] " + player.CurrentManaPoint + " < " + manaCost);
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MANAPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }

        player.CurrentManaPoint -= manaCost;
      }
      else if (ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Skill)
      {
        if (player.CurrentSkillPoint < SecondaryLogic.CostControl(command_name, ActionCommand.Cost(command_name), player))
        {
          Debug.Log("NO Skill-Point: [" + command_name + "] " + player.CurrentSkillPoint + " < " + SecondaryLogic.CostControl(command_name, ActionCommand.Cost(command_name), player));
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_SKILLPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        player.CurrentSkillPoint -= SecondaryLogic.CostControl(command_name, ActionCommand.Cost(command_name), player);
      }
    }
    
    // ポテンシャル・ゲージ加算
    if (player.Ally == Fix.Ally.Ally)
    {
      if (command_name == Fix.STAY || command_name == Fix.DEFENSE)
      {
        // 待機と防御はポテンシャル・ゲージへ加算しない。通常攻撃は加算するので、カテゴリタイプ通常ではなく個別で記載。
      }
      else if (ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Archetype)
      {
        // 元核はポテンシャル・ゲージへ加算しない。
      }
      else
      {
        One.TF.PotentialEnergy += player.GetPotentialEnergy();
      }
    }

    // ブラッド・サインによる効果
    if (player.IsBloodSign && (command_name != Fix.STAY && command_name != Fix.DEFENSE) && player.SearchFieldBuff(Fix.SHINING_HEAL) == null)
    {
      if (player.IsAbsolutePerfection)
      {
        // skip
      }
      else
      {
        ExecSlipDamage(player, player.IsBloodSign.EffectValue);
      }
    }

    // スリップによる効果
    if (player.IsSlip && (command_name != Fix.STAY && command_name != Fix.DEFENSE) && player.SearchFieldBuff(Fix.SHINING_HEAL) == null)
    {
      if (player.IsAbsolutePerfection)
      {
        // skip
      }
      else
      {
        ExecSlipDamage(player, player.IsSlip.EffectValue);
      }
    }

    // ペネトレーション・アローの効果判定
    if (player.IsPenetrationArrow && (command_name != Fix.STAY && command_name != Fix.DEFENSE) && player.SearchFieldBuff(Fix.SHINING_HEAL) == null)
    {
      ExecSlipDamage(player, player.IsPenetrationArrow.EffectValue);
    }

    Fix.CriticalType critical = Fix.CriticalType.Random;

    // 集中と断絶によるクリティカル判定
    BuffImage syutyuDanzetsu = player.IsSyutyuDanzetsu;
    if (ActionCommand.IsDamage(command_name) && syutyuDanzetsu)
    {
      Debug.Log("Detect IsSyutyuDanzetsu, then Absolute Critical.");
      critical = Fix.CriticalType.Absolute;
      player.NowExecSyutyuDanzetsu = true;
    }

    // サークル・オブ・イグナイトによる効果
    BuffImage field = player.SearchFieldBuff(Fix.CIRCLE_OF_THE_IGNITE);
    if (field)
    {
      if (ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Magic ||
          ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Skill ||
          ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.MonsterAction ||
          command_name == Fix.NORMAL_ATTACK ||
          command_name == Fix.MAGIC_ATTACK)
      {
        ExecElementalDamage(player, Fix.DamageSource.Fire, field.EffectValue);
      }
    }

    // Fearによる効果判定
    BuffImage fear = player.IsFear;
    if (fear)
    {
      if (player.IsAbsolutePerfection)
      {
        // skip
      }
      else
      {
        ExecBuffStun(player, player, SecondaryLogic.StunFromFear(player), 0);
        return;
      }
    }

    this.GlobalAnimationChain++; // コマンド実行をグローバルアニメーションチェインの対象とするが、これが最適かどうかは分からない。
    #region "コマンド実行"
    List<Character> target_list = null;
    Character currentTarget = null;
    int rand = 0;
    bool success = false;
    Debug.Log("Player: " + player.FullName + " Command: " + command_name);

    // レインボー・ムーン・コンパスによる効果
    if (player.IsEquip(Fix.RAINBOW_MOON_COMPASS))
    {
      double effectValue = SecondaryLogic.RainbowMoonCompass_Effect(player);
      int turn = SecondaryLogic.RainbowMoonCompass_Turn(player);
      int random = AP.Math.RandomInteger(6);
      if (random == 0)
      {
        Debug.Log("Equip " + Fix.RAINBOW_MOON_COMPASS + " PhysicalAttackUp " + effectValue.ToString());
        if (command_name != Fix.DEFENSE && command_name != Fix.STAY)
        {
          ExecBuffPhysicalAttackUp(player, player, turn, effectValue);
        }
      }
      else if (random == 1)
      {
        Debug.Log("Equip " + Fix.RAINBOW_MOON_COMPASS + " PhysicalDefenseUp " + effectValue.ToString());
        if (command_name != Fix.DEFENSE && command_name != Fix.STAY)
        {
          ExecBuffPhysicalDefenseUp(player, player, turn, effectValue);
        }
      }
      else if (random == 2)
      {
        Debug.Log("Equip " + Fix.RAINBOW_MOON_COMPASS + " MagicAttackUp " + effectValue.ToString());
        if (command_name != Fix.DEFENSE && command_name != Fix.STAY)
        {
          ExecBuffMagicAttackUp(player, player, turn, effectValue);
        }
      }
      else if (random == 3)
      {
        Debug.Log("Equip " + Fix.RAINBOW_MOON_COMPASS + " MagicDefenseUp " + effectValue.ToString());
        if (command_name != Fix.DEFENSE && command_name != Fix.STAY)
        {
          ExecBuffMagicDefenseUp(player, player, turn, effectValue);
        }
      }
      else if (random == 4)
      {
        Debug.Log("Equip " + Fix.RAINBOW_MOON_COMPASS + " BattleSpeedUp " + effectValue.ToString());
        if (command_name != Fix.DEFENSE && command_name != Fix.STAY)
        {
          ExecBuffBattleSpeedUp(player, player, turn, effectValue);
        }
      }
      else if (random == 5)
      {
        Debug.Log("Equip " + Fix.RAINBOW_MOON_COMPASS + " BattleResponseUp " + effectValue.ToString());
        if (command_name != Fix.DEFENSE && command_name != Fix.STAY)
        {
          ExecBuffBattleResponseUp(player, player, turn, effectValue);
        }
      }
    }

    // 神剣  フェルトゥーシュによる効果
    if (player.IsEquip(Fix.LEGENDARY_FELTUS))
    {
      Debug.Log("Equip " + Fix.LEGENDARY_FELTUS + " command: " + command_name);
      if (command_name != Fix.DEFENSE && command_name != Fix.STAY)
      {
        Debug.Log("Equip " + Fix.LEGENDARY_FELTUS + " Buff God-Will ");
        AbstractAddBuff(player, player.objBuffPanel, Fix.BUFF_GOD_WILL, Fix.BUFF_GOD_WILL_JP, Fix.INFINITY, 1, 0, 0);
      }
    }

    switch (command_name)
    {
      #region "一般"
      case Fix.NORMAL_ATTACK:
        if (player.IsEnemy)
        {
          One.PlaySoundEffect(Fix.SOUND_ENEMY_ATTACK1);
        }
        else
        {
          One.PlaySoundEffect(Fix.SOUND_SWORD_SLASH1);
        }
        ExecNormalAttack(player, target, SecondaryLogic.NormalAttack(player), Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        break;

      case Fix.MAGIC_ATTACK:
        if (player.IsEnemy)
        {
          One.PlaySoundEffect(Fix.SOUND_ENEMY_ATTACK1);
        }
        else
        {
          One.PlaySoundEffect(Fix.SOUND_MAGIC_ATTACK);
        }
        ExecMagicAttack(player, target, SecondaryLogic.MagicAttack(player), Fix.DamageSource.Colorless, Fix.IgnoreType.None, critical);
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
        ExecStanceOfTheBlade(player, target, critical);
        break;

      case Fix.SPEED_STEP:
        ExecSpeedStep(player, target, critical);
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
        ExecCircleOfTheDespair(player, target, target.objFieldPanel);
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
      #region "Delve VI"
      case Fix.CIRCLE_OF_THE_IGNITE:
        ExecCircleOfTheIgnite(player, target, target.objFieldPanel);
        break;

      case Fix.WATER_PRESENCE:
        ExecWaterPresence(player, target);
        break;

      case Fix.VALKYRIE_BLADE:
        ExecValkyrieBlade(player, target);
        break;

      case Fix.THE_DARK_INTENSITY:
        ExecTheDarkIntensity(player, target);
        break;

      case Fix.FUTURE_VISION:
        ExecFutureVision(player);
        break;

      case Fix.DETACHMENT_FAULT:
        ExecDetachmentFault(player, target, player.objFieldPanel, target.objFieldPanel);
        break;

      case Fix.STANCE_OF_THE_IAI:
        ExecStanceoftheIai(player);
        break;

      case Fix.ONE_IMMUNITY:
        ExecOneImmunity(player);
        break;

      case Fix.STANCE_OF_MUIN:
        ExecStanceofMuin(player);
        break;

      case Fix.ETERNAL_CONCENTRATION:
        ExecEternalConcentration(player);
        break;

      case Fix.SIGIL_OF_THE_FAITH:
        ExecSigiloftheFaith(player, target, player.objFieldPanel);
        break;

      case Fix.ZERO_IMMUNITY:
        ExecZeroImmunity(player, GroupStackInTheCommand.GetComponentsInChildren<StackObject>());
        break;
      #endregion
      #region "Delve VII"
      case Fix.LAVA_ANNIHILATION:
        target_list = GetOpponentGroup(player);
        ExecLavaAnnihilation(player, target_list, player.objFieldPanel, critical);
        break;

      case Fix.ABSOLUTE_ZERO:
        ExecAbsoluteZero(player, target);
        break;

      case Fix.RESURRECTION:
        ExecResurrection(player, target);
        break;

      case Fix.DEATH_SCYTHE:
        ExecDeathScythe(player, target, target.objFieldPanel);
        break;

      case Fix.GENESIS:
        ExecGenesis(player);
        break;

      case Fix.TIME_STOP:
        ExecTimeStop(player);
        break;

      case Fix.KINETIC_SMASH:
        ExecKineticSmash(player, target, critical);
        break;

      case Fix.CATASTROPHE:
        ExecCatastrophe(player, target, critical);
        break;

      case Fix.CARNAGE_RUSH:
        ExecCarnageRush(player, target, critical);
        break;

      case Fix.PIERCING_ARROW:
        ExecPiercingArrow(player, target, critical);
        break;

      case Fix.STANCE_OF_THE_KOKOROE:
        ExecStanceoftheKokoroe(player);
        break;

      case Fix.TRANSCENDENCE_REACHED:
        ExecTranscendenceReached(player, target);
        break;
      #endregion

      #region "Other"
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
        ExecEinShutyuDanzetsu(player, player);
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
        ExecUseRedPotion(player, player, command_name);
        break;

      case Fix.SMALL_BLUE_POTION:
      case Fix.NORMAL_BLUE_POTION:
      case Fix.LARGE_BLUE_POTION:
      case Fix.HUGE_BLUE_POTION:
      case Fix.HQ_BLUE_POTION:
      case Fix.THQ_BLUE_POTION:
      case Fix.PERFECT_BLUE_POTION:
        ExecUseBluePotion(player, player, command_name);
        break;

      case Fix.SMALL_GREEN_POTION:
      case Fix.NORMAL_GREEN_POTION:
      case Fix.LARGE_GREEN_POTION:
      case Fix.HUGE_GREEN_POTION:
      case Fix.HQ_GREEN_POTION:
      case Fix.THQ_GREEN_POTION:
      case Fix.PERFECT_GREEN_POTION:
        ExecUseGreenPotion(player, player, command_name);
        break;

      case Fix.PURE_CLEAN_WATER:
        ExecPureCleanWater(player, player);
        break;
      case Fix.PURE_SINSEISUI:
        ExecSinseisui(player, player);
        break;
      case Fix.PURE_VITALIRY_WATER:
        ExecVitalityWater(player, player);
        break;
      #endregion

      #region "モンスターアクション"
      // 以下、モンスターアクションはmagic numberでよい
      case Fix.COMMAND_HIKKAKI:
        ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_GREEN_NENEKI:
        ExecBuffPoison(player, target, 2, 7);
        break;

      case Fix.COMMAND_KANAKIRI:
        ExecBuffDizzy(player, target, 2, 0.30f);
        break;

      case Fix.COMMAND_WILD_CLAW:
        ExecNormalAttack(player, target, 1.35f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_KAMITSUKI:
        ExecNormalAttack(player, target, 1.40f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_TREE_SONG:
        success = ExecMagicAttack(player, target, 0.8f, Fix.DamageSource.Colorless, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSleep(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_SUN_FIRE:
        ExecMagicAttack(player, target, 1.35f, Fix.DamageSource.Fire, Fix.IgnoreType.None, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_TOSSHIN:
        success = ExecNormalAttack(player, target, 1.10f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_FEATHER_WING:
        success = ExecMagicAttack(player, target, 0.5f, Fix.DamageSource.Colorless, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSleep(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_DASH_KERI:
        success = ExecNormalAttack(player, target, 1.1f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffDizzy(player, target, 1, 0.30f);
        }
        break;

      case Fix.COMMAND_SUITSUKU_TSUTA:
        success = ExecNormalAttack(player, target, 0.5f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSlow(player, target, 2, 0.5f);
        }
        break;

      case Fix.COMMAND_SPIDER_NET:
        success = ExecNormalAttack(player, target, 0.5f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
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
          ExecNormalAttack(player, list[AP.Math.RandomInteger(list.Count)], 0.85f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_FIRE_EMISSION:
        ExecMagicAttack(player, target, 1.2f, Fix.DamageSource.Fire, Fix.IgnoreType.None, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_SUPER_TOSSHIN:
        success = ExecNormalAttack(player, target, 1.5f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
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
          ExecMagicAttack(player, list[AP.Math.RandomInteger(list.Count)], 0.5, Fix.DamageSource.Fire, Fix.IgnoreType.None, Fix.CriticalType.None, 25);
        }
        break;

      case Fix.COMMAND_BLAZE_DANCE:
        BuffUpFire(player, player, 5, 1.20f);
        break;

      case Fix.COMMAND_DRILL_CYCLONE:
        success = ExecNormalAttack(player, target, 1.50f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_RUMBLE_MACHINEGUN:
        for (int jj = 0; jj < 5; jj++)
        {
          rand = AP.Math.RandomInteger(PlayerList.Count);
          ExecNormalAttack(player, PlayerList[rand], 1.0f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Random);
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
        success = ExecNormalAttack(player, target, 0.80f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_SHADOW_SPEAR:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSilent(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_MIDARE_GIRI:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecNormalAttack(player, target_list[jj], 0.9f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
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
          ExecBuffMagicDefenseUp(player, target_list[jj], 5, 0.25f);
        }
        break;

      case Fix.COMMAND_HAND_CANNON:
        success = ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffDizzy(player, target, 2, 0.30f);
        }
        break;

      case Fix.COMMAND_SAIMIN_DANCE:
        ExecBuffSleep(player, target, 2, 0);
        break;

      case Fix.COMMAND_POISON_NEEDLE:
        success = ExecNormalAttack(player, target, 1.10f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffPoison(player, target, 3, 33);
        }
        break;

      case Fix.COMMAND_CHARGE_LANCE:
        ExecNormalAttack(player, target, 1.0f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Absolute);
        break;

      case Fix.COMMAND_SPIKE_SHOT:
        success = ExecNormalAttack(player, target, 1.4f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_JUBAKU_ON:
        success = ExecMagicAttack(player, target, 0.9f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffPhysicalDefenseDown(player, target, 5, 0.75f);
        }
        break;

      case Fix.COMMAND_ZINARI:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecNormalAttack(player, target_list[jj], 0.7f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_BOUHATSU:
        ExecNormalAttack(player, player, 2.0f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        ExecNormalAttack(player, target, 2.0f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        break;

      case Fix.COMMAND_THUNDER_CLOUD:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 0.8f, Fix.DamageSource.Wind, Fix.IgnoreType.None, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_SURUDOI_HIKKAKI:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          success = ExecNormalAttack(player, target_list[jj], 0.8f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
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
        success = ExecNormalAttack(player, target, 0.8f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSlip(player, target, 3, 25);
        }
        break;

      case Fix.COMMAND_BOLT_FRAME:
        success = ExecMagicAttack(player, target, 1.2f, Fix.DamageSource.Fire, Fix.IgnoreType.None, Fix.CriticalType.None);
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
          ExecMagicAttack(player, target_list[jj], 2.0f, Fix.DamageSource.Fire, Fix.IgnoreType.None, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_STONE_RAIN:
        for (int jj = 0; jj < 3; jj++)
        {
          rand = AP.Math.RandomInteger(PlayerList.Count);
          ExecMagicAttack(player, PlayerList[rand], 0.9f, Fix.DamageSource.Earth, Fix.IgnoreType.None, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_TARGETTING_SHOT:
        success = ExecNormalAttack(player, target, 1.0f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffMagicDefenseDown(player, target, 3, 0.75f);
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
          ExecNormalAttack(player, target, 0.5f + (0.5f * rand), Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
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
          ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
        }
        // 相手に魔法攻撃が当たったかどうかに関係なく、自分自身へのBUFFは適用される。
        ExecBuffMagicAttackUp(player, player, Fix.INFINITY, 0.10f);
        break;

      case Fix.COMMAND_SUPER_RANDOM_CANNON:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < 4; jj++)
        {
          double additional = AP.Math.RandomReal() / 2.0f;
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.8f + additional, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_ELECTRO_RAILGUN:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Fire, Fix.IgnoreType.None, Fix.CriticalType.None);
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
        AbstractAddBuff(target, PanelPlayerField, Fix.BUFF_LIGHTNING_OUTBURST, Fix.COMMAND_LIGHTNING_OUTBURST, Fix.INFINITY, 10, 0, 0);
        break;

      case Fix.COMMAND_WILD_STORM:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.Wind, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_YOUKAIEKI:
        success = ExecMagicAttack(player, target, 0.60f, Fix.DamageSource.Earth, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffBattleSpeedDown(player, target, 2, 0.70f);
          ExecBuffBattleResponseDown(player, target, 2, 0.70f);
        }
        break;

      case Fix.COMMAND_POISON_TONGUE:
        ExecNormalAttack(player, target, 0.80f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        ExecBuffPoison(player, target, 3, 70);
        break;

      case Fix.COMMAND_CONSTRICT:
        success = ExecNormalAttack(player, target, 0.7f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
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
        success = ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_WINDFLARE:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Wind, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSlow(player, target, 2, 0.5f);
        }
        break;

      case Fix.COMMAND_EARTHBOLT:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Earth, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffBind(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_SILENT_SHOT:
        success = ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffFear(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_PHANTOM_SONG:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
          ExecBuffSilent(player, target_list[jj], 1, 0);
        }
        break;

      case Fix.COMMAND_ENRAGE:
        ExecBuffPhysicalAttackUp(player, player, 3, 0.30f);
        break;

      case Fix.COMMAND_SPLASH_HARMONY:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Wind, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffParalyze(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_RANBOU_CHARGE:
        success = ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffPhysicalDefenseDown(player, target, 5, 0.70f);
        }
        break;

      case Fix.COMMAND_BEAST_STRIKE:
        success = ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffSlip(player, target, 3, 50);
        }
        break;

      case Fix.COMMAND_KONSHIN_TOKKAN:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.None, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_HUHAI_SINKOU:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.None, Fix.IgnoreType.None, Fix.CriticalType.None);
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
        success = ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecNormalAttack(player, target, 0.30f, Fix.DamageSource.Fire, Fix.IgnoreType.None, Fix.CriticalType.None);
        }
        break;

      case Fix.COMMAND_SHADOW_MIST:
        target_list = GetOpponentGroup(player);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          bool hit = ExecMagicAttack(player, target_list[jj], 0.80, Fix.DamageSource.None, Fix.IgnoreType.None, critical);
          if (hit)
          {
            ExecBuffDizzy(player, target_list[jj], 2, 0.30f);
            ExecBuffSlow(player, target_list[jj], 1, 0.50f);
          }
        }
        break;

      case Fix.COMMAND_ROCK_THROW:
        success = ExecNormalAttack(player, target, 1.40f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffStun(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_YOUEN_KISS:
        ExecBuffPoison(player, target, 3, 50);
        break;

      case Fix.COMMAND_POISON_SPORE:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.None, Fix.IgnoreType.None, Fix.CriticalType.None);
        if (success)
        {
          ExecBuffPoison(player, target, 3, 100);
        }
        break;

      case Fix.COMMAND_GROUND_RUMBLE:
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          ExecNormalAttack(player, target, 0.70f, Fix.DamageSource.Fire, Fix.IgnoreType.None, Fix.CriticalType.None);
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
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          bool hit = ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
          if (hit)
          {
            ExecBuffPhysicalDefenseDown(player, target_list[ii], 5, 0.70f);
          }
        }
        break;

      case Fix.COMMAND_RENSOU_TOSSHIN:
        for (int jj = 0; jj < 3; jj++)
        {
          // ランダムで対象を選んで当てる
          List<Character> list = GetOpponentGroupAlive(player);
          if (list.Count <= 0) { return; }
          ExecNormalAttack(player, list[AP.Math.RandomInteger(list.Count)], 0.90f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_VERDANT_VOICE:
        ExecLifeGain(player, player, player.MaxLife / 20);
        AbstractAddBuff(player, player.objFieldPanel, Fix.BUFF_VERDANT_VOICE, Fix.BUFF_VERDANT_VOICE, Fix.INFINITY, 0, 0, 0);
        break;

      case Fix.COMMAND_BLACK_SPORE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          AbstractAddBuff(target_list[ii], target_list[ii].objBuffPanel, "BlackSpore", Fix.COMMAND_BLACK_SPORE, Fix.INFINITY, 0, 0, 0);
        }
        break;

      case Fix.COMMAND_KILL_SPINNING_LANCER:
        ExecNormalAttack(player, target, 5.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_WING_BLADE:
        success = ExecMagicAttack(player, target, 1.2f, Fix.DamageSource.Wind, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffSilent(player, target, 2, 0);
          ExecBuffPhysicalAttackUp(player, player, 5, 0.20f);
        }
        break;

      case Fix.COMMAND_STONE_BLAW:
        success = ExecNormalAttack(player, target, 1.2f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffPhysicalDefenseDown(player, target, 5, 0.70f);
        }
        break;

      case Fix.COMMAND_HUMIOROSI:
        success = ExecNormalAttack(player, target, 1.2f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffMagicDefenseDown(player, target, 5, 0.70f);
        }
        break;

      case Fix.COMMAND_SQUALL_LIGHTNING:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          bool hit = ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          if (hit)
          {
            if (AP.Math.RandomInteger(3) == 0)
            {
              ExecBuffFreeze(player, target_list[ii], 2, 0);
            }
          }
        }
        break;

      case Fix.COMMAND_SIPPUUKEN:
        success = ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffBattleSpeedUp(player, player, 2, 0.30f);
        }
        break;

      case Fix.COMMAND_BRIGHTNESS_RINPUN:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          bool hit = ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          if (hit)
          {
            int random = AP.Math.RandomInteger(3);
            if (random == 0)
            {
              ExecBuffDizzy(player, target_list[ii], 3, 0.30f);
            }
            else if (random == 1)
            {
              ExecBuffSleep(player, target_list[ii], 3, 0);
            }
            else
            {
              ExecBuffPoison(player, target_list[ii], 3, 150);
            }
          }
        }
        break;

      case Fix.COMMAND_SHIROGANE_HORN:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        if (success)
        {
          target_list = GetAllyGroup(player);
          for (int ii = 0; ii < target_list.Count; ii++)
          {
            ExecBuffPhysicalDefenseUp(player, target_list[ii], 3, 0.20f);
          }
        }
        break;

      case Fix.COMMAND_VISIBLE_EYE:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffStun(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_INVISIBLE_EYE:
        ExecBuffBind(player, target, 3, 0);
        ExecBuffParalyze(player, target, 3, 0);
        break;

      case Fix.COMMAND_WIND_CUTTER:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          int number = AP.Math.RandomInteger(target_list.Count);
          ExecMagicAttack(player, target_list[number], 1.10f, Fix.DamageSource.Wind, Fix.IgnoreType.None, critical);         
        }
        break;

      case Fix.COMMAND_BLUE_LAVA:
        success = ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        if (success)
        {
          BuffUpIce(player, target, 5, 1.50f);
        }
        break;

      case Fix.COMMAND_BLUE_BUBBLE:
        success = ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        if (success)
        {
          BuffDownFire(player, target, 5, 0.30f);
        }
        break;

      case Fix.COMMAND_WHITE_LAVA:
        success = ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        if (success)
        {
          BuffUpLight(player, target, 5, 1.50f);
        }
        break;

      case Fix.COMMAND_WHITE_BUBBLE:
        success = ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        if (success)
        {
          BuffDownLight(player, target, 5, 0.30f);
        }
        break;

      case Fix.COMMAND_REFLECTION_SHADE:
        target_list = GetAllyGroupAlive(player);
        currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
        AbstractAddBuff(currentTarget, currentTarget.objBuffPanel, Fix.COMMAND_REFLECTION_SHADE, Fix.COMMAND_REFLECTION_SHADE, 3, 0, 0, 0);
        break;

      case Fix.COMMAND_ICHIMAI_GUARDWALL:
        target_list = GetAllyGroupAlive(player);
        currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
        AbstractAddBuff(currentTarget, currentTarget.objBuffPanel, Fix.COMMAND_ICHIMAI_GUARDWALL, Fix.COMMAND_ICHIMAI_GUARDWALL, 3, 0, 0, 0);
        break;

      case Fix.COMMAND_MULTIPLE_FEATHER:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 0.9f, Fix.DamageSource.Wind, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_BRIGHT_FLASH:
        success = ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffParalyze(player, target, 3, 0);
        }
        break;

      case Fix.COMMAND_CYCLONE_SHOT:
        for (int ii = 0; ii < 2; ii++)
        {
          ExecMagicAttack(player, target, 0.7f, Fix.DamageSource.Wind, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_MORPH_VANISH:
        success = ExecNormalAttack(player, target, 0.8f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (success)
        {
          int random = AP.Math.RandomInteger(3);
          if (random == 0)
          {
            ExecBuffPhysicalAttackDown(player, target, 3, 0.70f);
          }
          else if (random == 1)
          {
            ExecBuffMagicAttackDown(player, target, 3, 0.70f);
          }
          else
          {
            ExecBuffBattleSpeedDown(player, target, 3, 0.70f);
          }
        }
        break;

      case Fix.COMMAND_ROD_AGARTHA:
        success = ExecMagicAttack(player, target, 0.7f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffMagicAttackUp(player, player, 5, 0.20f);
        }
        break;

      case Fix.COMMAND_SWORD_MAHOROBA:
        success = ExecNormalAttack(player, target, 0.7f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffPhysicalAttackUp(player, player, 5, 0.20f);
        }
        break;

      case Fix.COMMAND_FEROCIOUS_THUNDER:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.7f, Fix.DamageSource.Wind, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_RAGING_CLAW:
        success = ExecNormalAttack(player, target, 1.0f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffSlip(player, target, 4, 200);
        }
        break;

      case Fix.COMMAND_CLEANSING_LIGHT:
        success = ExecMagicAttack(player, target, 1.0f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        if (success)
        {
          BuffUpLight(player, player, 4, 1.30f);
        }
        break;

      case Fix.COMMAND_FAITH_SIGHT:
        AbstractAddBuff(player, player.objFieldPanel, Fix.COMMAND_FAITH_SIGHT, Fix.COMMAND_FAITH_SIGHT, 9, 1200, 0, 0);
        break;

      case Fix.COMMAND_SAMAYOU_HAND:
        success = ExecNormalAttack(player, target, 0.7f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (success)
        {
          ExecBuffSlip(player, target, 3, 200);
          ExecBuffSilent(player, target, 3, 0);
        }
        break;

      case Fix.COMMAND_SEIIN_FOOTPRINT:
        AbstractAddBuff(player, player.objFieldPanel, Fix.COMMAND_SEIIN_FOOTPRINT, Fix.COMMAND_SEIIN_FOOTPRINT, 9, 15, 0, 0);
        break;

      case Fix.COMMAND_LIGHT_THUNDERBOLT:
        success = ExecMagicAttack(player, target, 1.30f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        if (success)
        {
          AbstractAddBuff(target, target.objBuffPanel, Fix.COMMAND_LIGHT_THUNDERBOLT, Fix.COMMAND_LIGHT_THUNDERBOLT, Fix.INFINITY, 0.10f, 0.10f, 0);
        }
        break;

      case Fix.COMMAND_CYCLONE_ARMOR:
        ExecBuffBattleSpeedUp(player, player, 5, 0.10f);
        ExecBuffPhysicalAttackUp(player, player, 5, 0.20f);
        ExecBuffMagicDefenseUp(player, player, 5, 0.30f);
        break;

      case Fix.COMMAND_FURY_TRIDENT:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
          int random = AP.Math.RandomInteger(3);
          if (random == 0)
          {
            ExecBuffFear(player, target_list[ii], 3, 0);
          }
          else if (random == 1)
          {
            ExecBuffFreeze(player, target_list[ii], 2, 0);
          }
          else if (random == 2)
          {
            ExecBuffStun(player, target_list[ii], 2, 0);
          }
        }
        break;

      case Fix.COMMAND_HEAVEN_THUNDER_SPEAR:
        ExecNormalAttack(player, target, 4.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecMagicAttack(player, target, 4.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_OVERRUN:
        ExecNormalAttack(player, target, 1.50f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_GLARE:
        ExecBuffStun(player, target, 2, 0);
        ExecBuffSilent(player, target, 3, 0);
        break;

      case Fix.COMMAND_ARC_BLASTER:
        ExecMagicAttack(player, target, 1.80f, Fix.DamageSource.Colorless, Fix.IgnoreType.None, critical);
        ExecBuffBattleSpeedUp(player, player, 5, 0.10f);
        break;

      case Fix.COMMAND_DRAGON_BREATH:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
          if (AP.Math.RandomInteger(2) == 0)
          {
            ExecBuffDizzy(player, target_list[ii], 2, 0.30f);
          }
          else
          {
            ExecBuffSilent(player, target_list[ii], 1, 0);
          }
        }
        ExecBuffBattleResponseUp(player, player, 5, 0.10f);
        break;

      case Fix.COMMAND_RENZOKU_BAKUHATSU:
        for (int ii = 0; ii < 3; ii++)
        {
          target_list = GetOpponentGroupAlive(player);
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.90f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_AIUCHI_NERAI:
        ExecLifeDown(player, 0.5f);
        ExecMagicAttack(player, target, 3.00f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_HIDDEN_KNIFE:
        ExecNormalAttack(player, target, 0.80f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Absolute);
        break;

      case Fix.COMMAND_MYSTICAL_FIELD:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffBattleSpeedUp(player, target_list[ii], 5, 0.10f);
        }
        break;

      case Fix.COMMAND_SEIKUU_GUARDWALL:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalDefenseUp(player, target_list[ii], 5, 0.50f);
        }
        break;

      case Fix.COMMAND_THUNDERCLOUD_INVASION:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 0.80f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          ExecBuffBattleResponseDown(player, target_list[ii], 5, 0.70f);
        }
        break;

      case Fix.COMMAND_MIST_BARRIER:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffMagicDefenseUp(player, target_list[ii], 5, 0.50f);
        }
        break;

      case Fix.COMMAND_SUN_SLAYER:
        ExecNormalAttack(player, target, 0.90f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecMagicAttack(player, target, 0.90f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_TRIPLE_TACTICS:
        rand = AP.Math.RandomInteger(3);
        if (rand == 0)
        {
          ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          ExecBuffPoison(player, target, 3, 500);
        }
        else if (rand == 1)
        {
          ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          ExecBuffBattleSpeedUp(player, player, 5, 0.10f);
        }
        else if (rand == 2)
        {
          ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          ExecBuffPhysicalAttackUp(player, player, 5, 0.10f);
        }
        break;

      case Fix.COMMAND_WIND_ARROW:
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffBind(player, target, 2, 0);
        break;

      case Fix.COMMAND_TYPHOON:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          if (AP.Math.RandomInteger(4) == 0)
          {
            ExecBuffStun(player, target_list[ii], 2, 0);
          }
        }
        break;

      case Fix.COMMAND_TAIKI_VANISH:
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Colorless, Fix.IgnoreType.None, critical);
        ExecBuffFreeze(player, target, 2, 0);
        break;

      case Fix.COMMAND_HARD_CHARGE:
        ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffStun(player, player, 1, 0);
        ExecBuffStun(player, target, 2, 0);
        break;

      case Fix.COMMAND_RAMPAGE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 5; ii++)
        {
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.80f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_ICE_BURN:
        ExecMagicAttack(player, target, 1.10f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        ExecBuffBind(player, target, 2, 0);
        ExecBuffSilent(player, target, 2, 0);
        break;

      case Fix.COMMAND_FROST_SHARD:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 5; ii++)
        {
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.80f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_DOKAAAAN:
        if (AP.Math.RandomInteger(4) == 0)
        {
          target_list = GetOpponentGroupAlive(player);
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 5.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        else
        {
          StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
        }
        break;

      case Fix.COMMAND_RENSYA:
        for (int ii = 0; ii < 2; ii++)
        {
          ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_ERRATIC_EXPLODE:
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
        ExecBuffSlip(player, target, 5, 500);
        break;

      case Fix.COMMAND_CYCLONE_FIELD:
        ExecBuffPhysicalDefenseUp(player, player, 5, 0.20f);
        ExecBuffMagicDefenseUp(player, player, 5, 0.20f);
        break;

      case Fix.COMMAND_ICE_RAY:
        ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Ice, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffFreeze(player, target, 1, 0);
        break;

      case Fix.COMMAND_CLEANSING_LANCE:
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.DefenseMode, critical);
        target_list = GetOpponentGroup(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          AbstractRemoveBuff(target_list[ii], target_list[ii].objBuffPanel, "", 1, Fix.BuffType.Positive);
        }
        break;

      case Fix.COMMAND_STATUS_CHANGE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          // Fear(恐怖)、Temptation(誘惑)、蘇生不可(Cannot Resurrect)は使用しない。
          List<string> chooseList = new List<string>() { Fix.EFFECT_POISON,
                                                       Fix.EFFECT_SILENT,
                                                       Fix.EFFECT_BIND,
                                                       Fix.EFFECT_SLEEP,
                                                       Fix.EFFECT_STUN,
                                                       Fix.EFFECT_PARALYZE,
                                                       Fix.EFFECT_FREEZE,
                                                       Fix.EFFECT_SLOW,
                                                       Fix.EFFECT_DIZZY,
                                                       Fix.EFFECT_SLIP };

          rand = AP.Math.RandomInteger(9);

          if (target_list[ii].IsStun == false)
          {
            chooseList.Remove(Fix.EFFECT_STUN);
          }
          else if (target_list[ii].IsBind == false)
          {
            chooseList.Remove(Fix.EFFECT_BIND);
          }
          else if (target_list[ii].IsSilent == false)
          {
            chooseList.Remove(Fix.EFFECT_SILENT);
          }
          else if (target_list[ii].IsFreeze == false)
          {
            chooseList.Remove(Fix.EFFECT_FREEZE);
          }
          else if (target_list[ii].IsSlip == false)
          {
            chooseList.Remove(Fix.EFFECT_SLIP);
          }
          else if (target_list[ii].IsSleep == false)
          {
            chooseList.Remove(Fix.EFFECT_SLEEP);
          }
          else if (target_list[ii].IsPoison == false)
          {
            chooseList.Remove(Fix.EFFECT_POISON);
          }
          else if (target_list[ii].IsParalyze == false)
          {
            chooseList.Remove(Fix.EFFECT_PARALYZE);
          }
          else if (target_list[ii].IsSlow == false)
          {
            chooseList.Remove(Fix.EFFECT_SLOW);
          }
          else if (target_list[ii].IsDizzy == false)
          {
            chooseList.Remove(Fix.EFFECT_DIZZY);
          }

          if (chooseList.Count > 0)
          {
            string choose = chooseList[AP.Math.RandomInteger(chooseList.Count)];
            if (choose == Fix.EFFECT_POISON)
            {
              ExecBuffPoison(player, target_list[ii], 9, 750);
            }
            else if (choose == Fix.EFFECT_SILENT)
            {
              ExecBuffSilent(player, target_list[ii], 3, 0);
            }
            else if (choose == Fix.EFFECT_BIND)
            {
              ExecBuffBind(player, target_list[ii], 3, 0);
            }
            else if (choose == Fix.EFFECT_SLEEP)
            {
              ExecBuffSleep(player, target_list[ii], 3, 0);
            }
            else if (choose == Fix.EFFECT_STUN)
            {
              ExecBuffStun(player, target_list[ii], 3, 0);
            }
            else if (choose == Fix.EFFECT_PARALYZE)
            {
              ExecBuffParalyze(player, target_list[ii], 3, 0);
            }
            else if (choose == Fix.EFFECT_FREEZE)
            {
              ExecBuffFreeze(player, target_list[ii], 2, 0);
            }
            else if (choose == Fix.EFFECT_SLOW)
            {
              ExecBuffSlow(player, target_list[ii], 3, 0.4f);
            }
            else if (choose == Fix.EFFECT_DIZZY)
            {
              ExecBuffDizzy(player, target_list[ii], 3, 0.30f);
            }
            else if (choose == Fix.EFFECT_SLIP)
            {
              ExecBuffSlip(player, target_list[ii], 9, 750);
            }
            else
            {
              ExecBuffFreeze(player, target_list[ii], 2, 0);
            }
          }
          else
          {
            ExecBuffFreeze(player, target_list[ii], 2, 0);
          }
        }
        break;

      case Fix.COMMAND_DEATH_DANCE:
        rand = AP.Math.RandomInteger(5);
        if (rand == 0)
        {
          ExecLifeDown(target, 0.10f);
        }
        else if (rand == 1)
        {
          ExecLifeDown(target, 0.30f);
        }
        else if (rand == 2)
        {
          ExecLifeDown(target, 0.50f);
        }
        else if (rand == 3)
        {
          ExecLifeDown(target, 0.60f);
        }
        else
        {
          ExecLifeDown(target, 0.70f);
        }
        break;

      case Fix.COMMAND_HEAVEN_VOICE:
        ExecLifeGain(player, player, 2000.0f + AP.Math.RandomInteger(1000));
        break;

      case Fix.COMMAND_PLASMA_STORM:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          double additional = (double)(AP.Math.RandomInteger(100) * 0.01f);
          ExecMagicAttack(player, target_list[ii], 0.85f + additional, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_APOCALYPSE_SWORD:
        ExecNormalAttack(player, target, 5.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        break;

      case Fix.COMMAND_WATER_GUN:
        ExecMagicAttack(player, target, 1.10f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        ExecBuffDizzy(player, target, 3, 0.20f);
        break;

      case Fix.COMMAND_WATER_DANCE:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffMagicDefenseUp(player, target_list[ii], 9, 0.50f);
        }
        break;

      case Fix.COMMAND_WATER_SHOT:
        ExecMagicAttack(player, target, 1.10f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        ExecBuffStun(player, target, 2, 0);
        break;

      case Fix.COMMAND_SKY_FEATHER:
        if (player.IsBattleSpeedUp == false)
        {
          ExecBuffBattleSpeedUp(player, player, 5, 0.10f);
        }
        else if (player.IsPhysicalAttackUp == false)
        {
          ExecBuffPhysicalAttackUp(player, player, 5, 0.10f);
        }
        else
        {
          ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_RAINBOW_BUBBLE:
        rand = AP.Math.RandomInteger(4);
        if (rand == 0)
        {
          target_list = GetAllyGroupAlive(player);
          for (int ii = 0; ii < target_list.Count; ii++)
          {
            ExecBuffMagicAttackUp(player, target_list[ii], 5, 0.20f);
          }
        }
        else if (rand == 1)
        {
          target_list = GetOpponentGroup(player);
          for (int ii = 0; ii < target_list.Count; ii++)
          {
            ExecBuffMagicDefenseDown(player, target_list[ii], 5, 0.20f);
          }
        }
        else if (rand == 2)
        {
          target_list = GetAllyGroupAlive(player);
          for (int ii = 0; ii < target_list.Count; ii++)
          {
            ExecBuffPhysicalDefenseUp(player, target_list[ii], 5, 0.20f);
          }
        }
        else if (rand == 3)
        {
          target_list = GetOpponentGroup(player);
          for (int ii = 0; ii < target_list.Count; ii++)
          {
            ExecBuffPhysicalDefenseDown(player, target_list[ii], 5, 0.80f);
          }
        }
        break;

      case Fix.COMMAND_WATER_CIRCLE:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecLifeGain(target_list[ii], target_list[ii], 1000 + AP.Math.RandomInteger(500));
        }
        break;

      case Fix.COMMAND_ROLLING_CHARGE:
        ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffStun(player, target, 1, 0);
        break;

      case Fix.COMMAND_JET_RUN:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecNormalAttack(player, target_list[ii], 0.90f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
          ExecBuffSlow(player, target_list[ii], 3, 0.80f);
        }
        break;

      case Fix.COMMAND_INVISIBLE_POISON:
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffPoison(player, target, 9, 1500);
        break;

      case Fix.COMMAND_BEAUTY_AROMA:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          rand = AP.Math.RandomInteger(3);
          if (rand == 0)
          {
            if (target.IsSleep == false)
            {
              ExecBuffSleep(player, target_list[ii], 3, 0);
            }
            else
            {
              ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
            }
          }
          else if (rand == 1)
          {
            if (target.IsDizzy == false)
            {
              ExecBuffDizzy(player, target_list[ii], 3, 0.20f);
            }
            else
            {
              ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
            }
          }
          else if (rand == 2)
          {
            if (target.IsParalyze == false)
            {
              ExecBuffParalyze(player, target_list[ii], 3, 0);
            }
            else
            {
              ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
            }
          }
        }
        break;

      case Fix.COMMAND_AQUA_BLOSSOM:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          if (target_list[ii].IsPoison == false)
          {
            ExecBuffPoison(player, target_list[ii], 9, 2500 + AP.Math.RandomInteger(500));
          }
          else if (target_list[ii].IsSlip == false)
          {
            ExecBuffSlip(player, target_list[ii], 9, 2500 + AP.Math.RandomInteger(500));
          }
          else
          {
            ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical);
          }
        }
        break;

      case Fix.COMMAND_DEATH_STROKE:
        rand = AP.Math.RandomInteger(3);
        if (rand == 0)
        {
          ExecLifeDown(target, 0.10f);
        }
        else if (rand == 1)
        {
          ExecLifeDown(target, 0.25f);
        }
        else
        {
          ExecLifeDown(target, 0.50f);
        }
        break;

      case Fix.COMMAND_DEVIL_EMBLEM:
        AbstractAddBuff(target, target.objFieldPanel, Fix.BUFF_DEVIL_EMBLEM, Fix.BUFF_DEVIL_EMBLEM, Fix.INFINITY, 0, 0, 0);
        break;

      case Fix.COMMAND_DEVILSPEAR_MISTELTEN:
        ExecNormalAttack(player, target, 5.50f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        break;

      case Fix.COMMAND_COLD_WIND:
        rand = AP.Math.RandomInteger(2);
        if (rand == 0)
        {
          ExecMagicAttack(player, target, 1.10f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          ExecBuffFreeze(player, target, 1, 0);
        }
        else if (rand == 1)
        {
          ExecBuffFreeze(player, target, 2, 0);
        }
        break;

      case Fix.COMMAND_PARALYZE_TENTACLE:
        if (target.IsParalyze == false)
        {
          ExecBuffParalyze(player, target, 3, 0);
        }
        else
        {
          ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_SCREAMING_SOUND:
        rand = AP.Math.RandomInteger(3);
        if (rand == 0)
        {
          if (target.IsBind == false)
          {
            ExecBuffBind(player, target, 3, 0);
          }
          else
          {
            ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          }
        }
        else if (rand == 1)
        {
          if (target.IsFear == false)
          {
            ExecBuffFear(player, target, 3, 0);
          }
          else
          {
            ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          }
        }
        else if (rand == 2)
        {
          if (target.IsSilent == false)
          {
            ExecBuffSilent(player, target, 3, 0);
          }
          else
          {
            ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          }
        }
        break;

      case Fix.COMMAND_KUROZUMI_FIELD:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffDizzy(player, target_list[ii], 3, 0.25f);
          ExecBuffSlow(player, target_list[ii], 3, 0.60f);
        }
        break;

      case Fix.COMMAND_HAGAIZIME:
        ExecNormalAttack(player, target, 1.10f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffStun(player, target, 2, 0);
        ExecBuffPhysicalDefenseDown(player, target, 3, 0.60f);
        break;

      case Fix.COMMAND_SOLID_SQUARE_WATER:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.10f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_BRIGHT_EYE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          rand = AP.Math.RandomInteger(3);
          if (rand == 0)
          {
            ExecBuffDizzy(player, target_list[ii], 3, 0.25f);
          }
          else if (rand == 1)
          {
            ExecBuffBind(player, target_list[ii], 3, 0);
          }
          else
          {
            ExecBuffParalyze(player, target_list[ii], 3, 0);
          }
        }
        break;

      case Fix.COMMAND_AXE_DRIVER:
        ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffPhysicalAttackUp(player, player, 9, 0.20f);
        break;

      case Fix.COMMAND_EARTH_CLAP:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecNormalAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_STONE_KOURA:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalDefenseUp(player, target_list[ii], 9, 0.30f);
        }            
        break;

      case Fix.COMMAND_DAIBOUSOU:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          rand = AP.Math.RandomInteger(300);
          double additional = (double)((double)rand / 100.0f);
          ExecNormalAttack(player, target_list[ii], 1.00f + additional, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_JUMP_SMASH:
        for (int ii = 0; ii < 2; ii++)
        {
          target_list = GetOpponentGroupAlive(player);
          rand = AP.Math.RandomInteger(target_list.Count);
          ExecNormalAttack(player, target_list[rand], 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          ExecNormalAttack(player, target_list[rand], 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_STRANGE_SPELL:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          rand = AP.Math.RandomInteger(2);
          if (rand == 0)
          {
            ExecBuffBattleSpeedUp(player, target_list[ii], 9, 0.20f);
          }
          else
          {
            ExecBuffPhysicalAttackUp(player, target_list[ii], 9, 0.20f);
          }
        }
        break;

      case Fix.COMMAND_THROWING_CRASH:
        ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffStun(player, target, 2, 0);
        break;

      case Fix.COMMAND_BAIRIKI:
        if (player.IsPhysicalAttackUp == false)
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 0.30f);
          ExecBuffPhysicalDefenseUp(player, player, 9, 0.30f);
        }
        else
        {
          ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_NAGITAOSHI:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecNormalAttack(player, target_list[ii], 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          ExecBuffStun(player, target_list[ii], 1, 0);
        }
        break;

      case Fix.COMMAND_WASHIZUKAMI:
        rand = AP.Math.RandomInteger(GetOpponentGroupAlive(player).Count);
        ExecLifeOne(target);
        break;

      case Fix.COMMAND_ZINARASHI:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          ExecBuffSlow(player, target_list[ii], 5, 1.00f - (double)((double)(AP.Math.RandomInteger(70))/100.0f));
        }
        break;

      case Fix.COMMAND_SUIKOMI:
        ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffFear(player, target, 5, 0);
        break;

      case Fix.COMMAND_EIGHT_ALL:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 8; ii++)
        {
          Character current_target = target_list[AP.Math.RandomInteger(target_list.Count)];
          // 強すぎるので物理攻撃はここでは与えない。
          // ExecNormalAttack(player, current_target, 0.50f, Fix.DamageSource.Physical, false, critical);
          rand = AP.Math.RandomInteger(8);
          if (rand == 0)
          {
            if (player.IsPhysicalAttackUp == false)
            {
              ExecBuffPhysicalAttackUp(player, player, 8, 0.40f);
            }
            else if (player.IsPhysicalDefenseUp == false)
            {
              ExecBuffPhysicalDefenseUp(player, player, 8, 0.30f);
            }
            else if (player.IsMagicAttackUp == false)
            {
              ExecBuffMagicAttackUp(player, player, 8, 0.30f);
            }
            else if (player.IsMagicDefenseUp == false)
            {
              ExecBuffMagicDefenseUp(player, player, 8, 0.30f);
            }
            else if (player.IsBattleSpeedUp == false)
            {
              ExecBuffBattleSpeedUp(player, player, 8, 0.30f);
            }
            // 戦闘反応が高すぎると、本コマンド自体のタイミングが早まってしまうため、対象外
            // else if (player.IsBattleReponseUp == false)
            // {
            //   ExecBuffBattleSpeedUp(player, player, 8, 0.30f);
            // }
            else
            {
              ExecMagicAttack(player, current_target, 0.50f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
            }
          }
          else if (rand == 1)
          {
            if (current_target.IsPhysicalAttackDown == false)
            {
              ExecBuffPhysicalAttackDown(player, current_target, 8, 0.60f);
            }
            else if (current_target.IsPhysicalDefenseDown == false)
            {
              ExecBuffPhysicalDefenseDown(player, current_target, 8, 0.60f);
            }
            else if (current_target.IsMagicAttackDown == false)
            {
              ExecBuffMagicAttackDown(player, current_target, 8, 0.60f);
            }
            else if (current_target.IsMagicDefenseDown == false)
            {
              ExecBuffMagicDefenseDown(player, current_target, 8, 0.60f);
            }
            else if (current_target.IsBattleSpeedDown == false)
            {
              ExecBuffBattleSpeedDown(player, current_target, 8, 0.60f);
            }
            else if (current_target.IsBattleResponseDown == false)
            {
              ExecBuffBattleResponseDown(player, current_target, 8, 0.60f);
            }
            else
            {
              ExecMagicAttack(player, current_target, 0.50f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
            }
          }
          else if (rand == 2)
          {
            ExecBuffSlip(player, current_target, 8, 2500);
          }
          else if (rand == 3)
          {
            ExecNormalAttack(player, current_target, 0.50f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          }
          else if (rand == 4)
          {
            if (current_target.IsDizzy == false)
            {
              ExecBuffDizzy(player, current_target, 8, 0.30f);
            }
            else
            {
              ExecBuffParalyze(player, target, 3, 0);
            }
          }
          else if (rand == 5)
          {
            if (current_target.IsSilent == false)
            {
              ExecBuffSilent(player, current_target, 8, 0);
            }
            else
            {
              ExecBuffBind(player, target, 4, 0);
            }
          }
          else if (rand == 6)
          {
            ExecBuffPoison(player, current_target, 8, 3000);
          }
          else if (rand == 7)
          {
            ExecBuffSleep(player, current_target, 8, 0);
          }
        }
        break;

      case Fix.COMMAND_SCARLET_SEED:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalAttackUp(player, target_list[ii], 5, 0.20f);
          ExecBuffMagicAttackUp(player, target_list[ii], 5, 0.20f);
        }
        break;

      case Fix.COMMAND_POISON_GERMINATION:
        ExecBuffPoison(player, target, 3, 4000);
        break;

      case Fix.COMMAND_WAVE_SIGN:
        ExecBuffBattleSpeedUp(player, player, 5, 0.20f);
        ExecBuffBattleSpeedDown(player, target, 5, 0.70f);
        break;

      case Fix.COMMAND_SILENT_SIGN:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffSilent(player, target_list[ii], 2, 0);
        }
        break;

      case Fix.COMMAND_HIKKAKI_CLAW:
        ExecNormalAttack(player, target, 1.10f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffSlip(player, target, 3, 3500 + AP.Math.RandomInteger(500));
        break;

      case Fix.COMMAND_BATTLE_DANCE:
        ExecBuffPhysicalAttackUp(player, player, 3, 0.20f);
        ExecBuffBattleSpeedUp(player, player, 3, 0.20f);
        break;

      case Fix.COMMAND_DRAIN_WEB:
        ExecMagicAttack(player, target, 1.10f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical);
        ExecBuffMagicDefenseDown(player, target, 3, 0.70f);
        break;

      case Fix.COMMAND_SAND_SMOKE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffDizzy(player, target_list[ii], 2, 0.30f);
        }
        break;

      case Fix.COMMAND_GUT_SLASH:
        ExecNormalAttack(player, target, 1.10f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffPhysicalDefenseDown(player, target, 3, 0.70f);
        break;

      case Fix.COMMAND_GUARDIAN_SONG:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalDefenseUp(player, target_list[ii], 3, 0.30f);
        }
        break;

      case Fix.COMMAND_WATER_FLAPPING:
        ExecMagicAttack(player, target, 1.10f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        ExecBuffBattleSpeedDown(player, target, 3, 0.70f);
        break;

      case Fix.COMMAND_INVISIBLE_THREAD:
        ExecBuffBind(player, target, 3, 0);
        ExecBuffSilent(player, target, 3, 0);
        break;

      case Fix.COMMAND_INTENSE_BREATH:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_BIG_SWIM:
        if (player.IsBattleSpeedUp == false)
        {
          ExecBuffBattleSpeedUp(player, player, 3, 0.20f);
        }
        else if (player.IsPhysicalDefenseUp == false)
        {
          ExecBuffPhysicalDefenseUp(player, player, 3, 0.20f);
        }
        else
        {
          ExecBuffMagicDefenseUp(player, player, 3, 0.20f);
        }
        ExecLifeGain(player, player, 4000.0f + AP.Math.RandomInteger(2500));
        break;

      case Fix.COMMAND_ROAR:
        target_list = GetOpponentGroup(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          if (target_list[ii].IsFear == false)
          {
            ExecBuffFear(player, target_list[ii], 2, 0);
          }
          else
          {
            ExecBuffStun(player, target_list[ii], 2, 0);
          }
        }
        break;

      case Fix.COMMAND_BITING:
        ExecNormalAttack(player, target, 1.50f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffPhysicalAttackUp(player, player, 3, 0.20f);
        break;

      case Fix.COMMAND_HOLLOW_MIST:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffDizzy(player, target_list[ii], 3, 0.25f);
        }
        break;

      case Fix.COMMAND_POLLUTED_POISON:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPoison(player, target_list[ii], 3, 6000 + AP.Math.RandomInteger(1000));
        }
        break;

      case Fix.COMMAND_BUBBLE_BULLET:
        ExecMagicAttack(player, target, 1.10f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        ExecBuffMagicDefenseDown(player, target, 3, 0.70f);
        break;

      case Fix.COMMAND_AMBUSH_ATTACK:
        ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffPhysicalDefenseDown(player, target, 3, 0.70);
        break;

      case Fix.COMMAND_GROUND_THUNDER:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_CONTINUOUS_CHARGE:
        target_list = GetOpponentGroupAlive(player);
        Character current = target_list[AP.Math.RandomInteger(target_list.Count)];
        for (int ii = 0; ii < 2; ii++)
        {
          ExecNormalAttack(player, current, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          ExecBuffStun(player, current, 1, 0);
        }
        break;

      case Fix.COMMAND_STAR_EMBLEM:
        ExecBuffMagicAttackUp(player, player, 3, 0.30f);
        ExecBuffMagicDefenseUp(player, player, 3, 0.30f);
        break;

      case Fix.COMMAND_MUD_PISTOL:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 4; ii++)
        {
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.80f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_RIPPER_CLAW:
        ExecNormalAttack(player, target, 1.30f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        break;

      case Fix.COMMAND_HIKICHIGIRI:
        ExecLifeDown(target, 0.50f);
        break;

      case Fix.COMMAND_RUBBER_TONG:
        ExecBuffBind(player, target, 3, 0);
        ExecBuffPoison(player, target, 3, 6000 + AP.Math.RandomInteger(1000));
        break;

      case Fix.COMMAND_SPANNING_SLASH:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.90f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_STARSWORD_KAI:
        ExecNormalAttack(player, target, 0.90f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecMagicAttack(player, target, 0.90f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_SEASTAR_EYE:
        ExecBuffParalyze(player, target, 3, 0);
        ExecBuffDizzy(player, target, 3, 0.30f);
        break;

      case Fix.COMMAND_WATER_CANNON:
        ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        ExecBuffStun(player, target, 1, 0);
        break;

      case Fix.COMMAND_PROTECTION_SEAL:
        target_list = GetAllyGroupAlive(player);
        ExecBuffMagicDefenseUp(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.30f);
        break;

      case Fix.COMMAND_BLOODSHOT_EYE:
        ExecBuffPhysicalAttackUp(player, player, 3, 0.30f);
        ExecBuffBattleSpeedUp(player, player, 3, 0.30f);
        break;

      case Fix.COMMAND_FRENZY_DRIVE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecNormalAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        }
        break;

      case Fix.COMMAND_THOUGHT_EATER:
        ExecMagicAttack(player, target, 1.10f, Fix.DamageSource.Colorless, Fix.IgnoreType.None, critical);
        ExecBuffMagicDefenseDown(player, target, 3, 0.70f);
        break;

      case Fix.COMMAND_VACUUM_SHOT:
        ExecNormalAttack(player, target, 1.10f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffPhysicalDefenseDown(player, target, 3, 0.70f);
        break;

      case Fix.COMMAND_PHANTOM_EATER:
        ExecLifeDown(target, 0.40f);
        break;

      case Fix.COMMAND_GHOST_KILL:
        rand = AP.Math.RandomInteger(10);
        if (rand == 0) { ExecLifeDown(target, 0.10f); }
        else if (rand == 1) { ExecLifeDown(target, 0.10f); }
        else if (rand == 2) { ExecLifeDown(target, 0.10f); }
        else if (rand == 3) { ExecLifeDown(target, 0.10f); }
        else if (rand == 4) { ExecLifeDown(target, 0.10f); }
        else if (rand == 5) { ExecLifeDown(target, 0.30f); }
        else if (rand == 6) { ExecLifeDown(target, 0.30f); }
        else if (rand == 7) { ExecLifeDown(target, 0.30f); }
        else if (rand == 8) { ExecLifeDown(target, 0.40f); }
        else if (rand == 9) { ExecLifeDown(target, 0.90f); }
        break;

      case Fix.COMMAND_ZERO_ATTACK:
        if (target.IsPhysicalDefenseDown == false)
        {
          ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
          ExecBuffPhysicalDefenseDown(player, target, 9, 0.70f);
        }
        else if (target.IsBattleSpeedDown == false)
        {
          ExecNormalAttack(player, target, 1.40f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
          ExecBuffBattleSpeedDown(player, target, 9, 0.70f);
        }
        else
        {
          ExecNormalAttack(player, target, 2.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Absolute);
        }
        break;

      case Fix.COMMAND_JU_STYLE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 10; ii++)
        {
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.40f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        }
        break;

      case Fix.COMMAND_CLEANSING_SONG:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecLifeGain(target_list[ii], target_list[ii], 5000 + AP.Math.RandomInteger(2000));
          AbstractRemoveBuff(target_list[ii], target_list[ii].objBuffPanel, "", 1, Fix.BuffType.Negative);
        }
        break;

      case Fix.COMMAND_WASH_AWAY:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 0.80f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          AbstractRemoveBuff(target_list[ii], target_list[ii].objBuffPanel, "", 1, Fix.BuffType.Positive);
        }
        break;

      case Fix.COMMAND_CHARGE:
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffStun(player, target, 1, 0);
        break;

      case Fix.COMMAND_SEA_STRIVE:
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecSeaStripe(player, target);
        break;

      case Fix.COMMAND_BLINK_SHELL:
        ExecFortuneSpirit(player, player);
        break;

      case Fix.COMMAND_PLATINUM_BLADE:
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffPhysicalDefenseDown(player, target, 9, 0.60f);
        break;

      case Fix.COMMAND_SEASTAR_OATH:
        ExecBuffPhysicalAttackUp(player, player, 9, 0.50f);
        break;

      case Fix.COMMAND_JEWEL_BREAK:
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        AbstractRemoveBuff(target, target.objBuffPanel, "", 2, Fix.BuffType.Positive);
        break;

      case Fix.COMMAND_STAR_DUST:
        UpdateMessage(player.FullName + "のスターソードが" + target.FullName + "へ無数の星屑を落とす！\r\n");
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        if (AP.Math.RandomInteger(2) == 0)
        {
          ExecBuffDizzy(player, target, 5, 0.30f);
        }
        else
        {
          ExecBuffStun(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_STARSWORD_KIRAMEKI:
        UpdateMessage(player.FullName + "はスターソード『煌』を振りかざしてきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.50f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_BARRIER_FIELD:
        UpdateMessage(player.FullName + "はスターソード『煌』を地面に差し込んだ！\r\n");
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalDefenseUp(player, target_list[ii], 9, 0.50f);
        }
        break;

      case Fix.COMMAND_CIRCULAR_SLASH:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecNormalAttack(player, target_list[ii], 1.50f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          ExecBuffSlip(player, target, 3, 5000 + AP.Math.RandomInteger(1000));
        }
        break;

      case Fix.COMMAND_TORPEDO_BUSTER:
        ExecNormalAttack(player, target, 3.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffFreeze(player, target, 2, 0);
        ExecBuffSlow(player, target, 9, 0.30f);
        break;

      case Fix.COMMAND_STAR_FALL:
        UpdateMessage(player.FullName + "のスターソードが" + target.FullName + "へ無数の星屑を落とす！\r\n");
        ExecMagicAttack(player, target, 1.50f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        ExecBuffSilent(player, target, 5, 0);
        ExecBuffStun(player, target, 1, 0);
        break;

      case Fix.COMMAND_STARSWORD_TSUYA:
        UpdateMessage(player.FullName + "はスターソード『艶』を振りかざしてきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.50f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_INVASION_FIELD:
        UpdateMessage(player.FullName + "はスターソード『艶』を地面に差し込んだ！\r\n");
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffMagicDefenseUp(player, target_list[ii], 9, 0.50f);
        }
        break;

      case Fix.COMMAND_ILLUSION_BOLT:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.50f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
          ExecBuffPoison(player, target, 3, 5000 + AP.Math.RandomInteger(1000));
        }
        break;

      case Fix.COMMAND_VORTEX_BLAST:
        ExecMagicAttack(player, target, 3.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffFreeze(player, target, 2, 0);
        ExecBuffSlow(player, target, 9, 0.30f);
        break;

      case Fix.COMMAND_FIRE_BULLET:
        UpdateMessage(player.FullName + "は燃え盛る炎の弾丸を吐いてきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 5; ii++)
        {
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.70f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_BLAZING_STORM:
        UpdateMessage(player.FullName + "の眼が大きくなる！ブレイジング・ストームを放射してきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_FLARE_BURN:
        UpdateMessage(player.FullName + "の目が一瞬、白い閃光を放ってきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffParalyze(player, target_list[ii], 4, 0);
        }
        break;

      case Fix.COMMAND_FIRE_WALL:
        // 蒼目の方にも火炎耐性を付ける。
        UpdateMessage(player.FullName + "はファイア・ウォールを発生させた！\r\n");
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          BuffResistFireUp(player, target_list[ii], 9, 12000);
        }
        break;

      case Fix.COMMAND_PENETRATION_EYE:
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
        ExecBuffStun(player, target, 2, 0);
        ExecBuffFear(player, target, 3, 0);
        break;

      case Fix.COMMAND_FROZEN_BULLET:
        UpdateMessage(player.FullName + "は凍てつく氷の弾丸を放ってきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 5; ii++)
        {
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.70f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_FREEZING_STORM:
        UpdateMessage(player.FullName + "の眼が大きくなる！フリージング・ストームを放射してきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_SUDDEN_SQUALL:
        UpdateMessage(player.FullName + "の目から突如、無数の氷線が放たれた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffSilent(player, target_list[ii], 4, 0);
        }
        break;

      case Fix.COMMAND_WATER_BUBBLE:
        //　赤目の方に水耐性を付ける。
        UpdateMessage(player.FullName + "はウォータ・バブルを発生させた！\r\n");
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          BuffResistIceUp(player, target_list[ii], 9, 12000);
        }
        break;

      case Fix.COMMAND_HALLUCINATE_EYE:
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        ExecBuffFreeze(player, target, 2, 0);
        ExecBuffSlow(player, target, 3, 0.30f);
        break;

      case Fix.COMMAND_BRAVE_ROAR:
        UpdateMessage(player.FullName + "は勇敢な雄叫びを上げた！\r\n");
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalAttackUp(player, target_list[ii], 5, 0.40f);
        }
        break;

      case Fix.COMMAND_SEASLIDE_WATER:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffBattleResponseUp(player, target_list[ii], 5, 0.30f);
        }
        break;

      case Fix.COMMAND_GUNGNIR_SLASH:
        UpdateMessage(player.FullName + "：食らえ、グングニルの力！　ッヤアァァァ！！\r\n");
        ExecNormalAttack(player, target, 2.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        ExecBuffSilent(player, target, 3, 0);
        break;

      case Fix.COMMAND_ISONIC_WAVE:
        UpdateMessage(player.FullName + "はアイソニック・ウェイヴを放ってきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_GUNGNIR_LIGHT:
        UpdateMessage(player.FullName + "：光輝け、グングニル！　ッハアァァァ！！\r\n");
        ExecNormalAttack(player, target, 5.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_LIFE_WATER:
        UpdateMessage(player.FullName + "は生命の龍水を浴びせた！\r\n");
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecLifeGain(target_list[ii], target_list[ii], 10000 + AP.Math.RandomInteger(2500));
        }
        break;

      case Fix.COMMAND_SALMAN_CHANT:
        UpdateMessage(player.FullName + "はサルマン神に対する誓いの詠唱を謡った！\r\n");
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalDefenseUp(player, target_list[ii], 5, 0.50f);
          ExecBuffMagicDefenseUp(player, target_list[ii], 5, 0.50f);
        }
        // PlayerSpellAbsorbWater(player, player);
        // PlayerSpellMirrorImage(player, player);
        break;

      case Fix.COMMAND_ANDATE_CHANT:
        UpdateMessage(player.FullName + "はアンダート神に対する誓いの詠唱を謡った！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalDefenseDown(player, target_list[ii], 5, 0.50f);
          ExecBuffMagicDefenseDown(player, target_list[ii], 5, 0.50f);
        }
        break;

      case Fix.COMMAND_ELEMENTAL_SPLASH:
        UpdateMessage(player.FullName + "は宙にウォータエレメンタルを飛ばした！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_BYAKURAN_FROZEN_ART:
        ExecMagicAttack(player, target, 5.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_SEASTAR_ORIGIN_SEAL:
        UpdateMessage(player.FullName + "は海星源の場全体へ大きな授印を展開しはじめた！\r\n");
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffBattleSpeedUp(player, target_list[ii], 5, 0.30f);
          ExecBuffMagicAttackUp(player, target_list[ii], 5, 0.40f);
          // Deflectionみたいな魔法はやはり欲しいか
          // PlayerSpellDeflection(player, group[ii]);
        }
        break;

      case Fix.COMMAND_SOUMEI_SEISOU_KEN:
        ExecMagicAttack(player, target, 3.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_SEASTARKING_ROAR:
        ExecBuffPhysicalAttackUp(player, player, 9, 0.20f);
        ExecBuffMagicAttackUp(player, player, 9, 0.20f);
        ExecBuffBattleResponseUp(player, player, 9, 0.20f);
        break;

      case Fix.COMMAND_BURST_CLOUD:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 10; ii++)
        {
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.30f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_TIDAL_WAVE:
        UpdateMessage(player.FullName + "は体全体を大きくうならせ、大きな津波を発生させてきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_SURGETIC_BIND:
        // 巻きつきによるスタン＋出血ダメージ攻撃を行う。
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffSlip(player, target, 9, 7000 + AP.Math.RandomInteger(1000));
        ExecBuffStun(player, target, 2, 0);
        break;

      case Fix.COMMAND_HUGE_SHOCKWAVE:
        // 一体に大ダメージ
        ExecNormalAttack(player, target, 5.0F, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        break;

      case Fix.COMMAND_BACKSTAB_ARROW:
        ExecNormalAttack(player, target, 1.00, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffSilent(player, target, 2, 0);
        break;

      case Fix.COMMAND_KARAME_BIND:
        ExecNormalAttack(player, target, 1.00, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffBind(player, target, 2, 0);
        break;

      case Fix.COMMAND_BEAST_SPIRIT:
        ExecBuffBattleSpeedUp(player, player, 3, 0.20f);
        break;

      case Fix.COMMAND_BEAST_HOUND:
        ExecBuffPhysicalDefenseUp(player, player, 3, 0.20f);
        break;

      case Fix.COMMAND_DATOTSU:
        ExecNormalAttack(player, target, 1.20f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        break;

      case Fix.COMMAND_ASSASSIN_POISONNEEDLE:
        ExecBuffPoison(player, target, 3, 8000 + AP.Math.RandomInteger(1500));
        break;

      case Fix.COMMAND_SAINT_SLASH:
        ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        ExecBuffDizzy(player, target, 3, 0.50f);
        break;

      case Fix.COMMAND_DEMON_CONTRACT:
        if (player.IsPhysicalAttackUp == false)
        {
          ExecBuffPhysicalAttackUp(player, player, 5, 0.9f);
        }
        else if (player.IsPhysicalDefenseUp == false)
        {
          ExecBuffPhysicalDefenseUp(player, player, 5, 0.9f);
        }
        ExecLifeDown(player, 0.10f);
        break;

      case Fix.COMMAND_DARKM_SPELL:
        ExecMagicAttack(player, target, 1.20f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffSilent(player, target, 2, 0);
        break;

      case Fix.COMMAND_HELLFIRE_SPELL:
        ExecMagicAttack(player, target, 1.30f, Fix.DamageSource.Fire, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffSlip(player, target, 3, 8500 + AP.Math.RandomInteger(1200));
        break;

      case Fix.COMMAND_RENZOKU_HOUSYA:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.90f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_STEAM_ARROW:
        ExecNormalAttack(player, target, 1.50f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecBuffStun(player, target, 2, 0);
        break;

      case Fix.COMMAND_BLACKDRAGON_WHISPER:
        UpdateMessage(player.FullName + "は黒龍より禁断の闇技を授かり、アイン達へ向けて呪術を放った。\r\n");
        ExecBuffCannotResurrect(player, target, Fix.INFINITY, 0);
        break;

      case Fix.COMMAND_DEATH_HAITOKU:
        target_list = GetAllyGroup(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          if (target_list[ii].Dead)
          {
            UpdateMessage(player.FullName + "は対象の魂に黒龍の生命エネルギーを注ぎ込んだ！\r\n");
            AbstractResurrection(player, target_list[ii], target.MaxLife);
            break;
          }
        }
        break;

      case Fix.COMMAND_SUPERIOR_FIELD:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalDefenseUp(player, target_list[ii], 5, 0.30f);
          ExecBuffMagicDefenseUp(player, target_list[ii], 5, 0.30f);
        }
        break;

      case Fix.COMMAND_SHINDOWKEN:
        for (int ii = 0; ii < 2; ii++)
        {
          ExecNormalAttack(player, target, 1.00f + AP.Math.RandomInteger(3) / 5.0f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_DEATH_STRIKE:
        UpdateMessage(player.FullName + "の強烈無比な剣技が" + target.FullName + "に炸裂した！\r\n");
        if (ExecNormalAttack(player, target, 2.0F, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical))
        {
          if (AP.Math.RandomInteger(3) == 0)
          {
            ExecLifeDown(target, 1.00f);
          }
        }
        break;

      case Fix.COMMAND_SOUL_FROZEN:
        UpdateMessage(player.FullName + "は剣を" + target.FullName + "の魂に突き立てるように切っ先を向けた！！\r\n");
        //GroundOne.PlaySoundEffect(Database.SOUND_ABSOLUTE_ZERO);
        ExecAbsoluteZero(player, target);
        break;

      case Fix.COMMAND_CURSED_THREAD:
        UpdateMessage(player.FullName + "：・・ックスス、ほぉら呪いの糸よ。\n");
        if (ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical))
        {
          ExecBuffParalyze(player, target, 3, 0);
          ExecBuffSlip(player, target, 5, 9500);
        }
        break;

      case Fix.COMMAND_HORROR_VISION:
        UpdateMessage(player.FullName + "：アッハハハ！！アタシを見ながら死ねえぇぇ！\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffBattleSpeedDown(player, target_list[ii], 3, 0.70f);
        }
        break;

      case Fix.COMMAND_RASEN_KOKUEN:
        UpdateMessage(player.FullName + "は刀の切っ先を素早く螺旋状に描き、黒い炎を噴出してきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          if (ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical))
          {
            AbstractAddBuff(target_list[ii], target_list[ii].objBuffPanel, Fix.DEATH_SCYTHE, Fix.BUFF_DEATH_SCYTHE_JP, 9, SecondaryLogic.DeathScythe_Effect(player), 0, 0);
          }
        }
        break;

      case Fix.COMMAND_RANSO_RENGEKI:
        UpdateMessage(player.FullName + "は狂気じみた旋律を奏でつつ、乱雑に刀を振り回してきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int i = 0; i < 3; i++)
        {
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.90f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_DEMON_BOLT:
        UpdateMessage(player.FullName + "は空間に悪魔の炎を創生してきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.20f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_ARCANE_DESTRUCTION:
        UpdateMessage(player.FullName + "は青紫のエネルギー体を創り出し、一気にそれを放出してきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          //GroundOne.PlaySoundEffect(Database.SOUND_ARCANE_DESTRUCTION);
          ExecLifeDownCurrent(target_list[ii], 0.50f);
        }
        break;

      case Fix.COMMAND_TOWER_FALL:
        if (ExecNormalAttack(player, target, 1.50f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical))
        {
          ExecBuffStun(player, target, 1, 0);
          ExecBuffParalyze(player, target, 4, 0);
        }
        break;

      case Fix.COMMAND_ROUND_DIVIDE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecNormalAttack(player, target_list[ii], 0.80f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          ExecBuffSlow(player, target_list[ii], 2, 0.35f);
        }
        break;

      case Fix.COMMAND_BLACK_FLARE:
        UpdateMessage(player.FullName + "：太陽の影より出てし熱き炎よ、焼き尽くせ！\r\n");
        target_list = GetOpponentGroupAlive(player);
        //GroundOne.PlaySoundEffect(Database.SOUND_BLACK_FLARE);
        // 雑魚モンスターとしては強すぎるので撤廃
        //for (int ii = 0; ii < target_list.Count; ii++)
        //{
        //  ExecMagicAttack(player, target_list[ii], 1.10f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
        //}
        ExecVolcanicBlaze(player, target_list, target.objFieldPanel, critical);
        break;

      case Fix.COMMAND_SATELLITE_SWORD:
        UpdateMessage(player.FullName + "：我が剣、喰らうがよい！！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.0F + AP.Math.RandomInteger(3), Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_SIGIL_OF_SUN_FALLEN:
        UpdateMessage(player.FullName + "：太陽を滅ぼすが如く！　太陽の滅印をくらえ！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecLifeOne(target_list[ii]);
          // ExecBuffSlip(player, target_list[ii], 3, 9000); // 雑魚モンスターとしては強すぎるので撤廃
        }
        break;

      case Fix.COMMAND_LIFE_BRILLIANT:
        UpdateMessage(player.FullName + "：この輝きを受け取りなさい。\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
        }
        AbstractHealCommand(player, player, player.MaxLife / 20.0f, false);
        break;

      case Fix.COMMAND_ALL_DUST:
        UpdateMessage(player.FullName + "：衰え朽ちなさい。\r\n");
        target_list = GetAllMember();
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecLifeDown(target_list[ii], 0.10f + AP.Math.RandomInteger(5) * 0.10f);
        }
        break;

      case Fix.COMMAND_LVEL_SONG:
        UpdateMessage(player.FullName + "：苦しみを抱え込みなさい。\r\n");
        //GroundOne.PlaySoundEffect(Database.SOUND_DAMNATION);
        target_list = GetAllMember();
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffSlip(player, target_list[ii], Fix.INFINITY, 7500 + AP.Math.RandomInteger(2500));
          ExecBuffPoison(player, target_list[ii], Fix.INFINITY, 7500 + AP.Math.RandomInteger(2500));
          // Damnation 雑魚モンスターとしては強すぎるので撤廃
        }
        break;

      case Fix.COMMAND_GIGANT_SLAYER:
        UpdateMessage(player.FullName + "：このイチゲキにて、クチハテよ\r\n");
        ExecNormalAttack(player, target, 2.0f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecBuffStun(player, target, 2, 0);
        break;

      case Fix.COMMAND_JUONSATSU:
        UpdateMessage(player.FullName + "：シせよ、オロカなるモノ\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          if (AP.Math.RandomInteger(4) == 0)
          {
            ExecLifeDown(target_list[ii], 1.00f);
          }
          else
          {
            ExecLifeOne(target_list[ii]);
          }
        }
        break;

      case Fix.COMMAND_ABYSS_LOGIC:
        UpdateMessage(player.FullName + "：ヤミへのコトワリ、シンエンへシズメ\r\n");
        ExecBuffPhysicalAttackDown(player, target, 3, 0.50f);
        ExecBuffPhysicalDefenseDown(player, target, 3, 0.50f);
        ExecBuffMagicAttackDown(player, target, 3, 0.50f);
        ExecBuffMagicDefenseDown(player, target, 3, 0.50f);
        ExecBuffBattleSpeedDown(player, target, 3, 0.50f);
        ExecBuffBattleResponseDown(player, target, 3, 0.50f);
        //ExecBuffBattlePotentialDown(player, target, 3, 0.50f); 雑魚モンスターとしては強すぎるので撤廃
        break;

      case Fix.COMMAND_BONE_TORNADO:
        UpdateMessage(player.FullName + "：は骨の嵐を部屋中に巻き起こしてきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_OMINOUS_LAUGH:
        UpdateMessage(player.FullName + "：は禍々しい呪詛を部屋中に響き渡らせてきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          if (AP.Math.RandomInteger(4) == 0)
          {
            ExecLifeDown(target_list[ii], 1.00f);
          }
          else
          {
            ExecLifeDown(target_list[ii], 0.50f);
          }
        }
        break;

      case Fix.COMMAND_SKULL_CRASH:
        UpdateMessage(player.FullName + "は頭蓋骨の部分をめがけて突進してきた。\r\n");
        if (ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical))
        {
          ExecBuffStun(player, target, 2, 0);
          ExecBuffSlip(player, target, 9, 8500);
        }
        break;

      case Fix.COMMAND_WAZAWAI_FLAME:
        UpdateMessage(player.FullName + "：シュゴオオオォォォ！！！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.DefenseMode, critical);
        }
        break;

      case Fix.COMMAND_THE_END:
        UpdateMessage(player.FullName + "：フシャアアアアァァ！！！！\r\n");
        target_list = GetOpponentGroupAlive(player);
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_HELLFLAME_BULLET:
        UpdateMessage(player.FullName + "：ダラララララアァ！！！！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 5; ii++)
        {
          ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 0.50f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_CHROMATIC_BULLET:
        UpdateMessage(player.FullName + "：ッハッハハハ、喰らえ喰らえ。\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          rand = AP.Math.RandomInteger(5);

          if (rand == 0)
          {
            ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
          }
          else if (rand == 1)
          {
            ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          }
          else if (rand == 2)
          {
            ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
          }
          else if (rand == 3)
          {
            ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.00f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical);
          }
          else if (rand == 4)
          {
            ExecMagicAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.00f, Fix.DamageSource.Colorless, Fix.IgnoreType.None, critical);
          }
        }
        break;

      case Fix.COMMAND_SUPER_MAX_WAVE:
        UpdateMessage(player.FullName + "：灼け落ちろ、超高温熱波動だ。\r\n");
        if (ExecMagicAttack(player, target, 2.00f, Fix.DamageSource.Fire, Fix.IgnoreType.DefenseMode, critical))
        {
          ExecBuffCannotResurrect(player, target, Fix.INFINITY, 0);
        }
        break;

      case Fix.COMMAND_IRREGULAR_REGENERATION:
        UpdateMessage(player.FullName + "：この再生能力、ニンゲンは欲しがるだろうな。\r\n");
        ExecLifeGain(player, player, player.MaxLife / 5.0f);
        break;

      case Fix.COMMAND_ETERNAL_CIRCLE:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          rand = AP.Math.RandomInteger(6);
          if (rand == 0)
          {
            ExecBuffPhysicalAttackUp(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.40f);
          }
          else if (rand == 1)
          {
            ExecBuffPhysicalDefenseUp(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.40f);
          }
          else if (rand == 2)
          {
            ExecBuffMagicAttackUp(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.40f);
          }
          else if (rand == 3)
          {
            ExecBuffMagicDefenseUp(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.40f);
          }
          else if (rand == 4)
          {
            ExecBuffBattleSpeedUp(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.40f);
          }
          else if (rand == 5)
          {
            ExecBuffBattleResponseUp(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.40f);
          }
        }
        break;

      case Fix.COMMAND_DESTRUCTION_CIRCLE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          rand = AP.Math.RandomInteger(6);
          if (rand == 0)
          {
            ExecBuffPhysicalAttackDown(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.60f);
          }
          else if (rand == 1)
          {
            ExecBuffPhysicalDefenseDown(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.60f);
          }
          else if (rand == 2)
          {
            ExecBuffMagicAttackDown(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.60f);
          }
          else if (rand == 3)
          {
            ExecBuffMagicDefenseDown(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.60f);
          }
          else if (rand == 4)
          {
            ExecBuffBattleSpeedDown(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.60f);
          }
          else if (rand == 5)
          {
            ExecBuffBattleResponseDown(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.60f);
          }
        }
        break;

      case Fix.COMMAND_PERFECT_STOP:
        ExecTimeStop(player);
        break;

      case Fix.COMMAND_SPECTOR_VOICE:
        UpdateMessage(player.FullName + "のスペクター・ヴォイスが発動した！\r\n");
        //GroundOne.PlaySoundEffect(Database.SOUND_ABSOLUTE_ZERO);
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 5; ii++)
        {
          rand = AP.Math.RandomInteger(4);
          if (rand == 0)
          {
            ExecBuffStun(player, target_list[AP.Math.RandomInteger(target_list.Count)], 2, 0);
          }
          else if (rand == 1)
          {
            ExecBuffSilent(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0);
          }
          else if (rand == 2)
          {
            ExecBuffDizzy(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0.30f);
          }
          else
          {
            ExecBuffSlip(player, target_list[AP.Math.RandomInteger(target_list.Count)], 9, 10000);
          }
        }
        break;

      case Fix.COMMAND_NOMERCY_SCREAM:
        UpdateMessage(player.FullName + "から無慈悲な叫び声が発せられた！" + target.FullName + "の心に直接ダメージが発生される。\r\n");
        ExecMagicAttack(player, target, 1.00f + AP.Math.RandomReal(), Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical);
        break;

      case Fix.COMMAND_DARK_SIMULACRUM:
        UpdateMessage(player.FullName + "不気味なドス黒い物体を排出し、それを放ってきた。\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 5; ii++)
        {
          rand = AP.Math.RandomInteger(4);
          if (rand == 0)
          {
            ExecBuffPoison(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 10000);
          }
          else if (rand == 1)
          {
            ExecLifeDownCurrent(target_list[AP.Math.RandomInteger(target_list.Count)], 0.50f);
          }
          else if (rand == 2)
          {
            ExecBuffCannotResurrect(player, target_list[AP.Math.RandomInteger(target_list.Count)], Fix.INFINITY, 0);
          }
          else
          {
            ExecBuffFear(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3, 0);
          }
        }
        break;

      case Fix.COMMAND_FABRIOLE_SPEAR:
        UpdateMessage(player.FullName + "：苦しみを刻み込みなさい、フェイブリオル・ランス！\r\n");
        target_list = GetOpponentGroupAlive(player);
        currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
        if (ExecNormalAttack(player, currentTarget, 2.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical))
        {
          ExecBuffStun(player, currentTarget, 2, 0);
        }
        break;

      case Fix.COMMAND_REST_IN_DREAM:
        UpdateMessage(player.FullName + "：苦しむ事はないのよ、安らかなる死別を与えましょう。\r\n");
        if (AP.Math.RandomInteger(2) == 0)
        {
          ExecLifeOne(target);
        }
        else
        {
          ExecLifeDown(target, 1.00f);
        }
        break;

      case Fix.COMMAND_DANCING_LANCER:
        UpdateMessage(player.FullName + "：この槍の舞を受けてみなさい、ダンシング・ランサー！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 2; ii++)
        {
          currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
          ExecNormalAttack(player, currentTarget, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
          currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
          ExecMagicAttack(player, currentTarget, 1.00f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_CHAOS_DEATHPERADE:
        UpdateMessage(player.FullName + "は終了のサインを示す演舞を踊ってみせた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        ExecDeathScythe(player, target_list[AP.Math.RandomInteger(target_list.Count)], target_list[0].objFieldPanel);
        break;

      case Fix.COMMAND_MARIA_DANSEL:
        UpdateMessage(player.FullName + "は不気味で美しい妖艶な演舞を踊ってみせた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalAttackDown(player, target_list[ii], 3, 0.50f);
          ExecBuffMagicAttackDown(player, target_list[ii], 3, 0.50f);
        }
        break;

      case Fix.COMMAND_DESTRUCT_TUNING:
        UpdateMessage(player.FullName + "は何も無い空間に対して破壊を行う演舞を踊ってみせた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffBattlePotentialDown(player, target_list[ii], 3, 0.70f);
        }
        break;

      case Fix.COMMAND_GROUND_CRACK:
        UpdateMessage(player.FullName + "の純黒の槍が地上へ突き刺された。大地に裂け目が発生する！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          if (ExecNormalAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical))
          {
            ExecBuffParalyze(player, target_list[ii], 2, 0);
            ExecBuffSilent(player, target_list[ii], 4, 0);
            ExecBuffBind(player, target_list[ii], 4, 0);
          }
        }
        break;

      case Fix.COMMAND_BLACK_DARK_LANCE:
        UpdateMessage(player.FullName + "は突先が純黒に染まった槍を" + target.FullName + "に向けて放ってきた！\r\n");
        if (target.CurrentLife <= 1000)
        {
          ExecLifeDown(target, 1.00f);
        }
        else if (AP.Math.RandomInteger(3) == 0)
        {
          ExecLifeOne(target);
        }
        else
        {
          ExecBuffDizzy(player, target, 3, 0.30f);
          ExecBuffSlip(player, target, 5, 12000);
        }
        break;

      case Fix.COMMAND_UNDEAD_WISH:
        UpdateMessage(player.FullName + "は不死への渇望を貪欲に見せ始めた！\r\n");
        ExecLifeGain(player, player, player.MaxLife / 5.0f);
        break;

      case Fix.COMMAND_HELL_CIRCLE:
        UpdateMessage(player.FullName + "は地獄の円を部屋全体に描いてきた！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffSlow(player, target_list[ii], 5, 0.30f);
          ExecBuffSlip(player, target_list[ii], 2, 14000);
          ExecBuffDizzy(player, target_list[ii], 3, 0.30f);
        }
        break;

      case Fix.COMMAND_INNOCENT_SLASH:
        UpdateMessage(player.FullName + "はスっとどこへともなく振りかざしてきた。\r\n");
        target_list = GetOpponentGroupAlive(player);
        ExecBuffCannotResurrect(player, target, Fix.INFINITY, 0);
        ExecLifeOne(target);
        ExecDeathScythe(player, target, target.objFieldPanel);
        break;

      case Fix.COMMAND_HARSH_CUTTER:
        UpdateMessage(player.FullName + "は部屋中をかき乱すように剣をぶん回してきた！！\r\n");
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
          ExecNormalAttack(player, currentTarget, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_JUDGEMENT_LIGHTNING:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
          ExecMagicAttack(player, currentTarget, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_BLACKHOLE:
        if (target.CurrentLife > target.MaxLife / 2.0f)
        {
          ExecLifeDownCurrent(target, 0.90f);
        }
        else
        {
          ExecLifeDown(target, 1.00f);
        }
        break;

      case Fix.COMMAND_ERROR_OCCUR:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffBattleSpeedDown(player, target_list[ii], 3, 0.30f);
        }
         ExecBuffBattleSpeedUp(player, player, 3, 0.50f);
        break;

      case Fix.COMMAND_FUMBLE_SIGN:
        if (ExecNormalAttack(player, target, 1.50f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical))
        {
          ExecBuffPhysicalAttackDown(player, target, 3, 0.80f);
          ExecBuffBattleSpeedDown(player, target, 3, 0.20f);
        }
        break;

      case Fix.COMMAND_AREA_TWIST:
        ExecLifeOne(target);
        break;

      case Fix.COMMAND_PARADOXICAL_SLICER:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
          ExecNormalAttack(player, currentTarget, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_OAHN_VOICE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          rand = AP.Math.RandomInteger(4);
          if (rand == 0)
          {
            ExecBuffStun(player, target_list[AP.Math.RandomInteger(target_list.Count)], 2, 0);
            ExecBuffBind(player, target, 5, 0);
          }
          else if (rand == 1)
          {
            ExecBuffStun(player, target_list[AP.Math.RandomInteger(target_list.Count)], 2, 0);
            ExecBuffParalyze(player, target, 5, 0);
          }
          else if (rand == 2)
          {
            ExecBuffStun(player, target_list[AP.Math.RandomInteger(target_list.Count)], 2, 0);
            ExecBuffFear(player, target, 5, 0);
          }
          else if (rand == 3)
          {
            ExecBuffStun(player, target_list[AP.Math.RandomInteger(target_list.Count)], 2, 0);
            ExecBuffSilent(player, target, 5, 0);
          }
        }
        break;

      case Fix.COMMAND_MOMENT_MAGIC:
        if (ExecMagicAttack(player, target, 2.00f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.DefenseMode, critical))
        {
          ExecBuffFreeze(player, target, 1, 0);
        }
        break;

      case Fix.COMMAND_DESPIAR_RAIN:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          if (ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical))
          {
            ExecBuffMagicDefenseDown(player, target_list[ii], 3, 0.30f);
          }
        }
        break;

      case Fix.COMMAND_SWORD_OF_WIND:
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Colorless, Fix.IgnoreType.DefenseMode, critical);
        break;

      case Fix.COMMAND_SKY_CUTTER:
        if (ExecNormalAttack(player, target, 1.50f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical))
        {
          ExecSlipDamage(target, 15000);
          ExecBuffFear(player, target, 5, 0);
          ExecBuffDizzy(player, target, 5, 0.30f);
          ExecBuffBattleSpeedDown(player, target, 5, 0.30f);
        }
        break;

      case Fix.COMMAND_SONIC_BLADE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 3; ii++)
        {
          currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
          ExecNormalAttack(player, currentTarget, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, critical);
        }
        break;

      case Fix.COMMAND_SCREAMING_FROM_HELL:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffStun(player, target_list[ii], 2, 0);
          ExecBuffPhysicalDefenseDown(player, target_list[ii], 5, 0.30f);
          ExecBuffMagicDefenseDown(player, target_list[ii], 5, 0.30f);
        }
        break;

      case Fix.COMMAND_DESPAIR_SPEAR:
        ExecMagicAttack(player, target, 2.00f, Fix.DamageSource.Colorless, Fix.IgnoreType.Both, critical);
        break;

      case Fix.COMMAND_KUUKAN_MATEN:
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          target_list[ii].objBuffPanel.RemoveAll(target_list[ii]);
          ExecBuffPhysicalAttackUp(player, target_list[ii], 5, 0.50f); 
          ExecBuffMagicAttackUp(player, target_list[ii], 5, 0.50f);
        }
        break;

      case Fix.COMMAND_METEOR_STORM:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          for (int jj = 0; jj < 3; jj++)
          {
            ExecMagicAttack(player, target_list[ii], 0.50f, Fix.DamageSource.Fire, Fix.IgnoreType.Both, critical);
          }
        }
        break;

      case Fix.COMMAND_CROSS_GATE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalDefenseDown(player, target_list[ii], 5, 0.25f);
          ExecBuffMagicDefenseDown(player, target_list[ii], 5, 0.25f);
          ExecBuffBattleSpeedDown(player, target_list[ii], 5, 0.25f);
        }
        target_list = GetAllyGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffPhysicalAttackUp(player, target_list[ii], 5, 0.25f);
          ExecBuffMagicAttackUp(player, target_list[ii], 5, 0.25f);
          ExecBuffBattleSpeedUp(player, target_list[ii], 5, 0.25f);
        }
        break;

      case Fix.COMMAND_PRISMATIC_BULLET:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 4; ii++)
        {
          rand = AP.Math.RandomInteger(5);

          currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
          if (rand == 0)
          {
            ExecMagicAttack(player, currentTarget, 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
            ExecBuffStun(player, currentTarget, 2, 0);
          }
          else if (rand == 1)
          {
            ExecMagicAttack(player, currentTarget, 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
            ExecBuffFreeze(player, currentTarget, 2, 0);
          }
          else if (rand == 2)
          {
            ExecMagicAttack(player, currentTarget, 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical);
            ExecBuffSlip(player, currentTarget, 5, 20000);
          }
          else if (rand == 3)
          {
            ExecMagicAttack(player, currentTarget, 1.00f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical);
            ExecBuffFear(player, currentTarget, 5, 0);
          }
          else if (rand == 4)
          {
            ExecMagicAttack(player, currentTarget, 1.00f, Fix.DamageSource.Colorless, Fix.IgnoreType.None, critical);
            ExecBuffCannotResurrect(player, currentTarget, Fix.INFINITY, 0);
          }
        }
        break;

      case Fix.COMMAND_PHOTON_LASER:
        target_list = GetOpponentGroupAlive(player);
        if (AP.Math.RandomInteger(2) == 0)
        {
          ExecLifeDown(target_list[AP.Math.RandomInteger(target_list.Count)], 1.00f);
        }
        else
        {
          ExecLifeOne(target_list[AP.Math.RandomInteger(target_list.Count)]);
        }
        break;

      case Fix.COMMAND_SEALED_STONE:
        ExecBuffBind(player, target, 5, 0);
        ExecBuffParalyze(player, target, 5, 0);
        ExecBuffSilent(player, target, 5, 0);
        ExecBuffFreeze(player, target, 3, 0);
        ExecBuffStun(player, target, 3, 0);
        break;

      case Fix.COMMAND_OUT_OF_CONTROL:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 4; ii++)
        {
          ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_POWER_EXPLOSION:
        target_list = GetOpponentGroupAlive(player);
        currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
        if (ExecNormalAttack(player, currentTarget, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical))
        {
          currentTarget.UseInstantPoint(false, Fix.COMMAND_POWER_EXPLOSION);
          currentTarget.UpdateInstantPointGauge();
        }
        break;

      case Fix.COMMAND_PERFECT_HIT:
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.Both, Fix.CriticalType.Absolute);
        break;

      case Fix.COMMAND_FUSION_CHARGE:
        player.CurrentInstantPoint += 1500;
        player.UpdateInstantPointGauge();
        StartAnimation(player.objGroup.gameObject, "インスタントゲージ増強", Fix.COLOR_NORMAL);
        break;

      case Fix.COMMAND_LEGION_DRIVE:
        ExecDivineCircle(player, player, player.objFieldPanel);
        if (player.IsPhysicalAttackUp == false)
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 0.20f);
        }
        else if (player.IsPhysicalAttackUp.EffectValue <= 0.20f)
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 0.30f);
        }
        else if (player.IsPhysicalAttackUp.EffectValue <= 0.30f)
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 0.40f);
        }
        else if (player.IsPhysicalAttackUp.EffectValue <= 0.40f)
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 0.50f);
        }
        else if (player.IsPhysicalAttackUp.EffectValue <= 0.50f)
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 0.60f);
        }
        else if (player.IsPhysicalAttackUp.EffectValue <= 0.60f)
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 0.70f);
        }
        else if (player.IsPhysicalAttackUp.EffectValue <= 0.70f)
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 0.80f);
        }
        else if (player.IsPhysicalAttackUp.EffectValue <= 0.80f)
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 0.90f);
        }
        else
        {
          ExecBuffPhysicalAttackUp(player, player, 9, 1.00f);
        }

        if (player.IsPhysicalDefenseUp == false)
        {
          ExecBuffPhysicalDefenseUp(player, player, 9, 0.20f);
        }
        else if (player.IsPhysicalDefenseUp.EffectValue <= 0.20f)
        {
          ExecBuffPhysicalDefenseUp(player, player, 9, 0.30f);
        }
        else if (player.IsPhysicalDefenseUp.EffectValue <= 0.30f)
        {
          ExecBuffPhysicalDefenseUp(player, player, 9, 0.40f);
        }
        else if (player.IsPhysicalDefenseUp.EffectValue <= 0.40f)
        {
          ExecBuffPhysicalDefenseUp(player, player, 9, 0.50f);
        }
        else if (player.IsPhysicalDefenseUp.EffectValue <= 0.50f)
        {
          ExecBuffPhysicalDefenseUp(player, player, 9, 0.60f);
        }
        else if (player.IsPhysicalDefenseUp.EffectValue <= 0.60f)
        {
          ExecBuffPhysicalDefenseUp(player, player, 9, 0.70f);
        }
        else if (player.IsPhysicalDefenseUp.EffectValue <= 0.70f)
        {
          ExecBuffPhysicalDefenseUp(player, player, 9, 0.80f);
        }
        else if (player.IsPhysicalDefenseUp.EffectValue <= 0.80f)
        {
          ExecBuffPhysicalDefenseUp(player, player, 9, 0.90f);
        }
        else
        {
          ExecBuffPhysicalDefenseUp(player, player, 9, 1.00f);
        }

        if (player.IsBattleSpeedUp == false)
        {
          ExecBuffBattleSpeedUp(player, player, 9, 0.20f);
        }
        else if (player.IsBattleSpeedUp.EffectValue <= 0.20f)
        {
          ExecBuffBattleSpeedUp(player, player, 9, 0.30f);
        }
        else if (player.IsBattleSpeedUp.EffectValue <= 0.30f)
        {
          ExecBuffBattleSpeedUp(player, player, 9, 0.40f);
        }
        else if (player.IsBattleSpeedUp.EffectValue <= 0.40f)
        {
          ExecBuffBattleSpeedUp(player, player, 9, 0.50f);
        }
        else if (player.IsBattleSpeedUp.EffectValue <= 0.50f)
        {
          ExecBuffBattleSpeedUp(player, player, 9, 0.60f);
        }
        else if (player.IsBattleSpeedUp.EffectValue <= 0.60f)
        {
          ExecBuffBattleSpeedUp(player, player, 9, 0.70f);
        }
        else if (player.IsBattleSpeedUp.EffectValue <= 0.70f)
        {
          ExecBuffBattleSpeedUp(player, player, 9, 0.80f);
        }
        else if (player.IsBattleSpeedUp.EffectValue <= 0.80f)
        {
          ExecBuffBattleSpeedUp(player, player, 9, 0.90f);
        }
        else
        {
          ExecBuffBattleSpeedUp(player, player, 9, 1.00f);
        }
        break;

      case Fix.COMMAND_BERSERKER_RUSH:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < 8; ii++)
        {
          currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
          if (ExecNormalAttack(player, currentTarget, 0.50f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical))
          {
            if (currentTarget.IsSlip == false)
            {
              ExecBuffSlip(player, currentTarget, 5, 18000 + AP.Math.RandomInteger(2000));
            }
            else if (currentTarget.IsPoison == false)
            {
              ExecBuffPoison(player, currentTarget, 5, 18000 + AP.Math.RandomInteger(2000));
            }
            else if (currentTarget.IsStun == false)
            {
              ExecBuffStun(player, currentTarget, 3, 0);
            }
            else if (currentTarget.IsParalyze == false)
            {
              ExecBuffParalyze(player, currentTarget, 5, 0);
            }
            else if (currentTarget.IsBind == false)
            {
              ExecBuffBind(player, currentTarget, 5, 0);
            }
            else if (currentTarget.IsSilent == false)
            {
              ExecBuffSilent(player, currentTarget, 5, 0);
            }
          }
        }
        break;

      case Fix.COMMAND_GOLDEN_MATRIX:
        AbstractAddBuff(player, player.objFieldPanel, Fix.GOLDEN_MATRIX, Fix.COMMAND_GOLDEN_MATRIX, Fix.INFINITY, 3, 0, 0);
        break;

      case Fix.COMMAND_METSU_INCARNATION:
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.DefenseValue, critical);
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.DefenseValue, critical);
        ExecBuffCannotResurrect(player, target, Fix.INFINITY, 0);
        break;

      case Fix.COMMAND_THOUSAND_SQUALL:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.None, critical);
          rand = AP.Math.RandomInteger(5);
          if (rand == 0)
          {
            ExecBuffPoison(player, target_list[ii], 5, 18500 + AP.Math.RandomInteger(2500));
          }
          else if (rand == 1)
          {
            ExecBuffSlip(player, target_list[ii], 5, 18500 + AP.Math.RandomInteger(2500));
          }
          else if (rand == 2)
          {
            ExecBuffSilent(player, target_list[ii], 5, 0);
          }
          else if (rand == 3)
          {
            ExecBuffBind(player, target_list[ii], 5, 0);
          }
          else if (rand == 4)
          {
            ExecBuffParalyze(player, target_list[ii], 5, 0);
          }
        }
        break;

      case Fix.COMMAND_AURORA_BLADE:
        BuffUpIce(player, player, 9, 1.50f);
        BuffUpLight(player, player, 9, 1.50f);
        break;

      case Fix.COMMAND_MEGIDO_BLAZE:
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.DefenseValue, critical);
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.DefenseValue, critical);
        break;

      case Fix.COMMAND_ABYSS_WILL:
        UpdateMessage(player.FullName + "：アビスは存在にあらず、意志そのもの。アビスとは理そのもの。\r\n");
        if (player.CurrentManaPoint < Fix.COST_ABYSS_WILL)
        {
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MANAPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        else
        {
          player.CurrentManaPoint -= Fix.COST_ABYSS_WILL;
          player.UpdateManaPoint();
          for (int ii = 0; ii < AllList.Count; ii++)
          {
            AbstractAddBuff(AllList[ii], AllList[ii].objBuffPanel, Fix.ABYSS_WILL, Fix.BUFF_ABYSS_WILL, Fix.INFINITY, 1, 0, 0);
          }
        }
        break;

      case Fix.COMMAND_ONE_HOMURA:
        UpdateMessage(player.FullName + "：永久の浄化印、焔の理を知るがよい。\r\n");
        if (player.CurrentManaPoint < Fix.COST_ICHINARU_HOMURA)
        {
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MANAPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        else
        {
          player.CurrentManaPoint -= Fix.COST_ICHINARU_HOMURA;
          player.UpdateManaPoint();
          AbstractAddBuff(target, target.objBuffPanel, Fix.ICHINARU_HOMURA, Fix.BUFF_ICHINARU_HOMURA, Fix.INFINITY, PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence), 0, 0);
        }
        break;

      case Fix.COMMAND_ABYSS_FIRE:
        UpdateMessage(player.FullName + "：深淵の呪怨印、アビスの理を知るがよい。\r\n");
        if (player.CurrentManaPoint < Fix.COST_ABYSS_FIRE)
        {
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MANAPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        else
        {
          player.CurrentManaPoint -= Fix.COST_ABYSS_FIRE;
          player.UpdateManaPoint();
          AbstractAddBuff(target, target.objBuffPanel, Fix.ABYSS_FIRE, Fix.COMMAND_ABYSS_FIRE, Fix.INFINITY, PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence), 0, 0);
        }
        break;

      case Fix.COMMAND_ETERNAL_DROPLET:
        UpdateMessage(player.FullName + "：理に制約など存在しない。理は永遠そのものである。\r\n");
        if (player.CurrentManaPoint < Fix.COST_ETERNAL_DROPLET)
        {
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MANAPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        else
        {
          player.CurrentManaPoint -= Fix.COST_ETERNAL_DROPLET;
          player.UpdateManaPoint();
          AbstractAddBuff(player, player.objBuffPanel, Fix.ETERNAL_DROPLET, Fix.COMMAND_ETERNAL_DROPLET, 4, 0, 0, 0);
        }
        break;

      case Fix.COMMAND_AUSTERITY_MATRIX_OMEGA:
        UpdateMessage(player.FullName + "：厳粛なる支配の理を受け止めるがよい。\r\n");
        if (player.CurrentManaPoint < Fix.COST_AUSTERITY_MATRIX_OMEGA)
        {
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MANAPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        else
        {
          player.CurrentManaPoint -= Fix.COST_AUSTERITY_MATRIX_OMEGA;
          player.UpdateManaPoint();
          for (int ii = 0; ii < AllList.Count; ii++)
          {
            AllList[ii].objBuffPanel.RemovePositiveBuffAll();
            AbstractAddBuff(AllList[ii], AllList[ii].objBuffPanel, Fix.AUSTERITY_MATRIX_OMEGA, Fix.BUFF_AUSTERITY_MATRIX_OMEGA, 3, 0, 0, 0);
          }
        }
        break;

      case Fix.COMMAND_VOICE_OF_ABYSS:
        UpdateMessage(player.FullName + "：深淵からの呼び声は、真実の理、コレを受け止めよ。\r\n");
        if (player.CurrentManaPoint < Fix.COST_VOICE_OF_ABYSS)
        {
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MANAPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        else
        {
          player.CurrentManaPoint -= Fix.COST_VOICE_OF_ABYSS;
          player.UpdateManaPoint();
          target_list = GetOpponentGroupAlive(player);
          // 【警告】敵だけ対象外なのは卑怯かもしれないので、要調整となる。
          //SetupEnemyGroup(ref group);
          for (int ii = 0; ii < target_list.Count; ii++)
          {
            AbstractAddBuff(target_list[ii], target_list[ii].objBuffPanel, Fix.VOICE_OF_ABYSS, Fix.BUFF_VOICE_OF_ABYSS, 2, 0, 0, 0);
          }
        }
        break;

      case Fix.COMMAND_VOID_BEAT:
        UpdateMessage(player.FullName + "：全て実像は等しく虚構である。虚無の理を受け入れよ。\r\n");
        if (player.CurrentManaPoint < Fix.COST_THE_ABYSS_WALL)
        {
          StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MANAPOINT_LESS, Fix.COLOR_NORMAL);
          return;
        }
        else
        {
          player.CurrentManaPoint -= Fix.COST_THE_ABYSS_WALL;
          player.UpdateManaPoint();
          for (int ii = 0; ii < AllList.Count; ii++)
          {
            ExecLifeDownCurrent(AllList[ii], 0.5f);
          }
        }
        break;

      case Fix.COMMAND_RENGEKI:
        UpdateMessage(player.FullName + "：食らえ、我が連・撃を！\r\n");
        for (int ii = 0; ii < 3; ii++)
        {
          ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        }
        break;

      case Fix.COMMAND_PERFECT_PROPHECY:
        UpdateMessage(player.FullName + "：貴公の動き。既に我の手中にあり。\r\n");
        AbstractAddBuff(player, player.objBuffPanel, Fix.PERFECT_PROPHECY, Fix.COMMAND_PERFECT_PROPHECY, Fix.INFINITY, 0, 0, 0);
        break;

      case Fix.COMMAND_HOLY_WISDOM:
        UpdateMessage(player.FullName + "：永久なる加護。ホーリー・ウィズダム！\r\n");
        AbstractAddBuff(player, player.objFieldPanel, Fix.HOLY_WISDOM, Fix.BUFF_HOLY_WISDOM_JP, Fix.INFINITY, 10, SecondaryLogic.HolyWisdom_Effect(player), 0);
        break;

      case Fix.COMMAND_ETERNAL_PRESENCE:
        UpdateMessage(player.FullName + "我が信念が揺らぐ事はない。エターナル・プリゼンス！！！：\r\n");
        player.objBuffPanel.RemoveNegativeBuffAll();
        AbstractAddBuff(player, player.objBuffPanel, Fix.ETERNAL_PRESENCE, Fix.COMMAND_ETERNAL_PRESENCE, SecondaryLogic.EternalPresence_Turn(player), SecondaryLogic.EternalPresence_Effect(player), SecondaryLogic.EternalPresence_Effect2(player), 0);
        break;

      case Fix.COMMAND_ULTIMATE_FLARE:
        UpdateMessage(player.FullName + "：究極奥義、受けてみよ。天啓・アルティメット・フレア！！！！！\r\n");
        if (ExecMagicAttack(player, target, 5.00f, Fix.DamageSource.Fire, Fix.IgnoreType.Both, critical))
        {
          AbstractAddBuff(target, target.objBuffPanel, Fix.ULTIMATE_FLARE, Fix.BUFF_SUN_MARK_JP, SecondaryLogic.UltimateFlare_Turn(player), 0, 0, 0); 
        }
        break;

      case Fix.COMMAND_GOUGEKI:
        UpdateMessage(player.FullName + "：我が剛・撃。受け止められまい！\r\n");
        if (ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.Both, critical))
        {
          target.UseInstantPoint(true, Fix.COMMAND_GOUGEKI);
          target.UpdateInstantPointGauge();
        }
        break;

      case Fix.COMMAND_BUTOH_ISSEN:
        AbstractCounterStackCommand(player, command_name, GroupStackInTheCommand.GetComponentsInChildren<StackObject>());
        break;

      case Fix.COMMAND_GOD_SENSE:
        ExecGodSense(player);
        break;

      case Fix.COMMAND_TIME_JUMP:
        AnimationSandGlass();
        UpdateTurnEnd();
        UpkeepStep();
        break;

      case Fix.COMMAND_STARSWORD_ZETSUKEN:
        AbstractAddBuff(player, player.groupTimeSequencePanel, Fix.STARSWORD_ZETSUKEN, Fix.COMMAND_STARSWORD_ZETSUKEN, SecondaryLogic.Starsword_Zetsuken_Turn(player), 0, 0, 0);
        break;

      case Fix.COMMAND_STARSWORD_REIKUU:
        AbstractAddBuff(player, player.groupTimeSequencePanel, Fix.STARSWORD_REIKUU, Fix.COMMAND_STARSWORD_REIKUU, SecondaryLogic.Starsword_Reikuu(player), 0, 0, 0);
        break;

      case Fix.COMMAND_STARSWORD_SEIEI:
        AbstractAddBuff(player, player.groupTimeSequencePanel, Fix.STARSWORD_SEIEI, Fix.COMMAND_STARSWORD_SEIEI, SecondaryLogic.Starsword_Seiei_Turn(player), 1, 0, 0);
        break;

      case Fix.COMMAND_STARSWORD_RYOKUEI:
        AbstractAddBuff(player, player.groupTimeSequencePanel, Fix.STARSWORD_RYOKUEI, Fix.COMMAND_STARSWORD_RYOKUEI, SecondaryLogic.Starsword_Ryokuei_Turn(player), 0, 0, 0);
        break;

      case Fix.COMMAND_STARSWORD_FINALITY:
        AbstractAddBuff(player, player.groupTimeSequencePanel, Fix.STARSWORD_FINALITY, Fix.COMMAND_STARSWORD_FINALITY, SecondaryLogic.Starsword_Finality_Turn(player), 0, 0, 0);
        break;

      case Fix.COMMAND_HEAVEN_CLEANSING_FIRE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Fire, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Random);
        }
        break;

      case Fix.COMMAND_SAINT_VOICE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffFear(player, target_list[ii], 2, 0);
          ExecBuffStun(player, target_list[ii], 2, 0);
          ExecBuffSilent(player, target_list[ii], 2, 0);
          ExecBuffParalyze(player, target_list[ii], 2, 0);
        }
        break;

      case Fix.COMMAND_BRILLIANT_LIFE:
        ExecLifeGain(player, player, player.MaxLife / 20.0f);
        ExecBuffMagicAttackUp(player, player, 9, 0.50f);
        ExecBuffBattleSpeedUp(player, player, 9, 0.50f);
        break;

      case Fix.COMMAND_BEZIER_TAIL_ATTACK:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecNormalAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Random);
        }
        break;

      case Fix.COMMAND_MURYO_YATSU_ON:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffBind(player, target_list[ii], 2, 0);
          ExecBuffFreeze(player, target_list[ii], 2, 0);
          ExecBuffSlip(player, target_list[ii], 2, 15000);
          ExecBuffPoison(player, target_list[ii], 2, 15000);
        }
        break;

      case Fix.COMMAND_WORD_OF_ONE:
        target_list = GetOpponentGroupAlive(player);
        ExecLifeOne(target_list[AP.Math.RandomInteger(target_list.Count)]);
        break;

      case Fix.COMMAND_DEATH_VOICE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecBuffFear(player, target_list[ii], 2, 0);
          ExecBuffFreeze(player, target_list[ii], 2, 0);
          ExecBuffBind(player, target_list[ii], 2, 0);
          ExecBuffSlip(player, target_list[ii], 2, 15000);
        }
        break;

      case Fix.COMMAND_IKOROSHI:
        target_list = GetOpponentGroupAlive(player);
        currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
        ExecLifeDown(currentTarget, 1.00f);
        break;

      case Fix.COMMAND_MEIFU_CONTACT:
        target_list = GetOpponentGroupAlive(player);
        currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
        ExecBuffPhysicalAttackDown(player, currentTarget, 3, 0.40f);
        ExecBuffMagicAttackDown(player, currentTarget, 3, 0.40f);
        ExecBuffBattlePotentialDown(player, currentTarget, 3, 0.40f);
        break;

      case Fix.COMMAND_SAINT_JUDGE:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.HolyLight, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Random);
        }
        break;

      case Fix.COMMAND_ANNEI_FUKUIN:
        target_list = GetOpponentGroupAlive(player);
        currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
        ExecBuffBattleSpeedDown(player, currentTarget, 3, 0.40f);
        ExecBuffBattleResponseDown(player, currentTarget, 3, 0.40f);
        ExecBuffBattlePotentialDown(player, currentTarget, 3, 0.40f);
        break;

      case Fix.COMMAND_LIFE_STREAMING:
        ExecLifeGain(player, player, player.MaxLife * 0.05f);
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecLifeDownCurrent(target_list[ii], 0.90f);
        }
        break;

      case Fix.COMMAND_GODWING_CLAW:
        target_list = GetOpponentGroupAlive(player);
        ExecNormalAttack(player, target_list[AP.Math.RandomInteger(target_list.Count)], 3.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Random);
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.Colorless, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Random);
        break;

      case Fix.COMMAND_GOD_BREATH:
        target_list = GetOpponentGroupAlive(player);
        currentTarget = target_list[AP.Math.RandomInteger(target_list.Count)];
        ExecBuffPhysicalAttackDown(player, currentTarget, 3, 0.40f);
        ExecBuffMagicAttackDown(player, currentTarget, 3, 0.40f);
        ExecBuffBind(player, currentTarget, 2, 0);
        ExecBuffSilent(player, currentTarget, 2, 0);
        ExecBuffParalyze(player, currentTarget, 2, 0);
        ExecBuffFreeze(player, currentTarget, 2, 0);
        ExecBuffCannotResurrect(player, currentTarget, 2, 0);
        break;

      case Fix.COMMAND_IRU_MEGIDO_BLAZE:
        ExecMagicAttack(player, target, 3.00f, Fix.DamageSource.Fire, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Random);
        break;

      case Fix.COMMAND_GROUND_BREAKING:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecNormalAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Random);
          ExecBuffStun(player, target_list[ii], 2, 0);
          ExecBuffPhysicalAttackDown(player, target_list[ii], 3, 0.40f);
          ExecBuffPhysicalDefenseDown(player, target_list[ii], 3, 0.40f);
        }
        break;

      case Fix.COMMAND_COSMO_BURN:
        ExecMagicAttack(player, target, 3.00f, Fix.DamageSource.Physical, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Random);
        ExecBuffBattlePotentialUp(player, player, 3, 0.50f);
        break;

      case Fix.COMMAND_REIJU_FALLTHUNDER:
        target_list = GetOpponentGroupAlive(player);
        for (int ii = 0; ii < target_list.Count; ii++)
        {
          ExecMagicAttack(player, target_list[ii], 1.00f, Fix.DamageSource.Ice, Fix.IgnoreType.DefenseMode, Fix.CriticalType.Random);
          ExecBuffSilent(player, target_list[ii], 2, 0);
          ExecBuffParalyze(player, target_list[ii], 2, 0);
          ExecBuffSlow(player, target_list[ii], 5, 0);
          ExecBuffBattleSpeedDown(player, target_list[ii], 5, 0.40f);
        }
        break;

      case Fix.COMMAND_SHADOW_BRINGER:
        ExecNormalAttack(player, target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
        ExecMagicAttack(player, target, 1.00f, Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical);
        AbstractAddBuff(target, target.objBuffPanel, Fix.SHADOW_BRINGER, Fix.BUFF_SHADOW_BRINGER, SecondaryLogic.ShadowBringer_Turn(player), SecondaryLogic.ShadowBringer_Effect(player), 0, 0);
        break;

      case Fix.COMMAND_SPHERE_OF_GLORY:
        ExecLifeGain(player, player, player.MaxLife / 100.0f + AP.Math.RandomInteger(100000));
        AbstractAddBuff(player, player.objBuffPanel, Fix.SPHERE_OF_GLORY, Fix.BUFF_SPHERE_OF_GLORY, SecondaryLogic.SphereOfGlory_Turn(player), SecondaryLogic.SphereOfGlory_Effect(player), 0, 0);
        break;

      case Fix.COMMAND_AURORA_PUNISHMENT:
        AbstractAddBuff(player, player.objFieldPanel, Fix.AURORA_PUNISHMENT, Fix.BUFF_AURORA_PUNISHMENT, SecondaryLogic.AuroraPunishment_Turn(player), SecondaryLogic.AuroraPunishment_Effect(player), 0, 0);
        AbstractAddBuff(target, target.objFieldPanel, Fix.AURORA_PUNISHMENT, Fix.BUFF_AURORA_PUNISHMENT, SecondaryLogic.AuroraPunishment_Turn(player), SecondaryLogic.AuroraPunishment_Effect(player), 0, 0);
        break;

      case Fix.COMMAND_INNOCENT_CIRCLE:
        AbstractGainManaPoint(player, player, player.MaxManaPoint * SecondaryLogic.InnocentCircle_Effect(player));
        AbstractGainSkillPoint(player, player, player.MaxSkillPoint * SecondaryLogic.InnocentCircle_Effect(player));
        AbstractAddBuff(player, player.objBuffPanel, Fix.INNOCENT_CIRCLE, Fix.BUFF_INNOCENT_CIRCLE, SecondaryLogic.InnocentCircle_Turn(player), SecondaryLogic.InnocentCircle_Effect(player), 0, 0);
        break;

      case Fix.COMMAND_ATOMIC_THE_INFINITY_NOVA:
        ExecMagicAttack(player, target, 7.0f, Fix.DamageSource.Colorless, Fix.IgnoreType.Both, critical);
        break;

      case Fix.COMMAND_ABSOLUTE_PERFECTION:
        AbstractAddBuff(player, player.objBuffPanel, Fix.ABSOLUTE_PERFECTION, Fix.BUFF_ABSOLUTE_PERFECTION, SecondaryLogic.AbsolutePerfection_Turn(player), 0, 0, 0);
        break;

      case Fix.COMMAND_ASTRAL_GATE:
        AbstractAddBuff(player, player.objFieldPanel, Fix.ASTRAL_GATE, Fix.BUFF_ASTRAL_GATE, SecondaryLogic.AstralGate_Turn(player), 0, 0, 0);
        AbstractAddBuff(target, target.objFieldPanel, Fix.ASTRAL_GATE, Fix.BUFF_ASTRAL_GATE, SecondaryLogic.AstralGate_Turn(player), 0, 0, 0);
        break;

      case Fix.COMMAND_DOUBLE_STANCE:
        AbstractCounterStackCommand(player, command_name, GroupStackInTheCommand.GetComponentsInChildren<StackObject>());
        AbstractAddBuff(player, player.objBuffPanel, Fix.DOUBLE_STANCE, Fix.COMMAND_DOUBLE_STANCE, SecondaryLogic.DoubleStance_Turn(player), 0, 0, 0);
        break;

      case Fix.COMMAND_DESTRUCTION_OF_TRUTH:
        StackObject[] stackList = GroupStackInTheCommand.GetComponentsInChildren<StackObject>();
        CreateStackObject(player, target, Fix.EFFECT_STACK_END, 0, Fix.STACKCOMMAND_SUDDEN_TIMER);
        for (int ii = 0; ii < stackList.Length; ii++)
        {
          Destroy(stackList[ii]);
          stackList[ii] = null;
        }
        break;

      case Fix.COMMAND_CHAOTIC_SCHEMA:
        AbstractAddBuff(player, player.objBuffPanel, Fix.CHAOTIC_SCHEMA, Fix.BUFF_CHAOTIC_SCHEMA, SecondaryLogic.ChaoticSchema_Turn(player), 0, 0, 0);
        player.BattleGaugeArrow2 = 30.0f;
        player.objArrow2.SetActive(true);
        break;

      case Fix.COMMAND_OATH_OF_SEFINE:
        AbstractAddBuff(player, player.objBuffPanel, Fix.OATH_OF_SEFINE, Fix.BUFF_OATH_OF_SEFINE, SecondaryLogic.OathOfSefine_Turn(player), 0, 0, 0);
        player.AlreadyOathOfSefine = true;
        break;

      case Fix.COMMAND_SPACETIME_INFLUENCE:
        if (player.CurrentTimeStopValue <= 0) // 強力無比な魔法のため、継続ターンの連続更新は出来なくしている。
        {
          player.CurrentTimeStopValue = (int)(SecondaryLogic.SpacetimeInfluence_Effect(player));
          AbstractAddBuff(player, player.objBuffPanel, Fix.SPACETIME_INFLUENCE, Fix.BUFF_SPACETIME_INFLUENCE, SecondaryLogic.SpacetimeInfluence_Turn(player), SecondaryLogic.SpacetimeInfluence_Effect(player), 0, 0);
        }
        break;

      case "絶望の魔手":
        //ExecBuffPoison(player, target, 10, 11);
        //ExecBuffSilent(player, target, 10, 0);
        //ExecBuffBind(player, target, 10, 0);
        //ExecBuffSleep(player, target, 10, 0);
        //ExecBuffStun(player, target, 10, 0);
        //ExecBuffParalyze(player, target, 10, 1);
        //ExecBuffFreeze(player, target, 10, 0);
        //ExecBuffFear(player, target, 10, 0);
        //ExecBuffSlow(player, target, 10, 0.5f);
        //ExecBuffDizzy(player, target, 10, 1);
        //ExecBuffSlip(player, target, 10, 12);
        //ExecBuffCannotResurrect(player, target, 10, 0);
        //ExecBuffNoGainLife(player, target, 10, 0);
        ExecBuffPhysicalAttackDown(player, target, Fix.INFINITY, 0.95f);
        ExecBuffPhysicalDefenseDown(player, target, Fix.INFINITY, 0.95f);
        ExecBuffMagicAttackDown(player, target, Fix.INFINITY, 0.95f);
        ExecBuffMagicDefenseDown(player, target, Fix.INFINITY, 0.95f);
        ExecBuffBattleSpeedDown(player, target, Fix.INFINITY, 0.95f);
        ExecBuffBattleResponseDown(player, target, Fix.INFINITY, 0.95f);
        ExecBuffBattlePotentialDown(player, target, Fix.INFINITY, 0.95f);
        break;

      case "麻痺付与":
        ExecBuffParalyze(player, target, 2, 0);
        ExecBuffParalyze(player, player, 2, 0);
        break;

      case "凍結付与":
        ExecBuffFreeze(player, target, 2, 0);
        ExecBuffFreeze(player, player, 2, 0);
        break;

      case "恐怖付与":
        ExecBuffFear(player, target, 3, 0);
        ExecBuffFear(player, player, 3, 0);
        break;

      case "鈍足付与":
        ExecBuffSlow(player, target, 3, 0.10f);
        ExecBuffSlow(player, player, 3, 0.10f);
        break;

      case "眩暈付与":
        ExecBuffDizzy(player, target, 3, 0.50f);
        ExecBuffDizzy(player, player, 3, 0.50f);
        break;

      case "出血付与":
        ExecBuffSlip(player, target, 3, 1000.0f);
        ExecBuffSlip(player, player, 3, 1000.0f);
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

  private List<Character> GetAllyGroupAlive(Character player)
  {
    List<Character> list = new List<Character>();
    if (player.Ally == Fix.Ally.Ally)
    {
      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        if (PlayerList[ii].Dead == false)
        {
          list.Add(PlayerList[ii]);
        }
      }
      return list;
    }
    //else if (player.Ally == Fix.Ally.Enemy)
    else
    {
      for (int ii = 0; ii < EnemyList.Count; ii++)
      {
        if (EnemyList[ii].Dead == false)
        {
          list.Add(EnemyList[ii]);
        }
      }
      return list;
    }
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

  private List<Character> GetOpponentGroupAlive(Character player)
  {
    List<Character> list = new List<Character>();
    if (player.Ally == Fix.Ally.Ally)
    {
      for (int ii = 0; ii < EnemyList.Count; ii++)
      {
        if (EnemyList[ii].Dead == false)
        {
          list.Add(EnemyList[ii]);
        }
      }
      return list;
    }
    //else if (player.Ally == Fix.Ally.Enemy)
    else
    {
      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        if (PlayerList[ii].Dead == false)
        {
          list.Add(PlayerList[ii]);
        }
      }
      return list;
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

  private void AnimationSandGlass()
  {
    this.nowAnimationSandGlassCounter = 0;
    this.nowAnimationSandGlass = true;
  }

  float angle = 0.0f;
  private void ExecAnimationSandGlass()
  {
    Text targetLabel = this.SandGlassText;

    if (this.nowAnimationSandGlassCounter <= 0)
    {
      back_Sandglass.gameObject.SetActive(true);
      targetLabel.text = (this.BattleTurnCount - 1).ToString();
      targetLabel.gameObject.SetActive(true);
      SandGlassImage.sprite = Resources.Load<Sprite>("AnimeSandGlass0");
      SandGlassImage.gameObject.SetActive(true);
    }

    int waitTime = 52;
    int startTime = 15;
    int moveLen = (Screen.width - 150) / 36;

    if (this.nowAnimationSandGlassCounter > startTime)
    {
      if (Application.platform == RuntimePlatform.Android ||
          Application.platform == RuntimePlatform.IPhonePlayer)
      {
        // 何もしない
      }
      else
      {
        System.Threading.Thread.Sleep(0);
      }
      //SandGlassImage.sprite = Resources.Load<Sprite>("AnimeSandGlass" + (this.nowAnimationSandGlassCounter-(startTime+1)).ToString());
      angle += 10;
      SandGlassImage.transform.rotation = Quaternion.Euler(0, 0, angle);
      SandGlassImage.transform.position = new Vector3(SandGlassImage.transform.position.x + moveLen, SandGlassImage.transform.position.y, SandGlassImage.transform.position.z);

      if (this.nowAnimationSandGlassCounter == 36)
      {
        targetLabel.text = this.BattleTurnCount.ToString();
      }
    }

    this.nowAnimationSandGlassCounter++;

    if (this.nowAnimationSandGlassCounter > waitTime)
    {
      System.Threading.Thread.Sleep(500);
      this.angle = 0.0f;
      SandGlassImage.transform.rotation = new Quaternion(0, 0, 0, 0);
      SandGlassImage.transform.position = new Vector3(SandGlassImage.transform.position.x - moveLen * (waitTime - startTime), SandGlassImage.transform.position.y, SandGlassImage.transform.position.z);
      back_Sandglass.gameObject.SetActive(false);
      targetLabel.gameObject.SetActive(false);
      SandGlassImage.gameObject.SetActive(false);
      this.nowAnimationSandGlass = false;
      this.nowAnimationSandGlassCounter = 0;
    }
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
        int factor1 = MAX_ANIMATION_TIME - 15;
        int factor2 = MAX_ANIMATION_TIME - 10;
        int factor3 = MAX_ANIMATION_TIME - 5;
        float speed1 = 0.0f;
        float speed2 = 1.0f;
        float speed3 = 2.0f;
        float speed4 = 7.0f;

        if (damageObj[ii].MaxTime == ANIMATION_TIME_HALF)
        {
          factor1 = 12;
          factor2 = 15;
          factor3 = 25;
          speed2 = 1.0f;
          speed3 = 2.0f;
          speed4 = 7.0f;
        }
        else if (damageObj[ii].MaxTime == ANIMATION_TIME_SHORT)
        {
          factor1 = 4;
          factor2 = 6;
          factor3 = 8;
          speed2 = 2.0f;
          speed3 = 4.0f;
          speed4 = 9.0f;
        }
        if (damageObj[ii].Timer <= factor1) { moveX = speed1; }
        else if (damageObj[ii].Timer <= factor2) { moveX = speed2; }
        else if (damageObj[ii].Timer <= factor3) { moveX = speed3; }
        else { moveX = speed4; }

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

    // Suddenタイマーによるスタック解決を表示。スタック制御は一旦停止。
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

    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (AllList[ii].IsFutureVision)
      {
        string currentStackName = stackList[stackList.Length - 1].StackName;
        Character player = stackList[stackList.Length - 1].Player;
        Character target = stackList[stackList.Length - 1].Target;

        if ((player.IsEnemy && AllList[ii].IsEnemy == false) ||
            (player.IsEnemy == false && AllList[ii].IsEnemy))
        {
          // FutureVisionはスタック解決中に解消とする。
          // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveTargetBuffを介さない。
          AllList[ii].RemoveTargetBuff(Fix.FUTURE_VISION);

          // 現在のスタックを破棄する。
          Destroy(stackList[stackList.Length - 1].gameObject);
          stackList[stackList.Length - 1] = null;
          CreateStackObject(player, target, currentStackName + " 失敗！（要因：フューチャー・ヴィジョン）", 0, Fix.STACKCOMMAND_SUDDEN_TIMER);
        }
      }

      if (AllList[ii].IsStarswordReikuu)
      {
        string currentStackName = stackList[stackList.Length - 1].StackName;
        Character player = stackList[stackList.Length - 1].Player;
        Character target = stackList[stackList.Length - 1].Target;

        if ((player.IsEnemy && AllList[ii].IsEnemy == false) ||
            (player.IsEnemy == false && AllList[ii].IsEnemy))
        {
          // スターソード「零空」はスタック解決中に解消とする。
          // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveTargetBuffを介さない。
          AllList[ii].RemoveTargetBuffFromTimeSequence(Fix.STARSWORD_REIKUU);

          BuffImage seiei = AllList[ii].IsStarswordSeiei;
          if (seiei)
          {
            Debug.Log("starswordSeiei additional damage 3 " + seiei.Cumulative);
            ExecMagicAttack(AllList[ii], AllList[ii].Target, (1.00f + seiei.Cumulative * 0.50f), Fix.DamageSource.HolyLight, Fix.IgnoreType.None, Fix.CriticalType.Random);
          }
          // 現在のスタックを破棄する。
          Destroy(stackList[stackList.Length - 1].gameObject);
          stackList[stackList.Length - 1] = null;
          CreateStackObject(player, target, currentStackName + " 失敗！（要因：" + Fix.COMMAND_STARSWORD_REIKUU + "）", 0, Fix.STACKCOMMAND_SUDDEN_TIMER);
          return;
        }
      }

      if (AllList[ii].IsPerfectProphecy)
      {
        string currentStackName = stackList[stackList.Length - 1].StackName;
        Character player = stackList[stackList.Length - 1].Player;
        Character target = stackList[stackList.Length - 1].Target;

        if ((player.IsEnemy && AllList[ii].IsEnemy == false) ||
            (player.IsEnemy == false && AllList[ii].IsEnemy))
        {
          // PerfectProphecyはスタック解決中に解消とする。
          // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveTargetBuffを介さない。
          AllList[ii].RemoveTargetBuff(Fix.PERFECT_PROPHECY);

          BuffImage seiei = AllList[ii].IsStarswordSeiei;
          if (seiei)
          {
            Debug.Log("starswordSeiei additional damage 3 " + seiei.Cumulative);
            ExecMagicAttack(AllList[ii], AllList[ii].Target, (1.00f + seiei.Cumulative * 0.50f), Fix.DamageSource.HolyLight, Fix.IgnoreType.None, Fix.CriticalType.Random);
          }
          // 現在のスタックを破棄する。
          Destroy(stackList[stackList.Length - 1].gameObject);
          stackList[stackList.Length - 1] = null;
          CreateStackObject(player, target, currentStackName + " 失敗！（要因：完全なる予見）", 0, Fix.STACKCOMMAND_SUDDEN_TIMER);
          return;
        }
      }

      if (AllList[ii].IsStanceOfTheIai)
      {
        string currentStackName = stackList[stackList.Length - 1].StackName;
        Character player = stackList[stackList.Length - 1].Player;
        Character target = stackList[stackList.Length - 1].Target;

        if ((player.IsEnemy && AllList[ii].IsEnemy == false && ActionCommand.IsDamage(stackList[stackList.Length - 1].StackName)) ||
            (player.IsEnemy == false && AllList[ii].IsEnemy && ActionCommand.IsDamage(stackList[stackList.Length - 1].StackName)))
        {
          ExecNormalAttack(target, player, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Absolute);
          // StanceoftheIaiはスタック解決中に解消とする。
          // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveTargetBuffを介さない。
          AllList[ii].RemoveTargetBuff(Fix.STANCE_OF_THE_IAI);

          // 現在のスタックを破棄する。
          Destroy(stackList[stackList.Length - 1].gameObject);
          stackList[stackList.Length - 1] = null;
          CreateStackObject(player, target, currentStackName + " 失敗！（要因：スタンス・オブ・ザ・イアイ）", 0, Fix.STACKCOMMAND_SUDDEN_TIMER);
          return;
        }
      }
    }
    // フロスト・ランス効果がある場合、インスタントはカウンターされる。
    // todo ただし、例外で無効化してくる効果も考えられるため、後にロジック改版。
    BuffImage frostLance = stackList[num].Player?.IsFrostLance ?? null;
    BuffImage counterDisallow = stackList[num].Player?.IsCounterDisallow ?? null;
    if (frostLance != null || counterDisallow != null)
    {
      Debug.Log("ExecStackInTheCommand counter phase length: " + stackList.Length + " " + stackList[stackList.Length - 1].StackName);
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

    // 敵専用、スタックコマンドの割り込み
    for (int ii = 0; ii < EnemyList.Count; ii++)
    {
      #region "デュエルプレイヤー１"
      if (EnemyList[ii].FullName == Fix.DUEL_PLAYER_1 || EnemyList[ii].FullName == Fix.DUEL_PLAYER_1_JP)
      {
        if (stackList[num].StackTimer <= 100)
        {
          int maxInstantPoint = EnemyList[ii].MaxInstantPoint;
          if (EnemyList[ii].CurrentInstantPoint >= maxInstantPoint)
          {
            EnemyList[ii].UseInstantPoint(false, Fix.COUNTER_ATTACK);
            EnemyList[ii].UpdateInstantPointGauge();
            CreateStackObject(EnemyList[ii], stackList[num].Player, Fix.COUNTER_ATTACK, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return;
          }
        }
      }
      #endregion
      #region "レネ・コルトス"
      if (EnemyList[ii].FullName == Fix.DUEL_LENE_COLTOS || EnemyList[ii].FullName == Fix.DUEL_LENE_COLTOS_JP)
      {
        if (stackList[num].StackTimer <= 100)
        {
          int maxInstantPoint = EnemyList[ii].MaxInstantPoint;
          if (EnemyList[ii].CurrentInstantPoint >= maxInstantPoint * ActionCommand.InstantGaugeCost(Fix.COUNTER_DISALLOW))
          {
            EnemyList[ii].UseInstantPoint(false, Fix.COUNTER_DISALLOW);
            EnemyList[ii].UpdateInstantPointGauge();
            CreateStackObject(EnemyList[ii], stackList[num].Player, Fix.COUNTER_DISALLOW, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return;
          }
        }
      }
      #endregion
      #region "セルモイ・ロウ"
      if (EnemyList[ii].FullName == Fix.DUEL_SELMOI_RO)
      {
        if (stackList[num].StackTimer <= 100)
        {
          int maxInstantPoint = EnemyList[ii].MaxInstantPoint;
          if (EnemyList[ii].CurrentInstantPoint >= maxInstantPoint)
          {
            EnemyList[ii].UseInstantPoint(false, Fix.COUNTER_ATTACK);
            EnemyList[ii].UpdateInstantPointGauge();
            CreateStackObject(EnemyList[ii], stackList[num].Player, Fix.COUNTER_ATTACK, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return;
          }
        }
      }
      #endregion
      #region "カルマンズ・オーン"
      if (EnemyList[ii].FullName == Fix.DUEL_CALMANS_OHN || EnemyList[ii].FullName == Fix.DUEL_CALMANS_OHN_JP)
      {
        if (stackList[num].StackTimer <= 100)
        {
          int maxInstantPoint = EnemyList[ii].MaxInstantPoint;
          if (EnemyList[ii].CurrentInstantPoint >= maxInstantPoint * ActionCommand.InstantGaugeCost(Fix.COUNTER_DISALLOW))
          {
            EnemyList[ii].UseInstantPoint(false, Fix.COUNTER_DISALLOW);
            EnemyList[ii].UpdateInstantPointGauge();
            CreateStackObject(EnemyList[ii], stackList[num].Player, Fix.COUNTER_DISALLOW, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return;
          }
        }
      }
      #endregion
      #region "シニキア・カールハンツ"
      if (EnemyList[ii].FullName == Fix.DUEL_SHINIKIA_KAHLHANZ || EnemyList[ii].FullName == Fix.DUEL_SHINIKIA_KAHLHANZ_JP)
      {
        if (stackList[num].StackTimer <= 100)
        {
          int maxInstantPoint = EnemyList[ii].MaxInstantPoint;
          if (EnemyList[ii].CurrentInstantPoint >= maxInstantPoint * ActionCommand.InstantGaugeCost(Fix.ZERO_IMMUNITY))
          {
            if (stackList[stackList.Length - 1].Player == EnemyList[ii])
            {
              // skip it
            }
            else if (EnemyList[ii].CurrentSkillPoint < SecondaryLogic.CostControl(Fix.ZERO_IMMUNITY, ActionCommand.Cost(Fix.ZERO_IMMUNITY), EnemyList[ii]))
            {
              // skip it
            }
            else if (ActionCommand.IsDamage(stackList[stackList.Length - 1].StackName) &&
                     EnemyList[ii].IsPhantomOboro == null &&
                     EnemyList[ii].CurrentManaPoint >= SecondaryLogic.CostControl(Fix.PHANTOM_OBORO, ActionCommand.Cost(Fix.PHANTOM_OBORO), EnemyList[ii]))
            {
              EnemyList[ii].UseInstantPoint(false, Fix.PHANTOM_OBORO);
              EnemyList[ii].UpdateInstantPointGauge();
              CreateStackObject(EnemyList[ii], stackList[num].Player, Fix.PHANTOM_OBORO, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return;
            }
            else if (ActionCommand.IsDamage(stackList[stackList.Length - 1].StackName) &&
                     EnemyList[ii].IsPhantomOboro)
            {
              // skip it
            }
            else if (ActionCommand.CannotBeCountered(stackList[stackList.Length - 1].StackName))
            {
              // skip it
            }
            else
            {
              EnemyList[ii].UseInstantPoint(false, Fix.ZERO_IMMUNITY);
              EnemyList[ii].UpdateInstantPointGauge();
              CreateStackObject(EnemyList[ii], stackList[num].Player, Fix.ZERO_IMMUNITY, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
              return;
            }
          }
        }
      }
      #endregion
      #region "リガール・オルフシュタイン"
      if (EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN || EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP || EnemyList[ii].FullName == Fix.EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW ||
          EnemyList[ii].FullName == Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN || EnemyList[ii].FullName == Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP || EnemyList[ii].FullName == Fix.FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW)
      {
        if (stackList[num].StackTimer <= 100)
        {
          int maxInstantPoint = EnemyList[ii].MaxInstantPoint;
          BuffImage eternalPresence = EnemyList[ii].IsEternalPresence;
          if (eternalPresence)
          {
            maxInstantPoint = (int)((double)EnemyList[ii].MaxInstantPoint * eternalPresence.EffectValue2);
          }
          if (EnemyList[ii].CurrentInstantPoint >= maxInstantPoint)
          {
            EnemyList[ii].UseInstantPoint(false, Fix.COMMAND_BUTOH_ISSEN);
            EnemyList[ii].UpdateInstantPointGauge();
            CreateStackObject(EnemyList[ii], stackList[num].Player, Fix.COMMAND_BUTOH_ISSEN, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            return;
          }
        }
      }
      #endregion
      #region "エルミ・ジョルジュ"
      if (EnemyList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT || EnemyList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT_JP || EnemyList[ii].FullName == Fix.ROYAL_KING_AERMI_JORZT_JP_VIEW ||
          EnemyList[ii].FullName == Fix.ETERNITY_KING_AERMI_JORZT || EnemyList[ii].FullName == Fix.ETERNITY_KING_AERMI_JORZT_JP || EnemyList[ii].FullName == Fix.ETERNITY_KING_AERMI_JORZT_JP_VIEW)
      {
        if (stackList[num].StackTimer <= 100)
        {
          int maxInstantPoint = EnemyList[ii].MaxInstantPoint;
          BuffImage oathOfGod = EnemyList[ii].IsOathOfGod;
          if (oathOfGod)
          {
            maxInstantPoint = (int)((double)EnemyList[ii].MaxInstantPoint * oathOfGod.EffectValue2);
          }
          if (EnemyList[ii].CurrentInstantPoint >= maxInstantPoint)
          {
            Debug.Log("warikomi EnemyList[ii].CurrentInstantPoint : maxInstantPoint " + EnemyList[ii].CurrentInstantPoint + " " + maxInstantPoint);
            int rand = AP.Math.RandomInteger(1);
            if (rand == 0)
            {
              EnemyList[ii].UseInstantPoint(false, Fix.COMMAND_DESTRUCTION_OF_TRUTH);
              EnemyList[ii].UpdateInstantPointGauge();
              CreateStackObject(EnemyList[ii], stackList[num].Player, Fix.COMMAND_DESTRUCTION_OF_TRUTH, Fix.STACKCOMMAND_IMMEDIATE_TIMER, 0);
            }
            else
            {
              EnemyList[ii].UseInstantPoint(false, Fix.COMMAND_DOUBLE_STANCE);
              EnemyList[ii].UpdateInstantPointGauge();
              CreateStackObject(EnemyList[ii], stackList[num].Player, Fix.COMMAND_DOUBLE_STANCE, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
            }
            return;
          }
        }
      }
      #endregion
    }

    // スタックタイマーが０になったら、コマンドを実行する。
    if (stackList[num].StackTimer <= 0)
    {
      if (ActionCommand.IsTarget(stackList[num].StackName) == ActionCommand.TargetType.Ally)
      {
        ExecPlayerCommand(stackList[num].Player, stackList[num].Player.Target2, stackList[num].StackName);
      }
      else
      {
        ExecPlayerCommand(stackList[num].Player, stackList[num].Target, stackList[num].StackName);
      }
    }
  }

  private void ExecNormalStack()
  {
    // スタックが無くなれば、終了とする。
    StackObject[] stackList = GroupNormalStack.GetComponentsInChildren<StackObject>();
    if (stackList.Length <= 0)
    {
      this.NowNormalStack = false;
      //GroupNormalStack.SetActive(false);
      return;
    }

    // スタックコマンドを実行する。
    int num = 0;
    if (ActionCommand.IsTarget(stackList[num].StackName) == ActionCommand.TargetType.Ally)
    {
      ExecCommandFromNormalStack(stackList[num].Player, stackList[num].Player.Target2, stackList[num].StackName, stackList[num]);
    }
    else
    {
      ExecCommandFromNormalStack(stackList[num].Player, stackList[num].Target, stackList[num].StackName, stackList[num]);
    }

    Destroy(stackList[num]);
    stackList[num] = null;
  }

  private void ExecCommandFromNormalStack(Character player, Character target, string command_name, StackObject stack_obj)
  {
    // より抽象化できたのかも知れない。1stリリースではこのままでいく。
    if (command_name == Fix.FIRE_BALL)
    {
      One.PlaySoundEffect(Fix.SOUND_FIREBALL);
      ExecMagicAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
    }
    else if (command_name == Fix.ICE_NEEDLE)
    {
      One.PlaySoundEffect(Fix.SOUND_ICENEEDLE);
      bool success = ExecMagicAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.FRESH_HEAL)
    {
      One.PlaySoundEffect(Fix.SOUND_FRESH_HEAL);
      AbstractHealCommand(stack_obj.Player, stack_obj.Target, stack_obj.HealValue, stack_obj.FromPotion);
    }
    else if (command_name == Fix.SHADOW_BLAST)
    {
      One.PlaySoundEffect(Fix.SOUND_SHADOW_BLAST);
      bool success = ExecMagicAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.ORACLE_COMMAND)
    {
      One.PlaySoundEffect(Fix.SOUND_ORACLE_COMMAND);
      double effectValue = stack_obj.EffectValue;
      if (stack_obj.Target.IsUltimateFlare)
      {
        effectValue = 0;
      }
      stack_obj.Target.CurrentInstantPoint += (int)((double)Fix.MAX_INSTANT_POINT * effectValue);
      int strValue = (int)((effectValue * 100));
      StartAnimation(stack_obj.Target.objGroup.gameObject, "Instant Point +" + strValue.ToString() + "%", Fix.COLOR_NORMAL);
    }
    else if (command_name == Fix.ENERGY_BOLT)
    {
      One.PlaySoundEffect(Fix.SOUND_ENERGY_BOLT);
      ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
    }
    else if (command_name == Fix.STRAIGHT_SMASH)
    {
      One.PlaySoundEffect(Fix.SOUND_STRAIGHT_SMASH);
      ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
    }
    else if (command_name == Fix.SHIELD_BASH)
    {
      One.PlaySoundEffect(Fix.SOUND_SHIElD_BASH);
      bool success = ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        ExecBuffStun(stack_obj.Player, stack_obj.Target, stack_obj.Turn, stack_obj.EffectValue);
      }
    }
    else if (command_name == Fix.LEG_STRIKE)
    {
      One.PlaySoundEffect(Fix.SOUND_LEG_STRIKE);
      bool success = ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.HUNTER_SHOT)
    {
      One.PlaySoundEffect(Fix.SOUND_HUNTER_SHOT);
      bool success = ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.TRUE_SIGHT)
    {
      One.PlaySoundEffect(Fix.SOUND_TRUE_SIGHT);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.DISPEL_MAGIC)
    {
      One.PlaySoundEffect(Fix.SOUND_DISPEL_MAGIC);
      AbstractRemoveBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.ViewBuffName, stack_obj.Num, stack_obj.BuffType);
    }
    else if (command_name == Fix.FLAME_BLADE)
    {
      One.PlaySoundEffect(Fix.SOUND_FLAMEBLADE);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.PURE_PURIFICATION)
    {
      One.PlaySoundEffect(Fix.SOUND_PURE_PURIFICATION);
      AbstractHealCommand(stack_obj.Player, stack_obj.Target, stack_obj.HealValue, stack_obj.FromPotion);
      AbstractRemoveBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.ViewBuffName, stack_obj.Num, stack_obj.BuffType);
    }
    else if (command_name == Fix.DIVINE_CIRCLE)
    {
      One.PlaySoundEffect(Fix.SOUND_DIVINE_CIRCLE);
      if (stack_obj.TargetField == null) { Debug.Log("target_field_obj is null..."); return; }
      AbstractAddBuff(stack_obj.Player, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.BLOOD_SIGN)
    {
      One.PlaySoundEffect(Fix.SOUND_BLOOD_SIGN);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.FORTUNE_SPIRIT)
    {
      One.PlaySoundEffect(Fix.SOUND_FORTUNE_SPIRIT);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.STANCE_OF_THE_BLADE)
    {
      One.PlaySoundEffect(Fix.SOUND_STANCE_OF_THE_BLADE);
      ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      // 対象への物理攻撃がヒットしなくても、自分自身にはBUFF付与する。
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.STANCE_OF_THE_GUARD)
    {
      One.PlaySoundEffect(Fix.SOUND_STANCE_OF_THE_GUARD);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.SPEED_STEP)
    {
      One.PlaySoundEffect(Fix.SOUND_SPEED_STEP);
      ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      // 対象への物理攻撃がヒットしなくても、自分自身にはBUFF付与する。
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.MULTIPLE_SHOT)
    {
      One.PlaySoundEffect(Fix.SOUND_MULTIPLE_SHOT);
      for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
      {
        this.GlobalAnimationChain++;
        ExecNormalAttack(stack_obj.Player, stack_obj.TargetList[ii], stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
        this.GlobalAnimationChain--;
      }
    }
    else if (command_name == Fix.LEYLINE_SCHEMA)
    {
      One.PlaySoundEffect(Fix.SOUND_LEYLINE_SCHEMA);
      if (stack_obj.TargetField == null) { Debug.Log("target_field_obj is null..."); return; }
      AbstractAddBuff(stack_obj.Player, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.SPIRITUAL_REST)
    {
      if (stack_obj.SequenceNumber == 0)
      {
        One.PlaySoundEffect(Fix.SOUND_SPIRITUAL_REST);
        if (stack_obj.Target.IsStun)
        {
          AbstractRemoveTargetBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName);
        }
      }
      else
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.HOLY_BREATH)
    {
      One.PlaySoundEffect(Fix.SOUND_HOLY_BREATH);
      for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
      {
        this.GlobalAnimationChain++;
        AbstractHealCommand(stack_obj.Player, stack_obj.TargetList[ii], stack_obj.HealValue, stack_obj.FromPotion);
        this.GlobalAnimationChain--;
      }
    }
    else if (command_name == Fix.BLACK_CONTRACT)
    {
      One.PlaySoundEffect(Fix.SOUND_BLACK_CONTRACT);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.WORD_OF_POWER)
    {
      One.PlaySoundEffect(Fix.SOUND_WORD_OF_POWER);
      ExecMagicAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
    }
    else if (command_name == Fix.SIGIL_OF_THE_PENDING)
    {
      One.PlaySoundEffect(Fix.SOUND_SIGIL_OF_THE_PENDING);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.DOUBLE_SLASH)
    {
      One.PlaySoundEffect(Fix.SOUND_DOUBLE_SLASH);
      ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
    }
    else if (command_name == Fix.CONCUSSIVE_HIT)
    {
      One.PlaySoundEffect(Fix.SOUND_CONCUSSIVE_HIT);
      bool success = ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.BONE_CRUSH)
    {
      One.PlaySoundEffect(Fix.SOUND_BONE_CRUSH);
      bool success = ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.EYE_OF_THE_ISSHIN)
    {
      One.PlaySoundEffect(Fix.SOUND_EYE_OF_THE_ISSHIN);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.VOICE_OF_VIGOR)
    {
      One.PlaySoundEffect(Fix.SOUND_VOICE_OF_THE_VIGOR);
      this.GlobalAnimationChain++;
      for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
      {
        AbstractAddBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
        ExecLifeGain(stack_obj.TargetList[ii], stack_obj.TargetList[ii], (stack_obj.TargetList[ii].MaxLife / 10.0f));
      }
      this.GlobalAnimationChain--;
    }
    else if (command_name == Fix.UNSEEN_AID)
    {
      One.PlaySoundEffect(Fix.SOUND_UNSEEN_AID);
      this.GlobalAnimationChain++;
      for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
      {
        stack_obj.TargetList[ii].objBuffPanel.RemoveAll(stack_obj.TargetList[ii]);
        StartAnimation(stack_obj.TargetList[ii].objGroup.gameObject, stack_obj.ViewBuffName, Fix.COLOR_NORMAL);
      }
      this.GlobalAnimationChain--;
    }
    else if (command_name == Fix.VOLCANIC_BLAZE)
    {
      One.PlaySoundEffect(Fix.SOUND_VOLCANIC_BLAZE);
      this.GlobalAnimationChain++;
      for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
      {
        ExecMagicAttack(stack_obj.Player, stack_obj.TargetList[ii], stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      }
      this.GlobalAnimationChain--;
      AbstractAddBuff(stack_obj.TargetList[0], stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.FREEZING_CUBE)
    {
      One.PlaySoundEffect(Fix.SOUND_FREEZING_CUBE);
      if (stack_obj.TargetField == null) { Debug.Log("target_field_obj is null..."); return; }
      bool success = ExecMagicAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.ANGELIC_ECHO)
    {
      if (stack_obj.SequenceNumber == 0)
      {
        One.PlaySoundEffect(Fix.SOUND_ANGELIC_ECHO);
        this.GlobalAnimationChain++;
        for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
        {
          AbstractHealCommand(stack_obj.Player, stack_obj.TargetList[ii], stack_obj.HealValue, stack_obj.FromPotion);
        }
        this.GlobalAnimationChain--;
      }
      else
      {
        if (stack_obj.TargetField == null) { Debug.Log("target_field_obj is null..."); return; }
        AbstractAddBuff(stack_obj.Player, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.CURSED_EVANGILE)
    {
      One.PlaySoundEffect(Fix.SOUND_CURSED_EVANGILE);
      bool success = ExecMagicAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.GALE_WIND)
    {
      One.PlaySoundEffect(Fix.SOUND_GALE_WIND);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.PHANTOM_OBORO)
    {
      One.PlaySoundEffect(Fix.SOUND_PHANTOM_OBORO);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.IRON_BUSTER)
    {
      if (stack_obj.SequenceNumber == 0)
      {
        One.PlaySoundEffect(Fix.SOUND_IRON_BUSTER);
        ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      }
      else
      {
        this.GlobalAnimationChain++;
        for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
        {
          if (stack_obj.TargetList[ii].Equals(target)) { continue; } // 同じターゲットはスキップ対象
          ExecNormalAttack(stack_obj.Player, stack_obj.TargetList[ii], stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
        }
        this.GlobalAnimationChain--;
      }
    }
    else if (command_name == Fix.DOMINATION_FIELD)
    {
      One.PlaySoundEffect(Fix.SOUND_DOMINATION_FIELD);
      AbstractAddBuff(stack_obj.Player, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.DEADLY_DRIVE)
    {
      One.PlaySoundEffect(Fix.SOUND_DEADLY_DRIVE);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.PENETRATION_ARROW)
    {
      One.PlaySoundEffect(Fix.SOUND_PENETRATION_ARROW);
      bool success = ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.WILL_AWAKENING)
    {
      One.PlaySoundEffect(Fix.SOUND_WILL_AWAKENING);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.CIRCLE_OF_SERENITY)
    {
      One.PlaySoundEffect(Fix.SOUND_CIRCLE_OF_SERENITY);
      for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
      {
        // AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_POISON, ""); // 猛毒は解除できない
        AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_SILENT, "");
        AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_BIND, "");
        AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_SLEEP, "");
        AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_STUN, "");
        AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_PARALYZE, "");
        // AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_FREEZE, ""); // 凍結は解除できない
        AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_FEAR, "");
        AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_TEMPTATION, "");
        AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_SLOW, "");
        AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_DIZZY, "");
        // AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_SLIP, ""); // 出血は解除できない
        // AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_CANNOT_RESURRECT, ""); // 蘇生不可は解除できない
        // AbstractRemoveTargetBuff(stack_obj.TargetList[ii], stack_obj.TargetList[ii].objBuffPanel, Fix.EFFECT_NO_GAIN_LIFE, ""); // ライフ回復不可は解除できない
      }

      AbstractAddBuff(stack_obj.Player, stack_obj.TargetField, Fix.CIRCLE_OF_SERENITY, Fix.CIRCLE_OF_SERENITY, SecondaryLogic.CircleOfTheSerenity_Turn(player), 0, 0, 0);
    }
    else if (command_name == Fix.FLAME_STRIKE)
    {
      One.PlaySoundEffect(Fix.SOUND_FLAME_STRIKE);
      bool success = ExecMagicAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.FROST_LANCE)
    {
      One.PlaySoundEffect(Fix.SOUND_FROST_LANCE);
      bool success = ExecMagicAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.SHINING_HEAL)
    {
      One.PlaySoundEffect(Fix.SOUND_SHINING_HEAL);
      AbstractHealCommand(stack_obj.Player, stack_obj.Target, stack_obj.HealValue, stack_obj.FromPotion);
      AbstractAddBuff(stack_obj.Target, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.CIRCLE_OF_THE_DESPAIR)
    {
      One.PlaySoundEffect(Fix.SOUND_CIRCLE_OF_THE_DESPAIR);
      AbstractAddBuff(stack_obj.Target, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.SEVENTH_PRINCIPLE)
    {
      One.PlaySoundEffect(Fix.SOUND_SEVENTH_PRINCIPLE);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.UNINTENTIONAL_HIT)
    {
      One.PlaySoundEffect(Fix.SOUND_UNINTENTIONAL_HIT);
      bool success = ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        ExecBuffParalyze(stack_obj.Player, stack_obj.Target, stack_obj.Turn, stack_obj.EffectValue);

        this.NowUnintentionalHitPlayer = stack_obj.Player;
        this.NowUnintentionalHitTarget = stack_obj.Target;
        this.NowUnintentionalHitCounter = stack_obj.NowCommandCounter;
        this.NowUnintentionalHitMode = true;
      }
    }
    else if (command_name == Fix.EVERFLOW_MIND)
    {
      One.PlaySoundEffect(Fix.SOUND_EVERFLOW_MIND);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.INNER_INSPIRATION)
    {
      One.PlaySoundEffect(Fix.SOUND_INNER_INSPIRATION);
      AbstractGainSkillPoint(stack_obj.Player, stack_obj.Target, stack_obj.EffectValue);
    }
    else if (command_name == Fix.CIRCLE_OF_THE_IGNITE)
    {
      One.PlaySoundEffect(Fix.SOUND_CIRCLE_OF_THE_IGNITE);
      AbstractAddBuff(stack_obj.Target, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.WATER_PRESENCE)
    {
      One.PlaySoundEffect(Fix.SOUND_WATER_PRESENCE);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.VALKYRIE_BLADE)
    {
      One.PlaySoundEffect(Fix.SOUND_VALKYRIE_BLADE);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.THE_DARK_INTENSITY)
    {
      One.PlaySoundEffect(Fix.SOUND_THE_DARK_INTENSITY);

      ExecLifeDown(stack_obj.Target, stack_obj.Decrease);
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.FUTURE_VISION)
    {
      One.PlaySoundEffect(Fix.SOUND_FUTURE_VISION);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.DETACHMENT_FAULT)
    {
      if (stack_obj.SequenceNumber == 0)
      {
        One.PlaySoundEffect(Fix.SOUND_DETACHMENT_FAULT);
        AbstractAddBuff(stack_obj.Player, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
      else
      {
        AbstractAddBuff(stack_obj.Target, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.STANCE_OF_THE_IAI)
    {
      One.PlaySoundEffect(Fix.SOUND_STANCE_OF_IAI);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.ONE_IMMUNITY)
    {
      One.PlaySoundEffect(Fix.SOUND_ONE_IMMUNITY);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.STANCE_OF_MUIN)
    {
      One.PlaySoundEffect(Fix.SOUND_STANCE_OF_MUIN);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.ETERNAL_CONCENTRATION)
    {
      One.PlaySoundEffect(Fix.SOUND_ETERNAL_CONCENTRATION);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.SIGIL_OF_THE_FAITH)
    {
      if (stack_obj.SequenceNumber == 0)
      {
        One.PlaySoundEffect(Fix.SOUND_SIGIL_OF_THE_FAITH);
        AbstractAddBuff(stack_obj.Player, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
      else
      {
        this.GlobalAnimationChain++;
        List<Character> player_list = GetAllyGroupAlive(stack_obj.Player);
        for (int ii = 0; ii < player_list.Count; ii++)
        {
          AbstractGainManaPoint(player_list[ii], player_list[ii], player_list[ii].MaxManaPoint - (player_list[ii].MaxManaPoint / player_list[ii].SearchFieldBuff(Fix.SIGIL_OF_THE_FAITH).EffectValue));
          AbstractGainSkillPoint(player_list[ii], player_list[ii], player_list[ii].MaxSkillPoint - (player_list[ii].MaxSkillPoint / player_list[ii].SearchFieldBuff(Fix.SIGIL_OF_THE_FAITH).EffectValue));
        }
        this.GlobalAnimationChain--;
      }
    }
    else if (command_name == Fix.LAVA_ANNIHILATION)
    {
      One.PlaySoundEffect(Fix.SOUND_LAVA_ANNIHILATION);
      this.GlobalAnimationChain++;
      for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
      {
        ExecMagicAttack(stack_obj.Player, stack_obj.TargetList[ii], stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      }
      this.GlobalAnimationChain--;
    }
    else if (command_name == Fix.ABSOLUTE_ZERO)
    {
      One.PlaySoundEffect(Fix.SOUND_ABSOLUTE_ZERO);
      if (stack_obj.Player.IsAbsoluteZero) { return; } // 強力無比な魔法のため、継続ターンの連続更新は出来なくしている。 
      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.RESURRECTION)
    {
      if (stack_obj.SequenceNumber == 0)
      {
        One.PlaySoundEffect(Fix.RESURRECTION);
      }
      else
      {
        System.Threading.Thread.Sleep(1300);
        AbstractResurrection(stack_obj.Player, stack_obj.Target, (int)(stack_obj.HealValue));
      }
    }
    else if (command_name == Fix.DEATH_SCYTHE)
    {
      One.PlaySoundEffect(Fix.SOUND_DEATH_SCYTHE);
      AbstractAddBuff(stack_obj.Target, stack_obj.TargetField, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.GENESIS)
    {
      if (stack_obj.SequenceNumber == 0)
      {
        One.PlaySoundEffect(Fix.SOUND_GENESIS);
        StartAnimation(stack_obj.Player.gameObject, Fix.GENESIS, Fix.COLOR_NORMAL, stack_obj.AnimationSpeed);
      }
      else
      {
        System.Threading.Thread.Sleep(500);
        ExecBeforeAttackPhase(stack_obj.Player, false);
      }
    }
    else if (command_name == Fix.TIME_STOP)
    {
      One.PlaySoundEffect(Fix.SOUND_TIME_STOP);
      if (stack_obj.Player.CurrentTimeStopValue <= 0) // 強力無比な魔法のため、継続ターンの連続更新は出来なくしている。
      {
        stack_obj.Player.CurrentTimeStopValue = (int)(stack_obj.Effect1);
        AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.KINETIC_SMASH)
    {
      One.PlaySoundEffect(Fix.SOUND_KINETIC_SMASH);
      ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
    }
    else if (command_name == Fix.CATASTROPHE)
    {
      One.PlaySoundEffect(Fix.SOUND_CATASTROPHE);
      ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
    }
    else if (command_name == Fix.PIERCING_ARROW)
    {
      One.PlaySoundEffect(Fix.SOUND_PIERCING_ARROW);
      bool success = ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
      if (success)
      {
        // ExecPiercingArrowは妨害の位置づけでありEverflowMindなどの効果を受け付けない。実行後は必ず０とする。
        // stack_objから変数を継承するべきかもしれないが、ココはこれで良しとする。
        stack_obj.Target.UseInstantPoint(true, Fix.PIERCING_ARROW);
        stack_obj.Target.UpdateInstantPointGauge();
        AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.STANCE_OF_THE_KOKOROE)
    {
      One.PlaySoundEffect(Fix.SOUND_STANCE_OF_KOKOROE);
      AbstractAddBuff(stack_obj.Player, stack_obj.Player.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.TRANSCENDENCE_REACHED)
    {
      One.PlaySoundEffect(Fix.SOUND_TRANSCENDENCE_REACHED);
      // 負のBUFFがあればそれを削除する。
      // [ Abstract化してもよい ]
      BuffImage[] buffList = stack_obj.Target.objBuffPanel.GetComponentsInChildren<BuffImage>();
      if (buffList == null) { return; }
      for (int ii = buffList.Length - 1; ii >= 0; ii--)
      {
        if (ActionCommand.GetBuffType(buffList[ii].BuffName) == Fix.BuffType.Negative)
        {
          buffList[ii].RemoveBuff();
        }
      }

      AbstractAddBuff(stack_obj.Target, stack_obj.Target.objBuffPanel, stack_obj.BuffName, stack_obj.ViewBuffName, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
    }
    else if (command_name == Fix.METEOR_BULLET)
    {
      One.PlaySoundEffect(Fix.SOUND_METEOR_BULLET);
      int rand = AP.Math.RandomInteger(stack_obj.TargetList.Count);
      ExecMagicAttack(stack_obj.Player, stack_obj.TargetList[rand], stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
    }
    else if (command_name == Fix.BLUE_BULLET)
    {
      One.PlaySoundEffect(Fix.SOUND_BLUE_BULLET);
      ExecMagicAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
    }
    else if (command_name == Fix.RAGING_STORM)
    {
      if (stack_obj.SequenceNumber == 0)
      {
        One.PlaySoundEffect(Fix.SOUND_RAGING_STORM);
        for (int ii = 0; ii < stack_obj.TargetList.Count; ii++)
        {
          ExecNormalAttack(stack_obj.Player, stack_obj.TargetList[ii], stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
        }
      }
      else if (stack_obj.SequenceNumber == 1)
      {
        AbstractAddBuff(stack_obj.Player, stack_obj.TargetField, Fix.RAGING_STORM, Fix.RAGING_STORM, stack_obj.Turn, stack_obj.Effect1, stack_obj.Effect2, stack_obj.Effect3);
      }
    }
    else if (command_name == Fix.CARNAGE_RUSH)
    {
      if (stack_obj.SequenceNumber == 0)
      {
        One.PlaySoundEffect(Fix.SOUND_HIT_01);
      }
      else
      {
        One.PlaySoundEffect(Fix.SOUND_HIT_02);
      }
      ExecNormalAttack(stack_obj.Player, stack_obj.Target, stack_obj.Magnify, stack_obj.DamageSource, stack_obj.IgnoreType, stack_obj.CriticalType, stack_obj.AnimationSpeed);
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

    if (player.IsFreeze || player.IsAstralGate)
    {
      if (player.IsAbsolutePerfection)
      {
        // skip
      }
      else
      {
        // 何もしないで終了
        return;
      }
    }

    if (move_skip > 0 || move_skip < 0)
    {
      player.BattleGaugeArrow += move_skip;
      if (player.BattleGaugeArrow >= Fix.BATTLE_SPEED_MAX) { player.BattleGaugeArrow = Fix.BATTLE_SPEED_MAX; }
      if (player.BattleGaugeArrow <= 0.0f) { player.BattleGaugeArrow = 0.0f; }
      player.UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX);

      if (player.objArrow2 != null && player.objArrow2.activeInHierarchy)
      {
        player.BattleGaugeArrow2 += move_skip;
        if (player.BattleGaugeArrow2 >= Fix.BATTLE_SPEED_MAX) { player.BattleGaugeArrow2 = Fix.BATTLE_SPEED_MAX; }
        if (player.BattleGaugeArrow2 <= 0.0f) { player.BattleGaugeArrow2 = 0.0f; }
        player.UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX);
      }
    }
    else
    {
      player.BattleGaugeArrow += (float)PrimaryLogic.BattleSpeed(player);
      Debug.Log(player.FullName + " BattleGaugeArrow: " + player.BattleGaugeArrow.ToString());
      if (player.BattleGaugeArrow >= Fix.BATTLE_SPEED_MAX) { player.BattleGaugeArrow = Fix.BATTLE_SPEED_MAX; }
      if (player.BattleGaugeArrow <= 0.0f) { player.BattleGaugeArrow = 0.0f; }
      player.UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX);

      if (player.objArrow2 != null && player.objArrow2.activeInHierarchy)
      {
        player.BattleGaugeArrow2 += (float)PrimaryLogic.BattleSpeed(player);
        if (player.BattleGaugeArrow2 >= Fix.BATTLE_SPEED_MAX) { player.BattleGaugeArrow2 = Fix.BATTLE_SPEED_MAX; }
        if (player.BattleGaugeArrow2 <= 0.0f) { player.BattleGaugeArrow2 = 0.0f; }
        player.UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX);
      }
    }
  }

  /// <summary>
  /// プレイヤーの行動ゲージを０に設定します。
  /// </summary>
  /// <param name="player"></param>
  /// <param name="arrow"></param>
  private void UpdatePlayerArrowZero(Character player)
  {
    player.BattleGaugeArrow = 0;
    if (player.SearchFieldBuff(Fix.COMMAND_SEIIN_FOOTPRINT) != null)
    {
      player.BattleGaugeArrow = (float)(player.SearchFieldBuff(Fix.COMMAND_SEIIN_FOOTPRINT).EffectValue);
    }
    player.UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX);
  }
  private void UpdatePlayerArrowZero2(Character player)
  {
    player.BattleGaugeArrow2 = 0;
    if (player.SearchFieldBuff(Fix.COMMAND_SEIIN_FOOTPRINT) != null)
    {
      player.BattleGaugeArrow2 = (float)(player.SearchFieldBuff(Fix.COMMAND_SEIIN_FOOTPRINT).EffectValue);
    }
    player.UpdateBattleGaugeArrow(BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX);
  }

  private void UpdatePlayerInstantGauge(Character player)
  {
    if (player.CurrentInstantPoint < player.MaxInstantPoint)
    {
      double increment = PrimaryLogic.BattleResponse(player);
      increment = increment * SpeedFactor();
      if (player.IsUltimateFlare)
      {
        increment = 0;
      }
      player.CurrentInstantPoint += increment;
      if (player.CurrentInstantPoint >= player.MaxInstantPoint)
      {
        player.CurrentInstantPoint = player.MaxInstantPoint;
      }
    }
  }

  #region "GUI Event"
  /// <summary>
  /// メインボタン押下時の処理
  /// </summary>
  public void TapCharacterMainButton(Button sender)
  {
    Debug.Log("TapPlayerMainButton: " + sender.name);

    if (this.NowNormalStack)
    {
      Debug.Log(MethodBase.GetCurrentMethod() + " NowNormalStack, then no action.");
      return;
    }

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

      // 対象元がタイム・ストップ対象者本人ではない場合、行動できない。
      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        if (this.NowTimeStop && sender.Equals(PlayerList[ii].objMainButton.ActionButton) && this.PlayerList[ii].CurrentTimeStopValue <= 0)
        {
          Debug.Log(MethodBase.GetCurrentMethod() + " CurrentTimeStopValue is less than 0, then no action.");
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
              ExecUseRedPotion(PlayerList[ii], PlayerList[ii], this.NowSelectActionSrcButton.name);
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
              ExecUseBluePotion(PlayerList[ii], PlayerList[ii], this.NowSelectActionSrcButton.name);
            }
          }
        }
        else if (this.NowSelectActionSrcButton.name == Fix.USE_GREEN_POTION_1 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_GREEN_POTION_2 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_GREEN_POTION_3 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_GREEN_POTION_4 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_GREEN_POTION_5 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_GREEN_POTION_6 ||
                 this.NowSelectActionSrcButton.name == Fix.USE_GREEN_POTION_7)
        {
          for (int ii = 0; ii < PlayerList.Count; ii++)
          {
            if (this.NowSelectActionDstButton.Equals(PlayerList[ii].objMainButton.ActionButton))
            {
              ExecUseGreenPotion(PlayerList[ii], PlayerList[ii], this.NowSelectActionSrcButton.name);
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
                      UpdateMessage(NowSelectSrcPlayer.GetCharacterSentence(1001));
                      return;
                    }
                    if (AllList[jj].IsEnemy && ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.Ally)
                    {
                      Debug.Log("Target Error. IsEnemy True : AC is Enemy");
                      UpdateMessage(NowSelectSrcPlayer.GetCharacterSentence(1002));
                      return;
                    }
                    if (ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.Ally)
                    {
                      PlayerList[ii].Target2 = AllList[jj];
                    }
                    else
                    {
                      PlayerList[ii].Target = AllList[jj];
                    }
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
                  UpdateMessage(NowSelectSrcPlayer.GetCharacterSentence(1001));
                  return;
                }
                if (AllList[ii].IsEnemy && ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.Ally)
                {
                  Debug.Log("Target Error. IsEnemy True : AC is Enemy");
                  UpdateMessage(NowSelectSrcPlayer.GetCharacterSentence(1002));
                  return;
                }

                Debug.Log("instant target is " + AllList[ii].FullName);
                ExecPlayerCommand(this.NowSelectSrcPlayer, AllList[ii], NowSelectActionCommandButton.name);
                break;
              }
            }

            // 実質ここには来ないが念のため、残しておく。
            if (ActionCommand.GetAttribute(NowSelectActionCommandButton.name) == ActionCommand.Attribute.Archetype)
            {
              // ポテンシャル・ゲージを消費。
              One.TF.PotentialEnergy = 0;
            }
            // 原則、こちらにしかこない。
            else
            {
              // インスタント・ゲージを消費。
              this.NowSelectSrcPlayer.UseInstantPoint(false, NowSelectActionCommandButton.name);
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
    Debug.Log(MethodBase.GetCurrentMethod() + ": " + sender.name);
    if (this.NowNormalStack)
    {
      Debug.Log(MethodBase.GetCurrentMethod() + " NowNormalStack, then no action.");
      return;
    }

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
      Debug.Log(MethodBase.GetCurrentMethod() + " selectedPlayer is null, then no action.");
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
    // 敵味方全体の場合はその場で選択決定。（DetachmentFaultなど）
    if (targetType == ActionCommand.TargetType.AllField)
    {
      ApplyMainActionCommand(this.NowSelectSrcPlayer, sender.ActionButton, this.NowSelectActionSrcButton, sender.name);
      ClearSelectFilterGroup();
      return;
    }

    // Duelモードではアクションコマンド選択時、対象は即時決定される。
    if (this.BattleType == Fix.BattleMode.Duel)
    {
      this.NowSelectActionCommandButton = sender.ActionButton;

      if (ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.Ally)
      {
        PlayerList[0].Target2 = PlayerList[0];
        ApplyMainActionCommand(PlayerList[0], NowSelectActionCommandButton, NowSelectActionSrcButton, NowSelectActionCommandButton.name);
        LogicInvalidate();
        ClearSelectFilterGroup();
      }
      else if (ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.Enemy)
      {
        PlayerList[0].Target = EnemyList[0];
        ApplyMainActionCommand(PlayerList[0], NowSelectActionCommandButton, NowSelectActionSrcButton, NowSelectActionCommandButton.name);
        LogicInvalidate();
        ClearSelectFilterGroup();
      }
      else if (ActionCommand.IsTarget(NowSelectActionCommandButton.name) == ActionCommand.TargetType.EnemyOrAlly)
      {
        // ターゲット選択状態へ遷移
        this.NowSelectTarget = true;
        SelectFilter.SetActive(true);
        GroupMainActionCommand.SetActive(false);
        this.NowSelectActionCommandButton = sender.ActionButton;
      }
      else
      {
        // それ以外は通常のEnemyと同じ扱いとする。
        PlayerList[0].Target = EnemyList[0];
        ApplyMainActionCommand(PlayerList[0], NowSelectActionCommandButton, NowSelectActionSrcButton, NowSelectActionCommandButton.name);
        LogicInvalidate();
        ClearSelectFilterGroup();
      }
    }
    else
    {
      // ターゲット選択状態へ遷移
      this.NowSelectTarget = true;
      SelectFilter.SetActive(true);
      GroupMainActionCommand.SetActive(false);
      this.NowSelectActionCommandButton = sender.ActionButton;
    }
  }

  /// <summary>
  /// アクションコマンド押下時の処理
  /// </summary>
  public void TapInstantAction(NodeActionCommand sender)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " +sender.CommandName);

    if (this.NowNormalStack)
    {
      Debug.Log(MethodBase.GetCurrentMethod() + " NowNormalStack, then no action.");
      return;
    }

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
      Debug.Log(MethodBase.GetCurrentMethod() + " selectedPlayer is null, then no action.");
      return;
    }

    // 対象元が死んでいる場合、行動できない。
    if (this.NowSelectSrcPlayer.Dead)
    {
      Debug.Log(MethodBase.GetCurrentMethod() + " selectedPlayer is already dead, then no action.");
      return;
    }

    // 対象元がタイム・ストップ対象者本人ではない場合、行動できない。
    if (this.NowTimeStop && this.NowSelectSrcPlayer.CurrentTimeStopValue <= 0)
    {
      Debug.Log(MethodBase.GetCurrentMethod() + " CurrentTimeStopValue is less than 0, then no action.");
      return;
    }

    // スタン効果により、行動できない。
    if (this.NowSelectSrcPlayer.IsStun)
    {
      if (sender.CommandName == Fix.CIRCLE_OF_SERENITY)
      {
        // サークル・オブ・セレニティはスタン中でも発動可能とする。
      }
      else
      {
        Debug.Log("CurrentPlayer is now stunning, then no action.");
        return;
      }
    }

    // Normalタイミングのため、行動できない。
    if (ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.Normal)
    {
      if (this.NowSelectSrcPlayer.IsWillAwakening)
      {
        Debug.Log("ActionCommand.TimingType.Normal, but IsWillAwakening detect, possible action.");
        // 通過
      }
      else if (this.NowSelectSrcPlayer.IsStanceoftheKokoroe)
      {
        Debug.Log("ActionCommand.TimingType.Normal, but IsStanceoftheKokoroe detect, possible action.");
        // 通過
      }
      else
      {
        Debug.Log("ActionCommand.TimingType.Normal, then no action.");
        return;
      }
    }

    // Sorceryタイミングのため、行動できない。
    if (ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.Sorcery)
    {
      if (this.NowSelectSrcPlayer.IsStanceoftheKokoroe)
      {
        Debug.Log("Command Timing is Sorcery, but IsStanceoftheKokoroe detect, possible action.");
        // 通過
      }
      else
      {
        Debug.Log("Command Timing is Sorcery, then no action.");
        return;
      }
    }

    // スタック・イン・ザ・コマンド専用のため、行動できない。
    if (this.NowStackInTheCommand == false && ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.StackCommand)
    {
      Debug.Log("NowStackInTheCommand false, Command Timing is StackCommand, then no action.");
      return;
    }

    Debug.Log("TapPlayerActionButton: " + this.NowSelectSrcPlayer.FullName + " " + this.NowSelectSrcPlayer.CurrentInstantPoint.ToString() + " " + this.NowSelectSrcPlayer.MaxInstantPoint.ToString());

    // 防御姿勢の場合、スタックが無い場合は即時適用。スタックある場合はスタック即時適用。インスタントゲージは消費しない。
    if (this.NowStackInTheCommand == false && sender.CommandName == Fix.DEFENSE)
    {
      this.NowSelectSrcPlayer.DecisionDefense();
      this.NowSelectSrcPlayer = null;
      return;
    }
    if (this.NowStackInTheCommand && sender.CommandName == Fix.DEFENSE)
    {
      CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.name, 1, Fix.STACKCOMMAND_SUDDEN_TIMER);
      return;
    }

    // 元核の場合
    if (ActionCommand.GetTiming(sender.CommandName) == ActionCommand.TimingType.Archetype)
    {
      // ポテンシャルゲージが不足している場合、行動できない。
      if (One.TF.PotentialEnergy < One.TF.MaxPotentialEnergy)
      {
        //UpdateMessage(this.NowSelectSrcPlayer.GetCharacterSentence(1003));
        Debug.Log("Still not enough PotentialEnergy point. then no action.");
        return;
      }

      One.TF.PotentialEnergy = 0;
      ExecPlayerCommand(this.NowSelectSrcPlayer, this.NowSelectSrcPlayer, sender.CommandName);
      return;
    }

    // インスタント値が不足している場合、行動できない。
    if ((this.NowSelectSrcPlayer.CurrentInstantPoint < this.NowSelectSrcPlayer.MaxInstantPoint) &&
        (ActionCommand.GetTiming(sender.CommandName) != ActionCommand.TimingType.Archetype)) // todo Archetypeではない場合、すべて使用不可能かどうかは決まっていない。
    {
      if (BattleType == Fix.BattleMode.Duel)
      {
        // Duelモード時、ここでは判定せず、次の処理へ。
      }
      else
      {
        UpdateMessage(this.NowSelectSrcPlayer.GetCharacterSentence(1003));
        Debug.Log("Still not enough instant point. then no action.");
        return;
      }
    }

    // スタック・イン・ザ・コマンドがまだ無い場合、Duelでなければターゲット選択へ
    if (this.NowStackInTheCommand == false && this.BattleType != Fix.BattleMode.Duel)
    {
      this.NowSelectTarget = true;
      SelectFilter.SetActive(true);
      this.NowInstantTarget = true;
      lblInstantAction.SetActive(true);

      this.NowSelectActionCommandButton = sender.ActionButton;
      return;
    }

    // Duel スタック・イン・ザ・コマンド
    if (this.NowSelectSrcPlayer.CurrentInstantPoint >= this.NowSelectSrcPlayer.MaxInstantPoint * ActionCommand.InstantGaugeCost(sender.CommandName))
    {
      Debug.Log("Duel this.NowSelectSrcPlayer.CurrentInstantPoint ok routne " + this.NowSelectSrcPlayer.CurrentInstantPoint + " " + this.NowSelectSrcPlayer.MaxInstantPoint * ActionCommand.InstantGaugeCost(sender.CommandName));
      this.NowSelectSrcPlayer.UseInstantPoint(false, sender.CommandName);
      this.NowSelectSrcPlayer.UpdateInstantPointGauge();
      if (sender.CommandName == Fix.HARDEST_PARRY)
      {
        CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.CommandName, 1, Fix.STACKCOMMAND_SUDDEN_TIMER);
      }
      else
      {
        CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.CommandName, Fix.STACKCOMMAND_NORMAL_TIMER, 0);
      }
    }
    else
    {
      Debug.Log("Duel this.NowSelectSrcPlayer.CurrentInstantPoint not enough... " + this.NowSelectSrcPlayer.CurrentInstantPoint + " " + this.NowSelectSrcPlayer.MaxInstantPoint * ActionCommand.InstantGaugeCost(sender.CommandName));
    }

    return;
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
          UpdateMessage(this.NowSelectSrcPlayer.GetCharacterSentence(1003));
          Debug.Log("Still now instant point. then no action.");
          return;
        }

        // ImmediateActionはポーションやシールなどの消耗品限定であり、アクションコマンドは入らない。実行後は必ず０とする。
        this.PlayerList[ii].UseInstantPoint(true, sender.CommandName);
        this.PlayerList[ii].UpdateInstantPointGauge();

        if (sender.CommandName == Fix.SMALL_RED_POTION ||
            sender.CommandName == Fix.NORMAL_RED_POTION ||
            sender.CommandName == Fix.LARGE_RED_POTION ||
            sender.CommandName == Fix.HUGE_RED_POTION ||
            sender.CommandName == Fix.HQ_RED_POTION ||
            sender.CommandName == Fix.THQ_RED_POTION ||
            sender.CommandName == Fix.PERFECT_RED_POTION)
        {
          bool result = ExecUseRedPotion(this.PlayerList[ii], this.PlayerList[ii], sender.CommandName);
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
          bool result = ExecUseBluePotion(this.PlayerList[ii], this.PlayerList[ii], sender.CommandName);
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
          bool result = ExecUseGreenPotion(this.PlayerList[ii], this.PlayerList[ii], sender.CommandName);
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

      case Fix.USE_GREEN_POTION_1:
      case Fix.USE_GREEN_POTION_2:
      case Fix.USE_GREEN_POTION_3:
      case Fix.USE_GREEN_POTION_4:
      case Fix.USE_GREEN_POTION_5:
      case Fix.USE_GREEN_POTION_6:
      case Fix.USE_GREEN_POTION_7:
        Debug.Log("Global USE_GREEN_POTION");
        if (this.GlobalInstantValue < Fix.GLOBAL_INSTANT_MAX)
        {
          Debug.Log("Still not enough global gauge, then no action.");
          return;
        }
        Debug.Log("UsePotionGREEN");
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
      else
      {
        objLvupSoulEssence.SetActive(false);
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

    if (One.FromHometown)
    {
      SceneManager.LoadSceneAsync(Fix.SCENE_HOME_TOWN);
    }
    else
    {
      SceneManager.LoadSceneAsync(Fix.SCENE_DUNGEON_FIELD);
    }
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
    One.ReInitializeGroundOne(false);
    One.StopDungeonMusic();
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
    Debug.Log("UpdateTurnEnd(S)");
    this.BattleTurnCount++;
    this.lblBattleTurn.text = "Turn " + BattleTurnCount.ToString();
    this.BattleTimer = 0;

    for (int ii = 0; ii < AllList.Count; ii++)
    {
      BuffImage zetsuken = AllList[ii].IsStarswordZetsuken;
      if (zetsuken)
      {
        Debug.Log("detect zetsuken");
        zetsuken.BuffCountDown();
        ExecNormalAttack(AllList[ii], AllList[ii].Target, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Random);
      }

      BuffImage seiei = AllList[ii].IsStarswordSeiei;
      if (seiei)
      {
        Debug.Log("detect seiei");
        seiei.BuffCountDown();
        seiei.Cumulative++;
        StartAnimation(AllList[ii].groupTimeSequencePanel.gameObject, Fix.BUFF_HOLY_FLARE_SWORD, Fix.COLOR_NORMAL);
      }

      BuffImage ryokuei = AllList[ii].IsStarswordRyokuei;
      if (ryokuei)
      {
        Debug.Log("detect ryokuei");
        ryokuei.BuffCountDown();
        ExecLifeGain(AllList[ii], AllList[ii], SecondaryLogic.Starsword_Ryokei_Value(AllList[ii]));
        AllList[ii].CurrentInstantPoint += 300;
        AllList[ii].UpdateInstantPointGauge();
        StartAnimation(AllList[ii].groupTimeSequencePanel.gameObject, Fix.BUFF_RYOKUEI, Fix.COLOR_NORMAL);
      }

      BuffImage finality = AllList[ii].IsStarswordFinality;
      if (finality)
      {
        Debug.Log("detect finality");
        finality.BuffCountDown();
        // Buffが消滅した時に発動する。
        if (AllList[ii].IsStarswordFinality == false)
        {
          ExecBuffCannotResurrect(AllList[ii], AllList[ii].Target, Fix.INFINITY, 0);
          ExecMagicAttack(AllList[ii], AllList[ii].Target, 10.0f, Fix.DamageSource.Colorless, Fix.IgnoreType.Both, Fix.CriticalType.Random);
        }
      }

      BuffImage chaoticSchema = AllList[ii].IsChaoticSchema;
      if (chaoticSchema)
      {
        if (chaoticSchema.RemainCounter <= 1)
        {
          AllList[ii].objArrow2.SetActive(false);
          AllList[ii].BattleGaugeArrow2 = 0;
        }
      }

      // 命運のプリズムボックスによる効果
      if (AllList[ii].IsEquip(Fix.MEIUN_PRISM_BOX))
      {
        int rand = AP.Math.RandomInteger(3);
        if (rand == 0)
        {
          double effectValue = AllList[ii].MaxLife * SecondaryLogic.MeiunPrismBox_Effect(AllList[ii]);
          Debug.Log("Equip " + Fix.MEIUN_PRISM_BOX + " Gain Life " + effectValue.ToString());
          ExecLifeGain(AllList[ii], AllList[ii], effectValue);
        }
        else if (rand == 1)
        {
          double effectValue = AllList[ii].MaxManaPoint * SecondaryLogic.MeiunPrismBox_Effect(AllList[ii]);
          Debug.Log("Equip " + Fix.MEIUN_PRISM_BOX + " Gain Mana " + effectValue.ToString());
          AbstractGainManaPoint(AllList[ii], AllList[ii], effectValue);
        }
        else if (rand == 2)
        {
          double effectValue = AllList[ii].MaxSkillPoint * SecondaryLogic.MeiunPrismBox_Effect(AllList[ii]);
          Debug.Log("Equip " + Fix.MEIUN_PRISM_BOX + " Gain SkillPoint " + effectValue.ToString());
          AbstractGainSkillPoint(AllList[ii], AllList[ii], effectValue);
        }
      }

      // アンシエント・フェイスフル・ブックによる効果
      if (AllList[ii].IsEquip(Fix.ANCIENT_FAITHFUL_BOOK))
      {
        double effect = AllList[ii].MaxInstantPoint * SecondaryLogic.AncientFaithfulBook_Effect(AllList[ii]);
        Debug.Log("Equip " + Fix.ANCIENT_FAITHFUL_BOOK + " Advance InstantGauge " + effect);
        AllList[ii].CurrentInstantPoint += (int)(effect);
        AllList[ii].UpdateInstantPointGauge();
        StartAnimation(AllList[ii].objGroup.gameObject, Fix.EFFECT_GAIN_INSTANT, Fix.COLOR_NORMAL);
      }

      // ブラック・スパイラル・ニードルによる効果
      if (AllList[ii].IsEquip(Fix.BLACK_SPIRAL_NEEDLE))
      {
        double effect = SecondaryLogic.BlackSpiralNeedle_Effect(AllList[ii]);
        Debug.Log("Equip " + Fix.BLACK_SPIRAL_NEEDLE + " AbstractRemoveBuff " + AllList[ii].FullName);
        bool success = AbstractRemoveBuff(AllList[ii], AllList[ii].objBuffPanel, Fix.BLACK_SPIRAL_NEEDLE, 1, Fix.BuffType.Negative);
        if (success)
        {
          Debug.Log("Equip " + Fix.BLACK_SPIRAL_NEEDLE + " PhysicalAttackUp " + effect);
          ExecBuffPhysicalAttackUp(AllList[ii], AllList[ii], SecondaryLogic.BlackSpiralNeedle_Turn(AllList[ii]), effect);
          Debug.Log("Equip " + Fix.BLACK_SPIRAL_NEEDLE + " PhysicalDefenseUp " + effect);
          ExecBuffPhysicalDefenseUp(AllList[ii], AllList[ii], SecondaryLogic.BlackSpiralNeedle_Turn(AllList[ii]), effect);
        }
      }

      // マインド・ストーンフィアー・ロッドによる効果
      if (AllList[ii].IsEquip(Fix.MIND_STONEFEAR_ROD))
      {
        double effect = SecondaryLogic.MindStoneFearRod_Effect(AllList[ii]);
        Debug.Log("Equip " + Fix.MIND_STONEFEAR_ROD + " AbstractRemoveBuff " + AllList[ii].FullName);
        bool success = AbstractRemoveBuff(AllList[ii], AllList[ii].objBuffPanel, Fix.MIND_STONEFEAR_ROD, 1, Fix.BuffType.Negative);
        if (success)
        {
          Debug.Log("Equip " + Fix.MIND_STONEFEAR_ROD + " MagicAttackUp " + effect);
          ExecBuffMagicAttackUp(AllList[ii], AllList[ii], SecondaryLogic.MindStoneFearRod_Turn(AllList[ii]), effect);
          Debug.Log("Equip " + Fix.MIND_STONEFEAR_ROD + " MagicDefenseUp " + effect);
          ExecBuffMagicDefenseUp(AllList[ii], AllList[ii], SecondaryLogic.MindStoneFearRod_Turn(AllList[ii]), effect);
        }
      }      
    }
    Debug.Log("UpdateTurnEnd(E)");
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
      if (buffPlayerFieldList[ii] != null && buffPlayerFieldList[ii].BuffName == Fix.BUFF_DEVIL_EMBLEM)
      {
        for (int jj = 0; jj < PlayerList.Count; jj++)
        {
          if (PlayerList[jj].IsSigilOfThePending == null)
          {
            ExecLifeDown(PlayerList[jj], 0.20f);
          }
        }
      }
      if (buffPlayerFieldList[ii] != null && buffPlayerFieldList[ii].BuffName == Fix.AURORA_PUNISHMENT)
      {
        for (int jj = 0; jj < PlayerList.Count; jj++)
        {
          if (PlayerList[jj].IsSigilOfThePending == null)
          {
            ExecMagicAttack(PlayerList[jj], PlayerList[jj], (1.00f + buffPlayerFieldList[ii].Cumulative * 0.10f), Fix.DamageSource.HolyLight, Fix.IgnoreType.None, Fix.CriticalType.Random);
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
            ExecLifeGain(EnemyList[jj], EnemyList[jj], EnemyList[jj].MaxLife / 40);
          }
        }
      }
      if (buffEnemyFieldList[ii] != null && buffEnemyFieldList[ii].BuffName == Fix.AURORA_PUNISHMENT)
      {
        for (int jj = 0; jj < EnemyList.Count; jj++)
        {
          if (EnemyList[jj].IsSigilOfThePending == null)
          {
            ExecMagicAttack(EnemyList[jj], EnemyList[jj], (1.00f + buffEnemyFieldList[ii].Cumulative * 0.10f), Fix.DamageSource.HolyLight, Fix.IgnoreType.None, Fix.CriticalType.Random);
          }
        }
      }
    }

    BuffImage deathScythePlayer = PlayerList[0].SearchFieldBuff(Fix.DEATH_SCYTHE);
    if (deathScythePlayer)
    {
      deathScythePlayer.CumulativeUp(SecondaryLogic.DeathScythe_Turn(PlayerList[0]), 1);
    }
    BuffImage deathScytheEnemy = EnemyList[0].SearchFieldBuff(Fix.DEATH_SCYTHE);
    if (deathScytheEnemy)
    {
      deathScytheEnemy.CumulativeUp(SecondaryLogic.DeathScythe_Turn(EnemyList[0]), 1);
    }

    BuffImage auroraPunishmentPlayer = PlayerList[0].IsAuroraPunishment;
    if (auroraPunishmentPlayer)
    {
      auroraPunishmentPlayer.CumulativeUp(SecondaryLogic.AuroraPunishment_Turn(PlayerList[0]), 1);
    }
    BuffImage auroraPunishmentEnemy = EnemyList[0].IsAuroraPunishment;
    if (auroraPunishmentEnemy)
    {
      auroraPunishmentEnemy.CumulativeUp(SecondaryLogic.AuroraPunishment_Turn(EnemyList[0]), 1);
    }

    // 各BUFFによる効果
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (AllList[ii].IsFreeze)
      {
        if (AllList[ii].IsAbsolutePerfection)
        {
          AllList[ii].CurrentActionPoint += Fix.AP_BASE;
          //AllList[ii].GainManaPoint(); // Manaはターン経過で増加しない
          AllList[ii].GainSkillPoint(); // Skillはターン経過で増加する
          AllList[ii].UpdateActionPoint();
        }
        else
        {
          // GainSkillPointできない。
        }
      }
      else
      {
        AllList[ii].CurrentActionPoint += Fix.AP_BASE;
        //AllList[ii].GainManaPoint(); // Manaはターン経過で増加しない
        AllList[ii].GainSkillPoint(); // Skillはターン経過で増加する
        AllList[ii].UpdateActionPoint();
      }

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
        ExecLifeGain(AllList[ii], AllList[ii], AllList[ii].IsHeartOfLife.EffectValue);
      }

      // 【猛毒】による効果
      if (AllList[ii].IsPoison)
      {
        if (AllList[ii].SearchFieldBuff(Fix.SHINING_HEAL) != null)
        {
          // 何もしない
        }
        else if (AllList[ii].IsAbsolutePerfection)
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

      if (AllList[ii].IsEternalConcentration)
      {
        List<Character> target_list = GetOpponentGroupAlive(AllList[ii]);
        for (int jj = 0; jj < target_list.Count; jj++)
        {
          if (AllList[ii].Target == target_list[jj])
          {
            AbstractAddBuff(AllList[ii].Target, AllList[ii].Target.objBuffPanel, Fix.BUFF_FOCUS_EYE, Fix.BUFF_FOCUS_EYE_JP, SecondaryLogic.FocusEye_Turn(AllList[ii]), 1, SecondaryLogic.FocusEye_Effect(), 0);
          }
        }
      }

      BuffImage sigilOfTheFaith = AllList[ii].SearchFieldBuff(Fix.SIGIL_OF_THE_FAITH);
      if (sigilOfTheFaith)
      {
        AbstractGainManaPoint(AllList[ii], AllList[ii], AllList[ii].MaxManaPoint - (AllList[ii].MaxManaPoint / sigilOfTheFaith.EffectValue));
        AbstractGainSkillPoint(AllList[ii], AllList[ii], AllList[ii].MaxSkillPoint - (AllList[ii].MaxSkillPoint / sigilOfTheFaith.EffectValue));
      }

      if (AllList[ii].IsBlackSpore)
      {
        int random = AP.Math.RandomInteger(4);
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
        }
      }

      BuffImage holyWisdom = AllList[ii].SearchFieldBuff(Fix.HOLY_WISDOM);
      if (holyWisdom)
      {
        double effectValue = holyWisdom.EffectValue2;
        UpdateMessage("聖なる加護が、" + AllList[ii].FullName + "へ生命力を注ぎ込んでいる。" + ((int)effectValue).ToString() + "ライフ回復\r\n");
        ExecLifeGain(AllList[ii], AllList[ii], effectValue);
      }

      BuffImage deathScythe = AllList[ii].SearchFieldBuff(Fix.DEATH_SCYTHE);
      if (deathScythe)
      {
        if (AllList[ii].Dead == false)
        {
          ExecLifeDown(AllList[ii], deathScythe.EffectValue * deathScythe.Cumulative);
          AbstractLostManaPoint(AllList[ii], AllList[ii], AllList[ii].MaxManaPoint * deathScythe.EffectValue * deathScythe.Cumulative);
          AbstractLostSkillPoint(AllList[ii], AllList[ii], AllList[ii].MaxSkillPoint * deathScythe.EffectValue * deathScythe.Cumulative);
          if (AllList[ii].CurrentLife <= 0)
          {
            AllList[ii].objFieldPanel.RemoveTargetFieldBuff(Fix.DEATH_SCYTHE);
            LogicInvalidate();
          }
        }
      }

      // レギィンアーゼ、「壱なる焔」の効果
      BuffImage ichinaruHomura = AllList[ii].IsIchinaruHomura;
      if (ichinaruHomura && AllList[ii].Dead == false)
      {
        UpdateMessage(AllList[ii].FullName + "に焔火が降り注ぐ。\r\n");
        ExecElementalDamage(AllList[ii], Fix.DamageSource.Fire, SecondaryLogic.IchinaruHomuraValue(AllList[ii]));
      }
      // レギィンアーゼ、「エターナル・ドロップレット」の効果
      BuffImage eternalDroplet = AllList[ii].IsEternalDroplet;
      if (eternalDroplet)
      {
        double effectValue = SecondaryLogic.EternalDropletValue_A(AllList[ii]);
        UpdateMessage("永遠を示す理が、" + AllList[ii].FullName + "へ生命力を注ぎ込んでいる。" + ((int)effectValue).ToString() + "ライフ回復\r\n");
        ExecLifeGain(AllList[ii], AllList[ii], effectValue);

        double effectValue2 = SecondaryLogic.EternalDropletValue_B(AllList[ii]);
        UpdateMessage(((int)effectValue2).ToString() + "マナ回復\r\n");        
        AllList[ii].CurrentManaPoint += (int)effectValue;
        AllList[ii].UpdateManaPoint();
        StartAnimation(AllList[ii].groupManaPoint, "マナ回復 " + ((int)effectValue).ToString(), Fix.COLOR_GAIN_MP);
      }

      // エルミ・ジョルジュ、「シャドウ・ブリンガー」の効果
      BuffImage shadowBringer = AllList[ii].IsShadowBringer;
      if (shadowBringer)
      {
        Debug.Log("detect shadowBringer");
        int result = (int)(AllList[ii].MaxManaPoint * shadowBringer.EffectValue);
        AllList[ii].CurrentManaPoint -= result;
        AllList[ii].UpdateManaPoint();
        StartAnimation(AllList[ii].groupManaPoint.gameObject, result.ToString(), Fix.COLOR_MP_DAMAGE);
      }

      // エルミ・ジョルジュ、「イノセント・サークル」の効果
      BuffImage innocentCircle = AllList[ii].IsInnocentCircle;
      if (innocentCircle)
      {
        bool detectMax = false;
        if (AllList[ii].CurrentManaPoint >= AllList[ii].MaxManaPoint)
        {
          detectMax = true;
        }
        else
        {
          AbstractGainManaPoint(AllList[ii], AllList[ii], AllList[ii].MaxManaPoint * innocentCircle.EffectValue);
        }

        if (AllList[ii].CurrentSkillPoint >= AllList[ii].MaxSkillPoint)
        {
          detectMax = true;
        }
        else
        {
          AbstractGainSkillPoint(AllList[ii], AllList[ii], AllList[ii].MaxSkillPoint * innocentCircle.EffectValue);
        }

        if (detectMax)
        {
          AllList[ii].CurrentInstantPoint += 300;
          AllList[ii].UpdateInstantPointGauge();
          StartAnimation(AllList[ii].objGroup.gameObject, "インスタントゲージ増強", Fix.COLOR_NORMAL);
        }
      }

      // 古代の宝珠：厳正の効果
      if (AllList[ii].IsEquip(Fix.ARTIFACT_GENSEI))
      {
        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Player Mana (before) " + AllList[ii].CurrentManaPoint + " / " + AllList[ii].MaxManaPoint);

        int core = (AllList[ii].MaxManaPoint / 100); // １％回復をベースとする。
        if (core <= 3) { core = 3; } // 最低でも3回復する事とする。
        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Gain Mana core       " + core);

        int additional = AllList[ii].MaxManaPoint / 100;
        if (additional <= 7) { additional = 7; } // 最低でも7+する事とする。
        additional = AP.Math.RandomInteger(additional);
        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Gain Mana additional " + additional);

        int effect = core + additional;
        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Gain Mana total      " + effect);
        AbstractGainManaPoint(AllList[ii], AllList[ii], effect);

        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Player Mana (after)  " + AllList[ii].CurrentManaPoint + " / " + AllList[ii].MaxManaPoint);
      }

      if (AllList[ii].IsEquip(Fix.ARTIFACT_ZIHI))
      {
        // MaxSkillPointは基底１００から変わらない設計だが、特殊効果やルール改定で上限が増えていくなら効果があるので上昇できる様にしておく。
        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Player SkillPoint (before) " + AllList[ii].CurrentSkillPoint + " / " + AllList[ii].MaxSkillPoint);

        int core = (AllList[ii].MaxSkillPoint / 100); // １％回復をベースとする。
        if (core <= 2) { core = 2; } // 最低でも2回復する事とする。
        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Gain SkillPoint core       " + core);

        int additional = AllList[ii].MaxSkillPoint / 100;
        if (additional <= 5) { additional = 5; } // 最低でも5+する事とする。
        additional = AP.Math.RandomInteger(additional);
        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Gain SkillPoint additional " + additional);

        int effect = core + additional;
        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Gain SkillPoint total      " + effect);
        AbstractGainSkillPoint(AllList[ii], AllList[ii], effect);

        Debug.Log("Equip " + Fix.ARTIFACT_GENSEI + " Player SkillPoint (after)  " + AllList[ii].CurrentSkillPoint + " / " + AllList[ii].MaxSkillPoint);
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
            AbstractHealCommand(PlayerList[jj], PlayerList[jj], buffPlayerFieldList[ii].EffectValue, false);
            BuffImage[] buffList = PlayerList[jj].GetNegativeBuffList();
            if (buffList != null && buffList.Length > 0) 
            {
              AbstractRemoveBuff(PlayerList[jj], PlayerList[jj].objBuffPanel, "", 1, Fix.BuffType.Negative);
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
            AbstractHealCommand(EnemyList[jj], EnemyList[jj], buffEnemyFieldList[ii].EffectValue, false);
            BuffImage[] buffList = EnemyList[jj].GetNegativeBuffList();
            if (buffList != null && buffList.Length > 0)
            {
              AbstractRemoveBuff(EnemyList[jj], EnemyList[jj].objBuffPanel, "", 1, Fix.BuffType.Negative);
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

  private void UpdateAutoRecoverForBoss()
  {
    for (int ii = 0; ii < EnemyList.Count; ii++)
    {
      if (EnemyList[ii].Area == Fix.MonsterArea.Boss1 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss2 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss21 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss22 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss23 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss24 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss25 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss3 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss4 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss42 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss5 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss52 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss53 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_1 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_2 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_3_1 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_3_2 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_4 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_5_1 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_5_2 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_6 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_7_1 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_7_2 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss54_7_3 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss6 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss62 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss63_1 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss63_2 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss63_3 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss64 ||
          EnemyList[ii].Area == Fix.MonsterArea.Boss64_2 ||
          EnemyList[ii].Area == Fix.MonsterArea.LastBoss)
      {
        // Debug.Log("Boss AutoRecover " + EnemyList[ii].FullName);
        EnemyList[ii].AutoRecover();
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
    player.txtActionCommand.text = command_name;
    ActionCommand.TargetType currentTargetType = ActionCommand.IsTarget(command_name);
    List<Character> opponentList = GetOpponentGroup(player);

    // Targetはターゲット種別に依存せず、相手側をターゲットとする。
    if (player.TargetSelectType == Fix.TargetSelectType.Behind)
    {
      player.Target = GetOpponentGroup(player)[opponentList.Count - 1];
    }
    else
    {
      player.Target = GetOpponentGroup(player)[0];
    }

    // Target2は味方陣営の先頭を対象とする。
    player.Target2 = GetAllyGroup(player)[0];

    // 自分自身の場合は、Target2を自分自身に設定
    if (currentTargetType == ActionCommand.TargetType.Own)
    {
      player.Target2 = player;
    }
    Debug.Log("SetupFirstCommand(E)");
  }
  #endregion
  #endregion

  #region "Exec Action Command"
  /// <summary>
  /// 基本ロジックを内包した物理攻撃実行コマンド
  /// </summary>
  private bool ExecNormalAttack(Character player, Character target, double magnify, Fix.DamageSource attr, Fix.IgnoreType ignore_target_defense, Fix.CriticalType critical, int animation_speed = MAX_ANIMATION_TIME)
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
        player.UseInstantPoint(true, Fix.SONIC_PULSE);
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
          // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveBuffを介さない。
          buffImage.RemoveBuff();
        }
        return false; // ディバイン・フィールドで吸収された場合はヒットしたことにならない。
      }
    }
    // モンスター専用：FAITH_SIGHTによる効果
    if (panelField != null)
    {
      BuffImage buffImage = PreCheckFieldEffect(panelField.gameObject, Fix.COMMAND_FAITH_SIGHT);
      if (buffImage != null)
      {
        Debug.Log("COMMAND_FAITH_SIGHT: " + player.FullName + " -> " + damageValue.ToString("F2") + " " + buffImage.EffectValue.ToString("F2"));
        buffImage.EffectValue -= damageValue;
        StartAnimationGroupPanel(buffImage.gameObject, Fix.BATTLE_DIVINE + "\r\n " + (int)(buffImage.EffectValue), Fix.COLOR_NORMAL);
        if (buffImage.EffectValue <= 0)
        {
          // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveBuffを介さない。
          buffImage.RemoveBuff();
        }
        return false; // FAITH_SIGHTで吸収された場合はヒットしたことにならない。
      }
    }
    if (panelField != null)
    {
      BuffImage buffImage = PreCheckFieldEffect(panelField.gameObject, Fix.GOLDEN_MATRIX);
      if (buffImage != null)
      {
        damageValue = 0;
        buffImage.CumulativeDown(1);
        StartAnimationGroupPanel(buffImage.gameObject, Fix.COMMAND_GOLDEN_MATRIX + "\r\n " + (int)(buffImage.EffectValue), Fix.COLOR_NORMAL);
        return false; // GoldenMatrix効果によりここで処理を終了
      }
    }

    // ブレードシャドウ・クラウディッド・ドレスによる効果
    if (target.IsEquip(Fix.BLADESHADOW_CROWDED_DRESS))
    {
      int percent = SecondaryLogic.BladeshadowCrowdedDress_Percent(player);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.BLADESHADOW_CROWDED_DRESS + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        double effect = SecondaryLogic.BladeshadowCrowdedDress_Effect1(target);
        Debug.Log("Equip " + Fix.BLADESHADOW_CROWDED_DRESS + " physical-damage reduction (before) " + damageValue + " " + effect);
        damageValue = damageValue * effect;
        Debug.Log("Equip " + Fix.BLADESHADOW_CROWDED_DRESS + " physical-damage reduction (after ) " + damageValue + " " + effect);
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DAMAGE_IS_HALF, Fix.COLOR_GUARD);

        double effect2 = damageValue;
        Debug.Log("Equip " + Fix.BLADESHADOW_CROWDED_DRESS + " reflect damage " + effect2.ToString());
        StartAnimation(player.objGroup.gameObject, Fix.EFFECT_DAMAGE_REFLECT, Fix.COLOR_DAMAGE_REFLECT);
        ExecElementalDamage(player, Fix.DamageSource.Colorless, effect2);

        // return true; ここでリターンしない。処理継続
      }
    }

    // ファントム・朧による効果
    if (target.IsPhantomOboro != null && this.NowStackInTheCommand)
    {
      damageValue = 0;
    }

    // モンスター特有
    if (target.IsIchimaiGuardwall != null)
    {
      // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveTargetBuffを介さない。
      target.RemoveTargetBuff(Fix.COMMAND_ICHIMAI_GUARDWALL);
      ApplyDamage(player, player, damageValue, resultCritical, animation_speed);
      return true;
      // 反射に関するロジック構築は必要だが、モンスターの単発行動であるため、これで良い。
    }

    BuffImage focusEye = target.IsFocusEye;
    if (focusEye)
    {
      damageValue = damageValue * (1.00f + focusEye.EffectValue2 * focusEye.Cumulative);
    }

    // ダメージ適用
    ApplyDamage(player, target, damageValue, resultCritical, animation_speed);

    // 追加効果
    BuffImage abyssFire = player.IsAbyssFire;
    if (abyssFire)
    {
      ExecElementalDamage(player, Fix.DamageSource.Fire, SecondaryLogic.AbyssFireValue(player));
    }

    BuffImage starswordSeiei = player.SearchTimeSequenceBuff(Fix.STARSWORD_SEIEI);
    if (starswordSeiei)
    {
      ExecMagicAttack(player, target, (1.00f + starswordSeiei.Cumulative * 0.50f), Fix.DamageSource.Fire, Fix.IgnoreType.None, critical);
    }

    // フレイム・ブレイドによる効果
    if (player.IsFlameBlade && player.Dead == false)
    {
      Debug.Log("Buff-Detect FlameBlade");
      bool resultCritical2 = false;
      double addDamageValue = player.IsFlameBlade.EffectValue2 + MagicDamageLogic(player, target, SecondaryLogic.FlameBlade(player), Fix.DamageSource.Fire, Fix.IgnoreType.None, critical, ref resultCritical2);
      Debug.Log("Buff-Detect FlameBlade addDamage: " + addDamageValue);
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
      stanceOfTheBlade.CumulativeUp(stanceOfTheBlade.RemainCounter, 1);
      if (beforeCumulative != stanceOfTheBlade.Cumulative)
      {
        Debug.Log("Target is stanceOfTheBlade, update cumulative " + stanceOfTheBlade.Cumulative);
        StartAnimation(player.objGroup.gameObject, Fix.BATTLE_ATTACK_UP, Fix.COLOR_NORMAL);
      }
      else
      {
        Debug.Log("Target is stanceOfTheBlade, no cumulative...");
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

    BuffImage theDarkIntensity = target.IsTheDarkIntensity;
    if (theDarkIntensity)
    {
      int beforeCumulative = theDarkIntensity.Cumulative;
      theDarkIntensity.Cumulative++;
      if (beforeCumulative != theDarkIntensity.Cumulative)
      {
        StartAnimation(target.objGroup.gameObject, Fix.BUFF_DARK_INTENSITY_UP_JP, Fix.COLOR_NORMAL);
      }
    }

    BuffImage valkyrieBlade = player.IsValkyrieBlade;
    if (valkyrieBlade != null)
    {
      Debug.Log("Target is valkyrieBlade, then additional damage: " + player.TotalIntelligence * SecondaryLogic.ValkyrieBlade_Effect(player));
      ExecElementalDamage(target, Fix.DamageSource.HolyLight, player.TotalIntelligence * SecondaryLogic.ValkyrieBlade_Effect(player));
      AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_VALKYRIE_SCAR, Fix.BUFF_VALKYRIE_SCAR_JP, SecondaryLogic.ValkyrieScar_Turn(player), 0, 0, 0);
    }

    // 土力の斧による効果
    if (player.IsEquip(Fix.EARTH_POWER_AXE))
    {
      Debug.Log("Equip " + Fix.EARTH_POWER_AXE + " call target skill");
      int random = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.EARTH_POWER_AXE + " random " + random + " " + SecondaryLogic.EarthPowerAxe_Effect(player));
      if (random <= SecondaryLogic.EarthPowerAxe_Effect(player))
      {
        double addDamageValue = SecondaryLogic.EarthPowerAxe_Effect2(player);
        Debug.Log("Equip " + Fix.EARTH_POWER_AXE + " Additional Damage " + addDamageValue.ToString());
        ApplyDamage(player, target, addDamageValue, false, animation_speed);
      }
      else
      {
        Debug.Log("Equip " + Fix.EARTH_POWER_AXE + " no action");
      }
    }

    // 疾風の剣による効果
    if (player.IsEquip(Fix.AERO_BLADE))
    {
      Debug.Log("Equip " + Fix.AERO_BLADE + " call target skill");
      int random = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.AERO_BLADE + " random " + random + " " + SecondaryLogic.AeroBlae_Effect(player));
      if (random <= SecondaryLogic.AeroBlae_Effect(player))
      {
        double addDamageValue = SecondaryLogic.AeroBlae_Effect2(player);
        Debug.Log("Equip " + Fix.AERO_BLADE + " Additional Damage " + addDamageValue.ToString());
        ApplyDamage(player, target, addDamageValue, false, animation_speed);
      }
      else
      {
        Debug.Log("Equip " + Fix.AERO_BLADE + " no action");
      }
    }

    // ソード・オブ・ライフによる効果
    if (player.IsEquip(Fix.SWORD_OF_LIFE))
    {
      double effectValue = SecondaryLogic.SwordOfLife_Effect(player);
      AbstractHealCommand(player, player, effectValue, false);
    }

    // ブルー・ライトニング・ソードによる効果
    if (player.IsEquip(Fix.BLUE_LIGHTNING_SWORD))
    {
      bool resultCritical2 = false;
      double addDamageValue = SecondaryLogic.BlueLightningSword_Effect(player) + MagicDamageLogic(player, target, SecondaryLogic.BlueLightningSword_Factor(player), Fix.DamageSource.Ice, Fix.IgnoreType.None, critical, ref resultCritical2);
      Debug.Log("Equip " + Fix.BLUE_LIGHTNING_SWORD + " Additional Damage " + addDamageValue.ToString());
      ExecElementalDamage(target, Fix.DamageSource.Ice, addDamageValue);
    }

    // アッシュ・エクスクルード・ランスによる効果
    if (player.IsEquip(Fix.ASH_EXCLUDE_LANCE))
    {
      double effect = SecondaryLogic.AshExcludeLance_Effect(player);
      Debug.Log("Equip " + Fix.ASH_EXCLUDE_LANCE + " AddBuff Slip " + effect);
      ExecBuffSlip(player, target, 1, effect);
    }

    // ボーン・クラッシュ・アックスによる効果
    if (player.IsEquip(Fix.BONE_CRUSH_AXE))
    {
      double effect = SecondaryLogic.BoneCrushAxe_Effect(player);
      Debug.Log("Equip " + Fix.BONE_CRUSH_AXE + " AddBuff PhysicalDefenseDown " + effect);
      ExecBuffPhysicalDefenseDown(player, target, 3, effect);
    }

    // コールド・スプラッシュ・クローによる効果
    if (player.IsEquip(Fix.COLD_SPLASH_CLAW))
    {
      bool resultCritical2 = false;
      double addDamageValue = SecondaryLogic.ColdSplashClaw_Effect(player) + MagicDamageLogic(player, target, SecondaryLogic.ColdSplashClaw_Factor(player), Fix.DamageSource.Ice, Fix.IgnoreType.None, critical, ref resultCritical2);
      Debug.Log("Equip " + Fix.COLD_SPLASH_CLAW + " Additional Damage " + addDamageValue.ToString());
      ExecElementalDamage(target, Fix.DamageSource.Ice, addDamageValue);
    }

    // 魔弾・シューティング・スターによる効果
    if (player.IsEquip(Fix.MADAN_SHOOTING_STAR))
    {
      bool resultCritical2 = false;
      double addDamageValue = SecondaryLogic.MadanShootingStar_Effect(player) + MagicDamageLogic(player, target, SecondaryLogic.MadanShootingStar_Factor(player), Fix.DamageSource.DarkMagic, Fix.IgnoreType.None, critical, ref resultCritical2);
      Debug.Log("Equip " + Fix.MADAN_SHOOTING_STAR + " Additional Damage " + addDamageValue.ToString());
      ExecElementalDamage(target, Fix.DamageSource.DarkMagic, addDamageValue);
    }

    // 炎翔刀による効果
    if (player.IsEquip(Fix.ENSHOUTOU))
    {
      bool resultCritical2 = false;
      double addDamageValue = SecondaryLogic.Enshoutou_Effect(player) + MagicDamageLogic(player, target, SecondaryLogic.Enshoutou_Factor(player), Fix.DamageSource.Fire, Fix.IgnoreType.None, critical, ref resultCritical2);
      Debug.Log("Equip " + Fix.ENSHOUTOU + " Additional Damage " + addDamageValue.ToString());
      ExecElementalDamage(target, Fix.DamageSource.Fire, addDamageValue);
    }

    // ガーラント・フェザー・ランスによる効果
    if (player.IsEquip(Fix.GALLANT_FEATHER_LANCE))
    {
      double effect = SecondaryLogic.GallantFeatherLance_Factor(player);
      Debug.Log("Equip " + Fix.GALLANT_FEATHER_LANCE + " AddBuff SpeedUp " + effect);
      ExecBuffBattleSpeedUp(player, player, SecondaryLogic.GallantFeatherLance_Turn(player), SecondaryLogic.GallantFeatherLance_Factor(player));
    }

    // サンダー・ブレイク・アックスによる効果
    if (player.IsEquip(Fix.THUNDER_BREAK_AXE))
    {
      int percent = SecondaryLogic.ThunderBreakAxe_Percent(player);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.THUNDER_BREAK_AXE + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        Debug.Log("Equip " + Fix.THUNDER_BREAK_AXE + "AddBuff Paralyze");
        ExecBuffParalyze(player, target, SecondaryLogic.ThunderBreakAxe_Turn(player), 0);
      }
    }

    // ラス・サーヴェル・クローによる効果
    if (player.IsEquip(Fix.WRATH_SABEL_CLAW))
    {
      int percent = SecondaryLogic.WrathSabelClaw_Percent(player);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.WRATH_SABEL_CLAW + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        double effect = SecondaryLogic.WrathSabelClaw_Effect(player);
        Debug.Log("Equip " + Fix.WRATH_SABEL_CLAW + " AddBuff Slip " + effect);
        ExecBuffSlip(player, target, SecondaryLogic.WrathSabelClaw_Turn(player), effect);
      }
    }

    // フルメタル・アストラル・ブレードによる効果
    if (player.IsEquip(Fix.FULLMETAL_ASTRAL_BLADE))
    {

      int percent = SecondaryLogic.FullmetalAstralBlade_Percent(player);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.FULLMETAL_ASTRAL_BLADE + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        double effect = player.MaxInstantPoint * SecondaryLogic.FullmetalAstralBlade_Effect(player);
        Debug.Log("Equip " + Fix.FULLMETAL_ASTRAL_BLADE + " Advance InstantGauge " + effect);
        player.CurrentInstantPoint += (int)(effect);
        player.UpdateInstantPointGauge();
        StartAnimation(player.objGroup.gameObject, Fix.EFFECT_GAIN_INSTANT, Fix.COLOR_NORMAL);
      }
    }

    // ストーム・フュリー・ランサーによる効果
    if (player.IsEquip(Fix.STORM_FURY_LANCER))
    {
      int rand = AP.Math.RandomInteger(3);
      if (rand == 0)
      {
        double effectValue = SecondaryLogic.StormFuryLancer_Effect(player);
        Debug.Log("Equip " + Fix.STORM_FURY_LANCER + " PhysicalAttackUp effect " + effectValue.ToString());
        ExecBuffPhysicalAttackUp(player, player, SecondaryLogic.StormFuryLancer_Turn(player), effectValue);
      }
      else if (rand == 1)
      {
        double effectValue = SecondaryLogic.StormFuryLancer_Effect(player);
        Debug.Log("Equip " + Fix.STORM_FURY_LANCER + " BattleSpeedUp effect " + effectValue.ToString());
        ExecBuffBattleSpeedUp(player, player, SecondaryLogic.StormFuryLancer_Turn(player), effectValue);
      }
      else if (rand == 2)
      {
        double effectValue = SecondaryLogic.StormFuryLancer_Effect(player);
        Debug.Log("Equip " + Fix.STORM_FURY_LANCER + " BattleResponseUp effect " + effectValue.ToString());
        ExecBuffBattleResponseUp(player, player, SecondaryLogic.StormFuryLancer_Turn(player), effectValue);
      }
    }

    // ウォーロード・バスタード・アックスによる効果
    if (player.IsEquip(Fix.WARLOAD_BASTARD_AXE))
    {
      int rand = AP.Math.RandomInteger(3);
      if (rand == 0)
      {
        double effectValue = SecondaryLogic.WarloadBasterdAxe_Effect(player);
        Debug.Log("Equip " + Fix.WARLOAD_BASTARD_AXE + " PhysicalDefenseDown effect " + effectValue.ToString());
        ExecBuffPhysicalDefenseDown(player, target, SecondaryLogic.WarloadBasterdAxe_Turn(player), effectValue);
      }
      else if (rand == 1)
      {
        double effectValue = SecondaryLogic.WarloadBasterdAxe_Effect(player);
        Debug.Log("Equip " + Fix.WARLOAD_BASTARD_AXE + " MagicDefenseDown effect " + effectValue.ToString());
        ExecBuffMagicDefenseDown(player, target, SecondaryLogic.WarloadBasterdAxe_Turn(player), effectValue);
      }
      else if (rand == 2)
      {
        double effectValue = SecondaryLogic.WarloadBasterdAxe_Effect(player);
        Debug.Log("Equip " + Fix.WARLOAD_BASTARD_AXE + " BattleSpeedDown effect " + effectValue.ToString());
        ExecBuffBattleSpeedDown(player, target, SecondaryLogic.WarloadBasterdAxe_Turn(player), effectValue);
      }
    }

    // アース・シャード・クローによる効果
    if (player.IsEquip(Fix.EARTH_SHARD_CLAW))
    {
      int percent = SecondaryLogic.EarthShardClaw_Percent(player);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.EARTH_SHARD_CLAW + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        double effectValue = player.MaxSkillPoint * SecondaryLogic.EarthShardClaw_Effect(player);
        effectValue = Math.Round(effectValue, MidpointRounding.AwayFromZero);
        Debug.Log("Equip " + Fix.EARTH_SHARD_CLAW + " Gain SkillPoint " + effectValue.ToString());
        AbstractGainSkillPoint(player, player, effectValue);
      }
    }

    // ルミナス・リフレクト・ミラーによる効果
    if (target.IsEquip(Fix.LUMINOUS_REFLECT_MIRROR))
    {
      int percent = SecondaryLogic.LuminousReflectMirror_Percent(target);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.LUMINOUS_REFLECT_MIRROR + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        double effectValue = damageValue * SecondaryLogic.LuminousReflectMirror_Effect(target);
        Debug.Log("Equip " + Fix.LUMINOUS_REFLECT_MIRROR + " reflect damage " + effectValue.ToString());
        StartAnimation(player.objGroup.gameObject, Fix.EFFECT_DAMAGE_REFLECT, Fix.COLOR_DAMAGE_REFLECT);
        ApplyDamage(target, player, effectValue, false, animation_speed);
      }
    }

    // ヴォルカニック・バトル・バスターによる効果
    if (player.IsEquip(Fix.VOLCANIC_BATTLE_BASTER))
    {
      int percent = SecondaryLogic.VolcanicBattleBuster_Percent(player);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.VOLCANIC_BATTLE_BASTER + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        int random = AP.Math.RandomInteger(4);
        if (random == 0)
        {
          Debug.Log("Equip " + Fix.VOLCANIC_BATTLE_BASTER + " AddBuff Stun");
          ExecBuffStun(player, target, SecondaryLogic.VolcanicBattleBuster_Trun(player), 0);
        }
        else if (random == 1)
        {
          Debug.Log("Equip " + Fix.VOLCANIC_BATTLE_BASTER + " AddBuff Paralyze");
          ExecBuffParalyze(player, target, SecondaryLogic.VolcanicBattleBuster_Trun(player), 0);
        }
        else if (random == 2)
        {
          Debug.Log("Equip " + Fix.VOLCANIC_BATTLE_BASTER + " AddBuff Fear");
          ExecBuffFear(player, target, SecondaryLogic.VolcanicBattleBuster_Trun(player), 0);
        }
        else if (random == 3)
        {
          Debug.Log("Equip " + Fix.VOLCANIC_BATTLE_BASTER + " AddBuff Slow");
          ExecBuffSlow(player, target, SecondaryLogic.VolcanicBattleBuster_Trun(player), SecondaryLogic.DarksunTragedicBook_Effect(player));
        }
      }
    }

    // スウィフトクロス・オブ・レッドサンダーによる効果
    if (target.IsEquip(Fix.SWIFTCROSS_OF_REDTHUNDER))
    {
      int percent = SecondaryLogic.SwiftcrossOFRedthunder_Percent(target);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.SWIFTCROSS_OF_REDTHUNDER + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        double effectValue = damageValue * SecondaryLogic.SwiftcrossOFRedthunder_Effect(target);
        Debug.Log("Equip " + Fix.SWIFTCROSS_OF_REDTHUNDER + " reflect damage " + effectValue.ToString());
        StartAnimation(player.objGroup.gameObject, Fix.EFFECT_DAMAGE_REFLECT, Fix.COLOR_DAMAGE_REFLECT);
        ApplyDamage(target, player, effectValue, false, animation_speed);
      }
    }

    // 神剣  フェルトゥーシュによる効果
    if (player.IsEquip(Fix.LEGENDARY_FELTUS))
    {
      Debug.Log("Equip " + Fix.LEGENDARY_FELTUS + " God-Contract, Cannot-Resurrect, No-Gain-Life ");
      AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_GOD_CONTRACT, Fix.BUFF_GOD_CONTRACT_JP, Fix.INFINITY, 0, 0, 0);
      ExecBuffCannotResurrect(player, target, Fix.INFINITY, 0);
      ExecBuffNoGainLife(player, target, Fix.INFINITY, 0);
    }

    return true;
  }

  /// <summary>
  /// 基本ロジックを内包した魔法攻撃実行コマンド
  /// </summary>
  private bool ExecMagicAttack(Character player, Character target, double magnify, Fix.DamageSource attr, Fix.IgnoreType ignore_target_defense, Fix.CriticalType critical, int animation_speed = MAX_ANIMATION_TIME)
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
          // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveBuffを介さない。
          buffImage.RemoveBuff();
        }
        return false; // ディバイン・フィールドで吸収された場合はヒットしたことにならない。
      }
    }

    // ハイウォーリアー・ドラゴンメイルによる効果
    if (target.IsEquip(Fix.HIGHWARRIOR_DRAGONMAIL))
    {
      int percent = SecondaryLogic.HighwarriorDragonmail_Percent(target);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.HIGHWARRIOR_DRAGONMAIL + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        double effect = SecondaryLogic.HighwarriorDragonmail_Effect(target);
        Debug.Log("Equip " + Fix.HIGHWARRIOR_DRAGONMAIL + " magic-damage reduction (before) " + damageValue + " " + effect);
        damageValue = damageValue * effect;
        Debug.Log("Equip " + Fix.HIGHWARRIOR_DRAGONMAIL + " magic-damage reduction (after ) " + damageValue + " " + effect);
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DAMAGE_IS_HALF, Fix.COLOR_GUARD);
      }
    }

    // ファントム・朧による効果
    if (target.IsPhantomOboro != null && this.NowStackInTheCommand)
    {
      damageValue = 0;
    }

    // モンスター特有
    if (target.IsReflectionShade != null)
    {
      // 効果切れ条件に合致したことによる消滅のため、AbstractRemoveTargetBuffを介さない。
      target.RemoveTargetBuff(Fix.COMMAND_REFLECTION_SHADE);
      StartAnimation(player.objGroup.gameObject, Fix.EFFECT_DAMAGE_REFLECT, Fix.COLOR_DAMAGE_REFLECT);
      ApplyDamage(player, player, damageValue, resultCritical, animation_speed);
      return true;
      // 反射に関するロジック構築は必要だが、モンスターの単発行動であるため、これで良い。
    }

    // ダメージ適用
    ApplyDamage(player, target, damageValue, resultCritical, animation_speed);

    // 追加効果
    BuffImage abyssFire = player.IsAbyssFire;
    if (abyssFire)
    {
      ExecElementalDamage(player, Fix.DamageSource.Fire, SecondaryLogic.AbyssFireValue(player));
    }

    if (player.IsStormArmor && player.Dead == false)
    {
      bool resultCritical2 = false;
      double addDamageValue = MagicDamageLogic(player, target, SecondaryLogic.StormArmor_Damage(player), Fix.DamageSource.Wind, Fix.IgnoreType.None, critical, ref resultCritical2);
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

    BuffImage theDarkIntensity = target.IsTheDarkIntensity;
    if (theDarkIntensity)
    {
      int beforeCumulative = theDarkIntensity.Cumulative;
      theDarkIntensity.Cumulative++;
      if (beforeCumulative != theDarkIntensity.Cumulative)
      {
        StartAnimation(target.objGroup.gameObject, Fix.BUFF_DARK_INTENSITY_UP_JP, Fix.COLOR_NORMAL);
      }
    }

    // 赤双授の杖による効果
    if (player.IsEquip(Fix.SEKISOUJU_ROD))
    {
      bool resultCritical2 = false;
      double addDamageValue = SecondaryLogic.SekisoujuRod_Effect(player) + MagicDamageLogic(player, target, SecondaryLogic.SekisoujuRod_Factor(player), Fix.DamageSource.Fire, Fix.IgnoreType.None, critical, ref resultCritical2);
      Debug.Log("Equip " + Fix.SEKISOUJU_ROD + " Additional Damage " + addDamageValue.ToString());
      ExecElementalDamage(target, Fix.DamageSource.Fire, addDamageValue);
    }

    // ゴルゴン・アイズ・ブックによる効果
    if (player.IsEquip(Fix.GORGON_EYES_BOOK))
    {
      double effect = SecondaryLogic.GorgonEyesBook_Effect(player);
      Debug.Log("Equip " + Fix.GORGON_EYES_BOOK + " AddBuff Poison " + effect);
      ExecBuffPoison(player, target, 2, effect);
    }

    // スター・フュージョン・オーブによる効果
    if (player.IsEquip(Fix.STAR_FUSION_ORB))
    {
      bool resultCritical2 = false;
      double addDamageValue = SecondaryLogic.StarFusionOrb_Effect(player) + MagicDamageLogic(player, target, SecondaryLogic.StarFusionOrb_Factor(player), Fix.DamageSource.HolyLight, Fix.IgnoreType.None, critical, ref resultCritical2);
      Debug.Log("Equip " + Fix.STAR_FUSION_ORB + " Additional Damage " + addDamageValue.ToString());
      ExecElementalDamage(target, Fix.DamageSource.HolyLight, addDamageValue);
    }

    // イントリンシック・フローズン・オーブによる効果
    if (player.IsEquip(Fix.INTRINSIC_FROZEN_ORB))
    {
      int percent = SecondaryLogic.IntrinsicFrozenOrb_Percent(player);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.INTRINSIC_FROZEN_ORB + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        Debug.Log("Equip " + Fix.INTRINSIC_FROZEN_ORB + " AddBuff Frozen");
        ExecBuffFreeze(player, target, SecondaryLogic.IntrinsicFrozenOrb_Turn(player), 0);
      }
    }

    // ブラック・リフレクター・シールドによる効果
    if (target.IsEquip(Fix.BLACK_REFLECTOR_SHIELD))
    {
      int percent = SecondaryLogic.BlackReflectorShield_Percent(target);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.BLACK_REFLECTOR_SHIELD + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        double effectValue = damageValue * SecondaryLogic.BlackReflectorShield_Effect(target);
        Debug.Log("Equip " + Fix.BLACK_REFLECTOR_SHIELD + " reflect damage " + effectValue.ToString());
        StartAnimation(player.objGroup.gameObject, Fix.EFFECT_DAMAGE_REFLECT, Fix.COLOR_DAMAGE_REFLECT);
        ApplyDamage(target, player, effectValue, false, animation_speed);
      }
    }

    // ブルー・スカイ・オーブによる効果
    if (player.IsEquip(Fix.BLUE_SKY_ORB))
    {
      int rand = AP.Math.RandomInteger(3);
      if (rand == 0)
      {
        double effectValue = SecondaryLogic.BlueSkyOrb_Effect(player);
        Debug.Log("Equip " + Fix.BLUE_SKY_ORB + " MagicAttackUp effect " + effectValue.ToString());
        ExecBuffMagicAttackUp(player, player, SecondaryLogic.BlueSkyOrb_Turn(player), effectValue);
      }
      else if (rand == 1)
      {
        double effectValue = SecondaryLogic.BlueSkyOrb_Effect(player);
        Debug.Log("Equip " + Fix.BLUE_SKY_ORB + " MagicDefenseUp effect " + effectValue.ToString());
        ExecBuffMagicDefenseUp(player, player, SecondaryLogic.BlueSkyOrb_Turn(player), effectValue);
      }
      else if (rand == 2)
      {
        double effectValue = SecondaryLogic.BlueSkyOrb_Effect(player);
        Debug.Log("Equip " + Fix.BLUE_SKY_ORB + " BattleResponseUp effect " + effectValue.ToString());
        ExecBuffBattleResponseUp(player, player, SecondaryLogic.BlueSkyOrb_Turn(player), effectValue);
      }
    }

    // ダークサン・トラジェディック・ブックによる効果
    if (player.IsEquip(Fix.DARKSUN_TRAGEDIC_BOOK))
    {
      int percent = SecondaryLogic.DarksunTragedicBook_Percent(player);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.DARKSUN_TRAGEDIC_BOOK + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        int random = AP.Math.RandomInteger(5);
        if (random == 0)
        {
          Debug.Log("Equip " + Fix.DARKSUN_TRAGEDIC_BOOK + " AddBuff Silence");
          ExecBuffSilent(player, target, SecondaryLogic.DarksunTragedicBook_Trun(player), 0);
        }
        else if (random == 1)
        {
          Debug.Log("Equip " + Fix.DARKSUN_TRAGEDIC_BOOK + " AddBuff Bind");
          ExecBuffBind(player, target, SecondaryLogic.DarksunTragedicBook_Trun(player), 0);
        }
        else if (random == 2)
        {
          Debug.Log("Equip " + Fix.DARKSUN_TRAGEDIC_BOOK + " AddBuff Sleep");
          ExecBuffSleep(player, target, SecondaryLogic.DarksunTragedicBook_Trun(player), 0);
        }
        else if (random == 3)
        {
          Debug.Log("Equip " + Fix.DARKSUN_TRAGEDIC_BOOK + " AddBuff Slow");
          ExecBuffSlow(player, target, SecondaryLogic.DarksunTragedicBook_Trun(player), SecondaryLogic.DarksunTragedicBook_Effect(player));
        }
        else if (random == 4)
        {
          Debug.Log("Equip " + Fix.DARKSUN_TRAGEDIC_BOOK + " AddBuff Dizzy");
          ExecBuffDizzy(player, target, SecondaryLogic.DarksunTragedicBook_Trun(player), SecondaryLogic.DarksunTragedicBook_Effect(player));
        }
      }
    }

    // スウィフトクロス・オブ・レッドサンダーによる効果
    if (target.IsEquip(Fix.SWIFTCROSS_OF_REDTHUNDER))
    {
      int percent = SecondaryLogic.SwiftcrossOFRedthunder_Percent(target);
      int rand = AP.Math.RandomInteger(100);
      Debug.Log("Equip " + Fix.SWIFTCROSS_OF_REDTHUNDER + "Percent " + percent.ToString() + " / " + rand.ToString());
      if (rand < percent)
      {
        double effectValue = damageValue * SecondaryLogic.SwiftcrossOFRedthunder_Effect(target);
        Debug.Log("Equip " + Fix.SWIFTCROSS_OF_REDTHUNDER + " reflect damage " + effectValue.ToString());
        StartAnimation(player.objGroup.gameObject, Fix.EFFECT_DAMAGE_REFLECT, Fix.COLOR_DAMAGE_REFLECT);
        ApplyDamage(target, player, effectValue, false, animation_speed);
      }
    }

    // 神剣  フェルトゥーシュによる効果
    if (player.IsEquip(Fix.LEGENDARY_FELTUS))
    {
      Debug.Log("Equip " + Fix.LEGENDARY_FELTUS + " God-Contract, Cannot-Resurrect, No-Gain-Life ");
      AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_GOD_CONTRACT, Fix.BUFF_GOD_CONTRACT_JP, Fix.INFINITY, 0, 0, 0);
      ExecBuffCannotResurrect(player, target, Fix.INFINITY, 0);
      ExecBuffNoGainLife(player, target, Fix.INFINITY, 0);
    }

    return true;
  }

  #region "Delve I"
  private void ExecFireBall(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.FireBall(player);
    stack.DamageSource = Fix.DamageSource.Fire;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.FIRE_BALL, stack);
  }

  private void ExecIceNeedle(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.IceNeedle(player);
    stack.DamageSource = Fix.DamageSource.Ice;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.ICE_NEEDLE;
    stack.ViewBuffName = Fix.ICE_NEEDLE;
    stack.Turn = SecondaryLogic.IceNeedle_Turn(player);
    stack.Effect1 = SecondaryLogic.IceNeedle_Value(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.ICE_NEEDLE, stack);
  }

  private void ExecFreshHeal(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.ShadowBlast(player);
    stack.HealValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.FreshHeal(player);
    stack.FromPotion = false;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.FRESH_HEAL, stack);
  }

  private void ExecShadowBlast(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.ShadowBlast(player);
    stack.DamageSource = Fix.DamageSource.DarkMagic;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.SHADOW_BLAST;
    stack.ViewBuffName = Fix.SHADOW_BLAST;
    stack.Turn = SecondaryLogic.ShadowBlast_Turn(player);
    stack.Effect1 = SecondaryLogic.ShadowBlast_Value(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.SHADOW_BLAST, stack);
  }

  private void ExecAirCutter(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.AirCutter(player), Fix.DamageSource.Wind, Fix.IgnoreType.None, critical);
    if (success)
    {
      AbstractAddBuff(player, player.objBuffPanel, Fix.AIR_CUTTER, Fix.AIR_CUTTER, SecondaryLogic.AirCutter_Turn(player), SecondaryLogic.AirCutter_Value(player), 0, 0);
    }
  }

  private void ExecRockSlum(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecMagicAttack(player, target, SecondaryLogic.RockSlum(player), Fix.DamageSource.Earth, Fix.IgnoreType.None, critical);
    if (success)
    {
      AbstractAddBuff(target, target.objBuffPanel, Fix.ROCK_SLAM, Fix.ROCK_SLAM, SecondaryLogic.RockSlum_Turn(player), SecondaryLogic.RockSlum_Value(player), 0, 0);
    }
  }

  private void ExecStraightSmash(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.StraightSmash(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.STRAIGHT_SMASH, stack);
  }

  private void ExecHunterShot(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.HunterShot(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.HUNTER_SHOT;
    stack.ViewBuffName = Fix.HUNTER_SHOT;
    stack.Turn = SecondaryLogic.HunterShot_Turn(player);
    stack.Effect1 = SecondaryLogic.HunterShot_Value(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.HUNTER_SHOT, stack);
  }

  private void ExecLegStrike(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.LegStrike(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.LEG_STRIKE;
    stack.ViewBuffName = Fix.LEG_STRIKE;
    stack.Turn = SecondaryLogic.LegStrike_Turn(player);
    stack.Effect1 = SecondaryLogic.LegStrike_Value(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.LEG_STRIKE, stack);
  }

  private void ExecVenomSlash(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.VenomSlash(player), Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
    if (success)
    {
      AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POISON, Fix.EFFECT_POISON, SecondaryLogic.VenomSlash_Turn(player), SecondaryLogic.VenomSlash_2(player) * PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Strength), 0, 0);
    }
  }

  private void ExecEnergyBolt(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.EnergyBolt(player);
    stack.DamageSource = Fix.DamageSource.Colorless;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.ENERGY_BOLT, stack);
  }

  private void ExecShieldBash(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.ShieldBash(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.SHIELD_BASH;
    stack.ViewBuffName = Fix.SHIELD_BASH;
    stack.Turn = SecondaryLogic.ShieldBash_Turn(player);
    stack.EffectValue = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.SHIELD_BASH, stack);
  }

  private void ExecAuraOfPower(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    AbstractAddBuff(target, target.objBuffPanel, Fix.AURA_OF_POWER, Fix.AURA_OF_POWER, SecondaryLogic.AuraOfPower_Turn(player), SecondaryLogic.AuraOfPower_Value(player), 0, 0);
  }

  private void ExecDispelMagic(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.ViewBuffName = Fix.DISPEL_MAGIC;
    stack.Num = SecondaryLogic.DispelMagic_Value(player);
    stack.BuffType = Fix.BuffType.Positive;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.DISPEL_MAGIC, stack);
  }

  private void ExecTrueSight(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.TRUE_SIGHT;
    stack.ViewBuffName = Fix.TRUE_SIGHT;
    stack.Turn = SecondaryLogic.TrueSight_Turn(player);
    stack.Effect1 = SecondaryLogic.TrueSight_Value(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.TRUE_SIGHT, stack);
  }

  private void ExecHeartOfLife(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    AbstractAddBuff(target, target.objBuffPanel, Fix.HEART_OF_LIFE, Fix.HEART_OF_LIFE, SecondaryLogic.HeartOfLife_Turn(player), SecondaryLogic.HeartOfLife(player) * PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence), 0, 0);
  }

  private void ExecDarknessCircle(Character player, Character target, BuffField target_field_obj)
  {
    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }

    AbstractAddBuff(target, target_field_obj, Fix.DARKNESS_CIRCLE, Fix.DARKNESS_CIRCLE, SecondaryLogic.DarknessCircle_Turn(player), SecondaryLogic.DarknessCircle_Value(player), 0, 0);
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

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.EffectValue = SecondaryLogic.OracleCommand(player);
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.ORACLE_COMMAND, stack);
  }
  #endregion

  #region "Delve II"
  private void ExecFlameBlade(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.FLAME_BLADE;
    stack.ViewBuffName = Fix.FLAME_BLADE;
    stack.Turn = SecondaryLogic.FlameBlade_Turn(player);
    stack.Effect1 = SecondaryLogic.FlameBlade(player);
    stack.Effect2 = SecondaryLogic.FlameBlade_BaseDamage(player);
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.FLAME_BLADE, stack);
  }

  private void ExecPurePurification(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.HealValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.PurePurificationHealValue(player);
    stack.FromPotion = false;
    stack.ViewBuffName = Fix.PURE_PURIFICATION;
    stack.Num = SecondaryLogic.PurePurification_Effect1(player);
    stack.BuffType = Fix.BuffType.Negative;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.PURE_PURIFICATION, stack);
  }

  private void ExecDivineCircle(Character player, Character target, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.DIVINE_CIRCLE;
    stack.ViewBuffName = Fix.DIVINE_CIRCLE;
    stack.Turn = SecondaryLogic.DivineCircle_Turn(player);
    stack.Effect1 = SecondaryLogic.DivineCircle_Effect1(player) * PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.TargetField = target_field_obj;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.DIVINE_CIRCLE, stack);
  }

  private void ExecBloodSign(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.BLOOD_SIGN;
    stack.ViewBuffName = Fix.BLOOD_SIGN;
    stack.Turn = SecondaryLogic.BloodSign_Turn(player);
    stack.Effect1 = SecondaryLogic.BloodSign(player) * PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.BLOOD_SIGN, stack);
  }

  private void ExecSkyShield(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    AbstractAddBuff(target, target.objBuffPanel, Fix.SKY_SHIELD, Fix.SKY_SHIELD, SecondaryLogic.SkyShield_Turn(player), SecondaryLogic.SkyShield_Value(player), 0, 0);
  }

  // true: カウンター成功
  // false: カウンター失敗
  private bool AbstractCounterStackCommand(Character player, string src_command_name, StackObject[] stack_list)
  {
    if (stack_list.Length >= 2)
    {
      int num = stack_list.Length - 2;

      Debug.Log("AbstractCounterStackCommand: " + stack_list[num].StackName);
      Debug.Log("Fix.WORD_OF_POWER          : " + Fix.WORD_OF_POWER);
      // 下記コマンドはCannot be counteredの対象
      if (stack_list[num].StackName == Fix.WORD_OF_POWER ||
          stack_list[num].StackName == Fix.IRON_BUSTER)
      {
        // Will Awakeningが無い場合は、カウンターできないまま。
        if (stack_list[num].Player.IsWillAwakening == null)
        {
          // 舞踏・一閃のみ、ダメージ０にできる。
          if (src_command_name == Fix.COMMAND_BUTOH_ISSEN)
          {
            StartAnimation(stack_list[num].gameObject, Fix.EFFECT_DAMAGE_IS_ZERO, Fix.COLOR_GUARD);
            ExecNormalAttack(player, stack_list[num].Player, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Absolute);
            Destroy(stack_list[num].gameObject);
            stack_list[num] = null;
            return true;
          }

          // 上記以外は、カウンター不可
          Debug.Log("AbstractCounterStackCommand 0 : " + stack_list[num].StackName);
          StartAnimation(stack_list[num].gameObject, Fix.EFFECT_CANNOT_BE_COUNTERED, Fix.COLOR_NORMAL);
          return false;
        }
        // Will Awakeningがあるので、カウンター
        else
        {
          Debug.Log("AbstractCounterStackCommand 1 : " + stack_list[num].StackName);
          StartAnimation(stack_list[num].gameObject, Fix.EFFECT_COUNTER, Fix.COLOR_NORMAL);
          Destroy(stack_list[num].gameObject);
          stack_list[num] = null;
          return true;
        }
      }
      // 通常コマンドは原則カウンターできる
      else
      {
        Debug.Log("AbstractCounterStackCommand 2 : " + stack_list[num].StackName);
        StartAnimation(stack_list[num].gameObject, Fix.EFFECT_COUNTER, Fix.COLOR_NORMAL);
        if (src_command_name == Fix.COMMAND_BUTOH_ISSEN)
        {
          if (ActionCommand.IsTarget(stack_list[num].StackName) == ActionCommand.TargetType.Enemy ||
              ActionCommand.IsTarget(stack_list[num].StackName) == ActionCommand.TargetType.EnemyField ||
              ActionCommand.IsTarget(stack_list[num].StackName) == ActionCommand.TargetType.EnemyGroup ||
              (ActionCommand.IsTarget(stack_list[num].StackName) == ActionCommand.TargetType.EnemyOrAlly && stack_list[num].Target == player) // リガール専用コマンドのため、これで良しとする
              )
          {
            ExecNormalAttack(player, stack_list[num].Player, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Absolute);
          }
          else
          {
            // なにもしない
          }
        }
        BuffImage seiei = player.IsStarswordSeiei;
        if (seiei)
        {
          Debug.Log("starswordSeiei additional damage 2");
          Debug.Log("Starsword-Seiei Cumulative " + seiei.Cumulative);
          ExecMagicAttack(player, stack_list[num].Player, (1.00f + 0.50f * seiei.Cumulative), Fix.DamageSource.HolyLight, Fix.IgnoreType.None, Fix.CriticalType.Random);
        }
        Destroy(stack_list[num].gameObject);
        stack_list[num] = null;

        return true;
      }
    }
    else
    {
      // とくになし
    }

    // 予期せぬ場合は対象が無いので失敗として扱う。
    return false;
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
    Debug.Log(MethodBase.GetCurrentMethod());
    One.PlaySoundEffect(Fix.SOUND_FLASH_COUNTER);

    if (stack_list.Length >= 2)
    {
      // FLASH_COUNTERがスタック先頭なので、一つ前を削除する。
      int num = stack_list.Length - 2;

      if (ActionCommand.GetAttribute(stack_list[num].StackName) == ActionCommand.Attribute.Magic &&
          (ActionCommand.GetBuffType(stack_list[num].StackName) == Fix.BuffType.Negative || ActionCommand.GetBuffType(stack_list[num].StackName) == Fix.BuffType.Positive))
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
    Debug.Log(MethodBase.GetCurrentMethod() + "(S)");
    One.PlaySoundEffect(Fix.SOUND_COUNTER_DISALLOW);
    
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
          Debug.Log("stack number: " + num);
          Debug.Log("stack_list: " + stack_list[num].Player.FullName);
          Character target = stack_list[num].Player;
          StartAnimation(stack_list[num].gameObject, "Counter!", Fix.COLOR_NORMAL);
          Destroy(stack_list[num].gameObject);
          stack_list[num] = null;

          AbstractAddBuff(target, target.objBuffPanel, Fix.COUNTER_DISALLOW, Fix.COUNTER_DISALLOW, SecondaryLogic.CounterDisallow_Turn(player), 0, 0, 0);
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
    Debug.Log(MethodBase.GetCurrentMethod() + "(S)");
    One.PlaySoundEffect(Fix.SOUND_HARDEST_PARRY);
    
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

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.EVERFLOW_MIND;
    stack.ViewBuffName = Fix.EVERFLOW_MIND;
    stack.Turn = SecondaryLogic.EverflowMind_Turn(player);
    stack.Effect1 = SecondaryLogic.EverflowMind_Effect1(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.EVERFLOW_MIND, stack);
  }

  private void ExecInnerInspiration(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.EffectValue = SecondaryLogic.InnerInspiration_Effect1(player) * target.MaxSkillPoint;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.INNER_INSPIRATION, stack);
  }

  private void ExecSeventhPrinciple(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.SEVENTH_PRINCIPLE;
    stack.ViewBuffName = Fix.SEVENTH_PRINCIPLE;
    stack.Turn = SecondaryLogic.SeventhPrinciple_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.SEVENTH_PRINCIPLE, stack);
  }

  private void ExecStanceOfTheBlade(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.StanceOfTheBladeDamage(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.STANCE_OF_THE_BLADE;
    stack.ViewBuffName = Fix.STANCE_OF_THE_BLADE;
    stack.Turn = SecondaryLogic.StanceOfTheBlade_Turn(player);
    stack.Effect1 = SecondaryLogic.StanceOfTheBlade(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.STANCE_OF_THE_BLADE, stack);
  }

  private void ExecSpeedStep(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.SpeedStepDamage(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.SPEED_STEP;
    stack.ViewBuffName = Fix.SPEED_STEP;
    stack.Turn = SecondaryLogic.SpeedStep_Turn(player);
    stack.Effect1 = SecondaryLogic.SpeedStep(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.SPEED_STEP, stack);
  }

  private void ExecStanceOfTheGuard(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.STANCE_OF_THE_GUARD;
    stack.ViewBuffName = Fix.STANCE_OF_THE_GUARD;
    stack.Turn = SecondaryLogic.StanceOfTheGuard_Turn(player);
    stack.Effect1 = SecondaryLogic.StanceOfTheGuard(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    //stack.Target = target; // 自分自身のためTargetは不要
    CreateNormalStackObject(Fix.STANCE_OF_THE_GUARD, stack);
  }

  private void ExecMultipleShot(Character player, List<Character> target_list, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.MultipleShot(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Player = player;
    stack.TargetList = target_list;
    CreateNormalStackObject(Fix.MULTIPLE_SHOT, stack);
  }

  private void ExecLeylineSchema(Character player, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.LEYLINE_SCHEMA;
    stack.ViewBuffName = Fix.LEYLINE_SCHEMA;
    stack.Turn = SecondaryLogic.LeylineSchema_Turn(player);
    stack.Effect1 = SecondaryLogic.LeylineSchema_Effect1(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.LEYLINE_SCHEMA, stack);
  }

  private void ExecInvisibleBind(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    bool success = ExecNormalAttack(player, target, SecondaryLogic.InvisibleBind(player), Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
    if (success)
    {
      AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_BIND, Fix.EFFECT_BIND, SecondaryLogic.InvibisleBind_Turn(player), 0, 0, 0);
    }
  }

  private void ExecFortuneSpirit(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.FORTUNE_SPIRIT;
    stack.ViewBuffName = Fix.FORTUNE_SPIRIT;
    stack.Turn = SecondaryLogic.FortuneSpirit_Turn(player);
    stack.Effect1 = SecondaryLogic.FortuneSpirit_Effect1(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.FORTUNE_SPIRIT, stack);
  }

  private void ExecSpiritualRest(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack0 = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack0.BuffName = Fix.EFFECT_STUN;
    stack0.ViewBuffName = Fix.EFFECT_REMOVE_STUN;
    stack0.Player = player;
    stack0.Target = target;
    stack0.SequenceNumber = 0;
    CreateNormalStackObject(Fix.SPIRITUAL_REST, stack0);

    StackObject stack1 = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack1.BuffName = Fix.BUFF_RESIST_STUN;
    stack1.ViewBuffName = Fix.BUFF_RESIST_STUN;
    stack1.Turn = SecondaryLogic.SpiritualRest_Turn(player);
    stack1.Effect1 = 0;
    stack1.Effect2 = 0;
    stack1.Effect3 = 0;
    stack1.Player = player;
    stack1.Target = target;
    stack1.SequenceNumber = 1;
    CreateNormalStackObject(Fix.SPIRITUAL_REST, stack1);
  }

  private void ExecZeroImmunity(Character player, StackObject[] stack_list)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    One.PlaySoundEffect(Fix.SOUND_ZERO_IMMUNITY);
    
    if (stack_list.Length >= 2)
    {
      int num = stack_list.Length - 2;

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
  }

  private void ExecCircleSlash(Character player, List<Character> target_list, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int ii = 0; ii < target_list.Count; ii++)
    {
      ExecNormalAttack(player, target_list[ii], SecondaryLogic.NormalAttack(player), Fix.DamageSource.Physical, Fix.IgnoreType.None, critical);
    }
  }

  private void ExecDoubleSlash(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    int totalCount = 2;
    for (int ii = 0; ii < totalCount; ii++)
    {
      StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
      stack.Magnify = SecondaryLogic.DoubleSlash(player);
      stack.DamageSource = Fix.DamageSource.Physical;
      stack.IgnoreType = Fix.IgnoreType.None;
      stack.CriticalType = critical;
      stack.AnimationSpeed = ANIMATION_TIME_HALF;
      stack.Player = player;
      stack.Target = target;
      CreateNormalStackObject(Fix.DOUBLE_SLASH, stack);
    }
  }
  #endregion

  #region "Delve III"
  private void ExecMeteorBullet(Character player, List<Character> target_list, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    int totalCount = SecondaryLogic.MeteorBullet_Effect1(player);
    for (int ii = 0; ii < totalCount; ii++)
    {
      StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
      stack.Magnify = SecondaryLogic.MeteorBullet(player);
      stack.DamageSource = Fix.DamageSource.Fire;
      stack.IgnoreType = Fix.IgnoreType.None;
      stack.CriticalType = critical;
      stack.AnimationSpeed = ANIMATION_TIME_SHORT;
      stack.Player = player;
      stack.TargetList = target_list;
      CreateNormalStackObject(Fix.METEOR_BULLET, stack);
    }
  }

  private void ExecBlueBullet(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    int totalCount = SecondaryLogic.BlueBullet_Effect1(player);
    for (int ii = 0; ii < totalCount; ii++)
    {
      StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
      stack.Magnify = SecondaryLogic.BlueBullet(player);
      stack.DamageSource = Fix.DamageSource.Ice;
      stack.IgnoreType = Fix.IgnoreType.None;
      stack.CriticalType = critical;
      stack.AnimationSpeed = ANIMATION_TIME_SHORT;
      stack.Player = player;
      stack.Target = target;
      CreateNormalStackObject(Fix.BLUE_BULLET, stack);
    }
  }

  public void ExecHolyBreath(Character player, List<Character> target_list)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.HealValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.HolyBreath(player);
    stack.FromPotion = false;
    stack.Player = player;
    stack.TargetList = target_list;
    CreateNormalStackObject(Fix.HOLY_BREATH, stack);
  }

  public void ExecBlackContract(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.BLACK_CONTRACT;
    stack.ViewBuffName = Fix.BLACK_CONTRACT;
    stack.Turn = SecondaryLogic.BlackContract_Turn(player);
    stack.Effect1 = SecondaryLogic.BlackContract(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = player;
    CreateNormalStackObject(Fix.BLACK_CONTRACT, stack);
  }

  private void ExecSonicPulse(Character player, Character target, Fix.CriticalType critical)
  {
    bool success = ExecMagicAttack(player, target, SecondaryLogic.SonicPulse(player), Fix.DamageSource.Wind, Fix.IgnoreType.None, critical);
    if (success)
    {
      AbstractAddBuff(target, target.objBuffPanel, Fix.SONIC_PULSE, Fix.SONIC_PULSE, SecondaryLogic.SonicPulse_Turn(player), SecondaryLogic.SonicPulse_Value(player), 0, 0);
    }
  }

  private void ExecLandShatter(Character player, Character target, Fix.CriticalType critical)
  {
    bool success = ExecMagicAttack(player, target, SecondaryLogic.LandShatter(player), Fix.DamageSource.Earth, Fix.IgnoreType.None, critical);
    if (success)
    {
      AbstractAddBuff(target, target.objBuffPanel, Fix.LAND_SHATTER, Fix.LAND_SHATTER, SecondaryLogic.LandShatter_Turn(player), 0, 0, 0);
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
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.ConcussiveHit(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.CONCUSSIVE_HIT;
    stack.ViewBuffName = Fix.CONCUSSIVE_HIT;
    stack.Turn = SecondaryLogic.ConcussiveHit_Turn(player);
    stack.Effect1 = SecondaryLogic.ConcussiveHit(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.CONCUSSIVE_HIT, stack);
  }

  public void ExecAetherDrive(Character player, Character target, BuffField target_field_obj)
  {
    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }

    AbstractAddBuff(player, target_field_obj, Fix.AETHER_DRIVE, Fix.AETHER_DRIVE, SecondaryLogic.AetherDrive_Turn(player), SecondaryLogic.AetherDrive_Effect(player), 0, 0);
  }

  public void ExecKillingWave(Character player, List<Character> target_list, BuffField target_field_obj)
  {
    if (target_field_obj == null) { Debug.Log("target_field_obj is null..."); return; }

    AbstractAddBuff(target_list[0], target_field_obj, Fix.KILLING_WAVE, Fix.KILLING_WAVE, SecondaryLogic.KillingWave_Turn(player), SecondaryLogic.KillingWave_Effect(player), 0, 0);
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

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.WordOfPower(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.DefenseMode;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.WORD_OF_POWER, stack);
  }

  public void ExecEyeOfTheIsshin(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.EYE_OF_THE_ISSHIN;
    stack.ViewBuffName = Fix.EYE_OF_THE_ISSHIN;
    stack.Turn = SecondaryLogic.EyeOfTheIsshin_Turn(player);
    stack.Effect1 = SecondaryLogic.EyeOfTheIsshin_Effect1(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = player;
    CreateNormalStackObject(Fix.EYE_OF_THE_ISSHIN, stack);
  }

  public void ExecBoneCrush(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.BoneCrush(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.BONE_CRUSH;
    stack.ViewBuffName = Fix.BONE_CRUSH;
    stack.Turn = SecondaryLogic.BoneCrush_Turn(player);
    stack.Effect1 = SecondaryLogic.BoneCrush_Value(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.BONE_CRUSH, stack);
  }

  public void ExecSeaStripe(Character player, Character target)
  {
    this.NowSeaStripePlayer = player;
    this.NowSeaStripeTarget = target;
    this.NowSeaStripeCounter = 0.30f * BATTLE_GAUGE_WITDH;
    this.NowSeaStripeMode = true;
  }

  public void ExecPlaySeaStripe()
  {
    if (this.NowSeaStripeCounter > 0)
    {
      float factor = (float)PrimaryLogic.BattleSpeed(this.NowSeaStripePlayer) * 2.00f;
      UpdatePlayerArrow(this.NowSeaStripePlayer, factor);
      this.NowSeaStripeCounter = this.NowSeaStripeCounter - factor * BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX;
    }

    if (this.NowSeaStripeCounter <= 0.0f)
    {
      ExecNormalAttack(this.NowSeaStripePlayer, this.NowSeaStripeTarget, 1.00f, Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Random);
      this.NowSeaStripePlayer = null;
      this.NowSeaStripeTarget = null;
      this.NowSeaStripeCounter = 0;
      this.NowSeaStripeMode = false;
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
      this.NowIrregularStepCounter = this.NowIrregularStepCounter - factor * BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX;
    }

    if (this.NowIrregularStepCounter <= 0.0f)
    {
      ExecNormalAttack(this.NowIrregularStepPlayer, this.NowIrregularStepTarget, SecondaryLogic.IrregularStep_Damage(this.NowIrregularStepPlayer), Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Random);
      this.NowIrregularStepPlayer = null;
      this.NowIrregularStepTarget = null;
      this.NowIrregularStepCounter = 0;
      this.NowIrregularStepMode = false;
    }
  }

  private void ExecPlayUnintentionalHit()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    One.PlaySoundEffect(Fix.SOUND_UNINTENTIONAL_HIT);
    if (this.NowUnintentionalHitCounter > 0)
    {
      // プレイヤーのゲージを進める
      float factor = (float)PrimaryLogic.BattleSpeed(this.NowUnintentionalHitPlayer) * 2.00f;
      UpdatePlayerArrow(this.NowUnintentionalHitPlayer, factor);

      // ターゲットのゲージを遅らせる
      float factor2 = (float)PrimaryLogic.BattleSpeed(this.NowUnintentionalHitTarget) * 2.00f;
      UpdatePlayerArrow(this.NowUnintentionalHitTarget, factor2 * -1);

      this.NowUnintentionalHitCounter = this.NowUnintentionalHitCounter - factor * BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX;
    }

    if (this.NowUnintentionalHitCounter <= 0.0f)
    {
      this.NowUnintentionalHitPlayer = null;
      this.NowUnintentionalHitTarget = null;
      this.NowUnintentionalHitCounter = 0;
      this.NowUnintentionalHitMode = false;
    }
  }

  private void ExecGodSense(Character player)
  {
    this.NowGodSensePlayer = player;
    this.NowGodSenseCounter = 0.90f * BATTLE_GAUGE_WITDH;
    this.NowGodSenseMode = true;
  }

  private void ExecPlayGodSense()
  {
    if (this.NowGodSenseCounter > 0)
    {
      // プレイヤーのゲージを進める
      float factor = (float)PrimaryLogic.BattleSpeed(this.NowGodSensePlayer) * 5.00f;
      UpdatePlayerArrow(this.NowGodSensePlayer, factor);

      this.NowGodSenseCounter = this.NowGodSenseCounter - factor * BATTLE_GAUGE_WITDH / Fix.BATTLE_SPEED_MAX;

      RectTransform rectX = NowGodSensePlayer.objArrow.GetComponent<RectTransform>();
      if (rectX.position.x >= BATTLE_GAUGE_WITDH)
      {
        if (ActionCommand.IsTarget(NowGodSensePlayer.CurrentActionCommand) == ActionCommand.TargetType.Ally)
        {
          ExecPlayerCommand(NowGodSensePlayer, NowGodSensePlayer.Target2, NowGodSensePlayer.CurrentActionCommand);
        }
        else
        {
          ExecPlayerCommand(NowGodSensePlayer, NowGodSensePlayer.Target, NowGodSensePlayer.CurrentActionCommand);
        }

        UpdatePlayerArrowZero(NowGodSensePlayer);
        BuffImage speedStep = NowGodSensePlayer.IsSpeedStep;
        if (speedStep != null)
        {
          Debug.Log("Target is speedStep, then Cumulative++");
          int beforeCumulative = speedStep.Cumulative;
          speedStep.Cumulative++;
          if (beforeCumulative != speedStep.Cumulative)
          {
            StartAnimation(NowGodSensePlayer.objGroup.gameObject, Fix.BATTLE_SPEED_UP, Fix.COLOR_NORMAL);
          }
        }
        NowGodSensePlayer.Decision = false;
      }
    }

    if (this.NowGodSenseCounter <= 0.0f)
    {
      this.NowGodSensePlayer = null;
      this.NowGodSenseCounter = 0;
      this.NowGodSenseMode = false;
    }
  }

  public void ExecSigilOfThePending(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.SIGIL_OF_THE_PENDING;
    stack.ViewBuffName = Fix.SIGIL_OF_THE_PENDING;
    stack.Turn = SecondaryLogic.SigilOfThePending_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.SIGIL_OF_THE_PENDING, stack);
  }

  public void ExecStormArmor(Character player, Character target)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.STORM_ARMOR, Fix.STORM_ARMOR, SecondaryLogic.StormArmor_Turn(player), SecondaryLogic.StormArmor_SpeedUp(player), SecondaryLogic.StormArmor_Damage(player), 0);
  }

  public void ExecMuteImpulse(Character player, Character target, Fix.CriticalType critical)
  {
    int positiveCount = target.GetPositiveBuff() + 1;
    ExecMagicAttack(player, target, SecondaryLogic.MuteImpulse(player) * positiveCount, Fix.DamageSource.Colorless, Fix.IgnoreType.None, critical);
  }

  public void ExecVoiceOfVigor(Character player, List<Character> target_list)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.VOICE_OF_VIGOR;
    stack.ViewBuffName = Fix.VOICE_OF_VIGOR;
    stack.Turn = SecondaryLogic.VoiceOfVigor_Turn(player);
    stack.Effect1 = SecondaryLogic.VoiceOfVigor(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.TargetList = target_list;
    CreateNormalStackObject(Fix.VOICE_OF_VIGOR, stack);
  }

  public void ExecUnseenAid(Character player, List<Character> target_list)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.ViewBuffName = Fix.BUFF_REMOVE_ALL;
    stack.Player = player;
    stack.TargetList = target_list;
    CreateNormalStackObject(Fix.UNSEEN_AID, stack);
  }
  #endregion

  #region "Delve IV"
  public void ExecGaleWind(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.GALE_WIND;
    stack.ViewBuffName = Fix.GALE_WIND;
    stack.Turn = SecondaryLogic.GaleWind_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    CreateNormalStackObject(Fix.GALE_WIND, stack);
  }

  public void ExecFreezingCube(Character player, Character target, BuffField target_field_obj, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.FreezingCube(player);
    stack.DamageSource = Fix.DamageSource.Ice;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.FREEZING_CUBE;
    stack.ViewBuffName = Fix.FREEZING_CUBE;
    stack.Turn = SecondaryLogic.FreezingCube_Turn(player);
    stack.Effect1 = SecondaryLogic.FreezingCube_Effect(player);
    stack.Effect2 = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.FreezingCube_Effect2(player);
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.FREEZING_CUBE, stack);
  }

  private void ExecVolcanicBlaze(Character player, List<Character> target_list, BuffField target_field_obj, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.VolcanicBlaze(player);
    stack.DamageSource = Fix.DamageSource.Fire;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.VOLCANIC_BLAZE;
    stack.ViewBuffName = Fix.VOLCANIC_BLAZE;
    stack.Turn = SecondaryLogic.VolcanicBlaze_Turn(player);
    stack.Effect1 = SecondaryLogic.VolcanicBlaze_Effect(player);
    stack.Effect2 = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.VolcanicBlaze_Effect2(player);
    stack.Effect3 = 0;
    stack.Player = player;
    stack.TargetList = target_list;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.VOLCANIC_BLAZE, stack);
  }

  private void ExecIronBuster(Character player, Character target, List<Character> target_list, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.IronBuster(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Player = player;
    stack.Target = target;
    stack.SequenceNumber = 0;
    CreateNormalStackObject(Fix.IRON_BUSTER, stack);

    StackObject stack1 = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack1.Magnify = SecondaryLogic.IronBuster_2(player);
    stack1.DamageSource = Fix.DamageSource.Physical;
    stack1.IgnoreType = Fix.IgnoreType.None;
    stack1.CriticalType = critical;
    stack1.AnimationSpeed = MAX_ANIMATION_TIME;
    stack1.Player = player;
    stack1.TargetList = target_list;
    stack1.SequenceNumber = 1;
    CreateNormalStackObject(Fix.IRON_BUSTER, stack1);
  }

  private void ExecAngelicEcho(Character player, List<Character> target_list, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.HealValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.AngelicEcho(player);
    stack.FromPotion = false;
    stack.Player = player;
    stack.TargetList = target_list;
    stack.SequenceNumber = 0;
    CreateNormalStackObject(Fix.ANGELIC_ECHO, stack);

    StackObject stack1 = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack1.BuffName = Fix.ANGELIC_ECHO;
    stack1.ViewBuffName = Fix.ANGELIC_ECHO;
    stack1.Turn = SecondaryLogic.AngelicEcho_Turn(player);
    stack1.Effect1 = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.AngelicEcho_Effect(player);
    stack1.Effect2 = 0;
    stack1.Effect3 = 0;
    stack1.Player = player;
    stack1.TargetField = target_field_obj;
    stack1.SequenceNumber = 1;
    CreateNormalStackObject(Fix.ANGELIC_ECHO, stack1);
  }

  private void ExecCursedEvangile(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.CursedEvangile(player);
    stack.DamageSource = Fix.DamageSource.DarkMagic;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.CURSED_EVANGILE;
    stack.ViewBuffName = Fix.CURSED_EVANGILE;
    stack.Turn = SecondaryLogic.CursedEvangile_Turn(player);
    stack.Effect1 = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.CursedEvangile_Effect(player);
    stack.Effect2 = SecondaryLogic.CursedEvangile_SlepTurn(player);
    stack.Effect3 = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.CursedEvangile_SlipFactor(player);
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.CURSED_EVANGILE, stack);
  }

  private void ExecPenetrationArrow(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.PenetrationArrow(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.DefenseMode;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.PENETRATION_ARROW;
    stack.ViewBuffName = Fix.PENETRATION_ARROW;
    stack.Turn = SecondaryLogic.PenetrationArrow_Turn(player);
    stack.Effect1 = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Strength) * SecondaryLogic.PenetrationArrow_Effect(player);
    stack.Effect2 = SecondaryLogic.PenetrationArrow_Effect2(player);
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.PENETRATION_ARROW, stack);
  }

  private void ExecCircleOfTheSerenity(Character player, List<Character> target_list, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.CIRCLE_OF_SERENITY;
    stack.ViewBuffName = Fix.CIRCLE_OF_SERENITY;
    stack.Turn = SecondaryLogic.CircleOfTheSerenity_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.TargetList = target_list;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.CIRCLE_OF_SERENITY, stack);
  }

  private void ExecRagingStorm(Character player, List<Character> target_list, BuffField target_field_obj, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    for (int jj = 0; jj < 2; jj++)
    {
      StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
      stack.Magnify = SecondaryLogic.RagingStorm(player);
      stack.DamageSource = Fix.DamageSource.Physical;
      stack.IgnoreType = Fix.IgnoreType.None;
      stack.CriticalType = critical;
      stack.AnimationSpeed = ANIMATION_TIME_HALF;
      stack.Player = player;
      stack.TargetList = target_list;
      stack.SequenceNumber = 0;
      CreateNormalStackObject(Fix.RAGING_STORM, stack);
    }

    StackObject stackBuff = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stackBuff.Turn = SecondaryLogic.RagingStorm_Turn(player);
    stackBuff.Effect1 = SecondaryLogic.RagingStorm_Effect1(player);
    stackBuff.Effect2 = 0;
    stackBuff.Effect3 = 0;
    stackBuff.Player = player;
    stackBuff.TargetField = target_field_obj;
    stackBuff.SequenceNumber = 1;

    CreateNormalStackObject(Fix.RAGING_STORM, stackBuff);
  }

  private void ExecPrecisionStrike(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    One.PlaySoundEffect(Fix.SOUND_PRECISION_STRIKE);
    ExecNormalAttack(player, target, SecondaryLogic.PrecisionStrike(player), Fix.DamageSource.Physical, Fix.IgnoreType.None, Fix.CriticalType.Absolute);
  }

  private void ExecUnintentionalHit(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.UnintentionalHit(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Turn = SecondaryLogic.UnintentionalHit_Turn(player);
    stack.EffectValue = 0;
    stack.NowCommandCounter = SecondaryLogic.UnintentionalHit_GaugeStep(player) * BATTLE_GAUGE_WITDH;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.UNINTENTIONAL_HIT, stack);
  }

  private void ExecWillAwakening(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.WILL_AWAKENING;
    stack.ViewBuffName = Fix.WILL_AWAKENING;
    stack.Turn = SecondaryLogic.WillAwakening_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.WILL_AWAKENING, stack);
  }

  private void ExecPhantomOboro(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.PHANTOM_OBORO;
    stack.ViewBuffName = Fix.PHANTOM_OBORO;
    stack.Turn = SecondaryLogic.PhantomOboro_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    CreateNormalStackObject(Fix.PHANTOM_OBORO, stack);
  }

  private void ExecDeadlyDrive(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.DEADLY_DRIVE;
    stack.ViewBuffName = Fix.DEADLY_DRIVE;
    stack.Turn = SecondaryLogic.DeadlyDrive_Turn(player);
    stack.Effect1 = SecondaryLogic.DeadlyDrive_Effect1(player);
    stack.Effect2 = SecondaryLogic.DeadlyDrive_Effect2(player);
    stack.Effect3 = SecondaryLogic.DeadlyDrive_Effect3(player);
    stack.Player = player;
    stack.Target = player;
    CreateNormalStackObject(Fix.DEADLY_DRIVE, stack);
  }

  private void ExecDominationField(Character player, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.DOMINATION_FIELD;
    stack.ViewBuffName = Fix.DOMINATION_FIELD;
    stack.Turn = SecondaryLogic.DominationField_Turn(player);
    stack.Effect1 = SecondaryLogic.DominationField_Effect1(player);
    stack.Effect2 = SecondaryLogic.DominationField_Effect2(player);
    stack.Effect3 = 0;
    stack.Player = player;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.DOMINATION_FIELD, stack);
  }
  #endregion

  #region "Delve V"
  private void ExecFlameStrike(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.FlameStrike(player);
    stack.DamageSource = Fix.DamageSource.Fire;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.FLAME_STRIKE;
    stack.ViewBuffName = Fix.FLAME_STRIKE;
    stack.Turn = SecondaryLogic.FlameStrike_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.FLAME_STRIKE, stack);
  }

  private void ExecFrostLance(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.FrostLance(player);
    stack.DamageSource = Fix.DamageSource.Ice;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.FROST_LANCE;
    stack.ViewBuffName = Fix.FROST_LANCE;
    stack.Turn = SecondaryLogic.FrostLance_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.FROST_LANCE, stack);
  }

  private void ExecShiningHeal(Character player, Character target, Fix.CriticalType critical, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.HealValue = target.MaxLife;
    stack.FromPotion = false;
    stack.BuffName = Fix.SHINING_HEAL;
    stack.ViewBuffName = Fix.SHINING_HEAL;
    stack.Turn = SecondaryLogic.ShiningHeal_Turn(player);
    stack.Effect1 = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.ShiningHeal_Effect1(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.SHINING_HEAL, stack);
  }

  private void ExecCircleOfTheDespair(Character player, Character target, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.CIRCLE_OF_THE_DESPAIR;
    stack.ViewBuffName = Fix.CIRCLE_OF_THE_DESPAIR;
    stack.Turn = SecondaryLogic.CircleOfDespair_Turn(player);
    stack.Effect1 = SecondaryLogic.CircleOfDespair_Effect1(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.CIRCLE_OF_THE_DESPAIR, stack);
  }
  #endregion

  #region "Delve VI"
  private void ExecCircleOfTheIgnite(Character player, Character target, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.CIRCLE_OF_THE_IGNITE;
    stack.ViewBuffName = Fix.CIRCLE_OF_THE_IGNITE;
    stack.Turn = SecondaryLogic.CircleOfTheIgnite_Turn(player);
    stack.Effect1 = player.TotalIntelligence * SecondaryLogic.CircleOfTheIgnite_Effect(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.CIRCLE_OF_THE_IGNITE, stack);
  }

  private void ExecWaterPresence(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.WATER_PRESENCE;
    stack.ViewBuffName = Fix.WATER_PRESENCE;
    stack.Turn = SecondaryLogic.WaterPresence_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.WATER_PRESENCE, stack);
  }

  private void ExecValkyrieBlade(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.VALKYRIE_BLADE;
    stack.ViewBuffName = Fix.VALKYRIE_BLADE;
    stack.Turn = SecondaryLogic.ValkyrieBlade_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.VALKYRIE_BLADE, stack);
  }

  private void ExecTheDarkIntensity(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.THE_DARK_INTENSITY;
    stack.ViewBuffName = Fix.THE_DARK_INTENSITY;
    stack.Turn = SecondaryLogic.TheDarkIntensity_Turn(player);
    stack.Effect1 = SecondaryLogic.TheDarkIntensity_Effect(player);
    stack.Effect2 = SecondaryLogic.TheDarkIntensity_Effect2(player);
    stack.Effect3 = 0;
    stack.Decrease = 0.50f;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.THE_DARK_INTENSITY, stack);
  }

  private void ExecFutureVision(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.FUTURE_VISION;
    stack.ViewBuffName = Fix.FUTURE_VISION;
    stack.Turn = SecondaryLogic.FutureVision_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    CreateNormalStackObject(Fix.FUTURE_VISION, stack);
  }

  private void ExecDetachmentFault(Character player, Character target, BuffField player_field_obj, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.DETACHMENT_FAULT;
    stack.ViewBuffName = Fix.DETACHMENT_FAULT;
    stack.Turn = SecondaryLogic.DetachmentFault_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    stack.TargetField = player_field_obj;
    stack.SequenceNumber = 0;
    CreateNormalStackObject(Fix.DETACHMENT_FAULT, stack);

    StackObject stack1 = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack1.BuffName = Fix.DETACHMENT_FAULT;
    stack1.ViewBuffName = Fix.DETACHMENT_FAULT;
    stack1.Turn = SecondaryLogic.DetachmentFault_Turn(player);
    stack1.Effect1 = 0;
    stack1.Effect2 = 0;
    stack1.Effect3 = 0;
    stack1.Player = player;
    stack1.Target = target;
    stack1.TargetField = target_field_obj;
    stack1.SequenceNumber = 1;
    CreateNormalStackObject(Fix.DETACHMENT_FAULT, stack1);
  }

  private void ExecStanceoftheIai(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.STANCE_OF_THE_IAI;
    stack.ViewBuffName = Fix.BUFF_STANCE_OF_THE_IAI_JP;
    stack.Turn = SecondaryLogic.StanceoftheIai_Turn(player);
    stack.Effect1 = SecondaryLogic.StanceoftheIai_Effect(player);
    stack.Effect2 = SecondaryLogic.StanceoftheIai_Effect2(player);
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = player;
    CreateNormalStackObject(Fix.STANCE_OF_THE_IAI, stack);
  }

  private void ExecOneImmunity(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.ONE_IMMUNITY;
    stack.ViewBuffName = Fix.BUFF_ONE_IMMUNITY_JP;
    stack.Turn = SecondaryLogic.OneImmunity_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = player;
    CreateNormalStackObject(Fix.ONE_IMMUNITY, stack);
  }

  private void ExecStanceofMuin(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.STANCE_OF_MUIN;
    stack.ViewBuffName = Fix.BUFF_STANCE_OF_MUIN_JP;
    stack.Turn = SecondaryLogic.StanceofMuin_Turn(player);
    stack.Effect1 = SecondaryLogic.StanceofMuin_Effect(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = player;
    CreateNormalStackObject(Fix.STANCE_OF_MUIN, stack);
  }

  private void ExecEternalConcentration(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());


    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.ETERNAL_CONCENTRATION;
    stack.ViewBuffName = Fix.BUFF_ETERNAL_CONCENTRATION_JP;
    stack.Turn = SecondaryLogic.EternalConcentration_Turn(player);
    stack.Effect1 = SecondaryLogic.EternalConcentration_Effect(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = player;
    CreateNormalStackObject(Fix.ETERNAL_CONCENTRATION, stack);
  }

  private void ExecSigiloftheFaith(Character player, Character target, BuffField player_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.SIGIL_OF_THE_FAITH;
    stack.ViewBuffName = Fix.BUFF_SIGIL_OF_THE_FAITH_JP;
    stack.Turn = SecondaryLogic.SigilOfTheFaith_Turn(player);
    stack.Effect1 = SecondaryLogic.SigilOfTheFaith_Effect(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    stack.TargetField = player_field_obj;
    stack.SequenceNumber = 0;
    CreateNormalStackObject(Fix.SIGIL_OF_THE_FAITH, stack);

    StackObject stack1 = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack1.Player = player;
    stack1.Target = target;
    stack1.TargetField = player_field_obj;
    stack1.SequenceNumber = 1;
    CreateNormalStackObject(Fix.SIGIL_OF_THE_FAITH, stack1);
  }
  #endregion

  #region "Delve VII"
  private void ExecLavaAnnihilation(Character player, List<Character> target_list, BuffField target_field_obj, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.LavaAnnihilation(player);
    stack.DamageSource = Fix.DamageSource.Fire;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Player = player;
    stack.TargetList = target_list;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.LAVA_ANNIHILATION, stack);
  }

  private void ExecAbsoluteZero(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.ABSOLUTE_ZERO;
    stack.ViewBuffName = Fix.BUFF_ABSOLUTE_ZERO_JP;
    stack.Turn = SecondaryLogic.AbsoluteZero_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.ABSOLUTE_ZERO, stack);
  }

  private void ExecResurrection(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    // 空スタックで復活呪文が実行されるまでのスリープを実現。
    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Player = player;
    stack.Target = target;
    stack.SequenceNumber = 0;
    CreateNormalStackObject(Fix.RESURRECTION, stack);

    StackObject stack1 = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack1.HealValue = (target.MaxLife / 2.0f);
    stack1.Player = player;
    stack1.Target = target;
    stack1.SequenceNumber = 1;
    CreateNormalStackObject(Fix.RESURRECTION, stack1);
  }

  private void ExecDeathScythe(Character player, Character target, BuffField target_field_obj)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.DEATH_SCYTHE;
    stack.ViewBuffName = Fix.BUFF_DEATH_SCYTHE_JP;
    stack.Turn = SecondaryLogic.DeathScythe_Turn(player);
    stack.Effect1 = SecondaryLogic.DeathScythe_Effect(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    stack.TargetField = target_field_obj;
    CreateNormalStackObject(Fix.DEATH_SCYTHE, stack);
  }

  private void ExecGenesis(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    // 空スタックでGenesisが実行されるまでのスリープを実現。
    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Player = player;
    stack.SequenceNumber = 0;
    stack.AnimationSpeed = ANIMATION_TIME_HALF;
    CreateNormalStackObject(Fix.SOUND_GENESIS, stack);

    StackObject stack1 = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack1.Player = player;
    stack1.SequenceNumber = 1;
    CreateNormalStackObject(Fix.SOUND_GENESIS, stack1);
  }

  private void ExecTimeStop(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.TIME_STOP;
    stack.ViewBuffName = Fix.BUFF_TIME_STOP;
    stack.Turn = SecondaryLogic.TimeStop_Turn(player);
    stack.Effect1 = SecondaryLogic.TimeStop_Effect(player);
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    CreateNormalStackObject(Fix.TIME_STOP, stack);
  }

  private void ExecKineticSmash(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.KineticSmash_Effect(player);
    stack.DamageSource = Fix.DamageSource.PhysicalMixed;
    stack.IgnoreType = Fix.IgnoreType.None;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.KINETIC_SMASH, stack);
  }

  private void ExecCatastrophe(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.Catastrophe(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.Both;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.CATASTROPHE, stack);
  }

  private void ExecCarnageRush(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());


    for (int ii = 0; ii < SecondaryLogic.CarnageRush_Count(player); ii++)
    {
      StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
      stack.Magnify = SecondaryLogic.CarnageRush(player);
      stack.DamageSource = Fix.DamageSource.Physical;
      stack.IgnoreType = Fix.IgnoreType.None;
      stack.CriticalType = critical;
      if (ii < SecondaryLogic.CarnageRush_Count(player) - 1) { stack.AnimationSpeed = ANIMATION_TIME_SHORT; }
      else { stack.AnimationSpeed = MAX_ANIMATION_TIME; }
      ;
      stack.Player = player;
      stack.Target = target;
      if (ii < SecondaryLogic.CarnageRush_Count(player) - 1) { stack.SequenceNumber = 0; }
      else { stack.SequenceNumber = 1; }
      CreateNormalStackObject(Fix.CARNAGE_RUSH, stack);
    }
  }

  private void ExecPiercingArrow(Character player, Character target, Fix.CriticalType critical)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.Magnify = SecondaryLogic.PiercingArrow(player);
    stack.DamageSource = Fix.DamageSource.Physical;
    stack.IgnoreType = Fix.IgnoreType.DefenseMode;
    stack.CriticalType = critical;
    stack.AnimationSpeed = MAX_ANIMATION_TIME;
    stack.BuffName = Fix.PIERCING_ARROW;
    stack.ViewBuffName = Fix.BUFF_PIERCING_ARROW_JP;
    stack.Turn = SecondaryLogic.PiercingArrow_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.PIERCING_ARROW, stack);
  }

  private void ExecStanceoftheKokoroe(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.STANCE_OF_THE_KOKOROE;
    stack.ViewBuffName = Fix.BUFF_STANCE_OF_THE_KOKOROE_JP;
    stack.Turn = SecondaryLogic.StanceoftheKokoroe_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = player;
    CreateNormalStackObject(Fix.STANCE_OF_THE_KOKOROE, stack);
  }

  private void ExecTranscendenceReached(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    StackObject stack = Instantiate(this.prefab_Stack, GroupNormalStack.transform.localPosition, Quaternion.identity) as StackObject;
    stack.BuffName = Fix.TRANSCENDENCE_REACHED;
    stack.ViewBuffName = Fix.BUFF_TRANSCENDENCE_REACHED;
    stack.Turn = SecondaryLogic.TranscendenceReached_Turn(player);
    stack.Effect1 = 0;
    stack.Effect2 = 0;
    stack.Effect3 = 0;
    stack.Player = player;
    stack.Target = target;
    CreateNormalStackObject(Fix.TRANSCENDENCE_REACHED, stack);
  }
  #endregion

  private bool ExecUseRedPotion(Character player, Character target, string command_name)
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

    if (target.IsEnemy)
    {
      if (target.Backpack.Contains(itemName) == false)
      {
        Debug.Log("Red Potion [Enemy] was not found... then miss.");
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
        return false;
      }

      Item current = new Item(itemName);
      target.Backpack.Remove(itemName);
      double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
      AbstractHealCommand(null, target, effectValue, true);
      return true;
    }
    else
    {
      if (One.TF.FindBackPackItem(itemName) == false)
      {
        Debug.Log("Red Potion was not found... then miss.");
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
        return false;
      }

      Item current = new Item(itemName);
      One.TF.DeleteBackpack(current, 1);
      double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
      AbstractHealCommand(player, target, effectValue, true);
      return true;
    }
  }

  private bool ExecUseBluePotion(Character player, Character target, string command_name)
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

    if (target.IsEnemy)
    {
      if (target.Backpack.Contains(itemName) == false)
      {
        Debug.Log("Blue Potion [Enemy] was not found... then miss.");
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
        return false;
      }

      Item current = new Item(itemName);
      target.Backpack.Remove(itemName);
      double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
      AbstractGainManaPoint(player, target, effectValue);
      return true;
    }
    else
    {
      if (One.TF.FindBackPackItem(itemName) == false)
      {
        Debug.Log("Blue Potion was not found... then miss.");
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
        return false;
      }

      Item current = new Item(itemName);
      One.TF.DeleteBackpack(current, 1);
      double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
      AbstractGainManaPoint(null, target, effectValue);
      return true;
    }
  }

  private bool ExecUseGreenPotion(Character player, Character target, string command_name)
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

    if (target.IsEnemy)
    {
      if (target.Backpack.Contains(itemName) == false)
      {
        Debug.Log("Green Potion [Enemy] was not found... then miss.");
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
        return false;
      }

      Item current = new Item(itemName);
      target.Backpack.Remove(itemName);
      double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
      AbstractGainSkillPoint(null, target, effectValue);
      return true;
    }
    else
    {
      if (One.TF.FindBackPackItem(itemName) == false)
      {
        Debug.Log("Green Potion was not found... then miss.");
        StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
        return false;
      }
      Item current = new Item(itemName);
      One.TF.DeleteBackpack(current, 1);
      double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
      AbstractGainSkillPoint(player, target, effectValue);
      return true;
    }

  }

  private bool ExecPureCleanWater(Character player, Character target)
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
    AbstractHealCommand(player, target, effectValue, true);
    return true;
  }

  private bool ExecSinseisui(Character player, Character target)
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

  private bool ExecVitalityWater(Character player, Character target)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    if (One.TF.FindBackPackItem(Fix.PURE_VITALIRY_WATER) == false)
    {
      Debug.Log("PURE_VITALIRY_WATER is nothing...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_NO_POTION, Fix.COLOR_NORMAL);
      return false;
    }
    if (One.TF.AlreadyVitalityWater)
    {
      Debug.Log("PURE_VITALIRY_WATER is already used...then miss.");
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_ALREADY_USED, Fix.COLOR_NORMAL);
      return false;
    }

    One.TF.AlreadyVitalityWater = true;
    double effectValue = target.MaxSkillPoint;
    AbstractGainSkillPoint(null, target, effectValue);
    return true;
  }

  private void ExecLifeGain(Character player, Character target, double effectValue)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    AbstractHealCommand(player, target, effectValue, false);
  }

  private void ExecLifeDownCurrent(Character target, double decrease)
  {
    int result = (int)((double)target.CurrentLife * decrease);
    Debug.Log("ExecLifeDownCurrent: " + target.FullName + " " + result.ToString() + " damage");
    target.CurrentLife -= result;
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL);
  }

  private void ExecLifeDown(Character target, double decrease)
  {
    int result = (int)((double)target.MaxLife * decrease);
    Debug.Log("ExecLifeDown: " + target.FullName + " " + result.ToString() + " damage");
    target.CurrentLife -= result;
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_NORMAL);
  }

  private void ExecLifeOne(Character target)
  {
    int result = 1;
    Debug.Log("ExecLifeOne: " + target.FullName + " life " + result.ToString());
    target.CurrentLife = 1;
    StartAnimation(target.objGroup.gameObject, "ライフ １", Fix.COLOR_NORMAL);
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


    if (target.IsOneImmunity)
    {
      effect_value = 0;
      StartAnimation(target.objGroup.gameObject, Fix.BUFF_ONE_IMMUNITY_JP, Fix.COLOR_GUARD);
    }

    if (target.IsPhantomOboro)
    {
      effect_value = 0;
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DAMAGE_IS_ZERO, Fix.COLOR_GUARD);
    }

    BuffImage holyWisdom = target.SearchFieldBuff(Fix.HOLY_WISDOM);
    if (holyWisdom)
    {
      holyWisdom.CumulativeDown(1);
      effect_value = 0;
      StartAnimation(target.objGroup.gameObject, Fix.BUFF_HOLY_WISDOM_JP, Fix.COLOR_GUARD);
    }

    BuffImage absolutePerfection = target.IsAbsolutePerfection;
    if (absolutePerfection)
    {
      effect_value = 0;
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DAMAGE_IS_ZERO, Fix.COLOR_GUARD);
    }

    BuffImage oathOfGod = target.IsOathOfGod;
    if (oathOfGod)
    {
      effect_value = 0;
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DAMAGE_IS_ZERO, Fix.COLOR_GUARD);
    }

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

    if (target.GetResistSlipLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_SLIP, Fix.COLOR_RESIST_ENABLE);
      return;
    }

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
      player.DetectCannotBePoison = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POISON, Fix.EFFECT_POISON, turn, effect_value, 0, 0);
  }

  private void ExecBuffSilent(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistSilenceLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_SILENCE, Fix.COLOR_NORMAL);
      player.DetectCannotBeSilence = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_SILENT, Fix.EFFECT_SILENT, turn, effect_value, 0, 0);
  }

  private void ExecBuffBind(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistBindLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_BIND, Fix.COLOR_NORMAL);
      player.DetectCannotBeBind = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_BIND, Fix.EFFECT_BIND, turn, effect_value, 0, 0);
  }

  private void ExecBuffSleep(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistSleepLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_SLEEP, Fix.COLOR_NORMAL);
      player.DetectCannotBeSleep = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_SLEEP, Fix.EFFECT_SLEEP, turn, effect_value, 0, 0);
  }

  private void ExecBuffStun(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistStunLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_STUN, Fix.COLOR_NORMAL);
      player.DetectCannotBeStun = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_STUN, Fix.EFFECT_STUN, turn, effect_value, 0, 0);
  }

  private void ExecBuffParalyze(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistParalyzeLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_PARALYZE, Fix.COLOR_NORMAL);
      player.DetectCannotBeParalyze = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_PARALYZE, Fix.EFFECT_PARALYZE, turn, effect_value, 0, 0);
  }

  private void ExecBuffFreeze(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistFreezeLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_FREEZE, Fix.COLOR_NORMAL);
      player.DetectCannotBeFrozen = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_FREEZE, Fix.EFFECT_FREEZE, turn, effect_value, 0, 0);
  }

  private void ExecBuffFear(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistFearLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_FEAR, Fix.COLOR_NORMAL);
      player.DetectCannotBeFear = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_FEAR, Fix.EFFECT_FEAR, turn, effect_value, 0, 0);
  }

  private void ExecBuffSlow(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistSlowLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_SLOW, Fix.COLOR_NORMAL);
      player.DetectCannotBeSlow = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_SLOW, Fix.EFFECT_SLOW, turn, effect_value, 0, 0);
  }

  private void ExecBuffDizzy(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistDizzyLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_DIZZY, Fix.COLOR_NORMAL);
      player.DetectCannotBeDizzy = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_DIZZY, Fix.EFFECT_DIZZY, turn, effect_value, 0, 0);
  }

  private void ExecBuffSlip(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistSlipLogic())
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_SLIP, Fix.COLOR_NORMAL);
      player.DetectCannotBeSlip = true;
      return;
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_SLIP, Fix.EFFECT_SLIP, turn, effect_value, 0, 0);
  }

  private void ExecBuffCannotResurrect(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistCannotResurrectLogic())
    {
      if (player.IsEquip(Fix.LEGENDARY_FELTUS))
      {
        Debug.Log("Equip " + Fix.LEGENDARY_FELTUS + " Immune Resist-Cannot-Resurrect !");
        StartAnimation(target.objGroup.gameObject, Fix.EFEECT_IMMUNE_RESIST, Fix.COLOR_WARNING);
        AbstractRemoveTargetBuff(target, target.objBuffPanel, Fix.BUFF_RESIST_CANNOT_RESURRECT, "");
      }
      else
      {
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_CANNOT_RESURRECT, Fix.COLOR_NORMAL);
        player.DetectCannotBeNoResurrection = true;
        return;
      }
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_CANNOT_RESURRECT, Fix.EFFECT_CANNOT_RESURRECT, turn, effect_value, 0, 0);
  }

  private void ExecBuffNoGainLife(Character player, Character target, int turn, double effect_value)
  {
    if (target.GetResistNoGainLife())
    {
      if (player.IsEquip(Fix.LEGENDARY_FELTUS))
      {
        Debug.Log("Equip " + Fix.LEGENDARY_FELTUS + " Immune Resist-NoGainLife !");
        StartAnimation(target.objGroup.gameObject, Fix.EFEECT_IMMUNE_RESIST, Fix.COLOR_WARNING);
        AbstractRemoveTargetBuff(target, target.objBuffPanel, Fix.BUFF_RESIST_NO_GAIN_LIFE, "");
      }
      else
      {
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESIST_NO_GAIN_LIFE, Fix.COLOR_NORMAL);
        player.DetectCannotBeNoGainLife = true;
        return;
      }
    }

    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_NO_GAIN_LIFE, Fix.EFFECT_NO_GAIN_LIFE, turn, effect_value, 0, 0);
  }

  private void ExecBuffPhysicalAttackUp(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_PA_UP, Fix.EFFECT_PA_UP, turn, effect_value, 0, 0);
  }
  private void ExecBuffPhysicalAttackDown(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_PA_DOWN, Fix.EFFECT_PA_DOWN, turn, effect_value, 0, 0);
  }

  private void ExecBuffPhysicalDefenseUp(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_PD_UP, Fix.EFFECT_PD_UP, turn, effect_value, 0, 0);
  }

  /// <summary>
  /// 物理防御力をDOWNさせるBUFFを付与する。
  /// 値が大きいほど、DOWN効果が大きい。
  /// </summary>
  private void ExecBuffPhysicalDefenseDown(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_PD_DOWN, Fix.EFFECT_PD_DOWN, turn, effect_value, 0, 0);
  }

  private void ExecBuffMagicAttackUp(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_MA_UP, Fix.EFFECT_MA_UP, turn, effect_value, 0, 0);
  }

  private void ExecBuffMagicAttackDown(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_MA_DOWN, Fix.EFFECT_MA_DOWN, turn, effect_value, 0, 0);
  }

  private void ExecBuffMagicDefenseUp(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_MD_UP, Fix.EFFECT_MD_UP, turn, effect_value, 0, 0);
  }

  private void ExecBuffMagicDefenseDown(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_MD_DOWN, Fix.EFFECT_MD_DOWN, turn, effect_value, 0, 0);
  }

  private void ExecBuffBattleSpeedUp(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_BS_UP, Fix.EFFECT_BS_UP, turn, effect_value, 0, 0);
  }

  private void ExecBuffBattleSpeedDown(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_BS_DOWN, Fix.EFFECT_BS_DOWN, turn, effect_value, 0, 0);
  }

  private void ExecBuffBattleResponseUp(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_BR_UP, Fix.EFFECT_BR_UP, turn, effect_value, 0, 0);
  }

  private void ExecBuffBattleResponseDown(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_BR_DOWN, Fix.EFFECT_BR_DOWN, turn, effect_value, 0, 0);
  }

  private void ExecBuffBattlePotentialUp(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_PO_UP, Fix.EFFECT_PO_UP, turn, effect_value, 0, 0);
  }

  private void ExecBuffBattlePotentialDown(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_PO_DOWN, Fix.EFFECT_PO_DOWN, turn, effect_value, 0, 0);
  }

  private void BuffUpFire(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERUP_FIRE, Fix.EFFECT_POWERUP_FIRE, turn, effect_value, 0, 0);
  }

  private void BuffDownFire(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERDOWN_FIRE, Fix.EFFECT_POWERDOWN_FIRE, turn, effect_value, 0, 0);
  }

  private void BuffUpIce(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERUP_ICE, Fix.EFFECT_POWERUP_ICE, turn, effect_value, 0, 0);
  }

  private void BuffDownIce(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERDOWN_ICE, Fix.EFFECT_POWERDOWN_ICE, turn, effect_value, 0, 0);
  }

  private void BuffUpLight(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERUP_LIGHT, Fix.EFFECT_POWERUP_LIGHT, turn, effect_value, 0, 0);
  }

  private void BuffDownLight(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERDOWN_LIGHT, Fix.EFFECT_POWERDOWN_LIGHT, turn, effect_value, 0, 0);
  }

  private void BuffUpShadow(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERUP_SHADOW, Fix.EFFECT_POWERUP_SHADOW, turn, effect_value, 0, 0);
  }

  private void BuffDownShadow(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERDOWN_SHADOW, Fix.EFFECT_POWERDOWN_SHADOW, turn, effect_value, 0, 0);
  }

  private void BuffUpWind(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERUP_WIND, Fix.EFFECT_POWERUP_WIND, turn, effect_value, 0, 0);
  }

  private void BuffDownWind(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERDOWN_WIND, Fix.EFFECT_POWERDOWN_WIND, turn, effect_value, 0, 0);
  }

  private void BuffUpEarth(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERUP_EARTH, Fix.EFFECT_POWERUP_EARTH, turn, effect_value, 0, 0);
  }

  private void BuffDownEarth(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_POWERDOWN_EARTH, Fix.EFFECT_POWERDOWN_EARTH, turn, effect_value, 0, 0);
  }

  private void BuffResistFireUp(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_RESIST_FIRE_UP, Fix.EFFECT_RESIST_FIRE_UP, turn, effect_value, 0, 0);
  }

  private void BuffResistIceUp(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.EFFECT_RESIST_ICE_UP, Fix.EFFECT_RESIST_ICE_UP, turn, effect_value, 0, 0);
  }

  private void ExecBuffSyutyuDanzetsu(Character player, Character target, int turn, double effect_value)
  {
    AbstractAddBuff(target, target.objBuffPanel, Fix.BUFF_SYUTYU_DANZETSU, Fix.BUFF_SYUTYU_DANZETSU, turn, effect_value, 0, 0);
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
  private double PhysicalDamageLogic(Character player, Character target, double magnify, Fix.DamageSource attr, Fix.IgnoreType ignore_target_defense, Fix.CriticalType critical, ref bool result_critical)
  {    
    // 攻撃コマンドのダメージを算出
    double damageValue = 0.0f;
    if (attr == Fix.DamageSource.Colorless)
    {
      damageValue = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * magnify;
    }
    else if (attr == Fix.DamageSource.PhysicalMixed)
    {
      damageValue = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Both) * magnify;
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
    int additional = 0;
    int current = SecondaryLogic.CriticalRate(player, target, additional);
    Debug.Log("PhysicalDamageLogic CriticalRate ( " + rand.ToString() + " / " + current + " ) ");
    // ヴィルジランデ・ヘルゲート・ランスによる効果
    if (player.IsEquip(Fix.VIRGIRANTE_HELLGATE_LANCE))
    {
      int effect = SecondaryLogic.VirgiranteHellgateLance_Percent(player);
      Debug.Log("Equip " + Fix.VIRGIRANTE_HELLGATE_LANCE + " CriticalRate Up " + effect + " (before) " + current + " rand:" + rand);
      current += effect;
      Debug.Log("Equip " + Fix.VIRGIRANTE_HELLGATE_LANCE + " CriticalRate Up " + effect + " (after)  " + current + " rand:" + rand);
    }

    // フラッシュ・ヴァニッシュ・スピアによる効果
    if (player.IsEquip(Fix.FLASH_VANISH_SPEAR))
    {
      int effect = SecondaryLogic.FlashVanishSpear_Effect(player);
      Debug.Log("Equip " + Fix.FLASH_VANISH_SPEAR + " CriticalRate Up " + effect + " (before) " + current + " rand:" + rand);
      current += effect;
      Debug.Log("Equip " + Fix.FLASH_VANISH_SPEAR + " CriticalRate Up " + effect + " (after)  " + current + " rand:" + rand);
    }

    // フォーチュン・スピリットによるクリティカル判定
    BuffImage fortune = player.IsFortuneSpirit;
    if (fortune != null) // ダメージ系統かどうかに関係なく、フォーチュンがあれば、クリティカル判定とする。
    {
      Debug.Log("Detect FortuneSpirit, then Absolute Critical.");
      critical = Fix.CriticalType.Absolute;
      fortune.CumulativeDown(1);
    }

    // エルミ・ジョルジュ、【神域】によるクリティカル判定
    BuffImage oathOfGod = player.IsOathOfGod;
    if (oathOfGod)
    {
      Debug.Log("Detect Oath of God, then Absolute Critical.");
      critical = Fix.CriticalType.Absolute;
      // Oath of Godは、ここではBUFF削除されない。
    }

    if (player.CannotCritical == false &&
        ((critical == Fix.CriticalType.Random && rand <= current))
       )
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      // ヴィルジランデ・ヘルゲート・ランスによる効果
      if (player.IsEquip(Fix.VIRGIRANTE_HELLGATE_LANCE))
      {
        double addCritical = SecondaryLogic.VirgiranteHellgateLance_Effect(player);
        Debug.Log("Equip " + Fix.VIRGIRANTE_HELLGATE_LANCE + " CriticalValue Up " + addCritical + " (before) " + damageValue);
        damageValue *= addCritical;
        Debug.Log("Equip " + Fix.VIRGIRANTE_HELLGATE_LANCE + " CriticalValue Up " + addCritical + " (after) " + damageValue);
      }

      // ゴールドウィル・ディセント・ソードによる効果
      if (player.IsEquip(Fix.GOLDWILL_DESCENT_SOWRD))
      {
        double addCritical = SecondaryLogic.GoldwillDescentSword_Effect(player);
        Debug.Log("Equip " + Fix.GOLDWILL_DESCENT_SOWRD + " CriticalValue Up " + addCritical + " (before) " + damageValue);
        damageValue *= addCritical;
        Debug.Log("Equip " + Fix.GOLDWILL_DESCENT_SOWRD + " CriticalValue Up " + addCritical + " (after) " + damageValue);
      }

      debug1 = damageValue;
      result_critical = true;
      Debug.Log("PhysicalDamageLogic detect Critical! (Random) ( " + rand.ToString() + " / " + current + " ) " + damageValue.ToString());
    }
    if (critical == Fix.CriticalType.Absolute)
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      // ヴィルジランデ・ヘルゲート・ランスによる効果
      if (player.IsEquip(Fix.VIRGIRANTE_HELLGATE_LANCE))
      {
        double addCritical = SecondaryLogic.VirgiranteHellgateLance_Effect(player);
        Debug.Log("Equip " + Fix.VIRGIRANTE_HELLGATE_LANCE + " CriticalValue Up " + addCritical + " (before) " + damageValue);
        damageValue *= addCritical;
        Debug.Log("Equip " + Fix.VIRGIRANTE_HELLGATE_LANCE + " CriticalValue Up " + addCritical + " (after) " + damageValue);
      }

      // ゴールドウィル・ディセント・ソードによる効果
      if (player.IsEquip(Fix.GOLDWILL_DESCENT_SOWRD))
      {
        double addCritical = SecondaryLogic.GoldwillDescentSword_Effect(player);
        Debug.Log("Equip " + Fix.GOLDWILL_DESCENT_SOWRD + " CriticalValue Up " + addCritical + " (before) " + damageValue);
        damageValue *= addCritical;
        Debug.Log("Equip " + Fix.GOLDWILL_DESCENT_SOWRD + " CriticalValue Up " + addCritical + " (after) " + damageValue);
      }

      debug1 = damageValue;
      result_critical = true;
      Debug.Log("PhysicalDamageLogic detect Critical! (Absolute) " + damageValue.ToString());
    }


    // ターゲットの物理防御を差し引く
    double defenseValue = PrimaryLogic.PhysicalDefense(target);
    if (ignore_target_defense == Fix.IgnoreType.DefenseValue ||
        ignore_target_defense == Fix.IgnoreType.Both)
    {
      Debug.Log("Detect ignore targetDefenseValue " + ignore_target_defense.ToString());
      defenseValue = 0;
    }
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
      // ターゲットが防御姿勢であれば、ダメージを軽減する。ただし防御無効の場合は差し引かない。
      if (ignore_target_defense == Fix.IgnoreType.DefenseMode ||
          ignore_target_defense == Fix.IgnoreType.Both)
      {
        Debug.Log("Target is Defense, but ignore_target_defense is true, then cannot Defense");
      }
      else
      {
        damageValue = damageValue * SecondaryLogic.DefenseFactor(target);
        Debug.Log("Target is Defense mode: " + damageValue.ToString("F2"));
      }
    }

    // ダメージ量が負の値になる場合は０とみなす。
    if (damageValue <= 0) { damageValue = 0; }

    return damageValue;
  }

  private double MagicDamageLogic(Character player, Character target, double magnify, Fix.DamageSource attr, Fix.IgnoreType ignore_target_defense, Fix.CriticalType critical, ref bool result_critical)
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
    int additional = 0;
    if (player.IsEquip(Fix.DORN_NAMELESS_ROD)) { additional += SecondaryLogic.DornNamelessRod_CritRate(player); Debug.Log("MagicDamageLogic DORN_NAMELESS_ROD CriticalRate Up " + additional); }
    int current = SecondaryLogic.CriticalRate(player, target, additional);
    Debug.Log("MagicDamageLogic CriticalRate ( " + rand.ToString() + " / " + current + " ) ");

    // ミュラーヘイゼン・ブック・オブ・アガルタによる効果
    if (player.IsEquip(Fix.MULLERHAIZEN_AGARTA_BOOK))
    {
      int effect = SecondaryLogic.MullerhaizenAgartaBook_Percent(player);
      Debug.Log("Equip " + Fix.MULLERHAIZEN_AGARTA_BOOK + " CriticalRate Up " + effect + " (before) " + current + " rand:" + rand);
      current += effect;
      Debug.Log("Equip " + Fix.MULLERHAIZEN_AGARTA_BOOK + " CriticalRate Up " + effect + " (after)  " + current + " rand:" + rand);
    }

    // フォーチュン・スピリットによるクリティカル判定
    BuffImage fortune = player.IsFortuneSpirit;
    if (fortune != null) // ダメージ系統かどうかに関係なく、フォーチュンがあれば、クリティカル判定とする。
    {
      Debug.Log("Detect FortuneSpirit, then Absolute Critical.");
      critical = Fix.CriticalType.Absolute;
      fortune.CumulativeDown(1);
    }

    // エルミ・ジョルジュ、【神域】によるクリティカル判定
    BuffImage oathOfGod = player.IsOathOfGod;
    if (oathOfGod)
    {
      Debug.Log("Detect Oath of God, then Absolute Critical.");
      critical = Fix.CriticalType.Absolute;
      // Oath of Godは、ここではBUFF削除されない。
    }

    if (player.CannotCritical == false &&
        ((critical == Fix.CriticalType.Random && rand <= current))
       )
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      // ミュラーヘイゼン・ブック・オブ・アガルタによる効果
      if (player.IsEquip(Fix.MULLERHAIZEN_AGARTA_BOOK))
      {
        double addCritical = SecondaryLogic.MullerhaizenAgartaBook_Effect(player);
        Debug.Log("Equip " + Fix.MULLERHAIZEN_AGARTA_BOOK + " CriticalValue Up " + addCritical + " (before) " + damageValue);
        damageValue *= addCritical;
        Debug.Log("Equip " + Fix.MULLERHAIZEN_AGARTA_BOOK + " CriticalValue Up " + addCritical + " (after) " + damageValue);
      }

      // クロマティック・フォージ・オーブによる効果
      if (player.IsEquip(Fix.CHROMATIC_FORGE_ORB))
      {
        double addCritical = SecondaryLogic.ChromaticForgeOrb_Effect(player);
        Debug.Log("Equip " + Fix.CHROMATIC_FORGE_ORB + " CriticalValue Up " + addCritical + " (before) " + damageValue);
        damageValue *= addCritical;
        Debug.Log("Equip " + Fix.CHROMATIC_FORGE_ORB + " CriticalValue Up " + addCritical + " (after) " + damageValue);
      }

      result_critical = true;
      Debug.Log("MagicDamageLogic detect Critical! (Random) ( " + rand.ToString() + " / " + current + " ) " + damageValue.ToString());
      UpdateMessage("クリティカル発生！");
    }
    if (critical == Fix.CriticalType.Absolute)
    {
      damageValue *= SecondaryLogic.CriticalFactor(player);
      // ミュラーヘイゼン・ブック・オブ・アガルタによる効果
      if (player.IsEquip(Fix.MULLERHAIZEN_AGARTA_BOOK))
      {
        double addCritical = SecondaryLogic.MullerhaizenAgartaBook_Effect(player);
        Debug.Log("Equip " + Fix.MULLERHAIZEN_AGARTA_BOOK + " CriticalValue Up " + addCritical + " (before) " + damageValue);
        damageValue *= addCritical;
        Debug.Log("Equip " + Fix.MULLERHAIZEN_AGARTA_BOOK + " CriticalValue Up " + addCritical + " (after) " + damageValue);
      }

      // クロマティック・フォージ・オーブによる効果
      if (player.IsEquip(Fix.CHROMATIC_FORGE_ORB))
      {
        double addCritical = SecondaryLogic.ChromaticForgeOrb_Effect(player);
        Debug.Log("Equip " + Fix.CHROMATIC_FORGE_ORB + " CriticalValue Up " + addCritical + " (before) " + damageValue);
        damageValue *= addCritical;
        Debug.Log("Equip " + Fix.CHROMATIC_FORGE_ORB + " CriticalValue Up " + addCritical + " (after) " + damageValue);
      }

      result_critical = true;
      Debug.Log("MagicDamageLogic detect Critical! (Absolute) " + damageValue.ToString());
      UpdateMessage("クリティカル発生！");
    }

    // ウォーター・プリゼンスによる効果
    if (target.IsWaterPresence)
    {
      damageValue *= SecondaryLogic.WaterPresence_Effect(player);
      Debug.Log("Detect WaterPresence, then damageValue half. " + damageValue);
    }

    // 属性耐性の分だけ、減衰させる ( Percent )
    double reductionFire = 0.0f;
    if (attr == Fix.DamageSource.Fire && target.IsDownFire != null && target.IsDownFire.EffectValue > 0) { reductionFire += target.IsDownFire.EffectValue; }
    if (attr == Fix.DamageSource.Fire && target.MainWeapon != null && target.MainWeapon.ResistFirePercent > 0) { reductionFire += target.MainWeapon.ResistFirePercent; }
    if (attr == Fix.DamageSource.Fire && target.SubWeapon != null && target.SubWeapon.ResistFirePercent > 0) { reductionFire += target.SubWeapon.ResistFirePercent; }
    if (attr == Fix.DamageSource.Fire && target.MainArmor != null && target.MainArmor.ResistFirePercent > 0) { reductionFire += target.MainArmor.ResistFirePercent; }
    if (attr == Fix.DamageSource.Fire && target.Accessory1 != null && target.Accessory1.ResistFirePercent > 0) { reductionFire += target.Accessory1.ResistFirePercent; }
    if (attr == Fix.DamageSource.Fire && target.Accessory2 != null && target.Accessory2.ResistFirePercent > 0) { reductionFire += target.Accessory2.ResistFirePercent; }
    if (attr == Fix.DamageSource.Fire && target.Artifact != null && target.Artifact.ResistFirePercent > 0) { reductionFire += target.Artifact.ResistFirePercent; }
    if (reductionFire >= 1.00f) { reductionFire = 1.00f; }
    damageValue *= (1.00f - reductionFire);

    double reductionIce = 0.0f;
    if (attr == Fix.DamageSource.Ice && target.IsDownIce != null && target.IsDownIce.EffectValue > 0) { reductionIce += target.IsDownIce.EffectValue; }
    if (attr == Fix.DamageSource.Ice && target.MainWeapon != null && target.MainWeapon.ResistIcePercent > 0) { reductionIce += target.MainWeapon.ResistIcePercent; }
    if (attr == Fix.DamageSource.Ice && target.SubWeapon != null && target.SubWeapon.ResistIcePercent > 0) { reductionIce += target.SubWeapon.ResistIcePercent; }
    if (attr == Fix.DamageSource.Ice && target.MainArmor != null && target.MainArmor.ResistIcePercent > 0) { reductionIce += target.MainArmor.ResistIcePercent; }
    if (attr == Fix.DamageSource.Ice && target.Accessory1 != null && target.Accessory1.ResistIcePercent > 0) { reductionIce += target.Accessory1.ResistIcePercent; }
    if (attr == Fix.DamageSource.Ice && target.Accessory2 != null && target.Accessory2.ResistIcePercent > 0) { reductionIce += target.Accessory2.ResistIcePercent; }
    if (attr == Fix.DamageSource.Ice && target.Artifact != null && target.Artifact.ResistIcePercent > 0) { reductionIce += target.Artifact.ResistIcePercent; }
    if (reductionIce >= 1.00f) { reductionIce = 1.00f; }
    damageValue *= (1.00f - reductionIce);

    double reductionLight = 0.0f;
    if (attr == Fix.DamageSource.HolyLight && target.IsDownLight != null && target.IsDownLight.EffectValue > 0) { reductionLight += target.IsDownLight.EffectValue; }
    if (attr == Fix.DamageSource.HolyLight && target.MainWeapon != null && target.MainWeapon.ResistLightPercent > 0) { reductionLight += target.MainWeapon.ResistLightPercent; }
    if (attr == Fix.DamageSource.HolyLight && target.SubWeapon != null && target.SubWeapon.ResistLightPercent > 0) { reductionLight += target.SubWeapon.ResistLightPercent; }
    if (attr == Fix.DamageSource.HolyLight && target.MainArmor != null && target.MainArmor.ResistLightPercent > 0) { reductionLight += target.MainArmor.ResistLightPercent; }
    if (attr == Fix.DamageSource.HolyLight && target.Accessory1 != null && target.Accessory1.ResistLightPercent > 0) { reductionLight += target.Accessory1.ResistLightPercent; }
    if (attr == Fix.DamageSource.HolyLight && target.Accessory2 != null && target.Accessory2.ResistLightPercent > 0) { reductionLight += target.Accessory2.ResistLightPercent; }
    if (attr == Fix.DamageSource.HolyLight && target.Artifact != null && target.Artifact.ResistLightPercent > 0) { reductionLight += target.Artifact.ResistLightPercent; }
    if (reductionLight >= 1.00f) { reductionLight = 1.00f; }
    damageValue *= (1.00f - reductionLight);

    double reductionShadow = 0.0f;
    if (attr == Fix.DamageSource.DarkMagic && target.IsDownShadow != null && target.IsDownShadow.EffectValue > 0) { reductionShadow += target.IsDownShadow.EffectValue; }
    if (attr == Fix.DamageSource.DarkMagic && target.MainWeapon != null && target.MainWeapon.ResistShadowPercent > 0) { reductionShadow += target.MainWeapon.ResistShadowPercent; }
    if (attr == Fix.DamageSource.DarkMagic && target.SubWeapon != null && target.SubWeapon.ResistShadowPercent > 0) { reductionShadow += target.SubWeapon.ResistShadowPercent; }
    if (attr == Fix.DamageSource.DarkMagic && target.MainArmor != null && target.MainArmor.ResistShadowPercent > 0) { reductionShadow += target.MainArmor.ResistShadowPercent; }
    if (attr == Fix.DamageSource.DarkMagic && target.Accessory1 != null && target.Accessory1.ResistShadowPercent > 0) { reductionShadow += target.Accessory1.ResistShadowPercent; }
    if (attr == Fix.DamageSource.DarkMagic && target.Accessory2 != null && target.Accessory2.ResistShadowPercent > 0) { reductionShadow += target.Accessory2.ResistShadowPercent; }
    if (attr == Fix.DamageSource.DarkMagic && target.Artifact != null && target.Artifact.ResistShadowPercent > 0) { reductionShadow += target.Artifact.ResistShadowPercent; }
    if (reductionShadow >= 1.00f) { reductionShadow = 1.00f; }
    damageValue *= (1.00f - reductionShadow);

    double reductionWind = 0.0f;
    if (attr == Fix.DamageSource.Wind && target.IsDownWind != null && target.IsDownWind.EffectValue > 0) { reductionWind += target.IsDownWind.EffectValue; }
    if (attr == Fix.DamageSource.Wind && target.MainWeapon != null && target.MainWeapon.ResistWindPercent > 0) { reductionWind += target.MainWeapon.ResistWindPercent; }
    if (attr == Fix.DamageSource.Wind && target.SubWeapon != null && target.SubWeapon.ResistWindPercent > 0) { reductionWind += target.SubWeapon.ResistWindPercent; }
    if (attr == Fix.DamageSource.Wind && target.MainArmor != null && target.MainArmor.ResistWindPercent > 0) { reductionWind += target.MainArmor.ResistWindPercent; }
    if (attr == Fix.DamageSource.Wind && target.Accessory1 != null && target.Accessory1.ResistWindPercent > 0) { reductionWind += target.Accessory1.ResistWindPercent; }
    if (attr == Fix.DamageSource.Wind && target.Accessory2 != null && target.Accessory2.ResistWindPercent > 0) { reductionWind += target.Accessory2.ResistWindPercent; }
    if (attr == Fix.DamageSource.Wind && target.Artifact != null && target.Artifact.ResistWindPercent > 0) { reductionWind += target.Artifact.ResistWindPercent; }
    if (reductionWind >= 1.00f) { reductionWind = 1.00f; }
    damageValue *= (1.00f - reductionWind);

    double reductionEarth = 0.0f;
    if (attr == Fix.DamageSource.Earth && target.IsDownEarth != null && target.IsDownEarth.EffectValue > 0) { reductionEarth += target.IsDownEarth.EffectValue; }
    if (attr == Fix.DamageSource.Earth && target.MainWeapon != null && target.MainWeapon.ResistEarthPercent > 0) { reductionEarth += target.MainWeapon.ResistEarthPercent; }
    if (attr == Fix.DamageSource.Earth && target.SubWeapon != null && target.SubWeapon.ResistEarthPercent > 0) { reductionEarth += target.SubWeapon.ResistEarthPercent; }
    if (attr == Fix.DamageSource.Earth && target.MainArmor != null && target.MainArmor.ResistEarthPercent > 0) { reductionEarth += target.MainArmor.ResistEarthPercent; }
    if (attr == Fix.DamageSource.Earth && target.Accessory1 != null && target.Accessory1.ResistEarthPercent > 0) { reductionEarth += target.Accessory1.ResistEarthPercent; }
    if (attr == Fix.DamageSource.Earth && target.Accessory2 != null && target.Accessory2.ResistEarthPercent > 0) { reductionEarth += target.Accessory2.ResistEarthPercent; }
    if (attr == Fix.DamageSource.Earth && target.Artifact != null && target.Artifact.ResistEarthPercent > 0) { reductionEarth += target.Artifact.ResistEarthPercent; }
    if (reductionEarth >= 1.00f) { reductionEarth = 1.00f; }
    damageValue *= (1.00f - reductionEarth);

    double debug1 = damageValue;

    // 属性耐性の分だけ、減衰させる ( Value )
    double reductionFireValue = 0.0f;
    if (attr == Fix.DamageSource.Fire && target.MainWeapon != null && target.MainWeapon.ResistFireValue > 0) { reductionFireValue += target.MainWeapon.ResistFireValue; }
    if (attr == Fix.DamageSource.Fire && target.SubWeapon != null && target.SubWeapon.ResistFireValue > 0) { reductionFireValue += target.SubWeapon.ResistFireValue; }
    if (attr == Fix.DamageSource.Fire && target.MainArmor != null && target.MainArmor.ResistFireValue > 0) { reductionFireValue += target.MainArmor.ResistFireValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory1 != null && target.Accessory1.ResistFireValue > 0) { reductionFireValue += target.Accessory1.ResistFireValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory2 != null && target.Accessory2.ResistFireValue > 0) { reductionFireValue += target.Accessory2.ResistFireValue; }
    if (attr == Fix.DamageSource.Fire && target.Artifact != null && target.Artifact.ResistFireValue > 0) { reductionFireValue += target.Artifact.ResistFireValue; }
    damageValue -= reductionFireValue;
    if (damageValue <= 0) { damageValue = 0; }

    double reductionIceValue = 0.0f;
    if (attr == Fix.DamageSource.Fire && target.MainWeapon != null && target.MainWeapon.ResistIceValue > 0) { reductionIceValue += target.MainWeapon.ResistIceValue; }
    if (attr == Fix.DamageSource.Fire && target.SubWeapon != null && target.SubWeapon.ResistIceValue > 0) { reductionIceValue += target.SubWeapon.ResistIceValue; }
    if (attr == Fix.DamageSource.Fire && target.MainArmor != null && target.MainArmor.ResistIceValue > 0) { reductionIceValue += target.MainArmor.ResistIceValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory1 != null && target.Accessory1.ResistIceValue > 0) { reductionIceValue += target.Accessory1.ResistIceValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory2 != null && target.Accessory2.ResistIceValue > 0) { reductionIceValue += target.Accessory2.ResistIceValue; }
    if (attr == Fix.DamageSource.Fire && target.Artifact != null && target.Artifact.ResistIceValue > 0) { reductionIceValue += target.Artifact.ResistIceValue; }
    damageValue -= reductionIceValue;
    if (damageValue <= 0) { damageValue = 0; }

    double reductionLightValue = 0.0f;
    if (attr == Fix.DamageSource.Fire && target.MainWeapon != null && target.MainWeapon.ResistLightValue > 0) { reductionLightValue += target.MainWeapon.ResistLightValue; }
    if (attr == Fix.DamageSource.Fire && target.SubWeapon != null && target.SubWeapon.ResistLightValue > 0) { reductionLightValue += target.SubWeapon.ResistLightValue; }
    if (attr == Fix.DamageSource.Fire && target.MainArmor != null && target.MainArmor.ResistLightValue > 0) { reductionLightValue += target.MainArmor.ResistLightValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory1 != null && target.Accessory1.ResistLightValue > 0) { reductionLightValue += target.Accessory1.ResistLightValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory2 != null && target.Accessory2.ResistLightValue > 0) { reductionLightValue += target.Accessory2.ResistLightValue; }
    if (attr == Fix.DamageSource.Fire && target.Artifact != null && target.Artifact.ResistLightValue > 0) { reductionLightValue += target.Artifact.ResistLightValue; }
    damageValue -= reductionLightValue;
    if (damageValue <= 0) { damageValue = 0; }

    double reductionShadowValue = 0.0f;
    if (attr == Fix.DamageSource.Fire && target.MainWeapon != null && target.MainWeapon.ResistShadowValue > 0) { reductionShadowValue += target.MainWeapon.ResistShadowValue; }
    if (attr == Fix.DamageSource.Fire && target.SubWeapon != null && target.SubWeapon.ResistShadowValue > 0) { reductionShadowValue += target.SubWeapon.ResistShadowValue; }
    if (attr == Fix.DamageSource.Fire && target.MainArmor != null && target.MainArmor.ResistShadowValue > 0) { reductionShadowValue += target.MainArmor.ResistShadowValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory1 != null && target.Accessory1.ResistShadowValue > 0) { reductionShadowValue += target.Accessory1.ResistShadowValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory2 != null && target.Accessory2.ResistShadowValue > 0) { reductionShadowValue += target.Accessory2.ResistShadowValue; }
    if (attr == Fix.DamageSource.Fire && target.Artifact != null && target.Artifact.ResistShadowValue > 0) { reductionShadowValue += target.Artifact.ResistShadowValue; }
    damageValue -= reductionShadowValue;
    if (damageValue <= 0) { damageValue = 0; }

    double reductionWindValue = 0.0f;
    if (attr == Fix.DamageSource.Fire && target.MainWeapon != null && target.MainWeapon.ResistWindValue > 0) { reductionWindValue += target.MainWeapon.ResistWindValue; }
    if (attr == Fix.DamageSource.Fire && target.SubWeapon != null && target.SubWeapon.ResistWindValue > 0) { reductionWindValue += target.SubWeapon.ResistWindValue; }
    if (attr == Fix.DamageSource.Fire && target.MainArmor != null && target.MainArmor.ResistWindValue > 0) { reductionWindValue += target.MainArmor.ResistWindValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory1 != null && target.Accessory1.ResistWindValue > 0) { reductionWindValue += target.Accessory1.ResistWindValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory2 != null && target.Accessory2.ResistWindValue > 0) { reductionWindValue += target.Accessory2.ResistWindValue; }
    if (attr == Fix.DamageSource.Fire && target.Artifact != null && target.Artifact.ResistWindValue > 0) { reductionWindValue += target.Artifact.ResistWindValue; }
    damageValue -= reductionWindValue;
    if (damageValue <= 0) { damageValue = 0; }

    double reductionEarthValue = 0.0f;
    if (attr == Fix.DamageSource.Fire && target.MainWeapon != null && target.MainWeapon.ResistEarthValue > 0) { reductionEarthValue += target.MainWeapon.ResistEarthValue; }
    if (attr == Fix.DamageSource.Fire && target.SubWeapon != null && target.SubWeapon.ResistEarthValue > 0) { reductionEarthValue += target.SubWeapon.ResistEarthValue; }
    if (attr == Fix.DamageSource.Fire && target.MainArmor != null && target.MainArmor.ResistEarthValue > 0) { reductionEarthValue += target.MainArmor.ResistEarthValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory1 != null && target.Accessory1.ResistEarthValue > 0) { reductionEarthValue += target.Accessory1.ResistEarthValue; }
    if (attr == Fix.DamageSource.Fire && target.Accessory2 != null && target.Accessory2.ResistEarthValue > 0) { reductionEarthValue += target.Accessory2.ResistEarthValue; }
    if (attr == Fix.DamageSource.Fire && target.Artifact != null && target.Artifact.ResistEarthValue > 0) { reductionEarthValue += target.Artifact.ResistEarthValue; }
    damageValue -= reductionEarthValue;
    if (damageValue <= 0) { damageValue = 0; }

    // ターゲットの魔法防御を差し引く。
    double defenseValue = PrimaryLogic.MagicDefense(target);
    if (ignore_target_defense == Fix.IgnoreType.DefenseValue ||
        ignore_target_defense == Fix.IgnoreType.Both)
    {
      Debug.Log("Detect ignore targetDefenseValue " + ignore_target_defense.ToString());
      defenseValue = 0;
    }
    double debug2 = defenseValue;
    damageValue -= defenseValue;
    double debug3 = damageValue;

    Debug.Log("Magic-DamageValue: " + debug0.ToString("F2") + " -> " + debug1.ToString("F2") + " - " + debug2.ToString("F2") + " = " + debug3.ToString("F2"));

    // 防御判定
    if (target.IsDefense)
    {
      // ターゲットが防御姿勢であれば、ダメージを軽減する。ただし防御無効の場合は差し引かない。
      if (ignore_target_defense == Fix.IgnoreType.DefenseMode ||
          ignore_target_defense == Fix.IgnoreType.Both)
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

    if (target.IsOneImmunity)
    {
      damageValue = 0;
      StartAnimation(target.objGroup.gameObject, Fix.BUFF_ONE_IMMUNITY_JP, Fix.COLOR_GUARD, animation_speed);
    }

    BuffImage holyWisdom = target.SearchFieldBuff(Fix.HOLY_WISDOM);
    if (holyWisdom)
    {
      holyWisdom.CumulativeDown(1);
      damageValue = 0;
      StartAnimation(target.objGroup.gameObject, Fix.BUFF_HOLY_WISDOM_JP, Fix.COLOR_GUARD, animation_speed);
    }

    BuffImage absolutePerfection = target.IsAbsolutePerfection;
    if (absolutePerfection)
    {
      damageValue = 0;
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DAMAGE_IS_ZERO, Fix.COLOR_GUARD, animation_speed);
    }

    BuffImage oathOfGod = target.IsOathOfGod;
    if (oathOfGod)
    {
      damageValue = 0;
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_DAMAGE_IS_ZERO, Fix.COLOR_GUARD, animation_speed);
    }

    int result = (int)damageValue;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " damage");
    UpdateMessage((player?.FullName ?? string.Empty) + " から " + target.FullName + " へ " + result.ToString() + " のダメージ");


    // 防壁がある場合、マナダメージへ変換する。
    if (target.IsTheAbyssWall)
    {
      target.CurrentManaPoint -= (int)result;
      target.UpdateManaPoint();
      StartAnimation(target.groupManaPoint.gameObject, result.ToString(), Fix.COLOR_MP_DAMAGE, animation_speed);
      if (target.CurrentManaPoint <= 0)
      {
        target.RemoveTargetBuff(Fix.THE_ABYSS_WALL);
      }
      return;
    }

    // スフィア・オブ・グローリーがある場合、累積カウンターが１つ乗る。
    BuffImage sphereOfGlory = target.IsSphereOfGlory;
    if (sphereOfGlory)
    {
      sphereOfGlory.CumulativeUp(sphereOfGlory.RemainCounter, 1);
    }

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
      if (player && player.IsOathOfGod)
      {
        Debug.Log("detect EFFECT_CANNOT_NOT_DEAD!!");
        // skip
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_CANNOT_NOT_DEAD, Fix.COLOR_WARNING, animation_speed);
      }
      else
      {
        target.CurrentLife = 1;
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_NOT_DEAD, Fix.COLOR_NORMAL, animation_speed);
      }
    }

    if (target.IsOathOfSefine != null && target.CurrentLife <= 0 && beforeTargetLife > 1)
    {
      if (player && player.IsOathOfGod)
      {
        // skip
        Debug.Log("detect EFFECT_CANNOT_NOT_DEAD!!");
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_CANNOT_NOT_DEAD, Fix.COLOR_WARNING, animation_speed);
      }
      else
      {
        target.CurrentLife = 1;
        StartAnimation(target.objGroup.gameObject, Fix.EFFECT_NOT_DEAD, Fix.COLOR_NORMAL, animation_speed);
        target.RemoveTargetBuff(Fix.OATH_OF_SEFINE);
        AbstractAddBuff(target, target.objBuffPanel, Fix.OATH_OF_GOD, Fix.BUFF_OATH_OF_GOD, SecondaryLogic.OathOfGod_Turn(player), SecondaryLogic.OathOfGod_Effect(player), SecondaryLogic.OathOfGod_Effect2(player), 0);
      }
    }
  }

  private bool AbstractHealCommand(Character player, Character target, double healValue, bool from_potion)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    if (target.IsValkyrieScar)
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_CANNOT_LIFEGAIN, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    if (target.IsAbsoluteZero)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BUFF_CANNOT_GAIN_JP, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // 武具による回復上昇効果はいずれも魔法である事を条件としているため、ポーション回復の場合は適用外とする。
    if (from_potion == false)
    {
      // フィネッセ・インペリアル・ブックによる効果
      if (player.IsEquip(Fix.FINESSE_IMPERIAL_BOOK))
      {
        double effectValue = SecondaryLogic.FinesseImperialBook_Effect(player);
        Debug.Log("Equip " + Fix.FINESSE_IMPERIAL_BOOK + " " + healValue.ToString() + " effect " + effectValue.ToString());
        healValue = healValue * effectValue;
        Debug.Log("Equip " + Fix.FINESSE_IMPERIAL_BOOK + " after " + healValue.ToString());
      }

      // エンゲージド・フューチャー・ロッドによる効果
      if (player.IsEquip(Fix.ENGAGED_FUTURE_ROD))
      {
        double effectValue = SecondaryLogic.EngagedFutureRod_Effect(player);
        Debug.Log("Equip " + Fix.ENGAGED_FUTURE_ROD + " " + healValue.ToString() + " effect " + effectValue.ToString());
        healValue = healValue * effectValue;
        Debug.Log("Equip " + Fix.ENGAGED_FUTURE_ROD + " after " + healValue.ToString());
      }

      // エルダースタッフ・オブ・ライフブルームによる効果
      if (player.IsEquip(Fix.ELDERSTAFF_OF_LIFEBLOOM))
      {
        double effectValue = SecondaryLogic.ElderstaffOfLifebloom_Effect(player);
        Debug.Log("Equip " + Fix.ELDERSTAFF_OF_LIFEBLOOM + " " + healValue.ToString() + " effect " + effectValue.ToString());
        healValue = healValue * effectValue;
        Debug.Log("Equip " + Fix.ELDERSTAFF_OF_LIFEBLOOM + " after " + healValue.ToString());
      }
    }

    if (target.IsVoiceOfAbyss)
    {
      healValue = 0;
    }

    // エルミ・ジョルジュ、【神域】によりライフ回復不可
    if (target.IsOathOfGod)
    {
      healValue = 0;
    }

    // ライフ回復不可のBuff
    if (target.IsNoGainLife)
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_FAIL_GAIN_LIFE_JP, Fix.COLOR_NORMAL);
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

    if (target.IsAbsoluteZero)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BUFF_CANNOT_GAIN_JP, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    if (target.IsVoiceOfAbyss)
    {
      gainValue = 0;
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

  private bool AbstractLostManaPoint(Character player, Character target, double lost_value)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // ロスト量が負の値になる場合は０とみなす。
    if (lost_value <= 0) { lost_value = 0; }

    int result = (int)lost_value;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " Mana lost");
    UpdateMessage((player?.FullName ?? string.Empty) + " から " + target.FullName + " へ " + result.ToString() + " ManaPoint減少");
    target.CurrentManaPoint -= result;
    target.txtManaPoint.text = target.CurrentManaPoint.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_LOST_MP);

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

    if (target.IsAbsoluteZero)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BUFF_CANNOT_GAIN_JP, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    if (target.IsVoiceOfAbyss)
    {
      gainValue = 0;
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

  private bool AbstractLostSkillPoint(Character player, Character target, double lost_value)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (target.Dead)
    {
      StartAnimation(target.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      this.NowAnimationMode = true;
      return false;
    }

    // ロスト量が負の値になる場合は０とみなす。
    if (lost_value <= 0) { lost_value = 0; }

    int result = (int)lost_value;
    Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " skill-point lost");
    UpdateMessage((player?.FullName ?? string.Empty) + " から " + target.FullName + " へ " + result.ToString() + " SkillPoint減少");
    target.CurrentSkillPoint -= result;
    target.txtSkillPoint.text = target.CurrentSkillPoint.ToString();
    StartAnimation(target.objGroup.gameObject, result.ToString(), Fix.COLOR_LOST_SP);

    return true;
  }

  private void AbstractResurrection(Character player, Character target, int gain_life)
  {
    if (target.IsCannotResurrect)
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_CANNOT_RESURRECT_JP, Fix.COLOR_NORMAL);
      return;
    }

    if (target.Dead == false)
    {
      StartAnimation(target.objGroup.gameObject, Fix.EFFECT_NOT_EFFECT_JP, Fix.COLOR_NORMAL);
      return;
    }

    target.ResurrectPlayer(gain_life);
    StartAnimation(target.objGroup.gameObject, Fix.EFFECT_RESURRECT_JP, Fix.COLOR_NORMAL);
  }

  private void AbstractAddBuff(Character target, BuffField buff_field, string buff_name, string view_buff_name, int remain_counter, double effect1, double effect2, double effect3)
  {
    if (buff_field == null)
    {
      StartAnimation(this.gameObject, Fix.BATTLE_MISS, Fix.COLOR_WARNING);
      return; 
    }

    if (target.SearchFieldBuff(Fix.DETACHMENT_FAULT))
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_FAILED, Fix.COLOR_WARNING);
      return;
    }

    BuffImage stanceOftheMuin = target.IsStanceOfMuin;
    if (stanceOftheMuin && ActionCommand.GetBuffType(buff_name) == Fix.BuffType.Negative)
    {
      stanceOftheMuin.CumulativeDown(1);
      StartAnimation(buff_field.gameObject, Fix.BUFF_MINUS_IMMUNE, Fix.COLOR_GUARD);
      return;
    }

    BuffImage transcendenceReached = target.IsTranscendenceReached;
    if (transcendenceReached && ActionCommand.GetBuffType(buff_name) == Fix.BuffType.Negative)
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_MINUS_IMMUNE, Fix.COLOR_GUARD);
      return;
    }

    BuffImage austerityMatrixOmega = target.IsAusterityMatrixOmega;
    if (austerityMatrixOmega && ActionCommand.GetBuffType(buff_name) == Fix.BuffType.Positive)
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_POSITIVE_IMMUNE, Fix.COLOR_WARNING);
      return;
    }

    BuffImage innocentCircle = target.IsInnocentCircle;
    if (innocentCircle && ActionCommand.GetBuffType(buff_name) == Fix.BuffType.Negative)
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_MINUS_IMMUNE, Fix.COLOR_GUARD);
      return;
    }

    buff_field.AddBuff(prefab_Buff, buff_name, remain_counter, effect1, effect2, effect3);
    StartAnimation(buff_field.gameObject, view_buff_name, Fix.COLOR_NORMAL);
  }

  /// <summary>
  /// Buff除去を行うメソッド。
  /// RemoveBuffが成功していればTrueを返す。それ以外はFalseで失敗とする。
  /// </summary>
  private bool AbstractRemoveBuff(Character target, BuffField buff_field, string view_buff_name, int num, Fix.BuffType buff_type)
  {
    if (target.SearchFieldBuff(Fix.DETACHMENT_FAULT))
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_FAILED, Fix.COLOR_WARNING);
      return false;
    }

    BuffImage transcendenceReached = target.IsTranscendenceReached;
    if (transcendenceReached && buff_type == Fix.BuffType.Positive)
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_FAILED, Fix.COLOR_WARNING);
      return false;
    }

    BuffImage innocentCircle = target.IsInnocentCircle;
    if (innocentCircle && buff_type == Fix.BuffType.Positive)
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_FAILED, Fix.COLOR_WARNING);
      return false;
    }

    bool success = target.RemoveBuff(num, buff_type);
    if (view_buff_name != "" && success)
    {
      StartAnimation(buff_field.gameObject, view_buff_name, Fix.COLOR_NORMAL);
    }

    return success;
  }

  private void AbstractRemoveTargetBuff(Character target, BuffField buff_field, string buff_name, string view_buff_name)
  {
    if (target.SearchFieldBuff(Fix.DETACHMENT_FAULT))
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_FAILED, Fix.COLOR_WARNING);
      return;
    }

    BuffImage transcendenceReached = target.IsTranscendenceReached;
    if (transcendenceReached && ActionCommand.GetBuffType(buff_name) == Fix.BuffType.Positive)
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_FAILED, Fix.COLOR_WARNING);
      return;
    }

    BuffImage innocentCircle = target.IsInnocentCircle;
    if (innocentCircle && ActionCommand.GetBuffType(buff_name) == Fix.BuffType.Positive)
    {
      StartAnimation(buff_field.gameObject, Fix.BUFF_FAILED, Fix.COLOR_WARNING);
      return;
    }

    target.RemoveTargetBuff(buff_name);
    if (view_buff_name != "")
    {
      StartAnimation(buff_field.gameObject, view_buff_name, Fix.COLOR_NORMAL);
    }
  }

  private void UpdateExp(Character character, int gain_exp)
  {
    if (character.Exp < character.GetNextExp())
    {
      character.GainExp(gain_exp);

      if (character.Exp >= character.GetNextExp())
      {
        string newCommand = string.Empty;
        character.Exp = character.Exp - character.GetNextExp();
        character.UpdateLevelup(ref newCommand, One.TF.AvailableFirstEssence, One.TF.AvailableSecondEssence, One.TF.AvailableThirdEssence, One.TF.AvailableFourthEssence);

        DetectLvup.Add(true);
        DetectLvupTitle.Add(character.FullName + "が Lv " + character.Level.ToString() + " にレベルアップしました！");
        DetectLvupMaxLife.Add("最大ライフが " + character.LevelupBaseLife() + " 上昇した！");
        DetectLvupMaxManaPoint.Add("最大マナが " + character.LevelupBaseManaPoint() + " 上昇した！");
        DetectLvupMaxSkillPoint.Add(""); // 最大スキルポイントが " + character.LevelupBaseSkillPoint() + " 上昇した！"); // スキルポイントは原則上昇しない。
        DetectLvupRemainPoint.Add("コア・パラメタポイントを " + character.LevelupRemainPoint() + " 獲得！");
        if (character.LevelupSoulEssence() > 0)
        {
          DetectLvupSoulEssence.Add("ソウル・エッセンスポイントを " + character.LevelupSoulEssence() + " 獲得！");
        }
        else
        {
          //DetectLvupSoulEssence.Add("");
        }
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

  private void ConstructNodeCharaExp(Character character)
  {
    NodeCharaExp node_charaExp = Instantiate(node_CharaExp) as NodeCharaExp;
    node_charaExp.txtPlayerName.text = character.FullName;
    // レベル上限に達している場合、表示固定とする。
    if (character.Level >= Fix.CHARACTER_MAX_LEVEL7)
    {
      node_charaExp.txtPlayerExp.text = "----- / -----";
    }
    else if (character.Exp < character.GetNextExp())
    {
      node_charaExp.txtPlayerExp.text = character.Exp + " / " + character.GetNextExp();
    }
    else
    {
      node_charaExp.txtPlayerExp.text = "Max";
    }

    // レベル上限に達している場合、表示固定とする。
    if (character.Level >= Fix.CHARACTER_MAX_LEVEL7)
    {
      node_charaExp.objCurrentExpGauge.rectTransform.localScale = new Vector3(0, 1.0f);
    }
    else
    {
      float dx = (float)character.Exp / (float)character.GetNextExp();
      node_charaExp.objCurrentExpGauge.rectTransform.localScale = new Vector3(dx, 1.0f);
    }

    if (character.Exp < character.GetNextExp())
    {
      node_charaExp.objCurrentExpBorder.gameObject.SetActive(true);
    }
    else
    {
      node_charaExp.objCurrentExpBorder.gameObject.SetActive(false);
    }
    node_charaExp.BeforeExpThreshold = character.GetNextExp();
    node_charaExp.BeforeExp = character.Exp;
    node_charaExp.gameObject.SetActive(true);
    node_charaExp.transform.SetParent(panelGameEndExpList.transform);

    node_charaExp.SourceCharacter = character;
    CharaExpList.Add(node_charaExp);
  }

  private void TimeStopEnd()
  {
    bool tempStop = false;
    for (int ii = 0; ii < AllList.Count; ii++)
    {
//      for (int jj = 0; jj < AllList[ii].ActionCommandStackList.Count; jj++)
//      {
//        if (AllList[ii].FirstName == Database.ENEMY_BOSS_BYSTANDER_EMPTINESS)
//        {
//          if (tempStop == false)
//          {
//            tempStop = true;
//            this.labelBattleTurnCount.color = Color.black;
//            System.Threading.Thread.Sleep(1000);
//            this.labelBattleTurn.color = Color.black;
//          }
//          PlayerAttackPhase(AllList[ii], AllList[ii].ActionCommandStackTarget[jj], TruthActionCommand.CheckPlayerActionFromString(ActiveList[ii].ActionCommandStackList[jj]), ActiveList[ii].ActionCommandStackList[jj], true, false, false);
//        }
//        else
//        {
////          ExecActionMethod(AllList[ii], AllList[ii].ActionCommandStackTarget[jj], TruthActionCommand.CheckPlayerActionFromString(ActiveList[ii].ActionCommandStackList[jj]), ActiveList[ii].ActionCommandStackList[jj]);
//        }
//      }
//      AllList[ii].ActionCommandStackList.Clear();
//      AllList[ii].ActionCommandStackTarget.Clear();
    }

    this.Background.GetComponent<Image>().color = UnityColor.White;
    this.TimeStopText.gameObject.SetActive(false);
    this.labelBattleTurn.color = Color.black;
    this.TimeSpeedLabel.color = Color.black;
    this.lblTimerCount.color = Color.black;
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      BackToNormalColor(AllList[ii]);
    }
  }

  private void BackToNormalColor(Character player)
  {
    //if (IsPlayerEnemy(player))
    //{
    //  if (((TruthEnemyCharacter)player).Rare == TruthEnemyCharacter.RareString.Gold)
    //  {
    //    player.labelName.color = UnityColor.DarkOrange;
    //    player.labelCurrentInstantPoint.color = UnityColor.Gold;
    //  }
    //  else
    //  {
    //    player.labelName.color = Color.black;
    //  }
    //}
    //else
    //{
    //  player.labelName.color = Color.black;
    //}

    //player.ActionLabel.color = Color.black;
    //player.CriticalLabel.color = Color.black;
    //player.DamageLabel.color = Color.black;
    //player.BuffPanel.GetComponent<Image>().color = UnityColor.GhostWhite;

    //if (player.CurrentLife >= player.MaxLife)
    //{
    //  player.labelCurrentLifePoint.color = Color.green;
    //}
    //else
    //{
    //  player.labelCurrentLifePoint.color = Color.black;
    //}
  }

  #endregion
  #endregion
}