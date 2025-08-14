using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class NodeBackpackView : MonoBehaviour
{
  public GameObject GroupCategoryBackpack;
  public GameObject GroupCategoryPrecious;

  public GameObject ContentPrecious;
  public Text txtPreciousDescription;
  public NodeBackpackItem nodePreciousItem;

  public GameObject GroupBackpack;
  public GameObject ContentBackpack;
  public NodeBackpackItem nodeBackpackItem;

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
  public Text txtItemDetailAmplifyPA;
  public Text txtItemDetailAmplifyPD;
  public Text txtItemDetailAmplifyMA;
  public Text txtItemDetailAmplifyMD;
  public Text txtItemDetailAmplifyBS;
  public Text txtItemDetailAmplifyBR;
  public Text txtItemDetailAmplifyPO;
  public Text txtItemDetailAmplifyFire;
  public Text txtItemDetailAmplifyIce;
  public Text txtItemDetailAmplifyLight;
  public Text txtItemDetailAmplifyShadow;
  public Text txtItemDetailResistFire;
  public Text txtItemDetailResistIce;
  public Text txtItemDetailResistLight;
  public Text txtItemDetailResistShadow;
  public Text txtItemDetailResistPoison;
  public Text txtItemDetailResistSilence;
  public Text txtItemDetailResistBind;
  public Text txtItemDetailResistSleep;
  public Text txtItemDetailResistStun;
  public Text txtItemDetailResistParalyze;
  public Text txtItemDetailResistFreeze;
  public Text txtItemDetailResistFear;
  public Text txtItemDetailResistSlow;
  public Text txtItemDetailResistDizzy;
  public Text txtItemDetailResistSlip;
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
  public Image imgItemDataAmplifyPA;
  public Image imgItemDataAmplifyPD;
  public Image imgItemDataAmplifyMA;
  public Image imgItemDataAmplifyMD;
  public Image imgItemDataAmplifyBS;
  public Image imgItemDataAmplifyBR;
  public Image imgItemDataAmplifyPO;
  public Image imgItemDetailAmplifyFire;
  public Image imgItemDetailAmplifyIce;
  public Image imgItemDetailAmplifyLight;
  public Image imgItemDetailAmplifyShadow;
  public Image imgItemDetailResistFire;
  public Image imgItemDetailResistIce;
  public Image imgItemDetailResistLight;
  public Image imgItemDetailResistShadow;
  public Image imgItemDetailResistPosion;
  public Image imgItemDetailResistSlience;
  public Image imgItemDetailResistBind;
  public Image imgItemDetailResistSleep;
  public Image imgItemDetailResistStun;
  public Image imgItemDetailResistParalyze;
  public Image imgItemDetailResistFreeze;
  public Image imgItemDetailResistFear;
  public Image imgItemDetailResistSlow;
  public Image imgItemDetailResistDizzy;
  public Image imgItemDetailResistSlip;

  public GameObject GroupDeleteDecision;

  public Image imgDeleteItem;
  public Text txtDeleteTitle;
  public Text txtDeleteMessage;
  public Button btnDelete;
  public Button btnCancel;
  public Button btnOK;

  public List<NodeBackpackItem> BackpackList = new List<NodeBackpackItem>();
  public List<NodeBackpackItem> PreciousList = new List<NodeBackpackItem>();

  public GameObject objBlockFilter;

  public MotherBase ParentView;

  public Item CurrentSelectBackpack;

  public void ConstructBackpackView(MotherBase parent_view)
  {
    if (parent_view != null)
    {
      this.ParentView = parent_view;
    }

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

    foreach (Transform n in ContentPrecious.transform)
    {
      GameObject.Destroy(n.gameObject);
    }
    ContentPrecious.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    PreciousList.Clear();
    counter = 0;
    for (int ii = 0; ii < One.TF.PreciousItemList.Count; ii++)
    {
      NodeBackpackItem current = Instantiate(nodePreciousItem) as NodeBackpackItem;
      current.Construct(ContentPrecious, One.TF.PreciousItemList[ii].ItemName, One.TF.PreciousItemList[ii].StackValue, ii, counter);
      counter++;
      PreciousList.Add(current);
    }
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

  public void TapPreciousItemSelect(NodeBackpackItem backpack)
  {
    Debug.Log("TapPreciousItemSelect(S)");
    for (int ii = 0; ii < PreciousList.Count; ii++)
    {
      Debug.Log("PreciousList: " + PreciousList[ii].txtName.text);
      PreciousList[ii].imgSelect.gameObject.SetActive(false);
    }
    backpack.imgSelect.gameObject.SetActive(true);

    txtPreciousDescription.text = new Item(backpack.txtName.text).Description;
  }

  public void TapCancelUse()
  {
    objBlockFilter.SetActive(false);
  }

  public void TapBackpackDetail()
  {
    if (this.CurrentSelectBackpack != null)
    {
      SetupItemDetail(this.CurrentSelectBackpack, imgItemDetail, txtItemDetailName, txtItemDetailType, txtItemDetailDesc, txtItemDetailSTR, txtItemDetailAGL, txtItemDetailINT, txtItemDetailSTM, txtItemDetailMND, txtItemDetailPA, txtItemDetailPAMax, txtItemDetailPD, txtItemDetailMA, txtItemDetailMAMax, txtItemDetailMD, txtItemDetailACC, txtItemDetailSPD, txtItemDetailRSP, txtItemDetailPO,
        txtItemDetailAmplifyPA, txtItemDetailAmplifyPD, txtItemDetailAmplifyMA, txtItemDetailAmplifyMD, txtItemDetailAmplifyBS, txtItemDetailAmplifyBR, txtItemDetailAmplifyPO,
        txtItemDetailAmplifyFire, txtItemDetailAmplifyIce, txtItemDetailAmplifyLight, txtItemDetailAmplifyShadow, txtItemDetailResistFire, txtItemDetailResistIce, txtItemDetailResistLight, txtItemDetailResistShadow,
        txtItemDetailResistPoison, txtItemDetailResistSilence, txtItemDetailResistBind, txtItemDetailResistSleep, txtItemDetailResistStun, txtItemDetailResistParalyze, txtItemDetailResistFreeze, txtItemDetailResistFear, txtItemDetailResistSlow, txtItemDetailResistDizzy, txtItemDetailResistSlip,
        imgItemDetailSTR, imgItemDetailAGL, imgItemDetailINT, imgItemDetailSTM, imgItemDetailMND, imgItemDetailPA, imgItemDetailPAMax, imgItemDetailPD, imgItemDetailMA, imgItemDetailMAMax, imgItemDetailMD, imgItemDetailACC, imgItemDetailSPD, imgItemDetailRSP, imgItemDetailPO,
        imgItemDataAmplifyPA, imgItemDataAmplifyPD, imgItemDataAmplifyMA, imgItemDataAmplifyMD, imgItemDataAmplifyBS, imgItemDataAmplifyBR, imgItemDataAmplifyPO,
        imgItemDetailAmplifyFire, imgItemDetailAmplifyIce, imgItemDetailAmplifyLight, imgItemDetailAmplifyShadow, imgItemDetailResistFire, imgItemDetailResistIce, imgItemDetailResistLight, imgItemDetailResistShadow,
        imgItemDetailResistPosion, imgItemDetailResistSlience, imgItemDetailResistBind, imgItemDetailResistSleep, imgItemDetailResistStun, imgItemDetailResistParalyze, imgItemDetailResistFreeze, imgItemDetailResistFear, imgItemDetailResistSlow, imgItemDetailResistDizzy, imgItemDetailResistSlip);

      GroupItemDetail.SetActive(true);
    }
  }

  private void SetupItemDetail(Item item, Image img_item,
                             Text txt_name, Text txt_type, Text txt_desc, Text txt_str, Text txt_agl, Text txt_int, Text txt_stm, Text txt_mnd,
                             Text txt_pa, Text txt_pa_max, Text txt_pd, Text txt_ma, Text txt_ma_max, Text txt_md, Text txt_acc, Text txt_spd, Text txt_rsp, Text txt_po,
                             Text txt_amp_pa, Text txt_amp_pd, Text txt_amp_ma, Text txt_amp_md, Text txt_amp_bs, Text txt_amp_br, Text txt_amp_po,
                             Text txt_amp_fire, Text txt_amp_ice, Text txt_amp_light, Text txt_amp_shadow, Text txt_res_fire, Text txt_res_ice, Text txt_res_light, Text txt_res_shadow,
                             Text txt_res_poison, Text txt_res_silence, Text txt_res_bind, Text txt_res_sleep, Text txt_res_stun, Text txt_res_paralyze, Text txt_res_freeze, Text txt_res_fear, Text txt_res_slow, Text txt_res_dizzy, Text txt_res_slip,
                             Image img_str, Image img_agl, Image img_int, Image img_stm, Image img_mnd,
                             Image img_pa, Image img_pa_max, Image img_pd, Image img_ma, Image img_ma_max, Image img_md, Image img_acc, Image img_spd, Image img_rsp, Image img_po,
                             Image img_amp_pa, Image img_amp_pd, Image img_amp_ma, Image img_amp_md, Image img_amp_bs, Image img_amp_br, Image img_amp_po,
                             Image img_amp_fire, Image img_amp_ice, Image img_amp_light, Image img_amp_shadow, Image img_res_fire, Image img_res_ice, Image img_res_light, Image img_res_shadow,
                             Image img_resist_poison, Image img_resist_silence, Image img_resist_bind, Image img_resist_sleep, Image img_resist_stun, Image img_resist_paralyze, Image img_resist_freeze, Image img_resist_fear, Image img_resist_slow, Image img_resist_dizzy, Image img_resist_slip)
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

    txt_amp_pa.text = (Math.Round((0.00f + item.AmplifyPhysicalAttack), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_amp_pd.text = (Math.Round((0.00f + item.AmplifyPhysicalDefense), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_amp_ma.text = (Math.Round((0.00f + item.AmplifyMagicAttack), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_amp_md.text = (Math.Round((0.00f + item.AmplifyMagicDefense), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_amp_bs.text = (Math.Round((0.00f + item.AmplifyBattleSpeed), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_amp_br.text = (Math.Round((0.00f + item.AmplifyBattleResponse), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_amp_po.text = (Math.Round((0.00f + item.AmplifyPotential), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";

    txt_amp_fire.text = (Math.Round((0.00f + item.AmplifyFire), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_amp_ice.text = (Math.Round((0.00f + item.AmplifyIce), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_amp_light.text = (Math.Round((0.00f + item.AmplifyLight), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_amp_shadow.text = (Math.Round((0.00f + item.AmplifyShadow), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_res_fire.text = (Math.Round((0.00f + item.ResistFirePercent), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_res_ice.text = (Math.Round((0.00f + item.ResistIcePercent), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_res_light.text = (Math.Round((0.00f + item.ResistLightPercent), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_res_shadow.text = (Math.Round((0.00f + item.ResistShadowPercent), 2, MidpointRounding.AwayFromZero) * 100).ToString() + "%";
    txt_res_poison.text = (item.ResistPoison ? "○" : "");
    txt_res_silence.text = (item.ResistSilence ? "○" : "");
    txt_res_bind.text = (item.ResistBind ? "○" : "");
    txt_res_sleep.text = (item.ResistSleep ? "○" : "");
    txt_res_stun.text = (item.ResistStun ? "○" : "");
    txt_res_paralyze.text = (item.ResistParalyze ? "○" : "");
    txt_res_freeze.text = (item.ResistFreeze ? "○" : "");
    txt_res_fear.text = (item.ResistFear ? "○" : "");
    txt_res_slow.text = (item.ResistSlow ? "○" : "");
    txt_res_dizzy.text = (item.ResistDizzy ? "○" : "");
    txt_res_slip.text = (item.ResistSlip ? "○" : "");

    img_str.color = (item.Strength <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(1.0f, 0, 0));
    img_agl.color = (item.Agility <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(0, 0, 1.0f));
    img_int.color = (item.Intelligence <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(125.0f / 255.0f, 0, 191.0f / 255.0f));
    img_stm.color = (item.Stamina <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(16.0f / 255.0f, 141.0f / 255.0f, 0));
    img_mnd.color = (item.Mind <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(1.0f, 1.0f, 0));
    img_pa.color = (item.PhysicalAttack <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(1.0f, 0, 0));
    img_pa_max.color = (item.PhysicalAttackMax <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(1.0f, 0, 0));
    img_pd.color = (item.PhysicalDefense <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(1.0f, 0, 0));
    img_ma.color = (item.MagicAttack <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(125.0f / 255.0f, 0, 191.0f / 255.0f));
    img_ma_max.color = (item.MagicAttackMax <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(125.0f / 255.0f, 0, 191.0f / 255.0f));
    img_md.color = (item.MagicDefense <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(125.0f / 255.0f, 0, 191.0f / 255.0f));
    img_acc.color = (item.BattleAccuracy <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(0, 0, 1.0f));
    img_spd.color = (item.BattleSpeed <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(0, 0, 1.0f));
    img_rsp.color = (item.BattleResponse <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(0, 0, 1.0f));
    img_po.color = (item.Potential <= 0 ? Fix.COLOR_NORMAL_EFFECT : new Color(1.0f, 1.0f, 0));

    img_amp_pa.color = (item.AmplifyPhysicalAttack > 1.00f ? new Color(1.0f, 0, 0) : Fix.COLOR_NORMAL_EFFECT);
    img_amp_pd.color = (item.AmplifyPhysicalDefense > 1.00f ? new Color(1.0f, 0, 0) : Fix.COLOR_NORMAL_EFFECT);
    img_amp_ma.color = (item.AmplifyMagicAttack > 1.00f ? new Color(125.0f / 255.0f, 0, 191.0f / 255.0f) : Fix.COLOR_NORMAL_EFFECT);
    img_amp_md.color = (item.AmplifyMagicDefense > 1.00f ? new Color(125.0f / 255.0f, 0, 191.0f / 255.0f) : Fix.COLOR_NORMAL_EFFECT);
    img_amp_bs.color = (item.AmplifyBattleSpeed > 1.00f ? new Color(0, 0, 1.0f) : Fix.COLOR_NORMAL_EFFECT);
    img_amp_br.color = (item.AmplifyBattleResponse > 1.00f ? new Color(0, 0, 1.0f) : Fix.COLOR_NORMAL_EFFECT);
    img_amp_po.color = (item.AmplifyPotential > 1.00f ? new Color(1.0f, 1.0f, 0) : Fix.COLOR_NORMAL_EFFECT);

    img_amp_fire.color = (item.AmplifyFire > 1.00f ? new Color(1.0f, 0, 0) : Fix.COLOR_NORMAL_EFFECT);
    img_amp_ice.color = (item.AmplifyIce > 1.00f ? new Color(0, 0, 1.0f) : Fix.COLOR_NORMAL_EFFECT);
    img_amp_light.color = (item.AmplifyLight > 1.00f ? new Color(1.0f, 1.0f, 0) : Fix.COLOR_NORMAL_EFFECT);
    img_amp_shadow.color = (item.AmplifyShadow > 1.00f ? new Color(0, 0, 0) : Fix.COLOR_NORMAL_EFFECT);
    //txt_amp_shadow.color = (item.AmplifyShadow > 1.00f ? new Color(1, 1, 1) : new Color(0, 0, 0));
    img_res_fire.color = (item.ResistFirePercent > 0.00f ? new Color(1.0f, 0, 0) : Fix.COLOR_NORMAL_EFFECT);
    img_res_ice.color = (item.ResistIcePercent > 0.00f ? new Color(0, 0, 1.0f) : Fix.COLOR_NORMAL_EFFECT);
    img_res_light.color = (item.ResistLightPercent > 0.00f ? new Color(1.0f, 1.0f, 0) : Fix.COLOR_NORMAL_EFFECT);
    img_res_shadow.color = (item.ResistShadowPercent > 0.00f ? new Color(0, 0, 0) : Fix.COLOR_NORMAL_EFFECT);
    //txt_res_shadow.color = (item.ResistShadowPercent > 0.00f ? new Color(1, 1, 1) : new Color(0, 0, 0));

    img_resist_poison.color = (item.ResistPoison ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_silence.color = (item.ResistSilence ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_bind.color = (item.ResistBind ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_sleep.color = (item.ResistSleep ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_stun.color = (item.ResistStun ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_paralyze.color = (item.ResistParalyze ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_freeze.color = (item.ResistFreeze ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_fear.color = (item.ResistFear ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_slow.color = (item.ResistSlow ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_dizzy.color = (item.ResistDizzy ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
    img_resist_slip.color = (item.ResistSlip ? Fix.COLOR_RESIST_ENABLE : Fix.COLOR_NORMAL_EFFECT);
  }

  public void TapBackpackDetailCancel()
  {
    GroupItemDetail.SetActive(false);
  }

  public void TapBackpackDelete()
  {
    Debug.Log("TapBackpackDelete(S)");
    if (this.CurrentSelectBackpack == null) { Debug.Log("CurrentSelectBackpack is null..."); }
    if (this.imgDeleteItem == null) { Debug.Log("imgDeleteItem is null..."); }

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
    ConstructBackpackView(null);
  }

  public void TapDeleteCancel()
  {
    GroupDeleteDecision.SetActive(false);
  }

}
