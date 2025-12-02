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
  public Text SupportMessage = null;
  public InputField AccountInputField = null;

  // debug
  public Text txtEnemy1;
  public Text txtEnemy2;
  public Text txtEnemy3;
  public Text txtDuel;
  public Text txtDuelA;
  public Text txtBoss;
  public Text txtBoss2;
  public Text txtBoss3;
  public Text txtMonsterData;

  bool firstAction = false;
  // Start is called before the first frame update
  public override void Start()
  {
    base.Start();
  }

  // Update is called once per frame
  void Update()
  {
    if (this.firstAction == false)
    {
      this.firstAction = true;

      One.PlayDungeonMusic(Fix.BGM12, Fix.BGM12LoopBegin);

      // 初期開始時、ファイルが無い場合準備しておく。
      One.MakeDirectory();

      // Initialize AR and Config
      if (System.IO.File.Exists(One.PathForRootFile(Fix.AR_FILE)) == false)
      {
        Debug.Log("PathForRootFile(Fix.AR_FILE no exist, then create it.: " + One.PathForRootFile(Fix.AR_FILE));
        One.UpdateAkashicRecord();
      }
      else
      {
        Debug.Log("PathForRootFile(Fix.AR_FILE exist, then no action.: " + One.PathForRootFile(Fix.AR_FILE));
      }

      if (System.IO.File.Exists(One.PathForRootFile(Fix.CONF_FILE)) == false)
      {
        Debug.Log("PathForRootFile(Fix.CONF_FILE no exist, then create it.: " + One.PathForRootFile(Fix.CONF_FILE));
        One.UpdateGameConfig();
      }
      else
      {
        Debug.Log("PathForRootFile(Fix.CONF_FILE exist, then no action.: " + One.PathForRootFile(Fix.CONF_FILE));
      }

      // AR Set
      try
      {
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
      }
      catch (Exception ex)
      {
        Debug.Log("Title(AR) Exception: " + ex.ToString());
      }

      // Config Set
      try
      {
        XmlDocument xmlConfig = new XmlDocument();
        xmlConfig.Load(One.PathForRootFile(Fix.CONF_FILE));

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
      catch (Exception ex)
      {
        Debug.Log("Title(Config) Exception: " + ex.ToString());
      }

      this.BGMSlider.value = (float)((float)One.CONF.EnableBGM);
      this.SoundSlider.value = (float)((float)One.CONF.EnableSoundEffect);
      this.DifficultySilder.value = One.CONF.Difficulty;
      this.ToggleSupportLog.isOn = One.CONF.SupportLog;
      Debug.Log("One.CONF.Account " + One.CONF.Account);
      this.TextAccount.text = "AccountID: " + One.CONF.Account;
      AccountInputField.text = One.CONF.Account;

      if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
      {
        groupSeekerMode.SetActive(true);
      }

      TapMonsterData();
    }
  }

  public void TapStartSeeker()
  {
    Debug.Log("TapStartSeeker(S)");
    TapCancelSystemMessage();

    One.RealWorldLoad();
    One.StopDungeonMusic();

    if (One.TF.EventCore_IdentifyFeltus)
    {
      Debug.Log("TapStartSeeker EventCore_IdentifyFeltus");
      Debug.Log("TapStartSeeker One.TF.CurrentDungeonField: " + One.TF.CurrentDungeonField);
      if (One.TF.CurrentDungeonField == Fix.MAPFILE_WOSM_2)
      {
        Debug.Log("TapStartSeeker MAPFILE_WOSM_2");
        SceneDimension.JumpToDungeonField();
      }
      else
      {
        Debug.Log("TapStartSeeker not MAPFILE_WOSM_2, then MAPFILE_BASE_FIELD");
        One.TF.CurrentDungeonField = Fix.MAPFILE_BASE_FIELD;
        // 初期スタートの位置
        if (One.TF.InitBasefieldStart == false)
        {
          Debug.Log("TapStartSeeker InitBasefieldStart false, then reset position");
          One.TF.InitBasefieldStart = true;
          One.TF.Field_X = Fix.BASEFIELD_EVENT_1_X;
          One.TF.Field_Y = Fix.BASEFIELD_EVENT_1_Y;
          One.TF.Field_Z = Fix.BASEFIELD_EVENT_1_Z;
        }
        else
        {
          Debug.Log("TapStartSeeker InitBasefieldStart true, then no action");
        }
        SceneDimension.JumpToDungeonField();
      }
    }
    else if (One.TF.SaveByDungeon)
    {
      Debug.Log("TapStartSeeker One.TF.SaveByDungeon(true) -> JumpToDungeonField");
      SceneDimension.JumpToDungeonField();
    }
    else
    {
      Debug.Log("TapStartSeeker One.TF.SaveByDungeon(false) -> JumpToHomeTown");
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

    //Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    //ein.FireBall = 6;
    ////ein.FlameBlade = 1;
    ////ein.GaleWind = 1;
    ////ein.IceNeedle = 1;
    ////ein.FreezingCube = 1;
    ////ein.VolcanicBlaze = 1;
    ////ein.IronBuster = 1;
    ////ein.CounterAttack = 1;
    ////ein.CursedEvangile = 1;
    ////ein.PenetrationArrow = 1;
    ////ein.CircleOfSerenity = 1;
    ////ein.WillAwakening = 1;
    ////ein.PhantomOboro = 1;
    ////ein.DeadlyDrive = 1;
    ////ein.DominationField = 1;
    ////ein.HunterShot = 1;
    ////ein.ShiningHeal = 1;
    ////ein.BloodSign = 1;
    ////ein.CircleOfTheDespair = 1;
    ////ein.RagingStorm = 1;
    ////ein.FreshHeal = 1;
    ////ein.EnergyBolt = 1;
    ////ein.SpeedStep = 1;
    ////ein.LeylineSchema = 3;
    ////ein.OracleCommand = 6;
    ////ein.EnergyBolt = 4;
    //ein.FortuneSpirit = 3;
    //ein.StanceOfTheBlade = 1;
    //ein.StanceOfTheGuard = 20;
    ////ein.SpiritualRest = 1;
    //ein.WordOfPower = 6;
    ////ein.SigilOfThePending = 4;
    //ein.DoubleSlash = 6;
    //ein.GaleWind = 3;
    //ein.EyeOfTheIsshin = 20;
    //ein.PhantomOboro = 3;
    ////ein.DominationField = 20;
    //ein.WillAwakening = 3;
    //ein.FlameStrike = 1;
    //ein.SeventhPrinciple = 4;
    //ein.HardestParry = 4;
    //ein.InnerInspiration = 6;
    //ein.ActionCommand1 = Fix.FIRE_BALL;
    //ein.ActionCommand2 = Fix.STRAIGHT_SMASH;
    //ein.ActionCommand3 = Fix.INNER_INSPIRATION;
    //ein.ActionCommand4 = Fix.FRESH_HEAL;
    //ein.ActionCommand5 = Fix.SEVENTH_PRINCIPLE;
    //ein.ActionCommand6 = Fix.PHANTOM_OBORO;
    //ein.ActionCommand7 = Fix.FLAME_STRIKE;
    //ein.ActionCommand8 = Fix.GALE_WIND;
    //ein.ActionCommand9 = Fix.HARDEST_PARRY;
    //ein.Strength = 100;
    //ein.Agility = 10;
    //ein.Intelligence = 10;
    //ein.Mind = 100;
    //ein.BaseManaPoint = 999;
    //ein.BaseLife = 1000;
    //ein.MaxGain();
    ////ein.CurrentManaPoint = 2;

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
    lana.ActionCommand9 = Fix.DEATH_SCYTHE;
    lana.Strength = 100;
    lana.Agility = 10;
    lana.Intelligence = 100;
    lana.Mind = 50;
    lana.BaseManaPoint = 999;
    lana.BaseLife = 1000;
    lana.MaxGain();
    //lana.CurrentManaPoint = 3;
    lana.CurrentLife = 0;
    lana.Dead = true;

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
    billy.Strength = 1;// 100;
    billy.Intelligence = 100;
    billy.Agility = 25;
    billy.Mind = 10;
    billy.BaseLife = 1;// 1000;
    billy.MaxGain();
    billy.CurrentLife = 1;// 300;

    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    One.TF.BattlePlayer2 = Fix.NAME_LANA_AMIRIA;
    //One.TF.BattlePlayer3 = Fix.NAME_EONE_FULNEA;
    //One.TF.BattlePlayer4 = Fix.NAME_BILLY_RAKI;

    //One.RealWorldLoad();
    //List<Character> available = One.AvailableCharacters;
    //foreach (Character current in available)
    //{
    //  current.MaxGain();
    //}
    //One.CreateShadowData();

    One.EnemyList.Clear();
    //if (txtEnemy1.text != String.Empty)
    {
      One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);
      One.BattleEnemyList.Add(Fix.DUMMY_SUBURI);
    }
    //if (txtEnemy2.text != String.Empty)
    //{
    //  One.BattleEnemyList.Add(txtEnemy2.text);
    //}
    //if (txtEnemy3.text != String.Empty)
    //{
    //  One.BattleEnemyList.Add(txtEnemy3.text);
    //}

    Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    ein.Level = 15;
    ein.Strength = 210;
    ein.Agility = 21;
    ein.Intelligence = 100;
    ein.Stamina = 14;
    ein.Mind = 10;
    ein.BaseLife = 222;
    ein.BaseManaPoint = 1000;// 166;
    ein.BaseSkillPoint = 100;
    ein.StraightSmash = 1;
    ein.ZeroImmunity = 1;
    ein.FreshHeal = 1;
    ein.FireBall = 1;
    ein.IceNeedle = 1;
    ein.ShadowBlast = 1;
    ein.OracleCommand = 1;
    ein.EnergyBolt = 1;
    ein.ShieldBash = 1;
    ein.LegStrike = 1;
    ein.HunterShot = 1;
    ein.TrueSight = 1;
    ein.DispelMagic = 1;
    ein.FlameBlade = 1;
    ein.PurePurification = 1;
    ein.DivineCircle = 1;
    ein.BloodSign = 1;
    ein.FortuneSpirit = 1;
    ein.FlashCounter = 1;
    ein.StanceOfTheBlade = 1;
    ein.StanceOfTheGuard = 1;
    ein.SpeedStep = 1;
    ein.MultipleShot = 1;
    ein.LeylineSchema = 1;
    ein.SpiritualRest = 1;
    ein.MeteorBullet = 1;
    ein.BlueBullet = 1;
    ein.HolyBreath = 1;
    ein.BlackContract = 1;
    ein.WordOfPower = 1;
    ein.SigilOfThePending = 1;
    ein.DoubleSlash = 1;
    ein.ConcussiveHit = 1;
    ein.BoneCrush = 1;
    ein.EyeOfTheIsshin = 1;
    ein.VoiceOfVigor = 1;
    ein.UnseenAid = 1;
    ein.VolcanicBlaze = 1;
    ein.FreezingCube = 1;
    ein.AngelicEcho = 1;
    ein.CursedEvangile = 1;
    ein.GaleWind = 1;
    ein.PhantomOboro = 1;
    ein.IronBuster = 1;
    ein.DominationField = 1;
    ein.DeadlyDrive = 1;
    ein.PenetrationArrow = 1;
    ein.WillAwakening = 1;
    ein.CircleOfSerenity = 1;
    ein.FlameStrike = 1;
    ein.FrostLance = 1;
    ein.ShiningHeal = 1;
    ein.CircleOfTheDespair = 1;
    ein.SeventhPrinciple = 1;
    ein.CounterDisallow = 1;
    ein.RagingStorm = 1;
    ein.UnintentionalHit = 1;
    ein.PrecisionStrike = 1;
    ein.EverflowMind = 1;
    ein.InnerInspiration = 1;
    ein.CircleOfTheIgnite = 1;
    ein.WaterPresence = 1;
    ein.ValkyrieBlade = 1;
    ein.TheDarkIntensity = 1;
    ein.FutureVision = 1;
    ein.DetachmentFault = 1;
    ein.StanceOfTheIai = 1;
    ein.OneImmunity = 1;
    ein.StanceOfMuin = 1;
    ein.EternalConcentration = 1;
    ein.SigilOfTheFaith = 1;
    ein.LavaAnnihilation = 1;
    ein.AbsoluteZero = 1;
    ein.Resurrection = 1;
    ein.DeathScythe = 1;
    ein.Genesis = 1;
    ein.TimeStop = 3;
    ein.KineticSmash = 1;
    ein.Catastrophe = 1;
    ein.CarnageRush = 1;
    ein.PiercingArrow = 1;
    ein.StanceOfTheKokoroe = 1;
    ein.TranscendenceReached = 1;
    ein.ActionCommand1 = Fix.CURE_SEAL;
    ein.ActionCommand2 = Fix.POTION_MAGIC_SEAL;
    ein.ActionCommand3 = Fix.DEFENSE;
    ein.ActionCommand4 = Fix.POTION_RESIST_FIRE;
    ein.ActionCommand5 = Fix.ARCHETYPE_EIN_1;
    //ein.ActionCommand4 = Fix.FLAME_STRIKE;
    ein.ActionCommand5 = Fix.FRESH_HEAL;
    //ein.ActionCommand6 = Fix.COUNTER_DISALLOW;
    ein.ActionCommand6 = Fix.GENESIS;
    //ein.ActionCommand7 = Fix.PRECISION_STRIKE;
    ein.ActionCommand7 = Fix.KINETIC_SMASH;
    //ein.ActionCommand8 = Fix.UNINTENTIONAL_HIT;
    //ein.ActionCommand9 = Fix.HARDEST_PARRY;
    ein.MainWeapon = new Item(Fix.EXTREME_SWORD);
    //ein.SubWeapon = new Item(Fix.SILVER_EARTH_SHIELD);
    //ein.Accessory1 = new Item(Fix.RED_AMULET);
    //ein.Accessory2 = new Item(Fix.BLUE_AMULET);
    ein.Accessory1 = new Item(Fix.MAGICLIGHT_ICE);
    ein.ActionCommandMain = Fix.TRANSCENDENCE_REACHED;
    ein.MaxGain();
    One.TF.AddBackPack(new Item(Fix.CURE_SEAL), 3);
    One.TF.AddBackPack(new Item(Fix.POTION_MAGIC_SEAL), 3);
    One.TF.AddBackPack(new Item(Fix.POTION_RESIST_FIRE), 3);

    One.TF.AvailablePotentialGauge = true;
    One.TF.AvailableArchetype_EinWolence = true;
    One.TF.PotentialEnergy = 10000;
    //One.TF.BattlePlayer1 = Fix.NAME_BILLY_RAKI;
    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    List<Character> available = One.AvailableCharacters;
    //foreach (Character current in available)
    //{
    //  current.MaxGain();
    //}
    One.CreateShadowData();
    //if (txtDuelA.text != String.Empty)
    //{
    //  One.BattleEnemyList.Clear();
    //  One.BattleEnemyList.Add(txtDuelA.text);
    //}

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

    One.TF.AvailablePotentialGauge = true;
    One.TF.AvailableArchetype_EinWolence = true;
    One.TF.PotentialEnergy = 10000;
    Character ein = One.SelectCharacter(Fix.NAME_EIN_WOLENCE);
    ein.Level = 58;
    ein.Strength = 297;
    ein.Agility = 50;
    ein.Intelligence = 24;
    ein.Stamina = 96;
    ein.Mind = 50;
    ein.BaseLife = 15214;
    ein.BaseManaPoint = 1712;
    ein.BaseSkillPoint = 100;
    ein.MainWeapon = new Item(Fix.GALLANT_FEATHER_LANCE);
    //ein.MainArmor = new Item(Fix.BLADESHADOW_CROWDED_DRESS);
    //ein.Accessory1 = new Item(Fix.FIRELIEGE_AETHER_TALISMAN);
    //ein.Accessory2 = new Item(Fix.ANGEL_CONTRACT_SHEET);
    //ein.Artifact = new Item(Fix.FLOW_FUNNEL_OF_THE_ZVELDOZE);

    //ein.Level = 15;
    //ein.Strength = 52;
    //ein.Agility = 37;
    //ein.Intelligence = 7;
    //ein.Stamina = 29;
    //ein.Mind = 22;
    //ein.BaseLife = 874;
    //ein.BaseManaPoint = 356;
    //ein.BaseSkillPoint = 100;
    //ein.MainWeapon = new Item(Fix.THUNDER_BREAK_AXE);
    //ein.SubWeapon = new Item(Fix.WIDE_BUCKLER);
    //ein.MainArmor = new Item(Fix.GOTHIC_PLATE);
    //ein.Accessory1 = new Item(Fix.RED_KOKUIN);
    //ein.Accessory2 = new Item(Fix.CHAINSHIFT_BOOTS);
    ein.StraightSmash = 1;
    ein.ZeroImmunity = 1;
    ein.PrecisionStrike = 1;
    ein.CounterDisallow = 1;
    ein.HardestParry = 1;
    ein.PrecisionStrike = 1;
    ein.ActionCommand1 = Fix.STRAIGHT_SMASH;
    ein.ActionCommand2 = Fix.ZERO_IMMUNITY;
    ein.ActionCommand3 = Fix.DEFENSE;
    ein.ActionCommand4 = Fix.PRECISION_STRIKE;
    ein.ActionCommand5 = Fix.ARCHETYPE_EIN_1;
    ein.ActionCommand6 = Fix.WORD_OF_POWER;
    ein.ActionCommand7 = Fix.HARDEST_PARRY;
    ein.ActionCommand8 = Fix.COUNTER_DISALLOW;
    //ein.ActionCommand4 = Fix.FLAME_STRIKE;
    //ein.ActionCommand5 = Fix.FRESH_HEAL;
    //ein.ActionCommand6 = Fix.COUNTER_DISALLOW;
    //ein.ActionCommand7 = Fix.PRECISION_STRIKE;
    //ein.ActionCommand8 = Fix.UNINTENTIONAL_HIT;
    //ein.ActionCommand9 = Fix.HARDEST_PARRY;
    //ein.MainWeapon = new Item(Fix.SMASH_BLADE);
    //ein.SubWeapon = new Item(Fix.IRON_SHIELD);
    //ein.MainArmor = new Item(Fix.CROSSCHAIN_MAIL);
    //ein.Accessory1 = new Item(Fix.RED_AMULET);
    //ein.Accessory2 = new Item(Fix.JADE_NOBLE_CIRCLET);
    ein.FreshHeal = 3;
    ein.WordOfPower = 3;
    ein.MaxGain();

    One.TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;

    //One.RealWorldLoad();
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
    if (txtDuelA.text != String.Empty)
    {
      One.BattleEnemyList.Clear();
      One.BattleEnemyList.Add(txtDuelA.text);
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
    ein.ActionCommand7 = Fix.COUNTER_DISALLOW;
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

  public void TapMonsterData()
  {
    txtMonsterData.text = "";
    List<string> characterName = new List<string>()
    { Fix.TINY_MANTIS,
      Fix.GREEN_SLIME,
      Fix.MANDRAGORA,
      Fix.YOUNG_WOLF,
      Fix.WILD_ANT,
      Fix.OLD_TREEFORK,
      Fix.SUN_FLOWER,
      Fix.SOLID_BEETLE,
      Fix.SILENT_LADYBUG,
      Fix.NIMBLE_RABBIT,
      Fix.ENTANGLED_VINE,
      Fix.CREEPING_SPIDER, 
      Fix.BLOOD_MOSS,
      Fix.KILLER_BEE,
      Fix.WONDER_SEED,
      Fix.DAUNTLESS_HORSE,
      Fix.DEBRIS_SOLDIER,
      Fix.MAGICAL_AUTOMATA,
      Fix.KILLER_MACHINE,
      Fix.STINKY_BAT,
      Fix.ANTIQUE_MIRROR, 
      Fix.MECH_HAND,
      Fix.ABSENCE_MOAI,
      Fix.ACID_SCORPION,
      Fix.NEJIMAKI_KNIGHT,
      Fix.AIMING_SHOOTER,
      Fix.CULT_BLACK_MAGICIAN,
      Fix.STONE_GOLEM,
      Fix.JUNK_VULKAN,
      Fix.LIGHTNING_CLOUD,
      Fix.SILENT_GARGOYLE,
      Fix.GATE_HOUND,
      Fix.PLAY_FIRE_IMP,
      Fix.WALKING_TIME_BOMB,
      Fix.EARTH_ELEMENTAL,
      Fix.DEATH_DRONE,
      Fix.ASSULT_SCARECROW,
      Fix.MAD_DOCTOR,
      Fix.CHARGED_BOAR,
      Fix.WOOD_ELF, 
      Fix.STINKED_SPORE,
      Fix.POISON_FLOG,
      Fix.GIANT_SNAKE,
      Fix.SAVAGE_BEAR,
      Fix.INNOCENT_FAIRY,
      Fix.SPEEDY_FALCON,
      Fix.MYSTIC_DRYAD,
      Fix.WOLF_HUNTER,
      Fix.FOREST_PHANTOM,
      Fix.EXCITED_ELEPHANT,
      Fix.SYLPH_DANCER,
      Fix.GATHERING_LAPTOR,
      Fix.RAGE_TIGER,
      Fix.THORN_WARRIOR,
      Fix.MUDDLED_PLANT,
      Fix.FLANSIS_KNIGHT,
      Fix.MIST_PYTHON,
      Fix.TOWERING_ENT,
      Fix.POISON_MARY,
      Fix.DISTURB_RHINO,
      Fix.WISDOM_CENTAURUS,
      Fix.SWIFT_EAGLE,
      Fix.EASTERN_GOLEM,
      Fix.WESTERN_GOLEM,
      Fix.WIND_ELEMENTAL,
      Fix.SKY_KNIGHT,
      Fix.THE_PURPLE_HIKARIGOKE,
      Fix.MYSTICAL_UNICORN,
      Fix.TRIAL_HERMIT,
      Fix.STORM_BIRDMAN,
      Fix.THE_BLUE_LAVA_EYE,
      Fix.THE_WHITE_LAVA_EYE,
      Fix.FLYING_CURTAIN,
      Fix.LUMINOUS_HAWK,
      Fix.AETHER_GUST,
      Fix.WHIRLWIND_KITSUNE,
      Fix.THUNDER_LION,
      Fix.SAINT_PEGASUS,
      Fix.DREAM_WALKER,
      Fix.IVORY_STATUE,
      Fix.STUBBORN_SAGE,
      Fix.BOMB_BALLON,
      Fix.OBSERVANT_HERALD,
      Fix.TOWER_SCOUT,
      Fix.MIST_SALVAGER,
      Fix.WINGSPAN_RANGER,
      Fix.MAJESTIC_CLOUD,
      Fix.HARDENED_GRIFFIN,
      Fix.PRISMA_SPHERE,
      Fix.MOVING_CANNON,
      Fix.VEIL_FORTUNE_WIZARD,
      Fix.DAGGER_FISH,
      Fix.FLOATING_MANTA, 
      Fix.SKYBLUE_BIRD,
      Fix.RAINBOW_CLIONE,
      Fix.ROLLING_MAGURO,
      Fix.BEAUTY_SEA_LILY,
      Fix.LIMBER_SEAEAGLE,
      Fix.FLUFFY_CORAL,
      Fix.BLACK_OCTOPUS,
      Fix.STEAL_SQUID,
      Fix.PROUD_VIKING,
      Fix.GAN_GAME,
      Fix.JUMPING_KAMASU,
      Fix.RECKLESS_WALRUS,
      Fix.WRECHED_ANEMONE,
      Fix.DEEPSEA_HAND,
      Fix.ASSULT_SERPENT,
      Fix.GIANT_SEA_SPIDER,
      Fix.ESCORT_HERMIT_CLUB,
      Fix.MOGUL_MANTA,
      Fix.GLUTTONY_COELACANTH,
      Fix.FEROCIOUS_WHALE,
      Fix.WEEPING_MIST,
      Fix.AMBUSH_ANGLERFISH,
      Fix.EMERALD_LOBSTER,
      Fix.STICKY_STARFISH,
      Fix.RAMPAGE_BIGSHARK,
      Fix.BIGMOUSE_JOE,
      Fix.SEA_STAR_KNIGHT,
      Fix.SEA_ELEMENTAL,
      Fix.EDGED_HIGH_SHARK,
      Fix.THOUGHTFUL_NAUTILUS,
      Fix.GHOST_SHIP,
      Fix.DEFENSIVE_DATSU,
      Fix.SEA_SONG_MARMAID,
      Fix.PHANTOM_HUNTER,
      Fix.BEAST_MASTER,
      Fix.ELDER_ASSASSIN,
      Fix.FALLEN_SEEKER,
      Fix.MEPHISTO_RIGHTARM,
      Fix.POWERED_STEAM_BOW,
      Fix.DARK_MESSENGER,
      Fix.MASTER_LORD,
      Fix.EXECUTIONER,
      Fix.MARIONETTE_NEMESIS,
      Fix.BLACKFIRE_MASTER_BLADE,
      Fix.SIN_THE_DARKELF,
      Fix.IMPERIAL_KNIGHT,
      Fix.SUN_STRIDER,
      Fix.BALANCE_IDLE,
      Fix.ARCHDEMON,
      Fix.UNDEAD_WYVERN,
      Fix.GO_FLAME_SLASHER,
      Fix.DEVIL_CHILDREN,
      Fix.ANCIENT_DISK,
      Fix.HOWLING_HORROR,
      Fix.PAIN_ANGEL,
      Fix.CHAOS_WARDEN,
      Fix.HELL_DREAD_KNIGHT,
      Fix.DOOM_BRINGER,
      Fix.BLACK_LIGHTNING_SPHERE,
      Fix.DISTORTED_SENSOR,
      Fix.ELDER_BAPHOMET,
      Fix.WIND_BREAKER,
      Fix.HOLLOW_SPECTOR,
      Fix.VENERABLE_WIZARD,
      Fix.UNKNOWN_FLOATING_BALL,
      Fix.PHOENIX,
      Fix.NINE_TAIL,
      Fix.MEPHISTOPHELES,
      Fix.JUDGEMENT, 
      Fix.EMERALD_DRAGON,
      Fix.TIAMAT,
    };

    for (int ii = 0; ii < characterName.Count; ii++)
    {
      CharacterConstruction(characterName[ii], ii);
    }
  }
  private void CharacterConstruction(string character_name, int ii)
  {
    GameObject objEC = new GameObject("objEC_" + ii.ToString());
    Character c1 = objEC.AddComponent<Character>();
    c1.Construction(character_name);
    if (ii != 0) { txtMonsterData.text += "\r\n"; }
    txtMonsterData.text += ii + " " + c1.FullName + " " + c1.Exp.ToString();
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
    One.UpdateGameConfig();
    groupConfig.SetActive(false);
    groupSaveLoad.gameObject.SetActive(false);
  }
}
