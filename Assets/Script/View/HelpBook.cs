using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class HelpBook : MotherBase
{
  // GUI
  public GameObject groupAttribute;
  public GameObject groupElement;
  public GameObject groupMixElement;
  public GameObject groupArchetype;
  public GameObject groupCommand;
  public GameObject groupCurrent;
  public GameObject groupAC;
  public GameObject groupBattle;
  public Button[] MenuButton;
  public Text[] MenuButtonText;
  public Button[] ElementButton;
  public Text[] ElementButtonText;
  public Button[] MixElementButton;
  public Text[] MixElementButtonText;
  public Button[] ArchetypeButton;
  public Text[] ArchetypeButtonText;
  public Button[] CommandButton;
  public Text[] CommandButtonText;
  public Image CurrentImage;
  public Text CurrentLabel_JP;
  public Text CurrentLabel_EN;
  public Text CurrentCost;
  public Text CurrentTarget;
  public Text CurrentTiming;
  public GameObject back_CurrentDescription;
  public Text CurrentDescription;
  public GameObject backPanel;
  public Button CloseButton;

  // Use this for initialization
  public override void Start()
  {
    base.Start();

    //if (GroundOne.WE2 != null && GroundOne.WE2.AvailableMixSpellSkill == false)
    //{
    //  AttributeButton[2].gameObject.SetActive(false);
    //  AttributeButton[3].gameObject.SetActive(false);
    //}
    //if (GroundOne.WE2 != null && GroundOne.WE2.AvailableArcheTypeCommand == false)
    //{
    //  AttributeButton[4].gameObject.SetActive(false);
    //}

    //if (GroundOne.TutorialMode)
    //{
    //  AttributeButton[2].gameObject.SetActive(false);
    //  AttributeButton[3].gameObject.SetActive(false);
    //  AttributeButton[4].gameObject.SetActive(false);
    //}

    TapHelpMenu(MenuButtonText[0]);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      tapClose();
    }
  }

  public void TapHelpMenu(Text sender)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + "(S)");
    if (sender.text == Fix.HELPMENU_ACTIONCOMMAND)
    {
      groupAC.SetActive(true);
      groupBattle.SetActive(false);
      tapElement(ElementButtonText[0]);
    }
    else if (sender.text == Fix.HELPMENUL_BATTLE)
    {
      groupAC.SetActive(false);
      groupBattle.SetActive(true);
    }
  }

  public void tapElement(Text sender)
  {
    Debug.Log(MethodBase.GetCurrentMethod() + "(S)");
    //One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
    SelectClassButton(sender);
    SelectCommandButton(CommandButtonText[0]);
  }

  public void tapActionCommand(Text sender)
  {
    //GroundOne.PlaySoundEffect(Database.SOUND_SELECT_TAP);
    SelectCommandButton(sender);
  }

  public void tapAttribute(Text sender)
  {
    //GroundOne.PlaySoundEffect(Database.SOUND_SELECT_TAP);


    //if (sender.text == "魔法")
    //{
    //  groupElement.SetActive(true);
    //  groupMixElement.SetActive(false);
    //  groupArchetype.SetActive(false);
    //  groupCommand.SetActive(true);
    //  // 上ボタン、テキスト更新
    //  ElementButtonText[0].text = "聖";
    //  ElementButtonText[1].text = "火";
    //  ElementButtonText[2].text = "理";
    //  ElementButtonText[3].text = "闇";
    //  ElementButtonText[4].text = "水";
    //  ElementButtonText[5].text = "空";
    //  // 最初の下項目のボタンを選択しておく！
    //  tapElement(ElementButtonText[0]);
    //}
    //else if (sender.text == "スキル")
    //{
    //  groupElement.SetActive(true);
    //  groupMixElement.SetActive(false);
    //  groupArchetype.SetActive(false);
    //  groupCommand.SetActive(true);
    //  // 上ボタン、テキスト更新
    //  ElementButtonText[0].text = "動";
    //  ElementButtonText[1].text = "柔";
    //  ElementButtonText[2].text = "心眼";
    //  ElementButtonText[3].text = "静";
    //  ElementButtonText[4].text = "剛";
    //  ElementButtonText[5].text = "無心";
    //  // 最初の下項目のボタンを選択しておく！
    //  tapElement(ElementButtonText[0]);
    //}
    //else if (sender.text == "複合魔法")
    //{
    //  groupElement.SetActive(false);
    //  groupMixElement.SetActive(true);
    //  groupArchetype.SetActive(false);
    //  groupCommand.SetActive(true);
    //  // 上ボタン、テキスト更新
    //  MixElementButtonText[0].text = "聖/火";
    //  MixElementButtonText[1].text = "聖/理";
    //  MixElementButtonText[2].text = "火/理";
    //  MixElementButtonText[3].text = "闇/水";
    //  MixElementButtonText[4].text = "闇/空";
    //  MixElementButtonText[5].text = "水/空";
    //  MixElementButtonText[6].text = "聖/水";
    //  MixElementButtonText[7].text = "聖/空";
    //  MixElementButtonText[8].text = "火/空";
    //  MixElementButtonText[9].text = "闇/火";
    //  MixElementButtonText[10].text = "闇/理";
    //  MixElementButtonText[11].text = "水/理";
    //  MixElementButtonText[12].text = "聖/闇";
    //  MixElementButtonText[13].text = "火/水";
    //  MixElementButtonText[14].text = "理/空";
    //  // 最初の下項目のボタンを選択しておく！
    //  tapElement(MixElementButtonText[0]);
    //}
    //else if (sender.text == "複合スキル")
    //{
    //  groupElement.SetActive(false);
    //  groupMixElement.SetActive(true);
    //  groupArchetype.SetActive(false);
    //  groupCommand.SetActive(true);
    //  // 上ボタン、テキスト更新
    //  MixElementButtonText[0].text = "動/柔";
    //  MixElementButtonText[1].text = "動/心眼";
    //  MixElementButtonText[2].text = "柔/心眼";
    //  MixElementButtonText[3].text = "静/剛";
    //  MixElementButtonText[4].text = "静/無心";
    //  MixElementButtonText[5].text = "剛/無心";
    //  MixElementButtonText[6].text = "動/剛";
    //  MixElementButtonText[7].text = "動/無心";
    //  MixElementButtonText[8].text = "柔/無心";
    //  MixElementButtonText[9].text = "静/柔";
    //  MixElementButtonText[10].text = "静/心眼";
    //  MixElementButtonText[11].text = "剛/心眼";
    //  MixElementButtonText[12].text = "動/静";
    //  MixElementButtonText[13].text = "柔/剛";
    //  MixElementButtonText[14].text = "心眼/無心";
    //  // 最初の下項目のボタンを選択しておく！
    //  tapElement(MixElementButtonText[0]);
    //}
    //else if (sender.text == "元核")
    //{
    //  groupElement.SetActive(false);
    //  groupMixElement.SetActive(false);
    //  groupArchetype.SetActive(true);
    //  groupCommand.SetActive(true);
    //  // 上ボタン、テキスト更新
    //  ArchetypeButtonText[0].text = "元核";
    //  // 最初の下項目のボタンを選択しておく！
    //  tapElement(ArchetypeButtonText[0]);
    //}
  }

  public void tapClose()
  {
    //One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
    SceneDimension.SceneClose(Fix.SCENE_HELP_BOOK);
  }

  private void SelectClassButton(Text sender)
  {
    //GroundOne.PlaySoundEffect(Database.SOUND_SELECT_TAP);
    //bool tutorialSkill = false;
    //Color targetColor = Color.white;
    int counter = 0;
    if (sender.text == Fix.CLASS_WARRIOR_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.STRAIGHT_SMASH); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.STANCE_OF_THE_BLADE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DOUBLE_SLASH); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.IRON_BUSTER); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.RAGING_STORM); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.STANCE_OF_THE_IAI); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.KINETIC_SMASH); counter++;
    }
    else if (sender.text == Fix.CLASS_ARCHERY_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.HUNTER_SHOT); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.MULTIPLE_SHOT); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.EYE_OF_THE_ISSHIN); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.PENETRATION_ARROW); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.PRECISION_STRIKE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ETERNAL_CONCENTRATION); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.PIERCING_ARROW); counter++;
    }
    else if (sender.text == Fix.CLASS_MARTIAL_ARTS_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.LEG_STRIKE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SPEED_STEP); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.BONE_CRUSH); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DEADLY_DRIVE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.UNINTENTIONAL_HIT); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.STANCE_OF_MUIN); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.CARNAGE_RUSH); counter++;
    }
    else if (sender.text == Fix.CLASS_COMBAT_TRICK_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.VENOM_SLASH); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.INVISIBLE_BIND); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.IRREGULAR_STEP); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ASSASSINATION_HIT); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.COUNTER_DISALLOW); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DIRTY_WISDOM); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.AMBIDEXTERITY); counter++;
    }
    else if (sender.text == Fix.CLASS_WONDER_HERMIT_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ENERGY_BOLT); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.IDEOLOGY_OF_SOPHISTICATION); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SIGIL_OF_THE_PENDING); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.PHANTOM_OBORO); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SIGIL_OF_THE_HOMURA); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.WORD_OF_PROPHECY); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.TRANSCENDENCE_REACHED); counter++;
    }
    else if (sender.text == Fix.CLASS_GUARDIAN_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SHIELD_BASH); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.STANCE_OF_THE_GUARD); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.CONCUSSIVE_HIT); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DOMINATION_FIELD); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.HARDEST_PARRY); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.WILD_SWING); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ONE_IMMUNITY); counter++;
    }
    else if (sender.text == Fix.CLASS_FIRE_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.FIRE_BALL); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.FLAME_BLADE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.METEOR_BULLET); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.VOLCANIC_BLAZE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.FLAME_STRIKE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.CIRCLE_OF_THE_IGNITE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.LAVA_ANNIHILATION); counter++;
    }
    else if (sender.text == Fix.CLASS_ICE_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ICE_NEEDLE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.PURE_PURIFICATION); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.BLUE_BULLET); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.FREEZING_CUBE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.FROST_LANCE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.WATER_PRESENCE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ABSOLUTE_ZERO); counter++;
    }
    else if (sender.text == Fix.CLASS_HOLYLIGHT_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.FRESH_HEAL); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DIVINE_CIRCLE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.HOLY_BREATH); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ANGELIC_ECHO); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SHINING_HEAL); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.VALKYRIE_BLADE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.RESURRECTION); counter++;
    }
    else if (sender.text == Fix.CLASS_DARK_MAGIC_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SHADOW_BLAST); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.BLOOD_SIGN); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.BLACK_CONTRACT); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.CURSED_EVANGILE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.CIRCLE_OF_THE_DESPAIR); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.THE_DARK_INTENSITY); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DEATH_SCYTHE); counter++;
    }
    else if (sender.text == Fix.CLASS_WIND_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.AIR_CUTTER); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.STORM_ARMOR); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SONIC_PULSE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.GALE_WIND); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ERRATIC_THUNDER); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.CYCLONE_FIELD); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.LIGHTNING_SQUALL); counter++;
    }
    else if (sender.text == Fix.CLASS_EARTH_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ROCK_SLAM); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SOLID_WALL); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.LAND_SHATTER); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SAND_BURST); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.PETRIFICATION); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.LIFE_GRACE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.EARTH_QUAKE); counter++;
    }
    //else if (sender.text == Fix.CLASS_ENHANCE)
    //{
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.AURA_OF_POWER); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SKY_SHIELD); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.AETHER_DRIVE); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.CIRCLE_OF_SERENITY); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.REVOLUTION_AURA); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.BRILLIANT_FORM); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.AUSTERITY_MATRIX); counter++;
    //}
    //else if (sender.text == Fix.CLASS_MYSTIC)
    //{
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DISPEL_MAGIC); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.FLASH_COUNTER); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.MUTE_IMPULSE); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DETACHMENT_FAULT); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.OATH_OF_AEGIS); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.FUTURE_VISION); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ESSENCE_OVERFLOW); counter++;
    //}
    //else if (sender.text == Fix.CLASS_BRAVE)
    //{
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.HEART_OF_LIFE); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.FORTUNE_SPIRIT); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.VOICE_OF_VIGOR); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.AURA_BURN); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.EVERFLOW_MIND); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SOUL_SHOUT); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.OVERWHELMING_DESTINY); counter++;
    //}
    //else if (sender.text == Fix.CLASS_VENGEANCE)
    //{
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DARK_AURA); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.STANCE_OF_THE_SHADE); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.KILLING_WAVE); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.LEVEL_EATER); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ABYSS_EYE); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.AVENGER_PROMISE); counter++;
    //  SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.DEMON_CONTRACT); counter++;
    //}
    else if (sender.text == Fix.CLASS_TRUTH_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.TRUE_SIGHT); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.LEYLINE_SCHEMA); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.WORD_OF_POWER); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.WILL_AWAKENING); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.MIND_FORCE); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SIGIL_OF_THE_FAITH); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.STANCE_OF_THE_KOKOROE); counter++;
    }
    else if (sender.text == Fix.CLASS_MINDFULNESS_JP)
    {
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ORACLE_COMMAND); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.SPIRITUAL_REST); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.UNSEEN_AID); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.EXACT_TIME); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.INNER_INSPIRATION); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.ZERO_IMMUNITY); counter++;
      SetupCommandButton(CommandButton[counter], CommandButtonText[counter], Fix.TIME_SKIP); counter++;
    }
    //else if (sender.text == "元核")
    //{
    //  SetupCommandButton(CommandButton[0], CommandButtonText[0], Database.ARCHETYPE_EIN_JP);
    //  SetupCommandButton(CommandButton[1], CommandButtonText[1], ""); // Database.ARCHETYPE_RANA_JP);
    //  SetupCommandButton(CommandButton[2], CommandButtonText[2], ""); // Database.ARCHETYPE_OL_JP);
    //  SetupCommandButton(CommandButton[3], CommandButtonText[3], ""); // Database.ARCHETYPE_VERZE_JP);
    //  SetupCommandButton(CommandButton[4], CommandButtonText[4], "");
    //  SetupCommandButton(CommandButton[5], CommandButtonText[5], "");
    //  SetupCommandButton(CommandButton[6], CommandButtonText[6], "");
    //}

    //if (GroundOne.TutorialMode)
    //{
    //  if (tutorialSkill == false)
    //  {
    //    SetupCommandButton(CommandButton[2], CommandButtonText[2], "？？？");
    //    SetupCommandButton(CommandButton[3], CommandButtonText[3], "？？？");
    //    SetupCommandButton(CommandButton[4], CommandButtonText[4], "？？？");
    //    SetupCommandButton(CommandButton[5], CommandButtonText[5], "？？？");
    //    SetupCommandButton(CommandButton[6], CommandButtonText[6], "？？？");
    //  }
    //  else
    //  {
    //    SetupCommandButton(CommandButton[1], CommandButtonText[1], "？？？");
    //    SetupCommandButton(CommandButton[2], CommandButtonText[2], "？？？");
    //    SetupCommandButton(CommandButton[3], CommandButtonText[3], "？？？");
    //  }
    //}

    //this.backPanel.GetComponent<Image>().color = targetColor;
    //SelectCommandButton(CommandButtonText[0]);
  }

  private void SelectCommandButton(Text sender)
  {
    //GroundOne.PlaySoundEffect(Database.SOUND_SELECT_TAP);

    if (sender == null) return;
    if (sender.text == "？？？") return;
    if (sender.text == "") return;

    string command = sender.text;

    CurrentLabel_EN.text = command;
    CurrentLabel_JP.text = ActionCommand.To_JP(command);
    CurrentImage.sprite = Resources.Load<Sprite>(command);
    CurrentDescription.text = ActionCommand.GetDescription(command); 
    CurrentCost.text = ActionCommand.Cost(command).ToString();


    if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.Enemy)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_ENEMY;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.Ally)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_ALLY;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.EnemyGroup)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_ENEMYGROUP;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.AllyGroup)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_ALLYGROUP;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.EnemyField)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_ENEMYGROUP;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.AllyField)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_ALLYGROUP;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.AllMember)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_ALLMEMBER;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.EnemyOrAlly)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_ENEMYORALLY;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.InstantTarget)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_INSTANTTARGET;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.Own)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_OWN;
    }
    else if (ActionCommand.IsTarget(command) == ActionCommand.TargetType.None)
    {
      CurrentTarget.text = Fix.TARGET_TYPE_NONE;
    }

    if (ActionCommand.GetTiming(sender.text) == ActionCommand.TimingType.Instant)
    {
      CurrentTiming.text = Fix.TIMING_TYPE_INSTANT;
    }
    else if (ActionCommand.GetTiming(sender.text) == ActionCommand.TimingType.Normal)
    {
      CurrentTiming.text = Fix.TIMING_TYPE_NORMAL;
    }
    else if (ActionCommand.GetTiming(sender.text) == ActionCommand.TimingType.Sorcery)
    {
      CurrentTiming.text = Fix.TIMING_TYPE_SORCERY;
    }
  }

  private void SetupCommandButton(Button button, Text txt, string targetName)
  {
    txt.text = targetName;
    if (targetName == "")
    {
      button.GetComponent<Image>().color = Color.clear; button.enabled = false;
    }
    else
    {
      button.GetComponent<Image>().color = Color.white; button.enabled = true;
    }
  }
}