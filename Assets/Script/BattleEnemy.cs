﻿using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.SceneManagement;
using UnityEditor.VersionControl;

public partial class BattleEnemy : MotherBase
{
  // prefab
  public BuffImage prefab_Buff = null;
  public StackObject prefab_Stack = null;
  public DamageObject prefab_Damage = null;
  public NodeBattleChara node_BattleChara = null;
  public GameObject prefab_Message = null;
  public NodeActionCommand prefab_MainAction = null;
  public NodeActionCommand prefab_InstantAction = null;

  // GUI-BattleView
  public GameObject GroupBattleGauge;
  public GameObject GroupParentPlayer;
  public GameObject GroupParentEnemy;
  public GameObject panelGameEnd;
  public Text txtGameEndMessage;

  // GUI-SandGlass
  public Image pbSandglass;
  public Text lblBattleTurn;
  public Text lblTimerCount;
  public Text lblTimerSpeed;

  // GUI-Field
  public GameObject PanelPlayerField;
  public GameObject PanelEnemyField;

  // GUI-Player
  public List<GameObject> PlayerArrowList;
  public List<GameObject> EnemyArrowList;
  public List<Image> imgPlayerInstantGauge_AC;
  //public List<Image> imgEnemyInstantGauge_AC; // 敵用のアクションコマンドボタンは画面上に出てこない。
  public List<Image> imgPlayerPotentialGauge;
  //public List<Image> imgEnemyPotentialGauge; // 敵用のアクションコマンドボタンは画面上に出てこない。
  public Image imgGlobalGauge_AC;

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
  public GameObject GroupMessage;

  public GameObject SelectFilter;
  public GameObject lblInstantAction;
  public GameObject btnCancelSelect;

  public GameObject GroupStackInTheCommand;
  public GameObject GroupAnimation;

  public bool CannotRunAway = false;

  // Inner Value
  private Sprite[] imageSandglass;
  private float speedDown = 1;

  public List<Character> PlayerList;
  public List<Character> EnemyList;
  public List<Character> AllList;
  public List<GameObject> AllFieldList;

  //protected Character currentPlayer = null;

  protected Fix.BattleStatus TimeStatus = Fix.BattleStatus.Ready;
  protected float BattleTimer = 0;
  protected int BattleTurn = 0;

  protected float GlobalInstantValue = 0;
  protected float GlobalInstantInc = 1;

  protected bool NowAnimationMode = false;
  public List<int> AnimationProgress;
  protected const int MAX_ANIMATION_TIME = 40;

  protected bool NowSelectGlobal = false;
  protected bool NowSelectTarget = false;
  protected bool NowInstantTarget = false;
  public Character NowSelectSrcPlayer = null;
  public Button NowSelectActionSrcButton = null;
  public Button NowSelectActionCommandButton = null;
  public Button NowSelectActionDstButton = null;

  protected GameEndType BattleEnd = GameEndType.None;

  protected bool DuelMode = true;
  protected bool NowStackInTheCommand = false;

  public enum GameEndType
  {
    None,
    Success,
    Fail,
    RunAway,
  }

  // Start is called before the first frame update
  public override void Start()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    base.Start();

    this.CannotRunAway = One.CannotRunAway;

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
    str_list0.Add(Fix.NORMAL_ATTACK);
    str_list0.Add(Fix.DEFENSE);
    str_list0.Add(Fix.USE_RED_POTION);
    str_list0.Add(Fix.READY_BUTTON);
    str_list0.Add(Fix.RUNAWAY_BUTTON);
    for (int ii = 0; ii < GlobalActionButtonList.Count; ii++)
    {
      SetupActionCommandButton(GlobalActionButtonList[ii], str_list0[ii]);
    }

