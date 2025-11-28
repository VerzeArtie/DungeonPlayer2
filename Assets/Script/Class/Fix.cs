using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Fix
{
  #region "enum"
  public enum Direction
  {
    None,
    Top,
    Left,
    Right,
    Bottom,
    Rise,
    Fall,
  }

  public enum BuffType
  {
    None,
    Positive,
    Negative,
    Neutral,
  }

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

  public enum BattleMode
  {
    None,
    Normal,
    Boss,
    Duel,
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
    Fire, // 炎
    Ice, // 氷
    HolyLight, // 聖
    DarkMagic, // 闇
    Force, // 理
    VoidChant, // 空唱
    Warrior, // 戦士
    Guardian, // 護衛
    MartialArts, // 格闘
    Archery, // 弓術
    Truth, // 心眼
    Mindfulness, // 無心
    HolyLight_DarkMagic, // 聖＋闇
    HolyLight_Fire, // 聖＋炎
    HolyLight_Ice, // 聖＋氷
    HolyLight_Force, // 聖＋理
    HolyLight_VoidChant, // 聖＋空唱
    DarkMagic_Fire, // 闇＋炎
    DarkMagic_Ice, // 闇＋氷
    DarkMagic_Force, // 闇＋理
    DarkMagic_VoidChant, // 闇＋空唱
    Fire_Ice, // 炎＋氷
    Fire_Force, // 炎＋理
    Fire_VoidChant, // 炎＋空唱
    Ice_Force, // 氷＋理
    Ice_VoidChant, // 氷＋空唱
    Force_VoidChant, // 理＋空唱
    Warrior_Guardian, // 戦士＋護衛
    Warrior_MartialArts, // 戦士＋格闘
    Warrior_Archery, // 戦士＋弓術
    Warrior_Truth, // 戦士＋心眼
    Warrior_Mindfulness, // 戦士＋無心
    Guardian_MartialArts, // 護衛＋格闘
    Guardian_Archery, // 護衛＋弓術
    Guardian_Truth, // 護衛＋心眼
    Guardian_Mindfulness, // 護衛＋無心
    MartialArts_Archery, // 格闘＋弓術
    MartialArts_Truth, // 格闘＋心眼
    MartialArts_Mindfulness, // 格闘＋無心
    Archery_Truth, // 弓術＋心眼
    Archery_Mindfulness, // 弓術＋無心
    Truth_Mindfulness, // 心眼＋無心
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
    Physical, // 物理
    PhysicalMixed, // 物理(KineticSmashなど)
    Colorless, // 無属性
  }

  public enum IgnoreType
  {
    None,
    DefenseMode, // 相手の防御姿勢を無視する
    DefenseValue, // 相手の物理防御力を無視する
    Both // 上記両方
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
    Boss1, // THE_GALVADAZER
    TruthBoss1,
    Area21,
    Area22,
    Area23,
    Area24,
    Boss21, // unused
    Boss22, // unused
    Boss23, // unused
    Boss24, // unused
    Boss25, // unused
    Boss2, // MAGICAL_HAIL_GUN
    TruthBoss2,
    Area31,
    Area32,
    Area33,
    Area34,
    Boss3, // FLANSIS_OF_THE_FOREST_QUEEN
    TruthBoss3,
    Area41,
    Area42,
    Area43,
    Area44,
    Area45,
    Boss4, // LIGHT_THUNDER_LANCEBOLTS
    Boss42, // THE_YODIRIAN
    TruthBoss4,
    Area51,
    Area52,
    Area53,
    Area54,
    Area55,
    Boss5, // DEVIL_STAR_DEATH_FLODIETE
    Boss52, // THE_BIGHAND_OF_KRAKEN
    Boss53, // GUARDIAN_ROYAL_NAGA
    Boss54_1, // BRILLIANT_SEA_PRINCE_1
    Boss54_2, // SHELL_THE_SWORD_KNIGHT
    Boss54_3_1, // SEA_STAR_KNIGHT_AEGIR
    Boss54_3_2, // SEA_STAR_KNIGHT_AMARA
    Boss54_4, // ORIGIN_STAR_CORAL_QUEEN_1
    Boss54_5_1, // JELLY_EYE_BRIGHT_RED
    Boss54_5_2, // JELLY_EYE_DEEP_BLUE
    Boss54_6, // GROUND_VORTEX_LEVIATHAN
    Boss54_7_1, // BRILLIANT_SEA_PRINCE
    Boss54_7_2, // ORIGIN_STAR_CORAL_QUEEN
    Boss54_7_3, // VELGAS_THE_KING_OF_SEA_STAR
    Area61,
    Area62,
    Area63,
    Area64,
    Area65,
    Boss6, // MASCLEWARRIOR_HARDIL
    Boss62, // HUGE_MAGICIAN_ZAGAN
    Boss63_1, // LEGIN_ARZE_1
    Boss63_2, // LEGIN_ARZE_2
    Boss63_3, // LEGIN_ARZE_3
    Boss64, // EMPEROR_LEGAL_ORPHSTEIN
    Boss64_2, // FIRE_EMPEROR_LEGAL_ORPHSTEIN
    TruthBoss5,
    Area46,
    Duel,
    Area7,
    LastBoss, // ROYAL_KING_AERMI_JORZT
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
  public static float BATTLE_SPEED_MAX = 500.0f;
  public const int BASE_TIMER_BAR_LENGTH = 500;
  public const int BASE_TIMER_DIV = 36;
  public const int TIMER_ICON_NUM = 8;
  public const int MAX_INSTANT_POINT = 1000;
  public const int BOSS_AUTORECOVER = 30;
     
  #endregion
  #region "Battle Effect Message"
  public const string BATTLE_MISS = "Miss";
  public const string BATTLE_DIZZY_MISS = "Dizzy Miss";
  public const string BATTLE_AP_LESS = "No AP";
  public const string BATTLE_MANAPOINT_LESS = "マナ不足";
  public const string BATTLE_SKILLPOINT_LESS = "スキルポイント不足";
  public const string BATTLE_NO_POTION = "No Potion";
  public const string BATTLE_ALREADY_USED = "空っぽ";
  public const string BATTLE_BIND = "Bind";
  public const string BATTLE_DIVINE = "Divine";
  public const string BATTLE_SILENT = "Silent";
  public const string BATTLE_SLEEP_MISS = "ミス(睡眠)";

  public const string BATTLE_ATTACK_UP = "物攻率 UP";
  public const string BATTLE_MAGIC_ATTACK_UP = "魔攻率 UP";
  public const string BATTLE_DEFENSE_UP = "物防率 UP";
  public const string BATTLE_MAGIC_DEFENSE_UP = "魔防率 UP";
  public const string BATTLE_SPEED_UP = "戦速率 UP";
  public const string BATTLE_RESPONS_UP = "戦応率 UP";
  public const string BATTLE_POTENTIAL_UP = "潜在率 UP";

  public const string BATTLE_SORCERY_FAIL = "ソーサリー失敗";
     
  // public const string MISS = @"ミス！";
  // public const string MISS_ACTION = @"行動ミス！";
  // public const string MISS_SPELL = @"詠唱ミス！";
  // public const string MISS_SKILL = @"スキル失敗！";
  public const string FAIL_COUNTER = @"カウンターミス！";
  // public const string FAIL_DEFLECTION = @"物理反射ミス！";
  public const string SUCCESS_COUNTER = @"カウンター発動！";
  // public const string RESIST_DISPEL = @"ディスペル耐性！";

  // 一般用語
  public const string BATTLE_STACK_FAIL_FACTOR = " 失敗！（要因：";
  #endregion
  #region "Character Color"
  public static Color COLOR_NORMAL = Color.black;
  public static Color COLOR_WARNING = Color.red;
  public static Color COLOR_GUARD = Color.magenta;
  public static Color COLOR_HEAL = Color.green;
  public static Color COLOR_GAIN_MP = Color.blue;
  public static Color COLOR_LOST_MP = Color.red;
  public static Color COLOR_GAIN_SP = Color.yellow;
  public static Color COLOR_LOST_SP = Color.red;
  public static Color COLOR_MP_DAMAGE = Color.HSVToRGB(0.5f, 0.2f, 0.7f);
  public static Color COLOR_DAMAGE_REFLECT = new Color(0.8f, 0.0f, 0.5f);    

  public static Color COLOR_FIRE = Color.red;
  public static Color COLOR_ICE = Color.blue;
  public static Color COLOR_HOLYLIGHT = Color.yellow;
  public static Color COLOR_DARKMAGIC = Color.black;
  public static Color COLOR_WARRIOR = new Color(92.0f / 255.0f, 44.0f / 255.0f, 44.0f / 255.0f);
  public static Color COLOR_GUARDIAN = new Color(84.0f / 255.0f, 0.0f / 255.0f, 129.0f / 255.0f);
  public static Color COLOR_MARTIALARTS = new Color(255.0f / 255.0f, 132.0f / 255.0f, 250.0f / 255.0f);
  public static Color COLOR_ARCHERY = new Color(255.0f / 255.0f, 174.0f / 255.0f, 0.0f / 255.0f);
  public static Color COLOR_FORCE = new Color(33.0f / 255.0f, 192.0f / 255.0f, 45.0f / 255.0f);
  public static Color COLOR_VOIDCHANT = new Color(189.0f / 255.0f, 189.0f / 255.0f, 189.0f / 255.0f);
  public static Color COLOR_TRUTH = new Color(172.0f / 255.0f, 210.0f / 255.0f, 255.0f / 255.0f);
  public static Color COLOR_MINDFULNESS = new Color(250.0f / 255.0f, 250.0f / 255.0f, 250.0f / 255.0f);

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

  public static Color COLOR_ENEMY_CHARA = new Color(230.0f / 255.0f, 180.0f / 255.0f, 150.0f / 255.0f);
  public static Color COLORFORE_ENEMY_CHARA = new Color(226.0f / 255.0f, 58.0f / 255.0f, 0 / 255.0f);

  public static Color COLOR_NORMAL_EFFECT = new Color(1, 1, 1);
  public static Color COLOR_RESIST_ENABLE = new Color(1.0f, 1.0f, 0.5f);
   
  #endregion
  #region "Buff Effect"
  public const string SITSUON = "Lost Sound";
  public const string SITSUON_JP = "失音";

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

  public const string EFFECT_RESIST_FIRE_UP = "ResistFireUp";
  public const string EFFECT_RESIST_ICE_UP = "ResistIceUp";
  public const string EFFECT_RESIST_LIGHT_UP = "ResistLightUp";
  public const string EFFECT_RESIST_SHADOW_UP = "ResistShadowUp";

  public const string EFFECT_POISON = "Poison";
  public const string EFFECT_POISON_JP = "猛毒";
  public const string EFFECT_SILENT = "Silent";
  public const string EFFECT_SILENT_JP = "沈黙";
  public const string EFFECT_BIND = "Bind";
  public const string EFFECT_BIND_JP = "束縛";
  public const string EFFECT_SLEEP = "Sleep";
  public const string EFFECT_SLEEP_JP = "睡眠";
  public const string EFFECT_STUN = "Stun";
  public const string EFFECT_STUN_JP = "スタン";
  public const string EFFECT_PARALYZE = "Paralyze";
  public const string EFFECT_PARALYZE_JP = "麻痺";
  public const string EFFECT_FREEZE = "Freeze";
  public const string EFFECT_FREEZE_JP = "凍結";
  public const string EFFECT_FEAR = "Fear";
  public const string EFFECT_FEAR_JP = "恐怖";
  public const string EFFECT_TEMPTATION = "Temptation";
  public const string EFFECT_TEMPTATION_JP = "誘惑";
  public const string EFFECT_SLOW = "Slow";
  public const string EFFECT_SLOW_JP = "鈍化";
  public const string EFFECT_DIZZY = "Dizzy";
  public const string EFFECT_DIZZY_JP = "眩暈";
  public const string EFFECT_SLIP = "Slip";
  public const string EFFECT_SLIP_JP = "出血";
  public const string EFFECT_CANNOT_RESURRECT = "Cannot Resurrect";
  public const string EFFECT_CANNOT_RESURRECT_JP = "蘇生不可";
  public const string EFFECT_NO_GAIN_LIFE = "No Gain Life";
  public const string EFFECT_NO_GAIN_LIFE_JP = "ライフ回復不可";

  public const string EFFECT_RESURRECT_JP = "復活";
  public const string EFFECT_NOT_EFFECT_JP = "効果なし";

  public const string EFFECT_FAIL_GAIN_LIFE = "No Gain Life";
  public const string EFFECT_FAIL_GAIN_LIFE_JP = "ライフ回復不可";

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
  public const string BUFF_RESIST_NO_GAIN_LIFE = "Resist NoGainLife";

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
  public const string EFFECT_RESIST_NO_GAIN_LIFE = "NoGainLife耐性";
  public const string EFFECT_REMOVE_NO_GAIN_LIFE = "NoGainLife除去";
  public const string EFEECT_IMMUNE_RESIST = "耐性無効！";

  public const string EFFECT_CANNOT_LIFEGAIN = "回復不可";
  public const string EFFECT_CANNOT_BE_COUNTERED = "カウンター不可！";
  public const string EFFECT_COUNTER = "カウンター！";
  public const string EFFECT_DAMAGE_IS_HALF = "ダメージ半減";
  public const string EFFECT_DAMAGE_IS_ZERO = "ダメージ０！";
  public const string EFFECT_DAMAGE_REFLECT = "ダメージ反射！";
  public const string EFFECT_STACK_END = "スタック破壊！";
  public const string EFFECT_NOT_DEAD = "決死　ライフ１！";
  public const string EFFECT_CANNOT_NOT_DEAD = "決死不可！";
  public const string EFFECT_LIFE_REGAIN = "生命復活";

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

  // アクションコマンド
  public const string BUFF_CIRCLE_IGNITE = "炎輪";
  public const string BUFF_WATER_PRESENCE = "水脈";
  public const string BUFF_VALKYRIE_BLADE = "聖剣";
  public const string BUFF_VALKYRIE_SCAR = "Valkyrie Scar";
  public const string BUFF_VALKYRIE_SCAR_JP = "聖痕";
  public const string BUFF_DARK_INTENSITY = "Dark Spirit";
  public const string BUFF_DARK_INTENSITY_JP = "暗黒精神";
  public const string BUFF_DARK_INTENSITY_UP ="Dark Spirit Up";
  public const string BUFF_DARK_INTENSITY_UP_JP = "暗黒精神増強";
  public const string BUFF_FUTURE_VISION_JP = "未来視";
  public const string BUFF_DETACHMENT_FAULT_JP = "無下";
  public const string BUFF_FAILED = "BUFF操作無効";
  public const string BUFF_STANCE_OF_THE_IAI_JP = "居合";
  public const string BUFF_ONE_IMMUNITY_JP = "唯一円";
  public const string BUFF_STANCE_OF_MUIN_JP = "無音";
  public const string BUFF_MINUS_IMMUNE = "負BUFF無効";
  public const string BUFF_POSITIVE_IMMUNE = "正BUFF無効";
  public const string BUFF_ETERNAL_CONCENTRATION_JP = "超集中";
  public const string BUFF_FOCUS_EYE = "Focus Eye";
  public const string BUFF_FOCUS_EYE_JP = "凝視";
  public const string BUFF_SIGIL_OF_THE_FAITH_JP = "信仰";
  public const string BUFF_ABSOLUTE_ZERO_JP = "絶対零度";
  public const string BUFF_CANNOT_MOVE_JP = "動作不能";
  public const string BUFF_CANNOT_GAIN_JP = "回復不能";
  public const string BUFF_DEATH_SCYTHE_JP = "死の鎌";
  public const string BUFF_PIERCING_ARROW_JP = "致命傷";
  public const string BUFF_STANCE_OF_THE_KOKOROE_JP = "心得";
  public const string BUFF_TIME_STOP = "時間停止";
  public const string BUFF_TRANSCENDENCE_REACHED = "超越";
  public const string BUFF_SUN_MARK_JP = "太陽印";
  public const string BUFF_HOLY_WISDOM_JP = "聖授";
  public const string BUFF_HOLY_FLARE_SWORD = "聖炎の刻印";
  public const string BUFF_RYOKUEI = "緑永";
  public const string BUFF_TIME_JUMP = "時間律の跳躍";
  public const string BUFF_SHADOW_BRINGER = "死滅";
  public const string BUFF_SPHERE_OF_GLORY = "栄光";
  public const string BUFF_AURORA_PUNISHMENT = "天罰";
  public const string BUFF_INNOCENT_CIRCLE = "無垢";
  public const string BUFF_ABSOLUTE_PERFECTION = "完成体";
  public const string BUFF_ASTRAL_GATE = "星門";
  public const string BUFF_DOUBLE_STANCE = "双極";
  public const string BUFF_CHAOTIC_SCHEMA = "分身";
  public const string BUFF_OATH_OF_SEFINE = "誓約";
  public const string BUFF_OATH_OF_GOD = "神域";
  public const string BUFF_SPACETIME_INFLUENCE = "時空干渉";
  public const string BUFF_LIFE_POINT = "意志";

  public const string BUFF_GOD_WILL = "God Will";
  public const string BUFF_GOD_WILL_JP = "神の意志";
  public const string BUFF_GOD_CONTRACT = "God Contract";
  public const string BUFF_GOD_CONTRACT_JP = "神の契約";

  // モンスター系
  public const string BUFF_LIGHTNING_OUTBURST = "Lightning Outburst";
  public const string BUFF_BLACK_SPORE = "BlackSpore";
  public const string BUFF_VERDANT_VOICE = "VerdantVoice";
  public const string BUFF_DEVIL_EMBLEM = "DevilEmblem";

  // BUFF追加向けファイル名
  public const string FLASH_BLAZE_BUFF = @"FlashBlaze_Buff"; // 炎追加効果
  public const string AFTER_REVIVE_HALF = @"AfterReviveHalf";
  public const string FIRE_DAMAGE_2 = @"FireDamage2";
  public const string BLACK_MAGIC = @"BlackMagic";
  public const string CHAOS_DESPERATE = @"ChaosDesperate";
  public const string ICHINARU_HOMURA = @"IchinaruHomura";
  public const string ABYSS_FIRE = @"AbyssFire";
  public const string LIGHT_AND_SHADOW = @"LightAndShadow";
  public const string ETERNAL_DROPLET = @"EternalDroplet";
  public const string AUSTERITY_MATRIX_OMEGA = @"AusterityMatrixOmega";
  public const string VOICE_OF_ABYSS = @"VoiceOfAbyss";
  public const string ABYSS_WILL = @"AbyssWill";
  public const string THE_ABYSS_WALL = @"TheAbyssWall";
  // レギィンアーゼマナコスト
  public const int COST_ICHINARU_HOMURA = 35000;
  public const int COST_ABYSS_FIRE = 32000;
  public const int COST_LIGHT_AND_SHADOW = 60000;
  public const int COST_ETERNAL_DROPLET = 48000;
  public const int COST_AUSTERITY_MATRIX_OMEGA = 95000;
  public const int COST_VOICE_OF_ABYSS = 87000;
  public const int COST_ABYSS_WILL = 25000;
  public const int COST_THE_ABYSS_WALL = 100000;
  // レギィンアーゼ、各種技による効果
  public const string BUFF_ICHINARU_HOMURA = @"毎ターン、焔ダメージ";
  public const string BUFF_ABYSS_FIRE = @"物理攻撃か魔法攻撃を行う度に、アビスダメージ";
  public const string BUFF_LIGHT_AND_SHADOW = @"物理／魔法ダメージ０";
  public const string BUFF_ETERNAL_DROPLET = @"ライフ／マナ回復";
  public const string BUFF_AUSTERITY_MATRIX_OMEGA = @"プラスBUFF無効";
  public const string BUFF_VOICE_OF_ABYSS = @"ライフ回復０";
  public const string BUFF_ABYSS_WILL = @"焔／アビスダメージ上昇";
  public const string BUFF_THE_ABYSS_WALL = @"ダメージ吸収バリア";

  public const string EFFECT_GAIN_INSTANT = "インスタントゲージ上昇";     

  #endregion
  #region "Timer"
  public const int BATTLEEND_AUTOEXIT = 200;
  public const int STACKCOMMAND_NORMAL_TIMER = 150;
  public const int STACKCOMMAND_SUDDEN_TIMER = 50;
  public const int STACKCOMMAND_IMMEDIATE_TIMER = 1;
  #endregion
  #endregion

  #region "Environment"
  #region "Program Data"
  public static string BaseMapFolder = @"\Map\";
  public static string BaseSoundFolder = @"Sounds/";
  public static string BaseSaveFolder = Environment.CurrentDirectory + @"\Save\";
  public static string BaseMusicFolder = @"BGM\";
  public const string TF_SAVE = @"TeamFoundationSave.xml";
  public const string AR_FILE = @"AkashicRecord.xml";
  public const string CONF_FILE = @"GameSetting.xml";
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
  public const string MAPFILE_ESMILIA_GRASSFIELD = "MapData_EsmiliaGrassField.txt";
  public const string MAPFILE_ARTHARIUM = "MapData_Artharium.txt";
  public const string MAPFILE_GORATRUM = "MapData_Goratrum.txt";
  public const string MAPFILE_GORATRUM_2 = "MapData_Goratrum_2.txt";
  public const string MAPFILE_VELGUS = "MapData_Velgus.txt";
  public const string MAPFILE_VELGUS_2 = "MapData_Velgus_2.txt";
  public const string MAPFILE_VELGUS_3 = "MapData_Velgus_3.txt";
  public const string MAPFILE_VELGUS_4 = "MapData_Velgus_4.txt";
  public const string MAPFILE_OHRAN_TOWER = "MapData_OhranTower.txt";
  public const string MAPFILE_MYSTIC_FOREST = "MapData_MysticForest.txt";
  public const string MAPFILE_GATE_OF_DHAL = "MapData_GateOfDhal.txt";
  public const string MAPFILE_SARITAN = "MapData_Saritan.txt";
  public const string MAPFILE_SNOWTREE_LATA = "MapData_SnowTreeLata.txt";
  public const string MAPFILE_DISKEL = "MapData_Diskel.txt";
  public const string MAPFILE_GANRO = "MapData_Ganro.txt";
  public const string MAPFILE_LOSLON = "MapData_Loslon.txt";
  public const string MAPFILE_EDELGARZEN = "MapData_EdelGarzen.txt";
  public const string MAPFILE_EDELGARZEN_2 = "MapData_EdelGarzen_2.txt";
  public const string MAPFILE_EDELGARZEN_3 = "MapData_EdelGarzen_3.txt";
  public const string MAPFILE_EDELGARZEN_4 = "MapData_EdelGarzen_4.txt";
  public const string MAPFILE_WOSM = "MapData_Wosm.txt";
  public const string MAPFILE_WOSM_2 = "MapData_Wosm_2.txt";
  public const string MAPFILE_GENESISGATE = "MapData_GenesisGate.txt";

  public const int MAPSIZE_X_ESMILIA_GRASSFIELD = 40;
  public const int MAPSIZE_Z_ESMILIA_GRASSFIELD = 20;

  public const int MAPSIZE_X_GORATRUM = 40;
  public const int MAPSIZE_Z_GORATRUM = 20;

  public const int MAPSIZE_X_MYSTICFOREST = 50;
  public const int MAPSIZE_Z_MYSTICFOREST = 30;

  public const int MAPSIZE_X_VELGUS_SEATEMPLE = 50;
  public const int MAPSIZE_Z_VELGUS_SEATEMPLE = 30;

  public const int MAPSIZE_X_VELGUS_SEATEMPLE_2 = 50;
  public const int MAPSIZE_Z_VELGUS_SEATEMPLE_2 = 30;

  public const int MAPSIZE_X_VELGUS_SEATEMPLE_3 = 50;
  public const int MAPSIZE_Z_VELGUS_SEATEMPLE_3 = 30;

  public const int MAPSIZE_X_VELGUS_SEATEMPLE_4 = 50;
  public const int MAPSIZE_Z_VELGUS_SEATEMPLE_4 = 30;

  public const int MAPSIZE_X_EDELGARZEN_1 = 61;
  public const int MAPSIZE_Z_EDELGARZEN_1 = 41;

  public const int MAPSIZE_X_EDELGARZEN_2 = 61;
  public const int MAPSIZE_Z_EDELGARZEN_2 = 41;

  public const int MAPSIZE_X_EDELGARZEN_3 = 61;
  public const int MAPSIZE_Z_EDELGARZEN_3 = 41;

  public const int MAPSIZE_X_EDELGARZEN_4 = 61;
  public const int MAPSIZE_Z_EDELGARZEN_4 = 41;

  #endregion
  #region "Sound File"
  public const string SOUND_FIREBALL = @"FireBall";
  public const string SOUND_FLAMEBLADE = @"FlameBlade";
  public const string SOUND_METEOR_BULLET = @"MeteorBullet";
  public const string SOUND_VOLCANIC_BLAZE = @"VolcanicBlaze";
  public const string SOUND_FLAME_STRIKE = @"FlameStrike";
  public const string SOUND_CIRCLE_OF_THE_IGNITE = @"CircleofTheIgnite";
  public const string SOUND_LAVA_ANNIHILATION = @"LavaAnnihilation";

  public const string SOUND_ICENEEDLE = @"IceNeedle";
  public const string SOUND_PURE_PURIFICATION = @"PurePurification";
  public const string SOUND_BLUE_BULLET = @"BlueBullet";
  public const string SOUND_FREEZING_CUBE = @"FreezingCube";
  public const string SOUND_FROST_LANCE = @"FrostLance";
  public const string SOUND_WATER_PRESENCE = @"WaterPresence";
  public const string SOUND_ABSOLUTE_ZERO = @"AbsoluteZero";

  public const string SOUND_FRESH_HEAL = @"FreshHeal";
  public const string SOUND_DIVINE_CIRCLE = @"DivineCircle";
  public const string SOUND_HOLY_BREATH = @"HolyBreath";
  public const string SOUND_ANGELIC_ECHO = @"AngelicEcho";
  public const string SOUND_SHINING_HEAL = @"ShiningHeal";
  public const string SOUND_VALKYRIE_BLADE = @"ValkyrieBlade";
  public const string SOUND_RESURRECTION = @"Resurrection";
  
  public const string SOUND_SHADOW_BLAST = @"ShadowBlast";
  public const string SOUND_BLOOD_SIGN = @"BloodSign";
  public const string SOUND_BLACK_CONTRACT = @"BlackContract";
  public const string SOUND_CURSED_EVANGILE = @"CursedEvangile";
  public const string SOUND_CIRCLE_OF_THE_DESPAIR = @"CircleoftheDespair";
  public const string SOUND_THE_DARK_INTENSITY = @"TheDarkIntensity";
  public const string SOUND_DEATH_SCYTHE = @"DeathScythe";
  
  public const string SOUND_ORACLE_COMMAND = @"OracleCommand";
  public const string SOUND_FORTUNE_SPIRIT = @"FortuneSpirit";
  public const string SOUND_WORD_OF_POWER = @"WordOfPower";
  public const string SOUND_GALE_WIND = @"GaleWind";
  public const string SOUND_SEVENTH_PRINCIPLE = @"SeventhPrinciple";
  public const string SOUND_FUTURE_VISION = @"FutureVision";
  public const string SOUND_GENESIS = @"Genesis";

  public const string SOUND_ENERGY_BOLT = @"EnergyBolt";
  public const string SOUND_FLASH_COUNTER = @"FlashCounter";
  public const string SOUND_SIGIL_OF_THE_PENDING = @"SigilOfThePending";
  public const string SOUND_PHANTOM_OBORO = @"PhantomOboro";
  public const string SOUND_COUNTER_DISALLOW = @"CounterDisallow";
  public const string SOUND_DETACHMENT_FAULT = @"DetachmentFault";
  public const string SOUND_TIME_STOP = @"TimeStop";

  public const string SOUND_STRAIGHT_SMASH = @"StraightSmash";
  public const string SOUND_STANCE_OF_THE_BLADE = @"StanceoftheBlade";
  public const string SOUND_DOUBLE_SLASH = @"DoubleSlash";
  public const string SOUND_IRON_BUSTER = @"IronBuster";
  public const string SOUND_RAGING_STORM = @"RagingStorm";
  public const string SOUND_STANCE_OF_IAI = @"StanceofTheIai";
  public const string SOUND_KINETIC_SMASH = @"KineticSmash";

  public const string SOUND_SHIElD_BASH = @"ShieldBash";
  public const string SOUND_STANCE_OF_THE_GUARD = @"StanceoftheGuard";
  public const string SOUND_CONCUSSIVE_HIT = @"ConcussiveHit";
  public const string SOUND_DOMINATION_FIELD = @"DominationField";
  public const string SOUND_HARDEST_PARRY = @"HardestParry";
  public const string SOUND_ONE_IMMUNITY = @"OneImmunity";
  public const string SOUND_CATASTROPHE = @"Catastrophe";

  public const string SOUND_LEG_STRIKE = @"LegStrike";
  public const string SOUND_SPEED_STEP = @"SpeedStep";
  public const string SOUND_BONE_CRUSH = @"BoneCrush";
  public const string SOUND_DEADLY_DRIVE = @"DeadlyDrive";
  public const string SOUND_UNINTENTIONAL_HIT = @"UnintentionalHit";
  public const string SOUND_STANCE_OF_MUIN = @"StanceOfMuin";
  // CarnageRush
  public const string SOUND_HIT_01 = @"Hit_01";
  public const string SOUND_HIT_02 = @"Hit_02";

  public const string SOUND_HUNTER_SHOT = @"HunterShot";
  public const string SOUND_MULTIPLE_SHOT = @"MultipleShot";
  public const string SOUND_EYE_OF_THE_ISSHIN = @"EyeoftheIsshin";
  public const string SOUND_PENETRATION_ARROW = @"PenetrationArrow";
  public const string SOUND_PRECISION_STRIKE = @"PrecisionStrike";
  public const string SOUND_ETERNAL_CONCENTRATION = @"EternalConcentration";
  public const string SOUND_PIERCING_ARROW = @"PiercingArrow";
  
  public const string SOUND_TRUE_SIGHT = @"TrueSight";
  public const string SOUND_LEYLINE_SCHEMA = @"LeylineSchema";
  public const string SOUND_VOICE_OF_THE_VIGOR = @"VoiceoftheVigor";
  public const string SOUND_WILL_AWAKENING = @"WillAwakening";
  public const string SOUND_EVERFLOW_MIND = @"EverflowMind";
  public const string SOUND_SIGIL_OF_THE_FAITH = @"SigilofTheFaith";
  public const string SOUND_STANCE_OF_KOKOROE = @"StanceOfKokoroe";
  
  public const string SOUND_DISPEL_MAGIC = @"DispelMagic";
  public const string SOUND_SPIRITUAL_REST = @"SpiritualRest";
  public const string SOUND_UNSEEN_AID = @"UnseenAid";
  public const string SOUND_CIRCLE_OF_SERENITY = @"CircleofSerenity";
  public const string SOUND_INNER_INSPIRATION = @"InnerInspiration";
  public const string SOUND_ZERO_IMMUNITY = @"ZeroImmunity";
  public const string SOUND_TRANSCENDENCE_REACHED = @"TranscendenceReached";
  
  public const string SOUND_ENEMY_ATTACK1 = @"EnemyAttack1";
  public const string SOUND_SWORD_SLASH1 = @"SwordSlash1";

  //public const string SOUND_CELESTIAL_NOVA = @"CelestialNova";
  public const string SOUND_MAGIC_ATTACK = @"MagicAttack";
  //public const string SOUND_KINETIC_SMASH = @"KineticSmash";
  public const string SOUND_ARCANE_DESTRUCTION = @"KineticSmash";
  public const string SOUND_CRUSHING_BLOW = @"CrushingBlow";
  public const string SOUND_SOUL_INFINITY = @"Catastrophe";
  //public const string SOUND_CATASTROPHE = @"Catastrophe";
  public const string SOUND_OBORO_IMPACT = @"Catastrophe";
  public const string SOUND_ABYSS_EYE = @"WhiteOut";
  public const string SOUND_DARK_BLAST = @"DarkBlast";
  public const string SOUND_DOOM_BLADE = @"DarkBlast";
  public const string SOUND_PHANTASMAL_WIND = @"HeatBoost";
  public const string SOUND_PARADOX_IMAGE = @"RiseOfImage";
  public const string SOUND_PIERCING_FLAME = @"FireBall";
  public const string SOUND_DEMONIC_IGNITE = @"FireBall";
  public const string SOUND_VORTEX_FIELD = @"DispelMagic";
  //public const string SOUND_GLORY = @"Glory";
  public const string SOUND_STATIC_BARRIER = @"Glory";
  public const string SOUND_NOURISH_SENSE = @"WordOfLife";
  public const string SOUND_LIFE_TAP = @"LifeTap";
  public const string SOUND_SYUTYU_DANZETSU = @"NothingOfNothingness";
  public const string SOUND_JUNKAN_SEIYAKU = @"NothingOfNothingness";
  public const string SOUND_ORA_ORA_ORAAA = @"Catastrophe";
  public const string SOUND_SHINZITSU_HAKAI = @"Catastrophe";
  public const string SOUND_HYMN_CONTRACT = @"Resurrection";
  public const string SOUND_ENDLESS_ANTHEM = @"Resurrection";
  //public const string SOUND_FLAME_STRIKE = @"FlameStrike";
  public const string SOUND_SIGIL_OF_HOMURA = @"FlameStrike";
  public const string SOUND_AUSTERITY_MATRIX = @"OneImmunity";
  public const string SOUND_RED_DRAGON_WILL = @"StraightSmash";
  public const string SOUND_BLUE_DRAGON_WILL = @"StraightSmash";
  public const string SOUND_ECLIPSE_END = @"BlackContract";
  public const string SOUND_SIN_FORTUNE = @"BlackContract";
  public const string SOUND_BLACK_FLARE = @"BlackContract";
  public const string SOUND_DEATH_DENY = @"BlackContract";
  public const string SOUND_DEATH = @"BlackContract";
  //public const string SOUND_RISINGKNUCKLE = @"RisingKnuckle";
  //public const string SOUND_DAMNATION = @"Damnation";
  public const string SOUND_CHOSEN_SACRIFY = @"Damnation";
  //public const string SOUND_ABSOLUTE_ZERO = @"AbsoluteZero";
  //public const string SOUND_LAVA_ANNIHILATION = @"LavaAnnihilation";
  public const string SOUND_KOKUEN_BLUE_EXPLODE = @"LavaAnnihilation";
  public const string SOUND_VOLCANICWAVE = @"VolcanicWave";
  public const string SOUND_MEGID_BLAZE = @"VolcanicWave";
  //public const string SOUND_FROZENLANCE = @"FrozenLance";
  public const string SOUND_SHARPNEL_NEEDLE = @"FrozenLance";
  //public const string SOUND_WHITEOUT = @"Whiteout";
  //public const string SOUND_TIME_STOP = @"TimeStop";
  public const string SOUND_WARP_GATE = @"TimeStop";
  //public const string SOUND_GENESIS = @"Genesis";
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
  //public const string SOUND_26 = @"GaleWind";
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
  //public const string SOUND_37 = @"InnerInspiration";
  public const string SOUND_38 = @"KineticSmash";
  public const string SOUND_39 = @"LavaAnnihilation";
  public const string SOUND_40 = @"LifeTap";
  public const string SOUND_41 = @"LvUp";
  public const string SOUND_42 = @"LvupFeltus";
  public const string SOUND_43 = @"MagicAttack";
  public const string SOUND_44 = @"MirrorImage";
  public const string SOUND_45 = @"NothingOfNothingness";
  //public const string SOUND_46 = @"OneImmunity";
  public const string SOUND_47 = @"PainfulInsanity";
  public const string SOUND_48 = @"PromisedKnowledge";
  public const string SOUND_49 = @"Protection";
  public const string SOUND_50 = @"PutiFireBall";
  //public const string SOUND_52 = @"Resurrection";
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
  //public const string SOUND_63 = @"Tranquility";
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
  public const string SCENE_BATTLE_ENEMY = @"BattleEnemy";
  public const string SCENE_HOME_TOWN = @"HomeTown";
  public const string SCENE_HELP_BOOK = @"HelpBook";
  public const string SCENE_PARTY_MENU = @"PartyMenu";
  public const string SCENE_TRUTH_ANSWER = @"TruthAnswer";
  public const string SCENE_ENDING = @"Ending";
  #endregion
  #region "Fixed Value"
  public const int INFINITY = 9999999;
  public const int MAX_BACKPACK_SIZE = 20;
  public const int MAX_ITEM_STACK_SIZE = 10;
  public const int MAX_TEAM_MEMBER = 3;
  public const int MAX_ENEMY_MEMBER = 3;
  public const int MAX_INSTANT_NUM = 9;
  public const int BASIC_SKILLPOINT = 100;
  public const int PARAMETER_MAX = 9999;
  public const int ESSENCE_REQUIRE_LV = 5;
  public static int[] ESSENCE_TREE_REQUIRE_LIST = { 5, 10, 15, 20, 30, 40, 50 };
  #endregion

  public static int CHARACTER_MAX_LEVEL1 = 10; // エスミリア草原区域まで
  public static int CHARACTER_MAX_LEVEL2 = 20; // ゴラトラム洞窟まで
  public static int CHARACTER_MAX_LEVEL3 = 30; // 神秘の森まで
  public static int CHARACTER_MAX_LEVEL4 = 40; // オーランの塔まで
  public static int CHARACTER_MAX_LEVEL5 = 50; // ヴェルガスの海底神殿まで
  public static int CHARACTER_MAX_LEVEL6 = 60; // エデルガイゼン城まで
  public static int CHARACTER_MAX_LEVEL7 = 70; // 離島ウォズムまで
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
  //  "(Optional) ゴラトラム洞窟の探索",
  //  "ファージル宮殿への報告（ObsidianStone）",
  //  "キルクード山道を抜けて",
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
  //  "里の長老からはゴラトラム洞窟については決して赴いては行けないと言われている。しかし、存在「ツァルマン」からは「挑む姿勢と、遂げる意志」の助言をもらっている。ゴラトラム洞窟へは赴くべきか・・・",
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
  public const string QUEST_DESC_1 = "ファージル宮殿へと向かい、遠征許可証を入手しよう。ファージル宮殿へ行くためにはエスミリア草原区域を抜けて行く必要がある。身支度が整い次第、出発しよう。";

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
  public const string QUEST_DESC_11_2 = "オーランの塔、最上階へと到達し展望台から本大陸の視察を行い、大陸の情勢について様々な情報を入手した。アインは国王にこの内容を伝えるべく、ファージル宮殿へと戻り、謁見の間にて国王エルミと対談する。";

  public const string QUEST_TITLE_20 = "塔最上階からの気配";
  public const string QUEST_DESC_20 = "オーランの塔最上階へと上る階段にて、流れ込んでくる異質な風をパーティ全員は感じ取った。この先、何かが待ち受けている事だけは間違いない。準備を万全にして挑んだ方が良いだろう。";

  public const string QUEST_TITLE_21 = "国王エルミからの依頼３";
  public const string QUEST_DESC_21 = "オーランの塔から見えた内容について国王へ報告を行った。国王エルミからは次の指令としてムーンフォーダー方面にあるパルメティシア神殿を目指すよう依頼を受けた。準備を整えたアイン達は、パルメティシア神殿へと向かう。";
  public const string QUEST_DESC_21_2 = "アーケンダイン街に到着したアイン達は、早速聞き込みを開始する事とした。アーケンダイン街を一通り回り、街の人と会話しよう。";

  public const string QUEST_TITLE_31 = "教皇ツヴェルドーゼからの依頼";
  public const string QUEST_DESC_31 = "パルメティシア神殿の教皇からヴェルガスの海底神殿に赴き、【天の名】を獲得してくる事を依頼された。アインは意を決してヴェルガス海底神殿へと赴く。ヴェルガス海底神殿で【天の名】を授かる事でアインはこれまで感じてきた違和感の正体について一定の理解を得る事が出来る。そう信じて歩を進める。";

  public const string QUEST_TITLE_41 = "教皇ツヴェルドーゼからの依頼２";
  public const string QUEST_DESC_41 = "【天の名】を授かったアインは、教皇ツヴェルドーゼとの謁見を経て、ヴィンスガルデ王国のエデルガイゼン城に向かうよう依頼された。アインはこれまでのObsidianStoneとの接触を通じて、一つの結論に辿り着こうとしている。エデルガイゼン城で待ち受ける事象を全て受け止める覚悟で、アインは足を進め始めた。";

  public const string QUEST_TITLE_22 = "隠されしは【神秘の森】";
  public const string QUEST_DESC_22 = "アーケンダイン街の中央噴水広場を行き交う町の人から、ここアーケンダイン街とツァルマンの里は過去において、交易ルートが存在していた事が分かった。交易ルートはアイン達が通ってきた道のりがそのまま交易路として使われていたようだ。その当時、ツァルマンの里の奥には不可侵なる領域【神秘の森】が存在していたという噂が流れていたという。今もその【神秘の森】があるか定かではないが、ツァルマンの里にもう一度訪れる事で判明するかもしれない。ツァルマンの里へ赴き、長老ともう一度対話を行おう。";
  public const string QUEST_DESC_22_2 = "ツァルマンの里にいる長老に【神秘の森】を問い合わせた結果、聖なる場所として管理されており、アイン達は入る事を許してもらう事が出来なかった。しかし長老は、アデル・ブリガンディという者にお使いを指示し、そのお使いに同行する形で認めてくれたようだ。アデル・ブリガンディと共に【神秘の森】を探索してみよう。きっと何か見つかるはずだ。";

  public const string QUEST_TITLE_23 = "赤き星はマーブルスター";
  public const string QUEST_DESC_23 = "アーケンダイン街の「占いの館：アミンダ」にて、赤い星について聞いた所、アインは占い師からマーブル・スターを提供される形となった。このアイテムが何のために使用されるのかは定かではないが、アインはひとまずこのアイテムについては【サリタンの地】を訪れる事を勧められた。【サリタンの地】を探し、このアイテムについて情報を入手しよう。";

  public const string DECISION_ESCAPE_FROM_DUNGEON = "遠見の青水晶（ダンジョンからの帰還）";
  public const string DECISION_TRANSFER_TOWN = "遠見の青水晶（街へのワープ）";
  public const string DECISION_ARTHARIUM_CLIFF = "アーサリウム工場跡地：崖の下へ";
  public const string DECISION_ARTHARIUM_CLIFF_END = "アーサリウム工場跡地：元の通路へ";
  public const string DECISION_ARTHARIUM_CRASH_DOOR = "アーサリウム工場跡地：扉を蹴破れ！";
  public const string DECISION_ARTHARIUM_CRASH_DOOR2 = "アーサリウム工場跡地：扉を蹴破れ！（２）";
  public const string DECISION_PARTY_JOIN_SELMOI_RO = "セルモイ・ロウを仲間に引き入れる";

  public const string CHOICE_VELGUS_JUDGE_1 = "ヴェルガス海底神殿：心の解【１】";
  public const string CHOICE_VELGUS_JUDGE_2 = "ヴェルガス海底神殿：心の解【２】";
  public const string CHOICE_VELGUS_JUDGE_3 = "ヴェルガス海底神殿：心の解【３】";
  public const string CHOICE_VELGUS_JUDGE_4 = "ヴェルガス海底神殿：心の解【４】";
  public const string CHOICE_VELGUS_JUDGE_5 = "ヴェルガス海底神殿：心の解【５】";
  public const string CHOICE_VELGUS_JUDGE_6 = "ヴェルガス海底神殿：心の解【６】";
  #endregion
  #region "Area Description"
  public const string AREA_INFO_ANSHET = "アンシェットの町はファージル宮殿から南方面への川沿いを下った所でひっそりと栄えている町である。行商人の行き来は少ないが、町全体としては安定しており、人々は穏やかな生活を送っている。";
  public const string AREA_INFO_ESMILIA_GRASSFIELD = "エスミリア草原区域にある獣道。ファージル宮殿とアンシェットの町はこの通路で行き来が行われる。モンスターが出現するが危険度【高】のモンスターが出現する事はなく、道なりに進めば、危険に見舞われる事は少ない。";
  public const string AREA_INFO_FAZIL_CASTLE = "ファージル区域全土を統治する国王エルミ・ジョルジュが住まうファージル宮殿。ファージル宮殿の裏には数々のワープゲートが設置されており、国王であるエルミ・ジョルジュ、王妃ファラ・フローレ、魔道学院の長シニキア・カールハンツ、正義の暴君オル・ランディス、存在不可視のヴェルゼ・アーティが日々各エリアの状況把握に努めている。ファージル全土で犯罪発生率が低く、一般市民が平和に暮らせているのは彼らの加護があるからに他ならない。";
  public const string AREA_INFO_GORATRUM_CAVE = "人々を魅了する鍾乳洞は、観光地として多くの旅行者をひきつけた場所である。今では鍾乳洞は僅かしか残っておらず、地の奥底からモンスターが出没するようになっているため、一般の人々がここを訪れる事は無い。探索に行くのであれば、入念な準備を怠らない事だ。";
  public const string AREA_INFO_COTUHSYE = "この港町には様々な職業の者が行き来している。国王エルミは本エリアを交流の場の一つとして制定しており、出入りについて制限は設けていないため交易が盛んである。だが、現在は船の出航制限がかかっており、ここからヴィンスガルデ王国行きの船は出ていない。";
  public const string AREA_INFO_MYSTIC_FOREST = "立ち入る人々を深淵なる濃霧へと誘う【神秘の森】。その場の見通しの悪さに加え、モンスターからの襲撃が繰り返し行われるため、方向感覚を失い、そのまま行方不明となる者が後を絶えない。進むためには入念なる準備が必要となるだろう。";
  public const string AREA_INFO_OHRAN_TOWER = "塔の頂上からは大陸全土を見渡す事ができる。【オーランの塔】が建設された時期は依然として不明であるが、少なくともファージル王国が栄えるよりも前から存在している。今では観光として訪れる者はおらず、モンスターが蔓延る場所と化しており、戦闘経験を積んだ者達が腕試しとして挑む場所に指定されている。塔の頂きに到達したければ、一定の力量、状況判断を持って挑む必要があるだろう。";
  public const string AREA_INFO_PARMETYSIA = "ムーンフォーダー方面を統括するパルメティシア神殿。その方面は雪原地域であり、ファージルエリアからは特別な事情が無い限り行くことはないとされている。また、そのエリア一帯はムーンフォーダー教団の一員達が定期的な監視を行っており、迂闊に出歩く事も許されていない。";
  public const string AREA_INFO_VELGUS_SEA_TEMPLE = "遥か古代から存在する海底神殿ヴェルガス。その名は教団がこの神殿を発見した当時の人物「ヴェルセリウス・ガーランド・アルトリウス」の名にちなんで命名された。この世に生まれし生命は等しく神から寵愛を受ける事が約束されており、それは「天の名」という形で示される。海底神殿には幾つもの紋様が刻まれており、紋様が示す意図はムーンフォーダー教団の力を持ってしても、未だ解明されていない。「天の名」が授けられると言われる海底神殿ではあるが、実質は魔物の巣窟となっている。海底神殿へ挑むには相当の力量が必要となるだろう。";
  public const string AREA_INFO_EDELGARZEN = "ヴィンスガルデ王国に悠然とそびえ立つエデルガイゼン城。他国からの侵略から守る事、他地域への監視を強化するため、キルクード山脈地帯の頂上にその城は建設された。難攻不落であるため、この城へ攻めこむ者は存在せず、圧倒的な存在感を放っている。城に向かう際は入念な準備と実行する力だけでは足りない。一定の器と、そして真の気質が必要となるだろう。";
  #endregion
  #endregion

  #region "Food Menu"
  // アンシェット街
  public const string FOOD_BALANCE_SET = "バランス定食";
  public const string FOOD_LARGE_GOHAN_SET = "山盛りごはんセット";
  public const string FOOD_TSIKARA_UDON = "タップリ 力うどん";
  public const string FOOD_ZUNOU_FLY_SET = "頭脳フライ定食";
  public const string FOOD_SPEED_SOBA = "おかわり卵蕎麦";

  // ファージル宮殿
  public const string FOOD_KATUCARRY = @"激辛カツカレー定食";
  public const string FOOD_OLIVE_AND_ONION = @"オリーブパンとオニオンスープ";
  public const string FOOD_INAGO_AND_TAMAGO = @"イナゴの佃煮と卵和え定食";
  public const string FOOD_USAGI = @"ウサギ肉のシチュー";
  public const string FOOD_SANMA = @"サンマ定食（煮物添え）";

  // 港町コチューシェ
  public const string FOOD_FISH_GURATAN = @"フィッシュ・グラタン";
  public const string FOOD_SEA_TENPURA = @"海鮮サクサク天プラ";
  public const string FOOD_TRUTH_YAMINABE_1 = @"真実の闇鍋（パート１）";
  public const string FOOD_OSAKANA_ZINGISKAN = @"お魚ジンギスカン";
  public const string FOOD_RED_HOT_SPAGHETTI = @"レッドホット・スパゲッティ";

  // ツァルマンの里
  public const string FOOD_TOBIUSAGI_ROAST = "トビウサギのロースト定食";
  public const string FOOD_WATARI_KAMONABE = "渡り鴨鍋";
  public const string FOOD_SYOI_KINOKO_SUGATAYAKI = "背負いキノコの姿焼";
  public const string FOOD_NEGIYAKI_DON = "ネギ焼き丼";
  public const string FOOD_NANAIRO_BUNA_NITSUKE = "七色ブナの煮つけ";

  // パルメティシア神殿
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
  public static string DESC_03 = DESC_03_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋３\r\n  技    \r\n  知    \r\n  体    \r\n  心＋１";
  public static string DESC_04 = DESC_04_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力    \r\n  技    \r\n  知＋３\r\n  体＋１\r\n  心＋１";
  public static string DESC_05 = DESC_05_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋２\r\n  技＋３\r\n  知    \r\n  体    \r\n  心＋１";

  public static string DESC_11 = DESC_11_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　＋５\r\n  技　　　\r\n  知　　　\r\n  体　＋５\r\n  心　　　";
  public static string DESC_12 = DESC_12_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　\r\n  技　　　\r\n  知　　　\r\n  体　＋５\r\n  心　＋５";
  public static string DESC_13 = DESC_13_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　\r\n  技　　　\r\n  知　＋８\r\n  体　　　\r\n  心　＋５";
  public static string DESC_14 = DESC_14_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋１０\r\n  技　＋５\r\n  知　　　\r\n  体　　　\r\n  心　　　";
  public static string DESC_15 = DESC_15_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　\r\n  技＋１２\r\n  知　＋５\r\n  体　　　\r\n  心　　　";

  public static string DESC_21 = DESC_21_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　\r\n  技＋１２\r\n  知　＋８\r\n  体　＋５\r\n  心　　　";
  public static string DESC_22 = DESC_22_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　＋５\r\n  技　　　\r\n  知＋１２\r\n  体　＋８\r\n  心　　　";
  public static string DESC_23 = DESC_23_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　\r\n  技　　　\r\n  知　＋５\r\n  体＋１７\r\n  心　＋８";
  public static string DESC_24 = DESC_24_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋１２\r\n  技＋１８\r\n  知　　　\r\n  体　　　\r\n  心　＋５";
  public static string DESC_25 = DESC_25_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋２３\r\n  技　＋５\r\n  知　　　\r\n  体　　　\r\n  心＋１２";

  public static string DESC_31 = DESC_31_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　\r\n  技＋３０\r\n  知　　　\r\n  体＋１０\r\n  心＋１０";
  public static string DESC_32 = DESC_32_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋３０\r\n  技　　　\r\n  知　　　\r\n  体＋１０\r\n  心＋１０";
  public static string DESC_33 = DESC_33_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　\r\n  技　　　\r\n  知＋３５\r\n  体＋１５\r\n  心＋２０";
  public static string DESC_34 = DESC_34_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　\r\n  技　　　\r\n  知　　　\r\n  体＋５０\r\n  心＋３０";
  public static string DESC_35 = DESC_35_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋２０\r\n  技＋２０\r\n  知＋２０\r\n  体＋２０\r\n  心＋２０";

  public static string DESC_51 = DESC_51_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　＋６０\r\n  技　　　　\r\n  知　＋８０\r\n  体　　　　\r\n  心　＋６０";
  public static string DESC_52 = DESC_52_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　　\r\n  技　＋８０\r\n  知　＋６０\r\n  体　＋６０\r\n  心　　　　";
  public static string DESC_53 = DESC_53_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　＋７０\r\n  技　　　　\r\n  知　　　　\r\n  体＋１２０\r\n  心　＋６０";
  public static string DESC_54 = DESC_54_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　＋６０\r\n  技　＋６０\r\n  知　＋６０\r\n  体　＋６０\r\n  心　＋６０";
  public static string DESC_55 = DESC_55_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　　\r\n  技　　　　\r\n  知＋２５０\r\n  体　＋９０\r\n  心　＋６０";

  public static string DESC_61 = DESC_61_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　　\r\n  技＋２５０\r\n  知＋２５０\r\n  体　　　　\r\n  心＋２５０";
  public static string DESC_62 = DESC_62_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋２５０\r\n  技　　　　\r\n  知　　　　\r\n  体＋２５０\r\n  心＋２５０";
  public static string DESC_63 = DESC_63_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋２５０\r\n  知　　　　\r\n  知＋５００\r\n  体＋２５０\r\n　心　　　　";
  public static string DESC_64 = DESC_64_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力　　　　\r\n  技＋２５０\r\n  知＋２５０\r\n  体＋５００\r\n  心　　　　";
  public static string DESC_65 = DESC_65_MINI + "\r\n\r\n食べた次の日は、以下の効果。\r\n  力＋５００\r\n  技＋２５０\r\n  知　　　　\r\n  体　　　　\r\n  心＋５００";

  public const string DESC_01_MINI = "体調を良くする事を意識して作られた定食。カロリーバランスが取れており、近隣の住人が良く食べに来る味付けとなっている。";
  public const string DESC_02_MINI = "腹ごしらえに最適なごはんセット。当然のごとく山盛りとなったごはんに加え、スタミナが十分につくおかずも多く盛られており、一部の客に人気がある";
  public const string DESC_03_MINI = "力を付けたければ、まずはこのうどんセットで決まり。特別な理由はないが、これを食べた次の日、非常にやる気が出ると好評。";
  public const string DESC_04_MINI = "ウサギの肉を太陽の葉で包み込み、じっくりとフライ仕立てにした。味は非常に濃厚で特徴的。食べると脳内が活性化して知力がＵＰするというもっぱらの噂。";
  public const string DESC_05_MINI = "食べても食べても追加され続ける卵蕎麦。組み合わせが抜群で飽きがこない味がする。途中でストップと宣言しないと、ずっと食べ続けてしまうので止め時が肝心。";

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

  public const string DESC_31_MINI = "ウサギのもも肉の部位をゆっくりと弱火で焼き上げ、ツァルマンの里秘伝のタレで仕上げられた逸品。ふんわりとした触感がクセになる美味しさ。";
  public const string DESC_32_MINI = "里の近辺で行われる狩猟では渡り鴨が良く取れる。鴨のふくらはぎ部分を切り落とし、鍋には多種多彩な野菜と共に入れられる。出来上がった鍋からは程よい香ばしい香りがして食欲を誘う。";
  public const string DESC_33_MINI = "背負いキノコを丸々一匹、石窯で焼き上げた珍しい料理。触感は意外とコリコリしており、食べてみるとやみつきになる。";
  public const string DESC_34_MINI = "熱い鉄板の上で豪快に焼き上げた大量のネギ。デカいどんぶりにドカっとのせ、一丁アガリ！";
  public const string DESC_35_MINI = "七色の色を放つブナは基本的に調理したとしても食べられる箇所はごく僅か。数日の間、煮付けた後の旨味は最高の状態で引き出される。";

  public const string DESC_51_MINI = "カリっと天ぷら粉で焼き上げた野菜天ぷら。\r\n野菜であることを忘れてしまうぐらい、非常に香ばしい食感が残る。";
  public const string DESC_52_MINI = "固くて歯ごたえの悪いアザラシ肉を十分にほぐし、凍らせた後、焼き、塩をまぶした究極の一品。";
  public const string DESC_53_MINI = "冬の季節、急激な温度変化により身が引き締まったビーフを使用したカレーライス。臭みは一切感じない。";
  public const string DESC_54_MINI = "肉、魚、豆、味噌汁、ご飯、煎茶。全てが揃ったバランスの良い定食。\r\nハンナおばさん自慢の定食。";
  public const string DESC_55_MINI = "何という青さ・・・見ただけで凍えてしまいそうだ。\r\n　食べた時の口いっぱいに広がる感触は一級品のデザートそのものである。";

  public const string DESC_61_MINI = "真っ黒な色のスパゲッティ\r\n見た目がかなり不気味だが・・・スパイスの効いた香りがする。";
  public const string DESC_62_MINI = "ハンバーグの中に小さめに切り刻んだピーナッツが入っている\r\nフワフワとしたジューシーな肉とカリっとしたピーナッツが食欲をそそる。";
  public const string DESC_63_MINI = "表面に真っ赤なトウガラシがかけられているヒレステーキ。\r\nその裏には実はほんのりとハチミツが隠し味として入っており、食べた者には辛さと甘さが同時に響き渡る。";
  public const string DESC_64_MINI = "１番人気のトースト定食といえば、このオレンジトースト。\r\nふんだんに塗られたオレンジジャムとホワイトクリームを乗せたバカでかいトーストは男女問わず人気の一品である。";
  public const string DESC_65_MINI = "食物の匂いが全くしない闇の鍋\r\n　ハンナ叔母さん曰く、美味しいモノはちゃんと入っているとの事。それを信じて食べるしか選択肢は無い。";

  public static int[] FOOD_01_VALUE = { 1, 1, 1, 0, 0 };
  public static int[] FOOD_02_VALUE = { 0, 0, 0, 3, 0 };
  public static int[] FOOD_03_VALUE = { 3, 0, 0, 0, 1 };
  public static int[] FOOD_04_VALUE = { 0, 0, 3, 1, 1 };
  public static int[] FOOD_05_VALUE = { 2, 3, 0, 0, 1 };

  public static int[] FOOD_11_VALUE = {  5,  0,  0,  5,  0 };
  public static int[] FOOD_12_VALUE = {  0,  0,  0,  5,  5 };
  public static int[] FOOD_13_VALUE = {  0,  0,  8,  0,  5 };
  public static int[] FOOD_14_VALUE = { 10,  5,  0,  0,  0 };
  public static int[] FOOD_15_VALUE = {  0, 12,  5,  0,  0 };

  public static int[] FOOD_21_VALUE = {  0, 12,  8,  5,  0 };
  public static int[] FOOD_22_VALUE = {  5,  0, 12,  8,  0 };
  public static int[] FOOD_23_VALUE = {  0,  0,  5, 17,  8 };
  public static int[] FOOD_24_VALUE = { 12, 18,  0,  0,  5 };
  public static int[] FOOD_25_VALUE = { 23,  5,  0,  0, 12 };

  public static int[] FOOD_31_VALUE = {  0, 30,  0, 10, 10 };
  public static int[] FOOD_32_VALUE = { 30,  0,  0, 10, 10 };
  public static int[] FOOD_33_VALUE = {  0,  0, 35, 15, 20 };
  public static int[] FOOD_34_VALUE = {  0,  0,  0, 50, 30 };
  public static int[] FOOD_35_VALUE = { 20, 20, 20, 20, 20 };

  public static int[] FOOD_51_VALUE = {  60,   0,  80,   0,  60 };
  public static int[] FOOD_52_VALUE = {   0,  80,  60,  60,   0 };
  public static int[] FOOD_53_VALUE = {  70,   0,   0, 120,  60 };
  public static int[] FOOD_54_VALUE = {  60,  60,  60,  60,  60 };
  public static int[] FOOD_55_VALUE = {   0,   0, 250,  90,  60 };

  public static int[] FOOD_61_VALUE = {   0, 250, 250,   0, 250 };
  public static int[] FOOD_62_VALUE = { 250,   0,   0, 250, 250 };
  public static int[] FOOD_63_VALUE = { 250,   0, 500, 250,   0 };
  public static int[] FOOD_64_VALUE = {   0, 250, 250, 500,   0 };
  public static int[] FOOD_65_VALUE = { 500, 250,   0,   0, 500 };
  #endregion

  #region "GUI Label"
  #region "コマンド属性(JP)"
  public const string ATTRIBUTE_BASIC = "基本行動";
  public const string ATTRIBUTE_MAGIC = "魔法";
  public const string ATTRIBUTE_SKILL = "スキル";
  public const string ATTRIBUTE_CORE = "元核";
  public const string ATTRIBUTE_MONSTERACTION = "モンスターアクション";
  public const string ATTRIBUTE_OTHER = "その他";
  public const string ATTRIBUTE_NONE = "その他"; // 【なし】と書くと万が一GUI表示した時不適切なので、【その他】としておく。
  #endregion

  #region "クラス属性ラベル(EN/JP)"
  public const string CLASS_FIRE = "Fire";
  public const string CLASS_FIRE_JP = "炎";
  public const string CLASS_ICE = "Ice";
  public const string CLASS_ICE_JP = "氷";
  public const string CLASS_HOLYLIGHT = "HolyLight";
  public const string CLASS_HOLYLIGHT_JP = "聖";
  public const string CLASS_DARK_MAGIC = "DarkMagic";
  public const string CLASS_DARK_MAGIC_JP = "闇";
  public const string CLASS_FORCE = "Force";
  public const string CLASS_FORCE_JP = "理";
  public const string CLASS_VOIDCHANT = "VoidChant";
  public const string CLASS_VOIDCHANT_JP = "空唱";
  public const string CLASS_WARRIOR = "Warrior";
  public const string CLASS_WARRIOR_JP = "戦士";
  public const string CLASS_GUARDIAN = "Guardian";
  public const string CLASS_GUARDIAN_JP = "護衛";
  public const string CLASS_MARTIAL_ARTS = "MartialArts";
  public const string CLASS_MARTIAL_ARTS_JP = "格闘";
  public const string CLASS_ARCHERY = "Archery";
  public const string CLASS_ARCHERY_JP = "弓術";
  public const string CLASS_TRUTH = "Truth";
  public const string CLASS_TRUTH_JP = "心眼";
  public const string CLASS_MINDFULNESS = "Mindfulness";
  public const string CLASS_MINDFULNESS_JP = "無心";
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

  public const string GAME_EXIT_TITLE = "ゲームを終了しますか？";
  public const string GAME_EXIT_DESCRIPTION = "セーブしていない場合、現在データは破棄されます。";
  public const string GAME_EXIT_OK = "終了する";
  public const string GAME_EXIT_CANCEL = "終了しない";

  public const string LOAD_DATA_COMPLETE = "ゲームデータの読み込みが完了しました。";
  #endregion

  #region "Action Command"
  // GlobalCommand
  public const string READY_BUTTON = "ReadyButton";
  public const string GO_BUTTON = "GoButton";
  public const string STOP_BUTTON = "StopButton";
  public const string RUNAWAY_BUTTON = "RunAwayButton";
  public const string LOG_BUTTON = "LogButton";

  // ActionCommand
  public const string NORMAL_ATTACK = "Normal Attack";
  public const string NORMAL_ATTACK_JP = "通常攻撃";
  public const string MAGIC_ATTACK = "Magic Attack";
  public const string MAGIC_ATTACK_JP = "魔法攻撃";
  public const string DEFENSE = "Defense";
  public const string DEFENSE_JP = "防御";
  public const string STAY = "Stay";
  public const string STAY_JP = "待機";
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
  public const string USE_GREEN_POTION_1 = "GreenPotion_1";
  public const string USE_GREEN_POTION_2 = "GreenPotion_2";
  public const string USE_GREEN_POTION_3 = "GreenPotion_3";
  public const string USE_GREEN_POTION_4 = "GreenPotion_4";
  public const string USE_GREEN_POTION_5 = "GreenPotion_5";
  public const string USE_GREEN_POTION_6 = "GreenPotion_6";
  public const string USE_GREEN_POTION_7 = "GreenPotion_7";


  // Delve I
  public const string FIRE_BALL = "Fire Ball";
  public const string FIRE_BALL_JP = "ファイア・ボール";
  public const string ICE_NEEDLE = "Ice Needle";
  public const string ICE_NEEDLE_JP = "アイス・ニードル";
  public const string FRESH_HEAL = "Fresh Heal";
  public const string FRESH_HEAL_JP = "フレッシュ・ヒール";
  public const string SHADOW_BLAST = "Shadow Blast";
  public const string SHADOW_BLAST_JP = "シャドウ・ブラスト";
  public const string ORACLE_COMMAND = "Oracle Command";
  public const string ORACLE_COMMAND_JP = "オラクル・コマンド";
  public const string ENERGY_BOLT = "Energy Bolt";
  public const string ENERGY_BOLT_JP = "エナジー・ボルト";

  public const string STRAIGHT_SMASH = "Straight Smash";
  public const string STRAIGHT_SMASH_JP = "ストレート・スマッシュ";
  public const string SHIELD_BASH = "Shield Bash";
  public const string SHIELD_BASH_JP = "シールド・バッシュ";
  public const string LEG_STRIKE = "Leg Strike";
  public const string LEG_STRIKE_JP = "レッグ・ストライク";
  public const string HUNTER_SHOT = "Hunter Shot";
  public const string HUNTER_SHOT_JP = "ハンター・ショット";
  public const string TRUE_SIGHT = "True Sight";
  public const string TRUE_SIGHT_JP = "トゥルー・サイト";
  public const string DISPEL_MAGIC = "Dispel Magic";
  public const string DISPEL_MAGIC_JP = "ディスペル・マジック";

  // Devle II
  public const string FLAME_BLADE = "Flame Blade";
  public const string FLAME_BLADE_JP = "フレイム・ブレイド";
  public const string PURE_PURIFICATION = "Pure Purification";
  public const string PURE_PURIFICATION_JP = "ピュア・ピュリファイケーション";
  public const string DIVINE_CIRCLE = "Divine Circle";
  public const string DIVINE_CIRCLE_JP = "ディバイン・サークル";
  public const string BLOOD_SIGN = "Blood Sign";
  public const string BLOOD_SIGN_JP = "ブラッド・サイン";
  public const string FORTUNE_SPIRIT = "Fortune Spirit";
  public const string FORTUNE_SPIRIT_JP = "フォーチュン・スピリット";
  public const string FLASH_COUNTER = "Flash Counter";
  public const string FLASH_COUNTER_JP = "フラッシュ・カウンター";

  public const string STANCE_OF_THE_BLADE = "Stance of the Blade";
  public const string STANCE_OF_THE_BLADE_JP = "スタンス・オブ・ブレイド";
  public const string STANCE_OF_THE_GUARD = "Stance of the Guard";
  public const string STANCE_OF_THE_GUARD_JP = "スタンス・オブ・ガード";
  public const string SPEED_STEP = "Speed Step";
  public const string SPEED_STEP_JP = "スピード・ステップ";
  public const string MULTIPLE_SHOT = "Multiple Shot";
  public const string MULTIPLE_SHOT_JP = "マルチプル・ショット";
  public const string LEYLINE_SCHEMA = "Leyline Schema";
  public const string LEYLINE_SCHEMA_JP = "レイライン・スキーマ";
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
  public const string WORD_OF_POWER = "Word Of Power";
  public const string WORD_OF_POWER_JP = "ワード・オブ・パワー";
  public const string SIGIL_OF_THE_PENDING = "Sigil of the Pending";
  public const string SIGIL_OF_THE_PENDING_JP = "シギル・オブ・ペンディング";

  public const string DOUBLE_SLASH = "Double Slash";
  public const string DOUBLE_SLASH_JP = "ダブル・スラッシュ";
  public const string CONCUSSIVE_HIT = "Concussive Hit";
  public const string CONCUSSIVE_HIT_JP = "コンカッシヴ・ヒット";
  public const string BONE_CRUSH = "Bone Crush";
  public const string BONE_CRUSH_JP = "ボーン・クラッシュ";
  public const string EYE_OF_THE_ISSHIN = "Eye of the Isshin";
  public const string EYE_OF_THE_ISSHIN_JP = "一心の眼";
  public const string VOICE_OF_VIGOR = "Voice of Vigor";
  public const string VOICE_OF_VIGOR_JP = "ヴォイス・オブ・ヴィゴー";
  public const string UNSEEN_AID = "Unseen Aid";
  public const string UNSEEN_AID_JP = "アンシーン・エイド";

  // Delve IV
  public const string VOLCANIC_BLAZE = "Volcanic Blaze";
  public const string VOLCANIC_BLAZE_JP = "ヴォルカニック・ブレイズ";
  public const string FREEZING_CUBE = "Freezing Cube";
  public const string FREEZING_CUBE_JP = "フリージング・キューブ";
  public const string ANGELIC_ECHO = "Angelic Echo";
  public const string ANGELIC_ECHO_JP = "エンジェリック・エコー";
  public const string CURSED_EVANGILE = "Cursed Evangile";
  public const string CURSED_EVANGILE_JP = "カーズド・エヴァンジール";
  public const string GALE_WIND = "Gale Wind";
  public const string GALE_WIND_JP = "ゲイル・ウィンド";
  public const string PHANTOM_OBORO = "Phantom Oboro";
  public const string PHANTOM_OBORO_JP = "ファントム・朧";

  public const string IRON_BUSTER = "Iron Buster";
  public const string IRON_BUSTER_JP = "アイアン・バスター";
  public const string DOMINATION_FIELD = "Domination Field";
  public const string DOMINATION_FIELD_JP = "ドミネーション・フィールド";
  public const string DEADLY_DRIVE = "Deadly Drive";
  public const string DEADLY_DRIVE_JP = "デッドリー・ドライブ";
  public const string PENETRATION_ARROW = "Penetration Arrow";
  public const string PENETRATION_ARROW_JP = "ペネトレーション・アロー";
  public const string WILL_AWAKENING = "Will Awakening";
  public const string WILL_AWAKENING_JP = "ウィル・アウェイケニング";
  public const string CIRCLE_OF_SERENITY = "Circle of Serenity";
  public const string CIRCLE_OF_SERENITY_JP = "サークル・オブ・セレニティ";

  // Delve V
  public const string FLAME_STRIKE = "Flame Strike";
  public const string FLAME_STRIKE_JP = "フレイム・ストライク";
  public const string FROST_LANCE = "Frost Lance";
  public const string FROST_LANCE_JP = "フロスト・ランス";
  public const string SHINING_HEAL = "Shining Heal";
  public const string SHINING_HEAL_JP = "シャイニング・ヒール";
  public const string CIRCLE_OF_THE_DESPAIR = "Circle of the Despair";
  public const string CIRCLE_OF_THE_DESPAIR_JP = "サークル・オブ・ディスペア";
  public const string SEVENTH_PRINCIPLE = "Seventh Principle";
  public const string SEVENTH_PRINCIPLE_JP = "第七原理";
  public const string COUNTER_DISALLOW = "Counter Disallow";
  public const string COUNTER_DISALLOW_JP = "カウンター・ディスアロウ";

  public const string RAGING_STORM = "Raging Storm";
  public const string RAGING_STORM_JP = "レイジング・ストーム";
  public const string HARDEST_PARRY = "Hardest Parry";
  public const string HARDEST_PARRY_JP = "ハーデスト・パリィ";
  public const string UNINTENTIONAL_HIT = "Unintentional Hit";
  public const string UNINTENTIONAL_HIT_JP = "アンインテンショナル・ヒット";
  public const string PRECISION_STRIKE = "Precision Strike";
  public const string PRECISION_STRIKE_JP = "プレシジョン・ストライク";
  public const string EVERFLOW_MIND = "Everflow Mind";
  public const string EVERFLOW_MIND_JP = "エバーフロー・マインド";
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
  public const string FUTURE_VISION = "Future Vision";
  public const string FUTURE_VISION_JP = "フューチャー・ビジョン";
  public const string DETACHMENT_FAULT = "Detachment Fault";
  public const string DETACHMENT_FAULT_JP = "デタッチメント・フォールト";

  public const string STANCE_OF_THE_IAI = "Stance of the Iai";
  public const string STANCE_OF_THE_IAI_JP = "スタンス・オブ・イアイ";
  public const string ONE_IMMUNITY = "One Immunity";
  public const string ONE_IMMUNITY_JP = "ワン・イムーニティ";
  public const string STANCE_OF_MUIN = "Stance of Muin";
  public const string STANCE_OF_MUIN_JP = "無音の構え";
  public const string ETERNAL_CONCENTRATION = "Eternal Concentration";
  public const string ETERNAL_CONCENTRATION_JP = "エターナル・コンセントレーション";
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
  public const string GENESIS = "Genesis";
  public const string GENESIS_JP = "ジェネシス";
  public const string TIME_STOP = "Time Stop";
  public const string TIME_STOP_JP = "タイム・ストップ";

  public const string KINETIC_SMASH = "Kinetic Smash";
  public const string KINETIC_SMASH_JP = "キネティック・スマッシュ";
  public const string CATASTROPHE = "Catastrophe";
  public const string CATASTROPHE_JP = "カタストロフィ";
  public const string CARNAGE_RUSH = "Carnage Rush";
  public const string CARNAGE_RUSH_JP = "カルネージ・ラッシュ";
  public const string PIERCING_ARROW = "Piercing Arrow";
  public const string PIERCING_ARROW_JP = "ピアッシング・アロー";
  public const string STANCE_OF_THE_KOKOROE = "Stance of the Kokoroe";
  public const string STANCE_OF_THE_KOKOROE_JP = "スタンス・オブ・心得";
  public const string TRANSCENDENCE_REACHED = "Transcendence Reached";
  public const string TRANSCENDENCE_REACHED_JP = "トランッセンデンス・リーチ";

  #region "【複合魔法】"
  // 聖＋闇 [完全逆]
  public const string PSYCHIC_TRANCE = "Psychic Trance";
  public const string PSYCHIC_TRANCE_JP = "サイキック・トランス";
  public const string BLIND_JUSTICE = "Blind Justice";
  public const string BLIND_JUSTICE_JP = "ブラインド・ジャスティス";
  public const string DEATH_DENY = "Death Deny";
  public const string DEATH_DENY_JP = "デス・ディナイ";
  // 聖＋炎
  public const string FLASH_BLAZE = "Flash Blaze";
  public const string FLASH_BLAZE_JP = "フラッシュ・ブレイズ";
  public const string LIGHT_DETONATOR = "Light Detonator";
  public const string LIGHT_DETONATOR_JP = "ライト・デトネイター";
  public const string ASCENDANT_METEOR = "Ascendant Meteor";
  public const string ASCENDANT_METEOR_JP = "アセンダント・メテオ";
  // 聖＋氷
  public const string SKY_SHIELD = "Sky Shield";
  public const string SKY_SHIELD_JP = "スカイ・シールド";
  public const string SACRED_FIELD = "Sacred Field";
  public const string SACRED_FIELD_JP = "サークレッド・フィールド";
  public const string SAINT_JUDGEMENT = "Saint Judgement";
  public const string SAINT_JUDGEMENT_JP = "セイント・ジャッジメント";
  // 聖＋理
  public const string HOLY_BREAKER = "Holy Breaker";
  public const string HOLY_BREAKER_JP = "ホーリー・ブレイカー";
  public const string EXALTED_FIELD = "Exalted Field";
  public const string EXALTED_FIELD_JP = "イグザルテッド・フィールド";
  public const string HYMN_CONTRACT = "Hymn Contract";
  public const string HYMN_CONTRACT_JP = "ヒムン・コントラクト";
  // 聖＋空唱
  public const string VOID_THUNDER = "Void Thunder";
  public const string VOID_THUNDER_JP = "ヴォイド・サンダー";
  public const string ANGEL_INTERVENTION = "Angel Intervention";
  public const string ANGEL_INTERVENTION_JP = "エンジェル・インターベンション";
  public const string ENDLESS_ANTHEM = "Endless Anthem";
  public const string ENDLESS_ANTHEM_JP = "エンドレス・アンセム";
  // 闇＋炎
  public const string BLACK_FIRE = "Black Fire";
  public const string BLACK_FIRE_JP = "ブラック・ファイア";
  public const string BLAZING_FIELD = "Blazing Field";
  public const string BLAZING_FIELD_JP = "ブレイジング・フィールド";
  public const string DEMONIC_IGNITE = "Demonic Ignite";
  public const string DEMONIC_IGNITE_JP = "デーモニック・イグナイト";
  // 闇＋氷
  public const string DEEP_MIRROR = "Deep Mirror";
  public const string DEEP_MIRROR_JP = "ディープ・ミラー";
  public const string STORM_SHARD = "Storm Shard";
  public const string STORM_SHARD_JP = "ストーム・シャード";
  public const string ABYSS_EYE = "Abyss Eye";
  public const string ABYSS_EYE_JP = "アビス・アイ";
  // 闇＋理
  public const string WORD_OF_MALICE = "Word of Malice";
  public const string WORD_OF_MALICE_JP = "ワード・オブ・マリス";
  public const string SIN_FORTUNE = "Sin Fortune";
  public const string SIN_FORTUNE_JP = "シン・フォーチュン";
  public const string BLOOD_SHACKLE = "Blood Shackle";
  public const string BLOOD_SHACKLE_JP = "ブラッド・シャックル";
  // 闇＋空唱
  public const string ACHROMA_BLAST = "Achroma Blast";
  public const string ACHROMA_BLAST_JP = "アクローマ・ブラスト";
  public const string DOOM_BLADE = "Doom Blade";
  public const string DOOM_BLADE_JP = "ドゥーム・ブレイド";
  public const string ECLIPSE_END = "Eclipse End";
  public const string ECLIPSE_END_JP = "エクリプス・エンド";
  // 炎＋氷 [完全逆]
  public const string CHILL_BURN = "Chill Burn";
  public const string CHILL_BURN_JP = "チル・バーン";
  public const string SWORD_OF_FREEZING_FIRE = "Sword of Freezing-Fire";
  public const string SWORD_OF_FREEZING_FIRE_JP = "ソード・オブ・フリージングファイア";
  public const string ZETA_EXPLOSION = "Zeta Explosion";
  public const string ZETA_EXPLOSION_JP = "ゼータ・エクスプロージョン";
  // 炎＋理
  public const string BURST_INFERNO = "Burst Inferno";
  public const string BURST_INFERNO_JP = "バースト・インフェルノ";
  public const string PIERCING_FLAME = "Piercing Flame";
  public const string PIERCING_FLAME_JP = "ピアッシング・フレイム";
  public const string SIGIL_OF_HOMURA = "Sigil of Homura";
  public const string SIGIL_OF_HOMURA_JP = "シギル・オブ・焔";
  // 炎＋空唱
  public const string ERRATIC_THUNDERBOLT = "Erratic Thunderbolt";
  public const string ERRATIC_THUNDERBOLT_JP = "エラティック・サンダーボルト";
  public const string STEAM_MIRROR = "Steam Mirror";
  public const string STEAM_MIRROR_JP = "スチーム・ミラー";
  public const string RED_DRAGON_WILL = "Red Dragon Will";
  public const string RED_DRAGON_WILL_JP = "レッド・ドラゴン・ウィル";
  // 氷＋理
  public const string WORD_OF_ATTITUDE = "Word Of Attitude";
  public const string WORD_OF_ATTITUDE_JP = "ワード・オブ・アティチュード";
  public const string ICICLE_BARRIER = "Icicle Barrier";
  public const string ICICLE_BARRIER_JP = "アイシクル・バリア";
  public const string AUSTERITY_MATRIX = "Austerity Matrix";
  public const string AUSTERITY_MATRIX_JP = "アウステリティ・マトリクス";
  // 氷＋空唱
  public const string GLACIAL_CIRCLE = "Glacial Circle";
  public const string GLACIAL_CIRCLE_JP = "グラシィアル・サークル";
  public const string VORTEX_SONG = "Vortex Song";
  public const string VORTEX_SONG_JP = "ヴォーテクス・ソング";
  public const string BLUE_DRAGON_WILL = "Blue Dragon Will";
  public const string BLUE_DRAGON_WILL_JP = "ブルー・ドラゴン・ウィル";
  // 理＋空唱 [完全逆]
  public const string WORD_OF_NINE = "Word of Nine";
  public const string WORD_OF_NINE_JP = "ワード・オブ・ナイン";
  public const string PARADOX_IMAGE = "Paradox Image";
  public const string PARADOX_IMAGE_JP = "パラドックス・イメージ";
  public const string WARP_GATE = "Warp Gate";
  public const string WARP_GATE_JP = "ワープ・ゲート";
  #endregion

  #region "【複合スキル】"
  // 戦士＋護衛 [完全逆]
  public const string NEUTRAL_SMASH = "Neutral Smash";
  public const string NEUTRAL_SMASH_JP = "ニュートラル・スマッシュ";
  public const string STANCE_OF_DOUBLE = "Stance of Double";
  public const string STANCE_OF_DOUBLE_JP = "スタンス・オブ・ダブル";
  // 戦士＋格闘
  public const string BLITZ_STRIKE = "Blitz Strike";
  public const string BLITZ_STRIKE_JP = "ブリッツ・ストライク";
  public const string ASSASSINATION_HIT = "Assassination Hit";
  public const string ASSASSINATION_HIT_JP = "アサシネーション・ヒット";
  // 戦士＋弓術
  public const string PHOENIX_EYE = "Phoenix Eye";
  public const string PHOENIX_EYE_JP = "フェニックス・アイ";
  public const string HARDENED_INSIGHT = "Hardened Insight";
  public const string HARDENED_INSIGHT_JP = "ハーディンド・インサイト";
  // 戦士＋心眼
  public const string CHALLENGING_SHOUT = "Challenging Shout";
  public const string CHALLENGING_SHOUT_JP = "チャレンジング・シャウト";
  public const string ONSLAUGHT_HIT = "Onslaught Hit";
  public const string ONSLAUGHT_HIT_JP = "オンスロート・ヒット";
  // 戦士＋無心
  public const string FORMLESS_STYLE = "Formless Style";
  public const string FORMLESS_STYLE_JP = "フォームレス・スタイル";
  public const string SMOOTHING_MOVE = "Smoothing Move";
  public const string SMOOTHING_MOVE_JP = "スムージング・ムーヴ";
  // 護衛＋格闘
  public const string TACTICAL_VISION = "Tactical Vision";
  public const string TACTICAL_VISION_JP = "タクティカル・ビジョン";
  public const string SWIFT_RESPONSE = "Swift Response";
  public const string SWIFT_RESPONSE_JP = "スウィフト・レスポンス";
  // 護衛＋弓術
  public const string RIGHTEOUSNESS_ARROW = "Righteousness Arrow";
  public const string RIGHTEOUSNESS_ARROW_JP = "ライティアスネス・アロー";
  public const string PERFECT_EVASION = "Perfect Evasion";
  public const string PERFECT_EVASION_JP = "パーフェクト・イヴェイジョン";
  // 護衛＋心眼
  public const string REFLEX_ESSENCE = "Reflex Essence";
  public const string REFLEX_ESSENCE_JP = "リフレックス・エッセンス";
  public const string SELF_PERSUASION = "Self Persuasion";
  public const string SELF_PERSUASION_JP = "セルフ・パースエイジョン";
  // 護衛＋無心
  public const string TRUST_SILENCE = "Trust Silence";
  public const string TRUST_SILENCE_JP = "トラスト・サイレンス";
  public const string NOURISH_POWER = "Nourish Power";
  public const string NOURISH_POWER_JP = "ノゥリッシュ・パワー";
  // 格闘＋弓術 [完全逆]
  public const string SUDDEN_STRIKEARROW = "Sudden StrikeArrow";
  public const string SUDDEN_STRIKEARROW_JP = "サドン・ストライクアロー";
  public const string STANCE_OF_MYSTIC = "Stance of Mystic";
  public const string STANCE_OF_MYSTIC_JP = "スタンス・オブ・ミスティック";
  // 格闘＋心眼
  public const string PSYCHIC_WAVE = "Psychic Wave";
  public const string PSYCHIC_WAVE_JP = "サイキック・ウェイヴ";
  public const string FLARE_OF_FIGHTING = "Flare of Fighting";
  public const string FLARE_OF_FIGHTING_JP = "闘いの閃光";
  // 格闘＋無心
  public const string INFINITY_IMAGE = "Infinity Image";
  public const string INFINITY_IMAGE_JP = "インフィニティ・イメージ";
  public const string UNIFIED_CONVICTION = "Unified Conviction";
  public const string UNIFIED_CONVICTION_JP = "ユニファイド・コンヴィクション";
  // 弓術＋心眼
  public const string ABSOLUTE_ARROW = "Absolute Arrow";
  public const string ABSOLUTE_ARROW_JP = "アブソリュート・アロー";
  public const string HEAVENS_WISDOM = "Heavens Wisdom";
  public const string HEAVENS_WISDOM_JP = "ヘブンズ・ウィズダム";
  // 弓術＋無心
  public const string SILENT_MEDITATION = "Silent Meditation";
  public const string SILENT_MEDITATION_JP = "サイレント・メディテーション";
  public const string COLORLESS_FORM = "Colorless Form";
  public const string COLORLESS_FORM_JP = "カラレス・フォーム";
  // 心眼＋無心
  public const string OVERWHELMING_DESTINY = "Overwhelming Destiny";
  public const string OVERWHELMING_DESTINY_JP = "オーバーウェルミング・デスティニー";
  public const string WORLD_CHANT = "World Chant";
  public const string WORLD_CHANT_JP = "世界の詠唱";
  #endregion

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
  public const string COMMAND_TAIATARI = "体当たり";
  public const string COMMAND_WINDFLARE = "ウィンド・フレア";
  public const string COMMAND_EARTHBOLT = "アース・ボルト";
  public const string COMMAND_SILENT_SHOT = "サイレント・ショット";
  public const string COMMAND_PHANTOM_SONG = "精霊の歌";
  public const string COMMAND_ENRAGE = "怒り";
  public const string COMMAND_SPLASH_HARMONY = "スプラッシュ・ハーモニー";
  public const string COMMAND_RANBOU_CHARGE = "乱暴な突進";
  public const string COMMAND_BEAST_STRIKE = "猛獣の一撃";
  public const string COMMAND_KONSHIN_TOKKAN = "渾身の突貫";
  public const string COMMAND_HUHAI_SINKOU = "腐敗の進行";
  public const string COMMAND_STRONG_SLASH = "ストロング・スラッシュ";
  public const string COMMAND_SHADOW_MIST = "闇の濃霧";
  public const string COMMAND_ROCK_THROW = "岩石投げ";
  public const string COMMAND_YOUEN_KISS = "妖艶なキス";
  public const string COMMAND_POISON_SPORE = "猛毒の胞子";
  public const string COMMAND_GROUND_RUMBLE = "地ならし";
  public const string COMMAND_FIRE_BLAST = "ファイア・ブラスト";
  public const string COMMAND_RENSOU_TOSSHIN = "連槍突進";
  public const string COMMAND_VERDANT_VOICE = "新緑の呼び声";
  public const string COMMAND_BLACK_SPORE = "黒い胞子";
  public const string COMMAND_KILL_SPINNING_LANCER = "キル・スピニングランサー";

  public const string COMMAND_WING_BLADE = "ウィング・ブレード";
  public const string COMMAND_STONE_BLAW = "ストーン・ブロー";
  public const string COMMAND_HUMIOROSI = "踏み下ろし";
  public const string COMMAND_SQUALL_LIGHTNING = "スコール・ライトニング";
  public const string COMMAND_SIPPUUKEN = "疾風剣";
  public const string COMMAND_BRIGHTNESS_RINPUN = "輝かしい鱗粉";
  public const string COMMAND_SHIROGANE_HORN = "白銀の角";
  public const string COMMAND_VISIBLE_EYE = "不可視の視線";
  public const string COMMAND_INVISIBLE_EYE = "可視光線";
  public const string COMMAND_WIND_CUTTER = "ウィンド・カッター";
  public const string COMMAND_BLUE_LAVA = "青い溶岩";
  public const string COMMAND_BLUE_BUBBLE = "ブルー・バブル";
  public const string COMMAND_WHITE_LAVA = "白い溶岩";
  public const string COMMAND_WHITE_BUBBLE = "ホワイト・バブル";
  public const string COMMAND_REFLECTION_SHADE = "リフレクション・シェード";
  public const string COMMAND_ICHIMAI_GUARDWALL = "壱枚の防壁";
  public const string COMMAND_MULTIPLE_FEATHER = "マルチプル・フェザー";
  public const string COMMAND_BRIGHT_FLASH = "ブライト・フラッシュ";
  public const string COMMAND_CYCLONE_SHOT = "サイクロン・ショット";
  public const string COMMAND_MORPH_VANISH = "変異バニッシュ";
  public const string COMMAND_ROD_AGARTHA = "杖：アガルタ";
  public const string COMMAND_SWORD_MAHOROBA = "剣：マホロバ";
  public const string COMMAND_FEROCIOUS_THUNDER = "フェロシアス・サンダー";
  public const string COMMAND_RAGING_CLAW = "レイジング・クロー";
  public const string COMMAND_CLEANSING_LIGHT = "浄化の光";
  public const string COMMAND_FAITH_SIGHT = "信仰への凝視";
  public const string COMMAND_SAMAYOU_HAND = "彷徨う手";
  public const string COMMAND_SEIIN_FOOTPRINT = "正因の足跡";
  public const string COMMAND_LIGHT_THUNDERBOLT = "雷光の一撃";
  public const string COMMAND_CYCLONE_ARMOR = "サイクロン・アーマー";
  public const string COMMAND_FURY_TRIDENT = "フューリー・トライデント";
  public const string COMMAND_HEAVEN_THUNDER_SPEAR = "天啓の雷槍";
  public const string COMMAND_OVERRUN = "踏みつぶし";
  public const string COMMAND_GLARE = "睨みつけ";
  public const string COMMAND_ARC_BLASTER = "アーク・ブラスター";
  public const string COMMAND_DRAGON_BREATH = "ドラゴン・ブレス";
  public const string COMMAND_RENZOKU_BAKUHATSU = "連続爆発";
  public const string COMMAND_AIUCHI_NERAI = "相打ち狙い";
  public const string COMMAND_HIDDEN_KNIFE = "隠しナイフ";
  public const string COMMAND_MYSTICAL_FIELD = "ミスティカル・フィールド";
  public const string COMMAND_SEIKUU_GUARDWALL = "清空の防壁";
  public const string COMMAND_THUNDERCLOUD_INVASION = "雷雲の侵攻";
  public const string COMMAND_MIST_BARRIER = "ミスト・バリア";
  public const string COMMAND_SUN_SLAYER = "サン・スレイヤー";
  public const string COMMAND_TRIPLE_TACTICS = "トリプル・タクティクス";
  public const string COMMAND_WIND_ARROW = "ウィンド・アロー";
  public const string COMMAND_TYPHOON = "タイフーン";
  public const string COMMAND_TAIKI_VANISH = "大気消滅";
  public const string COMMAND_HARD_CHARGE = "激突";
  public const string COMMAND_RAMPAGE = "大暴れ";
  public const string COMMAND_ICE_BURN = "アイス・バーン";
  public const string COMMAND_FROST_SHARD = "フロスト・シャード";
  public const string COMMAND_DOKAAAAN = "ドカーーン！";
  public const string COMMAND_RENSYA = "連射！";
  public const string COMMAND_ERRATIC_EXPLODE = "エラティック・エクスプロード";
  public const string COMMAND_CYCLONE_FIELD = "サイクロン・フィールド";
  public const string COMMAND_ICE_RAY = "アイス・レイ";
  public const string COMMAND_CLEANSING_LANCE = "浄化の槍";
  public const string COMMAND_STATUS_CHANGE = "状態変異";
  public const string COMMAND_DEATH_DANCE = "死の舞踏";
  public const string COMMAND_HEAVEN_VOICE = "天空の呼び声";
  public const string COMMAND_PLASMA_STORM = "プラズマ・ストーム";
  public const string COMMAND_APOCALYPSE_SWORD = "アポカリプス・ソード";

  public const string COMMAND_WATER_GUN = "ウォーター・ガン";
  public const string COMMAND_WATER_DANCE = "水中ダンス";
  public const string COMMAND_WATER_SHOT = "水中射出";
  public const string COMMAND_SKY_FEATHER = "スカイ・フェザー";
  public const string COMMAND_RAINBOW_BUBBLE = "虹色バブル";
  public const string COMMAND_WATER_CIRCLE = "ウォーター・サークル";
  public const string COMMAND_ROLLING_CHARGE = "ローリング・突撃";
  public const string COMMAND_JET_RUN = "ジェット・ラン";
  public const string COMMAND_INVISIBLE_POISON = "インビジブル・ポイゾン";
  public const string COMMAND_BEAUTY_AROMA = "かぐわしい芳香";
  public const string COMMAND_AQUA_BLOSSOM = "アクア・ブラッサム";
  public const string COMMAND_DEATH_STROKE = "デス・ストローク";
  public const string COMMAND_DEVIL_EMBLEM = "デビル・エムブレム";
  public const string COMMAND_DEVILSPEAR_MISTELTEN = "魔槍：ミストルティン";
  public const string COMMAND_COLD_WIND = "コールド・ウィンド";
  public const string COMMAND_PARALYZE_TENTACLE = "痺れ触手";
  public const string COMMAND_SCREAMING_SOUND = "奇声音波";
  public const string COMMAND_KUROZUMI_FIELD = "黒墨フィールド";
  public const string COMMAND_HAGAIZIME = "羽交い絞め";
  public const string COMMAND_SOLID_SQUARE_WATER = "ソリッド・スクエア・ウォータ";
  public const string COMMAND_BRIGHT_EYE = "ブライト・アイ";
  public const string COMMAND_AXE_DRIVER = "アクス・ドライバー";
  public const string COMMAND_EARTH_CLAP = "アース・クラップ";
  public const string COMMAND_STONE_KOURA = "石の甲羅";
  public const string COMMAND_DAIBOUSOU = "大暴走";
  public const string COMMAND_JUMP_SMASH = "跳躍スマッシュ";
  public const string COMMAND_STRANGE_SPELL = "奇妙な詠唱";
  public const string COMMAND_THROWING_CRASH = "スローイング・クラッシュ";
  public const string COMMAND_BAIRIKI = "倍力";
  public const string COMMAND_NAGITAOSHI = "なぎ倒し";
  public const string COMMAND_WASHIZUKAMI = "鷲掴み";
  public const string COMMAND_ZINARASHI = "地鳴らし";
  public const string COMMAND_SUIKOMI = "吸い込み";
  public const string COMMAND_EIGHT_ALL = "８つ手８つ眼８つ足";
  public const string COMMAND_SCARLET_SEED = "緋色の種";
  public const string COMMAND_POISON_GERMINATION = "猛毒の発芽";
  public const string COMMAND_WAVE_SIGN = "ウェーブ・サイン";
  public const string COMMAND_SILENT_SIGN = "無音のサイン";
  public const string COMMAND_HIKKAKI_CLAW = "引掻き爪";
  public const string COMMAND_BATTLE_DANCE = "闘いの舞";
  public const string COMMAND_DRAIN_WEB = "ドレイン・ウェブ";
  public const string COMMAND_SAND_SMOKE = "砂煙";
  public const string COMMAND_GUT_SLASH = "ガット・スラッシュ";
  public const string COMMAND_GUARDIAN_SONG = "護衛の賛歌";
  public const string COMMAND_WATER_FLAPPING = "水中はばたき";
  public const string COMMAND_INVISIBLE_THREAD = "不可視の縛糸";
  public const string COMMAND_INTENSE_BREATH = "激しいブレス";
  public const string COMMAND_BIG_SWIM = "大泳ぎ";
  public const string COMMAND_ROAR = "雄たけび";
  public const string COMMAND_BITING = "かぶりつき";
  public const string COMMAND_SAINT_DROP = "神聖の雫";
  public const string COMMAND_AMPLIFY_SEAL = "増幅の戦闘印";
  public const string COMMAND_PHANTOM_SEAL = "幻影の守護印";
  public const string COMMAND_TEN_BULLET = "十連飛礫";
  public const string COMMAND_HOLLOW_MIST = "嘆きの霧";
  public const string COMMAND_POLLUTED_POISON = "汚染された毒液";
  public const string COMMAND_BUBBLE_BULLET = "気泡弾";
  public const string COMMAND_AMBUSH_ATTACK = "潜伏攻撃";
  public const string COMMAND_GROUND_THUNDER = "グラウンド・サンダー";
  public const string COMMAND_CONTINUOUS_CHARGE = "連続特攻";
  public const string COMMAND_STAR_EMBLEM = "スターの紋様";
  public const string COMMAND_MUD_PISTOL = "泥鉄砲";
  public const string COMMAND_RIPPER_CLAW = "切り裂きクロー";
  public const string COMMAND_HIKICHIGIRI = "引きちぎり";
  public const string COMMAND_RUBBER_TONG = "ゴム舌";
  public const string COMMAND_SPANNING_SLASH = "スパニング・ラッシュ";
  public const string COMMAND_STARSWORD_KAI = "スター・ソード【改】";
  public const string COMMAND_SEASTAR_EYE = "海星の眼";
  public const string COMMAND_WATER_CANNON = "キャノン・ウォータ";
  public const string COMMAND_PROTECTION_SEAL = "プロテクション・シール";
  public const string COMMAND_BLOODSHOT_EYE = "血走った眼";
  public const string COMMAND_FRENZY_DRIVE = "狂暴ドライブ";
  public const string COMMAND_THOUGHT_EATER = "思考食い";
  public const string COMMAND_VACUUM_SHOT = "真空砲弾";
  public const string COMMAND_PHANTOM_EATER = "ファントム・イーター";
  public const string COMMAND_GHOST_KILL = "ゴースト・キル";
  public const string COMMAND_ZERO_ATTACK = "零の一閃";
  public const string COMMAND_JU_STYLE = "十の太刀";
  public const string COMMAND_CLEANSING_SONG = "洗礼の歌声";
  public const string COMMAND_WASH_AWAY = "洗い流し";
  public const string COMMAND_CHARGE = "突撃";
  public const string COMMAND_SEA_STRIVE = "シー・ストライヴ";
  public const string COMMAND_BLINK_SHELL = "ブリンク・シェル";
  public const string COMMAND_PLATINUM_BLADE = "プラチナ・ブレード";
  public const string COMMAND_SEASTAR_OATH = "海星源への誓い";
  public const string COMMAND_JEWEL_BREAK = "ジュエル・ブレイク";
  public const string COMMAND_STAR_DUST = "スター・ダスト";    
  public const string COMMAND_STARSWORD_KIRAMEKI = "スター・ソード【煌】";
  public const string COMMAND_BARRIER_FIELD = "結界フィールド";
  public const string COMMAND_CIRCULAR_SLASH = "サーキュラー・スラッシュ";
  public const string COMMAND_TORPEDO_BUSTER = "トルペード・バスター";
  public const string COMMAND_STAR_FALL = "スター・フォール";
  public const string COMMAND_STARSWORD_TSUYA = "スター・ソード【艶】";
  public const string COMMAND_INVASION_FIELD = "侵攻フィールド";
  public const string COMMAND_ILLUSION_BOLT = "イリュージョン・ボルト";
  public const string COMMAND_VORTEX_BLAST = "ヴォーテクス・ブラスト";
  public const string COMMAND_FIRE_BULLET = "燃え盛る炎弾丸";
  public const string COMMAND_BLAZING_STORM = "ブレイジング・ストーム";
  public const string COMMAND_FLARE_BURN = "フレア・バーン";
  public const string COMMAND_FIRE_WALL = "ファイア・ウォール";
  public const string COMMAND_PENETRATION_EYE = "ペネトレーション・アイ";
  public const string COMMAND_FROZEN_BULLET = "凍てつく氷炎弾丸";
  public const string COMMAND_FREEZING_STORM = "フリージング・ストーム";
  public const string COMMAND_SUDDEN_SQUALL = "サドン・スコール";
  public const string COMMAND_WATER_BUBBLE = "ウォータ・バブル";
  public const string COMMAND_HALLUCINATE_EYE = "ハルシネイト・アイ";
  public const string COMMAND_BRAVE_ROAR = "勇敢な雄叫び";
  public const string COMMAND_SEASLIDE_WATER = "シースライド・ウォータ";
  public const string COMMAND_GUNGNIR_SLASH= "グングニル・スラッシュ";
  public const string COMMAND_ISONIC_WAVE = "アイソニック・ウェイブ";
  public const string COMMAND_GUNGNIR_LIGHT = "グングニルの閃光";
  public const string COMMAND_LIFE_WATER = "生命の龍水";
  public const string COMMAND_SALMAN_CHANT = "サルマンの詠唱";
  public const string COMMAND_ANDATE_CHANT = "アンダートの詠唱";
  public const string COMMAND_ELEMENTAL_SPLASH = "エレメンタル・スプラッシュ";
  public const string COMMAND_BYAKURAN_FROZEN_ART = "白蘭真氷術";
  public const string COMMAND_SEASTAR_ORIGIN_SEAL = "海星源の授印";
  public const string COMMAND_SOUMEI_SEISOU_KEN = "爽鳴清双剣";
  //public const string COMMAND_ = "フレッシュ・ヒール";
  //public const string COMMAND_ = "フリージング・キューブ";
  //public const string COMMAND_ = "フォーチュン・スピリット";
  public const string COMMAND_SEASTARKING_ROAR = "海王の咆哮";
  public const string COMMAND_BURST_CLOUD = "バースト・クラウド";
  public const string COMMAND_HUGE_SHOCKWAVE = "大激衝";
  public const string COMMAND_SURGETIC_BIND = "サージェティック・バインド";
  public const string COMMAND_TIDAL_WAVE = "タイダル・ウェイブ";

  public const string COMMAND_BACKSTAB_ARROW = "バックスタッブ・アロー";
  public const string COMMAND_KARAME_BIND = "絡め捕り";
  public const string COMMAND_BEAST_SPIRIT = "野獣の魂";
  public const string COMMAND_BEAST_HOUND = "ビースト・ハウンド";
  public const string COMMAND_DATOTSU = "打突";
  public const string COMMAND_ASSASSIN_POISONNEEDLE = "アサシンの毒針";
  public const string COMMAND_SAINT_SLASH = "セイント・スラッシュ";
  public const string COMMAND_DEMON_CONTRACT = "悪魔との契約";
  public const string COMMAND_DARKM_SPELL = "暗黒呪文";
  public const string COMMAND_HELLFIRE_SPELL = "煉獄の禁術";
  public const string COMMAND_RENZOKU_HOUSYA = "連続放射";
  public const string COMMAND_STEAM_ARROW = "スチーム・アロー";
  public const string COMMAND_BLACKDRAGON_WHISPER = "黒龍のささやき";
  public const string COMMAND_DEATH_HAITOKU = "死への背徳";
  public const string COMMAND_SUPERIOR_FIELD = "スペリオル・フィールド";
  public const string COMMAND_SHINDOWKEN = "振動剣";
  public const string COMMAND_DEATH_STRIKE = "デス・ストライク";
  public const string COMMAND_SOUL_FROZEN = "魂への凍結";
  public const string COMMAND_CURSED_THREAD = "呪いの糸";
  public const string COMMAND_HORROR_VISION = "ホラー・ヴィジョン";
  public const string COMMAND_RASEN_KOKUEN = "螺旋黒炎";
  public const string COMMAND_RANSO_RENGEKI = "乱奏連撃";
  public const string COMMAND_DEMON_BOLT = "デーモン・ボルト";
  public const string COMMAND_ARCANE_DESTRUCTION = "アーケン・デストラクション";
  public const string COMMAND_TOWER_FALL = "タワー・フォール";
  public const string COMMAND_ROUND_DIVIDE = "ラウンド・ディバイド";
  public const string COMMAND_BLACK_FLARE = "ブラック・フレア";
  public const string COMMAND_SATELLITE_SWORD = "サテライト・ソード";
  public const string COMMAND_SIGIL_OF_SUN_FALLEN = "太陽の滅印";
  public const string COMMAND_LIFE_BRILLIANT = "生命の輝き";
  public const string COMMAND_ALL_DUST = "全ては灰に";
  public const string COMMAND_LVEL_SONG = "レヴェルの唄";
  public const string COMMAND_GIGANT_SLAYER = "ギガント・スレイヤー";
  public const string COMMAND_JUONSATSU = "呪怨殺";
  public const string COMMAND_ABYSS_LOGIC = "深淵の理";
  public const string COMMAND_BONE_TORNADO = "ボーン・トルネード";
  public const string COMMAND_OMINOUS_LAUGH = "不気味な笑い声";
  public const string COMMAND_SKULL_CRASH = "スカル・クラッシュ";
  public const string COMMAND_WAZAWAI_FLAME = "禍の炎";
  public const string COMMAND_THE_END = "ジ・エンド";
  public const string COMMAND_HELLFLAME_BULLET = "煉獄弾";
  public const string COMMAND_CHROMATIC_BULLET = "クロマティック・バレット";
  public const string COMMAND_SUPER_MAX_WAVE = "超高温熱波動";
  public const string COMMAND_IRREGULAR_REGENERATION = "異常再生";
  public const string COMMAND_ETERNAL_CIRCLE = "循環の紋様";
  public const string COMMAND_DESTRUCTION_CIRCLE = "破滅の紋様";
  public const string COMMAND_PERFECT_STOP = "完全停止";
  public const string COMMAND_SPECTOR_VOICE = "スペクター・ヴォイス";
  public const string COMMAND_NOMERCY_SCREAM = "無慈悲な叫び声";
  public const string COMMAND_DARK_SIMULACRUM = "ダーク・シミュラクラム";
  public const string COMMAND_FABRIOLE_SPEAR = "フェイブリオル・スピア";
  public const string COMMAND_REST_IN_DREAM = "安らかなる夢";
  public const string COMMAND_DANCING_LANCER = "ダンシング・ランサー";
  public const string COMMAND_CHAOS_DEATHPERADE = "カオス・デスペラーテ";
  public const string COMMAND_MARIA_DANSEL = "マリア・ダンセル";
  public const string COMMAND_DESTRUCT_TUNING = "調律への破壊";
  public const string COMMAND_GROUND_CRACK = "大地の裂け目";
  public const string COMMAND_BLACK_DARK_LANCE = "不朽の暗黒槍";
  public const string COMMAND_UNDEAD_WISH = "不死への渇望";
  public const string COMMAND_HELL_CIRCLE = "ヘル・サークル";
  public const string COMMAND_INNOCENT_SLASH = "無垢の一振り";
  public const string COMMAND_HARSH_CUTTER = "ハーシュ・カッター";
  public const string COMMAND_JUDGEMENT_LIGHTNING = "裁きの雷砲";
  public const string COMMAND_BLACKHOLE = "ブラック・ホール";
  public const string COMMAND_ERROR_OCCUR = "異常発生";
  public const string COMMAND_FUMBLE_SIGN = "ファンブル・サイン";
  public const string COMMAND_AREA_TWIST = "空間ねじ曲げ";
  public const string COMMAND_PARADOXICAL_SLICER = "パラドキシカル・スライサー";
  public const string COMMAND_OAHN_VOICE = "オーンの呼び声";
  public const string COMMAND_MOMENT_MAGIC = "瞬間魔法";
  public const string COMMAND_DESPIAR_RAIN = "破滅の雨";
  public const string COMMAND_SWORD_OF_WIND = "ソード・オブ・ウィンド";
  public const string COMMAND_SKY_CUTTER = "断空";
  public const string COMMAND_SONIC_BLADE = "高速剣";
  public const string COMMAND_SCREAMING_FROM_HELL = "地獄からの呼び声";
  public const string COMMAND_DESPAIR_SPEAR = "絶望の槍";
  public const string COMMAND_KUUKAN_MATEN = "空間魔天";
  public const string COMMAND_METEOR_STORM = "メテオ・ストーム";
  public const string COMMAND_CROSS_GATE = "クロス・ゲート";
  public const string COMMAND_PRISMATIC_BULLET = "プリズマティック・バレット";
  public const string COMMAND_PHOTON_LASER = "フォトン・レーザー";
  public const string COMMAND_SEALED_STONE = "封印石";
  public const string COMMAND_OUT_OF_CONTROL = "制御不能";
  public const string COMMAND_POWER_EXPLOSION = "パワー・エクスプロージョン";
  public const string COMMAND_PERFECT_HIT = "パーフェクト・ヒット";
  public const string COMMAND_FUSION_CHARGE = "フュージョン・チャージ";
  public const string COMMAND_LEGION_DRIVE = "レギオン・ドライブ";
  public const string COMMAND_BERSERKER_RUSH = "バーサーカー・ラッシュ";
  public const string GOLDEN_MATRIX = "Golden Matrix";
  public const string COMMAND_GOLDEN_MATRIX = "ゴールデン・マトリクス";
  public const string COMMAND_METSU_INCARNATION = "滅・インカーネーション";
  public const string COMMAND_THOUSAND_SQUALL = "サウザンド・スコール";
  public const string COMMAND_AURORA_BLADE = "オーロラ・ブレイド";
  public const string COMMAND_MEGIDO_BLAZE = "メギド・ブレイズ";
  public const string COMMAND_ABYSS_WILL = "アビスの意志";
  public const string COMMAND_ONE_HOMURA = "壱なる焔";
  public const string COMMAND_ABYSS_FIRE = "アビス・ファイア";
  public const string COMMAND_ETERNAL_DROPLET = "エターナル・ドロップレット";
  public const string COMMAND_AUSTERITY_MATRIX_OMEGA = "アウステリティ・マトリクスΩ";
  public const string COMMAND_VOICE_OF_ABYSS = "ヴォイス・オブ・アビス";
  public const string COMMAND_VOID_BEAT = "虚無の鼓動";

  public const string COMMAND_RENGEKI = "連・撃";
  public const string RENGEKI = "Rengeki";
  public const string COMMAND_PERFECT_PROPHECY = "完全なる予見";
  public const string PERFECT_PROPHECY = "Perfect Prophecy";
  public const string COMMAND_HOLY_WISDOM = "神明：ホーリー・ウィズダム";
  public const string HOLY_WISDOM = "Holy Wisdom";
  public const string COMMAND_ETERNAL_PRESENCE = "信念：エターナル・プリゼンス";
  public const string ETERNAL_PRESENCE = "Etermal Presence";
  public const string COMMAND_ULTIMATE_FLARE = "天啓：アルティメット・フレア";
  public const string ULTIMATE_FLARE = "Ultimate Flare";
  public const string COMMAND_GOUGEKI = "剛・撃";
  public const string GOUGEKI = "Gougeki";
  public const string COMMAND_BUTOH_ISSEN = "舞踏・一閃";
  public const string BUTOH_ISSEN = "Butoh Issen";
  public const string COMMAND_GOD_SENSE = "神域の感性";
  public const string GOD_SENSE = "God Sense";
  public const string COMMAND_TIME_JUMP = "時間の跳躍";
  public const string TIME_JUMP = "Time Jump";
  public const string COMMAND_STARSWORD_ZETSUKEN = "スター・ソード【絶剣】";
  public const string STARSWORD_ZETSUKEN = "Starsword_zetsuken";
  public const string COMMAND_STARSWORD_REIKUU = "スター・ソード【零空】";
  public const string STARSWORD_REIKUU = "Starsword_reikuu";
  public const string COMMAND_STARSWORD_SEIEI = "スター・ソード【盛栄】";
  public const string STARSWORD_SEIEI = "Starsword_seiei";
  public const string COMMAND_STARSWORD_RYOKUEI = "スター・ソード【緑永】";
  public const string STARSWORD_RYOKUEI = "Starsword_ryokuei";
  public const string COMMAND_STARSWORD_FINALITY = "スター・ソード【終焉】";
  public const string STARSWORD_FINALITY = "Starsword_finality";
  // public const string COMMAND_STARSWORD_ZETSU_HOMURA = "スター・ソード【焔絶剣】";

  public const string COMMAND_SHADOW_BRINGER = "シャドウ・ブリンガー";
  public const string SHADOW_BRINGER = "Shadow Bringer";
  public const string COMMAND_SPHERE_OF_GLORY = "スフィア・オブ・グローリー";
  public const string SPHERE_OF_GLORY = "Sphere of Glory";
  public const string COMMAND_AURORA_PUNISHMENT = "オーロラ・パニッシュメント";
  public const string AURORA_PUNISHMENT = "Aurora Punishment";
  public const string COMMAND_INNOCENT_CIRCLE = "無縫：イノセント・サークル";
  public const string INNOCENT_CIRCLE = "Innocent Circle";
  public const string COMMAND_ATOMIC_THE_INFINITY_NOVA = "天鳴：アトミック・ザ・インフィニティ・ノヴァ";
  public const string ATOMIC_THE_INFINITY_NOVA = "Atomic the Infinity Nova";
  public const string COMMAND_ABSOLUTE_PERFECTION = "アブソリュート・パーフェクション";
  public const string ABSOLUTE_PERFECTION = "Absolute Perfection";
  public const string COMMAND_ASTRAL_GATE = "アストラル・ゲート";
  public const string ASTRAL_GATE = "Astral Gate";
  public const string COMMAND_DOUBLE_STANCE = "双極の構え";
  public const string DOUBLE_STANCE = "Double Stance";
  public const string COMMAND_DESTRUCTION_OF_TRUTH = "真実の破壊";
  public const string DESTRUCTION_OF_TRUTH = "Destruction of Truth";
  public const string COMMAND_CHAOTIC_SCHEMA = "カオティック・スキーマ";
  public const string CHAOTIC_SCHEMA = "Chaotic Schema";
  public const string COMMAND_OATH_OF_SEFINE = "セフィーネへの誓い";
  public const string OATH_OF_SEFINE = "Oath of Sefine";
  public const string OATH_OF_GOD = "Oath of God";
  public const string COMMAND_SPACETIME_INFLUENCE = "時空干渉";
  public const string SPACETIME_INFLUENCE = "Spacetime Influence";

  public const string COMMAND_HEAVEN_CLEANSING_FIRE = "天界の浄化炎";
  public const string COMMAND_SAINT_VOICE = "聖戦の呼び声";
  public const string COMMAND_BRILLIANT_LIFE = "輝ける生命";

  public const string COMMAND_BEZIER_TAIL_ATTACK = "ベジェ・テイルアタック";
  public const string COMMAND_MURYO_YATSU_ON = "無量八ツ怨";
  public const string COMMAND_WORD_OF_ONE = "ワード・オブ・ワン";

  public const string COMMAND_DEATH_VOICE = "デス・ヴォイス";
  public const string COMMAND_IKOROSHI = "射殺し";
  public const string COMMAND_MEIFU_CONTACT = "冥府接触";

  public const string COMMAND_SAINT_JUDGE = "聖者の裁き";
  public const string COMMAND_ANNEI_FUKUIN = "安寧の福音";
  public const string COMMAND_LIFE_STREAMING = "ライフ・ストリーミング";

  public const string COMMAND_GODWING_CLAW = "ゴッドウィング・クロー";
  public const string COMMAND_GOD_BREATH = "ゴッド・ブレス";
  public const string COMMAND_IRU_MEGIDO_BLAZE = "イル・メギド・ブレイズ";

  public const string COMMAND_GROUND_BREAKING = "大地の破壊";
  public const string COMMAND_COSMO_BURN = "コスモ・バーン";
  public const string COMMAND_REIJU_FALLTHUNDER = "霊獣フォール・サンダー";

  public const string LIFE_POINT = "Life Point";

  public const string COMMAND_ = "";

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
  #region "フェーズ【 Iー１ 】：エスミリア草原区域"
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

  public const string RING_OF_OSCURETE = @"Ring of the Oscurete";
  public const string MERGIZD_SOL_BLADE = "Mergizd Sol Blade";

  #endregion
  #region "フェーズ【 Iー１ 】：アンシェット街(武具合成)"
  public const string WOLF_CROSS = @"ウルフ製の舞踏衣";
  public const string KOUKAKU_ARMOR = @"甲殻の鎧";
  public const string STRIDE_WAR_SWORD = @"ストライド・ウォーソード";
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

  public const string RED_AMULET = "レッド・アミュレット";
  public const string BLUE_AMULET = "ブルー・アミュレット";
  public const string PURPLE_AMULET = "パープル・アミュレット";
  public const string GREEN_AMULET = "グリーン・アミュレット";
  public const string YELLOW_AMULET = "イエロー・アミュレット";

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
  public const string MAXCARN_X_BUSTER = @"Maxcarn the X-BUSTER";
  #endregion
  #region "ファージル宮殿(武具合成)"
  public const string DENDO_DRILL_AXE = "電磁式ドリル・アックス";
  public const string ATTACH_SPIRAL_ORB = "装着型スパイラルオーブ";
  public const string THIN_STEEL_BUCKLER = "薄型鋼鉄バックラー"; 
  public const string TETRA_EYE_BIGROD = "テトラ式・積層眼の大杖"; 
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
  public const string FITNESS_CROSS = "フィットネス・クロス";
  public const string SILK_ROBE = "シルク・ローブ";

  public const string ENSHOUTOU = "炎翔刀";
  public const string GALLANT_FEATHER_LANCE = "ガーラント・フェザー・ランス";
  public const string THUNDER_BREAK_AXE = "サンダー・ブレイク・アックス";
  public const string WRATH_SABEL_CLAW = "ラス・サーヴェル・クロー";
  public const string DORN_NAMELESS_ROD = "ドルン・ネームレス・ロッド";
  public const string FINESSE_IMPERIAL_BOOK = "フィネッセ・インペリアル・ブック";
  public const string INTRINSIC_FROZEN_ORB = "イントリンシック・フローズン・オーブ";
  public const string FORCEFUL_BASTARD_SWORD = "フォースフル・バスタード・ソード";
  public const string SHARPNEL_ARC_LANCER = "シャープネル・アーク・ランサー";
  public const string OGRE_KILL_BUSTER = "オーガ・キル・バスター";
  public const string EXPLODING_ASH_BOW = "エクスプローディング・アッシュ・ボウ";
  public const string EARTH_POWERED_STAFF = "アース・パワード・スタッフ";
  public const string BLACK_REFLECTOR_SHIELD = "ブラック・リフレクター・シールド";
  public const string ARANDEL_FORCE_ARMOR = "アランデル・フォース・アーマー";
  public const string WONDERING_BLESSED_CROSS = "ワンダリング・ブレスド・クロス";
  public const string SERANA_BRILLIANT_ROBE = "セラーナ・ブリリアント・ローブ";

  public const string JUNK_TARISMAN_POISON = "ジャンク・タリスマン『猛毒』";
  public const string JUNK_TARISMAN_SILENCE = "ジャンク・タリスマン『沈黙』";
  public const string JUNK_TARISMAN_BIND = "ジャンク・タリスマン『束縛』";
  public const string JUNK_TARISMAN_SLEEP = "ジャンク・タリスマン『睡眠』";
  public const string JUNK_TARISMAN_STUN = "ジャンク・タリスマン『スタン』";
  public const string JUNK_TARISMAN_PARALYZE = "ジャンク・タリスマン『麻痺』";
  public const string JUNK_TARISMAN_FROZEN = "ジャンク・タリスマン『凍結』";
  public const string JUNK_TARISMAN_FEAR = "ジャンク・タリスマン『恐怖』";
  public const string JUNK_TARISMAN_TEMPTATION = "ジャンク・タリスマン『誘惑』";
  public const string JUNK_TARISMAN_SLOW = "ジャンク・タリスマン『鈍化』";
  public const string JUNK_TARISMAN_DIZZY = "ジャンク・タリスマン『眩暈』";
  public const string JUNK_TARISMAN_SLIP = "ジャンク・タリスマン『出血』";
  public const string SIHAIRYU_SIKOTU = "支配竜の指骨";
  public const string OLDGLORY_TREE_KAREHA = "古代栄樹の枯れ葉";
  public const string GALEWIND_KONSEKI = "ゲイル・ウィンドの痕跡";
  public const string SIN_CRYSTAL_KAKERA = "シン・クリスタルの欠片";
  public const string EVERMIND_ZANSHI = "エバー・マインドの残思";

  public const string BRONZE_RING_KIBA = "青銅の腕輪『牙』";
  public const string BRONZE_RING_SASU = "青銅の腕輪『刺』";
  public const string BRONZE_RING_KU = "青銅の腕輪『駆』";
  public const string BRONZE_RING_NAGURI = "青銅の腕輪『殴』";
  public const string BRONZE_RING_TOBI = "青銅の腕輪『飛』";
  public const string BRONZE_RING_KARAMU = "青銅の腕輪『絡』";
  public const string BRONZE_RING_HANERU = "青銅の腕輪『跳』";
  public const string BRONZE_RING_TORU = "青銅の腕輪『補』";
  public const string BRONZE_RING_MIRU = "青銅の腕輪『視』";
  public const string BRONZE_RING_KATAI = "青銅の腕輪『堅』";
  public const string RED_KOKUIN = "赤の刻印";
  public const string BLUE_KOKUIN = "青の刻印";
  public const string PURPLE_KOKUIN = "紫の刻印";
  public const string GREEN_KOKUIN = "緑の刻印";
  public const string YELLOW_KOKUIN = "黄の刻印";
  public const string SUNLEAF_SEAL = "サンリーフ・シール";
  public const string SPIRIT_TUNOBUE = "精霊達の角笛";
  public const string DEPLETH_SEED_PIERCE = "デプレス・シードピアス";
  public const string SPARKLINE_EMBLEM = "スパークライン・エムブレム";
  public const string CHAINSHIFT_BOOTS = "チェーンシフト・ブーツ";
  public const string ASHED_COMPASS = "アッシュド・コンパス";
  public const string ENSEMBLE_FEATHER_HUT = "エンゼンブル・フェザー・ハット";
  public const string MIRAGE_PLASMA_EARRING = "ミラージュ・プラズマ・イヤリング";
  public const string PHOTON_ZEAL_CROWN = "フォトン・ジール・クラウン";
  public const string DEMONS_STAR_BRACELET = "デーモンズ・スター・ブレスレット";
  public const string MIST_WAVE_GAUNTLET = "ミスト・ウェーブ・ガントレット";
  public const string MEIUN_PRISM_BOX = "命運のプリズムボックス";
  public const string SPIRIT_CHALICE_OF_HEART = "心の聖杯【ハート】";
  public const string SQUARE_SINNEN = "スクエア【信念】";
  public const string SQUARE_BLESTAR = "スクエア【熟慮】";
  public const string SQUARE_CHISEI = "スクエア【知性】";
  public const string SQUARE_SENREN = "スクエア【洗練】";
  public const string SQUARE_SAIKI = "スクエア【才気】";
  public const string SQUARE_TANREN = "スクエア【鍛錬】";
  public const string SQUARE_KOKOH = "スクエア【孤高】";

  public const string VIRGIRANTE_HELLGATE_LANCE = "ヴィルジランデ・ヘルゲート・ランス";
  public const string MULLERHAIZEN_AGARTA_BOOK = "ミュラーヘイゼン・ブック・オブ・アガルタ";
  #endregion
  #region "港町コチューシェ(武具合成)"
  public const string SILENT_OLGA_CLAW = "サイレント・オルガ・クロー";
  public const string IRIDESCENT_CLOUD_FEATHER = "イリディッセント・クラウド・フェザー";
  public const string BRINSCALE_WAR_CROSS = "ブリンスケイル・ウォー・クロス";
  public const string GREAT_COMPOSITE_LANCE = "グレート・コンポジット・ランス";
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

  public const string FULLMETAL_ASTRAL_BLADE = "フルメタル・アストラル・ブレード";
  public const string STORM_FURY_LANCER = "ストーム・フュリー・ランサー";
  public const string WARLOAD_BASTARD_AXE = "ウォーロード・バスタード・アックス";
  public const string EARTH_SHARD_CLAW = "アース・シャード・クロー";
  public const string ENGAGED_FUTURE_ROD = "エンゲージド・フューチャー・ロッド";
  public const string ANCIENT_FAITHFUL_BOOK = "アンシエント・フェイスフル・ブック";
  public const string BLUE_SKY_ORB = "ブルー・スカイ・オーブ";
  public const string PRISMATIC_SOUL_BREAKER = "プリズマティック・ソウル・ブレイカー";
  public const string BLOOD_STUBBORN_SPEAR = "ブラッド・スタボーン・スピア";
  public const string ELEMENTAL_DISRUPT_AXE = "エレメンタル・ディスラプト・アックス";
  public const string LINGERING_FROST_SHOOTER = "リンガリング・フロスト・シューター";
  public const string INFERNAL_IMMORTAL_STAFF = "インファーナル・イモータル・スタッフ";
  public const string GRACEFUL_KINGS_BUCKLER = "グレイスフル・キングス・バックラー";
  public const string HARDED_INTENSITY_PLATE = "ハーデッド・インテンシティ・プレート";
  public const string SOLDIER_HATRED_CROSS = "ソルジャー・ヴィゴー・クロス";
  public const string WONDERERS_INVISIBLE_ROBE = "ワンダラーズ・インビジブル・ローブ";
  public const string ZELMAN_THE_ONSLAUGHT_BASTER = "ゼールマン・ジ・オンスロート・バスター";
  public const string LIFEGRACE_FORTUNE_STAFF = "ライフグレイス・フォーチュン・スタッフ";
  public const string WHITEVEIL_QUEENS_ROBE = "ホワイトヴェール・クイーンズ・ローブ";
  public const string KODAIEIJU_GREEN_LEAF = "古代栄樹の常緑葉";

  public const string STEEL_RING_POWER = "鋼の腕輪『パワー』";
  public const string STEEL_RING_SENSE = "鋼の腕輪『センス』";
  public const string STEEL_RING_TOUGH = "鋼の腕輪『タフ』";
  public const string STEEL_RING_ROCK = "鋼の腕輪『ロック』";
  public const string STEEL_RING_FAST = "鋼の腕輪『ファスト』";
  public const string STEEL_RING_SHARP = "鋼の腕輪『シャープ』";
  public const string STEEL_RING_HIGH = "鋼の腕輪『ハイ』";
  public const string STEEL_RING_DEEP = "鋼の腕輪『ディープ』";
  public const string STEEL_RING_BOUND = "鋼の腕輪『バウンド』";
  public const string STEEL_RING_EMOTE = "鋼の腕輪『エモート』";
  public const string RED_MASEKI = "赤の魔石";
  public const string BLUE_MASEKI = "青の魔石";
  public const string PURPLE_MASEKI = "紫の魔石";
  public const string GREEN_MASEKI = "緑の魔石";
  public const string YELLOW_MASEKI = "黄の魔石";
  public const string POWER_STEEL_RING_SOLID = "強芯鋼の腕輪『ソリッド』";
  public const string POWER_STEEL_RING_VAPOUR = "強芯鋼の腕輪『ヴェイパー』";
  public const string POWER_STEEL_RING_STRAIN = "強芯鋼の腕輪『ストレイン』";
  public const string POWER_STEEL_RING_TOLERANCE = "強芯鋼の腕輪『トレランス』";
  public const string POWER_STEEL_RING_ASCEND = "強芯鋼の腕輪『アセンド』";
  public const string POWER_STEEL_RING_INTERCEPT = "強芯鋼の腕輪『インターセプト』";
  public const string STARAIR_FLOATING_STONE = "星空の飛空石";
  public const string LIGHTBRIGHT_FLOATING_STONE = "聖光の浮遊石";
  public const string LUMINOUS_REFLECT_MIRROR = "ルミナス・リフレクト・ミラー";
  public const string BLACK_SPIRAL_NEEDLE = "ブラック・スパイラル・ニードル";
  public const string EMBLEM_OF_VALKYRIE = "エムブレム・オブ・ヴァルキリー";
  public const string EMBLEM_OF_NECROMANCY = "エムブレム・オブ・ネクロマンシー";

  public const string GATUH_HAWL_OF_GREAT = @"Gatuh Hawl of Great";
  public const string JUZA_ARESTINE_SLICER = @"Arestine-Slicer of Juza";
  #endregion
  #region "ツァルマンの里"
  public const string OHRAN_REDIAN_ROD = "オーラン・レーディアン・ロッド";
  public const string VIGILANT_FENCER_ROBE = "ヴィジラント・フェンサー・ローブ";
  public const string LION_EYES_BLADE = "ライオン・アイズ・ブレード";
  public const string TYORENSOU_ZANKYO_LANCE = "蝶連双・弦響槍";
  #endregion
  #region "フェーズ【 IIIー１ 】：ヴェルガス海底神殿"
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

  public const string SOLEMN_EMPERORS_SWORD = "ソレム・エンペラーズ・ソード";
  public const string MYSTIC_BLUE_JAVELIN = "ミスティック・ブルー・ジャベリン";
  public const string STRONG_FIRE_HELL_BASTARDAXE = "剛煉炎・ヘル・バスタードアックス";
  public const string AURA_BURN_CLAW = "オーラ・バーン・クロー";
  public const string MIND_STONEFEAR_ROD = "マインド・ストーンフィアー・ロッド";
  public const string DARKSUN_TRAGEDIC_BOOK = "ダークサン・トラジェディック・ブック";
  public const string CHROMATIC_FORGE_ORB = "クロマティック・フォージ・オーブ";
  public const string GOLDWILL_DESCENT_SOWRD = "ゴールドウィル・ディセント・ソード";
  public const string FLASH_VANISH_SPEAR = "フラッシュ・ヴァニッシュ・スピア";
  public const string VOLCANIC_BATTLE_BASTER = "ヴォルカニック・バトル・バスター";
  public const string WHITE_FIRE_CROSSBOW = "ホワイト・ファイア・クロスボウ";
  public const string ELDERSTAFF_OF_LIFEBLOOM = "エルダースタッフ・オブ・ライフブルーム";
  public const string DIMENSION_ZERO_SHIELD = "ディメンジョン・ゼロ・シールド";
  public const string HIGHWARRIOR_DRAGONMAIL = "ハイウォーリアー・ドラゴンメイル";
  public const string SWIFTCROSS_OF_REDTHUNDER = "スウィフトクロス・オブ・レッドサンダー";
  public const string BLADESHADOW_CROWDED_DRESS = "ブレードシャドウ・クラウディッド・ドレス";
  public const string BLACKROGUE_BLACKROGUE_AMBIDEXTARITY_DAGGER = "ブラックローグ・アンビデキシタリティ・ダガー";
  public const string HOLY_BLESSING_SHIELD = "ホーリー・ブレッシング・シールド";
  public const string LATA_GUARDIAN_RING = "ガーディアン・リング【ラタの導き】";
  public const string BLUEEYE_TEMPLE_PENDANT = "神殿騎士のペンダント【青眼】";
  public const string REDEYE_TEMPLE_PENDANT = "神殿騎士のペンダント【赤眼】";

  public const string SILVER_RING_GOUKA = "銀の腕輪【業火】";
  public const string SILVER_RING_TSUNAMI = "銀の腕輪【津波】";
  public const string SILVER_RING_AKISAME = "銀の腕輪【秋雨】";
  public const string SILVER_RING_NEPPA = "銀の腕輪【熱波】";
  public const string SILVER_RING_RAIMEI = "銀の腕輪【雷鳴】";
  public const string SILVER_RING_FUBUKI = "銀の腕輪【吹雪】";
  public const string SILVER_RING_GENJITSU = "銀の腕輪【幻日】";
  public const string SILVER_RING_TATSUMAKI = "銀の腕輪【竜巻】";
  public const string SILVER_RING_SYUNIJI = "銀の腕輪【主虹】";
  public const string SILVER_RING_KAGEROU = "銀の腕輪【陽炎】";

  public const string REDLIGHT_BRIGHTSTONE = "赤光の輝石";
  public const string BLUELIGHT_BRIGHTSTONE = "青光の輝石";
  public const string PURPLELIGHT_BRIGHTSTONE = "紫光の輝石";
  public const string GREENLIGHT_BRIGHTSTONE = "緑光の輝石";
  public const string YELLOWLIGHT_BRIGHTSTONE = "黄光の輝石";

  public const string SEAL_OF_REDEYE = "シール・オブ・レッドアイ";
  public const string SEAL_OF_BLUEEYE = "シール・オブ・ブルーアイ";
  public const string WINGED_LIGHTNING_BOOTS = "ウィングド・ライトニング・ブーツ";
  public const string SPELLCASTERS_LENS = "スペルキャスターズ・レンズ";
  public const string PEACEFUL_REBIRTH_CANDLE = "ピースフル・リボーン・キャンドル";
  public const string DESPAIR_BLACKANGEL_RING = "デスペアー・ブラックエンジェル・リング";
  public const string PHANTASMAL_INSIGHT_RUNE = "ファンタズマル・インサイト・ルーン";
  public const string SILVER_ETERNAL_SEED = "シルバー・エターナル・シード";
  public const string FIRELIEGE_AETHER_TALISMAN = "ファイアリージェ・エーテルタリスマン";
  public const string RAINBOW_MOON_COMPASS = "レインボー・ムーン・コンパス";
  public const string ANGEL_CONTRACT_SHEET = "天使の契約書";

  public const string ADILRING_OF_BLUE_BURN = @"AdilRing of the Blue Burn";
  public const string SHEZL_MYSTIC_FORTUNE = @"Shezl the Mystic Fortune";
  public const string FLOW_FUNNEL_OF_THE_ZVELDOZE = @"Flow Funnel of the Zveldose";

  #endregion
  #region "パルメティシア神殿(武具合成)"
  public const string HIGH_RANGER_BATTLE_BOW = "ハイレンジャー・バトルボウ";
  public const string DARMEKIUS_HARD_PLATE = "ダルメキアス・ハード・プレート";
  public const string HATENA_BIG_BOX = "ハテナ・ビッグ・ボックス";
  public const string SEE_SONG_FEBRIOL_BOOK = "シー・ソング・フェイブリオル・ブック";
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
  #region "フェーズ【 IVー２ 】：エデルガイゼン城"
  public const string EXTREME_SWORD = "エクストリーム・ソード";
  public const string EXTREME_LANCE = "エクストリーム・ランス";
  public const string EXTREME_AXE = "エクストリーム・アックス";
  public const string EXTREME_CLAW = "エクストリーム・クロー";
  public const string EXTREME_ROD = "エクストリーム・ロッド";
  public const string EXTREME_BOOK = "エクストリーム・ブック";
  public const string EXTREME_ORB = "エクストリーム・オーブ";
  public const string EXTREME_BOW = "エクストリーム・ボウ";
  public const string EXTREME_LARGE_STAFF = "エクストリーム・ラージ・スタッフ";
  public const string EXTREME_SHIELD = "エクストリーム・シールド";
  public const string EXTREME_ARMOR = "エクストリーム・アーマー";
  public const string EXTREME_CROSS = "エクストリーム・クロス";
  public const string EXTREME_ROBE = "エクストリーム・ローブ";

  public const string ETHEREAL_EDGE_BLADE = "イスリアル・エッジ・ブレード";
  public const string EVIL_ELIMINATION_LANCE = "イビル・エリミネイション・ランス";
  public const string PRISON_DESTRUCTION_AXE = "プリズン・デストラクション・アックス";
  public const string SHINGETSUEN_CLAW = "深月淵の爪";
  public const string GARGAN_BLAZE_ROD = "ガルガン・ブレイズ・ロッド";
  public const string JUNKEI_SHIKI_BOOK = "純景の四季本";
  public const string ALL_ELEMENTAL_ORB = "オール・エレメンタル・オーブ";
  public const string SYOKO_PALESTRIDE_BOW = "曙光・ペイルストライド・ボウ";
  public const string LABYRINTH_MAGE_BLUESTAFF = "迷宮魔導士の蒼き大杖";
  public const string MAJESTIC_FORCE_SHIELD = "マジェスティッド・フォース・シールド";
  public const string SHISO_GENSUI_KING_CROSS = "始祖元帥の舞踏衣【王授】";
  public const string ROBE_OF_COLORSTREAMING = "ローブ・オブ・カラーストリーミング";

  public const string RED_CRYSTAL = @"真紅のクリスタル";
  public const string BLUE_CRYSTAL = @"瑠璃のクリスタル";
  public const string PURPLE_CRYSTAL = @"紫苑のクリスタル";
  public const string GREEN_CRYSTAL = @"翡翠のクリスタル";
  public const string YELLOW_CRYSTAL = @"琥珀のクリスタル";
  public const string PLATINUM_RING_1 = @"白金の腕輪【白虎】";
  public const string PLATINUM_RING_2 = @"白金の腕輪【ヴァルキリー】";
  public const string PLATINUM_RING_3 = @"白金の腕輪【ナイトメア】";
  public const string PLATINUM_RING_4 = @"白金の腕輪【ナラシンハ】";
  public const string PLATINUM_RING_5 = @"白金の腕輪【朱雀】";
  public const string PLATINUM_RING_6 = @"白金の腕輪【ウロボロス】";
  public const string PLATINUM_RING_7 = @"白金の腕輪【ナインテイル】";
  public const string PLATINUM_RING_8 = @"白金の腕輪【ベヒモス】";
  public const string PLATINUM_RING_9 = @"白金の腕輪【青龍】";
  public const string PLATINUM_RING_10 = @"白金の腕輪【玄武】";

  public const string BLACK_DRAGON_FEATHER = "黒翼龍の羽";
  public const string RAGING_RESONANCE_RING = "レイジング・レゾナンス・リング";
  public const string LAGINA_DISTORTED_BRACER = "ラギナ・ディストーテッド・ブレイサー";
  public const string RIGID_WAVE_METALGUNTLET = "リジッド・ウェーブ・メタルガントレット";
  public const string ISOCHRON_FATED_LENS = "イソクロン・フェイテッド・レンズ";
  public const string DARKNESS_COIN = "暗黒の通貨";
  public const string HEART_SEEKERS_STONE = "ハート・シーカーズ・ストーン";
  public const string SUN_BREAKERS_STONE = "サン・ブレイカーズ・ストーン";
  public const string DANZAI_ANGEL_TALISMAN = "断罪天使の護符";

  public const string EZEKRIEL_IMPRINT_SIGIL_ARMOR = "Ezekriel the Imprinted-Armor of Sigil";
  public const string MERGIZD_DAV_AGITATED_BLADE = @"Mergizd DAV-Agitated Blade";
  public const string SHEZL_THE_VENTIEL_DARKMIRAGE_BOOK = @"Shezl the Ventiel-DarkMirage Book";
  public const string XEXXER_WORLD_MASTERY_GLOBE = @"Xexxer the World-Mastery Globe";
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
  public const string PURE_SINSEISUI = "神聖水";
  public const string PURE_VITALIRY_WATER = "活湧水";
  public const string KODAIEIJU_EDA = "古代栄樹の枝";
  public const string KIGAN_OFUDA = "祈願の御札";
  public const string SHADOW_MOON_KEY = "月影の鍵";
  public const string SUN_BURST_KEY = "日輪の鍵";
  public const string STAR_DUST_KEY = "星屑の鍵";
  public const string ORIGIN_ROAD_KEY = "原初の鍵";
  public const string RESIST_POISON_SUIT = "耐毒防護服";
  public const string ARTHARIUM_KEY = "アーサリウム工場跡地の鍵";
  public const string VELGUS_KEY1 = "ヴェルガス海底神殿の鍵【１】";
  public const string VELGUS_KEY2 = "ヴェルガス海底神殿の鍵【２】";
  public const string VELGUS_KEY3 = "ヴェルガス海底神殿の鍵【３】";
  public const string VELGUS2_KEY1 = "ヴェルガス海底神殿の鍵【静穏】";
  public const string VELGUS2_KEY2 = "ヴェルガス海底神殿の鍵【疾走】";
  public const string VELGUS2_KEY3 = "ヴェルガス海底神殿の鍵【順応】";
  public const string EDELGARZEN_KEY = "エデルガイゼン城：正面ゲートの鍵";
  public const string EDELGARZEN_KEY1 = "エデルガイゼン城の鍵【不屈】";
  public const string EDELGARZEN_KEY2 = "エデルガイゼン城の鍵【意志】";
  public const string EDELGARZEN_KEY3 = "エデルガイゼン城の鍵【無為】";
  public const string EDELGARZEN_KEY4 = "エデルガイゼン城の鍵【全知】";
  public const string UNKNOWN_OBJECT = "奇妙な物体";
  public const string MARBLE_STAR = "マーブル・スター";
  public const string ZHALMAN_NECKLACE = "ツァルマン里の首飾り";
  public const string ZEMULGEARS = "極剣：ゼムルギアス";
  public const string ARTIFACT_GENSEI = "古代の宝珠：厳正";
  public const string ARTIFACT_ZIHI = "古代の宝珠：慈悲";
  public const string ARTIFACT_MUSOU = "古代の宝珠：無双";
  public const string FIRE_ANGEL_TALISMAN = "炎授天使の護符";
  public const string EARRING_OF_LANA = "ラナのイヤリング";
  public const string PRECIOUS_SWORD = "宝剣 ？？？";
  public const string BLUESKY_STAR_FEATHER = "蒼き星空天の羽";
  public const string REDCOMET_STAR_CHARM = "朱き彗星のお守り";

  public const string LEGENDARY_FELTUS = @"神剣  フェルトゥーシュ";
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
  public const string SMALL_GREEN_POTION = "小さい緑ポーション";
  public const string NORMAL_RED_POTION = "普通の赤ポーション";
  public const string NORMAL_BLUE_POTION = "普通の青ポーション";
  public const string NORMAL_GREEN_POTION = "普通の緑ポーション";
  public const string LARGE_RED_POTION = "大きな赤ポーション";
  public const string LARGE_BLUE_POTION = "大きな青ポーション";
  public const string LARGE_GREEN_POTION = "大きな緑ポーション";
  public const string HUGE_RED_POTION = "巨大な赤ポーション";
  public const string HUGE_BLUE_POTION = "巨大な青ポーション";
  public const string HUGE_GREEN_POTION = "巨大な緑ポーション";
  public const string HQ_RED_POTION = "高品質の赤ポーション";
  public const string HQ_BLUE_POTION = "高品質の青ポーション";
  public const string HQ_GREEN_POTION = "高品質の緑ポーション";
  public const string THQ_RED_POTION = "最高品質の赤ポーション";
  public const string THQ_BLUE_POTION = "最高品質の青ポーション";
  public const string THQ_GREEN_POTION = "最高品質の緑ポーション";
  public const string PERFECT_RED_POTION = "完全な赤ポーション";
  public const string PERFECT_BLUE_POTION = "完全な青ポーション";
  public const string PERFECT_GREEN_POTION = "完全な緑ポーション";

  #region "アンシェット街(ポーション合成)"
  public const string POTION_RESIST_FIRE = @"耐熱ポーション";
  public const string CURE_SEAL = @"キュア・シール";
  public const string POTION_MAGIC_SEAL = @"マジック・シール薬";
  #endregion
  #region "ファージル宮殿(ポーション合成)"
  public const string POTION_RESIST_PLUS = "レジスト・ポーション・プラス";
  public const string TOTAL_HIYAKU_KASSEI = "統合秘薬【活性】";
  public const string TOTAL_HIYAKU_JOUSEI = "統合秘薬【上清】";
  public const string PATERMA_DISMAGIC_DRINK = "パテルマ・防魔ドリンク";
  #endregion
  #region "港町コチューシェ(ポーション合成)"
  public const string SOUKAI_DRINK_SS = "爽快ドリンク【Ｓ＆Ｓ】";
  public const string TUUKAI_DRINK_DD = "痛快ドリンク【Ｄ＆Ｄ】";
  public const string GOD_YORISHIRO_SOSEI = "神の依り代【蘇生】";
  public const string OLDTREE_GUARDIAN_MARK = "古代栄樹の護法印";
  #endregion
  #region "ツァルマンの里(ポーション合成)"
  public const string TRADITIONAL_POTION_DATTOU = "伝統霊薬【脱闘】";
  public const string TRADITIONAL_POTION_HEIGAN = "伝統霊薬【閉眼】";
  public const string LEKS_MYSTICAL_POTION = "レクス・ミスティカル・ポーション";
  public const string TEN_ON_MORI_MEGUMI = "天の恩・森の恵";
  #endregion
  #region "パルメティシア神殿(ポーション合成)"
  public const string KINDAN_TOKKOUYAKU = "禁断の特効薬";
  public const string SEAL_OF_ARCPOWER = "シール・オブ・アークパワー";
  public const string SEAL_OF_CHOSEN_POWER = "シール・オブ・チューズン・パワー";
  public const string SOUIN_HIYAKU_DISENCHANT = "僧院の秘薬【解呪】";
  #endregion
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
  // 成長剤（６階）
  public const string GROWTH_LIQUID6_STRENGTH = @"成長リキッドⅥ【力】";
  public const string GROWTH_LIQUID6_AGILITY = @"成長リキッドⅥ【技】";
  public const string GROWTH_LIQUID6_INTELLIGENCE = @"成長リキッドⅥ【知】";
  public const string GROWTH_LIQUID6_STAMINA = @"成長リキッドⅥ【体】";
  public const string GROWTH_LIQUID6_MIND = @"成長リキッドⅥ【心】";
  // 成長剤（７階）
  public const string GROWTH_LIQUID7_STRENGTH = @"成長リキッドⅦ【力】";
  public const string GROWTH_LIQUID7_AGILITY = @"成長リキッドⅦ【技】";
  public const string GROWTH_LIQUID7_INTELLIGENCE = @"成長リキッドⅦ【知】";
  public const string GROWTH_LIQUID7_STAMINA = @"成長リキッドⅦ【体】";
  public const string GROWTH_LIQUID7_MIND = @"成長リキッドⅦ【心】";
  #endregion
  #region "素材系ドロップアイテム"
  public const string COMMON_MANTIS_TAIEKI = "マンティスの体液";
  public const string COMMON_GREEN_SIKISO = "緑化色素";
  public const string COMMON_MANDORAGORA_ROOT = "マンドラゴラの根";
  public const string COMMON_WOLF_FUR = "ウルフの毛皮";
  public const string COMMON_KOKYU_LETHER_MATERIAL = "コキューの革素材"; // 宝箱

  public const string COMMON_ANT_ESSENCE = "アントのエキス";
  public const string COMMON_KATAME_TREE = "固めの木の枝";
  public const string COMMON_SUN_LEAF = "太陽の葉";
  public const string COMMON_WARM_NO_KOUKAKU = "ワームの甲殻";
  public const string COMMON_YELLOW_TAIEKI = "黄色の体液";
  public const string COMMON_RABBIT_MEAT = "ウサギの肉";
  public const string COMMON_ORANGE_MATERIAL = "オレンジ・マテリアル"; // 宝箱

  public const string COMMON_TOGETOGE_GRASS = "トゲトゲの草";
  public const string COMMON_ASH_EGG = "薄灰色の卵";
  public const string COMMON_RED_HOUSI = "赤い胞子";
  public const string COMMON_DOKUSO_NEEDLE = "毒成分の針";
  public const string COMMON_PLANTNOID_SEED = "プラントノイドの種";
  public const string COMMON_HORSE_HIZUME = "馬の蹄";

  //public const string COMMON_BEATLE_TOGATTA_TUNO = @"ビートルの尖った角";
  //public const string COMMON_HENSYOKU_KUKI = @"変色した茎";
  //public const string COMMON_INAGO = @"蝗";
  //public const string COMMON_SPIDER_SILK = @"スパイダーシルク";
  //public const string COMMON_YELLOW_MATERIAL = @"イエロー・マテリアル";
  //public const string COMMON_ALRAUNE_KAHUN = @"アルラウネの花粉";
  //public const string RARE_MARY_KISS = @"マリーキッス";

  //public const string COMMON_TAKA_FETHER = @"鷹の白羽";
  //public const string COMMON_SNEAK_UROKO = @"ヘビの鱗";
  //public const string COMMON_TOGE_HAETA_SYOKUSYU = @"刺の生えた触手";
  //public const string RARE_HYUI_SEED = @"ヒューイの種";

  //public const string COMMON_OOKAMI_FANG = @"狼の牙";
  //public const string COMMON_BRILLIANT_RINPUN = @"輝きの燐粉";
  //public const string COMMON_MIST_CRYSTAL = @"霧の結晶";
  //public const string RARE_MOSSGREEN_EKISU = @"モスグリーンのエキス";

  public const string COMMON_MACHINE_PARTS = "機械のパーツ";
  public const string COMMON_COLORFUL_BALL = "発色弾";
  public const string COMMON_SHARP_HAHEN = "鋭利な破片";
  public const string COMMON_BAT_FEATHER = "バットの翼";
  public const string COMMON_GLASS_SHARD = "ガラスの欠片";

  public const string COMMON_MECHANICAL_SHAFT = "メカニカル・シャフト";
  public const string COMMON_AMBER_MATERIAL = "アンバー素材";
  public const string COMMON_NEBARIKE_EKITAI = "粘り気のある液体";
  public const string COMMON_USUGATA_ENBAN = "薄型の円盤";
  public const string COMMON_HASSYADAI = "発射台";
  public const string COMMON_KYOUTEN_X = "経典Ｘ";

  public const string COMMON_SOLIDSTONE_MATERIAL = "硬石素材";
  public const string COMMON_JUNK_PARTS = "ジャンクパーツ";
  public const string COMMON_ELECT_BOLT = "電磁ボルト";
  public const string COMMON_GARGOYLE_EYE = "ガーゴイルの目玉";
  public const string COMMON_WATCHDOG_TONGUE = "番犬の舌";
  public const string COMMON_BUYOBUYO_MOEKASU = "ブヨブヨした燃えカス";

  public const string COMMON_BAKUHA_CHAKKAZAI = "爆破用の着火剤";
  public const string COMMON_SEKKAIKOU = "石灰鉱";
  public const string COMMON_CHROTIUM_MATERIAL = "クロティウム素材";
  public const string COMMON_SANKAKU_STEEL = "三角の鉄鋼材";
  public const string COMMON_PURPLE_BOTTOLE = "紫色の薬瓶";

  public const string COMMON_BOAR_MOMONIKU = "ボアのもも肉";
  public const string COMMON_MIST_LEAF = "霧草";
  public const string COMMON_NORMAL_SPORE_ESSENCE = "無加工のスポア成分";
  public const string COMMON_FROG_FRONTLEG = "フロッグの前足";
  public const string COMMON_SNAKE_EMPTYSHELL = "蛇の抜け殻";

  public const string COMMON_BEAR_LARGE_CLAW = "熊の大爪";
  public const string COMMON_FAIRY_POWDER = "妖精パウダー";
  public const string COMMON_BEAUTY_WHITEFEATHER = "美しい白羽";
  public const string COMMON_DRYAD_RINPUN = "ドライアドの鱗粉";
  public const string COMMON_HUNTER_TOOL = "ハンターの道具袋";
  public const string COMMON_BLACK_MIST_ESSENCE = "黒い成分の霧";

  public const string COMMON_ELEPHANT_LEGS = "象のデカイ足";
  public const string COMMON_ELEMENTAL_KONA = "精霊の粉";
  public const string COMMON_LAPTOR_FUR = "ラプターの毛皮";
  public const string COMMON_SHARPNESS_TIGER_TOOTH = @"鋭く尖った虎牙";
  public const string COMMON_THORN_ELEMENT = "茨の冠素材";
  public const string COMMON_DORO_YOUKAIEKI = "ドロっとした溶解液";

  public const string COMMON_YOUKAI_MIKI = "怪気をまとった幹";
  public const string COMMON_DANPEN_OF_GOFU = "護符の切れ端";
  public const string COMMON_GOTUGOTU_BIGTREE = "ゴツゴツした大木";
  public const string COMMON_MARY_KISS = "マリーキッス";
  public const string COMMON_HUGE_HOHONIKU = "大型のほほ肉";

  public const string COMMON_MAGIC_HORN = "魔力ホーン";
  public const string COMMON_THREE_FEATHER = "三枚羽";
  public const string COMMON_YELLOW_DOROTSUCHI = "黄色いドロ土";
  public const string COMMON_RED_DOROTSUCHI = "赤いドロ土";
  public const string COMMON_WINDMAN_SEAL = "風民の印";

  public const string COMMON_AIRORIGIN_KIHO = "空源の気泡";
  public const string COMMON_HENSYOKU_KOKE = "変色ゴケ";
  public const string COMMON_KIRAMEKU_GOLDHORN = "煌めく黄金角";
  public const string COMMON_MYSTERY_SCROLL = "不思議な巻物";
  public const string COMMON_BIRD_OUGI = "バード扇子";
  public const string COMMON_BLUECOLOR_EYE = "青色の眼球";
  public const string COMMON_WHITECOLOR_EYE = "白色の眼球";

  public const string COMMON_CURTAIN_MATERIAL = "カーテン素材";
  public const string COMMON_MEGANE_MATERIAL = "博識メガネの素材";
  public const string COMMON_ARTHARIUM_JEWEL = "アーサリウム宝石";
  public const string COMMON_KITSUNE_TAIL = "狐の尻尾";
  public const string COMMON_LION_FUR = "ライオンの毛皮";
  public const string COMMON_WHITE_HIDUME = "白い蹄";
  public const string COMMON_TOUMEI_KESSYO = "無色透明の結晶";

  public const string COMMON_PARTIMIUM_MATERIAL = "パルティミウム素材";
  public const string COMMON_HUGE_BOOK = "分厚い読み物";
  public const string COMMON_GUNPOWDER = "火薬物";
  public const string COMMON_SILENT_WHISTLE = "音のしない笛";
  public const string COMMON_STEEL_BATON = "鋼鉄のバトン";
  public const string COMMON_PURE_SILVER = "純銀";

  public const string COMMON_SPEEDARROW_TOOL = "早矢の生成ツール";
  public const string COMMON_OVAL_GEAR = "オーバル・ギア";
  public const string COMMON_APLITOS_BONE = "アピュリトスの軟骨";
  public const string COMMON_MUKAKOU_SEKIEI = "無加工の石英";
  public const string COMMON_HOUDAN_SHARD = "砲弾の破片";
  public const string COMMON_DEATH_CLOVER = "デス・クローバー";

  public const string COMMON_DAGGERFISH_UROKO = "牙魚の鱗";
  public const string COMMON_MANTA_HARA = "マンタの腹";
  public const string COMMON_BLUE_MAGATAMA = "青の勾玉";
  public const string COMMON_KURIONE_ZOUMOTU = "クリオネの臓物";
  public const string COMMON_RENEW_AKAMI = "新鮮な赤身";
  public const string COMMON_ROSE_SEKKAI = "ローズ石灰";

  public const string COMMON_WASI_BLUE_FEATHER = "鷲の青羽";
  public const string COMMON_HANTOUMEI_ROCK = "半透明の奇麗な石";
  public const string COMMON_EIGHTEIGHT_KUROSUMI = "エイト・エイトの黒墨";
  public const string COMMON_BLACK_GESO = "黒ずんだゲソ";
  public const string COMMON_BIGAXE_TOP = "デカ斧の先端";
  public const string COMMON_GANGAME_EGG = "頑亀の卵";
  public const string COMMON_JUMP_MATERIAL = "跳躍材料";
  public const string COMMON_KYOZIN_MUNENIKU = "強靭なムネ肉";
  
  public const string COMMON_NANAIRO_SYOKUSYU = "七色の触手";
  public const string COMMON_SEA_MO = "深海の藻";
  public const string COMMON_SERPENT_UROKO = "サーペントの鱗";
  public const string COMMON_AYASHII_NENNEKI_ITO = "怪しい色の粘液糸";
  public const string COMMON_GOTUGOTU_KARA = "ゴツゴツした殻";
  public const string COMMON_SOFT_BIG_HIRE = "柔らかい大ヒレ";
  public const string COMMON_BIG_STONE = "ビッグ・ストーン";
  public const string COMMON_TAIRYO_FISH = "大量の魚群";

  public const string COMMON_UNKNOWN_BOX = "正体不明の箱";
  public const string COMMON_PUREWHITE_KIMO = "真っ白なキモ";
  public const string COMMON_SHRIMP_DOTAI = "エビの胴体";
  public const string COMMON_KOUSITUKA_MATERIAL = "硬質化素材";
  public const string COMMON_AOSAME_UROKO = "青鮫の鱗";
  public const string RARE_JOE_TONGUE = "ジョーの舌";
  public const string COMMON_EMBLEM_KNIGHT = "騎士達の紋章";

  public const string COMMON_SEA_WATER = "純正の海水";
  public const string COMMON_BLACKSAME_TOOTH = "黒鮫の剣歯";
  public const string COMMON_MYSTERIOUS_KARA = "不思議な形状の殻";
  public const string COMMON_CURSED_ITO = "呪いの糸";
  public const string COMMON_CHINMI_FISH = "珍味の魚介類";
  public const string COMMON_SEA_MUSICBOX = "海のオルゴール";

  //public const string COMMON_SIPPUU_HIRE = @"疾魚のヒレ";
  //public const string COMMON_WHITE_MAGATAMA = @"白の勾玉";
  //public const string COMMON_BLUEWHITE_SHARP_TOGE = @"青白の鋭いトゲ";
  //public const string RARE_TRANSPARENT_POWDER = @"透明なパウダー";

  //public const string COMMON_SEA_WASI_KUTIBASI = @"海鷲のくちばし";
  //public const string RARE_JOE_ARM = @"ジョーの腕";
  //public const string RARE_JOE_LEG = @"ジョーの足";

  //public const string COMMON_PURE_WHITE_BIGEYE = @"真っ白な大目玉";
  //public const string COMMON_SAME_NANKOTSU = @"サメの軟骨";
  //public const string COMMON_HALF_TRANSPARENT_ROCK_ASH = @"半透明の石灰";
  //public const string RARE_SEKIKASSYOKU_HASAMI = @"赤褐色のハサミ";

  //public const string COMMON_AOSAME_KENSHI = @"青鮫の剣歯";
  //public const string COMMON_EIGHTEIGHT_KYUUBAN = @"エイト・エイトの吸盤";

  public const string COMMON_HUNTER_SEVEN_TOOL = "ハンターの七つ道具";
  public const string COMMON_BEAST_KEGAWA = "猛獣の毛皮";
  public const string RARE_BLOOD_DAGGER_KAKERA = "血塗られたダガーの破片";
  public const string COMMON_SABI_BUGU = "錆付いたガラクタ武具";
  public const string RARE_MEPHISTO_BLACKLIGHT = "メフィストの黒い灯";
  public const string COMMON_STEAM_POMP = "蒸気ポンプ";

  public const string COMMON_SEEKER_HEAD = "シーカーの頭蓋骨";
  public const string RARE_ESSENCE_OF_DARK = "エッセンス・オブ・ダーク";
  public const string COMMON_EXECUTIONER_ROBE = "執行人の汚れたローブ";
  public const string COMMON_NEMESIS_ESSENCE = "ネメシス・エッセンス";
  public const string RARE_MASTERBLADE_FIRE = "マスターブレイドの残り火";
  //public const string RARE_MASTERBLADE_KAKERA = "マスターブレイドの破片";
  public const string COMMON_GREAT_JEWELCROWN = "豪華なジュエルクラウン";
  public const string COMMON_GOUKIN_MATERIAL = "合金製素材";

  public const string RARE_ESSENCE_OF_SHINE = "エッセンス・オブ・シャイン";
  //public const string COMMON_KUMITATE_TENBIN = "組み立て素材　天秤";
  public const string COMMON_KUMITATE_TENBIN_DOU = "組み立て素材　天分銅";
  //public const string COMMON_KUMITATE_TENBIN_BOU = "組み立て素材　天秤棒";
  public const string RARE_DEMON_HORN = "デーモンホーン";
  public const string COMMON_WYVERN_BONE = "ワイバーン・ボーン";
  public const string RARE_ESSENCE_OF_FLAME = "エッセンス・オブ・フレイム";
  public const string RARE_BLACK_SEAL_IMPRESSION = "黒の印鑑";
  public const string COMMON_HIGH_ESTORMIUM_MATERIAL = "高純度エストルミウム素材";

  public const string COMMON_ONRYOU_HAKO = "怨霊箱";
  public const string RARE_ANGEL_SILK = "天使のシルク";
  public const string RARE_CHAOS_SIZUKU = "混沌の雫";
  public const string RARE_DREAD_EXTRACT = "ドレッド・エキス";
  public const string RARE_DOOMBRINGER_KAKERA = "ドゥームブリンガーの欠片";
  //public const string RARE_DOOMBRINGER_TUKA = "ドゥームブリンガーの柄";
  public const string COMMON_KOKU_THUNDER_SIRUSI = "刻雷印";
  public const string COMMON_TENNEN_JISYAKU = "天然の磁石";

  public const string COMMON_VOID_BOU = "虚空棒";
  public const string COMMON_ESSENCE_OF_WIND = "エッセンス・オブ・ウィンド";
  public const string COMMON_INNOCENCE_ESSENCE = "イノセンス・エッセンス";
  public const string COMMON_JUNKAN_MAHU_GU = "循環の魔封具";
  public const string COMMON_UNRESOLVED_MATERIAL = "未解明の物質";
  #endregion
  #region "ラベル"
  // 素材判別文字
  public const string DESCRIPTION_SELL_ONLY = @"【売却専用品】" + "\r\n";
  public const string DESCRIPTION_BATTLE_ONLY = @"【戦闘中専用】" + "\r\n";
  public const string DESCRIPTION_EQUIP_MATERIAL = @"【武具素材】" + "\r\n";
  public const string DESCRIPTION_POTION_MATERIAL = @"【ポーション素材】" + "\r\n";
  public const string DESCRIPTION_FOOD_MATERIAL = @"【食材】" + "\r\n";
  public const string DESCRIPTION_WEAPON = @"【武器】";
  public const string DESCRIPTION_SHIELD = @"【盾】";
  public const string DESCRIPTION_ARMOR = @"【防具】";
  public const string DESCRIPTION_ACCESSORY = @"【アクセサリ】";
  public const string DESCRIPTION_POTION = @"【消耗品】";
  public const string DESCRIPTION_BLUEORB = @"【専用品】";
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
  public const string WONDER_SEED = "Wonder Seed";
  public const string WONDER_SEED_JP = "ワンダー シード";
  public const string DAUNTLESS_HORSE = "Dauntless Horse";
  public const string DAUNTLESS_HORSE_JP = "果敢な戦馬";
  public const string SCREAMING_RAFFLESIA = "Screaming Rafflesia";
  public const string SCREAMING_RAFFLESIA_JP = "叫喚のラフレシア";
  public const string SCREAMING_RAFFLESIA_JP_VIEW = "【草原の女王】\r\n叫喚のラフレシア";

  public const string DEBRIS_SOLDIER = "Debris Soldier";
  public const string DEBRIS_SOLDIER_JP = "ガラクタ機甲兵";
  public const string MAGICAL_AUTOMATA = "Magical Automata";
  public const string MAGICAL_AUTOMATA_JP = "魔道師団のオートマータ";
  public const string KILLER_MACHINE = "Killer Machine";
  public const string KILLER_MACHINE_JP = "キラー マシン";
  public const string STINKY_BAT = "Stinky Bat";
  public const string STINKY_BAT_JP = "泥臭いコウモリ";
  public const string ANTIQUE_MIRROR = "Antique Mirror";
  public const string ANTIQUE_MIRROR_JP = "アンティーク ミラー";
  public const string MECH_HAND = "Mech Hand";
  public const string MECH_HAND_JP = "メカ ハンド";
  public const string ABSENCE_MOAI = "Absence Moai";
  public const string ABSENCE_MOAI_JP = "無表情のモアイ";
  public const string ACID_SCORPION = "Acid Scorpion";
  public const string ACID_SCORPION_JP = "アシッド スコーピオン";
  public const string NEJIMAKI_KNIGHT = "Nejimaki Knight";
  public const string NEJIMAKI_KNIGHT_JP = "ネジマキ ナイト";
  public const string AIMING_SHOOTER = "Aiming Shooter";
  public const string AIMING_SHOOTER_JP = "エイミング シューター";
  public const string CULT_BLACK_MAGICIAN_JP = "教団の闇術師";
  public const string CULT_BLACK_MAGICIAN = "Cult Black Magician";
  public const string STONE_GOLEM = "Stone Golem";
  public const string STONE_GOLEM_JP = "ストーン ゴーレム";
  public const string JUNK_VULKAN = "Junk Vulkan";
  public const string JUNK_VULKAN_JP = "ジャンク バルカン";
  public const string LIGHTNING_CLOUD = "Lightning Cloud";
  public const string LIGHTNING_CLOUD_JP = "ライトニング クラウド";
  public const string SILENT_GARGOYLE = "Silent Gargoyle";
  public const string SILENT_GARGOYLE_JP = "サイレント ガーゴイル";
  public const string GATE_HOUND = "Gate Hound";
  public const string GATE_HOUND_JP = "門番犬";
  public const string PLAY_FIRE_IMP_JP = "炎遊びのインプ";
  public const string PLAY_FIRE_IMP = "Play-Fire Imp";
  public const string WALKING_TIME_BOMB = "Walking Time-Bomb";
  public const string WALKING_TIME_BOMB_JP = "歩行式時限爆弾";
  public const string EARTH_ELEMENTAL = "Earth Elemental";
  public const string EARTH_ELEMENTAL_JP = "アース・エレメンタル";
  public const string DEATH_DRONE = "Death Drone";
  public const string DEATH_DRONE_JP = "デス ドローン";
  public const string ASSULT_SCARECROW = "Assult Scarecrow";
  public const string ASSULT_SCARECROW_JP = "襲いかかるスケアクロウ";
  public const string MAD_DOCTOR = "Mad Doctor";
  public const string MAD_DOCTOR_JP = "マッド ドクター";
  public const string MAGICAL_HAIL_GUN = "Magical Hail-Gun";
  public const string MAGICAL_HAIL_GUN_JP = "魔法雹穴銃";
  public const string MAGICAL_HAIL_GUN_JP_VIEW = "【　暴走機動隊　】\r\n魔法雹穴銃";
  public const string THE_GALVADAZER = "Galvadazer, The Over-Boost-Destructor";
  public const string THE_GALVADAZER_JP = "暴走破壊者：ガルヴァデイザー";
  public const string THE_GALVADAZER_JP_VIEW = "【　暴走破壊者　】\r\nガルヴァデイザー";

  public const string CHARGED_BOAR = "Charged Boar";
  public const string CHARGED_BOAR_JP = "突撃ボア";
  public const string WOOD_ELF = "Wood Elf";
  public const string WOOD_ELF_JP = "ウッド エルフ";
  public const string POISON_FLOG = "Poison Flog";
  public const string STINKED_SPORE = "Stinked Spore";
  public const string STINKED_SPORE_JP = "生臭いスポア";
  public const string POISON_FLOG_JP = "ポイズン フロッグ";
  public const string GIANT_SNAKE = "Giant Snake";
  public const string GIANT_SNAKE_JP = "ジャイアント スネーク";
  public const string SAVAGE_BEAR = "Savage Bear";
  public const string SAVAGE_BEAR_JP = "野蛮な熊";
  public const string INNOCENT_FAIRY = "Innocent Fairy";
  public const string INNOCENT_FAIRY_JP = "イノセント フェアリー";
  public const string MYSTIC_DRYAD = "Mystic Dryad";
  public const string MYSTIC_DRYAD_JP = "神秘的なドライアド";
  public const string SPEEDY_FALCON = "Speedy Falcon";
  public const string SPEEDY_FALCON_JP = "スピーディ ファルコン";
  public const string WOLF_HUNTER = "Wolf Hunter";
  public const string WOLF_HUNTER_JP = "ウルフ・ハンター";
  public const string FOREST_PHANTOM = "Forest Phantom";
  public const string FOREST_PHANTOM_JP = "森に潜む幻影";
  public const string EXCITED_ELEPHANT = "Excited Elephant";
  public const string EXCITED_ELEPHANT_JP = "興奮するエレファント";
  public const string SYLPH_DANCER = "Sylph Dancer";
  public const string SYLPH_DANCER_JP = "シルフ ダンサー";
  public const string GATHERING_LAPTOR = "Gathering Laptor";
  public const string GATHERING_LAPTOR_JP = "ギャザリング ラプター";
  public const string RAGE_TIGER = "Rage Tiger";
  public const string RAGE_TIGER_JP = "レイジ・タイガー";
  public const string THORN_WARRIOR = "Thorn Warrior";
  public const string THORN_WARRIOR_JP = "茨の戦士";
  public const string MUDDLED_PLANT = "Muddled Plant";
  public const string MUDDLED_PLANT_JP = "腐敗したプラント";
  public const string FLANSIS_KNIGHT = "Flansis Knight";
  public const string FLANSIS_KNIGHT_JP = "フランシスの騎士";
  public const string MIST_PYTHON = "Mist Python";
  public const string MIST_PYTHON_JP = "ミスト パイソン";
  public const string TOWERING_ENT = "Towering Ent";
  public const string TOWERING_ENT_JP = "そびえ立つエント";
  public const string POISON_MARY = "Poison Mary";
  public const string POISON_MARY_JP = "ポイズン マリー";
  public const string DISTURB_RHINO = "Disturb Rhino";
  public const string DISTURB_RHINO_JP = "ディスターブ リノ";
  public const string FLANSIS_OF_THE_FOREST_QUEEN = "Flansis, The Queen of Verdant";
  public const string FLANSIS_OF_THE_FOREST_QUEEN_JP = "新緑の女王：フランシス";
  public const string FLANSIS_OF_THE_FOREST_QUEEN_JP_VIEW = "【　新緑の女王　】\r\nフランシス";

  public const string WISDOM_CENTAURUS = "Wisdom Centaurus";
  public const string WISDOM_CENTAURUS_JP = "知的なケンタウロス";
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
  public const string THE_WHITE_LAVA_EYE = "The White-Lava Eye";
  public const string THE_WHITE_LAVA_EYE_JP = "ホワイト ラーヴァ アイ";
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
  public const string MAJESTIC_CLOUD = "Magiestic Cloud";
  public const string MAJESTIC_CLOUD_JP = "マジェスティック クラウド";
  public const string HARDENED_GRIFFIN = "Hardened Griffin";
  public const string HARDENED_GRIFFIN_JP = "硬化体質のグリフィン";
  public const string PRISMA_SPHERE = "Prisma Sphere";
  public const string PRISMA_SPHERE_JP = "プリズマ スフィア";
  public const string MOVING_CANNON = "Moving Cannon";
  public const string MOVING_CANNON_JP = "動き回る砲台";
  public const string VEIL_FORTUNE_WIZARD = "Veil Fortune Wizard";
  public const string VEIL_FORTUNE_WIZARD_JP = "ヴェイル フォーチュン ウィザード";
  public const string LIGHT_THUNDER_LANCEBOLTS = "Light-Thunder Lancebolts";
  public const string LIGHT_THUNDER_LANCEBOLTS_JP = "雷光ランスボルツ";
  public const string LIGHT_THUNDER_LANCEBOLTS_JP_VIEW = "【　裁きの鳴動　】\r\n雷光ランスボルツ";
  public const string THE_YODIRIAN = "Yodirian, The Way of Tranquil-Line";
  public const string THE_YODIRIAN_JP = "静穏を受け継ぎし者：ヨーディリアン";
  public const string THE_YODIRIAN_JP_VIEW = "【　静穏を受け継ぎし者　】\r\nヨーディリアン";

  // ヴェルガスの海底神殿
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
  public const string BEAUTY_SEA_LILY = "Beauty Sea-Lily";
  public const string BEAUTY_SEA_LILY_JP = "美しきウミユリ";
  public const string DEVIL_STAR_DEATH_FLODIETE = "Devil-Star Death-Flodiete";
  public const string DEVIL_STAR_DEATH_FLODIETE_JP = "深海の魔族：デス・フローディーテ";
  public const string DEVIL_STAR_DEATH_FLODIETE_JP_VIEW = "【　深海の魔族　】\r\nデス・フローディーテ";
  public const string LIMBER_SEAEAGLE = "Limber SeaEagle";
  public const string LIMBER_SEAEAGLE_JP = "しなやかな海鷲";
  public const string FLUFFY_CORAL = "Fluffy Coral";
  public const string FLUFFY_CORAL_JP = "フラッフィ コーラル";
  public const string BLACK_OCTOPUS = "Black Octopus";
  public const string BLACK_OCTOPUS_JP = "ブラック オクトパス";
  public const string STEAL_SQUID = "Steal Squid";
  public const string STEAL_SQUID_JP = "忍び寄るスキッド";
  public const string PROUD_VIKING = "Proud Viking";
  public const string PROUD_VIKING_JP = "誇りあるバイキング";
  public const string GAN_GAME = "GanGame";
  public const string GAN_GAME_JP = "頑亀";
  public const string JUMPING_KAMASU = "Jumping Kamasu";
  public const string JUMPING_KAMASU_JP = "ジャンピング カマス";
  public const string RECKLESS_WALRUS = "Reckless Walrus";
  public const string RECKLESS_WALRUS_JP = "猛突進ウォーラス";
  public const string THE_BIGHAND_OF_KRAKEN = "The Big-Hand of Kraken";
  public const string THE_BIGHAND_OF_KRAKEN_JP = "クラーケンの大手";
  public const string THE_BIGHAND_OF_KRAKEN_JP_VIEW = "【　大海原の主　】\r\nクラーケンの大手";
  public const string WRECHED_ANEMONE = "Wreched Anemone";
  public const string WRECHED_ANEMONE_JP = "浅ましいアネモネ";
  public const string DEEPSEA_HAND = "DeepSea Hand";
  public const string DEEPSEA_HAND_JP = "深海の手";
  public const string ASSULT_SERPENT = "Assult Serpent";
  public const string ASSULT_SERPENT_JP = "襲いかかるサーペント";
  public const string GIANT_SEA_SPIDER = "Giant Sea-Spider";
  public const string GIANT_SEA_SPIDER_JP = "巨大なウミグモ";
  public const string ESCORT_HERMIT_CLUB = "Escort Hermit-Club";
  public const string ESCORT_HERMIT_CLUB_JP = "護衛隊 ハーミットクラブ";
  public const string MOGUL_MANTA = "Mogul Manta";
  public const string MOGUL_MANTA_JP = "モーグル マンタ";
  public const string GLUTTONY_COELACANTH = "Gluttony Coelacanth";
  public const string GLUTTONY_COELACANTH_JP = "大食いシーラカンス";
  public const string FEROCIOUS_WHALE = "Ferocious Whale";
  public const string FEROCIOUS_WHALE_JP = "フェロシアス ホエール";
  public const string GUARDIAN_ROYAL_NAGA = "Guardian Royal Naga";
  public const string GUARDIAN_ROYAL_NAGA_JP = "ガーディアン ロイヤル ナーガ";
  public const string GUARDIAN_ROYAL_NAGA_JP_VIEW = "【　聖域を護りし者　】\r\nガーディアン ロイヤル ナーガ";
  public const string WEEPING_MIST = "Weeping Mist";
  public const string WEEPING_MIST_JP = "ウィーピング ミスト";
  public const string AMBUSH_ANGLERFISH = "Ambush Anglerfish";
  public const string AMBUSH_ANGLERFISH_JP = "待ち伏せアンコウ";
  public const string EMERALD_LOBSTER = "Emerald Lobster";
  public const string EMERALD_LOBSTER_JP = "エメラルドのエビ";
  public const string STICKY_STARFISH = "Sticky Starfish";
  public const string STICKY_STARFISH_JP = "スティッキー スターフィッシュ";
  public const string RAMPAGE_BIGSHARK = "Rampage BigShark";
  public const string RAMPAGE_BIGSHARK_JP = "暴れ大ザメ";
  public const string BIGMOUSE_JOE = "Bigmouse Joe";
  public const string BIGMOUSE_JOE_JP = "ビッグマウス ジョー";
  public const string SEA_STAR_KNIGHT = "Sea-Star Knight";
  public const string SEA_STAR_KNIGHT_JP = "海星騎士";
  public const string SEA_ELEMENTAL = "Sea Elemental";
  public const string SEA_ELEMENTAL_JP = "シー エレメンタル";
  public const string EDGED_HIGH_SHARK = "Edged High-Shark";
  public const string EDGED_HIGH_SHARK_JP = "エッジド ハイシャーク";
  public const string THOUGHTFUL_NAUTILUS = "Thoughtful Nautilus";
  public const string THOUGHTFUL_NAUTILUS_JP = "思慮深いノーチラス";
  public const string GHOST_SHIP = "Ghost Ship";
  public const string GHOST_SHIP_JP = "幽霊船";
  public const string DEFENSIVE_DATSU = "Defensive Datsu";
  public const string DEFENSIVE_DATSU_JP = "身構えるダツ";
  public const string SEA_SONG_MARMAID = "Sea-Song Marmaid";
  public const string SEA_SONG_MARMAID_JP = "海の歌姫マーメイド";
  public const string BRILLIANT_SEA_PRINCE_1 = "Sea-Star-Prince Leva-Laul ";
  public const string BRILLIANT_SEA_PRINCE_1_JP = "海星の王子：レーヴァ・ラウル　";
  public const string BRILLIANT_SEA_PRINCE_1_JP_VIEW = "【　海星の王子　】\r\nレーヴァ・ラウル　";
  public const string SHELL_THE_SWORD_KNIGHT = "Shell the Sword-Knight";
  public const string SHELL_THE_SWORD_KNIGHT_JP = "シェル ザ ソードナイト";
  public const string SHELL_THE_SWORD_KNIGHT_JP_VIEW = "【　海星源の護り手　】\r\nシェル ザ ソードナイト";
  public const string SEA_STAR_KNIGHT_AEGIR = "Sea-StarKnight Aegir";
  public const string SEA_STAR_KNIGHT_AEGIR_JP = "海星騎士・エーギル";
  public const string SEA_STAR_KNIGHT_AEGIR_JP_VIEW = "【　天秤を携えし者　】\r\n海星騎士・エーギル";
  public const string SEA_STAR_KNIGHT_AMARA = "Sea-StarKnight Amara";
  public const string SEA_STAR_KNIGHT_AMARA_JP = "海星騎士・アマラ";
  public const string SEA_STAR_KNIGHT_AMARA_JP_VIEW = "【　天秤を見据えし者　】\r\n海星騎士・アマラ";
  public const string ORIGIN_STAR_CORAL_QUEEN_1 = "Sea-Star-Queen Meril-Sieju ";
  public const string ORIGIN_STAR_CORAL_QUEEN_1_JP = "源星の女王：メリル・セイジュ　";
  public const string ORIGIN_STAR_CORAL_QUEEN_1_JP_VIEW = "【源星の女王】メリル・セイジュ　";
  public const string JELLY_EYE_BRIGHT_RED = "Jelly-Eye Bright-Red";
  public const string JELLY_EYE_BRIGHT_RED_JP = "ジェリーアイ・熱光";
  public const string JELLY_EYE_BRIGHT_RED_JP_VIEW = "【巨眼の監視者】\r\nジェリーアイ・熱光";
  public const string JELLY_EYE_DEEP_BLUE = "Jelly-Eye Deep-Blue";
  public const string JELLY_EYE_DEEP_BLUE_JP = "ジェリーアイ・流冷";
  public const string JELLY_EYE_DEEP_BLUE_JP_VIEW = "【巨眼の監視者】\r\nジェリーアイ・流冷";
  public const string BRILLIANT_SEA_PRINCE = "Sea-Star-Prince Leva-Laul";
  public const string BRILLIANT_SEA_PRINCE_JP = "海星の王子：レーヴァ・ラウル";
  public const string BRILLIANT_SEA_PRINCE_JP_VIEW = "【　海星の王子　】レーヴァ・ラウル";
  public const string ORIGIN_STAR_CORAL_QUEEN = "Sea-Star-Queen Meril-Sieju";
  public const string ORIGIN_STAR_CORAL_QUEEN_JP = "源星の女王：メリル・セイジュ";
  public const string ORIGIN_STAR_CORAL_QUEEN_JP_VIEW = "【源星の女王】メリル・セイジュ";
  public const string VELGAS_THE_KING_OF_SEA_STAR = "Sea-Star-King Velgas-Olzeta";
  public const string VELGAS_THE_KING_OF_SEA_STAR_JP = "海星源の王：ヴェルガス・オルゼタ";
  public const string VELGAS_THE_KING_OF_SEA_STAR_JP_VIEW = "【　海星源の王】ヴェルガス・オルゼタ";
  public const string GROUND_VORTEX_LEVIATHAN = "Ground-Vortex Leviathan";
  public const string GROUND_VORTEX_LEVIATHAN_JP = "大海蛇リヴィアサン";
  public const string GROUND_VORTEX_LEVIATHAN_JP_VIEW = "【　深獄淵の鳴動　】\r\n大海蛇リヴィアサン";

  // エデルガイゼン城
  public const string PHANTOM_HUNTER = "Phantom Hunter";
  public const string PHANTOM_HUNTER_JP = "幻暗ハンター";
  public const string BEAST_MASTER = "Beast Master";
  public const string BEAST_MASTER_JP = "ビースト・マスター";
  public const string ELDER_ASSASSIN = "Elder Assassin";
  public const string ELDER_ASSASSIN_JP = "エルダー・アサシン";
  public const string FALLEN_SEEKER = "Fallen Seeker";
  public const string FALLEN_SEEKER_JP = "フォールン・シーカー";
  public const string MEPHISTO_RIGHTARM = "Mephisto Right-Arm";
  public const string MEPHISTO_RIGHTARM_JP = "メフィスト・ザ・ライトアーム";
  public const string POWERED_STEAM_BOW = "Powered Steam-Bow";
  public const string POWERED_STEAM_BOW_JP = "パワード・スチームボウ";
  public const string DARK_MESSENGER = "The Dark Messenger";
  public const string DARK_MESSENGER_JP = "闇の眷属";
  public const string MASTER_LORD = "Master Lord";
  public const string MASTER_LORD_JP = "マスター・ロード";
  public const string EXECUTIONER = "Executioner";
  public const string EXECUTIONER_JP = "エグゼキューショナー";
  public const string MARIONETTE_NEMESIS = "Marionette Nemesis";
  public const string MARIONETTE_NEMESIS_JP = "マリオネット・ネメシス";
  public const string BLACKFIRE_MASTER_BLADE = "Black-Fire Master-Blade";
  public const string BLACKFIRE_MASTER_BLADE_JP = "黒炎マスターブレイド";
  public const string SIN_THE_DARKELF = "Sin The Darkelf";
  public const string SIN_THE_DARKELF_JP = "シン・ザ・ダークエルフ";
  public const string IMPERIAL_KNIGHT = "Imperial Knight";
  public const string IMPERIAL_KNIGHT_JP = "インペリアル・ナイト";
  public const string SUN_STRIDER = "Sun Strider";
  public const string SUN_STRIDER_JP = "サン・ストライダー";
  public const string BALANCE_IDLE = "Balancing Idle";
  public const string BALANCE_IDLE_JP = "天秤を司る者";
  public const string ARCHDEMON = "ArchDemon";
  public const string ARCHDEMON_JP = "アークデーモン";
  public const string UNDEAD_WYVERN = "Undead Wyvern";
  public const string UNDEAD_WYVERN_JP = "アンデッド・ワイバーン";
  public const string GO_FLAME_SLASHER = "Go Flame-Slasher";
  public const string GO_FLAME_SLASHER_JP = "業・フレイムスラッシャー";
  public const string DEVIL_CHILDREN = "Devil Children";
  public const string DEVIL_CHILDREN_JP = "デビル・チルドレン";
  public const string ANCIENT_DISK = "Ancient Disk";
  public const string ANCIENT_DISK_JP = "古代紋様の円盤";
  public const string HOWLING_HORROR = "Howling Horror";
  public const string HOWLING_HORROR_JP = "ハウリングホラー";
  public const string PAIN_ANGEL = "Pain Angel";
  public const string PAIN_ANGEL_JP = "ペインエンジェル";
  public const string CHAOS_WARDEN = "Chaos Warden";
  public const string CHAOS_WARDEN_JP = "カオス・ワーデン";
  public const string HELL_DREAD_KNIGHT = "Hell Dread Knight";
  public const string HELL_DREAD_KNIGHT_JP = "ヘル・ドレッド・ナイト";
  public const string DOOM_BRINGER = "Doom Bringer";
  public const string DOOM_BRINGER_JP = "ドゥームブリンガー";
  public const string BLACK_LIGHTNING_SPHERE = "Black-Lightning Sphere";
  public const string BLACK_LIGHTNING_SPHERE_JP = "ブラックライトニング・スフィア";
  public const string DISTORTED_SENSOR = "Distorted Sensor";
  public const string DISTORTED_SENSOR_JP = "ディストーティッド センサー";
  public const string ELDER_BAPHOMET = "Elder Baphomet";
  public const string ELDER_BAPHOMET_JP = "エルダー バフォメット";
  public const string WIND_BREAKER = "Wind Breaker";
  public const string WIND_BREAKER_JP = "ウィンド・ブレイカー";
  public const string HOLLOW_SPECTOR = "Hollow Spector";
  public const string HOLLOW_SPECTOR_JP = "ホロウ・スペクター";
  public const string VENERABLE_WIZARD = "Venerable Wizard";
  public const string VENERABLE_WIZARD_JP = "ヴェネラブル・ウィザード";
  public const string UNKNOWN_FLOATING_BALL = "Unknown Floating-Ball";
  public const string UNKNOWN_FLOATING_BALL_JP = "正体不明の浮遊物";
  public const string MASCLEWARRIOR_HARDIL = "MuscleWarrior Hardil";
  public const string MASCLEWARRIOR_HARDIL_JP = "屈強戦士：ハーディル";
  public const string MASCLEWARRIOR_HARDIL_JP_VIEW = "【　屈強戦士　】\r\nハーディル";
  public const string HUGE_MAGICIAN_ZAGAN = "Huge Magician Zagan";
  public const string HUGE_MAGICIAN_ZAGAN_JP = "巨体魔導士：ザガン";
  public const string HUGE_MAGICIAN_ZAGAN_JP_VIEW = "【　巨体魔導士　】\r\n：ザガン";
  public const string LEGIN_ARZE_1 = "Legin-Arze <Miasma>";
  public const string LEGIN_ARZE_1_JP = "闇焔レギィン・アーゼ【瘴気】";
  public const string LEGIN_ARZE_1_JP_VIEW = "【　　闇焔　＜瘴気＞　】\r\nレギィン・アーゼ";
  public const string LEGIN_ARZE_2 = "Legin-Arze <Soundless>";
  public const string LEGIN_ARZE_2_JP = "闇焔レギィン・アーゼ【無音】";
  public const string LEGIN_ARZE_2_JP_VIEW = "【　　闇焔　＜無音＞　】\r\nレギィン・アーゼ";
  public const string LEGIN_ARZE_3 = "Legin-Arze <Abyss>";
  public const string LEGIN_ARZE_3_JP = "闇焔レギィン・アーゼ【深淵】";
  public const string LEGIN_ARZE_3_JP_VIEW = "【　　闇焔　＜深淵＞　】\r\nレギィン・アーゼ";
  public const string EMPEROR_LEGAL_ORPHSTEIN = "The Emperor: Legal Orphstein";
  public const string EMPEROR_LEGAL_ORPHSTEIN_JP = "皇帝：リガール・オルフシュタイン";
  public const string EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW = "【　　皇帝　　】\r\nリガール・オルフシュタイン";
  public const string FIRE_EMPEROR_LEGAL_ORPHSTEIN = "The Flame-Emperor: Legal Orphstein";
  public const string FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP = "真炎帝：リガール・オルフシュタイン";
  public const string FIRE_EMPEROR_LEGAL_ORPHSTEIN_JP_VIEW = "【　　真炎帝　　】\r\nリガール・オルフシュタイン";
  public const string ROYAL_KING_AERMI_JORZT = "Royal-King: Aermi Jorzt";
  public const string ROYAL_KING_AERMI_JORZT_JP = "高貴なる王：エルミ・ジョルジュ";
  public const string ROYAL_KING_AERMI_JORZT_JP_VIEW = "【　高貴なる王　】\r\nエルミ・ジョルジュ";
  public const string ETERNITY_KING_AERMI_JORZT = "Eternity-King: Aermi Jorzt";
  public const string ETERNITY_KING_AERMI_JORZT_JP = "久遠なる王：エルミ・ジョルジュ";
  public const string ETERNITY_KING_AERMI_JORZT_JP_VIEW = "【　久遠なる王　】\r\nエルミ・ジョルジュ";

  // 離島ウォズム
  public const string PHOENIX = @"Phoenix";
  public const string PHOENIX_JP = @"フェニックス";
  public const string NINE_TAIL = @"Nine Tail";
  public const string NINE_TAIL_JP = @"ナイン・テイル";
  public const string MEPHISTOPHELES = @"Mephistopheles";
  public const string MEPHISTOPHELES_JP = @"メフィストフェレス";
  public const string JUDGEMENT = @"Judgement";
  public const string JUDGEMENT_JP = @"ジャッジメント";
  public const string EMERALD_DRAGON = @"Emerald Dragon";
  public const string EMERALD_DRAGON_JP = @"エメラルド・ドラゴン";
  public const string TIAMAT = @"Tiamat";
  public const string TIAMAT_JP = @"ティアマト";

  // 未設定
  public const string RUDE_WATCHDOG = "Rude Watchdog";
  public const string RUDE_WATCHDOG_JP = "ルード ウォッチドッグ";
  public const string STONE_STATUE_SEIHITSU = "Stone-Statue Seihitsu";
  public const string STONE_STATUE_SEIHITSU_JP = "静謐な石像";
  public const string SHOTGUN_HYUUI = "Shotgun Hyuui";
  public const string SHOTGUN_HYUUI_JP = "ショットガン ヒューイ";
  public const string CALM_STAG = "Calm Stag";
  public const string CALM_STAG_JP = "冷静な鹿";
  public const string FOREST_ELEMENTAL = "Forest Elemental";
  public const string FOREST_ELEMENTAL_JP = "フォレスト エレメンタル";
  public const string LIGHTNING_SPHERE = "Lightning Sphere";
  public const string LIGHTNING_SPHERE_JP = "ライトニング・スフィア";
  public const string DECEIVED_HUNTSMAN = "Deceived Huntsman";
  public const string DECEIVED_HUNTSMAN_JP = "待ち伏せハンツマン";
  public const string DHAL_GUARDIAN = "Dhal Guardian";
  public const string DHAL_GUARDIAN_JP = "ダルの守護人";
  public const string PUPPET_MASTER = "Puppet Master";
  public const string PUPPET_MASTER_JP = "パペット・マスター";
  public const string DANCING_BLADE = "Dancing Blade";
  public const string DANCING_BLADE_JP = "ダンシング・ブレード";
  public const string TRAPPED_DISK = "Trapped Disk";
  public const string TRAPPED_DISK_JP = "トラップ仕掛けの円盤";
  public const string WHISTLE_SENSOR = "Whistle Sensor";
  public const string WHISTLE_SENSOR_JP = "笛吹きセンサー";
  public const string DREAD_LANCER = "Dread Lancer";
  public const string DREAD_LANCER_JP = "ドレッド・ランサー";
  public const string PEACEFUL_ANDANTINO = "Peaceful Andantino";
  public const string PEACEFUL_ANDANTINO_JP = "ピースフル・アンダンティーノ";
  public const string POISONED_CHALICE = "Poisoned Chalice";
  public const string POISONED_CHALICE_JP = "猛毒聖杯";
  public const string AURORA_SPIRIT = "Aurora Spirit";
  public const string AURORA_SPIRIT_JP = "オーロラ・スピリット";
  public const string HELL_KERBEROS = "Hell Kerberos";
  public const string HELL_KERBEROS_JP = "地獄のケルベロス";
  public const string HELL_KERBEROS_JP_VIEW = "【地獄の番人】\r\nヘル・ケルベロス";

  public const string DUMMY_SUBURI = "ダミー素振り君";
  #endregion

  #region "Dungeon Event"
  #region "エスミリア草原"
  #region "宝箱"
  public const string ESMILIA_Treasure_1_C = "Treasure";
  public const string ESMILIA_Treasure_1_O = "1";
  public const float ESMILIA_Treasure_1_X = 28.0f;
  public const float ESMILIA_Treasure_1_Y = 1.0f;
  public const float ESMILIA_Treasure_1_Z = 3.0f;

  public const string ESMILIA_Treasure_2_C = "Treasure";
  public const string ESMILIA_Treasure_2_O = "2";
  public const float ESMILIA_Treasure_2_X = 24.0f;
  public const float ESMILIA_Treasure_2_Y = 1.0f;
  public const float ESMILIA_Treasure_2_Z = 0.0f;

  public const string ESMILIA_Treasure_3_C = "Treasure";
  public const string ESMILIA_Treasure_3_O = "3";
  public const float ESMILIA_Treasure_3_X = 15.0f;
  public const float ESMILIA_Treasure_3_Y = 1.0f;
  public const float ESMILIA_Treasure_3_Z = 8.0f;

  public const string ESMILIA_Treasure_4_C = "Treasure";
  public const string ESMILIA_Treasure_4_O = "4";
  public const float ESMILIA_Treasure_4_X = 11.0f;
  public const float ESMILIA_Treasure_4_Y = 1.0f;
  public const float ESMILIA_Treasure_4_Z = 2.0f;

  public const string ESMILIA_Treasure_5_C = "Treasure";
  public const string ESMILIA_Treasure_5_O = "5";
  public const float ESMILIA_Treasure_5_X = 1.0f;
  public const float ESMILIA_Treasure_5_Y = 1.0f;
  public const float ESMILIA_Treasure_5_Z = 9.0f;

  public const string ESMILIA_Treasure_6_C = "Treasure";
  public const string ESMILIA_Treasure_6_O = "6";
  public const float ESMILIA_Treasure_6_X = -9.0f;
  public const float ESMILIA_Treasure_6_Y = 1.0f;
  public const float ESMILIA_Treasure_6_Z = 11.0f;

  public const string ESMILIA_Treasure_7_C = "Treasure";
  public const string ESMILIA_Treasure_7_O = "7";
  public const float ESMILIA_Treasure_7_X = 7.0f;
  public const float ESMILIA_Treasure_7_Y = 1.0f;
  public const float ESMILIA_Treasure_7_Z = -5.0f;

  public const string ESMILIA_Treasure_8_C = "Treasure";
  public const string ESMILIA_Treasure_8_O = "8";
  public const float ESMILIA_Treasure_8_X = 7.0f;
  public const float ESMILIA_Treasure_8_Y = 1.0f;
  public const float ESMILIA_Treasure_8_Z = 1.0f;

  public const string ESMILIA_Treasure_9_C = "Treasure";
  public const string ESMILIA_Treasure_9_O = "9";
  public const float ESMILIA_Treasure_9_X = -7.0f;
  public const float ESMILIA_Treasure_9_Y = 1.0f;
  public const float ESMILIA_Treasure_9_Z = 5.0f;

  public const string ESMILIA_Treasure_10_C = "Treasure";
  public const string ESMILIA_Treasure_10_O = "10";
  public const float ESMILIA_Treasure_10_X = 27.0f;
  public const float ESMILIA_Treasure_10_Y = 1.0f;
  public const float ESMILIA_Treasure_10_Z = -5.0f;
  #endregion
  #region "イベント"
  public const string ESMILIA_Rock_1_C = "Rock";
  public const string ESMILIA_Rock_1_O = "1";
  public const float ESMILIA_Rock_1_X = -9.0f;
  public const float ESMILIA_Rock_1_Y = 1.0f;
  public const float ESMILIA_Rock_1_Z = 8.0f;

  public const string ESMILIA_Rock_2_C = "Rock";
  public const string ESMILIA_Rock_2_O = "2";
  public const float ESMILIA_Rock_2_X = -5.0f;
  public const float ESMILIA_Rock_2_Y = 1.0f;
  public const float ESMILIA_Rock_2_Z = 10.0f;

  public const string ESMILIA_Rock_3_C = "Rock";
  public const string ESMILIA_Rock_3_O = "3";
  public const float ESMILIA_Rock_3_X = -3.0f;
  public const float ESMILIA_Rock_3_Y = 1.0f;
  public const float ESMILIA_Rock_3_Z = 0.0f;

  public const string ESMILIA_Rock_4_C = "Rock";
  public const string ESMILIA_Rock_4_O = "4";
  public const float ESMILIA_Rock_4_X = -7.0f;
  public const float ESMILIA_Rock_4_Y = 1.0f;
  public const float ESMILIA_Rock_4_Z = 4.0f;

  public const string ESMILIA_Rock_5_C = "Rock";
  public const string ESMILIA_Rock_5_O = "5";
  public const float ESMILIA_Rock_5_X = 9.0f;
  public const float ESMILIA_Rock_5_Y = 1.0f;
  public const float ESMILIA_Rock_5_Z = -4.0f;

  public const string ESMILIA_Rock_6_C = "Rock";
  public const string ESMILIA_Rock_6_O = "6";
  public const float ESMILIA_Rock_6_X = 13.0f;
  public const float ESMILIA_Rock_6_Y = 1.0f;
  public const float ESMILIA_Rock_6_Z = -1.0f;

  public const string ESMILIA_Rock_7_C = "Rock";
  public const string ESMILIA_Rock_7_O = "7";
  public const float ESMILIA_Rock_7_X = 16.0f;
  public const float ESMILIA_Rock_7_Y = 1.0f;
  public const float ESMILIA_Rock_7_Z = -4.0f;

  public const string ESMILIA_Rock_8_C = "Rock";
  public const string ESMILIA_Rock_8_O = "8";
  public const float ESMILIA_Rock_8_X = -6.0f;
  public const float ESMILIA_Rock_8_Y = 1.0f;
  public const float ESMILIA_Rock_8_Z = 2.0f;
  #endregion
  #region "階段"
  public const string ESMILIA_1_DOWNSTAIR_1_C = "Downstair";
  public const string ESMILIA_1_DOWNSTAIR_1_O = "1";
  public const float ESMILIA_1_DOWNSTAIR_1_X = 0.0f;
  public const float ESMILIA_1_DOWNSTAIR_1_Y = 0.0f;
  public const float ESMILIA_1_DOWNSTAIR_1_Z = 3.0f;
  #endregion
  #region "回復の泉"
  public const string ESMILIA_FOUNTAIN_1_C = "Fountain";
  public const string ESMILIA_FOUNTAIN_1_O = "1";
  public const float ESMILIA_FOUNTAIN_1_X = 20.0f;
  public const float ESMILIA_FOUNTAIN_1_Y = 1.0f;
  public const float ESMILIA_FOUNTAIN_1_Z = 7.0f;

  public const string ESMILIA_FOUNTAIN_2_C = "Fountain";
  public const string ESMILIA_FOUNTAIN_2_O = "2";
  public const float ESMILIA_FOUNTAIN_2_X = 14.0f;
  public const float ESMILIA_FOUNTAIN_2_Y = 1.0f;
  public const float ESMILIA_FOUNTAIN_2_Z = 1.0f;

  public const string ESMILIA_FOUNTAIN_3_C = "Fountain";
  public const string ESMILIA_FOUNTAIN_3_O = "3";
  public const float ESMILIA_FOUNTAIN_3_X = -4.0f;
  public const float ESMILIA_FOUNTAIN_3_Y = 1.0f;
  public const float ESMILIA_FOUNTAIN_3_Z = 1.0f;
  #endregion
  #region "ObsidianStone"
  public const string ESMILIA_ObsidianStone_1_C = "ObsidianStone";
  public const string ESMILIA_ObsidianStone_1_O = "1";
  public const float ESMILIA_ObsidianStone_1_X = 0.0f;
  public const float ESMILIA_ObsidianStone_1_Y = 1.0f;
  public const float ESMILIA_ObsidianStone_1_Z = 3.0f;
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
  #region "回復の泉"
  public const string GORATRUM_FOUNTAIN_1_C = "Fountain";
  public const string GORATRUM_FOUNTAIN_1_O = "1";
  public const float GORATRUM_FOUNTAIN_1_X = 18.0f;
  public const float GORATRUM_FOUNTAIN_1_Y = 1.0f;
  public const float GORATRUM_FOUNTAIN_1_Z = -3.0f;

  public const string GORATRUM_FOUNTAIN_2_C = "Fountain";
  public const string GORATRUM_FOUNTAIN_2_O = "2";
  public const float GORATRUM_FOUNTAIN_2_X = 8.0f;
  public const float GORATRUM_FOUNTAIN_2_Y = 1.0f;
  public const float GORATRUM_FOUNTAIN_2_Z = -10.0f;
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

  // Duel ヨーゼン・ゴルメッツ
  public const string GORATRUM_2_Event_4_C = "Event";
  public const string GORATRUM_2_Event_4_O = "38";
  public const float GORATRUM_2_Event_4_X = 35.0f;
  public const float GORATRUM_2_Event_4_Y = -0.0f;
  public const float GORATRUM_2_Event_4_Z = -10.0f;
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

  public const string MYSTICFOREST_Treasure_19_C = "Treasure";
  public const string MYSTICFOREST_Treasure_19_O = "19";
  public const float MYSTICFOREST_Treasure_19_X = 15.0f;
  public const float MYSTICFOREST_Treasure_19_Y = 1.0f;
  public const float MYSTICFOREST_Treasure_19_Z = -20.0f;
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

  public const string MYSTICFOREST_Event_54_C = "Event";
  public const string MYSTICFOREST_Event_54_O = "54";
  public const float MYSTICFOREST_Event_54_X = 7.0f;
  public const float MYSTICFOREST_Event_54_Y = 0.0f;
  public const float MYSTICFOREST_Event_54_Z = -21.0f;

  public const string MYSTICFOREST_Event_55_C = "Event";
  public const string MYSTICFOREST_Event_55_O = "55";
  public const float MYSTICFOREST_Event_55_X = 15.0f;
  public const float MYSTICFOREST_Event_55_Y = 0.0f;
  public const float MYSTICFOREST_Event_55_Z = -18.0f;

  // 隠し通路（１）
  public const string MYSTICFOREST_Event_56_C = "Event";
  public const string MYSTICFOREST_Event_56_O = "56";
  public const float MYSTICFOREST_Event_56_X = 38.0f;
  public const float MYSTICFOREST_Event_56_Y = 1.0f;
  public const float MYSTICFOREST_Event_56_Z = -22.0f;

  // 隠し通路（１）の反対側
  public const string MYSTICFOREST_Event_57_C = "Event";
  public const string MYSTICFOREST_Event_57_O = "57";
  public const float MYSTICFOREST_Event_57_X = 40.0f;
  public const float MYSTICFOREST_Event_57_Y = 1.0f;
  public const float MYSTICFOREST_Event_57_Z = -22.0f;

  // 隠し通路（２）
  public const string MYSTICFOREST_Event_58_C = "Event";
  public const string MYSTICFOREST_Event_58_O = "58";
  public const float MYSTICFOREST_Event_58_X = 48.0f;
  public const float MYSTICFOREST_Event_58_Y = 1.0f;
  public const float MYSTICFOREST_Event_58_Z = -21.0f;

  // 隠し通路（２）の反対側
  public const string MYSTICFOREST_Event_59_C = "Event";
  public const string MYSTICFOREST_Event_59_O = "59";
  public const float MYSTICFOREST_Event_59_X = 48.0f;
  public const float MYSTICFOREST_Event_59_Y = 1.0f;
  public const float MYSTICFOREST_Event_59_Z = -19.0f;

  // 隠し通路（３）
  public const string MYSTICFOREST_Event_60_C = "Event";
  public const string MYSTICFOREST_Event_60_O = "60";
  public const float MYSTICFOREST_Event_60_X = 48.0f;
  public const float MYSTICFOREST_Event_60_Y = 1.0f;
  public const float MYSTICFOREST_Event_60_Z = -17.0f;

  // 隠し通路（３）の反対側
  public const string MYSTICFOREST_Event_61_C = "Event";
  public const string MYSTICFOREST_Event_61_O = "61";
  public const float MYSTICFOREST_Event_61_X = 48.0f;
  public const float MYSTICFOREST_Event_61_Y = 1.0f;
  public const float MYSTICFOREST_Event_61_Z = -15.0f;

  // 隠し通路（４）
  public const string MYSTICFOREST_Event_62_C = "Event";
  public const string MYSTICFOREST_Event_62_O = "62";
  public const float MYSTICFOREST_Event_62_X = 48.0f;
  public const float MYSTICFOREST_Event_62_Y = 1.0f;
  public const float MYSTICFOREST_Event_62_Z = -12.0f;

  // 隠し通路（４）の反対側
  public const string MYSTICFOREST_Event_63_C = "Event";
  public const string MYSTICFOREST_Event_63_O = "63";
  public const float MYSTICFOREST_Event_63_X = 48.0f;
  public const float MYSTICFOREST_Event_63_Y = 1.0f;
  public const float MYSTICFOREST_Event_63_Z = -10.0f;

  // 隠し通路（５）
  public const string MYSTICFOREST_Event_64_C = "Event";
  public const string MYSTICFOREST_Event_64_O = "64";
  public const float MYSTICFOREST_Event_64_X = 48.0f;
  public const float MYSTICFOREST_Event_64_Y = 1.0f;
  public const float MYSTICFOREST_Event_64_Z = -13.0f;

  // 隠し通路（５）の反対側
  public const string MYSTICFOREST_Event_65_C = "Event";
  public const string MYSTICFOREST_Event_65_O = "65";
  public const float MYSTICFOREST_Event_65_X = 46.0f;
  public const float MYSTICFOREST_Event_65_Y = 1.0f;
  public const float MYSTICFOREST_Event_65_Z = -13.0f;

  // Duel アーダム・ヴィオ
  public const string MYSTICFOREST_Event_66_C = "Event";
  public const string MYSTICFOREST_Event_66_O = "66";
  public const float MYSTICFOREST_Event_66_X = 14.0f;
  public const float MYSTICFOREST_Event_66_Y = 0.0f;
  public const float MYSTICFOREST_Event_66_Z = -12.0f;

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

  // 未使用
  //public const string MYSTICFOREST_BRUSHWOOD_7_C = "BrushWood";
  //public const string MYSTICFOREST_BRUSHWOOD_7_O = "7";
  //public const float MYSTICFOREST_BRUSHWOOD_7_X = 48;
  //public const float MYSTICFOREST_BRUSHWOOD_7_Y = 1.0f;
  //public const float MYSTICFOREST_BRUSHWOOD_7_Z = -20.0f;

  // 未使用
  //public const string MYSTICFOREST_BRUSHWOOD_8_C = "BrushWood";
  //public const string MYSTICFOREST_BRUSHWOOD_8_O = "8";
  //public const float MYSTICFOREST_BRUSHWOOD_8_X = 48.0f;
  //public const float MYSTICFOREST_BRUSHWOOD_8_Y = 1.0f;
  //public const float MYSTICFOREST_BRUSHWOOD_8_Z = -16.0f;

  // 未使用
  //public const string MYSTICFOREST_BRUSHWOOD_9_C = "BrushWood";
  //public const string MYSTICFOREST_BRUSHWOOD_9_O = "9";
  //public const float MYSTICFOREST_BRUSHWOOD_9_X = 48.0f;
  //public const float MYSTICFOREST_BRUSHWOOD_9_Y = 1.0f;
  //public const float MYSTICFOREST_BRUSHWOOD_9_Z = -13.0f;

  // 未使用
  //public const string MYSTICFOREST_BRUSHWOOD_10_C = "BrushWood";
  //public const string MYSTICFOREST_BRUSHWOOD_10_O = "10";
  //public const float MYSTICFOREST_BRUSHWOOD_10_X = 45.0f;
  //public const float MYSTICFOREST_BRUSHWOOD_10_Y = 1.0f;
  //public const float MYSTICFOREST_BRUSHWOOD_10_Z = -13.0f;

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

  #region "回復の泉"
  public const string  MYSTICFOREST_FOUNTAIN_1_C = "Fountain";
  public const string  MYSTICFOREST_FOUNTAIN_1_O = "1";
  public const float  MYSTICFOREST_FOUNTAIN_1_X = 9.0f;
  public const float  MYSTICFOREST_FOUNTAIN_1_Y = 1.0f;
  public const float  MYSTICFOREST_FOUNTAIN_1_Z = -9.0f;

  public const string MYSTICFOREST_FOUNTAIN_2_C = "Fountain";
  public const string MYSTICFOREST_FOUNTAIN_2_O = "2";
  public const float MYSTICFOREST_FOUNTAIN_2_X = 7.0f;
  public const float MYSTICFOREST_FOUNTAIN_2_Y = 1.0f;
  public const float MYSTICFOREST_FOUNTAIN_2_Z = -20.0f;

  public const string MYSTICFOREST_FOUNTAIN_3_C = "Fountain";
  public const string MYSTICFOREST_FOUNTAIN_3_O = "3";
  public const float MYSTICFOREST_FOUNTAIN_3_X = 42.0f;
  public const float MYSTICFOREST_FOUNTAIN_3_Y = 1.0f;
  public const float MYSTICFOREST_FOUNTAIN_3_Z = -24.0f;
  #endregion

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
  #region "オーランの塔"

  #region "看板"
  public const string OHRANTOWER_MessageBoard_1_C = "MessageBoard";
  public const string OHRANTOWER_MessageBoard_1_O = "1";
  public const float OHRANTOWER_MessageBoard_1_X = 8.0f;
  public const float OHRANTOWER_MessageBoard_1_Y = 56.5f;
  public const float OHRANTOWER_MessageBoard_1_Z = -21.0f;
  #endregion

  #region "下り階段（入口）"
  public const string OHRANTOWER_DOWNSTAIR_1_C = "Downstair";
  public const string OHRANTOWER_DOWNSTAIR_1_O = "1";
  public const float OHRANTOWER_DOWNSTAIR_1_X = 15.0f;
  public const float OHRANTOWER_DOWNSTAIR_1_Y = 0.0f;
  public const float OHRANTOWER_DOWNSTAIR_1_Z = -30.0f;
  #endregion

  #region "FLOATINGTILE"
  // １層、右下
  public const string OHRANTOWER_FLOATINGTILE_1_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_1_O = "1";
  public const float OHRANTOWER_FLOATINGTILE_1_X = 25.0f;
  public const float OHRANTOWER_FLOATINGTILE_1_Y = 0.0f;
  public const float OHRANTOWER_FLOATINGTILE_1_Z = -24.0f;

  // １層、右下、戻り
  public const string OHRANTOWER_FLOATINGTILE_2_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_2_O = "2";
  public const float OHRANTOWER_FLOATINGTILE_2_X = 25.0f;
  public const float OHRANTOWER_FLOATINGTILE_2_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_2_Z = -24.0f;

  // １層、左下
  public const string OHRANTOWER_FLOATINGTILE_3_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_3_O = "3";
  public const float OHRANTOWER_FLOATINGTILE_3_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_3_Y = 0.0f;
  public const float OHRANTOWER_FLOATINGTILE_3_Z = -24.0f;

  // １層、左下、戻り
  public const string OHRANTOWER_FLOATINGTILE_4_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_4_O = "4";
  public const float OHRANTOWER_FLOATINGTILE_4_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_4_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_4_Z = -24.0f;

  // ２層、中央2A
  public const string OHRANTOWER_FLOATINGTILE_5_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_5_O = "5";
  public const float OHRANTOWER_FLOATINGTILE_5_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_5_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_5_Z = -16.0f;

  // ２層、中央2A、戻り
  public const string OHRANTOWER_FLOATINGTILE_6_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_6_O = "6";
  public const float OHRANTOWER_FLOATINGTILE_6_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_6_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_6_Z = -9.0f;

  // ２層、中央2B
  public const string OHRANTOWER_FLOATINGTILE_7_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_7_O = "7";
  public const float OHRANTOWER_FLOATINGTILE_7_X = 13.0f;
  public const float OHRANTOWER_FLOATINGTILE_7_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_7_Z = -7.0f;

  // ２層、中央2B、戻り
  public const string OHRANTOWER_FLOATINGTILE_8_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_8_O = "8";
  public const float OHRANTOWER_FLOATINGTILE_8_X = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_8_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_8_Z = -7.0f;

  // ２層、中央2C
  public const string OHRANTOWER_FLOATINGTILE_9_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_9_O = "9";
  public const float OHRANTOWER_FLOATINGTILE_9_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_9_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_9_Z = -9.0f;

  // ２層、中央2C、戻り
  public const string OHRANTOWER_FLOATINGTILE_10_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_10_O = "10";
  public const float OHRANTOWER_FLOATINGTILE_10_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_10_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_10_Z = -14.0f;

  // ２層、中央2D
  public const string OHRANTOWER_FLOATINGTILE_11_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_11_O = "11";
  public const float OHRANTOWER_FLOATINGTILE_11_X = 26.0f;
  public const float OHRANTOWER_FLOATINGTILE_11_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_11_Z = -19.0f;

  // ２層、中央2D、戻り
  public const string OHRANTOWER_FLOATINGTILE_12_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_12_O = "12";
  public const float OHRANTOWER_FLOATINGTILE_12_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_12_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_12_Z = -19.0f;

  // ２層、中央2E
  public const string OHRANTOWER_FLOATINGTILE_13_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_13_O = "13";
  public const float OHRANTOWER_FLOATINGTILE_13_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_13_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_13_Z = -22.0f;

  // ２層、中央2E、戻り
  public const string OHRANTOWER_FLOATINGTILE_14_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_14_O = "14";
  public const float OHRANTOWER_FLOATINGTILE_14_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_14_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_14_Z = -24.0f;

  // ２層、上り１２
  public const string OHRANTOWER_FLOATINGTILE_15_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_15_O = "15";
  public const float OHRANTOWER_FLOATINGTILE_15_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_15_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_15_Z = -27.0f;

  // ２層、上り１２、戻り
  public const string OHRANTOWER_FLOATINGTILE_16_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_16_O = "16";
  public const float OHRANTOWER_FLOATINGTILE_16_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_16_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_16_Z = -27.0f;

  // ３層、下り１３
  public const string OHRANTOWER_FLOATINGTILE_17_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_17_O = "17";
  public const float OHRANTOWER_FLOATINGTILE_17_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_17_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_17_Z = -27.0f;

  // ３層、下り１３、戻り
  public const string OHRANTOWER_FLOATINGTILE_18_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_18_O = "18";
  public const float OHRANTOWER_FLOATINGTILE_18_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_18_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_18_Z = -27.0f;

  // ２層、中央2F
  public const string OHRANTOWER_FLOATINGTILE_19_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_19_O = "19";
  public const float OHRANTOWER_FLOATINGTILE_19_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_19_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_19_Z = -24.0f;

  // ２層、中央2F、戻り
  public const string OHRANTOWER_FLOATINGTILE_20_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_20_O = "20";
  public const float OHRANTOWER_FLOATINGTILE_20_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_20_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_20_Z = -22.0f;

  // ３層、左上
  public const string OHRANTOWER_FLOATINGTILE_21_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_21_O = "21";
  public const float OHRANTOWER_FLOATINGTILE_21_X = 7.0f;
  public const float OHRANTOWER_FLOATINGTILE_21_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_21_Z = -3.0f;

  // ３層、左上、戻り
  public const string OHRANTOWER_FLOATINGTILE_22_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_22_O = "22";
  public const float OHRANTOWER_FLOATINGTILE_22_X = 7.0f;
  public const float OHRANTOWER_FLOATINGTILE_22_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_22_Z = -3.0f;

  // ４層、左上4A
  public const string OHRANTOWER_FLOATINGTILE_23_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_23_O = "23";
  public const float OHRANTOWER_FLOATINGTILE_23_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_23_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_23_Z = -8.0f;

  // ４層、左上4A、戻り
  public const string OHRANTOWER_FLOATINGTILE_24_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_24_O = "24";
  public const float OHRANTOWER_FLOATINGTILE_24_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_24_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_24_Z = -10.0f;

  // ４層、左上4B
  public const string OHRANTOWER_FLOATINGTILE_25_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_25_O = "25";
  public const float OHRANTOWER_FLOATINGTILE_25_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_25_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_25_Z = -11.0f;

  // ４層、左上4B、戻り
  public const string OHRANTOWER_FLOATINGTILE_26_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_26_O = "26";
  public const float OHRANTOWER_FLOATINGTILE_26_X = 3.0f;
  public const float OHRANTOWER_FLOATINGTILE_26_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_26_Z = -11.0f;

  // ４層、左上4C
  public const string OHRANTOWER_FLOATINGTILE_27_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_27_O = "27";
  public const float OHRANTOWER_FLOATINGTILE_27_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_27_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_27_Z = -10.0f;

  // ４層、左上4C、戻り
  public const string OHRANTOWER_FLOATINGTILE_28_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_28_O = "28";
  public const float OHRANTOWER_FLOATINGTILE_28_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_28_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_28_Z = -8.0f;

  // ４層、左上4D
  public const string OHRANTOWER_FLOATINGTILE_29_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_29_O = "29";
  public const float OHRANTOWER_FLOATINGTILE_29_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_29_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_29_Z = -12.0f;

  // ４層、左上4D、戻り
  public const string OHRANTOWER_FLOATINGTILE_30_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_30_O = "30";
  public const float OHRANTOWER_FLOATINGTILE_30_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_30_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_30_Z = -14.0f;

  // ４層、左上4E
  public const string OHRANTOWER_FLOATINGTILE_31_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_31_O = "31";
  public const float OHRANTOWER_FLOATINGTILE_31_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_31_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_31_Z = -15.0f;

  // ４層、左上4E、戻り
  public const string OHRANTOWER_FLOATINGTILE_32_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_32_O = "32";
  public const float OHRANTOWER_FLOATINGTILE_32_X = 3.0f;
  public const float OHRANTOWER_FLOATINGTILE_32_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_32_Z = -15.0f;

  // ４層、左上4F
  public const string OHRANTOWER_FLOATINGTILE_33_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_33_O = "33";
  public const float OHRANTOWER_FLOATINGTILE_33_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_33_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_33_Z = -16.0f;

  // ４層、左上4F、戻り
  public const string OHRANTOWER_FLOATINGTILE_34_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_34_O = "34";
  public const float OHRANTOWER_FLOATINGTILE_34_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_34_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_34_Z = -18.0f;

  // ４層、左上4G
  public const string OHRANTOWER_FLOATINGTILE_35_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_35_O = "35";
  public const float OHRANTOWER_FLOATINGTILE_35_X = 3.0f;
  public const float OHRANTOWER_FLOATINGTILE_35_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_35_Z = -19.0f;

  // ４層、左上4G、戻り
  public const string OHRANTOWER_FLOATINGTILE_36_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_36_O = "36";
  public const float OHRANTOWER_FLOATINGTILE_36_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_36_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_36_Z = -19.0f;

  // ４層、左上4H
  public const string OHRANTOWER_FLOATINGTILE_37_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_37_O = "37";
  public const float OHRANTOWER_FLOATINGTILE_37_X = 7.0f;
  public const float OHRANTOWER_FLOATINGTILE_37_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_37_Z = -19.0f;

  // ４層、左上4H、戻り
  public const string OHRANTOWER_FLOATINGTILE_38_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_38_O = "38";
  public const float OHRANTOWER_FLOATINGTILE_38_X = 9.0f;
  public const float OHRANTOWER_FLOATINGTILE_38_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_38_Z = -19.0f;

  // ４層、左上4I
  public const string OHRANTOWER_FLOATINGTILE_39_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_39_O = "39";
  public const float OHRANTOWER_FLOATINGTILE_39_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_39_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_39_Z = -18.0f;

  // ４層、左上4I、戻り
  public const string OHRANTOWER_FLOATINGTILE_40_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_40_O = "40";
  public const float OHRANTOWER_FLOATINGTILE_40_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_40_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_40_Z = -16.0f;

  // ４層、左上4J
  public const string OHRANTOWER_FLOATINGTILE_41_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_41_O = "41";
  public const float OHRANTOWER_FLOATINGTILE_41_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_41_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_41_Z = -14.0f;

  // ４層、左上4J、戻り
  public const string OHRANTOWER_FLOATINGTILE_42_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_42_O = "42";
  public const float OHRANTOWER_FLOATINGTILE_42_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_42_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_42_Z = -12.0f;

  // ４層、左上4K
  public const string OHRANTOWER_FLOATINGTILE_43_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_43_O = "43";
  public const float OHRANTOWER_FLOATINGTILE_43_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_43_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_43_Z = -10.0f;

  // ４層、左上4K、戻り
  public const string OHRANTOWER_FLOATINGTILE_44_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_44_O = "44";
  public const float OHRANTOWER_FLOATINGTILE_44_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_44_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_44_Z = -8.0f;

  // ４層、左上4K、次の地点
  public const string OHRANTOWER_FLOATINGTILE_45_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_45_O = "45";
  public const float OHRANTOWER_FLOATINGTILE_45_X = 21.0f;
  public const float OHRANTOWER_FLOATINGTILE_45_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_45_Z = -8.0f;

  // ４層、中央4L
  public const string OHRANTOWER_FLOATINGTILE_46_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_46_O = "46";
  public const float OHRANTOWER_FLOATINGTILE_46_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_46_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_46_Z = -7.0f;

  // ４層、左上4L、戻り
  public const string OHRANTOWER_FLOATINGTILE_47_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_47_O = "47";
  public const float OHRANTOWER_FLOATINGTILE_47_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_47_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_47_Z = -11.0f;

  // ４層、中央4M
  public const string OHRANTOWER_FLOATINGTILE_48_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_48_O = "48";
  public const float OHRANTOWER_FLOATINGTILE_48_X = 22.0f;
  public const float OHRANTOWER_FLOATINGTILE_48_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_48_Z = -11.0f;

  // ４層、左上4L、戻り
  public const string OHRANTOWER_FLOATINGTILE_49_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_49_O = "49";
  public const float OHRANTOWER_FLOATINGTILE_49_X = 22.0f;
  public const float OHRANTOWER_FLOATINGTILE_49_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_49_Z = -21.0f;

  // ４層、中央4N
  public const string OHRANTOWER_FLOATINGTILE_50_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_50_O = "50";
  public const float OHRANTOWER_FLOATINGTILE_50_X = 20.0f;
  public const float OHRANTOWER_FLOATINGTILE_50_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_50_Z = -23.0f;

  // ４層、左上4N、戻り
  public const string OHRANTOWER_FLOATINGTILE_51_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_51_O = "51";
  public const float OHRANTOWER_FLOATINGTILE_51_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_51_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_51_Z = -23.0f;

  // ４層、下り４
  public const string OHRANTOWER_FLOATINGTILE_52_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_52_O = "52";
  public const float OHRANTOWER_FLOATINGTILE_52_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_52_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_52_Z = -9.0f;

  // ４層、下り４、戻り
  public const string OHRANTOWER_FLOATINGTILE_53_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_53_O = "53";
  public const float OHRANTOWER_FLOATINGTILE_53_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_53_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_53_Z = -9.0f;

  // ３層、上部11
  public const string OHRANTOWER_FLOATINGTILE_54_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_54_O = "54";
  public const float OHRANTOWER_FLOATINGTILE_54_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_54_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_54_Z = -2.0f;

  // ３層、上部11、戻り
  public const string OHRANTOWER_FLOATINGTILE_55_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_55_O = "55";
  public const float OHRANTOWER_FLOATINGTILE_55_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_55_Y = 0.0f;
  public const float OHRANTOWER_FLOATINGTILE_55_Z = -2.0f;

  // １層、右上14
  public const string OHRANTOWER_FLOATINGTILE_56_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_56_O = "56";
  public const float OHRANTOWER_FLOATINGTILE_56_X = 25.0f;
  public const float OHRANTOWER_FLOATINGTILE_56_Y = 0.0f;
  public const float OHRANTOWER_FLOATINGTILE_56_Z = -6.0f;

  // １層、右上14、戻り
  public const string OHRANTOWER_FLOATINGTILE_57_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_57_O = "57";
  public const float OHRANTOWER_FLOATINGTILE_57_X = 25.0f;
  public const float OHRANTOWER_FLOATINGTILE_57_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_57_Z = -6.0f;

  // ３層、中央3A
  public const string OHRANTOWER_FLOATINGTILE_58_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_58_O = "58";
  public const float OHRANTOWER_FLOATINGTILE_58_X = 25.0f;
  public const float OHRANTOWER_FLOATINGTILE_58_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_58_Z = -16.0f;

  // ３層、右上3A、戻り
  public const string OHRANTOWER_FLOATINGTILE_59_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_59_O = "59";
  public const float OHRANTOWER_FLOATINGTILE_59_X = 25.0f;
  public const float OHRANTOWER_FLOATINGTILE_59_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_59_Z = -21.0f;

  // ３層、中央3B
  public const string OHRANTOWER_FLOATINGTILE_60_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_60_O = "60";
  public const float OHRANTOWER_FLOATINGTILE_60_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_60_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_60_Z = -21.0f;

  // ３層、右上3B、戻り
  public const string OHRANTOWER_FLOATINGTILE_61_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_61_O = "61";
  public const float OHRANTOWER_FLOATINGTILE_61_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_61_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_61_Z = -15.0f;

  // ３層、左上3B、次の地点
  public const string OHRANTOWER_FLOATINGTILE_62_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_62_O = "62";
  public const float OHRANTOWER_FLOATINGTILE_62_X = 18.0f;
  public const float OHRANTOWER_FLOATINGTILE_62_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_62_Z = -15.0f;

  // ３層、中央3C
  public const string OHRANTOWER_FLOATINGTILE_63_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_63_O = "63";
  public const float OHRANTOWER_FLOATINGTILE_63_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_63_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_63_Z = -12.0f;

  // ３層、右上3C、戻り
  public const string OHRANTOWER_FLOATINGTILE_64_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_64_O = "64";
  public const float OHRANTOWER_FLOATINGTILE_64_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_64_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_64_Z = -10.0f;

  // ３層、中央3D
  public const string OHRANTOWER_FLOATINGTILE_65_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_65_O = "65";
  public const float OHRANTOWER_FLOATINGTILE_65_X = 14.0f;
  public const float OHRANTOWER_FLOATINGTILE_65_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_65_Z = -9.0f;

  // ３層、右上3D、戻り
  public const string OHRANTOWER_FLOATINGTILE_66_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_66_O = "66";
  public const float OHRANTOWER_FLOATINGTILE_66_X = 12.0f;
  public const float OHRANTOWER_FLOATINGTILE_66_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_66_Z = -9.0f;

  // ３層、中央3E
  public const string OHRANTOWER_FLOATINGTILE_67_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_67_O = "67";
  public const float OHRANTOWER_FLOATINGTILE_67_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_67_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_67_Z = -8.0f;

  // ３層、右上3E、戻り
  public const string OHRANTOWER_FLOATINGTILE_68_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_68_O = "68";
  public const float OHRANTOWER_FLOATINGTILE_68_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_68_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_68_Z = -4.0f;

  // ３層、中央3F
  public const string OHRANTOWER_FLOATINGTILE_69_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_69_O = "69";
  public const float OHRANTOWER_FLOATINGTILE_69_X = 12.0f;
  public const float OHRANTOWER_FLOATINGTILE_69_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_69_Z = -3.0f;

  // ３層、右上3F、戻り
  public const string OHRANTOWER_FLOATINGTILE_70_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_70_O = "70";
  public const float OHRANTOWER_FLOATINGTILE_70_X = 14.0f;
  public const float OHRANTOWER_FLOATINGTILE_70_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_70_Z = -3.0f;

  // １層、左上15
  public const string OHRANTOWER_FLOATINGTILE_71_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_71_O = "71";
  public const float OHRANTOWER_FLOATINGTILE_71_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_71_Y = 0.0f;
  public const float OHRANTOWER_FLOATINGTILE_71_Z = -6.0f;

  // １層、左上15、戻り
  public const string OHRANTOWER_FLOATINGTILE_72_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_72_O = "72";
  public const float OHRANTOWER_FLOATINGTILE_72_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_72_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_72_Z = -6.0f;

  // ２層、左2G
  public const string OHRANTOWER_FLOATINGTILE_73_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_73_O = "73";
  public const float OHRANTOWER_FLOATINGTILE_73_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_73_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_73_Z = -11.0f;

  // ２層、左2G、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_74_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_74_O = "74";
  public const float OHRANTOWER_FLOATINGTILE_74_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_74_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_74_Z = -13.0f;

  // ２層、左2G、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_75_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_75_O = "75";
  public const float OHRANTOWER_FLOATINGTILE_75_X = 3.0f;
  public const float OHRANTOWER_FLOATINGTILE_75_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_75_Z = -13.0f;

  // ２層、左2G、次の地点３
  public const string OHRANTOWER_FLOATINGTILE_76_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_76_O = "76";
  public const float OHRANTOWER_FLOATINGTILE_76_X = 3.0f;
  public const float OHRANTOWER_FLOATINGTILE_76_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_76_Z = -17.0f;

  // ２層、左2G、次の地点４
  public const string OHRANTOWER_FLOATINGTILE_77_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_77_O = "77";
  public const float OHRANTOWER_FLOATINGTILE_77_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_77_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_77_Z = -17.0f;

  // ２層、左2G、次の地点５
  public const string OHRANTOWER_FLOATINGTILE_78_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_78_O = "78";
  public const float OHRANTOWER_FLOATINGTILE_78_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_78_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_78_Z = -20.0f;

  // ２層、左下2H
  public const string OHRANTOWER_FLOATINGTILE_79_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_79_O = "79";
  public const float OHRANTOWER_FLOATINGTILE_79_X = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_79_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_79_Z = -28.0f;

  // ２層、左下2H、戻り
  public const string OHRANTOWER_FLOATINGTILE_80_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_80_O = "80";
  public const float OHRANTOWER_FLOATINGTILE_80_X = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_80_Y = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_80_Z = -10.0f;

  // ３層、上部５
  public const string OHRANTOWER_FLOATINGTILE_81_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_81_O = "81";
  public const float OHRANTOWER_FLOATINGTILE_81_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_81_Y = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_81_Z = -2.0f;

  // ３層、上部５、戻り
  public const string OHRANTOWER_FLOATINGTILE_82_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_82_O = "82";
  public const float OHRANTOWER_FLOATINGTILE_82_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_82_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_82_Z = -2.0f;

  // ４層、右部６
  public const string OHRANTOWER_FLOATINGTILE_83_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_83_O = "83";
  public const float OHRANTOWER_FLOATINGTILE_83_X = 27.0f;
  public const float OHRANTOWER_FLOATINGTILE_83_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_83_Z = -19.0f;

  // ４層、右部６、戻り
  public const string OHRANTOWER_FLOATINGTILE_84_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_84_O = "84";
  public const float OHRANTOWER_FLOATINGTILE_84_X = 27.0f;
  public const float OHRANTOWER_FLOATINGTILE_84_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_84_Z = -19.0f;

  // ５層、右下７
  public const string OHRANTOWER_FLOATINGTILE_85_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_85_O = "85";
  public const float OHRANTOWER_FLOATINGTILE_85_X = 27.0f;
  public const float OHRANTOWER_FLOATINGTILE_85_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_85_Z = -27.0f;

  // ５層、右下７、戻り
  public const string OHRANTOWER_FLOATINGTILE_86_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_86_O = "86";
  public const float OHRANTOWER_FLOATINGTILE_86_X = 27.0f;
  public const float OHRANTOWER_FLOATINGTILE_86_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_86_Z = -27.0f;

  // ４層、右下4O
  public const string OHRANTOWER_FLOATINGTILE_87_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_87_O = "88";
  public const float OHRANTOWER_FLOATINGTILE_87_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_87_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_87_Z = -27.0f;

  // ４層、右下4O、戻り
  public const string OHRANTOWER_FLOATINGTILE_88_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_88_O = "88";
  public const float OHRANTOWER_FLOATINGTILE_88_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_88_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_88_Z = -27.0f;

  // ４層、右下4O
  public const string OHRANTOWER_FLOATINGTILE_89_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_89_O = "89";
  public const float OHRANTOWER_FLOATINGTILE_89_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_89_Y = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_89_Z = -27.0f;

  // ４層、右下4O、戻り
  public const string OHRANTOWER_FLOATINGTILE_90_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_90_O = "90";
  public const float OHRANTOWER_FLOATINGTILE_90_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_90_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_90_Z = -27.0f;

  // ５層、左下5A
  public const string OHRANTOWER_FLOATINGTILE_91_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_91_O = "91";
  public const float OHRANTOWER_FLOATINGTILE_91_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_91_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_91_Z = -27.0f;

  // ５層、左下5A、戻り
  public const string OHRANTOWER_FLOATINGTILE_92_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_92_O = "92";
  public const float OHRANTOWER_FLOATINGTILE_92_X = 14.0f;
  public const float OHRANTOWER_FLOATINGTILE_92_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_92_Z = -27.0f;

  // ５層、左下5A、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_93_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_93_O = "93";
  public const float OHRANTOWER_FLOATINGTILE_93_X = 14.0f;
  public const float OHRANTOWER_FLOATINGTILE_93_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_93_Z = -25.0f;

  // ５層、左下5A、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_94_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_94_O = "94";
  public const float OHRANTOWER_FLOATINGTILE_94_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_94_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_94_Z = -25.0f;

  // ５層、左下5A、次の地点３
  public const string OHRANTOWER_FLOATINGTILE_95_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_95_O = "95";
  public const float OHRANTOWER_FLOATINGTILE_95_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_95_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_95_Z = -16.0f;

  // ５層、左上5B
  public const string OHRANTOWER_FLOATINGTILE_96_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_96_O = "96";
  public const float OHRANTOWER_FLOATINGTILE_96_X = 9.0f;
  public const float OHRANTOWER_FLOATINGTILE_96_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_96_Z = -11.0f;

  // ５層、左上5B、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_97_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_97_O = "97";
  public const float OHRANTOWER_FLOATINGTILE_97_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_97_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_97_Z = -11.0f;

  // ５層、左上5B、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_98_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_98_O = "98";
  public const float OHRANTOWER_FLOATINGTILE_98_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_98_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_98_Z = -2.0f;

  // ５層、左上5B、次の地点３
  public const string OHRANTOWER_FLOATINGTILE_99_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_99_O = "99";
  public const float OHRANTOWER_FLOATINGTILE_99_X = 9.0f;
  public const float OHRANTOWER_FLOATINGTILE_99_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_99_Z = -2.0f;

  // ５層、左上5B、次の地点４
  public const string OHRANTOWER_FLOATINGTILE_100_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_100_O = "100";
  public const float OHRANTOWER_FLOATINGTILE_100_X = 9.0f;
  public const float OHRANTOWER_FLOATINGTILE_100_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_100_Z = -8.0f;

  // ５層、左上5B、次の地点５
  public const string OHRANTOWER_FLOATINGTILE_101_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_101_O = "101";
  public const float OHRANTOWER_FLOATINGTILE_101_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_101_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_101_Z = -8.0f;

  // ５層、左上5B、次の地点６
  public const string OHRANTOWER_FLOATINGTILE_102_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_102_O = "102";
  public const float OHRANTOWER_FLOATINGTILE_102_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_102_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_102_Z = -4.0f;

  // ５層、左上5B、次の地点７
  public const string OHRANTOWER_FLOATINGTILE_103_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_103_O = "103";
  public const float OHRANTOWER_FLOATINGTILE_103_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_103_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_103_Z = -4.0f;

  // ５層、左上5B、次の地点８
  public const string OHRANTOWER_FLOATINGTILE_104_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_104_O = "104";
  public const float OHRANTOWER_FLOATINGTILE_104_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_104_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_104_Z = -13.0f;

  // ５層、左８
  public const string OHRANTOWER_FLOATINGTILE_105_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_105_O = "105";
  public const float OHRANTOWER_FLOATINGTILE_105_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_105_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_105_Z = -15.0f;

  // ５層、左８、戻り
  public const string OHRANTOWER_FLOATINGTILE_106_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_106_O = "106";
  public const float OHRANTOWER_FLOATINGTILE_106_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_106_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_106_Z = -15.0f;

  // ６層、中央6A
  public const string OHRANTOWER_FLOATINGTILE_107_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_107_O = "107";
  public const float OHRANTOWER_FLOATINGTILE_107_X = 17.0f;
  public const float OHRANTOWER_FLOATINGTILE_107_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_107_Z = -6.0f;

  // ６層、中央6A、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_108_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_108_O = "108";
  public const float OHRANTOWER_FLOATINGTILE_108_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_108_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_108_Z = -6.0f;

  // ６層、中央6A、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_109_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_109_O = "109";
  public const float OHRANTOWER_FLOATINGTILE_109_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_109_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_109_Z = -24.0f;

  // ６層、中央6A、次の地点３
  public const string OHRANTOWER_FLOATINGTILE_110_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_110_O = "110";
  public const float OHRANTOWER_FLOATINGTILE_110_X = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_110_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_110_Z = -24.0f;

  // ６層、中央6A、次の地点４
  public const string OHRANTOWER_FLOATINGTILE_111_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_111_O = "111";
  public const float OHRANTOWER_FLOATINGTILE_111_X = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_111_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_111_Z = -25.0f;

  // ６層、中央6A、次の地点５
  public const string OHRANTOWER_FLOATINGTILE_112_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_112_O = "112";
  public const float OHRANTOWER_FLOATINGTILE_112_X = 14.0f;
  public const float OHRANTOWER_FLOATINGTILE_112_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_112_Z = -25.0f;

  // ６層、中央6A、次の地点６
  public const string OHRANTOWER_FLOATINGTILE_113_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_113_O = "113";
  public const float OHRANTOWER_FLOATINGTILE_113_X = 14.0f;
  public const float OHRANTOWER_FLOATINGTILE_113_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_113_Z = -24.0f;

  // ６層、中央6A、次の地点７
  public const string OHRANTOWER_FLOATINGTILE_114_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_114_O = "114";
  public const float OHRANTOWER_FLOATINGTILE_114_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_114_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_114_Z = -24.0f;

  // ６層、中央6A、次の地点８
  public const string OHRANTOWER_FLOATINGTILE_115_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_115_O = "115";
  public const float OHRANTOWER_FLOATINGTILE_115_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_115_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_115_Z = -19.0f;

  // ６層、中央6A、次の地点９
  public const string OHRANTOWER_FLOATINGTILE_116_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_116_O = "116";
  public const float OHRANTOWER_FLOATINGTILE_116_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_116_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_116_Z = -19.0f;

  // ６層、中央6A、次の地点１０
  public const string OHRANTOWER_FLOATINGTILE_117_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_117_O = "117";
  public const float OHRANTOWER_FLOATINGTILE_117_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_117_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_117_Z = -2.0f;

  // ６層、中央6A、次の地点１１
  public const string OHRANTOWER_FLOATINGTILE_118_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_118_O = "118";
  public const float OHRANTOWER_FLOATINGTILE_118_X = 28.0f;
  public const float OHRANTOWER_FLOATINGTILE_118_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_118_Z = -2.0f;

  // ６層、中央6A、次の地点１２
  public const string OHRANTOWER_FLOATINGTILE_119_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_119_O = "119";
  public const float OHRANTOWER_FLOATINGTILE_119_X = 28.0f;
  public const float OHRANTOWER_FLOATINGTILE_119_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_119_Z = -28.0f;

  // ６層、中央6A、次の地点１３
  public const string OHRANTOWER_FLOATINGTILE_120_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_120_O = "120";
  public const float OHRANTOWER_FLOATINGTILE_120_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_120_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_120_Z = -28.0f;

  // ６層、中央6A、次の地点１４
  public const string OHRANTOWER_FLOATINGTILE_121_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_121_O = "121";
  public const float OHRANTOWER_FLOATINGTILE_121_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_121_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_121_Z = -2.0f;

  // ６層、中央6A、次の地点１５
  public const string OHRANTOWER_FLOATINGTILE_122_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_122_O = "122";
  public const float OHRANTOWER_FLOATINGTILE_122_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_122_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_122_Z = -2.0f;

  // ６層、中央6A、次の地点１６
  public const string OHRANTOWER_FLOATINGTILE_123_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_123_O = "123";
  public const float OHRANTOWER_FLOATINGTILE_123_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_123_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_123_Z = -6.0f;

  // ６層、中央6A、次の地点１７
  public const string OHRANTOWER_FLOATINGTILE_124_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_124_O = "124";
  public const float OHRANTOWER_FLOATINGTILE_124_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_124_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_124_Z = -6.0f;

  // ６層、中央6A、次の地点１８
  public const string OHRANTOWER_FLOATINGTILE_125_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_125_O = "125";
  public const float OHRANTOWER_FLOATINGTILE_125_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_125_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_125_Z = -11.0f;

  // ６層、中央6A、次の地点１９
  public const string OHRANTOWER_FLOATINGTILE_126_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_126_O = "126";
  public const float OHRANTOWER_FLOATINGTILE_126_X = 12.0f;
  public const float OHRANTOWER_FLOATINGTILE_126_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_126_Z = -11.0f;

  // ６層、上部17
  public const string OHRANTOWER_FLOATINGTILE_127_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_127_O = "127";
  public const float OHRANTOWER_FLOATINGTILE_127_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_127_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_127_Z = -2.0f;

  // ６層、上部17、戻り
  public const string OHRANTOWER_FLOATINGTILE_128_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_128_O = "128";
  public const float OHRANTOWER_FLOATINGTILE_128_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_128_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_128_Z = -2.0f;

  // ５層、右上5C
  public const string OHRANTOWER_FLOATINGTILE_129_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_129_O = "129";
  public const float OHRANTOWER_FLOATINGTILE_129_X = 17.0f;
  public const float OHRANTOWER_FLOATINGTILE_129_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_129_Z = -4.0f;

  // ５層、右上5C、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_130_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_130_O = "130";
  public const float OHRANTOWER_FLOATINGTILE_130_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_130_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_130_Z = -4.0f;

  // ５層、右上5C、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_131_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_131_O = "131";
  public const float OHRANTOWER_FLOATINGTILE_131_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_131_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_131_Z = -7.0f;

  // ５層、右上5C、次の地点３
  public const string OHRANTOWER_FLOATINGTILE_132_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_132_O = "132";
  public const float OHRANTOWER_FLOATINGTILE_132_X = 21.0f;
  public const float OHRANTOWER_FLOATINGTILE_132_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_132_Z = -7.0f;

  // ５層、右上5C、次の地点４
  public const string OHRANTOWER_FLOATINGTILE_133_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_133_O = "133";
  public const float OHRANTOWER_FLOATINGTILE_133_X = 21.0f;
  public const float OHRANTOWER_FLOATINGTILE_133_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_133_Z = -2.0f;

  // ５層、右上5C、次の地点５
  public const string OHRANTOWER_FLOATINGTILE_134_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_134_O = "134";
  public const float OHRANTOWER_FLOATINGTILE_134_X = 28.0f;
  public const float OHRANTOWER_FLOATINGTILE_134_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_134_Z = -2.0f;

  // ５層、右上5C、次の地点６
  public const string OHRANTOWER_FLOATINGTILE_135_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_135_O = "135";
  public const float OHRANTOWER_FLOATINGTILE_135_X = 28.0f;
  public const float OHRANTOWER_FLOATINGTILE_135_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_135_Z = -11.0f;

  // ５層、右5D
  public const string OHRANTOWER_FLOATINGTILE_136_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_136_O = "136";
  public const float OHRANTOWER_FLOATINGTILE_136_X = 25.0f;
  public const float OHRANTOWER_FLOATINGTILE_136_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_136_Z = -12.0f;

  // ５層、右5D、戻り
  public const string OHRANTOWER_FLOATINGTILE_137_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_137_O = "137";
  public const float OHRANTOWER_FLOATINGTILE_137_X = 20.0f;
  public const float OHRANTOWER_FLOATINGTILE_137_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_137_Z = -12.0f;

  // ６層、中央10
  public const string OHRANTOWER_FLOATINGTILE_138_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_138_O = "138";
  public const float OHRANTOWER_FLOATINGTILE_138_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_138_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_138_Z = -13.0f;

  // ６層、中央10、戻り
  public const string OHRANTOWER_FLOATINGTILE_139_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_139_O = "139";
  public const float OHRANTOWER_FLOATINGTILE_139_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_139_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_139_Z = -13.0f;

  // ７層、右上7A
  public const string OHRANTOWER_FLOATINGTILE_140_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_140_O = "140";
  public const float OHRANTOWER_FLOATINGTILE_140_X = 23.0f;
  public const float OHRANTOWER_FLOATINGTILE_140_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_140_Z = -3.0f;

  // ７層、右上7A、戻り
  public const string OHRANTOWER_FLOATINGTILE_141_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_141_O = "141";
  public const float OHRANTOWER_FLOATINGTILE_141_X = 26.0f;
  public const float OHRANTOWER_FLOATINGTILE_141_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_141_Z = -3.0f;

  // ７層、中央左7B
  public const string OHRANTOWER_FLOATINGTILE_142_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_142_O = "142";
  public const float OHRANTOWER_FLOATINGTILE_142_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_142_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_142_Z = -12.0f;

  // ７層、中央左7B、戻り
  public const string OHRANTOWER_FLOATINGTILE_143_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_143_O = "143";
  public const float OHRANTOWER_FLOATINGTILE_143_X = 10.0f;
  public const float OHRANTOWER_FLOATINGTILE_143_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_143_Z = -18.0f;

  // ７層、左下7C
  public const string OHRANTOWER_FLOATINGTILE_144_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_144_O = "144";
  public const float OHRANTOWER_FLOATINGTILE_144_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_144_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_144_Z = -26.0f;

  // ７層、左下7C、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_145_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_145_O = "145";
  public const float OHRANTOWER_FLOATINGTILE_145_X = 11.0f;
  public const float OHRANTOWER_FLOATINGTILE_145_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_145_Z = -28.0f;

  // ７層、左下7C、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_146_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_146_O = "146";
  public const float OHRANTOWER_FLOATINGTILE_146_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_146_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_146_Z = -28.0f;

  // ７層、左下7C、次の地点３
  public const string OHRANTOWER_FLOATINGTILE_147_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_147_O = "147";
  public const float OHRANTOWER_FLOATINGTILE_147_X = 2.0f;
  public const float OHRANTOWER_FLOATINGTILE_147_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_147_Z = -2.0f;

  // ７層、左下7C、次の地点４
  public const string OHRANTOWER_FLOATINGTILE_148_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_148_O = "148";
  public const float OHRANTOWER_FLOATINGTILE_148_X = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_148_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_148_Z = -2.0f;

  // ７層、左下7C、次の地点５
  public const string OHRANTOWER_FLOATINGTILE_149_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_149_O = "149";
  public const float OHRANTOWER_FLOATINGTILE_149_X = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_149_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_149_Z = -7.0f;

  // ７層、左下7C、次の地点６
  public const string OHRANTOWER_FLOATINGTILE_150_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_150_O = "150";
  public const float OHRANTOWER_FLOATINGTILE_150_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_150_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_150_Z = -7.0f;

  // ７層、左下7C、次の地点７
  public const string OHRANTOWER_FLOATINGTILE_151_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_151_O = "151";
  public const float OHRANTOWER_FLOATINGTILE_151_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_151_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_151_Z = -12.0f;

  // ７層、左下7C、次の地点８
  public const string OHRANTOWER_FLOATINGTILE_152_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_152_O = "152";
  public const float OHRANTOWER_FLOATINGTILE_152_X = 12.0f;
  public const float OHRANTOWER_FLOATINGTILE_152_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_152_Z = -12.0f;

  // ７層、左下7C、次の地点９
  public const string OHRANTOWER_FLOATINGTILE_153_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_153_O = "153";
  public const float OHRANTOWER_FLOATINGTILE_153_X = 12.0f;
  public const float OHRANTOWER_FLOATINGTILE_153_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_153_Z = -21.0f;

  // ７層、左下7C、次の地点１０
  public const string OHRANTOWER_FLOATINGTILE_154_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_154_O = "154";
  public const float OHRANTOWER_FLOATINGTILE_154_X = 18.0f;
  public const float OHRANTOWER_FLOATINGTILE_154_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_154_Z = -21.0f;

  // ７層、左下7C、次の地点１１
  public const string OHRANTOWER_FLOATINGTILE_155_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_155_O = "155";
  public const float OHRANTOWER_FLOATINGTILE_155_X = 18.0f;
  public const float OHRANTOWER_FLOATINGTILE_155_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_155_Z = -14.0f;

  // ７層、下部右7D
  public const string OHRANTOWER_FLOATINGTILE_156_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_156_O = "156";
  public const float OHRANTOWER_FLOATINGTILE_156_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_156_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_156_Z = -26.0f;

  // ７層、下部右7D、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_157_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_157_O = "157";
  public const float OHRANTOWER_FLOATINGTILE_157_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_157_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_157_Z = -28.0f;

  // ７層、下部右7D、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_158_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_158_O = "158";
  public const float OHRANTOWER_FLOATINGTILE_158_X = 28.0f;
  public const float OHRANTOWER_FLOATINGTILE_158_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_158_Z = -28.0f;

  // ７層、下部右7D、次の地点３
  public const string OHRANTOWER_FLOATINGTILE_159_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_159_O = "159";
  public const float OHRANTOWER_FLOATINGTILE_159_X = 28.0f;
  public const float OHRANTOWER_FLOATINGTILE_159_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_159_Z = -24.0f;

  // ７層、下部右7D、次の地点４
  public const string OHRANTOWER_FLOATINGTILE_160_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_160_O = "160";
  public const float OHRANTOWER_FLOATINGTILE_160_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_160_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_160_Z = -24.0f;

  // ７層、下部右7D、次の地点５
  public const string OHRANTOWER_FLOATINGTILE_161_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_161_O = "161";
  public const float OHRANTOWER_FLOATINGTILE_161_X = 24.0f;
  public const float OHRANTOWER_FLOATINGTILE_161_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_161_Z = -10.0f;

  // ７層、下部右7D、次の地点６
  public const string OHRANTOWER_FLOATINGTILE_162_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_162_O = "162";
  public const float OHRANTOWER_FLOATINGTILE_162_X = 26.0f;
  public const float OHRANTOWER_FLOATINGTILE_162_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_162_Z = -10.0f;

  // ７層、下部右7D、次の地点７
  public const string OHRANTOWER_FLOATINGTILE_163_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_163_O = "163";
  public const float OHRANTOWER_FLOATINGTILE_163_X = 26.0f;
  public const float OHRANTOWER_FLOATINGTILE_163_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_163_Z = -12.0f;

  // ７層、右９
  public const string OHRANTOWER_FLOATINGTILE_164_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_164_O = "164";
  public const float OHRANTOWER_FLOATINGTILE_164_X = 26.0f;
  public const float OHRANTOWER_FLOATINGTILE_164_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_164_Z = -15.0f;

  // ７層、右９、戻り
  public const string OHRANTOWER_FLOATINGTILE_165_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_165_O = "165";
  public const float OHRANTOWER_FLOATINGTILE_165_X = 26.0f;
  public const float OHRANTOWER_FLOATINGTILE_165_Y = 40.0f;
  public const float OHRANTOWER_FLOATINGTILE_165_Z = -15.0f;

  // ７層、右下7E
  public const string OHRANTOWER_FLOATINGTILE_166_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_166_O = "166";
  public const float OHRANTOWER_FLOATINGTILE_166_X = 22.0f;
  public const float OHRANTOWER_FLOATINGTILE_166_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_166_Z = -22.0f;

  // ７層、右下7E、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_167_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_167_O = "167";
  public const float OHRANTOWER_FLOATINGTILE_167_X = 28.0f;
  public const float OHRANTOWER_FLOATINGTILE_167_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_167_Z = -22.0f;

  // ７層、右下7E、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_168_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_168_O = "168";
  public const float OHRANTOWER_FLOATINGTILE_168_X = 28.0f;
  public const float OHRANTOWER_FLOATINGTILE_168_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_168_Z = -2.0f;

  // ７層、右下7E、次の地点３
  public const string OHRANTOWER_FLOATINGTILE_169_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_169_O = "169";
  public const float OHRANTOWER_FLOATINGTILE_169_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_169_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_169_Z = -2.0f;

  // ７層、右下7E、次の地点４
  public const string OHRANTOWER_FLOATINGTILE_170_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_170_O = "170";
  public const float OHRANTOWER_FLOATINGTILE_170_X = 19.0f;
  public const float OHRANTOWER_FLOATINGTILE_170_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_170_Z = -6.0f;

  // ７層、右下7E、次の地点５
  public const string OHRANTOWER_FLOATINGTILE_171_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_171_O = "171";
  public const float OHRANTOWER_FLOATINGTILE_171_X = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_171_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_171_Z = -6.0f;

  // ７層、右下7E、次の地点６
  public const string OHRANTOWER_FLOATINGTILE_172_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_172_O = "172";
  public const float OHRANTOWER_FLOATINGTILE_172_X = 16.0f;
  public const float OHRANTOWER_FLOATINGTILE_172_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_172_Z = -4.0f;

  // ７層、中央右下7F
  public const string OHRANTOWER_FLOATINGTILE_173_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_173_O = "173";
  public const float OHRANTOWER_FLOATINGTILE_173_X = 20.0f;
  public const float OHRANTOWER_FLOATINGTILE_173_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_173_Z = -17.0f;

  // ７層、中央右下7F、戻り
  public const string OHRANTOWER_FLOATINGTILE_174_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_174_O = "174";
  public const float OHRANTOWER_FLOATINGTILE_174_X = 20.0f;
  public const float OHRANTOWER_FLOATINGTILE_174_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_174_Z = -12.0f;

  // ７層、中央右上7G
  public const string OHRANTOWER_FLOATINGTILE_175_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_175_O = "175";
  public const float OHRANTOWER_FLOATINGTILE_175_X = 22.0f;
  public const float OHRANTOWER_FLOATINGTILE_175_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_175_Z = -12.0f;

  // ７層、中央右上7G、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_176_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_176_O = "176";
  public const float OHRANTOWER_FLOATINGTILE_176_X = 22.0f;
  public const float OHRANTOWER_FLOATINGTILE_176_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_176_Z = -17.0f;

  // ７層、中央右上7G、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_177_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_177_O = "177";
  public const float OHRANTOWER_FLOATINGTILE_177_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_177_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_177_Z = -17.0f;

  // ７層、左7H
  public const string OHRANTOWER_FLOATINGTILE_178_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_178_O = "178";
  public const float OHRANTOWER_FLOATINGTILE_178_X = 5.0f;
  public const float OHRANTOWER_FLOATINGTILE_178_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_178_Z = -19.0f;

  // ７層、左7H、戻り
  public const string OHRANTOWER_FLOATINGTILE_179_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_179_O = "179";
  public const float OHRANTOWER_FLOATINGTILE_179_X = 9.0f;
  public const float OHRANTOWER_FLOATINGTILE_179_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_179_Z = -19.0f;

  // ７層、左下7I
  public const string OHRANTOWER_FLOATINGTILE_180_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_180_O = "180";
  public const float OHRANTOWER_FLOATINGTILE_180_X = 8.0f;
  public const float OHRANTOWER_FLOATINGTILE_180_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_180_Z = -22.0f;

  // ７層、左下7I、次の地点１
  public const string OHRANTOWER_FLOATINGTILE_181_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_181_O = "181";
  public const float OHRANTOWER_FLOATINGTILE_181_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_181_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_181_Z = -22.0f;

  // ７層、左下7I、次の地点２
  public const string OHRANTOWER_FLOATINGTILE_182_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_182_O = "182";
  public const float OHRANTOWER_FLOATINGTILE_182_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_182_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_182_Z = -26.0f;

  // ７層、左下7I、次の地点３
  public const string OHRANTOWER_FLOATINGTILE_183_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_183_O = "183";
  public const float OHRANTOWER_FLOATINGTILE_183_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_183_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_183_Z = -26.0f;

  // ７層、左下7I、次の地点４
  public const string OHRANTOWER_FLOATINGTILE_184_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_184_O = "184";
  public const float OHRANTOWER_FLOATINGTILE_184_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_184_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_184_Z = -17.0f;

  // ７層、中央7J
  public const string OHRANTOWER_FLOATINGTILE_185_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_185_O = "185";
  public const float OHRANTOWER_FLOATINGTILE_185_X = 13.0f;
  public const float OHRANTOWER_FLOATINGTILE_185_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_185_Z = -15.0f;

  // ７層、中央7J、戻り
  public const string OHRANTOWER_FLOATINGTILE_186_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_186_O = "186";
  public const float OHRANTOWER_FLOATINGTILE_186_X = 6.0f;
  public const float OHRANTOWER_FLOATINGTILE_186_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_186_Z = -15.0f;

  // ７層、左11
  public const string OHRANTOWER_FLOATINGTILE_187_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_187_O = "187";
  public const float OHRANTOWER_FLOATINGTILE_187_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_187_Y = 48.0f;
  public const float OHRANTOWER_FLOATINGTILE_187_Z = -15.0f;

  // ７層、左11、戻り
  public const string OHRANTOWER_FLOATINGTILE_188_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_188_O = "188";
  public const float OHRANTOWER_FLOATINGTILE_188_X = 4.0f;
  public const float OHRANTOWER_FLOATINGTILE_188_Y = 56.0f;
  public const float OHRANTOWER_FLOATINGTILE_188_Z = -15.0f;

  // ８層、中枢部
  public const string OHRANTOWER_FLOATINGTILE_189_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_189_O = "189";
  public const float OHRANTOWER_FLOATINGTILE_189_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_189_Y = 56.0f;
  public const float OHRANTOWER_FLOATINGTILE_189_Z = -15.0f;
  public const string OHRANTOWER_FLOATINGTILE_189_OBJID = "65";

  // ８層、中枢部、戻り
  public const string OHRANTOWER_FLOATINGTILE_190_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_190_O = "190";
  public const float OHRANTOWER_FLOATINGTILE_190_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_190_Y = -0.0f;
  public const float OHRANTOWER_FLOATINGTILE_190_Z = -15.0f;

  // ０層、右0A
  public const string OHRANTOWER_FLOATINGTILE_191_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_191_O = "191";
  public const float OHRANTOWER_FLOATINGTILE_191_X = 27.0f;
  public const float OHRANTOWER_FLOATINGTILE_191_Y = -56.0f;
  public const float OHRANTOWER_FLOATINGTILE_191_Z = -9.0f;

  // ０層、右0A、戻り
  public const string OHRANTOWER_FLOATINGTILE_192_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_192_O = "192";
  public const float OHRANTOWER_FLOATINGTILE_192_X = 12.0f;
  public const float OHRANTOWER_FLOATINGTILE_192_Y = -56.0f;
  public const float OHRANTOWER_FLOATINGTILE_192_Z = -9.0f;

  // ５層、中央右
  public const string OHRANTOWER_FLOATINGTILE_193_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_193_O = "193";
  public const float OHRANTOWER_FLOATINGTILE_193_X = 22.0f;
  public const float OHRANTOWER_FLOATINGTILE_193_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_193_Z = -16.0f;

  // ５層、中央右、戻り
  public const string OHRANTOWER_FLOATINGTILE_194_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_194_O = "194";
  public const float OHRANTOWER_FLOATINGTILE_194_X = 22.0f;
  public const float OHRANTOWER_FLOATINGTILE_194_Y = 32.0f;
  public const float OHRANTOWER_FLOATINGTILE_194_Z = -22.0f;

  // ０層、始まりを示す浮遊石
  public const string OHRANTOWER_FLOATINGTILE_195_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_195_O = "195";
  public const float OHRANTOWER_FLOATINGTILE_195_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_195_Y = 0.0f;
  public const float OHRANTOWER_FLOATINGTILE_195_Z = -15.0f;
  public const string OHRANTOWER_FLOATINGTILE_195_OBJID = "66";

  // ０層、始まりを示す浮遊石、戻り
  public const string OHRANTOWER_FLOATINGTILE_196_C = "FloatingTile";
  public const string OHRANTOWER_FLOATINGTILE_196_O = "196";
  public const float OHRANTOWER_FLOATINGTILE_196_X = 15.0f;
  public const float OHRANTOWER_FLOATINGTILE_196_Y = -56.0f;
  public const float OHRANTOWER_FLOATINGTILE_196_Z = -15.0f;
  #endregion

  #region "Event"
  // エントランス会話
  public const string OHRANTOWER_EVENT_1_C = "Event";
  public const string OHRANTOWER_EVENT_1_O = "1";
  public const float OHRANTOWER_EVENT_1_X = 15.0f;
  public const float OHRANTOWER_EVENT_1_Y = 0.0f;
  public const float OHRANTOWER_EVENT_1_Z = -27.0f;

  // オーランの塔、雷光ランスボルツ戦前の会話
  public const string OHRANTOWER_EVENT_2_C = "Event";
  public const string OHRANTOWER_EVENT_2_O = "2";
  public const float OHRANTOWER_EVENT_2_X = 22.0f;
  public const float OHRANTOWER_EVENT_2_Y = 32.0f;
  public const float OHRANTOWER_EVENT_2_Z = -24.0f;

  // オーランの塔、雷光ランスボルツ戦
  public const string OHRANTOWER_EVENT_3_C = "Event";
  public const string OHRANTOWER_EVENT_3_O = "3";
  public const float OHRANTOWER_EVENT_3_X = 22.0f;
  public const float OHRANTOWER_EVENT_3_Y = 32.0f;
  public const float OHRANTOWER_EVENT_3_Z = -25.0f;

  // オーランの塔、中盤の会話
  public const string OHRANTOWER_EVENT_4_C = "Event";
  public const string OHRANTOWER_EVENT_4_O = "4";
  public const float OHRANTOWER_EVENT_4_X = 8.0f;
  public const float OHRANTOWER_EVENT_4_Y = 40.0f;
  public const float OHRANTOWER_EVENT_4_Z = -15.0f;

  // オーランの塔、中盤の会話２
  public const string OHRANTOWER_EVENT_5_C = "Event";
  public const string OHRANTOWER_EVENT_5_O = "5";
  public const float OHRANTOWER_EVENT_5_X = 15.0f;
  public const float OHRANTOWER_EVENT_5_Y = 48.0f;
  public const float OHRANTOWER_EVENT_5_Z = -7.0f;

  // オーランの塔、中盤の会話３
  public const string OHRANTOWER_EVENT_6_C = "Event";
  public const string OHRANTOWER_EVENT_6_O = "6";
  public const float OHRANTOWER_EVENT_6_X = 14.0f;
  public const float OHRANTOWER_EVENT_6_Y = 48.0f;
  public const float OHRANTOWER_EVENT_6_Z = -15.0f;

  // オーランの塔、ボス前の察知
  public const float EVENT_OHRANTOWER_9_X = 15.0f;
  public const float EVENT_OHRANTOWER_9_Y = 56.0f;
  public const float EVENT_OHRANTOWER_9_Z = -2.0f;

  // オーランの塔、ボス戦前の会話
  public const float EVENT_OHRANTOWER_10_X = 15.0f;
  public const float EVENT_OHRANTOWER_10_Y = 56.0f;
  public const float EVENT_OHRANTOWER_10_Z = -24.0f;

  // オーランの塔、ボス戦の会話
  public const float EVENT_OHRANTOWER_11_X = 15.0f;
  public const float EVENT_OHRANTOWER_11_Y = 56.0f;
  public const float EVENT_OHRANTOWER_11_Z = -22.0f;

  // オーランの塔、中央扉
  public const float EVENT_OHRANTOWER_12_X = 15.0f;
  public const float EVENT_OHRANTOWER_12_Y = 56.0f;
  public const float EVENT_OHRANTOWER_12_Z = -11.0f;

  // オーランの塔、頂上
  public const float EVENT_OHRANTOWER_13_X = 15.0f;
  public const float EVENT_OHRANTOWER_13_Y = 56.0f;
  public const float EVENT_OHRANTOWER_13_Z = -9.0f;

  // エントランス会話(制覇後）
  public const string OHRANTOWER_EVENT_14_C = "Event";
  public const string OHRANTOWER_EVENT_14_O = "14";
  public const float OHRANTOWER_EVENT_14_X = 15.0f;
  public const float OHRANTOWER_EVENT_14_Y = 0.0f;
  public const float OHRANTOWER_EVENT_14_Z = -26.0f;

  // 中央最下層向け浮遊石の前会話(制覇後）
  public const string OHRANTOWER_EVENT_15_C = "Event";
  public const string OHRANTOWER_EVENT_15_O = "15";
  public const float OHRANTOWER_EVENT_15_X = 15.0f;
  public const float OHRANTOWER_EVENT_15_Y = 0.0f;
  public const float OHRANTOWER_EVENT_15_Z = -17.0f;

  #endregion

  #region "Treasure"
  public const string OHRANTOWER_Treasure_1_C = "Treasure";
  public const string OHRANTOWER_Treasure_1_O = "1";
  public const float OHRANTOWER_Treasure_1_X = 15.0f;
  public const float OHRANTOWER_Treasure_1_Y = 1.0f;
  public const float OHRANTOWER_Treasure_1_Z = -10.0f;

  public const string OHRANTOWER_Treasure_2_C = "Treasure";
  public const string OHRANTOWER_Treasure_2_O = "2";
  public const float OHRANTOWER_Treasure_2_X = 19.0f;
  public const float OHRANTOWER_Treasure_2_Y = 9.0f;
  public const float OHRANTOWER_Treasure_2_Z = -17.0f;

  public const string OHRANTOWER_Treasure_3_C = "Treasure";
  public const string OHRANTOWER_Treasure_3_O = "3";
  public const float OHRANTOWER_Treasure_3_X = 11.0f;
  public const float OHRANTOWER_Treasure_3_Y = 9.0f;
  public const float OHRANTOWER_Treasure_3_Z = -5.0f;

  public const string OHRANTOWER_Treasure_4_C = "Treasure";
  public const string OHRANTOWER_Treasure_4_O = "4";
  public const float OHRANTOWER_Treasure_4_X = 29.0f;
  public const float OHRANTOWER_Treasure_4_Y = 9.0f;
  public const float OHRANTOWER_Treasure_4_Z = -15.0f;

  public const string OHRANTOWER_Treasure_5_C = "Treasure";
  public const string OHRANTOWER_Treasure_5_O = "5";
  public const float OHRANTOWER_Treasure_5_X = 15.0f;
  public const float OHRANTOWER_Treasure_5_Y = 9.0f;
  public const float OHRANTOWER_Treasure_5_Z = -21.0f;

  public const string OHRANTOWER_Treasure_6_C = "Treasure";
  public const string OHRANTOWER_Treasure_6_O = "6";
  public const float OHRANTOWER_Treasure_6_X = 8.0f;
  public const float OHRANTOWER_Treasure_6_Y = 9.0f;
  public const float OHRANTOWER_Treasure_6_Z = -4.0f;

  public const string OHRANTOWER_Treasure_7_C = "Treasure";
  public const string OHRANTOWER_Treasure_7_O = "7";
  public const float OHRANTOWER_Treasure_7_X = 6.0f;
  public const float OHRANTOWER_Treasure_7_Y = 9.0f;
  public const float OHRANTOWER_Treasure_7_Z = -29.0f;

  public const string OHRANTOWER_Treasure_8_C = "Treasure";
  public const string OHRANTOWER_Treasure_8_O = "8";
  public const float OHRANTOWER_Treasure_8_X = 7.0f;
  public const float OHRANTOWER_Treasure_8_Y = 17.0f;
  public const float OHRANTOWER_Treasure_8_Z = -16.0f;

  public const string OHRANTOWER_Treasure_9_C = "Treasure";
  public const string OHRANTOWER_Treasure_9_O = "9";
  public const float OHRANTOWER_Treasure_9_X = 5.0f;
  public const float OHRANTOWER_Treasure_9_Y = 17.0f;
  public const float OHRANTOWER_Treasure_9_Z = -16.0f;

  public const string OHRANTOWER_Treasure_10_C = "Treasure";
  public const string OHRANTOWER_Treasure_10_O = "10";
  public const float OHRANTOWER_Treasure_10_X = 4.0f;
  public const float OHRANTOWER_Treasure_10_Y = 17.0f;
  public const float OHRANTOWER_Treasure_10_Z = -9.0f;

  public const string OHRANTOWER_Treasure_11_C = "Treasure";
  public const string OHRANTOWER_Treasure_11_O = "11";
  public const float OHRANTOWER_Treasure_11_X = 19.0f;
  public const float OHRANTOWER_Treasure_11_Y = 17.0f;
  public const float OHRANTOWER_Treasure_11_Z = -8.0f;

  public const string OHRANTOWER_Treasure_12_C = "Treasure";
  public const string OHRANTOWER_Treasure_12_O = "12";
  public const float OHRANTOWER_Treasure_12_X = 23.0f;
  public const float OHRANTOWER_Treasure_12_Y = 17.0f;
  public const float OHRANTOWER_Treasure_12_Z = -1.0f;

  public const string OHRANTOWER_Treasure_13_C = "Treasure";
  public const string OHRANTOWER_Treasure_13_O = "13";
  public const float OHRANTOWER_Treasure_13_X = 11.0f;
  public const float OHRANTOWER_Treasure_13_Y = 17.0f;
  public const float OHRANTOWER_Treasure_13_Z = -2.0f;

  public const string OHRANTOWER_Treasure_14_C = "Treasure";
  public const string OHRANTOWER_Treasure_14_O = "14";
  public const float OHRANTOWER_Treasure_14_X = 1.0f;
  public const float OHRANTOWER_Treasure_14_Y = 25.0f;
  public const float OHRANTOWER_Treasure_14_Z = -6.0f;

  public const string OHRANTOWER_Treasure_15_C = "Treasure";
  public const string OHRANTOWER_Treasure_15_O = "15";
  public const float OHRANTOWER_Treasure_15_X = 2.0f;
  public const float OHRANTOWER_Treasure_15_Y = 25.0f;
  public const float OHRANTOWER_Treasure_15_Z = -21.0f;

  public const string OHRANTOWER_Treasure_16_C = "Treasure";
  public const string OHRANTOWER_Treasure_16_O = "16";
  public const float OHRANTOWER_Treasure_16_X = 15.0f;
  public const float OHRANTOWER_Treasure_16_Y = 25.0f;
  public const float OHRANTOWER_Treasure_16_Z = -19.0f;

  public const string OHRANTOWER_Treasure_17_C = "Treasure";
  public const string OHRANTOWER_Treasure_17_O = "17";
  public const float OHRANTOWER_Treasure_17_X = 27.0f;
  public const float OHRANTOWER_Treasure_17_Y = 25.0f;
  public const float OHRANTOWER_Treasure_17_Z = -3.0f;

  public const string OHRANTOWER_Treasure_18_C = "Treasure";
  public const string OHRANTOWER_Treasure_18_O = "18";
  public const float OHRANTOWER_Treasure_18_X = 14.0f;
  public const float OHRANTOWER_Treasure_18_Y = 33.0f;
  public const float OHRANTOWER_Treasure_18_Z = -21.0f;

  public const string OHRANTOWER_Treasure_19_C = "Treasure";
  public const string OHRANTOWER_Treasure_19_O = "19";
  public const float OHRANTOWER_Treasure_19_X = 16.0f;
  public const float OHRANTOWER_Treasure_19_Y = 33.0f;
  public const float OHRANTOWER_Treasure_19_Z = -21.0f;

  public const string OHRANTOWER_Treasure_20_C = "Treasure";
  public const string OHRANTOWER_Treasure_20_O = "20";
  public const float OHRANTOWER_Treasure_20_X = 18.0f;
  public const float OHRANTOWER_Treasure_20_Y = 33.0f;
  public const float OHRANTOWER_Treasure_20_Z = -15.0f;

  public const string OHRANTOWER_Treasure_21_C = "Treasure";
  public const string OHRANTOWER_Treasure_21_O = "21";
  public const float OHRANTOWER_Treasure_21_X = 7.0f;
  public const float OHRANTOWER_Treasure_21_Y = 33.0f;
  public const float OHRANTOWER_Treasure_21_Z = -20.0f;

  public const string OHRANTOWER_Treasure_22_C = "Treasure";
  public const string OHRANTOWER_Treasure_22_O = "22";
  public const float OHRANTOWER_Treasure_22_X = 14.0f;
  public const float OHRANTOWER_Treasure_22_Y = 33.0f;
  public const float OHRANTOWER_Treasure_22_Z = -9.0f;

  public const string OHRANTOWER_Treasure_23_C = "Treasure";
  public const string OHRANTOWER_Treasure_23_O = "23";
  public const float OHRANTOWER_Treasure_23_X = 16.0f;
  public const float OHRANTOWER_Treasure_23_Y = 33.0f;
  public const float OHRANTOWER_Treasure_23_Z = -9.0f;

  public const string OHRANTOWER_Treasure_24_C = "Treasure";
  public const string OHRANTOWER_Treasure_24_O = "24";
  public const float OHRANTOWER_Treasure_24_X = 26.0f;
  public const float OHRANTOWER_Treasure_24_Y = 33.0f;
  public const float OHRANTOWER_Treasure_24_Z = -15.0f;

  public const string OHRANTOWER_Treasure_25_C = "Treasure";
  public const string OHRANTOWER_Treasure_25_O = "25";
  public const float OHRANTOWER_Treasure_25_X = 8.0f;
  public const float OHRANTOWER_Treasure_25_Y = 41.0f;
  public const float OHRANTOWER_Treasure_25_Z = -10.0f;

  public const string OHRANTOWER_Treasure_26_C = "Treasure";
  public const string OHRANTOWER_Treasure_26_O = "26";
  public const float OHRANTOWER_Treasure_26_X = 8.0f;
  public const float OHRANTOWER_Treasure_26_Y = 41.0f;
  public const float OHRANTOWER_Treasure_26_Z = -20.0f;

  public const string OHRANTOWER_Treasure_27_C = "Treasure";
  public const string OHRANTOWER_Treasure_27_O = "27";
  public const float OHRANTOWER_Treasure_27_X = 20.0f;
  public const float OHRANTOWER_Treasure_27_Y = 41.0f;
  public const float OHRANTOWER_Treasure_27_Z = -9.0f;

  public const string OHRANTOWER_Treasure_28_C = "Treasure";
  public const string OHRANTOWER_Treasure_28_O = "28";
  public const float OHRANTOWER_Treasure_28_X = 26.0f;
  public const float OHRANTOWER_Treasure_28_Y = 41.0f;
  public const float OHRANTOWER_Treasure_28_Z = -11.0f;

  public const string OHRANTOWER_Treasure_29_C = "Treasure";
  public const string OHRANTOWER_Treasure_29_O = "29";
  public const float OHRANTOWER_Treasure_29_X = 25.0f;
  public const float OHRANTOWER_Treasure_29_Y = 49.0f;
  public const float OHRANTOWER_Treasure_29_Z = -6.0f;

  public const string OHRANTOWER_Treasure_30_C = "Treasure";
  public const string OHRANTOWER_Treasure_30_O = "30";
  public const float OHRANTOWER_Treasure_30_X = 1.0f;
  public const float OHRANTOWER_Treasure_30_Y = 49.0f;
  public const float OHRANTOWER_Treasure_30_Z = -1.0f;

  public const string OHRANTOWER_Treasure_31_C = "Treasure";
  public const string OHRANTOWER_Treasure_31_O = "31";
  public const float OHRANTOWER_Treasure_31_X = 20.0f;
  public const float OHRANTOWER_Treasure_31_Y = 49.0f;
  public const float OHRANTOWER_Treasure_31_Z = -9.0f;

  public const string OHRANTOWER_Treasure_32_C = "Treasure";
  public const string OHRANTOWER_Treasure_32_O = "32";
  public const float OHRANTOWER_Treasure_32_X = 23.0f;
  public const float OHRANTOWER_Treasure_32_Y = 49.0f;
  public const float OHRANTOWER_Treasure_32_Z = -27.0f;

  public const string OHRANTOWER_Treasure_33_C = "Treasure";
  public const string OHRANTOWER_Treasure_33_O = "33";
  public const float OHRANTOWER_Treasure_33_X = 14.0f;
  public const float OHRANTOWER_Treasure_33_Y = 49.0f;
  public const float OHRANTOWER_Treasure_33_Z = -3.0f;

  public const string OHRANTOWER_Treasure_34_C = "Treasure";
  public const string OHRANTOWER_Treasure_34_O = "34";
  public const float OHRANTOWER_Treasure_34_X = 15.0f;
  public const float OHRANTOWER_Treasure_34_Y = 49.0f;
  public const float OHRANTOWER_Treasure_34_Z = -28.0f;

  public const string OHRANTOWER_Treasure_35_C = "Treasure";
  public const string OHRANTOWER_Treasure_35_O = "35";
  public const float OHRANTOWER_Treasure_35_X = 28.0f;
  public const float OHRANTOWER_Treasure_35_Y = 57.0f;
  public const float OHRANTOWER_Treasure_35_Z = -15.0f;

  public const string OHRANTOWER_Treasure_36_C = "Treasure";
  public const string OHRANTOWER_Treasure_36_O = "36";
  public const float OHRANTOWER_Treasure_36_X = 4.0f;
  public const float OHRANTOWER_Treasure_36_Y = 57.0f;
  public const float OHRANTOWER_Treasure_36_Z = -18.0f;

  public const string OHRANTOWER_Treasure_37_C = "Treasure";
  public const string OHRANTOWER_Treasure_37_O = "37";
  public const float OHRANTOWER_Treasure_37_X = 22.0f;
  public const float OHRANTOWER_Treasure_37_Y = 33.0f;
  public const float OHRANTOWER_Treasure_37_Z = -28.0f;
  #endregion

  #region "FloatingTile / WarpHole"
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

  public const string OHRANTOWER_WarpHole_26_C = "WarpHole";
  public const string OHRANTOWER_WarpHole_26_O = "26";
  public const float OHRANTOWER_WarpHole_26_X = 1f;
  public const float OHRANTOWER_WarpHole_26_Y = 44f;
  public const float OHRANTOWER_WarpHole_26_Z = 20f;
  #endregion

  #region "鍵付き扉"
  public const string OHRANTOWER_KEYDOOR_1_C = "KeyDoor";
  public const string OHRANTOWER_KEYDOOR_1_O = "1";
  public const float OHRANTOWER_KEYDOOR_1_X = 20.0f;
  public const float OHRANTOWER_KEYDOOR_1_Y = 16.5f;
  public const float OHRANTOWER_KEYDOOR_1_Z = -4.0f;

  public const string OHRANTOWER_KEYDOOR_2_C = "KeyDoor";
  public const string OHRANTOWER_KEYDOOR_2_O = "2";
  public const float OHRANTOWER_KEYDOOR_2_X = 18.0f;
  public const float OHRANTOWER_KEYDOOR_2_Y = 16.5f;
  public const float OHRANTOWER_KEYDOOR_2_Z = -4.0f;

  public const string OHRANTOWER_KEYDOOR_3_C = "KeyDoor";
  public const string OHRANTOWER_KEYDOOR_3_O = "3";
  public const float OHRANTOWER_KEYDOOR_3_X = 15.0f;
  public const float OHRANTOWER_KEYDOOR_3_Y = 56.5f;
  public const float OHRANTOWER_KEYDOOR_3_Z = -12.0f;

  public const string OHRANTOWER_KEYDOOR_4_C = "KeyDoor";
  public const string OHRANTOWER_KEYDOOR_4_O = "4";
  public const float OHRANTOWER_KEYDOOR_4_X = 15.0f;
  public const float OHRANTOWER_KEYDOOR_4_Y = 0.5f;
  public const float OHRANTOWER_KEYDOOR_4_Z = -19.0f;
  #endregion

  #region "回復の泉"
  public const string OHRANTOWER_FOUNTAIN_1_C = "Fountain";
  public const string OHRANTOWER_FOUNTAIN_1_O = "1";
  public const float OHRANTOWER_FOUNTAIN_1_X = 15.0f;
  public const float OHRANTOWER_FOUNTAIN_1_Y = 1.0f;
  public const float OHRANTOWER_FOUNTAIN_1_Z = -24.0f;

  public const string OHRANTOWER_FOUNTAIN_2_C = "Fountain";
  public const string OHRANTOWER_FOUNTAIN_2_O = "2";
  public const float OHRANTOWER_FOUNTAIN_2_X = 19.0f;
  public const float OHRANTOWER_FOUNTAIN_2_Y = 25.0f;
  public const float OHRANTOWER_FOUNTAIN_2_Z = -15.0f;

  public const string OHRANTOWER_FOUNTAIN_3_C = "Fountain";
  public const string OHRANTOWER_FOUNTAIN_3_O = "3";
  public const float OHRANTOWER_FOUNTAIN_3_X = 15.0f;
  public const float OHRANTOWER_FOUNTAIN_3_Y = 1.0f;
  public const float OHRANTOWER_FOUNTAIN_3_Z = -6.0f;

  public const string OHRANTOWER_FOUNTAIN_4_C = "Fountain";
  public const string OHRANTOWER_FOUNTAIN_4_O = "4";
  public const float OHRANTOWER_FOUNTAIN_4_X = 15.0f;
  public const float OHRANTOWER_FOUNTAIN_4_Y = 41.0f;
  public const float OHRANTOWER_FOUNTAIN_4_Z = -6.0f;

  public const string OHRANTOWER_FOUNTAIN_5_C = "Fountain";
  public const string OHRANTOWER_FOUNTAIN_5_O = "5";
  public const float OHRANTOWER_FOUNTAIN_5_X = 11.0f;
  public const float OHRANTOWER_FOUNTAIN_5_Y = 57.0f;
  public const float OHRANTOWER_FOUNTAIN_5_Z = -24.0f;
  #endregion

  #region "ObsidianStone"
  public const string OHRANTOWER_ObsidianStone_1_C = "ObsidianStone";
  public const string OHRANTOWER_ObsidianStone_1_O = "1";
  public const float OHRANTOWER_ObsidianStone_1_X = 7.0f;
  public const float OHRANTOWER_ObsidianStone_1_Y = -55.0f;
  public const float OHRANTOWER_ObsidianStone_1_Z = -9.0f;
  #endregion

  #endregion
  #region "ヴェルガスの海底神殿"
  #region "看板"
  // 第一階層、エントランスの間、看板
  public const string VELGUS_MessageBoard_1_C = "MessageBoard";
  public const string VELGUS_MessageBoard_1_O = "1";
  public const float VELGUS_MessageBoard_1_X = 14.0f;
  public const float VELGUS_MessageBoard_1_Y = 1.0f;
  public const float VELGUS_MessageBoard_1_Z = -9.0f;

  // 第一階層、中央の間、看板
  public const string VELGUS_MessageBoard_2_C = "MessageBoard";
  public const string VELGUS_MessageBoard_2_O = "2";
  public const float VELGUS_MessageBoard_2_X = 22.0f;
  public const float VELGUS_MessageBoard_2_Y = 1.0f;
  public const float VELGUS_MessageBoard_2_Z = -9.0f;

  // 第一階層、天の物語の間、看板
  public const string VELGUS_MessageBoard_3_C = "MessageBoard";
  public const string VELGUS_MessageBoard_3_O = "3";
  public const float VELGUS_MessageBoard_3_X = 41.0f;
  public const float VELGUS_MessageBoard_3_Y = 1.0f;
  public const float VELGUS_MessageBoard_3_Z = -5.0f;

  // 第一階層、ナンバータイルの間、看板
  public const string VELGUS_MessageBoard_4_C = "MessageBoard";
  public const string VELGUS_MessageBoard_4_O = "4";
  public const float VELGUS_MessageBoard_4_X = 24.0f;
  public const float VELGUS_MessageBoard_4_Y = 1.0f;
  public const float VELGUS_MessageBoard_4_Z = -17.0f;

  // 第一階層、パズルの間、看板
  public const string VELGUS_MessageBoard_5_C = "MessageBoard";
  public const string VELGUS_MessageBoard_5_O = "5";
  public const float VELGUS_MessageBoard_5_X = 18.0f;
  public const float VELGUS_MessageBoard_5_Y = 1.0f;
  public const float VELGUS_MessageBoard_5_Z = -14.0f;

  // 第一階層、？？？
  public const string VELGUS_MessageBoard_6_C = "MessageBoard";
  public const string VELGUS_MessageBoard_6_O = "6";
  public const float VELGUS_MessageBoard_6_X = 28.0f;
  public const float VELGUS_MessageBoard_6_Y = 1.0f;
  public const float VELGUS_MessageBoard_6_Z = -1.0f;

  // 第二階層、初級の間(1)、看板
  public const string VELGUS_2_MessageBoard_1_C = "MessageBoard";
  public const string VELGUS_2_MessageBoard_1_O = "1";
  public const float VELGUS_2_MessageBoard_1_X = 14.0f;
  public const float VELGUS_2_MessageBoard_1_Y = 1.0f;
  public const float VELGUS_2_MessageBoard_1_Z = -21.0f;

  // 第二階層、疾走の間(2)、看板
  public const string VELGUS_2_MessageBoard_2_C = "MessageBoard";
  public const string VELGUS_2_MessageBoard_2_O = "2";
  public const float VELGUS_2_MessageBoard_2_X = 22.0f;
  public const float VELGUS_2_MessageBoard_2_Y = 1.0f;
  public const float VELGUS_2_MessageBoard_2_Z = -22.0f;

  // 第二階層、疾走の間(3)、看板
  public const string VELGUS_2_MessageBoard_3_C = "MessageBoard";
  public const string VELGUS_2_MessageBoard_3_O = "3";
  public const float VELGUS_2_MessageBoard_3_X = 34.0f;
  public const float VELGUS_2_MessageBoard_3_Y = 1.0f;
  public const float VELGUS_2_MessageBoard_3_Z = -22.0f;

  // 第二階層、疾走の間(4)、看板
  public const string VELGUS_2_MessageBoard_4_C = "MessageBoard";
  public const string VELGUS_2_MessageBoard_4_O = "4";
  public const float VELGUS_2_MessageBoard_4_X = 36.0f;
  public const float VELGUS_2_MessageBoard_4_Y = 1.0f;
  public const float VELGUS_2_MessageBoard_4_Z = -18.0f;

  // 第二階層、海渡りの間(5)、看板
  public const string VELGUS_2_MessageBoard_5_C = "MessageBoard";
  public const string VELGUS_2_MessageBoard_5_O = "5";
  public const float VELGUS_2_MessageBoard_5_X = 14.0f;
  public const float VELGUS_2_MessageBoard_5_Y = 1.0f;
  public const float VELGUS_2_MessageBoard_5_Z = -15.0f;

  // 第二階層、ランダムの間(6)、看板
  public const string VELGUS_2_MessageBoard_6_C = "MessageBoard";
  public const string VELGUS_2_MessageBoard_6_O = "6";
  public const float VELGUS_2_MessageBoard_6_X = 27.0f;
  public const float VELGUS_2_MessageBoard_6_Y = 1.0f;
  public const float VELGUS_2_MessageBoard_6_Z = -10.0f;

  // 第二階層、遠点の間(7)、看板
  public const string VELGUS_2_MessageBoard_7_C = "MessageBoard";
  public const string VELGUS_2_MessageBoard_7_O = "7";
  public const float VELGUS_2_MessageBoard_7_X = 45.0f;
  public const float VELGUS_2_MessageBoard_7_Y = 1.0f;
  public const float VELGUS_2_MessageBoard_7_Z = -2.0f;

  // 第三階層、入口の看板
  public const string VELGUS_3_MessageBoard_1_C = "MessageBoard";
  public const string VELGUS_3_MessageBoard_1_O = "1";
  public const float VELGUS_3_MessageBoard_1_X = 7.0f;
  public const float VELGUS_3_MessageBoard_1_Y = 1.0f;
  public const float VELGUS_3_MessageBoard_1_Z = -24.0f;

  // 第四階層、上の看板
  public const string VELGUS_4_MessageBoard_1_C = "MessageBoard";
  public const string VELGUS_4_MessageBoard_1_O = "1";
  public const float VELGUS_4_MessageBoard_1_X = 26.0f;
  public const float VELGUS_4_MessageBoard_1_Y = 1.0f;
  public const float VELGUS_4_MessageBoard_1_Z = -5.0f;

  // 第四階層、左の看板
  public const string VELGUS_4_MessageBoard_2_C = "MessageBoard";
  public const string VELGUS_4_MessageBoard_2_O = "2";
  public const float VELGUS_4_MessageBoard_2_X = 17.0f;
  public const float VELGUS_4_MessageBoard_2_Y = 1.0f;
  public const float VELGUS_4_MessageBoard_2_Z = -14.0f;

  // 第四階層、右の看板
  public const string VELGUS_4_MessageBoard_3_C = "MessageBoard";
  public const string VELGUS_4_MessageBoard_3_O = "3";
  public const float VELGUS_4_MessageBoard_3_X = 35.0f;
  public const float VELGUS_4_MessageBoard_3_Y = 1.0f;
  public const float VELGUS_4_MessageBoard_3_Z = -14.0f;

  // 第四階層、下の看板
  public const string VELGUS_4_MessageBoard_4_C = "MessageBoard";
  public const string VELGUS_4_MessageBoard_4_O = "4";
  public const float VELGUS_4_MessageBoard_4_X = 26.0f;
  public const float VELGUS_4_MessageBoard_4_Y = 1.0f;
  public const float VELGUS_4_MessageBoard_4_Z = -23.0f;

  #endregion
  #region "第一階層"
  #region "階段(上り)"
  // (1F)
  public const string VELGUS_UPSTAIR_1_C = "Upstair";
  public const string VELGUS_UPSTAIR_1_O = "1";
  public const float VELGUS_UPSTAIR_1_X = 14.0f;
  public const float VELGUS_UPSTAIR_1_Y = 0.0f;
  public const float VELGUS_UPSTAIR_1_Z = -13.0f;
  // (2F)
  public const string VELGUS_UPSTAIR_2_C = "Upstair";
  public const string VELGUS_UPSTAIR_2_O = "2";
  public const float VELGUS_UPSTAIR_2_X = 1.0f;
  public const float VELGUS_UPSTAIR_2_Y = 0.0f;
  public const float VELGUS_UPSTAIR_2_Z = -19.0f;
  #endregion
  // トリガータイル（１－１）
  public const string VELGUS_TRIGGERTILE_1_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_1_O = "1";
  public const float VELGUS_TRIGGERTILE_1_X = 16.0f;
  public const float VELGUS_TRIGGERTILE_1_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_1_Z = -7.0f;

  // トリガータイル（１－２）
  public const string VELGUS_TRIGGERTILE_2_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_2_O = "2";
  public const float VELGUS_TRIGGERTILE_2_X = 16.0f;
  public const float VELGUS_TRIGGERTILE_2_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_2_Z = -11.0f;

  // トリガータイル（１－３）
  public const string VELGUS_TRIGGERTILE_3_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_3_O = "3";
  public const float VELGUS_TRIGGERTILE_3_X = 12.0f;
  public const float VELGUS_TRIGGERTILE_3_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_3_Z = -7.0f;

  // トリガータイル（１－４）
  public const string VELGUS_TRIGGERTILE_4_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_4_O = "4";
  public const float VELGUS_TRIGGERTILE_4_X = 12.0f;
  public const float VELGUS_TRIGGERTILE_4_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_4_Z = -11.0f;

  // シークレット壁（１）
  public const string VELGUS_SECRETWALL_5_C = "SecretWall";
  public const string VELGUS_SECRETWALL_5_O = "5";
  public const float VELGUS_SECRETWALL_5_X = 15.0f;
  public const float VELGUS_SECRETWALL_5_Y = 0.5f;
  public const float VELGUS_SECRETWALL_5_Z = -8.0f;

  // シークレット壁（１）移動後
  public const string VELGUS_SECRETWALL_5_2_C = "SecretWall";
  public const string VELGUS_SECRETWALL_5_2_O = "5";
  public const float VELGUS_SECRETWALL_5_2_X = 15.0f;
  public const float VELGUS_SECRETWALL_5_2_Y = 0.5f;
  public const float VELGUS_SECRETWALL_5_2_Z = -7.0f;

  // エントランス１：壁ドア（１）
  public const string VELGUS_DOOR_6_C = "VelgusDoor";
  public const string VELGUS_DOOR_6_O = "6";
  public const float VELGUS_DOOR_6_X = 14.0f;
  public const float VELGUS_DOOR_6_Y = 1.0f;
  public const float VELGUS_DOOR_6_Z = -5.0f;

  // エントランス１：壁ドア（２）
  public const string VELGUS_DOOR_7_C = "VelgusDoor";
  public const string VELGUS_DOOR_7_O = "7";
  public const float VELGUS_DOOR_7_X = 10.0f;
  public const float VELGUS_DOOR_7_Y = 1.0f;
  public const float VELGUS_DOOR_7_Z = -9.0f;

  // エントランス１：壁ドア（３）
  public const string VELGUS_DOOR_8_C = "VelgusDoor";
  public const string VELGUS_DOOR_8_O = "8";
  public const float VELGUS_DOOR_8_X = 18.0f;
  public const float VELGUS_DOOR_8_Y = 1.0f;
  public const float VELGUS_DOOR_8_Z = -9.0f;

  // 中央の間（周辺１）
  public const string VELGUS_TILEEVENT_9_C = "TileEvent";
  public const string VELGUS_TILEEVENT_9_O = "9";
  public const float VELGUS_TILEEVENT_9_X = 21.0f;
  public const float VELGUS_TILEEVENT_9_Y = 0.0f;
  public const float VELGUS_TILEEVENT_9_Z = -8.0f;

  // 中央の間（周辺２）
  public const string VELGUS_TILEEVENT_10_C = "TileEvent";
  public const string VELGUS_TILEEVENT_10_O = "10";
  public const float VELGUS_TILEEVENT_10_X = 21.0f;
  public const float VELGUS_TILEEVENT_10_Y = 0.0f;
  public const float VELGUS_TILEEVENT_10_Z = -10.0f;

  // 中央の間：右上　／　左上
  public const string VELGUS_TRIGGERTILE_11_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_11_O = "11";
  public const float VELGUS_TRIGGERTILE_11_X = 28.0f;
  public const float VELGUS_TRIGGERTILE_11_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_11_Z = -4.0f;

  // 中央の間：右下　／　右上
  public const string VELGUS_TRIGGERTILE_12_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_12_O = "12";
  public const float VELGUS_TRIGGERTILE_12_X = 30.0f;
  public const float VELGUS_TRIGGERTILE_12_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_12_Z = -12.0f;

  // 中央の間：左上　／　左下
  public const string VELGUS_TRIGGERTILE_13_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_13_O = "13";
  public const float VELGUS_TRIGGERTILE_13_X = 20.0f;
  public const float VELGUS_TRIGGERTILE_13_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_13_Z = -6.0f;

  // 中央の間：左下　／　右下
  public const string VELGUS_TRIGGERTILE_14_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_14_O = "14";
  public const float VELGUS_TRIGGERTILE_14_X = 22.0f;
  public const float VELGUS_TRIGGERTILE_14_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_14_Z = -14.0f;

  // 中央の間：壁ドア（１:CENTER）
  public const string VELGUS_DOOR_15_C = "VelgusDoor";
  public const string VELGUS_DOOR_15_O = "15";
  public const float VELGUS_DOOR_15_X = 25.0f;
  public const float VELGUS_DOOR_15_Y = 1.0f;
  public const float VELGUS_DOOR_15_Z = -11.0f;

  // 中央の間：外れの間への壁
  public const string VELGUS_SECRETWALL_16_C = "SecretWall";
  public const string VELGUS_SECRETWALL_16_O = "16";
  public const float VELGUS_SECRETWALL_16_X = 20.0f;
  public const float VELGUS_SECRETWALL_16_Y = 0.5f;
  public const float VELGUS_SECRETWALL_16_Z = -4.0f;

  // 中央の間：外れの間（上）
  public const string VELGUS_TRIGGERTILE_17_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_17_O = "17";
  public const float VELGUS_TRIGGERTILE_17_X = 25.0f;
  public const float VELGUS_TRIGGERTILE_17_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_17_Z = -2.0f;

  // 中央の間：右上、通路封鎖を開放
  public const string VELGUS_FAKESEA_18_C = "FakeSea";
  public const string VELGUS_FAKESEA_18_O = "18";
  public const float VELGUS_FAKESEA_18_X = 31.0f;
  public const float VELGUS_FAKESEA_18_Y = 0.0f;
  public const float VELGUS_FAKESEA_18_Z = -4.0f;

  public const string VELGUS_FAKESEA_19_C = "FakeSea";
  public const string VELGUS_FAKESEA_19_O = "19";
  public const float VELGUS_FAKESEA_19_X = 31.0f;
  public const float VELGUS_FAKESEA_19_Y = 0.0f;
  public const float VELGUS_FAKESEA_19_Z = -5.0f;

  // 中央の間：右下、通路封鎖を開放
  public const string VELGUS_FAKESEA_20_C = "FakeSea";
  public const string VELGUS_FAKESEA_20_O = "20";
  public const float VELGUS_FAKESEA_20_X = 29.0f;
  public const float VELGUS_FAKESEA_20_Y = 0.0f;
  public const float VELGUS_FAKESEA_20_Z = -15.0f;

  public const string VELGUS_FAKESEA_21_C = "FakeSea";
  public const string VELGUS_FAKESEA_21_O = "21";
  public const float VELGUS_FAKESEA_21_X = 29.0f;
  public const float VELGUS_FAKESEA_21_Y = 0.0f;
  public const float VELGUS_FAKESEA_21_Z = -16.0f;

  // 中央の間：左下、通路封鎖を開放
  public const string VELGUS_FAKESEA_22_C = "FakeSea";
  public const string VELGUS_FAKESEA_22_O = "22";
  public const float VELGUS_FAKESEA_22_X = 19.0f;
  public const float VELGUS_FAKESEA_22_Y = 0.0f;
  public const float VELGUS_FAKESEA_22_Z = -13.0f;

  public const string VELGUS_FAKESEA_23_C = "FakeSea";
  public const string VELGUS_FAKESEA_23_O = "23";
  public const float VELGUS_FAKESEA_23_X = 19.0f;
  public const float VELGUS_FAKESEA_23_Y = 0.0f;
  public const float VELGUS_FAKESEA_23_Z = -14.0f;

  // 右方、天の物語「詩」の間、スイッチ１
  public const string VELGUS_TRIGGERTILE_24_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_24_O = "24";
  public const float VELGUS_TRIGGERTILE_24_X = 42.0f;
  public const float VELGUS_TRIGGERTILE_24_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_24_Z = -11.0f;

  // エントランス：隠し壁ドア
  public const string VELGUS_SECRETWALL_25_C = "SecretWall";
  public const string VELGUS_SECRETWALL_25_O = "25";
  public const float VELGUS_SECRETWALL_25_X = 12.0f;
  public const float VELGUS_SECRETWALL_25_Y = 0.5f;
  public const float VELGUS_SECRETWALL_25_Z = -2.0f;

  // 右方、天の物語「詩」の間、壁ドア左
  public const string VELGUS_DOOR_26_C = "VelgusDoor";
  public const string VELGUS_DOOR_26_O = "26";
  public const float VELGUS_DOOR_26_X = 41.0f;
  public const float VELGUS_DOOR_26_Y = 1.0f;
  public const float VELGUS_DOOR_26_Z = -11.0f;

  // 右方、天の物語「詩」の間、壁ドア下
  public const string VELGUS_DOOR_27_C = "VelgusDoor";
  public const string VELGUS_DOOR_27_O = "27";
  public const float VELGUS_DOOR_27_X = 42.0f;
  public const float VELGUS_DOOR_27_Y = 1.0f;
  public const float VELGUS_DOOR_27_Z = -12.0f;

  // 右方、天の物語「詩」の間、壁ドア右
  public const string VELGUS_DOOR_28_C = "VelgusDoor";
  public const string VELGUS_DOOR_28_O = "28";
  public const float VELGUS_DOOR_28_X = 43.0f;
  public const float VELGUS_DOOR_28_Y = 1.0f;
  public const float VELGUS_DOOR_28_Z = -11.0f;

  // エントランス、外れの間、隠し壁ドア
  public const string VELGUS_SECRETWALL_29_C = "VelgusDoor";
  public const string VELGUS_SECRETWALL_29_O = "29";
  public const float VELGUS_SECRETWALL_29_X = 12.0f;
  public const float VELGUS_SECRETWALL_29_Y = 0.5f;
  public const float VELGUS_SECRETWALL_29_Z = -2.0f;

  // エントランス、外れの間、天の物語「詩』１
  public const string VELGUS_TRIGGERTILE_30_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_30_O = "30";
  public const float VELGUS_TRIGGERTILE_30_X = 11.0f;
  public const float VELGUS_TRIGGERTILE_30_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_30_Z = -2.0f;

  // 右方、天の物語「詩』２
  public const string VELGUS_TRIGGERTILE_31_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_31_O = "31";
  public const float VELGUS_TRIGGERTILE_31_X = 38.0f;
  public const float VELGUS_TRIGGERTILE_31_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_31_Z = -7.0f;

  // 右方、天の物語「詩』３
  public const string VELGUS_TRIGGERTILE_32_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_32_O = "32";
  public const float VELGUS_TRIGGERTILE_32_X = 40.0f;
  public const float VELGUS_TRIGGERTILE_32_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_32_Z = -7.0f;

  // 右方、天の物語「詩』４
  public const string VELGUS_TRIGGERTILE_33_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_33_O = "33";
  public const float VELGUS_TRIGGERTILE_33_X = 38.0f;
  public const float VELGUS_TRIGGERTILE_33_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_33_Z = -13.0f;

  // 右方、天の物語「詩』５
  public const string VELGUS_TRIGGERTILE_34_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_34_O = "34";
  public const float VELGUS_TRIGGERTILE_34_X = 38.0f;
  public const float VELGUS_TRIGGERTILE_34_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_34_Z = -15.0f;

  // 右方、天の物語「詩』６
  public const string VELGUS_TRIGGERTILE_35_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_35_O = "35";
  public const float VELGUS_TRIGGERTILE_35_X = 44.0f;
  public const float VELGUS_TRIGGERTILE_35_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_35_Z = -7.0f;

  // 右方、天の物語「詩』７
  public const string VELGUS_TRIGGERTILE_36_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_36_O = "36";
  public const float VELGUS_TRIGGERTILE_36_X = 46.0f;
  public const float VELGUS_TRIGGERTILE_36_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_36_Z = -7.0f;

  // 右方、天の物語「詩』８
  public const string VELGUS_TRIGGERTILE_37_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_37_O = "37";
  public const float VELGUS_TRIGGERTILE_37_X = 36.0f;
  public const float VELGUS_TRIGGERTILE_37_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_37_Z = -7.0f;

  // 右方、天の物語「詩』９
  public const string VELGUS_TRIGGERTILE_38_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_38_O = "38";
  public const float VELGUS_TRIGGERTILE_38_X = 36.0f;
  public const float VELGUS_TRIGGERTILE_38_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_38_Z = -9.0f;

  // 右方、天の物語「詩』１０
  public const string VELGUS_TRIGGERTILE_39_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_39_O = "39";
  public const float VELGUS_TRIGGERTILE_39_X = 44.0f;
  public const float VELGUS_TRIGGERTILE_39_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_39_Z = -3.0f;

  // 右方、天の物語「詩』１１
  public const string VELGUS_TRIGGERTILE_40_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_40_O = "40";
  public const float VELGUS_TRIGGERTILE_40_X = 44.0f;
  public const float VELGUS_TRIGGERTILE_40_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_40_Z = -5.0f;

  // 右方、天の物語「詩』１２
  public const string VELGUS_TRIGGERTILE_41_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_41_O = "41";
  public const float VELGUS_TRIGGERTILE_41_X = 44.0f;
  public const float VELGUS_TRIGGERTILE_41_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_41_Z = -13.0f;

  // 右方、天の物語「詩』１３
  public const string VELGUS_TRIGGERTILE_42_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_42_O = "42";
  public const float VELGUS_TRIGGERTILE_42_X = 44.0f;
  public const float VELGUS_TRIGGERTILE_42_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_42_Z = -15.0f;

  // 右方、天の物語「詩』１４
  public const string VELGUS_TRIGGERTILE_43_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_43_O = "43";
  public const float VELGUS_TRIGGERTILE_43_X = 34.0f;
  public const float VELGUS_TRIGGERTILE_43_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_43_Z = -13.0f;

  // 右方、天の物語「詩』１５
  public const string VELGUS_TRIGGERTILE_44_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_44_O = "44";
  public const float VELGUS_TRIGGERTILE_44_X = 36.0f;
  public const float VELGUS_TRIGGERTILE_44_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_44_Z = -13.0f;

  // 右方、天の物語「詩』１６
  public const string VELGUS_TRIGGERTILE_45_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_45_O = "45";
  public const float VELGUS_TRIGGERTILE_45_X = 48.0f;
  public const float VELGUS_TRIGGERTILE_45_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_45_Z = -2.0f;

  // トリガータイル（E3B-1）
  public const string VELGUS_TRIGGERTILE_46_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_46_O = "46";
  public const float VELGUS_TRIGGERTILE_46_X = 32.0f;
  public const float VELGUS_TRIGGERTILE_46_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_46_Z = -8.0f;

  // トリガータイル（E3B-2）
  public const string VELGUS_TRIGGERTILE_47_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_47_O = "47";
  public const float VELGUS_TRIGGERTILE_47_X = 48.0f;
  public const float VELGUS_TRIGGERTILE_47_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_47_Z = -4.0f;

  // トリガータイル（E3B-3）
  public const string VELGUS_TRIGGERTILE_48_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_48_O = "48";
  public const float VELGUS_TRIGGERTILE_48_X = 48.0f;
  public const float VELGUS_TRIGGERTILE_48_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_48_Z = -14.0f;

  // 右方、隠し壁ドア（E3B-1）
  public const string VELGUS_SECRETWALL_49_C = "SecretWall";
  public const string VELGUS_SECRETWALL_49_O = "49";
  public const float VELGUS_SECRETWALL_49_X = 39.0f;
  public const float VELGUS_SECRETWALL_49_Y = 0.5f;
  public const float VELGUS_SECRETWALL_49_Z = -10.0f;

  // 右方、隠し壁ドア（E3B-2）
  public const string VELGUS_SECRETWALL_50_C = "SecretWall";
  public const string VELGUS_SECRETWALL_50_O = "50";
  public const float VELGUS_SECRETWALL_50_X = 41.0f;
  public const float VELGUS_SECRETWALL_50_Y = 0.5f;
  public const float VELGUS_SECRETWALL_50_Z = -14.0f;

  // 右方、隠し壁ドア（E3B-3）
  public const string VELGUS_SECRETWALL_51_C = "SecretWall";
  public const string VELGUS_SECRETWALL_51_O = "51";
  public const float VELGUS_SECRETWALL_51_X = 45.0f;
  public const float VELGUS_SECRETWALL_51_Y = 0.5f;
  public const float VELGUS_SECRETWALL_51_Z = -10.0f;

  // 右方、隠し壁ドア（E3C-1）
  public const string VELGUS_SECRETWALL_52_C = "SecretWall";
  public const string VELGUS_SECRETWALL_52_O = "52";
  public const float VELGUS_SECRETWALL_52_X = 33.0f;
  public const float VELGUS_SECRETWALL_52_Y = 0.5f;
  public const float VELGUS_SECRETWALL_52_Z = -8.0f;

  // 右方、隠し壁ドア（E3C-2）
  public const string VELGUS_SECRETWALL_53_C = "SecretWall";
  public const string VELGUS_SECRETWALL_53_O = "53";
  public const float VELGUS_SECRETWALL_53_X = 47.0f;
  public const float VELGUS_SECRETWALL_53_Y = 0.5f;
  public const float VELGUS_SECRETWALL_53_Z = -4.0f;

  // 右方、隠し壁ドア（E3C-3）
  public const string VELGUS_SECRETWALL_54_C = "SecretWall";
  public const string VELGUS_SECRETWALL_54_O = "54";
  public const float VELGUS_SECRETWALL_54_X = 47.0f;
  public const float VELGUS_SECRETWALL_54_Y = 0.5f;
  public const float VELGUS_SECRETWALL_54_Z = -14.0f;

  // 右方、隠し壁ドア（E3D）
  public const string VELGUS_SECRETWALL_55_C = "SecretWall";
  public const string VELGUS_SECRETWALL_55_O = "55";
  public const float VELGUS_SECRETWALL_55_X = 32.0f;
  public const float VELGUS_SECRETWALL_55_Y = 0.5f;
  public const float VELGUS_SECRETWALL_55_Z = -12.0f;

  // 右方、隠し壁ドア（E3E）
  public const string VELGUS_SECRETWALL_56_C = "SecretWall";
  public const string VELGUS_SECRETWALL_56_O = "56";
  public const float VELGUS_SECRETWALL_56_X = 42.0f;
  public const float VELGUS_SECRETWALL_56_Y = 0.5f;
  public const float VELGUS_SECRETWALL_56_Z = -2.0f;

  // トリガータイル（E3B-F）
  public const string VELGUS_TRIGGERTILE_57_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_57_O = "57";
  public const float VELGUS_TRIGGERTILE_57_X = 34.0f;
  public const float VELGUS_TRIGGERTILE_57_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_57_Z = -1.0f;

  // 右方、隠し壁ドア（E3F）
  public const string VELGUS_SECRETWALL_58_C = "SecretWall";
  public const string VELGUS_SECRETWALL_58_O = "58";
  public const float VELGUS_SECRETWALL_58_X = 41.0f;
  public const float VELGUS_SECRETWALL_58_Y = 0.5f;
  public const float VELGUS_SECRETWALL_58_Z = -17.0f;

  // トリガータイル（E3G）
  public const string VELGUS_TRIGGERTILE_59_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_59_O = "59";
  public const float VELGUS_TRIGGERTILE_59_X = 37.0f;
  public const float VELGUS_TRIGGERTILE_59_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_59_Z = -17.0f;

  // 右方、隠し壁ドア（E3G)
  public const string VELGUS_SECRETWALL_60_C = "SecretWall";
  public const string VELGUS_SECRETWALL_60_O = "60";
  public const float VELGUS_SECRETWALL_60_X = 40.0f;
  public const float VELGUS_SECRETWALL_60_Y = 0.5f;
  public const float VELGUS_SECRETWALL_60_Z = -5.0f;

  // トリガータイル（E3G -> H）
  public const string VELGUS_TRIGGERTILE_61_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_61_O = "61";
  public const float VELGUS_TRIGGERTILE_61_X = 41.0f;
  public const float VELGUS_TRIGGERTILE_61_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_61_Z = -5.0f;

  // 詠唱の地（E3H)
  public const string VELGUS_CHANTFIELD_62_C = "ChantField";
  public const string VELGUS_CHANTFIELD_62_O = "62";
  public const float VELGUS_CHANTFIELD_62_X = 33.0f;
  public const float VELGUS_CHANTFIELD_62_Y = 0.0f;
  public const float VELGUS_CHANTFIELD_62_Z = -5.0f;

  // 右方、隠し壁ドア（E3H）
  public const string VELGUS_SECRETWALL_63_C = "SecretWall";
  public const string VELGUS_SECRETWALL_63_O = "63";
  public const float VELGUS_SECRETWALL_63_X = 43.0f;
  public const float VELGUS_SECRETWALL_63_Y = 0.5f;
  public const float VELGUS_SECRETWALL_63_Z = -1.0f;

  // 右方、隠し壁ドア（E3I）
  public const string VELGUS_SECRETWALL_64_C = "SecretWall";
  public const string VELGUS_SECRETWALL_64_O = "64";
  public const float VELGUS_SECRETWALL_64_X = 33.0f;
  public const float VELGUS_SECRETWALL_64_Y = 0.5f;
  public const float VELGUS_SECRETWALL_64_Z = -1.0f;

  // トリガータイル（E3-???）
  public const string VELGUS_TRIGGERTILE_65_C = "TriggerTile";
  public const string VELGUS_TRIGGERTILE_65_O = "65";
  public const float VELGUS_TRIGGERTILE_65_X = 28.0f;
  public const float VELGUS_TRIGGERTILE_65_Y = 0.0f;
  public const float VELGUS_TRIGGERTILE_65_Z = -1.0f;

  // イベント（E41）エリア可視化
  public const string VELGUS_EVENTTILE_66_C = "EventTile";
  public const string VELGUS_EVENTTILE_66_O = "66";
  public const float VELGUS_EVENTTILE_66_X = 25.0f;
  public const float VELGUS_EVENTTILE_66_Y = 0.0f;
  public const float VELGUS_EVENTTILE_66_Z = -19.0f;

  // 順路の間、ナンバータイル１－１
  public const string VELGUS_NUMBERTILE_1_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_67_O = "67";
  public const float VELGUS_NUMBERTILE_67_X = 23.0f;
  public const float VELGUS_NUMBERTILE_67_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_67_Z = -19.0f;

  // 順路の間、ナンバータイル１－１(1)
  public const string VELGUS_NUMBERTILE_1_1_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_68_O = "68";
  public const float VELGUS_NUMBERTILE_68_X = 23.0f;
  public const float VELGUS_NUMBERTILE_68_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_68_Z = -21.0f;

  // 順路の間、ナンバータイル１－１(2)
  public const string VELGUS_NUMBERTILE_1_1_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_69_O = "69";
  public const float VELGUS_NUMBERTILE_69_X = 23.0f;
  public const float VELGUS_NUMBERTILE_69_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_69_Z = -23.0f;

  // 順路の間、ナンバータイル１－１(3)
  public const string VELGUS_NUMBERTILE_1_1_3 = "NumberTile";
  public const string VELGUS_NUMBERTILE_70_O = "70";
  public const float VELGUS_NUMBERTILE_70_X = 23.0f;
  public const float VELGUS_NUMBERTILE_70_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_70_Z = -25.0f;

  // 順路の間、ナンバータイル１－２
  public const string VELGUS_NUMBERTILE_1_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_71_O = "71";
  public const float VELGUS_NUMBERTILE_71_X = 25.0f;
  public const float VELGUS_NUMBERTILE_71_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_71_Z = -25.0f;

  // 順路の間、ナンバータイル１－２(1)
  public const string VELGUS_NUMBERTILE_1_2_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_72_O = "72";
  public const float VELGUS_NUMBERTILE_72_X = 25.0f;
  public const float VELGUS_NUMBERTILE_72_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_72_Z = -23.0f;

  // 順路の間、ナンバータイル１－３
  public const string VELGUS_NUMBERTILE_1_3 = "NumberTile";
  public const string VELGUS_NUMBERTILE_73_O = "73";
  public const float VELGUS_NUMBERTILE_73_X = 25.0f;
  public const float VELGUS_NUMBERTILE_73_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_73_Z = -21.0f;

  // 順路の間、ナンバータイル１－３(1)
  public const string VELGUS_NUMBERTILE_1_3_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_74_O = "74";
  public const float VELGUS_NUMBERTILE_74_X = 27.0f;
  public const float VELGUS_NUMBERTILE_74_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_74_Z = -21.0f;

  // 順路の間、ナンバータイル１－３(2)
  public const string VELGUS_NUMBERTILE_1_3_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_75_O = "75";
  public const float VELGUS_NUMBERTILE_75_X = 27.0f;
  public const float VELGUS_NUMBERTILE_75_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_75_Z = -19.0f;

  // 順路の間、ナンバータイル１－３(3)
  public const string VELGUS_NUMBERTILE_1_3_3 = "NumberTile";
  public const string VELGUS_NUMBERTILE_76_O = "76";
  public const float VELGUS_NUMBERTILE_76_X = 29.0f;
  public const float VELGUS_NUMBERTILE_76_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_76_Z = -19.0f;

  // 順路の間、ナンバータイル１－４
  public const string VELGUS_NUMBERTILE_1_4 = "NumberTile";
  public const string VELGUS_NUMBERTILE_77_O = "77";
  public const float VELGUS_NUMBERTILE_77_X = 31.0f;
  public const float VELGUS_NUMBERTILE_77_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_77_Z = -19.0f;

  // 順路の間、ナンバータイル１－４(1)
  public const string VELGUS_NUMBERTILE_1_4_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_78_O = "78";
  public const float VELGUS_NUMBERTILE_78_X = 31.0f;
  public const float VELGUS_NUMBERTILE_78_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_78_Z = -21.0f;

  // 順路の間、ナンバータイル１－５
  public const string VELGUS_NUMBERTILE_1_5 = "NumberTile";
  public const string VELGUS_NUMBERTILE_79_O = "79";
  public const float VELGUS_NUMBERTILE_79_X = 29.0f;
  public const float VELGUS_NUMBERTILE_79_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_79_Z = -21.0f;

  // 順路の間、ナンバータイル１－５(1)
  public const string VELGUS_NUMBERTILE_1_5_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_80_O = "80";
  public const float VELGUS_NUMBERTILE_80_X = 29.0f;
  public const float VELGUS_NUMBERTILE_80_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_80_Z = -23.0f;

  // 順路の間、ナンバータイル１－５(2)
  public const string VELGUS_NUMBERTILE_1_5_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_81_O = "81";
  public const float VELGUS_NUMBERTILE_81_X = 27.0f;
  public const float VELGUS_NUMBERTILE_81_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_81_Z = -23.0f;

  // 順路の間、ナンバータイル１－６
  public const string VELGUS_NUMBERTILE_1_6 = "NumberTile";
  public const string VELGUS_NUMBERTILE_82_O = "82";
  public const float VELGUS_NUMBERTILE_82_X = 27.0f;
  public const float VELGUS_NUMBERTILE_82_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_82_Z = -25.0f;

  // 順路の間、ナンバータイル１－６(1)
  public const string VELGUS_NUMBERTILE_1_6_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_83_O = "83";
  public const float VELGUS_NUMBERTILE_83_X = 29.0f;
  public const float VELGUS_NUMBERTILE_83_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_83_Z = -25.0f;

  // 順路の間、ナンバータイル１－６(2)
  public const string VELGUS_NUMBERTILE_1_6_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_84_O = "84";
  public const float VELGUS_NUMBERTILE_84_X = 31.0f;
  public const float VELGUS_NUMBERTILE_84_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_84_Z = -25.0f;

  // 順路の間、ナンバータイル１－７
  public const string VELGUS_NUMBERTILE_1_7 = "NumberTile";
  public const string VELGUS_NUMBERTILE_85_O = "85";
  public const float VELGUS_NUMBERTILE_85_X = 31.0f;
  public const float VELGUS_NUMBERTILE_85_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_85_Z = -23.0f;

  // 順路の間、壁ドア１
  public const string VELGUS_DOOR_86 = "VelgusDoor";
  public const string VELGUS_DOOR_86_O = "86";
  public const float VELGUS_DOOR_86_X = 32.0f;
  public const float VELGUS_DOOR_86_Y = 1.0f;
  public const float VELGUS_DOOR_86_Z = -23.0f;

  // イベント（E42）エリア可視化
  public const string VELGUS_EVENTTILE_87_C = "EventTile";
  public const string VELGUS_EVENTTILE_87_O = "87";
  public const float VELGUS_EVENTTILE_87_X = 35.0f;
  public const float VELGUS_EVENTTILE_87_Y = 0.0f;
  public const float VELGUS_EVENTTILE_87_Z = -19.0f;

  // 順路の間、ナンバータイル２ー０(1)
  public const string VELGUS_NUMBERTILE_2_0_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_88_O = "88";
  public const float VELGUS_NUMBERTILE_88_X = 37.0f;
  public const float VELGUS_NUMBERTILE_88_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_88_Z = -19.0f;

  // 順路の間、ナンバータイル２ー０(2)
  public const string VELGUS_NUMBERTILE_2_0_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_89_O = "89";
  public const float VELGUS_NUMBERTILE_89_X = 39.0f;
  public const float VELGUS_NUMBERTILE_89_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_89_Z = -19.0f;

  // 順路の間、ナンバータイル２ー０(3)
  public const string VELGUS_NUMBERTILE_2_0_3 = "NumberTile";
  public const string VELGUS_NUMBERTILE_90_O = "90";
  public const float VELGUS_NUMBERTILE_90_X = 41.0f;
  public const float VELGUS_NUMBERTILE_90_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_90_Z = -19.0f;

  // 順路の間、ナンバータイル２ー０(4)
  public const string VELGUS_NUMBERTILE_2_0_4 = "NumberTile";
  public const string VELGUS_NUMBERTILE_91_O = "91";
  public const float VELGUS_NUMBERTILE_91_X = 43.0f;
  public const float VELGUS_NUMBERTILE_91_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_91_Z = -19.0f;

  // 順路の間、ナンバータイル２ー０(5)
  public const string VELGUS_NUMBERTILE_2_0_5 = "NumberTile";
  public const string VELGUS_NUMBERTILE_92_O = "92";
  public const float VELGUS_NUMBERTILE_92_X = 45.0f;
  public const float VELGUS_NUMBERTILE_92_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_92_Z = -19.0f;

  // 順路の間、ナンバータイル２ー０(6)
  public const string VELGUS_NUMBERTILE_2_0_6 = "NumberTile";
  public const string VELGUS_NUMBERTILE_93_O = "93";
  public const float VELGUS_NUMBERTILE_93_X = 45.0f;
  public const float VELGUS_NUMBERTILE_93_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_93_Z = -21.0f;

  // 順路の間、ナンバータイル２ー１
  public const string VELGUS_NUMBERTILE_2_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_94_O = "94";
  public const float VELGUS_NUMBERTILE_94_X = 45.0f;
  public const float VELGUS_NUMBERTILE_94_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_94_Z = -23.0f;

  // 順路の間、ナンバータイル２ー１(0)
  public const string VELGUS_NUMBERTILE_2_1_0 = "NumberTile";
  public const string VELGUS_NUMBERTILE_95_O = "95";
  public const float VELGUS_NUMBERTILE_95_X = 43.0f;
  public const float VELGUS_NUMBERTILE_95_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_95_Z = -23.0f;

  // 順路の間、ナンバータイル２ー１(1)
  public const string VELGUS_NUMBERTILE_2_1_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_96_O = "96";
  public const float VELGUS_NUMBERTILE_96_X = 43.0f;
  public const float VELGUS_NUMBERTILE_96_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_96_Z = -21.0f;

  // 順路の間、ナンバータイル２ー１(2)
  public const string VELGUS_NUMBERTILE_2_1_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_97_O = "97";
  public const float VELGUS_NUMBERTILE_97_X = 41.0f;
  public const float VELGUS_NUMBERTILE_97_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_97_Z = -21.0f;

  // 順路の間、ナンバータイル２ー１(3)
  public const string VELGUS_NUMBERTILE_2_1_3 = "NumberTile";
  public const string VELGUS_NUMBERTILE_98_O = "98";
  public const float VELGUS_NUMBERTILE_98_X = 39.0f;
  public const float VELGUS_NUMBERTILE_98_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_98_Z = -21.0f;

  // 順路の間、ナンバータイル２ー１(4)
  public const string VELGUS_NUMBERTILE_2_1_4 = "NumberTile";
  public const string VELGUS_NUMBERTILE_99_O = "99";
  public const float VELGUS_NUMBERTILE_99_X = 37.0f;
  public const float VELGUS_NUMBERTILE_99_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_99_Z = -21.0f;

  // 順路の間、ナンバータイル２ー１(5)
  public const string VELGUS_NUMBERTILE_2_1_5 = "NumberTile";
  public const string VELGUS_NUMBERTILE_100_O = "100";
  public const float VELGUS_NUMBERTILE_100_X = 35.0f;
  public const float VELGUS_NUMBERTILE_100_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_100_Z = -21.0f;

  // 順路の間、ナンバータイル２ー１(6)
  public const string VELGUS_NUMBERTILE_2_1_6 = "NumberTile";
  public const string VELGUS_NUMBERTILE_101_O = "101";
  public const float VELGUS_NUMBERTILE_101_X = 35.0f;
  public const float VELGUS_NUMBERTILE_101_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_101_Z = -23.0f;

  // 順路の間、ナンバータイル２ー１(7)
  public const string VELGUS_NUMBERTILE_2_1_7 = "NumberTile";
  public const string VELGUS_NUMBERTILE_102_O = "102";
  public const float VELGUS_NUMBERTILE_102_X = 35.0f;
  public const float VELGUS_NUMBERTILE_102_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_102_Z = -25.0f;

  // 順路の間、ナンバータイル２ー１(8)
  public const string VELGUS_NUMBERTILE_2_1_8 = "NumberTile";
  public const string VELGUS_NUMBERTILE_103_O = "103";
  public const float VELGUS_NUMBERTILE_103_X = 35.0f;
  public const float VELGUS_NUMBERTILE_103_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_103_Z = -27.0f;

  // 順路の間、ナンバータイル２ー１(9)
  public const string VELGUS_NUMBERTILE_2_1_9 = "NumberTile";
  public const string VELGUS_NUMBERTILE_104_O = "104";
  public const float VELGUS_NUMBERTILE_104_X = 37.0f;
  public const float VELGUS_NUMBERTILE_104_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_104_Z = -27.0f;

  // 順路の間、ナンバータイル２ー２
  public const string VELGUS_NUMBERTILE_2_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_105_O = "105";
  public const float VELGUS_NUMBERTILE_105_X = 39.0f;
  public const float VELGUS_NUMBERTILE_105_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_105_Z = -27.0f;

  // 順路の間、ナンバータイル２ー２(1)
  public const string VELGUS_NUMBERTILE_2_2_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_106_O = "106";
  public const float VELGUS_NUMBERTILE_106_X = 39.0f;
  public const float VELGUS_NUMBERTILE_106_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_106_Z = -25.0f;

  // 順路の間、ナンバータイル２ー２(1)
  public const string VELGUS_NUMBERTILE_2_2_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_107_O = "107";
  public const float VELGUS_NUMBERTILE_107_X = 37.0f;
  public const float VELGUS_NUMBERTILE_107_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_107_Z = -25.0f;

  // 順路の間、ナンバータイル２ー３
  public const string VELGUS_NUMBERTILE_2_3 = "NumberTile";
  public const string VELGUS_NUMBERTILE_108_O = "108";
  public const float VELGUS_NUMBERTILE_108_X = 37.0f;
  public const float VELGUS_NUMBERTILE_108_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_108_Z = -23.0f;

  // 順路の間、ナンバータイル２ー３(1)
  public const string VELGUS_NUMBERTILE_2_3_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_109_O = "109";
  public const float VELGUS_NUMBERTILE_109_X = 39.0f;
  public const float VELGUS_NUMBERTILE_109_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_109_Z = -23.0f;

  // 順路の間、ナンバータイル２ー３(2)
  public const string VELGUS_NUMBERTILE_2_3_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_110_O = "110";
  public const float VELGUS_NUMBERTILE_110_X = 41.0f;
  public const float VELGUS_NUMBERTILE_110_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_110_Z = -23.0f;

  // 順路の間、壁ドア２
  public const string VELGUS_DOOR_111 = "VelgusDoor";
  public const string VELGUS_DOOR_111_O = "111";
  public const float VELGUS_DOOR_111_X = 41.0f;
  public const float VELGUS_DOOR_111_Y = 1.0f;
  public const float VELGUS_DOOR_111_Z = -24.0f;

  // イベント（E43）エリア可視化
  public const string VELGUS_EVENTTILE_112_C = "EventTile";
  public const string VELGUS_EVENTTILE_112_O = "112";
  public const float VELGUS_EVENTTILE_112_X = 41.0f;
  public const float VELGUS_EVENTTILE_112_Y = 0.0f;
  public const float VELGUS_EVENTTILE_112_Z = -25.0f;

  // 順路の間、ナンバータイル３ー０(1)
  public const string VELGUS_NUMBERTILE_3_0_1 = "NumberTile";
  public const string VELGUS_NUMBERTILE_113_O = "113";
  public const float VELGUS_NUMBERTILE_113_X = 41.0f;
  public const float VELGUS_NUMBERTILE_113_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_113_Z = -27.0f;

  // 順路の間、ナンバータイル３ー０(2)
  public const string VELGUS_NUMBERTILE_3_0_2 = "NumberTile";
  public const string VELGUS_NUMBERTILE_114_O = "114";
  public const float VELGUS_NUMBERTILE_114_X = 43.0f;
  public const float VELGUS_NUMBERTILE_114_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_114_Z = -27.0f;

  // 順路の間、ナンバータイル３ー０(3)
  public const string VELGUS_NUMBERTILE_3_0_3 = "NumberTile";
  public const string VELGUS_NUMBERTILE_115_O = "115";
  public const float VELGUS_NUMBERTILE_115_X = 43.0f;
  public const float VELGUS_NUMBERTILE_115_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_115_Z = -25.0f;

  // 順路の間、ナンバータイル３ー０(4)
  public const string VELGUS_NUMBERTILE_3_0_4 = "NumberTile";
  public const string VELGUS_NUMBERTILE_116_O = "116";
  public const float VELGUS_NUMBERTILE_116_X = 45.0f;
  public const float VELGUS_NUMBERTILE_116_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_116_Z = -25.0f;

  // 順路の間、ナンバータイル３ー０(5)
  public const string VELGUS_NUMBERTILE_3_0_5 = "NumberTile";
  public const string VELGUS_NUMBERTILE_117_O = "117";
  public const float VELGUS_NUMBERTILE_117_X = 45.0f;
  public const float VELGUS_NUMBERTILE_117_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_117_Z = -27.0f;

  // 順路の間、ナンバータイル３ー０(6)
  public const string VELGUS_NUMBERTILE_3_0_6 = "NumberTile";
  public const string VELGUS_NUMBERTILE_118_O = "118";
  public const float VELGUS_NUMBERTILE_118_X = 47.0f;
  public const float VELGUS_NUMBERTILE_118_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_118_Z = -27.0f;

  // 順路の間、ナンバータイル３ー０(7)
  public const string VELGUS_NUMBERTILE_3_0_7 = "NumberTile";
  public const string VELGUS_NUMBERTILE_119_O = "119";
  public const float VELGUS_NUMBERTILE_119_X = 47.0f;
  public const float VELGUS_NUMBERTILE_119_Y = 0.0f;
  public const float VELGUS_NUMBERTILE_119_Z = -25.0f;

  // 順路の間、隠し壁ドア３
  public const string VELGUS_SECRETWALL_120_C = "SecretWall";
  public const string VELGUS_SECRETWALL_120_O = "120";
  public const float VELGUS_SECRETWALL_120_X = 47.0f;
  public const float VELGUS_SECRETWALL_120_Y = 0.5f;
  public const float VELGUS_SECRETWALL_120_Z = -24.0f;

  // パズルの間、E5(0)
  public const string VELGUS_EVENTTILE_121_C = "EventTile";
  public const string VELGUS_EVENTTILE_121_O = "121";
  public const float VELGUS_EVENTTILE_121_X = 17.0f;
  public const float VELGUS_EVENTTILE_121_Y = 0.0f;
  public const float VELGUS_EVENTTILE_121_Z = -17.0f;

  // パズルの間、E5(A)
  public const string VELGUS_EVENTTILE_122_C = "EventTile";
  public const string VELGUS_EVENTTILE_122_O = "122";
  public const float VELGUS_EVENTTILE_122_X = 15.0f;
  public const float VELGUS_EVENTTILE_122_Y = 0.0f;
  public const float VELGUS_EVENTTILE_122_Z = -17.0f;

  // パズルの間、E5(B)
  public const string VELGUS_EVENTTILE_123_C = "EventTile";
  public const string VELGUS_EVENTTILE_123_O = "123";
  public const float VELGUS_EVENTTILE_123_X = 16.0f;
  public const float VELGUS_EVENTTILE_123_Y = 0.0f;
  public const float VELGUS_EVENTTILE_123_Z = -21.0f;

  // パズルの間、E5(C)
  public const string VELGUS_EVENTTILE_124_C = "EventTile";
  public const string VELGUS_EVENTTILE_124_O = "124";
  public const float VELGUS_EVENTTILE_124_X = 16.0f;
  public const float VELGUS_EVENTTILE_124_Y = 0.0f;
  public const float VELGUS_EVENTTILE_124_Z = -25.0f;

  // パズルの間、E5(D)
  public const string VELGUS_EVENTTILE_125_C = "EventTile";
  public const string VELGUS_EVENTTILE_125_O = "125";
  public const float VELGUS_EVENTTILE_125_X = 12.0f;
  public const float VELGUS_EVENTTILE_125_Y = 0.0f;
  public const float VELGUS_EVENTTILE_125_Z = -26.0f;

  // パズルの間、E5(E)
  public const string VELGUS_EVENTTILE_126_C = "EventTile";
  public const string VELGUS_EVENTTILE_126_O = "126";
  public const float VELGUS_EVENTTILE_126_X = 8.0f;
  public const float VELGUS_EVENTTILE_126_Y = 0.0f;
  public const float VELGUS_EVENTTILE_126_Z = -26.0f;

  // パズルの間、E5(F)
  public const string VELGUS_EVENTTILE_127_C = "EventTile";
  public const string VELGUS_EVENTTILE_127_O = "127";
  public const float VELGUS_EVENTTILE_127_X = 7.0f;
  public const float VELGUS_EVENTTILE_127_Y = 0.0f;
  public const float VELGUS_EVENTTILE_127_Z = -22.0f;

  // パズルの間、E5(G)
  public const string VELGUS_EVENTTILE_128_C = "EventTile";
  public const string VELGUS_EVENTTILE_128_O = "128";
  public const float VELGUS_EVENTTILE_128_X = 7.0f;
  public const float VELGUS_EVENTTILE_128_Y = 0.0f;
  public const float VELGUS_EVENTTILE_128_Z = -18.0f;

  // パズルの間、E5(H)
  public const string VELGUS_EVENTTILE_129_C = "EventTile";
  public const string VELGUS_EVENTTILE_129_O = "129";
  public const float VELGUS_EVENTTILE_129_X = 11.0f;
  public const float VELGUS_EVENTTILE_129_Y = 0.0f;
  public const float VELGUS_EVENTTILE_129_Z = -17.0f;

  // SECRETWALL(隠し壁ドア)ではないのだが、同じコンテンツを使いたいので、同じ名称とする。
  // パズルの間、Wall-A1
  public const string VELGUS_SECRETWALL_130_C = "SecretWall";
  public const string VELGUS_SECRETWALL_130_O = "130";
  public const float VELGUS_SECRETWALL_130_X = 14.0f;
  public const float VELGUS_SECRETWALL_130_Y = 0.5f;
  public const float VELGUS_SECRETWALL_130_Z = -17.0f;

  // パズルの間、Wall-A2
  public const string VELGUS_SECRETWALL_131_C = "SecretWall";
  public const string VELGUS_SECRETWALL_131_O = "131";
  public const float VELGUS_SECRETWALL_131_X = 14.0f;
  public const float VELGUS_SECRETWALL_131_Y = 0.5f;
  public const float VELGUS_SECRETWALL_131_Z = -18.0f;

  // パズルの間、Wall-A3
  public const string VELGUS_SECRETWALL_132_C = "SecretWall";
  public const string VELGUS_SECRETWALL_132_O = "132";
  public const float VELGUS_SECRETWALL_132_X = 15.0f;
  public const float VELGUS_SECRETWALL_132_Y = 0.5f;
  public const float VELGUS_SECRETWALL_132_Z = -18.0f;

  // パズルの間、Wall-A4
  public const string VELGUS_SECRETWALL_133_C = "SecretWall";
  public const string VELGUS_SECRETWALL_133_O = "133";
  public const float VELGUS_SECRETWALL_133_X = 16.0f;
  public const float VELGUS_SECRETWALL_133_Y = 0.5f;
  public const float VELGUS_SECRETWALL_133_Z = -18.0f;

  // パズルの間、Wall-A5
  public const string VELGUS_SECRETWALL_134_C = "SecretWall";
  public const string VELGUS_SECRETWALL_134_O = "134";
  public const float VELGUS_SECRETWALL_134_X = 16.0f;
  public const float VELGUS_SECRETWALL_134_Y = 0.5f;
  public const float VELGUS_SECRETWALL_134_Z = -17.0f;

  // パズルの間、Wall-B1
  public const string VELGUS_SECRETWALL_135_C = "SecretWall";
  public const string VELGUS_SECRETWALL_135_O = "135";
  public const float VELGUS_SECRETWALL_135_X = 16.0f;
  public const float VELGUS_SECRETWALL_135_Y = 0.5f;
  public const float VELGUS_SECRETWALL_135_Z = -20.0f;

  // パズルの間、Wall-B2
  public const string VELGUS_SECRETWALL_136_C = "SecretWall";
  public const string VELGUS_SECRETWALL_136_O = "136";
  public const float VELGUS_SECRETWALL_136_X = 15.0f;
  public const float VELGUS_SECRETWALL_136_Y = 0.5f;
  public const float VELGUS_SECRETWALL_136_Z = -20.0f;

  // パズルの間、Wall-B3
  public const string VELGUS_SECRETWALL_137_C = "SecretWall";
  public const string VELGUS_SECRETWALL_137_O = "137";
  public const float VELGUS_SECRETWALL_137_X = 15.0f;
  public const float VELGUS_SECRETWALL_137_Y = 0.5f;
  public const float VELGUS_SECRETWALL_137_Z = -21.0f;

  // パズルの間、Wall-B4
  public const string VELGUS_SECRETWALL_138_C = "SecretWall";
  public const string VELGUS_SECRETWALL_138_O = "138";
  public const float VELGUS_SECRETWALL_138_X = 15.0f;
  public const float VELGUS_SECRETWALL_138_Y = 0.5f;
  public const float VELGUS_SECRETWALL_138_Z = -22.0f;

  // パズルの間、Wall-B5
  public const string VELGUS_SECRETWALL_139_C = "SecretWall";
  public const string VELGUS_SECRETWALL_139_O = "139";
  public const float VELGUS_SECRETWALL_139_X = 16.0f;
  public const float VELGUS_SECRETWALL_139_Y = 0.5f;
  public const float VELGUS_SECRETWALL_139_Z = -22.0f;

  // パズルの間、Wall-C1
  public const string VELGUS_SECRETWALL_140_C = "SecretWall";
  public const string VELGUS_SECRETWALL_140_O = "140";
  public const float VELGUS_SECRETWALL_140_X = 16.0f;
  public const float VELGUS_SECRETWALL_140_Y = 0.5f;
  public const float VELGUS_SECRETWALL_140_Z = -24.0f;

  // パズルの間、Wall-C2
  public const string VELGUS_SECRETWALL_141_C = "SecretWall";
  public const string VELGUS_SECRETWALL_141_O = "141";
  public const float VELGUS_SECRETWALL_141_X = 15.0f;
  public const float VELGUS_SECRETWALL_141_Y = 0.5f;
  public const float VELGUS_SECRETWALL_141_Z = -24.0f;

  // パズルの間、Wall-C3
  public const string VELGUS_SECRETWALL_142_C = "SecretWall";
  public const string VELGUS_SECRETWALL_142_O = "142";
  public const float VELGUS_SECRETWALL_142_X = 15.0f;
  public const float VELGUS_SECRETWALL_142_Y = 0.5f;
  public const float VELGUS_SECRETWALL_142_Z = -25.0f;

  // パズルの間、Wall-C4
  public const string VELGUS_SECRETWALL_143_C = "SecretWall";
  public const string VELGUS_SECRETWALL_143_O = "143";
  public const float VELGUS_SECRETWALL_143_X = 15.0f;
  public const float VELGUS_SECRETWALL_143_Y = 0.5f;
  public const float VELGUS_SECRETWALL_143_Z = -26.0f;

  // パズルの間、Wall-C5
  public const string VELGUS_SECRETWALL_144_C = "SecretWall";
  public const string VELGUS_SECRETWALL_144_O = "144";
  public const float VELGUS_SECRETWALL_144_X = 16.0f;
  public const float VELGUS_SECRETWALL_144_Y = 0.5f;
  public const float VELGUS_SECRETWALL_144_Z = -26.0f;

  // パズルの間、Wall-D1
  public const string VELGUS_SECRETWALL_145_C = "SecretWall";
  public const string VELGUS_SECRETWALL_145_O = "145";
  public const float VELGUS_SECRETWALL_145_X = 13.0f;
  public const float VELGUS_SECRETWALL_145_Y = 0.5f;
  public const float VELGUS_SECRETWALL_145_Z = -26.0f;

  // パズルの間、Wall-D2
  public const string VELGUS_SECRETWALL_146_C = "SecretWall";
  public const string VELGUS_SECRETWALL_146_O = "146";
  public const float VELGUS_SECRETWALL_146_X = 13.0f;
  public const float VELGUS_SECRETWALL_146_Y = 0.5f;
  public const float VELGUS_SECRETWALL_146_Z = -25.0f;

  // パズルの間、Wall-D3
  public const string VELGUS_SECRETWALL_147_C = "SecretWall";
  public const string VELGUS_SECRETWALL_147_O = "147";
  public const float VELGUS_SECRETWALL_147_X = 12.0f;
  public const float VELGUS_SECRETWALL_147_Y = 0.5f;
  public const float VELGUS_SECRETWALL_147_Z = -25.0f;

  // パズルの間、Wall-D4
  public const string VELGUS_SECRETWALL_148_C = "SecretWall";
  public const string VELGUS_SECRETWALL_148_O = "148";
  public const float VELGUS_SECRETWALL_148_X = 11.0f;
  public const float VELGUS_SECRETWALL_148_Y = 0.5f;
  public const float VELGUS_SECRETWALL_148_Z = -25.0f;

  // パズルの間、Wall-D5
  public const string VELGUS_SECRETWALL_149_C = "SecretWall";
  public const string VELGUS_SECRETWALL_149_O = "149";
  public const float VELGUS_SECRETWALL_149_X = 11.0f;
  public const float VELGUS_SECRETWALL_149_Y = 0.5f;
  public const float VELGUS_SECRETWALL_149_Z = -26.0f;

  // パズルの間、Wall-E1
  public const string VELGUS_SECRETWALL_150_C = "SecretWall";
  public const string VELGUS_SECRETWALL_150_O = "150";
  public const float VELGUS_SECRETWALL_150_X = 9.0f;
  public const float VELGUS_SECRETWALL_150_Y = 0.5f;
  public const float VELGUS_SECRETWALL_150_Z = -26.0f;

  // パズルの間、Wall-E2
  public const string VELGUS_SECRETWALL_151_C = "SecretWall";
  public const string VELGUS_SECRETWALL_151_O = "151";
  public const float VELGUS_SECRETWALL_151_X = 9.0f;
  public const float VELGUS_SECRETWALL_151_Y = 0.5f;
  public const float VELGUS_SECRETWALL_151_Z = -25.0f;

  // パズルの間、Wall-E3
  public const string VELGUS_SECRETWALL_152_C = "SecretWall";
  public const string VELGUS_SECRETWALL_152_O = "152";
  public const float VELGUS_SECRETWALL_152_X = 8.0f;
  public const float VELGUS_SECRETWALL_152_Y = 0.5f;
  public const float VELGUS_SECRETWALL_152_Z = -25.0f;

  // パズルの間、Wall-E4
  public const string VELGUS_SECRETWALL_153_C = "SecretWall";
  public const string VELGUS_SECRETWALL_153_O = "153";
  public const float VELGUS_SECRETWALL_153_X = 7.0f;
  public const float VELGUS_SECRETWALL_153_Y = 0.5f;
  public const float VELGUS_SECRETWALL_153_Z = -25.0f;

  // パズルの間、Wall-E5
  public const string VELGUS_SECRETWALL_154_C = "SecretWall";
  public const string VELGUS_SECRETWALL_154_O = "154";
  public const float VELGUS_SECRETWALL_154_X = 7.0f;
  public const float VELGUS_SECRETWALL_154_Y = 0.5f;
  public const float VELGUS_SECRETWALL_154_Z = -26.0f;

  // パズルの間、Wall-F1
  public const string VELGUS_SECRETWALL_155_C = "SecretWall";
  public const string VELGUS_SECRETWALL_155_O = "155";
  public const float VELGUS_SECRETWALL_155_X = 7.0f;
  public const float VELGUS_SECRETWALL_155_Y = 0.5f;
  public const float VELGUS_SECRETWALL_155_Z = -23.0f;

  // パズルの間、Wall-F2
  public const string VELGUS_SECRETWALL_156_C = "SecretWall";
  public const string VELGUS_SECRETWALL_156_O = "156";
  public const float VELGUS_SECRETWALL_156_X = 8.0f;
  public const float VELGUS_SECRETWALL_156_Y = 0.5f;
  public const float VELGUS_SECRETWALL_156_Z = -23.0f;

  // パズルの間、Wall-F3
  public const string VELGUS_SECRETWALL_157_C = "SecretWall";
  public const string VELGUS_SECRETWALL_157_O = "157";
  public const float VELGUS_SECRETWALL_157_X = 8.0f;
  public const float VELGUS_SECRETWALL_157_Y = 0.5f;
  public const float VELGUS_SECRETWALL_157_Z = -22.0f;

  // パズルの間、Wall-F4
  public const string VELGUS_SECRETWALL_158_C = "SecretWall";
  public const string VELGUS_SECRETWALL_158_O = "158";
  public const float VELGUS_SECRETWALL_158_X = 8.0f;
  public const float VELGUS_SECRETWALL_158_Y = 0.5f;
  public const float VELGUS_SECRETWALL_158_Z = -21.0f;

  // パズルの間、Wall-F5
  public const string VELGUS_SECRETWALL_159_C = "SecretWall";
  public const string VELGUS_SECRETWALL_159_O = "159";
  public const float VELGUS_SECRETWALL_159_X = 7.0f;
  public const float VELGUS_SECRETWALL_159_Y = 0.5f;
  public const float VELGUS_SECRETWALL_159_Z = -21.0f;

  // パズルの間、Wall-G1
  public const string VELGUS_SECRETWALL_160_C = "SecretWall";
  public const string VELGUS_SECRETWALL_160_O = "160";
  public const float VELGUS_SECRETWALL_160_X = 7.0f;
  public const float VELGUS_SECRETWALL_160_Y = 0.5f;
  public const float VELGUS_SECRETWALL_160_Z = -19.0f;

  // パズルの間、Wall-G2
  public const string VELGUS_SECRETWALL_161_C = "SecretWall";
  public const string VELGUS_SECRETWALL_161_O = "161";
  public const float VELGUS_SECRETWALL_161_X = 8.0f;
  public const float VELGUS_SECRETWALL_161_Y = 0.5f;
  public const float VELGUS_SECRETWALL_161_Z = -19.0f;

  // パズルの間、Wall-G3
  public const string VELGUS_SECRETWALL_162_C = "SecretWall";
  public const string VELGUS_SECRETWALL_162_O = "162";
  public const float VELGUS_SECRETWALL_162_X = 8.0f;
  public const float VELGUS_SECRETWALL_162_Y = 0.5f;
  public const float VELGUS_SECRETWALL_162_Z = -18.0f;

  // パズルの間、Wall-G4
  public const string VELGUS_SECRETWALL_163_C = "SecretWall";
  public const string VELGUS_SECRETWALL_163_O = "163";
  public const float VELGUS_SECRETWALL_163_X = 8.0f;
  public const float VELGUS_SECRETWALL_163_Y = 0.5f;
  public const float VELGUS_SECRETWALL_163_Z = -17.0f;

  // パズルの間、Wall-G5
  public const string VELGUS_SECRETWALL_164_C = "SecretWall";
  public const string VELGUS_SECRETWALL_164_O = "164";
  public const float VELGUS_SECRETWALL_164_X = 7.0f;
  public const float VELGUS_SECRETWALL_164_Y = 0.5f;
  public const float VELGUS_SECRETWALL_164_Z = -17.0f;

  // パズルの間、Wall-H1
  public const string VELGUS_SECRETWALL_165_C = "SecretWall";
  public const string VELGUS_SECRETWALL_165_O = "165";
  public const float VELGUS_SECRETWALL_165_X = 10.0f;
  public const float VELGUS_SECRETWALL_165_Y = 0.5f;
  public const float VELGUS_SECRETWALL_165_Z = -17.0f;

  // パズルの間、Wall-H2
  public const string VELGUS_SECRETWALL_166_C = "SecretWall";
  public const string VELGUS_SECRETWALL_166_O = "166";
  public const float VELGUS_SECRETWALL_166_X = 10.0f;
  public const float VELGUS_SECRETWALL_166_Y = 0.5f;
  public const float VELGUS_SECRETWALL_166_Z = -18.0f;

  // パズルの間、Wall-H3
  public const string VELGUS_SECRETWALL_167_C = "SecretWall";
  public const string VELGUS_SECRETWALL_167_O = "167";
  public const float VELGUS_SECRETWALL_167_X = 11.0f;
  public const float VELGUS_SECRETWALL_167_Y = 0.5f;
  public const float VELGUS_SECRETWALL_167_Z = -18.0f;

  // パズルの間、Wall-H4
  public const string VELGUS_SECRETWALL_168_C = "SecretWall";
  public const string VELGUS_SECRETWALL_168_O = "168";
  public const float VELGUS_SECRETWALL_168_X = 12.0f;
  public const float VELGUS_SECRETWALL_168_Y = 0.5f;
  public const float VELGUS_SECRETWALL_168_Z = -18.0f;

  // パズルの間、Wall-H5
  public const string VELGUS_SECRETWALL_169_C = "SecretWall";
  public const string VELGUS_SECRETWALL_169_O = "169";
  public const float VELGUS_SECRETWALL_169_X = 12.0f;
  public const float VELGUS_SECRETWALL_169_Y = 0.5f;
  public const float VELGUS_SECRETWALL_169_Z = -17.0f;

  // パズルの間、BallRed初期位置
  public const string VELGUS_BALLRED_170_C = "BallRed";
  public const string VELGUS_BALLRED_170_O = "170";
  public const float VELGUS_BALLRED_170_X = 13.0f;
  public const float VELGUS_BALLRED_170_Y = 1.0f;
  public const float VELGUS_BALLRED_170_Z = -20.0f;

  // パズルの間、BallBlue初期位置
  public const string VELGUS_BALLBLUE_171_C = "BallBlue";
  public const string VELGUS_BALLBLUE_171_O = "171";
  public const float VELGUS_BALLBLUE_171_X = 12.0f;
  public const float VELGUS_BALLBLUE_171_Y = 1.0f;
  public const float VELGUS_BALLBLUE_171_Z = -22.0f;

  // パズルの間、BallGreen初期位置
  public const string VELGUS_BALLGREEN_172_C = "BallGreen";
  public const string VELGUS_BALLGREEN_172_O = "172";
  public const float VELGUS_BALLGREEN_172_X = 13.0f;
  public const float VELGUS_BALLGREEN_172_Y = 1.0f;
  public const float VELGUS_BALLGREEN_172_Z = -22.0f;

  // パズルの間、BallYellow初期位置
  public const string VELGUS_BALLYELLOW_173_C = "BallGreen";
  public const string VELGUS_BALLYELLOW_173_O = "173";
  public const float VELGUS_BALLYELLOW_173_X = 11.0f;
  public const float VELGUS_BALLYELLOW_173_Y = 1.0f;
  public const float VELGUS_BALLYELLOW_173_Z = -20.0f;

  // パズルの間、BallRedゴール位置
  public const string VELGUS_BALLREDGOAL_174_C = "BallRedGoal";
  public const string VELGUS_BALLREDGOAL_174_O = "174";
  public const float VELGUS_BALLREDGOAL_174_X = 9.0f;
  public const float VELGUS_BALLREDGOAL_174_Y = 1.0f;
  public const float VELGUS_BALLREDGOAL_174_Z = -24.0f;

  // パズルの間、BallBlueゴール位置
  public const string VELGUS_BALLBLUEGOAL_175_C = "BallBlueGoal";
  public const string VELGUS_BALLBLUEGOAL_175_O = "175";
  public const float VELGUS_BALLBLUEGOAL_175_X = 14.0f;
  public const float VELGUS_BALLBLUEGOAL_175_Y = 1.0f;
  public const float VELGUS_BALLBLUEGOAL_175_Z = -19.0f;

  // パズルの間、BallGreenゴール位置
  public const string VELGUS_BALLGREENGOAL_176_C = "BallGreenGoal";
  public const string VELGUS_BALLGREENGOAL_176_O = "176";
  public const float VELGUS_BALLGREENGOAL_176_X = 9.0f;
  public const float VELGUS_BALLGREENGOAL_176_Y = 1.0f;
  public const float VELGUS_BALLGREENGOAL_176_Z = -19.0f;

  // パズルの間、BallYellowゴール位置
  public const string VELGUS_BALLYELLOWGOAL_177_C = "BallGreenGoal";
  public const string VELGUS_BALLYELLOWGOAL_177_O = "177";
  public const float VELGUS_BALLYELLOWGOAL_177_X = 14.0f;
  public const float VELGUS_BALLYELLOWGOAL_177_Y = 1.0f;
  public const float VELGUS_BALLYELLOWGOAL_177_Z = -24.0f;

  // パズルの間、壁ドアＡ
  public const string VELGUS_DOOR_178_C = "VelgusDoor";
  public const string VELGUS_DOOR_178_O = "178";
  public const float VELGUS_DOOR_178_X = 5.0f;
  public const float VELGUS_DOOR_178_Y = 1.0f;
  public const float VELGUS_DOOR_178_Z = -20.0f;

  // パズルの間、CircleRed移動前
  public const string VELGUS_CIRCLE_RED_179_C = "CircleRed";
  public const string VELGUS_CIRCLE_RED_179_O = "179";
  public const float VELGUS_CIRCLE_RED_179_X = 9.0f;
  public const float VELGUS_CIRCLE_RED_179_Y = 0.0f;
  public const float VELGUS_CIRCLE_RED_179_Z = -24.0f;

  // パズルの間、CircleBlue移動前
  public const string VELGUS_CIRCLE_BLUE_180_C = "CircleBlue";
  public const string VELGUS_CIRCLE_BLUE_180_O = "180";
  public const float VELGUS_CIRCLE_BLUE_180_X = 14.0f;
  public const float VELGUS_CIRCLE_BLUE_180_Y = 0.0f;
  public const float VELGUS_CIRCLE_BLUE_180_Z = -19.0f;

  // パズルの間、CircleGreen移動前
  public const string VELGUS_CIRCLE_GREEN_181_C = "CircleGreen";
  public const string VELGUS_CIRCLE_GREEN_181_O = "181";
  public const float VELGUS_CIRCLE_GREEN_181_X = 9.0f;
  public const float VELGUS_CIRCLE_GREEN_181_Y = 0.0f;
  public const float VELGUS_CIRCLE_GREEN_181_Z = -19.0f;

  // パズルの間、CircleYellow移動前
  public const string VELGUS_CIRCLE_YELLOW_182_C = "CircleYellow";
  public const string VELGUS_CIRCLE_YELLOW_182_O = "182";
  public const float VELGUS_CIRCLE_YELLOW_182_X = 14.0f;
  public const float VELGUS_CIRCLE_YELLOW_182_Y = 0.0f;
  public const float VELGUS_CIRCLE_YELLOW_182_Z = -24.0f;

  // パズルの間、CircleRed移動後
  public const string VELGUS_CIRCLE_RED_183_C = "CircleRed";
  public const string VELGUS_CIRCLE_RED_183_O = "183";
  public const float VELGUS_CIRCLE_RED_183_X = 12.0f;
  public const float VELGUS_CIRCLE_RED_183_Y = 0.0f;
  public const float VELGUS_CIRCLE_RED_183_Z = -19.0f;

  // パズルの間、CircleBlue移動後
  public const string VELGUS_CIRCLE_BLUE_184_C = "CircleBlue";
  public const string VELGUS_CIRCLE_BLUE_184_O = "184";
  public const float VELGUS_CIRCLE_BLUE_184_X = 11.0f;
  public const float VELGUS_CIRCLE_BLUE_184_Y = 0.0f;
  public const float VELGUS_CIRCLE_BLUE_184_Z = -24.0f;

  // パズルの間、CircleGreen移動後
  public const string VELGUS_CIRCLE_GREEN_185_C = "CircleGreen";
  public const string VELGUS_CIRCLE_GREEN_185_O = "185";
  public const float VELGUS_CIRCLE_GREEN_185_X = 13.0f;
  public const float VELGUS_CIRCLE_GREEN_185_Y = 0.0f;
  public const float VELGUS_CIRCLE_GREEN_185_Z = -24.0f;

  // パズルの間、CircleYellow移動後
  public const string VELGUS_CIRCLE_YELLOW_186_C = "CircleYellow";
  public const string VELGUS_CIRCLE_YELLOW_186_O = "186";
  public const float VELGUS_CIRCLE_YELLOW_186_X = 10.0f;
  public const float VELGUS_CIRCLE_YELLOW_186_Y = 0.0f;
  public const float VELGUS_CIRCLE_YELLOW_186_Z = -19.0f;

  // パズルの間、BallRedゴール位置(2)
  public const string VELGUS_BALLREDGOAL2_187_C = "BallRedGoal2";
  public const string VELGUS_BALLREDGOAL2_187_O = "187";
  public const float VELGUS_BALLREDGOAL2_187_X = 12.0f;
  public const float VELGUS_BALLREDGOAL2_187_Y = 1.0f;
  public const float VELGUS_BALLREDGOAL2_187_Z = -19.0f;

  // パズルの間、BallBlueゴール位置(2)
  public const string VELGUS_BALLBLUEGOAL2_188_C = "BallBlueGoal2";
  public const string VELGUS_BALLBLUEGOAL2_188_O = "188";
  public const float VELGUS_BALLBLUEGOAL2_188_X = 11.0f;
  public const float VELGUS_BALLBLUEGOAL2_188_Y = 1.0f;
  public const float VELGUS_BALLBLUEGOAL2_188_Z = -24.0f;

  // パズルの間、BallGreenゴール位置(2)
  public const string VELGUS_BALLGREENGOAL2_189_C = "BallGreenGoal2";
  public const string VELGUS_BALLGREENGOAL2_189_O = "189";
  public const float VELGUS_BALLGREENGOAL2_189_X = 13.0f;
  public const float VELGUS_BALLGREENGOAL2_189_Y = 1.0f;
  public const float VELGUS_BALLGREENGOAL2_189_Z = -24.0f;

  // パズルの間、BallYellowゴール位置(2)
  public const string VELGUS_BALLYELLOWGOAL2_190_C = "BallYellowGoal2";
  public const string VELGUS_BALLYELLOWGOAL2_190_O = "190";
  public const float VELGUS_BALLYELLOWGOAL2_190_X = 10.0f;
  public const float VELGUS_BALLYELLOWGOAL2_190_Y = 1.0f;
  public const float VELGUS_BALLYELLOWGOAL2_190_Z = -19.0f;

  // パズルの間、壁ドアＢ
  public const string VELGUS_DOOR_191_C = "VelgusDoor";
  public const string VELGUS_DOOR_191_O = "191";
  public const float VELGUS_DOOR_191_X = 18.0f;
  public const float VELGUS_DOOR_191_Y = 1.0f;
  public const float VELGUS_DOOR_191_Z = -27.0f;

  // パズルの間、CircleRed移動後(3)
  public const string VELGUS_CIRCLE_RED_192_C = "CircleRed";
  public const string VELGUS_CIRCLE_RED_192_O = "192";
  public const float VELGUS_CIRCLE_RED_192_X = 6.0f;
  public const float VELGUS_CIRCLE_RED_192_Y = 0.0f;
  public const float VELGUS_CIRCLE_RED_192_Z = -24.0f;

  // パズルの間、CircleBlue移動後(3)
  public const string VELGUS_CIRCLE_BLUE_193_C = "CircleBlue";
  public const string VELGUS_CIRCLE_BLUE_193_O = "193";
  public const float VELGUS_CIRCLE_BLUE_193_X = 9.0f;
  public const float VELGUS_CIRCLE_BLUE_193_Y = 0.0f;
  public const float VELGUS_CIRCLE_BLUE_193_Z = -16.0f;

  // パズルの間、CircleGreen移動後(3)
  public const string VELGUS_CIRCLE_GREEN_194_C = "CircleGreen";
  public const string VELGUS_CIRCLE_GREEN_194_O = "194";
  public const float VELGUS_CIRCLE_GREEN_194_X = 17.0f;
  public const float VELGUS_CIRCLE_GREEN_194_Y = 0.0f;
  public const float VELGUS_CIRCLE_GREEN_194_Z = -19.0f;

  // パズルの間、CircleYellow移動後(3)
  public const string VELGUS_CIRCLE_YELLOW_195_C = "CircleYellow";
  public const string VELGUS_CIRCLE_YELLOW_195_O = "195";
  public const float VELGUS_CIRCLE_YELLOW_195_X = 14.0f;
  public const float VELGUS_CIRCLE_YELLOW_195_Y = 0.0f;
  public const float VELGUS_CIRCLE_YELLOW_195_Z = -27.0f;

  // パズルの間、BallRedゴール位置(3)
  public const string VELGUS_BALLREDGOAL3_196_C = "BallRedGoal3";
  public const string VELGUS_BALLREDGOAL3_196_O = "196";
  public const float VELGUS_BALLREDGOAL3_196_X = 6.0f;
  public const float VELGUS_BALLREDGOAL3_196_Y = 1.0f;
  public const float VELGUS_BALLREDGOAL3_196_Z = -24.0f;

  // パズルの間、BallBlueゴール位置(3)
  public const string VELGUS_BALLBLUEGOAL3_197_C = "BallBlueGoal3";
  public const string VELGUS_BALLBLUEGOAL3_197_O = "197";
  public const float VELGUS_BALLBLUEGOAL3_197_X = 9.0f;
  public const float VELGUS_BALLBLUEGOAL3_197_Y = 1.0f;
  public const float VELGUS_BALLBLUEGOAL3_197_Z = -16.0f;

  // パズルの間、BallGreenゴール位置(3)
  public const string VELGUS_BALLGREENGOAL3_198_C = "BallGreenGoal2";
  public const string VELGUS_BALLGREENGOAL3_198_O = "198";
  public const float VELGUS_BALLGREENGOAL3_198_X = 17.0f;
  public const float VELGUS_BALLGREENGOAL3_198_Y = 1.0f;
  public const float VELGUS_BALLGREENGOAL3_198_Z = -19.0f;

  // パズルの間、BallYellowゴール位置(3)
  public const string VELGUS_BALLYELLOWGOAL3_199_C = "BallYellowGoal2";
  public const string VELGUS_BALLYELLOWGOAL3_199_O = "199";
  public const float VELGUS_BALLYELLOWGOAL3_199_X = 14.0f;
  public const float VELGUS_BALLYELLOWGOAL3_199_Y = 1.0f;
  public const float VELGUS_BALLYELLOWGOAL3_199_Z = -27.0f;

  // パズルの間、隠し壁ドアＣ
  public const string VELGUS_SECRETWALL_200_C = "SecretWall";
  public const string VELGUS_SECRETWALL_200_O = "200";
  public const float VELGUS_SECRETWALL_200_X = 4.0f;
  public const float VELGUS_SECRETWALL_200_Y = 0.5f;
  public const float VELGUS_SECRETWALL_200_Z = -19.0f;

  // 左上通路：壁ドア１
  public const string VELGUS_DOOR_201_C = "VelgusDoor";
  public const string VELGUS_DOOR_201_O = "201";
  public const float VELGUS_DOOR_201_X = 8.0f;
  public const float VELGUS_DOOR_201_Y = 1.0f;
  public const float VELGUS_DOOR_201_Z = -4.0f;

  // 左上通路：壁ドア２
  public const string VELGUS_DOOR_202_C = "VelgusDoor";
  public const string VELGUS_DOOR_202_O = "202";
  public const float VELGUS_DOOR_202_X = 6.0f;
  public const float VELGUS_DOOR_202_Y = 1.0f;
  public const float VELGUS_DOOR_202_Z = -2.0f;

  // 左上通路：壁ドア３
  public const string VELGUS_DOOR_203_C = "VelgusDoor";
  public const string VELGUS_DOOR_203_O = "203";
  public const float VELGUS_DOOR_203_X = 4.0f;
  public const float VELGUS_DOOR_203_Y = 1.0f;
  public const float VELGUS_DOOR_203_Z = -5.0f;

  // 左上通路：ボス戦
  public const string VELGUS_BOSS_204_C = "Boss";
  public const string VELGUS_BOSS_204_O = "204";
  public const float VELGUS_BOSS_204_X = 4.0f;
  public const float VELGUS_BOSS_204_Y = 0.0f;
  public const float VELGUS_BOSS_204_Z = -8.0f;

  // 下り階段
  public const string VELGUS_DOWNSTAIR_205_C = "Downstair";
  public const string VELGUS_DOWNSTAIR_205_O = "205";
  public const float VELGUS_DOWNSTAIR_205_X = 1.0f;
  public const float VELGUS_DOWNSTAIR_205_Y = 0.0f;
  public const float VELGUS_DOWNSTAIR_205_Z = -19.0f;
  #endregion
  // 番号を1番に戻したいかもしれないが、番号識別による重複が同一ダンジョンにあると危険なので識別IDの連番は継続とする。
  #region "第二階層"
  // 上り階段の右
  public const string VELGUS_LOCATION_206_C = "Location";
  public const string VELGUS_LOCATION_206_O = "206";
  public const float VELGUS_LOCATION_206_X = 2.0f;
  public const float VELGUS_LOCATION_206_Y = 0.0f;
  public const float VELGUS_LOCATION_206_Z = -19.0f;

  // 上り階段
  public const string VELGUS_UPSTAIR_207_C = "Upstair";
  public const string VELGUS_UPSTAIR_207_O = "207";
  public const float VELGUS_UPSTAIR_207_X = 1.0f;
  public const float VELGUS_UPSTAIR_207_Y = 0.0f;
  public const float VELGUS_UPSTAIR_207_Z = -19.0f;

  // 初級の間、E1(1)
  public const string VELGUS_EVENTTILE_208_C = "EventTile";
  public const string VELGUS_EVENTTILE_208_O = "208";
  public const float VELGUS_EVENTTILE_208_X = 14.0f;
  public const float VELGUS_EVENTTILE_208_Y = 0.0f;
  public const float VELGUS_EVENTTILE_208_Z = -18.0f;

  // 初級の間、E1(2)
  public const string VELGUS_EVENTTILE_209_C = "EventTile";
  public const string VELGUS_EVENTTILE_209_O = "209";
  public const float VELGUS_EVENTTILE_209_X = 16.0f;
  public const float VELGUS_EVENTTILE_209_Y = 0.0f;
  public const float VELGUS_EVENTTILE_209_Z = -19.0f;

  // 初級の間、E1(3)
  public const string VELGUS_EVENTTILE_210_C = "EventTile";
  public const string VELGUS_EVENTTILE_210_O = "210";
  public const float VELGUS_EVENTTILE_210_X = 17.0f;
  public const float VELGUS_EVENTTILE_210_Y = 0.0f;
  public const float VELGUS_EVENTTILE_210_Z = -21.0f;

  // 初級の間、E1(4)
  public const string VELGUS_EVENTTILE_211_C = "EventTile";
  public const string VELGUS_EVENTTILE_211_O = "211";
  public const float VELGUS_EVENTTILE_211_X = 16.0f;
  public const float VELGUS_EVENTTILE_211_Y = 0.0f;
  public const float VELGUS_EVENTTILE_211_Z = -23.0f;

  // 初級の間、E1(5)
  public const string VELGUS_EVENTTILE_212_C = "EventTile";
  public const string VELGUS_EVENTTILE_212_O = "212";
  public const float VELGUS_EVENTTILE_212_X = 14.0f;
  public const float VELGUS_EVENTTILE_212_Y = 0.0f;
  public const float VELGUS_EVENTTILE_212_Z = -24.0f;

  // 初級の間、E1(6)
  public const string VELGUS_EVENTTILE_213_C = "EventTile";
  public const string VELGUS_EVENTTILE_213_O = "213";
  public const float VELGUS_EVENTTILE_213_X = 12.0f;
  public const float VELGUS_EVENTTILE_213_Y = 0.0f;
  public const float VELGUS_EVENTTILE_213_Z = -23.0f;

  // 初級の間、E1(7)
  public const string VELGUS_EVENTTILE_214_C = "EventTile";
  public const string VELGUS_EVENTTILE_214_O = "214";
  public const float VELGUS_EVENTTILE_214_X = 11.0f;
  public const float VELGUS_EVENTTILE_214_Y = 0.0f;
  public const float VELGUS_EVENTTILE_214_Z = -21.0f;

  // 初級の間、E1(8)
  public const string VELGUS_EVENTTILE_215_C = "EventTile";
  public const string VELGUS_EVENTTILE_215_O = "215";
  public const float VELGUS_EVENTTILE_215_X = 12.0f;
  public const float VELGUS_EVENTTILE_215_Y = 0.0f;
  public const float VELGUS_EVENTTILE_215_Z = -19.0f;

  // 初級の間、壁ドア１
  public const string VELGUS_DOOR_216_C = "Velgus_Door";
  public const string VELGUS_DOOR_216_O = "216";
  public const float VELGUS_DOOR_216_X = 18.0f;
  public const float VELGUS_DOOR_216_Y = 1.0f;
  public const float VELGUS_DOOR_216_Z = -23.0f;

  // 初級の間、壁ドア２
  public const string VELGUS_DOOR_217_C = "Velgus_Door";
  public const string VELGUS_DOOR_217_O = "217";
  public const float VELGUS_DOOR_217_X = 18.0f;
  public const float VELGUS_DOOR_217_Y = 1.0f;
  public const float VELGUS_DOOR_217_Z = -19.0f;

  // 初級の間、壁ドア３
  public const string VELGUS_DOOR_218_C = "Velgus_Door";
  public const string VELGUS_DOOR_218_O = "218";
  public const float VELGUS_DOOR_218_X = 14.0f;
  public const float VELGUS_DOOR_218_Y = 1.0f;
  public const float VELGUS_DOOR_218_Z = -17.0f;

  // 疾走の間１
  public const string VELGUS_DOOR_219_C = "Velgus_Door";
  public const string VELGUS_DOOR_219_O = "219";
  public const float VELGUS_DOOR_219_X = 23.0f;
  public const float VELGUS_DOOR_219_Y = 1.0f;
  public const float VELGUS_DOOR_219_Z = -23.0f;

  public const string VELGUS_EVENTTILE_220_C = "EventTile";
  public const string VELGUS_EVENTTILE_220_O = "220";
  public const float VELGUS_EVENTTILE_220_X = 24.0f;
  public const float VELGUS_EVENTTILE_220_Y = 0.0f;
  public const float VELGUS_EVENTTILE_220_Z = -23.0f;

  public const string VELGUS_EVENTTILE_221_C = "EventTile";
  public const string VELGUS_EVENTTILE_221_O = "221";
  public const float VELGUS_EVENTTILE_221_X = 25.0f;
  public const float VELGUS_EVENTTILE_221_Y = 0.0f;
  public const float VELGUS_EVENTTILE_221_Z = -23.0f;

  public const string VELGUS_EVENTTILE_222_C = "EventTile";
  public const string VELGUS_EVENTTILE_222_O = "222";
  public const float VELGUS_EVENTTILE_222_X = 26.0f;
  public const float VELGUS_EVENTTILE_222_Y = 0.0f;
  public const float VELGUS_EVENTTILE_222_Z = -23.0f;

  public const string VELGUS_EVENTTILE_223_C = "EventTile";
  public const string VELGUS_EVENTTILE_223_O = "223";
  public const float VELGUS_EVENTTILE_223_X = 27.0f;
  public const float VELGUS_EVENTTILE_223_Y = 0.0f;
  public const float VELGUS_EVENTTILE_223_Z = -23.0f;

  public const string VELGUS_EVENTTILE_224_C = "EventTile";
  public const string VELGUS_EVENTTILE_224_O = "224";
  public const float VELGUS_EVENTTILE_224_X = 28.0f;
  public const float VELGUS_EVENTTILE_224_Y = 0.0f;
  public const float VELGUS_EVENTTILE_224_Z = -23.0f;

  public const string VELGUS_EVENTTILE_225_C = "EventTile";
  public const string VELGUS_EVENTTILE_225_O = "225";
  public const float VELGUS_EVENTTILE_225_X = 29.0f;
  public const float VELGUS_EVENTTILE_225_Y = 0.0f;
  public const float VELGUS_EVENTTILE_225_Z = -23.0f;

  public const string VELGUS_EVENTTILE_226_C = "EventTile";
  public const string VELGUS_EVENTTILE_226_O = "226";
  public const float VELGUS_EVENTTILE_226_X = 30.0f;
  public const float VELGUS_EVENTTILE_226_Y = 0.0f;
  public const float VELGUS_EVENTTILE_226_Z = -23.0f;

  public const string VELGUS_EVENTTILE_227_C = "EventTile";
  public const string VELGUS_EVENTTILE_227_O = "227";
  public const float VELGUS_EVENTTILE_227_X = 31.0f;
  public const float VELGUS_EVENTTILE_227_Y = 0.0f;
  public const float VELGUS_EVENTTILE_227_Z = -23.0f;

  public const string VELGUS_EVENTTILE_228_C = "EventTile";
  public const string VELGUS_EVENTTILE_228_O = "228";
  public const float VELGUS_EVENTTILE_228_X = 32.0f;
  public const float VELGUS_EVENTTILE_228_Y = 0.0f;
  public const float VELGUS_EVENTTILE_228_Z = -23.0f;

  // 疾走の間１、開始地点
  public const string VELGUS_FIXEDTILE_229C = "FIXEDTILE";
  public const string VELGUS_FIXEDTILE_229_O = "229";
  public const float VELGUS_FIXEDTILE_229_X = 24.0f;
  public const float VELGUS_FIXEDTILE_229_Y = 0.5f;
  public const float VELGUS_FIXEDTILE_229_Z = -23.0f;

  public const string VELGUS_FIXEDTILE_230_C = "FIXEDTILE";
  public const string VELGUS_FIXEDTILE_230_O = "230";
  public const float VELGUS_FIXEDTILE_230_X = 25.0f;
  public const float VELGUS_FIXEDTILE_230_Y = 0.5f;
  public const float VELGUS_FIXEDTILE_230_Z = -23.0f;

  public const string VELGUS_FIXEDTILE_231_C = "FIXEDTILE";
  public const string VELGUS_FIXEDTILE_231_O = "231";
  public const float VELGUS_FIXEDTILE_231_X = 26.0f;
  public const float VELGUS_FIXEDTILE_231_Y = 0.5f;
  public const float VELGUS_FIXEDTILE_231_Z = -23.0f;

  public const string VELGUS_FIXEDTILE_232_C = "FIXEDTILE";
  public const string VELGUS_FIXEDTILE_232_O = "232";
  public const float VELGUS_FIXEDTILE_232_X = 27.0f;
  public const float VELGUS_FIXEDTILE_232_Y = 0.5f;
  public const float VELGUS_FIXEDTILE_232_Z = -23.0f;

  public const string VELGUS_FIXEDTILE_233_C = "FIXEDTILE";
  public const string VELGUS_FIXEDTILE_233_O = "233";
  public const float VELGUS_FIXEDTILE_233_X = 28.0f;
  public const float VELGUS_FIXEDTILE_233_Y = 0.5f;
  public const float VELGUS_FIXEDTILE_233_Z = -23.0f;

  public const string VELGUS_FIXEDTILE_234_C = "FIXEDTILE";
  public const string VELGUS_FIXEDTILE_234_O = "234";
  public const float VELGUS_FIXEDTILE_234_X = 29.0f;
  public const float VELGUS_FIXEDTILE_234_Y = 0.5f;
  public const float VELGUS_FIXEDTILE_234_Z = -23.0f;

  public const string VELGUS_FIXEDTILE_235_C = "FIXEDTILE";
  public const string VELGUS_FIXEDTILE_235_O = "235";
  public const float VELGUS_FIXEDTILE_235_X = 30.0f;
  public const float VELGUS_FIXEDTILE_235_Y = 0.5f;
  public const float VELGUS_FIXEDTILE_235_Z = -23.0f;

  public const string VELGUS_FIXEDTILE_236_C = "FIXEDTILE";
  public const string VELGUS_FIXEDTILE_236_O = "236";
  public const float VELGUS_FIXEDTILE_236_X = 31.0f;
  public const float VELGUS_FIXEDTILE_236_Y = 0.5f;
  public const float VELGUS_FIXEDTILE_236_Z = -23.0f;

  // 疾走の間１、終了地点
  public const string VELGUS_FIXEDTILE_237_C = "FIXEDTILE";
  public const string VELGUS_FIXEDTILE_237_O = "237";
  public const float VELGUS_FIXEDTILE_237_X = 32.0f;
  public const float VELGUS_FIXEDTILE_237_Y = 0.5f;
  public const float VELGUS_FIXEDTILE_237_Z = -23.0f;

  public const string VELGUS_SLIDINGTILE_238_C = "SlidingTile";
  public const string VELGUS_SLIDINGTILE_238_O = "238";
  public const float VELGUS_SLIDINGTILE_238_X = 25.0f;
  public const float VELGUS_SLIDINGTILE_238_Y = 0.5f;
  public const float VELGUS_SLIDINGTILE_238_Z = -22.0f;

  public const string VELGUS_DOOR_239_C = "Velgus_Door";
  public const string VELGUS_DOOR_239_O = "239";
  public const float VELGUS_DOOR_239_X = 35.0f;
  public const float VELGUS_DOOR_239_Y = 1.0f;
  public const float VELGUS_DOOR_239_Z = -23.0f;

  // 疾走の間２、開始地点
  public const string VELGUS_EVENTTILE_240_C = "EventTile";
  public const string VELGUS_EVENTTILE_240_O = "240";
  public const float VELGUS_EVENTTILE_240_X = 36.0f;
  public const float VELGUS_EVENTTILE_240_Y = 0.0f;
  public const float VELGUS_EVENTTILE_240_Z = -23.0f;

  // 疾走の間２、終了地点
  public const string VELGUS_EVENTTILE_241_C = "EventTile";
  public const string VELGUS_EVENTTILE_241_O = "241";
  public const float VELGUS_EVENTTILE_241_X = 38.0f;
  public const float VELGUS_EVENTTILE_241_Y = 0.0f;
  public const float VELGUS_EVENTTILE_241_Z = -19.0f;

  // 疾走の間３、壁ドア
  public const string VELGUS_DOOR_242_C = "Velgus_Door";
  public const string VELGUS_DOOR_242_O = "242";
  public const float VELGUS_DOOR_242_X = 35.0f;
  public const float VELGUS_DOOR_242_Y = 1.0f;
  public const float VELGUS_DOOR_242_Z = -19.0f;

  // 疾走の間３、開始地点
  public const string VELGUS_EVENTTILE_243_C = "EventTile";
  public const string VELGUS_EVENTTILE_243_O = "243";
  public const float VELGUS_EVENTTILE_243_X = 34.0f;
  public const float VELGUS_EVENTTILE_243_Y = 0.0f;
  public const float VELGUS_EVENTTILE_243_Z = -19.0f;

  // 疾走の間３、終了地点
  public const string VELGUS_EVENTTILE_244_C = "EventTile";
  public const string VELGUS_EVENTTILE_244_O = "244";
  public const float VELGUS_EVENTTILE_244_X = 35.0f;
  public const float VELGUS_EVENTTILE_244_Y = 0.0f;
  public const float VELGUS_EVENTTILE_244_Z = -14.0f;

  // 疾走の間４、隠し壁ドア
  public const string VELGUS_SECRETWALL_245_C = "SecretWall";
  public const string VELGUS_SECRETWALL_245_O = "245";
  public const float VELGUS_SECRETWALL_245_X = 39.0f;
  public const float VELGUS_SECRETWALL_245_Y = 0.5f;
  public const float VELGUS_SECRETWALL_245_Z = -15.0f;

  // 疾走の間４、開始地点
  public const string VELGUS_EVENTTILE_246_C = "EventTile";
  public const string VELGUS_EVENTTILE_246_O = "246";
  public const float VELGUS_EVENTTILE_246_X = 40.0f;
  public const float VELGUS_EVENTTILE_246_Y = 0.0f;
  public const float VELGUS_EVENTTILE_246_Z = -15.0f;

  // 疾走の間４、終了地点
  public const string VELGUS_EVENTTILE_247_C = "EventTile";
  public const string VELGUS_EVENTTILE_247_O = "247";
  public const float VELGUS_EVENTTILE_247_X = 16.0f;
  public const float VELGUS_EVENTTILE_247_Y = 0.0f;
  public const float VELGUS_EVENTTILE_247_Z = -26.0f;

  // 疾走の間、壁ドア４
  public const string VELGUS_DOOR_248_C = "Velgus_Door";
  public const string VELGUS_DOOR_248_O = "248";
  public const float VELGUS_DOOR_248_X = 16.0f;
  public const float VELGUS_DOOR_248_Y = 1.0f;
  public const float VELGUS_DOOR_248_Z = -25.0f;

  // 疾走の間、壁ドア５
  public const string VELGUS_DOOR_249_C = "Velgus_Door";
  public const string VELGUS_DOOR_249_O = "249";
  public const float VELGUS_DOOR_249_X = 12.0f;
  public const float VELGUS_DOOR_249_Y = 1.0f;
  public const float VELGUS_DOOR_249_Z = -25.0f;

  // 海渡りの間１、終了地点
  public const string VELGUS_EVENTTILE_250_C = "EventTile";
  public const string VELGUS_EVENTTILE_250_O = "250";
  public const float VELGUS_EVENTTILE_250_X = 14.0f;
  public const float VELGUS_EVENTTILE_250_Y = 0.0f;
  public const float VELGUS_EVENTTILE_250_Z = -6.0f;

  // 海渡りの間２、開始地点
  public const string VELGUS_EVENTTILE_251_C = "EventTile";
  public const string VELGUS_EVENTTILE_251_O = "251";
  public const float VELGUS_EVENTTILE_251_X = 10.0f;
  public const float VELGUS_EVENTTILE_251_Y = 0.0f;
  public const float VELGUS_EVENTTILE_251_Z = -4.0f;

  // 海渡りの間２、終了地点
  public const string VELGUS_EVENTTILE_252_C = "EventTile";
  public const string VELGUS_EVENTTILE_252_O = "252";
  public const float VELGUS_EVENTTILE_252_X = 10.0f;
  public const float VELGUS_EVENTTILE_252_Y = 0.0f;
  public const float VELGUS_EVENTTILE_252_Z = -14.0f;

  // 海渡りの間３、開始地点
  public const string VELGUS_EVENTTILE_253_C = "EventTile";
  public const string VELGUS_EVENTTILE_253_O = "253";
  public const float VELGUS_EVENTTILE_253_X = 8.0f;
  public const float VELGUS_EVENTTILE_253_Y = 0.0f;
  public const float VELGUS_EVENTTILE_253_Z = -16.0f;

  // 海渡りの間３、スイッチ地点１
  public const string VELGUS_EVENTTILE_254_C = "EventTile";
  public const string VELGUS_EVENTTILE_254_O = "254";
  public const float VELGUS_EVENTTILE_254_X = 5.0f;
  public const float VELGUS_EVENTTILE_254_Y = 0.0f;
  public const float VELGUS_EVENTTILE_254_Z = -13.0f;

  // 海渡りの間３、スイッチ地点２
  public const string VELGUS_EVENTTILE_255_C = "EventTile";
  public const string VELGUS_EVENTTILE_255_O = "255";
  public const float VELGUS_EVENTTILE_255_X = 2.0f;
  public const float VELGUS_EVENTTILE_255_Y = 0.0f;
  public const float VELGUS_EVENTTILE_255_Z = -12.0f;

  // 海渡りの間３、スイッチ地点３
  public const string VELGUS_EVENTTILE_256_C = "EventTile";
  public const string VELGUS_EVENTTILE_256_O = "256";
  public const float VELGUS_EVENTTILE_256_X = 3.0f;
  public const float VELGUS_EVENTTILE_256_Y = 0.0f;
  public const float VELGUS_EVENTTILE_256_Z = -15.0f;

  // 海渡りの間３、スイッチ地点４
  public const string VELGUS_EVENTTILE_257_C = "EventTile";
  public const string VELGUS_EVENTTILE_257_O = "257";
  public const float VELGUS_EVENTTILE_257_X = 1.0f;
  public const float VELGUS_EVENTTILE_257_Y = 0.0f;
  public const float VELGUS_EVENTTILE_257_Z = -8.0f;

  // 海渡りの間３、終了地点
  public const string VELGUS_EVENTTILE_258_C = "EventTile";
  public const string VELGUS_EVENTTILE_258_O = "258";
  public const float VELGUS_EVENTTILE_258_X = 6.0f;
  public const float VELGUS_EVENTTILE_258_Y = 0.0f;
  public const float VELGUS_EVENTTILE_258_Z = -5.0f;

  // 海渡りの間３ー４、隠し壁ドア
  public const string VELGUS_SECRETWALL_259_C = "SecretWall";
  public const string VELGUS_SECRETWALL_259_O = "259";
  public const float VELGUS_SECRETWALL_259_X = 6.0f;
  public const float VELGUS_SECRETWALL_259_Y = 0.5f;
  public const float VELGUS_SECRETWALL_259_Z = -2.0f;

  // 海渡りの間４、開始地点
  public const string VELGUS_EVENTTILE_260_C = "EventTile";
  public const string VELGUS_EVENTTILE_260_O = "260";
  public const float VELGUS_EVENTTILE_260_X = 16.0f;
  public const float VELGUS_EVENTTILE_260_Y = 0.0f;
  public const float VELGUS_EVENTTILE_260_Z = -1.0f;

  // 海渡りの間４、スイッチ地点１
  public const string VELGUS_EVENTTILE_261_C = "EventTile";
  public const string VELGUS_EVENTTILE_261_O = "261";
  public const float VELGUS_EVENTTILE_261_X = 19.0f;
  public const float VELGUS_EVENTTILE_261_Y = 0.0f;
  public const float VELGUS_EVENTTILE_261_Z = -2.0f;

  // 海渡りの間４、スイッチ地点２
  public const string VELGUS_EVENTTILE_262_C = "EventTile";
  public const string VELGUS_EVENTTILE_262_O = "262";
  public const float VELGUS_EVENTTILE_262_X = 19.0f;
  public const float VELGUS_EVENTTILE_262_Y = 0.0f;
  public const float VELGUS_EVENTTILE_262_Z = -3.0f;

  // 海渡りの間４、スイッチ地点３
  public const string VELGUS_EVENTTILE_263_C = "EventTile";
  public const string VELGUS_EVENTTILE_263_O = "263";
  public const float VELGUS_EVENTTILE_263_X = 19.0f;
  public const float VELGUS_EVENTTILE_263_Y = 0.0f;
  public const float VELGUS_EVENTTILE_263_Z = -4.0f;

  // 海渡りの間４、スイッチ地点４
  public const string VELGUS_EVENTTILE_264_C = "EventTile";
  public const string VELGUS_EVENTTILE_264_O = "264";
  public const float VELGUS_EVENTTILE_264_X = 19.0f;
  public const float VELGUS_EVENTTILE_264_Y = 0.0f;
  public const float VELGUS_EVENTTILE_264_Z = -5.0f;

  // 海渡りの間４、終了地点
  // 終了地点＝宝箱のため、定義不要。

  // エントランス、壁ドア（３重の鍵）
  public const string VELGUS_DOOR_265_C = "VelgusDoor";
  public const string VELGUS_DOOR_265_O = "265";
  public const float VELGUS_DOOR_265_X = 10.0f;
  public const float VELGUS_DOOR_265_Y = 1.0f;
  public const float VELGUS_DOOR_265_Z = -23.0f;

  // ランダムの間、エリア表示（ランダム内容もここで決める）
  public const string VELGUS_EVENTTILE_266_C = "EventTile";
  public const string VELGUS_EVENTTILE_266_O = "266";
  public const float VELGUS_EVENTTILE_266_X = 29.0f;
  public const float VELGUS_EVENTTILE_266_Y = 0.0f;
  public const float VELGUS_EVENTTILE_266_Z = -10.0f;

  // ランダムの間、地点１
  public const string VELGUS_EVENTTILE_267_C = "EventTile";
  public const string VELGUS_EVENTTILE_267_O = "267";
  public const float VELGUS_EVENTTILE_267_X = 31.0f;
  public const float VELGUS_EVENTTILE_267_Y = 0.0f;
  public const float VELGUS_EVENTTILE_267_Z = -10.0f;

  // ランダムの間、地点２
  public const string VELGUS_EVENTTILE_268_C = "EventTile";
  public const string VELGUS_EVENTTILE_268_O = "268";
  public const float VELGUS_EVENTTILE_268_X = 35.0f;
  public const float VELGUS_EVENTTILE_268_Y = 0.0f;
  public const float VELGUS_EVENTTILE_268_Z = -10.0f;

  // ランダムの間、地点３
  public const string VELGUS_EVENTTILE_269_C = "EventTile";
  public const string VELGUS_EVENTTILE_269_O = "269";
  public const float VELGUS_EVENTTILE_269_X = 39.0f;
  public const float VELGUS_EVENTTILE_269_Y = 0.0f;
  public const float VELGUS_EVENTTILE_269_Z = -10.0f;

  // ランダムの間、地点４
  public const string VELGUS_EVENTTILE_270_C = "EventTile";
  public const string VELGUS_EVENTTILE_270_O = "270";
  public const float VELGUS_EVENTTILE_270_X = 31.0f;
  public const float VELGUS_EVENTTILE_270_Y = 0.0f;
  public const float VELGUS_EVENTTILE_270_Z = -6.0f;

  // ランダムの間、地点５
  public const string VELGUS_EVENTTILE_271_C = "EventTile";
  public const string VELGUS_EVENTTILE_271_O = "271";
  public const float VELGUS_EVENTTILE_271_X = 35.0f;
  public const float VELGUS_EVENTTILE_271_Y = 0.0f;
  public const float VELGUS_EVENTTILE_271_Z = -6.0f;

  // ランダムの間、地点６
  public const string VELGUS_EVENTTILE_272_C = "EventTile";
  public const string VELGUS_EVENTTILE_272_O = "272";
  public const float VELGUS_EVENTTILE_272_X = 39.0f;
  public const float VELGUS_EVENTTILE_272_Y = 0.0f;
  public const float VELGUS_EVENTTILE_272_Z = -6.0f;

  // ランダムの間、地点７
  public const string VELGUS_EVENTTILE_273_C = "EventTile";
  public const string VELGUS_EVENTTILE_273_O = "273";
  public const float VELGUS_EVENTTILE_273_X = 31.0f;
  public const float VELGUS_EVENTTILE_273_Y = 0.0f;
  public const float VELGUS_EVENTTILE_273_Z = -2.0f;

  // ランダムの間、地点８
  public const string VELGUS_EVENTTILE_274_C = "EventTile";
  public const string VELGUS_EVENTTILE_274_O = "274";
  public const float VELGUS_EVENTTILE_274_X = 35.0f;
  public const float VELGUS_EVENTTILE_274_Y = 0.0f;
  public const float VELGUS_EVENTTILE_274_Z = -2.0f;

  // ランダムの間、地点９
  public const string VELGUS_EVENTTILE_275_C = "EventTile";
  public const string VELGUS_EVENTTILE_275_O = "275";
  public const float VELGUS_EVENTTILE_275_X = 39.0f;
  public const float VELGUS_EVENTTILE_275_Y = 0.0f;
  public const float VELGUS_EVENTTILE_275_Z = -2.0f;

  // ランダムの間、壁ドア
  public const string VELGUS_DOOR_276_C = "Velgus_Door";
  public const string VELGUS_DOOR_276_O = "276";
  public const float VELGUS_DOOR_276_X = 41.0f;
  public const float VELGUS_DOOR_276_Y = 1.0f;
  public const float VELGUS_DOOR_276_Z = -6.0f;

  // 遠点の間入口、隠し壁ドア
  public const string VELGUS_SECRETWALL_277_C = "SecretWall";
  public const string VELGUS_SECRETWALL_277_O = "277";
  public const float VELGUS_SECRETWALL_277_X = 46.0f;
  public const float VELGUS_SECRETWALL_277_Y = 0.5f;
  public const float VELGUS_SECRETWALL_277_Z = -4.0f;

  // 遠点の間、開始地点（経路内容もここで決める）
  public const string VELGUS_EVENTTILE_278_C = "EventTile";
  public const string VELGUS_EVENTTILE_278_O = "278";
  public const float VELGUS_EVENTTILE_278_X = 48.0f;
  public const float VELGUS_EVENTTILE_278_Y = 0.0f;
  public const float VELGUS_EVENTTILE_278_Z = -7.0f;

  // 遠点の間、地点１
  public const string VELGUS_EVENTTILE_279_C = "EventTile";
  public const string VELGUS_EVENTTILE_279_O = "279";
  public const float VELGUS_EVENTTILE_279_X = 48.0f;
  public const float VELGUS_EVENTTILE_279_Y = 0.0f;
  public const float VELGUS_EVENTTILE_279_Z = -10.0f;

  // 遠点の間、地点２
  public const string VELGUS_EVENTTILE_280_C = "EventTile";
  public const string VELGUS_EVENTTILE_280_O = "280";
  public const float VELGUS_EVENTTILE_280_X = 46.0f;
  public const float VELGUS_EVENTTILE_280_Y = 0.0f;
  public const float VELGUS_EVENTTILE_280_Z = -9.0f;

  // 遠点の間、地点３
  public const string VELGUS_EVENTTILE_281_C = "EventTile";
  public const string VELGUS_EVENTTILE_281_O = "281";
  public const float VELGUS_EVENTTILE_281_X = 42.0f;
  public const float VELGUS_EVENTTILE_281_Y = 0.0f;
  public const float VELGUS_EVENTTILE_281_Z = -9.0f;

  // 遠点の間、地点４
  public const string VELGUS_EVENTTILE_282_C = "EventTile";
  public const string VELGUS_EVENTTILE_282_O = "282";
  public const float VELGUS_EVENTTILE_282_X = 42.0f;
  public const float VELGUS_EVENTTILE_282_Y = 0.0f;
  public const float VELGUS_EVENTTILE_282_Z = -12.0f;

  // 遠点の間、地点５
  public const string VELGUS_EVENTTILE_283_C = "EventTile";
  public const string VELGUS_EVENTTILE_283_O = "283";
  public const float VELGUS_EVENTTILE_283_X = 45.0f;
  public const float VELGUS_EVENTTILE_283_Y = 0.0f;
  public const float VELGUS_EVENTTILE_283_Z = -11.0f;

  // 遠点の間、地点６
  public const string VELGUS_EVENTTILE_284_C = "EventTile";
  public const string VELGUS_EVENTTILE_284_O = "284";
  public const float VELGUS_EVENTTILE_284_X = 48.0f;
  public const float VELGUS_EVENTTILE_284_Y = 0.0f;
  public const float VELGUS_EVENTTILE_284_Z = -12.0f;

  // 遠点の間、壁ドア
  public const string VELGUS_DOOR_285_C = "Velgus_Door";
  public const string VELGUS_DOOR_285_O = "285";
  public const float VELGUS_DOOR_285_X = 47.0f;
  public const float VELGUS_DOOR_285_Y = 1.0f;
  public const float VELGUS_DOOR_285_Z = -14.0f;

  // マップ右下、隠し壁ドア
  public const string VELGUS_SECRETWALL_286_C = "SecretWall";
  public const string VELGUS_SECRETWALL_286_O = "286";
  public const float VELGUS_SECRETWALL_286_X = 46.0f;
  public const float VELGUS_SECRETWALL_286_Y = 0.5f;
  public const float VELGUS_SECRETWALL_286_Z = -27.0f;

  // ボス前のイベント
  public const string VELGUS_EVENTTILE_287_C = "EventTile";
  public const string VELGUS_EVENTTILE_287_O = "287";
  public const float VELGUS_EVENTTILE_287_X = 9.0f;
  public const float VELGUS_EVENTTILE_287_Y = 0.0f;
  public const float VELGUS_EVENTTILE_287_Z = -25.0f;

  // ボス戦
  public const string VELGUS_BOSS_288_C = "Boss";
  public const string VELGUS_BOSS_288_O = "288";
  public const float VELGUS_BOSS_288_X = 7.0f;
  public const float VELGUS_BOSS_288_Y = 0.0f;
  public const float VELGUS_BOSS_288_Z = -25.0f;

  // 下り階段
  public const string VELGUS_DOWNSTAIR_289_C = "Downstair";
  public const string VELGUS_DOWNSTAIR_289_O = "289";
  public const float VELGUS_DOWNSTAIR_289_X = 1.0f;
  public const float VELGUS_DOWNSTAIR_289_Y = 0.0f;
  public const float VELGUS_DOWNSTAIR_289_Z = -25.0f;

  // 第三階層から登って来た時の開始地点
  public const string VELGUS_LOCATION_290_C = "Location";
  public const string VELGUS_LOCATION_290_O = "290";
  public const float VELGUS_LOCATION_290_X = 2.0f;
  public const float VELGUS_LOCATION_290_Y = 0.0f;
  public const float VELGUS_LOCATION_290_Z = -25.0f;
  #endregion
  // 番号を1番に戻したいかもしれないが、番号識別による重複が同一ダンジョンにあると危険なので識別IDの連番は継続とする。
  #region "第三階層"
  // 第二階層から降りて来た時の開始地点
  public const string VELGUS_LOCATION_291_C = "Location";
  public const string VELGUS_LOCATION_291_O = "291";
  public const float VELGUS_LOCATION_291_X = 2.0f;
  public const float VELGUS_LOCATION_291_Y = 0.0f;
  public const float VELGUS_LOCATION_291_Z = -25.0f;

  // 上り階段
  public const string VELGUS_UPSTAIR_292_C = "Upstair";
  public const string VELGUS_UPSTAIR_292_O = "292";
  public const float VELGUS_UPSTAIR_292_X = 1.0f;
  public const float VELGUS_UPSTAIR_292_Y = 0.0f;
  public const float VELGUS_UPSTAIR_292_Z = -25.0f;

  // エリア可視化（１）
  public const string VELGUS_EVENTTILE_293_C = "EventTile";
  public const string VELGUS_EVENTTILE_293_O = "293";
  public const float VELGUS_EVENTTILE_293_X = 7.0f;
  public const float VELGUS_EVENTTILE_293_Y = 0.0f;
  public const float VELGUS_EVENTTILE_293_Z = -27.0f;

  // ボス戦１前のイベント
  public const string VELGUS_EVENTTILE_294_C = "EventTile";
  public const string VELGUS_EVENTTILE_294_O = "294";
  public const float VELGUS_EVENTTILE_294_X = 7.0f;
  public const float VELGUS_EVENTTILE_294_Y = 0.0f;
  public const float VELGUS_EVENTTILE_294_Z = -19.0f;

  // ボス戦１
  public const string VELGUS_BOSS_295_C = "Boss";
  public const string VELGUS_BOSS_295_O = "295";
  public const float VELGUS_BOSS_295_X = 7.0f;
  public const float VELGUS_BOSS_295_Y = 0.0f;
  public const float VELGUS_BOSS_295_Z = -17.0f;

  // ボス戦２前のイベント
  public const string VELGUS_EVENTTILE_296_C = "EventTile";
  public const string VELGUS_EVENTTILE_296_O = "296";
  public const float VELGUS_EVENTTILE_296_X = 3.0f;
  public const float VELGUS_EVENTTILE_296_Y = 0.0f;
  public const float VELGUS_EVENTTILE_296_Z = -6.0f;

  // ボス戦２
  public const string VELGUS_BOSS_297_C = "Boss";
  public const string VELGUS_BOSS_297_O = "297";
  public const float VELGUS_BOSS_297_X = 5.0f;
  public const float VELGUS_BOSS_297_Y = 0.0f;
  public const float VELGUS_BOSS_297_Z = -6.0f;

  // ボス戦３前のイベント
  public const string VELGUS_EVENTTILE_298_C = "EventTile";
  public const string VELGUS_EVENTTILE_298_O = "298";
  public const float VELGUS_EVENTTILE_298_X = 26.0f;
  public const float VELGUS_EVENTTILE_298_Y = 0.0f;
  public const float VELGUS_EVENTTILE_298_Z = -3.0f;

  // ボス戦３
  public const string VELGUS_BOSS_299_C = "Boss";
  public const string VELGUS_BOSS_299_O = "298";
  public const float VELGUS_BOSS_299_X = 26.0f;
  public const float VELGUS_BOSS_299_Y = 0.0f;
  public const float VELGUS_BOSS_299_Z = -5.0f;

  // ボス戦４前のイベント
  public const string VELGUS_EVENTTILE_300_C = "EventTile";
  public const string VELGUS_EVENTTILE_300_O = "300";
  public const float VELGUS_EVENTTILE_300_X = 47.0f;
  public const float VELGUS_EVENTTILE_300_Y = 0.0f;
  public const float VELGUS_EVENTTILE_300_Z = -7.0f;

  // ボス戦４
  public const string VELGUS_BOSS_301_C = "Boss";
  public const string VELGUS_BOSS_301_O = "301";
  public const float VELGUS_BOSS_301_X = 45.0f;
  public const float VELGUS_BOSS_301_Y = 0.0f;
  public const float VELGUS_BOSS_301_Z = -7.0f;

  // ボス戦５前のイベント
  public const string VELGUS_EVENTTILE_302_C = "EventTile";
  public const string VELGUS_EVENTTILE_302_O = "302";
  public const float VELGUS_EVENTTILE_302_X = 41.0f;
  public const float VELGUS_EVENTTILE_302_Y = 0.0f;
  public const float VELGUS_EVENTTILE_302_Z = -17.0f;

  // ボス戦５
  public const string VELGUS_BOSS_303_C = "Boss";
  public const string VELGUS_BOSS_303_O = "303";
  public const float VELGUS_BOSS_303_X = 41.0f;
  public const float VELGUS_BOSS_303_Y = 0.0f;
  public const float VELGUS_BOSS_303_Z = -19.0f;

  // ボス戦６前のイベント
  public const string VELGUS_EVENTTILE_304_C = "EventTile";
  public const string VELGUS_EVENTTILE_304_O = "304";
  public const float VELGUS_EVENTTILE_304_X = 17.0f;
  public const float VELGUS_EVENTTILE_304_Y = 0.0f;
  public const float VELGUS_EVENTTILE_304_Z = -9.0f;

  // ボス戦６
  public const string VELGUS_BOSS_305_C = "Boss";
  public const string VELGUS_BOSS_305_O = "305";
  public const float VELGUS_BOSS_305_X = 17.0f;
  public const float VELGUS_BOSS_305_Y = 0.0f;
  public const float VELGUS_BOSS_305_Z = -11.0f;

  // ボス戦７前のイベント
  public const string VELGUS_EVENTTILE_306_C = "EventTile";
  public const string VELGUS_EVENTTILE_306_O = "306";
  public const float VELGUS_EVENTTILE_306_X = 26.0f;
  public const float VELGUS_EVENTTILE_306_Y = 0.0f;
  public const float VELGUS_EVENTTILE_306_Z = -23.0f;

  // ボス戦７
  public const string VELGUS_BOSS_307_C = "Boss";
  public const string VELGUS_BOSS_307_O = "307";
  public const float VELGUS_BOSS_307_X = 26.0f;
  public const float VELGUS_BOSS_307_Y = 0.0f;
  public const float VELGUS_BOSS_307_Z = -21.0f;

  // 下り階段
  public const string VELGUS_DOWNSTAIR_308_C = "Downstair";
  public const string VELGUS_DOWNSTAIR_308_O = "308";
  public const float VELGUS_DOWNSTAIR_308_X = 26.0f;
  public const float VELGUS_DOWNSTAIR_308_Y = 0.0f;
  public const float VELGUS_DOWNSTAIR_308_Z = -14.0f;

  // 第四階層から登って来た時の開始地点
  public const string VELGUS_LOCATION_309_C = "Location";
  public const string VELGUS_LOCATION_309_O = "309";
  public const float VELGUS_LOCATION_309_X = 26.0f;
  public const float VELGUS_LOCATION_309_Y = 0.0f;
  public const float VELGUS_LOCATION_309_Z = -15.0f;

  // シークレット壁（１）
  public const string VELGUS_SECRETWALL_310_C = "SecretWall";
  public const string VELGUS_SECRETWALL_310_O = "310";
  public const float VELGUS_SECRETWALL_310_X = 10.0f;
  public const float VELGUS_SECRETWALL_310_Y = 0.5f;
  public const float VELGUS_SECRETWALL_310_Z = -21.0f;

  // シークレット壁（２）
  public const string VELGUS_SECRETWALL_311_C = "SecretWall";
  public const string VELGUS_SECRETWALL_311_O = "311";
  public const float VELGUS_SECRETWALL_311_X = 19.0f;
  public const float VELGUS_SECRETWALL_311_Y = 0.5f;
  public const float VELGUS_SECRETWALL_311_Z = -4.0f;

  // シークレット壁（３）
  public const string VELGUS_SECRETWALL_312_C = "SecretWall";
  public const string VELGUS_SECRETWALL_312_O = "312";
  public const float VELGUS_SECRETWALL_312_X = 47.0f;
  public const float VELGUS_SECRETWALL_312_Y = 0.5f;
  public const float VELGUS_SECRETWALL_312_Z = -10.0f;

  // シークレット壁（３）(FakeSea 通路タイル１)
  public const string VELGUS_FAKESEA_313_C = "FakeSea";
  public const string VELGUS_FAKESEA_313_O = "313";
  public const float VELGUS_FAKESEA_313_X = 45.0f;
  public const float VELGUS_FAKESEA_313_Y = 0.0f;
  public const float VELGUS_FAKESEA_313_Z = -10.0f;

  // シークレット壁（３）(FakeSea 通路タイル２)
  public const string VELGUS_FAKESEA_314_C = "FakeSea";
  public const string VELGUS_FAKESEA_314_O = "314";
  public const float VELGUS_FAKESEA_314_X = 46.0f;
  public const float VELGUS_FAKESEA_314_Y = 0.0f;
  public const float VELGUS_FAKESEA_314_Z = -10.0f;

  // シークレット壁（４）
  public const string VELGUS_SECRETWALL_315_C = "SecretWall";
  public const string VELGUS_SECRETWALL_315_O = "315";
  public const float VELGUS_SECRETWALL_315_X = 33.0f;
  public const float VELGUS_SECRETWALL_315_Y = 0.5f;
  public const float VELGUS_SECRETWALL_315_Z = -26.0f;
  #endregion
  // 番号を1番に戻したいかもしれないが、番号識別による重複が同一ダンジョンにあると危険なので識別IDの連番は継続とする。
  #region "第四階層"
  // 第三階層から降りて来た時の開始地点
  public const string VELGUS_LOCATION_316_C = "Location";
  public const string VELGUS_LOCATION_316_O = "316";
  public const float VELGUS_LOCATION_316_X = 26.0f;
  public const float VELGUS_LOCATION_316_Y = 0.0f;
  public const float VELGUS_LOCATION_316_Z = -15.0f;

  // 上り階段
  public const string VELGUS_UPSTAIR_317_C = "Upstair";
  public const string VELGUS_UPSTAIR_317_O = "317";
  public const float VELGUS_UPSTAIR_317_X = 26.0f;
  public const float VELGUS_UPSTAIR_317_Y = 0.0f;
  public const float VELGUS_UPSTAIR_317_Z = -14.0f;

  // 待機タイル：上
  public const string VELGUS_EVENTTILE_318_C = "EventTile";
  public const string VELGUS_EVENTTILE_318_O = "318";
  public const float VELGUS_EVENTTILE_318_X = 26.0f;
  public const float VELGUS_EVENTTILE_318_Y = 0.0f;
  public const float VELGUS_EVENTTILE_318_Z = -10.0f;

  // 待機タイル：左
  public const string VELGUS_EVENTTILE_319_C = "EventTile";
  public const string VELGUS_EVENTTILE_319_O = "319";
  public const float VELGUS_EVENTTILE_319_X = 22.0f;
  public const float VELGUS_EVENTTILE_319_Y = 0.0f;
  public const float VELGUS_EVENTTILE_319_Z = -14.0f;

  // 待機タイル：右
  public const string VELGUS_EVENTTILE_320_C = "EventTile";
  public const string VELGUS_EVENTTILE_320_O = "320";
  public const float VELGUS_EVENTTILE_320_X = 30.0f;
  public const float VELGUS_EVENTTILE_320_Y = 0.0f;
  public const float VELGUS_EVENTTILE_320_Z = -14.0f;

  // 待機タイル：下
  public const string VELGUS_EVENTTILE_321_C = "EventTile";
  public const string VELGUS_EVENTTILE_321_O = "321";
  public const float VELGUS_EVENTTILE_321_X = 26.0f;
  public const float VELGUS_EVENTTILE_321_Y = 0.0f;
  public const float VELGUS_EVENTTILE_321_Z = -18.0f;

  // シークレット壁（上）
  public const string VELGUS_SECRETWALL_322_C = "SecretWall";
  public const string VELGUS_SECRETWALL_322_O = "322";
  public const float VELGUS_SECRETWALL_322_X = 26.0f;
  public const float VELGUS_SECRETWALL_322_Y = 0.5f;
  public const float VELGUS_SECRETWALL_322_Z = -9.0f;

  // シークレット壁（左）
  public const string VELGUS_SECRETWALL_323_C = "SecretWall";
  public const string VELGUS_SECRETWALL_323_O = "323";
  public const float VELGUS_SECRETWALL_323_X = 21.0f;
  public const float VELGUS_SECRETWALL_323_Y = 0.5f;
  public const float VELGUS_SECRETWALL_323_Z = -14.0f;

  // シークレット壁（右）
  public const string VELGUS_SECRETWALL_324_C = "SecretWall";
  public const string VELGUS_SECRETWALL_324_O = "324";
  public const float VELGUS_SECRETWALL_324_X = 31.0f;
  public const float VELGUS_SECRETWALL_324_Y = 0.5f;
  public const float VELGUS_SECRETWALL_324_Z = -14.0f;

  // シークレット壁（下）
  public const string VELGUS_SECRETWALL_325_C = "SecretWall";
  public const string VELGUS_SECRETWALL_325_O = "325";
  public const float VELGUS_SECRETWALL_325_X = 26.0f;
  public const float VELGUS_SECRETWALL_325_Y = 0.5f;
  public const float VELGUS_SECRETWALL_325_Z = -19.0f;

  // シークレット壁（下の下）
  public const string VELGUS_SECRETWALL_326_C = "SecretWall";
  public const string VELGUS_SECRETWALL_326_O = "326";
  public const float VELGUS_SECRETWALL_326_X = 26.0f;
  public const float VELGUS_SECRETWALL_326_Y = 0.5f;
  public const float VELGUS_SECRETWALL_326_Z = -27.0f;

  // 未タイル開放ポイント：上
  public const string VELGUS_EVENTTILE_327_C = "EventTile";
  public const string VELGUS_EVENTTILE_327_O = "327";
  public const float VELGUS_EVENTTILE_327_X = 26.0f;
  public const float VELGUS_EVENTTILE_327_Y = 0.0f;
  public const float VELGUS_EVENTTILE_327_Z = -8.0f;

  // 未タイル開放ポイント：左
  public const string VELGUS_EVENTTILE_328_C = "EventTile";
  public const string VELGUS_EVENTTILE_328_O = "328";
  public const float VELGUS_EVENTTILE_328_X = 20.0f;
  public const float VELGUS_EVENTTILE_328_Y = 0.0f;
  public const float VELGUS_EVENTTILE_328_Z = -14.0f;

  // 未タイル開放ポイント：右
  public const string VELGUS_EVENTTILE_329_C = "EventTile";
  public const string VELGUS_EVENTTILE_329_O = "329";
  public const float VELGUS_EVENTTILE_329_X = 32.0f;
  public const float VELGUS_EVENTTILE_329_Y = 0.0f;
  public const float VELGUS_EVENTTILE_329_Z = -14.0f;

  // 未タイル開放ポイント：下
  public const string VELGUS_EVENTTILE_330_C = "EventTile";
  public const string VELGUS_EVENTTILE_330_O = "330";
  public const float VELGUS_EVENTTILE_330_X = 26.0f;
  public const float VELGUS_EVENTTILE_330_Y = 0.0f;
  public const float VELGUS_EVENTTILE_330_Z = -20.0f;

  // 真実の間、入口
  public const string VELGUS_EVENTTILE_331_C = "EventTile";
  public const string VELGUS_EVENTTILE_331_O = "331";
  public const float VELGUS_EVENTTILE_331_X = 5.0f;
  public const float VELGUS_EVENTTILE_331_Y = 0.0f;
  public const float VELGUS_EVENTTILE_331_Z = -11.0f;

  // 真実の間、隠し扉
  public const string VELGUS_SECRETWALL_332_C = "SecretWall";
  public const string VELGUS_SECRETWALL_332_O = "332";
  public const float VELGUS_SECRETWALL_332_X = 5.0f;
  public const float VELGUS_SECRETWALL_332_Y = 0.5f;
  public const float VELGUS_SECRETWALL_332_Z = -10.0f;

  // 真実の間、未タイル開放ポイント
  public const string VELGUS_EVENTTILE_333_C = "EventTile";
  public const string VELGUS_EVENTTILE_333_O = "333";
  public const float VELGUS_EVENTTILE_333_X = 5.0f;
  public const float VELGUS_EVENTTILE_333_Y = 0.0f;
  public const float VELGUS_EVENTTILE_333_Z = -9.0f;

  // ObsidianStone
  public const string VELGUS_ObsidianStone_1_C = "ObsidianStone";
  public const string VELGUS_ObsidianStone_1_O = "1";
  public const float VELGUS_ObsidianStone_1_X = 5.0f;
  public const float VELGUS_ObsidianStone_1_Y = 1.0f;
  public const float VELGUS_ObsidianStone_1_Z = -4.0f;

  #endregion

  #region "宝箱"
  #region "第一階層"
  // エントランスの上
  public const string VELGUS_TREASURE_1_C = "Treasure";
  public const string VELGUS_TREASURE_1_O = "1";
  public const float VELGUS_TREASURE_1_X = 14.0f;
  public const float VELGUS_TREASURE_1_Y = 1.0f;
  public const float VELGUS_TREASURE_1_Z = -2.0f;

  // 中央の間（１）
  public const string VELGUS_TREASURE_2_C = "Treasure";
  public const string VELGUS_TREASURE_2_O = "2";
  public const float VELGUS_TREASURE_2_X = 25.0f;
  public const float VELGUS_TREASURE_2_Y = 1.0f;
  public const float VELGUS_TREASURE_2_Z = -9.0f;

  // 中央の間（２）
  public const string VELGUS_TREASURE_3_C = "Treasure";
  public const string VELGUS_TREASURE_3_O = "3";
  public const float VELGUS_TREASURE_3_X = 23.0f;
  public const float VELGUS_TREASURE_3_Y = 1.0f;
  public const float VELGUS_TREASURE_3_Z = -1.0f;

  // 右方の間（１）
  public const string VELGUS_TREASURE_4_C = "Treasure";
  public const string VELGUS_TREASURE_4_O = "4";
  public const float VELGUS_TREASURE_4_X = 48.0f;
  public const float VELGUS_TREASURE_4_Y = 1.0f;
  public const float VELGUS_TREASURE_4_Z = -12.0f;

  // 右方の間（２）
  public const string VELGUS_TREASURE_5_C = "Treasure";
  public const string VELGUS_TREASURE_5_O = "5";
  public const float VELGUS_TREASURE_5_X = 37.0f;
  public const float VELGUS_TREASURE_5_Y = 1.0f;
  public const float VELGUS_TREASURE_5_Z = -1.0f;

  // 順路の間（１）
  public const string VELGUS_TREASURE_6_C = "Treasure";
  public const string VELGUS_TREASURE_6_O = "6";
  public const float VELGUS_TREASURE_6_X = 33.0f;
  public const float VELGUS_TREASURE_6_Y = 1.0f;
  public const float VELGUS_TREASURE_6_Z = -21.0f;

  // 順路の間（２）
  public const string VELGUS_TREASURE_7_C = "Treasure";
  public const string VELGUS_TREASURE_7_O = "7";
  public const float VELGUS_TREASURE_7_X = 42.0f;
  public const float VELGUS_TREASURE_7_Y = 1.0f;
  public const float VELGUS_TREASURE_7_Z = -25.0f;

  // 順路の間（３）
  public const string VELGUS_TREASURE_8_C = "Treasure";
  public const string VELGUS_TREASURE_8_O = "8";
  public const float VELGUS_TREASURE_8_X = 47.0f;
  public const float VELGUS_TREASURE_8_Y = 1.0f;
  public const float VELGUS_TREASURE_8_Z = -19.0f;

  // パズルの間（１）
  public const string VELGUS_TREASURE_9_C = "Treasure";
  public const string VELGUS_TREASURE_9_O = "9";
  public const float VELGUS_TREASURE_9_X = 4.0f;
  public const float VELGUS_TREASURE_9_Y = 1.0f;
  public const float VELGUS_TREASURE_9_Z = -28.0f;

  // パズルの間（２）
  public const string VELGUS_TREASURE_10_C = "Treasure";
  public const string VELGUS_TREASURE_10_O = "10";
  public const float VELGUS_TREASURE_10_X = 19.0f;
  public const float VELGUS_TREASURE_10_Y = 1.0f;
  public const float VELGUS_TREASURE_10_Z = -19.0f;

  // パズルの間（３）
  public const string VELGUS_TREASURE_11_C = "Treasure";
  public const string VELGUS_TREASURE_11_O = "11";
  public const float VELGUS_TREASURE_11_X = 4.0f;
  public const float VELGUS_TREASURE_11_Y = 1.0f;
  public const float VELGUS_TREASURE_11_Z = -15.0f;

  // 左上通路（１）
  public const string VELGUS_TREASURE_12_C = "Treasure";
  public const string VELGUS_TREASURE_12_O = "12";
  public const float VELGUS_TREASURE_12_X = 8.0f;
  public const float VELGUS_TREASURE_12_Y = 1.0f;
  public const float VELGUS_TREASURE_12_Z = -3.0f;

  // 左上通路（２）
  public const string VELGUS_TREASURE_13_C = "Treasure";
  public const string VELGUS_TREASURE_13_O = "13";
  public const float VELGUS_TREASURE_13_X = 4.0f;
  public const float VELGUS_TREASURE_13_Y = 1.0f;
  public const float VELGUS_TREASURE_13_Z = -3.0f;
  #endregion
  #region "第二階層"
  // 入口の通路
  public const string VELGUS_2_TREASURE_1_C = "Treasure";
  public const string VELGUS_2_TREASURE_1_O = "1";
  public const float VELGUS_2_TREASURE_1_X = 7.0f;
  public const float VELGUS_2_TREASURE_1_Y = 1.0f;
  public const float VELGUS_2_TREASURE_1_Z = -19.0f;

  // 疾走の間１
  public const string VELGUS_2_TREASURE_2_C = "Treasure";
  public const string VELGUS_2_TREASURE_2_O = "2";
  public const float VELGUS_2_TREASURE_2_X = 34.0f;
  public const float VELGUS_2_TREASURE_2_Y = 1.0f;
  public const float VELGUS_2_TREASURE_2_Z = -24.0f;

  // 疾走の間２
  public const string VELGUS_2_TREASURE_3_C = "Treasure";
  public const string VELGUS_2_TREASURE_3_O = "3";
  public const float VELGUS_2_TREASURE_3_X = 36.0f;
  public const float VELGUS_2_TREASURE_3_Y = 1.0f;
  public const float VELGUS_2_TREASURE_3_Z = -20.0f;

  // 疾走の間３
  public const string VELGUS_2_TREASURE_4_C = "Treasure";
  public const string VELGUS_2_TREASURE_4_O = "4";
  public const float VELGUS_2_TREASURE_4_X = 38.0f;
  public const float VELGUS_2_TREASURE_4_Y = 1.0f;
  public const float VELGUS_2_TREASURE_4_Z = -16.0f;

  // 疾走の間３－２
  public const string VELGUS_2_TREASURE_5_C = "Treasure";
  public const string VELGUS_2_TREASURE_5_O = "5";
  public const float VELGUS_2_TREASURE_5_X = 38.0f;
  public const float VELGUS_2_TREASURE_5_Y = 1.0f;
  public const float VELGUS_2_TREASURE_5_Z = -14.0f;

  // 疾走の間４クリア後の左
  public const string VELGUS_2_TREASURE_6_C = "Treasure";
  public const string VELGUS_2_TREASURE_6_O = "6";
  public const float VELGUS_2_TREASURE_6_X = 13.0f;
  public const float VELGUS_2_TREASURE_6_Y = 1.0f;
  public const float VELGUS_2_TREASURE_6_Z = -27.0f;

  // 疾走の間４、走破後の隠し
  public const string VELGUS_2_TREASURE_7_C = "Treasure";
  public const string VELGUS_2_TREASURE_7_O = "7";
  public const float VELGUS_2_TREASURE_7_X = 47.0f;
  public const float VELGUS_2_TREASURE_7_Y = 1.0f;
  public const float VELGUS_2_TREASURE_7_Z = -26.0f;

  // 海渡りの間１
  public const string VELGUS_2_TREASURE_8_C = "Treasure";
  public const string VELGUS_2_TREASURE_8_O = "8";
  public const float VELGUS_2_TREASURE_8_X = 14.0f;
  public const float VELGUS_2_TREASURE_8_Y = 1.0f;
  public const float VELGUS_2_TREASURE_8_Z = -4.0f;

  // 海渡りの間２
  public const string VELGUS_2_TREASURE_9_C = "Treasure";
  public const string VELGUS_2_TREASURE_9_O = "9";
  public const float VELGUS_2_TREASURE_9_X = 11.0f;
  public const float VELGUS_2_TREASURE_9_Y = 1.0f;
  public const float VELGUS_2_TREASURE_9_Z = -16.0f;

  // 海渡りの間３ー１
  public const string VELGUS_2_TREASURE_10_C = "Treasure";
  public const string VELGUS_2_TREASURE_10_O = "10";
  public const float VELGUS_2_TREASURE_10_X = 5.0f;
  public const float VELGUS_2_TREASURE_10_Y = 1.0f;
  public const float VELGUS_2_TREASURE_10_Z = -3.0f;

  // 海渡りの間３ー２
  public const string VELGUS_2_TREASURE_11_C = "Treasure";
  public const string VELGUS_2_TREASURE_11_O = "11";
  public const float VELGUS_2_TREASURE_11_X = 7.0f;
  public const float VELGUS_2_TREASURE_11_Y = 1.0f;
  public const float VELGUS_2_TREASURE_11_Z = -3.0f;

  // 海渡りの間４
  public const string VELGUS_2_TREASURE_12_C = "Treasure";
  public const string VELGUS_2_TREASURE_12_O = "12";
  public const float VELGUS_2_TREASURE_12_X = 1.0f;
  public const float VELGUS_2_TREASURE_12_Y = 1.0f;
  public const float VELGUS_2_TREASURE_12_Z = -5.0f;

  // 海渡りの間５
  public const string VELGUS_2_TREASURE_13_C = "Treasure";
  public const string VELGUS_2_TREASURE_13_O = "13";
  public const float VELGUS_2_TREASURE_13_X = 22.0f;
  public const float VELGUS_2_TREASURE_13_Y = 1.0f;
  public const float VELGUS_2_TREASURE_13_Z = -6.0f;

  // ランダムの間１
  public const string VELGUS_2_TREASURE_14_C = "Treasure";
  public const string VELGUS_2_TREASURE_14_O = "14";
  public const float VELGUS_2_TREASURE_14_X = 43.0f;
  public const float VELGUS_2_TREASURE_14_Y = 1.0f;
  public const float VELGUS_2_TREASURE_14_Z = -2.0f;

  // ランダムの間２
  public const string VELGUS_2_TREASURE_15_C = "Treasure";
  public const string VELGUS_2_TREASURE_15_O = "15";
  public const float VELGUS_2_TREASURE_15_X = 47.0f;
  public const float VELGUS_2_TREASURE_15_Y = 1.0f;
  public const float VELGUS_2_TREASURE_15_Z = -2.0f;

  // 不規則の間
  public const string VELGUS_2_TREASURE_16_C = "Treasure";
  public const string VELGUS_2_TREASURE_16_O = "16";
  public const float VELGUS_2_TREASURE_16_X = 47.0f;
  public const float VELGUS_2_TREASURE_16_Y = 1.0f;
  public const float VELGUS_2_TREASURE_16_Z = -24.0f;

  #endregion
  #region "第三階層"
  public const string VELGUS_3_TREASURE_1_C = "Treasure";
  public const string VELGUS_3_TREASURE_1_O = "1";
  public const float VELGUS_3_TREASURE_1_X = 9.0f;
  public const float VELGUS_3_TREASURE_1_Y = 1.0f;
  public const float VELGUS_3_TREASURE_1_Z = -28.0f;

  public const string VELGUS_3_TREASURE_2_C = "Treasure";
  public const string VELGUS_3_TREASURE_2_O = "2";
  public const float VELGUS_3_TREASURE_2_X = 7.0f;
  public const float VELGUS_3_TREASURE_2_Y = 1.0f;
  public const float VELGUS_3_TREASURE_2_Z = -12.0f;

  public const string VELGUS_3_TREASURE_3_C = "Treasure";
  public const string VELGUS_3_TREASURE_3_O = "3";
  public const float VELGUS_3_TREASURE_3_X = 2.0f;
  public const float VELGUS_3_TREASURE_3_Y = 1.0f;
  public const float VELGUS_3_TREASURE_3_Z = -23.0f;

  public const string VELGUS_3_TREASURE_4_C = "Treasure";
  public const string VELGUS_3_TREASURE_4_O = "4";
  public const float VELGUS_3_TREASURE_4_X = 18.0f;
  public const float VELGUS_3_TREASURE_4_Y = 1.0f;
  public const float VELGUS_3_TREASURE_4_Z = -2.0f;

  public const string VELGUS_3_TREASURE_5_C = "Treasure";
  public const string VELGUS_3_TREASURE_5_O = "5";
  public const float VELGUS_3_TREASURE_5_X = 26.0f;
  public const float VELGUS_3_TREASURE_5_Y = 1.0f;
  public const float VELGUS_3_TREASURE_5_Z = -12.0f;

  public const string VELGUS_3_TREASURE_6_C = "Treasure";
  public const string VELGUS_3_TREASURE_6_O = "6";
  public const float VELGUS_3_TREASURE_6_X = 35.0f;
  public const float VELGUS_3_TREASURE_6_Y = 1.0f;
  public const float VELGUS_3_TREASURE_6_Z = -10.0f;

  public const string VELGUS_3_TREASURE_7_C = "Treasure";
  public const string VELGUS_3_TREASURE_7_O = "7";
  public const float VELGUS_3_TREASURE_7_X = 45.0f;
  public const float VELGUS_3_TREASURE_7_Y = 1.0f;
  public const float VELGUS_3_TREASURE_7_Z = -14.0f;

  public const string VELGUS_3_TREASURE_8_C = "Treasure";
  public const string VELGUS_3_TREASURE_8_O = "8";
  public const float VELGUS_3_TREASURE_8_X = 35.0f;
  public const float VELGUS_3_TREASURE_8_Y = 1.0f;
  public const float VELGUS_3_TREASURE_8_Z = -23.0f;

  public const string VELGUS_3_TREASURE_9_C = "Treasure";
  public const string VELGUS_3_TREASURE_9_O = "9";
  public const float VELGUS_3_TREASURE_9_X = 48.0f;
  public const float VELGUS_3_TREASURE_9_Y = 1.0f;
  public const float VELGUS_3_TREASURE_9_Z = -18.0f;

  public const string VELGUS_3_TREASURE_10_C = "Treasure";
  public const string VELGUS_3_TREASURE_10_O = "10";
  public const float VELGUS_3_TREASURE_10_X = 35.0f;
  public const float VELGUS_3_TREASURE_10_Y = 1.0f;
  public const float VELGUS_3_TREASURE_10_Z = -25.0f;

  public const string VELGUS_3_TREASURE_11_C = "Treasure";
  public const string VELGUS_3_TREASURE_11_O = "11";
  public const float VELGUS_3_TREASURE_11_X = 19.0f;
  public const float VELGUS_3_TREASURE_11_Y = 1.0f;
  public const float VELGUS_3_TREASURE_11_Z = -19.0f;

  #endregion
  #endregion
  #region "回復の泉"
  public const string VELGUS_FOUNTAIN_1_C = "Fountain";
  public const string VELGUS_FOUNTAIN_1_O = "1";
  public const float VELGUS_FOUNTAIN_1_X = 16.0f;
  public const float VELGUS_FOUNTAIN_1_Y = 1.0f;
  public const float VELGUS_FOUNTAIN_1_Z = -12.0f;

  public const string VELGUS_FOUNTAIN_2_C = "Fountain";
  public const string VELGUS_FOUNTAIN_2_O = "2";
  public const float VELGUS_FOUNTAIN_2_X = 5.0f;
  public const float VELGUS_FOUNTAIN_2_Y = 1.0f;
  public const float VELGUS_FOUNTAIN_2_Z = -6.0f;

  public const string VELGUS_FOUNTAIN_3_C = "Fountain";
  public const string VELGUS_FOUNTAIN_3_O = "3";
  public const float VELGUS_FOUNTAIN_3_X = 9.0f;
  public const float VELGUS_FOUNTAIN_3_Y = 1.0f;
  public const float VELGUS_FOUNTAIN_3_Z = -27.0f;

  public const string VELGUS_FOUNTAIN_4_C = "Fountain";
  public const string VELGUS_FOUNTAIN_4_O = "4";
  public const float VELGUS_FOUNTAIN_4_X = 2.0f;
  public const float VELGUS_FOUNTAIN_4_Y = 1.0f;
  public const float VELGUS_FOUNTAIN_4_Z = -2.0f;

  public const string VELGUS_FOUNTAIN_5_C = "Fountain";
  public const string VELGUS_FOUNTAIN_5_O = "5";
  public const float VELGUS_FOUNTAIN_5_X = 30.0f;
  public const float VELGUS_FOUNTAIN_5_Y = 1.0f;
  public const float VELGUS_FOUNTAIN_5_Z = -2.0f;

  public const string VELGUS_FOUNTAIN_6_C = "Fountain";
  public const string VELGUS_FOUNTAIN_6_O = "6";
  public const float VELGUS_FOUNTAIN_6_X = 48.0f;
  public const float VELGUS_FOUNTAIN_6_Y = 1.0f;
  public const float VELGUS_FOUNTAIN_6_Z = -8.0f;

  public const string VELGUS_FOUNTAIN_7_C = "Fountain";
  public const string VELGUS_FOUNTAIN_7_O = "7";
  public const float VELGUS_FOUNTAIN_7_X = 38.0f;
  public const float VELGUS_FOUNTAIN_7_Y = 1.0f;
  public const float VELGUS_FOUNTAIN_7_Z = -15.0f;

  public const string VELGUS_FOUNTAIN_8_C = "Fountain";
  public const string VELGUS_FOUNTAIN_8_O = "8";
  public const float VELGUS_FOUNTAIN_8_X = 20.0f;
  public const float VELGUS_FOUNTAIN_8_Y = 1.0f;
  public const float VELGUS_FOUNTAIN_8_Z = -8.0f;

  public const string VELGUS_FOUNTAIN_9_C = "Fountain";
  public const string VELGUS_FOUNTAIN_9_O = "9";
  public const float VELGUS_FOUNTAIN_9_X = 30.0f;
  public const float VELGUS_FOUNTAIN_9_Y = 1.0f;
  public const float VELGUS_FOUNTAIN_9_Z = -25.0f;
  #endregion
  #region "ObsidianPortal"
  // Odsidian Portal
  public const string VELGUS_ObsidianPortal_1_C = "ObsidianPortal";
  public const string VELGUS_ObsidianPortal_1_O = "1";
  public const float VELGUS_ObsidianPortal_1_X = -999.0f; // todo
  public const float VELGUS_ObsidianPortal_1_Y = -999.0f; // todo
  public const float VELGUS_ObsidianPortal_1_Z = -999.0f; // todo
  #endregion

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
  #region "エデルガイゼン城"
  #region "1F"
  #region "ワープ鏡"
  // ワープ鏡１
  public const string EDELGARZEN_1_MIRROR_1_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_1_O = "1";
  public const float EDELGARZEN_1_MIRROR_1_X = 12.0f;
  public const float EDELGARZEN_1_MIRROR_1_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_1_Z = -4.0f;

  // ワープ鏡１Ｂ
  public const string EDELGARZEN_1_MIRROR_1B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_1B_O = "1B";
  public const float EDELGARZEN_1_MIRROR_1B_X = 16.0f;
  public const float EDELGARZEN_1_MIRROR_1B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_1B_Z = -37.0f;

  // ワープ鏡２
  public const string EDELGARZEN_1_MIRROR_2_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_2_O = "2";
  public const float EDELGARZEN_1_MIRROR_2_X = 8.0f;
  public const float EDELGARZEN_1_MIRROR_2_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_2_Z = -5.0f;

  // ワープ鏡２Ｂ
  public const string EDELGARZEN_1_MIRROR_2B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_2B_O = "2B";
  public const float EDELGARZEN_1_MIRROR_2B_X = 50.0f;
  public const float EDELGARZEN_1_MIRROR_2B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_2B_Z = -20.0f;

  // ワープ鏡３
  public const string EDELGARZEN_1_MIRROR_3_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_3_O = "3";
  public const float EDELGARZEN_1_MIRROR_3_X = 55.0f;
  public const float EDELGARZEN_1_MIRROR_3_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_3_Z = -22.0f;

  // ワープ鏡３Ｂ
  public const string EDELGARZEN_1_MIRROR_3B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_3B_O = "3B";
  public const float EDELGARZEN_1_MIRROR_3B_X = 55.0f;
  public const float EDELGARZEN_1_MIRROR_3B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_3B_Z = -13.0f;

  // ワープ鏡４
  public const string EDELGARZEN_1_MIRROR_4_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_4_O = "4";
  public const float EDELGARZEN_1_MIRROR_4_X = 54.0f;
  public const float EDELGARZEN_1_MIRROR_4_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_4_Z = -25.0f;

  // ワープ鏡４Ｂ
  public const string EDELGARZEN_1_MIRROR_4B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_4B_O = "4B";
  public const float EDELGARZEN_1_MIRROR_4B_X = 44.0f;
  public const float EDELGARZEN_1_MIRROR_4B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_4B_Z = -3.0f;

  // ワープ鏡５
  public const string EDELGARZEN_1_MIRROR_5_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_5_O = "5";
  public const float EDELGARZEN_1_MIRROR_5_X = 48.0f;
  public const float EDELGARZEN_1_MIRROR_5_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_5_Z = -6.0f;

  // ワープ鏡５Ｂ
  public const string EDELGARZEN_1_MIRROR_5B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_5B_O = "5B";
  public const float EDELGARZEN_1_MIRROR_5B_X = 44.0f;
  public const float EDELGARZEN_1_MIRROR_5B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_5B_Z = -17.0f;

  // ワープ鏡６
  public const string EDELGARZEN_1_MIRROR_6_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_6_O = "6";
  public const float EDELGARZEN_1_MIRROR_6_X = 44.0f;
  public const float EDELGARZEN_1_MIRROR_6_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_6_Z = -8.0f;

  // ワープ鏡６Ｂ
  public const string EDELGARZEN_1_MIRROR_6B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_6B_O = "6B";
  public const float EDELGARZEN_1_MIRROR_6B_X = 48.0f;
  public const float EDELGARZEN_1_MIRROR_6B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_6B_Z = -25.0f;

  // ワープ鏡７
  public const string EDELGARZEN_1_MIRROR_7_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_7_O = "7";
  public const float EDELGARZEN_1_MIRROR_7_X = 48.0f;
  public const float EDELGARZEN_1_MIRROR_7_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_7_Z = -10.0f;

  // ワープ鏡７Ｂ
  public const string EDELGARZEN_1_MIRROR_7B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_7B_O = "7B";
  public const float EDELGARZEN_1_MIRROR_7B_X = 48.0f;
  public const float EDELGARZEN_1_MIRROR_7B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_7B_Z = -31.0f;

  // ワープ鏡８
  public const string EDELGARZEN_1_MIRROR_8_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_8_O = "8";
  public const float EDELGARZEN_1_MIRROR_8_X = 48.0f;
  public const float EDELGARZEN_1_MIRROR_8_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_8_Z = -29.0f;

  // ワープ鏡８Ｂ
  public const string EDELGARZEN_1_MIRROR_8B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_8B_O = "8B";
  public const float EDELGARZEN_1_MIRROR_8B_X = 42.0f;
  public const float EDELGARZEN_1_MIRROR_8B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_8B_Z = -31.0f;

  // ワープ鏡９
  public const string EDELGARZEN_1_MIRROR_9_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_9_O = "9";
  public const float EDELGARZEN_1_MIRROR_9_X = 48.0f;
  public const float EDELGARZEN_1_MIRROR_9_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_9_Z = -35.0f;

  // ワープ鏡９Ｂ
  public const string EDELGARZEN_1_MIRROR_9B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_9B_O = "9B";
  public const float EDELGARZEN_1_MIRROR_9B_X = 38.0f;
  public const float EDELGARZEN_1_MIRROR_9B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_9B_Z = -25.0f;

  // ワープ鏡１０
  public const string EDELGARZEN_1_MIRROR_10_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_10_O = "10";
  public const float EDELGARZEN_1_MIRROR_10_X = 43.0f;
  public const float EDELGARZEN_1_MIRROR_10_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_10_Z = -23.0f;

  // ワープ鏡１０Ｂ
  public const string EDELGARZEN_1_MIRROR_10B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_10B_O = "10B";
  public const float EDELGARZEN_1_MIRROR_10B_X = 43.0f;
  public const float EDELGARZEN_1_MIRROR_10B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_10B_Z = -21.0f;

  // ワープ鏡１１
  public const string EDELGARZEN_1_MIRROR_11_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_11_O = "11";
  public const float EDELGARZEN_1_MIRROR_11_X = 43.0f;
  public const float EDELGARZEN_1_MIRROR_11_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_11_Z = -27.0f;

  // ワープ鏡１１Ｂ
  public const string EDELGARZEN_1_MIRROR_11B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_11B_O = "11B";
  public const float EDELGARZEN_1_MIRROR_11B_X = 22.0f;
  public const float EDELGARZEN_1_MIRROR_11B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_11B_Z = -33.0f;

  // ワープ鏡１２
  public const string EDELGARZEN_1_MIRROR_12_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_12_O = "12";
  public const float EDELGARZEN_1_MIRROR_12_X = 37.0f;
  public const float EDELGARZEN_1_MIRROR_12_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_12_Z = -29.0f;

  // ワープ鏡１２Ｂ
  public const string EDELGARZEN_1_MIRROR_12B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_12B_O = "12B";
  public const float EDELGARZEN_1_MIRROR_12B_X = 37.0f;
  public const float EDELGARZEN_1_MIRROR_12B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_12B_Z = -35.0f;

  // ワープ鏡１３
  public const string EDELGARZEN_1_MIRROR_13_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_13_O = "13";
  public const float EDELGARZEN_1_MIRROR_13_X = 37.0f;
  public const float EDELGARZEN_1_MIRROR_13_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_13_Z = -33.0f;

  // ワープ鏡１３Ｂ
  public const string EDELGARZEN_1_MIRROR_13B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_13B_O = "13B";
  public const float EDELGARZEN_1_MIRROR_13B_X = 38.0f;
  public const float EDELGARZEN_1_MIRROR_13B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_13B_Z = -17.0f;

  // ワープ鏡１４
  public const string EDELGARZEN_1_MIRROR_14_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_14_O = "14";
  public const float EDELGARZEN_1_MIRROR_14_X = 35.0f;
  public const float EDELGARZEN_1_MIRROR_14_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_14_Z = -21.0f;

  // ワープ鏡１４Ｂ
  public const string EDELGARZEN_1_MIRROR_14B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_14B_O = "14B";
  public const float EDELGARZEN_1_MIRROR_14B_X = 14.0f;
  public const float EDELGARZEN_1_MIRROR_14B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_14B_Z = -4.0f;

  // ワープ鏡１５
  public const string EDELGARZEN_1_MIRROR_15_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_15_O = "15";
  public const float EDELGARZEN_1_MIRROR_15_X = 43.0f;
  public const float EDELGARZEN_1_MIRROR_15_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_15_Z = -35.0f;

  // ワープ鏡１５Ｂ
  public const string EDELGARZEN_1_MIRROR_15B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_15B_O = "15B";
  public const float EDELGARZEN_1_MIRROR_15B_X = 38.0f;
  public const float EDELGARZEN_1_MIRROR_15B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_15B_Z = -5.0f;

  // ワープ鏡１６
  public const string EDELGARZEN_1_MIRROR_16_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_16_O = "16";
  public const float EDELGARZEN_1_MIRROR_16_X = 42.0f;
  public const float EDELGARZEN_1_MIRROR_16_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_16_Z = -11.0f;

  // ワープ鏡１６Ｂ
  public const string EDELGARZEN_1_MIRROR_16B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_16B_O = "16B";
  public const float EDELGARZEN_1_MIRROR_16B_X = 43.0f;
  public const float EDELGARZEN_1_MIRROR_16B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_16B_Z = -19.0f;

  // ワープ鏡１７
  public const string EDELGARZEN_1_MIRROR_17_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_17_O = "17";
  public const float EDELGARZEN_1_MIRROR_17_X = 52.0f;
  public const float EDELGARZEN_1_MIRROR_17_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_17_Z = -5.0f;

  // ワープ鏡１７Ｂ
  public const string EDELGARZEN_1_MIRROR_17B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_17B_O = "17B";
  public const float EDELGARZEN_1_MIRROR_17B_X = 44.0f;
  public const float EDELGARZEN_1_MIRROR_17B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_17B_Z = -37.0f;

  // ワープ鏡１８
  public const string EDELGARZEN_1_MIRROR_18_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_18_O = "18";
  public const float EDELGARZEN_1_MIRROR_18_X = 33.0f;
  public const float EDELGARZEN_1_MIRROR_18_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_18_Z = -2.0f;

  // ワープ鏡１８Ｂ
  public const string EDELGARZEN_1_MIRROR_18B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_18B_O = "18B";
  public const float EDELGARZEN_1_MIRROR_18B_X = 17.0f;
  public const float EDELGARZEN_1_MIRROR_18B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_18B_Z = -15.0f;

  // ワープ鏡１９
  public const string EDELGARZEN_1_MIRROR_19_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_19_O = "19";
  public const float EDELGARZEN_1_MIRROR_19_X = 16.0f;
  public const float EDELGARZEN_1_MIRROR_19_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_19_Z = -10.0f;

  // ワープ鏡１９Ｂ
  public const string EDELGARZEN_1_MIRROR_19B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_19B_O = "19B";
  public const float EDELGARZEN_1_MIRROR_19B_X = 6.0f;
  public const float EDELGARZEN_1_MIRROR_19B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_19B_Z = -26.0f;

  // ワープ鏡２０
  public const string EDELGARZEN_1_MIRROR_20_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_20_O = "20";
  public const float EDELGARZEN_1_MIRROR_20_X = 20.0f;
  public const float EDELGARZEN_1_MIRROR_20_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_20_Z = -5.0f;

  // ワープ鏡２０Ｂ
  public const string EDELGARZEN_1_MIRROR_20B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_20B_O = "20B";
  public const float EDELGARZEN_1_MIRROR_20B_X = 10.0f;
  public const float EDELGARZEN_1_MIRROR_20B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_20B_Z = -26.0f;

  // ワープ鏡２１
  public const string EDELGARZEN_1_MIRROR_21_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_21_O = "21";
  public const float EDELGARZEN_1_MIRROR_21_X = 11.0f;
  public const float EDELGARZEN_1_MIRROR_21_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_21_Z = -21.0f;

  // ワープ鏡２１Ｂ
  public const string EDELGARZEN_1_MIRROR_21B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_21B_O = "21B";
  public const float EDELGARZEN_1_MIRROR_21B_X = 12.0f;
  public const float EDELGARZEN_1_MIRROR_21B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_21B_Z = -35.0f;

  // ワープ鏡２２
  public const string EDELGARZEN_1_MIRROR_22_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_22_O = "22";
  public const float EDELGARZEN_1_MIRROR_22_X = 7.0f;
  public const float EDELGARZEN_1_MIRROR_22_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_22_Z = -21.0f;

  // ワープ鏡２２Ｂ
  public const string EDELGARZEN_1_MIRROR_22B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_22B_O = "22B";
  public const float EDELGARZEN_1_MIRROR_22B_X = 13.0f;
  public const float EDELGARZEN_1_MIRROR_22B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_22B_Z = -22.0f;

  // ワープ鏡２３
  public const string EDELGARZEN_1_MIRROR_23_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_23_O = "23";
  public const float EDELGARZEN_1_MIRROR_23_X = 9.0f;
  public const float EDELGARZEN_1_MIRROR_23_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_23_Z = -21.0f;

  // ワープ鏡２３Ｂ
  public const string EDELGARZEN_1_MIRROR_23B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_23B_O = "23B";
  public const float EDELGARZEN_1_MIRROR_23B_X = 23.0f;
  public const float EDELGARZEN_1_MIRROR_23B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_23B_Z = -27.0f;

  // ワープ鏡２４
  public const string EDELGARZEN_1_MIRROR_24_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_24_O = "24";
  public const float EDELGARZEN_1_MIRROR_24_X = 5.0f;
  public const float EDELGARZEN_1_MIRROR_24_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_24_Z = -21.0f;

  // ワープ鏡２４Ｂ
  public const string EDELGARZEN_1_MIRROR_24B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_24B_O = "24B";
  public const float EDELGARZEN_1_MIRROR_24B_X = 17.0f;
  public const float EDELGARZEN_1_MIRROR_24B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_24B_Z = -27.0f;

  // ワープ鏡２５
  public const string EDELGARZEN_1_MIRROR_25_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_25_O = "25";
  public const float EDELGARZEN_1_MIRROR_25_X = 27.0f;
  public const float EDELGARZEN_1_MIRROR_25_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_25_Z = -19.0f;

  // ワープ鏡２５Ｂ
  public const string EDELGARZEN_1_MIRROR_25B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_25B_O = "25B";
  public const float EDELGARZEN_1_MIRROR_25B_X = 6.0f;
  public const float EDELGARZEN_1_MIRROR_25B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_25B_Z = -14.0f;

  // ワープ鏡２６
  public const string EDELGARZEN_1_MIRROR_26_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_26_O = "26";
  public const float EDELGARZEN_1_MIRROR_26_X = 22.0f;
  public const float EDELGARZEN_1_MIRROR_26_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_26_Z = -5.0f;

  // ワープ鏡２６Ｂ
  public const string EDELGARZEN_1_MIRROR_26B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_26B_O = "26B";
  public const float EDELGARZEN_1_MIRROR_26B_X = 6.0f;
  public const float EDELGARZEN_1_MIRROR_26B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_26B_Z = -18.0f;

  // ワープ鏡２７
  public const string EDELGARZEN_1_MIRROR_27_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_27_O = "27";
  public const float EDELGARZEN_1_MIRROR_27_X = 24.0f;
  public const float EDELGARZEN_1_MIRROR_27_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_27_Z = -5.0f;

  // ワープ鏡２７Ｂ
  public const string EDELGARZEN_1_MIRROR_27B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_27B_O = "27B";
  public const float EDELGARZEN_1_MIRROR_27B_X = 6.0f;
  public const float EDELGARZEN_1_MIRROR_27B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_27B_Z = -31.0f;

  // ワープ鏡２８
  public const string EDELGARZEN_1_MIRROR_28_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_28_O = "28";
  public const float EDELGARZEN_1_MIRROR_28_X = 36.0f;
  public const float EDELGARZEN_1_MIRROR_28_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_28_Z = -5.0f;

  // ワープ鏡２８Ｂ
  public const string EDELGARZEN_1_MIRROR_28B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_28B_O = "28B";
  public const float EDELGARZEN_1_MIRROR_28B_X = 54.0f;
  public const float EDELGARZEN_1_MIRROR_28B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_28B_Z = -31.0f;

  // ワープ鏡２９
  public const string EDELGARZEN_1_MIRROR_29_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_29_O = "29";
  public const float EDELGARZEN_1_MIRROR_29_X = 57.0f;
  public const float EDELGARZEN_1_MIRROR_29_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_29_Z = -22.0f;

  // ワープ鏡２９Ｂ
  public const string EDELGARZEN_1_MIRROR_29B_C = "Mirror";
  public const string EDELGARZEN_1_MIRROR_29B_O = "29B";
  public const float EDELGARZEN_1_MIRROR_29B_X = 18.0f;
  public const float EDELGARZEN_1_MIRROR_29B_Y = 0.5f;
  public const float EDELGARZEN_1_MIRROR_29B_Z = -34.0f;

  #endregion
  #region "Treasure"
  public const string EDELGARZEN_1_Treasure_1_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_1_O = "1";
  public const float EDELGARZEN_1_Treasure_1_X = 27.0f;
  public const float EDELGARZEN_1_Treasure_1_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_1_Z = -39.0f;

  public const string EDELGARZEN_1_Treasure_2_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_2_O = "2";
  public const float EDELGARZEN_1_Treasure_2_X = 4.0f;
  public const float EDELGARZEN_1_Treasure_2_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_2_Z = -9.0f;

  public const string EDELGARZEN_1_Treasure_3_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_3_O = "3";
  public const float EDELGARZEN_1_Treasure_3_X = 56.0f;
  public const float EDELGARZEN_1_Treasure_3_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_3_Z = -17.0f;

  public const string EDELGARZEN_1_Treasure_4_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_4_O = "4";
  public const float EDELGARZEN_1_Treasure_4_X = 45.0f;
  public const float EDELGARZEN_1_Treasure_4_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_4_Z = -35.0f;

  public const string EDELGARZEN_1_Treasure_5_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_5_O = "5";
  public const float EDELGARZEN_1_Treasure_5_X = 47.0f;
  public const float EDELGARZEN_1_Treasure_5_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_5_Z = -15.0f;

  public const string EDELGARZEN_1_Treasure_6_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_6_O = "6";
  public const float EDELGARZEN_1_Treasure_6_X = 38.0f;
  public const float EDELGARZEN_1_Treasure_6_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_6_Z = -13.0f;

  public const string EDELGARZEN_1_Treasure_7_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_7_O = "7";
  public const float EDELGARZEN_1_Treasure_7_X = 38.0f;
  public const float EDELGARZEN_1_Treasure_7_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_7_Z = -11.0f;

  public const string EDELGARZEN_1_Treasure_8_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_8_O = "8";
  public const float EDELGARZEN_1_Treasure_8_X = 31.0f;
  public const float EDELGARZEN_1_Treasure_8_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_8_Z = -2.0f;

  public const string EDELGARZEN_1_Treasure_9_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_9_O = "9";
  public const float EDELGARZEN_1_Treasure_9_X = 22.0f;
  public const float EDELGARZEN_1_Treasure_9_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_9_Z = -35.0f;

  public const string EDELGARZEN_1_Treasure_10_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_10_O = "10";
  public const float EDELGARZEN_1_Treasure_10_X = 56.0f;
  public const float EDELGARZEN_1_Treasure_10_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_10_Z = -9.0f;

  public const string EDELGARZEN_1_Treasure_11_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_11_O = "11";
  public const float EDELGARZEN_1_Treasure_11_X = 57.0f;
  public const float EDELGARZEN_1_Treasure_11_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_11_Z = -20.0f;

  public const string EDELGARZEN_1_Treasure_12_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_12_O = "12";
  public const float EDELGARZEN_1_Treasure_12_X = 24.0f;
  public const float EDELGARZEN_1_Treasure_12_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_12_Z = -22.0f;

  public const string EDELGARZEN_1_Treasure_13_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_13_O = "13";
  public const float EDELGARZEN_1_Treasure_13_X = 16.0f;
  public const float EDELGARZEN_1_Treasure_13_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_13_Z = -7.0f;

  public const string EDELGARZEN_1_Treasure_14_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_14_O = "14";
  public const float EDELGARZEN_1_Treasure_14_X = 14.0f;
  public const float EDELGARZEN_1_Treasure_14_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_14_Z = -35.0f;

  public const string EDELGARZEN_1_Treasure_15_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_15_O = "15";
  public const float EDELGARZEN_1_Treasure_15_X = 10.0f;
  public const float EDELGARZEN_1_Treasure_15_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_15_Z = -14.0f;

  public const string EDELGARZEN_1_Treasure_16_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_16_O = "16";
  public const float EDELGARZEN_1_Treasure_16_X = 26.0f;
  public const float EDELGARZEN_1_Treasure_16_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_16_Z = -11.0f;

  public const string EDELGARZEN_1_Treasure_17_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_17_O = "17";
  public const float EDELGARZEN_1_Treasure_17_X = 35.0f;
  public const float EDELGARZEN_1_Treasure_17_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_17_Z = -15.0f;

  public const string EDELGARZEN_1_Treasure_18_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_18_O = "18";
  public const float EDELGARZEN_1_Treasure_18_X = 8.0f;
  public const float EDELGARZEN_1_Treasure_18_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_18_Z = -35.0f;

  public const string EDELGARZEN_1_Treasure_19_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_19_O = "19";
  public const float EDELGARZEN_1_Treasure_19_X = 52.0f;
  public const float EDELGARZEN_1_Treasure_19_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_19_Z = -35.0f;

  public const string EDELGARZEN_1_Treasure_20_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_20_O = "20";
  public const float EDELGARZEN_1_Treasure_20_X = 33.0f;
  public const float EDELGARZEN_1_Treasure_20_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_20_Z = -39.0f;

  public const string EDELGARZEN_1_Treasure_21_C = "Treasure";
  public const string EDELGARZEN_1_Treasure_21_O = "21";
  public const float EDELGARZEN_1_Treasure_21_X = 20.0f;
  public const float EDELGARZEN_1_Treasure_21_Y = 1.0f;
  public const float EDELGARZEN_1_Treasure_21_Z = -35.0f;
  #endregion
  #region "Edelgarzen_Door"
  public const string EDELGARZEN_1_DOOR_1_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_1_O = "1";
  public const float EDELGARZEN_1_DOOR_1_X = 6.0f;
  public const float EDELGARZEN_1_DOOR_1_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_1_Z = -36.0f;

  public const string EDELGARZEN_1_DOOR_2_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_2_O = "2";
  public const float EDELGARZEN_1_DOOR_2_X = 6.0f;
  public const float EDELGARZEN_1_DOOR_2_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_2_Z = -4.0f;

  public const string EDELGARZEN_1_DOOR_3_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_3_O = "3";
  public const float EDELGARZEN_1_DOOR_3_X = 54.0f;
  public const float EDELGARZEN_1_DOOR_3_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_3_Z = -4.0f;

  public const string EDELGARZEN_1_DOOR_4_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_4_O = "4";
  public const float EDELGARZEN_1_DOOR_4_X = 54.0f;
  public const float EDELGARZEN_1_DOOR_4_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_4_Z = -36.0f;

  public const string EDELGARZEN_1_DOOR_5_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_5_O = "5";
  public const float EDELGARZEN_1_DOOR_5_X = 24.0f;
  public const float EDELGARZEN_1_DOOR_5_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_5_Z = -37.0f;

  public const string EDELGARZEN_1_DOOR_6_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_6_O = "6";
  public const float EDELGARZEN_1_DOOR_6_X = 29.0f;
  public const float EDELGARZEN_1_DOOR_6_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_6_Z = -20.0f;

  public const string EDELGARZEN_1_DOOR_7_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_7_O = "7";
  public const float EDELGARZEN_1_DOOR_7_X = 48.0f;
  public const float EDELGARZEN_1_DOOR_7_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_7_Z = -20.0f;

  public const string EDELGARZEN_1_DOOR_8_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_8_O = "8";
  public const float EDELGARZEN_1_DOOR_8_X = 50.0f;
  public const float EDELGARZEN_1_DOOR_8_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_8_Z = -24.0f;

  public const string EDELGARZEN_1_DOOR_9_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_9_O = "9";
  public const float EDELGARZEN_1_DOOR_9_X = 54.0f;
  public const float EDELGARZEN_1_DOOR_9_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_9_Z = -20.0f;

  public const string EDELGARZEN_1_DOOR_10_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_10_O = "10";
  public const float EDELGARZEN_1_DOOR_10_X = 48.0f;
  public const float EDELGARZEN_1_DOOR_10_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_10_Z = -12.0f;

  public const string EDELGARZEN_1_DOOR_11_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_11_O = "11";
  public const float EDELGARZEN_1_DOOR_11_X = 50.0f;
  public const float EDELGARZEN_1_DOOR_11_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_11_Z = -16.0f;

  public const string EDELGARZEN_1_DOOR_12_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_12_O = "12";
  public const float EDELGARZEN_1_DOOR_12_X = 46.0f;
  public const float EDELGARZEN_1_DOOR_12_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_12_Z = -13.0f;

  public const string EDELGARZEN_1_DOOR_13_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_13_O = "13";
  public const float EDELGARZEN_1_DOOR_13_X = 45.0f;
  public const float EDELGARZEN_1_DOOR_13_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_13_Z = -18.0f;

  public const string EDELGARZEN_1_DOOR_14_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_14_O = "14";
  public const float EDELGARZEN_1_DOOR_14_X = 46.0f;
  public const float EDELGARZEN_1_DOOR_14_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_14_Z = -20.0f;

  public const string EDELGARZEN_1_DOOR_15_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_15_O = "15";
  public const float EDELGARZEN_1_DOOR_15_X = 46.0f;
  public const float EDELGARZEN_1_DOOR_15_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_15_Z = -27.0f;

  public const string EDELGARZEN_1_DOOR_16_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_16_O = "16";
  public const float EDELGARZEN_1_DOOR_16_X = 46.0f;
  public const float EDELGARZEN_1_DOOR_16_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_16_Z = -33.0f;

  public const string EDELGARZEN_1_DOOR_17_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_17_O = "17";
  public const float EDELGARZEN_1_DOOR_17_X = 44.0f;
  public const float EDELGARZEN_1_DOOR_17_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_17_Z = -31.0f;

  public const string EDELGARZEN_1_DOOR_18_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_18_O = "18";
  public const float EDELGARZEN_1_DOOR_18_X = 40.0f;
  public const float EDELGARZEN_1_DOOR_18_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_18_Z = -31.0f;

  public const string EDELGARZEN_1_DOOR_19_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_19_O = "19";
  public const float EDELGARZEN_1_DOOR_19_X = 36.0f;
  public const float EDELGARZEN_1_DOOR_19_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_19_Z = -31.0f;

  public const string EDELGARZEN_1_DOOR_20_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_20_O = "20";
  public const float EDELGARZEN_1_DOOR_20_X = 36.0f;
  public const float EDELGARZEN_1_DOOR_20_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_20_Z = -25.0f;

  public const string EDELGARZEN_1_DOOR_21_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_21_O = "21";
  public const float EDELGARZEN_1_DOOR_21_X = 40.0f;
  public const float EDELGARZEN_1_DOOR_21_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_21_Z = -25.0f;

  public const string EDELGARZEN_1_DOOR_22_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_22_O = "22";
  public const float EDELGARZEN_1_DOOR_22_X = 44.0f;
  public const float EDELGARZEN_1_DOOR_22_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_22_Z = -25.0f;

  public const string EDELGARZEN_1_DOOR_23_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_23_O = "23";
  public const float EDELGARZEN_1_DOOR_23_X = 24.0f;
  public const float EDELGARZEN_1_DOOR_23_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_23_Z = -34.0f;

  public const string EDELGARZEN_1_DOOR_24_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_24_O = "24";
  public const float EDELGARZEN_1_DOOR_24_X = 43.0f;
  public const float EDELGARZEN_1_DOOR_24_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_24_Z = -15.0f;

  public const string EDELGARZEN_1_DOOR_25_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_25_O = "25";
  public const float EDELGARZEN_1_DOOR_25_X = 43.0f;
  public const float EDELGARZEN_1_DOOR_25_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_25_Z = -9.0f;

  public const string EDELGARZEN_1_DOOR_26_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_26_O = "26";
  public const float EDELGARZEN_1_DOOR_26_X = 32.0f;
  public const float EDELGARZEN_1_DOOR_26_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_26_Z = -19.0f;

  public const string EDELGARZEN_1_DOOR_27_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_27_O = "27";
  public const float EDELGARZEN_1_DOOR_27_X = 31.0f;
  public const float EDELGARZEN_1_DOOR_27_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_27_Z = -20.0f;

  public const string EDELGARZEN_1_DOOR_28_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_28_O = "28";
  public const float EDELGARZEN_1_DOOR_28_X = 36.0f;
  public const float EDELGARZEN_1_DOOR_28_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_28_Z = -37.0f;

  public const string EDELGARZEN_1_DOOR_29_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_29_O = "29";
  public const float EDELGARZEN_1_DOOR_29_X = 19.0f;
  public const float EDELGARZEN_1_DOOR_29_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_29_Z = -15.0f;

  public const string EDELGARZEN_1_DOOR_30_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_30_O = "30";
  public const float EDELGARZEN_1_DOOR_30_X = 17.0f;
  public const float EDELGARZEN_1_DOOR_30_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_30_Z = -11.0f;

  public const string EDELGARZEN_1_DOOR_31_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_31_O = "31";
  public const float EDELGARZEN_1_DOOR_31_X = 6.0f;
  public const float EDELGARZEN_1_DOOR_31_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_31_Z = -24.0f;

  public const string EDELGARZEN_1_DOOR_32_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_32_O = "32";
  public const float EDELGARZEN_1_DOOR_32_X = 10.0f;
  public const float EDELGARZEN_1_DOOR_32_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_32_Z = -24.0f;

  public const string EDELGARZEN_1_DOOR_33_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_33_O = "33";
  public const float EDELGARZEN_1_DOOR_33_X = 13.0f;
  public const float EDELGARZEN_1_DOOR_33_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_33_Z = -32.0f;

  public const string EDELGARZEN_1_DOOR_34_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_34_O = "34";
  public const float EDELGARZEN_1_DOOR_34_X = 23.0f;
  public const float EDELGARZEN_1_DOOR_34_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_34_Z = -30.0f;

  public const string EDELGARZEN_1_DOOR_35_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_35_O = "35";
  public const float EDELGARZEN_1_DOOR_35_X = 17.0f;
  public const float EDELGARZEN_1_DOOR_35_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_35_Z = -30.0f;

  public const string EDELGARZEN_1_DOOR_36_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_36_O = "36";
  public const float EDELGARZEN_1_DOOR_36_X = 17.0f;
  public const float EDELGARZEN_1_DOOR_36_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_36_Z = -23.0f;

  public const string EDELGARZEN_1_DOOR_37_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_37_O = "37";
  public const float EDELGARZEN_1_DOOR_37_X = 21.0f;
  public const float EDELGARZEN_1_DOOR_37_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_37_Z = -21.0f;

  public const string EDELGARZEN_1_DOOR_38_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_38_O = "38";
  public const float EDELGARZEN_1_DOOR_38_X = 17.0f;
  public const float EDELGARZEN_1_DOOR_38_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_38_Z = -19.0f;

  public const string EDELGARZEN_1_DOOR_39_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_39_O = "39";
  public const float EDELGARZEN_1_DOOR_39_X = 21.0f;
  public const float EDELGARZEN_1_DOOR_39_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_39_Z = -15.0f;

  public const string EDELGARZEN_1_DOOR_40_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_40_O = "40";
  public const float EDELGARZEN_1_DOOR_40_X = 8.0f;
  public const float EDELGARZEN_1_DOOR_40_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_40_Z = -14.0f;

  public const string EDELGARZEN_1_DOOR_41_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_41_O = "41";
  public const float EDELGARZEN_1_DOOR_41_X = 8.0f;
  public const float EDELGARZEN_1_DOOR_41_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_41_Z = -18.0f;

  public const string EDELGARZEN_1_DOOR_42_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_42_O = "42";
  public const float EDELGARZEN_1_DOOR_42_X = 13.0f;
  public const float EDELGARZEN_1_DOOR_42_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_42_Z = -15.0f;

  public const string EDELGARZEN_1_DOOR_43_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_43_O = "43";
  public const float EDELGARZEN_1_DOOR_43_X = 28.0f;
  public const float EDELGARZEN_1_DOOR_43_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_43_Z = -14.0f;

  public const string EDELGARZEN_1_DOOR_44_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_44_O = "44";
  public const float EDELGARZEN_1_DOOR_44_X = 32.0f;
  public const float EDELGARZEN_1_DOOR_44_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_44_Z = -14.0f;

  public const string EDELGARZEN_1_DOOR_45_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_45_O = "45";
  public const float EDELGARZEN_1_DOOR_45_X = 18.0f;
  public const float EDELGARZEN_1_DOOR_45_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_45_Z = -32.0f;

  public const string EDELGARZEN_1_DOOR_46_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_46_O = "46";
  public const float EDELGARZEN_1_DOOR_46_X = 30.0f;
  public const float EDELGARZEN_1_DOOR_46_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_46_Z = -38.0f;

  public const string EDELGARZEN_1_DOOR_47_C = "Edelgarzen_Door";
  public const string EDELGARZEN_1_DOOR_47_O = "47";
  public const float EDELGARZEN_1_DOOR_47_X = 30.0f;
  public const float EDELGARZEN_1_DOOR_47_Y = 0.5f;
  public const float EDELGARZEN_1_DOOR_47_Z = -34.0f;
  #endregion
  #region "階段"
  // 出口階段( 左下 )
  public const string EDELGARZEN_1_DOWNSTAIR_1_C = "Downstair";
  public const string EDELGARZEN_1_DOWNSTAIR_1_O = "1";
  public const float EDELGARZEN_1_DOWNSTAIR_1_X = 6.0f;
  public const float EDELGARZEN_1_DOWNSTAIR_1_Y = 0.0f;
  public const float EDELGARZEN_1_DOWNSTAIR_1_Z = -40.0f;

  // 上り階段（ 中央左 )
  public const string EDELGARZEN_1_UPSTAIR_2_C = "Upstair";
  public const string EDELGARZEN_1_UPSTAIR_2_O = "2";
  public const float EDELGARZEN_1_UPSTAIR_2_X = 29.0f;
  public const float EDELGARZEN_1_UPSTAIR_2_Y = 0.0f;
  public const float EDELGARZEN_1_UPSTAIR_2_Z = -7.0f;

  // 上り階段（ 左上の支え柱 )
  public const string EDELGARZEN_1_UPSTAIR_3_C = "Upstair";
  public const string EDELGARZEN_1_UPSTAIR_3_O = "3";
  public const float EDELGARZEN_1_UPSTAIR_3_X = 6.0f;
  public const float EDELGARZEN_1_UPSTAIR_3_Y = 0.0f;
  public const float EDELGARZEN_1_UPSTAIR_3_Z = -9.0f;

  // 上り階段（ 中央右 )
  public const string EDELGARZEN_1_UPSTAIR_4_C = "Upstair";
  public const string EDELGARZEN_1_UPSTAIR_4_O = "4";
  public const float EDELGARZEN_1_UPSTAIR_4_X = 31.0f;
  public const float EDELGARZEN_1_UPSTAIR_4_Y = 0.0f;
  public const float EDELGARZEN_1_UPSTAIR_4_Z = -7.0f;

  // 上り階段（ 右上の支え柱 )
  public const string EDELGARZEN_1_UPSTAIR_5_C = "Upstair";
  public const string EDELGARZEN_1_UPSTAIR_5_O = "5";
  public const float EDELGARZEN_1_UPSTAIR_5_X = 54.0f;
  public const float EDELGARZEN_1_UPSTAIR_5_Y = 0.0f;
  public const float EDELGARZEN_1_UPSTAIR_5_Z = -9.0f;

  // 上り階段（ 城内の左上 )
  public const string EDELGARZEN_1_UPSTAIR_6_C = "Upstair";
  public const string EDELGARZEN_1_UPSTAIR_6_O = "6";
  public const float EDELGARZEN_1_UPSTAIR_6_X = 13.0f;
  public const float EDELGARZEN_1_UPSTAIR_6_Y = 0.0f;
  public const float EDELGARZEN_1_UPSTAIR_6_Z = -7.0f;

  // 上り階段（ 城内の上部 )
  public const string EDELGARZEN_1_UPSTAIR_7_C = "Upstair";
  public const string EDELGARZEN_1_UPSTAIR_7_O = "7";
  public const float EDELGARZEN_1_UPSTAIR_7_X = 30.0f;
  public const float EDELGARZEN_1_UPSTAIR_7_Y = 0.0f;
  public const float EDELGARZEN_1_UPSTAIR_7_Z = -4.0f;

  // 出口階段( 正面ゲート )
  public const string EDELGARZEN_1_DOWNSTAIR_8_C = "Downstair";
  public const string EDELGARZEN_1_DOWNSTAIR_8_O = "8";
  public const float EDELGARZEN_1_DOWNSTAIR_8_X = 30.0f;
  public const float EDELGARZEN_1_DOWNSTAIR_8_Y = 0.0f;
  public const float EDELGARZEN_1_DOWNSTAIR_8_Z = -40.0f;

  // 上り階段（ 中央部 )
  public const string EDELGARZEN_1_UPSTAIR_9_C = "Upstair";
  public const string EDELGARZEN_1_UPSTAIR_9_O = "9";
  public const float EDELGARZEN_1_UPSTAIR_9_X = 30.0f;
  public const float EDELGARZEN_1_UPSTAIR_9_Y = 0.0f;
  public const float EDELGARZEN_1_UPSTAIR_9_Z = -23.0f;
  #endregion
  #region "Event"
  // ボス戦開始位置
  public const string EDELGARZEN_1_Event_1_C = "Event";
  public const string EDELGARZEN_1_Event_1_O = "1";
  public const float EDELGARZEN_1_Event_1_X = 30.0f;
  public const float EDELGARZEN_1_Event_1_Y = 0.0f;
  public const float EDELGARZEN_1_Event_1_Z = -33.0f;
  #endregion
  #endregion

  #region "2F"
  #region "ワープ鏡"
  // ワープ鏡１
  public const string EDELGARZEN_2_MIRROR_1_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_1_O = "1";
  public const float EDELGARZEN_2_MIRROR_1_X = 13.0f;
  public const float EDELGARZEN_2_MIRROR_1_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_1_Z = -11.0f;

  // ワープ鏡１Ｂ
  public const string EDELGARZEN_2_MIRROR_1B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_1B_O = "1B";
  public const float EDELGARZEN_2_MIRROR_1B_X = 19.0f;
  public const float EDELGARZEN_2_MIRROR_1B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_1B_Z = -14.0f;

  // ワープ鏡２
  public const string EDELGARZEN_2_MIRROR_2_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_2_O = "2";
  public const float EDELGARZEN_2_MIRROR_2_X = 11.0f;
  public const float EDELGARZEN_2_MIRROR_2_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_2_Z = -11.0f;

  // ワープ鏡２Ｂ
  public const string EDELGARZEN_2_MIRROR_2B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_2B_O = "2B";
  public const float EDELGARZEN_2_MIRROR_2B_X = 20.0f;
  public const float EDELGARZEN_2_MIRROR_2B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_2B_Z = -21.0f;

  // ワープ鏡３
  public const string EDELGARZEN_2_MIRROR_3_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_3_O = "3";
  public const float EDELGARZEN_2_MIRROR_3_X = 14.0f;
  public const float EDELGARZEN_2_MIRROR_3_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_3_Z = -19.0f;

  // ワープ鏡３Ｂ
  public const string EDELGARZEN_2_MIRROR_3B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_3B_O = "3B";
  public const float EDELGARZEN_2_MIRROR_3B_X = 10.0f;
  public const float EDELGARZEN_2_MIRROR_3B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_3B_Z = -28.0f;

  // ワープ鏡４
  public const string EDELGARZEN_2_MIRROR_4_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_4_O = "4";
  public const float EDELGARZEN_2_MIRROR_4_X = 14.0f;
  public const float EDELGARZEN_2_MIRROR_4_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_4_Z = -23.0f;

  // ワープ鏡４Ｂ
  public const string EDELGARZEN_2_MIRROR_4B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_4B_O = "4B";
  public const float EDELGARZEN_2_MIRROR_4B_X = 15.0f;
  public const float EDELGARZEN_2_MIRROR_4B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_4B_Z = -32.0f;

  // ワープ鏡５
  public const string EDELGARZEN_2_MIRROR_5_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_5_O = "5";
  public const float EDELGARZEN_2_MIRROR_5_X = 10.0f;
  public const float EDELGARZEN_2_MIRROR_5_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_5_Z = -19.0f;

  // ワープ鏡５Ｂ
  public const string EDELGARZEN_2_MIRROR_5B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_5B_O = "5B";
  public const float EDELGARZEN_2_MIRROR_5B_X = 20.0f;
  public const float EDELGARZEN_2_MIRROR_5B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_5B_Z = -28.0f;

  // ワープ鏡６
  public const string EDELGARZEN_2_MIRROR_6_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_6_O = "6";
  public const float EDELGARZEN_2_MIRROR_6_X = 10.0f;
  public const float EDELGARZEN_2_MIRROR_6_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_6_Z = -23.0f;

  // ワープ鏡６Ｂ
  public const string EDELGARZEN_2_MIRROR_6B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_6B_O = "6B";
  public const float EDELGARZEN_2_MIRROR_6B_X = 19.0f;
  public const float EDELGARZEN_2_MIRROR_6B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_6B_Z = -32.0f;

  // ワープ鏡７
  public const string EDELGARZEN_2_MIRROR_7_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_7_O = "7";
  public const float EDELGARZEN_2_MIRROR_7_X = 14.0f;
  public const float EDELGARZEN_2_MIRROR_7_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_7_Z = -27.0f;

  // ワープ鏡７Ｂ
  public const string EDELGARZEN_2_MIRROR_7B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_7B_O = "7B";
  public const float EDELGARZEN_2_MIRROR_7B_X = 19.0f;
  public const float EDELGARZEN_2_MIRROR_7B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_7B_Z = -10.0f;

  // ワープ鏡８
  public const string EDELGARZEN_2_MIRROR_8_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_8_O = "8";
  public const float EDELGARZEN_2_MIRROR_8_X = 14.0f;
  public const float EDELGARZEN_2_MIRROR_8_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_8_Z = -29.0f;

  // ワープ鏡８Ｂ
  public const string EDELGARZEN_2_MIRROR_8B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_8B_O = "8B";
  public const float EDELGARZEN_2_MIRROR_8B_X = 5.0f;
  public const float EDELGARZEN_2_MIRROR_8B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_8B_Z = -19.0f;

  // ワープ鏡９
  public const string EDELGARZEN_2_MIRROR_9_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_9_O = "9";
  public const float EDELGARZEN_2_MIRROR_9_X = 16.0f;
  public const float EDELGARZEN_2_MIRROR_9_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_9_Z = -27.0f;

  // ワープ鏡９Ｂ
  public const string EDELGARZEN_2_MIRROR_9B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_9B_O = "9B";
  public const float EDELGARZEN_2_MIRROR_9B_X = 5.0f;
  public const float EDELGARZEN_2_MIRROR_9B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_9B_Z = -23.0f;

  // ワープ鏡１０
  public const string EDELGARZEN_2_MIRROR_10_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_10_O = "10";
  public const float EDELGARZEN_2_MIRROR_10_X = 16.0f;
  public const float EDELGARZEN_2_MIRROR_10_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_10_Z = -29.0f;

  // ワープ鏡１０Ｂ
  public const string EDELGARZEN_2_MIRROR_10B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_10B_O = "10B";
  public const float EDELGARZEN_2_MIRROR_10B_X = 5.0f;
  public const float EDELGARZEN_2_MIRROR_10B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_10B_Z = -27.0f;

  // ワープ鏡１１
  public const string EDELGARZEN_2_MIRROR_11_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_11_O = "11";
  public const float EDELGARZEN_2_MIRROR_11_X = 4.0f;
  public const float EDELGARZEN_2_MIRROR_11_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_11_Z = -21.0f;

  // ワープ鏡１１Ｂ
  public const string EDELGARZEN_2_MIRROR_11B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_11B_O = "11B";
  public const float EDELGARZEN_2_MIRROR_11B_X = 16.0f;
  public const float EDELGARZEN_2_MIRROR_11B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_11B_Z = -15.0f;

  // ワープ鏡１２
  public const string EDELGARZEN_2_MIRROR_12_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_12_O = "12";
  public const float EDELGARZEN_2_MIRROR_12_X = 6.0f;
  public const float EDELGARZEN_2_MIRROR_12_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_12_Z = -21.0f;

  // ワープ鏡１２Ｂ
  public const string EDELGARZEN_2_MIRROR_12B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_12B_O = "12B";
  public const float EDELGARZEN_2_MIRROR_12B_X = 16.0f;
  public const float EDELGARZEN_2_MIRROR_12B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_12B_Z = -16.0f;

  // ワープ鏡１３
  public const string EDELGARZEN_2_MIRROR_13_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_13_O = "13";
  public const float EDELGARZEN_2_MIRROR_13_X = 4.0f;
  public const float EDELGARZEN_2_MIRROR_13_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_13_Z = -25.0f;

  // ワープ鏡１３Ｂ
  public const string EDELGARZEN_2_MIRROR_13B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_13B_O = "13B";
  public const float EDELGARZEN_2_MIRROR_13B_X = 15.0f;
  public const float EDELGARZEN_2_MIRROR_13B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_13B_Z = -17.0f;

  // ワープ鏡１４
  public const string EDELGARZEN_2_MIRROR_14_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_14_O = "14";
  public const float EDELGARZEN_2_MIRROR_14_X = 6.0f;
  public const float EDELGARZEN_2_MIRROR_14_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_14_Z = -25.0f;

  // ワープ鏡１４Ｂ
  public const string EDELGARZEN_2_MIRROR_14B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_14B_O = "14B";
  public const float EDELGARZEN_2_MIRROR_14B_X = 14.0f;
  public const float EDELGARZEN_2_MIRROR_14B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_14B_Z = -17.0f;

  // ワープ鏡１５
  public const string EDELGARZEN_2_MIRROR_15_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_15_O = "15";
  public const float EDELGARZEN_2_MIRROR_15_X = 4.0f;
  public const float EDELGARZEN_2_MIRROR_15_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_15_Z = -29.0f;

  // ワープ鏡１５Ｂ
  public const string EDELGARZEN_2_MIRROR_15B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_15B_O = "15B";
  public const float EDELGARZEN_2_MIRROR_15B_X = 7.0f;
  public const float EDELGARZEN_2_MIRROR_15B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_15B_Z = -13.0f;

  // ワープ鏡１６
  public const string EDELGARZEN_2_MIRROR_16_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_16_O = "16";
  public const float EDELGARZEN_2_MIRROR_16_X = 6.0f;
  public const float EDELGARZEN_2_MIRROR_16_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_16_Z = -29.0f;

  // ワープ鏡１６Ｂ
  public const string EDELGARZEN_2_MIRROR_16B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_16B_O = "16B";
  public const float EDELGARZEN_2_MIRROR_16B_X = 11.0f;
  public const float EDELGARZEN_2_MIRROR_16B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_16B_Z = -32.0f;

  // ワープ鏡１７
  public const string EDELGARZEN_2_MIRROR_17_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_17_O = "17";
  public const float EDELGARZEN_2_MIRROR_17_X = 6.0f;
  public const float EDELGARZEN_2_MIRROR_17_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_17_Z = -15.0f;

  // ワープ鏡１７Ｂ
  public const string EDELGARZEN_2_MIRROR_17B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_17B_O = "17B";
  public const float EDELGARZEN_2_MIRROR_17B_X = 6.0f;
  public const float EDELGARZEN_2_MIRROR_17B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_17B_Z = -33.0f;

  // ワープ鏡１８
  public const string EDELGARZEN_2_MIRROR_18_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_18_O = "18";
  public const float EDELGARZEN_2_MIRROR_18_X = 8.0f;
  public const float EDELGARZEN_2_MIRROR_18_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_18_Z = -15.0f;

  // ワープ鏡１８Ｂ
  public const string EDELGARZEN_2_MIRROR_18B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_18B_O = "18B";
  public const float EDELGARZEN_2_MIRROR_18B_X = 13.0f;
  public const float EDELGARZEN_2_MIRROR_18B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_18B_Z = -17.0f;

  // ワープ鏡１９
  public const string EDELGARZEN_2_MIRROR_19_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_19_O = "19";
  public const float EDELGARZEN_2_MIRROR_19_X = 4.0f;
  public const float EDELGARZEN_2_MIRROR_19_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_19_Z = -31.0f;

  // ワープ鏡１９Ｂ
  public const string EDELGARZEN_2_MIRROR_19B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_19B_O = "19B";
  public const float EDELGARZEN_2_MIRROR_19B_X = 8.0f;
  public const float EDELGARZEN_2_MIRROR_19B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_19B_Z = -19.0f;

  // ワープ鏡２０
  public const string EDELGARZEN_2_MIRROR_20_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_20_O = "20";
  public const float EDELGARZEN_2_MIRROR_20_X = 8.0f;
  public const float EDELGARZEN_2_MIRROR_20_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_20_Z = -31.0f;

  // ワープ鏡２０Ｂ
  public const string EDELGARZEN_2_MIRROR_20B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_20B_O = "20B";
  public const float EDELGARZEN_2_MIRROR_20B_X = 8.0f;
  public const float EDELGARZEN_2_MIRROR_20B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_20B_Z = -21.0f;

  // ワープ鏡２１
  public const string EDELGARZEN_2_MIRROR_21_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_21_O = "21";
  public const float EDELGARZEN_2_MIRROR_21_X = 4.0f;
  public const float EDELGARZEN_2_MIRROR_21_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_21_Z = -35.0f;

  // ワープ鏡２１Ｂ
  public const string EDELGARZEN_2_MIRROR_21B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_21B_O = "21B";
  public const float EDELGARZEN_2_MIRROR_21B_X = 8.0f;
  public const float EDELGARZEN_2_MIRROR_21B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_21B_Z = -23.0f;

  // ワープ鏡２２
  public const string EDELGARZEN_2_MIRROR_22_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_22_O = "22";
  public const float EDELGARZEN_2_MIRROR_22_X = 8.0f;
  public const float EDELGARZEN_2_MIRROR_22_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_22_Z = -35.0f;

  // ワープ鏡２２Ｂ
  public const string EDELGARZEN_2_MIRROR_22B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_22B_O = "22B";
  public const float EDELGARZEN_2_MIRROR_22B_X = 8.0f;
  public const float EDELGARZEN_2_MIRROR_22B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_22B_Z = -11.0f;

  // ワープ鏡２３
  public const string EDELGARZEN_2_MIRROR_23_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_23_O = "23";
  public const float EDELGARZEN_2_MIRROR_23_X = 38.0f;
  public const float EDELGARZEN_2_MIRROR_23_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_23_Z = -14.0f;

  // ワープ鏡２３Ｂ
  public const string EDELGARZEN_2_MIRROR_23B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_23B_O = "23B";
  public const float EDELGARZEN_2_MIRROR_23B_X = 56.0f;
  public const float EDELGARZEN_2_MIRROR_23B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_23B_Z = -28.0f;

  // ワープ鏡２４
  public const string EDELGARZEN_2_MIRROR_24_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_24_O = "24";
  public const float EDELGARZEN_2_MIRROR_24_X = 47.0f;
  public const float EDELGARZEN_2_MIRROR_24_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_24_Z = -35.0f;

  // ワープ鏡２４Ｂ
  public const string EDELGARZEN_2_MIRROR_24B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_24B_O = "24B";
  public const float EDELGARZEN_2_MIRROR_24B_X = 41.0f;
  public const float EDELGARZEN_2_MIRROR_24B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_24B_Z = -33.0f;

  // ワープ鏡２５
  public const string EDELGARZEN_2_MIRROR_25_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_25_O = "25";
  public const float EDELGARZEN_2_MIRROR_25_X = 45.0f;
  public const float EDELGARZEN_2_MIRROR_25_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_25_Z = -23.0f;

  // ワープ鏡２５Ｂ
  public const string EDELGARZEN_2_MIRROR_25B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_25B_O = "25B";
  public const float EDELGARZEN_2_MIRROR_25B_X = 49.0f;
  public const float EDELGARZEN_2_MIRROR_25B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_25B_Z = -19.0f;

  // ワープ鏡２６
  public const string EDELGARZEN_2_MIRROR_26_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_26_O = "26";
  public const float EDELGARZEN_2_MIRROR_26_X = 48.0f;
  public const float EDELGARZEN_2_MIRROR_26_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_26_Z = -16.0f;

  // ワープ鏡２６Ｂ
  public const string EDELGARZEN_2_MIRROR_26B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_26B_O = "26B";
  public const float EDELGARZEN_2_MIRROR_26B_X = 40.0f;
  public const float EDELGARZEN_2_MIRROR_26B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_26B_Z = -10.0f;

  // ワープ鏡２７
  public const string EDELGARZEN_2_MIRROR_27_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_27_O = "27";
  public const float EDELGARZEN_2_MIRROR_27_X = 46.0f;
  public const float EDELGARZEN_2_MIRROR_27_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_27_Z = -12.0f;

  // ワープ鏡２７Ｂ
  public const string EDELGARZEN_2_MIRROR_27B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_27B_O = "27B";
  public const float EDELGARZEN_2_MIRROR_27B_X = 56.0f;
  public const float EDELGARZEN_2_MIRROR_27B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_27B_Z = -14.0f;

  // ワープ鏡２８
  public const string EDELGARZEN_2_MIRROR_28_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_28_O = "28";
  public const float EDELGARZEN_2_MIRROR_28_X = 51.0f;
  public const float EDELGARZEN_2_MIRROR_28_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_28_Z = -28.0f;

  // ワープ鏡２８Ｂ
  public const string EDELGARZEN_2_MIRROR_28B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_28B_O = "28B";
  public const float EDELGARZEN_2_MIRROR_28B_X = 42.0f;
  public const float EDELGARZEN_2_MIRROR_28B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_28B_Z = -21.0f;

  // ワープ鏡２９
  public const string EDELGARZEN_2_MIRROR_29_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_29_O = "29";
  public const float EDELGARZEN_2_MIRROR_29_X = 44.0f;
  public const float EDELGARZEN_2_MIRROR_29_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_29_Z = -26.0f;

  // ワープ鏡２９Ｂ
  public const string EDELGARZEN_2_MIRROR_29B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_29B_O = "29B";
  public const float EDELGARZEN_2_MIRROR_29B_X = 50.0f;
  public const float EDELGARZEN_2_MIRROR_29B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_29B_Z = -26.0f;

  // ワープ鏡３０
  public const string EDELGARZEN_2_MIRROR_30_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_30_O = "30";
  public const float EDELGARZEN_2_MIRROR_30_X = 50.0f;
  public const float EDELGARZEN_2_MIRROR_30_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_30_Z = -30.0f;

  // ワープ鏡３０Ｂ
  public const string EDELGARZEN_2_MIRROR_30B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_30B_O = "30B";
  public const float EDELGARZEN_2_MIRROR_30B_X = 40.0f;
  public const float EDELGARZEN_2_MIRROR_30B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_30B_Z = -18.0f;

  // ワープ鏡３１
  public const string EDELGARZEN_2_MIRROR_31_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_31_O = "31";
  public const float EDELGARZEN_2_MIRROR_31_X = 54.0f;
  public const float EDELGARZEN_2_MIRROR_31_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_31_Z = -18.0f;

  // ワープ鏡３１Ｂ
  public const string EDELGARZEN_2_MIRROR_31B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_31B_O = "31B";
  public const float EDELGARZEN_2_MIRROR_31B_X = 42.0f;
  public const float EDELGARZEN_2_MIRROR_31B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_31B_Z = -30.0f;

  // ワープ鏡３２
  public const string EDELGARZEN_2_MIRROR_32_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_32_O = "32";
  public const float EDELGARZEN_2_MIRROR_32_X = 47.0f;
  public const float EDELGARZEN_2_MIRROR_32_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_32_Z = -7.0f;

  // ワープ鏡３２Ｂ
  public const string EDELGARZEN_2_MIRROR_32B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_32B_O = "32B";
  public const float EDELGARZEN_2_MIRROR_32B_X = 53.0f;
  public const float EDELGARZEN_2_MIRROR_32B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_32B_Z = -15.0f;

  // ワープ鏡３３
  public const string EDELGARZEN_2_MIRROR_33_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_33_O = "33";
  public const float EDELGARZEN_2_MIRROR_33_X = 46.0f;
  public const float EDELGARZEN_2_MIRROR_33_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_33_Z = -16.0f;

  // ワープ鏡３３Ｂ
  public const string EDELGARZEN_2_MIRROR_33B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_33B_O = "33B";
  public const float EDELGARZEN_2_MIRROR_33B_X = 38.0f;
  public const float EDELGARZEN_2_MIRROR_33B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_33B_Z = -28.0f;

  // ワープ鏡３４
  public const string EDELGARZEN_2_MIRROR_34_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_34_O = "34";
  public const float EDELGARZEN_2_MIRROR_34_X = 52.0f;
  public const float EDELGARZEN_2_MIRROR_34_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_34_Z = -21.0f;

  // ワープ鏡３４Ｂ
  public const string EDELGARZEN_2_MIRROR_34B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_34B_O = "34B";
  public const float EDELGARZEN_2_MIRROR_34B_X = 43.0f;
  public const float EDELGARZEN_2_MIRROR_34B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_34B_Z = -15.0f;

  // ワープ鏡３５
  public const string EDELGARZEN_2_MIRROR_35_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_35_O = "35";
  public const float EDELGARZEN_2_MIRROR_35_X = 43.0f;
  public const float EDELGARZEN_2_MIRROR_35_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_35_Z = -11.0f;

  // ワープ鏡３５Ｂ
  public const string EDELGARZEN_2_MIRROR_35B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_35B_O = "35B";
  public const float EDELGARZEN_2_MIRROR_35B_X = 53.0f;
  public const float EDELGARZEN_2_MIRROR_35B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_35B_Z = -33.0f;

  // ワープ鏡３６
  public const string EDELGARZEN_2_MIRROR_36_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_36_O = "36";
  public const float EDELGARZEN_2_MIRROR_36_X = 49.0f;
  public const float EDELGARZEN_2_MIRROR_36_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_36_Z = -23.0f;

  // ワープ鏡３６Ｂ
  public const string EDELGARZEN_2_MIRROR_36B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_36B_O = "36B";
  public const float EDELGARZEN_2_MIRROR_36B_X = 51.0f;
  public const float EDELGARZEN_2_MIRROR_36B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_36B_Z = -9.0f;

  // ワープ鏡３７
  public const string EDELGARZEN_2_MIRROR_37_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_37_O = "37";
  public const float EDELGARZEN_2_MIRROR_37_X = 51.0f;
  public const float EDELGARZEN_2_MIRROR_37_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_37_Z = -11.0f;

  // ワープ鏡３７Ｂ
  public const string EDELGARZEN_2_MIRROR_37B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_37B_O = "37B";
  public const float EDELGARZEN_2_MIRROR_37B_X = 43.0f;
  public const float EDELGARZEN_2_MIRROR_37B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_37B_Z = -28.0f;

  // ワープ鏡３８
  public const string EDELGARZEN_2_MIRROR_38_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_38_O = "38";
  public const float EDELGARZEN_2_MIRROR_38_X = 46.0f;
  public const float EDELGARZEN_2_MIRROR_38_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_38_Z = -19.0f;

  // ワープ鏡３８Ｂ
  public const string EDELGARZEN_2_MIRROR_38B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_38B_O = "38B";
  public const float EDELGARZEN_2_MIRROR_38B_X = 48.0f;
  public const float EDELGARZEN_2_MIRROR_38B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_38B_Z = -13.0f;

  // ワープ鏡３９
  public const string EDELGARZEN_2_MIRROR_39_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_39_O = "39";
  public const float EDELGARZEN_2_MIRROR_39_X = 26.0f;
  public const float EDELGARZEN_2_MIRROR_39_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_39_Z = -31.0f;

  // ワープ鏡３９Ｂ
  public const string EDELGARZEN_2_MIRROR_39B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_39B_O = "39B";
  public const float EDELGARZEN_2_MIRROR_39B_X = 26.0f;
  public const float EDELGARZEN_2_MIRROR_39B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_39B_Z = -29.0f;

  // ワープ鏡４０
  public const string EDELGARZEN_2_MIRROR_40_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_40_O = "40";
  public const float EDELGARZEN_2_MIRROR_40_X = 27.0f;
  public const float EDELGARZEN_2_MIRROR_40_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_40_Z = -22.0f;

  // ワープ鏡４０Ｂ
  public const string EDELGARZEN_2_MIRROR_40B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_40B_O = "40B";
  public const float EDELGARZEN_2_MIRROR_40B_X = 24.0f;
  public const float EDELGARZEN_2_MIRROR_40B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_40B_Z = -16.0f;

  // ワープ鏡４１
  public const string EDELGARZEN_2_MIRROR_41_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_41_O = "41";
  public const float EDELGARZEN_2_MIRROR_41_X = 26.0f;
  public const float EDELGARZEN_2_MIRROR_41_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_41_Z = -9.0f;

  // ワープ鏡４１Ｂ
  public const string EDELGARZEN_2_MIRROR_41B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_41B_O = "41B";
  public const float EDELGARZEN_2_MIRROR_41B_X = 26.0f;
  public const float EDELGARZEN_2_MIRROR_41B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_41B_Z = -2.0f;

  // ワープ鏡４２
  public const string EDELGARZEN_2_MIRROR_42_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_42_O = "42";
  public const float EDELGARZEN_2_MIRROR_42_X = 34.0f;
  public const float EDELGARZEN_2_MIRROR_42_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_42_Z = -31.0f;

  // ワープ鏡４２Ｂ
  public const string EDELGARZEN_2_MIRROR_42B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_42B_O = "42B";
  public const float EDELGARZEN_2_MIRROR_42B_X = 34.0f;
  public const float EDELGARZEN_2_MIRROR_42B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_42B_Z = -29.0f;

  // ワープ鏡４３
  public const string EDELGARZEN_2_MIRROR_43_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_43_O = "43";
  public const float EDELGARZEN_2_MIRROR_43_X = 32.0f;
  public const float EDELGARZEN_2_MIRROR_43_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_43_Z = -23.0f;

  // ワープ鏡４３Ｂ
  public const string EDELGARZEN_2_MIRROR_43B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_43B_O = "43B";
  public const float EDELGARZEN_2_MIRROR_43B_X = 36.0f;
  public const float EDELGARZEN_2_MIRROR_43B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_43B_Z = -16.0f;

  // ワープ鏡４４
  public const string EDELGARZEN_2_MIRROR_44_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_44_O = "44";
  public const float EDELGARZEN_2_MIRROR_44_X = 34.0f;
  public const float EDELGARZEN_2_MIRROR_44_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_44_Z = -9.0f;

  // ワープ鏡４４Ｂ
  public const string EDELGARZEN_2_MIRROR_44B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_44B_O = "44B";
  public const float EDELGARZEN_2_MIRROR_44B_X = 34.0f;
  public const float EDELGARZEN_2_MIRROR_44B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_44B_Z = -2.0f;

  // ワープ鏡４５
  public const string EDELGARZEN_2_MIRROR_45_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_45_O = "45";
  public const float EDELGARZEN_2_MIRROR_45_X = 30.0f;
  public const float EDELGARZEN_2_MIRROR_45_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_45_Z = -31.0f;

  // ワープ鏡４５Ｂ
  public const string EDELGARZEN_2_MIRROR_45B_C = "Mirror";
  public const string EDELGARZEN_2_MIRROR_45B_O = "45B";
  public const float EDELGARZEN_2_MIRROR_45B_X = 30.0f;
  public const float EDELGARZEN_2_MIRROR_45B_Y = 0.5f;
  public const float EDELGARZEN_2_MIRROR_45B_Z = -2.0f;
  #endregion
  #region "Treasure"
  public const string EDELGARZEN_2_Treasure_1_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_1_O = "1";
  public const float EDELGARZEN_2_Treasure_1_X = 14.0f;
  public const float EDELGARZEN_2_Treasure_1_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_1_Z = -15.0f;

  public const string EDELGARZEN_2_Treasure_2_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_2_O = "2";
  public const float EDELGARZEN_2_Treasure_2_X = 18.0f;
  public const float EDELGARZEN_2_Treasure_2_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_2_Z = -19.0f;

  public const string EDELGARZEN_2_Treasure_3_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_3_O = "3";
  public const float EDELGARZEN_2_Treasure_3_X = 10.0f;
  public const float EDELGARZEN_2_Treasure_3_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_3_Z = -35.0f;

  public const string EDELGARZEN_2_Treasure_4_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_4_O = "4";
  public const float EDELGARZEN_2_Treasure_4_X = 18.0f;
  public const float EDELGARZEN_2_Treasure_4_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_4_Z = -9.0f;

  public const string EDELGARZEN_2_Treasure_5_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_5_O = "5";
  public const float EDELGARZEN_2_Treasure_5_X = 12.0f;
  public const float EDELGARZEN_2_Treasure_5_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_5_Z = -21.0f;

  public const string EDELGARZEN_2_Treasure_6_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_6_O = "6";
  public const float EDELGARZEN_2_Treasure_6_X = 7.0f;
  public const float EDELGARZEN_2_Treasure_6_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_6_Z = -32.0f;

  public const string EDELGARZEN_2_Treasure_7_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_7_O = "7";
  public const float EDELGARZEN_2_Treasure_7_X = 53.0f;
  public const float EDELGARZEN_2_Treasure_7_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_7_Z = -11.0f;

  public const string EDELGARZEN_2_Treasure_8_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_8_O = "8";
  public const float EDELGARZEN_2_Treasure_8_X = 52.0f;
  public const float EDELGARZEN_2_Treasure_8_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_8_Z = -26.0f;

  public const string EDELGARZEN_2_Treasure_9_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_9_O = "9";
  public const float EDELGARZEN_2_Treasure_9_X = 38.0f;
  public const float EDELGARZEN_2_Treasure_9_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_9_Z = -35.0f;

  public const string EDELGARZEN_2_Treasure_10_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_10_O = "10";
  public const float EDELGARZEN_2_Treasure_10_X = 56.0f;
  public const float EDELGARZEN_2_Treasure_10_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_10_Z = -35.0f;

  public const string EDELGARZEN_2_Treasure_11_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_11_O = "11";
  public const float EDELGARZEN_2_Treasure_11_X = 40.0f;
  public const float EDELGARZEN_2_Treasure_11_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_11_Z = -15.0f;

  public const string EDELGARZEN_2_Treasure_12_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_12_O = "12";
  public const float EDELGARZEN_2_Treasure_12_X = 42.0f;
  public const float EDELGARZEN_2_Treasure_12_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_12_Z = -26.0f;

  public const string EDELGARZEN_2_Treasure_13_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_13_O = "13";
  public const float EDELGARZEN_2_Treasure_13_X = 56.0f;
  public const float EDELGARZEN_2_Treasure_13_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_13_Z = -7.0f;

  public const string EDELGARZEN_2_Treasure_14_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_14_O = "14";
  public const float EDELGARZEN_2_Treasure_14_X = 47.0f;
  public const float EDELGARZEN_2_Treasure_14_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_14_Z = -21.0f;

  public const string EDELGARZEN_2_Treasure_15_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_15_O = "15";
  public const float EDELGARZEN_2_Treasure_15_X = 11.0f;
  public const float EDELGARZEN_2_Treasure_15_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_15_Z = -7.0f;

  public const string EDELGARZEN_2_Treasure_16_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_16_O = "16";
  public const float EDELGARZEN_2_Treasure_16_X = 29.0f;
  public const float EDELGARZEN_2_Treasure_16_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_16_Z = -9.0f;

  public const string EDELGARZEN_2_Treasure_17_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_17_O = "17";
  public const float EDELGARZEN_2_Treasure_17_X = 15.0f;
  public const float EDELGARZEN_2_Treasure_17_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_17_Z = -3.0f;

  public const string EDELGARZEN_2_Treasure_18_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_18_O = "18";
  public const float EDELGARZEN_2_Treasure_18_X = 31.0f;
  public const float EDELGARZEN_2_Treasure_18_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_18_Z = -9.0f;

  public const string EDELGARZEN_2_Treasure_19_C = "Treasure";
  public const string EDELGARZEN_2_Treasure_19_O = "19";
  public const float EDELGARZEN_2_Treasure_19_X = 45.0f;
  public const float EDELGARZEN_2_Treasure_19_Y = 1.0f;
  public const float EDELGARZEN_2_Treasure_19_Z = -3.0f;
  #endregion
  #region "Edelgarzen Door"
  public const string EDELGARZEN_2_DOOR_1_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_1_O = "1";
  public const float EDELGARZEN_2_DOOR_1_X = 17.0f;
  public const float EDELGARZEN_2_DOOR_1_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_1_Z = -14.0f;

  public const string EDELGARZEN_2_DOOR_2_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_2_O = "2";
  public const float EDELGARZEN_2_DOOR_2_X = 17.0f;
  public const float EDELGARZEN_2_DOOR_2_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_2_Z = -21.0f;

  public const string EDELGARZEN_2_DOOR_3_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_3_O = "3";
  public const float EDELGARZEN_2_DOOR_3_X = 16.0f;
  public const float EDELGARZEN_2_DOOR_3_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_3_Z = -18.0f;

  public const string EDELGARZEN_2_DOOR_4_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_4_O = "4";
  public const float EDELGARZEN_2_DOOR_4_X = 12.0f;
  public const float EDELGARZEN_2_DOOR_4_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_4_Z = -26.0f;

  public const string EDELGARZEN_2_DOOR_5_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_5_O = "5";
  public const float EDELGARZEN_2_DOOR_5_X = 18.0f;
  public const float EDELGARZEN_2_DOOR_5_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_5_Z = -26.0f;

  public const string EDELGARZEN_2_DOOR_6_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_6_O = "6";
  public const float EDELGARZEN_2_DOOR_6_X = 17.0f;
  public const float EDELGARZEN_2_DOOR_6_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_6_Z = -25.0f;

  public const string EDELGARZEN_2_DOOR_7_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_7_O = "7";
  public const float EDELGARZEN_2_DOOR_7_X = 15.0f;
  public const float EDELGARZEN_2_DOOR_7_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_7_Z = -34.0f;

  public const string EDELGARZEN_2_DOOR_8_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_8_O = "8";
  public const float EDELGARZEN_2_DOOR_8_X = 17.0f;
  public const float EDELGARZEN_2_DOOR_8_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_8_Z = -35.0f;

  public const string EDELGARZEN_2_DOOR_9_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_9_O = "9";
  public const float EDELGARZEN_2_DOOR_9_X = 19.0f;
  public const float EDELGARZEN_2_DOOR_9_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_9_Z = -34.0f;

  public const string EDELGARZEN_2_DOOR_10_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_10_O = "10";
  public const float EDELGARZEN_2_DOOR_10_X = 22.0f;
  public const float EDELGARZEN_2_DOOR_10_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_10_Z = -30.0f;

  public const string EDELGARZEN_2_DOOR_11_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_11_O = "11";
  public const float EDELGARZEN_2_DOOR_11_X = 21.0f;
  public const float EDELGARZEN_2_DOOR_11_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_11_Z = -10.0f;

  public const string EDELGARZEN_2_DOOR_12_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_12_O = "12";
  public const float EDELGARZEN_2_DOOR_12_X = 17.0f;
  public const float EDELGARZEN_2_DOOR_12_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_12_Z = -17.0f;

  public const string EDELGARZEN_2_DOOR_13_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_13_O = "13";
  public const float EDELGARZEN_2_DOOR_13_X = 7.0f;
  public const float EDELGARZEN_2_DOOR_13_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_13_Z = -20.0f;

  public const string EDELGARZEN_2_DOOR_14_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_14_O = "14";
  public const float EDELGARZEN_2_DOOR_14_X = 7.0f;
  public const float EDELGARZEN_2_DOOR_14_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_14_Z = -24.0f;

  public const string EDELGARZEN_2_DOOR_15_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_15_O = "15";
  public const float EDELGARZEN_2_DOOR_15_X = 7.0f;
  public const float EDELGARZEN_2_DOOR_15_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_15_Z = -28.0f;

  public const string EDELGARZEN_2_DOOR_16_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_16_O = "16";
  public const float EDELGARZEN_2_DOOR_16_X = 9.0f;
  public const float EDELGARZEN_2_DOOR_16_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_16_Z = -25.0f;

  public const string EDELGARZEN_2_DOOR_17_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_17_O = "17";
  public const float EDELGARZEN_2_DOOR_17_X = 11.0f;
  public const float EDELGARZEN_2_DOOR_17_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_17_Z = -34.0f;

  public const string EDELGARZEN_2_DOOR_18_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_18_O = "18";
  public const float EDELGARZEN_2_DOOR_18_X = 13.0f;
  public const float EDELGARZEN_2_DOOR_18_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_18_Z = -35.0f;

  public const string EDELGARZEN_2_DOOR_19_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_19_O = "19";
  public const float EDELGARZEN_2_DOOR_19_X = 5.0f;
  public const float EDELGARZEN_2_DOOR_19_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_19_Z = -11.0f;

  public const string EDELGARZEN_2_DOOR_20_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_20_O = "20";
  public const float EDELGARZEN_2_DOOR_20_X = 4.0f;
  public const float EDELGARZEN_2_DOOR_20_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_20_Z = -16.0f;

  public const string EDELGARZEN_2_DOOR_21_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_21_O = "21";
  public const float EDELGARZEN_2_DOOR_21_X = 37.0f;
  public const float EDELGARZEN_2_DOOR_21_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_21_Z = -7.0f;

  public const string EDELGARZEN_2_DOOR_22_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_22_O = "22";
  public const float EDELGARZEN_2_DOOR_22_X = 4.0f;
  public const float EDELGARZEN_2_DOOR_22_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_22_Z = -2.0f;

  public const string EDELGARZEN_2_DOOR_23_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_23_O = "23";
  public const float EDELGARZEN_2_DOOR_23_X = 56.0f;
  public const float EDELGARZEN_2_DOOR_23_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_23_Z = -2.0f;

  public const string EDELGARZEN_2_DOOR_24_C = "Edelgarzen_Door";
  public const string EDELGARZEN_2_DOOR_24_O = "24";
  public const float EDELGARZEN_2_DOOR_24_X = 30.0f;
  public const float EDELGARZEN_2_DOOR_24_Y = 0.5f;
  public const float EDELGARZEN_2_DOOR_24_Z = -21.0f;
  #endregion
  #region "階段"
  // 下り階段( 区画１の中央左 )
  public const string EDELGARZEN_2_DOWNSTAIR_1_C = "Downstair";
  public const string EDELGARZEN_2_DOWNSTAIR_1_O = "1";
  public const float EDELGARZEN_2_DOWNSTAIR_1_X = 29.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_1_Y = 0.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_1_Z = -7.0f;

  // 下り階段( 区画１の左上 )
  public const string EDELGARZEN_2_DOWNSTAIR_2_C = "Downstair";
  public const string EDELGARZEN_2_DOWNSTAIR_2_O = "2";
  public const float EDELGARZEN_2_DOWNSTAIR_2_X = 6.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_2_Y = 0.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_2_Z = -9.0f;

  // 下り階段( 区画２の中央右 )
  public const string EDELGARZEN_2_DOWNSTAIR_3_C = "Downstair";
  public const string EDELGARZEN_2_DOWNSTAIR_3_O = "3";
  public const float EDELGARZEN_2_DOWNSTAIR_3_X = 31.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_3_Y = 0.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_3_Z = -7.0f;

  // 下り階段( 区画２の右上 )
  public const string EDELGARZEN_2_DOWNSTAIR_4_C = "Downstair";
  public const string EDELGARZEN_2_DOWNSTAIR_4_O = "4";
  public const float EDELGARZEN_2_DOWNSTAIR_4_X = 54.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_4_Y = 0.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_4_Z = -9.0f;

  // 下り階段( 区画３の右 )
  public const string EDELGARZEN_2_DOWNSTAIR_5_C = "Downstair";
  public const string EDELGARZEN_2_DOWNSTAIR_5_O = "5";
  public const float EDELGARZEN_2_DOWNSTAIR_5_X = 13.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_5_Y = 0.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_5_Z = -7.0f;

  // 上り階段( 区画３の左 )
  public const string EDELGARZEN_2_UPSTAIR_6_C = "Upstair";
  public const string EDELGARZEN_2_UPSTAIR_6_O = "6";
  public const float EDELGARZEN_2_UPSTAIR_6_X = 9.0f;
  public const float EDELGARZEN_2_UPSTAIR_6_Y = 0.0f;
  public const float EDELGARZEN_2_UPSTAIR_6_Z = -7.0f;

  // 上り階段( 外区画の左上 )
  public const string EDELGARZEN_2_UPSTAIR_7_C = "Upstair";
  public const string EDELGARZEN_2_UPSTAIR_7_O = "7";
  public const float EDELGARZEN_2_UPSTAIR_7_X = 1.0f;
  public const float EDELGARZEN_2_UPSTAIR_7_Y = 0.0f;
  public const float EDELGARZEN_2_UPSTAIR_7_Z = -2.0f;

  // 上り階段( 外区画の右上 )
  public const string EDELGARZEN_2_UPSTAIR_8_C = "Upstair";
  public const string EDELGARZEN_2_UPSTAIR_8_O = "8";
  public const float EDELGARZEN_2_UPSTAIR_8_X = 59.0f;
  public const float EDELGARZEN_2_UPSTAIR_8_Y = 0.0f;
  public const float EDELGARZEN_2_UPSTAIR_8_Z = -2.0f;

  // 上り階段( 外区画の真下 )
  public const string EDELGARZEN_2_UPSTAIR_9_C = "Upstair";
  public const string EDELGARZEN_2_UPSTAIR_9_O = "9";
  public const float EDELGARZEN_2_UPSTAIR_9_X = 30.0f;
  public const float EDELGARZEN_2_UPSTAIR_9_Y = 0.0f;
  public const float EDELGARZEN_2_UPSTAIR_9_Z = -35.0f;

  // 下り階段( 外区画の真上 )
  public const string EDELGARZEN_2_DOWNSTAIR_10_C = "Downstair";
  public const string EDELGARZEN_2_DOWNSTAIR_10_O = "10";
  public const float EDELGARZEN_2_DOWNSTAIR_10_X = 30.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_10_Y = 0.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_10_Z = -4.0f;

  // 下り階段( 中枢部の下 )
  public const string EDELGARZEN_2_DOWNSTAIR_11_C = "Downstair";
  public const string EDELGARZEN_2_DOWNSTAIR_11_O = "11";
  public const float EDELGARZEN_2_DOWNSTAIR_11_X = 30.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_11_Y = 0.0f;
  public const float EDELGARZEN_2_DOWNSTAIR_11_Z = -23.0f;

  // 上り階段( 中枢部の上 )
  public const string EDELGARZEN_2_UPSTAIR_12_C = "Upstair";
  public const string EDELGARZEN_2_UPSTAIR_12_O = "12";
  public const float EDELGARZEN_2_UPSTAIR_12_X = 30.0f;
  public const float EDELGARZEN_2_UPSTAIR_12_Y = 0.0f;
  public const float EDELGARZEN_2_UPSTAIR_12_Z = -13.0f;
  #endregion
  #region "Event"
  // ボス戦開始位置
  public const string EDELGARZEN_2_Event_1_C = "Event";
  public const string EDELGARZEN_2_Event_1_O = "1";
  public const float EDELGARZEN_2_Event_1_X = 30.0f;
  public const float EDELGARZEN_2_Event_1_Y = 0.0f;
  public const float EDELGARZEN_2_Event_1_Z = -20.0f;
  #endregion
  #endregion

  #region "3F"
  #region "ワープ鏡"
  // ワープ鏡１
  public const string EDELGARZEN_3_MIRROR_1_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_1_O = "1";
  public const float EDELGARZEN_3_MIRROR_1_X = 15.0f;
  public const float EDELGARZEN_3_MIRROR_1_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_1_Z = -5.0f;

  // ワープ鏡１Ｂ
  public const string EDELGARZEN_3_MIRROR_1B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_1B_O = "1B";
  public const float EDELGARZEN_3_MIRROR_1B_X = 39.0f;
  public const float EDELGARZEN_3_MIRROR_1B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_1B_Z = -20.0f;

  // ワープ鏡２
  public const string EDELGARZEN_3_MIRROR_2_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_2_O = "2";
  public const float EDELGARZEN_3_MIRROR_2_X = 35.0f;
  public const float EDELGARZEN_3_MIRROR_2_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_2_Z = -27.0f;

  // ワープ鏡２Ｂ
  public const string EDELGARZEN_3_MIRROR_2B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_2B_O = "2B";
  public const float EDELGARZEN_3_MIRROR_2B_X = 16.0f;
  public const float EDELGARZEN_3_MIRROR_2B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_2B_Z = -26.0f;

  // ワープ鏡３
  public const string EDELGARZEN_3_MIRROR_3_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_3_O = "3";
  public const float EDELGARZEN_3_MIRROR_3_X = 37.0f;
  public const float EDELGARZEN_3_MIRROR_3_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_3_Z = -27.0f;

  // ワープ鏡３Ｂ
  public const string EDELGARZEN_3_MIRROR_3B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_3B_O = "3B";
  public const float EDELGARZEN_3_MIRROR_3B_X = 39.0f;
  public const float EDELGARZEN_3_MIRROR_3B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_3B_Z = -13.0f;

  // ワープ鏡４
  public const string EDELGARZEN_3_MIRROR_4_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_4_O = "4";
  public const float EDELGARZEN_3_MIRROR_4_X = 39.0f;
  public const float EDELGARZEN_3_MIRROR_4_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_4_Z = -27.0f;

  // ワープ鏡４Ｂ
  public const string EDELGARZEN_3_MIRROR_4B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_4B_O = "4B";
  public const float EDELGARZEN_3_MIRROR_4B_X = 17.0f;
  public const float EDELGARZEN_3_MIRROR_4B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_4B_Z = -5.0f;

  // ワープ鏡５
  public const string EDELGARZEN_3_MIRROR_5_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_5_O = "5";
  public const float EDELGARZEN_3_MIRROR_5_X = 15.0f;
  public const float EDELGARZEN_3_MIRROR_5_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_5_Z = -32.0f;

  // ワープ鏡５Ｂ
  public const string EDELGARZEN_3_MIRROR_5B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_5B_O = "5B";
  public const float EDELGARZEN_3_MIRROR_5B_X = 52.0f;
  public const float EDELGARZEN_3_MIRROR_5B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_5B_Z = -14.0f;

  // ワープ鏡６
  public const string EDELGARZEN_3_MIRROR_6_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_6_O = "6";
  public const float EDELGARZEN_3_MIRROR_6_X = 17.0f;
  public const float EDELGARZEN_3_MIRROR_6_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_6_Z = -32.0f;

  // ワープ鏡６Ｂ
  public const string EDELGARZEN_3_MIRROR_6B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_6B_O = "6B";
  public const float EDELGARZEN_3_MIRROR_6B_X = 41.0f;
  public const float EDELGARZEN_3_MIRROR_6B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_6B_Z = -16.0f;

  // ワープ鏡７
  public const string EDELGARZEN_3_MIRROR_7_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_7_O = "7";
  public const float EDELGARZEN_3_MIRROR_7_X = 39.0f;
  public const float EDELGARZEN_3_MIRROR_7_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_7_Z = -9.0f;

  // ワープ鏡７Ｂ
  public const string EDELGARZEN_3_MIRROR_7B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_7B_O = "7B";
  public const float EDELGARZEN_3_MIRROR_7B_X = 7.0f;
  public const float EDELGARZEN_3_MIRROR_7B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_7B_Z = -26.0f;

  // ワープ鏡８
  public const string EDELGARZEN_3_MIRROR_8_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_8_O = "8";
  public const float EDELGARZEN_3_MIRROR_8_X = 37.0f;
  public const float EDELGARZEN_3_MIRROR_8_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_8_Z = -9.0f;

  // ワープ鏡８Ｂ
  public const string EDELGARZEN_3_MIRROR_8B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_8B_O = "8B";
  public const float EDELGARZEN_3_MIRROR_8B_X = 33.0f;
  public const float EDELGARZEN_3_MIRROR_8B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_8B_Z = -20.0f;

  // ワープ鏡９
  public const string EDELGARZEN_3_MIRROR_9_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_9_O = "9";
  public const float EDELGARZEN_3_MIRROR_9_X = 5.0f;
  public const float EDELGARZEN_3_MIRROR_9_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_9_Z = -4.0f;

  // ワープ鏡９Ｂ
  public const string EDELGARZEN_3_MIRROR_9B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_9B_O = "9B";
  public const float EDELGARZEN_3_MIRROR_9B_X = 52.0f;
  public const float EDELGARZEN_3_MIRROR_9B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_9B_Z = -22.0f;

  // ワープ鏡１０
  public const string EDELGARZEN_3_MIRROR_10_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_10_O = "10";
  public const float EDELGARZEN_3_MIRROR_10_X = 5.0f;
  public const float EDELGARZEN_3_MIRROR_10_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_10_Z = -6.0f;

  // ワープ鏡１０Ｂ
  public const string EDELGARZEN_3_MIRROR_10B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_10B_O = "10B";
  public const float EDELGARZEN_3_MIRROR_10B_X = 41.0f;
  public const float EDELGARZEN_3_MIRROR_10B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_10B_Z = -18.0f;

  // ワープ鏡１１
  public const string EDELGARZEN_3_MIRROR_11_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_11_O = "11";
  public const float EDELGARZEN_3_MIRROR_11_X = 43.0f;
  public const float EDELGARZEN_3_MIRROR_11_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_11_Z = -12.0f;
  // ワープ鏡１１Ｂ（なし）

  // ワープ鏡１２
  public const string EDELGARZEN_3_MIRROR_12_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_12_O = "12";
  public const float EDELGARZEN_3_MIRROR_12_X = 45.0f;
  public const float EDELGARZEN_3_MIRROR_12_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_12_Z = -12.0f;
  // ワープ鏡１２Ｂ（なし）

  // ワープ鏡１３
  public const string EDELGARZEN_3_MIRROR_13_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_13_O = "13";
  public const float EDELGARZEN_3_MIRROR_13_X = 47.0f;
  public const float EDELGARZEN_3_MIRROR_13_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_13_Z = -12.0f;
  // ワープ鏡１３Ｂ（なし）

  // ワープ鏡１４
  public const string EDELGARZEN_3_MIRROR_14_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_14_O = "14";
  public const float EDELGARZEN_3_MIRROR_14_X = 47.0f;
  public const float EDELGARZEN_3_MIRROR_14_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_14_Z = -16.0f;
  // ワープ鏡１４Ｂ（なし）

  // ワープ鏡１５
  public const string EDELGARZEN_3_MIRROR_15_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_15_O = "15";
  public const float EDELGARZEN_3_MIRROR_15_X = 47.0f;
  public const float EDELGARZEN_3_MIRROR_15_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_15_Z = -18.0f;
  // ワープ鏡１５Ｂ（なし）

  // ワープ鏡１６
  public const string EDELGARZEN_3_MIRROR_16_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_16_O = "16";
  public const float EDELGARZEN_3_MIRROR_16_X = 47.0f;
  public const float EDELGARZEN_3_MIRROR_16_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_16_Z = -20.0f;
  // ワープ鏡１６Ｂ（なし）

  // ワープ鏡１７
  public const string EDELGARZEN_3_MIRROR_17_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_17_O = "17";
  public const float EDELGARZEN_3_MIRROR_17_X = 8.0f;
  public const float EDELGARZEN_3_MIRROR_17_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_17_Z = -28.0f;
  // ワープ鏡１７Ｂ（なし）

  // ワープ鏡１８
  public const string EDELGARZEN_3_MIRROR_18_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_18_O = "18";
  public const float EDELGARZEN_3_MIRROR_18_X = 9.0f;
  public const float EDELGARZEN_3_MIRROR_18_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_18_Z = -29.0f;
  // ワープ鏡１８Ｂ（なし）

  // ワープ鏡１９
  public const string EDELGARZEN_3_MIRROR_19_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_19_O = "19";
  public const float EDELGARZEN_3_MIRROR_19_X = 10.0f;
  public const float EDELGARZEN_3_MIRROR_19_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_19_Z = -30.0f;
  // ワープ鏡１９Ｂ（なし）

  // ワープ鏡２０
  public const string EDELGARZEN_3_MIRROR_20_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_20_O = "20";
  public const float EDELGARZEN_3_MIRROR_20_X = 33.0f;
  public const float EDELGARZEN_3_MIRROR_20_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_20_Z = -34.0f;
  // ワープ鏡２０Ｂ（なし）

  // ワープ鏡２１
  public const string EDELGARZEN_3_MIRROR_21_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_21_O = "21";
  public const float EDELGARZEN_3_MIRROR_21_X = 35.0f;
  public const float EDELGARZEN_3_MIRROR_21_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_21_Z = -34.0f;
  // ワープ鏡２１Ｂ（なし）

  // ワープ鏡２２
  public const string EDELGARZEN_3_MIRROR_22_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_22_O = "22";
  public const float EDELGARZEN_3_MIRROR_22_X = 55.0f;
  public const float EDELGARZEN_3_MIRROR_22_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_22_Z = -16.0f;
  // ワープ鏡２２Ｂ（なし）

  // ワープ鏡２３
  public const string EDELGARZEN_3_MIRROR_23_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_23_O = "23";
  public const float EDELGARZEN_3_MIRROR_23_X = 55.0f;
  public const float EDELGARZEN_3_MIRROR_23_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_23_Z = -18.0f;
  // ワープ鏡２３Ｂ（なし）

  // ワープ鏡２４
  public const string EDELGARZEN_3_MIRROR_24_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_24_O = "24";
  public const float EDELGARZEN_3_MIRROR_24_X = 37.0f;
  public const float EDELGARZEN_3_MIRROR_24_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_24_Z = -22.0f;
  // ワープ鏡２４Ｂ（なし）

  // ワープ鏡２５
  public const string EDELGARZEN_3_MIRROR_25_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_25_O = "25";
  public const float EDELGARZEN_3_MIRROR_25_X = 47.0f;
  public const float EDELGARZEN_3_MIRROR_25_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_25_Z = -22.0f;
  // ワープ鏡２５Ｂ（なし）

  // ワープ鏡２６
  public const string EDELGARZEN_3_MIRROR_26_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_26_O = "26";
  public const float EDELGARZEN_3_MIRROR_26_X = 41.0f;
  public const float EDELGARZEN_3_MIRROR_26_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_26_Z = -28.0f;
  // ワープ鏡２６Ｂ（なし）

  // ワープ鏡２７
  public const string EDELGARZEN_3_MIRROR_27_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_27_O = "27";
  public const float EDELGARZEN_3_MIRROR_27_X = 15.0f;
  public const float EDELGARZEN_3_MIRROR_27_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_27_Z = -7.0f;

  // ワープ鏡２７Ｂ
  public const string EDELGARZEN_3_MIRROR_27B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_27B_O = "27B";
  public const float EDELGARZEN_3_MIRROR_27B_X = 49.0f;
  public const float EDELGARZEN_3_MIRROR_27B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_27B_Z = -7.0f;

  // ワープ鏡２８
  public const string EDELGARZEN_3_MIRROR_28_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_28_O = "28";
  public const float EDELGARZEN_3_MIRROR_28_X = 43.0f;
  public const float EDELGARZEN_3_MIRROR_28_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_28_Z = -8.0f;

  // ワープ鏡２８Ｂ
  public const string EDELGARZEN_3_MIRROR_28B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_28B_O = "28B";
  public const float EDELGARZEN_3_MIRROR_28B_X = 23.0f;
  public const float EDELGARZEN_3_MIRROR_28B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_28B_Z = -7.0f;

  // ワープ鏡２９
  public const string EDELGARZEN_3_MIRROR_29_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_29_O = "29";
  public const float EDELGARZEN_3_MIRROR_29_X = 45.0f;
  public const float EDELGARZEN_3_MIRROR_29_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_29_Z = -8.0f;

  // ワープ鏡２９Ｂ
  public const string EDELGARZEN_3_MIRROR_29B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_29B_O = "29B";
  public const float EDELGARZEN_3_MIRROR_29B_X = 37.0f;
  public const float EDELGARZEN_3_MIRROR_29B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_29B_Z = -33.0f;

  // ワープ鏡３０
  public const string EDELGARZEN_3_MIRROR_30_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_30_O = "30";
  public const float EDELGARZEN_3_MIRROR_30_X = 47.0f;
  public const float EDELGARZEN_3_MIRROR_30_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_30_Z = -8.0f;

  // ワープ鏡３０Ｂ
  public const string EDELGARZEN_3_MIRROR_30B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_30B_O = "30B";
  public const float EDELGARZEN_3_MIRROR_30B_X = 5.0f;
  public const float EDELGARZEN_3_MIRROR_30B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_30B_Z = -8.0f;

  // ワープ鏡３１
  public const string EDELGARZEN_3_MIRROR_31_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_31_O = "31";
  public const float EDELGARZEN_3_MIRROR_31_X = 19.0f;
  public const float EDELGARZEN_3_MIRROR_31_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_31_Z = -17.0f;

  // ワープ鏡３１Ｂ
  public const string EDELGARZEN_3_MIRROR_31B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_31B_O = "31B";
  public const float EDELGARZEN_3_MIRROR_31B_X = 27.0f;
  public const float EDELGARZEN_3_MIRROR_31B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_31B_Z = -17.0f;

  // ワープ鏡３２
  public const string EDELGARZEN_3_MIRROR_32_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_32_O = "32";
  public const float EDELGARZEN_3_MIRROR_32_X = 21.0f;
  public const float EDELGARZEN_3_MIRROR_32_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_32_Z = -17.0f;

  // ワープ鏡３２Ｂ
  public const string EDELGARZEN_3_MIRROR_32B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_32B_O = "32B";
  public const float EDELGARZEN_3_MIRROR_32B_X = 49.0f;
  public const float EDELGARZEN_3_MIRROR_32B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_32B_Z = -12.0f;

  // ワープ鏡３３
  public const string EDELGARZEN_3_MIRROR_33_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_33_O = "33";
  public const float EDELGARZEN_3_MIRROR_33_X = 35.0f;
  public const float EDELGARZEN_3_MIRROR_33_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_33_Z = -29.0f;

  // ワープ鏡３３Ｂ
  public const string EDELGARZEN_3_MIRROR_33B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_33B_O = "33B";
  public const float EDELGARZEN_3_MIRROR_33B_X = 17.0f;
  public const float EDELGARZEN_3_MIRROR_33B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_33B_Z = -12.0f;

  // ワープ鏡３４
  public const string EDELGARZEN_3_MIRROR_34_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_34_O = "34";
  public const float EDELGARZEN_3_MIRROR_34_X = 35.0f;
  public const float EDELGARZEN_3_MIRROR_34_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_34_Z = -31.0f;

  // ワープ鏡３４Ｂ
  public const string EDELGARZEN_3_MIRROR_34B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_34B_O = "34B";
  public const float EDELGARZEN_3_MIRROR_34B_X = 48.0f;
  public const float EDELGARZEN_3_MIRROR_34B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_34B_Z = -31.0f;

  // ワープ鏡３５
  public const string EDELGARZEN_3_MIRROR_35_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_35_O = "35";
  public const float EDELGARZEN_3_MIRROR_35_X = 4.0f;
  public const float EDELGARZEN_3_MIRROR_35_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_35_Z = -14.0f;

  // ワープ鏡３５Ｂ
  public const string EDELGARZEN_3_MIRROR_35B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_35B_O = "35B";
  public const float EDELGARZEN_3_MIRROR_35B_X = 27.0f;
  public const float EDELGARZEN_3_MIRROR_35B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_35B_Z = -25.0f;

  // ワープ鏡３６
  public const string EDELGARZEN_3_MIRROR_36_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_36_O = "36";
  public const float EDELGARZEN_3_MIRROR_36_X = 6.0f;
  public const float EDELGARZEN_3_MIRROR_36_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_36_Z = -18.0f;

  // ワープ鏡３６Ｂ
  public const string EDELGARZEN_3_MIRROR_36B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_36B_O = "36B";
  public const float EDELGARZEN_3_MIRROR_36B_X = 8.0f;
  public const float EDELGARZEN_3_MIRROR_36B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_36B_Z = -19.0f;

  // ワープ鏡３７
  public const string EDELGARZEN_3_MIRROR_37_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_37_O = "37";
  public const float EDELGARZEN_3_MIRROR_37_X = 23.0f;
  public const float EDELGARZEN_3_MIRROR_37_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_37_Z = -13.0f;
  // ワープ鏡３７Ｂ（なし）

  // ワープ鏡３８
  public const string EDELGARZEN_3_MIRROR_38_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_38_O = "38";
  public const float EDELGARZEN_3_MIRROR_38_X = 23.0f;
  public const float EDELGARZEN_3_MIRROR_38_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_38_Z = -15.0f;
  // ワープ鏡３８Ｂ（なし）

  // ワープ鏡３９
  public const string EDELGARZEN_3_MIRROR_39_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_39_O = "39";
  public const float EDELGARZEN_3_MIRROR_39_X = 23.0f;
  public const float EDELGARZEN_3_MIRROR_39_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_39_Z = -17.0f;
  // ワープ鏡３９Ｂ（なし）

  // ワープ鏡４０
  public const string EDELGARZEN_3_MIRROR_40_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_40_O = "40";
  public const float EDELGARZEN_3_MIRROR_40_X = 54.0f;
  public const float EDELGARZEN_3_MIRROR_40_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_40_Z = -14.0f;
  // ワープ鏡４０Ｂ（なし）

  // ワープ鏡４１
  public const string EDELGARZEN_3_MIRROR_41_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_41_O = "41";
  public const float EDELGARZEN_3_MIRROR_41_X = 56.0f;
  public const float EDELGARZEN_3_MIRROR_41_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_41_Z = -14.0f;
  // ワープ鏡４１Ｂ（なし）

  // ワープ鏡４２
  public const string EDELGARZEN_3_MIRROR_42_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_42_O = "42";
  public const float EDELGARZEN_3_MIRROR_42_X = 17.0f;
  public const float EDELGARZEN_3_MIRROR_42_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_42_Z = -7.0f;
  // ワープ鏡４２Ｂ（なし）

  // ワープ鏡４３
  public const string EDELGARZEN_3_MIRROR_43_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_43_O = "43";
  public const float EDELGARZEN_3_MIRROR_43_X = 19.0f;
  public const float EDELGARZEN_3_MIRROR_43_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_43_Z = -7.0f;
  // ワープ鏡４３Ｂ（なし）

  // ワープ鏡４４
  public const string EDELGARZEN_3_MIRROR_44_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_44_O = "44";
  public const float EDELGARZEN_3_MIRROR_44_X = 21.0f;
  public const float EDELGARZEN_3_MIRROR_44_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_44_Z = -7.0f;
  // ワープ鏡４４Ｂ（なし）

  // ワープ鏡４５
  public const string EDELGARZEN_3_MIRROR_45_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_45_O = "45";
  public const float EDELGARZEN_3_MIRROR_45_X = 43.0f;
  public const float EDELGARZEN_3_MIRROR_45_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_45_Z = -30.0f;
  // ワープ鏡４５Ｂ（なし）

  // ワープ鏡４６
  public const string EDELGARZEN_3_MIRROR_46_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_46_O = "46";
  public const float EDELGARZEN_3_MIRROR_46_X = 43.0f;
  public const float EDELGARZEN_3_MIRROR_46_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_46_Z = -32.0f;
  // ワープ鏡４６Ｂ（なし）

  // ワープ鏡４７
  public const string EDELGARZEN_3_MIRROR_47_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_47_O = "47";
  public const float EDELGARZEN_3_MIRROR_47_X = 23.0f;
  public const float EDELGARZEN_3_MIRROR_47_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_47_Z = -23.0f;
  // ワープ鏡４７Ｂ（なし）

  // ワープ鏡４８
  public const string EDELGARZEN_3_MIRROR_48_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_48_O = "48";
  public const float EDELGARZEN_3_MIRROR_48_X = 23.0f;
  public const float EDELGARZEN_3_MIRROR_48_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_48_Z = -25.0f;
  // ワープ鏡４８Ｂ（なし）

  // ワープ鏡４９
  public const string EDELGARZEN_3_MIRROR_49_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_49_O = "49";
  public const float EDELGARZEN_3_MIRROR_49_X = 23.0f;
  public const float EDELGARZEN_3_MIRROR_49_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_49_Z = -27.0f;
  // ワープ鏡４９Ｂ（なし）

  // ワープ鏡５０
  public const string EDELGARZEN_3_MIRROR_50_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_50_O = "50";
  public const float EDELGARZEN_3_MIRROR_50_X = 17.0f;
  public const float EDELGARZEN_3_MIRROR_50_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_50_Z = -14.0f;
  // ワープ鏡５０Ｂ（なし）

  // ワープ鏡５１
  public const string EDELGARZEN_3_MIRROR_51_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_51_O = "51";
  public const float EDELGARZEN_3_MIRROR_51_X = 22.0f;
  public const float EDELGARZEN_3_MIRROR_51_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_51_Z = -19.0f;
  // ワープ鏡５１Ｂ（なし）

  // ワープ鏡５２
  public const string EDELGARZEN_3_MIRROR_52_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_52_O = "52";
  public const float EDELGARZEN_3_MIRROR_52_X = 17.0f;
  public const float EDELGARZEN_3_MIRROR_52_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_52_Z = -24.0f;
  // ワープ鏡５２Ｂ（なし）

  // ワープ鏡５３
  public const string EDELGARZEN_3_MIRROR_53_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_53_O = "53";
  public const float EDELGARZEN_3_MIRROR_53_X = 15.0f;
  public const float EDELGARZEN_3_MIRROR_53_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_53_Z = -9.0f;

  // ワープ鏡５３Ｂ
  public const string EDELGARZEN_3_MIRROR_53B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_53B_O = "53B";
  public const float EDELGARZEN_3_MIRROR_53B_X = 50.0f;
  public const float EDELGARZEN_3_MIRROR_53B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_53B_Z = -30.0f;

  // ワープ鏡５４
  public const string EDELGARZEN_3_MIRROR_54_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_54_O = "54";
  public const float EDELGARZEN_3_MIRROR_54_X = 49.0f;
  public const float EDELGARZEN_3_MIRROR_54_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_54_Z = -21.0f;

  // ワープ鏡５４Ｂ
  public const string EDELGARZEN_3_MIRROR_54B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_54B_O = "54B";
  public const float EDELGARZEN_3_MIRROR_54B_X = 12.0f;
  public const float EDELGARZEN_3_MIRROR_54B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_54B_Z = -31.0f;

  // ワープ鏡５５
  public const string EDELGARZEN_3_MIRROR_55_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_55_O = "55";
  public const float EDELGARZEN_3_MIRROR_55_X = 49.0f;
  public const float EDELGARZEN_3_MIRROR_55_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_55_Z = -24.0f;

  // ワープ鏡５５Ｂ
  public const string EDELGARZEN_3_MIRROR_55B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_55B_O = "55B";
  public const float EDELGARZEN_3_MIRROR_55B_X = 50.0f;
  public const float EDELGARZEN_3_MIRROR_55B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_55B_Z = -10.0f;

  // ワープ鏡５６
  public const string EDELGARZEN_3_MIRROR_56_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_56_O = "56";
  public const float EDELGARZEN_3_MIRROR_56_X = 49.0f;
  public const float EDELGARZEN_3_MIRROR_56_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_56_Z = -27.0f;

  // ワープ鏡５６Ｂ
  public const string EDELGARZEN_3_MIRROR_56B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_56B_O = "56B";
  public const float EDELGARZEN_3_MIRROR_56B_X = 22.0f;
  public const float EDELGARZEN_3_MIRROR_56B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_56B_Z = -33.0f;

  // ワープ鏡５７
  public const string EDELGARZEN_3_MIRROR_57_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_57_O = "57";
  public const float EDELGARZEN_3_MIRROR_57_X = 13.0f;
  public const float EDELGARZEN_3_MIRROR_57_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_57_Z = -21.0f;

  // ワープ鏡５７Ｂ
  public const string EDELGARZEN_3_MIRROR_57B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_57B_O = "57B";
  public const float EDELGARZEN_3_MIRROR_57B_X = 27.0f;
  public const float EDELGARZEN_3_MIRROR_57B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_57B_Z = -27.0f;

  // ワープ鏡５８
  public const string EDELGARZEN_3_MIRROR_58_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_58_O = "58";
  public const float EDELGARZEN_3_MIRROR_58_X = 15.0f;
  public const float EDELGARZEN_3_MIRROR_58_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_58_Z = -21.0f;

  // ワープ鏡５８Ｂ
  public const string EDELGARZEN_3_MIRROR_58B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_58B_O = "58B";
  public const float EDELGARZEN_3_MIRROR_58B_X = 51.0f;
  public const float EDELGARZEN_3_MIRROR_58B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_58B_Z = -3.0f;

  // ワープ鏡５９
  public const string EDELGARZEN_3_MIRROR_59_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_59_O = "59";
  public const float EDELGARZEN_3_MIRROR_59_X = 41.0f;
  public const float EDELGARZEN_3_MIRROR_59_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_59_Z = -5.0f;

  // ワープ鏡５９Ｂ
  public const string EDELGARZEN_3_MIRROR_59B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_59B_O = "59B";
  public const float EDELGARZEN_3_MIRROR_59B_X = 48.0f;
  public const float EDELGARZEN_3_MIRROR_59B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_59B_Z = -29.0f;

  // ワープ鏡６０
  public const string EDELGARZEN_3_MIRROR_60_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_60_O = "60";
  public const float EDELGARZEN_3_MIRROR_60_X = 41.0f;
  public const float EDELGARZEN_3_MIRROR_60_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_60_Z = -14.0f;

  // ワープ鏡６０Ｂ
  public const string EDELGARZEN_3_MIRROR_60B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_60B_O = "60B";
  public const float EDELGARZEN_3_MIRROR_60B_X = 33.0f;
  public const float EDELGARZEN_3_MIRROR_60B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_60B_Z = -18.0f;

  // ワープ鏡６１
  public const string EDELGARZEN_3_MIRROR_61_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_61_O = "61";
  public const float EDELGARZEN_3_MIRROR_61_X = 21.0f;
  public const float EDELGARZEN_3_MIRROR_61_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_61_Z = -23.0f;

  // ワープ鏡６１Ｂ
  public const string EDELGARZEN_3_MIRROR_61B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_61B_O = "61B";
  public const float EDELGARZEN_3_MIRROR_61B_X = 12.0f;
  public const float EDELGARZEN_3_MIRROR_61B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_61B_Z = -17.0f;

  // ワープ鏡６２
  public const string EDELGARZEN_3_MIRROR_62_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_62_O = "62";
  public const float EDELGARZEN_3_MIRROR_62_X = 21.0f;
  public const float EDELGARZEN_3_MIRROR_62_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_62_Z = -31.0f;

  // ワープ鏡６２Ｂ
  public const string EDELGARZEN_3_MIRROR_62B_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_62B_O = "62B";
  public const float EDELGARZEN_3_MIRROR_62B_X = 18.0f;
  public const float EDELGARZEN_3_MIRROR_62B_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_62B_Z = -26.0f;

  // ワープ鏡６３
  public const string EDELGARZEN_3_MIRROR_63_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_63_O = "63";
  public const float EDELGARZEN_3_MIRROR_63_X = 23.0f;
  public const float EDELGARZEN_3_MIRROR_63_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_63_Z = -29.0f;
  // ワープ鏡６３Ｂ（なし）

  // ワープ鏡６４
  public const string EDELGARZEN_3_MIRROR_64_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_64_O = "64";
  public const float EDELGARZEN_3_MIRROR_64_X = 25.0f;
  public const float EDELGARZEN_3_MIRROR_64_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_64_Z = -30.0f;
  // ワープ鏡６４Ｂ（なし）

  // ワープ鏡６５
  public const string EDELGARZEN_3_MIRROR_65_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_65_O = "65";
  public const float EDELGARZEN_3_MIRROR_65_X = 23.0f;
  public const float EDELGARZEN_3_MIRROR_65_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_65_Z = -31.0f;
  // ワープ鏡６５Ｂ（なし）

  // ワープ鏡６６
  public const string EDELGARZEN_3_MIRROR_66_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_66_O = "66";
  public const float EDELGARZEN_3_MIRROR_66_X = 25.0f;
  public const float EDELGARZEN_3_MIRROR_66_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_66_Z = -32.0f;
  // ワープ鏡６６Ｂ（なし）

  // ワープ鏡６７
  public const string EDELGARZEN_3_MIRROR_67_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_67_O = "67";
  public const float EDELGARZEN_3_MIRROR_67_X = 37.0f;
  public const float EDELGARZEN_3_MIRROR_67_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_67_Z = -7.0f;
  // ワープ鏡６７Ｂ（なし）

  // ワープ鏡６８
  public const string EDELGARZEN_3_MIRROR_68_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_68_O = "68";
  public const float EDELGARZEN_3_MIRROR_68_X = 39.0f;
  public const float EDELGARZEN_3_MIRROR_68_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_68_Z = -7.0f;
  // ワープ鏡６８Ｂ（なし）

  // ワープ鏡６９
  public const string EDELGARZEN_3_MIRROR_69_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_69_O = "69";
  public const float EDELGARZEN_3_MIRROR_69_X = 43.0f;
  public const float EDELGARZEN_3_MIRROR_69_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_69_Z = -24.0f;
  // ワープ鏡６９Ｂ（なし）

  // ワープ鏡７０
  public const string EDELGARZEN_3_MIRROR_70_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_70_O = "70";
  public const float EDELGARZEN_3_MIRROR_70_X = 43.0f;
  public const float EDELGARZEN_3_MIRROR_70_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_70_Z = -26.0f;
  // ワープ鏡７０Ｂ（なし）

  // ワープ鏡７１
  public const string EDELGARZEN_3_MIRROR_71_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_71_O = "71";
  public const float EDELGARZEN_3_MIRROR_71_X = 43.0f;
  public const float EDELGARZEN_3_MIRROR_71_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_71_Z = -28.0f;
  // ワープ鏡７１Ｂ（なし）

  // ワープ鏡７２
  public const string EDELGARZEN_3_MIRROR_72_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_72_O = "72";
  public const float EDELGARZEN_3_MIRROR_72_X = 35.0f;
  public const float EDELGARZEN_3_MIRROR_72_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_72_Z = -18.0f;
  // ワープ鏡７２Ｂ（なし）

  // ワープ鏡７３
  public const string EDELGARZEN_3_MIRROR_73_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_73_O = "73";
  public const float EDELGARZEN_3_MIRROR_73_X = 37.0f;
  public const float EDELGARZEN_3_MIRROR_73_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_73_Z = -18.0f;
  // ワープ鏡７３Ｂ（なし）

  // ワープ鏡７４
  public const string EDELGARZEN_3_MIRROR_74_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_74_O = "74";
  public const float EDELGARZEN_3_MIRROR_74_X = 39.0f;
  public const float EDELGARZEN_3_MIRROR_74_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_74_Z = -18.0f;
  // ワープ鏡７４Ｂ（なし）

  // ワープ鏡７５
  public const string EDELGARZEN_3_MIRROR_75_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_75_O = "75";
  public const float EDELGARZEN_3_MIRROR_75_X = 12.0f;
  public const float EDELGARZEN_3_MIRROR_75_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_75_Z = -11.0f;
  // ワープ鏡７５Ｂ（なし）

  // ワープ鏡７６
  public const string EDELGARZEN_3_MIRROR_76_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_76_O = "76";
  public const float EDELGARZEN_3_MIRROR_76_X = 12.0f;
  public const float EDELGARZEN_3_MIRROR_76_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_76_Z = -13.0f;
  // ワープ鏡７６Ｂ（なし）

  // ワープ鏡７７
  public const string EDELGARZEN_3_MIRROR_77_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_77_O = "77";
  public const float EDELGARZEN_3_MIRROR_77_X = 12.0f;
  public const float EDELGARZEN_3_MIRROR_77_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_77_Z = -15.0f;
  // ワープ鏡７７Ｂ（なし）

  // ワープ鏡７８
  public const string EDELGARZEN_3_MIRROR_78_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_78_O = "78";
  public const float EDELGARZEN_3_MIRROR_78_X = 24.0f;
  public const float EDELGARZEN_3_MIRROR_78_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_78_Z = -19.0f;
  // ワープ鏡７８Ｂ（なし）

  // ワープ鏡７９
  public const string EDELGARZEN_3_MIRROR_79_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_79_O = "79";
  public const float EDELGARZEN_3_MIRROR_79_X = 27.0f;
  public const float EDELGARZEN_3_MIRROR_79_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_79_Z = -23.0f;
  // ワープ鏡７９Ｂ（なし）

  // ワープ鏡８０（Ａルート１）
  public const string EDELGARZEN_3_MIRROR_80_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_80_O = "80";
  public const float EDELGARZEN_3_MIRROR_80_X = 7.0f;
  public const float EDELGARZEN_3_MIRROR_80_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_80_Z = -2.0f;

  // ワープ鏡８１（Ａルート２）
  public const string EDELGARZEN_3_MIRROR_81_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_81_O = "81";
  public const float EDELGARZEN_3_MIRROR_81_X = 3.0f;
  public const float EDELGARZEN_3_MIRROR_81_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_81_Z = -8.0f;

  // ワープ鏡８２（Ａルート３）
  public const string EDELGARZEN_3_MIRROR_82_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_82_O = "82";
  public const float EDELGARZEN_3_MIRROR_82_X = 3.0f;
  public const float EDELGARZEN_3_MIRROR_82_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_82_Z = -33.0f;

  // ワープ鏡８３（Ａルート４）
  public const string EDELGARZEN_3_MIRROR_83_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_83_O = "83";
  public const float EDELGARZEN_3_MIRROR_83_X = 7.0f;
  public const float EDELGARZEN_3_MIRROR_83_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_83_Z = -37.0f;

  // ワープ鏡８４（Ａルート５）
  public const string EDELGARZEN_3_MIRROR_84_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_84_O = "84";
  public const float EDELGARZEN_3_MIRROR_84_X = 27.0f;
  public const float EDELGARZEN_3_MIRROR_84_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_84_Z = -37.0f;

  // ワープ鏡８５（Ｂルート１）
  public const string EDELGARZEN_3_MIRROR_85_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_85_O = "85";
  public const float EDELGARZEN_3_MIRROR_85_X = 53.0f;
  public const float EDELGARZEN_3_MIRROR_85_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_85_Z = -2.0f;

  // ワープ鏡８６（Ｂルート２）
  public const string EDELGARZEN_3_MIRROR_86_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_86_O = "86";
  public const float EDELGARZEN_3_MIRROR_86_X = 57.0f;
  public const float EDELGARZEN_3_MIRROR_86_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_86_Z = -8.0f;

  // ワープ鏡８７（Ｂルート３）
  public const string EDELGARZEN_3_MIRROR_87_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_87_O = "87";
  public const float EDELGARZEN_3_MIRROR_87_X = 57.0f;
  public const float EDELGARZEN_3_MIRROR_87_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_87_Z = -33.0f;

  // ワープ鏡８８（Ｂルート４）
  public const string EDELGARZEN_3_MIRROR_88_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_88_O = "88";
  public const float EDELGARZEN_3_MIRROR_88_X = 53.0f;
  public const float EDELGARZEN_3_MIRROR_88_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_88_Z = -37.0f;

  // ワープ鏡８９（Ｂルート５）
  public const string EDELGARZEN_3_MIRROR_89_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_89_O = "89";
  public const float EDELGARZEN_3_MIRROR_89_X = 33.0f;
  public const float EDELGARZEN_3_MIRROR_89_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_89_Z = -37.0f;

  // ワープ鏡９０（Ｃルート）
  public const string EDELGARZEN_3_MIRROR_90_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_90_O = "90";
  public const float EDELGARZEN_3_MIRROR_90_X = 30.0f;
  public const float EDELGARZEN_3_MIRROR_90_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_90_Z = -21.0f;

  // ワープ鏡９１（Ｄルート１）
  public const string EDELGARZEN_3_MIRROR_91_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_91_O = "91";
  public const float EDELGARZEN_3_MIRROR_91_X = 30.0f;
  public const float EDELGARZEN_3_MIRROR_91_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_91_Z = -19.0f;

  // ワープ鏡９２（Ｄルート左）
  public const string EDELGARZEN_3_MIRROR_92_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_92_O = "92";
  public const float EDELGARZEN_3_MIRROR_92_X = 29.0f;
  public const float EDELGARZEN_3_MIRROR_92_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_92_Z = -15.0f;

  // ワープ鏡９３（Ｄルート右）
  public const string EDELGARZEN_3_MIRROR_93_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_93_O = "93";
  public const float EDELGARZEN_3_MIRROR_93_X = 31.0f;
  public const float EDELGARZEN_3_MIRROR_93_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_93_Z = -15.0f;

  // ワープ鏡９４（最終地点）
  public const string EDELGARZEN_3_MIRROR_94_C = "Mirror";
  public const string EDELGARZEN_3_MIRROR_94_O = "94";
  public const float EDELGARZEN_3_MIRROR_94_X = 30.0f;
  public const float EDELGARZEN_3_MIRROR_94_Y = 0.5f;
  public const float EDELGARZEN_3_MIRROR_94_Z = -38.0f;
  #endregion
  #region "Treasure"
  public const string EDELGARZEN_3_Treasure_1_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_1_O = "1";
  public const float EDELGARZEN_3_Treasure_1_X = 45.0f;
  public const float EDELGARZEN_3_Treasure_1_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_1_Z = -6.0f;

  public const string EDELGARZEN_3_Treasure_2_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_2_O = "2";
  public const float EDELGARZEN_3_Treasure_2_X = 14.0f;
  public const float EDELGARZEN_3_Treasure_2_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_2_Z = -23.0f;

  public const string EDELGARZEN_3_Treasure_3_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_3_O = "3";
  public const float EDELGARZEN_3_Treasure_3_X = 37.0f;
  public const float EDELGARZEN_3_Treasure_3_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_3_Z = -30.0f;

  public const string EDELGARZEN_3_Treasure_4_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_4_O = "4";
  public const float EDELGARZEN_3_Treasure_4_X = 9.0f;
  public const float EDELGARZEN_3_Treasure_4_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_4_Z = -3.0f;

  public const string EDELGARZEN_3_Treasure_5_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_5_O = "5";
  public const float EDELGARZEN_3_Treasure_5_X = 5.0f;
  public const float EDELGARZEN_3_Treasure_5_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_5_Z = -10.0f;

  public const string EDELGARZEN_3_Treasure_6_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_6_O = "6";
  public const float EDELGARZEN_3_Treasure_6_X = 17.0f;
  public const float EDELGARZEN_3_Treasure_6_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_6_Z = -19.0f;

  public const string EDELGARZEN_3_Treasure_7_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_7_O = "7";
  public const float EDELGARZEN_3_Treasure_7_X = 44.0f;
  public const float EDELGARZEN_3_Treasure_7_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_7_Z = -31.0f;

  public const string EDELGARZEN_3_Treasure_8_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_8_O = "8";
  public const float EDELGARZEN_3_Treasure_8_X = 6.0f;
  public const float EDELGARZEN_3_Treasure_8_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_8_Z = -20.0f;

  public const string EDELGARZEN_3_Treasure_9_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_9_O = "9";
  public const float EDELGARZEN_3_Treasure_9_X = 14.0f;
  public const float EDELGARZEN_3_Treasure_9_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_9_Z = -13.0f;

  public const string EDELGARZEN_3_Treasure_10_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_10_O = "10";
  public const float EDELGARZEN_3_Treasure_10_X = 41.0f;
  public const float EDELGARZEN_3_Treasure_10_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_10_Z = -22.0f;

  public const string EDELGARZEN_3_Treasure_11_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_11_O = "11";
  public const float EDELGARZEN_3_Treasure_11_X = 28.0f;
  public const float EDELGARZEN_3_Treasure_11_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_11_Z = -13.0f;

  public const string EDELGARZEN_3_Treasure_12_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_12_O = "12";
  public const float EDELGARZEN_3_Treasure_12_X = 32.0f;
  public const float EDELGARZEN_3_Treasure_12_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_12_Z = -13.0f;

  public const string EDELGARZEN_3_Treasure_13_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_13_O = "13";
  public const float EDELGARZEN_3_Treasure_13_X = 3.0f;
  public const float EDELGARZEN_3_Treasure_13_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_13_Z = -37.0f;

  public const string EDELGARZEN_3_Treasure_14_C = "Treasure";
  public const string EDELGARZEN_3_Treasure_14_O = "14";
  public const float EDELGARZEN_3_Treasure_14_X = 57.0f;
  public const float EDELGARZEN_3_Treasure_14_Y = 1.0f;
  public const float EDELGARZEN_3_Treasure_14_Z = -37.0f;
  #endregion
  #region "Edelgarzen Door"
  public const string EDELGARZEN_3_DOOR_1_C = "Edelgarzen_Door";
  public const string EDELGARZEN_3_DOOR_1_O = "1";
  public const float EDELGARZEN_3_DOOR_1_X = 30.0f;
  public const float EDELGARZEN_3_DOOR_1_Y = 0.5f;
  public const float EDELGARZEN_3_DOOR_1_Z = -36.0f;

  public const string EDELGARZEN_3_DOOR_2_C = "Edelgarzen_Door";
  public const string EDELGARZEN_3_DOOR_2_O = "2";
  public const float EDELGARZEN_3_DOOR_2_X = 30.0f;
  public const float EDELGARZEN_3_DOOR_2_Y = 0.5f;
  public const float EDELGARZEN_3_DOOR_2_Z = -11.0f;
  #endregion
  #region "階段"
  // 下り階段( 左上のエントランス )
  public const string EDELGARZEN_3_DOWNSTAIR_1_C = "Downstair";
  public const string EDELGARZEN_3_DOWNSTAIR_1_O = "1";
  public const float EDELGARZEN_3_DOWNSTAIR_1_X = 9.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_1_Y = 0.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_1_Z = -7.0f;

  // 下り階段( Ａルートの左上 )
  public const string EDELGARZEN_3_DOWNSTAIR_2_C = "Downstair";
  public const string EDELGARZEN_3_DOWNSTAIR_2_O = "2";
  public const float EDELGARZEN_3_DOWNSTAIR_2_X = 1.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_2_Y = 0.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_2_Z = -2.0f;

  // 下り階段( Ｂルートの右上 )
  public const string EDELGARZEN_3_DOWNSTAIR_3_C = "Downstair";
  public const string EDELGARZEN_3_DOWNSTAIR_3_O = "3";
  public const float EDELGARZEN_3_DOWNSTAIR_3_X = 59.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_3_Y = 0.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_3_Z = -2.0f;

  // 下り階段( Ｄルートの中央下 )
  public const string EDELGARZEN_3_DOWNSTAIR_4_C = "Downstair";
  public const string EDELGARZEN_3_DOWNSTAIR_4_O = "4";
  public const float EDELGARZEN_3_DOWNSTAIR_4_X = 30.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_4_Y = 0.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_4_Z = -35.0f;

  // 下り階段( 最上階ルートの中央 )
  public const string EDELGARZEN_3_DOWNSTAIR_5_C = "Downstair";
  public const string EDELGARZEN_3_DOWNSTAIR_5_O = "5";
  public const float EDELGARZEN_3_DOWNSTAIR_5_X = 30.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_5_Y = 0.0f;
  public const float EDELGARZEN_3_DOWNSTAIR_5_Z = -13.0f;

  // 上り階段( 最上階ルートの上 )
  public const string EDELGARZEN_3_UPSTAIR_6_C = "Upstair";
  public const string EDELGARZEN_3_UPSTAIR_6_O = "6";
  public const float EDELGARZEN_3_UPSTAIR_6_X = 30.0f;
  public const float EDELGARZEN_3_UPSTAIR_6_Y = 0.0f;
  public const float EDELGARZEN_3_UPSTAIR_6_Z = -2.0f;
  #endregion
  #region "Event"
  // エントランス
  public const string EDELGARZEN_3_Event_1_C = "Event";
  public const string EDELGARZEN_3_Event_1_O = "1";
  public const float EDELGARZEN_3_Event_1_X = 12.0f;
  public const float EDELGARZEN_3_Event_1_Y = 0.0f;
  public const float EDELGARZEN_3_Event_1_Z = -7.0f;

  // 区画１( -> 2,3,4 )
  public const string EDELGARZEN_3_Event_2_C = "Event";
  public const string EDELGARZEN_3_Event_2_O = "2";
  public const float EDELGARZEN_3_Event_2_X = 35.0f;
  public const float EDELGARZEN_3_Event_2_Y = 0.0f;
  public const float EDELGARZEN_3_Event_2_Z = -24.0f;

  // 区画２( -> 5,6 )
  public const string EDELGARZEN_3_Event_3_C = "Event";
  public const string EDELGARZEN_3_Event_3_O = "3";
  public const float EDELGARZEN_3_Event_3_X = 16.0f;
  public const float EDELGARZEN_3_Event_3_Y = 0.0f;
  public const float EDELGARZEN_3_Event_3_Z = -28.0f;

  // 区画３( -> 7,8 )
  public const string EDELGARZEN_3_Event_4_C = "Event";
  public const string EDELGARZEN_3_Event_4_O = "4";
  public const float EDELGARZEN_3_Event_4_X = 39.0f;
  public const float EDELGARZEN_3_Event_4_Y = 0.0f;
  public const float EDELGARZEN_3_Event_4_Z = -11.0f;

  // 区画４( -> 9,10 )
  public const string EDELGARZEN_3_Event_5_C = "Event";
  public const string EDELGARZEN_3_Event_5_O = "5";
  public const float EDELGARZEN_3_Event_5_X = 7.0f;
  public const float EDELGARZEN_3_Event_5_Y = 0.0f;
  public const float EDELGARZEN_3_Event_5_Z = -5.0f;

  // 区画５( -> 11,12,13 )
  public const string EDELGARZEN_3_Event_6_C = "Event";
  public const string EDELGARZEN_3_Event_6_O = "6";
  public const float EDELGARZEN_3_Event_6_X = 47.0f;
  public const float EDELGARZEN_3_Event_6_Y = 0.0f;
  public const float EDELGARZEN_3_Event_6_Z = -14.0f;

  // 区画６( -> 14,15,16 )
  public const string EDELGARZEN_3_Event_7_C = "Event";
  public const string EDELGARZEN_3_Event_7_O = "7";
  public const float EDELGARZEN_3_Event_7_X = 43.0f;
  public const float EDELGARZEN_3_Event_7_Y = 0.0f;
  public const float EDELGARZEN_3_Event_7_Z = -16.0f;

  // 区画７( -> 17,18,19 )
  public const string EDELGARZEN_3_Event_8_C = "Event";
  public const string EDELGARZEN_3_Event_8_O = "8";
  public const float EDELGARZEN_3_Event_8_X = 11.0f;
  public const float EDELGARZEN_3_Event_8_Y = 0.0f;
  public const float EDELGARZEN_3_Event_8_Z = -27.0f;

  // 区画８( -> 20,21 )
  public const string EDELGARZEN_3_Event_9_C = "Event";
  public const string EDELGARZEN_3_Event_9_O = "9";
  public const float EDELGARZEN_3_Event_9_X = 33.0f;
  public const float EDELGARZEN_3_Event_9_Y = 0.0f;
  public const float EDELGARZEN_3_Event_9_Z = -33.0f;

  // 区画９( -> 22,23 )
  public const string EDELGARZEN_3_Event_10_C = "Event";
  public const string EDELGARZEN_3_Event_10_O = "10";
  public const float EDELGARZEN_3_Event_10_X = 53.0f;
  public const float EDELGARZEN_3_Event_10_Y = 0.0f;
  public const float EDELGARZEN_3_Event_10_Z = -17.0f;

  // 区画１０( -> 24,25,26 )
  public const string EDELGARZEN_3_Event_11_C = "Event";
  public const string EDELGARZEN_3_Event_11_O = "11";
  public const float EDELGARZEN_3_Event_11_X = 41.0f;
  public const float EDELGARZEN_3_Event_11_Y = 0.0f;
  public const float EDELGARZEN_3_Event_11_Z = -22.0f;

  // 区画２７( -> 28,29,30 )
  public const string EDELGARZEN_3_Event_12_C = "Event";
  public const string EDELGARZEN_3_Event_12_O = "12";
  public const float EDELGARZEN_3_Event_12_X = 47.0f;
  public const float EDELGARZEN_3_Event_12_Y = 0.0f;
  public const float EDELGARZEN_3_Event_12_Z = -5.0f;

  // 区画２８( -> 31,32 )
  public const string EDELGARZEN_3_Event_13_C = "Event";
  public const string EDELGARZEN_3_Event_13_O = "13";
  public const float EDELGARZEN_3_Event_13_X = 21.0f;
  public const float EDELGARZEN_3_Event_13_Y = 0.0f;
  public const float EDELGARZEN_3_Event_13_Z = -13.0f;

  // 区画２９( -> 33,34 )
  public const string EDELGARZEN_3_Event_14_C = "Event";
  public const string EDELGARZEN_3_Event_14_O = "14";
  public const float EDELGARZEN_3_Event_14_X = 39.0f;
  public const float EDELGARZEN_3_Event_14_Y = 0.0f;
  public const float EDELGARZEN_3_Event_14_Z = -30.0f;

  // 区画３０( -> 35,36 )
  public const string EDELGARZEN_3_Event_15_C = "Event";
  public const string EDELGARZEN_3_Event_15_O = "15";
  public const float EDELGARZEN_3_Event_15_X = 6.0f;
  public const float EDELGARZEN_3_Event_15_Y = 0.0f;
  public const float EDELGARZEN_3_Event_15_Z = -11.0f;

  // 区画３１( -> 37,38,39 )
  public const string EDELGARZEN_3_Event_16_C = "Event";
  public const string EDELGARZEN_3_Event_16_O = "16";
  public const float EDELGARZEN_3_Event_16_X = 25.0f;
  public const float EDELGARZEN_3_Event_16_Y = 0.0f;
  public const float EDELGARZEN_3_Event_16_Z = -13.0f;

  // 区画３２( -> 40,41 )
  public const string EDELGARZEN_3_Event_17_C = "Event";
  public const string EDELGARZEN_3_Event_17_O = "17";
  public const float EDELGARZEN_3_Event_17_X = 55.0f;
  public const float EDELGARZEN_3_Event_17_Y = 0.0f;
  public const float EDELGARZEN_3_Event_17_Z = -12.0f;

  // 区画３３( -> 42,43,44 )
  public const string EDELGARZEN_3_Event_18_C = "Event";
  public const string EDELGARZEN_3_Event_18_O = "18";
  public const float EDELGARZEN_3_Event_18_X = 19.0f;
  public const float EDELGARZEN_3_Event_18_Y = 0.0f;
  public const float EDELGARZEN_3_Event_18_Z = -9.0f;

  // 区画３４( -> 45,46 )
  public const string EDELGARZEN_3_Event_19_C = "Event";
  public const string EDELGARZEN_3_Event_19_O = "19";
  public const float EDELGARZEN_3_Event_19_X = 45.0f;
  public const float EDELGARZEN_3_Event_19_Y = 0.0f;
  public const float EDELGARZEN_3_Event_19_Z = -31.0f;

  // 区画３５( -> 47,48,49 )
  public const string EDELGARZEN_3_Event_20_C = "Event";
  public const string EDELGARZEN_3_Event_20_O = "20";
  public const float EDELGARZEN_3_Event_20_X = 25.0f;
  public const float EDELGARZEN_3_Event_20_Y = 0.0f;
  public const float EDELGARZEN_3_Event_20_Z = -25.0f;

  // 区画３６( -> 50,51,52 )
  public const string EDELGARZEN_3_Event_21_C = "Event";
  public const string EDELGARZEN_3_Event_21_O = "21";
  public const float EDELGARZEN_3_Event_21_X = 17.0f;
  public const float EDELGARZEN_3_Event_21_Y = 0.0f;
  public const float EDELGARZEN_3_Event_21_Z = -19.0f;

  // 区画５３( -> 54,55,56 )
  public const string EDELGARZEN_3_Event_22_C = "Event";
  public const string EDELGARZEN_3_Event_22_O = "22";
  public const float EDELGARZEN_3_Event_22_X = 50.0f;
  public const float EDELGARZEN_3_Event_22_Y = 0.0f;
  public const float EDELGARZEN_3_Event_22_Z = -24.0f;

  // 区画５４( -> 57,58 )
  public const string EDELGARZEN_3_Event_23_C = "Event";
  public const string EDELGARZEN_3_Event_23_O = "23";
  public const float EDELGARZEN_3_Event_23_X = 14.0f;
  public const float EDELGARZEN_3_Event_23_Y = 0.0f;
  public const float EDELGARZEN_3_Event_23_Z = -24.0f;

  // 区画５５( -> 59,60 )
  public const string EDELGARZEN_3_Event_24_C = "Event";
  public const string EDELGARZEN_3_Event_24_O = "24";
  public const float EDELGARZEN_3_Event_24_X = 41.0f;
  public const float EDELGARZEN_3_Event_24_Y = 0.0f;
  public const float EDELGARZEN_3_Event_24_Z = -10.0f;

  // 区画５６( -> 61,62 )
  public const string EDELGARZEN_3_Event_25_C = "Event";
  public const string EDELGARZEN_3_Event_25_O = "25";
  public const float EDELGARZEN_3_Event_25_X = 21.0f;
  public const float EDELGARZEN_3_Event_25_Y = 0.0f;
  public const float EDELGARZEN_3_Event_25_Z = -28.0f;

  // 区画５７( -> 63,64,65,66 )
  public const string EDELGARZEN_3_Event_26_C = "Event";
  public const string EDELGARZEN_3_Event_26_O = "26";
  public const float EDELGARZEN_3_Event_26_X = 24.0f;
  public const float EDELGARZEN_3_Event_26_Y = 0.0f;
  public const float EDELGARZEN_3_Event_26_Z = -34.0f;

  // 区画５８( -> 67,68 )
  public const string EDELGARZEN_3_Event_27_C = "Event";
  public const string EDELGARZEN_3_Event_27_O = "27";
  public const float EDELGARZEN_3_Event_27_X = 37.0f;
  public const float EDELGARZEN_3_Event_27_Y = 0.0f;
  public const float EDELGARZEN_3_Event_27_Z = -5.0f;

  // 区画５９( -> 69,70,71 )
  public const string EDELGARZEN_3_Event_28_C = "Event";
  public const string EDELGARZEN_3_Event_28_O = "28";
  public const float EDELGARZEN_3_Event_28_X = 45.0f;
  public const float EDELGARZEN_3_Event_28_Y = 0.0f;
  public const float EDELGARZEN_3_Event_28_Z = -24.0f;

  // 区画６０( -> 72,73,74 )
  public const string EDELGARZEN_3_Event_29_C = "Event";
  public const string EDELGARZEN_3_Event_29_O = "29";
  public const float EDELGARZEN_3_Event_29_X = 37.0f;
  public const float EDELGARZEN_3_Event_29_Y = 0.0f;
  public const float EDELGARZEN_3_Event_29_Z = -15.0f;

  // 区画６１( -> 75,76,77 )
  public const string EDELGARZEN_3_Event_30_C = "Event";
  public const string EDELGARZEN_3_Event_30_O = "30";
  public const float EDELGARZEN_3_Event_30_X = 15.0f;
  public const float EDELGARZEN_3_Event_30_Y = 0.0f;
  public const float EDELGARZEN_3_Event_30_Z = -15.0f;

  // 区画６２( -> 78,79 )
  public const string EDELGARZEN_3_Event_31_C = "Event";
  public const string EDELGARZEN_3_Event_31_O = "31";
  public const float EDELGARZEN_3_Event_31_X = 27.0f;
  public const float EDELGARZEN_3_Event_31_Y = 0.0f;
  public const float EDELGARZEN_3_Event_31_Z = -21.0f;

  // Ｃルートの中央下
  public const string EDELGARZEN_3_Event_32_C = "Event";
  public const string EDELGARZEN_3_Event_32_O = "32";
  public const float EDELGARZEN_3_Event_32_X = 30.0f;
  public const float EDELGARZEN_3_Event_32_Y = 0.0f;
  public const float EDELGARZEN_3_Event_32_Z = -33.0f;

  // Ｄルート
  public const string EDELGARZEN_3_Event_33_C = "Event";
  public const string EDELGARZEN_3_Event_33_O = "33";
  public const float EDELGARZEN_3_Event_33_X = 30.0f;
  public const float EDELGARZEN_3_Event_33_Y = 0.0f;
  public const float EDELGARZEN_3_Event_33_Z = -18.0f;

  // ボス戦開始位置
  public const string EDELGARZEN_3_Event_34_C = "Event";
  public const string EDELGARZEN_3_Event_34_O = "34";
  public const float EDELGARZEN_3_Event_34_X = 30.0f;
  public const float EDELGARZEN_3_Event_34_Y = 0.0f;
  public const float EDELGARZEN_3_Event_34_Z = -10.0f;
  #endregion
  #region "看板"
  public const string EDELGARZEN_3_MessageBoard_1_C = "MessageBoard";
  public const string EDELGARZEN_3_MessageBoard_1_O = "1";
  public const float EDELGARZEN_3_MessageBoard_1_X = 13.0f;
  public const float EDELGARZEN_3_MessageBoard_1_Y = 1.0f;
  public const float EDELGARZEN_3_MessageBoard_1_Z = -7.0f;

  public const string EDELGARZEN_3_MessageBoard_2_C = "MessageBoard";
  public const string EDELGARZEN_3_MessageBoard_2_O = "2";
  public const float EDELGARZEN_3_MessageBoard_2_X = 30.0f;
  public const float EDELGARZEN_3_MessageBoard_2_Y = 1.0f;
  public const float EDELGARZEN_3_MessageBoard_2_Z = -16.0f;
  #endregion
  #endregion

  #region "4F"
  #region "Edelgarzen_Door"
  // 入口の扉
  public const string EDELGARZEN_4_DOOR_1_C = "Edelgarzen_Door";
  public const string EDELGARZEN_4_DOOR_1_O = "1";
  public const float EDELGARZEN_4_DOOR_1_X = 30.0f;
  public const float EDELGARZEN_4_DOOR_1_Y = 0.5f;
  public const float EDELGARZEN_4_DOOR_1_Z = -4.0f;

  // 中央部屋の扉
  public const string EDELGARZEN_4_DOOR_2_C = "Edelgarzen_Door";
  public const string EDELGARZEN_4_DOOR_2_O = "2";
  public const float EDELGARZEN_4_DOOR_2_X = 30.0f;
  public const float EDELGARZEN_4_DOOR_2_Y = 0.5f;
  public const float EDELGARZEN_4_DOOR_2_Z = -24.0f;
  #endregion
  #region "ObsidianStone"
  public const string EDELGARZEN_ObsidianStone_1_C = "ObsidianStone";
  public const string EDELGARZEN_ObsidianStone_1_O = "1";
  public const float EDELGARZEN_ObsidianStone_1_X = 30.0f;
  public const float EDELGARZEN_ObsidianStone_1_Y = 1.0f;
  public const float EDELGARZEN_ObsidianStone_1_Z = -33.0f;
  #endregion
  #region "階段"
  // 下り階段( 最上部 )
  public const string EDELGARZEN_4_DOWNSTAIR_1_C = "Downstair";
  public const string EDELGARZEN_4_DOWNSTAIR_1_O = "1";
  public const float EDELGARZEN_4_DOWNSTAIR_1_X = 30.0f;
  public const float EDELGARZEN_4_DOWNSTAIR_1_Y = 0.0f;
  public const float EDELGARZEN_4_DOWNSTAIR_1_Z = -2.0f;
  #endregion
  #region "Event"
  // ボス戦
  public const string EDELGARZEN_4_Event_1_C = "Event";
  public const string EDELGARZEN_4_Event_1_O = "1";
  public const float EDELGARZEN_4_Event_1_X = 30.0f;
  public const float EDELGARZEN_4_Event_1_Y = 0.0f;
  public const float EDELGARZEN_4_Event_1_Z = -5.0f;

  // ObsidianStone
  public const string EDELGARZEN_4_Event_2_C = "Event";
  public const string EDELGARZEN_4_Event_2_O = "2";
  public const float EDELGARZEN_4_Event_2_X = 30.0f;
  public const float EDELGARZEN_4_Event_2_Y = 0.0f;
  public const float EDELGARZEN_4_Event_2_Z = -32.0f;

  // ObsidianStone到達後の移動制限
  public const string EDELGARZEN_4_Event_3_C = "Event";
  public const string EDELGARZEN_4_Event_3_O = "3";
  public const float EDELGARZEN_4_Event_3_X = 30.0f;
  public const float EDELGARZEN_4_Event_3_Y = 0.0f;
  public const float EDELGARZEN_4_Event_3_Z = -31.0f;

  // Obsidian Portal
  public const string EDELGARZEN_4_Event_4_C = "Event";
  public const string EDELGARZEN_4_Event_4_O = "4";
  public const float EDELGARZEN_4_Event_4_X = 30.0f;
  public const float EDELGARZEN_4_Event_4_Y = 0.5f;
  public const float EDELGARZEN_4_Event_4_Z = -35.0f;
  #endregion
  #endregion

  #region "回復の泉"
  public const string EDELGARZEN_FOUNTAIN_1_C = "Fountain";
  public const string EDELGARZEN_FOUNTAIN_1_O = "1";
  public const float EDELGARZEN_FOUNTAIN_1_X = 8.0f;
  public const float EDELGARZEN_FOUNTAIN_1_Y = 1.0f;
  public const float EDELGARZEN_FOUNTAIN_1_Z = -37.0f;

  public const string EDELGARZEN_FOUNTAIN_2_C = "Fountain";
  public const string EDELGARZEN_FOUNTAIN_2_O = "2";
  public const float EDELGARZEN_FOUNTAIN_2_X = 31.0f;
  public const float EDELGARZEN_FOUNTAIN_2_Y = 1.0f;
  public const float EDELGARZEN_FOUNTAIN_2_Z = -36.0f;
  #endregion
  #endregion
  #region "離島ウォズム"
  // 最初の地点
  public const string WOSM_EVENT_1_C = "Event";
  public const string WOSM_EVENT_1_O = "1";
  public const float WOSM_EVENT_1_X = 10.0f;
  public const float WOSM_EVENT_1_Y = 0.0f;
  public const float WOSM_EVENT_1_Z = -18.0f;

  // ボス戦
  public const string WOSM_EVENT_2_C = "Event";
  public const string WOSM_EVENT_2_O = "2";
  public const float WOSM_EVENT_2_X = 10.0f;
  public const float WOSM_EVENT_2_Y = 0.0f;
  public const float WOSM_EVENT_2_Z = -12.0f;

  // エンディング
  public const string WOSM_EVENT_3_C = "Event";
  public const string WOSM_EVENT_3_O = "3";
  public const float WOSM_EVENT_3_X = 10.0f;
  public const float WOSM_EVENT_3_Y = 0.0f;
  public const float WOSM_EVENT_3_Z = -10.0f;

  // 移動抑止（エンディング）
  public const string WOSM_EVENT_4_C = "Event";
  public const string WOSM_EVENT_4_O = "4";
  public const float WOSM_EVENT_4_X = 10.0f;
  public const float WOSM_EVENT_4_Y = 0.0f;
  public const float WOSM_EVENT_4_Z = -13.0f;

  // トゥルーエンド
  public const string WOSM_EVENT_5_C = "Event";
  public const string WOSM_EVENT_5_O = "5";
  public const float WOSM_EVENT_5_X = 10.0f;
  public const float WOSM_EVENT_5_Y = 0.0f;
  public const float WOSM_EVENT_5_Z = -8.0f;

  #endregion
  #region "全体フィールド"
  // 最初の地点
  public const string BASEFIELD_EVENT_1_C = "Event";
  public const string BASEFIELD_EVENT_1_O = "1";
  public const float BASEFIELD_EVENT_1_X = 65.0f;
  public const float BASEFIELD_EVENT_1_Y = -2.0f;
  public const float BASEFIELD_EVENT_1_Z = 30.0f;

  // キルクード山脈の開始地点
  public const string BASEFIELD_EVENT_2_C = "Event";
  public const string BASEFIELD_EVENT_2_O = "2";
  public const float BASEFIELD_EVENT_2_X = -6.0f;
  public const float BASEFIELD_EVENT_2_Y = 4.5f;
  public const float BASEFIELD_EVENT_2_Z = 55.0f;

  // キルクード山脈→オーランの塔向け通路（ビュー）
  public const string BASEFIELD_EVENT_3_C = "Event";
  public const string BASEFIELD_EVENT_3_O = "3";
  public const float BASEFIELD_EVENT_3_X = -4.0f;
  public const float BASEFIELD_EVENT_3_Y = 9.0f;
  public const float BASEFIELD_EVENT_3_Z = 39.0f;

  // キルクード山脈→オーランの塔向け通路（ブロック用）
  public const string BASEFIELD_EVENT_4_C = "Event";
  public const string BASEFIELD_EVENT_4_O = "4";
  public const float BASEFIELD_EVENT_4_X = -4.0f;
  public const float BASEFIELD_EVENT_4_Y = 9.0f;
  public const float BASEFIELD_EVENT_4_Z = 38.0f;

  // キルクード山脈→ツァルマンの里向け通路（ビュー）
  public const string BASEFIELD_EVENT_5_C = "Event";
  public const string BASEFIELD_EVENT_5_O = "5";
  public const float BASEFIELD_EVENT_5_X = 13.0f;
  public const float BASEFIELD_EVENT_5_Y = 15.5f;
  public const float BASEFIELD_EVENT_5_Z = 53.0f;

  // キルクード山脈→ツァルマンの里向け通路（ブロック用）
  public const string BASEFIELD_EVENT_6_C = "Event";
  public const string BASEFIELD_EVENT_6_O = "6";
  public const float BASEFIELD_EVENT_6_X = 14.0f;
  public const float BASEFIELD_EVENT_6_Y = 15.5f;
  public const float BASEFIELD_EVENT_6_Z = 53.0f;

  // キルクード山脈→パルメティシア神殿方向（ビュー）
  public const string BASEFIELD_EVENT_7_C = "Event";
  public const string BASEFIELD_EVENT_7_O = "7";
  public const float BASEFIELD_EVENT_7_X = 4.0f;
  public const float BASEFIELD_EVENT_7_Y = 22.5f;
  public const float BASEFIELD_EVENT_7_Z = 54.0f;

  // 天上界ジェネシスゲート手前
  public const string BASEFIELD_EVENT_8_C = "Event";
  public const string BASEFIELD_EVENT_8_O = "8";
  public const float BASEFIELD_EVENT_8_X = 0.0f;
  public const float BASEFIELD_EVENT_8_Y = 29.5f;
  public const float BASEFIELD_EVENT_8_Z = 48.0f;

  // 天上界ジェネシスゲート台座地点
  public const string BASEFIELD_EVENT_9_C = "Event";
  public const string BASEFIELD_EVENT_9_O = "9";
  public const float BASEFIELD_EVENT_9_X = 2.0f;
  public const float BASEFIELD_EVENT_9_Y = 30.0f;
  public const float BASEFIELD_EVENT_9_Z = 48.0f;
  #endregion
  #endregion

  #region "Hometown"
  public const string BACKGROUND_MORNING = @"hometown"; // ".jpg"; // change unity
  public const string BACKGROUND_EVENING = @"hometown_evening"; // ".jpg"; // change unity
  public const string BACKGROUND_NIGHT = @"hometown2"; // ".jpg"; // change unity
  #endregion

  #region "World Keyword"
  #region "Scenario"
  public const string WORLD_EVILPRIME_REDSTAR = "赤褐色の星";
  public const string WORLD_NORMAL_SEVENSTAR = "七つ星";
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

  public const string NAME_LEGAL_ORPHSTEIN = "リガール";
  public const string NAME_LEGAL_ORPHSTEIN＿FULL = "リガール・オルフシュタイン";

  public const string NAME_VERZE_ARTIE = @"ヴェルゼ";
  public const string NAME_VERZE_ARTIE_FULL = @"ヴェルゼ・アーティ";

  public const string NAME_OL_LANDIS = @"ランディス";
  public const string NAME_OL_LANDIS_FULL = @"オル・ランディス";

  public const string NAME_SINIKIA_KAHLHANZ = @"カールハンツ";
  public const string NAME_SINIKIA_KAHLHANZ_FULL = @"シニキア・カールハンツ";
  #endregion
  #region "Duel対戦相手"
  public const string DUEL_PLAYER_1 = "Duel Player 1";
  public const string DUEL_PLAYER_1_JP = "デュエルプレイヤー１";
  public const string DUEL_DUMMY_SUBURI = "Dummy Suburi-Kun";
  public const string DUEL_DUMMY_SUBURI_JP = "ダミー・素振り君";
  public const string DUEL_EGALT_SANDY = "Egalt Sandy";
  public const string DUEL_EGALT_SANDY_JP = "エガルト・サンディ";
  public const string DUEL_YORZEN_GORMEZ = "Yorzen Gormez";
  public const string DUEL_YORZEN_GORMEZ_JP = "ヨーゼン・ゴルメッツ";
  public const string DUEL_GILMEL_SHTORF = "Gilmel Shtorf";
  public const string DUEL_GILMEL_SHTORF_JP = "ジルメル・シュトルフ";
  public const string DUEL_ALJINA_MEIRI = "Aljina Meiri";
  public const string DUEL_ALJINA_MEIRI_JP = "アルジナ・メイリ";
  public const string DUEL_ZATKON_MEMBER_1 = "ZAT-KON Member 1";
  public const string DUEL_ZATKON_MEMBER_1_JP = "ZAT-KON メンバー１";
  public const string DUEL_ZATKON_MEMBER_2 = "ZAT-KON Member 2";
  public const string DUEL_ZATKON_MEMBER_2_JP = "ZAT-KON メンバー２";
  public const string DUEL_ARDAM_VIO = "Ardam Vio";
  public const string DUEL_ARDAM_VIO_JP = "アーダム・ヴィオ";
  public const string DUEL_WELK_ZADA = "Welk Zada";
  public const string DUEL_WELK_ZADA_JP = "ウェルク・ザダ";
  public const string DUEL_HERAL_JITTE = "Heral Jitte";
  public const string DUEL_HERAL_JITTE_JP = "ハーラル・ジッテ";
  public const string DUEL_LENE_COLTOS = "Lene Coltos";
  public const string DUEL_LENE_COLTOS_JP = "レネ・コルトス";
  public const string DUEL_SCOTY_ZALGE = "Scoty Zalge";
  public const string DUEL_SCOTY_ZALGE_JP = "スコーティ・ザルゲ";
  public const string DUEL_SHLSTHS_DEMIGOR = "Shlths Demigor";
  public const string DUEL_SHLSTHS_DEMIGOR_JP = "シルシス・デミゴル";
  public const string DUEL_JEDA_ARUS = "Jeda Arus";
  public const string DUEL_JEDA_ARUS_JP = "ジェダ・アルス";
  public const string DUEL_SELMOI_RO = "ZAT-KON Deadly-Assasin\r\nSelmoi-Ro";
  public const string DUEL_SELMOI_RO_JP = "ZAT-KON 強襲暗殺部隊\r\nセルモイ ロウ";
  public const string DUEL_CALMANS_OHN = "Calmans Ohn";
  public const string DUEL_CALMANS_OHN_JP = "ZAT-KON 裏・忍・長\r\nカルマンズ・オーン";
  // シェル・ザ・ソードナイト
  public const string DUEL_EONE_FULNEA = "Eone Fulnea "; // DUEL名識別のため、最後の空白スペースで意図的に区別
  public const string DUEL_EONE_FULNEA_JP = "エオネ・フルネア "; // DUEL名識別のため、最後の空白スペースで意図的に区別
  public const string DUEL_OL_LANDIS = "Ol Landis";
  public const string DUEL_OL_LANDIS_Jp = "オル・ランディス";
  public const string DUEL_SHINIKIA_KAHLHANZ = "Shinikia Kahlhanz";
  public const string DUEL_SHINIKIA_KAHLHANZ_JP = "シニキア・カールハンツ";
  public const string DUEL_SIN_OSCURETE = "Sin Oscurete";
  public const string DUEL_SIN_OSCURETE_JP = "シン・オスキュレーテ";
  // リガール・オルフシュタイン
  // エルミ・ジョルジュ
  #endregion
  #region "Area"
  public const string AREA_FAZIL = "ファージル";
  public const string AREA_VINSGARDE = "ヴィンスガルデ";
  public const string AREA_MOONFORDER = "ムーンフォーダー";
  #endregion
  #region "Hometown"
  public const string TOWN_ANSHET = "アンシェット街";
  public const string TOWN_ANSHET_ICON = "TownIcon_AnshetTown";
  public const string TOWN_QVELTA_TOWN = "クヴェルタ街";
  public const string TOWN_COTUHSYE = "港町コチューシェ";
  public const string TOWN_COTUHSYE_ICON = "TownIcon_CotusyeTown";
  public const string TOWN_ZHALMAN = "ツァルマンの里";
  public const string TOWN_ZHALMAN_ICON = "TownIcon_ZhalmanVillage";
  public const string TOWN_WOSM = "ウォズム村";
  public const string TOWN_ARCANEDINE = "アーケンダイン街";
  public const string TOWN_DALE = "ディルの街";
  public const string TOWER_OHRAN = "オーランの塔";
  public const string TOWN_LATA_HOUSE = "ラタの小屋";
  public const string TOWN_ZELMAN = "ゼールマンの里";
  public const string TOWER_FRAN = "フーランの塔";
  public const string TOWN_FAZIL_CASTLE = "ファージル宮殿";
  public const string TOWN_FAZIL_CASTLE_ICON = "TownIcon_FazilCastle";
  public const string TOWN_PARMETYSIA = "パルメテイシア神殿";
  public const string TOWN_PARMETYSIA_ICON = "TownIcon_ParmetysiaTemple";
  public const string TOWN_EDELGARZEN_CASTLE = "エデルガイゼン城";
  public const string TOWN_FAZIL_UNDERGROUND = "ファージル宮殿地下";
  #endregion
  #region "Dungeon"
  public const string DUNGEON_ESMILIA_GRASSFIELD = "エスミリア草原区域";
  public const string DUNGEON_ESMILIA_GRASSFIELD_ICON = "Dungeon_EsmiliaGrassfield";
  public const string DUNGEON_ARTHARIUM_FACTORY = "アーサリウム工場跡地";
  public const string DUNGEON_GORATRUM_CAVE = "ゴラトラムの洞窟";
  public const string DUNGEON_GORATRUM_CAVE_ICON = "Dungeon_GoratrumCave";
  public const string DUNGEON_OHRAN_TOWER = "オーランの塔";
  public const string DUNGEON_OHRAN_TOWER_ICON = "Dungeon_OhranTower";
  public const string DUNGEON_VELGUS_SEA_TEMPLE = "ヴェルガス海底神殿 第一階層";
  public const string DUNGEON_VELGUS_SEA_TEMPLE_ICON = "Dungeon_VelgusSeaTemple";
  public const string DUNGEON_VELGUS_SEA_TEMPLE_2 = "ヴェルガス海底神殿 第二階層";
  public const string DUNGEON_VELGUS_SEA_TEMPLE_3 = "ヴェルガス海底神殿 第三階層";
  public const string DUNGEON_VELGUS_SEA_TEMPLE_4 = "ヴェルガス海底神殿 最深部";
  public const string DUNGEON_MYSTIC_FOREST = "神秘の森";
  public const string DUNGEON_MYSTIC_FOREST_ICON = "Dungeon_MysticForest";
  public const string DUNGEON_GATE_OF_DHAL = "ダルの門";
  public const string DUNGEON_RUINS_OF_SARITAN = "廃墟サリタン";
  public const string DUNGEON_SNOWTREE_LATA = "雪原の大樹ラタ";
  public const string DUNGEON_DISKEL_BATTLE_FIELD = "ディスケル戦場跡地";
  public const string DUNGEON_EDELGARZEN_CASTLE = "エデルガイゼン城 第一階層";
  public const string DUNGEON_EDELGARZEN_CASTLE_ICON = "Dungeon_Edelgarzen";
  public const string DUNGEON_EDELGARZEN_CASTLE_2 = "エデルガイゼン城 第二階層";
  public const string DUNGEON_EDELGARZEN_CASTLE_3 = "エデルガイゼン城 第三階層";
  public const string DUNGEON_EDELGARZEN_CASTLE_4 = "エデルガイゼン城 最上階";
  public const string DUNGEON_SITH_GRAVEYARD = "シスの墓標";
  public const string DUNGEON_GANRO_FORTRESS = "ガンロー要塞";
  public const string DUNGEON_LOSLON_CAVE = "ロスロンの洞窟";
  public const string DUNGEON_HEAVENS_GENESIS_GATE = "天上界ジェネシスゲート";

  public const string DUNGEON_EDELGARZEN_CASTLE_CENTER = "エデルガイゼン城 正面ゲート";
  public const string DUNGEON_EDELGARZEN_CASTLE_CENTER_ICON = "Dungeon_Edelgarzen";
  #endregion
  #region "Field"
  public const string FIELD_ESMILIA_GRASS_AREA = "エスミリア草原区域";
  public const string FIELD_ARTHARIUM_FACTORY = "アーサリウム工場跡地";
  public const string FIELD_GORATRUM_DUNGEON = "ゴラトラムの洞窟";
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
