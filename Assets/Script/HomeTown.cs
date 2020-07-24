using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class HomeTown : MotherBase
{
  // HomeTown
  public GameObject objBlackOut;
  public Text txtDate;
  public Text txtArea;
  public Text txtGold;
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
  public GameObject contentShopItem;
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

  // Inn
  public GameObject GroupInn;

  // Quest Message
  public GameObject GroupQuestMessage;
  public Text txtQuestMessage;
  public GameObject panelSystemMessage;
  public Text txtSystemMessage;

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
  public Text txtFireBolt;
  public Text txtFlameBlade;
  public Text txtMeteorBullet;
  public Text txtFlameStrike;
  public Text txtLavaAnnihilation;

  public GameObject groupDecision;
  public Image imgCurrentDecision;
  public Text txtDecisionTitle;
  public Text txtDecisionMessage;
  public Button btnDecisionAccept;
  public Button btnDecisionCancel;
  public Button btnDecisionOK;

  // Menu Button
  public Button btnCustomEvent1;
  public Text txtCustomEvent1;
  public Button btnCustomEvent2;
  public Text txtCustomEvent2;

  public GameObject groupNowLoading;
  public SaveLoad groupSaveLoad;

  // Inner Value
  protected List<NodeCharaView> CharaViewList = new List<NodeCharaView>();
  protected Character CurrentPlayer = null;
  protected Character ShadowPlayer = null;
  protected string CurrentItemType = String.Empty;

  protected List<string> QuestMessageList = new List<string>();
  protected List<MessagePack.ActionEvent> QuestEventList = new List<MessagePack.ActionEvent>();

  List<NodeShopItem> ShopItemList = new List<NodeShopItem>();
  List<NodeBackpackItem> BackpackList = new List<NodeBackpackItem>();

  protected Item CurrentSelectBackpack;

  protected bool FirstAction = false;
    
  // Use this for initialization
  public override void Start()
  {
    base.Start();

    One.TF.SaveByDungeon = false;

    // 初期画面設定
    RefreshAllView();

    // イベント進行
    if (One.TF.Event_Message100010 == false)
    {
      One.TF.Event_Message100010 = true;
      MessagePack.Message100010(ref QuestMessageList, ref QuestEventList);
      TapOK();

      objBlackOut.SetActive(true);
      GroupQuestMessage.SetActive(true);
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE)
    {
      if (One.TF.Event_Message100020 == false)
      {
        One.TF.Event_Message100020 = true;
        MessagePack.Message100020(ref QuestMessageList, ref QuestEventList);
        TapOK();
        return;
      }

      if (One.TF.Event_Message500020 && One.TF.Event_Message700010 == false)
      {
        MessagePack.Message700010(ref QuestMessageList, ref QuestEventList); TapOK();
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
    else
    {
      txtMessage.text = "アイン：さて、何すっかな。";
    }
  }

  // Update is called once per frame
  public void Update()
  {
    if (this.FirstAction == false)
    {
      this.FirstAction = true;
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

  public void TapDungeonPlayer()
  {
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

    GroupDungeonPlayer.SetActive(true);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupInn.SetActive(false);
  }

  public void TapCharacter()
  {
    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(true);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupInn.SetActive(false);
  }
  public void TapBackpack()
  {
    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(true);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupInn.SetActive(false);
  }
  public void TapShop()
  {
    if (One.TF.Event_Message100020 == false)
    {
      MessagePack.Message100015(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }
    if (One.TF.CurrentAreaName == Fix.TOWN_QVELTA_TOWN && One.TF.Event_Message200040 && One.TF.Event_Message200050 == false && One.TF.QuestMain_00010 && One.TF.QuestMain_Complete_00010 == false)
    {
      MessagePack.Message200050(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }

    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(true);
    GroupActionCommandSetting.SetActive(false);
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

    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(true);
    GroupInn.SetActive(false);
  }

  public void TapInn()
  {
    if (One.TF.Event_Message100020 == false)
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

    GroupDungeonPlayer.SetActive(false);
    GroupCharacter.SetActive(false);
    GroupBackpack.SetActive(false);
    GroupShopItem.SetActive(false);
    GroupActionCommandSetting.SetActive(false);
    GroupInn.SetActive(true);
  }

  public void TapCustomEvent1()
  {
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
  }

  public void TapCustomEvent2()
  {

    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE && One.TF.Event_Message400030 == false)
    {
      MessagePack.Message400030(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
    else
    {
      MessagePack.Message400021(ref QuestMessageList, ref QuestEventList); TapOK();
      return;
    }
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

    //if (One.TF.AlreadyDungeon)
    //{
    //  txtMessage.text = "アイン：今、外から入ったばかリだ。少しは休まないとな。";
    //  return;
    //}

    One.TF.AlreadyDungeon = true;
    One.TF.AlreadyRestInn = false;
    groupNowLoading.SetActive(true);

    // todo
    if (One.TF.CurrentAreaName == Fix.TOWN_ANSHET)
    {
      One.TF.Field_X = -44.0f;
      One.TF.Field_Y = 2.0f;
      One.TF.Field_Z = 4.0f;
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE)
    {
      One.TF.Field_X = -49.0f;
      One.TF.Field_Y = 5.0f;
      One.TF.Field_Z = 17.0f;
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_QVELTA_TOWN)
    {
      One.TF.Field_X = 24.0f;
      One.TF.Field_Y = 1.0f;
      One.TF.Field_Z = 3.0f;
    }
    SceneDimension.JumpToDungeonField(Fix.MAPFILE_BASE_FIELD);
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
    GroupCharacterDetail.parentMotherBase = this;
    GroupCharacterDetail.ReleaseIt();
    GroupCharacterDetail.CurrentPlayer = this.CurrentPlayer;
    GroupCharacterDetail.UpdateCharacterDetailView(this.CurrentPlayer);
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
    if (imgCurrentDecision.name == Fix.FIRE_BOLT) { CurrentPlayer.FireBolt++; }
    else if (imgCurrentDecision.name == Fix.FLAME_BLADE) { CurrentPlayer.FlameBlade++; }
    else if (imgCurrentDecision.name == Fix.METEOR_BULLET) { CurrentPlayer.MeteorBullet++; }
    else if (imgCurrentDecision.name == Fix.FLAME_STRIKE) { CurrentPlayer.FlameStrike++; }
    else if (imgCurrentDecision.name == Fix.LAVA_ANNIHILATION) { CurrentPlayer.LavaAnnihilation++; }
    else if (imgCurrentDecision.name == Fix.ICE_NEEDLE) { CurrentPlayer.IceNeedle++; }
    else if (imgCurrentDecision.name == Fix.PURE_PURIFICATION) { CurrentPlayer.PurePurification++; }
    else if (imgCurrentDecision.name == Fix.BLUE_BULLET) { CurrentPlayer.BlueBullet++; }
    else if (imgCurrentDecision.name == Fix.FREEZING_CUBE) { CurrentPlayer.FreezingCube++; }
    else if (imgCurrentDecision.name == Fix.FROST_LANCE) { CurrentPlayer.FrostLance++; }
    else if (imgCurrentDecision.name == Fix.FRESH_HEAL) { CurrentPlayer.FreshHeal++; }
    else if (imgCurrentDecision.name == Fix.DIVINE_CIRCLE) { CurrentPlayer.DivineCircle++; }
    else if (imgCurrentDecision.name == Fix.HOLY_BREATH) { CurrentPlayer.HolyBreath++; }
    else if (imgCurrentDecision.name == Fix.SANCTION_FIELD) { CurrentPlayer.SanctionField++; }
    else if (imgCurrentDecision.name == Fix.VALKYRIE_BREAK) { CurrentPlayer.ValkyrieBreak++; }
    else if (imgCurrentDecision.name == Fix.SHADOW_BLAST) { CurrentPlayer.ShadowBlast++; }
    else if (imgCurrentDecision.name == Fix.BLOOD_SIGN) { CurrentPlayer.BloodSign++; }
    else if (imgCurrentDecision.name == Fix.DEATH_SCYTHE) { CurrentPlayer.DeathScythe++; }
    else if (imgCurrentDecision.name == Fix.WHISPER_VOICE) { CurrentPlayer.WhisperVoice++; }
    else if (imgCurrentDecision.name == Fix.ABYSS_EYE) { CurrentPlayer.AbyssEye++; }
    else if (imgCurrentDecision.name == Fix.STRAIGHT_SMASH) { CurrentPlayer.StraightSmash++; }
    else if (imgCurrentDecision.name == Fix.STANCE_OF_THE_BLADE) { CurrentPlayer.StanceOfTheBlade++; }
    else if (imgCurrentDecision.name == Fix.DOUBLE_SLASH) { CurrentPlayer.DoubleSlash++; }
    else if (imgCurrentDecision.name == Fix.WAR_SWING) { CurrentPlayer.WarSwing++; }
    else if (imgCurrentDecision.name == Fix.KINETIC_SMASH) { CurrentPlayer.KineticSmash++; }
    else if (imgCurrentDecision.name == Fix.SHIELD_BASH) { CurrentPlayer.ShieldBash++; }
    else if (imgCurrentDecision.name == Fix.STANCE_OF_THE_GUARD) { CurrentPlayer.StanceOfTheGuard++; }
    else if (imgCurrentDecision.name == Fix.CONCUSSIVE_HIT) { CurrentPlayer.ConcussiveHit++; }
    else if (imgCurrentDecision.name == Fix.DOMINATION_FIELD) { CurrentPlayer.DominationField++; }
    else if (imgCurrentDecision.name == Fix.OATH_OF_AEGIS) { CurrentPlayer.OathOfAegis++; }
    else if (imgCurrentDecision.name == Fix.HUNTER_SHOT) { CurrentPlayer.HunterShot++; }
    else if (imgCurrentDecision.name == Fix.MULTIPLE_SHOT) { CurrentPlayer.MultipleShot++; }
    else if (imgCurrentDecision.name == Fix.REACHABLE_TARGET) { CurrentPlayer.ReachableTarget++; }
    else if (imgCurrentDecision.name == Fix.HAWK_EYE) { CurrentPlayer.HawkEye++; }
    else if (imgCurrentDecision.name == Fix.PIERCING_ARROW) { CurrentPlayer.PiercingArrow++; }
    else if (imgCurrentDecision.name == Fix.VENOM_SLASH) { CurrentPlayer.VenomSlash++; }
    else if (imgCurrentDecision.name == Fix.INVISIBLE_BIND) { CurrentPlayer.InvisibleBind++; }
    else if (imgCurrentDecision.name == Fix.IRREGULAR_STEP) { CurrentPlayer.IrregularStep++; }
    else if (imgCurrentDecision.name == Fix.DISSENSION_RHYTHM) { CurrentPlayer.DissensionRhythm++; }
    else if (imgCurrentDecision.name == Fix.ASSASSINATION_HIT) { CurrentPlayer.AssassinationHit++; }
    else if (imgCurrentDecision.name == Fix.AURA_OF_POWER) { CurrentPlayer.AuraOfPower++; }
    else if (imgCurrentDecision.name == Fix.SKY_SHIELD) { CurrentPlayer.SkyShield++; }
    else if (imgCurrentDecision.name == Fix.STORM_ARMOR) { CurrentPlayer.StormArmor++; }
    else if (imgCurrentDecision.name == Fix.AETHER_DRIVE) { CurrentPlayer.AetherDrive++; }
    else if (imgCurrentDecision.name == Fix.RUNE_STRIKE) { CurrentPlayer.RuneStrike++; }
    else if (imgCurrentDecision.name == Fix.DISPEL_MAGIC) { CurrentPlayer.DispelMagic++; }
    else if (imgCurrentDecision.name == Fix.FLASH_COUNTER) { CurrentPlayer.FlashCounter++; }
    else if (imgCurrentDecision.name == Fix.MUTE_IMPULSE) { CurrentPlayer.MuteImpulse++; }
    else if (imgCurrentDecision.name == Fix.DETACHMENT_FAULT) { CurrentPlayer.DetachmentFault++; }
    else if (imgCurrentDecision.name == Fix.PHANTOM_OBORO) { CurrentPlayer.PhantomOboro++; }
    else if (imgCurrentDecision.name == Fix.HEART_OF_LIFE) { CurrentPlayer.HeartOfLife++; }
    else if (imgCurrentDecision.name == Fix.FORTUNE_SPIRIT) { CurrentPlayer.FortuneSpirit++; }
    else if (imgCurrentDecision.name == Fix.VOICE_OF_VIGOR) { CurrentPlayer.VoiceOfVigor++; }
    else if (imgCurrentDecision.name == Fix.SIGIL_OF_THE_FAITH) { CurrentPlayer.SigilOfTheFaith++; }
    else if (imgCurrentDecision.name == Fix.RAGING_STORM) { CurrentPlayer.RagingStorm++; }
    else if (imgCurrentDecision.name == Fix.ORACLE_COMMAND) { CurrentPlayer.OracleCommand++; }
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
    SelectShopItem(shopItem);
  }

  public void TapBuyItem(Text txt)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + txt.text);
    Item current = new Item(txt.text);
    if (One.TF.Gold < current.Gold)
    {
      int diff = current.Gold - One.TF.Gold;
      imgBuy.sprite = Resources.Load<Sprite>(txt.text);
      imgBuy.name = txt.text;
      txtBuyTitle.text = txt.text + " を購入する事ができません。";
      txtBuyMessage.text = "ゴールドがあと" + diff.ToString() + " 不足しています。ゴールドを入手してください。";
      btnBuyAccept.gameObject.SetActive(false);
      btnBuyCancel.gameObject.SetActive(false);
      btnBuyOK.gameObject.SetActive(true);
    }
    else
    {
      imgBuy.sprite = Resources.Load<Sprite>(txt.text);
      imgBuy.name = txt.text;
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
    // todo
    Item current = new Item(imgBuy.name);

    One.TF.AddBackPack(current);
    One.TF.Gold -= current.Gold;
    txtGold.text = One.TF.Gold.ToString();

    ConstructBackpackView();

    groupBuyDecision.SetActive(false);
    imgBuy.sprite = null;
    txtBuyTitle.text = string.Empty;
    txtBuyMessage.text = string.Empty;
  }
  public void TapBuyCancel()
  {
    groupBuyDecision.SetActive(false);
    imgBuy.sprite = null;
    txtBuyTitle.text = string.Empty;
    txtBuyMessage.text = string.Empty;
  }

  public void TapRestInn()
  {
    if (One.TF.AlreadyRestInn)
    {
      MessagePack.MessageX00002(ref QuestMessageList, ref QuestEventList);
      TapOK();
      return;
    }

    for (int ii = 0; ii < One.PlayerList.Count; ii++)
    {
      One.PlayerList[ii].MaxGain();
    }
    One.TF.AlreadyRestInn = true;
    One.TF.AlreadyDungeon = false;
    One.TF.EscapeFromDungeon = false;
    RefreshAllView();
    this.GroupInn.SetActive(false);

    MessagePack.MessageX00001(ref QuestMessageList, ref QuestEventList);
    TapOK();
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

        // ブラックアウトしている画面から元に戻す。
        if (currentEvent == MessagePack.ActionEvent.ReturnToNormal)
        {
          this.objBlackOut.SetActive(false);
          continue; // 継続
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
          RefreshQuestList();
          return;
        }
        // 新しいメンバーを加える。
        else if (currentEvent == MessagePack.ActionEvent.HomeTownAddNewCharacter)
        {
          if (currentMessage.Contains(Fix.NAME_EONE_FULNEA))
          {
            One.TF.AvailableEoneFulnea = true;
          }
          else if (currentMessage.Contains(Fix.NAME_BILLY_RAKI))
          {
            One.TF.AvailableBillyRaki = true;
          }

          List<Character> current = One.AvailableCharacters();
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
        else if (currentEvent == MessagePack.ActionEvent.GetItem)
        {
          Debug.Log("event: " + currentEvent.ToString() + " " + currentMessage);
          One.TF.AddBackPack(new Item(currentMessage));
          ConstructBackpackView();
          continue; // 継続
        }
        else if (currentEvent == MessagePack.ActionEvent.GetGold)
        {
          Debug.Log("event: " + currentEvent.ToString() + " " + currentMessage);
          One.TF.Gold += Convert.ToInt32(currentMessage);
          txtGold.text = One.TF.Gold.ToString();
          continue; // 継続
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
      if (totalValue > 0)
      {
        Debug.Log("Detect totalValue: " + totalValue.ToString());
        attributeList[ii].lockPanel.SetActive(false);
        attributeList[ii].txtName.text = attributeList[ii].CommandAttribute.ToString();
        attributeList[ii].txtTotal.text = "Lv" + totalValue;
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
            attributeList[ii].txtACPlus[jj].text = "+" + attrPlus[jj].ToString();
          }
          else
          {
            attributeList[ii].txtACPlus[jj].text = String.Empty;
          }
        }
      }
      else
      {
        Debug.Log("totalValue: " + totalValue.ToString() + " then, lockPanel on");
        attributeList[ii].lockPanel.SetActive(true);
        attributeList[ii].txtName.text = String.Empty;
        attributeList[ii].txtTotal.text = String.Empty;
        attributeList[ii].background.color = new Color(0.5f, 0.5f, 0.5f);
        for (int jj = 0; jj < attributeList[ii].imgACElement.Count; jj++)
        {
          attributeList[ii].imgACElement[jj].sprite = Resources.Load<Sprite>(Fix.Stay);
        }
        for (int jj = 0; jj < attributeList[ii].txtACElement.Count; jj++)
        {
          attributeList[ii].txtACElement[jj].text = string.Empty;
        }
        for (int jj = 0; jj < attributeList[ii].txtACPlus.Count; jj++)
        {
          attributeList[ii].txtACPlus[jj].text = string.Empty;
        }
      }
    }
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

  private NodeShopItem CreateShopItem(GameObject content, Item item, int num)
  {
    NodeShopItem shopItem = Instantiate(nodeShopItem) as NodeShopItem;

    shopItem.transform.SetParent(content.transform);
    shopItem.txtName.text = item.ItemName;
    shopItem.imgItem.sprite = Resources.Load<Sprite>("Icon_" + item?.ItemType.ToString() ?? "");

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

  private void ConstructBackpackView()
  {
    foreach (Transform n in ContentBackpack.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    ContentBackpack.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    BackpackList.Clear();
    for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
    {
      NodeBackpackItem current = Instantiate(nodeBackpackItem) as NodeBackpackItem;
      current.Construct(ContentBackpack, One.TF.BackpackList[ii].ItemName, One.TF.BackpackList[ii].StackValue, ii);
      BackpackList.Add(current);
    }
  }

  private void SelectShopItem(NodeShopItem shopItem)
  {
    Item item = new Item(shopItem.txtName.text);

    for (int ii = 0; ii < ShopItemList.Count; ii++)
    {
      ShopItemList[ii].imgSelect.gameObject.SetActive(false);
    }
    shopItem.imgSelect.gameObject.SetActive(true);

    SetupItemDetail(item, imgItem, txtItemName, txtItemType, txtItemDesc, txtItemSTR, txtItemAGL, txtItemINT, txtItemSTM, txtItemMND, txtItemPA, txtItemPAMax, txtItemPD, txtItemMA, txtItemMAMax, txtItemMD, txtItemACC, txtItemSPD, txtItemRSP, txtItemPO, imgItemSTR, imgItemAGL, imgItemINT, imgItemSTM, imgItemMND, imgItemPA, imgItemPAMax, imgItemPD, imgItemMA, imgItemMAMax, imgItemMD, imgItemACC, imgItemSPD, imgItemRSP, imgItemPO);
    txtItemGoldCost.text = item.Gold.ToString() + " Gold";
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

  public void TapBackpackSelect(NodeBackpackItem backpack)
  {
    Debug.Log("TapBackpackSelect(S)");
    this.CurrentSelectBackpack = new Item(backpack.txtName.text);

    for (int ii = 0; ii < BackpackList.Count; ii++)
    {
      Debug.Log("BackpackList: " + BackpackList[ii].txtName.text);
      BackpackList[ii].imgSelect.gameObject.SetActive(false);
    }
    backpack.imgSelect.gameObject.SetActive(true);
  }

  public void TapBackpackUse()
  {
    string current = (CurrentSelectBackpack?.ItemName ?? String.Empty);
    if (current == Fix.SMALL_RED_POTION)
    {
      Debug.Log("CurrentSelectBackpack: " + current + " is not use in hometown, then no action.");
    }
  }

  public void TapBackpackDetail()
  {
    if (this.CurrentSelectBackpack != null)
    {
      SetupItemDetail(this.CurrentSelectBackpack, imgItemDetail, txtItemDetailName, txtItemDetailType, txtItemDetailDesc, txtItemDetailSTR, txtItemDetailAGL, txtItemDetailINT, txtItemDetailSTM, txtItemDetailMND, txtItemDetailPA, txtItemDetailPAMax, txtItemDetailPD, txtItemDetailMA, txtItemDetailMAMax, txtItemDetailMD, txtItemDetailACC, txtItemDetailSPD, txtItemDetailRSP, txtItemDetailPO, imgItemDetailSTR, imgItemDetailAGL, imgItemDetailINT, imgItemDetailSTM, imgItemDetailMND, imgItemDetailPA, imgItemDetailPAMax, imgItemDetailPD, imgItemDetailMA, imgItemDetailMAMax, imgItemDetailMD, imgItemDetailACC, imgItemDetailSPD, imgItemDetailRSP, imgItemDetailPO);
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

  public override void RefreshAllView()
  {
    // エリア情報
    txtArea.text = One.TF.CurrentAreaName;

    // DungeonPlayerのクエストリストを設定
    RefreshQuestList();

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
    if (One.TF.CurrentAreaName == Fix.TOWN_COTUHSYE)
    {
      btnCustomEvent1.gameObject.SetActive(true);
      txtCustomEvent1.text = "船着き場";
      btnCustomEvent2.gameObject.SetActive(true);
      txtCustomEvent2.text = "街はずれ";
    }
    else if (One.TF.CurrentAreaName == Fix.TOWN_ZHALMAN)
    {
      btnCustomEvent1.gameObject.SetActive(true);
      txtCustomEvent1.text = "長老の家";
      btnCustomEvent2.gameObject.SetActive(false);
      txtCustomEvent2.text = "";
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
    List<Character> currentList = One.AvailableCharacters();
    for (int ii = 0; ii < currentList.Count; ii++)
    {
      NodeCharaView charaView = Instantiate(nodeCharaView) as NodeCharaView;
      CharaViewList.Add(charaView);
      CreateCharaView(contentCharacter, charaView, currentList[ii], ii);
    }

    // チームのリソース(GoldやObsidianStone)を画面へ反映
    txtGold.text = One.TF.Gold.ToString();
    //txtSoulFragment.text = One.TF.SoulFragment.ToString();
    txtObsidianStone.text = One.TF.ObsidianStone.ToString();

    // バックパック情報を画面へ反映
    ConstructBackpackView();

    this.CurrentPlayer = One.PlayerList[0];

    // アクションコマンド設定情報を画面へ反映
    foreach (Transform n in ContentMiniChara.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    List<Character> available = One.AvailableCharacters();
    for (int ii = 0; ii < available.Count; ii++)
    {
      CreateMiniCharaIcon(available[ii]);
    }
    UpdateActionCommandSetting(this.CurrentPlayer);

    // ショップアイテムを設定
    List<Item> shopList = new List<Item>();
    if (One.TF.CurrentAreaName == Fix.TOWN_FAZIL_CASTLE)
    {
      shopList.Add(new Item(Fix.FINE_SWORD));
      shopList.Add(new Item(Fix.FINE_CLAW));
      shopList.Add(new Item(Fix.FINE_ORB));
      shopList.Add(new Item(Fix.FINE_ARMOR));
      shopList.Add(new Item(Fix.FINE_CROSS));
      shopList.Add(new Item(Fix.FINE_ROBE));
      shopList.Add(new Item(Fix.FINE_SHIELD));
      shopList.Add(new Item(Fix.RED_PENDANT));
      shopList.Add(new Item(Fix.BLUE_PENDANT));
      shopList.Add(new Item(Fix.PURPLE_PENDANT));
      shopList.Add(new Item(Fix.GREEN_PENDANT));
      shopList.Add(new Item(Fix.YELLOW_PENDANT));
      shopList.Add(new Item(Fix.SMALL_RED_POTION));

      // todo
      if (false)
      {
        shopList.Add(new Item(Fix.FINE_LANCE));
        shopList.Add(new Item(Fix.FINE_AXE));
        shopList.Add(new Item(Fix.FINE_BOW));
        shopList.Add(new Item(Fix.FINE_ROD));
        shopList.Add(new Item(Fix.FINE_BOOK));
        //shopList.Add(new Item(Fix.BASTARD_SWORD));
        shopList.Add(new Item(Fix.AERO_BLADE));
        shopList.Add(new Item(Fix.GEAR_GENSEI));
        shopList.Add(new Item(Fix.MASTER_SWORD));
        shopList.Add(new Item(Fix.MASTER_SHIELD));
        shopList.Add(new Item(Fix.EDIL_BLACK_BLADE));
        shopList.Add(new Item(Fix.WHITE_PARGE_LANCE));
        shopList.Add(new Item(Fix.ICE_SPIRIT_LANCE));
      }
    }
    ShopItemList.Clear();
    for (int ii = 0; ii < shopList.Count; ii++)
    {
      ShopItemList.Add(CreateShopItem(contentShopItem, shopList[ii], ii));
    }
    contentShopItem.GetComponent<RectTransform>().sizeDelta = new Vector2(contentShopItem.GetComponent<RectTransform>().sizeDelta.x + 20, contentShopItem.GetComponent<RectTransform>().sizeDelta.y);
    if (ShopItemList.Count > 0)
    {
      SelectShopItem(ShopItemList[0]);
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
  }
}