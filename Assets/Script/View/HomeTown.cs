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

  // MenuButton
  public Button btnParty;
  public Button btnBlueSphere;
  public Button btnSystem;

  // HomeTown
  public Image backgroundData;
  public Text dayLabel;
  public GameObject objBlackOut;
  public Text txtDate;
  public Text txtArea;
  public Text txtSoulFragment;
  public Text txtObsidianStone;
  public Text txtMessage;
  public Image imgTownIcon;

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
  //public List<Button> StayList;
  //public List<Text> StayListName;
  //public List<GameObject> StayListCheckMark;
  //public List<GameObject> GroupPartyList;
  //public List<GameObject> MemberIconList;
  //public List<Image> PartyListClass;
  //public List<Text> PartyListName;
  //public List<Text> PartyListLevel;
  //public List<Text> PartyListLife;
  //public List<Text> PartyListSTR;
  //public List<Text> PartyListAGL;
  //public List<Text> PartyListINT;
  //public List<Text> PartyListSTM;
  //public List<Text> PartyListMND;
  //public NodeActionCommand prefab_ActionCommand;
  //public GameObject objSelectCursor;
  //public Text txtSelectCursor;

  // Inn
  public GameObject GroupInn;
  public GameObject GroupInnDecision;
  public List<Text> txtFoodMenuList;
  public Text txtFoodMenuTitle;
  public Text txtFoodMenuDesc;
  public Text txtFoodMenuStrengthUp;
  public Text txtFoodMenuAgilityUp;
  public Text txtFoodMenuIntelligenceUp;
  public Text txtFoodMenuStaminaUp;
  public Text txtFoodMenuMindUp;

  // ItemBank
  public GameObject GroupItemBank;
  public GameObject ContentItemBank;
  public NodeBackpackItem nodeItemBankItem;

  // New Available
  public GameObject GroupNewAvailable;
  public Text txtNewTitle;
  public Text txtNewDescription;
  public Text txtCloseButton;

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

  public Button btnGameExit;

  // Inner Value
  protected List<bool> DetectLvup = new List<bool>();
  protected List<string> DetectLvupTitle = new List<string>();
  protected List<string> DetectLvupMaxLife = new List<string>();
  protected List<string> DetectLvupMaxManaPoint = new List<string>();
  protected List<string> DetectLvupMaxSkillPoint = new List<string>();
  protected List<string> DetectLvupRemainPoint = new List<string>();
  protected List<string> DetectLvupSoulEssence = new List<string>();
  protected List<string> DetectLvupSpecial = new List<string>();

  protected Character CurrentPlayer = null;
  protected Character ShadowPlayer = null;
  protected string CurrentItemType = String.Empty;

  protected List<string> QuestMessageList = new List<string>();
  protected List<MessagePack.ActionEvent> QuestEventList = new List<MessagePack.ActionEvent>();

  List<NodeShopItem> ShopItemList = new List<NodeShopItem>();
  List<NodeShopItem> ShopSellItemList = new List<NodeShopItem>();
  List<NodeBackpackItem> BackpackList = new List<NodeBackpackItem>();
  List<NodeBackpackItem> ItemBankList = new List<NodeBackpackItem>();
  List<NodeBackpackItem> BackpackJewelSocketList = new List<NodeBackpackItem>();

  protected Item CurrentSelectBackpack = null;
  protected Item CurrentSelectJewelSocketItem = null;
  protected int CurrentSelectJewelSocketNumber = 0;

  protected Item CurrentSelectItemBank = null;

  protected GameObject CurrentSelectHideACAttribute;

  protected List<string> contentSelectAreaList = new List<string>();
  protected List<string> contentDungeonPlayerList = new List<string>();

  protected string GetItemFail = string.Empty;
  protected string GetQuestItemFail = string.Empty;

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
  private bool AlreadyDetectEncount = false;
  private bool AlreadyDetectEncounted = false;
  private int MarginTimeForCallBattle = 30;
  bool ignoreCreateShadow = false;

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

    // 戦闘リトライ
    if (One.BattleEnd == Fix.GameEndType.Retry)
    {
      One.BattleEnd = Fix.GameEndType.None;
      One.CopyShadowToMain();
      this.ignoreCreateShadow = true;
      PrepareCallTruthBattleEnemy();
      //this.nowEncountEnemy = true;
      txtQuestMessage.text = "";
      txtMessage.text = "";
      return;
    }

    #region "オーランの塔の状態は全てリセットとする。"
    One.TF.FieldObject_OhranTower_00001 = false;
    One.TF.FieldObject_OhranTower_00002 = false;
    One.TF.FieldObject_OhranTower_00003 = false;
    One.TF.FieldObject_OhranTower_00004 = false;
    One.TF.FieldObject_OhranTower_00005 = false;
    One.TF.FieldObject_OhranTower_00006 = false;
    One.TF.FieldObject_OhranTower_00007 = false;
    One.TF.FieldObject_OhranTower_00008 = false;
    One.TF.FieldObject_OhranTower_00009 = false;
    One.TF.FieldObject_OhranTower_00010 = false;
    One.TF.FieldObject_OhranTower_00011 = false;
    One.TF.FieldObject_OhranTower_00012 = false;
    One.TF.FieldObject_OhranTower_00013 = false;
    One.TF.FieldObject_OhranTower_00014 = false;
    One.TF.FieldObject_OhranTower_00015 = false;
    One.TF.FieldObject_OhranTower_00016 = false;
    One.TF.FieldObject_OhranTower_00017 = false;
    One.TF.FieldObject_OhranTower_00018 = false;
    One.TF.FieldObject_OhranTower_00019 = false;
    One.TF.FieldObject_OhranTower_00020 = false;
    One.TF.FieldObject_OhranTower_00021 = false;
    One.TF.FieldObject_OhranTower_00022 = false;
    One.TF.FieldObject_OhranTower_00023 = false;
    One.TF.FieldObject_OhranTower_00024 = false;
    One.TF.FieldObject_OhranTower_00025 = false;
    One.TF.FieldObject_OhranTower_00026 = false;
    One.TF.FieldObject_OhranTower_00027 = false;
    One.TF.FieldObject_OhranTower_00028 = false;
    One.TF.FieldObject_OhranTower_00029 = false;
    One.TF.FieldObject_OhranTower_00030 = false;
    One.TF.FieldObject_OhranTower_00031 = false;
    One.TF.FieldObject_OhranTower_00032 = false;
    One.TF.FieldObject_OhranTower_00033 = false;
    One.TF.FieldObject_OhranTower_00034 = false;
    One.TF.FieldObject_OhranTower_00035 = false;
    One.TF.FieldObject_OhranTower_00036 = false;
    One.TF.FieldObject_OhranTower_00037 = false;
    One.TF.FieldObject_OhranTower_00038 = false;
    One.TF.FieldObject_OhranTower_00039 = false;
    One.TF.FieldObject_OhranTower_00040 = false;
    One.TF.FieldObject_OhranTower_00041 = false;
    One.TF.FieldObject_OhranTower_00042 = false;
    One.TF.FieldObject_OhranTower_00043 = false;
    One.TF.FieldObject_OhranTower_00044 = false;
    One.TF.FieldObject_OhranTower_00045 = false;
    One.TF.FieldObject_OhranTower_00046 = false;
    One.TF.FieldObject_OhranTower_00047 = false;
    One.TF.FieldObject_OhranTower_00048 = false;
    One.TF.FieldObject_OhranTower_00049 = false;
    One.TF.FieldObject_OhranTower_00050 = false;
    One.TF.FieldObject_OhranTower_00051 = false;
    One.TF.FieldObject_OhranTower_00052 = false;
    One.TF.FieldObject_OhranTower_00053 = false;
    One.TF.FieldObject_OhranTower_00054 = false;
    One.TF.FieldObject_OhranTower_00055 = false;
    One.TF.FieldObject_OhranTower_00056 = false;
    One.TF.FieldObject_OhranTower_00057 = false;
    One.TF.FieldObject_OhranTower_00058 = false;
    One.TF.FieldObject_OhranTower_00059 = false;
    One.TF.FieldObject_OhranTower_00060 = false;
    One.TF.FieldObject_OhranTower_00061 = false;
    One.TF.FieldObject_OhranTower_00062 = false;
    One.TF.FieldObject_OhranTower_00063 = false;
    One.TF.FieldObject_OhranTower_00064 = false;
    One.TF.FieldObject_OhranTower_00065 = false;
    One.TF.FieldObject_OhranTower_00066 = false;
    One.TF.FieldObject_OhranTower_00067 = false;
    One.TF.FieldObject_OhranTower_00068 = false;
    One.TF.FieldObject_OhranTower_00069 = false;
    One.TF.FieldObject_OhranTower_00070 = false;
    One.TF.FieldObject_OhranTower_00071 = false;
    One.TF.FieldObject_OhranTower_00072 = false;
    One.TF.FieldObject_OhranTower_00073 = false;
    One.TF.FieldObject_OhranTower_00074 = false;
    One.TF.FieldObject_OhranTower_00075 = false;
    One.TF.FieldObject_OhranTower_00076 = false;
    One.TF.FieldObject_OhranTower_00077 = false;
    One.TF.FieldObject_OhranTower_00078 = false;
    One.TF.FieldObject_OhranTower_00079 = false;
    One.TF.FieldObject_OhranTower_00080 = false;
    One.TF.FieldObject_OhranTower_00081 = false;
    One.TF.FieldObject_OhranTower_00082 = false;
    One.TF.FieldObject_OhranTower_00083 = false;
    One.TF.FieldObject_OhranTower_00084 = false;
    One.TF.FieldObject_OhranTower_00085 = false;
    One.TF.FieldObject_OhranTower_00086 = false;
    One.TF.FieldObject_OhranTower_00087 = false;
    One.TF.FieldObject_OhranTower_00088 = false;
    One.TF.FieldObject_OhranTower_00089 = false;
    One.TF.FieldObject_OhranTower_00090 = false;
    One.TF.FieldObject_OhranTower_00091 = false;
    One.TF.FieldObject_OhranTower_00092 = false;
    One.TF.FieldObject_OhranTower_00093 = false;
    One.TF.FieldObject_OhranTower_00094 = false;
    One.TF.FieldObject_OhranTower_00095 = false;
    One.TF.FieldObject_OhranTower_00096 = false;
    One.TF.FieldObject_OhranTower_00097 = false;
    One.TF.FieldObject_OhranTower_00098 = false;
    One.TF.FieldObject_OhranTower_00099 = false;
    One.TF.FieldObject_OhranTower_00100 = false;
    One.TF.FieldObject_OhranTower_00101 = false;
    One.TF.FieldObject_OhranTower_00102 = false;
    One.TF.FieldObject_OhranTower_00103 = false;
    One.TF.FieldObject_OhranTower_00104 = false;
    One.TF.FieldObject_OhranTower_00105 = false;
    One.TF.FieldObject_OhranTower_00106 = false;
    One.TF.FieldObject_OhranTower_00107 = false;
    One.TF.FieldObject_OhranTower_00108 = false;
    One.TF.FieldObject_OhranTower_00109 = false;
    One.TF.FieldObject_OhranTower_00110 = false;
    One.TF.FieldObject_OhranTower_00111 = false;
    One.TF.FieldObject_OhranTower_00112 = false;
    One.TF.FieldObject_OhranTower_00113 = false;
    One.TF.FieldObject_OhranTower_00114 = false;
    One.TF.FieldObject_OhranTower_00115 = false;
    One.TF.FieldObject_OhranTower_00116 = false;
    One.TF.FieldObject_OhranTower_00117 = false;
    One.TF.FieldObject_OhranTower_00118 = false;
    One.TF.FieldObject_OhranTower_00119 = false;
    One.TF.FieldObject_OhranTower_00120 = false;
    One.TF.FieldObject_OhranTower_00121 = false;
    One.TF.FieldObject_OhranTower_00122 = false;
    One.TF.FieldObject_OhranTower_00123 = false;
    One.TF.FieldObject_OhranTower_00124 = false;
    One.TF.FieldObject_OhranTower_00125 = false;
    One.TF.FieldObject_OhranTower_00126 = false;
    One.TF.FieldObject_OhranTower_00127 = false;
    One.TF.FieldObject_OhranTower_00128 = false;
    One.TF.FieldObject_OhranTower_00129 = false;
    #endregion

    // イベント進行

    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      if (One.TF.Event_Message2600001 == false)
      {
        One.TF.AvailableEinWolence = true;
        One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
        One.TF.CurrentAreaName = Fix.TOWN_ANSHET;
        One.TF.BeforeAreaName = Fix.TOWN_ANSHET;
        One.TF.SaveByDungeon = false;
        One.TF.AlreadyDungeon = false;
        One.TF.AlreadyRestInn = true;
        RefreshAllView();
        UpdateBackgroundData(Fix.BACKGROUND_MORNING);
        objBlackOut.SetActive(true);
        GroupQuestMessage.SetActive(true);
        MessagePack.Message2600001(ref QuestMessageList, ref QuestEventList); TapOK();
        One.UpdateAkashicRecord();
        One.RealWorldSave();
        return;
      }

      txtQuestMessage.text = "アイン：さて、何すっかな。";
      txtMessage.text = "アイン：さて、何すっかな。";
      return;
    }

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
      Debug.Log("Hometown: TOWN_FAZIL_CASTLE");
      if (One.TF.Event_Message100020 == false)
      {
        Debug.Log("Message100020");
        One.TF.Event_Message100020 = true;
        MessagePack.Message100020(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }

      // 港町コチューシェからの帰還
      if (One.TF.Event_Message500020 && One.TF.Event_Message700010 == false)
      {
        Debug.Log("Message700010");
        MessagePack.Message700010(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // オーランの塔制覇後の帰還
      if (One.TF.Event_Message800210 && One.TF.Event_Message800220 == false)
      {
        Debug.Log("Message800150");
        MessagePack.Message800150(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // パルメテイシア神殿へ始めて向かった時のDUEL戦闘後の帰還
      if (One.TF.DefeatSelmoiRo && One.TF.Event_Message2200000 == false)
      {
        MessagePack.Message2200000(ref QuestMessageList, ref QuestEventList); TapOK();
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
    else if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE)
    {
      if (One.TF.DefeatZatKon_1 && One.TF.EventCore_DefeatZatkon_1 == false)
      {
        One.TF.EventCore_DefeatZatkon_1 = true;
        MessagePack.CoreScenario_DefeatZatkon_2(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }
      else if (One.TF.DefeatZatKon_2 && One.TF.EventCore_DefeatZatkon_2 == false)
      {
        One.TF.EventCore_DefeatZatkon_2 = true;
        MessagePack.CoreScenario_DefeatZatkonEnd(ref QuestMessageList, ref QuestEventList);
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
    else if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA)
    {
      // ヴェルガス海底神殿、DUELエオネ戦闘後の帰還
      if (One.TF.Event_Message1010010 && One.TF.Event_Message1010020 == false)
      {
        MessagePack.Message1010020(ref QuestMessageList, ref QuestEventList); TapOK();
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
      Debug.Log("Update FirstAction Start");

      // １日目終了時
      if (this.firstDay >= 1 && One.TF.AlreadyDungeon && One.TF.AvailableImmediateAction == false)
      {
        Debug.Log("Duel this.firstDay >= 1 && One.TF.AlreadyDungeon && One.TF.AvailableImmediateAction == false");
        MessagePack.Message000190(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // Duel、ダミー・素振り君を倒した後
      if (One.TF.Duel_DummySuburi_Start && One.TF.DefeatDummySuburi && One.TF.Duel_DummySuburi_Complete == false)
      {
        Debug.Log("Duel DummySuburi defeated event");
        MessagePack.DuelCall_DummySuburi_Complete(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // Duel、エガルト・サンディを倒した後
      if (One.TF.Duel_EgaltSandy_Start && One.TF.DefeatEgaltSandy && One.TF.Duel_EgaltSandy_Complete == false)
      {
        Debug.Log("Duel EgaltSandy defeated event");
        MessagePack.DuelCall_EgaltSandy_Complete(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // Duel、カルマンズ・オーンを倒した後
      if (One.TF.Duel_CalmansOhn_Start && One.TF.DefeatCalmansOhn && One.TF.Duel_CalmansOhn_Complete == false)
      {
        Debug.Log("Duel CalmansOhn defeated event");
        MessagePack.DuelCall_CalmansOhn_Complete(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // Duel、シニキア・カールハンツを倒した後
      if (One.TF.Duel_ShinikiaKahlhanz_Start && One.TF.DefeatShinikiaKahlhanz && One.TF.Duel_ShinikiaKahlhanz_Complete == false)
      {
        Debug.Log("Duel Shinikia-Kahlhanz defeated event");
        MessagePack.DuelCall_ShinikiaKahlhanz_Complete(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      Debug.Log("Update through...");

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
      // パルメティシア神殿に到着直後
      if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA && One.TF.Event_Message2200010 == false)
      {
        MessagePack.Message2200010(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      // パルメティシア神殿、ヴェルガス海底神殿の？？？看板到達後
      if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA && One.TF.Event_Message1000081 == false)
      {
        MessagePack.Message1000081(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // ツァルマンの里、神秘の森から帰還
      if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN && One.TF.Event_Message500022 && One.TF.Event_EntryMysticForest && One.TF.Event_Message500024 == false)
      {
        MessagePack.Message500024(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // Duelレネ・コルトス撃破後
      if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN && One.TF.DefeatLeneColtos && One.TF.Duel_LeneColtos_Complete == false)
      {
        Debug.Log("Duel LeneColtos defeated event");
        MessagePack.DuelCall_LeneColtos_Complete(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      // オーランの塔、ObsidianStoneを入手後の強制帰還
      if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE && One.TF.InscribeObsidianStone_3 && One.TF.Event_Message801010 == false)
      {
        UpdateBackgroundData(Fix.BACKGROUND_NIGHT);
        MessagePack.Message801010(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
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

    if (this.DungeonCallComplete)
    {
      return;
    }
    if (this.DungeonCall != string.Empty && this.DungeonMap != string.Empty && this.DungeonCallComplete == false)
    {
      this.DungeonCallComplete = true;
      Debug.Log("DungeonCallComplete: " + this.DungeonCall + " " + this.DungeonMap);
      One.TF.BeforeAreaName = One.TF.CurrentAreaName;
      One.StopDungeonMusic();
      One.TF.CurrentDungeonField = this.DungeonMap;
      SceneDimension.JumpToDungeonField();
      return;
    }

    //if (this.objSelectCursor.activeInHierarchy)
    //{
    //  RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(),
    //                    Input.mousePosition, canvas.worldCamera, out this.mousePosition);
    //  RectTransform objRect = objSelectCursor.GetComponent<RectTransform>();
    //  objSelectCursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(mousePosition.x + objRect.sizeDelta.x + 10, mousePosition.y + objRect.sizeDelta.y + 10);
    //}
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
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      MessagePack.MessageX00014(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    One.SaveMode = true;
    One.AfterBacktoTitle = false;
    One.SaveAndExit = false;
    this.groupSaveLoad.SceneLoading();
    this.groupSaveLoad.gameObject.SetActive(true);
    //SceneDimension.CallSaveLoad(this, true, false);
  }

  public void TapLoad()
  {
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      MessagePack.MessageX00014(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    One.SaveMode = false;
    One.AfterBacktoTitle = false;
    One.SaveAndExit = false;
    this.groupSaveLoad.SceneLoading();
    this.groupSaveLoad.gameObject.SetActive(true);
    //SceneDimension.CallSaveLoad(this, false, false);
  }

  public void TapHelp()
  {
    Debug.Log(MethodBase.GetCurrentMethod() + "(S)");
    SceneDimension.SceneAdd(Fix.SCENE_HELP_BOOK);
  }

  public void TapExit()
  {
    One.UpdateAkashicRecord();
    One.RealWorldSave();
    SceneDimension.JumpToTitle();
    return;
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
  }

  public void TapFastTravel()
  {
    // todo 何らかのイベントでホームタウンで使えるシナリオを構築すること。
    MessagePack.MessageX00013(ref QuestMessageList, ref QuestEventList);
    TapOK();
  }

  public void TapDungeonPlayer()
  {
    if (One.TF.AlreadyDungeon)
    {
      MessagePack.MessageX00008(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

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

    RefreshSelectAreaList();

    GroupDungeonPlayer.SetActive(true);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupTactics.SetActive(false);
    GroupInn.SetActive(false);
    GroupItemBank.SetActive(false);
    int countArea = contentSelectAreaList.Count;
    if (countArea >= 1)
    {
      Debug.Log("ViewSelectAreaEvent call");
      ViewSelectAreaEvent(contentSelectAreaList[countArea - 1]);
      Debug.Log("ViewSelectAreaEvent call ok");
    }
    int countQuest = contentDungeonPlayerList.Count;
    Debug.Log("countQuest: " + countQuest);
    if (countQuest >= 1)
    {
      Debug.Log("ViewQuestEvent call");
      ViewQuestEvent(contentDungeonPlayerList[countQuest - 1]);
      Debug.Log("ViewQuestEvent call ok");
    }
    MessagePack.MessageX00016(ref QuestMessageList, ref QuestEventList); TapOK();
  }

  public void TapBackpack()
  {
    if (GroupBackpack.activeInHierarchy)
    {
      GroupBackpack.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupBackpack.SetActive(true);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupTactics.SetActive(false);
    GroupInn.SetActive(false);
    GroupItemBank.SetActive(false);
  }

  public void TapShop()
  {
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      MessagePack.Message2600002(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.Event_Message000010 == false)
    {
      // MessagePack.Message100015(ref QuestMessageList, ref QuestEventList); TapOK();
      // return;
    }

    if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET)
    {
    }

    if (One.TF.CurrentAreaName == Fix.TOWN_QVELTA_TOWN && One.TF.Event_Message200040 && One.TF.Event_Message200050 == false && One.TF.QuestMain_00010 && One.TF.QuestMain_Complete_00010 == false)
    {
      MessagePack.Message200050(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA)
    {
      if (One.TF.Event_Message2200020 == false)
      {
        MessagePack.Message2200011(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }

      if (One.TF.Event_Message2200021 == false)
      {
        MessagePack.Message2200021(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }

    if (GroupShopItem.activeInHierarchy)
    {
      GroupShopItem.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(true);
    GroupActionCommandSetting.SetActive(false);
    GroupTactics.SetActive(false);
    GroupInn.SetActive(false);
    GroupItemBank.SetActive(false);
    MessagePack.MessageX00015(ref QuestMessageList, ref QuestEventList); TapOK();

    CheckNewContents();
  }

  private void CheckNewContents()
  {
    #region "アンシェット街"
    if ((One.AR.EquipAvailable_11 == false) && (One.AR.EquipMixtureDay_11 != 0) && (One.TF.GameDay > One.AR.EquipMixtureDay_11))
    {
      One.AR.EquipAvailable_11 = true;
      AvailableNewContent(Fix.WOLF_CROSS, (new Item(Fix.WOLF_CROSS)).Description);
    }
    if ((One.AR.EquipAvailable_12 == false) && (One.AR.EquipMixtureDay_12 != 0) && (One.TF.GameDay > One.AR.EquipMixtureDay_12))
    {
      One.AR.EquipAvailable_12 = true;
      AvailableNewContent(Fix.KOUKAKU_ARMOR, (new Item(Fix.KOUKAKU_ARMOR)).Description);
    }
    if ((One.AR.EquipAvailable_13 == false) && (One.AR.EquipMixtureDay_13 != 0) && (One.TF.GameDay > One.AR.EquipMixtureDay_13))
    {
      One.AR.EquipAvailable_13 = true;
      AvailableNewContent(Fix.STRIDE_WAR_SWORD, (new Item(Fix.STRIDE_WAR_SWORD)).Description);
    }

    if ((One.AR.PotionAvailable_11 == false) && (One.AR.PotionMixtureDay_11 != 0) && (One.TF.GameDay > One.AR.PotionMixtureDay_11))
    {
      One.AR.PotionAvailable_11 = true;
      AvailableNewContent(Fix.POTION_RESIST_FIRE, (new Item(Fix.POTION_RESIST_FIRE).Description));
    }
    if ((One.AR.PotionAvailable_12 == false) && (One.AR.PotionMixtureDay_12 != 0) && (One.TF.GameDay > One.AR.PotionMixtureDay_12))
    {
      One.AR.PotionAvailable_12 = true;
      AvailableNewContent(Fix.CURE_SEAL, (new Item(Fix.CURE_SEAL).Description));
    }
    if ((One.AR.PotionAvailable_13 == false) && (One.AR.PotionMixtureDay_13 != 0) && (One.TF.GameDay > One.AR.PotionMixtureDay_13))
    {
      One.AR.PotionAvailable_13 = true;
      AvailableNewContent(Fix.POTION_MAGIC_SEAL, (new Item(Fix.POTION_MAGIC_SEAL).Description));
    }

    if ((One.AR.FoodAvailable_11 == false) && (One.AR.FoodMixtureDay_11 != 0) && (One.TF.GameDay > One.AR.FoodMixtureDay_11))
    {
      One.AR.FoodAvailable_11 = true;
      AvailableNewContent(Fix.FOOD_TSIKARA_UDON, Fix.DESC_03);
    }
    if ((One.AR.FoodAvailable_12 == false) && (One.AR.FoodMixtureDay_12 != 0) && (One.TF.GameDay > One.AR.FoodMixtureDay_12))
    {
      One.AR.FoodAvailable_12 = true;
      AvailableNewContent(Fix.FOOD_ZUNOU_FLY_SET, Fix.DESC_04);
    }
    if ((One.AR.FoodAvailable_13 == false) && (One.AR.FoodMixtureDay_13 != 0) && (One.TF.GameDay > One.AR.FoodMixtureDay_13))
    {
      One.AR.FoodAvailable_13 = true;
      AvailableNewContent(Fix.FOOD_SPEED_SOBA, Fix.DESC_05);
    }
    #endregion
    #region "ファージル宮殿"
    if ((One.AR.EquipAvailable_21 == false) && (One.AR.EquipMixtureDay_21 != 0) && (One.TF.GameDay > One.AR.EquipMixtureDay_21))
    {
      One.AR.EquipAvailable_21 = true;
      AvailableNewContent(Fix.DENDO_DRILL_AXE, (new Item(Fix.DENDO_DRILL_AXE)).Description);
    }
    if ((One.AR.EquipAvailable_22 == false) && (One.AR.EquipMixtureDay_22 != 0) && (One.TF.GameDay > One.AR.EquipMixtureDay_22))
    {
      One.AR.EquipAvailable_22 = true;
      AvailableNewContent(Fix.ATTACH_SPIRAL_ORB, (new Item(Fix.ATTACH_SPIRAL_ORB)).Description);
    }
    if ((One.AR.EquipAvailable_23 == false) && (One.AR.EquipMixtureDay_23 != 0) && (One.TF.GameDay > One.AR.EquipMixtureDay_23))
    {
      One.AR.EquipAvailable_23 = true;
      AvailableNewContent(Fix.THIN_STEEL_BUCKLER, (new Item(Fix.THIN_STEEL_BUCKLER)).Description);
    }
    if ((One.AR.EquipAvailable_24 == false) && (One.AR.EquipMixtureDay_24 != 0) && (One.TF.GameDay > One.AR.EquipMixtureDay_24))
    {
      One.AR.EquipAvailable_24 = true;
      AvailableNewContent(Fix.TETRA_EYE_BIGROD, (new Item(Fix.TETRA_EYE_BIGROD)).Description);
    }

    if ((One.AR.PotionAvailable_21 == false) && (One.AR.PotionMixtureDay_21 != 0) && (One.TF.GameDay > One.AR.PotionMixtureDay_21))
    {
      One.AR.PotionAvailable_21 = true;
      AvailableNewContent(Fix.POTION_RESIST_PLUS, (new Item(Fix.POTION_RESIST_PLUS).Description));
    }
    if ((One.AR.PotionAvailable_22 == false) && (One.AR.PotionMixtureDay_22 != 0) && (One.TF.GameDay > One.AR.PotionMixtureDay_22))
    {
      One.AR.PotionAvailable_22 = true;
      AvailableNewContent(Fix.TOTAL_HIYAKU_KASSEI, (new Item(Fix.TOTAL_HIYAKU_KASSEI).Description));
    }
    if ((One.AR.PotionAvailable_23 == false) && (One.AR.PotionMixtureDay_23 != 0) && (One.TF.GameDay > One.AR.PotionMixtureDay_23))
    {
      One.AR.PotionAvailable_23 = true;
      AvailableNewContent(Fix.TOTAL_HIYAKU_JOUSEI, (new Item(Fix.TOTAL_HIYAKU_JOUSEI).Description));
    }
    if ((One.AR.PotionAvailable_24 == false) && (One.AR.PotionMixtureDay_24 != 0) && (One.TF.GameDay > One.AR.PotionMixtureDay_24))
    {
      One.AR.PotionAvailable_24 = true;
      AvailableNewContent(Fix.PATERMA_DISMAGIC_DRINK, (new Item(Fix.PATERMA_DISMAGIC_DRINK).Description));
    }

    if ((One.AR.FoodAvailable_21 == false) && (One.AR.FoodMixtureDay_21 != 0) && (One.TF.GameDay > One.AR.FoodMixtureDay_21))
    {
      One.AR.FoodAvailable_21 = true;
      AvailableNewContent(Fix.FOOD_INAGO_AND_TAMAGO, Fix.DESC_13);
    }
    if ((One.AR.FoodAvailable_22 == false) && (One.AR.FoodMixtureDay_22 != 0) && (One.TF.GameDay > One.AR.FoodMixtureDay_22))
    {
      One.AR.FoodAvailable_22 = true;
      AvailableNewContent(Fix.FOOD_USAGI, Fix.DESC_14);
    }
    if ((One.AR.FoodAvailable_23 == false) && (One.AR.FoodMixtureDay_23 != 0) && (One.TF.GameDay > One.AR.FoodMixtureDay_23))
    {
      One.AR.FoodAvailable_23 = true;
      AvailableNewContent(Fix.FOOD_SANMA, Fix.DESC_15);
    }

    #endregion
    #region "港町コチューシェ"
    if ((One.AR.EquipAvailable_31 == false) && (One.AR.EquipMixtureDay_31 != 0) && (One.TF.GameDay > One.AR.EquipMixtureDay_31))
    {
      One.AR.EquipAvailable_31 = true;
      AvailableNewContent(Fix.SILENT_OLGA_CLAW, (new Item(Fix.SILENT_OLGA_CLAW)).Description);
    }
    if ((One.AR.EquipAvailable_32 == false) && (One.AR.EquipMixtureDay_32 != 0) && (One.TF.GameDay > One.AR.EquipMixtureDay_32))
    {
      One.AR.EquipAvailable_32 = true;
      AvailableNewContent(Fix.IRIDESCENT_CLOUD_FEATHER, (new Item(Fix.IRIDESCENT_CLOUD_FEATHER)).Description);
    }

    if ((One.AR.PotionAvailable_31 == false) && (One.AR.PotionMixtureDay_31 != 0) && (One.TF.GameDay > One.AR.PotionMixtureDay_31))
    {
      One.AR.PotionAvailable_31 = true;
      AvailableNewContent(Fix.SOUKAI_DRINK_SS, (new Item(Fix.SOUKAI_DRINK_SS).Description));
    }

    if ((One.AR.FoodAvailable_31 == false) && (One.AR.FoodMixtureDay_31 != 0) && (One.TF.GameDay > One.AR.FoodMixtureDay_31))
    {
      One.AR.FoodAvailable_31 = true;
      AvailableNewContent(Fix.FOOD_TRUTH_YAMINABE_1, Fix.DESC_23);
    }
    #endregion

    ConstructShopBuyView();
    ConstructFoodMenu();
  }

  private void AvailableNewContent(string content_name, string description)
  {
    this.txtNewTitle.text = content_name;
    this.txtNewDescription.text = description;
    this.txtCloseButton.text = "【 " + content_name + " 】が追加されました！";
    GroupNewAvailable.SetActive(true);
  }

  public void TapActionCommandSetting()
  {
    if (One.TF.Event_Message000010 == false)
    {
      // MessagePack.Message100015(ref QuestMessageList, ref QuestEventList);
      // TapOK();
      // return;
    }

    if (GroupActionCommandSetting.activeInHierarchy)
    {
      GroupActionCommandSetting.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(true);
    GroupTactics.SetActive(false);
    GroupInn.SetActive(false);
    GroupItemBank.SetActive(false);
  }

  public void TapTactics()
  {
    Debug.Log("TapTactics(S)");
    if (One.TF.Event_Message000010 == false)
    {
      // MessagePack.Message100015(ref QuestMessageList, ref QuestEventList);
      // TapOK();
      // return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(true);
    GroupTactics.SetActive(true);
    GroupInn.SetActive(false);
    GroupItemBank.SetActive(false);
  }

  public void TapCommunicationLana()
  {
    // debug only
    // MessagePack.CommunicationLana_0(ref QuestMessageList, ref QuestEventList); TapOK();
    // return;

    Debug.Log("TapCommunicationLana(S)");
    if (One.TF.Event_Message000010 == false)
    {
      MessagePack.Message100015(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.AlreadyCommunicate)
    {
      MessagePack.CommunicationLana_AlreadyCommunicate(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 2 && One.TF.CommunicationLana_1 == false)
    {
      MessagePack.CommunicationLana_1(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 4 && One.TF.CommunicationLana_2 == false)
    {
      MessagePack.CommunicationLana_2(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 6 && One.TF.CommunicationLana_3 == false)
    {
      MessagePack.CommunicationLana_3(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 8 && One.TF.CommunicationLana_4 == false)
    {
      MessagePack.CommunicationLana_4(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 10 && One.TF.CommunicationLana_5 == false)
    {
      MessagePack.CommunicationLana_5(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 13 && One.TF.CommunicationLana_6 == false)
    {
      MessagePack.CommunicationLana_6(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 16 && One.TF.CommunicationLana_7 == false)
    {
      MessagePack.CommunicationLana_7(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 19 && One.TF.CommunicationLana_8 == false)
    {
      MessagePack.CommunicationLana_8(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 22 && One.TF.CommunicationLana_9 == false)
    {
      MessagePack.CommunicationLana_9(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 25 && One.TF.CommunicationLana_10 == false)
    {
      MessagePack.CommunicationLana_10(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 29 && One.TF.CommunicationLana_11 == false)
    {
      MessagePack.CommunicationLana_11(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 33 && One.TF.CommunicationLana_12 == false)
    {
      MessagePack.CommunicationLana_12(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 37 && One.TF.CommunicationLana_13 == false)
    {
      MessagePack.CommunicationLana_13(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    if (One.TF.GameDay >= 41 && One.TF.CommunicationLana_14 == false)
    {
      MessagePack.CommunicationLana_14(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    MessagePack.CommunicationLana_NoEvent(ref QuestMessageList, ref QuestEventList);
    TapOK();
    return;
  }

  public void TapInn()
  {
    Debug.Log("TapInn(S)");
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false && One.TF.Event_Message2600003 == false)
    {
      MessagePack.Message2600002(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

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
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupInn.SetActive(true);
    GroupItemBank.SetActive(false);

    CheckNewContents();
  }

  public void TapItemBank()
  {
    Debug.Log("TapItemBank(S)");

    if (GroupItemBank.activeInHierarchy)
    {
      GroupItemBank.SetActive(false);
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupInn.SetActive(false);
    GroupItemBank.SetActive(true);

    // もしも１つでもあれば、初期でそれを選択状態にしておく。
    if (One.TF.ItemBankList.Count > 0)
    {
      NodeBackpackItem[] list = ContentItemBank.GetComponentsInChildren<NodeBackpackItem>();
      for (int ii = 0; ii < list.Length; ii++)
      {
        Debug.Log(" ii: " + ii.ToString() + " " + list[ii].txtName.text);
      }
      TapItemBankSelect(list[0]);
    }
  }

  public void TapCustomEvent1()
  {
    if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET)
    {
      if (One.TF.Event_Message000010 == false)
      {
        MessagePack.Message100015(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }

      if (One.AR.Record_EarringOfLana && One.AR.NormalEnding)
      {
        MessagePack.CoreScenario_ContactLana(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else if (One.TF.EventCore_ContactLana_NoAction == false)
      {
        MessagePack.CoreScenario_ContactLana_NoAction(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      // アンシェット街で始めてダミー・素振り君と対戦する時
      else if (One.TF.Duel_DummySuburi && One.TF.Duel_DummySuburi_Start == false)
      {
        MessagePack.DuelCall_DummySuburi_Start(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.MessageX00007(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
    }
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
        else if (One.TF.Event_Message800220 && One.TF.Event_Message700060 == false)
        {
          // オーランの塔制覇後の謁見
          MessagePack.Message700060(ref QuestMessageList, ref QuestEventList); TapOK();
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
        MessagePack.Message500020(ref QuestMessageList, ref QuestEventList, One.TF.EventCore_SeekMissingLink); TapOK();
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
      else if (One.TF.DefeatBighandKraken && One.TF.EventCore_AcknowledgeFeltus == false)
      {
        MessagePack.CoreScenario_AcknowledgeFeltus(ref QuestMessageList, ref QuestEventList); TapOK();
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
      else if (One.TF.FindBackPackItem(Fix.KIGAN_OFUDA) && One.TF.EventCore_SeekMissingLinkInn && One.TF.EventCore_SeekMissingLink == false)
      {
        MessagePack.CoreScenario_SeekMissingLink(ref QuestMessageList, ref QuestEventList); TapOK();
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
      if (One.TF.Event_Message500050 == false)
      {
        MessagePack.Message500050(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else if (One.TF.Event_Message500050 && One.TF.FindBackPackItem(Fix.MARBLE_STAR) && One.TF.Event_Message500060 == false)
      {
        MessagePack.Message500060(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        MessagePack.MessageX00007_2(ref QuestMessageList, ref QuestEventList); TapOK();
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

    if (One.TF.Event_Message801010 && One.TF.Event_Message700060 == false)
    {
      MessagePack.Message801020(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    // 行き先がホームタウンの場合
    if (this.DungeonMap == Fix.TOWN_ANSHET ||
      this.DungeonMap == Fix.TOWN_FAZIL_CASTLE ||
      this.DungeonMap == Fix.TOWN_COTUHSYE ||
      this.DungeonMap == Fix.TOWN_ZHALMAN ||
      this.DungeonMap == Fix.TOWN_ARCANEDINE ||
      this.DungeonMap == Fix.TOWN_PARMETYSIA ||
      this.DungeonMap == Fix.TOWN_DALE ||
      this.DungeonMap == Fix.TOWN_LATA_HOUSE ||
      this.DungeonMap == Fix.TOWN_FAZIL_UNDERGROUND)
    {
      // パルメティシア神殿へ向かう際、Duel遭遇
      if (this.DungeonMap == Fix.TOWN_PARMETYSIA && One.TF.Event_Message700060 && One.TF.Event_Message801030 == false)
      {
        MessagePack.Message801030(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      else
      {
        ChangeHometown(One.TF.CurrentAreaName, this.DungeonMap);
      }
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
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_MYSTIC_FOREST, 48.0f, 1.0f, -26.0f);
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_OHRAN_TOWER)
    {
      if (One.TF.Event_Message800220 && One.TF.Event_Message800230 == false)
      {
        MessagePack.Message700070(ref QuestMessageList, ref QuestEventList); TapOK();
      }
      else
      {
        // オーランの塔入口は1か所のため、分岐しない。
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_OHRAN_TOWER, 15.0f, 1.0f, -30.0f);
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_VELGUS_SEA_TEMPLE)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET ||
          One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE ||
          One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE ||
          One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN ||
          One.TF.CurrentAreaName == Fix.TOWN_ARCANEDINE ||
          One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA)
      {
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_VELGUS, 14.0f, 1.0f, -12.0f);
      }
      else
      {
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_VELGUS_SEA_TEMPLE_4)
    {
      CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_VELGUS_4, 26.0f, 1.0f, -15.0f);
    }
    else if (this.DungeonMap == Fix.DUNGEON_GATE_OF_DHAL)
    {
      if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET ||
          One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE ||
          One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE ||
          One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN ||
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
          One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN ||
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
      if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA && One.TF.Event_Message1010030 && One.TF.EventCore_AcknowledgeFeltus && One.TF.EventCore_ProphecySaga_Oracle == false)
      {
        MessagePack.CoreScenario_ProphecySaga_Oracle(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      // エデルガイゼン城へ向かった時、１F「扉３」を開放済みなら、Duel遭遇
      else if (One.TF.Event_Message1900094 && One.TF.Duel_ShinikiaKahlhanz_Start == false)
      {
        MessagePack.DuelCall_ShinikiaKahlhanz_Start(ref QuestMessageList, ref QuestEventList); TapOK();
        return;
      }
      else
      {
        CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_EDELGARZEN, 6.0f, 1.0f, -39.0f);
      }
    }
    else if (this.DungeonMap == Fix.DUNGEON_EDELGARZEN_CASTLE_CENTER)
    {
      CallDungeon(One.TF.CurrentAreaName, Fix.MAPFILE_EDELGARZEN, 30.0f, 1.0f, -39.0f);
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

    // ホームタウンからダンジョンに向かう時、全快していて欲しい。宿屋ではないが全快扱いとする。
    for (int ii = 0; ii < One.PlayerList.Count; ii++)
    {
      One.PlayerList[ii].MaxGain();
      One.PlayerList[ii].Dead = false;
    }

    One.TF.AlreadyDungeon = true;
    One.TF.AlreadyRestInn = false;
    One.TF.Field_X = x;
    One.TF.Field_Y = y;
    One.TF.Field_Z = z;
    One.TF.BeforeAreaName = source;
    One.StopDungeonMusic();
    One.TF.CurrentDungeonField = destination;
    SceneDimension.JumpToDungeonField();
    groupNowLoading.SetActive(true);
  }

  private void ChangeHometown(string source, string destination)
  {
    One.TF.AlreadyDungeon = false;
    One.TF.AlreadyRestInn = true;
    this.HomeTownComplete = true;
    One.TF.BeforeAreaName = source;
    One.TF.CurrentAreaName = destination;
    One.StopDungeonMusic();
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

  public void TapDecisionCancel()
  {
    groupDecision.SetActive(false);
    imgCurrentDecision.sprite = null;
    txtDecisionMessage.text = string.Empty;
    txtDecisionTitle.text = string.Empty;
  }

  public void TapNodeMiniChara(Text txt)
  {
    // todo リリースで削除する。
    //Debug.Log("TapNodeMiniChara " + txt.text);
    //for (int ii = 0; ii < One.PlayerList.Count; ii++)
    //{
    //  if (One.PlayerList[ii].FullName == txt.text)
    //  {
    //    this.CurrentPlayer = One.PlayerList[ii];
    //    break;
    //  }
    //}
    //UpdateActionCommandSetting(this.CurrentPlayer);
  }

  public void TapShopItem(NodeShopItem shopItem)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + shopItem.txtName.text);

    if (One.TF.Event_Message000010 == false)
    {
      // MessagePack.Message100015(ref QuestMessageList, ref QuestEventList); TapOK();
      // return;
    }

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
      txtSellMessage.text = (current.Gold / 2).ToString() + " Goldで売却した後、 " + txt.text + " を手元に戻す事はできません。";
      btnSellAccept.gameObject.SetActive(true);
      btnSellCancel.gameObject.SetActive(true);
      btnSellOK.gameObject.SetActive(false);
    }
    groupSellDecision.SetActive(true);
  }

  public void TapSellAccept()
  {
    Item current = new Item(imgSell.name);

    int stack = 1;
    One.TF.DeleteBackpack(current, stack);
    One.TF.Gold += current.Gold / 2;

    #region "アンシェット街"
    if (current.ItemName == Fix.COMMON_WOLF_FUR) { One.AR.EquipMaterial_11 += stack; }
    if (current.ItemName == Fix.COMMON_KOKYU_LETHER_MATERIAL) { One.AR.EquipMaterial_12 += stack; }
    if (One.AR.EquipMaterial_11 >= 1 && One.AR.EquipMaterial_12 >= 1 && One.AR.EquipMixtureDay_11 <= 0) { One.AR.EquipMixtureDay_11 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_KATAME_TREE) { One.AR.EquipMaterial_13 += stack; }
    if (current.ItemName == Fix.COMMON_WARM_NO_KOUKAKU) { One.AR.EquipMaterial_14 += stack; }
    if (One.AR.EquipMaterial_13 >= 1 && One.AR.EquipMaterial_14 >= 1 && One.AR.EquipMixtureDay_12 <= 0) { One.AR.EquipMixtureDay_12 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_TOGETOGE_GRASS) { One.AR.EquipMaterial_15 += stack; }
    if (current.ItemName == Fix.COMMON_HORSE_HIZUME) { One.AR.EquipMaterial_16 += stack; }
    if (One.AR.EquipMaterial_15 >= 1 && One.AR.EquipMaterial_16 >= 1 && One.AR.EquipMixtureDay_13 <= 0) { One.AR.EquipMixtureDay_13 = One.TF.GameDay; }

    if (current.ItemName == Fix.COMMON_MANTIS_TAIEKI) { One.AR.PotionMaterial_11 += stack; }
    if (current.ItemName == Fix.COMMON_MANDORAGORA_ROOT) { One.AR.PotionMaterial_12 += stack; }
    if (One.AR.PotionMaterial_11 >= 1 && One.AR.PotionMaterial_12 >= 1 && One.AR.PotionMixtureDay_11 <= 0) { One.AR.PotionMixtureDay_11 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_YELLOW_TAIEKI) { One.AR.PotionMaterial_13 += stack; }
    if (current.ItemName == Fix.COMMON_ORANGE_MATERIAL) { One.AR.PotionMaterial_14 += stack; }
    if (One.AR.PotionMaterial_13 >= 1 && One.AR.PotionMaterial_14 >= 1 && One.AR.PotionMixtureDay_12 <= 0) { One.AR.PotionMixtureDay_12 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_RED_HOUSI) { One.AR.PotionMaterial_15 += stack; }
    if (current.ItemName == Fix.COMMON_DOKUSO_NEEDLE) { One.AR.PotionMaterial_16 += stack; }
    if (One.AR.PotionMaterial_15 >= 1 && One.AR.PotionMaterial_16 >= 1 && One.AR.PotionMixtureDay_13 <= 0) { One.AR.PotionMixtureDay_13 = One.TF.GameDay; }

    if (current.ItemName == Fix.COMMON_GREEN_SIKISO) { One.AR.FoodMaterial_11 += stack; }
    if (current.ItemName == Fix.COMMON_ANT_ESSENCE) { One.AR.FoodMaterial_12 += stack; }
    if (One.AR.FoodMaterial_11 >= 1 && One.AR.FoodMaterial_12 >= 1 && One.AR.FoodMixtureDay_11 <= 0) { One.AR.FoodMixtureDay_11 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_SUN_LEAF) { One.AR.FoodMaterial_13 += stack; }
    if (current.ItemName == Fix.COMMON_RABBIT_MEAT) { One.AR.FoodMaterial_14 += stack; }
    if (One.AR.FoodMaterial_13 >= 1 && One.AR.FoodMaterial_14 >= 1 && One.AR.FoodMixtureDay_12 <= 0) { One.AR.FoodMixtureDay_12 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_ASH_EGG) { One.AR.FoodMaterial_15 += stack; }
    if (current.ItemName == Fix.COMMON_PLANTNOID_SEED) { One.AR.FoodMaterial_16 += stack; }
    if (One.AR.FoodMaterial_15 >= 1 && One.AR.FoodMaterial_16 >= 1 && One.AR.FoodMixtureDay_13 <= 0) { One.AR.FoodMixtureDay_13 = One.TF.GameDay; }
    #endregion
    #region "ファージル宮殿"
    if (current.ItemName == Fix.COMMON_MACHINE_PARTS) { One.AR.EquipMaterial_21 += stack; }
    if (current.ItemName == Fix.COMMON_SHARP_HAHEN) { One.AR.EquipMaterial_22 += stack; }
    if (One.AR.EquipMaterial_21 >= 1 && One.AR.EquipMaterial_22 >= 1 && One.AR.EquipMixtureDay_21 <= 0) { One.AR.EquipMixtureDay_21 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_GLASS_SHARD) { One.AR.EquipMaterial_23 += stack; }
    if (current.ItemName == Fix.COMMON_MECHANICAL_SHAFT) { One.AR.EquipMaterial_24 += stack; }
    if (One.AR.EquipMaterial_23 >= 1 && One.AR.EquipMaterial_24 >= 1 && One.AR.EquipMixtureDay_22 <= 0) { One.AR.EquipMixtureDay_22 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_USUGATA_ENBAN) { One.AR.EquipMaterial_25 += stack; }
    if (current.ItemName == Fix.COMMON_SOLIDSTONE_MATERIAL) { One.AR.EquipMaterial_26 += stack; }
    if (One.AR.EquipMaterial_25 >= 1 && One.AR.EquipMaterial_26 >= 1 && One.AR.EquipMixtureDay_23 <= 0) { One.AR.EquipMixtureDay_23 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_JUNK_PARTS) { One.AR.EquipMaterial_27 += stack; }
    if (current.ItemName == Fix.COMMON_SANKAKU_STEEL) { One.AR.EquipMaterial_28 += stack; }
    if (One.AR.EquipMaterial_27 >= 1 && One.AR.EquipMaterial_28 >= 1 && One.AR.EquipMixtureDay_24 <= 0) { One.AR.EquipMixtureDay_24 = One.TF.GameDay; }

    if (current.ItemName == Fix.COMMON_COLORFUL_BALL) { One.AR.PotionMaterial_21 += stack; }
    if (current.ItemName == Fix.COMMON_AMBER_MATERIAL) { One.AR.PotionMaterial_22 += stack; }
    if (One.AR.PotionMaterial_21 >= 1 && One.AR.PotionMaterial_22 >= 1 && One.AR.PotionMixtureDay_21 <= 0) { One.AR.PotionMixtureDay_21 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_HASSYADAI) { One.AR.PotionMaterial_23 += stack; }
    if (current.ItemName == Fix.COMMON_KYOUTEN_X) { One.AR.PotionMaterial_24 += stack; }
    if (One.AR.PotionMaterial_23 >= 1 && One.AR.PotionMaterial_24 >= 1 && One.AR.PotionMixtureDay_22 <= 0) { One.AR.PotionMixtureDay_22 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_ELECT_BOLT) { One.AR.PotionMaterial_25 += stack; }
    if (current.ItemName == Fix.COMMON_BUYOBUYO_MOEKASU) { One.AR.PotionMaterial_26 += stack; }
    if (One.AR.PotionMaterial_25 >= 1 && One.AR.PotionMaterial_26 >= 1 && One.AR.PotionMixtureDay_23 <= 0) { One.AR.PotionMixtureDay_23 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_SEKKAIKOU) { One.AR.PotionMaterial_27 += stack; }
    if (current.ItemName == Fix.COMMON_PURPLE_BOTTOLE) { One.AR.PotionMaterial_28 += stack; }
    if (One.AR.PotionMaterial_27 >= 1 && One.AR.PotionMaterial_28 >= 1 && One.AR.PotionMixtureDay_24 <= 0) { One.AR.PotionMixtureDay_24 = One.TF.GameDay; }

    if (current.ItemName == Fix.COMMON_BAT_FEATHER) { One.AR.FoodMaterial_21 += stack; }
    if (current.ItemName == Fix.COMMON_NEBARIKE_EKITAI) { One.AR.FoodMaterial_22 += stack; }
    if (One.AR.FoodMaterial_21 >= 1 && One.AR.FoodMaterial_22 >= 1 && One.AR.FoodMixtureDay_21 <= 0) { One.AR.FoodMixtureDay_21 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_GARGOYLE_EYE) { One.AR.FoodMaterial_23 += stack; }
    if (current.ItemName == Fix.COMMON_WATCHDOG_TONGUE) { One.AR.FoodMaterial_24 += stack; }
    if (One.AR.FoodMaterial_23 >= 1 && One.AR.FoodMaterial_24 >= 1 && One.AR.FoodMixtureDay_22 <= 0) { One.AR.FoodMixtureDay_22 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_BAKUHA_CHAKKAZAI) { One.AR.FoodMaterial_25 += stack; }
    if (current.ItemName == Fix.COMMON_CHROTIUM_MATERIAL) { One.AR.FoodMaterial_26 += stack; }
    if (One.AR.FoodMaterial_25 >= 1 && One.AR.FoodMaterial_26 >= 1 && One.AR.FoodMixtureDay_23 <= 0) { One.AR.FoodMixtureDay_23 = One.TF.GameDay; }

    #endregion
    #region "港町コチューシェ"
    if (current.ItemName == Fix.COMMON_NORMAL_SPORE_ESSENCE) { One.AR.EquipMaterial_31 += stack; }
    if (current.ItemName == Fix.COMMON_BEAR_LARGE_CLAW) { One.AR.EquipMaterial_32 += stack; }
    if (One.AR.EquipMaterial_31 >= 1 && One.AR.EquipMaterial_32 >= 1 && One.AR.EquipMixtureDay_31 <= 0) { One.AR.EquipMixtureDay_31 = One.TF.GameDay; }
    if (current.ItemName == Fix.COMMON_BEAUTY_WHITEFEATHER) { One.AR.EquipMaterial_33 += stack; }
    if (current.ItemName == Fix.COMMON_BLACK_MIST_ESSENCE) { One.AR.EquipMaterial_34 += stack; }
    if (One.AR.EquipMaterial_33 >= 1 && One.AR.EquipMaterial_34 >= 1 && One.AR.EquipMixtureDay_32 <= 0) { One.AR.EquipMixtureDay_32 = One.TF.GameDay; }

    if (current.ItemName == Fix.COMMON_MIST_LEAF) { One.AR.PotionMaterial_31 += stack; }
    if (current.ItemName == Fix.COMMON_SNAKE_EMPTYSHELL) { One.AR.PotionMaterial_32 += stack; }
    if (One.AR.PotionMaterial_31 >= 1 && One.AR.PotionMaterial_32 >= 1 && One.AR.PotionMixtureDay_31 <= 0) { One.AR.PotionMixtureDay_31 = One.TF.GameDay; }

    if (current.ItemName == Fix.COMMON_BOAR_MOMONIKU) { One.AR.FoodMaterial_31 += stack; }
    if (current.ItemName == Fix.COMMON_FROG_FRONTLEG) { One.AR.EquipMaterial_32 += stack; }
    if (One.AR.FoodMaterial_31 >= 1 && One.AR.EquipMaterial_32 >= 1 && One.AR.FoodMixtureDay_31 <= 0) { One.AR.FoodMixtureDay_31 = One.TF.GameDay; }

    #endregion

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

    bool success = One.TF.AddBackPack(current);
    if (success == false)
    {
      MessagePack.MessageX00015_2(ref QuestMessageList, ref QuestEventList); TapOK();
    }
    else
    {
      One.TF.Gold -= current.Gold;
      txtItemGoldCost.text = One.TF.Gold.ToString();
      MessagePack.MessageX00015_3(ref QuestMessageList, ref QuestEventList, current.ItemName, current.Gold); TapOK();
    }

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

    if (sender.text == Fix.FOOD_BALANCE_SET) { txtFoodMenuDesc.text = Fix.DESC_01_MINI; SetupFoodMenu(Fix.FOOD_01_VALUE); }
    if (sender.text == Fix.FOOD_LARGE_GOHAN_SET) { txtFoodMenuDesc.text = Fix.DESC_02_MINI; SetupFoodMenu(Fix.FOOD_02_VALUE); }
    if (sender.text == Fix.FOOD_TSIKARA_UDON) { txtFoodMenuDesc.text = Fix.DESC_03_MINI; SetupFoodMenu(Fix.FOOD_03_VALUE); }
    if (sender.text == Fix.FOOD_ZUNOU_FLY_SET) { txtFoodMenuDesc.text = Fix.DESC_04_MINI; SetupFoodMenu(Fix.FOOD_04_VALUE); }
    if (sender.text == Fix.FOOD_SPEED_SOBA) { txtFoodMenuDesc.text = Fix.DESC_05_MINI; SetupFoodMenu(Fix.FOOD_05_VALUE); }

    if (sender.text == Fix.FOOD_KATUCARRY) { txtFoodMenuDesc.text = Fix.DESC_11_MINI; SetupFoodMenu(Fix.FOOD_11_VALUE); }
    if (sender.text == Fix.FOOD_OLIVE_AND_ONION) { txtFoodMenuDesc.text = Fix.DESC_12_MINI; SetupFoodMenu(Fix.FOOD_12_VALUE); }
    if (sender.text == Fix.FOOD_INAGO_AND_TAMAGO) { txtFoodMenuDesc.text = Fix.DESC_13_MINI; SetupFoodMenu(Fix.FOOD_13_VALUE); }
    if (sender.text == Fix.FOOD_USAGI) { txtFoodMenuDesc.text = Fix.DESC_14_MINI; SetupFoodMenu(Fix.FOOD_14_VALUE); }
    if (sender.text == Fix.FOOD_SANMA) { txtFoodMenuDesc.text = Fix.DESC_15_MINI; SetupFoodMenu(Fix.FOOD_15_VALUE); }

    if (sender.text == Fix.FOOD_FISH_GURATAN) { txtFoodMenuDesc.text = Fix.DESC_21_MINI; SetupFoodMenu(Fix.FOOD_21_VALUE); }
    if (sender.text == Fix.FOOD_SEA_TENPURA) { txtFoodMenuDesc.text = Fix.DESC_22_MINI; SetupFoodMenu(Fix.FOOD_22_VALUE); }
    if (sender.text == Fix.FOOD_TRUTH_YAMINABE_1) { txtFoodMenuDesc.text = Fix.DESC_23_MINI; SetupFoodMenu(Fix.FOOD_23_VALUE); }
    if (sender.text == Fix.FOOD_OSAKANA_ZINGISKAN) { txtFoodMenuDesc.text = Fix.DESC_24_MINI; SetupFoodMenu(Fix.FOOD_24_VALUE); }
    if (sender.text == Fix.FOOD_RED_HOT_SPAGHETTI) { txtFoodMenuDesc.text = Fix.DESC_25_MINI; SetupFoodMenu(Fix.FOOD_25_VALUE); }

    if (sender.text == Fix.FOOD_TOBIUSAGI_ROAST) { txtFoodMenuDesc.text = Fix.DESC_31_MINI; SetupFoodMenu(Fix.FOOD_31_VALUE); }
    if (sender.text == Fix.FOOD_WATARI_KAMONABE) { txtFoodMenuDesc.text = Fix.DESC_32_MINI; SetupFoodMenu(Fix.FOOD_32_VALUE); }
    if (sender.text == Fix.FOOD_SYOI_KINOKO_SUGATAYAKI) { txtFoodMenuDesc.text = Fix.DESC_33_MINI; SetupFoodMenu(Fix.FOOD_33_VALUE); }
    if (sender.text == Fix.FOOD_NEGIYAKI_DON) { txtFoodMenuDesc.text = Fix.DESC_34_MINI; SetupFoodMenu(Fix.FOOD_34_VALUE); }
    if (sender.text == Fix.FOOD_NANAIRO_BUNA_NITSUKE) { txtFoodMenuDesc.text = Fix.DESC_35_MINI; SetupFoodMenu(Fix.FOOD_35_VALUE); }

    if (sender.text == Fix.FOOD_HINYARI_YASAI) { txtFoodMenuDesc.text = Fix.DESC_51_MINI; SetupFoodMenu(Fix.FOOD_51_VALUE); }
    if (sender.text == Fix.FOOD_AZARASI_SHIOYAKI) { txtFoodMenuDesc.text = Fix.DESC_52_MINI; SetupFoodMenu(Fix.FOOD_52_VALUE); }
    if (sender.text == Fix.FOOD_WINTER_BEEF_CURRY) { txtFoodMenuDesc.text = Fix.DESC_53_MINI; SetupFoodMenu(Fix.FOOD_53_VALUE); }
    if (sender.text == Fix.FOOD_GATTURI_GOZEN) { txtFoodMenuDesc.text = Fix.DESC_54_MINI; SetupFoodMenu(Fix.FOOD_54_VALUE); }
    if (sender.text == Fix.FOOD_KOGOERU_DESSERT) { txtFoodMenuDesc.text = Fix.DESC_55_MINI; SetupFoodMenu(Fix.FOOD_55_VALUE); }

    if (sender.text == Fix.FOOD_BLACK_BUTTER_SPAGHETTI) { txtFoodMenuDesc.text = Fix.DESC_61_MINI; SetupFoodMenu(Fix.FOOD_61_VALUE); }
    if (sender.text == Fix.FOOD_KOROKORO_PIENUS_HAMBURG) { txtFoodMenuDesc.text = Fix.DESC_62_MINI; SetupFoodMenu(Fix.FOOD_62_VALUE); }
    if (sender.text == Fix.FOOD_PIRIKARA_HATIMITSU_STEAK) { txtFoodMenuDesc.text = Fix.DESC_63_MINI; SetupFoodMenu(Fix.FOOD_63_VALUE); }
    if (sender.text == Fix.FOOD_HUNWARI_ORANGE_TOAST) { txtFoodMenuDesc.text = Fix.DESC_64_MINI; SetupFoodMenu(Fix.FOOD_64_VALUE); }
    if (sender.text == Fix.FOOD_TRUTH_YAMINABE_2) { txtFoodMenuDesc.text = Fix.DESC_65_MINI; SetupFoodMenu(Fix.FOOD_65_VALUE); }

  }

  private void SetupFoodMenu(int[] food_value)
  {
    txtFoodMenuStrengthUp.text = food_value[0].ToString();
    txtFoodMenuAgilityUp.text = food_value[1].ToString();
    txtFoodMenuIntelligenceUp.text = food_value[2].ToString();
    txtFoodMenuStaminaUp.text = food_value[3].ToString();
    txtFoodMenuMindUp.text = food_value[4].ToString();
  }

  public void TapInnAccept(Text sender)
  {
    Debug.Log("TapInnAccept(S)");
    GroupInnDecision.SetActive(false);
    GroupInn.SetActive(false);
    One.TF.AlreadyRestInn = true;
    One.TF.AlreadyCommunicate = false;
    One.TF.AlreadyDungeon = false;
    One.TF.EscapeFromDungeon = false;
    One.TF.AlreadyPureCleanWater = false;
    One.TF.AlreadySinseisui = false;

    Debug.Log("One.TF.CurrentAreaName: " + One.TF.CurrentAreaName);
    Debug.Log("One.TF.Event_Message400040: " + One.TF.Event_Message400040);
    Debug.Log("One.TF.AvailableSecondEssence: " + One.TF.AvailableSecondEssence);

    // アンシェット街、DUEL戦
    if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET && One.TF.GameDay >= 3 && One.TF.Duel_DummySuburi == false)
    {
      Debug.Log("TapInnAccept Duel Dummy-Suburi");
      MessagePack.DuelCall_DummySuburi(ref QuestMessageList, ref QuestEventList, sender.text);
      TapOK();
      return;
    }

    // ファージル宮殿、DUEL戦
    if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE && One.TF.Event_Message600001 && One.TF.Duel_EgaltSandy_Start == false)
    {
      Debug.Log("TapInnAccept Duel Egalt-Sandy");
      MessagePack.DuelCall_EgaltSandy_Start(ref QuestMessageList, ref QuestEventList, sender.text);
      TapOK();
      return;
    }

    // ファージル宮殿、エオネ参戦後、第三属性の開放
    if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE && One.TF.AvailableEoneFulnea && One.TF.AvailableFirstEssence == false)
    {
      Debug.Log("TOWN_FAZIL_CASTLE event 1");
      MessagePack.Message700045(ref QuestMessageList, ref QuestEventList, sender.text);
      string newCommand = string.Empty;
      for (int ii = 0; ii < One.AvailableCharacters.Count; ii++)
      {
        One.AvailableCharacters[ii].LevelUpEssenceTree(3, ref newCommand);
        if (newCommand != String.Empty)
        {
          One.AvailableCharacters[ii].ApplyNewCommand(newCommand);
        }
      }
      TapOK();
      return;
    }

    // ゴラトラム洞窟で特定区画到達後、アイン、ラナのイヤリングについて考察
    if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE && One.TF.AlreadyRestInn == false && One.TF.EventCore_GoratrumAndEarring && One.TF.EventCore_GoratrumAndEarring2 == false)
    {
      MessagePack.CoreScenario_GoratrumAndEarring2(ref QuestMessageList, ref QuestEventList);
    }

    // 港町コチューシェ、ビリー参戦＋エオネ離脱後、第四属性の開放
    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE && One.TF.Event_Message400040 && One.TF.AvailableSecondEssence == false)
    {
      Debug.Log("TOWN_COTUHSYE event 1");
      MessagePack.Message400050(ref QuestMessageList, ref QuestEventList, sender.text);
      TapOK();
      return;
    }

    // 神秘の森で「祈願の御札」を入手した後、「宝剣？？？」について熟慮
    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE && One.TF.FindBackPackItem(Fix.KIGAN_OFUDA) && One.TF.EventCore_SeekMissingLinkInn == false)
    {
      MessagePack.CoreScenario_SeekMissingLinkInn(ref QuestMessageList, ref QuestEventList, sender.text);
      TapOK();
      return;
    }

    // ツァルマンの里、アデル参戦後、第五属性の開放
    if ((One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN || One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE) && One.TF.AvailableAdelBrigandy && One.TF.AvailableThirdEssence == false)
    {
      Debug.Log("TOWN_ZHALMAN event 1");
      MessagePack.Message500040(ref QuestMessageList, ref QuestEventList, sender.text);
      TapOK();
      return;
    }

    // ツァルマンの里、Duel戦：レネ・コルトス
    if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN && One.TF.FindBackPackItem(Fix.SHADOW_MOON_KEY) && One.TF.FindBackPackItem(Fix.SUN_BURST_KEY) && One.TF.Duel_LeneColtos_Start == false)
    {
      Debug.Log("TapInnAccept Duel Lene-Coltos");
      MessagePack.DuelCall_LeneColtos_Start(ref QuestMessageList, ref QuestEventList, sender.text);
      TapOK();
      return;
    }

    // パルメティシア神殿、Duel戦：カルマンズ・オーン
    if (One.TF.Event_Message1000292 && One.TF.Duel_CalmansOhn_Start == false)
    {
      Debug.Log("TapInnAccept Duel Calmans-Ohn");
      MessagePack.DuelCall_CalmansOhn_Start(ref QuestMessageList, ref QuestEventList, sender.text);
      TapOK();
      return;
    }

    // パルメテイシア神殿、エオネDUEL戦闘後
    if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA && One.TF.Event_Message1010020 && One.TF.Event_Message1010030 == false)
    {
      Debug.Log("TOWN_PARMETYSIA event Event_Message1010030");
      MessagePack.Message1010030(ref QuestMessageList, ref QuestEventList, sender.text);
      TapOK();
      return;
    }

    Debug.Log("TapInnAccept normal");
    MessagePack.MessageX00006(ref QuestMessageList, ref QuestEventList, sender.text, One.TF.CurrentAreaName);
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
    One.TF.AlreadyCommunicate = false;
    One.TF.AlreadyDungeon = false;
    One.TF.EscapeFromDungeon = false;
    One.TF.AlreadyPureCleanWater = false;
    One.TF.AlreadySinseisui = false;

    One.TF.Fountain_Esmilia_1 = false;
    One.TF.Fountain_Esmilia_2 = false;
    One.TF.Fountain_Esmilia_3 = false;
    One.TF.Fountain_Goratrum_1 = false;
    One.TF.Fountain_Goratrum_2 = false;
    One.TF.Fountain_MysticForest_1 = false;
    One.TF.Fountain_MysticForest_2 = false;
    One.TF.Fountain_MysticForest_3 = false;
    One.TF.Fountain_OhranTower_1 = false;
    One.TF.Fountain_OhranTower_2 = false;
    One.TF.Fountain_OhranTower_3 = false;
    One.TF.Fountain_OhranTower_4 = false;
    One.TF.Fountain_OhranTower_5 = false;
    One.TF.Fountain_Velgus_1 = false;
    One.TF.Fountain_Velgus_2 = false;
    One.TF.Fountain_Velgus_3 = false;
    One.TF.Fountain_Velgus_4 = false;
    One.TF.Fountain_Velgus_5 = false;
    One.TF.Fountain_Velgus_6 = false;
    One.TF.Fountain_Velgus_7 = false;
    One.TF.Fountain_Velgus_8 = false;
    One.TF.Fountain_Velgus_9 = false;
    One.TF.Fountain_Edelgarzen_1 = false;
    One.TF.Fountain_Edelgarzen_2 = false;

    One.TF.GameDay += 1;
    dayLabel.text = One.TF.GameDay.ToString() + "日目";
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      this.dayLabel.text = "？？？日目";
    }

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

    //// 未選択時は、キャラクターを選択
    //if (TacticsPickupCharacter == null)
    //{
    //  for (int ii = 0; ii < One.PlayerList.Count; ii++)
    //  {
    //    if (src_txt.text == One.PlayerList[ii].FullName)
    //    {
    //      TacticsPickupCharacter = One.PlayerList[ii];
    //      TacticsPickupPartyNumber = -1;
    //      objSelectCursor.SetActive(true);
    //      txtSelectCursor.text = One.PlayerList[ii].FullName;
    //      return;
    //    }
    //  }
    //  Debug.Log("TapPartyPickEnter cannot search playerlist...");
    //  return;
    //}

    //// 選択時は、パーティ内のキャラクターを選んでいる場合は、
    //// 選択しているキャラクターを削除する。
    //if (TacticsPickupPartyNumber >= 0)
    //{
    //  PartyListClass[TacticsPickupPartyNumber].sprite = null;
    //  PartyListName[TacticsPickupPartyNumber].text = "(Empty)";
    //  PartyListLevel[TacticsPickupPartyNumber].text = "--";
    //  PartyListLife[TacticsPickupPartyNumber].text = "--";
    //  PartyListSTR[TacticsPickupPartyNumber].text = "--";
    //  PartyListAGL[TacticsPickupPartyNumber].text = "--";
    //  PartyListINT[TacticsPickupPartyNumber].text = "--";
    //  PartyListSTM[TacticsPickupPartyNumber].text = "--";
    //  PartyListMND[TacticsPickupPartyNumber].text = "--";
    //  foreach (Transform n in GroupPartyList[TacticsPickupPartyNumber].transform)
    //  {
    //    GameObject.Destroy(n.gameObject);
    //  }
    //}

    //UpdateStayListCheckMark();
    //objSelectCursor.SetActive(false);
    //TacticsPickupCharacter = null;
    //TacticsPickupPartyNumber = -1;
  }
  public void TapPartyPickChoose(int num)
  {
    //Debug.Log(MethodInfo.GetCurrentMethod() +  ": " + num.ToString());
    //// 未選択時は、キャラクターを選択
    //if (TacticsPickupCharacter == null)
    //{
    //  for (int ii = 0; ii < One.PlayerList.Count; ii++)
    //  {
    //    if (PartyListName[num].text == One.PlayerList[ii].FullName)
    //    {
    //      TacticsPickupCharacter = One.PlayerList[ii];
    //      TacticsPickupPartyNumber = num;
    //      objSelectCursor.SetActive(true);
    //      txtSelectCursor.text = One.PlayerList[ii].FullName;
    //      return;
    //    }
    //  }
    //  Debug.Log(MethodInfo.GetCurrentMethod() + ": cannot search playerlist...");
    //  return;
    //}

    //// 反映先に既にキャラクターがある場合は、選択元を記憶する。
    //Character current = null;
    //if (PartyListName[num].text != null && PartyListName[num].text != String.Empty && PartyListName[num].text != "Character Name" && PartyListName[num].text != "(Empty)")
    //{
    //  Debug.Log("swap PartyListName is " + PartyListName[num].text);

    //  for (int ii = 0; ii < One.PlayerList.Count; ii++)
    //  {
    //    if (PartyListName[num].text == One.PlayerList[ii].FullName)
    //    {
    //      current = One.PlayerList[ii];
    //      break;
    //    }
    //  }
    //}

    //// 選択しているキャラクターが既にパーティリストにある場合は、それを削除する。
    //for (int ii = 0; ii < PartyListName.Count; ii++)
    //{
    //  Debug.Log("PartyListName: " + PartyListName[ii].text + " TacticsPickupCharacter: " + TacticsPickupCharacter.FullName);
    //  if (PartyListName[ii].text == "Character Name" || PartyListName[ii].text == "(Empty")
    //  {
    //    continue;
    //  }

    //  if (TacticsPickupCharacter.FullName == PartyListName[ii].text)
    //  {
    //    PartyListClass[ii].sprite = null;
    //    PartyListName[ii].text = "(Empty)";
    //    PartyListLevel[ii].text = "--";
    //    PartyListLife[ii].text = "--";
    //    PartyListSTR[ii].text = "--";
    //    PartyListAGL[ii].text = "--";
    //    PartyListINT[ii].text = "--";
    //    PartyListSTM[ii].text = "--";
    //    PartyListMND[ii].text = "--";
    //    foreach (Transform n in GroupPartyList[ii].transform)
    //    {
    //      GameObject.Destroy(n.gameObject);
    //    }
    //    break;
    //  }
    //}

    //// 現在選択しているキャラクターを指定箇所に反映する。
    //Debug.Log("Now setup TacticsPickupCharacter: " + num +  " " + TacticsPickupCharacter.FullName);
    //PartyListClass[num].sprite = Resources.Load<Sprite>("Unit_" + TacticsPickupCharacter?.Job.ToString() ?? "");
    //PartyListName[num].text = TacticsPickupCharacter.FullName;
    //PartyListLevel[num].text = TacticsPickupCharacter.Level.ToString();
    //PartyListLife[num].text = TacticsPickupCharacter.CurrentLife.ToString() + " / " + TacticsPickupCharacter.MaxLife.ToString();
    //PartyListSTR[num].text = TacticsPickupCharacter.TotalStrength.ToString();
    //PartyListAGL[num].text = TacticsPickupCharacter.TotalAgility.ToString();
    //PartyListINT[num].text = TacticsPickupCharacter.TotalIntelligence.ToString();
    //PartyListSTM[num].text = TacticsPickupCharacter.TotalStamina.ToString();
    //PartyListMND[num].text = TacticsPickupCharacter.TotalMind.ToString();

    //foreach (Transform n in GroupPartyList[num].transform)
    //{
    //  GameObject.Destroy(n.gameObject);
    //}
    //List<String> actionList = TacticsPickupCharacter.GetActionCommandList();
    //for (int ii = 0; ii < actionList.Count; ii++)
    //{
    //  NodeActionCommand instant = Instantiate(prefab_ActionCommand) as NodeActionCommand;
    //  instant.BackColor.color = TacticsPickupCharacter.BattleForeColor;
    //  instant.CommandName = actionList[ii];
    //  instant.name = actionList[ii];
    //  instant.OwnerName = TacticsPickupCharacter.FullName;
    //  instant.ActionButton.name = actionList[ii];
    //  instant.ActionButton.image.sprite = Resources.Load<Sprite>(actionList[ii]);

    //  //Debug.Log("TapPartyPickChoose: " + TacticsPickupCharacter.ActionCommandList[ii]);
    //  instant.transform.SetParent(GroupPartyList[num].transform);
    //  instant.gameObject.SetActive(true);
    //}

    //// 反映先のキャラクターと入れ替え情報があった場合、かつ
    //// 選択元がStayListではない場合、入れ替えを行う。
    //if (current != null && TacticsPickupPartyNumber >= 0)
    //{
    //  Debug.Log("Detect current: " + TacticsPickupPartyNumber + " " + current.FullName);
    //  PartyListClass[TacticsPickupPartyNumber].sprite = Resources.Load<Sprite>("Unit_" + current?.Job.ToString() ?? "");
    //  PartyListName[TacticsPickupPartyNumber].text = current.FullName;
    //  PartyListLevel[TacticsPickupPartyNumber].text = current.Level.ToString();
    //  PartyListLife[TacticsPickupPartyNumber].text = current.CurrentLife.ToString() + " / " + current.MaxLife.ToString();
    //  PartyListSTR[TacticsPickupPartyNumber].text = current.TotalStrength.ToString();
    //  PartyListAGL[TacticsPickupPartyNumber].text = current.TotalAgility.ToString();
    //  PartyListINT[TacticsPickupPartyNumber].text = current.TotalIntelligence.ToString();
    //  PartyListSTM[TacticsPickupPartyNumber].text = current.TotalStamina.ToString();
    //  PartyListMND[TacticsPickupPartyNumber].text = current.TotalMind.ToString();

    //  foreach (Transform n in GroupPartyList[TacticsPickupPartyNumber].transform)
    //  {
    //    GameObject.Destroy(n.gameObject);
    //  }
    //  List<string> actionListCurrent = current.GetActionCommandList();
    //  for (int ii = 0; ii < actionListCurrent.Count; ii++)
    //  {
    //    NodeActionCommand instant = Instantiate(prefab_ActionCommand) as NodeActionCommand;
    //    instant.BackColor.color = current.BattleForeColor;
    //    instant.CommandName = actionListCurrent[ii];
    //    instant.name = actionListCurrent[ii];
    //    instant.OwnerName = current.FullName;
    //    instant.ActionButton.name = actionListCurrent[ii];
    //    instant.ActionButton.image.sprite = Resources.Load<Sprite>(actionListCurrent[ii]);

    //    Debug.Log("TapPartyPickChoose: " + actionListCurrent[ii]);
    //    instant.transform.SetParent(GroupPartyList[TacticsPickupPartyNumber].transform);
    //    instant.gameObject.SetActive(true);
    //  }
    //}
    //else
    //{
    //  Debug.Log("Detect current: null...");
    //}

    //UpdateStayListCheckMark();
    //objSelectCursor.SetActive(false);
    //TacticsPickupCharacter = null;
    //TacticsPickupPartyNumber = -1;
  }

  public void TapPartyCommand()
  {
  }

  public void TapGetItemBank()
  {
    if (this.CurrentSelectItemBank == null) { return; }

    bool success = One.TF.AddBackPack(CurrentSelectItemBank);
    if (success == false)
    {
      MessagePack.MessageX00018(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    MessagePack.MessageX00018_2(ref QuestMessageList, ref QuestEventList, this.CurrentSelectItemBank.ItemName); TapOK();
    One.TF.RemoveItemBank(CurrentSelectItemBank);
    this.CurrentSelectItemBank = null;
    ConstructItemBankView();
  }

  public void TapItemBankSelect(NodeBackpackItem item)
  {
    Debug.Log("TapItemBankSelect(S)");
    this.CurrentSelectItemBank = One.TF.ItemBankList[item.BackpackNumber];

    for (int ii = 0; ii < ItemBankList.Count; ii++)
    {
      Debug.Log("ItemBankList: " + ItemBankList[ii].txtName.text);
      ItemBankList[ii].imgSelect.gameObject.SetActive(false);
    }
    item.imgSelect.gameObject.SetActive(true);
  }

  public void TapCloseNewAvailable()
  {
    GroupNewAvailable.SetActive(false); 
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
          One.ReInitializeGroundOne(false);
          One.StopDungeonMusic();
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

          currentMessage = currentMessage.Replace("クエスト【 ", "");
          currentMessage = currentMessage.Replace(" 】が開始されました！", "");

          // todo
          if (currentMessage.Equals(Fix.QUEST_TITLE_1)) { One.TF.QuestMain_00001 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_2)) { One.TF.QuestMain_00002 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_3)) { One.TF.QuestMain_00003 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_4)) { One.TF.QuestMain_00004 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_5)) { One.TF.QuestMain_00005 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_6)) { One.TF.QuestMain_00006 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_7)) { One.TF.QuestMain_00007 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_8)) { One.TF.QuestMain_00008 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_9)) { One.TF.QuestMain_00009 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_10)) { One.TF.QuestMain_00010 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_11)) { One.TF.QuestMain_00011 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_20)) { One.TF.QuestMain_00020 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_21)) { One.TF.QuestMain_00021 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_22)) { One.TF.QuestMain_00022 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_23)) { One.TF.QuestMain_00023 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_31)) { One.TF.QuestMain_00031 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_41)) { One.TF.QuestMain_00041 = true; }
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

          currentMessage = currentMessage.Replace("クエスト【 ", "");
          currentMessage = currentMessage.Replace(" 】を達成しました！", "");
          // todo
          if (currentMessage.Equals(Fix.QUEST_TITLE_1))
          {
            One.TF.QuestMain_Complete_00001 = true;

            // Message100021で獲得した内容を表示する。
            //int gainExp = 0;
            int gainGold = 2000;
            string gainItem = Fix.ARTIFACT_GENSEI;
            // int gainSoulFragment = 0;
            One.TF.Gold += gainGold;
            bool success = One.TF.AddBackPack(new Item(gainItem));
            if (success == false)
            {
              Debug.Log("QuestComplete cannot get AddBackpack, then AddItemBank");
              this.GetQuestItemFail = gainItem;
            }

            this.txtQCGoldGain.text = gainGold.ToString() + " ゴールドを獲得しました！";
            this.txtQCExpGain.text = "";// gainExp.ToString() + " 経験値を獲得しました！";
            this.txtQCItemGain.text = gainItem + " を獲得しました";
            this.txtQCSoulEssenceGain.text = "エオネ・フルネアが仲間になりました！";// "1 ソウル・エッセンスを獲得しました！";
          }
          else if (currentMessage.Equals(Fix.QUEST_TITLE_2))
          {
            One.TF.QuestMain_Complete_00002 = true;

            int gainGold = 50000;
            string gainItem = Fix.ARTIFACT_ZIHI;
            int gainSoulFragment = 1;
            for (int jj = 0; jj < One.AvailableCharacters.Count; jj++)
            {
              One.AvailableCharacters[jj].SoulFragment += gainSoulFragment;
            }
            bool success = One.TF.AddBackPack(new Item(gainItem));
            if (success == false)
            {
              Debug.Log("QuestComplete cannot get AddBackpack, then AddItemBank");
              this.GetQuestItemFail = gainItem;
            }

            this.txtQCExpGain.text = gainGold.ToString() + " ゴールドを獲得しました！";
            this.txtQCGoldGain.text = gainItem + " を獲得しました";
            this.txtQCSoulEssenceGain.text = "新しいミッションが追加されました！";
            this.txtQCItemGain.text = gainSoulFragment.ToString() + " ソウル・エッセンスを獲得しました！";
          }
          else if (currentMessage.Equals(Fix.QUEST_TITLE_21))
          {
            int gainGold = 50000;
            One.TF.Gold += gainGold;

            int gainSoulFragment = 1;
            for (int jj = 0; jj < One.AvailableCharacters.Count; jj++)
            {
              One.AvailableCharacters[jj].SoulFragment += gainSoulFragment;
            }

            this.txtQCExpGain.text = gainGold.ToString() + " ゴールドを獲得しました！";
            this.txtQCGoldGain.text = "新しいミッションが追加されました！";
            this.txtQCSoulEssenceGain.text = "";
            this.txtQCItemGain.text = gainSoulFragment.ToString() + " ソウル・エッセンスを獲得しました！";
          }
          else if (currentMessage.Equals(Fix.QUEST_TITLE_31))
          {
            int gainGold = 100000;
            One.TF.Gold += gainGold;

            int gainSoulFragment = 1;
            for (int jj = 0; jj < One.AvailableCharacters.Count; jj++)
            {
              One.AvailableCharacters[jj].SoulFragment += gainSoulFragment;
            }

            this.txtQCExpGain.text = gainGold.ToString() + " ゴールドを獲得しました！";
            this.txtQCGoldGain.text = "新しいミッションが追加されました！";
            this.txtQCSoulEssenceGain.text = "";
            this.txtQCItemGain.text = gainSoulFragment.ToString() + " ソウル・エッセンスを獲得しました！";
          }
          else
          {
            Debug.Log("FailRoutine... " + currentMessage);
          }

          if (currentMessage.Equals(Fix.QUEST_TITLE_2)) { One.TF.QuestMain_Complete_00002 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_3)) { One.TF.QuestMain_Complete_00003 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_4)) { One.TF.QuestMain_Complete_00004 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_5)) { One.TF.QuestMain_Complete_00005 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_6)) { One.TF.QuestMain_Complete_00006 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_7)) { One.TF.QuestMain_Complete_00007 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_8)) { One.TF.QuestMain_Complete_00008 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_9)) { One.TF.QuestMain_Complete_00009 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_10)) { One.TF.QuestMain_Complete_00010 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_11)) { One.TF.QuestMain_Complete_00011 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_20)) { One.TF.QuestMain_Complete_00020 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_21)) { One.TF.QuestMain_Complete_00021 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_22)) { One.TF.QuestMain_Complete_00022 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_23)) { One.TF.QuestMain_Complete_00023 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_31)) { One.TF.QuestMain_Complete_00031 = true; }
          if (currentMessage.Equals(Fix.QUEST_TITLE_41)) { One.TF.QuestMain_Complete_00041 = true; }
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
          Debug.Log("HomeTownAddNewCharacter phase: " + currentMessage);
          Debug.Log("One.TF.BattlePlayer1: " + One.TF.BattlePlayer1.ToString());
          Debug.Log("One.TF.BattlePlayer2: " + One.TF.BattlePlayer2.ToString());
          Debug.Log("One.TF.BattlePlayer3: " + One.TF.BattlePlayer3.ToString());
          Debug.Log("One.TF.BattlePlayer4: " + One.TF.BattlePlayer4.ToString());
          Debug.Log("One.TF.BattlePlayer5: " + One.TF.BattlePlayer5.ToString());
          Debug.Log("One.TF.BattlePlayer6: " + One.TF.BattlePlayer6.ToString());
          if (currentMessage.Contains(Fix.NAME_EONE_FULNEA))
          {
            Debug.Log("NewAddCharacter Eone");
            One.TF.AvailableEoneFulnea = true;
            if (One.TF.BattlePlayer3 == null || One.TF.BattlePlayer3 == String.Empty) { One.TF.BattlePlayer3 = Fix.NAME_EONE_FULNEA; Debug.Log("Eone 3"); }
            else if (One.TF.BattlePlayer4 == null || One.TF.BattlePlayer4 == String.Empty) { One.TF.BattlePlayer4 = Fix.NAME_EONE_FULNEA; Debug.Log("Eone 4"); }
            else if (One.TF.BattlePlayer5 == null || One.TF.BattlePlayer5 == String.Empty) { One.TF.BattlePlayer5 = Fix.NAME_EONE_FULNEA; Debug.Log("Eone 5"); }
            // todo ReInitializeではなくて、アップデートが必要。
          }
          else if (currentMessage.Contains(Fix.NAME_BILLY_RAKI))
          {
            One.TF.AvailableBillyRaki = true;
            One.TF.BattlePlayer4 = Fix.NAME_BILLY_RAKI;
            // todo ReInitializeではなくて、アップデートが必要。
          }
          else if (currentMessage.Contains(Fix.NAME_ADEL_BRIGANDY))
          {
            Debug.Log("NewAddCharacter Adel");
            One.TF.AvailableAdelBrigandy = true;
            if (One.TF.BattlePlayer3 == null || One.TF.BattlePlayer3 == String.Empty) { One.TF.BattlePlayer3 = Fix.NAME_ADEL_BRIGANDY; Debug.Log("Adel 3"); }
            else if (One.TF.BattlePlayer4 == null || One.TF.BattlePlayer4 == String.Empty) { One.TF.BattlePlayer4 = Fix.NAME_ADEL_BRIGANDY; Debug.Log("Adel 4"); }
            else if (One.TF.BattlePlayer5 == null || One.TF.BattlePlayer5 == String.Empty) { One.TF.BattlePlayer5 = Fix.NAME_ADEL_BRIGANDY; Debug.Log("Adel 5"); }
            else if (One.TF.BattlePlayer6 == null || One.TF.BattlePlayer6 == String.Empty) { One.TF.BattlePlayer6 = Fix.NAME_ADEL_BRIGANDY; Debug.Log("Adel 6"); }
            // todo ReInitializeではなくて、アップデートが必要。
          }
          else if (currentMessage.Contains(Fix.NAME_SELMOI_RO))
          {
            One.TF.AvailableSelmoiRo = true;
            // todo ReInitializeではなくて、アップデートが必要。
          }

          RefreshAllView();
          continue; // 継続
        }
        // 元いたパーティを復帰させる、もしくは更新する。
        else if (currentEvent == MessagePack.ActionEvent.HomeTownUpdateCharacter)
        {
          if (currentMessage.Contains(Fix.NAME_EONE_FULNEA))
          {
            Debug.Log("NewAddCharacter Eone");
            One.TF.AvailableEoneFulnea = true;
            if (One.TF.BattlePlayer3 == null || One.TF.BattlePlayer3 == String.Empty) { One.TF.BattlePlayer3 = Fix.NAME_EONE_FULNEA; Debug.Log("Eone 3"); }
            else if (One.TF.BattlePlayer4 == null || One.TF.BattlePlayer4 == String.Empty) { One.TF.BattlePlayer4 = Fix.NAME_EONE_FULNEA; Debug.Log("Eone 4"); }
            else if (One.TF.BattlePlayer5 == null || One.TF.BattlePlayer5 == String.Empty) { One.TF.BattlePlayer5 = Fix.NAME_EONE_FULNEA; Debug.Log("Eone 5"); }
            Character character = One.SelectCharacter(Fix.NAME_EONE_FULNEA);
          }

          RefreshAllView();
          continue; // 継続
        }
        // パーティから離脱する
        else if (currentEvent == MessagePack.ActionEvent.HomeTownRemoveCharacter)
        {
          if (currentMessage.Contains(Fix.NAME_EONE_FULNEA))
          {
            if (One.TF.BattlePlayer1 == Fix.NAME_EONE_FULNEA)
            {
              One.TF.BattlePlayer1 = One.TF.BattlePlayer2;
              One.TF.BattlePlayer2 = One.TF.BattlePlayer3;
              One.TF.BattlePlayer3 = One.TF.BattlePlayer4;
              //One.TF.BattlePlayer4 = Fix.NAME_EONE_FULNEA;
            }
            else if (One.TF.BattlePlayer2 == Fix.NAME_EONE_FULNEA)
            {
              One.TF.BattlePlayer2 = One.TF.BattlePlayer3;
              One.TF.BattlePlayer3 = One.TF.BattlePlayer4;
              //One.TF.BattlePlayer4 = Fix.NAME_EONE_FULNEA;
            }
            else if (One.TF.BattlePlayer3 == Fix.NAME_EONE_FULNEA)
            {
              One.TF.BattlePlayer3 = One.TF.BattlePlayer4;
              //One.TF.BattlePlayer4 = Fix.NAME_EONE_FULNEA;
            }
            One.TF.BattlePlayer4 = String.Empty;
          }
          continue; // 継続
        }
        // アイテムの入手
        else if (currentEvent == MessagePack.ActionEvent.GetItem)
        {
          Debug.Log("event: " + currentEvent.ToString() + " " + currentMessage);
          bool success = One.TF.AddBackPack(new Item(currentMessage));
          if (success == false)
          {
            this.GetItemFail = currentMessage;
          }
          else
          {
            this.GetItemFail = string.Empty;
          }
          ConstructBackpackView();
          ConstructItemBankView();
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.GetPreciousItem)
        {
          Debug.Log("event: " + currentEvent.ToString() + " " + currentMessage);
          // 大事なアイテムの入手に上限はない。
          One.TF.AddPreciousItem(new Item(currentMessage));
          ConstructBackpackView();
          ConstructItemBankView();
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.RemoveItem)
        {
          Debug.Log("event: " + currentEvent.ToString() + " " + currentMessage);
          One.TF.RemoveItem(new Item(currentMessage));
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
        else if (currentEvent == MessagePack.ActionEvent.LostGold)
        {
          Debug.Log("event: " + currentEvent.ToString() + " " + currentMessage);
          One.TF.Gold -= Convert.ToInt32(currentMessage);
          RefreshAllView();
          continue; // 継続
        }
        // 食事によるパラメタUP対象の更新
        else if (currentEvent == MessagePack.ActionEvent.HomeTownCallRequestFood)
        {
          List<Character> characters = One.AvailableCharacters;
          for (int jj = 0; jj < characters.Count; jj++)
          {
            // アンシェット街
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

            // ファージル宮殿
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

            // 港町コチューシェ
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

            // ツァルマンの里
            else if (currentMessage == Fix.FOOD_TOBIUSAGI_ROAST)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_31_VALUE);
            }
            else if (currentMessage == Fix.FOOD_WATARI_KAMONABE)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_32_VALUE);
            }
            else if (currentMessage == Fix.FOOD_SYOI_KINOKO_SUGATAYAKI)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_33_VALUE);
            }
            else if (currentMessage == Fix.FOOD_NEGIYAKI_DON)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_34_VALUE);
            }
            else if (currentMessage == Fix.FOOD_NANAIRO_BUNA_NITSUKE)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_35_VALUE);
            }

            // エリア３
            else if (currentMessage == Fix.FOOD_HINYARI_YASAI)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_51_VALUE);
            }
            else if (currentMessage == Fix.FOOD_AZARASI_SHIOYAKI)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_52_VALUE);
            }
            else if (currentMessage == Fix.FOOD_WINTER_BEEF_CURRY)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_53_VALUE);
            }
            else if (currentMessage == Fix.FOOD_GATTURI_GOZEN)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_54_VALUE);
            }
            else if (currentMessage == Fix.FOOD_KOGOERU_DESSERT)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_55_VALUE);
            }

            // エリア４
            else if (currentMessage == Fix.FOOD_BLACK_BUTTER_SPAGHETTI)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_61_VALUE);
            }
            else if (currentMessage == Fix.FOOD_KOROKORO_PIENUS_HAMBURG)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_62_VALUE);
            }
            else if (currentMessage == Fix.FOOD_PIRIKARA_HATIMITSU_STEAK)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_63_VALUE);
            }
            else if (currentMessage == Fix.FOOD_HUNWARI_ORANGE_TOAST)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_64_VALUE);
            }
            else if (currentMessage == Fix.FOOD_TRUTH_YAMINABE_2)
            {
              CharacterEatFood(characters[jj], Fix.FOOD_65_VALUE);
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
          GroupBackpack.SetActive(false);
          GroupShopItem.SetActive(false);
          GroupActionCommandSetting.SetActive(false);
          GroupInn.SetActive(false);
          GroupItemBank.SetActive(false);
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
        // サブビューを全て非表示にする。
        else if (currentEvent == MessagePack.ActionEvent.HomeTownHideAllSubView)
        {
          GroupDungeonPlayer.SetActive(false);
          GroupBackpack.SetActive(false);
          GroupShopItem.SetActive(false);
          GroupActionCommandSetting.SetActive(false);
          GroupInn.SetActive(false);
          GroupItemBank.SetActive(false);
        }
        // 宿屋を呼び出す
        else if (currentEvent == MessagePack.ActionEvent.HomeTownCallRestInn)
        {
          GroupDungeonPlayer.SetActive(false);
          GroupBackpack.SetActive(false);
          GroupShopItem.SetActive(false);
          GroupActionCommandSetting.SetActive(false);
          GroupInn.SetActive(true);
          GroupItemBank.SetActive(false);
          continue;
        }
        // 宿屋による休憩だけを実行する。
        else if (currentEvent == MessagePack.ActionEvent.HomeTownExecRestInn)
        {
          ExecRestInn();
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.HomeTownNight)
        {
          UpdateBackgroundData(Fix.BACKGROUND_NIGHT);
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.HometownNextDay)
        {

          ExecRestInn();
          UpdateBackgroundData(Fix.BACKGROUND_MORNING);
          this.objBlackOut.SetActive(false);
          MessagePack.MessageX00001(ref QuestMessageList, ref QuestEventList);
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.HomeTownResetMenuView)
        {
          GroupActionCommandSetting.SetActive(false);
          GroupDungeonPlayer.SetActive(false);
          GroupBackpack.SetActive(false);
          GroupShopItem.SetActive(false);
          GroupActionCommandSetting.SetActive(false);
          GroupTactics.SetActive(false);
          GroupInn.SetActive(false);
          GroupItemBank.SetActive(false);
          continue;
        }
        else if (currentEvent == MessagePack.ActionEvent.EncountDuel)
        {
          One.CannotRunAway = true;
          One.BattleEnemyList.Clear();
          One.BattleEnemyList.Add(currentMessage);
          PrepareCallTruthBattleEnemy();
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
      if (this.GetItemFail != string.Empty)
      {
        MessagePack.MessageX00017(ref QuestMessageList, ref QuestEventList, this.GetItemFail);
        One.TF.AddItemBank(new Item(this.GetItemFail));
        this.GetItemFail = string.Empty; // 即時クリア
        ConstructItemBankView();
        TapOK();
        return;
      }
      if (this.GetQuestItemFail != string.Empty)
      {
        MessagePack.MessageX00017(ref QuestMessageList, ref QuestEventList, this.GetQuestItemFail);
        One.TF.AddItemBank(new Item(this.GetQuestItemFail));
        this.GetQuestItemFail = string.Empty; // 即時クリア
        ConstructItemBankView();
        TapOK();
        return;
      }

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

  private void PrepareCallTruthBattleEnemy()
  {
    Debug.Log(MethodBase.GetCurrentMethod() + "1");

    this.AlreadyDetectEncount = true;
    One.BattleEnd = Fix.GameEndType.None;
    One.FromHometown = true;
    One.ShadowPlayerList.Clear();
    if (this.ignoreCreateShadow == false)
    {
      this.ignoreCreateShadow = true;
      One.CreateShadowData();
      for (int ii = 0; ii < One.EnemyList.Count; ii++)
      {
        UnityEngine.Object.DontDestroyOnLoad(One.ShadowPlayerList[ii]);
      }
    }
    Debug.Log(MethodBase.GetCurrentMethod() + "2");

    One.EnemyList.Clear();
    for (int ii = 0; ii < One.BattleEnemyList.Count; ii++)
    {
      Debug.Log(MethodBase.GetCurrentMethod() + "3 " + One.BattleEnemyList[ii]);
      GameObject objEC = new GameObject("objEC_" + ii.ToString());
      Debug.Log(MethodBase.GetCurrentMethod() + "3-2 " + One.BattleEnemyList[ii]);
      Character character = objEC.AddComponent<Character>();
      Debug.Log(MethodBase.GetCurrentMethod() + "3-3 " + One.BattleEnemyList[ii]);
      character.Construction(One.BattleEnemyList[ii]);
      Debug.Log(MethodBase.GetCurrentMethod() + "3-4 " + One.BattleEnemyList[ii]);
      One.EnemyList.Add(character);
      Debug.Log(MethodBase.GetCurrentMethod() + "3-5 " + One.BattleEnemyList[ii]);

      if (One.EnemyList[0].Area == Fix.MonsterArea.Boss1 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss2 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss3 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss4 ||
          One.EnemyList[0].Area == Fix.MonsterArea.Boss5)
      {
        One.BattleMode = Fix.BattleMode.Boss;
      }
      else if (One.EnemyList[0].FullName == Fix.DUEL_DUMMY_SUBURI || One.EnemyList[0].FullName == Fix.DUEL_DUMMY_SUBURI_JP ||
               One.EnemyList[0].FullName == Fix.DUEL_EGALT_SANDY || One.EnemyList[0].FullName == Fix.DUEL_EGALT_SANDY_JP ||
               One.EnemyList[0].FullName == Fix.DUEL_LENE_COLTOS || One.EnemyList[0].FullName == Fix.DUEL_LENE_COLTOS_JP ||
               One.EnemyList[0].FullName == Fix.DUEL_CALMANS_OHN || One.EnemyList[0].FullName == Fix.DUEL_CALMANS_OHN_JP ||
               One.EnemyList[0].FullName == Fix.NAME_EONE_FULNEA ||
               One.EnemyList[0].FullName == Fix.DUEL_SELMOI_RO || One.EnemyList[0].FullName == Fix.DUEL_SELMOI_RO_JP ||
               One.EnemyList[0].FullName == Fix.DUEL_SHINIKIA_KAHLHANZ || One.EnemyList[0].FullName == Fix.DUEL_SHINIKIA_KAHLHANZ_JP ||
               One.EnemyList[0].FullName == Fix.DUEL_ZATKON_MEMBER_1 || One.EnemyList[0].FullName == Fix.DUEL_ZATKON_MEMBER_1_JP ||
               One.EnemyList[0].FullName == Fix.DUEL_ZATKON_MEMBER_2 || One.EnemyList[0].FullName == Fix.DUEL_ZATKON_MEMBER_2_JP)
      {
        Debug.Log(MethodBase.GetCurrentMethod() + "4 Duel");
        One.BattleMode = Fix.BattleMode.Duel;
      }
      else
      {
        One.BattleMode = Fix.BattleMode.Normal;
      }
    }

    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      Debug.Log(MethodBase.GetCurrentMethod() + "5");
      UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    }

    //this.GroupQuestMessage.SetActive(true);
    Debug.Log(MethodBase.GetCurrentMethod() + "6");
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

  private void MoveTransform(GameObject obj, Transform dst)
  {
    foreach (Transform n in obj.transform)
    {
      n.transform.SetParent(dst.transform);
      break;
    }
  }

  // todo リリースで削除する。
  //  private void UpdateActionCommandSetting(Character player)
  //  {
  //    txtACHeaderName.text = player.FullName;

  //    // コンテンツ内のparent設定を解放する。
  //    foreach (Transform n in ContentActionCommandSetting.transform)
  //    {
  //      GameObject.Destroy(n.gameObject);
  //    }
  //    //for (int ii = 0; ii < Fix.INFINITY; ii++)
  //    //{

  //    //    MoveTransform(ContentActionCommandSetting, EmptyGroup.transform);
  //    //    if (ContentActionCommandSetting.transform.childCount <= 0)
  //    //    {
  //    //        break;
  //    //    }
  //    //}

  //    // コンテンツ長さを初期化する。
  //    GameObject content = ContentActionCommandSetting;
  //    content.GetComponent<RectTransform>().sizeDelta = new Vector2(1, content.GetComponent<RectTransform>().sizeDelta.y);

  //    txtAttributeSoulFragment.text = player.SoulFragment.ToString();

  //    // 制限開放の分だけ、リスト生成する。
  //    List<NodeACAttribute> attributeList = new List<NodeACAttribute>();
  //    if (One.TF.AvailableAllCommand)
  //    {
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.Fire);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.Ice);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.HolyLight);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.DarkMagic);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.Force);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.VoidChant);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.Warrior);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.Guardian);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.MartialArts);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.Archery);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.Truth);
  //      CreateACAttribute(attributeList, Fix.CommandAttribute.Mindfulness);
  //    }
  //    else
  //    {
  //      if (One.TF.AvailableFirstCommand)
  //      {
  //        Debug.Log("Detect AvailableFirstCommand");
  //        NodeACAttribute current = Instantiate(NodeACAttribute) as NodeACAttribute;
  //        current.CommandAttribute = player.FirstCommandAttribute;
  //        CreateACAttribute(ContentActionCommandSetting, current, attributeList.Count);
  //        attributeList.Add(current);
  //      }
  //      if (One.TF.AvailableSecondCommand)
  //      {
  //        Debug.Log("Detect AvailableSecondCommand");
  //        NodeACAttribute current = Instantiate(NodeACAttribute) as NodeACAttribute;
  //        current.CommandAttribute = player.SecondCommandAttribute;
  //        CreateACAttribute(ContentActionCommandSetting, current, attributeList.Count);
  //        attributeList.Add(current);
  //      }
  //      if (One.TF.AvailableThirdCommand)
  //      {
  //        Debug.Log("Detect AvailableThirdCommand");
  //        NodeACAttribute current = Instantiate(NodeACAttribute) as NodeACAttribute;
  //        current.CommandAttribute = player.ThirdCommandAttribute;
  //        CreateACAttribute(ContentActionCommandSetting, current, attributeList.Count);
  //        attributeList.Add(current);
  //      }
  //    }

  //    // アクションコマンドリストを表示する。
  //    for (int ii = 0; ii < attributeList.Count; ii++)
  //    {
  //      List<string> attrList = ActionCommand.GetCommandList(attributeList[ii].CommandAttribute);
  //      List<int> attrPlus = ActionCommand.GetCommandPlus(CurrentPlayer, attributeList[ii].CommandAttribute);

  //      int totalValue = 0;
  //      for (int jj = 0; jj < attrPlus.Count; jj++)
  //      {
  //        totalValue += attrPlus[jj];
  //      }

  //      // トータル１以上であれば表示。それ以外はLOCKED表示とする。
  ////      if (totalValue > 0)
  ////      {
  //        Debug.Log("Detect totalValue: " + totalValue.ToString());
  //        attributeList[ii].lockPanel.SetActive(false);
  //        attributeList[ii].txtName.text = attributeList[ii].CommandAttribute.ToString();
  //        attributeList[ii].txtTotal.text = "Total Lv" + totalValue;
  //        //attributeList[ii].background.color = ActionCommand.GetCommandColor(attributeList[ii].CommandAttribute);
  //        for (int jj = 0; jj < attributeList[ii].imgACElement.Count; jj++)
  //        {
  //          attributeList[ii].imgACElement[jj].sprite = Resources.Load<Sprite>(attrList[jj]);
  //        }
  //        for (int jj = 0; jj < attributeList[ii].txtACElement.Count; jj++)
  //        {
  //          attributeList[ii].txtACElement[jj].text = attrList[jj];
  //        }
  //        for (int jj = 0; jj < attributeList[ii].txtACPlus.Count; jj++)
  //        {
  //          if (attrPlus[jj] > 0)
  //          {
  //            attributeList[ii].ACLockPanel[jj].SetActive(false);
  //            attributeList[ii].txtACPlus[jj].text = "+" + attrPlus[jj].ToString();
  //          }
  //          else
  //          {
  //            attributeList[ii].txtACPlus[jj].text = String.Empty;
  //            //attributeList[ii].txtACElement[jj].text = ""; // 非公開にする必要性はない。
  //          }
  //        }
  //      //}
  //      //else
  //      //{
  //        Debug.Log("totalValue: " + totalValue.ToString() + " then, lockPanel on");
  //        //attributeList[ii].lockPanel.SetActive(true);
  //        //attributeList[ii].txtName.text = String.Empty;
  //        //attributeList[ii].txtTotal.text = String.Empty;
  //        //attributeList[ii].background.color = new Color(0.5f, 0.5f, 0.5f);
  //        //for (int jj = 0; jj < attributeList[ii].imgACElement.Count; jj++)
  //        //{
  //        //  attributeList[ii].imgACElement[jj].sprite = Resources.Load<Sprite>(Fix.STAY);
  //        //}
  //        //for (int jj = 0; jj < attributeList[ii].txtACElement.Count; jj++)
  //        //{
  //        //  attributeList[ii].txtACElement[jj].text = string.Empty;
  //        //}
  //        //for (int jj = 0; jj < attributeList[ii].txtACPlus.Count; jj++)
  //        //{
  //        //  attributeList[ii].txtACPlus[jj].text = string.Empty;
  //        //}
  //      //}
  //    }
  //  }

  private void CreateACAttribute(List<NodeACAttribute> list, Fix.CommandAttribute attribute)
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

  private void ConstructItemBankView()
  {
    foreach (Transform n in ContentItemBank.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    ContentItemBank.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    ItemBankList.Clear();
    int counter = 0;
    for (int ii = 0; ii < One.TF.ItemBankList.Count; ii++)
    {
      NodeBackpackItem current = Instantiate(nodeItemBankItem) as NodeBackpackItem;
      current.Construct(ContentItemBank, One.TF.ItemBankList[ii].ItemName, One.TF.ItemBankList[ii].StackValue, ii, counter);

      RectTransform rt = current.GetComponent<RectTransform>();
      rt.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
      //rt.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
      //rt.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
      //rt.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);

      counter++;
      ItemBankList.Add(current);
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

  private void ConstructFoodMenu()
  {
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
        current == Fix.PERFECT_BLUE_POTION ||
        current == Fix.SMALL_GREEN_POTION ||
        current == Fix.NORMAL_GREEN_POTION ||
        current == Fix.LARGE_GREEN_POTION ||
        current == Fix.HUGE_GREEN_POTION ||
        current == Fix.HQ_GREEN_POTION ||
        current == Fix.THQ_GREEN_POTION ||
        current == Fix.PERFECT_GREEN_POTION ||
        current == Fix.PURE_CLEAN_WATER ||
        current == Fix.PURE_SINSEISUI ||
        current == Fix.PURE_VITALIRY_WATER)
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
    // 基本固定
    btnParty.gameObject.SetActive(true);
    btnBlueSphere.gameObject.SetActive(false);
    btnSystem.gameObject.SetActive(true);

    // ゲーム終了ボタン
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      btnGameExit.gameObject.SetActive(true);
    }
    else
    {
      btnGameExit.gameObject.SetActive(false);
    }

    // エリア情報
    txtArea.text = One.TF.CurrentAreaName;

    // アイコンの反映
    if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET) { imgTownIcon.sprite = Resources.Load<Sprite>(Fix.TOWN_ANSHET_ICON); }
    else if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE) { imgTownIcon.sprite = Resources.Load<Sprite>(Fix.TOWN_FAZIL_CASTLE_ICON); }
    else if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE) { imgTownIcon.sprite = Resources.Load<Sprite>(Fix.TOWN_COTUHSYE_ICON); }
    else if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN) { imgTownIcon.sprite = Resources.Load<Sprite>(Fix.TOWN_ZHALMAN_ICON); }
    else if (One.TF.CurrentAreaName == Fix.TOWN_PARMETYSIA) { imgTownIcon.sprite = Resources.Load<Sprite>(Fix.TOWN_PARMETYSIA_ICON); }
    else { imgTownIcon.sprite = null; }

    // DungeonPlayerのクエストリストを設定
    RefreshQuestList();
    // DungeonPlayerの行き先リストを設定
    RefreshSelectAreaList();

    // SeekerModeではエスミリア草原区域のみを見せる
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      ViewSelectAreaEvent(Fix.DUNGEON_ESMILIA_GRASSFIELD);
    }

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

    if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET)
    {
      btnCustomEvent1.gameObject.SetActive(true);
      txtCustomEvent1.text = "中央噴水広場";
      btnCustomEvent2.gameObject.SetActive(false);
      txtCustomEvent2.text = string.Empty;
      btnCustomEvent3.gameObject.SetActive(false);
      txtCustomEvent3.text = string.Empty;
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
      btnCustomEvent2.gameObject.SetActive(true);
      txtCustomEvent2.text = "ドルワッツの民芸品店";
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

    // チームのリソース(GoldやObsidianStone)を画面へ反映
    txtObsidianStone.text = One.TF.ObsidianStone.ToString();

    // バックパック情報を画面へ反映
    ConstructBackpackView();

    // アイテム保管庫を画面へ反映
    ConstructItemBankView();

    this.CurrentPlayer = One.PlayerList[0];

    // アクションコマンド設定情報を画面へ反映
    foreach (Transform n in ContentMiniChara.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    List<Character> available = One.AvailableCharacters;
    for (int ii = 0; ii < available.Count; ii++)
    {
      if (One.TF.BattlePlayer1 == available[ii].FullName)
      {
        CreateMiniCharaIcon(available[ii]);
        break;
      }
    }
    for (int ii = 0; ii < available.Count; ii++)
    {
      if (One.TF.BattlePlayer2 == available[ii].FullName)
      {
        CreateMiniCharaIcon(available[ii]);
        break;
      }
    }
    for (int ii = 0; ii < available.Count; ii++)
    {
      if (One.TF.BattlePlayer3 == available[ii].FullName)
      {
        CreateMiniCharaIcon(available[ii]);
        break;
      }
    }
    for (int ii = 0; ii < available.Count; ii++)
    {
      if (One.TF.BattlePlayer4 == available[ii].FullName)
      {
        CreateMiniCharaIcon(available[ii]);
        break;
      }
    }
    for (int ii = 0; ii < available.Count; ii++)
    {
      if (One.TF.BattlePlayer5 == available[ii].FullName)
      {
        CreateMiniCharaIcon(available[ii]);
        break;
      }
    }
    for (int ii = 0; ii < available.Count; ii++)
    {
      if (One.TF.BattlePlayer6 == available[ii].FullName)
      {
        CreateMiniCharaIcon(available[ii]);
        break;
      }
    }
    // UpdateActionCommandSetting(this.CurrentPlayer); // todo リリースで削除する。

    // ショップ画面の購入アイテムを設定
    ConstructShopBuyView();

    // ショップ画面で売却アイテムを設定
    ConstructShopSellView();

    // ショップ初期画面は購入画面を設定
    TapShopTypeBuyItem();

    // 食事メニュー
    ConstructFoodMenu();

    // Tacticsのリスト
    //int counter = 0;
    //for (int ii = 0; ii < StayListName.Count; ii++)
    //{
    //  StayListName[ii].text = string.Empty;
    //}
    //for (int ii = 0; ii < StayListName.Count; ii++)
    //{
    //  if (One.AvailableCharacterName(Fix.NAME_LIST[ii]))
    //  {
    //    StayListName[counter].text = Fix.NAME_LIST[ii];
    //    counter++;
    //  }
    //}

    //int num = 0;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer1, num); num++;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer2, num); num++;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer3, num); num++;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer4, num); num++;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer5, num); num++;
    //UpdateTacticsPartyMember(One.TF.BattlePlayer6, num); num++;
    //UpdateStayListCheckMark();

    // 背景と日数
    this.dayLabel.text = One.TF.GameDay.ToString() + "日目";
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      this.dayLabel.text = "？？？日目";
    }

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
    //for (int ii = 0; ii < PartyListName.Count; ii++)
    //{
    //  if (PartyListName[ii].text != "(Empty)" && PartyListName[ii].text != String.Empty)
    //  {
    //    if (ii == 0) { One.TF.BattlePlayer1 = PartyListName[ii].text; }
    //    if (ii == 1) { One.TF.BattlePlayer2 = PartyListName[ii].text; }
    //    if (ii == 2) { One.TF.BattlePlayer3 = PartyListName[ii].text; }
    //    if (ii == 3) { One.TF.BattlePlayer4 = PartyListName[ii].text; }
    //    if (ii == 4) { One.TF.BattlePlayer5 = PartyListName[ii].text; }
    //    if (ii == 5) { One.TF.BattlePlayer6 = PartyListName[ii].text; }
    //  }
    //  else
    //  {
    //    if (ii == 0) { One.TF.BattlePlayer1 = string.Empty; }
    //    if (ii == 1) { One.TF.BattlePlayer2 = string.Empty; }
    //    if (ii == 2) { One.TF.BattlePlayer3 = string.Empty; }
    //    if (ii == 3) { One.TF.BattlePlayer4 = string.Empty; }
    //    if (ii == 4) { One.TF.BattlePlayer5 = string.Empty; }
    //    if (ii == 5) { One.TF.BattlePlayer6 = string.Empty; }
    //  }
    //}

    //for (int ii = 0; ii < StayListName.Count; ii++)
    //{
    //  if (StayListName[ii].text == One.TF.BattlePlayer1 ||
    //      StayListName[ii].text == One.TF.BattlePlayer2 ||
    //      StayListName[ii].text == One.TF.BattlePlayer3 ||
    //      StayListName[ii].text == One.TF.BattlePlayer4 ||
    //      StayListName[ii].text == One.TF.BattlePlayer5 ||
    //      StayListName[ii].text == One.TF.BattlePlayer6)
    //  {
    //    StayListCheckMark[ii].SetActive(true);
    //  }
    //  else
    //  {
    //    StayListCheckMark[ii].SetActive(false);
    //  }
    //}
  }

  private void UpdateTacticsPartyMember(string full_name, int num)
  {
    //if (full_name != string.Empty)
    //{
    //  for (int ii = 0; ii < One.PlayerList.Count; ii++)
    //  {
    //    if (One.PlayerList[ii].FullName == full_name)
    //    {
    //      Character current = One.PlayerList[ii];
    //      PartyListClass[num].sprite = Resources.Load<Sprite>("Unit_" + current?.Job.ToString() ?? "");
    //      PartyListName[num].text = current.FullName;
    //      PartyListLevel[num].text = current.Level.ToString();
    //      PartyListLife[num].text = current.CurrentLife.ToString() + " / " + current.MaxLife.ToString();
    //      PartyListSTR[num].text = current.TotalStrength.ToString();
    //      PartyListAGL[num].text = current.TotalAgility.ToString();
    //      PartyListINT[num].text = current.TotalIntelligence.ToString();
    //      PartyListSTM[num].text = current.TotalStamina.ToString();
    //      PartyListMND[num].text = current.TotalMind.ToString();

    //      foreach (Transform n in GroupPartyList[num].transform)
    //      {
    //        GameObject.Destroy(n.gameObject);
    //      }
    //      List<string> actionList = current.GetActionCommandList();
    //      for (int jj = 0; jj < actionList.Count; jj++)
    //      {
    //        NodeActionCommand instant = Instantiate(prefab_ActionCommand) as NodeActionCommand;
    //        instant.BackColor.color = current.BattleForeColor;
    //        instant.CommandName = actionList[jj];
    //        instant.name = actionList[jj];
    //        instant.OwnerName = current.FullName;
    //        instant.ActionButton.name = actionList[jj];
    //        instant.ActionButton.image.sprite = Resources.Load<Sprite>(actionList[jj]);

    //        //Debug.Log("TapPartyPickChoose: " + TacticsPickupCharacter.ActionCommandList[jj]);
    //        instant.transform.SetParent(GroupPartyList[num].transform);
    //        instant.gameObject.SetActive(true);
    //      }
    //      break;
    //    }
    //  }
    //}
  }

  private void RefreshQuestList()
  {
    // same DungeonField, HomeTown
    foreach (Transform n in contentDungeonPlayer.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    contentDungeonPlayerList.Clear();
    int counter = 0;

    // SeekerModeでクエストは見せない
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      AddQuestEvent("", false, 0);
      return;
    }

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
    if (One.TF.QuestMain_00031) { AddQuestEvent(Fix.QUEST_TITLE_31, One.TF.QuestMain_Complete_00031, counter); counter++; }
    if (One.TF.QuestMain_00041) { AddQuestEvent(Fix.QUEST_TITLE_41, One.TF.QuestMain_Complete_00041, counter); counter++; }
  }

  private void RefreshSelectAreaList()
  {
    foreach (Transform n in contentSelectArea.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    contentSelectAreaList.Clear();
    contentSelectArea.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSelectArea.GetComponent<RectTransform>().sizeDelta.x, 0);
    int counter = 0;

    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      AddSelectArea(Fix.DUNGEON_ESMILIA_GRASSFIELD, true, 0);
      return;
    }

    if (One.TF.QuestMain_00002) { AddSelectArea(Fix.TOWN_ANSHET, true, counter); counter++; }
    if (One.TF.QuestMain_00001) { AddSelectArea(Fix.DUNGEON_ESMILIA_GRASSFIELD, true, counter); counter++; }
    if (One.TF.QuestMain_00002) { AddSelectArea(Fix.TOWN_FAZIL_CASTLE, true, counter); counter++; }
    if (One.TF.QuestMain_00002) { AddSelectArea(Fix.DUNGEON_GORATRUM_CAVE, true, counter); counter++; }
    if (One.TF.Event_Message400030 && One.TF.AvailableBillyRaki) { AddSelectArea(Fix.TOWN_COTUHSYE, true, counter); counter++; }
    if (One.TF.Event_Message400030 && One.TF.AvailableBillyRaki) { AddSelectArea(Fix.DUNGEON_MYSTIC_FOREST, true, counter); counter++; }
    if (One.TF.Event_Message500010) { AddSelectArea(Fix.TOWN_ZHALMAN, true, counter); counter++; }
    if (One.TF.Event_Message700050) { AddSelectArea(Fix.DUNGEON_OHRAN_TOWER, true, counter); counter++; }
    if (One.TF.Event_Message700060) { AddSelectArea(Fix.TOWN_PARMETYSIA, true, counter); counter++; }
    if (One.TF.Event_Message2200020) { AddSelectArea(Fix.DUNGEON_VELGUS_SEA_TEMPLE, true, counter); counter++; }
    if (One.TF.Event_Message1000292) { AddSelectArea(Fix.DUNGEON_VELGUS_SEA_TEMPLE_4, true, counter); counter++; }
    if (One.TF.Event_Message1010030) { AddSelectArea(Fix.DUNGEON_EDELGARZEN_CASTLE, true, counter); counter++; }
    if (One.TF.Event_Message1900157) { AddSelectArea(Fix.DUNGEON_EDELGARZEN_CASTLE_CENTER, true, counter); counter++; }
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
    contentDungeonPlayerList.Add(quest_name);

    ViewQuestEvent(quest_name);

    RectTransform rect = button.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, -5 - counter * 100, 0);
  }

  private void AddSelectArea(string select_area_name, bool available, int counter)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + select_area_name + " " + counter);
    // same DungeonField, HomeTown
    NodeSelectAreaButton button = Instantiate(nodeSelectAreaButton) as NodeSelectAreaButton;
    button.gameObject.transform.SetParent(contentSelectArea.transform);
    button.txtName.text = select_area_name;

    // アイコンの反映
    if (select_area_name == Fix.DUNGEON_ESMILIA_GRASSFIELD) { button.ApplyImageIcon(Fix.DUNGEON_ESMILIA_GRASSFIELD_ICON); }
    else if (select_area_name == Fix.DUNGEON_GORATRUM_CAVE) { button.ApplyImageIcon(Fix.DUNGEON_GORATRUM_CAVE_ICON); }
    else if (select_area_name == Fix.DUNGEON_MYSTIC_FOREST) { button.ApplyImageIcon(Fix.DUNGEON_MYSTIC_FOREST_ICON); }
    else if (select_area_name == Fix.DUNGEON_OHRAN_TOWER) { button.ApplyImageIcon(Fix.DUNGEON_OHRAN_TOWER_ICON); }
    else if (select_area_name == Fix.DUNGEON_VELGUS_SEA_TEMPLE) { button.ApplyImageIcon(Fix.DUNGEON_VELGUS_SEA_TEMPLE_ICON); }
    else if (select_area_name == Fix.DUNGEON_VELGUS_SEA_TEMPLE_2) { button.ApplyImageIcon(Fix.DUNGEON_VELGUS_SEA_TEMPLE_ICON); }
    else if (select_area_name == Fix.DUNGEON_VELGUS_SEA_TEMPLE_3) { button.ApplyImageIcon(Fix.DUNGEON_VELGUS_SEA_TEMPLE_ICON); }
    else if (select_area_name == Fix.DUNGEON_VELGUS_SEA_TEMPLE_4) { button.ApplyImageIcon(Fix.DUNGEON_VELGUS_SEA_TEMPLE_ICON); }
    else if (select_area_name == Fix.DUNGEON_EDELGARZEN_CASTLE) { button.ApplyImageIcon(Fix.DUNGEON_EDELGARZEN_CASTLE_ICON); }
    else if (select_area_name == Fix.DUNGEON_EDELGARZEN_CASTLE_CENTER) { button.ApplyImageIcon(Fix.DUNGEON_EDELGARZEN_CASTLE_CENTER_ICON); }
    else if (select_area_name == Fix.TOWN_ANSHET) { button.ApplyImageIcon(Fix.TOWN_ANSHET_ICON); }
    else if (select_area_name == Fix.TOWN_FAZIL_CASTLE) { button.ApplyImageIcon(Fix.TOWN_FAZIL_CASTLE_ICON); }
    else if (select_area_name == Fix.TOWN_COTUHSYE) { button.ApplyImageIcon(Fix.TOWN_COTUHSYE_ICON); }
    else if (select_area_name == Fix.TOWN_ZHALMAN) { button.ApplyImageIcon(Fix.TOWN_ZHALMAN_ICON); }
    else if (select_area_name == Fix.TOWN_PARMETYSIA) { button.ApplyImageIcon(Fix.TOWN_PARMETYSIA_ICON); }
    else { /* 何もしない */ }

    if (available)
    {
      button.gameObject.SetActive(true);
    }
    else
    {
      button.imgFilter.gameObject.SetActive(true);
    }

    contentSelectAreaList.Add(select_area_name);

    contentSelectArea.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSelectArea.GetComponent<RectTransform>().sizeDelta.x, contentSelectArea.GetComponent<RectTransform>().sizeDelta.y + 100);

    //ViewQuestEvent(select_area_name);

    RectTransform rect = button.GetComponent<RectTransform>();
    rect.anchoredPosition = new Vector2(0, 0);
    rect.localPosition = new Vector3(0, -5 - counter * 100, 0);
  }

  public void ViewSelectAreaEvent(string select_area_name)
  {
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
    if (select_area_name == Fix.TOWN_PARMETYSIA) { txtEventDescription.text = Fix.AREA_INFO_PARMETYSIA; }
    if (select_area_name == Fix.DUNGEON_VELGUS_SEA_TEMPLE) { txtEventDescription.text = Fix.AREA_INFO_VELGUS_SEA_TEMPLE; }
    if (select_area_name == Fix.DUNGEON_VELGUS_SEA_TEMPLE_2) { txtEventDescription.text = Fix.AREA_INFO_VELGUS_SEA_TEMPLE; }
    if (select_area_name == Fix.DUNGEON_VELGUS_SEA_TEMPLE_3) { txtEventDescription.text = Fix.AREA_INFO_VELGUS_SEA_TEMPLE; }
    if (select_area_name == Fix.DUNGEON_VELGUS_SEA_TEMPLE_4) { txtEventDescription.text = Fix.AREA_INFO_VELGUS_SEA_TEMPLE; }
    if (select_area_name == Fix.DUNGEON_EDELGARZEN_CASTLE) { txtEventDescription.text = Fix.AREA_INFO_EDELGARZEN; }
    if (select_area_name == Fix.DUNGEON_EDELGARZEN_CASTLE_2) { txtEventDescription.text = Fix.AREA_INFO_EDELGARZEN; }
    if (select_area_name == Fix.DUNGEON_EDELGARZEN_CASTLE_3) { txtEventDescription.text = Fix.AREA_INFO_EDELGARZEN; }
    if (select_area_name == Fix.DUNGEON_EDELGARZEN_CASTLE_4) { txtEventDescription.text = Fix.AREA_INFO_EDELGARZEN; }
  }
  
  private void ViewQuestEvent(string quest_name)
  {
    // SeekerModeの場合、何もしない
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      return;
    }

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
    if (quest_name == Fix.QUEST_TITLE_31) { txtEventDescription.text = Fix.QUEST_DESC_31; }
    if (quest_name == Fix.QUEST_TITLE_41) { txtEventDescription.text = Fix.QUEST_DESC_41; }

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
      // shopList.Add(new Item(Fix.FINE_BOW)); // 初期メンバー、アイン・ラナのため弓はドロップさせない。
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
      shopList.Add(new Item(Fix.SMALL_GREEN_POTION));
      if (One.AR.EquipAvailable_11) { shopList.Add(new Item(Fix.WOLF_CROSS)); }
      if (One.AR.EquipAvailable_12) { shopList.Add(new Item(Fix.KOUKAKU_ARMOR)); }
      if (One.AR.EquipAvailable_13) { shopList.Add(new Item(Fix.STRIDE_WAR_SWORD)); }
      if (One.AR.PotionAvailable_11) { shopList.Add(new Item(Fix.POTION_RESIST_FIRE)); }
      if (One.AR.PotionAvailable_12) { shopList.Add(new Item(Fix.CURE_SEAL)); }
      if (One.AR.PotionAvailable_13) { shopList.Add(new Item(Fix.POTION_MAGIC_SEAL)); }
    }
    if (area_name == Fix.TOWN_FAZIL_CASTLE)
    {
      shopList.Add(new Item(Fix.CLASSICAL_SWORD));
      shopList.Add(new Item(Fix.CLASSICAL_CLAW));
      shopList.Add(new Item(Fix.CLASSICAL_LANCE));
      shopList.Add(new Item(Fix.CLASSICAL_AXE));
      shopList.Add(new Item(Fix.CLASSICAL_ROD));
      shopList.Add(new Item(Fix.CLASSICAL_BOOK));
      shopList.Add(new Item(Fix.CLASSICAL_ORB));
      shopList.Add(new Item(Fix.CLASSICAL_BOW));
      shopList.Add(new Item(Fix.CLASSICAL_SHIELD));
      shopList.Add(new Item(Fix.CLASSICAL_ARMOR));
      shopList.Add(new Item(Fix.CLASSICAL_CROSS));
      shopList.Add(new Item(Fix.CLASSICAL_ROBE));
      shopList.Add(new Item(Fix.RED_AMULET));
      shopList.Add(new Item(Fix.BLUE_AMULET));
      shopList.Add(new Item(Fix.PURPLE_AMULET));
      shopList.Add(new Item(Fix.GREEN_AMULET));
      shopList.Add(new Item(Fix.YELLOW_AMULET));
      shopList.Add(new Item(Fix.ASH_EXCLUDE_LANCE));
      shopList.Add(new Item(Fix.STAR_FUSION_ORB));
      shopList.Add(new Item(Fix.ROIZ_IMPERIAL_ARMOR));
      shopList.Add(new Item(Fix.CROWD_DIRGE_ROBE));
      shopList.Add(new Item(Fix.FIVECOLOR_COMPASS));
      shopList.Add(new Item(Fix.LIGHT_HAKURUANGEL_STATUE));
      shopList.Add(new Item(Fix.NORMAL_RED_POTION));
      shopList.Add(new Item(Fix.NORMAL_BLUE_POTION));
      shopList.Add(new Item(Fix.NORMAL_GREEN_POTION));
      if (One.AR.EquipAvailable_21) { shopList.Add(new Item(Fix.DENDO_DRILL_AXE)); }
      if (One.AR.EquipAvailable_22) { shopList.Add(new Item(Fix.ATTACH_SPIRAL_ORB)); }
      if (One.AR.EquipAvailable_23) { shopList.Add(new Item(Fix.THIN_STEEL_BUCKLER)); }
      if (One.AR.EquipAvailable_24) { shopList.Add(new Item(Fix.TETRA_EYE_BIGROD)); }
      if (One.AR.PotionAvailable_21) { shopList.Add(new Item(Fix.POTION_RESIST_PLUS)); }
      if (One.AR.PotionAvailable_22) { shopList.Add(new Item(Fix.TOTAL_HIYAKU_KASSEI)); }
      if (One.AR.PotionAvailable_23) { shopList.Add(new Item(Fix.TOTAL_HIYAKU_JOUSEI)); }
      if (One.AR.PotionAvailable_24) { shopList.Add(new Item(Fix.PATERMA_DISMAGIC_DRINK)); }

      //// todo
      //if (false)
      //{
      //  //shopList.Add(new Item(Fix.BASTARD_SWORD));
      //  shopList.Add(new Item(Fix.AERO_BLADE));
      //  shopList.Add(new Item(Fix.MASTER_SWORD));
      //  shopList.Add(new Item(Fix.MASTER_SHIELD));
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
      // shopList.Add(new Item(Fix.SMART_BOW)); // 神秘の森で弓をドロップさせないのでコチューシェでも販売しない。
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
      shopList.Add(new Item(Fix.GALLANT_FEATHER_LANCE));
      shopList.Add(new Item(Fix.ARANDEL_FORCE_ARMOR));
      shopList.Add(new Item(Fix.MIRAGE_PLASMA_EARRING));
      shopList.Add(new Item(Fix.MIST_WAVE_GAUNTLET));
      shopList.Add(new Item(Fix.LARGE_RED_POTION));
      shopList.Add(new Item(Fix.LARGE_BLUE_POTION));
      shopList.Add(new Item(Fix.LARGE_GREEN_POTION));
      if (One.AR.EquipAvailable_31) { shopList.Add(new Item(Fix.SILENT_OLGA_CLAW)); }
      if (One.AR.EquipAvailable_32) { shopList.Add(new Item(Fix.IRIDESCENT_CLOUD_FEATHER)); }
      if (One.AR.PotionAvailable_31) { shopList.Add(new Item(Fix.SOUKAI_DRINK_SS)); }
    }
    else if (area_name == Fix.TOWN_ZHALMAN)
    {
      shopList.Add(new Item(Fix.SUPERIOR_SWORD));
      shopList.Add(new Item(Fix.SUPERIOR_LANCE));
      shopList.Add(new Item(Fix.SUPERIOR_AXE));
      shopList.Add(new Item(Fix.SUPERIOR_CLAW));
      shopList.Add(new Item(Fix.SUPERIOR_ROD));
      shopList.Add(new Item(Fix.SUPERIOR_BOOK));
      shopList.Add(new Item(Fix.SUPERIOR_ORB));
      shopList.Add(new Item(Fix.SUPERIOR_LARGE_SWORD));
      shopList.Add(new Item(Fix.SUPERIOR_LARGE_LANCE));
      shopList.Add(new Item(Fix.SUPERIOR_LARGE_AXE));
      shopList.Add(new Item(Fix.SUPERIOR_BOW));
      shopList.Add(new Item(Fix.SUPERIOR_LARGE_STAFF));
      shopList.Add(new Item(Fix.SUPERIOR_SHIELD));
      shopList.Add(new Item(Fix.SUPERIOR_ARMOR));
      shopList.Add(new Item(Fix.SUPERIOR_CROSS));
      shopList.Add(new Item(Fix.SUPERIOR_ROBE));
      shopList.Add(new Item(Fix.STEEL_RING_POWER));
      shopList.Add(new Item(Fix.STEEL_RING_SENSE));
      shopList.Add(new Item(Fix.STEEL_RING_FAST));
      shopList.Add(new Item(Fix.STEEL_RING_DEEP));
      shopList.Add(new Item(Fix.STEEL_RING_BOUND));
      shopList.Add(new Item(Fix.EARTH_SHARD_CLAW));
      shopList.Add(new Item(Fix.BLOOD_STUBBORN_SPEAR));
      shopList.Add(new Item(Fix.EMBLEM_OF_VALKYRIE));
      shopList.Add(new Item(Fix.ZELMAN_THE_ONSLAUGHT_BASTER));
      shopList.Add(new Item(Fix.LIFEGRACE_FORTUNE_STAFF));
      shopList.Add(new Item(Fix.WHITEVEIL_QUEENS_ROBE));
      shopList.Add(new Item(Fix.KODAIEIJU_GREEN_LEAF));
      shopList.Add(new Item(Fix.HUGE_RED_POTION));
      shopList.Add(new Item(Fix.HUGE_BLUE_POTION));
      shopList.Add(new Item(Fix.HUGE_GREEN_POTION));
    }
    else if (area_name == Fix.TOWN_PARMETYSIA)
    {
      shopList.Add(new Item(Fix.MASTER_SWORD));
      shopList.Add(new Item(Fix.MASTER_LANCE));
      shopList.Add(new Item(Fix.MASTER_AXE));
      shopList.Add(new Item(Fix.MASTER_CLAW));
      shopList.Add(new Item(Fix.MASTER_ROD));
      shopList.Add(new Item(Fix.MASTER_BOOK));
      shopList.Add(new Item(Fix.MASTER_ORB));
      shopList.Add(new Item(Fix.MASTER_LARGE_SWORD));
      shopList.Add(new Item(Fix.MASTER_LARGE_LANCE));
      shopList.Add(new Item(Fix.MASTER_LARGE_AXE));
      shopList.Add(new Item(Fix.MASTER_BOW));
      shopList.Add(new Item(Fix.MASTER_LARGE_STAFF));
      shopList.Add(new Item(Fix.MASTER_SHIELD));
      shopList.Add(new Item(Fix.MASTER_ARMOR));
      shopList.Add(new Item(Fix.MASTER_CROSS));
      shopList.Add(new Item(Fix.MASTER_ROBE));
      shopList.Add(new Item(Fix.BLACKROGUE_BLACKROGUE_AMBIDEXTARITY_DAGGER));
      shopList.Add(new Item(Fix.HOLY_BLESSING_SHIELD));
      shopList.Add(new Item(Fix.LATA_GUARDIAN_RING));
      shopList.Add(new Item(Fix.BLUEEYE_TEMPLE_PENDANT));
      shopList.Add(new Item(Fix.REDEYE_TEMPLE_PENDANT));
      shopList.Add(new Item(Fix.HQ_RED_POTION));
      shopList.Add(new Item(Fix.HQ_BLUE_POTION));
      shopList.Add(new Item(Fix.HQ_GREEN_POTION));
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
      if (One.AR.FoodAvailable_11) { foodList.Add(Fix.FOOD_TSIKARA_UDON); }
      if (One.AR.FoodAvailable_12) { foodList.Add(Fix.FOOD_ZUNOU_FLY_SET); }
      if (One.AR.FoodAvailable_13) { foodList.Add(Fix.FOOD_SPEED_SOBA); }
    }
    else if (area_name == Fix.TOWN_FAZIL_CASTLE)
    {
      foodList.Add(Fix.FOOD_KATUCARRY);
      foodList.Add(Fix.FOOD_OLIVE_AND_ONION);
      if (One.AR.FoodAvailable_21) { foodList.Add(Fix.FOOD_INAGO_AND_TAMAGO); }
      if (One.AR.FoodAvailable_22) { foodList.Add(Fix.FOOD_USAGI); }
      if (One.AR.FoodAvailable_23) { foodList.Add(Fix.FOOD_SANMA); }
    }
    else if (area_name == Fix.TOWN_COTUHSYE)
    {
      foodList.Add(Fix.FOOD_FISH_GURATAN);
      foodList.Add(Fix.FOOD_SEA_TENPURA);
      if (One.AR.FoodAvailable_31) { foodList.Add(Fix.FOOD_TRUTH_YAMINABE_1); }
      if (false) { foodList.Add(Fix.FOOD_OSAKANA_ZINGISKAN); }
      if (false) { foodList.Add(Fix.FOOD_RED_HOT_SPAGHETTI); }
    }
    else if (area_name == Fix.TOWN_ZHALMAN)
    {
      foodList.Add(Fix.FOOD_TOBIUSAGI_ROAST);
      foodList.Add(Fix.FOOD_WATARI_KAMONABE);
      foodList.Add(Fix.FOOD_SYOI_KINOKO_SUGATAYAKI);
      foodList.Add(Fix.FOOD_NEGIYAKI_DON);
      foodList.Add(Fix.FOOD_NANAIRO_BUNA_NITSUKE);
    }
    else if (area_name == Fix.TOWN_PARMETYSIA)
    {
      foodList.Add(Fix.FOOD_HINYARI_YASAI);
      foodList.Add(Fix.FOOD_AZARASI_SHIOYAKI);
      foodList.Add(Fix.FOOD_WINTER_BEEF_CURRY);
      foodList.Add(Fix.FOOD_GATTURI_GOZEN);
      foodList.Add(Fix.FOOD_KOGOERU_DESSERT);
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