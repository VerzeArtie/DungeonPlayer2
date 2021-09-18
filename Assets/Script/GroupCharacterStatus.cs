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

  }

  /// <summary>
  /// キャラクターデータ（詳細）を画面に反映します。
  /// </summary>
  public void UpdateCharacterDetailView(Character player)
  {
    Debug.Log(MethodBase.GetCurrentMethod());
    this.GroupMainEquip.SetActive(true);
    this.GroupChangeEquip.SetActive(false);
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

    txtDetailSubWeapon.text = (player.SubWeapon?.ItemName ?? "( 装備なし )");
    imgDetailSubWeapon.sprite = Resources.Load<Sprite>("Icon_" + player.SubWeapon?.ItemType.ToString() ?? "");

    txtDetailArmor.text = (player.MainArmor?.ItemName ?? "( 装備なし )");
    imgDetailArmor.sprite = Resources.Load<Sprite>("Icon_" + player.MainArmor?.ItemType.ToString() ?? "");

    txtDetailAccessory1.text = (player.Accessory1?.ItemName ?? "( 装備なし )");
    imgDetailAccessory1.sprite = Resources.Load<Sprite>("Icon_" + player.Accessory1?.ItemType.ToString() ?? "");

    txtDetailAccessory2.text = (player.Accessory2?.ItemName ?? "( 装備なし )");
    imgDetailAccessory2.sprite = Resources.Load<Sprite>("Icon_" + player.Accessory2?.ItemType.ToString() ?? "");

    txtDetailArtifact.text = (player.Artifact?.ItemName ?? "( 装備なし )");
    imgDetailArtifact.sprite = Resources.Load<Sprite>("Icon_" + player.Artifact?.ItemType.ToString() ?? "");

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

    if (player.Exp < player.GetNextExp())
    {
      txtDetailLevel.text = this.CurrentPlayer.Level.ToString();
      GroupLevelUp?.SetActive(false);
    }
    else
    {
      txtDetailLevel.text = this.CurrentPlayer.Level.ToString() + " -> <color=blue>" + (this.CurrentPlayer.Level + 1).ToString() + "</color>";
      txtDetailExp.text = "MAX";
      GroupLevelUp?.SetActive(true);
      Debug.Log("remain " + CurrentPlayer.FullName + " " + CurrentPlayer.RemainPoint);
      if (CurrentPlayer.RemainPoint > 0)
      {
        for (int ii = 0; ii < btnPlus.Count; ii++)
        {
          btnPlus[ii].SetActive(true);
        }
      }
      else
      {
        for (int ii = 0; ii < btnPlus.Count; ii++)
        {
          btnPlus[ii].SetActive(false);
        }
      }
    }
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
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailLife, CurrentPlayer.MaxLife, ShadowPlayer.MaxLife);
    UpdateBattleValueWithShadow(CurrentPlayer, ShadowPlayer, txtDetailSoulPoint, CurrentPlayer.MaxSoulPoint, ShadowPlayer.MaxSoulPoint);
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
      CurrentPlayer.MainWeapon = null;
    }
    else if (CurrentItemType == Fix.ITEMTYPE_SUB_WEAPON)
    {
      Item current = new Item((CurrentPlayer.SubWeapon?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.SubWeapon);
      }
      CurrentPlayer.SubWeapon = null;
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ARMOR)
    {
      Item current = new Item((CurrentPlayer.MainArmor?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.MainArmor);
      }
      CurrentPlayer.MainArmor = null;
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ACCESSORY1)
    {
      Item current = new Item((CurrentPlayer.Accessory1?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.Accessory1);
      }
      CurrentPlayer.Accessory1 = null;
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ACCESSORY2)
    {
      Item current = new Item((CurrentPlayer.Accessory2?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.Accessory2);
      }
      CurrentPlayer.Accessory2 = null;
    }
    else if (CurrentItemType == Fix.ITEMTYPE_ARTIFACT)
    {
      Item current = new Item((CurrentPlayer.Artifact?.ItemName ?? string.Empty));
      if (current.ItemType != Item.ItemTypes.None)
      {
        One.TF.AddBackPack(CurrentPlayer.Artifact);
      }
      CurrentPlayer.Artifact = null;
    }
    //CurrentPlayer.MaxGain();

    ReleaseIt();

    // ビュー更新
    UpdateCharacterDetailView(CurrentPlayer);
    GroupChangeEquip.SetActive(false);
    GroupMainEquip.SetActive(true);
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
}
