using System.Collections;
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

public class GroupCharacterStatus : MonoBehaviour
{
  public Character CurrentPlayer = null;
  public Character ShadowPlayer = null;

  public string CurrentItemType = String.Empty;
  // Character ( Detail )
  public Text txtDetailName;
  public Text txtDetailLevel;
  public Text txtDetailLife;
  public Image imgDetailLife;
  public Text txtDetailSoulPoint;
  public Image imgDetailSP;
  public Text txtDetailExp;
  public Image imgDetailExp;
  public Text txtDetailStrength;
  public Text txtDetailAgility;
  public Text txtDetailIntelligence;
  public Text txtDetailStamina;
  public Text txtDetailMind;
  public Text txtDetailMainWeapon;
  public Image imgDetailMainWeapon;
  public GameObject backDetailMainWeapon;
  public Text txtDetailSubWeapon;
  public Image imgDetailSubWeapon;
  public GameObject backDetailSubWeapon;
  public Text txtDetailArmor;
  public Image imgDetailArmor;
  public GameObject backDetailArmor;
  public Text txtDetailAccessory1;
  public Image imgDetailAccessory1;
  public GameObject backDetailAccessory1;
  public Text txtDetailAccessory2;
  public Image imgDetailAccessory2;
  public GameObject backDetailAccessory2;
  public Text txtDetailArtifact;
  public Image imgDetailArtifact;
  public GameObject backDetailArtifact;
  public Text txtDetailPhysicalAttack;
  public Text txtDetailPhysicalAttackMax;
  public Text txtDetailPhysicalDefense;
  public Text txtDetailMagicAttack;
  public Text txtDetailMagicAttackMax;
  public Text txtDetailMagicDefense;
  public Text txtDetailBattleAccuracy;
  public Text txtDetailBattleSpeed;
  public Text txtDetailBattleResponse;
  public Text txtDetailPotential;
  public GameObject GroupLevelUp;
  public Text txtDetailRemainPoint;
  public List<GameObject> btnPlus;
  // Character ( Detail - Change Equip )
  public GameObject GroupMainEquip;
  public GameObject GroupChangeEquip;
  public GameObject ContentChangeEquip;
  public NodeBackpackItem nodeChangeEquip;
  public Text lblChangeEquipType;
  public Text txtChangeEquipName;
  public Image imgChangeEquip;

  // Character ( CommandSetting )
  public GameObject groupPartyBattleSetting;
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

  // Character ( Detail - Essence )
  public GameObject GroupSubViewStatus;
  public GameObject GroupSubViewCommandSetting;
  public GameObject GroupSubViewEssence;
  public List<NodeActionCommand> imgEssenceList;
  public List<Text> txtEssenceList;
  public Text txtEssencePoint;
  public Image imgEssenceCurrent;
  public Text txtEssenceCurrentCategory;
  public Text txtEssenceCurrentDescription;
  public GameObject groupEssenceDecision;
  public Image imgEssenceDecision;
  public Text txtEssenceDecisionTitle;
  public Text txtEssenceDecisionMessage;
  public Button btnEssenceDecisionAccept;
  public Button btnEssenceDecisionCancel;
  public Button btnEssenceDecisionOK;

  public MotherBase parentMotherBase = null;

  /// <summary>
  /// トップ画面へ戻す。
  /// </summary>
  public void TapBack()
  {
    ReleaseIt();

    // 本来であれば親シーンのオブジェクトは不要である。
    if (parentMotherBase != null)
    {
      parentMotherBase.RefreshAllView();
    }

    this.GroupMainEquip.SetActive(false);
    this.GroupChangeEquip.SetActive(false);
    this.gameObject.SetActive(false);

    SceneDimension.SceneClose("CharacterStatus");

  }

