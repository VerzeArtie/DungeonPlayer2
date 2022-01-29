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
  //private static GameObject objSQL = null;
  private static GameObject objTF = null;

  [SerializeField] private static List<Character> _characters = new List<Character>();
  public static List<Character> Characters
  {
    get { return _characters; }
  }
  public static Character P1 = null;
  //public static Character P2 = null;
  //public static Character TC = null;
  //public static Character FC = null;
  //public static Character P5 = null;
  //public static WorldEnvironment WE = null;
  //public static TruthWorldEnvironment WE2 = null; // ゲームストーリー全体のワールド環境フラグ
  //public static ControlSQL SQL = null;
  public static TeamFoundation TF = null;

  //public static bool[] Truth_KnownTileInfo = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];
  //public static bool[] Truth_KnownTileInfo2 = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];
  //public static bool[] Truth_KnownTileInfo3 = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];
  //public static bool[] Truth_KnownTileInfo4 = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];
  //public static bool[] Truth_KnownTileInfo5 = new bool[Database.TRUTH_DUNGEON_COLUMN * Database.TRUTH_DUNGEON_ROW];

  public static List<Character> ShadowPlayerList = new List<Character>();
  public static TeamFoundation ShadowTF = null;
  //public static TeamFoundation shadowWE2 = null; // todo 世界セーブはDungeonPlayer2でも必要

  public static GameObject sound = null; // サウンド音源
  public static AudioSource soundSource = null; // サウンドソース

  public static GameObject bgm = null; // BGM音源
  public static List<AudioSource> bgmSource = new List<AudioSource>(); // BGMソース
  private static List<String> BgmName = new List<string>();
  public static List<float> BgmLoopPoint = new List<float>();
  public static int BgmNumber = 0;

  public static int EnableBGM = 100; // ミュージック、デフォルトは100
  public static int EnableSoundEffect = 100; // 効果音、デフォルトは100
  public static int BattleSpeed = 3;
  public static int Difficulty = 2; // ゲーム難易度 デフォルトは２：普通
  public static GameLanguage Language = GameLanguage.English; // ゲームサポート言語
  public static bool SupportLog = true; // SQLサーバーに操作ログを残す　デフォルトはON

  public static bool AlreadyInitialize = false; // 既に一度InitializeGroundOneを呼んだかどうか

  public static bool TutorialMode = false; // チュートリアルモードを示すフラグ
  public static int TutorialLevel = 1; // チュートリアルのレベル

  public static List<Character> PlayerList = new List<Character>();
  public static List<Character> EnemyList = new List<Character>();

  #region "SceneManager"
  // MotherForm
  public static List<MotherBase> Parent;
  public static string SceneName;

  // SaveLoad
  public static bool AfterBacktoTitle = false; // タイトル戻り直前のセーブモード
  public static bool SaveMode = false; // false:Load true:Save
  public static bool SaveAndExit = false; // true:RealWorldSave and exit
  public static string CurrentLoadFileName = String.Empty; // 現在ロード対象となっているファイル名

  // DungeonField
  //public static string DungeonFieldName = Fix.MAPFILE_BASE_FIELD;
  public static Fix.GameEndType BattleEnd = Fix.GameEndType.None;
  public static List<string> BattleEnemyList = new List<string>();

  // BattleEnemy
  public static bool CannotRunAway = false;
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
    //UnityEngine.Object.Destroy(P1);
    //P1 = null;
    //UnityEngine.Object.Destroy(P2);
    //P2 = null;
    //UnityEngine.Object.Destroy(TC);
    //TC = null;
    //UnityEngine.Object.Destroy(FC);
    //FC = null;
    //UnityEngine.Object.Destroy(WE);
    //WE = null;
    //UnityEngine.Object.Destroy(WE2);
    //WE2 = null;
    //UnityEngine.Object.Destroy(WE3);
    //WE3 = null;
    //UnityEngine.Object.Destroy(SQL);
    //SQL = null;
    UnityEngine.Object.Destroy(TF);
    TF = null;

    for (int ii = 0; ii < objCharacterList.Count; ii++)
    {
      UnityEngine.Object.Destroy(objCharacterList[ii]);
      objCharacterList[ii] = null;
    }
    objCharacterList.Clear();
    objCharacterList = new List<GameObject>();
    //UnityEngine.Object.Destroy(objP1);
    //objP1 = null;
    //UnityEngine.Object.Destroy(objP2);
    //objP2 = null;
    //UnityEngine.Object.Destroy(objTC);
    //objTC = null;
    //UnityEngine.Object.Destroy(objFC);
    //objFC = null;
    //UnityEngine.Object.Destroy(objWE);
    //objWE = null;
    //UnityEngine.Object.Destroy(objWE2);
    //objWE2 = null;
    //UnityEngine.Object.Destroy(objWE3);
    //objWE3 = null;
    //UnityEngine.Object.Destroy(objSQL);
    //objSQL = null;
    UnityEngine.Object.Destroy(objTF);
    objTF = null;
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
      Parent.Clear();
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
    //objP1 = new GameObject("objP1");
    //objP2 = new GameObject("objSC");
    //objTC = new GameObject("objTC");
    //objFC = new GameObject("objFC");
    //objWE = new GameObject("objWE");
    //objWE2 = new GameObject("objWE2");
    //objSQL = new GameObject("objSQL");
    objTF = new GameObject("objTF");

    if (FromGameLoad == false)
    {
      Parent = new List<MotherBase>();
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
    //WE2 = objWE2.AddComponent<TruthWorldEnvironment>();
    TF = objTF.AddComponent<TeamFoundation>();

    for (int ii = 0; ii < Fix.MAPSIZE_X_CAVEOFSARUN * Fix.MAPSIZE_Z_CAVEOFSARUN; ii++)
    {
      TF.KnownTileList_CaveOfSarun.Add(false);
    }
    
    for (int ii = 0; ii < Fix.CHARACTER_LIST_NUM; ii++)
    {
      _characters.Add(objCharacterList[ii].AddComponent<Character>());
    }
    //P1 = objP1.AddComponent<Character>();
    //P2 = objP2.AddComponent<Character>();
    //TC = objTC.AddComponent<Character>();
    //FC = objFC.AddComponent<Character>();

    //SQL = objSQL.AddComponent<ControlSQL>();
    //SQL.SetupSql();

    TF.AvailableEinWolence = true;
    TF.AvailableLanaAmiria = true;

    // debug
    //TF.AvailableTactics = true;
    //TF.AvailableSkillTree = true;
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
    ////TF.AvailableSkillTree = true;
    ////TF.AvailableAllCommand = true;
    ////TF.AvailableThird = true;
    ////TF.AvailableFourth = true;
    ////TF.AvailableFirstCommand = true;
    ////TF.AvailableSecondCommand = true;
    ////TF.AvailableThirdCommand = true;

    //TF.BattlePlayer1 = Fix.NAME_EIN_WOLENCE;
    //TF.BattlePlayer2 = Fix.NAME_EONE_FULNEA;
    //TF.BattlePlayer3 = Fix.NAME_LANA_AMIRIA;
    //TF.BattlePlayer4 = Fix.NAME_ADEL_BRIGANDY;

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
    ////Characters[num].MainWeapon = new Item(Fix.EDIL_BLACK_BLADE);
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
    //Characters[num].ReachableTarget = 28;
    //Characters[num].HawkEye = 27;
    //Characters[num].PiercingArrow = 26;
    //Characters[num].VenomSlash = 25;
    //Characters[num].InvisibleBind = 24;
    //Characters[num].IrregularStep = 23;
    //Characters[num].DissensionRhythm = 22;
    //Characters[num].AssassinationHit = 21;
    //Characters[num].AuraOfPower = 20;
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
    //actionList3.Add(Fix.AIR_CUTTER);
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
    //actionList4.Add(Fix.AURA_OF_POWER);
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
    // TF.BackpackList.Add(new Item(Fix.MASTER_SWORD));
    // TF.BackpackList.Add(new Item(Fix.MASTER_SHIELD));
    // TF.BackpackList.Add(new Item(Fix.EDIL_BLACK_BLADE));
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
    //TF.CurrentDungeonField = Fix.MAPFILE_CAVEOFSARUN;
    // debug-end

    for (int ii = 0; ii < _characters.Count; ii++)
    {
      UnityEngine.Object.DontDestroyOnLoad(_characters[ii]);
    }
    //UnityEngine.Object.DontDestroyOnLoad(P1);
    //UnityEngine.Object.DontDestroyOnLoad(P2);
    //UnityEngine.Object.DontDestroyOnLoad(TC);
    //UnityEngine.Object.DontDestroyOnLoad(FC);
    //UnityEngine.Object.DontDestroyOnLoad(WE);
    //UnityEngine.Object.DontDestroyOnLoad(WE2);
    UnityEngine.Object.DontDestroyOnLoad(TF);
    UnityEngine.Object.DontDestroyOnLoad(sound);
    UnityEngine.Object.DontDestroyOnLoad(soundSource);
    UnityEngine.Object.DontDestroyOnLoad(bgm);
    UnityEngine.Object.DontDestroyOnLoad(bgmSource[0]);
    //UnityEngine.Object.DontDestroyOnLoad(SQL);
    return true;
  }

  public static List<Character> AvailableCharacters
  {
    get
    {
      List<Character> list = new List<Character>();
      int playerCounter = 0;
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


    //Type type3 = WE2.GetType();
    //foreach (PropertyInfo pi in type3.GetProperties())
    //{
    //  // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
    //  if (pi.PropertyType == typeof(System.Int32))
    //  {
    //    try
    //    {
    //      pi.SetValue(ShadowTF2, (System.Int32)(type3.GetProperty(pi.Name).GetValue(WE2, null)), null);
    //    }
    //    catch { }
    //  }
    //  else if (pi.PropertyType == typeof(System.String))
    //  {
    //    try
    //    {
    //      pi.SetValue(ShadowTF2, (string)(type3.GetProperty(pi.Name).GetValue(WE2, null)), null);
    //    }
    //    catch { }
    //  }
    //  else if (pi.PropertyType == typeof(System.Boolean))
    //  {
    //    try
    //    {
    //      pi.SetValue(ShadowTF2, (System.Boolean)(type3.GetProperty(pi.Name).GetValue(WE2, null)), null);
    //    }
    //    catch { }
    //  }
    //}
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
    //if (GroundOne.EnableSoundEffect > 0.0f)
    {
      soundSource.clip = Resources.Load<AudioClip>(Fix.BaseSoundFolder + soundName);
      soundSource.volume = (float)((float)One.EnableSoundEffect / 100.0f);
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
    bgmSource[BgmNumber].volume = (float)((float)One.EnableBGM / 100.0f);
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
  public static void ExecLoad(string targetFileName)
  {
    //        GroundOne.ReInitializeGroundOne(true);

    XmlDocument xml = new XmlDocument();
    DateTime now = DateTime.Now;
    string yearData = String.Empty;
    string monthData = String.Empty;
    string dayData = String.Empty;
    string hourData = String.Empty;
    string minuteData = String.Empty;
    string secondData = String.Empty;
    string gamedayData = String.Empty;
    string completeareaData = String.Empty;

    Debug.Log("ExecLoad 1 " + DateTime.Now + "." + DateTime.Now.Minute);
    xml.Load(One.pathForDocumentsFile(targetFileName));

    Debug.Log("ExecLoad 2 " + DateTime.Now + "." + DateTime.Now.Minute);
    //try
    //{
    //    XmlNodeList currentList = xml.GetElementsByTagName("MainWeapon");
    //    foreach (XmlNode node in currentList)
    //    {
    //        if (node.ParentNode.Name == Database.NODE_MAINPLAYERSTATUS)
    //        {
    //            GroundOne.MC.MainWeapon = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_SECONDPLAYERSTATUS)
    //        {
    //            GroundOne.SC.MainWeapon = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_THIRDPLAYERSTATUS)
    //        {
    //            GroundOne.TC.MainWeapon = new ItemBackPack(node.InnerText);
    //        }
    //    }
    //}
    //catch { }
    //// s 後編追加
    //try
    //{
    //    XmlNodeList currentList = xml.GetElementsByTagName("SubWeapon");
    //    foreach (XmlNode node in currentList)
    //    {
    //        if (node.ParentNode.Name == Database.NODE_MAINPLAYERSTATUS)
    //        {
    //            GroundOne.MC.SubWeapon = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_SECONDPLAYERSTATUS)
    //        {
    //            GroundOne.SC.SubWeapon = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_THIRDPLAYERSTATUS)
    //        {
    //            GroundOne.TC.SubWeapon = new ItemBackPack(node.InnerText);
    //        }
    //    }
    //}
    //catch { }
    //// e 後編追加
    //try
    //{
    //    XmlNodeList currentList = xml.GetElementsByTagName("MainArmor");
    //    foreach (XmlNode node in currentList)
    //    {
    //        if (node.ParentNode.Name == Database.NODE_MAINPLAYERSTATUS)
    //        {
    //            GroundOne.MC.MainArmor = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_SECONDPLAYERSTATUS)
    //        {
    //            GroundOne.SC.MainArmor = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_THIRDPLAYERSTATUS)
    //        {
    //            GroundOne.TC.MainArmor = new ItemBackPack(node.InnerText);
    //        }
    //    }
    //}
    //catch { }
    //try
    //{
    //    XmlNodeList currentList = xml.GetElementsByTagName("Accessory");
    //    foreach (XmlNode node in currentList)
    //    {
    //        if (node.ParentNode.Name == Database.NODE_MAINPLAYERSTATUS)
    //        {
    //            GroundOne.MC.Accessory = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_SECONDPLAYERSTATUS)
    //        {
    //            GroundOne.SC.Accessory = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_THIRDPLAYERSTATUS)
    //        {
    //            GroundOne.TC.Accessory = new ItemBackPack(node.InnerText);
    //        }
    //    }
    //}
    //catch { }
    //// s 後編追加
    //try
    //{
    //    XmlNodeList currentList = xml.GetElementsByTagName("Accessory2");
    //    foreach (XmlNode node in currentList)
    //    {
    //        if (node.ParentNode.Name == Database.NODE_MAINPLAYERSTATUS)
    //        {
    //            GroundOne.MC.Accessory2 = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_SECONDPLAYERSTATUS)
    //        {
    //            GroundOne.SC.Accessory2 = new ItemBackPack(node.InnerText);
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_THIRDPLAYERSTATUS)
    //        {
    //            GroundOne.TC.Accessory2 = new ItemBackPack(node.InnerText);
    //        }
    //    }
    //}
    //catch { }
    // e 後編追加
    Debug.Log("ExecLoad 3 " + DateTime.Now + "." + DateTime.Now.Minute);


    //for (int ii = 0; ii < Database.MAX_BACKPACK_SIZE; ii++)
    //{
    //    XmlNodeList temp = xml.GetElementsByTagName("BackPack" + ii.ToString());
    //    foreach (XmlNode node in temp)
    //    {
    //        if (node.ParentNode.Name == Database.NODE_MAINPLAYERSTATUS)
    //        {
    //            XmlNodeList temp2 = xml.GetElementsByTagName("BackPackStack" + ii.ToString());
    //            if (temp2.Count <= 0) // 旧互換の場合、必ずスタック量は１つである。
    //            {
    //                GroundOne.MC.AddBackPack(new ItemBackPack(node.InnerText));
    //            }
    //            else
    //            {
    //                foreach (XmlNode node2 in temp2)
    //                {
    //                    if (node2.ParentNode.Name == Database.NODE_MAINPLAYERSTATUS)
    //                    {
    //                        for (int kk = 0; kk < Convert.ToInt32(node2.InnerText); kk++)
    //                        {
    //                            GroundOne.MC.AddBackPack(new ItemBackPack(node.InnerText));
    //                        }
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_SECONDPLAYERSTATUS)
    //        {
    //            XmlNodeList temp2 = xml.GetElementsByTagName("BackPackStack" + ii.ToString());
    //            if (temp2.Count <= 0) // 旧互換の場合、必ずスタック量は１つである。
    //            {
    //                GroundOne.SC.AddBackPack(new ItemBackPack(node.InnerText));
    //            }
    //            else
    //            {
    //                foreach (XmlNode node2 in temp2)
    //                {
    //                    if (node2.ParentNode.Name == Database.NODE_SECONDPLAYERSTATUS)
    //                    {
    //                        for (int kk = 0; kk < Convert.ToInt32(node2.InnerText); kk++)
    //                        {
    //                            GroundOne.SC.AddBackPack(new ItemBackPack(node.InnerText));
    //                        }
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //        else if (node.ParentNode.Name == Database.NODE_THIRDPLAYERSTATUS)
    //        {
    //            XmlNodeList temp2 = xml.GetElementsByTagName("BackPackStack" + ii.ToString());
    //            if (temp2.Count <= 0) // 旧互換の場合、必ずスタック量は１つである。
    //            {
    //                GroundOne.TC.AddBackPack(new ItemBackPack(node.InnerText));
    //            }
    //            else
    //            {
    //                foreach (XmlNode node2 in temp2)
    //                {
    //                    if (node2.ParentNode.Name == Database.NODE_THIRDPLAYERSTATUS)
    //                    {
    //                        for (int kk = 0; kk < Convert.ToInt32(node2.InnerText); kk++)
    //                        {
    //                            GroundOne.TC.AddBackPack(new ItemBackPack(node.InnerText));
    //                        }
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    // e 後編編集
    Debug.Log("ExecLoad 4 " + DateTime.Now + "." + DateTime.Now.Minute);

    //Type type = GroundOne.MC.GetType();
    //foreach (PropertyInfo pi in type.GetProperties())
    //{
    //    // [警告]：catch構文はSetプロパティがない場合だが、それ以外のケースも見えなくなってしまうので要分析方法検討。
    //    if (pi.PropertyType == typeof(System.Int32))
    //    {
    //        try { pi.SetValue(GroundOne.MC, Convert.ToInt32(xml.DocumentElement.SelectSingleNode(@"/Body/" + Database.NODE_MAINPLAYERSTATUS + "/" + pi.Name).InnerText), null); }
    //        catch { }
    //        try { pi.SetValue(GroundOne.SC, Convert.ToInt32(xml.DocumentElement.SelectSingleNode(@"/Body/" + Database.NODE_SECONDPLAYERSTATUS + "/" + pi.Name).InnerText), null); }
    //        catch { }
    //        try { pi.SetValue(GroundOne.TC, Convert.ToInt32(xml.DocumentElement.SelectSingleNode(@"/Body/" + Database.NODE_THIRDPLAYERSTATUS + "/" + pi.Name).InnerText), null); }
    //        catch { }
    //    }
    //    else if (pi.PropertyType == typeof(System.String))
    //    {
    //        try { pi.SetValue(GroundOne.MC, xml.DocumentElement.SelectSingleNode(@"/Body/" + Database.NODE_MAINPLAYERSTATUS + "/" + pi.Name).InnerText, null); }
    //        catch { }
    //        try { pi.SetValue(GroundOne.SC, xml.DocumentElement.SelectSingleNode(@"/Body/" + Database.NODE_SECONDPLAYERSTATUS + "/" + pi.Name).InnerText, null); }
    //        catch { }
    //        try { pi.SetValue(GroundOne.TC, xml.DocumentElement.SelectSingleNode(@"/Body/" + Database.NODE_THIRDPLAYERSTATUS + "/" + pi.Name).InnerText, null); }
    //        catch { }
    //    }
    //    else if (pi.PropertyType == typeof(System.Boolean))
    //    {
    //        try { pi.SetValue(GroundOne.MC, Convert.ToBoolean(xml.DocumentElement.SelectSingleNode(@"/Body/" + Database.NODE_MAINPLAYERSTATUS + "/" + pi.Name).InnerText), null); }
    //        catch { }
    //        try { pi.SetValue(GroundOne.SC, Convert.ToBoolean(xml.DocumentElement.SelectSingleNode(@"/Body/" + Database.NODE_SECONDPLAYERSTATUS + "/" + pi.Name).InnerText), null); }
    //        catch { }
    //        try { pi.SetValue(GroundOne.TC, Convert.ToBoolean(xml.DocumentElement.SelectSingleNode(@"/Body/" + Database.NODE_THIRDPLAYERSTATUS + "/" + pi.Name).InnerText), null); }
    //        catch { }
    //    }
    //    // s 後編追加
    //    else if (pi.PropertyType == typeof(MainCharacter.AdditionalSpellType))
    //    {
    //        try
    //        {
    //            XmlNodeList currentList = xml.GetElementsByTagName(pi.Name);
    //            foreach (XmlNode node in currentList)
    //            {
    //                if (node.ParentNode.Name == Database.NODE_MAINPLAYERSTATUS)
    //                {
    //                    pi.SetValue(GroundOne.MC, (MainCharacter.AdditionalSpellType)Enum.Parse(typeof(MainCharacter.AdditionalSpellType), node.InnerText), null);
    //                }
    //                else if (node.ParentNode.Name == Database.NODE_SECONDPLAYERSTATUS)
    //                {
    //                    pi.SetValue(GroundOne.SC, (MainCharacter.AdditionalSpellType)Enum.Parse(typeof(MainCharacter.AdditionalSpellType), node.InnerText), null);
    //                }
    //                else if (node.ParentNode.Name == Database.NODE_THIRDPLAYERSTATUS)
    //                {
    //                    pi.SetValue(GroundOne.TC, (MainCharacter.AdditionalSpellType)Enum.Parse(typeof(MainCharacter.AdditionalSpellType), node.InnerText), null);
    //                }
    //            }
    //        }
    //        catch { }
    //    }
    //    else if (pi.PropertyType == typeof(MainCharacter.AdditionalSkillType))
    //    {
    //        try
    //        {
    //            XmlNodeList currentList = xml.GetElementsByTagName(pi.Name);
    //            foreach (XmlNode node in currentList)
    //            {
    //                if (node.ParentNode.Name == Database.NODE_MAINPLAYERSTATUS)
    //                {
    //                    pi.SetValue(GroundOne.MC, (MainCharacter.AdditionalSkillType)Enum.Parse(typeof(MainCharacter.AdditionalSkillType), node.InnerText), null);
    //                }
    //                else if (node.ParentNode.Name == Database.NODE_SECONDPLAYERSTATUS)
    //                {
    //                    pi.SetValue(GroundOne.SC, (MainCharacter.AdditionalSkillType)Enum.Parse(typeof(MainCharacter.AdditionalSkillType), node.InnerText), null);
    //                }
    //                else if (node.ParentNode.Name == Database.NODE_THIRDPLAYERSTATUS)
    //                {
    //                    pi.SetValue(GroundOne.TC, (MainCharacter.AdditionalSkillType)Enum.Parse(typeof(MainCharacter.AdditionalSkillType), node.InnerText), null);
    //                }
    //            }
    //        }
    //        catch { }
    //    }
    //    // e 後編追加
    //}
    Debug.Log("ExecLoad 5 " + DateTime.Now + "." + DateTime.Now.Minute);

    Debug.Log("ExecLoad 6 " + DateTime.Now + "." + DateTime.Now.Minute);
    Type typeTF = One.TF.GetType();


    PropertyInfo[] tempWE = typeTF.GetProperties();
    Debug.Log(tempWE.Length.ToString());

    foreach (PropertyInfo pi in tempWE)
    {
      if (pi.PropertyType == typeof(System.Int32))
      {
        Debug.Log("Int32 " + pi.Name + " " + pi.PropertyType.ToString());
        try
        {
          Debug.Log(xml.DocumentElement.SelectSingleNode(@"/Body/TeamFoundation/" + (pi.Name)).InnerText);
          pi.SetValue(One.TF, Convert.ToInt32(xml.DocumentElement.SelectSingleNode(@"/Body/TeamFoundation/" + (pi.Name)).InnerText), null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.String))
      {
        Debug.Log("String " + pi.Name + " " + pi.PropertyType.ToString());
        try
        {
          Debug.Log(xml.DocumentElement.SelectSingleNode(@"/Body/TeamFoundation/" + (pi.Name)).InnerText);
          pi.SetValue(One.TF, xml.DocumentElement.SelectSingleNode(@"/Body/TeamFoundation/" + (pi.Name)).InnerText, null);
        }
        catch { }
      }
      else if (pi.PropertyType == typeof(System.Boolean))
      {
        Debug.Log("Boolean " + pi.Name + " " + pi.PropertyType.ToString());
        try
        {
          Debug.Log(xml.DocumentElement.SelectSingleNode(@"/Body/TeamFoundation/" + (pi.Name)).InnerText);
          pi.SetValue(One.TF, Convert.ToBoolean(xml.DocumentElement.SelectSingleNode(@"/Body/TeamFoundation/" + (pi.Name)).InnerText), null);
        }
        catch { }
      }
      else
      {
        Debug.Log("else " + pi.Name + " " + pi.PropertyType.ToString());
      }
    }
    Debug.Log("ExecLoad 7 " + DateTime.Now + "." + DateTime.Now.Minute);

    //        Method.ReloadTruthWorldEnvironment();
    Debug.Log("ExecLoad 75 " + DateTime.Now + "." + DateTime.Now.Minute);

    //        Method.LoadKnownTileInfo();
    Debug.Log("ExecLoad 8-1 " + DateTime.Now + "." + DateTime.Now.Minute);


    Debug.Log("ExecLoad end");
  }
  //// 現実世界の自動セーブ
  //public static void AutoSaveRealWorld()
  //{
  //    SceneDimension.CallSaveLoadWithSaveOnly();
  //}
  //public static void AutoSaveRealWorld(MainCharacter MC, MainCharacter SC, MainCharacter TC, WorldEnvironment WE, bool[] knownTileInfo, bool[] knownTileInfo2, bool[] knownTileInfo3, bool[] knownTileInfo4, bool[] knownTileInfo5, bool[] Truth_KnownTileInfo, bool[] Truth_KnownTileInfo2, bool[] Truth_KnownTileInfo3, bool[] Truth_KnownTileInfo4, bool[] Truth_KnownTileInfo5)
  //{
  //    SceneDimension.CallSaveLoadWithSaveOnly();
  //}

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
}