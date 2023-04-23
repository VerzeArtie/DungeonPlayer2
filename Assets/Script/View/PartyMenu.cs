using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text;

public class PartyMenu : MotherBase
{
  public GroupCharacterStatus groupCharacterStatus;
  public GameObject groupPartyBattleSetting;
  public GameObject groupPartyCommand;
  public GameObject groupPartyItem;

  public Text txtGold;

  // Party-StayList
  public List<Button> StayList;
  public List<Text> StayListName;
  public List<Text> StayListLife;
  public List<Image> StayListLifeGauge;
  public List<Text> StayListManaPoint;
  public List<Image> StayListManaPointGauge;
  public List<Text> StayListSkillPoint;
  public List<Image> StayListSkillPointGauge;
  public List<GameObject> StayListCheckMark;
  public GameObject objCancelActionCommand;
  public Text txtCurrentName;
  public List<GameObject> objActionCommand;
  public Text txtBattleSettingCharacterName;

  // Battle-Setting
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

  // BackpackView
  public NodeBackpackView ParentBackpackView;

  // Inner Value
  private List<Character> PlayerList = new List<Character>();
  private Character CurrentPlayer = null;

  // Start is called before the first frame update
  public override void Start()
  {
    RefreshAllView();

    this.CurrentPlayer = PlayerList[0];
    TapStatus();
    TapStayListCharacter(StayListName[0]);
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void TapStatus()
  {
    SetupStayList();
    //    CallGroupPartyStatus(this.CurrentPlayer); // 移行前はコメントアウトしていない。要精査

    groupCharacterStatus.gameObject.SetActive(true);
    groupPartyCommand.SetActive(false);
    groupPartyItem.SetActive(false);
    groupPartyBattleSetting.SetActive(false);
  }
  public void TapCommand()
  {
    SetupStayList();
    groupCharacterStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(true);
    groupPartyItem.SetActive(false);
    groupPartyBattleSetting.SetActive(false);
  }

  public void TapItem()
  {
    SetupStayList();
    groupCharacterStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(false);
    groupPartyItem.SetActive(true);
    groupPartyBattleSetting.SetActive(false);
  }

  public void TapBattleSetting()
  {
    SetupStayList();
    groupCharacterStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(false);
    groupPartyItem.SetActive(false);
    groupPartyBattleSetting.SetActive(true);
  }

  public void TapBackpack()
  {
    if (ParentBackpackView.gameObject.activeInHierarchy)
    {
      ParentBackpackView.gameObject.SetActive(false);
      return;
    }

    ParentBackpackView.ConstructBackpackView(this);
    ParentBackpackView.gameObject.SetActive(true);
  }

  private void PartyMenuLoadded(Scene next, LoadSceneMode mode)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    SceneManager.sceneLoaded -= PartyMenuLoadded;
  }

