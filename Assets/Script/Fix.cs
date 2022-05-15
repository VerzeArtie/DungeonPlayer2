using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Fix
{
  public enum Ally
  {
    None,
    Ally,
    Enemy,
  }

  public enum BattleStatus
  {
    Ready,
    Go,
    Stop,
  }

  public enum GameEndType
  {
    None,
    Success,
    Fail,
    RunAway,
    Retry,
  }

  public enum JobClass
  {
    None,
    Fighter,
    Magician,
    Seeker,
  }

  public enum CommandAttribute
  {
    Fire,
    Ice,
    HolyLight,
    DarkMagic,
    Wind,
    Earth,
    Warrior,
    Archer,
    MartialArts,
    Rogue,
    WonderHermit,
    Armorer,
    EnhanceForm,
    MysticForm,
    Truth,
    Brave,
    Vengeance,
    Mindfulness,
    None,
  }

  public enum DamageCore
  {
    None,
    Physical,
    Magic,
  }

  public enum DamageSource
  {
    None,
    Fire,
    Ice,
    HolyLight,
    DarkMagic,
    Wind,
    Earth,
    Physical, // 物理
    Colorless, // 無属性
  }

  public enum EquipType
  {
    MainWeapon,
    SubWeapon,
    Armor,
    Accessory1,
    Accessory2,
    Artifact,
  }

  // Battle Gauge
  public const int BATTLE_CORE_SLEEP = 0;
  public const int BASE_TIMER_BAR_LENGTH = 30000;
  public const int BASE_TIMER_DIV = 36;
  public const int TIMER_ICON_NUM = 8;
  public const int MAX_INSTANT_POINT = 1000;
  public const int GLOBAL_INSTANT_MAX = 1000;
  public const int AP_BASE = 100;
  public const int INFINITY = 9999999;

  // Color
  public static Color COLOR_NORMAL = Color.black;
  public static Color COLOR_HEAL = Color.green;
  public static Color COLOR_GAIN_SP = Color.blue;

  public static Color COLOR_FIRST_CHARA = new Color(235.0f / 255.0f, 253.0f / 255.0f, 255.0f / 255.0f);
  public static Color COLORFORE_FIRST_CHARA = new Color(0, 185.0f / 255.0f, 255.0f / 255.0f);

  public static Color COLOR_SECOND_CHARA = new Color(255.0f / 255.0f, 208.0f / 255.0f, 244.0f / 255.0f);
  public static Color COLORFORE_SECOND_CHARA = new Color(255.0f / 255.0f, 124.0f / 255.0f, 170.0f / 255.0f);

  public static Color COLOR_THIRD_CHARA = new Color(255.0f / 255.0f, 245.0f / 255.0f, 189.0f / 255.0f);
  public static Color COLORFORE_THIRD_CHARA = new Color(248.0f / 255.0f, 237.0f / 255.0f, 95.0f / 255.0f);

  public static Color COLOR_FOURTH_CHARA = new Color(189.0f / 255.0f, 255.0f / 255.0f, 199.0f / 255.0f);
  public static Color COLORFORE_FOURTH_CHARA = new Color(0 / 255.0f, 187.0f / 255.0f, 0 / 255.0f);

  public static Color COLOR_FIFTH_CHARA = new Color(1.0f, 0.8f, 0.8f);
  public static Color COLORFORE_FIFTH_CHARA = new Color(200 / 255.0f, 0.3f, 0.3f);

  public static Color COLOR_ENEMY_CHARA = new Color(200.0f / 255.0f, 200.0f / 255.0f, 200.0f / 255.0f);
  public static Color COLORFORE_ENEMY_CHARA = new Color(226.0f / 255.0f, 58.0f / 255.0f, 0 / 255.0f);

  #region "Unityシーン名"
  public const string Title = @"Title";
  public const string Tutorial = @"Tutorial";
  public const string GameSetting = @"GameSetting";
  public const string DungeonTicket = @"DungeonTicket";
  public const string TruthAnswer = @"TruthAnswer";
  public const string TruthBattleEnemy = @"TruthBattleEnemy";
  public const string TruthBattleSetting = @"TruthBattleSetting";
  public const string TruthChoiceStatue = @"TruthChoiceStatue";
  public const string TruthChooseCommand = @"TruthChooseCommand";
  public const string TruthDecision = @"TruthDecision";
  public const string TruthDecision2 = @"TruthDecision2";
  public const string TruthDecision3 = @"TruthDecision3";
  public const string TruthDuelPlayerStatus = @"TruthDuelPlayerStatus";
  public const string TruthDuelRule = @"TruthDuelRule";
  public const string TruthDuelSelect = @"TruthDuelSelect";
  public const string TruthDungeon = @"TruthDungeon";
  public const string TruthEquipmentShop = @"TruthEquipmentShop";
  public const string TruthHomeTown = @"HomeTown";
  public const string TruthInformation = @"TruthInformation";
  public const string TruthItemBank = @"TruthItemBank";
  public const string TruthItemDesc = @"TruthItemDesc";
  public const string TruthPlayback = @"TruthPlayback";
  public const string TruthAchievement = @"TruthAchievement";
  public const string TruthPlayerInformation = @"TruthPlayerInformation";
  public const string TruthPotionShop = @"TruthPotionShop";
  public const string TruthRequestFood = @"TruthRequestFood";
  public const string TruthMonsterQuest = @"TruthMonsterQuest";
  public const string TruthSelectCharacter = @"TruthSelectCharacter";
  public const string TruthSelectEquipment = @"TruthSelectEquipment";
  public const string TruthSkillSpellDesc = @"TruthSkillSpellDesc";
  public const string TruthStatusPlayer = @"TruthStatusPlayer";
  public const string TruthWill = @"TruthWill";
  public const string TruthRequestInput = @"TruthInputRequest";
  public const string SaveLoad = @"SaveLoad";
  public const string SingleHomeTown = @"SingleHomeTown";
  public const string SingleDungeon = @"SingleDungeon";
  public const string SingleBattleEnemy = @"SingleBattleEnemy";

  public const string SCENE_DUNGEON_FIELD = @"DungeonField";
  public const string SCENE_HOME_TOWN = @"HomeTown";
  #endregion

  #region "効果音データファイル名"
  public const string SOUND_FIREBALL = @"FireBall";
  public const string SOUND_ICENEEDLE = @"IceNeedle";
  public const string SOUND_ENEMY_ATTACK1 = @"EnemyAttack1";
  public const string SOUND_SWORD_SLASH1 = @"SwordSlash1";
  public const string SOUND_STRAIGHT_SMASH = @"StraightSmash";
  public const string SOUND_FRESH_HEAL = @"FreshHeal";
  public const string SOUND_CELESTIAL_NOVA = @"CelestialNova";
  public const string SOUND_MAGIC_ATTACK = @"MagicAttack";
  public const string SOUND_KINETIC_SMASH = @"KineticSmash";
  public const string SOUND_ARCANE_DESTRUCTION = @"KineticSmash";
  public const string SOUND_CRUSHING_BLOW = @"CrushingBlow";
  public const string SOUND_SOUL_INFINITY = @"Catastrophe";
  public const string SOUND_CATASTROPHE = @"Catastrophe";
  public const string SOUND_OBORO_IMPACT = @"Catastrophe";
  public const string SOUND_ABYSS_EYE = @"WhiteOut";
  public const string SOUND_DARK_BLAST = @"DarkBlast";
  public const string SOUND_DOOM_BLADE = @"DarkBlast";
  public const string SOUND_PHANTASMAL_WIND = @"HeatBoost";
  public const string SOUND_PARADOX_IMAGE = @"RiseOfImage";
  public const string SOUND_PIERCING_FLAME = @"FireBall";
  public const string SOUND_DEMONIC_IGNITE = @"FireBall";
  public const string SOUND_VORTEX_FIELD = @"DispelMagic";
  public const string SOUND_GLORY = @"Glory";
  public const string SOUND_STATIC_BARRIER = @"Glory";
  public const string SOUND_NOURISH_SENSE = @"WordOfLife";
  public const string SOUND_LIFE_TAP = @"LifeTap";
  public const string SOUND_SYUTYU_DANZETSU = @"NothingOfNothingness";
  public const string SOUND_JUNKAN_SEIYAKU = @"NothingOfNothingness";
  public const string SOUND_ORA_ORA_ORAAA = @"Catastrophe";
  public const string SOUND_SHINZITSU_HAKAI = @"Catastrophe";
  public const string SOUND_HYMN_CONTRACT = @"Resurrection";
  public const string SOUND_ENDLESS_ANTHEM = @"Resurrection";
  public const string SOUND_FLAME_STRIKE = @"FlameStrike";
  public const string SOUND_SIGIL_OF_HOMURA = @"FlameStrike";
  public const string SOUND_AUSTERITY_MATRIX = @"OneImmunity";
  public const string SOUND_RED_DRAGON_WILL = @"StraightSmash";
  public const string SOUND_BLUE_DRAGON_WILL = @"StraightSmash";
  public const string SOUND_ECLIPSE_END = @"BlackContract";
  public const string SOUND_SIN_FORTUNE = @"BlackContract";
  public const string SOUND_BLACK_FLARE = @"BlackContract";
  public const string SOUND_DEATH_DENY = @"BlackContract";
  public const string SOUND_DEATH = @"BlackContract";
  public const string SOUND_RISINGKNUCKLE = @"RisingKnuckle";
  public const string SOUND_DAMNATION = @"Damnation";
  public const string SOUND_CHOSEN_SACRIFY = @"Damnation";
  public const string SOUND_ABSOLUTE_ZERO = @"AbsoluteZero";
  public const string SOUND_LAVA_ANNIHILATION = @"LavaAnnihilation";
  public const string SOUND_KOKUEN_BLUE_EXPLODE = @"LavaAnnihilation";
  public const string SOUND_VOLCANICWAVE = @"VolcanicWave";
  public const string SOUND_MEGID_BLAZE = @"VolcanicWave";
  public const string SOUND_FROZENLANCE = @"FrozenLance";
  public const string SOUND_SHARPNEL_NEEDLE = @"FrozenLance";
  public const string SOUND_WHITEOUT = @"Whiteout";
  public const string SOUND_WORD_OF_POWER = @"WordOfPower";
  public const string SOUND_TIME_STOP = @"TimeStop";
  public const string SOUND_WARP_GATE = @"TimeStop";
  public const string SOUND_GENESIS = @"Genesis";
  public const string SOUND_STANCE_OF_DOUBLE = @"Genesis";
  public const string SOUND_ZETA_EXPLOSION = @"LavaAnnihilation";

  public const string SOUND_GET_EPIC_ITEM = @"GetEpicItem";
  public const string SOUND_GET_RARE_ITEM = @"GetRareItem";

  public const string SOUND_LVUP_FELTUS = @"LvupFeltus";

  public const string SOUND_WALL_HIT = @"WallHit";
  public const string SOUND_FOOT_STEP = @"footstep";
  public const string SOUND_REST_INN = @"RestInn";
  public const string SOUND_DEVOURING_PLAGUE = @"DevouringPlague";

  public const string SOUND_LEVEL_UP = @"LvUp";
  public const string SOUND_SELECT_TAP = @"SelectTap";

  // ここから下はサウンドファイル名称を直接記述したものをナンバリング
  public const string SOUND_1 = @"AbsoluteZero";
  public const string SOUND_2 = @"AbsorbWater";
  public const string SOUND_3 = @"AeroBlade";
  public const string SOUND_4 = @"AetherDrive";
  public const string SOUND_5 = @"AntiStun";
  public const string SOUND_6 = @"BlackContract";
  public const string SOUND_7 = @"BloodyVengeance";
  public const string SOUND_8 = @"BlueLightning";
  public const string SOUND_9 = @"Catastrophe";
  public const string SOUND_10 = @"CelestialNova";
  public const string SOUND_11 = @"Cleansing";
  public const string SOUND_12 = @"CrushingBlow";
  public const string SOUND_13 = @"Damnation";
  public const string SOUND_14 = @"DarkBlast";
  public const string SOUND_15 = @"Deflection";
  public const string SOUND_17 = @"DispelMagic";
  public const string SOUND_18 = @"EnemyAttack1";
  public const string SOUND_19 = @"EternalPresence";
  public const string SOUND_20 = @"FireBall";
  public const string SOUND_21 = @"FlameAura";
  public const string SOUND_22 = @"FlameStrike";
  public const string SOUND_23 = @"footstep";
  public const string SOUND_24 = @"FreshHeal";
  public const string SOUND_25 = @"FrozenLance";
  public const string SOUND_26 = @"GaleWind";
  public const string SOUND_27 = @"Genesis";
  public const string SOUND_28 = @"GetEpicItem";
  public const string SOUND_29 = @"GetRareItem";
  public const string SOUND_30 = @"Glory";
  public const string SOUND_31 = @"HeatBoost";
  public const string SOUND_32 = @"HighEmotionality";
  public const string SOUND_33 = @"Hit01";
  public const string SOUND_34 = @"HolyShock";
  public const string SOUND_35 = @"IceNeedle";
  public const string SOUND_36 = @"ImmortalRave";
  public const string SOUND_37 = @"InnerInspiration";
  public const string SOUND_38 = @"KineticSmash";
  public const string SOUND_39 = @"LavaAnnihilation";
  public const string SOUND_40 = @"LifeTap";
  public const string SOUND_41 = @"LvUp";
  public const string SOUND_42 = @"LvupFeltus";
  public const string SOUND_43 = @"MagicAttack";
  public const string SOUND_44 = @"MirrorImage";
  public const string SOUND_45 = @"NothingOfNothingness";
  public const string SOUND_46 = @"OneImmunity";
  public const string SOUND_47 = @"PainfulInsanity";
  public const string SOUND_48 = @"PromisedKnowledge";
  public const string SOUND_49 = @"Protection";
  public const string SOUND_50 = @"PutiFireBall";
  public const string SOUND_52 = @"Resurrection";
  public const string SOUND_53 = @"RiseOfImage";
  public const string SOUND_54 = @"RisingKnuckle";
  public const string SOUND_55 = @"SaintPower";
  public const string SOUND_56 = @"ShadowPact";
  public const string SOUND_57 = @"SpecialHit";
  public const string SOUND_58 = @"StanceOfDeath";
  public const string SOUND_59 = @"StanceOfFlow";
  public const string SOUND_60 = @"StraightSmash";
  public const string SOUND_61 = @"SwordSlash1";
  public const string SOUND_62 = @"TimeStop";
  public const string SOUND_63 = @"Tranquility";
  public const string SOUND_64 = @"TruthVision";
  public const string SOUND_65 = @"VoidExtraction";
  public const string SOUND_66 = @"VolcanicWave";
  public const string SOUND_67 = @"WallHit";
  public const string SOUND_68 = @"WhiteOut";
  public const string SOUND_69 = @"WordOfFortune";
  public const string SOUND_70 = @"WordOfLife";
  public const string SOUND_71 = @"WordOfPower";

  public const string SOUND_OBJECTIVE_ADD = "ObjectiveAdd";
  public const string SOUND_OBJECTIVE_COMP = "ObjectiveComplete";

  public const string SOUND_MQ_BEGIN = "MonsterQuestBegin";
  public const string SOUND_MQ_REWARD = "MonsterQuestReward";
  #endregion

  // Battle Effect Message
  public const string BATTLE_MISS = "Miss";
  public const string BATTLE_DIZZY_MISS = "Dizzy Miss";
  public const string BATTLE_AP_LESS = "No AP";
  public const string BATTLE_SP_LESS = "No SP";
  public const string BATTLE_NO_POTION = "No Potion";
  public const string BATTLE_BIND = "Bind";
  public const string BATTLE_DIVINE = "Divine";
  public const string BATTLE_SILENT = "Silent";

  #region "Environment"
  public static string BaseMapFolder = @"\Map\";
  public static string BaseSoundFolder = @"Sounds/";
  public static string BaseSaveFolder = Environment.CurrentDirectory + @"\Save\";
  public static string BaseMusicFolder = @"BGM\";
  public const string TF_SAVE = @"TeamFoundationSave.xml";
  public static string WorldSaveNum = "999_";
  public static int WORLD_SAVE_NUM = 999;
  public static string AutoSaveNum = "210_";
  public static int AUTOSAVE_PAGE_NUM = 21;
  public static string SAVELOAD_NEW = "SaveLoadNew2";
  public static string SAVELOAD_NEW_AUTO = "SaveLoadNewAuto";
  public static int VERSION = 2;
  #endregion

  #region "Player Name"
  public const int CHARACTER_LIST_NUM = 24;
  public const string NAME_EIN_WOLENCE = @"アイン ウォーレンス";
  public const string NAME_LANA_AMIRIA = @"ラナ アミリア";
  public const string NAME_EONE_FULNEA = @"エオネ フルネア";
  public const string NAME_BILLY_RAKI = @"ビリー ラキ";
  public const string NAME_ADEL_BRIGANDY = @"アデル ブリガンディ";
  public const string NAME_CALMANS_OHN = @"カルマンズ オーン";
  public const string NAME_ANNA_HAMILTON = @"アンナ ハミルトン";
  public const string NAME_SELMOI_RO = @"セルモイ ロウ";
  public const string NAME_MAGI_ZELKIS = @"マーギ ゼルキス";
  public const string NAME_LENE_COLTOS = @"レネ コルトス";
  public const string NAME_SHUVALTZ_FLORE = @"シュヴァルツェ フローレ";
  public const string NAME_KARTIN_MAI = @"カーティン マイ";
  public const string NAME_JEDA_ARUS = @"ジェダ アルス";
  public const string NAME_ILZINA_MELDIETE = @"イルジナ メルディート";
  public const string NAME_OHRYU_GENMA = @"オウリュウ ゲンマ";
  public const string NAME_DELVA_TRECKINO = @"デルバ トレッキーノ";

  public const string NAME_SINIKIA_VEILHANZ = @"シニキア ヴェイルハンツ";
  public const string NAME_PERMA_WARAMY = @"ペルマ ワラミィ";
  public const string NAME_KILT_JORJU = @"キルト ジョルジュ";
  public const string NAME_SUN_YU = @"サン ユウ";
  public const string NAME_RVEL_ZELKIS = @"ルベル ゼルキス";
  public const string NAME_VAN_HEHGUSTEL = @"ヴァン ヘーグステル";
  public const string NAME_LADA_MYSTORUS = @"ラダ ミストゥルス";
  public const string NAME_SIN_OSCURETE = @"シン オスキュレーテ";
  public static string[] NAME_LIST = { NAME_EIN_WOLENCE, NAME_LANA_AMIRIA, NAME_EONE_FULNEA, NAME_BILLY_RAKI, NAME_ADEL_BRIGANDY, NAME_CALMANS_OHN,
                                       NAME_ANNA_HAMILTON, NAME_SELMOI_RO, NAME_MAGI_ZELKIS, NAME_LENE_COLTOS, NAME_SHUVALTZ_FLORE, NAME_KARTIN_MAI,
                                       NAME_JEDA_ARUS, NAME_ILZINA_MELDIETE, NAME_OHRYU_GENMA, NAME_DELVA_TRECKINO };
  #endregion

  #region "Enemy Name"
  public const string HELL_KERBEROS = "Hell Kerberos";
  public const string HELL_KERBEROS_JP = "地獄のケルベロス";

  // オーランの塔

  public const string _ = "";
  public const string _JP = "";
  #endregion

  #region "Event"
  //public static List<string> QUEST_EVENT_TITLE = new List<string>() {
  //  "国内外遠征許可証の入手",
  //  "国王エルミからの依頼",
  //  "鍛冶屋ヴァスタと会話",
  //  "ゼタニウム鉱石を採取",
  //  "マトックを探せ",
  //  "扉の鍵を探せ",
  //  "猛獣を撃破せよ",
  //  "毒から身を守ろう",
  //  "港町コチューシェへ",
  //  "ObsidianStoneの使い方",
  //  "試練の道 【茨】",
  //  "(Optional) ゴラトルム洞窟の探索",
  //  "ファージル宮殿への報告（ObsidianStone）",
  //  "キージク山道を抜けて",
  //  "ファージル宮殿への報告（異変に関する報告）",
  //  "海底神殿：ヴェルガス",
  //  "中立国：ムーンフォーダー",
  //  "見捨てられた廃墟の村：サリタン",
  //  "忍び寄る凶兆の表れ",
  //  "封印門：ダル",
  //  "焼かれし都にて",
  //  "難攻不落の要塞",
  //  "(Optional) 未開の地下洞窟ロスロン",
  //  "終戦：エデルガイゼン城",
  //  "神具の欠片",
  //  "里にまつわる伝説の神具",
  //  "【理】の起源：シス",
  //  "ラタ：すべてを遂げし者",
  //  "雪原の大樹に眠りしは叡智の印",
  //  "原罪ウォズム",
  //  "隠されしファージル宮殿の最深部",
  //  "神具が指し示すは、世界の【理】",
  //  "【理】世界創生の試練",
  //  "【理】起源滅亡の試練",
  //  "【理】無限回廊の試練",
  //  "究極の選択"
  // };

  //public static List<string> QUEST_EVENT_MESSAGE = new List<string>()
  //{
  //  "ファージル宮殿へと向かい、遠征許可証を入手しよう。ファージル宮殿はアンシェットの町から川沿いに北へ進めば見えてくる。身支度が整い次第、すぐに出発しよう。",
  //  "国内外遠征許可証を受理した際、国王エルミよりファージルエリアの港町コチューシェへ赴き調査を行うように依頼された。港町コチューシェはファージル区域の東側の海沿いにある。まずは東方面へ遠征してみよう。",
  //  "鍛冶屋ヴァスタに会いに行こう。ヴァスタはクヴェルタ街に住んでいる。",
  //  "ゼタニウム鉱石を５つ採取する様に依頼された。ゼタニウム鉱石はアーサリウム工場跡地のどこかにある様だ。謎のアイテムの正体を掴むためにも是非とも採取してこよう。",
  //  "アーサリウム工場跡地のどこかにマトックがあるという事がエオネ・フルネアから提言された。アーサリウム工場跡地内をくまなく探して、マトックを見つけ出そう。マトックを使えば岩壁を崩す事ができるはずだ。",
  //  "アーサリウム工場跡地の通路を進めていると大きな扉が見つかった。扉は施錠されており、鍵が無い限り開放は難しい。アーサリウム工場跡地内のどこかに鍵があるはずだ。探してみよう。",
  //  "",
  //  "アーサリウム工場跡地の奥を探索している最中、毒で充満しているエリアを発見した。対策なしでこのエリアにこれ以上足を踏み入れるわけにはいかない。毒から身を守れるアイテムを探してこよう。アイテムは、マトックを見つけた区画内のどこかにあるはずだ。",
  //  "謎のアイテムを鑑定した結果、本アイテムは部材の一つであることが判明した。他の部材については港町コチューシェで見かけたらしい。港町コチューシェへ向かおう。",
  //  "謎のアイテムはObsidianStoneと呼ばれる物であり、人類に叡智をもたらす物である。このアイテムの詳細についてはツァルマンの里の長老が知っている。ツァルマンの里へ赴き、そのアイテムの使い方を伝授してもらおう。",
  //  "ツァルマンとは実在する人物の名称ではなく、遥か過去よりこの里の秘境の場所に存在する何かを表わすワードであるという事を告げられた。ObsidianStoneについてはツァルマンと呼ばれる存在から詳細を聞いたほうが良いと長老から告げられた。試練の道【茨】へ挑みツァルマンとコンタクトを取ろう。",
  //  "里の長老からはゴラトルム洞窟については決して赴いては行けないと言われている。しかし、存在「ツァルマン」からは「挑む姿勢と、遂げる意志」の助言をもらっている。ゴラトルム洞窟へは赴くべきか・・・",
  //  "ObsidianStoneに関する情報は一通り得られた。いったんファージル宮殿へ帰還し、その内容をエルミおよびファラに報告しよう。",
  //  "ファージル宮殿から北東に向かうと、キージク山道がある。その山道の頂上にはオーランの塔が設置されている。その塔に赴き、周辺地域に何か変わった所が無いか見てきてほしいと依頼された。オーランの塔へ向かい、周辺地域に異常が起きていないか確認してこよう。",
  //  "オーランの塔から周辺を確認すると、いくつか異変がある箇所が確認された。ファージル宮殿へ帰還し、その内容をエルミおよびファラに報告しよう。",
  //  "「フィオーネの湖」中央に位置するヴェルガスの神殿は普段歩いては行けない箇所であるが、閉鎖されていた「洗状橋」が何者かによって可動させられているとの報告が入った。ヴェルガスの神殿には多くの未知なるモンスターが住んでおり、非常に危険である事が知られている。ヴェルガスの神殿へ赴き、神殿の状況を確認する事となった。",
  //  "ヴェルガスの神殿にて遭遇した人物から、中立国：ムーンフォーダー区域への入国許可証を得た。ムーンフォーダー区域内において、現在もなお不穏な出来事が発生しているため、その正体を突き止めるべく、まずは「清信者」達が集うアーケンダイン街へ入り情報を収集して欲しいとの依頼を連絡を受けた。",
  //  "アーケンダイン街の人々から聞いた情報によると、今は人が住んでいない廃墟サリタンにたびたび出入りしている不審な人物が目撃されている。廃墟サリタンに出入りしている人物を突き止めよう。",
  //  "廃墟サリタンで遭遇した人物は、神話王国の首都を収める国王本人だった。国王はつい先刻実施した神聖儀式により、凶兆のお告げを得ており、そこでは海底神殿ヴェルガスと廃墟サリタンに古来より封印せしObisidianStoneに関連する事象であるとの見解を得たとのこと。そのため、現在保持しているObisidianStoneを持って今すぐ神話王国の首都パルメティシアに訪れるように依頼された。",
  //  "ObisidianStoneに関する歴史をより深く紐解くため、ヴィンスガルデ王国へと続く「ダルの門」を開く事が必要である事をパルメティシア王より告げられた。王より受け取った鍵を用いて「ダルの門」を開き、ヴィンスガルデ王国にあるディル街へ訪問してほしいとの依頼を受けた。",
  //  "ディル街の人々は酷く荒んでいた。街が荒廃した理由は過去に起きた「戦乱ウォズム」により「主要都市ディスケル」が壊滅状態にさせられた事に起因する事が明らかとなった。ディスケルの跡地に赴き、まずは死者達の元へ酒と花を持っていき、弔いの儀式を行って欲しいようだ。",
  //  "死者の弔いを行い、ディル街に住む人々へその行いを伝えた。その結果、ディル街の人々は今の圧政に苦しむ事を嘆く事を止め、捨て身の決起を行い、ガンロー要塞への突撃を決意した。ガンロー要塞に向かい、ディル街の人々と共にガンロー要塞の総指揮官を打ち倒そう。",
  //  "ガンロー要塞より得た情報によると、エデルガイゼン城へ向かうまでの間、水面上を通過する事の出来る幻のルートが存在する事が判明している。そのルートを抜けた先には、未踏の地下洞窟ロスロンがあると言われている。幻のルートを探し、洞窟ロスロンを探索してみよう。",
  //  "当初、国王エルミから告げられた主目的はヴィンスガルデ王国へ赴き、その様子を探ってくる事だった。今となっては、その真意は明確であり、疑念をはさむ余地は無い。確固たる決意を秘めて、エデルガイゼン城へと向かおう。終戦はすぐそこまで来ている。",
  //  "エデルガイゼン城の国王よりある内容が伝えられた。それは、このエリア全域にまつわる神話の一つとして神具フェルトゥーシュにまつわる話だ。エデルガイゼン城の王より託されたパーツはその神具フェルトゥーシュの一部だという。この神具を完成させ、真の平和を志して欲しいと託されたのである。神具については、この城の先にある箇所にヒントを示す碑文があるというのだが、今はそこまで行く道筋は見えていない。一度ファージル宮殿へ戻り、国王エルミと相談してみよう。",
  //  "ファージル宮殿に国王エルミ、王妃ファラは居なかった。何が起きており、何が始まってしまったのか、彼らはまだ何一つ知らない状態に陥り困惑を隠せないでいた。そこへ王室の近衛隊長サンディより伝言が告げられた。「我を追い求めるは隠されし真実を追求する者。ツァルマンの里へ赴き、内なる扉を開くがよい。」　姿を消した国王と王妃を追うべく、ツァルマンの里へと向かおう。",
  //  "ゼールマンの里の長老より国王エルミおよび王妃ファラがここを訪れていた事を伝えられた。彼らの目的は伝説の神具を入手する事。伝説の神具はこの世界の【理】そのものであり、それを手にした者は絶対無二の力を会得することを教えられた。彼らは、この【理】を会得して全世界を支配しようとしている事が明らかとなった。国王と王妃を食い止めるべく、まずは【理】の起源を指し示す「シスの墓標」へと向かい、その【理】とは何であるかを知る必要があるだろう。",
  //  "墓標にて姿を現した思念体のシス。その存在から伝えられた内容は驚くべきものだった。【理】は存在に対する干渉律を示すものではなく、この世界の形成そのものを指すという内容である。戸惑いながらも伝えられた内容を受け止めた結果、国王エルミと王妃ファラが目指すべき地点が明らかとなった。本大陸の片隅にひっそりとそびえたつ「ラタの緑小屋」。そこには伝説の神具を構築するために必要な物理事象が隠されているとの事。国王と王妃が向かった先へと歩を進めよう。",
  //  "ラタの小屋で国王エルミと王妃ファラに遭遇し、会話を終えたその直後だった。彼らは転送の儀式を詠唱し、姿を消し去ったのだ。行先については詳しくは語られなかったが、その直後に床に置かれていた手紙には次のように記載されていた。【ウォズムの原罪を断ち切る。力を貸して欲しい】。ウォズムの地は聖なる区域とされており、原則立ち入る事は許されていない。立ち入るためには、ムーンフォーダー区域にある雪原の大樹に宿る生命体と接触し、叡智の印を授与する事。進むべき道は決まった。今すぐ雪原の大樹へ向かおう。",
  //  "雪原の大樹より「叡智の印」を授かり、国王エルミと同じ転送の儀式を習得した。目指す目的地は離島ウォズム。そこに何があるのか。何が起こるのか。何が迫っているのか。ファージル国王エルミの想いは計りないが、それを知るために転送の儀式を使い、離島ウォズムの地へ足を運ぼう。今、すべてが明らかになる。",
  //  "国王エルミは離島ウォズムの地で永眠した。その姿を惜しむ間もなく、その場に思念体シスが現れ、これから起こる事象について告げられた。その内容は、世界における【理】が崩れつつある事、そしてそれを食い止めるためには、今手元に入手している伝説の神具を完成体にさせる必要があるという事だ。完成体にする方法はただ一つ。ファージル宮殿が建設された地点の中央最深部に赴き、この世界の「るつぼ」と呼ばれる地点に到着する事。そしてその地点にある【無限螺旋の鏡】に神具かざそう。",
  //  "伝説の神具：フェルトゥーシュが完成した。同時に思念体となったエルミからは、これまでに起きた様々な事象はすべて確実に予期されていた【定め】である事が伝えられた。ここから先は思念体となったエルミ、そしてシスにも【定め】は見えていない。手元の神具フェルトゥーシュはただただ光を放ち続ける。指し示すは一点【天上界ジェネシスゲート】。そこには世界の【理】そのものが存在する。神具を手にし、固い決意を秘め、【天上界ジェネシスゲート】へと駆け上がるのだ。",
  //  "【理】が示すは世界の創生にまつわる過去の歴史。天上界ジェネシスゲートの第一層を探索し、世界の創生に関する事象を見定めよう。そして、第二層へと通じている【天翔の門】へと赴き,本階層をクリアしよう。",
  //  "【理】が示すは起源滅亡にまつわる未来の定め。天上界ジェネシスゲートの第二層を探索し、起源の滅亡に関する事象を見定めよう。そして、第三層へと通じている【深淵の門】へと赴き,本階層をクリアしよう。",
  //  "【理】が示すは無限回廊にまつわる現在そのもの。天上界ジェネシスゲートの第三層を探索し、現世の渦に関する事象を見定めよう。そして、最終層へと通じている【無因の門】へと赴き、本階層をクリアしよう。",
  //  "【理】は【すべて】を【選択】によって終わらせようとしている。【すべて】とは何か。そして選ぶべき【選択】とは何か。【理】が示した【究極の選択】と相対し【解】を提示しよう。",
  //};

  public const string QUEST_TITLE_1 = "国内外遠征許可証の入手";
  public const string QUEST_DESC_1 = "ファージル宮殿へと向かい、遠征許可証を入手しよう。ファージル宮殿はアンシェットの町から川沿いに北へ進めば見えてくる。身支度が整い次第、すぐに出発しよう。";

  public const string QUEST_TITLE_2 = "国王エルミからの依頼";
  public const string QUEST_DESC_2 = "国内外遠征許可証を受理した際、国王エルミよりファージルエリアの港町コチューシェへ赴き調査を行うように依頼された。港町コチューシェはファージル区域の東側の海沿いにある。まずは東方面へ遠征してみよう。";
  public const string QUEST_DESC_2_2 = "港町コチューシェに着いたアイン達は【奇妙な物体】が何であるかを知るため、ツァルマンの里へ向かう事を決意した。ツァルマンの里の詳細な場所は把握出来ていないが、旅を続ける事で見つけられるとアインは直感していた。まずは、北方面のヴィンスガルデ王国に続く山道ルートの方へ歩を進める事にした。";
  public const string QUEST_DESC_2_3 = "ツァルマンの里にたどり着いたアイン達は、里の長老と話をしていたが、その途中で突如追い返されてしまった。その直後、使者からの伝令により一度ファージル宮殿へ戻るよう告げられた。行く先を失ったアインはひとまず使者の伝令に従いファージル宮殿へと戻り、事の顛末を国王に報告する事とした。";

  public const string QUEST_TITLE_3 = "鍛冶屋ヴァスタと会話";
  public const string QUEST_DESC_3 = "鍛冶屋ヴァスタに会いに行こう。ヴァスタはファージル宮殿から東の方角へ真っ直ぐ進んだ所にあるクヴェルタ街に住んでいる。";

  public const string QUEST_TITLE_4 = "ゼタニウム鉱石を採取";
  public const string QUEST_DESC_4 = "ゼタニウム鉱石を５つ採取する様に依頼された。ゼタニウム鉱石はアーサリウム工場跡地のどこかにある様だ。謎のアイテムの正体を掴むためにも是非とも採取してこよう。";

  public const string QUEST_TITLE_5 = "マトックを探せ";
  public const string QUEST_DESC_5 = "アーサリウム工場跡地のどこかにマトックがあるという事をエオネ・フルネアから教えてもらった。アーサリウム工場跡地内をくまなく探して、マトックを見つけ出そう。マトックを使えば岩壁を崩す事ができるはずだ。";

  public const string QUEST_TITLE_6 = "扉の鍵を探せ";
  public const string QUEST_DESC_6 = "アーサリウム工場跡地の通路を進めていると大きな扉が見つかった。扉は施錠されており、鍵が無い限り開放は難しい。アーサリウム工場跡地内のどこかに鍵があるはずだ。探してみよう。";

  public const string QUEST_TITLE_7 = "猛獣を撃破せよ";
  public const string QUEST_DESC_7 = "細い通路の手前口にある看板では、こう示されていた。『本エリア奥にて凶暴な生物が発生。至急、本通路を封鎖する。』\r\n\r\n通常とは違った強力なモンスターが待ち構えている可能性がある。本エリアでは慎重に探索を進めて行こう。";

  public const string QUEST_TITLE_8 = "毒から身を守ろう";
  public const string QUEST_DESC_8 = "アーサリウム工場跡地を探索している最中、毒で充満しているエリアを発見した。対策なしでこのエリアにこれ以上足を踏み入れるわけにはいかない。毒から身を守れるアイテムを探してこよう。アイテムは、マトックを見つけた区画内のどこかにあるはずだ。";

  public const string QUEST_TITLE_9 = "奥に潜む不穏な気配";
  public const string QUEST_DESC_9 = "中央通路の扉を解除した後、ただならぬ雰囲気をパーティ全員は感じ取った。この先、明らかに何かが待ち受けている。アイン達は気を引き締めて奥へと進もうとしている。準備を万全にして挑んだ方が良いだろう。";

  public const string QUEST_TITLE_10 = "奇妙な物体に関する調査";
  public const string QUEST_DESC_10 = "アーサリウム工場跡地のボスを撃破した後、奥地で奇妙な物体を入手した。本アイテムが何を示す物なのかは全くの不明であり、この場で解析は行えない。本アイテムについてどうやって調査するか方針を決めようと考えたアインは、一旦クヴェルタ街に戻る事とした。クヴェルタ街に戻り、パーティメンバーと会話しよう。";

  public const string QUEST_TITLE_11 = "国王エルミからの依頼２";
  public const string QUEST_DESC_11 = "ツァルマンの里からファージル宮殿へと戻ったアイン達は次の指令としてオーランの塔へ赴き、本大陸の視察をしてくるように依頼を受けた。オーランの塔はこのファージル宮殿から北東に進んだ所にある様だ。北東へと進みオーランの塔を目指そう。";
  public const string QUEST_DESC_11_2 = "オーランの塔、最上階へと到達し展望台から本大陸の視察を行ったアイン達は、奇妙な薄赤い星が空にある事を確認した。この薄赤い星が何を意味するのかは分かってないが、少なくともその情報については一旦国王に伝えておいた方が良いとアインは判断した。ファージル宮殿へと戻り、謁見の間にて国王エルミと対談しよう。";

  public const string QUEST_TITLE_20 = "塔最上階からの気配";
  public const string QUEST_DESC_20 = "オーランの塔最上階へと上る階段にて、流れ込んでくる異質な風をパーティ全員は感じ取った。この先、何かが待ち受けている事だけは間違いない。準備を万全にして挑んだ方が良いだろう。";

  public const string QUEST_TITLE_21 = "国王エルミからの依頼３";
  public const string QUEST_DESC_21 = "オーランの塔から見えた奇妙な赤い星、およびそれ以外にも見えた内容について国王へ報告を行った。国王エルミからは次の指令としてムーンフォーダー方面にあるアーケンダイン街を目指すよう依頼を受けた。準備を万全に整え、アーケンダイン街を目指そう。";
  public const string QUEST_DESC_21_2 = "アーケンダイン街に到着したアイン達は、早速聞き込みを開始する事とした。アーケンダイン街を一通り回り、街の人と会話しよう。";

  public const string QUEST_TITLE_22 = "隠されしは【神秘の森】";
  public const string QUEST_DESC_22 = "アーケンダイン街の中央噴水広場を行き交う町の人から、ここアーケンダイン街とツァルマンの里は過去において、交易ルートが存在していた事が分かった。交易ルートはアイン達が通ってきた道のりがそのまま交易路として使われていたようだ。その当時、ツァルマンの里の奥には不可侵なる領域【神秘の森】が存在していたという噂が流れていたという。今もその【神秘の森】があるか定かではないが、ツァルマンの里にもう一度訪れる事で判明するかもしれない。ツァルマンの里へ赴き、長老ともう一度対話を行おう。";
  public const string QUEST_DESC_22_2 = "ツァルマンの里にいる長老に【神秘の森】を問い合わせた結果、聖なる場所として管理されており、アイン達は入る事を許してもらう事が出来なかった。しかし長老は、アデル・ブリガンディという者にお使いを指示し、そのお使いに同行する形で認めてくれたようだ。アデル・ブリガンディと共に【神秘の森】を探索してみよう。きっと何か見つかるはずだ。";

  public const string QUEST_TITLE_23 = "赤き星はマーブルスター";
  public const string QUEST_DESC_23 = "アーケンダイン街の「占いの館：アミンダ」にて、赤い星について聞いた所、アインは占い師からマーブル・スターを提供される形となった。このアイテムが何のために使用されるのかは定かではないが、アインはひとまずこのアイテムについては【サリタンの地】を訪れる事を勧められた。【サリタンの地】を探し、このアイテムについて情報を入手しよう。";

  public const string QUEST_TITLE_24 = "エオネ・フルネアの正体";
  public const string QUEST_DESC_24 = "アーケンダイン街にある「ワッツの民芸品店」をうろついていた所、アインは店の裏口で暇を持て余していた時、偶然にもエオネ・フルネアの声を聴いた。エオネ・フルネアは他の誰かを何か重要な話をしていたようだが、上手く聞き取る事は出来なかった。しかし、会話の中で唯一【パルメティシア神殿】に関する情報は聞き取る事が出来た。エオネ・フルネアが何者であり、何を実行しようとしているのかは今のアインでは知る術はないが、パルメテイシア神殿には必ず何か得られる情報がある事は確かな様だ。パルメテイシア神殿へ赴き、エオネ・フルネアに関する情報を入手しよう。";
  public const string QUEST_DESC_24_2 = "パルメテイシア神殿の法王に謁見した所、エオネ・フルネアとコンタクトを取るためには、「天の名」が必要であることが分かった。「天の名」を取得する方法は現時点では見つかっていないが、道はきっと拓けるという事をパルメテイシア法王より聞かされた。まずは、「天の名」について知っている人物を探そう。";

  public const string DECISION_ESCAPE_FROM_DUNGEON = "遠見の青水晶（ダンジョンからの帰還）";
  public const string DECISION_TRANSFER_TOWN = "遠見の青水晶（街へのワープ）";
  public const string DECISION_ARTHARIUM_CLIFF = "アーサリウム工場跡地：崖の下へ";
  public const string DECISION_ARTHARIUM_CLIFF_END = "アーサリウム工場跡地：元の通路へ";
  public const string DECISION_ARTHARIUM_CRASH_DOOR = "アーサリウム工場跡地：扉を蹴破れ！";
  public const string DECISION_ARTHARIUM_CRASH_DOOR2 = "アーサリウム工場跡地：扉を蹴破れ！（２）";
  public const string DECISION_PARTY_JOIN_SELMOI_RO = "セルモイ・ロウを仲間に引き入れる";
  #endregion

  #region "食事メニュー"
  // １階
  public const string FOOD_KATUCARRY = @"激辛カツカレー定食";
  public const string FOOD_OLIVE_AND_ONION = @"オリーブパンとオニオンスープ";
  public const string FOOD_INAGO_AND_TAMAGO = @"イナゴの佃煮と卵和え定食";
  public const string FOOD_USAGI = @"ウサギ肉のシチュー";
  public const string FOOD_SANMA = @"サンマ定食（煮物添え）";
  // ２階
  public const string FOOD_FISH_GURATAN = @"フィッシュ・グラタン";
  public const string FOOD_SEA_TENPURA = @"海鮮サクサク天プラ";
  public const string FOOD_TRUTH_YAMINABE_1 = @"真実の闇鍋（パート１）";
  public const string FOOD_OSAKANA_ZINGISKAN = @"お魚ジンギスカン";
  public const string FOOD_RED_HOT_SPAGHETTI = @"レッドホット・スパゲッティ";
  // ３階
  public const string FOOD_HINYARI_YASAI = @"ヒンヤリ・カリっと野菜定食";
  public const string FOOD_AZARASI_SHIOYAKI = @"白アザラシの塩焼き";
  public const string FOOD_WINTER_BEEF_CURRY = @"ウィンター・ビーフカレー";
  public const string FOOD_GATTURI_GOZEN = @"ガッツリ骨太御膳";
  public const string FOOD_KOGOERU_DESSERT = @"身も凍える・ブルーデザート";
  // ４階
  public const string FOOD_BLACK_BUTTER_SPAGHETTI = @"ブラックバター・スパゲッティ";
  public const string FOOD_KOROKORO_PIENUS_HAMBURG = @"コロコロ・ピーナッツ・ハンバーグ";
  public const string FOOD_PIRIKARA_HATIMITSU_STEAK = @"ピリ辛・ハチミツステーキ定食";
  public const string FOOD_HUNWARI_ORANGE_TOAST = @"ふんわり・オレンジトースト";
  public const string FOOD_TRUTH_YAMINABE_2 = @"真実の闇鍋（パート２）";

  public static string DESC_11 = DESC_11_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋５\r\n  技\r\n  知\r\n  体＋５\r\n  心";
  public static string DESC_12 = DESC_12_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技\r\n  知\r\n  体＋５\r\n  心＋５";
  public static string DESC_13 = DESC_13_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技\r\n  知＋５\r\n  体\r\n  心＋５";
  public static string DESC_14 = DESC_14_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋５\r\n  技＋５\r\n  知\r\n  体\r\n  心";
  public static string DESC_15 = DESC_15_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技＋５\r\n  知＋５\r\n  体\r\n  心";

  public static string DESC_21 = DESC_21_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技＋３０\r\n  知\r\n  体＋２０\r\n  心";
  public static string DESC_22 = DESC_22_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋２０\r\n  技\r\n  知\r\n  体＋３０\r\n  心";
  public static string DESC_23 = DESC_23_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技\r\n  知＋２０\r\n  体\r\n  心＋３０";
  public static string DESC_24 = DESC_24_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋３０\r\n  技\r\n  知\r\n  体\r\n  心＋２０";
  public static string DESC_25 = DESC_25_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技\r\n  知＋３０\r\n  体＋２０\r\n  心";

  public static string DESC_31 = DESC_31_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技\r\n  知＋８０\r\n  体\r\n  心＋６０";
  public static string DESC_32 = DESC_32_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技＋８０\r\n  知＋６０\r\n  体＋６０\r\n  心";
  public static string DESC_33 = DESC_33_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋８０\r\n  技\r\n  知\r\n  体＋８０\r\n  心＋４０";
  public static string DESC_34 = DESC_34_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋５０\r\n  技＋５０\r\n  知＋５０\r\n  体＋５０\r\n  心＋５０";
  public static string DESC_35 = DESC_35_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技\r\n  知＋１５０\r\n  体＋１００\r\n  心";

  public static string DESC_41 = DESC_41_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技＋２５０\r\n  知＋２５０\r\n  体\r\n  心＋２５０";
  public static string DESC_42 = DESC_42_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋２５０\r\n  技\r\n  知\r\n  体＋２５０\r\n  心＋２５０";
  public static string DESC_43 = DESC_43_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋２５０\r\n  知＋２５０\r\n  知\r\n  体＋２５０";
  public static string DESC_44 = DESC_44_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技＋２５０\r\n  知＋２５０\r\n  体＋２５０\r\n  心";
  public static string DESC_45 = DESC_45_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋２５０\r\n  技＋２５０\r\n  知\r\n  体\r\n  心＋２５０";

  public const string DESC_11_MINI = "か・・・辛い！！でもウマイ！！\r\n　実はハンナが客に応じて辛い配分を全調整してるとの事。";
  public const string DESC_12_MINI = "ほんのりとするオリーブの香りと、アッサリ味に仕立ててあるオニオン味のスープ。非常に好評のため定番メニューの一つとなっている。";
  public const string DESC_13_MINI = "味自体が非常に絶妙で美味しく、歯ごたえも非常に良い。問題はその見た目だが・・・。";
  public const string DESC_14_MINI = "ウサギ独特の臭みを無くし、肉の旨みは残してある。歯ごたえがかなりあるが、噛めばかむほど味が出る。";
  public const string DESC_15_MINI = "魚本来の味を引き出しており、かつ、煮物と非常にマッチしてる。";

  public const string DESC_21_MINI = "新鮮な魚介類の素材を細切りにして散りばめてあるグラタン。";
  public const string DESC_22_MINI = "魚介類独特の臭みを完全に除去し、質の高いテンプラに仕上げられている。大きさ／柔らかさ／食べごたえ共に申し分なく、腹いっぱい食べられる。";
  public const string DESC_23_MINI = "真実は闇の中にこそ潜む。味だけは保証されてるらしい・・・。";
  public const string DESC_24_MINI = "魚とは思えないような歯ごたえのあるジンギスカン。食べた後の後味は良く、何度でも食べたくなる味付け。";
  public const string DESC_25_MINI = "真っ赤なスパゲッティだが、実は全然辛く無いらしい。\r\n　素材の原色を駆使し、着色は一切行ってないそうだ。";

  public const string DESC_31_MINI = "カリっと天ぷら粉で焼き上げた野菜天ぷら。\r\n野菜であることを忘れてしまうぐらい、非常に香ばしい食感が残る。";
  public const string DESC_32_MINI = "固くて歯ごたえの悪いアザラシ肉を十分にほぐし、凍らせた後、焼き、塩をまぶした究極の一品。";
  public const string DESC_33_MINI = "冬の季節、急激な温度変化により身が引き締まったビーフを使用したカレーライス。臭みは一切感じない。";
  public const string DESC_34_MINI = "肉、魚、豆、味噌汁、ご飯、煎茶。全てが揃ったバランスの良い定食。\r\nハンナおばさん自慢の定食。";
  public const string DESC_35_MINI = "何という青さ・・・見ただけで凍えてしまいそうだ。\r\n　食べた時の口いっぱいに広がる感触は一級品のデザートそのものである。";

  public const string DESC_41_MINI = "真っ黒な色のスパゲッティ\r\n見た目がかなり不気味だが・・・スパイスの効いた香りがする。";
  public const string DESC_42_MINI = "ハンバーグの中に小さめに切り刻んだピーナッツが入っている\r\nフワフワとしたジューシーな肉とカリっとしたピーナッツが食欲をそそる。";
  public const string DESC_43_MINI = "表面に真っ赤なトウガラシがかけられているヒレステーキ。\r\nその裏には実はほんのりとハチミツが隠し味として入っており、食べた者には辛さと甘さが同時に響き渡る。";
  public const string DESC_44_MINI = "１番人気のトースト定食といえば、このオレンジトースト。\r\nふんだんに塗られたオレンジジャムとホワイトクリームを乗せたバカでかいトーストは男女問わず人気の一品である。";
  public const string DESC_45_MINI = "食物の匂いが全くしない闇の鍋\r\n　ハンナ叔母さん曰く、美味しいモノはちゃんと入っているとの事。それを信じて食べるしか選択肢は無い。";

  public static int[] FOOD_11_VALUE = { 5, 0, 0, 5, 0 };
  public static int[] FOOD_12_VALUE = { 0, 0, 0, 5, 5 };
  public static int[] FOOD_13_VALUE = { 0, 0, 5, 0, 5 };
  public static int[] FOOD_14_VALUE = { 5, 5, 0, 0, 0 };
  public static int[] FOOD_15_VALUE = { 0, 5, 5, 0, 0 };
  public static int[] FOOD_21_VALUE = { 0, 30, 0, 20, 0 };
  public static int[] FOOD_22_VALUE = { 20, 0, 0, 30, 0 };
  public static int[] FOOD_23_VALUE = { 0, 0, 20, 0, 30 };
  public static int[] FOOD_24_VALUE = { 30, 0, 0, 0, 20 };
  public static int[] FOOD_25_VALUE = { 0, 0, 30, 20, 0 };
  public static int[] FOOD_31_VALUE = { 0, 0, 80, 0, 60 };
  public static int[] FOOD_32_VALUE = { 0, 80, 60, 60, 0 };
  public static int[] FOOD_33_VALUE = { 80, 0, 0, 80, 40 };
  public static int[] FOOD_34_VALUE = { 50, 50, 50, 50, 50 };
  public static int[] FOOD_35_VALUE = { 0, 0, 150, 100, 0 };
  public static int[] FOOD_41_VALUE = { 0, 250, 250, 0, 250 };
  public static int[] FOOD_42_VALUE = { 250, 0, 0, 250, 250 };
  public static int[] FOOD_43_VALUE = { 250, 0, 250, 250, 0 };
  public static int[] FOOD_44_VALUE = { 0, 250, 250, 250, 0 };
  public static int[] FOOD_45_VALUE = { 250, 250, 0, 0, 250 };
  #endregion

  #region "Action Command"
  // GlobalCommand
  public const string GLOBAL_ACTION_1 = "GlobalAction1";
  public const string GLOBAL_ACTION_2 = "GlobalAction2";
  public const string GLOBAL_ACTION_3 = "GlobalAction3";
  public const string GLOBAL_ACTION_4 = "GlobalAction4";
  public const string READY_BUTTON = "ReadyButton";
  public const string GO_BUTTON = "GoButton";
  public const string STOP_BUTTON = "StopButton";
  public const string RUNAWAY_BUTTON = "RunAwayButton";
  public const string LOG_BUTTON = "LogButton";

  // ActionCommand
  public const string NORMAL_ATTACK = "Normal Attack";
  public const string MAGIC_ATTACK = "Magic Attack";
  public const string DEFENSE = "Defense";
  public const string STAY = "Stay";
  public const string USE_RED_POTION = "RedPotion";

  // Delve I
  public const string FIRE_BALL = "Fire Ball";
  public const string FIRE_BALL_JP = "ファイア・ボール";
  public const string ICE_NEEDLE = "Ice Needle";
  public const string ICE_NEEDLE_JP = "アイス・ニードル";
  public const string FRESH_HEAL = "Fresh Heal";
  public const string FRESH_HEAL_JP = "フレッシュ・ヒール";
  public const string SHADOW_BLAST = "Shadow Blast";
  public const string SHADOW_BLAST_JP = "シャドウ・ブラスト";
  public const string AIR_CUTTER = "Air Cutter";
  public const string AIR_CUTTER_JP = "エア・カッター";
  public const string ROCK_SLAM = "Rock Slam";
  public const string ROCK_SLAM_JP = "ロック・スラム";
  public const string STRAIGHT_SMASH = "Straight Smash";
  public const string STRAIGHT_SMASH_JP = "ストレート・スマッシュ";
  public const string HUNTER_SHOT = "Hunter Shot";
  public const string HUNTER_SHOT_JP = "ハンター・ショット";
  public const string LEG_STRIKE = "Leg Strike";
  public const string LEG_STRIKE_JP = "レッグ・ストライク";
  public const string VENOM_SLASH = "Venom Slash";
  public const string VENOM_SLASH_JP = "ヴェノム・スラッシュ";
  public const string ENERGY_BOLT = "Energy Bolt";
  public const string ENERGY_BOLT_JP = "エナジー・ボルト";
  public const string SHIELD_BASH = "Shield Bash";
  public const string SHIELD_BASH_JP = "シールド・バッシュ";
  public const string AURA_OF_POWER = "Aura of Power";
  public const string AURA_OF_POWER_JP = "オーラ・オブ・パワー";
  public const string DISPEL_MAGIC = "Dispel Magic";
  public const string DISPEL_MAGIC_JP = "ディスペル・マジック";
  public const string TRUE_SIGHT = "True Sight";
  public const string TRUE_SIGHT_JP = "トゥルー・サイト";
  public const string HEART_OF_LIFE = "Heart of Life";
  public const string HEART_OF_LIFE_JP = "ハート・オブ・ライフ";
  public const string DARK_AURA = "Dark Aura";
  public const string DARK_AURA_JP = "ダーク・オーラ";
  public const string ORACLE_COMMAND = "Oracle Command";
  public const string ORACLE_COMMAND_JP = "オラクル・コマンド";

  // Devle II
  public const string FLAME_BLADE = "Flame Blade";
  public const string FLAME_BLADE_JP = "フレイム・ブレイド";
  public const string PURE_PURIFICATION = "Pure Purification";
  public const string PURE_PURIFICATION_JP = "ピュア・ピュリファイケーション";
  public const string DIVINE_CIRCLE = "Divine Circle";
  public const string DIVINE_CIRCLE_JP = "ディバイン・サークル";
  public const string BLOOD_SIGN = "Blood Sign";
  public const string BLOOD_SIGN_JP = "ブラッド・サイン";
  public const string STORM_ARMOR = "Storm Armor";
  public const string STORM_ARMOR_JP = "ストーム・アーマー";
  public const string SOLID_WALL = "Solid Wall";
  public const string SOLID_WALL_JP = "ソリッド・ウォール";
  public const string STANCE_OF_THE_BLADE = "Stance of the Blade";
  public const string STANCE_OF_THE_BLADE_JP = "スタンス・オブ・ブレイド";
  public const string MULTIPLE_SHOT = "Multiple Shot";
  public const string MULTIPLE_SHOT_JP = "マルチプル・ショット";
  public const string SPEED_STEP = "Speed Step";
  public const string SPEED_STEP_JP = "スピード・ステップ";
  public const string INVISIBLE_BIND = "Invisible Bind";
  public const string INVISIBLE_BIND_JP = "インヴィジブル・バインド";
  public const string IDEOLOGY_OF_SOPHISTICATION = "Ideology of Sophistication";
  public const string IDEOLOGY_OF_SOPHISTICATION_JP = "イデオロギー・洗練";
  public const string STANCE_OF_THE_GUARD = "Stance of the Guard";
  public const string STANCE_OF_THE_GUARD_JP = "スタンス・オブ・ガード";
  public const string SKY_SHIELD = "Sky Shield";
  public const string SKY_SHIELD_JP = "スカイ・シールド";
  public const string FLASH_COUNTER = "Flash Counter";
  public const string FLASH_COUNTER_JP = "フラッシュ・カウンター";
  public const string LAYLINE_SCHEMA = "Layline Schema";
  public const string LAYLINE_SCHEMA_JP = "レイライン・スキーマ";
  public const string FORTUNE_SPIRIT = "Fortune Spirit";
  public const string FORTUNE_SPIRIT_JP = "フォーチュン・スピリット";
  public const string STANCE_OF_THE_SHADE = "Stance of the Shade";
  public const string STANCE_OF_THE_SHADE_JP = "スタンス・オブ・シェイド";
  public const string SPIRITUAL_REST = "Spiritual Rest";
  public const string SPIRITUAL_REST_JP = "スピリチュアル・レスト";

  // Delve III
  public const string METEOR_BULLET = "Meteor Bullet";
  public const string BLUE_BULLET = "Blue Bullet";
  public const string HOLY_BREATH = "Holy Breath";
  public const string BLACK_CONTRACT = "Black Contract";
  public const string SONIC_PULSE = "Sonic Pulse";
  public const string EARTH_SURGE = "Earth Surge";
  public const string DOUBLE_SLASH = "Double Slash";
  public const string EYE_OF_THE_TRUTH = "Eye of the Truth";
  public const string BONE_CRUSH = "Bone Crush";
  public const string IRREGULAR_STEP = "Irregular Step";
  public const string SIGIL_OF_THE_PENDING = "Sigil of the Pending";
  public const string CONCUSSIVE_HIT = "Concussive Hit";
  public const string AETHER_DRIVE = "Aether Drive";
  public const string MUTE_IMPULSE = "Mute Impulse";
  public const string WORD_OF_POWER = "Word Of Power";
  public const string VOICE_OF_VIGOR = "Voice of Vigor";
  public const string KILLING_WAVE = "Killing Wave";
  public const string UNSEEN_AID = "Unseen Aid";

  // Delve IV
  public const string VOLCANIC_BLAZE = "Volcanic Blaze";
  public const string FREEZING_CUBE = "Freezing Cube";
  public const string ANGELIC_ECHO = "Angelic Echo";
  public const string CURSED_EVANGEL = "Cursed Evangel";
  public const string GALE_WIND = "Gale Wind";
  public const string SAND_BURST = "Sand Burst";
  public const string IRON_BASTER = "Iron Baster";
  public const string PENETRATION_ARROW = "Penetration Arrow";
  public const string DEADLY_DRIVE = "Deadly Drive";
  public const string ASSASSINATION_HIT = "Assassination Hit";
  public const string PHANTOM_OBORO = "Phantom Oboro";
  public const string DOMINATION_FIELD = "Domination Field";
  public const string CIRCLE_OF_THE_VIGOR = "Circle of the Vigor";
  public const string DETACHMENT_FAULT = "Detachment Fault";
  public const string WILL_AWAKENING = "Will Awakening";
  public const string AURA_BURN = "Aura Burn";
  public const string LEVEL_EATER = "Level Eater";
  public const string EXACT_TIME = "Exact Time";

  // Delve V
  public const string FLAME_STRIKE = "Frame Strike";
  public const string FROST_LANCE = "Frost Lance";
  public const string SHINING_HEAL = "Shining Heal";
  public const string CIRCLE_OF_THE_DESPAIR = "Circle of the Despair";
  public const string ERRATIC_THUNDER = "Erratic Thunder";
  public const string PETRIFICATION = "Petrification";
  public const string RAGING_STORM = "Raging Storm";
  public const string PRECISION_RANGE = "Precision Range";
  public const string UNINTENTIONAL_HIT = "Unintentional Hit";
  public const string COUNTER_DISALLOW = "Counter Disallow";
  public const string SIGIL_OF_THE_HOMURA = "Sigil of the Homura";
  public const string HARDEST_PARRY = "Hardest Parry";
  public const string REVOLUTION_AURA = "Revolution Aura";
  public const string OATH_OF_AEGIS = "Oath of Aegis";
  public const string EAGLE_EYE = "Eagle Eye";
  public const string EVERFLOW_MIND = "Everflow Mind";
  public const string ABYSS_EYE = "Abyss Eye";
  public const string INNER_INSPIRATION = "Inner Inspiration";

  // Delve VI
  public const string CIRCLE_OF_THE_IGNITE = "Circle of the Ignite";
  public const string WATER_PRESENCE = "Water Presence";
  public const string VALKYRIE_BLADE = "Valkyrie Blade";
  public const string THE_DARK_INTENSITY = "The Dark Intensity";
  public const string CYCLONE_FIELD = "Cyclone Field";
  public const string LIFE_GRACE = "Life Grace";
  public const string STANCE_OF_THE_IAI = "Stance of the Iai";
  public const string ETERNAL_CONCENTRATION = "Eternal Concentration";
  public const string STANCE_OF_MUIN = "Stance of Muin";
  public const string DIRTY_WISDOM = "Dirty Wisdom";
  public const string WORD_OF_PROPHECY = "Word of Prophecy";
  public const string WILD_SWING = "Wild Swing";
  public const string AUSTERITY_MATRIX = "Austerity Matrix";
  public const string FUTURE_VISION = "Future Vision";
  public const string SIGIL_OF_THE_FAITH = "Sigil of the Faith";
  public const string SOUL_SHOUT = "Soul Shout";
  public const string AVENGER_PROMISE = "Avenger Promise";
  public const string ZERO_IMMUNITY = "Zero Immunity";

  // Delve VII
  public const string LAVA_ANNIHILATION = "Lava Annihilation";
  public const string ABSOLUTE_ZERO = "Absolute Zero";
  public const string RESURRECTION = "Resurrection";
  public const string DEATH_SCYTHE = "Death Scythe";
  public const string LIGHTNING_SQUALL = "Lightning Squall";
  public const string EARTH_QUAKE = "Earth Quake";
  public const string KINETIC_SMASH = "Kinetic Smash";
  public const string PIERCING_ARROW = "Piercing Arrow";
  public const string CARNAGE_RUSH = "Carnage Rush";
  public const string AMBIDEXTERITY = "Ambidexterity";
  public const string TRANSCENDENCE_REACHED = "Transcendence Reached";
  public const string ONE_IMMUNITY = "One Immunity";
  public const string BRILLIANT_FORM = "Brilliant Form";
  public const string ESSENCE_OVERFLOW = "Essence Overflow";
  public const string STANCE_OF_THE_KOKOROE = "Stance of the Kokoroe";
  public const string OVERWHELMING_DESTINY = "Overwhelming Destiny";
  public const string DEMON_CONTRACT = "Demon Contract";
  public const string TIME_SKIP = "Time Skip";

  //public const string DESTROYER_SMASH = "Destroyer Smash";
  //public const string DEADLY_ARROW = "Deadly Arrow";
  //public const string CIRCLE_SLASH = "Circle Slash";
  //public const string PHANTASMAL_WIND = "Phantasmal Wind";
  //public const string WAR_SWING = "War Swing";
  //public const string HAWK_EYE = "Hawk Eye";
  //public const string DISSENSION_RHYTHM = "Dissension Rhythm";
  //public const string SANCTION_FIELD = "Sanction Field";
  //public const string WHISPER_VOICE = "Whisper Voice";
  //public const string CIRCLE_OF_THE_POWER = "Circle of the Power";
  //public const string SAFETY_FIELD = "Safety Field";
  //public const string VALKYRIE_BREAK = "Valkyrie Break";
  //public const string RUNE_STRIKE = "Rune Strike";
  //public const string WIND_RUNNER = "Wind Runner";
  //public const string KILLER_GAZE = "Killer Gaze";
  //public const string PIERCING_FLAME = "Piercing Flame";
  //public const string WATER_SPLASH = "Water Splash";
  //public const string WORD_OF_THE_REVOLUTION = "Word of the Revolution";
  //public const string TRANQUILITY = "Tranquility";

  // Monster Action
  public const string COMMAND_HIKKAKI = "ひっかき";
  public const string COMMAND_GREEN_NENEKI = "緑色の粘液";
  public const string COMMAND_KANAKIRI = "金切り声";
  public const string COMMAND_WILD_CLAW = "ワイルド・クロー";
  public const string COMMAND_KAMITSUKI = "かみつき";
  public const string COMMAND_TREE_SONG = "木々の歌声";
  public const string COMMAND_SUN_FIRE = "サン・ファイア";
  public const string COMMAND_TOSSHIN = "突進";
  public const string COMMAND_FEATHER_WING = "はばたき";
  public const string COMMAND_DASH_KERI = "ダッシュ蹴り";
  public const string COMMAND_SUITSUKU_TSUTA = "吸い付くツタ";
  public const string COMMAND_SPIDER_NET = "スパイダー・ネット";
  public const string COMMAND_POISON_KOKE = "毒ゴケ";
  public const string COMMAND_CONTINUOUS_ATTACK = "連続攻撃";
  public const string COMMAND_FIRE_EMISSION = "炎の放射";
  public const string COMMAND_SUPER_TOSSHIN = "猛突進";

  public const string COMMAND_POISON_RINPUN = "毒の鱗粉";
  public const string COMMAND_YOUEN_FIRE = "妖艶なる炎";
  public const string COMMAND_BLAZE_DANCE = "ブレイズ・ダンス";
  public const string COMMAND_DRILL_CYCLONE = "ドリル・サイクロン";
  public const string COMMAND_RUMBLE_MACHINEGUN = "ランブル・マシンガン";
  public const string COMMAND_STRUGGLE_VOICE = "威圧する怒声";
  public const string COMMAND_GAREKI_TSUBUTE = "ガレキの飛礫";
  public const string COMMAND_SHADOW_SPEAR = "シャドウ・スピア";
  public const string COMMAND_MIDARE_GIRI = "乱れ斬り";
  public const string COMMAND_MIRROR_SHIELD = "ミラー・シールド";
  public const string COMMAND_HAND_CANNON = "ハンド・キャノン";
  public const string COMMAND_SAIMIN_DANCE = "催眠ダンス";
  public const string COMMAND_POISON_NEEDLE = "毒針";
  public const string COMMAND_SPIKE_SHOT = "スパイク・ショット";
  public const string COMMAND_THUNDER_CLOUD = "サンダー・クラウド";
  public const string COMMAND_SPAAAARK = "SPAAAARK!!";
  public const string COMMAND_SUPER_RANDOM_CANNON = "超ランダム乱射";
  public const string COMMAND_ELECTRO_RAILGUN = "電導レールガン";
  public const string COMMAND_NOTHING = "なし";
  #endregion

  #region "Effect"
  public const string EFFECT_POISON = "Poison";
  public const string EFFECT_HEART_OF_LIFE = "Life Gain";
  public const string EFFECT_SHADOW_BLAST = "Blind Effect";
  public const string EFFECT_FORTUNE = "Fortune";
  public const string EFFECT_SLIP = "Slip";
  public const string EFFECT_STUN = "Stun";
  public const string EFFECT_BIND = "Bind";
  public const string EFFECT_SLEEP = "Sleep";
  public const string EFFECT_DIZZY = "Dizzy";
  public const string EFFECT_SILENT = "Silent";
  public const string EFFECT_SLOW = "Slow";
  public const string EFFECT_GAUGE_BACK = "Gauge Back";
  public const string EFFECT_PD_DOWN = "PD Down";

  public const string EFFECT_POWERUP_FIRE = "UP Fire";
  public const string EFFECT_POWERUP_ICE = "UP Ice";
  public const string EFFECT_POWERUP_LIGHT = "UP Light";
  public const string EFFECT_POWERUP_SHADOW = "UP Shadow";

  public const string BUFF_RESIST_STUN = "Resist Stun";
  public const string EFFECT_RESIST_STUN = "Stun耐性";
  public const string EFFECT_REMOVE_STUN = "Stun除去";

  public const string BUFF_PD_DOWN = "PhysicalDefenseDown";

  public const string BUFF_REMOVE_ALL = "BUFF全除去";
  #endregion

  #region "Item Name"
  public const string ITEMTYPE_MAIN_WEAPON = "Main Weapon";
  public const string ITEMTYPE_SUB_WEAPON = "Sub Weapon";
  public const string ITEMTYPE_ARMOR = "Armor";
  public const string ITEMTYPE_ACCESSORY1 = "Accessory-1";
  public const string ITEMTYPE_ACCESSORY2 = "Accessory-2";
  public const string ITEMTYPE_ARTIFACT = "Artifact";

  //// Normal
  ////public const string FINE_SWORD = "ファイン・ソード";
  ////public const string FINE_LANCE = "ファイン・ランス";
  ////public const string FINE_AXE = "ファイン・アクス";
  ////public const string FINE_CLAW = "ファイン・クロー";
  ////public const string FINE_BOW = "ファイン・ボウ";
  ////public const string FINE_ROD = "ファイン・ロッド";
  ////public const string FINE_ORB = "ファイン・オーブ";
  ////public const string FINE_BOOK = "ファイン・ブック";
  ////public const string FINE_SHIELD = "ファイン・シールド";
  ////public const string BASTARD_SWORD = "バスタード・ソード";
  ////public const string FINE_ARMOR = "ファイン・アーマー";
  ////public const string FINE_CROSS = "ファイン・クロス";
  ////public const string FINE_ROBE = "ファイン・ローブ";
  //// Uncommon
  ////public const string RED_PENDANT = "レッド・ペンダント";
  ////public const string BLUE_PENDANT = "ブルー・ペンダント";
  ////public const string PURPLE_PENDANT = "パープル・ペンダント";
  ////public const string GREEN_PENDANT = "グリーン・ペンダント";
  ////public const string YELLOW_PENDANT = "イエロー・ペンダント";
  ////public const string ELVISH_BOW = @"エルヴィッシュ・ボウ";

  ////public const string AERO_BLADE = "エアロ・ブレード";
  //public const string WINGED_LONG_BOW = @"ウィングド・ロング・ボウ";
  public const string GEAR_GENSEI = "ギア【厳正】";
  public const string MASTER_SWORD = "マスター・ソード";
  public const string MASTER_SHIELD = "マスター・シールド";
  public const string EDIL_BLACK_BLADE = "エディル・ブラック・ブレード";
  //public const string SMALL_RED_POTION = "小さい赤ポーション";
  #endregion

  #region "Area"
  public const string AREA_FAZIL = "ファージル";
  public const string AREA_VINSGARDE = "ヴィンスガルデ";
  public const string AREA_MOONFORDER = "ムーンフォーダー";

  public const string TOWN_ANSHET = "アンシェット街";
  public const string TOWN_QVELTA_TOWN = "クヴェルタ街";
  public const string TOWN_COTUHSYE = "港町コチューシェ";
  public const string TOWN_ZHALMAN = "ツァルマンの里";
  public const string TOWN_WOSM = "ウォズム村";
  public const string TOWN_ARCANEDINE = "アーケンダイン街";
  public const string TOWN_DALE = "ディルの街";
  public const string TOWER_OHRAN = "オーランの塔";
  public const string TOWN_LATA_HOSE = "ラタの小屋";
  public const string TOWN_ZELMAN = "ゼールマンの里";
  public const string TOWER_FRAN = "フーランの塔";
  public const string TOWN_FAZIL_CASTLE = "ファージル宮殿";
  public const string TOWN_PARMETYSIA = "パルメテイシア神殿";
  public const string TOWN_EDELGARZEN_CASTLE = "エデルガイゼン城";

  public const string DUNGEON_CAVEOFSARUN = "サルンの洞窟";
  public const string DUNGEON_ARTHARIUM_FACTORY = "アーサリウム工場跡地";
  public const string DUNGEON_GORATRUM_CAVE = "ゴラトルムの洞窟";
  public const string DUNGEON_OHRAN_TOWER = "オーランの塔";
  public const string DUNGEON_VELGUS_SEA_TEMPLE = "ヴェルガス海底神殿";
  public const string DUNGEON_MYSTIC_FOREST = "神秘の森";
  public const string DUNGEON_GATE_OF_DHAL = "ダルの門";
  public const string DUNGEON_RUINS_OF_SARITAN = "廃墟サリタン";
  public const string DUNGEON_SNOWTREE_LATA = "雪原の大樹ラタ";
  public const string DUNGEON_DISKEL_BATTLE_FIELD = "ディスケル戦場跡地";
  public const string DUNGEON_SITH_GRAVEYARD = "シスの墓標";
  public const string DUNGEON_GANRO_FORTRESS = "ガンロー要塞";
  public const string DUNGEON_LOSLON_CAVE = "ロスロンの洞窟";
  public const string DUNGEON_HEAVENS_GENESIS_GATE = "天上界ジェネシスゲート";
  // todo ダルの門

  public const string FIELD_ESMILIA_GRASS_AREA = "エスミリア草原区域";
  public const string FIELD_ARTHARIUM_FACTORY = "アーサリウム工場跡地";
  public const string FIELD_GORATRUM_DUNGEON = "ゴラトルムの洞窟";
  public const string FIELD_ZHALMAN_VILLAGE = "ツァルマンの里";
  public const string FIELD_KIZIK_MOUNTAIN_ROAD = "キージク山道";
  public const string FIELD_ORAN_TOWER = "オーランの塔";
  public const string FIELD_ESMILIA_GRASS_TOWNROD = "エスミリア草原街道";
  public const string FIELD_VELGUS_SEA_TEMPLE = "ヴェルガスの海底神殿";
  public const string FIELD_MOONFORDER_SNOW_AREA = "ムーンフォーダー雪原区域";
  public const string FIELD_RUINS_OF_SARITAN = "廃墟サリタン";
  public const string FIELD_WOSM_ISOLATED_ISLAND = "離島ウォズム";
  public const string FIELD_VINSGARDE_OLDROAD = "ヴィンスガルデ古道";
  public const string FIELD_DISKEL_BATTLE_FIELD = "ディスケル戦場地";
  public const string FIELD_GANRO_FORTRESS = "ガンロー要塞";
  public const string FIELD_LOSLON_DUNGEON = "ロスロンの洞窟";
  public const string FIELD_EDELGARZEN_CASTLE = "エデルガイゼン城";
  public const string FIELD_MYSTIC_ZELMAN = "秘境の地ゼールマン";
  public const string FIELD_SNOWTREE_LATA = "雪原の大樹ラタ";
  public const string FIELD_KILCOOD_MOUNTAIN_AREA = "キルクード山岳地帯";
  public const string FIELD_HEAVENS_GENESIS_GATE = "天上界ジェネシスゲート";
  #endregion

  public const string GUARDIAN_ANGEL_RED = "炎授天使";
  public const string GUARDIAN_ANGEL_BLUE = "蒼授天使";
  public const string GUARDIAN_ANGEL_BLACK = "断罪天使";
  public const string GUARDIAN_ANGEL_WHITE = "珀流天使";

  #region "DungeonMapFile"
  public const string MAPFILE_BASE_FIELD = "MapData_BaseField.txt";
  public const string MAPFILE_CAVEOFSARUN = "MapData_CaveOfSarun.txt";
  public const string MAPFILE_ARTHARIUM = "MapData_Artharium.txt";
  public const string MAPFILE_GORATRUM = "MapData_Goratrum.txt";
  public const string MAPFILE_GORATRUM_2 = "MapData_Goratrum_2.txt";
  public const string MAPFILE_VELGUS = "MapData_Velgus.txt";
  public const string MAPFILE_OHRAN_TOWER = "MapData_OhranTower.txt";
  public const string MAPFILE_MYSTIC_FOREST = "MapData_MysticForest.txt";
  public const string MAPFILE_GATE_OF_DHAL = "MapData_GateOfDhal.txt";
  public const string MAPFILE_SARITAN = "MapData_Saritan.txt";
  public const string MAPFILE_SNOWTREELATA = "MapData_SnowTreeLata.txt";
  public const string MAPFILE_DISKEL = "MapData_Diskel.txt";
  public const string MAPFILE_GANRO = "MapData_Ganro.txt";
  public const string MAPFILE_LOSLON = "MapData_Loslon.txt";
  public const string MAPFILE_EDELGARZEN = "MapData_EdelGaizen.txt";
  public const string MAPFILE_GENESISGATE = "MapData_GenesisGate.txt";

  public const int MAPSIZE_X_CAVEOFSARUN = 40;
  public const int MAPSIZE_Z_CAVEOFSARUN = 20;

  public const int MAPSIZE_X_GORATRUM = 40;
  public const int MAPSIZE_Z_GORATRUM = 20;

  #endregion

  #region "Limit"
  public static int MAX_BACKPACK_SIZE = 9999;
  public static int MAX_ITEM_STACK_SIZE = 10;
  public static int MAX_TEAM_MEMBER = 4;
  public static int MAX_INSTANT_NUM = 9;
  #endregion

  #region "etc"
  public const int BATTLEEND_AUTOEXIT = 200;
  #endregion

}
