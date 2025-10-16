using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml;
using System.Text;
using System.Reflection;

public static class One
{
  public enum battleResult
  {
    None, // 情報なし
    OK, // 勝ち
    Ignore, // 負け
    Retry, // 再戦
    Abort, // 逃げる
  }

  public enum GameLanguage
  {
    English = 1,
    Japanese = 2,
  }

  public static List<string> ObjectiveList = new List<string>(); // 目標

  public static bool IsConnect = false; // サーバー接続OKサイン
  public static List<string> playbackMessage = new List<string>(); // プレイバックメッセージテキスト

  private static List<GameObject> objCharacterList = new List<GameObject>();
  //private static GameObject objWE = null;
  //private static GameObject objWE2 = null;
  private static GameObject objTF = null;
  private static GameObject objAR = null;
  private static GameObject objCONF = null;
  private static GameObject objSQL = null;

  [SerializeField] private static List<Character> _characters = new List<Character>();
  public static List<Character> Characters
  {
    get { return _characters; }
  }
  public static ControlSQL SQL = null;
  public static TeamFoundation TF = null;
  public static AkashicRecord AR = null;
  public static GameConfig CONF = null;

  //public static bool[] Truth_KnownTileInfo = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];
  //public static bool[] Truth_KnownTileInfo2 = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];
  //public static bool[] Truth_KnownTileInfo3 = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];
  //public static bool[] Truth_KnownTileInfo4 = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];
  //public static bool[] Truth_KnownTileInfo5 = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];

  public static List<Character> ShadowPlayerList = new List<Character>();
  public static TeamFoundation ShadowTF = null;
  public static AkashicRecord ShadowAR = null;

  public static GameObject sound = null; // サウンド音源
  public static AudioSource soundSource = null; // サウンドソース

  public static GameObject bgm = null; // BGM音源
  public static List<AudioSource> bgmSource = new List<AudioSource>(); // BGMソース
  private static List<String> BgmName = new List<string>();
  public static List<float> BgmLoopPoint = new List<float>();
  public static int BgmNumber = 0;

  public static int BattleSpeed = 3;
  public static GameLanguage Language = GameLanguage.English; // ゲームサポート言語

  public static bool AlreadyInitialize = false; // 既に一度InitializeGroundOneを呼んだかどうか

  public static bool TutorialMode = false; // チュートリアルモードを示すフラグ
  public static int TutorialLevel = 1; // チュートリアルのレベル

  public static List<Character> PlayerList = new List<Character>();
  public static List<Character> EnemyList = new List<Character>();

  #region "SceneManager"
  // SaveLoad
  public static bool AfterBacktoTitle = false; // タイトル戻り直前のセーブモード
  public static bool SaveMode = false; // false:Load true:Save
  public static bool SaveAndExit = false; // true:RealWorldSave and exit
  public static string CurrentLoadFileName = String.Empty; // 現在ロード対象となっているファイル名

  // DungeonField
  //public static string DungeonFieldName = Fix.MAPFILE_BASE_FIELD;
  public static Fix.GameEndType BattleEnd = Fix.GameEndType.None;
  public static List<string> BattleEnemyList = new List<string>();
  public static bool GoratrumHoleFalling = false;
  public static bool GoratrumHoleFalling2 = false; // 多少芋プログラミングだが、良しとする。
  public static bool GoratrumHoleFalling3 = false; // 多少芋プログラミングだが、良しとする。

  // BattleEnemy
  public static bool CannotRunAway = false;
  public static Fix.BattleMode BattleMode = Fix.BattleMode.None;
  public static bool FromHometown = false; // BackScene -> [false: from Dungeon] , [true: from Hometown]
  public static bool LifePointBattle = false;

  // Ending
  public static int EndingNumber = 1; // 1:Normal-End, 2:True-End
  #endregion

  public static void ReInitializeGroundOne(bool FromGameLoad)
  {
    Debug.Log("ReInitializeGroundOne (S)");

    for (int ii = 0; ii < _characters.Count; ii++)
    {
      UnityEngine.Object.Destroy(_characters[ii].gameObject);
      _characters[ii] = null;
    }
    _characters.Clear();
    _characters = new List<Character>();
    UnityEngine.Object.Destroy(SQL);
    SQL = null;
    UnityEngine.Object.Destroy(TF);
    TF = null;
    UnityEngine.Object.Destroy(AR);
    AR = null;
    UnityEngine.Object.Destroy(CONF);
    CONF = null;

    for (int ii = 0; ii < objCharacterList.Count; ii++)
    {
      UnityEngine.Object.Destroy(objCharacterList[ii]);
      objCharacterList[ii] = null;
    }
    objCharacterList.Clear();
    objCharacterList = new List<GameObject>();
    UnityEngine.Object.Destroy(objSQL);
    objSQL = null;
    UnityEngine.Object.Destroy(objTF);
    objTF = null;
    UnityEngine.Object.Destroy(objAR);
    objAR = null;
    UnityEngine.Object.Destroy(CONF);
    CONF = null;
    //UnityEngine.Object.Destroy(ShadowMC);
    //ShadowMC = null;
    //UnityEngine.Object.Destroy(ShadowSC);
    //ShadowSC = null;
    //UnityEngine.Object.Destroy(ShadowTC);
    //ShadowTC = null;
    //UnityEngine.Object.Destroy(shadowWE);
    //shadowWE = null;
    //UnityEngine.Object.Destroy(shadowWE2);
    //shadowWE2 = null;
    if (FromGameLoad == false)
    {
      UnityEngine.Object.Destroy(sound);
      UnityEngine.Object.Destroy(soundSource);
      sound = null;
      soundSource = null;
      UnityEngine.Object.Destroy(bgm);
      for (int ii = 0; ii < bgmSource.Count; ii++)
      {
        //bgmSource[ii].clip.UnloadAudioData();
        GameObject.Destroy(bgmSource[ii]);
      }
      bgm = null;
      bgmSource = null;
      BgmName.Clear();
      BgmName = null;
      BgmLoopPoint.Clear();
      BgmLoopPoint = null;
      BgmNumber = 0;
    }
    //Truth_KnownTileInfo = null;
    AlreadyInitialize = false;
    TutorialMode = false;
    TutorialLevel = 1;
    PlayerList.Clear();
    InitializeGroundOne(FromGameLoad);
  }

