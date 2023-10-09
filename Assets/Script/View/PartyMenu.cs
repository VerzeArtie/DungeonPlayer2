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
  public GameObject btnEssenceTree;

  public GroupCharacterStatus groupCharacterStatus;
  public GameObject groupPartyBattleSetting;
  public GameObject groupPartyCommand;
  public GameObject groupPartyEssenceTree;
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

  // EssenceTreeView
  public GameObject GroupEssenceCategory;
  public Text txtEssenceTreeName;
  public Button btnEssence_First;
  public Button btnEssence_Second;
  public Button btnEssence_Third;
  public Button btnEssence_Fourth;
  public GameObject GroupEssenceList1;
  public GameObject GroupEssenceList2;
  public GameObject GroupEssenceList3;
  public GameObject GroupEssenceList4;
  public List<Text> txtEssenceCategoryList;
  public List<GameObject> GroupEssenceList;
  public List<Text> txtEssenceElementList;
  public List<Text> txtEssenceElementLevelList;
  public List<Image> imgEssenceElementList;
  public List<GameObject> objHideEssenceElementList;

  // Character ( Detail - Essence )
  public GameObject GroupSubViewStatus;
  public GameObject GroupSubViewCommandSetting;
  public GameObject GroupSubViewEssence;
  public List<NodeActionCommand> imgEssenceList;
  public List<Text> txtEssenceList;
  public List<NodeActionCommand> imgEssenceList2;
  public List<Text> txtEssenceList2;
  public List<NodeActionCommand> imgEssenceList3;
  public List<Text> txtEssenceList3;
  public List<NodeActionCommand> imgEssenceList4;
  public List<Text> txtEssenceList4;

  public List<NodeActionCommand> imgEssenceList1_1;
  public List<Text> txtEssenceList1_1;
  public List<NodeActionCommand> imgEssenceList1_2;
  public List<Text> txtEssenceList1_2;
  public List<NodeActionCommand> imgEssenceList1_3;
  public List<Text> txtEssenceList1_3;
  public List<NodeActionCommand> imgEssenceList2_1;
  public List<Text> txtEssenceList2_1;
  public List<NodeActionCommand> imgEssenceList2_2;
  public List<Text> txtEssenceList2_2;
  public List<NodeActionCommand> imgEssenceList2_3;
  public List<Text> txtEssenceList2_3;
  public List<NodeActionCommand> imgEssenceList3_1;
  public List<Text> txtEssenceList3_1;
  public List<NodeActionCommand> imgEssenceList3_2;
  public List<Text> txtEssenceList3_2;
  public List<NodeActionCommand> imgEssenceList3_3;
  public List<Text> txtEssenceList3_3;
  public List<NodeActionCommand> imgEssenceList4_1;
  public List<Text> txtEssenceList4_1;
  public List<NodeActionCommand> imgEssenceList4_2;
  public List<Text> txtEssenceList4_2;
  public List<NodeActionCommand> imgEssenceList4_3;
  public List<Text> txtEssenceList4_3;

  public Text txtEssencePoint;
  //public Image imgEssenceCurrent;
  public NodeActionCommand imgEssenceCurrent;
  public Text txtEssenceCurrentName;
  public Text txtEssenceCurrentDescription;
  public Text txtEssenceCurrentDescEffect;
  public GameObject groupEssenceDecision;
  public Image imgEssenceDecision;
  public Text txtEssenceDecisionTitle;
  public Text txtEssenceDecisionMessage;
  public Button btnEssenceDecisionAccept;
  public Button btnEssenceDecisionCancel;
  public Button btnEssenceDecisionOK;

  public GameObject panelHideOther;
  // Inner Value
  private List<Character> PlayerList = new List<Character>();
  private Character CurrentPlayer = null;

  private string SwitchCharacter = string.Empty;

  // Start is called before the first frame update
  public override void Start()
  {
    RefreshAllView();

    this.CurrentPlayer = PlayerList[0];
    TapStatus();
    TapStayListCharacter(StayListName[0]);
    TapSelectEssence(txtEssenceElementList[0]);
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
    groupPartyEssenceTree.SetActive(false);
  }
  public void TapCommand()
  {
    SetupStayList();
    groupCharacterStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(true);
    groupPartyItem.SetActive(false);
    groupPartyBattleSetting.SetActive(false);
    groupPartyEssenceTree.SetActive(false);
  }

  public void TapItem()
  {
    SetupStayList();
    groupCharacterStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(false);
    groupPartyItem.SetActive(true);
    groupPartyBattleSetting.SetActive(false);
    groupPartyEssenceTree.SetActive(false);
  }

  public void TapBattleSetting()
  {
    SetupStayList();
    groupCharacterStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(false);
    groupPartyItem.SetActive(false);
    groupPartyBattleSetting.SetActive(true);
    groupPartyEssenceTree.SetActive(false);
  }

  public void TapEssenceTree()
  {
    SetupStayList();
    groupCharacterStatus.gameObject.SetActive(false);
    groupPartyCommand.SetActive(false);
    groupPartyItem.SetActive(false);
    groupPartyBattleSetting.SetActive(false);
    groupPartyEssenceTree.SetActive(true);
  }

  public void TapSwitchFormation()
  {
    panelHideOther.SetActive(!panelHideOther.activeInHierarchy);
    this.SwitchCharacter = string.Empty;
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

    // 隊列変更
    if (panelHideOther.activeInHierarchy)
    {
      Debug.Log("panelHideOther.activeInHierarchy is true, switch phase");
      if (this.SwitchCharacter == String.Empty)
      {
        Debug.Log("SwitchCharacter is empty, then set it: " + txt_name.text);
        this.SwitchCharacter = txt_name.text;
      }
      else if (this.SwitchCharacter == txt_name.text)
      {
        Debug.Log("SwitchCharacter is save, then cancel it: " + txt_name.text);
        // 同じ場合はキャンセル扱い
        this.SwitchCharacter = String.Empty;
      }
      else
      {
        // もう少し良い書き方があるはず。趣味なので探してみて最適化する事。
        Debug.Log("SwitchCharacter start: " + this.SwitchCharacter + " -> " + txt_name.text);
        // Swap
        if (One.TF.BattlePlayer1 == txt_name.text)
        {
          One.TF.BattlePlayer1 = this.SwitchCharacter;
          if (One.TF.BattlePlayer2 == this.SwitchCharacter) { One.TF.BattlePlayer2 = txt_name.text; }
          else if (One.TF.BattlePlayer3 == this.SwitchCharacter) { One.TF.BattlePlayer3 = txt_name.text; }
          else if (One.TF.BattlePlayer4 == this.SwitchCharacter) { One.TF.BattlePlayer4 = txt_name.text; }
          else if (One.TF.BattlePlayer5 == this.SwitchCharacter) { One.TF.BattlePlayer5 = txt_name.text; }
          else if (One.TF.BattlePlayer6 == this.SwitchCharacter) { One.TF.BattlePlayer6 = txt_name.text; }
        }
        else if (One.TF.BattlePlayer2 == txt_name.text)
        {
          One.TF.BattlePlayer2 = this.SwitchCharacter;
          if (One.TF.BattlePlayer1 == this.SwitchCharacter) { One.TF.BattlePlayer1 = txt_name.text; }
          else if (One.TF.BattlePlayer3 == this.SwitchCharacter) { One.TF.BattlePlayer3 = txt_name.text; }
          else if (One.TF.BattlePlayer4 == this.SwitchCharacter) { One.TF.BattlePlayer4 = txt_name.text; }
          else if (One.TF.BattlePlayer5 == this.SwitchCharacter) { One.TF.BattlePlayer5 = txt_name.text; }
          else if (One.TF.BattlePlayer6 == this.SwitchCharacter) { One.TF.BattlePlayer6 = txt_name.text; }
        }
        else if (One.TF.BattlePlayer3 == txt_name.text)
        {
          One.TF.BattlePlayer3 = this.SwitchCharacter;
          if (One.TF.BattlePlayer1 == this.SwitchCharacter) { One.TF.BattlePlayer1 = txt_name.text; }
          else if (One.TF.BattlePlayer2 == this.SwitchCharacter) { One.TF.BattlePlayer2 = txt_name.text; }
          else if (One.TF.BattlePlayer4 == this.SwitchCharacter) { One.TF.BattlePlayer4 = txt_name.text; }
          else if (One.TF.BattlePlayer5 == this.SwitchCharacter) { One.TF.BattlePlayer5 = txt_name.text; }
          else if (One.TF.BattlePlayer6 == this.SwitchCharacter) { One.TF.BattlePlayer6 = txt_name.text; }
        }
        else if (One.TF.BattlePlayer4 == txt_name.text)
        {
          One.TF.BattlePlayer4 = this.SwitchCharacter;
          if (One.TF.BattlePlayer1 == this.SwitchCharacter) { One.TF.BattlePlayer1 = txt_name.text; }
          else if (One.TF.BattlePlayer2 == this.SwitchCharacter) { One.TF.BattlePlayer2 = txt_name.text; }
          else if (One.TF.BattlePlayer3 == this.SwitchCharacter) { One.TF.BattlePlayer3 = txt_name.text; }
          else if (One.TF.BattlePlayer5 == this.SwitchCharacter) { One.TF.BattlePlayer5 = txt_name.text; }
          else if (One.TF.BattlePlayer6 == this.SwitchCharacter) { One.TF.BattlePlayer6 = txt_name.text; }
        }
        else if (One.TF.BattlePlayer5 == txt_name.text)
        {
          One.TF.BattlePlayer5 = this.SwitchCharacter;
          if (One.TF.BattlePlayer1 == this.SwitchCharacter) { One.TF.BattlePlayer1 = txt_name.text; }
          else if (One.TF.BattlePlayer2 == this.SwitchCharacter) { One.TF.BattlePlayer2 = txt_name.text; }
          else if (One.TF.BattlePlayer3 == this.SwitchCharacter) { One.TF.BattlePlayer3 = txt_name.text; }
          else if (One.TF.BattlePlayer4 == this.SwitchCharacter) { One.TF.BattlePlayer4 = txt_name.text; }
          else if (One.TF.BattlePlayer6 == this.SwitchCharacter) { One.TF.BattlePlayer6 = txt_name.text; }
        }
        else if (One.TF.BattlePlayer6 == txt_name.text)
        {
          One.TF.BattlePlayer6 = this.SwitchCharacter;
          if (One.TF.BattlePlayer1 == this.SwitchCharacter) { One.TF.BattlePlayer1 = txt_name.text; }
          else if (One.TF.BattlePlayer2 == this.SwitchCharacter) { One.TF.BattlePlayer2 = txt_name.text; }
          else if (One.TF.BattlePlayer3 == this.SwitchCharacter) { One.TF.BattlePlayer3 = txt_name.text; }
          else if (One.TF.BattlePlayer4 == this.SwitchCharacter) { One.TF.BattlePlayer4 = txt_name.text; }
          else if (One.TF.BattlePlayer5 == this.SwitchCharacter) { One.TF.BattlePlayer5 = txt_name.text; }
        }
        this.SwitchCharacter = String.Empty;
        RefreshAllView();
      }
      return;
    }
    Debug.Log("panelHideOther.activeInHierarchy is false...");

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
      if (player.CurrentManaPoint < ActionCommand.Cost(Fix.FRESH_HEAL, player))
      {
        return;
      }
      player.CurrentManaPoint -= ActionCommand.Cost(Fix.FRESH_HEAL, player);

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
        Character target = One.SelectCharacter(txt_name.text);
        if (target.Dead)
        {
          Debug.Log(MethodBase.GetCurrentMethod() + " Target is dead, cannot use. " + target.FullName + " " + ParentBackpackView.CurrentSelectBackpack.ItemName);
          return;
        }

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

    // エッセンスツリーへの反映
    if (player3.FullName == Fix.NAME_EIN_WOLENCE)
    {
      txtEssenceCategoryList[0].text = Fix.CLASS_WARRIOR;
      txtEssenceCategoryList[1].text = Fix.CLASS_FIRE;
      txtEssenceCategoryList[2].text = Fix.CLASS_GUARDIAN;
      txtEssenceCategoryList[3].text = Fix.CLASS_HOLYLIGHT;
    }
    else if (player3.FullName == Fix.NAME_LANA_AMIRIA)
    {
      txtEssenceCategoryList[0].text = Fix.CLASS_ICE;
      txtEssenceCategoryList[1].text = Fix.CLASS_MARTIAL_ARTS;
      txtEssenceCategoryList[2].text = Fix.CLASS_DARK_MAGIC;
      txtEssenceCategoryList[3].text = Fix.CLASS_MINDFULNESS;
    }
    else if (player3.FullName == Fix.NAME_EONE_FULNEA)
    {
      txtEssenceCategoryList[0].text = Fix.CLASS_ARCHERY;
      txtEssenceCategoryList[1].text = Fix.CLASS_HOLYLIGHT;
      txtEssenceCategoryList[2].text = Fix.CLASS_MINDFULNESS;
      txtEssenceCategoryList[3].text = Fix.CLASS_DARK_MAGIC;
    }
    else if (player3.FullName == Fix.NAME_BILLY_RAKI)
    {
      txtEssenceCategoryList[0].text = Fix.CLASS_MARTIAL_ARTS;
      txtEssenceCategoryList[1].text = Fix.CLASS_FIRE;
      txtEssenceCategoryList[2].text = Fix.CLASS_TRUTH;
      txtEssenceCategoryList[3].text = Fix.CLASS_WARRIOR;
    }
    else if (player3.FullName == Fix.NAME_ADEL_BRIGANDY)
    {
      txtEssenceCategoryList[0].text = Fix.CLASS_VOIDCHANT;
      txtEssenceCategoryList[1].text = Fix.CLASS_FORCE;
      txtEssenceCategoryList[2].text = Fix.CLASS_ICE;
      txtEssenceCategoryList[3].text = Fix.CLASS_FIRE;
    }
    SetupEssenceList(player3, 0);
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
      if (player.CurrentManaPoint < ActionCommand.Cost(Fix.SHINING_HEAL, player))
      {
        return;
      }
      player.CurrentManaPoint -= ActionCommand.Cost(Fix.SHINING_HEAL, player);

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

  #region "エッセンス・ツリー設定"
  public void TapEssenceCategory(int number)
  {
    SetupEssenceList(CurrentPlayer, number);
    TapSelectEssence(txtEssenceElementList[0]);
    //for (int ii = 0; ii < GroupEssenceList.Count; ii++)
    //{
    //  if (number == ii) { GroupEssenceList[ii].SetActive(true); }
    //  else { GroupEssenceList[ii].SetActive(false); }
    //}
  }

  public void TapSelectEssence(Text txt_title)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    txtEssenceCurrentName.text = txt_title.text;
    txtEssenceCurrentDescription.text = "～効果～　" + ActionCommand.GetDescription(txt_title.text);// CurrentPlayer.GetEssenceTreeDescList(txt_title.text);
    txtEssenceCurrentDescEffect.text = "～強化～　" + ActionCommand.GetDescEffect(this.CurrentPlayer, txt_title.text);
    imgEssenceCurrent.ApplyImageIcon(txt_title.text);
  }

  public void TapDecisionEssence()
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    imgEssenceDecision.sprite = imgEssenceCurrent.ActionButton.image.sprite;
    imgEssenceDecision.name = txtEssenceCurrentName.text;
    if (CurrentPlayer.SoulFragment <= 0)
    {
      txtEssenceDecisionTitle.text = txtEssenceCurrentName.text + " を獲得する事ができません。";
      txtEssenceDecisionMessage.text = "エッセンス・ポイントが不足しています。エッセンス・ポイントを入手してください。";
      btnEssenceDecisionAccept.gameObject.SetActive(false);
      btnEssenceDecisionCancel.gameObject.SetActive(false);
      btnEssenceDecisionOK.gameObject.SetActive(true);
      groupEssenceDecision.SetActive(true);
      return;
    }

    txtEssenceDecisionTitle.text = txtEssenceCurrentName.text + "を獲得しますか？";
    txtEssenceDecisionMessage.text = "エッセンス・ポイントを１ポイント消費して獲得します。この操作は元に戻せません。";
    btnEssenceDecisionAccept.gameObject.SetActive(true);
    btnEssenceDecisionCancel.gameObject.SetActive(true);
    btnEssenceDecisionOK.gameObject.SetActive(false);
    groupEssenceDecision.SetActive(true);
  }

  public void TapAcceptEssence()
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + imgEssenceDecision.name);
    CurrentPlayer.UpgradeEssenceTree(imgEssenceDecision.name);
    txtEssencePoint.text = CurrentPlayer.SoulFragment.ToString();
    groupEssenceDecision.SetActive(false);
  }

  public void TapCancelEssence()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    groupEssenceDecision.SetActive(false);
  }
  #endregion

  // 閉じる
  public void TapExit()
  {
    SceneDimension.SceneClose(Fix.SCENE_PARTY_MENU);
  }

  public override void RefreshAllView()
  {
    // エッセンスツリーボタン
    btnEssenceTree.SetActive(One.TF.AvailableSecondEssence);

    // プレイヤーリストの反映
    PlayerList.Clear();

    List<Character> list = One.AvailableCharacters;
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer1 == list[ii].FullName) { PlayerList.Add(list[ii]); break; }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer2 == list[ii].FullName) { PlayerList.Add(list[ii]); break; }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer3 == list[ii].FullName) { PlayerList.Add(list[ii]); break; }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer4 == list[ii].FullName) { PlayerList.Add(list[ii]); break; }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer5 == list[ii].FullName) { PlayerList.Add(list[ii]); break; }
    }
    for (int ii = 0; ii < list.Count; ii++)
    {
      if (One.TF.BattlePlayer6 == list[ii].FullName) { PlayerList.Add(list[ii]); break; }
    }

    // 不要なフィルタを排除
    panelHideOther.SetActive(false);

    // パーティステータス画面への反映
    SetupStayList();

    // コマンド設定画面への反映
    SetupActionCommand(PlayerList[0], ActionCommand.CommandCategory.ActionCommand); // [基本行動]が一番左で最初だが、デフォルトはアクションコマンドを表示

    // エッセンス画面への反映
    SetupEssenceList(PlayerList[0], 0);

    // バックパック情報を画面へ反映
    ParentBackpackView.ConstructBackpackView(this);

    // ゴールドへの反映
    txtGold.text = One.TF.Gold.ToString();
  }

  #region "private"
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

  private void SetupEssenceList(Character player, int number)
  {
    Debug.Log("SetupEssenceList(S) " + player.FullName + " " + number.ToString());
    string attribute = String.Empty;

    txtEssenceTreeName.text = player.FullName;
    txtEssencePoint.text = player.SoulFragment.ToString();

    if (player.FullName == Fix.NAME_EIN_WOLENCE)
    {
      if (number == 0) { attribute = Fix.CLASS_WARRIOR; }
      if (number == 1) { attribute = Fix.CLASS_FIRE; }
      if (number == 2) { attribute = Fix.CLASS_GUARDIAN; }
      if (number == 3) { attribute = Fix.CLASS_HOLYLIGHT; }
    }
    else if (player.FullName == Fix.NAME_LANA_AMIRIA)
    {
      if (number == 0) { attribute = Fix.CLASS_ICE; }
      if (number == 1) { attribute = Fix.CLASS_MARTIAL_ARTS; }
      if (number == 2) { attribute = Fix.CLASS_DARK_MAGIC; }
      if (number == 3) { attribute = Fix.CLASS_MINDFULNESS; }
    }
    else if (player.FullName == Fix.NAME_EONE_FULNEA)
    {
      if (number == 0) { attribute = Fix.CLASS_ARCHERY; }
      if (number == 1) { attribute = Fix.CLASS_HOLYLIGHT; }
      if (number == 2) { attribute = Fix.CLASS_MINDFULNESS; }
      if (number == 3) { attribute = Fix.CLASS_DARK_MAGIC; }
    }
    else if (player.FullName == Fix.NAME_BILLY_RAKI)
    {
      if (number == 0) { attribute = Fix.CLASS_MARTIAL_ARTS; }
      if (number == 1) { attribute = Fix.CLASS_FIRE; }
      if (number == 2) { attribute = Fix.CLASS_TRUTH; }
      if (number == 3) { attribute = Fix.CLASS_WARRIOR; }
    }
    else if (player.FullName == Fix.NAME_ADEL_BRIGANDY)
    {
      if (number == 0) { attribute = Fix.CLASS_VOIDCHANT; }
      if (number == 1) { attribute = Fix.CLASS_FORCE; }
      if (number == 2) { attribute = Fix.CLASS_ICE; }
      if (number == 3) { attribute = Fix.CLASS_FIRE; }
    }

    int counter = 0;
    if (attribute == Fix.CLASS_FIRE)
    {
      SetupEssenceElement(player.FireBall, Fix.FIRE_BALL, counter); counter++;
      SetupEssenceElement(player.FlameBlade, Fix.FLAME_BLADE, counter); counter++;
      SetupEssenceElement(player.MeteorBullet, Fix.METEOR_BULLET, counter); counter++;
      SetupEssenceElement(player.VolcanicBlaze, Fix.VOLCANIC_BLAZE, counter); counter++;
      SetupEssenceElement(player.FlameStrike, Fix.FLAME_STRIKE, counter); counter++;
      SetupEssenceElement(player.CircleOfTheIgnite, Fix.CIRCLE_OF_THE_IGNITE, counter); counter++;
      SetupEssenceElement(player.LavaAnnihilation, Fix.LAVA_ANNIHILATION, counter); counter++;
    }
    else if (attribute == Fix.CLASS_ICE)
    {
      SetupEssenceElement(player.IceNeedle, Fix.ICE_NEEDLE, counter); counter++;
      SetupEssenceElement(player.PurePurification, Fix.PURE_PURIFICATION, counter); counter++;
      SetupEssenceElement(player.BlueBullet, Fix.BLUE_BULLET, counter); counter++;
      SetupEssenceElement(player.FreezingCube, Fix.FREEZING_CUBE, counter); counter++;
      SetupEssenceElement(player.FrostLance, Fix.FROST_LANCE, counter); counter++;
      SetupEssenceElement(player.WaterPresence, Fix.WATER_PRESENCE, counter); counter++;
      SetupEssenceElement(player.AbsoluteZero, Fix.ABSOLUTE_ZERO, counter); counter++;
    }
    else if (attribute == Fix.CLASS_HOLYLIGHT)
    {
      SetupEssenceElement(player.FreshHeal, Fix.FRESH_HEAL, counter); counter++;
      SetupEssenceElement(player.DivineCircle, Fix.DIVINE_CIRCLE, counter); counter++;
      SetupEssenceElement(player.HolyBreath, Fix.HOLY_BREATH, counter); counter++;
      SetupEssenceElement(player.AngelicEcho, Fix.ANGELIC_ECHO, counter); counter++;
      SetupEssenceElement(player.ShiningHeal, Fix.SHINING_HEAL, counter); counter++;
      SetupEssenceElement(player.ValkyrieBlade, Fix.VALKYRIE_BLADE, counter); counter++;
      SetupEssenceElement(player.Resurrection, Fix.RESURRECTION, counter); counter++;
    }
    else if (attribute == Fix.CLASS_DARK_MAGIC)
    {
      SetupEssenceElement(player.ShadowBlast, Fix.SHADOW_BLAST, counter); counter++;
      SetupEssenceElement(player.BloodSign, Fix.BLOOD_SIGN, counter); counter++;
      SetupEssenceElement(player.BlackContract, Fix.BLACK_CONTRACT, counter); counter++;
      SetupEssenceElement(player.CursedEvangile, Fix.CURSED_EVANGILE, counter); counter++;
      SetupEssenceElement(player.CircleOfTheDespair, Fix.CIRCLE_OF_THE_DESPAIR, counter); counter++;
      SetupEssenceElement(player.TheDarkIntensity, Fix.THE_DARK_INTENSITY, counter); counter++;
      SetupEssenceElement(player.DeathScythe, Fix.DEATH_SCYTHE, counter); counter++;
    }
    else if (attribute == Fix.CLASS_FORCE)
    {
      SetupEssenceElement(player.OracleCommand, Fix.ORACLE_COMMAND, counter); counter++;
      SetupEssenceElement(player.FortuneSpirit, Fix.FORTUNE_SPIRIT, counter); counter++;
      SetupEssenceElement(player.WordOfPower, Fix.WORD_OF_POWER, counter); counter++;
      SetupEssenceElement(player.GaleWind, Fix.GALE_WIND, counter); counter++;
      SetupEssenceElement(player.SeventhPrinciple, Fix.SEVENTH_PRINCIPLE, counter); counter++;
      SetupEssenceElement(player.FutureVision, Fix.FUTURE_VISION, counter); counter++;
      SetupEssenceElement(player.Genesis, Fix.GENESIS, counter); counter++;
    }
    else if (attribute == Fix.CLASS_VOIDCHANT)
    {
      SetupEssenceElement(player.EnergyBolt, Fix.ENERGY_BOLT, counter); counter++;
      SetupEssenceElement(player.FlashCounter, Fix.FLASH_COUNTER, counter); counter++;
      SetupEssenceElement(player.SigilOfThePending, Fix.SIGIL_OF_THE_PENDING, counter); counter++;
      SetupEssenceElement(player.PhantomOboro, Fix.PHANTOM_OBORO, counter); counter++;
      SetupEssenceElement(player.CounterDisallow, Fix.COUNTER_DISALLOW, counter); counter++;
      SetupEssenceElement(player.DetachmentFault, Fix.DETACHMENT_FAULT, counter); counter++;
      SetupEssenceElement(player.TimeSkip, Fix.TIME_SKIP, counter); counter++;
    }
    else if (attribute == Fix.CLASS_WARRIOR)
    {
      SetupEssenceElement(player.StraightSmash, Fix.STRAIGHT_SMASH, counter); counter++;
      SetupEssenceElement(player.StanceOfTheBlade, Fix.STANCE_OF_THE_BLADE, counter); counter++;
      SetupEssenceElement(player.DoubleSlash, Fix.DOUBLE_SLASH, counter); counter++;
      SetupEssenceElement(player.IronBuster, Fix.IRON_BUSTER, counter); counter++;
      SetupEssenceElement(player.RagingStorm, Fix.RAGING_STORM, counter); counter++;
      SetupEssenceElement(player.StanceOfTheIai, Fix.STANCE_OF_THE_IAI, counter); counter++;
      SetupEssenceElement(player.KineticSmash, Fix.KINETIC_SMASH, counter); counter++;
    }
    else if (attribute == Fix.CLASS_GUARDIAN)
    {
      SetupEssenceElement(player.ShieldBash, Fix.SHIELD_BASH, counter); counter++;
      SetupEssenceElement(player.StanceOfTheGuard, Fix.STANCE_OF_THE_GUARD, counter); counter++;
      SetupEssenceElement(player.ConcussiveHit, Fix.CONCUSSIVE_HIT, counter); counter++;
      SetupEssenceElement(player.DominationField, Fix.DOMINATION_FIELD, counter); counter++;
      SetupEssenceElement(player.HardestParry, Fix.HARDEST_PARRY, counter); counter++;
      SetupEssenceElement(player.OneImmunity, Fix.ONE_IMMUNITY, counter); counter++;
      SetupEssenceElement(player.Catastrophe, Fix.CATASTROPHE, counter); counter++;
    }
    else if (attribute == Fix.CLASS_MARTIAL_ARTS)
    {
      SetupEssenceElement(player.LegStrike, Fix.LEG_STRIKE, counter); counter++;
      SetupEssenceElement(player.SpeedStep, Fix.SPEED_STEP, counter); counter++;
      SetupEssenceElement(player.BoneCrush, Fix.BONE_CRUSH, counter); counter++;
      SetupEssenceElement(player.DeadlyDrive, Fix.DEADLY_DRIVE, counter); counter++;
      SetupEssenceElement(player.UnintentionalHit, Fix.UNINTENTIONAL_HIT, counter); counter++;
      SetupEssenceElement(player.StanceOfMuin, Fix.STANCE_OF_MUIN, counter); counter++;
      SetupEssenceElement(player.CarnageRush, Fix.CARNAGE_RUSH, counter); counter++;
    }
    else if (attribute == Fix.CLASS_ARCHERY)
    {
      SetupEssenceElement(player.HunterShot, Fix.HUNTER_SHOT, counter); counter++;
      SetupEssenceElement(player.MultipleShot, Fix.MULTIPLE_SHOT, counter); counter++;
      SetupEssenceElement(player.EyeOfTheIsshin, Fix.EYE_OF_THE_ISSHIN, counter); counter++;
      SetupEssenceElement(player.PenetrationArrow, Fix.PENETRATION_ARROW, counter); counter++;
      SetupEssenceElement(player.PrecisionStrike, Fix.PRECISION_STRIKE, counter); counter++;
      SetupEssenceElement(player.EternalConcentration, Fix.ETERNAL_CONCENTRATION, counter); counter++;
      SetupEssenceElement(player.PiercingArrow, Fix.PIERCING_ARROW, counter); counter++;
    }
    else if (attribute == Fix.CLASS_TRUTH)
    {
      SetupEssenceElement(player.TrueSight, Fix.TRUE_SIGHT, counter); counter++;
      SetupEssenceElement(player.LeylineSchema, Fix.LEYLINE_SCHEMA, counter); counter++;
      SetupEssenceElement(player.VoiceOfVigor, Fix.VOICE_OF_VIGOR, counter); counter++;
      SetupEssenceElement(player.WillAwakening, Fix.WILL_AWAKENING, counter); counter++;
      SetupEssenceElement(player.EverflowMind, Fix.EVERFLOW_MIND, counter); counter++;
      SetupEssenceElement(player.SigilOfTheFaith, Fix.SIGIL_OF_THE_FAITH, counter); counter++;
      SetupEssenceElement(player.StanceOfTheKokoroe, Fix.STANCE_OF_THE_KOKOROE, counter); counter++;
    }
    else if (attribute == Fix.CLASS_MINDFULNESS)
    {
      SetupEssenceElement(player.DispelMagic, Fix.DISPEL_MAGIC, counter); counter++;
      SetupEssenceElement(player.SpiritualRest, Fix.SPIRITUAL_REST, counter); counter++;
      SetupEssenceElement(player.UnseenAid, Fix.UNSEEN_AID, counter); counter++;
      SetupEssenceElement(player.CircleOfSerenity, Fix.CIRCLE_OF_SERENITY, counter); counter++;
      SetupEssenceElement(player.InnerInspiration, Fix.INNER_INSPIRATION, counter); counter++;
      SetupEssenceElement(player.ZeroImmunity, Fix.ZERO_IMMUNITY, counter); counter++;
      SetupEssenceElement(player.TranscendenceReached, Fix.TRANSCENDENCE_REACHED, counter); counter++;
    }
  }

  private void SetupEssenceElement(int element_level, string label_text, int number)
  {
    // todo レベル０で条件を満たしている場合の可視化と、レベル０で未到達の場合はLOCKとして見せるのは設計が異なる。
    if (element_level >= 0)
    {
      txtEssenceElementList[number].text = label_text;
      imgEssenceElementList[number].sprite = Resources.Load<Sprite>(label_text);
      txtEssenceElementLevelList[number].text = "Lv " + element_level.ToString();
      objHideEssenceElementList[number].SetActive(false);
    }
    else
    {
      txtEssenceElementList[number].text = "？？？";
      imgEssenceElementList[number].sprite = Resources.Load<Sprite>(Fix.STAY);
      txtEssenceElementLevelList[number].text = "Lv " + element_level.ToString();
      objHideEssenceElementList[number].SetActive(true);
    }
  }
  #endregion
}
