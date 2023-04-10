using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public partial class HomeTown : MotherBase
{
  #region "Core"
  // HomeTown
  public Image backgroundData;
  public Text dayLabel;
  public GameObject objBlackOut;
  public Text txtDate;
  public Text txtArea;
  public Text txtSoulFragment;
  public Text txtObsidianStone;
  public Text txtMessage;

  // Config
  public GameObject GroupConfig;

  // DungeonPlayer
  public GameObject GroupDungeonPlayer;
  public GameObject contentDungeonPlayer;
  public NodeButton nodeButton;
  public Image imgEventIcon;
  public Text txtEventTitle;
  public Text txtEventDescription;
  public GameObject GroupSelectArea;
  public GameObject contentSelectArea;
  public NodeSelectAreaButton nodeSelectAreaButton;
  public Text txtGoButton;

  // Character
  public GameObject GroupCharacter;
  public GameObject contentCharacter;
  public NodeCharaView nodeCharaView;

  // Backpack
  public GameObject GroupBackpack;
  public GameObject ContentBackpack;
  public NodeBackpackItem nodeBackpackItem;
  public GameObject GroupDeleteDecision;
  public Image imgDeleteItem;
  public Text txtDeleteTitle;
  public Text txtDeleteMessage;
  public Button btnDelete;
  public Button btnCancel;
  public Button btnOK;
  public GameObject GroupItemDetail;
  public Image imgItemDetail;
  public Text txtItemDetailName;
  public Text txtItemDetailType;
  public Text txtItemDetailDesc;
  public Text txtItemDetailSTR;
  public Text txtItemDetailAGL;
  public Text txtItemDetailINT;
  public Text txtItemDetailSTM;
  public Text txtItemDetailMND;
  public Text txtItemDetailPA;
  public Text txtItemDetailPAMax;
  public Text txtItemDetailPD;
  public Text txtItemDetailMA;
  public Text txtItemDetailMAMax;
  public Text txtItemDetailMD;
  public Text txtItemDetailACC;
  public Text txtItemDetailSPD;
  public Text txtItemDetailRSP;
  public Text txtItemDetailPO;
  public Image imgItemDetailSTR;
  public Image imgItemDetailAGL;
  public Image imgItemDetailINT;
  public Image imgItemDetailSTM;
  public Image imgItemDetailMND;
  public Image imgItemDetailPA;
  public Image imgItemDetailPAMax;
  public Image imgItemDetailPD;
  public Image imgItemDetailMA;
  public Image imgItemDetailMAMax;
  public Image imgItemDetailMD;
  public Image imgItemDetailACC;
  public Image imgItemDetailSPD;
  public Image imgItemDetailRSP;
  public Image imgItemDetailPO;
  public Button btnJewelSocket;

  // Item-JewelSocket
  public GameObject GroupJewelSocket;
  public Text txtJewelSocketName;
  public Text txtJewelSocketType;
  public Image imgJewelSocket;
  public GameObject objJewelSocketItem1;
  public GameObject objJewelSocketItem2;
  public GameObject objJewelSocketItem3;
  public GameObject objJewelSocketItem4;
  public GameObject objJewelSocketItem5;
  public GameObject objBlackout_1;
  public GameObject objBlackout_2;
  public GameObject objBlackout_3;
  public GameObject objBlackout_4;
  public GameObject objBlackout_5;
  public Image imgJewelSocketItem1;
  public Image imgJewelSocketItem2;
  public Image imgJewelSocketItem3;
  public Image imgJewelSocketItem4;
  public Image imgJewelSocketItem5;
  public Text txtJewelSocketItem1;
  public Text txtJewelSocketItem2;
  public Text txtJewelSocketItem3;
  public Text txtJewelSocketItem4;
  public Text txtJewelSocketItem5;
  public Text lblJewelSocketItem1;
  public Text lblJewelSocketItem2;
  public Text lblJewelSocketItem3;
  public Text lblJewelSocketItem4;
  public Text lblJewelSocketItem5;
  // Equip-JewelSocket
  public GameObject GroupEquipJewelSocket;
  public Text lblEquipJewelSocket;
  public Text txtEquipJewelSocketName;
  public Image imgEquipJewelSocket;
  public GameObject ContentChangeJewelSocket;
  public NodeBackpackItem NodeBackpackItem_JeweSocket;

  // Character ( Detail )
  public GroupCharacterStatus GroupCharacterDetail;
  public Text txtDetailName;
  public Text txtDetailLevel;
  public Text txtDetailLife;
  public Text txtDetailStrength;
  public Text txtDetailAgility;
  public Text txtDetailIntelligence;
  public Text txtDetailStamina;
  public Text txtDetailMind;
  public Text txtDetailMainWeapon;
  public Image imgDetailMainWeapon;
  public Text txtDetailSubWeapon;
  public Image imgDetailSubWeapon;
  public Text txtDetailArmor;
  public Image imgDetailArmor;
  public Text txtDetailAccessory1;
  public Image imgDetailAccessory1;
  public Text txtDetailAccessory2;
  public Image imgDetailAccessory2;
  public Text txtDetailArtifact;
  public Image imgDetailArtifact;
  public Text txtDetailPhysicalAttack;
  public Text txtDetailPhysicalAttackMax;
  public Text txtDetailPhysicalDefense;
  public Text txtDetailMagicAttack;
  public Text txtDetailMagicAttackMax;
  public Text txtDetailMagicDefense;
  public Text txtDetailBattleSpeed;
  public Text txtDetailBattleResponse;
  public Text txtDetailPotential;
  public GameObject GroupLevelUp;
  public Text txtDetailRemainPoint;

  // Character ( Detail - Change Equip )
  public GameObject GroupMainEquip;
  public GameObject GroupChangeEquip;
  public GameObject ContentChangeEquip;
  public NodeBackpackItem nodeChangeEquip;
  public Text lblChangeEquipType;
  public Text txtChangeEquipName;
  public Image imgChangeEquip;

  // Shop Item
  public GameObject GroupShopItem;
  public GameObject GroupShopBuy;
  public GameObject GroupShopSell;
  public GameObject contentShopItem;
  public GameObject contentSellBackpackItem;
  public NodeShopItem nodeShopItem;
  public Image imgItem;
  public Text txtItemName;
  public Text txtItemType;
  public Text txtItemDesc;
  public Text txtItemSTR;
  public Text txtItemAGL;
  public Text txtItemINT;
  public Text txtItemSTM;
  public Text txtItemMND;
  public Text txtItemPA;
  public Text txtItemPAMax;
  public Text txtItemPD;
  public Text txtItemMA;
  public Text txtItemMAMax;
  public Text txtItemMD;
  public Text txtItemACC;
  public Text txtItemSPD;
  public Text txtItemRSP;
  public Text txtItemPO;
  public Image imgItemSTR;
  public Image imgItemAGL;
  public Image imgItemINT;
  public Image imgItemSTM;
  public Image imgItemMND;
  public Image imgItemPA;
  public Image imgItemPAMax;
  public Image imgItemPD;
  public Image imgItemMA;
  public Image imgItemMAMax;
  public Image imgItemMD;
  public Image imgItemACC;
  public Image imgItemSPD;
  public Image imgItemRSP;
  public Image imgItemPO;
  public Text txtItemGoldCost;
  public GameObject groupBuyDecision;
  public Image imgBuy;
  public Text txtBuyTitle;
  public Text txtBuyMessage;
  public Button btnBuyAccept;
  public Button btnBuyCancel;
  public Button btnBuyOK;
  public GameObject groupSellDecision;
  public Image imgSell;
  public Text txtSellTitle;
  public Text txtSellMessage;
  public Button btnSellAccept;
  public Button btnSellCancel;
  public Button btnSellOK;
  public Button btnShopBuy;
  public Button btnShopSell;
  public Text txtShopCurrentType;

  // Tactics
  public GameObject GroupTactics;
  public List<Button> StayList;
  public List<Text> StayListName;
  public List<GameObject> StayListCheckMark;
  public List<GameObject> GroupPartyList;
  public List<GameObject> MemberIconList;
  public List<Image> PartyListClass;
  public List<Text> PartyListName;
  public List<Text> PartyListLevel;
  public List<Text> PartyListLife;
  public List<Text> PartyListSTR;
  public List<Text> PartyListAGL;
  public List<Text> PartyListINT;
  public List<Text> PartyListSTM;
  public List<Text> PartyListMND;
  public NodeActionCommand prefab_ActionCommand;
  public GameObject objSelectCursor;
  public Text txtSelectCursor;

  // Inn
  public GameObject GroupInn;
  public GameObject GroupInnDecision;
  public List<Text> txtFoodMenuList;
  public Text txtFoodMenuTitle;
  public Text txtFoodMenuDesc;

  // Quest Message
  public GameObject GroupQuestMessage;
  public GameObject HidePanelMessage;
  public GameObject PanelTapMessage;
  public Text txtQuestMessage;
  public GameObject panelSystemMessage;
  public Text txtSystemMessage;

  // Quest Complete
  public GameObject GroupQuestComplete;
  public Text txtQCTitle;
  public Text txtQCExpGain;
  public Text txtQCGoldGain;
  public Text txtQCItemGain;
  public Text txtQCSoulEssenceGain;

  // Decision Message
  public GameObject GroupDecisionMessage;
  public Text txtDecisionMessageTitle;
  public Text txtDecisionMessageDescription;
  public Button btnDecisionMessageAccept;
  public Button btnDecisionMessageCancel;

  // Level-UP Character
  public GameObject GroupLvupCharacter;
  public Text txtLvupTitle;
  public Text txtLvupMaxLife;
  public Text txtLvupMaxMana;
  public Text txtLvupMaxSkill;
  public Text txtLvupRemainPoint;
  public Text txtLvupSoulEssence;
  public Text txtLvupSpecial;

  // AC Attribute
  public GameObject GroupActionCommandSetting;
  public NodeACAttribute NodeACAttribute;
  public List<GameObject> GroupACAttributeHide;
  public Text txtAttributeSoulFragment;
  public GameObject ContentActionCommandSetting;
  public GameObject ContentMiniChara;
  public NodeMiniChara NodeMiniCharaIcon;
  public GameObject EmptyGroup;
  public Text txtACHeaderName;

  public List<Image> imgACElement;
  public List<Text> txtACElement;

  public GameObject groupDecision;
  public Image imgCurrentDecision;
  public Text txtDecisionTitle;
  public Text txtDecisionMessage;
  public Button btnDecisionAccept;
  public Button btnDecisionCancel;
  public Button btnDecisionOK;

  // Menu Button
  public Button btnSkillTree;
  public Text txtSkillTree;
  public Button btnTactics;
  public Text txtTactics;
  public Button btnCustomEvent1;
  public Text txtCustomEvent1;
  public Button btnCustomEvent2;
  public Text txtCustomEvent2;
  public Button btnCustomEvent3;
  public Text txtCustomEvent3;

  public GameObject groupNowLoading;
  public SaveLoad groupSaveLoad;

  // Inner Value
  protected List<bool> DetectLvup = new List<bool>();
  protected List<string> DetectLvupTitle = new List<string>();
  protected List<string> DetectLvupMaxLife = new List<string>();
  protected List<string> DetectLvupMaxManaPoint = new List<string>();
  protected List<string> DetectLvupMaxSkillPoint = new List<string>();
  protected List<string> DetectLvupRemainPoint = new List<string>();
  protected List<string> DetectLvupSoulEssence = new List<string>();
  protected List<string> DetectLvupSpecial = new List<string>();

  protected List<NodeCharaView> CharaViewList = new List<NodeCharaView>();
  protected Character CurrentPlayer = null;
  protected Character ShadowPlayer = null;
  protected string CurrentItemType = String.Empty;

  protected List<string> QuestMessageList = new List<string>();
  protected List<MessagePack.ActionEvent> QuestEventList = new List<MessagePack.ActionEvent>();

  List<NodeShopItem> ShopItemList = new List<NodeShopItem>();
  List<NodeShopItem> ShopSellItemList = new List<NodeShopItem>();
  List<NodeBackpackItem> BackpackList = new List<NodeBackpackItem>();
  List<NodeBackpackItem> BackpackJewelSocketList = new List<NodeBackpackItem>();

  protected Item CurrentSelectBackpack = null;
  protected Item CurrentSelectJewelSocketItem = null;
  protected int CurrentSelectJewelSocketNumber = 0;

  protected GameObject CurrentSelectHideACAttribute;

  private string DungeonCall = string.Empty;
  private string DungeonMap = string.Empty;
  private bool DungeonCallComplete = false;

  private Character TacticsPickupCharacter = null;
  private int TacticsPickupPartyNumber = -1;
  private bool nowSelectCursor = false;
  private Canvas canvas;
  private RectTransform canvasRect;
  private Vector2 mousePosition;
  protected bool FirstAction = false;

  private bool HomeTownComplete = false;

  private int firstDay = 1;

  // Use this for initialization
  public override void Start()
  {
    base.Start();

    One.TF.SaveByDungeon = false;

    this.canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    this.canvasRect = canvas.GetComponent<RectTransform>();

    // 初期画面設定
    RefreshAllView();

    // イベント進行
    if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET)
    {
      if (One.TF.Event_Message100010 == false)
      {
        One.TF.Event_Message100010 = true;
        One.TF.AlreadyRestInn = true;
        UpdateBackgroundData(Fix.BACKGROUND_MORNING);
        MessagePack.Message100010(ref QuestMessageList, ref QuestEventList);
        TapOK();

        objBlackOut.SetActive(true);
        GroupQuestMessage.SetActive(true);
        return;
      }
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE)
    {
      if (One.TF.Event_Message100020 == false)
      {
        One.TF.Event_Message100020 = true;
        MessagePack.Message100020(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }

      // 港町コチューシェからの帰還
      if (One.TF.Event_Message500020 && One.TF.Event_Message700010 == false)
      {
        MessagePack.Message700010(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // オーランの塔からの帰還
      if (One.TF.Event_Message800100 && One.TF.Event_Message700020 == false)
      {
        MessagePack.Message700020(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_QVELTA_TOWN)
    {
      if (One.TF.Event_Message200010 == false)
      {
        One.TF.Event_Message200010 = true;
        MessagePack.Message200010(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN)
    {
      if (One.TF.Event_Message500010 == false)
      {
        MessagePack.Message500010(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }

    txtQuestMessage.text = "アイン：さて、何すっかな。";
    txtMessage.text = "アイン：さて、何すっかな。";
  }

  // Update is called once per frame
  public void Update()
  {
    if (this.HomeTownComplete)
    {
      return;
    }

    if (this.FirstAction == false)
    {
      this.FirstAction = true;

      // １日目終了時
      if (this.firstDay >= 1 && One.TF.AlreadyDungeon && One.TF.AvailableImmediateAction == false)
      {
        MessagePack.Message000190(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // クヴェルタ街、奇妙な物体の調査
      if (One.TF.CurrentAreaName == Fix.TOWN_QVELTA_TOWN && One.TF.Event_Message200040 == false && One.TF.QuestMain_00010 && One.TF.QuestMain_Complete_00010 == false)
      {
        MessagePack.Message200040(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      // 港町コチューシェ、初めのエントリー
      if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE && One.TF.Event_Message400010 == false)
      {
        MessagePack.Message400010(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      // アーケンダイン街、初めのエントリー
      if (One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE && One.TF.Event_Message1100010 == false)
      {
        MessagePack.Message1100010(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA && One.TF.Event_Message1100050)
      {
        MessagePack.Message2200010(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      // ツァルマンの里、神秘の森から帰還
      if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN && One.TF.Event_Message500022 && One.TF.Event_EntryMysticForest && One.TF.Event_Message500024 == false)
      {
        MessagePack.Message500024(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

    }

    if (this.DungeonCallComplete)
    {
      return;
    }
    if (this.DungeonCall != string.Empty && this.DungeonMap != string.Empty && this.DungeonCallComplete == false)
    {
      this.DungeonCallComplete = true;
      Debug.Log("DungeonCallComplete: " + this.DungeonCall + " " + this.DungeonMap);
      One.TF.BeforeAreaName = One.TF.CurrentAreaName;
      SceneDimension.JumpToDungeonField(this.DungeonMap);
      return;
    }

    if (this.objSelectCursor.activeInHierarchy)
    {
      RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(),
                        Input.mousePosition, canvas.worldCamera, out this.mousePosition);
      RectTransform objRect = objSelectCursor.GetComponent<RectTransform>();
      objSelectCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(mousePosition.x + objRect.sizeDelta.x + 10, mousePosition.y + objRect.sizeDelta.y + 10);
    }
  }

  public void TapConfig()
  {
    GroupConfig.SetActive(true);
  }

  public void TapConfigCancel()
  {
    GroupConfig.SetActive(false);
  }

  public void TapSave()
  {
    One.SaveMode = true;
    One.AfterBacktoTitle = false;
    One.SaveAndExit = false;
    this.groupSaveLoad.SceneLoading();
    this.groupSaveLoad.gameObject.SetActive(true);
    //SceneDimension.CallSaveLoad(this, true, false);
  }

  public void TapLoad()
  {
    One.SaveMode = false;
    One.AfterBacktoTitle = false;
    One.SaveAndExit = false;
    One.Parent.Add(this);
    this.groupSaveLoad.SceneLoading();
    this.groupSaveLoad.gameObject.SetActive(true);
    //SceneDimension.CallSaveLoad(this, false, false);
  }

  public void TapHelp()
  {
    Debug.Log(MethodBase.GetCurrentMethod() + "(S)");
    SceneDimension.SceneAdd(Fix.SCENE_HELP_BOOK);
  }

  public void TapPartyMenu()
  {
    //GroupPartyMenu.gameObject.SetActive(true);
    //this.CurrentPlayer = PlayerList[0];

    SceneManager.sceneLoaded += PartyMenuLoadded;
    SceneDimension.SceneAdd(Fix.SCENE_PARTY_MENU);
  }

  private void PartyMenuLoadded(Scene next, LoadSceneMode mode)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    SceneManager.sceneLoaded -= PartyMenuLoadded;

    //var charaStatus = GameObject.Find("groupCharacterStatus").GetComponent<GroupCharacterStatus>();

    //charaStatus.parentMotherBase = this;
    //charaStatus.ReleaseIt();
    //charaStatus.CurrentPlayer = this.CurrentPlayer;
    //charaStatus.UpdateCharacterDetailView(this.CurrentPlayer);
  }

  public void TapFastTravel()
  {
    // todo 何らかのイベントでホームタウンで使えるシナリオを構築すること。
    MessagePack.MessageX00013(ref QuestMessageList, ref QuestEventList);
    TapOK();
  }

  public void TapDungeonPlayer()
  {
    if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE && One.TF.QuestMain_00002 == false)
    {
      MessagePack.Message700040(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_QVELTA_TOWN && One.TF.Event_Message200040 && One.TF.Event_Message200050 == false && One.TF.QuestMain_00010 && One.TF.QuestMain_Complete_00010 == false)
    {
      MessagePack.Message200041(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE && (One.TF.Event_Message400020 == false || One.TF.Event_Message400030 == false))
    {
      MessagePack.Message400019(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE && One.TF.Event_Message400020 && One.TF.Event_Message400030 && One.TF.Event_Message400040 == false)
    {
      MessagePack.Message400040(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN && One.TF.Event_Message500020 == false)
    {
      MessagePack.Message500019(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN && One.TF.Event_Message500030 == false)
    {
      MessagePack.Message500030(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE && (One.TF.Event_Message1100020 == false || One.TF.Event_Message1100030 == false || One.TF.Event_Message1100040 == false))
    {
      MessagePack.Message1100011(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE && (One.TF.Event_Message1100050 == false && One.TF.Event_Message1100020 && One.TF.Event_Message1100030 && One.TF.Event_Message1100040))
    {
      MessagePack.Message1100050(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    if (GroupDungeonPlayer.activeInHierarchy)
    {
      GroupDungeonPlayer.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(true);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupTactics.SetActive(false);
    GroupInn.SetActive(false);
  }

  public void TapCharacter()
  {
    if (GroupCharacter.activeInHierarchy)
    {
      GroupCharacter.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(true);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupTactics.SetActive(false);
    GroupInn.SetActive(false);
  }

  public void TapBackpack()
  {
    if (GroupBackpack.activeInHierarchy)
    {
      GroupBackpack.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(true);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupTactics.SetActive(false);
    GroupInn.SetActive(false);
  }

  public void TapShop()
  {
    if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET)
    {
    }

    if (One.TF.CurrentAreaName == Fix.TOWN_QVELTA_TOWN && One.TF.Event_Message200040 && One.TF.Event_Message200050 == false && One.TF.QuestMain_00010 && One.TF.QuestMain_Complete_00010 == false)
    {
      MessagePack.Message200050(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    if (GroupShopItem.activeInHierarchy)
    {
      GroupShopItem.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(true);
    GroupActionCommandSetting.SetActive(false);
    GroupTactics.SetActive(false);
    GroupInn.SetActive(false);
  }

  public void TapActionCommandSetting()
  {
    if (One.TF.Event_Message100020 == false)
    {
      MessagePack.Message100015(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (GroupActionCommandSetting.activeInHierarchy)
    {
      GroupActionCommandSetting.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(true);
    GroupTactics.SetActive(false);
    GroupInn.SetActive(false);
  }

  public void TapTactics()
  {
    Debug.Log("TapTactics(S)");
    if (One.TF.Event_Message100020 == false)
    {
      MessagePack.Message100015(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(true);
    GroupTactics.SetActive(true);
    GroupInn.SetActive(false);
  }

  public void TapInn()
  {
    if (One.TF.Event_Message100020 == false && One.TF.Event_Message100001 == false)
    {
      MessagePack.Message100015(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_QVELTA_TOWN && One.TF.Event_Message200040 && One.TF.Event_Message200050 == false && One.TF.QuestMain_00010 && One.TF.QuestMain_Complete_00010 == false)
    {
      MessagePack.Message200041(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE && One.TF.Event_Message700020 == false)
    {
      MessagePack.Message700020(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    if (One.TF.AlreadyRestInn)
    {
      MessagePack.MessageX00002(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    if (GroupInn.activeInHierarchy)
    {
      GroupInn.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupInn.SetActive(true);
  }

  public void TapCustomEvent1()
  {
    if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE)
    {
      if (One.TF.Event_Message700030 == false)
      {
        MessagePack.Message700030(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        if (One.TF.Event_Message700010 && One.TF.Event_Message700050 == false)
        {
          MessagePack.Message700050(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        else
        {
          MessagePack.Message700031(ref QuestMessageList, ref QuestEventList); TapOK();
        }
        return;
      }
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE)
    {
      if (One.TF.Event_Message400020 == false)
      {
        MessagePack.Message400020(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.Message400021(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN)
    {
      if (One.TF.QuestMain_00022)
      {
        MessagePack.Message500022(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      if (One.TF.Event_Message500020 == false)
      {
        MessagePack.Message500020(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.Message500021(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE)
    {
      if (One.TF.Event_Message1100020 == false)
      {
        MessagePack.Message1100020(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA)
    {
      if (One.TF.Event_Message2200020 == false)
      {
        MessagePack.Message2200020(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
  }

  public void TapCustomEvent2()
  {
    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE)
    {
      if (One.TF.Event_Message400030 == false)
      {
        MessagePack.Message400030(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.Message400031(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN)
    {
      if (One.TF.Event_Message500022)
      {
        MessagePack.Message500023(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE)
    {
      if (One.TF.Event_Message1100030 == false)
      {
        MessagePack.Message1100030(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    else
    {
      MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
  }

  public void TapCustomEvent3()
  {
    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE)
    {
      MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN)
    {
      MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE)
    {
      if (One.TF.Event_Message1100040 == false)
      {
        MessagePack.Message1100040(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
    else
    {
      MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
  }

  public void TapDecisionMessageAccept()
  {
    if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN)
    {
      this.DungeonMap = Fix.MAPFILE_MYSTIC_FOREST;
      this.DungeonCall = Fix.DUNGEON_MYSTIC_FOREST;
      One.TF.Field_X = 0;
      One.TF.Field_Y = 1;
      One.TF.Field_Z = 0;
    }
  }

  public void TapDecisionMessageCancel()
  {
    GroupDecisionMessage.SetActive(false);
    txtDecisionMessageTitle.text = string.Empty;
    txtDecisionMessageDescription.text = string.Empty;
  }

  public void TapDungeon()
  {
    Debug.Log(MethodBase.GetCurrentMethod().Name);

    if (QuestMessageList.Count > 0)
    {
      this.txtQuestMessage.text = QuestMessageList[0];
      RemoveOneSentence();
      this.GroupQuestMessage.SetActive(true);
      return;
    }

    if (One.TF.AlreadyDungeon)
    {
      MessagePack.MessageX00008(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    if (this.DungeonMap == String.Empty)
    {
      MessagePack.MessageX00011(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    if (this.DungeonMap == One.TF.CurrentAreaName)
    {
      MessagePack.MessageX00012(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    // 行き先がホームタウンの場合
    if (this.DungeonMap == Fix.TOWN_ANSHET ||
        this.DungeonMap == Fix.TOWN_FAZIL_CASTLE ||
        this.DungeonMap == Fix.TOWN_COTUHSYE ||
        this.DungeonMap == Fix.TOWN_ARCANEDINE ||
        this.DungeonMap == Fix.TOWN_PARMETYSIA ||
        this.DungeonMap == Fix.TOWN_DALE ||
        this.DungeonMap == Fix.TOWN_LATA_HOUSE ||
        this.DungeonMap == Fix.TOWN_FAZIL_UNDERGROUND)
    {
      ChangeHometown(One.TF.CurrentAreaName, this.DungeonMap);
    }
    // 行き先がダンジョンの場合
    else if (this.DungeonMap == Fix.DUNGEON_ESMILIA_GRASSFIELD)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET)
      {
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_ESMILIA_GRASSFIELD, 28.0f, 1.0f, 9.0f); // todo 後でX,Yの基点が0,0ではないので分かりにくい。
      }
      else
      {
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_ESMILIA_GRASSFIELD, -9.0f, 1.0f, -4.0f); // todo 後でX,Yの基点が0,0ではないので分かりにくい。
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_GORATRUM_CAVE)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET ||
          One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE)
      {
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_GORATRUM, 5.0f, 1.0f, -1.0f);
      }
      else
      {
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_GORATRUM, 1.0f, 1.0f, -5.0f);
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_MYSTIC_FOREST)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET ||
          One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE ||
          One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE)
      {
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_MYSTIC_FOREST, 0.0f, 1.0f, -9.0f);
      }
      else
      {
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_OHRAN_TOWER)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET ||
          One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE ||
          One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE ||
          One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE)
      {
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_OHRAN_TOWER, 15.0f, 1.0f, -30.0f);
      }
      else
      {
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_VELGUS_SEA_TEMPLE)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET ||
          One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE ||
          One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE ||
          One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE ||
          One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA)
      {
      }
      else
      {
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_GATE_OF_DHAL)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET ||
          One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE ||
          One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE ||
          One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE ||
          One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA)
      {
      }
      else
      {
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_DISKEL_BATTLE_FIELD)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET ||
          One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE ||
          One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE ||
          One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE ||
          One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA ||
          One.TF.CurrentAreaName == Fix.TOWN_DALE)
      {
      }
      else
      {
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_EDELGARZEN_CASTLE)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET ||
          One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE ||
          One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE ||
          One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE ||
          One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA ||
          One.TF.CurrentAreaName == Fix.TOWN_DALE)
      {
      }
      else
      {
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_SNOWTREE_LATA)
    {
      // 入口・出口の分岐はない
    }
    else if (this.DungeonMap == Fix.DUNGEON_HEAVENS_GENESIS_GATE)
    {
      // 入口・出口の分岐はない
    }
  }

  private void CallDungeon(string source, string destination, float x, float y, float z)
  {
    Debug.Log("CallDungeon -> " + source + " " + destination);
    One.TF.AlreadyDungeon = true;
    One.TF.AlreadyRestInn = false;
    One.TF.Field_X = x;
    One.TF.Field_Y = y;
    One.TF.Field_Z = z;
    One.TF.BeforeAreaName = source;
    SceneDimension.JumpToDungeonField(destination);
    groupNowLoading.SetActive(true);
  }

  private void ChangeHometown(string source, string destination)
  {
    One.TF.AlreadyDungeon = false;
    One.TF.AlreadyRestInn = true;
    this.HomeTownComplete = true;
    One.TF.BeforeAreaName = source;
    One.TF.CurrentAreaName = destination;
    SceneDimension.JumpToHomeTown();
    groupNowLoading.SetActive(true);
  }

  //public void TapInn()
  //{
  //  Debug.Log(MethodBase.GetCurrentMethod().Name);

  //  if (One.TF.Event_Message100020 == false)
  //  {
  //    MessagePack.Message100015(ref QuestMessageList, ref QuestEventList);
  //    TapOK();
  //    return;
  //  }

  //  if (One.TF.AlreadyDungeon == false)
  //  {
  //    txtMessage.text = "ハンナ：まだどこにも行ってないみたいだね。早く出かけておいで。";
  //    return;
  //  }
  //  if (One.TF.RestInn)
  //  {
  //    txtMessage.text = "ハンナ：さっき、休んだばかりだよ。早く出かけておいで。";
  //    return;
  //  }

  //  for (int ii = 0; ii < One.PlayerList.Count; ii++)
  //  {
  //    One.PlayerList[ii].MaxGain();
  //  }
  //  One.TF.AlreadyDungeon = false;
  //  One.TF.RestInn = true;
  //  txtMessage.text = "ハンナ：休憩だね。全回復しておいたよ。";
  //}

  public void TapCharacterPanel(Text txtName)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    // 現在選択しているキャラクターを設定
    for (int ii = 0; ii < One.PlayerList.Count; ii++)
    {
      if (One.PlayerList[ii].FullName == txtName.text)
      {
        this.CurrentPlayer = One.PlayerList[ii];
        break;
      }
    }

    if (this.CurrentPlayer == null) { Debug.Log("Cannot search currentPlayer: " + txtName.text); return; }

    // キャラクター詳細画面へレベルアップ情報を反映
    this.CurrentPlayer.GetReadyLevelUp();

    // キャラクター詳細画面を呼び出し
    // HomeTownシーン内でCharacterStatus画面は保持しない。UnityのCharacterStatusシーンで管理する。
    // Dungeonfieldシーンからも同様。
    //GroupCharacterDetail.parentMotherBase = this;
    //GroupCharacterDetail.ReleaseIt();
    //GroupCharacterDetail.CurrentPlayer = this.CurrentPlayer;
    //GroupCharacterDetail.UpdateCharacterDetailView(this.CurrentPlayer);
    //GroupCharacterDetail.gameObject.SetActive(true);

    SceneManager.sceneLoaded += CharacterStatusLoadded;
    SceneDimension.SceneAdd("CharacterStatus");
    Debug.Log(MethodBase.GetCurrentMethod() + "(E)");
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

  public void TapHideACAttributeButton(GameObject sender)
  {
    Debug.Log("TapHideACAttributeButton(S) " + sender.name);
    Button[] btnList = sender.GetComponentsInChildren<Button>();
    for (int ii = 0; ii < btnList.Length; ii++)
    {
      Debug.Log("btnList: " + btnList[ii].name);
      if (btnList[ii].name.Contains("hidePanel"))
      {
        this.CurrentSelectHideACAttribute = sender;
        break;
      }
    }

    Text[] txtList = sender.GetComponentsInChildren<Text>();
    string currentAttributeName = String.Empty;
    for (int ii = 0; ii < txtList.Length; ii++)
    {
      Debug.Log("txtList: " + txtList[ii].name);
      if (txtList[ii].name.Contains("txtElement"))
      {
        currentAttributeName = txtList[ii].text;
        break;
      }
    }

    // １つ前のリストが解放されてないなら、ブロックする。
    // todo ただし一つ一つのコマンドをコーディングしないといけない。
    if (currentAttributeName == Fix.STANCE_OF_THE_BLADE && CurrentPlayer.StraightSmash <= 0)
    {
      CallBlockPage(currentAttributeName, Fix.STRAIGHT_SMASH);
      return;
    }
    if (currentAttributeName == Fix.DOUBLE_SLASH && CurrentPlayer.StanceOfTheBlade <= 0)
    {
      CallBlockPage(currentAttributeName, Fix.STANCE_OF_THE_BLADE);
      return;
    }

    if (CurrentPlayer.SoulFragment <= 0)
    {
      Debug.Log("CurrentPlayer.SoulFragment is under 0");

      imgCurrentDecision.sprite = Resources.Load<Sprite>(currentAttributeName);
      imgCurrentDecision.name = currentAttributeName;
      txtDecisionTitle.text = currentAttributeName + " を解放する事ができません。";
      txtDecisionMessage.text = "ソウル・フラグメントが不足しています。ソウル・フラグメントを入手してください。";
      btnDecisionAccept.gameObject.SetActive(false);
      btnDecisionCancel.gameObject.SetActive(false);
      btnDecisionOK.gameObject.SetActive(true);
      groupDecision.SetActive(true);
      return;
    }

    Debug.Log("CurrentPlayer.SoulFragment is currently " + CurrentPlayer.SoulFragment);

    imgCurrentDecision.sprite = Resources.Load<Sprite>(currentAttributeName);
    imgCurrentDecision.name = currentAttributeName;
    txtDecisionTitle.text = currentAttributeName + " を解放しますか？";
    txtDecisionMessage.text = "ソウル・フラグメントを１ポイント消費します。この操作は元に戻せません。";
    btnDecisionAccept.gameObject.SetActive(true);
    btnDecisionCancel.gameObject.SetActive(true);
    btnDecisionOK.gameObject.SetActive(false);
    groupDecision.SetActive(true);
  }

  private void CallBlockPage(string wish_command, string restriction)
  {
    imgCurrentDecision.sprite = Resources.Load<Sprite>(wish_command);
    imgCurrentDecision.name = wish_command;
    txtDecisionTitle.text = wish_command + " を解放する条件を満たしていません。";
    txtDecisionMessage.text = "このコマンドを解放するためには、" + restriction + "を解放する必要があります";
    btnDecisionAccept.gameObject.SetActive(false);
    btnDecisionCancel.gameObject.SetActive(false);
    btnDecisionOK.gameObject.SetActive(true);
    groupDecision.SetActive(true);
  }

  public void TapACAttributeButton(Text sender)
  {
    Debug.Log("sender: " + sender.text);
    if (CurrentPlayer.SoulFragment <= 0)
    {
      imgCurrentDecision.sprite = Resources.Load<Sprite>(sender.text);
      imgCurrentDecision.name = sender.text;
      txtDecisionTitle.text = sender.text + " を強化する事ができません。";
      txtDecisionMessage.text = "ソウル・フラグメントが不足しています。ソウル・フラグメントを入手してください。";
      btnDecisionAccept.gameObject.SetActive(false);
      btnDecisionCancel.gameObject.SetActive(false);
      btnDecisionOK.gameObject.SetActive(true);
    }
    else
    {
      imgCurrentDecision.sprite = Resources.Load<Sprite>(sender.text);
      imgCurrentDecision.name = sender.text;
      txtDecisionTitle.text = sender.text + " を強化しますか？";
      txtDecisionMessage.text = "ソウル・フラグメントを１ポイント消費します。この操作は元に戻せません。";
      btnDecisionAccept.gameObject.SetActive(true);
      btnDecisionCancel.gameObject.SetActive(true);
      btnDecisionOK.gameObject.SetActive(false);
    }
    groupDecision.SetActive(true);
  }

  public void TapDecisionAccept()
  {
    groupDecision.SetActive(false);
    // Delve I
    if (imgCurrentDecision.name == Fix.FIRE_BALL) { CurrentPlayer.FireBall++; }
    else if (imgCurrentDecision.name == Fix.ICE_NEEDLE) { CurrentPlayer.IceNeedle++; }
    else if (imgCurrentDecision.name == Fix.FRESH_HEAL) { CurrentPlayer.FreshHeal++; }
    else if (imgCurrentDecision.name == Fix.SHADOW_BLAST) { CurrentPlayer.ShadowBlast++; }
    else if (imgCurrentDecision.name == Fix.AIR_CUTTER) { CurrentPlayer.AirCutter++; }
    else if (imgCurrentDecision.name == Fix.ROCK_SLAM) { CurrentPlayer.RockSlam++; }
    else if (imgCurrentDecision.name == Fix.STRAIGHT_SMASH) { CurrentPlayer.StraightSmash++; }
    else if (imgCurrentDecision.name == Fix.HUNTER_SHOT) { CurrentPlayer.HunterShot++; }
    else if (imgCurrentDecision.name == Fix.LEG_STRIKE) { CurrentPlayer.LegStrike++; }
    else if (imgCurrentDecision.name == Fix.VENOM_SLASH) { CurrentPlayer.VenomSlash++; }
    else if (imgCurrentDecision.name == Fix.ENERGY_BOLT) { CurrentPlayer.EnergyBolt++; }
    else if (imgCurrentDecision.name == Fix.SHIELD_BASH) { CurrentPlayer.ShieldBash++; }
    else if (imgCurrentDecision.name == Fix.AURA_OF_POWER) { CurrentPlayer.AuraOfPower++; }
    else if (imgCurrentDecision.name == Fix.DISPEL_MAGIC) { CurrentPlayer.DispelMagic++; }
    else if (imgCurrentDecision.name == Fix.TRUE_SIGHT) { CurrentPlayer.TrueSight++; }
    else if (imgCurrentDecision.name == Fix.HEART_OF_LIFE) { CurrentPlayer.HeartOfLife++; }
    else if (imgCurrentDecision.name == Fix.DARK_AURA) { CurrentPlayer.DarkAura++; }
    else if (imgCurrentDecision.name == Fix.ORACLE_COMMAND) { CurrentPlayer.OracleCommand++; }


    else if (imgCurrentDecision.name == Fix.FLAME_BLADE) { CurrentPlayer.FlameBlade++; }
    else if (imgCurrentDecision.name == Fix.METEOR_BULLET) { CurrentPlayer.MeteorBullet++; }
    else if (imgCurrentDecision.name == Fix.FLAME_STRIKE) { CurrentPlayer.FlameStrike++; }
    else if (imgCurrentDecision.name == Fix.LAVA_ANNIHILATION) { CurrentPlayer.LavaAnnihilation++; }
    else if (imgCurrentDecision.name == Fix.PURE_PURIFICATION) { CurrentPlayer.PurePurification++; }
    else if (imgCurrentDecision.name == Fix.BLUE_BULLET) { CurrentPlayer.BlueBullet++; }
    else if (imgCurrentDecision.name == Fix.FREEZING_CUBE) { CurrentPlayer.FreezingCube++; }
    else if (imgCurrentDecision.name == Fix.FROST_LANCE) { CurrentPlayer.FrostLance++; }
    else if (imgCurrentDecision.name == Fix.DIVINE_CIRCLE) { CurrentPlayer.DivineCircle++; }
    else if (imgCurrentDecision.name == Fix.HOLY_BREATH) { CurrentPlayer.HolyBreath++; }
    else if (imgCurrentDecision.name == Fix.BLOOD_SIGN) { CurrentPlayer.BloodSign++; }
    else if (imgCurrentDecision.name == Fix.BLACK_CONTRACT) { CurrentPlayer.BlackContract++; }
    else if (imgCurrentDecision.name == Fix.ABYSS_EYE) { CurrentPlayer.AbyssEye++; }
    else if (imgCurrentDecision.name == Fix.STANCE_OF_THE_BLADE) { CurrentPlayer.StanceOfTheBlade++; }
    else if (imgCurrentDecision.name == Fix.DOUBLE_SLASH) { CurrentPlayer.DoubleSlash++; }
    else if (imgCurrentDecision.name == Fix.KINETIC_SMASH) { CurrentPlayer.KineticSmash++; }
    else if (imgCurrentDecision.name == Fix.STANCE_OF_THE_GUARD) { CurrentPlayer.StanceOfTheGuard++; }
    else if (imgCurrentDecision.name == Fix.CONCUSSIVE_HIT) { CurrentPlayer.ConcussiveHit++; }
    else if (imgCurrentDecision.name == Fix.DOMINATION_FIELD) { CurrentPlayer.DominationField++; }
    else if (imgCurrentDecision.name == Fix.OATH_OF_AEGIS) { CurrentPlayer.OathOfAegis++; }
    else if (imgCurrentDecision.name == Fix.MULTIPLE_SHOT) { CurrentPlayer.MultipleShot++; }
    else if (imgCurrentDecision.name == Fix.EYE_OF_THE_ISSHIN) { CurrentPlayer.EyeOfTheIsshin++; }
    else if (imgCurrentDecision.name == Fix.PIERCING_ARROW) { CurrentPlayer.PiercingArrow++; }
    else if (imgCurrentDecision.name == Fix.INVISIBLE_BIND) { CurrentPlayer.InvisibleBind++; }
    else if (imgCurrentDecision.name == Fix.IRREGULAR_STEP) { CurrentPlayer.IrregularStep++; }
    else if (imgCurrentDecision.name == Fix.ASSASSINATION_HIT) { CurrentPlayer.AssassinationHit++; }
    else if (imgCurrentDecision.name == Fix.SKY_SHIELD) { CurrentPlayer.SkyShield++; }
    else if (imgCurrentDecision.name == Fix.STORM_ARMOR) { CurrentPlayer.StormArmor++; }
    else if (imgCurrentDecision.name == Fix.FLASH_COUNTER) { CurrentPlayer.FlashCounter++; }
    else if (imgCurrentDecision.name == Fix.MUTE_IMPULSE) { CurrentPlayer.MuteImpulse++; }
    else if (imgCurrentDecision.name == Fix.DETACHMENT_FAULT) { CurrentPlayer.DetachmentFault++; }
    else if (imgCurrentDecision.name == Fix.PHANTOM_OBORO) { CurrentPlayer.PhantomOboro++; }
    else if (imgCurrentDecision.name == Fix.FORTUNE_SPIRIT) { CurrentPlayer.FortuneSpirit++; }
    else if (imgCurrentDecision.name == Fix.VOICE_OF_VIGOR) { CurrentPlayer.VoiceOfVigor++; }
    else if (imgCurrentDecision.name == Fix.SIGIL_OF_THE_FAITH) { CurrentPlayer.SigilOfTheFaith++; }
    else if (imgCurrentDecision.name == Fix.RAGING_STORM) { CurrentPlayer.RagingStorm++; }
    else if (imgCurrentDecision.name == Fix.SPIRITUAL_REST) { CurrentPlayer.SpiritualRest++; }
    else if (imgCurrentDecision.name == Fix.ZERO_IMMUNITY) { CurrentPlayer.ZeroImmunity++; }
    else if (imgCurrentDecision.name == Fix.ESSENCE_OVERFLOW) { CurrentPlayer.EssenceOverflow++; }
    else if (imgCurrentDecision.name == Fix.INNER_INSPIRATION) { CurrentPlayer.InnerInspiration++; }
    else
    {
      Debug.Log("Unknown Command: " + imgCurrentDecision.name);
      return; // 未登録の場合は、何も更新せず終了する。
    }
    CurrentPlayer.SoulFragment--;
    CurrentSelectHideACAttribute.gameObject.SetActive(false);
    UpdateActionCommandSetting(CurrentPlayer);
  }
  public void TapDecisionCancel()
  {
    groupDecision.SetActive(false);
    imgCurrentDecision.sprite = null;
    txtDecisionMessage.text = string.Empty;
    txtDecisionTitle.text = string.Empty;
  }

  public void TapNodeMiniChara(Text txt)
  {
    Debug.Log("TapNodeMiniChara " + txt.text);
    for (int ii = 0; ii < One.PlayerList.Count; ii++)
    {
      if (One.PlayerList[ii].FullName == txt.text)
      {
        this.CurrentPlayer = One.PlayerList[ii];
        break;
      }
    }
    UpdateActionCommandSetting(this.CurrentPlayer);
  }

  public void TapShopItem(NodeShopItem shopItem)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + shopItem.txtName.text);
    if (shopItem.ItemSell == false)
    {
      SelectShopItem(shopItem, ShopItemList);
    }
    else
    {
      Debug.Log("ShopSellItemList count: " + ShopSellItemList.Count.ToString());
      SelectShopItem(shopItem, ShopSellItemList);
    }
  }

  public void TapShopTypeBuyItem()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    GroupShopBuy.SetActive(true);
    GroupShopSell.SetActive(false);
    btnShopBuy.gameObject.SetActive(true);
    btnShopSell.gameObject.SetActive(false);
    txtShopCurrentType.text = Fix.SHOPMENU_BUY;
    bool result = FindAndSelectedShopItem(ShopItemList);
    if (result == false)
    {
      SetupItemDetailEmpty(null, imgItem, txtItemName, txtItemType, txtItemDesc, txtItemSTR, txtItemAGL, txtItemINT, txtItemSTM, txtItemMND, txtItemPA, txtItemPAMax, txtItemPD, txtItemMA, txtItemMAMax, txtItemMD, txtItemACC, txtItemSPD, txtItemRSP, txtItemPO, imgItemSTR, imgItemAGL, imgItemINT, imgItemSTM, imgItemMND, imgItemPA, imgItemPAMax, imgItemPD, imgItemMA, imgItemMAMax, imgItemMD, imgItemACC, imgItemSPD, imgItemRSP, imgItemPO);
    }
  }

  public void TapShopTypeSellItem()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    GroupShopBuy.SetActive(false);
    GroupShopSell.SetActive(true);
    btnShopBuy.gameObject.SetActive(false);
    btnShopSell.gameObject.SetActive(true);
    txtShopCurrentType.text = Fix.SHOPMENU_SELL;
    bool result = FindAndSelectedShopItem(ShopSellItemList);
    if (result == false)
    {
      SetupItemDetailEmpty(null, imgItem, txtItemName, txtItemType, txtItemDesc, txtItemSTR, txtItemAGL, txtItemINT, txtItemSTM, txtItemMND, txtItemPA, txtItemPAMax, txtItemPD, txtItemMA, txtItemMAMax, txtItemMD, txtItemACC, txtItemSPD, txtItemRSP, txtItemPO, imgItemSTR, imgItemAGL, imgItemINT, imgItemSTM, imgItemMND, imgItemPA, imgItemPAMax, imgItemPD, imgItemMA, imgItemMAMax, imgItemMD, imgItemACC, imgItemSPD, imgItemRSP, imgItemPO);
    }
  }

  public void TapSellItem(Text txt)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + txt.text);
    if (txt == null) { MessagePack.MessageX00009(ref QuestMessageList, ref QuestEventList); TapOK(); return; }
    if (txt.text == String.Empty || txt.text == "" || txt.text == null) { MessagePack.MessageX00009(ref QuestMessageList, ref QuestEventList); TapOK(); return; }

    Item current = new Item(txt.text);
    Debug.Log("itemSell ItemType: " + current.ItemType.ToString());
    imgSell.sprite = Resources.Load<Sprite>("Icon_" + current.ItemType.ToString());
    imgSell.name = txt.text;
    if (current.ImportantType == Item.Important.Precious)
    {
      txtSellTitle.text = txt.text + " は売却する事ができません。";
      txtSellMessage.text = txt.text + " は貴重品のため、売却することができません。";
      btnSellAccept.gameObject.SetActive(false);
      btnSellCancel.gameObject.SetActive(false);
      btnSellOK.gameObject.SetActive(true);
    }
    else
    {
      txtSellTitle.text = txt.text + " を売却しますか？";
      txtSellMessage.text = (current.Gold / 2).ToString()  + " Goldで売却した後、 " + txt.text + " を手元に戻す事はできません。";
      btnSellAccept.gameObject.SetActive(true);
      btnSellCancel.gameObject.SetActive(true);
      btnSellOK.gameObject.SetActive(false);
    }
    groupSellDecision.SetActive(true);
  }

  public void TapSellAccept()
  {
    Item current = new Item(imgSell.name);

    One.TF.DeleteBackpack(current, 1);
    One.TF.Gold += current.Gold / 2;

    RefreshAllView();
    TapSellCancel();
  }
  public void TapSellCancel()
  {
    groupSellDecision.SetActive(false);
    imgSell.sprite = null;
    txtSellTitle.text = string.Empty;
    txtSellMessage.text = string.Empty;
  }

  public void TapBuyItem(Text txt)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + txt.text);
    if (txt == null) { MessagePack.MessageX00010(ref QuestMessageList, ref QuestEventList); TapOK(); return; }
    if (txt.text == String.Empty || txt.text == "" || txt.text == null) { MessagePack.MessageX00010(ref QuestMessageList, ref QuestEventList); TapOK(); return; }

    Item current = new Item(txt.text);
    Debug.Log("itemBuy ItemType: " + current.ItemType.ToString());
    imgBuy.sprite = Resources.Load<Sprite>("Icon_" + current.ItemType.ToString());
    imgBuy.name = txt.text;
    if (One.TF.Gold < current.Gold)
    {
      int diff = current.Gold - One.TF.Gold;
      txtBuyTitle.text = txt.text + " を購入する事ができません。";
      txtBuyMessage.text = "ゴールドがあと" + diff.ToString() + " 不足しています。ゴールドを入手してください。";
      btnBuyAccept.gameObject.SetActive(false);
      btnBuyCancel.gameObject.SetActive(false);
      btnBuyOK.gameObject.SetActive(true);
    }
    else
    {
      txtBuyTitle.text = txt.text + " を購入しますか？";
      txtBuyMessage.text = current.Gold.ToString() + " ゴールドを消費します。この操作は元に戻せません。";
      btnBuyAccept.gameObject.SetActive(true);
      btnBuyCancel.gameObject.SetActive(true);
      btnBuyOK.gameObject.SetActive(false);
    }
    groupBuyDecision.SetActive(true);
  }

  public void TapBuyAccept()
  {
    Item current = new Item(imgBuy.name);

    One.TF.AddBackPack(current);
    One.TF.Gold -= current.Gold;

    ConstructBackpackView();
    TapBuyCancel();
  }
  public void TapBuyCancel()
  {
    groupBuyDecision.SetActive(false);
    imgBuy.sprite = null;
    txtBuyTitle.text = string.Empty;
    txtBuyMessage.text = string.Empty;
  }

  public void TapSelectInn()
  {
    GroupInnDecision.SetActive(true);
  }

  public void TapSelectFood(Text sender)
  {
    this.txtFoodMenuTitle.text = sender.text;

    if (sender.text == Fix.FOOD_BALANCE_SET) { txtFoodMenuDesc.text = Fix.DESC_01; }
    if (sender.text == Fix.FOOD_LARGE_GOHAN_SET) { txtFoodMenuDesc.text = Fix.DESC_02; }
    if (sender.text == Fix.FOOD_TSIKARA_UDON) { txtFoodMenuDesc.text = Fix.DESC_03; }
    if (sender.text == Fix.FOOD_ZUNOU_FLY_SET) { txtFoodMenuDesc.text = Fix.DESC_04; }
    if (sender.text == Fix.FOOD_SPEED_SOBA) { txtFoodMenuDesc.text = Fix.DESC_05; }

    if (sender.text == Fix.FOOD_KATUCARRY) { txtFoodMenuDesc.text = Fix.DESC_11; }
    if (sender.text == Fix.FOOD_OLIVE_AND_ONION) { txtFoodMenuDesc.text = Fix.DESC_12; }
    if (sender.text == Fix.FOOD_INAGO_AND_TAMAGO) { txtFoodMenuDesc.text = Fix.DESC_13; }
    if (sender.text == Fix.FOOD_USAGI) { txtFoodMenuDesc.text = Fix.DESC_14; }
    if (sender.text == Fix.FOOD_SANMA) { txtFoodMenuDesc.text = Fix.DESC_15; }

    if (sender.text == Fix.FOOD_FISH_GURATAN) { txtFoodMenuDesc.text = Fix.DESC_21; }
    if (sender.text == Fix.FOOD_SEA_TENPURA) { txtFoodMenuDesc.text = Fix.DESC_22; }
    if (sender.text == Fix.FOOD_TRUTH_YAMINABE_1) { txtFoodMenuDesc.text = Fix.DESC_23; }
    if (sender.text == Fix.FOOD_OSAKANA_ZINGISKAN) { txtFoodMenuDesc.text = Fix.DESC_24; }
    if (sender.text == Fix.FOOD_RED_HOT_SPAGHETTI) { txtFoodMenuDesc.text = Fix.DESC_25; }

    if (sender.text == Fix.FOOD_HINYARI_YASAI) { txtFoodMenuDesc.text = Fix.DESC_31; }
    if (sender.text == Fix.FOOD_AZARASI_SHIOYAKI) { txtFoodMenuDesc.text = Fix.DESC_32; }
    if (sender.text == Fix.FOOD_WINTER_BEEF_CURRY) { txtFoodMenuDesc.text = Fix.DESC_33; }
    if (sender.text == Fix.FOOD_GATTURI_GOZEN) { txtFoodMenuDesc.text = Fix.DESC_34; }
    if (sender.text == Fix.FOOD_KOGOERU_DESSERT) { txtFoodMenuDesc.text = Fix.DESC_35; }

    if (sender.text == Fix.FOOD_BLACK_BUTTER_SPAGHETTI) { txtFoodMenuDesc.text = Fix.DESC_41; }
    if (sender.text == Fix.FOOD_KOROKORO_PIENUS_HAMBURG) { txtFoodMenuDesc.text = Fix.DESC_42; }
    if (sender.text == Fix.FOOD_PIRIKARA_HATIMITSU_STEAK) { txtFoodMenuDesc.text = Fix.DESC_43; }
    if (sender.text == Fix.FOOD_HUNWARI_ORANGE_TOAST) { txtFoodMenuDesc.text = Fix.DESC_44; }
    if (sender.text == Fix.FOOD_TRUTH_YAMINABE_2) { txtFoodMenuDesc.text = Fix.DESC_45; }
  }

  public void TapInnAccept(Text sender)
  {
    GroupInnDecision.SetActive(false);
    GroupInn.SetActive(false);
    One.TF.AlreadyRestInn = true;
    One.TF.AlreadyDungeon = false;
    One.TF.EscapeFromDungeon = false;
    One.TF.AlreadyPureCleanWater = false;

    MessagePack.MessageX00006(ref QuestMessageList, ref QuestEventList, sender.text);
    TapOK();
  }

  public void tapInnCancel()
  {
    GroupInnDecision.SetActive(false);
  }

  public void TapRestInn()
  {
    if (One.TF.AlreadyRestInn)
    {
      MessagePack.MessageX00002(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    ExecRestInn();

    MessagePack.MessageX00001(ref QuestMessageList, ref QuestEventList);
    TapOK();
  }

  private void ExecRestInn()
  {
    for (int ii = 0; ii < One.PlayerList.Count; ii++)
    {
      One.PlayerList[ii].MaxGain();
      One.PlayerList[ii].Dead = false;
    }
    One.TF.AlreadyRestInn = true;
    One.TF.AlreadyDungeon = false;
    One.TF.EscapeFromDungeon = false;
    One.TF.AlreadyPureCleanWater = false;

    One.TF.GameDay += 1;
    dayLabel.text = One.TF.GameDay.ToString() + "日目";

    RefreshAllView();
    this.GroupInn.SetActive(false);
  }

  public void TapQuestCompleted()
  {
    GroupQuestComplete.SetActive(false);

    if (DetectLvup.Count > 0)
    {
      QuestMessageList.Add("");
      QuestEventList.Add(MessagePack.ActionEvent.ViewLevelUpCharacter);
    }
    TapOK();
  }

  public void TapLevelUpCharacterCompleted()
  {
    GroupLvupCharacter.SetActive(false);

    if (DetectLvup.Count > 0)
    {
      QuestMessageList.Add("");
      QuestEventList.Add(MessagePack.ActionEvent.ViewLevelUpCharacter);
    }
    TapOK();
  }

  public void TapPartyPickEnter(Text src_txt)
  {
    Debug.Log(MethodInfo.GetCurrentMethod() + ": " + src_txt.text);

    // 未選択時は、キャラクターを選択
    if (TacticsPickupCharacter == null)
    {
      for (int ii = 0; ii < One.PlayerList.Count; ii++)
      {
        if (src_txt.text == One.PlayerList[ii].FullName)
        {
          TacticsPickupCharacter = One.PlayerList[ii];
          TacticsPickupPartyNumber = -1;
          objSelectCursor.SetActive(true);
          txtSelectCursor.text = One.PlayerList[ii].FullName;
          return;
        }
      }
      Debug.Log("TapPartyPickEnter cannot search playerlist...");
      return;
    }

    // 選択時は、パーティ内のキャラクターを選んでいる場合は、
    // 選択しているキャラクターを削除する。
    if (TacticsPickupPartyNumber >= 0)
    {
      PartyListClass[TacticsPickupPartyNumber].sprite = null;
      PartyListName[TacticsPickupPartyNumber].text = "(Empty)";
      PartyListLevel[TacticsPickupPartyNumber].text = "--";
      PartyListLife[TacticsPickupPartyNumber].text = "--";
      PartyListSTR[TacticsPickupPartyNumber].text = "--";
      PartyListAGL[TacticsPickupPartyNumber].text = "--";
      PartyListINT[TacticsPickupPartyNumber].text = "--";
      PartyListSTM[TacticsPickupPartyNumber].text = "--";
      PartyListMND[TacticsPickupPartyNumber].text = "--";
      foreach (Transform n in GroupPartyList[TacticsPickupPartyNumber].transform)
      {
        GameObject.Destroy(n.gameObject);
      }
    }

    UpdateStayListCheckMark();
    objSelectCursor.SetActive(false);
    TacticsPickupCharacter = null;
    TacticsPickupPartyNumber = -1;
  }
  public void TapPartyPickChoose(int num)
  {
    Debug.Log(MethodInfo.GetCurrentMethod() +  ": " + num.ToString());
    // 未選択時は、キャラクターを選択
    if (TacticsPickupCharacter == null)
    {
      for (int ii = 0; ii < One.PlayerList.Count; ii++)
      {
        if (PartyListName[num].text == One.PlayerList[ii].FullName)
        {
          TacticsPickupCharacter = One.PlayerList[ii];
          TacticsPickupPartyNumber = num;
          objSelectCursor.SetActive(true);
          txtSelectCursor.text = One.PlayerList[ii].FullName;
          return;
        }
      }
      Debug.Log(MethodInfo.GetCurrentMethod() + ": cannot search playerlist...");
      return;
    }

    // 反映先に既にキャラクターがある場合は、選択元を記憶する。
    Character current = null;
    if (PartyListName[num].text != null && PartyListName[num].text != String.Empty && PartyListName[num].text != "Character Name" && PartyListName[num].text != "(Empty)")
    {
      Debug.Log("swap PartyListName is " + PartyListName[num].text);

      for (int ii = 0; ii < One.PlayerList.Count; ii++)
      {
        if (PartyListName[num].text == One.PlayerList[ii].FullName)
        {
          current = One.PlayerList[ii];
          break;
        }
      }
    }

    // 選択しているキャラクターが既にパーティリストにある場合は、それを削除する。
    for (int ii = 0; ii < PartyListName.Count; ii++)
    {
      Debug.Log("PartyListName: " + PartyListName[ii].text + " TacticsPickupCharacter: " + TacticsPickupCharacter.FullName);
      if (PartyListName[ii].text == "Character Name" || PartyListName[ii].text == "(Empty")
      {
        continue;
      }

      if (TacticsPickupCharacter.FullName == PartyListName[ii].text)
      {
        PartyListClass[ii].sprite = null;
        PartyListName[ii].text = "(Empty)";
        PartyListLevel[ii].text = "--";
        PartyListLife[ii].text = "--";
        PartyListSTR[ii].text = "--";
        PartyListAGL[ii].text = "--";
        PartyListINT[ii].text = "--";
        PartyListSTM[ii].text = "--";
        PartyListMND[ii].text = "--";
        foreach (Transform n in GroupPartyList[ii].transform)
        {
          GameObject.Destroy(n.gameObject);
        }
        break;
      }
    }

    // 現在選択しているキャラクターを指定箇所に反映する。
    Debug.Log("Now setup TacticsPickupCharacter: " + num +  " " + TacticsPickupCharacter.FullName);
    PartyListClass[num].sprite = Resources.Load<Sprite>("Unit_" + TacticsPickupCharacter?.Job.ToString() ?? "");
    PartyListName[num].text = TacticsPickupCharacter.FullName;
    PartyListLevel[num].text = TacticsPickupCharacter.Level.ToString();
    PartyListLife[num].text = TacticsPickupCharacter.CurrentLife.ToString() + " / " + TacticsPickupCharacter.MaxLife.ToString();
    PartyListSTR[num].text = TacticsPickupCharacter.TotalStrength.ToString();
    PartyListAGL[num].text = TacticsPickupCharacter.TotalAgility.ToString();
    PartyListINT[num].text = TacticsPickupCharacter.TotalIntelligence.ToString();
    PartyListSTM[num].text = TacticsPickupCharacter.TotalStamina.ToString();
    PartyListMND[num].text = TacticsPickupCharacter.TotalMind.ToString();

    foreach (Transform n in GroupPartyList[num].transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    List<String> actionList = TacticsPickupCharacter.GetActionCommandList();
    for (int ii = 0; ii < actionList.Count; ii++)
    {
      NodeActionCommand instant = Instantiate(prefab_ActionCommand) as NodeActionCommand;
      instant.BackColor.color = TacticsPickupCharacter.BattleForeColor;
      instant.CommandName = actionList[ii];
      instant.name = actionList[ii];
      instant.OwnerName = TacticsPickupCharacter.FullName;
      instant.ActionButton.name = actionList[ii];
      instant.ActionButton.image.sprite = Resources.Load<Sprite>(actionList[ii]);

      //Debug.Log("TapPartyPickChoose: " + TacticsPickupCharacter.ActionCommandList[ii]);
      instant.transform.SetParent(GroupPartyList[num].transform);
      instant.gameObject.SetActive(true);
    }

    // 反映先のキャラクターと入れ替え情報があった場合、かつ
    // 選択元がStayListではない場合、入れ替えを行う。
    if (current != null && TacticsPickupPartyNumber >= 0)
    {
      Debug.Log("Detect current: " + TacticsPickupPartyNumber + " " + current.FullName);
      PartyListClass[TacticsPickupPartyNumber].sprite = Resources.Load<Sprite>("Unit_" + current?.Job.ToString() ?? "");
      PartyListName[TacticsPickupPartyNumber].text = current.FullName;
      PartyListLevel[TacticsPickupPartyNumber].text = current.Level.ToString();
      PartyListLife[TacticsPickupPartyNumber].text = current.CurrentLife.ToString() + " / " + current.MaxLife.ToString();
      PartyListSTR[TacticsPickupPartyNumber].text = current.TotalStrength.ToString();
      PartyListAGL[TacticsPickupPartyNumber].text = current.TotalAgility.ToString();
      PartyListINT[TacticsPickupPartyNumber].text = current.TotalIntelligence.ToString();
      PartyListSTM[TacticsPickupPartyNumber].text = current.TotalStamina.ToString();
      PartyListMND[TacticsPickupPartyNumber].text = current.TotalMind.ToString();

      foreach (Transform n in GroupPartyList[TacticsPickupPartyNumber].transform)
      {
        GameObject.Destroy(n.gameObject);
      }
      List<string> actionListCurrent = current.GetActionCommandList();
      for (int ii = 0; ii < actionListCurrent.Count; ii++)
      {
        NodeActionCommand instant = Instantiate(prefab_ActionCommand) as NodeActionCommand;
        instant.BackColor.color = current.BattleForeColor;
        instant.CommandName = actionListCurrent[ii];
        instant.name = actionListCurrent[ii];
        instant.OwnerName = current.FullName;
        instant.ActionButton.name = actionListCurrent[ii];
        instant.ActionButton.image.sprite = Resources.Load<Sprite>(actionListCurrent[ii]);

        Debug.Log("TapPartyPickChoose: " + actionListCurrent[ii]);
        instant.transform.SetParent(GroupPartyList[TacticsPickupPartyNumber].transform);
        instant.gameObject.SetActive(true);
      }
    }
    else
    {
      Debug.Log("Detect current: null...");
    }

    UpdateStayListCheckMark();
    objSelectCursor.SetActive(false);
    TacticsPickupCharacter = null;
    TacticsPickupPartyNumber = -1;
  }

  public void TapPartyCommand()
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
        HidePanelMessage.gameObject.SetActive(true);
        PanelTapMessage.gameObject.SetActive(true);

        // ブラックアウトしている画面から元に戻す。
        if (currentEvent == MessagePack.ActionEvent.ReturnToNormal)
        {
          this.objBlackOut.SetActive(false);
          continue; // 継続
        }
        // ブラックアウトする。
        else if (currentEvent == MessagePack.ActionEvent.HomeTownBlackOut)
        {
          this.objBlackOut.SetActive(true);
          continue; // 継続
        }
        // ゲームオーバー、タイトルへ
        else if (currentEvent == MessagePack.ActionEvent.DungeonBadEnd)
        {
          SceneDimension.JumpToTitle();
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
        // 画面にYES/NOメッセージを表示する。
        else if (currentEvent == MessagePack.ActionEvent.HomeTownYesNoMessageDisplay)
        {
          this.txtDecisionMessageTitle.text = currentMessage;
          this.txtDecisionMessageDescription.text = "【神秘の森】はダンジョンエリアとなります。全滅した場合はゴールドが失われます。";
          this.GroupDecisionMessage.SetActive(true);
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
          RefreshSelectAreaList();
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
          this.txtQCTitle.text = currentMessage;
          this.GroupQuestComplete.SetActive(true);

          //this.txtSystemMessage.text = currentMessage;
          //this.panelSystemMessage.SetActive(true);

          // todo
          if (currentMessage.Contains(Fix.QUEST_TITLE_1))
          {
            One.TF.QuestMain_Complete_00001 = true;

            int gainExp = 300;
            int gainGold = 1000;
            string gainItem = Fix.FINE_SWORD;
            int gainSoulFragment = 1;
            for (int jj = 0; jj < One.AvailableCharacters.Count; jj++)
            {
              if (One.AvailableCharacters[jj].Exp < One.AvailableCharacters[jj].GetNextExp())
              {
                One.AvailableCharacters[jj].GainExp(gainExp);
                if (One.AvailableCharacters[jj].Exp >= One.AvailableCharacters[jj].GetNextExp())
                {
                  One.AvailableCharacters[jj].BaseLife += 15;
                  One.AvailableCharacters[jj].BaseManaPoint += 6;
                  One.AvailableCharacters[jj].BaseSkillPoint += 0; // スキルポイントは原則上昇しない。
                  One.AvailableCharacters[jj].RemainPoint += 3;
                  One.AvailableCharacters[jj].SoulFragment += 1;

                  DetectLvup.Add(true);
                  DetectLvupTitle.Add(One.AvailableCharacters[jj].FullName + "がレベルアップしました！");
                  DetectLvupMaxLife.Add("最大ライフが 15 上昇した！");
                  DetectLvupMaxManaPoint.Add("最大マナが 6 上昇した！");
                  DetectLvupMaxSkillPoint.Add(""); // 最大スキルポイントが 0 上昇した！"); // スキルポイントは原則上昇しない。
                  DetectLvupRemainPoint.Add("コア・パラメタポイントを 3 獲得！");
                  DetectLvupSoulEssence.Add("ソウル・エッセンスポイントを 1 獲得！");
                  DetectLvupSpecial.Add("");
                }
              }
              One.AvailableCharacters[jj].SoulFragment += gainSoulFragment;
            }
            One.TF.Gold += gainGold;
            One.TF.AddBackPack(new Item(gainItem));

            this.txtQCGoldGain.text = gainGold.ToString() + " ゴールドを獲得しました！";
            this.txtQCExpGain.text = gainExp.ToString() + " 経験値を獲得しました！";
            this.txtQCItemGain.text = gainItem + " を獲得しました";
            this.txtQCSoulEssenceGain.text = "1 ソウル・エッセンスを獲得しました！";
          }
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
          RefreshAllView();
          return;
        }
        else if (currentEvent == MessagePack.ActionEvent.ViewLevelUpCharacter)
        {
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
              txtLvupMaxMana.text = DetectLvupMaxManaPoint[0];
              DetectLvupMaxManaPoint.RemoveAt(0);
            }
            if (DetectLvupMaxSkillPoint.Count > 0)
            {
              txtLvupMaxSkill.text = DetectLvupMaxSkillPoint[0];
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
          }
          GroupLvupCharacter.SetActive(true);
          return;
        }
        // 新しいメンバーを加える。
        else if (currentEvent == MessagePack.ActionEvent.HomeTownAddNewCharacter)
        {
          if (currentMessage.Contains(Fix.NAME_EONE_FULNEA))
          {
            One.TF.AvailableEoneFulnea = true;
            One.TF.BattlePlayer3 = Fix.NAME_EONE_FULNEA;
            One.ReInitializeCharacter(Fix.NAME_EONE_FULNEA);
          }
          else if (currentMessage.Contains(Fix.NAME_BILLY_RAKI))
          {
            One.TF.AvailableBillyRaki = true;
            One.TF.BattlePlayer4 = Fix.NAME_BILLY_RAKI;
            One.ReInitializeCharacter(Fix.NAME_BILLY_RAKI);
          }
          else if (currentMessage.Contains(Fix.NAME_ADEL_BRIGANDY))
          {
            One.TF.AvailableAdelBrigandy = true;
            One.ReInitializeCharacter(Fix.NAME_ADEL_BRIGANDY);
          }
          else if (currentMessage.Contains(Fix.NAME_SELMOI_RO))
          {
            One.TF.AvailableSelmoiRo = true;
            One.ReInitializeCharacter(Fix.NAME_SELMOI_RO);
          }

          List<Character> current = One.AvailableCharacters;
          for (int jj = 0; jj < current.Count; jj++)
          {
            if (current[jj].FullName == currentMessage)
            {
              NodeCharaView charaView = Instantiate(nodeCharaView) as NodeCharaView;
              CharaViewList.Add(charaView);
              CreateCharaView(contentCharacter, charaView, current[jj], CharaViewList.Count - 1);
              break;
            }
          }
          RefreshAllView();
          continue; // 継続
        }
        // アイテムの入手
        else if (currentEvent == MessagePack.ActionEvent.GetItem)
        {
          Debug.Log("event: " + currentEvent.ToString() + " " + currentMessage);
          One.TF.AddBackPack(new Item(currentMessage));
          ConstructBackpackView();
          continue; // 継続
        }
        // Goldの入手
        else if (currentEvent == MessagePack.ActionEvent.GetGold)
        {
          Debug.Log("event: " + currentEvent.ToString() + " " + currentMessage);
          One.TF.Gold += Convert.ToInt32(currentMessage);
          RefreshAllView();
          continue; // 継続
        }
        // 食事によるパラメタUP対象の更新
        else if (currentEvent == MessagePack.ActionEvent.HomeTownCallRequestFood)
        {
          List<Character> characters = One.AvailableCharacters;
          for (int jj = 0; jj < characters.Count; jj++)
          {
            // エリア０
            if (currentMessage == Fix.FOOD_BALANCE_SET)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_01_VALUE);
            }
            else if (currentMessage == Fix.FOOD_LARGE_GOHAN_SET)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_02_VALUE);
            }
            else if (currentMessage == Fix.FOOD_TSIKARA_UDON)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_03_VALUE);
            }
            else if (currentMessage == Fix.FOOD_ZUNOU_FLY_SET)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_04_VALUE);
            }
            else if (currentMessage == Fix.FOOD_SPEED_SOBA)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_05_VALUE);
            }

            // エリア１
            if (currentMessage == Fix.FOOD_KATUCARRY)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_11_VALUE);
            }
            else if (currentMessage == Fix.FOOD_OLIVE_AND_ONION)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_12_VALUE);
            }
            else if (currentMessage == Fix.FOOD_INAGO_AND_TAMAGO)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_13_VALUE);
            }
            else if (currentMessage == Fix.FOOD_USAGI)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_14_VALUE);
            }
            else if (currentMessage == Fix.FOOD_SANMA)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_15_VALUE);
            }

            // エリア２
            else if (currentMessage == Fix.FOOD_FISH_GURATAN)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_21_VALUE);
            }
            else if (currentMessage == Fix.FOOD_SEA_TENPURA)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_22_VALUE);
            }
            else if (currentMessage == Fix.FOOD_TRUTH_YAMINABE_1)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_23_VALUE);
            }
            else if (currentMessage == Fix.FOOD_OSAKANA_ZINGISKAN)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_24_VALUE);
            }
            else if (currentMessage == Fix.FOOD_RED_HOT_SPAGHETTI)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_25_VALUE);
            }

            // エリア３
            else if (currentMessage == Fix.FOOD_HINYARI_YASAI)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_31_VALUE);
            }
            else if (currentMessage == Fix.FOOD_AZARASI_SHIOYAKI)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_32_VALUE);
            }
            else if (currentMessage == Fix.FOOD_WINTER_BEEF_CURRY)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_33_VALUE);
            }
            else if (currentMessage == Fix.FOOD_GATTURI_GOZEN)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_34_VALUE);
            }
            else if (currentMessage == Fix.FOOD_KOGOERU_DESSERT)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_35_VALUE);
            }

            // エリア４
            else if (currentMessage == Fix.FOOD_BLACK_BUTTER_SPAGHETTI)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_41_VALUE);
            }
            else if (currentMessage == Fix.FOOD_KOROKORO_PIENUS_HAMBURG)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_42_VALUE);
            }
            else if (currentMessage == Fix.FOOD_PIRIKARA_HATIMITSU_STEAK)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_43_VALUE);
            }
            else if (currentMessage == Fix.FOOD_HUNWARI_ORANGE_TOAST)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_44_VALUE);
            }
            else if (currentMessage == Fix.FOOD_TRUTH_YAMINABE_2)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_45_VALUE);
            }
          }
          for (int jj = 0; jj < One.AvailableCharacters.Count; jj++)
          {
            One.AvailableCharacters[jj].MaxGain();
            One.AvailableCharacters[jj].Dead = false;
          }
          RefreshAllView();
          continue;
        }
        // 自動セーブを行う。
        else if (currentEvent == MessagePack.ActionEvent.AutoSaveWorldEnvironment)
        {
          One.AutoSaveTruthWorldEnvironment();
          continue;
        }
        // クエストビューの表示
        else if (currentEvent == MessagePack.ActionEvent.ViewQuestDisplay)
        {
          GroupDungeonPlayer.SetActive(true);
          GroupCharacter.SetActive(false);
          GroupBackpack.SetActive(false);
          GroupShopItem.SetActive(false);
          GroupActionCommandSetting.SetActive(false);
          GroupInn.SetActive(false);
          continue;
        }
        // 通常メッセージ表示（システムメッセージが出ている場合は消す）
        else if (currentEvent == MessagePack.ActionEvent.None)
        {
          this.panelSystemMessage.SetActive(false);
          this.txtQuestMessage.text = currentMessage;
          Debug.Log("ActionEvent.None: " + currentMessage);
          return;
        }
        // 最後のメッセージ表示。その後は即時終了。
        else if (currentEvent == MessagePack.ActionEvent.LastMessage)
        {
          this.panelSystemMessage.SetActive(false);
          this.txtQuestMessage.text = currentMessage;
          Debug.Log("ActionEvent.None: " + currentMessage);
        }
        // 宿屋による休憩だけを実行する。
        else if (currentEvent == MessagePack.ActionEvent.HomeTownExecRestInn)
        {
          ExecRestInn();
        }
        else
        {
          Debug.Log("Error: unknown QuestEvent: " + currentEvent.ToString() + " " + currentMessage);
          continue;
        }
      }
      else
      {
        Debug.Log("TapOK: Break it");
        break;
      }
    }

    // メッセージが無くなったら、元の画面に戻す。
    if (this.QuestMessageList.Count <= 0)
    {
      //this.GroupQuestMessage.SetActive(false);
      HidePanelMessage.gameObject.SetActive(false);
      PanelTapMessage.gameObject.SetActive(false);
      panelSystemMessage.SetActive(false);

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

  private void CharacterEatFood(Character player, int[] food_up_value)
  {
    player.StrengthFood = food_up_value[0];
    player.AgilityFood = food_up_value[1];
    player.IntelligenceFood = food_up_value[2];
    player.StaminaFood = food_up_value[3];
    player.MindFood = food_up_value[4];
  }

  /// <summary>
  /// バックパックアイテムを生成します。
  /// </summary>
  private void CreateBackpack(GameObject content, NodeBackpackItem node, string item_name, int item_num, int num)
  {
  }

  private void CreateACAttribute(GameObject content, NodeACAttribute node, int num)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + node.name);
    node.transform.SetParent(content.transform);
    node.gameObject.SetActive(true);
    //node.transform.SetParent(content.transform);
    //node.SetActive(true);

    const int WIDTH = 700;
    content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x + WIDTH, content.GetComponent<RectTransform>().sizeDelta.y);

    RectTransform rect = node.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    //rect.sizeDelta = new Vector2(0, 0);
    rect.localPosition = new Vector3(50 + num * WIDTH, 0, 0);
  }

  /// <summary>
  /// キャラクターデータ（基本）を画面に反映します。
  /// </summary>
  //private void UpdatePlayerListView(Character player, NodeCharaView charaView)
  //{
  //  charaView.txtName.text = player.FullName;
  //  charaView.txtLevel.text = player.Level.ToString();
  //  charaView.txtExp.text = player.Exp.ToString();
  //  float dx = (float)((float)player.Exp / (float)player.GetNextExp());
  //  charaView.imgExpGauge.rectTransform.localScale = new Vector2(dx, 1.0f);
  //  charaView.imgExpGauge.color = new Color(72.0f / 255.0f, 220.0f / 255.0f, 71.0f / 255.0f);
  //  if (dx >= 1.0f)
  //  {
  //    charaView.txtExp.text = "Level Up!";
  //    charaView.imgExpGauge.color = new Color(255.0f / 255.0f, 201.0f / 255.0f, 177.0f / 255.0f);
  //  }
  //  charaView.imgJobClass.sprite = Resources.Load<Sprite>("Unit_" + player?.Job.ToString() ?? "");

  //  charaView.txtLife.text = player.CurrentLife.ToString() + " / " + player.MaxLife.ToString();
  //  float dx_life = (float)((float)player.CurrentLife / (float)player.MaxLife);
  //  charaView.imgLifeGauge.rectTransform.localScale = new Vector2(dx_life, 1.0f);
  //  charaView.txtStrength.text = player.TotalStrength.ToString();
  //  charaView.txtAgility.text = player.TotalAgility.ToString();
  //  charaView.txtIntelligence.text = player.TotalIntelligence.ToString();
  //  charaView.txtStamina.text = player.TotalStamina.ToString();
  //  charaView.txtMind.text = player.TotalMind.ToString();
  //  charaView.txtMainWeapon.text = player.MainWeapon?.ItemName ?? "( 装備なし )";
  //  Item temp = new Item(player.MainWeapon?.ItemName);
  //  charaView.imgMainWeapon.sprite = Resources.Load<Sprite>("Icon_" + temp?.ItemType.ToString() ?? "");
  //  charaView.gameObject.SetActive(true);
  //}

  private void MoveTransform(GameObject obj, Transform dst)
  {
    foreach (Transform n in obj.transform)
    {
      n.transform.SetParent(dst.transform);
      break;
    }
  }

  private void UpdateActionCommandSetting(Character player)
  {
    txtACHeaderName.text = player.FullName;

    // コンテンツ内のparent設定を解放する。
    foreach (Transform n in ContentActionCommandSetting.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    //for (int ii = 0; ii < Fix.INFINITY; ii++)
    //{

    //    MoveTransform(ContentActionCommandSetting, EmptyGroup.transform);
    //    if (ContentActionCommandSetting.transform.childCount <= 0)
    //    {
    //        break;
    //    }
    //}

    // コンテンツ長さを初期化する。
    GameObject content = ContentActionCommandSetting;
    content.GetComponent<RectTransform>().sizeDelta = new Vector2(1, content.GetComponent<RectTransform>().sizeDelta.y);

    txtAttributeSoulFragment.text = player.SoulFragment.ToString();

    // 制限開放の分だけ、リスト生成する。
    List<NodeACAttribute> attributeList = new List<NodeACAttribute>();
    if (One.TF.AvailableAllCommand)
    {
      CreateACAttribute(attributeList, Fix.CommandAttribute.Fire);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Ice);
      CreateACAttribute(attributeList, Fix.CommandAttribute.HolyLight);
      CreateACAttribute(attributeList, Fix.CommandAttribute.DarkMagic);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Wind);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Earth);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Warrior);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Archer);
      CreateACAttribute(attributeList, Fix.CommandAttribute.MartialArts);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Rogue);
      CreateACAttribute(attributeList, Fix.CommandAttribute.WonderHermit);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Armorer);
      CreateACAttribute(attributeList, Fix.CommandAttribute.EnhanceForm);
      CreateACAttribute(attributeList, Fix.CommandAttribute.MysticForm);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Brave);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Vengeance);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Truth);
      CreateACAttribute(attributeList, Fix.CommandAttribute.Mindfulness);
    }
    else
    {
      if (One.TF.AvailableFirstCommand)
      {
        Debug.Log("Detect AvailableFirstCommand");
        NodeACAttribute current = Instantiate(NodeACAttribute) as NodeACAttribute;
        current.CommandAttribute = player.FirstCommandAttribute;
        CreateACAttribute(ContentActionCommandSetting, current, attributeList.Count);
        attributeList.Add(current);
      }
      if (One.TF.AvailableSecondCommand)
      {
        Debug.Log("Detect AvailableSecondCommand");
        NodeACAttribute current = Instantiate(NodeACAttribute) as NodeACAttribute;
        current.CommandAttribute = player.SecondCommandAttribute;
        CreateACAttribute(ContentActionCommandSetting, current, attributeList.Count);
        attributeList.Add(current);
      }
      if (One.TF.AvailableThirdCommand)
      {
        Debug.Log("Detect AvailableThirdCommand");
        NodeACAttribute current = Instantiate(NodeACAttribute) as NodeACAttribute;
        current.CommandAttribute = player.ThirdCommandAttribute;
        CreateACAttribute(ContentActionCommandSetting, current, attributeList.Count);
        attributeList.Add(current);
      }
    }

    // アクションコマンドリストを表示する。
    for (int ii = 0; ii < attributeList.Count; ii++)
    {
      List<string> attrList = ActionCommand.GetCommandList(attributeList[ii].CommandAttribute);
      List<int> attrPlus = ActionCommand.GetCommandPlus(CurrentPlayer, attributeList[ii].CommandAttribute);

      int totalValue = 0;
      for (int jj = 0; jj < attrPlus.Count; jj++)
      {
        totalValue += attrPlus[jj];
      }

      // トータル１以上であれば表示。それ以外はLOCKED表示とする。
//      if (totalValue > 0)
//      {
        Debug.Log("Detect totalValue: " + totalValue.ToString());
        attributeList[ii].lockPanel.SetActive(false);
        attributeList[ii].txtName.text = attributeList[ii].CommandAttribute.ToString();
        attributeList[ii].txtTotal.text = "Total Lv" + totalValue;
        attributeList[ii].background.color = ActionCommand.GetCommandColor(attributeList[ii].CommandAttribute);
        for (int jj = 0; jj < attributeList[ii].imgACElement.Count; jj++)
        {
          attributeList[ii].imgACElement[jj].sprite = Resources.Load<Sprite>(attrList[jj]);
        }
        for (int jj = 0; jj < attributeList[ii].txtACElement.Count; jj++)
        {
          attributeList[ii].txtACElement[jj].text = attrList[jj];
        }
        for (int jj = 0; jj < attributeList[ii].txtACPlus.Count; jj++)
        {
          if (attrPlus[jj] > 0)
          {
            attributeList[ii].ACLockPanel[jj].SetActive(false);
            attributeList[ii].txtACPlus[jj].text = "+" + attrPlus[jj].ToString();
          }
          else
          {
            attributeList[ii].txtACPlus[jj].text = String.Empty;
            //attributeList[ii].txtACElement[jj].text = ""; // 非公開にする必要性はない。
          }
        }
      //}
      //else
      //{
        Debug.Log("totalValue: " + totalValue.ToString() + " then, lockPanel on");
        //attributeList[ii].lockPanel.SetActive(true);
        //attributeList[ii].txtName.text = String.Empty;
        //attributeList[ii].txtTotal.text = String.Empty;
        //attributeList[ii].background.color = new Color(0.5f, 0.5f, 0.5f);
        //for (int jj = 0; jj < attributeList[ii].imgACElement.Count; jj++)
        //{
        //  attributeList[ii].imgACElement[jj].sprite = Resources.Load<Sprite>(Fix.STAY);
        //}
        //for (int jj = 0; jj < attributeList[ii].txtACElement.Count; jj++)
        //{
        //  attributeList[ii].txtACElement[jj].text = string.Empty;
        //}
        //for (int jj = 0; jj < attributeList[ii].txtACPlus.Count; jj++)
        //{
        //  attributeList[ii].txtACPlus[jj].text = string.Empty;
        //}
      //}
    }
  }

  private void CreateACAttribute(List<NodeACAttribute> list,  Fix.CommandAttribute attribute)
  {
    NodeACAttribute current = Instantiate(NodeACAttribute);
    current.CommandAttribute = attribute;
    CreateACAttribute(ContentActionCommandSetting, current, list.Count);
    list.Add(current);
  }

  private void CreateMiniCharaIcon(Character player)
  {
    NodeMiniChara miniChara = Instantiate(NodeMiniCharaIcon) as NodeMiniChara;
    miniChara.txtName.text = player.FullName;
    miniChara.gameObject.SetActive(true);
    miniChara.transform.SetParent(ContentMiniChara.transform);
  }

  private void CreateCharaView(GameObject content, NodeCharaView charaView, Character player, int num)
  {
    charaView.transform.SetParent(contentCharacter.transform);
    RectTransform rect = charaView.GetComponent<RectTransform>();
    int NODE_HEIGHT = 160;
    rect.anchoredPosition = new Vector2(0, 0);
    rect.sizeDelta = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, -5 - num * NODE_HEIGHT, 0);

    charaView.name = "CharaView_" + player.FullName;
    charaView.txtName.text = player.FullName;
    charaView.txtLevel.text = player.Level.ToString();
    charaView.txtExp.text = player.Exp.ToString();
    float dx = (float)((float)player.Exp / (float)player.GetNextExp());
    charaView.imgExpGauge.rectTransform.localScale = new Vector2(dx, 1.0f);
    charaView.imgExpGauge.color = new Color(72.0f / 255.0f, 220.0f / 255.0f, 255.0f / 255.0f);
    if (dx >= 1.0f)
    {
      charaView.txtExp.text = "Level Up!";
      charaView.imgExpGauge.color = new Color(255.0f / 255.0f, 201.0f / 255.0f, 177.0f / 255.0f);
    }
    charaView.imgJobClass.sprite = Resources.Load<Sprite>("Unit_" + player?.Job.ToString() ?? "");

    charaView.txtLife.text = player.CurrentLife.ToString() + " / " + player.MaxLife.ToString();
    float dx_life = (float)((float)player.CurrentLife / (float)player.MaxLife);
    charaView.imgLifeGauge.rectTransform.localScale = new Vector2(dx_life, 1.0f);

    charaView.txtManaPoint.text = player.CurrentManaPoint.ToString() + " / " + player.MaxManaPoint.ToString();
    float dx_mp = (float)((float)player.CurrentManaPoint / (float)player.MaxManaPoint);
    charaView.imgManaPointGauge.rectTransform.localScale = new Vector2(dx_mp, 1.0f);

    charaView.txtSkillPoint.text = player.CurrentSkillPoint.ToString() + " / " + player.MaxSkillPoint.ToString();
    float dx_sp = (float)((float)player.CurrentSkillPoint / (float)player.MaxSkillPoint);
    charaView.imgSkillPointGauge.rectTransform.localScale = new Vector2(dx_sp, 1.0f);

    charaView.txtStrength.text = player.TotalStrength.ToString();
    charaView.txtAgility.text = player.TotalAgility.ToString();
    charaView.txtIntelligence.text = player.TotalIntelligence.ToString();
    charaView.txtStamina.text = player.TotalStamina.ToString();
    charaView.txtMind.text = player.TotalMind.ToString();
    charaView.txtMainWeapon.text = player.MainWeapon?.ItemName ?? "( 装備なし )";
    Item temp = new Item(player.MainWeapon?.ItemName);
    charaView.imgMainWeapon.sprite = Resources.Load<Sprite>("Icon_" + temp?.ItemType.ToString() ?? "");
    charaView.gameObject.SetActive(true);

    const int HEIGHT = 170;
    content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x, content.GetComponent<RectTransform>().sizeDelta.y + HEIGHT);
  }

  private NodeShopItem CreateShopItem(GameObject content, Item item, int num, bool item_sell)
  {
    NodeShopItem shopItem = Instantiate(nodeShopItem) as NodeShopItem;

    shopItem.transform.SetParent(content.transform);
    shopItem.txtName.text = item.ItemName;
    shopItem.imgItem.sprite = Resources.Load<Sprite>("Icon_" + item?.ItemType.ToString() ?? "");
    shopItem.ItemSell = item_sell;
    if (item_sell)
    {
      shopItem.txtGold.text = (item.Gold / 2).ToString() + " Gold";
    }
    else
    {
      shopItem.txtGold.text = item.Gold.ToString() + " Gold";
    }
    shopItem.imgbackground.color = item.GetRareColor;
    shopItem.gameObject.SetActive(true);

    const int WIDTH = 160;
    RectTransform rect = shopItem.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    //rect.sizeDelta = new Vector2(0, 0);
    rect.localPosition = new Vector3(20 + num * WIDTH, 0, 0);
    content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x + WIDTH, content.GetComponent<RectTransform>().sizeDelta.y);

    return shopItem;
  }

  private void ConstructShopBuyView()
  {
    foreach (Transform n in contentShopItem.transform)
    {
      GameObject.Destroy(n.gameObject);
    }

    ShopItemList.Clear();
    List<Item> shopList = GetShopItem(One.TF.CurrentAreaName);
    for (int ii = 0; ii < shopList.Count; ii++)
    {
      ShopItemList.Add(CreateShopItem(contentShopItem, shopList[ii], ii, false));
    }
    contentShopItem.GetComponent<RectTransform>().sizeDelta = new Vector2(contentShopItem.GetComponent<RectTransform>().sizeDelta.x + 20, contentShopItem.GetComponent<RectTransform>().sizeDelta.y);
    if (ShopItemList.Count > 0)
    {
      SelectShopItem(ShopItemList[0], ShopItemList);
    }
  }

  private void ConstructShopSellView()
  {
    foreach (Transform n in contentSellBackpackItem.transform)
    {
      GameObject.Destroy(n.gameObject);
    }

    ShopSellItemList.Clear();
    List<Item> sellList = One.TF.BackpackList;
    for (int ii = 0; ii < sellList.Count; ii++)
    {
      ShopSellItemList.Add(CreateShopItem(contentSellBackpackItem, sellList[ii], ii, true));
    }
    contentSellBackpackItem.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSellBackpackItem.GetComponent<RectTransform>().sizeDelta.x + 20, contentSellBackpackItem.GetComponent<RectTransform>().sizeDelta.y);

    Debug.Log("ShopSellItemList.Count: " + ShopSellItemList.Count);

    if (ShopSellItemList.Count > 0)
    {
      SelectShopItem(ShopSellItemList[0], ShopSellItemList);
    }
  }

  private void ConstructBackpackView()
  {
    foreach (Transform n in ContentBackpack.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    ContentBackpack.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    BackpackList.Clear();
    int counter = 0;
    for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
    {
      NodeBackpackItem current = Instantiate(nodeBackpackItem) as NodeBackpackItem;
      current.Construct(ContentBackpack, One.TF.BackpackList[ii].ItemName, One.TF.BackpackList[ii].StackValue, ii, counter);
      counter++;
      BackpackList.Add(current);
    }
  }

  private void ConstructBackpackJewelSocketView()
  {
    foreach (Transform n in ContentChangeJewelSocket.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    ContentChangeJewelSocket.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    BackpackJewelSocketList.Clear();
    int counter = 0;
    for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
    {
      if (CurrentPlayer.Equipable(Fix.EquipType.Artifact, One.TF.BackpackList[ii]))
      {
        NodeBackpackItem current = Instantiate(NodeBackpackItem_JeweSocket) as NodeBackpackItem;
        current.Construct(ContentChangeJewelSocket, One.TF.BackpackList[ii].ItemName, One.TF.BackpackList[ii].StackValue, ii, counter);
        counter++;
        BackpackJewelSocketList.Add(current);
      }
    }
  }

  private bool FindAndSelectedShopItem(List<NodeShopItem> shop_item_list)
  {
    for (int ii = 0; ii < shop_item_list.Count; ii++)
    {
      if (shop_item_list[ii].imgSelect.gameObject.activeInHierarchy)
      {
        Item item = new Item(shop_item_list[ii].txtName.text);
        SetupItemDetail(item, imgItem, txtItemName, txtItemType, txtItemDesc, txtItemSTR, txtItemAGL, txtItemINT, txtItemSTM, txtItemMND, txtItemPA, txtItemPAMax, txtItemPD, txtItemMA, txtItemMAMax, txtItemMD, txtItemACC, txtItemSPD, txtItemRSP, txtItemPO, imgItemSTR, imgItemAGL, imgItemINT, imgItemSTM, imgItemMND, imgItemPA, imgItemPAMax, imgItemPD, imgItemMA, imgItemMAMax, imgItemMD, imgItemACC, imgItemSPD, imgItemRSP, imgItemPO);
        txtItemGoldCost.text = One.TF.Gold.ToString();
        //if (txtShopCurrentType.text == Fix.SHOPMENU_BUY)
        //{
        //  txtItemGoldCost.text = item.Gold.ToString() + " Gold";
        //}
        //else
        //{
        //  txtItemGoldCost.text = (item.Gold / 2 ).ToString() + " Gold";
        //}
        return true;
      }
    }
    return false;
  }

  private void SelectShopItem(NodeShopItem shopItem, List<NodeShopItem> shop_item_list)
  {
    Item item = new Item(shopItem.txtName.text);

    for (int ii = 0; ii < shop_item_list.Count; ii++)
    {
      shop_item_list[ii].imgSelect.gameObject.SetActive(false);
    }
    shopItem.imgSelect.gameObject.SetActive(true);

    SetupItemDetail(item, imgItem, txtItemName, txtItemType, txtItemDesc, txtItemSTR, txtItemAGL, txtItemINT, txtItemSTM, txtItemMND, txtItemPA, txtItemPAMax, txtItemPD, txtItemMA, txtItemMAMax, txtItemMD, txtItemACC, txtItemSPD, txtItemRSP, txtItemPO, imgItemSTR, imgItemAGL, imgItemINT, imgItemSTM, imgItemMND, imgItemPA, imgItemPAMax, imgItemPD, imgItemMA, imgItemMAMax, imgItemMD, imgItemACC, imgItemSPD, imgItemRSP, imgItemPO);
    txtItemGoldCost.text = One.TF.Gold.ToString();
    //if (txtShopCurrentType.text == Fix.SHOPMENU_BUY)
    //{
    //  txtItemGoldCost.text = item.Gold.ToString() + " Gold";
    //}
    //else
    //{
    //  txtItemGoldCost.text = (item.Gold / 2).ToString() + " Gold";
    //}
  }

  private void SetupItemDetailEmpty(Item item, Image img_item,
                               Text txt_name, Text txt_type, Text txt_desc, Text txt_str, Text txt_agl, Text txt_int, Text txt_stm, Text txt_mnd,
                               Text txt_pa, Text txt_pa_max, Text txt_pd, Text txt_ma, Text txt_ma_max, Text txt_md, Text txt_acc, Text txt_spd, Text txt_rsp, Text txt_po,
                               Image img_str, Image img_agl, Image img_int, Image img_stm, Image img_mnd,
                               Image img_pa, Image img_pa_max, Image img_pd, Image img_ma, Image img_ma_max, Image img_md, Image img_acc, Image img_spd, Image img_rsp, Image img_po)
  {
    img_item.sprite = null;
    txt_name.text = "";
    txt_type.text = "";
    txt_desc.text = "";
    txt_str.text = "";
    txt_agl.text = "";
    txt_int.text = "";
    txt_stm.text = "";
    txt_mnd.text = "";
    txt_pa.text = "";
    txt_pa_max.text = "";
    txt_pd.text = "";
    txt_ma.text = "";
    txt_ma_max.text = "";
    txt_md.text = "";
    txt_acc.text = "";
    txt_spd.text = "";
    txt_rsp.text = "";
    txt_po.text = "";

    img_str.color = new Color(0.5f, 0.5f, 0.5f);
    img_agl.color = new Color(0.5f, 0.5f, 0.5f);
    img_int.color = new Color(0.5f, 0.5f, 0.5f);
    img_stm.color = new Color(0.5f, 0.5f, 0.5f);
    img_mnd.color = new Color(0.5f, 0.5f, 0.5f);
    img_pa.color = new Color(0.5f, 0.5f, 0.5f);
    img_pa_max.color = new Color(0.5f, 0.5f, 0.5f);
    img_pd.color = new Color(0.5f, 0.5f, 0.5f);
    img_ma.color = new Color(0.5f, 0.5f, 0.5f);
    img_ma_max.color = new Color(0.5f, 0.5f, 0.5f);
    img_md.color = new Color(0.5f, 0.5f, 0.5f);
    img_acc.color = new Color(0.5f, 0.5f, 0.5f);
    img_spd.color = new Color(0.5f, 0.5f, 0.5f);
    img_rsp.color = new Color(0.5f, 0.5f, 0.5f);
    img_po.color = new Color(0.5f, 0.5f, 0.5f);
  }

  private void SetupItemDetail(Item item, Image img_item,
                               Text txt_name, Text txt_type, Text txt_desc, Text txt_str, Text txt_agl, Text txt_int, Text txt_stm, Text txt_mnd,
                               Text txt_pa, Text txt_pa_max, Text txt_pd, Text txt_ma, Text txt_ma_max, Text txt_md, Text txt_acc, Text txt_spd, Text txt_rsp, Text txt_po,
                               Image img_str, Image img_agl, Image img_int, Image img_stm, Image img_mnd,
                               Image img_pa, Image img_pa_max, Image img_pd, Image img_ma, Image img_ma_max, Image img_md, Image img_acc, Image img_spd, Image img_rsp, Image img_po)
  {
    img_item.sprite = Resources.Load<Sprite>("Icon_" + item?.ItemType.ToString() ?? "");
    txt_name.text = item.ItemName;
    txt_type.text = item.ItemType_JP;
    txt_desc.text = item.Description;
    txt_str.text = item.Strength.ToString();
    txt_agl.text = item.Agility.ToString();
    txt_int.text = item.Intelligence.ToString();
    txt_stm.text = item.Stamina.ToString();
    txt_mnd.text = item.Mind.ToString();
    txt_pa.text = item.PhysicalAttack.ToString();
    txt_pa_max.text = item.PhysicalAttackMax.ToString();
    txt_pd.text = item.PhysicalDefense.ToString();
    txt_ma.text = item.MagicAttack.ToString();
    txt_ma_max.text = item.MagicAttackMax.ToString();
    txt_md.text = item.MagicDefense.ToString();
    txt_acc.text = item.BattleAccuracy.ToString();
    txt_spd.text = item.BattleSpeed.ToString();
    txt_rsp.text = item.BattleResponse.ToString();
    txt_po.text = item.Potential.ToString();

    img_str.color = (item.Strength <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(1.0f, 0, 0));
    img_agl.color = (item.Agility <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(0, 0, 1.0f));
    img_int.color = (item.Intelligence <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(125.0f / 255.0f, 0, 191.0f / 255.0f));
    img_stm.color = (item.Stamina <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(16.0f / 255.0f, 141.0f / 255.0f, 0));
    img_mnd.color = (item.Mind <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(1.0f, 1.0f, 0));
    img_pa.color = (item.PhysicalAttack <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(1.0f, 0, 0));
    img_pa_max.color = (item.PhysicalAttackMax <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(1.0f, 0, 0));
    img_pd.color = (item.PhysicalDefense <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(1.0f, 0, 0));
    img_ma.color = (item.MagicAttack <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(125.0f / 255.0f, 0, 191.0f / 255.0f));
    img_ma_max.color = (item.MagicAttackMax <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(125.0f / 255.0f, 0, 191.0f / 255.0f));
    img_md.color = (item.MagicDefense <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(125.0f / 255.0f, 0, 191.0f / 255.0f));
    img_acc.color = (item.BattleAccuracy <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(0, 0, 1.0f));
    img_spd.color = (item.BattleSpeed <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(0, 0, 1.0f));
    img_rsp.color = (item.BattleResponse <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(0, 0, 1.0f));
    img_po.color = (item.Potential <= 0 ? new Color(0.5f, 0.5f, 0.5f) : new Color(1.0f, 1.0f, 0));
  }

  public void TapQuestButton(Text txt)
  {
    // same DungeonField, HomeTown
    if (txt == null) { Debug.Log("TapQuestButton txt is null..."); return; }

    ViewQuestEvent(txt.text);
  }
  public void TapSelectAreaButton(Text txt)
  {
    ViewSelectAreaEvent(txt.text);
  }

  public void TapBackpackSelect(NodeBackpackItem backpack)
  {
    Debug.Log("TapBackpackSelect(S)");
    this.CurrentSelectBackpack = One.TF.BackpackList[backpack.BackpackNumber];

    for (int ii = 0; ii < BackpackList.Count; ii++)
    {
      Debug.Log("BackpackList: " + BackpackList[ii].txtName.text);
      BackpackList[ii].imgSelect.gameObject.SetActive(false);
    }
    backpack.imgSelect.gameObject.SetActive(true);
  }

  public void TapBackpackSelectJewelSocket(NodeBackpackItem backpack)
  {
    Debug.Log("TapBackpackSelectJewelSocket(S)");
    this.CurrentSelectJewelSocketItem = One.TF.BackpackList[backpack.BackpackNumber];

    for (int ii = 0; ii < BackpackJewelSocketList.Count; ii++)
    {
      Debug.Log("TapBackpackSelectJewelSocket: " + BackpackJewelSocketList[ii].txtName.text);
      BackpackJewelSocketList[ii].imgSelect.gameObject.SetActive(false);
    }
    backpack.imgSelect.gameObject.SetActive(true);
  }


  public void TapBackpackUse()
  {
    string current = (CurrentSelectBackpack?.ItemName ?? String.Empty);
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
        current == Fix.PERFECT_BLUE_POTION)
    {
      Debug.Log("CurrentSelectBackpack: " + current + " is not use in hometown, then no action.");
    }
  }

  public void TapBackpackDetail()
  {
    if (this.CurrentSelectBackpack != null)
    {
      SetupItemDetail(this.CurrentSelectBackpack, imgItemDetail, txtItemDetailName, txtItemDetailType, txtItemDetailDesc, txtItemDetailSTR, txtItemDetailAGL, txtItemDetailINT, txtItemDetailSTM, txtItemDetailMND, txtItemDetailPA, txtItemDetailPAMax, txtItemDetailPD, txtItemDetailMA, txtItemDetailMAMax, txtItemDetailMD, txtItemDetailACC, txtItemDetailSPD, txtItemDetailRSP, txtItemDetailPO, imgItemDetailSTR, imgItemDetailAGL, imgItemDetailINT, imgItemDetailSTM, imgItemDetailMND, imgItemDetailPA, imgItemDetailPAMax, imgItemDetailPD, imgItemDetailMA, imgItemDetailMAMax, imgItemDetailMD, imgItemDetailACC, imgItemDetailSPD, imgItemDetailRSP, imgItemDetailPO);
      btnJewelSocket.gameObject.SetActive(this.CurrentSelectBackpack.CanbeSocket1);
      GroupItemDetail.SetActive(true);
    }
  }

  public void TapBackpackDetailCancel()
  {
    GroupItemDetail.SetActive(false);
  }

  public void TapBackpackDelete()
  {
    imgDeleteItem.sprite = Resources.Load<Sprite>("Icon_" + this.CurrentSelectBackpack?.ItemType.ToString() ?? "");
    if (this.CurrentSelectBackpack.ImportantType == Item.Important.Precious)
    {
      txtDeleteTitle.text = this.CurrentSelectBackpack.ItemName + "は捨てる事が出来ません。";
      txtDeleteMessage.text = "";
      GroupDeleteDecision.SetActive(true);
      btnDelete.gameObject.SetActive(false);
      btnCancel.gameObject.SetActive(false);
      btnOK.gameObject.SetActive(true);
    }
    else
    {
      txtDeleteTitle.text = this.CurrentSelectBackpack.ItemName + "を捨てますか？";
      txtDeleteMessage.text = "バックパックから削除した場合、そのアイテムは二度と戻す事ができません。";
      GroupDeleteDecision.SetActive(true);
      btnDelete.gameObject.SetActive(true);
      btnCancel.gameObject.SetActive(true);
      btnOK.gameObject.SetActive(false);
    }
  }

  public void TapDeleteAccept()
  {
    GroupDeleteDecision.SetActive(false);

    if (this.CurrentSelectBackpack != null)
    {
      One.TF.RemoveItem(this.CurrentSelectBackpack);
    }
    ConstructBackpackView();
  }

  public void TapDeleteCancel()
  {
    GroupDeleteDecision.SetActive(false);
  }

  /// <summary>
  /// 対象のアイテムに宝玉ソケットを設定する画面を呼び出します。
  /// </summary>
  public void TapJewelSocket(Text sender)
  {
    Debug.Log("TapJewelSocket");

    RefreshJewelSocketView();

    GroupJewelSocket.SetActive(true);
  }

  public void TapCancelJewelSocket()
  {
    GroupJewelSocket.SetActive(false);
  }

  public void TapSelectJewelSocket(int num)
  {
    Debug.Log("TapEquipJewelSocket: " + num.ToString());

    this.CurrentSelectJewelSocketNumber = num;

    Item current = null;
    if (num == 0) { current = this.CurrentSelectBackpack.SocketedItem1; }
    else if (num == 1) { current = this.CurrentSelectBackpack.SocketedItem2; }
    else if (num == 2) { current = this.CurrentSelectBackpack.SocketedItem3; }
    else if (num == 3) { current = this.CurrentSelectBackpack.SocketedItem4; }
    else if (num == 4) { current = this.CurrentSelectBackpack.SocketedItem5; }

    if (current != null)
    {
      txtEquipJewelSocketName.text = current.ItemName;
      imgEquipJewelSocket.sprite = Resources.Load<Sprite>("Icon_" + current.ItemType.ToString());
    }
    else
    {
      txtEquipJewelSocketName.text = string.Empty;
      imgEquipJewelSocket.sprite = null;
    }

    // バックパックから装備可能なアイテムを設定
    ConstructBackpackJewelSocketView();

    GroupEquipJewelSocket.SetActive(true);
  }

  public void TapEquipJewelSocket_Equip(Text sender)
  {
    Debug.Log("CurrentSelectBackpack: " + CurrentSelectBackpack.ItemName);
    Debug.Log("CurrentSelectJewelSocketItem: " + CurrentSelectJewelSocketItem.ItemName);

    // 現在装備アイテムをバックパックに戻す。
    // 選択アイテムを装備する。
    if (this.CurrentSelectJewelSocketNumber == 0)
    {
      if (this.CurrentSelectBackpack.SocketedItem1 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem1);
      }
      this.CurrentSelectBackpack.SocketedItem1 = this.CurrentSelectJewelSocketItem;
    }
    else if (this.CurrentSelectJewelSocketNumber == 1)
    {
      if (this.CurrentSelectBackpack.SocketedItem2 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem2);
      }
      this.CurrentSelectBackpack.SocketedItem2 = this.CurrentSelectJewelSocketItem;
    }
    else if (this.CurrentSelectJewelSocketNumber == 2)
    {
      if (this.CurrentSelectBackpack.SocketedItem3 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem3);
      }
      this.CurrentSelectBackpack.SocketedItem3 = this.CurrentSelectJewelSocketItem;
    }
    else if (this.CurrentSelectJewelSocketNumber == 3)
    {
      if (this.CurrentSelectBackpack.SocketedItem4 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem4);
      }
      this.CurrentSelectBackpack.SocketedItem4 = this.CurrentSelectJewelSocketItem;
    }
    else if (this.CurrentSelectJewelSocketNumber == 4)
    {
      if (this.CurrentSelectBackpack.SocketedItem5 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem5);
      }
      this.CurrentSelectBackpack.SocketedItem5 = this.CurrentSelectJewelSocketItem;
    }

    // 選択アイテムをバックパックから削除する。
    One.TF.RemoveItem(this.CurrentSelectJewelSocketItem);

    // 宝玉ソケット用のバックパックを再反映する。
    ConstructBackpackJewelSocketView();

    // 宝玉ソケット画面を再反映する。
    RefreshJewelSocketView();
    RefreshAllView();

    GroupEquipJewelSocket.SetActive(false);
  }
  public void TapEquipJewelSocket_Detach()
  {
    Debug.Log("TapEquipJewelSocket_Detach: " + CurrentSelectBackpack.ItemName);

    // 現在装備アイテムをバックパックに戻す。
    // 現在装備を「装備なし」にする。
    if (this.CurrentSelectJewelSocketNumber == 0)
    {
      if (this.CurrentSelectBackpack.SocketedItem1 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem1);
      }
      this.CurrentSelectBackpack.SocketedItem1 = null;
    }
    else if (this.CurrentSelectJewelSocketNumber == 1)
    {
      if (this.CurrentSelectBackpack.SocketedItem2 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem2);
      }
      this.CurrentSelectBackpack.SocketedItem2 = null;
    }
    else if (this.CurrentSelectJewelSocketNumber == 2)
    {
      if (this.CurrentSelectBackpack.SocketedItem3 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem3);
      }
      this.CurrentSelectBackpack.SocketedItem3 = null;
    }
    else if (this.CurrentSelectJewelSocketNumber == 3)
    {
      if (this.CurrentSelectBackpack.SocketedItem4 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem4);
      }
      this.CurrentSelectBackpack.SocketedItem4 = null;
    }
    else if (this.CurrentSelectJewelSocketNumber == 4)
    {
      if (this.CurrentSelectBackpack.SocketedItem5 != null)
      {
        One.TF.AddBackPack(CurrentSelectBackpack.SocketedItem5);
      }
      this.CurrentSelectBackpack.SocketedItem5 = null;
    }

    // 宝玉ソケット用のバックパックを再反映する。
    ConstructBackpackJewelSocketView();

    // 宝玉ソケット画面を再反映する。
    RefreshJewelSocketView();
    RefreshAllView();

    GroupEquipJewelSocket.SetActive(false);
  }

  public void TapEquipJewelSocket_Cancel()
  {
    GroupEquipJewelSocket.SetActive(false);
  }

  public override void RefreshAllView()
  {
    // エリア情報
    txtArea.text = One.TF.CurrentAreaName;

    // DungeonPlayerのクエストリストを設定
    RefreshQuestList();
    // DungeonPlayerの行き先リストを設定
    RefreshSelectAreaList();

    // debug
    //for (int ii = 0; ii < Fix.QUEST_EVENT_TITLE.Count; ii++)
    //{
    //  NodeButton button = Instantiate(nodeButton) as NodeButton;
    //  button.gameObject.transform.SetParent(contentDungeonPlayer.transform);
    //  button.txtName.text = Fix.QUEST_EVENT_TITLE[ii];
    //  button.gameObject.SetActive(true);
    //  contentDungeonPlayer.GetComponent<RectTransform>().sizeDelta = new Vector2(contentDungeonPlayer.GetComponent<RectTransform>().sizeDelta.x, contentDungeonPlayer.GetComponent<RectTransform>().sizeDelta.y + 100);

    //  RectTransform rect = button.GetComponent<RectTransform>();
    //  rect.anchoredPosition = new Vector2(0, 0);
    //  rect.localPosition = new Vector3(0, -5 - ii * 100, 0);
    //}

    // メニューボタンの設定
    if (One.TF.AvailableTactics)
    {
      btnTactics.gameObject.SetActive(true);
      txtTactics.text = "Tactics";
    }
    else
    {
      btnTactics.gameObject.SetActive(false);
      txtTactics.text = string.Empty;
    }

    if (One.TF.AvailableSkillTree)
    {
      btnSkillTree.gameObject.SetActive(true);
      txtSkillTree.text = "Skill Tree";
    }
    else
    {
      btnSkillTree.gameObject.SetActive(false);
      txtSkillTree.text = string.Empty;
    }

    if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE)
    {
      btnCustomEvent1.gameObject.SetActive(true);
      txtCustomEvent1.text = "ファージル宮殿";
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE)
    {
      btnCustomEvent1.gameObject.SetActive(true);
      txtCustomEvent1.text = "船着き場";
      btnCustomEvent2.gameObject.SetActive(true);
      txtCustomEvent2.text = "街はずれ";
      btnCustomEvent3.gameObject.SetActive(false);
      txtCustomEvent3.text = string.Empty;
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN)
    {
      btnCustomEvent1.gameObject.SetActive(true);
      txtCustomEvent1.text = "長老の家";
      if (One.TF.Event_Message500022 == false)
      {
        btnCustomEvent2.gameObject.SetActive(false);
        txtCustomEvent2.text = string.Empty;
      }
      else
      {
        btnCustomEvent2.gameObject.SetActive(true);
        txtCustomEvent2.text = "神秘の森";
      }
      btnCustomEvent3.gameObject.SetActive(false);
      txtCustomEvent3.text = string.Empty;
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE)
    {
      btnCustomEvent1.gameObject.SetActive(true);
      txtCustomEvent1.text = "中央噴水広場";
      btnCustomEvent2.gameObject.SetActive(true);
      txtCustomEvent2.text = "ワッツの民芸品店";
      btnCustomEvent3.gameObject.SetActive(true);
      txtCustomEvent3.text = "占いの館：アミンダ";
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA)
    {
      btnCustomEvent1.gameObject.SetActive(true);
      txtCustomEvent1.text = "中央神殿";
      btnCustomEvent2.gameObject.SetActive(false);
      txtCustomEvent2.text = string.Empty;
      btnCustomEvent3.gameObject.SetActive(false);
      txtCustomEvent3.text = string.Empty;
    }

    // キャラクター情報を画面へ反映
    for (int ii = 0; ii < CharaViewList.Count; ii++)
    {
      if (CharaViewList[ii] != null)
      {
        Destroy(CharaViewList[ii].gameObject);
        CharaViewList[ii] = null;
      }
    }
    List<Character> currentList = One.AvailableCharacters;
    for (int ii = 0; ii < currentList.Count; ii++)
    {
      NodeCharaView charaView = Instantiate(nodeCharaView) as NodeCharaView;
      CharaViewList.Add(charaView);
      CreateCharaView(contentCharacter, charaView, currentList[ii], ii);
    }

    // チームのリソース(GoldやObsidianStone)を画面へ反映
    txtObsidianStone.text = One.TF.ObsidianStone.ToString();

    // バックパック情報を画面へ反映
    ConstructBackpackView();

    this.CurrentPlayer = One.PlayerList[0];

    // アクションコマンド設定情報を画面へ反映
    foreach (Transform n in ContentMiniChara.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    List<Character> available = One.AvailableCharacters;
    for (int ii = 0; ii < available.Count; ii++)
    {
      CreateMiniCharaIcon(available[ii]);
    }
    UpdateActionCommandSetting(this.CurrentPlayer);

    // ショップ画面の購入アイテムを設定
    ConstructShopBuyView();

    // ショップ画面で売却アイテムを設定
    ConstructShopSellView();

    // ショップ初期画面は購入画面を設定
    TapShopTypeBuyItem();

    // 食事メニュー
    List<string> listFoodMenu = GetFoodMenu(One.TF.CurrentAreaName);
    for (int ii = 0; ii < txtFoodMenuList.Count; ii++)
    {
      txtFoodMenuList[ii].text = String.Empty;
    }
    for (int ii = 0; ii < listFoodMenu.Count; ii++)
    {
      txtFoodMenuList[ii].text = listFoodMenu[ii];
    }
    TapSelectFood(txtFoodMenuList[0]);

    // Tacticsのリスト
    int counter = 0;
    for (int ii = 0; ii < StayListName.Count; ii++)
    {
      StayListName[ii].text = string.Empty;
    }
    for (int ii = 0; ii < StayListName.Count; ii++)
    {
      if (One.AvailableCharacterName(Fix.NAME_LIST[ii]))
      {
        StayListName[counter].text = Fix.NAME_LIST[ii];
        counter++;
      }
    }

    int num = 0;
    UpdateTacticsPartyMember(One.TF.BattlePlayer1, num); num++;
    UpdateTacticsPartyMember(One.TF.BattlePlayer2, num); num++;
    UpdateTacticsPartyMember(One.TF.BattlePlayer3, num); num++;
    UpdateTacticsPartyMember(One.TF.BattlePlayer4, num); num++;
    UpdateStayListCheckMark();

    // 背景と日数
    this.dayLabel.text = One.TF.GameDay.ToString() + "日目";
    if (One.TF.AlreadyRestInn)
    {
      this.firstDay = One.TF.GameDay - 1; // 休息したかどうかのフラグに関わらず町に訪れた最初の日を記憶します。
      if (this.firstDay <= 0) this.firstDay = 1; // [警告] 後編初日のロジック崩れによる回避手段。あまり良い直し方ではありません。
    }
    else
    {
      this.firstDay = One.TF.GameDay; // 休息したかどうかのフラグに関わらず町に訪れた最初の日を記憶します。
    }

    //if (GroundOne.DuelMode && GroundOne.enemyName1 == Database.VERZE_ARTIE)
    //{
    //  BlackOut();
    //  UpdateBackgroundData(Database.BaseResourceFolder + Database.BACKGROUND_FIELD_OF_FIRSTPLACE);
    //}
    if (One.TF.AlreadyRestInn == false)
    {
      UpdateBackgroundData(Fix.BACKGROUND_EVENING);
    }
    else
    {
      UpdateBackgroundData(Fix.BACKGROUND_MORNING);
    }

  }

  private void UpdateStayListCheckMark()
  {
    for (int ii = 0; ii < PartyListName.Count; ii++)
    {
      if (PartyListName[ii].text != "(Empty" && PartyListName[ii].text != String.Empty)
      {
        if (ii == 0) { One.TF.BattlePlayer1 = PartyListName[ii].text; }
        if (ii == 1) { One.TF.BattlePlayer2 = PartyListName[ii].text; }
        if (ii == 2) { One.TF.BattlePlayer3 = PartyListName[ii].text; }
        if (ii == 3) { One.TF.BattlePlayer4 = PartyListName[ii].text; }
      }
      else
      {
        if (ii == 0) { One.TF.BattlePlayer1 = string.Empty; }
        if (ii == 1) { One.TF.BattlePlayer2 = string.Empty; }
        if (ii == 2) { One.TF.BattlePlayer3 = string.Empty; }
        if (ii == 3) { One.TF.BattlePlayer4 = string.Empty; }
      }
    }

    for (int ii = 0; ii < StayListName.Count; ii++)
    {
      if (StayListName[ii].text == One.TF.BattlePlayer1 ||
          StayListName[ii].text == One.TF.BattlePlayer2 ||
          StayListName[ii].text == One.TF.BattlePlayer3 ||
          StayListName[ii].text == One.TF.BattlePlayer4)
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
          Character current = One.PlayerList[ii];
          PartyListClass[num].sprite = Resources.Load<Sprite>("Unit_" + current?.Job.ToString() ?? "");
          PartyListName[num].text = current.FullName;
          PartyListLevel[num].text = current.Level.ToString();
          PartyListLife[num].text = current.CurrentLife.ToString() + " / " + current.MaxLife.ToString();
          PartyListSTR[num].text = current.TotalStrength.ToString();
          PartyListAGL[num].text = current.TotalAgility.ToString();
          PartyListINT[num].text = current.TotalIntelligence.ToString();
          PartyListSTM[num].text = current.TotalStamina.ToString();
          PartyListMND[num].text = current.TotalMind.ToString();

          foreach (Transform n in GroupPartyList[num].transform)
          {
            GameObject.Destroy(n.gameObject);
          }
          List<string> actionList = current.GetActionCommandList();
          for (int jj = 0; jj < actionList.Count; jj++)
          {
            NodeActionCommand instant = Instantiate(prefab_ActionCommand) as NodeActionCommand;
            instant.BackColor.color = current.BattleForeColor;
            instant.CommandName = actionList[jj];
            instant.name = actionList[jj];
            instant.OwnerName = current.FullName;
            instant.ActionButton.name = actionList[jj];
            instant.ActionButton.image.sprite = Resources.Load<Sprite>(actionList[jj]);

            //Debug.Log("TapPartyPickChoose: " + TacticsPickupCharacter.ActionCommandList[jj]);
            instant.transform.SetParent(GroupPartyList[num].transform);
            instant.gameObject.SetActive(true);
          }
          break;
        }
      }
    }
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

  private void RefreshSelectAreaList()
  {
    foreach (Transform n in contentSelectArea.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    int counter = 0;
    //if (true) { AddSelectArea(Fix.TOWN_ANSHET, true, counter); counter++; }
    if (One.TF.QuestMain_00001) { AddSelectArea(Fix.DUNGEON_ESMILIA_GRASSFIELD, true, counter); counter++; }
    //if (One.TF.QuestMain_00002) { AddSelectArea(Fix.TOWN_FAZIL_CASTLE, true, counter); counter++; }
    if (One.TF.QuestMain_00002) { AddSelectArea(Fix.DUNGEON_GORATRUM_CAVE, true, counter); counter++; }
    //if (One.TF.Event_Message400030 && One.TF.AvailableBillyRaki) { AddSelectArea(Fix.TOWN_COTUHSYE, true, counter); counter++; }
    if (One.TF.Event_Message400030 && One.TF.AvailableBillyRaki) { AddSelectArea(Fix.DUNGEON_MYSTIC_FOREST, true, counter); counter++; }
    if (One.TF.Event_Message700050) { AddSelectArea(Fix.DUNGEON_OHRAN_TOWER, true, counter); counter++; }
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

  private void AddSelectArea(string select_area_name, bool available, int counter)
  {
    // same DungeonField, HomeTown
    NodeSelectAreaButton button = Instantiate(nodeSelectAreaButton) as NodeSelectAreaButton;
    button.gameObject.transform.SetParent(contentSelectArea.transform);
    button.txtName.text = select_area_name;
    if (available)
    {
      button.gameObject.SetActive(true);
    }
    else
    {
      button.imgFilter.gameObject.SetActive(true);
    }

    contentSelectArea.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSelectArea.GetComponent<RectTransform>().sizeDelta.x, contentSelectArea.GetComponent<RectTransform>().sizeDelta.y + 100);

    //ViewQuestEvent(select_area_name);

    RectTransform rect = button.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, -5 - counter * 100, 0);
  }

  public void ViewSelectAreaEvent(string select_area_name)
  {    // same DungeonField, HomeTown
    txtEventTitle.text = select_area_name;
    txtGoButton.text = "【 " +select_area_name + " 】へ向かう";
    this.DungeonMap = select_area_name;

    if (select_area_name == Fix.TOWN_ANSHET) { txtEventDescription.text = Fix.AREA_INFO_ANSHET; } 
    if (select_area_name == Fix.DUNGEON_ESMILIA_GRASSFIELD) { txtEventDescription.text = Fix.AREA_INFO_ESMILIA_GRASSFIELD; }
    if (select_area_name == Fix.TOWN_FAZIL_CASTLE) { txtEventDescription.text = Fix.AREA_INFO_FAZIL_CASTLE; }
    if (select_area_name == Fix.DUNGEON_GORATRUM_CAVE) { txtEventDescription.text = Fix.AREA_INFO_GORATRUM_CAVE; }
    if (select_area_name == Fix.TOWN_COTUHSYE) { txtEventDescription.text = Fix.AREA_INFO_COTUHSYE; }
    if (select_area_name == Fix.DUNGEON_MYSTIC_FOREST) { txtEventDescription.text = Fix.AREA_INFO_MYSTIC_FOREST; }
    if (select_area_name == Fix.DUNGEON_OHRAN_TOWER) { txtEventDescription.text = Fix.AREA_INFO_OHRAN_TOWER; }
  }
  
  private void ViewQuestEvent(string quest_name)
  {
    // same DungeonField, HomeTown
    txtEventTitle.text = quest_name;
    //txtGoButton.text = "GO";

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
    if (quest_name == Fix.QUEST_TITLE_21 && One.TF.Event_Message1100010)
    {
      txtEventDescription.text = Fix.QUEST_DESC_21_2;
    }
    if (quest_name == Fix.QUEST_TITLE_24 && One.TF.Event_Message2200020)
    {
      txtEventDescription.text = Fix.QUEST_DESC_24_2;
    }

    if (quest_name == Fix.QUEST_TITLE_22 && One.TF.Event_Message500022)
    {
      txtEventDescription.text = Fix.QUEST_DESC_22_2;
    }
  }

  private void RefreshJewelSocketView()
  {
    if (this.CurrentSelectBackpack != null)
    {
      Debug.Log("CurrentSelectBackpack: " + this.CurrentSelectBackpack.ItemName);
      Item current = this.CurrentSelectBackpack;
      txtJewelSocketName.text = current.ItemName;
      txtJewelSocketType.text = current.ItemType.ToString();
      imgJewelSocket.sprite = Resources.Load<Sprite>("Icon_" + current.ItemType.ToString());

      // ソケット１～５は芋プログラミングだが、良しとする。ただし、横展開概念が出た場合は要対処。
      // １つ目
      if (this.CurrentSelectBackpack.CanbeSocket1)
      {
        Item item = CurrentSelectBackpack.SocketedItem1;
        Image img = imgJewelSocketItem1;
        Text txt = txtJewelSocketItem1;
        if (item != null)
        {
          img.sprite = Resources.Load<Sprite>("Icon_" + item.ItemType.ToString());
          txt.text = item.ItemName;
        }
        else
        {
          img.sprite = null;
          txt.text = string.Empty;
        }
        lblJewelSocketItem1.text = "Jewel-Socket 1";
        objBlackout_1.SetActive(false);
        objJewelSocketItem1.GetComponent<Button>().interactable = true;
        objJewelSocketItem1.GetComponent<Outline>().enabled = true;
      }
      else
      {
        lblJewelSocketItem1.text = string.Empty;
        objBlackout_1.SetActive(true);
        objJewelSocketItem1.GetComponent<Button>().interactable = false;
        objJewelSocketItem1.GetComponent<Outline>().enabled = false;
      }

      // ２つ目
      if (this.CurrentSelectBackpack.CanbeSocket2)
      {
        Item item = CurrentSelectBackpack.SocketedItem2;
        Image img = imgJewelSocketItem2;
        Text txt = txtJewelSocketItem2;
        if (item != null)
        {
          img.sprite = Resources.Load<Sprite>("Icon_" + item.ItemType.ToString());
          txt.text = item.ItemName;
        }
        else
        {
          img.sprite = null;
          txt.text = string.Empty;
        }
        lblJewelSocketItem2.text = "Jewel-Socket 2";
        objBlackout_2.SetActive(false);
        objJewelSocketItem2.GetComponent<Button>().interactable = true;
        objJewelSocketItem2.GetComponent<Outline>().enabled = true;
      }
      else
      {
        lblJewelSocketItem2.text = string.Empty;
        objBlackout_2.SetActive(true);
        objJewelSocketItem2.GetComponent<Button>().interactable = false;
        objJewelSocketItem2.GetComponent<Outline>().enabled = false;
      }

      // ３つ目
      if (this.CurrentSelectBackpack.CanbeSocket3)
      {
        Item item = CurrentSelectBackpack.SocketedItem3;
        Image img = imgJewelSocketItem3;
        Text txt = txtJewelSocketItem3;
        if (item != null)
        {
          img.sprite = Resources.Load<Sprite>("Icon_" + item.ItemType.ToString());
          txt.text = item.ItemName;
        }
        else
        {
          img.sprite = null;
          txt.text = string.Empty;
        }
        lblJewelSocketItem3.text = "Jewel-Socket 3";
        objBlackout_3.SetActive(false);
        objJewelSocketItem3.GetComponent<Button>().interactable = true;
        objJewelSocketItem3.GetComponent<Outline>().enabled = true;
      }
      else
      {
        lblJewelSocketItem3.text = string.Empty;
        objBlackout_3.SetActive(true);
        objJewelSocketItem3.GetComponent<Button>().interactable = false;
        objJewelSocketItem3.GetComponent<Outline>().enabled = false;
      }

      // ４つ目
      if (this.CurrentSelectBackpack.CanbeSocket4)
      {
        Item item = CurrentSelectBackpack.SocketedItem4;
        Image img = imgJewelSocketItem4;
        Text txt = txtJewelSocketItem4;
        if (item != null)
        {
          img.sprite = Resources.Load<Sprite>("Icon_" + item.ItemType.ToString());
          txt.text = item.ItemName;
        }
        else
        {
          img.sprite = null;
          txt.text = string.Empty;
        }
        lblJewelSocketItem4.text = "Jewel-Socket 4";
        objBlackout_4.SetActive(false);
        objJewelSocketItem4.GetComponent<Button>().interactable = true;
        objJewelSocketItem4.GetComponent<Outline>().enabled = true;
      }
      else
      {
        lblJewelSocketItem4.text = string.Empty;
        objBlackout_4.SetActive(true);
        objJewelSocketItem4.GetComponent<Button>().interactable = false;
        objJewelSocketItem4.GetComponent<Outline>().enabled = false;
      }

      // ５つ目
      if (this.CurrentSelectBackpack.CanbeSocket5)
      {
        Item item = CurrentSelectBackpack.SocketedItem5;
        Image img = imgJewelSocketItem5;
        Text txt = txtJewelSocketItem5;
        if (item != null)
        {
          img.sprite = Resources.Load<Sprite>("Icon_" + item.ItemType.ToString());
          txt.text = item.ItemName;
        }
        else
        {
          img.sprite = null;
          txt.text = string.Empty;
        }
        lblJewelSocketItem5.text = "Jewel-Socket 5";
        objBlackout_5.SetActive(false);
        objJewelSocketItem5.GetComponent<Button>().interactable = true;
        objJewelSocketItem5.GetComponent<Outline>().enabled = true;
      }
      else
      {
        lblJewelSocketItem5.text = string.Empty;
        objBlackout_5.SetActive(true);
        objJewelSocketItem5.GetComponent<Button>().interactable = false;
        objJewelSocketItem5.GetComponent<Outline>().enabled = false;
      }

    }
  }
  #endregion

  #region "Menu Contents"
  private List<Item> GetShopItem(string area_name)
  {
    List<Item> shopList = new List<Item>();
    if (area_name == Fix.TOWN_ANSHET)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));
      shopList.Add(new Item(Fix.FINE_CLAW));
      shopList.Add(new Item(Fix.FINE_LANCE));
      shopList.Add(new Item(Fix.FINE_AXE));
      shopList.Add(new Item(Fix.FINE_BOW));
      shopList.Add(new Item(Fix.FINE_ORB));
      shopList.Add(new Item(Fix.FINE_BOOK));
      shopList.Add(new Item(Fix.FINE_ROD));
      shopList.Add(new Item(Fix.FINE_SHIELD));
      shopList.Add(new Item(Fix.FINE_ARMOR));
      shopList.Add(new Item(Fix.FINE_CROSS));
      shopList.Add(new Item(Fix.FINE_ROBE));
      shopList.Add(new Item(Fix.BLUE_WIZARD_HAT));
      shopList.Add(new Item(Fix.SWORD_OF_LIFE));
      shopList.Add(new Item(Fix.SMALL_RED_POTION));
      shopList.Add(new Item(Fix.SMALL_BLUE_POTION));
    }
    if (area_name == Fix.TOWN_FAZIL_CASTLE)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));
      shopList.Add(new Item(Fix.FINE_CLAW));
      shopList.Add(new Item(Fix.FINE_LANCE));
      shopList.Add(new Item(Fix.FINE_AXE));
      shopList.Add(new Item(Fix.FINE_BOW));
      shopList.Add(new Item(Fix.FINE_ORB));
      shopList.Add(new Item(Fix.FINE_BOOK));
      shopList.Add(new Item(Fix.FINE_ROD));
      shopList.Add(new Item(Fix.FINE_SHIELD));
      shopList.Add(new Item(Fix.FINE_ARMOR));
      shopList.Add(new Item(Fix.FINE_CROSS));
      shopList.Add(new Item(Fix.FINE_ROBE));
      shopList.Add(new Item(Fix.RED_PENDANT));
      shopList.Add(new Item(Fix.BLUE_PENDANT));
      shopList.Add(new Item(Fix.PURPLE_PENDANT));
      shopList.Add(new Item(Fix.GREEN_PENDANT));
      shopList.Add(new Item(Fix.YELLOW_PENDANT));
      shopList.Add(new Item(Fix.SWORD_OF_LIFE));
      shopList.Add(new Item(Fix.BLUE_WIZARD_HAT));
      shopList.Add(new Item(Fix.FLAME_HAND_KEEPER));
      shopList.Add(new Item(Fix.RED_PILLER_ORB));
      shopList.Add(new Item(Fix.MUIN_BOOK));
      shopList.Add(new Item(Fix.NORMAL_RED_POTION));
      shopList.Add(new Item(Fix.NORMAL_BLUE_POTION));

      //// todo
      //if (false)
      //{
      //  shopList.Add(new Item(Fix.FINE_LANCE));
      //  shopList.Add(new Item(Fix.FINE_AXE));
      //  shopList.Add(new Item(Fix.FINE_BOW));
      //  shopList.Add(new Item(Fix.FINE_ROD));
      //  shopList.Add(new Item(Fix.FINE_BOOK));
      //  //shopList.Add(new Item(Fix.BASTARD_SWORD));
      //  shopList.Add(new Item(Fix.AERO_BLADE));
      //  shopList.Add(new Item(Fix.GEAR_GENSEI));
      //  shopList.Add(new Item(Fix.MASTER_SWORD));
      //  shopList.Add(new Item(Fix.MASTER_SHIELD));
      //  shopList.Add(new Item(Fix.EDIL_BLACK_BLADE));
      //  shopList.Add(new Item(Fix.WHITE_PARGE_LANCE));
      //  shopList.Add(new Item(Fix.ICE_SPIRIT_LANCE));
      //}
    }
    else if (area_name == Fix.TOWN_COTUHSYE)
    {
      shopList.Add(new Item(Fix.SMART_SWORD));
      shopList.Add(new Item(Fix.SMART_CLAW));
      shopList.Add(new Item(Fix.SMART_LANCE));
      shopList.Add(new Item(Fix.SMART_AXE));
      shopList.Add(new Item(Fix.SMART_BOW));
      shopList.Add(new Item(Fix.SMART_ORB));
      shopList.Add(new Item(Fix.SMART_BOOK));
      shopList.Add(new Item(Fix.SMART_ROD));
      shopList.Add(new Item(Fix.SMART_SHIELD));
      shopList.Add(new Item(Fix.SMART_ARMOR));
      shopList.Add(new Item(Fix.SMART_CROSS));
      shopList.Add(new Item(Fix.RED_AMULET));
      shopList.Add(new Item(Fix.BLUE_AMULET));
      shopList.Add(new Item(Fix.PURPLE_AMULET));
      shopList.Add(new Item(Fix.GREEN_AMULET));
      shopList.Add(new Item(Fix.YELLOW_AMULET));
      shopList.Add(new Item(Fix.LARGE_RED_POTION));
      shopList.Add(new Item(Fix.LARGE_BLUE_POTION));
    }
    else if (area_name == Fix.TOWN_ZHALMAN)
    {
      shopList.Add(new Item(Fix.AERO_BLADE));
    }
    else if (area_name == Fix.TOWN_ARCANEDINE)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));

    }
    else if (area_name == Fix.TOWN_DALE)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));

    }
    else if (area_name == Fix.TOWN_ZELMAN)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));

    }
    return shopList;
  }

  public List<string> GetFoodMenu(string area_name)
  {
    List<string> foodList = new List<string>();
    if (area_name == Fix.TOWN_ANSHET)
    {
      foodList.Add(Fix.FOOD_BALANCE_SET);
      foodList.Add(Fix.FOOD_LARGE_GOHAN_SET);
      foodList.Add(Fix.FOOD_TSIKARA_UDON);
      foodList.Add(Fix.FOOD_ZUNOU_FLY_SET);
      foodList.Add(Fix.FOOD_SPEED_SOBA);
    }
    else if (area_name == Fix.TOWN_FAZIL_CASTLE)
    {
      foodList.Add(Fix.FOOD_KATUCARRY);
      foodList.Add(Fix.FOOD_OLIVE_AND_ONION);
      foodList.Add(Fix.FOOD_INAGO_AND_TAMAGO);
      foodList.Add(Fix.FOOD_USAGI);
      foodList.Add(Fix.FOOD_SANMA);
    }
    else if (area_name == Fix.TOWN_COTUHSYE)
    {
      foodList.Add(Fix.FOOD_FISH_GURATAN);
      foodList.Add(Fix.FOOD_SEA_TENPURA);
      foodList.Add(Fix.FOOD_TRUTH_YAMINABE_1);
      foodList.Add(Fix.FOOD_OSAKANA_ZINGISKAN);
      foodList.Add(Fix.FOOD_RED_HOT_SPAGHETTI);
    }
    else if (area_name == Fix.TOWN_ZHALMAN)
    {
      foodList.Add(Fix.FOOD_TOBIUSAGI_ROAST);
      foodList.Add(Fix.FOOD_WATARI_KAMONABE);
      foodList.Add(Fix.FOOD_SYOI_KINOKO_SUGATAYAKI);
      foodList.Add(Fix.FOOD_NEGIYAKI_DON);
      foodList.Add(Fix.FOOD_NANAIRO_BUNA_NITSUKE);
    }

    return foodList;
  }
  #endregion

  private void UpdateBackgroundData(string filename)
  {
    if (filename == null || filename == string.Empty || filename == "")
    {
      Debug.Log("filename == null || filename == string.Empty");
      return;
    }
    if (filename == Fix.BACKGROUND_MORNING)
    {
      this.backgroundData.sprite = Resources.Load<Sprite>( Fix.BACKGROUND_MORNING);
      this.backgroundData.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
      this.backgroundData.gameObject.SetActive(true);
    }
    else if (filename == Fix.BACKGROUND_EVENING)
    {
      this.backgroundData.sprite = Resources.Load<Sprite>(Fix.BACKGROUND_MORNING);
      this.backgroundData.color = new Color(191.0f / 255.0f, 139.0f / 255.0f, 25.0f / 255.0f, 1.0f);
      this.backgroundData.gameObject.SetActive(true);
    }
    else if (filename == Fix.BACKGROUND_NIGHT)
    {
      this.backgroundData.sprite = Resources.Load<Sprite>(Fix.BACKGROUND_MORNING);
      this.backgroundData.color = new Color(33.0f / 255.0f, 53.0f / 255.0f, 132.0f / 255.0f, 1.0f);
      this.backgroundData.gameObject.SetActive(true);
    }
    else
    {
      this.backgroundData.sprite = Resources.Load<Sprite>(filename);
      this.backgroundData.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
      this.backgroundData.gameObject.SetActive(true);
    }
  }
}