  public static bool InitializeGroundOne(bool FromGameLoad)
  {
    Debug.Log("InitializeGroundOne start");

    if (AlreadyInitialize == false) { AlreadyInitialize = true; }
    else { Debug.Log("already initialize"); return false; }

    for (int ii = 0; ii < Fix.CHARACTER_LIST_NUM; ii++)
    {
      objCharacterList.Add(new GameObject("obj_C" + (ii + 1).ToString("D2")));
    }
    objTF = new GameObject("objTF");
    objAR = new GameObject("objAR");
    objCONF = new GameObject("objCONF");
    objSQL = new GameObject("objSQL");

    if (FromGameLoad == false)
    {
      sound = new GameObject("sound");
      soundSource = sound.AddComponent<AudioSource>();
      bgm = new GameObject("bgm");
      bgmSource = new List<AudioSource>();
      bgmSource.Add(bgm.AddComponent<AudioSource>());
      BgmName = new List<string>();
      BgmLoopPoint = new List<float>();
    }

    //Truth_KnownTileInfo = new bool[Database.TRUTH_DUNGEON_ROW * Database.TRUTH_DUNGEON_COLUMN];
    //WE = objWE.AddComponent<WorldEnvironment>();
    //WE.DungeonArea = 1;
    //WE.AvailableFirstCharacter = true;
    TF = objTF.AddComponent<TeamFoundation>();
    AR = objAR.AddComponent<AkashicRecord>();
    CONF = objCONF.AddComponent<GameConfig>();

    for (int ii = 0; ii < Fix.MAPSIZE_X_ESMILIA_GRASSFIELD * Fix.MAPSIZE_Z_ESMILIA_GRASSFIELD; ii++)
    {
      TF.KnownTileList_EsmiliaGrassField.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_GORATRUM * Fix.MAPSIZE_Z_GORATRUM; ii++)
    {
      TF.KnownTileList_Goratrum.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_GORATRUM * Fix.MAPSIZE_Z_GORATRUM; ii++)
    {
      TF.KnownTileList_Goratrum_2.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_MYSTICFOREST * Fix.MAPSIZE_Z_MYSTICFOREST; ii++)
    {
      TF.KnownTileList_MysticForest.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_VELGUS_SEATEMPLE * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE; ii++)
    {
      TF.KnownTileList_VelgusSeaTemple.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_VELGUS_SEATEMPLE_2 * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE_2; ii++)
    {
      TF.KnownTileList_VelgusSeaTemple_2.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_VELGUS_SEATEMPLE_3 * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE_3; ii++)
    {
      TF.KnownTileList_VelgusSeaTemple_3.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_VELGUS_SEATEMPLE_4 * Fix.MAPSIZE_Z_VELGUS_SEATEMPLE_4; ii++)
    {
      TF.KnownTileList_VelgusSeaTemple_4.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_EDELGARZEN_1 * Fix.MAPSIZE_Z_EDELGARZEN_1; ii++)
    {
      TF.KnownTileList_Edelgarzen_1.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_EDELGARZEN_2 * Fix.MAPSIZE_Z_EDELGARZEN_2; ii++)
    {
      TF.KnownTileList_Edelgarzen_2.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_EDELGARZEN_3 * Fix.MAPSIZE_Z_EDELGARZEN_3; ii++)
    {
      TF.KnownTileList_Edelgarzen_3.Add(false);
    }
    for (int ii = 0; ii < Fix.MAPSIZE_X_EDELGARZEN_4 * Fix.MAPSIZE_Z_EDELGARZEN_4; ii++)
    {
      TF.KnownTileList_Edelgarzen_4.Add(false);
    }

    for (int ii = 0; ii < Fix.CHARACTER_LIST_NUM; ii++)
    {
      _characters.Add(objCharacterList[ii].AddComponent<Character>());
    }

    SQL = objSQL.AddComponent<ControlSQL>();
    SQL.SetupSql();

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
    catch (Exception ex)
    {
      Debug.Log("Title Exception: " + ex.ToString());
    }

    TF.AvailableEinWolence = true;
    TF.AvailableLanaAmiria = true;

    // debug
    TF.BeforeAreaName = Fix.TOWN_ANSHET;
    //TF.AvailableTactics = true;
    //TF.AvailableAllCommand = true;
    //TF.AvailableThird = true;
    //TF.AvailableFourth = true;
    //TF.AvailableFirstCommand = true;
    //TF.AvailableSecondCommand = true;
    //TF.AvailableThirdCommand = true;

    //TF.AvailableEoneFulnea = true;
    //TF.AvailableBillyRaki = true;
    //TF.AvailableAdelBrigandy = true;
    //TF.AvailableAnnaHamilton = true;
    //TF.AvailableCalmansOhn = true;
    //TF.AvailableDelvaTreckino = true;
    //TF.AvailableIlzinaMeldiete = true;
    //TF.AvailableJedaArus = true;
    //TF.AvailableKartinMai = true;
    //TF.AvailableLeneColtos = true;
    //TF.AvailableMagiZelkis = true;
    //TF.AvailableOhryuGenma = true;
    //TF.AvailableSelmoiRo = true;
    //TF.AvailableShuvaltzFlore = true;
    ////TF.AvailableKiltJorju = true;
    ////TF.AvailableLadaMystorus = true;
    ////TF.AvailablePermaWaramy = true;
    ////TF.AvailableRvelZelkis = true;
    ////TF.AvailableSinikiaVeilhanz = true;
    ////TF.AvailableSinOscurete = true;
    ////TF.AvailableSunYu = true;
    ////TF.AvailableVanHehgustel = true;
    ////TF.AvailableTactics = true;
    ////TF.AvailableAllCommand = true;
    ////TF.AvailableThird = true;
    ////TF.AvailableFourth = true;
    ////TF.AvailableFirstCommand = true;
    ////TF.AvailableSecondCommand = true;
    ////TF.AvailableThirdCommand = true;

    //TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    //TF.BattlePlayer2 = Fix.NAME_EONE_FULNEA;
    //TF.BattlePlayer3 = Fix.NAME_LANA_AMIRIA;

    int num = 0;

    _characters[num].CharacterCreation(Fix.NAME_EIN_WOLENCE); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_LANA_AMIRIA); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_EONE_FULNEA); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_BILLY_RAKI); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_ADEL_BRIGANDY); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_SHUVALTZ_FLORE); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_ANNA_HAMILTON); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_SELMOI_RO); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_ILZINA_MELDIETE); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_OHRYU_GENMA); PlayerList.Add(_characters[num]); num++;

    _characters[num].CharacterCreation(Fix.NAME_LENE_COLTOS); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_KARTIN_MAI); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_JEDA_ARUS); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_CALMANS_OHN); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_MAGI_ZELKIS); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_SINIKIA_VEILHANZ); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_PERMA_WARAMY); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_KILT_JORJU); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_SUN_YU); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_RVEL_ZELKIS); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_VAN_HEHGUSTEL); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_LADA_MYSTORUS); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_SIN_OSCURETE); PlayerList.Add(_characters[num]); num++;
    _characters[num].CharacterCreation(Fix.NAME_DELVA_TRECKINO); PlayerList.Add(_characters[num]); num++;

    num = 0;
    //_characters[num].FullName = Fix.NAME_EIN_WOLENCE;
    //_characters[num].Level = 1;
    //_characters[num].Strength = 5;
    //_characters[num].Agility = 3;
    //_characters[num].Intelligence = 2;
    //_characters[num].Stamina = 4;
    //_characters[num].Mind = 3;
    //_characters[num].Job = Fix.JobClass.Fighter;
    //_characters[num].FirstCommandAttribute = Fix.CommandAttribute.Warrior;
    //_characters[num].SecondCommandAttribute = Fix.CommandAttribute.Fire;
    //_characters[num].ThirdCommandAttribute = Fix.CommandAttribute.Brave;
    //List<string> actionList = new List<string>();
    //actionList.Add(Fix.NORMAL_ATTACK);
    //actionList.Add(Fix.DEFENSE);
    //actionList.Add(Fix.STRAIGHT_SMASH);
    //actionList.Add(Fix.FIRE_BALL);
    //actionList.Add(Fix.FLAME_BLADE);
    //actionList.Add(Fix.MULTIPLE_SHOT);
    //actionList.Add(Fix.FLASH_COUNTER);
    //actionList.Add(Fix.STAY);
    //actionList.Add(Fix.STAY);

    //_characters[num].ActionCommandList = actionList;
    //_characters[num].CurrentActionCommand = _characters[num].ActionCommandList[0];
    //_characters[num].MainWeapon = new Item(Fix.FINE_SWORD);
    //_characters[num].SubWeapon = new Item(Fix.FINE_SHIELD);
    //_characters[num].MainArmor = new Item(Fix.FINE_ARMOR);
    //_characters[num].BattleBackColor = Fix.COLOR_FIRST_CHARA;
    //_characters[num].BattleForeColor = Fix.COLORFORE_FIRST_CHARA;

    //Characters[num].Exp = Characters[num].GetNextExp();
    //Characters[num].RemainPoint = 5;
    //Characters[num].CurrentSoulPoint = 10;
    //_characters[num].MaxGain();
    //Characters[num].SoulFragment = 20;
    //Characters[num].AvailableSwordman = true;
    //Characters[num].AvailableFire = true;
    //Characters[num].AvailableBrave = true;
    //Characters[num].StraightSmash = 1;
    //Characters[num].FireBall = 1;
    //Characters[num].HeartOfLife = 1;
    //Characters[num].AvailableFire = true;
    //Characters[num].AvailableIce = true;
    //Characters[num].AvailableHolyLight = true;
    //Characters[num].AvailableDarkMagic = true;
    //Characters[num].AvailableSwordman = true;
    //Characters[num].AvailableArmorer = true;
    //Characters[num].AvailableArcher = true;
    //Characters[num].AvailableRogue = true;
    //Characters[num].AvailableEnhanceForm = true;
    //Characters[num].AvailableMysticForm = true;
    //Characters[num].AvailableBrave = true;
    //Characters[num].AvailableMindfulness = true;
    //Characters[num].FireBall = 1;
    //Characters[num].FlameBlade = 59;
    //Characters[num].MeteorBullet = 58;
    //Characters[num].FlameStrike = 57;
    //Characters[num].LavaAnnihilation = 56;
    //Characters[num].IceNeedle = 55;
    //Characters[num].PurePurification = 54;
    //Characters[num].BlueBullet = 53;
    //Characters[num].FreezingCube = 52;
    //Characters[num].FrostLance = 51;
    //Characters[num].FreshHeal = 50;
    //Characters[num].DivineCircle = 49;
    //Characters[num].HolyBreath = 48;
    //Characters[num].SanctionField = 47;
    //Characters[num].ValkyrieBreak = 46;
    //Characters[num].ShadowBlast = 45;
    //Characters[num].BloodSign = 44;
    //Characters[num].DeathScythe = 43;
    //Characters[num].WhisperVoice = 42;
    //Characters[num].AbyssEye = 41;
    //Characters[num].StraightSmash = 2;
    //Characters[num].StanceOfTheBlade = 39;
    //Characters[num].DoubleSlash = 38;
    //Characters[num].WarSwing = 37;
    //Characters[num].KineticSmash = 36;
    //Characters[num].ShieldBash = 35;
    //Characters[num].StanceOfTheGuard = 34;
    //Characters[num].ConcussiveHit = 33;
    //Characters[num].DominationField = 32;
    //Characters[num].OathOfAegis = 31;
    //Characters[num].HunterShot = 30;
    //Characters[num].MultipleShot = 29;
    //Characters[num].HawkEye = 27;
    //Characters[num].PiercingArrow = 26;
    //Characters[num].VenomSlash = 25;
    //Characters[num].InvisibleBind = 24;
    //Characters[num].IrregularStep = 23;
    //Characters[num].DissensionRhythm = 22;
    //Characters[num].AssassinationHit = 21;
    //Characters[num].SkyShield = 19;
    //Characters[num].StormArmor = 18;
    //Characters[num].AetherDrive = 17;
    //Characters[num].RuneStrike = 16;
    //Characters[num].DispelMagic = 15;
    //Characters[num].FlashCounter = 14;
    //Characters[num].MuteImpulse = 13;
    //Characters[num].DetachmentFault = 12;
    //Characters[num].PhantomOboro = 11;
    //Characters[num].HeartOfLife = 10;
    //Characters[num].FortuneSpirit = 9;
    //Characters[num].VoiceOfVigor = 8;
    //Characters[num].SigilOfTheFaith = 7;
    //Characters[num].RagingStorm = 6;
    //Characters[num].OracleCommand = 5;
    //Characters[num].SpiritualRest = 4;
    //Characters[num].ZeroImmunity = 3;
    //Characters[num].EssenceOverflow = 2;
    //Characters[num].InnerInspiration = 1;
    //Characters[num].CurrentLife = 1;
    //TF.BattlePlayer1 = Characters[num].FullName;
    //num++;

    //Characters[num].FullName = Fix.NAME_LANA_AMIRIA;
    //Characters[num].Level = 1;
    //Characters[num].Strength = 2;
    //Characters[num].Agility = 3;
    //Characters[num].Intelligence = 5;
    //Characters[num].Stamina = 3;
    //Characters[num].Mind = 2;
    //Characters[num].FirstCommandAttribute = Fix.CommandAttribute.Ice;
    //Characters[num].SecondCommandAttribute = Fix.CommandAttribute.DarkMagic;
    //Characters[num].ThirdCommandAttribute = Fix.CommandAttribute.Mindfulness;
    //List<string> actionList2 = new List<string>();
    //actionList2.Add(Fix.MAGIC_ATTACK);
    //actionList2.Add(Fix.FRESH_HEAL);
    //actionList2.Add(Fix.ICE_NEEDLE);
    //actionList2.Add(Fix.SHIELD_BASH);
    //actionList2.Add(Fix.DISPEL_MAGIC);
    //actionList2.Add(Fix.BLOOD_SIGN);
    //actionList2.Add(Fix.PURE_PURIFICATION);
    //actionList2.Add(Fix.DIVINE_CIRCLE);
    //actionList2.Add(Fix.SPIRITUAL_REST);
    //Characters[num].ActionCommandList = actionList2;
    // Characters[num].CurrentActionCommand = Characters[num].ActionCommandList[0];
    // Characters[num].MainWeapon = new Item(Fix.FINE_ROD);
    // Characters[num].BattleBackColor = Fix.COLOR_SECOND_CHARA;
    // Characters[num].BattleForeColor = Fix.COLORFORE_SECOND_CHARA;
    // Characters[num].Job = Fix.JobClass.Magician;
    //Characters[num].MaxGain();
    // Characters[num].SoulFragment = 3;
    // Characters[num].AvailableIce = true;
    // Characters[num].AvailableDarkMagic = true;
    // Characters[num].AvailableMindfulness = true;
    // Characters[num].IceNeedle = 1;
    // Characters[num].ShadowBlast = 1;
    // Characters[num].OracleCommand = 1;
    // //Characters[num].Exp = Characters[num].GetNextExp();
    //Characters[num].CurrentLife = 1;
    //TF.BattlePlayer2 = Characters[num].FullName;
    //num++;

    //Characters[num].FullName = Fix.NAME_EONE_FULNEA;
    //Characters[num].Level = 1;
    //Characters[num].Strength = 2;
    //Characters[num].Agility = 4;
    //Characters[num].Intelligence = 4;
    //Characters[num].Stamina = 2;
    //Characters[num].Mind = 3;
    //Characters[num].FirstCommandAttribute = Fix.CommandAttribute.HolyLight;
    //Characters[num].SecondCommandAttribute = Fix.CommandAttribute.Rogue;
    //Characters[num].ThirdCommandAttribute = Fix.CommandAttribute.MysticForm;
    //List<string> actionList3 = new List<string>();
    //actionList3.Add(Fix.NORMAL_ATTACK);
    //actionList3.Add(Fix.DEFENSE);
    //actionList3.Add(Fix.STRAIGHT_SMASH);
    //actionList3.Add(Fix.STRAIGHT_SMASH);
    //actionList3.Add(Fix.FORTUNE_SPIRIT);
    //actionList3.Add(Fix.STANCE_OF_THE_BLADE);
    //actionList3.Add(Fix.STANCE_OF_THE_GUARD);
    //actionList3.Add(Fix.INVISIBLE_BIND);
    //actionList3.Add(Fix.STAY);
    //Characters[num].ActionCommandList = actionList3;
    // Characters[num].CurrentActionCommand = Characters[num].ActionCommandList[0];
    // Characters[num].MainWeapon = new Item(Fix.FINE_BOOK);
    // Characters[num].Job = Fix.JobClass.Fighter;
    // Characters[num].BattleBackColor = Fix.COLOR_THIRD_CHARA;
    // Characters[num].BattleForeColor = Fix.COLORFORE_THIRD_CHARA;
    //Characters[num].MaxGain();
    // Characters[num].SoulFragment = 6;
    // Characters[num].AvailableHolyLight = true;
    // Characters[num].AvailableRogue = true;
    // Characters[num].AvailableMysticForm = true;
    // Characters[num].FreshHeal = 1;
    // Characters[num].VenomSlash = 1;
    // Characters[num].DispelMagic = 1;
    //Characters[num].CurrentLife = 1;
    //TF.BattlePlayer3 = Characters[num].FullName;
    //num++;

    //Characters[num].FullName = Fix.NAME_BILLY_RAKI;
    //Characters[num].Level = 1;
    //Characters[num].Strength = 4;
    //Characters[num].Agility = 5;
    //Characters[num].Intelligence = 4;
    //Characters[num].Stamina = 2;
    //Characters[num].Mind = 2;
    //Characters[num].FirstCommandAttribute = Fix.CommandAttribute.EnhanceForm;
    //Characters[num].SecondCommandAttribute = Fix.CommandAttribute.Armorer;
    //Characters[num].ThirdCommandAttribute = Fix.CommandAttribute.Archer;
    //Characters[num].ThirdCommandAttribute = Fix.CommandAttribute.DarkMagic;
    //List<string> actionList4 = new List<string>();
    //actionList4.Add(Fix.NORMAL_ATTACK);
    //actionList4.Add(Fix.DOUBLE_SLASH);
    //actionList4.Add(Fix.HEART_OF_LIFE);
    //actionList4.Add(Fix.SKY_SHIELD);
    //actionList4.Add(Fix.NORMAL_ATTACK);
    //actionList4.Add(Fix.VENOM_SLASH);
    //actionList4.Add(Fix.SHADOW_BLAST);
    //actionList4.Add(Fix.HUNTER_SHOT);
    //actionList4.Add(Fix.ORACLE_COMMAND);
    //Characters[num].ActionCommandList = actionList4;
    // Characters[num].CurrentActionCommand = Characters[num].ActionCommandList[0];
    // Characters[num].MainWeapon = new Item(Fix.FINE_CLAW);
    // Characters[num].BattleBackColor = Fix.COLOR_FOURTH_CHARA;
    // Characters[num].BattleForeColor = Fix.COLORFORE_FOURTH_CHARA;
    // Characters[num].Job = Fix.JobClass.Seeker;
    //Characters[num].MaxGain();
    // Characters[num].SoulFragment = 1;
    // Characters[num].AvailableEnhanceForm = true;
    // Characters[num].AvailableArmorer = true;
    // Characters[num].AvailableDarkMagic = true;
    // //Characters[num].AvailableArcher = true;
    // Characters[num].AuraOfPower = 0;
    // Characters[num].ShieldBash = 0;
    // Characters[num].HunterShot = 0;
    // Characters[num].ShadowBlast = 0;
    //Characters[num].CurrentLife = 1;
    //TF.BattlePlayer4 = Characters[num].FullName;
    //num++;

    //TF.BackpackList.Add(new Item(Fix.SMALL_RED_POTION));
    //TF.BackpackList.Add(new Item(Fix.SMALL_RED_POTION));
    //TF.BackpackList.Add(new Item(Fix.SMALL_BLUE_POTION));
    //TF.BackpackList.Add(new Item(Fix.SMALL_BLUE_POTION));
    //TF.BackpackList.Add(new Item(Fix.SMALL_RED_POTION));
    //TF.BackpackList.Add(new Item(Fix.FINE_SWORD));
    // TF.BackpackList.Add(new Item(Fix.FINE_ROD));
    // TF.BackpackList.Add(new Item(Fix.FINE_AXE));
    // TF.BackpackList.Add(new Item(Fix.FINE_ORB));
    // TF.BackpackList.Add(new Item(Fix.FINE_CLAW));
    // TF.BackpackList.Add(new Item(Fix.FINE_BOOK));
    // TF.BackpackList.Add(new Item(Fix.FINE_BOW));
    //// TF.BackpackList.Add(new Item(Fix.BASTARD_SWORD));
    // TF.BackpackList.Add(new Item(Fix.FINE_SHIELD));
    // TF.BackpackList.Add(new Item(Fix.FINE_ARMOR));
    // TF.BackpackList.Add(new Item(Fix.FINE_CROSS));
    // TF.BackpackList.Add(new Item(Fix.FINE_ROBE));

    // TF.BackpackList.Add(new Item(Fix.RED_PENDANT));
    // TF.BackpackList.Add(new Item(Fix.BLUE_PENDANT));
    // TF.BackpackList.Add(new Item(Fix.PURPLE_PENDANT));
    // TF.BackpackList.Add(new Item(Fix.GREEN_PENDANT));
    // TF.BackpackList.Add(new Item(Fix.YELLOW_PENDANT));
    // TF.BackpackList.Add(new Item(Fix.GEAR_GENSEI));
    // TF.BackpackList.Add(new Item(Fix.EXTREME_SWORD));
    // TF.BackpackList.Add(new Item(Fix.EXTREME_SHIELD));
    // TF.BackpackList.Add(new Item(Fix.SMALL_RED_POTION));
    // TF.BackpackList.Add(new Item(Fix.ZETANIUM_STONE));
    // TF.BackpackList.Add(new Item(Fix.ZEMULGEARS));
    // TF.BackpackList.Add(new Item(Fix.ARTIFACT_GENSEI));
    // TF.BackpackList.Add(new Item(Fix.ARTIFACT_JOURYOKU));
    // TF.BackpackList.Add(new Item(Fix.ARTIFACT_ZETSUKEN));
    // TF.BackpackList.Add(new Item(Fix.ARTIFACT_MUSOU));
    // TF.BackpackList.Add(new Item(Fix.ARTIFACT_ZIHI));

    //One.TF.Event_Message100010 = true;
    //TF.Event_Message100010 = true;
    //TF.Event_Message100020 = true;
    //TF.CurrentAreaName = Fix.TOWN_ANSHET;
    //TF.Gold = 1001;
    //One.TF.Gold = 1200;
    //TF.AvailableAnshet = true;
    //TF.AvailableGoratrum = true;
    //TF.AvailableQvelta = true;
    //TF.AvailableArtharium = true;
    //TF.AvailableCotuhsye = true;
    //TF.AvailableZhalman = true;
    //TF.AvailableOhran = true;
    //TF.AvailableVelgus = true;
    //TF.AvailableArcaneDine = true;
    //TF.AvailableParmetysia = true;
    //TF.AvailableSaritan = true;
    //TF.AvailableDhal = true;
    //TF.AvailableDale = true;
    //TF.AvailableDiskel = true;
    //TF.AvailableGanro = true;
    //TF.AvailableEdelgarzen = true;
    //TF.AvailableLoslon = true;
    //TF.AvailableZelman = true;
    //TF.AvailableLataHouse = true;
    //TF.AvailableSithGraveyard = true;
    //TF.AvailableFran = true;
    //TF.AvailableSnowtreeLata = true;
    //TF.AvailableWosm = true;
    //TF.AvailableFazilCastle = true;
    //TF.AvailableHeavenGenesisGate = true;

    //Character character = new GameObject("objEC_1").AddComponent<Character>();
    //character.Construction(Fix.TINY_MANTIS);
    //character.Construction(Fix.WILD_ANT);
    //character.Construction(Fix.OLD_TREEFORK);
    //character.Construction(Fix.THE_GALVADAZER);
    //character.Construction(Fix.WILD_ANT);
    //EnemyList.Add(character);

    //Character character2 = new GameObject("objEC_2").AddComponent<Character>();
    //character2.Construction(Fix.OLD_TREEFORK);
    //EnemyList.Add(character2);

    //Character character3 = new GameObject("objEC_3").AddComponent<Character>();
    //character3.Construction(Fix.SOLID_BEETLE_JP);
    //EnemyList.Add(character3);

    //Character character4 = new GameObject("objEC_4").AddComponent<Character>();
    //character4.Construction(Fix.CREEPING_SPIDER);
    //EnemyList.Add(character4);

    //for (int ii = 0; ii < One.EnemyList.Count; ii++)
    //{
    //  UnityEngine.Object.DontDestroyOnLoad(One.EnemyList[ii]);
    //}

    //EnemyList.Add(Fix.GREEN_SLIME);
    ////EnemyList.Add(Fix.MANDRAGORA);
    ////EnemyList.Add(Fix.YOUNG_WOLF);
    //Character character2 = new GameObject("objEC_2").AddComponent<Character>();
    //character.Construction(Fix.OLD_TREEFORK);
    //EnemyList.Add(character2);
    ////EnemyList.Add(Fix.SUN_FLOWER);
    ////EnemyList.Add(Fix.SOLID_BEETLE);
    //Character character3 = new GameObject("objEC_3").AddComponent<Character>();
    //character.Construction(Fix.SILENT_LADYBUG);
    //EnemyList.Add(character3);
    ////EnemyList.Add(Fix.MYSTIC_DRYAD);

    // DungeonFieldName = Fix.MAPFILE_ARTHARIUM;
    //DungeonFieldName = Fix.MAPFILE_BASE_FIELD;
    //TF.CurrentDungeonField = Fix.MAPFILE_ESMILIA_GRASSFIELD;
    // debug-end

    for (int ii = 0; ii < _characters.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(_characters[ii]);
    }
    UnityEngine.Object.DontDestroyOnLoad(TF);
    UnityEngine.Object.DontDestroyOnLoad(AR);
    UnityEngine.Object.DontDestroyOnLoad(CONF);
    UnityEngine.Object.DontDestroyOnLoad(sound);
    UnityEngine.Object.DontDestroyOnLoad(soundSource);
    UnityEngine.Object.DontDestroyOnLoad(bgm);
    UnityEngine.Object.DontDestroyOnLoad(bgmSource[0]);
    UnityEngine.Object.DontDestroyOnLoad(SQL);
    return true;
  }

  public static List<Character> AvailableCharacters
  {
    get
    {
      List<Character> list = new List<Character>();
      int playerCounter = 0;

      if (One.AR.EnterSeekerMode && One.AR.LeaveSeekerMode == false)
      {
        if (TF.AvailableEinWolence) { list.Add(_characters[playerCounter]); }
        return list;
      }

      if (TF.AvailableEinWolence) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableLanaAmiria) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableEoneFulnea) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableBillyRaki) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableAdelBrigandy) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableCalmansOhn) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableAnnaHamilton) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableSelmoiRo) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableMagiZelkis) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableLeneColtos) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableShuvaltzFlore) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableKartinMai) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableJedaArus) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableIlzinaMeldiete) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableOhryuGenma) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableDelvaTreckino) { list.Add(_characters[playerCounter]); }
      playerCounter++;

      if (TF.AvailableSinikiaVeilhanz) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailablePermaWaramy) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableKiltJorju) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableSunYu) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableRvelZelkis) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableVanHehgustel) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableLadaMystorus) { list.Add(_characters[playerCounter]); }
      playerCounter++;
      if (TF.AvailableSinOscurete) { list.Add(_characters[playerCounter]); }
      playerCounter++;

      return list;
    }
  }

  public static Character SelectCharacter(string full_name)
  {
    for (int ii = 0; ii < _characters.Count; ii++)
    {
      if (full_name == _characters[ii].FullName)
      {
        return _characters[ii];
      }
    }
    return null;
  }

  public static bool AvailableCharacterName(string full_name)
  {
    if ((TF.AvailableEinWolence && full_name == Fix.NAME_EIN_WOLENCE) ||
        (TF.AvailableLanaAmiria && full_name == Fix.NAME_LANA_AMIRIA) ||
        (TF.AvailableEoneFulnea && full_name == Fix.NAME_EONE_FULNEA) ||
        (TF.AvailableBillyRaki && full_name == Fix.NAME_BILLY_RAKI) ||
        (TF.AvailableAdelBrigandy && full_name == Fix.NAME_ADEL_BRIGANDY) ||
        (TF.AvailableCalmansOhn && full_name == Fix.NAME_CALMANS_OHN) ||
        (TF.AvailableAnnaHamilton && full_name == Fix.NAME_ANNA_HAMILTON) ||
        (TF.AvailableSelmoiRo && full_name == Fix.NAME_SELMOI_RO) ||
        (TF.AvailableMagiZelkis && full_name == Fix.NAME_MAGI_ZELKIS) ||
        (TF.AvailableLeneColtos && full_name == Fix.NAME_LENE_COLTOS) ||
        (TF.AvailableShuvaltzFlore && full_name == Fix.NAME_SHUVALTZ_FLORE) ||
        (TF.AvailableKartinMai && full_name == Fix.NAME_KARTIN_MAI) ||
        (TF.AvailableJedaArus && full_name == Fix.NAME_JEDA_ARUS) ||
        (TF.AvailableIlzinaMeldiete && full_name == Fix.NAME_ILZINA_MELDIETE) ||
        (TF.AvailableOhryuGenma && full_name == Fix.NAME_OHRYU_GENMA) ||
        (TF.AvailableDelvaTreckino && full_name == Fix.NAME_DELVA_TRECKINO) ||

        (TF.AvailableSinikiaVeilhanz && full_name == Fix.NAME_SINIKIA_VEILHANZ) ||
        (TF.AvailablePermaWaramy && full_name == Fix.NAME_PERMA_WARAMY) ||
        (TF.AvailableKiltJorju && full_name == Fix.NAME_KILT_JORJU) ||
        (TF.AvailableSunYu && full_name == Fix.NAME_SUN_YU) ||
        (TF.AvailableRvelZelkis && full_name == Fix.NAME_RVEL_ZELKIS) ||
        (TF.AvailableVanHehgustel && full_name == Fix.NAME_VAN_HEHGUSTEL) ||
        (TF.AvailableLadaMystorus && full_name == Fix.NAME_LADA_MYSTORUS) ||
        (TF.AvailableSinOscurete && full_name == Fix.NAME_SIN_OSCURETE)
        )
    {
      return true;
    }

    return false;
  }

  public static void CreateShadowData()
  {
    for (int ii = 0; ii < Fix.CHARACTER_LIST_NUM; ii++)
    {
      GameObject current = new GameObject("shadowPlayer_" + (ii + 1).ToString("D2"));
      Character shadow = current.AddComponent<Character>();
      shadow.MainWeapon = PlayerList[ii].MainWeapon;
      shadow.SubWeapon = PlayerList[ii].SubWeapon;
      shadow.MainArmor = PlayerList[ii].MainArmor;
      shadow.Accessory1 = PlayerList[ii].Accessory1;
      shadow.Accessory2 = PlayerList[ii].Accessory2;
      shadow.Artifact = PlayerList[ii].Artifact;

      Type type = PlayerList[ii].GetType();
      foreach (PropertyInfo pi in type.GetProperties())
      {
        if (pi.PropertyType == typeof(System.Int32))
        {
          try
          {
            pi.SetValue(shadow, (System.Int32)(type.GetProperty(pi.Name).GetValue(PlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.String))
        {
          try
          {
            pi.SetValue(shadow, (string)(type.GetProperty(pi.Name).GetValue(PlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Double))
        {
          try
          {
            pi.SetValue(shadow, (System.Double)(type.GetProperty(pi.Name).GetValue(PlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Single))
        {
          try
          {
            pi.SetValue(shadow, (System.Single)(type.GetProperty(pi.Name).GetValue(PlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Boolean))
        {
          try
          {
            pi.SetValue(shadow, (System.Boolean)(type.GetProperty(pi.Name).GetValue(PlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(Fix.JobClass))
        {
          try
          {
            pi.SetValue(shadow, (Fix.JobClass)Enum.Parse(typeof(Fix.JobClass), PlayerList[ii].Job.ToString()));
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(Fix.CommandAttribute))
        {
          try
          {
            pi.SetValue(shadow, (Fix.CommandAttribute)(type.GetProperty(pi.Name).GetValue(PlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(List<string>))
        {
          // todo ActionCommandList
        }
      }

      ShadowPlayerList.Add(shadow);
    }

    GameObject objTF = new GameObject("ShadowTF");
    ShadowTF = objTF.AddComponent<TeamFoundation>();
    Type type2 = TF.GetType();
    foreach (PropertyInfo pi in type2.GetProperties())
    {
      if (pi.PropertyType == typeof(System.Int32))
      {
        try
        {
          pi.SetValue(ShadowTF, (System.Int32)(type2.GetProperty(pi.Name).GetValue(TF, null)), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.String))
      {
        try
        {
          pi.SetValue(ShadowTF, (string)(type2.GetProperty(pi.Name).GetValue(TF, null)), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Double))
      {
        try
        {
          pi.SetValue(ShadowTF, (System.Double)(type2.GetProperty(pi.Name).GetValue(TF, null)), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Single))
      {
        try
        {
          pi.SetValue(ShadowTF, (System.Single)(type2.GetProperty(pi.Name).GetValue(TF, null)), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Boolean))
      {
        try
        {
          pi.SetValue(ShadowTF, (System.Boolean)(type2.GetProperty(pi.Name).GetValue(TF, null)), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(List<Item>))
      {
        Debug.Log("backpack maybe: " + pi.Name);
        if (pi.Name == "BackpackList")
        {
          try
          {
            Debug.Log("before shadowTF.backpack: " + ShadowTF.BackpackList.Count.ToString());

            ShadowTF.BackpackList.Clear();
            for (int ii = 0; ii < TF.BackpackList.Count; ii++)
            {
              Debug.Log("TF.backpack " + TF.BackpackList[ii].ItemName + " " + TF.BackpackList[ii].StackValue.ToString());
              ShadowTF.AddBackPack(TF.BackpackList[ii], TF.BackpackList[ii].StackValue);
            }

            Debug.Log("after shadowTF.backpack: " + ShadowTF.BackpackList.Count.ToString());
            for (int ii = 0; ii < TF.BackpackList.Count; ii++)
            {
              Debug.Log("ShadowTF.backpack " + ShadowTF.BackpackList[ii].ItemName + " " + ShadowTF.BackpackList[ii].StackValue.ToString());
            }
          }
          catch { }
        }
      }
    }


    GameObject objAR = new GameObject("ShadowAR");
    ShadowAR = objAR.AddComponent<AkashicRecord>();
    Type type3 = AR.GetType();
    foreach (PropertyInfo pi in type3.GetProperties())
    {
      if (pi.PropertyType == typeof(System.Int32))
      {
        try
        {
          pi.SetValue(ShadowAR, (System.Int32)(type3.GetProperty(pi.Name).GetValue(AR, null)), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.String))
      {
        try
        {
          pi.SetValue(ShadowAR, (string)(type3.GetProperty(pi.Name).GetValue(AR, null)), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Double))
      {
        try
        {
          pi.SetValue(ShadowAR, (System.Double)(type3.GetProperty(pi.Name).GetValue(AR, null)), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Single))
      {
        try
        {
          pi.SetValue(ShadowAR, (System.Single)(type3.GetProperty(pi.Name).GetValue(AR, null)), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Boolean))
      {
        try
        {
          pi.SetValue(ShadowAR, (System.Boolean)(type3.GetProperty(pi.Name).GetValue(AR, null)), null);
        }
        catch { }
      }
    }
  }

  public static void CopyShadowToMain()
  {
    Debug.Log("ShadowPlayer.Count " + One.ShadowPlayerList.Count.ToString());
    for (int ii = 0; ii < One.ShadowPlayerList.Count; ii++)
    {
      Debug.Log("ShadowPlayer life: " + One.ShadowPlayerList[ii].CurrentLife.ToString());
      One.PlayerList[ii].MainWeapon = One.ShadowPlayerList[ii].MainWeapon;
      One.PlayerList[ii].SubWeapon = One.ShadowPlayerList[ii].SubWeapon;
      One.PlayerList[ii].MainArmor = One.ShadowPlayerList[ii].MainArmor;
      One.PlayerList[ii].Accessory1 = One.ShadowPlayerList[ii].Accessory1;
      One.PlayerList[ii].Accessory2 = One.ShadowPlayerList[ii].Accessory2;
      One.PlayerList[ii].Artifact = One.ShadowPlayerList[ii].Artifact;

      Type type = PlayerList[ii].GetType();
      foreach (PropertyInfo pi in type.GetProperties())
      {
        if (pi.PropertyType == typeof(System.Int32))
        {
          try
          {
            pi.SetValue(One.PlayerList[ii], (System.Int32)(type.GetProperty(pi.Name).GetValue(One.ShadowPlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.String))
        {
          try
          {
            pi.SetValue(One.PlayerList[ii], (string)(type.GetProperty(pi.Name).GetValue(One.ShadowPlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Double))
        {
          try
          {
            pi.SetValue(One.PlayerList[ii], (System.Double)(type.GetProperty(pi.Name).GetValue(One.ShadowPlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Single))
        {
          try
          {
            pi.SetValue(One.PlayerList[ii], (System.Single)(type.GetProperty(pi.Name).GetValue(One.ShadowPlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Boolean))
        {
          try
          {
            pi.SetValue(One.PlayerList[ii], (System.Boolean)(type.GetProperty(pi.Name).GetValue(One.ShadowPlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(Fix.JobClass))
        {
          try
          {
            pi.SetValue(One.PlayerList[ii], (Fix.JobClass)Enum.Parse(typeof(Fix.JobClass), One.ShadowPlayerList[ii].Job.ToString()));
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(Fix.CommandAttribute))
        {
          try
          {
            pi.SetValue(One.PlayerList[ii], (Fix.CommandAttribute)(type.GetProperty(pi.Name).GetValue(One.ShadowPlayerList[ii], null)), null);
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(List<string>))
        {
          // todo ActionCommandList
        }
      }
    }

    // todo backpack
    // GetBackpack


      //Type type = MC.GetType();
      //foreach (PropertyInfo pi in type.GetProperties())
      //{
      //  // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
      //  if (pi.PropertyType == typeof(System.Int32))
      //  {
      //    try
      //    {
      //      pi.SetValue(MC, (System.Int32)(type.GetProperty(pi.Name).GetValue(ShadowMC, null)), null);
      //      pi.SetValue(SC, (System.Int32)(type.GetProperty(pi.Name).GetValue(ShadowSC, null)), null);
      //      pi.SetValue(TC, (System.Int32)(type.GetProperty(pi.Name).GetValue(ShadowTC, null)), null);
      //    }
      //    catch { }
      //  }
      //  else if (pi.PropertyType == typeof(System.String))
      //  {
      //    try
      //    {
      //      pi.SetValue(MC, (string)(type.GetProperty(pi.Name).GetValue(ShadowMC, null)), null);
      //      pi.SetValue(SC, (string)(type.GetProperty(pi.Name).GetValue(ShadowSC, null)), null);
      //      pi.SetValue(TC, (string)(type.GetProperty(pi.Name).GetValue(ShadowTC, null)), null);
      //    }
      //    catch { }
      //  }
      //  else if (pi.PropertyType == typeof(System.Boolean))
      //  {
      //    try
      //    {
      //      pi.SetValue(MC, (System.Boolean)(type.GetProperty(pi.Name).GetValue(ShadowMC, null)), null);
      //      pi.SetValue(SC, (System.Boolean)(type.GetProperty(pi.Name).GetValue(ShadowSC, null)), null);
      //      pi.SetValue(TC, (System.Boolean)(type.GetProperty(pi.Name).GetValue(ShadowTC, null)), null);
      //    }
      //    catch { }
      //  }
      //  // s 後編追加
      //  else if (pi.PropertyType == typeof(Character.AdditionalSpellType))
      //  {
      //    try
      //    {
      //      pi.SetValue(MC, (Character.AdditionalSpellType)(Enum.Parse(typeof(Character.AdditionalSpellType), type.GetProperty(pi.Name).GetValue(ShadowMC, null).ToString())), null);
      //      pi.SetValue(SC, (Character.AdditionalSpellType)(Enum.Parse(typeof(Character.AdditionalSpellType), type.GetProperty(pi.Name).GetValue(ShadowSC, null).ToString())), null);
      //      pi.SetValue(TC, (Character.AdditionalSpellType)(Enum.Parse(typeof(Character.AdditionalSpellType), type.GetProperty(pi.Name).GetValue(ShadowTC, null).ToString())), null);
      //    }
      //    catch { }
      //  }
      //  else if (pi.PropertyType == typeof(Character.AdditionalSkillType))
      //  {
      //    try
      //    {
      //      pi.SetValue(MC, (Character.AdditionalSkillType)(Enum.Parse(typeof(Character.AdditionalSkillType), type.GetProperty(pi.Name).GetValue(ShadowMC, null).ToString())), null);
      //      pi.SetValue(SC, (Character.AdditionalSkillType)(Enum.Parse(typeof(Character.AdditionalSkillType), type.GetProperty(pi.Name).GetValue(ShadowSC, null).ToString())), null);
      //      pi.SetValue(TC, (Character.AdditionalSkillType)(Enum.Parse(typeof(Character.AdditionalSkillType), type.GetProperty(pi.Name).GetValue(ShadowTC, null).ToString())), null);
      //    }
      //    catch { }
      //  }
      //  // e 後編追加
      //}

      //Type type2 = TF.GetType();
      //foreach (PropertyInfo pi in type2.GetProperties())
      //{
      //  // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
      //  if (pi.PropertyType == typeof(System.Int32))
      //  {
      //    try
      //    {
      //      pi.SetValue(TF, (System.Int32)(type2.GetProperty(pi.Name).GetValue(shadowTF, null)), null);
      //    }
      //    catch { }
      //  }
      //  else if (pi.PropertyType == typeof(System.String))
      //  {
      //    try
      //    {
      //      pi.SetValue(TF, (string)(type2.GetProperty(pi.Name).GetValue(shadowTF, null)), null);
      //    }
      //    catch { }
      //  }
      //  else if (pi.PropertyType == typeof(System.Boolean))
      //  {
      //    try
      //    {
      //      pi.SetValue(TF, (System.Boolean)(type2.GetProperty(pi.Name).GetValue(shadowTF, null)), null);
      //    }
      //    catch { }
      //  }
      //}

      //Type type3 = WE2.GetType();
      //foreach (PropertyInfo pi in type3.GetProperties())
      //{
      //  // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
      //  if (pi.PropertyType == typeof(System.Int32))
      //  {
      //    try
      //    {
      //      pi.SetValue(WE2, (System.Int32)(type3.GetProperty(pi.Name).GetValue(shadowTF2, null)), null);
      //    }
      //    catch { }
      //  }
      //  else if (pi.PropertyType == typeof(System.String))
      //  {
      //    try
      //    {
      //      pi.SetValue(WE2, (string)(type3.GetProperty(pi.Name).GetValue(shadowTF2, null)), null);
      //    }
      //    catch { }
      //  }
      //  else if (pi.PropertyType == typeof(System.Boolean))
      //  {
      //    try
      //    {
      //      pi.SetValue(WE2, (System.Boolean)(type3.GetProperty(pi.Name).GetValue(shadowTF2, null)), null);
      //    }
      //    catch { }
      //  }
      //}
    }

  #region "BGM再生と効果音関連"
  public static void PlaySoundEffect(string soundName)
  {
    Debug.Log("Conf EnableSoundEffect: " + One.CONF.EnableSoundEffect);
    //if (GroundOne.EnableSoundEffect > 0.0f)
    {
      soundSource.clip = Resources.Load<AudioClip>(Fix.BaseSoundFolder + soundName);
      soundSource.volume = (float)((float)One.CONF.EnableSoundEffect / 100.0f);
      soundSource.Play();
    }
  }

  public static void ChangeSoundEffectVolume(float vol)
  {
    soundSource.volume = vol;
  }

  public static void PlayDungeonMusic(string targetMusicName, float loopBegin)
  {
    PlayDungeonMusic(targetMusicName, string.Empty, loopBegin);
  }
  public static void PlayDungeonMusic(string targetMusicName, string targetMusicName2, float loopBegin)
  {
    StopDungeonMusic();

    bool detect = false;
    for (int ii = 0; ii < BgmName.Count; ii++)
    {
      if (targetMusicName == BgmName[ii])
      {
        BgmNumber = ii;
        detect = true;
        break;
      }
    }

    if (detect == false)
    {
      BgmName.Add(targetMusicName);
      BgmLoopPoint.Add(loopBegin);
      bgmSource.Add(bgm.AddComponent<AudioSource>());
      BgmNumber = BgmName.Count - 1;
    }

    bgmSource[BgmNumber].Stop();
    bgmSource[BgmNumber].clip = Resources.Load<AudioClip>(Fix.BaseMusicFolder + targetMusicName);
    bgmSource[BgmNumber].loop = false;
    bgmSource[BgmNumber].volume = (float)((float)One.CONF.EnableBGM / 100.0f);
    bgmSource[BgmNumber].time = 0;
    bgmSource[BgmNumber].Play();
  }

  public static void StopDungeonMusic()
  {
    if (bgmSource.Count > BgmNumber)
    {
      bgmSource[BgmNumber].Stop();
    }
  }

  public static void ChangeDungeonMusicVolume(float vol)
  {
    if (bgmSource.Count > BgmNumber)
    {
      bgmSource[BgmNumber].volume = vol;
    }
  }

  public static void TempStopDungeonMusic()
  {
    if (bgmSource.Count > BgmNumber)
    {
      bgmSource[BgmNumber].mute = true;
    }
  }

  public static void ResumeDungeonMusic()
  {
    if (bgmSource.Count > BgmNumber)
    {
      bgmSource[BgmNumber].mute = false;
    }
  }
  #endregion

  #region "セーブ・ロード関連"
  public static string pathForRoot()
  {
    if (Application.platform == RuntimePlatform.IPhonePlayer)
    {
      return Application.persistentDataPath;
    }
    else if (Application.platform == RuntimePlatform.Android)
    {
      return Application.persistentDataPath;
    }
    else
    {
      return Environment.CurrentDirectory + @"/Assets/Resources/"; // Unity作業フォルダ限定の書き方
    }
  }
  public static string pathForDocumentsFile(string filename)
  {
    if (Application.platform == RuntimePlatform.IPhonePlayer)
    {
      //string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
      //path = path.Substring(0, path.LastIndexOf('/'));
      //return Path.Combine(Path.Combine(path, "Documents"), filename);
      return Path.Combine(PathForSaveFile(), filename);
    }
    else if (Application.platform == RuntimePlatform.Android)
    {
      return Path.Combine(PathForSaveFile(), filename);
    }
    else
    {
      return Fix.BaseSaveFolder + filename;
    }
  }

  public static string PathForSaveFile()
  {
    if (Application.platform == RuntimePlatform.IPhonePlayer)
    {
      //return Application.persistentDataPath.Substring(0, Application.persistentDataPath.LastIndexOf('/')); // after (ios)
      return Path.Combine(Application.persistentDataPath, "save");
    }
    else if (Application.platform == RuntimePlatform.Android)
    {
      return Path.Combine(Application.persistentDataPath, "save");
    }
    else
    {
      return Fix.BaseSaveFolder;
    }

  }

  public static string PathForRootFile(string filename)
  {
    if (Application.platform == RuntimePlatform.IPhonePlayer)
    {
      //return filename;
      return Path.Combine(Application.persistentDataPath, filename);
    }
    else if (Application.platform == RuntimePlatform.Android)
    {
      return Path.Combine(Application.persistentDataPath, filename);
    }
    else
    {
      return filename;
    }
  }

  public static void MakeDirectory()
  {
    if (Application.platform == RuntimePlatform.IPhonePlayer)
    {
      // なし
      string directory = PathForSaveFile();
      if (System.IO.Directory.Exists(directory) == false)
      {
        System.IO.Directory.CreateDirectory(directory);
      }
    }
    else if (Application.platform == RuntimePlatform.Android)
    {
      string directory = PathForSaveFile();
      if (System.IO.Directory.Exists(directory) == false)
      {
        System.IO.Directory.CreateDirectory(directory);
      }
    }
    else
    {
      if (System.IO.Directory.Exists(Fix.BaseSaveFolder) == false)
      {
        System.IO.Directory.CreateDirectory(Fix.BaseSaveFolder);
      }
    }
  }

  // 通常セーブ、現実世界の自動セーブ、タイトルSeekerモードの自動セーブを結合
  public static void AutoSaveTruthWorldEnvironment()
  {
    XmlTextWriter xmlWriter = new XmlTextWriter(PathForRootFile(Fix.BaseSaveFolder + Fix.TF_SAVE), Encoding.UTF8);
    try
    {
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteWhitespace("\r\n");

      xmlWriter.WriteStartElement("Body");
      xmlWriter.WriteElementString("DateTime", DateTime.Now.ToString());
      xmlWriter.WriteWhitespace("\r\n");

      // ワールド環境
      xmlWriter.WriteStartElement("TeamFoundation");
      xmlWriter.WriteWhitespace("\r\n");
      if (TF != null)
      {
        Type typeWE2 = TF.GetType();
        foreach (PropertyInfo pi in typeWE2.GetProperties())
        {
          if (pi.PropertyType == typeof(System.Int32))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(TF, null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Single))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Single)(pi.GetValue(TF, null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.String))
          {
            xmlWriter.WriteElementString(pi.Name, (string)(pi.GetValue(TF, null)));
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Boolean))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Boolean)pi.GetValue(TF, null)).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
        }

        xmlWriter.WriteWhitespace("\r\n");

        xmlWriter.WriteStartElement("Backpack");
        xmlWriter.WriteWhitespace("\r\n");
        for (int ii = 0; ii < TF.BackpackList.Count; ii++)
        {
          xmlWriter.WriteElementString("BackPack" + ii.ToString(), TF.BackpackList[ii].ItemName);
          xmlWriter.WriteWhitespace("\r\n");
          xmlWriter.WriteElementString("BackPackStack" + ii.ToString(), TF.BackpackList[ii].StackValue.ToString());
          xmlWriter.WriteWhitespace("\r\n");
        }
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // プレイヤー情報
      for (int ii = 0; ii < PlayerList.Count; ii++)
      {
        Type type = PlayerList[ii].GetType();
        xmlWriter.WriteStartElement("Character_" + ii.ToString());
        xmlWriter.WriteWhitespace("\r\n");
        foreach (PropertyInfo pi in type.GetProperties())
        {
          if (pi.PropertyType == typeof(System.Int32))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.String))
          {
            xmlWriter.WriteElementString(pi.Name, (string)(pi.GetValue(PlayerList[ii], null)));
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Boolean))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Boolean)pi.GetValue(PlayerList[ii], null)).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
        }
        xmlWriter.WriteElementString("MainWeapon", (PlayerList[ii].MainWeapon?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("SubWeapon", (PlayerList[ii].SubWeapon?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("MainArmor", (PlayerList[ii].MainArmor?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Accessory1", (PlayerList[ii].Accessory1?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Accessory2", (PlayerList[ii].Accessory2?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Artifact", (PlayerList[ii].Artifact?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteEndElement();
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteWhitespace("\r\n");
      }

      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteEndDocument();
    }
    finally
    {
      xmlWriter.Close();
    }
  }

  public static void RealWorldSave()
  {
    ExecSave(Fix.WorldSaveNum, true);
  }

  private static void ExecSave(string targetFileName, bool forceSave)
  {
    DateTime now = DateTime.Now;

    foreach (string overwriteData in System.IO.Directory.GetFiles(One.PathForSaveFile(), "*.xml"))
    {
      if (overwriteData.Contains(targetFileName))
      {
        if (forceSave == false) // if 後編追加
        {
          //this.currentSaveText = sender;
          //this.currentTargetFileName = targetFileName;
          //this.yesnoSystemMessage.text = this.MESSAGE_OVERWRITE;
          //this.groupYesnoSystemMessage.SetActive(true);
          //this.Filter.SetActive(true);
          return;
        }
        else
        {
          System.IO.File.Delete(overwriteData); // 後編追加
        }
      }
    }

    targetFileName += now.Year.ToString("D4") + now.Month.ToString("D2") + now.Day.ToString("D2") + now.Hour.ToString("D2") + now.Minute.ToString("D2") + now.Second.ToString("D2") + One.TF.GameDay.ToString("D3");
    targetFileName += Convert.ToString(1);
    targetFileName += ".xml";

    XmlTextWriter xmlWriter = new XmlTextWriter(One.pathForDocumentsFile(targetFileName), Encoding.UTF8);
    try
    {
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteWhitespace("\r\n");

      xmlWriter.WriteStartElement("Body");
      xmlWriter.WriteElementString("DateTime", DateTime.Now.ToString());
      xmlWriter.WriteElementString("Version", Fix.VERSION.ToString());
      xmlWriter.WriteWhitespace("\r\n");

      // ワールド環境
      xmlWriter.WriteStartElement("TeamFoundation");
      xmlWriter.WriteWhitespace("\r\n");
      if (One.TF != null)
      {
        Type typeWE2 = One.TF.GetType();
        foreach (PropertyInfo pi in typeWE2.GetProperties())
        {
          if (pi.PropertyType == typeof(System.Int32))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(One.TF, null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.String))
          {
            xmlWriter.WriteElementString(pi.Name, (string)(pi.GetValue(One.TF, null)));
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Double))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Double)(pi.GetValue(One.TF, null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Single))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Single)(pi.GetValue(One.TF, null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Boolean))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Boolean)pi.GetValue(One.TF, null)).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
        }
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // バックパック
      xmlWriter.WriteStartElement("Backpack");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.BackpackList.Count; ii++)
      {
        xmlWriter.WriteElementString("Item_" + ii.ToString("D8"), One.TF.BackpackList[ii].ItemName);
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_Stack", One.TF.BackpackList[ii].StackValue.ToString());
        xmlWriter.WriteWhitespace("\r\n");
        if (One.TF.BackpackList[ii].CanbeSocket1 && One.TF.BackpackList[ii].SocketedItem1 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket1", One.TF.BackpackList[ii].SocketedItem1.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.BackpackList[ii].CanbeSocket2 && One.TF.BackpackList[ii].SocketedItem2 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket2", One.TF.BackpackList[ii].SocketedItem2.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.BackpackList[ii].CanbeSocket3 && One.TF.BackpackList[ii].SocketedItem3 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket3", One.TF.BackpackList[ii].SocketedItem3.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.BackpackList[ii].CanbeSocket4 && One.TF.BackpackList[ii].SocketedItem4 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket4", One.TF.BackpackList[ii].SocketedItem4.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
        if (One.TF.BackpackList[ii].CanbeSocket5 && One.TF.BackpackList[ii].SocketedItem5 != null)
        {
          xmlWriter.WriteElementString("Item_" + ii.ToString("D8") + "_JewelSocket5", One.TF.BackpackList[ii].SocketedItem5.ItemName);
          xmlWriter.WriteWhitespace("\r\n");
        }
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");


      // プレイヤー情報
      for (int ii = 0; ii < One.PlayerList.Count; ii++)
      {
        Type type = One.PlayerList[ii].GetType();
        xmlWriter.WriteStartElement("Character_" + ii.ToString());
        xmlWriter.WriteWhitespace("\r\n");
        foreach (PropertyInfo pi in type.GetProperties())
        {
          if (pi.PropertyType == typeof(System.Int32))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.String))
          {
            xmlWriter.WriteElementString(pi.Name, (string)(pi.GetValue(One.PlayerList[ii], null)));
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Double))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Double)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Single))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Single)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Boolean))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Boolean)pi.GetValue(One.PlayerList[ii], null)).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(Fix.JobClass))
          {
            xmlWriter.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(Fix.CommandAttribute))
          {
            xmlWriter.WriteElementString(pi.Name, ((Fix.CommandAttribute)(pi.GetValue(One.PlayerList[ii], null))).ToString());
            xmlWriter.WriteWhitespace("\r\n");
          }
        }
        xmlWriter.WriteElementString("MainWeapon", (One.PlayerList[ii].MainWeapon?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("SubWeapon", (One.PlayerList[ii].SubWeapon?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("MainArmor", (One.PlayerList[ii].MainArmor?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Accessory1", (One.PlayerList[ii].Accessory1?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Accessory2", (One.PlayerList[ii].Accessory2?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteElementString("Artifact", (One.PlayerList[ii].Artifact?.ItemName ?? String.Empty));
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteEndElement();
        xmlWriter.WriteWhitespace("\r\n");
        xmlWriter.WriteWhitespace("\r\n");
      }


      // ダンジョンKnownTileInfo
      xmlWriter.WriteStartElement("EsmiliaGrassField");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_EsmiliaGrassField.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileInfo_EsmiliaGrassField_" + ii.ToString("D8"), One.TF.KnownTileList_EsmiliaGrassField[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Goratrum )
      xmlWriter.WriteStartElement("Goratrum");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Goratrum.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileInfo_Goratrum_" + ii.ToString("D8"), One.TF.KnownTileList_Goratrum[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");
      // ダンジョンKnownTileInfo ( Goratrum_2 )
      xmlWriter.WriteStartElement("Goratrum_2");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Goratrum_2.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileInfo_Goratrum_2_" + ii.ToString("D8"), One.TF.KnownTileList_Goratrum_2[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( MysticForest )
      xmlWriter.WriteStartElement("MysticForest");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_MysticForest.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileInfo_MysticForest_" + ii.ToString("D8"), One.TF.KnownTileList_MysticForest[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( VelgusSeaTemple )
      xmlWriter.WriteStartElement("VelgusSeaTemple");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_VelgusSeaTemple.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_VelgusSeaTemple" + ii.ToString("D8"), One.TF.KnownTileList_VelgusSeaTemple[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( VelgusSeaTemple_2 )
      xmlWriter.WriteStartElement("VelgusSeaTemple_2");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_VelgusSeaTemple_2.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_VelgusSeaTemple_2" + ii.ToString("D8"), One.TF.KnownTileList_VelgusSeaTemple_2[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( VelgusSeaTemple_3 )
      xmlWriter.WriteStartElement("VelgusSeaTemple_3");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_VelgusSeaTemple_3.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_VelgusSeaTemple_3" + ii.ToString("D8"), One.TF.KnownTileList_VelgusSeaTemple_3[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( VelgusSeaTemple_4 )
      xmlWriter.WriteStartElement("VelgusSeaTemple_4");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_VelgusSeaTemple_4.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_VelgusSeaTemple_4" + ii.ToString("D8"), One.TF.KnownTileList_VelgusSeaTemple_4[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Edelgarzen_1 )
      xmlWriter.WriteStartElement("Edelgarzen_1");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Edelgarzen_1.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_Edelgarzen_1" + ii.ToString("D8"), One.TF.KnownTileList_Edelgarzen_1[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Edelgarzen_2 )
      xmlWriter.WriteStartElement("Edelgarzen_2");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Edelgarzen_2.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_Edelgarzen_2" + ii.ToString("D8"), One.TF.KnownTileList_Edelgarzen_2[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Edelgarzen_3 )
      xmlWriter.WriteStartElement("Edelgarzen_3");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Edelgarzen_3.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_Edelgarzen_3" + ii.ToString("D8"), One.TF.KnownTileList_Edelgarzen_3[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // ダンジョンKnownTileInfo ( Edelgarzen_4 )
      xmlWriter.WriteStartElement("Edelgarzen_4");
      xmlWriter.WriteWhitespace("\r\n");
      for (int ii = 0; ii < One.TF.KnownTileList_Edelgarzen_4.Count; ii++)
      {
        xmlWriter.WriteElementString("KnownTileList_Edelgarzen_4" + ii.ToString("D8"), One.TF.KnownTileList_Edelgarzen_4[ii].ToString());
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");
      xmlWriter.WriteWhitespace("\r\n");

      // TeamFoundation終了
      xmlWriter.WriteEndElement();
      xmlWriter.WriteWhitespace("\r\n");

      xmlWriter.WriteEndDocument();
    }
    finally
    {
      xmlWriter.Close();

      //if ((Text)sender != null) // if 後編追加
      //{
      //  ((Text)sender).text = DateTime.Now.ToString() + "\r\n経過日数：" + One.TF.GameDay.ToString("D3") + "日 ";
      //  if (One.TF.SaveByDungeon)
      //  {
      //    ((Text)sender).text += ConvertMapFileToDungeonName(One.TF.CurrentDungeonField);
      //  }
      //  else
      //  {
      //    ((Text)sender).text += saveDungeonAreaString + One.TF.CurrentAreaName;
      //  }

      //  if (!((Text)sender).Equals(buttonText[0])) back_button[0].GetComponent<Image>().sprite = null;
      //  if (!((Text)sender).Equals(buttonText[1])) back_button[1].GetComponent<Image>().sprite = null;
      //  if (!((Text)sender).Equals(buttonText[2])) back_button[2].GetComponent<Image>().sprite = null;
      //  if (!((Text)sender).Equals(buttonText[3])) back_button[3].GetComponent<Image>().sprite = null;
      //  if (!((Text)sender).Equals(buttonText[4])) back_button[4].GetComponent<Image>().sprite = null;
      //  if (!((Text)sender).Equals(buttonText[5])) back_button[5].GetComponent<Image>().sprite = null;
      //  if (!((Text)sender).Equals(buttonText[6])) back_button[6].GetComponent<Image>().sprite = null;
      //  if (!((Text)sender).Equals(buttonText[7])) back_button[7].GetComponent<Image>().sprite = null;
      //  if (!((Text)sender).Equals(buttonText[8])) back_button[8].GetComponent<Image>().sprite = null;
      //  if (!((Text)sender).Equals(buttonText[9])) back_button[9].GetComponent<Image>().sprite = null;
      //  for (int ii = 0; ii < buttonText.Length; ii++)
      //  {
      //    if (sender.Equals(buttonText[ii]))
      //    {
      //      back_button[ii].GetComponent<Image>().sprite = Resources.Load<Sprite>(Fix.SAVELOAD_NEW);
      //    }
      //  }
      //}
    }

    // セーブデータをサーバーへ転送する。
    //try
    //{
    //  Debug.Log("Call UpdateSaveData");
    //  using (FileStream fs = new FileStream(One.pathForDocumentsFile(targetFileName), FileMode.Open))
    //  {
    //    using (BinaryReader br = new BinaryReader(fs))
    //    {
    //      byte[] save_current = br.ReadBytes((int)fs.Length);
    //      using (FileStream fs2 = new FileStream(One.PathForRootFile(Fix.WE2_FILE), FileMode.Open))
    //      {
    //        using (BinaryReader br2 = new BinaryReader(fs2))
    //        {
    //          byte[] save_we2 = br2.ReadBytes((int)fs2.Length);
    //          One.SQL.UpdaeSaveData(save_current, save_we2, sender.text, this.pageNumber.ToString());
    //        }
    //      }
    //    }
    //  }

    //  Debug.Log("Call UpdateSaveData ok");
    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("ExecSave error: " + ex.ToString());
    //}
  }

  public static void RealWorldLoad()
  {
    ExecLoad(Fix.WorldSaveNum, true);
  }

  private static void ExecLoad(string targetFileName, bool forceLoad)
  {
    //if (this.nowAutoKill) { return; }
    //Debug.Log("ExecLoad 0 " + DateTime.Now);

    One.ReInitializeGroundOne(true);

    XmlDocument xml = new XmlDocument();
    DateTime now = DateTime.Now;
    string yearData = String.Empty;
    string monthData = String.Empty;
    string dayData = String.Empty;
    string hourData = String.Empty;
    string minuteData = String.Empty;
    string secondData = String.Empty;
    string gamedayData = String.Empty;
    //string completeareaData = String.Empty;

    Debug.Log("ExecLoad 1 " + DateTime.Now);
    //if (((Text)sender) != null)
    //{
    //  yearData = ((Text)sender).text.Substring(0, 4);
    //  monthData = ((Text)sender).text.Substring(5, 2);
    //  dayData = ((Text)sender).text.Substring(8, 2);
    //  hourData = ((Text)sender).text.Substring(11, 2);
    //  minuteData = ((Text)sender).text.Substring(14, 2);
    //  secondData = ((Text)sender).text.Substring(17, 2);
    //  gamedayData = ((Text)sender).text.Substring(this.gameDayString.Length + 19, 3);
    //  //completeareaData = ((Text)sender).text.Substring(this.gameDayString.Length + this.gameDayString2.Length + this.archiveAreaString.Length + 22, 1);

    //  //if (completeareaData == "制")
    //  //{
    //  //  this.systemMessage.text = MESSAGE_1;
    //  //  this.back_SystemMessage.SetActive(true);
    //  //  this.Filter.SetActive(true);
    //  //  return;
    //  //}
    //  targetFileName += yearData + monthData + dayData + hourData + minuteData + secondData + gamedayData + /* completeareaData + */ "1.xml";
    //}
    //else
    {
      foreach (string currentFile in System.IO.Directory.GetFiles(One.PathForSaveFile(), "*.xml"))
      {
        if (currentFile.Contains(Fix.WorldSaveNum))
        {
          targetFileName = System.IO.Path.GetFileName(currentFile);
          break;
        }
      }
    }

    xml.Load(One.pathForDocumentsFile(targetFileName));
    One.CurrentLoadFileName = targetFileName;
    Debug.Log("ExecLoad 2 " + DateTime.Now);

    // TeamFoundation
    List<string> listTFName = new List<string>();
    List<string> listTFValue = new List<string>();
    XmlNodeList parent = xml.GetElementsByTagName("TeamFoundation");
    for (int ii = 0; ii < parent.Count; ii++)
    {
      Debug.Log("node: " + parent[ii].Name.ToString());
      XmlNodeList current = parent[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        // Debug.Log("TF child: " + current[jj].Name + " value: " + current[jj].InnerText.ToString());
        listTFName.Add(current[jj].Name);
        listTFValue.Add(current[jj].InnerText);
      }
    }

    Type typeTF = One.TF.GetType();
    Debug.Log("ExecLoad 6 " + DateTime.Now);


    PropertyInfo[] tempTF = typeTF.GetProperties();
    Debug.Log(tempTF.Length.ToString());
    for (int ii = 0; ii < tempTF.Length; ii++)
    {
      // Debug.Log("TF: " + tempTF[ii].Name);
      PropertyInfo pi = tempTF[ii];
      // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
      if (pi.PropertyType == typeof(System.Int32))
      {
        try
        {
          for (int jj = 0; jj < listTFName.Count; jj++)
          {
            if (listTFName[jj] == pi.Name)
            {
              pi.SetValue(One.TF, Convert.ToInt32(listTFValue[jj]), null);
              break;
            }
          }
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Single))
      {
        try
        {
          for (int jj = 0; jj < listTFName.Count; jj++)
          {
            if (listTFName[jj] == pi.Name)
            {
              pi.SetValue(One.TF, Convert.ToSingle(listTFValue[jj]), null);
              break;
            }
          }
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.String))
      {
        try
        {
          for (int jj = 0; jj < listTFName.Count; jj++)
          {
            if (listTFName[jj] == pi.Name)
            {
              pi.SetValue(One.TF, listTFValue[jj], null);
              break;
            }
          }
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Boolean))
      {
        try
        {
          for (int jj = 0; jj < listTFName.Count; jj++)
          {
            if (listTFName[jj] == pi.Name)
            {
              pi.SetValue(One.TF, Convert.ToBoolean(listTFValue[jj]), null);
              break;
            }
          }
        }
        catch { }
      }
    }

    // Backpack
    List<string> listItemValue = new List<string>();
    List<string> listItemStack = new List<string>();
    List<string> listItemJewelSocket1 = new List<string>();
    List<string> listItemJewelSocket2 = new List<string>();
    List<string> listItemJewelSocket3 = new List<string>();
    List<string> listItemJewelSocket4 = new List<string>();
    List<string> listItemJewelSocket5 = new List<string>();
    XmlNodeList parentBackpack = xml.GetElementsByTagName("Backpack");
    for (int ii = 0; ii < parentBackpack.Count; ii++)
    {
      XmlNodeList current = parentBackpack[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].Name.Contains("Stack") == false && current[jj].Name.Contains("JewelSocket") == false)
        {
          listItemValue.Add(current[jj].InnerText);
          XmlNodeList temp2 = xml.GetElementsByTagName(current[jj].Name + "_Stack");
          listItemStack.Add(temp2[0]?.InnerText ?? String.Empty);

          XmlNodeList temp3_1 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket1");
          listItemJewelSocket1.Add(temp3_1[0]?.InnerText ?? string.Empty);

          XmlNodeList temp3_2 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket2");
          listItemJewelSocket2.Add(temp3_2[0]?.InnerText ?? string.Empty);

          XmlNodeList temp3_3 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket3");
          listItemJewelSocket3.Add(temp3_3[0]?.InnerText ?? string.Empty);

          XmlNodeList temp3_4 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket4");
          listItemJewelSocket4.Add(temp3_4[0]?.InnerText ?? string.Empty);

          XmlNodeList temp3_5 = xml.GetElementsByTagName(current[jj].Name + "_JewelSocket5");
          listItemJewelSocket5.Add(temp3_5[0]?.InnerText ?? string.Empty);
        }
      }
    }

    for (int ii = 0; ii < listItemValue.Count; ii++)
    {
      Debug.Log("listItemStack: " + listItemStack[ii]);
      for (int jj = 0; jj < Convert.ToInt32(listItemStack[ii]); jj++)
      {
        Item current = new Item(listItemValue[ii]);
        if (listItemJewelSocket1[ii] != string.Empty)
        {
          current.AddJewelSocket1(listItemJewelSocket1[ii]);
        }
        if (listItemJewelSocket2[ii] != string.Empty)
        {
          current.AddJewelSocket2(listItemJewelSocket2[ii]);
        }
        if (listItemJewelSocket3[ii] != string.Empty)
        {
          current.AddJewelSocket3(listItemJewelSocket3[ii]);
        }
        if (listItemJewelSocket4[ii] != string.Empty)
        {
          current.AddJewelSocket4(listItemJewelSocket4[ii]);
        }
        if (listItemJewelSocket5[ii] != string.Empty)
        {
          current.AddJewelSocket5(listItemJewelSocket5[ii]);
        }
        One.TF.AddBackPack(current);
      }
    }

    // Character
    for (int ii = 0; ii < Fix.INFINITY; ii++)
    {
      List<string> listName = new List<string>();
      List<string> listValue = new List<string>();
      XmlNodeList character = xml.GetElementsByTagName("Character_" + ii.ToString());
      if (character == null)
      {
        Debug.Log("character list is null, then no action");
        break;
      }
      if (character.Count <= 0)
      {
        Debug.Log("character list count is 0, then no action");
        break;
      }
      Debug.Log("character Detection ok");

      XmlNodeList current = character[0].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        // Debug.Log("character child: " + current[jj].Name + " value: " + current[jj].InnerText.ToString());
        listName.Add(current[jj].Name);
        listValue.Add(current[jj].InnerText);
      }

      GameObject objDummy = new GameObject();
      Character dummy = objDummy.AddComponent<Character>();
      Type typeCharacter = dummy.GetType();
      PropertyInfo[] tempCharacter = typeCharacter.GetProperties();
      for (int jj = 0; jj < tempCharacter.Length; jj++)
      {
        // Debug.Log("character: " + tempCharacter[jj].Name);
        PropertyInfo pi = tempCharacter[jj];
        // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
        if (pi.PropertyType == typeof(System.Int32))
        {
          try
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                pi.SetValue(One.Characters[ii], Convert.ToInt32(listValue[kk]), null);
                break;
              }
            }
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.String))
        {
          try
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                pi.SetValue(One.Characters[ii], listValue[kk], null);
                break;
              }
            }
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(System.Boolean))
        {
          try
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                pi.SetValue(One.Characters[ii], Convert.ToBoolean(listValue[kk]), null);
                break;
              }
            }
          }
          catch { }
        }
        else if (pi.PropertyType == typeof(Item))
        {

          // Debug.Log("Detect Item: " + pi.Name);
          if (pi.Name == "MainWeapon")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].MainWeapon = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "SubWeapon")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].SubWeapon = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "MainArmor")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].MainArmor = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "Accessory1")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].Accessory1 = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "Accessory2")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].Accessory2 = new Item(listValue[kk]);
                break;
              }
            }
          }
          else if (pi.Name == "Artifact")
          {
            for (int kk = 0; kk < listName.Count; kk++)
            {
              if (listName[kk] == pi.Name)
              {
                One.Characters[ii].Artifact = new Item(listValue[kk]);
                break;
              }
            }
          }
        }
        else if (pi.PropertyType == typeof(Fix.JobClass))
        {
          for (int kk = 0; kk < listName.Count; kk++)
          {
            if (listName[kk] == "Job")
            {
              One.Characters[ii].Job = (Fix.JobClass)Enum.Parse(typeof(Fix.JobClass), listValue[kk]);
              break;
            }
          }
        }
      }
    }

    Debug.Log(DateTime.Now.ToString());
    Debug.Log("ExecLoad 8-1 " + DateTime.Now + DateTime.Now.Millisecond);

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

    Debug.Log("ExecLoad 9-1");
    // KnownTileInfo
    XmlNodeList parentEsmiliaGrassField = xml.GetElementsByTagName("EsmiliaGrassField");
    for (int ii = 0; ii < parentEsmiliaGrassField.Count; ii++)
    {
      XmlNodeList current = parentEsmiliaGrassField[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        //Debug.Log("ExecLoad current " + jj.ToString() + " " + current[jj].InnerText);
        if (current[jj].InnerText.Contains("True"))
        {
          //Debug.Log("ExecLoad KnownTileList_EsmiliaGrassField KnownNumber: " + jj.ToString());
          One.TF.KnownTileList_EsmiliaGrassField[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_EsmiliaGrassField[jj] = false;
        }
      }
    }
    XmlNodeList parentGoratrum = xml.GetElementsByTagName("Goratrum");
    for (int ii = 0; ii < parentGoratrum.Count; ii++)
    {
      XmlNodeList current = parentGoratrum[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          //Debug.Log("ExecLoad KnownTileList_Goratrum KnownNumber: " + jj.ToString());
          One.TF.KnownTileList_Goratrum[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_Goratrum[jj] = false;
        }
      }
    }
    XmlNodeList parentGoratrum_2 = xml.GetElementsByTagName("Goratrum_2");
    for (int ii = 0; ii < parentGoratrum_2.Count; ii++)
    {
      XmlNodeList current = parentGoratrum_2[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_Goratrum_2[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_Goratrum_2[jj] = false;
        }
      }
    }

    XmlNodeList parentMysticForest = xml.GetElementsByTagName("MysticForest");
    for (int ii = 0; ii < parentMysticForest.Count; ii++)
    {
      XmlNodeList current = parentMysticForest[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_MysticForest[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_MysticForest[jj] = false;
        }
      }
    }

    XmlNodeList parentVelgusSeaTemple = xml.GetElementsByTagName("VelgusSeaTemple");
    for (int ii = 0; ii < parentVelgusSeaTemple.Count; ii++)
    {
      XmlNodeList current = parentVelgusSeaTemple[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_VelgusSeaTemple[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_VelgusSeaTemple[jj] = false;
        }
      }
    }

    XmlNodeList parentVelgusSeaTemple_2 = xml.GetElementsByTagName("VelgusSeaTemple_2");
    for (int ii = 0; ii < parentVelgusSeaTemple_2.Count; ii++)
    {
      XmlNodeList current = parentVelgusSeaTemple_2[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_VelgusSeaTemple_2[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_VelgusSeaTemple_2[jj] = false;
        }
      }
    }

    XmlNodeList parentVelgusSeaTemple_3 = xml.GetElementsByTagName("VelgusSeaTemple_3");
    for (int ii = 0; ii < parentVelgusSeaTemple_3.Count; ii++)
    {
      XmlNodeList current = parentVelgusSeaTemple_3[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_VelgusSeaTemple_3[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_VelgusSeaTemple_3[jj] = false;
        }
      }
    }

    XmlNodeList parentVelgusSeaTemple_4 = xml.GetElementsByTagName("VelgusSeaTemple_4");
    for (int ii = 0; ii < parentVelgusSeaTemple_4.Count; ii++)
    {
      XmlNodeList current = parentVelgusSeaTemple_4[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_VelgusSeaTemple_4[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_VelgusSeaTemple_4[jj] = false;
        }
      }
    }

    XmlNodeList parentEdelgarzen_1 = xml.GetElementsByTagName("Edelgarzen_1");
    for (int ii = 0; ii < parentEdelgarzen_1.Count; ii++)
    {
      XmlNodeList current = parentEdelgarzen_1[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_Edelgarzen_1[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_Edelgarzen_1[jj] = false;
        }
      }
    }

    XmlNodeList parentEdelgarzen_2 = xml.GetElementsByTagName("Edelgarzen_2");
    for (int ii = 0; ii < parentEdelgarzen_2.Count; ii++)
    {
      XmlNodeList current = parentEdelgarzen_2[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_Edelgarzen_2[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_Edelgarzen_2[jj] = false;
        }
      }
    }

    XmlNodeList parentEdelgarzen_3 = xml.GetElementsByTagName("Edelgarzen_3");
    for (int ii = 0; ii < parentEdelgarzen_3.Count; ii++)
    {
      XmlNodeList current = parentEdelgarzen_3[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_Edelgarzen_3[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_Edelgarzen_3[jj] = false;
        }
      }
    }

    XmlNodeList parentEdelgarzen_4 = xml.GetElementsByTagName("Edelgarzen_4");
    for (int ii = 0; ii < parentEdelgarzen_4.Count; ii++)
    {
      XmlNodeList current = parentEdelgarzen_4[ii].ChildNodes;
      for (int jj = 0; jj < current.Count; jj++)
      {
        if (current[jj].InnerText.Contains("True"))
        {
          One.TF.KnownTileList_Edelgarzen_4[jj] = true;
        }
        else
        {
          One.TF.KnownTileList_Edelgarzen_4[jj] = false;
        }
      }
    }

    Debug.Log("ExecLoad 9-2");

    //if (forceLoad == false)
    //{
    //  this.systemMessage.text = "ゲームデータの読み込みが完了しました。";
    //  this.back_SystemMessage.SetActive(true);
    //  this.autoKillTimer = 0;
    //  this.nowAutoKill = true;
    //  this.Filter.SetActive(true);
    //}
    Debug.Log("ExecLoad end");
  }


  //// 街でオル・ランディスが外れる、４階最初でヴェルゼが外れる、４階エリア３でラナが外れるのを統合
  //public static void RemoveParty(MainCharacter player, bool initializeBank)
  //{
  //    if (GroundOne.WE.AvailableThirdCharacter)
  //    {
  //        GroundOne.WE.AvailableThirdCharacter = false;
  //        // オルとヴェルゼは再度復帰する予定はないため、ここで一旦ソウルポイントをクリアする。
  //        for (int ii = 0; ii < player.CurrentSoulAttributes.Length; ii++)
  //        {
  //            player.CurrentSoulAttributes[ii] = 0;
  //        }
  //    }
  //    else if (GroundOne.WE.AvailableSecondCharacter)
  //    {
  //        GroundOne.WE.AvailableSecondCharacter = false;
  //        // ラナの場合、再度復帰する予定があるため、ここで一旦ソウルポイントはクリアしない。
  //        //for (int ii = 0; ii < player.CurrentSoulAttributes.Length; ii++)
  //        //{
  //        //    player.CurrentSoulAttributes[ii] = 0;
  //        //}
  //    }

  //    string[] itemBank = new string[Database.MAX_ITEM_BANK];
  //    int[] itemBankStack = new int[Database.MAX_ITEM_BANK];
  //    int current = 0;

  //    if (initializeBank)
  //    {
  //        GroundOne.WE.InitializeItemBankData();
  //    }

  //    string[] beforeItem = new string[Database.MAX_ITEM_BANK];
  //    int[] beforeStack = new int[Database.MAX_ITEM_BANK];
  //    GroundOne.WE.LoadItemBankData(ref beforeItem, ref beforeStack);
  //    for (int ii = 0; ii < beforeItem.Length; ii++)
  //    {
  //        if (beforeItem[ii] == String.Empty || beforeItem[ii] == "" || beforeItem[ii] == null)
  //        {
  //            // 空っぽの場合、何も追加しない。
  //        }
  //        else
  //        {
  //            itemBank[current] = beforeItem[ii];
  //            itemBankStack[current] = beforeStack[ii];
  //            current++;
  //        }
  //    }

  //    if (player.MainWeapon != null)
  //    {
  //        if ((player.MainWeapon.Name != Database.POOR_GOD_FIRE_GLOVE_REPLICA) &&
  //            (player.MainWeapon.Name != Database.RARE_WHITE_SILVER_SWORD_REPLICA) &&
  //            (player.MainWeapon.Name != String.Empty))
  //        {
  //            itemBank[current] = player.MainWeapon.Name;
  //            itemBankStack[current] = 1;
  //            current++;
  //        }
  //    }
  //    if (player.SubWeapon != null)
  //    {
  //        if ((player.SubWeapon.Name != Database.POOR_GOD_FIRE_GLOVE_REPLICA) &&
  //            (player.SubWeapon.Name != Database.RARE_WHITE_SILVER_SWORD_REPLICA) &&
  //            (player.SubWeapon.Name != String.Empty))
  //        {
  //            itemBank[current] = player.SubWeapon.Name;
  //            itemBankStack[current] = 1;
  //            current++;
  //        }
  //    }
  //    if (player.MainArmor != null)
  //    {
  //        if ((player.MainArmor.Name != Database.COMMON_AURA_ARMOR) &&
  //            (player.MainArmor.Name != Database.RARE_BLACK_AERIAL_ARMOR_REPLICA) &&
  //            (player.MainWeapon.Name != String.Empty))
  //        {
  //            itemBank[current] = player.MainArmor.Name;
  //            itemBankStack[current] = 1;
  //            current++;
  //        }
  //    }
  //    if (player.Accessory != null)
  //    {
  //        if ((player.Accessory.Name != Database.COMMON_FATE_RING) &&
  //            (player.Accessory.Name != Database.COMMON_LOYAL_RING) &&
  //            (player.Accessory.Name != Database.RARE_HEAVENLY_SKY_WING_REPLICA) &&
  //            (player.MainWeapon.Name != String.Empty))
  //        {
  //            itemBank[current] = player.Accessory.Name;
  //            itemBankStack[current] = 1;
  //            current++;
  //        }
  //    }
  //    if (player.Accessory2 != null)
  //    {
  //        if ((player.Accessory2.Name != Database.COMMON_FATE_RING) &&
  //            (player.Accessory2.Name != Database.COMMON_LOYAL_RING) &&
  //            (player.Accessory2.Name != Database.RARE_HEAVENLY_SKY_WING_REPLICA) &&
  //            (player.MainWeapon.Name != String.Empty))
  //        {
  //            itemBank[current] = player.Accessory2.Name;
  //            itemBankStack[current] = 1;
  //            current++;
  //        }
  //    }
  //    ItemBackPack[] backpackInfo = player.GetBackPackInfo();
  //    for (int ii = 0; ii < backpackInfo.Length; ii++)
  //    {
  //        if (backpackInfo[ii] != null)
  //        {
  //            if ((backpackInfo[ii].Name != Database.POOR_GOD_FIRE_GLOVE_REPLICA) &&
  //                (backpackInfo[ii].Name != Database.COMMON_AURA_ARMOR) &&
  //                (backpackInfo[ii].Name != Database.COMMON_FATE_RING) &&
  //                (backpackInfo[ii].Name != Database.COMMON_LOYAL_RING) &&
  //                (backpackInfo[ii].Name != Database.RARE_WHITE_SILVER_SWORD_REPLICA) &&
  //                (backpackInfo[ii].Name != Database.RARE_BLACK_AERIAL_ARMOR_REPLICA) &&
  //                (backpackInfo[ii].Name != Database.RARE_HEAVENLY_SKY_WING_REPLICA))
  //            {
  //                itemBank[current] = backpackInfo[ii].Name;
  //                itemBankStack[current] = backpackInfo[ii].StackValue;
  //                current++;
  //            }
  //        }
  //    }
  //    GroundOne.WE.UpdateItemBankData(itemBank, itemBankStack);
  //}
  #endregion

  /// <summary>
  /// 戦闘終了後のアイテムゲット、ファージル宮殿お楽しみ抽選券のアイテムゲットを統合
  /// </summary>
  public static string GetNewItem(Fix.DropItemCategory category, Character mc, Character ec1, int dungeonArea)
  {
    string targetItemName = String.Empty;
    int debugCounter1 = 0;
    int debugCounter2 = 0;
    int debugCounter3 = 0;
    int debugCounter4 = 0;
    int debugCounter5 = 0;
    int debugCounter6 = 0;
    int debugCounter7 = 0;
    int debugCounter8 = 0;
    int debugCounter9 = 0;

    int debugCounter_L = 0;
    int debugCounterE = 0;

    try
    {
      for (int zzz = 0; zzz < 1; zzz++)
      {
        System.Threading.Thread.Sleep(1);

        // ドロップアイテムを出現させる
        System.Random rd = new System.Random(Environment.TickCount * DateTime.Now.Millisecond);
        int param1 = 0; // 素材
        int param2 = 0; // POOR
        int param3 = 0; // COMMON
        int param4 = 0; // UNCOMMON
        int param5 = 0; // RARE
        int param6 = 0; // パラメタUP
        int param7 = 0; // EPIC
        int param8 = 0; // ハズレ

        // param1 は固定でいくこと
        // param2 + param3 + param4+param5 は1000とすること
        // param8はBlack以外は0とすること
        if (ec1 != null)
        {
          switch (ec1.Rare)
          {
            case Fix.RareString.Black:
              param1 = 1000;                     // Material 44.73 %
              param2 = 400;                      //     Poor 22.13 %
              param3 = 300;                      //   Common 13.73 %
              param4 = 200;                      // Uncommon  6.79 %
              param5 = 100;                      //     Rare  2.27 %
              param6 = 20;                       //  PowerUp  0.74 %
              param7 = 10 + One.TF.KillingEnemy; //     Epic  0.49 %  EPICを少し出しやすくする味付け
              param8 = 200;                      //     Lost  9.12 %
              break;
            case Fix.RareString.Blue:
              param1 = 1000;
              param2 = 100;
              param3 = 250;
              param4 = 450;
              param5 = 200;
              param6 = 60;
              param7 = 20 + One.TF.KillingEnemy * 3; // EPICを少し出しやすくする味付け
              param8 = 0;
              break;
            case Fix.RareString.Red:
              param1 = 1000;
              param2 = 0;
              param3 = 100;
              param4 = 300;
              param5 = 600;
              param6 = 120;
              param7 = 40 + One.TF.KillingEnemy * 5; // EPICを少し出しやすくする味付け
              param8 = 0;
              break;
            case Fix.RareString.Gold: // 階層ボスは固定ドロップアイテムだが、通常ボスはランダム扱い
              param1 = 0; // ボスレベルで素材は無い事とする。
              param2 = 0;
              param3 = 0;
              param4 = 600;
              param5 = 1200;
              param6 = 400;
              param7 = 80 + One.TF.KillingEnemy * 5; // EPICを少し出しやすくする味付け
              param8 = 0;
              break;
            case Fix.RareString.Purple: // 支配竜は固定ドロップアイテム
              break;
          }
        }
        else if (category == Fix.DropItemCategory.Lottery)
        {
          param1 = 0; // 抽選券、モンスター素材ではない。
          param2 = 0; // 抽選券、POORは無しとする
          param3 = 400;
          param4 = 240;
          param5 = 200;
          param6 = 100;
          param7 = 7;
          param8 = 0; // 抽選券、ハズレは無しとする
          debugCounter_L++;
        }

        int randomValue = rd.Next(1, param1 + param2 + param3 + param4 + param5 + param6 + param7 + param8 + 1);
        int randomValue2 = rd.Next(1, 1 + param2 + param3 + param4 + param5);

        #region "エリア毎のアイテム総数に応じた値を設定"
        // 1階は上述宣言時の値そのもの
        if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area11) ||
            (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area12) ||
            (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area13) ||
            (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area14) ||
            (category == Fix.DropItemCategory.Lottery && dungeonArea == 1))
        {
        }
        #endregion

        Debug.Log("DropItem: Enemy Area: " + ec1.Area.ToString());

        #region "モンスター毎の素材ドロップ"
        if (1 <= randomValue && randomValue <= param1) // 44.84 %
        {
          int DropItemNumber = 0;
          for (int ii = 0; ii < ec1.DropItem.Length; ii++)
          {
            if (ec1.DropItem[ii] != String.Empty)
            {
              DropItemNumber++;
            }
          }
          if (DropItemNumber <= 0) // 素材登録が無い場合、ハズレ
          {
            targetItemName = String.Empty;
          }
          else
          {
            int randomValue1 = AP.Math.RandomInteger(DropItemNumber);
            targetItemName = ec1.DropItem[randomValue1];
          }

          debugCounter1++;
        }
        #endregion
        #region "ダンジョンエリア毎の汎用装備品"
        else if (param1 < randomValue && randomValue <= (param1 + param2 + param3 + param4 + param5)) // 44.74%
        {
          if (1 <= randomValue2 && randomValue2 <= param2) // Poor 22.75%
          {
            Debug.Log("ItemDrop: category: Poor");
            #region "エスミリア草原区域"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area11) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area12) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area13) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area14) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 1))
            {
              int randomValue21 = rd.Next(1, 14);
              Debug.Log("randomValue21: " + randomValue21);
              switch (randomValue21)
              {
                case 1:
                  targetItemName = Fix.HINJAKU_RING;
                  break;
                case 2:
                  targetItemName = Fix.USUYOGORETA_FEATHER;
                  break;
                case 3:
                  targetItemName = Fix.NON_BRIGHT_ORB;
                  break;
                case 4:
                  targetItemName = Fix.KUKEI_BANGLE;
                  break;
                case 5:
                  targetItemName = Fix.SUTERARESHI_EMBLEM;
                  break;
                case 6:
                  targetItemName = Fix.PRACTICE_SWORD;
                  break;
                case 7:
                  targetItemName = Fix.PRACTICE_LANCE;
                  break;
                case 8:
                  targetItemName = Fix.PRACTICE_AXE;
                  break;
                case 9:
                  targetItemName = Fix.PRACTICE_CLAW;
                  break;
                case 10:
                  targetItemName = Fix.PRACTICE_ROD;
                  break;
                case 11:
                  targetItemName = Fix.PRACTICE_BOOK;
                  break;
                case 12:
                  targetItemName = Fix.PRACTICE_ORB;
                  break;
                case 13:
                  targetItemName = Fix.PRACTICE_SHIELD;
                  break;
              }
            }
            #endregion
            #region "ゴラトラム洞窟"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area21) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area22) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area23) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area24) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 2))
            {
              int randomValue21 = rd.Next(1, 11);
              Debug.Log("randomValue21: " + randomValue21);
              switch (randomValue21)
              {
                case 1:
                  targetItemName = Fix.HUANTEI_RING;
                  break;
                case 2:
                  targetItemName = Fix.DEPRESS_FEATHER;
                  break;
                case 3:
                  targetItemName = Fix.STIFF_BELT;
                  break;
                case 4:
                  targetItemName = Fix.LOST_NAME_EMBLEM;
                  break;
                case 5:
                  targetItemName = Fix.DAMAGED_STATUE;
                  break;
                case 6:
                  targetItemName = Fix.USED_HQ_BOOTS;
                  break;
                case 7:
                  targetItemName = Fix.MAGICLIGHT_FIRE;
                  break;
                case 8:
                  targetItemName = Fix.MAGICLIGHT_ICE;
                  break;
                case 9:
                  targetItemName = Fix.MAGICLIGHT_SHADOW;
                  break;
                case 10:
                  targetItemName = Fix.MAGICLIGHT_LIGHT;
                  break;
              }
            }
            #endregion
            #region "神秘の森"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area31) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area32) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area33) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area34) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 3))
            {
              int randomValue21 = rd.Next(1, 18);
              Debug.Log("randomValue21: " + randomValue21);
              switch (randomValue21)
              {
                case 1:
                  targetItemName = Fix.JUNK_TARISMAN_POISON;
                  break;
                case 2:
                  targetItemName = Fix.JUNK_TARISMAN_SILENCE;
                  break;
                case 3:
                  targetItemName = Fix.JUNK_TARISMAN_BIND;
                  break;
                case 4:
                  targetItemName = Fix.JUNK_TARISMAN_SLEEP;
                  break;
                case 5:
                  targetItemName = Fix.JUNK_TARISMAN_STUN;
                  break;
                case 6:
                  targetItemName = Fix.JUNK_TARISMAN_PARALYZE;
                  break;
                case 7:
                  targetItemName = Fix.JUNK_TARISMAN_FROZEN;
                  break;
                case 8:
                  targetItemName = Fix.JUNK_TARISMAN_FEAR;
                  break;
                case 9:
                  targetItemName = Fix.JUNK_TARISMAN_TEMPTATION;
                  break;
                case 10:
                  targetItemName = Fix.JUNK_TARISMAN_SLOW;
                  break;
                case 11:
                  targetItemName = Fix.JUNK_TARISMAN_DIZZY;
                  break;
                case 12:
                  targetItemName = Fix.JUNK_TARISMAN_SLIP;
                  break;
                case 13:
                  targetItemName = Fix.SIHAIRYU_SIKOTU;
                  break;
                case 14:
                  targetItemName = Fix.OLDGLORY_TREE_KAREHA;
                  break;
                case 15:
                  targetItemName = Fix.GALEWIND_KONSEKI;
                  break;
                case 16:
                  targetItemName = Fix.SIN_CRYSTAL_KAKERA;
                  break;
                case 17:
                  targetItemName = Fix.EVERMIND_ZANSHI;
                  break;
              }
            }
            #endregion
            #region "オーランの塔"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area41) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area42) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area43) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area44) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area45) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 4))
            {
              // POORは存在しないため、ブラックマテリアルにする。
              targetItemName = Fix.POOR_BLACK_MATERIAL4;
            }
            #endregion
            #region "ヴェルガス海底神殿"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area51) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area52) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area53) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area54) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area55) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 5))
            {
              // POORは存在しないため、ブラックマテリアルにする。
              targetItemName = Fix.POOR_BLACK_MATERIAL5;
            }
            #endregion
            #region "エデルガイゼン城"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area61) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area62) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area63) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area64) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area65) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 6))
            {
              // POORは存在しないため、ブラックマテリアルにする。
              targetItemName = Fix.POOR_BLACK_MATERIAL7;
            }
            #endregion
            debugCounter2++;
          }
          // ダンジョンエリア毎のコモン汎用装備品
          else if (param2 < randomValue2 && randomValue2 <= (param2 + param3)) // Common 13.44%
          {
            Debug.Log("ItemDrop: category: Common");
            #region "エスミリア草原区域"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area11) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area12) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area13) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 1))
            {
              int randomValue3 = rd.Next(1, 23);
              Debug.Log("randomValue3: " + randomValue3);
              switch (randomValue3)
              {
                case 1:
                  targetItemName = Fix.ADJUSTABLE_BELT;
                  break;
                case 2:
                  targetItemName = Fix.BIRD_STATUE;
                  break;
                case 3:
                  targetItemName = Fix.SHAPED_FINGERRING;
                  break;
                case 4:
                  targetItemName = Fix.REFRESHED_MANTLE;
                  break;
                case 5:
                  targetItemName = Fix.COOL_CROWN;
                  break;
                case 6:
                  targetItemName = Fix.FLAT_SHOES;
                  break;
                case 7:
                  targetItemName = Fix.COMPACT_EARRING;
                  break;
                case 8:
                  targetItemName = Fix.POWER_BANDANA;
                  break;
                case 9:
                  targetItemName = Fix.CHERRY_CHOKER;
                  break;
                case 10:
                  targetItemName = Fix.FIT_BANGLE;
                  break;
                case 11:
                  targetItemName = Fix.PRISM_EMBLEM;
                  break;
                case 12:
                  targetItemName = Fix.FINE_SWORD;
                  break;
                case 13:
                  targetItemName = Fix.FINE_LANCE;
                  break;
                case 14:
                  targetItemName = Fix.FINE_AXE;
                  break;
                case 15:
                  targetItemName = Fix.FINE_CLAW;
                  break;
                case 16:
                  targetItemName = Fix.FINE_ROD;
                  break;
                case 17:
                  targetItemName = Fix.FINE_BOOK;
                  break;
                case 18:
                  targetItemName = Fix.FINE_ORB;
                  break;
                case 19:
                  targetItemName = Fix.FINE_SHIELD;
                  break;
                case 20:
                  targetItemName = Fix.FINE_ARMOR;
                  break;
                case 21:
                  targetItemName = Fix.FINE_CROSS;
                  break;
                case 22:
                  targetItemName = Fix.FINE_ROBE;
                  break;
              }
            }
            #endregion
            #region "ゴラトラム洞窟"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area21) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area22) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area23) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area24) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 2))
            {
              int randomValue3 = rd.Next(1, 27);
              Debug.Log("randomValue3: " + randomValue3);
              switch (randomValue3)
              {
                case 1:
                  targetItemName = Fix.COPPERRING_TIGER;
                  break;
                case 2:
                  targetItemName = Fix.COPPERRING_DORPHINE;
                  break;
                case 3:
                  targetItemName = Fix.COPPERRING_HORSE;
                  break;
                case 4:
                  targetItemName = Fix.COPPERRING_BEAR;
                  break;
                case 5:
                  targetItemName = Fix.COPPERRING_HAYABUSA;
                  break;
                case 6:
                  targetItemName = Fix.COPPERRING_OCTOPUS;
                  break;
                case 7:
                  targetItemName = Fix.COPPERRING_RABBIT;
                  break;
                case 8:
                  targetItemName = Fix.COPPERRING_SPIDER;
                  break;
                case 9:
                  targetItemName = Fix.COPPERRING_DEER;
                  break;
                case 10:
                  targetItemName = Fix.COPPERRING_ELEPHANT;
                  break;
                case 11:
                  targetItemName = Fix.CLASSICAL_SWORD;
                  break;
                case 12:
                  targetItemName = Fix.CLASSICAL_LANCE;
                  break;
                case 13:
                  targetItemName = Fix.CLASSICAL_AXE;
                  break;
                case 14:
                  targetItemName = Fix.CLASSICAL_CLAW;
                  break;
                case 15:
                  targetItemName = Fix.CLASSICAL_ROD;
                  break;
                case 16:
                  targetItemName = Fix.CLASSICAL_BOOK;
                  break;
                case 17:
                  targetItemName = Fix.CLASSICAL_ORB;
                  break;
                case 18:
                  targetItemName = Fix.CLASSICAL_LARGE_SWORD;
                  break;
                case 19:
                  targetItemName = Fix.CLASSICAL_LARGE_LANCE;
                  break;
                case 20:
                  targetItemName = Fix.CLASSICAL_LARGE_AXE;
                  break;
                case 21:
                  targetItemName = Fix.CLASSICAL_BOW;
                  break;
                case 22:
                  targetItemName = Fix.CLASSICAL_LARGE_STAFF;
                  break;
                case 23:
                  targetItemName = Fix.CLASSICAL_SHIELD;
                  break;
                case 24:
                  targetItemName = Fix.CLASSICAL_ARMOR;
                  break;
                case 25:
                  targetItemName = Fix.CLASSICAL_CROSS;
                  break;
                case 26:
                  targetItemName = Fix.CLASSICAL_ROBE;
                  break;
              }
            }
            #endregion
            #region "神秘の森"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area31) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area32) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area33) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area34) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 3))
            {
              int randomValue3 = rd.Next(1, 27);
              Debug.Log("randomValue3: " + randomValue3);
              switch (randomValue3)
              {
                case 1:
                  targetItemName = Fix.BRONZE_RING_KIBA;
                  break;
                case 2:
                  targetItemName = Fix.BRONZE_RING_SASU;
                  break;
                case 3:
                  targetItemName = Fix.BRONZE_RING_KU;
                  break;
                case 4:
                  targetItemName = Fix.BRONZE_RING_NAGURI;
                  break;
                case 5:
                  targetItemName = Fix.BRONZE_RING_TOBI;
                  break;
                case 6:
                  targetItemName = Fix.BRONZE_RING_KARAMU;
                  break;
                case 7:
                  targetItemName = Fix.BRONZE_RING_HANERU;
                  break;
                case 8:
                  targetItemName = Fix.BRONZE_RING_TORU;
                  break;
                case 9:
                  targetItemName = Fix.BRONZE_RING_MIRU;
                  break;
                case 10:
                  targetItemName = Fix.BRONZE_RING_KATAI;
                  break;
                case 11:
                  targetItemName = Fix.SMART_SWORD;
                  break;
                case 12:
                  targetItemName = Fix.SMART_LANCE;
                  break;
                case 13:
                  targetItemName = Fix.SMART_AXE;
                  break;
                case 14:
                  targetItemName = Fix.SMART_CLAW;
                  break;
                case 15:
                  targetItemName = Fix.SMART_ROD;
                  break;
                case 16:
                  targetItemName = Fix.SMART_BOOK;
                  break;
                case 17:
                  targetItemName = Fix.SMART_ORB;
                  break;
                case 18:
                  targetItemName = Fix.SMART_LARGE_SWORD;
                  break;
                case 19:
                  targetItemName = Fix.SMART_LARGE_LANCE;
                  break;
                case 20:
                  targetItemName = Fix.SMART_LARGE_AXE;
                  break;
                case 21:
                  targetItemName = Fix.SMART_LARGE_SWORD; // Fix.SMART_BOW; 神秘の森で弓はドロップさせない。
                  break;
                case 22:
                  targetItemName = Fix.SMART_LARGE_STAFF;
                  break;
                case 23:
                  targetItemName = Fix.SMART_SHIELD;
                  break;
                case 24:
                  targetItemName = Fix.SMART_ARMOR;
                  break;
                case 25:
                  targetItemName = Fix.SMART_CROSS;
                  break;
                case 26:
                  targetItemName = Fix.SMART_ROBE;
                  break;
              }
            }
            #endregion
            #region "オーランの塔"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area41) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area42) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area43) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area44) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area45) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 4))
            {
              int randomValue3 = rd.Next(1, 27);
              Debug.Log("randomValue3: " + randomValue3);
              switch (randomValue3)
              {
                case 1:
                  targetItemName = Fix.SUPERIOR_SWORD;
                  break;
                case 2:
                  targetItemName = Fix.SUPERIOR_LANCE;
                  break;
                case 3:
                  targetItemName = Fix.SUPERIOR_AXE;
                  break;
                case 4:
                  targetItemName = Fix.SUPERIOR_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.SUPERIOR_ROD;
                  break;
                case 6:
                  targetItemName = Fix.SUPERIOR_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.SUPERIOR_ORB;
                  break;
                case 8:
                  targetItemName = Fix.SUPERIOR_LARGE_SWORD;
                  break;
                case 9:
                  targetItemName = Fix.SUPERIOR_LARGE_LANCE;
                  break;
                case 10:
                  targetItemName = Fix.SUPERIOR_LARGE_AXE;
                  break;
                case 11:
                  targetItemName = Fix.SUPERIOR_BOW;
                  break;
                case 12:
                  targetItemName = Fix.SUPERIOR_LARGE_STAFF;
                  break;
                case 13:
                  targetItemName = Fix.SUPERIOR_SHIELD;
                  break;
                case 14:
                  targetItemName = Fix.SUPERIOR_ARMOR;
                  break;
                case 15:
                  targetItemName = Fix.SUPERIOR_CROSS;
                  break;
                case 16:
                  targetItemName = Fix.SUPERIOR_ROBE;
                  break;
                case 17:
                  targetItemName = Fix.STEEL_RING_POWER;
                  break;
                case 18:
                  targetItemName = Fix.STEEL_RING_SENSE;
                  break;
                case 19:
                  targetItemName = Fix.STEEL_RING_TOUGH;
                  break;
                case 20:
                  targetItemName = Fix.STEEL_RING_ROCK;
                  break;
                case 21:
                  targetItemName = Fix.STEEL_RING_FAST;
                  break;
                case 22:
                  targetItemName = Fix.STEEL_RING_SHARP;
                  break;
                case 23:
                  targetItemName = Fix.STEEL_RING_HIGH;
                  break;
                case 24:
                  targetItemName = Fix.STEEL_RING_DEEP;
                  break;
                case 25:
                  targetItemName = Fix.STEEL_RING_BOUND;
                  break;
                case 26:
                  targetItemName = Fix.STEEL_RING_EMOTE;
                  break;
              }
            }
            #endregion
            #region "ヴェルガス海底神殿"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area51) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area52) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area53) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area54) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area55) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 5))
            {
              int randomValue3 = rd.Next(1, 24);
              Debug.Log("randomValue3: " + randomValue3);
              switch (randomValue3)
              {
                case 1:
                  targetItemName = Fix.MASTER_SWORD;
                  break;
                case 2:
                  targetItemName = Fix.MASTER_LANCE;
                  break;
                case 3:
                  targetItemName = Fix.MASTER_AXE;
                  break;
                case 4:
                  targetItemName = Fix.MASTER_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.MASTER_ROD;
                  break;
                case 6:
                  targetItemName = Fix.MASTER_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.MASTER_ORB;
                  break;
                //case 8:
                //  targetItemName = Fix.MASTER_LARGE_SWORD;
                //  break;
                //case 9:
                //  targetItemName = Fix.MASTER_LARGE_LANCE;
                //  break;
                //case 10:
                //  targetItemName = Fix.MASTER_LARGE_AXE;
                //  break;
                case 8:
                  targetItemName = Fix.MASTER_BOW;
                  break;
                case 9:
                  targetItemName = Fix.MASTER_LARGE_STAFF;
                  break;
                case 10:
                  targetItemName = Fix.MASTER_SHIELD;
                  break;
                case 11:
                  targetItemName = Fix.MASTER_ARMOR;
                  break;
                case 12:
                  targetItemName = Fix.MASTER_CROSS;
                  break;
                case 13:
                  targetItemName = Fix.MASTER_ROBE;
                  break;
                case 14:
                  targetItemName = Fix.SILVER_RING_GOUKA;
                  break;
                case 15:
                  targetItemName = Fix.SILVER_RING_TSUNAMI;
                  break;
                case 16:
                  targetItemName = Fix.SILVER_RING_AKISAME;
                  break;
                case 17:
                  targetItemName = Fix.SILVER_RING_NEPPA;
                  break;
                case 18:
                  targetItemName = Fix.SILVER_RING_RAIMEI;
                  break;
                case 19:
                  targetItemName = Fix.SILVER_RING_FUBUKI;
                  break;
                case 20:
                  targetItemName = Fix.SILVER_RING_GENJITSU;
                  break;
                case 21:
                  targetItemName = Fix.SILVER_RING_TATSUMAKI;
                  break;
                case 22:
                  targetItemName = Fix.SILVER_RING_SYUNIJI;
                  break;
                case 23:
                  targetItemName = Fix.SILVER_RING_KAGEROU;
                  break;
              }
            }
            #endregion
            #region "エデルガイゼン城"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area61) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area62) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area63) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area64) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area65) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 6))
            {
              int randomValue3 = rd.Next(1, 24);
              Debug.Log("randomValue3: " + randomValue3);
              switch (randomValue3)
              {
                case 1:
                  targetItemName = Fix.EXTREME_SWORD;
                  break;
                case 2:
                  targetItemName = Fix.EXTREME_LANCE;
                  break;
                case 3:
                  targetItemName = Fix.EXTREME_AXE;
                  break;
                case 4:
                  targetItemName = Fix.EXTREME_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.EXTREME_ROD;
                  break;
                case 6:
                  targetItemName = Fix.EXTREME_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.EXTREME_ORB;
                  break;
                //case 8:
                //  targetItemName = Fix.EXTREME_LARGE_SWORD;
                //  break;
                //case 9:
                //  targetItemName = Fix.EXTREME_LARGE_LANCE;
                //  break;
                //case 10:
                //  targetItemName = Fix.EXTREME_LARGE_AXE;
                //  break;
                case 8:
                  targetItemName = Fix.EXTREME_BOW;
                  break;
                case 9:
                  targetItemName = Fix.EXTREME_LARGE_STAFF;
                  break;
                case 10:
                  targetItemName = Fix.EXTREME_SHIELD;
                  break;
                case 11:
                  targetItemName = Fix.EXTREME_ARMOR;
                  break;
                case 12:
                  targetItemName = Fix.EXTREME_CROSS;
                  break;
                case 13:
                  targetItemName = Fix.EXTREME_ROBE;
                  break;
                case 14:
                  targetItemName = Fix.PLATINUM_RING_1;
                  break;
                case 15:
                  targetItemName = Fix.PLATINUM_RING_2;
                  break;
                case 16:
                  targetItemName = Fix.PLATINUM_RING_3;
                  break;
                case 17:
                  targetItemName = Fix.PLATINUM_RING_4;
                  break;
                case 18:
                  targetItemName = Fix.PLATINUM_RING_5;
                  break;
                case 19:
                  targetItemName = Fix.PLATINUM_RING_6;
                  break;
                case 20:
                  targetItemName = Fix.PLATINUM_RING_7;
                  break;
                case 21:
                  targetItemName = Fix.PLATINUM_RING_8;
                  break;
                case 22:
                  targetItemName = Fix.PLATINUM_RING_9;
                  break;
                case 23:
                  targetItemName = Fix.PLATINUM_RING_10;
                  break;
              }
            }
            #endregion
            debugCounter3++;
          }
          // ダンジョンエリア毎のアンコモン汎用装備品
          else if ((param2 + param3) < randomValue2 && randomValue2 <= (param2 + param3 + param4)) // Uncommon 6.7%
          {
            Debug.Log("ItemDrop: category: Uncommon");
            #region "エスミリア草原区域"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area11) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area12) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area13) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 1))
            {
              int randomValue4 = rd.Next(1, 17);
              Debug.Log("randomValue4: " + randomValue4);
              switch (randomValue4)
              {
                case 1:
                  targetItemName = Fix.RED_PENDANT;
                  break;
                case 2:
                  targetItemName = Fix.BLUE_PENDANT;
                  break;
                case 3:
                  targetItemName = Fix.PURPLE_PENDANT;
                  break;
                case 4:
                  targetItemName = Fix.GREEN_PENDANT;
                  break;
                case 5:
                  targetItemName = Fix.YELLOW_PENDANT;
                  break;
                case 6:
                  targetItemName = Fix.BRONZE_SWORD;
                  break;
                case 7:
                  targetItemName = Fix.SHARP_LANCE;
                  break;
                case 8:
                  targetItemName = Fix.VIKING_AXE;
                  break;
                case 9:
                  targetItemName = Fix.SURVIVAL_CLAW;
                  break;
                case 10:
                  targetItemName = Fix.WOOD_ROD;
                  break;
                case 11:
                  targetItemName = Fix.KINDNESS_BOOK;
                  break;
                case 12:
                  targetItemName = Fix.ENERGY_ORB;
                  break;
                case 13:
                  targetItemName = Fix.KITE_SHIELD;
                  break;
                case 14:
                  targetItemName = Fix.HEAVY_ARMOR;
                  break;
                case 15:
                  targetItemName = Fix.LEATHER_CROSS;
                  break;
                case 16:
                  targetItemName = Fix.COTTON_ROBE;
                  break;
              }
            }
            #endregion
            #region "ゴラトラム洞窟"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area21) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area22) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area23) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area24) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 2))
            {
              int randomValue4 = rd.Next(1, 22);
              Debug.Log("randomValue4: " + randomValue4);
              switch (randomValue4)
              {
                case 1:
                  targetItemName = Fix.SMASH_BLADE;
                  break;
                case 2:
                  targetItemName = Fix.STYLISH_LANCE;
                  break;
                case 3:
                  targetItemName = Fix.LAND_AXE;
                  break;
                case 4:
                  targetItemName = Fix.SAVAGE_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.WINGED_ROD;
                  break;
                case 6:
                  targetItemName = Fix.EXPERT_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.FLOATING_ORB;
                  break;
                case 8:
                  targetItemName = Fix.ELVISH_BOW;
                  break;
                case 9:
                  targetItemName = Fix.IRON_SHIELD;
                  break;
                case 10:
                  targetItemName = Fix.IRON_ARMOR;
                  break;
                case 11:
                  targetItemName = Fix.CROSSCHAIN_MAIL;
                  break;
                case 12:
                  targetItemName = Fix.CHIFFON_ROBE;
                  break;
                case 13:
                  targetItemName = Fix.RED_AMULET;
                  break;
                case 14:
                  targetItemName = Fix.BLUE_AMULET;
                  break;
                case 15:
                  targetItemName = Fix.PURPLE_AMULET;
                  break;
                case 16:
                  targetItemName = Fix.GREEN_AMULET;
                  break;
                case 17:
                  targetItemName = Fix.YELLOW_AMULET;
                  break;
                case 18:
                  targetItemName = Fix.STEEL_ANKLET;
                  break;
                case 19:
                  targetItemName = Fix.CLEAN_HEARBAND;
                  break;
                case 20:
                  targetItemName = Fix.TRUTH_GLASSES;
                  break;
                case 21:
                  targetItemName = Fix.FIVECOLOR_COMPASS;
                  break;
              }
            }
            #endregion
            #region "神秘の森"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area31) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area32) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area33) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area34) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 3))
            {
              int randomValue4 = rd.Next(1, 23);
              Debug.Log("randomValue4: " + randomValue4);
              switch (randomValue4)
              {
                case 1:
                  targetItemName = Fix.CUTTING_BLADE;
                  break;
                case 2:
                  targetItemName = Fix.SWIFT_SPEAR;
                  break;
                case 3:
                  targetItemName = Fix.POWERED_AXE;
                  break;
                case 4:
                  targetItemName = Fix.DANCING_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.AUTUMN_ROD;
                  break;
                case 6:
                  targetItemName = Fix.BULKY_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.FOCUS_ORB;
                  break;
                case 8:
                  targetItemName = Fix.WIDE_BUCKLER;
                  break;
                case 9:
                  targetItemName = Fix.GOTHIC_PLATE;
                  break;
                case 10:
                  targetItemName = Fix.FITNESS_CROSS;
                  break;
                case 11:
                  targetItemName = Fix.SILK_ROBE;
                  break;
                case 12:
                  targetItemName = Fix.RED_KOKUIN;
                  break;
                case 13:
                  targetItemName = Fix.BLUE_KOKUIN;
                  break;
                case 14:
                  targetItemName = Fix.PURPLE_KOKUIN;
                  break;
                case 15:
                  targetItemName = Fix.GREEN_KOKUIN;
                  break;
                case 16:
                  targetItemName = Fix.YELLOW_KOKUIN;
                  break;
                case 17:
                  targetItemName = Fix.SUNLEAF_SEAL;
                  break;
                case 18:
                  targetItemName = Fix.SPIRIT_TUNOBUE;
                  break;
                case 19:
                  targetItemName = Fix.DEPLETH_SEED_PIERCE;
                  break;
                case 20:
                  targetItemName = Fix.SPARKLINE_EMBLEM;
                  break;
                case 21:
                  targetItemName = Fix.CHAINSHIFT_BOOTS;
                  break;
                case 22:
                  targetItemName = Fix.ASHED_COMPASS;
                  break;
              }
            }
            #endregion
            #region "オーランの塔"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area41) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area42) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area43) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area44) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area45) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 4))
            {
              int randomValue4 = rd.Next(1, 6);
              Debug.Log("randomValue4: " + randomValue4);
              switch (randomValue4)
              {
                case 1:
                  targetItemName = Fix.RED_MASEKI;
                  break;
                case 2:
                  targetItemName = Fix.BLUE_MASEKI;
                  break;
                case 3:
                  targetItemName = Fix.PURPLE_MASEKI;
                  break;
                case 4:
                  targetItemName = Fix.GREEN_MASEKI;
                  break;
                case 5:
                  targetItemName = Fix.YELLOW_MASEKI;
                  break;
              }
            }
            #endregion
            #region "ヴェルガス海底神殿"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area51) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area52) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area53) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area54) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area55) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 5))
            {
              int randomValue4 = rd.Next(1, 6);
              Debug.Log("randomValue4: " + randomValue4);
              switch (randomValue4)
              {
                case 1:
                  targetItemName = Fix.REDLIGHT_BRIGHTSTONE;
                  break;
                case 2:
                  targetItemName = Fix.BLUELIGHT_BRIGHTSTONE;
                  break;
                case 3:
                  targetItemName = Fix.PURPLELIGHT_BRIGHTSTONE;
                  break;
                case 4:
                  targetItemName = Fix.GREENLIGHT_BRIGHTSTONE;
                  break;
                case 5:
                  targetItemName = Fix.YELLOWLIGHT_BRIGHTSTONE;
                  break;
              }
            }
            #endregion
            #region "エデルガイゼン城"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area61) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area62) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area63) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area64) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area65) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 6))
            {
              int randomValue4 = rd.Next(1, 6);
              Debug.Log("randomValue4: " + randomValue4);
              switch (randomValue4)
              {
                case 1:
                  targetItemName = Fix.RED_CRYSTAL;
                  break;
                case 2:
                  targetItemName = Fix.BLUE_CRYSTAL;
                  break;
                case 3:
                  targetItemName = Fix.PURPLE_CRYSTAL;
                  break;
                case 4:
                  targetItemName = Fix.GREEN_CRYSTAL;
                  break;
                case 5:
                  targetItemName = Fix.YELLOW_CRYSTAL;
                  break;
              }
            }
            #endregion
            debugCounter4++;
          }
          // ダンジョンエリア毎のレア汎用装備品
          else if ((param2 + param3 + param4) < randomValue2 && randomValue2 <= (param2 + param3 + param4 + param5)) // Rare 2.49%
          {
            Debug.Log("ItemDrop: category: Rare");
            #region "エスミリア草原区域"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area11) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area12) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area13) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 1))
            {
              int randomValue5 = rd.Next(1, 21);
              Debug.Log("randomValue5: " + randomValue5);
              switch (randomValue5)
              {
                case 1:
                  targetItemName = Fix.RISING_FORCE_CLAW;
                  break;
                case 2:
                  targetItemName = Fix.LIGHTNING_CLAW;
                  break;
                case 3:
                  targetItemName = Fix.SWORD_OF_LIFE;
                  break;
                case 4:
                  targetItemName = Fix.AERO_BLADE;
                  break;
                case 5:
                  targetItemName = Fix.WHITE_PARGE_LANCE;
                  break;
                case 6:
                  targetItemName = Fix.ICE_SPIRIT_LANCE;
                  break;
                case 7:
                  targetItemName = Fix.ICICLE_LONGBOW;
                  break;
                case 8:
                  targetItemName = Fix.MUMYOU_BOW;
                  break;
                case 9:
                  targetItemName = Fix.EARTH_POWER_AXE;
                  break;
                case 10:
                  targetItemName = Fix.WARWOLF_AXE;
                  break;
                case 11:
                  targetItemName = Fix.LIVING_GROWTH_ORB;
                  break;
                case 12:
                  targetItemName = Fix.RED_PILLER_ORB;
                  break;
                case 13:
                  targetItemName = Fix.TOUGH_TREE_ROD;
                  break;
                case 14:
                  targetItemName = Fix.BLACK_SORCERER_ROD;
                  break;
                case 15:
                  targetItemName = Fix.SAINT_FAITHFUL_BOOK;
                  break;
                case 16:
                  targetItemName = Fix.MUIN_BOOK;
                  break;
                case 17:
                  targetItemName = Fix.SUPERIOR_FLAME_SHIELD;
                  break;
                case 18:
                  targetItemName = Fix.FIRE_ANGEL_TALISMAN;
                  break;
                case 19:
                  targetItemName = Fix.BLUE_WIZARD_HAT;
                  break;
                case 20:
                  targetItemName = Fix.FLAME_HAND_KEEPER;
                  break;
              }
            }
            #endregion
            #region "ゴラトラム洞窟"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area21) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area22) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area23) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area24) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 2))
            {
              int randomValue5 = rd.Next(1, 18);
              Debug.Log("randomValue5: " + randomValue5);
              switch (randomValue5)
              {
                case 1:
                  targetItemName = Fix.BLUE_LIGHTNING_SWORD;
                  break;
                case 2:
                  targetItemName = Fix.ASH_EXCLUDE_LANCE;
                  break;
                case 3:
                  targetItemName = Fix.BONE_CRUSH_AXE;
                  break;
                case 4:
                  targetItemName = Fix.COLD_SPLASH_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.SEKISOUJU_ROD;
                  break;
                case 6:
                  targetItemName = Fix.GORGON_EYES_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.STAR_FUSION_ORB;
                  break;
                case 8:
                  targetItemName = Fix.MADAN_SHOOTING_STAR;
                  break;
                case 9:
                  targetItemName = Fix.SILVER_EARTH_SHIELD;
                  break;
                case 10:
                  targetItemName = Fix.ROIZ_IMPERIAL_ARMOR;
                  break;
                case 11:
                  targetItemName = Fix.SWIFT_THUNDER_CROSS;
                  break;
                case 12:
                  targetItemName = Fix.CROWD_DIRGE_ROBE;
                  break;
                case 13:
                  targetItemName = Fix.ZEPHYR_FEATHER_BLUE;
                  break;
                case 14:
                  targetItemName = Fix.CRIMSON_GAUNTLET;
                  break;
                case 15:
                  targetItemName = Fix.BURIED_DANZAIANGEL_STATUE;
                  break;
                case 16:
                  targetItemName = Fix.LIGHT_HAKURUANGEL_STATUE;
                  break;
                case 17:
                  targetItemName = Fix.JADE_NOBLE_CIRCLET;
                  break;
              }
            }
            #endregion
            #region "神秘の森"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area31) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area32) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area33) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area34) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 3))
            {
              int randomValue5 = rd.Next(1, 23);
              Debug.Log("randomValue5: " + randomValue5);
              switch (randomValue5)
              {
                case 1:
                  targetItemName = Fix.ENSHOUTOU;
                  break;
                case 2:
                  targetItemName = Fix.GALLANT_FEATHER_LANCE;
                  break;
                case 3:
                  targetItemName = Fix.THUNDER_BREAK_AXE;
                  break;
                case 4:
                  targetItemName = Fix.WRATH_SABEL_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.DORN_NAMELESS_ROD;
                  break;
                case 6:
                  targetItemName = Fix.FINESSE_IMPERIAL_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.INTRINSIC_FROZEN_ORB;
                  break;
                case 8:
                  targetItemName = Fix.FORCEFUL_BASTARD_SWORD;
                  break;
                case 9:
                  targetItemName = Fix.SHARPNEL_ARC_LANCER;
                  break;
                case 10:
                  targetItemName = Fix.OGRE_KILL_BUSTER;
                  break;
                case 11:
                  targetItemName = Fix.SHARPNEL_ARC_LANCER; // Fix.EXPLODING_ASH_BOW; 神秘の森で弓はドロップさせない。
                  break;
                case 12:
                  targetItemName = Fix.EARTH_POWERED_STAFF;
                  break;
                case 13:
                  targetItemName = Fix.BLACK_REFLECTOR_SHIELD;
                  break;
                case 14:
                  targetItemName = Fix.ARANDEL_FORCE_ARMOR;
                  break;
                case 15:
                  targetItemName = Fix.WONDERING_BLESSED_CROSS;
                  break;
                case 16:
                  targetItemName = Fix.SERANA_BRILLIANT_ROBE;
                  break;
                case 17:
                  targetItemName = Fix.ENSEMBLE_FEATHER_HUT;
                  break;
                case 18:
                  targetItemName = Fix.MIRAGE_PLASMA_EARRING;
                  break;
                case 19:
                  targetItemName = Fix.PHOTON_ZEAL_CROWN;
                  break;
                case 20:
                  targetItemName = Fix.DEMONS_STAR_BRACELET;
                  break;
                case 21:
                  targetItemName = Fix.MIST_WAVE_GAUNTLET;
                  break;
                case 22:
                  targetItemName = Fix.SPIRIT_CHALICE_OF_HEART;
                  break;
                //case 23:
                //  targetItemName = Fix.SQUARE_SINNEN;
                //  break;
                //case 24:
                //  targetItemName = Fix.SQUARE_BLESTAR;
                //  break;
                //case 25:
                //  targetItemName = Fix.SQUARE_CHISEI;
                //  break;
                //case 26:
                //  targetItemName = Fix.SQUARE_SENREN;
                //  break;
                //case 27:
                //  targetItemName = Fix.SQUARE_SAIKI;
                //  break;
                //case 28:
                //  targetItemName = Fix.SQUARE_TANREN;
                //  break;
                //case 29:
                //  targetItemName = Fix.SQUARE_KOKOH;
                //  break;                     
              }
            }
            #endregion
            #region "オーランの塔"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area41) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area42) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area43) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area44) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area45) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 4))
            {
              int randomValue5 = rd.Next(1, 25);
              Debug.Log("randomValue5: " + randomValue5);
              switch (randomValue5)
              {
                case 1:
                  targetItemName = Fix.FULLMETAL_ASTRAL_BLADE;
                  break;
                case 2:
                  targetItemName = Fix.STORM_FURY_LANCER;
                  break;
                case 3:
                  targetItemName = Fix.WARLOAD_BASTARD_AXE;
                  break;
                case 4:
                  targetItemName = Fix.EARTH_SHARD_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.ENGAGED_FUTURE_ROD;
                  break;
                case 6:
                  targetItemName = Fix.ANCIENT_FAITHFUL_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.BLUE_SKY_ORB;
                  break;
                case 8:
                  targetItemName = Fix.PRISMATIC_SOUL_BREAKER;
                  break;
                case 9:
                  targetItemName = Fix.BLOOD_STUBBORN_SPEAR;
                  break;
                case 10:
                  targetItemName = Fix.ELEMENTAL_DISRUPT_AXE;
                  break;
                case 11:
                  targetItemName = Fix.LINGERING_FROST_SHOOTER;
                  break;
                case 12:
                  targetItemName = Fix.INFERNAL_IMMORTAL_STAFF;
                  break;
                case 13:
                  targetItemName = Fix.GRACEFUL_KINGS_BUCKLER;
                  break;
                case 14:
                  targetItemName = Fix.HARDED_INTENSITY_PLATE;
                  break;
                case 15:
                  targetItemName = Fix.SOLDIER_HATRED_CROSS;
                  break;
                case 16:
                  targetItemName = Fix.WONDERERS_INVISIBLE_ROBE;
                  break;
                // 武具屋限定、ドロップ対象外
                //case 17:
                //  targetItemName = Fix.ZELMAN_THE_ONSLAUGHT_BASTER;
                //  break;
                //case 18:
                //  targetItemName = Fix.LIFEGRACE_FORTUNE_STAFF;
                //  break;
                //case 19:
                //  targetItemName = Fix.WHITEVEIL_QUEENS_ROBE;
                //  break;
                //case 20:
                //  targetItemName = Fix.KODAIEIJU_GREEN_LEAF;
                //  break;
                case 17:
                  targetItemName = Fix.POWER_STEEL_RING_SOLID;
                  break;
                case 18:
                  targetItemName = Fix.POWER_STEEL_RING_VAPOUR;
                  break;
                case 19:
                  targetItemName = Fix.POWER_STEEL_RING_STRAIN;
                  break;
                case 20:
                  targetItemName = Fix.POWER_STEEL_RING_TOLERANCE;
                  break;
                case 21:
                  targetItemName = Fix.POWER_STEEL_RING_ASCEND;
                  break;
                case 22:
                  targetItemName = Fix.POWER_STEEL_RING_INTERCEPT;
                  break;
                case 23:
                  targetItemName = Fix.STARAIR_FLOATING_STONE;
                  break;
                case 24:
                  targetItemName = Fix.LIGHTBRIGHT_FLOATING_STONE;
                  break;
                // 武具屋限定、ドロップ対象外
                //case 25:
                //  targetItemName = Fix.LUMINOUS_REFLECT_MIRROR;
                //  break;
                //case 26:
                //  targetItemName = Fix.BLACK_SPIRAL_NEEDLE;
                //  break;
                //case 27:
                //  targetItemName = Fix.EMBLEM_OF_VALKYRIE;
                //  break;
                //case 28:
                //  targetItemName = Fix.EMBLEM_OF_NECROMANCY;
                //  break;
              }
            }
            #endregion
            #region "ヴェルガス海底神殿"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area51) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area52) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area53) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area54) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area55) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 5))
            {
              int randomValue5 = rd.Next(1, 25);
              Debug.Log("randomValue5: " + randomValue5);
              switch (randomValue5)
              {
                case 1:
                  targetItemName = Fix.SOLEMN_EMPERORS_SWORD;
                  break;
                case 2:
                  targetItemName = Fix.MYSTIC_BLUE_JAVELIN;
                  break;
                case 3:
                  targetItemName = Fix.STRONG_FIRE_HELL_BASTARDAXE;
                  break;
                case 4:
                  targetItemName = Fix.AURA_BURN_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.MIND_STONEFEAR_ROD;
                  break;
                case 6:
                  targetItemName = Fix.DARKSUN_TRAGEDIC_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.CHROMATIC_FORGE_ORB;
                  break;
                case 8:
                  targetItemName = Fix.GOLDWILL_DESCENT_SOWRD;
                  break;
                case 9:
                  targetItemName = Fix.FLASH_VANISH_SPEAR;
                  break;
                case 10:
                  targetItemName = Fix.VOLCANIC_BATTLE_BASTER;
                  break;
                case 11:
                  targetItemName = Fix.WHITE_FIRE_CROSSBOW;
                  break;
                case 12:
                  targetItemName = Fix.ELDERSTAFF_OF_LIFEBLOOM;
                  break;
                case 13:
                  targetItemName = Fix.DIMENSION_ZERO_SHIELD;
                  break;
                case 14:
                  targetItemName = Fix.HIGHWARRIOR_DRAGONMAIL;
                  break;
                case 15:
                  targetItemName = Fix.SWIFTCROSS_OF_REDTHUNDER;
                  break;
                case 16:
                  targetItemName = Fix.BLADESHADOW_CROWDED_DRESS;
                  break;
                // 武具屋限定、ドロップ対象外
                //case 17:
                //  targetItemName = Fix.BLACKROGUE_BLACKROGUE_AMBIDEXTARITY_DAGGER;
                //  break;
                //case 18:
                //  targetItemName = Fix.HOLY_BLESSING_SHIELD;
                //  break;
                //case 19:
                //  targetItemName = Fix.LATA_GUARDIAN_RING;
                //  break;
                //case 20:
                //  targetItemName = Fix.BLUEEYE_TEMPLE_PENDANT;
                //  break;
                //case 21:
                //  targetItemName = Fix.REDEYE_TEMPLE_PENDANT;
                //  break;
                case 17:
                  targetItemName = Fix.SEAL_OF_REDEYE;
                  break;
                case 18:
                  targetItemName = Fix.SEAL_OF_BLUEEYE;
                  break;
                case 19:
                  targetItemName = Fix.WINGED_LIGHTNING_BOOTS;
                  break;
                case 20:
                  targetItemName = Fix.SPELLCASTERS_LENS;
                  break;
                case 21:
                  targetItemName = Fix.PEACEFUL_REBIRTH_CANDLE;
                  break;
                case 22:
                  targetItemName = Fix.DESPAIR_BLACKANGEL_RING;
                  break;
                case 23:
                  targetItemName = Fix.PHANTASMAL_INSIGHT_RUNE;
                  break;
                case 24:
                  targetItemName = Fix.SILVER_ETERNAL_SEED;
                  break;
                // 武具屋限定、ドロップ対象外
                //case 25:
                //  targetItemName = Fix.FIRELIEGE_AETHER_TALISMAN;
                //  break;
                //case 26:
                //  targetItemName = Fix.RAINBOW_MOON_COMPASS;
                //  break;
                //case 27:
                //  targetItemName = Fix.ANGEL_CONTRACT_SHEET;
                //  break;
              }
            }
            #endregion
            #region "エデルガイゼン城"
            if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area61) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area62) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area63) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area64) ||
                (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area65) ||
                (category == Fix.DropItemCategory.Lottery && dungeonArea == 6))
            {
              int randomValue5 = rd.Next(1, 20);
              Debug.Log("randomValue5: " + randomValue5);
              switch (randomValue5)
              {
                case 1:
                  targetItemName = Fix.ETHEREAL_EDGE_BLADE;
                  break;
                case 2:
                  targetItemName = Fix.EVIL_ELIMINATION_LANCE;
                  break;
                case 3:
                  targetItemName = Fix.PRISON_DESTRUCTION_AXE;
                  break;
                case 4:
                  targetItemName = Fix.SHINGETSUEN_CLAW;
                  break;
                case 5:
                  targetItemName = Fix.GARGAN_BLAZE_ROD;
                  break;
                case 6:
                  targetItemName = Fix.JUNKEI_SHIKI_BOOK;
                  break;
                case 7:
                  targetItemName = Fix.ALL_ELEMENTAL_ORB;
                  break;
                case 8:
                  targetItemName = Fix.SYOKO_PALESTRIDE_BOW;
                  break;
                case 9:
                  targetItemName = Fix.LABYRINTH_MAGE_BLUESTAFF;
                  break;
                case 10:
                  targetItemName = Fix.MAJESTIC_FORCE_SHIELD;
                  break;
                case 11:
                  targetItemName = Fix.BLACK_DRAGON_FEATHER;
                  break;
                case 12:
                  targetItemName = Fix.RAGING_RESONANCE_RING;
                  break;
                case 13:
                  targetItemName = Fix.LAGINA_DISTORTED_BRACER;
                  break;
                case 14:
                  targetItemName = Fix.RIGID_WAVE_METALGUNTLET;
                  break;
                case 15:
                  targetItemName = Fix.ISOCHRON_FATED_LENS;
                  break;
                case 16:
                  targetItemName = Fix.DARKNESS_COIN;
                  break;
                case 17:
                  targetItemName = Fix.HEART_SEEKERS_STONE;
                  break;
                case 18:
                  targetItemName = Fix.SUN_BREAKERS_STONE;
                  break;
                case 19:
                  targetItemName = Fix.DANZAI_ANGEL_TALISMAN;
                  break;
              }
            }
            #endregion
            debugCounter5++;
          }
          else
          {
            debugCounterE++;
          }
        }
        #endregion
        #region "ダンジョン階層依存のパワーアップアイテム"
        else if ((param1 + param2 + param3 + param4 + param5) < randomValue && randomValue <= (param1 + param2 + param3 + param4 + param5 + param6)) // Rare Use Item 0.90%
        {
          #region "エスミリア草原区域"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area11) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area12) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area13) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area14) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 1))
          {
            int randomValue6 = rd.Next(1, 6);
            Debug.Log("randomValue6: " + randomValue6);
            switch (randomValue6)
            {
              case 1:
                targetItemName = Fix.GROWTH_LIQUID_STRENGTH;
                break;
              case 2:
                targetItemName = Fix.GROWTH_LIQUID_AGILITY;
                break;
              case 3:
                targetItemName = Fix.GROWTH_LIQUID_INTELLIGENCE;
                break;
              case 4:
                targetItemName = Fix.GROWTH_LIQUID_STAMINA;
                break;
              case 5:
                targetItemName = Fix.GROWTH_LIQUID_MIND;
                break;
            }
          }
          #endregion
          #region "ゴラトラム洞窟"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area21) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area22) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area23) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area24) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 2))
          {
            int randomValue6 = rd.Next(1, 6);
            Debug.Log("randomValue6: " + randomValue6);
            switch (randomValue6)
            {
              case 1:
                targetItemName = Fix.GROWTH_LIQUID2_STRENGTH;
                break;
              case 2:
                targetItemName = Fix.GROWTH_LIQUID2_AGILITY;
                break;
              case 3:
                targetItemName = Fix.GROWTH_LIQUID2_INTELLIGENCE;
                break;
              case 4:
                targetItemName = Fix.GROWTH_LIQUID2_STAMINA;
                break;
              case 5:
                targetItemName = Fix.GROWTH_LIQUID2_MIND;
                break;
            }
          }
          #endregion
          #region "神秘の森"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area31) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area32) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area33) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area34) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 3))
          {
            int randomValue6 = rd.Next(1, 6);
            Debug.Log("randomValue6: " + randomValue6);
            switch (randomValue6)
            {
              case 1:
                targetItemName = Fix.GROWTH_LIQUID3_STRENGTH;
                break;
              case 2:
                targetItemName = Fix.GROWTH_LIQUID3_AGILITY;
                break;
              case 3:
                targetItemName = Fix.GROWTH_LIQUID3_INTELLIGENCE;
                break;
              case 4:
                targetItemName = Fix.GROWTH_LIQUID3_STAMINA;
                break;
              case 5:
                targetItemName = Fix.GROWTH_LIQUID3_MIND;
                break;
            }
          }
          #endregion
          #region "オーランの塔"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area41) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area42) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area43) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area44) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area45) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 4))
          {
            int randomValue6 = rd.Next(1, 6);
            Debug.Log("randomValue6: " + randomValue6);
            switch (randomValue6)
            {
              case 1:
                targetItemName = Fix.GROWTH_LIQUID4_STRENGTH;
                break;
              case 2:
                targetItemName = Fix.GROWTH_LIQUID4_AGILITY;
                break;
              case 3:
                targetItemName = Fix.GROWTH_LIQUID4_INTELLIGENCE;
                break;
              case 4:
                targetItemName = Fix.GROWTH_LIQUID4_STAMINA;
                break;
              case 5:
                targetItemName = Fix.GROWTH_LIQUID4_MIND;
                break;
            }
          }
          #endregion
          #region "ヴェルガス海底神殿"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area51) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area52) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area53) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area54) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area55) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 5))
          {
            int randomValue6 = rd.Next(1, 6);
            Debug.Log("randomValue6: " + randomValue6);
            switch (randomValue6)
            {
              case 1:
                targetItemName = Fix.GROWTH_LIQUID5_STRENGTH;
                break;
              case 2:
                targetItemName = Fix.GROWTH_LIQUID5_AGILITY;
                break;
              case 3:
                targetItemName = Fix.GROWTH_LIQUID5_INTELLIGENCE;
                break;
              case 4:
                targetItemName = Fix.GROWTH_LIQUID5_STAMINA;
                break;
              case 5:
                targetItemName = Fix.GROWTH_LIQUID5_MIND;
                break;
            }
          }
          #endregion
          #region "エデルガイゼン城"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area61) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area62) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area63) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area64) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area65) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 6))
          {
            int randomValue6 = rd.Next(1, 6);
            Debug.Log("randomValue6: " + randomValue6);
            switch (randomValue6)
            {
              case 1:
                targetItemName = Fix.GROWTH_LIQUID6_STRENGTH;
                break;
              case 2:
                targetItemName = Fix.GROWTH_LIQUID6_AGILITY;
                break;
              case 3:
                targetItemName = Fix.GROWTH_LIQUID6_INTELLIGENCE;
                break;
              case 4:
                targetItemName = Fix.GROWTH_LIQUID6_STAMINA;
                break;
              case 5:
                targetItemName = Fix.GROWTH_LIQUID6_MIND;
                break;
            }
          }
          #endregion
          debugCounter6++;
        }
        #endregion
        #region "ダンジョン階層依存の高級装備品"
        else if ((param1 + param2 + param3 + param4 + param5 + param6) < randomValue && randomValue <= (param1 + param2 + param3 + param4 + param5 + param6 + param7)) // EPIC 0.31%
        {
          #region "エスミリア草原区域"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area11) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area12) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area13) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area14) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 1))
          {
            // 低レベルの間に取得できてしまうのは、逆に拍子抜けしてしまうため、ブロックする。
            if (mc.Level <= 10)
            {
              int randomValue7_1 = rd.Next(1, 6);
              Debug.Log("randomValue7_1: " + randomValue7_1);
              switch (randomValue7_1)
              {
                case 1:
                  targetItemName = Fix.GROWTH_LIQUID_STRENGTH;
                  break;
                case 2:
                  targetItemName = Fix.GROWTH_LIQUID_AGILITY;
                  break;
                case 3:
                  targetItemName = Fix.GROWTH_LIQUID_INTELLIGENCE;
                  break;
                case 4:
                  targetItemName = Fix.GROWTH_LIQUID_STAMINA;
                  break;
                case 5:
                  targetItemName = Fix.GROWTH_LIQUID_MIND;
                  break;
              }
            }
            else
            {
              int randomValue7_2 = rd.Next(1, 3);
              Debug.Log("randomValue7_2: " + randomValue7_2);
              switch (randomValue7_2)
              {
                case 1:
                  targetItemName = Fix.RING_OF_OSCURETE;
                  break;
                case 2:
                  targetItemName = Fix.MERGIZD_SOL_BLADE;
                  break;
              }
              One.TF.KillingEnemy = 0; // EPIC出現後、ボーナス値をリセットしておく。
            }
          }
          #endregion
          #region "ゴラトラム洞窟"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area21) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area22) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area23) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area24) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 2))
          {
            // 低レベルの間に取得できてしまうのは、逆に拍子抜けしてしまうため、ブロックする。
            if (mc.Level <= 20)
            {
              int randomValue7_1 = rd.Next(1, 6);
              Debug.Log("randomValue7_1: " + randomValue7_1);
              switch (randomValue7_1)
              {
                case 1:
                  targetItemName = Fix.GROWTH_LIQUID2_STRENGTH;
                  break;
                case 2:
                  targetItemName = Fix.GROWTH_LIQUID2_AGILITY;
                  break;
                case 3:
                  targetItemName = Fix.GROWTH_LIQUID2_INTELLIGENCE;
                  break;
                case 4:
                  targetItemName = Fix.GROWTH_LIQUID2_STAMINA;
                  break;
                case 5:
                  targetItemName = Fix.GROWTH_LIQUID2_MIND;
                  break;
              }
            }
            else
            {
              int randomValue7_2 = rd.Next(1, 3);
              Debug.Log("randomValue7_2: " + randomValue7_2);
              switch (randomValue7_2)
              {
                case 1:
                  targetItemName = Fix.ADILORB_OF_THE_GARVANDI;
                  break;
                case 2:
                  targetItemName = Fix.MAXCARN_X_BUSTER;
                  break;
              }
              One.TF.KillingEnemy = 0; // EPIC出現後、ボーナス値をリセットしておく。
            }
          }
          #endregion
          #region "神秘の森"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area31) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area32) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area33) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area34) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 3))
          {
            // 低レベルの間に取得できてしまうのは、逆に拍子抜けしてしまうため、ブロックする。
            if (mc.Level <= 30)
            {
              int randomValue7_1 = rd.Next(1, 6);
              Debug.Log("randomValue7_1: " + randomValue7_1);
              switch (randomValue7_1)
              {
                case 1:
                  targetItemName = Fix.GROWTH_LIQUID3_STRENGTH;
                  break;
                case 2:
                  targetItemName = Fix.GROWTH_LIQUID3_AGILITY;
                  break;
                case 3:
                  targetItemName = Fix.GROWTH_LIQUID3_INTELLIGENCE;
                  break;
                case 4:
                  targetItemName = Fix.GROWTH_LIQUID3_STAMINA;
                  break;
                case 5:
                  targetItemName = Fix.GROWTH_LIQUID3_MIND;
                  break;
              }
            }
            else
            {
              int randomValue7_2 = rd.Next(1, 3);
              Debug.Log("randomValue7_2: " + randomValue7_2);
              switch (randomValue7_2)
              {
                case 1:
                  targetItemName = Fix.VIRGIRANTE_HELLGATE_LANCE;
                  break;
                case 2:
                  targetItemName = Fix.MULLERHAIZEN_AGARTA_BOOK;
                  break;
              }
              One.TF.KillingEnemy = 0; // EPIC出現後、ボーナス値をリセットしておく。
            }
          }
          #endregion
          #region "オーランの塔"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area41) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area42) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area43) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area44) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area45) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 4))
          {
            // レベル制限なし
            int randomValue7_2 = rd.Next(1, 3);
            Debug.Log("randomValue7_2: " + randomValue7_2);
            switch (randomValue7_2)
            {
              case 1:
                targetItemName = Fix.GATUH_HAWL_OF_GREAT;
                break;
              case 2:
                targetItemName = Fix.JUZA_ARESTINE_SLICER;
                break;
            }
            One.TF.KillingEnemy = 0; // EPIC出現後、ボーナス値をリセットしておく。
          }
          #endregion
          #region "ヴェルガス海底神殿"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area51) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area52) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area53) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area54) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area55) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 5))
          {
            // レベル制限なし
            int randomValue7_2 = rd.Next(1, 4);
            Debug.Log("randomValue7_2: " + randomValue7_2);
            switch (randomValue7_2)
            {
              case 1:
                targetItemName = Fix.ADILRING_OF_BLUE_BURN;
                break;
              case 2:
                targetItemName = Fix.SHEZL_MYSTIC_FORTUNE;
                break;
              case 3:
                targetItemName = Fix.FLOW_FUNNEL_OF_THE_ZVELDOZE;
                break;
            }
            One.TF.KillingEnemy = 0; // EPIC出現後、ボーナス値をリセットしておく。
          }
          #endregion
          #region "エデルガイゼン城"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area61) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area62) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area63) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area64) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area65) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 6))
          {
            // レベル制限なし
            int randomValue7_2 = rd.Next(1, 5);
            Debug.Log("randomValue7_2: " + randomValue7_2);
            switch (randomValue7_2)
            {
              case 1:
                targetItemName = Fix.EZEKRIEL_IMPRINT_SIGIL_ARMOR;
                break;
              case 2:
                targetItemName = Fix.MERGIZD_DAV_AGITATED_BLADE;
                break;
              case 3:
                targetItemName = Fix.SHEZL_THE_VENTIEL_DARKMIRAGE_BOOK;
                break;
              case 4:
                targetItemName = Fix.XEXXER_WORLD_MASTERY_GLOBE;
                break;
            }
            One.TF.KillingEnemy = 0; // EPIC出現後、ボーナス値をリセットしておく。
          }
          #endregion
          debugCounter7++;
        }
        #endregion
        #region "ハズレ"
        else if ((param1 + param2 + param3 + param4 + param5 + param6 + param7) < randomValue && randomValue <= (param1 + param2 + param3 + param4 + param5 + param6 + param7 + param8)) // ハズレ 8.7 %
        {
          Debug.Log("ItemDrop: category: Hazure");
          targetItemName = String.Empty;
          debugCounter8++;
        }
        else // 万が一規定外の値はハズレ 0.0%
        {
          targetItemName = String.Empty;
          debugCounter9++;
        }
        #endregion

        #region "ハズレは、不用品をランダムドロップ"
        if (targetItemName == string.Empty)
        {
          #region "エスミリア草原区域"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area11) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area12) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area13) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area14) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 1))
          {
            int randomValue8 = rd.Next(1, 101);
            Debug.Log("randomValue8: " + randomValue8);
            if (1 <= randomValue8 && randomValue8 <= 50)
            {
              targetItemName = Fix.POOR_BLACK_MATERIAL;
            }
          }
          #endregion
          #region "ゴラトラム洞窟"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area21) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area22) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area23) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area24) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 2))
          {
            int randomValue8 = rd.Next(1, 101);
            Debug.Log("randomValue8: " + randomValue8);
            if (1 <= randomValue8 && randomValue8 <= 50)
            {
              targetItemName = Fix.POOR_BLACK_MATERIAL2;
            }
          }
          #endregion
          #region "神秘の森"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area31) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area32) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area33) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area34) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 3))
          {
            int randomValue8 = rd.Next(1, 101);
            Debug.Log("randomValue8: " + randomValue8);
            if (1 <= randomValue8 && randomValue8 <= 50)
            {
              targetItemName = Fix.POOR_BLACK_MATERIAL3;
            }
          }
          #endregion
          #region "オーランの塔"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area41) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area42) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area43) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area44) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area45) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 4))
          {
            int randomValue8 = rd.Next(1, 101);
            Debug.Log("randomValue8: " + randomValue8);
            if (1 <= randomValue8 && randomValue8 <= 50)
            {
              targetItemName = Fix.POOR_BLACK_MATERIAL4;
            }
          }
          #endregion
          #region "ヴェルガス海底神殿"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area51) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area52) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area53) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area54) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area55) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 5))
          {
            int randomValue8 = rd.Next(1, 101);
            Debug.Log("randomValue8: " + randomValue8);
            if (1 <= randomValue8 && randomValue8 <= 50)
            {
              targetItemName = Fix.POOR_BLACK_MATERIAL5;
            }
          }
          #endregion
          #region "エデルガイゼン城"
          if ((category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area61) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area62) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area63) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area64) ||
              (category == Fix.DropItemCategory.Battle && ec1 != null && ec1.Area == Fix.MonsterArea.Area65) ||
              (category == Fix.DropItemCategory.Lottery && dungeonArea == 6))
          {
            int randomValue8 = rd.Next(1, 101);
            Debug.Log("randomValue8: " + randomValue8);
            if (1 <= randomValue8 && randomValue8 <= 50)
            {
              targetItemName = Fix.POOR_BLACK_MATERIAL6;
            }
          }
          #endregion
        }
        #endregion
      }

      Debug.Log("1:Material  " + String.Format("{0, 4}", debugCounter1) + " (" + Convert.ToString((double)(((double)debugCounter1 / 10000.0f) * 100.0f)) + " %)\r\n" +
                "2:Poor      " + String.Format("{0, 4}", debugCounter2) + " (" + Convert.ToString((double)(((double)debugCounter2 / 10000.0f) * 100.0f)) + " %)\r\n" +
                "3:Common    " + String.Format("{0, 4}", debugCounter3) + " (" + Convert.ToString((double)(((double)debugCounter3 / 10000.0f) * 100.0f)) + " %)\r\n" +
                "4:Uncommon  " + String.Format("{0, 4}", debugCounter4) + " (" + Convert.ToString((double)(((double)debugCounter4 / 10000.0f) * 100.0f)) + " %)\r\n" +
                "5:Rare      " + String.Format("{0, 4}", debugCounter5) + " (" + Convert.ToString((double)(((double)debugCounter5 / 10000.0f) * 100.0f)) + " %)\r\n" +
                "6:PowerUp   " + String.Format("{0, 4}", debugCounter6) + " (" + Convert.ToString((double)(((double)debugCounter6 / 10000.0f) * 100.0f)) + " %)\r\n" +
                "7:Epic      " + String.Format("{0, 4}", debugCounter7) + " (" + Convert.ToString((double)(((double)debugCounter7 / 10000.0f) * 100.0f)) + " %)\r\n" +
                "8:Lose      " + String.Format("{0, 4}", debugCounter8) + " (" + Convert.ToString((double)(((double)debugCounter8 / 10000.0f) * 100.0f)) + " %)\r\n" +
                "9:Unknown   " + String.Format("{0, 4}", debugCounter9) + " (" + Convert.ToString((double)(((double)debugCounter9 / 10000.0f) * 100.0f)) + " %)\r\n" +
                "E: " + String.Format("{0, 4}", debugCounterE) + " (" + Convert.ToString((double)(((double)debugCounterE / 10000.0f) * 100.0f)) + " %)\r\n" +
                "Total: " + (debugCounter1 + debugCounter2 + debugCounter3 + debugCounter4 + debugCounter5 + debugCounter6 + debugCounter7 + debugCounter8 + debugCounter9 + debugCounterE).ToString() + "\r\n" +
                "L: " + debugCounter_L.ToString() + "\r\n");

      #region "ボス撃破、固定ドロップアイテム"
      if (category == Fix.DropItemCategory.Battle && ec1 != null && (ec1.FullName == Fix.FLANSIS_OF_THE_FOREST_QUEEN || ec1.FullName == Fix.FLANSIS_OF_THE_FOREST_QUEEN_JP))
      {
        targetItemName = ec1.DropItem[0];
      }
      #endregion

    }
    catch (Exception ex)
    {
      Debug.Log("Exception: " + MethodBase.GetCurrentMethod() + " " + ex.ToString());
      targetItemName = String.Empty;
    }

    return targetItemName;
  }

  public static void UpdateAkashicRecord()
  {
    XmlTextWriter xmlWriter2 = new XmlTextWriter(PathForRootFile(Fix.AR_FILE), Encoding.UTF8);
    try
    {
      xmlWriter2.WriteStartDocument();
      xmlWriter2.WriteWhitespace("\r\n");

      xmlWriter2.WriteStartElement("Body");
      xmlWriter2.WriteElementString("DateTime", DateTime.Now.ToString());
      xmlWriter2.WriteWhitespace("\r\n");

      // アカシックレコード
      xmlWriter2.WriteStartElement("AkashicRecord");
      xmlWriter2.WriteWhitespace("\r\n");
      if (AR != null)
      {
        Type typeAR = AR.GetType();
        foreach (PropertyInfo pi in typeAR.GetProperties())
        {
          if (pi.PropertyType == typeof(System.Int32))
          {
            xmlWriter2.WriteElementString(pi.Name, ((System.Int32)(pi.GetValue(AR, null))).ToString());
            xmlWriter2.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.String))
          {
            xmlWriter2.WriteElementString(pi.Name, (string)(pi.GetValue(AR, null)));
            xmlWriter2.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Double))
          {
            xmlWriter2.WriteElementString(pi.Name, ((System.Double)pi.GetValue(AR, null)).ToString());
            xmlWriter2.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Single))
          {
            xmlWriter2.WriteElementString(pi.Name, ((System.Single)pi.GetValue(AR, null)).ToString());
            xmlWriter2.WriteWhitespace("\r\n");
          }
          else if (pi.PropertyType == typeof(System.Boolean))
          {
            xmlWriter2.WriteElementString(pi.Name, ((System.Boolean)pi.GetValue(AR, null)).ToString());
            xmlWriter2.WriteWhitespace("\r\n");
          }
        }
      }
      xmlWriter2.WriteEndElement();
      xmlWriter2.WriteWhitespace("\r\n");

      xmlWriter2.WriteEndElement();
      xmlWriter2.WriteWhitespace("\r\n");
      xmlWriter2.WriteEndDocument();
    }
    finally
    {
      xmlWriter2.Close();
    }
  }

}