using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Fix
{
  #region "enum"
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
    SwordMaster,
    HighFighter,
    MageMaster,
    HighSorcerer,
    WeaponMaster,
    DualSeeker
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

  public enum CriticalType
  {
    None,
    Random,
    Absolute,
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

  public enum TargetSelectType
  {
    None,
    Forward,
    Behind,
    Random,
  }

  public enum MonsterArea
  {
    None,
    Area11,
    Area12,
    Area13,
    Area14,
    Boss1,
    TruthBoss1,
    Area21,
    Area22,
    Area23,
    Area24,
    Boss21,
    Boss22,
    Boss23,
    Boss24,
    Boss25,
    Boss2,
    TruthBoss2,
    Area31,
    Area32,
    Area33,
    Area34,
    Boss3,
    TruthBoss3,
    Area41,
    Area42,
    Area43,
    Area44,
    Boss4,
    TruthBoss4,
    Area51,
    Boss5,
    TruthBoss5,
    Area46,
    Duel,
    LastBoss,
  }

  public enum RareString
  {
    Legendary,
    Purple,
    Gold,
    Red,
    Blue,
    Black
  }

  public enum DropItemCategory
  {
    Battle,
    Lottery,
  }
  #endregion

  #region "Battle"
  #region "Battle Gauge"
  public const int BATTLE_CORE_SLEEP = 0;
  public const int BASE_TIMER_BAR_LENGTH = 30000;
  public const int BASE_TIMER_DIV = 36;
  public const int TIMER_ICON_NUM = 8;
  public const int MAX_INSTANT_POINT = 1000;
  public const int GLOBAL_INSTANT_MAX = 1000;
  public const int AP_BASE = 100;
  #endregion
  #region "Battle Effect Message"
  public const string BATTLE_MISS = "Miss";
  public const string BATTLE_DIZZY_MISS = "Dizzy Miss";
  public const string BATTLE_AP_LESS = "No AP";
  public const string BATTLE_SP_LESS = "No SP";
  public const string BATTLE_NO_POTION = "No Potion";
  public const string BATTLE_ALREADY_USED = "空っぽ";
  public const string BATTLE_BIND = "Bind";
  public const string BATTLE_DIVINE = "Divine";
  public const string BATTLE_SILENT = "Silent";
  #endregion
  #region "Character Color"
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
  #endregion
  #region "Buff Effect"
  public const string EFFECT_HEART_OF_LIFE = "Life Gain";
  public const string EFFECT_SHADOW_BLAST = "Blind Effect";
  public const string EFFECT_FORTUNE = "Fortune";

  public const string EFFECT_GAUGE_BACK = "Gauge Back";

  public const string EFFECT_PA_UP = "PA Up";
  public const string EFFECT_PA_DOWN = "PA Down";
  public const string EFFECT_PD_UP = "PD Up";
  public const string EFFECT_PD_DOWN = "PD Down";
  public const string EFFECT_MA_UP = "MA Up";
  public const string EFFECT_MA_DOWN = "MA Down";
  public const string EFFECT_MD_UP = "MD Up";
  public const string EFFECT_MD_DOWN = "MD Down";
  public const string EFFECT_BS_UP = "BS Up";
  public const string EFFECT_BS_DOWN = "BS Down";
  public const string EFFECT_BR_UP = "BR Up";
  public const string EFFECT_BR_DOWN = "BR Down";
  public const string EFFECT_PO_UP = "PO Up";
  public const string EFFECT_PO_DOWN = "PO Down";

  public const string EFFECT_POWERUP_FIRE = "UP Fire";
  public const string EFFECT_POWERUP_ICE = "UP Ice";
  public const string EFFECT_POWERUP_LIGHT = "UP Light";
  public const string EFFECT_POWERUP_SHADOW = "UP Shadow";
  public const string EFFECT_POWERUP_WIND = "UP Wind";
  public const string EFFECT_POWERUP_EARTH = "UP Earth";

  public const string EFFECT_POISON = "Poison";
  public const string EFFECT_SILENT = "Silent"; // Silence,アイコンも一緒に変名する。
  public const string EFFECT_BIND = "Bind";
  public const string EFFECT_SLEEP = "Sleep";
  public const string EFFECT_STUN = "Stun";
  public const string EFFECT_PARALYZE = "Paralyze";
  public const string EFFECT_FREEZE = "Freeze";
  public const string EFFECT_FEAR = "Fear";
  public const string EFFECT_TEMPTATION = "Temptation";
  public const string EFFECT_SLOW = "Slow";
  public const string EFFECT_DIZZY = "Dizzy";
  public const string EFFECT_SLIP = "Slip";
  public const string EFFECT_CANNOT_RESURRECT = "Cannot Resurrect";

  public const string BUFF_RESIST_POISON = "Resist Poison";
  public const string BUFF_RESIST_SILENCE = "Resist Silence";
  public const string BUFF_RESIST_BIND = "Resist Bind";
  public const string BUFF_RESIST_SLEEP = "Resist Sleep";
  public const string BUFF_RESIST_STUN = "Resist Stun";
  public const string BUFF_RESIST_PARALYZE = "Resist Paralyze";
  public const string BUFF_RESIST_FREEZE = "Resist Freeze";
  public const string BUFF_RESIST_FEAR = "Resist Fear";
  public const string BUFF_RESIST_TEMPTATION = "Resist Temptation";
  public const string BUFF_RESIST_SLOW = "Resist Slow";
  public const string BUFF_RESIST_DIZZY = "Resist Dizzy";
  public const string BUFF_RESIST_SLIP = "Resist Slip";
  public const string BUFF_RESIST_CANNOT_RESURRECT = "Resist Cannot-Resurrect";

  public const string EFFECT_RESIST_POISON = "Poison耐性";
  public const string EFFECT_REMOVE_POISON = "Poison除去";
  public const string EFFECT_RESIST_SILENCE = "Silence耐性";
  public const string EFFECT_REMOVE_SILENCE = "Silence除去";
  public const string EFFECT_RESIST_BIND = "Bind耐性";
  public const string EFFECT_REMOVE_BIND = "Bind除去";
  public const string EFFECT_RESIST_SLEEP = "Sleep耐性";
  public const string EFFECT_REMOVE_SLEEP = "Sleep除去";
  public const string EFFECT_RESIST_STUN = "Stun耐性";
  public const string EFFECT_REMOVE_STUN = "Stun除去";
  public const string EFFECT_RESIST_PARALYZE = "Paralyze耐性";
  public const string EFFECT_REMOVE_PARALYZE = "Paralyze除去";
  public const string EFFECT_RESIST_FREEZE = "Freeze耐性";
  public const string EFFECT_REMOVE_FREEZE = "Freeze除去";
  public const string EFFECT_RESIST_FEAR = "Fear耐性";
  public const string EFFECT_REMOVE_FEAR = "Fear除去";
  public const string EFFECT_RESIST_TEMPTATION = "Temptation耐性";
  public const string EFFECT_REMOVE_TEMPTATION = "Temptation除去";
  public const string EFFECT_RESIST_SLOW = "Slow耐性";
  public const string EFFECT_REMOVE_SLOW = "Slow除去";
  public const string EFFECT_RESIST_DIZZY = "Dizzy耐性";
  public const string EFFECT_REMOVE_DIZZY = "Dizzy除去";
  public const string EFFECT_RESIST_SLIP = "Slip耐性";
  public const string EFFECT_REMOVE_SLIP = "Slip除去";
  public const string EFFECT_RESIST_CANNOT_RESURRECT = "CannotResurrect耐性";
  public const string EFFECT_REMOVE_CANNOT_RESURRECT = "CannotResurrect除去";

  public const string BUFF_PA_UP = "BuffPhysicalAttackUp";
  public const string BUFF_PA_DOWN = "BuffPhysicalAttackDown";
  public const string BUFF_PD_UP = "BuffPhysicalDefenseUp";
  public const string BUFF_PD_DOWN = "BuffPhysicalDefenseDown";
  public const string BUFF_MA_UP = "BuffMagicAttackUp";
  public const string BUFF_MA_DOWN = "BuffMagicAttackDown";
  public const string BUFF_MD_UP = "BuffMagicDefenseUp";
  public const string BUFF_MD_DOWN = "BuffMagicDefenseDown";
  public const string BUFF_BS_UP = "BuffBattleSpeedUp";
  public const string BUFF_BS_DOWN = "BuffBattleSpeedDown";
  public const string BUFF_BR_UP = "BuffBattleResponseUp";
  public const string BUFF_BR_DOWN = "BuffBattleResponseDown";
  public const string BUFF_PO_UP = "BuffPotentialUp";
  public const string BUFF_PO_DOWN = "BuffPotentialDown";

  public const string BUFF_REMOVE_ALL = "BUFF全除去";

  public const string BUFF_SYUTYU_DANZETSU = "SYUTYU-DANZETSU";

  public const string BUFF_LIGHTNING_OUTBURST = "Lightning Outburst";
  #endregion
  #region "Timer"
  public const int BATTLEEND_AUTOEXIT = 200;
  #endregion
  #endregion

  #region "Environment"
  #region "Program Data"
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

  public const int MAPSIZE_X_MYSTICFOREST = 50;
  public const int MAPSIZE_Z_MYSTICFOREST = 30;

  #endregion
  #region "Sound File"
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
  #region "Unity Scene"
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
  public const string SCENE_HELP_BOOK = @"HelpBook";
  #endregion
  #region "Limit"
  public const int INFINITY = 9999999;
  public static int MAX_BACKPACK_SIZE = 9999;
  public static int MAX_ITEM_STACK_SIZE = 10;
  public static int MAX_TEAM_MEMBER = 4;
  public static int MAX_ENEMY_MEMBER = 6;
  public static int MAX_INSTANT_NUM = 9;
  #endregion
  #endregion

  #region "Quest Event"
  #region "Quest List ( not used )"
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
  public const string QUEST_DESC_2 = "国内外遠征許可証を受理した際、国王エルミよりファージルエリアの港町コチューシェへ赴き調査を行うように依頼された。港町コチューシェはファージル区域の東側の海沿いにあるが、その途中でゴラトラム洞窟を潜り抜ける必要がある。ゴラトラム洞窟を突破し、港町コチューシェへ辿り着こう。";
  public const string QUEST_DESC_2_2 = "港町コチューシェに着いたアイン達は、傭兵ビリー・ラキと合流し、神秘の森へ向かう事を決意した。神秘の森に関する詳細な情報は入手できていないが、この旅を続ける事で見つけられるとアインは直感していた。";
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
  #region "Area Description"
  public const string AREA_INFO_ANSHET = "アンシェットの町はファージル宮殿から南方面への川沿いを下った所でひっそりと栄えている町である。行商人の行き来は少ないが、町全体としては安定しており、人々は穏やかな生活を送っている。";
  public const string AREA_INFO_CAVEOFSARUN = "エスミリア草原区域にある獣道。ファージル宮殿とアンシェットの町はこの通路で行き来が行われる。モンスターが出現するが危険度【高】のモンスターが出現する事はなく、道なりに進めば、危険に見舞われる事は少ない。";
  public const string AREA_INFO_FAZIL_CASTLE = "ファージル区域全土を統治する国王エルミ・ジョルジュが住まうファージル宮殿。ファージル宮殿の裏には数々のワープゲートが設置されており、国王であるエルミ・ジョルジュ、王妃ファラ・フローレ、魔道学院の長シニキア・カールハンツ、正義の暴君オル・ランディス、存在不可視のヴェルゼ・アーティが日々各エリアの状況把握に努めている。ファージル全土で犯罪発生率が低く、一般市民が平和に暮らせているのは彼らの加護があるからに他ならない。";
  public const string AREA_INFO_GORATRUM_CAVE = "人々を魅了する鍾乳洞は、観光地として多くの旅行者をひきつけた場所である。今では鍾乳洞は僅かしか残っておらず、地の奥底からモンスターが出没するようになっているため、一般の人々がここを訪れる事は無い。探索に行くのであれば、入念な準備を怠らない事だ。";
  public const string AREA_INFO_COTUHSYE = "この港町には様々な職業の者が行き来している。国王エルミは本エリアを交流の場の一つとして制定しており、出入りについて制限は設けていないため交易が盛んである。だが、現在は船の出航制限がかかっており、ここからヴィンスガルデ王国行きの船は出ていない。";
  public const string AREA_INFO_MYSTIC_FOREST = "立ち入る人々を深淵なる濃霧へと誘う【神秘の森】。その場の見通しの悪さに加え、モンスターからの襲撃が繰り返し行われるため、方向感覚を失い、そのまま行方不明となる者が後を絶えない。進むためには入念なる準備が必要となるだろう。";
  #endregion
  #endregion

  #region "Food Menu"
  public const string FOOD_BALANCE_SET = "バランス定食";
  public const string FOOD_LARGE_GOHAN_SET = "山盛りごはんセット";
  public const string FOOD_TSIKARA_UDON = "タップリ 力うどん";
  public const string FOOD_ZUNOU_FLY_SET = "頭脳フライ定食";
  public const string FOOD_SPEED_SOBA = "おかわり蕎麦";

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

  public static string DESC_01 = DESC_01_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋１\r\n  技＋１\r\n  知＋１\r\n  体    \r\n  心    ";
  public static string DESC_02 = DESC_02_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力    \r\n  技    \r\n  知    \r\n  体＋３\r\n  心    ";
  public static string DESC_03 = DESC_03_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋３\r\n  技    \r\n  知    \r\n  体    \r\n  心    ";
  public static string DESC_04 = DESC_04_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力    \r\n  技    \r\n  知＋３\r\n  体    \r\n  心    ";
  public static string DESC_05 = DESC_05_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力    \r\n  技＋３\r\n  知    \r\n  体    \r\n  心    ";

  public static string DESC_11 = DESC_11_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋５\r\n  技\r\n  知\r\n  体＋５\r\n  心";
  public static string DESC_12 = DESC_12_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技\r\n  知\r\n  体＋５\r\n  心＋５";
  public static string DESC_13 = DESC_13_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技\r\n  知＋５\r\n  体\r\n  心＋５";
  public static string DESC_14 = DESC_14_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋５\r\n  技＋５\r\n  知\r\n  体\r\n  心";
  public static string DESC_15 = DESC_15_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力\r\n  技＋５\r\n  知＋５\r\n  体\r\n  心";

  public static string DESC_21 = DESC_21_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　\r\n  技＋８\r\n  知＋５\r\n  体＋３\r\n  心　　";
  public static string DESC_22 = DESC_22_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋３\r\n  技　　\r\n  知＋８\r\n  体＋５\r\n  心　　";
  public static string DESC_23 = DESC_23_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　\r\n  技　　\r\n  知＋３\r\n  体＋８\r\n  心＋５";
  public static string DESC_24 = DESC_24_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋８\r\n  技＋５\r\n  知　　\r\n  体　　\r\n  心＋３";
  public static string DESC_25 = DESC_25_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋５\r\n  技＋３\r\n  知　　\r\n  体　　\r\n  心＋８";

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

  public const string DESC_01_MINI = "体調を良くする事を意識して作られた定食。カロリーバランスが取れており、近隣の住人が良く食べに来る味付けとなっている。";
  public const string DESC_02_MINI = "腹ごしらえに最適なごはんセット。当然のごとく山盛りとなったごはんに加え、スタミナが十分につくおかずも多く盛られており、一部の客に人気がある";
  public const string DESC_03_MINI = "力を付けたければ、まずはこのうどんセットで決まり。特別な理由はないが、これを食べた次の日、非常にやる気が出ると好評。";
  public const string DESC_04_MINI = "どこから仕入れてきたか分からない魚類をフライとして仕立てている。味は非常に濃厚で特徴的。食べると脳内が活性化して知力がＵＰするというもっぱらの噂。";
  public const string DESC_05_MINI = "食べても食べても追加され続ける蕎麦。美味しくて飽きがこないが、途中でストップしないと・・・";

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

  public static int[] FOOD_01_VALUE = { 1, 1, 1, 0, 0 };
  public static int[] FOOD_02_VALUE = { 0, 0, 0, 3, 0 };
  public static int[] FOOD_03_VALUE = { 3, 0, 0, 0, 0 };
  public static int[] FOOD_04_VALUE = { 0, 0, 3, 0, 0 };
  public static int[] FOOD_05_VALUE = { 0, 3, 0, 0, 0 };

  public static int[] FOOD_11_VALUE = { 5, 0, 0, 5, 0 };
  public static int[] FOOD_12_VALUE = { 0, 0, 0, 5, 5 };
  public static int[] FOOD_13_VALUE = { 0, 0, 5, 0, 5 };
  public static int[] FOOD_14_VALUE = { 5, 5, 0, 0, 0 };
  public static int[] FOOD_15_VALUE = { 0, 5, 5, 0, 0 };

  public static int[] FOOD_21_VALUE = { 0, 8, 5, 3, 0 };
  public static int[] FOOD_22_VALUE = { 3, 0, 8, 5, 0 };
  public static int[] FOOD_23_VALUE = { 0, 0, 3, 8, 5 };
  public static int[] FOOD_24_VALUE = { 8, 5, 0, 0, 3 };
  public static int[] FOOD_25_VALUE = { 5, 3, 0, 0, 8 };

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

  #region "GUI Label"
  #region "クラス属性ラベル(JP)"
  public const string CLASS_WARRIOR_JP = "戦士";
  public const string CLASS_ARCHERY_JP = "弓術";
  public const string CLASS_MARTIAL_ARTS_JP = "格闘";
  public const string CLASS_COMBAT_TRICK_JP = "計略";
  public const string CLASS_WONDER_HERMIT_JP = "仙術";
  public const string CLASS_GUARDIAN_JP = "護衛";
  public const string CLASS_FIRE_JP = "炎";
  public const string CLASS_ICE_JP = "氷";
  public const string CLASS_HOLYLIGHT = "聖";
  public const string CLASS_DARK_MAGIC = "闇";
  public const string CLASS_WIND = "風";
  public const string CLASS_EARTH = "土";
  public const string CLASS_ENHANCE = "進化";
  public const string CLASS_MYSTIC = "神秘";
  public const string CLASS_BRAVE = "勇敢";
  public const string CLASS_VENGEANCE = "復讐";
  public const string CLASS_TRUTH = "心眼";
  public const string CLASS_MINDFULNESS = "無心";
  #endregion

  #region "コマンドタイミング属性ラベル(JP)"
  public const string TIMING_TYPE_INSTANT = "インスタント";
  public const string TIMING_TYPE_NORMAL = "ノーマル";
  public const string TIMING_TYPE_SORCERY = "ソーサリー";
  #endregion

  #region "コマンド対象属性ラベル(JP)"
  public const string TARGET_TYPE_ENEMY = "敵単体";
  public const string TARGET_TYPE_ALLY = "味方単体";
  public const string TARGET_TYPE_ENEMYGROUP = "敵全体";
  public const string TARGET_TYPE_ALLYGROUP = "味方全体";
  public const string TARGET_TYPE_ENEMYFIELD = "敵フィールド";
  public const string TARGET_TYPE_ALLYFIELD = "味方フィールド";
  public const string TARGET_TYPE_ALLMEMBER = "敵味方全体";
  public const string TARGET_TYPE_ENEMYORALLY = "敵単体 / 味方単体";
  public const string TARGET_TYPE_INSTANTTARGET = "インスタント対象";
  public const string TARGET_TYPE_OWN = "自分自身";
  public const string TARGET_TYPE_NONE = "なし";
  #endregion

  #region "ヘルプメニューラベル(JP)"
  public const string HELPMENU_ACTIONCOMMAND = "アクションコマンド";
  public const string HELPMENUL_BATTLE = "バトル関連";
  #endregion

  #region "ホームタウンSHOPメニューラベル(JP)"
  public const string SHOPMENU_BUY = "購入";
  public const string SHOPMENU_SELL = "売却";
  #endregion
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
  public const string STAY_2 = "Stay_2";
  public const string USE_RED_POTION_1 = "RedPotion_1";
  public const string USE_RED_POTION_2 = "RedPotion_2";
  public const string USE_RED_POTION_3 = "RedPotion_3";
  public const string USE_RED_POTION_4 = "RedPotion_4";
  public const string USE_RED_POTION_5 = "RedPotion_5";
  public const string USE_RED_POTION_6 = "RedPotion_6";
  public const string USE_RED_POTION_7 = "RedPotion_7";
  public const string USE_BLUE_POTION_1 = "BluePotion_1";
  public const string USE_BLUE_POTION_2 = "BluePotion_2";
  public const string USE_BLUE_POTION_3 = "BluePotion_3";
  public const string USE_BLUE_POTION_4 = "BluePotion_4";
  public const string USE_BLUE_POTION_5 = "BluePotion_5";
  public const string USE_BLUE_POTION_6 = "BluePotion_6";
  public const string USE_BLUE_POTION_7 = "BluePotion_7";

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
  public const string HEART_OF_LIFE = "Heart of Life";
  public const string HEART_OF_LIFE_JP = "ハート・オブ・ライフ";
  public const string DARK_AURA = "Dark Aura";
  public const string DARK_AURA_JP = "ダーク・オーラ";
  public const string TRUE_SIGHT = "True Sight";
  public const string TRUE_SIGHT_JP = "トゥルー・サイト";
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
  public const string FORTUNE_SPIRIT = "Fortune Spirit";
  public const string FORTUNE_SPIRIT_JP = "フォーチュン・スピリット";
  public const string STANCE_OF_THE_SHADE = "Stance of the Shade";
  public const string STANCE_OF_THE_SHADE_JP = "スタンス・オブ・シェイド";
  public const string LAYLINE_SCHEMA = "Layline Schema";
  public const string LAYLINE_SCHEMA_JP = "レイライン・スキーマ";
  public const string SPIRITUAL_REST = "Spiritual Rest";
  public const string SPIRITUAL_REST_JP = "スピリチュアル・レスト";

  // Delve III
  public const string METEOR_BULLET = "Meteor Bullet";
  public const string METEOR_BULLET_JP = "メテオ・バレット";
  public const string BLUE_BULLET = "Blue Bullet";
  public const string BLUE_BULLET_JP = "ブルー・バレット";
  public const string HOLY_BREATH = "Holy Breath";
  public const string HOLY_BREATH_JP = "ホーリー・ブレス";
  public const string BLACK_CONTRACT = "Black Contract";
  public const string BLACK_CONTRACT_JP = "ブラック・コントラクト";
  public const string SONIC_PULSE = "Sonic Pulse";
  public const string SONIC_PULSE_JP = "ソニック・パルス";
  public const string LAND_SHATTER = "Land Shatter";
  public const string LAND_SHATTER_JP = "ランド・シャッター";
  public const string DOUBLE_SLASH = "Double Slash";
  public const string DOUBLE_SLASH_JP = "ダブル・スラッシュ";
  public const string EYE_OF_THE_ISSHIN = "Eye of the Isshin";
  public const string EYE_OF_THE_ISSHIN_JP = "一心の眼";
  public const string BONE_CRUSH = "Bone Crush";
  public const string BONE_CRUSH_JP = "ボーン・クラッシュ";
  public const string IRREGULAR_STEP = "Irregular Step";
  public const string IRREGULAR_STEP_JP = "イレギュラー・ステップ";
  public const string SIGIL_OF_THE_PENDING = "Sigil of the Pending";
  public const string SIGIL_OF_THE_PENDING_JP = "シギル・オブ・ペンディング";
  public const string CONCUSSIVE_HIT = "Concussive Hit";
  public const string CONCUSSIVE_HIT_JP = "コンカッシヴ・ヒット";
  public const string AETHER_DRIVE = "Aether Drive";
  public const string AETHER_DRIVE_JP = "エーテル・ドライブ";
  public const string MUTE_IMPULSE = "Mute Impulse";
  public const string MUTE_IMPULSE_JP = "ミュート・インパルス";
  public const string VOICE_OF_VIGOR = "Voice of Vigor";
  public const string VOICE_OF_VIGOR_JP = "ヴォイス・オブ・ヴィゴー";
  public const string KILLING_WAVE = "Killing Wave";
  public const string KILLING_WAVE_JP = "キリング・ウェイブ";
  public const string WORD_OF_POWER = "Word Of Power";
  public const string WORD_OF_POWER_JP = "ワード・オブ・パワー";
  public const string UNSEEN_AID = "Unseen Aid";
  public const string UNSEEN_AID_JP = "アンシーン・エイド";

  // Delve IV
  public const string VOLCANIC_BLAZE = "Volcanic Blaze";
  public const string VOLCANIC_BLAZE_JP = "ヴォルカニック・ブレイズ";
  public const string FREEZING_CUBE = "Freezing Cube";
  public const string FREEZING_CUBE_JP = "フリージング・キューブ";
  public const string ANGELIC_ECHO = "Angelic Echo";
  public const string ANGELIC_ECHO_JP = "エンジェリック・エコー";
  public const string CURSED_EVANGEL = "Cursed Evangel";
  public const string CURSED_EVANGEL_JP = "カーズド・エヴァンジール";
  public const string GALE_WIND = "Gale Wind";
  public const string GALE_WIND_JP = "ゲイル・ウィンド";
  public const string SAND_BURST = "Sand Burst";
  public const string SAND_BURST_JP = "サンド・バースト";
  public const string IRON_BASTER = "Iron Baster";
  public const string IRON_BASTER_JP = "アイアン・バスター";
  public const string PENETRATION_ARROW = "Penetration Arrow";
  public const string PENETRATION_ARROW_JP = "ペネトレーション・アロー";
  public const string DEADLY_DRIVE = "Deadly Drive";
  public const string DEADLY_DRIVE_JP = "デッドリー・ドライブ";
  public const string ASSASSINATION_HIT = "Assassination Hit";
  public const string ASSASSINATION_HIT_JP = "アサシネーション・ヒット";
  public const string PHANTOM_OBORO = "Phantom Oboro";
  public const string PHANTOM_OBORO_JP = "ファントム・朧";
  public const string DOMINATION_FIELD = "Domination Field";
  public const string DOMINATION_FIELD_JP = "ドミネーション・フィールド";
  public const string CIRCLE_OF_THE_VIGOR = "Circle of the Vigor";
  public const string CIRCLE_OF_THE_VIGOR_JP = "サークル・オブ・ヴィゴー";
  public const string DETACHMENT_FAULT = "Detachment Fault";
  public const string DETACHMENT_FAULT_JP = "デタッチメント・フォールト";
  public const string AURA_BURN = "Aura Burn";
  public const string AURA_BURN_JP = "オーラ・バーン";
  public const string LEVEL_EATER = "Level Eater";
  public const string LEVEL_EATER_JP = "レベル・イーター";
  public const string WILL_AWAKENING = "Will Awakening";
  public const string WILL_AWAKENING_JP = "ウィル・アウェイケニング";
  public const string EXACT_TIME = "Exact Time";
  public const string EXACT_TIME_JP = "イグザクト・タイム";

  // Delve V
  public const string FLAME_STRIKE = "Frame Strike";
  public const string FLAME_STRIKE_JP = "フレイム・ストライク";
  public const string FROST_LANCE = "Frost Lance";
  public const string FROST_LANCE_JP = "フロスト・ランス";
  public const string SHINING_HEAL = "Shining Heal";
  public const string SHINING_HEAL_JP = "シャイニング・ヒール";
  public const string CIRCLE_OF_THE_DESPAIR = "Circle of the Despair";
  public const string CIRCLE_OF_THE_DESPAIR_JP = "サークル・オブ・ディスペア";
  public const string ERRATIC_THUNDER = "Erratic Thunder";
  public const string ERRATIC_THUNDER_JP = "エラティック・サンダー";
  public const string PETRIFICATION = "Petrification";
  public const string PETRIFICATION_JP = "ペトリフィケーション";
  public const string RAGING_STORM = "Raging Storm";
  public const string RAGING_STORM_JP = "レイジング・ストーム";
  public const string PRECISION_STRIKE = "Precision Strike";
  public const string PRECISION_STRIKE_JP = "プレシジョン・ストライク";
  public const string UNINTENTIONAL_HIT = "Unintentional Hit";
  public const string UNINTENTIONAL_HIT_JP = "アンインテンショナル・ヒット";
  public const string COUNTER_DISALLOW = "Counter Disallow";
  public const string COUNTER_DISALLOW_JP = "カウンター・ディスアロウ";
  public const string SIGIL_OF_THE_HOMURA = "Sigil of the Homura";
  public const string SIGIL_OF_THE_HOMURA_JP = "シギル・オブ・ホムラ";
  public const string HARDEST_PARRY = "Hardest Parry";
  public const string HARDEST_PARRY_JP = "ハーデスト・パリィ";
  public const string REVOLUTION_AURA = "Revolution Aura";
  public const string REVOLUTION_AURA_JP = "レボリューション・オーラ";
  public const string OATH_OF_AEGIS = "Oath of Aegis";
  public const string OATH_OF_AEGIS_JP = "オース・オブ・イージス";
  public const string EVERFLOW_MIND = "Everflow Mind";
  public const string EVERFLOW_MIND_JP = "エバーフロー・マインド";
  public const string ABYSS_EYE = "Abyss Eye";
  public const string ABYSS_EYE_JP = "アビス・アイ";
  public const string MIND_FORCE = "Mind Force";
  public const string MIND_FORCE_JP = "精神の波動";
  public const string INNER_INSPIRATION = "Inner Inspiration";
  public const string INNER_INSPIRATION_JP = "インナー・インスピレーション";

  // Delve VI
  public const string CIRCLE_OF_THE_IGNITE = "Circle of the Ignite";
  public const string CIRCLE_OF_THE_IGNITE_JP = "サークル・オブ・イグニート";
  public const string WATER_PRESENCE = "Water Presence";
  public const string WATER_PRESENCE_JP = "ウォーター・プレゼンス";
  public const string VALKYRIE_BLADE = "Valkyrie Blade";
  public const string VALKYRIE_BLADE_JP = "ヴァルキリー・ブレイド";
  public const string THE_DARK_INTENSITY = "The Dark Intensity";
  public const string THE_DARK_INTENSITY_JP = "ザ・ダーク・インテンシティ";
  public const string CYCLONE_FIELD = "Cyclone Field";
  public const string CYCLONE_FIELD_JP = "サイクロン・フィールド";
  public const string LIFE_GRACE = "Life Grace";
  public const string LIFE_GRACE_JP = "ライフ・グレイス";
  public const string STANCE_OF_THE_IAI = "Stance of the Iai";
  public const string STANCE_OF_THE_IAI_JP = "スタンス・オブ・イアイ";
  public const string ETERNAL_CONCENTRATION = "Eternal Concentration";
  public const string ETERNAL_CONCENTRATION_JP = "エターナル・コンセントレーション";
  public const string STANCE_OF_MUIN = "Stance of Muin";
  public const string STANCE_OF_MUIN_JP = "無音の構え";
  public const string DIRTY_WISDOM = "Dirty Wisdom";
  public const string DIRTY_WISDOM_JP = "ダーティ・ウィズダム";
  public const string WORD_OF_PROPHECY = "Word of Prophecy";
  public const string WORD_OF_PROPHECY_JP = "ワード・オブ・プロフェシー";
  public const string WILD_SWING = "Wild Swing";
  public const string WILD_SWING_JP = "ワイルド・スウィング";
  public const string BRILLIANT_FORM = "Brilliant Form";
  public const string BRILLIANT_FORM_JP = "ブリリアント・フォーム";
  public const string FUTURE_VISION = "Future Vision";
  public const string FUTURE_VISION_JP = "フューチャー・ビジョン";
  public const string SOUL_SHOUT = "Soul Shout";
  public const string SOUL_SHOUT_JP = "ソウル・シャウト";
  public const string AVENGER_PROMISE = "Avenger Promise";
  public const string AVENGER_PROMISE_JP = "アヴェンジャー・プロミス";
  public const string SIGIL_OF_THE_FAITH = "Sigil of the Faith";
  public const string SIGIL_OF_THE_FAITH_JP = "シギル・オブ・フェイス";
  public const string ZERO_IMMUNITY = "Zero Immunity";
  public const string ZERO_IMMUNITY_JP = "ゼロ・イムーニティ";

  // Delve VII
  public const string LAVA_ANNIHILATION = "Lava Annihilation";
  public const string LAVA_ANNIHILATION_JP = "ラヴァ・アニヒレーション";
  public const string ABSOLUTE_ZERO = "Absolute Zero";
  public const string ABSOLUTE_ZERO_JP = "アブソリュート・ゼロ";
  public const string RESURRECTION = "Resurrection";
  public const string RESURRECTION_JP = "リザレクション";
  public const string DEATH_SCYTHE = "Death Scythe";
  public const string DEATH_SCYTHE_JP = "デス・サイズ";
  public const string LIGHTNING_SQUALL = "Lightning Squall";
  public const string LIGHTNING_SQUALL_JP = "ライトニング・スコール";
  public const string EARTH_QUAKE = "Earth Quake";
  public const string EARTH_QUAKE_JP = "アース・クェイク";
  public const string KINETIC_SMASH = "Kinetic Smash";
  public const string KINETIC_SMASH_JP = "キネティック・スマッシュ";
  public const string PIERCING_ARROW = "Piercing Arrow";
  public const string PIERCING_ARROW_JP = "ピアッシング・アロー";
  public const string CARNAGE_RUSH = "Carnage Rush";
  public const string CARNAGE_RUSH_JP = "カルネージ・ラッシュ";
  public const string AMBIDEXTERITY = "Ambidexterity";
  public const string AMBIDEXTERITY_JP = "アンビデキシタリティ";
  public const string TRANSCENDENCE_REACHED = "Transcendence Reached";
  public const string TRANSCENDENCE_REACHED_JP = "トランッセンデンス・リーチ";
  public const string ONE_IMMUNITY = "One Immunity";
  public const string ONE_IMMUNITY_JP = "ワン・イムーニティ";
  public const string AUSTERITY_MATRIX = "Austerity Matrix";
  public const string AUSTERITY_MATRIX_JP = "アウステリティ・マトリクス";
  public const string ESSENCE_OVERFLOW = "Essence Overflow";
  public const string ESSENCE_OVERFLOW_JP = "エッセンス・オーバーフロー";
  public const string OVERWHELMING_DESTINY = "Overwhelming Destiny";
  public const string OVERWHELMING_DESTINY_JP = "オーバーウェルミング・デスティニー";
  public const string DEMON_CONTRACT = "Demon Contract";
  public const string DEMON_CONTRACT_JP = "デーモン・コントラクト";
  public const string STANCE_OF_THE_KOKOROE = "Stance of the Kokoroe";
  public const string STANCE_OF_THE_KOKOROE_JP = "スタンス・オブ・心得";
  public const string TIME_SKIP = "Time Skip";
  public const string TIME_SKIP_JP = "タイム・スキップ";

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

  // 元核
  public const string ARCHETYPE_EIN_1 = "集中と断絶";
  public const string ARCHETYPE_LANA_1 = "完全なる詠唱";
  public const string ARCHETYPE_EONE_1 = "無感の讃歌";
  public const string ARCHETYPE_BILLY_1 = "勝利を我が手に！";
  public const string ARCHETYPE_ADEL_1 = "悠久なる記憶";
  public const string ARCHETYPE_RO_1 = "無二の構え";

  public const string ARCHETYPE_XXX_A = "循環の誓約"; // 旧ラナ
  public const string ARCHETYPE_XXX_B = "真実の破壊"; // 旧ヴェルゼ
  public const string ARCHETYPE_XXX_C = "オラオラオラァ！"; // 旧ランディス


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
  public const string COMMAND_STINKY_BREATH = "くさい吐息";
  public const string COMMAND_MIRROR_SHIELD = "ミラー・シールド";
  public const string COMMAND_HAND_CANNON = "ハンド・キャノン";
  public const string COMMAND_SAIMIN_DANCE = "催眠ダンス";
  public const string COMMAND_POISON_NEEDLE = "毒針";
  public const string COMMAND_CHARGE_LANCE = "チャージ・ランス";
  public const string COMMAND_SPIKE_SHOT = "スパイク・ショット";
  public const string COMMAND_JUBAKU_ON = "呪縛の怨";
  public const string COMMAND_ZINARI = "地鳴り";
  public const string COMMAND_BOUHATSU = "暴発";
  public const string COMMAND_THUNDER_CLOUD = "サンダー・クラウド";
  public const string COMMAND_SURUDOI_HIKKAKI = "するどい引掻き";
  public const string COMMAND_HAGESHII_KAMITSUKI = "はげしい噛みつき";
  public const string COMMAND_BOLT_FRAME = "ボルト・フレイム";
  public const string COMMAND_BOOOOMB = "ボム投下";
  public const string COMMAND_STONE_RAIN = "石の雨";
  public const string COMMAND_TARGETTING_SHOT = "狙い撃ち";
  public const string COMMAND_POWERED_ATTACK = "強襲";
  public const string COMMAND_SUSPICIOUS_VIAL = "怪しい薬瓶";
  public const string COMMAND_SPAAAARK = "SPAAAARK!!";
  public const string COMMAND_SUPER_RANDOM_CANNON = "超ランダム乱射";
  public const string COMMAND_ELECTRO_RAILGUN = "電導レールガン";
  public const string COMMAND_LIGHTNING_OUTBURST = "ライトニング・アウトバースト";

  public const string COMMAND_WILD_STORM = "ワイルド・ストーム";
  public const string COMMAND_YOUKAIEKI = "溶解液";
  public const string COMMAND_POISON_TONGUE = "猛毒の舌";
  public const string COMMAND_CONSTRICT = "締めつけ";
  public const string COMMAND_NOTHING = "なし";
  #endregion

  #region "Essence Tree"
  public const string SWORD_TRAINING = "剣の基礎訓練";
  public const string LANCE_TRAINING = "槍の基礎訓練";
  public const string AXE_TRAINING = "斧の基礎訓練";
  public const string CLAW_TRAINING = "爪の基礎訓練";
  public const string ROD_TRAINING = "杖の基礎訓練";
  public const string BOOK_TRAINING = "本の基礎訓練";
  public const string ORB_TRAINING = "水晶の基礎訓練";
  public const string BOW_TRAINING = "弓の基礎訓練";
  public const string SHIELD_TRAINING = "盾の基礎訓練";
  public const string WAY_OF_POTENTIAL = "潜在能力への意志";
  public const string GIFT_OF_TWIN = "双律の開眼";
  public const string TIME_EXPANSION = "時間律への干渉";
  public const string BREATHING_DANCE = "舞踏の呼吸";
  public const string MAGIC_SPELL_STANCE = "魔法詠唱の構え";
  public const string MIKIRI_SENSE = "見切りのセンス";
  public const string WAY_OF_SWORD = "剣への憧れ";
  public const string NEED_MORE_POWER = "パワーへの欲求";
  public const string RUSH_STANCE = "ラッシュの構え";
  public const string MASTER_TEACHING = "師範の教え";
  public const string TWIN_OFFENSIVE_STANCE = "双勢の構え";

  public const string STYLE_GLADIATOR = "Gladiator";
  public const string STYLE_GLADIATOR_JP = "グラディエーター";
  public const string STYLE_DEFENDER = "Defender";
  public const string STYLE_DEFENDER_JP = "ディフェンダー";
  public const string STYLE_BRAVE_SEEKER = "Brave Seeker";
  public const string STYLE_BRAVE_SEEKER_JP = "ブレイブ・シーカー";
  public const string STYLE_SWORD_DANCER = "Sword Dancer";
  public const string STYLE_SWORD_DANCER_JP = "ソード・ダンサー";
  public const string STYLE_ELEMENTAL_WIZARD = "Elemental Wizard";
  public const string STYLE_ELEMENTAL_WIZARD_JP = "エレメンタル・ウィザード";
  public const string STYLE_MYSTIC_ENHANCER = "Mystic Enhancer";
  public const string STYLE_MYSTIC_ENHANCER_JP = "ミスティック・エンハンサー";
  public const string STYLE_AERIAL_HUNTER = "Aerial Hunter";
  public const string STYLE_AERIAL_HUNTER_JP = "エアリアル・ハンター";
  public const string STYLE_HIGH_PRIEST = "High Priest";
  public const string STYLE_HIGH_PRIEST_JP = "ハイ・プリースト";
  public const string STYLE_ROYAL_KNIGHT = "Royal Knight";
  public const string STYLE_ROYAL_KNIGHT_JP = "ロイヤル・ナイト";
  public const string STYLE_VOICE_CALLER = "Voice Caller";
  public const string STYLE_VOICE_CALLER_JP = "ヴォイス・コーラー";
  public const string STYLE_WAR_MASTER = "War Master";
  public const string STYLE_WAR_MASTER_JP = "ウォー・マスター";
  public const string STYLE_DRAGON_SLAYER = "Dragon Slayer";
  public const string STYLE_DRAGON_SLAYER_JP = "ドラゴン・スレイヤー";
  public const string STYLE_BARD_RANGER = "Bird Ranger";
  public const string STYLE_BARD_RANGER_JP = "バード・レンジャー";
  public const string STYLE_BATTLE_SAGE = "Battle Sage";
  public const string STYLE_BATTLE_SAGE_JP = "バトル・セイジ";
  public const string STYLE_ORACLE_COMMANDER = "Oracle Commander";
  public const string STYLE_ORACLE_COMMANDER_JP = "オラクル・コマンダー";
  public const string STYLE_MAGE_BREAKER = "Mage Breaker";
  public const string STYLE_MAGE_BREAKER_JP = "メイジ・ブレイカー";
  public const string STYLE_SHADOW_ROGUE = "Shadow Rogue";
  public const string STYLE_SHADOW_ROGUE_JP = "シャドウ・ローグ";
  public const string STYLE_DEMON_LOAD = "Demon Lord";
  public const string STYLE_DEMON_LOAD_JP = "デーモン・ロード";

  public const string ESSENCE_RANK_1 = "【 I 】";
  public const string ESSENCE_RANK_2 = "【 II 】";
  public const string ESSENCE_RANK_3 = "【 III 】";
  public const string ESSENCE_RANK_4 = "【 IV 】";
  public const string ESSENCE_RANK_5 = "【 V 】";
  #endregion

  #region "Item Name"
  #region "武具"
  #region "フェーズ【 Iー１ 】：サルン洞窟前の草原区域"
  public const string PRACTICE_SWORD = "練習用の剣";
  public const string PRACTICE_LANCE = "練習用の槍";
  public const string PRACTICE_AXE = "練習用の斧";
  public const string PRACTICE_CLAW = "練習用の爪";
  public const string PRACTICE_ROD = "練習用の杖";
  public const string PRACTICE_BOOK = "練習用の本";
  public const string PRACTICE_ORB = "練習用のオーブ";
  public const string PRACTICE_SHIELD = "練習用の盾";

  public const string FINE_SWORD = "ファイン・ソード";
  public const string FINE_LANCE = "ファイン・ランス";
  public const string FINE_AXE = "ファイン・アックス";
  public const string FINE_CLAW = "ファイン・クロー";
  public const string FINE_ROD = "ファイン・ロッド";
  public const string FINE_BOOK = "ファイン・ブック";
  public const string FINE_ORB = "ファイン・オーブ";
  public const string FINE_LARGE_SWORD = "ファイン・ラージ・ソード";
  public const string FINE_LARGE_LANCE = "ファイン・ラージ・ランス";
  public const string FINE_LARGE_AXE = "ファイン・ラージ・アックス";
  public const string FINE_BOW = "ファイン・ボウ";
  public const string FINE_LARGE_STAFF = "ファイン・ラージ・スタッフ";
  public const string FINE_SHIELD = "ファイン・シールド";
  public const string FINE_ARMOR = "ファイン・アーマー";
  public const string FINE_CROSS = "ファイン・クロス";
  public const string FINE_ROBE = "ファイン・ローブ";

  public const string HEAVY_ARMOR = "ヘヴィ・アーマー";
  public const string LEATHER_CROSS = "レザー・クロス";
  public const string COTTON_ROBE = "コットン・ローブ";

  public const string SURVIVAL_CLAW = "サバイバル・クロー";
  public const string RISING_FORCE_CLAW = "ライジング・フォース・クロー";
  public const string LIGHTNING_CLAW = "電光の爪";
  public const string BRONZE_SWORD = "ブロンズ・ソード";
  public const string SWORD_OF_LIFE = "ソード・オブ・ライフ";
  public const string AERO_BLADE = "疾風の剣";
  public const string MERGIZD_SOL_BLADE = "Mergizd Sol Blade";
  public const string SHARP_LANCE = "シャープ・ランス";
  public const string WHITE_PARGE_LANCE = "ホワイトパージ・ランス";
  public const string ICE_SPIRIT_LANCE = "氷魂の槍";
  public const string ICICLE_LONGBOW = "アイシクル・ロングボウ";
  public const string MUMYOU_BOW = "無明の弓";
  public const string VIKING_AXE = "バイキング・アックス";
  public const string EARTH_POWER_AXE = "土力の斧";
  public const string WARWOLF_AXE = "ワーウルフ・アックス";
  public const string ENERGY_ORB = "エナジー・オーブ";
  public const string LIVING_GROWTH_ORB = "リビング・グロース・オーブ";
  public const string RED_PILLER_ORB = "炎柱の水晶玉";
  public const string WOOD_ROD = "ウッド・ロッド";
  public const string TOUGH_TREE_ROD = "頑丈な樫の杖";
  public const string BLACK_SORCERER_ROD = "ブラック・ソーサラー・ロッド";
  public const string KINDNESS_BOOK = "カインドネス・ブック";
  public const string SAINT_FAITHFUL_BOOK = "セイント・フェイスフル・ブック";
  public const string MUIN_BOOK = "無印の魔導書";
  public const string KITE_SHIELD = "カイト・シールド";
  public const string SUPERIOR_FLAME_SHIELD = "スペリオル・フレイム・シールド";
  public const string BEGINNER_ARMOR = "初心者の鎧";
  public const string BEGINNER_CROSS = "初心者の舞踏衣";
  public const string BEGINNER_ROBE = "初心者のローブ";

  public const string HINJAKU_RING = "貧弱な腕輪";
  public const string USUYOGORETA_FEATHER = "薄汚れた付け羽";
  public const string NON_BRIGHT_ORB = "輝きの無い丸い球";
  public const string KUKEI_BANGLE = "矩形のバングル";
  public const string SUTERARESHI_EMBLEM = "捨てられし紋章";

  public const string ADJUSTABLE_BELT = "調整されたベルト";
  public const string BIRD_STATUE = "鳥の彫像";
  public const string SHAPED_FINGERRING = "整った形の指輪";
  public const string REFRESHED_MANTLE = "スッキリしたマント";
  public const string COOL_CROWN = "品性ある王冠";
  public const string FLAT_SHOES = "フラット・シューズ";
  public const string COMPACT_EARRING = "コンパクト・イヤリング";
  public const string POWER_BANDANA = "パワー・バンダナ";
  public const string CHERRY_CHOKER = "チェリー・チョーカー";
  public const string FIT_BANGLE = "フィット・バングル";
  public const string PRISM_EMBLEM = "プリズム・エムブレム";

  public const string RED_PENDANT = "レッド・ペンダント";
  public const string BLUE_PENDANT = "ブルー・ペンダント";
  public const string PURPLE_PENDANT = "パープル・ペンダント";
  public const string GREEN_PENDANT = "グリーン・ペンダント";
  public const string YELLOW_PENDANT = "イエロー・ペンダント";
  public const string WARRIOR_BRACER = "ウォーリア・ブレーサー";
  public const string STARDUST_CHARM = "星屑のお守り";
  public const string BOLT_STONE = "電流石";

  public const string BLUE_WIZARD_HAT = "ブルー・ウィザード・ハット";
  public const string FLAME_HAND_KEEPER = "フレイム・ハンド・キーパー";
  #endregion
  #region "フェーズ【 Iー２ 】：ゴラトラム洞窟"
  public const string CLASSICAL_SWORD = "クラシカル・ソード";
  public const string CLASSICAL_LANCE = "クラシカル・ランス";
  public const string CLASSICAL_AXE = "クラシカル・アックス";
  public const string CLASSICAL_CLAW = "クラシカル・クロー";
  public const string CLASSICAL_ROD = "クラシカル・ロッド";
  public const string CLASSICAL_BOOK = "クラシカル・ブック";
  public const string CLASSICAL_ORB = "クラシカル・オーブ";
  public const string CLASSICAL_LARGE_SWORD = "クラシカル・ラージ・ソード";
  public const string CLASSICAL_LARGE_LANCE = "クラシカル・ラージ・ランス";
  public const string CLASSICAL_LARGE_AXE = "クラシカル・ラージ・アックス";
  public const string CLASSICAL_BOW = "クラシカル・ボウ";
  public const string CLASSICAL_LARGE_STAFF = "クラシカル・ラージ・スタッフ";
  public const string CLASSICAL_SHIELD = "クラシカル・シールド";
  public const string CLASSICAL_ARMOR = "クラシカル・アーマー";
  public const string CLASSICAL_CROSS = "クラシカル・クロス";
  public const string CLASSICAL_ROBE = "クラシカル・ローブ";

  public const string SMASH_BLADE = "スマッシュ・ブレード";
  public const string STYLISH_LANCE = "スタイリッシュ・ランス";
  public const string LAND_AXE = "ランド・アックス";
  public const string SAVAGE_CLAW = "サベージ・クロー";
  public const string WINGED_ROD = "ウィングド・ロッド";
  public const string EXPERT_BOOK = "エキスパート・ブック";
  public const string FLOATING_ORB = "フローティング・オーブ";
  public const string ELVISH_BOW = "エルヴィッシュ・ボウ";
  public const string IRON_SHIELD = "アイアン・シールド";
  public const string IRON_ARMOR = "アイアン・アーマー";
  public const string CROSSCHAIN_MAIL = "クロスチェイン・メイル";
  public const string CHIFFON_ROBE = "シフォン・ローブ";

  public const string BLUE_LIGHTNING_SWORD = "ブルー・ライトニング・ソード";
  public const string ASH_EXCLUDE_LANCE = "アッシュ・エクスクルード・ランス";
  public const string BONE_CRUSH_AXE = "ボーン・クラッシュ・アックス";
  public const string COLD_SPLASH_CLAW = "コールド・スプラッシュ・クロー";
  public const string SEKISOUJU_ROD = "赤双授の杖";
  public const string GORGON_EYES_BOOK = "ゴルゴン・アイズ・ブック";
  public const string STAR_FUSION_ORB = "スター・フュージョン・オーブ";
  public const string MADAN_SHOOTING_STAR = "魔弾・シューティング・スター";
  public const string SILVER_EARTH_SHIELD = "シルバー・アース・シールド";
  public const string ROIZ_IMPERIAL_ARMOR = "ロイズ・インペリアル・アーマー";
  public const string SWIFT_THUNDER_CROSS = "スウィフト・サンダー・クロス";
  public const string CROWD_DIRGE_ROBE = "クラウド・ダージェ・ローブ";

  public const string HUANTEI_RING = "不安定なリング";
  public const string DEPRESS_FEATHER = "デプレス・フェザー";
  public const string STIFF_BELT = "窮屈なベルト";
  public const string LOST_NAME_EMBLEM = "名を失った紋章";
  public const string DAMAGED_STATUE = "傷アリの彫像";
  public const string USED_HQ_BOOTS = "古びた高級ブーツ";
  public const string MAGICLIGHT_FIRE = "マジックライト【炎】";
  public const string MAGICLIGHT_ICE = "マジックライト【氷】";
  public const string MAGICLIGHT_SHADOW = "マジックライト【闇】";
  public const string MAGICLIGHT_LIGHT = "マジックライト【聖】";
  public const string MAGICLIGHT_WIND = "マジックライト【風】";
  public const string MAGICLIGHT_EARTH = "マジックライト【土】";

  public const string COPPERRING_TIGER = "銅の腕輪『虎』";
  public const string COPPERRING_DORPHINE = "銅の腕輪『イルカ』";
  public const string COPPERRING_HORSE = "銅の腕輪『馬』";
  public const string COPPERRING_BEAR = "銅の腕輪『熊』";
  public const string COPPERRING_HAYABUSA = "銅の腕輪『隼』";
  public const string COPPERRING_OCTOPUS = "銅の腕輪『タコ』";
  public const string COPPERRING_RABBIT = "銅の腕輪『兎』";
  public const string COPPERRING_SPIDER = "銅の腕輪『蜘蛛』";
  public const string COPPERRING_DEER = "銅の腕輪『鹿』";
  public const string COPPERRING_ELEPHANT = "銅の腕輪『象』";

  public const string STEEL_ANKLET = "鋼鉄のアンクレット";
  public const string CLEAN_HEARBAND = "清潔な髪飾り";
  public const string TRUTH_GLASSES = "真実メガネ";
  public const string FIVECOLOR_COMPASS = "５色のコンパス";
  public const string ZEPHYR_FEATHER_BLUE = "ゼフィール・フェザー・蒼";
  public const string CRIMSON_GAUNTLET = "深紅のガントレット";
  public const string BURIED_DANZAIANGEL_STATUE = "闇に埋もれし断罪天使の偶像";
  public const string LIGHT_HAKURUANGEL_STATUE = "輝ける珀流天使の偶像";
  public const string JADE_NOBLE_CIRCLET = "翡翠色の高貴なサークレット";

  public const string ADILORB_OF_THE_GARVANDI = "AdilOrb of the Garvandi";

  public const string KODAIEIJU_EDA = "古代栄樹の枝";
  public const string SINSEISUI = "神聖水";
  public const string KIGAN_OFUDA = "祈願の御札";

  #endregion
  #region "フェーズ【 IIー１ 】：神秘の森"
  public const string SMART_SWORD = "スマート・ソード";
  public const string SMART_LANCE = "スマート・ランス";
  public const string SMART_AXE = "スマート・アックス";
  public const string SMART_CLAW = "スマート・クロー";
  public const string SMART_ROD = "スマート・ロッド";
  public const string SMART_BOOK = "スマート・ブック";
  public const string SMART_ORB = "スマート・オーブ";
  public const string SMART_LARGE_SWORD = "スマート・ラージ・ソード";
  public const string SMART_LARGE_LANCE = "スマート・ラージ・ランス";
  public const string SMART_LARGE_AXE = "スマート・ラージ・アックス";
  public const string SMART_BOW = "スマート・ボウ";
  public const string SMART_LARGE_STAFF = "スマート・ラージ・スタッフ";
  public const string SMART_SHIELD = "スマート・シールド";
  public const string SMART_ARMOR = "スマート・アーマー";
  public const string SMART_CROSS = "スマート・クロス";
  public const string SMART_ROBE = "スマート・ローブ";

  public const string DANCING_CLAW = "ダンシング・クロー";
  public const string CUTTING_BLADE = "カッティング・ブレード";
  public const string SWIFT_SPEAR = "スウィフト・スピア";
  public const string POWERED_AXE = "パワード・アックス";
  public const string LONG_BOW = "ロング・ボウ";
  public const string AUTUMN_ROD = "オータムン・ロッド";
  public const string BULKY_BOOK = "バルキー・ブック";
  public const string FOCUS_ORB = "フォーカス・オーブ";
  public const string WIDE_BUCKLER = "ワイド・バックラー";
  public const string GOTHIC_PLATE = "ゴシック・プレート";
  public const string SILK_ROBE = "シルク・ローブ";
  public const string WATERY_RING = "ウォータリー・リング";
  public const string SUPERIOR_FEATHER = "スペリオル・フェザー";
  public const string HEAVYWEIGHT_SHOULDER = "ヘビーウェイト・ショルダー";
  public const string TIGHT_BOOTS = "タイト・ブーツ";
  public const string GORGEOUS_MANTLE = "ゴージャス・マント";
  public const string SWEET_BANGLE = "スイート・バングル";
  public const string NAMELESS_HAT = "ネームレス・ハット";
  public const string WARM_LEGGUARD = "ウォーム・レッグガード";
  public const string RED_AMULET = "レッド・アミュレット";
  public const string BLUE_AMULET = "ブルー・アミュレット";
  public const string PURPLE_AMULET = "パープル・アミュレット";
  public const string GREEN_AMULET = "グリーン・アミュレット";
  public const string YELLOW_AMULET = "イエロー・アミュレット";
  #endregion
  #region "フェーズ【 IIー２ 】：オーランの塔"
  public const string SUPERIOR_SWORD = "スペリオル・ソード";
  public const string SUPERIOR_LANCE = "スペリオル・ランス";
  public const string SUPERIOR_AXE = "スペリオル・アックス";
  public const string SUPERIOR_CLAW = "スペリオル・クロー";
  public const string SUPERIOR_ROD = "スペリオル・ロッド";
  public const string SUPERIOR_BOOK = "スペリオル・ブック";
  public const string SUPERIOR_ORB = "スペリオル・オーブ";
  public const string SUPERIOR_LARGE_SWORD = "スペリオル・ラージ・ソード";
  public const string SUPERIOR_LARGE_LANCE = "スペリオル・ラージ・ランス";
  public const string SUPERIOR_LARGE_AXE = "スペリオル・ラージ・アックス";
  public const string SUPERIOR_BOW = "スペリオル・ボウ";
  public const string SUPERIOR_LARGE_STAFF = "スペリオル・ラージ・スタッフ";
  public const string SUPERIOR_SHIELD = "スペリオル・シールド";
  public const string SUPERIOR_ARMOR = "スペリオル・アーマー";
  public const string SUPERIOR_CROSS = "スペリオル・クロス";
  public const string SUPERIOR_ROBE = "スペリオル・ローブ";
  #endregion
  #region "フェーズ【 IIIー１ 】：ヴェルガス海底神殿"
  public const string EXCELLENT_SWORD = "エクセレント・ソード";
  public const string EXCELLENT_LANCE = "エクセレント・ランス";
  public const string EXCELLENT_AXE = "エクセレント・アックス";
  public const string EXCELLENT_CLAW = "エクセレント・クロー";
  public const string EXCELLENT_ROD = "エクセレント・ロッド";
  public const string EXCELLENT_BOOK = "エクセレント・ブック";
  public const string EXCELLENT_ORB = "エクセレント・オーブ";
  public const string EXCELLENT_LARGE_SWORD = "エクセレント・ラージ・ソード";
  public const string EXCELLENT_LARGE_LANCE = "エクセレント・ラージ・ランス";
  public const string EXCELLENT_LARGE_AXE = "エクセレント・ラージ・アックス";
  public const string EXCELLENT_BOW = "エクセレント・ボウ";
  public const string EXCELLENT_LARGE_STAFF = "エクセレント・ラージ・スタッフ";
  public const string EXCELLENT_SHIELD = "エクセレント・シールド";
  public const string EXCELLENT_ARMOR = "エクセレント・アーマー";
  public const string EXCELLENT_CROSS = "エクセレント・クロス";
  public const string EXCELLENT_ROBE = "エクセレント・ローブ";
  #endregion
  #region "フェーズ【 IIIー２ 】：ダルの門"
  public const string MARVELOUS_SWORD = "マーベラス・ソード";
  public const string MARVELOUS_LANCE = "マーベラス・ランス";
  public const string MARVELOUS_AXE = "マーベラス・アックス";
  public const string MARVELOUS_CLAW = "マーベラス・クロー";
  public const string MARVELOUS_ROD = "マーベラス・ロッド";
  public const string MARVELOUS_BOOK = "マーベラス・ブック";
  public const string MARVELOUS_ORB = "マーベラス・オーブ";
  public const string MARVELOUS_LARGE_SWORD = "マーベラス・ラージ・ソード";
  public const string MARVELOUS_LARGE_LANCE = "マーベラス・ラージ・ランス";
  public const string MARVELOUS_LARGE_AXE = "マーベラス・ラージ・アックス";
  public const string MARVELOUS_BOW = "マーベラス・ボウ";
  public const string MARVELOUS_LARGE_STAFF = "マーベラス・ラージ・スタッフ";
  public const string MARVELOUS_SHIELD = "マーベラス・シールド";
  public const string MARVELOUS_ARMOR = "マーベラス・アーマー";
  public const string MARVELOUS_CROSS = "マーベラス・クロス";
  public const string MARVELOUS_ROBE = "マーベラス・ローブ";
  #endregion
  #region "フェーズ【 IVー１ 】：ディスケル戦場跡地"
  public const string MASTER_SWORD = "マスター・ソード";
  public const string MASTER_LANCE = "マスター・ランス";
  public const string MASTER_AXE = "マスター・アックス";
  public const string MASTER_CLAW = "マスター・クロー";
  public const string MASTER_ROD = "マスター・ロッド";
  public const string MASTER_BOOK = "マスター・ブック";
  public const string MASTER_ORB = "マスター・オーブ";
  public const string MASTER_LARGE_SWORD = "マスター・ラージ・ソード";
  public const string MASTER_LARGE_LANCE = "マスター・ラージ・ランス";
  public const string MASTER_LARGE_AXE = "マスター・ラージ・アックス";
  public const string MASTER_BOW = "マスター・ボウ";
  public const string MASTER_LARGE_STAFF = "マスター・ラージ・スタッフ";
  public const string MASTER_SHIELD = "マスター・シールド";
  public const string MASTER_ARMOR = "マスター・アーマー";
  public const string MASTER_CROSS = "マスター・クロス";
  public const string MASTER_ROBE = "マスター・ローブ";
  #endregion
  #region "フェーズ【 IVー２ 】：エデルガイゼン城"
  public const string EXTREME_SWORD = "エクストリーム・ソード";
  public const string EXTREME_LANCE = "エクストリーム・ランス";
  public const string EXTREME_AXE = "エクストリーム・アックス";
  public const string EXTREME_CLAW = "エクストリーム・クロー";
  public const string EXTREME_ROD = "エクストリーム・ロッド";
  public const string EXTREME_BOOK = "エクストリーム・ブック";
  public const string EXTREME_ORB = "エクストリーム・オーブ";
  public const string EXTREME_LARGE_SWORD = "エクストリーム・ラージ・ソード";
  public const string EXTREME_LARGE_LANCE = "エクストリーム・ラージ・ランス";
  public const string EXTREME_LARGE_AXE = "エクストリーム・ラージ・アックス";
  public const string EXTREME_BOW = "エクストリーム・ボウ";
  public const string EXTREME_LARGE_STAFF = "エクストリーム・ラージ・スタッフ";
  public const string EXTREME_SHIELD = "エクストリーム・シールド";
  public const string EXTREME_ARMOR = "エクストリーム・アーマー";
  public const string EXTREME_CROSS = "エクストリーム・クロス";
  public const string EXTREME_ROBE = "エクストリーム・ローブ";
  #endregion
  #region "フェーズ【 Vー１ 】：雪原の大樹ラタ"
  public const string INCREDIBLE_SWORD = "インクレディブル・ソード";
  public const string INCREDIBLE_LANCE = "インクレディブル・ランス";
  public const string INCREDIBLE_AXE = "インクレディブル・アックス";
  public const string INCREDIBLE_CLAW = "インクレディブル・クロー";
  public const string INCREDIBLE_ROD = "インクレディブル・ロッド";
  public const string INCREDIBLE_BOOK = "インクレディブル・ブック";
  public const string INCREDIBLE_ORB = "インクレディブル・オーブ";
  public const string INCREDIBLE_LARGE_SWORD = "インクレディブル・ラージ・ソード";
  public const string INCREDIBLE_LARGE_LANCE = "インクレディブル・ラージ・ランス";
  public const string INCREDIBLE_LARGE_AXE = "インクレディブル・ラージ・アックス";
  public const string INCREDIBLE_BOW = "インクレディブル・ボウ";
  public const string INCREDIBLE_LARGE_STAFF = "インクレディブル・ラージ・スタッフ";
  public const string INCREDIBLE_SHIELD = "インクレディブル・シールド";
  public const string INCREDIBLE_ARMOR = "インクレディブル・アーマー";
  public const string INCREDIBLE_CROSS = "インクレディブル・クロス";
  public const string INCREDIBLE_ROBE = "インクレディブル・ローブ";
  #endregion

  public const string ZETANIUM_STONE = "ゼタニウム鉱石";
  public const string FIELD_RESEARCH_LICENSE = "国内外遠征許可証";
  public const string ITEM_MATOCK = "マトック";
  public const string ITEM_TOOMI_AOSUISYOU = "遠見の青水晶";
  public const string ITEM_WALKING_ROPE = "綱渡りロープ";
  public const string ITEM_COPPER_KEY = "銅製の鍵";
  public const string PURE_CLEAN_WATER = "清透水";
  public const string RESIST_POISON_SUIT = "耐毒防護服";
  public const string ARTHARIUM_KEY = "アーサリウム工場跡地の鍵";
  public const string UNKNOWN_OBJECT = "奇妙な物体";
  public const string MARBLE_STAR = "マーブル・スター";
  public const string ZHALMAN_NECKLACE = "ツァルマン里の首飾り";
  public const string ZEMULGEARS = "極剣：ゼムルギアス";
  public const string ARTIFACT_GENSEI = "古代の宝珠：厳正";
  public const string ARTIFACT_ZIHI = "古代の宝珠：慈悲";
  public const string ARTIFACT_MUSOU = "古代の宝珠：無双";
  public const string ARTIFACT_ZETSUKEN = "古代の宝珠：絶剣";
  public const string ARTIFACT_JOURYOKU = "古代の宝珠：常緑";
  public const string FIRE_ANGEL_TALISMAN = "炎授天使の護符";

  public const string EPIC_RING_OF_OSCURETE = @"Ring of the Oscurete";
  public const string EPIC_MERGIZD_SOL_BLADE = @"Mergizd Sol Blade";

  public const string GEAR_GENSEI = "ギア【厳正】";
  public const string EDIL_BLACK_BLADE = "エディル・ブラック・ブレード";
  #endregion
  #region "無価値アイテム"
  public const string POOR_BLACK_MATERIAL = @"ブラックマテリアル";
  public const string POOR_BLACK_MATERIAL2 = @"ブラックマテリアル【改】";
  public const string POOR_BLACK_MATERIAL3 = @"ブラックマテリアル【灰】";
  public const string POOR_BLACK_MATERIAL4 = @"ブラックマテリアル【密】";
  public const string POOR_BLACK_MATERIAL5 = @"ブラックマテリアル【塵】";
  public const string POOR_BLACK_MATERIAL6 = @"ブラックマテリアル【試】";
  public const string POOR_BLACK_MATERIAL7 = @"ブラックマテリアル【滅】";
  public const string POOR_BLACK_MATERIAL8 = @"ブラックマテリアル【還】";
  public const string POOR_BLACK_MATERIAL9 = @"ブラックマテリアル【空】";
  #endregion
  #region "ポーション"
  public const string SMALL_RED_POTION = "小さい赤ポーション";
  public const string SMALL_BLUE_POTION = "小さい青ポーション";
  public const string NORMAL_RED_POTION = "普通の赤ポーション";
  public const string NORMAL_BLUE_POTION = "普通の青ポーション";
  public const string LARGE_RED_POTION = "大きな赤ポーション";
  public const string LARGE_BLUE_POTION = "大きな青ポーション";
  public const string HUGE_RED_POTION = "巨大な赤ポーション";
  public const string HUGE_BLUE_POTION = "巨大な青ポーション";
  public const string HQ_RED_POTION = "高品質の赤ポーション";
  public const string HQ_BLUE_POTION = "高品質の青ポーション";
  public const string THQ_RED_POTION = "最高品質の赤ポーション";
  public const string THQ_BLUE_POTION = "最高品質の青ポーション";
  public const string PERFECT_RED_POTION = "完全な赤ポーション";
  public const string PERFECT_BLUE_POTION = "完全な青ポーション";
  #endregion
  #region "成長剤"
  // 成長剤（１階）
  public const string GROWTH_LIQUID_STRENGTH = @"成長リキッド【力】";
  public const string GROWTH_LIQUID_AGILITY = @"成長リキッド【技】";
  public const string GROWTH_LIQUID_INTELLIGENCE = @"成長リキッド【知】";
  public const string GROWTH_LIQUID_STAMINA = @"成長リキッド【体】";
  public const string GROWTH_LIQUID_MIND = @"成長リキッド【心】";
  // 成長剤（２階）
  public const string GROWTH_LIQUID2_STRENGTH = @"成長リキッドⅡ【力】";
  public const string GROWTH_LIQUID2_AGILITY = @"成長リキッドⅡ【技】";
  public const string GROWTH_LIQUID2_INTELLIGENCE = @"成長リキッドⅡ【知】";
  public const string GROWTH_LIQUID2_STAMINA = @"成長リキッドⅡ【体】";
  public const string GROWTH_LIQUID2_MIND = @"成長リキッドⅡ【心】";
  // 成長剤（３階）
  public const string GROWTH_LIQUID3_STRENGTH = @"成長リキッドⅢ【力】";
  public const string GROWTH_LIQUID3_AGILITY = @"成長リキッドⅢ【技】";
  public const string GROWTH_LIQUID3_INTELLIGENCE = @"成長リキッドⅢ【知】";
  public const string GROWTH_LIQUID3_STAMINA = @"成長リキッドⅢ【体】";
  public const string GROWTH_LIQUID3_MIND = @"成長リキッドⅢ【心】";
  // 成長剤（４階）
  public const string GROWTH_LIQUID4_STRENGTH = @"成長リキッドⅣ【力】";
  public const string GROWTH_LIQUID4_AGILITY = @"成長リキッドⅣ【技】";
  public const string GROWTH_LIQUID4_INTELLIGENCE = @"成長リキッドⅣ【知】";
  public const string GROWTH_LIQUID4_STAMINA = @"成長リキッドⅣ【体】";
  public const string GROWTH_LIQUID4_MIND = @"成長リキッドⅣ【心】";
  // 成長剤（５階）
  public const string GROWTH_LIQUID5_STRENGTH = @"成長リキッドⅤ【力】";
  public const string GROWTH_LIQUID5_AGILITY = @"成長リキッドⅤ【技】";
  public const string GROWTH_LIQUID5_INTELLIGENCE = @"成長リキッドⅤ【知】";
  public const string GROWTH_LIQUID5_STAMINA = @"成長リキッドⅤ【体】";
  public const string GROWTH_LIQUID5_MIND = @"成長リキッドⅤ【心】";
  #endregion
  #endregion

  #region "Monster Name"
  public const string TINY_MANTIS = "Tiny Mantis";
  public const string TINY_MANTIS_JP = "小さいカマキリ";
  public const string GREEN_SLIME = "Green Slime";
  public const string GREEN_SLIME_JP = "グリーン スライム";
  public const string MANDRAGORA = "Mandragora";
  public const string MANDRAGORA_JP = "マンドラゴラ";
  public const string YOUNG_WOLF = "Young Wolf";
  public const string YOUNG_WOLF_JP = "ヤング ウルフ";
  public const string WILD_ANT = "Wild Ant";
  public const string WILD_ANT_JP = "野生のアリ";
  public const string OLD_TREEFORK = "Old Treefolk";
  public const string OLD_TREEFORK_JP = "古びたツリーフォーク";
  public const string SUN_FLOWER = "Sun Flower";
  public const string SUN_FLOWER_JP = "サン フラワー";
  public const string SOLID_BEETLE = "Solid Beetle";
  public const string SOLID_BEETLE_JP = "甲殻ビートル";
  public const string SILENT_LADYBUG = "Silent Ladybug";
  public const string SILENT_LADYBUG_JP = "物静かなレディバグ";
  public const string MYSTIC_DRYAD = "Mystic Dryad";
  public const string MYSTIC_DRYAD_JP = "神秘的なドライアド";
  public const string NIMBLE_RABBIT = "Nimble Rabbit";
  public const string NIMBLE_RABBIT_JP = "軽快なラビット";
  public const string ENTANGLED_VINE = "Entangled Vine";
  public const string ENTANGLED_VINE_JP = "絡みつく蔦";
  public const string CREEPING_SPIDER = "Creeping Spider";
  public const string CREEPING_SPIDER_JP = "忍び寄るスパイダー";
  public const string BLOOD_MOSS = "Blood Moss";
  public const string BLOOD_MOSS_JP = "ブラッド モス";
  public const string KILLER_BEE = "Killer Bee";
  public const string KILLER_BEE_JP = "キラー ビー";
  public const string WOOD_ELF = "Wood Elf";
  public const string WOOD_ELF_JP = "ウッド エルフ";
  public const string RUDE_WATCHDOG = "Rude Watchdog";
  public const string RUDE_WATCHDOG_JP = "ルード ウォッチドッグ";
  public const string STINKED_SPORE = "Stinked Spore";
  public const string STINKED_SPORE_JP = "生臭いスポア";
  public const string DAUNTLESS_HORSE = "Dauntless Horse";
  public const string DAUNTLESS_HORSE_JP = "果敢な戦馬";
  public const string WONDER_SEED = "Wonder Seed";
  public const string WONDER_SEED_JP = "ワンダー シード";
  public const string SHOTGUN_HYUUI = "Shotgun Hyuui";
  public const string SHOTGUN_HYUUI_JP = "ショットガン ヒューイ";
  public const string CHARGED_BOAR = "Charged Boar";
  public const string CHARGED_BOAR_JP = "突撃ボア";
  public const string POISON_FLOG = "Poison Flog";
  public const string POISON_FLOG_JP = "ポイズン フロッグ";
  public const string SPEEDY_FALCON = "Speedy Falcon";
  public const string SPEEDY_FALCON_JP = "スピーディ ファルコン";
  public const string INNOCENT_FAIRY = "Innocent Fairy";
  public const string INNOCENT_FAIRY_JP = "イノセント フェアリー";
  public const string GIANT_SNAKE = "Giant Snake";
  public const string GIANT_SNAKE_JP = "ジャイアント スネーク";
  public const string CALM_STAG = "Calm Stag";
  public const string CALM_STAG_JP = "冷静な鹿";
  public const string SAVAGE_BEAR = "Savage Bear";
  public const string SAVAGE_BEAR_JP = "野蛮な熊";
  public const string FOREST_ELEMENTAL = "Forest Elemental";
  public const string FOREST_ELEMENTAL_JP = "フォレスト エレメンタル";
  public const string EXCITED_ELEPHANT = "Excited Elephant";
  public const string EXCITED_ELEPHANT_JP = "興奮するエレファント";
  public const string FLANSIS_KNIGHT = "Flansis Knight";
  public const string FLANSIS_KNIGHT_JP = "フランシスの騎士";
  public const string GATHERING_LAPTOR = "Gathering Laptor";
  public const string GATHERING_LAPTOR_JP = "ギャザリング ラプター";
  public const string SYLPH_DANCER = "Sylph Dancer";
  public const string SYLPH_DANCER_JP = "シルフ ダンサー";
  public const string THORN_WARRIOR = "Thorn Warrior";
  public const string THORN_WARRIOR_JP = "茨の戦士";
  public const string TOWERING_ENT = "Towering Ent";
  public const string TOWERING_ENT_JP = "そびえ立つエント";
  public const string DISTURB_RHINO = "Disturb Rhino";
  public const string DISTURB_RHINO_JP = "ディスターブ リノ";
  public const string MIST_PYTHON = "Mist Python";
  public const string MIST_PYTHON_JP = "ミスト パイソン";
  public const string MUDDLED_PLANT = "Muddled Plant";
  public const string MUDDLED_PLANT_JP = "腐敗したプラント";
  public const string POISON_MARY = "Poison Mary";
  public const string POISON_MARY_JP = "ポイズン マリー";
  public const string FLANSIS_OF_THE_FOREST_QUEEN = "Flansis, The Queen of Verdant";
  public const string FLANSIS_OF_THE_FOREST_QUEEN_JP = "新緑の女王：フランシス";
  public const string DAGGER_FISH = "Dagger Fish";
  public const string DAGGER_FISH_JP = "ダガー フィッシュ";
  public const string FLOATING_MANTA = "Floating Manta";
  public const string FLOATING_MANTA_JP = "浮遊するマンタ";
  public const string SKYBLUE_BIRD = "Skyblue Bird";
  public const string SKYBLUE_BIRD_JP = "スカイブルー バード";
  public const string RAINBOW_CLIONE = "Rainbow Clione";
  public const string RAINBOW_CLIONE_JP = "レインボー クリオネ";
  public const string ROLLING_MAGURO = "Rolling Maguro";
  public const string ROLLING_MAGURO_JP = "ローリング マグロ";
  public const string LIMBER_SEAEAGLE = "Limber SeaEagle";
  public const string LIMBER_SEAEAGLE_JP = "しなやかな海鷲";
  public const string FLUFFY_CORAL = "Fluffy Coral";
  public const string FLUFFY_CORAL_JP = "フラッフィ コーラル";
  public const string BLACK_OCTOPUS = "Black Octopus";
  public const string BLACK_OCTOPUS_JP = "ブラック オクトパス";
  public const string STEAL_SQUID = "Steal Squid";
  public const string STEAL_SQUID_JP = "忍び寄るスキッド";
  public const string THE_HAND_OF_KRAKEN = "The Hand of Kraken";
  public const string THE_HAND_OF_KRAKEN_JP = "クラーケンの大手";
  public const string PROUD_VIKING = "Proud Viking";
  public const string PROUD_VIKING_JP = "誇りあるバイキング";
  public const string GAN_GAME = "GanGame";
  public const string GAN_GAME_JP = "頑亀";
  public const string JUMPING_KAMASU = "Jumping Kamasu";
  public const string JUMPING_KAMASU_JP = "ジャンピング カマス";
  public const string WRECHED_ANEMONE = "Wreched Anemone";
  public const string WRECHED_ANEMONE_JP = "浅ましいアネモネ";
  public const string DEEPSEA_HAND = "DeepSea Hand";
  public const string DEEPSEA_HAND_JP = "深海の手";
  public const string ASSULT_SERPENT = "Assult Serpent";
  public const string ASSULT_SERPENT_JP = "襲いかかるサーペント";
  public const string ESCORT_HERMIT_CLUB = "Escort Hermit-Club";
  public const string ESCORT_HERMIT_CLUB_JP = "護衛隊 ハーミットクラブ";
  public const string GLUTTONY_COELACANTH = "Gluttony Coelacanth";
  public const string GLUTTONY_COELACANTH_JP = "大食いシーラカンス";
  public const string GIANT_SEA_SPIDER = "Giant Sea-Spider";
  public const string GIANT_SEA_SPIDER_JP = "巨大なウミグモ";
  public const string SHELL_THE_SWORD_KNIGHT = "Shell the Sword-Knight";
  public const string SHELL_THE_SWORD_KNIGHT_JP = "シェル ザ ソードナイト";
  public const string MOGUL_MANTA = "Mogul Manta";
  public const string MOGUL_MANTA_JP = "モーグル マンタ";
  public const string WEEPING_MIST = "Weeping Mist";
  public const string WEEPING_MIST_JP = "ウィーピング ミスト";
  public const string AMBUSH_ANGLERFISH = "Ambush Anglerfish";
  public const string AMBUSH_ANGLERFISH_JP = "待ち伏せアンコウ";
  public const string EMERALD_LOBSTER = "Emerald Lobster";
  public const string EMERALD_LOBSTER_JP = "エメラルドのエビ";
  public const string BIGMOUSE_JOE = "Bigmouse Joe";
  public const string BIGMOUSE_JOE_JP = "ビッグマウス ジョー";
  public const string RAMPAGE_BIGSHARK = "Rampage BigShark";
  public const string RAMPAGE_BIGSHARK_JP = "暴れ大ザメ";
  public const string STICKY_STARFISH = "Sticky Starfish";
  public const string STICKY_STARFISH_JP = "スティッキー スターフィッシュ";
  public const string SEA_ELEMENTAL = "Sea Elemental";
  public const string SEA_ELEMENTAL_JP = "シー エレメンタル";
  public const string EDGED_HIGH_SHARK = "Edged High-Shark";
  public const string EDGED_HIGH_SHARK_JP = "エッジド ハイシャーク";
  public const string GUARDIAN_ROYAL_NAGA = "Guardian Royal Naga";
  public const string GUARDIAN_ROYAL_NAGA_JP = "ガーディアン ロイヤル ナーガ";
  public const string THOUGHTFUL_NAUTILUS = "Thoughtful Nautilus";
  public const string THOUGHTFUL_NAUTILUS_JP = "思慮深いノーチラス";
  public const string FEROCIOUS_WHALE = "Ferocious Whale";
  public const string FEROCIOUS_WHALE_JP = "フェロシアス ホエール";
  public const string GHOST_SHIP = "Ghost Ship";
  public const string GHOST_SHIP_JP = "幽霊船";
  public const string RECKLESS_WALRUS = "Reckless Walrus";
  public const string RECKLESS_WALRUS_JP = "猛突進ウォーラス";
  public const string BEAUTY_SEA_LILY = "Beauty Sea-Lily";
  public const string BEAUTY_SEA_LILY_JP = "美しきウミユリ";
  public const string DEFENSIVE_DATSU = "Defensive Datsu";
  public const string DEFENSIVE_DATSU_JP = "身構えるダツ";
  public const string SEA_STAR_KNIGHT = "Sea-Star Knight";
  public const string SEA_STAR_KNIGHT_JP = "海星騎士";
  public const string SEA_SONG_MARMAID = "Sea-Song Marmaid";
  public const string SEA_SONG_MARMAID_JP = "海の歌姫マーメイド";
  public const string BRILLIANT_SEA_PRINCE = "Brilliant Sea-Prince";
  public const string BRILLIANT_SEA_PRINCE_JP = "輝ける海の王子";
  public const string VELGAS_THE_KING_OF_SEA_STAR = "Velgas, The king of Sea-Star";
  public const string VELGAS_THE_KING_OF_SEA_STAR_JP = "海星源の王：ヴェルガス";
  public const string DEBRIS_SOLDIER = "Debris Soldier";
  public const string DEBRIS_SOLDIER_JP = "ガラクタ機甲兵";
  public const string MAGICAL_AUTOMATA = "Magical Automata";
  public const string MAGICAL_AUTOMATA_JP = "魔道師団のオートマータ";
  public const string KILLER_MACHINE = "Killer Machine";
  public const string KILLER_MACHINE_JP = "キラー マシン";
  public const string ANTIQUE_MIRROR = "Antique Mirror";
  public const string ANTIQUE_MIRROR_JP = "アンティーク ミラー";
  public const string MECH_HAND = "Mech Hand";
  public const string MECH_HAND_JP = "メカ ハンド";
  public const string ABSENCE_MOAI = "Absence Moai";
  public const string ABSENCE_MOAI_JP = "無表情のモアイ";
  public const string ACID_SCORPION = "Acid Scorpion";
  public const string ACID_SCORPION_JP = "アシッド スコーピオン";
  public const string AIMING_SHOOTER = "Aiming Shooter";
  public const string AIMING_SHOOTER_JP = "エイミング シューター";
  public const string LIGHTNING_CLOUD = "Lightning Cloud";
  public const string LIGHTNING_CLOUD_JP = "ライトニング クラウド";
  public const string STONE_STATUE_SEIHITSU = "Stone-Statue Seihitsu";
  public const string STONE_STATUE_SEIHITSU_JP = "静謐な石像";
  public const string NEJIMAKI_KNIGHT = "Nejimaki Knight";
  public const string NEJIMAKI_KNIGHT_JP = "ネジマキ ナイト";
  public const string WALKING_TIME_BOMB = "Walking Time-Bomb";
  public const string WALKING_TIME_BOMB_JP = "歩行式時限爆弾";
  public const string DISTORTED_SENSOR = "Distorted Sensor";
  public const string DISTORTED_SENSOR_JP = "ディストーティッド センサー";
  public const string JUNK_VULKAN = "Junk Vulkan";
  public const string JUNK_VULKAN_JP = "ジャンク バルカン";
  public const string ASSULT_SCARECROW = "Assult Scarecrow";
  public const string ASSULT_SCARECROW_JP = "襲いかかるスケアクロウ";
  public const string MAD_DOCTOR = "Mad Doctor";
  public const string MAD_DOCTOR_JP = "マッド ドクター";
  public const string SILENT_GARGOYLE = "Silent Gargoyle";
  public const string SILENT_GARGOYLE_JP = "サイレント ガーゴイル";
  public const string STONE_GOLEM = "Stone Golem";
  public const string STONE_GOLEM_JP = "ストーン ゴーレム";
  public const string DEATH_DRONE = "Death Drone";
  public const string DEATH_DRONE_JP = "デス ドローン";
  public const string STINKY_BAT = "Stinky Bat";
  public const string STINKY_BAT_JP = "泥臭いコウモリ";
  public const string CULT_BLACK_MAGICIAN_JP = "教団の闇術師";
  public const string CULT_BLACK_MAGICIAN = "Cult Black Magician";
  public const string GATE_HOUND = "Gate Hound";
  public const string GATE_HOUND_JP = "門番犬";
  public const string PLAY_FIRE_IMP_JP = "炎遊びのインプ";
  public const string PLAY_FIRE_IMP = "Play-Fire Imp";
  public const string EARTH_ELEMENTAL = "Earth Elemental";
  public const string EARTH_ELEMENTAL_JP = "アース・エレメンタル";
  public const string MAGICAL_HAIL_GUN = "Magical Hail-Gun";
  public const string MAGICAL_HAIL_GUN_JP = "魔法雹穴銃";
  public const string THE_GALVADAZER = "Galvadazer, The Over-Boost-Destructor";
  public const string THE_GALVADAZER_JP = "暴走破壊者：ガルヴァデイザー";
  public const string SWIFT_EAGLE = "Swift Eagle";
  public const string SWIFT_EAGLE_JP = "スウィフト イーグル";
  public const string EASTERN_GOLEM = "Eastern Golem";
  public const string EASTERN_GOLEM_JP = "イースタン ゴーレム";
  public const string WESTERN_GOLEM = "Western Golem";
  public const string WESTERN_GOLEM_JP = "ウェスタン ゴーレム";
  public const string WIND_ELEMENTAL = "Wind Elemental";
  public const string WIND_ELEMENTAL_JP = "ウィンド エレメンタル";
  public const string SKY_KNIGHT = "Sky Knight";
  public const string SKY_KNIGHT_JP = "スカイ ナイト";
  public const string THE_PURPLE_HIKARIGOKE = "The Purple Hikarigoke";
  public const string THE_PURPLE_HIKARIGOKE_JP = "紫色のヒカリゴケ";
  public const string MYSTICAL_UNICORN = "Mystical Unicorn";
  public const string MYSTICAL_UNICORN_JP = "ミスティカル ユニコーン";
  public const string TRIAL_HERMIT = "Trial Hermit";
  public const string TRIAL_HERMIT_JP = "トライアル ハーミット";
  public const string STORM_BIRDMAN = "Storm Birdman";
  public const string STORM_BIRDMAN_JP = "疾風のバードマン";
  public const string THE_BLUE_LAVA_EYE = "The Blue-Lava Eye";
  public const string THE_BLUE_LAVA_EYE_JP = "ブルー ラーヴァ アイ";
  public const string FLYING_CURTAIN = "Flying Curtain";
  public const string FLYING_CURTAIN_JP = "浮遊するカーテン";
  public const string LUMINOUS_HAWK = "Luminous Hawk";
  public const string LUMINOUS_HAWK_JP = "ルミナス ホーク";
  public const string AETHER_GUST = "Aether Gust";
  public const string AETHER_GUST_JP = "エーテル ガスト";
  public const string WHIRLWIND_KITSUNE = "Whirlwind Kitsune";
  public const string WHIRLWIND_KITSUNE_JP = "風纏い狐";
  public const string THUNDER_LION = "Thunder Lion";
  public const string THUNDER_LION_JP = "サンダー ライオン";
  public const string SAINT_PEGASUS = "Saint Pegasus";
  public const string SAINT_PEGASUS_JP = "神聖なるペガサス";
  public const string DREAM_WALKER = "Dream Walker";
  public const string DREAM_WALKER_JP = "ドリーム ウォーカー";
  public const string IVORY_STATUE = "Ivory Statue";
  public const string IVORY_STATUE_JP = "アイボリー スタチュー";
  public const string STUBBORN_SAGE = "Stubborn Sage";
  public const string STUBBORN_SAGE_JP = "スタボーン セイジ";
  public const string LIGHT_THUNDER_LANCEBOLTS = "Light-Thunder Lancebolts";
  public const string LIGHT_THUNDER_LANCEBOLTS_JP = "雷光ランスボルツ";
  public const string BOMB_BALLON = "Bomb Ballon";
  public const string BOMB_BALLON_JP = "爆弾バルーン";
  public const string OBSERVANT_HERALD = "Observant Herald";
  public const string OBSERVANT_HERALD_JP = "用心深い伝令者";
  public const string TOWER_SCOUT = "Tower Scout";
  public const string TOWER_SCOUT_JP = "塔の監視者";
  public const string MIST_SALVAGER = "Mist Salvager";
  public const string MIST_SALVAGER_JP = "ミスト サルベージャー";
  public const string WINGSPAN_RANGER = "Wingspan  Ranger";
  public const string WINGSPAN_RANGER_JP = "ウィングスパン レンジャー";
  public const string HARDENED_GRIFFIN = "Hardened Griffin";
  public const string HARDENED_GRIFFIN_JP = "硬化体質のグリフィン";
  public const string MAJESTIC_CLOUD = "Magiestic Cloud";
  public const string MAJESTIC_CLOUD_JP = "マジェスティック クラウド";
  public const string PRISMA_SPHERE = "Prisma Sphere";
  public const string PRISMA_SPHERE_JP = "プリズマ スフィア";
  public const string VEIL_FORTUNE_WIZARD = "Veil Fortune Wizard";
  public const string VEIL_FORTUNE_WIZARD_JP = "ヴェイル フォーチュン ウィザード";
  public const string THE_YODIRIAN = "Yodirian, The Way of Tranquil-Line";
  public const string THE_YODIRIAN_JP = "静穏を受け継ぎし者：ヨーディリアン";
  public const string IMPERIAL_KNIGHT = "Imperial Knight";
  public const string IMPERIAL_KNIGHT_JP = "インペリアル・ナイト";
  public const string VENERABLE_WIZARD = "Venerable Wizard";
  public const string VENERABLE_WIZARD_JP = "ヴェネラブル・ウィザード";
  public const string HOLLOW_SPECTOR = "Hollow Spector";
  public const string HOLLOW_SPECTOR_JP = "ホロウ・スペクター";
  public const string LIGHTNING_SPHERE = "Lightning Sphere";
  public const string LIGHTNING_SPHERE_JP = "ライトニング・スフィア";
  public const string DECEIVED_HUNTSMAN = "Deceived Huntsman";
  public const string DECEIVED_HUNTSMAN_JP = "待ち伏せハンツマン";
  public const string MOVING_CANNON = "Moving Cannon";
  public const string MOVING_CANNON_JP = "動き回る砲台";
  public const string DHAL_GUARDIAN = "Dhal Guardian";
  public const string DHAL_GUARDIAN_JP = "ダルの守護人";
  public const string PUPPET_MASTER = "Puppet Master";
  public const string PUPPET_MASTER_JP = "パペット・マスター";
  public const string DANCING_BLADE = "Dancing Blade";
  public const string DANCING_BLADE_JP = "ダンシング・ブレード";
  public const string MASCLEWARRIOR_HARDIL = "MuscleWarrior Hardil";
  public const string MASCLEWARRIOR_HARDIL_JP = "屈強戦士：ハーディル";
  public const string TRAPPED_DISK = "Trapped Disk";
  public const string TRAPPED_DISK_JP = "トラップ仕掛けの円盤";
  public const string WHISTLE_SENSOR = "Whistle Sensor";
  public const string WHISTLE_SENSOR_JP = "笛吹きセンサー";
  public const string DREAD_LANCER = "Dread Lancer";
  public const string DREAD_LANCER_JP = "ドレッド・ランサー";
  public const string RAGE_TIGER = "Rage Tiger";
  public const string RAGE_TIGER_JP = "レイジ・タイガー";
  public const string PEACEFUL_ANDANTINO = "Peaceful Andantino";
  public const string PEACEFUL_ANDANTINO_JP = "ピースフル・アンダンティーノ";
  public const string POISONED_CHALICE = "Poisoned Chalice";
  public const string POISONED_CHALICE_JP = "猛毒聖杯";
  public const string WISDOM_CENTAURUS = "Wisdom Centaurus";
  public const string WISDOM_CENTAURUS_JP = "知的なケンタウロス";
  public const string UNKNOWN_FLOATING_BALL = "Unknown Floating-Ball";
  public const string UNKNOWN_FLOATING_BALL_JP = "正体不明の浮遊物";
  public const string AURORA_SPIRIT = "Aurora Spirit";
  public const string AURORA_SPIRIT_JP = "オーロラ・スピリット";
  public const string HUGE_MAGICIAN_ZAGAN = "Huge Magician Zagan";
  public const string HUGE_MAGICIAN_ZAGAN_JP = "巨体魔導士：ザガン";
  public const string SCREAMING_RAFFLESIA = "叫喚のラフレシア";
  public const string HELL_KERBEROS = "Hell Kerberos";
  public const string HELL_KERBEROS_JP = "地獄のケルベロス";
  #endregion

  #region "Dungeon Event"
  #region "サルン洞窟前の草原区域"
  #region "宝箱"
  public const string CAVEOFSARUN_Treasure_1_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_1_O = "1";
  public const float CAVEOFSARUN_Treasure_1_X = 28.0f;
  public const float CAVEOFSARUN_Treasure_1_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_1_Z = 3.0f;

  public const string CAVEOFSARUN_Treasure_2_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_2_O = "2";
  public const float CAVEOFSARUN_Treasure_2_X = 24.0f;
  public const float CAVEOFSARUN_Treasure_2_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_2_Z = 0.0f;

  public const string CAVEOFSARUN_Treasure_3_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_3_O = "3";
  public const float CAVEOFSARUN_Treasure_3_X = 15.0f;
  public const float CAVEOFSARUN_Treasure_3_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_3_Z = 8.0f;

  public const string CAVEOFSARUN_Treasure_4_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_4_O = "4";
  public const float CAVEOFSARUN_Treasure_4_X = 11.0f;
  public const float CAVEOFSARUN_Treasure_4_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_4_Z = 2.0f;

  public const string CAVEOFSARUN_Treasure_5_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_5_O = "5";
  public const float CAVEOFSARUN_Treasure_5_X = 1.0f;
  public const float CAVEOFSARUN_Treasure_5_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_5_Z = 9.0f;

  public const string CAVEOFSARUN_Treasure_6_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_6_O = "6";
  public const float CAVEOFSARUN_Treasure_6_X = -9.0f;
  public const float CAVEOFSARUN_Treasure_6_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_6_Z = 11.0f;

  public const string CAVEOFSARUN_Treasure_7_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_7_O = "7";
  public const float CAVEOFSARUN_Treasure_7_X = 7.0f;
  public const float CAVEOFSARUN_Treasure_7_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_7_Z = -5.0f;

  public const string CAVEOFSARUN_Treasure_8_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_8_O = "8";
  public const float CAVEOFSARUN_Treasure_8_X = 7.0f;
  public const float CAVEOFSARUN_Treasure_8_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_8_Z = 1.0f;

  public const string CAVEOFSARUN_Treasure_9_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_9_O = "9";
  public const float CAVEOFSARUN_Treasure_9_X = -7.0f;
  public const float CAVEOFSARUN_Treasure_9_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_9_Z = 5.0f;

  public const string CAVEOFSARUN_Treasure_10_C = "Treasure";
  public const string CAVEOFSARUN_Treasure_10_O = "10";
  public const float CAVEOFSARUN_Treasure_10_X = 27.0f;
  public const float CAVEOFSARUN_Treasure_10_Y = 1.0f;
  public const float CAVEOFSARUN_Treasure_10_Z = -5.0f;
  #endregion
  #region "イベント"
  public const string CAVEOFSARUN_Rock_1_C = "Rock";
  public const string CAVEOFSARUN_Rock_1_O = "1";
  public const float CAVEOFSARUN_Rock_1_X = -9.0f;
  public const float CAVEOFSARUN_Rock_1_Y = 1.0f;
  public const float CAVEOFSARUN_Rock_1_Z = 8.0f;

  public const string CAVEOFSARUN_Rock_2_C = "Rock";
  public const string CAVEOFSARUN_Rock_2_O = "2";
  public const float CAVEOFSARUN_Rock_2_X = -5.0f;
  public const float CAVEOFSARUN_Rock_2_Y = 1.0f;
  public const float CAVEOFSARUN_Rock_2_Z = 10.0f;

  public const string CAVEOFSARUN_Rock_3_C = "Rock";
  public const string CAVEOFSARUN_Rock_3_O = "3";
  public const float CAVEOFSARUN_Rock_3_X = -3.0f;
  public const float CAVEOFSARUN_Rock_3_Y = 1.0f;
  public const float CAVEOFSARUN_Rock_3_Z = 0.0f;

  public const string CAVEOFSARUN_Rock_4_C = "Rock";
  public const string CAVEOFSARUN_Rock_4_O = "4";
  public const float CAVEOFSARUN_Rock_4_X = -7.0f;
  public const float CAVEOFSARUN_Rock_4_Y = 1.0f;
  public const float CAVEOFSARUN_Rock_4_Z = 4.0f;

  public const string CAVEOFSARUN_Rock_5_C = "Rock";
  public const string CAVEOFSARUN_Rock_5_O = "5";
  public const float CAVEOFSARUN_Rock_5_X = 9.0f;
  public const float CAVEOFSARUN_Rock_5_Y = 1.0f;
  public const float CAVEOFSARUN_Rock_5_Z = -4.0f;

  public const string CAVEOFSARUN_Rock_6_C = "Rock";
  public const string CAVEOFSARUN_Rock_6_O = "6";
  public const float CAVEOFSARUN_Rock_6_X = 13.0f;
  public const float CAVEOFSARUN_Rock_6_Y = 1.0f;
  public const float CAVEOFSARUN_Rock_6_Z = -1.0f;

  public const string CAVEOFSARUN_Rock_7_C = "Rock";
  public const string CAVEOFSARUN_Rock_7_O = "7";
  public const float CAVEOFSARUN_Rock_7_X = 16.0f;
  public const float CAVEOFSARUN_Rock_7_Y = 1.0f;
  public const float CAVEOFSARUN_Rock_7_Z = -4.0f;

  public const string CAVEOFSARUN_Rock_8_C = "Rock";
  public const string CAVEOFSARUN_Rock_8_O = "8";
  public const float CAVEOFSARUN_Rock_8_X = -6.0f;
  public const float CAVEOFSARUN_Rock_8_Y = 1.0f;
  public const float CAVEOFSARUN_Rock_8_Z = 2.0f;
  #endregion
  #endregion
  #region "ゴラトラム洞窟"
  #region "宝箱"
  public const string GORATRUM_Treasure_1_C = "Treasure";
  public const string GORATRUM_Treasure_1_O = "1";
  public const float GORATRUM_Treasure_1_X = 12.0f;
  public const float GORATRUM_Treasure_1_Y = 1.0f;
  public const float GORATRUM_Treasure_1_Z = -1.0f;

  public const string GORATRUM_Treasure_2_C = "Treasure";
  public const string GORATRUM_Treasure_2_O = "2";
  public const float GORATRUM_Treasure_2_X = 22.0f;
  public const float GORATRUM_Treasure_2_Y = 1.0f;
  public const float GORATRUM_Treasure_2_Z = -4.0f;

  public const string GORATRUM_Treasure_3_C = "Treasure";
  public const string GORATRUM_Treasure_3_O = "3";
  public const float GORATRUM_Treasure_3_X = 13.0f;
  public const float GORATRUM_Treasure_3_Y = 1.0f;
  public const float GORATRUM_Treasure_3_Z = -16.0f;

  public const string GORATRUM_Treasure_4_C = "Treasure";
  public const string GORATRUM_Treasure_4_O = "4";
  public const float GORATRUM_Treasure_4_X = 19.0f;
  public const float GORATRUM_Treasure_4_Y = 1.0f;
  public const float GORATRUM_Treasure_4_Z = -14.0f;

  public const string GORATRUM_Treasure_5_C = "Treasure";
  public const string GORATRUM_Treasure_5_O = "5";
  public const float GORATRUM_Treasure_5_X = 9.0f;
  public const float GORATRUM_Treasure_5_Y = 1.0f;
  public const float GORATRUM_Treasure_5_Z = -11.0f;

  public const string GORATRUM_Treasure_6_C = "Treasure";
  public const string GORATRUM_Treasure_6_O = "6";
  public const float GORATRUM_Treasure_6_X = 1.0f;
  public const float GORATRUM_Treasure_6_Y = 1.0f;
  public const float GORATRUM_Treasure_6_Z = -16.0f;

  public const string GORATRUM_Treasure_7_C = "Treasure";
  public const string GORATRUM_Treasure_7_O = "7";
  public const float GORATRUM_Treasure_7_X = 31.0f;
  public const float GORATRUM_Treasure_7_Y = 1.0f;
  public const float GORATRUM_Treasure_7_Z = -18.0f;

  public const string GORATRUM_Treasure_8_C = "Treasure";
  public const string GORATRUM_Treasure_8_O = "8";
  public const float GORATRUM_Treasure_8_X = 30.0f;
  public const float GORATRUM_Treasure_8_Y = 1.0f;
  public const float GORATRUM_Treasure_8_Z = -11.0f;

  public const string GORATRUM_Treasure_9_C = "Treasure";
  public const string GORATRUM_Treasure_9_O = "9";
  public const float GORATRUM_Treasure_9_X = 35.0f;
  public const float GORATRUM_Treasure_9_Y = 1.0f;
  public const float GORATRUM_Treasure_9_Z = -8.0f;

  public const string GORATRUM_Treasure_10_C = "Treasure";
  public const string GORATRUM_Treasure_10_O = "10";
  public const float GORATRUM_Treasure_10_X = 38.0f;
  public const float GORATRUM_Treasure_10_Y = 1.0f;
  public const float GORATRUM_Treasure_10_Z = -6.0f;

  public const string GORATRUM_Treasure_11_C = "Treasure";
  public const string GORATRUM_Treasure_11_O = "11";
  public const float GORATRUM_Treasure_11_X = 36.0f;
  public const float GORATRUM_Treasure_11_Y = 1.0f;
  public const float GORATRUM_Treasure_11_Z = -3.0f;

  public const string GORATRUM_2_Treasure_1_C = "Treasure";
  public const string GORATRUM_2_Treasure_1_O = "1";
  public const float GORATRUM_2_Treasure_1_X = 36.0f;
  public const float GORATRUM_2_Treasure_1_Y = 1.0f;
  public const float GORATRUM_2_Treasure_1_Z = -2.0f;

  public const string GORATRUM_2_Treasure_2_C = "Treasure";
  public const string GORATRUM_2_Treasure_2_O = "2";
  public const float GORATRUM_2_Treasure_2_X = 7.0f;
  public const float GORATRUM_2_Treasure_2_Y = 1.0f;
  public const float GORATRUM_2_Treasure_2_Z = -16.0f;

  public const string GORATRUM_2_Treasure_3_C = "Treasure";
  public const string GORATRUM_2_Treasure_3_O = "3";
  public const float GORATRUM_2_Treasure_3_X = 31.0f;
  public const float GORATRUM_2_Treasure_3_Y = 1.0f;
  public const float GORATRUM_2_Treasure_3_Z = -1.0f;

  public const string GORATRUM_2_Treasure_4_C = "Treasure";
  public const string GORATRUM_2_Treasure_4_O = "4";
  public const float GORATRUM_2_Treasure_4_X = 29.0f;
  public const float GORATRUM_2_Treasure_4_Y = 1.0f;
  public const float GORATRUM_2_Treasure_4_Z = -16.0f;
  #endregion
  #region "階段(上り)"
  // (1F)
  public const string GORATRUM_Upstair_1_C = "Upstair";
  public const string GORATRUM_Upstair_1_O = "1";
  public const float GORATRUM_Upstair_1_X = 5.0f;
  public const float GORATRUM_Upstair_1_Y = 0.0f;
  public const float GORATRUM_Upstair_1_Z = -2.0f;

  public const string GORATRUM_Upstair_2_C = "Upstair";
  public const string GORATRUM_Upstair_2_O = "2";
  public const float GORATRUM_Upstair_2_X = 0.0f;
  public const float GORATRUM_Upstair_2_Y = 0.0f;
  public const float GORATRUM_Upstair_2_Z = -5.0f;

  // (2F)
  public const string GORATRUM_2_Upstair_1_C = "Upstair";
  public const string GORATRUM_2_Upstair_1_O = "1";
  public const float GORATRUM_2_Upstair_1_X = 10.0f;
  public const float GORATRUM_2_Upstair_1_Y = 0.0f;
  public const float GORATRUM_2_Upstair_1_Z = -8.0f;

  public const string GORATRUM_2_Upstair_2_C = "Upstair";
  public const string GORATRUM_2_Upstair_2_O = "2";
  public const float GORATRUM_2_Upstair_2_X = 25.0f;
  public const float GORATRUM_2_Upstair_2_Y = 0.0f;
  public const float GORATRUM_2_Upstair_2_Z = -7.0f;

  public const string GORATRUM_2_Upstair_3_C = "Upstair";
  public const string GORATRUM_2_Upstair_3_O = "3";
  public const float GORATRUM_2_Upstair_3_X = 32.0f; // todo
  public const float GORATRUM_2_Upstair_3_Y = 0.0f;
  public const float GORATRUM_2_Upstair_3_Z = -5.0f;

  public const string GORATRUM_2_Upstair_4_C = "Upstair";
  public const string GORATRUM_2_Upstair_4_O = "4";
  public const float GORATRUM_2_Upstair_4_X = 5.0f;
  public const float GORATRUM_2_Upstair_4_Y = 0.0f;
  public const float GORATRUM_2_Upstair_4_Z = -16.0f;

  public const string GORATRUM_2_Upstair_5_C = "Upstair";
  public const string GORATRUM_2_Upstair_5_O = "5";
  public const float GORATRUM_2_Upstair_5_X = 1.0f;
  public const float GORATRUM_2_Upstair_5_Y = 0.0f;
  public const float GORATRUM_2_Upstair_5_Z = -14.0f;

  public const string GORATRUM_2_Upstair_6_C = "Upstair";
  public const string GORATRUM_2_Upstair_6_O = "6";
  public const float GORATRUM_2_Upstair_6_X = 15.0f;
  public const float GORATRUM_2_Upstair_6_Y = 0.0f;
  public const float GORATRUM_2_Upstair_6_Z = -18.0f;

  public const string GORATRUM_2_Upstair_7_C = "Upstair";
  public const string GORATRUM_2_Upstair_7_O = "7";
  public const float GORATRUM_2_Upstair_7_X = 38.0f;
  public const float GORATRUM_2_Upstair_7_Y = 0.0f;
  public const float GORATRUM_2_Upstair_7_Z = -1.0f;

  public const string GORATRUM_2_Upstair_8_C = "Upstair";
  public const string GORATRUM_2_Upstair_8_O = "8";
  public const float GORATRUM_2_Upstair_8_X = 38.0f;
  public const float GORATRUM_2_Upstair_8_Y = 0.0f;
  public const float GORATRUM_2_Upstair_8_Z = -18.0f;

  public const string GORATRUM_2_Upstair_9_C = "Upstair";
  public const string GORATRUM_2_Upstair_9_O = "9";
  public const float GORATRUM_2_Upstair_9_X = 32.0f;
  public const float GORATRUM_2_Upstair_9_Y = 0.0f;
  public const float GORATRUM_2_Upstair_9_Z = -9.0f;

  public const string GORATRUM_2_Upstair_10_C = "Upstair";
  public const string GORATRUM_2_Upstair_10_O = "10";
  public const float GORATRUM_2_Upstair_10_X = 21.0f;
  public const float GORATRUM_2_Upstair_10_Y = 0.0f;
  public const float GORATRUM_2_Upstair_10_Z = -12.0f;

  public const string GORATRUM_2_Upstair_11_C = "Upstair";
  public const string GORATRUM_2_Upstair_11_O = "11";
  public const float GORATRUM_2_Upstair_11_X = 15.0f;
  public const float GORATRUM_2_Upstair_11_Y = 0.0f;
  public const float GORATRUM_2_Upstair_11_Z = -3.0f;

  public const string GORATRUM_2_Upstair_12_C = "Upstair";
  public const string GORATRUM_2_Upstair_12_O = "12";
  public const float GORATRUM_2_Upstair_12_X = 1.0f;
  public const float GORATRUM_2_Upstair_12_Y = 0.0f;
  public const float GORATRUM_2_Upstair_12_Z = -1.0f;
  #endregion
  #region "階段(下り)"
  // (1F)
  public const string GORATRUM_Downstair_1_C = "Downstair";
  public const string GORATRUM_Downstair_1_O = "1";
  public const float GORATRUM_Downstair_1_X = 10.0f;
  public const float GORATRUM_Downstair_1_Y = 0.0f;
  public const float GORATRUM_Downstair_1_Z = -8.0f;

  public const string GORATRUM_Downstair_2_C = "Downstair";
  public const string GORATRUM_Downstair_2_O = "2";
  public const float GORATRUM_Downstair_2_X = 25.0f;
  public const float GORATRUM_Downstair_2_Y = 0.0f;
  public const float GORATRUM_Downstair_2_Z = -7.0f;

  public const string GORATRUM_Downstair_3_C = "Downstair";
  public const string GORATRUM_Downstair_3_O = "3";
  public const float GORATRUM_Downstair_3_X = 32.0f; // todo
  public const float GORATRUM_Downstair_3_Y = 0.0f;
  public const float GORATRUM_Downstair_3_Z = -5.0f;

  public const string GORATRUM_Downstair_4_C = "Downstair";
  public const string GORATRUM_Downstair_4_O = "4";
  public const float GORATRUM_Downstair_4_X = 5.0f;
  public const float GORATRUM_Downstair_4_Y = 0.0f;
  public const float GORATRUM_Downstair_4_Z = -16.0f;

  public const string GORATRUM_Downstair_5_C = "Downstair";
  public const string GORATRUM_Downstair_5_O = "5";
  public const float GORATRUM_Downstair_5_X = 1.0f;
  public const float GORATRUM_Downstair_5_Y = 0.0f;
  public const float GORATRUM_Downstair_5_Z = -14.0f;

  public const string GORATRUM_Downstair_6_C = "Downstair";
  public const string GORATRUM_Downstair_6_O = "6";
  public const float GORATRUM_Downstair_6_X = 15.0f;
  public const float GORATRUM_Downstair_6_Y = 0.0f;
  public const float GORATRUM_Downstair_6_Z = -18.0f;

  public const string GORATRUM_Downstair_7_C = "Downstair";
  public const string GORATRUM_Downstair_7_O = "7";
  public const float GORATRUM_Downstair_7_X = 38.0f;
  public const float GORATRUM_Downstair_7_Y = 0.0f;
  public const float GORATRUM_Downstair_7_Z = -1.0f;

  public const string GORATRUM_Downstair_8_C = "Downstair";
  public const string GORATRUM_Downstair_8_O = "8";
  public const float GORATRUM_Downstair_8_X = 38.0f;
  public const float GORATRUM_Downstair_8_Y = 0.0f;
  public const float GORATRUM_Downstair_8_Z = -18.0f;

  public const string GORATRUM_Downstair_9_C = "Downstair";
  public const string GORATRUM_Downstair_9_O = "9";
  public const float GORATRUM_Downstair_9_X = 32.0f;
  public const float GORATRUM_Downstair_9_Y = 0.0f;
  public const float GORATRUM_Downstair_9_Z = -9.0f;

  public const string GORATRUM_Downstair_10_C = "Downstair";
  public const string GORATRUM_Downstair_10_O = "10";
  public const float GORATRUM_Downstair_10_X = 21.0f;
  public const float GORATRUM_Downstair_10_Y = 0.0f;
  public const float GORATRUM_Downstair_10_Z = -12.0f;

  public const string GORATRUM_Downstair_11_C = "Downstair";
  public const string GORATRUM_Downstair_11_O = "11";
  public const float GORATRUM_Downstair_11_X = 15.0f;
  public const float GORATRUM_Downstair_11_Y = 0.0f;
  public const float GORATRUM_Downstair_11_Z = -3.0f;

  public const string GORATRUM_Downstair_12_C = "Downstair";
  public const string GORATRUM_Downstair_12_O = "12";
  public const float GORATRUM_Downstair_12_X = 1.0f;
  public const float GORATRUM_Downstair_12_Y = 0.0f;
  public const float GORATRUM_Downstair_12_Z = -1.0f;
  #endregion
  #region "穴"
  // 入口広場右通路の穴１
  public const string GORATRUM_Hole_1_C = "Hole";
  public const string GORATRUM_Hole_1_O = "1";
  public const float GORATRUM_Hole_1_X = 13.0f;
  public const float GORATRUM_Hole_1_Y = -0.5f;
  public const float GORATRUM_Hole_1_Z = -7.0f;

  // 上部噴水広場の右（上の穴）２
  public const string GORATRUM_Hole_2_C = "Hole";
  public const string GORATRUM_Hole_2_O = "2";
  public const float GORATRUM_Hole_2_X = 24.0f;
  public const float GORATRUM_Hole_2_Y = -0.5f;
  public const float GORATRUM_Hole_2_Z = -2.0f;

  // 上部噴水広場の右（下の穴）３
  public const string GORATRUM_Hole_3_C = "Hole";
  public const string GORATRUM_Hole_3_O = "3";
  public const float GORATRUM_Hole_3_X = 24.0f;
  public const float GORATRUM_Hole_3_Y = -0.5f;
  public const float GORATRUM_Hole_3_Z = -5.0f;

  // 入口広場右通路の穴の下側４
  public const string GORATRUM_Hole_4_C = "Hole";
  public const string GORATRUM_Hole_4_O = "4";
  public const float GORATRUM_Hole_4_X = 13.0f;
  public const float GORATRUM_Hole_4_Y = -0.5f;
  public const float GORATRUM_Hole_4_Z = -12.0f;

  // 入口広場右通路の穴の右通路側５
  public const string GORATRUM_Hole_5_C = "Hole";
  public const string GORATRUM_Hole_5_O = "5";
  public const float GORATRUM_Hole_5_X = 24.0f;
  public const float GORATRUM_Hole_5_Y = -0.5f;
  public const float GORATRUM_Hole_5_Z = -9.0f;

  // 右上エル穴の左岸１
  public const string GORATRUM_Hole_6_C = "Hole";
  public const string GORATRUM_Hole_6_O = "6";
  public const float GORATRUM_Hole_6_X = 33.0f;
  public const float GORATRUM_Hole_6_Y = -0.5f;
  public const float GORATRUM_Hole_6_Z = -1.0f;

  // 右上エル穴の左岸２
  public const string GORATRUM_Hole_7_C = "Hole";
  public const string GORATRUM_Hole_7_O = "7";
  public const float GORATRUM_Hole_7_X = 33.0f;
  public const float GORATRUM_Hole_7_Y = -0.5f;
  public const float GORATRUM_Hole_7_Z = -2.0f;

  // 右上エル穴の左岸３
  public const string GORATRUM_Hole_8_C = "Hole";
  public const string GORATRUM_Hole_8_O = "8";
  public const float GORATRUM_Hole_8_X = 33.0f;
  public const float GORATRUM_Hole_8_Y = -0.5f;
  public const float GORATRUM_Hole_8_Z = -3.0f;

  // 右上エル穴の左岸４
  public const string GORATRUM_Hole_9_C = "Hole";
  public const string GORATRUM_Hole_9_O = "9";
  public const float GORATRUM_Hole_9_X = 33.0f;
  public const float GORATRUM_Hole_9_Y = -0.5f;
  public const float GORATRUM_Hole_9_Z = -4.0f;

  // 右上エル穴の左岸５
  public const string GORATRUM_Hole_10_C = "Hole";
  public const string GORATRUM_Hole_10_O = "10";
  public const float GORATRUM_Hole_10_X = 33.0f;
  public const float GORATRUM_Hole_10_Y = -0.5f;
  public const float GORATRUM_Hole_10_Z = -5.0f;

  // 右上エル穴の左岸６
  public const string GORATRUM_Hole_11_C = "Hole";
  public const string GORATRUM_Hole_11_O = "11";
  public const float GORATRUM_Hole_11_X = 33.0f;
  public const float GORATRUM_Hole_11_Y = -0.5f;
  public const float GORATRUM_Hole_11_Z = -6.0f;

  // 左下聖堂の穴：左
  public const string GORATRUM_Hole_12_C = "Hole";
  public const string GORATRUM_Hole_12_O = "12";
  public const float GORATRUM_Hole_12_X = 6.0f;
  public const float GORATRUM_Hole_12_Y = -0.5f;
  public const float GORATRUM_Hole_12_Z = -14.0f;

  // 左下聖堂の穴：右
  public const string GORATRUM_Hole_13_C = "Hole";
  public const string GORATRUM_Hole_13_O = "13";
  public const float GORATRUM_Hole_13_X = 8.0f;
  public const float GORATRUM_Hole_13_Y = -0.5f;
  public const float GORATRUM_Hole_13_Z = -14.0f;

  // 一番左下、聖堂通路先の穴
  public const string GORATRUM_Hole_14_C = "Hole";
  public const string GORATRUM_Hole_14_O = "14";
  public const float GORATRUM_Hole_14_X = 1.0f;
  public const float GORATRUM_Hole_14_Y = -0.5f;
  public const float GORATRUM_Hole_14_Z = -18.0f;

  // 右下中央の穴
  public const string GORATRUM_Hole_15_C = "Hole";
  public const string GORATRUM_Hole_15_O = "15";
  public const float GORATRUM_Hole_15_X = 33.0f;
  public const float GORATRUM_Hole_15_Y = -0.5f;
  public const float GORATRUM_Hole_15_Z = -14.0f;

  // 右上エル穴の右岸１
  public const string GORATRUM_Hole_16_C = "Hole";
  public const string GORATRUM_Hole_16_O = "16";
  public const float GORATRUM_Hole_16_X = 34.0f;
  public const float GORATRUM_Hole_16_Y = -0.5f;
  public const float GORATRUM_Hole_16_Z = -1.0f;

  // 右上エル穴の右岸２
  public const string GORATRUM_Hole_17_C = "Hole";
  public const string GORATRUM_Hole_17_O = "17";
  public const float GORATRUM_Hole_17_X = 34.0f;
  public const float GORATRUM_Hole_17_Y = -0.5f;
  public const float GORATRUM_Hole_17_Z = -2.0f;

  // 右上エル穴の右岸３
  public const string GORATRUM_Hole_18_C = "Hole";
  public const string GORATRUM_Hole_18_O = "18";
  public const float GORATRUM_Hole_18_X = 34.0f;
  public const float GORATRUM_Hole_18_Y = -0.5f;
  public const float GORATRUM_Hole_18_Z = -3.0f;

  // 右上エル穴の右岸４
  public const string GORATRUM_Hole_19_C = "Hole";
  public const string GORATRUM_Hole_19_O = "19";
  public const float GORATRUM_Hole_19_X = 34.0f;
  public const float GORATRUM_Hole_19_Y = -0.5f;
  public const float GORATRUM_Hole_19_Z = -4.0f;

  // 右上エル穴の右岸５
  public const string GORATRUM_Hole_20_C = "Hole";
  public const string GORATRUM_Hole_20_O = "20";
  public const float GORATRUM_Hole_20_X = 34.0f;
  public const float GORATRUM_Hole_20_Y = -0.5f;
  public const float GORATRUM_Hole_20_Z = -5.0f;

  // 右上エル穴の右岸６
  public const string GORATRUM_Hole_21_C = "Hole";
  public const string GORATRUM_Hole_21_O = "21";
  public const float GORATRUM_Hole_21_X = 35.0f;
  public const float GORATRUM_Hole_21_Y = -0.5f;
  public const float GORATRUM_Hole_21_Z = -5.0f;

  // 右上エル穴の右岸７
  public const string GORATRUM_Hole_22_C = "Hole";
  public const string GORATRUM_Hole_22_O = "22";
  public const float GORATRUM_Hole_22_X = 36.0f;
  public const float GORATRUM_Hole_22_Y = -0.5f;
  public const float GORATRUM_Hole_22_Z = -5.0f;

  // 右上エル穴の下岸１
  public const string GORATRUM_Hole_23_C = "Hole";
  public const string GORATRUM_Hole_23_O = "23";
  public const float GORATRUM_Hole_23_X = 34.0f;
  public const float GORATRUM_Hole_23_Y = -0.5f;
  public const float GORATRUM_Hole_23_Z = -6.0f;

  // 右上エル穴の下岸２
  public const string GORATRUM_Hole_24_C = "Hole";
  public const string GORATRUM_Hole_24_O = "24";
  public const float GORATRUM_Hole_24_X = 35.0f;
  public const float GORATRUM_Hole_24_Y = -0.5f;
  public const float GORATRUM_Hole_24_Z = -6.0f;

  // 右上エル穴の下岸３
  public const string GORATRUM_Hole_25_C = "Hole";
  public const string GORATRUM_Hole_25_O = "25";
  public const float GORATRUM_Hole_25_X = 36.0f;
  public const float GORATRUM_Hole_25_Y = -0.5f;
  public const float GORATRUM_Hole_25_Z = -6.0f;

  // 右下の三角穴１
  public const string GORATRUM_Hole_26_C = "Hole";
  public const string GORATRUM_Hole_26_O = "26";
  public const float GORATRUM_Hole_26_X = 36.0f;
  public const float GORATRUM_Hole_26_Y = -0.5f;
  public const float GORATRUM_Hole_26_Z = -16.0f;

  // 右下の三角穴２
  public const string GORATRUM_Hole_27_C = "Hole";
  public const string GORATRUM_Hole_27_O = "27";
  public const float GORATRUM_Hole_27_X = 37.0f;
  public const float GORATRUM_Hole_27_Y = -0.5f;
  public const float GORATRUM_Hole_27_Z = -16.0f;

  // 右下の三角穴３
  public const string GORATRUM_Hole_28_C = "Hole";
  public const string GORATRUM_Hole_28_O = "28";
  public const float GORATRUM_Hole_28_X = 36.0f;
  public const float GORATRUM_Hole_28_Y = -0.5f;
  public const float GORATRUM_Hole_28_Z = -17.0f;

  // 中央一方通行ルート穴１
  public const string GORATRUM_Hole_29_C = "Hole";
  public const string GORATRUM_Hole_29_O = "29";
  public const float GORATRUM_Hole_29_X = 28.0f;
  public const float GORATRUM_Hole_29_Y = -0.5f;
  public const float GORATRUM_Hole_29_Z = -10.0f;

  // 中央一方通行ルート穴２
  public const string GORATRUM_Hole_30_C = "Hole";
  public const string GORATRUM_Hole_30_O = "30";
  public const float GORATRUM_Hole_30_X = 17.0f;
  public const float GORATRUM_Hole_30_Y = -0.5f;
  public const float GORATRUM_Hole_30_Z = -15.0f;

  // 中央一方通行ルート穴３
  public const string GORATRUM_Hole_31_C = "Hole";
  public const string GORATRUM_Hole_31_O = "31";
  public const float GORATRUM_Hole_31_X = 11.0f;
  public const float GORATRUM_Hole_31_Y = -0.5f;
  public const float GORATRUM_Hole_31_Z = -3.0f;
  #endregion
  #region "扉"
  // 入口広場の下扉
  public const string GORATRUM_CopperDoor_1_C = "CopperDoor";
  public const string GORATRUM_CopperDoor_1_O = "1";
  public const float GORATRUM_CopperDoor_1_X = 8.0f;
  public const float GORATRUM_CopperDoor_1_Y = 1.0f;
  public const float GORATRUM_CopperDoor_1_Z = -8.0f;

  // 入口広場の左扉
  public const string GORATRUM_CopperDoor_2_C = "CopperDoor";
  public const string GORATRUM_CopperDoor_2_O = "2";
  public const float GORATRUM_CopperDoor_2_X = 3.0f;
  public const float GORATRUM_CopperDoor_2_Y = 1.0f;
  public const float GORATRUM_CopperDoor_2_Z = -5.0f;

  // 中央通路を繋ぐドア
  public const string GORATRUM_CopperDoor_3_C = "CopperDoor";
  public const string GORATRUM_CopperDoor_3_O = "3";
  public const float GORATRUM_CopperDoor_3_X = 25.0f;
  public const float GORATRUM_CopperDoor_3_Y = 1.0f;
  public const float GORATRUM_CopperDoor_3_Z = -17.0f;
  #endregion
  #region "看板"
  public const string GORATRUM_MessageBoard_1_C = "MessageBoard";
  public const string GORATRUM_MessageBoard_1_O = "1";
  public const float GORATRUM_MessageBoard_1_X = 8.0f;
  public const float GORATRUM_MessageBoard_1_Y = 1.0f;
  public const float GORATRUM_MessageBoard_1_Z = -5.0f;

  public const string GORATRUM_MessageBoard_2_C = "MessageBoard";
  public const string GORATRUM_MessageBoard_2_O = "2";
  public const float GORATRUM_MessageBoard_2_X = 32.0f;
  public const float GORATRUM_MessageBoard_2_Y = 1.0f;
  public const float GORATRUM_MessageBoard_2_Z = -2.0f;

  public const string GORATRUM_MessageBoard_3_C = "MessageBoard";
  public const string GORATRUM_MessageBoard_3_O = "3";
  public const float GORATRUM_MessageBoard_3_X = 25.0f;
  public const float GORATRUM_MessageBoard_3_Y = 1.0f;
  public const float GORATRUM_MessageBoard_3_Z = -14.0f;

  public const string GORATRUM_MessageBoard_4_C = "MessageBoard";
  public const string GORATRUM_MessageBoard_4_O = "4";
  public const float GORATRUM_MessageBoard_4_X = 7.0f;
  public const float GORATRUM_MessageBoard_4_Y = 1.0f;
  public const float GORATRUM_MessageBoard_4_Z = -15.0f;

  public const string GORATRUM_MessageBoard_5_C = "MessageBoard";
  public const string GORATRUM_MessageBoard_5_O = "5";
  public const float GORATRUM_MessageBoard_5_X = 35.0f;
  public const float GORATRUM_MessageBoard_5_Y = 1.0f;
  public const float GORATRUM_MessageBoard_5_Z = -7.0f;
  #endregion
  #region "ObsidianPortal"
  // Odsidian Portal
  public const string GORATRUM_2_ObsidianPortal_1_C = "ObsidianPortal";
  public const string GORATRUM_2_ObsidianPortal_1_O = "35";
  public const float GORATRUM_2_ObsidianPortal_1_X = 20.0f;
  public const float GORATRUM_2_ObsidianPortal_1_Y = 1.0f;
  public const float GORATRUM_2_ObsidianPortal_1_Z = -3.0f;
  #endregion
  #region "イベント"
  // 1F
  // 入口広場のエントリー地点
  public const string GORATRUM_Event_1_C = "Event";
  public const string GORATRUM_Event_1_O = "1";
  public const float GORATRUM_Event_1_X = 8.0f;
  public const float GORATRUM_Event_1_Y = 0.0f;
  public const float GORATRUM_Event_1_Z = -3.0f;

  // 左下聖堂前の３タイル（左）
  public const string GORATRUM_Event_2_C = "Event";
  public const string GORATRUM_Event_2_O = "2";
  public const float GORATRUM_Event_2_X = 6.0f;
  public const float GORATRUM_Event_2_Y = 0.0f;
  public const float GORATRUM_Event_2_Z = -17.0f;

  // 左下聖堂前の３タイル（中央）
  public const string GORATRUM_Event_3_C = "Event";
  public const string GORATRUM_Event_3_O = "3";
  public const float GORATRUM_Event_3_X = 7.0f;
  public const float GORATRUM_Event_3_Y = 0.0f;
  public const float GORATRUM_Event_3_Z = -17.0f;

  // 左下聖堂前の３タイル（右）
  public const string GORATRUM_Event_4_C = "Event";
  public const string GORATRUM_Event_4_O = "4";
  public const float GORATRUM_Event_4_X = 8.0f;
  public const float GORATRUM_Event_4_Y = 0.0f;
  public const float GORATRUM_Event_4_Z = -17.0f;

  // 2F
  // 中央の旧聖堂の入口タイル
  public const string GORATRUM_2_Event_1_C = "Event";
  public const string GORATRUM_2_Event_1_O = "1";
  public const float GORATRUM_2_Event_1_X = 20.0f;
  public const float GORATRUM_2_Event_1_Y = 0.0f;
  public const float GORATRUM_2_Event_1_Z = -6.0f;

  // ボス手前
  public const string GORATRUM_2_Event_2_C = "Event";
  public const string GORATRUM_2_Event_2_O = "2";
  public const float GORATRUM_2_Event_2_X = 7.0f;
  public const float GORATRUM_2_Event_2_Y = -0.0f;
  public const float GORATRUM_2_Event_2_Z = -8.0f;

  // ボス
  public const string GORATRUM_2_Event_3_C = "Event";
  public const string GORATRUM_2_Event_3_O = "38";
  public const float GORATRUM_2_Event_3_X = 6.0f;
  public const float GORATRUM_2_Event_3_Y = -0.0f;
  public const float GORATRUM_2_Event_3_Z = -8.0f;
  #endregion
  #endregion
  #region "神秘の森"
  #region "宝箱"
  public const string MYSTICFOREST_Treasure_1_C = "Treasure";
  public const string MYSTICFOREST_Treasure_1_O = "1";
  public const float MYSTICFOREST_Treasure_1_X = 32.0f;
  public const float MYSTICFOREST_Treasure_1_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_1_Z = -9.0f;

  public const string MYSTICFOREST_Treasure_2_C = "Treasure";
  public const string MYSTICFOREST_Treasure_2_O = "2";
  public const float MYSTICFOREST_Treasure_2_X = 33.0f;
  public const float MYSTICFOREST_Treasure_2_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_2_Z = -19.0f;

  public const string MYSTICFOREST_Treasure_3_C = "Treasure";
  public const string MYSTICFOREST_Treasure_3_O = "3";
  public const float MYSTICFOREST_Treasure_3_X = 22.0f;
  public const float MYSTICFOREST_Treasure_3_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_3_Z = -8.0f;

  public const string MYSTICFOREST_Treasure_4_C = "Treasure";
  public const string MYSTICFOREST_Treasure_4_O = "4";
  public const float MYSTICFOREST_Treasure_4_X = 44.0f;
  public const float MYSTICFOREST_Treasure_4_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_4_Z = -3.0f;

  public const string MYSTICFOREST_Treasure_5_C = "Treasure";
  public const string MYSTICFOREST_Treasure_5_O = "5";
  public const float MYSTICFOREST_Treasure_5_X = 3.0f;
  public const float MYSTICFOREST_Treasure_5_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_5_Z = -2.0f;

  public const string MYSTICFOREST_Treasure_6_C = "Treasure";
  public const string MYSTICFOREST_Treasure_6_O = "6";
  public const float MYSTICFOREST_Treasure_6_X = 41.0f;
  public const float MYSTICFOREST_Treasure_6_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_6_Z = -19.0f;

  public const string MYSTICFOREST_Treasure_7_C = "Treasure";
  public const string MYSTICFOREST_Treasure_7_O = "7";
  public const float MYSTICFOREST_Treasure_7_X = 13.0f;
  public const float MYSTICFOREST_Treasure_7_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_7_Z = -18.0f;

  public const string MYSTICFOREST_Treasure_8_C = "Treasure";
  public const string MYSTICFOREST_Treasure_8_O = "8";
  public const float MYSTICFOREST_Treasure_8_X = 7.0f;
  public const float MYSTICFOREST_Treasure_8_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_8_Z = -24.0f;

  public const string MYSTICFOREST_Treasure_9_C = "Treasure";
  public const string MYSTICFOREST_Treasure_9_O = "9";
  public const float MYSTICFOREST_Treasure_9_X = 9.0f;
  public const float MYSTICFOREST_Treasure_9_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_9_Z = -28.0f;

  public const string MYSTICFOREST_Treasure_10_C = "Treasure";
  public const string MYSTICFOREST_Treasure_10_O = "10";
  public const float MYSTICFOREST_Treasure_10_X = 1.0f;
  public const float MYSTICFOREST_Treasure_10_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_10_Z = -22.0f;

  public const string MYSTICFOREST_Treasure_11_C = "Treasure";
  public const string MYSTICFOREST_Treasure_11_O = "11";
  public const float MYSTICFOREST_Treasure_11_X = 40.0f;
  public const float MYSTICFOREST_Treasure_11_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_11_Z = -5.0f;

  public const string MYSTICFOREST_Treasure_12_C = "Treasure";
  public const string MYSTICFOREST_Treasure_12_O = "12";
  public const float MYSTICFOREST_Treasure_12_X = 12.0f;
  public const float MYSTICFOREST_Treasure_12_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_12_Z = -11.0f;

  public const string MYSTICFOREST_Treasure_13_C = "Treasure";
  public const string MYSTICFOREST_Treasure_13_O = "13";
  public const float MYSTICFOREST_Treasure_13_X = 36.0f;
  public const float MYSTICFOREST_Treasure_13_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_13_Z = -1.0f;

  public const string MYSTICFOREST_Treasure_14_C = "Treasure";
  public const string MYSTICFOREST_Treasure_14_O = "14";
  public const float MYSTICFOREST_Treasure_14_X = 30.0f;
  public const float MYSTICFOREST_Treasure_14_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_14_Z = -22.0f;

  public const string MYSTICFOREST_Treasure_15_C = "Treasure";
  public const string MYSTICFOREST_Treasure_15_O = "15";
  public const float MYSTICFOREST_Treasure_15_X = 33.0f;
  public const float MYSTICFOREST_Treasure_15_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_15_Z = -23.0f;

  public const string MYSTICFOREST_Treasure_16_C = "Treasure";
  public const string MYSTICFOREST_Treasure_16_O = "16";
  public const float MYSTICFOREST_Treasure_16_X = 40.0f;
  public const float MYSTICFOREST_Treasure_16_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_16_Z = -10.0f;

  public const string MYSTICFOREST_Treasure_17_C = "Treasure";
  public const string MYSTICFOREST_Treasure_17_O = "17";
  public const float MYSTICFOREST_Treasure_17_X = 22.0f;
  public const float MYSTICFOREST_Treasure_17_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_17_Z = -4.0f;

  public const string MYSTICFOREST_Treasure_18_C = "Treasure";
  public const string MYSTICFOREST_Treasure_18_O = "18";
  public const float MYSTICFOREST_Treasure_18_X = 19.0f;
  public const float MYSTICFOREST_Treasure_18_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_18_Z = -14.0f;
  #endregion
  #region "看板"
  public const string MYSTICFOREST_MessageBoard_1_C = "MessageBoard";
  public const string MYSTICFOREST_MessageBoard_1_O = "1";
  public const float MYSTICFOREST_MessageBoard_1_X = 6.0f;
  public const float MYSTICFOREST_MessageBoard_1_Y = 1.0f;
  public const float MYSTICFOREST_MessageBoard_1_Z = -9.0f;

  public const string MYSTICFOREST_MessageBoard_2_C = "MessageBoard";
  public const string MYSTICFOREST_MessageBoard_2_O = "2";
  public const float MYSTICFOREST_MessageBoard_2_X = 35.0f;
  public const float MYSTICFOREST_MessageBoard_2_Y = 1.0f;
  public const float MYSTICFOREST_MessageBoard_2_Z = -14.0f;

  public const string MYSTICFOREST_MessageBoard_3_C = "MessageBoard";
  public const string MYSTICFOREST_MessageBoard_3_O = "3";
  public const float MYSTICFOREST_MessageBoard_3_X = 5.0f;
  public const float MYSTICFOREST_MessageBoard_3_Y = 1.0f;
  public const float MYSTICFOREST_MessageBoard_3_Z = -16.0f;

  public const string MYSTICFOREST_MessageBoard_4_C = "MessageBoard";
  public const string MYSTICFOREST_MessageBoard_4_O = "4";
  public const float MYSTICFOREST_MessageBoard_4_X = 22.0f;
  public const float MYSTICFOREST_MessageBoard_4_Y = 1.0f;
  public const float MYSTICFOREST_MessageBoard_4_Z = -19.0f;
  #endregion
  #region "イベント"
  // 入口広場のエントリー地点
  public const string MYSTICFOREST_Event_1_C = "Event";
  public const string MYSTICFOREST_Event_1_O = "1";
  public const float MYSTICFOREST_Event_1_X = 9.0f;
  public const float MYSTICFOREST_Event_1_Y = 0.0f;
  public const float MYSTICFOREST_Event_1_Z = -7.0f;

  public const string MYSTICFOREST_Event_1_2_C = "Event";
  public const string MYSTICFOREST_Event_1_2_O = "1-2";
  public const float MYSTICFOREST_Event_1_2_X = 36.0f;
  public const float MYSTICFOREST_Event_1_2_Y = 0.0f;
  public const float MYSTICFOREST_Event_1_2_Z = -20.0f;

  public const string MYSTICFOREST_Event_2_C = "Event";
  public const string MYSTICFOREST_Event_2_O = "2";
  public const float MYSTICFOREST_Event_2_X = 29.0f;
  public const float MYSTICFOREST_Event_2_Y = 0.0f;
  public const float MYSTICFOREST_Event_2_Z = -8.0f;

  public const string MYSTICFOREST_Event_2_2_C = "Event";
  public const string MYSTICFOREST_Event_2_2_O = "2-2";
  public const float MYSTICFOREST_Event_2_2_X = 21.0f;
  public const float MYSTICFOREST_Event_2_2_Y = 0.0f;
  public const float MYSTICFOREST_Event_2_2_Z = -22.0f;

  public const string MYSTICFOREST_Event_2_3_C = "Event";
  public const string MYSTICFOREST_Event_2_3_O = "2-3";
  public const float MYSTICFOREST_Event_2_3_X = 44.0f;
  public const float MYSTICFOREST_Event_2_3_Y = 0.0f;
  public const float MYSTICFOREST_Event_2_3_Z = -5.0f;

  public const string MYSTICFOREST_Event_3_C = "Event";
  public const string MYSTICFOREST_Event_3_O = "3";
  public const float MYSTICFOREST_Event_3_X = 23.0f;
  public const float MYSTICFOREST_Event_3_Y = 0.0f;
  public const float MYSTICFOREST_Event_3_Z = -14.0f;

  public const string MYSTICFOREST_Event_4_C = "Event";
  public const string MYSTICFOREST_Event_4_O = "4";
  public const float MYSTICFOREST_Event_4_X = 18.0f;
  public const float MYSTICFOREST_Event_4_Y = 0.0f;
  public const float MYSTICFOREST_Event_4_Z = -18.0f;

  public const string MYSTICFOREST_Event_4_2_C = "Event";
  public const string MYSTICFOREST_Event_4_2_O = "4-2";
  public const float MYSTICFOREST_Event_4_2_X = 22.0f;
  public const float MYSTICFOREST_Event_4_2_Y = 0.0f;
  public const float MYSTICFOREST_Event_4_2_Z = -3.0f;

  public const string MYSTICFOREST_Event_4_3_C = "Event";
  public const string MYSTICFOREST_Event_4_3_O = "4-3";
  public const float MYSTICFOREST_Event_4_3_X = 22.0f;
  public const float MYSTICFOREST_Event_4_3_Y = 0.0f;
  public const float MYSTICFOREST_Event_4_3_Z = -5.0f;

  public const string MYSTICFOREST_Event_4_4_C = "Event";
  public const string MYSTICFOREST_Event_4_4_O = "4-4";
  public const float MYSTICFOREST_Event_4_4_X = 13.0f;
  public const float MYSTICFOREST_Event_4_4_Y = 0.0f;
  public const float MYSTICFOREST_Event_4_4_Z = -3.0f;

  public const string MYSTICFOREST_Event_4_5_C = "Event";
  public const string MYSTICFOREST_Event_4_5_O = "4-5";
  public const float MYSTICFOREST_Event_4_5_X = 10.0f;
  public const float MYSTICFOREST_Event_4_5_Y = 0.0f;
  public const float MYSTICFOREST_Event_4_5_Z = -1.0f;

  public const string MYSTICFOREST_Event_4_6_C = "Event";
  public const string MYSTICFOREST_Event_4_6_O = "4-6";
  public const float MYSTICFOREST_Event_4_6_X = 7.0f;
  public const float MYSTICFOREST_Event_4_6_Y = 0.0f;
  public const float MYSTICFOREST_Event_4_6_Z = -2.0f;

  public const string MYSTICFOREST_Event_4_7_C = "Event";
  public const string MYSTICFOREST_Event_4_7_O = "4-7";
  public const float MYSTICFOREST_Event_4_7_X = 1.0f;
  public const float MYSTICFOREST_Event_4_7_Y = 0.0f;
  public const float MYSTICFOREST_Event_4_7_Z = -7.0f;

  public const string MYSTICFOREST_Event_4_8_C = "Event";
  public const string MYSTICFOREST_Event_4_8_O = "4-8";
  public const float MYSTICFOREST_Event_4_8_X = 5.0f;
  public const float MYSTICFOREST_Event_4_8_Y = 0.0f;
  public const float MYSTICFOREST_Event_4_8_Z = -5.0f;

  public const string MYSTICFOREST_Event_4_9_C = "Event";
  public const string MYSTICFOREST_Event_4_9_O = "4-9";
  public const float MYSTICFOREST_Event_4_9_X = 1.0f;
  public const float MYSTICFOREST_Event_4_9_Y = 0.0f;
  public const float MYSTICFOREST_Event_4_9_Z = -2.0f;

  public const string MYSTICFOREST_Event_5_C = "Event";
  public const string MYSTICFOREST_Event_5_O = "5";
  public const float MYSTICFOREST_Event_5_X = 21.0f;
  public const float MYSTICFOREST_Event_5_Y = 0.0f;
  public const float MYSTICFOREST_Event_5_Z = -4.0f;

  public const string MYSTICFOREST_Event_6_C = "Event";
  public const string MYSTICFOREST_Event_6_O = "6";
  public const float MYSTICFOREST_Event_6_X = 1.0f;
  public const float MYSTICFOREST_Event_6_Y = 0.0f;
  public const float MYSTICFOREST_Event_6_Z = -24.0f;

  public const string MYSTICFOREST_Event_7_C = "Event";
  public const string MYSTICFOREST_Event_7_O = "7";
  public const float MYSTICFOREST_Event_7_X = 3.0f;
  public const float MYSTICFOREST_Event_7_Y = 0.0f;
  public const float MYSTICFOREST_Event_7_Z = -24.0f;

  public const string MYSTICFOREST_Event_8_C = "Event";
  public const string MYSTICFOREST_Event_8_O = "8";
  public const float MYSTICFOREST_Event_8_X = 5.0f;
  public const float MYSTICFOREST_Event_8_Y = 0.0f;
  public const float MYSTICFOREST_Event_8_Z = -24.0f;

  public const string MYSTICFOREST_Event_9_C = "Event";
  public const string MYSTICFOREST_Event_9_O = "9";
  public const float MYSTICFOREST_Event_9_X = 48.0f;
  public const float MYSTICFOREST_Event_9_Y = 0.0f;
  public const float MYSTICFOREST_Event_9_Z = -5.0f;

  public const string MYSTICFOREST_Event_10_C = "Event";
  public const string MYSTICFOREST_Event_10_O = "10";
  public const float MYSTICFOREST_Event_10_X = 46.0f;
  public const float MYSTICFOREST_Event_10_Y = 0.0f;
  public const float MYSTICFOREST_Event_10_Z = -5.0f;

  public const string MYSTICFOREST_Event_11_C = "Event";
  public const string MYSTICFOREST_Event_11_O = "11";
  public const float MYSTICFOREST_Event_11_X = 12.0f;
  public const float MYSTICFOREST_Event_11_Y = 0.0f;
  public const float MYSTICFOREST_Event_11_Z = -4.0f;

  public const string MYSTICFOREST_Event_12_C = "Event";
  public const string MYSTICFOREST_Event_12_O = "12";
  public const float MYSTICFOREST_Event_12_X = 11.0f;
  public const float MYSTICFOREST_Event_12_Y = 0.0f;
  public const float MYSTICFOREST_Event_12_Z = -2.0f;

  public const string MYSTICFOREST_Event_13_C = "Event";
  public const string MYSTICFOREST_Event_13_O = "13";
  public const float MYSTICFOREST_Event_13_X = 8.0f;
  public const float MYSTICFOREST_Event_13_Y = 0.0f;
  public const float MYSTICFOREST_Event_13_Z = -1.0f;

  public const string MYSTICFOREST_Event_14_C = "Event";
  public const string MYSTICFOREST_Event_14_O = "14";
  public const float MYSTICFOREST_Event_14_X = 3.0f;
  public const float MYSTICFOREST_Event_14_Y = 0.0f;
  public const float MYSTICFOREST_Event_14_Z = -7.0f;

  public const string MYSTICFOREST_Event_15_C = "Event";
  public const string MYSTICFOREST_Event_15_O = "15";
  public const float MYSTICFOREST_Event_15_X = 6.0f;
  public const float MYSTICFOREST_Event_15_Y = 0.0f;
  public const float MYSTICFOREST_Event_15_Z = -6.0f;

  public const string MYSTICFOREST_Event_16_C = "Event";
  public const string MYSTICFOREST_Event_16_O = "16";
  public const float MYSTICFOREST_Event_16_X = 41.0f;
  public const float MYSTICFOREST_Event_16_Y = 0.0f;
  public const float MYSTICFOREST_Event_16_Z = -13.0f;

  public const string MYSTICFOREST_Event_17_C = "Event";
  public const string MYSTICFOREST_Event_17_O = "17";
  public const float MYSTICFOREST_Event_17_X = 43.0f;
  public const float MYSTICFOREST_Event_17_Y = 0.0f;
  public const float MYSTICFOREST_Event_17_Z = -15.0f;

  public const string MYSTICFOREST_Event_18_C = "Event";
  public const string MYSTICFOREST_Event_18_O = "18";
  public const float MYSTICFOREST_Event_18_X = 43.0f;
  public const float MYSTICFOREST_Event_18_Y = 0.0f;
  public const float MYSTICFOREST_Event_18_Z = -11.0f;

  public const string MYSTICFOREST_Event_19_C = "Event";
  public const string MYSTICFOREST_Event_19_O = "19";
  public const float MYSTICFOREST_Event_19_X = 7.0f;
  public const float MYSTICFOREST_Event_19_Y = 0.0f;
  public const float MYSTICFOREST_Event_19_Z = -28.0f;

  public const string MYSTICFOREST_Event_20_C = "Event";
  public const string MYSTICFOREST_Event_20_O = "20";
  public const float MYSTICFOREST_Event_20_X = 2.0f;
  public const float MYSTICFOREST_Event_20_Y = 0.0f;
  public const float MYSTICFOREST_Event_20_Z = -13.0f;

  public const string MYSTICFOREST_Event_20_2_C = "Event";
  public const string MYSTICFOREST_Event_20_2_O = "20-2";
  public const float MYSTICFOREST_Event_20_2_X = 2.0f;
  public const float MYSTICFOREST_Event_20_2_Y = 0.0f;
  public const float MYSTICFOREST_Event_20_2_Z = -15.0f;

  public const string MYSTICFOREST_Event_20_3_C = "Event";
  public const string MYSTICFOREST_Event_20_3_O = "20-3";
  public const float MYSTICFOREST_Event_20_3_X = 3.0f;
  public const float MYSTICFOREST_Event_20_3_Y = 0.0f;
  public const float MYSTICFOREST_Event_20_3_Z = -16.0f;

  public const string MYSTICFOREST_Event_20_4_C = "Event";
  public const string MYSTICFOREST_Event_20_4_O = "20-4";
  public const float MYSTICFOREST_Event_20_4_X = 1.0f;
  public const float MYSTICFOREST_Event_20_4_Y = 0.0f;
  public const float MYSTICFOREST_Event_20_4_Z = -18.0f;

  public const string MYSTICFOREST_Event_20_5_C = "Event";
  public const string MYSTICFOREST_Event_20_5_O = "20-5";
  public const float MYSTICFOREST_Event_20_5_X = 3.0f;
  public const float MYSTICFOREST_Event_20_5_Y = 0.0f;
  public const float MYSTICFOREST_Event_20_5_Z = -20.0f;

  public const string MYSTICFOREST_Event_21_C = "Event";
  public const string MYSTICFOREST_Event_21_O = "21";
  public const float MYSTICFOREST_Event_21_X = 4.0f;
  public const float MYSTICFOREST_Event_21_Y = 0.0f;
  public const float MYSTICFOREST_Event_21_Z = -22.0f;

  public const string MYSTICFOREST_Event_22_C = "Event";
  public const string MYSTICFOREST_Event_22_O = "22";
  public const float MYSTICFOREST_Event_22_X = 40.0f;
  public const float MYSTICFOREST_Event_22_Y = 0.0f;
  public const float MYSTICFOREST_Event_22_Z = -3.0f;

  public const string MYSTICFOREST_Event_23_C = "Event";
  public const string MYSTICFOREST_Event_23_O = "23";
  public const float MYSTICFOREST_Event_23_X = 32.0f;
  public const float MYSTICFOREST_Event_23_Y = 0.0f;
  public const float MYSTICFOREST_Event_23_Z = -4.0f;

  public const string MYSTICFOREST_Event_24_C = "Event";
  public const string MYSTICFOREST_Event_24_O = "24";
  public const float MYSTICFOREST_Event_24_X = 32.0f;
  public const float MYSTICFOREST_Event_24_Y = 0.0f;
  public const float MYSTICFOREST_Event_24_Z = -2.0f;

  public const string MYSTICFOREST_Event_25_C = "Event";
  public const string MYSTICFOREST_Event_25_O = "25";
  public const float MYSTICFOREST_Event_25_X = 28.0f;
  public const float MYSTICFOREST_Event_25_Y = 0.0f;
  public const float MYSTICFOREST_Event_25_Z = -2.0f;

  public const string MYSTICFOREST_Event_26_C = "Event";
  public const string MYSTICFOREST_Event_26_O = "26";
  public const float MYSTICFOREST_Event_26_X = 28.0f;
  public const float MYSTICFOREST_Event_26_Y = 0.0f;
  public const float MYSTICFOREST_Event_26_Z = -4.0f;

  public const string MYSTICFOREST_Event_27_C = "Event";
  public const string MYSTICFOREST_Event_27_O = "27";
  public const float MYSTICFOREST_Event_27_X = 27.0f;
  public const float MYSTICFOREST_Event_27_Y = 0.0f;
  public const float MYSTICFOREST_Event_27_Z = -6.0f;

  public const string MYSTICFOREST_Event_28_C = "Event";
  public const string MYSTICFOREST_Event_28_O = "28";
  public const float MYSTICFOREST_Event_28_X = 25.0f;
  public const float MYSTICFOREST_Event_28_Y = 0.0f;
  public const float MYSTICFOREST_Event_28_Z = -6.0f;

  public const string MYSTICFOREST_Event_29_C = "Event";
  public const string MYSTICFOREST_Event_29_O = "29";
  public const float MYSTICFOREST_Event_29_X = 24.0f;
  public const float MYSTICFOREST_Event_29_Y = 0.0f;
  public const float MYSTICFOREST_Event_29_Z = -9.0f;

  public const string MYSTICFOREST_Event_30_C = "Event";
  public const string MYSTICFOREST_Event_30_O = "30";
  public const float MYSTICFOREST_Event_30_X = 24.0f;
  public const float MYSTICFOREST_Event_30_Y = 0.0f;
  public const float MYSTICFOREST_Event_30_Z = -11.0f;

  public const string MYSTICFOREST_Event_31_C = "Event";
  public const string MYSTICFOREST_Event_31_O = "31";
  public const float MYSTICFOREST_Event_31_X = 19.0f;
  public const float MYSTICFOREST_Event_31_Y = 0.0f;
  public const float MYSTICFOREST_Event_31_Z = -11.0f;

  public const string MYSTICFOREST_Event_32_C = "Event";
  public const string MYSTICFOREST_Event_32_O = "32";
  public const float MYSTICFOREST_Event_32_X = 17.0f;
  public const float MYSTICFOREST_Event_32_Y = 0.0f;
  public const float MYSTICFOREST_Event_32_Z = -11.0f;

  public const string MYSTICFOREST_Event_33_C = "Event";
  public const string MYSTICFOREST_Event_33_O = "33";
  public const float MYSTICFOREST_Event_33_X = 34.0f;
  public const float MYSTICFOREST_Event_33_Y = 0.0f;
  public const float MYSTICFOREST_Event_33_Z = -1.0f;

  public const string MYSTICFOREST_Event_34_C = "Event";
  public const string MYSTICFOREST_Event_34_O = "34";
  public const float MYSTICFOREST_Event_34_X = 26.0f;
  public const float MYSTICFOREST_Event_34_Y = 0.0f;
  public const float MYSTICFOREST_Event_34_Z = -16.0f;

  public const string MYSTICFOREST_Event_35_C = "Event";
  public const string MYSTICFOREST_Event_35_O = "35";
  public const float MYSTICFOREST_Event_35_X = 31;
  public const float MYSTICFOREST_Event_35_Y = 0.0f;
  public const float MYSTICFOREST_Event_35_Z = -21.0f;

  public const string MYSTICFOREST_Event_36_C = "Event";
  public const string MYSTICFOREST_Event_36_O = "36";
  public const float MYSTICFOREST_Event_36_X = 30.0f;
  public const float MYSTICFOREST_Event_36_Y = 0.0f;
  public const float MYSTICFOREST_Event_36_Z = -18.0f;

  public const string MYSTICFOREST_Event_37_C = "Event";
  public const string MYSTICFOREST_Event_37_O = "37";
  public const float MYSTICFOREST_Event_37_X = 25.0f;
  public const float MYSTICFOREST_Event_37_Y = 0.0f;
  public const float MYSTICFOREST_Event_37_Z = -21.0f;

  public const string MYSTICFOREST_Event_38_C = "Event";
  public const string MYSTICFOREST_Event_38_O = "38";
  public const float MYSTICFOREST_Event_38_X = 23.0f;
  public const float MYSTICFOREST_Event_38_Y = 0.0f;
  public const float MYSTICFOREST_Event_38_Z = -25.0f;

  public const string MYSTICFOREST_Event_39_C = "Event";
  public const string MYSTICFOREST_Event_39_O = "39";
  public const float MYSTICFOREST_Event_39_X = 23.0f;
  public const float MYSTICFOREST_Event_39_Y = 0.0f;
  public const float MYSTICFOREST_Event_39_Z = -27.0f;

  public const string MYSTICFOREST_Event_40_C = "Event";
  public const string MYSTICFOREST_Event_40_O = "40";
  public const float MYSTICFOREST_Event_40_X = 24.0f;
  public const float MYSTICFOREST_Event_40_Y = 0.0f;
  public const float MYSTICFOREST_Event_40_Z = -26.0f;

  public const string MYSTICFOREST_Event_41_C = "Event";
  public const string MYSTICFOREST_Event_41_O = "41";
  public const float MYSTICFOREST_Event_41_X = 26.0f;
  public const float MYSTICFOREST_Event_41_Y = 0.0f;
  public const float MYSTICFOREST_Event_41_Z = -26.0f;

  public const string MYSTICFOREST_Event_42_C = "Event";
  public const string MYSTICFOREST_Event_42_O = "42";
  public const float MYSTICFOREST_Event_42_X = 32.0f;
  public const float MYSTICFOREST_Event_42_Y = 0.0f;
  public const float MYSTICFOREST_Event_42_Z = -24.0f;

  public const string MYSTICFOREST_Event_43_C = "Event";
  public const string MYSTICFOREST_Event_43_O = "43";
  public const float MYSTICFOREST_Event_43_X = 34.0f;
  public const float MYSTICFOREST_Event_43_Y = 0.0f;
  public const float MYSTICFOREST_Event_43_Z = -24.0f;

  public const string MYSTICFOREST_Event_44_C = "Event";
  public const string MYSTICFOREST_Event_44_O = "44";
  public const float MYSTICFOREST_Event_44_X = 33.0f;
  public const float MYSTICFOREST_Event_44_Y = 0.0f;
  public const float MYSTICFOREST_Event_44_Z = -25.0f;

  public const string MYSTICFOREST_Event_45_C = "Event";
  public const string MYSTICFOREST_Event_45_O = "45";
  public const float MYSTICFOREST_Event_45_X = 33.0f;
  public const float MYSTICFOREST_Event_45_Y = 0.0f;
  public const float MYSTICFOREST_Event_45_Z = -27.0f;

  public const string MYSTICFOREST_Event_46_C = "Event";
  public const string MYSTICFOREST_Event_46_O = "46";
  public const float MYSTICFOREST_Event_46_X = 36.0f;
  public const float MYSTICFOREST_Event_46_Y = 0.0f;
  public const float MYSTICFOREST_Event_46_Z = -26.0f;

  public const string MYSTICFOREST_Event_47_C = "Event";
  public const string MYSTICFOREST_Event_47_O = "47";
  public const float MYSTICFOREST_Event_47_X = 35.0f;
  public const float MYSTICFOREST_Event_47_Y = 0.0f;
  public const float MYSTICFOREST_Event_47_Z = -28.0f;

  public const string MYSTICFOREST_Event_48_C = "Event";
  public const string MYSTICFOREST_Event_48_O = "48";
  public const float MYSTICFOREST_Event_48_X = 46.0f;
  public const float MYSTICFOREST_Event_48_Y = 0.0f;
  public const float MYSTICFOREST_Event_48_Z = -11.0f;

  public const string MYSTICFOREST_Event_49_C = "Event";
  public const string MYSTICFOREST_Event_49_O = "49";
  public const float MYSTICFOREST_Event_49_X = 45.0f;
  public const float MYSTICFOREST_Event_49_Y = 0.0f;
  public const float MYSTICFOREST_Event_49_Z = -17.0f;

  public const string MYSTICFOREST_Event_50_C = "Event";
  public const string MYSTICFOREST_Event_50_O = "50";
  public const float MYSTICFOREST_Event_50_X = 40.0f;
  public const float MYSTICFOREST_Event_50_Y = 0.0f;
  public const float MYSTICFOREST_Event_50_Z = -15.0f;

  public const string MYSTICFOREST_Event_51_C = "Event";
  public const string MYSTICFOREST_Event_51_O = "51";
  public const float MYSTICFOREST_Event_51_X = 41.0f;
  public const float MYSTICFOREST_Event_51_Y = 0.0f;
  public const float MYSTICFOREST_Event_51_Z = -9.0f;

  public const string MYSTICFOREST_Event_52_C = "Event";
  public const string MYSTICFOREST_Event_52_O = "52";
  public const float MYSTICFOREST_Event_52_X = 18.0f;
  public const float MYSTICFOREST_Event_52_Y = 0.0f;
  public const float MYSTICFOREST_Event_52_Z = -13.0f;

  public const string MYSTICFOREST_Event_53_C = "Event";
  public const string MYSTICFOREST_Event_53_O = "53";
  public const float MYSTICFOREST_Event_53_X = 42.0f;
  public const float MYSTICFOREST_Event_53_Y = 0.0f;
  public const float MYSTICFOREST_Event_53_Z = -26.0f;
  #endregion
  #region "BrushWood"
  public const string MYSTICFOREST_BRUSHWOOD_1_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_1_O = "1";
  public const float MYSTICFOREST_BRUSHWOOD_1_X = 11.0f;
  public const float MYSTICFOREST_BRUSHWOOD_1_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_1_Z = -9.0f;

  public const string MYSTICFOREST_BRUSHWOOD_2_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_2_O = "2";
  public const float MYSTICFOREST_BRUSHWOOD_2_X = 37.0f;
  public const float MYSTICFOREST_BRUSHWOOD_2_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_2_Z = -13.0f;

  public const string MYSTICFOREST_BRUSHWOOD_3_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_3_O = "3";
  public const float MYSTICFOREST_BRUSHWOOD_3_X = 18.0f;
  public const float MYSTICFOREST_BRUSHWOOD_3_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_3_Z = -26.0f;

  public const string MYSTICFOREST_BRUSHWOOD_4_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_4_O = "4";
  public const float MYSTICFOREST_BRUSHWOOD_4_X = 15.0f;
  public const float MYSTICFOREST_BRUSHWOOD_4_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_4_Z = -4.0f;

  public const string MYSTICFOREST_BRUSHWOOD_5_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_5_O = "5";
  public const float MYSTICFOREST_BRUSHWOOD_5_X = 6.0f;
  public const float MYSTICFOREST_BRUSHWOOD_5_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_5_Z = -26.0f;

  public const string MYSTICFOREST_BRUSHWOOD_6_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_6_O = "6";
  public const float MYSTICFOREST_BRUSHWOOD_6_X = 37.0f;
  public const float MYSTICFOREST_BRUSHWOOD_6_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_6_Z = -28.0f;

  public const string MYSTICFOREST_BRUSHWOOD_7_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_7_O = "7";
  public const float MYSTICFOREST_BRUSHWOOD_7_X = 48;
  public const float MYSTICFOREST_BRUSHWOOD_7_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_7_Z = -20.0f;

  public const string MYSTICFOREST_BRUSHWOOD_8_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_8_O = "8";
  public const float MYSTICFOREST_BRUSHWOOD_8_X = 48.0f;
  public const float MYSTICFOREST_BRUSHWOOD_8_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_8_Z = -16.0f;

  public const string MYSTICFOREST_BRUSHWOOD_9_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_9_O = "9";
  public const float MYSTICFOREST_BRUSHWOOD_9_X = 48.0f;
  public const float MYSTICFOREST_BRUSHWOOD_9_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_9_Z = -13.0f;

  public const string MYSTICFOREST_BRUSHWOOD_10_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_10_O = "10";
  public const float MYSTICFOREST_BRUSHWOOD_10_X = 45.0f;
  public const float MYSTICFOREST_BRUSHWOOD_10_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_10_Z = -13.0f;

  public const string MYSTICFOREST_BRUSHWOOD_11_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_11_O = "11";
  public const float MYSTICFOREST_BRUSHWOOD_11_X = 23.0f;
  public const float MYSTICFOREST_BRUSHWOOD_11_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_11_Z = -4.0f;

  public const string MYSTICFOREST_BRUSHWOOD_12_C = "BrushWood";
  public const string MYSTICFOREST_BRUSHWOOD_12_O = "12";
  public const float MYSTICFOREST_BRUSHWOOD_12_X = 21.0f;
  public const float MYSTICFOREST_BRUSHWOOD_12_Y = 1.0f;
  public const float MYSTICFOREST_BRUSHWOOD_12_Z = -13.0f;
  #endregion
  public const string MYSTICFOREST_STEPBACK_1_C = "StepBack";
  public const string MYSTICFOREST_STEPBACK_1_O = "1";
  public const float MYSTICFOREST_STEPBACK_1_X = 23.0f;
  public const float MYSTICFOREST_STEPBACK_1_Y = 0.0f;
  public const float MYSTICFOREST_STEPBACK_1_Z = -23.0f;

  #region "ObsidianPortal"
  // Odsidian Portal
  public const string MYSTICFOREST_ObsidianPortal_1_C = "ObsidianPortal";
  public const string MYSTICFOREST_ObsidianPortal_1_O = "1";
  public const float MYSTICFOREST_ObsidianPortal_1_X = 43.0f;
  public const float MYSTICFOREST_ObsidianPortal_1_Y = 1.0f;
  public const float MYSTICFOREST_ObsidianPortal_1_Z = -13.0f;
  #endregion

  #region "Boss"
  public const string MYSTICFOREST_Boss_1_C = "Boss";
  public const string MYSTICFOREST_Boss_1_O = "1";
  public const float MYSTICFOREST_Boss_1_X = 44.0f;
  public const float MYSTICFOREST_Boss_1_Y = 0.0f;
  public const float MYSTICFOREST_Boss_1_Z = -26.0f;
  #endregion

  #region "階段"
  public const string MYSTICFOREST_UPSTAIR_1_C = "Upstair";
  public const string MYSTICFOREST_UPSTAIR_1_O = "1";
  public const float MYSTICFOREST_UPSTAIR_1_X = 0.0f;
  public const float MYSTICFOREST_UPSTAIR_1_Y = 0.0f;
  public const float MYSTICFOREST_UPSTAIR_1_Z = -9.0f;

  public const string MYSTICFOREST_UPSTAIR_2_C = "Upstair";
  public const string MYSTICFOREST_UPSTAIR_2_O = "2";
  public const float MYSTICFOREST_UPSTAIR_2_X = 49.0f;
  public const float MYSTICFOREST_UPSTAIR_2_Y = 0.0f;
  public const float MYSTICFOREST_UPSTAIR_2_Z = -26.0f;
  #endregion
  #endregion
  #region "アーサリウム工場跡地 ( not used )"
  // センター区画左側通路先、崖落ち
  public const string MAPEVENT_ARTHARIUM_1_C = "MapEvent";
  public const float MAPEVENT_ARTHARIUM_1_X = 28;
  public const float MAPEVENT_ARTHARIUM_1_Y = -4;
  public const float MAPEVENT_ARTHARIUM_1_Z = 48;

  // 崖落ちマップから通常通路へと帰還
  public const string MAPEVENT_ARTHARIUM_2_C = "MapEvent";
  public const float MAPEVENT_ARTHARIUM_2_X = 8;
  public const float MAPEVENT_ARTHARIUM_2_Y = -1;
  public const float MAPEVENT_ARTHARIUM_2_Z = 49;

  // 通常通路に戻り、ラナと合流
  public const string MAPEVENT_ARTHARIUM_3_C = "MapEvent";
  public const string MAPEVENT_ARTHARIUM_3_O = "MAPEVENT_ARTHARIUM_3";
  public const float MAPEVENT_ARTHARIUM_3_X = 27;
  public const float MAPEVENT_ARTHARIUM_3_Y = -4;
  public const float MAPEVENT_ARTHARIUM_3_Z = 48;

  // 右下、入口看板後の扉
  public const string MAPEVENT_ARTHARIUM_4_0_O = "MAPEVENT_ARTHARIUM_4_0";
  public const float MAPEVENT_ARTHARIUM_4_0_X = 38;
  public const float MAPEVENT_ARTHARIUM_4_0_Y = -1;
  public const float MAPEVENT_ARTHARIUM_4_0_Z = 18;

  // 右下、強敵モンスター入口
  public const string MAPEVENT_ARTHARIUM_4_O = "MAPEVENT_ARTHARIUM_4";

  public const string MAPEVENT_ARTHARIUM_5_O = "MAPEVENT_ARTHARIUM_5";
  public const float MAPEVENT_ARTHARIUM_5_X = 77;
  public const float MAPEVENT_ARTHARIUM_5_Y = -1;
  public const float MAPEVENT_ARTHARIUM_5_Z = 16;

  public const string MAPEVENT_ARTHARIUM_6_O = "MAPEVENT_ARTHARIUM_6";
  public const float MAPEVENT_ARTHARIUM_6_X = -34;
  public const float MAPEVENT_ARTHARIUM_6_Y = 2.5f;
  public const float MAPEVENT_ARTHARIUM_6_Z = 12;

  public const string MAPEVENT_ARTHARIUM_6_2_O = "MAPEVENT_ARTHARIUM_6_2";
  public const float MAPEVENT_ARTHARIUM_6_2_X = -35;
  public const float MAPEVENT_ARTHARIUM_6_2_Y = 2.5f;
  public const float MAPEVENT_ARTHARIUM_6_2_Z = 12;

  public const string MAPEVENT_ARTHARIUM_7_O = "MAPEVENT_ARTHARIUM_7";
  public const float MAPEVENT_ARTHARIUM_7_X = 15;
  public const float MAPEVENT_ARTHARIUM_7_Y = -1.5f;
  public const float MAPEVENT_ARTHARIUM_7_Z = 35;

  public const string MAPEVENT_ARTHARIUM_8_O = "MAPEVENT_ARTHARIUM_8";
  public const float MAPEVENT_ARTHARIUM_8_X = 15;
  public const float MAPEVENT_ARTHARIUM_8_Y = -1.5f;
  public const float MAPEVENT_ARTHARIUM_8_Z = 35;

  public const string MAPEVENT_ARTHARIUM_9_O = "MAPEVENT_ARTHARIUM_9";

  public const string MAPEVENT_ARTHARIUM_10_O = "MAPEVENT_ARTHARIUM_10";
  public const float MAPEVENT_ARTHARIUM_10_1_X = -32;
  public const float MAPEVENT_ARTHARIUM_10_1_Y = 0;
  public const float MAPEVENT_ARTHARIUM_10_1_Z = 48;

  public const float MAPEVENT_ARTHARIUM_10_2_X = -31;
  public const float MAPEVENT_ARTHARIUM_10_2_Y = 0;
  public const float MAPEVENT_ARTHARIUM_10_2_Z = 48;

  public const float MAPEVENT_ARTHARIUM_10_3_X = -30;
  public const float MAPEVENT_ARTHARIUM_10_3_Y = 0;
  public const float MAPEVENT_ARTHARIUM_10_3_Z = 48;

  public const string MAPEVENT_ARTHARIUM_11_O = "MAPEVENT_ARTHARIUM_11";

  // 山道ルート入口
  public const string MAPEVENT_ARTHARIUM_12_O = "MAPEVENT_ARTHARIUM_12";
  public const float MAPEVENT_ARTHARIUM_12_X = 56;
  public const float MAPEVENT_ARTHARIUM_12_Y = 0;
  public const float MAPEVENT_ARTHARIUM_12_Z = 2;

  // 山道ルート、ツァルマンの里入口
  public const string EVENT_BASEFIELD_10_O = "EVENT_BASEFIELD_10_O";
  public const float EVENT_BASEFIELD_10_X = 52;
  public const float EVENT_BASEFIELD_10_Y = 6.5f;
  public const float EVENT_BASEFIELD_10_Z = 38;

  public const string ARTHARIUM_Treasure_3_C = "Treasure";
  public const string ARTHARIUM_Treasure_3_O = "3";
  public const float ARTHARIUM_Treasure_3_X = 35f;
  public const float ARTHARIUM_Treasure_3_Y = 0f;
  public const float ARTHARIUM_Treasure_3_Z = 17f;

  public const string ARTHARIUM_Treasure_2_C = "Treasure";
  public const string ARTHARIUM_Treasure_2_O = "2";
  public const float ARTHARIUM_Treasure_2_X = 26f;
  public const float ARTHARIUM_Treasure_2_Y = 0f;
  public const float ARTHARIUM_Treasure_2_Z = 18f;

  public const string ARTHARIUM_Treasure_1_C = "Treasure";
  public const string ARTHARIUM_Treasure_1_O = "1";
  public const float ARTHARIUM_Treasure_1_X = 19f;
  public const float ARTHARIUM_Treasure_1_Y = -0.5f;
  public const float ARTHARIUM_Treasure_1_Z = 37f;

  public const string ARTHARIUM_Treasure_6_C = "Treasure";
  public const string ARTHARIUM_Treasure_6_O = "6";
  public const float ARTHARIUM_Treasure_6_X = -15f;
  public const float ARTHARIUM_Treasure_6_Y = 1f;
  public const float ARTHARIUM_Treasure_6_Z = 33f;

  public const string ARTHARIUM_Treasure_5_C = "Treasure";
  public const string ARTHARIUM_Treasure_5_O = "5";
  public const float ARTHARIUM_Treasure_5_X = -12f;
  public const float ARTHARIUM_Treasure_5_Y = 1f;
  public const float ARTHARIUM_Treasure_5_Z = 50f;

  public const string ARTHARIUM_Treasure_7_C = "Treasure";
  public const string ARTHARIUM_Treasure_7_O = "7";
  public const float ARTHARIUM_Treasure_7_X = -42f;
  public const float ARTHARIUM_Treasure_7_Y = 5f;
  public const float ARTHARIUM_Treasure_7_Z = 39f;

  public const string ARTHARIUM_Treasure_4_C = "Treasure";
  public const string ARTHARIUM_Treasure_4_O = "4";
  public const float ARTHARIUM_Treasure_4_X = 80f;
  public const float ARTHARIUM_Treasure_4_Y = -4f;
  public const float ARTHARIUM_Treasure_4_Z = 25f;

  public const string ARTHARIUM_Rock_4_C = "Rock";
  public const string ARTHARIUM_Rock_4_O = "4";
  public const float ARTHARIUM_Rock_4_X = 26f;
  public const float ARTHARIUM_Rock_4_Y = -0.5f;
  public const float ARTHARIUM_Rock_4_Z = 30f;

  public const string ARTHARIUM_Rock_5_C = "Rock";
  public const string ARTHARIUM_Rock_5_O = "5";
  public const float ARTHARIUM_Rock_5_X = 13f;
  public const float ARTHARIUM_Rock_5_Y = -0.5f;
  public const float ARTHARIUM_Rock_5_Z = 30f;

  public const string ARTHARIUM_Rock_3_C = "Rock";
  public const string ARTHARIUM_Rock_3_O = "3";
  public const float ARTHARIUM_Rock_3_X = 22f;
  public const float ARTHARIUM_Rock_3_Y = -0.5f;
  public const float ARTHARIUM_Rock_3_Z = 19f;

  public const string ARTHARIUM_Rock_2_C = "Rock";
  public const string ARTHARIUM_Rock_2_O = "2";
  public const float ARTHARIUM_Rock_2_X = 11f;
  public const float ARTHARIUM_Rock_2_Y = 1f;
  public const float ARTHARIUM_Rock_2_Z = 9f;

  public const string ARTHARIUM_Rock_1_C = "Rock";
  public const string ARTHARIUM_Rock_1_O = "1";
  public const float ARTHARIUM_Rock_1_X = -5f;
  public const float ARTHARIUM_Rock_1_Y = 1f;
  public const float ARTHARIUM_Rock_1_Z = 19f;

  public const string ARTHARIUM_Treasure_8_C = "Treasure";
  public const string ARTHARIUM_Treasure_8_O = "8";
  public const float ARTHARIUM_Treasure_8_X = 28f;
  public const float ARTHARIUM_Treasure_8_Y = -6.5f;
  public const float ARTHARIUM_Treasure_8_Z = 42f;

  public const string ARTHARIUM_Treasure_9_C = "Treasure";
  public const string ARTHARIUM_Treasure_9_O = "9";
  public const float ARTHARIUM_Treasure_9_X = 34f;
  public const float ARTHARIUM_Treasure_9_Y = -6f;
  public const float ARTHARIUM_Treasure_9_Z = 43f;

  public const string ARTHARIUM_Treasure_10_C = "Treasure";
  public const string ARTHARIUM_Treasure_10_O = "10";
  public const float ARTHARIUM_Treasure_10_X = 55f;
  public const float ARTHARIUM_Treasure_10_Y = -5f;
  public const float ARTHARIUM_Treasure_10_Z = 60f;

  public const string ARTHARIUM_Treasure_11_C = "Treasure";
  public const string ARTHARIUM_Treasure_11_O = "11";
  public const float ARTHARIUM_Treasure_11_X = 63f;
  public const float ARTHARIUM_Treasure_11_Y = -4f;
  public const float ARTHARIUM_Treasure_11_Z = 49f;

  public const string ARTHARIUM_Treasure_12_C = "Treasure";
  public const string ARTHARIUM_Treasure_12_O = "12";
  public const float ARTHARIUM_Treasure_12_X = 38f;
  public const float ARTHARIUM_Treasure_12_Y = -4.5f;
  public const float ARTHARIUM_Treasure_12_Z = 64f;

  public const string ARTHARIUM_Treasure_13_C = "Treasure";
  public const string ARTHARIUM_Treasure_13_O = "13";
  public const float ARTHARIUM_Treasure_13_X = 48f;
  public const float ARTHARIUM_Treasure_13_Y = -4.5f;
  public const float ARTHARIUM_Treasure_13_Z = 74f;

  public const string ARTHARIUM_Treasure_14_C = "Treasure";
  public const string ARTHARIUM_Treasure_14_O = "14";
  public const float ARTHARIUM_Treasure_14_X = 15f;
  public const float ARTHARIUM_Treasure_14_Y = -0.5f;
  public const float ARTHARIUM_Treasure_14_Z = 74f;

  public const string ARTHARIUM_Fountain_1_C = "Fountain";
  public const string ARTHARIUM_Fountain_1_O = "1";
  public const float ARTHARIUM_Fountain_1_X = 33f;
  public const float ARTHARIUM_Fountain_1_Y = -0.5f;
  public const float ARTHARIUM_Fountain_1_Z = 30f;

  public const string ARTHARIUM_MessageBoard_1_C = "MessageBoard";
  public const string ARTHARIUM_MessageBoard_1_O = "1";
  public const float ARTHARIUM_MessageBoard_1_X = 37f;
  public const float ARTHARIUM_MessageBoard_1_Y = -1f;
  public const float ARTHARIUM_MessageBoard_1_Z = 21f;

  public const string ARTHARIUM_Door_Copper_1_C = "Door_Copper";
  public const string ARTHARIUM_Door_Copper_1_O = "1";
  public const float ARTHARIUM_Door_Copper_1_X = 38f;
  public const float ARTHARIUM_Door_Copper_1_Y = -1f;
  public const float ARTHARIUM_Door_Copper_1_Z = 18f;

  public const string ARTHARIUM_Treasure_15_C = "Treasure";
  public const string ARTHARIUM_Treasure_15_O = "15";
  public const float ARTHARIUM_Treasure_15_X = 40f;
  public const float ARTHARIUM_Treasure_15_Y = -1f;
  public const float ARTHARIUM_Treasure_15_Z = 9f;

  public const string ARTHARIUM_Treasure_16_C = "Treasure";
  public const string ARTHARIUM_Treasure_16_O = "16";
  public const float ARTHARIUM_Treasure_16_X = 49f;
  public const float ARTHARIUM_Treasure_16_Y = -1f;
  public const float ARTHARIUM_Treasure_16_Z = 5f;

  public const string ARTHARIUM_Treasure_17_C = "Treasure";
  public const string ARTHARIUM_Treasure_17_O = "17";
  public const float ARTHARIUM_Treasure_17_X = 60f;
  public const float ARTHARIUM_Treasure_17_Y = -1f;
  public const float ARTHARIUM_Treasure_17_Z = 16f;

  public const string ARTHARIUM_Treasure_18_C = "Treasure";
  public const string ARTHARIUM_Treasure_18_O = "18";
  public const float ARTHARIUM_Treasure_18_X = 55f;
  public const float ARTHARIUM_Treasure_18_Y = -1f;
  public const float ARTHARIUM_Treasure_18_Z = 11f;

  public const string ARTHARIUM_Fountain_2_C = "Fountain";
  public const string ARTHARIUM_Fountain_2_O = "2";
  public const float ARTHARIUM_Fountain_2_X = 66f;
  public const float ARTHARIUM_Fountain_2_Y = -1f;
  public const float ARTHARIUM_Fountain_2_Z = 18f;

  public const string ARTHARIUM_Treasure_19_C = "Treasure";
  public const string ARTHARIUM_Treasure_19_O = "19";
  public const float ARTHARIUM_Treasure_19_X = 78f;
  public const float ARTHARIUM_Treasure_19_Y = -1f;
  public const float ARTHARIUM_Treasure_19_Z = 19f;

  public const string ARTHARIUM_Door_Copper_2_C = "Door_Copper";
  public const string ARTHARIUM_Door_Copper_2_O = "2";
  public const float ARTHARIUM_Door_Copper_2_X = 77f;
  public const float ARTHARIUM_Door_Copper_2_Y = -1f;
  public const float ARTHARIUM_Door_Copper_2_Z = 16f;

  public const string ARTHARIUM_Crystal_1_C = "Crystal";
  public const string ARTHARIUM_Crystal_1_O = "1";
  public const float ARTHARIUM_Crystal_1_X = 76f;
  public const float ARTHARIUM_Crystal_1_Y = -3.5f;
  public const float ARTHARIUM_Crystal_1_Z = 14f;

  public const string ARTHARIUM_Treasure_20_C = "Treasure";
  public const string ARTHARIUM_Treasure_20_O = "20";
  public const float ARTHARIUM_Treasure_20_X = -25f;
  public const float ARTHARIUM_Treasure_20_Y = 2f;
  public const float ARTHARIUM_Treasure_20_Z = 11f;

  public const string ARTHARIUM_Treasure_21_C = "Treasure";
  public const string ARTHARIUM_Treasure_21_O = "21";
  public const float ARTHARIUM_Treasure_21_X = -45f;
  public const float ARTHARIUM_Treasure_21_Y = 4.5f;
  public const float ARTHARIUM_Treasure_21_Z = 31f;

  public const string ARTHARIUM_Treasure_22_C = "Treasure";
  public const string ARTHARIUM_Treasure_22_O = "22";
  public const float ARTHARIUM_Treasure_22_X = -58f;
  public const float ARTHARIUM_Treasure_22_Y = 4.5f;
  public const float ARTHARIUM_Treasure_22_Z = 25f;

  public const string ARTHARIUM_Treasure_23_C = "Treasure";
  public const string ARTHARIUM_Treasure_23_O = "23";
  public const float ARTHARIUM_Treasure_23_X = -62f;
  public const float ARTHARIUM_Treasure_23_Y = 4.5f;
  public const float ARTHARIUM_Treasure_23_Z = 10f;

  public const string ARTHARIUM_Treasure_24_C = "Treasure";
  public const string ARTHARIUM_Treasure_24_O = "24";
  public const float ARTHARIUM_Treasure_24_X = -32f;
  public const float ARTHARIUM_Treasure_24_Y = 3.5f;
  public const float ARTHARIUM_Treasure_24_Z = 17f;

  public const string ARTHARIUM_Treasure_25_C = "Treasure";
  public const string ARTHARIUM_Treasure_25_O = "25";
  public const float ARTHARIUM_Treasure_25_X = -11f;
  public const float ARTHARIUM_Treasure_25_Y = 2.5f;
  public const float ARTHARIUM_Treasure_25_Z = 12f;

  public const string ARTHARIUM_Fountain_3_C = "Fountain";
  public const string ARTHARIUM_Fountain_3_O = "3";
  public const float ARTHARIUM_Fountain_3_X = -20f;
  public const float ARTHARIUM_Fountain_3_Y = 1.5f;
  public const float ARTHARIUM_Fountain_3_Z = 10f;

  public const string ARTHARIUM_Fountain_4_C = "Fountain";
  public const string ARTHARIUM_Fountain_4_O = "4";
  public const float ARTHARIUM_Fountain_4_X = -53f;
  public const float ARTHARIUM_Fountain_4_Y = 4.5f;
  public const float ARTHARIUM_Fountain_4_Z = 15f;

  public const string ARTHARIUM_Treasure_26_C = "Treasure";
  public const string ARTHARIUM_Treasure_26_O = "26";
  public const float ARTHARIUM_Treasure_26_X = -64f;
  public const float ARTHARIUM_Treasure_26_Y = 4.5f;
  public const float ARTHARIUM_Treasure_26_Z = 1f;

  public const string ARTHARIUM_Treasure_27_C = "Treasure";
  public const string ARTHARIUM_Treasure_27_O = "27";
  public const float ARTHARIUM_Treasure_27_X = -71f;
  public const float ARTHARIUM_Treasure_27_Y = -2f;
  public const float ARTHARIUM_Treasure_27_Z = 12f;

  public const string ARTHARIUM_Fountain_5_C = "Fountain";
  public const string ARTHARIUM_Fountain_5_O = "5";
  public const float ARTHARIUM_Fountain_5_X = -67f;
  public const float ARTHARIUM_Fountain_5_Y = -2f;
  public const float ARTHARIUM_Fountain_5_Z = 12f;

  public const string ARTHARIUM_Crystal_2_C = "Crystal";
  public const string ARTHARIUM_Crystal_2_O = "2";
  public const float ARTHARIUM_Crystal_2_X = -69f;
  public const float ARTHARIUM_Crystal_2_Y = -4f;
  public const float ARTHARIUM_Crystal_2_Z = 24f;

  public const string ARTHARIUM_Door_Copper_3_C = "Door_Copper";
  public const string ARTHARIUM_Door_Copper_3_O = "3";
  public const float ARTHARIUM_Door_Copper_3_X = -11f;
  public const float ARTHARIUM_Door_Copper_3_Y = 2.5f;
  public const float ARTHARIUM_Door_Copper_3_Z = 9f;

  public const string ARTHARIUM_Rock_6_C = "Rock";
  public const string ARTHARIUM_Rock_6_O = "6";
  public const float ARTHARIUM_Rock_6_X = -11f;
  public const float ARTHARIUM_Rock_6_Y = 2.5f;
  public const float ARTHARIUM_Rock_6_Z = 11f;

  public const string ARTHARIUM_Door_Copper_4_C = "Door_Copper";
  public const string ARTHARIUM_Door_Copper_4_O = "4";
  public const float ARTHARIUM_Door_Copper_4_X = -1f;
  public const float ARTHARIUM_Door_Copper_4_Y = 1f;
  public const float ARTHARIUM_Door_Copper_4_Z = 33f;

  public const string ARTHARIUM_Door_Copper_5_C = "Door_Copper";
  public const string ARTHARIUM_Door_Copper_5_O = "5";
  public const float ARTHARIUM_Door_Copper_5_X = 0f;
  public const float ARTHARIUM_Door_Copper_5_Y = 1f;
  public const float ARTHARIUM_Door_Copper_5_Z = 33f;

  public const string ARTHARIUM_Fountain_6_C = "Fountain";
  public const string ARTHARIUM_Fountain_6_O = "6";
  public const float ARTHARIUM_Fountain_6_X = -31f;
  public const float ARTHARIUM_Fountain_6_Y = 1f;
  public const float ARTHARIUM_Fountain_6_Z = 44f;

  public const string ARTHARIUM_ObsidianStone_1_C = "ObsidianStone";
  public const string ARTHARIUM_ObsidianStone_1_O = "1";
  public const float ARTHARIUM_ObsidianStone_1_X = -31f;
  public const float ARTHARIUM_ObsidianStone_1_Y = 3.5f;
  public const float ARTHARIUM_ObsidianStone_1_Z = 66f;
  #endregion
  #region "オーランの塔 ( not used )"
  //// オーランの塔、一層、右側（下）
  //public const string EVENT_OHRANTOWER_1_O = "EVENT_OHRANTOWER_1_O";
  //public const float EVENT_OHRANTOWER_1_X = 10;
  //public const float EVENT_OHRANTOWER_1_Y = 0;
  //public const float EVENT_OHRANTOWER_1_Z = 1;

  //// オーランの塔、二層、右側（上）
  //public const string EVENT_OHRANTOWER_2_O = "EVENT_OHRANTOWER_2_O";
  //public const float EVENT_OHRANTOWER_2_X = 10;
  //public const float EVENT_OHRANTOWER_2_Y = 8;
  //public const float EVENT_OHRANTOWER_2_Z = 1;

  //// オーランの塔、一層、左側（下）
  //public const string EVENT_OHRANTOWER_3_O = "EVENT_OHRANTOWER_3_O";
  //public const float EVENT_OHRANTOWER_3_X = -16;
  //public const float EVENT_OHRANTOWER_3_Y = 0;
  //public const float EVENT_OHRANTOWER_3_Z = 1;

  //// オーランの塔、一層、左側（上）
  //public const string EVENT_OHRANTOWER_4_O = "EVENT_OHRANTOWER_4_O";
  //public const float EVENT_OHRANTOWER_4_X = -16;
  //public const float EVENT_OHRANTOWER_4_Y = 12;
  //public const float EVENT_OHRANTOWER_4_Z = 1;

  //// オーランの塔、二層、中央左岸（入口）
  //public const string EVENT_OHRANTOWER_4_O = "EVENT_OHRANTOWER_4_O";
  //public const float EVENT_OHRANTOWER_4_X = -16;
  //public const float EVENT_OHRANTOWER_4_Y = 12;
  //public const float EVENT_OHRANTOWER_4_Z = 1;

  // オーランの塔、ボス前の察知
  public const float EVENT_OHRANTOWER_9_X = 5.0f;
  public const float EVENT_OHRANTOWER_9_Y = 55.5f;
  public const float EVENT_OHRANTOWER_9_Z = 27.0f;

  // オーランの塔、ボス戦
  public const float EVENT_OHRANTOWER_10_X = 1.0f;
  public const float EVENT_OHRANTOWER_10_Y = 64.0f;
  public const float EVENT_OHRANTOWER_10_Z = 25.0f;

  // オーランの塔、展望台箇所
  public const float EVENT_OHRANTOWER_11_X = 1.0f;
  public const float EVENT_OHRANTOWER_11_Y = 65.0f;
  public const float EVENT_OHRANTOWER_11_Z = 32.0f;

  public const string OHRANTOWER_Treasure_1_C = "Treasure";
  public const string OHRANTOWER_Treasure_1_O = "1";
  public const float OHRANTOWER_Treasure_1_X = 17f;
  public const float OHRANTOWER_Treasure_1_Y = 9f;
  public const float OHRANTOWER_Treasure_1_Z = 7f;

  public const string OHRANTOWER_Treasure_2_C = "Treasure";
  public const string OHRANTOWER_Treasure_2_O = "2";
  public const float OHRANTOWER_Treasure_2_X = -13f;
  public const float OHRANTOWER_Treasure_2_Y = 9f;
  public const float OHRANTOWER_Treasure_2_Z = 25f;

  public const string OHRANTOWER_FloatingTile_1_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_1_O = "1";
  public const float OHRANTOWER_FloatingTile_1_X = 10f;
  public const float OHRANTOWER_FloatingTile_1_Y = 0f;
  public const float OHRANTOWER_FloatingTile_1_Z = 1f;

  public const string OHRANTOWER_FloatingTile_2_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_2_O = "2";
  public const float OHRANTOWER_FloatingTile_2_X = -16f;
  public const float OHRANTOWER_FloatingTile_2_Y = 0f;
  public const float OHRANTOWER_FloatingTile_2_Z = 1f;

  public const string OHRANTOWER_FloatingTile_3_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_3_O = "3";
  public const float OHRANTOWER_FloatingTile_3_X = -16f;
  public const float OHRANTOWER_FloatingTile_3_Y = 12f;
  public const float OHRANTOWER_FloatingTile_3_Z = 23f;

  public const string OHRANTOWER_FloatingTile_4_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_4_O = "4";
  public const float OHRANTOWER_FloatingTile_4_X = -5f;
  public const float OHRANTOWER_FloatingTile_4_Y = 8f;
  public const float OHRANTOWER_FloatingTile_4_Z = 13f;

  public const string OHRANTOWER_FloatingTile_5_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_5_O = "5";
  public const float OHRANTOWER_FloatingTile_5_X = 5f;
  public const float OHRANTOWER_FloatingTile_5_Y = 8f;
  public const float OHRANTOWER_FloatingTile_5_Z = 13f;

  public const string OHRANTOWER_FloatingTile_6_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_6_O = "6";
  public const float OHRANTOWER_FloatingTile_6_X = 16f;
  public const float OHRANTOWER_FloatingTile_6_Y = 8f;
  public const float OHRANTOWER_FloatingTile_6_Z = 24f;

  public const string OHRANTOWER_Treasure_4_C = "Treasure";
  public const string OHRANTOWER_Treasure_4_O = "4";
  public const float OHRANTOWER_Treasure_4_X = 27f;
  public const float OHRANTOWER_Treasure_4_Y = 9f;
  public const float OHRANTOWER_Treasure_4_Z = 25f;

  public const string OHRANTOWER_FloatingTile_7_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_7_O = "7";
  public const float OHRANTOWER_FloatingTile_7_X = 13f;
  public const float OHRANTOWER_FloatingTile_7_Y = 8f;
  public const float OHRANTOWER_FloatingTile_7_Z = 22f;

  public const string OHRANTOWER_FloatingTile_8_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_8_O = "8";
  public const float OHRANTOWER_FloatingTile_8_X = 3f;
  public const float OHRANTOWER_FloatingTile_8_Y = 8f;
  public const float OHRANTOWER_FloatingTile_8_Z = 25f;

  public const string OHRANTOWER_FloatingTile_9_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_9_O = "9";
  public const float OHRANTOWER_FloatingTile_9_X = -10f;
  public const float OHRANTOWER_FloatingTile_9_Y = 8f;
  public const float OHRANTOWER_FloatingTile_9_Z = 23f;

  public const string OHRANTOWER_FloatingTile_10_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_10_O = "10";
  public const float OHRANTOWER_FloatingTile_10_X = 14f;
  public const float OHRANTOWER_FloatingTile_10_Y = 8f;
  public const float OHRANTOWER_FloatingTile_10_Z = 7f;

  public const string OHRANTOWER_FloatingTile_11_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_11_O = "11";
  public const float OHRANTOWER_FloatingTile_11_X = 20f;
  public const float OHRANTOWER_FloatingTile_11_Y = 8f;
  public const float OHRANTOWER_FloatingTile_11_Z = 17f;

  public const string OHRANTOWER_ObsidianStone_2_C = "ObsidianStone";
  public const string OHRANTOWER_ObsidianStone_2_O = "2";
  public const float OHRANTOWER_ObsidianStone_2_X = -29f;
  public const float OHRANTOWER_ObsidianStone_2_Y = 9f;
  public const float OHRANTOWER_ObsidianStone_2_Z = 17f;

  public const string OHRANTOWER_Treasure_3_C = "Treasure";
  public const string OHRANTOWER_Treasure_3_O = "3";
  public const float OHRANTOWER_Treasure_3_X = -21f;
  public const float OHRANTOWER_Treasure_3_Y = 11f;
  public const float OHRANTOWER_Treasure_3_Z = 18f;

  public const string OHRANTOWER_WarpHole_1_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_1_O = "1";
  public const float OHRANTOWER_WarpHole_1_X = -8f;
  public const float OHRANTOWER_WarpHole_1_Y = 20f;
  public const float OHRANTOWER_WarpHole_1_Z = 23f;

  public const string OHRANTOWER_WarpHole_2_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_2_O = "2";
  public const float OHRANTOWER_WarpHole_2_X = 5f;
  public const float OHRANTOWER_WarpHole_2_Y = 12f;
  public const float OHRANTOWER_WarpHole_2_Z = 23f;

  public const string OHRANTOWER_WarpHole_3_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_3_O = "3";
  public const float OHRANTOWER_WarpHole_3_X = -6f;
  public const float OHRANTOWER_WarpHole_3_Y = 12f;
  public const float OHRANTOWER_WarpHole_3_Z = 23f;

  public const string OHRANTOWER_WarpHole_4_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_4_O = "4";
  public const float OHRANTOWER_WarpHole_4_X = 7f;
  public const float OHRANTOWER_WarpHole_4_Y = 20f;
  public const float OHRANTOWER_WarpHole_4_Z = 23f;

  public const string OHRANTOWER_FloatingTile_12_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_12_O = "12";
  public const float OHRANTOWER_FloatingTile_12_X = 17f;
  public const float OHRANTOWER_FloatingTile_12_Y = 20f;
  public const float OHRANTOWER_FloatingTile_12_Z = 12f;

  public const string OHRANTOWER_WarpHole_5_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_5_O = "5";
  public const float OHRANTOWER_WarpHole_5_X = -16f;
  public const float OHRANTOWER_WarpHole_5_Y = 28f;
  public const float OHRANTOWER_WarpHole_5_Z = 12f;

  public const string OHRANTOWER_WarpHole_6_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_6_O = "6";
  public const float OHRANTOWER_WarpHole_6_X = 17f;
  public const float OHRANTOWER_WarpHole_6_Y = 28f;
  public const float OHRANTOWER_WarpHole_6_Z = 2f;

  public const string OHRANTOWER_Treasure_5_C = "Treasure";
  public const string OHRANTOWER_Treasure_5_O = "5";
  public const float OHRANTOWER_Treasure_5_X = 2f;
  public const float OHRANTOWER_Treasure_5_Y = 29f;
  public const float OHRANTOWER_Treasure_5_Z = 8f;

  public const string OHRANTOWER_Treasure_6_C = "Treasure";
  public const string OHRANTOWER_Treasure_6_O = "6";
  public const float OHRANTOWER_Treasure_6_X = -2f;
  public const float OHRANTOWER_Treasure_6_Y = 29f;
  public const float OHRANTOWER_Treasure_6_Z = 8f;

  public const string OHRANTOWER_FloatingTile_13_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_13_O = "13";
  public const float OHRANTOWER_FloatingTile_13_X = -10f;
  public const float OHRANTOWER_FloatingTile_13_Y = 28f;
  public const float OHRANTOWER_FloatingTile_13_Z = 21f;

  public const string OHRANTOWER_FloatingTile_14_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_14_O = "14";
  public const float OHRANTOWER_FloatingTile_14_X = 2f;
  public const float OHRANTOWER_FloatingTile_14_Y = 36f;
  public const float OHRANTOWER_FloatingTile_14_Z = 31f;

  public const string OHRANTOWER_FloatingTile_15_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_15_O = "15";
  public const float OHRANTOWER_FloatingTile_15_X = 10f;
  public const float OHRANTOWER_FloatingTile_15_Y = 36f;
  public const float OHRANTOWER_FloatingTile_15_Z = 30f;

  public const string OHRANTOWER_FloatingTile_16_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_16_O = "16";
  public const float OHRANTOWER_FloatingTile_16_X = 10f;
  public const float OHRANTOWER_FloatingTile_16_Y = 36f;
  public const float OHRANTOWER_FloatingTile_16_Z = 19f;

  public const string OHRANTOWER_FloatingTile_17_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_17_O = "17";
  public const float OHRANTOWER_FloatingTile_17_X = 9f;
  public const float OHRANTOWER_FloatingTile_17_Y = 36f;
  public const float OHRANTOWER_FloatingTile_17_Z = 11f;

  public const string OHRANTOWER_FloatingTile_18_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_18_O = "18";
  public const float OHRANTOWER_FloatingTile_18_X = -2f;
  public const float OHRANTOWER_FloatingTile_18_Y = 36f;
  public const float OHRANTOWER_FloatingTile_18_Z = 11f;

  public const string OHRANTOWER_FloatingTile_19_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_19_O = "19";
  public const float OHRANTOWER_FloatingTile_19_X = -10f;
  public const float OHRANTOWER_FloatingTile_19_Y = 36f;
  public const float OHRANTOWER_FloatingTile_19_Z = 12f;

  public const string OHRANTOWER_FloatingTile_20_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_20_O = "20";
  public const float OHRANTOWER_FloatingTile_20_X = -9f;
  public const float OHRANTOWER_FloatingTile_20_Y = 36f;
  public const float OHRANTOWER_FloatingTile_20_Z = 18f;

  public const string OHRANTOWER_FloatingTile_21_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_21_O = "21";
  public const float OHRANTOWER_FloatingTile_21_X = -2f;
  public const float OHRANTOWER_FloatingTile_21_Y = 36f;
  public const float OHRANTOWER_FloatingTile_21_Z = 17f;

  public const string OHRANTOWER_FloatingTile_22_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_22_O = "22";
  public const float OHRANTOWER_FloatingTile_22_X = 4f;
  public const float OHRANTOWER_FloatingTile_22_Y = 36f;
  public const float OHRANTOWER_FloatingTile_22_Z = 18f;

  public const string OHRANTOWER_FloatingTile_23_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_23_O = "23";
  public const float OHRANTOWER_FloatingTile_23_X = 3f;
  public const float OHRANTOWER_FloatingTile_23_Y = 36f;
  public const float OHRANTOWER_FloatingTile_23_Z = 35f;

  public const string OHRANTOWER_FloatingTile_24_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_24_O = "24";
  public const float OHRANTOWER_FloatingTile_24_X = -4f;
  public const float OHRANTOWER_FloatingTile_24_Y = 36f;
  public const float OHRANTOWER_FloatingTile_24_Z = 34f;

  public const string OHRANTOWER_FloatingTile_25_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_25_O = "25";
  public const float OHRANTOWER_FloatingTile_25_X = -5f;
  public const float OHRANTOWER_FloatingTile_25_Y = 36f;
  public const float OHRANTOWER_FloatingTile_25_Z = 31f;

  public const string OHRANTOWER_FloatingTile_26_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_26_O = "26";
  public const float OHRANTOWER_FloatingTile_26_X = -10f;
  public const float OHRANTOWER_FloatingTile_26_Y = 36f;
  public const float OHRANTOWER_FloatingTile_26_Z = 30f;

  public const string OHRANTOWER_FloatingTile_27_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_27_O = "27";
  public const float OHRANTOWER_FloatingTile_27_X = -9f;
  public const float OHRANTOWER_FloatingTile_27_Y = 36f;
  public const float OHRANTOWER_FloatingTile_27_Z = 25f;

  public const string OHRANTOWER_FloatingTile_28_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_28_O = "28";
  public const float OHRANTOWER_FloatingTile_28_X = -3f;
  public const float OHRANTOWER_FloatingTile_28_Y = 36f;
  public const float OHRANTOWER_FloatingTile_28_Z = 23f;

  public const string OHRANTOWER_FloatingTile_29_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_29_O = "29";
  public const float OHRANTOWER_FloatingTile_29_X = 10f;
  public const float OHRANTOWER_FloatingTile_29_Y = 36f;
  public const float OHRANTOWER_FloatingTile_29_Z = 21f;

  public const string OHRANTOWER_Treasure_7_C = "Treasure";
  public const string OHRANTOWER_Treasure_7_O = "7";
  public const float OHRANTOWER_Treasure_7_X = 2f;
  public const float OHRANTOWER_Treasure_7_Y = 29f;
  public const float OHRANTOWER_Treasure_7_Z = 22f;

  public const string OHRANTOWER_Treasure_8_C = "Treasure";
  public const string OHRANTOWER_Treasure_8_O = "8";
  public const float OHRANTOWER_Treasure_8_X = -2f;
  public const float OHRANTOWER_Treasure_8_Y = 29f;
  public const float OHRANTOWER_Treasure_8_Z = 22f;

  public const string OHRANTOWER_WarpHole_7_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_7_O = "7";
  public const float OHRANTOWER_WarpHole_7_X = 0f;
  public const float OHRANTOWER_WarpHole_7_Y = 36f;
  public const float OHRANTOWER_WarpHole_7_Z = 21f;

  public const string OHRANTOWER_WarpHole_8_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_8_O = "8";
  public const float OHRANTOWER_WarpHole_8_X = 0f;
  public const float OHRANTOWER_WarpHole_8_Y = 44f;
  public const float OHRANTOWER_WarpHole_8_Z = 18f;

  public const string OHRANTOWER_WarpHole_9_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_9_O = "9";
  public const float OHRANTOWER_WarpHole_9_X = 4f;
  public const float OHRANTOWER_WarpHole_9_Y = 44f;
  public const float OHRANTOWER_WarpHole_9_Z = 21f;

  public const string OHRANTOWER_WarpHole_10_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_10_O = "10";
  public const float OHRANTOWER_WarpHole_10_X = 7f;
  public const float OHRANTOWER_WarpHole_10_Y = 44f;
  public const float OHRANTOWER_WarpHole_10_Z = 18f;

  public const string OHRANTOWER_WarpHole_11_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_11_O = "11";
  public const float OHRANTOWER_WarpHole_11_X = 0f;
  public const float OHRANTOWER_WarpHole_11_Y = 44f;
  public const float OHRANTOWER_WarpHole_11_Z = 14f;

  public const string OHRANTOWER_WarpHole_12_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_12_O = "12";
  public const float OHRANTOWER_WarpHole_12_X = -7f;
  public const float OHRANTOWER_WarpHole_12_Y = 44f;
  public const float OHRANTOWER_WarpHole_12_Z = 18f;

  public const string OHRANTOWER_WarpHole_13_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_13_O = "13";
  public const float OHRANTOWER_WarpHole_13_X = -4f;
  public const float OHRANTOWER_WarpHole_13_Y = 44f;
  public const float OHRANTOWER_WarpHole_13_Z = 21f;

  public const string OHRANTOWER_WarpHole_14_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_14_O = "14";
  public const float OHRANTOWER_WarpHole_14_X = -4f;
  public const float OHRANTOWER_WarpHole_14_Y = 44f;
  public const float OHRANTOWER_WarpHole_14_Z = 25f;

  public const string OHRANTOWER_WarpHole_15_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_15_O = "15";
  public const float OHRANTOWER_WarpHole_15_X = -7f;
  public const float OHRANTOWER_WarpHole_15_Y = 44f;
  public const float OHRANTOWER_WarpHole_15_Z = 28f;

  public const string OHRANTOWER_WarpHole_16_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_16_O = "16";
  public const float OHRANTOWER_WarpHole_16_X = -2f;
  public const float OHRANTOWER_WarpHole_16_Y = 44f;
  public const float OHRANTOWER_WarpHole_16_Z = 33f;

  public const string OHRANTOWER_WarpHole_17_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_17_O = "17";
  public const float OHRANTOWER_WarpHole_17_X = 2f;
  public const float OHRANTOWER_WarpHole_17_Y = 44f;
  public const float OHRANTOWER_WarpHole_17_Z = 33f;

  public const string OHRANTOWER_WarpHole_18_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_18_O = "18";
  public const float OHRANTOWER_WarpHole_18_X = 7f;
  public const float OHRANTOWER_WarpHole_18_Y = 44f;
  public const float OHRANTOWER_WarpHole_18_Z = 28f;

  public const string OHRANTOWER_WarpHole_19_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_19_O = "19";
  public const float OHRANTOWER_WarpHole_19_X = 4f;
  public const float OHRANTOWER_WarpHole_19_Y = 44f;
  public const float OHRANTOWER_WarpHole_19_Z = 25f;

  public const string OHRANTOWER_WarpHole_20_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_20_O = "20";
  public const float OHRANTOWER_WarpHole_20_X = 6f;
  public const float OHRANTOWER_WarpHole_20_Y = 44f;
  public const float OHRANTOWER_WarpHole_20_Z = 32f;

  public const string OHRANTOWER_WarpHole_21_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_21_O = "21";
  public const float OHRANTOWER_WarpHole_21_X = 6f;
  public const float OHRANTOWER_WarpHole_21_Y = 44f;
  public const float OHRANTOWER_WarpHole_21_Z = 15f;

  public const string OHRANTOWER_WarpHole_22_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_22_O = "22";
  public const float OHRANTOWER_WarpHole_22_X = -7f;
  public const float OHRANTOWER_WarpHole_22_Y = 44f;
  public const float OHRANTOWER_WarpHole_22_Z = 23f;

  public const string OHRANTOWER_WarpHole_23_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_23_O = "23";
  public const float OHRANTOWER_WarpHole_23_X = -2f;
  public const float OHRANTOWER_WarpHole_23_Y = 44f;
  public const float OHRANTOWER_WarpHole_23_Z = 35f;

  public const string OHRANTOWER_WarpHole_24_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_24_O = "24";
  public const float OHRANTOWER_WarpHole_24_X = -4f;
  public const float OHRANTOWER_WarpHole_24_Y = 44f;
  public const float OHRANTOWER_WarpHole_24_Z = 14f;

  public const string OHRANTOWER_WarpHole_25_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_25_O = "25";
  public const float OHRANTOWER_WarpHole_25_X = 0f;
  public const float OHRANTOWER_WarpHole_25_Y = 44f;
  public const float OHRANTOWER_WarpHole_25_Z = 28f;

  public const string OHRANTOWER_FloatingTile_30_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_30_O = "30";
  public const float OHRANTOWER_FloatingTile_30_X = 9f;
  public const float OHRANTOWER_FloatingTile_30_Y = 44f;
  public const float OHRANTOWER_FloatingTile_30_Z = 23f;

  public const string OHRANTOWER_Fountain_1_C = "Fountain";
  public const string OHRANTOWER_Fountain_1_O = "1";
  public const float OHRANTOWER_Fountain_1_X = 4f;
  public const float OHRANTOWER_Fountain_1_Y = 64f;
  public const float OHRANTOWER_Fountain_1_Z = 22f;

  public const string OHRANTOWER_FloatingTile_31_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_31_O = "31";
  public const float OHRANTOWER_FloatingTile_31_X = -1f;
  public const float OHRANTOWER_FloatingTile_31_Y = 64f;
  public const float OHRANTOWER_FloatingTile_31_Z = 26f;

  public const string OHRANTOWER_FloatingTile_32_C = "FloatingTile";
  public const string OHRANTOWER_FloatingTile_32_O = "32";
  public const float OHRANTOWER_FloatingTile_32_X = -1f;
  public const float OHRANTOWER_FloatingTile_32_Y = 1f;
  public const float OHRANTOWER_FloatingTile_32_Z = 24f;

  public const string OHRANTOWER_Treasure_9_C = "Treasure";
  public const string OHRANTOWER_Treasure_9_O = "9";
  public const float OHRANTOWER_Treasure_9_X = -6f;
  public const float OHRANTOWER_Treasure_9_Y = 37f;
  public const float OHRANTOWER_Treasure_9_Z = 26f;

  public const string OHRANTOWER_Treasure_10_C = "Treasure";
  public const string OHRANTOWER_Treasure_10_O = "10";
  public const float OHRANTOWER_Treasure_10_X = 5f;
  public const float OHRANTOWER_Treasure_10_Y = 37f;
  public const float OHRANTOWER_Treasure_10_Z = 27f;

  public const string OHRANTOWER_Treasure_11_C = "Treasure";
  public const string OHRANTOWER_Treasure_11_O = "11";
  public const float OHRANTOWER_Treasure_11_X = -1f;
  public const float OHRANTOWER_Treasure_11_Y = 37f;
  public const float OHRANTOWER_Treasure_11_Z = 15f;

  public const string OHRANTOWER_Treasure_12_C = "Treasure";
  public const string OHRANTOWER_Treasure_12_O = "12";
  public const float OHRANTOWER_Treasure_12_X = -2f;
  public const float OHRANTOWER_Treasure_12_Y = 37f;
  public const float OHRANTOWER_Treasure_12_Z = 25f;

  public const string OHRANTOWER_Treasure_13_C = "Treasure";
  public const string OHRANTOWER_Treasure_13_O = "13";
  public const float OHRANTOWER_Treasure_13_X = 0f;
  public const float OHRANTOWER_Treasure_13_Y = 45f;
  public const float OHRANTOWER_Treasure_13_Z = 32f;

  public const string OHRANTOWER_Treasure_14_C = "Treasure";
  public const string OHRANTOWER_Treasure_14_O = "14";
  public const float OHRANTOWER_Treasure_14_X = -8f;
  public const float OHRANTOWER_Treasure_14_Y = 45f;
  public const float OHRANTOWER_Treasure_14_Z = 12f;

  public const string OHRANTOWER_Treasure_15_C = "Treasure";
  public const string OHRANTOWER_Treasure_15_O = "15";
  public const float OHRANTOWER_Treasure_15_X = -8f;
  public const float OHRANTOWER_Treasure_15_Y = 45f;
  public const float OHRANTOWER_Treasure_15_Z = 16f;

  public const string OHRANTOWER_Treasure_16_C = "Treasure";
  public const string OHRANTOWER_Treasure_16_O = "16";
  public const float OHRANTOWER_Treasure_16_X = -7f;
  public const float OHRANTOWER_Treasure_16_Y = 45f;
  public const float OHRANTOWER_Treasure_16_Z = 35f;

  public const string OHRANTOWER_Treasure_17_C = "Treasure";
  public const string OHRANTOWER_Treasure_17_O = "17";
  public const float OHRANTOWER_Treasure_17_X = -6f;
  public const float OHRANTOWER_Treasure_17_Y = 62.5f;
  public const float OHRANTOWER_Treasure_17_Z = 22f;

  public const string OHRANTOWER_Treasure_18_C = "Treasure";
  public const string OHRANTOWER_Treasure_18_O = "18";
  public const float OHRANTOWER_Treasure_18_X = 5f;
  public const float OHRANTOWER_Treasure_18_Y = 8f;
  public const float OHRANTOWER_Treasure_18_Z = 18f;

  public const string OHRANTOWER_Treasure_19_C = "Treasure";
  public const string OHRANTOWER_Treasure_19_O = "19";
  public const float OHRANTOWER_Treasure_19_X = 5f;
  public const float OHRANTOWER_Treasure_19_Y = 9f;
  public const float OHRANTOWER_Treasure_19_Z = 9f;

  public const string OHRANTOWER_Treasure_20_C = "Treasure";
  public const string OHRANTOWER_Treasure_20_O = "20";
  public const float OHRANTOWER_Treasure_20_X = -16f;
  public const float OHRANTOWER_Treasure_20_Y = 13f;
  public const float OHRANTOWER_Treasure_20_Z = 10f;

  public const string OHRANTOWER_Treasure_21_C = "Treasure";
  public const string OHRANTOWER_Treasure_21_O = "21";
  public const float OHRANTOWER_Treasure_21_X = -2f;
  public const float OHRANTOWER_Treasure_21_Y = 13f;
  public const float OHRANTOWER_Treasure_21_Z = 21f;

  public const string OHRANTOWER_Treasure_22_C = "Treasure";
  public const string OHRANTOWER_Treasure_22_O = "22";
  public const float OHRANTOWER_Treasure_22_X = 1f;
  public const float OHRANTOWER_Treasure_22_Y = 29f;
  public const float OHRANTOWER_Treasure_22_Z = 18f;

  public const string OHRANTOWER_Treasure_23_C = "Treasure";
  public const string OHRANTOWER_Treasure_23_O = "23";
  public const float OHRANTOWER_Treasure_23_X = -1f;
  public const float OHRANTOWER_Treasure_23_Y = 45f;
  public const float OHRANTOWER_Treasure_23_Z = 20f;

  public const string OHRANTOWER_WarpHole_26_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_26_O = "26";
  public const float OHRANTOWER_WarpHole_26_X = 1f;
  public const float OHRANTOWER_WarpHole_26_Y = 44f;
  public const float OHRANTOWER_WarpHole_26_Z = 20f;
  #endregion
  #region "ダルの門 ( not used )"
  // ダルの門、右エリア入口
  public const string EVENT_GATEDHAL_1 = "EVENT_GATEDHAL_1";
  public const float EVENT_GATEDHAL_1_X = 44.0f;
  public const float EVENT_GATEDHAL_1_Y = 1.0f;
  public const float EVENT_GATEDHAL_1_Z = 3.0f;

  // ダルの門、左エリア入口
  public const string EVENT_GATEDHAL_2 = "EVENT_GATEDHAL_2";
  public const float EVENT_GATEDHAL_2_X = -44.0f;
  public const float EVENT_GATEDHAL_2_Y = 1.0f;
  public const float EVENT_GATEDHAL_2_Z = 3.0f;

  // ダルの門、中央通路入口
  public const string EVENT_GATEDHAL_3 = "EVENT_GATEDHAL_3";
  public const float EVENT_GATEDHAL_3_X = 0;
  public const float EVENT_GATEDHAL_3_Y = 1.0f;
  public const float EVENT_GATEDHAL_3_Z = 2.0f;

  public const string GATEOFDHAL_DhalGate_Tile_1_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_1_O = "1";
  public const float GATEOFDHAL_DhalGate_Tile_1_X = 20f;
  public const float GATEOFDHAL_DhalGate_Tile_1_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_1_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_2_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_2_O = "2";
  public const float GATEOFDHAL_DhalGate_Tile_2_X = 18f;
  public const float GATEOFDHAL_DhalGate_Tile_2_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_2_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_3_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_3_O = "3";
  public const float GATEOFDHAL_DhalGate_Tile_3_X = 16f;
  public const float GATEOFDHAL_DhalGate_Tile_3_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_3_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_4_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_4_O = "4";
  public const float GATEOFDHAL_DhalGate_Tile_4_X = 14f;
  public const float GATEOFDHAL_DhalGate_Tile_4_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_4_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_5_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_5_O = "5";
  public const float GATEOFDHAL_DhalGate_Tile_5_X = 12f;
  public const float GATEOFDHAL_DhalGate_Tile_5_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_5_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_6_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_6_O = "6";
  public const float GATEOFDHAL_DhalGate_Tile_6_X = -19f;
  public const float GATEOFDHAL_DhalGate_Tile_6_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_6_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_7_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_7_O = "7";
  public const float GATEOFDHAL_DhalGate_Tile_7_X = -21f;
  public const float GATEOFDHAL_DhalGate_Tile_7_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_7_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_8_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_8_O = "8";
  public const float GATEOFDHAL_DhalGate_Tile_8_X = -23f;
  public const float GATEOFDHAL_DhalGate_Tile_8_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_8_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_9_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_9_O = "9";
  public const float GATEOFDHAL_DhalGate_Tile_9_X = -25f;
  public const float GATEOFDHAL_DhalGate_Tile_9_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_9_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_10_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_10_O = "10";
  public const float GATEOFDHAL_DhalGate_Tile_10_X = -27f;
  public const float GATEOFDHAL_DhalGate_Tile_10_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_10_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Tile_11_C = "DhalGate_Tile";
  public const string GATEOFDHAL_DhalGate_Tile_11_O = "11";
  public const float GATEOFDHAL_DhalGate_Tile_11_X = -29f;
  public const float GATEOFDHAL_DhalGate_Tile_11_Y = 0f;
  public const float GATEOFDHAL_DhalGate_Tile_11_Z = 5f;

  public const string GATEOFDHAL_DhalGate_Door_1_C = "DhalGate_Door";
  public const string GATEOFDHAL_DhalGate_Door_1_O = "1";
  public const float GATEOFDHAL_DhalGate_Door_1_X = 44f;
  public const float GATEOFDHAL_DhalGate_Door_1_Y = 1f;
  public const float GATEOFDHAL_DhalGate_Door_1_Z = 3f;

  public const string GATEOFDHAL_DhalGate_Door_2_C = "DhalGate_Door";
  public const string GATEOFDHAL_DhalGate_Door_2_O = "2";
  public const float GATEOFDHAL_DhalGate_Door_2_X = -44f;
  public const float GATEOFDHAL_DhalGate_Door_2_Y = 1f;
  public const float GATEOFDHAL_DhalGate_Door_2_Z = 3f;

  public const string GATEOFDHAL_DhalGate_Door_3_C = "DhalGate_Door";
  public const string GATEOFDHAL_DhalGate_Door_3_O = "3";
  public const float GATEOFDHAL_DhalGate_Door_3_X = 0f;
  public const float GATEOFDHAL_DhalGate_Door_3_Y = 1f;
  public const float GATEOFDHAL_DhalGate_Door_3_Z = 2f;

  public const string GATEOFDHAL_Treasure_1_C = "Treasure";
  public const string GATEOFDHAL_Treasure_1_O = "1";
  public const float GATEOFDHAL_Treasure_1_X = 42f;
  public const float GATEOFDHAL_Treasure_1_Y = 1f;
  public const float GATEOFDHAL_Treasure_1_Z = 22f;

  public const string GATEOFDHAL_Treasure_2_C = "Treasure";
  public const string GATEOFDHAL_Treasure_2_O = "2";
  public const float GATEOFDHAL_Treasure_2_X = 38f;
  public const float GATEOFDHAL_Treasure_2_Y = 1f;
  public const float GATEOFDHAL_Treasure_2_Z = 6f;

  public const string GATEOFDHAL_Treasure_3_C = "Treasure";
  public const string GATEOFDHAL_Treasure_3_O = "3";
  public const float GATEOFDHAL_Treasure_3_X = 20f;
  public const float GATEOFDHAL_Treasure_3_Y = 4f;
  public const float GATEOFDHAL_Treasure_3_Z = 8f;

  public const string GATEOFDHAL_Treasure_4_C = "Treasure";
  public const string GATEOFDHAL_Treasure_4_O = "4";
  public const float GATEOFDHAL_Treasure_4_X = 8f;
  public const float GATEOFDHAL_Treasure_4_Y = 4f;
  public const float GATEOFDHAL_Treasure_4_Z = 14f;

  public const string GATEOFDHAL_Treasure_5_C = "Treasure";
  public const string GATEOFDHAL_Treasure_5_O = "5";
  public const float GATEOFDHAL_Treasure_5_X = 20f;
  public const float GATEOFDHAL_Treasure_5_Y = 4f;
  public const float GATEOFDHAL_Treasure_5_Z = 21f;

  public const string GATEOFDHAL_Treasure_6_C = "Treasure";
  public const string GATEOFDHAL_Treasure_6_O = "6";
  public const float GATEOFDHAL_Treasure_6_X = 19f;
  public const float GATEOFDHAL_Treasure_6_Y = 4f;
  public const float GATEOFDHAL_Treasure_6_Z = 14f;

  public const string GATEOFDHAL_Treasure_7_C = "Treasure";
  public const string GATEOFDHAL_Treasure_7_O = "7";
  public const float GATEOFDHAL_Treasure_7_X = 31f;
  public const float GATEOFDHAL_Treasure_7_Y = 4f;
  public const float GATEOFDHAL_Treasure_7_Z = 24f;

  public const string GATEOFDHAL_Treasure_8_C = "Treasure";
  public const string GATEOFDHAL_Treasure_8_O = "8";
  public const float GATEOFDHAL_Treasure_8_X = -39f;
  public const float GATEOFDHAL_Treasure_8_Y = 1f;
  public const float GATEOFDHAL_Treasure_8_Z = 8f;

  public const string GATEOFDHAL_Treasure_9_C = "Treasure";
  public const string GATEOFDHAL_Treasure_9_O = "9";
  public const float GATEOFDHAL_Treasure_9_X = -33f;
  public const float GATEOFDHAL_Treasure_9_Y = 1f;
  public const float GATEOFDHAL_Treasure_9_Z = 11f;

  public const string GATEOFDHAL_Treasure_10_C = "Treasure";
  public const string GATEOFDHAL_Treasure_10_O = "10";
  public const float GATEOFDHAL_Treasure_10_X = -33f;
  public const float GATEOFDHAL_Treasure_10_Y = 1f;
  public const float GATEOFDHAL_Treasure_10_Z = 9f;

  public const string GATEOFDHAL_Treasure_11_C = "Treasure";
  public const string GATEOFDHAL_Treasure_11_O = "11";
  public const float GATEOFDHAL_Treasure_11_X = -39f;
  public const float GATEOFDHAL_Treasure_11_Y = 1f;
  public const float GATEOFDHAL_Treasure_11_Z = 21f;

  public const string GATEOFDHAL_Treasure_12_C = "Treasure";
  public const string GATEOFDHAL_Treasure_12_O = "12";
  public const float GATEOFDHAL_Treasure_12_X = -39f;
  public const float GATEOFDHAL_Treasure_12_Y = 1f;
  public const float GATEOFDHAL_Treasure_12_Z = 19f;

  public const string GATEOFDHAL_Treasure_13_C = "Treasure";
  public const string GATEOFDHAL_Treasure_13_O = "13";
  public const float GATEOFDHAL_Treasure_13_X = -23f;
  public const float GATEOFDHAL_Treasure_13_Y = 4f;
  public const float GATEOFDHAL_Treasure_13_Z = 16f;

  public const string GATEOFDHAL_Treasure_14_C = "Treasure";
  public const string GATEOFDHAL_Treasure_14_O = "14";
  public const float GATEOFDHAL_Treasure_14_X = -16f;
  public const float GATEOFDHAL_Treasure_14_Y = 4f;
  public const float GATEOFDHAL_Treasure_14_Z = 12f;

  public const string GATEOFDHAL_Treasure_15_C = "Treasure";
  public const string GATEOFDHAL_Treasure_15_O = "15";
  public const float GATEOFDHAL_Treasure_15_X = -9f;
  public const float GATEOFDHAL_Treasure_15_Y = 4f;
  public const float GATEOFDHAL_Treasure_15_Z = 13f;

  public const string GATEOFDHAL_Treasure_16_C = "Treasure";
  public const string GATEOFDHAL_Treasure_16_O = "16";
  public const float GATEOFDHAL_Treasure_16_X = -6f;
  public const float GATEOFDHAL_Treasure_16_Y = 4f;
  public const float GATEOFDHAL_Treasure_16_Z = 19f;

  public const string GATEOFDHAL_Treasure_17_C = "Treasure";
  public const string GATEOFDHAL_Treasure_17_O = "17";
  public const float GATEOFDHAL_Treasure_17_X = -17f;
  public const float GATEOFDHAL_Treasure_17_Y = 4f;
  public const float GATEOFDHAL_Treasure_17_Z = 23f;

  public const string GATEOFDHAL_Treasure_18_C = "Treasure";
  public const string GATEOFDHAL_Treasure_18_O = "18";
  public const float GATEOFDHAL_Treasure_18_X = -15f;
  public const float GATEOFDHAL_Treasure_18_Y = 4f;
  public const float GATEOFDHAL_Treasure_18_Z = 24f;

  public const string GATEOFDHAL_Treasure_19_C = "Treasure";
  public const string GATEOFDHAL_Treasure_19_O = "19";
  public const float GATEOFDHAL_Treasure_19_X = 27f;
  public const float GATEOFDHAL_Treasure_19_Y = 10f;
  public const float GATEOFDHAL_Treasure_19_Z = 11f;

  public const string GATEOFDHAL_Treasure_20_C = "Treasure";
  public const string GATEOFDHAL_Treasure_20_O = "20";
  public const float GATEOFDHAL_Treasure_20_X = 42f;
  public const float GATEOFDHAL_Treasure_20_Y = 10f;
  public const float GATEOFDHAL_Treasure_20_Z = 7f;

  public const string GATEOFDHAL_Treasure_21_C = "Treasure";
  public const string GATEOFDHAL_Treasure_21_O = "21";
  public const float GATEOFDHAL_Treasure_21_X = 45f;
  public const float GATEOFDHAL_Treasure_21_Y = 10f;
  public const float GATEOFDHAL_Treasure_21_Z = 17f;

  public const string GATEOFDHAL_Treasure_22_C = "Treasure";
  public const string GATEOFDHAL_Treasure_22_O = "22";
  public const float GATEOFDHAL_Treasure_22_X = 13f;
  public const float GATEOFDHAL_Treasure_22_Y = 10f;
  public const float GATEOFDHAL_Treasure_22_Z = 13f;

  public const string GATEOFDHAL_Treasure_23_C = "Treasure";
  public const string GATEOFDHAL_Treasure_23_O = "23";
  public const float GATEOFDHAL_Treasure_23_X = 5f;
  public const float GATEOFDHAL_Treasure_23_Y = 10f;
  public const float GATEOFDHAL_Treasure_23_Z = 11f;

  public const string GATEOFDHAL_Treasure_24_C = "Treasure";
  public const string GATEOFDHAL_Treasure_24_O = "24";
  public const float GATEOFDHAL_Treasure_24_X = 6f;
  public const float GATEOFDHAL_Treasure_24_Y = 10f;
  public const float GATEOFDHAL_Treasure_24_Z = 18f;

  public const string GATEOFDHAL_Treasure_25_C = "Treasure";
  public const string GATEOFDHAL_Treasure_25_O = "25";
  public const float GATEOFDHAL_Treasure_25_X = 7f;
  public const float GATEOFDHAL_Treasure_25_Y = 10f;
  public const float GATEOFDHAL_Treasure_25_Z = 28f;

  public const string GATEOFDHAL_Treasure_26_C = "Treasure";
  public const string GATEOFDHAL_Treasure_26_O = "26";
  public const float GATEOFDHAL_Treasure_26_X = 4f;
  public const float GATEOFDHAL_Treasure_26_Y = 10f;
  public const float GATEOFDHAL_Treasure_26_Z = 31f;

  public const string GATEOFDHAL_Treasure_27_C = "Treasure";
  public const string GATEOFDHAL_Treasure_27_O = "27";
  public const float GATEOFDHAL_Treasure_27_X = 23f;
  public const float GATEOFDHAL_Treasure_27_Y = 10f;
  public const float GATEOFDHAL_Treasure_27_Z = 28f;

  public const string GATEOFDHAL_Treasure_28_C = "Treasure";
  public const string GATEOFDHAL_Treasure_28_O = "28";
  public const float GATEOFDHAL_Treasure_28_X = 29f;
  public const float GATEOFDHAL_Treasure_28_Y = 10f;
  public const float GATEOFDHAL_Treasure_28_Z = 27f;

  public const string GATEOFDHAL_Treasure_29_C = "Treasure";
  public const string GATEOFDHAL_Treasure_29_O = "29";
  public const float GATEOFDHAL_Treasure_29_X = 29f;
  public const float GATEOFDHAL_Treasure_29_Y = 10f;
  public const float GATEOFDHAL_Treasure_29_Z = 23f;

  public const string GATEOFDHAL_Treasure_30_C = "Treasure";
  public const string GATEOFDHAL_Treasure_30_O = "30";
  public const float GATEOFDHAL_Treasure_30_X = 39f;
  public const float GATEOFDHAL_Treasure_30_Y = 10f;
  public const float GATEOFDHAL_Treasure_30_Z = 29f;

  public const string GATEOFDHAL_Treasure_31_C = "Treasure";
  public const string GATEOFDHAL_Treasure_31_O = "31";
  public const float GATEOFDHAL_Treasure_31_X = 44f;
  public const float GATEOFDHAL_Treasure_31_Y = 10f;
  public const float GATEOFDHAL_Treasure_31_Z = 21f;

  public const string GATEOFDHAL_Treasure_32_C = "Treasure";
  public const string GATEOFDHAL_Treasure_32_O = "32";
  public const float GATEOFDHAL_Treasure_32_X = 37f;
  public const float GATEOFDHAL_Treasure_32_Y = 10f;
  public const float GATEOFDHAL_Treasure_32_Z = 19f;

  public const string GATEOFDHAL_Treasure_33_C = "Treasure";
  public const string GATEOFDHAL_Treasure_33_O = "33";
  public const float GATEOFDHAL_Treasure_33_X = -5f;
  public const float GATEOFDHAL_Treasure_33_Y = 10f;
  public const float GATEOFDHAL_Treasure_33_Z = 16f;

  public const string GATEOFDHAL_Treasure_34_C = "Treasure";
  public const string GATEOFDHAL_Treasure_34_O = "34";
  public const float GATEOFDHAL_Treasure_34_X = -12f;
  public const float GATEOFDHAL_Treasure_34_Y = 10f;
  public const float GATEOFDHAL_Treasure_34_Z = 8f;

  public const string GATEOFDHAL_Treasure_35_C = "Treasure";
  public const string GATEOFDHAL_Treasure_35_O = "35";
  public const float GATEOFDHAL_Treasure_35_X = -17f;
  public const float GATEOFDHAL_Treasure_35_Y = 10f;
  public const float GATEOFDHAL_Treasure_35_Z = 9f;

  public const string GATEOFDHAL_Treasure_36_C = "Treasure";
  public const string GATEOFDHAL_Treasure_36_O = "36";
  public const float GATEOFDHAL_Treasure_36_X = -13f;
  public const float GATEOFDHAL_Treasure_36_Y = 10f;
  public const float GATEOFDHAL_Treasure_36_Z = 3f;

  public const string GATEOFDHAL_Treasure_37_C = "Treasure";
  public const string GATEOFDHAL_Treasure_37_O = "37";
  public const float GATEOFDHAL_Treasure_37_X = -44f;
  public const float GATEOFDHAL_Treasure_37_Y = 10f;
  public const float GATEOFDHAL_Treasure_37_Z = 5f;

  public const string GATEOFDHAL_Treasure_38_C = "Treasure";
  public const string GATEOFDHAL_Treasure_38_O = "38";
  public const float GATEOFDHAL_Treasure_38_X = -45f;
  public const float GATEOFDHAL_Treasure_38_Y = 10f;
  public const float GATEOFDHAL_Treasure_38_Z = 17f;

  public const string GATEOFDHAL_Treasure_39_C = "Treasure";
  public const string GATEOFDHAL_Treasure_39_O = "39";
  public const float GATEOFDHAL_Treasure_39_X = -41f;
  public const float GATEOFDHAL_Treasure_39_Y = 10f;
  public const float GATEOFDHAL_Treasure_39_Z = 17f;

  public const string GATEOFDHAL_Treasure_40_C = "Treasure";
  public const string GATEOFDHAL_Treasure_40_O = "40";
  public const float GATEOFDHAL_Treasure_40_X = -39f;
  public const float GATEOFDHAL_Treasure_40_Y = 10f;
  public const float GATEOFDHAL_Treasure_40_Z = 5f;

  public const string GATEOFDHAL_Treasure_41_C = "Treasure";
  public const string GATEOFDHAL_Treasure_41_O = "41";
  public const float GATEOFDHAL_Treasure_41_X = -27f;
  public const float GATEOFDHAL_Treasure_41_Y = 10f;
  public const float GATEOFDHAL_Treasure_41_Z = 14f;

  public const string GATEOFDHAL_Treasure_42_C = "Treasure";
  public const string GATEOFDHAL_Treasure_42_O = "42";
  public const float GATEOFDHAL_Treasure_42_X = -4f;
  public const float GATEOFDHAL_Treasure_42_Y = 10f;
  public const float GATEOFDHAL_Treasure_42_Z = 20f;

  public const string GATEOFDHAL_Treasure_43_C = "Treasure";
  public const string GATEOFDHAL_Treasure_43_O = "43";
  public const float GATEOFDHAL_Treasure_43_X = -7f;
  public const float GATEOFDHAL_Treasure_43_Y = 10f;
  public const float GATEOFDHAL_Treasure_43_Z = 22f;

  public const string GATEOFDHAL_Treasure_44_C = "Treasure";
  public const string GATEOFDHAL_Treasure_44_O = "44";
  public const float GATEOFDHAL_Treasure_44_X = -4f;
  public const float GATEOFDHAL_Treasure_44_Y = 10f;
  public const float GATEOFDHAL_Treasure_44_Z = 30f;

  public const string GATEOFDHAL_Treasure_45_C = "Treasure";
  public const string GATEOFDHAL_Treasure_45_O = "45";
  public const float GATEOFDHAL_Treasure_45_X = -13f;
  public const float GATEOFDHAL_Treasure_45_Y = 10f;
  public const float GATEOFDHAL_Treasure_45_Z = 30f;

  public const string GATEOFDHAL_Treasure_46_C = "Treasure";
  public const string GATEOFDHAL_Treasure_46_O = "46";
  public const float GATEOFDHAL_Treasure_46_X = -23f;
  public const float GATEOFDHAL_Treasure_46_Y = 10f;
  public const float GATEOFDHAL_Treasure_46_Z = 28f;

  public const string GATEOFDHAL_Treasure_47_C = "Treasure";
  public const string GATEOFDHAL_Treasure_47_O = "47";
  public const float GATEOFDHAL_Treasure_47_X = -30f;
  public const float GATEOFDHAL_Treasure_47_Y = 10f;
  public const float GATEOFDHAL_Treasure_47_Z = 30f;

  public const string GATEOFDHAL_Treasure_48_C = "Treasure";
  public const string GATEOFDHAL_Treasure_48_O = "48";
  public const float GATEOFDHAL_Treasure_48_X = -44f;
  public const float GATEOFDHAL_Treasure_48_Y = 10f;
  public const float GATEOFDHAL_Treasure_48_Z = 22f;

  public const string GATEOFDHAL_Treasure_49_C = "Treasure";
  public const string GATEOFDHAL_Treasure_49_O = "49";
  public const float GATEOFDHAL_Treasure_49_X = -37f;
  public const float GATEOFDHAL_Treasure_49_Y = 10f;
  public const float GATEOFDHAL_Treasure_49_Z = 19f;

  public const string GATEOFDHAL_Treasure_50_C = "Treasure";
  public const string GATEOFDHAL_Treasure_50_O = "50";
  public const float GATEOFDHAL_Treasure_50_X = -8f;
  public const float GATEOFDHAL_Treasure_50_Y = 13f;
  public const float GATEOFDHAL_Treasure_50_Z = 25f;

  public const string GATEOFDHAL_Treasure_51_C = "Treasure";
  public const string GATEOFDHAL_Treasure_51_O = "51";
  public const float GATEOFDHAL_Treasure_51_X = 29f;
  public const float GATEOFDHAL_Treasure_51_Y = 13f;
  public const float GATEOFDHAL_Treasure_51_Z = 11f;
  #endregion
  #endregion

  #region "World Keyword"
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
  #region "Area"
  public const string AREA_FAZIL = "ファージル";
  public const string AREA_VINSGARDE = "ヴィンスガルデ";
  public const string AREA_MOONFORDER = "ムーンフォーダー";
  #endregion
  #region "Hometown"
  public const string TOWN_ANSHET = "アンシェット街";
  public const string TOWN_QVELTA_TOWN = "クヴェルタ街";
  public const string TOWN_COTUHSYE = "港町コチューシェ";
  public const string TOWN_ZHALMAN = "ツァルマンの里";
  public const string TOWN_WOSM = "ウォズム村";
  public const string TOWN_ARCANEDINE = "アーケンダイン街";
  public const string TOWN_DALE = "ディルの街";
  public const string TOWER_OHRAN = "オーランの塔";
  public const string TOWN_LATA_HOUSE = "ラタの小屋";
  public const string TOWN_ZELMAN = "ゼールマンの里";
  public const string TOWER_FRAN = "フーランの塔";
  public const string TOWN_FAZIL_CASTLE = "ファージル宮殿";
  public const string TOWN_PARMETYSIA = "パルメテイシア神殿";
  public const string TOWN_EDELGARZEN_CASTLE = "エデルガイゼン城";
  public const string TOWN_FAZIL_UNDERGROUND = "ファージル宮殿地下";
  #endregion
  #region "Dungeon"
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
  public const string DUNGEON_EDELGARZEN_CASTLE = "エデルガイゼン城";
  public const string DUNGEON_SITH_GRAVEYARD = "シスの墓標";
  public const string DUNGEON_GANRO_FORTRESS = "ガンロー要塞";
  public const string DUNGEON_LOSLON_CAVE = "ロスロンの洞窟";
  public const string DUNGEON_HEAVENS_GENESIS_GATE = "天上界ジェネシスゲート";
  #endregion
  #region "Field"
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
  #region "Guardian Angel"
  public const string GUARDIAN_ANGEL_RED = "炎授天使";
  public const string GUARDIAN_ANGEL_BLUE = "蒼授天使";
  public const string GUARDIAN_ANGEL_BLACK = "断罪天使";
  public const string GUARDIAN_ANGEL_WHITE = "珀流天使";
  #endregion
  #endregion

}
