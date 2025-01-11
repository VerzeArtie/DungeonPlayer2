using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MotherBase
{
  public SaveLoad groupSaveLoad;
  public GameObject groupConfig;
  public GameObject groupSeekerMode;
  public GameObject GroupSystemMessage;
  public Text SystemMessageText;

  // Config
  public GameObject groupAccount;
  public Text account;
  public GameObject buttonTicket;
  public Text supportMessage;
  public Text GameEndMessage;
  public Text lblTutorial;
  public Text lblGameStart;
  public Text lblSeeker;
  public Text lblLoad;
  public Text lblConfig;
  public Text lblExit;

  public Slider BGMSlider = null;
  public Slider SoundSlider = null;
  public Slider DifficultySilder = null;
  public Toggle ToggleSupportLog = null;
  public Text TextAccount = null;
  // public Button LanguageEngligh = null;
  // public Button LanguageJapanese = null;
  public Text SupportMessage = null;
  public InputField AccountInputField = null;

  // debug
  public Text txtEnemy1;
  public Text txtEnemy2;
  public Text txtEnemy3;
  public Text txtDuel;
  public Text txtBoss;
  public Text txtBoss2;
  public Text txtBoss3;

  bool firstAction = false;
  // Start is called before the first frame update
  public override void Start()
  {
    base.Start();

    // debug
    XmlDocument xml2 = new XmlDocument();
    xml2.Load(One.PathForRootFile(Fix.AR_FILE));
    Type typeAR = One.AR.GetType();
    foreach (PropertyInfo pi in typeAR.GetProperties())
    {
      if (pi.PropertyType == typeof(System.Int32))
      {
        try
        {
          pi.SetValue(One.AR, Convert.ToInt32(xml2.GetElementsByTagName(pi.Name)[0].InnerText), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.String))
      {
        try
        {
          pi.SetValue(One.AR, (xml2.GetElementsByTagName(pi.Name)[0].InnerText), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Double))
      {
        try
        {
          pi.SetValue(One.AR, Convert.ToDouble(xml2.GetElementsByTagName(pi.Name)[0].InnerText), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Single))
      {
        try
        {
          pi.SetValue(One.AR, Convert.ToSingle(xml2.GetElementsByTagName(pi.Name)[0].InnerText), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Boolean))
      {
        try
        {
          pi.SetValue(One.AR, Convert.ToBoolean(xml2.GetElementsByTagName(pi.Name)[0].InnerText), null);
        }
        catch { }
      }
    }

    // Config
    try
    {
      XmlDocument xmlConfig = new XmlDocument();
      xmlConfig.Load(One.PathForRootFile(Fix.GameSettingFileName));

      Type typeCONF = One.CONF.GetType();
      foreach (PropertyInfo pi in typeCONF.GetProperties())
      {
        if (pi.PropertyType == typeof(System.Int32))
        {
          try
          {
            pi.SetValue(One.CONF, Convert.ToInt32(xmlConfig.GetElementsByTagName(pi.Name)[0].InnerText), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.String))
        {
          try
          {
            pi.SetValue(One.CONF, (xmlConfig.GetElementsByTagName(pi.Name)[0].InnerText), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Double))
        {
          try
          {
            pi.SetValue(One.CONF, Convert.ToDouble(xmlConfig.GetElementsByTagName(pi.Name)[0].InnerText), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Single))
        {
          try
          {
            pi.SetValue(One.CONF, Convert.ToSingle(xmlConfig.GetElementsByTagName(pi.Name)[0].InnerText), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Boolean))
        {
          try
          {
            pi.SetValue(One.CONF, Convert.ToBoolean(xmlConfig.GetElementsByTagName(pi.Name)[0].InnerText), null);
          }
          catch { }
        }
      }
    }
    catch { }

    this.BGMSlider.value = (float)((float)One.CONF.EnableBGM);
    this.SoundSlider.value = (float)((float)One.CONF.EnableSoundEffect);
    //this.battleSpeedBar.Value = this.battleSpeed;
    this.DifficultySilder.value = One.CONF.Difficulty;
    this.ToggleSupportLog.isOn = One.CONF.SupportLog;
    //if (One.Language == One.GameLanguage.English)
    //{
    //  LanguageEngligh.Select();
    //}
    //else
    //{
    //  LanguageJapanese.Select();
    //}
    Debug.Log("One.CONF.Account " + One.CONF.Account);
    this.TextAccount.text = "AccountID: " + One.CONF.Account;
    AccountInputField.text = One.CONF.Account;
  }

  // Update is called once per frame
  void Update()
  {
    if (this.firstAction == false)
    {
      this.firstAction = true;
      // 初期開始時、ファイルが無い場合準備しておく。
      One.MakeDirectory();

      if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
      {
        groupSeekerMode.SetActive(true);
      }
    }
  }

  public void TapStartSeeker()
  {
    Debug.Log("TapStartSeeker ok");
    TapCancelSystemMessage();

    One.RealWorldLoad();
    One.StopDungeonMusic();

    if (One.TF.EventCore_IdentifyFeltus)
    {
      
      One.TF.CurrentDungeonField = Fix.MAPFILE_BASE_FIELD;
      // 初期スタートの位置
      if (One.TF.InitBasefieldStart == false)
      {
        One.TF.InitBasefieldStart = true;
        One.TF.Field_X = Fix.BASEFIELD_EVENT_1_X;
        One.TF.Field_Y = Fix.BASEFIELD_EVENT_1_Y;
        One.TF.Field_Z = Fix.BASEFIELD_EVENT_1_Z;
      }
      SceneDimension.JumpToDungeonField();
    }
    else if (One.TF.SaveByDungeon)
    {
      SceneDimension.JumpToDungeonField();
    }
    else
    {
      SceneDimension.JumpToHomeTown();
    }
  }

  public void TapCancelSystemMessage()
  {
    this.SystemMessageText.text = "";
    this.GroupSystemMessage.SetActive(false);
  }

  public void TapGameStart()
  {
    Debug.Log("TapGameStart ok");

    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      SystemMessageText.text = "アイン・ウォーレンスは並行世界へと突入しており、選択不可。";
      GroupSystemMessage.SetActive(true);
      return;
    }

    if (System.IO.File.Exists(One.PathForRootFile(Fix.AR_FILE)) == false)
    {
      Debug.Log("PathForRootFile(Fix.AR_FILE no exist, then create it.: " + One.PathForRootFile(Fix.AR_FILE));
      One.UpdateAkashicRecord();
    }
    else
    {
      Debug.Log("PathForRootFile(Fix.AR_FILE exist, then no action.: " + One.PathForRootFile(Fix.AR_FILE));
    }

    One.TF.AvailableEinWolence = true;
    One.TF.AvailableLanaAmiria = true;
    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    One.TF.BattlePlayer2 = Fix.NAME_LANA_AMIRIA;
    One.TF.CurrentAreaName = Fix.TOWN_ANSHET;
    One.TF.BeforeAreaName = Fix.TOWN_ANSHET;
    One.StopDungeonMusic();
    SceneDimension.JumpToHomeTown();
  }

  public void TapGameStartDungeon()
  {
    if (System.IO.File.Exists(One.PathForRootFile(Fix.AR_FILE)) == false)
    {
      Debug.Log("PathForRootFile(Fix.AR_FILE no exist, then create it.: " + One.PathForRootFile(Fix.AR_FILE));
      One.UpdateAkashicRecord();
    }
    else
    {
      Debug.Log("PathForRootFile(Fix.AR_FILE exist, then no action.: " + One.PathForRootFile(Fix.AR_FILE));
    }

    One.TF.AvailableEinWolence = true;
    One.TF.AvailableLanaAmiria = true;
    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    One.TF.BattlePlayer2 = Fix.NAME_LANA_AMIRIA;
    One.TF.CurrentAreaName = Fix.TOWN_ANSHET;
    One.TF.BeforeAreaName = Fix.TOWN_ANSHET;
    One.StopDungeonMusic();
    One.TF.CurrentDungeonField = Fix.MAPFILE_VELGUS;
    SceneDimension.JumpToDungeonField();
  }

  public void TapGameLoad()
  {
    if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
    {
      SystemMessageText.text = "アイン・ウォーレンスは並行世界へと突入しており、選択不可。";
      GroupSystemMessage.SetActive(true);
      return;
    }

    One.SaveMode = false;
    One.AfterBacktoTitle = false;
    One.SaveAndExit = false;
    this.groupSaveLoad.SceneLoading();
    this.groupSaveLoad.gameObject.SetActive(true);
    //SceneDimension.CallSaveLoad(this, false, false);
  }

  public void TapExit()
  {
    Application.Quit();
  }

  public void TapConfig()
  {
    TapCancelSystemMessage();
    groupConfig.SetActive(true);
  }

  public void TapClose()
  {
    groupConfig.SetActive(false);
    groupSaveLoad.gameObject.SetActive(false);
  }

  public void TapBattleTest()
  {
    One.BattleEnd = Fix.GameEndType.None;

    One.TF.AvailableEoneFulnea = true;
    One.TF.AvailableBillyRaki = true;

    Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    ein.FireBall = 6;
    //ein.FlameBlade = 1;
    //ein.GaleWind = 1;
    //ein.IceNeedle = 1;
    //ein.FreezingCube = 1;
    //ein.VolcanicBlaze = 1;
    //ein.IronBuster = 1;
    //ein.CounterAttack = 1;
    //ein.CursedEvangile = 1;
    //ein.PenetrationArrow = 1;
    //ein.CircleOfSerenity = 1;
    //ein.WillAwakening = 1;
    //ein.PhantomOboro = 1;
    //ein.DeadlyDrive = 1;
    //ein.DominationField = 1;
    //ein.HunterShot = 1;
    //ein.ShiningHeal = 1;
    //ein.BloodSign = 1;
    //ein.CircleOfTheDespair = 1;
    //ein.RagingStorm = 1;
    //ein.FreshHeal = 1;
    //ein.EnergyBolt = 1;
    //ein.SpeedStep = 1;
    //ein.LeylineSchema = 3;
    //ein.OracleCommand = 6;
    //ein.EnergyBolt = 4;
    ein.FortuneSpirit = 3;
    ein.StanceOfTheBlade = 1;
    ein.StanceOfTheGuard = 20;
    //ein.SpiritualRest = 1;
    ein.WordOfPower = 6;
    //ein.SigilOfThePending = 4;
    ein.DoubleSlash = 6;
    ein.GaleWind = 3;
    ein.EyeOfTheIsshin = 20;
    ein.PhantomOboro = 3;
    //ein.DominationField = 20;
    ein.WillAwakening = 3;
    ein.FlameStrike = 1;
    ein.SeventhPrinciple = 4;
    ein.HardestParry = 4;
    ein.InnerInspiration = 6;
    ein.ActionCommand1 = Fix.FIRE_BALL;
    ein.ActionCommand2 = Fix.STRAIGHT_SMASH;
    ein.ActionCommand3 = Fix.INNER_INSPIRATION;
    ein.ActionCommand4 = Fix.FRESH_HEAL;
    ein.ActionCommand5 = Fix.SEVENTH_PRINCIPLE;
    ein.ActionCommand6 = Fix.PHANTOM_OBORO;
    ein.ActionCommand7 = Fix.FLAME_STRIKE;
    ein.ActionCommand8 = Fix.GALE_WIND;
    ein.ActionCommand9 = Fix.HARDEST_PARRY;
    ein.Strength = 100;
    ein.Agility = 10;
    ein.Intelligence = 10;
    ein.Mind = 100;
    ein.BaseManaPoint = 999;
    ein.BaseLife = 1000;
    ein.MaxGain();
    //ein.CurrentManaPoint = 2;

    Character lana = One.SelectCharacter(Fix.NAME_LANA_AMIRIA);
    lana.IceNeedle = 6;
    lana.LegStrike = 2;
    lana.ShiningHeal = 1;
    lana.EverflowMind = 1;
    lana.StraightSmash = 1;
    lana.InnerInspiration = 1;
    lana.DispelMagic = 6;
    lana.PurePurification = 3;
    lana.BloodSign = 20;
    lana.SpeedStep = 6;
    lana.SpiritualRest = 4;
    lana.BlackContract = 4;
    lana.CursedEvangile = 4;
    lana.CircleOfSerenity = 4;
    lana.CircleOfTheDespair = 6;
    lana.CounterDisallow = 4;
    lana.ActionCommand1 = Fix.ICE_NEEDLE;
    lana.ActionCommand2 = Fix.SHINING_HEAL;
    lana.ActionCommand3 = Fix.STRAIGHT_SMASH;
    lana.ActionCommand4 = Fix.CIRCLE_OF_SERENITY;
    lana.ActionCommand5 = Fix.COUNTER_DISALLOW;
    lana.ActionCommand6 = Fix.CIRCLE_OF_THE_DESPAIR;
    lana.ActionCommand7 = Fix.BLOOD_SIGN;
    lana.ActionCommand8 = Fix.CURSED_EVANGILE;
    lana.ActionCommand9 = Fix.SPIRITUAL_REST;
    lana.Strength = 100;
    lana.Agility = 10;
    lana.Intelligence = 100;
    lana.Mind = 50;
    lana.BaseManaPoint = 999;
    lana.BaseLife = 1000;
    lana.MaxGain();
    //lana.CurrentManaPoint = 3;

    Character eone = One.SelectCharacter(Fix.NAME_EONE_FULNEA);
    eone.AgilityFood = 1;
    eone.Agility = 30;
    eone.HunterShot = 6;
    eone.DivineCircle = 60;
    eone.MultipleShot = 10;
    eone.BlueBullet = 5;
    eone.HolyBreath = 6;
    eone.UnseenAid = 4;
    eone.FreezingCube = 2;
    eone.AngelicEcho = 1;
    eone.PenetrationArrow = 6;
    eone.FrostLance = 6;
    eone.ShiningHeal = 3;
    eone.PrecisionStrike = 4;
    eone.ActionCommand1 = Fix.FRESH_HEAL;
    eone.ActionCommand2 = Fix.HUNTER_SHOT;
    eone.ActionCommand3 = Fix.SHINING_HEAL;
    eone.ActionCommand4 = Fix.PENETRATION_ARROW;
    eone.ActionCommand5 = Fix.BLUE_BULLET;
    eone.ActionCommand6 = Fix.HOLY_BREATH;
    eone.ActionCommand7 = Fix.PRECISION_STRIKE;
    eone.ActionCommand8 = Fix.ANGELIC_ECHO;
    eone.ActionCommand9 = Fix.FROST_LANCE;
    eone.Strength = 100;
    eone.Agility = 10;
    eone.Intelligence = 100;
    eone.Mind = 10;
    eone.BaseLife = 1000;
    eone.BaseManaPoint = 1000;
    eone.MaxGain();

    Character billy = One.SelectCharacter(Fix.NAME_BILLY_RAKI);
    billy.MeteorBullet = 3;
    billy.ConcussiveHit = 4;
    billy.BoneCrush = 6;
    billy.VoiceOfVigor = 20;
    billy.VolcanicBlaze = 2;
    billy.IronBuster = 6;
    billy.DeadlyDrive = 6;
    billy.RagingStorm = 1;
    billy.EverflowMind = 6;
    billy.ActionCommand1 = Fix.METEOR_BULLET;
    billy.ActionCommand2 = Fix.CONCUSSIVE_HIT;
    billy.ActionCommand3 = Fix.BONE_CRUSH;
    billy.ActionCommand4 = Fix.VOICE_OF_VIGOR;
    billy.ActionCommand5 = Fix.EVERFLOW_MIND;
    billy.ActionCommand6 = Fix.IRON_BUSTER;
    billy.ActionCommand7 = Fix.DEADLY_DRIVE;
    billy.ActionCommand8 = Fix.RAGING_STORM;
    billy.Strength = 100;
    billy.Intelligence = 100;
    billy.Agility = 25;
    billy.Mind = 10;
    billy.BaseLife = 1000;
    billy.MaxGain();
    billy.CurrentLife = 300;

    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    One.TF.BattlePlayer2 = Fix.NAME_LANA_AMIRIA;
    One.TF.BattlePlayer3 = Fix.NAME_EONE_FULNEA;
    One.TF.BattlePlayer4 = Fix.NAME_BILLY_RAKI;

    One.RealWorldLoad();
    List<Character> available = One.AvailableCharacters;
    foreach (Character current in available)
    {
      current.MaxGain();
    }
    One.CreateShadowData();

    One.EnemyList.Clear();
    if (txtEnemy1.text != String.Empty)
    {
      One.BattleEnemyList.Add(txtEnemy1.text);
    }
    if (txtEnemy2.text != String.Empty)
    {
      One.BattleEnemyList.Add(txtEnemy2.text);
    }
    if (txtEnemy3.text != String.Empty)
    {
      One.BattleEnemyList.Add(txtEnemy3.text);
    }

    for (int ii = 0; ii < One.BattleEnemyList.Count; ii++)
    {
      GameObject objEC = new GameObject("objEC_" + ii.ToString());
      Character character = objEC.AddComponent<Character>();
      character.Construction(One.BattleEnemyList[ii]);
      character.MaxGain();
      One.EnemyList.Add(character);
    }

    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    }
    //    SceneDimension.CallBattleEnemy();

    One.BattleMode = Fix.BattleMode.Normal;
    One.StopDungeonMusic();
    SceneDimension.CallBattleEnemy();
  }

  public void TapDuelTest()
  {
    One.BattleEnd = Fix.GameEndType.None;

    One.TF.AvailableEoneFulnea = true;

    Character lana = One.SelectCharacter(Fix.NAME_LANA_AMIRIA);
    lana.Strength = 10;
    lana.Agility = 10;
    lana.Intelligence = 10;
    lana.Mind = 100;
    lana.BaseManaPoint = 999;
    lana.BaseLife = 1000;

    Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    ein.GaleWind = 1;
    ein.IceNeedle = 1;
    ein.FreezingCube = 1;
    ein.VolcanicBlaze = 1;
    ein.IronBuster = 1;
    ein.CounterAttack = 1;
    ein.CursedEvangile = 1;
    ein.PenetrationArrow = 1;
    ein.CircleOfSerenity = 1;
    ein.WillAwakening = 1;
    ein.PhantomOboro = 1;
    ein.DeadlyDrive = 1;
    ein.DominationField = 1;
    ein.FlameStrike = 1;
    ein.FrostLance = 1;
    ein.CounterDisallow = 1;
    ein.PrecisionStrike = 1;
    ein.UnintentionalHit = 1;
    ein.HardestParry = 1;
    ein.EverflowMind = 1;

    ein.Strength = 30;
    ein.Agility = 9;
    ein.Intelligence = 6;
    ein.Stamina = 20;
    ein.Mind = 30;
    ein.BaseManaPoint = 999;
    ein.ActionCommand1 = Fix.STRAIGHT_SMASH;
    ein.ActionCommand2 = Fix.FIRE_BALL;
    ein.ActionCommand3 = Fix.DEFENSE;
    ein.ActionCommand4 = Fix.FLAME_STRIKE;
    ein.ActionCommand5 = Fix.FROST_LANCE;
    ein.ActionCommand6 = Fix.COUNTER_DISALLOW;
    ein.ActionCommand7 = Fix.PRECISION_STRIKE;
    ein.ActionCommand8 = Fix.UNINTENTIONAL_HIT;
    ein.ActionCommand9 = Fix.HARDEST_PARRY;
    ein.MaxGain();

    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;

    One.RealWorldLoad();
    List<Character> available = One.AvailableCharacters;
    foreach (Character current in available)
    {
      current.MaxGain();
    }
    One.CreateShadowData();

    One.EnemyList.Clear();
    if (txtDuel.text != String.Empty)
    {
      One.BattleEnemyList.Add(txtDuel.text);
    }
    for (int ii = 0; ii < One.BattleEnemyList.Count; ii++)
    {
      GameObject objEC = new GameObject("objEC_" + ii.ToString());
      Character character = objEC.AddComponent<Character>();
      character.Construction(One.BattleEnemyList[ii]);
      character.MaxGain();
      One.EnemyList.Add(character);
    }

    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    }
    //    SceneDimension.CallBattleEnemy();

    One.BattleMode = Fix.BattleMode.Duel;
    One.StopDungeonMusic();
    One.LifePointBattle = false;
    SceneDimension.CallBattleEnemy();
  }


  public void TapBossTest()
  {
    One.BattleEnd = Fix.GameEndType.None;

    One.TF.AvailableEoneFulnea = true;

    Character lana = One.SelectCharacter(Fix.NAME_LANA_AMIRIA);
    lana.Strength = 10;
    lana.Agility = 10;
    lana.Intelligence = 10;
    lana.Mind = 100;
    lana.BaseManaPoint = 999;
    lana.BaseLife = 1000;

    Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    ein.GaleWind = 1;
    ein.IceNeedle = 1;
    ein.FreezingCube = 1;
    ein.VolcanicBlaze = 1;
    ein.IronBuster = 1;
    ein.CounterAttack = 1;
    ein.CursedEvangile = 1;
    ein.PenetrationArrow = 1;
    ein.CircleOfSerenity = 1;
    ein.WillAwakening = 1;
    ein.PhantomOboro = 1;
    ein.DeadlyDrive = 1;
    ein.DominationField = 1;
    ein.Strength = 10;
    ein.Agility = 10;
    ein.Intelligence = 10;
    ein.Mind = 100;
    ein.BaseManaPoint = 999;
    ein.BaseLife = 1000;
    ein.ActionCommand1 = Fix.FIRE_BALL;
    ein.ActionCommand2 = Fix.DOMINATION_FIELD;
    ein.ActionCommand3 = Fix.CURSED_EVANGILE;
    ein.ActionCommand4 = Fix.PENETRATION_ARROW;
    ein.ActionCommand5 = Fix.CIRCLE_OF_SERENITY;
    ein.ActionCommand6 = Fix.WILL_AWAKENING;
    ein.ActionCommand7 = Fix.COUNTER_ATTACK;
    ein.ActionCommand8 = Fix.PHANTOM_OBORO;
    ein.ActionCommand9 = Fix.DEADLY_DRIVE;
    ein.MaxGain();
    //Character eone = One.SelectCharacter(Fix.NAME_EONE_FULNEA);
    //eone.AgilityFood = 1;

    One.TF.BattlePlayer1 = Fix.NAME_LANA_AMIRIA;
    One.TF.BattlePlayer2 = Fix.NAME_EIN_WOLENCE;
    //One.TF.BattlePlayer3 = Fix.NAME_EONE_FULNEA;

    One.RealWorldLoad();
    List<Character> available = One.AvailableCharacters;
    foreach (Character current in available)
    {
      current.MaxGain();
    }
    One.CreateShadowData();

    One.EnemyList.Clear();
    if (txtBoss.text != String.Empty)
    {
      One.BattleEnemyList.Add(txtBoss.text);
    }
    if (txtBoss2.text != String.Empty)
    {
      One.BattleEnemyList.Add(txtBoss2.text);
    }
    if (txtBoss3.text != String.Empty)
    {
      One.BattleEnemyList.Add(txtBoss3.text);
    }

    for (int ii = 0; ii < One.BattleEnemyList.Count; ii++)
    {
      GameObject objEC = new GameObject("objEC_" + ii.ToString());
      Character character = objEC.AddComponent<Character>();
      character.Construction(One.BattleEnemyList[ii]);
      //character.Strength = 50;
      //character.Agility = 20;
      //character.Intelligence = 100;
      //character.Mind = 20;
      //character.BaseLife = 999999;
      //character.BaseManaPoint = 99999;
      character.MaxGain();
      One.EnemyList.Add(character);
    }

    for (int ii = 0; ii < One.EnemyList.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    }
    //    SceneDimension.CallBattleEnemy();

    One.BattleMode = Fix.BattleMode.Boss;
    One.StopDungeonMusic();
    SceneDimension.CallBattleEnemy();
  }


  public void ChangeBGMVolume(Slider sender)
  {
    One.CONF.EnableBGM = (int)sender.value;
    One.ChangeDungeonMusicVolume((float)(sender.value / 100.0f));
  }

  public void ChangeSoundEffectVolume(Slider sender)
  {
    One.CONF.EnableSoundEffect = (int)sender.value;
    One.ChangeSoundEffectVolume((float)(sender.value / 100.0f));
  }

  public void ChangeDifficulty(Slider sender)
  {
    One.CONF.Difficulty = (int)sender.value;
  }

  public void ChangeSupportLog(Toggle toggle)
  {
    One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
    One.CONF.SupportLog = toggle.isOn;
  }

  //public void ChangeLanguage(int number)
  //{
  //  One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
  //  if (number == 2)
  //  {
  //    One.Language = One.GameLanguage.English;
  //  }
  //  else
  //  {
  //    One.Language = One.GameLanguage.Japanese;
  //  }
  //}

  public void ChangeAccountName(Text txt)
  {
    One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
    if (txt.text.Length < 2)
    {
      SupportMessage.text = "Please enter 2 or more characters.";
      SupportMessage.gameObject.SetActive(true);
      return;
    }

    if (One.SQL.ExistOwnerName(txt.text))
    {
      SupportMessage.text = "A character with that name already exists.";
      SupportMessage.gameObject.SetActive(true);
      return;
    }
    One.SQL.ChangeOwnerName("ChangeAccountName", string.Empty, string.Empty, txt.text);
    One.CONF.Account = txt.text;
    // Method.AutoSaveTruthWorldEnvironment();
    this.TextAccount.text = "AccountID: " + One.CONF.Account;

    SupportMessage.text = "Account name has been changed.";
    SupportMessage.gameObject.SetActive(true);
  }


  public void tapClose()
  {
    One.PlaySoundEffect(Fix.SOUND_SELECT_TAP);
    try
    {
      //this.battleSpeed = battleSpeedBar.Value;
      //this.difficulty = difficultyBar.Value;

      XmlTextWriter xmlWriter = new XmlTextWriter(Fix.GameSettingFileName, System.Text.Encoding.UTF8);
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteWhitespace("\r\n");

      xmlWriter.WriteStartElement("Body");
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteElementString("DateTime", DateTime.Now.ToString());
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteElementString("EnableBGM", One.CONF.EnableBGM.ToString());
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteElementString("EnableSoundEffect", One.CONF.EnableSoundEffect.ToString());
      xmlWriter.WriteWhitespace("\r\n");
      //xmlWriter.WriteElementString("BattleSpeed", this.battleSpeed.ToString());
      //xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteElementString("Difficulty", One.CONF.Difficulty.ToString());
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteElementString("SupportLog", One.CONF.SupportLog.ToString());
      xmlWriter.WriteWhitespace("\r\n");
      //xmlWriter.WriteElementString("GameLanguage", One.Language.ToString());
      //xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteElementString("Account", One.CONF.Account);
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteEndElement();

      xmlWriter.WriteEndDocument();
      xmlWriter.Close();
    }
    catch { }

    groupConfig.SetActive(false);
    groupSaveLoad.gameObject.SetActive(false);
  }
}