    // キャラクターを生成する。
    List<Character> playerList = new List<Character>();
    for (int ii = 0; ii < Fix.MAX_TEAM_MEMBER; ii++)
    {
      string target = String.Empty;
      if (ii == 0) { target = One.TF.BattlePlayer1; }
      if (ii == 1) { target = One.TF.BattlePlayer2; }
      if (ii == 2) { target = One.TF.BattlePlayer3; }
      if (ii == 3) { target = One.TF.BattlePlayer4; }

      int counter = 0;
      if (One.TF.AvailableEinWolence && target == Fix.NAME_EIN_WOLENCE) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableLanaAmiria && target == Fix.NAME_LANA_AMIRIA) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableEoneFulnea && target == Fix.NAME_EONE_FULNEA) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableMagiZelkis && target == Fix.NAME_MAGI_ZELKIS) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableSelmoiRo && target == Fix.NAME_SELMOI_RO) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableKartinMai && target == Fix.NAME_KARTIN_MAI) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableJedaArus && target == Fix.NAME_JEDA_ARUS) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableSinikiaVeilhanz && target == Fix.NAME_SINIKIA_VEILHANZ) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableAdelBrigandy && target == Fix.NAME_ADEL_BRIGANDY) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableLeneColtos && target == Fix.NAME_LENE_COLTOS) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailablePermaWaramy && target == Fix.NAME_PERMA_WARAMY) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableKiltJorju && target == Fix.NAME_KILT_JORJU) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableBillyRaki && target == Fix.NAME_BILLY_RAKI) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableAnnaHamilton && target == Fix.NAME_ANNA_HAMILTON) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableCalmansOhn && target == Fix.NAME_CALMANS_OHN) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableSunYu && target == Fix.NAME_SUN_YU) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableShuvaltzFlore && target == Fix.NAME_SHUVALTZ_FLORE) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableRvelZelkis && target == Fix.NAME_RVEL_ZELKIS) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableVanHehgustel && target == Fix.NAME_VAN_HEHGUSTEL) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableOhryuGenma && target == Fix.NAME_OHRYU_GENMA) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableLadaMystorus && target == Fix.NAME_LADA_MYSTORUS) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableSinOscurete && target == Fix.NAME_SIN_OSCURETE) { playerList.Add(One.Characters[counter]); }
      counter++;
      if (One.TF.AvailableDelvaTreckino && target == Fix.NAME_DELVA_TRECKINO) { playerList.Add(One.Characters[counter]); }
      counter++;
    }

    // 味方グループの作成
    for (int ii = 0; ii < playerList.Count; ii++)
    {
      NodeBattleChara node = Instantiate(node_BattleChara) as NodeBattleChara;
      node.gameObject.SetActive(true);
      node.transform.SetParent(GroupParentPlayer.transform);
      //playerList[ii].MaxGain(); //プレイヤー側は全快設定は不要。
      playerList[ii].IsEnemy = false;
      AddPlayerFromOne(playerList[ii], node, PlayerArrowList[ii], GroupParentActionPanelList[ii], GroupActionButton[ii], imgPlayerInstantGauge_AC[ii], imgPlayerPotentialGauge[ii]);

      // キャラクターグループのリストに追加
      playerList[ii].Ally = Fix.Ally.Ally;
      PlayerList.Add(playerList[ii]);
      AllList.Add(playerList[ii]);

      // インスタント・アクションの作成
      for (int jj = 0; jj < playerList[ii].ActionCommandList.Count; jj++)
      {
        string commandName = playerList[ii].ActionCommandList[jj];
        ActionCommand.TimingType timing = ActionCommand.GetTiming(commandName);
        if (timing == ActionCommand.TimingType.Instant)
        {
          NodeActionCommand instant = Instantiate(prefab_InstantAction) as NodeActionCommand;
          instant.BackColor.color = playerList[ii].BattleForeColor;
          instant.CommandName = commandName;
          instant.name = commandName;
          instant.OwnerName = playerList[ii].FullName;
          instant.ActionButton.name = commandName;
          instant.ActionButton.image.sprite = Resources.Load<Sprite>(commandName);

          instant.transform.SetParent(GroupInstantAction.transform);
          instant.gameObject.SetActive(true);
        }
      }
    }

    // 敵グループの作成
    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      NodeBattleChara node = Instantiate(node_BattleChara) as NodeBattleChara;
      node.gameObject.SetActive(true);
      node.transform.SetParent(GroupParentEnemy.transform);
      //GameObject objEC = new GameObject("objEC");
      //Character character = objEC.AddComponent<Character>();
      //character.BattleBackColor = Fix.COLOR_ENEMY_CHARA;
      //character.BattleForeColor = Fix.COLORFORE_ENEMY_CHARA;
      //character.Construction(One.EnemyList[ii]);
      One.EnemyList[ii].IsEnemy = true;
      AddPlayerFromOne(One.EnemyList[ii], node, EnemyArrowList[ii], null, null, null, null);

      // キャラクターグループのリストに追加
      One.EnemyList[ii].Ally = Fix.Ally.Enemy;
      One.EnemyList[ii].ChooseCommand();
      EnemyList.Add(One.EnemyList[ii]);
      AllList.Add(One.EnemyList[ii]);
    }

    // 初期ターゲットを設定する。
    for (int ii = 0; ii < PlayerList.Count; ii++)
    {
      Debug.Log("first command: " + PlayerList[ii].ActionCommandList[0]);
      PlayerList[ii].CurrentActionCommand = PlayerList[ii].ActionCommandList[0];
      SetupActionCommandButton(PlayerList[ii].objMainButton, PlayerList[ii].ActionCommandList[0]);
      PlayerList[ii].txtActionCommand.text = PlayerList[ii].ActionCommandList[0];
      ActionCommand.TargetType currentTargetType = ActionCommand.IsTarget(PlayerList[ii].ActionCommandList[0]);
      if (currentTargetType == ActionCommand.TargetType.Enemy)
      {
        PlayerList[ii].Target = EnemyList[0];
      }
      else if (currentTargetType == ActionCommand.TargetType.Ally)
      {
        PlayerList[ii].Target = PlayerList[0];
      }
    }
    for (int ii = 0; ii < EnemyList.Count; ii++)
    {
      EnemyList[ii].CurrentActionCommand = EnemyList[ii].ActionCommandList[0];
      ActionCommand.TargetType currentTargetType = ActionCommand.IsTarget(EnemyList[ii].ActionCommandList[0]);
      if (currentTargetType == ActionCommand.TargetType.Enemy)
      {
        EnemyList[ii].Target = PlayerList[0];
      }
      else if (currentTargetType == ActionCommand.TargetType.Ally)
      {
        EnemyList[ii].Target = EnemyList[0];
      }
    }

    //this.currentPlayer = PlayerList[0];

    this.AllFieldList.Add(this.PanelPlayerField);
    this.AllFieldList.Add(this.PanelEnemyField);

    LogicInvalidate();
  }

  private void AddPlayerFromOne(Character character, NodeBattleChara node, GameObject arrow, NodeActionPanel group_parent_actionpanel, GameObject groupActionButton, Image instant_gauge_ac, Image potential_energy)
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
    character.txtSoulPoint = node.txtSoulPoint;
    character.objBackInstantGauge = node.objBackSoulPointGauge;
    character.objCurrentSoulPointGauge = node.objCurrentSoulPointGauge;
    character.objCurrentSoulPointBorder = node.objCurrentSoulPointBorder;
    character.objMainButton = node.objMainButton;
    character.txtActionCommand = node.txtActionCommand;
    character.groupActionPoint = node.groupActionPoint;
    character.objBuffPanel = node.groupBuff;
    character.txtTargetName = node.txtTargetName;
    character.imgTargetLifeGauge = node.imgTargetLifeGauge;

    character.objParentActionPanel = group_parent_actionpanel;
    character.groupActionButton = groupActionButton;
    character.imgCurrentEnergyPointGauge = potential_energy;

    // GUI画面向けオブジェクトの登録
    if (character.txtName != null)
    {
      character.txtName.text = character.FullName;
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
    }
    if (character.objBackInstantGauge)
    {
      character.objBackInstantGauge.color = character.BattleBackColor;
    }
    if (character.txtSoulPoint != null)
    {
      character.txtSoulPoint.text = character.CurrentSoulPoint.ToString();
    }

    // アクションコマンドボタンの割当を設定する。
    if (groupActionButton != null)
    {
      character.ActionCommandList.Clear();
      if (character.Job == Fix.JobClass.Fighter)
      {
        AddActionButton(character, groupActionButton, Fix.NORMAL_ATTACK);
      }
      else if (character.Job == Fix.JobClass.Magician)
      {
        AddActionButton(character, groupActionButton, Fix.MAGIC_ATTACK);
      }
      else if (character.Job == Fix.JobClass.Seeker)
      {
        AddActionButton(character, groupActionButton, Fix.NORMAL_ATTACK);
        AddActionButton(character, groupActionButton, Fix.MAGIC_ATTACK);
      }
      AddActionButton(character, groupActionButton, Fix.DEFENSE);
      if (character.FireBolt > 0) { AddActionButton(character, groupActionButton, Fix.FIRE_BOLT); }
      if (character.IceNeedle > 0) { AddActionButton(character, groupActionButton, Fix.ICE_NEEDLE); }
      if (character.FreshHeal > 0) { AddActionButton(character, groupActionButton, Fix.FRESH_HEAL); }
      if (character.ShadowBlast > 0) { AddActionButton(character, groupActionButton, Fix.SHADOW_BLAST); }
      if (character.AuraOfPower > 0) { AddActionButton(character, groupActionButton, Fix.AURA_OF_POWER); }
      if (character.DispelMagic > 0) { AddActionButton(character, groupActionButton, Fix.DISPEL_MAGIC); }
      if (character.StraightSmash > 0) { AddActionButton(character, groupActionButton, Fix.STRAIGHT_SMASH); }
      if (character.ShieldBash > 0) { AddActionButton(character, groupActionButton, Fix.SHIELD_BASH); }
      if (character.HunterShot > 0) { AddActionButton(character, groupActionButton, Fix.HUNTER_SHOT); }
      if (character.VenomSlash > 0) { AddActionButton(character, groupActionButton, Fix.VENOM_SLASH); }
      if (character.HeartOfLife > 0) { AddActionButton(character, groupActionButton, Fix.HEART_OF_LIFE); }
      if (character.OracleCommand > 0) { AddActionButton(character, groupActionButton, Fix.ORACLE_COMMAND); }
      if (character.FlameBlade > 0) { AddActionButton(character, groupActionButton, Fix.FLAME_BLADE); }
      if (character.PurePurification > 0) { AddActionButton(character, groupActionButton, Fix.PURE_PURIFICATION); }
      if (character.DivineCircle> 0) { AddActionButton(character, groupActionButton, Fix.DIVINE_CIRCLE); }
      if (character.BloodSign> 0) { AddActionButton(character, groupActionButton, Fix.BLOOD_SIGN); }
      if (character.SkyShield > 0) { AddActionButton(character, groupActionButton, Fix.SKY_SHIELD); }
      if (character.FlashCounter > 0) { AddActionButton(character, groupActionButton, Fix.FLASH_COUNTER); }
      if (character.StanceOfTheBlade > 0) { AddActionButton(character, groupActionButton, Fix.STANCE_OF_THE_BLADE); }
      if (character.StanceOfTheGuard > 0) { AddActionButton(character, groupActionButton, Fix.STANCE_OF_THE_GUARD); }
      if (character.MultipleShot > 0) { AddActionButton(character, groupActionButton, Fix.MULTIPLE_SHOT); }
      if (character.InvisibleBind > 0) { AddActionButton(character, groupActionButton, Fix.INVISIBLE_BIND); }
      if (character.FortuneSpirit > 0) { AddActionButton(character, groupActionButton, Fix.FORTUNE_SPIRIT); }
      if (character.SpiritualRest > 0) { AddActionButton(character, groupActionButton, Fix.SPIRITUAL_REST); }

      //for (int ii = 0; ii < character.ActionCommandList.Count; ii++)
      //{
      //  string commandName = character.ActionCommandList[ii];
      //  NodeActionCommand instant = Instantiate(prefab_MainAction) as NodeActionCommand;
      //  instant.BackColor.color = character.BattleForeColor;
      //  instant.CommandName = commandName;
      //  instant.name = commandName;
      //  instant.OwnerName = character.FullName;
      //  instant.ActionButton.name = commandName;
      //  instant.ActionButton.image.sprite = Resources.Load<Sprite>(commandName);

      //  instant.transform.SetParent(groupActionButton.transform);
      //  instant.gameObject.SetActive(true);
      //}
    }

    // アクションポイントのビュー割当を設定する。
    if (character.groupActionPoint != null)
    {
      character.imgActionPointList = new List<Image>();
      Image[] imageList = character.groupActionPoint.GetComponentsInChildren<Image>();
      for (int jj = 0; jj < imageList.Length; jj++)
      {
        //Debug.Log(imageList[jj].name);
        character.imgActionPointList.Add(imageList[jj]);
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
    // アニメーションを実行する。この間、時間を進めない。
    if (NowAnimationMode)
    {
      ExecAnimation();
      return;
    }
    // スタックインザコマンドを実行中。この間、時間を進めない。
    if (NowStackInTheCommand)
    {
      ExecStackInTheCommand();
      return;
    }

    // ターゲット選択中は、時間を進めない。
    if (NowSelectTarget || NowInstantTarget)
    {
      return;
    }
    // タイムステータスの状況に応じて、時間を進めない。
    if (TimeStatus == Fix.BattleStatus.Ready || TimeStatus == Fix.BattleStatus.Stop)
    {
      return;
    }
    // バトルが完了している場合、時間を進めない。
    if (BattleEnd != GameEndType.None)
    {
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
      this.BattleEnd = GameEndType.Success;
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
          }
        }
        One.TF.Gold += gainGold;

        txtGameEndMessage.text = "敵を倒した。\r\n" + gainExp + "経験値を獲得。\r\n" + gainGold + "ゴールドを獲得";
        panelGameEnd.SetActive(true);

        // todo ここでイベントフラグを制御してよいか、再考の余地はある。
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
      }
      return;
    }
    // プレイヤー側が全滅した場合、ゲームエンドとする。
    if (CheckGroupAlive(PlayerList) == false)
    {
      this.BattleEnd = GameEndType.Fail;
      if (panelGameEnd.activeInHierarchy == false)
      {
        txtGameEndMessage.text = PlayerList[0].FullName + "達は全滅しました・・・\r\n街へ戻ります。";
        panelGameEnd.SetActive(true);
      }
      return;
    }

    LogicInvalidate();

    // プレイヤーゲージを進行する。
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (AllList[ii].Dead == false && AllList[ii].IsSleep == false && AllList[ii].IsStun == false)
      {
        UpdatePlayerArrow(AllList[ii]);
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
      //Debug.Log("width: " + GroupBattleGauge.GetComponent<RectTransform>().rect.width);
      if (rectX.position.x <= (GroupBattleGauge.GetComponent<RectTransform>().rect.width - rectX.sizeDelta.x) / 5.0f)
      {
        if (EnemyList[ii].Target != null && EnemyList[ii].Target.Dead && EnemyList[ii].Target.IsEnemy == false)
        {
          Character current = SearchOpponentForEnemy(PlayerList);
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
      if (rectX.position.x >= (GroupBattleGauge.GetComponent<RectTransform>().rect.width - rectX.sizeDelta.x) / 4.0f && EnemyList[ii].Decision == false)
      {
        EnemyList[ii].Decision = true;
        string decision = EnemyList[ii].ChooseCommand();
        EnemyList[ii].CurrentActionCommand = decision;
        EnemyList[ii].txtActionCommand.text = decision;
      }
    }

    LogicInvalidate();

    // Duelモード専用
    // 敵プレイヤー側がインスタントが溜まった場合、スタックインザコマンドを発動する。
    if (this.DuelMode)
    {
      for (int ii = 0; ii < EnemyList.Count; ii++)
      {
        //if (EnemyList[ii].CurrentInstantPoint >= EnemyList[ii].MaxInstantPoint)
        //{
        //    EnemyList[ii].CurrentInstantPoint = 0;
        //    EnemyList[ii].UpdateInstantPointGauge();

        //    CreateStackObject(EnemyList[ii], PlayerList[0], Fix.STRAIGHT_SMASH, 100);
        //    return; // メインフェーズの行動を起こさせないため、ここで強制終了させる。
        //}
      }
    }

    // プレイヤ－ゲージがたまった場合、アクションコマンドを実行する。
    for (int ii = 0; ii < AllList.Count; ii++)
    {
      if (AllList[ii].Dead == false)
      {
        RectTransform rectX = AllList[ii].objArrow.GetComponent<RectTransform>();
        if (rectX.position.x >= GroupBattleGauge.GetComponent<RectTransform>().rect.width - rectX.sizeDelta.x)
        {
          ExecPlayerCommand(AllList[ii], AllList[ii].Target, string.Empty);
          UpdatePlayerArrowZero(AllList[ii], AllList[ii].objArrow);
          AllList[ii].Decision = false;
          break;
        }
      }
    }

    LogicInvalidate();
  }

  private void CreateStackObject(Character player, Character target, string command_name, int timer)
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
    stack.ConstructStack(player, target, command_name, timer);
    stack.gameObject.SetActive(true);

    this.NowStackInTheCommand = true;
    GroupStackInTheCommand.SetActive(true);
  }

  private void LogicInvalidate()
  {
    UpdateTimerSpeed();

    for (int ii = 0; ii < AllList.Count; ii++)
    {
      // プレイヤーのリソースゲージ値を更新する。
      if (AllList[ii].Dead == false)
      {
        AllList[ii].UpdateLife();
        AllList[ii].UpdatePlayerInstantPoint();
        AllList[ii].UpdateActionPoint();
        AllList[ii].UpdateEnergyPoint();
        AllList[ii].UpdateSoulPoint();
      }
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
    UpdateCharacterDead(this.AllList);
  }

  private Character SearchOpponentForEnemy(List<Character> player_list)
  {
    for (int ii = 0; ii < player_list.Count; ii++)
    {
      if (player_list[ii].Dead == false)
      {
        return player_list[ii];
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
  private void SetupActionCommandButton(Button button, string command_name)
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

  /// <summary>
  /// プレイヤーコマンドを実行します。
  /// </summary>
  private void ExecPlayerCommand(Character player, Character target, string command_name)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + player?.FullName);

    if (player == null)
    {
      Debug.Log("Player is null, then no action.");
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      return;
    }
    if (target == null)
    {
      Debug.Log("Target is null, then no action.");
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_MISS, Fix.COLOR_NORMAL);
      return;
    }
    if (target.Dead && command_name != Fix.RESURRECTION)
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
      StartAnimation(player.objGroup.gameObject, "Miss", Fix.COLOR_NORMAL);
      return;
    }

    if (player.IsBind && command_name != Fix.DEFENSE)
    {
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_BIND, Fix.COLOR_NORMAL);
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


    if (player.CurrentSoulPoint < ActionCommand.CostSP(command_name))
    {
      Debug.Log("NO SP: [" + command_name + "] " + player.CurrentSoulPoint + " < " + ActionCommand.CostSP(command_name));
      StartAnimation(player.objGroup.gameObject, Fix.BATTLE_SP_LESS, Fix.COLOR_NORMAL);
      return;
    }
    player.CurrentSoulPoint -= ActionCommand.CostSP(command_name);

    player.CurrentEnergyPoint += 1000;

    // ブラッド・サインによる効果
    if (player.IsBloodSign && ActionCommand.GetAttribute(command_name) == ActionCommand.Attribute.Magic)
    {
      ExecSlipDamage(player, player.IsBloodSign.EffectValue);
    }

    // ディバイン・フィールドによる効果
    GameObject panelField = GetPanelFieldFromPlayer(target);
    if (ActionCommand.IsDamage(command_name))
    {
      Debug.Log("IsDamage: " + command_name);
      BuffImage buffImage = PreCheckFieldEffect(panelField, Fix.DIVINE_CIRCLE);
      if (buffImage != null)
      {
        double damage = DamageFromCommand(player, command_name);
        Debug.Log("DivineShiled: " + player.FullName + " -> " + damage.ToString("F2"));
        buffImage.EffectValue -= damage;
        if (buffImage.EffectValue <= 0)
        {
          buffImage.RemoveBuff();
        }
        StartAnimation(panelField, Fix.BATTLE_DIVINE, Fix.COLOR_NORMAL);
        return; // todo ただし追加効果やダメージ軽減しきれなかった分があり、本来次のフェーズに繋げないといけない。
      }
    }

    // todo Critical Hit.  PlayerNormalAttackの基本攻撃ロジックの実装が必要となってきている。
    CriticalType critical = CriticalType.Random;
    BuffImage fortune = player.IsFortuneSpirit;
    if (ActionCommand.IsDamage(command_name) && fortune != null)
    {
      Debug.Log("Detect FortuneSpirit, then Absolute Critical.");
      critical = CriticalType.Absolute;
      fortune.RemoveBuff();
    }

    #region "コマンド実行"
    List<Character> target_group = null;
    Debug.Log("Command: " + command_name);
    switch (command_name)
    {
      case Fix.NORMAL_ATTACK:
        ExecNormalAttack(player, target, SecondaryLogic.NormalAttack(player), critical);
        break;

      case Fix.MAGIC_ATTACK:
        ExecMagicAttack(player, target, SecondaryLogic.MagicAttack(player), Fix.CommandAttribute.None, critical);
        break;

      case Fix.DEFENSE:
        player.CurrentActionCommand = Fix.DEFENSE;
        player.txtActionCommand.text = Fix.DEFENSE;
        break;

      case Fix.STAY:
        // 何もしない
        break;

      case Fix.USE_RED_POTION:
        ExecUseRedPotion(target);
        break;

      case Fix.FIRE_BOLT:
        ExecFireBolt(player, target, critical);
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

      case Fix.AURA_OF_POWER:
        ExecAuraOfPower(player, target);
        break;

      case Fix.DISPEL_MAGIC:
        ExecDispelMagic(player, target);
        break;

      case Fix.STRAIGHT_SMASH:
        ExecStraightSmash(player, target, critical);
        break;

      case Fix.SHIELD_BASH:
        ExecShieldBash(player, target, critical);
        break;

      case Fix.HUNTER_SHOT:
        ExecHunterShot(player, target, critical);
        break;

      case Fix.VENOM_SLASH:
        ExecVenomSlash(player, target, critical);
        break;

      case Fix.HEART_OF_LIFE:
        ExecHeartOfLife(player, target);
        break;

      case Fix.ORACLE_COMMAND:
        ExecOracleCommand(player, target);
        break;

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
        bool detect = false;
        string buff_name = Fix.DIVINE_CIRCLE;
        GameObject targetPanel = GetPanelFieldFromPlayer(target);
        BuffImage[] buffList = targetPanel.GetComponentsInChildren<BuffImage>();
        for (int ii = 0; ii < buffList.Length; ii++)
        {
          if (buffList[ii].BuffName == buff_name)
          {
            buffList[ii].UpdateBuff(buff_name, SecondaryLogic.DivineCircle_Turn(player), SecondaryLogic.DivineCircle(player));
            detect = true;
            break;
          }
        }
        if (detect == false)
        {
          for (int ii = 0; ii < buffList.Length; ii++)
          {
            if (buffList[ii].BuffName == string.Empty)
            {
              buffList[ii].UpdateBuff(buff_name, SecondaryLogic.DivineCircle_Turn(player), SecondaryLogic.DivineCircle(player));
              detect = true;
              break;
            }
          }
        }
        StartAnimation(target.objGroup.gameObject, Fix.DIVINE_CIRCLE, Fix.COLOR_NORMAL);
        break;

      case Fix.SKY_SHIELD:
        ExecSkyShield(player, target);
        break;

      case Fix.FLASH_COUNTER:
        ExecFlashCounter(player, GroupStackInTheCommand.GetComponentsInChildren<StackObject>());
        break;

      case Fix.STANCE_OF_THE_BLADE:
        ExecStanceOfTheBlade(player, target);
        break;

      case Fix.STANCE_OF_THE_GUARD:
        ExecStanceOfTheGuard(player, target);
        break;

      case Fix.MULTIPLE_SHOT:
        target_group = GetOpponentGroup(player);
        ExecMultipleShot(player, target_group, critical);
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

      case Fix.ZERO_IMMUNITY:
        ExecZeroImmunity(player, target);
        break;

      case Fix.CIRCLE_SLASH:
        target_group = GetOpponentGroup(player);
        ExecCircleSlash(player, target_group, critical);
        break;

      case Fix.DOUBLE_SLASH:
        ExecDoubleSlash(player, target, critical);
        break;

      // 以下、モンスターアクションはmagic numberでよい
      case Fix.COMMAND_HIKKAKI:
        ExecNormalAttack(player, target, 1.30f, critical);
        break;

      case Fix.COMMAND_GREEN_NENEKI:
        ExecBuffPoison(player, target, 2, 7);
        break;

      case Fix.COMMAND_KANAKIRI:
        ExecBuffDizzy(player, target, 2, 30.0f);
        break;

      case Fix.COMMAND_WILD_CLAW:
        ExecNormalAttack(player, target, 1.35f, critical);
        break;

      case Fix.COMMAND_KAMITSUKI:
        ExecNormalAttack(player, target, 1.40f, critical);
        break;

      case Fix.COMMAND_TREE_SONG:
        ExecBuffSleep(player, target, 2, 0);
        break;

      case Fix.COMMAND_SUN_FIRE:
        ExecMagicAttack(player, target, 1.35f, Fix.CommandAttribute.Fire, critical);
        break;

      case Fix.COMMAND_TOSSHIN:
        ExecNormalAttack(player, target, 1.10f, critical);
        ExecBuffStun(player, target, 1, 0);
        break;

      case Fix.COMMAND_FEATHER_WING:
        ExecMagicAttack(player, target, 0.5f, Fix.CommandAttribute.None, critical);
        ExecBuffSleep(player, target, 2, 0);
        break;

      case Fix.COMMAND_POISON_RINPUN:
        ExecBuffPoison(player, target, 3, 33);
        break;

      case Fix.COMMAND_YOUEN_FIRE:
        ExecMagicAttack(player, target, 1.40f, Fix.CommandAttribute.Fire, critical);
        break;

      case Fix.COMMAND_BLAZE_DANCE:
        BuffUpFire(player, player, 5, 1.20f);
        break;

      default:
        Debug.Log("Nothing Command: " + command_name);
        break;
    }
    #endregion
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

  private GameObject GetPanelFieldFromPlayer(Character player)
  {
    if (player.Ally == Fix.Ally.Ally)
    {
      return this.PanelPlayerField;
    }
    if (player.Ally == Fix.Ally.Enemy)
    {
      return this.PanelEnemyField;
    }
    return null;
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
  private void StartAnimation(GameObject targetObj, string message, Color color)
  {
    DamageObject damageObj = Instantiate(this.prefab_Damage, new Vector3(0, 0, 0), Quaternion.identity) as DamageObject;
    // 対象オブジェクトにリンクさせて位置を設定する。
    damageObj.transform.SetParent(targetObj.transform);
    damageObj.name = "DamageObject";
    RectTransform rect = damageObj.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    rect.anchorMin = new Vector2(0, 0);
    rect.anchorMax = new Vector2(0, 0);
    rect.pivot = new Vector2(0, 0);
    rect.anchoredPosition = new Vector2(0, 0);

    // アニメーショングループに再設定してアニメーション表示する。
    damageObj.Construct(message, color, MAX_ANIMATION_TIME);
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
    DamageObject[] damageObj = GroupAnimation.GetComponentsInChildren<DamageObject>();
    for (int ii = 0; ii < damageObj.Length; ii++)
    {
      if (damageObj[ii].Timer > 0)
      {
        damageObj[ii].Timer--;
        RectTransform rect = damageObj[ii].txtMessage.GetComponent<RectTransform>();
        float moveX = 0.0f;
        if (damageObj[ii].Timer <= MAX_ANIMATION_TIME - 15) { moveX = 0.0f; }
        else if (damageObj[ii].Timer <= MAX_ANIMATION_TIME - 10) { moveX = 1.0f; }
        else if (damageObj[ii].Timer <= MAX_ANIMATION_TIME - 5) { moveX = 2.0f; }
        else { moveX = 7.0f; }

        rect.position = new Vector3(rect.position.x + moveX, rect.position.y, rect.position.z);

        detect = true;

        if (damageObj[ii].Timer <= 0)
        {
          //EndAnimation(damageObj[ii].txtMessage);
          RectTransform rect2 = damageObj[ii].txtMessage.GetComponent<RectTransform>();
          rect2.position = new Vector3(0, rect.position.y, rect.position.z);
          damageObj[ii].txtMessage.gameObject.SetActive(false);
          Destroy(damageObj[ii].gameObject);
          damageObj[ii] = null;
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

    // スタックがあれば、最後に積まれたスタックを優先処理する。
    int num = stackList.Length - 1;
    stackList[num].StackTimer--;
    stackList[num].txtStackTime.text = stackList[num].StackTimer.ToString();
    if (stackList[num].StackTimer <= 0)
    {
      ExecPlayerCommand(stackList[num].Player, stackList[num].Target, stackList[num].StackName);
      StackObject[] current = GroupStackInTheCommand.GetComponentsInChildren<StackObject>();
      if (current.Length > 0)
      {
        Debug.Log("curren is existed: " + current.Length.ToString());
        Destroy(current[current.Length - 1].gameObject);
        current[current.Length - 1] = null;
      }
    }
  }

  /// <summary>
  /// プレイヤーの行動ゲージを更新します。
  /// </summary>
  private void UpdatePlayerArrow(Character player)
  {
    RectTransform rect = player.objArrow.GetComponent<RectTransform>();
    float speedValue = (float)PrimaryLogic.BattleSpeed(player);
    //Debug.Log("speedValue: " + speedValue);
    // 画面の枠の大きさに応じて、スピード倍率を調整する。(ベース100)
    // プレイヤーアローの大きさの分を画面枠から差し引いて調整する。
    float factor = (GroupBattleGauge.GetComponent<RectTransform>().rect.width - rect.sizeDelta.x) / 100.0f;
    //Debug.Log("factor: " + factor);
    speedValue = speedValue * factor * SpeedFactor();
    //Debug.Log("speedValue2: " + speedValue);
    rect.position = new Vector3(rect.position.x + speedValue, rect.position.y, rect.position.z);
    if (rect.position.x >= GroupBattleGauge.GetComponent<RectTransform>().rect.width - rect.sizeDelta.x)
    {
      rect.position = new Vector3(GroupBattleGauge.GetComponent<RectTransform>().rect.width - rect.sizeDelta.x, rect.position.y, rect.position.z);
    }
  }

  /// <summary>
  /// プレイヤーの行動ゲージを０に設定します。
  /// </summary>
  /// <param name="player"></param>
  /// <param name="arrow"></param>
  private void UpdatePlayerArrowZero(Character player, GameObject arrow)
  {
    RectTransform rect = arrow.GetComponent<RectTransform>();
    rect.position = new Vector3(0, rect.position.y, rect.position.z);
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
        if (sender.Equals(EnemyList[ii].objMainButton))
        {
          Debug.Log("First target is enemy, then no action.");
          return;
        }
      }

      // 最初は味方をターゲットにする。
      //bool detectChange = false;
      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        Debug.Log(PlayerList[ii].objMainButton.name);
        if (sender.Equals(PlayerList[ii].objMainButton))
        {
          //if (this.currentPlayer.Equals(PlayerList[ii]) == false)
          //{
          //  detectChange = true;
          //}
          //
          //this.currentPlayer = PlayerList[ii];
          ////this.txtCurrentPlayerName.text = PlayerList[ii].FullName;
          ////this.imgCurrentPlayerActionButton.color = PlayerList[ii].BattleColor;

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
              if (this.NowSelectActionDstButton.Equals(EnemyList[jj].objMainButton))
              {
                // アクションコマンドを更新
                PlayerList[ii].CurrentActionCommand = this.NowSelectActionSrcButton.name;
                PlayerList[ii].txtActionCommand.text = this.NowSelectActionSrcButton.name;
                CopyActionButton(this.NowSelectActionSrcButton, PlayerList[ii].objMainButton);

                // ターゲット敵を更新
                PlayerList[ii].Target = EnemyList[jj];
              }
            }
          }
        }
        else if (this.NowSelectActionSrcButton.name == Fix.USE_RED_POTION)
        {
          for (int ii = 0; ii < PlayerList.Count; ii++)
          {
            if (this.NowSelectActionDstButton.Equals(PlayerList[ii].objMainButton))
            {
              ExecUseRedPotion(PlayerList[ii]);
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
              if (NowSelectActionSrcButton.Equals(PlayerList[ii].objMainButton))
              {
                // ターゲットを反映する。
                for (int jj = 0; jj < AllList.Count; jj++)
                {
                  if (NowSelectActionDstButton.Equals(AllList[jj].objMainButton))
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
                CopyActionButton(NowSelectActionCommandButton, NowSelectActionSrcButton);
                PlayerList[ii].CurrentActionCommand = NowSelectActionCommandButton.name;
                PlayerList[ii].txtActionCommand.text = NowSelectActionCommandButton.name;
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
              if (NowSelectActionDstButton.Equals(AllList[ii].objMainButton))
              {
                Debug.Log("instant target is " + AllList[ii].FullName);
                ExecPlayerCommand(this.NowSelectSrcPlayer, AllList[ii], NowSelectActionCommandButton.name);
                break;
              }
            }

            this.NowSelectSrcPlayer.CurrentInstantPoint = 0;
            this.NowSelectSrcPlayer.UpdateInstantPointGauge();
          }
          // 決定後、通常の戦闘モードに戻す。
          ClearSelectFilterGroup();
        }
      }
    }
  }

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

    // 自分自身の場合はその場で選択決定。（防御など）
    ActionCommand.TargetType targetType = ActionCommand.IsTarget(sender.CommandName);
    if (targetType == ActionCommand.TargetType.Own)
    {
      CopyActionButton(sender.ActionButton, this.NowSelectSrcPlayer.objMainButton);
      this.NowSelectSrcPlayer.CurrentActionCommand = sender.CommandName;
      this.NowSelectSrcPlayer.txtActionCommand.text = sender.CommandName;
      // 決定後、通常の戦闘モードに戻す。
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
  public void TapPlayerActionButton(Button sender)
  {
    // 対象元を検索する。
    if (this.NowSelectSrcPlayer == null)
    {
      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        if (PlayerList[ii].objActionButtonList == null) { continue; }

        for (int jj = 0; jj < PlayerList[ii].objActionButtonList.Count; jj++)
        {
          if (sender.Equals(PlayerList[ii].objActionButtonList[jj]))
          {
            this.NowSelectSrcPlayer = PlayerList[ii];
            break;
          }
        }
      }
    }

    if (this.NowSelectSrcPlayer == null)
    {
      Debug.Log("selectedPlayer is null, then no action.");
      return;
    }

    if (this.NowStackInTheCommand == false)
    {
      if (sender.name == Fix.DEFENSE)
      {
        CopyActionButton(sender, this.NowSelectSrcPlayer.objMainButton);
        this.NowSelectSrcPlayer.CurrentActionCommand = Fix.DEFENSE;
        this.NowSelectSrcPlayer.txtActionCommand.text = Fix.DEFENSE;
        // 決定後、通常の戦闘モードに戻す。
        ClearSelectFilterGroup();
        return;
      }

      this.NowSelectTarget = true;
      SelectFilter.SetActive(true);
      GroupMainActionCommand.SetActive(false);

      this.NowSelectActionCommandButton = sender;
    }
    else
    {
      if (this.NowSelectSrcPlayer.CurrentInstantPoint >= this.NowSelectSrcPlayer.MaxInstantPoint)
      {
        this.NowSelectSrcPlayer.CurrentInstantPoint = 0;
        this.NowSelectSrcPlayer.UpdateInstantPointGauge();
        CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.name, 100);
      }
    }
  }

  public void TapInstantAction(NodeActionCommand sender)
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

    // インスタント値が不足している場合、行動できない。
    if (this.NowSelectSrcPlayer.CurrentInstantPoint < this.NowSelectSrcPlayer.MaxInstantPoint)
    {
      UpdateMessage(this.NowSelectSrcPlayer.CharacterMessage(1003));
      Debug.Log("Still now instant point. then no action.");
      return;
    }

    if (this.NowStackInTheCommand == false)
    {
      if (this.NowSelectSrcPlayer.IsSleep || this.NowSelectSrcPlayer.IsStun)
      {
        Debug.Log("CurrentPlayer is now sleeping or stunning, then no action.");
        return;
      }

      if (this.NowSelectTarget == false)
      {
        Debug.Log("TapPlayerActionButton: " + this.NowSelectSrcPlayer.FullName + " " + this.NowSelectSrcPlayer.CurrentInstantPoint.ToString() + " " + this.NowSelectSrcPlayer.MaxInstantPoint.ToString());
      }

      this.NowSelectTarget = true;
      SelectFilter.SetActive(true);
      this.NowInstantTarget = true;
      lblInstantAction.SetActive(true);

      this.NowSelectActionCommandButton = sender.ActionButton;
    }
    else
    {
      if (this.NowSelectSrcPlayer.CurrentInstantPoint >= this.NowSelectSrcPlayer.MaxInstantPoint)
      {
        this.NowSelectSrcPlayer.CurrentInstantPoint = 0;
        this.NowSelectSrcPlayer.UpdateInstantPointGauge();
        CreateStackObject(this.NowSelectSrcPlayer, EnemyList[0], sender.name, 100);
      }
    }
  }

  /// <summary>
  /// グローバルアクションボタン押下時の処理
  /// </summary>
  public void TapGlobalActionButton(Button sender)
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    switch (sender.name)
    {
      case Fix.DEFENSE:
        Debug.Log("Global Defense");
        for (int ii = 0; ii < PlayerList.Count; ii++)
        {
          PlayerList[ii].CurrentActionCommand = Fix.DEFENSE;
          PlayerList[ii].txtActionCommand.text = Fix.DEFENSE;
          CopyActionButton(sender, PlayerList[ii].objMainButton);
        }
        break;

      case Fix.NORMAL_ATTACK:
        Debug.Log("Global NormalAttack");
        if (this.NowSelectActionSrcButton == null)
        {
          this.NowSelectActionSrcButton = sender;
          SelectFilter.SetActive(true);
          //btnCancelSelect.SetActive(true);
          this.NowSelectTarget = true;
          this.NowSelectGlobal = true;
        }
        break;

      case Fix.USE_RED_POTION:
        Debug.Log("Global USE_RED_POTION");
        if (this.GlobalInstantValue < Fix.GLOBAL_INSTANT_MAX)
        {
          Debug.Log("Still not enough global gauge, then no action.");
          return;
        }
        Debug.Log("UsePotionRed");
        if (this.NowSelectActionSrcButton == null)
        {
          this.NowSelectActionSrcButton = sender;
          SelectFilter.SetActive(true);
          //btnCancelSelect.SetActive(true);
          this.NowSelectTarget = true;
          this.NowSelectGlobal = true;
        }
        break;

      case Fix.READY_BUTTON:
        Debug.Log("Global READY_BUTTON");
        this.TimeStatus = Fix.BattleStatus.Go;
        sender.GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.GO_BUTTON);
        sender.name = Fix.GO_BUTTON;
        break;

      case Fix.GO_BUTTON:
        Debug.Log("Global GO_BUTTON");
        this.TimeStatus = Fix.BattleStatus.Stop;
        sender.GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.STOP_BUTTON);
        sender.name = Fix.STOP_BUTTON;
        break;

      case Fix.STOP_BUTTON:
        Debug.Log("Global STOP_BUTTON");
        this.TimeStatus = Fix.BattleStatus.Go;
        sender.GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.GO_BUTTON);
        sender.name = Fix.GO_BUTTON;
        break;

      case Fix.RUNAWAY_BUTTON:
        Debug.Log("RUNAWAY_BUTTON");
        if (this.CannotRunAway)
        {
          Debug.Log("CannotRunAway is true, then prohibit RunAway.");
          return;
        }

        this.BattleEnd = GameEndType.RunAway;
        if (panelGameEnd.activeInHierarchy == false)
        {
          txtGameEndMessage.text = PlayerList[0].FullName + "達は逃げ出した・・・";
          panelGameEnd.SetActive(true);
        }
        break;

      default:
        Debug.Log("Unknown Command, then no action.");
        break;
    }
  }

  public void TapPotentialAction(Button sender)
  {
  }

  /// <summary>
  /// アクション行動選択中の状態を解除します。
  /// </summary>
  public void TapCancelSelect()
  {
    ClearSelectFilterGroup();
  }

  public void TapEndScene()
  {
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
    for (int ii = 0; ii < AllFieldList.Count; ii++)
    {
      BuffImage[] buffList = AllFieldList[ii].GetComponentsInChildren<BuffImage>();
      for (int jj = 0; jj < buffList.Length; jj++)
      {
        buffList[jj].BuffCountDown();
      }
    }

    for (int ii = 0; ii < AllList.Count; ii++)
    {
      AllList[ii].CurrentActionPoint += Fix.AP_BASE;
      AllList[ii].GainSoulPoint();
      AllList[ii].UpdateActionPoint();

      if (AllList[ii].IsHeartOfLife)
      {
        ExecLifeGain(AllList[ii], AllList[ii].IsHeartOfLife.EffectValue);
      }

      if (AllList[ii].IsPoison)
      {
        ExecPoisonDamage(AllList[ii], AllList[ii].IsPoison.EffectValue);
      }

      if (AllList[ii].IsBloodSign)
      {
        ExecSlipDamage(AllList[ii], AllList[ii].IsBloodSign.EffectValue);
      }

      AllList[ii].BuffCountdown();
    }
  }

  /// <summary>
  /// プレイヤーが死亡条件に合致した場合、死亡にします。
  /// </summary>
  private void UpdateCharacterDead(List<Character> group_list)
  {
    for (int ii = 0; ii < group_list.Count; ii++)
    {
      if (group_list[ii].CurrentLife <= 0)
      {
        group_list[ii].DeadPlayer();
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
    return (11.0f - speedDown) / 10.0f;
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

  private void AddActionButton(Character character, GameObject group_action_button, string command_name)
  {
    NodeActionCommand instant = Instantiate(prefab_MainAction) as NodeActionCommand;
    instant.BackColor.color = character.BattleForeColor;
    instant.CommandName = command_name;
    instant.name = command_name;
    instant.OwnerName = character.FullName;
    instant.ActionButton.name = command_name;
    instant.ActionButton.image.sprite = Resources.Load<Sprite>(command_name);

    instant.transform.SetParent(group_action_button.transform);
    instant.gameObject.SetActive(true);

    character.ActionCommandList.Add(command_name);
    Debug.Log("character AC add: " + character.ActionCommandList.Count);

  }
  #endregion
}