  public void TapStayListCharacter(Text txt_name)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    // コマンド実行
    if (objCancelActionCommand.activeInHierarchy)
    {
      Character player = One.SelectCharacter(txtCurrentName.text);
      Character target = One.SelectCharacter(txt_name.text);

      double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.FreshHeal(player);
      Debug.Log(MethodBase.GetCurrentMethod());
      if (target.Dead)
      {
        return;
      }
      if (player.CurrentManaPoint < ActionCommand.Cost(Fix.FRESH_HEAL))
      {
        return;
      }
      player.CurrentManaPoint -= ActionCommand.Cost(Fix.FRESH_HEAL);

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
            PlayerList[ii].CurrentManaPoint += (int)effectValue;
          }
          else if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.SMALL_GREEN_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.NORMAL_GREEN_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.LARGE_GREEN_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.HUGE_GREEN_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.HQ_GREEN_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.THQ_GREEN_POTION ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.PERFECT_GREEN_POTION)
          {
            Item current = new Item(ParentBackpackView.CurrentSelectBackpack.ItemName);
            One.TF.DeleteBackpack(current, 1);
            double effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
            PlayerList[ii].CurrentSkillPoint += (int)effectValue;
          }
          // todo スキルポイント回復ポーションを復活させる事。
          else if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID_STRENGTH ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID2_STRENGTH ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID3_STRENGTH ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID4_STRENGTH ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID5_STRENGTH ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID6_STRENGTH ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID7_STRENGTH)
          {
            Item current = new Item(ParentBackpackView.CurrentSelectBackpack.ItemName);
            One.TF.DeleteBackpack(current, 1);
            int effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
            PlayerList[ii].Strength += effectValue;
          }
          else if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID_AGILITY ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID2_AGILITY ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID3_AGILITY ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID4_AGILITY ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID5_AGILITY ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID6_AGILITY ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID7_AGILITY)
          {
            Item current = new Item(ParentBackpackView.CurrentSelectBackpack.ItemName);
            One.TF.DeleteBackpack(current, 1);
            int effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
            PlayerList[ii].Agility += effectValue;
          }
          else if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID_INTELLIGENCE ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID2_INTELLIGENCE ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID3_INTELLIGENCE ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID4_INTELLIGENCE ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID5_INTELLIGENCE ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID6_INTELLIGENCE ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID7_INTELLIGENCE)
          {
            Item current = new Item(ParentBackpackView.CurrentSelectBackpack.ItemName);
            One.TF.DeleteBackpack(current, 1);
            int effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
            PlayerList[ii].Intelligence += effectValue;
          }
          else if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID_STAMINA ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID2_STAMINA ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID3_STAMINA ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID4_STAMINA ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID5_STAMINA ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID6_STAMINA ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID7_STAMINA)
          {
            Item current = new Item(ParentBackpackView.CurrentSelectBackpack.ItemName);
            One.TF.DeleteBackpack(current, 1);
            int effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
            PlayerList[ii].Stamina += effectValue;
          }
          else if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID_MIND ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID2_MIND ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID3_MIND ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID4_MIND ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID5_MIND ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID6_MIND ||
                   ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.GROWTH_LIQUID7_MIND)
          {
            Item current = new Item(ParentBackpackView.CurrentSelectBackpack.ItemName);
            One.TF.DeleteBackpack(current, 1);
            int effectValue = current.ItemValue1 + AP.Math.RandomInteger(1 + current.ItemValue2 - current.ItemValue1);
            PlayerList[ii].Mind += effectValue;
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
        if (this.groupCharacterStatus.gameObject.activeInHierarchy)
        {
          CallGroupPartyStatus(PlayerList[ii]); // 移行前はコメントアウトしていない。要精査
        }
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
    groupCharacterStatus.parentMotherBase = this;
    groupCharacterStatus.ReleaseIt();
    groupCharacterStatus.CurrentPlayer = player;
    groupCharacterStatus.UpdateCharacterDetailView(player);

    //SceneManager.sceneLoaded += CharacterStatusLoadded;
    //SceneDimension.SceneAdd("CharacterStatus");
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

  public void TapBackpackSelect(NodeBackpackItem sender)
  {
    ParentBackpackView.TapBackpackSelect(sender);
  }

  public void TapBackpackUse()
  {
    string current = (ParentBackpackView.CurrentSelectBackpack?.ItemName ?? String.Empty);
    if (current == Fix.SMALL_RED_POTION ||
        current == Fix.NORMAL_RED_POTION ||
        current == Fix.LARGE_RED_POTION ||
        current == Fix.HUGE_RED_POTION ||
        current == Fix.HQ_RED_POTION ||
        current == Fix.THQ_RED_POTION ||
        current == Fix.PERFECT_RED_POTION ||
        current == Fix.SMALL_BLUE_POTION ||
        current == Fix.NORMAL_BLUE_POTION ||
        current == Fix.LARGE_BLUE_POTION ||
        current == Fix.HUGE_BLUE_POTION ||
        current == Fix.HQ_BLUE_POTION ||
        current == Fix.THQ_BLUE_POTION ||
        current == Fix.PERFECT_BLUE_POTION ||
        current == Fix.SMALL_GREEN_POTION ||
        current == Fix.NORMAL_GREEN_POTION ||
        current == Fix.LARGE_GREEN_POTION ||
        current == Fix.HUGE_GREEN_POTION ||
        current == Fix.HQ_GREEN_POTION ||
        current == Fix.THQ_GREEN_POTION ||
        current == Fix.PERFECT_GREEN_POTION ||
        current == Fix.GROWTH_LIQUID_STRENGTH ||
        current == Fix.GROWTH_LIQUID2_STRENGTH ||
        current == Fix.GROWTH_LIQUID3_STRENGTH ||
        current == Fix.GROWTH_LIQUID4_STRENGTH ||
        current == Fix.GROWTH_LIQUID5_STRENGTH ||
        current == Fix.GROWTH_LIQUID6_STRENGTH ||
        current == Fix.GROWTH_LIQUID7_STRENGTH ||
        current == Fix.GROWTH_LIQUID_AGILITY ||
        current == Fix.GROWTH_LIQUID2_AGILITY ||
        current == Fix.GROWTH_LIQUID3_AGILITY ||
        current == Fix.GROWTH_LIQUID4_AGILITY ||
        current == Fix.GROWTH_LIQUID5_AGILITY ||
        current == Fix.GROWTH_LIQUID6_AGILITY ||
        current == Fix.GROWTH_LIQUID7_AGILITY ||
        current == Fix.GROWTH_LIQUID_INTELLIGENCE ||
        current == Fix.GROWTH_LIQUID2_INTELLIGENCE ||
        current == Fix.GROWTH_LIQUID3_INTELLIGENCE ||
        current == Fix.GROWTH_LIQUID4_INTELLIGENCE ||
        current == Fix.GROWTH_LIQUID5_INTELLIGENCE ||
        current == Fix.GROWTH_LIQUID6_INTELLIGENCE ||
        current == Fix.GROWTH_LIQUID7_INTELLIGENCE ||
        current == Fix.GROWTH_LIQUID_STAMINA ||
        current == Fix.GROWTH_LIQUID2_STAMINA ||
        current == Fix.GROWTH_LIQUID3_STAMINA ||
        current == Fix.GROWTH_LIQUID4_STAMINA ||
        current == Fix.GROWTH_LIQUID5_STAMINA ||
        current == Fix.GROWTH_LIQUID6_STAMINA ||
        current == Fix.GROWTH_LIQUID7_STAMINA ||
        current == Fix.GROWTH_LIQUID_MIND ||
        current == Fix.GROWTH_LIQUID2_MIND ||
        current == Fix.GROWTH_LIQUID3_MIND ||
        current == Fix.GROWTH_LIQUID4_MIND ||
        current == Fix.GROWTH_LIQUID5_MIND ||
        current == Fix.GROWTH_LIQUID6_MIND ||
        current == Fix.GROWTH_LIQUID7_MIND
        )
    {
      ParentBackpackView.objBlockFilter.SetActive(true);
    }
  }

  public void TapBackpackDetail()
  {
    ParentBackpackView.TapBackpackDetail();
  }

  public void TapBackpackDelete()
  {
    ParentBackpackView.TapBackpackDelete();
  }

  public void TapBackpackCancelAction()
  {
    ParentBackpackView.objBlockFilter.SetActive(false);
  }

  // バトル設定
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

  public void TapAvailableListButton(NodeActionCommand action_command)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    if (FilterForAll.activeInHierarchy == false)
    {
      if (action_command.CommandName == "" || action_command.CommandName == Fix.STAY)
      {
        return;
      }
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

  #region "アクションコマンド"
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
      if (player.CurrentManaPoint < ActionCommand.Cost(Fix.SHINING_HEAL))
      {
        return;
      }
      player.CurrentManaPoint -= ActionCommand.Cost(Fix.SHINING_HEAL);

      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.ShiningHeal(player);
        Character target = PlayerList[ii];
        if (target.Dead)
        {
          return;
        }

        if (healValue <= 0) { healValue = 0; }
        PlayerList[ii].CurrentLife += (int)healValue;
      }
      groupCharacterStatus.UpdateCharacterDetailView(groupCharacterStatus.CurrentPlayer);
    }
    SetupStayList();
  }

  public void TapCancelActionCommand()
  {
    objCancelActionCommand.SetActive(false);
  }
  #endregion

  // 閉じる
  public void TapExit()
  {
    SceneDimension.SceneClose(Fix.SCENE_PARTY_MENU);
  }

  #region "private"

  public override void RefreshAllView()
  {
    // プレイヤーリストの反映
    PlayerList.Clear();

    List<Character> list = One.AvailableCharacters;
    for (int ii = 0; ii < list.Count; ii++)
    {
      PlayerList.Add(list[ii]);
    }

    // パーティステータス画面への反映
    SetupStayList();

    // コマンド設定画面への反映
    SetupActionCommand(PlayerList[0], ActionCommand.CommandCategory.ActionCommand); // [基本行動]が一番左で最初だが、デフォルトはアクションコマンドを表示

    // バックパック情報を画面へ反映
    ParentBackpackView.ConstructBackpackView(this);

    // ゴールドへの反映
    txtGold.text = One.TF.Gold.ToString();
  }

  private void SetupStayList()
  {
    for (int ii = 0; ii < StayListName.Count; ii++)
    {
      if (StayList[ii] != null) { StayList[ii].gameObject.SetActive(false); }
      if (StayListName[ii] != null) { StayListName[ii].text = string.Empty; }
      if (StayListLife[ii] != null) { StayListLife[ii].text = string.Empty; }
      if (StayListManaPoint[ii] != null) { StayListManaPoint[ii].text = string.Empty; }
      if (StayListSkillPoint[ii] != null) { StayListSkillPoint[ii].text = string.Empty; }
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
      if (StayListManaPoint[ii] != null) { StayListManaPoint[ii].text = PlayerList[ii].CurrentManaPoint.ToString() + " / " + PlayerList[ii].MaxManaPoint.ToString(); }
      if (StayListManaPointGauge[ii] != null)
      {
        float dx = (float)PlayerList[ii].CurrentManaPoint / (float)PlayerList[ii].MaxManaPoint;
        StayListManaPointGauge[ii].rectTransform.localScale = new Vector2(dx, 1.0f);
      }
      if (StayListSkillPoint[ii] != null) { StayListSkillPoint[ii].text = PlayerList[ii].CurrentSkillPoint.ToString() + " / " + PlayerList[ii].MaxSkillPoint.ToString(); }
      if (StayListSkillPointGauge[ii] != null)
      {
        float dx = (float)PlayerList[ii].CurrentSkillPoint / (float)PlayerList[ii].MaxSkillPoint;
        StayListSkillPointGauge[ii].rectTransform.localScale = new Vector2(dx, 1.0f);
      }

      StayList[ii].gameObject.SetActive(true);
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
        continue;
      }

      ListActionCommandSet[ii].CommandName = actionList[ii];
      ListActionCommandSet[ii].name = actionList[ii];
      ListActionCommandSet[ii].ActionButton.name = actionList[ii];
      ListActionCommandSet[ii].ApplyImageIcon(actionList[ii]);
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
    groupCommandCategory.SetActive(true);
    btnCommandCategoryAction.gameObject.SetActive(true);
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
      ListAvailableCommandText[ii].text = currentList[ii];
    }
  }
  #endregion
}
