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
  public GameObject groupPageScroll;
  public Text txtCommandTitle;
  public Image imgCommandTitle;
  public Text txtCommandAttribute;
  public Text txtCommandCost;
  public Text txtCommandDescription;

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
  public List<Button> btnEssenceCategoryList;
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

  private int CurrentEssenceSelectNumber = 0;

  private int CurrentBattleSettingPageNumber = 0;

  private const int BATTLE_SETTING_NUM = 8;

  private string CurrentSelectHealCommand = String.Empty;

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

      if (this.CurrentSelectHealCommand == Fix.FRESH_HEAL)
      {
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
      }
      else if (this.CurrentSelectHealCommand == Fix.PURE_PURIFICATION)
      {
        double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.PurePurificationHealValuel(player);
        Debug.Log(MethodBase.GetCurrentMethod());
        if (target.Dead)
        {
          return;
        }
        if (player.CurrentManaPoint < ActionCommand.Cost(Fix.PURE_PURIFICATION, player))
        {
          return;
        }
        player.CurrentManaPoint -= ActionCommand.Cost(Fix.PURE_PURIFICATION, player);

        if (healValue <= 0) { healValue = 0; }
        int result = (int)healValue;
        Debug.Log((player?.FullName ?? string.Empty) + " -> " + target.FullName + " " + result.ToString() + " heal");
        target.CurrentLife += result;
      }

      CurrentSelectHealCommand = String.Empty;
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
          else if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.PURE_CLEAN_WATER)
          {
            if (One.TF.AlreadyPureCleanWater == false)
            {
              One.TF.AlreadyPureCleanWater = true;
              PlayerList[ii].CurrentLife += PlayerList[ii].MaxLife;
            }
            else
            {
              // 何かメッセージを入れないと使えない事が分からない。
            }
          }
          else if (ParentBackpackView.CurrentSelectBackpack.ItemName == Fix.PURE_SINSEISUI)
          {
            if (One.TF.AlreadySinseisui == false)
            {
              One.TF.AlreadySinseisui = true;
              PlayerList[ii].CurrentManaPoint += PlayerList[ii].MaxManaPoint;
            }
            else
            {
              // 何かメッセージを入れないと使えない事が分からない。
            }
          }
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

          CurrentSelectHealCommand = String.Empty;
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
      if (player2.PurePurification > 0) { objActionCommand[0].SetActive(true); }
      else { objActionCommand[0].SetActive(false); }

      if (player2.FreshHeal > 0) { objActionCommand[1].SetActive(true); }
      else { objActionCommand[1].SetActive(false); }

      if (player2.ShiningHeal > 0) { objActionCommand[2].SetActive(true); }
      else { objActionCommand[2].SetActive(false); }

      if (player2.LifeGrace > 0) { objActionCommand[3].SetActive(true); }
      else { objActionCommand[3].SetActive(false); }

      if (player2.HolyBreath > 0) { objActionCommand[4].SetActive(true); }
      else { objActionCommand[4].SetActive(false); }
    }

    // コマンド設定画面への反映
    Character player3 = One.SelectCharacter(txt_name.text);
    SetupActionCommand(player3, ActionCommand.CommandCategory.ActionCommand); // [基本行動]が一番左で最初だが、デフォルトはアクションコマンドを表示

    // エッセンスツリーへの反映
    txtEssenceCategoryList[0].text = GetCommandAttributeString(player3.FirstCommandAttribute);
    txtEssenceCategoryList[1].text = GetCommandAttributeString(player3.SecondCommandAttribute);
    txtEssenceCategoryList[2].text = GetCommandAttributeString(player3.ThirdCommandAttribute);
    txtEssenceCategoryList[3].text = GetCommandAttributeString(player3.FourthCommandAttribute);
    txtEssenceCategoryList[4].text = GetCommandAttributeString(player3.FifthCommandAttribute);
    txtEssenceCategoryList[5].text = GetCommandAttributeString(player3.SixthCommandAttribute);

    // アカシックレコードによる表示／非表示
    btnEssenceCategoryList[0].gameObject.SetActive(true);
    btnEssenceCategoryList[1].gameObject.SetActive(One.AR.PartyJoin_EoneFulnea);
    btnEssenceCategoryList[2].gameObject.SetActive(One.AR.PartyJoin_BillyRaki);
    btnEssenceCategoryList[3].gameObject.SetActive(One.AR.PartyJoin_AdelBrigandy);
    btnEssenceCategoryList[4].gameObject.SetActive(One.AR.GiftParmetysiaWord);
    btnEssenceCategoryList[5].gameObject.SetActive(One.AR.InscribeObsidianStone_4);
    btnEssenceCategoryList[6].gameObject.SetActive(One.AR.InscribeObsidianStone_5);
    btnEssenceCategoryList[7].gameObject.SetActive(One.AR.InscribeObsidianStone_6);

    SetupEssenceList(player3, 0);
    CurrentEssenceSelectNumber = 0;
  }

  private string GetCommandAttributeString(Fix.CommandAttribute attribute)
  {
    if (attribute == Fix.CommandAttribute.Fire) { return Fix.CLASS_FIRE; }
    if (attribute == Fix.CommandAttribute.Ice) { return Fix.CLASS_ICE; }
    if (attribute == Fix.CommandAttribute.HolyLight) { return Fix.CLASS_HOLYLIGHT; }
    if (attribute == Fix.CommandAttribute.DarkMagic) { return Fix.CLASS_DARK_MAGIC; }
    if (attribute == Fix.CommandAttribute.Force) { return Fix.CLASS_FORCE; }
    if (attribute == Fix.CommandAttribute.VoidChant) { return Fix.CLASS_VOIDCHANT; }
    if (attribute == Fix.CommandAttribute.Warrior) { return Fix.CLASS_WARRIOR; }
    if (attribute == Fix.CommandAttribute.Guardian) { return Fix.CLASS_GUARDIAN; }
    if (attribute == Fix.CommandAttribute.MartialArts) { return Fix.CLASS_MARTIAL_ARTS; }
    if (attribute == Fix.CommandAttribute.Archery) { return Fix.CLASS_ARCHERY; }
    if (attribute == Fix.CommandAttribute.Truth) { return Fix.CLASS_TRUTH; }
    if (attribute == Fix.CommandAttribute.Mindfulness) { return Fix.CLASS_MINDFULNESS; }

    return String.Empty;
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
        current == Fix.GROWTH_LIQUID7_MIND ||
        current == Fix.PURE_CLEAN_WATER || 
        current == Fix.PURE_SINSEISUI
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

    txtCommandTitle.text = action_command.CommandName;
    imgCommandTitle.sprite = Resources.Load<Sprite>(action_command.CommandName);
    txtCommandAttribute.text = "タイプ： " + ActionCommand.GetAttribute_JP(action_command.CommandName).ToString();
    txtCommandCost.text = "コスト： " + ActionCommand.Cost(action_command.CommandName, CurrentPlayer).ToString() + ActionCommand.GetAttribute_Unit(action_command.CommandName);
    txtCommandDescription.text = ActionCommand.GetDescription(action_command.CommandName);

    // 万が一選択状態が存在していない場合は再設定する。
    if (this.CurrentSelectCommand == null)
    {
      this.CurrentSelectCommand = action_command;
      return;
    }
    // 現在選択と違うアクションコマンドの場合は設定モードに移行しない。
    if (this.CurrentSelectCommand != action_command)
    {
      this.CurrentSelectCommand = action_command;
      return;
    }

    // 設定モードへの移行
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
    // this.CurrentSelectCommand = null; // キャンセル時、現在選択しているコマンドはクリアしなくて良いGUIとなった。
  }

  public void TapBattleSettingPageNext()
  {
    Debug.Log("TapBattleSettingPageNext(S)");

    List<string> currentList = CurrentPlayer.GetAvailableList();
    if (currentList.Count <= (this.CurrentBattleSettingPageNumber + 1) * BATTLE_SETTING_NUM)
    {
      Debug.Log("TapBattleSettingPageNext - PageLimit, then no action.");
      return;
    }

    this.CurrentBattleSettingPageNumber++;

    for (int ii = 0; ii < ListAvailableCommand.Count; ii++)
    {
      Debug.Log("GetAvailableList: " + ListAvailableCommand[ii].CommandName);
      if (ii >= currentList.Count - this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM)
      {
        ListAvailableCommand[ii].CommandName = String.Empty;
        ListAvailableCommand[ii].name = String.Empty;
        ListAvailableCommand[ii].ActionButton.image.sprite = null;
        ListAvailableCommandText[ii].text = String.Empty;
        continue;
      }
      ListAvailableCommand[ii].CommandName = currentList[ii + this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM];
      ListAvailableCommand[ii].name = currentList[ii + this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM];
      ListAvailableCommand[ii].ApplyImageIcon(currentList[ii + this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM]);
      ListAvailableCommandText[ii].text = currentList[ii + this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM];
    }
  }

  public void TapBattleSettingPageBack()
  {
    Debug.Log("TapBattleSettingPageBack(S)");

    if (this.CurrentBattleSettingPageNumber <= 0)
    {
      Debug.Log("TapBattleSettingPageBack - PageFirst, then no action.");
      return;
    }
    this.CurrentBattleSettingPageNumber--;

    List<string> currentList = CurrentPlayer.GetAvailableList();
    for (int ii = 0; ii < ListAvailableCommand.Count; ii++)
    {
      Debug.Log("GetAvailableList: " + ListAvailableCommand[ii].CommandName);
      if (ii >= currentList.Count - this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM)
      {
        ListAvailableCommand[ii].CommandName = String.Empty;
        ListAvailableCommand[ii].name = String.Empty;
        ListAvailableCommand[ii].ActionButton.image.sprite = null;
        ListAvailableCommandText[ii].text = String.Empty;
        continue;
      }
      ListAvailableCommand[ii].CommandName = currentList[ii + this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM];
      ListAvailableCommand[ii].name = currentList[ii + this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM];
      ListAvailableCommand[ii].ApplyImageIcon(currentList[ii + this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM]);
      ListAvailableCommandText[ii].text = currentList[ii + this.CurrentBattleSettingPageNumber * BATTLE_SETTING_NUM];
    }
  }

  #region "アクションコマンド"
  public void TapActionCommand(Text txt_src)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + txt_src.text);

    if (txt_src.text == Fix.FRESH_HEAL)
    {
      CurrentSelectHealCommand = Fix.FRESH_HEAL;
      objCancelActionCommand.SetActive(true);
    }
    else if (txt_src.text == Fix.PURE_PURIFICATION)
    {
      CurrentSelectHealCommand = Fix.PURE_PURIFICATION;
      objCancelActionCommand.SetActive(true);
    }
    else if (txt_src.text == Fix.HOLY_BREATH)
    {
      Character player = One.SelectCharacter(txtCurrentName.text);
      if (player.CurrentManaPoint < ActionCommand.Cost(Fix.HOLY_BREATH, player))
      {
        return;
      }
      player.CurrentManaPoint -= ActionCommand.Cost(Fix.HOLY_BREATH, player);

      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        double healValue = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Random, PrimaryLogic.SpellSkillType.Intelligence) * SecondaryLogic.HolyBreath(player);
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
    CurrentSelectHealCommand = String.Empty;
    objCancelActionCommand.SetActive(false);
  }
  #endregion

  #region "エッセンス・ツリー設定"
  public void TapEssenceCategory(int number)
  {
    CurrentEssenceSelectNumber = number;
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

    TapSelectEssence(txtEssenceCurrentName);
    SetupEssenceList(this.CurrentPlayer, this.CurrentEssenceSelectNumber);
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
    CurrentEssenceSelectNumber = 0;

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

    this.CurrentBattleSettingPageNumber = 0; // 初期表示のため、0に再設定
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

    if (currentList.Count > BATTLE_SETTING_NUM)
    {
      groupPageScroll.SetActive(true);
    }
    else
    {
      groupPageScroll.SetActive(false);
    }

    txtCommandTitle.text = ListAvailableCommand[0].CommandName;
    imgCommandTitle.sprite = Resources.Load<Sprite>(ListAvailableCommand[0].CommandName);
    txtCommandAttribute.text = "タイプ： " + ActionCommand.GetAttribute_JP(ListAvailableCommand[0].CommandName).ToString();
    txtCommandCost.text = "コスト： " + ActionCommand.Cost(ListAvailableCommand[0].CommandName, CurrentPlayer).ToString() + ActionCommand.GetAttribute_Unit(ListAvailableCommand[0].CommandName);
    txtCommandDescription.text = ActionCommand.GetDescription(ListAvailableCommand[0].CommandName);
    this.CurrentSelectCommand = ListAvailableCommand[0]; // 初期設定で現在選択しているコマンドは０番目を設定しているので反映しておくGUIクリアしなくて良いGUIとなった。
  }

  private void SetupEssenceList(Character player, int number)
  {
    Debug.Log("SetupEssenceList(S) " + player.FullName + " " + number.ToString());
    string attribute = String.Empty;

    txtEssenceTreeName.text = player.FullName;
    txtEssencePoint.text = player.SoulFragment.ToString();

    attribute = txtEssenceCategoryList[number].text;
    Debug.Log("SetupEssenceList attribute: " + attribute);

    int counter = 0;
    if (attribute == Fix.CLASS_FIRE)
    {
      SetupEssenceElement(player.FireBall, Fix.FIRE_BALL, One.AR.FireBall, counter); counter++;
      SetupEssenceElement(player.FlameBlade, Fix.FLAME_BLADE, One.AR.FlameBlade, counter); counter++;
      SetupEssenceElement(player.MeteorBullet, Fix.METEOR_BULLET, One.AR.MeteorBullet, counter); counter++;
      SetupEssenceElement(player.VolcanicBlaze, Fix.VOLCANIC_BLAZE, One.AR.VolcanicBlaze, counter); counter++;
      SetupEssenceElement(player.FlameStrike, Fix.FLAME_STRIKE, One.AR.FlameStrike, counter); counter++;
      SetupEssenceElement(player.CircleOfTheIgnite, Fix.CIRCLE_OF_THE_IGNITE, One.AR.CircleOfTheIgnite, counter); counter++;
      SetupEssenceElement(player.LavaAnnihilation, Fix.LAVA_ANNIHILATION, One.AR.LavaAnnihilation, counter); counter++;
    }
    else if (attribute == Fix.CLASS_ICE)
    {
      SetupEssenceElement(player.IceNeedle, Fix.ICE_NEEDLE, One.AR.IceNeedle, counter); counter++;
      SetupEssenceElement(player.PurePurification, Fix.PURE_PURIFICATION, One.AR.PurePurification, counter); counter++;
      SetupEssenceElement(player.BlueBullet, Fix.BLUE_BULLET, One.AR.BlueBullet, counter); counter++;
      SetupEssenceElement(player.FreezingCube, Fix.FREEZING_CUBE, One.AR.FreezingCube, counter); counter++;
      SetupEssenceElement(player.FrostLance, Fix.FROST_LANCE, One.AR.FrostLance, counter); counter++;
      SetupEssenceElement(player.WaterPresence, Fix.WATER_PRESENCE, One.AR.WaterPresence, counter); counter++;
      SetupEssenceElement(player.AbsoluteZero, Fix.ABSOLUTE_ZERO, One.AR.AbsoluteZero, counter); counter++;
    }
    else if (attribute == Fix.CLASS_HOLYLIGHT)
    {
      SetupEssenceElement(player.FreshHeal, Fix.FRESH_HEAL, One.AR.FreshHeal, counter); counter++;
      SetupEssenceElement(player.DivineCircle, Fix.DIVINE_CIRCLE, One.AR.DivineCircle, counter); counter++;
      SetupEssenceElement(player.HolyBreath, Fix.HOLY_BREATH, One.AR.HolyBreath, counter); counter++;
      SetupEssenceElement(player.AngelicEcho, Fix.ANGELIC_ECHO, One.AR.AngelicEcho, counter); counter++;
      SetupEssenceElement(player.ShiningHeal, Fix.SHINING_HEAL, One.AR.ShiningHeal, counter); counter++;
      SetupEssenceElement(player.ValkyrieBlade, Fix.VALKYRIE_BLADE, One.AR.ValkyrieBlade, counter); counter++;
      SetupEssenceElement(player.Resurrection, Fix.RESURRECTION, One.AR.Resurrection, counter); counter++;
    }
    else if (attribute == Fix.CLASS_DARK_MAGIC)
    {
      SetupEssenceElement(player.ShadowBlast, Fix.SHADOW_BLAST, One.AR.ShadowBlast, counter); counter++;
      SetupEssenceElement(player.BloodSign, Fix.BLOOD_SIGN, One.AR.BloodSign, counter); counter++;
      SetupEssenceElement(player.BlackContract, Fix.BLACK_CONTRACT, One.AR.BlackContract, counter); counter++;
      SetupEssenceElement(player.CursedEvangile, Fix.CURSED_EVANGILE, One.AR.CursedEvangile, counter); counter++;
      SetupEssenceElement(player.CircleOfTheDespair, Fix.CIRCLE_OF_THE_DESPAIR, One.AR.CircleOfTheDespair, counter); counter++;
      SetupEssenceElement(player.TheDarkIntensity, Fix.THE_DARK_INTENSITY, One.AR.TheDarkIntensity, counter); counter++;
      SetupEssenceElement(player.DeathScythe, Fix.DEATH_SCYTHE, One.AR.DeathScythe, counter); counter++;
    }
    else if (attribute == Fix.CLASS_FORCE)
    {
      SetupEssenceElement(player.OracleCommand, Fix.ORACLE_COMMAND, One.AR.OracleCommand, counter); counter++;
      SetupEssenceElement(player.FortuneSpirit, Fix.FORTUNE_SPIRIT, One.AR.FortuneSpirit, counter); counter++;
      SetupEssenceElement(player.WordOfPower, Fix.WORD_OF_POWER, One.AR.WordOfPower, counter); counter++;
      SetupEssenceElement(player.GaleWind, Fix.GALE_WIND, One.AR.GaleWind, counter); counter++;
      SetupEssenceElement(player.SeventhPrinciple, Fix.SEVENTH_PRINCIPLE, One.AR.SeventhPrinciple, counter); counter++;
      SetupEssenceElement(player.FutureVision, Fix.FUTURE_VISION, One.AR.FutureVision, counter); counter++;
      SetupEssenceElement(player.Genesis, Fix.GENESIS, One.AR.Genesis, counter); counter++;
    }
    else if (attribute == Fix.CLASS_VOIDCHANT)
    {
      SetupEssenceElement(player.EnergyBolt, Fix.ENERGY_BOLT, One.AR.EnergyBolt, counter); counter++;
      SetupEssenceElement(player.FlashCounter, Fix.FLASH_COUNTER, One.AR.FlashCounter, counter); counter++;
      SetupEssenceElement(player.SigilOfThePending, Fix.SIGIL_OF_THE_PENDING, One.AR.SigilOfThePending, counter); counter++;
      SetupEssenceElement(player.PhantomOboro, Fix.PHANTOM_OBORO, One.AR.PhantomOboro, counter); counter++;
      SetupEssenceElement(player.CounterDisallow, Fix.COUNTER_DISALLOW, One.AR.CounterDisallow, counter); counter++;
      SetupEssenceElement(player.DetachmentFault, Fix.DETACHMENT_FAULT, One.AR.DetachmentFault, counter); counter++;
      SetupEssenceElement(player.TimeSkip, Fix.TIME_SKIP, One.AR.TimeSkip, counter); counter++;
    }
    else if (attribute == Fix.CLASS_WARRIOR)
    {
      SetupEssenceElement(player.StraightSmash, Fix.STRAIGHT_SMASH, One.AR.StraightSmash, counter); counter++;
      SetupEssenceElement(player.StanceOfTheBlade, Fix.STANCE_OF_THE_BLADE, One.AR.StanceOfTheBlade, counter); counter++;
      SetupEssenceElement(player.DoubleSlash, Fix.DOUBLE_SLASH, One.AR.DoubleSlash, counter); counter++;
      SetupEssenceElement(player.IronBuster, Fix.IRON_BUSTER, One.AR.IronBuster, counter); counter++;
      SetupEssenceElement(player.RagingStorm, Fix.RAGING_STORM, One.AR.RagingStorm, counter); counter++;
      SetupEssenceElement(player.StanceOfTheIai, Fix.STANCE_OF_THE_IAI, One.AR.StanceOfTheIai, counter); counter++;
      SetupEssenceElement(player.KineticSmash, Fix.KINETIC_SMASH, One.AR.KineticSmash, counter); counter++;
    }
    else if (attribute == Fix.CLASS_GUARDIAN)
    {
      SetupEssenceElement(player.ShieldBash, Fix.SHIELD_BASH, One.AR.ShieldBash, counter); counter++;
      SetupEssenceElement(player.StanceOfTheGuard, Fix.STANCE_OF_THE_GUARD, One.AR.StanceOfTheGuard, counter); counter++;
      SetupEssenceElement(player.ConcussiveHit, Fix.CONCUSSIVE_HIT, One.AR.ConcussiveHit, counter); counter++;
      SetupEssenceElement(player.DominationField, Fix.DOMINATION_FIELD, One.AR.DominationField, counter); counter++;
      SetupEssenceElement(player.HardestParry, Fix.HARDEST_PARRY, One.AR.HardestParry, counter); counter++;
      SetupEssenceElement(player.OneImmunity, Fix.ONE_IMMUNITY, One.AR.OneImmunity, counter); counter++;
      SetupEssenceElement(player.Catastrophe, Fix.CATASTROPHE, One.AR.Catastrophe, counter); counter++;
    }
    else if (attribute == Fix.CLASS_MARTIAL_ARTS)
    {
      SetupEssenceElement(player.LegStrike, Fix.LEG_STRIKE, One.AR.LegStrike, counter); counter++;
      SetupEssenceElement(player.SpeedStep, Fix.SPEED_STEP, One.AR.SpeedStep, counter); counter++;
      SetupEssenceElement(player.BoneCrush, Fix.BONE_CRUSH, One.AR.BoneCrush, counter); counter++;
      SetupEssenceElement(player.DeadlyDrive, Fix.DEADLY_DRIVE, One.AR.DeadlyDrive, counter); counter++;
      SetupEssenceElement(player.UnintentionalHit, Fix.UNINTENTIONAL_HIT, One.AR.UnintentionalHit, counter); counter++;
      SetupEssenceElement(player.StanceOfMuin, Fix.STANCE_OF_MUIN, One.AR.StanceOfMuin, counter); counter++;
      SetupEssenceElement(player.CarnageRush, Fix.CARNAGE_RUSH, One.AR.CarnageRush, counter); counter++;
    }
    else if (attribute == Fix.CLASS_ARCHERY)
    {
      SetupEssenceElement(player.HunterShot, Fix.HUNTER_SHOT, One.AR.HunterShot, counter); counter++;
      SetupEssenceElement(player.MultipleShot, Fix.MULTIPLE_SHOT, One.AR.MultipleShot, counter); counter++;
      SetupEssenceElement(player.EyeOfTheIsshin, Fix.EYE_OF_THE_ISSHIN, One.AR.EyeOfTheIsshin, counter); counter++;
      SetupEssenceElement(player.PenetrationArrow, Fix.PENETRATION_ARROW, One.AR.PenetrationArrow, counter); counter++;
      SetupEssenceElement(player.PrecisionStrike, Fix.PRECISION_STRIKE, One.AR.PrecisionStrike, counter); counter++;
      SetupEssenceElement(player.EternalConcentration, Fix.ETERNAL_CONCENTRATION, One.AR.EternalConcentration, counter); counter++;
      SetupEssenceElement(player.PiercingArrow, Fix.PIERCING_ARROW, One.AR.PiercingArrow, counter); counter++;
    }
    else if (attribute == Fix.CLASS_TRUTH)
    {
      SetupEssenceElement(player.TrueSight, Fix.TRUE_SIGHT, One.AR.TrueSight, counter); counter++;
      SetupEssenceElement(player.LeylineSchema, Fix.LEYLINE_SCHEMA, One.AR.LeylineSchema, counter); counter++;
      SetupEssenceElement(player.VoiceOfVigor, Fix.VOICE_OF_VIGOR, One.AR.VoiceOfVigor, counter); counter++;
      SetupEssenceElement(player.WillAwakening, Fix.WILL_AWAKENING, One.AR.WillAwakening, counter); counter++;
      SetupEssenceElement(player.EverflowMind, Fix.EVERFLOW_MIND, One.AR.EverflowMind, counter); counter++;
      SetupEssenceElement(player.SigilOfTheFaith, Fix.SIGIL_OF_THE_FAITH, One.AR.SigilOfTheFaith, counter); counter++;
      SetupEssenceElement(player.StanceOfTheKokoroe, Fix.STANCE_OF_THE_KOKOROE, One.AR.StanceOfTheKokoroe, counter); counter++;
    }
    else if (attribute == Fix.CLASS_MINDFULNESS)
    {
      SetupEssenceElement(player.DispelMagic, Fix.DISPEL_MAGIC, One.AR.DispelMagic, counter); counter++;
      SetupEssenceElement(player.SpiritualRest, Fix.SPIRITUAL_REST, One.AR.SpiritualRest, counter); counter++;
      SetupEssenceElement(player.UnseenAid, Fix.UNSEEN_AID, One.AR.UnseenAid, counter); counter++;
      SetupEssenceElement(player.CircleOfSerenity, Fix.CIRCLE_OF_SERENITY, One.AR.CircleOfSerenity, counter); counter++;
      SetupEssenceElement(player.InnerInspiration, Fix.INNER_INSPIRATION, One.AR.InnerInspiration, counter); counter++;
      SetupEssenceElement(player.ZeroImmunity, Fix.ZERO_IMMUNITY, One.AR.ZeroImmunity, counter); counter++;
      SetupEssenceElement(player.TranscendenceReached, Fix.TRANSCENDENCE_REACHED, One.AR.TranscendenceReached, counter); counter++;
    }
  }

  private void SetupEssenceElement(int element_level, string label_text, bool available, int number)
  {
    // level 1以上なら可視化
    if (element_level >= 1)
    {
      txtEssenceElementList[number].text = label_text;
      imgEssenceElementList[number].sprite = Resources.Load<Sprite>(label_text);
      txtEssenceElementLevelList[number].text = "Lv " + element_level.ToString();
      objHideEssenceElementList[number].SetActive(false);
    }
    // level 0であっても、条件を満たせば可視化
    else if (available)
    {
      txtEssenceElementList[number].text = label_text;
      imgEssenceElementList[number].sprite = Resources.Load<Sprite>(label_text);
      txtEssenceElementLevelList[number].text = "Lv " + element_level.ToString();
      objHideEssenceElementList[number].SetActive(false);
    }
    // それ以外は非表示とする。
    else
    {
      txtEssenceElementList[number].text = "？？？";
      imgEssenceElementList[number].sprite = Resources.Load<Sprite>(Fix.STAY);
      txtEssenceElementLevelList[number].text = ""; // "Lv " + element_level.ToString();
      objHideEssenceElementList[number].SetActive(true);
    }
  }
  #endregion
}