  /// <summary>
  /// キャラクターデータ（詳細）を画面に反映します。
  /// </summary>
  public void UpdateCharacterDetailView(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    this.GroupMainEquip.SetActive(true);
    this.GroupChangeEquip.SetActive(false);
    if (this.GroupSubViewStatus != null) { this.GroupSubViewStatus.SetActive(true); } // DungeonField側でNullアクセス。画面をAdditiveにしてソース統合化すべきである。
    if (this.GroupSubViewEssence != null) { this.GroupSubViewEssence.SetActive(false); } // DungeonField側でNullアクセス。画面をAdditiveにしてソース統合化すべきである。
    //this.gameObject.SetActive(true);

    // シャドウデータを生成
    CreateShadowData(player);
    Debug.Log(MethodBase.GetCurrentMethod() + " CreateShadowData ok");
    Debug.Log("ShadowData name: " + ShadowPlayer.FullName);

    // キャラクター情報を画面に反映
    txtDetailName.text = player.FullName;
    txtDetailLevel.text = player.Level.ToString();
    txtDetailLife.text = player.CurrentLife.ToString() + " / " + player.MaxLife.ToString();
    txtDetailSoulPoint.text = player.CurrentSoulPoint.ToString() + " / " + player.MaxSoulPoint.ToString();
    txtDetailExp.text = player.Exp.ToString() + " / " + player.GetNextExp().ToString();
    txtDetailStrength.text = player.TotalStrength.ToString();
    txtDetailAgility.text = player.TotalAgility.ToString();
    txtDetailIntelligence.text = player.TotalIntelligence.ToString();
    txtDetailStamina.text = player.TotalStamina.ToString();
    txtDetailMind.text = player.TotalMind.ToString();
    txtDetailPhysicalAttack.text = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Min).ToString("F2");
    txtDetailPhysicalAttackMax.text = PrimaryLogic.PhysicalAttack(player, PrimaryLogic.ValueType.Max).ToString("F2");
    txtDetailPhysicalDefense.text = PrimaryLogic.PhysicalDefense(player).ToString("F2");
    txtDetailMagicAttack.text = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Min).ToString("F2");
    txtDetailMagicAttackMax.text = PrimaryLogic.MagicAttack(player, PrimaryLogic.ValueType.Max).ToString("F2");
    txtDetailMagicDefense.text = PrimaryLogic.MagicDefense(player).ToString("F2");
    txtDetailBattleAccuracy.text = PrimaryLogic.BattleAccuracy(player).ToString("F2");
    txtDetailBattleSpeed.text = PrimaryLogic.BattleSpeed(player).ToString("F2");
    txtDetailBattleResponse.text = PrimaryLogic.BattleResponse(player).ToString("F2");
    txtDetailPotential.text = PrimaryLogic.Potential(player).ToString("F2");
    txtDetailRemainPoint.text = player.RemainPoint.ToString();

    txtDetailMainWeapon.text = (player.MainWeapon?.ItemName ?? "( 装備なし )");
    imgDetailMainWeapon.sprite = Resources.Load<Sprite>("Icon_" + player.MainWeapon?.ItemType.ToString() ?? "");
    backDetailMainWeapon.GetComponent<Image>().color = player.MainWeapon?.GetRareColor ?? Color.white;
    txtDetailMainWeapon.GetComponent<Text>().color = player.MainWeapon?.GetRareTextColor ?? Color.white;

    txtDetailSubWeapon.text = (player.SubWeapon?.ItemName ?? "( 装備なし )");
    imgDetailSubWeapon.sprite = Resources.Load<Sprite>("Icon_" + player.SubWeapon?.ItemType.ToString() ?? "");
    backDetailSubWeapon.GetComponent<Image>().color = player.SubWeapon?.GetRareColor ?? Color.white;
    txtDetailSubWeapon.GetComponent<Text>().color = player.SubWeapon?.GetRareTextColor ?? Color.white;

    txtDetailArmor.text = (player.MainArmor?.ItemName ?? "( 装備なし )");
    imgDetailArmor.sprite = Resources.Load<Sprite>("Icon_" + player.MainArmor?.ItemType.ToString() ?? "");
    backDetailArmor.GetComponent<Image>().color = player.MainArmor?.GetRareColor ?? Color.white;
    txtDetailArmor.GetComponent<Text>().color = player.MainArmor?.GetRareTextColor ?? Color.white;

    txtDetailAccessory1.text = (player.Accessory1?.ItemName ?? "( 装備なし )");
    imgDetailAccessory1.sprite = Resources.Load<Sprite>("Icon_" + player.Accessory1?.ItemType.ToString() ?? "");
    backDetailAccessory1.GetComponent<Image>().color = player.Accessory1?.GetRareColor ?? Color.white;
    txtDetailAccessory1.GetComponent<Text>().color = player.Accessory1?.GetRareTextColor ?? Color.white;

    txtDetailAccessory2.text = (player.Accessory2?.ItemName ?? "( 装備なし )");
    imgDetailAccessory2.sprite = Resources.Load<Sprite>("Icon_" + player.Accessory2?.ItemType.ToString() ?? "");
    backDetailAccessory2.GetComponent<Image>().color = player.Accessory2?.GetRareColor ?? Color.white;
    txtDetailAccessory2.GetComponent<Text>().color = player.Accessory2?.GetRareTextColor ?? Color.white;

    txtDetailArtifact.text = (player.Artifact?.ItemName ?? "( 装備なし )");
    imgDetailArtifact.sprite = Resources.Load<Sprite>("Icon_" + player.Artifact?.ItemType.ToString() ?? "");
    backDetailArtifact.GetComponent<Image>().color = player.Artifact?.GetRareColor ?? Color.white;
    txtDetailArtifact.GetComponent<Text>().color = player.Artifact?.GetRareTextColor ?? Color.white;

    if (imgDetailExp != null)
    {
      float dx = (float)player.Exp / (float)player.GetNextExp();
      imgDetailExp.rectTransform.localScale = new Vector2(dx, 1.0f);
    }
    if (imgDetailSP != null)
    {
      Debug.Log("sp: " + player.CurrentSoulPoint.ToString() + " / " + player.MaxSoulPoint.ToString());
      float dx = (float)player.CurrentSoulPoint / (float)player.MaxSoulPoint;
      imgDetailSP.rectTransform.localScale = new Vector2(dx, 1.0f);
    }
    if (imgDetailLife != null)
    {
      float dx = (float)player.CurrentLife / (float)player.MaxLife;
      imgDetailLife.rectTransform.localScale = new Vector2(dx, 1.0f);
    }

    if (txtEssencePoint != null)
    {
      txtEssencePoint.text = player.SoulFragment.ToString();
    }
    if (imgEssenceList != null && imgEssenceList.Count > 0)
    {
      List<string> list = CurrentPlayer.GetEssenceTreeTitleList();
      List<string> iconList = CurrentPlayer.GetEssenceTreeIconList();
      for (int ii = 0; ii < list.Count; ii++)
      {
        imgEssenceList[ii].ActionButton.image.sprite = Resources.Load<Sprite>(iconList[ii]);
        txtEssenceList[ii].text = list[ii];
      }
      TapSelectEssence(txtEssenceList[0]); // 最初を選択しておく。
    }

    if (ShadowPlayer != null)
    {
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailStrength, CurrentPlayer.TotalStrength, ShadowPlayer.TotalStrength);
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailAgility, CurrentPlayer.TotalAgility, ShadowPlayer.TotalAgility);
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailIntelligence, CurrentPlayer.TotalIntelligence, ShadowPlayer.TotalIntelligence);
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailStamina, CurrentPlayer.TotalStamina, ShadowPlayer.TotalStamina);
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailMind, CurrentPlayer.TotalMind, ShadowPlayer.TotalMind);
      UpdateBattleValueTwoWithShadow(CurrentPlayer, ShadowPlayer, txtDetailLife, CurrentPlayer.MaxLife, ShadowPlayer.MaxLife, CurrentPlayer.CurrentLife);
      UpdateBattleValueTwoWithShadow(CurrentPlayer, ShadowPlayer, txtDetailSoulPoint, CurrentPlayer.MaxSoulPoint, ShadowPlayer.MaxSoulPoint, CurrentPlayer.CurrentSoulPoint);
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailPhysicalAttack, PrimaryLogic.PhysicalAttack(CurrentPlayer, PrimaryLogic.ValueType.Min), PrimaryLogic.PhysicalAttack(ShadowPlayer, PrimaryLogic.ValueType.Min));
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailPhysicalAttackMax, PrimaryLogic.PhysicalAttack(CurrentPlayer, PrimaryLogic.ValueType.Max), PrimaryLogic.PhysicalAttack(ShadowPlayer, PrimaryLogic.ValueType.Max));
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailPhysicalDefense, PrimaryLogic.PhysicalDefense(CurrentPlayer), PrimaryLogic.PhysicalDefense(ShadowPlayer));
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailMagicAttack, PrimaryLogic.MagicAttack(CurrentPlayer, PrimaryLogic.ValueType.Min), PrimaryLogic.MagicAttack(ShadowPlayer, PrimaryLogic.ValueType.Min));
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailMagicAttackMax, PrimaryLogic.MagicAttack(CurrentPlayer, PrimaryLogic.ValueType.Max), PrimaryLogic.MagicAttack(ShadowPlayer, PrimaryLogic.ValueType.Max));
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailMagicDefense, PrimaryLogic.MagicDefense(CurrentPlayer), PrimaryLogic.MagicDefense(ShadowPlayer));
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailBattleAccuracy, PrimaryLogic.BattleAccuracy(CurrentPlayer), PrimaryLogic.BattleAccuracy(ShadowPlayer));
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailBattleSpeed, PrimaryLogic.BattleSpeed(CurrentPlayer), PrimaryLogic.BattleSpeed(ShadowPlayer));
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailBattleResponse, PrimaryLogic.BattleResponse(CurrentPlayer), PrimaryLogic.BattleResponse(ShadowPlayer));
      UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailPotential, PrimaryLogic.Potential(CurrentPlayer), PrimaryLogic.Potential(ShadowPlayer));
    }

    // コマンド設定画面への反映
    SetupActionCommand(CurrentPlayer, ActionCommand.CommandCategory.ActionCommand); // [基本行動]が一番左で最初だが、デフォルトはアクションコマンドを表示

    txtDetailLevel.text = this.CurrentPlayer.Level.ToString();

    Debug.Log("remain " + CurrentPlayer.FullName + " " + CurrentPlayer.RemainPoint);
    if (CurrentPlayer.RemainPoint > 0)
    {
      GroupLevelUp?.SetActive(true);
      for (int ii = 0; ii < btnPlus.Count; ii++)
      {
        btnPlus[ii].SetActive(true);
      }
    }
    else
    {
      GroupLevelUp?.SetActive(false);
      for (int ii = 0; ii < btnPlus.Count; ii++)
      {
        btnPlus[ii].SetActive(false);
      }
    }

    //txtDetailLevel.text = this.CurrentPlayer.Level.ToString() + " -> <color=blue>" + (this.CurrentPlayer.Level + 1).ToString() + "</color>";
    //txtDetailExp.text = "MAX";
    //GroupLevelUp?.SetActive(true);
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
    //ActionCommandMain.ActionButton.image.sprite = Resources.Load<Sprite>(player.ActionCommandMain);

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
        //ListActionCommandSet[ii].ActionButton.image.sprite = Resources.Load<Sprite>(Fix.STAY);
        continue;
      }

      ListActionCommandSet[ii].CommandName = actionList[ii];
      ListActionCommandSet[ii].name = actionList[ii];
      ListActionCommandSet[ii].ActionButton.name = actionList[ii];
      ListActionCommandSet[ii].ApplyImageIcon(actionList[ii]);
      //ListActionCommandSet[ii].ActionButton.image.sprite = Resources.Load<Sprite>(actionList[ii]);
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
    groupCommandCategory.SetActive(One.TF.AvailableImmediateAction);
    btnCommandCategoryAction.gameObject.SetActive(One.TF.AvailableImmediateAction);
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
      //ListAvailableCommand[ii].ActionButton.image.sprite = Resources.Load<Sprite>(currentList[ii]);
      ListAvailableCommandText[ii].text = currentList[ii];
    }
  }

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

  /// <summary>
  /// シャドウデータからバトル設定値を画面へ反映します。（int型)
  /// </summary>
  private void UpdateBattleValueWithShadow(Character player, Character shadow, Text txtObj, int value1, int value2)
  {
    string color = "black";
    if (value1 < value2) { color = "blue"; }
    if (value1 > value2) { color = "red"; }
    txtObj.text = value1.ToString();

    if (value1 != value2)
    {
      txtObj.text += " -> <color=" + color + ">" + value2.ToString() + "</color>";
    }
  }

  /// <summary>
  /// シャドウデータからバトル設定値を画面へ反映します。（int型)
  /// </summary>
  private void UpdateBattleValueTwoWithShadow(Character player, Character shadow, Text txtObj, int value1, int value2, int value3)
  {
    txtObj.text = value3.ToString() + " / ";

    string color = "black";
    if (value1 < value2) { color = "blue"; }
    if (value1 > value2) { color = "red"; }
    txtObj.text += value1.ToString();

    if (value1 != value2)
    {
      txtObj.text += " -> <color=" + color + ">" + value2.ToString() + "</color>";
    }
  }

  /// <summary>
  /// シャドウデータからバトル設定値を画面へ反映します。（double型)
  /// </summary>
  private void UpdateBattleValueWithShadow(Character player, Character shadow, Text txtObj, double value1, double value2)
  {
    string color = "black";
    if (value1 < value2) { color = "blue"; }
    if (value1 > value2) { color = "red"; }
    txtObj.text = value1.ToString("F2");

    if (value1 != value2)
    {
      txtObj.text += " -> <color=" + color + ">" + value2.ToString("F2") + "</color>";
    }
  }

  /// <summary>
  /// 装備箇所（メイン）の装備変更画面を呼び出します。
  /// </summary>
  /// <param name="sender"></param>
  public void TapChangeEquipMainWeapon(Text sender)
  {
    // シャドウデータを生成
    CreateShadowData(this.CurrentPlayer);

    // 変更対象のメインアイテムを設定
    this.CurrentItemType = Fix.ITEMTYPE_MAIN_WEAPON;
    lblChangeEquipType.text = Fix.ITEMTYPE_MAIN_WEAPON;
    txtChangeEquipName.text = sender.text;
    Item temp = new Item(sender.text);
    imgChangeEquip.sprite = Resources.Load<Sprite>("Icon_" + temp?.ItemType.ToString() ?? "");

    // バックパックから装備可能なアイテムを設定
    ContentChangeEquip.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    int counter = 0;
    for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
    {
      if (CurrentPlayer.Equipable(Fix.EquipType.MainWeapon, One.TF.BackpackList[ii]))
      {
        CreateBackpack(ContentChangeEquip, nodeChangeEquip, One.TF.BackpackList[ii].ItemName, One.TF.BackpackList[ii].StackValue, ii, counter);
        counter++;
      }
    }

    // 画面表示
    GroupChangeEquip.SetActive(true);
    GroupMainEquip.SetActive(false);
  }

  /// <summary>
  /// 装備箇所（サブ）の装備変更画面を呼び出します。
  /// </summary>
  /// <param name="sender"></param>
  public void TapChangeEquipSubWeapon(Text sender)
  {
    // シャドウデータを生成
    CreateShadowData(this.CurrentPlayer);

    // 変更対象のメインアイテムを設定
    this.CurrentItemType = Fix.ITEMTYPE_SUB_WEAPON;
    lblChangeEquipType.text = Fix.ITEMTYPE_SUB_WEAPON;
    txtChangeEquipName.text = sender.text;
    Item temp = new Item(sender.text);
    imgChangeEquip.sprite = Resources.Load<Sprite>("Icon_" + temp?.ItemType.ToString() ?? "");

    // バックパックから装備可能なアイテムを設定
    ContentChangeEquip.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    int counter = 0;
    for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
    {
      if (CurrentPlayer.Equipable(Fix.EquipType.SubWeapon, One.TF.BackpackList[ii]))
      {
        CreateBackpack(ContentChangeEquip, nodeChangeEquip, One.TF.BackpackList[ii].ItemName, One.TF.BackpackList[ii].StackValue, ii, counter);
        counter++;
      }
    }

    // 画面表示
    GroupChangeEquip.SetActive(true);
    GroupMainEquip.SetActive(false);
  }

  /// <summary>
  /// 装備箇所（アーマー）の装備変更画面を呼び出します。
  /// </summary>
  /// <param name="sender"></param>
  public void TapChangeEquipArmor(Text sender)
  {
    // シャドウデータを生成
    CreateShadowData(this.CurrentPlayer);

    // 変更対象のメインアイテムを設定
    this.CurrentItemType = Fix.ITEMTYPE_ARMOR;
    lblChangeEquipType.text = Fix.ITEMTYPE_ARMOR;
    txtChangeEquipName.text = sender.text;
    Item temp = new Item(sender.text);
    imgChangeEquip.sprite = Resources.Load<Sprite>("Icon_" + temp?.ItemType.ToString() ?? "");

    // バックパックから装備可能なアイテムを設定
    ContentChangeEquip.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    int counter = 0;
    for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
    {
      if (CurrentPlayer.Equipable(Fix.EquipType.Armor, One.TF.BackpackList[ii]))
      {
        CreateBackpack(ContentChangeEquip, nodeChangeEquip, One.TF.BackpackList[ii].ItemName, One.TF.BackpackList[ii].StackValue, ii, counter);
        counter++;
      }
    }

    // 画面表示
    GroupChangeEquip.SetActive(true);
    GroupMainEquip.SetActive(false);
  }

  /// <summary>
  /// 装備箇所（アクセサリ１）の装備変更画面を呼び出します。
  /// </summary>
  /// <param name="sender"></param>
  public void TapChangeEquipAccessory1(Text sender)
  {
    // シャドウデータを生成
    CreateShadowData(this.CurrentPlayer);

    // 変更対象のメインアイテムを設定
    this.CurrentItemType = Fix.ITEMTYPE_ACCESSORY1;
    lblChangeEquipType.text = Fix.ITEMTYPE_ACCESSORY1;
    txtChangeEquipName.text = sender.text;
    Item temp = new Item(sender.text);
    imgChangeEquip.sprite = Resources.Load<Sprite>("Icon_" + temp.ItemType.ToString() ?? "");

    // バックパックから装備可能なアイテムを設定
    ContentChangeEquip.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    int counter = 0;
    for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
    {
      if (CurrentPlayer.Equipable(Fix.EquipType.Accessory1, One.TF.BackpackList[ii]))
      {
        CreateBackpack(ContentChangeEquip, nodeChangeEquip, One.TF.BackpackList[ii].ItemName, One.TF.BackpackList[ii].StackValue, ii,counter);
        counter++;
      }
    }

    // 画面表示
    GroupChangeEquip.SetActive(true);
    GroupMainEquip.SetActive(false);
  }

  /// <summary>
  /// 装備箇所（アクセサリ２）の装備変更画面を呼び出します。
  /// </summary>
  /// <param name="sender"></param>
  public void TapChangeEquipAccessory2(Text sender)
  {
    // シャドウデータを生成
    CreateShadowData(this.CurrentPlayer);

    // 変更対象のメインアイテムを設定
    this.CurrentItemType = Fix.ITEMTYPE_ACCESSORY2;
    lblChangeEquipType.text = Fix.ITEMTYPE_ACCESSORY2;
    txtChangeEquipName.text = sender.text;
    Item temp = new Item(sender.text);
    imgChangeEquip.sprite = Resources.Load<Sprite>("Icon_" + temp.ItemType.ToString() ?? "");

    // バックパックから装備可能なアイテムを設定
    ContentChangeEquip.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    int counter = 0;
    for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
    {
      if (CurrentPlayer.Equipable(Fix.EquipType.Accessory2, One.TF.BackpackList[ii]))
      {
        CreateBackpack(ContentChangeEquip, nodeChangeEquip, One.TF.BackpackList[ii].ItemName, One.TF.BackpackList[ii].StackValue, ii, counter);
        counter++;
      }
    }

    // 画面表示
    GroupChangeEquip.SetActive(true);
    GroupMainEquip.SetActive(false);
  }

  /// <summary>
  /// 装備箇所（アーティファクト）の装備変更画面を呼び出します。
  /// </summary>
  /// <param name="sender"></param>
  public void TapChangeEquipArtifact(Text sender)
  {
    // シャドウデータを生成
    CreateShadowData(this.CurrentPlayer);

    // 変更対象のメインアイテムを設定
    this.CurrentItemType = Fix.ITEMTYPE_ARTIFACT;
    lblChangeEquipType.text = Fix.ITEMTYPE_ARTIFACT;
    txtChangeEquipName.text = sender.text;
    Item temp = new Item(sender.text);
    imgChangeEquip.sprite = Resources.Load<Sprite>("Icon_" + temp.ItemType.ToString() ?? "");

    // バックパックから装備可能なアイテムを設定
    ContentChangeEquip.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    int counter = 0;
    for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
    {
      if (CurrentPlayer.Equipable(Fix.EquipType.Artifact, One.TF.BackpackList[ii]))
      {
        CreateBackpack(ContentChangeEquip, nodeChangeEquip, One.TF.BackpackList[ii].ItemName, One.TF.BackpackList[ii].StackValue, ii, counter);
        counter++;
      }
    }

    // 画面表示
    GroupChangeEquip.SetActive(true);
    GroupMainEquip.SetActive(false);
  }

  /// <summary>
  /// シャドウデータを生成します。
  /// </summary>
  private void CreateShadowData(Character player)
  {
    if (ShadowPlayer == null)
    {
      Debug.Log(MethodBase.GetCurrentMethod() + " ShadowPlayer is null, then create it");
      if (player == null) { Debug.Log("player is null..."); }
      GameObject objShadow = new GameObject();
      ShadowPlayer = objShadow.AddComponent<Character>();
      ShadowPlayer.FullName = player.FullName;
      ShadowPlayer.Level = player.Level;
      ShadowPlayer.Exp = player.Exp;
      ShadowPlayer.Strength = player.Strength;
      ShadowPlayer.StrengthFood = player.StrengthFood;
      ShadowPlayer.Agility = player.Agility;
      ShadowPlayer.AgilityFood = player.AgilityFood;
      ShadowPlayer.Intelligence = player.Intelligence;
      ShadowPlayer.IntelligenceFood = player.IntelligenceFood;
      ShadowPlayer.Stamina = player.Stamina;
      ShadowPlayer.StaminaFood = player.StaminaFood;
      ShadowPlayer.Mind = player.Mind;
      ShadowPlayer.MindFood = player.MindFood;
      ShadowPlayer.BaseLife = player.BaseLife;
      ShadowPlayer.BaseSoulPoint = player.BaseSoulPoint;
      ShadowPlayer.CurrentLife = player.CurrentLife;
      ShadowPlayer.CurrentSoulPoint = player.CurrentSoulPoint;
      ShadowPlayer.RemainPoint = player.RemainPoint;
      if (player.MainWeapon != null)
      {
        ShadowPlayer.MainWeapon = new Item(player.MainWeapon.ItemName);
      }
      if (player.SubWeapon != null)
      {
        ShadowPlayer.SubWeapon = new Item(player.SubWeapon.ItemName);
      }
      if (player.MainArmor != null)
      {
        ShadowPlayer.MainArmor = new Item(player.MainArmor.ItemName);
      }
      if (player.Accessory1 != null)
      {
        ShadowPlayer.Accessory1 = new Item(player.Accessory1.ItemName);
      }
      if (player.Accessory2 != null)
      {
        ShadowPlayer.Accessory2 = new Item(player.Accessory2.ItemName);
      }
      if (player.Artifact != null)
      {
        ShadowPlayer.Artifact = new Item(player.Artifact.ItemName);
      }
    }
  }

  /// <summary>
  /// バックパックアイテムを生成します。
  /// </summary>
  private void CreateBackpack(GameObject content, NodeBackpackItem node, string item_name, int item_num, int num, int counter)
  {
    Instantiate(node).Construct(content, item_name, item_num, num, counter);
  }


  public void TapBackpackSelect(NodeBackpackItem backpack)
  {
    Debug.Log("TapBackpackSelect(S)");
    //this.CurrentSelectBackpack = One.TF.BackpackList[backpack.BackpackNumber];

    //for (int ii = 0; ii < BackpackList.Count; ii++)
    //{
    //  Debug.Log("BackpackList: " + BackpackList[ii].txtName.text);
    //  BackpackList[ii].imgSelect.gameObject.SetActive(false);
    //}
    backpack.imgSelect.gameObject.SetActive(true);
  }

  /// <summary>
  /// 装備品を選択します。
  /// </summary>
  /// <param name="sender"></param>
  public void TapNodeChangeEquip(Text sender)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + " " + sender.text);

    if (CurrentItemType == Fix.ITEMTYPE_MAIN_WEAPON)
    {
      this.ShadowPlayer.MainWeapon = null;
      this.ShadowPlayer.MainWeapon = new Item(sender.text);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_SUB_WEAPON)
    {
      this.ShadowPlayer.SubWeapon = null;
      this.ShadowPlayer.SubWeapon = new Item(sender.text);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ARMOR)
    {
      this.ShadowPlayer.MainArmor = null;
      this.ShadowPlayer.MainArmor = new Item(sender.text);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ACCESSORY1)
    {
      this.ShadowPlayer.Accessory1 = null;
      this.ShadowPlayer.Accessory1 = new Item(sender.text);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ACCESSORY2)
    {
      this.ShadowPlayer.Accessory2 = null;
      this.ShadowPlayer.Accessory2 = new Item(sender.text);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ARTIFACT)
    {
      this.ShadowPlayer.Artifact = null;
      this.ShadowPlayer.Artifact = new Item(sender.text);
    }

    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailStrength, CurrentPlayer.TotalStrength, ShadowPlayer.TotalStrength);
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailAgility, CurrentPlayer.TotalAgility, ShadowPlayer.TotalAgility);
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailIntelligence, CurrentPlayer.TotalIntelligence, ShadowPlayer.TotalIntelligence);
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailStamina, CurrentPlayer.TotalStamina, ShadowPlayer.TotalStamina);
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailMind, CurrentPlayer.TotalMind, ShadowPlayer.TotalMind);
    UpdateBattleValueTwoWithShadow(CurrentPlayer, ShadowPlayer, txtDetailLife, CurrentPlayer.MaxLife, ShadowPlayer.MaxLife, CurrentPlayer.CurrentLife);
    UpdateBattleValueTwoWithShadow(CurrentPlayer, ShadowPlayer, txtDetailSoulPoint, CurrentPlayer.MaxSoulPoint, ShadowPlayer.MaxSoulPoint, CurrentPlayer.CurrentSoulPoint);
    //UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailLife, CurrentPlayer.MaxLife, ShadowPlayer.MaxLife);
    //UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailSoulPoint, CurrentPlayer.MaxSoulPoint, ShadowPlayer.MaxSoulPoint);
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailPhysicalAttack, PrimaryLogic.PhysicalAttack(CurrentPlayer, PrimaryLogic.ValueType.Min), PrimaryLogic.PhysicalAttack(ShadowPlayer, PrimaryLogic.ValueType.Min));
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailPhysicalAttackMax, PrimaryLogic.PhysicalAttack(CurrentPlayer, PrimaryLogic.ValueType.Max), PrimaryLogic.PhysicalAttack(ShadowPlayer, PrimaryLogic.ValueType.Max));
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailPhysicalDefense, PrimaryLogic.PhysicalDefense(CurrentPlayer), PrimaryLogic.PhysicalDefense(ShadowPlayer));
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailMagicAttack, PrimaryLogic.MagicAttack(CurrentPlayer, PrimaryLogic.ValueType.Min), PrimaryLogic.MagicAttack(ShadowPlayer, PrimaryLogic.ValueType.Min));
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailMagicAttackMax, PrimaryLogic.MagicAttack(CurrentPlayer, PrimaryLogic.ValueType.Max), PrimaryLogic.MagicAttack(ShadowPlayer, PrimaryLogic.ValueType.Max));
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailMagicDefense, PrimaryLogic.MagicDefense(CurrentPlayer), PrimaryLogic.MagicDefense(ShadowPlayer));
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailBattleAccuracy, PrimaryLogic.BattleAccuracy(CurrentPlayer), PrimaryLogic.BattleAccuracy(ShadowPlayer));
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailBattleSpeed, PrimaryLogic.BattleSpeed(CurrentPlayer), PrimaryLogic.BattleSpeed(ShadowPlayer));
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailBattleResponse, PrimaryLogic.BattleResponse(CurrentPlayer), PrimaryLogic.BattleResponse(ShadowPlayer));
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailPotential, PrimaryLogic.Potential(CurrentPlayer), PrimaryLogic.Potential(ShadowPlayer));
  }

  /// <summary>
  /// 装備しようとしていたアイテムを装備します。
  /// </summary>
  public void TapAcceptChangeEquip()
  {
    // ・現在装備アイテムをバックパックに戻す。
    // ・選択アイテムを装備する。
    // ・選択アイテムをバックパックから削除する。
    if (CurrentItemType == Fix.ITEMTYPE_MAIN_WEAPON)
    {
      if (ShadowPlayer.MainWeapon != null)
      {
        Item current = new Item((CurrentPlayer.MainWeapon?.ItemName ?? string.Empty));
        if (current.ItemType != Item.ItemTypes.None)
        {
          One.TF.AddBackPack(CurrentPlayer.MainWeapon);
        }
        CurrentPlayer.MainWeapon = new Item(ShadowPlayer.MainWeapon.ItemName);
        One.TF.RemoveItem(ShadowPlayer.MainWeapon);

        // メイン武器が両手持ちで、サブに装備がある場合、サブを外す。
        if (ShadowPlayer.MainWeapon.GripType == Item.GripTypes.TwoHand)
        {
          if (CurrentPlayer.SubWeapon != null && CurrentPlayer.SubWeapon.ItemName != String.Empty)
          {
            One.TF.AddBackPack(CurrentPlayer.SubWeapon);
            CurrentPlayer.SubWeapon = new Item(string.Empty);
          }
        }
      }
    }
    else if (CurrentItemType == Fix.ITEMTYPE_SUB_WEAPON)
    {
      if (ShadowPlayer.MainWeapon != null)
      {
        Item current = new Item((CurrentPlayer.SubWeapon?.ItemName ?? string.Empty));
        if (current.ItemType != Item.ItemTypes.None)
        {
          One.TF.AddBackPack(CurrentPlayer.SubWeapon);
        }
        CurrentPlayer.SubWeapon = new Item(ShadowPlayer.SubWeapon.ItemName);
        One.TF.RemoveItem(ShadowPlayer.SubWeapon);
      }
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ARMOR)
    {
      if (ShadowPlayer.MainWeapon != null)
      {
        Item current = new Item((CurrentPlayer.MainArmor?.ItemName ?? string.Empty));
        if (current.ItemType != Item.ItemTypes.None)
        {
          One.TF.AddBackPack(CurrentPlayer.MainArmor);
        }
        CurrentPlayer.MainArmor = new Item(ShadowPlayer.MainArmor.ItemName);
        One.TF.RemoveItem(ShadowPlayer.MainArmor);
      }
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ACCESSORY1)
    {
      if (ShadowPlayer.MainWeapon != null)
      {
        Item current = new Item((CurrentPlayer.Accessory1?.ItemName ?? string.Empty));
        if (current.ItemType != Item.ItemTypes.None)
        {
          One.TF.AddBackPack(CurrentPlayer.Accessory1);
        }
        CurrentPlayer.Accessory1 = new Item(ShadowPlayer.Accessory1.ItemName);
        One.TF.RemoveItem(ShadowPlayer.Accessory1);
      }
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ACCESSORY2)
    {
      if (ShadowPlayer.MainWeapon != null)
      {
        Item current = new Item((CurrentPlayer.Accessory2?.ItemName ?? string.Empty));
        if (current.ItemType != Item.ItemTypes.None)
        {
          One.TF.AddBackPack(CurrentPlayer.Accessory2);
        }
        CurrentPlayer.Accessory2 = new Item(ShadowPlayer.Accessory2.ItemName);
        One.TF.RemoveItem(ShadowPlayer.Accessory2);
      }
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ARTIFACT)
    {
      if (ShadowPlayer.MainWeapon != null)
      {
        Item current = new Item((CurrentPlayer.Artifact?.ItemName ?? string.Empty));
        if (current.ItemType != Item.ItemTypes.None)
        {
          One.TF.AddBackPack(CurrentPlayer.Artifact);
        }
        CurrentPlayer.Artifact = new Item(ShadowPlayer.Artifact.ItemName);
        One.TF.RemoveItem(ShadowPlayer.Artifact);
      }
    }
    //CurrentPlayer.MaxGain();

    ReleaseIt();

    // ビュー更新
    UpdateCharacterDetailView(CurrentPlayer);
    GroupChangeEquip.SetActive(false);
    GroupMainEquip.SetActive(true);
    // 本来であれば親シーンのオブジェクトは不要である。
    if (parentMotherBase != null)
    {
      parentMotherBase.RefreshAllView();
    }
  }

  /// <summary>
  /// 現在装備しているアイテムをはずします。
  /// </summary>
  public void TapEquipDetach()
  {
    // ・現在装備アイテムをバックパックに戻す。
    // ・現在装備を「装備なし」にする。
    // ・ターゲットプレイヤーを全快にする。
    if (CurrentItemType == Fix.ITEMTYPE_MAIN_WEAPON)
    {
      Item current = new Item((CurrentPlayer.MainWeapon?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.MainWeapon);
      }
      CurrentPlayer.MainWeapon = new Item(string.Empty);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_SUB_WEAPON)
    {
      Item current = new Item((CurrentPlayer.SubWeapon?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.SubWeapon);
      }
      CurrentPlayer.SubWeapon = new Item(string.Empty);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ARMOR)
    {
      Item current = new Item((CurrentPlayer.MainArmor?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.MainArmor);
      }
      CurrentPlayer.MainArmor = new Item(string.Empty);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ACCESSORY1)
    {
      Item current = new Item((CurrentPlayer.Accessory1?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.Accessory1);
      }
      CurrentPlayer.Accessory1 = new Item(string.Empty);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ACCESSORY2)
    {
      Item current = new Item((CurrentPlayer.Accessory2?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.Accessory2);
      }
      CurrentPlayer.Accessory2 = new Item(string.Empty);
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ARTIFACT)
    {
      Item current = new Item((CurrentPlayer.Artifact?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.Artifact);
      }
      CurrentPlayer.Artifact = new Item(string.Empty);
    }
    //CurrentPlayer.MaxGain();

    ReleaseIt();

    // ビュー更新
    UpdateCharacterDetailView(CurrentPlayer);
    GroupChangeEquip.SetActive(false);
    GroupMainEquip.SetActive(true);
    // 本来であれば親シーンのオブジェクトは不要である。
    if (parentMotherBase != null)
    {
      parentMotherBase.RefreshAllView();
    }
  }

  /// <summary>
  ///  装備しようとしていたアイテムを装備せず、キャンセル扱いとします。
  /// </summary>
  public void TapCancelChangeEquip()
  {
    ReleaseIt();

    // ビュー更新
    UpdateCharacterDetailView(this.CurrentPlayer);
    GroupChangeEquip.SetActive(false);
    GroupMainEquip.SetActive(true);
  }

  public void ReleaseIt()
  {
    // 解放する。
    if (this.ShadowPlayer != null)
    {
      Destroy(this.ShadowPlayer.gameObject);
      this.ShadowPlayer = null;
    }

    // コンテンツ内を解放する。
    foreach (Transform n in ContentChangeEquip.transform)
    {
      Destroy(n.gameObject);
    }
  }

  /// <summary>
  /// レベルアップでStrengthを加算します。
  /// </summary>
  public void TapParameterUpStrength()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    this.ShadowPlayer.AddStrength();
    UpdateCharacterDetailView(this.ShadowPlayer);
  }

  /// <summary>
  /// レベルアップでAgilityを加算します。
  /// </summary>
  public void TapParameterUpAgility()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    this.ShadowPlayer.AddAgility();
    UpdateCharacterDetailView(this.ShadowPlayer);
  }

  /// <summary>
  /// レベルアップでIntelligenceを加算します。
  /// </summary>
  public void TapParameterUpIntelligence()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    this.ShadowPlayer.AddIntelligence();
    UpdateCharacterDetailView(this.ShadowPlayer);
  }

  /// <summary>
  /// レベルアップでStaminaを加算します。
  /// </summary>
  public void TapParameterUpStamina()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    this.ShadowPlayer.AddStamina();
    UpdateCharacterDetailView(this.ShadowPlayer);
  }

  /// <summary>
  /// レベルアップでMindを加算します。
  /// </summary>
  public void TapParameterUpMind()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    this.ShadowPlayer.AddMind();
    UpdateCharacterDetailView(this.ShadowPlayer);
  }

  /// <summary>
  /// レベルアップで加算した値をリセットします。
  /// </summary>
  public void TapParameterUpReset()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    this.ShadowPlayer.ResetLevelUp();
    UpdateCharacterDetailView(this.ShadowPlayer);
  }

  /// <summary>
  /// レベルアップで加算した値をコミットします。
  /// </summary>
  public void TapParameterUpAccept()
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    this.CurrentPlayer.PlusStrength = this.ShadowPlayer.PlusStrength;
    this.CurrentPlayer.PlusAgility = this.ShadowPlayer.PlusAgility;
    this.CurrentPlayer.PlusIntelligence = this.ShadowPlayer.PlusIntelligence;
    this.CurrentPlayer.PlusStamina = this.ShadowPlayer.PlusStamina;
    this.CurrentPlayer.PlusMind = this.ShadowPlayer.PlusMind;
    this.CurrentPlayer.RemainPoint = this.ShadowPlayer.RemainPoint;
    this.CurrentPlayer.AcceptLevelup();
    //this.CurrentPlayer.MaxGain();

    // 本来であれば親シーンのオブジェクトは不要である。
    if (parentMotherBase != null)
    {
      parentMotherBase.RefreshAllView();
    }
    // todo DungeonFieldの場合、親シーンのプレイヤーリストのライフ上限表示の更新ができていない。

    // トップ画面へ戻す。
    GroupLevelUp.SetActive(false);
    for (int ii = 0; ii < btnPlus.Count; ii++)
    {
      btnPlus[ii].SetActive(false);
    }

    this.ReleaseIt();
    this.UpdateCharacterDetailView(this.CurrentPlayer);

    //this.gameObject.SetActive(false);
  }

  public void TapCharacterStatus()
  {
    GroupSubViewStatus.SetActive(true);
    GroupSubViewCommandSetting.SetActive(false);
    GroupSubViewEssence.SetActive(false);
  }
  public void TapCharacterCommand()
  {
    GroupSubViewStatus.SetActive(false);
    GroupSubViewCommandSetting.SetActive(true);
    GroupSubViewEssence.SetActive(false);
  }
  public void TapCharacterEssence()
  {
    GroupSubViewStatus.SetActive(false);
    GroupSubViewCommandSetting.SetActive(false);
    GroupSubViewEssence.SetActive(true);
  }

  public void TapSelectEssence(Text txt_title)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    txtEssenceCurrentCategory.text = txt_title.text;
    List<string> titleList = CurrentPlayer.GetEssenceTreeTitleList();
    List<string> descList = CurrentPlayer.GetEssenceTreeDescList();
    List<string> iconList = CurrentPlayer.GetEssenceTreeIconList();
    for (int ii = 0; ii < titleList.Count; ii++)
    {
      if (txt_title.text == titleList[ii])
      {
        txtEssenceCurrentDescription.text = descList[ii];
        imgEssenceCurrent.sprite = Resources.Load<Sprite>(iconList[ii]);
      }
    }
  }

  public void TapDecisionEssence()
  {
    Debug.Log(MethodBase.GetCurrentMethod());

    imgEssenceDecision.sprite = imgEssenceCurrent.sprite;
    imgEssenceDecision.name = txtEssenceCurrentCategory.text;
    if (CurrentPlayer.SoulFragment <= 0)
    {
      txtEssenceDecisionTitle.text = txtEssenceCurrentCategory.text + " を獲得する事ができません。";
      txtEssenceDecisionMessage.text = "エッセンス・ポイントが不足しています。エッセンス・ポイントを入手してください。";
      btnEssenceDecisionAccept.gameObject.SetActive(false);
      btnEssenceDecisionCancel.gameObject.SetActive(false);
      btnEssenceDecisionOK.gameObject.SetActive(true);
      groupEssenceDecision.SetActive(true);
      return;
    }

    txtEssenceDecisionTitle.text = txtEssenceCurrentCategory.text + "を獲得しますか？";
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
}
